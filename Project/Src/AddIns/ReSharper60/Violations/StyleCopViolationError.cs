// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StyleCopViolationError.cs" company="http://stylecop.codeplex.com">
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
//   Highlighting class for a StyleCop Violation set to severity level Error.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace StyleCop.ReSharper60.Violations
{
    #region Using Directives

    using JetBrains.DocumentModel;
    using JetBrains.ReSharper.Daemon;

    using StyleCop.CSharp;

    #endregion

    /// <summary>
    /// Highlighting class for a StyleCop Violation set to severity level Error.
    /// </summary>
    [StaticSeverityHighlighting(ViolationSeverity, "a")]
    public class StyleCopViolationError : StyleCopViolationBase
    {
        #region Constants and Fields

        /// <summary>
        /// The Violation severity.
        /// </summary>
        private const Severity ViolationSeverity = Severity.ERROR;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="StyleCopViolationError"/> class.
        /// </summary>
        /// <param name="violation">
        /// The <see cref="StyleCop.ViolationEventArgs"/> instance containing the event data.
        /// </param>
        /// <param name="documentRange">
        /// Range where the Violation happened.
        /// </param>
        /// <param name="fileName">
        /// The file Name.
        /// </param>
        /// <param name="lineNumber">
        /// Line number of the violation.
        /// </param>
        public StyleCopViolationError(ViolationEventArgs violation, DocumentRange documentRange, string fileName, int lineNumber)
            : base(violation, documentRange, fileName, lineNumber)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StyleCopViolationError"/> class.
        /// </summary>
        /// <param name="tooltip">
        /// The tooltip.
        /// </param>
        public StyleCopViolationError(string tooltip)
            : base(tooltip)
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the severity of this highlighting.
        /// </summary>
        /// <value>
        /// </value>
        public override Severity Severity
        {
            get
            {
                return ViolationSeverity;
            }
        }

        #endregion
    }
}