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

namespace StyleCop.ReSharper60.Core
{
    #region Using Directives

    using System;

    using JetBrains.ReSharper.Daemon;
    using JetBrains.ReSharper.Psi;

    using StyleCop.Diagnostics;

    #endregion

    /// <summary>
    /// Daemon stage for StyleCop. This class is automatically loaded by ReSharper daemon 
    /// because it's marked with the <see cref="DaemonStageAttribute"/> attribute.
    /// </summary>
    [DaemonStage]
    public class StyleCopStage : IDaemonStage
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

        #region Implemented Interfaces

        #region IDaemonStage

        /// <summary>
        /// This method provides a <see cref="IDaemonStageProcess"/> instance which is assigned to highlighting a single document.
        /// </summary>
        /// <param name="process">
        /// Current Daemon Process.
        /// </param>
        /// <param name="processKind">
        /// The process kind.
        /// </param>
        /// <returns>
        /// Current <see cref="IDaemonStageProcess"/>.
        /// </returns>
        public IDaemonStageProcess CreateProcess(IDaemonProcess process, DaemonProcessKind processKind)
        {
            StyleCopTrace.In(process, processKind);

            if (process == null)
            {
                throw new ArgumentNullException("process");
            }

            if (processKind == DaemonProcessKind.OTHER)
            {
                StyleCopTrace.Out();

                return null;
            }

            return StyleCopTrace.Out(new StyleCopStageProcess(process));
        }
        
        /// <summary>
        /// We want to add markers to the right-side stripe as well as contribute to document errors.
        /// </summary>
        /// <param name="projectFile">
        /// File that the Stripe needs to be applied to.
        /// </param>
        /// <returns>
        /// A <see cref="ErrorStripeRequest"/> for the specified file.
        /// </returns>
        public ErrorStripeRequest NeedsErrorStripe(IPsiSourceFile projectFile)
        {
            return ErrorStripeRequest.STRIPE_AND_ERRORS;
        }

        #endregion

        #endregion
    }
}