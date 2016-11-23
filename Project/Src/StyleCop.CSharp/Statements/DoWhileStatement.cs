// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DoWhileStatement.cs" company="https://github.com/StyleCop">
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
//   A do-while-statement.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    /// <summary>
    /// A do-while-statement.
    /// </summary>
    /// <subcategory>statement</subcategory>
    public sealed class DoWhileStatement : Statement
    {
        #region Fields

        /// <summary>
        /// The expression within the while statement.
        /// </summary>
        private readonly Expression conditionExpression;

        /// <summary>
        /// The statement that is embedded within this do-while-statement.
        /// </summary>
        private readonly Statement embeddedStatement;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the DoWhileStatement class.
        /// </summary>
        /// <param name="tokens">
        /// The list of tokens that form the statement.
        /// </param>
        /// <param name="conditionExpression">
        /// The expression within the while statement.
        /// </param>
        /// <param name="embeddedStatement">
        /// The statement that is embedded within this do-while-statement.
        /// </param>
        internal DoWhileStatement(CsTokenList tokens, Expression conditionExpression, Statement embeddedStatement)
            : base(StatementType.DoWhile, tokens)
        {
            Param.AssertNotNull(tokens, "tokens");
            Param.AssertNotNull(conditionExpression, "conditionExpression");
            Param.AssertNotNull(embeddedStatement, "embeddedStatement");

            this.conditionExpression = conditionExpression;
            this.embeddedStatement = embeddedStatement;

            this.AddExpression(conditionExpression);
            this.AddStatement(embeddedStatement);
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the expression within the while statement.
        /// </summary>
        public Expression ConditionalExpression
        {
            get
            {
                return this.conditionExpression;
            }
        }

        /// <summary>
        /// Gets the statement that is embedded within this do-while-statement.
        /// </summary>
        public Statement EmbeddedStatement
        {
            get
            {
                return this.embeddedStatement;
            }
        }

        #endregion
    }
}