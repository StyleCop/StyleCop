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

namespace Microsoft.VisualStudio.Shell.RegistrationAttributes.UnitTests
{

    /// <summary>
    /// This class tests the CodeGeneratorRegistrationAttribute class
    /// </summary>
    [CLSCompliant(false)]
    [TestClass]
    public class CodeGeneratorRegistrationAttributeTest : AttributeCommonTest
    {
        //Reg Key Name
        private string GeneratorsRegKeyName = "generators".ToUpperInvariant();

        //Reg Key Value names
        private string ClsidValueName = "clsid".ToUpperInvariant();
        private string GeneratesDesignTimeSourceValueName = "generatesdesigntimesource".ToUpperInvariant();
        private string GeneratesSharedDesignTimeSourceValueName = "generatesshareddesigntimesource".ToUpperInvariant();

        //Reg data to build the key name
        private string GeneratorGuid = Guid.NewGuid().ToString("B").ToLower();
        private Type GeneratorType = typeof(DummyTypeWithGuid);
        private string GeneratorName = typeof(DummyTypeWithGuid).Name.ToLower();

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
                    CodeGeneratorRegistrationAttribute codeGenRegAttrib = new CodeGeneratorRegistrationAttribute(GeneratorType, GeneratorName, GeneratorGuid);
                    codeGenRegAttrib.GeneratesDesignTimeSource = true;
                    codeGenRegAttrib.GeneratesSharedDesignTimeSource = true;
                    _instance = codeGenRegAttrib;

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
                RegKeyToAdd = string.Join(@"\", new string[] { GeneratorsRegKeyName, GeneratorGuid, GeneratorName });
                RegKeyToAdd = RegKeyToAdd.ToUpperInvariant();

                //Build the data for each reg key entry in the hah table.
                Hashtable valData = new Hashtable();
                valData.Add(string.Empty, GeneratorName.ToUpperInvariant());
                valData.Add(ClsidValueName, GeneratorType.GUID.ToString("B").ToUpperInvariant());
                valData.Add(GeneratesDesignTimeSourceValueName, "1");
                valData.Add(GeneratesSharedDesignTimeSourceValueName, "1");

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
