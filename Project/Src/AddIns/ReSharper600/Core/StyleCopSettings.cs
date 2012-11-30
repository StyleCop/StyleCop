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
extern alias JB;

namespace StyleCop.ReSharper600.Core
{
    #region Using Directives

    using System;
    using System.Collections.Generic;
    using System.IO;

    using JetBrains.ProjectModel;

    using StyleCop.Diagnostics;
    using StyleCop.ReSharper600.Options;

    #endregion

    /// <summary>
    /// The style cop settings.
    /// </summary>
    public class StyleCopSettings
    {
        #region Constants

        private const string CsParserId = "StyleCop.CSharp.CsParser";

        #endregion

        #region Static Fields

        private static readonly Dictionary<string, bool> BoolCache = new Dictionary<string, bool>();

        private static readonly Dictionary<string, Settings> SettingsCache = new Dictionary<string, Settings>();

        private static readonly Dictionary<string, string> StringCache = new Dictionary<string, string>();

        #endregion

        #region Fields

        private readonly StyleCopCore styleCopCore;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="StyleCopSettings"/> class.
        /// </summary>
        /// <param name="styleCopCore">
        /// The style cop core.
        /// </param>
        public StyleCopSettings(StyleCopCore styleCopCore)
        {
            this.styleCopCore = styleCopCore;
        }

        #endregion

        #region Public Methods and Operators

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
        public string FindSettingsFilePath(IProjectItem projectItem)
        {
            StyleCopTrace.In(projectItem);

            string cacheKey = string.Format("{0}::{1}", "FindSettingsFilePath", projectItem.Location.FullPath.ToLowerInvariant());

            string settings;

            if (StringCache.TryGetValue(cacheKey, out settings))
            {
                StyleCopTrace.Out();

                return settings;
            }

            IProject projectFile = projectItem.GetProject();

            string result = this.FindSettingsFilePath(projectFile);

            StringCache[cacheKey] = result;

            return StyleCopTrace.Out(result);
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

            if (string.IsNullOrEmpty(settingsFile))
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
        /// <param name="settingsPath">
        /// The settings path.
        /// </param>
        public void LoadSettingsFiles(IEnumerable<CodeProject> projects, string settingsPath)
        {
            StyleCopTrace.In(projects, settingsPath);

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

            if (BoolCache.TryGetValue(cacheKey, out result))
            {
                StyleCopTrace.Out();
                return result;
            }

            if (projectFile.Name.EndsWith(".cs"))
            {
                if (!StyleCopOptions.Instance.UseExcludeFromStyleCopSetting || !projectFile.ProjectFileIsExcludedFromStyleCop())
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
                            BoolCache[cacheKey] = false;

                            StyleCopTrace.Out();

                            return false;
                        }
                    }
                }
            }

            BoolCache[cacheKey] = true;

            StyleCopTrace.Out();

            return true;
        }

        #endregion

        #region Methods

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
                JB::JetBrains.Util.FileSystemPath directory = project.Location;

                if (directory.ExistsDirectory)
                {
                    FileInfo settingsFile = this.FindSettingsFile(directory.ToDirectoryInfo());

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

            if (SettingsCache.TryGetValue(cacheKey, out mergedSettings))
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

            SettingsCache[cacheKey] = mergedSettings;

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

        #endregion
    }
}