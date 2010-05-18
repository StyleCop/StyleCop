//------------------------------------------------------------------------------
// <copyright file="WindowPane.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>                                                                
//------------------------------------------------------------------------------

namespace Microsoft.VisualStudio.Shell
{

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
    using System.Windows.Interop;
    using System.Windows;
    using System.Windows.Markup;

    using IOleServiceProvider = Microsoft.VisualStudio.OLE.Interop.IServiceProvider;
    using IServiceProvider = System.IServiceProvider;
    using System.IO;


    class UIWin32ElementWrapper : IVsUIWin32Element, IVsBroadcastMessageEvents, IDisposable
    {
        private IVsShell _vsShell;
        private uint _broadcastEventCookie;

        WindowPane _pane;

        internal UIWin32ElementWrapper(WindowPane pane)
        {
            _pane = pane;
        }
        #region IVsUIWin32Element Members

        public int Create(IntPtr parent, out IntPtr pHandle)
        {
            IntPtr hwnd = _pane.Window.Handle;
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

            style &= ~(NativeMethods.WS_EX_DLGMODALFRAME |
                       NativeMethods.WS_EX_NOPARENTNOTIFY |
                       NativeMethods.WS_EX_TOPMOST |
                       NativeMethods.WS_EX_MDICHILD |
                       NativeMethods.WS_EX_TOOLWINDOW |
                       NativeMethods.WS_EX_CONTEXTHELP |
                       NativeMethods.WS_EX_APPWINDOW);

            UnsafeNativeMethods.SetWindowLong(hwnd, NativeMethods.GWL_EXSTYLE, (IntPtr)style);
            UnsafeNativeMethods.SetParent(hwnd, (IntPtr)parent);
            //            UnsafeNativeMethods.SetWindowPos(hwnd, IntPtr.Zero, x, y, cx, cy, NativeMethods.SWP_NOZORDER | NativeMethods.SWP_NOACTIVATE);
            UnsafeNativeMethods.ShowWindow(hwnd, NativeMethods.SW_SHOWNORMAL);

            // Sync broadcast events so we update our UI when colors/fonts change.
            //
            if (_vsShell == null)
            {
                _vsShell = ServiceProvider.GlobalProvider.GetService(typeof(SVsShell)) as IVsShell;
                if (_vsShell != null)
                {
                    NativeMethods.ThrowOnFailure(_vsShell.AdviseBroadcastMessages(this, out _broadcastEventCookie));
                }
            }

            pHandle = hwnd;
            return NativeMethods.S_OK;
        }

        public int Destroy()
        {
            throw new NotImplementedException();
        }

        public int GetHandle(out IntPtr pHandle)
        {
            pHandle = _pane.Window.Handle;
            return VSConstants.S_OK;
        }

        public int ShowModal(IntPtr parent, out int pDlgResult)
        {
            throw new NotImplementedException();
        }

        #endregion

        /// <include file='doc\WindowPane.uex' path='docs/doc[@for="WindowPane.IVsBroadcastMessageEvents.OnBroadcastMessage"]/*' />
        /// <internalonly/>
        /// <devdoc>
        /// Receives broadcast messages from the shell
        /// </devdoc>
        int IVsBroadcastMessageEvents.OnBroadcastMessage(uint msg, IntPtr wParam, IntPtr lParam)
        {
            int hr = NativeMethods.S_OK;
            IntPtr hwnd = _pane.Window.Handle;
            bool result = UnsafeNativeMethods.PostMessage(hwnd, (int)msg, wParam, wParam);
            if (!result)
                hr = NativeMethods.E_FAIL;
            return hr;
        }


        #region IDisposable Members

        public void Dispose()
        {
            if (_vsShell != null)
            {
                try
                {
                    // Don't check for return code because here we can't do anything in case of failure.
                    _vsShell.UnadviseBroadcastMessages(_broadcastEventCookie);
                }
                catch (Exception) { /* do nothing */ }
                _vsShell = null;
                _broadcastEventCookie = 0;
            }
        }

