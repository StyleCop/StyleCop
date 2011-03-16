//-----------------------------------------------------------------------
// <copyright file="LockStatement.cs">
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
    /// A lock-statement.
    /// </summary>
    /// <subcategory>statement</subcategory>
    public sealed class LockStatement : Statement
    {
        #region Private Fields

        /// <summary>
        /// The object to lock.
        /// </summary>
        private CodeUnitProperty<Expression> lockObject;

        /// <summary>
        /// The body of the lock-statement.
        /// </summary>
        private CodeUnitProperty<Statement> body;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the LockStatement class.
        /// </summary>
        /// <param name="proxy">Proxy object for the statement.</param>
        /// <param name="lockedExpression">The item to lock.</param>
        internal LockStatement(CodeUnitProxy proxy, Expression lockedExpression)
            : base(proxy, StatementType.Lock)
        {
            Param.AssertNotNull(proxy, "proxy");
            Param.AssertNotNull(lockedExpression, "lockedExpression");

            this.lockObject.Value = lockedExpression;
        }

        #endregion Internal Constructors

        #region Public Properties

        /// <summary>
        /// Gets the item to lock.
        /// </summary>
        public Expression LockObject
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.lockObject.Initialized)
                {
                    this.Initialize();
                    CsLanguageService.Debug.Assert(this.lockObject.Value != null, "Failed to initialize.");
                }

                return this.lockObject.Value;
            }
        }

        /// <summary>
        /// Gets the body of the lock-statement.
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

            this.lockObject.Reset();
            this.body.Reset();
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

            this.lockObject.Value = openParen.FindNextSiblingExpression();
            if (this.lockObject.Value == null)
            {
                throw new SyntaxException(this.Document, this.LineNumber);
            }

            CloseParenthesisToken closeParen = this.lockObject.Value.FindNextSibling<CloseParenthesisToken>();
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

        #endregion Private Methods
    }
}
