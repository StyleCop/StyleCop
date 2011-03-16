//-----------------------------------------------------------------------
// <copyright file="CodeModelException.cs">
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
    /// Exception which is thrown when an invalid change is made to a code model.
    /// </summary>
    [Serializable]
    public sealed class CodeModelException : Exception
    {
        #region Private Fields

        /// <summary>
        /// The source code document that contains the code model error.
        /// </summary>
        private Code sourceCode;

        /// <summary>
        /// The document.
        /// </summary>
        private CsDocument document;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the CodeModelException class.
        /// </summary>
        internal CodeModelException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the CodeModelException class.
        /// </summary>
        /// <param name="sourceCode">The source code document containing the exception.</param>
        internal CodeModelException(Code sourceCode)
            : base(string.Format(CultureInfo.CurrentCulture, Strings.CodeModelError, sourceCode.Path))
        {
            Param.AssertNotNull(sourceCode, "sourceCode");
            this.sourceCode = sourceCode;
        }

        /// <summary>
        /// Initializes a new instance of the CodeModelException class.
        /// </summary>
        /// <param name="sourceCode">The source code document containing the exception.</param>
        /// <param name="message">The exception message.</param>
        internal CodeModelException(Code sourceCode, string message)
            : base(string.Format(CultureInfo.CurrentCulture, Strings.CodeModelErrorWithMessage, sourceCode.Path, message))
        {
            Param.AssertNotNull(sourceCode, "sourceCode");
            Param.AssertValidString(message, "message");

            this.sourceCode = sourceCode;
        }

        /// <summary>
        /// Initializes a new instance of the CodeModelException class.
        /// </summary>
        /// <param name="sourceCode">The source code document containing the exception.</param>
        /// <param name="innerException">The exception within this exception.</param>
        internal CodeModelException(Code sourceCode, Exception innerException)
            : base(string.Format(CultureInfo.CurrentCulture, Strings.CodeModelError, sourceCode.Path), innerException)
        {
            Param.AssertNotNull(sourceCode, "sourceCode");
            Param.Ignore(innerException);

            this.sourceCode = sourceCode;
        }

        /// <summary>
        /// Initializes a new instance of the CodeModelException class.
        /// </summary>
        /// <param name="sourceCode">The source code document containing the exception.</param>
        /// <param name="message">The exception message.</param>
        /// <param name="innerException">The exception within this exception.</param>
        internal CodeModelException(Code sourceCode, string message, Exception innerException)
            : base(string.Format(CultureInfo.CurrentCulture, Strings.CodeModelErrorWithMessage, sourceCode.Path, message), innerException)
        {
            Param.AssertNotNull(sourceCode, "sourceCode");
            Param.AssertValidString(message, "message");
            Param.Ignore(innerException);

            this.sourceCode = sourceCode;
        }

        /// <summary>
        /// Initializes a new instance of the CodeModelException class.
        /// </summary>
        /// <param name="document">The document containing the exception.</param>
        internal CodeModelException(CsDocument document)
            : base(string.Format(CultureInfo.CurrentCulture, Strings.CodeModelError, document.Name))
        {
            Param.AssertNotNull(document, "document");
            this.document = document;
        }

        /// <summary>
        /// Initializes a new instance of the CodeModelException class.
        /// </summary>
        /// <param name="document">The document containing the exception.</param>
        /// <param name="message">The exception message.</param>
        internal CodeModelException(CsDocument document, string message)
            : base(string.Format(CultureInfo.CurrentCulture, Strings.CodeModelErrorWithMessage, document.Name, message))
        {
            Param.AssertNotNull(document, "document");
            Param.AssertValidString(message, "message");

            this.document = document;
        }

        /// <summary>
        /// Initializes a new instance of the CodeModelException class.
        /// </summary>
        /// <param name="document">The document containing the exception.</param>
        /// <param name="innerException">The exception within this exception.</param>
        internal CodeModelException(CsDocument document, Exception innerException)
            : base(string.Format(CultureInfo.CurrentCulture, Strings.CodeModelError, document.Name), innerException)
        {
            Param.AssertNotNull(document, "document");
            Param.Ignore(innerException);

            this.document = document;
        }

        /// <summary>
        /// Initializes a new instance of the CodeModelException class.
        /// </summary>
        /// <param name="document">The document containing the exception.</param>
        /// <param name="message">The exception message.</param>
        /// <param name="innerException">The exception within this exception.</param>
        internal CodeModelException(CsDocument document, string message, Exception innerException)
            : base(string.Format(CultureInfo.CurrentCulture, Strings.CodeModelErrorWithMessage, document.Name, message), innerException)
        {
            Param.AssertNotNull(document, "document");
            Param.AssertValidString(message, "message");
            Param.Ignore(innerException);

            this.document = document;
        }

        /// <summary>
        /// Initializes a new instance of the CodeModelException class.
        /// </summary>
        /// <param name="serializationInfo">Holds the serialization info about the exception.</param>
        /// <param name="streamingContext">Holds contextual information.</param>
        private CodeModelException(SerializationInfo serializationInfo, StreamingContext streamingContext)
            : base(serializationInfo, streamingContext)
        {
            Param.Ignore(serializationInfo, streamingContext);
        }

        #endregion Internal Constructors

        #region Public Properties

        /// <summary>
        /// Gets the name of the source code document that contains the code model error.
        /// </summary>
        public string SourceCodeName
        {
            get
            {
                return this.sourceCode != null ? this.sourceCode.Name : this.document != null ? this.document.Name : string.Empty;
            }
        }

        /// <summary>
        /// Gets the path to the source code document that contains the code model error.
        /// </summary>
        public string SourceCodePath
        {
            get
            {
                return this.sourceCode != null ? this.sourceCode.Path : this.document != null ? this.document.Path : string.Empty;
            }
        }

        /// <summary>
        /// Gets the document that contains the code model error.
        /// </summary>
        public CsDocument Document
        {
            get
            {
                return this.document;
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
