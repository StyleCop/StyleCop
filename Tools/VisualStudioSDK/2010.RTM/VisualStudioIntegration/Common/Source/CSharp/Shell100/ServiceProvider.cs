//------------------------------------------------------------------------------
// <copyright file="ServiceProvider.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>                                                                
//------------------------------------------------------------------------------

namespace Microsoft.VisualStudio.Shell {

    using Microsoft.VisualStudio.OLE.Interop;
    using Microsoft.VisualStudio.Shell.Interop;
    using System;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using System.Threading;

    using IOleServiceProvider = Microsoft.VisualStudio.OLE.Interop.IServiceProvider;
    using IServiceProvider = System.IServiceProvider;

    /// <include file='doc\ServiceProvider.uex' path='docs/doc[@for="ServiceProvider"]' />
    /// <devdoc>
    ///     This class acts as a bridge between Microsoft.VisualStudio.OLE.Interop.IServiceProvider 
    ///     and System.IServiceProvider.  It implements System.IServiceProvider and takes 
    ///     as a constructor argument an instance of Microsoft.VisualStudio.OLE.Interop.IServiceProvider.  
    ///     It supports both GUID and type based lookups and also has debug code to assert 
    ///     for common native implementation pitfalls, like not implementing IUnknown on 
    ///     an object or requiring a specific IID along with a matching SID.
    /// </devdoc>
    [CLSCompliant(false)]
	[System.Runtime.InteropServices.ComVisible(true)]
    public sealed class ServiceProvider : IServiceProvider, IDisposable, IObjectWithSite {
        
        private static TraceSwitch TRACESERVICE = new TraceSwitch("TRACESERVICE", "ServiceProvider: Trace service provider requests.");

        private IOleServiceProvider    serviceProvider;
        private bool                   defaultServices;

        /// <include file='doc\ServiceProvider.uex' path='docs/doc[@for="ServiceProvider.ServiceProvider"]' />
        /// <devdoc>
        ///     Creates a new ServiceProvider object and uses the given interface to resolve
        ///     services.
        /// </devdoc>
        public ServiceProvider(IOleServiceProvider sp) : this(sp, true){
        }
        
        /// <include file='doc\ServiceProvider.uex' path='docs/doc[@for="ServiceProvider.ServiceProvider1"]' />
        /// <devdoc>
        ///     Creates a new ServiceProvider object and uses the given interface to resolve
        ///     services.  If defaultServices is true (the default) this service  provider will
        ///     respond to Microsoft.VisualStudio.OLE.Interop.IServiceProvider and IObjectWithSite
        ///     as services.  A query for Microsoft.VisualStudio.OLE.Interop.IServiceProvider will
        ///     return the underlying COM service provider and a query for IObjectWithSite will
        ///     return this object.  If false is passed into defaultServices these two services
        ///     will not be provided and the service provider will be "transparent".
        /// </devdoc>
        public ServiceProvider(IOleServiceProvider sp, bool defaultServices) {
            if (sp == null) {
                throw new ArgumentNullException("sp");
            }
            this.serviceProvider = sp;
            this.defaultServices = defaultServices;
        }

        /// <devdoc>
        ///     Private, default constructor used to create a dummy ServiceProvider with
        ///     no underlying services.
        /// </devdoc>
        private ServiceProvider() {
        }
        
        /// <include file='doc\ServiceProvider.uex' path='docs/doc[@for="ServiceProvider.Dispose"]' />
        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc>
        public void Dispose() {
            if (serviceProvider != null) {
                serviceProvider = null;
            }
        }

        /// <include file='doc\ServiceProvider.uex' path='docs/doc[@for="ServiceProvider.GetService"]' />
        /// <devdoc>
        ///     Retrieves the requested service.
        /// </devdoc>
        public object GetService(Type serviceType) {

            if (serviceType == null) {
                throw new ArgumentNullException("serviceType");
            }

            // If we have already been disposed, disallow all service
            // requests.
            //
            if (serviceProvider == null) {
                return null;
            }
            
            // First, can we resolve this service class into a GUID?  If not, then
            // we have nothing to pass.
            //
            Debug.WriteLineIf(TRACESERVICE.TraceVerbose, "Resolving service '" + serviceType.FullName + " through the service provider " + serviceProvider.ToString() + ".");
            return GetService(serviceType.GUID, serviceType);
        }

