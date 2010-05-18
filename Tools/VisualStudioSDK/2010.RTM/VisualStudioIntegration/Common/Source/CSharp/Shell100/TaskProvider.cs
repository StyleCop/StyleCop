//------------------------------------------------------------------------------
// <copyright file="TaskProvider.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>                                                                
//------------------------------------------------------------------------------

namespace Microsoft.VisualStudio.Shell {

    using Microsoft.VisualStudio.OLE.Interop;
    using Microsoft.VisualStudio.Shell.Interop;
    using Microsoft.VisualStudio.TextManager.Interop;
    using Microsoft.Win32;
    using System;
    using System.Collections;
    using System.Collections.Specialized;
    using System.ComponentModel;
    using System.ComponentModel.Design;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    using System.Windows.Forms.Design;

    using IOleServiceProvider = Microsoft.VisualStudio.OLE.Interop.IServiceProvider;
    using IServiceProvider = System.IServiceProvider;

    /// <include file='doc\TaskProvider.uex' path='docs/doc[@for="TaskProvider"]' />
    /// <devdoc>
    ///     This class implements IVsTaskProvider.  It provides a 
    ///     framework-friendly way to define a package and its associated 
    ///     services.  
    /// </devdoc>
    [CLSCompliant(false)]
    [System.Runtime.InteropServices.ComVisible(true)]
    public class TaskProvider :

