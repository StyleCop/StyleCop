//-----------------------------------------------------------------------
// <copyright file="ForStatement.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.
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
//-----------------------------------------------------------------------
namespace Microsoft.StyleCop.CSharp.CodeModel
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

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
        /// The statement that is embedded within this for-statement.
        /// </summary>
        private CodeUnitProperty<Statement> embeddedStatement;

        /// <summary>
        /// The variables declared within the statement.
        /// </summary>
        private CodeUnitProperty<IList<IVariable>> variables;

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

            Debug.Assert(initializers.IsReadOnly, "The collection of initializers should be read-only.");
            Debug.Assert(iterators.IsReadOnly, "The collection of iterators should be read-only.");
        }

        #endregion Internal Constructors

        #region Public Override Properties

        /// <summary>
        /// Gets the variables defined within this code unit.
        /// </summary>
        public override IList<IVariable> Variables
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.variables.Initialized)
                {
                    ICollection<Expression> inits = this.Initializers;
                    if (inits == null || inits.Count == 0)
                    {
                        this.variables.Value = CsLanguageService.EmptyVariableArray;
                    }
                    else
                    {
                        var vars = new List<IVariable>(inits.Count);

                        foreach (Expression initializerExpression in inits)
                        {
                            if (initializerExpression.Is(ExpressionType.VariableDeclaration))
                            {
                                vars.AddRange(((VariableDeclarationExpression)initializerExpression).Variables);
                            }
                        }

                        this.variables.Value = vars.AsReadOnly();
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
        /// Gets the statement that is embedded within this for-statement.
        /// </summary>
        public Statement EmbeddedStatement
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.embeddedStatement.Initialized)
                {
                    this.Initialize();
                    Debug.Assert(this.embeddedStatement.Value != null, "Failed to initialize.");
                }

                return this.embeddedStatement.Value;
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
            this.embeddedStatement.Reset();
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

            this.condition.Value = semicolon.FindNextSibling<Expression>();
            if (this.condition.Value == null)
            {
                throw new SyntaxException(this.Document, this.LineNumber);
            }

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

            this.embeddedStatement.Value = closeParen.FindNextSibling<Statement>();
            if (this.embeddedStatement.Value == null)
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

            bool comma = false;
            for (CodeUnit c = start.FindNextSibling<CodeUnit>(); c != null; c = c.FindNextSibling<CodeUnit>())
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

            bool comma = false;
            for (CodeUnit c = start.FindNextSibling<CodeUnit>(); c != null; c = c.FindNextSibling<CodeUnit>())
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

            throw new SyntaxException(this.Document, this.LineNumber);
        }

        #endregion Private Methods
    }
}