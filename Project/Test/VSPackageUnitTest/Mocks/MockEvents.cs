//-----------------------------------------------------------------------
// <copyright file="MockEvents.cs">
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
    using System;

    class MockEvents : EnvDTE.Events
    {
        readonly MockBuildEvents _buildEvents = new MockBuildEvents();

        #region Events Members

        public EnvDTE.BuildEvents BuildEvents
        {
            get { return _buildEvents; }
        }

        public EnvDTE.DTEEvents DTEEvents
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public EnvDTE.DebuggerEvents DebuggerEvents
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public EnvDTE.FindEvents FindEvents
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public object GetObject(string Name)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public EnvDTE.ProjectItemsEvents MiscFilesEvents
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public EnvDTE.SelectionEvents SelectionEvents
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public EnvDTE.SolutionEvents SolutionEvents
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public EnvDTE.ProjectItemsEvents SolutionItemsEvents
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public object get_CommandBarEvents(object CommandBarControl)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public EnvDTE.CommandEvents get_CommandEvents(string Guid, int ID)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public EnvDTE.DocumentEvents get_DocumentEvents(EnvDTE.Document Document)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public EnvDTE.OutputWindowEvents get_OutputWindowEvents(string Pane)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public EnvDTE.TaskListEvents get_TaskListEvents(string Filter)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public EnvDTE.TextEditorEvents get_TextEditorEvents(EnvDTE.TextDocument TextDocumentFilter)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public EnvDTE.WindowEvents get_WindowEvents(EnvDTE.Window WindowFilter)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}