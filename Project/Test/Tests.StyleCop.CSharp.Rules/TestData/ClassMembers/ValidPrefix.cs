using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpAnalyzersTest.TestData.ValidPrefixes
{
    public class Class1
    {
        public bool A<T>()
        {
            return B<T>(); // should throw 1101
        }

        private bool B<T>()
        {
            return true;
        }
    }

    public class Class2
    {
        public bool A<T>()
        {
            return B(); // should throw 1101
        }

        private bool B()
        {
            return true;
        }
    }

    public class Class3
    {
        public void A1<T>(T value)
        {
        }

        public virtual void A2<T>(T value)
        {
        }
    }

    //// 1100 - don't use base (only use base if virtual in base class and overridden locally or declared new locally)
    //// 1101 - must use this
    //// 11nn - use this or base 
    /*

    when checking base (must have a BaseClass specified) -
      
    if the method call is 'A1<T>' look for:
      (a method on base class called 'A1<T>' marked virtual AND local method A1 marked override) OR
      method on this class called 'A1<T>' marked new. If found then base is ok.

     ( 'override A1' OR 'new A1<T>' )
     if found base is ok
     
    if the method call is 'A1' look for:
      (a method on base class called 'A1<T>' or 'A1' marked virtual AND local method A1 marked override) OR
      (method on this class called 'A1<T>' marked new) OR 
      (A1<T> on base not virtual AND A1 on this class) OR
      (A1<T> on base not virtual AND A1<T> override on this class)
     If found then base is ok.

     ( 'override A1' OR 'new A1<T>' OR 'override A1<T>' OR 'A1' )
     If found then base is ok.


    if the method call is like 'A1<int>' look for:
      (a method on base class called 'A1<T>' marked virtual AND local method A1 marked override) OR
      method on this class called 'A1'. If found base is ok.

     ( 'override A1' OR 'A1' ) 
     If found then base is ok.
     
     otherwise not needed.
      
    
    when checking for this or base (must have a BaseClass specified):
      
      
     if the method call is like 'A1<T>' look for a method on base class called 'A1<T>' marked virtual OR
     method on this class called 'A1<T>' marked new. If found then 'base or this' are required. 
     
     * ( 'new A1<T>' )
     throw 'ThisOrBaseRequired'
    
     
    if the method call is like 'A1' look for a method on base class called 'A1<T>' or 'A1' marked virtual OR
      method on this class called 'A1<T>' marked new. If found then 'base or this'  is required.

     ( 'new A1<T>' )
     throw 'ThisOrBaseRequired'
    
    
     if the method call is like 'A1<int>' look for a method on base class called 'A1<T>' marked virtual OR
      method on this class called 'A1<T>' marked new. If found then 'base or this' are required.
 
     ( 'new A1<T>' )
     throw 'ThisOrBaseRequired'
     
      
     if the method call is like 'A1' look for a method on base class called 'A1<T>' or 'A1' marked virtual OR
      method on this class called 'A1<T>' marked new. If found then 'base or this'  is required.
     if the method call is like 'A1' look for a method on base class called 'A1<T>' AND
      method on this class called 'A1'. If found then 'base or this'  is required.
  
     ( 'new  A1<T>' OR ' not new not override A1' ) 
     throw 'ThisOrBaseRequired'
     
      
      
      
     when checking for 'this' (no BaseClass specified):
     
     if the method call is 'A1<int>' look for a method on base class called 'A1<T>' marked virtual OR
      method on this class called 'A1<T>'. If both not found then 'this' is required.

     ( ! 'A1<T>' )
     * then this is required
      
      if the method call is 'A1' look for a method on base class called 'A1<T>' marked virtual OR
      method on this class called 'A1<T>' or 'A1'. If both not found then 'this' is required.

     ( ! 'A1<T>' || ! 'A1' ) 
     * this is required
      
     
    
      
    
     Equals, ReferenceEquals and static methods
     
    */



    public class Class4 : Class3
    {
        public new void A1<T>(T value)
        {
            this.A1(value); // should not throw 1100 or 1101 - calling the local method.
            base.A1(value); // should not throw 1100 or 1101 (base is required) - calling the base method.
            this.A1<T>(value); // should not throw 1100 or 1101 - calling the local method.
            base.A1<T>(value); // should not throw 1100 or 1101 (base is required) - calling the base method.
            A1<T>(value); // needs 'this or base' - calling the local method. (but could call base)
            A1(value); // needs 'this or base' - calling the local method. (but could call base)
        }
    }

    public class Class5 : Class3
    {
        public void A1(int value)
        {
            this.A1(value); // should not throw 1100 or 1101 - calling the local method.
            base.A1(value); // should not throw 1100 or 1101 - calling the base method.
            this.A1<int>(value); // should not throw 1100 or 1101 - calling the local method.
            base.A1<int>(value); // should not throw 1100 or 1101 - calling the base method.
            A1<int>(value); // needs 'this or base' - calling the local method.
            A1(value); // needs 'this or base' - calling the local method.
        }

        public new void A1<T>(T value)
        {
            this.A1(value); // should not throw 1100 or 1101 - calling the local method.
            base.A1(value); // should not throw 1100 or 1101 - calling the base method.
            this.A1<T>(value); // should not throw 1100 or 1101 - calling the local method.
            base.A1<T>(value); // should not throw 1100 or 1101 - calling the base method.
            A1<T>(value); // needs 'this or base' - calling the local method.
            A1(value); // needs 'this or base' - calling the local method.
        }
    }

    public class Class6 : Class3
    {
        public void A1(int value)
        {
            this.A1(value); // should not throw 1100 or 1101 - calling the local method.
            base.A1(value); // should not throw 1100 or 1101 - calling the base method.
            this.A1<int>(value); // should not throw 1100 or 1101 - calling the only method.
            base.A1<int>(value); // should throw 1100 swap base to this - calling the only method. *** CAN'T DETECT THIS ***
            A1<int>(value); // should throw 1101 needs 'this' - calling the only method.
            A1(value); // needs 'this or base' - calling the local method.
            A1<bool>(true); // should throw 1101 needs 'this' - calling the only method.
        }
    }

    public class Class7 : Class3
    {
        public new void A1<T>(T value)
        {
        }

        public override void A2<T>(T value)
        {
            this.A1(value); // should not throw 1100 or 1101 - calling the base method.
            base.A1(value); // should not throw 1100 or 1101 (base is required) - calling the base method.
            this.A1<T>(value); // should not throw 1100 or 1101 - calling the local method.
            base.A1<T>(value); // should not throw 1100 or 1101 (base is required) - calling the base method.
            A1<T>(value); // needs 'this or base' - calling the local method. (but could call base)
            A1(value); // needs 'this or base' - calling the local method. (but could call base)

            this.A2(value); // should not throw 1100 or 1101 - calling the local method.
            base.A2(value); // should not throw 1100 or 1101 (base is required) - calling the base method.
            this.A2<T>(value); // should not throw 1100 or 1101 - calling the local method.
            base.A2<T>(value); // should not throw 1100 or 1101 (base is required) - calling the base method.
            A2<T>(value); // needs 'this or base' - calling the local method. (but could call base)
            A2(value); // needs 'this or base' - calling the local method. (but could call base)
        }
    }

    public class Class8 : Class3
    {
        public override void A2<T>(T value)
        {
            this.A1(value); // should not throw 1100 or 1101 - calling the base method.
            base.A1(value); // should throw 1100 (base not required) - calling the base method. 
            this.A1<T>(value); // should not throw 1100 or 1101 - calling the only method.
            base.A1<T>(value); // should throw 1100 (base not required) - calling the only method.
            A1<T>(value); // should throw 1101 needs 'this' - calling the only method.
            A1(value); // should throw 1101 needs 'this' - calling the only method.

            this.A2(value); // should not throw 1100 or 1101 - calling the local method.
            base.A2(value); // should not throw 1100 or 1101 - calling the base method.
            this.A2<T>(value); // should not throw 1100 or 1101 - calling the local method.
            base.A2<T>(value); // should not throw 1100 or 1101 - calling the base method.
            A2<T>(value); // needs 'this or base' - calling the local method. (but could call base)
            A2(value); // needs 'this or base' - calling the local method. (but could call base)
        }
    }

    public class Class9
    {
        public void A2<T>(T value)
        {
            this.A2(value); // should not throw 1100 or 1101 - calling the local method.
            this.A2<T>(value); // should not throw 1100 or 1101 - calling the local method.
            A2<T>(value); // should throw 1101 needs 'this' - calling the only method.
            A2(value); // should throw 1101 needs 'this' - calling the only method.
        }
    }



    /// <summary>
    /// The class 75.
    /// </summary>
    internal class Class75
    {
        #region Fields

        /// <summary>
        /// The dictionary.
        /// </summary>
        private Dictionary<int, string> dictionary;

        /// <summary>
        /// The variable.
        /// </summary>
        private IList<int> variable;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Class75"/> class.
        /// </summary>
        public Class75()
        {
            this.dictionary = new Dictionary<int, string>();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets Property.
        /// </summary>
        /// <value>
        /// The property. 
        /// </value>
        public IList<int> Property
        {
            get
            {
                return (IList<int>)this.variable;
            }
        }

        public Dictionary<int, string> Dictionary
        {
            get
            {
                return (Dictionary<int, string>)this.dictionary;
            }
        }

        #endregion
    }

    /// <summary>
    /// The Deque class implements a type of list known as a Double Ended Queue. A Deque
    /// is quite similar to a List, in that items have indices (starting at 0), and the item at any
    /// index can be efficiently retrieved. The difference between a List and a Deque lies in the
    /// efficiency of inserting elements at the beginning. In a List, items can be efficiently added
    /// to the end, but inserting an item at the beginning of the List is slow, taking time
    /// proportional to the size of the List. In a Deque, items can be added to the beginning
    /// or end equally efficiently, regardless of the number of items in the Deque. As a trade-off
    /// for this increased flexibility, Deque is somewhat slower than List (but still constant time) when
    /// being indexed to get or retrieve elements.
    /// </summary>
    /// <typeparam name="T">The type of items stored in the Deque.</typeparam>
    /// <remarks><para>The Deque class can also be used as a more flexible alternative to the Queue
    /// and Stack classes. Deque is as efficient as Queue and Stack for adding or removing items,
    /// but is more flexible: it allows access
    /// to all items in the queue, and allows adding or removing from either end.</para>
    ///   <para>Deque is implemented as a ring buffer, which is grown as necessary. The size
    /// of the buffer is doubled whenever the existing capacity is too small to hold all the
    /// elements.</para></remarks>
    [Serializable]
    public class Deque<T> : ListBase<T>, ICloneable
    {
        /// <summary>
        /// The initial size of the buffer.
        /// </summary>
        private const int InitialSize = 8;

        /// <summary>
        /// A ring buffer containing all the items in the deque. Shrinks or grows as needed.
        /// Except temporarily during an add, there is always at least one empty item.
        /// </summary>
        private T[] buffer;

        /// <summary>
        /// Index of the first item (index 0) in the deque.
        /// Always in the range 0 through buffer.Length - 1.
        /// </summary>
        private int start;

        /// <summary>
        /// Index just beyond the last item in the deque. If equal to start, the deque is empty.
        /// Always in the range 0 through buffer.Length - 1.
        /// </summary>
        private int end;

        /// <summary>
        ///  Holds the change stamp for the collection.
        /// </summary>
        private int changeStamp;

        #region constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="Deque&lt;T&gt;"/> class.
        /// </summary>
        /// <remarks>Create a new Deque that is initially empty.</remarks>
        public Deque()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Deque&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <remarks>Create a new Deque initialized with the items from the passed collection,  in order.</remarks>
        public Deque(IEnumerable<T> collection)
        {
            this.AddManyToBack(collection);
        }

        #endregion

        #region public sealed override int Count

        /// <summary>
        /// Gets the number of items currently stored in the Deque. The last item
        /// in the Deque has index Count-1.
        /// </summary>
        /// <value>The number of items stored in this Deque.</value>
        /// <remarks>Getting the count of items in the Deque takes a small constant
        /// amount of time.</remarks>
        public override sealed int Count
        {
            get
            {
                if (this.end >= this.start)
                {
                    return this.end - this.start;
                }

                return this.end + this.buffer.Length - this.start;
            }
        }

        #endregion

        #region public int Capacity

        /// <summary>
        /// Gets or sets the capacity of the Deque. The Capacity is the number of
        /// items that this Deque can hold without expanding its internal buffer. Since
        /// Deque will automatically expand its buffer when necessary, in almost all cases
        /// it is unnecessary to worry about the capacity. However, if it is known that a
        /// Deque will contain exactly 1000 items eventually, it can slightly improve
        /// efficiency to set the capacity to 1000 up front, so that the Deque does not
        /// have to expand automatically.
        /// </summary>
        /// <value>The number of items that this Deque can hold without expanding its
        /// internal buffer.</value>
        /// <exception cref="ArgumentOutOfRangeException">The capacity is being set
        /// to less than Count, or to too large a value.</exception>
        /// <remarks>awaiting remarks</remarks>
        public int Capacity
        {
            get
            {
                if (this.buffer == null)
                {
                    return 0;
                }

                return this.buffer.Length - 1;
            }

            set
            {
                if (value < this.Count)
                {
                    throw new ArgumentOutOfRangeException("value", Strings.CapacityLessThanCount);
                }

                if (value > int.MaxValue - 1)
                {
                    throw new ArgumentOutOfRangeException("value");
                }

                if (value == this.Capacity)
                {
                    return;
                }

                var newBuffer = new T[value + 1];
                this.CopyTo(newBuffer, 0);
                this.end = this.Count;
                this.start = 0;
                this.buffer = newBuffer;
            }
        }

        #endregion

        #region public sealed override T this[int index]

        /// <summary>
        /// Gets or sets an item at a particular index in the Deque.
        /// </summary>
        /// <param name="index">The index in the Deque of the item.</param>
        /// <returns>The value at the indicated index.</returns>
        /// <typeparam name="T">The type of items stored in the Deque.</typeparam>
        /// <exception cref="ArgumentOutOfRangeException">The index is less than zero or greater than or equal
        /// to Count.</exception>
        /// <remarks>Getting or setting the item at a particular index takes a small constant amount
        /// of time, no matter what index is used.</remarks>
        public override sealed T this[int index]
        {
            get
            {
                var i = index + this.start;

                // handles both the case where index < 0, or the above addition overflow to a negative number.
                if (i < this.start)
                {
                    throw new ArgumentOutOfRangeException("index");
                }

                if (this.end >= this.start)
                {
                    if (i >= this.end)
                    {
                        throw new ArgumentOutOfRangeException("index");
                    }

                    return this.buffer[i];
                }

                var length = this.buffer.Length;
                if (i >= length)
                {
                    i -= length;
                    if (i >= this.end)
                    {
                        throw new ArgumentOutOfRangeException("index");
                    }
                }

                return this.buffer[i];
            }

            set
            {
                // Like List<T>, we stop enumerations after a set operation. There is no
                // technical reason to do this, however.
                this.StopEnumerations();

                var i = index + this.start;

                // handles both the case where index < 0, or the above addition overflow to a negative number.
                if (i < this.start)
                {
                    throw new ArgumentOutOfRangeException("index");
                }

                if (this.end >= this.start)
                {
                    if (i >= this.end)
                    {
                        throw new ArgumentOutOfRangeException("index");
                    }

                    this.buffer[i] = value;
                }
                else
                {
                    var length = this.buffer.Length;
                    if (i >= length)
                    {
                        i -= length;
                        if (i >= this.end)
                        {
                            throw new ArgumentOutOfRangeException("index");
                        }
                    }

                    this.buffer[i] = value;
                }
            }
        }

        #endregion

        #region public sealed override void CopyTo(T[] array, int arrayIndex)

        /// <summary>
        /// Copies all the items in the Deque into an array.
        /// </summary>
        /// <param name="array">Array to copy to.</param>
        /// <param name="arrayIndex">Starting index in <paramref name="array"/> to copy to.</param>
        /// <remarks>awaiting remarks</remarks>
        public override sealed void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException("array");
            }

            // This override is provided to give a more efficient implementation to CopyTo than
            // the default one provided by CollectionBase.
            var length = (this.buffer == null) ? 0 : this.buffer.Length;

            if (this.start > this.end)
            {
                Array.Copy(this.buffer, this.start, array, arrayIndex, length - this.start);
                Array.Copy(this.buffer, 0, array, arrayIndex + length - this.start, this.end);
            }
            else
            {
                if (this.end > this.start)
                {
                    Array.Copy(this.buffer, this.start, array, arrayIndex, this.end - this.start);
                }
            }
        }

        #endregion

        #region public void TrimToSize()

        /// <summary>
        /// Trims the amount of memory used by the Deque by changing
        /// the Capacity to be equal to Count. If no more items will be added
        /// to the Deque, calling TrimToSize will reduce the amount of memory
        /// used by the Deque.
        /// </summary>
        /// <remarks>awaiting remarks</remarks>
        public void TrimToSize()
        {
            this.Capacity = this.Count;
        }

        #endregion

        #region public sealed override void Clear()

        /// <summary>
        /// Removes all items from the Deque.
        /// </summary>
        /// <remarks>Clearing the Deque takes a small constant amount of time, regardless of
        /// how many items are currently in the Deque.</remarks>
        public override sealed void Clear()
        {
            this.StopEnumerations();
            this.buffer = null;
            this.start = this.end = 0;
        }

        #endregion

        #region public sealed override IEnumerator<T> GetEnumerator()

        /// <summary>
        /// Enumerates all of the items in the list, in order. The item at index 0
        /// is enumerated first, then the item at index 1, and so on. If the items
        /// are added to or removed from the Deque during enumeration, the
        /// enumeration ends with an InvalidOperationException.
        /// </summary>
        /// <returns>An IEnumerator&lt;T&gt; that enumerates all the
        /// items in the list.</returns>
        /// <exception cref="InvalidOperationException">The Deque has an item added or deleted during the enumeration.</exception>
        /// <remarks>awaiting remarks</remarks>
        public override sealed IEnumerator<T> GetEnumerator()
        {
            var startStamp = this.changeStamp;
            var count = this.Count;
            for (var i = 0; i < count; ++i)
            {
                yield return this[i];
                this.CheckEnumerationStamp(startStamp);
            }
        }

        #endregion

        #region public sealed override void Insert(int index, T item)

        /// <summary>
        /// Inserts a new item at the given index in the Deque. All items at indexes
        /// equal to or greater than <paramref name="index"/> move up one index
        /// in the Deque.
        /// </summary>
        /// <param name="index">The index in the Deque to insert the item at. After the
        /// insertion, the inserted item is located at this index. The
        /// front item in the Deque has index 0.</param>
        /// <param name="item">The item to insert at the given index.</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="index"/> is
        /// less than zero or greater than Count.</exception>
        /// <remarks>The amount of time to insert an item in the Deque is proportional
        /// to the distance of index from the closest end of the Deque:
        /// O(Min(<paramref name="index"/>, Count - <paramref name="index"/>)).
        /// Thus, inserting an item at the front or end of the Deque is always fast; the middle of
        /// of the Deque is the slowest place to insert.</remarks>
        public override sealed void Insert(int index, T item)
        {
            this.StopEnumerations();
            var count = this.Count;
            if (index < 0 || index > this.Count)
            {
                throw new ArgumentOutOfRangeException("index");
            }

            if (this.buffer == null)
            {
                // The buffer hasn't been created yet.
                this.CreateInitialBuffer(item);
                return;
            }

            var length = this.buffer.Length;
            int i; // The location the new item was placed at.

            if (index < count / 2)
            {
                // Inserting into the first half of the list. Move items with
                // lower index down in the buffer.
                this.start -= 1;
                if (this.start < 0)
                {
                    this.start += length;
                }

                i = index + this.start;
                if (i >= length)
                {
                    i -= length;
                    if (length - 1 > this.start)
                    {
                        Array.Copy(this.buffer, this.start + 1, this.buffer, this.start, length - 1 - this.start);
                    }

                    this.buffer[length - 1] = this.buffer[0]; // unneeded if end == 0, but doesn't hurt
                    if (i > 0)
                    {
                        Array.Copy(this.buffer, 1, this.buffer, 0, i);
                    }
                }
                else
                {
                    if (i > this.start)
                    {
                        Array.Copy(this.buffer, this.start + 1, this.buffer, this.start, i - this.start);
                    }
                }
            }
            else
            {
                // Inserting into the last half of the list. Move items with higher
                // index up in the buffer.
                i = index + this.start;
                if (i >= length)
                {
                    i -= length;
                }

                if (i <= this.end)
                {
                    if (this.end > i)
                    {
                        Array.Copy(this.buffer, i, this.buffer, i + 1, this.end - i);
                    }

                    this.end += 1;
                    if (this.end >= length)
                    {
                        this.end -= length;
                    }
                }
                else
                {
                    if (this.end > 0)
                    {
                        Array.Copy(this.buffer, 0, this.buffer, 1, this.end);
                    }

                    this.buffer[0] = this.buffer[length - 1];
                    if (length - 1 > i)
                    {
                        Array.Copy(this.buffer, i, this.buffer, i + 1, length - 1 - i);
                    }

                    this.end += 1;
                }
            }

            this.buffer[i] = item;
            if (this.start == this.end)
            {
                this.IncreaseBuffer();
            }
        }

        #endregion

        #region public void InsertRange(int index, IEnumerable<T> collection)

        /// <summary>
        /// Inserts a collection of items at the given index in the Deque. All items at indexes
        /// equal to or greater than <paramref name="index"/> increase their indices in the Deque
        /// by the number of items inserted.
        /// </summary>
        /// <param name="index">The index in the Deque to insert the collection at. After the
        /// insertion, the first item of the inserted collection is located at this index. The
        /// front item in the Deque has index 0.</param>
        /// <param name="collection">The collection of items to insert at the given index.</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="index"/> is
        /// less than zero or greater than Count.</exception>
        /// <remarks>The amount of time to insert a collection in the Deque is proportional
        /// to the distance of index from the closest end of the Deque, plus the number of items
        /// inserted (M):
        /// O(M + Min(<paramref name="index"/>, Count - <paramref name="index"/>)).</remarks>
        public void InsertRange(int index, IEnumerable<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("collection");
            }

            this.StopEnumerations();

            var count = this.Count;
            if (index < 0 || index > this.Count)
            {
                throw new ArgumentOutOfRangeException("index");
            }

            // We need an ICollection, because we need the count of the collection.
            // If needed, copy the items to a temporary list.
            ICollection<T> coll;
            if (collection is ICollection<Deque<T>>)
            {
                coll = (ICollection<T>)collection;
            }
            else
            {
                coll = new List<T>(collection);
            }

            if (coll.Count == 0)
            {
                return; // nothing to do.
            }

            // Create enough capacity in the list for the new items.
            if (this.Capacity < this.Count + coll.Count)
            {
                this.Capacity = this.Count + coll.Count;
            }

            var length = this.buffer.Length;
            int s, d;

            if (index < count / 2)
            {
                // Inserting into the first half of the list. Move items with
                // lower index down in the buffer.
                s = this.start;
                d = s - coll.Count;
                if (d < 0)
                {
                    d += length;
                }

                this.start = d;
                var c = index;

                while (c > 0)
                {
                    var chunk = c;
                    if (length - d < chunk)
                    {
                        chunk = length - d;
                    }

                    if (length - s < chunk)
                    {
                        chunk = length - s;
                    }

                    Array.Copy(this.buffer, s, this.buffer, d, chunk);
                    c -= chunk;
                    if ((d += chunk) >= length)
                    {
                        d -= length;
                    }

                    if ((s += chunk) >= length)
                    {
                        s -= length;
                    }
                }
            }
            else
            {
                // Inserting into the last half of the list. Move items with higher
                // index up in the buffer.
                s = this.end;
                d = s + coll.Count;
                if (d >= length)
                {
                    d -= length;
                }

                this.end = d;
                var move = count - index; // number of items at end to move

                var c = move;
                while (c > 0)
                {
                    var chunk = c;
                    if (d > 0 && d < chunk)
                    {
                        chunk = d;
                    }

                    if (s > 0 && s < chunk)
                    {
                        chunk = s;
                    }

                    if ((d -= chunk) < 0)
                    {
                        d += length;
                    }

                    if ((s -= chunk) < 0)
                    {
                        s += length;
                    }

                    Array.Copy(this.buffer, s, this.buffer, d, chunk);
                    c -= chunk;
                }

                d -= coll.Count;
                if (d < 0)
                {
                    d += length;
                }
            }

            // Copy the items into the space vacated, which starts at d.
            foreach (var item in coll)
            {
                this.buffer[d] = item;
                if (++d >= length)
                {
                    d -= length;
                }
            }
        }

        #endregion

        #region public sealed override void RemoveAt(int index)

        /// <summary>
        /// Removes the item at the given index in the Deque. All items at indexes
        /// greater than <paramref name="index"/> move down one index
        /// in the Deque.
        /// </summary>
        /// <param name="index">The index in the list to remove the item at. The
        /// first item in the list has index 0.</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="index"/> is
        /// less than zero or greater than or equal to Count.</exception>
        /// <remarks>The amount of time to delete an item in the Deque is proportional
        /// to the distance of index from the closest end of the Deque:
        /// O(Min(<paramref name="index"/>, Count - 1 - <paramref name="index"/>)).
        /// Thus, deleting an item at the front or end of the Deque is always fast; the middle of
        /// of the Deque is the slowest place to delete.</remarks>
        public override sealed void RemoveAt(int index)
        {
            this.StopEnumerations();

            var count = this.Count;

            if (index < 0 || index >= count)
            {
                throw new ArgumentOutOfRangeException("index");
            }

            var length = this.buffer.Length;
            int i; // index of removed item
            if (index < count / 2)
            {
                // Removing in the first half of the list. Move items with
                // lower index up in the buffer.
                i = index + this.start;

                if (i >= length)
                {
                    i -= length;

                    if (i > 0)
                    {
                        Array.Copy(this.buffer, 0, this.buffer, 1, i);
                    }

                    this.buffer[0] = this.buffer[length - 1];
                    if (length - 1 > this.start)
                    {
                        Array.Copy(this.buffer, this.start, this.buffer, this.start + 1, length - 1 - this.start);
                    }
                }
                else
                {
                    if (i > this.start)
                    {
                        Array.Copy(this.buffer, this.start, this.buffer, this.start + 1, i - this.start);
                    }
                }

                this.buffer[this.start] = default(T);
                this.start += 1;
                if (this.start >= length)
                {
                    this.start -= length;
                }
            }
            else
            {
                // Removing in the second half of the list. Move items with
                // higher indexes down in the buffer.
                i = index + this.start;
                if (i >= length)
                {
                    i -= length;
                }

                this.end -= 1;
                if (this.end < 0)
                {
                    this.end = length - 1;
                }

                if (i <= this.end)
                {
                    if (this.end > i)
                    {
                        Array.Copy(this.buffer, i + 1, this.buffer, i, this.end - i);
                    }
                }
                else
                {
                    if (length - 1 > i)
                    {
                        Array.Copy(this.buffer, i + 1, this.buffer, i, length - 1 - i);
                    }

                    this.buffer[length - 1] = this.buffer[0];
                    if (this.end > 0)
                    {
                        Array.Copy(this.buffer, 1, this.buffer, 0, this.end);
                    }
                }

                this.buffer[this.end] = default(T);
            }
        }

        #endregion

        #region public void RemoveRange(int index, int count)

        /// <summary>
        /// Removes a range of items at the given index in the Deque. All items at indexes
        /// greater than <paramref name="index"/> move down <paramref name="count"/> indices
        /// in the Deque.
        /// </summary>
        /// <param name="index">The index in the list to remove the range at. The
        /// first item in the list has index 0.</param>
        /// <param name="count">The number of items to remove.</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="index"/> is
        /// less than zero or greater than or equal to Count, or <paramref name="count"/> is less than zero
        /// or too large.</exception>
        /// <remarks>The amount of time to delete <paramref name="count"/> items in the Deque is proportional
        /// to the distance to the closest end of the Deque:
        /// O(Min(<paramref name="index"/>, Count - <paramref name="index"/> - <paramref name="count"/>)).</remarks>
        public void RemoveRange(int index, int count)
        {
            this.StopEnumerations();
            var dequeCount = this.Count;

            if (index < 0 || index >= dequeCount)
            {
                throw new ArgumentOutOfRangeException("index");
            }

            if (count < 0 || count > dequeCount - index)
            {
                throw new ArgumentOutOfRangeException("count");
            }

            if (count == 0)
            {
                return;
            }

            var length = this.buffer.Length;
            int s, d;
            if (index < dequeCount / 2)
            {
                // Removing in the first half of the list. Move items with
                // lower index up in the buffer.
                s = this.start + index;
                if (s >= length)
                {
                    s -= length;
                }

                d = s + count;
                if (d >= length)
                {
                    d -= length;
                }

                var c = index;
                while (c > 0)
                {
                    var chunk = c;
                    if (d > 0 && d < chunk)
                    {
                        chunk = d;
                    }

                    if (s > 0 && s < chunk)
                    {
                        chunk = s;
                    }

                    if ((d -= chunk) < 0)
                    {
                        d += length;
                    }

                    if ((s -= chunk) < 0)
                    {
                        s += length;
                    }

                    Array.Copy(this.buffer, s, this.buffer, d, chunk);
                    c -= chunk;
                }

                // At this point, s == start
                for (c = 0; c < count; ++c)
                {
                    this.buffer[s] = default(T);
                    if (++s >= length)
                    {
                        s -= length;
                    }
                }

                this.start = s;
            }
            else
            {
                // Removing in the second half of the list. Move items with
                // higher indexes down in the buffer.
                var move = dequeCount - index - count;
                s = this.end - move;
                if (s < 0)
                {
                    s += length;
                }

                d = s - count;
                if (d < 0)
                {
                    d += length;
                }

                var c = move;
                while (c > 0)
                {
                    var chunk = c;
                    if (length - d < chunk)
                    {
                        chunk = length - d;
                    }

                    if (length - s < chunk)
                    {
                        chunk = length - s;
                    }

                    Array.Copy(this.buffer, s, this.buffer, d, chunk);
                    c -= chunk;
                    if ((d += chunk) >= length)
                    {
                        d -= length;
                    }

                    if ((s += chunk) >= length)
                    {
                        s -= length;
                    }
                }

                // At this point, s == end.
                for (c = 0; c < count; ++c)
                {
                    if (--s < 0)
                    {
                        s += length;
                    }

                    this.buffer[s] = default(T);
                }

                this.end = s;
            }
        }

        #endregion

        #region public void AddToFront(T item)

        /// <summary>
        /// Adds an item to the front of the Deque. The indices of all existing items
        /// in the Deque are increased by 1. This method is
        /// equivalent to <c>Insert(0, item)</c> but is a little more
        /// efficient.
        /// </summary>
        /// <param name="item">The item to add.</param>
        /// <remarks>Adding an item to the front of the Deque takes
        /// a small constant amount of time, regardless of how many items are in the Deque.</remarks>
        public void AddToFront(T item)
        {
            this.StopEnumerations();

            if (this.buffer == null)
            {
                // The buffer hasn't been created yet.
                this.CreateInitialBuffer(item);
                return;
            }

            if (--this.start < 0)
            {
                this.start += this.buffer.Length;
            }

            this.buffer[this.start] = item;
            if (this.start == this.end)
            {
                this.IncreaseBuffer();
            }
        }

        #endregion

        #region public void AddManyToFront(IEnumerable<T> collection)

        /// <summary>
        /// Adds a collection of items to the front of the Deque. The indices of all existing items
        /// in the Deque are increased by the number of items inserted. The first item in the added collection becomes the
        /// first item in the Deque.
        /// </summary>
        /// <param name="collection">The collection of items to add.</param>
        /// <remarks>This method takes time O(M), where M is the number of items in the
        /// <paramref name="collection"/>.</remarks>
        public void AddManyToFront(IEnumerable<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("collection");
            }

            this.InsertRange(0, collection);
        }

        #endregion

        #region public void AddToBack(T item)

        /// <summary>
        /// Adds an item to the back of the Deque. The indices of all existing items
        /// in the Deque are unchanged. This method is
        /// equivalent to <c>Insert(Count, item)</c> but is a little more
        /// efficient.
        /// </summary>
        /// <param name="item">The item to add.</param>
        /// <remarks>Adding an item to the back of the Deque takes
        /// a small constant amount of time, regardless of how many items are in the Deque.</remarks>
        public void AddToBack(T item)
        {
            this.StopEnumerations();
            if (this.buffer == null)
            {
                // The buffer hasn't been created yet.
                this.CreateInitialBuffer(item);
                return;
            }

            this.buffer[this.end] = item;
            if (++this.end >= this.buffer.Length)
            {
                this.end -= this.buffer.Length;
            }

            if (this.start == this.end)
            {
                this.IncreaseBuffer();
            }
        }

        #endregion

        #region public sealed override void Add(T item)

        /// <summary>
        /// Adds an item to the back of the Deque. The indices of all existing items
        /// in the Deque are unchanged. This method is
        /// equivalent to <c>AddToBack(item)</c>.
        /// </summary>
        /// <param name="item">The item to add.</param>
        /// <remarks>Adding an item to the back of the Deque takes
        /// a small constant amount of time, regardless of how many items are in the Deque.</remarks>
        public override sealed void Add(T item)
        {
            this.AddToBack(item);
        }

        #endregion

        #region public void AddManyToBack(IEnumerable<T> collection)

        /// <summary>
        /// Adds a collection of items to the back of the Deque. The indices of all existing items
        /// in the Deque are unchanged. The last item in the added collection becomes the
        /// last item in the Deque.
        /// </summary>
        /// <param name="collection">The collection of item to add.</param>
        /// <remarks>This method takes time O(M), where M is the number of items in the
        /// <paramref name="collection"/>.</remarks>
        public void AddManyToBack(IEnumerable<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("collection");
            }

            foreach (var item in collection)
            {
                this.AddToBack(item);
            }
        }

        #endregion

        #region public T RemoveFromFront()

        /// <summary>
        /// Removes an item from the front of the Deque. The indices of all existing items
        /// in the Deque are decreased by 1. This method is
        /// equivalent to <c>RemoveAt(0)</c> but is a little more
        /// efficient.
        /// </summary>
        /// <returns>The item that was removed.</returns>
        /// <exception cref="InvalidOperationException">The Deque is empty.</exception>
        /// <remarks>Removing an item from the front of the Deque takes
        /// a small constant amount of time, regardless of how many items are in the Deque.</remarks>
        public T RemoveFromFront()
        {
            if (this.start == this.end)
            {
                throw new InvalidOperationException(Strings.CollectionIsEmpty);
            }

            this.StopEnumerations();

            var item = this.buffer[this.start];
            this.buffer[this.start] = default(T);
            if (++this.start >= this.buffer.Length)
            {
                this.start -= this.buffer.Length;
            }

            return item;
        }

        #endregion

        #region public T RemoveFromBack()

        /// <summary>
        /// Removes an item from the back of the Deque. The indices of all existing items
        /// in the Deque are unchanged. This method is
        /// equivalent to <c>RemoveAt(Count-1)</c> but is a little more
        /// efficient.
        /// </summary>
        /// <returns>Type T</returns>
        /// <exception cref="InvalidOperationException">The Deque is empty.</exception>
        /// <remarks>Removing an item from the back of the Deque takes
        /// a small constant amount of time, regardless of how many items are in the Deque.</remarks>
        public T RemoveFromBack()
        {
            if (this.start == this.end)
            {
                throw new InvalidOperationException(Strings.CollectionIsEmpty);
            }

            this.StopEnumerations();

            if (--this.end < 0)
            {
                this.end += this.buffer.Length;
            }

            var item = this.buffer[this.end];
            this.buffer[this.end] = default(T);
            return item;
        }

        #endregion

        #region public T GetAtFront()

        /// <summary>
        /// Retreives the item currently at the front of the Deque. The Deque is
        /// unchanged. This method is
        /// equivalent to <c>deque[0]</c> (except that a different exception is thrown).
        /// </summary>
        /// <returns>The item at the front of the Deque.</returns>
        /// <exception cref="InvalidOperationException">The Deque is empty.</exception>
        /// <remarks>Retreiving the item at the front of the Deque takes
        /// a small constant amount of time, regardless of how many items are in the Deque.</remarks>
        public T GetAtFront()
        {
            if (this.start == this.end)
            {
                throw new InvalidOperationException(Strings.CollectionIsEmpty);
            }

            return this.buffer[this.start];
        }

        #endregion

        #region public T GetAtBack()

        /// <summary>
        /// Retreives the item currently at the back of the Deque. The Deque is
        /// unchanged. This method is
        /// equivalent to <c>deque[deque.Count - 1]</c> (except that a different exception is thrown).
        /// </summary>
        /// <returns>The item at the back of the Deque.</returns>
        /// <exception cref="InvalidOperationException">The Deque is empty.</exception>
        /// <remarks>Retreiving the item at the back of the Deque takes
        /// a small constant amount of time, regardless of how many items are in the Deque.</remarks>
        public T GetAtBack()
        {
            if (this.start == this.end)
            {
                throw new InvalidOperationException(Strings.CollectionIsEmpty);
            }

            if (this.end == 0)
            {
                return this.buffer[this.buffer.Length - 1];
            }

            return this.buffer[this.end - 1];
        }

        #endregion

        #region public Deque<T> Clone()

        /// <summary>
        /// Creates a new Deque that is a copy of this one.
        /// </summary>
        /// <returns>A copy of the current deque.</returns>
        /// <remarks>Copying a Deque takes O(N) time, where N is the number of items in this Deque..</remarks>
        public Deque<T> Clone()
        {
            return new Deque<T>(this);
        }

        #endregion

        #region object ICloneable.Clone()

        /// <summary>
        /// Creates a new Deque that is a copy of this one.
        /// </summary>
        /// <returns>A copy of the current deque.</returns>
        /// <remarks>Copying a Deque takes O(N) time, where N is the number of items in this Deque..</remarks>
        object ICloneable.Clone()
        {
            return this.Clone();
        }

        #endregion

        #region public Deque<T> CloneContents()

        /// <summary>
        /// Makes a deep clone of this Deque. A new Deque is created with a clone of
        /// each element of this set, by calling ICloneable.Clone on each element. If T is
        /// a value type, then each element is copied as if by simple assignment.
        /// </summary>
        /// <returns>The cloned Deque.</returns>
        /// <exception cref="InvalidOperationException">T is a reference type that does not implement ICloneable.</exception>
        /// <remarks><para>If T is a reference type, it must implement
        /// ICloneable. Otherwise, an InvalidOperationException is thrown.</para>
        /// <para>Cloning the Deque takes time O(N), where N is the number of items in the Deque.</para></remarks>
        public Deque<T> CloneContents()
        {
            bool itemIsValueType;
            if (!Util.IsCloneableType(typeof(T), out itemIsValueType))
            {
                throw new InvalidOperationException(string.Format(Strings.TypeNotCloneable, typeof(T).FullName));
            }

            var clone = new Deque<T>();

            // Clone each item, and add it to the new ordered set.
            foreach (var item in this)
            {
                T itemClone;
                if (itemIsValueType)
                {
                    itemClone = item;
                }
                else
                {
                    if (item == null)
                    {
                        itemClone = default(T); // Really null, because we know T is a reference type
                    }
                    else
                    {
                        itemClone = (T)((ICloneable)item).Clone();
                    }
                }

                clone.AddToBack(itemClone);
            }

            return clone;
        }

        #endregion

        #region internal void Print()

