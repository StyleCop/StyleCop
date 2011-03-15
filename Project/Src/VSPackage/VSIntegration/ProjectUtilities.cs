//-----------------------------------------------------------------------
// <copyright file="ProjectUtilities.cs">
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
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Security;
    using EnvDTE;

    /// <summary>
    /// Utility class for project related stuff.
    /// </summary>
    internal static class ProjectUtilities
    {
        #region Private Static Fields

        /// <summary>
        /// The "project enabled" cache used to prevent costly deep COM interactions after the "project enabled" data has already been collected.
        /// </summary>
        private static readonly Dictionary<string, bool> projectEnabledCache = new Dictionary<string, bool>();

        /// <summary>
        /// System Service provider.
        /// </summary>
        private static IServiceProvider serviceProvider;
       
        /// <summary>
        /// The EnvDTE class used to register ItemsAdded, ItemsRemoved, and ItemsRenamed events.
        /// </summary>
        private static ProjectItemsEvents projectItemsEvents;

        /// <summary>
        /// The Solution events.
        /// </summary>
        private static SolutionEvents solutionEvents;

        /// <summary>
        /// Keeps a collection of projects which do not contain the BuildAction property.
        /// </summary>
        private static Dictionary<string, List<string>> projectsMissingProperties;

        #endregion Private Static Fields

        #region Private Delegates

        /// <summary>
        /// Invokes a method to operate on the given project.
        /// </summary>
        /// <param name="project">The project to operate on.</param>
        /// <param name="projectKey">The unique key for the project.</param>
        /// <param name="path">The path to the project.</param>
        /// <param name="projectContext">Project-specific context information.</param>
        /// <param name="fileContext">File-specific context information.</param>
        /// <returns>If an object is returned, enumeration will end.</returns>
        private delegate object ProjectInvoker(Project project, int projectKey, string path, ref object projectContext, ref object fileContext);

        /// <summary>
        /// Invokes a method to operate on the given project item.
        /// </summary>
        /// <param name="projectItem">The project item to operate on.</param>
        /// <param name="path">The path to the project item.</param>
        /// <param name="projectContext">Project-specific context information.</param>
        /// <param name="fileContext">File-specific context information.</param>
        /// <returns>If an object is returned, enumeration will end.</returns>
        private delegate object ProjectItemInvoker(ProjectItem projectItem, string path, ref object projectContext, ref object fileContext);

        #endregion Private Delegates

        #region Internal Static Methods
        
        /// <summary>
        /// Initializes this static class.
        /// </summary>
        /// <param name="provider">The service provider to set.</param>
        internal static void Initialize(IServiceProvider provider)
        {
            Param.AssertNotNull(provider, "provider");
            serviceProvider = provider;

            DTE dte = GetDTE();
            if (dte != null)
            {
                Events events = dte.Events;

                // Our "project enabled cache" is invalidated whenever the projects change, so clear our cached
                // values any time one an event for project changes occur.
                if (events != null)
                {
                    if (projectItemsEvents == null)
                    {
                        projectItemsEvents = (ProjectItemsEvents)events.GetObject("ProjectItemsEvents");
                        if (projectItemsEvents != null)
                        {
                            projectItemsEvents.ItemAdded += ProjectItemsEventsClassItemAdded;
                            projectItemsEvents.ItemRemoved += ProjectItemsEventsClassItemRemoved;
                            projectItemsEvents.ItemRenamed += ProjectItemsEventsClassItemRenamed;
                        }
                    }

                    if (solutionEvents == null)
                    {
                        solutionEvents = events.SolutionEvents;
                        if (solutionEvents != null)
                        {
                            solutionEvents.ProjectAdded += SolutionEvents_ProjectAdded;
                            solutionEvents.ProjectRemoved += SolutionEvents_ProjectRemoved;
                            solutionEvents.ProjectRenamed += SolutionEvents_ProjectRenamed;
                        }
                    }
                }
            }
        }
        
        /// <summary>
        /// Gets the VS Document for the given file.
        /// </summary>
        /// <param name="file">The file to retrieve the document for.</param>
        /// <returns>Returns the VS Document object.</returns>
        internal static Document GetCodeDocument(string file)
        {
            Param.AssertValidString(file, "file");

            Document doc = null;

            try
            {
                DTE applicationObject = GetDTE();

                // Look for the file in the currently loaded project.
                if (applicationObject.Solution.Projects != null)
                {
                    foreach (Project project in applicationObject.Solution.Projects)
                    {
                        object codeEditor = EnumerateProject(
                            project,
                            null,
                            new ProjectItemInvoker(OpenCodeEditor),
                            null,
                            file);

                        if (codeEditor != null)
                        {
                            doc = codeEditor as Document;
                            if (doc != null)
                            {
                                break;
                            }
                        }
                    }
                }

                // Look for the item in the currently opened documents.
                if (doc == null)
                {
                    if (applicationObject.Documents != null)
                    {
                        foreach (Document document in applicationObject.Documents)
                        {
                            if (string.Compare(document.FullName, file, StringComparison.OrdinalIgnoreCase) == 0)
                            {
                                doc = document;
                                break;
                            }
                        }
                    }
                }
            }
            catch (COMException)
            {
            }

            return doc;
        }

        /// <summary>
        /// Attempts to locate a code editor document for the given file within the given project.
        /// </summary>
        /// <param name="projectItem">The project item to operate on.</param>
        /// <param name="path">The path to the project item.</param>
        /// <param name="projectContext">The project context.</param>
        /// <param name="fileContext">Contains the path to the file.</param>
        /// <returns>Returns the document for the given file if found.</returns>
        internal static object OpenCodeEditor(ProjectItem projectItem, string path, ref object projectContext, ref object fileContext)
        {
            Param.AssertNotNull(projectItem, "projectItem");
            Param.AssertValidString(path, "path");
            Param.Ignore(projectContext);
            Param.AssertNotNull(fileContext, "fileContext");

            string filePath = (string)fileContext;

            if (path == filePath)
            {
                projectItem.Open(Constants.vsViewKindCode);
                return projectItem.Document;
            }

            return null;
        }

        /// <summary>
        /// Gets the currently active project from the solution explorer.
        /// </summary>
        /// <returns>Returns the active project.</returns>
        internal static Project GetActiveProject()
        {
            DTE applicationObject = GetDTE();

            // Get the selected project.
            Array projects = (Array)applicationObject.ActiveSolutionProjects;
            Debug.Assert(projects.Length == 1, "More than one project is selected");

            return (Project)projects.GetValue(0);
        }

        /// <summary>
        /// Determines whether the StyleCop menu items should be shown.
        /// </summary>
        /// <param name="helper">The analysis helper instance.</param>
        /// <param name="type">Indicates the type of solution artifacts to search.</param>
        /// <returns>The type of solution node selected.</returns>
        internal static bool SupportsStyleCop(AnalysisHelper helper, AnalysisType type)
        {
            Param.Ignore(helper, type);

            DTE applicationObject = GetDTE();

            if (type == AnalysisType.Solution || type == AnalysisType.Project)
            {
                // Create a project enumerator for the correct VS project list.
                ProjectCollection enumerator = new ProjectCollection();

                if (type == AnalysisType.Solution)
                {
                    enumerator.SolutionProjects = applicationObject.Solution.Projects;
                }
                else
                {
                    enumerator.SelectedProjects = (IEnumerable)applicationObject.ActiveSolutionProjects;
                }

                // Enumerate through the VS projects.
                foreach (Project project in enumerator)
                {
                    if (project != null)
                    {
                        // If we've already cached a value for whether this project supports StyleCop, use it, since it is very
                        // expensive to constantly scan massive unmanaged project trees through COM.  This used to render Visual 
                        // Studio unusable in largely unmanaged solutions (http://stylecop.codeplex.com/workitem/6662).
                        bool isEnabled;
                        if (projectEnabledCache.ContainsKey(project.UniqueName))
                        {
                            isEnabled = projectEnabledCache[project.UniqueName];
                        }
                        else
                        {
                            isEnabled = EnumerateProject(
                                        project,
                                        new ProjectInvoker(IsKnownProjectTypeVisitor),
                                        new ProjectItemInvoker(IsKnownFileTypeVisitor),
                                        helper,
                                        null) != null;
                            projectEnabledCache.Add(project.UniqueName, isEnabled);
                        }

                        if (isEnabled)
                        {
                            return true;
                        }
                    }
                }
            }
            else if (type == AnalysisType.Item || type == AnalysisType.Folder)
            {
                if (AreSelectedFilesKnownFileTypes(helper))
                {
                    return true;
                }
            }
            else if (type == AnalysisType.File)
            {
                Document document = applicationObject.ActiveDocument;
                if (document != null && !string.IsNullOrEmpty(document.FullName))
                {
                    string fileExtension = Path.GetExtension(document.FullName);
                    if (fileExtension.Length > 0 && fileExtension.StartsWith(".", StringComparison.Ordinal))
                    {
                        fileExtension = fileExtension.Substring(1, fileExtension.Length - 1);
                    }

                    if (IsKnownFileExtension(fileExtension, helper.Core))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Creates the list of project files to be analyzed.
        /// </summary>
        /// <param name="core"><see cref="T:StyleCopCore">Core object</see> that hosts the environment.</param>
        /// <param name="type">The analyze type being performed.</param>
        /// <returns>Returns the list of projects.</returns>
        internal static IList<CodeProject> GetProjectList(StyleCopCore core, AnalysisType type)
        {
            Param.AssertNotNull(core, "core");
            Param.Ignore(type);

            // Create a list to store the list of code projects to be analyzed.
            List<CodeProject> codeProjects = new List<CodeProject>();

            DTE applicationObject = GetDTE();

            if (type == AnalysisType.Solution || type == AnalysisType.Project)
            {
                // Create a project enumerator for the correct VS project list.
                ProjectCollection enumerator = new ProjectCollection();

                if (type == AnalysisType.Solution)
                {
                    enumerator.SolutionProjects = applicationObject.Solution.Projects;
                }
                else
                {
                    enumerator.SelectedProjects = (IEnumerable)applicationObject.ActiveSolutionProjects;
                }

                // Enumerate through the VS projects.
                foreach (Project project in enumerator)
                {
                    if (project != null)
                    {
                        EnumerateProject(
                            project,
                            new ProjectInvoker(AddCodeProject),
                            new ProjectItemInvoker(AddFileToProject),
                            codeProjects,
                            null);
                    }
                }
            }
            else if (type == AnalysisType.Item || type == AnalysisType.Folder)
            {
                GetSelectedItemFiles(codeProjects);
            }
            else if (type == AnalysisType.File)
            {
                Document document = applicationObject.ActiveDocument;
                if (document != null)
                {
                    CodeProject codeProject = null;

                    string projectPath = GetProjectPath(document.ProjectItem.ContainingProject);
                    if (projectPath != null)
                    {
                        codeProject = new CodeProject(
                            projectPath.GetHashCode(),
                            projectPath,
                            GetProjectConfiguration(document.ProjectItem.ContainingProject));
                    }
                    else if (document.FullName != null && document.FullName.Length > 0)
                    {
                        codeProject = new CodeProject(
                            document.FullName.GetHashCode(),
                            Path.GetDirectoryName(document.FullName),
                            new StyleCop.Configuration(null));
                    }

                    if (codeProject != null)
                    {
                        core.Environment.AddSourceCode(codeProject, document.FullName, null);
                        codeProjects.Add(codeProject);
                    }
                }
            }
            else
            {
                Debug.Fail("Unknown analysis type requested.");
            }

            return codeProjects;
        }

        /// <summary>
        /// Gets the selected item files.
        /// </summary>
        /// <param name="codeProjects">The list of projects.</param>
        internal static void GetSelectedItemFiles(IList<CodeProject> codeProjects)
        {
            Param.AssertNotNull(codeProjects, "codeProjects");

            DTE applicationObject = GetDTE();

            // Check whether there are any selected files.
            if (applicationObject.SelectedItems.Count > 0)
            {
                Dictionary<Project, CodeProject> cachedProjects = new Dictionary<Project, CodeProject>();

                Project project = null;
                CodeProject codeProject = null;

                foreach (SelectedItem selectedItem in applicationObject.SelectedItems)
                {
                    if (selectedItem.ProjectItem != null && selectedItem.ProjectItem.ContainingProject != null)
                    {
                        if (selectedItem.ProjectItem.ContainingProject != project)
                        {
                            project = selectedItem.ProjectItem.ContainingProject;

                            if (!cachedProjects.TryGetValue(project, out codeProject))
                            {
                                string projectPath = GetProjectPath(project);
                                if (projectPath != null)
                                {
                                    codeProject = new CodeProject(
                                        projectPath.GetHashCode(),
                                        projectPath,
                                        GetProjectConfiguration(project));

                                    codeProjects.Add(codeProject);
                                    cachedProjects.Add(project, codeProject);
                                }
                            }
                        }

                        if (codeProject != null && project != null)
                        {
                            EnumerateProjectItem(
                                selectedItem.ProjectItem,
                                project.Name,
                                new ProjectInvoker(AddCodeProject),
                                new ProjectItemInvoker(AddFileToProject),
                                codeProjects,
                                codeProject);
                        }
                    }
                    else if (selectedItem.Project != null)
                    {
                        EnumerateProject(
                            selectedItem.Project,
                            new ProjectInvoker(AddCodeProject),
                            new ProjectItemInvoker(AddFileToProject),
                            codeProjects,
                            null);
                    }
                }
            }
        }

        /*

        /// <summary>
        /// Gets the opened item files.
        /// </summary>
        /// <param name="codeProjects">The list of projects.</param>
        internal static void GetOpenedFiles(IList<CodeProject> codeProjects)
        {
            Param.AssertNotNull(codeProjects, "codeProjects");

            DTE applicationObject = GetDTE();

            // Check whether there are any selected files.
            if (applicationObject.Documents.Count > 0)
            {
                Dictionary<Project, CodeProject> cachedProjects = new Dictionary<Project, CodeProject>();

                Project project = null;
                CodeProject codeProject = null;

                foreach (Document document in applicationObject.Documents)
                {
                    if (document.ProjectItem != null && document.ProjectItem.ContainingProject != null)
                    {
                        if (document.ProjectItem.ContainingProject != project)
                        {
                            project = document.ProjectItem.ContainingProject;

                            if (!cachedProjects.TryGetValue(project, out codeProject))
                            {
                                string projectPath = GetProjectPath(project);
                                if (projectPath != null)
                                {
                                    codeProject = new CodeProject(
                                        projectPath.GetHashCode(),
                                        projectPath,
                                        GetProjectConfiguration(project));

                                    codeProjects.Add(codeProject);
                                    cachedProjects.Add(project, codeProject);
                                }
                            }
                        }

                        if (codeProject != null && project != null)
                        {
                            EnumerateProjectItem(
                                document.ProjectItem,
                                project.Name,
                                new ProjectInvoker(AddCodeProject),
                                new ProjectItemInvoker(AddFileToProject),
                                codeProjects,
                                codeProject);
                        }
                    }
                }
            }
        }
         * 
         * */

        /// <summary>
        /// Gets the path to the given project.
        /// </summary>
        /// <param name="project">The project.</param>
        /// <returns>Returns the path to the project.</returns>
        internal static string GetProjectPath(Project project)
        {
            Param.AssertNotNull(project, "project");

            // First try the project.FileName property.
            string path = null;

            path = GetProjectFullName(project);

            if (string.IsNullOrEmpty(path))
            {
                // Next, see if there is a special property defined for this project.
                if (project.Properties != null)
                {
                    // By default use the property FullPath unless another is provided.
                    string propertyName = "FullPath";

                    StyleCopVSPackage package = serviceProvider.GetService(typeof(StyleCopVSPackage)) as StyleCopVSPackage;
                    string alternatePropertyName;

                    Dictionary<string, string> projectProperties = null;
                    if (package.Helper.ProjectTypes.TryGetValue(project.Kind, out projectProperties) && projectProperties != null)
                    {
                        if (projectProperties.TryGetValue("ProjectPath", out alternatePropertyName))
                        {
                            propertyName = alternatePropertyName;
                        }
                    }

                    try
                    {
                        Property property = project.Properties.Item(propertyName);
                        if (property != null)
                        {
                            path = (string)property.Value;
                        }
                    }
                    catch (ArgumentException)
                    {
                        // For certain project types, accessing the project.Properties.Item method can throw 
                        // an ArgumentException if the name of the property does not exist. In this case
                        // we simply skip this project.
                    }
                }
            }

            if (string.IsNullOrEmpty(path))
            {
                path = GetProjectFileName(project);
            }

            // Trim the path if necessary.
            if (!string.IsNullOrEmpty(path))
            {
                path = Path.GetDirectoryName(path);
            }

            return path == null ? null : (path.Length > 0 ? path : null);
        }

        /// <summary>
        /// Gets the active configuration for the given project.
        /// </summary>
        /// <param name="project">The project.</param>
        /// <returns>Returns the active configuration.</returns>
        internal static StyleCop.Configuration GetProjectConfiguration(Project project)
        {
            Param.AssertNotNull(project, "project");

            try
            {
                // Make sure the project has a configuration manager.
                if (project != null && project.ConfigurationManager != null)
                {
                    if (!IsProjectMissingProperty(project, "DefineConstants"))
                    {
                        // Check whether there is an active configuration.
                        Configuration activeConfiguration = project.ConfigurationManager.ActiveConfiguration;
                        if (activeConfiguration != null)
                        {
                            // Make sure the configuration has properties.
                            if (activeConfiguration != null && activeConfiguration.Properties != null)
                            {
                                // Get the constants.
                                Property property = activeConfiguration.Properties.Item("DefineConstants");
                                if (property != null && property.Value != null)
                                {
                                    string constantList = property.Value as string;
                                    if (constantList != null)
                                    {
                                        // Add each constants from this configuration and return it.
                                        return new StyleCop.Configuration(constantList.Split(';'));
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (COMException)
            {
            }
            catch (ArgumentException)
            {
                // For certain types of projects, the ConfigurationManager.ActiveConfiguration
                // property will throw an ArgumentException immediately when you try to access 
                // the property. This just means there is no configuration defined.
            }

            if (project != null)
            {
                AddMissingPropertyForProject(project, "DefineConstants");
            }

            // There is no active configuration. Just return an empty configuration object.
            return new StyleCop.Configuration(null);
        }

        #endregion Internal Static Methods

        #region Private Static Methods

        /// <summary>
        /// Gets an instance of the extensibility application object (DTE). 
        /// </summary>
        /// <remarks>
        /// This is not thread safe and should only be called from the UI thread. 
        /// </remarks>
        /// <returns>An instance of <see cref="T:EnvDTE.DTE."/>.</returns>
        private static DTE GetDTE()
        {
            Debug.Assert(serviceProvider != null, "serviceProvider is null");
            DTE applicationObject = (DTE)serviceProvider.GetService(typeof(DTE));
            Debug.Assert(applicationObject != null, "No DTE service available.");
            return applicationObject;
        }

        /// <summary>
        /// Enumerates through the given project.
        /// </summary>
        /// <param name="project">The project to enumerate.</param>
        /// <param name="projectCallback">Called on each project enumerated through.</param>
        /// <param name="projectItemCallback">Called on each project item enumerated through.</param>
        /// <param name="projectContext">Project-specific context information.</param>
        /// <param name="fileContext">File-specific context information.</param>
        /// <returns>If an object is returned, enumeration should end.</returns>
        private static object EnumerateProject(
            Project project,
            ProjectInvoker projectCallback,
            ProjectItemInvoker projectItemCallback,
            object projectContext,
            object fileContext)
        {
            Param.AssertNotNull(project, "project");
            Param.Ignore(projectCallback);
            Param.Ignore(projectItemCallback);
            Param.Ignore(projectContext);
            Param.Ignore(fileContext);

            DTE applicationObject = GetDTE();

            if (project.Kind == Constants.vsProjectKindSolutionItems)
            {
                // Figure out the path to the solution.
                string solutionPath = Path.GetDirectoryName(applicationObject.Solution.FullName);

                // Invoke the callback method on the project if necessary.
                if (projectCallback != null)
                {
                    // These types of projects are all located at the root of the solution, so we need
                    // to tack on the project name in order to differentiate between them.
                    string projectId = Path.Combine(applicationObject.Solution.FullName, project.Name);

                    object temp = projectCallback(
                        project,
                        projectId.GetHashCode(),
                        solutionPath,
                        ref projectContext,
                        ref fileContext);

                    if (temp != null)
                    {
                        return temp;
                    }
                }

                if (project.ProjectItems != null)
                {
                    // Enumerate the items under this solution project.
                    object temp = EnumerateSolutionProjectItems(
                        applicationObject.Solution,
                        project.ProjectItems,
                        solutionPath,
                        projectCallback,
                        projectItemCallback,
                        projectContext,
                        fileContext);

                    if (temp != null)
                    {
                        return temp;
                    }
                }
            }
            else
            {
                // Invoke the callback method on the project if necessary.
                if (projectCallback != null)
                {
                    string projectPath = GetProjectPath(project);
                    if (projectPath != null)
                    {
                        object temp = projectCallback(project, projectPath.GetHashCode(), projectPath, ref projectContext, ref fileContext);
                        if (temp != null)
                        {
                            return temp;
                        }
                    }
                }

                if (project.ProjectItems != null)
                {
                    // Enumerate the items under this project.
                    object temp = EnumerateProjectItems(
                        project.ProjectItems,
                        project.Name,
                        projectCallback,
                        projectItemCallback,
                        projectContext,
                        fileContext);

                    if (temp != null)
                    {
                        return temp;
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Enumerates through the items in the given solution project.
        /// </summary>
        /// <param name="solution">The solution contianing the project.</param>
        /// <param name="items">The list of items in the project.</param>
        /// <param name="solutionPath">The path to the solution.</param>
        /// <param name="projectCallback">Called on each project enumerated through.</param>
        /// <param name="projectItemCallback">Called on each project item enumerated through.</param>
        /// <param name="projectContext">Project-specific context information.</param>
        /// <param name="fileContext">File-specific context information.</param>
        /// <returns>If an object is returned, enumeration should end.</returns>
        private static object EnumerateSolutionProjectItems(
            Solution solution,
            ProjectItems items,
            string solutionPath,
            ProjectInvoker projectCallback,
            ProjectItemInvoker projectItemCallback,
            object projectContext,
            object fileContext)
        {
            Param.AssertNotNull(solution, "solution");
            Param.AssertNotNull(items, "items");
            Param.AssertValidString(solutionPath, "solutionPath");
            Param.Ignore(projectCallback);
            Param.Ignore(projectItemCallback);
            Param.Ignore(projectContext);
            Param.Ignore(fileContext);

            // Loop through each item in the solution project.
            foreach (ProjectItem item in items)
            {
                try
                {
                    switch (item.Kind)
                    {
                        case Constants.vsProjectItemKindSubProject:
                            if (item.SubProject != null)
                            {
                                object temp = EnumerateProject(item.SubProject, projectCallback, projectItemCallback, projectContext, fileContext);
                                if (temp != null)
                                {
                                    return temp;
                                }
                            }

                            break;

                        case Constants.vsProjectItemKindPhysicalFolder:
                        case Constants.vsProjectItemKindVirtualFolder:
                            if (item.ProjectItems != null)
                            {
                                object temp = EnumerateSolutionProjectItems(
                                    solution, item.ProjectItems, solutionPath, projectCallback, projectItemCallback, projectContext, fileContext);
                                if (temp != null)
                                {
                                    return temp;
                                }
                            }

                            break;

                        default:
                            // Call the callback for this item if necessary.
                            if (projectItemCallback != null && item.Name != null && item.Name.Length > 0)
                            {
                                string filePath = Path.Combine(solutionPath, item.Name);
                                object temp = projectItemCallback(item, filePath, ref projectContext, ref fileContext);
                                if (temp != null)
                                {
                                    return temp;
                                }
                            }

                            // If this is a physical file, check whether it has any sub-files.
                            if (item.Kind == Constants.vsProjectItemKindPhysicalFile ||
                                item.Kind == Constants.vsProjectItemKindSolutionItems)
                            {
                                if (item.ProjectItems != null && item.ProjectItems.Count > 0)
                                {
                                    object temp = EnumerateSolutionProjectItems(
                                        solution, item.ProjectItems, solutionPath, projectCallback, projectItemCallback, projectContext, fileContext);
                                    if (temp != null)
                                    {
                                        return temp;
                                    }
                                }
                            }

                            // Get the files from the subproject if there is one.
                            if (item.SubProject != null)
                            {
                                object temp = EnumerateProject(item.SubProject, projectCallback, projectItemCallback, projectContext, fileContext);
                                if (temp != null)
                                {
                                    return temp;
                                }
                            }

                            break;
                    }
                }
                catch (COMException)
                {
                }
            }

            return null;
        }

        /// <summary>
        /// Enumerates through the items in the given project items list.
        /// </summary>
        /// <param name="items">The items to add files from.</param>
        /// <param name="name">The name of the project.</param>
        /// <param name="projectCallback">Called on each project enumerated through.</param>
        /// <param name="projectItemCallback">Called on each project item enumerated through.</param>
        /// <param name="projectContext">Project-specific context information.</param>
        /// <param name="fileContext">File-specific context information.</param>
        /// <returns>If an object is returned, enumeration should end.</returns>
        private static object EnumerateProjectItems(
            ProjectItems items,
            string name,
            ProjectInvoker projectCallback,
            ProjectItemInvoker projectItemCallback,
            object projectContext,
            object fileContext)
        {
            Param.AssertNotNull(items, "items");
            Param.AssertNotNull(name, "name");
            Param.Ignore(projectCallback);
            Param.Ignore(projectItemCallback);
            Param.Ignore(projectContext);
            Param.Ignore(fileContext);

            // Loop through each item in the project.
            foreach (ProjectItem item in items)
            {
                object temp = EnumerateProjectItem(item, name, projectCallback, projectItemCallback, projectContext, fileContext);
                if (temp != null)
                {
                    return temp;
                }
            }

            return null;
        }

        /// <summary>
        /// Enumerates through the items under the given project item.
        /// </summary>
        /// <param name="item">The item to add.</param>
        /// <param name="name">The name of the project.</param>
        /// <param name="projectCallback">Called on each project enumerated through.</param>
        /// <param name="projectItemCallback">Called on each project item enumerated through.</param>
        /// <param name="projectContext">Project-specific context information.</param>
        /// <param name="fileContext">File-specific context information.</param>
        /// <returns>If an object is returned, enumeration should end.</returns>
        private static object EnumerateProjectItem(
            ProjectItem item,
            string name,
            ProjectInvoker projectCallback,
            ProjectItemInvoker projectItemCallback,
            object projectContext,
            object fileContext)
        {
            Param.AssertNotNull(item, "item");
            Param.AssertNotNull(name, "name");
            Param.Ignore(projectCallback);
            Param.Ignore(projectItemCallback);
            Param.Ignore(projectContext);
            Param.Ignore(fileContext);

            try
            {
                switch (item.Kind)
                {
                    case Constants.vsProjectItemKindSubProject:
                        if (item.SubProject != null)
                        {
                            object temp = EnumerateProject(item.SubProject, projectCallback, projectItemCallback, projectContext, fileContext);
                            if (temp != null)
                            {
                                return temp;
                            }
                        }

                        break;

                    case Constants.vsProjectItemKindPhysicalFolder:
                    case Constants.vsProjectItemKindVirtualFolder:
                        if (item.ProjectItems != null)
                        {
                            object temp = EnumerateProjectItems(item.ProjectItems, name, projectCallback, projectItemCallback, projectContext, fileContext);
                            if (temp != null)
                            {
                                return temp;
                            }
                        }

                        break;

                    default:
                        if (item.Properties != null)
                        {
                            if (projectItemCallback != null)
                            {
                                // Only add the item if the build action is set to compile.
                                if (CheckProjectItemBuildAction(item))
                                {
                                    string filePath = GetProjectItemPath(item);
                                    if (filePath != null && filePath.Length > 0)
                                    {
                                        object temp = projectItemCallback(item, filePath, ref projectContext, ref fileContext);
                                        if (temp != null)
                                        {
                                            return temp;
                                        }
                                    }
                                }
                            }
                        }

                        // Check whether it has any sub-files.
                        if (item.ProjectItems != null)
                        {
                            object temp = EnumerateProjectItems(item.ProjectItems, name, projectCallback, projectItemCallback, projectContext, fileContext);
                            if (temp != null)
                            {
                                return temp;
                            }
                        }

                        // If there is a sub-project, get the sub-project files.
                        if (item.SubProject != null)
                        {
                            object temp = EnumerateProject(item.SubProject, projectCallback, projectItemCallback, projectContext, fileContext);
                            if (temp != null)
                            {
                                return temp;
                            }
                        }

                        break;
                }
            }
            catch (COMException)
            {
            }

            return null;
        }

        /// <summary>
        /// Checks the given project item to ensure that the build action is not set to None.
        /// </summary>
        /// <param name="item">The build action to check.</param>
        /// <returns>Returns true if the build action is set to anything other than None.</returns>
        private static bool CheckProjectItemBuildAction(ProjectItem item)
        {
            Param.AssertNotNull(item, "item");

            try
            {
                // If the project containing this item does not contain the BuildAction property, then
                // return true to indicate that this file should be included.
                if (IsProjectMissingProperty(item.ContainingProject, "BuildAction"))
                {
                    return true;
                }

                Property buildAction = item.Properties.Item("BuildAction");
                if (buildAction != null)
                {
                    // BuildAction 0 == None
                    return (int)buildAction.Value != 0;
                }
            }
            catch (COMException)
            {
                // Can be thrown if the BuildAction property doesn't exist.
            }
            catch (ArgumentException)
            {
                // Can be thrown if the BuildAction property doesn't exist.
            }
            catch (InvalidCastException)
            {
                // Don't think this will ever happen, but this is here for robustness.
            }

            // We only get here if the BuildAction property does not exist. Make a note of this for next time.
            if (item.ContainingProject != null)
            {
                AddMissingPropertyForProject(item.ContainingProject, "BuildAction");
            }

            // Return true to indicate that this file type is ok.
            return true;
        }

        /// <summary>
        /// Determines whether the given project type is known to not contain the given property.
        /// </summary>
        /// <param name="project">The project to check.</param>
        /// <param name="propertyName">The name of the property.</param>
        /// <returns>Returns true if the project type is known to not contain the property.</returns>
        private static bool IsProjectMissingProperty(Project project, string propertyName)
        {
            Param.Ignore(project, "project");
            Param.AssertValidString(propertyName, "propertyName");

            if (project == null)
            {
                return true;
            }

            if (projectsMissingProperties == null)
            {
                return false;
            }

            List<string> missingProperties = null;
            if (!projectsMissingProperties.TryGetValue(project.Kind, out missingProperties) ||
                missingProperties == null ||
                !missingProperties.Contains(propertyName))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Registers the given project type as not containing the given property.
        /// </summary>
        /// <param name="project">The project.</param>
        /// <param name="propertyName">The property to register.</param>
        private static void AddMissingPropertyForProject(Project project, string propertyName)
        {
            Param.AssertNotNull(project, "project");
            Param.AssertNotNull(propertyName, "propertyName");

            if (projectsMissingProperties == null)
            {
                projectsMissingProperties = new Dictionary<string, List<string>>();
            }

            List<string> missingProperties = null;
            if (!projectsMissingProperties.TryGetValue(project.Kind, out missingProperties))
            {
                missingProperties = new List<string>(2);
                projectsMissingProperties.Add(project.Kind, missingProperties);
            }

            Debug.Assert(missingProperties != null, "Properties list should always be set here");

            missingProperties.Add(propertyName);
        }

        /// <summary>
        /// Adds a code project to the given list.
        /// </summary>
        /// <param name="project">The project to add.</param>
        /// <param name="projectKey">The unique key for the project.</param>
        /// <param name="path">The path to the project.</param>
        /// <param name="projectContext">Must contain a list of code projects.</param>
        /// <param name="fileContext">The context that will be passed to the file enumerator.</param>
        /// <returns>Always returns null so that enumeration will continue.</returns>
        private static object AddCodeProject(
            Project project, int projectKey, string path, ref object projectContext, ref object fileContext)
        {
            Param.AssertNotNull(project, "project");
            Param.Ignore(projectKey);
            Param.AssertValidString(path, "path");
            Param.AssertNotNull(projectContext, "projectContext");
            Param.Ignore(fileContext);

            // Get the list of code projects.
            List<CodeProject> codeProjects = (List<CodeProject>)projectContext;

            // Create a new CodeProject for this project.
            CodeProject codeProject = new CodeProject(
                projectKey,
                path,
                ProjectUtilities.GetProjectConfiguration(project));

            // Set this new CodeProject as the outgoing file context.
            fileContext = codeProject;

            // Add the new CodeProject to the list.
            codeProjects.Add(codeProject);

            return null;
        }

        /// <summary>
        /// Determines whether the project item is a known file type.
        /// </summary>
        /// <param name="projectItem">The project item to check.</param>
        /// <param name="path">The path to the project item.</param>
        /// <param name="projectContext">The project context.</param>
        /// <param name="fileContext">The file context.</param>
        /// <returns>Returns a non-null value if the item is a known file type, or null otherwise.</returns>
        private static object IsKnownFileTypeVisitor(
            ProjectItem projectItem, string path, ref object projectContext, ref object fileContext)
        {
            Param.Ignore(projectItem);
            Param.AssertValidString(path, "path");
            Param.AssertNotNull(projectContext, "projectContext");
            Param.Ignore(fileContext);

            string fileExtension = Path.GetExtension(projectItem.Name);
            if (fileExtension.Length > 0 && fileExtension.StartsWith(".", StringComparison.Ordinal))
            {
                fileExtension = fileExtension.Substring(1, fileExtension.Length - 1);
            }

            if (IsKnownFileExtension(fileExtension, ((AnalysisHelper)projectContext).Core))
            {
                return true;
            }

            return null;
        }

        /// <summary>
        /// Determines whether the given file extension is known.
        /// </summary>
        /// <param name="fileExtension">The file extension to check.</param>
        /// <param name="core">The core instance.</param>
        /// <returns>Returns true if the file extension is known, false otherwise.</returns>
        private static bool IsKnownFileExtension(string fileExtension, StyleCopCore core)
        {
            Param.AssertNotNull(fileExtension, "fileExtension");
            Param.AssertNotNull(core, "core");

            if (fileExtension.Length > 0)
            {
                foreach (SourceParser parser in core.Parsers)
                {
                    foreach (string fileType in parser.FileTypes)
                    {
                        if (string.Equals(fileExtension, fileType, StringComparison.OrdinalIgnoreCase))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Determines whether the project is a known project type.
        /// </summary>
        /// <param name="project">The project to add.</param>
        /// <param name="projectKey">The unique key for the project.</param>
        /// <param name="path">The path to the project.</param>
        /// <param name="projectContext">Contains the AnalysisHelper object.</param>
        /// <param name="fileContext">Is not used.</param>
        /// <returns>Returns a non-null value if the item is a known file type, or null otherwise.</returns>
        private static object IsKnownProjectTypeVisitor(
            Project project, int projectKey, string path, ref object projectContext, ref object fileContext)
        {
            Param.AssertNotNull(project, "project");
            Param.Ignore(projectKey);
            Param.AssertValidString(path, "path");
            Param.AssertNotNull(projectContext, "projectContext");
            Param.Ignore(fileContext);

            AnalysisHelper helper = (AnalysisHelper)projectContext;

            // If this project type exists in the list of known project types, then return true to indicate
            // that this is a known project type.
            if (helper.ProjectTypes != null)
            {
                Dictionary<string, string> properties = null;
                if (helper.ProjectTypes.TryGetValue(project.Kind, out properties))
                {
                    return true;
                }
            }

            // Return null to indicate that this is not a known project type and that the walker should continue searching.
            return null;
        }

        /// <summary>
        /// Determines whether any of the selected files are known file types.
        /// </summary>
        /// <param name="helper">The analysis helper instance.</param>
        /// <returns>Returns true if one of the selected items is a known type or contains a known type.</returns>
        private static bool AreSelectedFilesKnownFileTypes(AnalysisHelper helper)
        {
            Param.AssertNotNull(helper, "helper");

            DTE applicationObject = GetDTE();

            // Check whether there are any selected files.
            if (applicationObject.SelectedItems.Count > 0)
            {
                foreach (SelectedItem selectedItem in applicationObject.SelectedItems)
                {
                    if (selectedItem.ProjectItem != null && selectedItem.ProjectItem.ContainingProject != null)
                    {
                        if (EnumerateProjectItem(
                            selectedItem.ProjectItem,
                            selectedItem.ProjectItem.ContainingProject.Name,
                            null,
                            new ProjectItemInvoker(IsKnownFileTypeVisitor),
                            helper,
                            null) != null)
                        {
                            return true;
                        }
                    }
                    else if (selectedItem.Project != null)
                    {
                        if (EnumerateProject(
                            selectedItem.Project,
                            null,
                            new ProjectItemInvoker(IsKnownFileTypeVisitor),
                            helper,
                            null) != null)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Adds the given file to the given code project.
        /// </summary>
        /// <param name="projectItem">The project item describing the file.</param>
        /// <param name="path">The path to the file.</param>
        /// <param name="projectContext">The project context.</param>
        /// <param name="fileContext">Must contain the code project.</param>
        /// <returns>Always returns null so that enumeration will continue.</returns>
        private static object AddFileToProject(
            ProjectItem projectItem, string path, ref object projectContext, ref object fileContext)
        {
            Param.Ignore(projectItem);
            Param.AssertValidString(path, "path");
            Param.Ignore(projectContext);
            Param.Ignore(fileContext);

            if (fileContext != null)
            {
                // Get the code project.
                CodeProject codeProject = (CodeProject)fileContext;

                // Add the file to the code project.
                StyleCopVSPackage package = serviceProvider.GetService(typeof(StyleCopVSPackage)) as StyleCopVSPackage;
                Debug.Assert(package != null, "package is null");
                package.Core.Environment.AddSourceCode(codeProject, path, null);
            }

            return null;
        }

        /// <summary>
        /// Gets the path to the given project item.
        /// </summary>
        /// <param name="item">The project item.</param>
        /// <returns>Returns the path to the project item.</returns>
        private static string GetProjectItemPath(ProjectItem item)
        {
            Param.AssertNotNull(item, "item");

            try
            {
                if (item.ContainingProject != null && IsProjectMissingProperty(item.ContainingProject, "FullPath"))
                {
                    return null;
                }

                if (item.Properties != null)
                {
                    Property property = item.Properties.Item("FullPath");
                    if (property != null)
                    {
                        return (string)property.Value;
                    }
                }
            }
            catch (ArgumentException)
            {
                // For certain project item types, this throws an argument exception.
            }
            catch (COMException)
            {
                // For certain project types, this throws a COM Exception.
            }

            // Register that the project type does not contain this property.
            if (item.ContainingProject != null)
            {
                AddMissingPropertyForProject(item.ContainingProject, "FullPath");
            }

            return null;
        }

        /// <summary>
        /// Gets the FileName property from the given project, protecting against exceptions.
        /// </summary>
        /// <param name="project">The project.</param>
        /// <returns>Returns the value of the FileName property.</returns>
        private static string GetProjectFileName(Project project)
        {
            Param.AssertNotNull(project, "project");

            try
            {
                return project.FileName;
            }
            catch (NotImplementedException)
            {
                // Some project types will throw a NotImplementedException under certain contitions when this property is accessed.
            }
            catch (InvalidCastException)
            {
                // Some project types will throw an InvalidCastException under certain contitions when this property is accessed.
            }
            catch (COMException)
            {
                // Some project types will throw a COMException under certain contitions when this property is accessed.
            }

            return null;
        }

        /// <summary>
        /// Gets the FullName property from the given project, protecting against exceptions.
        /// </summary>
        /// <param name="project">The project.</param>
        /// <returns>Returns the value of the FullName property.</returns>
        private static string GetProjectFullName(Project project)
        {
            Param.AssertNotNull(project, "project");

            try
            {
                string fullName = project.FullName;

                // If the path starts with "http:" then it is not a valid file system path. This eliminates the
                // need for an exception to be thrown for web service projects, which always begin with something like http://, ftp://, etc.
                if (fullName != null && !fullName.StartsWith("http:", StringComparison.OrdinalIgnoreCase))
                {
                    // The Path.GetFullPath function will tell us whether or not the path is well formed
                    // and looks like a file system path.
                    return Path.GetFullPath(fullName);
                }
            }
            catch (ArgumentException)
            {
                // The path is not a valid file system path. This can happen for example with Web Service projects, 
                // where the project.FullName property contains a path like http://localhost/etc rather than a path on the file system.
            }
            catch (NotSupportedException)
            {
                // The path contains invalid characters.
            }
            catch (PathTooLongException)
            {
                // The path is too long.
            }
            catch (SecurityException)
            {
                // The user does not have permission to access the full path.
            }
            catch (NotImplementedException)
            {
                // Some project types will throw a NotImplementedException under certain contitions when this property is accessed.
            }
            catch (InvalidCastException)
            {
                // Some project types will throw an InvalidCastException under certain contitions when this property is accessed.
            }
            catch (COMException)
            {
                // Some project types will throw a COMException under certain contitions when this property is accessed.
            }

            return null;
        }

        /// <summary>
        /// Clear the static "project enabled" cache.  Use in reaction to events which invalidate the old cache.
        /// </summary>
        private static void ClearProjectEnabledCache()
        {
            projectEnabledCache.Clear();
        }

        /// <summary>
        /// The ProjectItemsEventClass ItemAdded event handler.
        /// </summary>
        /// <param name="projectItem">The item added.</param>
        private static void ProjectItemsEventsClassItemAdded(ProjectItem projectItem)
        {
            Param.AssertNotNull(projectItem, "projectItem");
            ClearProjectEnabledCache();
        }

        /// <summary>
        /// The ProjectItemsEventClass ItemRenamed event handler.
        /// </summary>
        /// <param name="projectItem">The item renamed.</param>
        /// <param name="oldName">The old name of the item.</param>
        private static void ProjectItemsEventsClassItemRenamed(ProjectItem projectItem, string oldName)
        {
            Param.AssertNotNull(projectItem, "projectItem");
            Param.AssertNotNull(oldName, "oldName");
            ClearProjectEnabledCache();
        }

        /// <summary>
        /// The ProjectItemsEventClass ItemRemoved event handler.
        /// </summary>
        /// <param name="projectItem">The item removed.</param>
        private static void ProjectItemsEventsClassItemRemoved(ProjectItem projectItem)
        {
            Param.AssertNotNull(projectItem, "projectItem");
            ClearProjectEnabledCache();
        }

        /// <summary>
        /// The SolutionEventsProjectRenamed handler.
        /// </summary>
        /// <param name="project">The project that was renamed.</param>
        /// <param name="oldName">The old name.</param>
        private static void SolutionEvents_ProjectRenamed(Project project, string oldName)
        {
            ClearProjectEnabledCache();
        }

        /// <summary>
        /// The SolutionEventsProjectRemoved handler.
        /// </summary>
        /// <param name="project">The project that was removed.</param>
        private static void SolutionEvents_ProjectRemoved(Project project)
        {
            ClearProjectEnabledCache();
        }

        /// <summary>
        /// The SolutionEventsProjecAdded handler.
        /// </summary>
        /// <param name="project">The project that was added.</param>
        private static void SolutionEvents_ProjectAdded(Project project)
        {
            ClearProjectEnabledCache();
        }

        #endregion Private Static Methods

        /*
        internal static IEnumerable<string> GetMultiSelectionFilenames()
        {
            IVsMonitorSelection selectionMonitor = serviceProvider.GetService(typeof(IVsMonitorSelection)) as IVsMonitorSelection;

            IntPtr hierarchyPtr = IntPtr.Zero;
            uint itemID = 0;
            IVsMultiItemSelect multiSelect = null;
            IntPtr containerPtr = IntPtr.Zero;

            int hr = selectionMonitor.GetCurrentSelection(out hierarchyPtr, out itemID, out multiSelect, out containerPtr);
            if (IntPtr.Zero != containerPtr)
            {
                Marshal.Release(containerPtr);
                containerPtr = IntPtr.Zero;
            }

            Debug.Assert(hr == VSConstants.S_OK, "GetCurrentSelection failed.");

            if (itemID == VSConstants.VSITEMID_SELECTION)
            {
                uint itemCount = 0;
                int singleHierarchy = 0;
                hr = multiSelect.GetSelectionInfo(out itemCount, out singleHierarchy);
                Debug.Assert(hr == VSConstants.S_OK, "GetSelectionInfo failed.");
                ErrorHandler.ThrowOnFailure(hr);

                VSITEMSELECTION[] items = new VSITEMSELECTION[itemCount];
                hr = multiSelect.GetSelectedItems(0, itemCount, items);
                Debug.Assert(hr == VSConstants.S_OK, "GetSelectedItems failed.");
                ErrorHandler.ThrowOnFailure(hr);

                foreach (VSITEMSELECTION item in items)
                {
                    object result;
                    item.pHier.GetProperty(item.itemid, (int)__VSHPROPID.VSHPROPID_Name, out result);
                    string name = (string)result;
                    yield return name;
                }
            }
//            return null;
        }
        

        internal static string GetSingleItemShortFilename()
        {
            IVsMonitorSelection selectionMonitor = serviceProvider.GetService(typeof(IVsMonitorSelection)) as IVsMonitorSelection;

            IntPtr hierarchyPtr = IntPtr.Zero;
            uint itemID = 0;
            IVsMultiItemSelect multiSelect = null;
            IntPtr containerPtr = IntPtr.Zero;

            int hr = selectionMonitor.GetCurrentSelection(out hierarchyPtr, out itemID, out multiSelect, out containerPtr);

            if (IntPtr.Zero != containerPtr)
            {
                Marshal.Release(containerPtr);
                containerPtr = IntPtr.Zero;
            }

            Debug.Assert(hr == VSConstants.S_OK, "GetCurrentSelection failed.");
            ErrorHandler.ThrowOnFailure(hr);

            Debug.Assert(itemID != VSConstants.VSITEMID_SELECTION, "This should only be called on single item selections.");
            Debug.Assert(multiSelect == null, "Internal error multi select is supposed to be null here");
            if (hierarchyPtr == IntPtr.Zero)
            {
                Debug.Assert(itemID != VSConstants.VSITEMID_ROOT, "This was called on the solution node.");
                throw new InvalidOperationException();
            }

            IVsHierarchy hierarchy = (IVsHierarchy)Marshal.GetUniqueObjectForIUnknown(hierarchyPtr);

            object result;
            ErrorHandler.ThrowOnFailure(
                hierarchy.GetProperty(itemID, (int)__VSHPROPID.VSHPROPID_ProjectName, out result));
            ErrorHandler.ThrowOnFailure(
                hierarchy.GetProperty(itemID, (int)__VSHPROPID.VSHPROPID_SaveName, out result));
            ErrorHandler.ThrowOnFailure(
                hierarchy.GetProperty(itemID, (int)__VSHPROPID.VSHPROPID_TypeName, out result));
            ErrorHandler.ThrowOnFailure(
                hierarchy.GetProperty(itemID, (int)__VSHPROPID.VSHPROPID_Name, out result));

            return result as string;
        }

        private static IVsProject GetProjectOfItem(IVsHierarchy hierarchy, uint itemID)
        {
            return (IVsProject)hierarchy;
        }

        /*
        /// <summary>
        /// Gets the projects of current selections.
        /// </summary>
        /// <returns>A list of projects.</returns>
        internal static IList<IVsProject> GetProjectsOfCurrentSelections()
        {
            List<IVsProject> results = new List<IVsProject>();

            int hr = VSConstants.S_OK;
            IVsMonitorSelection selectionMonitor = serviceProvider.GetService(typeof(IVsMonitorSelection)) as IVsMonitorSelection;
            IntPtr hierarchyPtr = IntPtr.Zero;
            uint itemID = 0;
            IVsMultiItemSelect multiSelect = null;
            IntPtr containerPtr = IntPtr.Zero;
            hr = selectionMonitor.GetCurrentSelection(out hierarchyPtr, out itemID, out multiSelect, out containerPtr);
            if (IntPtr.Zero != containerPtr)
            {
                Marshal.Release(containerPtr);
                containerPtr = IntPtr.Zero;
            }
            Debug.Assert(hr == VSConstants.S_OK, "GetCurrentSelection failed.");

            if (itemID == HierarchyConstants.VSITEMID_SELECTION)
            {
                uint itemCount = 0;
                int fSingleHierarchy = 0;
                hr = multiSelect.GetSelectionInfo(out itemCount, out fSingleHierarchy);
                Debug.Assert(hr == VSConstants.S_OK, "GetSelectionInfo failed.");

                VSITEMSELECTION[] items = new VSITEMSELECTION[itemCount];
                hr = multiSelect.GetSelectedItems(0, itemCount, items);
                Debug.Assert(hr == VSConstants.S_OK, "GetSelectedItems failed.");

                foreach (VSITEMSELECTION item in items)
                {
                    IVsProject project = GetProjectOfItem(item.pHier, item.itemid);
                    if (!results.Contains(project))
                    {
                        results.Add(project);
                    }
                }
            }
            else
            {
                //case where no visible project is open (single file)
                if (hierarchyPtr != IntPtr.Zero)
                {
                    IVsHierarchy hierarchy = (IVsHierarchy)Marshal.GetUniqueObjectForIUnknown(hierarchyPtr);
                    results.Add(GetProjectOfItem(hierarchy, itemID));
                }
            }

            return results;
        }

        internal static string GetProjectFilePath(IVsProject project)
        {
            string path = string.Empty;
            int hr = project.GetMkDocument(HierarchyConstants.VSITEMID_ROOT, out path);
            Debug.Assert(hr == VSConstants.S_OK || hr == VSConstants.E_NOTIMPL, "GetMkDocument failed for project.");

            return path;
        }

        internal static string GetUniqueProjectNameFromFile(string projectFile)
        {
            IVsProject project = GetProjectByFileName(projectFile);

            if (project != null)
            {
                return GetUniqueUIName(project);
            }

            return null;
        }

        internal static string GetUniqueUIName(IVsProject project)
        {
            IVsSolution3 solution = serviceProvider.GetService(typeof(SVsSolution)) as IVsSolution3;
            string name = null;
            int hr = solution.GetUniqueUINameOfProject((IVsHierarchy)project, out name);
            Debug.Assert(hr == VSConstants.S_OK, "GetUniqueUINameOfProject failed.");
            return name;
        }

        /// <summary>
        /// List the projects that are loaded in the solution.
        /// </summary>
        /// <returns>An enumeration of <see cref="T>IVsProject">Projects</see>.</returns>
        internal static IEnumerable<IVsProject> GetLoadedProjects()
        {
            IVsSolution solution = serviceProvider.GetService(typeof(SVsSolution)) as IVsSolution;
            IEnumHierarchies enumerator = null;
            Guid guid = Guid.Empty;
            solution.GetProjectEnum((uint)__VSENUMPROJFLAGS.EPF_LOADEDINSOLUTION, ref guid, out enumerator);
            IVsHierarchy[] hierarchy = new IVsHierarchy[1] { null };
            uint fetched = 0;
            for (enumerator.Reset(); enumerator.Next(1, hierarchy, out fetched) == VSConstants.S_OK && fetched == 1; ) // 1 means *nothing*
            {
                yield return (IVsProject)hierarchy[0];
            }
        }

        internal static IVsProject GetProjectByFileName(string projectFile)
        {
            foreach (IVsProject project in GetLoadedProjects())
            {
                if (string.Compare(projectFile, GetProjectFilePath(project), StringComparison.OrdinalIgnoreCase) == 0)
                {
                    return project;
                }
            }

            return null;
        }
         */
    }
}