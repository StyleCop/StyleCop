//-----------------------------------------------------------------------
// <copyright file="SwitchStatement.cs">
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
    /// A switch-statement.
    /// </summary>
    /// <subcategory>statement</subcategory>
    public sealed class SwitchStatement : Statement
    {
        #region Private Fields

        /// <summary>
        /// The expression to switch off of.
        /// </summary>
        private CodeUnitProperty<Expression> switchExpression;

        /// <summary>
        /// The list of case statements under the switch statements.
        /// </summary>
        private CodeUnitProperty<ICollection<SwitchCaseStatement>> caseStatements;

        /// <summary>
        /// The default statement under the switch statement, if there is one.
        /// </summary>
        private CodeUnitProperty<SwitchDefaultStatement> defaultStatement;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the SwitchStatement class.
        /// </summary>
        /// <param name="proxy">Proxy object for the statement.</param>
        /// <param name="switchExpression">The expression to switch off of.</param>
        /// <param name="caseStatements">The list of case statements under the switch statement.</param>
        /// <param name="defaultStatement">The default statement under the switch statement.</param>
        internal SwitchStatement(
            CodeUnitProxy proxy, 
            Expression switchExpression, 
            ICollection<SwitchCaseStatement> caseStatements, 
            SwitchDefaultStatement defaultStatement)
            : base(proxy, StatementType.Switch)
        {
            Param.AssertNotNull(proxy, "proxy");
            Param.AssertNotNull(switchExpression, "switchExpression");
            Param.AssertNotNull(caseStatements, "caseStatements");
            Param.Ignore(defaultStatement);

            this.switchExpression.Value = switchExpression;
            this.caseStatements.Value = caseStatements;
            this.defaultStatement.Value = defaultStatement;

            CsLanguageService.Debug.Assert(caseStatements.IsReadOnly, "The collection of case statements should be read-only.");
        }

        #endregion Internal Constructors
    
        #region Public Properties

        /// <summary>
        /// Gets the expression to switch off of.
        /// </summary>
        public Expression SwitchExpression
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.switchExpression.Initialized)
                {
                    this.Initialize();
                    CsLanguageService.Debug.Assert(this.switchExpression.Value != null, "Failed to initialize");
                }

                return this.switchExpression.Value;
            }
        }

        /// <summary>
        /// Gets the list of case statements under the switch statement.
        /// </summary>
        public ICollection<SwitchCaseStatement> CaseStatements
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.caseStatements.Initialized)
                {
                    this.Initialize();
                }

                return this.caseStatements.Value;
            }
        }

        /// <summary>
        /// Gets the default statement under the switch statement, if there is one.
        /// </summary>
        public SwitchDefaultStatement DefaultStatement
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.defaultStatement.Initialized)
                {
                    this.Initialize();
                }

                return this.defaultStatement.Value;
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

            this.switchExpression.Reset();
            this.caseStatements.Reset();
            this.defaultStatement.Reset();
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

            this.switchExpression.Value = openParen.FindNextSiblingExpression();
            if (this.switchExpression.Value == null)
            {
                throw new SyntaxException(this.Document, this.LineNumber);
            }

            CloseParenthesisToken closeParen = this.switchExpression.Value.FindNextSibling<CloseParenthesisToken>();
            if (closeParen == null)
            {
                throw new SyntaxException(this.Document, this.LineNumber);
            }

            this.defaultStatement.Value = null;
            List<SwitchCaseStatement> caseList = new List<SwitchCaseStatement>();

            for (CodeUnit c = closeParen.FindNextSibling(); c != null; c = c.FindNext())
            {
                if (c.Is(StatementType.SwitchCase))
                {
                    caseList.Add((SwitchCaseStatement)c);
                }
                else if (c.Is(StatementType.SwitchDefault))
                {
                    if (this.defaultStatement.Value != null)
                    {
                        throw new SyntaxException(this.Document, this.LineNumber);
                    }

                    this.defaultStatement.Value = (SwitchDefaultStatement)c;
                    break;
                }
                else if (c.Is(TokenType.OpenCurlyBracket))
                {
                    if (caseList.Count > 0 || this.defaultStatement.Value != null)
                    {
                        throw new SyntaxException(this.Document, this.LineNumber);
                    }
                }
                else if (!c.Is(CodeUnitType.LexicalElement) || c.Is(LexicalElementType.Token))
                {
                    break;
                }
            }

            this.caseStatements.Value = caseList.AsReadOnly();
        }

        #endregion Private Methods
    }
}
