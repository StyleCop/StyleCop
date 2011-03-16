//-----------------------------------------------------------------------
// <copyright file="QueryOrderByClause.cs">
//     MS-PL
// </copyright>
// <license>
//   This source code is subject to terms and conditions of the Microsoft 
//   Public License. A copy of the license can be found in the License.html 
//   file at the root of this distribution. 
//   By using this source code in any fashion, you are agreeing to be bound 
//   by the terms of the Microsoft Public License. You must not remove this 
//   notice, or any other, from this software.
// </license>
//-----------------------------------------------------------------------
namespace StyleCop.CSharp.CodeModel
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
        /// <returns>Returns true if the items are equal.</returns>
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
        private CodeUnitProperty<ICollection<QueryOrderByOrdering>> orderings;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the QueryOrderByClause class.
        /// </summary>
        /// <param name="proxy">Proxy object for the clause.</param>
        /// <param name="orderings">The collection of orderings in the clause.</param>
        internal QueryOrderByClause(CodeUnitProxy proxy, ICollection<QueryOrderByOrdering> orderings)
            : base(proxy, QueryClauseType.OrderBy)
        {
            Param.AssertNotNull(proxy, "proxy");
            Param.AssertNotNull(orderings, "orderings");

            this.orderings.Value = orderings;
            CsLanguageService.Debug.Assert(orderings.IsReadOnly, "Must be a read only collection.");
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
                this.ValidateEditVersion();

                if (!this.orderings.Initialized)
                {
                    List<QueryOrderByOrdering> list = new List<QueryOrderByOrdering>();

                    Expression orderingExpression = this.FindFirstChildExpression();
                    while (orderingExpression != null)
                    {
                        CodeUnit position = orderingExpression;

                        QueryOrderByOrdering ordering = new QueryOrderByOrdering();
                        ordering.Expression = orderingExpression;

                        // Check for a possible ascending or descending keyword.
                        for (CodeUnit c = position.FindNextSibling(); c != null; c = c.FindNextSibling())
                        {
                            if (c.Is(TokenType.Ascending))
                            {
                                ordering.Direction = QueryOrderByDirection.Ascending;
                                position = c;
                                break;
                            }
                            else if (c.Is(TokenType.Descending))
                            {
                                ordering.Direction = QueryOrderByDirection.Descending;
                                position = c;
                                break;
                            }
                            else if (!c.Is(CodeUnitType.LexicalElement) || c.Is(LexicalElementType.Token))
                            {
                                break;
                            }
                        }

                        list.Add(ordering);

                        // Look for a comma next.
                        orderingExpression = null;
                        for (CodeUnit c = position.FindNextSibling(); c != null; c = c.FindNextSibling())
                        {
                            if (c.Is(TokenType.Comma))
                            {
                                orderingExpression = c.FindNextSiblingExpression();
                                break;
                            }
                            else if (!c.Is(CodeUnitType.LexicalElement) || c.Is(LexicalElementType.Token))
                            {
                                break;
                            }
                        }
                    }

                    this.orderings.Value = list.AsReadOnly();
                }

                return this.orderings.Value;
            }
        }

        #endregion Public Properties

        #region Protected Override Methods

        /// <summary>
        /// Resets the contents of the class.
        /// </summary>
        protected override void Reset()
        {
            base.Reset();

            this.orderings.Reset();
        }

        #endregion Protected Override Methods
    }
}
