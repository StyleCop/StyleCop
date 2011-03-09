//-----------------------------------------------------------------------
// <copyright file="MockEnumHierarchies.cs" company="Microsoft">
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
    using System.Text;
    using Microsoft.VisualStudio.Shell.Interop;
    using Microsoft.VisualStudio;
    
    class MockEnumHierarchies : IEnumHierarchies
    {
        List<MockIVsProject> _projects;
        int _next = 0;

        public MockEnumHierarchies(IEnumerable<MockIVsProject> projects)
        {
            _projects = new List<MockIVsProject>(projects);
        }

        #region IEnumHierarchies Members

        public int Clone(out IEnumHierarchies ppenum)
        {
            ppenum = new MockEnumHierarchies(_projects);
            return VSConstants.S_OK;
        }

        public int Next(uint celt, IVsHierarchy[] rgelt, out uint pceltFetched)
        {
            pceltFetched = 0;

            while (pceltFetched < celt && _next < _projects.Count)
            {
                rgelt[pceltFetched] = _projects[_next];
                pceltFetched++;
                ++_next;
            }

            if (pceltFetched == celt)
            {
                return VSConstants.S_OK;
            }
            else
            {
                return VSConstants.S_FALSE;
            }
        }

        public int Reset()
        {
            _next = 0;
            return VSConstants.S_OK;
        }

        public int Skip(uint celt)
        {
            IVsHierarchy[] items = new IVsHierarchy[celt];
            uint fetched;

            return Next(celt, items, out fetched);
        }

        #endregion
    }
}

