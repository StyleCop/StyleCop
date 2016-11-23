// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MockEnumHierarchies.cs" company="https://github.com/StyleCop">
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
//   The mock enum hierarchies.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace VSPackageUnitTest.Mocks
{
    using System.Collections.Generic;

    using Microsoft.VisualStudio;
    using Microsoft.VisualStudio.Shell.Interop;

    /// <summary>
    /// The mock enum hierarchies.
    /// </summary>
    internal class MockEnumHierarchies : IEnumHierarchies
    {
        #region Constants and Fields

        private int _next = 0;

        private List<MockIVsProject> _projects;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MockEnumHierarchies"/> class.
        /// </summary>
        /// <param name="projects">
        /// The projects.
        /// </param>
        public MockEnumHierarchies(IEnumerable<MockIVsProject> projects)
        {
            this._projects = new List<MockIVsProject>(projects);
        }

        #endregion

        #region Implemented Interfaces

        #region IEnumHierarchies

        /// <summary>
        /// The clone.
        /// </summary>
        /// <param name="ppenum">
        /// The ppenum.
        /// </param>
        /// <returns>
        /// The clone.
        /// </returns>
        public int Clone(out IEnumHierarchies ppenum)
        {
            ppenum = new MockEnumHierarchies(this._projects);
            return VSConstants.S_OK;
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
        public int Next(uint celt, IVsHierarchy[] rgelt, out uint pceltFetched)
        {
            pceltFetched = 0;

            while (pceltFetched < celt && this._next < this._projects.Count)
            {
                rgelt[pceltFetched] = this._projects[this._next];
                pceltFetched++;
                ++this._next;
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
        public int Skip(uint celt)
        {
            IVsHierarchy[] items = new IVsHierarchy[celt];
            uint fetched;

            return this.Next(celt, items, out fetched);
        }

        #endregion

        #endregion
    }
}