        #endregion
    }


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
    [ContentProperty("Content")]
    [System.Runtime.InteropServices.ComVisible(true)]
    public abstract class WindowPane : IOleCommandTarget, IServiceProvider, IVsWindowPane, IVsUIElementPane, IDisposable
    {
        private IServiceProvider _parentProvider;
        private ServiceProvider _provider;

        private IMenuCommandService _commandService;
        private HelpService _helpService;

        private bool _zombie = false;

        private UIWin32ElementWrapper win32Wrapper = null;

        /// <summary>
        /// Creates a new window pane with a null parent service provider
        /// </summary>
        protected WindowPane()
        {
        }

        /// <include file='doc\WindowPane.uex' path='docs/doc[@for="WindowPane.WindowPane"]' />
        /// <devdoc>
        ///     Creates a new window pane.  The window pane can accept a service provider
        ///     to use when resolving services.  This provider can be null.
        /// </devdoc>
        protected WindowPane(IServiceProvider provider)
            : this()
        {
            _parentProvider = provider;
        }

        /// <include file='doc\WindowPane.uex' path='docs/doc[@for="WindowPane.Window"]' />
        /// <devdoc>
        ///     Retrieves the window associated with this window pane.
        /// </devdoc>
        public virtual System.Windows.Forms.IWin32Window Window { get { return null; } }

        /// <devdoc>
        /// Stores the state for how this WindowPane was initialized. Initialization
        /// happens through either IVsWindowPane.CreatePaneWindow or IVsUIElementPane.CreateUIElementPane.
        /// </devdoc>
        protected PaneInitializationMode InitializationMode { get; private set; }

        /// <devdoc>
        /// Override or set to provide the content of this tool window.   Expected kinds of objects include
        /// FrameworkElement, IVsUIWpfElement, IVsUIWin32Element.   If the object is not of one of the expected
        /// types, it will be wrapped in a ContentControl, treated as WPF and any styling or formatting may
        /// be applied through the global resource dictionary.
        /// If your tool content is created from xaml, override the setter to provide a backing store for the content.
        /// </devdoc>
        public virtual Object Content
        {
            get;
            set;
        }

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

                if (win32Wrapper != null)
                    win32Wrapper.Dispose();
                win32Wrapper = null;

                IDisposable disposableWindow = null;
                if (Content != null)
                {
                    disposableWindow = Content as IDisposable;
                }
                else
                {
                    disposableWindow = Window as IDisposable;
                }
                    
