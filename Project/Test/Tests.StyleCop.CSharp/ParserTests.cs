// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParserTests.cs" company="">
//     MS-PL
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
        /// <summary>
        /// The test context.
        /// </summary>
        private static TestContext testContext;

        /// <summary>
        /// The my class initialize.
        /// </summary>
        /// <param name="context">
        /// The test context.
        /// </param>
        [ClassInitialize]
        public static void MyClassInitialize(TestContext context)
        {
            testContext = context;
        }

        /// <summary>
        /// The cs parser test assorted.
        /// </summary>
        [TestMethod]
        [DeploymentItem("StyleCop.CSharp.Rules.dll")]
        [DeploymentItem("Testing.StyleCop.CSharp.ParserDump.dll")]
        [DeploymentItem("TestData\\Assorted", "Assorted")]
        public void CsParserTestAssorted()
        {
            this.RunTest("Assorted");
        }

        /// <summary>
        /// The cs parser test index initializer.
        /// </summary>
        [TestMethod]
        [DeploymentItem("StyleCop.CSharp.Rules.dll")]
        [DeploymentItem("Testing.StyleCop.CSharp.ParserDump.dll")]
        [DeploymentItem("TestData\\IndexInitializer", "IndexInitializer")]
        public void CsParserTestIndexInitializer()
        {
            this.RunTest("IndexInitializer");
        }

        /// <summary>
        /// The cs parser test elements.
        /// </summary>
        [TestMethod]
        [DeploymentItem("StyleCop.CSharp.Rules.dll")]
        [DeploymentItem("Testing.StyleCop.CSharp.ParserDump.dll")]
        [DeploymentItem("TestData\\Elements", "Elements")]
        public void CsParserTestElements()
        {
            this.RunTest("Elements");
        }

        /// <summary>
        /// The cs parser test extension methods.
        /// </summary>
        [TestMethod]
        [DeploymentItem("StyleCop.CSharp.Rules.dll")]
        [DeploymentItem("Testing.StyleCop.CSharp.ParserDump.dll")]
        [DeploymentItem("TestData\\ExtensionMethods", "ExtensionMethods")]
        public void CsParserTestExtensionMethods()
        {
            this.RunTest("ExtensionMethods");
        }

        /// <summary>
        /// The cs parser test file lists.
        /// </summary>
        [TestMethod]
        [DeploymentItem("StyleCop.CSharp.Rules.dll")]
        [DeploymentItem("Testing.StyleCop.CSharp.ParserDump.dll")]
        [DeploymentItem("TestData\\FileLists", "FileLists")]
        public void CsParserTestFileLists()
        {
            this.RunTest("FileLists");
        }

        /// <summary>
        /// The cs parser test generated code.
        /// </summary>
        [TestMethod]
        [DeploymentItem("StyleCop.CSharp.Rules.dll")]
        [DeploymentItem("Testing.StyleCop.CSharp.ParserDump.dll")]
        [DeploymentItem("TestData\\GeneratedCode", "GeneratedCode")]
        public void CsParserTestGeneratedCode()
        {
            this.RunTest("GeneratedCode");
        }

        /// <summary>
        /// The cs parser test implicitly typed arrays.
        /// </summary>
        [TestMethod]
        [DeploymentItem("StyleCop.CSharp.Rules.dll")]
        [DeploymentItem("Testing.StyleCop.CSharp.ParserDump.dll")]
        [DeploymentItem("TestData\\ImplicitlyTypedArrays", "ImplicitlyTypedArrays")]
        public void CsParserTestImplicitlyTypedArrays()
        {
            this.RunTest("ImplicitlyTypedArrays");
        }

        /// <summary>
        /// The cs parser test lambda expressions.
        /// </summary>
        [TestMethod]
        [DeploymentItem("StyleCop.CSharp.Rules.dll")]
        [DeploymentItem("Testing.StyleCop.CSharp.ParserDump.dll")]
        [DeploymentItem("TestData\\LambdaExpressions", "LambdaExpressions")]
        public void CsParserTestLambdaExpressions()
        {
            this.RunTest("LambdaExpressions");
        }

        /// <summary>
        /// The cs parser test named arguments.
        /// </summary>
        [TestMethod]
        [DeploymentItem("StyleCop.CSharp.Rules.dll")]
        [DeploymentItem("Testing.StyleCop.CSharp.ParserDump.dll")]
        [DeploymentItem("TestData\\NamedArguments", "NamedArguments")]
        public void CsParserTestNamedArguments()
        {
            this.RunTest("NamedArguments");
        }

        /// <summary>
        /// The cs parser test query expressions.
        /// </summary>
        [TestMethod]
        [DeploymentItem("StyleCop.CSharp.Rules.dll")]
        [DeploymentItem("Testing.StyleCop.CSharp.ParserDump.dll")]
        [DeploymentItem("TestData\\QueryExpressions", "QueryExpressions")]
        public void CsParserTestQueryExpressions()
        {
            this.RunTest("QueryExpressions");
        }

        /// <summary>
        /// The cs parser test null condition expressions.
        /// </summary>
        [TestMethod]
        [DeploymentItem("StyleCop.CSharp.Rules.dll")]
        [DeploymentItem("Testing.StyleCop.CSharp.ParserDump.dll")]
        [DeploymentItem("TestData\\NullConditionExpressions", "NullConditionExpressions")]
        public void CsParserTestNullCondtionExpressions()
        {
            this.RunTest("NullConditionExpressions");
        }

        /// <summary>
        /// The cs parser test for cast expression with linq keyword.
        /// </summary>
        [TestMethod]
        [DeploymentItem("StyleCop.CSharp.Rules.dll")]
        [DeploymentItem("Testing.StyleCop.CSharp.ParserDump.dll")]
        [DeploymentItem("TestData\\CastExpression", "CastExpressionWithLinqKeyWordAsVariable")]
        public void CsParserTestCastExpressionWithLinqKeyWordAsVariable()
        {
            this.RunTest("CastExpressionWithLinqKeyWordAsVariable");
        }

        /// <summary>
        /// The cs parser test for strings.
        /// </summary>
        [TestMethod]
        [DeploymentItem("StyleCop.CSharp.Rules.dll")]
        [DeploymentItem("Testing.StyleCop.CSharp.ParserDump.dll")]
        [DeploymentItem("TestData\\Strings", "Strings")]
        public void CsParserTestStrings()
        {
            this.RunTest("Strings");
        }

        /// <summary>
        /// The cs parser test for object and collection initializers.
        /// </summary>
        [TestMethod]
        [DeploymentItem("StyleCop.CSharp.Rules.dll")]
        [DeploymentItem("Testing.StyleCop.CSharp.ParserDump.dll")]
        [DeploymentItem("TestData\\ObjectAndCollectionInitializers", "ObjectAndCollectionInitializers")]
        public void CsParserTestObjectAndCollectionInitializers()
        {
            this.RunTest("ObjectAndCollectionInitializers");
        }

        /// <summary>
        /// The cs parser test ternary operator.
        /// </summary>
        [TestMethod]
        [DeploymentItem("StyleCop.CSharp.Rules.dll")]
        [DeploymentItem("Testing.StyleCop.CSharp.ParserDump.dll")]
        [DeploymentItem("TestData\\TernaryOperator", "TernaryOperator")]
        public void CsParserTestTernaryOperator()
        {
            this.RunTest("TernaryOperator");
        }

        /// <summary>
        /// The cs parser pattern match.
        /// </summary>
        [TestMethod]
        [DeploymentItem("StyleCop.CSharp.Rules.dll")]
        [DeploymentItem("Testing.StyleCop.CSharp.ParserDump.dll")]
        [DeploymentItem("TestData\\PatternMatch", "PatternMatch")]
        public void CsParserTestPatternMatch()
        {
            this.RunTest("PatternMatch");
        }   
        
        /// <summary>
        /// The cs parser pattern match.
        /// </summary>
        [TestMethod]
        [DeploymentItem("StyleCop.CSharp.Rules.dll")]
        [DeploymentItem("Testing.StyleCop.CSharp.ParserDump.dll")]
        [DeploymentItem("TestData\\DefaultLiteralExpressions", "DefaultLiteralExpressions")]
        public void CsParserTestDefaultLiteralExpressions()
        {
            this.RunTest("DefaultLiteralExpressions");
        }

        /// <summary>
        /// The run test.
        /// </summary>
        /// <param name="testName">The test name.</param>
        /// <param name="simulationFrameworkVersion">The framework version to simulate.</param>
        private void RunTest(string testName, double simulationFrameworkVersion = 0)
        {
            string[] files = new string[2];
            files[0] = Path.Combine(testContext.DeploymentDirectory, "StyleCop.CSharp.Rules.dll");
            files[1] = Path.Combine(testContext.DeploymentDirectory, "Testing.StyleCop.CSharp.ParserDump.dll");

            bool result = StyleCopTestRunner.Run(testName, testContext.TestDir, testContext.ResultsDirectory, testContext.DeploymentDirectory, false, simulationFrameworkVersion, files);
            Assert.IsTrue(result);
        }
    }
}