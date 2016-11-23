// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MockTextView.cs" company="https://github.com/StyleCop">
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
//   The mock text view.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace VSPackageUnitTest.Mocks
{
    using System;

    using Microsoft.VisualStudio;
    using Microsoft.VisualStudio.OLE.Interop;
    using Microsoft.VisualStudio.TextManager.Interop;

    /// <summary>
    /// The mock text view.
    /// </summary>
    internal class MockTextView : IVsTextView
    {
        #region Events

        /// <summary>
        /// The on set caret pos.
        /// </summary>
        public event EventHandler<SetCaretPosEventArgs> OnSetCaretPos;

        #endregion

        #region Implemented Interfaces

        #region IVsTextView

        /// <summary>
        /// The add command filter.
        /// </summary>
        /// <param name="pNewCmdTarg">
        /// The p new cmd targ.
        /// </param>
        /// <param name="ppNextCmdTarg">
        /// The pp next cmd targ.
        /// </param>
        /// <returns>
        /// The add command filter.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int AddCommandFilter(IOleCommandTarget pNewCmdTarg, out IOleCommandTarget ppNextCmdTarg)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The center columns.
        /// </summary>
        /// <param name="iLine">
        /// The i line.
        /// </param>
        /// <param name="iLeftCol">
        /// The i left col.
        /// </param>
        /// <param name="iColCount">
        /// The i col count.
        /// </param>
        /// <returns>
        /// The center columns.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int CenterColumns(int iLine, int iLeftCol, int iColCount)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The center lines.
        /// </summary>
        /// <param name="iTopLine">
        /// The i top line.
        /// </param>
        /// <param name="iCount">
        /// The i count.
        /// </param>
        /// <returns>
        /// The center lines.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int CenterLines(int iTopLine, int iCount)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The clear selection.
        /// </summary>
        /// <param name="fMoveToAnchor">
        /// The f move to anchor.
        /// </param>
        /// <returns>
        /// The clear selection.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int ClearSelection(int fMoveToAnchor)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The close view.
        /// </summary>
        /// <returns>
        /// The close view.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int CloseView()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The ensure span visible.
        /// </summary>
        /// <param name="span">
        /// The span.
        /// </param>
        /// <returns>
        /// The ensure span visible.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int EnsureSpanVisible(TextSpan span)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The get buffer.
        /// </summary>
        /// <param name="ppBuffer">
        /// The pp buffer.
        /// </param>
        /// <returns>
        /// The get buffer.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int GetBuffer(out IVsTextLines ppBuffer)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The get caret pos.
        /// </summary>
        /// <param name="piLine">
        /// The pi line.
        /// </param>
        /// <param name="piColumn">
        /// The pi column.
        /// </param>
        /// <returns>
        /// The get caret pos.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int GetCaretPos(out int piLine, out int piColumn)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The get line and column.
        /// </summary>
        /// <param name="iPos">
        /// The i pos.
        /// </param>
        /// <param name="piLine">
        /// The pi line.
        /// </param>
        /// <param name="piIndex">
        /// The pi index.
        /// </param>
        /// <returns>
        /// The get line and column.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int GetLineAndColumn(int iPos, out int piLine, out int piIndex)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The get line height.
        /// </summary>
        /// <param name="piLineHeight">
        /// The pi line height.
        /// </param>
        /// <returns>
        /// The get line height.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int GetLineHeight(out int piLineHeight)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The get nearest position.
        /// </summary>
        /// <param name="iLine">
        /// The i line.
        /// </param>
        /// <param name="iCol">
        /// The i col.
        /// </param>
        /// <param name="piPos">
        /// The pi pos.
        /// </param>
        /// <param name="piVirtualSpaces">
        /// The pi virtual spaces.
        /// </param>
        /// <returns>
        /// The get nearest position.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int GetNearestPosition(int iLine, int iCol, out int piPos, out int piVirtualSpaces)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The get point of line column.
        /// </summary>
        /// <param name="iLine">
        /// The i line.
        /// </param>
        /// <param name="iCol">
        /// The i col.
        /// </param>
        /// <param name="ppt">
        /// The ppt.
        /// </param>
        /// <returns>
        /// The get point of line column.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int GetPointOfLineColumn(int iLine, int iCol, POINT[] ppt)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The get scroll info.
        /// </summary>
        /// <param name="iBar">
        /// The i bar.
        /// </param>
        /// <param name="piMinUnit">
        /// The pi min unit.
        /// </param>
        /// <param name="piMaxUnit">
        /// The pi max unit.
        /// </param>
        /// <param name="piVisibleUnits">
        /// The pi visible units.
        /// </param>
        /// <param name="piFirstVisibleUnit">
        /// The pi first visible unit.
        /// </param>
        /// <returns>
        /// The get scroll info.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int GetScrollInfo(int iBar, out int piMinUnit, out int piMaxUnit, out int piVisibleUnits, out int piFirstVisibleUnit)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The get selected text.
        /// </summary>
        /// <param name="pbstrText">
        /// The pbstr text.
        /// </param>
        /// <returns>
        /// The get selected text.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int GetSelectedText(out string pbstrText)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The get selection.
        /// </summary>
        /// <param name="piAnchorLine">
        /// The pi anchor line.
        /// </param>
        /// <param name="piAnchorCol">
        /// The pi anchor col.
        /// </param>
        /// <param name="piEndLine">
        /// The pi end line.
        /// </param>
        /// <param name="piEndCol">
        /// The pi end col.
        /// </param>
        /// <returns>
        /// The get selection.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int GetSelection(out int piAnchorLine, out int piAnchorCol, out int piEndLine, out int piEndCol)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The get selection data object.
        /// </summary>
        /// <param name="ppIDataObject">
        /// The pp i data object.
        /// </param>
        /// <returns>
        /// The get selection data object.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int GetSelectionDataObject(out IDataObject ppIDataObject)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The get selection mode.
        /// </summary>
        /// <returns>
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public TextSelMode GetSelectionMode()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The get selection span.
        /// </summary>
        /// <param name="pSpan">
        /// The p span.
        /// </param>
        /// <returns>
        /// The get selection span.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int GetSelectionSpan(TextSpan[] pSpan)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The get text stream.
        /// </summary>
        /// <param name="iTopLine">
        /// The i top line.
        /// </param>
        /// <param name="iTopCol">
        /// The i top col.
        /// </param>
        /// <param name="iBottomLine">
        /// The i bottom line.
        /// </param>
        /// <param name="iBottomCol">
        /// The i bottom col.
        /// </param>
        /// <param name="pbstrText">
        /// The pbstr text.
        /// </param>
        /// <returns>
        /// The get text stream.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int GetTextStream(int iTopLine, int iTopCol, int iBottomLine, int iBottomCol, out string pbstrText)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The get window handle.
        /// </summary>
        /// <returns>
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public IntPtr GetWindowHandle()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The get word extent.
        /// </summary>
        /// <param name="iLine">
        /// The i line.
        /// </param>
        /// <param name="iCol">
        /// The i col.
        /// </param>
        /// <param name="dwFlags">
        /// The dw flags.
        /// </param>
        /// <param name="pSpan">
        /// The p span.
        /// </param>
        /// <returns>
        /// The get word extent.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int GetWordExtent(int iLine, int iCol, uint dwFlags, TextSpan[] pSpan)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The highlight matching brace.
        /// </summary>
        /// <param name="dwFlags">
        /// The dw flags.
        /// </param>
        /// <param name="cSpans">
        /// The c spans.
        /// </param>
        /// <param name="rgBaseSpans">
        /// The rg base spans.
        /// </param>
        /// <returns>
        /// The highlight matching brace.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int HighlightMatchingBrace(uint dwFlags, uint cSpans, TextSpan[] rgBaseSpans)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The initialize.
        /// </summary>
        /// <param name="pBuffer">
        /// The p buffer.
        /// </param>
        /// <param name="hwndParent">
        /// The hwnd parent.
        /// </param>
        /// <param name="InitFlags">
        /// The init flags.
        /// </param>
        /// <param name="pInitView">
        /// The p init view.
        /// </param>
        /// <returns>
        /// The initialize.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int Initialize(IVsTextLines pBuffer, IntPtr hwndParent, uint InitFlags, INITVIEW[] pInitView)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The position caret for editing.
        /// </summary>
        /// <param name="iLine">
        /// The i line.
        /// </param>
        /// <param name="cIndentLevels">
        /// The c indent levels.
        /// </param>
        /// <returns>
        /// The position caret for editing.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int PositionCaretForEditing(int iLine, int cIndentLevels)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The remove command filter.
        /// </summary>
        /// <param name="pCmdTarg">
        /// The p cmd targ.
        /// </param>
        /// <returns>
        /// The remove command filter.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int RemoveCommandFilter(IOleCommandTarget pCmdTarg)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The replace text on line.
        /// </summary>
        /// <param name="iLine">
        /// The i line.
        /// </param>
        /// <param name="iStartCol">
        /// The i start col.
        /// </param>
        /// <param name="iCharsToReplace">
        /// The i chars to replace.
        /// </param>
        /// <param name="pszNewText">
        /// The psz new text.
        /// </param>
        /// <param name="iNewLen">
        /// The i new len.
        /// </param>
        /// <returns>
        /// The replace text on line.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int ReplaceTextOnLine(int iLine, int iStartCol, int iCharsToReplace, string pszNewText, int iNewLen)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The restrict view range.
        /// </summary>
        /// <param name="iMinLine">
        /// The i min line.
        /// </param>
        /// <param name="iMaxLine">
        /// The i max line.
        /// </param>
        /// <param name="pClient">
        /// The p client.
        /// </param>
        /// <returns>
        /// The restrict view range.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int RestrictViewRange(int iMinLine, int iMaxLine, IVsViewRangeClient pClient)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The send explicit focus.
        /// </summary>
        /// <returns>
        /// The send explicit focus.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int SendExplicitFocus()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The set buffer.
        /// </summary>
        /// <param name="pBuffer">
        /// The p buffer.
        /// </param>
        /// <returns>
        /// The set buffer.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int SetBuffer(IVsTextLines pBuffer)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The set caret pos.
        /// </summary>
        /// <param name="iLine">
        /// The i line.
        /// </param>
        /// <param name="iColumn">
        /// The i column.
        /// </param>
        /// <returns>
        /// The set caret pos.
        /// </returns>
        public int SetCaretPos(int iLine, int iColumn)
        {
            if (this.OnSetCaretPos != null)
            {
                this.OnSetCaretPos(this, new SetCaretPosEventArgs(iLine, iColumn));
            }

            return VSConstants.S_OK;
        }

        /// <summary>
        /// The set scroll position.
        /// </summary>
        /// <param name="iBar">
        /// The i bar.
        /// </param>
        /// <param name="iFirstVisibleUnit">
        /// The i first visible unit.
        /// </param>
        /// <returns>
        /// The set scroll position.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int SetScrollPosition(int iBar, int iFirstVisibleUnit)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The set selection.
        /// </summary>
        /// <param name="iAnchorLine">
        /// The i anchor line.
        /// </param>
        /// <param name="iAnchorCol">
        /// The i anchor col.
        /// </param>
        /// <param name="iEndLine">
        /// The i end line.
        /// </param>
        /// <param name="iEndCol">
        /// The i end col.
        /// </param>
        /// <returns>
        /// The set selection.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int SetSelection(int iAnchorLine, int iAnchorCol, int iEndLine, int iEndCol)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The set selection mode.
        /// </summary>
        /// <param name="iSelMode">
        /// The i sel mode.
        /// </param>
        /// <returns>
        /// The set selection mode.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int SetSelectionMode(TextSelMode iSelMode)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The set top line.
        /// </summary>
        /// <param name="iBaseLine">
        /// The i base line.
        /// </param>
        /// <returns>
        /// The set top line.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int SetTopLine(int iBaseLine)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The update completion status.
        /// </summary>
        /// <param name="pCompSet">
        /// The p comp set.
        /// </param>
        /// <param name="dwFlags">
        /// The dw flags.
        /// </param>
        /// <returns>
        /// The update completion status.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int UpdateCompletionStatus(IVsCompletionSet pCompSet, uint dwFlags)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The update tip window.
        /// </summary>
        /// <param name="pTipWindow">
        /// The p tip window.
        /// </param>
        /// <param name="dwFlags">
        /// The dw flags.
        /// </param>
        /// <returns>
        /// The update tip window.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int UpdateTipWindow(IVsTipWindow pTipWindow, uint dwFlags)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The update view frame caption.
        /// </summary>
        /// <returns>
        /// The update view frame caption.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int UpdateViewFrameCaption()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        #endregion

        /// <summary>
        /// The set caret pos event args.
        /// </summary>
        public class SetCaretPosEventArgs : EventArgs
        {
            #region Constants and Fields

            public readonly int Column;

            public readonly int Line;

            #endregion

            #region Constructors and Destructors

            /// <summary>
            /// Initializes a new instance of the <see cref="SetCaretPosEventArgs"/> class.
            /// </summary>
            /// <param name="line">
            /// The line.
            /// </param>
            /// <param name="column">
            /// The column.
            /// </param>
            public SetCaretPosEventArgs(int line, int column)
            {
                this.Line = line;
                this.Column = column;
            }

            #endregion
        }
    }
}