// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AnalyzerTests.cs" company="">
//   
// </copyright>
// <summary>
//   The analyzer tests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CSharpAnalyzersTest
{
    using System;
    using System.IO;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using StyleCop.Test;

    /// <summary>
    /// The analyzer tests.
    /// </summary>
    [TestClass]
    public class AnalyzerTests
    {
        #region Constants and Fields

        /// <summary>
        ///   The project root.
        /// </summary>
        private static string ProjectRoot = Environment.ExpandEnvironmentVariables("%projectroot%");

        /// <summary>
        ///   The test bin.
        /// </summary>
        private static string TestBin = Path.Combine(ProjectRoot, @"Test\TestBin");

        /// <summary>
        ///   The test context.
        /// </summary>
        private static TestContext TestContext;

        /// <summary>
        ///   The test root.
        /// </summary>
        private static string TestRoot = Path.Combine(ProjectRoot, @"Test\AddIns\CSharp\Analyzers\CSharpAnalyzersTest");

        #endregion

        #region Public Methods

        /// <summary>
        /// The my class initialize.
        /// </summary>
        /// <param name="testContext">
        /// The test context.
        /// </param>
        [ClassInitialize]
        public static void MyClassInitialize(TestContext testContext)
        {
            TestContext = testContext;

            if (!Directory.Exists(TestContext.TestResultsDirectory))
            {
                Directory.CreateDirectory(TestContext.TestResultsDirectory);
            }
        }

        /// <summary>
        /// The cs analyzer access modifiers test.
        /// </summary>
        [TestMethod]
        public void CsAnalyzerAccessModifiersTest()
        {
            this.RunTest("AccessModifiers");
        }

        /// <summary>
        /// The cs analyzer built in types test.
        /// </summary>
        [TestMethod]
        public void CsAnalyzerBuiltInTypesTest()
        {
            this.RunTest("BuiltInTypes");
        }

        /// <summary>
        /// The cs analyzer class members test.
        /// </summary>
        [TestMethod]
        public void CsAnalyzerClassMembersTest()
        {
            this.RunTest("ClassMembers");
        }

        /// <summary>
        /// The cs analyzer comments test.
        /// </summary>
        [TestMethod]
        public void CsAnalyzerCommentsTest()
        {
            this.RunTest("Comments");
        }

        /// <summary>
        /// The cs analyzer curly brackets test.
        /// </summary>
        [TestMethod]
        public void CsAnalyzerCurlyBracketsTest()
        {
            this.RunTest("CurlyBrackets");
        }

        /// <summary>
        /// The cs analyzer debug text test.
        /// </summary>
        [TestMethod]
        public void CsAnalyzerDebugTextTest()
        {
            this.RunTest("DebugText");
        }

        /// <summary>
        /// The cs analyzer declaration keyword order test.
        /// </summary>
        [TestMethod]
        public void CsAnalyzerDeclarationKeywordOrderTest()
        {
            this.RunTest("DeclarationKeywordOrder");
        }

        /// <summary>
        /// The cs analyzer documentation test.
        /// </summary>
        [TestMethod]
        public void CsAnalyzerDocumentationTest()
        {
            this.RunTest("Documentation", Path.Combine(TestRoot, @"TestData\Documentation\IncludedDocumentation.xml"));
        }

        /// <summary>
        /// The cs analyzer element order test.
        /// </summary>
        [TestMethod]
        public void CsAnalyzerElementOrderTest()
        {
            this.RunTest("ElementOrder");
        }

        /// <summary>
        /// The cs analyzer empty strings test.
        /// </summary>
        [TestMethod]
        public void CsAnalyzerEmptyStringsTest()
        {
            this.RunTest("EmptyStrings");
        }

        /// <summary>
        /// The cs analyzer file contents test.
        /// </summary>
        [TestMethod]
        public void CsAnalyzerFileContentsTest()
        {
            this.RunTest("FileContents");
        }

        /// <summary>
        /// The cs analyzer file headers test.
        /// </summary>
        [TestMethod]
        public void CsAnalyzerFileHeadersTest()
        {
            this.RunTest("FileHeaders");
        }

        /// <summary>
        /// The cs analyzer line spacing test.
        /// </summary>
        [TestMethod]
        public void CsAnalyzerLineSpacingTest()
        {
            this.RunTest("LineSpacing");
        }

        /// <summary>
        /// The cs analyzer method parameters test.
        /// </summary>
        [TestMethod]
        public void CsAnalyzerMethodParametersTest()
        {
            this.RunTest("MethodParameters");
        }

        /// <summary>
        /// The cs analyzer naming test.
        /// </summary>
        [TestMethod]
        public void CsAnalyzerNamingTest()
        {
            this.RunTest("Naming");
        }

        /// <summary>
        /// The cs analyzer parenthesis test.
        /// </summary>
        [TestMethod]
        public void CsAnalyzerParenthesisTest()
        {
            this.RunTest("Parenthesis");
        }

        /// <summary>
        /// The cs analyzer query clauses test.
        /// </summary>
        [TestMethod]
        public void CsAnalyzerQueryClausesTest()
        {
            this.RunTest("QueryClauses");
        }

        /// <summary>
        /// The cs analyzer regions test.
        /// </summary>
        [TestMethod]
        public void CsAnalyzerRegionsTest()
        {
            this.RunTest("Regions");
        }

        /// <summary>
        /// The cs analyzer spacing test.
        /// </summary>
        [TestMethod]
        public void CsAnalyzerSpacingTest()
        {
            this.RunTest("Spacing");
        }

        /// <summary>
        /// The cs analyzer statements test.
        /// </summary>
        [TestMethod]
        public void CsAnalyzerStatementsTest()
        {
            this.RunTest("Statements");
        }

        /// <summary>
        /// The cs analyzer tabs test.
        /// </summary>
        [TestMethod]
        public void CsAnalyzerTabsTest()
        {
            this.RunTest("Tabs");
        }

        /// <summary>
        /// The cs analyzer unnecessary code test.
        /// </summary>
        [TestMethod]
        public void CsAnalyzerUnnecessaryCodeTest()
        {
            this.RunTest("UnnecessaryCode");
        }

        #endregion

        #region Methods

        /// <summary>
        /// The run test.
        /// </summary>
        /// <param name="testName">
        /// The test name.
        /// </param>
        /// <param name="testfilesToCopy">
        /// The testfiles to copy.
        /// </param>
        private void RunTest(string testName, params string[] testfilesToCopy)
        {
            string[] files = new string[testfilesToCopy.Length + 2];
            files[0] = Path.Combine(TestBin, "StyleCop.CSharp.dll");
            files[1] = Path.Combine(TestBin, "StyleCop.CSharp.Rules.dll");
            testfilesToCopy.CopyTo(files, 2);

            bool result = StyleCopTestRunner.Run(testName, TestRoot, TestContext.DeploymentDirectory, TestContext.TestResultsDirectory, false, files);

            Assert.IsTrue(result, TestContext.TestResultsDirectory);
        }

        #endregion
    }
}