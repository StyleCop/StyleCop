// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MockTextManager.cs" company="https://github.com/StyleCop">
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
//   The mock text manager.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace VSPackageUnitTest.Mocks
{
    using System;
    using System.Collections.Generic;

    using Microsoft.VisualStudio;
    using Microsoft.VisualStudio.TextManager.Interop;

    /// <summary>
    /// The mock text manager.
    /// </summary>
    internal class MockTextManager : IVsTextManager
    {
        #region Constants and Fields

        private readonly Dictionary<string, MockTextView> _views = new Dictionary<string, MockTextView>();

        #endregion

        #region Public Methods

        /// <summary>
        /// The add view.
        /// </summary>
        /// <param name="fileName">
        /// The file name.
        /// </param>
        /// <returns>
        /// </returns>
        public MockTextView AddView(string fileName)
        {
            MockTextView view = new MockTextView();
            this._views.Add(fileName, view);
            return view;
        }

        #endregion

        #region Implemented Interfaces

        #region IVsTextManager

        /// <summary>
        /// The adjust file change ignore count.
        /// </summary>
        /// <param name="pBuffer">
        /// The p buffer.
        /// </param>
        /// <param name="fIgnore">
        /// The f ignore.
        /// </param>
        /// <returns>
        /// The adjust file change ignore count.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int AdjustFileChangeIgnoreCount(IVsTextBuffer pBuffer, int fIgnore)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The attempt to check out buffer from scc.
        /// </summary>
        /// <param name="pBufData">
        /// The p buf data.
        /// </param>
        /// <param name="pfCheckoutSucceeded">
        /// The pf checkout succeeded.
        /// </param>
        /// <returns>
        /// The attempt to check out buffer from scc.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int AttemptToCheckOutBufferFromScc(IVsUserData pBufData, out int pfCheckoutSucceeded)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The attempt to check out buffer from scc 2.
        /// </summary>
        /// <param name="pszFileName">
        /// The psz file name.
        /// </param>
        /// <param name="pfCheckoutSucceeded">
        /// The pf checkout succeeded.
        /// </param>
        /// <param name="piStatusFlags">
        /// The pi status flags.
        /// </param>
        /// <returns>
        /// The attempt to check out buffer from scc 2.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int AttemptToCheckOutBufferFromScc2(string pszFileName, out int pfCheckoutSucceeded, out int piStatusFlags)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The create selection action.
        /// </summary>
        /// <param name="pBuffer">
        /// The p buffer.
        /// </param>
        /// <param name="ppAction">
        /// The pp action.
        /// </param>
        /// <returns>
        /// The create selection action.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int CreateSelectionAction(IVsTextBuffer pBuffer, out IVsTextSelectionAction ppAction)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The enum buffers.
        /// </summary>
        /// <param name="ppEnum">
        /// The pp enum.
        /// </param>
        /// <returns>
        /// The enum buffers.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int EnumBuffers(out IVsEnumTextBuffers ppEnum)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The enum independent views.
        /// </summary>
        /// <param name="pBuffer">
        /// The p buffer.
        /// </param>
        /// <param name="ppEnum">
        /// The pp enum.
        /// </param>
        /// <returns>
        /// The enum independent views.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int EnumIndependentViews(IVsTextBuffer pBuffer, out IVsEnumIndependentViews ppEnum)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The enum language services.
        /// </summary>
        /// <param name="ppEnum">
        /// The pp enum.
        /// </param>
        /// <returns>
        /// The enum language services.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int EnumLanguageServices(out IVsEnumGUID ppEnum)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The enum views.
        /// </summary>
        /// <param name="pBuffer">
        /// The p buffer.
        /// </param>
        /// <param name="ppEnum">
        /// The pp enum.
        /// </param>
        /// <returns>
        /// The enum views.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int EnumViews(IVsTextBuffer pBuffer, out IVsEnumTextViews ppEnum)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The get active view.
        /// </summary>
        /// <param name="fMustHaveFocus">
        /// The f must have focus.
        /// </param>
        /// <param name="pBuffer">
        /// The p buffer.
        /// </param>
        /// <param name="ppView">
        /// The pp view.
        /// </param>
        /// <returns>
        /// The get active view.
        /// </returns>
        public int GetActiveView(int fMustHaveFocus, IVsTextBuffer pBuffer, out IVsTextView ppView)
        {
            string fileName = ((MockTextLines)pBuffer).FileName;

            if (this._views.ContainsKey(fileName))
            {
                ppView = this._views[fileName];
                return VSConstants.S_OK;
            }
            else
            {
                ppView = null;
                return VSConstants.E_INVALIDARG;
            }
        }

        /// <summary>
        /// The get buffer scc status.
        /// </summary>
        /// <param name="pBufData">
        /// The p buf data.
        /// </param>
        /// <param name="pbNonEditable">
        /// The pb non editable.
        /// </param>
        /// <returns>
        /// The get buffer scc status.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int GetBufferSccStatus(IVsUserData pBufData, out int pbNonEditable)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The get buffer scc status 2.
        /// </summary>
        /// <param name="pszFileName">
        /// The psz file name.
        /// </param>
        /// <param name="pbNonEditable">
        /// The pb non editable.
        /// </param>
        /// <param name="piStatusFlags">
        /// The pi status flags.
        /// </param>
        /// <returns>
        /// The get buffer scc status 2.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int GetBufferSccStatus2(string pszFileName, out int pbNonEditable, out int piStatusFlags)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The get marker type count.
        /// </summary>
        /// <param name="piMarkerTypeCount">
        /// The pi marker type count.
        /// </param>
        /// <returns>
        /// The get marker type count.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int GetMarkerTypeCount(out int piMarkerTypeCount)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The get marker type interface.
        /// </summary>
        /// <param name="iMarkerTypeID">
        /// The i marker type id.
        /// </param>
        /// <param name="ppMarkerType">
        /// The pp marker type.
        /// </param>
        /// <returns>
        /// The get marker type interface.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int GetMarkerTypeInterface(int iMarkerTypeID, out IVsTextMarkerType ppMarkerType)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The get per language preferences.
        /// </summary>
        /// <param name="pLangPrefs">
        /// The p lang prefs.
        /// </param>
        /// <returns>
        /// The get per language preferences.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int GetPerLanguagePreferences(LANGPREFERENCES[] pLangPrefs)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The get registered marker type id.
        /// </summary>
        /// <param name="pguidMarker">
        /// The pguid marker.
        /// </param>
        /// <param name="piMarkerTypeID">
        /// The pi marker type id.
        /// </param>
        /// <returns>
        /// The get registered marker type id.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int GetRegisteredMarkerTypeID(ref Guid pguidMarker, out int piMarkerTypeID)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The get shortcut manager.
        /// </summary>
        /// <param name="ppShortcutMgr">
        /// The pp shortcut mgr.
        /// </param>
        /// <returns>
        /// The get shortcut manager.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int GetShortcutManager(out IVsShortcutManager ppShortcutMgr)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The get user preferences.
        /// </summary>
        /// <param name="pViewPrefs">
        /// The p view prefs.
        /// </param>
        /// <param name="pFramePrefs">
        /// The p frame prefs.
        /// </param>
        /// <param name="pLangPrefs">
        /// The p lang prefs.
        /// </param>
        /// <param name="pColorPrefs">
        /// The p color prefs.
        /// </param>
        /// <returns>
        /// The get user preferences.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int GetUserPreferences(VIEWPREFERENCES[] pViewPrefs, FRAMEPREFERENCES[] pFramePrefs, LANGPREFERENCES[] pLangPrefs, FONTCOLORPREFERENCES[] pColorPrefs)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The ignore next file change.
        /// </summary>
        /// <param name="pBuffer">
        /// The p buffer.
        /// </param>
        /// <returns>
        /// The ignore next file change.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int IgnoreNextFileChange(IVsTextBuffer pBuffer)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The map filename to language sid.
        /// </summary>
        /// <param name="pszFileName">
        /// The psz file name.
        /// </param>
        /// <param name="pguidLangSID">
        /// The pguid lang sid.
        /// </param>
        /// <returns>
        /// The map filename to language sid.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int MapFilenameToLanguageSID(string pszFileName, out Guid pguidLangSID)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The navigate to line and column.
        /// </summary>
        /// <param name="pBuffer">
        /// The p buffer.
        /// </param>
        /// <param name="guidDocViewType">
        /// The guid doc view type.
        /// </param>
        /// <param name="iStartRow">
        /// The i start row.
        /// </param>
        /// <param name="iStartIndex">
        /// The i start index.
        /// </param>
        /// <param name="iEndRow">
        /// The i end row.
        /// </param>
        /// <param name="iEndIndex">
        /// The i end index.
        /// </param>
        /// <returns>
        /// The navigate to line and column.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int NavigateToLineAndColumn(IVsTextBuffer pBuffer, ref Guid guidDocViewType, int iStartRow, int iStartIndex, int iEndRow, int iEndIndex)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The navigate to position.
        /// </summary>
        /// <param name="pBuffer">
        /// The p buffer.
        /// </param>
        /// <param name="guidDocViewType">
        /// The guid doc view type.
        /// </param>
        /// <param name="iPos">
        /// The i pos.
        /// </param>
        /// <param name="iLen">
        /// The i len.
        /// </param>
        /// <returns>
        /// The navigate to position.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int NavigateToPosition(IVsTextBuffer pBuffer, ref Guid guidDocViewType, int iPos, int iLen)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The register buffer.
        /// </summary>
        /// <param name="pBuffer">
        /// The p buffer.
        /// </param>
        /// <returns>
        /// The register buffer.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int RegisterBuffer(IVsTextBuffer pBuffer)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The register independent view.
        /// </summary>
        /// <param name="pUnk">
        /// The p unk.
        /// </param>
        /// <param name="pBuffer">
        /// The p buffer.
        /// </param>
        /// <returns>
        /// The register independent view.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int RegisterIndependentView(object pUnk, IVsTextBuffer pBuffer)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The register view.
        /// </summary>
        /// <param name="pView">
        /// The p view.
        /// </param>
        /// <param name="pBuffer">
        /// The p buffer.
        /// </param>
        /// <returns>
        /// The register view.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int RegisterView(IVsTextView pView, IVsTextBuffer pBuffer)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The set file change advise.
        /// </summary>
        /// <param name="pszFileName">
        /// The psz file name.
        /// </param>
        /// <param name="fStart">
        /// The f start.
        /// </param>
        /// <returns>
        /// The set file change advise.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int SetFileChangeAdvise(string pszFileName, int fStart)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The set per language preferences.
        /// </summary>
        /// <param name="pLangPrefs">
        /// The p lang prefs.
        /// </param>
        /// <returns>
        /// The set per language preferences.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int SetPerLanguagePreferences(LANGPREFERENCES[] pLangPrefs)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The set user preferences.
        /// </summary>
        /// <param name="pViewPrefs">
        /// The p view prefs.
        /// </param>
        /// <param name="pFramePrefs">
        /// The p frame prefs.
        /// </param>
        /// <param name="pLangPrefs">
        /// The p lang prefs.
        /// </param>
        /// <param name="pColorPrefs">
        /// The p color prefs.
        /// </param>
        /// <returns>
        /// The set user preferences.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int SetUserPreferences(VIEWPREFERENCES[] pViewPrefs, FRAMEPREFERENCES[] pFramePrefs, LANGPREFERENCES[] pLangPrefs, FONTCOLORPREFERENCES[] pColorPrefs)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The suspend file change advise.
        /// </summary>
        /// <param name="pszFileName">
        /// The psz file name.
        /// </param>
        /// <param name="fSuspend">
        /// The f suspend.
        /// </param>
        /// <returns>
        /// The suspend file change advise.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int SuspendFileChangeAdvise(string pszFileName, int fSuspend)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The unregister buffer.
        /// </summary>
        /// <param name="pBuffer">
        /// The p buffer.
        /// </param>
        /// <returns>
        /// The unregister buffer.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int UnregisterBuffer(IVsTextBuffer pBuffer)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The unregister independent view.
        /// </summary>
        /// <param name="pUnk">
        /// The p unk.
        /// </param>
        /// <param name="pBuffer">
        /// The p buffer.
        /// </param>
        /// <returns>
        /// The unregister independent view.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int UnregisterIndependentView(object pUnk, IVsTextBuffer pBuffer)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The unregister view.
        /// </summary>
        /// <param name="pView">
        /// The p view.
        /// </param>
        /// <returns>
        /// The unregister view.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int UnregisterView(IVsTextView pView)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        #endregion
    }
}