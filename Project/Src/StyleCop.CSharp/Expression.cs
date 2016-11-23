// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Expression.cs" company="https://github.com/StyleCop">
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
//   A single expression within a <see cref="Statement" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Text;

    /// <summary>
    /// A single expression within a <see cref="Statement"/>.
    /// </summary>
    /// <subcategory>expression</subcategory>
    [DebuggerDisplay("{Text}")]
    public class Expression : CodeUnit
    {
        #region Fields

        /// <summary>
        /// The type of the expression.
        /// </summary>
        private readonly ExpressionType type;

        /// <summary>
        /// Stores a text representation of the expression. This is created on demand.
        /// </summary>
        private string text;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the Expression class.
        /// </summary>
        /// <param name="type">
        /// The type of the expression.
        /// </param>
        internal Expression(ExpressionType type)
            : base(CodePartType.Expression)
        {
            Param.Ignore(type);

            this.type = type;
        }

        /// <summary>
        /// Initializes a new instance of the Expression class.
        /// </summary>
        /// <param name="type">
        /// The type of the expression.
        /// </param>
        /// <param name="tokens">
        /// The list of tokens that form the expression.
        /// </param>
        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors", 
            Justification = "The tokens property is virtual but it this is safe as expressions are sealed.")]
        internal Expression(ExpressionType type, CsTokenList tokens)
            : base(CodePartType.Expression, tokens)
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
        /// Gets the type of the expression.
        /// </summary>
        public ExpressionType ExpressionType
        {
            get
            {
                return this.type;
            }
        }

        /// <summary>
        /// Gets a text representation of the expression.
        /// </summary>
        public string Text
        {
            get
            {
                if (this.text == null)
                {
                    this.CreateTextString();
                }

                return this.text;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Walks through the code units in the expression.
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
        public void WalkExpression<T>(
            CodeWalkerStatementVisitor<T> statementCallback, 
            CodeWalkerExpressionVisitor<T> expressionCallback, 
            CodeWalkerQueryClauseVisitor<T> queryClauseCallback, 
            T context)
        {
            Param.Ignore(statementCallback, expressionCallback, queryClauseCallback, context);
            CodeWalker<T>.Start(this, statementCallback, expressionCallback, queryClauseCallback, context);
        }

        /// <summary>
        /// Walks through the code units in the expression.
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
        public void WalkExpression<T>(CodeWalkerStatementVisitor<T> statementCallback, CodeWalkerExpressionVisitor<T> expressionCallback, T context)
        {
            Param.Ignore(statementCallback, expressionCallback, context);
            this.WalkExpression(statementCallback, expressionCallback, null, context);
        }

        /// <summary>
        /// Walks through the code units in the expression.
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
        public void WalkExpression<T>(CodeWalkerStatementVisitor<T> statementCallback, T context)
        {
            Param.Ignore(statementCallback, context);
            this.WalkExpression(statementCallback, null, null, context);
        }

        /// <summary>
        /// Walks through the code units in the expression.
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
        public void WalkExpression(
            CodeWalkerStatementVisitor<object> statementCallback, 
            CodeWalkerExpressionVisitor<object> expressionCallback, 
            CodeWalkerQueryClauseVisitor<object> queryClauseCallback)
        {
            Param.Ignore(statementCallback, expressionCallback, queryClauseCallback);
            CodeWalker<object>.Start(this, statementCallback, expressionCallback, queryClauseCallback, null);
        }

        /// <summary>
        /// Walks through the code units in the expression.
        /// </summary>
        /// <param name="statementCallback">
        /// Callback executed when a statement is visited.
        /// </param>
        /// <param name="expressionCallback">
        /// Callback executed when an expression is visited.
        /// </param>
        public void WalkExpression(CodeWalkerStatementVisitor<object> statementCallback, CodeWalkerExpressionVisitor<object> expressionCallback)
        {
            Param.Ignore(statementCallback, expressionCallback);
            this.WalkExpression(statementCallback, expressionCallback, null, null);
        }

        /// <summary>
        /// Walks through the code units in the expression.
        /// </summary>
        /// <param name="statementCallback">
        /// Callback executed when a statement is visited.
        /// </param>
        public void WalkExpression(CodeWalkerStatementVisitor<object> statementCallback)
        {
            Param.Ignore(statementCallback);
            this.WalkExpression(statementCallback, null, null, null);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Creates a text string based on the child tokens in the attribute.
        /// </summary>
        private void CreateTextString()
        {
            StringBuilder tokenText = new StringBuilder();
            foreach (CsToken token in this.Tokens)
            {
                // Strip out comments and preprocessor directives.
                if (token.CsTokenType != CsTokenType.SingleLineComment && token.CsTokenType != CsTokenType.MultiLineComment
                    && token.CsTokenType != CsTokenType.PreprocessorDirective)
                {
                    string decodedText = CodeLexer.DecodeEscapedText(token.Text, true);
                    tokenText.Append(decodedText);
                }
            }

            this.text = tokenText.ToString();
        }

        #endregion
    }
}