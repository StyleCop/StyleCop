//--------------------------------------------------------------------------
//  <copyright file="RunningDocumentTable.cs" company="Microsoft">
//      Copyright (c) Microsoft Corporation.  All rights reserved.
//  </copyright>
//  <summary>
//  </summary>
//--------------------------------------------------------------------------
using System;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Collections;
using System.Xml;
using System.Text;
using System.Text.RegularExpressions;
using System.Net;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.VisualStudio.TextManager.Interop;
using Microsoft.VisualStudio.OLE.Interop;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.Designer.Interfaces;
using Microsoft.VisualStudio.Shell;
using IOleServiceProvider = Microsoft.VisualStudio.OLE.Interop.IServiceProvider;
using IServiceProvider = System.IServiceProvider;
using ShellConstants = Microsoft.VisualStudio.Shell.Interop.Constants;
using OleConstants = Microsoft.VisualStudio.OLE.Interop.Constants;

namespace Microsoft.VisualStudio.Shell {

    public class RunningDocumentTable : IEnumerable<RunningDocumentInfo> {
        IServiceProvider site;
        IVsRunningDocumentTable rdt;

        /// <include file='doc\RunningDocumentTable.uex' path='docs/doc[@for="RunningDocumentTable.RunningDocumentTable"]/*' />
        public RunningDocumentTable(IServiceProvider site) {
            this.site = site;
            this.rdt = site.GetService(typeof(SVsRunningDocumentTable)) as IVsRunningDocumentTable;
            if (this.rdt == null){
                throw new System.NotSupportedException(typeof(SVsRunningDocumentTable).FullName);
            }
        }

        /// <include file='doc\RunningDocumentTable.uex' path='docs/doc[@for="RunningDocumentTable.FindDocument"]/*' />
        public object FindDocument(string moniker) {
            IVsHierarchy hierarchy;
            uint itemid;
            uint docCookie;
            return FindDocument(moniker, out hierarchy, out itemid, out docCookie);
        }

        /// <include file='doc\RunningDocumentTable.uex' path='docs/doc[@for="RunningDocumentTable.FindDocument1"]/*' />
        public object FindDocument(string moniker, out uint docCookie) {
            IVsHierarchy hierarchy;
            uint itemid;
            return FindDocument(moniker, out hierarchy, out itemid, out docCookie);
        }

        /// <include file='doc\RunningDocumentTable.uex' path='docs/doc[@for="RunningDocumentTable.FindDocument2"]/*' />
        public object FindDocument(string moniker, out IVsHierarchy hierarchy, out uint itemid, out uint docCookie){
            itemid = 0;
            hierarchy = null;
            docCookie = 0;
            if (this.rdt == null) return null;
            IntPtr docData = IntPtr.Zero;
            NativeMethods.ThrowOnFailure(rdt.FindAndLockDocument((uint)_VSRDTFLAGS.RDT_NoLock, moniker, out hierarchy, out itemid, out docData, out docCookie));
            if (docData == IntPtr.Zero) return null;
            try {
                return Marshal.GetObjectForIUnknown(docData);
            } finally {
                Marshal.Release(docData);
            }
        }

        /// <include file='doc\RunningDocumentTable.uex' path='docs/doc[@for="RunningDocumentTable.GetHierarchyItem"]/*' />
        public IVsHierarchy GetHierarchyItem(string moniker) {                      
            uint docCookie;
            uint itemid;
            IVsHierarchy hierarchy;
            object docData = this.FindDocument(moniker, out hierarchy, out itemid, out docCookie);
            return hierarchy;
        }

        /// <include file='doc\RunningDocumentTable.uex' path='docs/doc[@for="RunningDocumentTable.GetRunningDocumentContents"]/*' />
        /// Return the document contents if it is loaded, otherwise return null.
        public string GetRunningDocumentContents(string path) {
            object docDataObj = this.FindDocument(path);
            if (docDataObj != null) {
                return GetBufferContents(docDataObj);
            }
            return null;
        }

        private static string GetBufferContents(object docDataObj) {
            string text = null;
            IVsTextLines buffer = null;
            if (docDataObj is IVsTextLines) {
                buffer = (IVsTextLines)docDataObj;
            } else if (docDataObj is IVsTextBufferProvider) {
                IVsTextBufferProvider tp = (IVsTextBufferProvider)docDataObj;
                if (tp.GetTextBuffer(out buffer) != NativeMethods.S_OK)
                    buffer = null;
            }
            if (buffer != null) {
                int endLine, endIndex;
                NativeMethods.ThrowOnFailure(buffer.GetLastLineIndex(out endLine, out endIndex));
                NativeMethods.ThrowOnFailure(buffer.GetLineText(0, 0, endLine, endIndex, out text));
                buffer = null;
            }
            return text;
        }

