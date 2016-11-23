// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AwaitStatement.cs" company="https://github.com/StyleCop">
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
//   An await statement.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    /// <summary>
    /// An await statement.
    /// </summary>
    /// <subcategory>statement</subcategory>
    public sealed class AwaitStatement : Statement
    {
        #region Fields

        /// <summary>
        /// The await value expression.
        /// </summary>
        private readonly Expression awaitValue;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the AwaitStatement class.
        /// </summary>
        /// <param name="tokens">
        /// The list of tokens that form the statement.
        /// </param>
        /// <param name="awaitValue">
        /// The await value expression.
        /// </param>
        internal AwaitStatement(CsTokenList tokens, Expression awaitValue)
            : base(StatementType.Await, tokens)
        {
            Param.AssertNotNull(tokens, "tokens");
            Param.Ignore(awaitValue);

            this.awaitValue = awaitValue;

            if (awaitValue != null)
            {
                this.AddExpression(awaitValue);
            }
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the await value expression.
        /// </summary>
        public Expression AwaitValue
        {
            get
            {
                return this.awaitValue;
            }
        }

        #endregion
    }
}