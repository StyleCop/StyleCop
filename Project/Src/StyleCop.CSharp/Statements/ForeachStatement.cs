// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ForeachStatement.cs" company="https://github.com/StyleCop">
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
//   A foreach statement.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    /// <summary>
    /// A foreach statement.
    /// </summary>
    /// <subcategory>statement</subcategory>
    public sealed class ForeachStatement : Statement
    {
        #region Fields

        /// <summary>
        /// The item being iterated over.
        /// </summary>
        private readonly Expression item;

        /// <summary>
        /// The variable or tuple type, declared in the foreach statement declaration.
        /// </summary>
        private readonly Expression variable;

        /// <summary>
        /// The statement that is embedded within this foreach statement.
        /// </summary>
        private Statement embeddedStatement;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the ForeachStatement class.
        /// </summary>
        /// <param name="tokens">
        /// The list of tokens that form the statement.
        /// </param>
        /// <param name="variable">
        /// The variable or tuple type, declared in for each statement declaration.
        /// </param>
        /// <param name="item">
        /// The item being iterated over.
        /// </param>
        internal ForeachStatement(CsTokenList tokens, Expression variable, Expression item)
            : base(StatementType.Foreach, tokens)
        {
            Param.AssertNotNull(tokens, "tokens");
            Param.AssertNotNull(variable, "variable");
            Param.AssertNotNull(item, "item");
            Param.Assert(
                variable.ExpressionType == ExpressionType.VariableDeclaration || variable.ExpressionType == ExpressionType.Tuple, 
                nameof(variable), 
                "variable must be of type VariableDeclaration or Tuple");

            this.variable = variable;
            this.item = item;

            this.AddExpression(variable);
            this.AddExpression(item);
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the statement that is embedded within this foreach statement.
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

        /// <summary>
        /// Gets the item being iterated over.
        /// </summary>
        public Expression Item
        {
            get
            {
                return this.item;
            }
        }

        /// <summary>
        /// Gets the variable or tuple type, declared in the foreach statement declaration.
        /// </summary>
        public Expression Variable
        {
            get
            {
                return this.variable;
            }
        }

        #endregion
    }
}