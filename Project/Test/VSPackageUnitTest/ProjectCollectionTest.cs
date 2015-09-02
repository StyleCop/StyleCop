// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProjectCollectionTest.cs" company="http://stylecop.codeplex.com">
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
//   This is a test class for ProjectCollectionTest and is intended
//   to contain all ProjectCollectionTest Unit Tests
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace VSPackageUnitTest
{
    using System.Collections;

    using EnvDTE;

    using Microsoft.VisualStudio.TestTools.MockObjects;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using StyleCop.VisualStudio;

    /// <summary>
    /// This is a test class for ProjectCollectionTest and is intended
    ///   to contain all ProjectCollectionTest Unit Tests
    /// </summary>
    [TestClass]
    [DeploymentItem("Microsoft.VisualStudio.QualityTools.MockObjectFramework.dll")]
    [DeploymentItem("StyleCop.VSPackage.dll")]
    public class ProjectCollectionTest
    {
        #region Properties

        ///<summary>
        ///  Gets or sets the test context which provides
        ///  information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext { get; set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// A test for GetEnumerator
        /// </summary>
        [TestMethod]
        public void GetEnumeratorNullTest()
        {
            ProjectCollection target = new ProjectCollection();
            IEnumerator actual;
            actual = target.GetEnumerator();
            Assert.IsNull(actual);
        }

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
        // Use TestInitialize to run code before running each test
        // [TestInitialize]
        // public void MyTestInitialize()
        // {
        // }
        // Use TestCleanup to run code after each test has run
        // [TestCleanup]
        // public void MyTestCleanup()
        // {
        // }

        /// <summary>
        /// A test for GetEnumerator
        /// </summary>
        [TestMethod]
        public void GetEnumeratorSelectedProjectsTest()
        {
            ProjectCollection target = new ProjectCollection();
            Mock<IEnumerable> mockEnumerable = new Mock<IEnumerable>();
            Mock<IEnumerator> mockEnumerator = new Mock<IEnumerator>();
            IEnumerator expected = mockEnumerator.Instance;
            mockEnumerable.ImplementExpr(e => e.GetEnumerator(), expected);
            target.SelectedProjects = mockEnumerable.Instance;
            IEnumerator actual;
            actual = target.GetEnumerator();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// A test for GetEnumerator
        /// </summary>
        [TestMethod]
        public void GetEnumeratorSolutionProjectsTest()
        {
            ProjectCollection target = new ProjectCollection();
            Mock<IEnumerable> mockEnumerable = new Mock<IEnumerable>();
            Mock<IEnumerator> mockEnumerator = new Mock<IEnumerator>();
            Mock<Projects> mockProjects = new Mock<Projects>();
            IEnumerator expected = mockEnumerator.Instance;
            mockProjects.ImplementExpr(p => p.GetEnumerator(), expected);
            mockEnumerable.ImplementExpr(e => e.GetEnumerator(), expected);
            target.SolutionProjects = mockProjects.Instance;
            IEnumerator actual;
            actual = target.GetEnumerator();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// A test for SelectedProjects
        /// </summary>
        [TestMethod]
        public void SelectedProjectsTest()
        {
            ProjectCollection target = new ProjectCollection();
            IEnumerable expected = new Mock<IEnumerable>().Instance;
            IEnumerable actual;
            target.SelectedProjects = expected;
            actual = target.SelectedProjects;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// A test for SolutionProjects
        /// </summary>
        [TestMethod]
        public void SolutionProjectsTest()
        {
            ProjectCollection target = new ProjectCollection();
            Mock<Projects> mockProjects = new Mock<Projects>();
            Projects expected = mockProjects.Instance;
            Projects actual;
            target.SolutionProjects = expected;
            actual = target.SolutionProjects;
            Assert.AreEqual(expected, actual);
        }

        #endregion
    }
}