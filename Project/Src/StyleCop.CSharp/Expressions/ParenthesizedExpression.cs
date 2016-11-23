// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParenthesizedExpression.cs" company="https://github.com/StyleCop">
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
//   An expression wrapped within parenthesis.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    /// <summary>
    /// An expression wrapped within parenthesis.
    /// </summary>
    /// <subcategory>expression</subcategory>
    public sealed class ParenthesizedExpression : Expression
    {
        #region Fields

        /// <summary>
        /// The expression within the parenthesis.
        /// </summary>
        private readonly Expression innerExpression;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the ParenthesizedExpression class.
        /// </summary>
        /// <param name="tokens">
        /// The list of tokens that form the expression.
        /// </param>
        /// <param name="innerExpression">
        /// The expression within the parenthesis.
        /// </param>
        internal ParenthesizedExpression(CsTokenList tokens, Expression innerExpression)
            : base(ExpressionType.Parenthesized, tokens)
        {
            Param.AssertNotNull(tokens, "tokens");
            Param.AssertNotNull(innerExpression, "innerExpression");

            this.innerExpression = innerExpression;
            this.AddExpression(innerExpression);
        }

        #endregion

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

        #endregion
    }
}