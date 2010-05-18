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
using Microsoft.VisualStudio.Shell;
using System.Collections;
using System.Runtime.InteropServices;
using System.Globalization;

namespace Microsoft.VisualStudio.Shell.RegistrationAttributes.UnitTests
{

    /// <summary>
    /// This class tests the CodeGeneratorRegistrationAttribute class
    /// </summary>
    [CLSCompliant(false)]
    [TestClass]
    public class SingleFileGeneratorAttributeTest : AttributeCommonTest  
    {
        private Type ProjectFactType = typeof(DummyTypeWithGuid);

        /// <summary>
        /// Gets an appropiately populated attribute instance
        /// </summary>
        [CLSCompliant(false)]
        protected override RegistrationAttribute AttributeInstance
        {
            get
            {
                if (_instance == null)
                {
                    SingleFileGeneratorSupportRegistrationAttribute sfgRegAttrib =
                        new SingleFileGeneratorSupportRegistrationAttribute(ProjectFactType);
                    _instance = sfgRegAttrib;
                }
                return _instance;
            }
        }

        /// <summary>
        /// Returns the hash table of the expected registry key and values.
        /// </summary>
        protected override Hashtable ExpectedValues
        {
            get 
            {
                _data.Clear();
                //Build the reg key name
                RegKeyToAdd = string.Format(CultureInfo.InvariantCulture, @"Generators\{0}", ProjectFactType.GUID.ToString("B"));
                RegKeyToAdd = RegKeyToAdd.ToUpperInvariant();

                //Build the data for each reg key entry in the hah table.
                Hashtable valData = new Hashtable();
                valData.Add(string.Empty, string.Empty);

                //Add the reg entry
                _data.Add(RegKeyToAdd, valData);

                return _data;
            }
        }

        /// <summary>
        /// This scenario tests if an instance of the attribute can be constructed
        /// </summary>
        [TestMethod()]
        public override void CreateInstance()
        {
            base.CreateInstance();
        }

        /// <summary>
        /// This scenario verifies Register method
        /// </summary>
        [TestMethod()]
        public override void RegistrationTest()
        {
            base.RegistrationTest();
        }

        /// <summary>
        /// This scenario verifies the UnRegistermehtod
        /// </summary>
        [TestMethod()]
        public override void UnRegistrationTest()
        {
            base.UnRegistrationTest();
        }

    }
}
