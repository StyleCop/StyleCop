/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

***************************************************************************/

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.VisualStudio.Shell.UnitTests
{
    /// <summary>
    ///EditorFactoryNotifyForProjectAttribute class unit tests 
    ///</summary>
    [TestClass()]
    public class EditorFactoryNotifyForProjectAttributeTest
    {
        private object projectType;
        private string fileExtension;
        private object factoryType;

        #region Initialization
        /// <summary>
        /// Creates XmlDocument with one node = rootNodeName
        /// </summary>
        [TestInitialize()]
        public void InitializeParameters()
        {
            projectType = "{8a333fe3-2e11-42d9-8f6b-ae761e3b0588}";
            fileExtension = "TXT";
            factoryType = new Guid("{3e8702a1-d26f-4b91-bdc2-7ea0022b696c}");
        }
        #endregion Initialization

        /// <summary>
        /// Verify that the constructor throws a ArgumentNullException if the
        /// projectType is not set.
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorWithProjectTypeNullArgTest()
        {
            projectType = null;
            EditorFactoryNotifyForProjectAttribute target = new EditorFactoryNotifyForProjectAttribute(projectType, fileExtension, factoryType);
            Assert.IsNotNull(target, "Failed to initialize new instance of type EditorFactoryNotifyForProjectAttribute");
        }

        /// <summary>
        /// Verify that the constructor throws a ArgumentNullException if the
        /// projectType is not set.
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorWithFactoryTypeNullArgTest()
        {
            factoryType = null;
            EditorFactoryNotifyForProjectAttribute target = new EditorFactoryNotifyForProjectAttribute(projectType, fileExtension, factoryType);
            Assert.IsNotNull(target, "Failed to initialize new instance of type EditorFactoryNotifyForProjectAttribute");
        }

        /// <summary>
        ///A test for EditorFactoryNotifyForProjectAttribute (object, string, object)
        ///</summary>
        [TestMethod()]
        public void ConstructorTest()
        {
            EditorFactoryNotifyForProjectAttribute target = new EditorFactoryNotifyForProjectAttribute(projectType, fileExtension, factoryType);
            Assert.IsNotNull(target, "Failed to initialize new instance of type EditorFactoryNotifyForProjectAttribute");

            String factoryTypeString = "{3e8702a1-d26f-4b91-bdc2-7ea0022b696c}";
            projectType = new Guid("{3e8702a1-d26f-4b91-bdc2-7ea0022b696c}");
            EditorFactoryNotifyForProjectAttribute targetFromString = new EditorFactoryNotifyForProjectAttribute(projectType, fileExtension, factoryTypeString);
            Assert.IsNotNull(targetFromString, "Failed to initialize new instance of type EditorFactoryNotifyForProjectAttribute from String");

            Int32 integ = new Int32();
            factoryType = integ.GetType();
            projectType = integ.GetType();

            EditorFactoryNotifyForProjectAttribute targetFromType = new EditorFactoryNotifyForProjectAttribute(projectType, fileExtension, factoryType);
            Assert.IsNotNull(targetFromType, "Failed to initialize new instance of type EditorFactoryNotifyForProjectAttribute from Type");
        }

        /// <summary>
        /// A test for EditorFactoryNotifyForProjectAttribute (object, string, object)
        /// </summary>
        [TestMethod()]
        public void ConstructorTest1()
        {
            EditorFactoryNotifyForProjectAttribute target = new EditorFactoryNotifyForProjectAttribute(projectType, fileExtension, factoryType);
            Assert.IsNotNull(target, "Failed to initialize new instance of type EditorFactoryNotifyForProjectAttribute");

            String factoryTypeString = "{3e8702a1-d26f-4b91-bdc2-7ea0022b696c}";
            projectType = new Guid("{3e8702a1-d26f-4b91-bdc2-7ea0022b696c}");
            EditorFactoryNotifyForProjectAttribute targetFromString = new EditorFactoryNotifyForProjectAttribute(projectType, fileExtension, factoryTypeString);
            Assert.IsNotNull(targetFromString, "Failed to initialize new instance of type EditorFactoryNotifyForProjectAttribute from String");

            factoryType = typeof(int);
            projectType = typeof(int);

            EditorFactoryNotifyForProjectAttribute targetFromType = new EditorFactoryNotifyForProjectAttribute(projectType, fileExtension, factoryType);
            Assert.IsNotNull(targetFromType, "Failed to initialize new instance of type EditorFactoryNotifyForProjectAttribute from Type");
        }

        /// <summary>
        ///A test for EditorFactoryNotifyForProjectAttribute (object, string, object)
        /// Wrong cunxtructor parameter type test.
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void ConstructorTestArgumentException()
        {
            object projectType = typeof(int); // TODO: Initialize to an appropriate value
            string fileExtension = null; // TODO: Initialize to an appropriate value
            object factoryType = (int)0; // TODO: Initialize to an appropriate value

            EditorFactoryNotifyForProjectAttribute target = new EditorFactoryNotifyForProjectAttribute(projectType, fileExtension, factoryType);
            Assert.IsNotNull(target, "Failed to initialize new instance of type EditorFactoryNotifyForProjectAttribute");
        }

        /// <summary>
        ///A test for EditorFactoryNotifyForProjectAttribute (object, string, object)
        /// Wrong cunxtructor parameter type test.
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void ConstructorTestArgumentException1()
        {
            object projectType = (int)0; // TODO: Initialize to an appropriate value
            string fileExtension = null; // TODO: Initialize to an appropriate value
            object factoryType = typeof(int); // TODO: Initialize to an appropriate value

            EditorFactoryNotifyForProjectAttribute target = new EditorFactoryNotifyForProjectAttribute(projectType, fileExtension, factoryType);
            Assert.IsNotNull(target, "Failed to initialize new instance of type EditorFactoryNotifyForProjectAttribute");
        }


        /// <summary>
        ///A test for FactoryType
        ///</summary>
        [TestMethod()]
        public void FactoryTypeTest()
        {
            EditorFactoryNotifyForProjectAttribute target = new EditorFactoryNotifyForProjectAttribute(projectType,
            fileExtension, factoryType);
            Guid val = new Guid("{3e8702a1-d26f-4b91-bdc2-7ea0022b696c}");

            Assert.AreEqual(val, target.FactoryType, "Microsoft.Samples.VisualStudio.SynchronousXmlDesigner.Attributes.EditorFactoryNotify" +
            "ForProjectAttribute.FactoryType was not set correctly.");
        }

        /// <summary>
        ///A test for FileExtension
        ///</summary>
        [TestMethod()]
        public void FileExtensionTest()
        {
            EditorFactoryNotifyForProjectAttribute target = new EditorFactoryNotifyForProjectAttribute(projectType, fileExtension, factoryType);
            string val = "TXT";

            Assert.AreEqual(val, target.FileExtension, "Microsoft.Samples.VisualStudio.SynchronousXmlDesigner.Attributes.EditorFactoryNotify" +
                    "ForProjectAttribute.FileExtension was not set correctly.");
        }

        /// <summary>
        ///A test for ProjectFileExtensionPath
        ///</summary>        
        [TestMethod()]
        public void ProjectFileExtensionPathTest()
        {
            EditorFactoryNotifyForProjectAttribute target = new EditorFactoryNotifyForProjectAttribute(projectType, fileExtension, factoryType);
            string extension = "TXT";

            Assert.AreEqual(extension, target.FileExtension,
            "Microsoft.Samples.VisualStudio.SynchronousXmlDesigner.Attributes.EditorFactoryNotify" +
                    "ForProjectAttribute.ProjectFileExtensionPath was not set correctly.");
        }

        /// <summary>
        /// A test for ProjectType
        /// </summary>
        [TestMethod()]
        public void ProjectTypeTest()
        {
            EditorFactoryNotifyForProjectAttribute target = new EditorFactoryNotifyForProjectAttribute(projectType, fileExtension, factoryType);
            Guid val = new Guid("{8a333fe3-2e11-42d9-8f6b-ae761e3b0588}");

            Assert.AreEqual(val, target.ProjectType, "Microsoft.Samples.VisualStudio.SynchronousXmlDesigner.Attributes.EditorFactoryNotify" +
                    "ForProjectAttribute.ProjectType was not set correctly.");
        }

        /// <summary>
        /// A test for Register (RegistrationContext)
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RegisterWithNullArgTest()
        {
            EditorFactoryNotifyForProjectAttribute target = new EditorFactoryNotifyForProjectAttribute(projectType, fileExtension, factoryType);
            MockRegistrationContext context = null;
            target.Register(context);
        }

        /// <summary>
        /// A test for Register (RegistrationContext)
        /// </summary>
        [TestMethod()]
        public void RegisterTest()
        {
            EditorFactoryNotifyForProjectAttribute target = new EditorFactoryNotifyForProjectAttribute(projectType, fileExtension, factoryType);
            using (MockRegistrationContext context = new MockRegistrationContext())
            {
                target.Register(context);
            }
        }

        /// <summary>
        /// A test for Unregister (RegistrationContext)
        /// </summary>
        [TestMethod()]
        public void UnregisterWithNullArgTest()
        {
            EditorFactoryNotifyForProjectAttribute target = new EditorFactoryNotifyForProjectAttribute(projectType, fileExtension, factoryType);
            MockRegistrationContext context = null;
            target.Unregister(context);
        }

        /// <summary>
        /// A test for Unregister (RegistrationContext)
        /// </summary>
        [TestMethod()]
        public void UnregisterTest()
        {
            EditorFactoryNotifyForProjectAttribute target = new EditorFactoryNotifyForProjectAttribute(projectType, fileExtension, factoryType);
            using (MockRegistrationContext context = new MockRegistrationContext())
            {
                target.Unregister(context);
            }
        }
    }
}
