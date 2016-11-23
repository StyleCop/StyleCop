// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QueryOrderByOrdering.cs" company="https://github.com/StyleCop">
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
//   An individual ordering statement.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    /// <summary>
    /// An individual ordering statement.
    /// </summary>
    public struct QueryOrderByOrdering
    {
        #region Fields

        /// <summary>
        /// The ordering direction.
        /// </summary>
        private QueryOrderByDirection direction;

        /// <summary>
        /// The ordering expression.
        /// </summary>
        private Expression expression;

        #endregion

        #region Public Properties

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

        #endregion

        #region Public Methods and Operators

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
        /// Determines whether the two items are not equal.
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
        /// <param name="obj">
        /// The object to compare against.
        /// </param>
        /// <returns>
        /// Returns true if the objects are equal.
        /// </returns>
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

        #endregion
    }
}