//-----------------------------------------------------------------------
// <copyright file="UsingStatement.cs" company="Microsoft">
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
    /// A using-statement.
    /// </summary>
    /// <subcategory>statement</subcategory>
    public sealed class UsingStatement : Statement
    {
        #region Private Fields

        /// <summary>
        /// The expression declared in the using-statement.
        /// </summary>
        private CodeUnitProperty<Expression> resource;

        /// <summary>
        /// The statement that is embedded within this using-statement.
        /// </summary>
        private CodeUnitProperty<Statement> embeddedStatement;

        /// <summary>
        /// The collection of variables declared within the statement.
        /// </summary>
        private CodeUnitProperty<IList<IVariable>> variables;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the UsingStatement class.
        /// </summary>
        /// <param name="proxy">Proxy object for the statement.</param>
        /// <param name="resource">The resource aquisition expression declared in the using statement.</param>
        internal UsingStatement(CodeUnitProxy proxy, Expression resource)
            : base(proxy, StatementType.Using)
        {
            Param.AssertNotNull(proxy, "proxy");
            Param.AssertNotNull(resource, "resource");

            this.resource.Value = resource;
        }

        #endregion Internal Constructors

        #region Public Properties

        /// <summary>
        /// Gets the resource aquisition expression assigned to the obtained resource.
        /// </summary>
        public Expression Resource
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.resource.Initialized)
                {
                    this.Initialize();
                    Debug.Assert(this.embeddedStatement.Value != null, "Failed to initialize.");
                }

                return this.resource.Value;
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

        /// <summary>
        /// Gets the variables defined within this code unit.
        /// </summary>
        /// <returns>Returns the collection of variables.</returns>
        public override IList<IVariable> Variables
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.variables.Initialized)
                {
                    VariableDeclarationExpression item = this.FindFirstChild<VariableDeclarationExpression>();
                    if (item != null)
                    {
                        this.variables.Value = item.Variables;
                    }
                    else
                    {
                        this.variables.Value = CsParser.EmptyVariableArray;
                    }
                }

                return this.variables.Value;
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

            this.resource.Reset();
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

            this.resource.Value = openParen.FindNextSibling<Expression>();
            if (this.resource.Value == null)
            {
                throw new SyntaxException(this.Document, this.LineNumber);
            }

            CloseParenthesisToken closeParen = this.resource.Value.FindNextSibling<CloseParenthesisToken>();
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
