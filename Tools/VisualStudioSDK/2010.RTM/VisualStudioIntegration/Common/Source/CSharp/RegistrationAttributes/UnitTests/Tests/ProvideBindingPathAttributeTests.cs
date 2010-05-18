/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

***************************************************************************/

using System;
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VsSDK.UnitTestLibrary;
using System.Reflection;
using System.IO;

namespace Microsoft.VisualStudio.Shell.RegistrationAttributes.UnitTests
{
    /// <summary>
    /// Unit tests for the ProvideBindingPathAttribute class
    /// </summary>
    [CLSCompliant(false)]
    [TestClass]
    public class ProvideBindingPathAttributeTests : AttributeCommonTest
    {
        [TestMethod]
        public void Register_WithDefaultProperties_UsesComponentPathAndPackageGuidValue()
        {
            var attribute = new ProvideBindingPathAttribute();
            var expectedKeys = new Hashtable()
            {
                //Build the data for each reg key entry in the hash table.
                { 
                    @"BindingPaths\".ToUpperInvariant() + ContextMock.GetType().GUID.ToString("B").ToUpperInvariant(), 
                    new Hashtable()
                    {
                        { Path.GetDirectoryName(Assembly.GetExecutingAssembly().EscapedCodeBase).ToUpperInvariant(), "" }
                    }
                }
            };

            AttributeCommonTest.RegistrationTest(attribute, expectedKeys, new BaseRegistrationContextMock());
        }

        [TestMethod]
        public void Register_WithSubFolderSpecified_UsesPackageFolderTokenWithSubTokenAndPackageGuidValue()
        {
            var attribute = new ProvideBindingPathAttribute()
            {
                SubPath = "subFolder",
            };

            var expectedKeys = new Hashtable()
            {
                //Build the data for each reg key entry in the hash table.
                { 
                    @"BindingPaths\".ToUpperInvariant() + ContextMock.GetType().GUID.ToString("B").ToUpperInvariant(), 
                    new Hashtable()
                    {   
                        {Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().EscapedCodeBase),"subFolder").ToUpperInvariant(), ""}
                    }
                }
            };

            AttributeCommonTest.RegistrationTest(attribute, expectedKeys, new BaseRegistrationContextMock());
        }

        [TestMethod]
        public void Register_NullContext_ExceptionThrown()
        {
            NullContextTestHelper(true);
        }

        [TestMethod]
        public void Unregister_NullContext_ExceptionThrown()
        {
            NullContextTestHelper(false);
        }

        private static void NullContextTestHelper(bool useRegisterMethod)
        {
            bool exceptionThrown = false;
            var attribute = new ProvideBindingPathAttribute();
            try
            {
                if (useRegisterMethod)
                {
                    attribute.Register(null);
                }
                else
                {
                    attribute.Unregister(null);
                }
            }
            catch (ArgumentNullException)
            {
                exceptionThrown = true;
            }
            Assert.IsTrue(exceptionThrown);
        }

        protected override Hashtable ExpectedValues
        {
            get { throw new NotImplementedException(); }
        }

        protected override RegistrationAttribute AttributeInstance
        {
            get { throw new NotImplementedException(); }
        }
    }
}
