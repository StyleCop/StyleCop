// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VSWindowsTest.cs" company="https://github.com/StyleCop">
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
//   This is a test class for VSWindowsTest and is intended
//   to contain all VSWindowsTest Unit Tests
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace VSPackageUnitTest
{
    using System;
    using System.Reflection;

    using EnvDTE;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using StyleCop.VisualStudio;

    using VSPackageUnitTest.Mocks;

    /// <summary>
    /// This is a test class for VSWindowsTest and is intended
    ///   to contain all VSWindowsTest Unit Tests
    /// </summary>
    [TestClass]
    public class VSWindowsTest : BasicUnitTest
    {
        #region Constants and Fields

        private MockServiceProvider serviceProvider;

        #endregion

        #region Public Methods

        /// <summary>
        /// Unit Test Case for DTE.
        /// </summary>
        [TestMethod]
        public void DTEPropertyTest()
        {
            VSWindows actual = VSWindows.GetInstance(this.serviceProvider);
            Assert.IsNotNull(typeof(VSWindows).GetProperty("DTE", BindingFlags.Instance | BindingFlags.NonPublic)
                .GetValue(actual, null), "DTE property was null");
        }

        /// <summary>
        /// A test for GetInstance
        /// </summary>
        [TestMethod]
        public void GetInstanceTest()
        {
            VSWindows actual = VSWindows.GetInstance(this.serviceProvider);
            Assert.IsNotNull(actual, "VSWindows.GetInstance() returned null.");
            Assert.AreEqual(this.serviceProvider, (IServiceProvider)typeof(VSWindows).GetField("serviceProvider", BindingFlags.Instance | BindingFlags.NonPublic)
                .GetValue(actual), "Service provider was not set correctly");
        }

        /// <summary>
        /// The my test cleanup.
        /// </summary>
        [TestCleanup]
        public void MyTestCleanup()
        {
            this.serviceProvider = null;
            typeof(VSWindows).GetField("instance", BindingFlags.Static | BindingFlags.NonPublic)
                .SetValue(null, null);
        }

        /// <summary>
        /// The my test initialize.
        /// </summary>
        [TestInitialize]
        public void MyTestInitialize()
        {
            this.serviceProvider = new MockServiceProvider();
        }

        /// <summary>
        /// Unit Test Case for OutputPane.
        /// </summary>
        [TestMethod]
        public void OutputPanePropertyTest()
        {
            // Setup
            Mock<Window> mockWindow = this.SetupMockWindow();
            Mock<OutputWindow> mockOutputWindow = new Mock<OutputWindow>(MockBehavior.Strict);
            mockWindow.SetupGet(w => w.Object).Returns(mockOutputWindow.Object);
            Mock<OutputWindowPane> mockOutputWindowPane = new Mock<OutputWindowPane>(MockBehavior.Strict);
            Mock<OutputWindowPanes> mockOutputWindowPanes = new Mock<OutputWindowPanes>(MockBehavior.Strict);
            mockOutputWindow.SetupGet(ow => ow.OutputWindowPanes).Returns((EnvDTE.OutputWindowPanes)mockOutputWindowPanes.Object);
            mockOutputWindowPanes.Setup(owp => owp.Add("StyleCop")).Returns((EnvDTE.OutputWindowPane)mockOutputWindowPane.Object);

            // Call
            VSWindows actual = VSWindows.GetInstance(this.serviceProvider);

            // Verify
            Assert.IsNotNull(actual.OutputPane, "OutputPane property was null");
        }

        /// <summary>
        /// Unit Test Case for OutputPane.
        /// </summary>
        [TestMethod]
        public void OutputWindowPropertyTest()
        {
            // Setup
            Mock<Window> mockWindow = this.SetupMockWindow();

            // Call
            VSWindows actual = VSWindows.GetInstance(this.serviceProvider);

            // Verify
            Assert.IsNotNull(actual.OutputWindow, "OutputWindow property was null");
        }

        #endregion

        #region Methods

        private Mock<Window> SetupMockWindow()
        {
            Mock<Windows> mockWindows = new Mock<Windows>(MockBehavior.Strict);
            Mock<Window> mockWindow = new Mock<Window>(MockBehavior.Strict);
            mockWindows.Setup(ws => ws.Item(Constants.vsWindowKindOutput)).Returns(mockWindow.Object);
            this.serviceProvider.DTE.Windows = mockWindows.Object;
            return mockWindow;
        }

        #endregion
    }
}