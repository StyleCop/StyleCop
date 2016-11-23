// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NodeIndex.cs" company="https://github.com/StyleCop">
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
//   Describes the index of a node in the list.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// Describes the index of a node in the list.
    /// </summary>
    public struct NodeIndex
    {
        #region Constants

        /// <summary>
        /// The amount of space to leave between each node index.
        /// </summary>
        internal const int Spacer = 5;

        #endregion

        #region Fields

        /// <summary>
        /// The main part of the index.
        /// </summary>
        private int bigValue;

        /// <summary>
        /// The small part of the index.
        /// </summary>
        private short smallValue;

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Compares the two indexes and returns a standard comparison result.
        /// </summary>
        /// <param name="index1">
        /// The first index.
        /// </param>
        /// <param name="index2">
        /// The second index.
        /// </param>
        /// <returns>
        /// Returns a negative value if the first index is less than the second index, a positive
        /// value if the second index is greater than the first index, or zero if the two indexes are equal.
        /// </returns>
        public static int Compare(NodeIndex index1, NodeIndex index2)
        {
            Param.Ignore(index1, index2);

            if (index1 < index2)
            {
                return -1;
            }
            else if (index1 > index2)
            {
                return 1;
            }

            return 0;
        }

        /// <summary>
        /// Determines whether the two indexes are equal.
        /// </summary>
        /// <param name="index1">The first index.</param>
        /// <param name="index2">The second index.</param>
        /// <returns>Returns true if the indexes are equal.</returns>
        public static bool operator ==(NodeIndex index1, NodeIndex index2)
        {
            Param.Ignore(index1, index2);
            return index1.bigValue == index2.bigValue && index1.smallValue == index2.smallValue;
        }

        /// <summary>
        /// Determines whether the first index is greater than the second index.
        /// </summary>
        /// <param name="index1">The first index.</param>
        /// <param name="index2">The second index.</param>
        /// <returns>Returns true if the first index is greater than the second index.</returns>
        public static bool operator >(NodeIndex index1, NodeIndex index2)
        {
            Param.Ignore(index1, index2);
            return (index1.bigValue > index2.bigValue) || ((index1.bigValue == index2.bigValue) && (index1.smallValue > index2.smallValue));
        }

        /// <summary>
        /// Determines whether the first index is greater than or equal to the second index.
        /// </summary>
        /// <param name="index1">The first index.</param>
        /// <param name="index2">The second index.</param>
        /// <returns>Returns true if the first index is greater than or equal to the second index.</returns>
        public static bool operator >=(NodeIndex index1, NodeIndex index2)
        {
            Param.Ignore(index1, index2);
            return index1.bigValue >= index2.bigValue && index1.smallValue >= index2.smallValue;
        }

        /// <summary>
        /// Determines whether the two indexes are not equal.
        /// </summary>
        /// <param name="index1">The first index.</param>
        /// <param name="index2">The second index.</param>
        /// <returns>Returns true if the indexes are not equal.</returns>
        public static bool operator !=(NodeIndex index1, NodeIndex index2)
        {
            Param.Ignore(index1, index2);
            return index1.bigValue != index2.bigValue || index1.smallValue != index2.smallValue;
        }

        /// <summary>
        /// Determines whether the first index is less than the second index.
        /// </summary>
        /// <param name="index1">The first index.</param>
        /// <param name="index2">The second index.</param>
        /// <returns>Returns true if the first index is less than the second index.</returns>
        public static bool operator <(NodeIndex index1, NodeIndex index2)
        {
            Param.Ignore(index1, index2);
            return (index1.bigValue < index2.bigValue) || ((index1.bigValue == index2.bigValue) && (index1.smallValue < index2.smallValue));
        }

        /// <summary>
        /// Determines whether the first index is less than or equal to the second index.
        /// </summary>
        /// <param name="index1">The first index.</param>
        /// <param name="index2">The second index.</param>
        /// <returns>Returns true if the first index is less than or equal to the second index.</returns>
        public static bool operator <=(NodeIndex index1, NodeIndex index2)
        {
            Param.Ignore(index1, index2);
            return index1.bigValue <= index2.bigValue && index1.smallValue <= index2.smallValue;
        }

        /// <summary>
        /// Determines whether the index is equal to the given object.
        /// </summary>
        /// <param name="obj">
        /// The object to compare with.
        /// </param>
        /// <returns>
        /// Returns true if the object is equal to this index.
        /// </returns>
        public override bool Equals(object obj)
        {
            Param.Ignore(obj);

            if (obj == null)
            {
                return false;
            }

            try
            {
                NodeIndex index = (NodeIndex)obj;
                return this.bigValue == index.bigValue && this.smallValue == index.smallValue;
            }
            catch (InvalidCastException)
            {
                return false;
            }
        }

        /// <summary>
        /// Gets the hash code for the index.
        /// </summary>
        /// <returns>Returns the hash code for the index.</returns>
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        /// <summary>
        /// Gets the index as a string.
        /// </summary>
        /// <returns>Returns the index as a string.</returns>
        public override string ToString()
        {
            return this.bigValue + "." + this.smallValue;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Creates an index for a new node being inserted at the beginning of the list.
        /// </summary>
        /// <param name="before">
        /// The index of the previous node.
        /// </param>
        /// <param name="index">
        /// Returns the new index.
        /// </param>
        /// <returns>
        /// Returns true if the new index was created, or false if there are no more indexes.
        /// </returns>
        internal static bool CreateAfter(NodeIndex before, out NodeIndex index)
        {
            Param.Ignore(before);
            return Create(before.bigValue, before.smallValue, int.MaxValue, short.MaxValue, out index);
        }

        /// <summary>
        /// Creates an index for a new node being inserted at the beginning of the list.
        /// </summary>
        /// <param name="after">
        /// The index of the next node.
        /// </param>
        /// <param name="index">
        /// Returns the new index.
        /// </param>
        /// <returns>
        /// Returns true if the new index was created, or false if there are no more indexes.
        /// </returns>
        internal static bool CreateBefore(NodeIndex after, out NodeIndex index)
        {
            Param.Ignore(after);
            return Create(int.MinValue, short.MinValue, after.bigValue, after.smallValue, out index);
        }

        /// <summary>
        /// Creates an index for a new node being inserted into the middle of the list.
        /// </summary>
        /// <param name="before">
        /// The index of the previous node.
        /// </param>
        /// <param name="after">
        /// The index of the next node.
        /// </param>
        /// <param name="index">
        /// Returns the new index.
        /// </param>
        /// <returns>
        /// Returns true if the new index was created, or false if there are no more indexes.
        /// </returns>
        internal static bool CreateBetween(NodeIndex before, NodeIndex after, out NodeIndex index)
        {
            Param.Ignore(before, after);
            return Create(before.bigValue, before.smallValue, after.bigValue, after.smallValue, out index);
        }

        /// <summary>
        /// Creates an index for a new node which is the first node in the list.
        /// </summary>
        /// <param name="index">
        /// Returns the new index.
        /// </param>
        /// <returns>
        /// Returns true if the new index was created, or false if there are no more indexes.
        /// </returns>
        internal static bool CreateFirst(out NodeIndex index)
        {
            return Create(int.MinValue, short.MinValue, int.MaxValue, short.MaxValue, out index);
        }

        /// <summary>
        /// Sets the index to the given big value.
        /// </summary>
        /// <param name="newBigValue">
        /// The new big value.
        /// </param>
        internal void Set(int newBigValue)
        {
            Param.Ignore(newBigValue);

            this.bigValue = newBigValue;
            this.smallValue = 0;
        }

        /// <summary>
        /// Creates an index for a new node.
        /// </summary>
        /// <param name="previousBigValue">
        /// The big value of the previous node.
        /// </param>
        /// <param name="previousSmallValue">
        /// The small value of the previous node.
        /// </param>
        /// <param name="nextBigValue">
        /// The big value of the next node.
        /// </param>
        /// <param name="nextSmallValue">
        /// The small value of the next node.
        /// </param>
        /// <param name="index">
        /// Returns the new index.
        /// </param>
        /// <returns>
        /// Returns true if the new index was created, or false if there are no more indexes.
        /// </returns>
        private static bool Create(int previousBigValue, short previousSmallValue, int nextBigValue, short nextSmallValue, out NodeIndex index)
        {
            Param.Ignore(previousBigValue, previousSmallValue, nextBigValue, nextSmallValue);

            // Validate the conditions we allow.
            Debug.Assert(
                (previousBigValue < nextBigValue) || ((previousBigValue == nextBigValue) && (previousSmallValue < nextSmallValue))
                || ((previousBigValue == nextSmallValue) && (previousSmallValue == nextSmallValue)), 
                "The values are not allowed.");

            int bigValue;
            short smallValue;

            index = new NodeIndex();

            // Check whether the indexes are the same up to the small value.
            if (previousBigValue == nextBigValue)
            {
                bigValue = previousBigValue;

                if (!CreateSmallValue(previousSmallValue, nextSmallValue, out smallValue))
                {
                    return false;
                }
            }
            else
            {
                if (CreateBigValue(previousBigValue, nextBigValue, out bigValue))
                {
                    smallValue = 0;
                }
                else if (bigValue == previousBigValue)
                {
                    if (!CreateSmallValue(previousSmallValue, nextSmallValue, out smallValue))
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            index.bigValue = bigValue;
            index.smallValue = smallValue;

            return true;
        }

        /// <summary>
        /// Creates a new big value between the two given values.
        /// </summary>
        /// <param name="previous">
        /// The previous big value.
        /// </param>
        /// <param name="next">
        /// The next big value.
        /// </param>
        /// <param name="bigValue">
        /// Returns the new big value.
        /// </param>
        /// <returns>
        /// Returns false if it was not possible to create a new big value.
        /// </returns>
        private static bool CreateBigValue(int previous, int next, out int bigValue)
        {
            Param.Ignore(previous, next);

            bigValue = 0;

            if (previous == next)
            {
                return false;
            }

            // The algorithm to use depends on where this node is in relation to other 
            // nodes in the list.
            if (previous == int.MinValue)
            {
                if (next == int.MaxValue)
                {
                    // This is the first item in the list. Set it in the middle of the index range.
                    bigValue = 0;
                }
                else
                {
                    // This is the first node in the list. Space it off from the next node.
                    int spacer = (next - int.MinValue < Spacer + 1) ? next - int.MinValue : Spacer + 1;
                    if (spacer <= 0)
                    {
                        return false;
                    }

                    bigValue = next - spacer;
                }
            }
            else if (next == int.MaxValue)
            {
                // This is the last node in the list. Space it off from the previous node.
                int spacer = (int.MaxValue - previous < Spacer + 1) ? int.MaxValue - previous : Spacer + 1;
                if (spacer <= 0)
                {
                    return false;
                }

                bigValue = previous + spacer;
            }
            else
            {
                // This node is placed between two existing nodes. Center it between the two nodes.
                bigValue = previous + ((next - previous) / 2);
                if (bigValue == previous || bigValue == next)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Creates a new small value between the two given values.
        /// </summary>
        /// <param name="previous">
        /// The previous small value.
        /// </param>
        /// <param name="next">
        /// The next small value.
        /// </param>
        /// <param name="smallValue">
        /// Returns the new small value.
        /// </param>
        /// <returns>
        /// Returns false if it was not possible to create a new small value.
        /// </returns>
        private static bool CreateSmallValue(short previous, short next, out short smallValue)
        {
            Param.Ignore(previous, next);

            smallValue = 0;

            if (previous == next)
            {
                return false;
            }

            // The algorithm to use depends on where this node is in relation to other 
            // nodes in the list.
            if (previous == short.MinValue)
            {
                if (next == short.MaxValue)
                {
                    // This is the first item in the list. Set it in the middle of the index range.
                    smallValue = 0;
                }
                else
                {
                    // This is the first node in the list. Space it off from the next node.
                    short spacer = (next - short.MinValue < Spacer + 1) ? (short)(next - short.MinValue) : (short)(Spacer + 1);
                    if (spacer <= 0)
                    {
                        return false;
                    }

                    smallValue = (short)(next - spacer);
                }
            }
            else if (next == short.MaxValue)
            {
                // This is the last node in the list. Space it off from the previous node.
                short spacer = (short.MaxValue - previous < Spacer + 1) ? (short)(short.MaxValue - previous) : (short)(Spacer + 1);
                if (spacer <= 0)
                {
                    return false;
                }

                smallValue = (short)(previous + spacer);
            }
            else
            {
                // This node is placed between two existing nodes. Center it between the two nodes.
                smallValue = (short)((next - previous) / 2);
                if (smallValue == previous || smallValue == next)
                {
                    return false;
                }
            }

            return true;
        }

        #endregion
    }
}