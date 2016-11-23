// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MockTextLines.cs" company="https://github.com/StyleCop">
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
//   The mock text lines.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace VSPackageUnitTest.Mocks
{
    using System;

    using Microsoft.VisualStudio.OLE.Interop;
    using Microsoft.VisualStudio.TextManager.Interop;

    /// <summary>
    /// The mock text lines.
    /// </summary>
    internal class MockTextLines : IVsTextLines
    {
        #region Constants and Fields

        public readonly string FileName = null;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MockTextLines"/> class.
        /// </summary>
        /// <param name="fileName">
        /// The file name.
        /// </param>
        public MockTextLines(string fileName)
        {
            this.FileName = fileName;
        }

        #endregion

        #region Implemented Interfaces

        #region IVsTextLines

        /// <summary>
        /// The advise text lines events.
        /// </summary>
        /// <param name="pSink">
        /// The p sink.
        /// </param>
        /// <param name="pdwCookie">
        /// The pdw cookie.
        /// </param>
        /// <returns>
        /// The advise text lines events.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int AdviseTextLinesEvents(IVsTextLinesEvents pSink, out uint pdwCookie)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The can replace lines.
        /// </summary>
        /// <param name="iStartLine">
        /// The i start line.
        /// </param>
        /// <param name="iStartIndex">
        /// The i start index.
        /// </param>
        /// <param name="iEndLine">
        /// The i end line.
        /// </param>
        /// <param name="iEndIndex">
        /// The i end index.
        /// </param>
        /// <param name="iNewLen">
        /// The i new len.
        /// </param>
        /// <returns>
        /// The can replace lines.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int CanReplaceLines(int iStartLine, int iStartIndex, int iEndLine, int iEndIndex, int iNewLen)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The copy line text.
        /// </summary>
        /// <param name="iStartLine">
        /// The i start line.
        /// </param>
        /// <param name="iStartIndex">
        /// The i start index.
        /// </param>
        /// <param name="iEndLine">
        /// The i end line.
        /// </param>
        /// <param name="iEndIndex">
        /// The i end index.
        /// </param>
        /// <param name="pszBuf">
        /// The psz buf.
        /// </param>
        /// <param name="pcchBuf">
        /// The pcch buf.
        /// </param>
        /// <returns>
        /// The copy line text.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int CopyLineText(int iStartLine, int iStartIndex, int iEndLine, int iEndIndex, IntPtr pszBuf, ref int pcchBuf)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The create edit point.
        /// </summary>
        /// <param name="iLine">
        /// The i line.
        /// </param>
        /// <param name="iIndex">
        /// The i index.
        /// </param>
        /// <param name="ppEditPoint">
        /// The pp edit point.
        /// </param>
        /// <returns>
        /// The create edit point.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int CreateEditPoint(int iLine, int iIndex, out object ppEditPoint)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The create line marker.
        /// </summary>
        /// <param name="iMarkerType">
        /// The i marker type.
        /// </param>
        /// <param name="iStartLine">
        /// The i start line.
        /// </param>
        /// <param name="iStartIndex">
        /// The i start index.
        /// </param>
        /// <param name="iEndLine">
        /// The i end line.
        /// </param>
        /// <param name="iEndIndex">
        /// The i end index.
        /// </param>
        /// <param name="pClient">
        /// The p client.
        /// </param>
        /// <param name="ppMarker">
        /// The pp marker.
        /// </param>
        /// <returns>
        /// The create line marker.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int CreateLineMarker(int iMarkerType, int iStartLine, int iStartIndex, int iEndLine, int iEndIndex, IVsTextMarkerClient pClient, IVsTextLineMarker[] ppMarker)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The create text point.
        /// </summary>
        /// <param name="iLine">
        /// The i line.
        /// </param>
        /// <param name="iIndex">
        /// The i index.
        /// </param>
        /// <param name="ppTextPoint">
        /// The pp text point.
        /// </param>
        /// <returns>
        /// The create text point.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int CreateTextPoint(int iLine, int iIndex, out object ppTextPoint)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The enum markers.
        /// </summary>
        /// <param name="iStartLine">
        /// The i start line.
        /// </param>
        /// <param name="iStartIndex">
        /// The i start index.
        /// </param>
        /// <param name="iEndLine">
        /// The i end line.
        /// </param>
        /// <param name="iEndIndex">
        /// The i end index.
        /// </param>
        /// <param name="iMarkerType">
        /// The i marker type.
        /// </param>
        /// <param name="dwFlags">
        /// The dw flags.
        /// </param>
        /// <param name="ppEnum">
        /// The pp enum.
        /// </param>
        /// <returns>
        /// The enum markers.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int EnumMarkers(int iStartLine, int iStartIndex, int iEndLine, int iEndIndex, int iMarkerType, uint dwFlags, out IVsEnumLineMarkers ppEnum)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The find marker by line index.
        /// </summary>
        /// <param name="iMarkerType">
        /// The i marker type.
        /// </param>
        /// <param name="iStartingLine">
        /// The i starting line.
        /// </param>
        /// <param name="iStartingIndex">
        /// The i starting index.
        /// </param>
        /// <param name="dwFlags">
        /// The dw flags.
        /// </param>
        /// <param name="ppMarker">
        /// The pp marker.
        /// </param>
        /// <returns>
        /// The find marker by line index.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int FindMarkerByLineIndex(int iMarkerType, int iStartingLine, int iStartingIndex, uint dwFlags, out IVsTextLineMarker ppMarker)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The get language service id.
        /// </summary>
        /// <param name="pguidLangService">
        /// The pguid lang service.
        /// </param>
        /// <returns>
        /// The get language service id.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int GetLanguageServiceID(out Guid pguidLangService)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The get last line index.
        /// </summary>
        /// <param name="piLine">
        /// The pi line.
        /// </param>
        /// <param name="piIndex">
        /// The pi index.
        /// </param>
        /// <returns>
        /// The get last line index.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int GetLastLineIndex(out int piLine, out int piIndex)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The get length of line.
        /// </summary>
        /// <param name="iLine">
        /// The i line.
        /// </param>
        /// <param name="piLength">
        /// The pi length.
        /// </param>
        /// <returns>
        /// The get length of line.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int GetLengthOfLine(int iLine, out int piLength)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The get line count.
        /// </summary>
        /// <param name="piLineCount">
        /// The pi line count.
        /// </param>
        /// <returns>
        /// The get line count.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int GetLineCount(out int piLineCount)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The get line data.
        /// </summary>
        /// <param name="iLine">
        /// The i line.
        /// </param>
        /// <param name="pLineData">
        /// The p line data.
        /// </param>
        /// <param name="pMarkerData">
        /// The p marker data.
        /// </param>
        /// <returns>
        /// The get line data.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int GetLineData(int iLine, LINEDATA[] pLineData, MARKERDATA[] pMarkerData)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The get line data ex.
        /// </summary>
        /// <param name="dwFlags">
        /// The dw flags.
        /// </param>
        /// <param name="iLine">
        /// The i line.
        /// </param>
        /// <param name="iStartIndex">
        /// The i start index.
        /// </param>
        /// <param name="iEndIndex">
        /// The i end index.
        /// </param>
        /// <param name="pLineData">
        /// The p line data.
        /// </param>
        /// <param name="pMarkerData">
        /// The p marker data.
        /// </param>
        /// <returns>
        /// The get line data ex.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int GetLineDataEx(uint dwFlags, int iLine, int iStartIndex, int iEndIndex, LINEDATAEX[] pLineData, MARKERDATA[] pMarkerData)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The get line index of position.
        /// </summary>
        /// <param name="iPosition">
        /// The i position.
        /// </param>
        /// <param name="piLine">
        /// The pi line.
        /// </param>
        /// <param name="piColumn">
        /// The pi column.
        /// </param>
        /// <returns>
        /// The get line index of position.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int GetLineIndexOfPosition(int iPosition, out int piLine, out int piColumn)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The get line text.
        /// </summary>
        /// <param name="iStartLine">
        /// The i start line.
        /// </param>
        /// <param name="iStartIndex">
        /// The i start index.
        /// </param>
        /// <param name="iEndLine">
        /// The i end line.
        /// </param>
        /// <param name="iEndIndex">
        /// The i end index.
        /// </param>
        /// <param name="pbstrBuf">
        /// The pbstr buf.
        /// </param>
        /// <returns>
        /// The get line text.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int GetLineText(int iStartLine, int iStartIndex, int iEndLine, int iEndIndex, out string pbstrBuf)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The get marker data.
        /// </summary>
        /// <param name="iTopLine">
        /// The i top line.
        /// </param>
        /// <param name="iBottomLine">
        /// The i bottom line.
        /// </param>
        /// <param name="pMarkerData">
        /// The p marker data.
        /// </param>
        /// <returns>
        /// The get marker data.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int GetMarkerData(int iTopLine, int iBottomLine, MARKERDATA[] pMarkerData)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The get pair extents.
        /// </summary>
        /// <param name="pSpanIn">
        /// The p span in.
        /// </param>
        /// <param name="pSpanOut">
        /// The p span out.
        /// </param>
        /// <returns>
        /// The get pair extents.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int GetPairExtents(TextSpan[] pSpanIn, TextSpan[] pSpanOut)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The get position of line.
        /// </summary>
        /// <param name="iLine">
        /// The i line.
        /// </param>
        /// <param name="piPosition">
        /// The pi position.
        /// </param>
        /// <returns>
        /// The get position of line.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int GetPositionOfLine(int iLine, out int piPosition)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The get position of line index.
        /// </summary>
        /// <param name="iLine">
        /// The i line.
        /// </param>
        /// <param name="iIndex">
        /// The i index.
        /// </param>
        /// <param name="piPosition">
        /// The pi position.
        /// </param>
        /// <returns>
        /// The get position of line index.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int GetPositionOfLineIndex(int iLine, int iIndex, out int piPosition)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The get size.
        /// </summary>
        /// <param name="piLength">
        /// The pi length.
        /// </param>
        /// <returns>
        /// The get size.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int GetSize(out int piLength)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The get state flags.
        /// </summary>
        /// <param name="pdwReadOnlyFlags">
        /// The pdw read only flags.
        /// </param>
        /// <returns>
        /// The get state flags.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int GetStateFlags(out uint pdwReadOnlyFlags)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The get undo manager.
        /// </summary>
        /// <param name="ppUndoManager">
        /// The pp undo manager.
        /// </param>
        /// <returns>
        /// The get undo manager.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int GetUndoManager(out IOleUndoManager ppUndoManager)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The i vs text lines reserved 1.
        /// </summary>
        /// <param name="iLine">
        /// The i line.
        /// </param>
        /// <param name="pLineData">
        /// The p line data.
        /// </param>
        /// <param name="fAttributes">
        /// The f attributes.
        /// </param>
        /// <returns>
        /// The i vs text lines reserved 1.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int IVsTextLinesReserved1(int iLine, LINEDATA[] pLineData, int fAttributes)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The initialize content.
        /// </summary>
        /// <param name="pszText">
        /// The psz text.
        /// </param>
        /// <param name="iLength">
        /// The i length.
        /// </param>
        /// <returns>
        /// The initialize content.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int InitializeContent(string pszText, int iLength)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The lock buffer.
        /// </summary>
        /// <returns>
        /// The lock buffer.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int LockBuffer()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The lock buffer ex.
        /// </summary>
        /// <param name="dwFlags">
        /// The dw flags.
        /// </param>
        /// <returns>
        /// The lock buffer ex.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int LockBufferEx(uint dwFlags)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The release line data.
        /// </summary>
        /// <param name="pLineData">
        /// The p line data.
        /// </param>
        /// <returns>
        /// The release line data.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int ReleaseLineData(LINEDATA[] pLineData)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The release line data ex.
        /// </summary>
        /// <param name="pLineData">
        /// The p line data.
        /// </param>
        /// <returns>
        /// The release line data ex.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int ReleaseLineDataEx(LINEDATAEX[] pLineData)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The release marker data.
        /// </summary>
        /// <param name="pMarkerData">
        /// The p marker data.
        /// </param>
        /// <returns>
        /// The release marker data.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int ReleaseMarkerData(MARKERDATA[] pMarkerData)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The reload.
        /// </summary>
        /// <param name="fUndoable">
        /// The f undoable.
        /// </param>
        /// <returns>
        /// The reload.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int Reload(int fUndoable)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The reload lines.
        /// </summary>
        /// <param name="iStartLine">
        /// The i start line.
        /// </param>
        /// <param name="iStartIndex">
        /// The i start index.
        /// </param>
        /// <param name="iEndLine">
        /// The i end line.
        /// </param>
        /// <param name="iEndIndex">
        /// The i end index.
        /// </param>
        /// <param name="pszText">
        /// The psz text.
        /// </param>
        /// <param name="iNewLen">
        /// The i new len.
        /// </param>
        /// <param name="pChangedSpan">
        /// The p changed span.
        /// </param>
        /// <returns>
        /// The reload lines.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int ReloadLines(int iStartLine, int iStartIndex, int iEndLine, int iEndIndex, IntPtr pszText, int iNewLen, TextSpan[] pChangedSpan)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The replace lines.
        /// </summary>
        /// <param name="iStartLine">
        /// The i start line.
        /// </param>
        /// <param name="iStartIndex">
        /// The i start index.
        /// </param>
        /// <param name="iEndLine">
        /// The i end line.
        /// </param>
        /// <param name="iEndIndex">
        /// The i end index.
        /// </param>
        /// <param name="pszText">
        /// The psz text.
        /// </param>
        /// <param name="iNewLen">
        /// The i new len.
        /// </param>
        /// <param name="pChangedSpan">
        /// The p changed span.
        /// </param>
        /// <returns>
        /// The replace lines.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int ReplaceLines(int iStartLine, int iStartIndex, int iEndLine, int iEndIndex, IntPtr pszText, int iNewLen, TextSpan[] pChangedSpan)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The replace lines ex.
        /// </summary>
        /// <param name="dwFlags">
        /// The dw flags.
        /// </param>
        /// <param name="iStartLine">
        /// The i start line.
        /// </param>
        /// <param name="iStartIndex">
        /// The i start index.
        /// </param>
        /// <param name="iEndLine">
        /// The i end line.
        /// </param>
        /// <param name="iEndIndex">
        /// The i end index.
        /// </param>
        /// <param name="pszText">
        /// The psz text.
        /// </param>
        /// <param name="iNewLen">
        /// The i new len.
        /// </param>
        /// <param name="pChangedSpan">
        /// The p changed span.
        /// </param>
        /// <returns>
        /// The replace lines ex.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int ReplaceLinesEx(uint dwFlags, int iStartLine, int iStartIndex, int iEndLine, int iEndIndex, IntPtr pszText, int iNewLen, TextSpan[] pChangedSpan)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The reserved 1.
        /// </summary>
        /// <returns>
        /// The reserved 1.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int Reserved1()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The reserved 10.
        /// </summary>
        /// <returns>
        /// The reserved 10.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int Reserved10()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The reserved 2.
        /// </summary>
        /// <returns>
        /// The reserved 2.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int Reserved2()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The reserved 3.
        /// </summary>
        /// <returns>
        /// The reserved 3.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int Reserved3()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The reserved 4.
        /// </summary>
        /// <returns>
        /// The reserved 4.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int Reserved4()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The reserved 5.
        /// </summary>
        /// <returns>
        /// The reserved 5.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int Reserved5()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The reserved 6.
        /// </summary>
        /// <returns>
        /// The reserved 6.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int Reserved6()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The reserved 7.
        /// </summary>
        /// <returns>
        /// The reserved 7.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int Reserved7()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The reserved 8.
        /// </summary>
        /// <returns>
        /// The reserved 8.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int Reserved8()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The reserved 9.
        /// </summary>
        /// <returns>
        /// The reserved 9.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int Reserved9()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The set language service id.
        /// </summary>
        /// <param name="guidLangService">
        /// The guid lang service.
        /// </param>
        /// <returns>
        /// The set language service id.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int SetLanguageServiceID(ref Guid guidLangService)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The set state flags.
        /// </summary>
        /// <param name="dwReadOnlyFlags">
        /// The dw read only flags.
        /// </param>
        /// <returns>
        /// The set state flags.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int SetStateFlags(uint dwReadOnlyFlags)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The unadvise text lines events.
        /// </summary>
        /// <param name="dwCookie">
        /// The dw cookie.
        /// </param>
        /// <returns>
        /// The unadvise text lines events.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int UnadviseTextLinesEvents(uint dwCookie)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The unlock buffer.
        /// </summary>
        /// <returns>
        /// The unlock buffer.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int UnlockBuffer()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The unlock buffer ex.
        /// </summary>
        /// <param name="dwFlags">
        /// The dw flags.
        /// </param>
        /// <returns>
        /// The unlock buffer ex.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int UnlockBufferEx(uint dwFlags)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        #endregion
    }
}