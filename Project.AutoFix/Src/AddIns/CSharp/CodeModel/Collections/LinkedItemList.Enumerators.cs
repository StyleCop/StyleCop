//-----------------------------------------------------------------------
// <copyright file="LinkedItemList.Enumerators.cs">
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
namespace StyleCop.CSharp.CodeModel.Collections
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// A set of enumerators for iterating through lists based on the <see cref="LinkedItemList{T}"/> class.
    /// </summary>
    /// <typeparam name="T">The type of item stored in the list.</typeparam>
    internal static class LinkedItemListEnumerators<T> where T : class, ILinkNode<T>
    {
        #region ForwardEnumerable Class
        
        /// <summary>
        /// Provides an enumerator for iterating forward through the items in the list.
        /// </summary>
        public class ForwardEnumerable : IEnumerable<T>
        {
            #region Private Fields

            /// <summary>
            /// The first item in the master list.
            /// </summary>
            private T startItem;

            /// <summary>
            /// The last item in the master list.
            /// </summary>
            private T endItem;

            #endregion Private Fields

            #region Public Constructors

            /// <summary>
            /// Initializes a new instance of the ForwardEnumerable class.
            /// </summary>
            /// <param name="startItem">The first item in the master list.</param>
            /// <param name="endItem">The last item in the master list.</param>
            public ForwardEnumerable(T startItem, T endItem)
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
                return new ForwardEnumerator(this.startItem, this.endItem);
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

        #endregion ForwardEnumerable Class

        #region BackwardEnumerable Class

        /// <summary>
        /// Provides an enumerator for iterating backwards through the items in the list.
        /// </summary>
        public class BackwardEnumerable : IEnumerable<T>
        {
            #region Private Fields

            /// <summary>
            /// The first item in the master list.
            /// </summary>
            private T startItem;

            /// <summary>
            /// The last item in the master list.
            /// </summary>
            private T endItem;

            #endregion Private Fields

            #region Public Constructors

            /// <summary>
            /// Initializes a new instance of the BackwardEnumerable class.
            /// </summary>
            /// <param name="startItem">The first item in the master list.</param>
            /// <param name="endItem">The last item in the master list.</param>
            public BackwardEnumerable(T startItem, T endItem)
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
                return new BackwardEnumerator(this.startItem, this.endItem);
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

        #endregion BackwardEnumerable Class

        #region ForwardEnumerator Class

        /// <summary>
        /// Enumerates fowards through the items in the collection.
        /// </summary>
        public class ForwardEnumerator : IEnumerator<T>
        {
            #region Private Fields

            /// <summary>
            /// The first item in the master list.
            /// </summary>
            private T startItem;

            /// <summary>
            /// The last item in the master list.
            /// </summary>
            private T endItem;

            /// <summary>
            /// The current item in the collection.
            /// </summary>
            private T currentItem;

            #endregion Private Fields

            #region Public Constructors

            /// <summary>
            /// Initializes a new instance of the ForwardEnumerator class.
            /// </summary>
            /// <param name="startItem">The first item in the master list.</param>
            /// <param name="endItem">The last item in the master list.</param>
            public ForwardEnumerator(T startItem, T endItem)
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
                    this.currentItem = this.currentItem.LinkNode.Next;
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

        #endregion ForwardEnumerator Class

        #region BackwardEnumerator Class

        /// <summary>
        /// Enumerates backwards through the items in the collection.
        /// </summary>
        public class BackwardEnumerator : IEnumerator<T>
        {
            #region Private Fields

            /// <summary>
            /// The first item in the master list.
            /// </summary>
            private T startItem;

            /// <summary>
            /// The last item in the master list.
            /// </summary>
            private T endItem;

            /// <summary>
            /// The current item in the collection.
            /// </summary>
            private T currentItem;

            #endregion Private Fields

            #region Public Constructors

            /// <summary>
            /// Initializes a new instance of the BackwardEnumerator class.
            /// </summary>
            /// <param name="startItem">The first item in the master list.</param>
            /// <param name="endItem">The last item in the master list.</param>
            public BackwardEnumerator(T startItem, T endItem)
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
                    this.currentItem = this.currentItem.LinkNode.Previous;
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

        #endregion BackwardEnumerator Class
    }
}