        IVsTaskProvider,
        IVsTaskProvider2,
        IVsTaskProvider3,
        IDisposable {

        internal IServiceProvider       provider;
        internal ImageList              imageList;
        internal IVsTaskList            taskList;
        internal uint                   taskListCookie;
        internal TaskCollection         tasks;
        internal StringCollection       subCategories;
        internal int                    suspended;
        internal bool                   dirty;
        internal Guid                   providerGuid;
        internal string                 name;
        internal bool                   alwaysVisible;
        internal bool                   disableAutoRoute;
        internal Guid                   toolbarGroup;
        internal int                    toolbarId;
        internal bool                   maintainOrder;
        private  bool                   inFinalRelease;


        /// <include file='doc\TaskProvider.uex' path='docs/doc[@for="TaskProvider.TaskProvider"]/*' />
        public TaskProvider(IServiceProvider provider) {
            this.provider = provider;
        }

        /// <include file='doc\TaskProvider.uex' path='docs/doc[@for="TaskCollection.Finalize"]/*' />
        ~TaskProvider() {
            Dispose(false);
        }

        /// <include file='doc\TaskProvider.uex' path='docs/doc[@for="TaskCollection.MaintainTaskOrder"]/*' />
        /// Determines whether or not the task list should maintain the task order given to it by the task provider.
        public bool MaintainInitialTaskOrder {
            get { return this.maintainOrder; }
            set { this.maintainOrder = value; }
        }

        /// The TaskList groups all tasks from multiple providers
        /// that provide the same GUID into one list.  
        /// <include file='doc\TaskProvider.uex' path='docs/doc[@for="TaskCollection.ProviderGuid"]/*' />
        public Guid ProviderGuid {
            get { return this.providerGuid; }
            set { this.providerGuid = value; }
        }

        /// <include file='doc\TaskProvider.uex' path='docs/doc[@for="TaskCollection.ProviderName"]/*' />
        /// Returns a localized human-readable name for this data provider.
        public string ProviderName {
            get { return this.name; }
            set { this.name = value; }
        }
        
        /// <include file='doc\TaskProvider.uex' path='docs/doc[@for="TaskCollection.AlwaysVisible"]/*' />
        /// Provider is always visible in dropdown even if it has no tasks.
        public bool AlwaysVisible {
            get { return this.alwaysVisible; }
            set { this.alwaysVisible = value; }
        }

        /// <include file='doc\TaskProvider.uex' path='docs/doc[@for="TaskCollection.DisableAutoRoute"]/*' />
        /// Provider is always visible in dropdown even if it has no tasks.
        public bool DisableAutoRoute
        {
            get { return this.disableAutoRoute; }
            set { this.disableAutoRoute = value; }
        }

        // Returns a group GUID and toolbar ID indicating which toolbar should be displayed when this
        // provider is active.  Set pguidGroup and pdwID to GUID_NULL and 0, respectively, to indicate
        // that this provider has no toolbar.  If you do provide a toolbar, you must include the
        // provider dropdown as the first group, by including this line in your CTC file:
        //     guidSHLMainMenu:IDG_VS_TASKLIST_PROVIDERLIST, <your toolbar's group>:<your toolbar menu ID>, 0x0100;
        // See vscommon\appid\inc\ShellCmdPlace.ctc for examples.
        /// <include file='doc\TaskProvider.uex' path='docs/doc[@for="TaskProvider.ToolbarGroup"]/*' />
        public Guid ToolbarGroup {
            get { return this.toolbarGroup; }
            set { this.toolbarGroup = value; }
        }

        /// <include file='doc\TaskProvider.uex' path='docs/doc[@for="TaskProvider.ToolbarId"]/*' />
        public int ToolbarId {
            get { return this.toolbarId; }
            set { this.toolbarId = value; }
        }

        /// <include file='doc\TaskProvider.uex' path='docs/doc[@for="TaskProvider.ImageList"]/*' />
        public ImageList ImageList {
            get {
                return imageList;
            }
            set {
                if (imageList != value) {
                    imageList = value;
                    UpdateProviderInfo();
                }
            }
        }
        
        /// <include file='doc\TaskProvider.uex' path='docs/doc[@for="TaskProvider.Subcategories"]/*' />
        public StringCollection Subcategories {
            get {
                if (subCategories == null) {
                    subCategories = new StringCollection();
                }
                return subCategories;
            }
        }
        
        /// <include file='doc\TaskProvider.uex' path='docs/doc[@for="TaskProvider.Tasks"]/*' />
        public TaskCollection Tasks {
            get {
                if (tasks == null) {
                    tasks = new TaskCollection(this);
                }
                return tasks;
            }
        }

        /// <include file='doc\TaskProvider.uex' path='docs/doc[@for="TaskProvider.VsTaskList"]/*' />
        protected virtual IVsTaskList VsTaskList {
            get {
                if (taskList == null) {
                    taskList = GetService(typeof(SVsTaskList)) as IVsTaskList;
                    if (taskList == null) {
                        throw new InvalidOperationException(string.Format(Resources.Culture, Resources.General_MissingService, typeof(IVsTaskList).FullName));
                    }
                    NativeMethods.ThrowOnFailure( taskList.RegisterTaskProvider(this, out taskListCookie) );
                }

                return taskList;
            }
        }
        
        /// <include file='doc\TaskProvider.uex' path='docs/doc[@for="TaskProvider.Dispose"]/*' />
        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        
        /// <include file='doc\TaskProvider.uex' path='docs/doc[@for="TaskProvider.Dispose1"]/*' />
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
        protected virtual void Dispose(bool disposing)
        {
			if (disposing)
			{
				if (tasks != null && !inFinalRelease)
				{
					tasks.Clear();
					tasks = null;
				}

				if (taskList != null)
				{
					try
					{
						// Don't check for the result code because here we can't do anything in case of failure
						taskList.UnregisterTaskProvider(taskListCookie);
					}
					catch (Exception)
					{ /* do nothing */ }
					taskList = null;
				}

				if (imageList != null)
				{
					imageList.Dispose();
					imageList = null;
				}
			}
        }

        /// <include file='doc\TaskProvider.uex' path='docs/doc[@for="TaskProvider.GetService"]/*' />
        protected internal object GetService(Type serviceType) {
            if (provider != null) {
                return provider.GetService(serviceType);
            }
            return null;
        }
        
        /// <include file='doc\TaskProvider.uex' path='docs/doc[@for="Navigate"]/*' />
        /// <devdoc>
        ///     Navigates the document in the given task to the given logical view.
        /// </devdoc>
        public bool Navigate(Task task, Guid logicalView) {

            if (task == null) {
                throw new ArgumentNullException("task");
            }

            // Get the doc data for the task's document
            if (task.Document == null || task.Document.Length == 0) {
                return false;
            }

            IVsUIShellOpenDocument openDoc = GetService(typeof(IVsUIShellOpenDocument)) as IVsUIShellOpenDocument;
            if (openDoc == null) {
                return false;
            }

            IVsWindowFrame frame;
            IOleServiceProvider sp;
            IVsUIHierarchy hier;
            uint itemid;
            Guid logView = logicalView;

            if (NativeMethods.Failed(openDoc.OpenDocumentViaProject(task.Document, ref logView, out sp, out hier, out itemid, out frame)) || frame == null) {
                return false;
            }

            object docData;
            frame.GetProperty((int)__VSFPROPID.VSFPROPID_DocData, out docData);

            VsTextBuffer buffer = docData as VsTextBuffer;
            if (buffer == null) {
                IVsTextBufferProvider bufferProvider = docData as IVsTextBufferProvider;
                if (bufferProvider != null) {
                    IVsTextLines lines;
                    NativeMethods.ThrowOnFailure(bufferProvider.GetTextBuffer(out lines));
                    buffer = lines as VsTextBuffer;
                    Debug.Assert(buffer != null, "IVsTextLines does not implement IVsTextBuffer");
                    if (buffer == null) {
                        return false;
                    }
                }
            }

            // Finally, perform the navigation.
            IVsTextManager mgr = GetService(typeof(VsTextManagerClass)) as IVsTextManager;

            if (mgr == null) {
                return false;
            }

            int line = task.Line;
            // Buffer is zero based
            if (line > 0) line--;

            mgr.NavigateToLineAndColumn(buffer, ref logicalView, line, 0, line, 0);
            return true;
        }

        /// <include file='doc\TaskProvider.uex' path='docs/doc[@for="TaskProvider.Refresh"]/*' />
        public void Refresh() {
            if (suspended == 0) {
                dirty = false;
                NativeMethods.ThrowOnFailure( VsTaskList.RefreshTasks(taskListCookie) );
            } else {
                dirty = true;
            }
        }

        /// <include file='doc\TaskProvider.uex' path='docs/doc[@for="TaskProvider.Show"]/*' />
        public virtual void Show() {
            IUIService uis = GetService(typeof(IUIService)) as IUIService;
            if (uis != null) {
                uis.ShowToolWindow(new Guid(EnvDTE.Constants.vsWindowKindTaskList));
            }
        }

        /// <include file='doc\TaskProvider.uex' path='docs/doc[@for="TaskProvider.SuspendRefresh"]/*' />
        /// <devdoc>
        /// SuspendRefresh stops refresh of the task list from happening until ResumeRefresh
        /// is called.  It supports nested Suspend/Resume.  The reason for this method is because
        /// by default, every change to the TaskCollection results in a call to Refresh, and
        /// the task list updates synchronously when Refresh() is called, so this allows 
        /// batching of the updates to occur which results in cleaner UI experience.  For
        /// example, without this refreshing a long task list will cause the task list scrollbar 
        /// to shrink and grow in a very visible way. By calling Suspend/Resume instead the
        /// the update of the a longs task list happens with very little visual noise.
        /// </devdoc>
        public void SuspendRefresh()
        {
            if (suspended < int.MaxValue)
                suspended++;
            else
                Debug.Fail("TaskProvider.SuspendRefresh() was called int.MaxValue times.\nYou may want to change the counter to something bigger then an int");
        }

        /// <include file='doc\TaskProvider.uex' path='docs/doc[@for="TaskProvider.ResumeRefresh"]/*' />
        public void ResumeRefresh() {
            if (suspended > 0) {
                suspended--;
                if (suspended == 0 && dirty) {
                    Refresh();
                }
            }
        }

        private void TasksChanged() {
            Refresh();
        }

        private void UpdateProviderInfo() {
            if (taskList != null) {
                NativeMethods.ThrowOnFailure( taskList.UpdateProviderInfo(taskListCookie) );
            }
        }

        /// <include file='doc\TaskProvider.uex' path='docs/doc[@for="TaskProvider.IVsTaskProvider.EnumTaskItems"]/*' />
        /// <internalonly/>
        int IVsTaskProvider.EnumTaskItems(out IVsEnumTaskItems items) {
            items = new VsEnumTaskItems(Tasks);
            return NativeMethods.S_OK;
        }

        /// <include file='doc\TaskProvider.uex' path='docs/doc[@for="TaskProvider.IVsTaskProvider.ImageList"]/*' />
        /// <internalonly/>
        int IVsTaskProvider.ImageList(out IntPtr himagelist) {
            if (ImageList != null) {
                HandleRef hRef = new HandleRef(null, ImageList.Handle);
                himagelist = UnsafeNativeMethods.ImageList_Duplicate(hRef);
            }
            else {
                himagelist = IntPtr.Zero;
            }
            return NativeMethods.S_OK;
        }

        /// <include file='doc\TaskProvider.uex' path='docs/doc[@for="TaskProvider.IVsTaskProvider.OnTaskListFinalRelease"]/*' />
        /// <internalonly/>
        int IVsTaskProvider.OnTaskListFinalRelease(IVsTaskList taskList) {
            inFinalRelease = true;
            Dispose(true);
            return NativeMethods.S_OK;
        }

        /// <include file='doc\TaskProvider.uex' path='docs/doc[@for="TaskProvider.IVsTaskProvider.ReRegistrationKey"]/*' />
        /// <internalonly/>
        int IVsTaskProvider.ReRegistrationKey(out string key) {
            key = string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0}.{1}", this.GetType().Name, this.GetHashCode());
            return NativeMethods.S_OK;
        }

