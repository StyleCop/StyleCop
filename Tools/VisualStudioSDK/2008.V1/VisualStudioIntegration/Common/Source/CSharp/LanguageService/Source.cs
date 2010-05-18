//#define LANGTRACE
using Microsoft.VisualStudio.TextManager.Interop;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.OLE.Interop;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio;
using IOleServiceProvider = Microsoft.VisualStudio.OLE.Interop.IServiceProvider;
using IServiceProvider = System.IServiceProvider;
using System.IO;
using System.Globalization;
using VsCommands = Microsoft.VisualStudio.VSConstants.VSStd97CmdID;
using VsCommands2K = Microsoft.VisualStudio.VSConstants.VSStd2KCmdID;

namespace Microsoft.VisualStudio.Package {
    /// <include file='doc\Source.uex' path='docs/doc[@for="Severity"]/*' />
    public enum Severity {
        /// <include file='doc\Source.uex' path='docs/doc[@for="Severity.Hint"]/*' />
        Hint,
        /// <include file='doc\Source.uex' path='docs/doc[@for="Severity.Warning"]/*' />
        Warning,
        /// <include file='doc\Source.uex' path='docs/doc[@for="Severity.Error"]/*' />
        Error,
        /// <include file='doc\Source.uex' path='docs/doc[@for="Severity.Fatal"]/*' />
        Fatal
    };

    /// <include file='doc\Source.uex' path='docs/doc[@for="CommentInfo"]/*' />
    public struct CommentInfo {
        private string lineStart;
        private string blockStart;
        private string blockEnd;
        private bool useLineComments;


        /// <include file='doc\Source.uex' path='docs/doc[@for="CommentInfo.LineStart;"]/*' />
        public string LineStart {
            get {
                return this.lineStart;
            }
            set {
                this.lineStart = value;
            }
        }

        /// <include file='doc\Source.uex' path='docs/doc[@for="CommentInfo.BlockStart;"]/*' />
        public string BlockStart {
            get {
                return this.blockStart;
            }
            set {
                this.blockStart = value;
            }
        }
        /// <include file='doc\Source.uex' path='docs/doc[@for="CommentInfo.BlockEnd;"]/*' />
        public string BlockEnd {
            get {
                return this.blockEnd;
            }
            set {
                this.blockEnd = value;
            }
        }

        /// <include file='doc\Source.uex' path='docs/doc[@for="CommentInfo.UseLineComments;"]/*' />
        public bool UseLineComments {
            get {
                return this.useLineComments;
            }
            set {
                this.useLineComments = value;
            }
        }

    }

    //===================================================================================
    // Default Implementations
    //===================================================================================
    /// <include file='doc\Source.uex' path='docs/doc[@for="Source"]/*' />
    /// <summary>
    /// Source represents one source file and manages the parsing and intellisense on this file
    /// and keeping things like the drop down combos in sync with the source and so on.
    /// </summary>
    [CLSCompliant(false)]
    public class Source : IDisposable, IVsTextLinesEvents, IVsFinalTextChangeCommitEvents, IVsHiddenTextClient, IVsUserDataEvents {
        private LanguageService service;
        private IVsTextLines textLines;
        private Colorizer colorizer;
        internal TaskProvider taskProvider;
        private CompletionSet completionSet;
        private int dirtyTime;
        private bool dirty;
        private TextSpan dirtySpan;
        private MethodData methodData;
        private ExpansionProvider expansionProvider;
        private int requestSync;
        private NativeMethods.ConnectionPointCookie textChangeCommitEvents;
        private NativeMethods.ConnectionPointCookie textLinesEvents;
        private NativeMethods.ConnectionPointCookie userDataEvents;
        private IVsTextColorState colorState;
        private IVsHiddenTextSession hiddenTextSession;
        internal static int HiddenRegionCookie = 25;
        private bool doOutlining;
        private ArrayList hiddenRegions;
        private int openCount;
        private int lastParseTime;
        static internal WORDEXTFLAGS WholeToken = (WORDEXTFLAGS)0x1000;
        private IntPtr pUnkTextLines;

        /// <include file='doc\Source.uex' path='docs/doc[@for="Source.CompletedFirstParse"]/*' />
        public bool CompletedFirstParse {
			get { return this.lastParseTime!=Int32.MaxValue; }
        }

        /// <include file='doc\Source.uex' path='docs/doc[@for="Source.Source"]/*' />
        public Source(LanguageService service, IVsTextLines textLines, Colorizer colorizer) {
#if LANGTRACE
            Tracing.TraceRef(textLines, "Source.textLines");
#endif
            this.service = service;
            this.textLines = textLines;
            pUnkTextLines = Marshal.GetIUnknownForObject(this.textLines); //so it can't get disposed on us
            this.colorizer = colorizer;
            this.dirty = true;
            this.completionSet = this.CreateCompletionSet();
            this.methodData = this.CreateMethodData();
            this.colorState = (IVsTextColorState)textLines;
            // track source changes
            this.textChangeCommitEvents = new NativeMethods.ConnectionPointCookie(textLines, this, typeof(IVsFinalTextChangeCommitEvents));
            this.textLinesEvents = new NativeMethods.ConnectionPointCookie(textLines, this, typeof(IVsTextLinesEvents));
            this.userDataEvents = new NativeMethods.ConnectionPointCookie(textLines, this, typeof(IVsUserDataEvents));

            this.doOutlining = this.service.Preferences.AutoOutlining;
            if (this.doOutlining) {
                GetHiddenTextSession();
            }
            this.expansionProvider = GetExpansionProvider();

			this.lastParseTime = Int32.MaxValue;
        }

        /// <include file='doc\Source.uex' path='docs/doc[@for="Source.Finalize"]/*' />
        ~Source() {
#if LANGTRACE
            Trace.WriteLine("~Source");
#endif
        }

        /// <include file='doc\Source.uex' path='docs/doc[@for="Source.ColorState;"]/*' />
        public IVsTextColorState ColorState {
            get { return this.colorState; }
            set { this.colorState = value; }
        }

        /// <include file='doc\Source.uex' path='docs/doc[@for="Source.LanguageService"]/*' />
        public LanguageService LanguageService {
            get { return this.service; }
        }

        /// <include file='doc\Source.uex' path='docs/doc[@for="Source.CompletionSet"]/*' />
        public CompletionSet CompletionSet {
            get { return this.completionSet; }
        }

        /// <include file='doc\Source.uex' path='docs/doc[@for="Source.GetColorizer"]/*' />
        public Colorizer GetColorizer() {
            return this.colorizer;
        }

        /// <include file='doc\Source.uex' path='docs/doc[@for="Source.Recolorize"]/*' />
        public void Recolorize(int startLine, int endLine) {
            if (this.colorState != null && this.GetLineCount() > 0) {
                int lastLine = this.GetLineCount() - 1;
                startLine = Math.Min(startLine, lastLine);
                endLine = Math.Min(endLine, lastLine);
                this.colorState.ReColorizeLines(startLine, endLine);
            }
        }

        /// <include file='doc\Source.uex' path='docs/doc[@for="Source.CreateAuthoringSink"]/*' />
        public virtual AuthoringSink CreateAuthoringSink(ParseReason reason, int line, int col) {
            int maxErrors = this.service.Preferences.MaxErrorMessages;
            return new AuthoringSink(reason, line, col, maxErrors);
        }

        /// <include file='doc\Source.uex' path='docs/doc[@for="Source.CreateCompletionSet"]/*' />
        public virtual CompletionSet CreateCompletionSet() {
            return new CompletionSet(this.service.GetImageList(), this);
        }

        /// <include file='doc\Source.uex' path='docs/doc[@for="Source.GetMethodData"]/*' />
        public virtual MethodData CreateMethodData() {
            return new MethodData(this.service.Site);
        }

        /// <include file='doc\Source.uex' path='docs/doc[@for="Source.GetTaskProvider"]/*' />
        public virtual TaskProvider GetTaskProvider() {
            if (this.taskProvider == null) {
                this.taskProvider = new ErrorListProvider(service.Site); // task list
                // <temporary hack>
                // Due to the fact that the ErrorList is not yet working...the 
                // following at least results in all tasks from the same language 
                // service into one list.
                this.taskProvider.ProviderGuid = service.GetLanguageServiceGuid();
                this.taskProvider.ProviderName = service.Name;
                // </temporary hack>
            }
            return this.taskProvider;
        }

        /// <include file='doc\Source.uex' path='docs/doc[@for="Source.GetExpansionProvider"]/*' />
        public virtual ExpansionProvider GetExpansionProvider() {
            if (this.expansionProvider == null && this.service != null) {
                this.expansionProvider = this.service.CreateExpansionProvider(this);
            }
            return this.expansionProvider;
        }
        /// <include file='doc\Source.uex' path='docs/doc[@for="Source.IsCompletorActive"]/*' />
        /// <devdiv>returns true if either CompletionSet or MethodData is being displayed.</devdiv>
        public bool IsCompletorActive {
            get {
                return (this.completionSet != null && this.completionSet.IsDisplayed) ||
                    (this.methodData != null && this.methodData.IsDisplayed);
            }
        }

        /// <include file='doc\Source.uex' path='docs/doc[@for="Source.DismissCompletor"]/*' />
        public void DismissCompletor() {
            if (this.completionSet != null && this.completionSet.IsDisplayed) {
                this.completionSet.Close();
            }
            if (this.methodData != null && this.methodData.IsDisplayed) {
                this.methodData.Close();
            }
        }

        /// <include file='doc\Source.uex' path='docs/doc[@for="Source.Open"]/*' />
        public void Open() {
            this.openCount++;
        }

