// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QueryClause.cs" company="https://github.com/StyleCop">
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
//   The base class for all query clauses.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    /// <summary>
    /// The base class for all query clauses.
    /// </summary>
    public abstract class QueryClause : CodeUnit
    {
        #region Fields

        /// <summary>
        /// The type of the query clause.
        /// </summary>
        private readonly QueryClauseType type;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the QueryClause class.
        /// </summary>
        /// <param name="type">
        /// The type of the clause.
        /// </param>
        /// <param name="tokens">
        /// The list of tokens that form the clause.
        /// </param>
        internal QueryClause(QueryClauseType type, CsTokenList tokens)
            : base(CodePartType.QueryClause, tokens)
        {
            Param.Ignore(type);
            Param.AssertNotNull(tokens, "tokens");

            this.type = type;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the query clause that contains this clause, if there is one.
        /// </summary>
        public QueryClause ParentQueryClause
        {
            get
            {
                return this.Parent as QueryClause;
            }
        }

        /// <summary>
        /// Gets the type of the query clause.
        /// </summary>
        public QueryClauseType QueryClauseType
        {
            get
            {
                return this.type;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Walks through the code units in the query clause.
        /// </summary>
        /// <param name="statementCallback">
        /// Callback executed when a statement is visited.
        /// </param>
        /// <param name="expressionCallback">
        /// Callback executed when an expression is visited.
        /// </param>
        /// <param name="queryClauseCallback">
        /// Callback executed when a query clause is visited.
        /// </param>
        /// <param name="context">
        /// The optional visitor context data.
        /// </param>
        /// <typeparam name="T">
        /// The type of the context item.
        /// </typeparam>
        public void WalkQueryClause<T>(
            CodeWalkerStatementVisitor<T> statementCallback, 
            CodeWalkerExpressionVisitor<T> expressionCallback, 
            CodeWalkerQueryClauseVisitor<T> queryClauseCallback, 
            T context)
        {
            Param.Ignore(statementCallback, expressionCallback, queryClauseCallback, context);
            CodeWalker<T>.Start(this, statementCallback, expressionCallback, queryClauseCallback, context);
        }

        /// <summary>
        /// Walks through the code units in the query clause.
        /// </summary>
        /// <param name="statementCallback">
        /// Callback executed when a statement is visited.
        /// </param>
        /// <param name="expressionCallback">
        /// Callback executed when an expression is visited.
        /// </param>
        /// <param name="context">
        /// The optional visitor context data.
        /// </param>
        /// <typeparam name="T">
        /// The type of the context item.
        /// </typeparam>
        public void WalkQueryClause<T>(CodeWalkerStatementVisitor<T> statementCallback, CodeWalkerExpressionVisitor<T> expressionCallback, T context)
        {
            Param.Ignore(statementCallback, expressionCallback, context);
            this.WalkQueryClause(statementCallback, expressionCallback, null, context);
        }

        /// <summary>
        /// Walks through the code units in the query clause.
        /// </summary>
        /// <param name="statementCallback">
        /// Callback executed when a statement is visited.
        /// </param>
        /// <param name="context">
        /// The optional visitor context data.
        /// </param>
        /// <typeparam name="T">
        /// The type of the context item.
        /// </typeparam>
        public void WalkQueryClause<T>(CodeWalkerStatementVisitor<T> statementCallback, T context)
        {
            Param.Ignore(statementCallback, context);
            this.WalkQueryClause(statementCallback, null, null, context);
        }

        /// <summary>
        /// Walks through the code units in the query clause.
        /// </summary>
        /// <param name="statementCallback">
        /// Callback executed when a statement is visited.
        /// </param>
        /// <param name="expressionCallback">
        /// Callback executed when an expression is visited.
        /// </param>
        /// <param name="queryClauseCallback">
        /// Callback executed when a query clause is visited.
        /// </param>
        public void WalkQueryClause(
            CodeWalkerStatementVisitor<object> statementCallback, 
            CodeWalkerExpressionVisitor<object> expressionCallback, 
            CodeWalkerQueryClauseVisitor<object> queryClauseCallback)
        {
            Param.Ignore(statementCallback, expressionCallback, queryClauseCallback);
            CodeWalker<object>.Start(this, statementCallback, expressionCallback, queryClauseCallback, null);
        }

        /// <summary>
        /// Walks through the code units in the query clause.
        /// </summary>
        /// <param name="statementCallback">
        /// Callback executed when a statement is visited.
        /// </param>
        /// <param name="expressionCallback">
        /// Callback executed when an expression is visited.
        /// </param>
        public void WalkQueryClause(CodeWalkerStatementVisitor<object> statementCallback, CodeWalkerExpressionVisitor<object> expressionCallback)
        {
            Param.Ignore(statementCallback, expressionCallback);
            this.WalkQueryClause(statementCallback, expressionCallback, null, null);
        }

        /// <summary>
        /// Walks through the code units in the query clause.
        /// </summary>
        /// <param name="statementCallback">
        /// Callback executed when a statement is visited.
        /// </param>
        public void WalkQueryClause(CodeWalkerStatementVisitor<object> statementCallback)
        {
            Param.Ignore(statementCallback);
            this.WalkQueryClause(statementCallback, null, null, null);
        }

        #endregion
    }
}