        /// <include file='doc\TaskProvider.uex' path='docs/doc[@for="TaskProvider.IVsTaskProvider.SubcategoryList"]/*' />
        /// <internalonly/>
        int IVsTaskProvider.SubcategoryList(uint cbstr, string[] rgbstr, out uint cnt) {
            cnt = 0;
            if (null == rgbstr) {
                if (0 == cbstr) {
                    cnt = (null == subCategories) ? 0 : (uint)subCategories.Count;
                    return NativeMethods.S_OK;
                }
                throw new ArgumentNullException("rgbstr");
            }
            if (subCategories != null) {
                for (cnt = 0; cnt < cbstr && cnt < subCategories.Count; ++cnt) {
                    rgbstr[(int)cnt] = subCategories[(int)cnt];
                }

            }
            return NativeMethods.S_OK;
        }

        /// <include file='doc\TaskProvider.uex' path='docs/doc[@for="TaskProvider.IVsTaskProvider2.EnumTaskItems"]/*' />
        /// <internalonly/>
        int IVsTaskProvider2.EnumTaskItems(out IVsEnumTaskItems items) {
            return ((IVsTaskProvider)this).EnumTaskItems(out items);
        }

        /// <include file='doc\TaskProvider.uex' path='docs/doc[@for="TaskProvider.IVsTaskProvider2.ImageList"]/*' />
        /// <internalonly/>
        int IVsTaskProvider2.ImageList(out IntPtr himagelist) {
            return ((IVsTaskProvider)this).ImageList(out himagelist);
        }

