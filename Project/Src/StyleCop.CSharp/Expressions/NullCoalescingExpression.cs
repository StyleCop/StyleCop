// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NullCoalescingExpression.cs" company="https://github.com/StyleCop">
//   MS-PL
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
// <summary>
//   An expression representing a null coalescing operation.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    /// <summary>
    /// An expression representing a null coalescing operation.
    /// </summary>
    /// <subcategory>expression</subcategory>
    public sealed class NullCoalescingExpression : Expression
    {
        #region Fields

        /// <summary>
        /// The left hand side of the expression.
        /// </summary>
        private readonly Expression leftHandSide;

        /// <summary>
        /// The right hand side of the expression.
        /// </summary>
        private readonly Expression rightHandSide;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the NullCoalescingExpression class.
        /// </summary>
        /// <param name="tokens">
        /// The list of tokens that form the expression.
        /// </param>
        /// <param name="leftHandSide">
        /// The left hand side of the expression.
        /// </param>
        /// <param name="rightHandSide">
        /// The right hand side of the expression.
        /// </param>
        internal NullCoalescingExpression(CsTokenList tokens, Expression leftHandSide, Expression rightHandSide)
            : base(ExpressionType.NullCoalescing, tokens)
        {
            Param.AssertNotNull(tokens, "tokens");
            Param.AssertNotNull(leftHandSide, "leftHandSide");
            Param.AssertNotNull(rightHandSide, "rightHandSide");

            this.leftHandSide = leftHandSide;
            this.rightHandSide = rightHandSide;

            this.AddExpression(leftHandSide);
            this.AddExpression(rightHandSide);
        }

        #endregion

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

        #endregion
    }
}