// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MockTaskEnum.cs" company="https://github.com/StyleCop">
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
//   The mock task enum.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace VSPackageUnitTest.Mocks
{
    using System;
    using System.Collections.Generic;

    using Microsoft.VisualStudio;
    using Microsoft.VisualStudio.Shell.Interop;

    /// <summary>
    /// The mock task enum.
    /// </summary>
    internal class MockTaskEnum : IVsEnumTaskItems
    {
        #region Constants and Fields

        private readonly IList<IVsTaskItem> _items;

        private int _next = 0;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MockTaskEnum"/> class.
        /// </summary>
        /// <param name="items">
        /// The items.
        /// </param>
        public MockTaskEnum(IList<IVsTaskItem> items)
        {
            this._items = items;
        }

        #endregion

        #region Implemented Interfaces

        #region IVsEnumTaskItems

        /// <summary>
        /// The clone.
        /// </summary>
        /// <param name="ppenum">
        /// The ppenum.
        /// </param>
        /// <returns>
        /// The clone.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int Clone(out IVsEnumTaskItems ppenum)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The next.
        /// </summary>
        /// <param name="celt">
        /// The celt.
        /// </param>
        /// <param name="rgelt">
        /// The rgelt.
        /// </param>
        /// <param name="pceltFetched">
        /// The pcelt fetched.
        /// </param>
        /// <returns>
        /// The next.
        /// </returns>
        public int Next(uint celt, IVsTaskItem[] rgelt, uint[] pceltFetched)
        {
            for (pceltFetched[0] = 0; celt > 0; --celt, ++pceltFetched[0])
            {
                if (this._next >= this._items.Count)
                {
                    return VSConstants.S_FALSE;
                }

                rgelt[pceltFetched[0]] = this._items[this._next++];
            }

            return VSConstants.S_OK;
        }

        /// <summary>
        /// The reset.
        /// </summary>
        /// <returns>
        /// The reset.
        /// </returns>
        public int Reset()
        {
            this._next = 0;
            return VSConstants.S_OK;
        }

        /// <summary>
        /// The skip.
        /// </summary>
        /// <param name="celt">
        /// The celt.
        /// </param>
        /// <returns>
        /// The skip.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int Skip(uint celt)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        #endregion
    }
}