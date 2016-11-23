// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MockDTE.cs" company="https://github.com/StyleCop">
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
//   The mock dte.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace VSPackageUnitTest.Mocks
{
    using System;

    using EnvDTE;

    /// <summary>
    /// The mock dte.
    /// </summary>
    internal class MockDTE : EnvDTE.DTE
    {
        #region Constants and Fields

        private readonly MockEvents _events = new MockEvents();

        private readonly IServiceProvider _serviceProvider;

        private readonly MockDTESolution _solution;

        private readonly MockDocuments _documents;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MockDTE"/> class.
        /// </summary>
        /// <param name="serviceProvider">
        /// The service provider.
        /// </param>
        public MockDTE(IServiceProvider serviceProvider)
        {
            this._serviceProvider = serviceProvider;
            this._solution = new MockDTESolution(this._serviceProvider);
            this._documents = new MockDocuments(this);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets ActiveDocument.
        /// </summary>
        /// <exception cref="Exception">
        /// </exception>
        public Document ActiveDocument
        {
            get
            {
                return new MockDocument();
            }
        }

        /// <summary>
        /// Gets ActiveSolutionProjects.
        /// </summary>
        /// <exception cref="Exception">
        /// </exception>
        public object ActiveSolutionProjects
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        /// <summary>
        /// Gets ActiveWindow.
        /// </summary>
        /// <exception cref="Exception">
        /// </exception>
        public Window ActiveWindow
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

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
        /// Gets Application.
        /// </summary>
        /// <exception cref="Exception">
        /// </exception>
        public DTE Application
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        /// <summary>
        /// Gets CommandBars.
        /// </summary>
        /// <exception cref="Exception">
        /// </exception>
        public object CommandBars
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        /// <summary>
        /// Gets CommandLineArguments.
        /// </summary>
        /// <exception cref="Exception">
        /// </exception>
        public string CommandLineArguments
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        /// <summary>
        /// Gets Commands.
        /// </summary>
        /// <exception cref="Exception">
        /// </exception>
        public Commands Commands
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        /// <summary>
        /// Gets ContextAttributes.
        /// </summary>
        /// <exception cref="Exception">
        /// </exception>
        public ContextAttributes ContextAttributes
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
        /// Gets Debugger.
        /// </summary>
        /// <exception cref="Exception">
        /// </exception>
        public Debugger Debugger
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        /// <summary>
        /// Gets or sets DisplayMode.
        /// </summary>
        /// <exception cref="Exception">
        /// </exception>
        /// <exception cref="Exception">
        /// </exception>
        public vsDisplay DisplayMode
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
        /// Gets Documents.
        /// </summary>
        /// <exception cref="Exception">
        /// </exception>
        public Documents Documents
        {
            get
            {
                return this._documents;
            }
        }

        /// <summary>
        /// Gets Edition.
        /// </summary>
        /// <exception cref="Exception">
        /// </exception>
        public string Edition
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        /// <summary>
        /// Gets Events.
        /// </summary>
        public Events Events
        {
            get
            {
                return this._events;
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
        /// Gets Find.
        /// </summary>
        /// <exception cref="Exception">
        /// </exception>
        public Find Find
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
        /// Gets ItemOperations.
        /// </summary>
        /// <exception cref="Exception">
        /// </exception>
        public ItemOperations ItemOperations
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        /// <summary>
        /// Gets LocaleID.
        /// </summary>
        /// <exception cref="Exception">
        /// </exception>
        public int LocaleID
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        /// <summary>
        /// Gets Macros.
        /// </summary>
        /// <exception cref="Exception">
        /// </exception>
        public Macros Macros
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        /// <summary>
        /// Gets MacrosIDE.
        /// </summary>
        /// <exception cref="Exception">
        /// </exception>
        public DTE MacrosIDE
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        /// <summary>
        /// Gets MainWindow.
        /// </summary>
        /// <exception cref="Exception">
        /// </exception>
        public Window MainWindow
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        /// <summary>
        /// Gets Mode.
        /// </summary>
        /// <exception cref="Exception">
        /// </exception>
        public vsIDEMode Mode
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        /// <summary>
        /// Gets Name.
        /// </summary>
        /// <exception cref="Exception">
        /// </exception>
        public string Name
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        /// <summary>
        /// Gets ObjectExtenders.
        /// </summary>
        /// <exception cref="Exception">
        /// </exception>
        public ObjectExtenders ObjectExtenders
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        /// <summary>
        /// Gets RegistryRoot.
        /// </summary>
        /// <exception cref="Exception">
        /// </exception>
        public string RegistryRoot
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        /// <summary>
        /// Gets SelectedItems.
        /// </summary>
        /// <exception cref="Exception">
        /// </exception>
        public SelectedItems SelectedItems
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        /// <summary>
        /// Gets Solution.
        /// </summary>
        public Solution Solution
        {
            get
            {
                return this._solution;
            }
        }

        /// <summary>
        /// Gets SourceControl.
        /// </summary>
        /// <exception cref="Exception">
        /// </exception>
        public SourceControl SourceControl
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        /// <summary>
        /// Gets StatusBar.
        /// </summary>
        /// <exception cref="Exception">
        /// </exception>
        public StatusBar StatusBar
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether SuppressUI.
        /// </summary>
        /// <exception cref="Exception">
        /// </exception>
        /// <exception cref="Exception">
        /// </exception>
        public bool SuppressUI
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
        /// Gets UndoContext.
        /// </summary>
        /// <exception cref="Exception">
        /// </exception>
        public UndoContext UndoContext
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether UserControl.
        /// </summary>
        /// <exception cref="Exception">
        /// </exception>
        /// <exception cref="Exception">
        /// </exception>
        public bool UserControl
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
        /// Gets Version.
        /// </summary>
        /// <exception cref="Exception">
        /// </exception>
        public string Version
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        /// <summary>
        /// Gets WindowConfigurations.
        /// </summary>
        /// <exception cref="Exception">
        /// </exception>
        public WindowConfigurations WindowConfigurations
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        /// <summary>
        /// Gets or sets Windows.
        /// </summary>
        public Windows Windows { get; set; }

        #endregion

        #region Implemented Interfaces

        #region _DTE

        /// <summary>
        /// The execute command.
        /// </summary>
        /// <param name="commandName">
        /// The command name.
        /// </param>
        /// <param name="commandArgs">
        /// The command args.
        /// </param>
        /// <exception cref="Exception">
        /// </exception>
        public void ExecuteCommand(string commandName, string commandArgs)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The get object.
        /// </summary>
        /// <param name="Name">
        /// The name.
        /// </param>
        /// <returns>
        /// The get object.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public object GetObject(string Name)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The launch wizard.
        /// </summary>
        /// <param name="file">
        /// The vsz file.
        /// </param>
        /// <param name="contextParams">
        /// The context params.
        /// </param>
        /// <returns>
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public wizardResult LaunchWizard(string file, ref object[] contextParams)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The open file.
        /// </summary>
        /// <param name="viewKind">
        /// The view kind.
        /// </param>
        /// <param name="fileName">
        /// The file name.
        /// </param>
        /// <returns>
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public Window OpenFile(string viewKind, string fileName)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The quit.
        /// </summary>
        /// <exception cref="Exception">
        /// </exception>
        public void Quit()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The satellite dll path.
        /// </summary>
        /// <param name="path">
        /// The path.
        /// </param>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <returns>
        /// The satellite path.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public string SatelliteDllPath(string path, string name)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The get_ is open file.
        /// </summary>
        /// <param name="viewKind">
        /// The view kind.
        /// </param>
        /// <param name="fileName">
        /// The file name.
        /// </param>
        /// <returns>
        /// The get_ is open file.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public bool get_IsOpenFile(string viewKind, string fileName)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The get_ properties.
        /// </summary>
        /// <param name="Category">
        /// The category.
        /// </param>
        /// <param name="Page">
        /// The page.
        /// </param>
        /// <returns>
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public Properties get_Properties(string Category, string Page)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        #endregion
    }
}