//-----------------------------------------------------------------------
// <copyright file="QueryLetClause.cs">
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

    /// <summary>
    /// Describes a let clause in a query expression.
    /// </summary>
    public sealed class QueryLetClause : QueryClauseWithExpression
    {
        #region Private Fields

        /// <summary>
        /// The variable that ranges over the values in the query result.
        /// </summary>
        private Variable rangeVariable;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the QueryLetClause class.
        /// </summary>
        /// <param name="tokens">The list of tokens that form the clause.</param>
        /// <param name="rangeVariable">The variable that ranges over the values in the query result.</param>
        /// <param name="expression">The range expression.</param>
        internal QueryLetClause(CsTokenList tokens, Variable rangeVariable, Expression expression)
            : base(QueryClauseType.Let, tokens, expression)
        {
            Param.AssertNotNull(tokens, "tokens");
            Param.AssertNotNull(rangeVariable, "rangeVariable");
            Param.AssertNotNull(expression, "expression");

            this.rangeVariable = rangeVariable;
        }

        #endregion Internal Constructors

        #region Public Properties

        /// <summary>
        /// Gets the variable that ranges over the values in the query result.
        /// </summary>
        public Variable RangeVariable
        {
            get
            {
                return this.rangeVariable;
            }
        }

        #endregion Public Properties
    }
}
