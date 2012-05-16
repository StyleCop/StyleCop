// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StyleCopCodeCleanupModule.cs" company="http://stylecop.codeplex.com">
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
// --------------------------------------------------------------------------------------------------------------------

extern alias JB;

namespace StyleCop.ReSharper611.CodeCleanup
{
    #region Using Directives

    using System.Collections.Generic;

    using JetBrains.Application;
    using JetBrains.DocumentModel;
    using JetBrains.ReSharper.Feature.Services.CodeCleanup;
    using JetBrains.ReSharper.Feature.Services.CSharp.CodeCleanup;
    using JetBrains.ReSharper.Psi;
    using JetBrains.ReSharper.Psi.CSharp;
    using JetBrains.ReSharper.Psi.CSharp.Tree;

    using StyleCop.Diagnostics;
    using StyleCop.ReSharper611.CodeCleanup.Descriptors;
    using StyleCop.ReSharper611.CodeCleanup.Options;
    using StyleCop.ReSharper611.CodeCleanup.Rules;

    #endregion

    /// <summary>
    ///   Custom StyleCop CodeCleanUp module to fix StyleCop violations.
    ///   We ensure that most of the ReSharper modules are run before we are.
    /// </summary>
    [CodeCleanupModule(ModulesBefore = new[] { typeof(UpdateFileHeader), typeof(ArrangeThisQualifier), typeof(ReplaceByVar), typeof(ReformatCode) })]
    public class StyleCopCodeCleanupModule : ICodeCleanupModule
    {
        #region Constants and Fields

        /// <summary>
        ///   Documentation descriptor.
        /// </summary>
        private static readonly DocumentationDescriptor documentationDescriptor = new DocumentationDescriptor();

        /// <summary>
        ///   Layout descriptor.
        /// </summary>
        private static readonly LayoutDescriptor layoutDescriptor = new LayoutDescriptor();

        /// <summary>
        ///   Maintainability descriptor.
        /// </summary>
        private static readonly MaintainabilityDescriptor maintainabilityDescriptor = new MaintainabilityDescriptor();

        /// <summary>
        ///   Ordering descriptor.
        /// </summary>
        private static readonly OrderingDescriptor orderingDescriptor = new OrderingDescriptor();

        /// <summary>
        ///   Readability descriptor.
        /// </summary>
        private static readonly ReadabilityDescriptor readabilityDescriptor = new ReadabilityDescriptor();

        /// <summary>
        ///   Spacing descriptor.
        /// </summary>
        private static readonly SpacingDescriptor spacingDescriptor = new SpacingDescriptor();

        /// <summary>
        ///   Locks object passed to our constructor.
        /// </summary>
        private readonly IShellLocks shellLocks;

        #endregion

        /// <summary>
        /// Initializes a new instance of the StyleCopCodeCleanupModule class.
        /// </summary>
        /// <param name = "shellLocks">
        /// The IShellLocks object.
        /// </param>
        public StyleCopCodeCleanupModule(IShellLocks shellLocks)
        {
            this.shellLocks = shellLocks;
        }

        #region Properties

        /// <summary>
        /// Gets the collection of option descriptors.
        /// </summary>
        /// <value>
        /// The descriptors.
        /// </value>
        public ICollection<CodeCleanupOptionDescriptor> Descriptors
        {
            get
            {
                return new CodeCleanupOptionDescriptor[] { documentationDescriptor, layoutDescriptor, maintainabilityDescriptor, orderingDescriptor, readabilityDescriptor, spacingDescriptor };
            }
        }

        /// <summary>
        /// Gets a value indicating whether the module is available on selection, or on the whole file.
        /// </summary>
        /// <value>
        /// The is available on selection.
        /// </value>
        public bool IsAvailableOnSelection
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Gets the language this module can operate.
        /// </summary>
        /// <value>
        /// The language type.
        /// </value>
        public PsiLanguageType LanguageType
        {
            get
            {
                return CSharpLanguage.Instance;
            }
        }

        #endregion

        #region Implemented Interfaces

        #region ICodeCleanupModule

