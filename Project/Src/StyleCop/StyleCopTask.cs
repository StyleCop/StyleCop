// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StyleCopTask.cs" company="https://github.com/StyleCop">
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
//   MSBuild task that exposes StyleCop to MSBuild-based projects.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    using Microsoft.Build.Framework;
    using Microsoft.Build.Utilities;

    using StyleCop.Diagnostics;

    /// <summary>
    /// MSBuild task that exposes StyleCop to MSBuild-based projects.
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "StyleCop", Justification = "This is the correct casing.")]
    public sealed class StyleCopTask : Task
    {
        #region Constants

        /// <summary>
        /// Allow 10000 violations by default.
        /// </summary>
        private const int DefaultViolationLimit = 10000;

        /// <summary>
        /// Error code used when logging errors/warnings to MSBuild.
        /// </summary>
        private const string MSBuildErrorCode = null;

        /// <summary>
        /// SubCategory used when logging errors/warnings to MSBuild.
        /// </summary>
        private const string MSBuildSubCategory = null;

        #endregion

        #region Fields

        /// <summary>
        /// MSBuild input - see corresponding public property for details.
        /// </summary>
        private ITaskItem[] inputAdditionalAddinPaths = new ITaskItem[0];

        /// <summary>
        /// MSBuild input - see corresponding public property for details.
        /// </summary>
        private bool inputCacheResults;

        /// <summary>
        /// MSBuild input - see corresponding public property for details.
        /// </summary>
        private string[] inputDefineConstants = new string[0];

        /// <summary>
        /// MSBuild input - see corresponding public property for details.
        /// </summary>
        private bool inputForceFullAnalysis;

        /// <summary>
        /// MSBuild input - see corresponding public property for details.
        /// </summary>
        private ITaskItem inputOverrideSettingsFile;

        /// <summary>
        /// MSBuild input - see corresponding public property for details.
        /// </summary>
        private ITaskItem inputProjectFullPath;

        /// <summary>
        /// MSBuild input - see corresponding public property for details.
        /// </summary>
        private ITaskItem[] inputSourceFiles = new ITaskItem[0];

        /// <summary>
        /// MSBuild input - see corresponding public property for details.
        /// </summary>
        private bool inputTreatErrorsAsWarnings;

        /// <summary>
        /// MSBuild input - see corresponding public property for details.
        /// </summary>
        private ITaskItem maxViolationCount;

        /// <summary>
        /// MSBuild input - see corresponding public property for details.
        /// </summary>
        private ITaskItem outputFile;

        /// <summary>
        /// Keeps track of whether we encountered any errors (not warnings).
        /// </summary>
        private bool succeeded = true;

        /// <summary>
        /// The number of violations seen.
        /// </summary>
        private int violationCount;

        /// <summary>
        /// The number of violations to allow.
        /// </summary>
        private int violationLimit;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the array of folders to search for addin modules.
        /// </summary>
        /// <remarks>This value is set by MSBuild.</remarks>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Addin", 
            Justification = "API has already been published and should not be changed.")]
        public ITaskItem[] AdditionalAddinPaths
        {
            get
            {
                return this.inputAdditionalAddinPaths;
            }

            set
            {
                Param.Ignore(value);
                this.inputAdditionalAddinPaths = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether StyleCop should write cache files to disk after
        /// performing an analysis.
        /// </summary>
        /// <remarks>This value is set by MSBuild.</remarks>
        public bool CacheResults
        {
            get
            {
                return this.inputCacheResults;
            }

            set
            {
                Param.Ignore(value);
                this.inputCacheResults = value;
            }
        }

        /// <summary>
        /// Gets or sets the constants defined in the project.
        /// </summary>
        /// <remarks>This value is set by MSBuild.</remarks>
        public string[] DefineConstants
        {
            get
            {
                return this.inputDefineConstants;
            }

            set
            {
                Param.Ignore(value);
                this.inputDefineConstants = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether StyleCop should ignore cached results and 
        /// perform a clean analysis.
        /// </summary>
        /// <remarks>This value is set by MSBuild.</remarks>
        public bool ForceFullAnalysis
        {
            get
            {
                return this.inputForceFullAnalysis;
            }

            set
            {
                Param.Ignore(value);
                this.inputForceFullAnalysis = value;
            }
        }

        /// <summary>
        /// Gets or sets the maximum number of violations allowed from the project until analysis will quit.
        /// </summary>
        public ITaskItem MaxViolationCount
        {
            get
            {
                return this.maxViolationCount;
            }

            set
            {
                Param.Ignore(value);
                this.maxViolationCount = value;
            }
        }

        /// <summary>
        /// Gets or sets a value specifying the name of the file for outputting the violations.
        /// </summary>
        public ITaskItem OutputFile
        {
            get
            {
                return this.outputFile;
            }

            set
            {
                Param.RequireNotNull(value, "OutputFile");
                this.outputFile = value;
            }
        }

        /// <summary>
        /// Gets or sets a file containing the settings that are specific to this project. Settings that are present in
        /// the OverrideSettingsFile will override settings that are present in the SharedSettingsFile.
        /// </summary>
        /// <remarks>This value is set by MSBuild. This file will be ignored if it is null or cannot be opened.</remarks>
        public ITaskItem OverrideSettingsFile
        {
            get
            {
                return this.inputOverrideSettingsFile;
            }

            set
            {
                Param.Ignore(value);
                this.inputOverrideSettingsFile = value;
            }
        }

        /// <summary>
        /// Gets or sets the complete path to the project file.
        /// </summary>
        /// <remarks>This value is set by MSBuild.</remarks>
        public ITaskItem ProjectFullPath
        {
            get
            {
                return this.inputProjectFullPath;
            }

            set
            {
                Param.RequireNotNull(value, "ProjectFullPath");
                this.inputProjectFullPath = value;
            }
        }

        /// <summary>
        /// Gets or sets the files to analyze.
        /// </summary>
        /// <remarks>This value is set by MSBuild.</remarks>
        public ITaskItem[] SourceFiles
        {
            get
            {
                return this.inputSourceFiles;
            }

            set
            {
                Param.RequireNotNull(value, "SourceFiles");
                this.inputSourceFiles = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether StyleCop should log all violations as build warnings.
        /// </summary>
        /// <remarks>This value is set by MSBuild.</remarks>
        public bool TreatErrorsAsWarnings
        {
            get
            {
                return this.inputTreatErrorsAsWarnings;
            }

            set
            {
                Param.Ignore(value);
                this.inputTreatErrorsAsWarnings = value;
            }
        }

        /// <summary>
        /// Gets the number of violations seen.
        /// </summary>
        [Output]
        public int ViolationCount
        {
            get
            {
                return this.violationCount;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Executes this MSBuild task, based on the input values passed in by the MSBuild engine.
        /// </summary>
        /// <returns>Returns true if there were no errors, false otherwise.</returns>
        public override bool Execute()
        {
            StyleCopTrace.In();

            // Clear the violation count and set the violation limit for the project.
            this.violationCount = 0;
            this.violationLimit = 0;

            if (this.maxViolationCount != null)
            {
                if (!int.TryParse(this.maxViolationCount.ItemSpec, out this.violationLimit))
                {
                    this.violationLimit = 0;
                }
            }

            if (this.violationLimit == 0)
            {
                this.violationLimit = DefaultViolationLimit;
            }

            // Get settings files (if null or empty use null filename so it uses right default).
            string overrideSettingsFileName = null;
            if (this.inputOverrideSettingsFile != null && this.inputOverrideSettingsFile.ItemSpec.Length > 0)
            {
                overrideSettingsFileName = this.inputOverrideSettingsFile.ItemSpec;
            }

            // Get addin paths.
            List<string> addinPaths = new List<string>();
            if (this.inputAdditionalAddinPaths != null)
            {
                addinPaths.AddRange(this.inputAdditionalAddinPaths.Select(addinPath => addinPath.GetMetadata("FullPath")));
            }

            // Create the StyleCop console.
            StyleCopConsole console = new StyleCopConsole(
                overrideSettingsFileName, this.inputCacheResults, this.outputFile == null ? null : this.outputFile.ItemSpec, addinPaths, true);

            // Create the configuration.
            Configuration configuration = new Configuration(this.inputDefineConstants);

            string projectFullPath = null;
            if (this.inputProjectFullPath != null)
            {
                projectFullPath = this.inputProjectFullPath.GetMetadata("FullPath");
            }

            if (!string.IsNullOrEmpty(projectFullPath))
            {
                // Create a CodeProject object for these files.
                CodeProject project = new CodeProject(projectFullPath.GetHashCode(), projectFullPath, configuration);

                // Add each source file to this project.
                foreach (ITaskItem inputSourceFile in this.inputSourceFiles)
                {
                    console.Core.Environment.AddSourceCode(project, inputSourceFile.ItemSpec, null);
                }

                try
                {
                    // Subscribe to events
                    console.OutputGenerated += this.OnOutputGenerated;
                    console.ViolationEncountered += this.OnViolationEncountered;

                    // Analyze the source files
                    CodeProject[] projects = new[] { project };
                    console.Start(projects, this.inputForceFullAnalysis);
                }
                finally
                {
                    // Unsubscribe from events
                    console.OutputGenerated -= this.OnOutputGenerated;
                    console.ViolationEncountered -= this.OnViolationEncountered;
                }
            }

            return StyleCopTrace.Out(this.succeeded);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Called when StyleCop outputs messages.
        /// </summary>
        /// <param name="sender">
        /// The event sender.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private void OnOutputGenerated(object sender, OutputEventArgs e)
        {
            Param.Ignore(sender);
            Param.AssertNotNull(e, "e");

            lock (this)
            {
                this.Log.LogMessage(e.Importance, e.Output.Trim());
            }
        }

        /// <summary>
        /// Called when StyleCop encounters a violation.
        /// </summary>
        /// <param name="sender">
        /// The event sender.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private void OnViolationEncountered(object sender, ViolationEventArgs e)
        {
            Param.Ignore(sender);
            Param.AssertNotNull(e, "e");

            if (this.violationLimit < 0 || this.violationCount < this.violationLimit)
            {
                this.violationCount++;

                // Does the violation qualify for breaking the build?
                if (!(e.Warning || this.inputTreatErrorsAsWarnings))
                {
                    this.succeeded = false;
                }

                string path = string.Empty;
                if (e.SourceCode != null && e.SourceCode.Path != null && e.SourceCode.Path.Length > 0)
                {
                    path = e.SourceCode.Path;
                }
                else if (e.Element != null && e.Element.Document != null && e.Element.Document.SourceCode != null && e.Element.Document.SourceCode.Path != null)
                {
                    path = e.Element.Document.SourceCode.Path;
                }

                lock (this)
                {
                    string trimmedNamespace = e.Violation.Rule.Namespace.SubstringAfter("StyleCop.", StringComparison.Ordinal);
                    trimmedNamespace = trimmedNamespace.SubstringBeforeLast("Rules", StringComparison.Ordinal);
                    string description = string.Concat(e.Violation.Rule.CheckId, " : ", trimmedNamespace, " : ", e.Message);

                    if (e.Warning || this.inputTreatErrorsAsWarnings)
                    {
                        if (e.Location == null)
                        {
                            this.Log.LogWarning(MSBuildSubCategory, MSBuildErrorCode, null, path, e.LineNumber, 1, 0, 0, description);
                        }
                        else
                        {
                            this.Log.LogWarning(
                                MSBuildSubCategory, 
                                MSBuildErrorCode, 
                                null, 
                                path,
                                e.Location.Value.StartPoint.LineNumber,
                                e.Location.Value.StartPoint.IndexOnLine,
                                e.Location.Value.EndPoint.LineNumber,
                                e.Location.Value.EndPoint.IndexOnLine, 
                                description);
                        }
                    }
                    else
                    {
                        if (e.Location == null)
                        {
                            this.Log.LogError(MSBuildSubCategory, MSBuildErrorCode, null, path, e.LineNumber, 1, 0, 0, description);
                        }
                        else
                        {
                            this.Log.LogError(
                                MSBuildSubCategory, 
                                MSBuildErrorCode, 
                                null, 
                                path,
                                e.Location.Value.StartPoint.LineNumber,
                                e.Location.Value.StartPoint.IndexOnLine,
                                e.Location.Value.EndPoint.LineNumber,
                                e.Location.Value.EndPoint.IndexOnLine, 
                                description);
                        }
                    }
                }
            }
        }

        #endregion
    }
}