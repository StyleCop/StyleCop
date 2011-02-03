//-----------------------------------------------------------------------
// <copyright file="StyleCopVSPackage.cs">
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
namespace StyleCop.VisualStudio
{
    using System;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.InteropServices;
    using Microsoft.VisualStudio.Shell;
    using Microsoft.VisualStudio.Shell.Interop;
    using StyleCop;

    /// <summary>
    /// Provides a Visual Studio package for StyleCop.
    /// </summary>
    [PackageRegistration(UseManagedResourcesOnly = true)]
    [DefaultRegistryRoot("Software\\Microsoft\\VisualStudio\\10.0")]
    [InstalledProductRegistration(false, "#110", "#112", "4.4", IconResourceID = 400)]
    [ProvideAutoLoad(/*UICONTEXT_SolutionExists*/ "f1536ef8-92ec-443c-9ed7-fdadf150da82")]
    [ProvideLoadKey("Standard", "4.4", "StyleCop", "Microsoft PLK", 200)]
    [ProvideMenuResource(1000, 1)]
    [Guid(GuidList.StyleCopPackageIdString)]
    [SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling", Justification = "The class is complex.")]
    public sealed class StyleCopVSPackage : Package, IDisposable
    {
        #region Private Fields

        /// <summary>
        /// The helper class for performing analysis.
        /// </summary>
        private AnalysisHelper helper;

        /// <summary>
        /// The StyleCop core object.
        /// </summary>
        private StyleCopCore core;

        /// <summary>
        /// Handles the menu commands at the Package level.
        /// </summary>
        private PackageCommandSet commandSet;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the StyleCopVSPackage class.
        /// </summary>
        /// <remarks>When the constructor is called, the package is not sited yet within Visual Studio.
        /// To peform initialization after the package has been sited, place the initialization code within
        /// the Initialize method.</remarks>
        public StyleCopVSPackage()
        {
            ProjectUtilities.Initialize(this);
        }

        #endregion Public Constructors

        #region Private Delegates

        /// <summary>
        /// Delegate for text added to the output pane.
        /// </summary>
        /// <param name="output">The text to add.</param>
        private delegate void AddOutputEventHandler(string output);

        #endregion Private Delegates

        #region Internal Properties

        /// <summary>
        /// Gets the StyleCop core object.
        /// </summary>
        internal StyleCopCore Core
        {
            get
            {
                if (this.core == null)
                {
                    this.core = new StyleCopCore();
                }

                return this.core;
            }
        }

        /// <summary>
        /// Gets the helper class for performing analysis.
        /// </summary>
        internal AnalysisHelper Helper
        {
            get
            {
                if (this.helper == null)
                {
                    this.helper = new FileAnalysisHelper(this, this.Core);
                }

                return this.helper;
            }
        }

        #endregion Internal Properties

        #region Private Properties

        /// <summary>
        /// Gets a value indicating whether the package is running in setup mode.
        /// </summary>
        private bool SetupMode
        {
            get
            {
                // Are we running with /setup?
                IVsAppCommandLine commandLine = (IVsAppCommandLine)GetService(typeof(IVsAppCommandLine));
                int present;
                string value;

                Microsoft.VisualStudio.ErrorHandler.ThrowOnFailure(commandLine.GetOption("setup", out present, out value));
                return present == 1;
            }
        }

        #endregion Private Properties

        #region Public Methods

        /// <summary>
        /// Disposes the contents of the class.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Writes a line of output to the output window.
        /// </summary>
        /// <param name="output">The text to output.</param>
        public void AddOutput(string output)
        {
            Param.RequireNotNull(output, "output");

            if (InvisibleForm.Instance.InvokeRequired)
            {
                AddOutputEventHandler outputDelegate = new AddOutputEventHandler(this.AddOutput);
                InvisibleForm.Instance.Invoke(outputDelegate, output);
            }
            else
            {
                EnvDTE.OutputWindowPane pane = VSWindows.GetInstance(this).OutputPane;
                if (pane != null)
                {
                    pane.OutputString(output);
                }
            }
        }

        #endregion Public Methods

        #region Internal Methods

        #endregion Internal Methods

        #region Protected Override Methods

        /// <summary>
        /// Initializes the package.
        /// </summary>
        /// <remarks>This method is called right after the package is sited, so this is the place to initialize
        /// code that relies on services provided by Visual Studio.</remarks>
        protected override void Initialize()
        {
            base.Initialize();

            if (!this.SetupMode)
            {
                System.ComponentModel.Design.IServiceContainer sc = (System.ComponentModel.Design.IServiceContainer)this;
                sc.AddService(typeof(IVsPackage), this, false);

                // Ensure that the IDE enviroment is available.
                EnvDTE.DTE dte = (EnvDTE.DTE)this.GetService(typeof(EnvDTE.DTE));
                if (dte == null)
                {
                    throw new InvalidOperationException(Strings.CouldNotGetVSEnvironment);
                }

                this.Core.Initialize(null, true);

                this.Helper.Initialize();

                // Ensuring that the form is created on the UI thread.
                if (InvisibleForm.Instance == null)
                {
                    throw new InvalidOperationException(Strings.NoInvisbileForm);
                }

                // Set up the menu items.
                this.AddMenuItems();
            }
        }

        /// <summary>
        /// Disposes the contents of the class.
        /// </summary>
        /// <param name="disposing">Indicates whether to dispose managed resources.</param>
        protected override void Dispose(bool disposing)
        {
            Param.Ignore(disposing);
            base.Dispose(disposing);

            if (disposing)
            {
                if (this.helper != null)
                {
                    this.helper.Dispose();
                    this.helper = null;
                }

                if (this.core != null)
                {
                    this.core.Dispose();
                    this.core = null;
                }
            }
        }

        #endregion Protected Override Methods

        #region Private Methods

        /// <summary>
        /// Adds the menu items for this package.
        /// </summary>
        private void AddMenuItems()
        {
            this.commandSet = new PackageCommandSet(this);
            this.commandSet.Initialize();
        }

        #endregion Private Methods
    }
}