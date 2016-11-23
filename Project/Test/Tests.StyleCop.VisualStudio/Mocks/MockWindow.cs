// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MockWindow.cs" company="https://github.com/StyleCop">
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
//   The mock window.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace VSPackageUnitTest.Mocks
{
    using System;

    using EnvDTE;

    /// <summary>
    /// The mock window.
    /// </summary>
    internal class MockWindow : EnvDTE.Window
    {
        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether AutoHides.
        /// </summary>
        /// <exception cref="NotImplementedException">
        /// </exception>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public bool AutoHides
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Gets or sets Caption.
        /// </summary>
        /// <exception cref="NotImplementedException">
        /// </exception>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public string Caption
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Gets Collection.
        /// </summary>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public Windows Collection
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Gets ContextAttributes.
        /// </summary>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public ContextAttributes ContextAttributes
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Gets DTE.
        /// </summary>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public DTE DTE
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Gets Document.
        /// </summary>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public Document Document
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Gets HWnd.
        /// </summary>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public int HWnd
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Gets or sets Height.
        /// </summary>
        /// <exception cref="NotImplementedException">
        /// </exception>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public int Height
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether IsFloating.
        /// </summary>
        /// <exception cref="NotImplementedException">
        /// </exception>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public bool IsFloating
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Gets Kind.
        /// </summary>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public string Kind
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Gets or sets Left.
        /// </summary>
        /// <exception cref="NotImplementedException">
        /// </exception>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public int Left
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether Linkable.
        /// </summary>
        /// <exception cref="NotImplementedException">
        /// </exception>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public bool Linkable
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Gets LinkedWindowFrame.
        /// </summary>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public Window LinkedWindowFrame
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Gets LinkedWindows.
        /// </summary>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public LinkedWindows LinkedWindows
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Gets Object.
        /// </summary>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public object Object
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Gets ObjectKind.
        /// </summary>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public string ObjectKind
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Gets Project.
        /// </summary>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public Project Project
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Gets ProjectItem.
        /// </summary>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public ProjectItem ProjectItem
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Gets Selection.
        /// </summary>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public object Selection
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Gets or sets Top.
        /// </summary>
        /// <exception cref="NotImplementedException">
        /// </exception>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public int Top
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Gets Type.
        /// </summary>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public vsWindowType Type
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether Visible.
        /// </summary>
        /// <exception cref="NotImplementedException">
        /// </exception>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public bool Visible
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Gets or sets Width.
        /// </summary>
        /// <exception cref="NotImplementedException">
        /// </exception>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public int Width
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Gets or sets WindowState.
        /// </summary>
        /// <exception cref="NotImplementedException">
        /// </exception>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public vsWindowState WindowState
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        #endregion

        #region Implemented Interfaces

        #region Window

        /// <summary>
        /// The activate.
        /// </summary>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public void Activate()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The attach.
        /// </summary>
        /// <param name="lWindowHandle">
        /// The l window handle.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public void Attach(int lWindowHandle)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The close.
        /// </summary>
        /// <param name="SaveChanges">
        /// The save changes.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public void Close(vsSaveChanges SaveChanges)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The detach.
        /// </summary>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public void Detach()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The set focus.
        /// </summary>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public void SetFocus()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The set kind.
        /// </summary>
        /// <param name="eKind">
        /// The e kind.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public void SetKind(vsWindowType eKind)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The set selection container.
        /// </summary>
        /// <param name="Objects">
        /// The objects.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public void SetSelectionContainer(ref object[] Objects)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The set tab picture.
        /// </summary>
        /// <param name="Picture">
        /// The picture.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public void SetTabPicture(object Picture)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The get_ document data.
        /// </summary>
        /// <param name="bstrWhichData">
        /// The bstr which data.
        /// </param>
        /// <returns>
        /// The get_ document data.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public object get_DocumentData(string bstrWhichData)
        {
            throw new NotImplementedException();
        }

        #endregion

        #endregion
    }
}