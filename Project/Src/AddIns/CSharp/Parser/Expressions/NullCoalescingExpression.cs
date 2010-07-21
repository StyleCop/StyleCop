//-----------------------------------------------------------------------
// <copyright file="NullCoalescingExpression.cs" company="Microsoft">
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
    /// An expression representing a null coalescing operation.
    /// </summary>
    /// <subcategory>expression</subcategory>
    public sealed class NullCoalescingExpression : Expression
    {
        #region Private Fields

        /// <summary>
        /// The left hand side of the expression.
        /// </summary>
        private Expression leftHandSide;

        /// <summary>
        /// The right hand side of the expression.
        /// </summary>
        private Expression rightHandSide;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the NullCoalescingExpression class.
        /// </summary>
        /// <param name="proxy">Proxy object for the expression.</param>
        /// <param name="leftHandSide">The left hand side of the expression.</param>
        /// <param name="rightHandSide">The right hand side of the expression.</param>
        internal NullCoalescingExpression(CodeUnitProxy proxy, Expression leftHandSide, Expression rightHandSide)
            : base(proxy, ExpressionType.NullCoalescing)
        {
            Param.AssertNotNull(proxy, "proxy");
            Param.AssertNotNull(leftHandSide, "leftHandSide");
            Param.AssertNotNull(rightHandSide, "rightHandSide");

            this.leftHandSide = leftHandSide;
            this.rightHandSide = rightHandSide;
        }

        #endregion Internal Constructors

        #region Public Properties

        /// <summary>
        /// Gets the left hand side of the expression.
        /// </summary>
        public Expression LeftHandSide
        {
            get
            {
                return this.leftHandSide;
            }
        }

        /// <summary>
        /// Gets the right hand side of the expression.
        /// </summary>
        public Expression RightHandSide
        {
            get
            {
                return this.rightHandSide;
            }
        }

        #endregion Public Properties
    }
}
