//-----------------------------------------------------------------------
// <copyright file="ViolationTaskTest.cs" company="Microsoft">
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
    using System.Collections;
    using Microsoft.StyleCop;
    using Microsoft.StyleCop.VisualStudio;
    using Microsoft.VisualStudio.Shell;
    using Microsoft.VisualStudio.Shell.Interop;
    using Microsoft.VisualStudio.TestTools.MockObjects;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using VSPackageUnitTest.Mocks;

    /// <summary>
    ///This is a test class for ViolationTaskTest and is intended
    ///to contain all ViolationTaskTest Unit Tests
    ///</summary>
    [TestClass()]
    [DeploymentItem("Microsoft.StyleCop.VSPackage.dll")]
    [DeploymentItem("Microsoft.StyleCop.VSPackage_Accessor.dll")]
    [DeploymentItem("Microsoft.StyleCop_Accessor.dll")]
    [DeploymentItem("Microsoft.VisualStudio.Shell_Accessor.dll")]
    public class ViolationTaskTest
    {
        private Mock<IServiceProvider> mockServiceProvider;
        private ViolationInfo_Accessor violation;
        private ViolationTask_Accessor taskUnderTest;
        private ErrorTask_Accessor taskUnderTestShell;
        private StyleCopVSPackage package;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext { get; set; }

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


        /// <summary>
        /// Use TestInitialize to run code before running each test 
        /// </summary>
        [TestInitialize()]
        public void MyTestInitialize()
        {
            // Creating a package wil lset the facoctory service provider.
            this.package = new StyleCopVSPackage();

            this.mockServiceProvider = new Mock<IServiceProvider>();
            this.violation = CreateDummyViolationInfo();

            StyleCopVSPackage_Accessor.AttachShadow(this.package).Core.DisplayUI = false;
            this.taskUnderTest = new ViolationTask_Accessor(this.package, violation);
            this.taskUnderTestShell = ErrorTask_Accessor.AttachShadow(this.taskUnderTest.Target);
        }

        /// <summary>
        /// Use TestCleanup to run code after each test has run
        /// </summary>
        [TestCleanup()]
        public void MyTestCleanup()
        {
            this.taskUnderTest = null;
            this.taskUnderTestShell = null;
            this.taskUnderTest = null;
        }

        #endregion

        private static ViolationInfo_Accessor CreateDummyViolationInfo()
        {
            ViolationInfo_Accessor violation = new ViolationInfo_Accessor()
            {
                File = @"c:\MyFile.cs",
                LineNumber = 666,
                Description = "My Description"
            };

            return violation;
        }

        /// <summary>
        ///A test for ViolationTask Constructor
        ///</summary>
        [TestMethod()]
        public void ViolationTaskConstructorTest()
        {
            Assert.IsNotNull(this.taskUnderTest.violation, "Constructor didn't set internal field 'violation'");
            Assert.AreEqual(this.violation.File, this.taskUnderTestShell.Document, "Constructor failed to set up property Document");
            Assert.AreEqual(this.violation.LineNumber, this.taskUnderTestShell.Line + 1, "Constructor failed to set up property Line");
            Assert.AreEqual(this.violation.Description, this.taskUnderTestShell.Text, "Constructor failed to set up property Text");
            Assert.AreEqual(0, this.taskUnderTestShell.Column, "Constructor failed to set up property Column");
            Assert.AreEqual(TaskErrorCategory.Warning, this.taskUnderTestShell.ErrorCategory, "Constructor failed to set up property ErrorCategory");
        }

        /// <summary>
        ///A test for OnNavigate
        ///</summary>
        [TestMethod()]
        public void OnNavigateToDocInProjectTest()
        {
            var mockDocumentEnumerator = new SequenceMock<IEnumerator>();
            var mockDte = new Mock<EnvDTE.DTE>();
            var mockDocuments = new Mock<EnvDTE.Documents>();
            var mockDocument = new SequenceMock<EnvDTE.Document>();
            var mockActiveDocument = new Mock<EnvDTE.Document>();
            var mockTextSelection = new SequenceMock<EnvDTE.TextSelection>();
            var mockVirtualPoint = new SequenceMock<EnvDTE.VirtualPoint>();

            this.SetupProjectUtilities(mockDocumentEnumerator, mockDte, mockDocuments, mockDocument, mockActiveDocument, this.violation.File);

            mockDocument.AddExpectationExpr(doc => doc.Activate());
            mockDocument.AddExpectationExpr(doc => doc.DTE, (Func<EnvDTE.DTE>)delegate { return (EnvDTE.DTE)mockDte.Instance; });
            
            mockActiveDocument.ImplementExpr(doc => doc.Selection, mockTextSelection.Instance);

            mockTextSelection.ImplementExpr(sel => sel.GotoLine(this.violation.LineNumber, true));
            mockTextSelection.ImplementExpr(sel => sel.ActivePoint, mockVirtualPoint.Instance);

            mockVirtualPoint.ImplementExpr(vp => vp.TryToShow(EnvDTE.vsPaneShowHow.vsPaneShowCentered, 0));

            this.mockServiceProvider.ImplementExpr(sp => sp.GetService(typeof(EnvDTE.DTE)), mockDte.Instance);
            ProjectUtilities_Accessor.Initialize(this.mockServiceProvider.Instance);

            // Execute
            this.taskUnderTest.OnNavigate(EventArgs.Empty);

            // Verify the required methods are called to show the violation
            mockTextSelection.Verify();
            mockVirtualPoint.Verify();
            mockDocument.Verify();
        }

        private void SetupProjectUtilities(SequenceMock<IEnumerator> mockDocumentEnumerator, Mock<EnvDTE.DTE> mockDte, Mock<EnvDTE.Documents> mockDocuments, SequenceMock<EnvDTE.Document> mockDocument, Mock<EnvDTE.Document> mockActiveDocument, string fileName)
        {
            var mockSolution = new Mock<EnvDTE.Solution>();
            var mockProjects = new Mock<EnvDTE.Projects>();
            var mockProject = new Mock<EnvDTE.Project>();
            var mockProjectEnumerator = new SequenceMock<IEnumerator>();

            mockDte.ImplementExpr(dte => dte.Solution, mockSolution.Instance);
            mockDte.ImplementExpr(dte => dte.Documents, mockDocuments.Instance);
            mockDte.ImplementExpr(dte => dte.ActiveDocument, mockActiveDocument.Instance);

            mockSolution.ImplementExpr(sol => sol.Projects, mockProjects.Instance);
            mockProjects.ImplementExpr(e => e.GetEnumerator(), mockProjectEnumerator.Instance);

            mockProjectEnumerator.AddExpectationExpr(en => en.MoveNext(), true);
            mockProjectEnumerator.AddExpectationExpr(en => en.Current, mockProject.Instance);
            mockProjectEnumerator.AddExpectationExpr(en => en.MoveNext(), false);

            mockProject.ImplementExpr(p => p.Kind, EnvDTE.Constants.vsProjectKindMisc);
            mockProject.ImplementExpr(p => p.ProjectItems, (Func<EnvDTE.ProjectItems>)delegate { return null; });

            mockDocuments.ImplementExpr(docs => docs.GetEnumerator(), mockDocumentEnumerator.Instance);

            mockDocumentEnumerator.AddExpectationExpr(docs => docs.MoveNext(), true);
            mockDocumentEnumerator.AddExpectationExpr(docs => docs.Current, mockDocument.Instance);
            mockDocumentEnumerator.AddExpectationExpr(docs => docs.MoveNext(), false);

            mockDocument.AddExpectationExpr(doc => doc.FullName, fileName);
        }

        /// <summary>
        ///A test for OnNavigate
        ///</summary>
        [TestMethod()]
        public void OnNavigateToDocNotInProjectTest()
        {
            var mockDocumentEnumerator = new SequenceMock<IEnumerator>();
            var mockDte = new Mock<EnvDTE.DTE>();
            var mockDocuments = new Mock<EnvDTE.Documents>();
            var mockDocument = new SequenceMock<EnvDTE.Document>();
            var mockActiveDocument = new Mock<EnvDTE.Document>();
            var mockTextSelection = new SequenceMock<EnvDTE.TextSelection>();
            var mockVirtualPoint = new SequenceMock<EnvDTE.VirtualPoint>();

            this.SetupProjectUtilities(mockDocumentEnumerator, mockDte, mockDocuments, mockDocument, mockActiveDocument, "DummyFile.txt");
            var mockSecondDocument = new SequenceMock<EnvDTE.Document>();
            mockDocumentEnumerator.AddExpectationExpr(docs => docs.MoveNext(), true);
            mockDocumentEnumerator.AddExpectationExpr(docs => docs.Current, mockSecondDocument.Instance);
            mockDocumentEnumerator.AddExpectationExpr(docs => docs.MoveNext(), false);

            mockSecondDocument.AddExpectationExpr(doc => doc.FullName, "DummyFile.txt");

            AnalysisHelper_Accessor analysisHelper = SetCoreNoUI();
            bool eventFired = false;
            analysisHelper.core.OutputGenerated += (sender, args) => { eventFired = true; };

            mockActiveDocument.ImplementExpr(doc => doc.Selection, mockTextSelection.Instance);

            mockTextSelection.ImplementExpr(sel => sel.GotoLine(this.violation.LineNumber, true));
            mockTextSelection.ImplementExpr(sel => sel.ActivePoint, mockVirtualPoint.Instance);

            mockVirtualPoint.ImplementExpr(vp => vp.TryToShow(EnvDTE.vsPaneShowHow.vsPaneShowCentered, 0));

            this.mockServiceProvider.ImplementExpr(sp => sp.GetService(typeof(EnvDTE.DTE)), mockDte.Instance);
            ProjectUtilities_Accessor.Initialize(this.mockServiceProvider.Instance);

            // Execute
            this.taskUnderTest.OnNavigate(EventArgs.Empty);

            // Verify the required methods are called to show the violation
            mockTextSelection.Verify();
            mockVirtualPoint.Verify();
            mockDocument.Verify();

            Assert.IsTrue(eventFired, "Core did not fire output event");
        }

        /// <summary>
        ///A test for OnNavigate
        ///</summary>
        [TestMethod()]
        public void OnNavigateNoDocumentTest()
        {
            var mockDte = new Mock<EnvDTE.DTE>();
            this.mockServiceProvider.ImplementExpr(sp => sp.GetService(typeof(EnvDTE.DTE)), mockDte.Instance);
            this.mockServiceProvider.ImplementExpr(sp => sp.GetService(typeof(SVsSolutionBuildManager)), new MockSolutionBuildManager());
            AnalysisHelper_Accessor analysisHelper = SetCoreNoUI();
            bool eventFired = false;
            analysisHelper.core.OutputGenerated += (sender, args) => { eventFired = true; };

            ProjectUtilities_Accessor.Initialize(this.mockServiceProvider.Instance);

            // Does nothing - included for code coverage and to catch it if it starts doing something unexpectedtly
            this.taskUnderTestShell.Document = null;
            this.taskUnderTest.OnNavigate(EventArgs.Empty);

            Assert.IsTrue(eventFired, "Core did not fire output event");

            // Reset Factory.ServiceProvider.
            ProjectUtilities_Accessor.serviceProvider = null;
        }

        private AnalysisHelper_Accessor SetCoreNoUI()
        {
            StyleCopVSPackage_Accessor packageAccessor = StyleCopVSPackage_Accessor.AttachShadow(this.package);
            return packageAccessor.Helper;
        }

        /// <summary>
        ///A test for OnNavigate
        ///</summary>
        [TestMethod()]
        public void OnNavigateEmptyDocumentTest()
        {
            bool eventFired = false;
            var mockDte = new Mock<EnvDTE.DTE>();
            this.mockServiceProvider.ImplementExpr(sp => sp.GetService(typeof(EnvDTE.DTE)), mockDte.Instance);
            this.mockServiceProvider.ImplementExpr(sp => sp.GetService(typeof(SVsSolutionBuildManager)), new MockSolutionBuildManager());
            AnalysisHelper_Accessor analysisHelper = SetCoreNoUI();
            analysisHelper.core.OutputGenerated += (sender, args) => { eventFired = true; };

            ProjectUtilities_Accessor.Initialize(this.mockServiceProvider.Instance);

            // Does nothing - included for code coverage and to catch it if it starts doing something unexpectedtly
            this.taskUnderTestShell.Document = string.Empty;
            this.taskUnderTest.OnNavigate(EventArgs.Empty);

            Assert.IsTrue(eventFired, "Core did not fire output event");
        }
    }
}