                if (disposableWindow != null)
                {
                    try {
                        disposableWindow.Dispose();
                    } catch (Exception) {
                        Debug.Fail("Failed to dispose window");
                    }
                }
                disposableWindow = null;

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
        protected virtual object GetService(Type serviceType)
        {

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
            if (serviceType.IsEquivalentTo(typeof(IMenuCommandService))) {
                EnsureCommandService();
                return _commandService;
            }
            else if (serviceType.IsEquivalentTo(typeof(IOleCommandTarget))) {
                return _commandService;
            }
            else if (serviceType.IsEquivalentTo(typeof(IHelpService))) {
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

            // We should never attempt to resite the parent
            // if _provider is not null it will have already succeeded above.
            if (serviceType.IsEquivalentTo(typeof(IObjectWithSite)))
                return null;

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


        /// <include file='doc\WindowPane.uex' path='docs/doc[@for="WindowPane.IVsUIElementPane.CloseUIElementPane"]/*' />
        /// <internalonly/>
        /// <devdoc>
        /// IVsUIElementPane implementation.
        /// </devdoc>
        int IVsUIElementPane.CloseUIElementPane() {
            OnClose();
            return NativeMethods.S_OK;
        }

        /// <include file='doc\WindowPane.uex' path='docs/doc[@for="WindowPane.IVsUIElementPane.CreateUIElementPane"]/*' />
        /// <internalonly/>
        /// <devdoc>
        /// IVsUIElementPane implementation.
        /// </devdoc>
        int IVsUIElementPane.CreateUIElementPane(out object uiElement) {
            uiElement = null;

            if (InitializationMode != PaneInitializationMode.Uninitialized)
                throw new InvalidOperationException("The WindowPane is already initialized");

            // Indicate to derived classes that IVsUIElementPane.CreateUIElementPane was used, and not IVsWindowPane.CreatePaneWindow
            InitializationMode = PaneInitializationMode.IVsUIElementPane;

            // We should call OnCreate one time for derived classes to pre-initialize themselves.
            // This should be called before accessing the Content or Window properties.
            OnCreate();

            if (Content != null)
                uiElement = Content;
            else if (Window != null) {
                win32Wrapper = new UIWin32ElementWrapper(this);
                uiElement = win32Wrapper;
            }
            else
                return VSConstants.E_UNEXPECTED;

            return VSConstants.S_OK;
        }


        /// <include file='doc\WindowPane.uex' path='docs/doc[@for="WindowPane.IVsUIElementPane.GetDefaultSize"]/*' />
        /// <internalonly/>
        /// <devdoc>
        /// IVsUIElementPane implementation.
        /// </devdoc>
        int IVsUIElementPane.GetDefaultUIElementSize(SIZE[] size) {
            return NativeMethods.E_NOTIMPL;
        }

        /// <summary>
        /// Override to load previously saved state of the pane
        /// </summary>
        /// <param name="?"></param>
        /// <param name="?"></param>
        /// <returns></returns>
        public virtual int LoadUIState(Stream stateStream)
        {
            return VSConstants.E_NOTIMPL;
        }


        private static byte[] GetBufferFromIStream(IStream comStream)
        {
            LARGE_INTEGER zeroPos;
            zeroPos.QuadPart = 0;
            ULARGE_INTEGER[] streamPosition = new ULARGE_INTEGER[1];
            comStream.Seek(zeroPos, (uint)STREAM_SEEK.STREAM_SEEK_CUR, streamPosition);
            comStream.Seek(zeroPos, (uint)STREAM_SEEK.STREAM_SEEK_SET, null);

            Microsoft.VisualStudio.OLE.Interop.STATSTG[] stat = new Microsoft.VisualStudio.OLE.Interop.STATSTG[1];
            comStream.Stat(stat, (uint)STATFLAG.STATFLAG_NONAME);

            int bufferLength = (int)stat[0].cbSize.QuadPart;
            byte[] buffer = new byte[bufferLength];
            uint bytesRead = 0;
            comStream.Read(buffer, (uint)buffer.Length, out bytesRead);

            // return the stream to its previous location
            LARGE_INTEGER newPos;
            newPos.QuadPart = (long)streamPosition[0].QuadPart;
            comStream.Seek(newPos, (uint)STREAM_SEEK.STREAM_SEEK_SET, null);

            return buffer;
        }


        /// <include file='doc\WindowPane.uex' path='docs/doc[@for="WindowPane.IVsUIElementPane.LoadUIElementState"]/*' />
        /// <internalonly/>
        /// <devdoc>
        /// IVsUIElementPane implementation.
        /// </devdoc>
        int IVsUIElementPane.LoadUIElementState(IStream pstream)
        {
            byte[] bytes = GetBufferFromIStream(pstream);
            if (bytes.Length > 0)
            {
                using (MemoryStream stateStream = new MemoryStream(bytes))
                {
                     return LoadUIState(stateStream);
                }
            }

            return VSConstants.S_OK;
        }

        /// <summary>
        /// Override to save custom state information to be used later when the pane is reconstructed.
        /// </summary>
        /// <returns>The stream with the state information</returns>
        public virtual int SaveUIState(out Stream stateStream)
        {
            stateStream = null;
            return VSConstants.S_OK;
        }

        /// <include file='doc\WindowPane.uex' path='docs/doc[@for="WindowPane.IVsUIElementPane.SaveUIElementState"]/*' />
        /// <internalonly/>
        /// <devdoc>
        /// IVsUIElementPane implementation.
        /// </devdoc>
        int IVsUIElementPane.SaveUIElementState(IStream pstream) {

            Stream stateStream;
            
            int hresult = SaveUIState(out stateStream);
            if (ErrorHandler.Succeeded(hresult))
            {
                // Make sure the returned stream (if any) is properly disposed even if it's not readable or is empty
                using (stateStream)
                {
                    // If a stream was returned and is readable and have anything to read from it
                    if (stateStream != null && stateStream.CanRead && stateStream.Length > 0)
                    {
                        using (BinaryReader reader = new BinaryReader(stateStream))
                        {
                            byte[] bytes = new byte[stateStream.Length];
                            stateStream.Position = 0;
                            reader.Read(bytes, 0, bytes.Length);
                            uint written = 0;
                            pstream.Write(bytes, (uint)bytes.Length, out written);
                            pstream.Commit((uint)STGC.STGC_DEFAULT);
                        }
                    }
                }
            }

            return hresult;
        }

        private int InternalSetSite(IOleServiceProvider p)
        {
            // The siting mechanism works as follows:  If the
            // parent provider provides ServiceProviderHierarchy
            // as a service we will insert our service provider in
            // the WindowPaneSite slot of the hierarchy.
            // If, however, it does not provide
            // this service, we will create a new 
            // ServiceProvider that will be used to resolve
            // services through this site.  
            //
            if (_provider != null)
            {
                _provider.Dispose();
                _provider = null;
            }

            IObjectWithSite ows = GetService(typeof(IObjectWithSite)) as IObjectWithSite;
            ServiceProviderHierarchy serviceHierarchy = GetService(typeof(ServiceProviderHierarchy)) as ServiceProviderHierarchy;
            if (serviceHierarchy != null)
            {
                ServiceProvider sp = (p == null ? null : new ServiceProvider(p));
                serviceHierarchy[ServiceProviderHierarchyOrder.WindowPaneSite] = sp;
            }
            else if (ows != null)
            {
                ows.SetSite(p);
            }
            else
            {
                if (p != null)
                {
                    _provider = new ServiceProvider(p);
                }
            }

            if (p != null)
            {
                Initialize();
            }
            return NativeMethods.S_OK;
        }

        /// <include file='doc\WindowPane.uex' path='docs/doc[@for="WindowPane.IVsUIElementPane.SetUIElementSite"]/*' />
        /// <internalonly/>
        /// <devdoc>
        /// IVsUIElementPane implementation.
        /// </devdoc>
        int IVsUIElementPane.SetUIElementSite(IOleServiceProvider p) {
            // If classes derived from WindowPane explicitly implemented IVsWindowPane, and relied on the explicit implementation of SetSite to be called,
            // we should make sure we call them.  Otherwise, IVsWindowPane.SetSite will call SetSiteInternal in the default implementation.
            return ((IVsWindowPane)this).SetSite(p);
        }

        private int InternalTranslateAccelerator(Microsoft.VisualStudio.OLE.Interop.MSG[] msg) {
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

        /// <include file='doc\WindowPane.uex' path='docs/doc[@for="WindowPane.IVsUIElementPane.TranslateUIElementAccelerator"]/*' />
        /// <internalonly/>
        /// <devdoc>
        /// IVsUIElementPane implementation.
        /// </devdoc>
        int IVsUIElementPane.TranslateUIElementAccelerator(Microsoft.VisualStudio.OLE.Interop.MSG[] msg) {
            return InternalTranslateAccelerator(msg);
        }

        #region IVsWindowPane Members

        [System.Obsolete("The IVsWindowPane interface on the WindowPane is obsolete, use IVsUIElementPane")]
        int IVsWindowPane.ClosePane()
        {
            OnClose();
            return NativeMethods.S_OK;
        }

        [System.Obsolete("The IVsWindowPane interface on the WindowPane is obsolete, use IVsUIElementPane")]
        int IVsWindowPane.CreatePaneWindow(IntPtr hwndParent, int x, int y, int cx, int cy, out IntPtr hwnd)
        {
            if (InitializationMode != PaneInitializationMode.Uninitialized)
                throw new InvalidOperationException("The WindowPane is already initialized");

            // Indicate to derived classes that IVsWindowPane.CreatePaneWindow was used, and not IVsUIElementPane.CreateUIElementPane
            InitializationMode = PaneInitializationMode.IVsWindowPane;

            // We should call OnCreate one time for derived classes to pre-initialize themselves.
            // This should be called before accessing the Content or Window properties.
            OnCreate();

            hwnd = IntPtr.Zero;
            if (Content == null && Window == null)
                throw new InvalidOperationException("A WindowPane derived type must provide either a content control or a HWND.   If the tool is WPF based IVsUIElementPane.CreteUIElement should be used.");

            int hresult = NativeMethods.S_OK;
            if (Content != null)
            {
                // This path is unusual in that the content of this frame is WPF but it is being requested as an HWND through this
                // obsolete API.   Create a HwndSource wrapper around the FrameworkElement using the provided parent
                if (Content is FrameworkElement || Content is IVsUIWpfElement)
                {
                    // Create a HwndSource for the the content 
                    HwndSource contentSource = new HwndSource(/* classStyle */ 0,
                        NativeMethods.WS_CHILD | NativeMethods.WS_CLIPSIBLINGS | NativeMethods.WS_VISIBLE,
                        /* exStyle */ 0,
                        /* x, y */ 0, 0,
                        /* name */ "",  // no name for this item. 
                        hwndParent);

                    contentSource.SizeToContent = SizeToContent.Manual;
                    if (Content is IVsUIWpfElement)
                    {
                        object element = null;
                        ((IVsUIWpfElement)Content).CreateFrameworkElement(out element);
                        contentSource.RootVisual = (FrameworkElement)element;
                    }
                    else
                    {
                        contentSource.RootVisual = (FrameworkElement)Content;
                    }

                    contentSource.Disposed += delegate(object sender, EventArgs e)
                    {
                        this.Dispose();
                    };
                    
                    hwnd = contentSource.Handle;
                }
                // If the content is already win32 and impliments the IVsUIWin32Element, we have little to do
                else if (Content is IVsUIWin32Element)
                {
                    hresult = ((IVsUIWin32Element)Content).Create(hwndParent, out hwnd);
                }
            }
            else if (Window != null)
            {
                // If our derived class provided a Win32 control, create it with the provided parent
                win32Wrapper = new UIWin32ElementWrapper(this);
                hresult = win32Wrapper.Create(hwndParent, out hwnd);
            }

            return hresult;
        }

        [System.Obsolete("The IVsWindowPane interface on the WindowPane is obsolete, use IVsUIElementPane")]
        int IVsWindowPane.GetDefaultSize(SIZE[] pSize) {
            return NativeMethods.E_NOTIMPL;
        }

        [System.Obsolete("The IVsWindowPane interface on the WindowPane is obsolete, use IVsUIElementPane")]
        int IVsWindowPane.LoadViewState(IStream pStream) {
            return NativeMethods.E_NOTIMPL;
        }

        [System.Obsolete("The IVsWindowPane interface on the WindowPane is obsolete, use IVsUIElementPane")]
        int IVsWindowPane.SaveViewState(IStream pStream) {
            return NativeMethods.E_NOTIMPL;
        }

        [System.Obsolete("The IVsWindowPane interface on the WindowPane is obsolete, use IVsUIElementPane")]
        int IVsWindowPane.SetSite(Microsoft.VisualStudio.OLE.Interop.IServiceProvider psp)
        {
            return InternalSetSite(psp);
        }

        [System.Obsolete("The IVsWindowPane interface on the WindowPane is obsolete, use IVsUIElementPane")]
        int IVsWindowPane.TranslateAccelerator(Microsoft.VisualStudio.OLE.Interop.MSG[] lpmsg)
        {
            return InternalTranslateAccelerator(lpmsg);
        }

        #endregion

        /// <devdoc>
        /// Enumerates the possible initialization states for a WindowPane instance.
        /// </devdoc>
        protected enum PaneInitializationMode
        {
            Uninitialized = 0,
            IVsWindowPane,
            IVsUIElementPane
        }
    }
}

