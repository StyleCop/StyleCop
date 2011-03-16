//-----------------------------------------------------------------------
// <copyright file="UsingStatement.cs">
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
        /// The body of the using-statement.
        /// </summary>
        private CodeUnitProperty<Statement> body;

        /// <summary>
        /// The collection of variables declared within the statement.
        /// </summary>
        private CodeUnitProperty<VariableCollection> variables;

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
                    CsLanguageService.Debug.Assert(this.body.Value != null, "Failed to initialize.");
                }

                return this.resource.Value;
            }
        }

        /// <summary>
        /// Gets the body of the using-statement.
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
        /// Gets the variables defined within this code unit.
        /// </summary>
        /// <returns>Returns the collection of variables.</returns>
        public override VariableCollection Variables
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.variables.Initialized)
                {
                    this.variables.Value = new VariableCollection();

                    VariableDeclarationExpression item = this.FindFirstChild<VariableDeclarationExpression>();
                    if (item != null)
                    {
                        this.variables.Value.AddRange(item.Variables);
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

            this.resource.Value = openParen.FindNextSiblingExpression();
            if (this.resource.Value == null)
            {
                throw new SyntaxException(this.Document, this.LineNumber);
            }

            CloseParenthesisToken closeParen = this.resource.Value.FindNextSibling<CloseParenthesisToken>();
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
