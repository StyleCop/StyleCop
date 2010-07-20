//-----------------------------------------------------------------------
// <copyright file="LiteralExpression.cs" company="Microsoft">
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
    /// An expression representing a literal.
    /// </summary>
    /// <subcategory>expression</subcategory>
    public sealed class LiteralExpression : Expression
    {
        #region Private Fields

        /// <summary>
        /// The literal token.
        /// </summary>
        private CodeUnitProperty<Token> token;

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

            this.token.Value = token;
        }

        #endregion Internal Constructors

        #region Public Properties

        /// <summary>
        /// Gets the literal token.
        /// </summary>
        public Token Token
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.token.Initialized)
                {
                    this.token.Value = this.FindFirstChild<Token>();
                    if (this.token.Value == null)
                    {
                        throw new SyntaxException(this.Document, this.LineNumber);
                    }
                }

                return this.token.Value;
            }
        }

        /// <summary>
        /// Gets the text of the expression.
        /// </summary>
        public string Text
        {
            get
            {
                Token token = this.Token;
                return token == null ? string.Empty : token.Text;
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

        #region Protected Override Methods

        /// <summary>
        /// Resets the contents of the class.
        /// </summary>
        protected override void Reset()
        {
            base.Reset();

            this.token.Reset();
        }

        #endregion Protected Override Methods
    }
}
