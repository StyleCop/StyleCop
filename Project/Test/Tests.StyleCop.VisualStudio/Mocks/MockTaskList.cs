// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MockTaskList.cs" company="https://github.com/StyleCop">
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
//   The mock task list.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace VSPackageUnitTest.Mocks
{
    using System;
    using System.Collections.Generic;

    using Microsoft.VisualStudio;
    using Microsoft.VisualStudio.OLE.Interop;
    using Microsoft.VisualStudio.Shell.Interop;

    /// <summary>
    /// The mock task list.
    /// </summary>
    internal class MockTaskList : IVsTaskList, IVsTaskList2
    {
        #region Constants and Fields

        private uint _nextCookie = 0;

        private Dictionary<uint, IVsTaskProvider> _providers = new Dictionary<uint, IVsTaskProvider>();

        private List<IVsTaskItem> _selection = new List<IVsTaskItem>();

        #endregion

        #region Events

        /// <summary>
        /// The on refresh tasks.
        /// </summary>
        public event EventHandler<RefreshTasksArgs> OnRefreshTasks;

        /// <summary>
        /// The on register task provider.
        /// </summary>
        public event EventHandler<RegisterTaskProviderArgs> OnRegisterTaskProvider;

        /// <summary>
        /// The on set active provider.
        /// </summary>
        public event EventHandler<SetActiveProviderArgs> OnSetActiveProvider;

        /// <summary>
        /// The on unregister task provider.
        /// </summary>
        public event EventHandler<UnregisterTaskProviderArgs> OnUnregisterTaskProvider;

        #endregion

        #region Public Methods

        /// <summary>
        /// The clear.
        /// </summary>
        public void Clear()
        {
            this._providers.Clear();
            this._selection.Clear();
        }

        /// <summary>
        /// The set selected.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <param name="selected">
        /// The selected.
        /// </param>
        public void SetSelected(IVsTaskItem item, bool selected)
        {
            if (!selected)
            {
                this._selection.Remove(item);
            }
            else
            {
                if (!this._selection.Contains(item))
                {
                    this._selection.Add(item);
                }
            }
        }

        #endregion

        #region Implemented Interfaces

        #region IVsTaskList

        /// <summary>
        /// The auto filter.
        /// </summary>
        /// <param name="cat">
        /// The cat.
        /// </param>
        /// <returns>
        /// The auto filter.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int AutoFilter(VSTASKCATEGORY cat)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The auto filter 2.
        /// </summary>
        /// <param name="guidCustomView">
        /// The guid custom view.
        /// </param>
        /// <returns>
        /// The auto filter 2.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int AutoFilter2(ref Guid guidCustomView)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The dump output.
        /// </summary>
        /// <param name="dwReserved">
        /// The dw reserved.
        /// </param>
        /// <param name="cat">
        /// The cat.
        /// </param>
        /// <param name="pstmOutput">
        /// The pstm output.
        /// </param>
        /// <param name="pfOutputWritten">
        /// The pf output written.
        /// </param>
        /// <returns>
        /// The dump output.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int DumpOutput(uint dwReserved, VSTASKCATEGORY cat, IStream pstmOutput, out int pfOutputWritten)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The enum task items.
        /// </summary>
        /// <param name="ppenum">
        /// The ppenum.
        /// </param>
        /// <returns>
        /// The enum task items.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int EnumTaskItems(out IVsEnumTaskItems ppenum)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The refresh tasks.
        /// </summary>
        /// <param name="dwProviderCookie">
        /// The dw provider cookie.
        /// </param>
        /// <returns>
        /// The refresh tasks.
        /// </returns>
        public int RefreshTasks(uint dwProviderCookie)
        {
            if (this.OnRefreshTasks != null)
            {
                this.OnRefreshTasks(this, new RefreshTasksArgs(dwProviderCookie, this._providers[dwProviderCookie]));
            }

            return VSConstants.S_OK;
        }

        /// <summary>
        /// The register custom category.
        /// </summary>
        /// <param name="guidCat">
        /// The guid cat.
        /// </param>
        /// <param name="dwSortOrder">
        /// The dw sort order.
        /// </param>
        /// <param name="pCat">
        /// The p cat.
        /// </param>
        /// <returns>
        /// The register custom category.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int RegisterCustomCategory(ref Guid guidCat, uint dwSortOrder, VSTASKCATEGORY[] pCat)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The register task provider.
        /// </summary>
        /// <param name="pProvider">
        /// The p provider.
        /// </param>
        /// <param name="pdwProviderCookie">
        /// The pdw provider cookie.
        /// </param>
        /// <returns>
        /// The register task provider.
        /// </returns>
        public int RegisterTaskProvider(IVsTaskProvider pProvider, out uint pdwProviderCookie)
        {
            pdwProviderCookie = ++this._nextCookie;
            this._providers.Add(pdwProviderCookie, pProvider);

            if (this.OnRegisterTaskProvider != null)
            {
                this.OnRegisterTaskProvider(this, new RegisterTaskProviderArgs(pProvider, this._nextCookie));
            }

            return VSConstants.S_OK;
        }

        /// <summary>
        /// The set silent output mode.
        /// </summary>
        /// <param name="fSilent">
        /// The f silent.
        /// </param>
        /// <returns>
        /// The set silent output mode.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int SetSilentOutputMode(int fSilent)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The unregister custom category.
        /// </summary>
        /// <param name="catAssigned">
        /// The cat assigned.
        /// </param>
        /// <returns>
        /// The unregister custom category.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int UnregisterCustomCategory(VSTASKCATEGORY catAssigned)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The unregister task provider.
        /// </summary>
        /// <param name="dwProviderCookie">
        /// The dw provider cookie.
        /// </param>
        /// <returns>
        /// The unregister task provider.
        /// </returns>
        public int UnregisterTaskProvider(uint dwProviderCookie)
        {
            this._providers.Remove(dwProviderCookie);

            if (this.OnUnregisterTaskProvider != null)
            {
                this.OnUnregisterTaskProvider(this, new UnregisterTaskProviderArgs(dwProviderCookie));
            }

            return VSConstants.S_OK;
        }

        /// <summary>
        /// The update provider info.
        /// </summary>
        /// <param name="dwProviderCookie">
        /// The dw provider cookie.
        /// </param>
        /// <returns>
        /// The update provider info.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int UpdateProviderInfo(uint dwProviderCookie)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        #region IVsTaskList2

        /// <summary>
        /// The begin task edit.
        /// </summary>
        /// <param name="pItem">
        /// The p item.
        /// </param>
        /// <param name="iFocusField">
        /// The i focus field.
        /// </param>
        /// <returns>
        /// The begin task edit.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int BeginTaskEdit(IVsTaskItem pItem, int iFocusField)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The enum selected items.
        /// </summary>
        /// <param name="ppEnum">
        /// The pp enum.
        /// </param>
        /// <returns>
        /// The enum selected items.
        /// </returns>
        public int EnumSelectedItems(out IVsEnumTaskItems ppEnum)
        {
            ppEnum = new MockTaskEnum(this._selection);
            return VSConstants.S_OK;
        }

        /// <summary>
        /// The get active provider.
        /// </summary>
        /// <param name="ppProvider">
        /// The pp provider.
        /// </param>
        /// <returns>
        /// The get active provider.
        /// </returns>
        public int GetActiveProvider(out IVsTaskProvider ppProvider)
        {
            foreach (IVsTaskProvider provider in this._providers.Values)
            {
                ppProvider = provider;
                return VSConstants.S_OK;
            }

            ppProvider = null;
            return VSConstants.S_OK;
        }

        /// <summary>
        /// The get caret pos.
        /// </summary>
        /// <param name="ppItem">
        /// The pp item.
        /// </param>
        /// <returns>
        /// The get caret pos.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int GetCaretPos(out IVsTaskItem ppItem)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The get selection count.
        /// </summary>
        /// <param name="pnItems">
        /// The pn items.
        /// </param>
        /// <returns>
        /// The get selection count.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int GetSelectionCount(out int pnItems)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The refresh all providers.
        /// </summary>
        /// <returns>
        /// The refresh all providers.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int RefreshAllProviders()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The refresh or add tasks.
        /// </summary>
        /// <param name="vsProviderCookie">
        /// The vs provider cookie.
        /// </param>
        /// <param name="nTasks">
        /// The n tasks.
        /// </param>
        /// <param name="prgTasks">
        /// The prg tasks.
        /// </param>
        /// <returns>
        /// The refresh or add tasks.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int RefreshOrAddTasks(uint vsProviderCookie, int nTasks, IVsTaskItem[] prgTasks)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The remove tasks.
        /// </summary>
        /// <param name="vsProviderCookie">
        /// The vs provider cookie.
        /// </param>
        /// <param name="nTasks">
        /// The n tasks.
        /// </param>
        /// <param name="prgTasks">
        /// The prg tasks.
        /// </param>
        /// <returns>
        /// The remove tasks.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int RemoveTasks(uint vsProviderCookie, int nTasks, IVsTaskItem[] prgTasks)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The select items.
        /// </summary>
        /// <param name="nItems">
        /// The n items.
        /// </param>
        /// <param name="pItems">
        /// The p items.
        /// </param>
        /// <param name="tsfSelType">
        /// The tsf sel type.
        /// </param>
        /// <param name="tsspScrollPos">
        /// The tssp scroll pos.
        /// </param>
        /// <returns>
        /// The select items.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int SelectItems(int nItems, IVsTaskItem[] pItems, uint tsfSelType, uint tsspScrollPos)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The set active provider.
        /// </summary>
        /// <param name="rguidProvider">
        /// The rguid provider.
        /// </param>
        /// <returns>
        /// The set active provider.
        /// </returns>
        public int SetActiveProvider(ref Guid rguidProvider)
        {
            if (this.OnSetActiveProvider != null)
            {
                this.OnSetActiveProvider(this, new SetActiveProviderArgs(rguidProvider));
            }

            return VSConstants.S_OK;
        }

        #endregion

        #endregion

        /// <summary>
        /// The refresh tasks args.
        /// </summary>
        public class RefreshTasksArgs : EventArgs
        {
            #region Constants and Fields

            public readonly uint Cookie;

            public readonly IVsTaskProvider Provider;

            #endregion

            #region Constructors and Destructors

            /// <summary>
            /// Initializes a new instance of the <see cref="RefreshTasksArgs"/> class.
            /// </summary>
            /// <param name="cookie">
            /// The cookie.
            /// </param>
            /// <param name="provider">
            /// The provider.
            /// </param>
            public RefreshTasksArgs(uint cookie, IVsTaskProvider provider)
            {
                this.Cookie = cookie;
                this.Provider = provider;
            }

            #endregion
        }

        /// <summary>
        /// The register task provider args.
        /// </summary>
        public class RegisterTaskProviderArgs : EventArgs
        {
            #region Constants and Fields

            public readonly uint Cookie;

            public readonly IVsTaskProvider Provider;

            #endregion

            #region Constructors and Destructors

            /// <summary>
            /// Initializes a new instance of the <see cref="RegisterTaskProviderArgs"/> class.
            /// </summary>
            /// <param name="provider">
            /// The provider.
            /// </param>
            /// <param name="cookie">
            /// The cookie.
            /// </param>
            public RegisterTaskProviderArgs(IVsTaskProvider provider, uint cookie)
            {
                this.Provider = provider;
                this.Cookie = cookie;
            }

            #endregion
        }

        /// <summary>
        /// The set active provider args.
        /// </summary>
        public class SetActiveProviderArgs : EventArgs
        {
            #region Constants and Fields

            public readonly Guid ProviderGuid;

            #endregion

            #region Constructors and Destructors

            /// <summary>
            /// Initializes a new instance of the <see cref="SetActiveProviderArgs"/> class.
            /// </summary>
            /// <param name="providerGuid">
            /// The provider guid.
            /// </param>
            public SetActiveProviderArgs(Guid providerGuid)
            {
                this.ProviderGuid = providerGuid;
            }

            #endregion
        }

        /// <summary>
        /// The unregister task provider args.
        /// </summary>
        public class UnregisterTaskProviderArgs : EventArgs
        {
            #region Constants and Fields

            public readonly uint Cookie;

            #endregion

            #region Constructors and Destructors

            /// <summary>
            /// Initializes a new instance of the <see cref="UnregisterTaskProviderArgs"/> class.
            /// </summary>
            /// <param name="cookie">
            /// The cookie.
            /// </param>
            public UnregisterTaskProviderArgs(uint cookie)
            {
                this.Cookie = cookie;
            }

            #endregion
        }
    }
}