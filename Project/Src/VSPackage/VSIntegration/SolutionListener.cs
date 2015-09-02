//--------------------------------------------------------------------------
// <copyright file="SolutionListener.cs">
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
    using Microsoft.VisualStudio;
    using Microsoft.VisualStudio.Shell.Interop;

    /// <summary>
    /// Listens for events from the solution.
    /// </summary>
    internal class SolutionListener : IVsSolutionEvents4, IVsSolutionEvents3, IVsSolutionEvents2, IVsSolutionEvents, IDisposable
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
        /// The VS Solution object.
        /// </summary>
        private IVsSolution solution;

        #endregion Private fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the SolutionListener class.
        /// </summary>
        /// <param name="serviceProvider">The system service provider.</param>
        internal SolutionListener(IServiceProvider serviceProvider)
        {
            Param.AssertNotNull(serviceProvider, "serviceProvider");

            this.solution = serviceProvider.GetService(typeof(SVsSolution)) as IVsSolution;
            if (this.solution == null)
            {
                throw new InvalidOperationException();
            }
        }

        #endregion Constructors

        #region Events

        /// <summary>
        /// Fires after a solution is opened.
        /// </summary>
        internal event EventHandler AfterSolutionOpened;

        /// <summary>
        /// Files before a solution is closed.
        /// </summary>
        internal event EventHandler BeforeClosingSolution;

        #endregion Events

        #region Public Methods

        /// <summary>
        /// Initializes the object.
        /// </summary>
        public void Initialize()
        {
            if (this.solution != null)
            {
                ErrorHandler.ThrowOnFailure(
                    this.solution.AdviseSolutionEvents(this, out this.eventsCookie));
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

        #region IVsSolutionEvents4 Members

        /// <summary>
        /// Method is not implemented.
        /// </summary>
        /// <param name="hierarchy">The parameter is not used.</param>
        /// <param name="added">The parameter is not used.</param>
        /// <returns>Returns E_NOTIMPL.</returns>
        public virtual int OnAfterAsynchOpenProject(IVsHierarchy hierarchy, int added)
        {
            Param.Ignore(hierarchy, added);
            return VSConstants.E_NOTIMPL;
        }

        /// <summary>
        /// Method is not implemented.
        /// </summary>
        /// <param name="hierarchy">The parameter is not used.</param>
        /// <returns>Returns E_NOTIMPL.</returns>
        public virtual int OnAfterChangeProjectParent(IVsHierarchy hierarchy)
        {
            Param.Ignore(hierarchy);
            return VSConstants.E_NOTIMPL;
        }

        /// <summary>
        /// Method is not implemented.
        /// </summary>
        /// <param name="hierarchy">The parameter is not used.</param>
        /// <returns>Returns E_NOTIMPL.</returns>
        public virtual int OnAfterRenameProject(IVsHierarchy hierarchy)
        {
            Param.Ignore(hierarchy);
            return VSConstants.E_NOTIMPL;
        }

        /// <summary>
        /// Method is not implemented.
        /// </summary>
        /// <param name="hierarchy">The parameter is not used.</param>
        /// <param name="newParentHier">The parameter is not used.</param>
        /// <param name="cancel">The parameter is not used.</param>
        /// <returns>Returns E_NOTIMPL.</returns>
        public virtual int OnQueryChangeProjectParent(IVsHierarchy hierarchy, IVsHierarchy newParentHier, ref int cancel)
        {
            Param.Ignore(hierarchy, newParentHier, cancel);
            return VSConstants.E_NOTIMPL;
        }

        #endregion

        #region IVsSolutionEvents3 Members

        /// <summary>
        /// Method is not implemented.
        /// </summary>
        /// <param name="reserved">>The parameter is not used.</param>
        /// <returns>Returns E_NOTIMPL.</returns>
        public virtual int OnAfterCloseSolution(object reserved)
        {
            Param.Ignore(reserved);

            return VSConstants.E_NOTIMPL;
        }

        /// <summary>
        /// Method is not implemented.
        /// </summary>
        /// <param name="hierarchy">The parameter is not used.</param>
        /// <returns>Returns E_NOTIMPL.</returns>
        public virtual int OnAfterClosingChildren(IVsHierarchy hierarchy)
        {
            Param.Ignore(hierarchy);
            return VSConstants.E_NOTIMPL;
        }

        /// <summary>
        /// Method is not implemented.
        /// </summary>
        /// <param name="stubHierarchy">The parameter is not used.</param>
        /// <param name="realHierarchy">The parameter is not used.</param>
        /// <returns>Returns E_NOTIMPL.</returns>
        public virtual int OnAfterLoadProject(IVsHierarchy stubHierarchy, IVsHierarchy realHierarchy)
        {
            Param.Ignore(stubHierarchy, realHierarchy);
            return VSConstants.E_NOTIMPL;
        }

        /// <summary> 
        /// Method is not implemented.
        /// </summary>
        /// <param name="reserved">The parameter is not used.</param>
        /// <returns>Returns E_NOTIMPL.</returns>
        public virtual int OnAfterMergeSolution(object reserved)
        {
            Param.Ignore(reserved);
            return VSConstants.E_NOTIMPL;
        }

        /// <summary>
        /// Method is not implemented.
        /// </summary>
        /// <param name="hierarchy">The parameter is not used.</param>
        /// <param name="added">The parameter is not used.</param>
        /// <returns>Returns E_NOTIMPL.</returns>
        public virtual int OnAfterOpenProject(IVsHierarchy hierarchy, int added)
        {
            Param.Ignore(hierarchy, added);
            return VSConstants.E_NOTIMPL;
        }

        /// <summary>
        /// Method is not implemented.
        /// </summary>
        /// <param name="reserved">The parameter is not used.</param>
        /// <param name="newSolution">The parameter is not used.</param>
        /// <returns>Returns S_OK.</returns>
        public virtual int OnAfterOpenSolution(object reserved, int newSolution)
        {
            Param.Ignore(reserved, newSolution);
            if (this.AfterSolutionOpened != null)
            {
                this.AfterSolutionOpened(this, EventArgs.Empty);
            }

            return VSConstants.S_OK;
        }

        /// <summary>
        /// Method is not implemented.
        /// </summary>
        /// <param name="hierarchy">The parameter is not used.</param>
        /// <returns>Returns E_NOTIMPL.</returns>
        public virtual int OnAfterOpeningChildren(IVsHierarchy hierarchy)
        {
            Param.Ignore(hierarchy);
            return VSConstants.E_NOTIMPL;
        }

        /// <summary>
        /// Method is not implemented.
        /// </summary>
        /// <param name="hierarchy">The parameter is not used.</param>
        /// <param name="removed">The parameter is not used.</param>
        /// <returns>Returns E_NOTIMPL.</returns>
        public virtual int OnBeforeCloseProject(IVsHierarchy hierarchy, int removed)
        {
            Param.Ignore(hierarchy, removed);
            return VSConstants.E_NOTIMPL;
        }

        /// <summary>
        /// Method is not implemented.
        /// </summary>
        /// <param name="reserved">The parameter is not used.</param>
        /// <returns>Returns E_NOTIMPL.</returns>
        public virtual int OnBeforeCloseSolution(object reserved)
        {
            Param.Ignore(reserved);
            if (this.BeforeClosingSolution != null)
            {
                this.BeforeClosingSolution(this, EventArgs.Empty);
            }

            return VSConstants.S_OK;
        }

        /// <summary>
        /// Method is not implemented.
        /// </summary>
        /// <param name="hierarchy">The parameter is not used.</param>
        /// <returns>Returns E_NOTIMPL.</returns>
        public virtual int OnBeforeClosingChildren(IVsHierarchy hierarchy)
        {
            Param.Ignore(hierarchy);

            return VSConstants.E_NOTIMPL;
        }

        /// <summary>
        /// Method is not implemented.
        /// </summary>
        /// <param name="hierarchy">The parameter is not used.</param>
        /// <returns>Returns E_NOTIMPL.</returns>
        public virtual int OnBeforeOpeningChildren(IVsHierarchy hierarchy)
        {
            Param.Ignore(hierarchy);

            return VSConstants.E_NOTIMPL;
        }

        /// <summary>
        /// Method is not implemented.
        /// </summary>
        /// <param name="realHierarchy">The parameter is not used.</param>
        /// <param name="stubHierarchy">The parameter is not used.</param>
        /// <returns>Returns E_NOTIMPL.</returns>
        public virtual int OnBeforeUnloadProject(IVsHierarchy realHierarchy, IVsHierarchy stubHierarchy)
        {
            Param.Ignore(realHierarchy, stubHierarchy);

            return VSConstants.E_NOTIMPL;
        }

        /// <summary>
        /// Method is not implemented.
        /// </summary>
        /// <param name="hierarchy">The parameter is not used.</param>
        /// <param name="removing">The parameter is not used.</param>
        /// <param name="cancel">The parameter is not used.</param>
        /// <returns>Returns E_NOTIMPL.</returns>
        public virtual int OnQueryCloseProject(IVsHierarchy hierarchy, int removing, ref int cancel)
        {
            Param.Ignore(hierarchy, removing, cancel);

            return VSConstants.E_NOTIMPL;
        }

        /// <summary>
        /// Method is not implemented.
        /// </summary>
        /// <param name="reserved">The parameter is not used.</param>
        /// <param name="cancel">The parameter is not used.</param>
        /// <returns>Returns E_NOTIMPL.</returns>
        public virtual int OnQueryCloseSolution(object reserved, ref int cancel)
        {
            Param.Ignore(reserved, cancel);

            return VSConstants.E_NOTIMPL;
        }

        /// <summary>
        /// Method is not implemented.
        /// </summary>
        /// <param name="realHierarchy">The parameter is not used.</param>
        /// <param name="cancel">The parameter is not used.</param>
        /// <returns>Returns E_NOTIMPL.</returns>
        public virtual int OnQueryUnloadProject(IVsHierarchy realHierarchy, ref int cancel)
        {
            Param.Ignore(realHierarchy, cancel);

            return VSConstants.E_NOTIMPL;
        }

        #endregion

        #region Protected methods

        /// <summary>
        /// Disposes the object.
        /// </summary>
        /// <param name="disposing">Is the object being disposed?</param>
        protected virtual void Dispose(bool disposing)
        {
            Param.Ignore(disposing);

            if (!this.disposed)
            {
                lock (mutex)
                {
                    if ((disposing && (this.eventsCookie != 0)) && (this.solution != null))
                    {
                        ErrorHandler.ThrowOnFailure(
                        this.solution.UnadviseSolutionEvents(this.eventsCookie));
                        this.eventsCookie = 0;
                    }

                    this.disposed = true;
                }
            }
        }

        #endregion Protected methods
    }
}