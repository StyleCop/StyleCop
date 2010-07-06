//-----------------------------------------------------------------------
// <copyright file="LiteralExpression.cs" company="Microsoft">
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
namespace Microsoft.StyleCop.CSharp_old
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
        /// The literal token node.
        /// </summary>
        private Node<CsToken> tokenNode;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the LiteralExpression class.
        /// </summary>
        /// <param name="tokens">The list of tokens that form the expression.</param>
        /// <param name="tokenNode">The literal token node.</param>
        internal LiteralExpression(CsTokenList tokens, Node<CsToken> tokenNode)
            : base(ExpressionType.Literal, tokens)
        {
            Param.AssertNotNull(tokens, "tokens");
            Param.AssertNotNull(tokenNode, "token");

            this.tokenNode = tokenNode;
        }

        /// <summary>
        /// Initializes a new instance of the LiteralExpression class.
        /// </summary>
        /// <param name="masterList">The master token list for the document containing the expression.</param>
        /// <param name="tokenNode">The literal token represented by the expression.</param>
        internal LiteralExpression(MasterList<CsToken> masterList, Node<CsToken> tokenNode)
            : this(new CsTokenList(masterList, tokenNode, tokenNode), tokenNode)
        {
            Param.AssertNotNull(masterList, "masterList");
            Param.AssertNotNull(tokenNode, "tokenNode");
        }

        #endregion Internal Constructors

        #region Public Properties

        /// <summary>
        /// Gets the literal token.
        /// </summary>
        public CsToken Token
        {
            get
            {
                return this.tokenNode.Value;
            }
        }

        /// <summary>
        /// Gets the literal token node.
        /// </summary>
        public Node<CsToken> TokenNode
        {
            get
            {
                return this.tokenNode;
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
            return this.tokenNode.Value.Text;
        }

        #endregion Public Override Methods
    }
}