        public string GetRunningDocumentContents(uint docCookie) {
            uint flags, readLocks, editLocks, itemid;
            string moniker;
            IVsHierarchy hierarchy;
            IntPtr docData;
            int hr = this.rdt.GetDocumentInfo(docCookie, out flags, out readLocks, out editLocks, out moniker, out hierarchy, out itemid, out docData);
            if (hr == VSConstants.S_OK && docData != IntPtr.Zero) {
                try {
                    object data = Marshal.GetObjectForIUnknown(docData);
                    return GetBufferContents(data);
                } finally {
                    Marshal.Release(docData);
                }
            }
            return "";
        }

        public RunningDocumentInfo GetDocumentInfo(uint docCookie) {
            RunningDocumentInfo info = new RunningDocumentInfo();
            IntPtr docData;
            int hr = this.rdt.GetDocumentInfo(docCookie, out info.Flags,
                out info.ReadLocks, out info.EditLocks, out info.Moniker,
                out info.Hierarchy, out info.ItemId, out docData);
            if (hr == VSConstants.S_OK) {
                try {
                    if (docData != IntPtr.Zero)
                        info.DocData = Marshal.GetObjectForIUnknown(docData);
                    return info;
                } finally {
                    Marshal.Release(docData);
                }
            }
            return info;
        }

        /// <include file='doc\RunningDocumentTable.uex' path='docs/doc[@for="VsShell.SaveFileIfDirty"]/*' />
        public string SaveFileIfDirty(string fullPath) {
            object docData = this.FindDocument(fullPath);
            if (docData is IVsPersistDocData2) {
                IVsPersistDocData2 pdd = (IVsPersistDocData2)docData;
                int dirty = 0;
                int hr = pdd.IsDocDataDirty(out dirty);
                if (NativeMethods.Succeeded(hr) && dirty != 0) {
                    string newdoc;
                    int cancelled;
                    NativeMethods.ThrowOnFailure(pdd.SaveDocData(VSSAVEFLAGS.VSSAVE_Save, out newdoc, out cancelled));
                    return newdoc;
                }
            }
            return fullPath;
        }

        public void RenameDocument(string oldName, string newName, IVsHierarchy pIVsHierarchy, uint itemId){
            IntPtr pUnk = Marshal.GetIUnknownForObject(pIVsHierarchy);
            if (pUnk != IntPtr.Zero) {
                try {
                    IntPtr pHier = IntPtr.Zero;
                    Guid guid = typeof(IVsHierarchy).GUID;
                    NativeMethods.ThrowOnFailure(Marshal.QueryInterface(pUnk, ref guid, out pHier));
                    try {
                        NativeMethods.ThrowOnFailure(this.rdt.RenameDocument(oldName, newName, pHier, itemId));
                    } finally {
                        Marshal.Release(pHier);
                    }
                } finally {
                    Marshal.Release(pUnk);
                }
            }
        }

        public uint Advise(IVsRunningDocTableEvents sink) {
            uint cookie;
            NativeMethods.ThrowOnFailure(this.rdt.AdviseRunningDocTableEvents(sink, out cookie));
            return cookie;
        }

        public void Unadvise(uint cookie) {
            NativeMethods.ThrowOnFailure(this.rdt.UnadviseRunningDocTableEvents(cookie));
        }

        public uint RegisterAndLockDocument(_VSRDTFLAGS lockType, string mkDocument, IVsHierarchy hierarchy, uint itemid, IntPtr docData) {
            uint cookie;
            NativeMethods.ThrowOnFailure(rdt.RegisterAndLockDocument((uint)lockType, mkDocument, hierarchy, itemid, docData, out cookie));
            return cookie;           
        }

        public void LockDocument(_VSRDTFLAGS lockType, uint cookie) {
            NativeMethods.ThrowOnFailure(rdt.LockDocument((uint)lockType, cookie));
        }

        public void UnlockDocument(_VSRDTFLAGS lockType, uint cookie) {
            NativeMethods.ThrowOnFailure(rdt.UnlockDocument((uint)lockType, cookie));
        }

        // Enumerate the running documents
        public IEnumerator<RunningDocumentInfo> GetEnumerator() {
            IList<RunningDocumentInfo> list = new List<RunningDocumentInfo>();
            IEnumRunningDocuments ppenum;
            if (NativeMethods.Succeeded(rdt.GetRunningDocumentsEnum(out ppenum))) {
                uint[] rgelt = new uint[1];
                uint fetched = 0;
                while (true) {
                    if (NativeMethods.Succeeded(ppenum.Next(1, rgelt, out fetched)) && fetched == 1) {
                        list.Add(GetDocumentInfo(rgelt[0]));
                    } else {
                        break;
                    }
                }
            }
            return list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }

    [CLSCompliant(false)]
    public struct RunningDocumentInfo {
        public uint Flags;
        public uint ReadLocks;
        public uint EditLocks;
        public IVsHierarchy Hierarchy;
        public uint ItemId;
        public string Moniker;
        public object DocData;
    }

}
