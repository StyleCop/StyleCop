/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

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
    using ErrorHandler = Microsoft.VisualStudio.ErrorHandler;

    /// <include file='doc\FlavoredProject.uex' path='docs/doc[@for="FlavoredProject"]/*' />
    /// <devdoc>
    /// A project that is a subtype/flavor of an inner project.
    /// The default behavior of all methods is to delegate to the
    /// inner project. For any behavior you want to change, simply
    /// handle the request yourself.
    /// </devdoc>
    [CLSCompliant(false)]
    public abstract class FlavoredProjectBase : 
        IVsAggregatableProjectCorrected,
        System.IServiceProvider,
        IVsHierarchy,
        IVsUIHierarchy,
        IOleCommandTarget
    {
        // Keep interface reference for all interface we override

        /// <include file='doc\FlavoredProject.uex' path='docs/doc[@for="FlavoredProject._innerVsAggregatableProject"]/*' />
        protected IVsAggregatableProjectCorrected _innerVsAggregatableProject;
        /// <include file='doc\FlavoredProject.uex' path='docs/doc[@for="FlavoredProject._innerVsHierarchy"]/*' />
        protected IVsHierarchy _innerVsHierarchy;
        /// <include file='doc\FlavoredProject.uex' path='docs/doc[@for="FlavoredProject._innerVsUIHierarchy"]/*' />
        protected IVsUIHierarchy _innerVsUIHierarchy;
        /// <include file='doc\FlavoredProject.uex' path='docs/doc[@for="FlavoredProject._innerOleCommandTarget"]/*' />
        protected IOleCommandTarget _innerOleCommandTarget;

        /// <include file='doc\FlavoredProject.uex' path='docs/doc[@for="FlavoredProject.serviceProvider"]/*' />
        protected System.IServiceProvider serviceProvider;

        private OleMenuCommandService _menuService;
        private DocumentsEventsSink _documentsEventsSink;
        private bool _hierarchyClosed = false;
        private int _inExecCommand = 0;

        uint cookie = 0;

        /// <include file='doc\FlavoredProject.uex' path='docs/doc[@for="FlavoredProject.FlavoredProject"]/*' />
        public FlavoredProjectBase()
        {
            _documentsEventsSink = new FlavoredProjectBase.DocumentsEventsSink(this);
        }

        /// <include file='doc\FlavoredProject.uex' path='docs/doc[@for="FlavoredProject.GetComInterface"]/*' />
        /// <devdoc>
        /// A project derived from this base class will be aggregated with a native COM component (the ProjectAggregator object) 
        /// that can also aggregate an inner project in case of flavoring.
        /// Because of this structure, all the request for interfaces exposed to COM must be handled by the external object that 
        /// has a special implementation of QueryInterface that handles both inner and outer projects. 
        /// If you don’t use this helper method when requesting an interface you can get unexpected InvalidCast exceptions.
        /// Note that if you want to get the implementation of an interface implemented by your FlavoredProjectBase-derived
        /// object, then you must use the standard cast operator.
        /// </devdoc>
        public Interface_T GetComInterface<Interface_T>() where Interface_T : class
        {
            IntPtr thisUnknown = IntPtr.Zero;
            IntPtr interfacePtr = IntPtr.Zero;
            try
            {
                thisUnknown = Marshal.GetIUnknownForObject(this);
                Guid iid = typeof(Interface_T).GUID;
                if (ErrorHandler.Failed(Marshal.QueryInterface(thisUnknown, ref iid, out interfacePtr)) || (IntPtr.Zero == interfacePtr))
                {
                    return null;
                }
                return Marshal.GetObjectForIUnknown(interfacePtr) as Interface_T;
            }
            finally
            {
                if (IntPtr.Zero != thisUnknown)
                {
                    Marshal.Release(thisUnknown);
                }
                if (IntPtr.Zero != interfacePtr)
                {
                    Marshal.Release(interfacePtr);
                }
            }
        }

        #region IVsAggregatableProjectCorrected

        /// <devdoc>
        /// This is where all QI for interface on the inner object should happen
        /// Then set the inner project
        /// wait for InitializeForOuter to be called to do the real initialization
        /// </devdoc>
        int IVsAggregatableProjectCorrected.SetInnerProject(IntPtr innerIUnknown)
        {
            // delegate to the protected method
            this.SetInnerProject(innerIUnknown);

            return VSConstants.S_OK;
        }

        /// <include file='doc\FlavoredProject.uex' path='docs/doc[@for="FlavoredProject.SetInnerProject"]/*' />
        /// <devdoc>
        /// This is were all QI for interface on the inner object should happen
        /// Then set the inner project
        /// wait for InitializeForOuter to be called to do the real initialization
        /// </devdoc>
        protected virtual void SetInnerProject(IntPtr innerIUnknown)
        {
            object inner = null;

            inner = Marshal.GetObjectForIUnknown(innerIUnknown);

            // Keep a reference to each interface we want to call on the inner project
            // we must do it now as once we call SetInner the AddRef would be forwarded to ourselves
            _innerVsAggregatableProject = inner as IVsAggregatableProjectCorrected;
            Debug.Assert(inner != null, "Failed to retrieve IVsAggregatableProjectCorrected from inner Project");
            _innerVsHierarchy = (IVsHierarchy)inner;
            _innerVsUIHierarchy = (IVsUIHierarchy)inner;
            // "As" should return null without throwing in the event the base project does not implement the interface
            _innerOleCommandTarget = inner as IOleCommandTarget;

            // Setup our menu command service
            if (this.serviceProvider == null)
                throw new NotSupportedException("serviceProvider should have been set before SetInnerProject gets called.");
            _menuService = new OleMenuCommandService(this, _innerOleCommandTarget);

            // Pass the inner project pointer to the VisualStudio.ProjectAggregator2 object. This native object
            // has a special implementation of QueryInterface that delegates first to our managed FlavoredProjectBase
            // derived object and then to the inner project (either the base project or the next project flavor down).
            IntPtr thisIUnknown = IntPtr.Zero;
            IVsProjectAggregator2 vsProjectAggregator2 = null;
            try
            {
                thisIUnknown = Marshal.GetIUnknownForObject(this);
                vsProjectAggregator2 = (IVsProjectAggregator2)Marshal.GetObjectForIUnknown(thisIUnknown);
                if (vsProjectAggregator2 != null)
                    vsProjectAggregator2.SetInner(innerIUnknown);
            }
            finally
            {
                if (thisIUnknown != IntPtr.Zero)
                    Marshal.Release(thisIUnknown);
            }
        }

        /// <devdoc>
        /// Do the initialization here (such as loading flavor specific
        /// information from the project)
        /// </devdoc>
        int IVsAggregatableProjectCorrected.InitializeForOuter(string fileName, string location, string name,
            uint flags, ref Guid guidProject, out IntPtr project, out int canceled)
        {
            int hr = VSConstants.S_OK;
            project = IntPtr.Zero;
            canceled = 0;

            if (_innerVsAggregatableProject == null || guidProject != VSConstants.IID_IUnknown)
                throw new NotSupportedException();

            IntPtr thisIUnknown = IntPtr.Zero;
            try
            {
                thisIUnknown = Marshal.GetIUnknownForObject(this);
                if (thisIUnknown != IntPtr.Zero)
                    hr = Marshal.QueryInterface(thisIUnknown, ref guidProject, out project);
            }
            finally
            {
                if (thisIUnknown != IntPtr.Zero)
                    Marshal.Release(thisIUnknown);
            }

            bool cancel;
            this.InitializeForOuter(fileName, location, name, flags, ref guidProject, out cancel);
            if (cancel)
                canceled = 1;

            return hr;
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
        int IVsAggregatableProjectCorrected.OnAggregationComplete()
        {
            this.OnAggregationComplete();
            if (_innerVsAggregatableProject != null)
                return _innerVsAggregatableProject.OnAggregationComplete();
            return VSConstants.S_OK;
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
            ErrorHandler.ThrowOnFailure(trackDocuments.AdviseTrackProjectDocumentsEvents(_documentsEventsSink, out cookie));
        }

        /// <devdoc>
        /// This must be delegetated to the inner most project
        /// </devdoc>
        int IVsAggregatableProjectCorrected.SetAggregateProjectTypeGuids(string projectTypeGuids)
        {
            if (_innerVsAggregatableProject == null)
                throw new NotSupportedException();

            return _innerVsAggregatableProject.SetAggregateProjectTypeGuids(projectTypeGuids);
        }

        /// <devdoc>
        /// This must be delegetated to the inner most project
        /// </devdoc>
        int IVsAggregatableProjectCorrected.GetAggregateProjectTypeGuids(out string projectTypeGuids)
        {
            if (_innerVsAggregatableProject == null)
                throw new NotSupportedException();

            return _innerVsAggregatableProject.GetAggregateProjectTypeGuids(out projectTypeGuids);
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
            return VSConstants.S_OK;
        }

        int IVsHierarchy.Close()
        {
            _hierarchyClosed = true;
            this.Close();

            if (cookie != 0)
            {
                // Unsubscribe to events 
                IVsTrackProjectDocuments2 trackDocuments = GetTrackProjectDocuments();
                trackDocuments.UnadviseTrackProjectDocumentsEvents(cookie);
                cookie = 0;
            }

            this._menuService = null;
            if (_inExecCommand == 0)
                FreeInterfaces();

            return VSConstants.S_OK;
        }

        public virtual void FreeInterfaces()
        {
            this._menuService = null;

            if (_innerOleCommandTarget != null)
            {
                if (Marshal.IsComObject(_innerOleCommandTarget))
                    Marshal.ReleaseComObject(_innerOleCommandTarget);
                _innerOleCommandTarget = null;
            }

            if (_innerVsAggregatableProject != null)
            {
                if (Marshal.IsComObject(_innerVsAggregatableProject))
                    Marshal.ReleaseComObject(_innerVsAggregatableProject);
                _innerVsAggregatableProject = null;
            }

            if (_innerVsUIHierarchy != null)
            {
                if (Marshal.IsComObject(_innerVsUIHierarchy))
                    Marshal.ReleaseComObject(_innerVsUIHierarchy);
                _innerVsUIHierarchy = null;
            }

            if (_innerVsHierarchy != null)
            {
                if (Marshal.IsComObject(_innerVsHierarchy))
                    Marshal.ReleaseComObject(_innerVsHierarchy);
                _innerVsHierarchy = null;
            }
        } 



        int IVsHierarchy.GetCanonicalName(uint itemId, out string name)
        {
            return this.GetCanonicalName(itemId, out name);
        }

        int IVsHierarchy.GetGuidProperty(uint itemId, int propId, out System.Guid guid)
        {
            guid = this.GetGuidProperty(itemId, propId);
            return VSConstants.S_OK;
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
            return VSConstants.S_OK;
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
            return VSConstants.S_OK;
        }

        int IVsHierarchy.SetGuidProperty(uint itemId, int propId, ref System.Guid guid)
        {
            this.SetGuidProperty(itemId, propId, ref guid);
            return VSConstants.S_OK;
        }

        int IVsHierarchy.SetSite(Microsoft.VisualStudio.OLE.Interop.IServiceProvider serviceProvider)
        {
            this.serviceProvider = (System.IServiceProvider)new ServiceProvider(serviceProvider);
            ErrorHandler.ThrowOnFailure(_innerVsHierarchy.SetSite(serviceProvider));
            return VSConstants.S_OK;
        }

        int IVsHierarchy.UnadviseHierarchyEvents(uint cookie)
        {
            this.UnadviseHierarchyEvents(cookie);
            return VSConstants.S_OK;
        }

        int IVsHierarchy.SetProperty(uint itemId, int propId, System.Object property)
        {
            return this.SetProperty(itemId, propId, property);
        }

        int IVsHierarchy.Unused0()
        {
            this.Unused0();
            return VSConstants.S_OK;
        }

        int IVsHierarchy.Unused1()
        {
            this.Unused1();
            return VSConstants.S_OK;
        }

        int IVsHierarchy.Unused2()
        {
            this.Unused2();
            return VSConstants.S_OK;
        }

        int IVsHierarchy.Unused3()
        {
            this.Unused3();
            return VSConstants.S_OK;
        }

        int IVsHierarchy.Unused4()
        {
            this.Unused4();
            return VSConstants.S_OK;
        }

        /// <include file='doc\FlavoredProject.uex' path='docs/doc[@for="FlavoredProject.AdviseHierarchyEvents"]/*' />
        protected virtual uint AdviseHierarchyEvents(Microsoft.VisualStudio.Shell.Interop.IVsHierarchyEvents eventSink)
        {
            uint cookie=0;
            ErrorHandler.ThrowOnFailure(_innerVsHierarchy.AdviseHierarchyEvents(eventSink, out cookie));
            return cookie;
        }

        /// <include file='doc\FlavoredProject.uex' path='docs/doc[@for="FlavoredProject.Close"]/*' />
        protected virtual void Close()
        {
            ErrorHandler.ThrowOnFailure(_innerVsHierarchy.Close());
        }

        /// <include file='doc\FlavoredProject.uex' path='docs/doc[@for="FlavoredProject.GetCanonicalName"]/*' />
        protected virtual int GetCanonicalName(uint itemId, out string name)
        {
            return _innerVsHierarchy.GetCanonicalName(itemId, out name);
        }

        /// <include file='doc\FlavoredProject.uex' path='docs/doc[@for="FlavoredProject.GetGuidProperty"]/*' />
        protected virtual Guid GetGuidProperty(uint itemId, int propId)
        {
            Guid property = Guid.Empty;
            if (_innerVsHierarchy != null)
                ErrorHandler.ThrowOnFailure(_innerVsHierarchy.GetGuidProperty(itemId, propId, out property));
            else
                return Guid.Empty;
            return property;
        }

        /// <include file='doc\FlavoredProject.uex' path='docs/doc[@for="FlavoredProject.GetNestedHierarchy"]/*' />
        protected virtual int GetNestedHierarchy(uint itemId, ref System.Guid guidHierarchyNested, out System.IntPtr hierarchyNested, out uint itemIdNested)
        {
            if (_innerVsHierarchy != null)
                return _innerVsHierarchy.GetNestedHierarchy(itemId, ref guidHierarchyNested, out hierarchyNested, out itemIdNested);
            else
            {
                hierarchyNested = IntPtr.Zero;
                itemIdNested = VSConstants.VSITEMID_NIL;
                return VSConstants.E_NOINTERFACE;
            }
        }

        /// <include file='doc\FlavoredProject.uex' path='docs/doc[@for="FlavoredProject.GetProperty"]/*' />
        protected virtual int GetProperty(uint itemId, int propId, out Object property)
        {
            if (_innerVsHierarchy != null)
                return _innerVsHierarchy.GetProperty(itemId, propId, out property);
            else
            {
                property = null;
                return VSConstants.E_UNEXPECTED;
            }
        }

        /// <include file='doc\FlavoredProject.uex' path='docs/doc[@for="FlavoredProject.GetSite"]/*' />
        protected virtual Microsoft.VisualStudio.OLE.Interop.IServiceProvider GetSite()
        {
            Microsoft.VisualStudio.OLE.Interop.IServiceProvider serviceProvider;
            ErrorHandler.ThrowOnFailure(_innerVsHierarchy.GetSite(out serviceProvider));
            return serviceProvider;
        }

        /// <include file='doc\FlavoredProject.uex' path='docs/doc[@for="FlavoredProject.ParseCanonicalName"]/*' />
        protected virtual int ParseCanonicalName(string name, out uint itemId)
        {
            return _innerVsHierarchy.ParseCanonicalName(name, out itemId);
        }

        /// <include file='doc\FlavoredProject.uex' path='docs/doc[@for="FlavoredProject.QueryClose"]/*' />
        protected virtual bool QueryClose()
        {
            int canClose;
            ErrorHandler.ThrowOnFailure(_innerVsHierarchy.QueryClose(out canClose));
            return (canClose != 0);
        }

        /// <include file='doc\FlavoredProject.uex' path='docs/doc[@for="FlavoredProject.SetGuidProperty"]/*' />
        protected virtual void SetGuidProperty(uint itemId, int propId, ref System.Guid guid)
        {
            ErrorHandler.ThrowOnFailure(_innerVsHierarchy.SetGuidProperty(itemId, propId, ref guid));
        }

        /// <include file='doc\FlavoredProject.uex' path='docs/doc[@for="FlavoredProject.UnadviseHierarchyEvents"]/*' />
        protected virtual void UnadviseHierarchyEvents(uint cookie)
        {
            ErrorHandler.ThrowOnFailure(_innerVsHierarchy.UnadviseHierarchyEvents(cookie));
        }

        /// <include file='doc\FlavoredProject.uex' path='docs/doc[@for="FlavoredProject.SetProperty"]/*' />
        protected virtual int SetProperty(uint itemId, int propId, System.Object property)
        {
            return _innerVsHierarchy.SetProperty(itemId, propId, property);
        }

        /// <include file='doc\FlavoredProject.uex' path='docs/doc[@for="FlavoredProject.Unused0"]/*' />
        protected virtual void Unused0()
        {
            ErrorHandler.ThrowOnFailure(_innerVsHierarchy.Unused0());
        }

        /// <include file='doc\FlavoredProject.uex' path='docs/doc[@for="FlavoredProject.Unused1"]/*' />
        protected virtual void Unused1()
        {
            ErrorHandler.ThrowOnFailure(_innerVsHierarchy.Unused1());
        }

        /// <include file='doc\FlavoredProject.uex' path='docs/doc[@for="FlavoredProject.Unused2"]/*' />
        protected virtual void Unused2()
        {
            ErrorHandler.ThrowOnFailure(_innerVsHierarchy.Unused2());
        }

        /// <include file='doc\FlavoredProject.uex' path='docs/doc[@for="FlavoredProject.Unused3"]/*' />
        protected virtual void Unused3()
        {
            ErrorHandler.ThrowOnFailure(_innerVsHierarchy.Unused3());
        }

        /// <include file='doc\FlavoredProject.uex' path='docs/doc[@for="FlavoredProject.Unused4"]/*' />
        protected virtual void Unused4()
        {
            ErrorHandler.ThrowOnFailure(_innerVsHierarchy.Unused4());
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
            return _innerVsUIHierarchy.QueryStatusCommand(itemid, ref pguidCmdGroup, cCmds, prgCmds, pCmdText);
        }

        int IVsUIHierarchy.ExecCommand(uint itemid, ref Guid pguidCmdGroup, uint nCmdID, uint nCmdexecopt, IntPtr pvaIn, IntPtr pvaOut)
        {
            int hr = VSConstants.S_OK;
            try
            {
                _inExecCommand++;
                hr = this.ExecCommand(itemid, ref pguidCmdGroup, nCmdID, nCmdexecopt, pvaIn, pvaOut);
            }
            finally
            {
                _inExecCommand--;
                Debug.Assert(_inExecCommand >= 0);
                if (_hierarchyClosed && _inExecCommand == 0)
                {
                    FreeInterfaces();
                }
            }
            return hr;
        }
        /// <include file='doc\FlavoredProject.uex' path='docs/doc[@for="FlavoredProject.ExecCommand"]/*' />
        protected virtual int ExecCommand(uint itemid, ref Guid pguidCmdGroup, uint nCmdID, uint nCmdexecopt, IntPtr pvaIn, IntPtr pvaOut)
        {
            return _innerVsUIHierarchy.ExecCommand(itemid, ref pguidCmdGroup, nCmdID, nCmdexecopt, pvaIn, pvaOut);
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
            int hr = ((IOleCommandTarget)_menuService).Exec(ref pguidCmdGroup, nCmdID, nCmdexecopt, pvaIn, pvaOut);
            return hr;
        }

        int IOleCommandTarget.QueryStatus(ref Guid pguidCmdGroup, uint cCmds, OLECMD[] prgCmds, IntPtr pCmdText)
        {
            int hr = ((IOleCommandTarget)_menuService).QueryStatus(ref pguidCmdGroup, cCmds, prgCmds, pCmdText);
            return hr;
        }

        #endregion

        #region IServiceProvider Members

        object System.IServiceProvider.GetService(Type serviceType)
        {
            if (serviceType == typeof(IOleCommandTarget))
                return ((IOleCommandTarget)_menuService);
            else if (serviceType == typeof(System.ComponentModel.Design.IMenuCommandService))
                return ((System.ComponentModel.Design.IMenuCommandService)_menuService);
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
        internal class DocumentsEventsSink : IVsTrackProjectDocumentsEvents2
        {
            private FlavoredProjectBase _flavoredProjectBase; 

            internal DocumentsEventsSink(FlavoredProjectBase flavoredProjectBase)
            {
                _flavoredProjectBase = flavoredProjectBase;
            }

            /// We subscribes to IVsTrackProjectDocumentsEvents and trigger the
            /// corresponding event once per file per event.
            /// We filters the events to only reports those related to our project.
            /// This is NOT required for flavoring, but simplify the work the
            /// derived classes have to do when subscribing to these events

            int IVsTrackProjectDocumentsEvents2.OnAfterAddDirectoriesEx(int cProjects, int cDirectories, IVsProject[] rgpProjects, int[] rgFirstIndices, string[] rgpszMkDocuments, VSADDDIRECTORYFLAGS[] rgFlags)
            {
                _flavoredProjectBase.GenerateEvents(rgpProjects, rgFirstIndices, rgpszMkDocuments, _flavoredProjectBase.DirectoryAdded, new ProjectDocumentsChangeEventArgs());
                return VSConstants.S_OK;
            }

            int IVsTrackProjectDocumentsEvents2.OnAfterAddFilesEx(int cProjects, int cFiles, IVsProject[] rgpProjects, int[] rgFirstIndices, string[] rgpszMkDocuments, VSADDFILEFLAGS[] rgFlags)
            {
                _flavoredProjectBase.GenerateEvents(rgpProjects, rgFirstIndices, rgpszMkDocuments, _flavoredProjectBase.FileAdded, new ProjectDocumentsChangeEventArgs());
                return VSConstants.S_OK;
            }

            int IVsTrackProjectDocumentsEvents2.OnAfterRemoveDirectories(int cProjects, int cDirectories, IVsProject[] rgpProjects, int[] rgFirstIndices, string[] rgpszMkDocuments, VSREMOVEDIRECTORYFLAGS[] rgFlags)
            {
                _flavoredProjectBase.GenerateEvents(rgpProjects, rgFirstIndices, rgpszMkDocuments, _flavoredProjectBase.DirectoryRemoved, new ProjectDocumentsChangeEventArgs());
                return VSConstants.S_OK;
            }

            int IVsTrackProjectDocumentsEvents2.OnAfterRemoveFiles(int cProjects, int cFiles, IVsProject[] rgpProjects, int[] rgFirstIndices, string[] rgpszMkDocuments, VSREMOVEFILEFLAGS[] rgFlags)
            {
                _flavoredProjectBase.GenerateEvents(rgpProjects, rgFirstIndices, rgpszMkDocuments, _flavoredProjectBase.FileRemoved, new ProjectDocumentsChangeEventArgs());
                return VSConstants.S_OK;
            }

            int IVsTrackProjectDocumentsEvents2.OnAfterRenameDirectories(int cProjects, int cDirs, IVsProject[] rgpProjects, int[] rgFirstIndices, string[] rgszMkOldNames, string[] rgszMkNewNames, VSRENAMEDIRECTORYFLAGS[] rgFlags)
            {
                _flavoredProjectBase.GenerateEvents(rgpProjects, rgFirstIndices, rgszMkNewNames, _flavoredProjectBase.DirectoryRenamed, new ProjectDocumentsChangeEventArgs());
                return VSConstants.S_OK;
            }

            int IVsTrackProjectDocumentsEvents2.OnAfterRenameFiles(int cProjects, int cFiles, IVsProject[] rgpProjects, int[] rgFirstIndices, string[] rgszMkOldNames, string[] rgszMkNewNames, VSRENAMEFILEFLAGS[] rgFlags)
            {
                _flavoredProjectBase.GenerateEvents(rgpProjects, rgFirstIndices, rgszMkNewNames, _flavoredProjectBase.FileRenamed, new ProjectDocumentsChangeEventArgs());
                return VSConstants.S_OK;
            }

            int IVsTrackProjectDocumentsEvents2.OnAfterSccStatusChanged(int cProjects, int cFiles, IVsProject[] rgpProjects, int[] rgFirstIndices, string[] rgpszMkDocuments, uint[] rgdwSccStatus)
            {
                _flavoredProjectBase.GenerateEvents(rgpProjects, rgFirstIndices, rgpszMkDocuments, _flavoredProjectBase.SccStatusChanged, new ProjectDocumentsChangeEventArgs());
                return VSConstants.S_OK;
            }

            int IVsTrackProjectDocumentsEvents2.OnQueryAddDirectories(IVsProject pProject, int cDirectories, string[] rgpszMkDocuments, VSQUERYADDDIRECTORYFLAGS[] rgFlags, VSQUERYADDDIRECTORYRESULTS[] pSummaryResult, VSQUERYADDDIRECTORYRESULTS[] rgResults)
            {
                return VSConstants.S_OK; // We are not interested in this one
            }

            int IVsTrackProjectDocumentsEvents2.OnQueryAddFiles(IVsProject pProject, int cFiles, string[] rgpszMkDocuments, VSQUERYADDFILEFLAGS[] rgFlags, VSQUERYADDFILERESULTS[] pSummaryResult, VSQUERYADDFILERESULTS[] rgResults)
            {
                return VSConstants.S_OK; // We are not interested in this one
            }

            int IVsTrackProjectDocumentsEvents2.OnQueryRemoveDirectories(IVsProject pProject, int cDirectories, string[] rgpszMkDocuments, VSQUERYREMOVEDIRECTORYFLAGS[] rgFlags, VSQUERYREMOVEDIRECTORYRESULTS[] pSummaryResult, VSQUERYREMOVEDIRECTORYRESULTS[] rgResults)
            {
                return VSConstants.S_OK; // We are not interested in this one
            }

            int IVsTrackProjectDocumentsEvents2.OnQueryRemoveFiles(IVsProject pProject, int cFiles, string[] rgpszMkDocuments, VSQUERYREMOVEFILEFLAGS[] rgFlags, VSQUERYREMOVEFILERESULTS[] pSummaryResult, VSQUERYREMOVEFILERESULTS[] rgResults)
            {
                return VSConstants.S_OK; // We are not interested in this one
            }

            int IVsTrackProjectDocumentsEvents2.OnQueryRenameDirectories(IVsProject pProject, int cDirs, string[] rgszMkOldNames, string[] rgszMkNewNames, VSQUERYRENAMEDIRECTORYFLAGS[] rgFlags, VSQUERYRENAMEDIRECTORYRESULTS[] pSummaryResult, VSQUERYRENAMEDIRECTORYRESULTS[] rgResults)
            {
                return VSConstants.S_OK; // We are not interested in this one
            }

            int IVsTrackProjectDocumentsEvents2.OnQueryRenameFiles(IVsProject pProject, int cFiles, string[] rgszMkOldNames, string[] rgszMkNewNames, VSQUERYRENAMEFILEFLAGS[] rgFlags, VSQUERYRENAMEFILERESULTS[] pSummaryResult, VSQUERYRENAMEFILERESULTS[] rgResults)
            {
                return VSConstants.S_OK; // We are not interested in this one
            }
        }

        #endregion

        #region Helpers for IVsTrackProjectDocumentsEvents2

        /// <devdoc>
        /// Used to subscribe/unsubscribe to those events
        /// </devdoc>
        private IVsTrackProjectDocuments2 GetTrackProjectDocuments()
        {
            IVsTrackProjectDocuments2 trackDocuments = ((System.IServiceProvider)this).GetService(typeof(SVsTrackProjectDocuments)) as IVsTrackProjectDocuments2;
            Debug.Assert(trackDocuments != null, "Could not get the IVsTrackProjectDocuments2 object");
            if (trackDocuments == null)
            {
                throw new InvalidOperationException();
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
                if (IsThisProject(projects[i]))
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

        private bool IsThisProject(IVsProject prj)
        {
            bool areSame = false;
            Guid IID_IUnknown = VSConstants.IID_IUnknown;
            IntPtr otherPtr = IntPtr.Zero;
            IntPtr otherIUnk = IntPtr.Zero;
            IntPtr thisPtr = IntPtr.Zero;
            IntPtr thisIUnk = IntPtr.Zero;
            try
            {
                otherPtr = Marshal.GetIUnknownForObject(prj);
                Marshal.QueryInterface(otherPtr, ref IID_IUnknown, out otherIUnk);

                thisPtr = Marshal.GetIUnknownForObject(this);
                Marshal.QueryInterface(thisPtr, ref IID_IUnknown, out thisIUnk);
                areSame = (otherIUnk == thisIUnk);
            }
            finally
            {
                if (IntPtr.Zero != otherPtr)
                {
                    Marshal.Release(otherPtr);
                }
                if (IntPtr.Zero != otherIUnk)
                {
                    Marshal.Release(otherIUnk);
                }
                if (IntPtr.Zero != thisPtr)
                {
                    Marshal.Release(thisPtr);
                }
                if (IntPtr.Zero != thisIUnk)
                {
                    Marshal.Release(thisIUnk);
                }
            }
            return areSame;
        }

        #endregion
    }
}
