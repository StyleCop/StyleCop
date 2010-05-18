//------------------------------------------------------------------------------
// <copyright file="WritableSettingsStore.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>                                                                
//------------------------------------------------------------------------------

namespace Microsoft.VisualStudio.Shell.Settings
{
    using System;
    using System.IO;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.Shell.Interop;
    using System.Runtime.InteropServices;
    using System.Diagnostics;
    using Microsoft.VisualStudio.Settings;
    
    /// <summary>
    /// Abstract class for both reading and writing the selected scope's collections and properties. It is obtained from 
    /// <see cref="SettingsManager.GetWritableSettingsStore"/> method.
    /// 
    /// This class is derived from the SettingsStore hence it inherits all the functionalities from it. It adds property and
    /// collection manipulation abilities on top of it.
    /// </summary>    
    [CLSCompliant(false)] // Methods of this class have unsigned integer parameters
    internal sealed class ShellWritableSettingsStore : WritableSettingsStore
    {
        #region SettingsStore implementation
        /// The overrides to the SettingsStore methods are delegated to an instance of
        /// the ShellSettingsStore class.

        public override bool GetBoolean(string collectionPath, string propertyName)
        {
            return settingsStore.GetBoolean(collectionPath, propertyName);
        }

        public override bool GetBoolean(string collectionPath, string propertyName, bool defaultValue)
        {
            return settingsStore.GetBoolean(collectionPath, propertyName, defaultValue);
        }

        public override int GetInt32(string collectionPath, string propertyName)
        {
            return settingsStore.GetInt32(collectionPath, propertyName);
        }

        public override int GetInt32(string collectionPath, string propertyName, int defaultValue)
        {
            return settingsStore.GetInt32(collectionPath, propertyName, defaultValue);
        }

        public override uint GetUInt32(string collectionPath, string propertyName)
        {
            return settingsStore.GetUInt32(collectionPath, propertyName);
        }

        public override uint GetUInt32(string collectionPath, string propertyName, uint defaultValue)
        {
            return settingsStore.GetUInt32(collectionPath, propertyName, defaultValue);
        }

        public override long GetInt64(string collectionPath, string propertyName)
        {
            return settingsStore.GetInt64(collectionPath, propertyName);
        }

        public override long GetInt64(string collectionPath, string propertyName, long defaultValue)
        {
            return settingsStore.GetInt64(collectionPath, propertyName, defaultValue);
        }

        public override ulong GetUInt64(string collectionPath, string propertyName)
        {
            return settingsStore.GetUInt64(collectionPath, propertyName);
        }

        public override ulong GetUInt64(string collectionPath, string propertyName, ulong defaultValue)
        {
            return settingsStore.GetUInt64(collectionPath, propertyName, defaultValue);
        }

        public override string GetString(string collectionPath, string propertyName)
        {
            return settingsStore.GetString(collectionPath, propertyName);
        }

        public override string GetString(string collectionPath, string propertyName, string defaultValue)
        {
            return settingsStore.GetString(collectionPath, propertyName, defaultValue);
        }

        public override MemoryStream GetMemoryStream(string collectionPath, string propertyName)
        {
            return settingsStore.GetMemoryStream(collectionPath, propertyName);
        }

        public override SettingsType GetPropertyType(string collectionPath, string propertyName)
        {
            return settingsStore.GetPropertyType(collectionPath, propertyName);
        }

        public override bool PropertyExists(string collectionPath, string propertyName)
        {
            return settingsStore.PropertyExists(collectionPath, propertyName);
        }

        public override bool CollectionExists(string collectionPath)
        {
            return settingsStore.CollectionExists(collectionPath);
        }

        public override DateTime GetLastWriteTime(string collectionPath)
        {
            return settingsStore.GetLastWriteTime(collectionPath);
        }

        public override int GetSubCollectionCount(string collectionPath)
        {
            return settingsStore.GetSubCollectionCount(collectionPath);
        }

        public override int GetPropertyCount(string collectionPath)
        {
            return settingsStore.GetPropertyCount(collectionPath);
        }

        public override IEnumerable<string> GetSubCollectionNames(string collectionPath)
        {
            return settingsStore.GetSubCollectionNames(collectionPath);
        }

        public override IEnumerable<string> GetPropertyNames(string collectionPath)
        {
            return settingsStore.GetPropertyNames(collectionPath);
        }

        #endregion

        #region WritableSettingsStore implementation

