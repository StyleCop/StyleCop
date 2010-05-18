//------------------------------------------------------------------------------
// <copyright file="MsiTokenAttribute.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>                                                                
//------------------------------------------------------------------------------

namespace Microsoft.VisualStudio.Shell {

    using System;

    /// <include file='doc\MsiTokenAttribute.uex' path='docs/doc[@for="MsiTokenAttribute"]' />
    /// <devdoc>
    ///     This attribute defines a token string for the MSI installer.  RegPkg
    ///     will search for these attributes on a package class to identify custom
    ///     replacement tokens when generating registry scripts for the Microsoft
    ///     Installer.  Possible token names vary, but RegPkg may query for the 
    ///     following tokens:
    ///
    ///     $ComponentPath  : the path to the component.
    ///     SystemFolder    : the path to the OS system folder (%systemroot%\system32)
    ///
    /// </devdoc>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple=true, Inherited=false)]
    public sealed class MsiTokenAttribute : Attribute {

        private string _name;
        private string _value;
    
        /// <include file='doc\MsiTokenAttribute.uex' path='docs/doc[@for="MsiTokenAttribute.MsiTokenAttribute"]' />
        /// <devdoc>
        ///     Creates a new MsiTokenAttribute.
        /// </devdoc>
        public MsiTokenAttribute (string name, string value) {
            if (name == null) {
                throw new ArgumentNullException("name");
            }

            if (value == null) {
                throw new ArgumentNullException("value");
            }

            _name = name;
            _value = value;
        }
        
        /// <include file='doc\MsiTokenAttribute.uex' path='docs/doc[@for="MsiTokenAttribute.Name"]' />
        /// <devdoc>
        ///     Returns the MSI token name.
        /// </devdoc>
        public string Name {
            get {
                return _name;
            }
        }
        
        /// <include file='doc\MsiTokenAttribute.uex' path='docs/doc[@for="MsiTokenAttribute.Value"]' />
        /// <devdoc>
        ///     Returns the MSI token value.
        /// </devdoc>
        public string Value {
            get {
                return _value;
            }
        }
    }
}

