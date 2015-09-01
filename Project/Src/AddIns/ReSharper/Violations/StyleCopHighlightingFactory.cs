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
namespace StyleCop.ReSharper.Violations
{
    #region Using Directives

    using JetBrains.DocumentModel;
    using JetBrains.ProjectModel;
    using JetBrains.ReSharper.Feature.Services.Daemon;
    using JetBrains.ReSharper.Resources.Shell;

    using StyleCop.ReSharper.Options;

    #endregion

    /// <summary>
    /// Factory class for getting HighLights for StyleCop violations.
    /// </summary>
    public static class StyleCopHighlightingFactory
    {
        #region Public Methods and Operators

        /// <summary>
        /// Gets the highlight for the specified StyleCop Violation.
        /// </summary>
        /// <param name="violation">
        /// The <see cref="StyleCop.ViolationEventArgs"/> instance containing the event data.
        /// </param>
        /// <param name="documentRange">
        /// <see cref="DocumentRange"/>where the Violation happened.
        /// </param>
        /// <returns>
        /// An <see cref="IHighlighting"/> for the specified Violation.
        /// </returns>
        public static IHighlighting GetHighlight(ViolationEventArgs violation, DocumentRange documentRange)
        {
            string ruleID = violation.Violation.Rule.CheckId;
            string highlightID = HighlightingRegistering.GetHighlightID(ruleID);

            SolutionManagerBase solutionManager = Shell.Instance.GetComponent<SolutionManagerBase>();

            Severity severity = HighlightingSettingsManager.Instance.GetConfigurableSeverity(highlightID, solutionManager.CurrentSolution);

            switch (severity)
            {
                case Severity.ERROR:
                    return new StyleCopHighlightingError(violation, documentRange);
                case Severity.HINT:
                    return new StyleCopHighlightingHint(violation, documentRange);
                case Severity.INFO:
                    return new StyleCopHighlightingError(violation, documentRange);
                case Severity.SUGGESTION:
                    return new StyleCopHighlightingSuggestion(violation, documentRange);
                case Severity.WARNING:
                    return new StyleCopHighlightingWarning(violation, documentRange);
                default:
                    return new StyleCopHighlightingDoNotShow(violation, documentRange);
            }
        }

        #endregion
    }
}