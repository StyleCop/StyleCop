// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EnumItem.cs" company="https://github.com/StyleCop">
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
//   Describes a single item within an  element.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    using System.Collections.Generic;

    /// <summary>
    /// Describes a single item within an <see cref="Enum"/> element.
    /// </summary>
    /// <subcategory>element</subcategory>
    public sealed class EnumItem : CsElement
    {
        #region Fields

        /// <summary>
        /// The initialization expression, if there is one.
        /// </summary>
        private readonly Expression initialization;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="EnumItem"/> class.
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
        /// <param name="initialization">
        /// The initialization expression, if there is one.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the element resides within a block of unsafe code.
        /// </param>
        /// <param name="generated">
        /// Indicates whether the code element was generated or written by hand.
        /// </param>
        internal EnumItem(
            CsDocument document, 
            Enum parent, 
            XmlHeader header, 
            ICollection<Attribute> attributes, 
            Declaration declaration, 
            Expression initialization, 
            bool unsafeCode, 
            bool generated)
            : base(document, parent, ElementType.EnumItem, "enum item " + declaration.Name, header, attributes, declaration, unsafeCode, generated)
        {
            Param.Ignore(document, parent, header, attributes, declaration, initialization, unsafeCode, generated);

            this.initialization = initialization;
            if (this.initialization != null)
            {
                this.AddExpression(this.initialization);
            }
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the initialization expression for the <see cref="Enum"/> item, if there is one.
        /// </summary>
        public Expression Initialization
        {
            get
            {
                return this.initialization;
            }
        }

        #endregion
    }
}