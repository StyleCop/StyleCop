//--------------------------------------------------------------------------
// <copyright file="LinkedItemList.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.
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
namespace Microsoft.StyleCop.CSharp.CodeModel.Collections
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Text;

    /// <summary>
    /// A doubly-linked list.
    /// </summary>
    /// <typeparam name="T">The type of item stored in the list.</typeparam>
    internal partial class LinkedItemList<T> : ICollection<T> where T : class, ILinkNode<T>
    {
        #region Private Fields

        /// <summary>
        /// The first node in the list.
        /// </summary>
        private T head;

        /// <summary>
        /// The last node in the list.
        /// </summary>
        private T tail;

        /// <summary>
        /// The number of items in the list.
        /// </summary>
        private int count;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the LinkedItemList class.
        /// </summary>
        internal LinkedItemList()
        {
        }

        #endregion Internal Constructors

        #region Public Properties

        /// <summary>
        /// Gets a value indicating whether the collection is read-only.
        /// </summary>
        public bool IsReadOnly
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Gets the first item in the list.
        /// </summary>
        public T First
        {
            get
            {
                return this.head;
            }
        }

        /// <summary>
        /// Gets the last item in the list.
        /// </summary>
        public T Last
        {
            get
            {
                return this.tail;
            }
        }

        /// <summary>
        /// Gets the number of items in the collection.
        /// </summary>
        public int Count
        {
            get
            {
                return this.count;
            }
        }

        #endregion Public Properties

        #region Public Virtual Methods

        /// <summary>
        /// Inserts a item into the list after the given item.
        /// </summary>
        /// <param name="node">The node to insert.</param>
        /// <param name="nodeToInsertAfter">The node to insert the item after.</param>
        public virtual void InsertAfter(T node, T nodeToInsertAfter)
        {
            Param.AssertNotNull(node, "node");
            Param.Ignore(nodeToInsertAfter);

            Debug.Assert(
                nodeToInsertAfter != null || this.head == null,
                "nodeToInsertAfter",
                "nodeToInsertAfter may only be null if the list is empty");

            // Check and set the containing list.
            if (node.LinkNode.ContainingList != null)
            {
                throw new ArgumentException("The node has already been inserted into a different collection.");
            }

            node.LinkNode.ContainingList = this;

            // First, check if the list is empty.
            if (this.head == null)
            {
                Debug.Assert(this.tail == null, "The head is null but the tail is not null");
                Debug.Assert(nodeToInsertAfter == null, "The head is null but nodeToInsertAfter is not null");
                Debug.Assert(this.Count == 0, "The list should be empty.");

                this.head = node;
                this.tail = node;
                node.LinkNode.Next = null;
                node.LinkNode.Previous = null;
            }
            else
            {
                Debug.Assert(this.tail != null, "Head is not null but tail is null");

                if (nodeToInsertAfter.Equals(this.tail))
                {
                    // The new node is going at the end of the list.
                    this.tail.LinkNode.Next = node;
                    node.LinkNode.Next = null;
                    node.LinkNode.Previous = this.tail;
                    this.tail = node;
                }
                else
                {
                    // The new node is going somewhere in the middle of the list.
                    Debug.Assert(nodeToInsertAfter.LinkNode.Next != null, "The node should be in the middle of the list, having a next node.");

                    nodeToInsertAfter.LinkNode.Next.LinkNode.Previous = node;
                    node.LinkNode.Next = nodeToInsertAfter.LinkNode.Next;
                    nodeToInsertAfter.LinkNode.Next = node;
                    node.LinkNode.Previous = nodeToInsertAfter;
                }
            }

            ++this.count;
        }

        /// <summary>
        /// Inserts a node into the list before the given item.
        /// </summary>
        /// <param name="node">The node to insert.</param>
        /// <param name="nodeToInsertBefore">The node to insert the item before.</param>
        public virtual void InsertBefore(T node, T nodeToInsertBefore)
        {
            Param.AssertNotNull(node, "node");
            Param.Ignore(nodeToInsertBefore);

            Debug.Assert(
                nodeToInsertBefore != null || this.head == null,
                "nodeToInsertBefore",
                "nodeToInsertBefore may only be null if the list is empty");

            // Check and set the containing list.
            if (node.LinkNode.ContainingList != null)
            {
                throw new ArgumentException("The node has already been inserted into a different collection.");
            }

            node.LinkNode.ContainingList = this;

            // First, check if the list is empty.
            if (this.head == null)
            {
                Debug.Assert(this.tail == null, "The head is null but the tail is not null");
                Debug.Assert(nodeToInsertBefore == null, "The head is null but nodeToInsertBefore is not null");
                Debug.Assert(this.Count == 0, "The list should be empty.");

                this.head = node;
                this.tail = node;
                node.LinkNode.Next = null;
                node.LinkNode.Previous = null;
            }
            else
            {
                Debug.Assert(this.tail != null, "Head is not null but tail is null");

                if (nodeToInsertBefore.Equals(this.head))
                {
                    // The new node is going at the beginning of the list.
                    this.head.LinkNode.Previous = node;
                    node.LinkNode.Previous = null;
                    node.LinkNode.Next = this.head;
                    this.head = node;
                }
                else
                {
                    // The new node is going somewhere in the middle of the list.
                    Debug.Assert(nodeToInsertBefore.LinkNode.Previous != null, "The node should be somewhere in the middle of the list, having a previous node.");

                    nodeToInsertBefore.LinkNode.Previous.LinkNode.Next = node;
                    node.LinkNode.Previous = nodeToInsertBefore.LinkNode.Previous;
                    nodeToInsertBefore.LinkNode.Previous = node;
                    node.LinkNode.Next = nodeToInsertBefore;
                }
            }

            ++this.count;
        }

        /// <summary>
        /// Adds the range of items to the collection.
        /// </summary>
        /// <param name="nodes">The range of nodes to add.</param>
        public virtual void AddRange(IEnumerable<T> nodes)
        {
            Param.Ignore(nodes);

            // Make sure the given collection is not empty before doing anything.
            if (nodes != null)
            {
                // Initialize the previous node to the last node in the list, which will
                // be null if the list is initially empty.
                T previousNode = this.tail;

                // Add each of the nodes in the collection.
                foreach (T node in nodes)
                {
                    // Ensure that this node is not already in another list, and then set this as the containing list.
                    if (node.LinkNode.ContainingList != null)
                    {
                        throw new ArgumentException("The node has already been inserted into a different collection.");
                    }

                    node.LinkNode.ContainingList = this;

                    // If there is a previous node, set its NextNode reference to this node.
                    if (previousNode != null)
                    {
                        previousNode.LinkNode.Next = node;
                    }

                    // Set the back pointer to the previous node.
                    node.LinkNode.Previous = previousNode;

                    // This is now the last node in the list. Set this as the tail node and make sure 
                    // it's forward pointer is null.
                    this.tail = node;
                    node.LinkNode.Next = null;

                    // If there is no head node, this is the first node in the list and so it becomes the head node.
                    if (this.head == null)
                    {
                        this.head = node;
                    }

                    // Increment the count for the new node.
                    ++this.count;

                    // Update the previous node reference to this node to prepare to add the next node in the collection.
                    previousNode = node;
                }
            }
        }

        /// <summary>
        /// Removes the given node from the list.
        /// </summary>
        /// <param name="node">The node to remove from the list.</param>
        /// <returns>Return true if the node was removed from the list.</returns>
        public virtual bool Remove(T node)
        {
            Param.AssertNotNull(node, "node");

            // Verify the containing list.
            if (node.LinkNode.ContainingList != this)
            {
                return false;
            }

            if (this.head == null)
            {
                // The list is empty so there is nothing to remove.
                Debug.Assert(this.tail == null, "The head of the list is null but the tail is not null");

                return false;
            }

            if (this.head.Equals(this.tail))
            {
                // This is the only node in the list.
                if (!this.head.Equals(node))
                {
                    return false;
                }

                Debug.Assert(this.count == 1, "There is only one node but the count is not 1.");

                this.head = null;
                this.tail = null;
            }
            else if (this.head.Equals(node))
            {
                // Removing the first node in the list.
                Debug.Assert(this.tail != null, "The head is not null but the tail is null");

                this.head.LinkNode.Next.LinkNode.Previous = null;
                this.head = this.head.LinkNode.Next;
            }
            else if (this.tail.Equals(node))
            {
                // Removing the last node in the list.
                Debug.Assert(this.head != null, "The tail is not null but the head is null");

                this.tail.LinkNode.Previous.LinkNode.Next = null;
                this.tail = this.tail.LinkNode.Previous;
            }
            else
            {
                // Removing a node that is somewhere in the middle of the list.
                node.LinkNode.Previous.LinkNode.Next = node.LinkNode.Next;
                node.LinkNode.Next.LinkNode.Previous = node.LinkNode.Previous;
            }

            node.LinkNode.Next = null;
            node.LinkNode.Previous = null;
            node.LinkNode.ContainingList = null;

            --this.count;

            return true;
        }

        /// <summary>
        /// Removes the given range of nodes from the list.
        /// </summary>
        /// <param name="start">The first node to remove.</param>
        /// <param name="end">The last node to remove.</param>
        /// <remarks>This method assumes that both the start node and the end node are nodes in this list,
        /// and that the start node appears before the end node in the list. These assumptions are not
        /// verified, so use this method with care.</remarks>
        public virtual void RemoveRange(T start, T end)
        {
            Param.AssertNotNull(start, "start");
            Param.AssertNotNull(end, "end");

            // Decrement the count for each node being removed.
            for (T node = start; node != null; node = node.LinkNode.Next)
            {
                --this.count;
                node.LinkNode.ContainingList = null;

                if (node == end)
                {
                    break;
                }
            }

            // Fix up the head and tail of the list.
            if (start.Equals(this.head))
            {
                this.head = end.LinkNode.Next;
            }

            if (end.Equals(this.tail))
            {
                this.tail = start.LinkNode.Previous;
            }

            // Remove the nodes.
            if (start.LinkNode.Previous != null)
            {
                start.LinkNode.Previous.LinkNode.Next = end.LinkNode.Next;
            }

            if (end.LinkNode.Next != null)
            {
                end.LinkNode.Next.LinkNode.Previous = start.LinkNode.Previous;
            }

            start.LinkNode.Previous = null;
            end.LinkNode.Next = null;
        }

        /// <summary>
        /// Removes the given node from the list and replaces it with a different node.
        /// </summary>
        /// <param name="node">The node to remove.</param>
        /// <param name="newNode">The replacement node.</param>
        public virtual void Replace(T node, T newNode)
        {
            Param.AssertNotNull(node, "node");
            Param.AssertNotNull(newNode, "newNode");

            newNode.LinkNode.Next = node.LinkNode.Next;
            newNode.LinkNode.Previous = node.LinkNode.Previous;

            if (node.LinkNode.Previous != null)
            {
                node.LinkNode.Previous.LinkNode.Next = newNode;
            }

            if (node.LinkNode.Next != null)
            {
                node.LinkNode.Next.LinkNode.Previous = newNode;
            }

            if (newNode.LinkNode.ContainingList != null)
            {
                throw new ArgumentException("The node has already been inserted into a different collection.");
            }

            node.LinkNode.ContainingList = null;
            newNode.LinkNode.ContainingList = this;
        }

        /// <summary>
        /// Clears the contents of the list.
        /// </summary>
        public virtual void Clear()
        {
            for (T node = this.head; node != null; node = node.LinkNode.Next)
            {
                node.LinkNode.ContainingList = null;
                if (node == this.tail)
                {
                    break;
                }
            }

            this.head = null;
            this.tail = null;
            this.count = 0;
        }

        #endregion Public Virtual Methods

        #region Public Methods

        /// <summary>
        /// Gets an enumerator that iterates through the nodes in the collection.
        /// </summary>
        /// <returns>Returns an enumerator that iterates through the nodes in the collection.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return new LinkedItemListEnumerators<T>.ForwardEnumerator(this.head, this.tail);
        }

        /// <summary>
        /// Gets an enumerator that iterates through the nodes in the collection.
        /// </summary>
        /// <returns>Returns an enumerator that iterates through the nodes in the collection.</returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        /// <summary>
        /// Determines whether the given item is contained within the list.
        /// </summary>
        /// <param name="item">The item to search for.</param>
        /// <returns>Returns true if the item is contained within the list.</returns>
        public bool Contains(T item)
        {
            Param.Ignore(item);

            for (T listNode = this.head; listNode != null; listNode = listNode.LinkNode.Next)
            {
                if (listNode == item)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Copies the entire collection to the given array, starting at the specified index of the target array.
        /// </summary>
        /// <param name="array">The array that is the destination of the nodes copied from the collection.</param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            Param.AssertNotNull(array, "array");
            Param.AssertGreaterThanOrEqualToZero(arrayIndex, "arrayIndex");

            int i = arrayIndex;
            for (T listNode = this.head; listNode != null; listNode = listNode.LinkNode.Next)
            {
                array[i++] = listNode;
            }
        }

        /// <summary>
        /// Gets an iterator for enumerating forward through the items in the list.
        /// </summary>
        /// <returns>Returns the enumerable object.</returns>
        public IEnumerable<T> ForwardIterator()
        {
            return this.ForwardIterator(this.head);
        }

        /// <summary>
        /// Gets an iterator for enumerating forward through the items in the list.
        /// </summary>
        /// <param name="start">The start position of the iterator.</param>
        /// <returns>Returns the enumerable object.</returns>
        public IEnumerable<T> ForwardIterator(T start)
        {
            Param.Ignore(start);

            return new LinkedItemListEnumerators<T>.ForwardEnumerable(start, this.tail);
        }

        /// <summary>
        /// Gets an iterator for enumerating backwards through the items in the list.
        /// </summary>
        /// <returns>Returns the enumerable object.</returns>
        public IEnumerable<T> ReverseIterator()
        {
            return this.ReverseIterator(this.tail);
        }

        /// <summary>
        /// Gets an iterator for enumerating backwards through the items in the list.
        /// </summary>
        /// <param name="start">The start position of the iterator.</param>
        /// <returns>Returns the enumerable object.</returns>
        public IEnumerable<T> ReverseIterator(T start)
        {
            Param.Ignore(start);

            return new LinkedItemListEnumerators<T>.BackwardEnumerable(start, this.head);
        }

        /// <summary>
        /// Inserts the specified item at the beginning of the list.
        /// </summary>
        /// <param name="item">The item to insert.</param>
        public void InsertFirst(T item)
        {
            Param.AssertNotNull(item, "item");
            this.InsertBefore(item, this.head);
        }

        /// <summary>
        /// Inserts the specified item at the end of the list.
        /// </summary>
        /// <param name="item">The item to insert.</param>
        public void InsertLast(T item)
        {
            Param.AssertNotNull(item, "item");
            this.InsertAfter(item, this.tail);
        }

        /// <summary>
        /// Adds an item to the collection.
        /// </summary>
        /// <param name="item">The item to add to the collection.</param>
        public void Add(T item)
        {
            Param.AssertNotNull(item, "item");
            this.InsertLast(item);
        }

        #endregion Public Methods
    }
}
