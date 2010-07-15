//-----------------------------------------------------------------------
// <copyright file="ForeachStatement.cs" company="Microsoft">
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
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// A foreach-statement.
    /// </summary>
    /// <subcategory>statement</subcategory>
    public sealed class ForeachStatement : Statement
    {
        #region Private Fields

        /// <summary>
        /// The variable declared in the foreach-statement declaration.
        /// </summary>
        private CodeUnitProperty<VariableDeclarationExpression> variable;

        /// <summary>
        /// The item being interated over.
        /// </summary>
        private CodeUnitProperty<Expression> item;

        /// <summary>
        /// The statement that is embedded within this foreach-statement.
        /// </summary>
        private CodeUnitProperty<Statement> embeddedStatement;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the ForeachStatement class.
        /// </summary>
        /// <param name="proxy">Proxy object for the statement.</param>
        /// <param name="variable">The variable declared in foreach-statement declaration.</param>
        /// <param name="item">The item being iterated over.</param>
        internal ForeachStatement(CodeUnitProxy proxy, VariableDeclarationExpression variable, Expression item)
            : base(proxy, StatementType.Foreach)
        {
            Param.AssertNotNull(proxy, "proxy");
            Param.AssertNotNull(variable, "variable");
            Param.AssertNotNull(item, "item");

            this.variable.Value = variable;
            this.item.Value = item;
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
                return this.Variable.Variables;
            }
        }

        #endregion Public Override Properties

        #region Public Properties

        /// <summary>
        /// Gets the variable declared in the foreach-statement declaration.
        /// </summary>
        public VariableDeclarationExpression Variable
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.variable.Initialized)
                {
                    this.Initialize();
                    Debug.Assert(this.variable.Value != null, "Failed to initialize.");
                }

                return this.variable.Value;
            }
        }

        /// <summary>
        /// Gets the item being iterated over.
        /// </summary>
        public Expression Item
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.item.Initialized)
                {
                    this.Initialize();
                    Debug.Assert(this.item.Value != null, "Failed to initialize.");
                }

                return this.item.Value;
            }
        }

        /// <summary>
        /// Gets the statement that is embedded within this foreach-statement.
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

            this.item.Reset();
            this.embeddedStatement.Reset();
            this.variable.Reset();
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

            this.variable.Value = openParen.FindNextSibling<VariableDeclarationExpression>();
            if (this.variable.Value == null)
            {
                throw new SyntaxException(this.Document, this.LineNumber);
            }

            InToken @in = openParen.FindNextSibling<InToken>();
            if (@in == null)
            {
                throw new SyntaxException(this.Document, this.LineNumber);
            }

            this.item.Value = @in.FindNextSibling<Expression>();
            if (this.item.Value == null)
            {
                throw new SyntaxException(this.Document, this.LineNumber);
            }

            CloseParenthesisToken closeParen = this.item.Value.FindNextSibling<CloseParenthesisToken>();
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
