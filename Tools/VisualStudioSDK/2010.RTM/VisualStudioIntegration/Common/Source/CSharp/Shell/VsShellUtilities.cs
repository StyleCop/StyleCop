//--------------------------------------------------------------------------
//  <copyright file="VSShellUtilities.cs" company="Microsoft">
//      Copyright (c) Microsoft Corporation.  All rights reserved.
//  </copyright>
//  <devdoc>
//  </devdoc>
//--------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TextManager.Interop;
using Microsoft.VisualStudio.OLE.Interop;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.Designer.Interfaces;
using Microsoft.VisualStudio.Shell;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.Win32;
using System.Globalization;
using System.IO;
using System.Collections;
using System.Xml;
using System.Text;
using System.Net;
using IOleServiceProvider = Microsoft.VisualStudio.OLE.Interop.IServiceProvider;
using IServiceProvider = System.IServiceProvider;
using ShellConstants = Microsoft.VisualStudio.Shell.Interop.Constants;
using OleConstants = Microsoft.VisualStudio.OLE.Interop.Constants;
using EnvDTE;

namespace Microsoft.VisualStudio.Shell
{

    /// <include file='doc\VsShellUtilities.uex' path='docs/doc[@for="VsShellUtilities"]/*' />
    /// <devdoc>
    ///This class provides some useful static shell based methods. 
    /// </devdoc>
    [CLSCompliant(false)]
    public static class VsShellUtilities
    {

        /// <include file='doc\VsShellUtilities.uex' path='docs/doc[@for="VsShellUtilities.RenameDocument"]/*' />
        /// <devdoc>
        /// Rename document in the running document table from oldName to newName.
        /// </devdoc>
        /// <param name="site">The service provider.</param>
        /// <param name="oldName">Full path to the old name of the document.</param>        
        /// <param name="newName">Full path to the new name of the document.</param>        
        public static void RenameDocument(IServiceProvider site, string oldName, string newName)
        {
            if (site == null)
            {
                throw new ArgumentException("site");
            }

            if (String.IsNullOrEmpty(oldName))
            { 
                throw new ArgumentException("oldName");
            }

            if (String.IsNullOrEmpty(newName))
            {
                throw new ArgumentException("newName");
            }

            IVsRunningDocumentTable pRDT = site.GetService(typeof(SVsRunningDocumentTable)) as IVsRunningDocumentTable;
            IVsUIShellOpenDocument doc = site.GetService(typeof(SVsUIShellOpenDocument)) as IVsUIShellOpenDocument;
            IVsUIShell uiShell = site.GetService(typeof(SVsUIShell)) as IVsUIShell;

            if (pRDT == null || doc == null) return;

            IVsHierarchy pIVsHierarchy;
            uint itemId;
            IntPtr docData;
            uint uiVsDocCookie;
            ErrorHandler.ThrowOnFailure(pRDT.FindAndLockDocument((uint)_VSRDTFLAGS.RDT_NoLock, oldName, out pIVsHierarchy, out itemId, out docData, out uiVsDocCookie));

            if (docData != IntPtr.Zero)
            {
                try
                {
                    IntPtr pUnk = Marshal.GetIUnknownForObject(pIVsHierarchy);
                    Guid iid = typeof(IVsHierarchy).GUID;
                    IntPtr pHier;
                    Marshal.QueryInterface(pUnk, ref iid, out pHier);
                    try
                    {
                        ErrorHandler.ThrowOnFailure(pRDT.RenameDocument(oldName, newName, pHier, itemId));
                    }
                    finally
                    {
                        Marshal.Release(pHier);
                        Marshal.Release(pUnk);
                    }

                    string newCaption = Path.GetFileName(newName);
                    // now we need to tell the windows to update their captions. 
                    IEnumWindowFrames ppenum;
                    ErrorHandler.ThrowOnFailure(uiShell.GetDocumentWindowEnum(out ppenum));
                    IVsWindowFrame[] rgelt = new IVsWindowFrame[1];
                    uint fetched;
                    while (ppenum.Next(1, rgelt, out fetched) == VSConstants.S_OK && fetched == 1)
                    {
                        IVsWindowFrame windowFrame = rgelt[0];
                        object data;
                        ErrorHandler.ThrowOnFailure(windowFrame.GetProperty((int)__VSFPROPID.VSFPROPID_DocData, out data));
                        IntPtr ptr = Marshal.GetIUnknownForObject(data);
                        try
                        {
                            if (ptr == docData)
                            {
                                ErrorHandler.ThrowOnFailure(windowFrame.SetProperty((int)__VSFPROPID.VSFPROPID_OwnerCaption, newCaption));
                            }
                        }
                        finally
                        {
                            if (ptr != IntPtr.Zero)
                            {
                                Marshal.Release(ptr);
                            }
                        }
                    }
                }
                finally
                {
                    Marshal.Release(docData);
                }
            }
        }

        /// <include file='doc\VsShellUtilities.uex' path='docs/doc[@for="VsShellUtilities.OpenDocument"]/*' />
        /// <devdoc>
        /// Open document using the appropriate project. 
        /// </devdoc>
        /// <param name="provider">The service provider.</param>
        /// <param name="fullPath">Full path to the document.</param>
        /// <param name="logicalView">In MultiView case determines view to be activated by IVsMultiViewDocumentView. For a list of logical view GUIDS, see constants starting with LOGVIEWID_ defined in NativeMethods class</param>
        /// <param name="hierarchy">Reference to the IVsUIHierarchy interface of the project that can open the document.</param>
        /// <param name="itemID"> Reference to the hierarchy item identifier of the document in the project.</param>
        /// <param name="windowFrame">A reference to the window frame that is mapped to the document.</param>
        /// <param name="view">A reference to the primary view of the document.</param>
        public static void OpenDocument(IServiceProvider provider, string fullPath, Guid logicalView, out IVsUIHierarchy hierarchy, out uint itemID, out IVsWindowFrame windowFrame, out IVsTextView view)
        {
            itemID = VSConstants.VSITEMID_NIL;
            windowFrame = null;
            hierarchy = null;
            view = null;

            if (provider == null)
            {
                throw new ArgumentException("provider");
            }

            if (String.IsNullOrEmpty(fullPath))
            {
                throw new ArgumentException("fullPath");
            }

            OpenDocument(provider, fullPath, logicalView, out hierarchy, out itemID, out windowFrame);
            view = GetTextView(windowFrame);
        }

