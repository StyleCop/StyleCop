/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

***************************************************************************/

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Security;
using System.IO;
using System.Collections;
using System.Text;
using Microsoft.VisualStudio.OLE.Interop;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio;

using IOleServiceProvider = Microsoft.VisualStudio.OLE.Interop.IServiceProvider;
using IServiceProvider = System.IServiceProvider;

namespace Microsoft.VsSDK.UnitTestLibrary
{
	public class OleServiceProvider : IServiceProvider, IOleServiceProvider, IDisposable
	{
		#region static fields
		private static GenericMockFactory profferServiceFactory;
		private static GenericMockFactory hostLocaleFactory;
		private static GenericMockFactory resourceManagerFactory;
		#endregion

		#region fields
		private class ServiceInstance
		{
			internal object service;
			internal bool shouldDispose;
			internal ServiceInstance(object service, bool shouldDispose)
			{
				this.service = service;
				this.shouldDispose = shouldDispose;
			}
		}

		private Dictionary<Guid, ServiceInstance> services = new Dictionary<Guid, ServiceInstance>();
		private bool isDisposed;
		/// <summary>
		/// Defines an object that will be a mutex for this object for synchronizing thread calls.
		/// </summary>
		private static volatile object Mutex = new object();
		#endregion

		#region ctors
		public OleServiceProvider()
		{
		}

		private static void ProfferServiceCallback(object sender, CallbackArgs args)
		{
			args.SetParameter(2, (uint)0);
			args.ReturnValue = 0;
		}

		/// <summary>
		/// Use to create an IOleServiceProvider with the basic services required by
		/// MS.VS.Shell.Package.SetSite() base implementation
		/// </summary>
		/// <returns></returns>
		public static OleServiceProvider CreateOleServiceProviderWithBasicServices()
		{
			// Create the service provider
			OleServiceProvider serviceProvider = new OleServiceProvider();

			// Add IProfferService
			// Create the type only once, then create as many instances as required.
			if (profferServiceFactory == null)
			{
				profferServiceFactory = new GenericMockFactory("MockProfferService", new Type[] { typeof(IProfferService) });
			}
			BaseMock mockObject = profferServiceFactory.GetInstance();
			mockObject.AddMethodCallback(string.Format(CultureInfo.InvariantCulture, "{0}.{1}", typeof(IProfferService).FullName, "ProfferService"),
                                         new EventHandler<CallbackArgs>(ProfferServiceCallback));
			serviceProvider.AddService(typeof(SProfferService), mockObject, false);

			// Add IUIHostLocale
			if (hostLocaleFactory == null)
			{
				hostLocaleFactory = new GenericMockFactory("MockUiHostLocale", new Type[] { typeof(IUIHostLocale), typeof(IUIHostLocale2) });
			}
			mockObject = hostLocaleFactory.GetInstance();
			// Set the return value to 0 (S_OK) and the out parameter to 1033 (enu).
			mockObject.AddMethodReturnValues(string.Format(CultureInfo.InvariantCulture,
                                                      "{0}.{1}",
                                                      typeof(IUIHostLocale).FullName,
                                                      "GetUILocale"), 
                                             new object[] { 0, (uint)1033 });
			serviceProvider.AddService(typeof(SUIHostLocale), mockObject, false);

			// Add IVsResourceManager
			if (resourceManagerFactory == null)
			{
				resourceManagerFactory = new GenericMockFactory("MockResourceManager", new Type[] { typeof(IVsResourceManager) });
			}
			mockObject = resourceManagerFactory.GetInstance();
			mockObject.AddMethodReturnValues(string.Format(CultureInfo.InvariantCulture,
                                                      "{0}.{1}",
                                                      typeof(IVsResourceManager).FullName,
                                                      "LoadResourceString"), 
                                             new object[] { 0, Guid.Empty, 0, null, "Mock Localized String" });
			serviceProvider.AddService(typeof(SVsResourceManager), mockObject, false);
			
			return serviceProvider;
		}

		#endregion

