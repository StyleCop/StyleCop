// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MockWindowFrame.cs" company="https://github.com/StyleCop">
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
//   The mock window frame.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace VSPackageUnitTest.Mocks
{
    using System;
    using System.Runtime.InteropServices;

    using Microsoft.VisualStudio;
    using Microsoft.VisualStudio.Shell.Interop;
    using Microsoft.VisualStudio.TextManager.Interop;

    /// <summary>
    /// The mock window frame.
    /// </summary>
    internal class MockWindowFrame : IVsWindowFrame
    {
        #region Constants and Fields

        public MockTextLines TextLines = null;

        #endregion

        #region Implemented Interfaces

        #region IVsWindowFrame

        /// <summary>
        /// The close frame.
        /// </summary>
        /// <param name="grfSaveOptions">
        /// The grf save options.
        /// </param>
        /// <returns>
        /// The close frame.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int CloseFrame(uint grfSaveOptions)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The get frame pos.
        /// </summary>
        /// <param name="pdwSFP">
        /// The pdw sfp.
        /// </param>
        /// <param name="pguidRelativeTo">
        /// The pguid relative to.
        /// </param>
        /// <param name="px">
        /// The px.
        /// </param>
        /// <param name="py">
        /// The py.
        /// </param>
        /// <param name="pcx">
        /// The pcx.
        /// </param>
        /// <param name="pcy">
        /// The pcy.
        /// </param>
        /// <returns>
        /// The get frame pos.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int GetFramePos(VSSETFRAMEPOS[] pdwSFP, out Guid pguidRelativeTo, out int px, out int py, out int pcx, out int pcy)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The get guid property.
        /// </summary>
        /// <param name="propid">
        /// The propid.
        /// </param>
        /// <param name="pguid">
        /// The pguid.
        /// </param>
        /// <returns>
        /// The get guid property.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int GetGuidProperty(int propid, out Guid pguid)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The get property.
        /// </summary>
        /// <param name="propid">
        /// The propid.
        /// </param>
        /// <param name="pvar">
        /// The pvar.
        /// </param>
        /// <returns>
        /// The get property.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int GetProperty(int propid, out object pvar)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The hide.
        /// </summary>
        /// <returns>
        /// The hide.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int Hide()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The is on screen.
        /// </summary>
        /// <param name="pfOnScreen">
        /// The pf on screen.
        /// </param>
        /// <returns>
        /// The is on screen.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int IsOnScreen(out int pfOnScreen)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The is visible.
        /// </summary>
        /// <returns>
        /// The is visible.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int IsVisible()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The query view interface.
        /// </summary>
        /// <param name="riid">
        /// The riid.
        /// </param>
        /// <param name="ppv">
        /// The ppv.
        /// </param>
        /// <returns>
        /// The query view interface.
        /// </returns>
        public int QueryViewInterface(ref Guid riid, out IntPtr ppv)
        {
            if (riid == typeof(IVsTextLines).GUID)
            {
                ppv = Marshal.GetIUnknownForObject(this.TextLines);
                return VSConstants.S_OK;
            }
            else
            {
                ppv = IntPtr.Zero;
                return VSConstants.E_NOINTERFACE;
            }
        }

        /// <summary>
        /// The set frame pos.
        /// </summary>
        /// <param name="dwSFP">
        /// The dw sfp.
        /// </param>
        /// <param name="rguidRelativeTo">
        /// The rguid relative to.
        /// </param>
        /// <param name="x">
        /// The x.
        /// </param>
        /// <param name="y">
        /// The y.
        /// </param>
        /// <param name="cx">
        /// The cx.
        /// </param>
        /// <param name="cy">
        /// The cy.
        /// </param>
        /// <returns>
        /// The set frame pos.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int SetFramePos(VSSETFRAMEPOS dwSFP, ref Guid rguidRelativeTo, int x, int y, int cx, int cy)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The set guid property.
        /// </summary>
        /// <param name="propid">
        /// The propid.
        /// </param>
        /// <param name="rguid">
        /// The rguid.
        /// </param>
        /// <returns>
        /// The set guid property.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int SetGuidProperty(int propid, ref Guid rguid)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The set property.
        /// </summary>
        /// <param name="propid">
        /// The propid.
        /// </param>
        /// <param name="var">
        /// The var.
        /// </param>
        /// <returns>
        /// The set property.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int SetProperty(int propid, object var)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The show.
        /// </summary>
        /// <returns>
        /// The show.
        /// </returns>
        public int Show()
        {
            return VSConstants.S_OK;
        }

        /// <summary>
        /// The show no activate.
        /// </summary>
        /// <returns>
        /// The show no activate.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int ShowNoActivate()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        #endregion
    }
}