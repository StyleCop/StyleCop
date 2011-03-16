//-----------------------------------------------------------------------
// <copyright file="DoWhileStatement.cs">
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

    /// <summary>
    /// A do-while-statement.
    /// </summary>
    /// <subcategory>statement</subcategory>
    public sealed class DoWhileStatement : Statement
    {
        #region Private Fields

        /// <summary>
        /// The body of the do-while-statement.
        /// </summary>
        private CodeUnitProperty<Statement> body;

        /// <summary>
        /// The expression within the while statement.
        /// </summary>
        private CodeUnitProperty<Expression> condition;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the DoWhileStatement class.
        /// </summary>
        /// <param name="proxy">Proxy object for the statement.</param>
        /// <param name="condition">The expression within the while statement.</param>
        /// <param name="body">The body of the do-while-statement.</param>
        internal DoWhileStatement(CodeUnitProxy proxy, Expression condition, Statement body)
            : base(proxy, StatementType.DoWhile)
        {
            Param.AssertNotNull(proxy, "proxy");
            Param.AssertNotNull(condition, "condition");
            Param.AssertNotNull(body, "body");

            this.condition.Value = condition;
            this.body.Value = body;
        }

        #endregion Internal Constructors

        #region Public Properties

        /// <summary>
        /// Gets the expression within the while statement.
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
        /// Gets the body of the do-while-statement.
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

            this.body.Reset();
            this.condition.Reset();
        }

        #endregion Protected Override Methods

        #region Private Methods

        /// <summary>
        /// Initializes the contents of the statement.
        /// </summary>
        private void Initialize()
        {
            this.body.Value = this.FindFirstChildStatement();
            if (this.body.Value == null)
            {
                throw new SyntaxException(this.Document, this.LineNumber);
            }

            OpenParenthesisToken openParen = this.body.Value.FindNextSibling<OpenParenthesisToken>();
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
        }

        #endregion Private Methods
    }
}
