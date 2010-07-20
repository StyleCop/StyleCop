//-----------------------------------------------------------------------
// <copyright file="LockStatement.cs" company="Microsoft">
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
    using System.Diagnostics;

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
        private CodeUnitProperty<Expression> lockedExpression;

        /// <summary>
        /// The statement that is embedded within this lock-statement.
        /// </summary>
        private CodeUnitProperty<Statement> embeddedStatement;

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

            this.lockedExpression.Value = lockedExpression;
        }

        #endregion Internal Constructors

        #region Public Properties

        /// <summary>
        /// Gets the item to lock.
        /// </summary>
        public Expression LockedExpression
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.lockedExpression.Initialized)
                {
                    this.Initialize();
                    Debug.Assert(this.lockedExpression.Value != null, "Failed to initialize.");
                }

                return this.lockedExpression.Value;
            }
        }

        /// <summary>
        /// Gets the statement that is embedded within this lock-statement.
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

            this.lockedExpression.Reset();
            this.embeddedStatement.Reset();
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

            this.lockedExpression.Value = openParen.FindNextSibling<Expression>();
            if (this.lockedExpression.Value == null)
            {
                throw new SyntaxException(this.Document, this.LineNumber);
            }

            CloseParenthesisToken closeParen = this.lockedExpression.Value.FindNextSibling<CloseParenthesisToken>();
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

        #endregion Private Methods
    }
}
