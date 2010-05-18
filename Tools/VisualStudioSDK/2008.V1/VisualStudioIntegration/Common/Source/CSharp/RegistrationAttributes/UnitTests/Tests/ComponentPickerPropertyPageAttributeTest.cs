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

namespace Microsoft.VisualStudio.Shell.RegistrationAttributes.UnitTests.Tests
{
    /// <summary>
    /// This class tests the ComponentPickerPropertyPageAttribute class
    /// </summary>
    [CLSCompliant(false)]
    [TestClass]
    public class ComponentPickerPropertyPageAttributeTest : AttributeCommonTest
    {
        //Reg Key Name
        private string ComponentPickerRegKeyName = "ComponentPickerPages";
        private string PageRegKeyName = "TestPage";

        //Reg Key Value Names
        private string ComponentTypeValueName = "componenttype".ToUpperInvariant();
        private string AddToMruValueName = "addtomru".ToUpperInvariant();
        private string PacakgeValueName = "package".ToUpperInvariant();
        private string PageValueName = "page".ToUpperInvariant();
        private string SortValueName = "sort".ToUpperInvariant();

        //Reg data to build the key name
        private Type PageType = typeof(DummyTypeWithGuid);
        private Type PackageType = typeof(DummyTypeWithGuid);
        private string PageDefaultValueData = typeof(DummyTypeWithGuid).Name.ToLower();
        private string ComponentTypeValueData = "MyComponent";
        private bool AddToMruValueData = true;
        private int SortOrderData = 10;

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
                    ComponentPickerPropertyPageAttribute cmpPickerPageAttrib = new ComponentPickerPropertyPageAttribute(PackageType, PageType, PageRegKeyName);
                    cmpPickerPageAttrib.AddToMru = AddToMruValueData;
                    cmpPickerPageAttrib.ComponentType = ComponentTypeValueData;
                    cmpPickerPageAttrib.DefaultPageNameValue = PageDefaultValueData;
                    cmpPickerPageAttrib.SortOrder = SortOrderData;

                    _instance = cmpPickerPageAttrib;

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
                RegKeyToAdd = string.Join(@"\", new string[] { ComponentPickerRegKeyName, PageRegKeyName });
                RegKeyToAdd = RegKeyToAdd.ToUpperInvariant();

                //Build the data for each reg key entry in the hah table.
                Hashtable valData = new Hashtable();
                valData.Add(string.Empty, PageDefaultValueData.ToUpperInvariant());
                valData.Add(PacakgeValueName, PackageType.GUID.ToString("B").ToUpperInvariant());
                valData.Add(PageValueName, PageType.GUID.ToString("B").ToUpperInvariant());
                valData.Add(ComponentTypeValueName, ComponentTypeValueData.ToUpperInvariant());

                valData.Add(AddToMruValueName, Convert.ToInt32(AddToMruValueData).ToString());
                valData.Add(SortValueName, SortOrderData.ToString());

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