        /// <summary>
        /// Updates the value of the specified property to the given Boolean value while setting its data type to 
        /// <see cref="SettingsType.Int32"/>. If the previous data type of the property is different, it overwrites it.
        /// If the property does not exist it creates one.
        /// </summary>
        /// <param name="collectionPath">Path of the collection of the property.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="value">New value of the property.</param>
        /// <exception cref="ArgumentException">If the collection does not exist, this exception is thrown.</exception>  
        public override void SetBoolean(string collectionPath, string propertyName, bool value)
        {
            HelperMethods.CheckNullArgument(collectionPath, "collectionPath");
            HelperMethods.CheckNullArgument(propertyName, "propertyName");

            int hr = this.writableSettingsStore.SetBool(collectionPath, propertyName, Convert.ToInt32(value));
            Marshal.ThrowExceptionForHR(hr);
        }     

        /// <summary>
        /// Updates the value of the specified property to the given integer value while setting its data type to 
        /// <see cref="SettingsType.Int32"/>. If the previous data type of the property is different, it overwrites it.
        /// If the property does not exist it creates one.
        /// </summary>
        /// <param name="collectionPath">Path of the collection of the property.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="value">New value of the property.</param>
        /// <exception cref="ArgumentException">If the collection does not exist, this exception is thrown.</exception>        
        public override void SetInt32(string collectionPath, string propertyName, int value)
        {
            HelperMethods.CheckNullArgument(collectionPath, "collectionPath");
            HelperMethods.CheckNullArgument(propertyName, "propertyName");

            int hr = this.writableSettingsStore.SetInt(collectionPath, propertyName, value);
            Marshal.ThrowExceptionForHR(hr);
        }        

        /// <summary>
        /// Updates the value of the specified property to the given unsigned integer value while setting its data type to 
        /// <see cref="SettingsType.Int32"/>. If the previous data type of the property is different, it overwrites it.
        /// If the property does not exist it creates one.
        /// </summary>
        /// <param name="collectionPath">Path of the collection of the property.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="value">New value of the property.</param>
        /// <exception cref="ArgumentException">If the collection does not exist, this exception is thrown.</exception>        
        public override void SetUInt32(string collectionPath, string propertyName, uint value)
        {
            HelperMethods.CheckNullArgument(collectionPath, "collectionPath");
            HelperMethods.CheckNullArgument(propertyName, "propertyName");

            int hr = this.writableSettingsStore.SetUnsignedInt(collectionPath, propertyName, value);
            Marshal.ThrowExceptionForHR(hr);

        }        

        /// <summary>
        /// Updates the value of the specified property to the given long value while setting its data type to 
        /// <see cref="SettingsType.Int64"/>. If the previous data type of the property is different, it overwrites it.
        /// If the property does not exist it creates one.
        /// </summary>
        /// <param name="collectionPath">Path of the collection of the property.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="value">New value of the property.</param>
        /// <exception cref="ArgumentException">If the collection does not exist, this exception is thrown.</exception>        
        public override void SetInt64(string collectionPath, string propertyName, long value)
        {
            HelperMethods.CheckNullArgument(collectionPath, "collectionPath");
            HelperMethods.CheckNullArgument(propertyName, "propertyName");

            int hr = this.writableSettingsStore.SetInt64(collectionPath, propertyName, value);
            Marshal.ThrowExceptionForHR(hr);
        }

        /// <summary>
        /// Updates the value of the specified property to the given unsigned long value while setting its data type to 
        /// <see cref="SettingsType.Int64"/>. If the previous data type of the property is different, it overwrites it.
        /// If the property does not exist it creates one.
        /// </summary>
        /// <param name="collectionPath">Path of the collection of the property.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="value">New value of the property.</param>
        /// <exception cref="ArgumentException">If the collection does not exist, this exception is thrown.</exception> 
        public override void SetUInt64(string collectionPath, string propertyName, ulong value)
        {
            HelperMethods.CheckNullArgument(collectionPath, "collectionPath");
            HelperMethods.CheckNullArgument(propertyName, "propertyName");

            int hr = this.writableSettingsStore.SetUnsignedInt64(collectionPath, propertyName, value);
            Marshal.ThrowExceptionForHR(hr);
        }

