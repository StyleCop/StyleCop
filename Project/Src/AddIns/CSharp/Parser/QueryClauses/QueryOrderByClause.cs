//-----------------------------------------------------------------------
// <copyright file="QueryOrderByClause.cs">
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
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// The various direction types for an order-by query.
    /// </summary>
    public enum QueryOrderByDirection
    {
        /// <summary>
        /// Undefined order.
        /// </summary>
        Undefined,

        /// <summary>
        /// Ascending order.
        /// </summary>
        Ascending,

        /// <summary>
        /// Descending order.
        /// </summary>
        Descending
    }

    /// <summary>
    /// An individual ordering statement.
    /// </summary>
    public struct QueryOrderByOrdering
    {
        /// <summary>
        /// The ordering direction.
        /// </summary>
        private QueryOrderByDirection direction;

        /// <summary>
        /// The ordering expression.
        /// </summary>
        private Expression expression;

        /// <summary>
        /// Gets or sets the ordering direction.
        /// </summary>
        public QueryOrderByDirection Direction
        {
            get
            {
                return this.direction;
            }

            set
            {
                Param.Ignore(value);
                this.direction = value;
            }
        }

        /// <summary>
        /// Gets or sets the ordering expression.
        /// </summary>
        public Expression Expression
        {
            get
            {
                return this.expression;
            }

            set
            {
                Param.Ignore(value);
                this.expression = value;
            }
        }

        /// <summary>
        /// Determines whether the two items are equal.
        /// </summary>
        /// <param name="item1">The first item.</param>
        /// <param name="item2">The second item.</param>
        /// <returns>Returns true if the items are equal</returns>
        public static bool operator ==(QueryOrderByOrdering item1, QueryOrderByOrdering item2)
        {
            Param.Ignore(item1, item2);
            return item1.Expression == item2.Expression && item1.Direction == item2.Direction;
        }

        /// <summary>
        /// Determines whether the two items are inequal.
        /// </summary>
        /// <param name="item1">The first item.</param>
        /// <param name="item2">The second item.</param>
        /// <returns>Returns true if the items are not equal.</returns>
        public static bool operator !=(QueryOrderByOrdering item1, QueryOrderByOrdering item2)
        {
            Param.Ignore(item1, item2);
            return item1.Expression != item2.Expression || item1.Direction != item2.Direction;
        }

        /// <summary>
        /// Determines whether this value is equal to the given object.
        /// </summary>
        /// <param name="obj">The object to compare against.</param>
        /// <returns>Returns true if the objects are equal.</returns>
        public override bool Equals(object obj)
        {
            Param.Ignore(obj);

            if (obj == null)
            {
                return false;
            }

            QueryOrderByOrdering item = (QueryOrderByOrdering)obj;
            return item.Expression == this.expression && item.Direction == this.direction;
        }

        /// <summary>
        /// Gets a unique hash code for the item.
        /// </summary>
        /// <returns>Returns the hash code.</returns>
        public override int GetHashCode()
        {
            return this.expression.GetHashCode() ^ this.direction.GetHashCode();
        }
    }

    /// <summary>
    /// Describes a order-by clause in a query expression.
    /// </summary>
    public sealed class QueryOrderByClause : QueryClause
    {
        #region Private Fields

        /// <summary>
        /// The list of orderings.
        /// </summary>
        private QueryOrderByOrdering[] orderings;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the QueryOrderByClause class.
        /// </summary>
        /// <param name="tokens">The list of tokens that form the clause.</param>
        /// <param name="orderings">The collection of orderings in the clause.</param>
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

        #endregion Internal Constructors

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

        #endregion Public Properties
    }
}
