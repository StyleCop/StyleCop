//-----------------------------------------------------------------------
// <copyright file="LinkedItemListEnumerators{T}.cs">
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
namespace StyleCop
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// A set of enumerators for iterating through lists based on the <see cref="LinkedItemList{T}"/> class.
    /// </summary>
    /// <typeparam name="T">The type of item stored in the list.</typeparam>
    internal static class LinkedItemListEnumerators<T> where T : class
    {
        #region ForwardValueEnumerable Class
        
        /// <summary>
        /// Provides an enumerator for iterating forward through the items in the list.
        /// </summary>
        public class ForwardValueEnumerable : IEnumerable<T>
        {
            #region Private Fields

            /// <summary>
            /// The first item in the master list.
            /// </summary>
            private Node<T> startItem;

            /// <summary>
            /// The last item in the master list.
            /// </summary>
            private Node<T> endItem;

            #endregion Private Fields

            #region Public Constructors

            /// <summary>
            /// Initializes a new instance of the ForwardValueEnumerable class.
            /// </summary>
            /// <param name="startItem">The first item in the master list.</param>
            /// <param name="endItem">The last item in the master list.</param>
            public ForwardValueEnumerable(Node<T> startItem, Node<T> endItem)
            {
                Param.Ignore(startItem);
                Param.Ignore(endItem);

                this.startItem = startItem;
                this.endItem = endItem;
            }

            #endregion Public Constructors

            #region Public Methods

            /// <summary>
            /// Gets an enumerator for iterating through the list.
            /// </summary>
            /// <returns>Returns the enumerator.</returns>
            public IEnumerator<T> GetEnumerator()
            {
                return new ForwardValueEnumerator(this.startItem, this.endItem);
            }

            /// <summary>
            /// Gets an enumerator for iterating through the list.
            /// </summary>
            /// <returns>Returns the enumerator.</returns>
            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }

            #endregion Public Methods
        }

        #endregion ForwardValueEnumerable Class

        #region BackwardValueEnumerable Class

        /// <summary>
        /// Provides an enumerator for iterating backwards through the items in the list.
        /// </summary>
        public class BackwardValueEnumerable : IEnumerable<T>
        {
            #region Private Fields

            /// <summary>
            /// The first item in the master list.
            /// </summary>
            private Node<T> startItem;

            /// <summary>
            /// The last item in the master list.
            /// </summary>
            private Node<T> endItem;

            #endregion Private Fields

            #region Public Constructors

            /// <summary>
            /// Initializes a new instance of the BackwardValueEnumerable class.
            /// </summary>
            /// <param name="startItem">The first item in the master list.</param>
            /// <param name="endItem">The last item in the master list.</param>
            public BackwardValueEnumerable(Node<T> startItem, Node<T> endItem)
            {
                Param.Ignore(startItem);
                Param.Ignore(endItem);

                this.startItem = startItem;
                this.endItem = endItem;
            }

            #endregion Public Constructors

            #region Public Methods

            /// <summary>
            /// Gets an enumerator for iterating through the list.
            /// </summary>
            /// <returns>Returns the enumerator.</returns>
            public IEnumerator<T> GetEnumerator()
            {
                return new BackwardValueEnumerator(this.startItem, this.endItem);
            }

            /// <summary>
            /// Gets an enumerator for iterating through the list.
            /// </summary>
            /// <returns>Returns the enumerator.</returns>
            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }

            #endregion Public Methods
        }

        #endregion BackwardValueEnumerable Class

        #region ForwardNodeEnumerable Class

        /// <summary>
        /// Provides an enumerator for iterating forward through the nodes in the list.
        /// </summary>
        public class ForwardNodeEnumerable : IEnumerable<Node<T>>
        {
            #region Private Fields

            /// <summary>
            /// The first item in the master list.
            /// </summary>
            private Node<T> startItem;

            /// <summary>
            /// The last item in the master list.
            /// </summary>
            private Node<T> endItem;

            #endregion Private Fields

            #region Public Constructors

            /// <summary>
            /// Initializes a new instance of the ForwardNodeEnumerable class.
            /// </summary>
            /// <param name="startItem">The first item in the master list.</param>
            /// <param name="endItem">The last item in the master list.</param>
            public ForwardNodeEnumerable(Node<T> startItem, Node<T> endItem)
            {
                Param.Ignore(startItem);
                Param.Ignore(endItem);

                this.startItem = startItem;
                this.endItem = endItem;
            }

            #endregion Public Constructors

            #region Public Methods

            /// <summary>
            /// Gets an enumerator for iterating through the list.
            /// </summary>
            /// <returns>Returns the enumerator.</returns>
            public IEnumerator<Node<T>> GetEnumerator()
            {
                return new ForwardNodeEnumerator(this.startItem, this.endItem);
            }

            /// <summary>
            /// Gets an enumerator for iterating through the list.
            /// </summary>
            /// <returns>Returns the enumerator.</returns>
            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }

            #endregion Public Methods
        }

        #endregion ForwardNodeEnumerable Class

        #region BackwardNodeEnumerable Class

        /// <summary>
        /// Provides an enumerator for iterating backwards through the list.
        /// </summary>
        public class BackwardNodeEnumerable : IEnumerable<Node<T>>
        {
            #region Private Fields

            /// <summary>
            /// The first item in the master list.
            /// </summary>
            private Node<T> startItem;

            /// <summary>
            /// The last item in the master list.
            /// </summary>
            private Node<T> endItem;

            #endregion Private Fields

            #region Public Constructors

            /// <summary>
            /// Initializes a new instance of the BackwardNodeEnumerable class.
            /// </summary>
            /// <param name="startItem">The first item in the master list.</param>
            /// <param name="endItem">The last item in the master list.</param>
            public BackwardNodeEnumerable(Node<T> startItem, Node<T> endItem)
            {
                Param.Ignore(startItem);
                Param.Ignore(endItem);

                this.startItem = startItem;
                this.endItem = endItem;
            }

            #endregion Public Constructors

            #region Public Methods

            /// <summary>
            /// Gets an enumerator for iterating through the list.
            /// </summary>
            /// <returns>Returns the enumerator.</returns>
            public IEnumerator<Node<T>> GetEnumerator()
            {
                return new BackwardNodeEnumerator(this.startItem, this.endItem);
            }

            /// <summary>
            /// Gets an enumerator for iterating through the list.
            /// </summary>
            /// <returns>Returns the enumerator.</returns>
            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }

            #endregion Public Methods
        }

        #endregion BackwardNodeEnumerable Class

        #region ForwardValueEnumerator Class

        /// <summary>
        /// Enumerates forwards through the items in the collection.
        /// </summary>
        public class ForwardValueEnumerator : IEnumerator<T>
        {
            #region Private Fields

            /// <summary>
            /// The first item in the master list.
            /// </summary>
            private Node<T> startItem;

            /// <summary>
            /// The last item in the master list.
            /// </summary>
            private Node<T> endItem;

            /// <summary>
            /// The current item in the collection.
            /// </summary>
            private Node<T> currentItem;

            #endregion Private Fields

            #region Public Constructors

            /// <summary>
            /// Initializes a new instance of the ForwardValueEnumerator class.
            /// </summary>
            /// <param name="startItem">The first item in the master list.</param>
            /// <param name="endItem">The last item in the master list.</param>
            public ForwardValueEnumerator(Node<T> startItem, Node<T> endItem)
            {
                Param.Ignore(startItem);
                Param.Ignore(endItem);

                this.startItem = startItem;
                this.endItem = endItem;
            }

            #endregion Public Constructors

            #region Public Properties

            /// <summary>
            /// Gets the current item.
            /// </summary>
            public T Current
            {
                get
                {
                    return this.currentItem == null ? null : this.currentItem.Value;
                }
            }

            #endregion Public Properties

            #region IEnumerator Interface Properties

            /// <summary>
            /// Gets the current item.
            /// </summary>
            object System.Collections.IEnumerator.Current
            {
                get
                {
                    return this.Current;
                }
            }

            #endregion IEnumerator Interface Properties

            #region Public Methods

            /// <summary>
            /// Disposes the contents of the class.
            /// </summary>
            public void Dispose()
            {
                GC.SuppressFinalize(this);
            }

            /// <summary>
            /// Moves to the next item in the collection.
            /// </summary>
            /// <returns>Returns false if there are no more items in the collection.</returns>
            public bool MoveNext()
            {
                if (this.startItem == null || this.endItem == null)
                {
                    return false;
                }
                else if (this.currentItem == null)
                {
                    this.currentItem = this.startItem;
                }
                else if (this.currentItem == this.endItem)
                {
                    this.currentItem = null;
                }
                else
                {
                    this.currentItem = this.currentItem.Next;
                }

                return this.currentItem != null;
            }

            /// <summary>
            /// Resets the enumerator back to the beginning of the collection.
            /// </summary>
            public void Reset()
            {
                this.currentItem = null;
            }

            #endregion Public Methods
        }

        #endregion ForwardValueEnumerator Class

        #region BackwardValueEnumerator Class

        /// <summary>
        /// Enumerates backwards through the items in the collection.
        /// </summary>
        public class BackwardValueEnumerator : IEnumerator<T>
        {
            #region Private Fields

            /// <summary>
            /// The first item in the master list.
            /// </summary>
            private Node<T> startItem;

            /// <summary>
            /// The last item in the master list.
            /// </summary>
            private Node<T> endItem;

            /// <summary>
            /// The current item in the collection.
            /// </summary>
            private Node<T> currentItem;

            #endregion Private Fields

            #region Public Constructors

            /// <summary>
            /// Initializes a new instance of the BackwardValueEnumerator class.
            /// </summary>
            /// <param name="startItem">The first item in the master list.</param>
            /// <param name="endItem">The last item in the master list.</param>
            public BackwardValueEnumerator(Node<T> startItem, Node<T> endItem)
            {
                Param.Ignore(startItem);
                Param.Ignore(endItem);

                this.startItem = startItem;
                this.endItem = endItem;
            }

            #endregion Public Constructors

            #region Public Properties

            /// <summary>
            /// Gets the current item.
            /// </summary>
            public T Current
            {
                get
                {
                    return this.currentItem == null ? null : this.currentItem.Value;
                }
            }

            #endregion Public Properties

            #region IEnumerator Interface Properties

            /// <summary>
            /// Gets the current item.
            /// </summary>
            object System.Collections.IEnumerator.Current
            {
                get
                {
                    return this.currentItem == null ? null : this.currentItem.Value;
                }
            }

            #endregion IEnumerator Interface Properties

            #region Public Methods

            /// <summary>
            /// Disposes the contents of the class.
            /// </summary>
            public void Dispose()
            {
                GC.SuppressFinalize(this);
            }

            /// <summary>
            /// Moves to the next item in the collection.
            /// </summary>
            /// <returns>Returns false if there are no more items in the collection.</returns>
            public bool MoveNext()
            {
                if (this.startItem == null || this.endItem == null)
                {
                    return false;
                }
                else if (this.currentItem == null)
                {
                    this.currentItem = this.startItem;
                }
                else if (this.currentItem == this.endItem)
                {
                    this.currentItem = null;
                }
                else
                {
                    this.currentItem = this.currentItem.Previous;
                }

                return this.currentItem != null;
            }

            /// <summary>
            /// Resets the enumerator back to the beginning of the collection.
            /// </summary>
            public void Reset()
            {
                this.currentItem = null;
            }

            #endregion Public Methods
        }

        #endregion BackwardValueEnumerator Class

        #region ForwardNodeEnumerator Class

        /// <summary>
        /// Enumerates forwards through the nodes in the collection.
        /// </summary>
        public class ForwardNodeEnumerator : IEnumerator<Node<T>>
        {
            #region Private Fields

            /// <summary>
            /// The first item in the master list.
            /// </summary>
            private Node<T> startItem;

            /// <summary>
            /// The last item in the master list.
            /// </summary>
            private Node<T> endItem;

            /// <summary>
            /// The current item in the collection.
            /// </summary>
            private Node<T> currentItem;

            #endregion Private Fields

            #region Public Constructors

            /// <summary>
            /// Initializes a new instance of the ForwardNodeEnumerator class.
            /// </summary>
            /// <param name="startItem">The first item in the master list.</param>
            /// <param name="endItem">The last item in the master list.</param>
            public ForwardNodeEnumerator(Node<T> startItem, Node<T> endItem)
            {
                Param.Ignore(startItem);
                Param.Ignore(endItem);

                this.startItem = startItem;
                this.endItem = endItem;
            }

            #endregion Public Constructors

            #region Public Properties

            /// <summary>
            /// Gets the current item.
            /// </summary>
            public Node<T> Current
            {
                get
                {
                    return this.currentItem;
                }
            }

            #endregion Public Properties

            #region IEnumerator Interface Properties

            /// <summary>
            /// Gets the current item.
            /// </summary>
            object System.Collections.IEnumerator.Current
            {
                get
                {
                    return this.currentItem;
                }
            }

            #endregion IEnumerator Interface Properties

            #region Public Methods

            /// <summary>
            /// Disposes the contents of the class.
            /// </summary>
            public void Dispose()
            {
                GC.SuppressFinalize(this);
            }

            /// <summary>
            /// Moves to the next item in the collection.
            /// </summary>
            /// <returns>Returns false if there are no more items in the collection.</returns>
            public bool MoveNext()
            {
                if (this.startItem == null || this.endItem == null)
                {
                    return false;
                }
                else if (this.currentItem == null)
                {
                    this.currentItem = this.startItem;
                }
                else if (this.currentItem == this.endItem)
                {
                    this.currentItem = null;
                }
                else
                {
                    this.currentItem = this.currentItem.Next;
                }

                return this.currentItem != null;
            }

            /// <summary>
            /// Resets the enumerator back to the beginning of the collection.
            /// </summary>
            public void Reset()
            {
                this.currentItem = null;
            }

            #endregion Public Methods
        }

        #endregion ForwardNodeEnumerator Class

        #region BackwardNodeEnumerator Class

        /// <summary>
        /// Enumerates backwards through the nodes in the collection.
        /// </summary>
        public class BackwardNodeEnumerator : IEnumerator<Node<T>>
        {
            #region Private Fields

            /// <summary>
            /// The first item in the master list.
            /// </summary>
            private Node<T> startItem;

            /// <summary>
            /// The last item in the master list.
            /// </summary>
            private Node<T> endItem;

            /// <summary>
            /// The current item in the collection.
            /// </summary>
            private Node<T> currentItem;

            #endregion Private Fields

            #region Public Constructors

            /// <summary>
            /// Initializes a new instance of the BackwardNodeEnumerator class.
            /// </summary>
            /// <param name="startItem">The first item in the master list.</param>
            /// <param name="endItem">The last item in the master list.</param>
            public BackwardNodeEnumerator(Node<T> startItem, Node<T> endItem)
            {
                Param.Ignore(startItem);
                Param.Ignore(endItem);

                this.startItem = startItem;
                this.endItem = endItem;
            }

            #endregion Public Constructors

            #region Public Properties

            /// <summary>
            /// Gets the current item.
            /// </summary>
            public Node<T> Current
            {
                get
                {
                    return this.currentItem;
                }
            }

            #endregion Public Properties

            #region IEnumerator Interface Properties

            /// <summary>
            /// Gets the current item.
            /// </summary>
            object System.Collections.IEnumerator.Current
            {
                get
                {
                    return this.currentItem;
                }
            }

            #endregion IEnumerator Interface Properties

            #region Public Methods

            /// <summary>
            /// Disposes the contents of the class.
            /// </summary>
            public void Dispose()
            {
                GC.SuppressFinalize(this);
            }

            /// <summary>
            /// Moves to the next item in the collection.
            /// </summary>
            /// <returns>Returns false if there are no more items in the collection.</returns>
            public bool MoveNext()
            {
                if (this.startItem == null || this.endItem == null)
                {
                    return false;
                }
                else if (this.currentItem == null)
                {
                    this.currentItem = this.startItem;
                }
                else if (this.currentItem == this.endItem)
                {
                    this.currentItem = null;
                }
                else
                {
                    this.currentItem = this.currentItem.Previous;
                }

                return this.currentItem != null;
            }

            /// <summary>
            /// Resets the enumerator back to the beginning of the collection.
            /// </summary>
            public void Reset()
            {
                this.currentItem = null;
            }

            #endregion Public Methods
        }

        #endregion BackwardNodeEnumerator Class
    }
}