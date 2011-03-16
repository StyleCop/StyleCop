//-----------------------------------------------------------------------
// <copyright file="IfStatement.cs">
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
    /// An if-statement.
    /// </summary>
    /// <subcategory>statement</subcategory>
    public sealed class IfStatement : Statement
    {
        #region Private Fields

        /// <summary>
        /// The expression within the if-statement.
        /// </summary>
        private CodeUnitProperty<Expression> condition;

        /// <summary>
        /// The body of the if-statement.
        /// </summary>
        private CodeUnitProperty<Statement> body;

        /// <summary>
        /// The else-statement attached to the end of this if-statement, if any.
        /// </summary>
        private CodeUnitProperty<ElseStatement> elseStatement;

        /// <summary>
        /// All of the else statements attached to this if-statement.
        /// </summary>
        private CodeUnitProperty<ICollection<Statement>> attachedStatements;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the IfStatement class.
        /// </summary>
        /// <param name="proxy">Proxy object for the statement.</param>
        /// <param name="condition">The expression within the if-statement.</param>
        internal IfStatement(CodeUnitProxy proxy, Expression condition)
            : base(proxy, StatementType.If)
        {
            Param.AssertNotNull(proxy, "proxy");
            Param.AssertNotNull(condition, "condition");

            this.condition.Value = condition;
        }

        #endregion Internal Constructors

        #region Public Properties

        /// <summary>
        /// Gets the expression within the if-statement.
        /// </summary>
        public Expression Condition
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.condition.Initialized)
                {
                    this.Initialize();
                    CsLanguageService.Debug.Assert(this.condition.Value != null, "Failed to initialize.");
                }

                return this.condition.Value;
            }
        }

        /// <summary>
        /// Gets the body of the if-statement.
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

        /// <summary>
        /// Gets the else-statement attached to the end of this if-statement, if any.
        /// </summary>
        public ElseStatement AttachedElseStatement
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.elseStatement.Initialized)
                {
                    this.Initialize();
                }

                return this.elseStatement.Value;
            }
        }

        #endregion Public Properties

        #region Public Override Properties

        /// <summary>
        /// Gets the collection of statements attached to this if-statement.
        /// </summary>
        public override ICollection<Statement> AttachedStatements
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.attachedStatements.Initialized)
                {
                    List<Statement> elses = new List<Statement>();

                    ElseStatement @else = this.AttachedElseStatement;
                    while (@else != null)
                    {
                        elses.Add(@else);
                        @else = @else.AttachedElseStatement;
                    }

                    this.attachedStatements.Value = elses.AsReadOnly();
                }

                return this.attachedStatements.Value;
            }
        }

        #endregion Public Override Properties

        #region Protected Override Methods

        /// <summary>
        /// Resets the contents of the class.
        /// </summary>
        protected override void Reset()
        {
            base.Reset();

            this.condition.Reset();
            this.body.Reset();
            this.elseStatement.Reset();
            this.attachedStatements.Reset();
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

            this.condition.Value = openParen.FindNextSiblingExpression();
            if (this.condition.Value == null)
            {
                throw new SyntaxException(this.Document, this.LineNumber);
            }

            CloseParenthesisToken closeParen = this.condition.Value.FindNextSibling<CloseParenthesisToken>();
            if (closeParen == null)
            {
                throw new SyntaxException(this.Document, this.LineNumber);
            }

            this.body.Value = closeParen.FindNextSiblingStatement();
            if (this.body.Value == null)
            {
                throw new SyntaxException(this.Document, this.LineNumber);
            }

            // Look for an attached else statement after the if-statement.
            this.elseStatement.Value = null;

            for (CodeUnit c = this.FindNextSibling(); c != null; c = c.FindNext())
            {
                if (c.Is(StatementType.Else))
                {
                    this.elseStatement.Value = (ElseStatement)c;
                }
                else if (!c.Is(CodeUnitType.LexicalElement) || c.Is(LexicalElementType.Token))
                {
                    break;
                }
            }
        }

        #endregion Private Methods
    }
}
