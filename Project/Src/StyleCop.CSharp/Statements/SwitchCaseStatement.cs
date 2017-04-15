// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SwitchCaseStatement.cs" company="https://github.com/StyleCop">
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
//   A case-statement within a switch-statement.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    /// <summary>
    /// A case-statement within a switch-statement.
    /// </summary>
    /// <subcategory>statement</subcategory>
    public sealed class SwitchCaseStatement : Statement
    {
        #region Fields

        /// <summary>
        /// The case label identifier.
        /// </summary>
        private readonly Expression identifier;

        /// <summary>
        /// The variable declared as part of pattern match of the case statement, if available.
        /// </summary>
        private readonly Expression matchVariable;

        /// <summary>
        /// The when expression declared as part of pattern match of the case statement, if available.
        /// </summary>
        private readonly Expression whenExpression;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the SwitchCaseStatement class.
        /// </summary>
        /// <param name="identifier">
        /// The case label identifier.
        /// </param>
        /// <param name="matchVariable">
        /// The variable declared as part of pattern match of the case statement.
        /// </param>
        /// <param name="whenExpression">
        /// The when expression declared as part of pattern match of the case statement.
        /// </param>
        internal SwitchCaseStatement(Expression identifier, Expression matchVariable, Expression whenExpression)
            : base(StatementType.SwitchCase)
        {
            Param.AssertNotNull(identifier, "identifier");
            Param.Ignore(matchVariable);
            Param.Ignore(whenExpression);

            this.identifier = identifier;
            this.matchVariable = matchVariable;
            this.whenExpression = whenExpression;

            this.AddExpression(identifier);

            if (this.matchVariable != null)
            {
                this.AddExpression(this.matchVariable);
            }

            if (this.whenExpression != null)
            {
                this.AddExpression(this.whenExpression);
            }
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the case label identifier.
        /// </summary>
        public Expression Identifier => this.identifier;

        /// <summary>
        /// Gets the expression that represents the variable declared as part of pattern match of the case statement, if available.
        /// </summary>
        public Expression MatchVariable => this.matchVariable;

        /// <summary>
        /// Gets the when expression that is declared as part of the case statement, if available.
        /// </summary>
        public Expression WhenExpression => this.whenExpression;

        #endregion
    }
}