// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AnalysisThreadTest.cs" company="https://github.com/StyleCop">
//   MS-PL
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
// <summary>
//   This is a test class for AnalysisThreadTest and is intended
//   to contain all AnalysisThreadTest Unit Tests
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace VSPackageUnitTest
{
    using System.Collections.Generic;
    using System.Reflection;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using StyleCop;
    using StyleCop.VisualStudio;

    /// <summary>
    /// This is a test class for AnalysisThreadTest and is intended
    ///  to contain all AnalysisThreadTest Unit Tests
    /// </summary>
    [TestClass]
    public class AnalysisThreadTest
    {
        #region Properties

        /// <summary>
        ///   Gets or sets the test context which provides
        ///   information about and functionality for the current test run.
        /// </summary>
        public TestContext TestContext { get; set; }

        #endregion

        // You can use the following additional attributes as you write your tests:
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext)
        // {
        // }
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup()
        // {
        // }
        // Use TestInitialize to run code before running each test
        // [TestInitialize]
        // public void MyTestInitialize()
        // {
        // }
        // Use TestCleanup to run code after each test has run
        // [TestCleanup]
        // public void MyTestCleanup()
        // {
        // }
        #region Public Methods

        /// <summary>
        /// Unit Test Case for Constructor
        ///   This tests ???.
        /// </summary>
        [TestMethod]
        public void ConstructorTest()
        {
            bool isFull = true;
            var target = CreateAnalysisThread(isFull);
            Assert.IsNotNull(target, "Constructor is broken");
            Assert.IsNotNull(typeof(AnalysisThread)
                .GetField("projects", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(target),
                "Constructor did not set the projects.");
            Assert.IsTrue((bool)typeof(AnalysisThread)
                .GetField("full", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(target),
                "Constructor did not set the full flag.");
            Assert.IsNotNull(typeof(AnalysisThread)
                .GetField("core", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(target),
                "Constructor did not set the core.");
        }

        /// <summary>
        /// Unit Test Case for AnalyseProc
        ///   This tests ???.
        /// </summary>
        [TestMethod]
        public void TestAnalyseProcFull()
        {
            var target = CreateAnalysisThread(true);
            target.AnalyzeProc();
        }

        /// <summary>
        /// Unit Test Case for TestMethod
        ///   This tests ???.
        /// </summary>
        [TestMethod]
        public void TestAnalyzeProcNotFull()
        {
            var target = CreateAnalysisThread(false);

            bool eventFired = false;
            target.Complete += (sender, args) => { eventFired = true; };

            target.AnalyzeProc();
            Assert.IsTrue(eventFired, "Analysation didnt fire the Complete event");
        }

        #endregion

        #region Methods

        private static AnalysisThread CreateAnalysisThread(bool isFull)
        {
            var core = new StyleCopCore();
            var projects = new List<CodeProject>();
            var mockCodeProject = new Mock<CodeProject>(MockBehavior.Strict);
            var codeProject = new CodeProject(0, "test", new Configuration(new string[0]));
            projects.Add(codeProject);

            var target = new AnalysisThread(isFull, projects, core);
            return target;
        }

        #endregion
    }
}