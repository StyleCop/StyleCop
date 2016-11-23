// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConditionalExpression.cs" company="https://github.com/StyleCop">
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
//   An expression representing a conditional operation.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    /// <summary>
    /// An expression representing a conditional operation.
    /// </summary>
    /// <subcategory>expression</subcategory>
    public sealed class ConditionalExpression : Expression
    {
        #region Fields

        /// <summary>
        /// The condition being evaluated.
        /// </summary>
        private readonly Expression condition;

        /// <summary>
        /// The expression that is evaluated if the condition is false.
        /// </summary>
        private readonly Expression falseValue;

        /// <summary>
        /// The expression that is evaluated if the condition is true.
        /// </summary>
        private readonly Expression trueValue;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the ConditionalExpression class.
        /// </summary>
        /// <param name="tokens">
        /// The list of tokens that form the expression.
        /// </param>
        /// <param name="condition">
        /// The condition being evaluated.
        /// </param>
        /// <param name="trueValue">
        /// The expression that is evaluated if the condition is true.
        /// </param>
        /// <param name="falseValue">
        /// The expression that is evaluated if the condition is false.
        /// </param>
        internal ConditionalExpression(CsTokenList tokens, Expression condition, Expression trueValue, Expression falseValue)
            : base(ExpressionType.Conditional, tokens)
        {
            Param.AssertNotNull(tokens, "tokens");
            Param.AssertNotNull(condition, "condition");
            Param.AssertNotNull(trueValue, "trueValue");
            Param.AssertNotNull(falseValue, "falseValue");

            this.condition = condition;
            this.trueValue = trueValue;
            this.falseValue = falseValue;

            this.AddExpression(condition);
            this.AddExpression(trueValue);
            this.AddExpression(falseValue);
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the condition that is being evaluated.
        /// </summary>
        public Expression Condition
        {
            get
            {
                return this.condition;
            }
        }

        /// <summary>
        /// Gets the expression that is evaluated if the condition is false.
        /// </summary>
        public Expression FalseExpression
        {
            get
            {
                return this.falseValue;
            }
        }

        /// <summary>
        /// Gets the expression that is evaluated if the condition is true.
        /// </summary>
        public Expression TrueExpression
        {
            get
            {
                return this.trueValue;
            }
        }

        #endregion
    }
}