        /// <include file='doc\VsShellUtilities.uex' path='docs/doc[@for="VsShellUtilities.OpenDocument"]/*' />
        /// <devdoc>
        /// Open document using the appropriate project. 
        /// </devdoc>
        /// <param name="provider">The service provider.</param>
        /// <param name="fullPath">Full path to the document.</param>
        /// <param name="logicalView">GUID identifying the logical view.</param>
        /// <param name="hierarchy">Reference to the IVsUIHierarchy interface of the project that contains the Open document.</param>
        /// <param name="itemID"> Reference to the hierarchy item identifier of the document in the project.</param>
        /// <param name="windowFrame">A reference to the window frame that is mapped to the document.</param>
        public static void OpenDocument(IServiceProvider provider, string fullPath, Guid logicalView, out IVsUIHierarchy hierarchy, out uint itemID, out IVsWindowFrame windowFrame)
        {
            windowFrame = null;
            itemID = VSConstants.VSITEMID_NIL;
            hierarchy = null;

            if (provider == null)
            {
                throw new ArgumentException("provider");
            }

            if (String.IsNullOrEmpty(fullPath))
            {
                throw new ArgumentException("fullPath");
            }

            //open document
            if (!IsDocumentOpen(provider, fullPath, Guid.Empty, out hierarchy, out itemID, out windowFrame))
            {
                IVsUIShellOpenDocument shellOpenDoc = provider.GetService(typeof(IVsUIShellOpenDocument)) as IVsUIShellOpenDocument;
                if (shellOpenDoc != null)
                {
                    IOleServiceProvider psp;
                    uint itemid;
                    ErrorHandler.ThrowOnFailure(shellOpenDoc.OpenDocumentViaProject(fullPath, ref logicalView, out psp, out hierarchy, out itemid, out windowFrame));
                    if (windowFrame != null)
                        ErrorHandler.ThrowOnFailure(windowFrame.Show());
                    psp = null;
                }
            }
            else if (windowFrame != null)
            {
                ErrorHandler.ThrowOnFailure(windowFrame.Show());
            }
        }

        /// <include file='doc\VsShellUtilities.uex' path='docs/doc[@for="VsShellUtilities.GetTextView"]/*' />
        /// <devdoc>
        /// Get primary view for a window frame.
        /// </devdoc>
        /// <param name="windowFrame">The window frame</param>
        /// <returns>A refererence to an IVsTextView if successfull. Otherwise null.</returns>
        public static IVsTextView GetTextView(IVsWindowFrame windowFrame)
        {
            if (windowFrame == null)
            {
                throw new ArgumentException("windowFrame");
            }

            IVsTextView textView = null;
            object pvar;
            ErrorHandler.ThrowOnFailure(windowFrame.GetProperty((int)__VSFPROPID.VSFPROPID_DocView, out pvar));
            if (pvar is IVsTextView)
            {
                textView = (IVsTextView)pvar;
            }
            else if (pvar is IVsCodeWindow)
            {
                IVsCodeWindow codeWin = (IVsCodeWindow)pvar;
                try
                {
                    ErrorHandler.ThrowOnFailure(codeWin.GetPrimaryView(out textView));
                }
                catch (COMException e)
                {
                    // perhaps the code window doesn't use IVsTextWindow?
                    Trace.WriteLine("Exception : " + e.Message);
                    textView = null;
                }
            }
            return textView;
        }

        /// <include file='doc\VsShellUtilities.uex' path='docs/doc[@for="VsShellUtilities.GetWindowObject"]/*' />
        /// <devdoc>
        /// Get Window interface for the window frame.
        /// </devdoc>
        /// <param name="windowFrame">The window frame.</param>
        /// <returns>A reference to the Window interaface if succesfull. Otherwise null.</returns>
        public static EnvDTE.Window GetWindowObject(IVsWindowFrame windowFrame)
        {
            if (windowFrame == null)
            {
                throw new ArgumentException("windowFrame");
            }

            EnvDTE.Window window = null;
            object pvar;
            ErrorHandler.ThrowOnFailure(windowFrame.GetProperty((int)__VSFPROPID.VSFPROPID_ExtWindowObject, out pvar));
            if (pvar is EnvDTE.Window)
            {
                window = (EnvDTE.Window)pvar;
            }
            return window;

        }

        /// <include file='doc\VsShellUtilities.uex' path='docs/doc[@for="VsShellUtilities.IsDocumentOpen"]/*' />
        /// <devdoc>
        /// Determine if a document is opened with a given logical view.  
        /// </devdoc>
        /// <param name="provider">The service provider.</param>
        /// <param name="fullPath">Full path to the document</param>
        /// <param name="logicalView">GUID identifying the logical view. If logicalView is set to Guid.Empty, it will return true if any view is open.</param>
        /// <param name="hierarchy">Reference to the IVsUIHierarchy interface of the project that contains the Open document</param>
        /// <param name="itemID"> Reference to the hierarchy item identifier of the document in the project</param>
        /// <param name="windowFrame">A reference to the window frame that is mapped to the document</param>
        /// <returns>true if the document is open with the given logical view</returns>
        public static bool IsDocumentOpen(IServiceProvider provider, string fullPath, Guid logicalView, out IVsUIHierarchy hierarchy, out uint itemID, out IVsWindowFrame windowFrame)
        {
            windowFrame = null;
            itemID = VSConstants.VSITEMID_NIL;
            hierarchy = null;

            if (provider == null)
            {
                throw new ArgumentException("provider");
            }

            if (String.IsNullOrEmpty(fullPath))
            {
                throw new ArgumentException("fullPath");
            }

            //open document
            IVsUIShellOpenDocument shellOpenDoc = provider.GetService(typeof(IVsUIShellOpenDocument)) as IVsUIShellOpenDocument;
            IVsRunningDocumentTable pRDT = provider.GetService(typeof(IVsRunningDocumentTable)) as IVsRunningDocumentTable;
            if (pRDT != null && shellOpenDoc != null)
            {
                IntPtr punkDocData = IntPtr.Zero;
                uint docCookie;
                uint[] pitemid = new uint[1];
                IVsHierarchy ppIVsHierarchy;
                try
                {
                    ErrorHandler.ThrowOnFailure(pRDT.FindAndLockDocument((uint)_VSRDTFLAGS.RDT_NoLock, fullPath, out ppIVsHierarchy, out pitemid[0], out punkDocData, out docCookie));
                    int pfOpen;
                    uint flags = (logicalView == Guid.Empty) ? (uint)__VSIDOFLAGS.IDO_IgnoreLogicalView : 0;
                    ErrorHandler.ThrowOnFailure(shellOpenDoc.IsDocumentOpen((IVsUIHierarchy)ppIVsHierarchy, pitemid[0], fullPath, ref logicalView, flags, out hierarchy, pitemid, out windowFrame, out pfOpen));
                    if (windowFrame != null)
                    {
                        itemID = pitemid[0];
                        return (pfOpen == 1);
                    }
                }
                finally
                {
                    if (punkDocData != IntPtr.Zero)
                    {
                        Marshal.Release(punkDocData);
                    }
                }
            }
            return false;
        }

