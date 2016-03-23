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

namespace StyleCop.ReSharper.Options
{
    using System.Reflection;

    using JetBrains.Application.Settings;
    using JetBrains.Util;

    /// <summary>
    /// Class to hold all of the Configurable options for this addin.
    /// </summary>
    [SettingsKey(typeof(Missing), "StyleCop Options")]
    public class StyleCopOptionsSettingsKey
    {
        /// <summary>
        /// Gets or sets a value indicating whether the analysis executes as you type.
        /// </summary>
        [SettingsEntry(true, "Analysis Enabled")]
        public bool AnalysisEnabled { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to analyze read only files.
        /// </summary>
        [SettingsEntry(false, "analyze read only files")]
        public bool AnalyzeReadOnlyFiles { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether declaration comments should be multi line or single line.
        /// </summary>
        [SettingsEntry(true, "Check R# Code Style Options At StartUp")]
        public bool CheckReSharperCodeStyleOptionsAtStartUp { get; set; }

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
        /// Gets or sets a value indicating whether to insert TODO into created documentation text.
        /// </summary>
        [SettingsEntry(false, "Insert TODO into new documentation text")]
        public bool InsertToDoText { get; set; }

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
        /// Gets or sets a value indicating whether StyleCop plugins are enabled
        /// </summary>
        [SettingsEntry(false, "Enable StyleCop plugins")]
        public bool PluginsEnabled { get; set; }

        /// <summary>
        /// Gets or sets a value indicating the location to search for StyleCop plugins
        /// </summary>
        [SettingsEntry("", "StyleCop plugin search location")]
        public string PluginsPath { get; set; }
    }
}