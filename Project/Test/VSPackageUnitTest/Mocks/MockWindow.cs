//--------------------------------------------------------------------------
// <copyright file="MockWindow.cs">
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
    internal class MockWindow : EnvDTE.Window
    {
        #region Window Members

        public void Activate()
        {
            throw new System.NotImplementedException();
        }

        public void Attach(int lWindowHandle)
        {
            throw new System.NotImplementedException();
        }

        public bool AutoHides
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
                throw new System.NotImplementedException();
            }
        }

        public string Caption
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
                throw new System.NotImplementedException();
            }
        }

        public void Close(EnvDTE.vsSaveChanges SaveChanges)
        {
            throw new System.NotImplementedException();
        }

        public EnvDTE.Windows Collection
        {
            get { throw new System.NotImplementedException(); }
        }

        public EnvDTE.ContextAttributes ContextAttributes
        {
            get { throw new System.NotImplementedException(); }
        }

        public EnvDTE.DTE DTE
        {
            get { throw new System.NotImplementedException(); }
        }

        public void Detach()
        {
            throw new System.NotImplementedException();
        }

        public EnvDTE.Document Document
        {
            get { throw new System.NotImplementedException(); }
        }

        public int HWnd
        {
            get { throw new System.NotImplementedException(); }
        }

        public int Height
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
                throw new System.NotImplementedException();
            }
        }

        public bool IsFloating
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
                throw new System.NotImplementedException();
            }
        }

        public string Kind
        {
            get { throw new System.NotImplementedException(); }
        }

        public int Left
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
                throw new System.NotImplementedException();
            }
        }

        public bool Linkable
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
                throw new System.NotImplementedException();
            }
        }

        public EnvDTE.Window LinkedWindowFrame
        {
            get { throw new System.NotImplementedException(); }
        }

        public EnvDTE.LinkedWindows LinkedWindows
        {
            get { throw new System.NotImplementedException(); }
        }

        public object Object
        {
            get { throw new System.NotImplementedException(); }
        }

        public string ObjectKind
        {
            get { throw new System.NotImplementedException(); }
        }

        public EnvDTE.Project Project
        {
            get { throw new System.NotImplementedException(); }
        }

        public EnvDTE.ProjectItem ProjectItem
        {
            get { throw new System.NotImplementedException(); }
        }

        public object Selection
        {
            get { throw new System.NotImplementedException(); }
        }

        public void SetFocus()
        {
            throw new System.NotImplementedException();
        }

        public void SetKind(EnvDTE.vsWindowType eKind)
        {
            throw new System.NotImplementedException();
        }

        public void SetSelectionContainer(ref object[] Objects)
        {
            throw new System.NotImplementedException();
        }

        public void SetTabPicture(object Picture)
        {
            throw new System.NotImplementedException();
        }

        public int Top
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
                throw new System.NotImplementedException();
            }
        }

        public EnvDTE.vsWindowType Type
        {
            get { throw new System.NotImplementedException(); }
        }

        public bool Visible
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
                throw new System.NotImplementedException();
            }
        }

        public int Width
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
                throw new System.NotImplementedException();
            }
        }

        public EnvDTE.vsWindowState WindowState
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
                throw new System.NotImplementedException();
            }
        }

        public object get_DocumentData(string bstrWhichData)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}
