// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemList.cs" company="https://github.com/StyleCop">
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
//   A list of items that points into a <see cref="MasterList" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// A list of items that points into a <see cref="MasterList"/>.
    /// </summary>
    /// <typeparam name="T">
    /// The type of item stored in the list.
    /// </typeparam>
    [SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix", Justification = "The class stores a linked list.")]
    public class ItemList<T> : INodeList<T>, IEnumerable<T>
        where T : class
    {
        #region Fields

        /// <summary>
        /// The master list that this list points into.
        /// </summary>
        private readonly MasterList<T> masterList;

        /// <summary>
        /// The first item in the master list.
        /// </summary>
        private Node<T> firstItem;

        /// <summary>
        /// The last item in the master list.
        /// </summary>
        private Node<T> lastItem;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ItemList{T}"/> class. 
        /// Initializes a new instance of the ItemList class.
        /// </summary>
        /// <param name="masterList">
        /// The master list that this list points into.
        /// </param>
        public ItemList(MasterList<T> masterList)
        {
            Param.RequireNotNull(masterList, "masterList");
            this.masterList = masterList;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ItemList{T}"/> class. 
        /// Initializes a new instance of the ItemList class.
        /// </summary>
        /// <param name="masterList">
        /// The master list that this list points into.
        /// </param>
        /// <param name="firstItem">
        /// The first item in the master list.
        /// </param>
        /// <param name="lastItem">
        /// The last item in the master list.
        /// </param>
        public ItemList(MasterList<T> masterList, Node<T> firstItem, Node<T> lastItem)
        {
            Param.RequireNotNull(masterList, "masterList");
            Param.RequireNotNull(firstItem, "firstItem");
            Param.RequireNotNull(lastItem, "lastItem");

            this.masterList = masterList.AsReadWrite;
            this.firstItem = firstItem;
            this.lastItem = lastItem;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the first item in the list.
        /// </summary>
        public Node<T> First
        {
            get
            {
                return this.firstItem;
            }

            protected set
            {
                this.firstItem = value;
            }
        }

        /// <summary>
        /// Gets or sets the last item in the list.
        /// </summary>
        public Node<T> Last
        {
            get
            {
                return this.lastItem;
            }

            protected set
            {
                this.lastItem = value;
            }
        }

        /// <summary>
        /// Gets the master list that contains this list.
        /// </summary>
        public MasterList<T> MasterList
        {
            get
            {
                return this.masterList.AsReadOnly;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Creates a copy of this list.
        /// </summary>
        /// <returns>Returns the copy.</returns>
        public virtual ItemList<T> Clone()
        {
            return new ItemList<T>(this.masterList, this.firstItem, this.lastItem);
        }

        /// <summary>
        /// Gets an iterator for enumerating forward through the items in the list.
        /// </summary>
        /// <returns>Returns the enumerable object.</returns>
        public IEnumerable<T> ForwardIterator()
        {
            return new LinkedItemListEnumerators<T>.ForwardValueEnumerable(this.firstItem, this.lastItem);
        }

        /// <summary>
        /// Gets an iterator for enumerating forward through the items in the list.
        /// </summary>
        /// <param name="start">
        /// The start position of the iterator.
        /// </param>
        /// <returns>
        /// Returns the enumerable object.
        /// </returns>
        public IEnumerable<T> ForwardIterator(Node<T> start)
        {
            Param.Ignore(start);

            if (this.IsAfterLast(start))
            {
                return new T[] { };
            }

            return new LinkedItemListEnumerators<T>.ForwardValueEnumerable(start, this.lastItem);
        }

        /// <summary>
        /// Gets an iterator for enumerating forward through the nodes in the list.
        /// </summary>
        /// <returns>Returns the enumerable object.</returns>
        public IEnumerable<Node<T>> ForwardNodeIterator()
        {
            return new LinkedItemListEnumerators<T>.ForwardNodeEnumerable(this.firstItem, this.lastItem);
        }

        /// <summary>
        /// Gets an iterator for enumerating forward through the nodes in the list.
        /// </summary>
        /// <param name="start">
        /// The start position of the iterator.
        /// </param>
        /// <returns>
        /// Returns the enumerable object.
        /// </returns>
        public IEnumerable<Node<T>> ForwardNodeIterator(Node<T> start)
        {
            Param.Ignore(start);

            if (this.IsAfterLast(start))
            {
                return new Node<T>[] { };
            }

            return new LinkedItemListEnumerators<T>.ForwardNodeEnumerable(start, this.lastItem);
        }

        /// <summary>
        /// Gets an enumerator for walking through the items in the list.
        /// </summary>
        /// <returns>Returns the enumerator.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return new LinkedItemListEnumerators<T>.ForwardValueEnumerator(this.firstItem, this.lastItem);
        }

        /// <summary>
        /// Determines whether the given node is beyond the bounds of the list.
        /// </summary>
        /// <param name="node">
        /// The node to check.
        /// </param>
        /// <returns>
        /// Returns true if the node is beyond the bounds of the list.
        /// </returns>
        /// <remarks>
        /// This method only checks the nodes one step beyond the bounds of the list.
        /// If the node is more than one step beyond the bounds of the list, this method
        /// will still return true.
        /// </remarks>
        public bool OutOfBounds(Node<T> node)
        {
            Param.Ignore(node);

            if (node == null || this.firstItem == null || this.lastItem == null)
            {
                return true;
            }

            return node.Index < this.firstItem.Index || node.Index > this.lastItem.Index;
        }

        /// <summary>
        /// Gets an iterator for enumerating backwards through the items in the list.
        /// </summary>
        /// <returns>Returns the enumerable object.</returns>
        public IEnumerable<T> ReverseIterator()
        {
            return new LinkedItemListEnumerators<T>.BackwardValueEnumerable(this.lastItem, this.firstItem);
        }

        /// <summary>
        /// Gets an iterator for enumerating backwards through the items in the list.
        /// </summary>
        /// <param name="start">
        /// The start position of the iterator.
        /// </param>
        /// <returns>
        /// Returns the enumerable object.
        /// </returns>
        public IEnumerable<T> ReverseIterator(Node<T> start)
        {
            Param.Ignore(start);

            if (this.IsBeforeFirst(start))
            {
                return new T[] { };
            }

            return new LinkedItemListEnumerators<T>.BackwardValueEnumerable(start, this.firstItem);
        }

        /// <summary>
        /// Gets an iterator for enumerating backwards through the nodes in the list.
        /// </summary>
        /// <returns>Returns the enumerable object.</returns>
        public IEnumerable<Node<T>> ReverseNodeIterator()
        {
            return new LinkedItemListEnumerators<T>.BackwardNodeEnumerable(this.lastItem, this.firstItem);
        }

        /// <summary>
        /// Gets an iterator for enumerating backwards through the nodes in the list.
        /// </summary>
        /// <param name="start">
        /// The start position of the iterator.
        /// </param>
        /// <returns>
        /// Returns the enumerable object.
        /// </returns>
        public IEnumerable<Node<T>> ReverseNodeIterator(Node<T> start)
        {
            Param.Ignore(start);

            if (this.IsBeforeFirst(start))
            {
                return new Node<T>[] { };
            }

            return new LinkedItemListEnumerators<T>.BackwardNodeEnumerable(start, this.firstItem);
        }

        #endregion

        #region Explicit Interface Methods

        /// <summary>
        /// Gets an enumerator for walking through the items in the list.
        /// </summary>
        /// <returns>Returns the enumerator.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Determines whether the given node comes after the last node in this list.
        /// </summary>
        /// <param name="node">
        /// The node to check.
        /// </param>
        /// <returns>
        /// Returns true if the given node comes after the last node in this list.
        /// </returns>
        private bool IsAfterLast(Node<T> node)
        {
            Param.Ignore(node);

            if (node == null || this.lastItem == null)
            {
                return true;
            }

            return node.Index > this.lastItem.Index;
        }

        /// <summary>
        /// Determines whether the given node comes before the first node in this list.
        /// </summary>
        /// <param name="node">
        /// The node to check.
        /// </param>
        /// <returns>
        /// Returns true if the given node comes before the first node in this list.
        /// </returns>
        private bool IsBeforeFirst(Node<T> node)
        {
            Param.Ignore(node);

            if (node == null || this.firstItem == null)
            {
                return true;
            }

            return node.Index < this.firstItem.Index;
        }

        #endregion
    }
}