        /// <include file='doc\ServiceProvider.uex' path='docs/doc[@for="ServiceProvider.GetService1"]' />
        /// <devdoc>
        ///     Retrieves the requested service.
        /// </devdoc>
        public object GetService(Guid guid) {
            // If we have already been disposed, disallow all service
            // requests.
            //
            if (serviceProvider == null) {
                return null;
            }
            return GetService(guid, null);
        }

        /// <devdoc>
        ///     Retrieves the requested service.  The guid must be specified; the class is only
        ///     used when debugging and it may be null.
        /// </devdoc>
        private object GetService(Guid guid, Type serviceType) {
            object service = null;

            // No valid guid on the passed in class, so there is no service for it.
            //
            if (guid.Equals(Guid.Empty)) {
                Debug.WriteLineIf(TRACESERVICE.TraceVerbose, "\tNo SID -- Guid is empty");
                return null;
            }

            // We provide a couple of services of our own.
            //
            if (defaultServices) {
                if (guid.Equals(NativeMethods.IID_IServiceProvider)) {
                    return serviceProvider;
                }
                if (guid.Equals(NativeMethods.IID_IObjectWithSite)) {
                    return (IObjectWithSite)this;
                }
            }

            IntPtr pUnk = IntPtr.Zero;
            Guid guidUnk = NativeMethods.IID_IUnknown;
            int hr = serviceProvider.QueryService(ref guid, ref guidUnk, out pUnk);

            if ( (NativeMethods.Succeeded(hr)) && (IntPtr.Zero != pUnk) ) {
                try {
                    service = Marshal.GetObjectForIUnknown(pUnk);
                }
                finally {
                    Marshal.Release(pUnk);
                }
            }
            else {
                service = null;

                // These may be interesting to log.
                //
                Debug.WriteLineIf(TRACESERVICE.TraceVerbose, "\tQueryService failed");

                #if DEBUG
                // Ensure that this service failure was not the result of a bad QI implementation.
                // In C++, 99% of a service query uses SID == IID, but for us, we always use IID = IUnknown
                // first.  If the service didn't implement IUnknown correctly, we'll fail the service request
                // and it's very difficult to track this down. 
                //
                pUnk = IntPtr.Zero;
                hr = serviceProvider.QueryService(ref guid, ref guid, out pUnk);

                if ( (NativeMethods.Succeeded(hr)) && (IntPtr.Zero != pUnk) ) {
                    object obj = null;
                    try {
                        obj = Marshal.GetObjectForIUnknown(pUnk);
                    }
                    finally {
                        Marshal.Release(pUnk);
                    }

                    // Note that I do not return this service if we succeed -- I don't
                    // want to make debug work correctly when retail doesn't!
                    Debug.Assert(!System.Runtime.InteropServices.Marshal.IsComObject(obj),
                                 "The service " + (serviceType != null ? serviceType.Name : guid.ToString()) +
                                 " implements it's own interface, but does not implement IUnknown!\r\n" +
                                 "This is a bad service implementation, not a problem in the CLR service provider mechanism." + obj.ToString());
                }

                #endif
            }

            return service;
        }

        internal TInterfaceType GetService<TInterfaceType>(Type serviceType) where TInterfaceType : class
        {
            TInterfaceType service = GetService(serviceType) as TInterfaceType;
            if (service == null)
            {
                throw new InvalidOperationException(string.Format(Resources.Culture, Resources.General_MissingService, serviceType.FullName));
            }
            return service;
        }

        /// <include file='doc\ServiceProvider.uex' path='docs/doc[@for="ServiceProvider.IObjectWithSite.GetSite"]/*' />
        /// <internalonly/>
        /// <devdoc>
        /// Retrieves the current site object we're using to
        /// resolve services.
        /// </devdoc>
        void IObjectWithSite.GetSite(ref Guid riid, out IntPtr ppv) {
            object o = GetService(riid);
            if (o == null) {
                Marshal.ThrowExceptionForHR(NativeMethods.E_NOINTERFACE);
            }

            IntPtr punk = Marshal.GetIUnknownForObject(o);
            int hr = Marshal.QueryInterface(punk, ref riid, out ppv);
            Marshal.Release(punk);
            if (NativeMethods.Failed(hr)) {
                Marshal.ThrowExceptionForHR(hr);
            }
        }

