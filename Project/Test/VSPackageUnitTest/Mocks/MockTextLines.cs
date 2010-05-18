//-----------------------------------------------------------------------
// <copyright file="MockTextLines.cs" company="Microsoft">
//   Copyright (c) Microsoft Corporation.
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


    class MockTextLines : IVsTextLines
    {
        public readonly string FileName = null;

        public MockTextLines(string fileName)
        {
            FileName = fileName;
        }

        #region IVsTextLines Members

        public int AdviseTextLinesEvents(IVsTextLinesEvents pSink, out uint pdwCookie)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int CanReplaceLines(int iStartLine, int iStartIndex, int iEndLine, int iEndIndex, int iNewLen)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int CopyLineText(int iStartLine, int iStartIndex, int iEndLine, int iEndIndex, IntPtr pszBuf, ref int pcchBuf)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int CreateEditPoint(int iLine, int iIndex, out object ppEditPoint)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int CreateLineMarker(int iMarkerType, int iStartLine, int iStartIndex, int iEndLine, int iEndIndex, IVsTextMarkerClient pClient, IVsTextLineMarker[] ppMarker)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int CreateTextPoint(int iLine, int iIndex, out object ppTextPoint)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int EnumMarkers(int iStartLine, int iStartIndex, int iEndLine, int iEndIndex, int iMarkerType, uint dwFlags, out IVsEnumLineMarkers ppEnum)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int FindMarkerByLineIndex(int iMarkerType, int iStartingLine, int iStartingIndex, uint dwFlags, out IVsTextLineMarker ppMarker)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int GetLanguageServiceID(out Guid pguidLangService)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int GetLastLineIndex(out int piLine, out int piIndex)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int GetLengthOfLine(int iLine, out int piLength)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int GetLineCount(out int piLineCount)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int GetLineData(int iLine, LINEDATA[] pLineData, MARKERDATA[] pMarkerData)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int GetLineDataEx(uint dwFlags, int iLine, int iStartIndex, int iEndIndex, LINEDATAEX[] pLineData, MARKERDATA[] pMarkerData)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int GetLineIndexOfPosition(int iPosition, out int piLine, out int piColumn)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int GetLineText(int iStartLine, int iStartIndex, int iEndLine, int iEndIndex, out string pbstrBuf)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int GetMarkerData(int iTopLine, int iBottomLine, MARKERDATA[] pMarkerData)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int GetPairExtents(TextSpan[] pSpanIn, TextSpan[] pSpanOut)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int GetPositionOfLine(int iLine, out int piPosition)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int GetPositionOfLineIndex(int iLine, int iIndex, out int piPosition)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int GetSize(out int piLength)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int GetStateFlags(out uint pdwReadOnlyFlags)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int GetUndoManager(out Microsoft.VisualStudio.OLE.Interop.IOleUndoManager ppUndoManager)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int IVsTextLinesReserved1(int iLine, LINEDATA[] pLineData, int fAttributes)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int InitializeContent(string pszText, int iLength)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int LockBuffer()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int LockBufferEx(uint dwFlags)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int ReleaseLineData(LINEDATA[] pLineData)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int ReleaseLineDataEx(LINEDATAEX[] pLineData)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int ReleaseMarkerData(MARKERDATA[] pMarkerData)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int Reload(int fUndoable)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int ReloadLines(int iStartLine, int iStartIndex, int iEndLine, int iEndIndex, IntPtr pszText, int iNewLen, TextSpan[] pChangedSpan)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int ReplaceLines(int iStartLine, int iStartIndex, int iEndLine, int iEndIndex, IntPtr pszText, int iNewLen, TextSpan[] pChangedSpan)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int ReplaceLinesEx(uint dwFlags, int iStartLine, int iStartIndex, int iEndLine, int iEndIndex, IntPtr pszText, int iNewLen, TextSpan[] pChangedSpan)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int Reserved1()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int Reserved10()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int Reserved2()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int Reserved3()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int Reserved4()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int Reserved5()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int Reserved6()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int Reserved7()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int Reserved8()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int Reserved9()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int SetLanguageServiceID(ref Guid guidLangService)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int SetStateFlags(uint dwReadOnlyFlags)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int UnadviseTextLinesEvents(uint dwCookie)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int UnlockBuffer()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int UnlockBufferEx(uint dwFlags)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
