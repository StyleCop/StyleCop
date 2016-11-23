// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QueryClauseWithExpression.cs" company="https://github.com/StyleCop">
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
//   A base class for a query clause which contains an embedded expression.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    /// <summary>
    /// A base class for a query clause which contains an embedded expression.
    /// </summary>
    public abstract class QueryClauseWithExpression : QueryClause
    {
        #region Fields

        /// <summary>
        /// The range expression.
        /// </summary>
        private readonly Expression expression;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the QueryClauseWithExpression class.
        /// </summary>
        /// <param name="type">
        /// The type of the query clause.
        /// </param>
        /// <param name="tokens">
        /// The list of tokens that form the clause.
        /// </param>
        /// <param name="expression">
        /// The range expression.
        /// </param>
        internal QueryClauseWithExpression(QueryClauseType type, CsTokenList tokens, Expression expression)
            : base(type, tokens)
        {
            Param.Ignore(type);
            Param.AssertNotNull(tokens, "tokens");
            Param.AssertNotNull(expression, "expression");

            this.expression = expression;

            this.AddExpression(expression);
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the range expression.
        /// </summary>
        public Expression Expression
        {
            get
            {
                return this.expression;
            }
        }

        #endregion
    }
}