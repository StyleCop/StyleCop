//-----------------------------------------------------------------------
// <copyright file="AttributeExpression.cs" company="Microsoft">
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

    /// <summary>
    /// An expression representing an element or assembly attribute.
    /// </summary>
    /// <subcategory>expression</subcategory>
    public sealed class AttributeExpression : Expression
    {
        #region Private Fields

        /// <summary>
        /// The attribute target, if any.
        /// </summary>
        private LiteralExpression target;

        /// <summary>
        /// The attribute initialization call.
        /// </summary>
        private Expression initialization; 

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the AttributeExpression class.
        /// </summary>
        /// <param name="tokens">The list of tokens that form the expression.</param>
        /// <param name="target">The attribute target, if any.</param>
        /// <param name="initialization">The attribute initialization call.</param>
        internal AttributeExpression(CsTokenList tokens, LiteralExpression target, Expression initialization)
            : base(ExpressionType.Attribute, tokens)
        {
            Param.AssertNotNull(tokens, "tokens");
            Param.Ignore(target);
            Param.AssertNotNull(initialization, "initialization");

            // Add the target expression.
            this.target = target;
            if (target != null)
            {
                this.AddExpression(target);
            }

            // Add the initialization expression.
            this.initialization = initialization;
            this.AddExpression(initialization);
        }

        #endregion Internal Constructors

        #region Public Properties

        /// <summary>
        /// Gets the attribute target.
        /// </summary>
        public LiteralExpression Target
        {
            get
            {
                return this.target;
            }
        }

        /// <summary>
        /// Gets the attribute initialization call expression.
        /// </summary>
        public Expression Initialization
        {
            get
            {
                return this.initialization;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this is an assembly attribute.
        /// </summary>
        public bool IsAssemblyAttribute
        {
            get
            {
                bool assembly = false;
                foreach (CsToken token in this.Tokens)
                {
                    if (!assembly)
                    {
                        if (token.Text == "assembly")
                        {
                            assembly = true;
                        }
                    }
                    else if (token.CsTokenType != CsTokenType.WhiteSpace &&
                        token.CsTokenType != CsTokenType.EndOfLine &&
                        token.CsTokenType != CsTokenType.SingleLineComment &&
                        token.CsTokenType != CsTokenType.MultiLineComment &&
                        token.CsTokenType != CsTokenType.PreprocessorDirective)
                    {
                        if (token.Text == ":")
                        {
                            return true;
                        }
                    }
                }

                return false;
            }
        }

        #endregion Public Properties
    }
}
