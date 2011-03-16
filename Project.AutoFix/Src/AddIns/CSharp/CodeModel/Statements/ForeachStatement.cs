//-----------------------------------------------------------------------
// <copyright file="ForeachStatement.cs">
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
    /// A foreach-statement.
    /// </summary>
    /// <subcategory>statement</subcategory>
    public sealed class ForeachStatement : Statement
    {
        #region Private Fields

        /// <summary>
        /// The variable declared in the foreach statement declaration.
        /// </summary>
        private CodeUnitProperty<VariableDeclarationExpression> iterationVariable;

        /// <summary>
        /// The item being interated over.
        /// </summary>
        private CodeUnitProperty<Expression> collection;

        /// <summary>
        /// The body of the foreach statement.
        /// </summary>
        private CodeUnitProperty<Statement> body;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the ForeachStatement class.
        /// </summary>
        /// <param name="proxy">Proxy object for the statement.</param>
        /// <param name="iterationVariable">The iteration variable declared in foreach statement declaration.</param>
        /// <param name="collection">The enumerable expression being iterated over.</param>
        internal ForeachStatement(CodeUnitProxy proxy, VariableDeclarationExpression iterationVariable, Expression collection)
            : base(proxy, StatementType.Foreach)
        {
            Param.AssertNotNull(proxy, "proxy");
            Param.AssertNotNull(iterationVariable, "iterationVariable");
            Param.AssertNotNull(collection, "collection");

            this.iterationVariable.Value = iterationVariable;
            this.collection.Value = collection;
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
                return this.IterationVariable.Variables;
            }
        }

        #endregion Public Override Properties

        #region Public Properties

        /// <summary>
        /// Gets the iteration variable declared in the foreach statement declaration.
        /// </summary>
        public VariableDeclarationExpression IterationVariable
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.iterationVariable.Initialized)
                {
                    this.Initialize();
                    CsLanguageService.Debug.Assert(this.iterationVariable.Value != null, "Failed to initialize.");
                }

                return this.iterationVariable.Value;
            }
        }

        /// <summary>
        /// Gets the enumerable expression being iterated over.
        /// </summary>
        public Expression Collection
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.collection.Initialized)
                {
                    this.Initialize();
                    CsLanguageService.Debug.Assert(this.collection.Value != null, "Failed to initialize.");
                }

                return this.collection.Value;
            }
        }

        /// <summary>
        /// Gets the body of the foreach statement.
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

            this.collection.Reset();
            this.body.Reset();
            this.iterationVariable.Reset();
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

            this.iterationVariable.Value = openParen.FindNextSibling<VariableDeclarationExpression>();
            if (this.iterationVariable.Value == null)
            {
                throw new SyntaxException(this.Document, this.LineNumber);
            }

            InToken @in = openParen.FindNextSibling<InToken>();
            if (@in == null)
            {
                throw new SyntaxException(this.Document, this.LineNumber);
            }

            this.collection.Value = @in.FindNextSiblingExpression();
            if (this.collection.Value == null)
            {
                throw new SyntaxException(this.Document, this.LineNumber);
            }

            CloseParenthesisToken closeParen = this.collection.Value.FindNextSibling<CloseParenthesisToken>();
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
