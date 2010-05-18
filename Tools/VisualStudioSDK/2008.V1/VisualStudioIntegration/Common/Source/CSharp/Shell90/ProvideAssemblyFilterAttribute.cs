//------------------------------------------------------------------------------
// <copyright file="ProvideAssemblyFilterAttribute.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>                                                                
//------------------------------------------------------------------------------

namespace Microsoft.VisualStudio.Shell {
    
    using System;
    using Microsoft.VisualStudio.Shell.Interop;

    /// <include file='doc\ProvideAssemblyFilterAttribute.uex' path='docs/doc[@for="ProvideAssemblyFilterAttribute"]' />
    /// <devdoc>
    ///    Provides an assembly filter for a toolbox item configuration object.  Place this attribute on an object
    ///    that implements IConfigureToolboxItem to describe the assemblies the object wishes to filter.
    /// </devdoc>
    [AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public sealed class ProvideAssemblyFilterAttribute : Attribute {
        private string _assemblyFilter;

        /// <include file='doc\ProvideAssemblyFilterAttribute.uex' path='docs/doc[@for="ProvideAssemblyFilterAttribute.ProvideAssemblyFilterAttribute"]' />
        /// <devdoc>
        ///    Constructor
        /// </devdoc>
        public ProvideAssemblyFilterAttribute(string assemblyFilter) {
            if (assemblyFilter == null) {
                throw new ArgumentNullException("assemblyFilter");
            }

            if (assemblyFilter.Length == 0) {
                throw new ArgumentException(Resources.General_ExpectedNonEmptyString, "assemblyFilter");
            }

            _assemblyFilter = assemblyFilter;
        }

        /// <include file='doc\ProvideAssemblyFilterAttribute.uex' path='docs/doc[@for="ProvideAssemblyFilterAttribute.AssemblyFilter"]' />
        /// <devdoc>
        ///    The filter for the toolbox item configuration object.  Filters are used to optimize which toolbox item configuration objects
        ///    are invoked when a new toolbox item is added.  Filters allow you to specify as much as as little of an assembly as you 
        ///    like.  Here are some examples:
        /// 
        ///    All Assemblies:  *
        ///    Any version of System.Windows.Forms: System.Windows.Forms
        ///    
        /// </devdoc>
        public string AssemblyFilter {
            get {
                return _assemblyFilter;
            }
        }
    }
}
