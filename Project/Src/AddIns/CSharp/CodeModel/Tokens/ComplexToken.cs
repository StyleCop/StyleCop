//-----------------------------------------------------------------------
// <copyright file="ComplexToken.cs" company="Microsoft">
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
namespace Microsoft.StyleCop.CSharp.CodeModel
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// A token which contains sub-tokens.
    /// </summary>
    /// <subcategory>token</subcategory>
    public abstract class ComplexToken : Token
    {
        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the ComplexToken class.
        /// </summary>
        /// <param name="proxy">Proxy object for the statement.</param>
        /// <param name="tokenType">The type of the token.</param>
        internal ComplexToken(CodeUnitProxy proxy, TokenType tokenType)
            : base(proxy, tokenType)
        {
            Param.AssertNotNull(proxy, "proxy");
            Param.Ignore(tokenType);

            this.IsComplexToken = true;
        }

        #endregion Internal Constructors

        #region Protected Override Methods

        /// <summary>
        /// Creates a text string based on the child tokens in the token.
        /// </summary>
        protected override void CreateTextString()
        {
            var text = new StringBuilder();

            for (LexicalElement lex = this.FindFirstDescendent<LexicalElement>(); lex != null; lex = lex.FindNextDescendentOf<LexicalElement>(this))
            {
                text.Append(lex.Text);
            }

            this.Text = text.ToString();
        }

        #endregion Protected Override Methods
    }
}
