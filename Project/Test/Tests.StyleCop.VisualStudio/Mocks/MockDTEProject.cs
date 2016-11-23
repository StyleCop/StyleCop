// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MockDTEProject.cs" company="https://github.com/StyleCop">
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
//   The mock dte project.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace VSPackageUnitTest.Mocks
{
    using System;

    using EnvDTE;

    /// <summary>
    /// The mock dte project.
    /// </summary>
    internal class MockDTEProject : EnvDTE.Project
    {
        #region Constants and Fields

        private readonly MockDTEGlobals _globals = new MockDTEGlobals();

        private readonly MockIVsProject _project;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MockDTEProject"/> class.
        /// </summary>
        /// <param name="project">
        /// The project.
        /// </param>
        public MockDTEProject(MockIVsProject project)
        {
            this._project = project;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets CodeModel.
        /// </summary>
        /// <exception cref="Exception">
        /// </exception>
        public CodeModel CodeModel
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        /// <summary>
        /// Gets Collection.
        /// </summary>
        /// <exception cref="Exception">
        /// </exception>
        public Projects Collection
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        /// <summary>
        /// Gets ConfigurationManager.
        /// </summary>
        /// <exception cref="Exception">
        /// </exception>
        public ConfigurationManager ConfigurationManager
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        /// <summary>
        /// Gets DTE.
        /// </summary>
        /// <exception cref="Exception">
        /// </exception>
        public DTE DTE
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        /// <summary>
        /// Gets ExtenderCATID.
        /// </summary>
        /// <exception cref="Exception">
        /// </exception>
        public string ExtenderCATID
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        /// <summary>
        /// Gets ExtenderNames.
        /// </summary>
        /// <exception cref="Exception">
        /// </exception>
        public object ExtenderNames
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        /// <summary>
        /// Gets FileName.
        /// </summary>
        public string FileName
        {
            get
            {
                return this._project.FullPath;
            }
        }

        /// <summary>
        /// Gets FullName.
        /// </summary>
        /// <exception cref="Exception">
        /// </exception>
        public string FullName
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        /// <summary>
        /// Gets Globals.
        /// </summary>
        public Globals Globals
        {
            get
            {
                return this._globals;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether IsDirty.
        /// </summary>
        /// <exception cref="Exception">
        /// </exception>
        /// <exception cref="Exception">
        /// </exception>
        public bool IsDirty
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }

            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        /// <summary>
        /// Gets Kind.
        /// </summary>
        /// <exception cref="Exception">
        /// </exception>
        public string Kind
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        /// <summary>
        /// Gets or sets Name.
        /// </summary>
        /// <exception cref="Exception">
        /// </exception>
        /// <exception cref="Exception">
        /// </exception>
        public string Name
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }

            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        /// <summary>
        /// Gets Object.
        /// </summary>
        /// <exception cref="Exception">
        /// </exception>
        public object Object
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        /// <summary>
        /// Gets ParentProjectItem.
        /// </summary>
        /// <exception cref="Exception">
        /// </exception>
        public ProjectItem ParentProjectItem
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        /// <summary>
        /// Gets ProjectItems.
        /// </summary>
        /// <exception cref="Exception">
        /// </exception>
        public ProjectItems ProjectItems
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        /// <summary>
        /// Gets Properties.
        /// </summary>
        /// <exception cref="Exception">
        /// </exception>
        public Properties Properties
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether Saved.
        /// </summary>
        /// <exception cref="Exception">
        /// </exception>
        /// <exception cref="Exception">
        /// </exception>
        public bool Saved
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }

            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        /// <summary>
        /// Gets UniqueName.
        /// </summary>
        /// <exception cref="Exception">
        /// </exception>
        public string UniqueName
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        #endregion

        #region Implemented Interfaces

        #region Project

        /// <summary>
        /// The delete.
        /// </summary>
        /// <exception cref="Exception">
        /// </exception>
        public void Delete()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The save.
        /// </summary>
        /// <param name="fileName">
        /// The file name.
        /// </param>
        /// <exception cref="Exception">
        /// </exception>
        public void Save(string fileName)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The save as.
        /// </summary>
        /// <param name="NewFileName">
        /// The new file name.
        /// </param>
        /// <exception cref="Exception">
        /// </exception>
        public void SaveAs(string NewFileName)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The get_ extender.
        /// </summary>
        /// <param name="extenderName">
        /// The extender name.
        /// </param>
        /// <returns>
        /// The get_ extender.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public object get_Extender(string extenderName)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        #endregion
    }
}