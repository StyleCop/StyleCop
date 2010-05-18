/***************************************************************************
         Copyright (c) Microsoft Corporation, All rights reserved.             
    This code sample is provided "AS IS" without warranty of any kind, 
    it is not recommended for use in a production environment.
***************************************************************************/

namespace Microsoft.VisualStudio.Shell.Flavor
{
    using System;
    using System.Diagnostics;
    using System.Globalization;
    using System.Runtime.InteropServices;
    using Microsoft.VisualStudio.Shell.Interop;
    using Microsoft.VisualStudio.OLE.Interop;
    using Microsoft.VisualStudio.Shell;


    /// <include file='doc\FlavoredProjectFactory.uex' path='docs/doc[@for="FlavoredProjectFactory"]/*' />
    /// <devdoc>
    /// The project factory for the project flavor.
    /// Note that this is also known as Project Subtype
    /// </devdoc>
    [CLSCompliant(false)]
    public abstract class FlavoredProjectFactory : IVsAggregatableProjectFactory, IVsProjectFactory
    {
        private ServiceProvider _serviceProvider;
        /// <include file='doc\FlavoredProjectFactory.uex' path='docs/doc[@for="FlavoredProjectFactory.ServiceProvider"]/*' />
        protected ServiceProvider serviceProvider
        {
            get { return _serviceProvider; }
        }

        /// <include file='doc\FlavoredProjectFactory.uex' path='docs/doc[@for="FlavoredProjectFactory.FlavoredProjectFactory"]/*' />
        public FlavoredProjectFactory()
        {
        }

        #region IVsProjectFactory

        int IVsProjectFactory.CanCreateProject(string fileName, uint flags, out int canCreate)
        {
            canCreate = this.CanCreateProject(fileName, flags) ? 1 : 0;
            return NativeMethods.S_OK;
        }
        /// <include file='doc\FlavoredProjectFactory.uex' path='docs/doc[@for="FlavoredProjectFactory.CanCreateProject"]/*' />
        /// <devdoc>
        /// This is called to ask the factory if it can create a project based on the current parameters
        /// </devdoc>
        /// <returns>True if the project can be created</returns>
        protected virtual bool CanCreateProject(string fileName, uint flags)
        {
            // Validate the filename
            bool canCreate = !string.IsNullOrEmpty(fileName);
            canCreate |= !PackageUtilities.ContainsInvalidFileNameChars(fileName);
            return canCreate;
        }

        /// <devdoc>
        /// This is not expected to be called unless using an extension other then the base project
        /// </devdoc>
        int IVsProjectFactory.CreateProject(string fileName, string location, string name, uint flags, ref Guid projectGuid, out System.IntPtr project, out int canceled)
        {
            this.CreateProject(fileName, location, name, flags, ref projectGuid, out project, out canceled);
            return NativeMethods.S_OK;
        }
        /// <include file='doc\FlavoredProjectFactory.uex' path='docs/doc[@for="FlavoredProjectFactory.CreateProject"]/*' />
        /// <devdoc>
        /// If you want to use your own extension, you will need to call IVsCreateAggregatedProject.CreateAggregatedProject()
        /// </devdoc>
        /// <returns>HRESULT</returns>
        protected virtual void CreateProject(string fileName, string location, string name, uint flags, ref Guid projectGuid, out System.IntPtr project, out int canceled)
        {
            // If the extension is that of the base project then we don't get called
            project = IntPtr.Zero;
            canceled = 0;
        }

        int IVsProjectFactory.Close()
        {
            this.Dispose(true);

            return NativeMethods.S_OK;
        }
        /// <include file='doc\FlavoredProjectFactory.uex' path='docs/doc[@for="FlavoredProjectFactory.Dispose"]/*' />
        protected virtual void Dispose(bool disposing)
        {
            if (_serviceProvider != null)
            {
                _serviceProvider.Dispose();
                _serviceProvider = null;
            }
        }

        int IVsProjectFactory.SetSite(Microsoft.VisualStudio.OLE.Interop.IServiceProvider provider)
        {
            // keep track of our service provider
            this._serviceProvider = new ServiceProvider(provider);

            this.Initialize();

            return NativeMethods.S_OK;
        }
        /// <include file='doc\FlavoredProjectFactory.uex' path='docs/doc[@for="FlavoredProjectFactory.Initialize"]/*' />
        /// <devdoc>
        /// Called by SetSite after setting our service provider
        /// </devdoc>
        protected virtual void Initialize()
        {
        }

        #endregion

        #region IVsAggregatableProjectFactory

        int IVsAggregatableProjectFactory.GetAggregateProjectType(string fileName, out string projectTypeGuid)
        {
            projectTypeGuid = this.ProjectTypeGuids(fileName);
            return NativeMethods.S_OK;
        }

        int IVsAggregatableProjectFactory.PreCreateForOuter(object outerProject, out object project)
        {
            project = null;
            project = PreCreateForOuter(outerProject);

            if (!(project is FlavoredProject))
            {
                // We are not throwing in this case as someone could create 1 factory that support creating both
                // flavored project and full project. Also, someone could have implemented their flavored project
                // without using our base class. Never the less, if executing in the debugger, we should log this
                // to the output window.
                string warning = String.Format(CultureInfo.InvariantCulture, "Expected to recieve a FlavoredProject from PreCreateForOuter.\n Recieved a {0}", project.GetType().FullName);
                Trace.WriteLine(warning);
                // If you build your own version of this assembly and you intend to use FlavoredProject, uncomment
                // the following line as this will make any problem more obvious on debug builds
                //Debug.Fail(warning);
            }

            if (project == null)
                return NativeMethods.E_FAIL;

            return NativeMethods.S_OK;
        }
        /// <include file='doc\FlavoredProjectFactory.uex' path='docs/doc[@for="FlavoredProjectFactory.PreCreateForOuter"]/*' />
        /// <devdoc>
        /// This function returns an instance of the project. This is just creating the object,
        /// VS will later call SetInner and InitializeForOuter to initialize it.
        /// </devdoc>
        /// <param name="outerProject"></param>
        /// <returns>The project subtype</returns>
        protected abstract object PreCreateForOuter(object outerProject);
        #endregion

        /// <include file='doc\FlavoredProjectFactory.uex' path='docs/doc[@for="FlavoredProjectFactory.ProjectTypeGuids"]/*' />
        protected virtual string ProjectTypeGuids(string file)
        {
            throw new NotImplementedException();
        }
    }
}
