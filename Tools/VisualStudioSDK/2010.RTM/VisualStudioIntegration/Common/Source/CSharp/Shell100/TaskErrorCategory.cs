//------------------------------------------------------------------------------
// <copyright file="TaskErrorCategory.cs" company="Microsoft">
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

    /// <include file='doc\TaskErrorCategory.uex' path='docs/doc[@for="TaskErrorCategory"]' />
    /// <devdoc>
    /// </devdoc>
    public enum TaskErrorCategory {
        /// <include file='doc\TaskErrorCategory.uex' path='docs/doc[@for="TaskErrorCategory.Error"]' />
        Error = __VSERRORCATEGORY.EC_ERROR,
        /// <include file='doc\TaskErrorCategory.uex' path='docs/doc[@for="TaskErrorCategory.Warning"]' />
        Warning = __VSERRORCATEGORY.EC_WARNING,
        /// <include file='doc\TaskErrorCategory.uex' path='docs/doc[@for="TaskErrorCategory.Message"]' />
        Message = __VSERRORCATEGORY.EC_MESSAGE
    }
}

