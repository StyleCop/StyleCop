// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PackageCommandSetTest.cs" company="https://github.com/StyleCop">
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
//   This is a test class for PackageCommandSetTest and is intended
//   to contain all PackageCommandSetTest Unit Tests
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace VSPackageUnitTest
{
    using System;
    using System.Reflection;

    using EnvDTE;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using StyleCop.VisualStudio;

    /// <summary>
    /// This is a test class for PackageCommandSetTest and is intended
    ///  to contain all PackageCommandSetTest Unit Tests
    /// </summary>
    [TestClass]
    public class PackageCommandSetTest : BasicUnitTest
    {
        #region Constants and Fields

        private Mock<IServiceProvider> mockServiceProvider;

        #endregion

        #region Public Methods

        /// <summary>
        /// A test for PackageCommandSet Constructor
        /// </summary>
        [TestMethod]
        public void PackageCommandSetConstructorTest()
        {
            var mockActiveDocument = new Mock<Document>(MockBehavior.Strict);
            var mockDte = new Mock<DTE>(MockBehavior.Strict);

            mockDte.SetupGet(x => x.ActiveDocument).Returns(mockActiveDocument.Object);

            this.mockServiceProvider.Setup(x => x.GetService(typeof(EnvDTE.DTE))).Returns(mockDte.Object);

            PackageCommandSet target = new PackageCommandSet(this.mockServiceProvider.Object);
            CommandSet innerTarget = new PackageCommandSet(this.mockServiceProvider.Object);
            Assert.IsNotNull(typeof(PackageCommandSet).GetProperty("CommandList", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(innerTarget, null),
                "CommandList was not created.");
            Assert.IsNotNull(typeof(PackageCommandSet).GetProperty("ServiceProvider", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(innerTarget, null),
                "Service provider not stored by the constructor");
        }

        /// <summary>
        /// Use TestCleanup to run code after each test has run
        /// </summary>
        [TestCleanup]
        public void TestCleanup()
        {
            typeof(ProjectUtilities).GetField("serviceProvider", BindingFlags.NonPublic | BindingFlags.Static)
                .SetValue(null, null);
        }

        /// <summary>
        /// Use TestInitialize to run code before running each test
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            this.mockServiceProvider = new Mock<IServiceProvider>(MockBehavior.Strict);
            typeof(ProjectUtilities).GetField("serviceProvider", BindingFlags.NonPublic | BindingFlags.Static)
                .SetValue(null, this.mockServiceProvider.Object);
        }

        #endregion
    }
}