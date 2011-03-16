//-----------------------------------------------------------------------
// <copyright file="MockDTEProjects.cs">
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
    using Microsoft.VisualStudio.Shell.Interop;

    internal class MockDTEProjects : EnvDTE.Projects
    {
        readonly IServiceProvider _serviceProvider;
        readonly Dictionary<string, MockDTEProject> _projects = new Dictionary<string, MockDTEProject>();

        public MockDTEProjects(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        #region Projects Members

        public int Count
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public EnvDTE.DTE DTE
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public System.Collections.IEnumerator GetEnumerator()
        {
            MockSolution solution = _serviceProvider.GetService(typeof(SVsSolution)) as MockSolution;
            foreach (MockIVsProject project in solution.Projects)
            {
                if (!_projects.ContainsKey(project.FullPath))
                {
                    _projects.Add(project.FullPath, new MockDTEProject(project));
                }
                yield return _projects[project.FullPath];
            }
        }

        public EnvDTE.Project Item(object index)
        {
            return Utilities.ListFromEnum(_projects.Values)[(int)index];
        }

        public string Kind
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public EnvDTE.DTE Parent
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public EnvDTE.Properties Properties
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        #endregion
    }
}
