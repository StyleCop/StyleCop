//------------------------------------------------------------------------------
// <copyright file="SettingsStore.cs" company="Microsoft">
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
    using Microsoft.VisualStudio.Settings;

    /// <summary>
    /// Abstract class for reading/enumerating the selected scope's collections and properties. It is obtained from 
    /// <see cref="SettingsManager.GetReadOnlySettingsStore"/> method.
    /// 
    /// In the methods of this class if the collection path is provided as the empty string ("") then it 
    /// denotes the top level collection. If the property name is empty string then it denotes the default 
    /// property of the collection.
    /// 
    /// Collections can contain properties and sub-collections. Sub-collections paths are described with the 
    /// separators like directories in file system. Likewise, separator is '\' (back-slash) character. Example
    /// of a sub-collection path would be: "Root Collection\Internal Collection\Leaf Collection".
    /// </summary>
    [CLSCompliant(false)] // Methods of this class have unsigned integer parameters
    internal class ShellSettingsStore : SettingsStore
    {            
        /// <summary>
        /// Returns the value of the requested property whose data type is <see cref="SettingsType.Int32"/> as boolean.
        /// </summary>
        /// <param name="collectionPath">Path of the collection of the property.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <exception cref="ArgumentException">Throws this exception if the property is of different type or if it does 
        /// not exist.</exception>
        /// <returns>If the underling integer value for the property is non-zero, it returns true and false otherwise.</returns>
        public override bool GetBoolean(string collectionPath, string propertyName)
        {
            HelperMethods.CheckNullArgument(collectionPath, "collectionPath");
            HelperMethods.CheckNullArgument(propertyName, "propertyName");

            int value;
            int hr = this.settingsStore.GetBool(collectionPath, propertyName, out value);
            Marshal.ThrowExceptionForHR(hr);
            
            return Convert.ToBoolean(value);
        }

        /// <summary>
        /// Returns the value of the requested property whose data type is <see cref="SettingsType.Int32"/> as boolean.
        /// </summary>
        /// <param name="collectionPath">Path of the collection of the property.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="defaultValue">Value to be returned if the property does not exist.</param>
        /// <exception cref="ArgumentException">Throws this exception if the property is of different type.</exception>
        /// <returns>If the property does not exist, it returns the defaultValue passed in otherwise it returns true if the 
        /// underling integer value is non-zero and false if it is zero.</returns>
        public override bool GetBoolean(string collectionPath, string propertyName, bool defaultValue)
        {
            HelperMethods.CheckNullArgument(collectionPath, "collectionPath");
            HelperMethods.CheckNullArgument(propertyName, "propertyName");

            int value;
            int hr = this.settingsStore.GetBoolOrDefault(collectionPath, propertyName, Convert.ToInt32(defaultValue), out value);
            Marshal.ThrowExceptionForHR(hr);

            return Convert.ToBoolean(value);
        }

        /// <summary>
        /// Returns the value of the requested property whose data type is <see cref="SettingsType.Int32"/>.
        /// </summary>
        /// <param name="collectionPath">Path of the collection of the property.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <exception cref="ArgumentException">Throws this exception if the property is of different type or if it does 
        /// not exist.</exception>
        /// <returns>Value of the property. If the value was stored as an unsigned integer previously then regular type 
        /// conversion sematics applies.</returns>
        public override int GetInt32(string collectionPath, string propertyName)
        {
            HelperMethods.CheckNullArgument(collectionPath, "collectionPath");
            HelperMethods.CheckNullArgument(propertyName, "propertyName");

            int value;
            int hr = this.settingsStore.GetInt(collectionPath, propertyName, out value);
            Marshal.ThrowExceptionForHR(hr);

            return value;
        }

        /// <summary>
        /// Returns the value of the requested property whose data type is <see cref="SettingsType.Int32"/>.
        /// </summary>
        /// <param name="collectionPath">Path of the collection of the property.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="defaultValue">Value to be returned if the property does not exist.</param>
        /// <exception cref="ArgumentException">Throws this exception if the property is of different type.</exception>
        /// <returns>If the property does not exist, it returns the defaultValue passed in. If the value was stored as an 
        /// unsigned integer previously then regular type conversion sematics applies.</returns>
        public override int GetInt32(string collectionPath, string propertyName, int defaultValue)
        {
            HelperMethods.CheckNullArgument(collectionPath, "collectionPath");
            HelperMethods.CheckNullArgument(propertyName, "propertyName");

            int value;
            int hr = this.settingsStore.GetIntOrDefault(collectionPath, propertyName, defaultValue, out value);
            Marshal.ThrowExceptionForHR(hr);

            return value;
        }

        /// <summary>
        /// Returns the value of the requested property whose data type is <see cref="SettingsType.Int32"/>.
        /// </summary>
        /// <param name="collectionPath">Path of the collection of the property.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <exception cref="ArgumentException">Throws this exception if the property is of different type or if it does 
        /// not exist.</exception>
        /// <returns>Value of the property. If the value was stored as an signed integer previously then regular type 
        /// conversion sematics applies.</returns>
        public override uint GetUInt32(string collectionPath, string propertyName)
        {
            HelperMethods.CheckNullArgument(collectionPath, "collectionPath");
            HelperMethods.CheckNullArgument(propertyName, "propertyName");

            uint value;
            int hr = this.settingsStore.GetUnsignedInt(collectionPath, propertyName, out value);
            Marshal.ThrowExceptionForHR(hr);

            return value;
        }

        /// <summary>
        /// Returns the value of the requested property whose data type is <see cref="SettingsType.Int32"/>.
        /// </summary>
        /// <param name="collectionPath">Path of the collection of the property.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="defaultValue">Value to be returned if the property does not exist.</param>
        /// <exception cref="ArgumentException">Throws this exception if the property is of different type.</exception>
        /// <returns>If the property does not exist, it returns the defaultValue passed in. If the value was stored as an 
        /// signed integer previously then regular type conversion sematics applies.</returns>
        public override uint GetUInt32(string collectionPath, string propertyName, uint defaultValue)
        {
            HelperMethods.CheckNullArgument(collectionPath, "collectionPath");
            HelperMethods.CheckNullArgument(propertyName, "propertyName");

            uint value;
            int hr = this.settingsStore.GetUnsignedIntOrDefault(collectionPath, propertyName, defaultValue, out value);
            Marshal.ThrowExceptionForHR(hr);

            return value;
        }

        /// <summary>
        /// Returns the value of the requested property whose data type is <see cref="SettingsType.Int64"/>.
        /// </summary>
        /// <param name="collectionPath">Path of the collection of the property.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <exception cref="ArgumentException">Throws this exception if the property is of different type or if it does 
        /// not exist.</exception>
        /// <returns>Value of the property. If the value was stored as an unsigned long previously then regular type 
        /// conversion sematics applies.</returns>
        public override long GetInt64(string collectionPath, string propertyName)
        {
            HelperMethods.CheckNullArgument(collectionPath, "collectionPath");
            HelperMethods.CheckNullArgument(propertyName, "propertyName");

            long value;
            int hr = this.settingsStore.GetInt64(collectionPath, propertyName, out value);
            Marshal.ThrowExceptionForHR(hr);

            return value;
        }

        /// <summary>
        /// Returns the value of the requested property whose data type is <see cref="SettingsType.Int64"/>.
        /// </summary>
        /// <param name="collectionPath">Path of the collection of the property.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="defaultValue">Value to be returned if the property does not exist.</param>
        /// <exception cref="ArgumentException">Throws this exception if the property is of different type.</exception>
        /// <returns>If the property does not exist, it returns the defaultValue passed in. If the value was stored as an 
        /// unsigned long previously then regular type conversion sematics applies.</returns>
        public override long GetInt64(string collectionPath, string propertyName, long defaultValue)
        {
            HelperMethods.CheckNullArgument(collectionPath, "collectionPath");
            HelperMethods.CheckNullArgument(propertyName, "propertyName");

            long value;
            int hr = this.settingsStore.GetInt64OrDefault(collectionPath, propertyName, defaultValue, out value);
            Marshal.ThrowExceptionForHR(hr);

            return value;
        }
        
        /// <summary>
        /// Returns the value of the requested property whose data type is <see cref="SettingsType.Int64"/>.
        /// </summary>
        /// <param name="collectionPath">Path of the collection of the property.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <exception cref="ArgumentException">Throws this exception if the property is of different type or if it does 
        /// not exist.</exception>
        /// <returns>Value of the property. If the value was stored as an signed long previously then regular type 
        /// conversion sematics applies.</returns>        
        public override ulong GetUInt64(string collectionPath, string propertyName)
        {
            HelperMethods.CheckNullArgument(collectionPath, "collectionPath");
            HelperMethods.CheckNullArgument(propertyName, "propertyName");

            ulong value;
            int hr = this.settingsStore.GetUnsignedInt64(collectionPath, propertyName, out value);
            Marshal.ThrowExceptionForHR(hr);

            return value;
        }

        /// <summary>
        /// Returns the value of the requested property whose data type is <see cref="SettingsType.Int64"/>.
        /// </summary>
        /// <param name="collectionPath">Path of the collection of the property.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="defaultValue">Value to be returned if the property does not exist.</param>
        /// <exception cref="ArgumentException">Throws this exception if the property is of different type.</exception>
        /// <returns>If the property does not exist, it returns the defaultValue passed in. If the value was stored as an 
        /// signed long previously then regular type conversion sematics applies.</returns>
        public override ulong GetUInt64(string collectionPath, string propertyName, ulong defaultValue)
        {
            HelperMethods.CheckNullArgument(collectionPath, "collectionPath");
            HelperMethods.CheckNullArgument(propertyName, "propertyName");

            ulong value;
            int hr = this.settingsStore.GetUnsignedInt64OrDefault(collectionPath, propertyName, defaultValue, out value);
            Marshal.ThrowExceptionForHR(hr);

            return value;
        }
        
        /// <summary>
        /// Returns the value of the requested property whose data type is <see cref="SettingsType.String"/>.
        /// </summary>
        /// <param name="collectionPath">Path of the collection of the property.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <exception cref="ArgumentException">Throws this exception if the property is of different type or if it does 
        /// not exist.</exception>
        /// <returns>Value of the property.</returns> 
        public override string GetString(string collectionPath, string propertyName)
        {
            HelperMethods.CheckNullArgument(collectionPath, "collectionPath");
            HelperMethods.CheckNullArgument(propertyName, "propertyName");

            string value;
            int hr = this.settingsStore.GetString(collectionPath, propertyName, out value);
            Marshal.ThrowExceptionForHR(hr);

            return value;
        }

        /// <summary>
        /// Returns the value of the requested property whose data type is <see cref="SettingsType.String"/>.
        /// </summary>
        /// <param name="collectionPath">Path of the collection of the property.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="defaultValue">Value to be returned if the property does not exist.</param>
        /// <exception cref="ArgumentException">Throws this exception if the property is of different type.</exception>
        /// <returns>If the property does not exist, it returns the defaultValue passed in.</returns>
        public override string GetString(string collectionPath, string propertyName, string defaultValue)
        {
            HelperMethods.CheckNullArgument(collectionPath, "collectionPath");
            HelperMethods.CheckNullArgument(propertyName, "propertyName");

            string value;
            int hr = this.settingsStore.GetStringOrDefault(collectionPath, propertyName, defaultValue, out value);
            Marshal.ThrowExceptionForHR(hr);

            return value;
        }

        /// <summary>
        /// Returns the value of the requested property whose data type is <see cref="SettingsType.Binary"/>. In order to
        /// access the underlying byte array at once <see cref="MemoryStream.ToArray"/> method can be used.
        /// </summary>
        /// <param name="collectionPath">Path of the collection of the property.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <exception cref="ArgumentException">Throws this exception if the property is of different type or if it does 
        /// not exist.</exception>
        /// <returns><see cref="MemoryStream"/> for the stream of bytes this property.</returns>  
        public override MemoryStream GetMemoryStream(string collectionPath, string propertyName)
        {
            HelperMethods.CheckNullArgument(collectionPath, "collectionPath");
            HelperMethods.CheckNullArgument(propertyName, "propertyName");

            // get the length of the property data
            uint[] actualLength = new uint[1];
            int hr = this.settingsStore.GetBinary(collectionPath, propertyName, 0, null, actualLength);
            Marshal.ThrowExceptionForHR(hr);

            // fetch the property data
            uint propertyDataLength = actualLength[0];  // byte length of the binary property
            byte[] propertyDataBuffer = new byte[propertyDataLength];
            hr = this.settingsStore.GetBinary(collectionPath, propertyName, propertyDataLength, propertyDataBuffer, null);
            Marshal.ThrowExceptionForHR(hr);

            return new MemoryStream(propertyDataBuffer);
        }

        /// <summary>
        /// Returns the type of the requested property.
        /// </summary>
        /// <param name="collectionPath">Path of the collection of the property.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <exception cref="ArgumentException">Throws this exception if the property does not exist.</exception>
        /// <returns>Type of the property.</returns>  
        public override SettingsType GetPropertyType(string collectionPath, string propertyName)
        {
            HelperMethods.CheckNullArgument(collectionPath, "collectionPath");
            HelperMethods.CheckNullArgument(propertyName, "propertyName");

            uint propertyType;
            int hr = this.settingsStore.GetPropertyType(collectionPath, propertyName, out propertyType);
            Marshal.ThrowExceptionForHR(hr);

            return (SettingsType)propertyType;
        }
        
        /// <summary>
        /// Checks the existance of the property passed in to this method.
        /// </summary>
        /// <param name="collectionPath">Path of the collection of the property.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns>Returns true if the property exists and false otherwise.</returns>
        public override bool PropertyExists(string collectionPath, string propertyName)
        {
            HelperMethods.CheckNullArgument(collectionPath, "collectionPath");
            HelperMethods.CheckNullArgument(propertyName, "propertyName");

            int doesPropertyExist;
            int hr = this.settingsStore.PropertyExists(collectionPath, propertyName, out doesPropertyExist);
            Marshal.ThrowExceptionForHR(hr);

            return Convert.ToBoolean(doesPropertyExist);
        }

        /// <summary>
        /// Checks the existance of the collection passed in to this method.
        /// </summary>
        /// <param name="collectionPath">Path of the collection.</param>
        /// <returns>Returns true if the collection exists and false otherwise.</returns>
        public override bool CollectionExists(string collectionPath)
        {
            HelperMethods.CheckNullArgument(collectionPath, "collectionPath");

            int doesCollectionExist;
            int hr = this.settingsStore.CollectionExists(collectionPath, out doesCollectionExist);
            Marshal.ThrowExceptionForHR(hr);

            return Convert.ToBoolean(doesCollectionExist);
        }
        
        /// <summary>
        /// Provides the last write time of the properties and sub collections immediate to the given collection. The method does 
        /// report any further changes internal to the sub collections (i.e. non-recursive). The last write time of a collection is 
        /// updated if properties are created, deleted or their values modified or if a sub collection is created or deleted.         
        /// </summary>
        /// <param name="collectionPath">Path of the collection.</param>
        /// <exception cref="ArgumentException">If the collection does not exist, method throws this exception.</exception>
        /// <returns>Last update time to the collection in <see cref="DateTimeKind.Local"/> format.</returns>
        public override DateTime GetLastWriteTime(string collectionPath)
        {
            HelperMethods.CheckNullArgument(collectionPath, "collectionPath");            

            SYSTEMTIME[] sysTime = new SYSTEMTIME[1];
            int hr = this.settingsStore.GetLastWriteTime(collectionPath, sysTime);
            Marshal.ThrowExceptionForHR(hr);

            return new DateTime(sysTime[0].wYear, sysTime[0].wMonth, sysTime[0].wDay, 
                                sysTime[0].wHour, sysTime[0].wMinute, sysTime[0].wSecond, 
                                sysTime[0].wMilliseconds, DateTimeKind.Local);
        }
                 
        /// <summary>
        /// Returns the number of sub collections under the given collection.
        /// </summary>
        /// <param name="collectionPath">Path of the collection.</param>
        /// <exception cref="ArgumentException">If the collection does not exist, method throws this exception.</exception>
        /// <returns>Number of sub collections is returned.</returns>
        public override int GetSubCollectionCount(string collectionPath)
        {
            HelperMethods.CheckNullArgument(collectionPath, "collectionPath");

            uint subCollectionCount;
            int hr = this.settingsStore.GetSubCollectionCount(collectionPath, out subCollectionCount);
            Marshal.ThrowExceptionForHR(hr);

            return Convert.ToInt32(subCollectionCount); // throws OverflowException if the value is larger than MAXINT which is not expected anyway
        }

        /// <summary>
        /// Returns the number of properties under the given collection.
        /// </summary>
        /// <param name="collectionPath">Path of the collection.</param>
        /// <exception cref="ArgumentException">If the collection does not exist, method throws this exception.</exception>
        /// <returns>Number of properties is returned.</returns>
        public override int GetPropertyCount(string collectionPath)
        {
            HelperMethods.CheckNullArgument(collectionPath, "collectionPath");

            uint propertyCount;
            int hr = this.settingsStore.GetPropertyCount(collectionPath, out propertyCount);
            Marshal.ThrowExceptionForHR(hr);

            return Convert.ToInt32(propertyCount); // throws OverflowException if the value is larger than MAXINT which is not expected anyway
        }

        /// <summary>
        /// Returns the names of sub collections under the given collection.
        /// </summary>
        /// <param name="collectionPath">Path of the collection.</param>
        /// <exception cref="ArgumentException">If the collection does not exist, method throws this exception.</exception>
        /// <returns>Names of sub collections is returned.</returns>
        public override IEnumerable<string> GetSubCollectionNames(string collectionPath)
        {
            HelperMethods.CheckNullArgument(collectionPath, "collectionPath");

            // count is cached since the GetSubCollectionName method itself verifies the limits
            uint subCollectionCount;
            int hr = this.settingsStore.GetSubCollectionCount(collectionPath, out subCollectionCount);
            Marshal.ThrowExceptionForHR(hr);

            // TODO: When "yield return" is used above execption is not thrown when the argument is null,
            // update the below loop to use yield return when that problem is fixed.
            string[] names = new string[subCollectionCount];
            for (uint i = 0; i < subCollectionCount; i++)
            {
                string subCollectionName;
                hr = this.settingsStore.GetSubCollectionName(collectionPath, i, out subCollectionName);
                Marshal.ThrowExceptionForHR(hr);
                names[i] = subCollectionName;
            }

            return names;
        }

        /// <summary>
        /// Returns the names of properties under the given collection.
        /// </summary>
        /// <param name="collectionPath">Path of the collection.</param>
        /// <exception cref="ArgumentException">If the collection does not exist, method throws this exception.</exception>
        /// <returns>Names of properties is returned.</returns>
        public override IEnumerable<string> GetPropertyNames(string collectionPath)
        {
            HelperMethods.CheckNullArgument(collectionPath, "collectionPath");

            // count is cached since the GetPropertyName method itself verifies the limits
            uint propertyCount;
            int hr = this.settingsStore.GetPropertyCount(collectionPath, out propertyCount);
            Marshal.ThrowExceptionForHR(hr);

            // TODO: When "yield return" is used above execption is not thrown when the argument is null,
            // update the below loop to use yield return when that problem is fixed.
            string[] names = new string[propertyCount];
            for (uint i = 0; i < propertyCount; i++)
            {
                string propertyName;
                hr = this.settingsStore.GetPropertyName(collectionPath, i, out propertyName);
                Marshal.ThrowExceptionForHR(hr);
                names[i] = propertyName;
            }

            return names;
        }        

        /// <summary>
        /// Internal constructor that takes the COM interface that provides the functionality of this class.
        /// </summary>
        /// <param name="settingsStore">COM interface wrapped by this class.</param>
        internal ShellSettingsStore(IVsSettingsStore settingsStore)
        {
            HelperMethods.CheckNullArgument(settingsStore, "settingsStore");
            this.settingsStore = settingsStore;
        }

        // Thunked interop COM interface
        private IVsSettingsStore settingsStore;
    }
}