//-----------------------------------------------------------------------
// <copyright file="MockDTEProject.cs" company="Microsoft">
//   Copyright (c) Microsoft Corporation.
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
    using System;
    using System.Collections.Generic;
    using System.Text;
    
    class MockDTEProject : EnvDTE.Project
    {
        readonly MockIVsProject _project;
        readonly MockDTEGlobals _globals = new MockDTEGlobals();

        public MockDTEProject(MockIVsProject project)
        {
            _project = project;
        }

        #region Project Members

        public EnvDTE.CodeModel CodeModel
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public EnvDTE.Projects Collection
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public EnvDTE.ConfigurationManager ConfigurationManager
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public EnvDTE.DTE DTE
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public void Delete()
        {
            throw new Exception("The method or operation is not implemented.");
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
            get { return _project.FullPath; }
        }

        public string FullName
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public EnvDTE.Globals Globals
        {
            get { return _globals; }
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

        public string Kind
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

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

        public object Object
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public EnvDTE.ProjectItem ParentProjectItem
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public EnvDTE.ProjectItems ProjectItems
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public EnvDTE.Properties Properties
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public void Save(string FileName)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void SaveAs(string NewFileName)
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

        public string UniqueName
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public object get_Extender(string ExtenderName)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