        /// <summary>
        /// Updates the value of the specified property to the given string value while setting its data type to 
        /// <see cref="SettingsType.String"/>. If the previous data type of the property is different, it overwrites it.
        /// If the property does not exist it creates one.
        /// </summary>
        /// <param name="collectionPath">Path of the collection of the property.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="value">New value of the property.</param>
        /// <exception cref="ArgumentException">If the collection does not exist, this exception is thrown.</exception> 
        public override void SetString(string collectionPath, string propertyName, string value)
        {
            HelperMethods.CheckNullArgument(collectionPath, "collectionPath");
            HelperMethods.CheckNullArgument(propertyName, "propertyName");
            HelperMethods.CheckNullArgument(value, "value");

            int hr = this.writableSettingsStore.SetString(collectionPath, propertyName, value);
            Marshal.ThrowExceptionForHR(hr);
        }        

        /// <summary>
        /// Updates the value of the specified property to the bits of the MemoryStream while setting its data type to 
        /// <see cref="SettingsType.Binary"/>. If the previous data type of the property is different, it overwrites it.
        /// If the property does not exist it creates one.
        /// </summary>
        /// <param name="collectionPath">Path of the collection of the property.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="value">MemoryStream to set the bits of the property.</param>
        /// <exception cref="ArgumentException">If the collection does not exist, this exception is thrown.</exception> 
        public override void SetMemoryStream(string collectionPath, string propertyName, MemoryStream value)
        {
            HelperMethods.CheckNullArgument(collectionPath, "collectionPath");
            HelperMethods.CheckNullArgument(propertyName, "propertyName");
            HelperMethods.CheckNullArgument(value, "value");

            byte[] valueBuffer = value.ToArray();
            int hr = this.writableSettingsStore.SetBinary(collectionPath, propertyName, (uint)valueBuffer.Length, valueBuffer);
            Marshal.ThrowExceptionForHR(hr);
        }        

        /// <summary>
        /// Creates the given collection path by creating each nested collection while skipping the ones that already exist. 
        /// If the full path of collections already exist, the method simply returns.
        /// </summary>
        /// <param name="collectionPath">Path of the collection.</param>
        /// <exception cref="ArgumentException">If empty string ("") is passed to the method then it throws this exception.
        /// </exception>
        public override void CreateCollection(string collectionPath)
        {
            HelperMethods.CheckNullOrEmptyString(collectionPath, "collectionPath");

            int hr = this.writableSettingsStore.CreateCollection(collectionPath);
            Marshal.ThrowExceptionForHR(hr);
        }           

        /// <summary>
        /// Deletes the given collection recursively deleting all of the sub collections and properties in it. If the collection 
        /// does not exist or an empty string ("") is passed then the method returns false.
        /// </summary>
        /// <param name="collectionPath">Path of the collection to be deleted.</param>
        /// <returns>Result of the deletion.</returns>
        public override bool DeleteCollection(string collectionPath)
        {
            HelperMethods.CheckNullArgument(collectionPath, "collectionPath");

            int hr = this.writableSettingsStore.DeleteCollection(collectionPath);
            Marshal.ThrowExceptionForHR(hr);

            Debug.Assert(hr == VSConstants.S_OK || hr == VSConstants.S_FALSE);

            return hr == VSConstants.S_OK;
        }        

        /// <summary>         
        /// Deletes the given property from the collection. If the property or the collection does not exist then the method 
        /// returns false.
        /// </summary>
        /// <param name="collectionPath">Collection that contains the property to be deleted.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns>Result of the deletion.</returns>
        public override bool DeleteProperty(string collectionPath, string propertyName)
        {
            HelperMethods.CheckNullArgument(collectionPath, "collectionPath");
            HelperMethods.CheckNullArgument(propertyName, "propertyName");

            int hr = this.writableSettingsStore.DeleteProperty(collectionPath, propertyName);
            Marshal.ThrowExceptionForHR(hr);

            Debug.Assert(hr == VSConstants.S_OK || hr == VSConstants.S_FALSE);

            return hr == VSConstants.S_OK;
        }

        #endregion

        /// <summary>
        /// Internal constructor that takes the COM interface that provides the functionality of this class.
        /// </summary>
        /// <param name="writableSettingsStore">COM interface wrapped by this class.</param>
        internal ShellWritableSettingsStore(IVsWritableSettingsStore writableSettingsStore)
        {
            HelperMethods.CheckNullArgument(writableSettingsStore, "writableSettingsStore");
            this.writableSettingsStore = writableSettingsStore;
            this.settingsStore = new ShellSettingsStore(this.writableSettingsStore);
        }

        // Thunked interop COM interface.
        private IVsWritableSettingsStore writableSettingsStore;

        // Thunked SettingsStore instance.
        private SettingsStore settingsStore;
    }
}