        /// <include file='doc\Source.uex' path='docs/doc[@for="Source.Close"]/*' />
        public bool Close() {
#if LANGTRACE
            Trace.WriteLine("Source::Close");
#endif
            if (--this.openCount == 0) {
                return true;
            }
            return false;
        }

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="Source.Dispose"]/*' />
        public virtual void Dispose() {
#if LANGTRACE
            Trace.WriteLine("Source::Cleanup");
#endif
            try {
                if (this.textLinesEvents != null) {
                    this.textLinesEvents.Dispose();
                    this.textLinesEvents = null;
                }
            } catch (COMException) {
            }
            try {
                if (this.textChangeCommitEvents != null) {
                    this.textChangeCommitEvents.Dispose();
                    this.textChangeCommitEvents = null;
                }
            } catch (COMException) {
            }
            try {
                if (this.userDataEvents != null) {
                    this.userDataEvents.Dispose();
                    this.userDataEvents = null;
                }
            } catch (COMException) {
            }
            try {
                if (this.hiddenTextSession != null) {
                    // We can't throw or exit here because we need to call Dispose on the
                    // other members that need to be disposed.
                    this.hiddenTextSession.UnadviseClient();
                    // This is causing a debug assert in vs\env\msenv\textmgr\vrlist.cpp
                    // at line 1997 in CVisibleRegionList::Terminate
                    //this.hiddenTextSession.Terminate();
                    Marshal.ReleaseComObject(hiddenTextSession);
                    this.hiddenTextSession = null;
                }
            } catch (COMException) {
            }
            try {
                if (this.methodData != null) {
                    this.methodData.Dispose();
                    this.methodData = null;
                }
            } catch (COMException) {
            }
            try {
                if (this.completionSet != null) {
                    this.completionSet.Dispose();
                    this.completionSet = null;
                }
            } catch (COMException) {
            }
            try {

                if (this.taskProvider != null) {
                    this.taskProvider.Dispose();
                    this.taskProvider = null;
                }
            } catch (COMException) {
            }
            try {
                this.service = null;
                if (this.colorizer != null) {
                    // The colorizer is owned by the core text editor, so we don't close it, the core text editor
                    // does that for us when it is ready to do so.
                    //colorizer.CloseColorizer();
                    this.colorizer = null;
                }
            } catch (COMException) {
            }
            try {
                if (this.colorState != null) {
                    Marshal.ReleaseComObject(this.colorState);
                    this.colorState = null;
                }
            } catch (COMException) {
            }
            try {
                if (this.expansionProvider != null) {
                    this.expansionProvider.Dispose();
                    this.expansionProvider = null;
                }

            } catch (COMException) {
            }
            try {

                // Sometimes OnCloseSource is called when language service is changed, (for example
                // when you save the file with a different file extension) in which case we cannot 
                // null out the site because that will cause a crash inside msenv.dll.
                //            if (this.textLines != null) {
                //                ((IObjectWithSite)this.textLines).SetSite(null);
                //            }
                if (this.textLines != null) {
                    this.textLines = null; //rely on GC rather control lifetime through ReleaseCOMObject
                    Marshal.Release(pUnkTextLines);
                }
            } catch (COMException) {
            }
        }

        /// <include file='doc\Source.uex' path='docs/doc[@for="Source.IsClosed"]/*' />
        public bool IsClosed {
            get { return this.textLines == null; }
        }

        /// <include file='doc\Source.uex' path='docs/doc[@for="Source.LastParseTime"]/*' />
        public int LastParseTime {
            get { return this.lastParseTime; }
            set { this.lastParseTime = value; }
        }

        /// <include file='doc\Source.uex' path='docs/doc[@for="Source.GetTextLines"]/*' />
        public IVsTextLines GetTextLines() {
            return this.textLines;
        }
        /// <include file='doc\Source.uex' path='docs/doc[@for="Source.GetLineLength"]/*' />
        public int GetLineLength(int line) {
            int len;
            NativeMethods.ThrowOnFailure(this.textLines.GetLengthOfLine(line, out len));
            return len;
        }
        /// <include file='doc\Source.uex' path='docs/doc[@for="Source.GetLineCount"]/*' />
        public int GetLineCount() {
            int count;
            NativeMethods.ThrowOnFailure(this.textLines.GetLineCount(out count));
            return count;
        }

        /// <include file='doc\Source.uex' path='docs/doc[@for="Source.GetPositionOfLineIndex"]/*' />
        public int GetPositionOfLineIndex(int line, int col) {
            int position;
            NativeMethods.ThrowOnFailure(this.textLines.GetPositionOfLineIndex(line, col, out position));
            return position;
        }
        /// <include file='doc\Source.uex' path='docs/doc[@for="Source.GetLineIndexOfPosition"]/*' />
        public void GetLineIndexOfPosition(int position, out int line, out int col) {
            NativeMethods.ThrowOnFailure(this.textLines.GetLineIndexOfPosition(position, out line, out col));
        }

        /// <include file='doc\Source.uex' path='docs/doc[@for="Source.GetLine"]/*' />
        public string GetLine(int line) {
            int len;
            NativeMethods.ThrowOnFailure(this.textLines.GetLengthOfLine(line, out len));
            return GetText(line, 0, line, len);
        }
        /// <include file='doc\Source.uex' path='docs/doc[@for="Source.GetText"]/*' />
        public string GetText() {
            int endLine, endCol;
            NativeMethods.ThrowOnFailure(this.textLines.GetLastLineIndex(out endLine, out endCol));
            return GetText(0, 0, endLine, endCol);
        }

        /// <include file='doc\Source.uex' path='docs/doc[@for="Source.GetText1"]/*' />
        public string GetText(int startLine, int startCol, int endLine, int endCol) {
            string text;
            Debug.Assert(TextSpanHelper.ValidCoord(this, startLine, startCol) && TextSpanHelper.ValidCoord(this, endLine, endCol));
            NativeMethods.ThrowOnFailure(this.textLines.GetLineText(startLine, startCol, endLine, endCol, out text));
            return text;
        }

        /// <include file='doc\Source.uex' path='docs/doc[@for="Source.GetText2"]/*' />
        public string GetText(TextSpan span) {
            return GetText(span.iStartLine, span.iStartIndex, span.iEndLine, span.iEndIndex);
        }

        /// <include file='doc\Source.uex' path='docs/doc[@for="Source.GetTextUpToLine"]/*' />
        public string GetTextUpToLine(int line) {
            Debug.Assert(TextSpanHelper.ValidCoord(this, line, 0));
            int lastLine;
            NativeMethods.ThrowOnFailure(this.textLines.GetLineCount(out lastLine));
            lastLine--;
            if (line > 0) lastLine = Math.Min(line, lastLine);
            int lastIdx;
            NativeMethods.ThrowOnFailure(this.textLines.GetLengthOfLine(lastLine, out lastIdx));
            return GetText(0, 0, lastLine, lastIdx);
        }

        /// <include file='doc\Source.uex' path='docs/doc[@for="Source.SetText"]/*' />
        public void SetText(string newText) {
            int endLine, endCol;
            NativeMethods.ThrowOnFailure(this.textLines.GetLastLineIndex(out endLine, out endCol));
            int len = (newText == null) ? 0 : newText.Length;
            IntPtr pText = Marshal.StringToCoTaskMemAuto(newText);
            try {
                NativeMethods.ThrowOnFailure(this.textLines.ReplaceLines(0, 0, endLine, endCol, pText, len, null));
            } finally {
                Marshal.FreeCoTaskMem(pText);
            }
        }

        /// <include file='doc\Source.uex' path='docs/doc[@for="Source.SetText"]/*' />
        public void SetText(TextSpan span, string newText) {
            this.SetText(span.iStartLine, span.iStartIndex, span.iEndLine, span.iEndIndex, newText);
        }

        /// <include file='doc\Source.uex' path='docs/doc[@for="Source.SetText"]/*' />
        public void SetText(int startLine, int startCol, int endLine, int endCol, string newText) {
            int len = (newText == null) ? 0 : newText.Length;
            int realEndLine, realEndCol;
            // trim to the real bounds of the file so we don't get a COM exception
            NativeMethods.ThrowOnFailure(this.textLines.GetLastLineIndex(out realEndLine, out realEndCol));
            if (endLine > realEndLine) {
                endLine = realEndLine;
                endCol = realEndCol;
            } else if (endLine == realEndLine && endCol > realEndCol) {
                endCol = realEndCol;
            }
            IntPtr pText = Marshal.StringToCoTaskMemAuto(newText);
            try {
                NativeMethods.ThrowOnFailure(this.textLines.ReplaceLines(startLine, startCol, endLine, endCol, pText, len, null));
            } finally {
                Marshal.FreeCoTaskMem(pText);
            }
        }

        /// <include file='doc\Source.uex' path='docs/doc[@for="Source.GetUserData"]/*' />
        public object GetUserData(ref Guid key) {
            object data = null;
            IVsUserData iud = null;
            iud = (IVsUserData)this.textLines;
            int rc = iud.GetData(ref key, out data);
            iud = null;
            return (rc == NativeMethods.S_OK) ? data : null;
        }

        /// <include file='doc\Source.uex' path='docs/doc[@for="Source.SetUserData"]/*' />
        public void SetUserData(ref Guid key, object data) {
            IVsUserData iud = (IVsUserData)this.textLines;
            NativeMethods.ThrowOnFailure(iud.SetData(ref key, data));
        }

        /// <include file='doc\Source.uex' path='docs/doc[@for="Source.Dirty"]/*' />
        public bool IsDirty {
            get {
                return this.dirty;
            }
            set {
#if LANGTRACE
                //Trace.WriteLine("Source.IsDirty="+value);
#endif
                this.dirty = value;
                if (value) {
                    this.dirtyTime = System.Environment.TickCount;
                    this.requestSync = (this.requestSync == Int32.MaxValue) ? 0 : this.requestSync + 1;
                }
            }
        }

        /// <include file='doc\Source.uex' path='docs/doc[@for="Source.ChangeCount"]/*' />
        /// Returns a number indicating whether the buffer has changed since you last called.
        public int ChangeCount {
            get {
                return this.requestSync;
            }
        }

        /// <include file='doc\Source.uex' path='docs/doc[@for="Source.DirtySpan"]/*' />
        public TextSpan DirtySpan {
            get {
                return this.dirtySpan;
            }
        }

        void AddDirty(TextSpan span) {
            if (!this.IsDirty) {
                this.dirtySpan = span;
            } else {
                this.dirtySpan = TextSpanHelper.Merge(dirtySpan, span);
            }
            this.IsDirty = true;
        }

        #region Reformatting

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="ViewFilter.Reformat"]/*' />
        /// <summary>
        /// This method formats the given span using the given EditArray. The default behavior does nothing.  
        /// So you need to override this method if you want formatting to work.  
        /// An empty input span means reformat the entire document.
        /// You also need to turn on Preferences.EnableFormatSelection.
        /// </summary>
        public virtual void ReformatSpan(EditArray mgr, TextSpan span) {
        }

        #endregion

        #region Commenting

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="Source.GetCommentFormat"]/*' />
        /// <summary>Override this method if you want to provide different comment dilimiters.
        /// You can turn off commenting by setting Preferences.EnableCommenting to false.</summary>
        public virtual CommentInfo GetCommentFormat() {
            CommentInfo info = new CommentInfo();
            info.LineStart = "//";
            info.BlockStart = "/*";
            info.BlockEnd = "*/";
            info.UseLineComments = true;
            return info;
        }

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="Source.CommentSpan"]/*' />
        public virtual TextSpan CommentSpan(TextSpan span) {
            TextSpan result = span;
            CommentInfo commentInfo = this.GetCommentFormat();

            using (new CompoundAction(this, SR.GetString(SR.CommentSelection))) {
                //try to use line comments first, if we can.        
                if (commentInfo.UseLineComments && !string.IsNullOrEmpty(commentInfo.LineStart)) {
                    span = CommentLines(span, commentInfo.LineStart);
                } else if (!string.IsNullOrEmpty(commentInfo.BlockStart) && !string.IsNullOrEmpty(commentInfo.BlockEnd)) {
                    result = CommentBlock(span, commentInfo.BlockStart, commentInfo.BlockEnd);
                }
            }
            return result;
        }

        /// <include file='doc\ViewFilter.uex' path='docs/doc[@for="Source.CommentBlock"]/*' />
        /// <summary>
        /// Called from Comment Selection. Default behavior is to insert line style comments
        /// at beginning and end of selection. Override to add custome behavior.
        /// </summary>
        /// <param name="span"></param>
        /// <param name="lineComment"></param>
        /// <returns>The final span of the commented lines including the comment delimiters</returns>
        public virtual TextSpan CommentLines(TextSpan span, string lineComment) {
            //comment each line
            for (int line = span.iStartLine; line <= span.iEndLine; line++) {
                int idx = this.ScanToNonWhitespaceChar(line);
                this.SetText(line, idx, line, idx, lineComment);
            }
            span.iEndIndex += lineComment.Length;
            return span;
        }

        /// <include file='doc\ViewFilter.uex' path='docs/doc[@for="Source.CommentBlock"]/*' />
        /// <summary>
        /// Called from Comment Selection. Default behavior is to insert block style comments
        /// at beginning and end of selection. Override to add custome behavior.
        /// </summary>
        /// <returns>The final span of the commented block including the comment delimiters</returns>
        public virtual TextSpan CommentBlock(TextSpan span, string blockStart, string blockEnd) {
            //sp. case no selection
            if (span.iStartIndex == span.iEndIndex &&
                span.iStartLine == span.iEndLine) {
                span.iStartIndex = this.ScanToNonWhitespaceChar(span.iStartLine);
                span.iEndIndex = this.GetLineLength(span.iEndLine);
            }
            //sp. case partial selection on single line
            if (span.iStartLine == span.iEndLine) {
                span.iEndIndex += blockStart.Length;
            }
            //add start comment
            this.SetText(span.iStartLine, span.iStartIndex, span.iStartLine, span.iStartIndex, blockStart);
            //add end comment
            this.SetText(span.iEndLine, span.iEndIndex, span.iEndLine, span.iEndIndex, blockEnd);
            span.iEndIndex += blockEnd.Length;
            return span;
        }

        /// <summary>
        /// Uncomments the given span of text and returns the span of the uncommented block.
        /// </summary>
        public virtual TextSpan UncommentSpan(TextSpan span) {
            CommentInfo commentInfo = this.GetCommentFormat();

            using (new CompoundAction(this, SR.GetString(SR.UncommentSelection))) {
                // is block comment selected?
                if (commentInfo.UseLineComments && !string.IsNullOrEmpty(commentInfo.LineStart)) {
                    span = UncommentLines(span, commentInfo.LineStart);
                } else if (commentInfo.BlockStart != null && commentInfo.BlockEnd != null) {
                    // TODO: this doesn't work if the selection contains a mix of code and block comments
                    // or multiple block comments!!  We should use the scanner to find the embedded 
                    // comments and uncomment the resulting comment spans only.
                    this.TrimSpan(ref span);
                    span = UncommentBlock(span, commentInfo.BlockStart, commentInfo.BlockEnd);
                }
            }
            return span;
        }

        /// <include file='doc\ViewFilter.uex' path='docs/doc[@for="ViewFilter.UncommentLines"]/*' />
        public virtual TextSpan UncommentLines(TextSpan span, string lineComment) {
            // Remove line comments
            int clen = lineComment.Length;
            for (int line = span.iStartLine; line <= span.iEndLine; line++) {
                int i = this.ScanToNonWhitespaceChar(line);
                string text = this.GetLine(line);
                if (text.Substring(i, clen) == lineComment) {
                    this.SetText(line, i, line, i + clen, ""); // remove line comment.
                    if (line == span.iStartLine && span.iStartIndex != 0) span.iStartIndex = i;
                }
            }
            span.iStartIndex = 0;
            return span;
        }

        /// <include file='doc\ViewFilter.uex' path='docs/doc[@for="ViewFilter.UncommentBlock"]/*' />
        /// <summary>Uncomments the given block and returns the span of the uncommented block</summary>
        public virtual TextSpan UncommentBlock(TextSpan span, string blockStart, string blockEnd) {

            int startLen = this.GetLineLength(span.iStartLine);
            int endLen = this.GetLineLength(span.iEndLine);

            TextSpan result = span;

            //sp. case no selection, try and uncomment the current line.
            if (span.iStartIndex == span.iEndIndex &&
                span.iStartLine == span.iEndLine) {
                span.iStartIndex = this.ScanToNonWhitespaceChar(span.iStartLine);
                span.iEndIndex = this.GetLineLength(span.iEndLine);
            }

            // Check that comment start and end blocks are possible.
            if (span.iStartIndex + blockStart.Length <= startLen && span.iEndIndex - blockStart.Length >= 0) {
                string startText = this.GetText(span.iStartLine, span.iStartIndex, span.iStartLine, span.iStartIndex + blockStart.Length);

                if (startText == blockStart) {
                    string endText = null;
                    TextSpan linespan = span;
                    linespan.iStartLine = linespan.iEndLine;
                    linespan.iStartIndex = linespan.iEndIndex - blockEnd.Length;
                    Debug.Assert(TextSpanHelper.IsPositive(linespan));
                    endText = this.GetText(linespan);
                    if (endText == blockEnd) {
                        //yes, block comment selected; remove it        
                        this.SetText(linespan.iStartLine, linespan.iStartIndex, linespan.iEndLine, linespan.iEndIndex, null);
                        this.SetText(span.iStartLine, span.iStartIndex, span.iStartLine, span.iStartIndex + blockStart.Length, null);
                        span.iEndIndex -= blockEnd.Length;
                        if (span.iStartLine == span.iEndLine) span.iEndIndex -= blockStart.Length;
                        result = span;
                    }
                }
            }

            return result;
        }


        #endregion

        // IVsFinalTextChangeCommitEvents
        #region IVsFinalTextChangeCommitEvents
        /// <include file='doc\Source.uex' path='docs/doc[@for="Source.OnChangesCommitted"]/*' />
        public virtual void OnChangesCommitted(uint reason, TextSpan[] changedArea) {
            AddDirty(changedArea[0]);
        }
        #endregion

        #region IVsTextLinesEvents
        /// <include file='doc\Source.uex' path='docs/doc[@for="Source.OnChangeLineText"]/*' />
        public virtual void OnChangeLineText(TextLineChange[] lineChange, int last) {
            TextSpan span = new TextSpan();
            span.iStartIndex = lineChange[0].iStartIndex;
            span.iStartLine = lineChange[0].iStartLine;
            span.iEndLine = lineChange[0].iOldEndLine;
            span.iEndIndex = lineChange[0].iOldEndIndex;
            AddDirty(span);
            span.iEndLine = lineChange[0].iNewEndLine;
            span.iEndIndex = lineChange[0].iNewEndIndex;
            AddDirty(span);
        }

        /// <include file='doc\Source.uex' path='docs/doc[@for="Source.OnChangeLineAttributes"]/*' />
        public virtual void OnChangeLineAttributes(int firstLine, int lastLine) {
        }
        #endregion

        //===================================================================================
        // Helper methods:
        //===================================================================================   
        /// <include file='doc\Source.uex' path='docs/doc[@for="Source.GetFilePath"]/*' />
        public virtual string GetFilePath() {
            if (this.textLines == null) return null;
            return FilePathUtilities.GetFilePath(this.textLines);
        }

        /// <summary>
        /// Return the column position of 1st non whitespace character on line
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public int ScanToNonWhitespaceChar(int line) {
            string text = GetLine(line);
            int len = text.Length;
            int i = 0;
            while (i < len && Char.IsWhiteSpace(text[i])) {
                i++;
            }
            return i;
        }

        /// <include file='doc\Source.uex' path='docs/doc[@for="Source.ColumnToVisiblePosition"]/*' />
        /// <summary>
        /// Return the column position that the user will see given the current
        /// tab size setting.  This is the opposite of VisiblePositionToColumn
        /// </summary>
        public int ColumnToVisiblePosition(int line, int col) {
            string text = this.GetLine(line);
            int tabsize = this.LanguageService.Preferences.TabSize;
            int visible = 0;
            for (int i = 0, n = text.Length; i < col && i < n; i++) {
                char ch = text[i];
                int step = 1;
                if (ch == '\t') {
                    step = tabsize - visible % tabsize;
                }
                visible += step;
            }
            return visible;
        }

        /// <include file='doc\Source.uex' path='docs/doc[@for="Source.VisiblePositionToColumn"]/*' />
        /// <summary>
        /// Convert a user visible position back to char position in the buffer.
        /// This is the opposite of ColumnToVisiblePosition. In this case the 
        /// visible position was off the end of the line, it just returns the 
        /// column position at the end of the line.
        /// </summary>
        public int VisiblePositionToColumn(int line, int visiblePosition) {
            string text = this.GetLine(line);
            int tabsize = this.LanguageService.Preferences.TabSize;
            int visible = 0;
            int i = 0;
            for (int n = text.Length; i < n; i++) {
                char ch = text[i];
                int step = 1;
                if (ch == '\t') {
                    step = visible % tabsize;
                    if (step == 0) step = tabsize;
                }
                visible += step;
                if (visible > visiblePosition)
                    return i;
            }
            return i;
        }

        /// <include file='doc\Source.uex' path='docs/doc[@for="Source.GetDocumentSpan"]/*' />
        public TextSpan GetDocumentSpan() {
            TextSpan span = new TextSpan();
            span.iStartIndex = span.iStartLine = 0;
            NativeMethods.ThrowOnFailure(this.textLines.GetLastLineIndex(out span.iEndLine, out span.iEndIndex));
            return span;
        }

        string NormalizeString(string message) {
            //remove control characters
            StringBuilder sb = new StringBuilder();
            for (int i = 0, n = message.Length; i < n; i++) {
                char ch = message[i];

                sb.Append(System.Convert.ToInt32(ch) < 0x20 ? ' ' : ch);
            }
            return sb.ToString();
        }

        // helper methods.
        /// <include file='doc\Source.uex' path='docs/doc[@for="Source.CreateErrorTaskItem"]/*' />
        public virtual DocumentTask CreateErrorTaskItem(TextSpan span, string filename, string message, TaskPriority priority, TaskCategory category, MARKERTYPE markerType, TaskErrorCategory errorCategory) {
            // create task item
            
            //TODO this src obj may not be the one matching filename.
            //find the src for the filename only then call ValidSpan.
            //Debug.Assert(TextSpanHelper.ValidSpan(this, span)); 

            DocumentTask taskItem = CreateErrorTaskItem(span, markerType, filename);
            taskItem.Priority = priority;
            taskItem.Category = category;
            taskItem.ErrorCategory = errorCategory;
            taskItem.Text = message;
            taskItem.IsTextEditable = false;
            taskItem.IsCheckedEditable = false;
            return taskItem;
        }

        /// <include file='doc\Source.uex' path='docs/doc[@for="Source.CreateErrorTaskItem2"]/*' />
        public virtual DocumentTask CreateErrorTaskItem(TextSpan span, MARKERTYPE markerType, string filename) {
            return new DocumentTask(this.service.Site, this.textLines, markerType, span, filename);
        }

        /// <include file='doc\Source.uex' path='docs/doc[@for="Source.GetNewLine"]/*' />
        // return the type of new line to use that matches the one at the given line.
        public string GetNewLine(int line) {
            string eol = "\r\n"; // "\x000D\x000A"
            LINEDATAEX[] ld = new LINEDATAEX[1];
            NativeMethods.ThrowOnFailure(this.textLines.GetLineDataEx(0, line, 0, 0, ld, null));
            uint iEolType = (uint)ld[0].iEolType;
            if (iEolType == (uint)EOLTYPE.eolUNI_LINESEP) {
                if (this.textLines is IVsTextLines2) {
                    IVsTextLines2 textLines2 = (IVsTextLines2)this.textLines;
                    int hr = textLines2.GetEolTypeEx(ld, out iEolType);
                    if (NativeMethods.Failed(hr)) {
#if LANGTRACE
                        Trace.WriteLine("Ignoring actual EOL type and continuing");
#endif
                        iEolType = (uint)EOLTYPE.eolUNI_LINESEP;
                    }
                }
            }

            switch (iEolType) {
            case (uint)EOLTYPE.eolCR:
            eol = "\r"; // "\x000D"
            break;
            case (uint)EOLTYPE.eolLF:
            eol = "\n"; // "\x000A"
            break;
            case (uint)EOLTYPE.eolUNI_LINESEP:
            eol = "\u2028";
            break;
            case (uint)EOLTYPE.eolUNI_PARASEP:
            eol = "\u2029";
            break;
            case (uint)_EOLTYPE2.eolUNI_NEL:
            eol = "\u0085";
            break;
            }

            NativeMethods.ThrowOnFailure(this.textLines.ReleaseLineDataEx(ld));

            return eol;
        }

        /// <include file='doc\Source.uex' path='docs/doc[@for="Source.NormalizeNewlines"]/*' />
        /// <summary>Convert the newlines in the given input string to the style of newline
        /// provided in the second argument.</summary>
        public string NormalizeNewlines(string input, string newline) {
            StringBuilder sb = new StringBuilder();
            for (int i = 0, n = input.Length; i < n; i++) {
                char c = input[i];
                if (c == '\r') {
                    sb.Append(newline);
                    if (i + 1 < n && input[i + 1] == '\n') {
                        i++;
                    }
                } else if (c == '\n') {
                    sb.Append(newline);
                } else {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }


        /// <include file='doc\Source.uex' path='docs/doc[@for="Source.GetTokenInfoAt"]/*' />
        public virtual int GetTokenInfoAt(TokenInfo[] infoArray, int col, ref TokenInfo info) {
            for (int i = 0, len = infoArray.Length; i < len; i++) {
                int start = infoArray[i].StartIndex;
                int end = infoArray[i].EndIndex;

                if (i == 0 && start > col)
                    return -1;

                if (col >= start && col <= end) {
                    info = infoArray[i];
                    return i;
                }
            }

            return -1;
        }


        /// <include file='doc\Source.uex' path='docs/doc[@for="Source.OnIdle"]/*' />
        public virtual void OnIdle(bool periodic) {
            // Kick of a background parse, but only in the periodic intervals
            if (!periodic || this.service == null || this.service.LastActiveTextView == null) {
                return;
            }

            // Don't do background parsing while intellisense completion is going on
            if ((this.completionSet != null && this.completionSet.IsDisplayed) ||
                (this.methodData != null && this.methodData.IsDisplayed)) {
                return;
            }

            // Don't kick off a background parse, while the user is typing.
            // this.dirtyTime moves with every keystroke.
            int msec = System.Environment.TickCount;
            int delay = Math.Max(this.lastParseTime, this.service.Preferences.CodeSenseDelay);

            if ((msec < this.dirtyTime) ||   // Environment.TickCount wraps around every 49 days.
                (msec - this.dirtyTime > delay)) {
                if (this.dirty && !this.service.IsParsing) {
                    BeginParse();
                }
            }
        }

        /// <include file='doc\Source.uex' path='docs/doc[@for="Source.BeginParse"]/*' />
        public virtual void BeginParse() {
            this.dirty = false;
            this.BeginParse(0, 0, new TokenInfo(), ParseReason.Check, this.service.LastActiveTextView, new ParseResultHandler(this.HandleParseResponse));
        }

        /// <include file='doc\Source.uex' path='docs/doc[@for="Source.GetTokenInfo"]/*' />
        public virtual TokenInfo GetTokenInfo(int line, int col) {
            //get current line 
            TokenInfo info = new TokenInfo();
            //get line info
            TokenInfo[] lineInfo = this.colorizer.GetLineInfo(this.textLines, line, this.colorState);
            if (lineInfo != null) {
                //get character info      
                this.GetTokenInfoAt(lineInfo, col - 1, ref info);
            }

            return info;
        }

        /// <include file='doc\Source.uex' path='docs/doc[@for="Source.OnCommand"]/*' />
        public virtual void OnCommand(IVsTextView textView, VsCommands2K command, char ch) {
            if (textView == null || this.service == null || !this.service.Preferences.EnableCodeSense)
                return;

            bool backward = (command == VsCommands2K.BACKSPACE || command == VsCommands2K.BACKTAB ||
                command == VsCommands2K.LEFT || command == VsCommands2K.LEFT_EXT);

            int line, idx;

            NativeMethods.ThrowOnFailure(textView.GetCaretPos(out line, out idx));

            TokenInfo info = GetTokenInfo(line, idx);
            TokenTriggers triggerClass = info.Trigger;

            if ((triggerClass & TokenTriggers.MemberSelect) != 0 && (command == VsCommands2K.TYPECHAR)) {
                ParseReason reason = ((triggerClass & TokenTriggers.MatchBraces) == TokenTriggers.MatchBraces) ? ParseReason.MemberSelectAndHighlightBraces : ParseReason.MemberSelect;
                this.Completion(textView, info, reason);
            } else if ((triggerClass & TokenTriggers.MatchBraces) != 0 && this.service.Preferences.EnableMatchBraces) {
                if ((command != VsCommands2K.BACKSPACE) && ((command == VsCommands2K.TYPECHAR) || this.service.Preferences.EnableMatchBracesAtCaret)) {
                    this.MatchBraces(textView, line, idx, info);
                }
            }
            //displayed & a trigger found
            // todo: This means the method tip disappears if you type "ENTER" 
            // while entering method arguments, which is bad.
            if ((triggerClass & TokenTriggers.MethodTip) != 0 && this.methodData.IsDisplayed) {
                if ((triggerClass & TokenTriggers.MethodTip) == TokenTriggers.ParameterNext) {
                    //this is an optimization
                    methodData.AdjustCurrentParameter((backward && idx > 0) ? -1 : +1);
                } else {
                    //this is the general case
                    this.MethodTip(textView, line, (backward && idx > 0) ? idx - 1 : idx, info);
                }
            } else if ((triggerClass & TokenTriggers.MethodTip) != 0 && (command == VsCommands2K.TYPECHAR) && this.service.Preferences.ParameterInformation) {
                //not displayed & trigger found & character typed & method info enabled
                this.MethodTip(textView, line, idx, info);
            } else if (methodData.IsDisplayed) {
                //displayed & complex command
                this.MethodTip(textView, line, idx, info);
            }
        }

        /// <include file='doc\Source.uex' path='docs/doc[@for="Source.GetWordExtent"]/*' />
        public bool GetWordExtent(int line, int idx, WORDEXTFLAGS flags, out int startIdx, out int endIdx) {
            Debug.Assert(line >= 0 && idx >= 0);
            startIdx = endIdx = idx;

            int length;
            NativeMethods.ThrowOnFailure(this.textLines.GetLengthOfLine(line, out length));
            // pin to length of line just in case we return false and skip pinning at the end of this method.
            startIdx = endIdx = Math.Min(idx, length);
            if (length == 0) {
                return false;
            }

            //get the character classes
            TokenInfo[] lineInfo = this.colorizer.GetLineInfo(this.textLines, line, this.colorState);
            if (lineInfo == null || lineInfo.Length == 0) return false;

            int count = lineInfo.Length;
            TokenInfo info = new TokenInfo();
            int index = this.GetTokenInfoAt(lineInfo, idx, ref info);

            if (index < 0) return false;
            // don't do anything in comment or text or literal space, unless we
            // are doing intellisense in which case we want to match the entire value
            // of quoted strings.
            TokenType type = info.Type;
            if ((flags != Source.WholeToken || type != TokenType.String) && (type == TokenType.Comment || type == TokenType.LineComment || type == TokenType.Text || type == TokenType.String || type == TokenType.Literal))
                return false;
            //search for a token
            switch (flags & WORDEXTFLAGS.WORDEXT_MOVETYPE_MASK) {
            case WORDEXTFLAGS.WORDEXT_PREVIOUS:
            index--;
            while (index >= 0 && !MatchToken(flags, lineInfo[index])) index--;
            if (index < 0) return false;
            break;

            case WORDEXTFLAGS.WORDEXT_NEXT:
            index++;
            while (index < count && !MatchToken(flags, lineInfo[index])) index++;
            if (index >= count) return false;
            break;

            case WORDEXTFLAGS.WORDEXT_NEAREST: {
                int prevIdx = index;
                prevIdx--;
                while (prevIdx >= 0 && !MatchToken(flags, lineInfo[prevIdx])) prevIdx--;
                int nextIdx = index;
                while (nextIdx < count && !MatchToken(flags, lineInfo[nextIdx])) nextIdx++;
                if (prevIdx < 0 && nextIdx >= count) return false;
                else if (nextIdx >= count) index = prevIdx;
                else if (prevIdx < 0) index = nextIdx;
                else if (index - prevIdx < nextIdx - index) index = prevIdx;
                else
                    index = nextIdx;
                break;
            }

            case WORDEXTFLAGS.WORDEXT_CURRENT:
            default:
            if (!MatchToken(flags, info))
                return false;

            break;
            }
            info = lineInfo[index];

            // We found something, set the span, pinned to the valid coordinates for the
            // current line.
            startIdx = Math.Min(length, info.StartIndex);
            endIdx = Math.Min(length, info.EndIndex);

            // The scanner endIndex is the last char of the symbol, but
            // GetWordExtent wants it to be the next char after that, so 
            // we increment the endIdx (if we can).
            if (endIdx < length) endIdx++;
            return true;
        }

        static bool MatchToken(WORDEXTFLAGS flags, TokenInfo info) {
            TokenType type = info.Type;
            if ((flags & WORDEXTFLAGS.WORDEXT_FINDTOKEN) != 0)
                return !(type == TokenType.Comment || type == TokenType.LineComment);
            else
                return (type == TokenType.Keyword || type == TokenType.Identifier || type == TokenType.String || type == TokenType.Literal);
        }



        /// <include file='doc\Source.uex' path='docs/doc[@for="Source.TrimSpan(ref span);"]/*' />
        /// Trim whitespace from the beginning and ending of the given span.
        public void TrimSpan(ref TextSpan span) {
            // Scan forwards past whitepsace.
            int length;
            NativeMethods.ThrowOnFailure(this.textLines.GetLengthOfLine(span.iStartLine, out length));

            while (span.iStartLine < span.iEndLine || (span.iStartLine == span.iEndLine && span.iStartIndex < span.iEndIndex)) {
                string text = this.GetText(span.iStartLine, 0, span.iStartLine, length);
                for (int i = span.iStartIndex; i < length; i++) {
                    char ch = text[i];
                    if (ch != ' ' && ch != '\t')
                        break;
                    span.iStartIndex++;
                }
                if (span.iStartIndex >= length) {
                    span.iStartIndex = 0;
                    span.iStartLine++;
                    NativeMethods.ThrowOnFailure(this.textLines.GetLengthOfLine(span.iStartLine, out length));
                } else {
                    break;
                }
            }
            // Scan backwards past whitepsace.
            NativeMethods.ThrowOnFailure(this.textLines.GetLengthOfLine(span.iEndLine, out length));

            while (span.iStartLine < span.iEndLine || (span.iStartLine == span.iEndLine && span.iStartIndex < span.iEndIndex)) {
                string text = GetText(span.iEndLine, 0, span.iEndLine, length);
                for (int i = span.iEndIndex - 1; i >= 0; i--) {
                    char ch = text[i];
                    if (ch != ' ' && ch != '\t')
                        break;
                    span.iEndIndex--;
                }
                if (span.iEndIndex <= 0) {
                    span.iEndLine--;
                    NativeMethods.ThrowOnFailure(this.textLines.GetLengthOfLine(span.iEndLine, out length));
                    span.iEndIndex = length;
                } else {
                    break;
                }
            }
        }

        /// <include file='doc\Source.uex' path='docs/doc[@for="Source.Completion"]/*' />
        public virtual void Completion(IVsTextView textView, TokenInfo info, ParseReason reason) {
            int line;
            int idx;
            NativeMethods.ThrowOnFailure(textView.GetCaretPos(out line, out idx));
            this.BeginParse(line, idx, info, reason, textView, new ParseResultHandler(this.HandleCompletionResponse));
        }

        internal void HandleCompletionResponse(ParseRequest req) {
            try {
                if (this.service == null || req == null || req.View == null ||
                    req.Scope == null || req.Timestamp != this.requestSync)
                    return;
#if LANGTRACE
                Trace.WriteLine("Source::HandleCompletionResponse");
#endif
                SetLastParseTime(req.parseTime); // for OnIdle loop

                ParseReason reason = req.Reason;
                if (reason == ParseReason.MemberSelectAndHighlightBraces)
                    HandleMatchBracesResponse(req);

                Declarations decls = req.Scope.GetDeclarations(req.View, req.Line, req.Col, req.TokenInfo, reason);
                // We go to all this effort even when this.service.Preferences.AutoListMembers
                // is false because sometimes the language service also wants to do "auto-insert"
                // operations at the same time as completion.  
                bool completeWord = (reason == ParseReason.CompleteWord);
                int line;
                int idx;
                NativeMethods.ThrowOnFailure(req.View.GetCaretPos(out line, out idx));

                if (decls.GetCount() > 0 &&
                    (this.service.Preferences.AutoListMembers || completeWord || reason == ParseReason.DisplayMemberList) &&
                    line == req.Line && idx == req.Col //ensure user has not chaged cursor location
                    ) {
                    this.completionSet.Init(req.View, decls, completeWord);
                }

#if LANGTRACE
            } catch (Exception e) {
                Trace.WriteLine("HandleCompletionResponse exception: " + e.Message);
#endif
            } catch {
            }
        }

        internal void SetLastParseTime(int time) {
#if LANGTRACE
            Trace.WriteLine("Previous parse time="+this.lastParseTime+"\tNew parse time="+time);
#endif
            this.lastParseTime = time;            
        }

        /// <include file='doc\Source.uex' path='docs/doc[@for="Source.MethodTip"]/*' />
        public virtual void MethodTip(IVsTextView textView, int line, int index, TokenInfo info) {
            this.BeginParse(line, index, info, ParseReason.MethodTip, textView, new ParseResultHandler(this.HandleMethodTipResponse));
        }

        internal void HandleMethodTipResponse(ParseRequest req) {
            try {
                if (this.service == null || req.Timestamp != this.requestSync)
                    return;

                CallInfo call = req.Sink.MethodCalls.GetCurrentMethodCall();
                if (call == null) goto fail;
                StringCollection names = call.names;
                if (names.Count == 0) goto fail;
                ArrayList contexts = call.sourceLocations;
                string name = names[names.Count - 1];
                TextSpan span = (TextSpan)contexts[names.Count - 1];
                Methods methods = req.Scope.GetMethods(span.iStartLine, span.iStartIndex, name);

                if (methods == null)
                    goto fail;

                int currentParameter = call.currentParameter;
                this.methodData.Refresh(req.View, methods, currentParameter, span);
                return;
            fail:
                DismissCompletor();
#if LANGTRACE
            } catch (Exception e) {
                Trace.WriteLine("HandleMethodTipResponse exception: " + e.Message);
#endif
            } catch {
            }
        }

        /// <include file='doc\Source.uex' path='docs/doc[@for="Source.MatchBraces"]/*' />
        public virtual void MatchBraces(IVsTextView textView, int line, int index, TokenInfo info) {
            this.BeginParse(line, index, info, ParseReason.HighlightBraces, textView, new ParseResultHandler(this.HandleMatchBracesResponse));
        }

        internal void HandleMatchBracesResponse(ParseRequest req) {
            try {
                if (this.service == null || req.Timestamp != this.requestSync)
                    return;

#if LANGTRACE
                Trace.WriteLine("HandleMatchBracesResponse");
#endif
                if (req.Sink.Spans.Count == 0)
                    return;

                // Normalize the spans, and weed out empty ones, since there's no point
                // trying to highlight an empty span.
                ArrayList normalized = new ArrayList();
                foreach (TextSpan span in req.Sink.Spans) {
                    TextSpan norm = span;
                    TextSpanHelper.Normalize(ref norm, this.textLines);
                    if (!TextSpanHelper.ValidSpan(this, norm)) {
                        Debug.Assert(false, "Invalid text span");
                    } else if (!TextSpanHelper.IsEmpty(norm)) {
                        normalized.Add(norm);
                    }
                }

                if (normalized.Count == 0)
                    return;

                //transform spanList into an array of spans
                TextSpan[] spans = (TextSpan[])normalized.ToArray(typeof(TextSpan));

                //highlight
                NativeMethods.ThrowOnFailure(req.View.HighlightMatchingBrace((uint)this.service.Preferences.HighlightMatchingBraceFlags, (uint)spans.Length, spans));
                //try to show the matching line in the statusbar
                if (spans.Length > 0 && this.service.Preferences.EnableShowMatchingBrace) {
                    IVsStatusbar statusBar = (IVsStatusbar)service.Site.GetService(typeof(SVsStatusbar));
                    if (statusBar != null) {
                        TextSpan span = spans[0];
                        bool found = false;
                        // Gather up the other side of the brace match so we can 
                        // display the text in the status bar. There could be more than one
                        // if MatchTriple was involved, in which case we merge them.
                        for (int i = 0, n = spans.Length; i < n; i++) {
                            TextSpan brace = spans[i];
                            if (brace.iStartLine != req.Line) {
                                if (brace.iEndLine != brace.iStartLine) {
                                    brace.iEndLine = brace.iStartLine;
                                    brace.iEndIndex = this.GetLineLength(brace.iStartLine);
                                }
                                if (!found) {
                                    span = brace;
                                } else if (brace.iStartLine == span.iStartLine) {
                                    span = TextSpanHelper.Merge(span, brace);
                                }
                                found = true;
                            }
                        }
                        if (found) {
                            Debug.Assert(TextSpanHelper.IsPositive(span));
                            string text = this.GetText(span);

                            int start;
                            int len = text.Length;

                            for (start = 0; start < len && Char.IsWhiteSpace(text[start]); start++) ;

                            if (start < span.iEndIndex) {
                                if (text.Length > 80) {
                                    text = String.Format(CultureInfo.CurrentUICulture, SR.GetString(SR.Truncated), text.Substring(0, 80));
                                }
                                text = String.Format(CultureInfo.CurrentUICulture, SR.GetString(SR.BraceMatchStatus), text);
                                NativeMethods.ThrowOnFailure(statusBar.SetText(text));
                            }
                        }
                    }
                }
#if LANGTRACE
            } catch (Exception e) {
                Trace.WriteLine("HandleMatchBracesResponse exception: " + e.Message);
#endif
            } catch {
            }
        }

        /// <include file='doc\Source.uex' path='docs/doc[@for="Source.GetPairExtents"]/*' />
        public virtual void GetPairExtents(IVsTextView textView, int line, int col, out TextSpan span) {
            span = new TextSpan();
            TextSpan startBraceSpan, endBraceSpan;
            this.GetPairExtents(textView, line, col, out startBraceSpan, out endBraceSpan);
            span.iStartLine = startBraceSpan.iStartLine;
            span.iStartIndex = startBraceSpan.iStartIndex;
            span.iEndLine = endBraceSpan.iStartLine;
            span.iEndIndex = endBraceSpan.iStartIndex;

            TextSpanHelper.MakePositive(ref span);
            Debug.Assert(TextSpanHelper.ValidSpan(this, span));
            return;
        }

        public virtual bool GetPairExtents(IVsTextView textView, int line, int col, out TextSpan startBraceSpan, out TextSpan endBraceSpan) {
            bool found = false;
            startBraceSpan = new TextSpan();
            endBraceSpan = new TextSpan();

            // Synchronously return the matching brace location.      
            ParseRequest req = this.BeginParse(line, col, new TokenInfo(), ParseReason.MatchBraces, textView, new ParseResultHandler(HandleGetPairExtentResponse));
            AuthoringSink sink = req.Sink;
            AuthoringScope scope = req.Scope;
            IAsyncResult result = req.result;
            if (result != null && !result.IsCompleted) {
                result.AsyncWaitHandle.WaitOne();
            }

            ArrayList braces = sink.Braces;
            int matches = braces.Count;
            if (matches == 0)
                return found;

            // The following algorithm allows for multiple potentially overlapping
            // matches to be returned. This is because the same pairs used here are
            // also used in brace highlighting, and brace highlighting supports
            // MatchTriple which include more than 2 spans.  So here
            // we have to find which of the spans we are currently inside.

            int i = 0;
            for (i = 0; i < matches; i++) {
                BraceMatch m = (BraceMatch)sink.Braces[i];
                TripleMatch t = m as TripleMatch;
                if (TextSpanHelper.ContainsInclusive(m.a, line, col)) {
                    startBraceSpan = m.a;
                    endBraceSpan = m.b;
                    found = true;
                    break;
                } else if (TextSpanHelper.ContainsInclusive(m.b, line, col)) {
                    if (t != null) {
                        startBraceSpan = m.b;
                        endBraceSpan = t.c;
                    } else {
                        startBraceSpan = m.a;
                        endBraceSpan = m.b;
                    }
                    found = true;
                    break;
                } else if (t != null && TextSpanHelper.ContainsInclusive(t.c, line, col)) {
                    startBraceSpan = m.a;
                    endBraceSpan = t.c;
                    found = true;
                    break;
                }
            }

            return found;
        }

        void HandleGetPairExtentResponse(ParseRequest request) {
        }

        internal ParseRequest BeginParse(int line, int idx, TokenInfo info, ParseReason reason, IVsTextView view, ParseResultHandler callback) {
            string text = this.GetText(); // get all the text
            string fname = this.GetFilePath();
            ParseRequest request = this.service.CreateParseRequest(this, line, idx, info, text, fname, reason, view);
            request.Timestamp = this.requestSync;
            request.DirtySpan = this.dirtySpan;
            if (callback == null || !this.LanguageService.Preferences.EnableAsyncCompletion) {
                request.IsSynchronous = true; //unless registry value indicates that sync ops always prefer async 
            }
            if (request.IsSynchronous) {
                this.service.ParseRequest(request);
                SetLastParseTime(request.parseTime);
                if (callback != null) callback(request);
            } else {
                request.result = this.service.BeginParse(request, callback);
            }
            return request;
        }

        internal void HandleParseResponse(ParseRequest req) {
            try {
#if LANGTRACE
                Trace.WriteLine("HandleParseResponse:" + req.Timestamp);
#endif
                if (this.service == null) return;

                SetLastParseTime(req.parseTime); // for OnIdle loop

                if (req.Timestamp == this.requestSync) {
                    // If the request is out of sync with the buffer, then the error spans
                    // and hidden regions could be wrong, so we ignore this parse and wait 
                    // for the next OnIdle parse.
                    ReportTasks(req.Sink.errors);
                    if (req.Sink.ProcessHiddenRegions) {
                        ProcessHiddenRegions(req.Sink.hiddenRegions);
                    }
                }
                this.service.OnParseComplete(req);
#if LANGTRACE
            } catch (Exception e) {
                Trace.WriteLine("HandleParseResponse exception: " + e.Message);
#endif
            } catch {
            }
        }

        internal void FixupMarkerSpan(ref TextSpan span) {
            // This is similar to TextSpanHelper.Normalize except that 
            // we try not to create empty spans at end of line, since VS doesn't like
            // empty spans for text markers.  See comment in CreateMaker in DocumentTask.cs 

            //adjust max. lines
            int lineCount;
            if (NativeMethods.Failed(this.textLines.GetLineCount(out lineCount)))
                return;
            span.iEndLine = Math.Min(span.iEndLine, lineCount - 1);
            //make sure the start is still before the end
            if (!TextSpanHelper.IsPositive(span)) {
                span.iStartLine = span.iEndLine;
                span.iStartIndex = span.iEndIndex;
            }
            //adjust for line length
            int lineLength;
            if (NativeMethods.Failed(this.textLines.GetLengthOfLine(span.iStartLine, out lineLength)))
                return;
            span.iStartIndex = Math.Min(span.iStartIndex, lineLength);
            if (NativeMethods.Failed(this.textLines.GetLengthOfLine(span.iEndLine, out lineLength)))
                return;
            span.iEndIndex = Math.Min(span.iEndIndex, lineLength);

            if (TextSpanHelper.IsEmpty(span) && span.iStartIndex == lineLength && span.iEndLine + 1 < lineCount) {
                // Make the span include the newline if it was empty and at the end of the line.
                span.iEndLine++;
                span.iEndIndex = 0;
            }
        }

        internal void ReportTasks(ArrayList errors) {
            TaskProvider taskProvider = this.GetTaskProvider();

            if (errors == null || errors.Count == 0) {
                if (taskProvider.Tasks.Count > 0) {
                    taskProvider.Tasks.Clear();
                }
                return;
            }
            int removed = 0;
            int added = 0;
            int merged = 0;
            int errorMax = this.service.Preferences.MaxErrorMessages;
            string fname = this.GetFilePath();
            RunningDocumentTable rdt = new RunningDocumentTable(this.service.Site);
            IVsHierarchy thisHeirarchy = rdt.GetHierarchyItem(fname);

            // Here we merge errors lists to reduce flicker.  It is not a very intelligent merge
            // but that is ok, the worst case is the task list flickers a bit.  But 99% of the time
            // one error is added or removed as the user is typing, and this merge will reduce flicker
            // in this case.
            errors = GroupBySeverity(errors);
            taskProvider.SuspendRefresh(); // batch updates.
            int pos = 0;
            TaskErrorCategory mostSevere = TaskErrorCategory.Message;

            for (int i = 0, n = errors.Count; i < n; i++) {
                ErrorNode enode = (ErrorNode)errors[i];
                string filename = enode.uri;
                bool thisFile = (!string.IsNullOrEmpty(filename) && NativeMethods.IsSamePath(fname, filename));

                TextSpan span = enode.context;
                Severity severity = enode.severity;
                string message = enode.message;
                if (message == null) continue;

                message = NormalizeString(message);
                // Don't do multi-line squiggles, instead just squiggle to the
                // end of the first line.
                if (span.iEndLine > span.iStartLine) {
                    span.iEndLine = span.iStartLine;
                    NativeMethods.ThrowOnFailure(this.textLines.GetLengthOfLine(span.iStartLine, out span.iEndIndex));
                }
                //normalize text span
                if (thisFile) {
                    FixupMarkerSpan(ref span);
                } else {
                    TextSpanHelper.MakePositive(ref span);
                }
                //set options
                TaskPriority priority = TaskPriority.Normal;
                TaskCategory category = TaskCategory.BuildCompile;
                MARKERTYPE markerType = MARKERTYPE.MARKER_CODESENSE_ERROR;
                TaskErrorCategory errorCategory = TaskErrorCategory.Warning;

                if (severity == Severity.Fatal || severity == Severity.Error) {
                    priority = TaskPriority.High;
                    errorCategory = TaskErrorCategory.Error;                    
                } else if (severity == Severity.Hint) {
                    category = TaskCategory.Comments;
                    markerType = MARKERTYPE.MARKER_INVISIBLE;
                    errorCategory = TaskErrorCategory.Message;
                } else if (severity == Severity.Warning) {
                    markerType = MARKERTYPE.MARKER_COMPILE_ERROR;
                    errorCategory = TaskErrorCategory.Warning;
                }
                if (errorCategory < mostSevere) {
                    mostSevere = errorCategory;
                }

                IVsHierarchy hierarchy = thisHeirarchy;
                if (!thisFile) {
                    // must be an error reference to another file.
                    hierarchy = rdt.GetHierarchyItem(filename);
                    markerType = MARKERTYPE.MARKER_OTHER_ERROR; // indicate to CreateErrorTaskItem
                }

                bool found = false;
                while (pos < taskProvider.Tasks.Count) {
                    Task current = taskProvider.Tasks[pos];
                    if (current is DocumentTask) {
                        DocumentTask dt = (DocumentTask)current;
                        if (dt.IsMarkerValid && // marker is still valid?
                            NativeMethods.IsSamePath(current.Document, filename) && 
                            current.Text == message && TextSpanHelper.IsSameSpan(span, dt.Span) && 
                            current.Category == category && 
                            current.Priority == priority && 
                            dt.ErrorCategory == errorCategory) {
                            pos++;
                            merged++;
                            found = true;
                            // Since we're reusing the existing entry, let's make sure the line
                            // line number we are displaying the right line number information.
                            // (The DocumentTask gets out of sync with the IVsTextLineMarker because
                            // the IVsTextLineMarker is a bookmark that tracks user edits). 
                            if (dt.Column != span.iStartIndex || dt.Line != span.iStartLine) {
                                dt.Column = span.iStartIndex;
                                dt.Line = span.iStartLine;
                                taskProvider.Refresh(); // mark it as dirty.
                            }
                            break;
                        }
                    }
                    removed++;
                    taskProvider.Tasks.RemoveAt(pos);
                }
                if (!found) {
                    added++;
                    DocumentTask docTask = this.CreateErrorTaskItem(span, filename, message, priority, category, markerType, errorCategory);
                    docTask.HierarchyItem = hierarchy;
                    taskProvider.Tasks.Insert(pos, docTask);
                    pos++;
                }
                //check error count
                if (pos == errorMax) {
                    string maxMsg = SR.GetString(SR.MaxErrorsReached);
                    string localFile = this.GetFilePath();
                    span = this.GetDocumentSpan();
                    span.iStartIndex = span.iEndIndex;
                    span.iStartLine = span.iEndLine;
                    DocumentTask error = this.CreateErrorTaskItem(span, localFile, maxMsg, TaskPriority.High, TaskCategory.CodeSense, MARKERTYPE.MARKER_INVISIBLE, mostSevere);
                    error.HierarchyItem = hierarchy;
                    taskProvider.Tasks.Insert(pos, error);
                    pos++;
                    break;
                }
            }
            // remove trailing errors that should no longer exist.
            while (pos < taskProvider.Tasks.Count) {
                removed++;
                taskProvider.Tasks.RemoveAt(pos);
            }
            taskProvider.ResumeRefresh(); // batch updates.
        }

        private static ArrayList GroupBySeverity(ArrayList errors) {
            // Sort the errors by severity so that if there's more than 'max' errors, then
            // the errors actually reported are the most severe.  I do not use ArrayList.Sort 
            // because that would lose the order inherent in each group of errors provided by 
            // the language service, which is most likely some sort of parse-order which will 
            // make more sense to the user.
            ArrayList result = new ArrayList();
            foreach (Severity s in new Severity[] { Severity.Fatal, Severity.Error, Severity.Warning, Severity.Hint }) {
                foreach (ErrorNode e in errors) {
                    if (e.severity == s) {
                        result.Add(e);
                    }
                }
            }
            return result;
        }

        /// <include file='doc\Source.uex' path='docs/doc[@for="Source.RemoveTask"]/*' />
        public void RemoveTask(DocumentTask task) {
            for (int i = 0, n = this.taskProvider.Tasks.Count; i < n; i++) {
                Task current = this.taskProvider.Tasks[i];
                if (current == task) {
                    this.taskProvider.Tasks.RemoveAt(i); return;
                }
            }
        }

        /// <include file='doc\Source.uex' path='docs/doc[@for="Source.RemoveHiddenRegions"]/*' />
        public virtual void RemoveHiddenRegions() {
            IVsHiddenTextSession session = GetHiddenTextSession();
            IVsEnumHiddenRegions ppenum;
            TextSpan[] aspan = new TextSpan[1];
            aspan[0] = GetDocumentSpan();
            NativeMethods.ThrowOnFailure(session.EnumHiddenRegions((uint)FIND_HIDDEN_REGION_FLAGS.FHR_BY_CLIENT_DATA, (uint)Source.HiddenRegionCookie, aspan, out ppenum));
            uint fetched;
            IVsHiddenRegion[] aregion = new IVsHiddenRegion[1];
            while (ppenum.Next(1, aregion, out fetched) == NativeMethods.S_OK && fetched == 1) {
                NativeMethods.ThrowOnFailure(aregion[0].Invalidate((int)CHANGE_HIDDEN_REGION_FLAGS.chrNonUndoable));
            }

        }

        internal void ToggleRegions() {
            IVsHiddenTextSession session = GetHiddenTextSession();
            IVsEnumHiddenRegions ppenum;
            TextSpan[] aspan = new TextSpan[1];
            aspan[0] = GetDocumentSpan();
            NativeMethods.ThrowOnFailure(session.EnumHiddenRegions((uint)FIND_HIDDEN_REGION_FLAGS.FHR_BY_CLIENT_DATA, (uint)Source.HiddenRegionCookie, aspan, out ppenum));
            uint fetched;
            IVsHiddenRegion[] aregion = new IVsHiddenRegion[1];
            using (new CompoundAction(this, "ToggleAllRegions")) {
                while (ppenum.Next(1, aregion, out fetched) == NativeMethods.S_OK && fetched == 1) {
                    uint dwState;
                    aregion[0].GetState(out dwState);
                    dwState ^= (uint)HIDDEN_REGION_STATE.hrsExpanded;
                    NativeMethods.ThrowOnFailure(aregion[0].SetState(dwState,
                        (uint)CHANGE_HIDDEN_REGION_FLAGS.chrDefault));
                }
            }
        }

        internal void DisableOutlining() {
            this.OutliningEnabled = false;
            this.RemoveHiddenRegions();
        }

        /// <include file='doc\Source.uex' path='docs/doc[@for="Source.ProcessHiddenRegions"]/*' />
        public virtual void ProcessHiddenRegions(ArrayList hiddenRegions) {
            this.hiddenRegions = hiddenRegions;

            if (!this.doOutlining) {
                return;
            }
            // Compare the existing regions with the new regions and 
            // remove any that do not match the new regions.
            IVsHiddenTextSession session = GetHiddenTextSession();
            IVsEnumHiddenRegions ppenum;
            TextSpan[] aspan = new TextSpan[1];
            aspan[0] = GetDocumentSpan();
            NativeMethods.ThrowOnFailure(session.EnumHiddenRegions((uint)FIND_HIDDEN_REGION_FLAGS.FHR_BY_CLIENT_DATA, (uint)Source.HiddenRegionCookie, aspan, out ppenum));
            uint fetched;
            IVsHiddenRegion[] aregion = new IVsHiddenRegion[1];
            int matched = 0;
            int removed = 0;
            int added = 0;
            int pos = 0;

            // Create a list of IVsHiddenRegion objects, sorted in the same order that the
            // authoring sink sorts.  This is necessary because VS core editor does NOT return
            // the regions in the same order that we add them.
            ArrayList regions = new ArrayList();
            ArrayList spans = new ArrayList();

            while (ppenum.Next(1, aregion, out fetched) == NativeMethods.S_OK && fetched == 1) {
                NativeMethods.ThrowOnFailure(aregion[0].GetSpan(aspan));
                TextSpan s = aspan[0];
                int i = spans.Count - 1;
                while (i >= 0) {
                    TextSpan s2 = (TextSpan)spans[i];
                    if (TextSpanHelper.StartsAfterStartOf(s, s2))
                        break;
                    i--;
                }
                spans.Insert(i + 1, s);
                regions.Insert(i + 1, aregion[0]);
            }

            // Now merge the list found with the list in the AuthoringSink to figure out
            // what matches, what needs to be removed, and what needs to be inserted.
            NewHiddenRegion r = pos < hiddenRegions.Count ? (NewHiddenRegion)hiddenRegions[pos] : new NewHiddenRegion();
            for (int i = 0, n = regions.Count; i < n; i++) {

                IVsHiddenRegion region = (IVsHiddenRegion)regions[i];
                TextSpan span = (TextSpan)spans[i];

                // In case we're inserting a new region, scan ahead to matching start line
                while (r.tsHiddenText.iStartLine < span.iStartLine) {
                    pos++;
                    if (pos >= hiddenRegions.Count) {
                        r = new NewHiddenRegion();
                        break;
                    } else {
                        r = (NewHiddenRegion)hiddenRegions[pos];
                    }
                }
                if (TextSpanHelper.IsSameSpan(r.tsHiddenText, span)) {
                    // This region is already there.
                    matched++;
                    hiddenRegions.RemoveAt(pos);
                    r = (pos < hiddenRegions.Count) ? (NewHiddenRegion)hiddenRegions[pos] : new NewHiddenRegion();
                } else {
                    removed++;
                    NativeMethods.ThrowOnFailure(region.Invalidate((int)CHANGE_HIDDEN_REGION_FLAGS.chrNonUndoable));
                }
            }

            int start = Environment.TickCount;
            if (hiddenRegions.Count > 0) {
                int count = hiddenRegions.Count;
                // For very large documents this can take a while, so add them in chunks of 
                // 1000 and stop after 5 seconds. 
                int maxTime = this.LanguageService.Preferences.MaxRegionTime;
                int chunkSize = 1000;
                NewHiddenRegion[] chunk = new NewHiddenRegion[chunkSize];
                int now = Environment.TickCount;
                int i = 0;
                while (i < count && start > now - maxTime) {
                    int j = 0;
                    while (i < count && j < chunkSize) {
                        r = (NewHiddenRegion)hiddenRegions[i];
                        if (!TextSpanHelper.ValidSpan(this, r.tsHiddenText)) {
#if	LANGTRACE
                            Debug.Assert(false, "Invalid span " + r.tsHiddenText.iStartLine + "," + r.tsHiddenText.iStartIndex + "," + r.tsHiddenText.iEndLine + "," + r.tsHiddenText.iEndIndex);
#endif
                            break;
                        } else {
                            chunk[j] = r;
                            added++;
                        }
                        i++;
                        j++;
                    }
                    int hr = session.AddHiddenRegions((int)CHANGE_HIDDEN_REGION_FLAGS.chrNonUndoable, j, chunk, null);
                    if (NativeMethods.Failed(hr)) {
                        break; // stop adding if we start getting errors.
                    }
                    now = Environment.TickCount;
                }
            }
            
#if	LANGTRACE
            int diff = Environment.TickCount - start;
            Trace.WriteLine(String.Format(CultureInfo.InvariantCulture, "Hidden Regions: Matched={0}, Removed={1}, Addded={2}/{3} in {4} ms", matched, removed, added, hiddenRegions.Count, diff));
#endif
            Marshal.ReleaseComObject(ppenum);
        }

        /// <include file='doc\Source.uex' path='docs/doc[@for="Source.GetHiddenTextSession"]/*' />
        public IVsHiddenTextSession GetHiddenTextSession() {
            if (this.hiddenTextSession == null) {
                IVsHiddenTextManager htextmgr = service.Site.GetService(typeof(SVsTextManager)) as IVsHiddenTextManager;
                if (htextmgr != null) {
                    IVsHiddenTextSession session = null;
                    int hr = htextmgr.GetHiddenTextSession(textLines, out session);
                    if (hr == NativeMethods.E_FAIL) {
                        // Then there was no hidden text session.
                        NativeMethods.ThrowOnFailure(htextmgr.CreateHiddenTextSession(0, textLines, this, out session));
                    }
                    this.hiddenTextSession = session;
                    Marshal.ReleaseComObject(htextmgr);
                }
            }
            return this.hiddenTextSession;
        }

        /// <include file='doc\Source.uex' path='docs/doc[@for="Source.OutliningEnabled"]/*' />
        public virtual bool OutliningEnabled {
            get {
                return this.doOutlining;
            }
            set {
                if (this.doOutlining != value) {
                    this.doOutlining = value;
                    if (value) {
                        this.IsDirty = true;
                        // force reparse as soon as possible.
                        this.dirtyTime = Math.Max(0, this.dirtyTime - this.service.Preferences.CodeSenseDelay);
                    }
                }
            }
        }

        #region IVsHiddenTextClient
        /// <include file='doc\Source.uex' path='docs/doc[@for="Source.OnHiddenRegionChange"]/*' />
        public virtual void OnHiddenRegionChange(IVsHiddenRegion region, HIDDEN_REGION_EVENT evt, int fBufferModifiable) {
        }

        /// <include file='doc\Source.uex' path='docs/doc[@for="Source.GetTipText"]/*' />
        public virtual int GetTipText(IVsHiddenRegion region, string[] result) {
            if (result != null && result.Length > 0) {
                TextSpan[] aspan = new TextSpan[1];
                NativeMethods.ThrowOnFailure(region.GetSpan(aspan));
                result[0] = this.GetText(aspan[0]);
            }
            return NativeMethods.S_OK;
        }

        /// <include file='doc\Source.uex' path='docs/doc[@for="Source.GetMarkerCommandInfo"]/*' />
        public virtual int GetMarkerCommandInfo(IVsHiddenRegion region, int item, string[] outText, uint[] flags) {
            if (flags != null && flags.Length > 0)
                flags[0] = 0;
            if (outText != null && outText.Length > 0)
                outText[0] = null;
            return NativeMethods.E_NOTIMPL;
        }

        /// <include file='doc\Source.uex' path='docs/doc[@for="Source.ExecMarkerCommand"]/*' />
        public virtual int ExecMarkerCommand(IVsHiddenRegion region, int cmd) {
            return NativeMethods.E_NOTIMPL;
        }

        /// <include file='doc\Source.uex' path='docs/doc[@for="Source.MakeBaseSpanVisible"]/*' />
        public virtual int MakeBaseSpanVisible(IVsHiddenRegion region, TextSpan[] span) {
            return NativeMethods.E_NOTIMPL;
        }

        /// <include file='doc\Source.uex' path='docs/doc[@for="Source.OnBeforeSessionEnd"]/*' />
        public virtual void OnBeforeSessionEnd() {
        }
        #endregion

        #region IVsUserDataEvents Members

        /// <include file='doc\Source.uex' path='docs/doc[@for="Source.OnUserDataChange"]/*' />
        public virtual void OnUserDataChange(ref Guid riidKey, object vtNewValue) {
        }

        #endregion

    }

    // This class gathers pseudo-keystrokes and applies the cumulative changes to the IVsTextLines buffer.
    // and also records them in case macro recording is on.  It also wraps the edits in 
    // an IVsCompoundAction.
    /// <include file='doc\Source.uex' path='docs/doc[@for="Completor"]/*' />
    [CLSCompliant(false)]
    public class Completor : IDisposable {
        internal LanguageService langsvc;
        internal IVsTextView view;
        internal Source src;
        internal StringBuilder sb;
        internal int caret;
        internal int lineLength;
        internal TextSpan span;
        internal IVsTextMacroHelper macro;
        internal string line;
        internal CompoundAction ca;

        /// <include file='doc\Source.uex' path='docs/doc[@for="Completor.Completor"]/*' />
        public Completor(LanguageService langsvc, IVsTextView view, string description) {
            this.langsvc = langsvc;
            this.view = view;
            this.src = langsvc.GetSource(view);
            this.sb = new StringBuilder();
            this.caret = 0; // current position within StringBuilder.

            this.ca = new CompoundAction(src, description);
            this.ca.FlushEditActions(); // make sure we see a consistent coordinate system.

            // initialize span representing what we are removing from the buffer.
            NativeMethods.ThrowOnFailure(view.GetCaretPos(out span.iStartLine, out span.iStartIndex));
            this.span.iEndLine = span.iStartLine;
            this.span.iEndIndex = span.iStartIndex;
            RefreshLine();

            macro = this.langsvc.GetIVsTextMacroHelperIfRecordingOn();
        }

        /// <include file='doc\Source.uex' path='docs/doc[@for="Completor.IsExpansionActive"]/*' />
        public bool IsExpansionActive {
            get {
                ExpansionProvider ep = src.GetExpansionProvider();
                return (ep != null && ep.InTemplateEditingMode);
            }
        }

        /// <include file='doc\Source.uex' path='docs/doc[@for="Completor.RefreshLine"]/*' />
        public void RefreshLine() {
            this.line = this.src.GetLine(span.iStartLine);
            this.lineLength = src.GetLineLength(span.iStartLine);
        }

        /// <include file='doc\Source.uex' path='docs/doc[@for="Completor.Dispose"]/*' />
        /// <summary>This method calls Apply() if you have not already done it.</summary>
        public void Dispose() {
            if (this.ca != null) {
                Apply();
            }
            // DO NOT DISPOSE THE LANGUAGE SERVICE HERE -- WE DON'T OWN IT!!!
            this.langsvc = null;
            this.macro = null;
            this.view = null;
        }

        /// <include file='doc\Source.uex' path='docs/doc[@for="Completor.Apply"]/*' />
        public void Apply() {
            string text = sb.ToString();
            NativeMethods.ThrowOnFailure(view.ReplaceTextOnLine(span.iStartLine, span.iStartIndex, span.iEndIndex - span.iStartIndex, text, text.Length));
            this.ca.Close(); // make sure we see a consistent coordinate system.
            this.ca = null;
            // move caret position
            // todo: what if a newline was typed (e.g. an attribute value enumeration contains a new line) ??
            NativeMethods.ThrowOnFailure(view.SetCaretPos(span.iStartLine, span.iStartIndex + caret));
        }

        /// <include file='doc\Source.uex' path='docs/doc[@for="Completor.TypeChar"]/*' />
        public void TypeChar(char ch) {
            if (caret >= sb.Length) {
                sb.Append(ch);
            } else {
                sb.Insert(caret, ch);
            }
            caret++;

            // record caret movement for correct macro handling.
            if (macro != null) {
                ushort u = Convert.ToUInt16(ch);
                macro.RecordTypeChar(u, 0);
            }
        }

        /// <include file='doc\Source.uex' path='docs/doc[@for="Completor.TypeChars"]/*' />
        public void TypeChars(string s) {
            if (caret >= sb.Length) {
                sb.Append(s);
            } else {
                sb.Insert(caret, s);
            }
            caret += s.Length;

            if (macro != null) {
                macro.RecordTypeChars(s, 0);
            }
        }

        /// <include file='doc\Source.uex' path='docs/doc[@for="Completor.TypeLeft"]/*' />
        public void TypeLeft(int len) {
            int i = span.iStartIndex + caret - len;
            Debug.Assert(i >= 0 && i <= this.lineLength + sb.Length); // must still be on the current line.
            if (i < 0) len = span.iStartIndex + caret; // pin 

            if (this.caret < len) {
                if (sb.Length == 0) {
                    // In this case we can just move our span window to the left.
                    span.iStartIndex -= len;
                    span.iEndIndex -= len;
                } else {
                    // We need to expand our buffer to the left to include what is on the line
                    // so that our Apply() method can put that text back correctly (since this
                    // class currently only supports one overall edit on the line.
                    // todo: add support for the recording multiple discontiguous edits.
                    int diff = len - this.caret;
                    this.sb.Insert(0, line.Substring(span.iStartIndex - diff, diff));
                    span.iStartIndex -= diff;
                    this.caret = 0;
                }
            } else {
                this.caret -= len;
            }
            if (macro != null) {
                while (len-- > 0) {
                    macro.RecordMoveSelectionRel(MOVESELECTION_REL_TYPE.MOVESELECTION_REL_CHARACTER, 1, 0);
                }
            }
        }

        /// <include file='doc\Source.uex' path='docs/doc[@for="Completor.AtEndOfLine"]/*' />
        public bool AtEndOfLine {
            get { return span.iStartIndex + caret == sb.Length + this.lineLength; }
        }

        /// <include file='doc\Source.uex' path='docs/doc[@for="Completor.TypeRight"]/*' />
        public void TypeRight(int len) {
            int i = span.iStartIndex + caret + len;
            int length = sb.Length + this.lineLength;
            Debug.Assert(i <= length); // must still be on the current line.
            if (i > length) len = length - (span.iStartIndex + caret); // pin 
            if (len <= 0) return; // NOP

            if (this.caret + len > sb.Length) {
                if (sb.Length == 0) {
                    // In this case we can just move our span window to the right.
                    span.iStartIndex += len;
                    span.iEndIndex += len;
                } else {
                    // Need to expand out StringBuilder with text to the right of the current position.
                    int diff = (this.caret + len) - sb.Length;
                    sb.Append(line.Substring(span.iStartIndex, diff));
                    span.iEndIndex += diff;
                    this.caret = sb.Length;
                }
            } else {
                this.caret += len;
            }
            if (macro != null) {
                while (len-- > 0) {
                    macro.RecordMoveSelectionRel(MOVESELECTION_REL_TYPE.MOVESELECTION_REL_CHARACTER, 0, 0);
                }
            }
        }

        /// <include file='doc\Source.uex' path='docs/doc[@for="Completor.TypeBackspace"]/*' />
        public void TypeBackspace(int len) {
            int i = span.iStartIndex + caret - len;
            Debug.Assert(i >= 0); // must still be on the current line.
            if (i < 0) len = span.iStartIndex + caret; // pin

            caret -= len;
            if (caret < 0) {
                // replace chars in the buffer 
                Debug.Assert(span.iStartIndex > -caret);
                span.iStartIndex += caret;
                caret = 0;
            }

            if (macro != null) {
                macro.RecordDelete(1, (uint)len);
            }
        }

        /// <include file='doc\Source.uex' path='docs/doc[@for="Completor.TypeDelete"]/*' />
        public void TypeDelete(int len) {
            if (caret < sb.Length) {
                int delta = sb.Length - caret;
                len -= delta;
                sb.Remove(caret, delta);
            }
            if (len > 0) {
                // replace chars in the buffer 
                Debug.Assert(span.iEndIndex + len <= this.lineLength);
                if (span.iEndIndex + len > this.lineLength) {
                    len = this.lineLength - span.iEndIndex; // pin.
                }
                span.iEndIndex += len;
            }

            if (macro != null) {
                macro.RecordDelete(0, (uint)len);
            }
        }
    }

    /// <include file='doc\Source.uex' path='docs/doc[@for="CompoundAction"]/*' />
    /// <summary>
    /// This class can be used in a using statement to open and close a compound edit action
    /// via IVsCompoundAction interface.  Be sure to call Close() at the end of your using
    /// statement, otherwise Dispose will call Abort.
    /// </summary>
    [CLSCompliant(false)]
    public class CompoundAction : IDisposable {
        IVsCompoundAction action;
        bool opened;
        Source src;
        Colorizer colorizer;

        /// <include file='doc\Source.uex' path='docs/doc[@for="CompoundAction.CompoundAction2"]/*' />
        public CompoundAction(Source src, string description) {
            this.opened = false;
            this.src = src;
            this.action = (IVsCompoundAction)src.GetTextLines();
            if (this.action == null) {
                throw new ArgumentNullException("(IVsCompoundAction)src.GetTextLines()");
            }
            NativeMethods.ThrowOnFailure(action.OpenCompoundAction(description));
            this.opened = true;
            this.colorizer = src.GetColorizer();
            if (colorizer != null) colorizer.Suspend(); // batch colorization            
        }

        /// <include file='doc\Source.uex' path='docs/doc[@for="CompoundAction.FlushEditActions"]/*' />
        public void FlushEditActions() {
            // in case there is already a compound action under way, this enables the caller
            // to see a consistent buffer coordinate system.
            action.FlushEditActions(); // sometimes returns E_NOTIMPL and this is expected!            
        }

        /// <include file='doc\Source.uex' path='docs/doc[@for="CompoundAction.Dispose"]/*' />
        public void Dispose() {
            Close();
        }

        /// <include file='doc\Source.uex' path='docs/doc[@for="CompoundAction.Close"]/*' />
        public void Close() {
            if (opened && action != null) {
                action.CloseCompoundAction();
                action = null;
                opened = false;
                ResumeColorization();
            }
        }
        /// <include file='doc\Source.uex' path='docs/doc[@for="CompoundAction.Abort"]/*' />
        public void Abort() {
            if (opened && action != null) {
                action.AbortCompoundAction();
                action = null;
                opened = false;
                ResumeColorization(); // batch colorization
            }
        }

        void ResumeColorization() {
            if (colorizer != null) {
                colorizer.Resume(); // batch colorization
                TextSpan span = src.DirtySpan;
                int start = span.iStartLine;
                int end = span.iEndLine;
                src.Recolorize(start, end);
                colorizer = null;
            }
        }
    }

    /// <include file='doc\Source.uex' path='docs/doc[@for="CompoundAction"]/*' />
    /// <summary>
    /// This class can be used in a using statement to open and close a compound edit action
    /// via IVsCompoundAction interface from an IVsTextView.  This allows the view to optimize 
    /// it's updates based on edits you are making on the buffer, so it's the preferred way of
    /// doing things if you have access to the IVsTextView.  If not, use CompoundAction.
    /// </summary>
    [CLSCompliant(false)]
    public class CompoundViewAction : IDisposable {
        IVsCompoundAction action;
        bool opened;
        /// <include file='doc\Source.uex' path='docs/doc[@for="CompoundViewAction.CompoundViewAction"]/*' />
        public CompoundViewAction(IVsTextView view, string description) {
            opened = false;
            action = (IVsCompoundAction)view;
            if (this.action == null) {
                throw new ArgumentNullException("(IVsCompoundAction)view");
            }
            NativeMethods.ThrowOnFailure(action.OpenCompoundAction(description));
            opened = true;
        }

        /// <include file='doc\Source.uex' path='docs/doc[@for="CompoundViewAction.FlushEditActions"]/*' />
        public void FlushEditActions() {
            // in case there is already a compound action under way, this enables the caller
            // to see a consistent buffer coordinate system.
            action.FlushEditActions(); // sometimes returns E_NOTIMPL and this is expected!            
        }

        /// <include file='doc\Source.uex' path='docs/doc[@for="CompoundViewAction.Dispose"]/*' />
        /// <summary>This method calls Close if you have not already called Close</summary>
        public void Dispose() {
            Close();
        }
        /// <include file='doc\Source.uex' path='docs/doc[@for="CompoundViewAction.Close"]/*' />
        public void Close() {
            if (opened && action != null) {
                action.CloseCompoundAction();
                action = null;
                opened = false;
            }
        }
        /// <include file='doc\Source.uex' path='docs/doc[@for="CompoundViewAction.Abort"]/*' />
        public void Abort() {
            if (opened && action != null) {
                action.AbortCompoundAction();
                action = null;
                opened = false;
            }
        }
    }


    //==================================================================================
    /// <include file='doc\Source.uex' path='docs/doc[@for="CompletionSet"]/*' />
    [CLSCompliant(false)]
    public class CompletionSet : IVsCompletionSet, IVsCompletionSetEx, IDisposable {
        ImageList imageList;
        bool displayed;
        bool completeWord;
        string committedWord;
        char commitChar;
        int commitIndex;
        IVsTextView textView;
        Declarations decls;
        Source source;
        TextSpan initialExtent;
        bool isCommitted;
        bool wasUnique;

        /// <include file='doc\Source.uex' path='docs/doc[@for="CompletionSet.CompletionSet"]/*' />
        public CompletionSet(ImageList imageList, Source source) {
            this.imageList = imageList;
            this.source = source;
        }

        /// <include file='doc\Source.uex' path='docs/doc[@for="CompletionSet.IsDisplayed"]/*' />
        public bool IsDisplayed {
            get {
                return this.displayed;
            }
        }

        /// <include file='doc\Source.uex' path='docs/doc[@for="CompletionSet.IsCommitted"]/*' />
        public bool IsCommitted {
            get {
                return this.isCommitted;
            }
        }

        /// <include file='doc\Source.uex' path='docs/doc[@for="CompletionSet.OnCommitText"]/*' />
        public string OnCommitText {
            get {
                return this.committedWord;
            }
        }
        /// <include file='doc\Source.uex' path='docs/doc[@for="CompletionSet.Init"]/*' />
        public virtual void Init(IVsTextView textView, Declarations declarations, bool completeWord) {
            Close();
            this.textView = textView;
            this.Declarations = declarations;
            this.completeWord = completeWord;

            //check if we have members
            long count = decls.GetCount();
            if (count <= 0) return;

            //initialise and refresh      
            UpdateCompletionFlags flags = UpdateCompletionFlags.UCS_NAMESCHANGED;

            if (this.completeWord) flags |= UpdateCompletionFlags.UCS_COMPLETEWORD;

            this.wasUnique = false;

            int hr = textView.UpdateCompletionStatus(this, (uint)flags);
            NativeMethods.ThrowOnFailure(hr);

            this.displayed = (!this.wasUnique || !completeWord);
        }

        /// <include file='doc\Source.uex' path='docs/doc[@for="CompletionSet.Dispose"]/*' />
        public virtual void Dispose() {
            Close();
            if (imageList != null) imageList.Dispose();
            this.imageList = null;
        }

        /// <include file='doc\Source.uex' path='docs/doc[@for="CompletionSet.Close"]/*' />
        public virtual void Close() {
            if (this.displayed && this.textView != null) {
                // Here we can't throw or exit because we need to call Dispose on
                // the disposable membres.
                try {
                    textView.UpdateCompletionStatus(null, 0);
                } catch (COMException) {
                }
            }
            this.displayed = false;
            this.textView = null;
            this.Declarations = null;
        }

        /// <include file='doc\Source.uex' path='docs/doc[@for="CompletionSet.Declarations"]/*' />
        public Declarations Declarations {
            get { return this.decls; }
            set {
                if (this.decls != null && this.decls != value) {
                    this.decls.Dispose();
                }
                this.decls = value;
            }
        }

        /// <include file='doc\Source.uex' path='docs/doc[@for="CompletionSet.OnAutoComplete"]/*' />
        public virtual char OnAutoComplete() {
            this.isCommitted = false;
            if (this.decls != null) {
                return this.decls.OnAutoComplete(this.textView, this.committedWord, this.commitChar, this.commitIndex);
            }
            return '\0';
        }

        #region IVsCompletionSet
        //--------------------------------------------------------------------------
        //IVsCompletionSet methods
        //--------------------------------------------------------------------------
        /// <include file='doc\Source.uex' path='docs/doc[@for="CompletionSet.GetImageList"]/*' />
        public virtual int GetImageList(out IntPtr phImages) {
            phImages = this.imageList.Handle;
            return NativeMethods.S_OK;
        }

        /// <include file='doc\Source.uex' path='docs/doc[@for="CompletionSet.GetFlags"]/*' />
        public virtual uint GetFlags() {
            return (uint)UpdateCompletionFlags.CSF_HAVEDESCRIPTIONS | (uint)UpdateCompletionFlags.CSF_CUSTOMCOMMIT | (uint)UpdateCompletionFlags.CSF_INITIALEXTENTKNOWN | (uint)UpdateCompletionFlags.CSF_CUSTOMMATCHING;
        }

        /// <include file='doc\Source.uex' path='docs/doc[@for="CompletionSet.GetCount"]/*' />
        public virtual int GetCount() {
            return this.decls.GetCount();
        }

        /// <include file='doc\Source.uex' path='docs/doc[@for="CompletionSet.GetDisplayText"]/*' />
        public int GetDisplayText(int index, out string text, int[] glyph) {
            if (glyph != null) {
                glyph[0] = this.decls.GetGlyph(index);
            }
            text = this.decls.GetDisplayText(index);
            return NativeMethods.S_OK;
        }

        /// <include file='doc\Source.uex' path='docs/doc[@for="CompletionSet.GetDescriptionText"]/*' />
        public int GetDescriptionText(int index, out string description) {
            description = this.decls.GetDescription(index);
            return NativeMethods.S_OK;
        }

        /// <include file='doc\Source.uex' path='docs/doc[@for="CompletionSet.GetInitialExtent"]/*' />
        public virtual int GetInitialExtent(out int line, out int startIdx, out int endIdx) {

            int hr = NativeMethods.S_OK;
            if (this.decls.GetInitialExtent(this.textView, out line, out startIdx, out endIdx)) {
                goto done;
            }

            int idx;
            this.initialExtent = new TextSpan();

            NativeMethods.ThrowOnFailure(this.textView.GetCaretPos(out line, out idx));
#if	TRACE_PARSING
            Trace.WriteLine("GetInitialExtent at " + line + "," + idx);
#endif
            hr = GetTokenExtent(line, idx, out startIdx, out endIdx);

        done:
            // Remember the initial extent so we can pass it along on the commit.
            this.initialExtent.iStartLine = this.initialExtent.iEndLine = line;
            this.initialExtent.iStartIndex = startIdx;
            this.initialExtent.iEndIndex = endIdx;

            Debug.Assert(TextSpanHelper.ValidCoord(this.source, line, startIdx) &&
                TextSpanHelper.ValidCoord(this.source, line, endIdx));
            return hr;
        }

        int GetTokenExtent(int line, int idx, out int startIdx, out int endIdx) {
            int hr = VSConstants.S_OK;
            bool rc = this.source.GetWordExtent(line, idx, Source.WholeToken, out startIdx, out endIdx);
            // make sure the span is positive.
            endIdx = Math.Max(startIdx, endIdx);

            if (!rc && idx > 0) {
                rc = this.source.GetWordExtent(line, idx - 1, Source.WholeToken, out startIdx, out endIdx);
                if (!rc) {
                    // Must stop core text editor from looking at startIdx and endIdx since they are likely
                    // invalid.  So we must return a real failure here, not just S_FALSE.
                    startIdx = endIdx = idx;
                    hr = VSConstants.E_NOTIMPL;
                } else {
                    endIdx = Math.Max(endIdx, idx);
                }
            }
            return hr;
        }

        /// <include file='doc\Source.uex' path='docs/doc[@for="CompletionSet.GetBestMatch"]/*' />
        public virtual int GetBestMatch(string textSoFar, int length, out int index, out uint flags) {
            flags = 0;
            index = 0;
#if	TRACE_PARSING
            Trace.WriteLine("GetBestMatch '" + textSoFar + "'");
#endif

            bool uniqueMatch = false;
            if (textSoFar.Length != 0) {
                this.decls.GetBestMatch(textSoFar, out index, out uniqueMatch);
                if (index < 0 || index >= GetCount()) {
                    index = 0;
                    uniqueMatch = false;
                } else {
                    // Indicate that we want to select something in the list.
                    flags = (uint)UpdateCompletionFlags.GBM_SELECT;
                }
            } else if (GetCount() == 1 && this.completeWord) {
                // Only one entry, and user has invoked "word completion", then
                // simply select this item.
                index = 0;
                flags = (uint)UpdateCompletionFlags.GBM_SELECT;
                uniqueMatch = true;
            }
            if (uniqueMatch) {
                flags |= (uint)UpdateCompletionFlags.GBM_UNIQUE;
                this.wasUnique = true;
            }
            return NativeMethods.S_OK;
        }

        /// <include file='doc\Source.uex' path='docs/doc[@for="CompletionSet.OnCommit"]/*' />
        public virtual int OnCommit(string textSoFar, int index, int selected, ushort commitChar, out string completeWord) {
            char ch = (char)commitChar;
            bool isCommitChar = true;
#if	TRACE_PARSING
            Trace.WriteLine("OnCommit '" + textSoFar + "'," + index + "," + selected + "," + commitChar.ToString(CultureInfo.CurrentUICulture));
#endif
            if (commitChar != 0) {
                // if the char is in the list of given member names then obviously it
                // is not a commit char.
                int i = (textSoFar == null) ? 0 : textSoFar.Length;
                for (int j = 0, n = decls.GetCount(); j < n; j++) {
                    string name = decls.GetName(j);
                    if (name.Length > i && name[i] == commitChar) {
                        if (i == 0 || String.Compare(name.Substring(0, i), textSoFar, true, CultureInfo.CurrentUICulture) == 0) {
                            goto nocommit; // cannot be a commit char if it is an expected char in a matching name
                        }
                    }
                }
                isCommitChar = this.decls.IsCommitChar(textSoFar, (selected == 0) ? -1 : index, ch);
            }

            completeWord = textSoFar;
            if (isCommitChar) {
                if (selected == 0) index = -1;
                this.committedWord = completeWord = this.decls.OnCommit(this.textView, textSoFar, ch, index, ref this.initialExtent);
                this.commitChar = ch;
                this.commitIndex = index;
                this.isCommitted = true;
                return NativeMethods.S_OK;
            }
        nocommit:
            // S_FALSE return means the character is not a commit character.
            completeWord = textSoFar;
            return NativeMethods.S_FALSE;
        }

        /// <include file='doc\Source.uex' path='docs/doc[@for="CompletionSet.Dismiss"]/*' />
        public virtual void Dismiss() {
            this.displayed = false;
        }
        #endregion

        #region IVsCompletionSetEx Members

        public virtual int CompareItems(string bstrSoFar, string bstrOther, int lCharactersToCompare, out int plResult) {
            plResult = 0;
            return NativeMethods.E_NOTIMPL;
        }

        public virtual int IncreaseFilterLevel(int iSelectedItem) {
            return NativeMethods.E_NOTIMPL;
        }

        public virtual int DecreaseFilterLevel(int iSelectedItem) {
            return NativeMethods.E_NOTIMPL;
        }

        public virtual int GetCompletionItemColor(int iIndex, out uint dwFGColor, out uint dwBGColor) {
            dwFGColor = dwBGColor = 0;
            return NativeMethods.E_NOTIMPL;
        }

        public virtual int GetFilterLevel(out int iFilterLevel) {
            iFilterLevel = 0;
            return NativeMethods.E_NOTIMPL;
        }

        public virtual int OnCommitComplete() {
            CodeWindowManager mgr = this.source.LanguageService.GetCodeWindowManagerForView(this.textView);
            if (mgr != null) {
                ViewFilter filter = mgr.GetFilter(this.textView);
                if (filter != null) {
                    filter.OnAutoComplete();
                }
            }
            return NativeMethods.S_OK;
        }

        #endregion
    }

    //-------------------------------------------------------------------------------------
    /// <include file='doc\Source.uex' path='docs/doc[@for="MethodData"]/*' />
    [CLSCompliant(false)]
    public class MethodData : IVsMethodData, IDisposable {
        IServiceProvider provider;
        IVsMethodTipWindow methodTipWindow;
        Methods methods;
        int currentParameter;
        int currentMethod;
        bool displayed;
        IVsTextView textView;
        TextSpan context;

        /// <include file='doc\Source.uex' path='docs/doc[@for="MethodData.MethodData"]/*' />
        public MethodData(IServiceProvider site) {
            this.provider = site;
            Microsoft.VisualStudio.Shell.Package pkg = (Microsoft.VisualStudio.Shell.Package)site.GetService(typeof(Microsoft.VisualStudio.Shell.Package));
            if (pkg == null) {
                throw new NullReferenceException(typeof(Microsoft.VisualStudio.Shell.Package).FullName);
            }
            Guid riid = typeof(IVsMethodTipWindow).GUID;
            Guid clsid = typeof(VsMethodTipWindowClass).GUID;
            this.methodTipWindow = (IVsMethodTipWindow)pkg.CreateInstance(ref clsid, ref riid, typeof(IVsMethodTipWindow));
            if (this.methodTipWindow != null) {
                NativeMethods.ThrowOnFailure(methodTipWindow.SetMethodData(this));
            }
        }
        /// <include file='doc\Source.uex' path='docs/doc[@for="MethodData.Provider;"]/*' />
        protected IServiceProvider Provider {
            get { return this.provider; }
            set { this.provider = value; }
        }
        /// <include file='doc\Source.uex' path='docs/doc[@for="MethodData.MethodTipWindow;"]/*' />
        protected IVsMethodTipWindow MethodTipWindow {
            get { return this.methodTipWindow; }
            set { this.methodTipWindow = value; }
        }
        /// <include file='doc\Source.uex' path='docs/doc[@for="MethodData.Methods;"]/*' />
        protected Methods Methods {
            get { return this.methods; }
            set { this.methods = value; }
        }
        /// <include file='doc\Source.uex' path='docs/doc[@for="MethodData.TextView;"]/*' />
        protected IVsTextView TextView {
            get { return this.textView; }
            set { this.textView = value; }
        }

        /// <include file='doc\Source.uex' path='docs/doc[@for="MethodData.IsDisplayed"]/*' />
        public bool IsDisplayed {
            get {
                return this.displayed;
            }
        }

        /// <include file='doc\Source.uex' path='docs/doc[@for="MethodData.Refresh"]/*' />
        public void Refresh(IVsTextView textView, Methods methods, int currentParameter, TextSpan context) {
            if (!this.displayed) {
                this.currentMethod = methods.DefaultMethod;
            }
            this.methods = methods;
            this.context = context;

            // Apparently this Refresh() method is called as a result of event notification
            // after the currentMethod is changed, so we do not want to Dismiss anything or
            // reset the currentMethod here. 
            //Dismiss();  
            this.textView = textView;
            this.methods = methods;

            this.currentParameter = currentParameter;
            this.AdjustCurrentParameter(0);
        }

        /// <include file='doc\Source.uex' path='docs/doc[@for="MethodData.AdjustCurrentParameter"]/*' />
        public void AdjustCurrentParameter(int increment) {
            this.currentParameter += increment;
            if (this.currentParameter < 0)
                this.currentParameter = -1;
            else if (this.currentParameter >= this.GetParameterCount(this.currentMethod))
                this.currentParameter = this.GetParameterCount(this.currentMethod);

            this.UpdateView();
        }

        /// <include file='doc\Source.uex' path='docs/doc[@for="MethodData.Close"]/*' />
        public void Close() {
            this.Dismiss();
            this.textView = null;
            this.methods = null;
        }

        /// <include file='doc\Source.uex' path='docs/doc[@for="MethodData.Dismiss"]/*' />
        public void Dismiss() {
            if (this.displayed && this.textView != null) {
                NativeMethods.ThrowOnFailure(this.textView.UpdateTipWindow(this.methodTipWindow, (uint)TipWindowFlags.UTW_DISMISS));
            }

            this.OnDismiss();
        }

        /// <include file='doc\Source.uex' path='docs/doc[@for="MethodData.Dispose"]/*' />
        public virtual void Dispose() {
            Close();
            if (this.methodTipWindow != null)
                NativeMethods.ThrowOnFailure(this.methodTipWindow.SetMethodData(null));
            this.methodTipWindow = null;
            this.provider = null;
        }

        //========================================================================
        //IVsMethodData
        /// <include file='doc\Source.uex' path='docs/doc[@for="MethodData.GetOverloadCount"]/*' />
        public int GetOverloadCount() {
            if (this.textView == null || this.methods == null) return 0;
            return this.methods.GetCount();
        }

        /// <include file='doc\Source.uex' path='docs/doc[@for="MethodData.GetCurMethod"]/*' />
        public int GetCurMethod() {
            return this.currentMethod;
        }

        /// <include file='doc\Source.uex' path='docs/doc[@for="MethodData.NextMethod"]/*' />
        public int NextMethod() {
            if (this.currentMethod < GetOverloadCount() - 1) this.currentMethod++;

            return this.currentMethod;
        }

        /// <include file='doc\Source.uex' path='docs/doc[@for="MethodData.PrevMethod"]/*' />
        public int PrevMethod() {
            if (this.currentMethod > 0) this.currentMethod--;

            return this.currentMethod;
        }

        /// <include file='doc\Source.uex' path='docs/doc[@for="MethodData.GetParameterCount"]/*' />
        public int GetParameterCount(int method) {
            if (this.methods == null) return 0;

            if (method < 0 || method >= GetOverloadCount()) return 0;

            return this.methods.GetParameterCount(method);
        }

        /// <include file='doc\Source.uex' path='docs/doc[@for="MethodData.GetCurrentParameter"]/*' />
        public int GetCurrentParameter(int method) {
            return this.currentParameter;
        }

        /// <include file='doc\Source.uex' path='docs/doc[@for="MethodData.OnDismiss"]/*' />
        public void OnDismiss() {
            this.textView = null;
            this.methods = null;
            this.currentMethod = 0;
            this.currentParameter = 0;
            this.displayed = false;
        }

        /// <include file='doc\Source.uex' path='docs/doc[@for="MethodData.UpdateView"]/*' />
        public void UpdateView() {
            if (this.textView != null) {
                NativeMethods.ThrowOnFailure(this.textView.UpdateTipWindow(this.methodTipWindow, (uint)TipWindowFlags.UTW_CONTENTCHANGED | (uint)TipWindowFlags.UTW_CONTEXTCHANGED));
                this.displayed = true;
            }
        }

        /// <include file='doc\Source.uex' path='docs/doc[@for="MethodData.GetContextStream"]/*' />
        public int GetContextStream(out int pos, out int length) {
            pos = 0;
            length = 0;
            int line, idx;
            NativeMethods.ThrowOnFailure(this.textView.GetCaretPos(out line, out idx));
            line = Math.Max(line, this.context.iStartLine);
            int vspace;
            NativeMethods.ThrowOnFailure(this.textView.GetNearestPosition(line, this.context.iStartIndex, out pos, out vspace));
            line = Math.Max(line, this.context.iEndLine);
            int endpos;
            NativeMethods.ThrowOnFailure(this.textView.GetNearestPosition(line, this.context.iEndIndex, out endpos, out vspace));
            length = endpos - pos;
            return NativeMethods.S_OK;
        }

        /// <include file='doc\Source.uex' path='docs/doc[@for="MethodData.GetMethodText"]/*' />
        public IntPtr GetMethodText(int method, MethodTextType type) {
            if (this.methods == null) return IntPtr.Zero;

            if (method < 0 || method >= GetOverloadCount()) return IntPtr.Zero;

            string result = null;

            //a type
            if ((type == MethodTextType.MTT_TYPEPREFIX && this.methods.TypePrefixed) ||
                (type == MethodTextType.MTT_TYPEPOSTFIX && !this.methods.TypePrefixed)) {
                string str = this.methods.GetType(method);

                if (str == null) return IntPtr.Zero;

                result = this.methods.TypePrefix + str + this.methods.TypePostfix;
            } else {
                //other
                switch (type) {
                case MethodTextType.MTT_OPENBRACKET:
                result = this.methods.OpenBracket;
                break;

                case MethodTextType.MTT_CLOSEBRACKET:
                result = this.methods.CloseBracket;
                break;

                case MethodTextType.MTT_DELIMITER:
                result = this.methods.Delimiter;
                break;

                case MethodTextType.MTT_NAME:
                result = this.methods.GetName(method);
                break;

                case MethodTextType.MTT_DESCRIPTION:
                result = this.methods.GetDescription(method);
                break;

                case MethodTextType.MTT_TYPEPREFIX:
                case MethodTextType.MTT_TYPEPOSTFIX:
                default:
                break;
                }
            }

            return result == null ? IntPtr.Zero : Marshal.StringToBSTR(result);
        }

        /// <include file='doc\Source.uex' path='docs/doc[@for="MethodData.GetParameterText"]/*' />
        public IntPtr GetParameterText(int method, int parameter, ParameterTextType type) {
            if (this.methods == null) return IntPtr.Zero;

            if (method < 0 || method >= GetOverloadCount()) return IntPtr.Zero;

            if (parameter < 0 || parameter >= GetParameterCount(method)) return IntPtr.Zero;

            string name;
            string description;
            string display;

            this.methods.GetParameterInfo(method, parameter, out name, out display, out description);

            string result = null;

            switch (type) {
            case ParameterTextType.PTT_NAME:
            result = name;
            break;

            case ParameterTextType.PTT_DESCRIPTION:
            result = description;
            break;

            case ParameterTextType.PTT_DECLARATION:
            result = display;
            break;

            default:
            break;
            }
            return result == null ? IntPtr.Zero : Marshal.StringToBSTR(result);
        }
    }
}