        #region IServiceProvider Members
        public object GetService(Type serviceType)
        {
            if (typeof(IOleServiceProvider) == serviceType)
                return this;
            if ((null == services) || (!services.ContainsKey(serviceType.GUID)))
                return null;
            return services[serviceType.GUID].service;
        }
        #endregion

        #region IOleServiceProvider Members

        public int QueryService(ref Guid guidService, ref Guid riid, out IntPtr ppvObject)
		{
			ppvObject = (IntPtr)0;
			int hr = VSConstants.S_OK;

			ServiceInstance serviceInstance = null;

			if (services != null && services.ContainsKey(guidService))
			{
				serviceInstance = services[guidService];				
			}

			if (serviceInstance == null)
			{
				return VSConstants.E_NOINTERFACE;
			}
			
			// Now check to see if the user asked for an IID other than
			// IUnknown.  If so, we must do another QI.
			//
			if (riid.Equals(VSConstants.IID_IUnknown))
			{
				ppvObject = Marshal.GetIUnknownForObject(serviceInstance.service);
			}
			else
			{
				IntPtr pUnk = IntPtr.Zero;
				try
				{
					pUnk = Marshal.GetIUnknownForObject(serviceInstance.service);
					hr = Marshal.QueryInterface(pUnk, ref riid, out ppvObject);
				}
				finally
				{
					if (pUnk != IntPtr.Zero)
					{
						Marshal.Release(pUnk);
					}
				}
			}

			return hr;
		}

		#endregion

		#region Dispose		

		/// <summary>
		/// The IDispose interface Dispose method for disposing the object determinastically.
		/// </summary>
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		#endregion

		/// <summary>
		/// Adds the given service to the service container.
		/// </summary>
		/// <param name="serviceType">The type of the service to add.</param>
		/// <param name="serviceInstance">An instance of the service.</param>
		/// <param name="shouldDisposeServiceInstance">true if the Dipose of the service provider is allowed to dispose the sevice instance.</param>
		public void AddService(Type serviceType, object serviceInstance, bool shouldDisposeServiceInstance)
		{
			if (serviceType == null)
			{
				throw new ArgumentNullException("serviceType");
			}

			if (serviceInstance == null)
			{
				throw new ArgumentNullException("serviceInstance");
			}

			if (services == null)
			{
				services = new Dictionary<Guid, ServiceInstance>();
			}

			// Disallow the addition of duplicate services.
			if (services.ContainsKey(serviceType.GUID))
			{
				throw new InvalidOperationException();
			}

			// Add the service to the list
			services.Add(serviceType.GUID, new ServiceInstance(serviceInstance, shouldDisposeServiceInstance));
		}

		/// <devdoc>
		/// Removes the given service type from the service container.
		/// </devdoc>
		public void RemoveService(Type serviceType)
		{
			if (serviceType == null)
			{
				throw new ArgumentNullException("serviceType");
			}

			if (services.ContainsKey(serviceType.GUID))
			{
				services.Remove(serviceType.GUID);
			}			
		}

		#region helper methods
		/// <summary>
		/// The method that does the cleanup.
		/// </summary>
		/// <param name="disposing"></param>
		protected virtual void Dispose(bool disposing)
		{
			// Everybody can go here.
			if (!this.isDisposed)
			{
				// Synchronize calls to the Dispose simulteniously.
				lock (Mutex)
				{
					if (disposing)
					{
						// Remove all our services
						if (services != null)
						{
							while (services.Count > 0)
							{
								IEnumerator enumarator = services.Keys.GetEnumerator();
								enumarator.MoveNext();
								Guid guid = (Guid)enumarator.Current;
								this.RemoveService(guid);
							}
							services.Clear();
							services = null;
						}
					}

					this.isDisposed = true;
				}
			}
		}

		private void RemoveService(Guid guid)
		{
			if (this.services != null)
			{
				ServiceInstance serviceInstance = this.services[guid];
				if (serviceInstance != null)
				{
					services.Remove(guid);
					if (serviceInstance.shouldDispose && serviceInstance.service is IDisposable)
					{
						((IDisposable)(serviceInstance.service)).Dispose();
					}
				}
			}
		}
		#endregion

	}
}
