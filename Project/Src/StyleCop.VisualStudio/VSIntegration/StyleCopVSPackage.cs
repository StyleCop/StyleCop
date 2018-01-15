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
    using System.ComponentModel.Design;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Reflection;
    using System.Runtime.InteropServices;

    using Microsoft.VisualStudio;
    using Microsoft.VisualStudio.Shell;
    using Microsoft.VisualStudio.Shell.Interop;

    using StyleCop;

    /// <summary>
    /// Provides a Visual Studio package for StyleCop.
    /// </summary>
    [PackageRegistration(UseManagedResourcesOnly = true)]
    [DefaultRegistryRoot("Software\\Microsoft\\VisualStudio\\10.0")]
    [InstalledProductRegistration(
        "StyleCop",
        "Provides source code style and consistency tools. For more information, see https://github.com/StyleCop/StyleCop.",
        "5.0",
        IconResourceID = 400)]
    [ProvideAutoLoad(UIContextGuids.SolutionExists)]
    [ProvideAutoLoad(UIContextGuids.NoSolution)]
    [ProvideLoadKey("Standard", "5.0", "StyleCop", "StyleCop", 200)]
    [ProvideMenuResource(1000, 1)]
    [Guid(GuidList.StyleCopPackageIdString)]
    [SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling", Justification = "The class is complex.")]
    public sealed class StyleCopVSPackage : Package, IDisposable, IVsShellPropertyEvents
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

        /// <summary>
        /// Used to track whether VS has left its zombie state.
        /// </summary>
        private uint cookie;
        
        #endregion Private Fields

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
        /// Gets a value indicating whether the VS DTE object is available yet. This object is available once the zombie state has gone.
        /// </summary>
        /// <returns>True if the DTE object is available, otherwise false.</returns>
        private bool IsDTEReady
        {
            get
            {
                EnvDTE.DTE dte = (EnvDTE.DTE)this.GetService(typeof(EnvDTE.DTE));
                return dte != null;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the package is running in setup mode.
        /// </summary>
        private bool SetupMode
        {
            get
            {
                // Are we running with /setup?
                IVsAppCommandLine commandLine = (IVsAppCommandLine)this.GetService(typeof(IVsAppCommandLine));
                int present;
                string value;

                ErrorHandler.ThrowOnFailure(commandLine.GetOption("setup", out present, out value));
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
                    pane.OutputLine(output);
                }
            }
        }

        /// <summary>
        /// Called when VS properties change. We use this to wait for VS to finish its setup and leave its 'zombie' state
        /// </summary>
        /// <param name="propid">The property id that has changed.</param>
        /// <param name="var">The new value of the property.</param>
        /// <returns>S_OK is successful</returns>
        public int OnShellPropertyChange(int propid, object var)
        {
            // When the Visual Studio zombie state is false we can finish our init
            if (propid == (int)__VSSPROPID.VSSPROPID_Zombie && (bool)var == false)
            {
                this.InitializeMenus();
                
                // Our VS Shell EventListener is no longer needed
                IVsShell shellService = this.GetService(typeof(SVsShell)) as IVsShell;

                if (shellService != null)
                {
                    ErrorHandler.ThrowOnFailure(shellService.UnadviseShellPropertyChanges(this.cookie));
                }
                
                this.cookie = 0;
            }
            
            return VSConstants.S_OK;
        }
        
        #endregion Public Methods

        #region Protected Override Methods
       
        /// <summary>
        /// Initializes the package.
        /// </summary>
        /// <remarks>
        /// This method is called right after the package is sited, so this is the place to initialize
        /// code that relies on services provided by Visual Studio.
        /// </remarks>
        protected override void Initialize()
        {
            base.Initialize();

            if (this.IsDTEReady)
            {
                this.InitializeMenus();
            }
            else
            {
                // Set an eventlistener for shell property changes
                // We do this to wait for VS to leave its zombie state
                IVsShell shellService = this.GetService(typeof(SVsShell)) as IVsShell;

                if (shellService != null)
                {
                    ErrorHandler.ThrowOnFailure(shellService.AdviseShellPropertyChanges(this, out this.cookie));
                }
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

                this.core = null;
            }
        }

        #endregion Protected Override Methods

        #region Private Methods
       
        /// <summary>
        /// Completes our initialization. This may be called from out overridden Initialize method and sometimes waiting until after the zombie state has
        /// gone from VS.
        /// </summary>
        private void InitializeMenus()
        {
            if (!this.SetupMode)
            {
                IServiceContainer sc = this;
                sc.AddService(typeof(IVsPackage), this, false);

                // Ensure that the IDE enviroment is available.
                EnvDTE.DTE dte = (EnvDTE.DTE)this.GetService(typeof(EnvDTE.DTE));
                if (dte == null)
                {
                    throw new InvalidOperationException(Strings.CouldNotGetVSEnvironment);
                }

                ProjectUtilities.Initialize(this);
                this.Core.Initialize(new[] { Path.GetDirectoryName(typeof(StyleCopVSPackage).Assembly.Location) }, loadFromDefaultPath: false);
                this.Helper.Initialize();

                // Ensuring that the form is created on the UI thread.
                if (InvisibleForm.Instance == null)
                {
                    throw new InvalidOperationException(Strings.NoInvisbleForm);
                }

                // Set up the menu items.
                this.commandSet = new PackageCommandSet(this);
                this.commandSet.Initialize();
            }
        }

        #endregion Private Methods
    }
}