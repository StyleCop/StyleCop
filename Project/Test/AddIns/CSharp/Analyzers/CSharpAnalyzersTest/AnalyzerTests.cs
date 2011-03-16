namespace CSharpAnalyzersTest
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    //using StyleCop.Test;
    using System.IO;

    using StyleCop.Test;

    [TestClass]
    public class AnalyzerTests
    {
        private static TestContext TestContext;
        private static string ProjectRoot = Environment.ExpandEnvironmentVariables("%projectroot%");
        private static string TestRoot = Path.Combine(ProjectRoot, @"Test\AddIns\CSharp\Analyzers\CSharpAnalyzersTest");
        private static string TestBin = Path.Combine(ProjectRoot, @"Test\TestBin");

        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            TestContext = testContext;

            if (!Directory.Exists(TestContext.TestResultsDirectory))
            {
                Directory.CreateDirectory(TestContext.TestResultsDirectory);
            }
        }

        [TestMethod]
        public void CsAnalyzerAccessModifiersTest()
        {
            this.RunTest("AccessModifiers");
        }

        [TestMethod]
        public void CsAnalyzerBuiltInTypesTest()
        {
            this.RunTest("BuiltInTypes");
        }

        [TestMethod]
        public void CsAnalyzerClassMembersTest()
        {
            this.RunTest("ClassMembers");
        }

        [TestMethod]
        public void CsAnalyzerCommentsTest()
        {
            this.RunTest("Comments");
        }

        [TestMethod]
        public void CsAnalyzerCurlyBracketsTest()
        {
            this.RunTest("CurlyBrackets");
        }

        [TestMethod]
        public void CsAnalyzerDebugTextTest()
        {
            this.RunTest("DebugText");
        }

        [TestMethod]
        public void CsAnalyzerDeclarationKeywordOrderTest()
        {
            this.RunTest("DeclarationKeywordOrder");
        }

        [TestMethod]
        public void CsAnalyzerDocumentationTest()
        {
            this.RunTest("Documentation", Path.Combine(TestRoot, @"TestData\Documentation\IncludedDocumentation.xml"));
        }

        [TestMethod]
        public void CsAnalyzerElementOrderTest()
        {
            this.RunTest("ElementOrder");
        }

        [TestMethod]
        public void CsAnalyzerEmptyStringsTest()
        {
            this.RunTest("EmptyStrings");
        }

        [TestMethod]
        public void CsAnalyzerFileContentsTest()
        {
            this.RunTest("FileContents");
        }

        [TestMethod]
        public void CsAnalyzerFileHeadersTest()
        {
            this.RunTest("FileHeaders");
        }

        [TestMethod]
        public void CsAnalyzerLineSpacingTest()
        {
            this.RunTest("LineSpacing");
        }

        [TestMethod]
        public void CsAnalyzerMethodParametersTest()
        {
            this.RunTest("MethodParameters");
        }

        [TestMethod]
        public void CsAnalyzerNamingTest()
        {
            this.RunTest("Naming");
        }

        [TestMethod]
        public void CsAnalyzerParenthesisTest()
        {
            this.RunTest("Parenthesis");
        }

        [TestMethod]
        public void CsAnalyzerQueryClausesTest()
        {
            this.RunTest("QueryClauses");
        }

        [TestMethod]
        public void CsAnalyzerRegionsTest()
        {
            this.RunTest("Regions");
        }

        [TestMethod]
        public void CsAnalyzerSpacingTest()
        {
            this.RunTest("Spacing");
        }

        [TestMethod]
        public void CsAnalyzerStatementsTest()
        {
            this.RunTest("Statements");
        }

        [TestMethod]
        public void CsAnalyzerTabsTest()
        {
            this.RunTest("Tabs");
        }

        [TestMethod]
        public void CsAnalyzerUnnecessaryCodeTest()
        {
            this.RunTest("UnnecessaryCode");
        }

        private void RunTest(string testName, params string[] testfilesToCopy)
        {
            string[] a3 = new string[testfilesToCopy.Length + 2];
            a3[0] = Path.Combine(TestBin, "StyleCop.CSharp.dll");
            a3[1] = Path.Combine(TestBin, "StyleCop.CSharp.Rules.dll");
            testfilesToCopy.CopyTo(a3, 2);
            

            bool result = StyleCopTestRunner.Run(
                testName, 
                TestRoot, 
                TestContext.DeploymentDirectory, 
                TestContext.TestResultsDirectory, 
                false, a3
                );
            
            Assert.IsTrue(result, TestContext.TestResultsDirectory);
        }
    }
}
