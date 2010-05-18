/***************************************************************************
         Copyright (c) Microsoft Corporation, All rights reserved.             
    This code sample is provided "AS IS" without warranty of any kind, 
    it is not recommended for use in a production environment.
***************************************************************************/

namespace Microsoft.VisualStudio.Shell.Flavor
{
    using System;
    using System.Diagnostics;
    using System.Globalization;
    using System.Runtime.InteropServices;
    using Microsoft.VisualStudio.Shell.Interop;
    using Microsoft.VisualStudio.OLE.Interop;
    using Microsoft.VisualStudio.Shell;

    /// <include file='doc\FlavoredProject.uex' path='docs/doc[@for="FlavoredProject"]/*' />
    /// <devdoc>
    /// A project that is a subtype/flavor of an inner project.
    /// The default behavior of all methods is to delegate to the
    /// inner project. For any behavior you want to change, simply
    /// handle the request yourself.
    /// </devdoc>
    [CLSCompliant(false)]
    public abstract class FlavoredProject : 
        Microsoft.VisualStudio.ProjectAggregator.CProjectAggregatorClass, // Provide aggregation support
        IVsAggregatableProject,
        System.IServiceProvider,
        IVsHierarchy,
        IVsUIHierarchy,
        IOleCommandTarget,
        IVsTrackProjectDocumentsEvents2
    {
        // Keep interface reference for all interface we override

        /// <include file='doc\FlavoredProject.uex' path='docs/doc[@for="FlavoredProject.innerVsAggregatableProject"]/*' />
        protected IVsAggregatableProject innerVsAggregatableProject;
        /// <include file='doc\FlavoredProject.uex' path='docs/doc[@for="FlavoredProject.innerVsHierarchy"]/*' />
        protected IVsHierarchy innerVsHierarchy;
        /// <include file='doc\FlavoredProject.uex' path='docs/doc[@for="FlavoredProject.innerVsUIHierarchy"]/*' />
        protected IVsUIHierarchy innerVsUIHierarchy;
        /// <include file='doc\FlavoredProject.uex' path='docs/doc[@for="FlavoredProject.innerOleCommandTarget"]/*' />
        protected IOleCommandTarget innerOleCommandTarget;

        /// <include file='doc\FlavoredProject.uex' path='docs/doc[@for="FlavoredProject.serviceProvider"]/*' />
        protected System.IServiceProvider serviceProvider;

        private OleMenuCommandService menuService;

        uint cookie = 0;

        /// <include file='doc\FlavoredProject.uex' path='docs/doc[@for="FlavoredProject.FlavoredProject"]/*' />
        public FlavoredProject()
        {
        }

        #region IVsAggregatableProject

        /// <devdoc>
        /// This is were all QI for interface on the inner object should happen
        /// Then set the inner project
        /// wait for InitializeForOuter to be called to do the real initialization
        /// </devdoc>
        int IVsAggregatableProject.SetInnerProject(object inner)
        {
            // delegate to the protected method
            this.SetInnerProject(inner);

            return NativeMethods.S_OK;
        }

        /// <include file='doc\FlavoredProject.uex' path='docs/doc[@for="FlavoredProject.SetInnerProject"]/*' />
        /// <devdoc>
        /// This is were all QI for interface on the inner object should happen
        /// Then set the inner project
        /// wait for InitializeForOuter to be called to do the real initialization
        /// </devdoc>
        protected virtual void SetInnerProject(object inner)
        {
            // Keep a reference to each interface we want to call on the inner project
            // we must do it now as once we call SetInner the AddRef would be forwarded to ourselves
            innerVsAggregatableProject = (IVsAggregatableProject)inner;
            innerVsHierarchy = (IVsHierarchy)inner;
            innerVsUIHierarchy = (IVsUIHierarchy)inner;
            // As should return null without throwing in the event the base project does not implement the interface
            innerOleCommandTarget = inner as IOleCommandTarget;

            // Setup our menu command service
            if (this.serviceProvider == null)
                throw new NotSupportedException("serviceProvider should have been set before SetInnerProject gets called.");
            menuService = new OleMenuCommandService(this, innerOleCommandTarget);

            // Aggregate the project
            this.SetInner(inner);
        }

        /// <devdoc>
        /// Do the initialization here (such as loading flavor specific
        /// information from the project)
        /// </devdoc>
        int IVsAggregatableProject.InitializeForOuter(string fileName, string location, string name,
            uint flags, ref Guid guidProject, out IntPtr project, out int canceled)
        {
            if (innerVsAggregatableProject == null || guidProject != NativeMethods.IID_IUnknown)
                throw new NotSupportedException();

            Marshal.QueryInterface(Marshal.GetIUnknownForObject(this), ref guidProject, out project);

            canceled = 0;
            bool cancel;
            this.InitializeForOuter(fileName, location, name, flags, ref guidProject, out cancel);
            if (cancel)
                canceled = 1;

            return NativeMethods.S_OK;
        }

        /// <include file='doc\FlavoredProject.uex' path='docs/doc[@for="FlavoredProject.InitializeForOuter"]/*' />
        /// <devdoc>
        /// Allow the project to initialize itself.
        /// At this point it possible to call the inner project
        /// Also allow canceling the project creation
        /// </devdoc>
        /// <returns>Return true to cancel the project creation</returns>
        protected virtual void InitializeForOuter(string fileName, string location, string name, uint flags, ref Guid guidProject, out bool cancel)
        {
            cancel = false;
        }
        /// <devdoc>
        /// This is called when all object in aggregation have received InitializeForOuter calls.
        /// At this point the aggregation is complete and fully functional.
        /// </devdoc>
        int IVsAggregatableProject.OnAggregationComplete()
        {
            this.OnAggregationComplete();
            if (innerVsAggregatableProject != null)
                return innerVsAggregatableProject.OnAggregationComplete();
            return NativeMethods.S_OK;
        }

        /// <include file='doc\FlavoredProject.uex' path='docs/doc[@for="FlavoredProject.OnAggregationComplete"]/*' />
        /// <devdoc>
        /// This is called when all object in aggregation have received InitializeForOuter calls.
        /// At this point the aggregation is complete and fully functional.
        /// </devdoc>
        protected virtual void OnAggregationComplete()
        {
            // This will subscribe to the IVsTrackProjectDocumentsEvents.
            // This is not required to flavor a project but makes it easier for derived class
            // to subscribe to these events.
            IVsTrackProjectDocuments2 trackDocuments = GetTrackProjectDocuments();
            ErrorHandler.ThrowOnFailure(trackDocuments.AdviseTrackProjectDocumentsEvents(this, out cookie));
        }

        /// <devdoc>
        /// This must be delegetated to the inner most project
        /// </devdoc>
        int IVsAggregatableProject.SetAggregateProjectTypeGuids(string projectTypeGuids)
        {
            if (innerVsAggregatableProject == null)
                throw new NotSupportedException();

            return innerVsAggregatableProject.SetAggregateProjectTypeGuids(projectTypeGuids);
        }

        /// <devdoc>
        /// This must be delegetated to the inner most project
        /// </devdoc>
        int IVsAggregatableProject.GetAggregateProjectTypeGuids(out string projectTypeGuids)
        {
            if (innerVsAggregatableProject == null)
                throw new NotSupportedException();

            return innerVsAggregatableProject.GetAggregateProjectTypeGuids(out projectTypeGuids);
        }

        #endregion

        #region IVsHierarchy
        //
        // Most methods call protected virtual methods which delegate to the inner project.
        // Derived classes should override those protected method if they want to change the
        // behavior.
        //

        int IVsHierarchy.AdviseHierarchyEvents(Microsoft.VisualStudio.Shell.Interop.IVsHierarchyEvents eventSink, out uint cookie)
        {
            cookie = this.AdviseHierarchyEvents(eventSink);
            return NativeMethods.S_OK;
        }

        int IVsHierarchy.Close()
        {
            if (cookie != 0)
            {
                // Unsubscribe to events
                IVsTrackProjectDocuments2 trackDocuments = GetTrackProjectDocuments();
                trackDocuments.UnadviseTrackProjectDocumentsEvents(cookie);
                cookie = 0;
            }
            this.Close();
            return NativeMethods.S_OK;
        }

        int IVsHierarchy.GetCanonicalName(uint itemId, out string name)
        {
            return this.GetCanonicalName(itemId, out name);
        }

        int IVsHierarchy.GetGuidProperty(uint itemId, int propId, out System.Guid guid)
        {
            guid = this.GetGuidProperty(itemId, propId);
            return NativeMethods.S_OK;
        }

        int IVsHierarchy.GetNestedHierarchy(uint itemId, ref System.Guid guidHierarchyNested, out System.IntPtr hierarchyNested, out uint itemIdNested)
        {
            return this.GetNestedHierarchy(itemId, ref guidHierarchyNested, out hierarchyNested, out itemIdNested);
        }

        int IVsHierarchy.GetProperty(uint itemId, int propId, out System.Object property)
        {
            // While other methods expect the protected method to throw, for GetProperty
            // we break this pattern as it is called much more often and it is legitimate to
            // return not implemented. Therefore it can help perf and debugging experience
            return this.GetProperty(itemId, propId, out property);
        }

        int IVsHierarchy.GetSite(out Microsoft.VisualStudio.OLE.Interop.IServiceProvider serviceProvider)
        {
            serviceProvider = this.GetSite();
            return NativeMethods.S_OK;
        }

        int IVsHierarchy.ParseCanonicalName(string name, out uint itemId)
        {
            return this.ParseCanonicalName(name, out itemId);
        }

        int IVsHierarchy.QueryClose(out int canClose)
        {
            canClose = 0;
            if (this.QueryClose())
                canClose = 1;
            return NativeMethods.S_OK;
        }

        int IVsHierarchy.SetGuidProperty(uint itemId, int propId, ref System.Guid guid)
        {
            this.SetGuidProperty(itemId, propId, ref guid);
            return NativeMethods.S_OK;
        }

        int IVsHierarchy.SetSite(Microsoft.VisualStudio.OLE.Interop.IServiceProvider serviceProvider)
        {
            this.serviceProvider = (System.IServiceProvider)new ServiceProvider(serviceProvider);
            NativeMethods.ThrowOnFailure(innerVsHierarchy.SetSite(serviceProvider));
            return NativeMethods.S_OK;
        }

        int IVsHierarchy.UnadviseHierarchyEvents(uint cookie)
        {
            this.UnadviseHierarchyEvents(cookie);
            return NativeMethods.S_OK;
        }

        int IVsHierarchy.SetProperty(uint itemId, int propId, System.Object property)
        {
            return this.SetProperty(itemId, propId, property);
        }

        int IVsHierarchy.Unused0()
        {
            this.Unused0();
            return NativeMethods.S_OK;
        }

        int IVsHierarchy.Unused1()
        {
            this.Unused1();
            return NativeMethods.S_OK;
        }

        int IVsHierarchy.Unused2()
        {
            this.Unused2();
            return NativeMethods.S_OK;
        }

        int IVsHierarchy.Unused3()
        {
            this.Unused3();
            return NativeMethods.S_OK;
        }

        int IVsHierarchy.Unused4()
        {
            this.Unused4();
            return NativeMethods.S_OK;
        }

        /// <include file='doc\FlavoredProject.uex' path='docs/doc[@for="FlavoredProject.AdviseHierarchyEvents"]/*' />
        protected virtual uint AdviseHierarchyEvents(Microsoft.VisualStudio.Shell.Interop.IVsHierarchyEvents eventSink)
        {
            uint cookie=0;
            NativeMethods.ThrowOnFailure(innerVsHierarchy.AdviseHierarchyEvents(eventSink, out cookie));
            return cookie;
        }

        /// <include file='doc\FlavoredProject.uex' path='docs/doc[@for="FlavoredProject.Close"]/*' />
        protected virtual void Close()
        {
            NativeMethods.ThrowOnFailure(innerVsHierarchy.Close());
        }

        /// <include file='doc\FlavoredProject.uex' path='docs/doc[@for="FlavoredProject.GetCanonicalName"]/*' />
        protected virtual int GetCanonicalName(uint itemId, out string name)
        {
            return innerVsHierarchy.GetCanonicalName(itemId, out name);
        }

        /// <include file='doc\FlavoredProject.uex' path='docs/doc[@for="FlavoredProject.GetGuidProperty"]/*' />
        protected virtual Guid GetGuidProperty(uint itemId, int propId)
        {
            Guid property;
            NativeMethods.ThrowOnFailure(innerVsHierarchy.GetGuidProperty(itemId, propId, out property));
            return property;
        }

        /// <include file='doc\FlavoredProject.uex' path='docs/doc[@for="FlavoredProject.GetNestedHierarchy"]/*' />
        protected virtual int GetNestedHierarchy(uint itemId, ref System.Guid guidHierarchyNested, out System.IntPtr hierarchyNested, out uint itemIdNested)
        {
            return innerVsHierarchy.GetNestedHierarchy(itemId, ref guidHierarchyNested, out hierarchyNested, out itemIdNested);
        }

        /// <include file='doc\FlavoredProject.uex' path='docs/doc[@for="FlavoredProject.GetProperty"]/*' />
        protected virtual int GetProperty(uint itemId, int propId, out Object property)
        {
            return innerVsHierarchy.GetProperty(itemId, propId, out property);
        }

        /// <include file='doc\FlavoredProject.uex' path='docs/doc[@for="FlavoredProject.GetSite"]/*' />
        protected virtual Microsoft.VisualStudio.OLE.Interop.IServiceProvider GetSite()
        {
            Microsoft.VisualStudio.OLE.Interop.IServiceProvider serviceProvider;
            NativeMethods.ThrowOnFailure(innerVsHierarchy.GetSite(out serviceProvider));
            return serviceProvider;
        }

        /// <include file='doc\FlavoredProject.uex' path='docs/doc[@for="FlavoredProject.ParseCanonicalName"]/*' />
        protected virtual int ParseCanonicalName(string name, out uint itemId)
        {
            return innerVsHierarchy.ParseCanonicalName(name, out itemId);
        }

        /// <include file='doc\FlavoredProject.uex' path='docs/doc[@for="FlavoredProject.QueryClose"]/*' />
        protected virtual bool QueryClose()
        {
            int canClose;
            NativeMethods.ThrowOnFailure(innerVsHierarchy.QueryClose(out canClose));
            return (canClose != 0);
        }

        /// <include file='doc\FlavoredProject.uex' path='docs/doc[@for="FlavoredProject.SetGuidProperty"]/*' />
        protected virtual void SetGuidProperty(uint itemId, int propId, ref System.Guid guid)
        {
            NativeMethods.ThrowOnFailure(innerVsHierarchy.SetGuidProperty(itemId, propId, ref guid));
        }

        /// <include file='doc\FlavoredProject.uex' path='docs/doc[@for="FlavoredProject.UnadviseHierarchyEvents"]/*' />
        protected virtual void UnadviseHierarchyEvents(uint cookie)
        {
            NativeMethods.ThrowOnFailure(innerVsHierarchy.UnadviseHierarchyEvents(cookie));
        }

        /// <include file='doc\FlavoredProject.uex' path='docs/doc[@for="FlavoredProject.SetProperty"]/*' />
        protected virtual int SetProperty(uint itemId, int propId, System.Object property)
        {
            return innerVsHierarchy.SetProperty(itemId, propId, property);
        }

        /// <include file='doc\FlavoredProject.uex' path='docs/doc[@for="FlavoredProject.Unused0"]/*' />
        protected virtual void Unused0()
        {
            NativeMethods.ThrowOnFailure(innerVsHierarchy.Unused0());
        }

        /// <include file='doc\FlavoredProject.uex' path='docs/doc[@for="FlavoredProject.Unused1"]/*' />
        protected virtual void Unused1()
        {
            NativeMethods.ThrowOnFailure(innerVsHierarchy.Unused1());
        }

        /// <include file='doc\FlavoredProject.uex' path='docs/doc[@for="FlavoredProject.Unused2"]/*' />
        protected virtual void Unused2()
        {
            NativeMethods.ThrowOnFailure(innerVsHierarchy.Unused2());
        }

        /// <include file='doc\FlavoredProject.uex' path='docs/doc[@for="FlavoredProject.Unused3"]/*' />
        protected virtual void Unused3()
        {
            NativeMethods.ThrowOnFailure(innerVsHierarchy.Unused3());
        }

        /// <include file='doc\FlavoredProject.uex' path='docs/doc[@for="FlavoredProject.Unused4"]/*' />
        protected virtual void Unused4()
        {
            NativeMethods.ThrowOnFailure(innerVsHierarchy.Unused4());
        }
        #endregion

        #region IVsUIHierarchy Members
        //
        // All methods (except for QueryStatusCommand and ExecCommand) call the IVsHierarchy implementation.
        // QueryStatusCommand and ExecCommand call a protected virtual method that the base class can override.
        // Note that we QI for IVsUIHierarchy on this so that if we are flavored we call the outer IVsHierarchy.
        //

        int IVsUIHierarchy.QueryStatusCommand(uint itemid, ref Guid pguidCmdGroup, uint cCmds, OLECMD[] prgCmds, IntPtr pCmdText)
        {
            return this.QueryStatusCommand(itemid, ref pguidCmdGroup, cCmds, prgCmds, pCmdText);
        }
        /// <include file='doc\FlavoredProject.uex' path='docs/doc[@for="FlavoredProject.QueryStatusCommand"]/*' />
        protected virtual int QueryStatusCommand(uint itemid, ref Guid pguidCmdGroup, uint cCmds, OLECMD[] prgCmds, IntPtr pCmdText)
        {
            return innerVsUIHierarchy.QueryStatusCommand(itemid, ref pguidCmdGroup, cCmds, prgCmds, pCmdText);
        }

        int IVsUIHierarchy.ExecCommand(uint itemid, ref Guid pguidCmdGroup, uint nCmdID, uint nCmdexecopt, IntPtr pvaIn, IntPtr pvaOut)
        {
            return this.ExecCommand(itemid, ref pguidCmdGroup, nCmdID, nCmdexecopt, pvaIn, pvaOut);
        }
        /// <include file='doc\FlavoredProject.uex' path='docs/doc[@for="FlavoredProject.ExecCommand"]/*' />
        protected virtual int ExecCommand(uint itemid, ref Guid pguidCmdGroup, uint nCmdID, uint nCmdexecopt, IntPtr pvaIn, IntPtr pvaOut)
        {
            return innerVsUIHierarchy.ExecCommand(itemid, ref pguidCmdGroup, nCmdID, nCmdexecopt, pvaIn, pvaOut);
        }



        int IVsUIHierarchy.AdviseHierarchyEvents(IVsHierarchyEvents pEventSink, out uint pdwCookie)
        {
            return ((IVsHierarchy)this).AdviseHierarchyEvents(pEventSink, out pdwCookie);
        }

        int IVsUIHierarchy.Close()
        {
            return ((IVsHierarchy)this).Close();
        }

        int IVsUIHierarchy.GetCanonicalName(uint itemid, out string pbstrName)
        {
            return ((IVsHierarchy)this).GetCanonicalName(itemid, out pbstrName);
        }

        int IVsUIHierarchy.GetGuidProperty(uint itemid, int propid, out Guid pguid)
        {
            return ((IVsHierarchy)this).GetGuidProperty(itemid, propid, out pguid);
        }

        int IVsUIHierarchy.GetNestedHierarchy(uint itemid, ref Guid iidHierarchyNested, out IntPtr ppHierarchyNested, out uint pitemidNested)
        {
            return ((IVsHierarchy)this).GetNestedHierarchy(itemid, ref iidHierarchyNested, out ppHierarchyNested, out pitemidNested);
        }

        int IVsUIHierarchy.GetProperty(uint itemid, int propid, out object pvar)
        {
            return ((IVsHierarchy)this).GetProperty(itemid, propid, out pvar);
        }

        int IVsUIHierarchy.GetSite(out Microsoft.VisualStudio.OLE.Interop.IServiceProvider ppSP)
        {
            return ((IVsHierarchy)this).GetSite(out ppSP);
        }

        int IVsUIHierarchy.ParseCanonicalName(string pszName, out uint pitemid)
        {
            return ((IVsHierarchy)this).ParseCanonicalName(pszName, out pitemid);
        }

        int IVsUIHierarchy.QueryClose(out int pfCanClose)
        {
            return ((IVsHierarchy)this).QueryClose(out pfCanClose);
        }

        int IVsUIHierarchy.SetGuidProperty(uint itemid, int propid, ref Guid rguid)
        {
            return ((IVsHierarchy)this).SetGuidProperty(itemid, propid, ref rguid);
        }

        int IVsUIHierarchy.SetProperty(uint itemid, int propid, object var)
        {
            return ((IVsHierarchy)this).SetProperty(itemid, propid, var);
        }

        int IVsUIHierarchy.SetSite(Microsoft.VisualStudio.OLE.Interop.IServiceProvider psp)
        {
            return ((IVsHierarchy)this).SetSite(psp);
        }

        int IVsUIHierarchy.UnadviseHierarchyEvents(uint dwCookie)
        {
            return ((IVsHierarchy)this).UnadviseHierarchyEvents(dwCookie);
        }

        int IVsUIHierarchy.Unused0()
        {
            return ((IVsHierarchy)this).Unused0();
        }

        int IVsUIHierarchy.Unused1()
        {
            return ((IVsHierarchy)this).Unused1();
        }

        int IVsUIHierarchy.Unused2()
        {
            return ((IVsHierarchy)this).Unused2();
        }

        int IVsUIHierarchy.Unused3()
        {
            return ((IVsHierarchy)this).Unused3();
        }

        int IVsUIHierarchy.Unused4()
        {
            return ((IVsHierarchy)this).Unused4();
        }

        #endregion


        #region IOleCommandTarget Members

        int IOleCommandTarget.Exec(ref Guid pguidCmdGroup, uint nCmdID, uint nCmdexecopt, IntPtr pvaIn, IntPtr pvaOut)
        {
            int hr = ((IOleCommandTarget)menuService).Exec(ref pguidCmdGroup, nCmdID, nCmdexecopt, pvaIn, pvaOut);
            return hr;
        }

        int IOleCommandTarget.QueryStatus(ref Guid pguidCmdGroup, uint cCmds, OLECMD[] prgCmds, IntPtr pCmdText)
        {
            int hr = ((IOleCommandTarget)menuService).QueryStatus(ref pguidCmdGroup, cCmds, prgCmds, pCmdText);
            return hr;
        }

        #endregion

        #region IServiceProvider Members

        object System.IServiceProvider.GetService(Type serviceType)
        {
            if (serviceType == typeof(IOleCommandTarget))
                return ((IOleCommandTarget)menuService);
            else if (serviceType == typeof(System.ComponentModel.Design.IMenuCommandService))
                return ((System.ComponentModel.Design.IMenuCommandService)menuService);
            else 
                return this.serviceProvider.GetService(serviceType);

        }

        #endregion

        #region Events (subset of IVsTrackProjectDocumentsEvents)
        // This makes it easier for the derived class to subscribe to only the events it
        // is really interested in and get one event per file. This also filter events
        // and only send events that have to do with this project

        /// <include file='doc\FlavoredProject.uex' path='docs/doc[@for="FlavoredProject.EventHandler"]/*' />
        public delegate void EventHandler<ProjectDocumentsChangeEventArgs>(object sender, ProjectDocumentsChangeEventArgs e);

        /// <include file='doc\FlavoredProject.uex' path='docs/doc[@for="FlavoredProject.FileAdded"]/*' />
        /// <devdoc>
        /// Called after a file was added to this project.
        /// </devdoc>
        public event EventHandler<ProjectDocumentsChangeEventArgs> FileAdded;
        /// <include file='doc\FlavoredProject.uex' path='docs/doc[@for="FlavoredProject.FileRemoved"]/*' />
        /// <devdoc>
        /// Called after a file was remove from this project.
        /// </devdoc>
        public event EventHandler<ProjectDocumentsChangeEventArgs> FileRemoved;
        /// <include file='doc\FlavoredProject.uex' path='docs/doc[@for="FlavoredProject.FileRenamed"]/*' />
        /// <devdoc>
        /// Called after a file was renamed in this project.
        /// </devdoc>
        public event EventHandler<ProjectDocumentsChangeEventArgs> FileRenamed;

        /// <include file='doc\FlavoredProject.uex' path='docs/doc[@for="FlavoredProject.DirectoryAdded"]/*' />
        /// <devdoc>
        /// Called after a directory was added to this project.
        /// </devdoc>
        public event EventHandler<ProjectDocumentsChangeEventArgs> DirectoryAdded;
        /// <include file='doc\FlavoredProject.uex' path='docs/doc[@for="FlavoredProject.DirectoryRemoved"]/*' />
        /// <devdoc>
        /// Called after a directory was remove from this project.
        /// </devdoc>
        public event EventHandler<ProjectDocumentsChangeEventArgs> DirectoryRemoved;
        /// <include file='doc\FlavoredProject.uex' path='docs/doc[@for="FlavoredProject.DirectoryRenamed"]/*' />
        /// <devdoc>
        /// Called after a directory was renamed in this project.
        /// </devdoc>
        public event EventHandler<ProjectDocumentsChangeEventArgs> DirectoryRenamed;

        /// <include file='doc\FlavoredProject.uex' path='docs/doc[@for="FlavoredProject.SccStatusChanged"]/*' />
        /// <devdoc>
        /// Called after the source code control status of a file in this project changed.
        /// </devdoc>
        public event EventHandler<ProjectDocumentsChangeEventArgs> SccStatusChanged;
        #endregion

        #region IVsTrackProjectDocumentsEvents2 Members
        /// We subscribes to IVsTrackProjectDocumentsEvents and trigger the
        /// corresponding event once per file per event.
        /// We filters the events to only reports those related to our project.
        /// This is NOT required for flavoring, but simplify the work the
        /// derived classes have to do when subscribing to these events

        int IVsTrackProjectDocumentsEvents2.OnAfterAddDirectoriesEx(int cProjects, int cDirectories, IVsProject[] rgpProjects, int[] rgFirstIndices, string[] rgpszMkDocuments, VSADDDIRECTORYFLAGS[] rgFlags)
        {
            GenerateEvents(rgpProjects, rgFirstIndices, rgpszMkDocuments, DirectoryAdded, new ProjectDocumentsChangeEventArgs());
            return NativeMethods.S_OK;
        }

        int IVsTrackProjectDocumentsEvents2.OnAfterAddFilesEx(int cProjects, int cFiles, IVsProject[] rgpProjects, int[] rgFirstIndices, string[] rgpszMkDocuments, VSADDFILEFLAGS[] rgFlags)
        {
            GenerateEvents(rgpProjects, rgFirstIndices, rgpszMkDocuments, FileAdded, new ProjectDocumentsChangeEventArgs());
            return NativeMethods.S_OK;
        }

        int IVsTrackProjectDocumentsEvents2.OnAfterRemoveDirectories(int cProjects, int cDirectories, IVsProject[] rgpProjects, int[] rgFirstIndices, string[] rgpszMkDocuments, VSREMOVEDIRECTORYFLAGS[] rgFlags)
        {
            GenerateEvents(rgpProjects, rgFirstIndices, rgpszMkDocuments, DirectoryRemoved, new ProjectDocumentsChangeEventArgs());
            return NativeMethods.S_OK;
        }

        int IVsTrackProjectDocumentsEvents2.OnAfterRemoveFiles(int cProjects, int cFiles, IVsProject[] rgpProjects, int[] rgFirstIndices, string[] rgpszMkDocuments, VSREMOVEFILEFLAGS[] rgFlags)
        {
            GenerateEvents(rgpProjects, rgFirstIndices, rgpszMkDocuments, FileRemoved, new ProjectDocumentsChangeEventArgs());
            return NativeMethods.S_OK;
        }

        int IVsTrackProjectDocumentsEvents2.OnAfterRenameDirectories(int cProjects, int cDirs, IVsProject[] rgpProjects, int[] rgFirstIndices, string[] rgszMkOldNames, string[] rgszMkNewNames, VSRENAMEDIRECTORYFLAGS[] rgFlags)
        {
            GenerateEvents(rgpProjects, rgFirstIndices, rgszMkNewNames, DirectoryRenamed, new ProjectDocumentsChangeEventArgs());
            return NativeMethods.S_OK;
        }

        int IVsTrackProjectDocumentsEvents2.OnAfterRenameFiles(int cProjects, int cFiles, IVsProject[] rgpProjects, int[] rgFirstIndices, string[] rgszMkOldNames, string[] rgszMkNewNames, VSRENAMEFILEFLAGS[] rgFlags)
        {
            GenerateEvents(rgpProjects, rgFirstIndices, rgszMkNewNames, FileRenamed, new ProjectDocumentsChangeEventArgs());
            return NativeMethods.S_OK;
        }

        int IVsTrackProjectDocumentsEvents2.OnAfterSccStatusChanged(int cProjects, int cFiles, IVsProject[] rgpProjects, int[] rgFirstIndices, string[] rgpszMkDocuments, uint[] rgdwSccStatus)
        {
            GenerateEvents(rgpProjects, rgFirstIndices, rgpszMkDocuments, SccStatusChanged, new ProjectDocumentsChangeEventArgs());
            return NativeMethods.S_OK;
        }

        int IVsTrackProjectDocumentsEvents2.OnQueryAddDirectories(IVsProject pProject, int cDirectories, string[] rgpszMkDocuments, VSQUERYADDDIRECTORYFLAGS[] rgFlags, VSQUERYADDDIRECTORYRESULTS[] pSummaryResult, VSQUERYADDDIRECTORYRESULTS[] rgResults)
        {
            return NativeMethods.S_OK; // We are not interested in this one
        }

        int IVsTrackProjectDocumentsEvents2.OnQueryAddFiles(IVsProject pProject, int cFiles, string[] rgpszMkDocuments, VSQUERYADDFILEFLAGS[] rgFlags, VSQUERYADDFILERESULTS[] pSummaryResult, VSQUERYADDFILERESULTS[] rgResults)
        {
            return NativeMethods.S_OK; // We are not interested in this one
        }

        int IVsTrackProjectDocumentsEvents2.OnQueryRemoveDirectories(IVsProject pProject, int cDirectories, string[] rgpszMkDocuments, VSQUERYREMOVEDIRECTORYFLAGS[] rgFlags, VSQUERYREMOVEDIRECTORYRESULTS[] pSummaryResult, VSQUERYREMOVEDIRECTORYRESULTS[] rgResults)
        {
            return NativeMethods.S_OK; // We are not interested in this one
        }

        int IVsTrackProjectDocumentsEvents2.OnQueryRemoveFiles(IVsProject pProject, int cFiles, string[] rgpszMkDocuments, VSQUERYREMOVEFILEFLAGS[] rgFlags, VSQUERYREMOVEFILERESULTS[] pSummaryResult, VSQUERYREMOVEFILERESULTS[] rgResults)
        {
            return NativeMethods.S_OK; // We are not interested in this one
        }

        int IVsTrackProjectDocumentsEvents2.OnQueryRenameDirectories(IVsProject pProject, int cDirs, string[] rgszMkOldNames, string[] rgszMkNewNames, VSQUERYRENAMEDIRECTORYFLAGS[] rgFlags, VSQUERYRENAMEDIRECTORYRESULTS[] pSummaryResult, VSQUERYRENAMEDIRECTORYRESULTS[] rgResults)
        {
            return NativeMethods.S_OK; // We are not interested in this one
        }

        int IVsTrackProjectDocumentsEvents2.OnQueryRenameFiles(IVsProject pProject, int cFiles, string[] rgszMkOldNames, string[] rgszMkNewNames, VSQUERYRENAMEFILEFLAGS[] rgFlags, VSQUERYRENAMEFILERESULTS[] pSummaryResult, VSQUERYRENAMEFILERESULTS[] rgResults)
        {
            return NativeMethods.S_OK; // We are not interested in this one
        }

        #endregion

        #region Helpers for IVsTrackProjectDocumentsEvents2

        /// <devdoc>
        /// Used to subscribe/unsubscribe to those events
        /// </devdoc>
        private IVsTrackProjectDocuments2 GetTrackProjectDocuments()
        {
            IVsTrackProjectDocuments2 trackDocuments = ((System.IServiceProvider)this).GetService(typeof(SVsTrackProjectDocuments)) as IVsTrackProjectDocuments2;
            if (trackDocuments == null)
            {
                throw new ApplicationException(string.Format(Resources.Culture, Resources.Flavor_FailedToGetService, "SVsTrackProjectDocuments"));
            }
            return trackDocuments;
        }

        /// <devdoc>
        /// Look at the list of projects and files and for each file that is part of this
        /// project, set the MkDocument on the event argument and trigger the event.
        /// </devdoc>
        private void GenerateEvents(
            IVsProject[] projects,
            int[] firstFiles,
            string[] mkDocuments,
            EventHandler<ProjectDocumentsChangeEventArgs> eventToGenerate,
            ProjectDocumentsChangeEventArgs e)
        {
            if (eventToGenerate == null)
                return; // no event = nothing to do

            if (projects == null || firstFiles == null || mkDocuments == null)
                throw new ArgumentNullException();
            if (projects.Length != firstFiles.Length)
                throw new ArgumentException();

            // First find out which range of the array (if any) include the files that belong to this project
            int first = -1;
            int last = mkDocuments.Length - 1; // default to the last document
            for (int i = 0; i < projects.Length; ++i)
            {
                if (first > -1)
                {
                    // We get here if there is 1 or more project(s) after ours in the list
                    last = firstFiles[i] - 1;
                    break;
                }
                if (Object.ReferenceEquals(projects[i], this))
                    first = firstFiles[i];
            }
            if (last >= mkDocuments.Length)
                throw new ArgumentException();
            // See if we have any documents
            if (first < 0)
                return; // Nothing that belongs to this project

            // For each file, generate the event
            for (int i = first; i <= last; ++i)
            {
                try
                {
                    e.MkDocument = mkDocuments[i];
                    eventToGenerate(this, e);
                }
                catch(Exception error)
                {
                    Debug.Fail(error.Message);
                }
            }
        }
        #endregion
    }
}
