//-----------------------------------------------------------------------
// <copyright file="LiteralExpression.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
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
    /// An expression representing a literal.
    /// </summary>
    /// <subcategory>expression</subcategory>
    public sealed class LiteralExpression : Expression
    {
        #region Private Fields

        /// <summary>
        /// The literal token.
        /// </summary>
        private Token token;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the LiteralExpression class.
        /// </summary>
        /// <param name="proxy">Proxy object for the expression.</param>
        /// <param name="token">The literal token.</param>
        internal LiteralExpression(CodeUnitProxy proxy, Token token)
            : base(proxy, ExpressionType.Literal)
        {
            Param.AssertNotNull(proxy, "proxy");
            Param.AssertNotNull(token, "token");

            this.token = token;
        }

        /////// <summary>
        /////// Initializes a new instance of the LiteralExpression class.
        /////// </summary>
        /////// <param name="masterList">The master token list for the document containing the expression.</param>
        /////// <param name="tokenNode">The literal token represented by the expression.</param>
        ////internal LiteralExpression(MasterList<Token> masterList, Node<Token> tokenNode)
        ////    : this(new TokenList(masterList, tokenNode, tokenNode), tokenNode)
        ////{
        ////    Param.AssertNotNull(masterList, "masterList");
        ////    Param.AssertNotNull(tokenNode, "tokenNode");
        ////}

        #endregion Internal Constructors

        #region Public Properties

        /// <summary>
        /// Gets the literal token.
        /// </summary>
        public Token Token
        {
            get
            {
                return this.token;
            }
        }

        /// <summary>
        /// Gets the text of the expression.
        /// </summary>
        public string Text
        {
            get
            {
                return this.token == null ? string.Empty : this.token.Text;
            }
        }

        #endregion Public Properties

        #region Public Override Methods

        /// <summary>
        /// Gets the contents of the expression as a string.
        /// </summary>
        /// <returns>Returns the string.</returns>
        public override string ToString()
        {
            return this.Text;
        }

        #endregion Public Override Methods
    }
}
