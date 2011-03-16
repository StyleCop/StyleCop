//-----------------------------------------------------------------------
// <copyright file="ICodeDocumentExtensions.cs">
//     MS-PL
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
namespace StyleCop.CSharp
{
    using System;
    using System.Diagnostics;
    using StyleCop.CSharp.CodeModel;

    /// <summary>
    /// Extensions for the ICodeDocument interface.
    /// </summary>
    public static class ICodeDocumentExtensions
    {
        /// <summary>
        /// Coverts the given document into a <see cref="CsDocument" /> if possible.
        /// </summary>
        /// <param name="document">The document to convert.</param>
        /// <returns>Returns the converted document or null.</returns>
        public static CsDocument AsCsDocument(this ICodeDocument document)
        {
            Param.RequireNotNull(document, "document");

            CsDocumentWrapper wrapper = document as CsDocumentWrapper;
            if (wrapper == null)
            {
                return null;
            }

            return wrapper.CsDocument;
        }

        /// <summary>
        /// Gets a value indicating whether the document is read-only.
        /// </summary>
        /// <param name="document">The document.</param>
        /// <returns>Returns true if the document is readonly.</returns>
        public static bool IsReadOnly(this CsDocument document)
        {
            Param.RequireNotNull(document, "document");

            var wrapper = CsDocumentWrapper.Wrapper(document);
            Debug.Assert(wrapper != null, "Document has not been wrapped.");

            return wrapper.ReadOnly;
        }
    }
}