        /// <include file='doc\VsShellUtilities.uex' path='docs/doc[@for="VsShellUtilities.OpenAsMiscellaneousFile"]/*' />
        /// <devdoc>
        /// Open a file using the miscellaneous project.
        /// </devdoc>
        /// <param name="provider">The service provider.</param>
        /// <param name="path">Path to the item to open.</param>
        /// <param name="caption">Caption of the item.</param>
        /// <param name="editor">Unique identifier of the editor type.</param>
        /// <param name="physicalView">Name of physical view.</param>
        /// <param name="logicalView">Name of logical view.</param>
        public static void OpenAsMiscellaneousFile(IServiceProvider provider, string path, string caption, Guid editor, string physicalView, Guid logicalView)
        {

            if (provider == null)
            {
                throw new ArgumentException("provider");
            }

            if (String.IsNullOrEmpty(path))
            {
                throw new ArgumentException("path");
            }

            IVsProject3 proj = VsShellUtilities.GetMiscellaneousProject(provider);
            VSADDRESULT[] result = new VSADDRESULT[1];
            // NOTE: This method must use VSADDITEMOPERATION.VSADDITEMOP_CLONEFILE.
            // VSADDITEMOPERATION.VSADDITEMOP_OPENFILE doesn't work.
            VSADDITEMOPERATION op = VSADDITEMOPERATION.VSADDITEMOP_CLONEFILE;
            __VSCREATEEDITORFLAGS flags = __VSCREATEEDITORFLAGS.CEF_CLONEFILE;
            ErrorHandler.ThrowOnFailure(proj.AddItemWithSpecific(VSConstants.VSITEMID_NIL, op, caption, 1, new string[1] { path }, IntPtr.Zero,
                (uint)flags, ref editor, physicalView, ref logicalView, result));

            if (result[0] != VSADDRESULT.ADDRESULT_Success)
            {
                throw new ApplicationException(result[0].ToString());
            }
        }

        /// <include file='doc\VsShellUtilities.uex' path='docs/doc[@for="VsShellUtilities.GetMiscellaneousProject"]/*' />
        /// <devdoc>
        /// Get miscellaneous project from current solution
        /// </devdoc>
        /// <param name="provider">The service provider</param>
        /// <returns>A refernce to the IVsProject3 interface for the misceleneous project.</returns>
        public static IVsProject3 GetMiscellaneousProject(IServiceProvider provider)
        {
            if (provider == null)
            {
                throw new ArgumentNullException("provider");
            }

            IVsHierarchy miscHierarchy = null;
            Guid miscProj = VSConstants.CLSID_MiscellaneousFilesProject;
            IVsSolution sln = (IVsSolution)provider.GetService(typeof(SVsSolution));
            int hr = sln.GetProjectOfGuid(ref miscProj, out miscHierarchy);

            if (ErrorHandler.Failed(hr) || miscHierarchy == null)
            {
                // need to create it then
                IntPtr ptr;
                Guid iidVsHierarchy = typeof(IVsHierarchy).GUID;
                __VSCREATEPROJFLAGS grfCreate = __VSCREATEPROJFLAGS.CPF_OPENFILE;
                //                if (!g_fShowMiscellaneousFilesProject)
                //                    grfCreate |= CPF_NOTINSLNEXPLR;
                ErrorHandler.ThrowOnFailure(sln.CreateProject(ref miscProj, null, null, null, (uint)grfCreate, ref iidVsHierarchy, out ptr));
                try
                {
                    miscHierarchy = (IVsHierarchy)Marshal.GetTypedObjectForIUnknown(ptr, typeof(IVsHierarchy));
                }
                finally
                {
                    Marshal.Release(ptr);
                }
            }
            return miscHierarchy as IVsProject3;
        }

        /// <include file='doc\VsShellUtilities.uex' path='docs/doc[@for="VsShellUtilities.GetMiscellaneousProject"]/*' />
        /// <devdoc>
        /// Get miscellaneous project from current solution
        /// </devdoc>
        /// <param name="provider">The service provider</param>
        /// <param name="create">If false, does not force creation of the misc project</param>
        /// <returns>A refernce to the IVsProject3 interface for the misceleneous project.</returns>
        public static IVsProject3 GetMiscellaneousProject(IServiceProvider provider, bool create)
        {
            if (provider == null)
            {
                throw new ArgumentNullException("provider");
            }

            IVsHierarchy miscHierarchy = null;
            Guid miscProj = VSConstants.CLSID_MiscellaneousFilesProject;
            IVsSolution2 sln = (IVsSolution2)provider.GetService(typeof(SVsSolution));
            int hr = sln.GetProjectOfGuid(ref miscProj, out miscHierarchy);

            if ((NativeMethods.Failed(hr) || miscHierarchy == null) && create)
            {
                return GetMiscellaneousProject(provider);
            }
            return miscHierarchy as IVsProject3;
        }

