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
    /// This class tests the ProvideAppCommandLineAttribute class
    /// </summary>
    [CLSCompliant(false)]
    [TestClass]
    public class AppCommandLineAttributeTest : AttributeCommonTest
    {
        #region fields
        private Type packageType = typeof(DummyTypeWithGuid);
        private string appCmdLineName = "MyAppCommandLine".ToUpperInvariant(); 
        #endregion

        #region overridden properties
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
                    ProvideAppCommandLineAttribute appCmdAttrib =
                        new ProvideAppCommandLineAttribute(appCmdLineName, packageType);
                    appCmdAttrib.Arguments = "*";
                    appCmdAttrib.DemandLoad = 1;
                    appCmdAttrib.HelpString = "#200";
                    _instance = appCmdAttrib;
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
                RegKeyToAdd = @"AppCommandLine\MyAppCommandLine".ToUpperInvariant();

                //Build the data for each reg key entry in the hash table.
                Hashtable valData = new Hashtable();
                valData.Add("Arguments".ToUpperInvariant(), "*");
                valData.Add("DemandLoad".ToUpperInvariant(), "1".ToUpperInvariant());
                valData.Add("Package".ToUpperInvariant(), packageType.GUID.ToString("B").ToUpperInvariant());
                valData.Add("HelpString".ToUpperInvariant(), "#200".ToUpperInvariant());

                //Add the reg entry
                _data.Add(RegKeyToAdd, valData);

                return _data;
            }
        } 
        #endregion

        #region overridden methods
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
        #endregion
    }
}