        /// <include file='doc\TaskProvider.uex' path='docs/doc[@for="TaskProvider.IVsTaskProvider2.OnTaskListFinalRelease"]/*' />
        /// <internalonly/>
        int IVsTaskProvider2.OnTaskListFinalRelease(IVsTaskList taskList) {
            return ((IVsTaskProvider)this).OnTaskListFinalRelease(taskList);
        }

        /// <include file='doc\TaskProvider.uex' path='docs/doc[@for="TaskProvider.IVsTaskProvider2.ReRegistrationKey"]/*' />
        /// <internalonly/>
        int IVsTaskProvider2.ReRegistrationKey(out string key) {
            return ((IVsTaskProvider)this).ReRegistrationKey(out key);
        }

        /// <include file='doc\TaskProvider.uex' path='docs/doc[@for="TaskProvider.IVsTaskProvider2.SubcategoryList"]/*' />
        /// <internalonly/>
        int IVsTaskProvider2.SubcategoryList(uint cbstr, string[] rgbstr, out uint cnt) {
            return ((IVsTaskProvider)this).SubcategoryList(cbstr, rgbstr, out cnt);
        }

        /// <include file='doc\TaskProvider.uex' path='docs/doc[@for="TaskProvider.IVsTaskProvider2.MaintainInitialTaskOrder"]/*' />
        /// <internalonly/>
        int IVsTaskProvider2.MaintainInitialTaskOrder(out int fMaintainOrder) {
            fMaintainOrder = this.maintainOrder ? 1 : 0;
            return NativeMethods.S_OK;
        }

