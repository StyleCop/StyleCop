//------------------------------------------------------------------------------
// <copyright file="Task.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>                                                                
//------------------------------------------------------------------------------

namespace Microsoft.VisualStudio.Shell {

    using Microsoft.VisualStudio.OLE.Interop;
    using Microsoft.VisualStudio.Shell.Interop;
    using Microsoft.Win32;
    using System;
    using System.Collections;
    using System.Collections.Specialized;
    using System.ComponentModel;
    using System.ComponentModel.Design;
    using System.Diagnostics;
    using System.IO;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    using IOleServiceProvider = Microsoft.VisualStudio.OLE.Interop.IServiceProvider;
    using IServiceProvider = System.IServiceProvider;

    /// <include file='doc\Task.uex' path='docs/doc[@for="Task"]' />
    /// <devdoc>
    ///     This class implements IVsTaskItem.  
    /// </devdoc>
    [ComVisible(true)]
    [CLSCompliant(false)]
    public class Task :

        IVsTaskItem,
        IVsProvideUserContext
    {
        /// <include file='doc\Task.uex' path='docs/doc[@for="Task.contextNameKeyword"]/*' />
        public const string contextNameKeyword = "Keyword";

        private TaskProvider owner;
        private bool canDelete;
        private bool checkedEditable;
        private bool priorityEditable;
        private bool textEditable;
        private TaskPriority priority;
        private TaskCategory category;
        private int          subCategoryIndex;
        private string       text; 
        private string       document;
        private string       caption;
        private string       helpKeyword;
        private int          line;
        private int          imageIndex;
        private int          column;
        private bool         isChecked;
        private IVsUserContext context = null;

        /// <include file='doc\Task.uex' path='docs/doc[@for="Task.Task"]/*' />
        public Task() {
            priority = TaskPriority.Normal;
            subCategoryIndex = -1;
            // Initializing the imageIndex to -1 tells VS to not expect to get
            // an imageList from us either, and instead use the default images.
            // This fixes bug 172354.
            imageIndex = -1;
            line = -1;
            column = -1;
            text = string.Empty;
            helpKeyword = string.Empty;
            document = string.Empty;
        }

        /// <include file='doc\Task.uex' path='docs/doc[@for="Task.Task1"]/*' />
        public Task(Exception error) : this() {
    
            // Now use the exception to fill in the 
            // task data.
            if (error == null) {
                throw new ArgumentNullException("error");
            }

            Text = error.Message;
            HelpKeyword = error.HelpLink;

            if (Text.Length == 0) {
                Text = error.ToString();
            }

            // UNDONE: How do we generate this info for non-code thingies?  This must be
            // generic, or at least extensible.

            while(error != null) {
                System.ComponentModel.Design.Serialization.CodeDomSerializerException cdex;
                System.Xml.XmlException xmlex;
                 
                if ((cdex = error as System.ComponentModel.Design.Serialization.CodeDomSerializerException) != null) {
                    System.CodeDom.CodeLinePragma lp = cdex.LinePragma;
                    if (lp != null) {
                        Document = lp.FileName;
                        Line = lp.LineNumber;
                    }
                    break;
                }
                else if ((xmlex = error as System.Xml.XmlException) != null) {
                    Line = xmlex.LineNumber - 1;
                    break;
                }
                error = error.InnerException;
            }
        }


        /// <include file='doc\Task.uex' path='docs/doc[@for="Task.CanDelete"]/*' />
        public bool CanDelete {
            get {
                return canDelete;
            }
            set {
                if (canDelete != value) {
                    canDelete = value;
                    UpdateOwner();
                }
            }
        }
        
        /// <include file='doc\Task.uex' path='docs/doc[@for="Task.Category"]/*' />
        public TaskCategory Category {
            get {
                return category; 
            }
            set {
                if (category != value) {
                    category = value;
                    UpdateOwner();
                }
            }
        }
        
        /// <include file='doc\Task.uex' path='docs/doc[@for="Task.Checked"]/*' />
        public bool Checked {
            get {
                return isChecked;
            }
            set {
                if (isChecked != value) {
                    isChecked = value;
                    UpdateOwner();
                }
            }
        }
        
        /// <include file='doc\Task.uex' path='docs/doc[@for="Task.Column"]/*' />
        public int Column {
            get {
                return column;
            }
            set {
                if (column != value) {
                    column = value;
                    UpdateOwner();
                }
            }
        }

        /// <include file='doc\Task.uex' path='docs/doc[@for="Task.Document"]/*' />
        public string Document { 
            get {
                return document;
            }
            set {
                if (value == null) {
                    value = string.Empty;
                }
                if (document != value) {
                    document = value;
                    UpdateOwner();
                }
            }
        }

        /// <include file='doc\Task.uex' path='docs/doc[@for="Task.HelpKeyword"]/*' />
        public string HelpKeyword {
            get {
                return helpKeyword;
            }
            set {
                if (value == null) {
                    value = string.Empty;
                }

                if (helpKeyword != value) {
                    helpKeyword = value;
                    UpdateOwner();
                }
            }
        }
        
        /// <include file='doc\Task.uex' path='docs/doc[@for="Task.ImageIndex"]/*' />
        public int ImageIndex {
            get {
                return imageIndex;
            }
            set {
                if (imageIndex != value) {
                    imageIndex = value;
                    UpdateOwner();
                }
            }
        }
        
        /// <include file='doc\Task.uex' path='docs/doc[@for="Task.IsCheckedEditable"]/*' />
        public bool IsCheckedEditable {
            get {
                return checkedEditable;
            }
            set {
                if (checkedEditable != value) {
                    checkedEditable = value;
                    UpdateOwner();
                }
            }
        }
        
        /// <include file='doc\Task.uex' path='docs/doc[@for="Task.IsPriorityEditable"]/*' />
        public bool IsPriorityEditable {
            get {
                return priorityEditable;
            }
            set {
                if (priorityEditable != value) {
                    priorityEditable = value;
                    UpdateOwner();
                }
            }
        }
        
        /// <include file='doc\Task.uex' path='docs/doc[@for="Task.IsTextEditable"]/*' />
        public bool IsTextEditable {
            get {
                return textEditable;
            }
            set {
                if (textEditable != value) {
                    textEditable = value;
                    UpdateOwner();
                }
            }
        }
        
        /// <include file='doc\Task.uex' path='docs/doc[@for="Task.Line"]/*' />
        public int Line {
            get {
                return line;
            }
            set {
                if (line != value) {
                    line = value;
                    UpdateOwner();
                }
            }
        }

        internal TaskProvider Owner {
            get {
                return owner;
            }
            set {
                if (owner != null && value == null) {
                    OnRemoved(EventArgs.Empty);
                }
                owner = value;
            }
        }
        
        /// <include file='doc\Task.uex' path='docs/doc[@for="Task.Priority"]/*' />
        public TaskPriority Priority {
            get {
                return priority;
            }
            set {
                if (priority != value) {
                    priority = value;
                    UpdateOwner();
                }
            }
        }
        
        /// <include file='doc\Task.uex' path='docs/doc[@for="Task.SubcategoryIndex"]/*' />
        public int SubcategoryIndex {
            get {
                return subCategoryIndex;
            }
            set {
                if (subCategoryIndex != value) {
                    subCategoryIndex = value;
                    UpdateOwner();
                }
            }
        }
        
        /// <include file='doc\Task.uex' path='docs/doc[@for="Task.Text"]/*' />
        public string Text {
            get {
                return text;
            }
            set {
                if (value == null) {
                    value = string.Empty;
                }
                if (text != value) {
                    text = value;
                    UpdateOwner();
                }
            }
        }
        
        /// <include file='doc\Task.uex' path='docs/doc[@for="Task.Deleted"]/*' />
        public event EventHandler Deleted;

        /// <include file='doc\Task.uex' path='docs/doc[@for="Task.Removed"]/*' />
        public event EventHandler Removed;
        
        /// <include file='doc\Task.uex' path='docs/doc[@for="Task.Help"]/*' />
        public event EventHandler Help;
        
        /// <include file='doc\Task.uex' path='docs/doc[@for="Task.Navigate"]/*' />
        public event EventHandler Navigate;
        
        /// <include file='doc\Task.uex' path='docs/doc[@for="Task.OnDeleted"]/*' />
        protected virtual void OnDeleted(EventArgs e) {
            if (Deleted != null) {
                Deleted(this, e);
            }
        }
        /// <include file='doc\Task.uex' path='docs/doc[@for="Task.OnRemoved"]/*' />
        protected virtual void OnRemoved(EventArgs e) {
            if (Removed != null) {
                Removed(this, e);
            }
        }        
        /// <include file='doc\Task.uex' path='docs/doc[@for="Task.OnHelp"]/*' />
        protected virtual void OnHelp(EventArgs e) {

            if (HelpKeyword.Length > 0 && owner != null) {
                IHelpService help = owner.GetService(typeof(IHelpService)) as IHelpService;
                Debug.Assert(help != null, "We can't find a help service in the service provider");
                if (help != null) {
                    help.ShowHelpFromKeyword(HelpKeyword);
                }
            }

            if (Help != null) {
                Help(this, e);
            }
        }
        
        /// <include file='doc\Task.uex' path='docs/doc[@for="Task.OnNavigate"]/*' />
        protected virtual void OnNavigate(EventArgs e) {
            if (Navigate != null) {
                Navigate(this, e);
            }
        }

        private void UpdateOwner() {
            if (owner != null) {
                owner.Refresh();
            }
        }

        private string GetDisplayName(string fileName) {
            if (owner != null) {
            IVsRunningDocumentTable pRDT = (IVsRunningDocumentTable)owner.GetService(typeof(SVsRunningDocumentTable));
            if (pRDT != null) {
                IntPtr punkDocData;
                uint docCookie;
                uint[] pitemid = new uint[1];
                IVsHierarchy ppIVsHierarchy;
                int hr = pRDT.FindAndLockDocument((uint)_VSRDTFLAGS.RDT_NoLock, fileName, out ppIVsHierarchy, out pitemid[0], out punkDocData, out docCookie);
                if (NativeMethods.Succeeded(hr) && punkDocData != IntPtr.Zero && ppIVsHierarchy != null)
                {
                    Marshal.Release(punkDocData);
                    object isNew;
                    hr = ppIVsHierarchy.GetProperty(pitemid[0], (int)__VSHPROPID.VSHPROPID_IsNewUnsavedItem, out isNew);
                    if (NativeMethods.Succeeded(hr) && (bool)isNew) {
                        object fileCaption;
                        hr = ppIVsHierarchy.GetProperty(pitemid[0], (int)__VSHPROPID.VSHPROPID_Caption, out fileCaption);
                        string caption = fileCaption as string;
                        if (NativeMethods.Succeeded(hr) && !String.IsNullOrEmpty(caption))
                        {
                            return caption;
                        }
                    }
                }
            }
            }
            return fileName;
        }

        private string GetCaption() {
            if (caption == null) {
                caption = GetDisplayName(document);
            }
            return caption;
        }

        #region IVsTaskItem

        /// <include file='doc\Task.uex' path='docs/doc[@for="Task.IVsTaskItem.CanDelete"]/*' />
        /// <internalonly/>
        int IVsTaskItem.CanDelete(out int fdelete) {
            fdelete = (CanDelete) ? 1 : 0;
            return NativeMethods.S_OK;
        }

        /// <include file='doc\Task.uex' path='docs/doc[@for="Task.IVsTaskItem.Category"]/*' />
        /// <internalonly/>
        int IVsTaskItem.Category(VSTASKCATEGORY[] cat) {
            if (cat != null) {
                cat[0] = (VSTASKCATEGORY)(uint)Category;
            }
            return NativeMethods.S_OK;
        }

        /// <include file='doc\Task.uex' path='docs/doc[@for="Task.IVsTaskItem.Column"]/*' />
        /// <internalonly/>
        int IVsTaskItem.Column(out int col) {
            col = Column;
            return NativeMethods.S_OK;
        }

        /// <include file='doc\Task.uex' path='docs/doc[@for="Task.IVsTaskItem.Document"]/*' />
        /// <internalonly/>
        int IVsTaskItem.Document(out string doc) {
            doc = GetCaption();
            return NativeMethods.S_OK;
        }

        /// <include file='doc\Task.uex' path='docs/doc[@for="Task.IVsTaskItem.HasHelp"]/*' />
        /// <internalonly/>
        int IVsTaskItem.HasHelp(out int fHelp) {
            fHelp = (Help != null || (HelpKeyword != null && owner!=null)) ? 1 : 0;
            return NativeMethods.S_OK;
        }

        /// <include file='doc\Task.uex' path='docs/doc[@for="Task.IVsTaskItem.ImageListIndex"]/*' />
        /// <internalonly/>
        int IVsTaskItem.ImageListIndex(out int index) {
            index = ImageIndex;
            return NativeMethods.S_OK;
        }

        /// <include file='doc\Task.uex' path='docs/doc[@for="Task.IVsTaskItem.IsReadOnly"]/*' />
        /// <internalonly/>
        int IVsTaskItem.IsReadOnly(VSTASKFIELD field, out int fReadOnly) {

            bool readOnly = true;

            switch(field) {
                case VSTASKFIELD.FLD_CHECKED:
                    readOnly = !IsCheckedEditable;
                    break;
                case VSTASKFIELD.FLD_PRIORITY:
                    readOnly = !IsPriorityEditable;
                    break;
                case VSTASKFIELD.FLD_DESCRIPTION:
                    readOnly = !IsTextEditable;
                    break;
            }

            fReadOnly = (readOnly) ? 1 : 0;
            return NativeMethods.S_OK;
        }

        /// <include file='doc\Task.uex' path='docs/doc[@for="Task.IVsTaskItem.Line"]/*' />
        /// <internalonly/>
        int IVsTaskItem.Line(out int line) {
            line = Line;
            return NativeMethods.S_OK;
        }

        /// <include file='doc\Task.uex' path='docs/doc[@for="Task.IVsTaskItem.NavigateTo"]/*' />
        /// <internalonly/>
        int IVsTaskItem.NavigateTo() {
            OnNavigate(EventArgs.Empty);
            return NativeMethods.S_OK;
        }

        /// <include file='doc\Task.uex' path='docs/doc[@for="Task.IVsTaskItem.NavigateToHelp"]/*' />
        /// <internalonly/>
        int IVsTaskItem.NavigateToHelp() {
            OnHelp(EventArgs.Empty);
            return NativeMethods.S_OK;
        }

        /// <include file='doc\Task.uex' path='docs/doc[@for="Task.IVsTaskItem.OnDeleteTask"]/*' />
        /// <internalonly/>
        int IVsTaskItem.OnDeleteTask() {
            OnDeleted(EventArgs.Empty);
            return NativeMethods.S_OK;
        }

        /// <include file='doc\Task.uex' path='docs/doc[@for="Task.IVsTaskItem.OnFilterTask"]/*' />
        /// <internalonly/>
        int IVsTaskItem.OnFilterTask(int f) {
            return NativeMethods.S_OK;
        }

        /// <include file='doc\Task.uex' path='docs/doc[@for="Task.IVsTaskItem.SubcategoryIndex"]/*' />
        /// <internalonly/>
        int IVsTaskItem.SubcategoryIndex(out int index) {
            index = SubcategoryIndex;
            if ( index < 0 )
            {
                return NativeMethods.E_FAIL;
            }
            return NativeMethods.S_OK;
        }

        /// <include file='doc\Task.uex' path='docs/doc[@for="Task.IVsTaskItem.get_Checked"]/*' />
        /// <internalonly/>
        int IVsTaskItem.get_Checked(out int f) {
            f = Checked ? 1 : 0;
            return NativeMethods.S_OK;
        }

        /// <include file='doc\Task.uex' path='docs/doc[@for="Task.IVsTaskItem.get_Priority"]/*' />
        /// <internalonly/>
        int IVsTaskItem.get_Priority(VSTASKPRIORITY[] pri) {
            if (pri != null) {
                pri[0] = (VSTASKPRIORITY)(uint)Priority;
            }
            return NativeMethods.S_OK;
        }

        /// <include file='doc\Task.uex' path='docs/doc[@for="Task.IVsTaskItem.get_Text"]/*' />
        /// <internalonly/>
        int IVsTaskItem.get_Text(out string text) {
            text = Text;
            return NativeMethods.S_OK;
        }

        /// <include file='doc\Task.uex' path='docs/doc[@for="Task.IVsTaskItem.put_Checked"]/*' />
        /// <internalonly/>
        int IVsTaskItem.put_Checked(int f) {
            isChecked = f != 0;  // don't call property, as it will call back to the task list
            return NativeMethods.S_OK;
        }

        /// <include file='doc\Task.uex' path='docs/doc[@for="Task.IVsTaskItem.put_Priority"]/*' />
        /// <internalonly/>
        int IVsTaskItem.put_Priority(VSTASKPRIORITY pri) {
            priority = (TaskPriority)(uint)pri;
            return NativeMethods.S_OK;
        }

        /// <include file='doc\Task.uex' path='docs/doc[@for="Task.IVsTaskItem.put_Text"]/*' />
        /// <internalonly/>
        int IVsTaskItem.put_Text(string t) {
            text = t;
            return NativeMethods.S_OK;
        }
        #endregion

        #region IVsProvideUserContext Members

        /// <include file='doc\Task.uex' path='docs/doc[@for="Task.GetUserContext"]/*' />
        public int GetUserContext(out IVsUserContext ppctx)
        {
            int hr = NativeMethods.S_OK;
            if (context == null)
            {
                // Create an empty context
                IVsMonitorUserContext monitorContext = owner.GetService(typeof(SVsMonitorUserContext)) as IVsMonitorUserContext;
                NativeMethods.ThrowOnFailure(monitorContext.CreateEmptyContext(out context));

                // Add the required information to the context
                hr = context.AddAttribute(VSUSERCONTEXTATTRIBUTEUSAGE.VSUC_Usage_LookupF1, contextNameKeyword, this.HelpKeyword);
            }
            ppctx = context;

            return hr;
        }

        #endregion
    }


