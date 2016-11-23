// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Enum.cs" company="https://github.com/StyleCop">
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
//   Describes the contents of an  element.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Describes the contents of an <see cref="Enum"/> element.
    /// </summary>
    /// <subcategory>element</subcategory>
    [SuppressMessage("Microsoft.Naming", "CA1716:IdentifiersShouldNotMatchKeywords", Justification = "The class describes a C# enum.")]
    [SuppressMessage("Microsoft.Naming", "CA1711:IdentifiersShouldNotHaveIncorrectSuffix", Justification = "The class name does not need any suffix.")]
    public sealed class Enum : CsElement
    {
        #region Fields

        /// <summary>
        /// The derived base type.
        /// </summary>
        private string baseType;

        /// <summary>
        /// The list of items in the <see cref="Enum"/>.
        /// </summary>
        private ICollection<EnumItem> items;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Enum"/> class.
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
        internal Enum(
            CsDocument document, CsElement parent, XmlHeader header, ICollection<Attribute> attributes, Declaration declaration, bool unsafeCode, bool generated)
            : base(document, parent, ElementType.Enum, "enum " + declaration.Name, header, attributes, declaration, unsafeCode, generated)
        {
            Param.Ignore(document, parent, header, attributes, declaration, unsafeCode, generated);
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the base type for the <see cref="Enum"/>.
        /// </summary>
        public string BaseType
        {
            get
            {
                return this.baseType;
            }
        }

        /// <summary>
        /// Gets the collection of items in the <see cref="Enum"/>.
        /// </summary>
        public ICollection<EnumItem> Items
        {
            get
            {
                return this.items;
            }

            internal set
            {
                Param.AssertNotNull(value, "Items");
                this.items = value;

                Debug.Assert(this.items.IsReadOnly, "The collection of enum items should be read-only.");
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the base type, if there is one.
        /// </summary>
        internal override void Initialize()
        {
            // Get the base type, if any.
            this.baseType = this.GetBaseType();
        }

        /// <summary>
        /// Gets the base type of the item.
        /// </summary>
        /// <returns>Returns the name of the base type or null if none.</returns>
        private string GetBaseType()
        {
            // Pull out the base type.
            bool foundColon = false;
            foreach (CsToken token in this.Declaration.Tokens)
            {
                if (foundColon)
                {
                    if (token.CsTokenType != CsTokenType.WhiteSpace && token.CsTokenType != CsTokenType.EndOfLine && token.CsTokenType != CsTokenType.SingleLineComment
                        && token.CsTokenType != CsTokenType.MultiLineComment && token.CsTokenType != CsTokenType.PreprocessorDirective)
                    {
                        return token.Text;
                    }
                }
                else if (token.Text == ":")
                {
                    foundColon = true;
                }
            }

            return null;
        }

        #endregion
    }
}