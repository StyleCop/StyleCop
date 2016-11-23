// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConstructorInitializerStatement.cs" company="https://github.com/StyleCop">
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
//   A constructor initialization statement.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    /// <summary>
    /// A constructor initialization statement.
    /// </summary>
    /// <subcategory>statement</subcategory>
    public sealed class ConstructorInitializerStatement : Statement
    {
        #region Fields

        /// <summary>
        /// The expression within this statement.
        /// </summary>
        private readonly MethodInvocationExpression expression;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the ConstructorInitializerStatement class.
        /// </summary>
        /// <param name="tokens">
        /// The list of tokens that form the statement.
        /// </param>
        /// <param name="expression">
        /// The expression within this statement.
        /// </param>
        internal ConstructorInitializerStatement(CsTokenList tokens, MethodInvocationExpression expression)
            : base(StatementType.ConstructorInitializer, tokens)
        {
            Param.AssertNotNull(tokens, "tokens");
            Param.AssertNotNull(expression, "expression");

            this.expression = expression;
            this.AddExpression(expression);
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the expression within this statement.
        /// </summary>
        public MethodInvocationExpression Expression
        {
            get
            {
                return this.expression;
            }
        }

        #endregion
    }
}