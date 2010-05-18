//------------------------------------------------------------------------------
// <copyright file="ResourcePicker.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>                                                                
//------------------------------------------------------------------------------

namespace Microsoft.VisualStudio.Shell {

    using System.Runtime.Serialization.Formatters;
    using System.Runtime.InteropServices;
    using System.Diagnostics;
    using System;
    using System.IO;
    using System.Security.Permissions;
    using Microsoft.Win32;
    using System.Collections;
    using System.Windows.Forms;
    using System.Drawing;
    using System.Drawing.Design;
    using System.ComponentModel;
    using System.ComponentModel.Design;
    using System.ComponentModel.Design.Serialization;
    using System.Windows.Forms.ComponentModel;
    using System.Windows.Forms.Design;
    using System.Resources;
    using System.Resources.Tools;
    using System.Globalization;


    /// <include file='doc\IResXResourceService.uex' path='docs/doc[@for="IResXResourceService"]/*' />
    /// <devdoc>
    ///    <para>
    ///         This interface is an abstraction layer that allows various clients to control resxreaders and writers
    ///         that get used within Visual Studio.
    ///    </para>
    /// </devdoc>
    public interface IResXResourceService {

        /// <include file='doc\IResXResourceService.uex' path='docs/doc[@for="GetResXResourceReader"]/*' />
        /// <devdoc>
        ///    <para>
        ///         Returns a resx resource reader given a basepath and name
        ///    </para>
        /// </devdoc>
        IResourceReader GetResXResourceReader(string resXFullName, bool useResXDataNodes);

        /// <include file='doc\IResXResourceService.uex' path='docs/doc[@for="GetResXResourceReader"]/*' />
        /// <devdoc>
        ///    <para>
        ///         Returns a resx resource reader given a basepath and name
        ///    </para>
        /// </devdoc>
        IResourceReader GetResXResourceReader(TextReader textReader, bool useResXDataNodes, string basePath);

        /// <include file='doc\IResXResourceService.uex' path='docs/doc[@for="GetResXResourceWriter"]/*' />
        /// <devdoc>
        ///    <para>
        ///         Returns a resx resource writer given a basepath and name
        ///    </para>
        /// </devdoc>
        IResourceWriter GetResXResourceWriter(string resXFullName);

        /// <include file='doc\IResXResourceService.uex' path='docs/doc[@for="GetResXResourceWriter"]/*' />
        /// <devdoc>
        ///    <para>
        ///         Returns a resx resource writer given a basepath and name
        ///    </para>
        /// </devdoc>
        IResourceWriter GetResXResourceWriter(TextWriter textWriter, string basePath);
    }
}
