// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AnalysisHelperTest.cs" company="http://stylecop.codeplex.com">
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
//   This is a test class for AnalysisHelperTest and is intended
//   to contain all AnalysisHelperTest Unit Tests
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace VSPackageUnitTest
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using StyleCop;
    using StyleCop.VisualStudio;

    using VSPackageUnitTest.Mocks;

    /// <summary>
    /// This is a test class for AnalysisHelperTest and is intended
    ///  to contain all AnalysisHelperTest Unit Tests
    /// </summary>
    [TestClass]
    public class AnalysisHelperTest : BasicUnitTest
    {
        #region Public Methods

        /// <summary>
        /// A test for AnalysisHelper Constructor
        /// </summary>
        [TestMethod]
        [DeploymentItem("StyleCop.VSPackage.dll")]
        public void AnalysisHelperConstructorTest()
        {
            IServiceProvider serviceProvider = new MockServiceProvider();
            StyleCopCore core = new StyleCopCore();
            FileAnalysisHelper_Accessor specificTarget = new FileAnalysisHelper_Accessor(serviceProvider, core);
            AnalysisHelper_Accessor target = FileAnalysisHelper_Accessor.AttachShadow(specificTarget.Target);
            Assert.IsNotNull(target, "Unable to instantiate the AnalysisHelper class");
            Assert.IsNotNull(target.Core, "AnalysisHelper.Core was null");
        }

        #endregion

        /*
        /// <summary>
        ///A test for AnalysisSupported
        ///</summary>
        [TestMethod]
        [DeploymentItem("StyleCop.VSPackage.dll")]
        public void AnalysisSupportedSingleItemTrueTest()
        {
            IVsHierarchy hierarchy = CreateHierarchyItem("MyCodeFile.cs");
            bool expected = true;
            bool actual = AnalysisHelper_Accessor.FileItemAnalysisSupported(hierarchy);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for AnalysisSupported
        ///</summary>
        [TestMethod]
        [DeploymentItem("StyleCop.VSPackage.dll")]
        public void AnalysisSupportedSingleItemFalseCppTest()
        {
            IVsHierarchy hierarchy = CreateHierarchyItem("MyCodeFile.cpp");
            bool expected = false;
            bool actual = AnalysisHelper_Accessor.FileItemAnalysisSupported(hierarchy);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for AnalysisSupported
        ///</summary>
        [TestMethod]
        [DeploymentItem("StyleCop.VSPackage.dll")]
        public void AnalysisSupportedSingleItemTrueCppTest()
        {
            IVsHierarchy hierarchy = CreateHierarchyItem("MyProjectFile.csproj");
            bool expected = true;
            bool actual = AnalysisHelper_Accessor.FileItemAnalysisSupported(hierarchy);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for AnalysisSupported
        ///</summary>
        [TestMethod]
        [DeploymentItem("StyleCop.VSPackage.dll")]
        public void AnalysisSupportedMultiSelectionItemTrueTest()
        {
            IVsMultiItemSelect multiSelection = null; // TODO: Initialize to an appropriate value
            bool expected = true;
            bool actual = AnalysisHelper_Accessor.AnalysisSupported(multiSelection);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for AnalysisSupported
        ///</summary>
        [TestMethod]
        [DeploymentItem("StyleCop.VSPackage.dll")]
        public void AnalysisSupportedMultiSelectionItemFalseTest()
        {
            IVsMultiItemSelect multiSelection = null; // TODO: Initialize to an appropriate value
            bool expected = false;
            bool actual;
            actual = AnalysisHelper_Accessor.AnalysisSupported(multiSelection);
            Assert.AreEqual(expected, actual);
        }

        private IVsHierarchy CreateHierarchyItem(string p)
        {
            Mock<IVsHierarchy> mockHierarchy = new Mock<IVsHierarchy>();
            throw new System.NotImplementedException();
        }
        */
    }
}