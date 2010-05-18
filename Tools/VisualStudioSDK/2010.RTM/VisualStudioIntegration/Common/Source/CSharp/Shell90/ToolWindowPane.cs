//------------------------------------------------------------------------------
// <copyright file="ToolWindowPane.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>                                                                
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.VisualStudio.OLE.Interop;
using Microsoft.VisualStudio.Shell.Interop;

using IOleServiceProvider = Microsoft.VisualStudio.OLE.Interop.IServiceProvider;
using IServiceProvider = System.IServiceProvider;

namespace Microsoft.VisualStudio.Shell
{
    /// <include file='doc\ToolWindowPane.uex' path='docs/doc[@for="ToolWindowPane"]/*' />
    /// <summary>
    /// Summary description for ToolWindowPane.
    /// </summary>
    [System.Runtime.InteropServices.ComVisible(true)]
    public abstract class ToolWindowPane : WindowPane
    {
        private string caption;
        private IVsWindowFrame frame = null;
        private Microsoft.VisualStudio.Shell.Package package = null;
        private CommandID toolBarCommandID = null;
        private VSTWT_LOCATION toolBarLocation;
        private int bitmapResourceID;
        private int bitmapIndex;
        private Guid toolClsid;

        /// <include file='doc\ToolWindowPane.uex' path='docs/doc[@for="ToolWindowPane.ToolWindowPane"]/*' />
        /// <summary>
        /// Constructor
        /// </summary>
        protected ToolWindowPane(IServiceProvider provider)
        :
        base(provider)
        {
            toolClsid = Guid.Empty;
            bitmapIndex = -1;
            bitmapResourceID = -1;
            toolBarLocation = VSTWT_LOCATION.VSTWT_TOP;
        }
    
        /// <include file='doc\ToolWindowPane.uex' path='docs/doc[@for="ToolWindowPane.Caption"]/*' />
        /// <summary>
        /// Get or Set the text on the title bar of the ToolWindow
        /// </summary>
        /// <value></value>
        public string Caption
        {
            get { return caption; }
            set
            {
                caption = value;
                if (frame != null && caption != null)
                {
                    // Since the window is already created, set the coresponding property
                    int hr = NativeMethods.S_OK;
                    try {
                        hr = frame.SetProperty((int)__VSFPROPID.VSFPROPID_Caption, caption);
                    } catch (COMException e) {
                        hr = e.ErrorCode;
                    }
                    Debug.Assert(hr >= 0, "Failed to set caption on toolwindow");
                }
            }
        }

        /// <include file='doc\ToolWindowPane.uex' path='docs/doc[@for="ToolWindowPane.Frame"]/*' />
        /// <summary>
        /// Get or Set the Frame (IvsWindowFrame) hosting the ToolWindow
        /// </summary>
        public object Frame
        {
            get { return frame; }
            set
            {
                frame = (IVsWindowFrame)value;
                // Fire the event to let any custom creation code run
                OnToolWindowCreated();
            }
        }

        /// <include file='doc\ToolWindowPane.uex' path='docs/doc[@for="ToolWindowPane.Package"]/*' />
        /// <summary>
        /// Get or Set the Package (Microsoft.VisualStudio.Shell.Package) owning the ToolWindow.
        /// This should only be set by the base Package class when it creates the toolwindow.
        /// </summary>
        public object Package
        {
            get { return package; }
            set
            {
                if (frame != null || package != null)
                    throw new NotSupportedException(Resources.ToolWindow_PackageOnlySetByCreator);
                package = (Microsoft.VisualStudio.Shell.Package)value;
            }
        }

        /// <include file='doc\ToolWindowPane.uex' path='docs/doc[@for="ToolWindowPane.ToolBar"]/*' />
        /// <summary>
        /// If the toolwindow has a ToolBar, it is described by this parameter.
        /// Otherwise this is null
        /// </summary>
        public CommandID ToolBar
        {
            get { return toolBarCommandID; }
            set
            {
                if (frame != null)
                    throw new Exception(Resources.ToolWindow_TooLateToAddToolbar);
                toolBarCommandID = value;
            }
        }

