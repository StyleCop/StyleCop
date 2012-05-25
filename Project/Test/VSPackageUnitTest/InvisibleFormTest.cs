// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InvisibleFormTest.cs" company="http://stylecop.codeplex.com">
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
//   This is a test class for InvisibleFormTest and is intended
//   to contain all InvisibleFormTest Unit Tests
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace VSPackageUnitTest
{
    using System.Windows.Forms;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using StyleCop.VisualStudio;

    /// <summary>
    /// This is a test class for InvisibleFormTest and is intended
    ///   to contain all InvisibleFormTest Unit Tests
    /// </summary>
    [TestClass]
    public class InvisibleFormTest : BasicUnitTest
    {
        #region Public Methods

        /// <summary>
        /// A test for Instance
        /// </summary>
        [TestMethod]
        [DeploymentItem("StyleCop.VSPackage.dll")]
        public void InstanceTest()
        {
            InvisibleForm_Accessor actual;

            actual = InvisibleForm_Accessor.Instance;
            Assert.IsNotNull(actual, "InvisibleForm.Instance returned null");

            // Reset and try again
            InvisibleForm_Accessor.instanceForm = null;
            actual = InvisibleForm_Accessor.Instance;
            Assert.IsNotNull(actual, "InvisibleForm.Instance returned null");
            Assert.AreSame(actual.Target, InvisibleForm_Accessor.Instance.Target, "Second call to the property should return the same opbject instance.");

            Form f = actual.Target as Form;
            Assert.IsFalse(f.Visible, "InvisibleForm should not be visible");
        }

        /// <summary>
        /// The my test cleanup.
        /// </summary>
        [TestCleanup]
        public void MyTestCleanup()
        {
            InvisibleForm_Accessor.instanceForm = null;
        }

        /// <summary>
        /// The my test initialize.
        /// </summary>
        [TestInitialize]
        public void MyTestInitialize()
        {
            InvisibleForm_Accessor.instanceForm = null;
        }

        #endregion
    }
}