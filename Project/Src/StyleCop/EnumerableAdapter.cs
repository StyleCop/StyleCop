// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EnumerableAdapter.cs" company="https://github.com/StyleCop">
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
//   Event handler for converting elements within an adapted collection.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Event handler for converting elements within an adapted collection.
    /// </summary>
    /// <typeparam name="TOriginal">
    /// The type of the elements stored in the original collection.
    /// </typeparam>
    /// <typeparam name="TAdapted">
    /// The type of the element returned in the adapted collection.
    /// </typeparam>
    /// <param name="item">
    /// The element to convert.
    /// </param>
    /// <returns>
    /// Returns the converted element.
    /// </returns>
    public delegate TAdapted AdapterConverterHandler<TOriginal, TAdapted>(TOriginal item);

    /// <summary>
    /// Adapts an enumerable collection from one format to another.
    /// </summary>
    /// <typeparam name="TOriginal">
    /// The type of the elements stored in the original collection.
    /// </typeparam>
    /// <typeparam name="TAdapted">
    /// The type of the elements returned in the adapted collection.
    /// </typeparam>
    [SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix", Scope = "type", 
        Justification = "The type is an adapter for a collection, not a simple collection.")]
    public sealed partial class EnumerableAdapter<TOriginal, TAdapted> : IEnumerable<TAdapted>
    {
        #region Fields

        /// <summary>
        /// The adapter converter.
        /// </summary>
        private readonly AdapterConverterHandler<TOriginal, TAdapted> converter;

        /// <summary>
        /// The enumerable collection that is wrapped by this class.
        /// </summary>
        private readonly IEnumerable<TOriginal> innerEnumerable;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="EnumerableAdapter{TOriginal,TAdapted}"/> class. 
        /// Initializes a new instance of the EnumerableAdapter class.
        /// </summary>
        /// <param name="enumerable">
        /// The enumerable collection to wrap.
        /// </param>
        /// <param name="converter">
        /// Converts elements from the original list to the adapted list.
        /// </param>
        public EnumerableAdapter(IEnumerable<TOriginal> enumerable, AdapterConverterHandler<TOriginal, TAdapted> converter)
        {
            Param.Ignore(enumerable);
            Param.RequireNotNull(converter, "converter");

            this.innerEnumerable = enumerable;
            this.converter = converter;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the inner enumerable collection wrapped by this adapter.
        /// </summary>
        public IEnumerable<TOriginal> InnerEnumerable
        {
            get
            {
                return this.innerEnumerable;
            }
        }

        #endregion

        #region Explicit Interface Methods

        /// <summary>
        /// Gets an enumerator for iterating through the items in the list.
        /// </summary>
        /// <returns>Returns the enumerator.</returns>
        IEnumerator<TAdapted> IEnumerable<TAdapted>.GetEnumerator()
        {
            if (this.innerEnumerable == null)
            {
                yield break;
            }

            foreach (TOriginal item in this.innerEnumerable)
            {
                yield return this.Convert(item);
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Converts the item to its adapted format.
        /// </summary>
        /// <param name="item">
        /// The item to convert.
        /// </param>
        /// <returns>
        /// Returns the converted item.
        /// </returns>
        private TAdapted Convert(TOriginal item)
        {
            Param.Ignore(item);

            return this.converter(item);
        }

        #endregion
    }
    
    /// <content>
    /// Implements the weakly typed interface IEnumerable.
    /// </content>
    public partial class EnumerableAdapter<TOriginal, TAdapted>
    {
        #region Explicit Interface Methods

        /// <summary>
        /// Gets an enumerator for iterating through the items in the list.
        /// </summary>
        /// <returns>Returns the enumerator.</returns>
        IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            if (this.innerEnumerable == null)
            {
                yield break;
            }

            foreach (TOriginal item in this.innerEnumerable)
            {
                yield return this.Convert(item);
            }
        }

        #endregion
    }
}