        /// <include file='doc\VsShellUtilities.uex' path='docs/doc[@for="VsShellUtilities.OpenDocument"]/*' />
        /// <devdoc>
        /// Open a document.
        /// </devdoc>
        /// <param name="provider">The service provider.</param>
        /// <param name="path">Full path to the document.</param>
        public static void OpenDocument(IServiceProvider provider, string path)
        {
            if (provider == null)
            {
                throw new ArgumentException("provider");
            }

            if (String.IsNullOrEmpty(path))
            {
                throw new ArgumentException("path");
            }

            IVsUIHierarchy hierarchy;
            uint itemID;
            IVsWindowFrame windowFrame;
            Guid logicalView = Guid.Empty;
            VsShellUtilities.OpenDocument(provider, path, logicalView, out hierarchy, out itemID, out windowFrame);
            windowFrame = null;
            hierarchy = null;
        }

        /// <include file='doc\VsShellUtilities.uex' path='docs/doc[@for="VsShellUtilities.OpenDocumentWithSpecificEditor"]/*' />
        /// <devdoc>
        /// Open a document using a specific editor. 
        /// </devdoc>
        /// <param name="provider">The service provider.</param>
        /// <param name="fullPath">Full path to the document.</param>
        /// <param name="editorType">Unique identifier of the editor type.</param>
        /// <param name="logicalView">In MultiView case determines view to be activated by IVsMultiViewDocumentView. For a list of logical view GUIDS, see constants starting with LOGVIEWID_ defined in NativeMethods class</param>
        /// <returns>A reference to the window frame that is mapped to the document.</returns>
        public static IVsWindowFrame OpenDocumentWithSpecificEditor(IServiceProvider provider, string fullPath, Guid editorType, Guid logicalView)
        {
            if (provider == null)
            {
                throw new ArgumentException("provider");
            }

            if (String.IsNullOrEmpty(fullPath))
            {
                throw new ArgumentException("fullPath");
            }

            IVsUIHierarchy hierarchy;
            uint itemID;
            IVsWindowFrame windowFrame;
            OpenDocumentWithSpecificEditor(provider, fullPath, editorType, logicalView, out hierarchy, out itemID, out windowFrame);
            hierarchy = null;
            return windowFrame;
        }

        /// <include file='doc\VsShellUtilities.uex' path='docs/doc[@for="VsShellUtilities.OpenDocumentWithSpecificEditor"]/*' />
        /// <devdoc>
        /// Open a document using a specific editor. 
        /// </devdoc>
        /// <param name="provider">The service provider.</param>
        /// <param name="fullPath">Full path to the document.</param>
        /// <param name="editorType">Unique identifier of the editor type.</param>
        /// <param name="logicalView">In MultiView case determines view to be activated by IVsMultiViewDocumentView. For a list of logical view GUIDS, see constants starting with LOGVIEWID_ defined in NativeMethods class</param>
        /// <param name="hierarchy">Reference to the IVsUIHierarchy interface of the project that can open the document.</param>
        /// <param name="itemID"> Reference to the hierarchy item identifier of the document in the project.</param>
        /// <param name="windowFrame">A reference to the window frame that is mapped to the document.</param>
        public static void OpenDocumentWithSpecificEditor(IServiceProvider provider, string fullPath, Guid editorType, Guid logicalView, out IVsUIHierarchy hierarchy, out uint itemID, out IVsWindowFrame windowFrame)
        {
            windowFrame = null;
            itemID = VSConstants.VSITEMID_NIL;
            hierarchy = null;

            if (provider == null)
            {
                throw new ArgumentException("provider");
            }

            if (String.IsNullOrEmpty(fullPath))
            {
                throw new ArgumentException("fullPath");
            }

            //open document
            IVsUIShellOpenDocument shellOpenDoc = provider.GetService(typeof(IVsUIShellOpenDocument)) as IVsUIShellOpenDocument;
            IVsRunningDocumentTable pRDT = provider.GetService(typeof(IVsRunningDocumentTable)) as IVsRunningDocumentTable;
            string physicalView = null;
            if (pRDT != null && shellOpenDoc != null)
            {
                ErrorHandler.ThrowOnFailure(shellOpenDoc.MapLogicalView(ref editorType, ref logicalView, out physicalView));
                // See if the requested editor is already open with the requested view.
                IntPtr punkDocData = IntPtr.Zero;
                uint docCookie;
                IVsHierarchy ppIVsHierarchy;
                try
                {
                    ErrorHandler.ThrowOnFailure(pRDT.FindAndLockDocument((uint)_VSRDTFLAGS.RDT_NoLock, fullPath, out ppIVsHierarchy, out itemID, out punkDocData, out docCookie));                    
                    int pfOpen;
                    uint flags = (uint)__VSIDOFLAGS.IDO_ActivateIfOpen;
                    int hr = shellOpenDoc.IsSpecificDocumentViewOpen((IVsUIHierarchy)ppIVsHierarchy, itemID, fullPath, ref editorType, physicalView, flags, out hierarchy, out itemID, out windowFrame, out pfOpen);
                    if (ErrorHandler.Succeeded(hr) && pfOpen == 1)
                    {
                        return;
                    }
                }
                finally
                { 
                    if (punkDocData != IntPtr.Zero)
                    {
                        Marshal.Release(punkDocData);
                    }
                }

                IOleServiceProvider psp;
                uint editorFlags = (uint)__VSSPECIFICEDITORFLAGS.VSSPECIFICEDITOR_UseEditor | (uint)__VSSPECIFICEDITORFLAGS.VSSPECIFICEDITOR_DoOpen;
                ErrorHandler.ThrowOnFailure(shellOpenDoc.OpenDocumentViaProjectWithSpecific(fullPath, editorFlags, ref editorType, physicalView, ref logicalView, out psp, out hierarchy, out itemID, out windowFrame));
                if (windowFrame != null)
                    ErrorHandler.ThrowOnFailure(windowFrame.Show());
                psp = null;
            }
        }