        /// <include file='doc\ToolWindowPane.uex' path='docs/doc[@for="ToolWindowPane.ToolBarLocation"]/*' />
        /// <summary>
        /// Get or Set where the toolbar should be in the tool window (Up, down, left, right).
        /// This parameter is based on VSTWT_LOCATION
        /// </summary>
        public int ToolBarLocation
        {
            get { return (int)toolBarLocation; }
            set
            {
                if (frame != null)
                    throw new Exception(Resources.ToolWindow_TooLateToAddToolbar);
                toolBarLocation = (VSTWT_LOCATION)value;
            }
        }

        /// <include file='doc\ToolWindowPane.uex' path='docs/doc[@for="ToolWindowPane.ToolClsid"]/*' />
        /// <summary>
        /// This is used to specify the CLSID of a tool that should be used for this toolwindow
        /// </summary>
        public Guid ToolClsid
        {
            get { return toolClsid; }
            set
            {
                if (frame != null)
                    throw new Exception(Resources.ToolWindow_TooLateToAddTool);
                toolClsid = value;
            }
        }

        /// <include file='doc\ToolWindowPane.uex' path='docs/doc[@for="ToolWindowPane.BitmapResourceID"]/*' />
        /// <summary>
        /// Get or Set the resource ID for the bitmap strip from which to take the window frame icon
        /// </summary>
        public int BitmapResourceID
        {
            get { return bitmapResourceID; }
            set
            {
                bitmapResourceID = value;
                if (frame != null && bitmapResourceID != -1)
                {
                    int hr = NativeMethods.S_OK;
                    // Since the window is already created, set the coresponding property
                    try {
                        hr = frame.SetProperty((int)__VSFPROPID.VSFPROPID_BitmapResource, bitmapResourceID);
                    } catch (COMException e) {
                        hr = e.ErrorCode;
                    }
                    Debug.Assert(hr >= 0, "Failed to set bitmap resource on toolwindow");
                }
            }
        }

        /// <include file='doc\ToolWindowPane.uex' path='docs/doc[@for="ToolWindowPane.BitmapIndex"]/*' />
        /// <summary>
        /// Get or Set the index of the image to use in the bitmap strip for the window frame icon
        /// </summary>
        public int BitmapIndex
        {
            get { return bitmapIndex; }
            set
            {
                bitmapIndex = value;
                if (frame != null && bitmapIndex != -1)
                {
                    int hr = NativeMethods.S_OK;
                    // Since the window is already created, set the coresponding property
                    try {
                        hr = frame.SetProperty((int)__VSFPROPID.VSFPROPID_BitmapIndex, bitmapIndex);
                    } catch (COMException e) {
                        hr = e.ErrorCode;
                    }
                    Debug.Assert(hr >= 0, "Failed to set bitmap index on toolwindow");
                }
            }
        }

        /// <include file='doc\ToolWindowPane.uex' path='docs/doc[@for="ToolWindowPane.GetIVsWindowPane"]/*' />
        /// <summary>
        /// This method make it possible to provide an IVsWindowPane not derived from ToolWindowPane
        /// To support that scenario one would override this method and create their IVsWindowPane and
        /// return it.
        /// </summary>
        /// <returns>IVsWindowPane to be hosted in the toolwindow frame</returns>
        public virtual object GetIVsWindowPane()
        {
            return (IVsWindowPane)this;
        }

        /// <include file='doc\ToolWindowPane.uex' path='docs/doc[@for="ToolWindowPane.OnToolWindowCreated"]/*' />
        /// <summary>
        /// This method can be overriden by the derived class to execute
        /// any code that needs to run after the IVsWindowFrame is created.
        /// If the toolwindow has a toolbar with a combobox, it should make
        /// sure its command handler are set by the time they return from
        /// this method.
        /// This is called when someone set the Frame property.
        /// </summary>
        public virtual void OnToolWindowCreated()
        {
            Debug.Assert(frame != null, "Frame should be set before this method is called");

            // If any property were set, set them on the frame (setting our properties will take care of it)
            Caption = caption;
            BitmapResourceID = bitmapResourceID;
            BitmapIndex = bitmapIndex;
        }

        /// <summary>
        /// This should be overriden if you want to run code before the window is shown
        /// but after its toolbar is added.
        /// </summary>
        public virtual void OnToolBarAdded()
        {
        }
    }
}
