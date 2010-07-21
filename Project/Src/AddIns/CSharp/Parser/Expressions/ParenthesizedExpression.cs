//-----------------------------------------------------------------------
// <copyright file="ParenthesizedExpression.cs" company="Microsoft">
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
    /// An expression wrapped within parenthesis.
    /// </summary>
    /// <subcategory>expression</subcategory>
    public sealed class ParenthesizedExpression : Expression
    {
        #region Private Fields

        /// <summary>
        /// The expression within the parenthesis.
        /// </summary>
        private Expression innerExpression;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the ParenthesizedExpression class.
        /// </summary>
        /// <param name="proxy">Proxy object for the expression.</param>
        /// <param name="innerExpression">The expression within the parenthesis.</param>
        internal ParenthesizedExpression(CodeUnitProxy proxy, Expression innerExpression)
            : base(proxy, ExpressionType.Parenthesized)
        {
            Param.AssertNotNull(proxy, "proxy");
            Param.AssertNotNull(innerExpression, "innerExpression");

            this.innerExpression = innerExpression;
        }

        #endregion Internal Constructors

        #region Public Properties

        /// <summary>
        /// Gets the expression within the parenthesis.
        /// </summary>
        public Expression InnerExpression
        {
            get
            {
                return this.innerExpression;
            }
        }

        #endregion Public Properties
    }
}
