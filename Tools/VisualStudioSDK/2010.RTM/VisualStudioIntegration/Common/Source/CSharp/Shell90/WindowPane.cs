//------------------------------------------------------------------------------
// <copyright file="WindowPane.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>                                                                
//------------------------------------------------------------------------------

namespace Microsoft.VisualStudio.Shell {

    using Microsoft.VisualStudio.OLE.Interop;
    using Microsoft.VisualStudio.Shell.Interop;
    using Microsoft.Win32;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.ComponentModel.Design;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    using IOleServiceProvider = Microsoft.VisualStudio.OLE.Interop.IServiceProvider;
    using IServiceProvider = System.IServiceProvider;

    /// <include file='doc\WindowPane.uex' path='docs/doc[@for="WindowPane"]' />
    /// <devdoc>
    ///     This is a quick way to implement a tool window pane.  This class 
    ///     implements IVsWindowPane; you must provide an implementation of an 
    ///     object that returns an IWin32Window, however.  In addition to 
    ///     IVsWindowPane this object implements IOleCommandTarget, mapping 
    ///     it to IMenuCommandService and IObjectWithSite, mapping the site 
    ///     to services that can be querried through its protected GetService 
    ///     method.
    /// </devdoc>
    [System.Runtime.InteropServices.ComVisible(true)]
    public abstract class WindowPane : 

