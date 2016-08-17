// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StyleCopSettings.cs" company="http://stylecop.codeplex.com">
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
//   The style cop settings.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace StyleCop.ReSharper.Core
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    using JetBrains.Application.FileSystemTracker;
    using JetBrains.Application.Settings;
    using JetBrains.DataFlow;
    using JetBrains.ProjectModel;
    using JetBrains.ReSharper.Psi;
    using JetBrains.Util;

    using StyleCop.Diagnostics;
    using StyleCop.ReSharper.Extensions;
    using StyleCop.ReSharper.Options;

    /// <summary>
    /// The style cop settings.
    /// </summary>
    public class StyleCopSettings
    {
        private const string CsParserId = "StyleCop.CSharp.CsParser";

        private readonly Dictionary<string, bool> boolCache = new Dictionary<string, bool>();

        private readonly Dictionary<string, Settings> settingsCache = new Dictionary<string, Settings>();

        private readonly Dictionary<string, string> settingsFilePathForProjectFile = new Dictionary<string, string>();

        private readonly Lifetime lifetime;

        private readonly StyleCopCore styleCopCore;

        private readonly IFileSystemTracker fileSystemTracker;

        /// <summary>
        /// Initializes a new instance of the <see cref="StyleCopSettings"/> class.
        /// </summary>
        /// <param name="lifetime">
        /// The lifetime of the settings object.
        /// </param>
        /// <param name="styleCopCore">
        /// The style cop core.
        /// </param>
        /// <param name="fileSystemTracker">
        /// The file system tracker.
        /// </param>
        public StyleCopSettings(Lifetime lifetime, StyleCopCore styleCopCore, IFileSystemTracker fileSystemTracker)
        {
            this.lifetime = lifetime;
            this.styleCopCore = styleCopCore;
            this.fileSystemTracker = fileSystemTracker;
        }

        /// <summary>
        /// Gets the settings for the file provided.
        /// </summary>
        /// <param name="projectFile">
        /// The project file to get the Settings for.
        /// </param>
        /// <returns>
        /// Null if it couldn't find one.
        /// </returns>
        public Settings GetSettings(IProjectFile projectFile)
        {
            StyleCopTrace.In(projectFile);

            string settingsFile = this.FindSettingsFilePath(projectFile);

            Settings settings = this.GetMergedSettings(settingsFile);

            if (settings == null)
            {
                string defaultSettingsPath = this.styleCopCore.Environment.GetDefaultSettingsPath();
                return string.IsNullOrEmpty(defaultSettingsPath) ? null : this.styleCopCore.Environment.GetSettings(defaultSettingsPath, true);
            }

            return StyleCopTrace.Out(this.styleCopCore.Environment.GetSettings(settingsFile, true));
        }

        /// <summary>
        /// The load settings files.
        /// </summary>
        /// <param name="projects">
        /// The projects.
        /// </param>
        /// <param name="projectFile">
        /// The source file that is being inspected
        /// </param>
        public void LoadSettingsFiles(IEnumerable<CodeProject> projects, IProjectFile projectFile)
        {
            StyleCopTrace.In(projects, projectFile);

            string settingsPath = this.FindSettingsFilePath(projectFile);

            Settings mergedSettings = this.GetMergedSettings(settingsPath);

            foreach (CodeProject project in projects)
            {
                Settings projectSettings = mergedSettings ?? this.styleCopCore.Environment.GetProjectSettings(project, true);

                if (projectSettings != null)
                {
                    project.Settings = projectSettings;
                    project.SettingsLoaded = true;
                }
            }

            StyleCopTrace.Out();
        }

        /// <summary>
        /// The skip analysis for document.
        /// </summary>
        /// <param name="projectFile">
        /// The project file.
        /// </param>
        /// <returns>
        /// True if analysis should be skipped.
        /// </returns>
        public bool SkipAnalysisForDocument(IProjectFile projectFile)
        {
            StyleCopTrace.In(projectFile);

            string cacheKey = string.Format("{0}::{1}", "SkipAnalysisForDocument", projectFile.Location.FullPath.ToLowerInvariant());

            bool result;

            if (this.boolCache.TryGetValue(cacheKey, out result))
            {
                StyleCopTrace.Out();
                return result;
            }

            if (projectFile.Name.EndsWith(".cs"))
            {
                IContextBoundSettingsStore settingsStore = projectFile.ToSourceFile().GetSettingsStore();
                if (!settingsStore.GetValue((StyleCopOptionsSettingsKey key) => key.UseExcludeFromStyleCopSetting) || !projectFile.ProjectFileIsExcludedFromStyleCop())
                {
                    bool analyzeDesignerFiles = true;
                    bool analyzeGeneratedFiles = false;

                    BooleanProperty analyzeDesignerFilesSetting = this.GetParserSetting(projectFile, "AnalyzeDesignerFiles") as BooleanProperty;

                    if (analyzeDesignerFilesSetting != null)
                    {
                        analyzeDesignerFiles = analyzeDesignerFilesSetting.Value;
                    }

                    if (analyzeDesignerFiles || !projectFile.Name.EndsWith(".Designer.cs", StringComparison.OrdinalIgnoreCase))
                    {
                        BooleanProperty analyzeGeneratedFilesSetting = this.GetParserSetting(projectFile, "AnalyzeGeneratedFiles") as BooleanProperty;

                        if (analyzeGeneratedFilesSetting != null)
                        {
                            analyzeGeneratedFiles = analyzeGeneratedFilesSetting.Value;
                        }

                        if (analyzeGeneratedFiles
                            || (!projectFile.Name.EndsWith(".g.cs", StringComparison.OrdinalIgnoreCase)
                                && !projectFile.Name.EndsWith(".generated.cs", StringComparison.OrdinalIgnoreCase)))
                        {
                            this.boolCache[cacheKey] = false;

                            StyleCopTrace.Out();

                            return false;
                        }
                    }
                }
            }

            this.boolCache[cacheKey] = true;

            StyleCopTrace.Out();

            return true;
        }

        /// <summary>
        /// Gets the settings file if it exists in this directory.
        /// </summary>
        /// <param name="directory">
        /// The directory.
        /// </param>
        /// <returns>
        /// The FileInfo for the settings file if one exists in this directory.
        /// </returns>
        private static FileInfo GetSettingsFileForDirectoryInfo(DirectoryInfo directory)
        {
            StyleCopTrace.In();

            string[] settingsFileNames = new[] { "Settings.StyleCop", "Settings.SourceAnalysis" };

            foreach (string settingsFileName in settingsFileNames)
            {
                FileInfo[] foundSettingsFiles = directory.GetFiles(settingsFileName, SearchOption.TopDirectoryOnly);

                if (foundSettingsFiles.Length > 0)
                {
                    return StyleCopTrace.Out(foundSettingsFiles[0]);
                }
            }

            StyleCopTrace.Out();

            return null;
        }

        /// <summary>
        /// Adds a FileSystemWatcher for the settings.stylecop file in the folder of the file provided.
        /// </summary>
        /// <param name="path">
        /// A path to a file that we will watch the folder of.
        /// </param>
        private void AddWatcherForSettingsFile(string path)
        {
            StyleCopTrace.In(path);
            if (string.IsNullOrEmpty(path))
            {
                StyleCopTrace.Out();
                return;
            }

            this.fileSystemTracker.AdviseFileChanges(
                this.lifetime,
                FileSystemPath.Parse(path),
                _ =>
                    {
                        this.settingsFilePathForProjectFile.Clear();
                        this.settingsCache.Clear();
                    });

            StyleCopTrace.Out();
        }

        /// <summary>
        /// Searches this directory and the parents thereof to see 
        /// if a Settings file exists.
        /// </summary>
        /// <param name="directoryInfo">
        /// The directory.
        /// </param>
        /// <returns>
        /// The FileInfo for the settings file.
        /// </returns>
        private FileInfo FindSettingsFile(DirectoryInfo directoryInfo)
        {
            StyleCopTrace.In();

            FileInfo settingsFilePath = GetSettingsFileForDirectoryInfo(directoryInfo);

            if (settingsFilePath == null && directoryInfo.Parent != null)
            {
                settingsFilePath = this.FindSettingsFile(directoryInfo.Parent);
            }

            return StyleCopTrace.Out(settingsFilePath);
        }

        /// <summary>
        /// Searches directories of the project items project file and the parents thereof to see 
        /// if a Settings file exists.
        /// </summary>
        /// <param name="projectItem">
        /// File being examined.
        /// </param>
        /// <returns>
        /// Path to the settings file.
        /// </returns>
        private string FindSettingsFilePath(IProjectItem projectItem)
        {
            StyleCopTrace.In(projectItem);

            string cacheKey = projectItem.Location.FullPath.ToLowerInvariant();

            string settings;

            if (this.settingsFilePathForProjectFile.TryGetValue(cacheKey, out settings))
            {
                StyleCopTrace.Out();

                return settings;
            }

            IProject projectFile = projectItem.GetProject();

            string result = this.FindSettingsFilePath(projectFile);

            // TODO: This makes no sense
            // We cache, per source file location, the location of the settings.stylecop file.
            // We only look for the settings.stylecop file at the project root folder and above.
            // But we add a file watcher at the source file location
            // this.AddWatcherForSettingsFile(projectItem.Location.FullPath);
            this.settingsFilePathForProjectFile[cacheKey] = result;

            return StyleCopTrace.Out(result);
        }

        /// <summary>
        /// Searches directories of the project file and the parents thereof to see 
        /// if a Settings file exists.
        /// </summary>
        /// <param name="project">
        /// The project file.
        /// </param>
        /// <returns>
        /// Path to the settings file.
        /// </returns>
        private string FindSettingsFilePath(IProject project)
        {
            StyleCopTrace.In(project);

            if (project != null)
            {
                FileSystemPath directory = project.Location;

                if (directory.ExistsDirectory)
                {
                    FileInfo settingsFile = this.FindSettingsFile(new DirectoryInfo(directory.FullPath));

                    if (settingsFile != null)
                    {
                        return StyleCopTrace.Out(settingsFile.FullName);
                    }
                }
            }

            StyleCopTrace.Out();

            return null;
        }

        private Settings GetMergedSettings(string settingsPath)
        {
            StyleCopTrace.In(settingsPath);

            string cacheKey = string.Empty;

            if (string.IsNullOrEmpty(settingsPath))
            {
                cacheKey = string.Format("{0}::EMPTY", "GetMergedSettings");
            }
            else
            {
                cacheKey = string.Format("{0}::{1}", "GetMergedSettings", settingsPath.ToLowerInvariant());
            }

            Settings mergedSettings = null;

            if (this.settingsCache.TryGetValue(cacheKey, out mergedSettings))
            {
                StyleCopTrace.Out();

                return mergedSettings;
            }

            Settings localSettings = this.styleCopCore.Environment.GetSettings(settingsPath, false);

            if (localSettings != null)
            {
                SettingsMerger merger = new SettingsMerger(localSettings, this.styleCopCore.Environment);

                mergedSettings = merger.MergedSettings;
            }

            this.settingsCache[cacheKey] = mergedSettings;

            // TODO: This doesn't invalidate the cache if any of the other files change
            this.AddWatcherForSettingsFile(settingsPath);

            return StyleCopTrace.Out(mergedSettings);
        }

        private PropertyValue GetParserSetting(IProjectFile projectFile, string propertyName)
        {
            StyleCopTrace.In(projectFile, propertyName);
            PropertyValue returnValue = null;

            SourceParser addIn = this.styleCopCore.GetParser(CsParserId);

            if (addIn != null)
            {
                string settingsFile = this.FindSettingsFilePath(projectFile);

                if (!string.IsNullOrEmpty(settingsFile))
                {
                    Settings settings = this.styleCopCore.Environment.GetSettings(settingsFile, true);

                    if (settings != null)
                    {
                        returnValue = addIn.GetSetting(settings, propertyName);
                    }
                }
            }

            return StyleCopTrace.Out(returnValue);
        }
    }
}