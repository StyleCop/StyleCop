using Microsoft.VisualStudio.Package;
using Microsoft.VisualStudio.OLE.Interop;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.TextManager.Interop;
using Microsoft.VisualStudio.Shell;
using Microsoft.Win32;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using System.Security.Permissions;
using IOleServiceProvider = Microsoft.VisualStudio.OLE.Interop.IServiceProvider;
using IServiceProvider = System.IServiceProvider;
using ShellConstants = Microsoft.VisualStudio.Shell.Interop.Constants;
using OleConstants = Microsoft.VisualStudio.OLE.Interop.Constants;
using VsShell = Microsoft.VisualStudio.Shell.VsShellUtilities;


namespace Microsoft.VisualStudio.Package {
    /// <include file='doc\LanguageService.uex' path='docs/doc[@for="ParseReason"]/*' />
    public enum ParseReason {
        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="ParseReason.None"]/*' />
        None,
        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="ParseReason.MemberSelect"]/*' />
        MemberSelect,
        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="ParseReason.HighlightBraces"]/*' />
        HighlightBraces,
        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="ParseReason.MemberSelectAndHighlightBraces"]/*' />
        MemberSelectAndHighlightBraces,
        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="ParseReason.MatchBraces"]/*' />
        MatchBraces,
        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="ParseReason.Check"]/*' />
        Check,
        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="ParseReason.CompleteWord"]/*' />
        CompleteWord,
        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="ParseReason.DisplayMemberList"]/*' />
        DisplayMemberList,
        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="ParseReason.QuickInfo"]/*' />
        QuickInfo,
        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="ParseReason.MethodTip"]/*' />
        MethodTip,
        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="ParseReason.Autos"]/*' />
        Autos,
        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="ParseReason.CodeSpan"]/*' />
        CodeSpan,
        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="ParseReason.Goto"]/*' />
        Goto
    };

    /// <include file='doc\LanguageService.uex' path='docs/doc[@for="LanguageService"]/*' />
    [CLSCompliant(false), ComVisible(true)]
    public abstract class LanguageService : IDisposable, IVsLanguageInfo, IVsLanguageDebugInfo,
        IVsProvideColorableItems, IVsLanguageContextProvider, IOleServiceProvider,
        IObjectWithSite, ISynchronizeInvoke, IVsDebuggerEvents,
        IVsFormatFilterProvider { //, IVsOutliningCapableLanguage {

        private IServiceProvider site;
        private ArrayList codeWindowManagers;
        private LanguagePreferences preferences;
        private ArrayList sources;
        private ArrayList colorizers;
        private bool disposed;
        private IVsDebugger debugger;
        private uint cookie;
        private DBGMODE dbgMode;
        private int lcid;
        private bool isParsing;
        private Thread mainThread;
        private MainThreadTask task;
        private MainThreadTask tail;
        private TaskControl control;

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="LanguageService.LanguageService"]/*' />
        protected LanguageService() {
            this.codeWindowManagers = new ArrayList();
            this.sources = new ArrayList();
            this.colorizers = new ArrayList();
            this.mainThread = Thread.CurrentThread;            
        }

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="LanguageService.Initialize"]/*' />
        public virtual void Initialize() {
        }

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="LanguageService.Site;"]/*' />
        public IServiceProvider Site {
            get { return this.site; }
        }

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="LanguageService.MainThreadId"]/*' />
        public int MainThreadId {
            get {
                return this.mainThread.ManagedThreadId;
            }
        }

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="LanguageService.Preferences"]/*' />
        public LanguagePreferences Preferences {
            get {
                if (this.preferences == null && !disposed) {
                    this.preferences = this.GetLanguagePreferences();
                }
                return this.preferences;
            }
            set {
                this.preferences = value;
            }
        }

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="LanguageService.Done"]/*' />
        /// <summary>
        /// Cleanup the sources, uiShell, shell, preferences and imageList objects
        /// and unregister this language service with VS.
        /// </summary>
        public virtual void Dispose() {
            OnActiveViewChanged(null);
            this.disposed = true;
            this.StopThread();
            this.lastActiveView = null;
            if (this.control != null) {
                this.control.Dispose();
                this.control = null;
            }
            if (this.sources != null) {
                foreach (Source s in this.sources) {
                    s.Dispose();
                }
                this.sources.Clear();
                this.sources = null;
            }
            if (this.colorizers != null) {
                foreach (Colorizer c in this.colorizers) {
                    c.Dispose();
                }
                this.colorizers.Clear();
                this.colorizers = null;
            }

            if (this.codeWindowManagers != null) {
                foreach (CodeWindowManager m in this.codeWindowManagers) {
                    m.Close();
                }
                this.codeWindowManagers.Clear();
                this.codeWindowManagers = null;
            }

            if (this.preferences != null) {
                this.preferences.Dispose();
                this.preferences = null;
            }
            if (this.debugger != null && this.cookie != 0) {
                NativeMethods.ThrowOnFailure(this.debugger.UnadviseDebuggerEvents(this.cookie));
                this.cookie = 0;
                this.debugger = null;
            }
            if (this.task != null)
                this.task.Dispose();
            this.task = null;
            this.site = null;
        }

        // Methods implemented by subclass.
        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="LanguageService.GetLanguagePreferences"]/*' />
        /// It is expected that you will have one static language preferences object
        /// for your package.
        public abstract LanguagePreferences GetLanguagePreferences();

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="LanguageService.GetScanner"]/*' />
        public abstract IScanner GetScanner(IVsTextLines buffer);

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="LanguageService.ParseSource"]/*' />
        public abstract AuthoringScope ParseSource(ParseRequest req);

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="LanguageService.Name"]/*' />
        /// <summary>Return the name of the language, such as "HTML" or "C++", and so on.</summary>
        public abstract string Name { get; }

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="LanguageService.GetLanguageServiceGuid"]/*' />
        public Guid GetLanguageServiceGuid() {
            return this.GetType().GUID;
        }

        #region IVsProvideColorableItems
        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="LanguageService.GetItemCount"]/*' />
        public virtual int GetItemCount(out int count) {
            count = 0;
            return NativeMethods.E_NOTIMPL;
        }

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="LanguageService.GetColorableItem"]/*' />
        public virtual int GetColorableItem(int index, out IVsColorableItem item) {
            item = null;
            return NativeMethods.E_NOTIMPL;
        }
        #endregion

        #region IVsLanguageContextProvider
        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="LanguageService.IVsLanguageContextProvider.UpdateLanguageContext"]/*' />
        /// <internalonly/>
        int IVsLanguageContextProvider.UpdateLanguageContext(uint dwHint, IVsTextLines buffer, TextSpan[] ptsSelection, object ptr) {
            if (ptr != null && ptr is IVsUserContext) {
                UpdateLanguageContext((LanguageContextHint)dwHint, buffer, ptsSelection, (IVsUserContext)ptr);
            }
            return NativeMethods.S_OK;
        }

        /// <summary>
        /// Call this method if you want UpdateLanguageContext to be called again.
        /// </summary>
        public void SetUserContextDirty(string fileName) {
            if (string.IsNullOrEmpty(fileName)) return;
            IVsWindowFrame windowFrame = null;
            uint itemID = VSConstants.VSITEMID_NIL;
            IVsUIHierarchy hierarchy = null;
            if (VsShell.IsDocumentOpen(this.Site, fileName, Guid.Empty, out hierarchy, out itemID, out windowFrame)) {
                IVsUserContext context;
                if (windowFrame != null) {
                    object prop;
                    int hr = windowFrame.GetProperty((int)__VSFPROPID.VSFPROPID_UserContext, out prop);
                    context = (IVsUserContext)prop;
                    if (NativeMethods.Succeeded(hr) && context != null) {
                        context.SetDirty(1);
                    }
                }
            }
        }

        #endregion

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="LanguageService.UpdateLanguageContext"]/*' />
        public virtual void UpdateLanguageContext(LanguageContextHint hint, IVsTextLines buffer, TextSpan[] ptsSelection, IVsUserContext context) {
        }

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="LanguageService.GetImageList"]/*' />
        public virtual ImageList GetImageList() {
            ImageList ilist = new ImageList();
            ilist.ImageSize = new Size(16, 16);
            ilist.TransparentColor = Color.FromArgb(255, 0, 255);
            Stream stream = typeof(LanguageService).Assembly.GetManifestResourceStream("Resources.completionset.bmp");
            ilist.Images.AddStrip(new Bitmap(stream));
            return ilist;
        }

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="LanguageService.IsMacroRecordingOn"]/*' />
        public bool IsMacroRecordingOn() {
            IVsShell shell = this.GetService(typeof(SVsShell)) as IVsShell;
            if (shell != null) {
                object pvar;
                NativeMethods.ThrowOnFailure(shell.GetProperty((int)__VSSPROPID.VSSPROPID_RecordState, out pvar));
                shell = null;
                if (pvar != null) {
                    return ((VSRECORDSTATE)pvar == VSRECORDSTATE.VSRECORDSTATE_ON);
                }
            }
            return false;
        }

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="LanguageService.GetIVsDebugger"]/*' />
        public IVsDebugger GetIVsDebugger() {
            if (this.debugger == null) {
                Guid guid = typeof(Microsoft.VisualStudio.Shell.Interop.IVsDebugger).GUID;
                this.debugger = this.GetService(typeof(IVsDebugger)) as IVsDebugger;
                if (this.debugger != null) {
                    NativeMethods.ThrowOnFailure(debugger.AdviseDebuggerEvents(this, out this.cookie));
                }
            }
            return debugger;
        }

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="LanguageService.GetIVsTextMacroHelperIfRecordingOn"]/*' />
        public IVsTextMacroHelper GetIVsTextMacroHelperIfRecordingOn() {
            if (IsMacroRecordingOn()) {
                IVsTextManager textmgr = (IVsTextManager)this.GetService(typeof(SVsTextManager));
                return (IVsTextMacroHelper)textmgr;
            }
            return null;
        }

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="LanguageService.OpenDocument"]/*' />
        public void OpenDocument(string path) {
            VsShell.OpenDocument(this.site, path);
        }

        internal int lastLine = -1;
        internal int lastCol = -1;
        internal string lastFileName;
        internal IVsTextView lastActiveView;

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="LanguageService.LastActiveTextView"]/*' />
        /// <devdoc>
        /// Returns the last active IVsTextView that is managed by this language service.
        /// </devdoc>
        public IVsTextView LastActiveTextView {
            get { return this.lastActiveView; }
        }

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="LanguageService.IsActive"]/*' />
        /// <devdoc>
        /// Return whether or not the last active text view is one of ours or not.
        /// </devdoc>
        public bool IsActive {
            get {
                if (disposed) return false;
                if (this.lastActiveView == null) return false;
                return this.GetSource(this.lastActiveView) != null;
            }
        }

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="LanguageService.OnIdle"]/*' />
        public virtual void OnIdle(bool periodic) {
            RunTasks();
            if (!this.IsActive)
                return;

            // here's our chance to synchronize combo's and so on, 
            // first we see if the caret has moved.                
            IVsTextView view = this.lastActiveView;
            if (view == null) return;
            Source s = this.GetSource(view);
            if (s == null) return;

            int line = -1, col = -1;
            NativeMethods.ThrowOnFailure(view.GetCaretPos(out line, out col));
            
            if (line != this.lastLine || col != this.lastCol || this.lastFileName == null) {
                this.lastLine = line;
                this.lastCol = col;
                this.lastFileName = s.GetFilePath(); 
                CodeWindowManager cwm = this.GetCodeWindowManagerForView(view);
                if (cwm != null) {
                    this.OnCaretMoved(cwm, view, line, col);
                }
            }
            s.OnIdle(periodic);
            RunTasks();
        }

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="LanguageService.GetDropDownHelper"]/*' />
        /// <devdoc>
        /// Return your implementation of TypeAndMemberDropdownBars if you want 
        /// drop down combos to appear at the top of your code window.
        /// </devdoc>
        public virtual TypeAndMemberDropdownBars CreateDropDownHelper(IVsTextView forView) {
            return null;
        }
        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="LanguageService.OnActiveViewChanged"]/*' />
        public virtual void OnActiveViewChanged(IVsTextView textView) {
            this.lastActiveView = textView;
            this.lastFileName = null;
            this.StopThread(); // current parse no longer relevant.
        }
        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="LanguageService.OnCaretMoved"]/*' />
        public virtual void OnCaretMoved(CodeWindowManager mgr, IVsTextView textView, int line, int col) {
            if (mgr.DropDownHelper != null)
                mgr.DropDownHelper.SynchronizeDropdowns(textView, line, col);
        }

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="LanguageService.SynchronizeDropdowns"]/*' />
        public virtual void SynchronizeDropdowns() {
            IVsTextView textView = this.LastActiveTextView;
            if (textView != null) {
                CodeWindowManager mgr = this.GetCodeWindowManagerForView(textView);
                if (mgr != null && mgr.DropDownHelper != null) {
                    try {
                        int line = -1, col = -1;
                        if (NativeMethods.Failed(textView.GetCaretPos(out line, out col)))
                            return;
                        mgr.DropDownHelper.SynchronizeDropdowns(textView, line, col);
                    } catch { }
                }
            }
        }

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="LanguageService.OnChangesCommitted"]/*' />
        protected virtual void OnChangesCommitted(uint flags, Microsoft.VisualStudio.TextManager.Interop.TextSpan[] ptsChanged) {
        }

        // Override this method to plug in your own custom colorizer.
        // You shouldn't need to do this since the colorizer simply
        // uses your Scanner to get the color information.
        // This method returns the same colorizer for each unique buffer,
        // which you must do also.
        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="LanguageService.GetColorizer"]/*' />
        public virtual Colorizer GetColorizer(IVsTextLines buffer) {
            foreach (Colorizer c in this.colorizers) {
                if (c.buffer == buffer) {
                    return c; 
                }
            }
            Colorizer result = new Colorizer(this, buffer, this.GetScanner(buffer));
            this.colorizers.Add(result);
            return result;
        }

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="LanguageService.CreateSource"]/*' />
        public virtual Source CreateSource(IVsTextLines buffer) {
            return new Source(this, buffer, this.GetColorizer(buffer));
        }

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="LanguageService.GetSources"]/*' />
        /// <summary>For enumerating all the known 'Source' objects.</summary>
        public IEnumerable GetSources() {
            return this.sources;
        }

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="LanguageService.GetSource"]/*' />
        // We have to make sure we return the same colorizer for each text buffer,
        // so we keep a hashtable of IVsTextLines -> Source objects, the Source
        // object owns the Colorizer for that buffer.  If this method returns null
        // then it means the text buffer does not belong to this language service.
        public Source GetSource(IVsTextLines buffer) {
            if (buffer == null) return null;
            foreach (Source src in this.sources) {
                if (src.GetTextLines() == buffer) {
                    return src;
                }
            }
            return null;
        }

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="LanguageService.GetSource2"]/*' />
        public Source GetSource(IVsTextView view) {
            if (view == null) return null;
            IVsTextLines buffer;
            NativeMethods.ThrowOnFailure(view.GetBuffer(out buffer));
            return GetSource(buffer);
        }

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="LanguageService.GetSource1"]/*' />
        public Source GetSource(string fname) {
            if (this.sources != null) {
                foreach (Source s in this.sources) {
                    if (NativeMethods.IsSamePath(s.GetFilePath(), fname))
                        return s;
                }
            }
            return null;
        }

        internal virtual void OnCloseColorizer(Colorizer c) {
            if (this.colorizers != null) {
                if (this.colorizers.Contains(c)) {
                    this.colorizers.Remove(c);
                }
            }
        }

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="LanguageService.OnCloseSource"]/*' />
        public virtual void OnCloseSource(Source source) {
            ClearTask();
            StopThread();
            if (this.sources != null) {
                if (this.sources.Contains(source)) {
                    this.sources.Remove(source);
                }
            }
        }

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="LanguageService.IsSourceOpen"]/*' />
        public virtual bool IsSourceOpen(Source src) {
            return (this.sources != null) && this.sources.Contains(src);
        }


        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="LanguageService.IsDebugging"]/*' />
        public bool IsDebugging {
            get {
                if (this.debugger == null) {
                    this.debugger = GetIVsDebugger();
                }
                return this.dbgMode != DBGMODE.DBGMODE_Design;
            }
        }

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="LanguageService.CreateDocumentProperties"]/*' />
        // Override this method to create your own custom document properties for
        // display in the Properties Window when the editor for this Source is active.
        // Default is null which means there will be no document properties.
        public virtual DocumentProperties CreateDocumentProperties(CodeWindowManager mgr) {
            return null;
        }

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="LanguageService.CreateExpansionFunction"]/*' />
        /// If the functionName is supported, return a new IVsExpansionFunction object.
        public virtual ExpansionFunction CreateExpansionFunction(ExpansionProvider provider, string functionName) {
            return null;
        }
        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="LanguageService.CreateExpansionProvider"]/*' />
        public virtual ExpansionProvider CreateExpansionProvider(Source src) {
            return new ExpansionProvider(src);
        }

        #region IVsLanguageInfo methods
        // GetCodeWindowManager -- this gives us the VsCodeWindow which is what we need to
        // add adornments and so forth.
        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="LanguageService.GetCodeWindowManager"]/*' />
        public int GetCodeWindowManager(IVsCodeWindow codeWindow, out IVsCodeWindowManager mgr) {
            Initialize();
            IVsTextLines buffer = null;
            NativeMethods.ThrowOnFailure(codeWindow.GetBuffer(out buffer));
            mgr = CreateCodeWindowManager(codeWindow, GetOrCreateSource(buffer));
            return NativeMethods.S_OK;
        }

        private Source GetOrCreateSource(IVsTextLines buffer) {
            // see if we already have a Source object.
            Source s = GetSource(buffer);
            if (s == null) {
                // Ok, then create one.
                s = CreateSource(buffer);
                this.sources.Add(s);
            }
            return s;
        }

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="LanguageService.CreateCodeWindowManager"]/*' />
        public virtual CodeWindowManager CreateCodeWindowManager(IVsCodeWindow codeWindow, Source source) {
            return new CodeWindowManager(this, codeWindow, source);
        }

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="LanguageService.GetColorizer1"]/*' />
        public int GetColorizer(IVsTextLines buffer, out IVsColorizer result) {
            // Do NOT create source object yet - this might be an invisible editor in which
            // case Source object will create shutdown problems (VSWhidbey bug 447564).
            result = this.GetColorizer(buffer);
            return NativeMethods.S_OK;
        }

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="LanguageService.GetLanguageName"]/*' />        
        public virtual int GetLanguageName(out string name) {
            name = this.Name;
            return NativeMethods.S_OK;
        }

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="LanguageService.GetFileExtensions"]/*' />
        public virtual int GetFileExtensions(out string extensions) {
            extensions = "";
            return NativeMethods.S_OK;
        }

        #endregion

        #region IVsLanguageDebugInfo methods
        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="LanguageService.GetLanguageID"]/*' />
        public virtual int GetLanguageID(IVsTextBuffer buffer, int line, int col, out Guid langId) {
            langId = GetLanguageServiceGuid();
            return NativeMethods.S_OK;
        }

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="LanguageService.GetLocationOfName"]/*' />
        public virtual int GetLocationOfName(string name, out string pbstrMkDoc, TextSpan[] spans) {
            pbstrMkDoc = null;
            return NativeMethods.E_NOTIMPL;
        }

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="LanguageService.GetNameOfLocation"]/*' />
        public virtual int GetNameOfLocation(IVsTextBuffer buffer, int line, int col, out string name, out int lineOffset) {
            name = null;
            lineOffset = 0;
            /*
         TRACE1( "LanguageService(%S)::GetNameOfLocation", m_languageName );
        OUTARG(lineOffset);
        OUTARG(name);
        INARG(textBuffer);

        HRESULT hr;
        IScope* scope = NULL;
        hr = GetScopeFromBuffer( textBuffer, &scope );
        if (FAILED(hr)) return hr;
  
        long realLine = line;
        hr = scope->Narrow( line, idx, name, &realLine );
        RELEASE(scope);
        if (hr != S_OK) return hr;

        *lineOffset = line - realLine;
        return S_OK;
      */
            return NativeMethods.S_OK;
        }

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="LanguageService.GetProximityExpressions"]/*' />
        public virtual int GetProximityExpressions(IVsTextBuffer buffer, int line, int col, int cLines, out IVsEnumBSTR ppEnum) {
            ppEnum = null;
            /*
        TRACE2( "LanguageService(%S)::GetProximityExpressions: line %i", m_languageName, line );
        OUTARG(exprs);
        INARG(textBuffer);

        //check the linecount
        if (lineCount <= 0) lineCount = 1;

        //get the source 
        //TODO: this only works for sources that are opened in the environment
        HRESULT hr;
        Source* source = NULL;
        hr = GetSource( textBuffer, &source );
        if (FAILED(hr)) return hr;

        //parse and find the proximity expressions
        StringList* strings = NULL;
        hr = source->GetAutos( line, line + lineCount, &strings );
        RELEASE(source);
        if (FAILED(hr)) return hr;

        hr = strings->QueryInterface( IID_IVsEnumBSTR, reinterpret_cast<void**>(exprs) );
        RELEASE(strings);
        if (FAILED(hr)) return hr;
  
        return S_OK;
      */
            return NativeMethods.S_FALSE;
        }

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="LanguageService.IsMappedLocation"]/*' />
        public virtual int IsMappedLocation(IVsTextBuffer buffer, int line, int col) {
            return NativeMethods.S_FALSE;
        }

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="LanguageService.ResolveName"]/*' />
        public virtual int ResolveName(string name, uint flags, out IVsEnumDebugName ppNames) {
            ppNames = null;
            return NativeMethods.E_NOTIMPL;
        }

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="LanguageService.ValidateBreakpointLocation"]/*' />
        public virtual int ValidateBreakpointLocation(IVsTextBuffer buffer, int line, int col, TextSpan[] pCodeSpan) {
            return NativeMethods.E_NOTIMPL;
        }
        #endregion

        /// <include file='doc\Package.uex' path='docs/doc[@for="LanguageService.GetService"]' />
        public object GetService(Type serviceType) {
            if (this.site != null) {
                return this.site.GetService(serviceType);
            }
            return null;
        }

        #region Microsoft.VisualStudio.OLE.Interop.IServiceProvider methods
        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="LanguageService.QueryService"]/*' />
        public virtual int QueryService(ref Guid guidService, ref Guid iid, out IntPtr obj) {
            obj = IntPtr.Zero;
            if (this.site != null) {
                IOleServiceProvider psp = this.GetService(typeof(IOleServiceProvider)) as IOleServiceProvider;
                if (psp != null)
                    NativeMethods.ThrowOnFailure(psp.QueryService(ref guidService, ref iid, out obj));
                return 0;
            }
            return (int)NativeMethods.E_UNEXPECTED;
        }
        #endregion

        // Override this method if you want to insert your own view filter
        // into the command chain.  
        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="LanguageService.CreateViewFilter"]/*' />
        public virtual ViewFilter CreateViewFilter(CodeWindowManager mgr, IVsTextView newView) {
            return new ViewFilter(mgr, newView);
        }

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="LanguageService.AddCodeWindowManager"]/*' />
        public void AddCodeWindowManager(CodeWindowManager m) {
            this.codeWindowManagers.Add(m);
        }

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="LanguageService.RemoveCodeWindowManager"]/*' />
        public void RemoveCodeWindowManager(CodeWindowManager m) {
            this.codeWindowManagers.Remove(m);
        }

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="LanguageService.GetCodeWindowManagerForView"]/*' />
        public CodeWindowManager GetCodeWindowManagerForView(IVsTextView view) {
            if (view == null) return null;
            foreach (CodeWindowManager m in this.codeWindowManagers) {
                if (m.CodeWindow != null) {
                    IVsTextView pView;
                    int hr = m.CodeWindow.GetLastActiveView(out pView);
                    if (hr == NativeMethods.S_OK && pView == view)
                        return m;
                }
            }
            return null;
        }

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="LanguageService.GetCodeWindowManagerForSource"]/*' />
        public CodeWindowManager GetCodeWindowManagerForSource(Source src) {
            if (src == null) return null;
            foreach (CodeWindowManager m in this.codeWindowManagers) {
                if (m.Source == src) {
                    return m;
                }
            }
            return null;
        }

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="LanguageService.TileVertically"]/*' />
        /// <summary>Executes the given command if it is enabled and supported using the
        /// current SUIHostCommandDispatcher.</summary>
        public int DispatchCommand(Guid cmdGuid, uint cmdId, IntPtr pvaIn, IntPtr pvaOut) {
            int hr = NativeMethods.E_FAIL;
            IOleCommandTarget cmdTarget = this.Site.GetService(typeof(SUIHostCommandDispatcher)) as IOleCommandTarget;
            if (cmdTarget != null) {
                OLECMD[] prgCmds = new OLECMD[1];
                prgCmds[0].cmdID = cmdId;
                hr = cmdTarget.QueryStatus(ref cmdGuid, 1, prgCmds, IntPtr.Zero);
                if (hr == NativeMethods.S_OK &&
                    ((prgCmds[0].cmdf & (uint)OLECMDF.OLECMDF_ENABLED) == (uint)OLECMDF.OLECMDF_ENABLED)) {
                    hr = cmdTarget.Exec(ref cmdGuid, cmdId, 0, IntPtr.Zero, IntPtr.Zero);
                }
            }
            return hr;
        }

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="LanguageService.ScrollToEnd"]/*' />
        public void ScrollToEnd(IVsWindowFrame frame) {
            IVsTextView view = VsShell.GetTextView(frame);
            if (view != null) {
                ScrollToEnd(view);
            }
        }
        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="LanguageService.ScrollToEnd2"]/*' />
        public void ScrollToEnd(IVsTextView view) {
            IVsTextLines buffer;
            NativeMethods.ThrowOnFailure(view.GetBuffer(out buffer));
            int lines;
            NativeMethods.ThrowOnFailure(buffer.GetLineCount(out lines));
            int lineHeight;
            NativeMethods.ThrowOnFailure(view.GetLineHeight(out lineHeight));
            Microsoft.VisualStudio.NativeMethods.RECT bounds = new Microsoft.VisualStudio.NativeMethods.RECT();
            NativeMethods.GetClientRect(view.GetWindowHandle(), ref bounds);
            int visibleLines = ((bounds.bottom - bounds.top) / lineHeight) - 1;
            // The line number needed to be passed to SetTopLine is ZERO based, so need to subtract ONE from number of total lines
            int top = Math.Max(0, lines - visibleLines - 1);
            Debug.Assert(lines > top, "Cannot set top line to be greater than total number of lines");
#if XMLTRACE
            Trace.WriteLine("ScrollToEnd: lines=" + lines + ", visibleLines=" + visibleLines + ", top=" + top);
#endif
            NativeMethods.ThrowOnFailure(view.SetTopLine(top));
        }

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="LanguageService.BeginParse"]/*' />
        public IAsyncResult BeginParse(ParseRequest request, ParseResultHandler handler) {
            StartThread();
            lock (this) {
                request.Callback = handler;
                this.parseRequest = request;
                this.isParsing = true;
                this.parseRequestPending.Set();
                this.parseRequestDone.Reset();
                return new AsyncResult(this, request, this.parseRequestDone);
            }
        }

        public IAsyncResult GetParseResult() {
            return new AsyncResult(this, this.parseRequest, this.parseRequestDone);
        }

        class AsyncResult : IAsyncResult {
            LanguageService service;
            ParseRequest request;
            ParseWaitHandle handle;

            public AsyncResult(LanguageService svc, ParseRequest request, ParseWaitHandle handle) {
                this.service = svc;
                this.request = request;
                this.handle = handle;
            }
            public object AsyncState {
                get { return request; }
            }

            public WaitHandle AsyncWaitHandle {
                get { return this.handle; }
            }

            public bool CompletedSynchronously {
                get { return request.IsSynchronous; }
            }

            public bool IsCompleted {
                get { return this.handle.IsSet(); }
            }
        }

        /// <summary>
        /// This class provides a special wrapper on WaitHandle that allows a caller
        /// to block on a parse request, while still pumping the RunTasks queue so they
        /// don't cause a deadlock.
        /// </summary>
        class ParseWaitHandle : WaitHandle {
            LanguageService service;
            ManualResetEvent evt = new ManualResetEvent(false);
            bool set = false;

            public ParseWaitHandle(LanguageService service) {
                this.service = service;
            }

            public void Set() {
                set = true;
                evt.Set();
            }
            public void Reset() {
                set = false;
                evt.Reset();
            }
            public bool IsSet(){
                return this.set;
            }
            public override bool WaitOne() {
                while (!this.WaitOne(10, false)) {                    
                }
                return true;
            }

            public override bool WaitOne(int millisecondsTimeout, bool exitContext) {
                int total = 0;
                bool result = false;
                while (total <= millisecondsTimeout && !result) {
                    result = evt.WaitOne(10, false);
                    total += 10;
                    service.RunTasks();
                }
                return result;
            }

            public override bool WaitOne(TimeSpan timeout, bool exitContext) {
                return WaitOne(timeout.Milliseconds, exitContext);
            }            
        }

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="LanguageService.CreateParseRequest"]/*' />
        public virtual ParseRequest CreateParseRequest(Source s, int line, int idx, TokenInfo info, string sourceText, 
                                                       string fname, ParseReason reason, IVsTextView view) {
            this.isParsing = false; // yes, "false".  It get's set to true in the actual background thread.
            bool sync = false;
            if (!this.Preferences.EnableAsyncCompletion) {
                sync = true; //unless registry value indicates that sync ops always prefer async 
            }
            return new ParseRequest(line, idx, info, sourceText, fname, reason, view, s.CreateAuthoringSink(reason, line, idx), sync);
        }

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="LanguageService.OnParseComplete"]/*' />
        /// <summary>Override this method if you need to do any post-parse work on the main UI thread.
        /// Be sure to call this base method in order to get the dynamic help context updated.</summary>
        public virtual void OnParseComplete(ParseRequest req) {
            SetUserContextDirty(req.FileName);
            RefreshUI();
        }

        internal void RefreshUI() {
            IVsUIShell uiShell = this.GetService(typeof(SVsUIShell)) as IVsUIShell;
            if (uiShell != null) {
                uiShell.UpdateCommandUI(1);
            }
        }

        internal void StartThread() {
            if (this.parseThread == null && !disposed) {
                this.parseRequestPending = new ManualResetEvent(false);
                this.parseThreadTerminated = new ManualResetEvent(false);
                this.parseRequestDone = new ParseWaitHandle(this);
                this.parseThread = new Thread(new ThreadStart(ParseThread));
                this.parseThread.Start();
            }
        }

        internal void StopThread() {
            if (this.parseThread != null) {
                this.parseRequest = new ParseRequest(true);
                ManualResetEvent ptt = this.parseThreadTerminated;
                this.parseRequestPending.Set();
                if (!ptt.WaitOne(10, false)) { // give it a few milliseconds...
                    // Then kill it right away so devenv.exe shuts down quickly and so that
                    // the parse thread doesn't try to access services that are already shutdown.
                    try {
                        this.parseThread.Abort();
                        this.parseRequestDone.Set(); // make sure this gets set!
                    } catch {
                    }
                    this.parseThread = null;
                }
            }
            CleanupThread();
        }

        internal void CleanupThread() {
            this.parseRequestPending = null;
            this.parseThreadTerminated = null;
            this.parseThread = null;
            this.parseRequestDone = null;
        }

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="LanguageService.OnParseComplete"]/*' />
        public bool IsParsing {
            get { return this.isParsing; }
            set { this.isParsing = value; }
        }

        public void AbortBackgroundParse() {
            this.StopThread();
        }

        internal ParseRequest parseRequest;
        internal ManualResetEvent parseRequestPending;
        internal ManualResetEvent parseThreadTerminated = new ManualResetEvent(false);
        private ParseWaitHandle parseRequestDone;

        internal Thread parseThread;

        internal void ParseThread() {
            try {

                // Initialize this thread's culture info with that of the shell's LCID
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(this.lcid);
                bool stop = false;
                while (!stop) {
                    if (!parseRequestPending.WaitOne(10000, true)) {
                        break;
                    }
                    ParseRequest req = null;
                    lock (this) {
                        req = this.parseRequest;
                        this.parseRequest = null; // got it!
                        parseRequestPending.Reset();
                    }
                    if (req.Terminate)
                        break;

                    try {
                        this.isParsing = true;
                        this.ParseRequest(req);
                        if (this.parseRequest == null || req.Reason == ParseReason.Check) {
                            // If another parse request has already come in then the
                            // user must be typing really fast (e.g. macros) and 
                            // so we throw this response away, and go right on to the
                            // next request.
                            // Note this must be asynchronous (do NOT call invoke).
                            // Reason being that the UI thread may then want to call
                            // StopThread, which would deadlock if this was synchronous.
                            this.BeginInvoke(req.Callback, new object[1] { req });
                        }
                    } catch (ThreadAbortException) {
                        stop = true;
                    } finally {
                        if (this.parseRequestDone != null) { //thread cleanup might have set this to null
                            this.parseRequestDone.Set();
                        }
                    }
                    this.isParsing = false;
                }
                ManualResetEvent ptt = parseThreadTerminated;
                CleanupThread();
                ptt.Set();
                this.isParsing = false;
            } catch {
#if LANGTRACE
                Trace.WriteLine("Background Parse Thread Aborted");
#endif
            }
            this.isParsing = false;
        }

        internal void ParseRequest(ParseRequest req) {
            int start = Environment.TickCount;
            req.Scope = this.ParseSource(req);
            int end = Environment.TickCount;
            if (end > start) {
#if LANGTRACE
                Trace.WriteLine("ParseRequest in " + (end - start) + " ticks");
#endif
                req.parseTime = end - start;
            }
        }

        #region IObjectWithSite
        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="LanguageService.IObjectWithSite.GetSite"]/*' />
        public void GetSite(ref Guid iid, out IntPtr ptr) {
            IntPtr pUnk = Marshal.GetIUnknownForObject(this.site);
            Marshal.QueryInterface(pUnk, ref iid, out ptr);
            Marshal.Release(pUnk);
        }
        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="LanguageService.IObjectWithSite.SetSite"]/*' />
        /// <internalonly/>
        public void SetSite(object site) {
            if (site is IServiceProvider) {
                this.site = (IServiceProvider)site;
            } else if (site is IOleServiceProvider) {
                this.site = new ServiceProvider((IOleServiceProvider)site);
            }
            Microsoft.VisualStudio.Shell.Package pkg = (Microsoft.VisualStudio.Shell.Package)this.site.GetService(typeof(Microsoft.VisualStudio.Shell.Package));
            this.lcid = pkg.GetProviderLocale();
            this.control = new TaskControl(this);
        }
        #endregion

#if IVsOutliningCapableLanguage                 
        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="LanguageService.CollapseToDefinitions"]/*' />
        public virtual void CollapseToDefinitions(IVsTextLines buffer, IVsOutliningSession session) {
            Source source = this.GetSource(buffer);
            source.CollapseAllHiddenRegions(session);
        }
#endif

        void Queue(MainThreadTask task) {
            lock (this) {
                if (this.tail != null) { // might actually be running!
                    this.tail.Next = task; // quietly append the new task
                } else {
                    this.task = task;
                    if (this.control != null) {
                        // Ping RunTasks right away rather than waiting for OnIdle.
                        this.control.PostRunTasks();
                    }
                }
                this.tail = task;
            }
        }

        MainThreadTask Dequeue() {
            lock (this) {
                MainThreadTask result = null;
                if (this.task != null) {
                    result = this.task;
                    this.task = result.Next;
                    if (this.task == null) {
                        this.tail = null;
                    }
                }
                return result;
            }
        }

        void ClearTask() {
            lock (this) {
                this.task = this.tail = null;
            }
        }

        internal void RunTasks() {
            MainThreadTask task = Dequeue();
            while (task != null) {
                task.Run();
                task = Dequeue();
            }
        }

        #region ISynchronizeInvoke Members

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="LanguageService.BeginInvoke"]/*' />
        [HostProtection(Synchronization = true, ExternalThreading = true)]
        public IAsyncResult BeginInvoke(Delegate method, object[] args) {
            MainThreadTask task = new MainThreadTask(this.mainThread, method, args);
            Queue(task);
            return task; // wait for onidle.
        }

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="LanguageService.Invoke"]/*' />
        public object Invoke(Delegate method, object[] args) {
            MainThreadTask task = new MainThreadTask(this.mainThread, method, args);
            if (!task.CompletedSynchronously) {
                Queue(task);
                task.AsyncWaitHandle.WaitOne(); // wait for onidle loop.
            }
            object result = task.AsyncState;
            return result;
        }

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="LanguageService.EndInvoke"]/*' />
        public object EndInvoke(IAsyncResult result) {
            result.AsyncWaitHandle.WaitOne();
            return result.AsyncState;
        }

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="LanguageService.InvokeRequired"]/*' />
        public bool InvokeRequired {
            get {
                return this.mainThread != Thread.CurrentThread;
            }
        }
        #endregion


        #region IVsDebuggerEvents Members

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="LanguageService.OnModeChange"]/*' />
        public virtual int OnModeChange(DBGMODE dbgmodeNew) {
            this.dbgMode = dbgmodeNew;
            return NativeMethods.S_OK;
        }

        #endregion


        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="LanguageService.QueryInvalidEncoding"]/*' />
        /// Return true if the given encoding information is invalid for your language service
        /// Default always returns false.  If you return true, then also return an error
        /// message to display to the user.
        public virtual bool QueryInvalidEncoding(__VSTFF format, out string errorMessage) {
            errorMessage = null;
            return false;
        }

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="LanguageService.GetFormatFilterList"]/*' />
        // Provides the list of available extensions for Save As.
        // The following default filter string is automatically added
        // by Visual Studio:
        // "All Files (*.*)\n*.*\nText Files (*.txt)\n*.txt\n"
        public virtual string GetFormatFilterList() {
            return "";
        }

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="LanguageService.CurFileExtensionFormat"]/*' />
        // Provides the index to the filter matching the extension of the file passed in.
        // The default behavior for this method is to look for the matching extension 
        // in the list returned from GetFormatFilterList and return the index to that extension.
        // It expects GetFormatFilterList to return newline separated or '|' separated 
        // list of label/extension pairs. It expects the extensions to be in the format "*.x"
        // where x is the extension you want to match.  Returns -1 if there is no match.
        public virtual int CurFileExtensionFormat(string fileName) {

            string filter = GetFormatFilterList();
            if (string.IsNullOrEmpty(filter)) return -1;

            string fileext = FilePathUtilities.GetFileExtension(fileName);

            string[] sa = null;
            if (filter.Contains("\n")) {
                sa = filter.Split('\n');
            } else if (filter.Contains("|")) {
                sa = filter.Split('|');
            } else {
                throw new ArgumentException(SR.GetString(SR.UnrecognizedFilterFormat), "GetFormatFilterList");
            }

            for (int i = 0, n = sa.Length - 1; i < n; i += 2) {
                string ext = sa[i + 1].Trim();
                if (ext.Length > 1 && string.Compare(ext.Substring(1), fileext, StringComparison.OrdinalIgnoreCase) == 0) {
                    return i / 2;
                }
            }
            return -1;
        }

        #region IVsFormatFilterProvider Members
        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="LanguageService.IVsFormatFilterProvider.QueryInvalidEncoding"]/*' />
        /// <internalonly/>
        int IVsFormatFilterProvider.QueryInvalidEncoding(uint format, out string pbstrMessage) {
            if (QueryInvalidEncoding((__VSTFF)format, out pbstrMessage)) {
                return NativeMethods.S_OK;
            }
            return NativeMethods.S_FALSE;
        }

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="LanguageService.IVsFormatFilterProvider.CurFileExtensionFormat"]/*' />
        /// <internalonly/>
        int IVsFormatFilterProvider.CurFileExtensionFormat(string bstrFileName, out uint pdwExtnIndex) {
            pdwExtnIndex = 0;
            if (!string.IsNullOrEmpty(bstrFileName)) {
                int i = CurFileExtensionFormat(bstrFileName);
                if (i >= 0) {
                    pdwExtnIndex = (uint)i;
                    return NativeMethods.S_OK;
                }
            }
            return NativeMethods.E_FAIL; // return 0 - but no match found.
        }

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="LanguageService.IVsFormatFilterProvider.GetFormatFilterList"]/*' />
        /// <internalonly/>
        int IVsFormatFilterProvider.GetFormatFilterList(out string pbstrFilterList) {
            pbstrFilterList = GetFormatFilterList();
            if (pbstrFilterList.Contains("|")) {
                string[] sa = pbstrFilterList.Split('|');
                pbstrFilterList = string.Join("\n", sa);
            }
            if (pbstrFilterList == null)
                return NativeMethods.E_FAIL;

            // Must be terminated with a new line character.
            // (since inside VS this results in the proper Win32 saveas dialog double null 
            // termination format since the new lines are replaced with nulls).
            // (See dlgsave.cpp line 163 in the InvokeSaveAsDlg function).
            if (!pbstrFilterList.EndsWith("\n", StringComparison.OrdinalIgnoreCase))
                pbstrFilterList = pbstrFilterList + "\n";

            return NativeMethods.S_OK;
        }

        #endregion
    } // end class LanguageService

    internal class MainThreadTask : IAsyncResult, IDisposable {
        ManualResetEvent evt = new ManualResetEvent(false);
        Delegate method;
        object[] args;
        bool completed;
        bool completedSynchronously;
        Thread main;
        object result;
        MainThreadTask next;
        ExecutionContext context;
        Exception error;

        public MainThreadTask(Thread main, Delegate method, object[] args) {
            this.main = main;
            this.method = method;
            this.args = args;
            if (Thread.CurrentThread == main) {
                Run(); // run synchronously!
                this.completedSynchronously = true;
            } else {
                this.context = ExecutionContext.Capture();
            }
        }

        public MainThreadTask Next {
            get { return this.next; }
            set { this.next = value; }
        }

        public void Run() {
            if (!this.completed && this.method != null) {
                if (this.context == null) {
                    RunSecure(null);
                } else {
                    ExecutionContext.Run(this.context, new ContextCallback(RunSecure), null);
                }
            }
        }

        void RunSecure(object state) {
            try {
                this.result = method.DynamicInvoke(args);
            } catch (Exception e) {
                // Save the exception for the original thread who made this request.
                this.error = e;
            } finally {
                this.completed = true;
                this.evt.Set();
            }
        }

        public object AsyncState {
            get {
                if (this.error != null) {
                    // throw the exception on the original thread.
                    throw this.error;
                }
                return this.result;
            }
        }

        public WaitHandle AsyncWaitHandle {
            get { return this.evt; }
        }

        public bool CompletedSynchronously {
            get { return this.completedSynchronously; }
        }

        public bool IsCompleted {
            get { return this.completed; }
        }

        public void Dispose() {
            if (this.evt != null) {
                this.evt.Close();
                this.evt = null;
            }
            this.method = null;
            this.args = null;
        }
    }

    /// <include file='doc\LanguageService.uex' path='docs/doc[@for="ParseResultHandler"]/*' />
    [CLSCompliant(false)]
    public delegate void ParseResultHandler(ParseRequest request);

    /// <include file='doc\LanguageService.uex' path='docs/doc[@for="ParseRequest"]/*' />
    [CLSCompliant(false)]
    public class ParseRequest {
        int line, col;
        TextSpan dirtySpan;
        string fileName;
        string text;
        ParseReason reason;
        IVsTextView view;
        bool terminate;
        ParseResultHandler callback;
        AuthoringSink sink;
        AuthoringScope scope;
        TokenInfo tokenInfo;
        int timestamp;
        internal int parseTime;
        bool isSynchronous;
        internal IAsyncResult result;

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="ParseRequest.IsSynchronous;"]/*' />
        public bool IsSynchronous {
            get { return isSynchronous; }
            set { isSynchronous = value; }
        }

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="ParseRequest.Line;"]/*' />
        public int Line {
            get { return this.line; }
            set { this.line = value; }
        }

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="ParseRequest.Col;"]/*' />
        public int Col {
            get { return this.col; }
            set { this.col = value; }
        }

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="ParseRequest.DirtySpan;"]/*' />
        public TextSpan DirtySpan {
            get { return this.dirtySpan; }
            set { this.dirtySpan = value; }
        }

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="ParseRequest.FileName;"]/*' />
        public string FileName {
            get { return this.fileName; }
            set { this.fileName = value; }
        }

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="ParseRequest.Text;"]/*' />
        public string Text {
            get { return this.text; }
            set { this.text = value; }
        }

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="ParseRequest.Reason;"]/*' />
        public ParseReason Reason {
            get { return this.reason; }
            set { this.reason = value; }
        }

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="ParseRequest.View;"]/*' />
        public IVsTextView View {
            get { return this.view; }
            set { this.view = value; }
        }

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="ParseRequest.Terminate;"]/*' />
        public bool Terminate {
            get { return this.terminate; }
            set { this.terminate = value; }
        }

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="ParseRequest.Callback;"]/*' />
        public ParseResultHandler Callback {
            get { return this.callback; }
            set { this.callback = value; }
        }

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="ParseRequest.Sink;"]/*' />
        public AuthoringSink Sink {
            get { return this.sink; }
            set { this.sink = value; }
        }

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="ParseRequest.Scope;"]/*' />
        public AuthoringScope Scope {
            get { return this.scope; }
            set { this.scope = value; }
        }

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="ParseRequest.TokenInfo;"]/*' />
        public TokenInfo TokenInfo {
            get { return this.tokenInfo; }
            set { this.tokenInfo = value; }
        }

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="ParseRequest.Timestamp;"]/*' />
        public int Timestamp {
            get { return this.timestamp; }
            set { this.timestamp = value; }
        }

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="ParseRequest.ParseRequest"]/*' />
        public ParseRequest(bool terminate) {
            this.Terminate = terminate;
        }

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="ParseRequest.ParseRequest1"]/*' />
        public ParseRequest(int line, int col, TokenInfo info, string src, string fname, 
            ParseReason reason, IVsTextView view, AuthoringSink sink, bool synchronous) {
            this.Line = line;
            this.Col = col;
            this.FileName = fname;
            this.Text = src;
            this.Reason = reason;
            this.View = view;
            this.Sink = sink;
            this.TokenInfo = info;
            this.isSynchronous = synchronous;
        }
    }

    /// <include file='doc\LanguageService.uex' path='docs/doc[@for="AuthoringScope"]/*' />
    [CLSCompliant(false)]
    public abstract class AuthoringScope {
        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="AuthoringScope.GetDataTipText"]/*' />
        public abstract string GetDataTipText(int line, int col, out TextSpan span);

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="AuthoringScope.GetDeclarations"]/*' />
        //REVIEW: why pass in the view and the info?
        public abstract Declarations GetDeclarations(IVsTextView view, int line, int col, TokenInfo info, ParseReason reason);

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="AuthoringScope.GetMethods"]/*' />
        public abstract Methods GetMethods(int line, int col, string name);

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="AuthoringScope.Goto"]/*' />
        public abstract string Goto(Microsoft.VisualStudio.VSConstants.VSStd97CmdID cmd, IVsTextView textView, int line, int col, out TextSpan span);
    }

    /// <include file='doc\LanguageService.uex' path='docs/doc[@for="Declarations"]/*' />
    [CLSCompliant(false)]
    public abstract class Declarations : IDisposable {

        private string lastBestMatch;

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="Declarations.LastBestMatch"]/*' />
        public string LastBestMatch {
            get {
                return this.lastBestMatch;
            }
            set {
                this.lastBestMatch = value;
            }
        }

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="Declarations.Declarations"]/*' />
        protected Declarations() {
            this.LastBestMatch = "";
        }

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="Declarations.Dispose"]/*' />
        public virtual void Dispose() {
        }

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="Declarations.GetCount"]/*' />
        public abstract int GetCount();

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="Declarations.GetDisplayText"]/*' />
        public abstract string GetDisplayText(int index);

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="Declarations.GetName"]/*' />
        public abstract String GetName(int index);

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="Declarations.GetDescription"]/*' />
        public abstract String GetDescription(int index);

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="Declarations.GetGlyph"]/*' />
        public abstract int GetGlyph(int index);

        /// <include file='doc\Source.uex' path='docs/doc[@for="Declarations.GetInitialExtent"]/*' />
        /// <summary>Override this method if you want to customize how the initial extent
        /// is calculated.  If you do not implement this method the the Source object 
        /// GetWordExtent will be used by default.</summary>
        public virtual bool GetInitialExtent(IVsTextView textView, out int line, out int startIdx, out int endIdx) {
            line = startIdx = endIdx = 0;
            return false;
        }

        // return whether this is a uniqueMatch or not
        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="Declarations.GetBestMatch"]/*' />
        public virtual void GetBestMatch(String value, out int index, out bool uniqueMatch) {
            index = -1;
            uniqueMatch = false;
            this.LastBestMatch = "";
            if (value != null) {
                int count = GetCount();
                bool found = false;
                bool foundInsensitive = false;
                bool uniqueInsensitive = false;
                int indexInsensitive = -1;
                // Don't assume the list is sorted!                
                // But give case-sensitive comparison the preference.
                for (int i = 0; i < count; i++) {
                    if (IsPerfectMatch(value, i)){
                        if (!found) {
                            uniqueMatch = true;
                            found = true;
                            index = i;
                        } else {
                            uniqueMatch = false;
                            break;
                        }
                    } 
                    if (IsMatch(value, i)) {
                        if (!foundInsensitive) {
                            uniqueInsensitive = true;
                            foundInsensitive = true;
                            indexInsensitive = i;
                        } else {
                            uniqueInsensitive = false;
                        }
                    }
                }
                if (!found && foundInsensitive) {
                    uniqueMatch = uniqueInsensitive;
                    index = indexInsensitive;
                }
                return;
            }
            if (value == null || value.Length == 0) {
                // no match found - return S_FALSE
                COMException ce = new COMException("", unchecked((int)0x00000001));
                throw ce;
            } else {
                this.LastBestMatch = value;
                index = GetCount();
                uniqueMatch = true;
            }
            return;
        }

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="Declarations.IsMatch"]/*' />
        public virtual bool IsMatch(string textSoFar, int index) {
            int len = textSoFar.Length;
            string text = GetName(index);
            return String.Compare(text, 0, textSoFar, 0, len, true, CultureInfo.CurrentUICulture) == 0;
        }

        bool IsPerfectMatch(string textSoFar, int index) {
            int len = textSoFar.Length;
            string text = GetName(index);
            return String.Compare(text, 0, textSoFar, 0, len, false, CultureInfo.CurrentUICulture) == 0;
        }

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="Declarations.IsCommitChar"]/*' />
        public virtual bool IsCommitChar(string textSoFar, int selected, char commitCharacter) {
            // Usual language identifier rules...
            return !(Char.IsLetterOrDigit(commitCharacter) || commitCharacter == '_');
        }

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="Declarations.OnCommit"]/*' />
        public virtual string OnCommit(IVsTextView textView, string textSoFar, char commitCharacter, int index, ref TextSpan initialExtent) {
            return GetName(index);
        }

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="Declarations.OnAutoComplete"]/*' />
        // This method allows the implementer to do something after completion is finished, for example,
        // in the XML editor the when the user selects a start tag name "<foo", this method is used to
        // insert the end tag automatically "></foo>".  The framework makes sure this method is called at
        // the right time, after VS has actually inserted the result from OnCommit, in this case "foo".
        // It returns one more character to process, which may itself be a trigger for more intellisense.
        public virtual char OnAutoComplete(IVsTextView textView, string committedText, char commitCharacter, int index) {
            // do nothing by default.
            return '\0';
        }
    }

    //-------------------------------------------------------------------------------------
    /// <include file='doc\LanguageService.uex' path='docs/doc[@for="Methods"]/*' />
    [CLSCompliant(false)]
    public abstract class Methods {

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="Methods.DefaultMethod"]/*' />
        /// <summary>Returns the method that should be selected first (based on what was found
        /// at parse time at the ParseRequest source location).</summary>
        public virtual int DefaultMethod {
            get { return 0; }
        }

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="Methods.GetName"]/*' />
        public abstract string GetName(int index);

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="Methods.GetCount"]/*' />
        public abstract int GetCount();

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="Methods.GetDescription"]/*' />
        public abstract string GetDescription(int index);

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="Methods.GetType"]/*' />
        public abstract string GetType(int index);

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="Methods.GetParameterCount"]/*' />
        public abstract int GetParameterCount(int index);

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="Methods.GetParameterInfo"]/*' />
        public abstract void GetParameterInfo(int index, int parameter, out string name, out string display, out string description);

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="Methods.OpenBracket"]/*' />
        public virtual string OpenBracket {
            get { return "("; }
        }
        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="Methods.CloseBracket"]/*' />
        public virtual string CloseBracket {
            get { return ")"; }
        }
        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="Methods.Delimiter"]/*' />
        public virtual string Delimiter {
            get { return ","; }
        }
        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="Methods.TypePrefixed"]/*' />
        public virtual bool TypePrefixed {
            get { return false; }
        }
        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="Methods.TypePrefix"]/*' />
        public virtual string TypePrefix {
            get { return null; }
        }
        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="Methods.TypePostfix"]/*' />
        public virtual string TypePostfix {
            get { return null; }
        }
    }

    internal class CallInfo {
        internal int currentParameter;
        internal StringCollection names;
        internal ArrayList sourceLocations;
    };

    internal class MethodCalls {
        private Stack calls;
        private CallInfo call;

        public MethodCalls() {
            this.calls = new Stack();
            this.Push(new StringCollection(), new ArrayList());
        }

        public void Push(StringCollection names, ArrayList sourceLocations) {
            this.calls.Push(call);
            this.call = new CallInfo();
            this.call.names = names;
            this.call.sourceLocations = sourceLocations;
        }

        public void NextParameter() {
            this.call.currentParameter++;
        }

        public void Pop() {
            if (this.calls.Count <= 0) {
                Debug.Assert(false); return;
            }
            call = (CallInfo)this.calls.Pop();
        }

        public CallInfo GetCurrentMethodCall() {
            return this.call;
        }
    }

    internal class BraceMatch {
        internal TextSpan a;
        internal TextSpan b;
        internal int priority;

        public BraceMatch(TextSpan a, TextSpan b, int priority) {
            this.a = a;
            this.b = b;
            this.priority = priority;
        }

    }

    internal class TripleMatch : BraceMatch {
        internal TextSpan c;

        public TripleMatch(TextSpan a, TextSpan b, TextSpan c, int priority)
            : base(a, b, priority) {
            this.c = c;
        }
    }

    /// <include file='doc\LanguageService.uex' path='docs/doc[@for="AuthoringSink"]/*' />
    /// <summary>
    /// AuthoringSink is used to gather information from the parser to help in the following:
    /// - error reporting
    /// - matching braces (ctrl-])
    /// - intellisense: Member Selection, CompleteWord, QuickInfo, MethodTips
    /// - management of the autos window in the debugger
    /// - breakpoint validation
    /// </summary>
    [CLSCompliant(false)]
    public class AuthoringSink {
        internal ParseReason reason;
        internal StringCollection Names;
        internal ArrayList SourceLocations;
        internal int line;
        internal int col;
        internal MethodCalls MethodCalls;
        internal ArrayList Spans;
        internal ArrayList Braces;
        internal bool foundMatchingBrace;
        internal ArrayList hiddenRegions;
        internal bool processHiddenRegions;
        internal ArrayList errors;
        private int[] errorCounts;
        private int maxErrors;

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="AuthoringSink.AuthoringSink"]/*' />
        public AuthoringSink(ParseReason reason, int line, int col, int maxErrors) {
            this.reason = reason;
            this.errors = new ArrayList();
            this.line = line;
            this.col = col;
            this.Names = new StringCollection();
            this.SourceLocations = new ArrayList();
            this.MethodCalls = new MethodCalls();
            this.Spans = new ArrayList();
            this.Braces = new ArrayList();
            this.hiddenRegions = new ArrayList();
            this.errorCounts = new int[4];
            this.maxErrors = maxErrors;
        }

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="AuthoringSink.Line"]/*' />
        public int Line {
            get { return this.line; }
        }

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="AuthoringSink.Column"]/*' />
        public int Column {
            get { return this.col; }
        }

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="AuthoringSink.Reason"]/*' />
        public ParseReason Reason {
            get { return this.reason; }
        }

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="AuthoringSink.FoundMatchingBrace"]/*' />
        public bool FoundMatchingBrace {
            get { return this.foundMatchingBrace; }
            set { this.foundMatchingBrace = value; }
        }

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="AuthoringSink.UpdateHiddenRegions"]/*' />
        /// <summary>Determines whether or not hidden regions should be updated
        /// or not based on the calls to AddHiddenRegion.  Default is false.</summary>
        public bool ProcessHiddenRegions {
            get { return this.processHiddenRegions; }
            set { this.processHiddenRegions = value; }
        }

        private void AddBraces(BraceMatch b) {
            this.foundMatchingBrace = true;
            int i = 0;
            for (int n = this.Braces.Count; i < n; i++) {
                BraceMatch a = (BraceMatch)this.Braces[i];
                if (a.priority < b.priority)
                    break;
            }
            this.Braces.Insert(i, b);
        }

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="AuthoringSink.BraceMatching"]/*' />
        /// <summary>Use this property to find if your parser should call MatchPair or MatchTriple</summary>
        public bool BraceMatching {
            get {
                switch (this.reason) {
                    case ParseReason.MatchBraces:
                    case ParseReason.HighlightBraces:
                    case ParseReason.MemberSelectAndHighlightBraces:
                        return true;
                }
                return false;
            }
        }

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="AuthoringSink.MatchPair"]/*' />
        /// <summary>
        /// Whenever a matching pair is parsed, e.g. '{' and '}', this method is called
        /// with the text span of both the left and right item. The
        /// information is used when a user types "ctrl-]" in VS
        /// to find a matching brace and when auto-highlight matching
        /// braces is enabled.  A priority can also be given so that multiple overlapping pairs 
        /// can be prioritized for brace matching.  The matching pair with the highest priority 
        /// (largest integer value) wins.
        /// </summary>
        public virtual void MatchPair(TextSpan span, TextSpan endContext, int priority) {
            if (BraceMatching) {
                TextSpanHelper.MakePositive(ref span);
                TextSpanHelper.MakePositive(ref endContext);
                if (TextSpanHelper.ContainsInclusive(span, this.line, this.col) ||
                    TextSpanHelper.ContainsInclusive(endContext, this.line, this.col)) {
                    this.Spans.Add(span);
                    this.Spans.Add(endContext);
                    AddBraces(new BraceMatch(span, endContext, priority));
                }
            }
        }

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="AuthoringSink.MatchTriple"]/*' />
        /// <summary>
        /// Matching tripples are used to highlight in bold a completed statement.  For example
        /// when you type the closing brace on a foreach statement VS highlights in bold the statement
        /// that was closed.  The first two source contexts are the beginning and ending of the statement that
        /// opens the block (for example, the span of the "foreach(...){" and the third source context
        /// is the closing brace for the block (e.g., the "}").  A priority can also be given so that
        /// multiple overlapping pairs can be prioritized for brace matching.  
        /// The matching pair with the highest priority  (largest integer value) wins.
        /// </summary>
        public virtual void MatchTriple(TextSpan startSpan, TextSpan middleSpan, TextSpan endSpan, int priority) {
            if (BraceMatching) {
                TextSpanHelper.MakePositive(ref startSpan);
                TextSpanHelper.MakePositive(ref middleSpan);
                TextSpanHelper.MakePositive(ref endSpan);
                if (TextSpanHelper.ContainsInclusive(startSpan, this.line, this.col) ||
                    TextSpanHelper.ContainsInclusive(middleSpan, this.line, this.col) ||
                    TextSpanHelper.ContainsInclusive(endSpan, this.line, this.col)) {
                    this.Spans.Add(startSpan);
                    this.Spans.Add(middleSpan);
                    this.Spans.Add(endSpan);
                    AddBraces(new TripleMatch(startSpan, middleSpan, endSpan, priority));
                }
            }
        }

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="AuthoringSink.FindNames"]/*' />
        /// <summary>Use this property to find if your parser should call StartName or QualifyName</summary>
        public bool FindNames {
            get {
                switch (this.reason) {
                    case ParseReason.MemberSelect:
                    case ParseReason.CompleteWord:
                    case ParseReason.MemberSelectAndHighlightBraces:
                    case ParseReason.DisplayMemberList:
                    case ParseReason.QuickInfo:
                    case ParseReason.MethodTip:
                    case ParseReason.Autos:
                        return true;
                }
                return false;
            }
        }
        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="AuthoringSink.StartName"]/*' />
        /// <summary>
        /// In support of Member Selection, CompleteWord, QuickInfo, 
        /// MethodTip, and Autos, the StartName and QualifyName methods
        /// are called.
        /// StartName is called for each identifier that is parsed (e.g. "Console")
        /// </summary>
        public virtual void StartName(TextSpan span, string name) {
            if (FindNames) {
                int startLine = span.iStartLine;
                int startCol = span.iStartIndex;
                int endLine = span.iEndLine;
                int endCol = span.iEndIndex;
                if (startLine < 0 || startCol < 0 || startLine > endLine || (startLine == endLine && endCol < startCol)) {
                    Debug.Assert(false);
                    return;
                }
                if (startLine <= this.line && endLine >= this.line) {
                    this.Names.Add(name);
                    this.SourceLocations.Add(span);
                }
            }
        }

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="AuthoringSink.QualifyName"]/*' />
        /// <summary>
        /// QualifyName is called for each qualification with both
        /// the text span of the selector (e.g. ".")  and the text span 
        /// of the name ("WriteLine").
        /// </summary>
        public virtual void QualifyName(TextSpan selectorContext, TextSpan nameContext, string name) {
            if (FindNames) {
                int startLine1 = selectorContext.iStartLine;
                int startCol1 = selectorContext.iStartIndex;
                int endCol1 = selectorContext.iEndIndex;
                int endLine1 = selectorContext.iEndLine;
                int startLine2 = nameContext.iStartLine;
                int startCol2 = nameContext.iStartIndex;
                int endCol2 = nameContext.iEndIndex;
                int endLine2 = nameContext.iEndLine;
                if (startLine1 < 0 || startCol1 < 0 || (startLine1 == endLine1 && endCol1 < startCol1) || startLine2 < startLine1 || startCol2 < 0 || (startLine2 == endLine2 && endCol2 < startCol2)) {
                    Debug.Assert(false);
                    return;
                }
                if (startLine2 <= this.line && endLine2 >= this.line) {
                    this.Names.Add(name);
                    this.SourceLocations.Add(nameContext);
                }
            }
        }

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="AuthoringSink.AutoExpression"]/*' />
        /// <summary>
        /// AutoExpression is in support of IVsLanguageDebugInfo.GetProximityExpressions.
        /// It is called for each expression that might be interesting for
        /// a user in the "Auto Debugging" window. All names that are
        /// set using StartName and QualifyName are already automatically
        /// added to the "Auto" window! This means that AutoExpression
        /// is rarely used.
        /// </summary>
        public virtual void AutoExpression(TextSpan expr) {
        }

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="AuthoringSink.CodeSpan"]/*' />
        /// <summary>
        /// CodeSpan is in support of IVsLanguageDebugInfo.ValidateBreakpointLocation.
        /// It is called for each region that contains "executable" code.
        /// This is used to validate breakpoints. Comments are
        /// automatically taken care of based on TokenInfo returned from scanner. 
        /// Normally this method is called when a procedure is started/ended.
        /// </summary>
        public virtual void CodeSpan(TextSpan span) {
        }

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="AuthoringSink.MethodParameters"]/*' />
        /// <summary>Use this property to find if your parser should call StartParameters, NextParameter or EndParameters</summary>
        public bool MethodParameters {
            get {
                switch (this.reason) {
                    case ParseReason.MethodTip:
                    case ParseReason.QuickInfo:
                        return true;
                }
                return false;
            }
        }


        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="AuthoringSink.StartParameters"]/*' />
        /// <summary>
        /// The StartParameters, Parameter and EndParameter methods are
        /// called in support of method tip intellisense (ECMD_PARAMINFO).
        /// [StartParameters] is called when the parameters of a method
        /// are started, ie. "(".
        /// [Parameter] is called on the start of a new parameter, ie. ",".
        /// [EndParameter] is called on the end of the paramters, ie. ")".
        /// </summary>
        public virtual void StartParameters(TextSpan context) {
            if (MethodParameters) {
                int startLine = context.iStartLine;
                int startCol = context.iStartIndex;
                if (startLine < 0 || startCol < 0) {
                    Debug.Assert(false);
                    return;
                }
                if (this.line > startLine || (this.line == startLine && this.col >= startCol)) {
                    this.MethodCalls.Push(this.Names, this.SourceLocations);
                    this.Names = new StringCollection();
                    this.SourceLocations = new ArrayList();
                }
            }
        }

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="AuthoringSink.NextParameter"]/*' />
        /// <summary>
        /// NextParameter is called after StartParameters on the start of each new parameter, ie. ",".
        /// </summary>
        public virtual void NextParameter(TextSpan context) {
            if (MethodParameters) {
                int startLine = context.iStartLine;
                int startCol = context.iStartIndex;
                if (startLine < 0 || startCol < 0) {
                    Debug.Assert(false);
                    return;
                }
                if (this.line > startLine || (this.line == startLine && this.col > startCol)) {
                    this.MethodCalls.NextParameter();
                }
            }
        }

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="AuthoringSink.EndParameters"]/*' />
        /// <summary>
        /// EndParameter is called on the end of the paramters, ie. ")".
        /// </summary>
        public virtual void EndParameters(TextSpan context) {
            if (MethodParameters) {
                int startLine = context.iStartLine;
                int startCol = context.iStartIndex;
                if (startLine < 0 || startCol < 0) {
                    Debug.Assert(false);
                    return;
                }
                if (this.line > startLine || (this.line == startLine && this.col > startCol)) {
                    this.MethodCalls.Pop();
                }
            }
        }

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="AuthoringSink.AddTask"]/*' />
        /// <summary>
        /// Add an error message. This method also filters out duplicates so you only
        /// see the unique errors in the error list window.
        /// </summary>
        public virtual void AddError(string path, string message, TextSpan context, Severity sev) {
            if (this.reason != ParseReason.Check)
                return;
            if (context.iStartLine < 0 || context.iEndLine < context.iStartLine || context.iStartIndex < 0 || (context.iEndLine == context.iStartLine && context.iEndIndex < context.iStartIndex)) {
                Debug.Assert(false);
                return;
            }
            int i = (int)sev;
            if (this.errorCounts[i] == this.maxErrors)
                return; // reached maximum

            // Make sure the error is unique.
            foreach (ErrorNode n in this.errors) {
                if ((TextSpanHelper.IsSameSpan(n.context, context) ||
                     TextSpanHelper.IsEmbedded(n.context, context) ||
                     TextSpanHelper.IsEmbedded(context, n.context)) &&
                    n.message == message &&
                    n.severity == sev &&
                    n.uri == path) {
                    return; // then it's a duplicate!
                }
            }
            this.errorCounts[i]++;
            this.errors.Add(new ErrorNode(path, message, context, sev));
        }

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="AuthoringSink.HiddenRegions"]/*' />
        /// <summary>Use this property to find if your parser should call AddHiddenRegion</summary>
        public bool HiddenRegions {
            get {
                return (this.reason == ParseReason.Check);
            }
        }

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="AuthoringSink.AddHiddenRegion"]/*' />
        /// <summary>
        /// This is in support of outlining.
        /// </summary>
        public virtual void AddHiddenRegion(TextSpan context) {
            if (!HiddenRegions)
                return;

            NewHiddenRegion r = new NewHiddenRegion();
            r.iType = (int)HIDDEN_REGION_TYPE.hrtCollapsible;
            r.dwBehavior = (int)HIDDEN_REGION_BEHAVIOR.hrbClientControlled;
            r.dwState = (int)HIDDEN_REGION_STATE.hrsExpanded;
            r.tsHiddenText = context;
            r.pszBanner = null;
            r.dwClient = (uint)Source.HiddenRegionCookie;
            AddHiddenRegion(r);
        }

        /// <include file='doc\LanguageService.uex' path='docs/doc[@for="AuthoringSink.AddHiddenRegion"]/*' />
        /// <summary>
        /// AddHiddenRegion calls this for you, you can call it directly or override it
        /// to modify the default behavior.
        /// </summary>
        public virtual void AddHiddenRegion(NewHiddenRegion r) {
            if (!HiddenRegions)
                return;

            // Sort the regions by their start positions so that if they add more than 
            // MaxRegions then they get the outer top level ones first.
            int i = this.hiddenRegions.Count - 1;
            while (i >= 0) {
                NewHiddenRegion s = (NewHiddenRegion)this.hiddenRegions[i];
                if (TextSpanHelper.StartsAfterStartOf(r.tsHiddenText, s.tsHiddenText))
                    break;
                i--;
            }
            this.hiddenRegions.Insert(i + 1, r);
        }

    }; // AuthoringSink

    internal class ErrorNode {
        public string uri;
        public string message;
        public TextSpan context;
        public Severity severity;
        public ErrorNode(string uri, string message, TextSpan context, Severity severity) {
            this.uri = uri;
            this.message = message;
            this.context = context;
            this.severity = severity;
        }
    }

    internal class TaskControl : UserControl {
        LanguageService svc;
        const int WM_USER = 0x0400;
        const int WM_RUNTASKS = WM_USER + 500;
        IntPtr hwnd;
        bool posted;

        public TaskControl(LanguageService svc) {
            this.svc = svc;
            this.hwnd = this.Handle;
        }

        protected override void Dispose(bool disposing) {
            this.svc = null;
            base.Dispose(disposing);
        }

        // This causes a thread switch to the main UI thread where we can safely call RunTasks().
        public void PostRunTasks() {
            if (!this.posted) {
                this.posted = true;
                NativeMethods.PostMessage(this.hwnd, WM_RUNTASKS, IntPtr.Zero, IntPtr.Zero);
            }
        }

        protected override void WndProc(ref Message m) {
            if (m.Msg == WM_RUNTASKS && this.svc != null) {
                this.posted = false;
                svc.RunTasks();
            }
            base.WndProc(ref m);
        }
    }

}