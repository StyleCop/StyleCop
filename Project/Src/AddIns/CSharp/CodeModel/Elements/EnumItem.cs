//-----------------------------------------------------------------------
// <copyright file="EnumItem.cs" company="Microsoft">
//   Copyright (c) Microsoft Corporation.
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
namespace Microsoft.StyleCop.CSharp.CodeModel
{
    using System;
    using System.Collections.Generic;
    
    /// <summary>
    /// Describes a single item within an enum element.
    /// </summary>
    /// <subcategory>element</subcategory>
    public sealed class EnumItem : Element
    {
        #region Private Fields

        /// <summary>
        /// The initialization expression, if there is one.
        /// </summary>
        private CodeUnitProperty<Expression> initialization;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the EnumItem class.
        /// </summary>
        /// <param name="proxy">Proxy object for the enum.</param>
        /// <param name="name">The name of the enum.</param>
        /// <param name="attributes">The list of attributes attached to this element.</param>
        /// <param name="initialization">The initialization expression, if there is one.</param>
        /// <param name="unsafeCode">Indicates whether the element resides within a block of unsafe code.</param>
        internal EnumItem(CodeUnitProxy proxy, string name, ICollection<Attribute> attributes, Expression initialization, bool unsafeCode)
            : base(proxy, ElementType.EnumItem, name, attributes, unsafeCode)
        {
            Param.AssertNotNull(proxy, "proxy");
            Param.AssertValidString(name, "name");
            Param.Ignore(attributes, initialization, unsafeCode);

            this.initialization.Value = initialization;
        }

        #endregion Internal Constructors

        #region Public Properties

        /// <summary>
        /// Gets the initialization expression for the enum item, if there is one.
        /// </summary>
        public Expression Initialization
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.initialization.Initialized)
                {
                    this.initialization.Value = this.FindFirstChild<Expression>();
                }

                return this.initialization.Value;
            }
        }

        #endregion Public Properties

        #region Protected Override Properties

        /// <summary>
        /// Gets the collection of modifiers allowed on this element.
        /// </summary>
        protected override IEnumerable<string> AllowedModifiers
        {
            get
            {
                return new string[] { };
            }
        }

        #endregion Protected Override Properties

        #region Protected Override Methods

        /// <summary>
        /// Gets the name of the element.
        /// </summary>
        /// <returns>The name of the element.</returns>
        protected override string GetElementName()
        {
            for (Token token = this.FindFirstChild<Token>(); token != null; token = token.FindNextSibling<Token>())
            {
                if (token.Is(TokenType.Literal) || token.Is(TokenType.Type))
                {
                    return token.Text;
                }
            }

            throw new SyntaxException(this.Document, this.LineNumber);
        }

        /// <summary>
        /// Resets the contents of the class.
        /// </summary>
        protected override void Reset()
        {
            base.Reset();
            this.initialization.Reset();
        }

        #endregion Protected Override Methods
    }
}
