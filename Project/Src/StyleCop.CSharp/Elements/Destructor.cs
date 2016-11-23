// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Destructor.cs" company="https://github.com/StyleCop">
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
//   Describes a class destructor.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    using System.Collections.Generic;

    /// <summary>
    /// Describes a class destructor.
    /// </summary>
    /// <subcategory>element</subcategory>
    public sealed class Destructor : CsElement
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the Destructor class.
        /// </summary>
        /// <param name="document">
        /// The document that contains the element.
        /// </param>
        /// <param name="parent">
        /// The parent of the element.
        /// </param>
        /// <param name="header">
        /// The Xml header for this element.
        /// </param>
        /// <param name="attributes">
        /// The list of attributes attached to this element.
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
        internal Destructor(
            CsDocument document, CsElement parent, XmlHeader header, ICollection<Attribute> attributes, Declaration declaration, bool unsafeCode, bool generated)
            : base(document, parent, ElementType.Destructor, "destructor " + declaration.Name, header, attributes, declaration, unsafeCode, generated)
        {
            Param.AssertNotNull(document, "document");
            Param.AssertNotNull(parent, "parent");
            Param.Ignore(header);
            Param.Ignore(attributes);
            Param.AssertNotNull(declaration, "declaration");
            Param.Ignore(unsafeCode);
            Param.Ignore(generated);

            // Static destructors are always public.
            if (this.Declaration.ContainsModifier(CsTokenType.Static))
            {
                this.Declaration.AccessModifierType = AccessModifierType.Public;
            }
        }

        #endregion
    }
}