#if DEBUG
        /// <summary>
        /// Print out the internal state of the Deque for debugging.
        /// </summary>
        /// <remarks>awaiting remarks</remarks>
        internal void Print()
        {
            Console.WriteLine("length={0}  start={1}  end={2}", this.buffer.Length, this.start, this.end);
            for (var i = 0; i < this.buffer.Length; ++i)
            {
                Console.Write(i == this.start ? "start-> " : "        ");
                Console.Write(i == this.end ? "end-> " : "      ");
                Console.WriteLine("{0,4} {1}", i, this.buffer[i]);
            }

            Console.WriteLine();
        }
#endif
        // DEBUG

        #endregion

        #region private void CreateInitialBuffer(T firstItem)

        /// <summary>
        /// Creates the initial buffer and initialized the Deque to contain one initial
        /// item.
        /// </summary>
        /// <param name="firstItem">First and only item for the Deque.</param>
        /// <remarks>awaiting remarks</remarks>
        private void CreateInitialBuffer(T firstItem)
        {
            // The buffer hasn't been created yet.
            this.buffer = new T[InitialSize];
            this.start = 0;
            this.end = 1;
            this.buffer[0] = firstItem;
            return;
        }

        #endregion

        #region private void IncreaseBuffer()

        /// <summary>
        /// Increase the amount of buffer space. When calling this method, the Deque
        /// must not be empty. If start and end are equal, that indicates a completely
        /// full Deque.
        /// </summary>
        /// <remarks>awaiting remarks</remarks>
        private void IncreaseBuffer()
        {
            var count = this.Count;
            var length = this.buffer.Length;

            var newBuffer = new T[length * 2];
            if (this.start >= this.end)
            {
                Array.Copy(this.buffer, this.start, newBuffer, 0, length - this.start);
                Array.Copy(this.buffer, 0, newBuffer, length - this.start, this.end);
                this.end = this.end + length - this.start;
                this.start = 0;
            }
            else
            {
                Array.Copy(this.buffer, this.start, newBuffer, 0, this.end - this.start);
                this.end = this.end - this.start;
                this.start = 0;
            }

            this.buffer = newBuffer;
        }

        #endregion

        #region private void StopEnumerations()

        /// <summary>
        /// Must be called whenever there is a structural change in the tree. Causes
        /// changeStamp to be changed, which causes any in-progress enumerations
        /// to throw exceptions.
        /// </summary>
        /// <remarks>awaiting remarks</remarks>
        private void StopEnumerations()
        {
            ++this.changeStamp;
        }

        #endregion

        #region private void CheckEnumerationStamp(int startStamp)

        /// <summary>
        /// Checks the given stamp against the current change stamp. If different, the
        /// collection has changed during enumeration and an InvalidOperationException
        /// must be thrown
        /// </summary>
        /// <param name="startStamp">changeStamp at the start of the enumeration.</param>
        /// <remarks>awaiting remarks</remarks>
        private void CheckEnumerationStamp(int startStamp)
        {
            if (startStamp != this.changeStamp)
            {
                throw new InvalidOperationException(Strings.ChangeDuringEnumeration);
            }
        }

        #endregion
    }

    public class TypeOfCheck
    {
        public void Method1()
        {
            var a = typeof(PagedEntities<Series>); // valid
            var b = typeof(Series); // valid
        }
    }

    public class TypeOfCheck2 : OperationHandler
    {
        public void Method1()
        {
            var a = typeof(PagedEntities<Series>); // valid
            var b = typeof(Series); // valid
            Debug.Assert(
                getOperation.TargetEntityType == typeof(Device) || getOperation.TargetEntityType == typeof(PagedEntities<Device>), "This has been checked in CanHandle"); // valid
        }
    }
}
