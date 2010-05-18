//------------------------------------------------------------------------------
// <copyright file="DefaultRegistryRootAttribute.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>                                                                
//------------------------------------------------------------------------------

namespace Microsoft.VisualStudio.Shell {

    using System;

    /// <include file='doc\DefaultRegistryRootAttribute.uex' path='docs/doc[@for="DefaultRegistryRootAttribute"]' />
    /// <devdoc>
    ///     This attribute defines the default registry root this package was designed to work with.  
    ///     This attribute exists on the Package base class and contains the root for the version of 
    ///     Visual Studio the package was copiled for.  The various path and registry methods on 
    ///     Package make use of this attribute, as does default registration code that setup will 
    ///     use to register packages. 
    /// </devdoc>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple=false, Inherited=true)]
    public sealed class DefaultRegistryRootAttribute : Attribute {

        private string _root;
    
        /// <include file='doc\DefaultRegistryRootAttribute.uex' path='docs/doc[@for="DefaultRegistryRootAttribute.DefaultRegistryRootAttribute"]' />
        /// <devdoc>
        ///     Creates a new DefaultRegistryRootAttribute.
        /// </devdoc>
        public DefaultRegistryRootAttribute (string root) {
            if (root == null) {
                throw new ArgumentNullException("root");
            }
            _root = root;
        }
        
        /// <include file='doc\DefaultRegistryRootAttribute.uex' path='docs/doc[@for="DefaultRegistryRootAttribute.Root"]' />
        /// <devdoc>
        ///     Returns the default registry root.
        /// </devdoc>
        public string Root {
            get {
                return _root;
            }
        }
    }
}

