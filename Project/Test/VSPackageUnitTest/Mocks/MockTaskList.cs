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

    internal class MockTaskList : IVsTaskList, IVsTaskList2
    {
        public class RefreshTasksArgs : EventArgs
        {
            public readonly uint Cookie;
            public readonly IVsTaskProvider Provider;
            public RefreshTasksArgs(uint cookie, IVsTaskProvider provider) { Cookie = cookie; Provider = provider; }
        }
        public event EventHandler<RefreshTasksArgs> OnRefreshTasks;

        public class RegisterTaskProviderArgs : EventArgs
        {
            public readonly IVsTaskProvider Provider;
            public readonly uint Cookie;
            public RegisterTaskProviderArgs(IVsTaskProvider provider, uint cookie) { Provider = provider; Cookie = cookie; }
        }
        public event EventHandler<RegisterTaskProviderArgs> OnRegisterTaskProvider;

        public class UnregisterTaskProviderArgs : EventArgs
        {
            public readonly uint Cookie;
            public UnregisterTaskProviderArgs(uint cookie) { Cookie = cookie; }
        }
        public event EventHandler<UnregisterTaskProviderArgs> OnUnregisterTaskProvider;

        public class SetActiveProviderArgs : EventArgs
        {
            public readonly Guid ProviderGuid;
            public SetActiveProviderArgs(Guid providerGuid) { ProviderGuid = providerGuid; }
        }
        public event EventHandler<SetActiveProviderArgs> OnSetActiveProvider;

        Dictionary<uint, IVsTaskProvider> _providers = new Dictionary<uint, IVsTaskProvider>();
        List<IVsTaskItem> _selection = new List<IVsTaskItem>();

        public void SetSelected(IVsTaskItem item, bool selected)
        {
            if (!selected)
            {
                _selection.Remove(item);
            }
            else
            {
                if (!_selection.Contains(item))
                {
                    _selection.Add(item);
                }
            }
        }

        public void Clear()
        {
            _providers.Clear();
            _selection.Clear();
        }

        #region IVsTaskList Members

        public int AutoFilter(VSTASKCATEGORY cat)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int AutoFilter2(ref Guid guidCustomView)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int DumpOutput(uint dwReserved, VSTASKCATEGORY cat, Microsoft.VisualStudio.OLE.Interop.IStream pstmOutput, out int pfOutputWritten)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int EnumTaskItems(out IVsEnumTaskItems ppenum)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int RefreshTasks(uint dwProviderCookie)
        {
            if (OnRefreshTasks != null)
            {
                OnRefreshTasks(this, new RefreshTasksArgs(dwProviderCookie, _providers[dwProviderCookie]));
            }
            return VSConstants.S_OK;
        }

        public int RegisterCustomCategory(ref Guid guidCat, uint dwSortOrder, VSTASKCATEGORY[] pCat)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        uint _nextCookie = 0;

        public int RegisterTaskProvider(IVsTaskProvider pProvider, out uint pdwProviderCookie)
        {
            pdwProviderCookie = ++_nextCookie;
            _providers.Add(pdwProviderCookie, pProvider);

            if (OnRegisterTaskProvider != null)
            {
                OnRegisterTaskProvider(this, new RegisterTaskProviderArgs(pProvider, _nextCookie));
            }
            return VSConstants.S_OK;
        }

        public int SetSilentOutputMode(int fSilent)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int UnregisterCustomCategory(VSTASKCATEGORY catAssigned)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int UnregisterTaskProvider(uint dwProviderCookie)
        {
            _providers.Remove(dwProviderCookie);

            if (OnUnregisterTaskProvider != null)
            {
                OnUnregisterTaskProvider(this, new UnregisterTaskProviderArgs(dwProviderCookie));
            }
            return VSConstants.S_OK;
        }

        public int UpdateProviderInfo(uint dwProviderCookie)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        #region IVsTaskList2 Members

        public int BeginTaskEdit(IVsTaskItem pItem, int iFocusField)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int EnumSelectedItems(out IVsEnumTaskItems ppEnum)
        {
            ppEnum = new MockTaskEnum(_selection);
            return VSConstants.S_OK;
        }

        public int GetActiveProvider(out IVsTaskProvider ppProvider)
        {
            foreach (IVsTaskProvider provider in _providers.Values)
            {
                ppProvider = provider;
                return VSConstants.S_OK;
            }

            ppProvider = null;
            return VSConstants.S_OK;
        }

        public int GetCaretPos(out IVsTaskItem ppItem)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int GetSelectionCount(out int pnItems)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int RefreshAllProviders()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int RefreshOrAddTasks(uint vsProviderCookie, int nTasks, IVsTaskItem[] prgTasks)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int RemoveTasks(uint vsProviderCookie, int nTasks, IVsTaskItem[] prgTasks)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int SelectItems(int nItems, IVsTaskItem[] pItems, uint tsfSelType, uint tsspScrollPos)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int SetActiveProvider(ref Guid rguidProvider)
        {
            if (OnSetActiveProvider != null)
            {
                OnSetActiveProvider(this, new SetActiveProviderArgs(rguidProvider));
            }
            return VSConstants.S_OK;
        }

        #endregion
    }
}

