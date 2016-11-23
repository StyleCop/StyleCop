// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ViolationTaskTest.cs" company="https://github.com/StyleCop">
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
//   This is a test class for ViolationTaskTest and is intended
//   to contain all ViolationTaskTest Unit Tests
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace VSPackageUnitTest
{
    using System;
    using System.Collections;
    using System.Reflection;

    using EnvDTE;

    using Microsoft.VisualStudio.Shell;
    using Microsoft.VisualStudio.Shell.Interop;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using StyleCop;
    using StyleCop.VisualStudio;

    using VSPackageUnitTest.Mocks;

    /// <summary>
    /// This is a test class for ViolationTaskTest and is intended
    ///  to contain all ViolationTaskTest Unit Tests
    /// </summary>
    [TestClass]
    public class ViolationTaskTest
    {
        #region Constants and Fields

        private Mock<IServiceProvider> mockServiceProvider;

        private StyleCopVSPackage package;

        private ViolationTask taskUnderTest;

        private ErrorTask taskUnderTestShell;

        private ViolationInfo violation;

        #endregion

        #region Properties

        ///<summary>
        ///  Gets or sets the test context which provides
        ///  information about and functionality for the current test run.
        ///</summary>
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
        #region Public Methods

        /// <summary>
        /// Use TestCleanup to run code after each test has run
        /// </summary>
        [TestCleanup]
        public void MyTestCleanup()
        {
            this.taskUnderTest = null;
            this.taskUnderTestShell = null;
            this.taskUnderTest = null;
        }

        /// <summary>
        /// Use TestInitialize to run code before running each test
        /// </summary>
        [TestInitialize]
        public void MyTestInitialize()
        {
            // Creating a package will set the factory service provider.
            this.package = new StyleCopVSPackage();

            this.mockServiceProvider = new Mock<IServiceProvider>(MockBehavior.Strict);
            this.violation = CreateDummyViolationInfo();

            this.package.Core.DisplayUI = false;
            this.taskUnderTest = new ViolationTask(this.package, this.violation, null);
            this.taskUnderTestShell = taskUnderTest;
        }

        /// <summary>
        /// A test for OnNavigate
        /// </summary>
        [TestMethod]
        public void OnNavigateEmptyDocumentTest()
        {
            bool eventFired = false;
            var mockDte = new Mock<DTE>(MockBehavior.Strict);
            this.mockServiceProvider.Setup(sp => sp.GetService(typeof(EnvDTE.DTE))).Returns(mockDte.Object);
            this.mockServiceProvider.Setup(sp => sp.GetService(typeof(SVsSolutionBuildManager))).Returns(new MockSolutionBuildManager());
            AnalysisHelper analysisHelper = this.SetCoreNoUI();
            var styleCopCore = (StyleCopCore)typeof(AnalysisHelper)
                .GetField("core", BindingFlags.Instance | BindingFlags.NonPublic)
                .GetValue(analysisHelper);
            styleCopCore.OutputGenerated += (sender, args) => { eventFired = true; };

            // Does nothing - included for code coverage and to catch it if it starts doing something unexpectedly
            this.taskUnderTestShell.Document = string.Empty;
            typeof(ViolationTask).GetMethod("OnNavigate", BindingFlags.Instance | BindingFlags.NonPublic)
                .Invoke(this.taskUnderTest, new object[] { EventArgs.Empty });

            Assert.IsTrue(eventFired, "Core did not fire output event");
        }

        /// <summary>
        /// A test for OnNavigate
        /// </summary>
        [TestMethod]
        public void OnNavigateNoDocumentTest()
        {
            var mockDte = new Mock<DTE>(MockBehavior.Strict);
            this.mockServiceProvider.Setup(sp => sp.GetService(typeof(EnvDTE.DTE))).Returns(mockDte.Object);
            this.mockServiceProvider.Setup(sp => sp.GetService(typeof(SVsSolutionBuildManager))).Returns(new MockSolutionBuildManager());
            AnalysisHelper analysisHelper = this.SetCoreNoUI();
            bool eventFired = false;
            var styleCopCore = (StyleCopCore)typeof(AnalysisHelper)
                .GetField("core", BindingFlags.Instance | BindingFlags.NonPublic)
                .GetValue(analysisHelper);
            styleCopCore.OutputGenerated += (sender, args) => { eventFired = true; };

            // ProjectUtilities.Initialize(this.mockServiceProvider.Instance);

            // Does nothing - included for code coverage and to catch it if it starts doing something unexpectedtly
            this.taskUnderTestShell.Document = null;
            typeof(ViolationTask).GetMethod("OnNavigate", BindingFlags.Instance | BindingFlags.NonPublic)
                .Invoke(this.taskUnderTest, new object[] { EventArgs.Empty });

            Assert.IsTrue(eventFired, "Core did not fire output event");

            // Reset Factory.ServiceProvider.
            typeof(ProjectUtilities).GetField("serviceProvider", BindingFlags.Static | BindingFlags.NonPublic)
                .SetValue(null, null);
        }

        /// <summary>
        /// A test for OnNavigate
        /// </summary>
        [TestMethod]
        public void OnNavigateToDocInProjectTest()
        {
            var mockDocumentEnumerator = new Mock<IEnumerator>(MockBehavior.Strict);
            var mockDte = new Mock<DTE>(MockBehavior.Strict);
            var mockDocuments = new Mock<Documents>(MockBehavior.Strict);
            var mockDocument = new Mock<Document>(MockBehavior.Strict);
            var mockActiveDocument = new Mock<Document>(MockBehavior.Strict);
            var mockTextSelection = new Mock<TextSelection>(MockBehavior.Strict);
            var mockVirtualPoint = new Mock<VirtualPoint>(MockBehavior.Strict);

            this.SetupProjectUtilities(mockDocumentEnumerator, mockDte, mockDocuments, mockDocument, mockActiveDocument);

            var mockDocumentSequence = new MockSequence();
            mockDocument.SetupGet(doc => doc.FullName).Returns(this.violation.File);
            mockDocument.InSequence(mockDocumentSequence).Setup(doc => doc.Activate());
            mockDocument.InSequence(mockDocumentSequence).SetupGet(doc => doc.DTE)
                .Returns((Func<DTE>)delegate { return (EnvDTE.DTE)mockDte.Object; });

            mockActiveDocument.SetupGet(doc => doc.Selection).Returns(mockTextSelection.Object);

            var mockTextSelectionSequence = new MockSequence();
            mockTextSelection.InSequence(mockTextSelectionSequence)
                .Setup(sel => sel.GotoLine(this.violation.LineNumber, true));
            mockTextSelection.InSequence(mockTextSelectionSequence)
                .SetupGet(sel => sel.ActivePoint).Returns(mockVirtualPoint.Object);

            mockVirtualPoint.Setup(vp => vp.TryToShow(EnvDTE.vsPaneShowHow.vsPaneShowCentered, 0)).Returns(false);

            this.mockServiceProvider.Setup(sp => sp.GetService(typeof(EnvDTE.DTE))).Returns(mockDte.Object);
            typeof(ProjectUtilities).GetField("serviceProvider", BindingFlags.Static | BindingFlags.NonPublic)
                .SetValue(null, this.mockServiceProvider.Object);

            // Execute
            typeof(ViolationTask).GetMethod("OnNavigate", BindingFlags.Instance | BindingFlags.NonPublic)
                .Invoke(this.taskUnderTest, new object[] { EventArgs.Empty });

            // Verify the required methods are called to show the violation
            mockTextSelection.VerifyAll();
            mockVirtualPoint.VerifyAll();
            mockDocument.VerifyAll();
        }

        /// <summary>
        /// A test for OnNavigate
        /// </summary>
        [TestMethod]
        public void OnNavigateToDocNotInProjectTest()
        {
            var mockDocumentEnumerator = new Mock<IEnumerator>(MockBehavior.Strict);
            var mockDte = new Mock<DTE>(MockBehavior.Strict);
            var mockDocuments = new Mock<Documents>(MockBehavior.Strict);
            var mockDocument = new Mock<Document>(MockBehavior.Strict);
            var mockActiveDocument = new Mock<Document>(MockBehavior.Strict);
            var mockTextSelection = new Mock<TextSelection>(MockBehavior.Strict);

            this.SetupProjectUtilities(mockDocumentEnumerator, mockDte, mockDocuments, mockDocument, mockActiveDocument);
            var mockSecondDocument = new Mock<Document>(MockBehavior.Strict);
            var mockDocumentEnumeratorSequence = new MockSequence();
            mockDocumentEnumerator.InSequence(mockDocumentEnumeratorSequence).Setup(docs => docs.MoveNext())
                .Returns(true);
            mockDocumentEnumerator.InSequence(mockDocumentEnumeratorSequence).SetupGet(docs => docs.Current)
                .Returns(mockSecondDocument.Object);
            mockDocumentEnumerator.InSequence(mockDocumentEnumeratorSequence).Setup(docs => docs.MoveNext())
                .Returns(false);

            mockSecondDocument.SetupGet(doc => doc.FullName).Returns("DummyFile.txt");

            AnalysisHelper analysisHelper = this.SetCoreNoUI();
            bool eventFired = false;
            var styleCopCore = (StyleCopCore)typeof(AnalysisHelper)
                .GetField("core", BindingFlags.Instance | BindingFlags.NonPublic)
                .GetValue(analysisHelper);
            styleCopCore.OutputGenerated += (sender, args) => { eventFired = true; };

            mockActiveDocument.SetupGet(doc => doc.Selection).Returns(mockTextSelection.Object);

            var mockTextSelectionSequence = new MockSequence();
            mockTextSelection.InSequence(mockTextSelectionSequence).Setup(sel => sel.GotoLine(this.violation.LineNumber, true));

            this.mockServiceProvider.Setup(sp => sp.GetService(typeof(EnvDTE.DTE))).Returns(mockDte.Object);
            typeof(ProjectUtilities).GetField("serviceProvider", BindingFlags.Static | BindingFlags.NonPublic)
                .SetValue(null, this.mockServiceProvider.Object);

            // Execute
            typeof(ViolationTask).GetMethod("OnNavigate", BindingFlags.Instance | BindingFlags.NonPublic)
                .Invoke(this.taskUnderTest, new object[] { EventArgs.Empty });

            // Verify the required methods are called to show the violation
            mockTextSelection.VerifyAll();
            mockDocument.VerifyAll();

            Assert.IsTrue(eventFired, "Core did not fire output event");
        }

        /// <summary>
        /// A test for ViolationTask Constructor
        /// </summary>
        [TestMethod]
        public void ViolationTaskConstructorTest()
        {
            Assert.IsNotNull(typeof(ViolationTask)
                .GetField("violation", BindingFlags.Instance | BindingFlags.NonPublic)
                .GetValue(this.taskUnderTest),
                "Constructor didn't set internal field 'violation'");
            Assert.AreEqual(
                this.violation.File,
                this.taskUnderTestShell.Document,
                "Constructor failed to set up property Document");
            Assert.AreEqual(
                this.violation.LineNumber,
                this.taskUnderTestShell.Line + 1,
                "Constructor failed to set up property Line");
            Assert.AreEqual(
                this.violation.Description,
                this.taskUnderTestShell.Text,
                "Constructor failed to set up property Text");
            Assert.AreEqual(0, this.taskUnderTestShell.Column + 1, "Constructor failed to set up property Column");
        }

        #endregion

        #region Methods

        private static ViolationInfo CreateDummyViolationInfo()
        {
            ViolationInfo violation = new ViolationInfo() { File = @"c:\MyFile.cs", LineNumber = 666, Description = "My Description" };

            return violation;
        }

        private AnalysisHelper SetCoreNoUI()
        {
            return (AnalysisHelper)typeof(StyleCopVSPackage)
                .GetProperty("Helper", BindingFlags.Instance | BindingFlags.NonPublic)
                .GetValue(this.package, null);
        }

        private void SetupProjectUtilities(
            Mock<IEnumerator> mockDocumentEnumerator,
            Mock<DTE> mockDte,
            Mock<Documents> mockDocuments,
            Mock<Document> mockDocument,
            Mock<Document> mockActiveDocument)
        {
            var mockSolution = new Mock<Solution>(MockBehavior.Strict);
            var mockProjects = new Mock<Projects>(MockBehavior.Strict);
            var mockProject = new Mock<Project>(MockBehavior.Strict);
            var mockProjectEnumerator = new Mock<IEnumerator>(MockBehavior.Strict);
            
            mockDte.SetupGet(dte => dte.Solution).Returns(mockSolution.Object);
            mockDte.SetupGet(dte => dte.Documents).Returns(mockDocuments.Object);
            mockDte.SetupGet(dte => dte.ActiveDocument).Returns(mockActiveDocument.Object);

            mockSolution.SetupGet(sol => sol.Projects).Returns(mockProjects.Object);
            mockProjects.Setup(e => e.GetEnumerator()).Returns(mockProjectEnumerator.Object);

            var mockProjectEnumeratorSequence = new MockSequence();
            mockProjectEnumerator.InSequence(mockProjectEnumeratorSequence)
                .Setup(en => en.MoveNext()).Returns(true);
            mockProjectEnumerator.InSequence(mockProjectEnumeratorSequence)
                .SetupGet(en => en.Current).Returns(mockProject.Object);
            mockProjectEnumerator.InSequence(mockProjectEnumeratorSequence)
                .Setup(en => en.MoveNext()).Returns(false);

            mockProject.SetupGet(p => p.Kind).Returns(EnvDTE.Constants.vsProjectKindMisc);
            mockProject.SetupGet(p => p.ProjectItems).Returns((Func<ProjectItems>)delegate { return null; });

            mockDocuments.Setup(docs => docs.GetEnumerator()).Returns(mockDocumentEnumerator.Object);

            var mockDocumentEnumeratorSequence = new MockSequence();
            mockDocumentEnumerator.InSequence(mockDocumentEnumeratorSequence)
                .Setup(docs => docs.MoveNext()).Returns(true);
            mockDocumentEnumerator.InSequence(mockDocumentEnumeratorSequence)
                .SetupGet(docs => docs.Current).Returns(mockDocument.Object);
            mockDocumentEnumerator.InSequence(mockDocumentEnumeratorSequence)
                .Setup(docs => docs.MoveNext()).Returns(false);
        }

        #endregion
    }
}