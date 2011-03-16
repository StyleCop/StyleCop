//-----------------------------------------------------------------------
// <copyright file="SyntaxException.cs">
//   MS-PL
// </copyright>
// <license>
//   This source code is subject to terms and conditions of the Microsoft 
//   Public License. A copy of the license can be found in the License.html 
//   file at the root of this distribution. 
//   By using this source code in any fashion, you are agreeing to be bound 
//   by the terms of the Microsoft Public License. You must not remove this 
//   notice, or any other, from this software.
// </license>
//-----------------------------------------------------------------------
namespace StyleCop.CSharp.CodeModel
{
    using System;
    using System.Globalization;
    using System.Runtime.Serialization;
    using System.Security.Permissions;

    /// <summary>
    /// Exception which is thrown when a syntax error is found in the code
    /// which prevents StyleCop from analyzing the code.
    /// </summary>
    [Serializable]
    public sealed class SyntaxException : Exception
    {
        #region Private Fields

        /// <summary>
        /// The source code document that contains the syntax error.
        /// </summary>
        private Code sourceCode;

        /// <summary>
        /// The document.
        /// </summary>
        private CsDocument document;

        /// <summary>
        /// The line number that the error appears on.
        /// </summary>
        private int lineNumber = 1;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the SyntaxException class.
        /// </summary>
        internal SyntaxException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the SyntaxException class.
        /// </summary>
        /// <param name="sourceCode">The source code document containing the exception.</param>
        /// <param name="lineNumber">The line number of the exception.</param>
        internal SyntaxException(Code sourceCode, int lineNumber)
            : base(string.Format(CultureInfo.CurrentCulture, Strings.SyntaxErrorInFile, sourceCode.Path, lineNumber))
        {
            Param.AssertNotNull(sourceCode, "sourceCode");
            Param.AssertGreaterThanZero(lineNumber, "lineNumber");

            this.sourceCode = sourceCode;
            this.lineNumber = lineNumber;
        }

        /// <summary>
        /// Initializes a new instance of the SyntaxException class.
        /// </summary>
        /// <param name="sourceCode">The source code document containing the exception.</param>
        /// <param name="lineNumber">The line number of the exception.</param>
        /// <param name="message">The exception message.</param>
        internal SyntaxException(Code sourceCode, int lineNumber, string message)
            : base(string.Format(CultureInfo.CurrentCulture, Strings.SyntaxErrorInFileWithMessage, sourceCode.Path, lineNumber, message))
        {
            Param.AssertNotNull(sourceCode, "sourceCode");
            Param.AssertGreaterThanZero(lineNumber, "lineNumber");
            Param.AssertValidString(message, "message");

            this.sourceCode = sourceCode;
            this.lineNumber = lineNumber;
        }

        /// <summary>
        /// Initializes a new instance of the SyntaxException class.
        /// </summary>
        /// <param name="sourceCode">The source code document containing the exception.</param>
        /// <param name="lineNumber">The line number of the exception.</param>
        /// <param name="innerException">The exception within this exception.</param>
        internal SyntaxException(Code sourceCode, int lineNumber, Exception innerException)
            : base(string.Format(CultureInfo.CurrentCulture, Strings.SyntaxErrorInFile, sourceCode.Path, lineNumber), innerException)
        {
            Param.AssertNotNull(sourceCode, "sourceCode");
            Param.AssertGreaterThanZero(lineNumber, "lineNumber");
            Param.Ignore(innerException);

            this.sourceCode = sourceCode;
            this.lineNumber = lineNumber;
        }

        /// <summary>
        /// Initializes a new instance of the SyntaxException class.
        /// </summary>
        /// <param name="sourceCode">The source code document containing the exception.</param>
        /// <param name="lineNumber">The line number of the exception.</param>
        /// <param name="message">The exception message.</param>
        /// <param name="innerException">The exception within this exception.</param>
        internal SyntaxException(Code sourceCode, int lineNumber, string message, Exception innerException)
            : base(string.Format(CultureInfo.CurrentCulture, Strings.SyntaxErrorInFileWithMessage, sourceCode.Path, lineNumber, message), innerException)
        {
            Param.AssertNotNull(sourceCode, "sourceCode");
            Param.AssertGreaterThanZero(lineNumber, "lineNumber");
            Param.AssertValidString(message, "message");
            Param.Ignore(innerException);

            this.sourceCode = sourceCode;
            this.lineNumber = lineNumber;
        }

