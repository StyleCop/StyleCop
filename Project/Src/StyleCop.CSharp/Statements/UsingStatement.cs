// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UsingStatement.cs" company="https://github.com/StyleCop">
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
//   A using-statement.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    /// <summary>
    /// A using-statement.
    /// </summary>
    /// <subcategory>statement</subcategory>
    public sealed class UsingStatement : Statement
    {
        #region Fields

        /// <summary>
        /// The expression declared in the using-statement.
        /// </summary>
        private readonly Expression resource;

        /// <summary>
        /// The statement that is embedded within this using-statement.
        /// </summary>
        private Statement embeddedStatement;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the UsingStatement class.
        /// </summary>
        /// <param name="tokens">
        /// The list of tokens that form the statement.
        /// </param>
        /// <param name="resource">
        /// The resource acquisition expression declared in the using statement.
        /// </param>
        internal UsingStatement(CsTokenList tokens, Expression resource)
            : base(StatementType.Using, tokens)
        {
            Param.AssertNotNull(tokens, "tokens");
            Param.AssertNotNull(resource, "resource");

            this.resource = resource;
            this.AddExpression(resource);
        }

        #endregion

        #region Public Properties

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

        /// <summary>
        /// Gets the resource acquisition expression assigned to the obtained resource.
        /// </summary>
        public Expression Resource
        {
            get
            {
                return this.resource;
            }
        }

        #endregion
    }
}