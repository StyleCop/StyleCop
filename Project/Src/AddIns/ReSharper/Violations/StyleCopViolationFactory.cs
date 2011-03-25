//-----------------------------------------------------------------------
// <copyright file="">
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
//-----------------------------------------------------------------------

namespace StyleCop.ReSharper.Violations
{
    #region Using Directives

    using JetBrains.DocumentModel;
    using JetBrains.ReSharper.Daemon;

    using StyleCop;
    using StyleCop.CSharp;

    using StyleCop.ReSharper.Options;

    #endregion

    /// <summary>
    /// Factory class for getting HighLights for StyleCop violations.
    /// </summary>
    public static class StyleCopViolationFactory
    {
        #region Public Methods

        /// <summary>
        /// Gets the highlight for the specified StyleCop Violation.
        /// </summary>
        /// <param name="violation">
        /// The <see cref="Microsoft.StyleCop.ViolationEventArgs"/> instance containing the event data.
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

            var severity = HighlightingSettingsManager.Instance.Settings.GetSeverity(highlightID);

            switch (severity)
            {
                case Severity.ERROR:
                    return new StyleCopViolationError(violation, documentRange, fileName, lineNumber);
                case Severity.HINT:
                    return new StyleCopViolationHint(violation, documentRange, fileName, lineNumber);
                case Severity.INFO:
                    return new StyleCopViolationError(violation, documentRange, fileName, lineNumber);
                case Severity.SUGGESTION:
                    return new StyleCopViolationSuggestion(violation, documentRange, fileName, lineNumber);
                case Severity.WARNING:
                    return new StyleCopViolationWarning(violation, documentRange, fileName, lineNumber);
                default:
                    return new StyleCopViolationDoNotShow(violation, documentRange, fileName, lineNumber);
            }
        }

        #endregion
    }
}