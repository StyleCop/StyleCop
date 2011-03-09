//-----------------------------------------------------------------------
// <copyright file="MockSolutionBuildManager.cs">
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
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.VisualStudio.Shell.Interop;
    using Microsoft.VisualStudio;

    public class MockSolutionBuildManager : IVsSolutionBuildManager
    {
        readonly List<IVsUpdateSolutionEvents> _eventSinks = new List<IVsUpdateSolutionEvents>();
        #region IVsSolutionBuildManager Members

        public int AdviseUpdateSolutionEvents(IVsUpdateSolutionEvents sink, out uint pdwCookie)
        {
            _eventSinks.Add(sink);
            pdwCookie = (uint)this._eventSinks.Count;
            return VSConstants.S_OK;
        }

        public int CanCancelUpdateSolutionConfiguration(out int pfCanCancel)
        {
            throw new NotImplementedException();
        }

        public int CancelUpdateSolutionConfiguration()
        {
            throw new NotImplementedException();
        }

        public int DebugLaunch(uint grfLaunch)
        {
            throw new NotImplementedException();
        }

        public int FindActiveProjectCfg(IntPtr pvReserved1, IntPtr pvReserved2, IVsHierarchy pIVsHierarchy_RequestedProject, IVsProjectCfg[] ppIVsProjectCfg_Active)
        {
            throw new NotImplementedException();
        }

        public int GetProjectDependencies(IVsHierarchy pHier, uint celt, IVsHierarchy[] rgpHier, uint[] pcActual)
        {
            throw new NotImplementedException();
        }

        public int QueryBuildManagerBusy(out int pfBuildManagerBusy)
        {
            throw new NotImplementedException();
        }

        public int QueryDebugLaunch(uint grfLaunch, out int pfCanLaunch)
        {
            throw new NotImplementedException();
        }

        public int StartSimpleUpdateProjectConfiguration(IVsHierarchy pIVsHierarchyToBuild, IVsHierarchy pIVsHierarchyDependent, string pszDependentConfigurationCanonicalName, uint dwFlags, uint dwDefQueryResults, int fSuppressUI)
        {
            throw new NotImplementedException();
        }

        public int StartSimpleUpdateSolutionConfiguration(uint dwFlags, uint dwDefQueryResults, int fSuppressUI)
        {
            throw new NotImplementedException();
        }

        public int UnadviseUpdateSolutionEvents(uint dwCookie)
        {
            this._eventSinks[(int)dwCookie - 1] = null;
            return VSConstants.S_OK;
        }

        public int UpdateSolutionConfigurationIsActive(out int pfIsActive)
        {
            throw new NotImplementedException();
        }

        public int get_CodePage(out uint puiCodePage)
        {
            throw new NotImplementedException();
        }

        public int get_IsDebug(out int pfIsDebug)
        {
            throw new NotImplementedException();
        }

        public int get_StartupProject(out IVsHierarchy ppHierarchy)
        {
            throw new NotImplementedException();
        }

        public int put_CodePage(uint uiCodePage)
        {
            throw new NotImplementedException();
        }

        public int put_IsDebug(int fIsDebug)
        {
            throw new NotImplementedException();
        }

        public int set_StartupProject(IVsHierarchy pHierarchy)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
