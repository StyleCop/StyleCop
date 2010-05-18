//-----------------------------------------------------------------------
// <copyright file="MockSolution.cs" company="Microsoft">
//   Copyright (c) Microsoft Corporation.
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
    using Microsoft.VisualStudio;
    using Microsoft.VisualStudio.Shell.Interop;

    internal class MockSolution : IVsSolution, IVsSolution3
    {
        readonly List<MockIVsProject> _projects = new List<MockIVsProject>();
        readonly List<IVsSolutionEvents> _eventSinks = new List<IVsSolutionEvents>();

        public void AddProject(MockIVsProject project)
        {
            _projects.Add(project);
            foreach (IVsSolutionEvents sink in _eventSinks)
            {
                if (sink != null)
                {
                    sink.OnAfterOpenProject(project, 1);
                }
            }
        }

        public IEnumerable<MockIVsProject> Projects
        {
            get { return _projects; }
        }

        #region IVsSolution Members

        public int AddVirtualProject(IVsHierarchy pHierarchy, uint grfAddVPFlags)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int AddVirtualProjectEx(IVsHierarchy pHierarchy, uint grfAddVPFlags, ref Guid rguidProjectID)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int AdviseSolutionEvents(IVsSolutionEvents pSink, out uint pdwCookie)
        {
            _eventSinks.Add(pSink);
            pdwCookie = (uint)_eventSinks.Count;
            return VSConstants.S_OK;
        }

        public int CanCreateNewProjectAtLocation(int fCreateNewSolution, string pszFullProjectFilePath, out int pfCanCreate)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int CloseSolutionElement(uint grfCloseOpts, IVsHierarchy pHier, uint docCookie)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int CreateNewProjectViaDlg(string pszExpand, string pszSelect, uint dwReserved)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int CreateProject(ref Guid rguidProjectType, string lpszMoniker, string lpszLocation, string lpszName, uint grfCreateFlags, ref Guid iidProject, out IntPtr ppProject)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int CreateSolution(string lpszLocation, string lpszName, uint grfCreateFlags)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int GenerateNextDefaultProjectName(string pszBaseName, string pszLocation, out string pbstrProjectName)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int GenerateUniqueProjectName(string lpszRoot, out string pbstrProjectName)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int GetGuidOfProject(IVsHierarchy pHierarchy, out Guid pguidProjectID)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int GetItemInfoOfProjref(string pszProjref, int propid, out object pvar)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int GetItemOfProjref(string pszProjref, out IVsHierarchy ppHierarchy, out uint pitemid, out string pbstrUpdatedProjref, VSUPDATEPROJREFREASON[] puprUpdateReason)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int GetProjectEnum(uint grfEnumFlags, ref Guid rguidEnumOnlyThisType, out IEnumHierarchies ppenum)
        {
            ppenum = new MockEnumHierarchies(_projects);
            return VSConstants.S_OK;
        }

        public int GetProjectFactory(uint dwReserved, Guid[] pguidProjectType, string pszMkProject, out IVsProjectFactory ppProjectFactory)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int GetProjectFilesInSolution(uint grfGetOpts, uint cProjects, string[] rgbstrProjectNames, out uint pcProjectsFetched)
        {
            if (cProjects == 0)
            {
                pcProjectsFetched = (uint)_projects.Count;
            }
            else
            {
                for (int i = 0; i < cProjects; ++i)
                {
                    rgbstrProjectNames[i] = _projects[i].FullPath;
                }
                pcProjectsFetched = cProjects;
            }

            return VSConstants.S_OK;
        }

        public int GetProjectInfoOfProjref(string pszProjref, int propid, out object pvar)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int GetProjectOfGuid(ref Guid rguidProjectID, out IVsHierarchy ppHierarchy)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int GetProjectOfProjref(string pszProjref, out IVsHierarchy ppHierarchy, out string pbstrUpdatedProjref, VSUPDATEPROJREFREASON[] puprUpdateReason)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int GetProjectOfUniqueName(string pszUniqueName, out IVsHierarchy ppHierarchy)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int GetProjectTypeGuid(uint dwReserved, string pszMkProject, out Guid pguidProjectType)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int GetProjrefOfItem(IVsHierarchy pHierarchy, uint itemid, out string pbstrProjref)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int GetProjrefOfProject(IVsHierarchy pHierarchy, out string pbstrProjref)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int GetProperty(int propid, out object pvar)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int GetSolutionInfo(out string pbstrSolutionDirectory, out string pbstrSolutionFile, out string pbstrUserOptsFile)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int GetUniqueNameOfProject(IVsHierarchy pHierarchy, out string pbstrUniqueName)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int GetVirtualProjectFlags(IVsHierarchy pHierarchy, out uint pgrfAddVPFlags)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int OnAfterRenameProject(IVsProject pProject, string pszMkOldName, string pszMkNewName, uint dwReserved)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int OpenSolutionFile(uint grfOpenOpts, string pszFilename)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int OpenSolutionViaDlg(string pszStartDirectory, int fDefaultToAllProjectsFilter)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int QueryEditSolutionFile(out uint pdwEditResult)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int QueryRenameProject(IVsProject pProject, string pszMkOldName, string pszMkNewName, uint dwReserved, out int pfRenameCanContinue)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int RemoveVirtualProject(IVsHierarchy pHierarchy, uint grfRemoveVPFlags)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int SaveSolutionElement(uint grfSaveOpts, IVsHierarchy pHier, uint docCookie)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int SetProperty(int propid, object var)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int UnadviseSolutionEvents(uint dwCookie)
        {
            _eventSinks[(int)dwCookie - 1] = null;
            return VSConstants.S_OK;
        }

        #endregion

        #region IVsSolution3 Members

        public int CheckForAndSaveDeferredSaveSolution(int fCloseSolution, string pszMessage, string pszTitle, uint grfFlags)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int CreateNewProjectViaDlgEx(string pszDlgTitle, string pszTemplateDir, string pszExpand, string pszSelect, string pszHelpTopic, uint cnpvdeFlags, IVsBrowseProjectLocation pBrowse)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int GetUniqueUINameOfProject(IVsHierarchy pHierarchy, out string pbstrUniqueName)
        {
            MockIVsProject project = pHierarchy as MockIVsProject;

            pbstrUniqueName = "Unique name of " + project.FullPath;
            return VSConstants.S_OK;
        }

        public int UpdateProjectFileLocationForUpgrade(string pszCurrentLocation, string pszUpgradedLocation)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}

