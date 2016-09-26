//-----------------------------------------------------------------------
// <copyright file="UpdateSolutionListenerTest.cs">
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
//-----------------------------------------------------------------------
namespace VSPackageUnitTest
{
    using System;
    using System.Diagnostics;
    using System.Reflection;
    using Microsoft.VisualStudio;
    using Microsoft.VisualStudio.Shell.Interop;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using StyleCop.VisualStudio;
    using VSPackageUnitTest.Mocks;

    /// <summary>
    /// This is a test class for UpdateSolutionListenerTest and is intended
    /// to contain all UpdateSolutionListenerTest Unit Tests
    /// </summary>
    [TestClass]
    public class UpdateSolutionListenerTest : BasicUnitTest
    {
        /// <summary>
        /// A test for UpdateSolution_StartUpdate
        /// </summary>
        [TestMethod]
        public void UpdateSolution_StartUpdateTest()
        {
            IServiceProvider serviceProvider = this.PrepareServiceProvider();
            UpdateSolutionListener target = new UpdateSolutionListener(serviceProvider);
            int pfCancelUpdate = 0; 
            int pfCancelUpdateExpected = 0; 
            int expected = VSConstants.S_OK;
            int actual;

            bool eventFired = false;
            target.BeginBuild += (sender, args) => { eventFired = true; };
            actual = target.UpdateSolution_StartUpdate(ref pfCancelUpdate);
            Assert.AreEqual(pfCancelUpdateExpected, pfCancelUpdate);
            Assert.AreEqual(expected, actual);
            Assert.IsTrue(eventFired, "The BeginBuild event did npot fire");
        }

        /// <summary>
        ///A test for UpdateSolution_Done
        ///</summary>
        [TestMethod]
        public void UpdateSolution_DoneTest()
        {
            IServiceProvider serviceProvider = this.PrepareServiceProvider();
            UpdateSolutionListener target = new UpdateSolutionListener(serviceProvider);
            int fSucceeded = 0; 
            int fModified = 0; 
            int fCancelCommand = 0; 
            int expected = VSConstants.E_NOTIMPL;
            int actual = target.UpdateSolution_Done(fSucceeded, fModified, fCancelCommand);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for UpdateSolution_Cancel
        ///</summary>
        [TestMethod]
        public void UpdateSolution_CancelTest()
        {
            IServiceProvider serviceProvider = this.PrepareServiceProvider();
            UpdateSolutionListener target = new UpdateSolutionListener(serviceProvider);
            int expected = VSConstants.E_NOTIMPL;
            int actual;
            actual = target.UpdateSolution_Cancel();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for UpdateSolution_Begin
        ///</summary>
        [TestMethod]
        public void UpdateSolution_BeginTest()
        {
            IServiceProvider serviceProvider = this.PrepareServiceProvider();
            UpdateSolutionListener target = new UpdateSolutionListener(serviceProvider);
            int pfCancelUpdate = 0; 
            int pfCancelUpdateExpected = 0; 
            int expected = VSConstants.E_NOTIMPL;
            int actual = target.UpdateSolution_Begin(ref pfCancelUpdate);
            Assert.AreEqual(pfCancelUpdateExpected, pfCancelUpdate);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for OnActiveProjectCfgChange
        ///</summary>
        [TestMethod]
        public void OnActiveProjectCfgChangeTest()
        {
            IServiceProvider serviceProvider = this.PrepareServiceProvider();
            UpdateSolutionListener target = new UpdateSolutionListener(serviceProvider);
            int expected = VSConstants.E_NOTIMPL;
            int actual = target.OnActiveProjectCfgChange(null);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Initialize
        ///</summary>
        [TestMethod]
        public void InitializeTest()
        {
            var serviceProvider = new MockServiceProvider();

            UpdateSolutionListener target = new UpdateSolutionListener(serviceProvider); 
            target.Initialize();

            uint expected = 1;
            Assert.AreEqual(expected, expected, (uint)target.GetType()
                .GetField("eventsCookie", BindingFlags.Instance | BindingFlags.NonPublic)
                .GetValue(target));
        }

        /// <summary>
        ///A test for Dispose
        ///</summary>
        [TestMethod]
        public void DisposeTest()
        {
            var serviceProvider = new MockServiceProvider();
            var mockUpdateSolutionEvents = new Mock<IVsUpdateSolutionEvents>(MockBehavior.Strict);
            UpdateSolutionListener target = new UpdateSolutionListener(serviceProvider);

            uint cookie = 0;
            ((IVsSolutionBuildManager)serviceProvider.GetService(typeof(SVsSolutionBuildManager))).AdviseUpdateSolutionEvents(mockUpdateSolutionEvents.Object, out cookie);
            Debug.Assert(cookie == 1);

            target.GetType()
                .GetField("eventsCookie", BindingFlags.Instance | BindingFlags.NonPublic)
                .SetValue(target, cookie);
            target.Dispose();
        }

        /// <summary>
        ///A test for UpdateSolutionListener Constructor
        ///</summary>
        [TestMethod]
        public void UpdateSolutionListenerConstructorTest()
        {
            IServiceProvider serviceProvider = this.PrepareServiceProvider();
            UpdateSolutionListener target = new UpdateSolutionListener(serviceProvider);
            Assert.IsNotNull(target);
        }

        private IServiceProvider PrepareServiceProvider()
        {
            var mock = new MockServiceProvider();
            return mock;
        }
    }
}
