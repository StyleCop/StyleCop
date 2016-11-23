// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LockStatement.cs" company="https://github.com/StyleCop">
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
//   A lock-statement.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    /// <summary>
    /// A lock-statement.
    /// </summary>
    /// <subcategory>statement</subcategory>
    public sealed class LockStatement : Statement
    {
        #region Fields

        /// <summary>
        /// The object to lock.
        /// </summary>
        private readonly Expression lockedExpression;

        /// <summary>
        /// The statement that is embedded within this lock-statement.
        /// </summary>
        private Statement embeddedStatement;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the LockStatement class.
        /// </summary>
        /// <param name="tokens">
        /// The list of tokens that form the statement.
        /// </param>
        /// <param name="lockedExpression">
        /// The item to lock.
        /// </param>
        internal LockStatement(CsTokenList tokens, Expression lockedExpression)
            : base(StatementType.Lock, tokens)
        {
            Param.AssertNotNull(tokens, "tokens");
            Param.AssertNotNull(lockedExpression, "lockedExpression");

            this.lockedExpression = lockedExpression;
            this.AddExpression(lockedExpression);
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the statement that is embedded within this lock-statement.
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
        /// Gets the item to lock.
        /// </summary>
        public Expression LockedExpression
        {
            get
            {
                return this.lockedExpression;
            }
        }

        #endregion
    }
}