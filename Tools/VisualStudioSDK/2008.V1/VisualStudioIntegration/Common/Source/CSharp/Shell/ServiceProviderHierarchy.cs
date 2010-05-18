//------------------------------------------------------------------------------
// <copyright file="ServiceProviderHierarchy.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>                                                                
//------------------------------------------------------------------------------

namespace Microsoft.VisualStudio.Shell {

    using System;
    using System.Collections.Generic;

    /// <include file='doc\ServiceProviderHierarchy.uex' path='docs/doc[@for="ServiceProviderHierarchy"]' />
    /// <devdoc>
    ///     This class acts as a hierarchical service provider.  It stores IServiceProviders in a sorted dictionary
    ///     for an ordered retrieval.  When GetService is called to retrieve a service, the service providers are queried
    ///     in a specific order.  This is useful when multiple service providers are combined such as in 
    ///     the WindowPane implementation
    /// </devdoc>
    [CLSCompliant(false)]
    public sealed class ServiceProviderHierarchy : SortedList<int, IServiceProvider>, IServiceProvider {
        
        /// <include file='doc\ServiceProviderHierarchy.uex' path='docs/doc[@for="ServiceProviderHierarchy.GetService"]' />
        /// <devdoc>
        ///     Retrieves the requested service by walking the hierarchy of service providers.
        /// </devdoc>
        public object GetService(Type serviceType) {
            
            if (serviceType == null) {
                throw new ArgumentNullException("serviceType");
            }

            object service = null;

            if (serviceType == typeof(ServiceProviderHierarchy)) {
                service = this;
            }
            else {
                foreach(IServiceProvider provider in Values) {
                    service = provider.GetService(serviceType);
                    if (service != null) {
                        break;
                    }
                }
            }

            return service;
        }
    }

    /// <include file='doc\ServiceProviderHierarchyOrder.uex' path='docs/doc[@for="ServiceProviderHierarchyOrder"]' />
    /// <devdoc>
    ///     When multiple service providers are combined in a service provider hierarchy they 
    ///     are ordered according to a numeric ordering.  This class provides recommended service
    ///     resolution order for common service providers.
    /// </devdoc>
    public sealed class ServiceProviderHierarchyOrder {
        /// <include file='doc\ServiceProviderHierarchy.uex' path='docs/doc[@for="ServiceProviderHierarchyOrder.PackageSite"]/*' />
        public const int PackageSite = 100;
        /// <include file='doc\ServiceProviderHierarchy.uex' path='docs/doc[@for="ServiceProviderHierarchyOrder.WindowPaneSite"]/*' />
        public const int WindowPaneSite = 50;
        /// <include file='doc\ServiceProviderHierarchy.uex' path='docs/doc[@for="ServiceProviderHierarchyOrder.ProjectItemContext"]/*' />
        public const int ProjectItemContext = 25;
    }
}

