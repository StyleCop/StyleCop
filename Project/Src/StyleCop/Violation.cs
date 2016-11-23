// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Violation.cs" company="https://github.com/StyleCop">
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
//   Describes one violation.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop
{
    using System.Globalization;

    /// <summary>
    /// Describes one violation.
    /// </summary>
    public class Violation
    {
        #region Fields

        /// <summary>
        /// The element that the violation appears in.
        /// </summary>
        private readonly ICodeElement element;

        /// <summary>
        /// The line number that the violation appears on.
        /// </summary>
        private readonly int line;

        /// <summary>
        /// The code location that the violation appears on.
        /// </summary>
        private readonly CodeLocation? location;

        /// <summary>
        /// The context message.
        /// </summary>
        private readonly string message;

        /// <summary>
        /// The rule that triggered the violation.
        /// </summary>
        private readonly Rule rule;

        /// <summary>
        /// The source code that the violation appears in.
        /// </summary>
        private readonly SourceCode sourceCode;

        /// <summary>
        /// The unique key for this violation.
        /// </summary>
        private int key;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the Violation class.
        /// </summary>
        /// <param name="rule">
        /// The rule that triggered the violation.
        /// </param>
        /// <param name="element">
        /// The element that this violation appears in.
        /// </param>
        /// <param name="location">
        /// The location in the source code where the violation occurs.
        /// </param>
        /// <param name="message">
        /// The context message for the violation.
        /// </param>
        internal Violation(Rule rule, ICodeElement element, CodeLocation location, string message)
        {
            Param.AssertNotNull(rule, "rule");
            Param.Ignore(element);
            Param.AssertNotNull(location, "location");
            Param.AssertNotNull(message, "message");

            this.rule = rule;
            this.element = element;

            // The CodeLocation passed in is zero based everywhere in StyleCop for the column. The line number is already 1 based.
            // We convert is to 1 based here so that are xml reports etc and VisualStudio UI friendly.
            this.location = new CodeLocation(
                location.StartPoint.Index, 
                location.EndPoint.Index, 
                location.StartPoint.IndexOnLine + 1, 
                location.EndPoint.IndexOnLine + 1, 
                location.StartPoint.LineNumber, 
                location.EndPoint.LineNumber);

            // If the location has been passed in we set the linenumber.
            this.line = location.LineNumber;
            this.message = message;

            if (this.element != null && this.element.Document != null)
            {
                this.sourceCode = this.element.Document.SourceCode;
            }

            this.UpdateKey();
        }

        /// <summary>
        /// Initializes a new instance of the Violation class.
        /// </summary>
        /// <param name="rule">
        /// The rule that triggered the violation.
        /// </param>
        /// <param name="element">
        /// The element that this violation appears in.
        /// </param>
        /// <param name="line">
        /// The line in the source code where the violation occurs.
        /// </param>
        /// <param name="message">
        /// The context message for the violation.
        /// </param>
        internal Violation(Rule rule, ICodeElement element, int line, string message)
        {
            Param.AssertNotNull(rule, "rule");
            Param.Ignore(element);
            Param.AssertGreaterThanOrEqualToZero(line, "line");
            Param.AssertNotNull(message, "message");

            this.rule = rule;
            this.element = element;
            this.line = line;

            // As the line only is passed in we ensure the location is null.
            // A null location indicates we only know the line it was on.
            this.location = null;
            this.message = message;

            if (this.element != null && this.element.Document != null)
            {
                this.sourceCode = this.element.Document.SourceCode;
            }

            this.UpdateKey();
        }

        /// <summary>
        /// Initializes a new instance of the Violation class.
        /// </summary>
        /// <param name="rule">
        /// The rule that triggered the violation.
        /// </param>
        /// <param name="sourceCode">
        /// The source code that this violation appears in.
        /// </param>
        /// <param name="location">
        /// The location in the source code where the violation occurs.
        /// </param>
        /// <param name="message">
        /// The context message for the violation.
        /// </param>
        internal Violation(Rule rule, SourceCode sourceCode, CodeLocation location, string message)
        {
            Param.AssertNotNull(rule, "rule");
            Param.Ignore(sourceCode);
            Param.AssertNotNull(location, "location");
            Param.AssertNotNull(message, "message");

            this.rule = rule;
            this.sourceCode = sourceCode;

            // The CodeLocation passed in is zero based everywhere in StyleCop for the column. The line number is already 1 based.
            // We convert is to 1 based here so that are xml reports etc and VisualStudio UI friendly.
            this.location = new CodeLocation(
                location.StartPoint.Index, 
                location.EndPoint.Index, 
                location.StartPoint.IndexOnLine + 1, 
                location.EndPoint.IndexOnLine + 1, 
                location.StartPoint.LineNumber, 
                location.EndPoint.LineNumber);

            // If the location has been passed in we set the linenumber.
            this.line = location.LineNumber;

            this.message = message;

            this.UpdateKey();
        }

        /// <summary>
        /// Initializes a new instance of the Violation class.
        /// </summary>
        /// <param name="rule">
        /// The rule that triggered the violation.
        /// </param>
        /// <param name="sourceCode">
        /// The source code that this violation appears in.
        /// </param>
        /// <param name="line">
        /// The line in the source code where the violation occurs.
        /// </param>
        /// <param name="message">
        /// The context message for the violation.
        /// </param>
        internal Violation(Rule rule, SourceCode sourceCode, int line, string message)
        {
            Param.AssertNotNull(rule, "rule");
            Param.Ignore(sourceCode);
            Param.AssertGreaterThanOrEqualToZero(line, "line");
            Param.AssertNotNull(message, "message");

            this.rule = rule;
            this.sourceCode = sourceCode;
            this.line = line;
            this.message = message;

            this.UpdateKey();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the element that contains the violation.
        /// </summary>
        public ICodeElement Element
        {
            get
            {
                return this.element;
            }
        }

        /// <summary>
        /// Gets the unique key for this violation that can be used when adding
        /// the violation to a dictionary.
        /// </summary>
        public int Key
        {
            get
            {
                return this.key;
            }
        }

        /// <summary>
        /// Gets the line number in the source code where the violation occurs.
        /// </summary>
        public int Line
        {
            get
            {
                return this.line;
            }
        }

        /// <summary>
        /// Gets the location the violation occurred on or null if we only know the line number. Location has a 1 based line and 1 based column.
        /// </summary>
        public CodeLocation? Location
        {
            get
            {
                return this.location;
            }
        }

        /// <summary>
        /// Gets the context message for the violation.
        /// </summary>
        public string Message
        {
            get
            {
                return this.message;
            }
        }

        /// <summary>
        /// Gets the rule that triggered the violation.
        /// </summary>
        public Rule Rule
        {
            get
            {
                return this.rule;
            }
        }

        /// <summary>
        /// Gets the source code that contains the violation.
        /// </summary>
        public SourceCode SourceCode
        {
            get
            {
                return this.sourceCode;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Updates the internal key.
        /// </summary>
        private void UpdateKey()
        {
            string lineText;

            // If the location has been set we need to allow multiple issues of the same type per line.
            // The key should join the location parts together (start.line,start.column, end.line, end.column)
            if (this.location == null)
            {
                lineText = this.line.ToString(CultureInfo.InvariantCulture);
            }
            else
            {
                lineText = string.Format(
                    "{0},{1},{2},{3}", 
                    this.location.Value.StartPoint.LineNumber, 
                    this.location.Value.StartPoint.IndexOnLine,
                    this.location.Value.EndPoint.LineNumber,
                    this.location.Value.EndPoint.IndexOnLine);
            }

            this.key = string.Format("{0}:{1}:{2}", this.rule.Name, lineText, this.message).GetHashCode();
        }

        #endregion
    }
}