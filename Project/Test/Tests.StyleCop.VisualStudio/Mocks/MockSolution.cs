// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MockSolution.cs" company="https://github.com/StyleCop">
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
//   The mock solution.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace VSPackageUnitTest.Mocks
{
    using System;
    using System.Collections.Generic;

    using Microsoft.VisualStudio;
    using Microsoft.VisualStudio.Shell.Interop;

    /// <summary>
    /// The mock solution.
    /// </summary>
    internal class MockSolution : IVsSolution, IVsSolution3
    {
        #region Constants and Fields

        private readonly List<IVsSolutionEvents> _eventSinks = new List<IVsSolutionEvents>();

        private readonly List<MockIVsProject> _projects = new List<MockIVsProject>();

        #endregion

        #region Properties

        /// <summary>
        /// Gets Projects.
        /// </summary>
        public IEnumerable<MockIVsProject> Projects
        {
            get
            {
                return this._projects;
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// The add project.
        /// </summary>
        /// <param name="project">
        /// The project.
        /// </param>
        public void AddProject(MockIVsProject project)
        {
            this._projects.Add(project);
            foreach (IVsSolutionEvents sink in this._eventSinks)
            {
                if (sink != null)
                {
                    sink.OnAfterOpenProject(project, 1);
                }
            }
        }

        #endregion

        #region Implemented Interfaces

        #region IVsSolution

        /// <summary>
        /// The add virtual project.
        /// </summary>
        /// <param name="pHierarchy">
        /// The p hierarchy.
        /// </param>
        /// <param name="grfAddVPFlags">
        /// The grf add vp flags.
        /// </param>
        /// <returns>
        /// The add virtual project.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int AddVirtualProject(IVsHierarchy pHierarchy, uint grfAddVPFlags)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The add virtual project ex.
        /// </summary>
        /// <param name="pHierarchy">
        /// The p hierarchy.
        /// </param>
        /// <param name="grfAddVPFlags">
        /// The grf add vp flags.
        /// </param>
        /// <param name="rguidProjectID">
        /// The rguid project id.
        /// </param>
        /// <returns>
        /// The add virtual project ex.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int AddVirtualProjectEx(IVsHierarchy pHierarchy, uint grfAddVPFlags, ref Guid rguidProjectID)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The advise solution events.
        /// </summary>
        /// <param name="pSink">
        /// The p sink.
        /// </param>
        /// <param name="pdwCookie">
        /// The pdw cookie.
        /// </param>
        /// <returns>
        /// The advise solution events.
        /// </returns>
        public int AdviseSolutionEvents(IVsSolutionEvents pSink, out uint pdwCookie)
        {
            this._eventSinks.Add(pSink);
            pdwCookie = (uint)this._eventSinks.Count;
            return VSConstants.S_OK;
        }

        /// <summary>
        /// The can create new project at location.
        /// </summary>
        /// <param name="fCreateNewSolution">
        /// The f create new solution.
        /// </param>
        /// <param name="pszFullProjectFilePath">
        /// The psz full project file path.
        /// </param>
        /// <param name="pfCanCreate">
        /// The pf can create.
        /// </param>
        /// <returns>
        /// The can create new project at location.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int CanCreateNewProjectAtLocation(int fCreateNewSolution, string pszFullProjectFilePath, out int pfCanCreate)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The close solution element.
        /// </summary>
        /// <param name="grfCloseOpts">
        /// The grf close opts.
        /// </param>
        /// <param name="pHier">
        /// The p hier.
        /// </param>
        /// <param name="docCookie">
        /// The doc cookie.
        /// </param>
        /// <returns>
        /// The close solution element.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int CloseSolutionElement(uint grfCloseOpts, IVsHierarchy pHier, uint docCookie)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The create new project via dlg.
        /// </summary>
        /// <param name="pszExpand">
        /// The psz expand.
        /// </param>
        /// <param name="pszSelect">
        /// The psz select.
        /// </param>
        /// <param name="dwReserved">
        /// The dw reserved.
        /// </param>
        /// <returns>
        /// The create new project via dlg.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int CreateNewProjectViaDlg(string pszExpand, string pszSelect, uint dwReserved)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The create project.
        /// </summary>
        /// <param name="rguidProjectType">
        /// The rguid project type.
        /// </param>
        /// <param name="lpszMoniker">
        /// The lpsz moniker.
        /// </param>
        /// <param name="lpszLocation">
        /// The lpsz location.
        /// </param>
        /// <param name="lpszName">
        /// The lpsz name.
        /// </param>
        /// <param name="grfCreateFlags">
        /// The grf create flags.
        /// </param>
        /// <param name="iidProject">
        /// The iid project.
        /// </param>
        /// <param name="ppProject">
        /// The pp project.
        /// </param>
        /// <returns>
        /// The create project.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int CreateProject(ref Guid rguidProjectType, string lpszMoniker, string lpszLocation, string lpszName, uint grfCreateFlags, ref Guid iidProject, out IntPtr ppProject)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The create solution.
        /// </summary>
        /// <param name="lpszLocation">
        /// The lpsz location.
        /// </param>
        /// <param name="lpszName">
        /// The lpsz name.
        /// </param>
        /// <param name="grfCreateFlags">
        /// The grf create flags.
        /// </param>
        /// <returns>
        /// The create solution.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int CreateSolution(string lpszLocation, string lpszName, uint grfCreateFlags)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The generate next default project name.
        /// </summary>
        /// <param name="pszBaseName">
        /// The psz base name.
        /// </param>
        /// <param name="pszLocation">
        /// The psz location.
        /// </param>
        /// <param name="pbstrProjectName">
        /// The pbstr project name.
        /// </param>
        /// <returns>
        /// The generate next default project name.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int GenerateNextDefaultProjectName(string pszBaseName, string pszLocation, out string pbstrProjectName)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The generate unique project name.
        /// </summary>
        /// <param name="lpszRoot">
        /// The lpsz root.
        /// </param>
        /// <param name="pbstrProjectName">
        /// The pbstr project name.
        /// </param>
        /// <returns>
        /// The generate unique project name.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int GenerateUniqueProjectName(string lpszRoot, out string pbstrProjectName)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The get guid of project.
        /// </summary>
        /// <param name="pHierarchy">
        /// The p hierarchy.
        /// </param>
        /// <param name="pguidProjectID">
        /// The pguid project id.
        /// </param>
        /// <returns>
        /// The get guid of project.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int GetGuidOfProject(IVsHierarchy pHierarchy, out Guid pguidProjectID)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The get item info of projref.
        /// </summary>
        /// <param name="pszProjref">
        /// The psz projref.
        /// </param>
        /// <param name="propid">
        /// The propid.
        /// </param>
        /// <param name="pvar">
        /// The pvar.
        /// </param>
        /// <returns>
        /// The get item info of projref.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int GetItemInfoOfProjref(string pszProjref, int propid, out object pvar)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The get item of projref.
        /// </summary>
        /// <param name="pszProjref">
        /// The psz projref.
        /// </param>
        /// <param name="ppHierarchy">
        /// The pp hierarchy.
        /// </param>
        /// <param name="pitemid">
        /// The pitemid.
        /// </param>
        /// <param name="pbstrUpdatedProjref">
        /// The pbstr updated projref.
        /// </param>
        /// <param name="puprUpdateReason">
        /// The pupr update reason.
        /// </param>
        /// <returns>
        /// The get item of projref.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int GetItemOfProjref(string pszProjref, out IVsHierarchy ppHierarchy, out uint pitemid, out string pbstrUpdatedProjref, VSUPDATEPROJREFREASON[] puprUpdateReason)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The get project enum.
        /// </summary>
        /// <param name="grfEnumFlags">
        /// The grf enum flags.
        /// </param>
        /// <param name="rguidEnumOnlyThisType">
        /// The rguid enum only this type.
        /// </param>
        /// <param name="ppenum">
        /// The ppenum.
        /// </param>
        /// <returns>
        /// The get project enum.
        /// </returns>
        public int GetProjectEnum(uint grfEnumFlags, ref Guid rguidEnumOnlyThisType, out IEnumHierarchies ppenum)
        {
            ppenum = new MockEnumHierarchies(this._projects);
            return VSConstants.S_OK;
        }

        /// <summary>
        /// The get project factory.
        /// </summary>
        /// <param name="dwReserved">
        /// The dw reserved.
        /// </param>
        /// <param name="pguidProjectType">
        /// The pguid project type.
        /// </param>
        /// <param name="pszMkProject">
        /// The psz mk project.
        /// </param>
        /// <param name="ppProjectFactory">
        /// The pp project factory.
        /// </param>
        /// <returns>
        /// The get project factory.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int GetProjectFactory(uint dwReserved, Guid[] pguidProjectType, string pszMkProject, out IVsProjectFactory ppProjectFactory)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The get project files in solution.
        /// </summary>
        /// <param name="grfGetOpts">
        /// The grf get opts.
        /// </param>
        /// <param name="cProjects">
        /// The c projects.
        /// </param>
        /// <param name="rgbstrProjectNames">
        /// The rgbstr project names.
        /// </param>
        /// <param name="pcProjectsFetched">
        /// The pc projects fetched.
        /// </param>
        /// <returns>
        /// The get project files in solution.
        /// </returns>
        public int GetProjectFilesInSolution(uint grfGetOpts, uint cProjects, string[] rgbstrProjectNames, out uint pcProjectsFetched)
        {
            if (cProjects == 0)
            {
                pcProjectsFetched = (uint)this._projects.Count;
            }
            else
            {
                for (int i = 0; i < cProjects; ++i)
                {
                    rgbstrProjectNames[i] = this._projects[i].FullPath;
                }

                pcProjectsFetched = cProjects;
            }

            return VSConstants.S_OK;
        }

        /// <summary>
        /// The get project info of projref.
        /// </summary>
        /// <param name="pszProjref">
        /// The psz projref.
        /// </param>
        /// <param name="propid">
        /// The propid.
        /// </param>
        /// <param name="pvar">
        /// The pvar.
        /// </param>
        /// <returns>
        /// The get project info of projref.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int GetProjectInfoOfProjref(string pszProjref, int propid, out object pvar)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The get project of guid.
        /// </summary>
        /// <param name="rguidProjectID">
        /// The rguid project id.
        /// </param>
        /// <param name="ppHierarchy">
        /// The pp hierarchy.
        /// </param>
        /// <returns>
        /// The get project of guid.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int GetProjectOfGuid(ref Guid rguidProjectID, out IVsHierarchy ppHierarchy)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The get project of projref.
        /// </summary>
        /// <param name="pszProjref">
        /// The psz projref.
        /// </param>
        /// <param name="ppHierarchy">
        /// The pp hierarchy.
        /// </param>
        /// <param name="pbstrUpdatedProjref">
        /// The pbstr updated projref.
        /// </param>
        /// <param name="puprUpdateReason">
        /// The pupr update reason.
        /// </param>
        /// <returns>
        /// The get project of projref.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int GetProjectOfProjref(string pszProjref, out IVsHierarchy ppHierarchy, out string pbstrUpdatedProjref, VSUPDATEPROJREFREASON[] puprUpdateReason)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The get project of unique name.
        /// </summary>
        /// <param name="pszUniqueName">
        /// The psz unique name.
        /// </param>
        /// <param name="ppHierarchy">
        /// The pp hierarchy.
        /// </param>
        /// <returns>
        /// The get project of unique name.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int GetProjectOfUniqueName(string pszUniqueName, out IVsHierarchy ppHierarchy)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The get project type guid.
        /// </summary>
        /// <param name="dwReserved">
        /// The dw reserved.
        /// </param>
        /// <param name="pszMkProject">
        /// The psz mk project.
        /// </param>
        /// <param name="pguidProjectType">
        /// The pguid project type.
        /// </param>
        /// <returns>
        /// The get project type guid.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int GetProjectTypeGuid(uint dwReserved, string pszMkProject, out Guid pguidProjectType)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The get projref of item.
        /// </summary>
        /// <param name="pHierarchy">
        /// The p hierarchy.
        /// </param>
        /// <param name="itemid">
        /// The itemid.
        /// </param>
        /// <param name="pbstrProjref">
        /// The pbstr projref.
        /// </param>
        /// <returns>
        /// The get projref of item.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int GetProjrefOfItem(IVsHierarchy pHierarchy, uint itemid, out string pbstrProjref)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The get projref of project.
        /// </summary>
        /// <param name="pHierarchy">
        /// The p hierarchy.
        /// </param>
        /// <param name="pbstrProjref">
        /// The pbstr projref.
        /// </param>
        /// <returns>
        /// The get projref of project.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int GetProjrefOfProject(IVsHierarchy pHierarchy, out string pbstrProjref)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The get property.
        /// </summary>
        /// <param name="propid">
        /// The propid.
        /// </param>
        /// <param name="pvar">
        /// The pvar.
        /// </param>
        /// <returns>
        /// The get property.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int GetProperty(int propid, out object pvar)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The get solution info.
        /// </summary>
        /// <param name="pbstrSolutionDirectory">
        /// The pbstr solution directory.
        /// </param>
        /// <param name="pbstrSolutionFile">
        /// The pbstr solution file.
        /// </param>
        /// <param name="pbstrUserOptsFile">
        /// The pbstr user opts file.
        /// </param>
        /// <returns>
        /// The get solution info.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int GetSolutionInfo(out string pbstrSolutionDirectory, out string pbstrSolutionFile, out string pbstrUserOptsFile)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The get unique name of project.
        /// </summary>
        /// <param name="pHierarchy">
        /// The p hierarchy.
        /// </param>
        /// <param name="pbstrUniqueName">
        /// The pbstr unique name.
        /// </param>
        /// <returns>
        /// The get unique name of project.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int GetUniqueNameOfProject(IVsHierarchy pHierarchy, out string pbstrUniqueName)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The get virtual project flags.
        /// </summary>
        /// <param name="pHierarchy">
        /// The p hierarchy.
        /// </param>
        /// <param name="pgrfAddVPFlags">
        /// The pgrf add vp flags.
        /// </param>
        /// <returns>
        /// The get virtual project flags.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int GetVirtualProjectFlags(IVsHierarchy pHierarchy, out uint pgrfAddVPFlags)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The on after rename project.
        /// </summary>
        /// <param name="pProject">
        /// The p project.
        /// </param>
        /// <param name="pszMkOldName">
        /// The psz mk old name.
        /// </param>
        /// <param name="pszMkNewName">
        /// The psz mk new name.
        /// </param>
        /// <param name="dwReserved">
        /// The dw reserved.
        /// </param>
        /// <returns>
        /// The on after rename project.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int OnAfterRenameProject(IVsProject pProject, string pszMkOldName, string pszMkNewName, uint dwReserved)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The open solution file.
        /// </summary>
        /// <param name="grfOpenOpts">
        /// The grf open opts.
        /// </param>
        /// <param name="pszFilename">
        /// The psz filename.
        /// </param>
        /// <returns>
        /// The open solution file.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int OpenSolutionFile(uint grfOpenOpts, string pszFilename)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The open solution via dlg.
        /// </summary>
        /// <param name="pszStartDirectory">
        /// The psz start directory.
        /// </param>
        /// <param name="fDefaultToAllProjectsFilter">
        /// The f default to all projects filter.
        /// </param>
        /// <returns>
        /// The open solution via dlg.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int OpenSolutionViaDlg(string pszStartDirectory, int fDefaultToAllProjectsFilter)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The query edit solution file.
        /// </summary>
        /// <param name="pdwEditResult">
        /// The pdw edit result.
        /// </param>
        /// <returns>
        /// The query edit solution file.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int QueryEditSolutionFile(out uint pdwEditResult)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The query rename project.
        /// </summary>
        /// <param name="pProject">
        /// The p project.
        /// </param>
        /// <param name="pszMkOldName">
        /// The psz mk old name.
        /// </param>
        /// <param name="pszMkNewName">
        /// The psz mk new name.
        /// </param>
        /// <param name="dwReserved">
        /// The dw reserved.
        /// </param>
        /// <param name="pfRenameCanContinue">
        /// The pf rename can continue.
        /// </param>
        /// <returns>
        /// The query rename project.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int QueryRenameProject(IVsProject pProject, string pszMkOldName, string pszMkNewName, uint dwReserved, out int pfRenameCanContinue)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The remove virtual project.
        /// </summary>
        /// <param name="pHierarchy">
        /// The p hierarchy.
        /// </param>
        /// <param name="grfRemoveVPFlags">
        /// The grf remove vp flags.
        /// </param>
        /// <returns>
        /// The remove virtual project.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int RemoveVirtualProject(IVsHierarchy pHierarchy, uint grfRemoveVPFlags)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The save solution element.
        /// </summary>
        /// <param name="grfSaveOpts">
        /// The grf save opts.
        /// </param>
        /// <param name="pHier">
        /// The p hier.
        /// </param>
        /// <param name="docCookie">
        /// The doc cookie.
        /// </param>
        /// <returns>
        /// The save solution element.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int SaveSolutionElement(uint grfSaveOpts, IVsHierarchy pHier, uint docCookie)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The set property.
        /// </summary>
        /// <param name="propid">
        /// The propid.
        /// </param>
        /// <param name="var">
        /// The var.
        /// </param>
        /// <returns>
        /// The set property.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int SetProperty(int propid, object var)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The unadvise solution events.
        /// </summary>
        /// <param name="dwCookie">
        /// The dw cookie.
        /// </param>
        /// <returns>
        /// The unadvise solution events.
        /// </returns>
        public int UnadviseSolutionEvents(uint dwCookie)
        {
            this._eventSinks[(int)dwCookie - 1] = null;
            return VSConstants.S_OK;
        }

        #endregion

        #region IVsSolution3

        /// <summary>
        /// The check for and save deferred save solution.
        /// </summary>
        /// <param name="fCloseSolution">
        /// The f close solution.
        /// </param>
        /// <param name="pszMessage">
        /// The psz message.
        /// </param>
        /// <param name="pszTitle">
        /// The psz title.
        /// </param>
        /// <param name="grfFlags">
        /// The grf flags.
        /// </param>
        /// <returns>
        /// The check for and save deferred save solution.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int CheckForAndSaveDeferredSaveSolution(int fCloseSolution, string pszMessage, string pszTitle, uint grfFlags)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The create new project via dlg ex.
        /// </summary>
        /// <param name="pszDlgTitle">
        /// The psz dlg title.
        /// </param>
        /// <param name="pszTemplateDir">
        /// The psz template dir.
        /// </param>
        /// <param name="pszExpand">
        /// The psz expand.
        /// </param>
        /// <param name="pszSelect">
        /// The psz select.
        /// </param>
        /// <param name="pszHelpTopic">
        /// The psz help topic.
        /// </param>
        /// <param name="cnpvdeFlags">
        /// The cnpvde flags.
        /// </param>
        /// <param name="pBrowse">
        /// The p browse.
        /// </param>
        /// <returns>
        /// The create new project via dlg ex.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int CreateNewProjectViaDlgEx(string pszDlgTitle, string pszTemplateDir, string pszExpand, string pszSelect, string pszHelpTopic, uint cnpvdeFlags, IVsBrowseProjectLocation pBrowse)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// The get unique ui name of project.
        /// </summary>
        /// <param name="pHierarchy">
        /// The p hierarchy.
        /// </param>
        /// <param name="pbstrUniqueName">
        /// The pbstr unique name.
        /// </param>
        /// <returns>
        /// The get unique ui name of project.
        /// </returns>
        public int GetUniqueUINameOfProject(IVsHierarchy pHierarchy, out string pbstrUniqueName)
        {
            MockIVsProject project = pHierarchy as MockIVsProject;

            pbstrUniqueName = "Unique name of " + project.FullPath;
            return VSConstants.S_OK;
        }

        /// <summary>
        /// The update project file location for upgrade.
        /// </summary>
        /// <param name="pszCurrentLocation">
        /// The psz current location.
        /// </param>
        /// <param name="pszUpgradedLocation">
        /// The psz upgraded location.
        /// </param>
        /// <returns>
        /// The update project file location for upgrade.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public int UpdateProjectFileLocationForUpgrade(string pszCurrentLocation, string pszUpgradedLocation)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        #endregion
    }
}