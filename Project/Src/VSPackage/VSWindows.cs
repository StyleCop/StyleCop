//--------------------------------------------------------------------------
// <copyright file="VSWindows.cs">
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
    using EnvDTE;

    /// <summary>
    /// Class that wraps various VS windows used by StyleCop.
    /// </summary>
    internal class VSWindows
    {
        #region Fields

        /// <summary>
        /// Static instance of the VSWindows class..
        /// </summary>
        private static VSWindows instance;

        /// <summary>
        /// Mutex for thread safety.
        /// </summary>
        private EnvDTE.DTE environment;

        /// <summary>
        /// System service provider.
        /// </summary>
        private IServiceProvider serviceProvider;

        /// <summary>
        /// The DTE output window.
        /// </summary>
        private EnvDTE.Window outputWindow;

        /// <summary>
        /// The DTE output window pane.
        /// </summary>
        private OutputWindowPane outputPane;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the VSWindows class.
        /// </summary>
        /// <param name="serviceProvider">System service provider.</param>
        private VSWindows(IServiceProvider serviceProvider)
        {
            Param.AssertNotNull(serviceProvider, "serviceProvider");
            this.serviceProvider = serviceProvider;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets an instance of the DTE output window.
        /// </summary>
        internal EnvDTE.Window OutputWindow
        {
            get
            {
                if (this.outputWindow == null)
                {
                    try
                    {
                        this.outputWindow = this.DTE.Windows.Item(EnvDTE.Constants.vsWindowKindOutput);
                    }
                    catch (ArgumentException)
                    {
                        // This occurs when VS in unable to load the output window. Just proceed.
                    }
                }

                return this.outputWindow;
            }
        }

        /// <summary>
        /// Gets an instance of the DTE output window pane.
        /// </summary>
        internal OutputWindowPane OutputPane
        {
            get
            {
                if (this.outputPane == null)
                {
                    try
                    {
                        OutputWindow outputWindowObject = (OutputWindow)this.OutputWindow.Object;
                        this.outputPane = outputWindowObject.OutputWindowPanes.Add("StyleCop");
                    }
                    catch (ArgumentException)
                    {
                        // This occurs when VS in unable to load the output window. Just proceed.
                    }
                }

                return this.outputPane;
            }
        }

        /// <summary>
        /// Gets an instance of the DTE from the service provider.
        /// </summary>
        private EnvDTE.DTE DTE
        {
            get
            {
                if (this.environment == null)
                {
                    this.environment = (EnvDTE.DTE)this.serviceProvider.GetService(typeof(EnvDTE.DTE));
                }

                return this.environment;
            }
        }

        #endregion Properties

        /// <summary>
        /// Gets the singleton instance of the VSWindows.
        /// </summary>
        /// <param name="serviceProvider">System service provider.</param>
        /// <returns>Returns the singleton instance of the VSWindows.</returns>
        internal static VSWindows GetInstance(IServiceProvider serviceProvider)
        {
            Param.AssertNotNull(serviceProvider, "serviceProvider");

            if (instance == null)
            {
                instance = new VSWindows(serviceProvider);
            }

            return instance;
        }
    }
}