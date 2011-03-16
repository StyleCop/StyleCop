//-----------------------------------------------------------------------
// <copyright file="MockIVsProject.cs">
//   MS-PL
// </copyright>
// <license>
//   This source code is subject to terms and conditions of the Microsoft 
//   Public License. A copy of the license can be found in the License.html 
//   file at the root of this distribution. 
//   By using this source code in any fashion, you are agreeing to be bound 
//   by the terms of the Microsoft Public License. You must not remove this 
//   notice, or any other, from this software.
// </license>
//-----------------------------------------------------------------------
namespace VSPackageUnitTest.Mocks
{
    using System;
    using System.Collections.Generic;
    using StyleCop.VisualStudio;
    using Microsoft.VisualStudio;
    using Microsoft.VisualStudio.Shell.Interop;

    class MockIVsProject : IVsProject, IVsHierarchy
    {
        readonly List<string> _items = new List<string>();
        readonly string _projFile;

        public MockIVsProject(string projFile)
        {
            _projFile = projFile;
        }

        public string FullPath
        {
            get { return _projFile; }
        }

        public void AddItem(string itemName)
        {
            _items.Add(itemName);
        }

        #region IVsProject Members

        public int AddItem(uint itemidLoc, VSADDITEMOPERATION dwAddItemOperation, string pszItemName, uint cFilesToOpen, string[] rgpszFilesToOpen, IntPtr hwndDlgOwner, VSADDRESULT[] pResult)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int GenerateUniqueItemName(uint itemidLoc, string pszExt, string pszSuggestedRoot, out string pbstrItemName)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int GetItemContext(uint itemid, out Microsoft.VisualStudio.OLE.Interop.IServiceProvider ppSP)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int GetMkDocument(uint itemid, out string pbstrMkDocument)
        {

            if (itemid == VSConstants.VSITEMID_ROOT)
            {
                pbstrMkDocument = _projFile;
                return VSConstants.S_OK;
            }
            else if (itemid >= 0 && itemid < _items.Count)
            {
                pbstrMkDocument = _items[(int)itemid];
                return VSConstants.S_OK;
            }
            throw new Exception("The method or operation is not implemented.");
        }

        public int IsDocumentInProject(string pszMkDocument, out int pfFound, VSDOCUMENTPRIORITY[] pdwPriority, out uint pitemid)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int OpenItem(uint itemid, ref Guid rguidLogicalView, IntPtr punkDocDataExisting, out IVsWindowFrame ppWindowFrame)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        #region IVsHierarchy Members

        public int AdviseHierarchyEvents(IVsHierarchyEvents pEventSink, out uint pdwCookie)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int Close()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int GetCanonicalName(uint itemid, out string pbstrName)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int GetGuidProperty(uint itemid, int propid, out Guid pguid)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int GetNestedHierarchy(uint itemid, ref Guid iidHierarchyNested, out IntPtr ppHierarchyNested, out uint pitemidNested)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int GetProperty(uint itemid, int propid, out object pvar)
        {
            if (itemid == VSConstants.VSITEMID_ROOT)
            {
                if (propid == (int)__VSHPROPID.VSHPROPID_FirstChild)
                {
                    if (_items.Count > 0)
                    {
                        pvar = 0;
                    }
                    else
                    {
                        unchecked
                        {
                            pvar = (int)VSConstants.VSITEMID_NIL;
                        }
                    }
                    return VSConstants.S_OK;
                }
            }
            else if (itemid >= 0 && itemid < _items.Count)
            {
                if (propid == (int)__VSHPROPID.VSHPROPID_NextSibling)
                {
                    if (itemid < _items.Count - 1)
                    {
                        pvar = (int)itemid + 1;
                    }
                    else
                    {
                        unchecked
                        {
                            pvar = (int)VSConstants.VSITEMID_NIL;
                        }
                    }
                    return VSConstants.S_OK;
                }
                else if (propid == (int)__VSHPROPID.VSHPROPID_FirstChild)
                {
                    unchecked
                    {
                        pvar = (int)VSConstants.VSITEMID_NIL;
                    }
                    return VSConstants.S_OK;
                }
            }
            throw new Exception("The method or operation is not implemented.");
        }

        public int GetSite(out Microsoft.VisualStudio.OLE.Interop.IServiceProvider ppSP)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int ParseCanonicalName(string pszName, out uint pitemid)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int QueryClose(out int pfCanClose)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int SetGuidProperty(uint itemid, int propid, ref Guid rguid)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int SetProperty(uint itemid, int propid, object var)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int SetSite(Microsoft.VisualStudio.OLE.Interop.IServiceProvider psp)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int UnadviseHierarchyEvents(uint dwCookie)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int Unused0()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int Unused1()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int Unused2()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int Unused3()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int Unused4()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}

