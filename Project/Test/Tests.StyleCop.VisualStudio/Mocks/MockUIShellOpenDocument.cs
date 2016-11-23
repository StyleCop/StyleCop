// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MockUIShellOpenDocument.cs" company="https://github.com/StyleCop">
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
//   The mock ui shell open document.
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
    /// The mock ui shell open document.
    /// </summary>
    internal class MockUIShellOpenDocument : IVsUIShellOpenDocument
    {
        #region Constants and Fields

        private readonly Dictionary<string, MockWindowFrame> _documents = new Dictionary<string, MockWindowFrame>();

        #endregion

        #region Public Methods

        /// <summary>
        /// The add document.
        /// </summary>
        /// <param name="path">
        /// The path.
        /// </param>
        /// <returns>
        /// </returns>
        public MockWindowFrame AddDocument(string path)
        {
            MockWindowFrame frame = new MockWindowFrame();
            frame.TextLines = new MockTextLines(path);
            this._documents.Add(path, frame);
            return frame;
        }

        #endregion

        #region Implemented Interfaces

        #region IVsUIShellOpenDocument

        /// <summary>
        /// The add standard previewer.
        /// </summary>
        /// <param name="pszExePath">
        /// The psz exe path.
        /// </param>
        /// <param name="pszDisplayName">
        /// The psz display name.
        /// </param>
        /// <param name="fUseDDE">
        /// The f use dde.
        /// </param>
        /// <param name="pszDDEService">
        /// The psz dde service.
        /// </param>
        /// <param name="pszDDETopicOpenURL">
        /// The psz dde topic open url.
        /// </param>
        /// <param name="pszDDEItemOpenURL">
        /// The psz dde item open url.
        /// </param>
        /// <param name="pszDDETopicActivate">
        /// The psz dde topic activate.
        /// </param>
        /// <param name="pszDDEItemActivate">
        /// The psz dde item activate.
        /// </param>
        /// <param name="aspAddPreviewerFlags">
        /// The asp add previewer flags.
        /// </param>
        /// <returns>
        /// The add standard previewer.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int AddStandardPreviewer(
            string pszExePath, 
            string pszDisplayName, 
            int fUseDDE, 
            string pszDDEService, 
            string pszDDETopicOpenURL, 
            string pszDDEItemOpenURL, 
            string pszDDETopicActivate, 
            string pszDDEItemActivate, 
            uint aspAddPreviewerFlags)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The get first default previewer.
        /// </summary>
        /// <param name="pbstrDefBrowserPath">
        /// The pbstr def browser path.
        /// </param>
        /// <param name="pfIsInternalBrowser">
        /// The pf is internal browser.
        /// </param>
        /// <param name="pfIsSystemBrowser">
        /// The pf is system browser.
        /// </param>
        /// <returns>
        /// The get first default previewer.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int GetFirstDefaultPreviewer(out string pbstrDefBrowserPath, out int pfIsInternalBrowser, out int pfIsSystemBrowser)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The get standard editor factory.
        /// </summary>
        /// <param name="dwReserved">
        /// The dw reserved.
        /// </param>
        /// <param name="pguidEditorType">
        /// The pguid editor type.
        /// </param>
        /// <param name="pszMkDocument">
        /// The psz mk document.
        /// </param>
        /// <param name="rguidLogicalView">
        /// The rguid logical view.
        /// </param>
        /// <param name="pbstrPhysicalView">
        /// The pbstr physical view.
        /// </param>
        /// <param name="ppEF">
        /// The pp ef.
        /// </param>
        /// <returns>
        /// The get standard editor factory.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int GetStandardEditorFactory(uint dwReserved, ref Guid pguidEditorType, string pszMkDocument, ref Guid rguidLogicalView, out string pbstrPhysicalView, out IVsEditorFactory ppEF)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The initialize editor instance.
        /// </summary>
        /// <param name="grfIEI">
        /// The grf iei.
        /// </param>
        /// <param name="punkDocView">
        /// The punk doc view.
        /// </param>
        /// <param name="punkDocData">
        /// The punk doc data.
        /// </param>
        /// <param name="pszMkDocument">
        /// The psz mk document.
        /// </param>
        /// <param name="rguidEditorType">
        /// The rguid editor type.
        /// </param>
        /// <param name="pszPhysicalView">
        /// The psz physical view.
        /// </param>
        /// <param name="rguidLogicalView">
        /// The rguid logical view.
        /// </param>
        /// <param name="pszOwnerCaption">
        /// The psz owner caption.
        /// </param>
        /// <param name="pszEditorCaption">
        /// The psz editor caption.
        /// </param>
        /// <param name="pHier">
        /// The p hier.
        /// </param>
        /// <param name="itemid">
        /// The itemid.
        /// </param>
        /// <param name="punkDocDataExisting">
        /// The punk doc data existing.
        /// </param>
        /// <param name="pSPHierContext">
        /// The p sp hier context.
        /// </param>
        /// <param name="rguidCmdUI">
        /// The rguid cmd ui.
        /// </param>
        /// <param name="ppWindowFrame">
        /// The pp window frame.
        /// </param>
        /// <returns>
        /// The initialize editor instance.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int InitializeEditorInstance(
            uint grfIEI, 
            IntPtr punkDocView, 
            IntPtr punkDocData, 
            string pszMkDocument, 
            ref Guid rguidEditorType, 
            string pszPhysicalView, 
            ref Guid rguidLogicalView, 
            string pszOwnerCaption, 
            string pszEditorCaption, 
            IVsUIHierarchy pHier, 
            uint itemid, 
            IntPtr punkDocDataExisting, 
            IServiceProvider pSPHierContext, 
            ref Guid rguidCmdUI, 
            out IVsWindowFrame ppWindowFrame)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The is document in a project.
        /// </summary>
        /// <param name="pszMkDocument">
        /// The psz mk document.
        /// </param>
        /// <param name="ppUIH">
        /// The pp uih.
        /// </param>
        /// <param name="pitemid">
        /// The pitemid.
        /// </param>
        /// <param name="ppSP">
        /// The pp sp.
        /// </param>
        /// <param name="pDocInProj">
        /// The p doc in proj.
        /// </param>
        /// <returns>
        /// The is document in a project.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int IsDocumentInAProject(string pszMkDocument, out IVsUIHierarchy ppUIH, out uint pitemid, out IServiceProvider ppSP, out int pDocInProj)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The is document open.
        /// </summary>
        /// <param name="pHierCaller">
        /// The p hier caller.
        /// </param>
        /// <param name="itemidCaller">
        /// The itemid caller.
        /// </param>
        /// <param name="pszMkDocument">
        /// The psz mk document.
        /// </param>
        /// <param name="rguidLogicalView">
        /// The rguid logical view.
        /// </param>
        /// <param name="grfIDO">
        /// The grf ido.
        /// </param>
        /// <param name="ppHierOpen">
        /// The pp hier open.
        /// </param>
        /// <param name="pitemidOpen">
        /// The pitemid open.
        /// </param>
        /// <param name="ppWindowFrame">
        /// The pp window frame.
        /// </param>
        /// <param name="pfOpen">
        /// The pf open.
        /// </param>
        /// <returns>
        /// The is document open.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int IsDocumentOpen(
            IVsUIHierarchy pHierCaller, 
            uint itemidCaller, 
            string pszMkDocument, 
            ref Guid rguidLogicalView, 
            uint grfIDO, 
            out IVsUIHierarchy ppHierOpen, 
            uint[] pitemidOpen, 
            out IVsWindowFrame ppWindowFrame, 
            out int pfOpen)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The is specific document view open.
        /// </summary>
        /// <param name="pHierCaller">
        /// The p hier caller.
        /// </param>
        /// <param name="itemidCaller">
        /// The itemid caller.
        /// </param>
        /// <param name="pszMkDocument">
        /// The psz mk document.
        /// </param>
        /// <param name="rguidEditorType">
        /// The rguid editor type.
        /// </param>
        /// <param name="pszPhysicalView">
        /// The psz physical view.
        /// </param>
        /// <param name="grfIDO">
        /// The grf ido.
        /// </param>
        /// <param name="ppHierOpen">
        /// The pp hier open.
        /// </param>
        /// <param name="pitemidOpen">
        /// The pitemid open.
        /// </param>
        /// <param name="ppWindowFrame">
        /// The pp window frame.
        /// </param>
        /// <param name="pfOpen">
        /// The pf open.
        /// </param>
        /// <returns>
        /// The is specific document view open.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int IsSpecificDocumentViewOpen(
            IVsUIHierarchy pHierCaller, 
            uint itemidCaller, 
            string pszMkDocument, 
            ref Guid rguidEditorType, 
            string pszPhysicalView, 
            uint grfIDO, 
            out IVsUIHierarchy ppHierOpen, 
            out uint pitemidOpen, 
            out IVsWindowFrame ppWindowFrame, 
            out int pfOpen)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The map logical view.
        /// </summary>
        /// <param name="rguidEditorType">
        /// The rguid editor type.
        /// </param>
        /// <param name="rguidLogicalView">
        /// The rguid logical view.
        /// </param>
        /// <param name="pbstrPhysicalView">
        /// The pbstr physical view.
        /// </param>
        /// <returns>
        /// The map logical view.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int MapLogicalView(ref Guid rguidEditorType, ref Guid rguidLogicalView, out string pbstrPhysicalView)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The open copy of standard editor.
        /// </summary>
        /// <param name="pWindowFrame">
        /// The p window frame.
        /// </param>
        /// <param name="rguidLogicalView">
        /// The rguid logical view.
        /// </param>
        /// <param name="ppNewWindowFrame">
        /// The pp new window frame.
        /// </param>
        /// <returns>
        /// The open copy of standard editor.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int OpenCopyOfStandardEditor(IVsWindowFrame pWindowFrame, ref Guid rguidLogicalView, out IVsWindowFrame ppNewWindowFrame)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The open document via project.
        /// </summary>
        /// <param name="pszMkDocument">
        /// The psz mk document.
        /// </param>
        /// <param name="rguidLogicalView">
        /// The rguid logical view.
        /// </param>
        /// <param name="ppSP">
        /// The pp sp.
        /// </param>
        /// <param name="ppHier">
        /// The pp hier.
        /// </param>
        /// <param name="pitemid">
        /// The pitemid.
        /// </param>
        /// <param name="ppWindowFrame">
        /// The pp window frame.
        /// </param>
        /// <returns>
        /// The open document via project.
        /// </returns>
        public int OpenDocumentViaProject(
            string pszMkDocument, ref Guid rguidLogicalView, out IServiceProvider ppSP, out IVsUIHierarchy ppHier, out uint pitemid, out IVsWindowFrame ppWindowFrame)
        {
            ppSP = null;
            ppHier = null;
            pitemid = 0;

            if (this._documents.ContainsKey(pszMkDocument))
            {
                ppWindowFrame = this._documents[pszMkDocument];
                return VSConstants.S_OK;
            }
            else
            {
                ppWindowFrame = null;
                return VSConstants.E_INVALIDARG;
            }
        }

        /// <summary>
        /// The open document via project with specific.
        /// </summary>
        /// <param name="pszMkDocument">
        /// The psz mk document.
        /// </param>
        /// <param name="grfEditorFlags">
        /// The grf editor flags.
        /// </param>
        /// <param name="rguidEditorType">
        /// The rguid editor type.
        /// </param>
        /// <param name="pszPhysicalView">
        /// The psz physical view.
        /// </param>
        /// <param name="rguidLogicalView">
        /// The rguid logical view.
        /// </param>
        /// <param name="ppSP">
        /// The pp sp.
        /// </param>
        /// <param name="ppHier">
        /// The pp hier.
        /// </param>
        /// <param name="pitemid">
        /// The pitemid.
        /// </param>
        /// <param name="ppWindowFrame">
        /// The pp window frame.
        /// </param>
        /// <returns>
        /// The open document via project with specific.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int OpenDocumentViaProjectWithSpecific(
            string pszMkDocument, 
            uint grfEditorFlags, 
            ref Guid rguidEditorType, 
            string pszPhysicalView, 
            ref Guid rguidLogicalView, 
            out IServiceProvider ppSP, 
            out IVsUIHierarchy ppHier, 
            out uint pitemid, 
            out IVsWindowFrame ppWindowFrame)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The open specific editor.
        /// </summary>
        /// <param name="grfOpenSpecific">
        /// The grf open specific.
        /// </param>
        /// <param name="pszMkDocument">
        /// The psz mk document.
        /// </param>
        /// <param name="rguidEditorType">
        /// The rguid editor type.
        /// </param>
        /// <param name="pszPhysicalView">
        /// The psz physical view.
        /// </param>
        /// <param name="rguidLogicalView">
        /// The rguid logical view.
        /// </param>
        /// <param name="pszOwnerCaption">
        /// The psz owner caption.
        /// </param>
        /// <param name="pHier">
        /// The p hier.
        /// </param>
        /// <param name="itemid">
        /// The itemid.
        /// </param>
        /// <param name="punkDocDataExisting">
        /// The punk doc data existing.
        /// </param>
        /// <param name="pSPHierContext">
        /// The p sp hier context.
        /// </param>
        /// <param name="ppWindowFrame">
        /// The pp window frame.
        /// </param>
        /// <returns>
        /// The open specific editor.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int OpenSpecificEditor(
            uint grfOpenSpecific, 
            string pszMkDocument, 
            ref Guid rguidEditorType, 
            string pszPhysicalView, 
            ref Guid rguidLogicalView, 
            string pszOwnerCaption, 
            IVsUIHierarchy pHier, 
            uint itemid, 
            IntPtr punkDocDataExisting, 
            IServiceProvider pSPHierContext, 
            out IVsWindowFrame ppWindowFrame)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The open standard editor.
        /// </summary>
        /// <param name="grfOpenStandard">
        /// The grf open standard.
        /// </param>
        /// <param name="pszMkDocument">
        /// The psz mk document.
        /// </param>
        /// <param name="rguidLogicalView">
        /// The rguid logical view.
        /// </param>
        /// <param name="pszOwnerCaption">
        /// The psz owner caption.
        /// </param>
        /// <param name="pHier">
        /// The p hier.
        /// </param>
        /// <param name="itemid">
        /// The itemid.
        /// </param>
        /// <param name="punkDocDataExisting">
        /// The punk doc data existing.
        /// </param>
        /// <param name="psp">
        /// The psp.
        /// </param>
        /// <param name="ppWindowFrame">
        /// The pp window frame.
        /// </param>
        /// <returns>
        /// The open standard editor.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int OpenStandardEditor(
            uint grfOpenStandard, 
            string pszMkDocument, 
            ref Guid rguidLogicalView, 
            string pszOwnerCaption, 
            IVsUIHierarchy pHier, 
            uint itemid, 
            IntPtr punkDocDataExisting, 
            IServiceProvider psp, 
            out IVsWindowFrame ppWindowFrame)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The open standard previewer.
        /// </summary>
        /// <param name="ospOpenDocPreviewer">
        /// The osp open doc previewer.
        /// </param>
        /// <param name="pszURL">
        /// The psz url.
        /// </param>
        /// <param name="resolution">
        /// The resolution.
        /// </param>
        /// <param name="dwReserved">
        /// The dw reserved.
        /// </param>
        /// <returns>
        /// The open standard previewer.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int OpenStandardPreviewer(uint ospOpenDocPreviewer, string pszURL, VSPREVIEWRESOLUTION resolution, uint dwReserved)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The search projects for relative path.
        /// </summary>
        /// <param name="grfRPS">
        /// The grf rps.
        /// </param>
        /// <param name="pszRelPath">
        /// The psz rel path.
        /// </param>
        /// <param name="pbstrAbsPath">
        /// The pbstr abs path.
        /// </param>
        /// <returns>
        /// The search projects for relative path.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int SearchProjectsForRelativePath(uint grfRPS, string pszRelPath, string[] pbstrAbsPath)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        #endregion
    }
}