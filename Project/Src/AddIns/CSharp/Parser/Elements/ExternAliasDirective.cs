//-----------------------------------------------------------------------
// <copyright file="ExternAliasDirective.cs" company="Microsoft">
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
    /// Describes the contents of an extern alias directive.
    /// </summary>
    /// <subcategory>element</subcategory>
    public sealed class ExternAliasDirective : Element
    {
        #region Private Fields

        /// <summary>
        /// The identifier name of the alias.
        /// </summary>
        private string identifier = string.Empty;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the ExternAliasDirective class.
        /// </summary>
        /// <param name="proxy">Proxy object for the extern alias.</param>
        /// <param name="name">The name of the extern alias.</param>
        internal ExternAliasDirective(CodeUnitProxy proxy, string name)
            : base(proxy,  ElementType.ExternAliasDirective, name, null, false)
        {
            Param.Ignore(proxy);
            Param.AssertValidString(name, "name");
        }

        #endregion Internal Constructors

        #region Public Properties

        /// <summary>
        /// Gets the identifier of the alias.
        /// </summary>
        public string Identifier
        {
            get
            {
                return this.identifier;
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

            // Find the 'alias' keyword.
            Token aliasToken = null;

            for (Token token = this.FindFirstChild<Token>(); token != null; token = token.FindNextSibling<Token>())
            {
                if (token.TokenType == TokenType.Alias)
                {
                    aliasToken = token;
                    break;
                }
            }

            // Make sure we found it.
            if (aliasToken != null && aliasToken != this.FindLastChild<Token>())
            {
                Token temp = aliasToken.FindNextSibling<Token>();
                if (temp != null)
                {
                    // This word is the identifier
                    this.identifier = CodeParser.TrimType(CodeParser.GetFullName(document, this, temp, out temp));
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
            // Get the alias keyword.
            Token aliasToken = this.FindFirstChild<AliasToken>();
            if (aliasToken != null)
            {
                // The next Token is the name.
                Token nameToken = aliasToken.FindNextSibling<Token>();
                if (nameToken != null)
                {
                    return nameToken.Text;
                }
            }

            throw new SyntaxException(this.Document, this.LineNumber);
        }

        #endregion Protected Override Methods
    }
}
