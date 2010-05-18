//------------------------------------------------------------------------------
// <copyright file="TaskCategory.cs" company="Microsoft">
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

    /// <include file='doc\TaskCategory.uex' path='docs/doc[@for="TaskCategory"]' />
    /// <devdoc>
    ///     This class implements IVsTask.  It provides a 
    ///     framework-friendly way to define a package and its associated 
    ///     services.
    /// </devdoc>
    public enum TaskCategory {
        /// <include file='doc\TaskCategory.uex' path='docs/doc[@for="TaskCategory.All"]/*' />
        All = VSTASKCATEGORY.CAT_ALL,
        /// <include file='doc\TaskCategory.uex' path='docs/doc[@for="TaskCategory.BuildCompile"]/*' />
        BuildCompile = VSTASKCATEGORY.CAT_BUILDCOMPILE,
        /// <include file='doc\TaskCategory.uex' path='docs/doc[@for="TaskCategory.Comments"]/*' />
        Comments = VSTASKCATEGORY.CAT_COMMENTS,
        /// <include file='doc\TaskCategory.uex' path='docs/doc[@for="TaskCategory.CodeSense"]/*' />
        CodeSense = VSTASKCATEGORY.CAT_CODESENSE,
        /// <include file='doc\TaskCategory.uex' path='docs/doc[@for="TaskCategory.ShortCuts"]/*' />
        ShortCuts = VSTASKCATEGORY.CAT_SHORTCUTS,
        /// <include file='doc\TaskCategory.uex' path='docs/doc[@for="TaskCategory.User"]/*' />
        User = VSTASKCATEGORY.CAT_USER,
        /// <include file='doc\TaskCategory.uex' path='docs/doc[@for="TaskCategory.Misc"]/*' />
        Misc = VSTASKCATEGORY.CAT_MISC,
        /// <include file='doc\TaskCategory.uex' path='docs/doc[@for="TaskCategory.Html"]/*' />
        Html = VSTASKCATEGORY.CAT_HTML
    }
}

