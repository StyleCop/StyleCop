//-----------------------------------------------------------------------
// <copyright file="WhileStatement.cs" company="Microsoft">
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
namespace Microsoft.StyleCop.CSharp
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// A while-statement.
    /// </summary>
    /// <subcategory>statement</subcategory>
    public sealed class WhileStatement : Statement
    {
        #region Private Fields

        /// <summary>
        /// The expression within the while-statement.
        /// </summary>
        private CodeUnitProperty<Expression> conditionExpression;

        /// <summary>
        /// The statement that is embedded within this while-statement.
        /// </summary>
        private CodeUnitProperty<Statement> embeddedStatement;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the WhileStatement class.
        /// </summary>
        /// <param name="proxy">Proxy object for the statement.</param>
        /// <param name="conditionExpression">The expression within the while-statement.</param>
        internal WhileStatement(CodeUnitProxy proxy, Expression conditionExpression)
            : base(proxy, StatementType.While)
        {
            Param.AssertNotNull(proxy, "proxy");
            Param.AssertNotNull(conditionExpression, "conditionExpression");

            this.conditionExpression.Value = conditionExpression;
        }

        #endregion Internal Constructors

        #region Public Properties

        /// <summary>
        /// Gets the expression within the while-statement.
        /// </summary>
        public Expression ConditionExpression
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.conditionExpression.Initialized)
                {
                    this.Initialize();
                    Debug.Assert(this.conditionExpression.Value != null, "Failed to initialize.");
                }

                return this.conditionExpression.Value;
            }
        }

        /// <summary>
        /// Gets the statement that is embedded within this while-statement.
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

            this.embeddedStatement.Reset();
            this.conditionExpression.Reset();
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

            this.conditionExpression.Value = openParen.FindNextSibling<Expression>();
            if (this.conditionExpression.Value == null)
            {
                throw new SyntaxException(this.Document, this.LineNumber);
            }

            CloseParenthesisToken closeParen = this.conditionExpression.Value.FindNextSibling<CloseParenthesisToken>();
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
