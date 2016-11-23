// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MockDTESolution.cs" company="https://github.com/StyleCop">
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
//   The mock dte solution.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace VSPackageUnitTest.Mocks
{
    using System;
    using System.Collections;

    using EnvDTE;

    /// <summary>
    /// The mock dte solution.
    /// </summary>
    internal class MockDTESolution : EnvDTE.Solution
    {
        #region Constants and Fields

        private readonly MockDTEProjects _projects;

        private readonly IServiceProvider _serviceProvider;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MockDTESolution"/> class.
        /// </summary>
        /// <param name="serviceProvider">
        /// The service provider.
        /// </param>
        public MockDTESolution(IServiceProvider serviceProvider)
        {
            this._serviceProvider = serviceProvider;
            this._projects = new MockDTEProjects(this._serviceProvider);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets AddIns.
        /// </summary>
        /// <exception cref="Exception">
        /// </exception>
        public AddIns AddIns
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        /// <summary>
        /// Gets Count.
        /// </summary>
        /// <exception cref="Exception">
        /// </exception>
        public int Count
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
        /// <exception cref="Exception">
        /// </exception>
        public string FileName
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
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
        /// <exception cref="Exception">
        /// </exception>
        public Globals Globals
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
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
        /// Gets a value indicating whether IsOpen.
        /// </summary>
        /// <exception cref="Exception">
        /// </exception>
        public bool IsOpen
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        /// <summary>
        /// Gets Parent.
        /// </summary>
        /// <exception cref="Exception">
        /// </exception>
        public DTE Parent
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        /// <summary>
        /// Gets Projects.
        /// </summary>
        public Projects Projects
        {
            get
            {
                return this._projects;
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
        /// Gets SolutionBuild.
        /// </summary>
        /// <exception cref="Exception">
        /// </exception>
        public SolutionBuild SolutionBuild
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        #endregion

        #region Implemented Interfaces

        #region _Solution

        /// <summary>
        /// The add from file.
        /// </summary>
        /// <param name="FileName">
        /// The file name.
        /// </param>
        /// <param name="Exclusive">
        /// The exclusive.
        /// </param>
        /// <returns>
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public Project AddFromFile(string FileName, bool Exclusive)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The add from template.
        /// </summary>
        /// <param name="FileName">
        /// The file name.
        /// </param>
        /// <param name="Destination">
        /// The destination.
        /// </param>
        /// <param name="ProjectName">
        /// The project name.
        /// </param>
        /// <param name="Exclusive">
        /// The exclusive.
        /// </param>
        /// <returns>
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public Project AddFromTemplate(string FileName, string Destination, string ProjectName, bool Exclusive)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The close.
        /// </summary>
        /// <param name="SaveFirst">
        /// The save first.
        /// </param>
        /// <exception cref="Exception">
        /// </exception>
        public void Close(bool SaveFirst)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="Destination">
        /// The destination.
        /// </param>
        /// <param name="Name">
        /// The name.
        /// </param>
        /// <exception cref="Exception">
        /// </exception>
        public void Create(string Destination, string Name)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The find project item.
        /// </summary>
        /// <param name="FileName">
        /// The file name.
        /// </param>
        /// <returns>
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public ProjectItem FindProjectItem(string FileName)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The get enumerator.
        /// </summary>
        /// <returns>
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public IEnumerator GetEnumerator()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The item.
        /// </summary>
        /// <param name="index">
        /// The index.
        /// </param>
        /// <returns>
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public Project Item(object index)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The open.
        /// </summary>
        /// <param name="FileName">
        /// The file name.
        /// </param>
        /// <exception cref="Exception">
        /// </exception>
        public void Open(string FileName)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The project items template path.
        /// </summary>
        /// <param name="ProjectKind">
        /// The project kind.
        /// </param>
        /// <returns>
        /// The project items template path.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public string ProjectItemsTemplatePath(string ProjectKind)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The remove.
        /// </summary>
        /// <param name="proj">
        /// The proj.
        /// </param>
        /// <exception cref="Exception">
        /// </exception>
        public void Remove(Project proj)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The save as.
        /// </summary>
        /// <param name="FileName">
        /// The file name.
        /// </param>
        /// <exception cref="Exception">
        /// </exception>
        public void SaveAs(string FileName)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The get_ extender.
        /// </summary>
        /// <param name="ExtenderName">
        /// The extender name.
        /// </param>
        /// <returns>
        /// The get_ extender.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public object get_Extender(string ExtenderName)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The get_ template path.
        /// </summary>
        /// <param name="ProjectType">
        /// The project type.
        /// </param>
        /// <returns>
        /// The get_ template path.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public string get_TemplatePath(string ProjectType)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        #endregion
    }
}