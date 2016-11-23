// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProjectCollectionTest.cs" company="https://github.com/StyleCop">
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

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using StyleCop.VisualStudio;

    /// <summary>
    /// This is a test class for ProjectCollectionTest and is intended
    ///   to contain all ProjectCollectionTest Unit Tests
    /// </summary>
    [TestClass]
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
            Mock<IEnumerable> mockEnumerable = new Mock<IEnumerable>(MockBehavior.Strict);
            Mock<IEnumerator> mockEnumerator = new Mock<IEnumerator>(MockBehavior.Strict);
            IEnumerator expected = mockEnumerator.Object;
            mockEnumerable.Setup(e => e.GetEnumerator()).Returns(expected);
            target.SelectedProjects = mockEnumerable.Object;
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
            Mock<IEnumerable> mockEnumerable = new Mock<IEnumerable>(MockBehavior.Strict);
            Mock<IEnumerator> mockEnumerator = new Mock<IEnumerator>(MockBehavior.Strict);
            Mock<Projects> mockProjects = new Mock<Projects>(MockBehavior.Strict);
            IEnumerator expected = mockEnumerator.Object;
            mockProjects.Setup(p => p.GetEnumerator()).Returns(expected);
            mockEnumerable.Setup(e => e.GetEnumerator()).Returns(expected);
            target.SolutionProjects = mockProjects.Object;
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
            IEnumerable expected = new Mock<IEnumerable>(MockBehavior.Strict).Object;
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
            Mock<Projects> mockProjects = new Mock<Projects>(MockBehavior.Strict);
            Projects expected = mockProjects.Object;
            Projects actual;
            target.SolutionProjects = expected;
            actual = target.SolutionProjects;
            Assert.AreEqual(expected, actual);
        }

        #endregion
    }
}