        /// <include file='doc\VsShellUtilities.uex' path='docs/doc[@for="VsShellUtilities.GetProject"]/*' />
        /// <devdoc>
        /// Get reference to the IVsHierarchy interface for project that owns the document.
        /// </devdoc>
        /// <param name="site">The service provider.</param>
        /// <param name="moniker">The document moniker.</param>
        /// <returns>
        /// If the document is open, this is a reference to the IVsUIHierarchy Interface implementation of the project that owns the document. 
        /// If the document is not open, the value of this parameter is NULL. 
        /// </returns>
        public static IVsHierarchy GetProject(IServiceProvider site, string moniker)
        {
            if (site == null)
            {
                throw new ArgumentException("site");
            }

            if (String.IsNullOrEmpty(moniker))
            {
                throw new ArgumentException("moniker");
            }

            IVsUIShellOpenDocument opendoc = site.GetService(typeof(SVsUIShellOpenDocument)) as IVsUIShellOpenDocument;
            IVsUIHierarchy hierarchy = null;
            uint pitemid;
            IOleServiceProvider sp;
            int docInProj;
            int rc = opendoc.IsDocumentInAProject(moniker, out hierarchy, out pitemid, out sp, out docInProj);
            ErrorHandler.ThrowOnFailure(rc);
            return hierarchy as IVsHierarchy;
        }

        /// <include file='doc\VsShellUtilities.uex' path='docs/doc[@for="VsShellUtilities.GetRunningDocumentContents"]/*' />
        /// <devdoc>
        /// Get contents of file loaded by the running document table.
        /// </devdoc>
        /// <param name="site">The service provider.</param>
        /// <param name="path">Path to the file.</param>
        /// <returns>The contents of the file if it is loaded by RDT. Otherwise it returns null.</returns>
        public static string GetRunningDocumentContents(IServiceProvider site, string path)
        {
            if (site == null)
            {
                throw new ArgumentException("site");
            }

            if (String.IsNullOrEmpty(path))
            {
                throw new ArgumentException("path");
            }

            string text = null;
            IVsRunningDocumentTable pRDT = (IVsRunningDocumentTable)site.GetService(typeof(SVsRunningDocumentTable));
            if (pRDT != null)
            {
                IntPtr punkDocData = IntPtr.Zero;
                uint pitemid;
                uint docCookie;
                IVsHierarchy ppIVsHierarchy;
                try
                {
                    ErrorHandler.ThrowOnFailure(pRDT.FindAndLockDocument((uint)_VSRDTFLAGS.RDT_NoLock, path, out ppIVsHierarchy, out pitemid, out punkDocData, out docCookie));
                    if (punkDocData != IntPtr.Zero)
                    {
                        object docDataObj = Marshal.GetObjectForIUnknown(punkDocData);
                        IVsTextLines buffer = null;
                        if (docDataObj is IVsTextLines)
                        {
                            buffer = (IVsTextLines)docDataObj;
                        }
                        else if (docDataObj is IVsTextBufferProvider)
                        {
                            IVsTextBufferProvider tp = (IVsTextBufferProvider)docDataObj;
                            if (tp.GetTextBuffer(out buffer) != VSConstants.S_OK)
                                buffer = null;
                        }
                        if (buffer != null)
                        {
                            int endLine, endIndex;
                            ErrorHandler.ThrowOnFailure(buffer.GetLastLineIndex(out endLine, out endIndex));
                            ErrorHandler.ThrowOnFailure(buffer.GetLineText(0, 0, endLine, endIndex, out text));
                            buffer = null;
                            return text;
                        }
                    }
                }
                finally
                {
                    if (punkDocData != IntPtr.Zero)
                    {
                        Marshal.Release(punkDocData);
                    }
                }
            }

            return null;
        }

        /// <include file='doc\VsShellUtilities.uex' path='docs/doc[@for="VsShellUtilities.GetRDTDocumentInfo"]/*' />
        /// <devdoc>
        /// Get a reference to the IVsPersistDocData interface associated to a document in the Running Document Table.
        /// </devdoc>
        /// <param name="site">The service provider.</param>
        /// <param name="documentName">Path to the document.</param>
        /// <param name="hierarchy">[out, optional] Reference to the IVsHierarchy interface for the project who owns the document.</param>
        /// <param name="itemid">[out, optional] Reference to an item identifier in the hierarchy. </param>
        /// <param name="persistDocData">[out] A reference to the IVsPersistDocData interface associated to the document</param>
        /// <param name="docCookie">[out, optional] A reference to an abstract handle to the document. </param>
        public static void GetRDTDocumentInfo(IServiceProvider site, string documentName, out IVsHierarchy hierarchy, out uint itemid, out IVsPersistDocData persistDocData, out uint docCookie)
        {
            hierarchy = null;
            itemid = VSConstants.VSITEMID_NIL;
            persistDocData = null;
            docCookie = (uint)ShellConstants.VSDOCCOOKIE_NIL;

            if (site == null)
            {
                throw new ArgumentException("site");
            }

            if (String.IsNullOrEmpty(documentName))
            {
                throw new ArgumentException("documentName");
            }

            // Get the document info.
            IVsRunningDocumentTable rdt = site.GetService(typeof(IVsRunningDocumentTable)) as IVsRunningDocumentTable;
            if (rdt == null) return;

            IntPtr docData = IntPtr.Zero;
            try
            {
                ErrorHandler.ThrowOnFailure(rdt.FindAndLockDocument((uint)_VSRDTFLAGS.RDT_NoLock, documentName, out hierarchy, out itemid, out docData, out docCookie));


                if (docData != IntPtr.Zero)
                {
                    // if interface is not supported, return null
                    persistDocData = Marshal.GetObjectForIUnknown(docData) as IVsPersistDocData;
                }
            }
            finally
            {

                if (docData != IntPtr.Zero)
                {
                    Marshal.Release(docData);
                }
            }
        }

