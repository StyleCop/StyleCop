//-----------------------------------------------------------------------
// <copyright file="ICodeDocumentExtensions.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.
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
namespace Microsoft.StyleCop.CSharp
{
    using System;
    using Microsoft.StyleCop.CSharp.CodeModel;

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
    }
}
