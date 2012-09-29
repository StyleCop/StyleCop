// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StyleCopHighlightingFactory.cs" company="http://stylecop.codeplex.com">
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
//   Factory class for getting HighLights for StyleCop violations.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace StyleCop.ReSharper710.Violations
{
    #region Using Directives

    using JetBrains.Application;
    using JetBrains.Application.Settings;
    using JetBrains.DocumentModel;
    using JetBrains.ProjectModel;
    using JetBrains.ReSharper.Daemon;
    using JetBrains.ReSharper.Psi;
    using JetBrains.VsIntegration.ProjectModel;

    using StyleCop.ReSharper710.Options;

    #endregion

    /// <summary>
    /// Factory class for getting HighLights for StyleCop violations.
    /// </summary>
    public static class StyleCopHighlightingFactory
    {
        #region Public Methods

        /// <summary>
        /// Gets the highlight for the specified StyleCop Violation.
        /// </summary>
        /// <param name="violation">
        /// The <see cref="StyleCop.ViolationEventArgs"/> instance containing the event data.
        /// </param>
        /// <param name="documentRange">
        /// <see cref="DocumentRange"/>where the Violation happened.
        /// </param>
        /// <param name="fileName">
        /// <see cref="CsElement"/>of the violation.
        /// </param>
        /// <param name="lineNumber">
        /// Line number where the violation happened.
        /// </param>
        /// <returns>
        /// An <see cref="IHighlighting"/> for the specified Violation.
        /// </returns>
        public static IHighlighting GetHighlight(ViolationEventArgs violation, DocumentRange documentRange, string fileName, int lineNumber)
        {
            var ruleID = violation.Violation.Rule.CheckId;
            var highlightID = HighlightingRegistering.GetHighlightID(ruleID);

            var solutionManager = Shell.Instance.GetComponent<VSSolutionManager>();
           
            var settingsStore = PsiSourceFileExtensions.GetSettingsStore(null, solutionManager.CurrentSolution);

            var severity = HighlightingSettingsManager.Instance.GetConfigurableSeverity(highlightID, settingsStore);
            
            switch (severity)
            {
                case Severity.ERROR:
                    return new StyleCopHighlightingError(violation, documentRange, fileName, lineNumber);
                case Severity.HINT:
                    return new StyleCopHighlightingHint(violation, documentRange, fileName, lineNumber);
                case Severity.INFO:
                    return new StyleCopHighlightingError(violation, documentRange, fileName, lineNumber);
                case Severity.SUGGESTION:
                    return new StyleCopHighlightingSuggestion(violation, documentRange, fileName, lineNumber);
                case Severity.WARNING:
                    return new StyleCopHighlightingWarning(violation, documentRange, fileName, lineNumber);
                default:
                    return new StyleCopHighlightingDoNotShow(violation, documentRange, fileName, lineNumber);
            }
        }

        #endregion
    }
}