        /// <summary>
        /// Initializes a new instance of the SyntaxException class.
        /// </summary>
        /// <param name="document">The document containing the exception.</param>
        /// <param name="lineNumber">The line number of the exception.</param>
        internal SyntaxException(CsDocument document, int lineNumber)
            : base(string.Format(CultureInfo.CurrentCulture, Strings.SyntaxErrorInFile, document.Name, lineNumber))
        {
            Param.AssertNotNull(document, "document");
            Param.AssertGreaterThanZero(lineNumber, "lineNumber");

            this.document = document;
            this.lineNumber = lineNumber;
        }

        /// <summary>
        /// Initializes a new instance of the SyntaxException class.
        /// </summary>
        /// <param name="document">The document containing the exception.</param>
        /// <param name="lineNumber">The line number of the exception.</param>
        /// <param name="message">The exception message.</param>
        internal SyntaxException(CsDocument document, int lineNumber, string message)
            : base(string.Format(CultureInfo.CurrentCulture, Strings.SyntaxErrorInFileWithMessage, document.Name, lineNumber, message))
        {
            Param.AssertNotNull(document, "document");
            Param.AssertGreaterThanZero(lineNumber, "lineNumber");
            Param.AssertValidString(message, "message");

            this.document = document;
            this.lineNumber = lineNumber;
        }

        /// <summary>
        /// Initializes a new instance of the SyntaxException class.
        /// </summary>
        /// <param name="document">The document containing the exception.</param>
        /// <param name="lineNumber">The line number of the exception.</param>
        /// <param name="innerException">The exception within this exception.</param>
        internal SyntaxException(CsDocument document, int lineNumber, Exception innerException)
            : base(string.Format(CultureInfo.CurrentCulture, Strings.SyntaxErrorInFile, document.Name, lineNumber), innerException)
        {
            Param.AssertNotNull(document, "document");
            Param.AssertGreaterThanZero(lineNumber, "lineNumber");
            Param.Ignore(innerException);

            this.document = document;
            this.lineNumber = lineNumber;
        }

        /// <summary>
        /// Initializes a new instance of the SyntaxException class.
        /// </summary>
        /// <param name="document">The document containing the exception.</param>
        /// <param name="lineNumber">The line number of the exception.</param>
        /// <param name="message">The exception message.</param>
        /// <param name="innerException">The exception within this exception.</param>
        internal SyntaxException(CsDocument document, int lineNumber, string message, Exception innerException)
            : base(string.Format(CultureInfo.CurrentCulture, Strings.SyntaxErrorInFileWithMessage, document.Name, lineNumber, message), innerException)
        {
            Param.AssertNotNull(document, "document");
            Param.AssertGreaterThanZero(lineNumber, "lineNumber");
            Param.AssertValidString(message, "message");
            Param.Ignore(innerException);

            this.document = document;
            this.lineNumber = lineNumber;
        }

        /// <summary>
        /// Initializes a new instance of the SyntaxException class.
        /// </summary>
        /// <param name="serializationInfo">Holds the serialization info about the exception.</param>
        /// <param name="streamingContext">Holds contextual information.</param>
        private SyntaxException(SerializationInfo serializationInfo, StreamingContext streamingContext)
            : base(serializationInfo, streamingContext)
        {
            Param.Ignore(serializationInfo, streamingContext);
        }

        #endregion Internal Constructors

        #region Public Properties

        /// <summary>
        /// Gets the name of the source code document that contains the syntax error.
        /// </summary>
        public string SourceCodeName
        {
            get
            {
                return this.sourceCode != null ? this.sourceCode.Name : this.document != null ? this.document.Name : string.Empty;
            }
        }

        /// <summary>
        /// Gets the path to the source code document that contains the syntax error.
        /// </summary>
        public string SourceCodePath
        {
            get
            {
                return this.sourceCode != null ? this.sourceCode.Path : this.document != null ? this.document.Path : string.Empty;
            }
        }

        /// <summary>
        /// Gets the document that contains the syntax error.
        /// </summary>
        public CsDocument Document
        {
            get
            {
                return this.document;
            }
        }

        /// <summary>
        /// Gets the line number that the syntax error appears on.
        /// </summary>
        public int LineNumber
        {
            get
            {
                return this.lineNumber;
            }
        }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Populates a SerializationInfo with the data needed to serialize the target object.
        /// </summary>
        /// <param name="info">The SerializationInfo to populate with data.</param>
        /// <param name="context">The destination context for this serialization.</param>
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            Param.Ignore(info, context);
            base.GetObjectData(info, context);
        }

        #endregion Public Methods
    }
}
