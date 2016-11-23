// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QueryOrderByClause.cs" company="https://github.com/StyleCop">
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
//   Describes a order-by clause in a query expression.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    using System.Collections.Generic;

    /// <summary>
    /// Describes a order-by clause in a query expression.
    /// </summary>
    public sealed class QueryOrderByClause : QueryClause
    {
        #region Fields

        /// <summary>
        /// The list of orderings.
        /// </summary>
        private readonly QueryOrderByOrdering[] orderings;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the QueryOrderByClause class.
        /// </summary>
        /// <param name="tokens">
        /// The list of tokens that form the clause.
        /// </param>
        /// <param name="orderings">
        /// The collection of orderings in the clause.
        /// </param>
        internal QueryOrderByClause(CsTokenList tokens, ICollection<QueryOrderByOrdering> orderings)
            : base(QueryClauseType.OrderBy, tokens)
        {
            Param.AssertNotNull(tokens, "tokens");
            Param.AssertNotNull(orderings, "orderings");

            this.orderings = new QueryOrderByOrdering[orderings.Count];

            int i = 0;
            foreach (QueryOrderByOrdering ordering in orderings)
            {
                this.orderings[i++] = ordering;
                this.AddExpression(ordering.Expression);
            }
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the collection of orderings in the clause.
        /// </summary>
        public ICollection<QueryOrderByOrdering> Orderings
        {
            get
            {
                return this.orderings;
            }
        }

        #endregion
    }
}