// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SyntaxException.cs" company="https://github.com/StyleCop">
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
//   Exception which is thrown when a syntax error is found in the code
//   which prevents StyleCop from analyzing the code.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop
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
        #region Fields

        /// <summary>
        /// The line number that the error appears on.
        /// </summary>
        private readonly int lineNumber = 1;

        /// <summary>
        /// The source code document that contains the syntax error.
        /// </summary>
        private readonly SourceCode sourceCode;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the SyntaxException class.
        /// </summary>
        public SyntaxException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the SyntaxException class.
        /// </summary>
        /// <param name="sourceCode">
        /// The source code document containing the exception.
        /// </param>
        /// <param name="lineNumber">
        /// The line number of the exception.
        /// </param>
        public SyntaxException(SourceCode sourceCode, int lineNumber)
            : base(string.Format(CultureInfo.CurrentCulture, Strings.SyntaxErrorInFile, sourceCode.Path, lineNumber))
        {
            Param.RequireNotNull(sourceCode, "sourceCode");
            Param.RequireGreaterThanZero(lineNumber, "lineNumber");

            this.sourceCode = sourceCode;
            this.lineNumber = lineNumber;
        }

        /// <summary>
        /// Initializes a new instance of the SyntaxException class.
        /// </summary>
        /// <param name="sourceCode">
        /// The source code document containing the exception.
        /// </param>
        /// <param name="lineNumber">
        /// The line number of the exception.
        /// </param>
        /// <param name="message">
        /// The exception message.
        /// </param>
        public SyntaxException(SourceCode sourceCode, int lineNumber, string message)
            : base(string.Format(CultureInfo.CurrentCulture, Strings.SyntaxErrorInFileWithMessage, sourceCode.Path, lineNumber, message))
        {
            Param.RequireNotNull(sourceCode, "sourceCode");
            Param.RequireGreaterThanZero(lineNumber, "lineNumber");
            Param.RequireValidString(message, "message");

            this.sourceCode = sourceCode;
            this.lineNumber = lineNumber;
        }

        /// <summary>
        /// Initializes a new instance of the SyntaxException class.
        /// </summary>
        /// <param name="sourceCode">
        /// The source code document containing the exception.
        /// </param>
        /// <param name="lineNumber">
        /// The line number of the exception.
        /// </param>
        /// <param name="innerException">
        /// The exception within this exception.
        /// </param>
        public SyntaxException(SourceCode sourceCode, int lineNumber, Exception innerException)
            : base(string.Format(CultureInfo.CurrentCulture, Strings.SyntaxErrorInFile, sourceCode.Path, lineNumber), innerException)
        {
            Param.RequireNotNull(sourceCode, "sourceCode");
            Param.RequireGreaterThanZero(lineNumber, "lineNumber");
            Param.Ignore(innerException);

            this.sourceCode = sourceCode;
            this.lineNumber = lineNumber;
        }

        /// <summary>
        /// Initializes a new instance of the SyntaxException class.
        /// </summary>
        /// <param name="sourceCode">
        /// The source code document containing the exception.
        /// </param>
        /// <param name="lineNumber">
        /// The line number of the exception.
        /// </param>
        /// <param name="message">
        /// The exception message.
        /// </param>
        /// <param name="innerException">
        /// The exception within this exception.
        /// </param>
        public SyntaxException(SourceCode sourceCode, int lineNumber, string message, Exception innerException)
            : base(string.Format(CultureInfo.CurrentCulture, Strings.SyntaxErrorInFileWithMessage, sourceCode.Path, lineNumber, message), innerException)
        {
            Param.RequireNotNull(sourceCode, "sourceCode");
            Param.RequireGreaterThanZero(lineNumber, "lineNumber");
            Param.RequireValidString(message, "message");
            Param.Ignore(innerException);

            this.sourceCode = sourceCode;
            this.lineNumber = lineNumber;
        }

        /// <summary>
        /// Initializes a new instance of the SyntaxException class.
        /// </summary>
        /// <param name="serializationInfo">
        /// Holds the serialization info about the exception.
        /// </param>
        /// <param name="streamingContext">
        /// Holds contextual information.
        /// </param>
        private SyntaxException(SerializationInfo serializationInfo, StreamingContext streamingContext)
            : base(serializationInfo, streamingContext)
        {
            Param.Ignore(serializationInfo, streamingContext);
        }

        #endregion

        #region Public Properties

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

        /// <summary>
        /// Gets the source code document that contains the syntax error.
        /// </summary>
        public SourceCode SourceCode
        {
            get
            {
                return this.sourceCode;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Populates a SerializationInfo with the data needed to serialize the target object.
        /// </summary>
        /// <param name="info">
        /// The SerializationInfo to populate with data.
        /// </param>
        /// <param name="context">
        /// The destination context for this serialization.
        /// </param>
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            Param.Ignore(info, context);
            base.GetObjectData(info, context);
        }

        #endregion
    }
}