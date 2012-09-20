// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StyleCopOptionsSettingsKey.cs" company="http://stylecop.codeplex.com">
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
//   Class to hold all of the Configurable options for this addin.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

extern alias JB;

namespace StyleCop.ReSharper700.Options
{
    #region Using Directives

    using System.IO;
    using System.Reflection;
    using System.Windows.Forms;

    using JetBrains.Application.Settings;

    using Microsoft.Win32;

    using StyleCop.ReSharper700.Core;

    #endregion

    /// <summary>
    /// Class to hold all of the Configurable options for this addin.
    /// </summary>
    [SettingsKey(typeof(Missing), "StyleCop Options")]
    public class StyleCopOptionsSettingsKey
    {
        #region Constants and Fields

        /// <summary>
        /// Set to true to always check for updates when Visual Studio starts.
        /// </summary>
        private bool alwaysCheckForUpdatesWhenVisualStudioStarts;
        
        /// <summary>
        /// Tracks whether we should check for updates.
        /// </summary>
        private bool automaticallyCheckForUpdates;

        /// <summary>
        /// The number of days between update checks.
        /// </summary>
        private int daysBetweenUpdateChecks;

        /// <summary>
        /// The value of the detected path for StyleCop.
        /// </summary>
        private string styleCopDetectedPath;

        /// <summary>
        /// Set to true when we've attempted to get the StyleCop path.
        /// </summary>
        private bool attemptedToGetStyleCopPath;

        #endregion
        
        #region Properties
        
        /// <summary>
        /// Gets or sets DashesCountInFileHeader.
        /// </summary>
        [SettingsEntry(116, "Dashes Count In File Header")]
        public int DashesCountInFileHeader { get; set; }
        
        /// <summary>
        /// Gets or sets a value indicating whether descriptive text should be inserted into missing documentation headers.
        /// </summary>
        [SettingsEntry(true, "Insert Text Into Documentation")]
        public bool InsertTextIntoDocumentation { get; set; }
        
        /// <summary>
        /// Gets or sets the ParsingPerformance value. 9 means every time R# calls us, 8 means after 1 second, 7 means after 2 seconds, etc.
        /// </summary>
        /// <value>
        /// The performance value.
        /// </value>
        [SettingsEntry(7, "Parsing Performance")]
        public int ParsingPerformance { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the analysis executes as you type.
        /// </summary>
        [SettingsEntry(true, "Analysis Enabled")]
        public bool AnalysisEnabled { get; set; }
        
        /// <summary>
        /// Gets or sets the Specified Assembly Path.
        /// </summary>
        /// <value>
        /// The allow null attribute.
        /// </value>
        [SettingsEntry("", "Specified Assembly Path")]
        public string SpecifiedAssemblyPath { get; set; }

        /// <summary>
        /// Gets or sets the text for inserting suppress message attributes.
        /// </summary>
        [SettingsEntry("Reviewed. Suppression is OK here.", "Suppress StyleCop Attribute Justification Text")]
        public string SuppressStyleCopAttributeJustificationText { get; set; }
        
        /// <summary>
        /// Gets or sets a value indicating whether to use exclude from style cop setting.
        /// </summary>
        [SettingsEntry(true, "Use Exclude From StyleCop Setting")]
        public bool UseExcludeFromStyleCopSetting { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether declaration comments should be multi line or single line.
        /// </summary>
        [SettingsEntry(false, "Use Single Line Declaration Comments")]
        public bool UseSingleLineDeclarationComments { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether declaration comments should be multi line or single line.
        /// </summary>
        [SettingsEntry(true, "Check R# Code Style Options At StartUp")]
        public bool CheckReSharperCodeStyleOptionsAtStartUp { get; set; }
        
        /// <summary>
        /// Gets or sets a value indicating whether to analyze read only files.
        /// </summary>
        [SettingsEntry(false, "analyze read only files")]
        public bool AnalyzeReadOnlyFiles { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to insert TODO into created documentation text.
        /// </summary>
        [SettingsEntry(false, "Insert TODO into new documentation text")]
        public bool InsertToDoText { get; set; }

        #endregion
        
        #region Methods

        /// <summary>
        /// Detects the style cop path.
        /// </summary>
        /// <returns>
        /// The path to the detected StyleCop assembly.
        /// </returns>
        public static string DetectStyleCopPath()
        {
            var assemblyPath = GetStyleCopPath();
            return StyleCopReferenceHelper.LocationValid(assemblyPath) ? assemblyPath : null;
        }

        /// <summary>
        /// Gets the assembly location.
        /// </summary>
        /// <returns>
        /// The path to the StyleCop assembly.
        /// </returns>
        public string GetAssemblyPath()
        {
            if (!this.attemptedToGetStyleCopPath)
            {
                this.attemptedToGetStyleCopPath = true;

                if (!string.IsNullOrEmpty(this.SpecifiedAssemblyPath))
                {
                    if (StyleCopReferenceHelper.LocationValid(this.SpecifiedAssemblyPath))
                    {
                        this.styleCopDetectedPath = this.SpecifiedAssemblyPath;
                        return this.styleCopDetectedPath;
                    }

                    // Location not valid. Blank it and automatically get location
                    this.SpecifiedAssemblyPath = null;
                }

                this.styleCopDetectedPath = DetectStyleCopPath();

                if (string.IsNullOrEmpty(this.styleCopDetectedPath))
                {
                    MessageBox.Show(
                        string.Format("Failed to find the StyleCop Assembly. Please check your StyleCop installation."), "Error Finding StyleCop Assembly", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return this.styleCopDetectedPath;
        }

        /// <summary>
        /// Gets the StyleCop assembly path.
        /// </summary>
        /// <returns>
        /// The path to the StyleCop assembly or null if not found.
        /// </returns>
        private static string GetStyleCopPath()
        {
            var directory = StyleCop.Utils.InstallDirFromRegistry() ?? Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            return directory == null ? directory : Path.Combine(directory, Constants.StyleCopAssemblyName);
        }
        
        #endregion
    }
}