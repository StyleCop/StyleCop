
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

        public WordCollection(IEqualityComparer<string> comparer)
        {
            this.words = new Dictionary<string, object>(comparer);
        }

        #endregion

        #region Public Events

        public event CollectionChangeEventHandler CollectionChanged;

        #endregion

        #region Public Properties

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

        public void Add(string item)
        {
            CheckWord(item);
            if (!this.words.ContainsKey(item))
            {
                this.words.Add(item, null);
                this.OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Add, item));
            }
        }

        public void Clear()
        {
            this.words.Clear();
            this.OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Refresh, null));
        }

        public bool Contains(string item)
        {
            return this.words.ContainsKey(item);
        }

        public void CopyTo(string[] array, int arrayIndex)
        {
            this.words.Keys.CopyTo(array, arrayIndex);
        }

        public IEnumerator<string> GetEnumerator()
        {
            return this.words.Keys.GetEnumerator();
        }

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
            return ((item.Length > 0) && (item.Length <= 0x40));
        }

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