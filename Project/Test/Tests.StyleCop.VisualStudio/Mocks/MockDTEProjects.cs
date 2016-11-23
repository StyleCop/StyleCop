// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MockDTEProjects.cs" company="https://github.com/StyleCop">
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
//   The mock dte projects.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace VSPackageUnitTest.Mocks
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    using EnvDTE;

    using Microsoft.VisualStudio.Shell.Interop;

    /// <summary>
    /// The mock dte projects.
    /// </summary>
    internal class MockDTEProjects : EnvDTE.Projects
    {
        #region Constants and Fields

        private readonly Dictionary<string, MockDTEProject> _projects = new Dictionary<string, MockDTEProject>();

        private readonly IServiceProvider _serviceProvider;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MockDTEProjects"/> class.
        /// </summary>
        /// <param name="serviceProvider">
        /// The service provider.
        /// </param>
        public MockDTEProjects(IServiceProvider serviceProvider)
        {
            this._serviceProvider = serviceProvider;
        }

        #endregion

        #region Properties

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

        #endregion

        #region Implemented Interfaces

        #region Projects

        /// <summary>
        /// The get enumerator.
        /// </summary>
        /// <returns>
        /// </returns>
        public IEnumerator GetEnumerator()
        {
            MockSolution solution = this._serviceProvider.GetService(typeof(SVsSolution)) as MockSolution;
            foreach (MockIVsProject project in solution.Projects)
            {
                if (!this._projects.ContainsKey(project.FullPath))
                {
                    this._projects.Add(project.FullPath, new MockDTEProject(project));
                }

                yield return this._projects[project.FullPath];
            }
        }

        /// <summary>
        /// The item.
        /// </summary>
        /// <param name="index">
        /// The index.
        /// </param>
        /// <returns>
        /// </returns>
        public Project Item(object index)
        {
            return Utilities.ListFromEnum(this._projects.Values)[(int)index];
        }

        #endregion

        #endregion
    }
}