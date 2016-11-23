// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DocumentRoot.cs" company="https://github.com/StyleCop">
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
//   An element which represents the root level of a document.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    /// <summary>
    /// An element which represents the root level of a document.
    /// </summary>
    /// <subcategory>element</subcategory>
    public sealed class DocumentRoot : Namespace
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the DocumentRoot class.
        /// </summary>
        /// <param name="document">
        /// The document that this element belongs to.
        /// </param>
        /// <param name="declaration">
        /// The declaration class for this element.
        /// </param>
        /// <param name="generated">
        /// Indicates whether the element contains generated code.
        /// </param>
        internal DocumentRoot(CsDocument document, Declaration declaration, bool generated)
            : base(document, null, ElementType.Root, Strings.DocumentRoot, null, null, declaration, false, generated)
        {
            Param.AssertNotNull(document, "document");
            Param.AssertNotNull(declaration, "declaration");
            Param.Ignore(generated);
        }

        #endregion
    }
}