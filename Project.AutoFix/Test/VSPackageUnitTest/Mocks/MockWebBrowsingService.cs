//-----------------------------------------------------------------------
// <copyright file="MockWebBrowsingService.cs">
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
namespace VSPackageUnitTest.Mocks
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.VisualStudio.Shell.Interop;
    using Microsoft.VisualStudio;

    internal class MockWebBrowsingService : IVsWebBrowsingService
    {
        public class NavigateEventArgs : EventArgs
        {
            public readonly string Url;
            public NavigateEventArgs(string url)
            {
                Url = url;
            }
        }

        public event EventHandler<NavigateEventArgs> OnNavigate;

        #region IVsWebBrowsingService Members

        public int CreateExternalWebBrowser(uint dwCreateFlags, VSPREVIEWRESOLUTION dwResolution, string lpszURL)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int CreateWebBrowser(uint dwCreateFlags, ref Guid rguidOwner, string lpszBaseCaption, string lpszStartURL, IVsWebBrowserUser pUser, out IVsWebBrowser ppBrowser, out IVsWindowFrame ppFrame)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int CreateWebBrowserEx(uint dwCreateFlags, ref Guid rguidPersistenceSlot, uint dwId, string lpszBaseCaption, string lpszStartURL, IVsWebBrowserUser pUser, out IVsWebBrowser ppBrowser, out IVsWindowFrame ppFrame)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int GetFirstWebBrowser(ref Guid rguidPersistenceSlot, out IVsWindowFrame ppFrame, out IVsWebBrowser ppBrowser)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int GetWebBrowserEnum(ref Guid rguidPersistenceSlot, out IEnumWindowFrames ppenum)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int Navigate(string lpszURL, uint dwNaviageFlags, out IVsWindowFrame ppFrame)
        {
            if (OnNavigate != null)
            {
                OnNavigate(this, new NavigateEventArgs(lpszURL));
            }

            ppFrame = new MockWindowFrame();
            return VSConstants.S_OK;
        }

        #endregion
    }
}

