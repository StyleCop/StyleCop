// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CodeUnitCollection{T}.cs" company="https://github.com/StyleCop">
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
//   A read-only collection of items.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// A read-only collection of items.
    /// </summary>
    /// <typeparam name="T">
    /// The type of code unit stored in the collection.
    /// </typeparam>
    internal class CodeUnitCollection<T> : ICollection<T>
        where T : IWriteableCodeUnit
    {
        #region Fields

        /// <summary>
        /// The parent of all items in the collection.
        /// </summary>
        private readonly ICodePart parent;

        /// <summary>
        /// The internal collection of items.
        /// </summary>
        private List<T> items;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CodeUnitCollection{T}"/> class. 
        /// Initializes a new instance of the CodeUnitCollection class.
        /// </summary>
        /// <param name="parent">
        /// The parent of all items in the collection.
        /// </param>
        public CodeUnitCollection(ICodePart parent)
        {
            Param.Ignore(parent);
            this.parent = parent;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the number of items in the list.
        /// </summary>
        public int Count
        {
            get
            {
                if (this.items == null)
                {
                    return 0;
                }

                return this.items.Count;
            }
        }

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
        /// Gets the parent of all items in the collection.
        /// </summary>
        public ICodePart Parent
        {
            get
            {
                return this.parent;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Determines whether the given item is contained within the collection.
        /// </summary>
        /// <param name="item">
        /// The item to find.
        /// </param>
        /// <returns>
        /// Returns true if the item is contained within the collection.
        /// </returns>
        public bool Contains(T item)
        {
            Param.Ignore(item);
            return this.items.Contains(item);
        }

        /// <summary>
        /// Copies the collection to the given array.
        /// </summary>
        /// <param name="array">
        /// The array to copy into.
        /// </param>
        /// <param name="arrayIndex">
        /// The index in the array at which to begin copying.
        /// </param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            Param.Ignore(array, arrayIndex);
            this.items.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Gets an enumerator for iterating through the collection.
        /// </summary>
        /// <returns>Returns the enumerator.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return this.items.GetEnumerator();
        }

        #endregion

        #region Explicit Interface Methods

        /// <summary>
        /// Adds an item to the collection.
        /// </summary>
        /// <param name="item">
        /// The item to add.
        /// </param>
        void ICollection<T>.Add(T item)
        {
            Param.Ignore(item);
            throw new NotSupportedException();
        }

        /// <summary>
        /// Clears the collection.
        /// </summary>
        void ICollection<T>.Clear()
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Gets an enumerator for iterating through the collection.
        /// </summary>
        /// <returns>Returns the enumerator.</returns>
        IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.items.GetEnumerator();
        }

        /// <summary>
        /// Removes an item from the collection.
        /// </summary>
        /// <param name="item">
        /// The item to remove.
        /// </param>
        /// <returns>
        /// Returns true if the item was removed.
        /// </returns>
        bool ICollection<T>.Remove(T item)
        {
            Param.Ignore(item);
            throw new NotSupportedException();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Adds an item to the collection.
        /// </summary>
        /// <param name="item">
        /// The item to add to the collection.
        /// </param>
        internal void Add(T item)
        {
            Param.AssertNotNull(item, "item");

            this.InitializeItem(item);

            if (this.items == null)
            {
                this.items = new List<T>();
            }

            this.items.Add(item);
        }

        /// <summary>
        /// Adds a range of items to the collection.
        /// </summary>
        /// <param name="codeUnits">
        /// The range of items to add.
        /// </param>
        internal void AddRange(IEnumerable<T> codeUnits)
        {
            Param.Ignore(codeUnits);

            if (this.items == null)
            {
                this.items = new List<T>();
            }

            if (codeUnits != null)
            {
                foreach (T item in codeUnits)
                {
                    this.InitializeItem(item);
                }
            }

            this.items.AddRange(codeUnits);
        }

        /// <summary>
        /// Clears the contents of the list.
        /// </summary>
        internal void Clear()
        {
            if (this.items != null)
            {
                for (int index = 0; index < this.items.Count; ++index)
                {
                    this.UninitializeItem(this.items[index]);
                }

                if (this.items != null)
                {
                    this.items.Clear();
                }
            }
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
        internal bool Remove(T item)
        {
            Param.Ignore(item);

            if (item != null)
            {
                this.UninitializeItem(item);
            }

            if (this.items != null)
            {
                return this.items.Remove(item);
            }

            return false;
        }

        /// <summary>
        /// Initializes an item when it is added to the list.
        /// </summary>
        /// <param name="item">
        /// The item to initialize.
        /// </param>
        protected virtual void InitializeItem(T item)
        {
            Param.Ignore(item);

            if (item != null)
            {
                item.SetParent(this.parent);
            }
        }

        /// <summary>
        /// Uninitializes an item when it is removed from the list.
        /// </summary>
        /// <param name="item">
        /// The item to uninitialize.
        /// </param>
        protected virtual void UninitializeItem(T item)
        {
            Param.Ignore(item);

            if (item != null)
            {
                item.SetParent(null);
            }
        }

        #endregion
    }
}