    /// <include file='doc\Task.uex' path='docs/doc[@for="ErrorTask"]' />
    /// <devdoc>
    ///     This class implements IVsErrorItem.  
    /// </devdoc>
    [CLSCompliant(false)]
    [System.Runtime.InteropServices.ComVisible(true)]
    public class ErrorTask : Task, IVsErrorItem {

        IVsHierarchy        item;
        TaskErrorCategory   category;

        /// <include file='doc\Task.uex' path='docs/doc[@for="ErrorTask.ErrorTask"]/*' />
        public ErrorTask() {
            category = TaskErrorCategory.Error;
        }

        /// <include file='doc\Task.uex' path='docs/doc[@for="ErrorTask.ErrorTask1"]/*' />
        public ErrorTask(Exception error) : base(error) {
        }

        /// Get/Set the error category associated with this task.
        public TaskErrorCategory ErrorCategory {
            get {
                return category;
            }
            set {
                category = value;
            }
        }

        /// <include file='doc\Task.uex' path='docs/doc[@for="ErrorTask.Project"]/*' />
        /// Get/Set the hierarchy item associated with this task.
        public IVsHierarchy HierarchyItem {
            get { return this.item; }
            set { this.item = value; }
        }

        /// <include file='doc\Task.uex' path='docs/doc[@for="Task.IVsErrorItem.GetProject"]/*' />
        /// todo: This method will soon switch to out IVsHierarchy ppProject
        int IVsErrorItem.GetHierarchy(out IVsHierarchy ppHier) {
            ppHier = this.item;
            return NativeMethods.S_OK;
        }

        /// <include file='doc\Task.uex' path='docs/doc[@for="Task.IVsErrorItem.GetCategory"]/*' />
        int IVsErrorItem.GetCategory(out uint pCategory) {
            pCategory = (uint)ErrorCategory;
            return NativeMethods.S_OK;
        }
    }
}