        // Returns the behavior flags for this provider.
        /// <include file='doc\TaskProvider.uex' path='docs/doc[@for="TaskProvider.IVsTaskProvider3.GetProviderFlags"]/*' />
        /// <internalonly/>
        int IVsTaskProvider3.GetProviderFlags(out uint tpfFlags){
            tpfFlags = (this.alwaysVisible) ? (uint)__VSTASKPROVIDERFLAGS.TPF_ALWAYSVISIBLE : 0;
            if (disableAutoRoute)
                tpfFlags |= (uint)__VSTASKPROVIDERFLAGS.TPF_NOAUTOROUTING;
            return NativeMethods.S_OK; 
        }
        
        /// <include file='doc\TaskProvider.uex' path='docs/doc[@for="TaskProvider.IVsTaskProvider3.GetProviderName"]/*' />
        /// <internalonly/>
        int IVsTaskProvider3.GetProviderName(out string pbstrName){
            pbstrName = this.name;
            return NativeMethods.S_OK;
        }

        /// <include file='doc\TaskProvider.uex' path='docs/doc[@for="TaskProvider.IVsTaskProvider3.GetProviderGuid"]/*' />
        /// <devdoc>
        /// Returns a unique ID for this provider.  This is used to persist and restore per-provider
        /// data managed by the task list, such as user customizations of column width and order.
        /// </devdoc>
        /// <internalonly/>
        int IVsTaskProvider3.GetProviderGuid(out Guid pguidProvider) {
            pguidProvider = this.GetType().GUID;
            return NativeMethods.S_OK;
        }

        /// <include file='doc\TaskProvider.uex' path='docs/doc[@for="TaskProvider.IVsTaskProvider3.GetProviderToolbar"]/*' />
        /// <internalonly/>
        int IVsTaskProvider3.GetProviderToolbar(out Guid pguidGroup, out uint pdwID) {
            pguidGroup = this.toolbarGroup;
            pdwID = (uint)this.toolbarId;
            return NativeMethods.S_OK;
        }

        /// <include file='doc\TaskProvider.uex' path='docs/doc[@for="TaskCollection.IVsTaskProvider3.GetColumnCount"]/*' />
        // Returns the total number of columns supported by this provider, including columns that are
        // not visible by default.
        int IVsTaskProvider3.GetColumnCount(out int count) {
            // todo: provide a way to define custom columns
            // right now it is getting default behavior for free.
            count = 0;
            return NativeMethods.E_FAIL;
        }

        /// <include file='doc\TaskProvider.uex' path='docs/doc[@for="TaskCollection.IVsTaskProvider3.GetColumn"]/*' />
        // Gets the definition of an indexed column (0 <= iColumn < nColumns).
        int IVsTaskProvider3.GetColumn(int iColumn, VSTASKCOLUMN[] pColumn) {
            return NativeMethods.E_FAIL;
        }

        /// <include file='doc\TaskProvider.uex' path='docs/doc[@for="TaskCollection.IVsTaskProvider3.GetSurrogateProviderGuid"]/*' />
        int IVsTaskProvider3.GetSurrogateProviderGuid(out System.Guid guid) {
            guid = Guid.Empty;
            return NativeMethods.E_NOTIMPL;
        }

        /// <include file='doc\TaskProvider.uex' path='docs/doc[@for="TaskCollection.IVsTaskProvider3.OnBeginTaskEdit"]/*' />
        // Called when the user begins editing a task in-place.  Providers may want to avoid scrolling
        // the tasklist or changing the selection during editing, since these actions can force in-
        // place edit mode to be canceled abruptly.
        int IVsTaskProvider3.OnBeginTaskEdit(IVsTaskItem item) {
            return NativeMethods.S_OK;
        }

