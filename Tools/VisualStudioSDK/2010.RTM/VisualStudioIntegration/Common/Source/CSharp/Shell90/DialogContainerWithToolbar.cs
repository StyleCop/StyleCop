//------------------------------------------------------------------------------
// <copyright file="WindowPane.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>                                                                
//------------------------------------------------------------------------------

using System;
using Microsoft.VisualStudio.OLE.Interop;
using Microsoft.VisualStudio.Shell.Interop;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows.Forms;
using System.Security.Permissions;

using IOleServiceProvider = Microsoft.VisualStudio.OLE.Interop.IServiceProvider;
using IServiceProvider = System.IServiceProvider;
using IMessageFilter = System.Windows.Forms.IMessageFilter;

namespace Microsoft.VisualStudio.Shell {

    /// <include file='doc\DialogContainerWithToolbar.uex' path='docs/doc[@for="DialogContainerWithToolbar"]/*' />
    /// <devdoc>
    /// This class is the base class for forms that need to be displayed as modal dialogs inside VisualStudio.
    /// </devdoc>
    [CLSCompliant(false)]
    public class DialogContainerWithToolbar : Form,
        IVsToolWindowToolbar,
        IServiceProvider,
        IMessageFilter
    {
        /// <devdoc>
        /// This class is used to change the control contained by the form to a
        /// IVsWindowPane. This is expecially needed if the control is a form,
        /// because WinForms will not allow us to make it child of another form.
        /// </devdoc>
        private class WindowPaneAdapter : WindowPane
        {
            private Control control;
            private DialogContainerWithToolbar container;
            private IntPtr paneHwnd;

            private int left;
            private int top;
            private int height;
            private int width;

            public WindowPaneAdapter(DialogContainerWithToolbar container, Control control) :
                base ((IServiceProvider)container)
            {
                this.container = container;
                this.paneHwnd = IntPtr.Zero;
                this.control = control;
            }

            protected override void Dispose(bool disposing)
            {
                if (disposing)
                {
                    if (null != control)
                    {
                        control.Dispose();
                        control = null;
                    }
                    paneHwnd = IntPtr.Zero;
                }
                base.Dispose(disposing);
            }

            public IntPtr Handle
            {
                get { return paneHwnd; }
            }

            public void Focus()
            {
                control.Focus();
            }

            // Create the pane at the specific coordinates.
            public void Create(int left, int top, int height, int width)
            {
                // Check if the pane was created before.
                if (IntPtr.Zero != paneHwnd)
                    throw new InvalidOperationException();

                // Create the object.
                NativeMethods.ThrowOnFailure(
                    ((IVsWindowPane)this).CreatePaneWindow(container.Handle, left, top, width, height, out paneHwnd));

                // Store the coordinates
                this.left = left;
                this.top = top;
                this.height = height;
                this.width = width;
            }

            // Returns the IWin32Window interface (used to access the handle of the control)
            public override IWin32Window Window
            {
                get { return (IWin32Window)control;  }
            }

            // Move the the pane to the specific coordinates.
            public void Move(int left, int top, int height, int width)
            {
                if (IntPtr.Zero == Handle)
                    return;

                bool result = UnsafeNativeMethods.SetWindowPos(
                                Handle, 
                                IntPtr.Zero, 
                                left, 
                                top,
                                width,
                                height,
                                NativeMethods.SWP_NOZORDER | NativeMethods.SWP_NOACTIVATE);

                if ( !result)
                    throw new Exception();

                this.left = left;
                this.top = top;
                this.height = height;
                this.width = width;
            }

            public int Left
            {
                get { return left; }
            }

            public int Top
            {
                get { return top; }
            }

            public int Height
            {
                get { return height; }
            }

            public int Width
            {
                get { return width; }
            }
        }

        private class ShowDialogContainer : Container
        {
            private IServiceProvider provider;
            public ShowDialogContainer(IServiceProvider sp)
            {
                provider = sp;
            }

            protected override object GetService(Type serviceType)
            {
                if (provider != null)
                {
                    object service = provider.GetService(serviceType);
                    if (null != service)
                        return service;
                }
                return base.GetService(serviceType);
            }
        }

        // Variables to handle the contained control
        private WindowPaneAdapter containedForm;
        private System.Drawing.Size controlSize;

        // Toolbar handling
        private IVsToolWindowToolbarHost toolbarHost;
        private RECT toolbarRect;
        private CommandID toolbarCommandId;
        private VSTWT_LOCATION toolbarLocation;

        // Services
        private IServiceProvider provider;
        private OleMenuCommandService commandService;
        private uint commandTargetCookie;

        /// <include file='doc\DialogContainerWithToolbar.uex' path='docs/doc[@for="DialogContainerWithToolbar.DialogContainerWithToolbar"]/*' />
        /// <devdoc>
        /// Constructor of the DialogContainerWithToolbar. This constructor allow the caller to set a IServiceProvider,
        /// the conatined control and an additional IOleCommandTarget implementation that will be chained to the one
        /// implemented by OleMenuCommandTarget.
        /// </devdoc>
        public DialogContainerWithToolbar(IServiceProvider sp, Control contained, IOleCommandTarget parentCommandTarget)
        {
            if (null == contained)
                throw new ArgumentNullException("contained");

            if (null == sp)
                throw new ArgumentNullException("sp");

            PrivateInit(sp, contained, parentCommandTarget);
        }

        /// <include file='doc\DialogContainerWithToolbar.uex' path='docs/doc[@for="DialogContainerWithToolbar.DialogContainerWithToolbar1"]/*' />
        /// <devdoc>
        /// Constructor of the DialogContainerWithToolbar. This constructor allow the caller to set a IServiceProvider and
        /// the conatined control.
        /// </devdoc>
        public DialogContainerWithToolbar(IServiceProvider sp, Control contained)
        {
            if (null == contained)
                throw new ArgumentNullException("contained");

            if (null == sp)
                throw new ArgumentNullException("sp");

            IOleCommandTarget parentTarget = contained as IOleCommandTarget;
            PrivateInit(sp, contained, parentTarget);
        }

        /// <include file='doc\DialogContainerWithToolbar.uex' path='docs/doc[@for="DialogContainerWithToolbar.DialogContainerWithToolbar2"]/*' />
        /// <devdoc>
        /// Constructor of the DialogContainerWithToolbar. This constructor allow the caller to set a IServiceProvider.
        /// </devdoc>
        public DialogContainerWithToolbar(IServiceProvider sp)
        {
            if (null == sp)
                throw new ArgumentNullException("sp");

            PrivateInit(sp, null, null);
        }

        /// <include file='doc\DialogContainerWithToolbar.uex' path='docs/doc[@for="DialogContainerWithToolbar.DialogContainerWithToolbar3"]/*' />
        /// <devdoc>
        /// Constructor of the DialogContainerWithToolbar.
        /// </devdoc>
        public DialogContainerWithToolbar()
        {
            PrivateInit(null, null, null);
        }

        private void RegisterCommandTarget()
        {
            if (null == provider)
                throw new InvalidOperationException();

            IVsRegisterPriorityCommandTarget registerCommandTarget = (IVsRegisterPriorityCommandTarget)provider.GetService(typeof(SVsRegisterPriorityCommandTarget));
            if (null != registerCommandTarget)
                NativeMethods.ThrowOnFailure(
                    registerCommandTarget.RegisterPriorityCommandTarget(
                        0,
                        (IOleCommandTarget)commandService,
                        out commandTargetCookie));
        }

        private void PrivateInit(IServiceProvider sp, Control contained, IOleCommandTarget parentTarget)
        {
            provider = sp;

            commandTargetCookie = 0;
            if (null == parentTarget)
            {
                commandService = new OleMenuCommandService(sp);
            }
            else
            {
                commandService = new OleMenuCommandService(sp, parentTarget);
            }
            if (null != sp)
            {
                // Now we have to register the IOleCommandTarget implemented by the OleCommandService
                // as a priority command target, so it will be called by the shell.
                RegisterCommandTarget();
            }

            // Set the defaults for the toolbar (empty toolbar placed at the top)
            toolbarRect.left = 0;
            toolbarRect.top = 0;
            toolbarRect.right = 0;
            toolbarRect.bottom = 0;
            toolbarCommandId = null;
            toolbarLocation = VSTWT_LOCATION.VSTWT_TOP;

            if (null == contained)
            {
                containedForm = null;
            }
            else
            {
                controlSize = contained.ClientSize;
                containedForm = new WindowPaneAdapter(this, contained);
                this.Site = contained.Site;
                Form innerForm = contained as Form;
                if (null != innerForm)
                {
                    // If the contained control is a form, then copy some
                    // of its property to this one.
                    this.AcceptButton = innerForm.AcceptButton;
                    this.AccessibleDefaultActionDescription = innerForm.AccessibleDefaultActionDescription;
                    this.AccessibleDescription = innerForm.AccessibleDescription;
                    this.AccessibleName = innerForm.AccessibleName;
                    this.AccessibleRole = innerForm.AccessibleRole;
                    this.AllowDrop = innerForm.AllowDrop;
                    this.AllowTransparency = innerForm.AllowTransparency;
                    this.AutoScaleDimensions = innerForm.AutoScaleDimensions;
                    this.AutoScaleMode = innerForm.AutoScaleMode;
                    this.AutoScroll = innerForm.AutoScroll;
                    this.AutoScrollMargin = innerForm.AutoScrollMargin;
                    this.AutoScrollMinSize = innerForm.AutoScrollMinSize;
                    this.AutoScrollPosition = innerForm.AutoScrollPosition;
                    this.BindingContext = innerForm.BindingContext;
                    this.Bounds = innerForm.Bounds;
                    this.CancelButton = innerForm.CancelButton;
                    this.ContextMenu = innerForm.ContextMenu;
                    this.ControlBox = innerForm.ControlBox;
                    this.Cursor = innerForm.Cursor;
                    this.DesktopBounds = innerForm.DesktopBounds;
                    this.DesktopLocation = innerForm.DesktopLocation;
                    this.Font = innerForm.Font;
                    this.FormBorderStyle = innerForm.FormBorderStyle;
                    this.Icon = innerForm.Icon;
                    this.IsAccessible = innerForm.IsAccessible;
                    this.MaximizeBox = innerForm.MaximizeBox;
                    this.MaximumSize = innerForm.MaximumSize;
                    this.Menu = innerForm.Menu;
                    this.MinimizeBox = innerForm.MinimizeBox;
                    this.MinimumSize = innerForm.MinimumSize;
                    this.Opacity = innerForm.Opacity;
                    this.Region = innerForm.Region;
                    this.RightToLeft = innerForm.RightToLeft;
                    this.ShowInTaskbar = innerForm.ShowInTaskbar;
                    this.SizeGripStyle = innerForm.SizeGripStyle;
                    this.StartPosition = innerForm.StartPosition;
                    this.Text = innerForm.Text;
                    this.TopLevel = innerForm.TopLevel;
                    this.TopMost = innerForm.TopMost;
                    this.TransparencyKey = innerForm.TransparencyKey;
                }
            }
            // At the end of the copy we have to set the properties that we want
            // to enforse (right now only the HelpButton on the command bar).
            this.HelpButton = true;

            // Set the callbacks for the events that this default implementation will handle.
            this.Load += new EventHandler(FormLoad);
            this.Closing += new System.ComponentModel.CancelEventHandler(OnClosing);
        }

        /// <include file='doc\DialogContainerWithToolbar.uex' path='docs/doc[@for="DialogContainerWithToolbar.SetSite"]/*' />
        /// <devdoc>
        /// Set the site for this window.
        /// </devdoc>
        public void SetSite(IServiceProvider sp)
        {
            if (null != provider)
                throw new InvalidOperationException();

            provider = sp;
            RegisterCommandTarget();
        }

        /// <include file='doc\DialogContainerWithToolbar.uex' path='docs/doc[@for="DialogContainerWithToolbar.Dispose"]/*' />
        /// <devdoc>
        /// </devdoc>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Make sure that all the resources are closed.
                OnClosing(this, new System.ComponentModel.CancelEventArgs());
            }
            base.Dispose(disposing);
        }

        private void OnClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Close the toolbar host.
            if (null != toolbarHost)
            {
                toolbarHost.Close(0);
                toolbarHost = null;
            }
            // Close and dispose the main pane.
            if (null != containedForm)
            {
                ((IVsWindowPane)containedForm).ClosePane();
                containedForm = null;
            }
            // Check if we are still registered as priority command target
            if ( (0 != commandTargetCookie) && (null != provider) )
            {
                IVsRegisterPriorityCommandTarget registerCommandTarget = GetService(typeof(SVsRegisterPriorityCommandTarget)) as IVsRegisterPriorityCommandTarget;
                if (null != registerCommandTarget)
                    registerCommandTarget.UnregisterPriorityCommandTarget(commandTargetCookie);
                commandTargetCookie = 0;
            }
            if (null != e)
                e.Cancel = false;
        }

        object IServiceProvider.GetService(System.Type serviceType)
        {
            if ( serviceType == typeof(IVsToolWindowToolbar) )
                return this;

            if ( serviceType == typeof(IOleCommandTarget) )
                return commandService;

            if ( (serviceType == typeof(IVsToolWindowToolbarHost)) && (null != ToolbarHost) )
                return ToolbarHost;

            return provider.GetService(serviceType);
        }

        /// <include file='doc\DialogContainerWithToolbar.uex' path='docs/doc[@for="DialogContainerWithToolbar.ToolbarID"]/*' />
        /// <devdoc>
        /// Gets or Sets the CommandID of the toolbar contained in this dialog.
        /// </devdoc>
        public CommandID ToolbarID
        {
            get { return toolbarCommandId; }
            set { toolbarCommandId = value; }
        }

        /// <include file='doc\DialogContainerWithToolbar.uex' path='docs/doc[@for="DialogContainerWithToolbar.ToolbarLocation"]/*' />
        /// <devdoc>
        /// Location of the toolbar (Top, left, right ot bottom).
        /// </devdoc>
        public VSTWT_LOCATION ToolbarLocation
        {
            get { return toolbarLocation; }
            set { toolbarLocation = value; }
        }

        /// <include file='doc\DialogContainerWithToolbar.uex' path='docs/doc[@for="DialogContainerWithToolbar.ToolbarHost"]/*' />
        /// <devdoc>
        /// Gets the IVsToolWindowToolbarHost interface for this window.
        /// </devdoc>
        public IVsToolWindowToolbarHost ToolbarHost
        {
            get
            {
                // Check if there is a cached pointer to the interface.
                if (null != toolbarHost)
                    return toolbarHost;

                // If no cached version exist, we have to get a new one
                // from the UIShell service.
                IVsUIShell uiShell = (IVsUIShell)provider.GetService(typeof(SVsUIShell));
                NativeMethods.ThrowOnFailure(
                    uiShell.SetupToolbar(Handle, (IVsToolWindowToolbar)this, out toolbarHost));
                return toolbarHost;
            }
        }

        /// <include file='doc\DialogContainerWithToolbar.uex' path='docs/doc[@for="DialogContainerWithToolbar.CommandService"]/*' />
        /// <devdoc>
        /// Returns the command service used to check the status or execute
        /// the toolbar's commands.
        /// </devdoc>
        public IMenuCommandService CommandService
        {
            get { return commandService as IMenuCommandService; }
        }

        int IVsToolWindowToolbar.GetBorder(RECT[] rect)
        {
            // Check that the parameter is correct.
            if ((null == rect) || (rect.Length != 1))
                throw new ArgumentException("rect");

            // Return the client area of this form.
            rect[0].left = 0;
            rect[0].top = 0;
            rect[0].right = this.ClientSize.Width;
            rect[0].bottom = this.ClientSize.Height;

            return NativeMethods.S_OK;
        }

        int IVsToolWindowToolbar.SetBorderSpace(RECT[] rect)
        {
            // Check input parameter.
            if ((null == rect) || (rect.Length != 1))
                throw new ArgumentException("rect");

            // Store the toolbar informations and resize the main pane to leave room
            // for the commandbar.
            toolbarRect = rect[0];
            ResizePane();

            return NativeMethods.S_OK;
        }

        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        bool IMessageFilter.PreFilterMessage(ref Message m)
        {
            if (null != ToolbarHost)
            {
                int lResult;
                int hr = ToolbarHost.ProcessMouseActivationModal(m.HWnd,(uint)m.Msg, (uint)m.WParam, (int)m.LParam, out lResult);
                // Check for errors.
                if ( NativeMethods.Failed(hr) )
                    return false;
                // ProcessMouseActivationModal returns S_FALSE to stop the message processing, but this
                // function have to return true in this case.
                return (hr==NativeMethods.S_FALSE);
            }

            return false;
        }

        /// <include file='doc\DialogContainerWithToolbar.uex' path='docs/doc[@for="DialogContainerWithToolbar.ShowDialog"]/*' />
        /// <devdoc>
        /// Show this window as modal dialog.
        /// </devdoc>
        public new DialogResult ShowDialog()
        {
            // if we don't have a service provider we can not show the dialog correctly
            if (null == provider)
                throw new InvalidOperationException();

            DialogResult result;
            IMessageFilter filter = this as IMessageFilter;

            // Make sure that there is non visual containment for this form
            ShowDialogContainer dialogContainer = null;
            if (this.Site == null)
            {
                dialogContainer = new ShowDialogContainer((IServiceProvider)this);
                dialogContainer.Add(this);
            }

            try
            {
                // This form needs to install its message filter in order to
                // let the toolbar process the mouse events.
                Application.AddMessageFilter(filter);

                // Show the modal dialog
                result = base.ShowDialog();
            }
            finally
            {
                if (dialogContainer != null)
                    dialogContainer.Remove(this);
                Application.RemoveMessageFilter(filter);
            }

            return result;
        }

        private void ResizePane()
        {
            // Get the size of the window.
            System.Drawing.Size mySize = this.ClientSize;

            // toolbarRect is not a real rectangle, it store the space that we have
            // to free at the left, top, right and bottom of this form for the toolbar.
            // So we have to move the main pane out of the way.
            int x = toolbarRect.left;
            int y = toolbarRect.top;
            int width = mySize.Width - toolbarRect.left - toolbarRect.right;
            int height = mySize.Height - toolbarRect.top - toolbarRect.bottom;

            containedForm.Move(x, y, height, width);
        }

        private void ResizeForm(object sender, EventArgs e)
        {
            ResizePane();
            if (ToolbarHost != null)
                ToolbarHost.BorderChanged();
        }

        private void FormLoad(object sender, EventArgs e)
        {
            if (this.DesignMode)
                return;

            if (null == containedForm)
            {
                // Handle the case that the class was constructed with the parameterless
                // constructor, so no container control is created.
                // In this case we have to create a new control that will contain all the
                // controls contained by this form and use it to create the window pane.
                Control paneControl = new UserControl();
                while (this.Controls.Count > 0)
                {
                    Control ctl = this.Controls[0];
                    ctl.Parent = paneControl;
                }
                containedForm = new WindowPaneAdapter(this, paneControl);
                controlSize = this.ClientSize;
            }

            System.Drawing.Size mySize = this.ClientSize;

            // Check if this window has a toolbar.
            if (null != toolbarCommandId)
            {
                Guid toolbarCommandSet = toolbarCommandId.Guid;
                NativeMethods.ThrowOnFailure(
                    ToolbarHost.AddToolbar(toolbarLocation, ref toolbarCommandSet, (uint)toolbarCommandId.ID));
                NativeMethods.ThrowOnFailure(ToolbarHost.Show(0));
                NativeMethods.ThrowOnFailure(ToolbarHost.ForceUpdateUI());
            }

            // Now we have to resize the form to make room for the toolbar.
            mySize.Width = controlSize.Width + toolbarRect.left + toolbarRect.right;
            mySize.Height = controlSize.Height + toolbarRect.top + toolbarRect.bottom;
            this.ClientSize = mySize;

            // Find the coordinate of the main pane.
            int x = toolbarRect.left;
            int y = toolbarRect.top;
            int width = mySize.Width - toolbarRect.left - toolbarRect.right;
            int height = mySize.Height - toolbarRect.top - toolbarRect.bottom;

            // Make sure that the pane is created.
            containedForm.Create(x, y, height, width);
            // Set the focus to the control
            containedForm.Focus();

            // Install the handler for the resize.
            this.Resize += new EventHandler(ResizeForm);
        }
    }
}
