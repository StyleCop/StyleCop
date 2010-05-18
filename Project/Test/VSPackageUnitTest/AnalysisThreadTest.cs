//-----------------------------------------------------------------------
// <copyright file="AnalysisThreadTest.cs" company="Microsoft">
//   Copyright (c) Microsoft Corporation.
// </copyright>
// <license>
//   This source code is subject to terms and conditions of the Microsoft 
//   Public License. A copy of the license can be found in the License.html 
//   file at the root of this distribution. If you cannot locate the  
//   Microsoft Public License, please send an email to dlr@microsoft.com. 
//   By using this source code in any fashion, you are agreeing to be bound 
//   by the terms of the Microsoft Public License. You must not remove this 
//   notice, or any other, from this software.
// </license>
//-----------------------------------------------------------------------
namespace VSPackageUnitTest
{
    using System;
    using System.Collections.Generic;
    using Microsoft.StyleCop;
    using Microsoft.StyleCop.VisualStudio;
    using Microsoft.VisualStudio.TestTools.MockObjects;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    /// <summary>
    ///This is a test class for AnalysisThreadTest and is intended
    ///to contain all AnalysisThreadTest Unit Tests
    ///</summary>
    [TestClass()]
    public class AnalysisThreadTest
    {
        /// <summary>
        /// Gets or sets the test context which provides
        /// information about and functionality for the current test run.
        /// </summary>
        public TestContext TestContext
        {
            get;
            set;
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion

        /// <summary>
        /// Unit Test Case for Constructor
        /// This tests ???.
        /// </summary>
        [TestMethod()]
        public void ConstructorTest()
        {
            bool isFull = true;
            var target = CreateAnalysisThread(isFull);
            Assert.IsNotNull(target, "Constructor is broken");
            Assert.IsNotNull(target.projects, "Constructor did not set the projects.");
            Assert.IsTrue(target.full, "Constructor did not set the full flag.");
            Assert.IsNotNull(target.core, "Constructor did not set the core.");
        }

        /// <summary>
        /// Unit Test Case for AnalyseProc
        /// This tests ???.
        /// </summary>
        [TestMethod()]
        public void TestAnalyseProcFull()
        {
            var target = CreateAnalysisThread(true);
            target.AnalyzeProc();
        }

        /// <summary>
        /// Unit Test Case for TestMethod
        /// This tests ???.
        /// </summary>
        [TestMethod()]
        public void TestAnalyzeProcNotFull()
        {
            var target = CreateAnalysisThread(false);

            bool eventFired = false;
            target.add_Complete((sender, args) => { eventFired = true; });

            target.AnalyzeProc();
            Assert.IsTrue(eventFired, "Analysation didnt fire the Complete event");
        }

        private static AnalysisThread_Accessor CreateAnalysisThread(bool isFull)
        {
            var core = new StyleCopCore();
            var projects = new List<CodeProject>();
            var mockCodeProject = new Mock<CodeProject>();
            var codeProject = new CodeProject(0, "test", new Configuration(new string[0]));
            projects.Add(codeProject);

            var target = new AnalysisThread_Accessor(isFull, projects, core); 
            return target;
        }
    }
}
