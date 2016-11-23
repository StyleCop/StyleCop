// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LinkedItemList.cs" company="https://github.com/StyleCop">
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
//   A doubly-linked list.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// A doubly-linked list.
    /// </summary>
    /// <typeparam name="T">
    /// The type of item stored in the list.
    /// </typeparam>
    internal class LinkedItemList<T> : ICollection<T>
        where T : class
    {
        #region Fields

        /// <summary>
        /// The number of items in the list.
        /// </summary>
        private int count;

        /// <summary>
        /// The first node in the list.
        /// </summary>
        private Node<T> head;

        /// <summary>
        /// The last node in the list.
        /// </summary>
        private Node<T> tail;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="LinkedItemList{T}"/> class. 
        /// Initializes a new instance of the LinkedItemList class.
        /// </summary>
        internal LinkedItemList()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LinkedItemList{T}"/> class. 
        /// Initializes a new instance of the LinkedItemList class.
        /// </summary>
        /// <param name="items">
        /// The initial items for the list.
        /// </param>
        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors", Justification = "This is safe")]
        internal LinkedItemList(ICollection<T> items)
        {
            Param.Ignore(items);

            if (items != null)
            {
                this.AddRange(items);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LinkedItemList{T}"/> class. 
        /// Initializes a new instance of the LinkedItemList class.
        /// </summary>
        /// <param name="nodes">
        /// The initial nodes for the list.
        /// </param>
        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors", Justification = "This is safe")]
        internal LinkedItemList(ICollection<Node<T>> nodes)
        {
            Param.Ignore(nodes);

            if (nodes != null)
            {
                this.AddRange(nodes);
            }
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
        /// Gets the number of items in the collection.
        /// </summary>
        public int Count
        {
            get
            {
                return this.count;
            }
        }

        /// <summary>
        /// Gets the first item in the list.
        /// </summary>
        public Node<T> First
        {
            get
            {
                return this.head;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the collection is read-only.
        /// </summary>
        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Gets the last item in the list.
        /// </summary>
        public Node<T> Last
        {
            get
            {
                return this.tail;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Adds an item to the collection.
        /// </summary>
        /// <param name="item">
        /// The item to add to the collection.
        /// </param>
        public void Add(T item)
        {
            Param.AssertNotNull(item, "item");
            this.InsertLast(item);
        }

        /// <summary>
        /// Adds an item to the collection.
        /// </summary>
        /// <param name="node">
        /// The node to add to the collection.
        /// </param>
        public void Add(Node<T> node)
        {
            Param.AssertNotNull(node, "node");
            this.InsertAfter(node, this.tail);
        }

        /// <summary>
        /// Adds the range of items to the collection.
        /// </summary>
        /// <param name="items">
        /// The range of items to add.
        /// </param>
        /// <returns>
        /// Returns the added nodes.
        /// </returns>
        public ICollection<Node<T>> AddRange(IEnumerable<T> items)
        {
            Param.Ignore(items);

            // Make sure the given collection is not empty before doing anything.
            if (items != null)
            {
                // Create a collection of wrappers for the items.
                List<Node<T>> wrappers = new List<Node<T>>();

                foreach (T item in items)
                {
                    wrappers.Add(new Node<T>(item));
                }

                this.AddRange(wrappers);

                return wrappers;
            }

            return null;
        }

        /// <summary>
        /// Adds the range of items to the collection.
        /// </summary>
        /// <param name="nodes">
        /// The range of nodes to add.
        /// </param>
        public void AddRange(IEnumerable<Node<T>> nodes)
        {
            Param.Ignore(nodes);

            // Make sure the given collection is not empty before doing anything.
            if (nodes != null)
            {
                // Initialize the previous node to the last node in the list, which will
                // be null if the list is initially empty.
                Node<T> previousNode = this.tail;

                // Add each of the nodes in the collection.
                foreach (Node<T> node in nodes)
                {
                    // Ensure that this node is not already in another list, and then set this as the containing list.
                    if (node.ContainingList != null)
                    {
                        throw new ArgumentException(Strings.NodeAlreadyInCollection);
                    }

                    node.ContainingList = this;

                    // If there is a previous node, set its NextNode reference to this node.
                    if (previousNode != null)
                    {
                        previousNode.Next = node;
                    }

                    // Set the back pointer to the previous node.
                    node.Previous = previousNode;

                    // This is now the last node in the list. Set this as the tail node and make sure 
                    // it's forward pointer is null.
                    this.tail = node;
                    node.Next = null;

                    // If there is no head node, this is the first node in the list and so it becomes the head node.
                    if (this.head == null)
                    {
                        this.head = node;
                    }

                    // Increment the count for the new node.
                    ++this.count;

                    // Update the previous node reference to this node to prepare to add the next node in the collection.
                    previousNode = node;

                    // Set up the index for the node.
                    if (!node.CreateIndex())
                    {
                        this.ResetNodeIndexes();
                    }
                }
            }
        }

        /// <summary>
        /// Clears the contents of the list.
        /// </summary>
        public void Clear()
        {
            for (Node<T> node = this.head; node != null; node = node.Next)
            {
                node.ContainingList = null;
                if (node == this.tail)
                {
                    break;
                }
            }

            this.head = null;
            this.tail = null;
            this.count = 0;
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

            for (Node<T> listNode = this.head; listNode != null; listNode = listNode.Next)
            {
                if (listNode.Value == item)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Determines whether the given item is contained within the list.
        /// </summary>
        /// <param name="node">
        /// The node to search for.
        /// </param>
        /// <returns>
        /// Returns true if the node is contained within the list.
        /// </returns>
        public bool Contains(Node<T> node)
        {
            Param.Ignore(node);

            for (Node<T> listNode = this.head; listNode != null; listNode = listNode.Next)
            {
                if (listNode == node)
                {
                    return true;
                }
            }

            return false;
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
            Param.AssertNotNull(array, "array");
            Param.AssertGreaterThanOrEqualToZero(arrayIndex, "arrayIndex");

            int i = arrayIndex;
            for (Node<T> listNode = this.head; listNode != null; listNode = listNode.Next)
            {
                array[i++] = listNode.Value;
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
        /// <param name="start">
        /// The start position of the iterator.
        /// </param>
        /// <returns>
        /// Returns the enumerable object.
        /// </returns>
        public IEnumerable<T> ForwardIterator(Node<T> start)
        {
            Param.Ignore(start);

            return new LinkedItemListEnumerators<T>.ForwardValueEnumerable(start, this.tail);
        }

        /// <summary>
        /// Gets an iterator for enumerating forward through the nodes in the list.
        /// </summary>
        /// <returns>Returns the enumerable object.</returns>
        public IEnumerable<Node<T>> ForwardNodeIterator()
        {
            return this.ForwardNodeIterator(this.head);
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

            return new LinkedItemListEnumerators<T>.ForwardNodeEnumerable(start, this.tail);
        }

        /// <summary>
        /// Gets an enumerator that iterates through the nodes in the collection.
        /// </summary>
        /// <returns>Returns an enumerator that iterates through the nodes in the collection.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return new LinkedItemListEnumerators<T>.ForwardValueEnumerator(this.head, this.tail);
        }

        /// <summary>
        /// Inserts a item into the list after the given item.
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
        public Node<T> InsertAfter(T item, Node<T> nodeToInsertAfter)
        {
            Param.AssertNotNull(item, "item");
            Param.Ignore(nodeToInsertAfter);

            return this.InsertAfter(new Node<T>(item), nodeToInsertAfter);
        }

        /// <summary>
        /// Inserts a node into the list before the given item.
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
        public Node<T> InsertBefore(T item, Node<T> nodeToInsertBefore)
        {
            Param.AssertNotNull(item, "item");
            Param.Ignore(nodeToInsertBefore);

            return this.InsertBefore(new Node<T>(item), nodeToInsertBefore);
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
        public Node<T> InsertFirst(T item)
        {
            Param.AssertNotNull(item, "item");
            return this.InsertBefore(item, this.head);
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
        public Node<T> InsertLast(T item)
        {
            Param.AssertNotNull(item, "item");
            return this.InsertAfter(item, this.tail);
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
        public bool Remove(T item)
        {
            Param.AssertNotNull(item, "item");

            for (Node<T> node = this.head; node != null; node = node.Next)
            {
                if (node.Value.Equals(item))
                {
                    return this.Remove(node);
                }
            }

            return false;
        }

        /// <summary>
        /// Removes the given node from the list.
        /// </summary>
        /// <param name="node">
        /// The node to remove from the list.
        /// </param>
        /// <returns>
        /// Return true if the node was removed from the list.
        /// </returns>
        public bool Remove(Node<T> node)
        {
            Param.AssertNotNull(node, "node");

            // Verify the containing list.
            if (node.ContainingList != this)
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

                this.head.Next.Previous = null;
                this.head = this.head.Next;
            }
            else if (this.tail.Equals(node))
            {
                // Removing the last node in the list.
                Debug.Assert(this.head != null, "The tail is not null but the head is null");

                this.tail.Previous.Next = null;
                this.tail = this.tail.Previous;
            }
            else
            {
                // Removing a node that is somewhere in the middle of the list.
                node.Previous.Next = node.Next;
                node.Next.Previous = node.Previous;
            }

            node.Next = null;
            node.Previous = null;
            node.ContainingList = null;

            --this.count;

            return true;
        }

        /// <summary>
        /// Removes the given range of nodes from the list.
        /// </summary>
        /// <param name="start">
        /// The first node to remove.
        /// </param>
        /// <param name="end">
        /// The last node to remove.
        /// </param>
        /// <remarks>
        /// This method assumes that both the start node and the end node are nodes in this list,
        /// and that the start node appears before the end node in the list. These assumptions are not
        /// verified, so use this method with care.
        /// </remarks>
        public void RemoveRange(Node<T> start, Node<T> end)
        {
            Param.AssertNotNull(start, "start");
            Param.AssertNotNull(end, "end");

            // Decrement the count for each node being removed.
            for (Node<T> node = start; node != null; node = node.Next)
            {
                --this.count;
                node.ContainingList = null;

                if (node == end)
                {
                    break;
                }
            }

            // Fix up the head and tail of the list.
            if (start.Equals(this.head))
            {
                this.head = end.Next;
            }

            if (end.Equals(this.tail))
            {
                this.tail = start.Previous;
            }

            // Remove the nodes.
            if (start.Previous != null)
            {
                start.Previous.Next = end.Next;
            }

            if (end.Next != null)
            {
                end.Next.Previous = start.Previous;
            }

            start.Previous = null;
            end.Next = null;
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
        public Node<T> Replace(Node<T> node, T newItem)
        {
            Param.AssertNotNull(node, "node");
            Param.AssertNotNull(newItem, "newItem");

            Node<T> newNode = new Node<T>(newItem);
            this.Replace(node, newNode);

            return newNode;
        }

        /// <summary>
        /// Removes the given node from the list and replaces it with a different node.
        /// </summary>
        /// <param name="node">
        /// The node to remove.
        /// </param>
        /// <param name="newNode">
        /// The replacement node.
        /// </param>
        public void Replace(Node<T> node, Node<T> newNode)
        {
            Param.AssertNotNull(node, "node");
            Param.AssertNotNull(newNode, "newNode");

            newNode.Next = node.Next;
            newNode.Previous = node.Previous;

            if (node.Previous != null)
            {
                node.Previous.Next = newNode;
            }

            if (node.Next != null)
            {
                node.Next.Previous = newNode;
            }

            if (newNode.ContainingList != null)
            {
                throw new ArgumentException(Strings.NodeAlreadyInCollection);
            }

            node.ContainingList = null;
            newNode.ContainingList = this;

            // Set up the index for the node.
            if (!newNode.CreateIndex())
            {
                this.ResetNodeIndexes();
            }
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
        /// <param name="start">
        /// The start position of the iterator.
        /// </param>
        /// <returns>
        /// Returns the enumerable object.
        /// </returns>
        public IEnumerable<T> ReverseIterator(Node<T> start)
        {
            Param.Ignore(start);

            return new LinkedItemListEnumerators<T>.BackwardValueEnumerable(start, this.head);
        }

        /// <summary>
        /// Gets an iterator for enumerating backwards through the nodes in the list.
        /// </summary>
        /// <returns>Returns the enumerable object.</returns>
        public IEnumerable<Node<T>> ReverseNodeIterator()
        {
            return this.ReverseNodeIterator(this.tail);
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

            return new LinkedItemListEnumerators<T>.BackwardNodeEnumerable(start, this.head);
        }

        #endregion

        #region Explicit Interface Methods

        /// <summary>
        /// Gets an enumerator that iterates through the nodes in the collection.
        /// </summary>
        /// <returns>Returns an enumerator that iterates through the nodes in the collection.</returns>
        IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
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
        /// Inserts a item into the list after the given item.
        /// </summary>
        /// <param name="node">
        /// The node to insert.
        /// </param>
        /// <param name="nodeToInsertAfter">
        /// The node to insert the item after.
        /// </param>
        /// <returns>
        /// Returns the new node.
        /// </returns>
        private Node<T> InsertAfter(Node<T> node, Node<T> nodeToInsertAfter)
        {
            Param.AssertNotNull(node, "node");
            Param.Ignore(nodeToInsertAfter);

            Debug.Assert(nodeToInsertAfter != null || this.head == null, "nodeToInsertAfter", "nodeToInsertAfter may only be null if the list is empty");

            // Check and set the containing list.
            if (node.ContainingList != null)
            {
                throw new ArgumentException(Strings.NodeAlreadyInCollection);
            }

            node.ContainingList = this;

            // First, check if the list is empty.
            if (this.head == null)
            {
                Debug.Assert(this.tail == null, "The head is null but the tail is not null");
                Debug.Assert(nodeToInsertAfter == null, "The head is null but nodeToInsertAfter is not null");
                Debug.Assert(this.Count == 0, "The list should be empty.");

                this.head = node;
                this.tail = node;
                node.Next = null;
                node.Previous = null;
            }
            else
            {
                Debug.Assert(this.tail != null, "Head is not null but tail is null");

                if (nodeToInsertAfter.Equals(this.tail))
                {
                    // The new node is going at the end of the list.
                    this.tail.Next = node;
                    node.Next = null;
                    node.Previous = this.tail;
                    this.tail = node;
                }
                else
                {
                    // The new node is going somewhere in the middle of the list.
                    Debug.Assert(nodeToInsertAfter.Next != null, "The node should be in the middle of the list, having a next node.");

                    nodeToInsertAfter.Next.Previous = node;
                    node.Next = nodeToInsertAfter.Next;
                    nodeToInsertAfter.Next = node;
                    node.Previous = nodeToInsertAfter;
                }
            }

            ++this.count;

            // Set up the index for the node.
            if (!node.CreateIndex())
            {
                this.ResetNodeIndexes();
            }

            return node;
        }

        /// <summary>
        /// Inserts a node into the list before the given item.
        /// </summary>
        /// <param name="node">
        /// The node to insert.
        /// </param>
        /// <param name="nodeToInsertBefore">
        /// The node to insert the item before.
        /// </param>
        /// <returns>
        /// Returns the new node.
        /// </returns>
        private Node<T> InsertBefore(Node<T> node, Node<T> nodeToInsertBefore)
        {
            Param.AssertNotNull(node, "node");
            Param.Ignore(nodeToInsertBefore);

            Debug.Assert(nodeToInsertBefore != null || this.head == null, "nodeToInsertBefore", "nodeToInsertBefore may only be null if the list is empty");

            // Check and set the containing list.
            if (node.ContainingList != null)
            {
                throw new ArgumentException(Strings.NodeAlreadyInCollection);
            }

            node.ContainingList = this;

            // First, check if the list is empty.
            if (this.head == null)
            {
                Debug.Assert(this.tail == null, "The head is null but the tail is not null");
                Debug.Assert(nodeToInsertBefore == null, "The head is null but nodeToInsertBefore is not null");
                Debug.Assert(this.Count == 0, "The list should be empty.");

                this.head = node;
                this.tail = node;
                node.Next = null;
                node.Previous = null;
            }
            else
            {
                Debug.Assert(this.tail != null, "Head is not null but tail is null");

                if (nodeToInsertBefore.Equals(this.head))
                {
                    // The new node is going at the beginning of the list.
                    this.head.Previous = node;
                    node.Previous = null;
                    node.Next = this.head;
                    this.head = node;
                }
                else
                {
                    // The new node is going somewhere in the middle of the list.
                    Debug.Assert(nodeToInsertBefore.Previous != null, "The node should be somewhere in the middle of the list, having a previous node.");

                    nodeToInsertBefore.Previous.Next = node;
                    node.Previous = nodeToInsertBefore.Previous;
                    nodeToInsertBefore.Previous = node;
                    node.Next = nodeToInsertBefore;
                }
            }

            // Set up the index for the node.
            if (!node.CreateIndex())
            {
                this.ResetNodeIndexes();
            }

            ++this.count;

            return node;
        }

        /// <summary>
        /// Resets the indexes of all nodes in the list.
        /// </summary>
        private void ResetNodeIndexes()
        {
            // Determine the best starting point for the first index. Try to center the nodes
            // in the middle of the index range, leaving space between each node.
            int spacer = NodeIndex.Spacer;

            while (spacer > 0)
            {
                if (this.count * (spacer + 1) < Math.Abs(int.MinValue) + int.MaxValue)
                {
                    break;
                }

                --spacer;
            }

            // If the nodes can still not fit with a zero-length spacer. Then throw an exception
            // and quit. This could be further optimized by using the small values to fit a lot
            // more nodes. However, it is unlikely that there will ever be more nodes than there
            // are indexes in an int field.
            int totalLength = this.count * (spacer + 1);
            if (totalLength >= Math.Abs(int.MinValue) + int.MaxValue)
            {
                throw new InvalidOperationException();
            }

            // Center the node list within the int range.
            int nextIndex = 0 - (totalLength / 2);

            for (Node<T> node = this.First; node != null; node = node.Next)
            {
                node.Index.Set(nextIndex);
                nextIndex += spacer + 1;
            }

            // Notify that the node indexes have been reset.
            this.OnNodeIndexesReset(new EventArgs());
        }

        #endregion
    }
}