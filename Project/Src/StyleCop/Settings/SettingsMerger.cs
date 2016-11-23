// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SettingsMerger.cs" company="https://github.com/StyleCop">
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
//   Merges a settings file with other settings files.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop
{
    using System;
    using System.Diagnostics;
    using System.IO;

    /// <summary>
    /// Merges a settings file with other settings files.
    /// </summary>
    public class SettingsMerger
    {
        #region Constants

        /// <summary>
        /// The name of the linked settings property.
        /// </summary>
        internal const string LinkedSettingsProperty = "LinkedSettingsFile";

        /// <summary>
        /// The name of the merge settings property.
        /// </summary>
        internal const string MergeSettingsFilesProperty = "MergeSettingsFiles";

        /// <summary>
        /// Merge with a linked settings file.
        /// </summary>
        internal const string MergeStyleLinked = "Linked";

        /// <summary>
        /// Do not merge the settings file.
        /// </summary>
        internal const string MergeStyleNone = "NoMerge";

        /// <summary>
        /// Merge with a parent settings file.
        /// </summary>
        internal const string MergeStyleParent = "Parent";

        #endregion

        #region Fields

        /// <summary>
        /// The environment in which StyleCop is running.
        /// </summary>
        private readonly StyleCopEnvironment environment;

        /// <summary>
        /// The settings which should be merged.
        /// </summary>
        private readonly Settings localSettings;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the SettingsMerger class.
        /// </summary>
        /// <param name="localSettings">
        /// The settings which should be merged.
        /// </param>
        /// <param name="environment">
        /// The environment in which StyleCop is running.
        /// </param>
        public SettingsMerger(Settings localSettings, StyleCopEnvironment environment)
        {
            Param.RequireNotNull(localSettings, "localSettings");
            Param.RequireNotNull(environment, "environment");

            this.localSettings = localSettings;
            this.environment = environment;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the local settings merged with parent settings.
        /// </summary>
        public Settings MergedSettings
        {
            get
            {
                string mergeType = DetermineMergeType(this.localSettings, this.environment);

                Settings mergedSettings = this.localSettings;

                // Perform the necessary type of merge.
                if (string.CompareOrdinal(mergeType, SettingsMerger.MergeStyleLinked) == 0)
                {
                    mergedSettings = this.FindMergedSettingsThroughLinkedSettings(this.localSettings, true);
                }
                else if (string.CompareOrdinal(mergeType, SettingsMerger.MergeStyleNone) != 0)
                {
                    mergedSettings = this.FindMergedSettingsThroughParentPaths(this.localSettings, true);
                }

                // Now that the settings have been merged, determine whether there are any file groups in the settings
                // that need to be merged with the main settings.
                foreach (SourceFileListSettings fileList in this.localSettings.SourceFileLists)
                {
                    if (fileList.Settings == null)
                    {
                        fileList.Settings = mergedSettings;
                    }
                    else
                    {
                        mergeType = DetermineMergeType(fileList.Settings, this.environment);

                        // Perform the necessary type of merge.
                        if (string.CompareOrdinal(mergeType, SettingsMerger.MergeStyleLinked) == 0)
                        {
                            fileList.Settings = this.FindMergedSettingsThroughLinkedSettings(fileList.Settings, true);
                        }
                        else if (string.CompareOrdinal(mergeType, SettingsMerger.MergeStyleNone) != 0)
                        {
                            fileList.Settings = MergeSettings(mergedSettings, fileList.Settings);
                        }
                    }

                    // Finally, add the merged file list to the new merged settings object.
                    if (mergedSettings != this.localSettings)
                    {
                        mergedSettings.AddSourceFileList(fileList);
                    }
                }

                return mergedSettings;
            }
        }

        /// <summary>
        /// Gets the merged parent settings which would be merged with the local settings.
        /// </summary>
        public Settings ParentMergedSettings
        {
            get
            {
                StringProperty mergeTypeProperty = this.localSettings.GlobalSettings.GetProperty(SettingsMerger.MergeSettingsFilesProperty) as StringProperty;

                string mergeType = SettingsMerger.MergeStyleParent;
                if (mergeTypeProperty != null)
                {
                    mergeType = mergeTypeProperty.Value;
                }

                // If the merge style is set to link but the current environment doesn't support linking, change it to parent.
                if (!this.environment.SupportsLinkedSettings && string.CompareOrdinal(mergeType, SettingsMerger.MergeStyleLinked) == 0)
                {
                    mergeType = SettingsMerger.MergeStyleParent;
                }

                if (string.CompareOrdinal(mergeType, SettingsMerger.MergeStyleParent) == 0)
                {
                    return this.FindMergedSettingsThroughParentPaths(this.localSettings, false);
                }
                else if (string.CompareOrdinal(mergeType, SettingsMerger.MergeStyleLinked) == 0)
                {
                    return this.FindMergedSettingsThroughLinkedSettings(this.localSettings, false);
                }

                return null;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Merged two sets of property collections together.
        /// </summary>
        /// <param name="originalPropertyCollection">
        /// The original property collection.
        /// </param>
        /// <param name="overridingPropertyCollection">
        /// The overriding property collection.
        /// </param>
        /// <param name="mergedPropertyCollection">
        /// The merged property collection.
        /// </param>
        internal static void MergePropertyCollections(
            PropertyCollection originalPropertyCollection, PropertyCollection overridingPropertyCollection, PropertyCollection mergedPropertyCollection)
        {
            Param.Ignore(originalPropertyCollection);
            Param.Ignore(overridingPropertyCollection);
            Param.AssertNotNull(mergedPropertyCollection, "mergedPropertyCollection");

            // The merge is based on whether one or both files are present.
            if (originalPropertyCollection == null && overridingPropertyCollection != null)
            {
                // There are no settings in the original settings file, only settings from the overriding file.
                foreach (PropertyValue property in overridingPropertyCollection)
                {
                    mergedPropertyCollection.Add(property.Clone());
                }
            }
            else if (originalPropertyCollection != null && overridingPropertyCollection == null)
            {
                // There are no settings from the overriding settings file, only settings from the original file.
                foreach (PropertyValue property in originalPropertyCollection)
                {
                    // Only take a property from the original collection if the property is supposed to be merged.
                    if (property.PropertyDescriptor.Merge)
                    {
                        mergedPropertyCollection.Add(property.Clone());
                    }
                }
            }
            else if (originalPropertyCollection != null && overridingPropertyCollection != null)
            {
                // There are settings in both settings files. Fist, loop through each property collection 
                // in the original settings file.
                foreach (PropertyValue originalProperty in originalPropertyCollection)
                {
                    if (originalProperty.PropertyDescriptor.Merge)
                    {
                        // Try to find a corresponding property in the overriding settings file.
                        PropertyValue overridingProperty = overridingPropertyCollection[originalProperty.PropertyName];
                        if (overridingProperty == null)
                        {
                            // There is no corresponding overriding property. Just add the original property.
                            mergedPropertyCollection.Add(originalProperty.Clone());
                        }
                        else
                        {
                            // Merge the two property value collections together depending on the property type.
                            switch (originalProperty.PropertyType)
                            {
                                case PropertyType.Int:
                                case PropertyType.String:
                                case PropertyType.Boolean:
                                    mergedPropertyCollection.Add(overridingProperty.Clone());
                                    break;

                                case PropertyType.Collection:
                                    MergeCollectionProperties(mergedPropertyCollection, originalProperty, overridingProperty);
                                    break;

                                default:
                                    Debug.Fail("Unexpected property type.");
                                    break;
                            }
                        }
                    }
                }

                // Now look through each property in the overriding property collection. If there is any 
                // property here which is not contained in the merged collection, just add it directly.
                // This means that it was not present in the original collection.
                foreach (PropertyValue overridingProperty in overridingPropertyCollection)
                {
                    PropertyValue mergedProperty = mergedPropertyCollection[overridingProperty.PropertyName];
                    if (mergedProperty == null)
                    {
                        mergedPropertyCollection.Add(overridingProperty.Clone());
                    }
                }
            }

            mergedPropertyCollection.IsReadOnly = true;
        }

        /// <summary>
        /// Determines the type of merge to perform, based on the local settings file.
        /// </summary>
        /// <param name="settings">
        /// The settings file
        /// </param>
        /// <param name="environment">
        /// The environment.
        /// </param>
        /// <returns>
        /// Returns the merge type.
        /// </returns>
        private static string DetermineMergeType(Settings settings, StyleCopEnvironment environment)
        {
            Param.AssertNotNull(settings, "settings");
            Param.Ignore(environment);

            StringProperty mergeTypeProperty = settings.GlobalSettings.GetProperty(SettingsMerger.MergeSettingsFilesProperty) as StringProperty;

            string mergeType = SettingsMerger.MergeStyleParent;
            if (mergeTypeProperty != null)
            {
                mergeType = mergeTypeProperty.Value;
            }

            // If the merge style is set to link but the current environment doesn't support linking, change it to parent.
            if ((environment == null || !environment.SupportsLinkedSettings) && string.CompareOrdinal(mergeType, SettingsMerger.MergeStyleLinked) == 0)
            {
                mergeType = SettingsMerger.MergeStyleParent;
            }

            return mergeType;
        }

        /// <summary>
        /// Merges two collection properties together.
        /// </summary>
        /// <param name="mergedPropertyCollection">
        /// The merged property collection.
        /// </param>
        /// <param name="originalProperty">
        /// The original property to merge.
        /// </param>
        /// <param name="overridingProperty">
        /// The overriding property to merge.
        /// </param>
        private static void MergeCollectionProperties(PropertyCollection mergedPropertyCollection, PropertyValue originalProperty, PropertyValue overridingProperty)
        {
            Param.AssertNotNull(mergedPropertyCollection, "mergedPropertyCollection");
            Param.AssertNotNull(originalProperty, "originalProperty");
            Param.AssertNotNull(overridingProperty, "overridingProperty");

            CollectionProperty originalCollectionProperty = (CollectionProperty)originalProperty;
            CollectionProperty overridingCollectionProperty = (CollectionProperty)overridingProperty;

            // Create a new merged collection property.
            CollectionProperty mergedCollectionProperty = new CollectionProperty((CollectionPropertyDescriptor)originalCollectionProperty.PropertyDescriptor);
            mergedPropertyCollection.Add(mergedCollectionProperty);

            // Add each of the strings from the overriding collection.
            foreach (string value in overridingCollectionProperty.Values)
            {
                mergedCollectionProperty.Add(value);
            }

            // If necessary, also add the strings from the original collection.
            if (originalCollectionProperty.Aggregate)
            {
                foreach (string value in originalCollectionProperty.Values)
                {
                    if (!mergedCollectionProperty.Contains(value))
                    {
                        mergedCollectionProperty.Add(value);
                    }
                }
            }
        }

        /// <summary>
        /// Merges two settings files together.
        /// </summary>
        /// <param name="originalSettings">
        /// The original settings.
        /// </param>
        /// <param name="overridingSettings">
        /// The settings which are overriding the original settings.
        /// </param>
        /// <returns>
        /// Returns the merged settings.
        /// </returns>
        private static Settings MergeSettings(Settings originalSettings, Settings overridingSettings)
        {
            Param.AssertNotNull(originalSettings, "originalSettings");
            Param.AssertNotNull(overridingSettings, "overridingSettings");

            //// TODO Not sure why this has to be true
            //// TODO Also where are we getting a different core from?
            Debug.Assert(originalSettings.Core == overridingSettings.Core, "The settings must come from the same core instance.");

            // Create a new merged settings object.
            Settings mergedSettings = new Settings(originalSettings.Core);

            // Merge the global settings together.
            MergePropertyCollections(originalSettings.GlobalSettings, overridingSettings.GlobalSettings, mergedSettings.GlobalSettings);

            // Merge the parser settings together. Loop through the settings for each parser in the original settings.
            foreach (AddInPropertyCollection originalParserSettings in originalSettings.ParserSettings)
            {
                // Try to find settings for this parser in the overriding settings.
                AddInPropertyCollection overridingParserSettings = overridingSettings.GetAddInSettings(originalParserSettings.AddIn);

                // Create a new merged parser settings object.
                AddInPropertyCollection mergedParserSettings = new AddInPropertyCollection(originalParserSettings.AddIn);
                mergedSettings.SetAddInSettings(mergedParserSettings);

                // Merge the parser settings together.
                MergePropertyCollections(originalParserSettings, overridingParserSettings, mergedParserSettings);
            }

            // Now loop through the settings for each parser in the overriding settings. If there are any parser
            // settings here that aren't in the merged settings, then copy the settings directly from the overriding settings.
            // This means that there were no settings for this parser in the original settings.
            foreach (AddInPropertyCollection overridingParserSettings in overridingSettings.ParserSettings)
            {
                AddInPropertyCollection mergedParserSettings = mergedSettings.GetAddInSettings(overridingParserSettings.AddIn);
                if (mergedParserSettings == null)
                {
                    mergedSettings.SetAddInSettings((AddInPropertyCollection)overridingParserSettings.Clone());
                }
            }

            // Merge the analyzer settings together. Loop through the settings for each analyzer in the original settings.
            foreach (AddInPropertyCollection originalAnalyzerSettings in originalSettings.AnalyzerSettings)
            {
                // Try to find settings for this analyzer in the overriding settings.
                AddInPropertyCollection overridingAnalyzerSettings = overridingSettings.GetAddInSettings(originalAnalyzerSettings.AddIn);

                // Create a new merged analyzer settings object.
                AddInPropertyCollection mergedAnalyzerSettings = new AddInPropertyCollection(originalAnalyzerSettings.AddIn);
                mergedSettings.SetAddInSettings(mergedAnalyzerSettings);

                // Merge the analyer settings together.
                MergePropertyCollections(originalAnalyzerSettings, overridingAnalyzerSettings, mergedAnalyzerSettings);
            }

            // Now loop through the settings for each analyzer in the overriding settings. If there are any analyzer
            // settings here that aren't in the merged settings, then copy the settings directly from the overriding settings.
            // This means that there were no settings for this analyzer in the original settings.
            foreach (AddInPropertyCollection overridingAnalyzerSettings in overridingSettings.AnalyzerSettings)
            {
                AddInPropertyCollection mergedAnalyzerSettings = mergedSettings.GetAddInSettings(overridingAnalyzerSettings.AddIn);
                if (mergedAnalyzerSettings == null)
                {
                    mergedSettings.SetAddInSettings((AddInPropertyCollection)overridingAnalyzerSettings.Clone());
                }
            }

            // Merge the write times together. Set the write time of the merged settings file to the most
            // recent write time of the two file which were merged.
            if (originalSettings.WriteTime.CompareTo(overridingSettings.WriteTime) > 0)
            {
                mergedSettings.WriteTime = originalSettings.WriteTime;
            }
            else
            {
                mergedSettings.WriteTime = overridingSettings.WriteTime;
            }

            return mergedSettings;
        }

        /// <summary>
        /// Finds a linked settings document and merges it with the given settings.
        /// </summary>
        /// <param name="originalSettings">
        /// The original settings.
        /// </param>
        /// <param name="mergeOriginal">
        /// Indicates whether the merge the original settings with the linked settings.
        /// </param>
        /// <returns>
        /// Returns the merged settings.
        /// </returns>
        /// <remarks>
        /// This method is designed to work only in file-based environments.
        /// </remarks>
        private Settings FindMergedSettingsThroughLinkedSettings(Settings originalSettings, bool mergeOriginal)
        {
            Param.AssertNotNull(originalSettings, "originalSettings");
            Param.Ignore(mergeOriginal);

            StringProperty linkedSettingsProperty = originalSettings.GlobalSettings.GetProperty(SettingsMerger.LinkedSettingsProperty) as StringProperty;
            if (linkedSettingsProperty != null && !string.IsNullOrEmpty(linkedSettingsProperty.Value))
            {
                string linkedSettingsFile = Environment.ExpandEnvironmentVariables(linkedSettingsProperty.Value);

                if (linkedSettingsFile.StartsWith(".", StringComparison.Ordinal) || !linkedSettingsFile.Contains("\\"))
                {
                    linkedSettingsFile = Utils.MakeAbsolutePath(Path.GetDirectoryName(originalSettings.Location), linkedSettingsFile);
                }

                if (File.Exists(linkedSettingsFile))
                {
                    Settings mergedLinkedSettings = this.environment.GetSettings(linkedSettingsFile, true);
                    if (mergedLinkedSettings != null)
                    {
                        if (mergeOriginal)
                        {
                            return MergeSettings(mergedLinkedSettings, originalSettings);
                        }

                        return mergedLinkedSettings;
                    }
                }
            }

            // The linked settings do not exist. Just return the original settings.
            return originalSettings;
        }

        /// <summary>
        /// Scans all parent paths above the path containing the given settings file, and merges all settings together.
        /// </summary>
        /// <param name="originalSettings">
        /// The original settings to merge.
        /// </param>
        /// <param name="mergeOriginal">
        /// Indicates whether the merge the original settings with the parent settings files.
        /// </param>
        /// <returns>
        /// Returns the merged settings.
        /// </returns>
        private Settings FindMergedSettingsThroughParentPaths(Settings originalSettings, bool mergeOriginal)
        {
            Param.AssertNotNull(originalSettings, "originalSettings");
            Param.Ignore(mergeOriginal);

            if (!originalSettings.DefaultSettings)
            {
                bool defaultSettings = false;

                string parentSettingsPath = this.environment.GetParentSettingsPath(originalSettings.Location);
                if (string.IsNullOrEmpty(parentSettingsPath) && !originalSettings.DefaultSettings)
                {
                    defaultSettings = true;
                    parentSettingsPath = this.environment.GetDefaultSettingsPath();
                }

                if (!string.IsNullOrEmpty(parentSettingsPath))
                {
                    Settings mergedParentSettings = this.environment.GetSettings(parentSettingsPath, !defaultSettings);
                    mergedParentSettings.DefaultSettings = defaultSettings;

                    if (mergedParentSettings != null)
                    {
                        if (mergeOriginal)
                        {
                            Settings mergedSettings = MergeSettings(mergedParentSettings, originalSettings);
                            mergedSettings.DefaultSettings = defaultSettings;

                            return mergedSettings;
                        }

                        return mergedParentSettings;
                    }
                }
            }

            return mergeOriginal ? originalSettings : null;
        }

        #endregion
    }
}