        /// <include file='doc\TaskProvider.uex' path='docs/doc[@for="TaskCollection.IVsTaskProvider3.OnEndTaskEdit"]/*' />
        // Called when the user finishes editing a task in-place.  fCommitChanges indicates whether the
        // user chose to commit the changes or discard them.  This method may set *pfAllowChanges to
        // FALSE to disallow the user from exiting edit mode.  If fCommitChanges is TRUE, the changes
        // will have already been persisted down to the task item.
        int IVsTaskProvider3.OnEndTaskEdit(IVsTaskItem item, int fCommitChanges, out int fAllowChanges) {
            fAllowChanges = 1;
            return NativeMethods.S_OK;
        }

        /// <include file='doc\TaskProvider.uex' path='docs/doc[@for="TaskCollection"]/*' />
        public sealed class TaskCollection :

            IList {

            private TaskProvider owner;
            private ArrayList list;

            /// <include file='doc\TaskProvider.uex' path='docs/doc[@for="TaskCollection.TaskCollection"]/*' />
            public TaskCollection(TaskProvider owner) {
                if (null == owner) {
                    throw new ArgumentNullException("owner");
                }
                this.owner = owner;
                this.list = new ArrayList();
            }

            /// <include file='doc\TaskProvider.uex' path='docs/doc[@for="TaskCollection.Count"]/*' />
            public int Count {
                get {
                    return list.Count;
                }
            }

            /// <include file='doc\TaskProvider.uex' path='docs/doc[@for="TaskCollection.this"]/*' />
            public Task this[int index] {
                get {
                    return (Task)list[index];
                }
                set {
                    if (value == null) {
                        throw new ArgumentNullException("value");
                    }
                    Task t = this[index];
                    if (t != null) {
                        t.Owner = null;
                    }
                    list[index] = value;
                    value.Owner = owner;
                    owner.TasksChanged();
                }
            }

            /// <include file='doc\TaskProvider.uex' path='docs/doc[@for="TaskCollection.Add"]/*' />
            public int Add(Task task) {
                if (task == null) {
                    throw new ArgumentNullException("task");
                }
                int index = list.Add(task);
                task.Owner = owner;
                owner.TasksChanged();
                return index;
            }

            /// <include file='doc\TaskProvider.uex' path='docs/doc[@for="TaskCollection.Clear"]/*' />
            public void Clear() {
                if (list.Count > 0) {
                    foreach (Task t in list) {
                        t.Owner = null;
                    }
                    list.Clear();
                    owner.TasksChanged();
                }
            }

            /// <include file='doc\TaskProvider.uex' path='docs/doc[@for="TaskCollection.Contains"]/*' />
            public bool Contains(Task task) {
                return list.Contains(task);
            }

            private void EnsureTask(object obj) {
                if (!(obj is Task)) {
                    throw new ArgumentException(string.Format(Resources.Culture, Resources.General_InvalidType, typeof(Task).FullName), "obj");
                }
            }

            /// <include file='doc\TaskProvider.uex' path='docs/doc[@for="TaskCollection.GetEnumerator"]/*' />
            public IEnumerator GetEnumerator() {
                return list.GetEnumerator();
            }

            /// <include file='doc\TaskProvider.uex' path='docs/doc[@for="TaskCollection.IndexOf"]/*' />
            public int IndexOf(Task task) {
                return list.IndexOf(task);
            }

            /// <include file='doc\TaskProvider.uex' path='docs/doc[@for="TaskCollection.Insert"]/*' />
            public void Insert(int index, Task task) {
                if (task == null) {
                    throw new ArgumentNullException("task");
                }
                list.Insert(index, task);
                task.Owner = owner;
                owner.TasksChanged();
            }

            /// <include file='doc\TaskProvider.uex' path='docs/doc[@for="TaskCollection.Remove"]/*' />
            public void Remove(Task task) {
                if (task == null) {
                    throw new ArgumentNullException("task");
                }
                list.Remove(task);
                task.Owner = null;
                owner.TasksChanged();
            }

            /// <include file='doc\TaskProvider.uex' path='docs/doc[@for="TaskCollection.RemoveAt"]/*' />
            public void RemoveAt(int index) {
                Task t = this[index];
                t.Owner = null;
                list.RemoveAt(index);
                owner.TasksChanged();
            }

            /// <include file='doc\TaskProvider.uex' path='docs/doc[@for="TaskCollection.ICollection.CopyTo"]/*' />
            /// <internalonly/>
            void ICollection.CopyTo(Array array, int index) {
                list.CopyTo(array, index);
            }

            /// <include file='doc\TaskProvider.uex' path='docs/doc[@for="TaskCollection.ICollection.IsSynchronized"]/*' />
            /// <internalonly/>
            bool ICollection.IsSynchronized {
                get {
                    return false;
                }
            }

            /// <include file='doc\TaskProvider.uex' path='docs/doc[@for="TaskCollection.ICollection.SyncRoot"]/*' />
            /// <internalonly/>
            object ICollection.SyncRoot {
                get {
                    return this;
                }
            }

            /// <include file='doc\TaskProvider.uex' path='docs/doc[@for="TaskCollection.IList.IsFixedSize"]/*' />
            /// <internalonly/>
            bool IList.IsFixedSize {
                get {
                    return false;
                }
            }

            /// <include file='doc\TaskProvider.uex' path='docs/doc[@for="TaskCollection.IList.IsReadOnly"]/*' />
            /// <internalonly/>
            bool IList.IsReadOnly {
                get {
                    return false;
                }
            }

            /// <include file='doc\TaskProvider.uex' path='docs/doc[@for="TaskCollection.IList.this"]/*' />
            /// <internalonly/>
            object IList.this[int index] {
                get {
                    return this[index];
                }
                set {
                    EnsureTask(value);
                    this[index] = (Task)value;
                }
            }

            /// <include file='doc\TaskProvider.uex' path='docs/doc[@for="TaskCollection.IList.Add"]/*' />
            /// <internalonly/>
            int IList.Add(object obj) {
                EnsureTask(obj);
                return Add((Task)obj);
            }

            /// <include file='doc\TaskProvider.uex' path='docs/doc[@for="TaskCollection.IList.Clear"]/*' />
            /// <internalonly/>
            void IList.Clear() {
                Clear();
            }

            /// <include file='doc\TaskProvider.uex' path='docs/doc[@for="TaskCollection.IList.Contains"]/*' />
            /// <internalonly/>
            bool IList.Contains(object obj) {
                EnsureTask(obj);
                return Contains((Task)obj);
            }

            /// <include file='doc\TaskProvider.uex' path='docs/doc[@for="TaskCollection.IList.IndexOf"]/*' />
            /// <internalonly/>
            int IList.IndexOf(object obj) {
                EnsureTask(obj);
                return IndexOf((Task)obj);
            }

            /// <include file='doc\TaskProvider.uex' path='docs/doc[@for="TaskCollection.IList.Insert"]/*' />
            /// <internalonly/>
            void IList.Insert(int index, object obj) {
                EnsureTask(obj);
                Insert(index, (Task)obj);
            }

            /// <include file='doc\TaskProvider.uex' path='docs/doc[@for="TaskCollection.IList.Remove"]/*' />
            /// <internalonly/>
            void IList.Remove(object obj) {
                EnsureTask(obj);
                Remove((Task)obj);
            }

            /// <include file='doc\TaskProvider.uex' path='docs/doc[@for="TaskCollection.IList.RemoveAt"]/*' />
            /// <internalonly/>
            void IList.RemoveAt(int index) {
                RemoveAt(index);
            }
        }

