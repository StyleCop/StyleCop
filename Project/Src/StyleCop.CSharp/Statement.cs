// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Statement.cs" company="https://github.com/StyleCop">
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
//   A single statement within a code file or element.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// A single statement within a code file or element.
    /// </summary>
    /// <subcategory>statement</subcategory>
    public abstract class Statement : CodeUnit
    {
        #region Static Fields

        /// <summary>
        /// An empty array of statements.
        /// </summary>
        private static readonly Statement[] EmptyStatementArray = new Statement[0];

        #endregion

        #region Fields

        /// <summary>
        /// The type of the statement.
        /// </summary>
        private readonly StatementType type;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the Statement class.
        /// </summary>
        /// <param name="type">
        /// The type of the statement.
        /// </param>
        internal Statement(StatementType type)
            : base(CodePartType.Statement)
        {
            Param.Ignore(type);

            this.type = type;
        }

        /// <summary>
        /// Initializes a new instance of the Statement class.
        /// </summary>
        /// <param name="type">
        /// The type of the statement.
        /// </param>
        /// <param name="tokens">
        /// The list of tokens that form the statement.
        /// </param>
        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors", 
            Justification = "The tokens property is virtual but it this is safe as statements are sealed.")]
        internal Statement(StatementType type, CsTokenList tokens)
            : base(CodePartType.Statement, tokens)
        {
            Param.Ignore(type);
            Param.AssertNotNull(tokens, "tokens");

            this.type = type;

            this.Tokens = tokens;
            this.Tokens.Trim();

            Debug.Assert(this.Tokens.First != null, "The tokens list should not be empty");
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the collection of statements which are attached to
        /// the end of this statement.
        /// </summary>
        /// <remarks>Examples of attached statements are the else-statements
        /// attached to an if-statement, or the catch statements attached to a try-statement.</remarks>
        public virtual IEnumerable<Statement> AttachedStatements
        {
            get
            {
                return EmptyStatementArray;
            }
        }

        /// <summary>
        /// Gets the type of the statement.
        /// </summary>
        public StatementType StatementType
        {
            get
            {
                return this.type;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Walks through the code units in the statement.
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
        public void WalkStatement<T>(
            CodeWalkerStatementVisitor<T> statementCallback, 
            CodeWalkerExpressionVisitor<T> expressionCallback, 
            CodeWalkerQueryClauseVisitor<T> queryClauseCallback, 
            T context)
        {
            Param.Ignore(statementCallback, expressionCallback, queryClauseCallback, context);
            CodeWalker<T>.Start(this, statementCallback, expressionCallback, queryClauseCallback, context);
        }

        /// <summary>
        /// Walks through the code units in the statement.
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
        public void WalkStatement<T>(CodeWalkerStatementVisitor<T> statementCallback, CodeWalkerExpressionVisitor<T> expressionCallback, T context)
        {
            Param.Ignore(statementCallback, expressionCallback, context);
            this.WalkStatement(statementCallback, expressionCallback, null, context);
        }

        /// <summary>
        /// Walks through the code units in the statement.
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
        public void WalkStatement<T>(CodeWalkerStatementVisitor<T> statementCallback, T context)
        {
            Param.Ignore(statementCallback, context);
            this.WalkStatement(statementCallback, null, null, context);
        }

        /// <summary>
        /// Walks through the code units in the statement.
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
        public void WalkStatement(
            CodeWalkerStatementVisitor<object> statementCallback, 
            CodeWalkerExpressionVisitor<object> expressionCallback, 
            CodeWalkerQueryClauseVisitor<object> queryClauseCallback)
        {
            Param.Ignore(statementCallback, expressionCallback, queryClauseCallback);
            CodeWalker<object>.Start(this, statementCallback, expressionCallback, queryClauseCallback, null);
        }

        /// <summary>
        /// Walks through the code units in the statement.
        /// </summary>
        /// <param name="statementCallback">
        /// Callback executed when a statement is visited.
        /// </param>
        /// <param name="expressionCallback">
        /// Callback executed when an expression is visited.
        /// </param>
        public void WalkStatement(CodeWalkerStatementVisitor<object> statementCallback, CodeWalkerExpressionVisitor<object> expressionCallback)
        {
            Param.Ignore(statementCallback, expressionCallback);
            this.WalkStatement(statementCallback, expressionCallback, null, null);
        }

        /// <summary>
        /// Walks through the code units in the statement.
        /// </summary>
        /// <param name="statementCallback">
        /// Callback executed when a statement is visited.
        /// </param>
        public void WalkStatement(CodeWalkerStatementVisitor<object> statementCallback)
        {
            Param.Ignore(statementCallback);
            this.WalkStatement(statementCallback, null, null, null);
        }

        #endregion
    }
}