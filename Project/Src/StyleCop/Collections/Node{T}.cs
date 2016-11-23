// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Node{T}.cs" company="https://github.com/StyleCop">
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
//   Interface which is implemented by a node class to be used with the LinkedItemList class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop
{
    /// <summary>
    /// Interface which is implemented by a node class to be used with the LinkedItemList class.
    /// </summary>
    /// <typeparam name="T">
    /// The type of node stored in the linked list.
    /// </typeparam>
    public class Node<T>
        where T : class
    {
        #region Fields

        /// <summary>
        /// The current item.
        /// </summary>
        private readonly T item;

        /// <summary>
        /// The master list that contains this node.
        /// </summary>
        private LinkedItemList<T> containingList;

        /// <summary>
        /// The index of the node in the list in which it is contained.
        /// </summary>
        private NodeIndex index;

        /// <summary>
        /// The next node.
        /// </summary>
        private Node<T> next;

        /// <summary>
        /// The previous node.
        /// </summary>
        private Node<T> previous;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Node{T}"/> class. 
        /// Initializes a new instance of the Node class.
        /// </summary>
        /// <param name="item">
        /// The node item.
        /// </param>
        internal Node(T item)
        {
            Param.AssertNotNull(item, "item");
            this.item = item;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the index of the node within the master list that contains it.
        /// </summary>
        /// <remarks>The index is not guaranteed to be immutable. Subscribe to the <see cref="MasterList{T}.NodeIndexesReset"/> event
        /// to receive a notification when the indexes of nodes within the list are reset.</remarks>
        public NodeIndex Index
        {
            get
            {
                return this.index;
            }
        }

        /// <summary>
        /// Gets the next node in the list.
        /// </summary>
        public Node<T> Next
        {
            get
            {
                return this.next;
            }

            internal set
            {
                this.next = value;
            }
        }

        /// <summary>
        /// Gets the previous node in the list.
        /// </summary>
        public Node<T> Previous
        {
            get
            {
                return this.previous;
            }

            internal set
            {
                this.previous = value;
            }
        }

        /// <summary>
        /// Gets the node.
        /// </summary>
        public T Value
        {
            get
            {
                return this.item;
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the master list that contains this node.
        /// </summary>
        internal LinkedItemList<T> ContainingList
        {
            get
            {
                return this.containingList;
            }

            set
            {
                Param.Ignore(value);
                this.containingList = value;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Determines whether the given node is in the same list as this node.
        /// </summary>
        /// <param name="node">
        /// The other node.
        /// </param>
        /// <returns>
        /// true if the nodes are in the same list; false otherwise.
        /// </returns>
        public bool NodesInSameList(Node<T> node)
        {
            Param.Ignore(node);

            if (node == null)
            {
                return false;
            }

            return node.ContainingList == this.ContainingList;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Creates the index for the node.
        /// </summary>
        /// <returns>Returns true if the index was created successfully, or false if it not possible
        /// to create a new index for this node.</returns>
        /// <remarks>This method should be called after the node is added to a list.</remarks>
        internal bool CreateIndex()
        {
            bool success = false;

            if (this.next == null)
            {
                if (this.previous == null)
                {
                    // This is the only node in the list.
                    success = NodeIndex.CreateFirst(out this.index);
                }
                else
                {
                    // This is the last node in the list.
                    success = NodeIndex.CreateAfter(this.previous.index, out this.index);
                }
            }
            else if (this.previous == null)
            {
                // This is the last node in the list.
                success = NodeIndex.CreateBefore(this.next.index, out this.index);
            }
            else
            {
                // This node is between two nodes in the list.
                success = NodeIndex.CreateBetween(this.previous.index, this.next.index, out this.index);
            }

            return success;
        }

        #endregion
    }
}