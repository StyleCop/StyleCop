// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QueryJoinClause.cs" company="https://github.com/StyleCop">
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
//   Describes a join clause in a query expression.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    /// <summary>
    /// Describes a join clause in a query expression.
    /// </summary>
    public sealed class QueryJoinClause : QueryClause
    {
        #region Fields

        /// <summary>
        /// The expression after the 'equals' keyword.
        /// </summary>
        private readonly Expression equalsKeyExpression;

        /// <summary>
        /// The expression after the 'in' keyword.
        /// </summary>
        private readonly Expression inExpression;

        /// <summary>
        /// The optional variable that the result is placed into.
        /// </summary>
        private readonly Variable intoVariable;

        /// <summary>
        /// The expression after the 'on' keyword.
        /// </summary>
        private readonly Expression onKeyExpression;

        /// <summary>
        /// The variable that ranges over the values in the query result.
        /// </summary>
        private readonly Variable rangeVariable;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the QueryJoinClause class.
        /// </summary>
        /// <param name="tokens">
        /// The list of tokens that form the clause.
        /// </param>
        /// <param name="rangeVariable">
        /// The variable that ranges over the values in the query result.
        /// </param>
        /// <param name="inExpression">
        /// The expression after the 'in' keyword.
        /// </param>
        /// <param name="onKeyExpression">
        /// The expression after the 'on' keyword.
        /// </param>
        /// <param name="equalsKeyExpression">
        /// The expression after the 'equals' keyword.
        /// </param>
        /// <param name="intoVariable">
        /// The optional variable that the result is placed into.
        /// </param>
        internal QueryJoinClause(
            CsTokenList tokens, Variable rangeVariable, Expression inExpression, Expression onKeyExpression, Expression equalsKeyExpression, Variable intoVariable)
            : base(QueryClauseType.Join, tokens)
        {
            Param.AssertNotNull(tokens, "tokens");
            Param.AssertNotNull(rangeVariable, "rangeVariable");
            Param.AssertNotNull(inExpression, "inExpression");
            Param.AssertNotNull(onKeyExpression, "onKeyExpression");
            Param.AssertNotNull(equalsKeyExpression, "equalsKeyExpression");
            Param.Ignore(intoVariable);

            this.rangeVariable = rangeVariable;
            this.inExpression = inExpression;
            this.onKeyExpression = onKeyExpression;
            this.equalsKeyExpression = equalsKeyExpression;
            this.intoVariable = intoVariable;

            this.AddExpression(this.inExpression);
            this.AddExpression(this.onKeyExpression);
            this.AddExpression(this.equalsKeyExpression);
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the expression after the 'equals' keyword.
        /// </summary>
        public Expression EqualsKeyExpression
        {
            get
            {
                return this.equalsKeyExpression;
            }
        }

        /// <summary>
        /// Gets the expression after the 'in' keyword.
        /// </summary>
        public Expression InExpression
        {
            get
            {
                return this.inExpression;
            }
        }

        /// <summary>
        /// Gets the optional variable that the result is placed into.
        /// </summary>
        public Variable IntoVariable
        {
            get
            {
                return this.intoVariable;
            }
        }

        /// <summary>
        /// Gets the expression after the 'on' keyword.
        /// </summary>
        public Expression OnKeyExpression
        {
            get
            {
                return this.onKeyExpression;
            }
        }

        /// <summary>
        /// Gets the variable that ranges over the values in the query result.
        /// </summary>
        public Variable RangeVariable
        {
            get
            {
                return this.rangeVariable;
            }
        }

        #endregion
    }
}