        /// <include file='doc\VsShellUtilities.uex' path='docs/doc[@for="VsShellUtilities.SaveFileIfDirty"]/*' />
        /// <devdoc>
        /// Save file if it is dirty.
        /// </devdoc>
        /// <param name="site">The service provider.</param>
        /// <param name="fullPath">The full path of the file to be saved.</param>
        public static void SaveFileIfDirty(IServiceProvider site, string fullPath)
        {
            if (site == null)
            {
                throw new ArgumentException("site");
            }

            if (String.IsNullOrEmpty(fullPath))
            {
                throw new ArgumentException("fullPath");
            }

            IVsRunningDocumentTable pRDT = (IVsRunningDocumentTable)site.GetService(typeof(SVsRunningDocumentTable));
            if (pRDT != null)
            {
                IntPtr punkDocData;
                uint pitemid;
                uint docCookie;
                IVsHierarchy vsHierarchy;
                ErrorHandler.ThrowOnFailure(pRDT.FindAndLockDocument((uint)_VSRDTFLAGS.RDT_NoLock, fullPath, out vsHierarchy, out pitemid, out punkDocData, out docCookie));
                if (punkDocData != IntPtr.Zero)
                {
                    try
                    {
                        IVsPersistDocData2 pdd = (IVsPersistDocData2)Marshal.GetObjectForIUnknown(punkDocData);
                        int dirty;
                        ErrorHandler.ThrowOnFailure(pdd.IsDocDataDirty(out dirty));
                        if (dirty != 0)
                        {
                            string newdoc;
                            int cancelled;
                            ErrorHandler.ThrowOnFailure(pdd.SaveDocData(VSSAVEFLAGS.VSSAVE_Save, out newdoc, out cancelled));
                        }
                    }
                    finally
                    {
                        Marshal.Release(punkDocData);
                    }
                }
                vsHierarchy = null;
            }
            pRDT = null;
        }

        /// <include file='doc\VsShellUtilities.uex' path='docs/doc[@for="VsShellUtilities.SaveFileIfDirty"]/*' />
        /// <devdoc>
        /// Save document data for a text view.
        /// </devdoc>
        /// <param name="view">The view to be saved</param>
        public static void SaveFileIfDirty(IVsTextView view)
        {
            if (view == null)
            {
                throw new ArgumentException("view");
            }


            IVsTextLines buffer;
            ErrorHandler.ThrowOnFailure(view.GetBuffer(out buffer));
            IVsPersistDocData2 pdd = (IVsPersistDocData2)buffer;
            int dirty;
            ErrorHandler.ThrowOnFailure(pdd.IsDocDataDirty(out dirty));
            if (dirty != 0)
            {
                string newdoc;
                int cancelled;
                ErrorHandler.ThrowOnFailure(pdd.SaveDocData(VSSAVEFLAGS.VSSAVE_Save, out newdoc, out cancelled));
            }
            pdd = null;
            buffer = null;
        }

        /// <include file='doc\VsShellUtilities.uex' path='docs/doc[@for="VsShellUtilities.PromptYesNo"]/*' />
        /// <devdoc>
        /// Prompt the user with the specified message.
        /// </devdoc>
        /// <param name="message">The message to show.</param>
        /// <param name="title">The title of the message box.</param>
        /// <param name="icon">The icon to show on the message box.</param>
        /// <param name="uiShell">A reference to a IVsUIShell interface.</param>        
        /// <returns>Return true if the result is Yes, false otherwise.</returns>
        public static bool PromptYesNo(string message, string title, OLEMSGICON icon, IVsUIShell uiShell)
        {
            Guid emptyGuid = Guid.Empty;
            int result = 0;
            ErrorHandler.ThrowOnFailure(uiShell.ShowMessageBox(
                0,
                ref emptyGuid,
                title,
                message,
                null,
                0,
                OLEMSGBUTTON.OLEMSGBUTTON_YESNO,
                OLEMSGDEFBUTTON.OLEMSGDEFBUTTON_SECOND,
                icon,
                0,
                out result));

            return (result == NativeMethods.IDYES);
        }

        /// <include file='doc\VsShellUtilities.uex' path='docs/doc[@for="VsShellUtilities.ShowMessageBox"]/*' />
        /// <devdoc>
        /// Show message box.
        /// </devdoc>
        /// <param name="serviceProvider">The service provider</param>
        /// <param name="message">The message to show</param>
        /// <param name="title">The title of the message box</param>
        /// <param name="icon">The icon to show on the message box</param>
        /// <param name="msgButton">The button type</param>
        /// <param name="defaultButton">The default button</param>
        /// <returns>If the method succeeds, it returns S_OK. If it fails, it returns an error code. If a referernce to the IVsUIShell interface cannot be retrived from the service provider then InvalidOperationException is thrown.</returns>
        public static int ShowMessageBox(IServiceProvider serviceProvider, string message, string title, OLEMSGICON icon, OLEMSGBUTTON msgButton, OLEMSGDEFBUTTON defaultButton)
        {
            Debug.Assert(serviceProvider != null, "Could not create MessageBox for a null serviceprovider");
            if (serviceProvider == null)
            {
                throw new ArgumentException("serviceProvider");
            }

            IVsUIShell uiShell = serviceProvider.GetService(typeof(IVsUIShell)) as IVsUIShell;
            Debug.Assert(uiShell != null, "Could not get the IVsUIShell object from the services exposed by this serviceprovider");
            if (uiShell == null)
            {
                throw new InvalidOperationException();
            }
            Guid emptyGuid = Guid.Empty;
            int result = 0;
            ErrorHandler.ThrowOnFailure(uiShell.ShowMessageBox(
                0,
                ref emptyGuid,
                title,
                message,
                null,
                0,
                msgButton,
                defaultButton,
                icon,
                0,
                out result));

            return result;
        }