        /// <summary>
        /// Check if this module can handle given project file.
        /// </summary>
        /// <param name = "projectFile">
        /// The project file to check.
        /// </param>
        /// <returns>
        /// <c>True.</c>if the project file is available; otherwise 
        /// <c>False.</c>.
        /// </returns>
        public bool IsAvailable(IPsiSourceFile projectFile)
        {
            return projectFile.GetPsiFile<CSharpLanguage>() != null;
        }

        /// <summary>
        /// Process clean-up on file.
        /// </summary>
        /// <param name = "projectFile">
        /// The project file to process.
        /// </param>
        /// <param name = "rangeMarker">
        /// The range marker to process.
        /// </param>
        /// <param name = "profile">
        /// The code cleanup settings to use.
        /// </param>
        /// <param name = "progressIndicator">
        /// The progress indicator.
        /// </param>
        public void Process(IPsiSourceFile projectFile, IRangeMarker rangeMarker, CodeCleanupProfile profile, JB::JetBrains.Application.Progress.IProgressIndicator progressIndicator)
        {
            if (projectFile == null)
            {
                return;
            }

            if (!this.IsAvailable(projectFile))
            {
                return;
            }

            var solution = projectFile.GetSolution();

            var file = projectFile.GetPsiFile<CSharpLanguage>() as ICSharpFile;

            if (file == null)
            {
                return;
            }
            
            PsiManager.GetInstance(solution).DoTransaction(() => this.InternalProcess(profile, file), "Code cleanup");
            
            StyleCopTrace.Out();
        }
        
        /// <summary>
        /// Get default setting for given profile type.
        /// </summary>
        /// <param name = "profile">
        /// The code cleanup profile to use.
        /// </param>
        /// <param name = "profileType">
        /// Determine if it is a full or reformat <see cref = "CodeCleanup.DefaultProfileType" />.
        /// </param>
        public void SetDefaultSetting(CodeCleanupProfile profile, CodeCleanup.DefaultProfileType profileType)
        {
            // Default option are set in the constructors.
            var orderingOptions = new OrderingOptions();
            profile.SetSetting(orderingDescriptor, orderingOptions);

            var layoutOptions = new LayoutOptions();
            profile.SetSetting(layoutDescriptor, layoutOptions);

            var documentationOptions = new DocumentationOptions();
            profile.SetSetting(documentationDescriptor, documentationOptions);

            var spacingOptions = new SpacingOptions();
            profile.SetSetting(spacingDescriptor, spacingOptions);

            var readabilityOptions = new ReadabilityOptions();
            profile.SetSetting(readabilityDescriptor, readabilityOptions);

            var maintainabilityOptions = new MaintainabilityOptions();
            profile.SetSetting(maintainabilityDescriptor, maintainabilityOptions);
        }

        /// <summary>
        /// Processes all the cleanup.
        /// </summary>
        /// <param name="profile">The current profile to use.</param>
        /// <param name="file">The file to clean.</param>
        private void InternalProcess(CodeCleanupProfile profile, ICSharpFile file)
        {
            var documentationOptions = profile.GetSetting(documentationDescriptor);
            var layoutOptions = profile.GetSetting(layoutDescriptor);
            var maintainabilityOptions = profile.GetSetting(maintainabilityDescriptor);
            var orderingOptions = profile.GetSetting(orderingDescriptor);
            var readabilityOptions = profile.GetSetting(readabilityDescriptor);
            var spacingOptions = profile.GetSetting(spacingDescriptor);

            // Process the file for all the different Code Cleanups we have here
            // we do them in a very specific order. Do not change it.
            new ReadabilityRules(this.shellLocks).Execute(readabilityOptions, file);
            new MaintainabilityRules().Execute(maintainabilityOptions, file);
            new DocumentationRules().Execute(documentationOptions, file);
            new LayoutRules().Execute(layoutOptions, file);
            new SpacingRules().Execute(spacingOptions, file);
            new OrderingRules().Execute(orderingOptions, file);
        }

        #endregion

        #endregion
    }
}