// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WordCollection.cs" company="https://github.com/StyleCop">
//   MS-PL
// </copyright>
// <summary>
//   Defines the WordCollection type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.Spelling
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;

    internal class WordCollection : ICollection<string>
    {
        #region Fields

        private readonly Dictionary<string, object> words;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="WordCollection"/> class.
        /// </summary>
        /// <param name="comparer">
        /// The comparer.
        /// </param>
        public WordCollection(IEqualityComparer<string> comparer)
        {
            this.words = new Dictionary<string, object>(comparer);
        }

        #endregion

        #region Public Events

        /// <summary>
        /// The collection changed.
        /// </summary>
        public event CollectionChangeEventHandler CollectionChanged;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the count.
        /// </summary>
        public int Count
        {
            get
            {
                return this.words.Count;
            }
        }

        #endregion

        #region Explicit Interface Properties

        bool ICollection<string>.IsReadOnly
        {
            get
            {
                return false;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        public void Add(string item)
        {
            CheckWord(item);
            if (!this.words.ContainsKey(item))
            {
                this.words.Add(item, null);
                this.OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Add, item));
            }
        }

        /// <summary>
        /// The clear.
        /// </summary>
        public void Clear()
        {
            this.words.Clear();
            this.OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Refresh, null));
        }

        /// <summary>
        /// The contains.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <returns>
        /// The System.Boolean.
        /// </returns>
        public bool Contains(string item)
        {
            return this.words.ContainsKey(item);
        }

        /// <summary>
        /// The copy to.
        /// </summary>
        /// <param name="array">
        /// The array.
        /// </param>
        /// <param name="arrayIndex">
        /// The array index.
        /// </param>
        public void CopyTo(string[] array, int arrayIndex)
        {
            this.words.Keys.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// The get enumerator.
        /// </summary>
        /// <returns>
        /// The System.Collections.Generic.IEnumerator`1[T -&gt; System.String].
        /// </returns>
        public IEnumerator<string> GetEnumerator()
        {
            return this.words.Keys.GetEnumerator();
        }

        /// <summary>
        /// The remove.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <returns>
        /// The System.Boolean.
        /// </returns>
        public bool Remove(string item)
        {
            CheckWord(item);
            if (this.words.Remove(item))
            {
                this.OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Remove, item));
                return true;
            }

            return false;
        }

        #endregion

        #region Explicit Interface Methods

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        #endregion

        #region Methods

        internal static bool IsValidWordLength(string item)
        {
            return (item.Length > 0) && (item.Length <= 0x40);
        }

        /// <summary>
        /// The on collection changed.
        /// </summary>
        /// <param name="e">
        /// The e.
        /// </param>
        protected virtual void OnCollectionChanged(CollectionChangeEventArgs e)
        {
            if (this.CollectionChanged != null)
            {
                this.CollectionChanged(this, e);
            }
        }

        private static void CheckWord(string item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            if (!IsValidWordLength(item))
            {
                throw new ArgumentException();
            }
        }

        #endregion
    }
}