        /// <include file='doc\VsShellUtilities.uex' path='docs/doc[@for="VsShellUtilities.GetTaskItems"]/*' />
        /// <devdoc>
        /// Get list of all tasks items.
        /// </devdoc>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>A list of task items.</returns>
        public static IList<IVsTaskItem2> GetTaskItems(IServiceProvider serviceProvider)
        {
            IList<IVsTaskItem2> tasks = new List<IVsTaskItem2>();

            if (serviceProvider == null)
            {
                throw new ArgumentException("serviceProvider");
            }

            IVsTaskList taskList = serviceProvider.GetService(typeof(IVsTaskList)) as IVsTaskList;

            if (taskList == null)
            {
                throw new InvalidOperationException();
            }

            IVsEnumTaskItems enumTaskItems;
            try
            {
                ErrorHandler.ThrowOnFailure(taskList.EnumTaskItems(out enumTaskItems));

                if (enumTaskItems == null)
                {
                    return tasks;
                }

                int result = VSConstants.E_FAIL;
                uint[] fetched = new uint[1];
                do
                {
                    IVsTaskItem[] taskItems = new IVsTaskItem[1];

                    result = enumTaskItems.Next(1, taskItems, fetched);

                    if (fetched[0] == 1)
                    {
                        IVsTaskItem2 taskItem = taskItems[0] as IVsTaskItem2;
                        tasks.Add(taskItem);
                    }

                } while (result == VSConstants.S_OK && fetched[0] == 1);
            }
            catch (COMException e)
            {
                Trace.WriteLine("Exception : " + e.Message);
            }

            return tasks;
        }

        /// <include file='doc\VsShellUtilities.uex' path='docs/doc[@for="VsShellUtilities.EmptyTaskList"]/*' />
        /// <devdoc>
        /// Empty the task list.
        /// </devdoc>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>If the method succeeds, it returns S_OK. If it fails, it returns an error code. </returns>
        public static int EmptyTaskList(IServiceProvider serviceProvider)
        {
            if (serviceProvider == null)
            {
                throw new ArgumentException("serviceProvider");
            }

            IVsTaskList taskList = serviceProvider.GetService(typeof(IVsTaskList)) as IVsTaskList;

            if (taskList == null)
            {
                throw new InvalidOperationException();
            }

            IVsEnumTaskItems enumTaskItems;
            int result = VSConstants.S_OK;
            try
            {
                ErrorHandler.ThrowOnFailure(taskList.EnumTaskItems(out enumTaskItems));

                if (enumTaskItems == null)
                {
                    throw new InvalidOperationException();
                }

                // Retrieve the task item text and check whether it is equal with one that supposed to be thrown.
                
                uint[] fetched = new uint[1];
                do
                {
                    IVsTaskItem[] taskItems = new IVsTaskItem[1];

                    result = enumTaskItems.Next(1, taskItems, fetched);

                    if (fetched[0] == 1)
                    {
                        IVsTaskItem2 taskItem = taskItems[0] as IVsTaskItem2;
                        if (taskItem != null)
                        {
                            int canDelete;
                            ErrorHandler.ThrowOnFailure(taskItem.CanDelete(out canDelete));
                            if (canDelete == 1)
                            {
                                ErrorHandler.ThrowOnFailure(taskItem.OnDeleteTask());
                            }
                        }
                    }

                } while (result == VSConstants.S_OK && fetched[0] == 1);

            }
            catch (COMException e)
            {
                Trace.WriteLine("Exception : " + e.Message);
                result = e.ErrorCode;
            }

            return result;
        }

        /// <include file='doc\VsShellUtilities.uex' path='docs/doc[@for="VsShellUtilities.LaunchDebugger"]/*' />
        /// <devdoc>
        /// Launch the debugger.
        /// </devdoc>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="info">A reference to a VsDebugTargetInfo object.</param>
        public static void LaunchDebugger(IServiceProvider serviceProvider, VsDebugTargetInfo info)
        {
            Debug.Assert(serviceProvider != null, "Cannot launch the debugger on an empty service provider");
            if (serviceProvider == null)
            {
                throw new ArgumentException("serviceProvider");
            }

            info.cbSize = (uint)Marshal.SizeOf(info);
            IntPtr ptr = Marshal.AllocCoTaskMem((int)info.cbSize);
            Marshal.StructureToPtr(info, ptr, false);
            try
            {
                IVsDebugger d = serviceProvider.GetService(typeof(IVsDebugger)) as IVsDebugger;
                Debug.Assert(d != null, "Could not retrieve IVsDebugger from " + serviceProvider.GetType().Name);

                if (d == null)
                {
                    throw new InvalidOperationException();
                }
                
                ErrorHandler.ThrowOnFailure(d.LaunchDebugTargets(1, ptr));
            }
            catch (COMException e)
            {
                Trace.WriteLine("Exception : " + e.Message);
            }
            finally
            {
                if (ptr != IntPtr.Zero)
                {
                    Marshal.FreeCoTaskMem(ptr);
                }
            }
        }

        /// <include file='doc\VsShellUtilities.uex' path='docs/doc[@for="VsShellUtilities.GetHierarchy"]/*' />
        /// <devdoc>
        /// Get reference to IVsHierarchy interface from project guid.
        /// </devdoc>
        /// <param name="site">The service provider.</param>
        /// <param name="projectGuid">A project guid.</param>
        ///<returns>A reference to an IVsHierarchy interface.</returns>
        public static IVsHierarchy GetHierarchy(IServiceProvider site, Guid projectGuid)
        {
            if (site == null)
            {
                throw new ArgumentException("site");
            }

            if (projectGuid == Guid.Empty)
            {
                throw new ArgumentException("projectGuid");
            }

            IVsHierarchy hierarchy = null;

            IVsSolution solution = site.GetService(typeof(SVsSolution)) as IVsSolution;

            if (solution == null)
            {
                throw new InvalidOperationException();
            }

            try
            {
                solution.GetProjectOfGuid(ref projectGuid, out hierarchy);
            }
            catch (COMException e)
            {
                Trace.WriteLine("Exception :" + e.Message);
            }
            // If the project is not loaded this is the exception thrown.
            catch (InvalidCastException e)
            {
                Trace.WriteLine("Exception :" + e.Message);
            }

            return hierarchy;
        }

