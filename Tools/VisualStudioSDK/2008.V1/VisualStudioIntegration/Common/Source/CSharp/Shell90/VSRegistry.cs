//------------------------------------------------------------------------------
// <copyright file="Package.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>                                                                
//------------------------------------------------------------------------------
using System;
using Microsoft.Win32;

using Microsoft.VisualStudio.Shell.Interop;

using ErrorHandler = Microsoft.VisualStudio.ErrorHandler;
using IServiceProvider = System.IServiceProvider;
using IOleServiceProvider = Microsoft.VisualStudio.OLE.Interop.IServiceProvider;

namespace Microsoft.VisualStudio.Shell {
    /// <summary>
    /// Helper class to handle the registry of the instance of VS that is
    /// hosting this code.
    /// </summary>
    [System.CLSCompliant(false)]
    public static class VSRegistry {
        // ServiceProvider object that wraps the global service provider of VS.
        private static ServiceProvider globalProvider;

        private static ServiceProvider GlobalProvider {
            get {
                if (null == globalProvider) {
                    // Try to get the global service provider from the Package class.
                    IOleServiceProvider sp = Package.GetGlobalService(typeof(IOleServiceProvider)) as IOleServiceProvider;
                    if (null != sp) {
                        globalProvider = new ServiceProvider(sp);
                    }
                }
                return globalProvider;
            }
        }

        /// <summary>
        /// Returns a read-only RegistryKey object for the root of a given storage type.
        /// It is up to the caller to dispose the returned object.
        /// </summary>
        /// <param name="registryType">The type of registry storage to open.</param>
        public static RegistryKey RegistryRoot(__VsLocalRegistryType registryType) {
            return RegistryRoot(GlobalProvider, registryType, false);
        }

        /// <summary>
        /// Returns a RegistryKey object for the root of a given storage type.
        /// It is up to the caller to dispose the returned object.
        /// </summary>
        /// <param name="registryType">The type of registry storage to open.</param>
        /// <param name="writable">Flag to indicate is the key should be writable.</param>
        public static RegistryKey RegistryRoot(__VsLocalRegistryType registryType, bool writable) {
            return RegistryRoot(GlobalProvider, registryType, writable);
        }

        /// <summary>
        /// Returns a RegistryKey object for the root of a given storage type.
        /// It is up to the caller to dispose the returned object.
        /// </summary>
        /// <param name="provider">The service provider to use to access the Visual Studio's services.</param>
        /// <param name="registryType">The type of registry storage to open.</param>
        /// <param name="writable">Flag to indicate is the key should be writable.</param>
        public static RegistryKey RegistryRoot(IServiceProvider provider, __VsLocalRegistryType registryType, bool writable) {
            if (null == provider) {
                throw new ArgumentNullException("provider");
            }

            // The current implementation of the shell supports only RegType_UserSettings and
            // RegType_Configuration, so for any other values we have to return not implemented.
            if ((__VsLocalRegistryType.RegType_UserSettings != registryType) &&
                (__VsLocalRegistryType.RegType_Configuration != registryType))
            {
                throw new NotSupportedException();
            }

            // Try to get the new ILocalRegistry4 interface that is able to handle the new
            // registry paths.
            ILocalRegistry4 localRegistry = provider.GetService(typeof(SLocalRegistry)) as ILocalRegistry4;
            if (null != localRegistry) {
                uint rootHandle;
                string rootPath;
                if (ErrorHandler.Succeeded(localRegistry.GetLocalRegistryRootEx((uint)registryType, out rootHandle, out rootPath))) {
                    // Check if we have valid data.
                    __VsLocalRegistryRootHandle handle = (__VsLocalRegistryRootHandle)rootHandle;
                    if (!string.IsNullOrEmpty(rootPath) && (__VsLocalRegistryRootHandle.RegHandle_Invalid != handle)) {
                        // Check if the root is inside HKLM or HKCU. Note that this does not depends only from
                        // the registry type, but also from instance-specific data like the RANU flag.
                        RegistryKey root = (__VsLocalRegistryRootHandle.RegHandle_LocalMachine == handle) ? Registry.LocalMachine : Registry.CurrentUser;
                        return root.OpenSubKey(rootPath, writable);
                    }
                }
            }

            // We are here if the usage of the new interface failed for same reason, so we have to fall back to
            // the ond way to access the registry.
            ILocalRegistry2 oldRegistry = provider.GetService(typeof(SLocalRegistry)) as ILocalRegistry2;
            if (null == oldRegistry) {
                // There is something wrong with this installation or this service provider.
                return null;
            }
            string registryPath;
            NativeMethods.ThrowOnFailure(oldRegistry.GetLocalRegistryRoot(out registryPath));
            if (string.IsNullOrEmpty(registryPath)) {
                return null;
            }

            RegistryKey regRoot = (__VsLocalRegistryType.RegType_Configuration == registryType) ? Registry.LocalMachine : Registry.CurrentUser;
            return regRoot.OpenSubKey(registryPath, writable);
        }
    }
}
