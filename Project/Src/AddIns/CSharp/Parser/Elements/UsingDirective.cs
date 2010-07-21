//-----------------------------------------------------------------------
// <copyright file="UsingDirective.cs" company="Microsoft">
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
namespace Microsoft.StyleCop.CSharp
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Describes the contents of a using directive.
    /// </summary>
    /// <subcategory>element</subcategory>
    public sealed class UsingDirective : Element
    {
        #region Private Fields

        /// <summary>
        /// The namespace type declared by the using element.
        /// </summary>
        private string namespaceType = string.Empty;

        /// <summary>
        /// The alias mapped to the namespace type, if any.
        /// </summary>
        private string alias = string.Empty;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the UsingDirective class.
        /// </summary>
        /// <param name="proxy">Proxy object for the using directive.</param>
        /// <param name="name">The name of the using directive.</param>
        /// <param name="namespace">The namespace being used.</param>
        /// <param name="alias">Optional alias for the namespace, if any.</param>
        internal UsingDirective(CodeUnitProxy proxy, string name, string @namespace, string alias) 
            : base(proxy, ElementType.UsingDirective, name, null, false)
        {
            Param.AssertNotNull(proxy, "proxy");
            Param.AssertValidString(name, "name");
            Param.AssertValidString(@namespace, "namespace");
            Param.Ignore(alias);

            this.namespaceType = @namespace;

            if (alias != null)
            {
                this.alias = alias;
            }
        }

        #endregion Internal Constructors

        #region Public Properties

        /// <summary>
        /// Gets the alias defined within the using directive, if any.
        /// </summary>
        public string Alias
        {
            get
            {
                return this.alias;
            }
        }

        /// <summary>
        /// Gets the namespace type declared by the using element.
        /// </summary>
        public string NamespaceType
        {
            get
            {
                return this.namespaceType;
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

        #region Internal Override Methods

        /// <summary>
        /// Initializes the element.
        /// </summary>
        /// <param name="document">The document that contains the element.</param>
        internal override void Initialize(CsDocument document)
        {
            Param.AssertNotNull(document, "document");

            base.Initialize(document);

            // Find the 'using' keyword.
            Token usingKeyword = null;

            for (Token token = this.FindFirstChild<Token>(); token != null; token = token.FindNextSibling<Token>())
            {
                if (token.TokenType == TokenType.UsingDirective)
                {
                    usingKeyword = token;
                    break;
                }
            }

            // Make sure we found it.
            if (usingKeyword != null)
            {
                // Move past it.
                Token index = usingKeyword.FindNextSibling<Token>();
                if (index != null)
                {
                    // This word is usually the namespace type, unless an alias is defined.
                    this.namespaceType = CodeParser.TrimType(CodeParser.GetFullName(document, this, index, out index));

                    // Now see if the next word is an equals sign.
                    index = index.FindNextSibling<Token>();

                    if (index != null)
                    {
                        if (index.Text == "=")
                        {
                            // Get the word after the equals sign, which will be the namespace.
                            index = index.FindNextSibling<Token>();

                            if (index != null)
                            {
                                // Set the alias and the namespace.
                                this.alias = this.namespaceType;
                                this.namespaceType = CodeParser.TrimType(index.Text);
                            }
                        }
                    }
                }
            }
        }

        #endregion Internal Override Methods

        #region Protected Override Methods

        /// <summary>
        /// Gets the name of the element.
        /// </summary>
        /// <returns>The name of the element.</returns>
        protected override string GetElementName()
        {
            string alias = this.Alias;
            if (alias != null)
            {
                return alias;
            }

            return this.NamespaceType;
        }

        #endregion Protected Override Methods
    }
}
