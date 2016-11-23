// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MockServiceProvider.cs" company="https://github.com/StyleCop">
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
//   The mock service provider.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace VSPackageUnitTest.Mocks
{
    using System;
    using System.ComponentModel.Design;
    using System.Diagnostics;

    using EnvDTE;

    using Microsoft.VisualStudio.Shell;
    using Microsoft.VisualStudio.Shell.Interop;
    using Microsoft.VisualStudio.TextManager.Interop;

    /// <summary>
    /// The mock service provider.
    /// </summary>
    internal class MockServiceProvider : IServiceProvider
    {
        #region Constants and Fields

        private readonly MockSolutionBuildManager _BuildManager = new MockSolutionBuildManager();

        private readonly OleMenuCommandService _menuService;

        private readonly MockRDT _rdt = new MockRDT();

        private readonly MockSolution _solution = new MockSolution();

        private readonly MockStatusBar _statusBar = new MockStatusBar();

        private readonly MockTaskList _taskList = new MockTaskList();

        private readonly MockTextManager _textMgr = new MockTextManager();

        private readonly MockShell _uiShell = new MockShell();

        private readonly MockUIShellOpenDocument _uiShellOpenDoc = new MockUIShellOpenDocument();

        private readonly MockWebBrowsingService _webBrowser = new MockWebBrowsingService();

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MockServiceProvider"/> class.
        /// </summary>
        public MockServiceProvider()
        {
            this._menuService = new OleMenuCommandService(this);
            this.DTE = new MockDTE(this);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets DTE.
        /// </summary>
        public MockDTE DTE { get; set; }

        /// <summary>
        /// Gets MockBuildManager.
        /// </summary>
        public MockSolutionBuildManager MockBuildManager
        {
            get
            {
                return this._BuildManager;
            }
        }

        /// <summary>
        /// Gets TaskList.
        /// </summary>
        public MockTaskList TaskList
        {
            get
            {
                return this._taskList;
            }
        }

        #endregion

        #region Implemented Interfaces

        #region IServiceProvider

        /// <summary>
        /// The get service.
        /// </summary>
        /// <param name="serviceType">
        /// The service type.
        /// </param>
        /// <returns>
        /// The get service.
        /// </returns>
        public object GetService(Type serviceType)
        {
            if (serviceType == typeof(SVsTaskList))
            {
                return this._taskList;
            }
            else if (serviceType == typeof(SVsUIShell))
            {
                return this._uiShell;
            }
            else if (serviceType == typeof(SVsStatusbar))
            {
                return this._statusBar;
            }
            else if (serviceType == typeof(DTE))
            {
                return this.DTE;
            }
            else if (serviceType == typeof(SVsSolution))
            {
                return this._solution;
            }
            else if (serviceType == typeof(SVsRunningDocumentTable))
            {
                return this._rdt;
            }
            else if (serviceType == typeof(SVsUIShellOpenDocument))
            {
                return this._uiShellOpenDoc;
            }
            else if (serviceType == typeof(SVsTextManager))
            {
                return this._textMgr;
            }
            else if (serviceType == typeof(SVsWebBrowsingService))
            {
                return this._webBrowser;
            }
            else if (serviceType == typeof(IMenuCommandService))
            {
                return this._menuService;
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

        #endregion
    }
}