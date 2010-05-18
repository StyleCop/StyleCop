/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

***************************************************************************/

using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VsSDK.UnitTestLibrary;
using System.Collections;
using System.Runtime.InteropServices;

namespace Microsoft.VisualStudio.Shell.RegistrationAttributes.UnitTests
{
    /// <summary>
    /// This class is created just to get a type that can be used for the test.
    /// </summary>
    [Guid("EEAB0D91-86F3-4f3a-959A-9548C5642203")]
    public class DummyTypeWithGuid
    {
    }

    /// <summary>
    /// This class tests the common methods and all the properties of the attribute
    /// </summary>
    /// 
    [CLSCompliant(false)]
    public abstract class AttributeCommonTest
    {
        #region fields
        /// <summary>
        /// Top level reg key to add
        /// </summary>
        protected string RegKeyToAdd = "";

        /// <summary>
        /// Attribute instance
        /// </summary>
        [CLSCompliant(false)]
        protected RegistrationAttribute _instance = null;

        /// <summary>
        /// Data to hold the expected values
        /// </summary>
        protected Hashtable _data = new Hashtable();

        /// <summary>
        /// The registration context mock that has the values set by the registration method
        /// </summary>
        private BaseRegistrationContextMock _mock = null;
        #endregion

        #region properties
        /// <summary>
        /// Returns the registration context mock object.
        /// </summary>
        protected BaseRegistrationContextMock ContextMock
        {
            get
            {
                if (_mock == null)
                    _mock = new BaseRegistrationContextMock();
                return _mock;
            }
        } 
        #endregion

        #region abstract properties
        /// <summary>
        /// This property is implemented by the derived tests to set up the expected values
        /// hash table. The table is keyed on reg key name and value is a hash table of value 
        /// name data pairs for e.g:
        /// KEY:(String)
        /// Packages\{019971D6-4685-11D2-B48A-0000F87572EB}
        /// VALUES:(HashTable)        
        ///     ""              "Visual Basic Compiler Package"
        ///     InprocServer32  "E:\binaries.x86ret.rtm\bin\i386\vspkgs\msvb7.dll"
        /// Packages\{019971D6-4685-11D2-B48A-0000F87572EB}\Automation
        ///     "My Automation Object"              "AutomationObject"
        /// </summary>
        protected abstract Hashtable ExpectedValues
        {
            get;
        }

        /// <summary>
        /// Gets an appropiately populated attribute instance
        /// </summary>
        [CLSCompliant(false)]
        protected abstract RegistrationAttribute AttributeInstance
        {
            get;
        }
        #endregion

        #region virtual methods (test helpers)
        /// <summary>
        /// This scenario tests if an instance of the attribute can be constructed
        /// </summary>
        /// 
        public virtual void CreateInstance()
        {
            Assert.IsNotNull(this.AttributeInstance);
        }

        /// <summary>
        /// This scenario verifies Register method
        /// </summary>
        public virtual void RegistrationTest()
        {
            this.AttributeInstance.Register(ContextMock);

            //Verify if the number of the registry entries is the same
            Assert.IsTrue(ContextMock.RegistryEntries.Count == this.ExpectedValues.Count);

            //Verify each entry
            foreach (object regKeyName in ContextMock.RegistryEntries.Keys)
            {
                Hashtable valDataActual, valDataExpected;
                Assert.IsNotNull(valDataActual = (Hashtable)(((RegistrationKeyMock)ContextMock.RegistryEntries[regKeyName])).Keys);
                Assert.IsNotNull(valDataExpected = (Hashtable)ExpectedValues[regKeyName]);
                Assert.IsTrue(valDataActual.Count == valDataExpected.Count);
                foreach (object valueName in valDataActual.Keys)
                    Assert.IsTrue(string.Compare(valDataActual[valueName.ToString()].ToString(), valDataExpected[valueName.ToString()].ToString(), true) == 0);
            }

        }

        /// <summary>
        /// This scenario verifies the UnRegistermehtod
        /// </summary>
        public virtual void UnRegistrationTest()
        {
            AttributeInstance.Unregister(ContextMock);
            Assert.IsTrue(ContextMock.RegistryEntries.Count == 0);
        }
        #endregion
    }

}
