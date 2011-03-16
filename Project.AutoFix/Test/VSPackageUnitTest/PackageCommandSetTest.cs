//--------------------------------------------------------------------------
// <copyright file="PackageCommandSetTest.cs">
//   MS-PL
// </copyright>
// <license>
//   This source code is subject to terms and conditions of the Microsoft 
//   Public License. A copy of the license can be found in the License.html 
//   file at the root of this distribution. 
//   By using this source code in any fashion, you are agreeing to be bound 
//   by the terms of the Microsoft Public License. You must not remove this 
//   notice, or any other, from this software.
// </license>
//-----------------------------------------------------------------------
namespace VSPackageUnitTest
{
    using StyleCop.VisualStudio;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using Microsoft.VisualStudio.TestTools.MockObjects;
    using VSPackageUnitTest.Mocks;

    /// <summary>
    ///This is a test class for PackageCommandSetTest and is intended
    ///to contain all PackageCommandSetTest Unit Tests
    ///</summary>
    [TestClass()]
    public class PackageCommandSetTest : BasicUnitTest
    {
        private MockServiceProvider mockServiceProvider;
        private IServiceProvider serviceProvider;

        /// <summary>
        ///A test for StatusAnalyzeThisFile
        ///</summary>
        [TestMethod()]
        [Ignore()]
        [DeploymentItem("StyleCop.VSPackage.dll")]
        public void VsStatusAnalyzeSingleFileTest()
        {
            PackageCommandSet_Accessor target = new PackageCommandSet_Accessor(this.serviceProvider);
            target.StatusAnalyzeThisFile(this, EventArgs.Empty);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        /// A test for PackageCommandSet Constructor
        ///</summary>
        [TestMethod()]
        [DeploymentItem("StyleCop.VSPackage.dll")]
        public void VsPackageCommandSetConstructorTest()
        {
            PackageCommandSet_Accessor target = new PackageCommandSet_Accessor(this.serviceProvider);
            CommandSet_Accessor innerTarget = new PackageCommandSet_Accessor(this.serviceProvider);
            Assert.IsNotNull(target.CommandList, "CommandList was not created.");
            Assert.IsNotNull(innerTarget.ServiceProvider, "Service provider not stored by the constructor");
        }

        /// <summary>
        /// Use TestInitialize to run code before running each test
        /// </summary>
        [TestInitialize()]
        public void TestInitialize()
        {
            this.mockServiceProvider = new MockServiceProvider();
            this.serviceProvider = this.mockServiceProvider;
            ProjectUtilities_Accessor.serviceProvider = this.serviceProvider;
        }
        
        /// <summary>
        /// Use TestCleanup to run code after each test has run
        /// </summary>
        [TestCleanup()]
        public void TestCleanup()
        {
            ProjectUtilities_Accessor.serviceProvider = null;
        }
    }
}
