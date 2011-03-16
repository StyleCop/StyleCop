//-----------------------------------------------------------------------
// <copyright file="MockWindowFrame.cs">
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
    using System.Runtime.InteropServices;
    using Microsoft.VisualStudio;
    using Microsoft.VisualStudio.Shell.Interop;
    using Microsoft.VisualStudio.TextManager.Interop;
    
    internal class MockWindowFrame : IVsWindowFrame
    {
        public MockTextLines TextLines = null;

        #region IVsWindowFrame Members

        public int CloseFrame(uint grfSaveOptions)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int GetFramePos(VSSETFRAMEPOS[] pdwSFP, out Guid pguidRelativeTo, out int px, out int py, out int pcx, out int pcy)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int GetGuidProperty(int propid, out Guid pguid)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int GetProperty(int propid, out object pvar)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int Hide()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int IsOnScreen(out int pfOnScreen)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int IsVisible()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int QueryViewInterface(ref Guid riid, out IntPtr ppv)
        {
            if (riid == typeof(IVsTextLines).GUID)
            {
                ppv = Marshal.GetIUnknownForObject(TextLines);
                return VSConstants.S_OK;
            }
            else
            {
                ppv = IntPtr.Zero;
                return VSConstants.E_NOINTERFACE;
            }
        }

        public int SetFramePos(VSSETFRAMEPOS dwSFP, ref Guid rguidRelativeTo, int x, int y, int cx, int cy)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int SetGuidProperty(int propid, ref Guid rguid)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int SetProperty(int propid, object var)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int Show()
        {
            return VSConstants.S_OK;
        }

        public int ShowNoActivate()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}

