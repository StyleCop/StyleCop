//--------------------------------------------------------------------------
// <copyright file="LinkNode.cs" company="Microsoft">
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
namespace Microsoft.StyleCop.Collections
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Contained by a node that can be inserted into a <see cref="LinkedItemList{T}" />.
    /// </summary>
    /// <typeparam name="T">The type of the container node.</typeparam>
    public class LinkNode<T> where T : class, ILinkNode<T>
    {
        #region Private Fields

        /// <summary>
        /// The next node.
        /// </summary>
        private T next;

        /// <summary>
        /// The previous node.
        /// </summary>
        private T previous;

        /// <summary>
        /// The list that contains this node.
        /// </summary>
        private LinkedItemList<T> containingList;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the LinkNode class.
        /// </summary>
        /// <param name="containerNode">The linked list node that contains this item.</param>
        public LinkNode(T containerNode)
        {
            Param.RequireNotNull(containerNode, "containerNode");
            
            // The containerNode instance is not used, but it is required in the constructor to enforce the 
            // notion that a LinkNode has a 1:1 relationship with its container node.
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        /// Gets the next node in the list.
        /// </summary>
        public T Next
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
        public T Previous
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

        #endregion Public Properties

        #region Internal Properties

        /// <summary>
        /// Gets or sets the list that contains this node.
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

        #endregion Internal Properties

        #region Public Methods

        /// <summary>
        /// Determines whether the given node is in the same list as this node.
        /// </summary>
        /// <param name="node">The other node.</param>
        /// <returns>true if the nodes are in the same list; false otherwise.</returns>
        public bool NodesInSameList(T node)
        {
            Param.Ignore(node);

            if (node == null)
            {
                return false;
            }

            return node.LinkNode.ContainingList == this.ContainingList;
        }

        #endregion Public Methods
    }
}
