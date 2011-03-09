//-----------------------------------------------------------------------
// <copyright file="MockTaskList.cs">
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
namespace VSPackageUnitTest.Mocks
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio;
    using Microsoft.VisualStudio.Shell.Interop;

    class MockTaskEnum : IVsEnumTaskItems
    {
        readonly IList<IVsTaskItem> _items;
        int _next = 0;

        public MockTaskEnum(IList<IVsTaskItem> items)
        {
            _items = items;
        }

        #region IVsEnumTaskItems Members

        public int Clone(out IVsEnumTaskItems ppenum)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int Next(uint celt, IVsTaskItem[] rgelt, uint[] pceltFetched)
        {
            for (pceltFetched[0] = 0; celt > 0; --celt, ++pceltFetched[0])
            {
                if (_next >= _items.Count)
                {
                    return VSConstants.S_FALSE;
                }
                rgelt[pceltFetched[0]] = _items[_next++];
            }
            return VSConstants.S_OK;
        }

        public int Reset()
        {
            _next = 0;
            return VSConstants.S_OK;
        }

        public int Skip(uint celt)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
