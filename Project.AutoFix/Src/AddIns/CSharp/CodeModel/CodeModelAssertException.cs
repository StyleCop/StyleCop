//-----------------------------------------------------------------------
// <copyright file="CodeModelAssertException.cs">
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
    public sealed class CodeModelAssertException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the CodeModelAssertException class.
        /// </summary>
        internal CodeModelAssertException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the CodeModelAssertException class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        internal CodeModelAssertException(string message)
            : base(string.Format(CultureInfo.CurrentCulture, Strings.ThrowOnAssert, message))
        {
            Param.AssertValidString(message, "message");
        }

        /// <summary>
        /// Initializes a new instance of the CodeModelAssertException class.
        /// </summary>
        /// <param name="innerException">The exception within this exception.</param>
        internal CodeModelAssertException(Exception innerException)
            : base(string.Format(CultureInfo.CurrentCulture, Strings.ThrowOnAssert), innerException)
        {
            Param.Ignore(innerException);
        }

        /// <summary>
        /// Initializes a new instance of the CodeModelAssertException class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        /// <param name="innerException">The exception within this exception.</param>
        internal CodeModelAssertException(string message, Exception innerException)
            : base(string.Format(CultureInfo.CurrentCulture, Strings.ThrowOnAssert, message), innerException)
        {
            Param.AssertValidString(message, "message");
            Param.Ignore(innerException);
        }

        /// <summary>
        /// Initializes a new instance of the CodeModelAssertException class.
        /// </summary>
        /// <param name="serializationInfo">Holds the serialization info about the exception.</param>
        /// <param name="streamingContext">Holds contextual information.</param>
        private CodeModelAssertException(SerializationInfo serializationInfo, StreamingContext streamingContext)
            : base(serializationInfo, streamingContext)
        {
            Param.Ignore(serializationInfo, streamingContext);
        }

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
    }
}
