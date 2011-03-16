//-----------------------------------------------------------------------
// <copyright file="MockDTESolution.cs">
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

    class MockDTESolution : EnvDTE.Solution
    {
        readonly IServiceProvider _serviceProvider;
        readonly MockDTEProjects _projects;

        public MockDTESolution(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _projects = new MockDTEProjects(_serviceProvider);
        }

        #region _Solution Members

        public EnvDTE.Project AddFromFile(string FileName, bool Exclusive)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public EnvDTE.Project AddFromTemplate(string FileName, string Destination, string ProjectName, bool Exclusive)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public EnvDTE.AddIns AddIns
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public void Close(bool SaveFirst)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int Count
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public void Create(string Destination, string Name)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public EnvDTE.DTE DTE
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public string ExtenderCATID
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public object ExtenderNames
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public string FileName
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public EnvDTE.ProjectItem FindProjectItem(string FileName)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public string FullName
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public System.Collections.IEnumerator GetEnumerator()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public EnvDTE.Globals Globals
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

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

        public bool IsOpen
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public EnvDTE.Project Item(object index)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Open(string FileName)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public EnvDTE.DTE Parent
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public string ProjectItemsTemplatePath(string ProjectKind)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public EnvDTE.Projects Projects
        {
            get { return _projects; }
        }

        public EnvDTE.Properties Properties
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public void Remove(EnvDTE.Project proj)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void SaveAs(string FileName)
        {
            throw new Exception("The method or operation is not implemented.");
        }

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

        public EnvDTE.SolutionBuild SolutionBuild
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public object get_Extender(string ExtenderName)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public string get_TemplatePath(string ProjectType)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
