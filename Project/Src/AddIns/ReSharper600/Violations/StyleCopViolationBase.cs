// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StyleCopViolationBase.cs" company="http://stylecop.codeplex.com">
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

namespace StyleCop.ReSharper600.Violations
{
    #region Using Directives

    using System.Drawing;

    using JetBrains.DocumentModel;
    using JetBrains.ReSharper.Daemon;

    #endregion

    /// <summary>
    /// Highlights the StyleCop Violation within the IDE.
    /// </summary>
    public abstract class StyleCopViolationBase : IHighlighting
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="StyleCopViolationBase"/> class.
        /// </summary>
        /// <param name="violation">
        /// The <see cref="StyleCop.ViolationEventArgs"/> instance containing the Violation data.
        /// </param>
        /// <param name="documentRange">
        /// Range where the Violation happened.
        /// </param>
        /// <param name="fileName">
        /// The file Name.
        /// </param>
        /// <param name="lineNumber">
        /// Line number of where the violation happened.
        /// </param>
        protected StyleCopViolationBase(ViolationEventArgs violation, DocumentRange documentRange, string fileName, int lineNumber)
        {
            this.CheckId = violation.Violation.Rule.CheckId;
            this.ToolTip = violation.Message + " [StyleCop Rule: " + this.CheckId + "]";
            this.DocumentRange = documentRange;
            this.FileName = fileName;
            this.LineNumber = lineNumber;
            this.Rule = violation.Violation.Rule;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StyleCopViolationBase"/> class.
        /// </summary>
        /// <param name="violation">
        /// The <see cref="StyleCop.ViolationEventArgs"/> instance containing the Violation data.
        /// </param>
        protected StyleCopViolationBase(ViolationEventArgs violation)
        {
            this.CheckId = violation.Violation.Rule.CheckId;
            this.ToolTip = violation.Message + " [StyleCop Rule: " + this.CheckId + "]";
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StyleCopViolationBase"/> class with the specified tooltip and text range.
        /// </summary>
        /// <param name="tooltip">
        /// The tooltip.
        /// </param>
        protected StyleCopViolationBase(string tooltip)
        {
            this.ToolTip = tooltip;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the attribute id.
        /// </summary>
        /// <value>
        /// The attribute id.
        /// </value>
        public virtual string AttributeId
        {
            get
            {
                switch (this.Severity)
                {
                    case Severity.ERROR:
                        return HighlightingAttributeIds.ERROR_ATTRIBUTE;
                    case Severity.WARNING:
                        return HighlightingAttributeIds.WARNING_ATTRIBUTE;
                    case Severity.SUGGESTION:
                        return HighlightingAttributeIds.SUGGESTION_ATTRIBUTE;
                    case Severity.HINT:
                        return HighlightingAttributeIds.HINT_ATTRIBUTE;
                    case Severity.INFO:
                    case Severity.DO_NOT_SHOW:
                        return null;
                }

                return null;
            }
        }

        /// <summary>
        /// Gets the check id for the Violation.
        /// </summary>
        public string CheckId { get; private set; }

        /// <summary>
        /// Gets the color on stripe.
        /// </summary>
        /// <value>
        /// The color on stripe.
        /// </value>
        public virtual Color ColorOnStripe
        {
            get
            {
                return Color.Empty;
            }
        }

        /// <summary>
        /// Gets or sets the text range where the Violation happened.
        /// </summary>
        public DocumentRange DocumentRange { get; set; }

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
        /// Gets or sets FileName.
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Gets or sets the line number where the Violation happened.
        /// </summary>
        public int LineNumber { get; set; }

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
        /// Gets the severity of this highlighting.
        /// </summary>
        /// <value>
        /// </value>
        public virtual Severity Severity
        {
            get
            {
                return Severity.ERROR;
            }
        }

        /// <summary>
        /// Gets or sets the tooltip to display on the highlight.
        /// </summary>
        public string ToolTip { get; set; }

        #endregion

        #region Implemented Interfaces

        #region IHighlighting

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

        #endregion

        #endregion
    }
}