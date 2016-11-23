// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmptyElement.cs" company="https://github.com/StyleCop">
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
//   Describes an element consisting only of a single semicolon.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    /// <summary>
    /// Describes an element consisting only of a single semicolon.
    /// </summary>
    /// <subcategory>element</subcategory>
    public sealed class EmptyElement : CsElement
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the EmptyElement class.
        /// </summary>
        /// <param name="document">
        /// The document that contains the element.
        /// </param>
        /// <param name="parent">
        /// The parent of the element.
        /// </param>
        /// <param name="declaration">
        /// The declaration code for this element.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the element resides within a block of unsafe code.
        /// </param>
        /// <param name="generated">
        /// Indicates whether the code element was generated or written by hand.
        /// </param>
        internal EmptyElement(CsDocument document, CsElement parent, Declaration declaration, bool unsafeCode, bool generated)
            : base(document, parent, ElementType.EmptyElement, Strings.EmptyElement, null, null, declaration, unsafeCode, generated)
        {
            Param.AssertNotNull(document, "document");
            Param.AssertNotNull(parent, "parent");
            Param.AssertNotNull(declaration, "declaration");
            Param.Ignore(unsafeCode);
            Param.Ignore(generated);
        }

        #endregion
    }
}