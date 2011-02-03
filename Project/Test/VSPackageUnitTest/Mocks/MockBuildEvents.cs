//-----------------------------------------------------------------------
// <copyright file="MockEvents.cs">
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
namespace VSPackageUnitTest.Mocks
{
    class MockBuildEvents : EnvDTE.BuildEvents
    {
        public int OnBuildBeginSubscriberCount
        {
            get { return (OnBuildBegin == null) ? 0 : OnBuildBegin.GetInvocationList().Length; }
        }

        public void FireOnBuildBegin(EnvDTE.vsBuildScope scope, EnvDTE.vsBuildAction action)
        {
            if (OnBuildBegin != null)
            {
                OnBuildBegin(scope, action);
            }
        }

        public void FireOnBuildDone(EnvDTE.vsBuildScope scope, EnvDTE.vsBuildAction action)
        {
            if (OnBuildDone != null)
            {
                OnBuildDone(scope, action);
            }
        }

        #region _dispBuildEvents_Event Members

        public event EnvDTE._dispBuildEvents_OnBuildBeginEventHandler OnBuildBegin;

        public event EnvDTE._dispBuildEvents_OnBuildDoneEventHandler OnBuildDone;

        // These are unused currently, but they must exist to satisfy the interface contract.
        // Disable the warning for unused variables.
#pragma warning disable 67
        public event EnvDTE._dispBuildEvents_OnBuildProjConfigBeginEventHandler OnBuildProjConfigBegin;

        public event EnvDTE._dispBuildEvents_OnBuildProjConfigDoneEventHandler OnBuildProjConfigDone;
#pragma warning restore 67

        #endregion
    }
}
