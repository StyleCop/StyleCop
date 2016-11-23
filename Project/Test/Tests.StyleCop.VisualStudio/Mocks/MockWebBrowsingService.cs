// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MockWebBrowsingService.cs" company="https://github.com/StyleCop">
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
//   The mock web browsing service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace VSPackageUnitTest.Mocks
{
    using System;

    using Microsoft.VisualStudio;
    using Microsoft.VisualStudio.Shell.Interop;

    /// <summary>
    /// The mock web browsing service.
    /// </summary>
    internal class MockWebBrowsingService : IVsWebBrowsingService
    {
        #region Events

        /// <summary>
        /// The on navigate.
        /// </summary>
        public event EventHandler<NavigateEventArgs> OnNavigate;

        #endregion

        #region Implemented Interfaces

        #region IVsWebBrowsingService

        /// <summary>
        /// The create external web browser.
        /// </summary>
        /// <param name="dwCreateFlags">
        /// The dw create flags.
        /// </param>
        /// <param name="dwResolution">
        /// The dw resolution.
        /// </param>
        /// <param name="lpszURL">
        /// The lpsz url.
        /// </param>
        /// <returns>
        /// The create external web browser.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int CreateExternalWebBrowser(uint dwCreateFlags, VSPREVIEWRESOLUTION dwResolution, string lpszURL)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The create web browser.
        /// </summary>
        /// <param name="dwCreateFlags">
        /// The dw create flags.
        /// </param>
        /// <param name="rguidOwner">
        /// The rguid owner.
        /// </param>
        /// <param name="lpszBaseCaption">
        /// The lpsz base caption.
        /// </param>
        /// <param name="lpszStartURL">
        /// The lpsz start url.
        /// </param>
        /// <param name="pUser">
        /// The p user.
        /// </param>
        /// <param name="ppBrowser">
        /// The pp browser.
        /// </param>
        /// <param name="ppFrame">
        /// The pp frame.
        /// </param>
        /// <returns>
        /// The create web browser.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int CreateWebBrowser(
            uint dwCreateFlags, ref Guid rguidOwner, string lpszBaseCaption, string lpszStartURL, IVsWebBrowserUser pUser, out IVsWebBrowser ppBrowser, out IVsWindowFrame ppFrame)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The create web browser ex.
        /// </summary>
        /// <param name="dwCreateFlags">
        /// The dw create flags.
        /// </param>
        /// <param name="rguidPersistenceSlot">
        /// The rguid persistence slot.
        /// </param>
        /// <param name="dwId">
        /// The dw id.
        /// </param>
        /// <param name="lpszBaseCaption">
        /// The lpsz base caption.
        /// </param>
        /// <param name="lpszStartURL">
        /// The lpsz start url.
        /// </param>
        /// <param name="pUser">
        /// The p user.
        /// </param>
        /// <param name="ppBrowser">
        /// The pp browser.
        /// </param>
        /// <param name="ppFrame">
        /// The pp frame.
        /// </param>
        /// <returns>
        /// The create web browser ex.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int CreateWebBrowserEx(
            uint dwCreateFlags, ref Guid rguidPersistenceSlot, uint dwId, string lpszBaseCaption, string lpszStartURL, IVsWebBrowserUser pUser, out IVsWebBrowser ppBrowser, out IVsWindowFrame ppFrame)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The get first web browser.
        /// </summary>
        /// <param name="rguidPersistenceSlot">
        /// The rguid persistence slot.
        /// </param>
        /// <param name="ppFrame">
        /// The pp frame.
        /// </param>
        /// <param name="ppBrowser">
        /// The pp browser.
        /// </param>
        /// <returns>
        /// The get first web browser.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int GetFirstWebBrowser(ref Guid rguidPersistenceSlot, out IVsWindowFrame ppFrame, out IVsWebBrowser ppBrowser)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The get web browser enum.
        /// </summary>
        /// <param name="rguidPersistenceSlot">
        /// The rguid persistence slot.
        /// </param>
        /// <param name="ppenum">
        /// The ppenum.
        /// </param>
        /// <returns>
        /// The get web browser enum.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int GetWebBrowserEnum(ref Guid rguidPersistenceSlot, out IEnumWindowFrames ppenum)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The navigate.
        /// </summary>
        /// <param name="lpszURL">
        /// The lpsz url.
        /// </param>
        /// <param name="dwNaviageFlags">
        /// The dw naviage flags.
        /// </param>
        /// <param name="ppFrame">
        /// The pp frame.
        /// </param>
        /// <returns>
        /// The navigate.
        /// </returns>
        public int Navigate(string lpszURL, uint dwNaviageFlags, out IVsWindowFrame ppFrame)
        {
            if (this.OnNavigate != null)
            {
                this.OnNavigate(this, new NavigateEventArgs(lpszURL));
            }

            ppFrame = new MockWindowFrame();
            return VSConstants.S_OK;
        }

        #endregion

        #endregion

        /// <summary>
        /// The navigate event args.
        /// </summary>
        public class NavigateEventArgs : EventArgs
        {
            #region Constants and Fields

            public readonly string Url;

            #endregion

            #region Constructors and Destructors

            /// <summary>
            /// Initializes a new instance of the <see cref="NavigateEventArgs"/> class.
            /// </summary>
            /// <param name="url">
            /// The url.
            /// </param>
            public NavigateEventArgs(string url)
            {
                this.Url = url;
            }

            #endregion
        }
    }
}