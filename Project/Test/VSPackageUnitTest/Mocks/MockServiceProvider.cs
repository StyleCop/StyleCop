//-----------------------------------------------------------------------
// <copyright file="MockServiceProvider.cs">
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
    using System.Collections.Generic;
    using System.ComponentModel.Design;
    using System.Diagnostics;
    using System.Text;
    using EnvDTE;
    using Microsoft.VisualStudio.Shell;
    using Microsoft.VisualStudio.Shell.Interop;
    using Microsoft.VisualStudio.TestTools.MockObjects;
    using Microsoft.VisualStudio.TextManager.Interop;

    internal class MockServiceProvider : IServiceProvider
    {
        readonly MockTaskList _taskList = new MockTaskList();
        readonly MockShell _uiShell = new MockShell();
        readonly MockStatusBar _statusBar = new MockStatusBar();
        readonly MockSolution _solution = new MockSolution();
        readonly MockRDT _rdt = new MockRDT();
        readonly MockUIShellOpenDocument _uiShellOpenDoc = new MockUIShellOpenDocument();
        readonly MockTextManager _textMgr = new MockTextManager();
        readonly MockWebBrowsingService _webBrowser = new MockWebBrowsingService();
        readonly OleMenuCommandService _menuService;
        readonly MockSolutionBuildManager _BuildManager = new MockSolutionBuildManager();

        public MockServiceProvider()
        {
            _menuService = new OleMenuCommandService(this);
            this.DTE = new MockDTE(this);
        }

        public MockSolutionBuildManager MockBuildManager
        {
            get { return _BuildManager; }
        }

        public MockTaskList TaskList
        {
            get { return _taskList; }
        }

        public MockDTE DTE
        {
            get;
            set;
        }

        #region IServiceProvider Members

        public object GetService(Type serviceType)
        {
            if (serviceType == typeof(SVsTaskList))
            {
                return _taskList;
            }
            else if (serviceType == typeof(SVsUIShell))
            {
                return _uiShell;
            }
            else if (serviceType == typeof(SVsStatusbar))
            {
                return _statusBar;
            }
            else if (serviceType == typeof(DTE))
            {
                return this.DTE;
            }
            else if (serviceType == typeof(SVsSolution))
            {
                return _solution;
            }
            else if (serviceType == typeof(SVsRunningDocumentTable))
            {
                return _rdt;
            }
            else if (serviceType == typeof(SVsUIShellOpenDocument))
            {
                return _uiShellOpenDoc;
            }
            else if (serviceType == typeof(SVsTextManager))
            {
                return _textMgr;
            }
            else if (serviceType == typeof(SVsWebBrowsingService))
            {
                return _webBrowser;
            }
            else if (serviceType == typeof(IMenuCommandService))
            {
                return _menuService;
            }
            else if (serviceType == typeof(ISelectionService))
            {
                return null;
            }
            else if (serviceType == typeof(IDesignerHost))
            {
                return null;
            }
            else if (serviceType == typeof(SVsSolutionBuildManager))
            {
                return this._BuildManager;
            }
            else
            {
                Debug.Fail("Service " + serviceType + " not found.");
                return null;
            }
        }

        #endregion
    }
}
