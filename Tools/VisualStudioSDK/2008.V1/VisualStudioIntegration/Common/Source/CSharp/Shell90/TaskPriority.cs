//------------------------------------------------------------------------------
// <copyright file="TaskPriority.cs" company="Microsoft">
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

    /// <include file='doc\TaskPriority.uex' path='docs/doc[@for="TaskPriority"]' />
    /// <devdoc>
    ///     This class implements IVsTask.  It provides a 
    ///     framework-friendly way to define a package and its associated 
    ///     services.
    /// </devdoc>
    public enum TaskPriority {
    	/// <include file='doc\TaskPriority.uex' path='docs/doc[@for="TaskPriority.High"]/*' />
    	High = VSTASKPRIORITY.TP_HIGH,
    	/// <include file='doc\TaskPriority.uex' path='docs/doc[@for="TaskPriority.Normal"]/*' />
    	Normal = VSTASKPRIORITY.TP_NORMAL,
    	/// <include file='doc\TaskPriority.uex' path='docs/doc[@for="TaskPriority.Low"]/*' />
    	Low = VSTASKPRIORITY.TP_LOW
    }
}

