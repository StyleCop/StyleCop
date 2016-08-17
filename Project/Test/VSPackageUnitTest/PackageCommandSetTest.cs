// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PackageCommandSetTest.cs" company="http://stylecop.codeplex.com">
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

    using Microsoft.VisualStudio.TestTools.MockObjects;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            var mockActiveDocument = new Mock<Document>();
            var mockDte = new Mock<DTE>();

            mockDte.ImplementExpr(dte => dte.ActiveDocument, mockActiveDocument.Instance);

            this.mockServiceProvider.ImplementExpr(sp => sp.GetService(typeof(EnvDTE.DTE)), mockDte.Instance);

            PackageCommandSet target = new PackageCommandSet(this.mockServiceProvider.Instance);
            CommandSet innerTarget = new PackageCommandSet(this.mockServiceProvider.Instance);
            Assert.IsNotNull(typeof(PackageCommandSet).GetProperty("CommandList", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(innerTarget),
                "CommandList was not created.");
            Assert.IsNotNull(typeof(PackageCommandSet).GetProperty("ServiceProvider", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(innerTarget),
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
            this.mockServiceProvider = new Mock<IServiceProvider>();
            typeof(ProjectUtilities).GetField("serviceProvider", BindingFlags.NonPublic | BindingFlags.Static)
                .SetValue(null, this.mockServiceProvider.Instance);
        }

        #endregion
    }
}