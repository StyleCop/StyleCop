using System;
//using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Xml;
using System.Collections;
using System.IO;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.OLE.Interop;
using Microsoft.VisualStudio.TextManager.Interop;
using Microsoft.VisualStudio.Shell;
using IOleServiceProvider = Microsoft.VisualStudio.OLE.Interop.IServiceProvider;
using IServiceProvider = System.IServiceProvider;
using VsShell = Microsoft.VisualStudio.Shell.VsShellUtilities;

namespace Microsoft.VisualStudio.Package {

    // DocumentTask is associated with an IVsTextLineMarker in a specified document and 
    // implements Navigate() to jump to that marker.
    /// <include file='doc\DocumentTask.uex' path='docs/doc[@for="DocumentTask"]/*' />
    [CLSCompliant(false)]
    [System.Runtime.InteropServices.ComVisible(true)]
    public class DocumentTask : ErrorTask, IVsTextMarkerClient, IDisposable {
        // Since all taskitems support this field we define it generically. Can use put_Text to set it.
        IServiceProvider site;
        string fileName;
        IVsTextLineMarker textLineMarker;
        TextSpan span;        
        bool markerValid;

        /// <include file='doc\DocumentTask.uex' path='docs/doc[@for="DocumentTask.DocumentTask"]/*' />
        public DocumentTask(IServiceProvider site, IVsTextLines buffer, MARKERTYPE markerType, TextSpan span, string fileName) {

            this.site = site;
            this.fileName = fileName;
            this.span = span;
            this.Document = this.fileName;
            this.Column = span.iStartIndex;
            this.Line = span.iStartLine;

            if (markerType != MARKERTYPE.MARKER_OTHER_ERROR) {
                // create marker so task item navigation works even after file is edited.
                IVsTextLineMarker[] marker = new IVsTextLineMarker[1];
                // bugbug: the following comment in the method CEnumMarkers::Initialize() of
                // ~\env\msenv\textmgr\markers.cpp means that tool tips on empty spans
                // don't work:
                //      "VS7 #23719/#15312 [CFlaat]: exclude adjacent markers when the target span is non-empty"
                // So I wonder if we should debug assert on that or try and modify the span
                // in some way to make it non-empty...
                NativeMethods.ThrowOnFailure(buffer.CreateLineMarker((int)markerType, span.iStartLine, span.iStartIndex, span.iEndLine, span.iEndIndex, this, marker));
                this.textLineMarker = marker[0];
                this.markerValid = true;
            }
            
            
        }
        /// <include file='doc\DocumentTask.uex' path='docs/doc[@for="DocumentTask.Finalize"]/*' />
        ~DocumentTask() {
            Dispose(false);
        }

        /// <include file='doc\TaskProvider.uex' path='docs/doc[@for="DocumentTask.IsMarkerValid"]/*' />
        public bool IsMarkerValid {
            get {
                return this.markerValid;
            }
        }

        /// <include file='doc\TaskProvider.uex' path='docs/doc[@for="DocumentTask.Site"]/*' />
        public IServiceProvider Site {
            get { return this.site; }
        }

        /// <include file='doc\TaskProvider.uex' path='docs/doc[@for="DocumentTask.Dispose"]/*' />
        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <include file='doc\TaskProvider.uex' path='docs/doc[@for="DocumentTask.Dispose1"]/*' />
        protected virtual void Dispose(bool disposing) {
            if (this.textLineMarker != null){
                this.textLineMarker.UnadviseClient();
            }
            this.textLineMarker = null;
            this.site = null;
        }

