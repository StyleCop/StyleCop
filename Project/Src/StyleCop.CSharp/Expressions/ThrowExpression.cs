// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ThrowExpression.cs" company="https://github.com/StyleCop">
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
//   An expression representing throwing a exception.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    /// <summary>
    /// An expression that represents throwing an exception.
    /// </summary>
    public sealed class ThrowExpression : Expression
    {
        #region Fields

        /// <summary>
        /// The expression that represents the exception part of the throw expression.
        /// </summary>
        private readonly Expression exceptionExpression;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the ThrowExpression class.
        /// </summary>
        /// <param name="tokens">
        /// The list of tokens that form the expression.
        /// </param>
        /// <param name="exceptionExpression">
        /// An expression that represents the exception part of the throw expression.
        /// </param>
        internal ThrowExpression(CsTokenList tokens, Expression exceptionExpression)
            : base(ExpressionType.Throw, tokens)
        {
            Param.AssertNotNull(tokens, nameof(tokens));
            Param.AssertNotNull(exceptionExpression, nameof(exceptionExpression));

            this.exceptionExpression = exceptionExpression;
            this.AddExpression(exceptionExpression);
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the expression that represents the exception part of the throw expression.
        /// </summary>
        public Expression ExceptionExpression => this.exceptionExpression;

        #endregion
    }
}
