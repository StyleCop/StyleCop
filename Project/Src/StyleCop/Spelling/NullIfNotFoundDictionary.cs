
namespace StyleCop.Spelling
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;

    [DebuggerDisplay("Count = {Count}")]
    [Serializable]
    internal class NullIfNotFoundDictionary<TKey, TValue> : IDictionary<TKey, TValue>
        where TValue : class
    {
        #region Fields

        private readonly Dictionary<TKey, TValue> dictionary;

        #endregion

        #region Constructors and Destructors

        public NullIfNotFoundDictionary()
        {
            this.dictionary = new Dictionary<TKey, TValue>();
        }

        public NullIfNotFoundDictionary(int capacity)
        {
            this.dictionary = new Dictionary<TKey, TValue>(capacity);
        }

        public NullIfNotFoundDictionary(IEqualityComparer<TKey> comparer)
        {
            this.dictionary = new Dictionary<TKey, TValue>(comparer);
        }

        public NullIfNotFoundDictionary(IDictionary<TKey, TValue> dictionary)
        {
            this.dictionary = new Dictionary<TKey, TValue>(dictionary);
        }

        public NullIfNotFoundDictionary(int capacity, IEqualityComparer<TKey> comparer)
        {
            this.dictionary = new Dictionary<TKey, TValue>(capacity, comparer);
        }

        public NullIfNotFoundDictionary(IDictionary<TKey, TValue> dictionary, IEqualityComparer<TKey> comparer)
        {
            this.dictionary = new Dictionary<TKey, TValue>(dictionary, comparer);
        }

        #endregion

        #region Public Properties

        public int Count
        {
            get
            {
                return this.dictionary.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                ICollection<KeyValuePair<TKey, TValue>> collection = this.dictionary;
                return collection.IsReadOnly;
            }
        }

        public ICollection<TKey> Keys
        {
            get
            {
                return this.dictionary.Keys;
            }
        }

        public ICollection<TValue> Values
        {
            get
            {
                return this.dictionary.Values;
            }
        }

        #endregion

        #region Public Indexers

        public TValue this[TKey key]
        {
            get
            {
                TValue result;
                if (!this.TryGetValue(key, out result))
                {
                    return default(TValue);
                }
                return result;
            }
            set
            {
                this.dictionary[key] = value;
            }
        }

        #endregion

        #region Public Methods and Operators

        public void Add(TKey key, TValue value)
        {
            this.dictionary.Add(key, value);
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            ICollection<KeyValuePair<TKey, TValue>> collection = this.dictionary;
            collection.Add(item);
        }

        public void Clear()
        {
            this.dictionary.Clear();
        }

        public bool Contains(TKey key)
        {
            return this.ContainsKey(key);
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            ICollection<KeyValuePair<TKey, TValue>> collection = this.dictionary;
            return collection.Contains(item);
        }

        public bool ContainsKey(TKey key)
        {
            return this.dictionary.ContainsKey(key);
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            ICollection<KeyValuePair<TKey, TValue>> collection = this.dictionary;
            collection.CopyTo(array, arrayIndex);
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            ICollection<KeyValuePair<TKey, TValue>> collection = this.dictionary;
            return collection.GetEnumerator();
        }

        public bool Remove(TKey key)
        {
            return this.dictionary.Remove(key);
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            ICollection<KeyValuePair<TKey, TValue>> collection = this.dictionary;
            return collection.Remove(item);
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            return this.dictionary.TryGetValue(key, out value);
        }

        #endregion

        #region Explicit Interface Methods

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        #endregion
    }
}