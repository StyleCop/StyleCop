//-----------------------------------------------------------------------
// <copyright file="MockTextView.cs">
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
    using System.Text;
    using Microsoft.VisualStudio.TextManager.Interop;
    using Microsoft.VisualStudio;

    class MockTextView : IVsTextView
    {
        public class SetCaretPosEventArgs : EventArgs
        {
            public readonly int Line;
            public readonly int Column;
            public SetCaretPosEventArgs(int line, int column)
            {
                Line = line;
                Column = column;
            }
        }

        public event EventHandler<SetCaretPosEventArgs> OnSetCaretPos;

        #region IVsTextView Members

        public int AddCommandFilter(Microsoft.VisualStudio.OLE.Interop.IOleCommandTarget pNewCmdTarg, out Microsoft.VisualStudio.OLE.Interop.IOleCommandTarget ppNextCmdTarg)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int CenterColumns(int iLine, int iLeftCol, int iColCount)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int CenterLines(int iTopLine, int iCount)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int ClearSelection(int fMoveToAnchor)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int CloseView()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int EnsureSpanVisible(TextSpan span)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int GetBuffer(out IVsTextLines ppBuffer)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int GetCaretPos(out int piLine, out int piColumn)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int GetLineAndColumn(int iPos, out int piLine, out int piIndex)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int GetLineHeight(out int piLineHeight)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int GetNearestPosition(int iLine, int iCol, out int piPos, out int piVirtualSpaces)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int GetPointOfLineColumn(int iLine, int iCol, Microsoft.VisualStudio.OLE.Interop.POINT[] ppt)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int GetScrollInfo(int iBar, out int piMinUnit, out int piMaxUnit, out int piVisibleUnits, out int piFirstVisibleUnit)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int GetSelectedText(out string pbstrText)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int GetSelection(out int piAnchorLine, out int piAnchorCol, out int piEndLine, out int piEndCol)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int GetSelectionDataObject(out Microsoft.VisualStudio.OLE.Interop.IDataObject ppIDataObject)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public TextSelMode GetSelectionMode()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int GetSelectionSpan(TextSpan[] pSpan)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int GetTextStream(int iTopLine, int iTopCol, int iBottomLine, int iBottomCol, out string pbstrText)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public IntPtr GetWindowHandle()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int GetWordExtent(int iLine, int iCol, uint dwFlags, TextSpan[] pSpan)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int HighlightMatchingBrace(uint dwFlags, uint cSpans, TextSpan[] rgBaseSpans)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int Initialize(IVsTextLines pBuffer, IntPtr hwndParent, uint InitFlags, INITVIEW[] pInitView)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int PositionCaretForEditing(int iLine, int cIndentLevels)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int RemoveCommandFilter(Microsoft.VisualStudio.OLE.Interop.IOleCommandTarget pCmdTarg)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int ReplaceTextOnLine(int iLine, int iStartCol, int iCharsToReplace, string pszNewText, int iNewLen)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int RestrictViewRange(int iMinLine, int iMaxLine, IVsViewRangeClient pClient)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int SendExplicitFocus()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int SetBuffer(IVsTextLines pBuffer)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int SetCaretPos(int iLine, int iColumn)
        {
            if (OnSetCaretPos != null)
            {
                OnSetCaretPos(this, new SetCaretPosEventArgs(iLine, iColumn));
            }
            return VSConstants.S_OK;
        }

        public int SetScrollPosition(int iBar, int iFirstVisibleUnit)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int SetSelection(int iAnchorLine, int iAnchorCol, int iEndLine, int iEndCol)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int SetSelectionMode(TextSelMode iSelMode)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int SetTopLine(int iBaseLine)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int UpdateCompletionStatus(IVsCompletionSet pCompSet, uint dwFlags)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int UpdateTipWindow(IVsTipWindow pTipWindow, uint dwFlags)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int UpdateViewFrameCaption()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
