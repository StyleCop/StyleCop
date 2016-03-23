// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StyleCopHighlightingBase.cs" company="http://stylecop.codeplex.com">
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
//   Highlights the StyleCop Violation within the IDE.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.ReSharper.Violations
{
    using JetBrains.DocumentModel;
    using JetBrains.ReSharper.Feature.Services.Daemon;

    /// <summary>
    /// Highlights the StyleCop Violation within the IDE.
    /// </summary>
    public abstract class StyleCopHighlightingBase : IHighlighting
    {
        private readonly DocumentRange documentRange;

        /// <summary>
        /// Initializes a new instance of the <see cref="StyleCopHighlightingBase"/> class.
        /// </summary>
        /// <param name="violationEventArgs">
        /// The <see cref="StyleCop.ViolationEventArgs"/> instance containing the Violation data.
        /// </param>
        /// <param name="documentRange">
        /// Range where the Violation happened.
        /// </param>
        protected StyleCopHighlightingBase(ViolationEventArgs violationEventArgs, DocumentRange documentRange)
        {
            this.CheckId = violationEventArgs.Violation.Rule.CheckId;
            this.ToolTip = violationEventArgs.Message + " [StyleCop Rule: " + this.CheckId + "]";
            this.documentRange = documentRange;
            this.Rule = violationEventArgs.Violation.Rule;
            this.Violation = violationEventArgs.Violation;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StyleCopHighlightingBase"/> class with the specified tooltip and text range.
        /// </summary>
        /// <param name="tooltip">
        /// The tooltip.
        /// </param>
        protected StyleCopHighlightingBase(string tooltip)
        {
            this.ToolTip = tooltip;
        }

        /// <summary>
        /// Gets the check id for the Violation.
        /// </summary>
        public string CheckId { get; private set; }

        /// <summary>
        /// Gets the tooltip to be displayed on the error stripe within the IDE.
        /// </summary>
        public string ErrorStripeToolTip
        {
            get
            {
                return this.ToolTip;
            }
        }

        /// <summary>
        /// Gets the Offset.
        /// </summary>
        public int NavigationOffsetPatch
        {
            get
            {
                return 0;
            }
        }

        /// <summary>
        /// Gets the rule that the violation is for.
        /// </summary>
        public Rule Rule { get; private set; }

        /// <summary>
        /// Gets the tooltip to display on the highlight.
        /// </summary>
        public string ToolTip { get; private set; }

        /// <summary>
        /// Gets the internal Violation.
        /// </summary>
        public Violation Violation { get; private set; }

        /// <summary>
        /// Gets or sets the text range where the Violation happened.
        /// </summary>
        /// <returns>
        /// The document range of the highlight.
        /// </returns>
        public DocumentRange CalculateRange()
        {
            return this.documentRange;
        }

        /// <summary>
        /// Returns true if valid.
        /// </summary>
        /// <returns>
        /// True if valid.
        /// </returns>
        public bool IsValid()
        {
            return true;
        }
    }
}