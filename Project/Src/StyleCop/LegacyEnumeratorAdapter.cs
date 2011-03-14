//-----------------------------------------------------------------------
// <copyright file="LegacyEnumeratorAdapter.cs">
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
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Adapts an enumerable collection from one format to another.
    /// </summary>
    /// <typeparam name="T">The type of the elements enumerated over.</typeparam>
    public sealed partial class LegacyEnumeratorAdapter<T> : IEnumerator<T>
    {
        #region Private Fields

        /// <summary>
        /// The enumerable collection that is wrapped by this class.
        /// </summary>
        private IEnumerator innerEnumerator;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the LegacyEnumeratorAdapter class.
        /// </summary>
        /// <param name="enumerator">The enumerator to wrap.</param>
        public LegacyEnumeratorAdapter(IEnumerator enumerator)
        {
            Param.Ignore(enumerator);
            this.innerEnumerator = enumerator;
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        /// Gets the inner enumerator wrapped by this adapter.
        /// </summary>
        public IEnumerator InnerEnumerator
        {
            get
            {
                return this.innerEnumerator;
            }
        }

        /// <summary>
        /// Gets the current item.
        /// </summary>
        object System.Collections.IEnumerator.Current
        {
            get
            {
                if (this.innerEnumerator == null)
                {
                    return null;
                }

                return this.innerEnumerator.Current;
            }
        }

        /// <summary>
        /// Gets the current item.
        /// </summary>
        T System.Collections.Generic.IEnumerator<T>.Current 
        {
            get
            {
                if (this.innerEnumerator == null)
                {
                    return default(T);
                }

                return (T)this.innerEnumerator.Current;
            }
        }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Disposes the contents of the class.
        /// </summary>
        public void Dispose()
        {
        }

        /// <summary>
        /// Moves to the next item.
        /// </summary>
        /// <returns>Returns false if there are no more items.</returns>
        bool System.Collections.IEnumerator.MoveNext()
        {
            if (this.innerEnumerator == null)
            {
                return false;
            }

            return this.innerEnumerator.MoveNext();
        }

        /// <summary>
        /// Resets the enumerator.
        /// </summary>
        void System.Collections.IEnumerator.Reset()
        {
            if (this.innerEnumerator != null)
            {
                this.innerEnumerator.Reset();
            }
        }

        #endregion Public Methods
    }
}