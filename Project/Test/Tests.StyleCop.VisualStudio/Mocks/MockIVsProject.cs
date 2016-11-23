// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MockIVsProject.cs" company="https://github.com/StyleCop">
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
//   The mock i vs project.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace VSPackageUnitTest.Mocks
{
    using System;
    using System.Collections.Generic;

    using Microsoft.VisualStudio;
    using Microsoft.VisualStudio.Shell.Interop;

    using IServiceProvider = Microsoft.VisualStudio.OLE.Interop.IServiceProvider;

    /// <summary>
    /// The mock i vs project.
    /// </summary>
    internal class MockIVsProject : IVsProject, IVsHierarchy
    {
        #region Constants and Fields

        private readonly List<string> _items = new List<string>();

        private readonly string _projFile;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MockIVsProject"/> class.
        /// </summary>
        /// <param name="projFile">
        /// The proj file.
        /// </param>
        public MockIVsProject(string projFile)
        {
            this._projFile = projFile;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets FullPath.
        /// </summary>
        public string FullPath
        {
            get
            {
                return this._projFile;
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// The add item.
        /// </summary>
        /// <param name="itemName">
        /// The item name.
        /// </param>
        public void AddItem(string itemName)
        {
            this._items.Add(itemName);
        }

        #endregion

        #region Implemented Interfaces

        #region IVsHierarchy

        /// <summary>
        /// The advise hierarchy events.
        /// </summary>
        /// <param name="pEventSink">
        /// The p event sink.
        /// </param>
        /// <param name="pdwCookie">
        /// The pdw cookie.
        /// </param>
        /// <returns>
        /// The advise hierarchy events.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int AdviseHierarchyEvents(IVsHierarchyEvents pEventSink, out uint pdwCookie)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The close.
        /// </summary>
        /// <returns>
        /// The close.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int Close()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The get canonical name.
        /// </summary>
        /// <param name="itemid">
        /// The itemid.
        /// </param>
        /// <param name="pbstrName">
        /// The pbstr name.
        /// </param>
        /// <returns>
        /// The get canonical name.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int GetCanonicalName(uint itemid, out string pbstrName)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The get guid property.
        /// </summary>
        /// <param name="itemid">
        /// The itemid.
        /// </param>
        /// <param name="propid">
        /// The propid.
        /// </param>
        /// <param name="pguid">
        /// The pguid.
        /// </param>
        /// <returns>
        /// The get guid property.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int GetGuidProperty(uint itemid, int propid, out Guid pguid)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The get nested hierarchy.
        /// </summary>
        /// <param name="itemid">
        /// The itemid.
        /// </param>
        /// <param name="iidHierarchyNested">
        /// The iid hierarchy nested.
        /// </param>
        /// <param name="ppHierarchyNested">
        /// The pp hierarchy nested.
        /// </param>
        /// <param name="pitemidNested">
        /// The pitemid nested.
        /// </param>
        /// <returns>
        /// The get nested hierarchy.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int GetNestedHierarchy(uint itemid, ref Guid iidHierarchyNested, out IntPtr ppHierarchyNested, out uint pitemidNested)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The get property.
        /// </summary>
        /// <param name="itemid">
        /// The itemid.
        /// </param>
        /// <param name="propid">
        /// The propid.
        /// </param>
        /// <param name="pvar">
        /// The pvar.
        /// </param>
        /// <returns>
        /// The get property.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int GetProperty(uint itemid, int propid, out object pvar)
        {
            if (itemid == VSConstants.VSITEMID_ROOT)
            {
                if (propid == (int)__VSHPROPID.VSHPROPID_FirstChild)
                {
                    if (this._items.Count > 0)
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
            else if (itemid >= 0 && itemid < this._items.Count)
            {
                if (propid == (int)__VSHPROPID.VSHPROPID_NextSibling)
                {
                    if (itemid < this._items.Count - 1)
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

        /// <summary>
        /// The get site.
        /// </summary>
        /// <param name="ppSP">
        /// The pp sp.
        /// </param>
        /// <returns>
        /// The get site.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int GetSite(out IServiceProvider ppSP)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The parse canonical name.
        /// </summary>
        /// <param name="pszName">
        /// The psz name.
        /// </param>
        /// <param name="pitemid">
        /// The pitemid.
        /// </param>
        /// <returns>
        /// The parse canonical name.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int ParseCanonicalName(string pszName, out uint pitemid)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The query close.
        /// </summary>
        /// <param name="pfCanClose">
        /// The pf can close.
        /// </param>
        /// <returns>
        /// The query close.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int QueryClose(out int pfCanClose)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The set guid property.
        /// </summary>
        /// <param name="itemid">
        /// The itemid.
        /// </param>
        /// <param name="propid">
        /// The propid.
        /// </param>
        /// <param name="rguid">
        /// The rguid.
        /// </param>
        /// <returns>
        /// The set guid property.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int SetGuidProperty(uint itemid, int propid, ref Guid rguid)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The set property.
        /// </summary>
        /// <param name="itemid">
        /// The itemid.
        /// </param>
        /// <param name="propid">
        /// The propid.
        /// </param>
        /// <param name="var">
        /// The var.
        /// </param>
        /// <returns>
        /// The set property.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int SetProperty(uint itemid, int propid, object var)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The set site.
        /// </summary>
        /// <param name="psp">
        /// The psp.
        /// </param>
        /// <returns>
        /// The set site.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int SetSite(IServiceProvider psp)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The unadvise hierarchy events.
        /// </summary>
        /// <param name="dwCookie">
        /// The dw cookie.
        /// </param>
        /// <returns>
        /// The unadvise hierarchy events.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int UnadviseHierarchyEvents(uint dwCookie)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The unused 0.
        /// </summary>
        /// <returns>
        /// The unused 0.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int Unused0()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The unused 1.
        /// </summary>
        /// <returns>
        /// The unused 1.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int Unused1()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The unused 2.
        /// </summary>
        /// <returns>
        /// The unused 2.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int Unused2()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The unused 3.
        /// </summary>
        /// <returns>
        /// The unused 3.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int Unused3()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The unused 4.
        /// </summary>
        /// <returns>
        /// The unused 4.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int Unused4()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        #region IVsProject

        /// <summary>
        /// The add item.
        /// </summary>
        /// <param name="itemidLoc">
        /// The itemid loc.
        /// </param>
        /// <param name="dwAddItemOperation">
        /// The dw add item operation.
        /// </param>
        /// <param name="pszItemName">
        /// The psz item name.
        /// </param>
        /// <param name="cFilesToOpen">
        /// The c files to open.
        /// </param>
        /// <param name="rgpszFilesToOpen">
        /// The rgpsz files to open.
        /// </param>
        /// <param name="hwndDlgOwner">
        /// The hwnd dlg owner.
        /// </param>
        /// <param name="pResult">
        /// The p result.
        /// </param>
        /// <returns>
        /// The add item.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int AddItem(uint itemidLoc, VSADDITEMOPERATION dwAddItemOperation, string pszItemName, uint cFilesToOpen, string[] rgpszFilesToOpen, IntPtr hwndDlgOwner, VSADDRESULT[] pResult)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The generate unique item name.
        /// </summary>
        /// <param name="itemidLoc">
        /// The itemid loc.
        /// </param>
        /// <param name="pszExt">
        /// The psz ext.
        /// </param>
        /// <param name="pszSuggestedRoot">
        /// The psz suggested root.
        /// </param>
        /// <param name="pbstrItemName">
        /// The pbstr item name.
        /// </param>
        /// <returns>
        /// The generate unique item name.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int GenerateUniqueItemName(uint itemidLoc, string pszExt, string pszSuggestedRoot, out string pbstrItemName)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The get item context.
        /// </summary>
        /// <param name="itemid">
        /// The itemid.
        /// </param>
        /// <param name="ppSP">
        /// The pp sp.
        /// </param>
        /// <returns>
        /// The get item context.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int GetItemContext(uint itemid, out IServiceProvider ppSP)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The get mk document.
        /// </summary>
        /// <param name="itemid">
        /// The itemid.
        /// </param>
        /// <param name="pbstrMkDocument">
        /// The pbstr mk document.
        /// </param>
        /// <returns>
        /// The get mk document.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int GetMkDocument(uint itemid, out string pbstrMkDocument)
        {
            if (itemid == VSConstants.VSITEMID_ROOT)
            {
                pbstrMkDocument = this._projFile;
                return VSConstants.S_OK;
            }
            else if (itemid >= 0 && itemid < this._items.Count)
            {
                pbstrMkDocument = this._items[(int)itemid];
                return VSConstants.S_OK;
            }

            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The is document in project.
        /// </summary>
        /// <param name="pszMkDocument">
        /// The psz mk document.
        /// </param>
        /// <param name="pfFound">
        /// The pf found.
        /// </param>
        /// <param name="pdwPriority">
        /// The pdw priority.
        /// </param>
        /// <param name="pitemid">
        /// The pitemid.
        /// </param>
        /// <returns>
        /// The is document in project.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int IsDocumentInProject(string pszMkDocument, out int pfFound, VSDOCUMENTPRIORITY[] pdwPriority, out uint pitemid)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The open item.
        /// </summary>
        /// <param name="itemid">
        /// The itemid.
        /// </param>
        /// <param name="rguidLogicalView">
        /// The rguid logical view.
        /// </param>
        /// <param name="punkDocDataExisting">
        /// The punk doc data existing.
        /// </param>
        /// <param name="ppWindowFrame">
        /// The pp window frame.
        /// </param>
        /// <returns>
        /// The open item.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int OpenItem(uint itemid, ref Guid rguidLogicalView, IntPtr punkDocDataExisting, out IVsWindowFrame ppWindowFrame)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        #endregion
    }
}