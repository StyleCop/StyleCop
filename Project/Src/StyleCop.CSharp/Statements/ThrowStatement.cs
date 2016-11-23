// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ThrowStatement.cs" company="https://github.com/StyleCop">
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
//   A throw-statement.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    /// <summary>
    /// A throw-statement.
    /// </summary>
    /// <subcategory>statement</subcategory>
    public sealed class ThrowStatement : Statement
    {
        #region Fields

        /// <summary>
        /// The expression being thrown, if any.
        /// </summary>
        private readonly Expression thrownExpression;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the ThrowStatement class.
        /// </summary>
        /// <param name="tokens">
        /// The list of tokens that form the statement.
        /// </param>
        /// <param name="thrownExpression">
        /// The expression being thrown, if any.
        /// </param>
        internal ThrowStatement(CsTokenList tokens, Expression thrownExpression)
            : base(StatementType.Throw, tokens)
        {
            Param.AssertNotNull(tokens, "tokens");
            Param.Ignore(thrownExpression);

            this.thrownExpression = thrownExpression;

            if (thrownExpression != null)
            {
                this.AddExpression(thrownExpression);
            }
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the expression being thrown, if any.
        /// </summary>
        public Expression ThrownExpression
        {
            get
            {
                return this.thrownExpression;
            }
        }

        #endregion
    }
}