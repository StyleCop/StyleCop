// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IfStatement.cs" company="https://github.com/StyleCop">
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
// <summary>
//   An if-statement.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    using System.Collections.Generic;

    /// <summary>
    /// An if-statement.
    /// </summary>
    /// <subcategory>statement</subcategory>
    public sealed class IfStatement : Statement
    {
        #region Fields

        /// <summary>
        /// The expression within the if-statement.
        /// </summary>
        private readonly Expression conditionExpression;

        /// <summary>
        /// The else-statement attached to the end of this if-statement, if any.
        /// </summary>
        private ElseStatement elseStatement;

        /// <summary>
        /// The statement that is embedded within this if-statement.
        /// </summary>
        private Statement embeddedStatement;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the IfStatement class.
        /// </summary>
        /// <param name="tokens">
        /// The list of tokens that form the statement.
        /// </param>
        /// <param name="conditionExpression">
        /// The expression within the if-statement.
        /// </param>
        internal IfStatement(CsTokenList tokens, Expression conditionExpression)
            : base(StatementType.If, tokens)
        {
            Param.AssertNotNull(tokens, "tokens");
            Param.AssertNotNull(conditionExpression, "conditionExpression");

            this.conditionExpression = conditionExpression;
            this.AddExpression(conditionExpression);
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the else-statement attached to the end of this if-statement, if any.
        /// </summary>
        public ElseStatement AttachedElseStatement
        {
            get
            {
                return this.elseStatement;
            }

            internal set
            {
                this.elseStatement = value;
            }
        }

        /// <summary>
        /// Gets the collection of statements attached to this if-statement.
        /// </summary>
        public override IEnumerable<Statement> AttachedStatements
        {
            get
            {
                ElseStatement elseStatement = this.elseStatement;
                while (elseStatement != null)
                {
                    yield return elseStatement;
                    elseStatement = elseStatement.AttachedElseStatement;
                }

                yield break;
            }
        }

        /// <summary>
        /// Gets the expression within the if-statement.
        /// </summary>
        public Expression ConditionExpression
        {
            get
            {
                return this.conditionExpression;
            }
        }

        /// <summary>
        /// Gets the statement that is embedded within this if-statement.
        /// </summary>
        public Statement EmbeddedStatement
        {
            get
            {
                return this.embeddedStatement;
            }

            internal set
            {
                Param.AssertNotNull(value, "EmbeddedStatement");
                this.embeddedStatement = value;
                this.AddStatement(this.embeddedStatement);
            }
        }

        #endregion
    }
}