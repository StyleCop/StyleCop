// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StyleCopStage.cs" company="http://stylecop.codeplex.com">
//   MS-PL
// </copyright>
// <license>
//   This source code is subject to terms and conditions of the Microsoft 
//   Public License. A copy of the license can be found in the License.html 
//   file at the root of this distribution. If you cannot locate the  
//   Microsoft Public License, please send an email to dlr@microsoft.com. 
//   By using this source code in any fashion, you are agreeing to be bound 
//   by the terms of the Microsoft Public License. You must not remove this 
//   notice, or any other, from this software.
// </license>
// <summary>
//   Daemon stage for StyleCop. This class is automatically loaded by ReSharper daemon
//   because it's marked with the <see cref="DaemonStageAttribute" /> attribute.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
extern alias JB;

namespace StyleCop.ReSharper611.Core
{
    #region Using Directives

    using System;
    using System.Linq;

    using JetBrains.Application.Progress;
    using JetBrains.Application.Settings;
    using JetBrains.ReSharper.Daemon;
    using JetBrains.ReSharper.Daemon.CSharp.Stages;
    using JetBrains.ReSharper.Psi;
    using JetBrains.ReSharper.Psi.Tree;

    using StyleCop.Diagnostics;
    using StyleCop.ReSharper611.Options;

    #endregion

    /// <summary>
    /// Daemon stage for StyleCop. This class is automatically loaded by ReSharper daemon 
    /// because it's marked with the <see cref="DaemonStageAttribute"/> attribute.
    /// </summary>
    [DaemonStage]
    public class StyleCopStage : CSharpDaemonStageBase  
    {
        #region Properties

        /// <summary>
        /// Gets a value indicating whether this stage should be run for documents that aren't shown.
        /// </summary>
        /// <remarks>
        /// This stage shouldn't be run on documents which are not shown now.
        /// </remarks>
        public bool RunForInvisibleDocuments
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Gets the stage we want to run our process before.
        /// </summary>
        public Type[] StagesAfter
        {
            get
            {
                return JB::JetBrains.Util.EmptyArray<Type>.Instance;
            }
        }

        /// <summary>
        /// Gets the stage we want to run our process after.
        /// </summary>
        /// <remarks>
        /// We want to put our markers after language-dependent code analysis.
        /// </remarks>
        public Type[] StagesBefore
        {
            get
            {
                return new[] { typeof(LanguageSpecificDaemonStage) };
            }
        }

        #endregion
        
        /// <summary>
        /// This method provides a <see cref="IDaemonStageProcess"/> instance which is assigned to highlighting a single document.
        /// </summary>
        /// <param name="process">
        /// Current Daemon Process.
        /// </param>
        /// <param name="settingsStore">
        /// The settingsStore store to use.
        /// </param>
        /// <param name="processKind">
        /// The process kind.
        /// </param>
        /// <returns>
        /// Current <see cref="IDaemonStageProcess"/>.
        /// </returns>
        public override IDaemonStageProcess CreateProcess(IDaemonProcess process, IContextBoundSettingsStore settingsStore, DaemonProcessKind processKind)
        {
            StyleCopTrace.In(process, settingsStore, processKind);

            if (process == null)
            {
                throw new ArgumentNullException("process");
            }

            try
            {
                if (processKind == DaemonProcessKind.OTHER)
                {
                    StyleCopTrace.Info("ProcessKind Other.");
                    StyleCopTrace.Out();
                    return null;
                }

                if (!settingsStore.GetValue<StyleCopOptionsSettingsKey, bool>(key => key.AnalysisEnabled))
                {
                    StyleCopTrace.Info("Analysis disabled.");
                    StyleCopTrace.Out();
                    return null;
                }

                if (!this.IsSupported(process.SourceFile))
                {
                    StyleCopTrace.Info("File type not supported.");
                    StyleCopTrace.Out();
                    return null;
                }

                if (!this.FileIsValid(process.SourceFile))
                {
                    StyleCopTrace.Info("Source file not valid.");
                    StyleCopTrace.Out();
                    return null;
                }

                if (!settingsStore.GetValue<StyleCopOptionsSettingsKey, bool>(key => key.AnalyseReadOnlyFiles))
                {
                    if (process.SourceFile.Properties.IsNonUserFile)
                    {
                        StyleCopTrace.Info("Not analysing non user files.");
                        StyleCopTrace.Out();
                        return null;
                    }
                }

                return StyleCopTrace.Out(new StyleCopStageProcess(process, settingsStore));
            }
            catch (ProcessCancelledException)
            {
                return null;
            }
        }

        /// <summary>
        /// We want to add markers to the right-side stripe as well as contribute to document errors.
        /// </summary>
        /// <param name="sourceFile">
        /// File that the Stripe needs to be applied to.
        /// </param>
        /// <param name="settingsStore">
        /// The store to use.
        /// </param>
        /// <returns>
        /// A <see cref="ErrorStripeRequest"/> for the specified file.
        /// </returns>
        public ErrorStripeRequest NeedsErrorStripe(IPsiSourceFile sourceFile, IContextBoundSettingsStore settingsStore)
        {
            return ErrorStripeRequest.STRIPE_AND_ERRORS;
        }

        /// <summary>
        /// Checks the given file is valid to check.
        /// </summary>
        /// <param name="sourceFile">THe file to check.</param>
        /// <returns>True if its valid.</returns>
        private bool FileIsValid(IPsiSourceFile sourceFile)
        {
            if (sourceFile == null)
            {
                return false;
            }

            var file = CSharpDaemonStageBase.GetPsiFile(sourceFile);

            if (file == null)
            {
                return false;
            }

            var hasErrorElements = new RecursiveElementCollector<IErrorElement>(null).ProcessElement(file).GetResults().Any();
            
            return !hasErrorElements;
        }
    }
}