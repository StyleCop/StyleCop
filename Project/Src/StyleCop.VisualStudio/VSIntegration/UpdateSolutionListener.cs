//-----------------------------------------------------------------------
// <copyright file="UpdateSolutionListener.cs">
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
    using Microsoft.VisualStudio;
    using Microsoft.VisualStudio.Shell.Interop;

    /// <summary>
    /// Listens for update events from the solution - including build events.
    /// </summary>
    internal class UpdateSolutionListener : IVsUpdateSolutionEvents, IDisposable
    {
        #region Private fields

        /// <summary>
        /// Mutex for thread safety.
        /// </summary>
        private static volatile object mutex = new object();

        /// <summary>
        /// Event cookie, set the class is initialized.
        /// </summary>
        private uint eventsCookie;

        /// <summary>
        /// Flag indicating whether the class has been disposed.
        /// </summary>
        private bool disposed;

        /// <summary>
        /// Manages the solution build events.
        /// </summary>
        private IVsSolutionBuildManager solutionBuildManager;

        /// <summary>
        /// System service provider.
        /// </summary>
        private IServiceProvider serviceProvider;

        #endregion Private fields
        
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the UpdateSolutionListener class.
        /// </summary>
        /// <param name="serviceProvider">The system service provider.</param>
        internal UpdateSolutionListener(IServiceProvider serviceProvider)
        {
            Param.AssertNotNull(serviceProvider, "serviceProvider");

            this.serviceProvider = serviceProvider;
        }

        #endregion Constructors

        /// <summary>
        /// Fired when the build begins.
        /// </summary>
        internal event EventHandler BeginBuild;

        #region Private properties

        /// <summary>
        /// Gets the instance of the <see cref="T:IVsSolutionBuildManager"/>
        /// </summary>
        private IVsSolutionBuildManager SolutionBuildManager
        {
            get
            {
                if (this.solutionBuildManager == null)
                {
                    this.solutionBuildManager = (IVsSolutionBuildManager)this.serviceProvider.GetService(typeof(SVsSolutionBuildManager));
                    Debug.Assert(this.solutionBuildManager != null, "No SVsSolutionBuildManager service available.");
                }

                return this.solutionBuildManager;
            }
        }

        #endregion Private properties

        #region Public Methods

        /// <summary>
        /// Initializes the object.
        /// </summary>
        public void Initialize()
        {
            if (this.SolutionBuildManager != null)
            {
                ErrorHandler.ThrowOnFailure(
                    this.SolutionBuildManager.AdviseUpdateSolutionEvents(this, out this.eventsCookie));
            }
        }

        /// <summary>
        /// Disposes the object.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion Public Methods

        #region IVsUpdateSolutionEvents Members

        /// <summary>
        /// Method is not implemented.
        /// </summary>
        /// <param name="hierarchy">The parameter is not used.</param>
        /// <returns>Returns E_NOTIMPL.</returns>
        public int OnActiveProjectCfgChange(IVsHierarchy hierarchy)
        {
            Param.Ignore(hierarchy);

            return VSConstants.E_NOTIMPL;
        }

        /// <summary>
        /// Method is not implemented.
        /// </summary>
        /// <param name="cancelUpdate">The parameter is not used.</param>
        /// <returns>Returns E_NOTIMPL.</returns>
        public int UpdateSolution_Begin(ref int cancelUpdate)
        {
            Param.Ignore(cancelUpdate);

            return VSConstants.E_NOTIMPL;
        }

        /// <summary>
        /// Method is not implemented.
        /// </summary>
        /// <returns>Returns E_NOTIMPL.</returns>
        public int UpdateSolution_Cancel()
        {
            return VSConstants.E_NOTIMPL;
        }

        /// <summary>
        /// Method is not implemented.
        /// </summary>
        /// <param name="succeeded">The parameter is not used.</param>
        /// <param name="modified">The parameter is not used.</param>
        /// <param name="cancelCommand">The parameter is not used.</param>
        /// <returns>Returns E_NOTIMPL.</returns>
        public int UpdateSolution_Done(int succeeded, int modified, int cancelCommand)
        {
            Param.Ignore(succeeded, modified, cancelCommand);

            return VSConstants.E_NOTIMPL;
        }

        /// <summary>
        /// Called before the first project configuration is about to be built. 
        /// </summary>
        /// <param name="cancelUpdate">The parameter is not used.</param>
        /// <returns>Returns S_OK.</returns>
        public int UpdateSolution_StartUpdate(ref int cancelUpdate)
        {
            Param.Ignore(cancelUpdate);

            if (this.BeginBuild != null)
            {
                this.BeginBuild(this, EventArgs.Empty);
            }

            return VSConstants.S_OK;
        }

        #endregion

        #region Protected methods

        /// <summary>
        /// Disposes the object.
        /// </summary>
        /// <param name="disposing">Is the object being disposed?</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Usage", 
            "CA1806:DoNotIgnoreMethodResults", 
            MessageId = "Microsoft.VisualStudio.Shell.Interop.IVsSolutionBuildManager.UnadviseUpdateSolutionEvents(System.UInt32)",
            Justification = "We ignore the HRESULT since we dont want to throw in the dispose")]
        protected virtual void Dispose(bool disposing)
        {
            Param.Ignore(disposing);

            if (!this.disposed)
            {
                lock (mutex)
                {
                    if ((disposing && (this.eventsCookie != 0)) && (this.solutionBuildManager != null))
                    {
                        this.solutionBuildManager.UnadviseUpdateSolutionEvents(this.eventsCookie);
                        this.eventsCookie = 0;
                    }

                    this.disposed = true;
                }
            }
        }

        #endregion Protected methods
    }
}