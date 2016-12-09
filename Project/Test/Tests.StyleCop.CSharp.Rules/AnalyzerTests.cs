// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AnalyzerTests.cs">
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
//   The analyzer tests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CSharpAnalyzersTest
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Reflection;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using StyleCop.Spelling;
    using StyleCop.Test;

    /// <summary>
    /// The analyzer tests.
    /// </summary>
    [TestClass]
    public class AnalyzerTests
    {
        /// <summary>
        /// The test context.
        /// </summary>
        private static TestContext testContext;

        #region Public Methods

        /// <summary>
        /// Tests the class initialize.
        /// </summary>
        /// <param name="context">The context.</param>
        [ClassInitialize]
        public static void TestClassInitialize(TestContext context)
        {
            testContext = context;
        }

        /// <summary>
        /// The cs analyzer access modifiers test.
        /// </summary>
        [TestMethod]
        [DeploymentItem("StyleCop.CSharp.dll")]
        [DeploymentItem("StyleCop.CSharp.Rules.dll")]
        [DeploymentItem("TestData\\AccessModifiers", "AccessModifiers")]
        public void CsAnalyzerAccessModifiersTest()
        {
            this.RunTest("AccessModifiers");
        }

        /// <summary>
        /// The cs analyzer built in types test.
        /// </summary>
        [TestMethod]
        [DeploymentItem("StyleCop.CSharp.dll")]
        [DeploymentItem("StyleCop.CSharp.Rules.dll")]
        [DeploymentItem("TestData\\BuiltInTypes", "BuiltInTypes")]
        public void CsAnalyzerBuiltInTypesTest()
        {
            this.RunTest("BuiltInTypes");
        }

        /// <summary>
        /// The cs analyzer built in types test.
        /// </summary>
        [TestMethod]
        [DeploymentItem("StyleCop.CSharp.dll")]
        [DeploymentItem("StyleCop.CSharp.Rules.dll")]
        [DeploymentItem("TestData\\StringFormat", "StringFormat")]
        public void CsAnalyzerStringFormatTest()
        {
            this.RunTest("StringFormat");
        }

        /// <summary>
        /// The cs analyzer class members test.
        /// </summary>
        [TestMethod]
        [DeploymentItem("StyleCop.CSharp.dll")]
        [DeploymentItem("StyleCop.CSharp.Rules.dll")]
        [DeploymentItem("TestData\\ClassMembers", "ClassMembers")]
        public void CsAnalyzerClassMembersTest()
        {
            this.RunTest("ClassMembers");
        }

        /// <summary>
        /// The cs analyzer comments test.
        /// </summary>
        [TestMethod]
        [DeploymentItem("StyleCop.CSharp.dll")]
        [DeploymentItem("StyleCop.CSharp.Rules.dll")]
        [DeploymentItem("TestData\\Comments", "Comments")]
        public void CsAnalyzerCommentsTest()
        {
            this.RunTest("Comments");
        }

        /// <summary>
        /// The cs analyzer curly brackets test.
        /// </summary>
        [TestMethod]
        [DeploymentItem("StyleCop.CSharp.dll")]
        [DeploymentItem("StyleCop.CSharp.Rules.dll")]
        [DeploymentItem("TestData\\CurlyBrackets", "CurlyBrackets")]
        public void CsAnalyzerCurlyBracketsTest()
        {
            this.RunTest("CurlyBrackets");
        }

        /// <summary>
        /// The cs analyzer debug text test.
        /// </summary>
        [TestMethod]
        [DeploymentItem("StyleCop.CSharp.dll")]
        [DeploymentItem("StyleCop.CSharp.Rules.dll")]
        [DeploymentItem("TestData\\DebugText", "DebugText")]
        public void CsAnalyzerDebugTextTest()
        {
            this.RunTest("DebugText");
        }

        /// <summary>
        /// The cs analyzer declaration keyword order test.
        /// </summary>
        [TestMethod]
        [DeploymentItem("StyleCop.CSharp.dll")]
        [DeploymentItem("StyleCop.CSharp.Rules.dll")]
        [DeploymentItem("TestData\\DeclarationKeywordOrder", "DeclarationKeywordOrder")]
        public void CsAnalyzerDeclarationKeywordOrderTest()
        {
            this.RunTest("DeclarationKeywordOrder");
        }

        /// <summary>
        /// The cs analyzer documentation test.
        /// </summary>
        [TestMethod]
        [DeploymentItem("StyleCop.CSharp.dll")]
        [DeploymentItem("StyleCop.CSharp.Rules.dll")]
        [DeploymentItem("mssp7en.dll")]
        [DeploymentItem("mssp7en.lex")]
        [DeploymentItem("TestData\\Documentation", "Documentation")]
        public void CsAnalyzerDocumentationTest()
        {
            this.RunTest("Documentation");
        }

        /// <summary>
        /// The cs analyzer element order test.
        /// </summary>
        [TestMethod]
        [DeploymentItem("StyleCop.CSharp.dll")]
        [DeploymentItem("StyleCop.CSharp.Rules.dll")]
        [DeploymentItem("TestData\\ElementOrder", "ElementOrder")]
        public void CsAnalyzerElementOrderTest()
        {
            this.RunTest("ElementOrder");
        }

        /// <summary>
        /// The cs analyzer empty strings test.
        /// </summary>
        [TestMethod]
        [DeploymentItem("StyleCop.CSharp.dll")]
        [DeploymentItem("StyleCop.CSharp.Rules.dll")]
        [DeploymentItem("TestData\\EmptyStrings", "EmptyStrings")]
        public void CsAnalyzerEmptyStringsTest()
        {
            this.RunTest("EmptyStrings");
        }

        /// <summary>
        /// The cs analyzer file contents test.
        /// </summary>
        [TestMethod]
        [DeploymentItem("StyleCop.CSharp.dll")]
        [DeploymentItem("StyleCop.CSharp.Rules.dll")]
        [DeploymentItem("TestData\\FileContents", "FileContents")]
        public void CsAnalyzerFileContentsTest()
        {
            this.RunTest("FileContents");
        }

        /// <summary>
        /// The cs analyzer file headers test.
        /// </summary>
        [TestMethod]
        [DeploymentItem("StyleCop.CSharp.dll")]
        [DeploymentItem("StyleCop.CSharp.Rules.dll")]
        [DeploymentItem("TestData\\FileHeaders", "FileHeaders")]
        public void CsAnalyzerFileHeadersTest()
        {
            this.RunTest("FileHeaders");
        }

        /// <summary>
        /// The cs analyzer line spacing test.
        /// </summary>
        [TestMethod]
        [DeploymentItem("StyleCop.CSharp.dll")]
        [DeploymentItem("StyleCop.CSharp.Rules.dll")]
        [DeploymentItem("TestData\\LineSpacing", "LineSpacing")]
        public void CsAnalyzerLineSpacingTest()
        {
            this.RunTest("LineSpacing");
        }

        /// <summary>
        /// The cs analyzer method parameters test.
        /// </summary>
        [TestMethod]
        [DeploymentItem("StyleCop.CSharp.dll")]
        [DeploymentItem("StyleCop.CSharp.Rules.dll")]
        [DeploymentItem("TestData\\MethodParameters", "MethodParameters")]
        public void CsAnalyzerMethodParametersTest()
        {
            this.RunTest("MethodParameters");
        }

        /// <summary>
        /// The cs analyzer naming test.
        /// </summary>
        [TestMethod]
        [DeploymentItem("StyleCop.CSharp.dll")]
        [DeploymentItem("StyleCop.CSharp.Rules.dll")]
        [DeploymentItem("TestData\\Naming", "Naming")]
        public void CsAnalyzerNamingTest()
        {
            this.RunTest("Naming");
        }

        /// <summary>
        /// The cs analyzer parenthesis test.
        /// </summary>
        [TestMethod]
        [DeploymentItem("StyleCop.CSharp.dll")]
        [DeploymentItem("StyleCop.CSharp.Rules.dll")]
        [DeploymentItem("TestData\\Parenthesis", "Parenthesis")]
        public void CsAnalyzerParenthesisTest()
        {
            this.RunTest("Parenthesis");
        }

        /// <summary>
        /// The cs analyzer query clauses test.
        /// </summary>
        [TestMethod]
        [DeploymentItem("StyleCop.CSharp.dll")]
        [DeploymentItem("StyleCop.CSharp.Rules.dll")]
        [DeploymentItem("TestData\\QueryClauses", "QueryClauses")]
        public void CsAnalyzerQueryClausesTest()
        {
            this.RunTest("QueryClauses");
        }

        /// <summary>
        /// The cs analyzer regions test.
        /// </summary>
        [TestMethod]
        [DeploymentItem("StyleCop.CSharp.dll")]
        [DeploymentItem("StyleCop.CSharp.Rules.dll")]
        [DeploymentItem("TestData\\Regions", "Regions")]
        public void CsAnalyzerRegionsTest()
        {
            this.RunTest("Regions");
        }

        /// <summary>
        /// The cs analyzer spacing test.
        /// </summary>
        [TestMethod]
        [DeploymentItem("StyleCop.CSharp.dll")]
        [DeploymentItem("StyleCop.CSharp.Rules.dll")]
        [DeploymentItem("TestData\\Spacing", "Spacing")]
        public void CsAnalyzerSpacingTest()
        {
            this.RunTest("Spacing");
        }

        /// <summary>
        /// The cs analyzer statements test.
        /// </summary>
        [TestMethod]
        [DeploymentItem("StyleCop.CSharp.dll")]
        [DeploymentItem("StyleCop.CSharp.Rules.dll")]
        [DeploymentItem("TestData\\Statements", "Statements")]
        public void CsAnalyzerStatementsTest()
        {
            this.RunTest("Statements");
        }

        /// <summary>
        /// The cs analyzer tabs test.
        /// </summary>
        [TestMethod]
        [DeploymentItem("StyleCop.CSharp.dll")]
        [DeploymentItem("StyleCop.CSharp.Rules.dll")]
        [DeploymentItem("TestData\\Tabs", "Tabs")]
        public void CsAnalyzerTabsTest()
        {
            this.RunTest("Tabs");
        }

        /// <summary>
        /// The cs analyzer unnecessary code test.
        /// </summary>
        [TestMethod]
        [DeploymentItem("StyleCop.CSharp.dll")]
        [DeploymentItem("StyleCop.CSharp.Rules.dll")]
        [DeploymentItem("TestData\\UnnecessaryCode", "UnnecessaryCode")]
        public void CsAnalyzerUnnecessaryCodeTest()
        {
            this.RunTest("UnnecessaryCode");
        }

        #endregion

        #region Methods

        /// <summary>
        /// The run test.
        /// </summary>
        /// <param name="testName">The test name.</param>
        /// <param name="simulationFrameworkVersion">The framework version to simulate for test.</param>
        private void RunTest(string testName, double simulationFrameworkVersion = 0)
        {
            string[] files = new string[2];
            files[0] = Path.Combine(testContext.DeploymentDirectory, "StyleCop.CSharp.dll");
            files[1] = Path.Combine(testContext.DeploymentDirectory, "StyleCop.CSharp.Rules.dll");
    
            bool result = StyleCopTestRunner.Run(testName, testContext.TestDir, testContext.ResultsDirectory,  testContext.DeploymentDirectory, false, simulationFrameworkVersion, files);

            Assert.IsTrue(result);
        }

        #endregion
    }
}