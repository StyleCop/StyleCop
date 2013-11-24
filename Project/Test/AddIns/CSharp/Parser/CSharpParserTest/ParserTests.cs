// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParserTests.cs" company="">
//   
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
//   The parser tests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CSharpParserTest
{
    using System;
    using System.IO;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using StyleCop.Test;

    /// <summary>
    /// The parser tests.
    /// </summary>
    [TestClass]
    public class ParserTests
    {
        #region Constants and Fields

        /// <summary>
        /// The project root.
        /// </summary>
        private static string ProjectRoot = Environment.ExpandEnvironmentVariables("%projectroot%");

        /// <summary>
        /// The test bin.
        /// </summary>
        private static string TestBin = Path.Combine(ProjectRoot, @"Test\TestBin");

        /// <summary>
        /// The test context.
        /// </summary>
        private static TestContext TestContext;

        /// <summary>
        /// The test root.
        /// </summary>
        private static string TestRoot = Path.Combine(ProjectRoot, @"Test\AddIns\CSharp\Parser\CSharpParserTest");

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
        /// The cs parser test assorted.
        /// </summary>
        [TestMethod]
        public void CsParserTestAssorted()
        {
            //Console.ReadLine();
            this.RunTest("Assorted");
        }

        /// <summary>
        /// The cs parser test elements.
        /// </summary>
        [TestMethod]
        public void CsParserTestElements()
        {
            this.RunTest("Elements");
        }

        /// <summary>
        /// The cs parser test extension methods.
        /// </summary>
        [TestMethod]
        public void CsParserTestExtensionMethods()
        {
            this.RunTest("ExtensionMethods");
        }

        /// <summary>
        /// The cs parser test file lists.
        /// </summary>
        [TestMethod]
        public void CsParserTestFileLists()
        {
            this.RunTest("FileLists");
        }

        /// <summary>
        /// The cs parser test generated code.
        /// </summary>
        [TestMethod]
        public void CsParserTestGeneratedCode()
        {
            this.RunTest("GeneratedCode");
        }

        /// <summary>
        /// The cs parser test implicitly typed arrays.
        /// </summary>
        [TestMethod]
        public void CsParserTestImplicitlyTypedArrays()
        {
            this.RunTest("ImplicitlyTypedArrays");
        }

        /// <summary>
        /// The cs parser test lambda expressions.
        /// </summary>
        [TestMethod]
        public void CsParserTestLambdaExpressions()
        {
            this.RunTest("LambdaExpressions");
        }

        /// <summary>
        /// The cs parser test named arguments.
        /// </summary>
        [TestMethod]
        public void CsParserTestNamedArguments()
        {
            this.RunTest("NamedArguments");
        }

        /// <summary>
        /// The cs parser test query expressions.
        /// </summary>
        [TestMethod]
        public void CsParserTestQueryExpressions()
        {
            this.RunTest("QueryExpressions");
        }

        #endregion

        #region Methods

        /// <summary>
        /// The run test.
        /// </summary>
        /// <param name="testName">
        /// The test name.
        /// </param>
        private void RunTest(string testName)
        {
            Assert.IsTrue(
                StyleCopTestRunner.Run(testName, TestRoot, TestContext.DeploymentDirectory, TestContext.TestResultsDirectory, false, Path.Combine(TestBin, "StyleCop.CSharp.Rules.dll")), 
                TestContext.TestResultsDirectory);
        }

        #endregion
    }
}