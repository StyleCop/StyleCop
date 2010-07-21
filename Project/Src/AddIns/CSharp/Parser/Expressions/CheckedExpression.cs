//-----------------------------------------------------------------------
// <copyright file="CheckedExpression.cs" company="Microsoft">
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
    /// An expression representing a checked operation.
    /// </summary>
    /// <subcategory>expression</subcategory>
    public sealed class CheckedExpression : Expression
    {
        #region Private Fields

        /// <summary>
        /// The expression wrapped within the checked expression.
        /// </summary>
        private Expression internalExpression;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the CheckedExpression class.
        /// </summary>
        /// <param name="tokens">The list of tokens that form the expression.</param>
        /// <param name="internalExpression">The expression wrapped within the checked expression.</param>
        internal CheckedExpression(CsTokenList tokens, Expression internalExpression)
            : base(ExpressionType.Checked, tokens)
        {
            Param.AssertNotNull(tokens, "tokens");
            Param.AssertNotNull(internalExpression, "internalExpression");

            this.internalExpression = internalExpression;
            this.AddExpression(internalExpression);
        }

        #endregion Internal Constructors

        #region Public Properties

        /// <summary>
        /// Gets the expression wrapped within this checked expression.
        /// </summary>
        public Expression InternalExpression
        {
            get
            {
                return this.internalExpression;
            }
        }

        #endregion Public Properties
    }
}
