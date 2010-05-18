//------------------------------------------------------------------------------
// <copyright file="SettingsManager.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>                                                                
//------------------------------------------------------------------------------

namespace Microsoft.VisualStudio.Shell.Settings
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.Shell.Interop;
    using System.Runtime.InteropServices;
    using System.Diagnostics;
    using Microsoft.VisualStudio.Settings;

    /// <summary>
    /// This is the gateway class to reach for the settings stored inside the Visual Studio. It provides two basic
    /// functionality. It allows to search for properties and collections inside the scopes. It hands the 
    /// <see cref="SettingsScope"/> and <see cref="WritableSettingsStore"/> classes for further manipulation of the 
    /// collections and properties within the scopes. This class implements the <see cref="IDisposable"/> pattern 
    /// hence it needs to be disposed after it is no longer necessary.
    /// </summary>
    [CLSCompliant(false)] // Methods of this class have enumeration return values
    public sealed class ShellSettingsManager : SettingsManager
    {        
        /// <summary>
        /// Constructor for the SettingsManager class. It requires Service Provider to reach IVsSettingsManager
        /// which is the interop COM interface of the service that provides the Settings related functionalities.
        /// </summary>
        /// <param name="serviceProvider">Service provider of the VS.</param>
        public ShellSettingsManager(IServiceProvider serviceProvider)
        {
            HelperMethods.CheckNullArgument(serviceProvider, "serviceProvider");

            this.settingsManager = serviceProvider.GetService(typeof(SVsSettingsManager)) as IVsSettingsManager;
            if (this.settingsManager == null)
            {
                throw new NotSupportedException(typeof(SVsSettingsManager).FullName);
            }
        }

        /// <summary>
        /// Outputs the scopes that contain the given collection. If more than one scope contains the collection,
        /// the corresponding bit flags of those scopes are set.
        /// </summary>
        /// <param name="collectionPath">Path of the collection to be searched.</param>
        /// <returns>Enclosing scopes.</returns>
        public override EnclosingScopes GetCollectionScopes(string collectionPath)
        {
            HelperMethods.CheckNullArgument(collectionPath, "collectionPath");

            uint scopes;
            int hr = this.settingsManager.GetCollectionScopes(collectionPath, out scopes);
            Marshal.ThrowExceptionForHR(hr);

            return (EnclosingScopes)scopes;
        }

        /// <summary>
        /// Outputs the scopes that contain the given property. If more than one scope contains the property,
        /// the corresponding bit flags of those scopes are set.
        /// </summary>
        /// <param name="collectionPath">Path of the collection of the property.</param>
        /// <param name="propertyName">Name of the property to be searched.</param>
        /// <returns>Enclosing scopes.</returns>
        public override EnclosingScopes GetPropertyScopes(string collectionPath, string propertyName)
        {
            HelperMethods.CheckNullArgument(collectionPath, "collectionPath");
            HelperMethods.CheckNullArgument(propertyName, "propertyName");

            uint scopes;
            int hr = this.settingsManager.GetPropertyScopes(collectionPath, propertyName, out scopes);
            Marshal.ThrowExceptionForHR(hr);            

            return (EnclosingScopes)scopes;
        }

        /// <summary>
        /// Provides the <see cref="SettingsStore"/> class for the requested scope which can be used for read-only 
        /// operations.
        /// </summary>
        /// <param name="scope">Requested scope.</param>
        /// <returns><see cref="SettingsStore"/> instance that can be used for accessing the scope.</returns>
        public override SettingsStore GetReadOnlySettingsStore(SettingsScope scope)
        {
            IVsSettingsStore settingsStore;
            int hr = this.settingsManager.GetReadOnlySettingsStore((uint)scope, out settingsStore);
            Marshal.ThrowExceptionForHR(hr);            

            return new ShellSettingsStore(settingsStore);
        }

        /// <summary>
        /// Provides the <see cref="WritableSettingsStore"/> class for the requested scope which can be used both for
        /// reading and writing.
        /// </summary>
        /// <param name="scope">Requested scope.</param>
        /// <exception cref="ArgumentException">If the given scope is not a writable one.</exception>
        /// <returns><see cref="WritableSettingsStore"/> instance that can be used for accessing the scope.</returns>
        public override WritableSettingsStore GetWritableSettingsStore(SettingsScope scope)
        {
            IVsWritableSettingsStore writableSettingsStore;
            int hr = this.settingsManager.GetWritableSettingsStore((uint)scope, out writableSettingsStore);
            Marshal.ThrowExceptionForHR(hr);
            
            return new ShellWritableSettingsStore(writableSettingsStore);
        }

        /// <summary>
        /// Returns the folder that Visual Studio uses for storing various cache, backup, template, etc. files
        /// </summary>
        /// <param name="folder">Requested folder.</param>        
        /// <returns>Full path of the requested folder.</returns>
        public override string GetApplicationDataFolder(ApplicationDataFolder folder)
        {
            string folderPath;
            int hr = this.settingsManager.GetApplicationDataFolder((uint)folder, out folderPath);
            Marshal.ThrowExceptionForHR(hr);

            return folderPath;
        }

        /// <summary>
        /// Returns the list of folders that Visual Studio uses for installing/discovering machine-wide extensions.
        /// </summary>
        /// <returns>List of extensions root paths.</returns>
        public override IEnumerable<string> GetCommonExtensionsSearchPaths()
        {
            uint arraySize;
            int hr = this.settingsManager.GetCommonExtensionsSearchPaths(0, null, out arraySize);
            Marshal.ThrowExceptionForHR(hr);

            string[] searchPaths = new string[arraySize];
            hr = this.settingsManager.GetCommonExtensionsSearchPaths((uint)searchPaths.Length, searchPaths, out arraySize);
            Marshal.ThrowExceptionForHR(hr);
            return searchPaths;
        }

        // Thunked interop COM interface.
        private IVsSettingsManager settingsManager;
    }
}