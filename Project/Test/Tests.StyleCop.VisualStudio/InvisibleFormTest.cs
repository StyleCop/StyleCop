// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InvisibleFormTest.cs" company="https://github.com/StyleCop">
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
    using System.Reflection;
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
        public void InstanceTest()
        {
            InvisibleForm actual;

            actual = InvisibleForm.Instance;
            Assert.IsNotNull(actual, "InvisibleForm.Instance returned null");

            // Reset and try again
            typeof(InvisibleForm)
                .GetField("instanceForm", BindingFlags.Static | BindingFlags.NonPublic)
                .SetValue(null, null);
            actual = InvisibleForm.Instance;
            Assert.IsNotNull(actual, "InvisibleForm.Instance returned null");
            Assert.AreSame(actual, InvisibleForm.Instance, "Second call to the property should return the same opbject instance.");

            Form f = actual as Form;
            Assert.IsFalse(f.Visible, "InvisibleForm should not be visible");
        }

        /// <summary>
        /// The my test cleanup.
        /// </summary>
        [TestCleanup]
        public void MyTestCleanup()
        {
            typeof(InvisibleForm)
                .GetField("instanceForm", BindingFlags.Static | BindingFlags.NonPublic)
                .SetValue(null, null);
        }

        /// <summary>
        /// The my test initialize.
        /// </summary>
        [TestInitialize]
        public void MyTestInitialize()
        {
            typeof(InvisibleForm)
                .GetField("instanceForm", BindingFlags.Static | BindingFlags.NonPublic)
                .SetValue(null, null);
        }

        #endregion
    }
}