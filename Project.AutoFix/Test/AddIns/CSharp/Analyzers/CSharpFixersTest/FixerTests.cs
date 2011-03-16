namespace CSharpFixersTest
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using StyleCop.Test;
    using System.IO;

    [TestClass]
    public class FixerTests
    {
        private static TestContext TestContext;
        private static string ProjectRoot = Environment.ExpandEnvironmentVariables("%projectroot%");
        private static string TestRoot = Path.Combine(ProjectRoot, @"Test\AddIns\CSharp\Analyzers\CSharpFixersTest");

        [ClassInitialize]
        public static void MyClassInitialize(TestContext testContext)
        {
            TestContext = testContext;

            if (!Directory.Exists(TestContext.TestResultsDirectory))
            {
                Directory.CreateDirectory(TestContext.TestResultsDirectory);
            }
        }

        [TestMethod]
        public void CsFixerBuiltInTypesTest()
        {
            this.RunTest("BuiltInTypes");
        }

        [TestMethod]
        public void CsFixerClassMembersTest()
        {
            this.RunTest("ClassMembers");
        }

        [TestMethod]
        public void CsFixerFileHeadersTest()
        {
            this.RunTest("FileHeaders");
        }

        [TestMethod]
        public void CsFixerEmptyStringsTest()
        {
            this.RunTest("EmptyStrings");
        }

        private void RunTest(string testName)
        {
            Assert.IsTrue(StyleCopTestRunner.Run(testName, TestRoot, TestContext.DeploymentDirectory, TestContext.TestResultsDirectory, true), TestContext.TestResultsDirectory);
        }
    }
}
