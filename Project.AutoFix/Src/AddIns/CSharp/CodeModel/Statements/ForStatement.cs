//-----------------------------------------------------------------------
// <copyright file="ForStatement.cs">
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
    /// A for-statement.
    /// </summary>
    /// <subcategory>statement</subcategory>
    public sealed class ForStatement : Statement
    {
        #region Private Fields

        /// <summary>
        /// The variables initialized in the for-statement.
        /// </summary>
        private CodeUnitProperty<ICollection<Expression>> initializers;

        /// <summary>
        /// The condition checked before each loop through the for-statement.
        /// </summary>
        private CodeUnitProperty<Expression> condition;

        /// <summary>
        /// The statements called at the end of each loop through the for-statement,
        /// used to advance the enumerator.
        /// </summary>
        private CodeUnitProperty<ICollection<Expression>> iterators;

        /// <summary>
        /// The body of the for-statement.
        /// </summary>
        private CodeUnitProperty<Statement> body;

        /// <summary>
        /// The variables declared within the statement.
        /// </summary>
        private CodeUnitProperty<VariableCollection> variables;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the ForStatement class.
        /// </summary>
        /// <param name="proxy">Proxy object for the statement.</param>
        /// <param name="initializers">The variables declared in the for-statement declaration.</param>
        /// <param name="condition">The condition expression.</param>
        /// <param name="iterators">The iterator expressions.</param>
        internal ForStatement(
            CodeUnitProxy proxy,
            ICollection<Expression> initializers,
            Expression condition,
            ICollection<Expression> iterators)
            : base(proxy, StatementType.For)
        {
            Param.AssertNotNull(proxy, "proxy");
            Param.AssertNotNull(initializers, "initializers");
            Param.Ignore(condition);
            Param.AssertNotNull(iterators, "iterators");
            
            this.initializers.Value = initializers;
            this.condition.Value = condition;
            this.iterators.Value = iterators;

            CsLanguageService.Debug.Assert(initializers.IsReadOnly, "The collection of initializers should be read-only.");
            CsLanguageService.Debug.Assert(iterators.IsReadOnly, "The collection of iterators should be read-only.");
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

                    ICollection<Expression> inits = this.Initializers;
                    if (inits != null && inits.Count > 0)
                    {
                        foreach (Expression initializerExpression in inits)
                        {
                            if (initializerExpression.Is(ExpressionType.VariableDeclaration))
                            {
                                this.variables.Value.AddRange(((VariableDeclarationExpression)initializerExpression).Variables);
                            }
                        }
                    }
                }

                return this.variables.Value;
            }
        }

        #endregion Public Override Properties

        #region Public Properties

        /// <summary>
        /// Gets the variables declared in the for-statement declaration.
        /// </summary>
        public ICollection<Expression> Initializers
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.initializers.Initialized)
                {
                    this.Initialize();
                }

                return this.initializers.Value;
            }
        }

        /// <summary>
        /// Gets the condition checked before each loop through the for-statement.
        /// </summary>
        public Expression Condition
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.condition.Initialized)
                {
                    this.Initialize();
                }

                return this.condition.Value;
            }
        }

        /// <summary>
        /// Gets the expressions called at the end of each loop through the for-statement,
        /// used to advance the enumerator.
        /// </summary>
        public ICollection<Expression> Iterators
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.iterators.Initialized)
                {
                    this.Initialize();
                }

                return this.iterators.Value;
            }
        }

        /// <summary>
        /// Gets body of the for-statement.
        /// </summary>
        public Statement Body
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

            this.initializers.Reset();
            this.condition.Reset();
            this.iterators.Reset();
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
            OpenParenthesisToken openParen = this.FindFirstChild<OpenParenthesisToken>();
            if (openParen == null)
            {
                throw new SyntaxException(this.Document, this.LineNumber);
            }

            this.initializers.Value = this.FindInitializers(openParen);
            if (this.initializers.Value == null)
            {
                throw new SyntaxException(this.Document, this.LineNumber);
            }

            SemicolonToken semicolon = openParen.FindNextSibling<SemicolonToken>();
            if (semicolon == null)
            {
                throw new SyntaxException(this.Document, this.LineNumber);
            }

            this.condition.Value = this.FindCondition(semicolon);

            semicolon = semicolon.FindNextSibling<SemicolonToken>();
            if (semicolon == null)
            {
                throw new SyntaxException(this.Document, this.LineNumber);
            }

            this.iterators.Value = this.FindIterators(semicolon);
            if (this.iterators.Value == null)
            {
                throw new SyntaxException(this.Document, this.LineNumber);
            }

            CloseParenthesisToken closeParen = semicolon.FindNextSibling<CloseParenthesisToken>();
            if (closeParen == null)
            {
                throw new SyntaxException(this.Document, this.LineNumber);
            }

            this.body.Value = closeParen.FindNextSiblingStatement();
            if (this.body.Value == null)
            {
                throw new SyntaxException(this.Document, this.LineNumber);
            }
        }

        /// <summary>
        /// Finds and gathers the initializer expressions for the for statement.
        /// </summary>
        /// <param name="start">The code unit in front of the initializers.</param>
        /// <returns>Returns the collection of initializers.</returns>
        private ICollection<Expression> FindInitializers(CodeUnit start)
        {
            Param.AssertNotNull(start, "start");

            List<Expression> expressions = new List<Expression>();

            bool comma = true;
            for (CodeUnit c = start.FindNextSibling(); c != null; c = c.FindNextSibling())
            {
                if (!c.Is(CodeUnitType.LexicalElement) || c.Is(LexicalElementType.Token))
                {
                    if (c.Is(TokenType.Semicolon))
                    {
                        return expressions.AsReadOnly();
                    }
                    else if (comma)
                    {
                        comma = false;
                        if (c.Is(CodeUnitType.Expression))
                        {
                            expressions.Add((Expression)c);
                        }
                        else
                        {
                            throw new SyntaxException(this.Document, this.LineNumber);
                        }
                    }
                    else
                    {
                        if (c.Is(TokenType.Comma))
                        {
                            comma = true;
                        }
                        else
                        {
                            throw new SyntaxException(this.Document, this.LineNumber);
                        }
                    }
                }
            }

            throw new SyntaxException(this.Document, this.LineNumber);
        }

        /// <summary>
        /// Finds the condition expression if there is one.
        /// </summary>
        /// <param name="start">The code unit in front of the expression.</param>
        /// <returns>Returns the condition expression or null.</returns>
        private Expression FindCondition(CodeUnit start)
        {
            Param.AssertNotNull(start, "start");

            for (CodeUnit c = start.FindNextSibling(); c != null; c = c.FindNextSibling())
            {
                if (!c.Is(CodeUnitType.LexicalElement) || c.Is(LexicalElementType.Token))
                {
                    if (c.Is(TokenType.Semicolon))
                    {
                        return null;
                    }

                    if (c.Is(CodeUnitType.Expression))
                    {
                        return (Expression)c;
                    }

                    break;
                }
            }

            throw new SyntaxException(this.Document, this.LineNumber);
        }

        /// <summary>
        /// Finds and gathers the initializer expressions for the for statement.
        /// </summary>
        /// <param name="start">The code unit in front of the initializers.</param>
        /// <returns>Returns the collection of initializers.</returns>
        private ICollection<Expression> FindIterators(CodeUnit start)
        {
            Param.AssertNotNull(start, "start");

            List<Expression> expressions = new List<Expression>();

            bool comma = true;
            for (CodeUnit c = start.FindNextSibling(); c != null; c = c.FindNextSibling())
            {
                if (!c.Is(CodeUnitType.LexicalElement) || c.Is(LexicalElementType.Token))
                {
                    if (c.Is(TokenType.CloseParenthesis))
                    {
                        return expressions.AsReadOnly();
                    }
                    else if (comma)
                    {
                        comma = false;
                        if (c.Is(CodeUnitType.Expression))
                        {
                            expressions.Add((Expression)c);
                        }
                        else
                        {
                            throw new SyntaxException(this.Document, this.LineNumber);
                        }
                    }
                    else
                    {
                        if (c.Is(TokenType.Comma))
                        {
                            comma = true;
                        }
                        else
                        {
                            throw new SyntaxException(this.Document, this.LineNumber);
                        }
                    }
                }
            }

            throw new SyntaxException(this.Document, this.LineNumber);
        }

        #endregion Private Methods
    }
}