        /// <include file='doc\ServiceProvider.uex' path='docs/doc[@for="ServiceProvider.IObjectWithSite.SetSite"]/*' />
        /// <internalonly/>
        /// <devdoc>
        /// Sets the site object we will be using to resolve services.
        /// </devdoc>
        void IObjectWithSite.SetSite(object pUnkSite) {
            if (pUnkSite is IOleServiceProvider) {
                serviceProvider = (IOleServiceProvider)pUnkSite;
            }
        }

        /// <devdoc>
        ///     The global service provider.
        ///     Note that this is not a ThreadStatic field. Once a non-empty
        ///     global service provider has been created, it will act as the
        ///     proxy for all other threads.
        /// <devdoc>
        static ServiceProvider globalProvider;

        /// <summary>
        ///     The thread which set globalProvider
        /// </summary>
        static Thread threadOwningGlobalProvider;

        static void SetGlobalProvider(ServiceProvider sp)
        {
            globalProvider = sp;
            threadOwningGlobalProvider = Thread.CurrentThread;
        }

        /// <summary>
        ///     Is the calling thread the same as the thread which set the
        ///     global provider.
        /// </summary>
        /// <returns></returns>
        internal static bool CheckServiceProviderThreadAccess()
        {
            return threadOwningGlobalProvider == Thread.CurrentThread;
        }

        /// <devdoc>
        ///     Determines if the given ServiceProvider is uninitialized
        /// </devdoc>
        static bool IsNullOrUnsited(ServiceProvider sp)
        {
            return sp == null || sp.serviceProvider == null;
        }

        /// <include file='doc\ServiceProvider.uex' path='docs/doc[@for="ServiceProvider.GlobalProvider"]' />
        /// <devdoc>
        /// Get the global service provider for the calling thread. The global
        /// service provider is set by calling ServiceProvider.CreateFromSetSite.
        /// If ServiceProvider.CreateFromSetSite has not been called, an attempt
        /// is made to retrieve the a service provider from the OLE message filter.
        /// If no suitable service provider can be found on the calling thread, then
        /// a new, empty ServiceProvider is returned.
        /// </devdoc>
        public static ServiceProvider GlobalProvider
        {
            get
            {
                if (IsNullOrUnsited(globalProvider))
                {
                    IOleServiceProvider oleProvider = OleServiceProvider.GlobalProvider;
                    if (oleProvider != null)
                    {
                        Debug.WriteLineIf(TRACESERVICE.TraceVerbose, "Initializing ServiceProvider.GlobalProvider from OLE message filter.");
                        SetGlobalProvider(new ServiceProvider(oleProvider));
                    }
                    else if(globalProvider == null)
                    {
                        Debug.WriteLineIf(TRACESERVICE.TraceVerbose, "Creating a dummy global ServiceProvider because OleServiceProvider.GlobalProvider is unavailable for this thread.");
                        SetGlobalProvider(new ServiceProvider());
                    }
                }
                return globalProvider;
            }
        }

        /// <include file='doc\ServiceProvider.uex' path='docs/doc[@for="ServiceProvider.CreateFromSetSite"]' />
        /// <devdoc>
        /// Create a new ServiceProvider for the given site.
        /// Should be called from an object that implements SetSite
        /// (IObjectWithSite or IVsPackage). Automatically sets the global
        /// service provider if it hasn't already been set.
        /// This method is typically called from the SetSite method of a
        /// Visual Studio package.
        /// Note: By calling this method, the caller declares that it knows
        /// the global OLE service provider for the calling thread and that
        /// the ServiceProvider instance returned may be used by other,
        /// unrelated components, accessed via the ServiceProvider.GlobalProvider
        /// static property.
        /// </devdoc>
        public static ServiceProvider CreateFromSetSite(IOleServiceProvider sp)
        {
            ServiceProvider provider = new ServiceProvider(sp);

            // If there is no current global service provider or the existing
            // one is unsited, then set it here.
            if (IsNullOrUnsited(globalProvider))
            {
                Debug.WriteLineIf(TRACESERVICE.TraceVerbose, "Initializing ServiceProvider.GlobalProvider from SetSite.");
                SetGlobalProvider(provider);
            }

            return provider;
        }
    }
}