        private class VsEnumTaskItems : IVsEnumTaskItems {

            private TaskCollection tasks;
            private IEnumerator taskEnum;

            internal VsEnumTaskItems(TaskCollection tasks) {
                this.tasks = tasks;
                this.taskEnum = tasks.GetEnumerator();
            }

            public int Clone(out IVsEnumTaskItems newItems) {
                newItems = new VsEnumTaskItems(tasks);
                return NativeMethods.S_OK;
            }

            public int Next(uint celt, IVsTaskItem[] items, uint[] pceltFetched) {
                if (items == null || items.Length < celt)
                    throw new ArgumentException(String.Empty, "items");

                uint fetched = 0;

                while (fetched < celt && taskEnum.MoveNext()) {
                    items[fetched++] = (IVsTaskItem)taskEnum.Current;
                }

                if (pceltFetched != null && pceltFetched.Length > 0) {
                    pceltFetched[0] = fetched;
                }

                if (fetched == 0 && celt > 0) {
                    return NativeMethods.S_FALSE;
                }

                return NativeMethods.S_OK;
            }

            public int Reset() {
                taskEnum.Reset();
                return NativeMethods.S_OK;
            }

            public int Skip(uint count) {
                while (count != 0) {
                    count--;
                    if (!taskEnum.MoveNext() && count != 0) {
                        return NativeMethods.S_FALSE;
                    }
                }

                return NativeMethods.S_OK;
            }
        }
    }


    // <include file='doc\TaskProvider.uex' path='docs/doc[@for="TaskProvider"]' />
    /// <include file='doc\TaskProvider.uex' path='docs/doc[@for="ErrorListProvider"]/*' />
    /// <devdoc>
    /// Use this provider to provide tasks for the Visual Studio Error List
    /// window. This task provider also has a Guid which is returned from
    /// </devdoc>
    [CLSCompliant(false)]
    public class ErrorListProvider : TaskProvider {
        IVsErrorList errorList;


        /// <include file='doc\TaskProvider.uex' path='docs/doc[@for="ErrorListProvider.TaskProvider"]/*' />
        public ErrorListProvider(IServiceProvider provider) : base(provider) {
        }

        /// <include file='doc\TaskProvider.uex' path='docs/doc[@for="ErrorListProvider.Finalize"]/*' />
        ~ErrorListProvider() {
            Dispose(false);
        }

        /// <include file='doc\TaskProvider.uex' path='docs/doc[@for="ErrorListProvider.Dispose1"]/*' />
        protected override void Dispose(bool disposing) {
            base.Dispose(disposing);
            this.errorList = null;
        }

        /// <include file='doc\TaskProvider.uex' path='docs/doc[@for="ErrorListProvider.VsTaskList"]/*' />
        protected override IVsTaskList VsTaskList {
            get {
                if (taskList == null) {

                    this.errorList = GetService(typeof(SVsErrorList)) as IVsErrorList;
                    if (errorList == null) {
                        return base.VsTaskList;
                    }
                    this.taskList = errorList as IVsTaskList;
                    if (taskList == null) {
                        throw new InvalidOperationException(string.Format(Resources.Culture, Resources.General_MissingService, typeof(IVsTaskList).FullName));
                    }
                    NativeMethods.ThrowOnFailure(taskList.RegisterTaskProvider(this, out taskListCookie));
                }

                return taskList;
            }
        }

        // Activates the window and makes it visible.  This should only be called
        // at the completion of a build process.
        /// <include file='doc\TaskProvider.uex' path='docs/doc[@for="ErrorListProvider.BringToFront"]/*' />
        public void BringToFront() {
            IVsTaskList tasklist = this.VsTaskList;
            NativeMethods.ThrowOnFailure( errorList.BringToFront() );
            tasklist = null;
        }

        // Forces the error toggle "on", so that errors are visible in the list.  Warnings and
        // informational messages are not affected.
        /// <include file='doc\TaskProvider.uex' path='docs/doc[@for="ErrorListProvider.ForceShowErrors"]/*' />
        public void ForceShowErrors() {
            IVsTaskList tasklist = this.VsTaskList;
            NativeMethods.ThrowOnFailure( errorList.ForceShowErrors() );
            tasklist = null;
        }
    
        /// <include file='doc\ErrorListProvider.uex' path='docs/doc[@for="ErrorListProvider.Show"]/*' />
        public override void Show() {
            IUIService uis = GetService(typeof(IUIService)) as IUIService;
            if (uis != null) {
                Guid errorList = new Guid(EnvDTE80.WindowKinds.vsWindowKindErrorList);
                uis.ShowToolWindow(errorList);
            }
        }
    }
}

