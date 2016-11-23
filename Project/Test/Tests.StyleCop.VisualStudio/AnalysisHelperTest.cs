// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AnalysisHelperTest.cs" company="https://github.com/StyleCop">
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
        public void AnalysisHelperConstructorTest()
        {
            IServiceProvider serviceProvider = new MockServiceProvider();
            StyleCopCore core = new StyleCopCore();
            FileAnalysisHelper specificTarget = new FileAnalysisHelper(serviceProvider, core);
            AnalysisHelper target = specificTarget;
            Assert.IsNotNull(target, "Unable to instantiate the AnalysisHelper class");
            Assert.IsNotNull(target.Core, "AnalysisHelper.Core was null");
        }

        #endregion
   }
}