        /// <include file='doc\VsShellUtilities.uex' path='docs/doc[@for="VsShellUtilities.GetUIHierarchyWindow"]/*' />
        /// <devdoc>
        /// Get reference to IVsUIHierarchyWindow interface from guid persistence slot.
        /// </devdoc>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="guidPersistenceSlot">Unique identifier for a tool window created using IVsUIShell::CreateToolWindow. The caller of this method can use predefined identifiers that map to tool windows if those tool windows are known to the caller. </param>
        /// <returns>A reference to an IVsUIHierarchyWindow interface.</returns>
        public static IVsUIHierarchyWindow GetUIHierarchyWindow(IServiceProvider serviceProvider, Guid guidPersistenceSlot)
        {
            if (serviceProvider == null)
            {
                throw new ArgumentException("serviceProvider");
            }

            IVsUIShell shell = serviceProvider.GetService(typeof(SVsUIShell)) as IVsUIShell;

            Debug.Assert(shell != null, "Could not get the ui shell from the project");
            if (shell == null)
            {
                throw new InvalidOperationException();
            }

            object pvar = null;
            IVsWindowFrame frame = null;
            IVsUIHierarchyWindow uiHierarchyWindow = null;

            try
            {
                ErrorHandler.ThrowOnFailure(shell.FindToolWindow(0, ref guidPersistenceSlot, out frame));
                ErrorHandler.ThrowOnFailure(frame.GetProperty((int)__VSFPROPID.VSFPROPID_DocView, out pvar));
            }
            catch (COMException e)
            {
                Trace.WriteLine("Exception :" + e.Message);
            }
            finally
            {
                if (pvar != null)
                {
                    IVsWindowPane pane = (IVsWindowPane)pvar;

                    uiHierarchyWindow = (IVsUIHierarchyWindow)pane;
                }
            }

            return uiHierarchyWindow;
        }

        /// <include file='doc\VsShellUtilities.uex' path='docs/doc[@for="VsShellUtilities.GetOutputWindowPane"]/*' />
        /// <devdoc>
        /// Get reference to IVsOutputWindowPane interface from pane guid.
        /// </devdoc>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="guidPane">A guid for the pane.</param>
        /// <returns>A reference to an IVsOutputWindowPane interface.</returns>
        public static IVsOutputWindowPane GetOutputWindowPane(IServiceProvider serviceProvider, Guid guidPane)
        {
            if (serviceProvider == null)
            {
                throw new ArgumentException("serviceProvider");
            }

            IVsOutputWindow outputWindow = serviceProvider.GetService(typeof(IVsOutputWindow)) as IVsOutputWindow;
            if (outputWindow == null)
            {
                throw new InvalidOperationException();
            }

            IVsOutputWindowPane outputWindowPane = null;
            try
            {
                ErrorHandler.ThrowOnFailure(outputWindow.GetPane(ref guidPane, out outputWindowPane));
            }
            catch (COMException e)
            {
                Trace.WriteLine("Exception :" + e.Message);
            }

            return outputWindowPane;
        }

        /// <include file='doc\VsShellUtilities.uex' path='docs/doc[@for="VsShellUtilities.GetDebugMode"]/*' />
        /// <devdoc>
        /// Get debug mode of the shell (design/break/shell).
        /// </devdoc>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>A DBGMODE enumeration.</returns>
        public static DBGMODE GetDebugMode(IServiceProvider serviceProvider)
        {
            DBGMODE[] dbgmode = new DBGMODE[1] { DBGMODE.DBGMODE_Design };

            if (serviceProvider == null)
            {
                throw new ArgumentException("serviceProvider");
            }

            IVsDebugger debugger = serviceProvider.GetService(typeof(IVsDebugger)) as IVsDebugger;

            if (debugger == null)
            {
                throw new InvalidOperationException();
            }

            try
            {
                ErrorHandler.ThrowOnFailure(debugger.GetMode(dbgmode));
            }
            catch (COMException e)
            {
                Trace.WriteLine("Exception :" + e.Message);
            }

            return dbgmode[0];
        }

        /// <include file='doc\VsShellUtilities.uex' path='docs/doc[@for="VsShellUtilities.IsVisualStudioInDesignMode"]/*' />
        /// <devdoc>
        /// Is Visual Studio in design mode.
        /// </devdoc>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>true if visual studio is in design mode</returns>
        public static bool IsVisualStudioInDesignMode(IServiceProvider serviceProvider)
        {
            if (serviceProvider == null)
            {
                throw new ArgumentException("serviceProvider");
            }

            DBGMODE dbgMode = GetDebugMode(serviceProvider) & ~DBGMODE.DBGMODE_EncMask;

            return dbgMode == DBGMODE.DBGMODE_Design;
        }

        /// <include file='doc\VsShellUtilities.uex' path='docs/doc[@for="VsShellUtilities.IsSolutionBuilding"]/*' />
        /// <devdoc>
        /// Is current solution building or deploying
        /// </devdoc>
        /// <param name="serviceProvider">The service provider</param>
        /// <returns>true if solution is building or deploying.</returns>
        public static bool IsSolutionBuilding(IServiceProvider serviceProvider)
        {
            if (serviceProvider == null)
            {
                throw new ArgumentException("serviceProvider");
            }

            IVsSolutionBuildManager solutionBuildManager = serviceProvider.GetService(typeof(IVsSolutionBuildManager)) as IVsSolutionBuildManager;

            if (solutionBuildManager == null)
            {
                throw new InvalidOperationException();
            }

            int returnValueAsInteger = 0;
            ErrorHandler.ThrowOnFailure(solutionBuildManager.QueryBuildManagerBusy(out returnValueAsInteger));
            return (returnValueAsInteger == 1);
        }

        /// <include file='doc\VsShellUtilities.uex' path='docs/doc[@for="VsShellUtilities.IsInAutomationFunction"]/*' />
        /// <devdoc>
        /// Is an extensibility object executing an automation function.
        /// </devdoc>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>true if the extensiblity object is executing an automation function.</returns>
        public static bool IsInAutomationFunction(IServiceProvider serviceProvider)
        {
            if (serviceProvider == null)
            {
                throw new ArgumentException("serviceProvider");
            }

            IVsExtensibility extensibility = serviceProvider.GetService(typeof(IVsExtensibility)) as IVsExtensibility;

            if (extensibility == null)
            {
                throw new InvalidOperationException();
            }

            return (extensibility.IsInAutomationFunction() == 0) ? false : true;
        }
    }
}
