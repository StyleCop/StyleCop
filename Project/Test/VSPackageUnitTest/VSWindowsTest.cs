//--------------------------------------------------------------------------
// <copyright file="VSWindowsTest.cs" company="Microsoft">
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
    using Microsoft.StyleCop.VisualStudio;
    using Microsoft.VisualStudio.TestTools.MockObjects;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using VSPackageUnitTest.Mocks;

    /// <summary>
    ///This is a test class for VSWindowsTest and is intended
    ///to contain all VSWindowsTest Unit Tests
    ///</summary>
    [TestClass()]
    public class VSWindowsTest : BasicUnitTest
    {
        private MockServiceProvider serviceProvider;

        /// <summary>
        /// A test for GetInstance
        /// </summary>
        [TestMethod()]
        [DeploymentItem("Microsoft.StyleCop.VSPackage.dll")]
        public void GetInstanceTest()
        {
            VSWindows_Accessor actual = VSWindows_Accessor.GetInstance(this.serviceProvider);
            Assert.IsNotNull(actual, "VSWindows.GetInstance() returned null.");
            Assert.AreEqual(this.serviceProvider, actual.serviceProvider, "Service provider was not set correctly");
        }

        /// <summary>
        /// Unit Test Case for DTE.
        /// </summary>
        [TestMethod()]
        public void DTEPropertyTest()
        {
            VSWindows_Accessor actual = VSWindows_Accessor.GetInstance(this.serviceProvider);
            Assert.IsNotNull(actual.DTE, "DTE property was null");
        }

        /// <summary>
        /// Unit Test Case for OutputPane.
        /// </summary>
        [TestMethod()]
        public void OutputWindowPropertyTest()
        {
            // Setup
            Mock<EnvDTE.Window> mockWindow = SetupMockWindow();

            // Call
            VSWindows_Accessor actual = VSWindows_Accessor.GetInstance(this.serviceProvider);

            // Verify
            Assert.IsNotNull(actual.OutputWindow, "OutputWindow property was null");
        }

        /// <summary>
        /// Unit Test Case for OutputPane.
        /// </summary>
        [TestMethod()]
        public void OutputPanePropertyTest()
        {
            // Setup
            Mock<EnvDTE.Window> mockWindow = SetupMockWindow();
            Mock<EnvDTE.OutputWindow> mockOutputWindow = new Mock<EnvDTE.OutputWindow>();
            mockWindow.ImplementExpr(w => w.Object, (EnvDTE.OutputWindow)mockOutputWindow.Instance);
            Mock<EnvDTE.OutputWindowPane> mockOutputWindowPane = new Mock<EnvDTE.OutputWindowPane>();
            Mock<EnvDTE.OutputWindowPanes> mockOutputWindowPanes = new Mock<EnvDTE.OutputWindowPanes>();
            mockOutputWindow.ImplementExpr(ow => ow.OutputWindowPanes, (EnvDTE.OutputWindowPanes)mockOutputWindowPanes.Instance);
            mockOutputWindowPanes.ImplementExpr(owp => owp.Add("StyleCop"), (EnvDTE.OutputWindowPane)mockOutputWindowPane.Instance);

            // Call
            VSWindows_Accessor actual = VSWindows_Accessor.GetInstance(this.serviceProvider);

            // Verify
            Assert.IsNotNull(actual.OutputPane, "OutputPane property was null");
        }

        private Mock<EnvDTE.Window> SetupMockWindow()
        {
            Mock<EnvDTE.Windows> mockWindows = new Mock<EnvDTE.Windows>();
            Mock<EnvDTE.Window> mockWindow = new Mock<EnvDTE.Window>();
            mockWindows.ImplementExpr(ws => ws.Item(EnvDTE.Constants.vsWindowKindOutput), (EnvDTE.Window)mockWindow.Instance);
            this.serviceProvider.DTE.Windows = mockWindows.Instance as EnvDTE.Windows;
            return mockWindow;
        }

        [TestInitialize()]
        public void MyTestInitialize()
        {
            this.serviceProvider = new MockServiceProvider();
        }

        [TestCleanup()]
        public void MyTestCleanup()
        {
            this.serviceProvider = null;
            VSWindows_Accessor.instance = null;
        }
    }
}