        /// <include file='doc\DocumentTask.uex' path='docs/doc[@for="DocumentTask.OnNavigate"]/*' />
        protected override void OnNavigate(EventArgs e) {

            TextSpan span = this.span;
            if (textLineMarker != null) {
                TextSpan[] spanArray = new TextSpan[1];
                NativeMethods.ThrowOnFailure(textLineMarker.GetCurrentSpan(spanArray));
                span = spanArray[0];
            }

            IVsUIHierarchy hierarchy;
            uint itemID;
            IVsWindowFrame docFrame;
            IVsTextView textView;
            VsShell.OpenDocument(this.site, this.fileName, NativeMethods.LOGVIEWID_Code, out hierarchy, out itemID, out docFrame, out textView);
            NativeMethods.ThrowOnFailure(docFrame.Show());
            if (textView != null) {
                NativeMethods.ThrowOnFailure(textView.SetCaretPos(span.iStartLine, span.iStartIndex));
                TextSpanHelper.MakePositive(ref span);
                NativeMethods.ThrowOnFailure(textView.SetSelection(span.iStartLine, span.iStartIndex, span.iEndLine, span.iEndIndex));
                NativeMethods.ThrowOnFailure(textView.EnsureSpanVisible(span));
            }
            base.OnNavigate(e);
        }

        /// <include file='doc\DocumentTask.uex' path='docs/doc[@for="DocumentTask.OnRemoved"]/*' />
        protected override void OnRemoved(EventArgs e) {
            if (textLineMarker != null) {
                NativeMethods.ThrowOnFailure(textLineMarker.Invalidate());
                this.markerValid = false;
            }
            textLineMarker = null;
            this.site = null;
            base.OnRemoved(e);
        }

        /// <include file='doc\DocumentTask.uex' path='docs/doc[@for="DocumentTask.Span"]/*' />
        public TextSpan Span {
            get {
                if (textLineMarker != null) {
                    TextSpan[] aSpan = new TextSpan[1];
                    NativeMethods.ThrowOnFailure(textLineMarker.GetCurrentSpan(aSpan));
                    return aSpan[0];
                }
                return this.span;
            }
        }

        /// <include file='doc\DocumentTask.uex' path='docs/doc[@for="DocumentTask.TextLineMarker"]/*' />
        public IVsTextLineMarker TextLineMarker {
            get { return this.textLineMarker; }
        }

        #region IVsTextMarkerClient methods

        /*---------------------------------------------------------
            IVsTextMarkerClient
        -----------------------------------------------------------*/
        /// <include file='doc\DocumentTask.uex' path='docs/doc[@for="DocumentTask.MarkerInvalidated"]/*' />
        public virtual void MarkerInvalidated() {
            this.markerValid = false;            
        }

        /// <include file='doc\DocumentTask.uex' path='docs/doc[@for="DocumentTask.OnBufferSave"]/*' />
        public virtual void OnBufferSave(string fileName) {
        }

        /// <include file='doc\DocumentTask.uex' path='docs/doc[@for="DocumentTask.OnBeforeBufferClose"]/*' />
        public virtual void OnBeforeBufferClose() {
        }

        /// <include file='doc\DocumentTask.uex' path='docs/doc[@for="DocumentTask.OnAfterSpanReload"]/*' />
        public virtual void OnAfterSpanReload() {
        }

        /// <include file='doc\DocumentTask.uex' path='docs/doc[@for="DocumentTask.OnAfterMarkerChange"]/*' />
        public virtual int OnAfterMarkerChange(IVsTextMarker marker) {
            return NativeMethods.S_OK;
        }

        /// <include file='doc\DocumentTask.uex' path='docs/doc[@for="DocumentTask.GetTipText"]/*' />
        public virtual int GetTipText(IVsTextMarker marker, string[] tipText) {
            if (this.Text != null && this.Text.Length > 0) tipText[0] = this.Text;
            return NativeMethods.S_OK;
        }

        /// <include file='doc\DocumentTask.uex' path='docs/doc[@for="DocumentTask.GetMarkerCommandInfo"]/*' />
        public virtual int GetMarkerCommandInfo(IVsTextMarker marker, int item, string[] text, uint[] commandFlags) {
            // Returning S_OK results in error message appearing in editor's
            // context menu when you right click over the error message.
            if (commandFlags != null && commandFlags.Length > 0)
                commandFlags[0] = 0;
            if (text != null && text.Length > 0)
                text[0] = null;
            return NativeMethods.E_NOTIMPL;
        }

        /// <include file='doc\DocumentTask.uex' path='docs/doc[@for="DocumentTask.ExecMarkerCommand"]/*' />
        public virtual int ExecMarkerCommand(IVsTextMarker marker, int item) {
            return NativeMethods.S_OK;
        }
        #endregion 
    };

}
