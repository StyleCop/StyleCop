// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RefExpression.cs" company="https://github.com/StyleCop">
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
//   An expression that represents a reference to the evaluated value.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    /// <summary>
    /// An expression that represents a reference to the evaluated value.
    /// </summary>
    public sealed class RefExpression : Expression
    {
        #region Fields

        /// <summary>
        /// The underlying value expression.
        /// </summary>
        private readonly Expression value;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the RefExpression class.
        /// </summary>
        /// <param name="tokens">
        /// The list of tokens that form the expression.
        /// </param>
        /// <param name="value">
        /// The underlying value expression.
        /// </param>
        internal RefExpression(CsTokenList tokens, Expression value)
            : base(ExpressionType.Ref, tokens)
        {
            Param.AssertNotNull(tokens, nameof(tokens));
            Param.AssertNotNull(value, nameof(value));

            this.value = value;
            this.AddExpression(value);
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the underlying value expression.
        /// </summary>
        public Expression Value => this.value;

        #endregion
    }
}
