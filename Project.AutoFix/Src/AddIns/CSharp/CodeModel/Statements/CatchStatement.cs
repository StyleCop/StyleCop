//-----------------------------------------------------------------------
// <copyright file="CatchStatement.cs">
//     MS-PL
// </copyright>
// <license>
//   This source code is subject to terms and conditions of the Microsoft 
//   Public License. A copy of the license can be found in the License.html 
//   file at the root of this distribution. 
//   By using this source code in any fashion, you are agreeing to be bound 
//   by the terms of the Microsoft Public License. You must not remove this 
//   notice, or any other, from this software.
// </license>
//-----------------------------------------------------------------------
namespace StyleCop.CSharp.CodeModel
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// A catch-statement.
    /// </summary>
    /// <subcategory>statement</subcategory>
    public sealed class CatchStatement : Statement
    {
        #region Private Fields

        /// <summary>
        /// The try-statement that this catch-statement is attached to.
        /// </summary>
        private CodeUnitProperty<TryStatement> tryStatement;

        /// <summary>
        /// The inner expression.
        /// </summary>
        private CodeUnitProperty<Expression> catchExpression;

        /// <summary>
        /// The exception variable identifier.
        /// </summary>
        private CodeUnitProperty<string> identifier;

        /// <summary>
        /// The class type of the exception being caught.
        /// </summary>
        private CodeUnitProperty<TypeToken> exceptionType;

        /// <summary>
        /// The body of the catch-statement.
        /// </summary>
        private CodeUnitProperty<BlockStatement> body;

        /// <summary>
        /// The variables declared within the statement.
        /// </summary>
        private CodeUnitProperty<VariableCollection> variables;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the CatchStatement class.
        /// </summary>
        /// <param name="proxy">Proxy object for the statement.</param>
        /// <param name="tryStatement">The try-statement that this catch-statement is attached to.</param>
        /// <param name="classExpression">The inner expression.</param>
        /// <param name="body">The body of the catch-statement.</param>
        internal CatchStatement(
            CodeUnitProxy proxy,
            TryStatement tryStatement,
            Expression classExpression,
            BlockStatement body)
            : base(proxy, StatementType.Catch)
        {
            Param.AssertNotNull(proxy, "proxy");
            Param.AssertNotNull(tryStatement, "tryStatement");
            Param.Ignore(classExpression);
            Param.AssertNotNull(body, "body");

            this.tryStatement.Value = tryStatement;
            this.catchExpression.Value = classExpression;
            this.body.Value = body;
        }

        #endregion Internal Constructors

        #region Public Override Properties

        /// <summary>
        /// Gets the variables defined within this code unit.
        /// </summary>
        public override VariableCollection Variables
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.variables.Initialized)
                {
                    this.variables.Value = new VariableCollection();

                    Expression @catch = this.CatchExpression;

                    if (@catch != null)
                    {
                        var expression = @catch.FindFirst<VariableDeclarationExpression>();
                        if (expression != null)
                        {
                            this.variables.Value.AddRange(expression.Variables);
                        }
                    }
                }

                return this.variables.Value;
            }
        }

        #endregion Public Override Properties

        #region Public Properties

        /// <summary>
        /// Gets the try-statement that this catch-statement is attached to.
        /// </summary>
        public TryStatement TryStatement
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.tryStatement.Initialized)
                {
                    this.Initialize();
                    CsLanguageService.Debug.Assert(this.tryStatement.Value != null, "Failed to initialize.");
                }

                return this.tryStatement.Value;
            }
        }

        /// <summary>
        /// Gets the class type of the exception being caught.
        /// </summary>
        public TypeToken ExceptionType
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.exceptionType.Initialized)
                {
                    this.Initialize();
                    CsLanguageService.Debug.Assert(this.exceptionType.Value != null, "Failed to initialize.");
                }

                return this.exceptionType.Value;
            }
        }

        /// <summary>
        /// Gets the exception variable identifier.
        /// </summary>
        public string Identifier
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.identifier.Initialized)
                {
                    this.Initialize();
                    CsLanguageService.Debug.Assert(this.identifier.Value != null, "Failed to initialize.");
                }

                return this.identifier.Value;
            }
        }

        /// <summary>
        /// Gets the expression within the catch statement.
        /// </summary>
        public Expression CatchExpression
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.catchExpression.Initialized)
                {
                    this.Initialize();
                    CsLanguageService.Debug.Assert(this.catchExpression.Value != null, "Failed to initialize.");
                }

                return this.catchExpression.Value;
            }
        }

        /// <summary>
        /// Gets the body of the catch-statement.
        /// </summary>
        public BlockStatement Body
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.body.Initialized)
                {
                    this.Initialize();
                    CsLanguageService.Debug.Assert(this.body.Value != null, "Failed to initialize.");
                }

                return this.body.Value;
            }
        }

        #endregion Public Properties

        #region Protected Override Methods

        /// <summary>
        /// Resets the contents of the class.
        /// </summary>
        protected override void Reset()
        {
            base.Reset();

            this.tryStatement.Reset();
            this.catchExpression.Reset();
            this.identifier.Reset();
            this.exceptionType.Reset();
            this.body.Reset();
            this.variables.Reset();
        }

        #endregion Protected Override Methods

        #region Private Methods

        /// <summary>
        /// Initializes the contents of the statement.
        /// </summary>
        private void Initialize()
        {
            CodeUnit start = this.FindFirstChild<OpenParenthesisToken>();
            if (start == null)
            {
                throw new SyntaxException(this.Document, this.LineNumber);
            }

            Expression expression = start.FindNextSiblingExpression();
            if (expression != null)
            {
                this.catchExpression.Value = expression;

                if (expression.ExpressionType == ExpressionType.Literal)
                {
                    this.exceptionType.Value = CodeParser.ExtractTypeTokenFromLiteralExpression((LiteralExpression)expression);
                }
                else if (expression.ExpressionType == ExpressionType.VariableDeclaration)
                {
                    VariableDeclarationExpression variableDeclaration = (VariableDeclarationExpression)expression;

                    this.exceptionType.Value = variableDeclaration.Type;

                    foreach (VariableDeclaratorExpression declarator in variableDeclaration.Declarators)
                    {
                        this.identifier.Value = declarator.Identifier.Text;
                        break;
                    }
                }

                start = expression;
            }

            CloseParenthesisToken closeParen = start.FindNextSibling<CloseParenthesisToken>();
            if (closeParen == null)
            {
                throw new SyntaxException(this.Document, this.LineNumber);
            }

            this.body.Value = closeParen.FindNextSibling<BlockStatement>();
            if (this.body.Value == null)
            {
                throw new SyntaxException(this.Document, this.LineNumber);
            }

            // Look for the try-statement that this catch-statement is attached to.
            this.tryStatement.Value = null;

            for (CodeUnit c = this.FindPreviousSibling(); c != null; c = c.FindNext())
            {
                if (c.Is(StatementType.Try))
                {
                    this.tryStatement.Value = (TryStatement)c;
                }
                else if (!c.Is(StatementType.Catch) && (!c.Is(CodeUnitType.LexicalElement) || c.Is(LexicalElementType.Token)))
                {
                    break;
                }
            }

            if (this.tryStatement.Value == null)
            {
                throw new SyntaxException(this.Document, this.LineNumber);
            }
        }

        #endregion Private Methods
    }
}