        IVsWindowPane,
        IOleCommandTarget,
        IVsBroadcastMessageEvents,
        IServiceProvider,
        IDisposable {

        private IServiceProvider        _parentProvider;
        private ServiceProvider         _provider;
        private IVsShell                _vsShell;
        private uint                    _broadcastEventCookie;

        private IMenuCommandService     _commandService;
        private HelpService             _helpService;

        private bool                    _zombie = false;

        /// <include file='doc\WindowPane.uex' path='docs/doc[@for="WindowPane.WindowPane"]' />
        /// <devdoc>
        ///     Creates a new window pane.  The window pane can accept a service provider
        ///     to use when resolving services.  This provider can be null.
        /// </devdoc>
        protected WindowPane(IServiceProvider provider) {
            _parentProvider = provider;
        }

        /// <include file='doc\WindowPane.uex' path='docs/doc[@for="WindowPane.Window"]' />
        /// <devdoc>
        ///     Retrieves the window associated with this window pane.
        /// </devdoc>
        public abstract IWin32Window Window { get; }
        
        /// <include file='doc\WindowPane.uex' path='docs/doc[@for="WindowPane.Dispose"]' />
        /// <devdoc>
        ///     Can be called to dispose this editing window.
        /// </devdoc>
        public void Dispose() {
            Dispose(true);
        }

        /// <include file='doc\WindowPane.uex' path='docs/doc[@for="WindowPane.Dispose1"]' />
        /// <devdoc>
        ///     Called when this window pane is being disposed.
        /// </devdoc>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
        protected virtual void Dispose(bool disposing) {

            if (disposing) {

                if (_vsShell != null) {
                    try {
                        // Don't check for return code because here we can't do anything in case of failure.
                        _vsShell.UnadviseBroadcastMessages(_broadcastEventCookie);
                    } catch (Exception) { /* do nothing */ }
                    _vsShell = null;
                    _broadcastEventCookie = 0;
                }

                IWin32Window window = Window;
                if (window is IDisposable) {
                    try {
                    ((IDisposable)window).Dispose();
                    } catch (Exception) {
                        Debug.Fail("Failed to dispose window");
                    }
                }
                window = null;

                if (_commandService != null && _commandService is IDisposable) {
                    try {
                    ((IDisposable)_commandService).Dispose();
                    } catch (Exception) {
                        Debug.Fail("Failed to dispose command service");
                    }
                }
                _commandService = null;

                if (_parentProvider != null)
                    _parentProvider = null;

                if (_helpService != null)
                    _helpService = null;

                // Do not clear _provider.  SetSite will do it for us.

                _zombie = true;
            }
        }

        /// <devdoc>
        /// This is a separate method so the jitter doesn't see MenuCommandService (from system.design.dll) in
        /// the GetService call and load the assembly.
        /// </devdoc> 
        private void EnsureCommandService() {
            if (_commandService == null) {
                _commandService = new OleMenuCommandService(this);
            }
        }

        /// <include file='doc\WindowPane.uex' path='docs/doc[@for="WindowPane.GetService"]' />
        /// <devdoc>
        ///     Maps to IServiceProvider for service routing.
        /// </devdoc>
        protected virtual object GetService(Type serviceType) {

            if (_zombie)
            {
                Debug.Fail("GetService called after WindowPane was zombied");
                return null;
            }

            if (serviceType == null) {
                throw new ArgumentNullException("serviceType");
            }

            // We provide IMenuCommandService, so we will
            // demand create it.  MenuCommandService also
            // implements IOleCommandTarget, but unless
            // someone requested IMenuCommandService no commands
            // will exist, so we don't demand create for
            // IOleCommandTarget
            //
            if (serviceType == typeof(IMenuCommandService)) {
                EnsureCommandService();
                return _commandService;
            }
            else if (serviceType == typeof(IOleCommandTarget)) {
                return _commandService;
            }
            else if (serviceType == typeof(IHelpService)) {
                if (_helpService == null) {
                    _helpService = new HelpService(this);
                }
                return _helpService;
            }

            if (_provider != null) {
                object service = _provider.GetService(serviceType);
                if (service != null) {
                    return service;
                }
            }

            if (_parentProvider != null) {
                return _parentProvider.GetService(serviceType);
            }

            return null;
        }

        /// <include file='doc\WindowPane.uex' path='docs/doc[@for="WindowPane.Initialize"]' />
        /// <devdoc>
        ///     This method is called after the window pane has been sited.  Any initialization
        ///     that requires window frame services from VS can be done by overriding this
        ///     method.
        /// </devdoc>
        protected virtual void Initialize() {
        }

        /// <include file='doc\WindowPane.uex' path='docs/doc[@for="WindowPane.OnClose"]/*' />
        /// <devdoc>
        ///     The OnClose method is called in response to the ClosePane method on
        ///     IVsWindowPane.  The default implementation calls Dispose();
        /// </devdoc>
        protected virtual void OnClose() {
            Dispose();
        }

        /// <include file='doc\WindowPane.uex' path='docs/doc[@for="WindowPane.OnCreate"]/*' />
        /// <devdoc>
        ///     The OnCreate method is called during the CreatePaneWindow method of
        ///     IVsWindowPane.  This provides a handy hook for knowing when VS wants
        ///     the window.  The default implementation does nothing.
        /// </devdoc>
        protected virtual void OnCreate() {
        }

        /// <include file='doc\WindowPane.uex' path='docs/doc[@for="WindowPane.PreProcessMessage"]' />
        /// <devdoc>
        ///     This method will be called to pre-process keyboard
        ///     messages before VS handles them.  It is directly
        ///     attached to IVsWindowPane::TranslateAccellerator.
        ///     The default implementation calls the PreProcessMessage
        ///     method on a Windows Forms control.  You may override this if your
        ///     window pane is not based on Windows Forms.
        ///     Arguments and return values are the
        ///     same as for Windows Forms:  return true if you handled
        ///     the message, false if you want the default processing
        ///     to occur.
        /// </devdoc>
        protected virtual bool PreProcessMessage(ref Message m) {
            Control c = Control.FromChildHandle(m.HWnd);
            if (c != null) {
                return c.PreProcessControlMessage(ref m) == PreProcessControlState.MessageProcessed;
            }
            else {
                return false;
            }
        }

        /// <include file='doc\WindowPane.uex' path='docs/doc[@for="WindowPane.IOleCommandTarget.Exec"]/*' />
        /// <internalonly/>
        /// <devdoc>
        /// This is called by Visual Studio when the user has requested to execute a particular
        /// command.  There is no need to override this method.  If you need access to menu
        /// commands use IMenuCommandService.
        /// </devdoc>
        int IOleCommandTarget.Exec(ref Guid guidGroup, uint nCmdId, uint nCmdExcept, IntPtr pIn, IntPtr vOut) {

            // Always redirect through GetService for this.  That way outside users can replace
            // it.
            //
            IOleCommandTarget cmdTarget = GetService(typeof(IOleCommandTarget)) as IOleCommandTarget;
            if (cmdTarget != null) {
                return cmdTarget.Exec(ref guidGroup, nCmdId, nCmdExcept, pIn, vOut);
            }
            else {
                return NativeMethods.OLECMDERR_E_NOTSUPPORTED;
            }
        }
        
        /// <include file='doc\WindowPane.uex' path='docs/doc[@for="WindowPane.IOleCommandTarget.QueryStatus"]/*' />
        /// <internalonly/>
        /// <devdoc>
        /// This is called by Visual Studio when it needs the status of our menu commands.  There
        /// is no need to override this method.  If you need access to menu commands use
        /// IMenuCommandService.
        /// </devdoc>
        int IOleCommandTarget.QueryStatus(ref Guid guidGroup, uint nCmdId, OLECMD[] oleCmd, IntPtr oleText) {

            // Always redirect through GetService for this.  That way outside users can replace
            // it.
            //
            IOleCommandTarget cmdTarget = GetService(typeof(IOleCommandTarget)) as IOleCommandTarget;
            if (cmdTarget != null) {
                return cmdTarget.QueryStatus(ref guidGroup, nCmdId, oleCmd, oleText);
            }
            else {
                return NativeMethods.OLECMDERR_E_NOTSUPPORTED;
            }
        }

        /// <include file='doc\WindowPane.uex' path='docs/doc[@for="WindowPane.IServiceProvider.GetService"]/*' />
        /// <internalonly/>
        /// <devdoc>
        /// IServiceProvider implementation.
        /// </devdoc>
        object IServiceProvider.GetService(Type serviceType) {
            return GetService(serviceType);
        }

        /// <include file='doc\WindowPane.uex' path='docs/doc[@for="WindowPane.IVsBroadcastMessageEvents.OnBroadcastMessage"]/*' />
        /// <internalonly/>
        /// <devdoc>
        /// Receives broadcast messages from the shell
        /// </devdoc>
        int IVsBroadcastMessageEvents.OnBroadcastMessage(uint msg, IntPtr wParam, IntPtr lParam) {
            int hr = NativeMethods.S_OK;
            IntPtr hwnd = Window.Handle;
            bool result = UnsafeNativeMethods.PostMessage(hwnd, (int)msg, wParam, wParam);
            if ( !result )
                hr = NativeMethods.E_FAIL;
            return hr;
        }

        /// <include file='doc\WindowPane.uex' path='docs/doc[@for="WindowPane.IVsWindowPane.ClosePane"]/*' />
        /// <internalonly/>
        /// <devdoc>
        /// IVsWindowPane implementation.
        /// </devdoc>
        int IVsWindowPane.ClosePane() {

            if (_vsShell != null) {
                NativeMethods.ThrowOnFailure(_vsShell.UnadviseBroadcastMessages(_broadcastEventCookie));
                _vsShell = null;
                _broadcastEventCookie = 0;
            }

            OnClose();
            return NativeMethods.S_OK;
        }

        /// <include file='doc\WindowPane.uex' path='docs/doc[@for="WindowPane.IVsWindowPane.CreatePaneWindow"]/*' />
        /// <internalonly/>
        /// <devdoc>
        /// IVsWindowPane implementation.
        /// </devdoc>
        int IVsWindowPane.CreatePaneWindow(IntPtr hwndParent, int   x, int   y, int   cx, int   cy, out IntPtr pane) {
            
            OnCreate();
            IntPtr hwnd = Window.Handle;
            int style = (int)UnsafeNativeMethods.GetWindowLong(hwnd, NativeMethods.GWL_STYLE);

            // set up the required styles of an IVsWindowPane
            style |= (NativeMethods.WS_CLIPSIBLINGS | NativeMethods.WS_CHILD | NativeMethods.WS_VISIBLE);
            style &= ~(NativeMethods.WS_POPUP |
                       NativeMethods.WS_MINIMIZE |
                       NativeMethods.WS_MAXIMIZE |
                       NativeMethods.WS_DLGFRAME |
                       NativeMethods.WS_SYSMENU |
                       NativeMethods.WS_THICKFRAME |
                       NativeMethods.WS_MINIMIZEBOX |
                       NativeMethods.WS_MAXIMIZEBOX);

            UnsafeNativeMethods.SetWindowLong(hwnd, NativeMethods.GWL_STYLE, (IntPtr)style);

            style = (int)UnsafeNativeMethods.GetWindowLong(hwnd, NativeMethods.GWL_EXSTYLE);

            style &= ~(NativeMethods.WS_EX_DLGMODALFRAME  |
                       NativeMethods.WS_EX_NOPARENTNOTIFY |
                       NativeMethods.WS_EX_TOPMOST        |
                       NativeMethods.WS_EX_MDICHILD       |
                       NativeMethods.WS_EX_TOOLWINDOW     |
                       NativeMethods.WS_EX_CONTEXTHELP    |
                       NativeMethods.WS_EX_APPWINDOW);

            UnsafeNativeMethods.SetWindowLong(hwnd, NativeMethods.GWL_EXSTYLE, (IntPtr)style);
            UnsafeNativeMethods.SetParent(hwnd, (IntPtr)hwndParent);
            UnsafeNativeMethods.SetWindowPos(hwnd, IntPtr.Zero, x, y, cx, cy, NativeMethods.SWP_NOZORDER | NativeMethods.SWP_NOACTIVATE);
            UnsafeNativeMethods.ShowWindow(hwnd, NativeMethods.SW_SHOWNORMAL);
            
            // Sync broadcast events so we update our UI when colors/fonts change.
            //
            if (_vsShell == null) {
                _vsShell = (IVsShell)GetService(typeof(SVsShell));
                if (_vsShell != null) {
                    NativeMethods.ThrowOnFailure(_vsShell.AdviseBroadcastMessages(this, out _broadcastEventCookie));
                }
            }
            
            pane = hwnd;
            return NativeMethods.S_OK;
        }

        /// <include file='doc\WindowPane.uex' path='docs/doc[@for="WindowPane.IVsWindowPane.GetDefaultSize"]/*' />
        /// <internalonly/>
        /// <devdoc>
        /// IVsWindowPane implementation.
        /// </devdoc>
        int IVsWindowPane.GetDefaultSize(SIZE[] size) {
            return NativeMethods.E_NOTIMPL;
        }

        /// <include file='doc\WindowPane.uex' path='docs/doc[@for="WindowPane.IVsWindowPane.LoadViewState"]/*' />
        /// <internalonly/>
        /// <devdoc>
        /// IVsWindowPane implementation.
        /// </devdoc>
        int IVsWindowPane.LoadViewState(IStream pstream) {
            Marshal.ReleaseComObject(pstream);
            return NativeMethods.E_NOTIMPL;
        }

        /// <include file='doc\WindowPane.uex' path='docs/doc[@for="WindowPane.IVsWindowPane.SaveViewState"]/*' />
        /// <internalonly/>
        /// <devdoc>
        /// IVsWindowPane implementation.
        /// </devdoc>
        int IVsWindowPane.SaveViewState(IStream pstream) {
            Marshal.ReleaseComObject(pstream);
            return NativeMethods.E_NOTIMPL;
        }

        /// <include file='doc\WindowPane.uex' path='docs/doc[@for="WindowPane.IVsWindowPane.SetSite"]/*' />
        /// <internalonly/>
        /// <devdoc>
        /// IVsWindowPane implementation.
        /// </devdoc>
        int IVsWindowPane.SetSite(IOleServiceProvider p) {

            // The siting mechanism works as follows:  If the
            // parent provider provides ServiceProviderHierarchy
            // as a service we will insert our service provider in
            // the WindowPaneSite slot of the hierarchy.
            // If, however, it does not provide
            // this service, we will create a new 
            // ServiceProvider that will be used to resolve
            // services through this site.  
            //
            if (_provider != null) {
                _provider.Dispose();
                _provider = null;
            }

            IObjectWithSite ows = GetService(typeof(IObjectWithSite)) as IObjectWithSite;
            ServiceProviderHierarchy serviceHierarchy = GetService(typeof(ServiceProviderHierarchy)) as ServiceProviderHierarchy;
            if (serviceHierarchy != null) {
                ServiceProvider sp = (p == null ? null : new ServiceProvider(p));
                serviceHierarchy[ServiceProviderHierarchyOrder.WindowPaneSite] = sp;             
            }
            else if (ows != null) {
               ows.SetSite(p);
            }
            else {
                if (p != null) {
                    _provider = new ServiceProvider(p);
                }
            }

            if (p != null) {
                Initialize();
            }
            return NativeMethods.S_OK;
        }

        /// <include file='doc\WindowPane.uex' path='docs/doc[@for="WindowPane.IVsWindowPane.TranslateAccelerator"]/*' />
        /// <internalonly/>
        /// <devdoc>
        /// IVsWindowPane implementation.
        /// </devdoc>
        int IVsWindowPane.TranslateAccelerator(Microsoft.VisualStudio.OLE.Interop.MSG[] msg) {
            Message m = Message.Create(msg[0].hwnd, (int)msg[0].message, msg[0].wParam, msg[0].lParam);
            bool eat = PreProcessMessage(ref m);

            msg[0].message = (uint)m.Msg;
            msg[0].wParam = m.WParam;
            msg[0].lParam = m.LParam;

            if (eat) {
                return NativeMethods.S_OK;
            }
            else {
                return NativeMethods.E_FAIL;
            }
        }
    } 
}

