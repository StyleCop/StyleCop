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
    using System.Data;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using System.Security;
    using EnvDTE;

    using Microsoft.VisualStudio.Shell;
    using Microsoft.VisualStudio.Shell.Interop;

    using Constants = EnvDTE.Constants;
    using Project = EnvDTE.Project;

    /// <summary>
    /// Utility class for project related stuff.
    /// </summary>
    internal static class ProjectUtilities
    {
        #region Constants

        private const string StyleCopTreatErrorsAsWarnings = "StyleCopTreatErrorsAsWarnings";

        private const string StyleCopTargetsName = "StyleCop.targets";

        private const string StyleCopTargetsFullName = @"$(ProgramFiles)\MSBuild\StyleCop\v4.7\StyleCop.targets";

        #endregion

        #region Private Static Fields

        /// <summary>
        /// The cache used to prevent costly deep COM interactions after the "project enabled" data has already been collected.
        /// </summary>
        private static readonly Dictionary<string, bool> ProjectEnabledCache = new Dictionary<string, bool>();

        /// <summary>
        /// The cache used to prevent costly deep disk interactions after the 'StyleCop Excluded' data has already been collected.
        /// </summary>
        private static readonly Dictionary<string, bool> ProjectItemExcluded = new Dictionary<string, bool>();

        /// <summary>
        /// Keeps a collection of projects which do not contain the properties in the List.
        /// </summary>
        private static readonly Dictionary<string, List<string>> ProjectsMissingProperties = new Dictionary<string, List<string>>();

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
        /// <param name="analysisType">The type of analysis being completed.</param>
        /// <param name="projectContext">Project-specific context information.</param>
        /// <param name="fileContext">File-specific context information.</param>
        /// <returns>If an object is returned, enumeration will end.</returns>
        private delegate object ProjectItemInvoker(ProjectItem projectItem, string path, AnalysisType analysisType, ref object projectContext, ref object fileContext);

        #endregion Private Delegates
        
        #region Enums

        /// <summary>
        /// The build integration setting.
        /// </summary>
        internal enum BuildIntegration
        {
            None,
            TreatErrorAsWarning,
            TreatErrorAsError
        }

        #endregion

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
                            solutionEvents.ProjectAdded += SolutionEventsProjectAdded;
                            solutionEvents.ProjectRemoved += SolutionEventsProjectRemoved;
                            solutionEvents.ProjectRenamed += SolutionEventsProjectRenamed;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Determines the target framework version for the c# project file.
        /// </summary> 
        /// <param name="project">The project file to read property.</param> 
        /// <returns>The target framework version, or 0 if none is specified.</returns> 
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Cannot allow exception from plug-in to kill VS or build")]
        internal static double TargetFrameworkVersion(Project project)
        {
            string projectFilePathName = GetProjectFileName(project);
            if (string.IsNullOrEmpty(projectFilePathName))
            {
                return 0.0;
            }
            
            using (DataSet data = new DataSet())
            {
                data.Locale = CultureInfo.InvariantCulture;

                try
                {
                    // Load project as dataset
                    data.ReadXml(projectFilePathName);
                    DataTable propertyGroups = data.Tables["PropertyGroup"];

                    object projectTargetFrameworkVersion = propertyGroups.Rows[0]["TargetFrameworkVersion"];

                    if (projectTargetFrameworkVersion != System.DBNull.Value)
                    {
                        double targetFrameworkVersion;
                        string projectTargetFrameworkVersionString = (string)projectTargetFrameworkVersion;

                        if (projectTargetFrameworkVersionString.Length > 4)
                        {
                            // TargetFrameworkVersion will be something like "v4.5.1", so skip the "v" and last char when parsing to double: 
                            if (double.TryParse(projectTargetFrameworkVersionString.Substring(1, 3), out targetFrameworkVersion))
                            {
                                return targetFrameworkVersion;
                            }
                        }
                        else
                        {
                            // TargetFrameworkVersion will be something like "v3.5", so skip the "v" when parsing to double: 
                            if (double.TryParse(projectTargetFrameworkVersionString.Substring(1), out targetFrameworkVersion))
                            {
                                return targetFrameworkVersion;
                            }
                        }
                    }
                }
                catch
                {
                    // Ignore missing TargetFrameworkVersion version. Just return 0.0.
                }
            }

            return 0.0;
        }

        /// <summary>
        /// Sets the active ProjectItem to Excluded or not.
        /// </summary>
        /// <param name="type">Type of analysis.</param>
        /// <param name="value">The value to set it to.</param>
        /// <returns>True if we've been able to set the value.</returns>
        internal static bool SetItemExcluded(AnalysisType type, bool value)
        {
            Param.Ignore(type);

            DTE applicationObject = GetDTE();

            if (type == AnalysisType.Solution || type == AnalysisType.Project || type == AnalysisType.Folder)
            {
                return false;
            }

            if (type == AnalysisType.Item)
            {
                // Check whether there are any selected files.
                if (applicationObject.SelectedItems.Count == 1)
                {
                    foreach (SelectedItem selectedItem in applicationObject.SelectedItems)
                    {
                        if (selectedItem.ProjectItem != null && selectedItem.ProjectItem.ContainingProject != null)
                        {
                            return SetProjectItemExcluded(selectedItem.ProjectItem, value);
                        }

                        return false;
                    }
                }

                return false;
            }

            if (type == AnalysisType.File)
            {
                Document document = applicationObject.ActiveDocument;
                if (document != null && !string.IsNullOrEmpty(document.FullName))
                {
                    return SetProjectItemExcluded(document.ProjectItem, value);
                }
            }

            return false;
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
                        object codeEditor = EnumerateProject(project, null, OpenCodeEditor, null, file);

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
        /// Gets the EnvDTE.Project for the given file.
        /// </summary>
        /// <param name="file">The file to retrieve the document for.</param>
        /// <returns>Returns the Project object.</returns>
        internal static Project GetProject(string file)
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
                        object codeEditor = EnumerateProject(project, null, OpenCodeEditor, null, file);

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

            return doc != null ? doc.ProjectItem.ContainingProject : null;
        }

        /// <summary>
        /// Attempts to locate a code editor document for the given file within the given project.
        /// </summary>
        /// <param name="projectItem">The project item to operate on.</param>
        /// <param name="path">The path to the project item.</param>
        /// <param name="analysisType">The type of analysis being completed.</param>
        /// <param name="projectContext">The project context.</param>
        /// <param name="fileContext">Contains the path to the file.</param>
        /// <returns>Returns the document for the given file if found.</returns>
        internal static object OpenCodeEditor(ProjectItem projectItem, string path, AnalysisType analysisType, ref object projectContext, ref object fileContext)
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
                        // Studio unusable in largely unmanaged solutions (#6662).
                        bool isEnabled;

                        if (ProjectEnabledCache.ContainsKey(project.UniqueName))
                        {
                            isEnabled = ProjectEnabledCache[project.UniqueName];
                        }
                        else
                        {
                            isEnabled = EnumerateProject(project, IsKnownProjectTypeVisitor, IsKnownFileTypeVisitor, helper, null) != null;
                            ProjectEnabledCache.Add(project.UniqueName, isEnabled);
                        }

                        if (isEnabled)
                        {
                            return true;
                        }
                    }
                }

                return false;
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
        /// Determines whether the selected item is included in StyleCop analysis.
        /// </summary>
        /// <param name="type">Indicates the type of solution artifacts to search.</param>
        /// <returns>True if the selected item would be included in analysis.</returns>
        internal static bool IsItemIncluded(AnalysisType type)
        {
            DTE applicationObject = GetDTE();

            if (type == AnalysisType.Solution || type == AnalysisType.Project || type == AnalysisType.Folder)
            {
                return true;
            }

            if (type == AnalysisType.Item)
            {
                // Check whether there are any selected files.
                // More than 1 selected we just return true
                if (applicationObject.SelectedItems.Count == 0 || applicationObject.SelectedItems.Count > 1)
                {
                    return true;
                }

                foreach (SelectedItem selectedItem in applicationObject.SelectedItems)
                {
                    if (selectedItem.ProjectItem != null && selectedItem.ProjectItem.ContainingProject != null)
                    {
                        return CheckProjectItemIsIncluded(selectedItem.ProjectItem);
                    }

                    return true;
                }

                return false;
            }

            if (type == AnalysisType.File)
            {
                Document document = applicationObject.ActiveDocument;
                if (document != null && !string.IsNullOrEmpty(document.FullName))
                {
                    return CheckProjectItemIsIncluded(document.ProjectItem);
                }
            }

            return false;
        }

        /// <summary>
        /// Creates the list of project files to be analyzed.
        /// </summary>
        /// <param name="core"><see cref="T:StyleCopCore">Core object</see> that hosts the environment.</param>
        /// <param name="type">The analyze type being performed.</param>
        /// <param name="analysisFilePath">The path to the initial file we are analyzing.</param>
        /// <param name="analysisHelper">The analysis helper.</param>
        /// <returns>Returns the list of projects.</returns>
        internal static IList<CodeProject> GetProjectList(StyleCopCore core, AnalysisType type, out string analysisFilePath, AnalysisHelper analysisHelper)
        {
            Param.AssertNotNull(core, "core");
            Param.Ignore(type);

            // Create a list to store the list of code projects to be analyzed.
            List<CodeProject> codeProjects = new List<CodeProject>();

            DTE applicationObject = GetDTE();

            analysisFilePath = null;

            switch (type)
            {
                case AnalysisType.Project:
                case AnalysisType.Solution:
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
                        // We continue if we know the project type or if its a misc item or a solution folder
                        if (project != null && (IsKnownProjectType(project, analysisHelper) ||
                            project.Kind == Constants.vsProjectKindMisc ||
                            project.Kind == Constants.vsProjectKindSolutionItems))
                        {
                            EnumerateProject(project, AddCodeProject, AddFileToProject, codeProjects, null);
                        }
                    }

                    break;

                case AnalysisType.Folder:
                case AnalysisType.Item:
                    analysisFilePath = GetSelectedItemFiles(codeProjects);
                    break;

                case AnalysisType.File:
                    var document = applicationObject.ActiveDocument;
                    if (document != null)
                    {
                        CodeProject codeProject = null;

                        string projectPath = GetProjectPath(document.ProjectItem.ContainingProject);
                        if (projectPath != null)
                        {
                            codeProject = new CodeProject(projectPath.GetHashCode(), projectPath, GetProjectConfiguration(document.ProjectItem.ContainingProject), TargetFrameworkVersion(document.ProjectItem.ContainingProject));
                        }
                        else if (!string.IsNullOrEmpty(document.FullName))
                        {
                            codeProject = new CodeProject(document.FullName.GetHashCode(), Path.GetDirectoryName(document.FullName), new StyleCop.Configuration(null));
                        }

                        if (codeProject != null)
                        {
                            // If this is a designer.cs file (and so a dependant of another file) then we need to add it but also its parent and siblings.
                            analysisFilePath = document.FullName;

                            var allFilesForProjectItem = GetAllFilesForProjectItem(document.ProjectItem);

                            foreach (var path in allFilesForProjectItem)
                            {
                                core.Environment.AddSourceCode(codeProject, path, null);
                            }

                            codeProjects.Add(codeProject);
                        }
                    }

                    break;
                default:
                    Debug.Fail("Unknown analysis type requested.");
                    break;
            }

            return codeProjects;
        }

        /// <summary>
        /// Gets the selected item files.
        /// </summary>
        /// <param name="codeProjects">The list of projects.</param>
        /// <returns>The path to the first file actually selected. Null if we were on a selected folder.</returns>
        internal static string GetSelectedItemFiles(IList<CodeProject> codeProjects)
        {
            Param.AssertNotNull(codeProjects, "codeProjects");

            string analysisFilePath = null;

            DTE applicationObject = GetDTE();

            // Check whether there are any selected files.
            if (applicationObject.SelectedItems.Count > 0)
            {
                var cachedProjects = new Dictionary<Project, CodeProject>();

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
                                    codeProject = new CodeProject(projectPath.GetHashCode(), projectPath, GetProjectConfiguration(project), TargetFrameworkVersion(project));

                                    codeProjects.Add(codeProject);
                                    cachedProjects.Add(project, codeProject);
                                }
                            }
                        }

                        if (codeProject != null)
                        {
                            EnumerateProjectItem(selectedItem.ProjectItem, project.Name, AddCodeProject, AddFileToProject, codeProjects, codeProject);
                        }
                    }
                    else if (selectedItem.Project != null)
                    {
                        EnumerateProject(selectedItem.Project, AddCodeProject, AddFileToProject, codeProjects, null);
                    }
                }
            }

            // Not always null because of the delegates. Leave this here.
            return analysisFilePath;
        }

        /// <summary>
        /// Gets the path to the given project.
        /// </summary>
        /// <param name="project">The project.</param>
        /// <returns>Returns the path to the project or null if we can't get it.</returns>
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
                    if (!ProjectHasPropertyMissing(project, "DefineConstants"))
                    {
                        // Check whether there is an active configuration.
                        Configuration activeConfiguration = project.ConfigurationManager.ActiveConfiguration;
                        if (activeConfiguration != null)
                        {
                            // Make sure the configuration has properties.
                            if (activeConfiguration.Properties != null)
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

            // If we get here we've either not got the property or had an exception
            AddMissingPropertyForProject(project, "DefineConstants");

            // There is no active configuration. Just return an empty configuration object.
            return new StyleCop.Configuration(null);
        }

        /// <summary>
        /// Gets the FullName property from the given project, protecting against exceptions.
        /// </summary>
        /// <param name="project">The project.</param>
        /// <returns>Returns the value of the FullName property.</returns>
        internal static string GetProjectFullName(Project project)
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
        /// Sets build integration setting in project.
        /// </summary>
        /// <param name="project">The MSBuild project.</param>
        /// <param name="buildIntegration">The build integration setting.</param>
        internal static void SetBuildIntegrationInProject(Microsoft.Build.Evaluation.Project project, BuildIntegration buildIntegration)
        {
            Param.AssertNotNull(project, "project");
            Param.AssertNotNull(buildIntegration, "buildIntegration");

            SetBuildIntegrationInProject(project, buildIntegration != BuildIntegration.None);
            SetTreatLevel(project, buildIntegration);

            project.Save();
        }

        internal static BuildIntegration GetBuildIntegrationInProject(Microsoft.Build.Evaluation.Project project)
        {
            Param.AssertNotNull(project, "project");

            ProjectUtilities.BuildIntegration setting = BuildIntegration.None;
            if (project.Imports.Any(p => p.ImportedProject.FullPath.IndexOf(StyleCopTargetsName, StringComparison.OrdinalIgnoreCase) != -1))
            {
                setting = BuildIntegration.TreatErrorAsWarning;
                var styleCopTreatErrorsAsWarningsProp = project.AllEvaluatedProperties
                    .SingleOrDefault(p => p.Name == StyleCopTreatErrorsAsWarnings);
                string property = styleCopTreatErrorsAsWarningsProp != null
                    ? styleCopTreatErrorsAsWarningsProp.EvaluatedValue
                    : null;
                bool treatAsWarnings;
                if (bool.TryParse(property, out treatAsWarnings) && !treatAsWarnings)
                {
                    setting = BuildIntegration.TreatErrorAsError;
                }
            }

            return setting;
        }

        #endregion Internal Static Methods

        #region Private Static Methods

        /// <summary>
        /// Gets a list of all the files for the given projectItem. Includes all dependant files for partial types.
        /// </summary>
        /// <param name="projectItem">The projectItem to find the files for.</param>
        /// <returns>A list of all the files for this project.</returns>
        private static IEnumerable<string> GetAllFilesForProjectItem(ProjectItem projectItem)
        {
            var files = new List<string>();

            // If this is a designer.cs file (and so a dependant of another file) then we need to add it but also its parent and siblings.
            var parentProjectItem = projectItem.Collection.Parent as ProjectItem;

            // Checking for != folder
            if (parentProjectItem != null && parentProjectItem.Kind != Constants.vsProjectItemKindPhysicalFolder)
            {
                // So document is dependant on 'f' so add that too
                files.Add(parentProjectItem.FileNames[0]);

                foreach (ProjectItem dependentItem in parentProjectItem.ProjectItems)
                {
                    // So document is dependant on 'f' so add that too
                    files.Add(dependentItem.FileNames[0]);
                }
            }
            else
            {
                files.Add(projectItem.FileNames[0]);
            }

            return files;
        }

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

                    object callbackResult = projectCallback(project, projectId.GetHashCode(), solutionPath, ref projectContext, ref fileContext);

                    if (callbackResult != null)
                    {
                        return callbackResult;
                    }
                }

                if (project.ProjectItems != null)
                {
                    // Enumerate the items under this solution project.
                    object temp = EnumerateSolutionProjectItems(
                        applicationObject.Solution, project.ProjectItems, solutionPath, projectCallback, projectItemCallback, projectContext, fileContext);

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
                        object callbackResult = projectCallback(project, projectPath.GetHashCode(), projectPath, ref projectContext, ref fileContext);
                        if (callbackResult != null)
                        {
                            return callbackResult;
                        }
                    }
                }

                if (project.ProjectItems != null)
                {
                    // Enumerate the items under this project.
                    object temp = EnumerateProjectItems(project.ProjectItems, project.Name, projectCallback, projectItemCallback, projectContext, fileContext);

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
        /// <param name="solution">The solution containing the project.</param>
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
                                object temp = projectItemCallback(item, filePath, AnalysisType.Solution, ref projectContext, ref fileContext);
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
        /// Checks to see if the project item is excluded from stylecop in the project file.
        /// </summary>
        /// <param name="item">The ProjectItem to check.</param>
        /// <param name="newValue">The value to ensure its set to.</param>
        /// <returns>True if the item had its setting changed.</returns>
        [SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResult", Justification = "Using the default value from bool.TryParse")]
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Cannot allow exception from plug-in to kill VS or build")]
        private static bool SetProjectItemExcluded(ProjectItem item, bool newValue)
        {
            try
            {
                string uniqueName = item.ContainingProject.UniqueName;

                var solution = (IVsSolution)Package.GetGlobalService(typeof(SVsSolution));

                IVsHierarchy hierarchy;

                solution.GetProjectOfUniqueName(uniqueName, out hierarchy);

                var buildPropertyStorage = hierarchy as IVsBuildPropertyStorage;

                if (buildPropertyStorage == null)
                {
                    return false;
                }

                uint itemId;

                var fullPath = (string)item.Properties.Item("FullPath").Value;

                hierarchy.ParseCanonicalName(fullPath, out itemId);

                string excludeFromStyleCopValue;
                buildPropertyStorage.GetItemAttribute(itemId, "ExcludeFromStyleCop", out excludeFromStyleCopValue);

                string excludeFromSourceAnalysisValue;
                buildPropertyStorage.GetItemAttribute(itemId, "ExcludeFromSourceAnalysis", out excludeFromSourceAnalysisValue);

                bool excludeFromStyleCop;
                bool.TryParse(excludeFromStyleCopValue, out excludeFromStyleCop);

                bool excludeFromSourceAnalysis;
                bool.TryParse(excludeFromSourceAnalysisValue, out excludeFromSourceAnalysis);

                if (excludeFromStyleCop != newValue)
                {
                    // We are setting as the value was different
                    // If ExcludeFromSourceAnalysis was there set its value too
                    if (excludeFromSourceAnalysisValue != null)
                    {
                        buildPropertyStorage.SetItemAttribute(itemId, "ExcludeFromSourceAnalysis", newValue.ToString());
                    }

                    buildPropertyStorage.SetItemAttribute(itemId, "ExcludeFromStyleCop", newValue.ToString());
                    item.ContainingProject.Save();
                }

                string key = GetKeyForProjectItem(item);

                if (ProjectItemExcluded.ContainsKey(key))
                {
                    ProjectItemExcluded[key] = newValue;
                }
                else
                {
                    ProjectItemExcluded.Add(key, newValue);
                }

                return true;
            }
            catch
            {
                // For some project kinds (and we can't know them all i.e. wixproj) 
                // The project won't load as the item.ContainingProject.Filename is not the fullpath
                // Any exceptions whilst attempting this we assume the item is not excluded.
                return false;
            }
        }

        /// <summary>
        /// Checks to see if the project item is excluded from stylecop in the project file.
        /// </summary>
        /// <param name="item">The ProjectItem to check.</param>
        /// <returns>True if the item is excluded otherwise False.</returns>
        [SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResult", Justification = "Using the default value from bool.TryParse")]
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Cannot allow exception from plug-in to kill VS or build")]
        private static bool IsProjectItemExcluded(ProjectItem item)
        {
            try
            {
                string key = GetKeyForProjectItem(item);

                string uniqueName = item.ContainingProject.UniqueName;

                var solution = (IVsSolution)Package.GetGlobalService(typeof(SVsSolution));

                IVsHierarchy hierarchy;

                solution.GetProjectOfUniqueName(uniqueName, out hierarchy);

                var buildPropertyStorage = hierarchy as IVsBuildPropertyStorage;

                if (buildPropertyStorage == null)
                {
                    return false;
                }

                uint itemId;

                var fullPath = (string)item.Properties.Item("FullPath").Value;

                hierarchy.ParseCanonicalName(fullPath, out itemId);

                string excludeFromStyleCopValue;
                buildPropertyStorage.GetItemAttribute(itemId, "ExcludeFromStyleCop", out excludeFromStyleCopValue);

                string excludeFromSourceAnalysisValue;
                buildPropertyStorage.GetItemAttribute(itemId, "ExcludeFromSourceAnalysis", out excludeFromSourceAnalysisValue);

                bool excludeFromStyleCop;
                bool.TryParse(excludeFromStyleCopValue, out excludeFromStyleCop);

                bool excludeFromSourceAnalysis;
                bool.TryParse(excludeFromSourceAnalysisValue, out excludeFromSourceAnalysis);

                bool excluded = excludeFromStyleCop || excludeFromSourceAnalysis;

                ProjectItemExcluded.Add(key, excluded);

                return excludeFromStyleCop;
            }
            catch
            {
                // For some project kinds (and we can't know them all i.e. wixproj) 
                // The project won't load as the item.ContainingProject.Filename is not the fullpath
                // Any exceptions whilst attempting this we assume the item is not excluded.
                return false;
            }
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
                                // Only add the item if the build action is set to compile (0 = None, 1 = Compile etc)
                                if (CheckProjectItemBuildAction(item))
                                {
                                    string filePath = GetProjectItemPath(item);
                                    if (!string.IsNullOrEmpty(filePath))
                                    {
                                        if (CheckProjectItemIsIncluded(item))
                                        {
                                            object callbackResult = projectItemCallback(item, filePath, AnalysisType.Project, ref projectContext, ref fileContext);
                                            if (callbackResult != null)
                                            {
                                                return callbackResult;
                                            }
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
            catch (NotImplementedException)
            {
                // item.SubProject throws this for Installshield projects
            }

            return null;
        }

        private static string GetKeyForProjectItem(ProjectItem projectItem)
        {
            string filename = GetProjectItemPath(projectItem);
            var trimmedPath = filename.Substring(Path.GetDirectoryName(projectItem.ContainingProject.FullName).Length + 1).ToUpperInvariant();
            return projectItem.ContainingProject.FileName + ":" + trimmedPath;
        }

        /// <summary>
        /// Checks to see if this Project Item is included in the analysis.
        /// </summary>
        /// <param name="item">The project item to check.</param>
        /// <returns>True if the item is included in the analysis otherwise False.</returns>
        private static bool CheckProjectItemIsIncluded(ProjectItem item)
        {
            Param.AssertNotNull(item, "item");

            try
            {
                var isLinkProperty = item.Properties.Item("IsLink");

                if (isLinkProperty != null && bool.Parse(isLinkProperty.Value.ToString()))
                {
                    // The ProjectItem is a linked file to we'll assume these haven't got
                    // ExcludeFromStyleCop in the proj file
                    return true;
                }

                var key = GetKeyForProjectItem(item);
                return !(ProjectItemExcluded.ContainsKey(key) ? ProjectItemExcluded[key] : IsProjectItemExcluded(item));
            }
            catch (ArgumentException)
            {
                // Thrown if item doesn't have an IsLink property.
                return true;
            }
        }

        /// <summary>
        /// Checks the project item to ensure that the BuildAction is set to Compile (1).
        /// </summary>
        /// <param name="item">The ProjectItem to check.</param>
        /// <returns>Returns True if the BuildAction is set to Compile otherwise False.</returns>
        private static bool CheckProjectItemBuildAction(ProjectItem item)
        {
            Param.AssertNotNull(item, "item");

            try
            {
                // Analyze cs file for ASP V5
                if (item.Kind == Constants.vsProjectItemKindPhysicalFile && item.ContainingProject.Kind == "{8BB2217D-0F2D-49D1-97BC-3654ED321F3B}")
                {
                    return true;
                }
                 
                Property buildAction = item.Properties.Item("BuildAction");
                if (buildAction == null)
                {
                    return false;
                }

                // True if BuildAction == 1 (Compile)
                return (int)buildAction.Value == 1;
            }
            catch (NotImplementedException)
            {
                // Thrown by Installshield projects (and maybe others)
                return false;
            }
            catch (TargetInvocationException)
            {
                // Thrown by CRM 2011 Developer Toolkit (and maybe others)
                return false;
            }
            catch (COMException)
            {
                return false;
            }
            catch (InvalidCastException)
            {
                // Don't think this will ever happen, but this is here for robustness.
                return false;
            }
            catch (ArgumentException)
            {
                // Thrown if the BuildAction property doesn't exist.
                // This is primarily for Web projects where the aspx.cs files do not have a BuildAction
                // but we still want to analyze them.
                return true;
            }
        }

        /// <summary>
        /// Determines whether the project kind has the property missing.
        /// </summary>
        /// <param name="project">The project to check.</param>
        /// <param name="propertyName">The name of the property.</param>
        /// <returns>Returns true if the property is missing from the project.</returns>
        private static bool ProjectHasPropertyMissing(Project project, string propertyName)
        {
            Param.AssertNotNull(project, "project");
            Param.AssertValidString(propertyName, "propertyName");

            List<string> missingProperties;

            if (ProjectsMissingProperties.TryGetValue(project.Kind, out missingProperties))
            {
                return missingProperties.Contains(propertyName);
            }

            return false;
        }

        /// <summary>
        /// Registers the given project Kind as having the property missing.
        /// </summary>
        /// <param name="project">The project.</param>
        /// <param name="propertyName">The property to register as missing.</param>
        private static void AddMissingPropertyForProject(Project project, string propertyName)
        {
            Param.AssertNotNull(project, "project");
            Param.AssertNotNull(propertyName, "propertyName");

            List<string> missingProperties;

            if (!ProjectsMissingProperties.TryGetValue(project.Kind, out missingProperties))
            {
                missingProperties = new List<string>(1);
                ProjectsMissingProperties.Add(project.Kind, missingProperties);
            }

            Debug.Assert(missingProperties != null, "Properties list should always be set here");

            if (!missingProperties.Contains(propertyName))
            {
                missingProperties.Add(propertyName);
            }
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
            var codeProjects = (List<CodeProject>)projectContext;

            // Create a new CodeProject for this project.          
            var codeProject = new CodeProject(projectKey, path, GetProjectConfiguration(project), TargetFrameworkVersion(project));

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
        /// <param name="analysisType">The type of analysis being completed.</param>
        /// <param name="projectContext">The project context.</param>
        /// <param name="fileContext">The file context.</param>
        /// <returns>Returns a non-null value if the item is a known file type, or null otherwise.</returns>
        private static object IsKnownFileTypeVisitor(ProjectItem projectItem, string path, AnalysisType analysisType, ref object projectContext, ref object fileContext)
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
            // Return null to indicate that this is not a known project type and that the walker should continue searching.
            return IsKnownProjectType(project, helper) ? (object)true : null;
        }

        /// <summary>
        /// Determines whether the project is a known project type.
        /// </summary>
        /// <param name="project">The project to add.</param>
        /// <param name="helper">The Analysis helper.</param>
        /// <returns>Returns True if its a known file type, or False otherwise.</returns>
        private static bool IsKnownProjectType(Project project, AnalysisHelper helper)
        {
            Param.AssertNotNull(project, "project");
            Param.AssertNotNull(helper, "helper");

            // If this project type exists in the list of known project types, then return true to indicate
            // that this is a known project type.
            if (helper.ProjectTypes != null)
            {
                Dictionary<string, string> properties;
                if (helper.ProjectTypes.TryGetValue(project.Kind, out properties))
                {
                    return true;
                }
            }

            return false;
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
                        if (EnumerateProjectItem(selectedItem.ProjectItem, selectedItem.ProjectItem.ContainingProject.Name, null, IsKnownFileTypeVisitor, helper, null)
                            != null)
                        {
                            return true;
                        }
                    }
                    else if (selectedItem.Project != null)
                    {
                        if (EnumerateProject(selectedItem.Project, null, IsKnownFileTypeVisitor, helper, null) != null)
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
        /// <param name="analysisType">The type of analysis being completed.</param>
        /// /// <param name="projectContext">The project context.</param>
        /// <param name="fileContext">Must contain the code project.</param>
        /// <returns>Always returns null so that enumeration will continue.</returns>
        private static object AddFileToProject(ProjectItem projectItem, string path, AnalysisType analysisType, ref object projectContext, ref object fileContext)
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

                if (analysisType == AnalysisType.File)
                {
                    var allFilesForProjectItem = GetAllFilesForProjectItem(projectItem);

                    foreach (var filepath in allFilesForProjectItem)
                    {
                        package.Core.Environment.AddSourceCode(codeProject, filepath, null);
                    }
                }
                else
                {
                    package.Core.Environment.AddSourceCode(codeProject, path, null);
                }
            }

            return null;
        }

        /// <summary>
        /// Gets the path to the given project item.
        /// </summary>
        /// <param name="projectItem">The project item.</param>
        /// <returns>Returns the path to the project item or null.</returns>
        private static string GetProjectItemPath(ProjectItem projectItem)
        {
            Param.AssertNotNull(projectItem, "projectItem");

            try
            {
                if (projectItem.Properties == null)
                {
                    return null;
                }

                Property property = projectItem.Properties.Item("FullPath");
                if (property == null)
                {
                    return null;
                }

                return property.Value.ToString();
            }
            catch (ArgumentException)
            {
                // For certain project item types, this throws an argument exception.
            }
            catch (COMException)
            {
                // For certain project types, this throws a COM Exception.
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
        /// Clear the static caches. Used in reaction to events which invalidate the old caches.
        /// </summary>
        private static void ClearCaches()
        {
            ProjectEnabledCache.Clear();
            ProjectItemExcluded.Clear();
            ProjectsMissingProperties.Clear();
        }

        /// <summary>
        /// The ProjectItemsEventClass ItemAdded event handler.
        /// </summary>
        /// <param name="projectItem">The item added.</param>
        private static void ProjectItemsEventsClassItemAdded(ProjectItem projectItem)
        {
            Param.AssertNotNull(projectItem, "projectItem");
            ClearCaches();
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
            ClearCaches();
        }

        /// <summary>
        /// The ProjectItemsEventClass ItemRemoved event handler.
        /// </summary>
        /// <param name="projectItem">The item removed.</param>
        private static void ProjectItemsEventsClassItemRemoved(ProjectItem projectItem)
        {
            Param.AssertNotNull(projectItem, "projectItem");
            ClearCaches();
        }

        /// <summary>
        /// The SolutionEventsProjectRenamed handler.
        /// </summary>
        /// <param name="project">The project that was renamed.</param>
        /// <param name="oldName">The old name.</param>
        private static void SolutionEventsProjectRenamed(Project project, string oldName)
        {
            ClearCaches();
        }

        /// <summary>
        /// The SolutionEventsProjectRemoved handler.
        /// </summary>
        /// <param name="project">The project that was removed.</param>
        private static void SolutionEventsProjectRemoved(Project project)
        {
            ClearCaches();
        }

        /// <summary>
        /// The SolutionEventsProjectAdded handler.
        /// </summary>
        /// <param name="project">The project that was added.</param>
        private static void SolutionEventsProjectAdded(Project project)
        {
            ClearCaches();
        }

        private static void SetBuildIntegrationInProject(Microsoft.Build.Evaluation.Project project, bool enable)
        {
            Param.AssertNotNull(project, "project");
            Param.AssertNotNull(enable, "enable");

            bool isStyleCopImported = project.Imports
                .Any(p => p.ImportedProject.FullPath.IndexOf(
                    StyleCopTargetsName, StringComparison.OrdinalIgnoreCase) != -1);
            if (enable && !isStyleCopImported)
            {
                project.Xml.AddImport(StyleCopTargetsFullName);
            }
            else if (!enable && isStyleCopImported)
            {
                var styleCopImports = project.Imports
                    .Where(p => p.ImportedProject.FullPath.IndexOf(
                        StyleCopTargetsName, StringComparison.OrdinalIgnoreCase) != -1);
                foreach (var styleCopImport in styleCopImports)
                {
                    project.Xml.RemoveChild(styleCopImport.ImportingElement);
                }
            }
        }

        private static void SetTreatLevel(Microsoft.Build.Evaluation.Project project, BuildIntegration buildIntegration)
        {
            Param.AssertNotNull(project, "project");
            Param.AssertNotNull(buildIntegration, "enable");

            switch (buildIntegration)
            {
                case BuildIntegration.None:
                    break;
                case BuildIntegration.TreatErrorAsWarning:
                    project.SetProperty(StyleCopTreatErrorsAsWarnings, true.ToString());
                    break;
                case BuildIntegration.TreatErrorAsError:
                    project.SetProperty(StyleCopTreatErrorsAsWarnings, false.ToString());
                    break;
                default:
                    throw new ArgumentOutOfRangeException("buildIntegration");
            }
        }

        #endregion Private Static Methods
    }
}