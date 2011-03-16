//--------------------------------------------------------------------------
// <copyright file="AnalysisHelperTest.cs">
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
    using System;
    using StyleCop.VisualStudio;
    using Microsoft.VisualStudio.Shell.Interop;
    using Microsoft.VisualStudio.TestTools.MockObjects;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using VSPackageUnitTest.Mocks;
    using StyleCop;

    /// <summary>
    ///This is a test class for AnalysisHelperTest and is intended
    ///to contain all AnalysisHelperTest Unit Tests
    ///</summary>
    [TestClass()]
    public class AnalysisHelperTest : BasicUnitTest
    {
        /// <summary>
        ///A test for AnalysisHelper Constructor
        ///</summary>
        [TestMethod()]
        [DeploymentItem("StyleCop.VSPackage.dll")]
        public void VsAnalysisHelperConstructorTest()
        {
            IServiceProvider serviceProvider = new MockServiceProvider();
            StyleCopCore core = new StyleCopCore();
            FileAnalysisHelper_Accessor specificTarget = new FileAnalysisHelper_Accessor(serviceProvider, core);
            AnalysisHelper_Accessor target = FileAnalysisHelper_Accessor.AttachShadow(specificTarget.Target);
            Assert.IsNotNull(target, "Unable to instantiate the AnalysisHelper class");
            Assert.IsNotNull(target.Core, "AnalysisHelper.Core was null");
        }
    }
}
