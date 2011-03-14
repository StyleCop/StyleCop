//-----------------------------------------------------------------------
// <copyright file="SwitchStatement.cs">
//   MS-PL
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
namespace StyleCop.CSharp
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

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
        private Expression switchItem;

        /// <summary>
        /// The list of case statements under the switch statements.
        /// </summary>
        private ICollection<SwitchCaseStatement> caseStatements;

        /// <summary>
        /// The default statement under the switch statement, if there is one.
        /// </summary>
        private SwitchDefaultStatement defaultStatement;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the SwitchStatement class.
        /// </summary>
        /// <param name="tokens">The list of tokens that form the statement.</param>
        /// <param name="switchItem">The expression to switch off of.</param>
        /// <param name="caseStatements">The list of case statements under the switch statement.</param>
        /// <param name="defaultStatement">The default statement under the switch statement.</param>
        internal SwitchStatement(
            CsTokenList tokens, 
            Expression switchItem, 
            ICollection<SwitchCaseStatement> caseStatements, 
            SwitchDefaultStatement defaultStatement)
            : base(StatementType.Switch, tokens)
        {
            Param.AssertNotNull(tokens, "tokens");
            Param.AssertNotNull(switchItem, "switchItem");
            Param.AssertNotNull(caseStatements, "caseStatements");
            Param.Ignore(defaultStatement);

            this.switchItem = switchItem;
            this.caseStatements = caseStatements;
            this.defaultStatement = defaultStatement;

            Debug.Assert(caseStatements.IsReadOnly, "The collection of case statements should be read-only.");

            this.AddExpression(switchItem);

            foreach (Statement statement in caseStatements)
            {
                this.AddStatement(statement);
            }

            if (defaultStatement != null)
            {
                this.AddStatement(defaultStatement);
            }
        }

        #endregion Internal Constructors
    
        #region Public Properties

        /// <summary>
        /// Gets the expression to switch off of.
        /// </summary>
        public Expression SwitchItem
        {
            get
            {
                return this.switchItem;
            }
        }

        /// <summary>
        /// Gets the list of case statements under the switch statement.
        /// </summary>
        public ICollection<SwitchCaseStatement> CaseStatements
        {
            get
            {
                return this.caseStatements;
            }
        }

        /// <summary>
        /// Gets the default statement under the switch statement, if there is one.
        /// </summary>
        public SwitchDefaultStatement DefaultStatement
        {
            get
            {
                return this.defaultStatement;
            }
        }

        #endregion Public Properties
    }
}