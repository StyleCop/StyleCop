// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MockSolutionBuildManager.cs" company="https://github.com/StyleCop">
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
//   The mock solution build manager.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace VSPackageUnitTest.Mocks
{
    using System;
    using System.Collections.Generic;

    using Microsoft.VisualStudio;
    using Microsoft.VisualStudio.Shell.Interop;

    /// <summary>
    /// The mock solution build manager.
    /// </summary>
    public class MockSolutionBuildManager : IVsSolutionBuildManager
    {
        #region Constants and Fields

        private readonly List<IVsUpdateSolutionEvents> _eventSinks = new List<IVsUpdateSolutionEvents>();

        #endregion

        #region Implemented Interfaces

        #region IVsSolutionBuildManager

        /// <summary>
        /// The advise update solution events.
        /// </summary>
        /// <param name="sink">
        /// The sink.
        /// </param>
        /// <param name="pdwCookie">
        /// The pdw cookie.
        /// </param>
        /// <returns>
        /// The advise update solution events.
        /// </returns>
        public int AdviseUpdateSolutionEvents(IVsUpdateSolutionEvents sink, out uint pdwCookie)
        {
            this._eventSinks.Add(sink);
            pdwCookie = (uint)this._eventSinks.Count;
            return VSConstants.S_OK;
        }

        /// <summary>
        /// The can cancel update solution configuration.
        /// </summary>
        /// <param name="pfCanCancel">
        /// The pf can cancel.
        /// </param>
        /// <returns>
        /// The can cancel update solution configuration.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public int CanCancelUpdateSolutionConfiguration(out int pfCanCancel)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The cancel update solution configuration.
        /// </summary>
        /// <returns>
        /// The cancel update solution configuration.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public int CancelUpdateSolutionConfiguration()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The debug launch.
        /// </summary>
        /// <param name="grfLaunch">
        /// The grf launch.
        /// </param>
        /// <returns>
        /// The debug launch.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public int DebugLaunch(uint grfLaunch)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The find active project cfg.
        /// </summary>
        /// <param name="pvReserved1">
        /// The pv reserved 1.
        /// </param>
        /// <param name="pvReserved2">
        /// The pv reserved 2.
        /// </param>
        /// <param name="pIVsHierarchy_RequestedProject">
        /// The p i vs hierarchy_ requested project.
        /// </param>
        /// <param name="ppIVsProjectCfg_Active">
        /// The pp i vs project cfg_ active.
        /// </param>
        /// <returns>
        /// The find active project cfg.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public int FindActiveProjectCfg(IntPtr pvReserved1, IntPtr pvReserved2, IVsHierarchy pIVsHierarchy_RequestedProject, IVsProjectCfg[] ppIVsProjectCfg_Active)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The get project dependencies.
        /// </summary>
        /// <param name="pHier">
        /// The p hier.
        /// </param>
        /// <param name="celt">
        /// The celt.
        /// </param>
        /// <param name="rgpHier">
        /// The rgp hier.
        /// </param>
        /// <param name="pcActual">
        /// The pc actual.
        /// </param>
        /// <returns>
        /// The get project dependencies.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public int GetProjectDependencies(IVsHierarchy pHier, uint celt, IVsHierarchy[] rgpHier, uint[] pcActual)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The query build manager busy.
        /// </summary>
        /// <param name="pfBuildManagerBusy">
        /// The pf build manager busy.
        /// </param>
        /// <returns>
        /// The query build manager busy.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public int QueryBuildManagerBusy(out int pfBuildManagerBusy)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The query debug launch.
        /// </summary>
        /// <param name="grfLaunch">
        /// The grf launch.
        /// </param>
        /// <param name="pfCanLaunch">
        /// The pf can launch.
        /// </param>
        /// <returns>
        /// The query debug launch.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public int QueryDebugLaunch(uint grfLaunch, out int pfCanLaunch)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The start simple update project configuration.
        /// </summary>
        /// <param name="pIVsHierarchyToBuild">
        /// The p i vs hierarchy to build.
        /// </param>
        /// <param name="pIVsHierarchyDependent">
        /// The p i vs hierarchy dependent.
        /// </param>
        /// <param name="pszDependentConfigurationCanonicalName">
        /// The psz dependent configuration canonical name.
        /// </param>
        /// <param name="dwFlags">
        /// The dw flags.
        /// </param>
        /// <param name="dwDefQueryResults">
        /// The dw def query results.
        /// </param>
        /// <param name="fSuppressUI">
        /// The f suppress ui.
        /// </param>
        /// <returns>
        /// The start simple update project configuration.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public int StartSimpleUpdateProjectConfiguration(
            IVsHierarchy pIVsHierarchyToBuild, IVsHierarchy pIVsHierarchyDependent, string pszDependentConfigurationCanonicalName, uint dwFlags, uint dwDefQueryResults, int fSuppressUI)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The start simple update solution configuration.
        /// </summary>
        /// <param name="dwFlags">
        /// The dw flags.
        /// </param>
        /// <param name="dwDefQueryResults">
        /// The dw def query results.
        /// </param>
        /// <param name="fSuppressUI">
        /// The f suppress ui.
        /// </param>
        /// <returns>
        /// The start simple update solution configuration.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public int StartSimpleUpdateSolutionConfiguration(uint dwFlags, uint dwDefQueryResults, int fSuppressUI)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The unadvise update solution events.
        /// </summary>
        /// <param name="dwCookie">
        /// The dw cookie.
        /// </param>
        /// <returns>
        /// The unadvise update solution events.
        /// </returns>
        public int UnadviseUpdateSolutionEvents(uint dwCookie)
        {
            this._eventSinks[(int)dwCookie - 1] = null;
            return VSConstants.S_OK;
        }

        /// <summary>
        /// The update solution configuration is active.
        /// </summary>
        /// <param name="pfIsActive">
        /// The pf is active.
        /// </param>
        /// <returns>
        /// The update solution configuration is active.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public int UpdateSolutionConfigurationIsActive(out int pfIsActive)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The get_ code page.
        /// </summary>
        /// <param name="puiCodePage">
        /// The pui code page.
        /// </param>
        /// <returns>
        /// The get_ code page.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public int get_CodePage(out uint puiCodePage)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The get_ is debug.
        /// </summary>
        /// <param name="pfIsDebug">
        /// The pf is debug.
        /// </param>
        /// <returns>
        /// The get_ is debug.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public int get_IsDebug(out int pfIsDebug)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The get_ startup project.
        /// </summary>
        /// <param name="ppHierarchy">
        /// The pp hierarchy.
        /// </param>
        /// <returns>
        /// The get_ startup project.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public int get_StartupProject(out IVsHierarchy ppHierarchy)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The put_ code page.
        /// </summary>
        /// <param name="uiCodePage">
        /// The ui code page.
        /// </param>
        /// <returns>
        /// The put_ code page.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public int put_CodePage(uint uiCodePage)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The put_ is debug.
        /// </summary>
        /// <param name="fIsDebug">
        /// The f is debug.
        /// </param>
        /// <returns>
        /// The put_ is debug.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public int put_IsDebug(int fIsDebug)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The set_ startup project.
        /// </summary>
        /// <param name="pHierarchy">
        /// The p hierarchy.
        /// </param>
        /// <returns>
        /// The set_ startup project.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public int set_StartupProject(IVsHierarchy pHierarchy)
        {
            throw new NotImplementedException();
        }

        #endregion

        #endregion
    }
}