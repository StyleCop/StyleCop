// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CodeWalker{T}.cs" company="https://github.com/StyleCop">
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
//   Delegate for a callback executed when an element is visited.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Delegate for a callback executed when an element is visited.
    /// </summary>
    /// <param name="element">
    /// The element being visited.
    /// </param>
    /// <param name="parentElement">
    /// The parent element, if any.
    /// </param>
    /// <param name="context">
    /// The optional visitor context data.
    /// </param>
    /// <returns>
    /// Returns true to continue, or false to stop the walker.
    /// </returns>
    /// <typeparam name="T">
    /// The type of the visitor context data.
    /// </typeparam>
    public delegate bool CodeWalkerElementVisitor<T>(CsElement element, CsElement parentElement, T context);

    /// <summary>
    /// Delegate for a callback executed when a statement is visited.
    /// </summary>
    /// <param name="statement">
    /// The statement being visited.
    /// </param>
    /// <param name="parentExpression">
    /// The parent expression, if any.
    /// </param>
    /// <param name="parentStatement">
    /// The parent statement, if any.
    /// </param>
    /// <param name="parentElement">
    /// The parent element, if any.
    /// </param>
    /// <param name="context">
    /// The optional visitor context data.
    /// </param>
    /// <returns>
    /// Returns true to continue, or false to stop the walker.
    /// </returns>
    /// <typeparam name="T">
    /// The type of the visitor context data.
    /// </typeparam>
    public delegate bool CodeWalkerStatementVisitor<T>(Statement statement, Expression parentExpression, Statement parentStatement, CsElement parentElement, T context);

    /// <summary>
    /// Delegate for a callback executed when an expression is visited.
    /// </summary>
    /// <param name="expression">
    /// The expression being visited.
    /// </param>
    /// <param name="parentExpression">
    /// The parent expression, if any.
    /// </param>
    /// <param name="parentStatement">
    /// The parent statement, if any.
    /// </param>
    /// <param name="parentElement">
    /// The parent element, if any.
    /// </param>
    /// <param name="context">
    /// The optional visitor context data.
    /// </param>
    /// <returns>
    /// Returns true to continue, or false to stop the walker.
    /// </returns>
    /// <typeparam name="T">
    /// The type of the visitor context data.
    /// </typeparam>
    public delegate bool CodeWalkerExpressionVisitor<T>(Expression expression, Expression parentExpression, Statement parentStatement, CsElement parentElement, T context);

    /// <summary>
    /// Delegate for a callback executed when a query clause is visited.
    /// </summary>
    /// <param name="clause">
    /// The query clause being visited.
    /// </param>
    /// <param name="parentClause">
    /// The parent query clause, if any.
    /// </param>
    /// <param name="parentExpression">
    /// The parent expression, if any.
    /// </param>
    /// <param name="parentStatement">
    /// The parent statement, if any.
    /// </param>
    /// <param name="parentElement">
    /// The parent element, if any.
    /// </param>
    /// <param name="context">
    /// The optional visitor context data.
    /// </param>
    /// <returns>
    /// Returns true to continue, or false to stop the walker.
    /// </returns>
    /// <typeparam name="T">
    /// The type of the visitor context data.
    /// </typeparam>
    public delegate bool CodeWalkerQueryClauseVisitor<T>(
        QueryClause clause, QueryClause parentClause, Expression parentExpression, Statement parentStatement, CsElement parentElement, T context);

    /// <summary>
    /// Walks through the code object model.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the visitor context data.
    /// </typeparam>
    internal class CodeWalker<T>
    {
        #region Fields

        /// <summary>
        /// Callback executed when an element is visited.
        /// </summary>
        private readonly CodeWalkerElementVisitor<T> elementCallback;

        /// <summary>
        /// Callback executed when an expression is visited.
        /// </summary>
        private readonly CodeWalkerExpressionVisitor<T> expressionCallback;

        /// <summary>
        /// Callback executed when a query clause is visited.
        /// </summary>
        private readonly CodeWalkerQueryClauseVisitor<T> queryClauseCallback;

        /// <summary>
        /// Callback executed when a statement is visited.
        /// </summary>
        private readonly CodeWalkerStatementVisitor<T> statementCallback;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CodeWalker{T}"/> class. 
        /// Initializes a new instance of the CodeWalker class.
        /// </summary>
        /// <param name="document">
        /// The document to walk through.
        /// </param>
        /// <param name="elementCallback">
        /// Callback executed when an element is visited.
        /// </param>
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
        private CodeWalker(
            CsDocument document, 
            CodeWalkerElementVisitor<T> elementCallback, 
            CodeWalkerStatementVisitor<T> statementCallback, 
            CodeWalkerExpressionVisitor<T> expressionCallback, 
            CodeWalkerQueryClauseVisitor<T> queryClauseCallback, 
            T context)
        {
            Param.AssertNotNull(document, "document");
            Param.Ignore(elementCallback);
            Param.Ignore(statementCallback);
            Param.Ignore(expressionCallback);
            Param.Ignore(queryClauseCallback);
            Param.Ignore(context);

            this.elementCallback = elementCallback;
            this.statementCallback = statementCallback;
            this.expressionCallback = expressionCallback;
            this.queryClauseCallback = queryClauseCallback;

            this.WalkElement(document.RootElement, null, context);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CodeWalker{T}"/> class. 
        /// Initializes a new instance of the CodeWalker class.
        /// </summary>
        /// <param name="element">
        /// The element to walk through.
        /// </param>
        /// <param name="elementCallback">
        /// Callback executed when an element is visited.
        /// </param>
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
        private CodeWalker(
            CsElement element, 
            CodeWalkerElementVisitor<T> elementCallback, 
            CodeWalkerStatementVisitor<T> statementCallback, 
            CodeWalkerExpressionVisitor<T> expressionCallback, 
            CodeWalkerQueryClauseVisitor<T> queryClauseCallback, 
            T context)
        {
            Param.AssertNotNull(element, "element");
            Param.Ignore(elementCallback);
            Param.Ignore(statementCallback);
            Param.Ignore(expressionCallback);
            Param.Ignore(queryClauseCallback);
            Param.Ignore(context);

            this.elementCallback = elementCallback;
            this.statementCallback = statementCallback;
            this.expressionCallback = expressionCallback;
            this.queryClauseCallback = queryClauseCallback;

            this.WalkElement(element, element.FindParentElement(), context);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CodeWalker{T}"/> class. 
        /// Initializes a new instance of the CodeWalker class.
        /// </summary>
        /// <param name="statement">
        /// The statement to walk through.
        /// </param>
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
        private CodeWalker(
            Statement statement, 
            CodeWalkerStatementVisitor<T> statementCallback, 
            CodeWalkerExpressionVisitor<T> expressionCallback, 
            CodeWalkerQueryClauseVisitor<T> queryClauseCallback, 
            T context)
        {
            Param.AssertNotNull(statement, "statement");
            Param.Ignore(statementCallback);
            Param.Ignore(expressionCallback);
            Param.Ignore(queryClauseCallback);
            Param.Ignore(context);

            this.statementCallback = statementCallback;
            this.expressionCallback = expressionCallback;
            this.queryClauseCallback = queryClauseCallback;

            this.WalkStatement(statement, statement.FindParentExpression(), statement.FindParentStatement(), statement.FindParentElement(), context);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CodeWalker{T}"/> class. 
        /// Initializes a new instance of the CodeWalker class.
        /// </summary>
        /// <param name="expression">
        /// The expression to walk through.
        /// </param>
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
        private CodeWalker(
            Expression expression, 
            CodeWalkerStatementVisitor<T> statementCallback, 
            CodeWalkerExpressionVisitor<T> expressionCallback, 
            CodeWalkerQueryClauseVisitor<T> queryClauseCallback, 
            T context)
        {
            Param.AssertNotNull(expression, "expression");
            Param.Ignore(statementCallback);
            Param.Ignore(expressionCallback);
            Param.Ignore(queryClauseCallback);
            Param.Ignore(context);

            this.statementCallback = statementCallback;
            this.expressionCallback = expressionCallback;
            this.queryClauseCallback = queryClauseCallback;

            this.WalkExpression(expression, expression.FindParentExpression(), expression.FindParentStatement(), expression.FindParentElement(), context);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CodeWalker{T}"/> class. 
        /// Initializes a new instance of the CodeWalker class.
        /// </summary>
        /// <param name="queryClause">
        /// The query clause to walk through.
        /// </param>
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
        private CodeWalker(
            QueryClause queryClause, 
            CodeWalkerStatementVisitor<T> statementCallback, 
            CodeWalkerExpressionVisitor<T> expressionCallback, 
            CodeWalkerQueryClauseVisitor<T> queryClauseCallback, 
            T context)
        {
            Param.AssertNotNull(queryClause, "queryClause");
            Param.Ignore(statementCallback);
            Param.Ignore(expressionCallback);
            Param.Ignore(queryClauseCallback);
            Param.Ignore(context);

            this.statementCallback = statementCallback;
            this.expressionCallback = expressionCallback;
            this.queryClauseCallback = queryClauseCallback;

            this.WalkQueryClause(
                queryClause, 
                queryClause.ParentQueryClause, 
                queryClause.FindParentExpression(), 
                queryClause.FindParentStatement(), 
                queryClause.FindParentElement(), 
                context);
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Creates and starts a code walker.
        /// </summary>
        /// <param name="document">
        /// The document to walk through.
        /// </param>
        /// <param name="elementCallback">
        /// Callback executed when an element is visited.
        /// </param>
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
        [SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", 
            Justification = "The CodeWalker instance is create but not saved because the constructor walks through the elements.")]
        public static void Start(
            CsDocument document, 
            CodeWalkerElementVisitor<T> elementCallback, 
            CodeWalkerStatementVisitor<T> statementCallback, 
            CodeWalkerExpressionVisitor<T> expressionCallback, 
            CodeWalkerQueryClauseVisitor<T> queryClauseCallback, 
            T context)
        {
            Param.AssertNotNull(document, "document");
            Param.Ignore(elementCallback);
            Param.Ignore(statementCallback);
            Param.Ignore(expressionCallback);
            Param.Ignore(queryClauseCallback);
            Param.Ignore(context);

            new CodeWalker<T>(document, elementCallback, statementCallback, expressionCallback, queryClauseCallback, context);
        }

        /// <summary>
        /// Creates and starts a code walker.
        /// </summary>
        /// <param name="element">
        /// The element to walk through.
        /// </param>
        /// <param name="elementCallback">
        /// Callback executed when an element is visited.
        /// </param>
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
        [SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", 
            Justification = "The CodeWalker instance is create but not saved because the constructor walks through the elements.")]
        public static void Start(
            CsElement element, 
            CodeWalkerElementVisitor<T> elementCallback, 
            CodeWalkerStatementVisitor<T> statementCallback, 
            CodeWalkerExpressionVisitor<T> expressionCallback, 
            CodeWalkerQueryClauseVisitor<T> queryClauseCallback, 
            T context)
        {
            Param.AssertNotNull(element, "element");
            Param.Ignore(elementCallback);
            Param.Ignore(statementCallback);
            Param.Ignore(expressionCallback);
            Param.Ignore(queryClauseCallback);
            Param.Ignore(context);

            new CodeWalker<T>(element, elementCallback, statementCallback, expressionCallback, queryClauseCallback, context);
        }

        /// <summary>
        /// Creates and starts a code walker.
        /// </summary>
        /// <param name="statement">
        /// The statement to walk through.
        /// </param>
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
        [SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", 
            Justification = "The CodeWalker instance is create but not saved because the constructor walks through the elements.")]
        public static void Start(
            Statement statement, 
            CodeWalkerStatementVisitor<T> statementCallback, 
            CodeWalkerExpressionVisitor<T> expressionCallback, 
            CodeWalkerQueryClauseVisitor<T> queryClauseCallback, 
            T context)
        {
            Param.AssertNotNull(statement, "statement");
            Param.Ignore(statementCallback);
            Param.Ignore(expressionCallback);
            Param.Ignore(queryClauseCallback);
            Param.Ignore(context);

            new CodeWalker<T>(statement, statementCallback, expressionCallback, queryClauseCallback, context);
        }

        /// <summary>
        /// Creates and starts a code walker.
        /// </summary>
        /// <param name="expression">
        /// The expression to walk through.
        /// </param>
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
        [SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", 
            Justification = "The CodeWalker instance is create but not saved because the constructor walks through the elements.")]
        public static void Start(
            Expression expression, 
            CodeWalkerStatementVisitor<T> statementCallback, 
            CodeWalkerExpressionVisitor<T> expressionCallback, 
            CodeWalkerQueryClauseVisitor<T> queryClauseCallback, 
            T context)
        {
            Param.AssertNotNull(expression, "expression");
            Param.Ignore(statementCallback);
            Param.Ignore(expressionCallback);
            Param.Ignore(queryClauseCallback);
            Param.Ignore(context);

            new CodeWalker<T>(expression, statementCallback, expressionCallback, queryClauseCallback, context);
        }

        /// <summary>
        /// Creates and starts a code walker.
        /// </summary>
        /// <param name="queryClause">
        /// The query clause to walk through.
        /// </param>
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
        [SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", 
            Justification = "The CodeWalker instance is create but not saved because the constructor walks through the elements.")]
        public static void Start(
            QueryClause queryClause, 
            CodeWalkerStatementVisitor<T> statementCallback, 
            CodeWalkerExpressionVisitor<T> expressionCallback, 
            CodeWalkerQueryClauseVisitor<T> queryClauseCallback, 
            T context)
        {
            Param.AssertNotNull(queryClause, "queryClause");
            Param.Ignore(statementCallback);
            Param.Ignore(expressionCallback);
            Param.Ignore(queryClauseCallback);
            Param.Ignore(context);

            new CodeWalker<T>(queryClause, statementCallback, expressionCallback, queryClauseCallback, context);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Delegate for a callback executed when an element is visited.
        /// </summary>
        /// <param name="element">
        /// The element being visited.
        /// </param>
        /// <param name="parentElement">
        /// The parent element, if any.
        /// </param>
        /// <param name="context">
        /// The optional visitor context data.
        /// </param>
        /// <returns>
        /// Returns true to continue, or false to stop the walker.
        /// </returns>
        private bool VisitElement(CsElement element, CsElement parentElement, ref T context)
        {
            Param.AssertNotNull(element, "element");
            Param.Ignore(parentElement);
            Param.Ignore(context);

            if (this.elementCallback != null)
            {
                return this.elementCallback(element, parentElement, context);
            }

            return true;
        }

        /// <summary>
        /// Delegate for a callback executed when an expression is visited.
        /// </summary>
        /// <param name="expression">
        /// The expression being visited.
        /// </param>
        /// <param name="parentExpression">
        /// The parent expression, if any.
        /// </param>
        /// <param name="parentStatement">
        /// The parent statement, if any.
        /// </param>
        /// <param name="parentElement">
        /// The parent element, if any.
        /// </param>
        /// <param name="context">
        /// The optional visitor context data.
        /// </param>
        /// <returns>
        /// Returns true to continue, or false to stop the walker.
        /// </returns>
        private bool VisitExpression(Expression expression, Expression parentExpression, Statement parentStatement, CsElement parentElement, ref T context)
        {
            Param.AssertNotNull(expression, "expression");
            Param.Ignore(parentExpression);
            Param.Ignore(parentStatement);
            Param.Ignore(parentElement);
            Param.Ignore(context);

            if (this.expressionCallback != null)
            {
                return this.expressionCallback(expression, parentExpression, parentStatement, parentElement, context);
            }

            return true;
        }

        /// <summary>
        /// Delegate for a callback executed when a query clause is visited.
        /// </summary>
        /// <param name="clause">
        /// The query clause being visited.
        /// </param>
        /// <param name="parentClause">
        /// The parent query clause, if any.
        /// </param>
        /// <param name="parentExpression">
        /// The parent expression, if any.
        /// </param>
        /// <param name="parentStatement">
        /// The parent statement, if any.
        /// </param>
        /// <param name="parentElement">
        /// The parent element, if any.
        /// </param>
        /// <param name="context">
        /// The optional visitor context data.
        /// </param>
        /// <returns>
        /// Returns true to continue, or false to stop the walker.
        /// </returns>
        private bool VisitQueryClause(
            QueryClause clause, QueryClause parentClause, Expression parentExpression, Statement parentStatement, CsElement parentElement, ref T context)
        {
            Param.AssertNotNull(clause, "clause");
            Param.Ignore(parentClause);
            Param.Ignore(parentExpression);
            Param.Ignore(parentStatement);
            Param.Ignore(parentElement);
            Param.Ignore(context);

            if (this.queryClauseCallback != null)
            {
                return this.queryClauseCallback(clause, parentClause, parentExpression, parentStatement, parentElement, context);
            }

            return true;
        }

        /// <summary>
        /// Delegate for a callback executed when a statement is visited.
        /// </summary>
        /// <param name="statement">
        /// The statement being visited.
        /// </param>
        /// <param name="parentExpression">
        /// The parent expression, if any.
        /// </param>
        /// <param name="parentStatement">
        /// The parent statement, if any.
        /// </param>
        /// <param name="parentElement">
        /// The parent element, if any.
        /// </param>
        /// <param name="context">
        /// The optional visitor context data.
        /// </param>
        /// <returns>
        /// Returns true to continue, or false to stop the walker.
        /// </returns>
        private bool VisitStatement(Statement statement, Expression parentExpression, Statement parentStatement, CsElement parentElement, ref T context)
        {
            Param.AssertNotNull(statement, "statement");
            Param.Ignore(parentExpression);
            Param.Ignore(parentStatement);
            Param.Ignore(parentElement);
            Param.Ignore(context);

            if (this.statementCallback != null)
            {
                return this.statementCallback(statement, parentExpression, parentStatement, parentElement, context);
            }

            return true;
        }

        /// <summary>
        /// Walks the children of the given element.
        /// </summary>
        /// <param name="element">
        /// The element.
        /// </param>
        /// <param name="parentElement">
        /// The parent element, if any.
        /// </param>
        /// <param name="context">
        /// The optional visitor context data.
        /// </param>
        /// <returns>
        /// Returns true to continue, or false to stop the walker.
        /// </returns>
        private bool WalkElement(CsElement element, CsElement parentElement, T context)
        {
            Param.Ignore(element, parentElement, context);

            if (element != null)
            {
                T childContext = context;
                if (!this.VisitElement(element, parentElement, ref childContext))
                {
                    return false;
                }

                foreach (Statement childStatement in element.ChildStatements)
                {
                    if (!this.WalkStatement(childStatement, null, null, element, childContext))
                    {
                        return false;
                    }
                }

                foreach (CsElement childElement in element.ChildElements)
                {
                    if (!this.WalkElement(childElement, element, childContext))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Walks the children of the given expression.
        /// </summary>
        /// <param name="expression">
        /// The expression.
        /// </param>
        /// <param name="parentExpression">
        /// The parent expression, if any.
        /// </param>
        /// <param name="parentStatement">
        /// The parent statement, if any.
        /// </param>
        /// <param name="parentElement">
        /// The parent element, if any.
        /// </param>
        /// <param name="context">
        /// The optional visitor context data.
        /// </param>
        /// <returns>
        /// Returns true to continue, or false to stop the walker.
        /// </returns>
        private bool WalkExpression(Expression expression, Expression parentExpression, Statement parentStatement, CsElement parentElement, T context)
        {
            Param.Ignore(expression, parentExpression, parentStatement, parentElement, context);

            if (expression != null)
            {
                T childContext = context;
                if (!this.VisitExpression(expression, parentExpression, parentStatement, parentElement, ref childContext))
                {
                    return false;
                }

                foreach (Expression childExpression in expression.ChildExpressions)
                {
                    if (!this.WalkExpression(childExpression, expression, parentStatement, parentElement, childContext))
                    {
                        return false;
                    }
                }

                if (expression.ExpressionType == ExpressionType.Query)
                {
                    QueryExpression queryExpression = (QueryExpression)expression;
                    foreach (QueryClause childClause in queryExpression.ChildClauses)
                    {
                        if (!this.WalkQueryClause(childClause, null, expression, parentStatement, parentElement, childContext))
                        {
                            return false;
                        }
                    }
                }

                foreach (Statement childStatement in expression.ChildStatements)
                {
                    if (!this.WalkStatement(childStatement, expression, parentStatement, parentElement, childContext))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Walks the children of the given query clause.
        /// </summary>
        /// <param name="clause">
        /// The clause.
        /// </param>
        /// <param name="parentClause">
        /// The parent clause, if any.
        /// </param>
        /// <param name="parentExpression">
        /// The parent expression, if any.
        /// </param>
        /// <param name="parentStatement">
        /// The parent statement, if any.
        /// </param>
        /// <param name="parentElement">
        /// The parent element, if any.
        /// </param>
        /// <param name="context">
        /// The optional visitor context data.
        /// </param>
        /// <returns>
        /// Returns true to continue, or false to stop the walker.
        /// </returns>
        private bool WalkQueryClause(
            QueryClause clause, QueryClause parentClause, Expression parentExpression, Statement parentStatement, CsElement parentElement, T context)
        {
            Param.Ignore(clause, parentClause, parentExpression, parentStatement, parentElement, context);

            if (clause != null)
            {
                T childContext = context;
                if (!this.VisitQueryClause(clause, parentClause, parentExpression, parentStatement, parentElement, ref childContext))
                {
                    return false;
                }

                foreach (Expression childExpression in clause.ChildExpressions)
                {
                    if (!this.WalkExpression(childExpression, parentExpression, parentStatement, parentElement, childContext))
                    {
                        return false;
                    }
                }

                if (clause.QueryClauseType == QueryClauseType.Continuation)
                {
                    QueryContinuationClause continuationClause = (QueryContinuationClause)clause;
                    foreach (QueryClause childClause in continuationClause.ChildClauses)
                    {
                        if (!this.WalkQueryClause(childClause, clause, parentExpression, parentStatement, parentElement, childContext))
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Walks the children of the given statement.
        /// </summary>
        /// <param name="statement">
        /// The statement.
        /// </param>
        /// <param name="parentExpression">
        /// The parent expression, if any.
        /// </param>
        /// <param name="parentStatement">
        /// The parent statement, if any.
        /// </param>
        /// <param name="parentElement">
        /// The parent element, if any.
        /// </param>
        /// <param name="context">
        /// The optional visitor context data.
        /// </param>
        /// <returns>
        /// Returns true to continue, or false to stop the walker.
        /// </returns>
        private bool WalkStatement(Statement statement, Expression parentExpression, Statement parentStatement, CsElement parentElement, T context)
        {
            Param.Ignore(statement, parentExpression, parentStatement, parentElement, context);

            if (statement != null)
            {
                T childContext = context;
                if (!this.VisitStatement(statement, parentExpression, parentStatement, parentElement, ref childContext))
                {
                    return false;
                }

                foreach (Expression childExpression in statement.ChildExpressions)
                {
                    if (!this.WalkExpression(childExpression, parentExpression, statement, parentElement, childContext))
                    {
                        return false;
                    }
                }

                foreach (Statement childStatement in statement.ChildStatements)
                {
                    if (!this.WalkStatement(childStatement, parentExpression, statement, parentElement, childContext))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        #endregion
    }
}