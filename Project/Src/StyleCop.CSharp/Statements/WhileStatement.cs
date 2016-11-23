// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WhileStatement.cs" company="https://github.com/StyleCop">
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
//   A while-statement.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    /// <summary>
    /// A while-statement.
    /// </summary>
    /// <subcategory>statement</subcategory>
    public sealed class WhileStatement : Statement
    {
        #region Fields

        /// <summary>
        /// The expression within the while-statement.
        /// </summary>
        private readonly Expression conditionExpression;

        /// <summary>
        /// The statement that is embedded within this while-statement.
        /// </summary>
        private Statement embeddedStatement;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the WhileStatement class.
        /// </summary>
        /// <param name="tokens">
        /// The list of tokens that form the statement.
        /// </param>
        /// <param name="conditionExpression">
        /// The expression within the while-statement.
        /// </param>
        internal WhileStatement(CsTokenList tokens, Expression conditionExpression)
            : base(StatementType.While, tokens)
        {
            Param.AssertNotNull(tokens, "tokens");
            Param.AssertNotNull(conditionExpression, "conditionExpression");

            this.conditionExpression = conditionExpression;
            this.AddExpression(conditionExpression);
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the expression within the while-statement.
        /// </summary>
        public Expression ConditionExpression
        {
            get
            {
                return this.conditionExpression;
            }
        }

        /// <summary>
        /// Gets the statement that is embedded within this while-statement.
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