// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MockBuildEvents.cs" company="https://github.com/StyleCop">
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
//   The mock build events.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace VSPackageUnitTest.Mocks
{
    using EnvDTE;

    /// <summary>
    /// The mock build events.
    /// </summary>
    internal class MockBuildEvents : EnvDTE.BuildEvents
    {
        /// <summary>
        ///   The on build begin.
        /// </summary>
        public event _dispBuildEvents_OnBuildBeginEventHandler OnBuildBegin;

        /// <summary>
        ///   The on build done.
        /// </summary>
        public event _dispBuildEvents_OnBuildDoneEventHandler OnBuildDone;

        // These are unused currently, but they must exist to satisfy the interface contract.
        // Disable the warning for unused variables.
#pragma warning disable 67

        /// <summary>
        ///   The on build proj config begin.
        /// </summary>
        public event _dispBuildEvents_OnBuildProjConfigBeginEventHandler OnBuildProjConfigBegin;

        /// <summary>
        ///   The on build proj config done.
        /// </summary>
        public event _dispBuildEvents_OnBuildProjConfigDoneEventHandler OnBuildProjConfigDone;
#pragma warning restore 67

        #region Properties

        /// <summary>
        ///   Gets OnBuildBeginSubscriberCount.
        /// </summary>
        public int OnBuildBeginSubscriberCount
        {
            get
            {
                return (this.OnBuildBegin == null) ? 0 : this.OnBuildBegin.GetInvocationList().Length;
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// The fire on build begin.
        /// </summary>
        /// <param name="scope">
        /// The scope.
        /// </param>
        /// <param name="action">
        /// The action.
        /// </param>
        public void FireOnBuildBegin(vsBuildScope scope, vsBuildAction action)
        {
            if (this.OnBuildBegin != null)
            {
                this.OnBuildBegin(scope, action);
            }
        }

        /// <summary>
        /// The fire on build done.
        /// </summary>
        /// <param name="scope">
        /// The scope.
        /// </param>
        /// <param name="action">
        /// The action.
        /// </param>
        public void FireOnBuildDone(vsBuildScope scope, vsBuildAction action)
        {
            if (this.OnBuildDone != null)
            {
                this.OnBuildDone(scope, action);
            }
        }
        
        #endregion
    }
}