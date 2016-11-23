// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MasterList{T}.cs" company="https://github.com/StyleCop">
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
//   A master list of items.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// A master list of items.
    /// </summary>
    /// <typeparam name="T">
    /// The type of item stored in the list.
    /// </typeparam>
    [SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix", Justification = "The class stores linked list of items.")]
    public class MasterList<T> : INodeList<T>, ICollection<T>
        where T : class
    {
        #region Static Fields

        /// <summary>
        /// An empty master list.
        /// </summary>
        [SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "Represents an empty list.")]
        [SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes", Justification = "Represents an empty list.")]
        public static readonly MasterList<T> Empty = new MasterList<T>(true);

        #endregion

        #region Fields

        /// <summary>
        /// The internal list.
        /// </summary>
        private readonly LinkedItemList<T> list = new LinkedItemList<T>();

        /// <summary>
        /// Indicates whether the list is read-only.
        /// </summary>
        private readonly bool readOnly;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MasterList{T}"/> class. 
        /// Initializes a new instance of the MasterList class.
        /// </summary>
        public MasterList()
        {
            this.list.NodeIndexesReset += this.ListNodeIndexesReset;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MasterList{T}"/> class. 
        /// Initializes a new instance of the MasterList class.
        /// </summary>
        /// <param name="items">
        /// The initial list.
        /// </param>
        public MasterList(ICollection<T> items)
            : this()
        {
            Param.RequireNotNull(items, "items");
            this.list.AddRange(items);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MasterList{T}"/> class. 
        /// Initializes a new instance of the MasterList class.
        /// </summary>
        /// <param name="readOnly">
        /// Indicates whether the collection is read-only.
        /// </param>
        private MasterList(bool readOnly)
            : this()
        {
            Param.Ignore(readOnly);
            this.readOnly = readOnly;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MasterList{T}"/> class. 
        /// Initializes a new instance of the MasterList class.
        /// </summary>
        /// <param name="innerList">
        /// The inner list to wrap in this object.
        /// </param>
        /// <param name="readOnly">
        /// Indicates whether the collection is read-only.
        /// </param>
        private MasterList(LinkedItemList<T> innerList, bool readOnly)
        {
            Param.AssertNotNull(innerList, "innerList");
            Param.Ignore(readOnly);

            this.list = innerList;
            this.readOnly = readOnly;
        }

        #endregion

        #region Public Events

        /// <summary>
        /// Event that is fired when the node indexes are reset.
        /// </summary>
        public event EventHandler NodeIndexesReset;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets a read-only version of the list.
        /// </summary>
        public MasterList<T> AsReadOnly
        {
            get
            {
                if (this.readOnly)
                {
                    return this;
                }

                return new MasterList<T>(this.list, true);
            }
        }

        /// <summary>
        /// Gets the number of nodes in the collection.
        /// </summary>
        public int Count
        {
            get
            {
                return this.list.Count;
            }
        }

        /// <summary>
        /// Gets the first item in the list.
        /// </summary>
        public Node<T> First
        {
            get
            {
                return this.list.First;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the list is read-only.
        /// </summary>
        public bool IsReadOnly
        {
            get
            {
                return this.readOnly;
            }
        }

        /// <summary>
        /// Gets the last item in the list.
        /// </summary>
        public Node<T> Last
        {
            get
            {
                return this.list.Last;
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets a read-write version of the list.
        /// </summary>
        internal MasterList<T> AsReadWrite
        {
            get
            {
                if (!this.readOnly)
                {
                    return this;
                }

                return new MasterList<T>(this.list, false);
            }
        }

        /// <summary>
        /// Gets the inner list wrapped by this class.
        /// </summary>
        internal LinkedItemList<T> InnerList
        {
            get
            {
                return this.list;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Adds a item to the collection.
        /// </summary>
        /// <param name="item">
        /// The item to add to the collection.
        /// </param>
        public virtual void Add(T item)
        {
            Param.RequireNotNull(item, "item");

            if (this.readOnly)
            {
                throw new NotSupportedException(Strings.ReadOnlyCollection);
            }

            this.InsertLast(item);
        }

        /// <summary>
        /// Adds the range of items to the collection.
        /// </summary>
        /// <param name="items">
        /// The range of items to add.
        /// </param>
        public virtual void AddRange(IEnumerable<T> items)
        {
            Param.Ignore(items);

            if (this.readOnly)
            {
                throw new NotSupportedException(Strings.ReadOnlyCollection);
            }

            this.list.AddRange(items);
        }

        /// <summary>
        /// Clears the contents of the list.
        /// </summary>
        public virtual void Clear()
        {
            if (this.readOnly)
            {
                throw new NotSupportedException(Strings.ReadOnlyCollection);
            }

            this.list.Clear();
        }

        /// <summary>
        /// Determines whether the given item is contained within the list.
        /// </summary>
        /// <param name="item">
        /// The item to search for.
        /// </param>
        /// <returns>
        /// Returns true if the item is contained within the list.
        /// </returns>
        public bool Contains(T item)
        {
            Param.Ignore(item);
            return this.list.Contains(item);
        }

        /// <summary>
        /// Copies the entire collection to the given array, starting at the specified index of the target array.
        /// </summary>
        /// <param name="array">
        /// The array that is the destination of the nodes copied from the collection.
        /// </param>
        /// <param name="arrayIndex">
        /// The zero-based index in array at which copying begins.
        /// </param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            Param.Ignore(array, arrayIndex);
            this.list.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Gets an iterator for enumerating forward through the items in the list.
        /// </summary>
        /// <returns>Returns the enumerable object.</returns>
        public IEnumerable<T> ForwardIterator()
        {
            return this.list.ForwardIterator();
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

            return this.list.ForwardIterator(start);
        }

        /// <summary>
        /// Gets an iterator for enumerating forward through the nodes in the list.
        /// </summary>
        /// <returns>Returns the enumerable object.</returns>
        public IEnumerable<Node<T>> ForwardNodeIterator()
        {
            return this.list.ForwardNodeIterator();
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

            return this.list.ForwardNodeIterator(start);
        }

        /// <summary>
        /// Gets an enumerator that iterates through the nodes in the collection.
        /// </summary>
        /// <returns>Returns an enumerator that iterates through the nodes in the collection.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return this.list.GetEnumerator();
        }

        /// <summary>
        /// Inserts a item into the list after the given node.
        /// </summary>
        /// <param name="item">
        /// The item to insert.
        /// </param>
        /// <param name="nodeToInsertAfter">
        /// The node to insert the item after.
        /// </param>
        /// <returns>
        /// Returns the new node.
        /// </returns>
        public virtual Node<T> InsertAfter(T item, Node<T> nodeToInsertAfter)
        {
            Param.RequireNotNull(item, "item");
            Param.Ignore(nodeToInsertAfter);

            if (this.readOnly)
            {
                throw new NotSupportedException(Strings.ReadOnlyCollection);
            }

            Node<T> node = this.list.InsertAfter(item, nodeToInsertAfter);

            return node;
        }

        /// <summary>
        /// Inserts a node into the list before the given node.
        /// </summary>
        /// <param name="item">
        /// The item to insert.
        /// </param>
        /// <param name="nodeToInsertBefore">
        /// The node to insert the item before.
        /// </param>
        /// <returns>
        /// Returns the new node.
        /// </returns>
        public virtual Node<T> InsertBefore(T item, Node<T> nodeToInsertBefore)
        {
            Param.RequireNotNull(item, "item");
            Param.Ignore(nodeToInsertBefore);

            if (this.readOnly)
            {
                throw new NotSupportedException(Strings.ReadOnlyCollection);
            }

            Node<T> node = this.list.InsertBefore(item, nodeToInsertBefore);
            return node;
        }

        /// <summary>
        /// Inserts the specified item at the beginning of the list.
        /// </summary>
        /// <param name="item">
        /// The item to insert.
        /// </param>
        /// <returns>
        /// Returns the new node.
        /// </returns>
        public virtual Node<T> InsertFirst(T item)
        {
            Param.RequireNotNull(item, "item");

            if (this.readOnly)
            {
                throw new NotSupportedException(Strings.ReadOnlyCollection);
            }

            return this.list.InsertFirst(item);
        }

        /// <summary>
        /// Inserts the specified item at the end of the list.
        /// </summary>
        /// <param name="item">
        /// The item to insert.
        /// </param>
        /// <returns>
        /// Returns the new node.
        /// </returns>
        public virtual Node<T> InsertLast(T item)
        {
            Param.RequireNotNull(item, "item");

            if (this.readOnly)
            {
                throw new NotSupportedException(Strings.ReadOnlyCollection);
            }

            return this.list.InsertLast(item);
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
        public bool OutOfBounds(Node<T> node)
        {
            Param.Ignore(node);

            // In a MasterList, the only test for out-of-bounds is whether the node is null.
            // Otherwise, all nodes are considered to be members of the list.
            return node == null;
        }

        /// <summary>
        /// Removes the given item from the list.
        /// </summary>
        /// <param name="item">
        /// The item to remove from the list.
        /// </param>
        /// <returns>
        /// Return true if the item was removed from the list.
        /// </returns>
        /// <remarks>
        /// This method is inefficient as it must iterate the list to find the node to remove.
        /// </remarks>
        public virtual bool Remove(T item)
        {
            Param.RequireNotNull(item, "item");

            if (this.readOnly)
            {
                throw new NotSupportedException(Strings.ReadOnlyCollection);
            }

            for (Node<T> node = this.First; node != null; node = node.Next)
            {
                if (node.Value == item)
                {
                    return this.Remove(node);
                }
            }

            return false;
        }

        /// <summary>
        /// Removes the given item from the list.
        /// </summary>
        /// <param name="node">
        /// The item to remove from the list.
        /// </param>
        /// <returns>
        /// Return true if the item was removed from the list.
        /// </returns>
        public virtual bool Remove(Node<T> node)
        {
            Param.Ignore(node);

            if (this.readOnly)
            {
                throw new NotSupportedException(Strings.ReadOnlyCollection);
            }

            return this.list.Remove(node);
        }

        /// <summary>
        /// Removes the given range of items from the list.
        /// </summary>
        /// <param name="startNode">
        /// The first item to remove.
        /// </param>
        /// <param name="endNode">
        /// The last item to remove.
        /// </param>
        /// <remarks>
        /// This method assumes that both the start item and the end item are items in this list,
        /// and that the start item appears before the end item in the list. These assumptions are not
        /// verified, so use this method with care.
        /// </remarks>
        public virtual void RemoveRange(Node<T> startNode, Node<T> endNode)
        {
            Param.Ignore(startNode, endNode);

            if (this.readOnly)
            {
                throw new NotSupportedException(Strings.ReadOnlyCollection);
            }

            if ((startNode == null && endNode != null) || (startNode != null && endNode == null))
            {
                throw new ArgumentException(Strings.BothItemsMustBeNullOrNonNull);
            }

            this.list.RemoveRange(startNode, endNode);
        }

        /// <summary>
        /// Removes the given node from the list and replaces it with a different node.
        /// </summary>
        /// <param name="node">
        /// The node to remove.
        /// </param>
        /// <param name="newItem">
        /// The replacement item.
        /// </param>
        /// <returns>
        /// Returns the new node for the replacement item.
        /// </returns>
        public virtual Node<T> Replace(Node<T> node, T newItem)
        {
            Param.RequireNotNull(node, "node");
            Param.RequireNotNull(newItem, "newItem");

            return this.list.Replace(node, newItem);
        }

        /// <summary>
        /// Gets an iterator for enumerating backwards through the items in the list.
        /// </summary>
        /// <returns>Returns the enumerable object.</returns>
        public IEnumerable<T> ReverseIterator()
        {
            return this.list.ReverseIterator();
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

            return this.list.ReverseIterator(start);
        }

        /// <summary>
        /// Gets an iterator for enumerating backwards through the nodes in the list.
        /// </summary>
        /// <returns>Returns the enumerable object.</returns>
        public IEnumerable<Node<T>> ReverseNodeIterator()
        {
            return this.list.ReverseNodeIterator();
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

            return this.list.ReverseNodeIterator(start);
        }

        #endregion

        #region Explicit Interface Methods

        /// <summary>
        /// Gets an enumerator that iterates through the nodes in the collection.
        /// </summary>
        /// <returns>Returns an enumerator that iterates through the nodes in the collection.</returns>
        IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.list.GetEnumerator();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Called when the node indexes are reset.
        /// </summary>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        protected virtual void OnNodeIndexesReset(EventArgs e)
        {
            Param.RequireNotNull(e, "e");

            // Make sure we cache the delegate locally to avoid other threads unsubscribing before we call them.
            // See http://piers7.blogspot.com/2010/03/3-races-with-net-events.html for info.
            EventHandler handlers = this.NodeIndexesReset;

            if (handlers != null)
            {
                handlers(this, e);
            }
        }

        /// <summary>
        /// Called when the node indexes are reset within the inner list.
        /// </summary>
        /// <param name="sender">
        /// The event sender.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private void ListNodeIndexesReset(object sender, EventArgs e)
        {
            Param.Ignore(sender, e);
            this.OnNodeIndexesReset(e);
        }

        #endregion
    }
}