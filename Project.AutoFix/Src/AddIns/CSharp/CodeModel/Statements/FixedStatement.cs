//-----------------------------------------------------------------------
// <copyright file="FixedStatement.cs">
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
    /// A fixed-statement.
    /// </summary>
    /// <subcategory>statement</subcategory>
    public sealed class FixedStatement : Statement
    {
        #region Private Fields

        /// <summary>
        /// The fixed variable.
        /// </summary>
        private CodeUnitProperty<VariableDeclarationExpression> fixedVariable;

        /// <summary>
        /// The body of the fixed-statement.
        /// </summary>
        private CodeUnitProperty<Statement> body;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the FixedStatement class.
        /// </summary>
        /// <param name="proxy">Proxy object for the statement.</param>
        /// <param name="fixedVariable">The fixed variable.</param>
        internal FixedStatement(CodeUnitProxy proxy, VariableDeclarationExpression fixedVariable)
            : base(proxy, StatementType.Fixed)
        {
            Param.AssertNotNull(proxy, "proxy");
            Param.AssertNotNull(fixedVariable, "fixedVariable");

            this.fixedVariable.Value = fixedVariable;
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
                return this.FixedVariable.Variables;
            }
        }

        #endregion Public Override Properties

        #region Public Properties

        /// <summary>
        /// Gets the fixed variable.
        /// </summary>
        public VariableDeclarationExpression FixedVariable
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.fixedVariable.Initialized)
                {
                    this.Initialize();
                    CsLanguageService.Debug.Assert(this.fixedVariable.Value != null, "Failed to initialize.");
                }

                return this.fixedVariable.Value;
            }
        }

        /// <summary>
        /// Gets the body of the fixed-statement.
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

            this.fixedVariable.Reset();
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

            this.fixedVariable.Value = openParen.FindNextSibling<VariableDeclarationExpression>();
            if (this.fixedVariable.Value == null)
            {
                throw new SyntaxException(this.Document, this.LineNumber);
            }

            CloseParenthesisToken closeParen = this.fixedVariable.Value.FindNextSibling<CloseParenthesisToken>();
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
