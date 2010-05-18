//------------------------------------------------------------------------------
// <copyright file="IConfigureToolboxItem.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>                                                                
//------------------------------------------------------------------------------

namespace Microsoft.VisualStudio.Shell {
    
    using System;
    using System.Drawing.Design;
    using Microsoft.VisualStudio.Shell.Interop;

    /// <include file='doc\IConfigureToolboxItem.uex' path='docs/doc[@for="IConfigureToolboxItem"]' />
    /// <devdoc>
    ///    This interface can be implemented on a creatable object.  The toolbox service will call
    ///    ConfigureToolboxItem on this interface when a new toolbox item is first added to the
    ///    toolbox.  This gives an external party a chance to add additional data to the toolbox item's
    ///    Properties dictionary.  This data then gets serialized as a permanent part of the toolbox item.
    /// 
    ///    Objects that implement this interface should be declared through a 
    ///    ProvideToolboxItemConfigurationAttribute attached to the package.  This attribute will register 
    ///    the object under the local CLSID hive in the VS registry and also add a reference to the GUID in
    ///    VSREGROOT\ToolboxItemConfiguration.  The data contained in this registry entry
    ///    is as follows:
    /// 
    ///    VSREGROOT\ToolboxItemConfiguration
    ///        AssemblyName
    ///             ConfigurationTypeName={guid}
    /// 
    ///    As an example:
    /// 
    ///    VSREGROOT\ToolboxItemConfiguration
    ///        System, Version=2.0.3500
    ///            CompactFrameworkProvider = {GUID}
    /// 
    /// 
    ///    The assembly name is parsed and the various keys are matched.  Keys can have a
    ///    "*" in them to be taken as wildcards.  So, for example, to cover all versions
    ///    of System.WindowsForms you would specify:
    /// 
    ///    System.Windows.Forms, Version=*, PublicKeyToken=969...
    /// 
    ///    The assembly name may also be a wildcard to load the configuration object
    ///    for all toolbox items (not recommended).
    /// </devdoc>
    public interface IConfigureToolboxItem {

        /// <include file='doc\IConfigureToolboxItem.uex' path='docs/doc[@for="IConfigureToolboxItem.ConfigureToolboxItem"]' />
        /// <devdoc>
        ///     Adds extra configuration information to thish toolbox item.
        /// </devdoc>
        void ConfigureToolboxItem(ToolboxItem item);
    }
}
