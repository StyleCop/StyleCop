namespace CSharpParserTest
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using StyleCop.Test;
    using System.IO;

    [TestClass]
    public class ParserTests
    {
        private static TestContext TestContext;
        private static string ProjectRoot = Environment.ExpandEnvironmentVariables("%projectroot%");
        private static string TestRoot = Path.Combine(ProjectRoot, @"Test\AddIns\CSharp\Parser\CSharpParserTest");
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
        public void CsParserTestAssorted()
        {
            Console.ReadLine();
            this.RunTest("Assorted");
        }

        [TestMethod]
        public void CsParserTestElements()
        {
            this.RunTest("Elements");
        }

        [TestMethod]
        public void CsParserTestExtensionMethods()
        {
            this.RunTest("ExtensionMethods");
        }

        [TestMethod]
        public void CsParserTestFileLists()
        {
            this.RunTest("FileLists");
        }

        [TestMethod]
        public void CsParserTestGeneratedCode()
        {
            this.RunTest("GeneratedCode");
        }

        [TestMethod]
        public void CsParserTestImplicitlyTypedArrays()
        {
            this.RunTest("ImplicitlyTypedArrays");
        }

        [TestMethod]
        public void CsParserTestLambdaExpressions()
        {
            this.RunTest("LambdaExpressions");
        }

        [TestMethod]
        public void CsParserTestNamedArguments()
        {
            this.RunTest("NamedArguments");
        }

        [TestMethod]
        public void CsParserTestQueryExpressions()
        {
            this.RunTest("QueryExpressions");
        }

        private void RunTest(string testName)
        {
            Assert.IsTrue(StyleCopTestRunner.Run(testName, TestRoot, TestContext.DeploymentDirectory, TestContext.TestResultsDirectory, false, Path.Combine(TestBin, "StyleCop.CSharp.Rules.dll")), TestContext.TestResultsDirectory);
        }
    }
}
