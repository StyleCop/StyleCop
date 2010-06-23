//-----------------------------------------------------------------------
// <copyright file="Settings.cs" company="Microsoft">
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
namespace Microsoft.StyleCop
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.IO;
    using System.Security;
    using System.Xml;

    /// <summary>
    /// Represents a single StyleCop settings file in read-only mode.
    /// </summary>
    public class Settings
    {
        #region Public Constants

        /// <summary>
        /// The default settings file name.
        /// </summary>
        public const string DefaultFileName = "Settings.StyleCop";

        /// <summary>
        /// The alternate settings file name.
        /// </summary>
        public const string AlternateFileName = "Settings.SourceAnalysis";

        #endregion Public Constants

        #region Private Static Fields

        /// <summary>
        /// An empty array of strings.
        /// </summary>
        private static readonly string[] EmptyStringArray = new string[] { };

        #endregion Private Static Fields

        #region Private Fields

        /// <summary>
        /// The path to the settings document.
        /// </summary>
        private string path;

        /// <summary>
        /// The location where the document is contained.
        /// </summary>
        private string location;

        /// <summary>
        /// The contents of the settings document.
        /// </summary>
        private XmlDocument contents;

        /// <summary>
        /// The time when the settings were last updated.
        /// </summary>
        private DateTime writeTime;

        /// <summary>
        /// The global settings.
        /// </summary>
        private PropertyCollection globalSettings = new PropertyCollection();

        /// <summary>
        /// The settings for the parsers.
        /// </summary>
        private Dictionary<string, AddInPropertyCollection> parserSettings = new Dictionary<string, AddInPropertyCollection>();

        /// <summary>
        /// The settings for the analyzers.
        /// </summary>
        private Dictionary<string, AddInPropertyCollection> analyzerSettings = new Dictionary<string, AddInPropertyCollection>();

        /// <summary>
        /// The collection of excluded files specified in the settings.
        /// </summary>
        private Dictionary<string, string> excludedFiles;

        /// <summary>
        /// The StyleCop core instance.
        /// </summary>
        private StyleCopCore core;

        /// <summary>
        /// Indicates whether this is the default settings file for the installation.
        /// </summary>
        private bool defaultSettings;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the Settings class.
        /// </summary>
        /// <param name="core">The StyleCop core instance.</param>
        internal Settings(StyleCopCore core)
        {
            Param.AssertNotNull(core, "core");
            this.core = core;
        }

        /// <summary>
        /// Initializes a new instance of the Settings class.
        /// </summary>
        /// <param name="core">The StyleCop core instance.</param>
        /// <param name="path">The path to the settings document.</param>
        /// <param name="location">The location where the settings document is contained.</param>
        internal Settings(StyleCopCore core, string path, string location)
            : this(core, path, location, null, new DateTime())
        {
            Param.Ignore(core, path, location);
        }

        /// <summary>
        /// Initializes a new instance of the Settings class.
        /// </summary>
        /// <param name="core">The StyleCop core instance.</param>
        /// <param name="path">The path to the settings document.</param>
        /// <param name="location">The location where the settings document is contained.</param>
        /// <param name="contents">The initial contents of the settings document.</param>
        /// <param name="writeTime">The time when the settings were last updated.</param>
        internal Settings(StyleCopCore core, string path, string location, XmlDocument contents, DateTime writeTime)
        {
            Param.AssertNotNull(core, "core");
            Param.AssertValidString(path, "path");
            Param.AssertValidString(location, "location");
            Param.Ignore(contents);
            Param.Ignore(writeTime);

            this.core = core;
            this.path = path;
            this.location = location;
            this.contents = contents;
            this.writeTime = writeTime;

            this.LoadSettingsDocument();
        }

        #endregion Internal Constructors

        #region Public Properties

        /// <summary>
        /// Gets a value indicating whether the settings are loaded.
        /// </summary>
        public bool Loaded
        {
            get
            {
                return this.contents != null;
            }
        }

        /// <summary>
        /// Gets the location where the settings document is contained.
        /// </summary>
        public string Location
        {
            get
            {
                return this.location;
            }
        }

        /// <summary>
        /// Gets the path to the settings file.
        /// </summary>
        public string Path
        {
            get
            {
                return this.path;
            }
        }

        /// <summary>
        /// Gets the time when the settings were last updated.
        /// </summary>
        public DateTime WriteTime 
        {
            get
            {
                return this.writeTime;
            }

            internal set
            {
                this.writeTime = value;
            }
        }

        /// <summary>
        /// Gets the global settings.
        /// </summary>
        public PropertyCollection GlobalSettings
        {
            get
            {
                return this.globalSettings;
            }
        }

        /// <summary>
        /// Gets the collection of settings for the parsers.
        /// </summary>
        public ICollection<AddInPropertyCollection> ParserSettings
        {
            get
            {
                return this.parserSettings.Values;
            }
        }

        /// <summary>
        /// Gets the collection of settings for the analyzers.
        /// </summary>
        public ICollection<AddInPropertyCollection> AnalyzerSettings
        {
            get
            {
                return this.analyzerSettings.Values;
            }
        }

        /// <summary>
        /// Gets the contents of the settings document.
        /// </summary>
        [SuppressMessage(
            "Microsoft.Design", 
            "CA1059:MembersShouldNotExposeCertainConcreteTypes", 
            MessageId = "System.Xml.XmlNode", 
            Justification = "Compliance would break public API.")]
        public XmlDocument Contents
        {
            get
            {
                return this.contents;
            }
        }

        /// <summary>
        /// Gets the collection of excluded files.
        /// </summary>
        public ICollection<string> ExcludedFiles
        {
            get
            {
                if (this.excludedFiles == null)
                {
                    return EmptyStringArray;
                }

                return this.excludedFiles.Values;
            }
        }

        #endregion Public Properties

        #region Internal Properties

        /// <summary>
        /// Gets the core instance.
        /// </summary>
        internal StyleCopCore Core
        {
            get
            {
                return this.core;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this is the default settings file for the installation.
        /// </summary>
        internal bool DefaultSettings
        {
            get
            {
                return this.defaultSettings;
            }

            set
            {
                Param.Ignore(value);
                this.defaultSettings = value;
            }
        }

        #endregion Internal Properties

        #region Protected Properties

        /// <summary>
        /// Gets the settings for the parsers.
        /// </summary>
        protected Dictionary<string, AddInPropertyCollection> ParserDictionary
        {
            get
            {
                return this.parserSettings;
            }
        }

        /// <summary>
        /// Gets the settings for the analyzers.
        /// </summary>
        protected Dictionary<string, AddInPropertyCollection> AnalyzerDictionary
        {
            get
            {
                return this.analyzerSettings;
            }
        }

        #endregion Protected Properties

        #region Public Methods

        /// <summary>
        /// Gets the settings for the given add-in.
        /// </summary>
        /// <param name="addIn">The add-in.</param>
        /// <returns>Returns the add-in settings or null if there are no settings for the add-in.</returns>
        public AddInPropertyCollection GetAddInSettings(StyleCopAddIn addIn)
        {
            Param.RequireNotNull(addIn, "addIn");

            Dictionary<string, AddInPropertyCollection> collection = this.GetPropertyCollectionDictionary(addIn);
            
            AddInPropertyCollection settingsForAddIn;
            if (collection.TryGetValue(addIn.Id, out settingsForAddIn))
            {
                return settingsForAddIn;
            }

            return null;
        }

        /// <summary>
        /// Gets a setting for the given add-in.
        /// </summary>
        /// <param name="addIn">The add-in.</param>
        /// <param name="propertyName">The name of the setting property.</param>
        /// <returns>Returns the setting or null if the setting does not exist for the add-in.</returns>
        [SuppressMessage(
            "Microsoft.Naming", 
            "CA1702:CompoundWordsShouldBeCasedCorrectly", 
            MessageId = "InSetting",
            Justification = "InSetting is two words in this context.")]
        public PropertyValue GetAddInSetting(StyleCopAddIn addIn, string propertyName)
        {
            Param.RequireNotNull(addIn, "addIn");
            Param.RequireValidString(propertyName, "propertyName");

            PropertyCollection properties = this.GetAddInSettings(addIn);
            if (properties != null)
            {
                return properties[propertyName];
            }

            return null;
        }

        /// <summary>
        /// Determines whether the given file has been excluded in the settings.
        /// </summary>
        /// <param name="fileName">The name of the file.</param>
        /// <returns>Returns true if the file has been excluded; false otherwise.</returns>
        public bool IsFileExcluded(string fileName)
        {
            Param.Ignore(fileName);

            if (this.excludedFiles != null && !string.IsNullOrEmpty(fileName))
            {
                return this.excludedFiles.ContainsKey(fileName.ToUpperInvariant());
            }

            return false;
        }

        #endregion Public Methods

        #region Internal Methods

        /// <summary>
        /// Sets the settings for the given add-in.
        /// </summary>
        /// <param name="properties">The properties to set.</param>
        /// <remarks>This overrides any existing settings for the add-in.</remarks>
        internal void SetAddInSettings(AddInPropertyCollection properties)
        {
            Param.AssertNotNull(properties, "properties");

            Dictionary<string, AddInPropertyCollection> collection = this.GetPropertyCollectionDictionary(properties.AddIn);

            if (collection.ContainsKey(properties.AddIn.Id))
            {
                collection[properties.AddIn.Id] = properties;
            }
            else
            {
                collection.Add(properties.AddIn.Id, properties);
            }
        }

        /// <summary>
        /// Sets a setting for the given add-in.
        /// </summary>
        /// <param name="addIn">The add-in.</param>
        /// <param name="property">The setting property to set.</param>
        internal void SetAddInSettingInternal(StyleCopAddIn addIn, PropertyValue property)
        {
            Param.AssertNotNull(addIn, "addIn");
            Param.AssertNotNull(property, "property");

            AddInPropertyCollection properties = this.GetAddInSettings(addIn);
            if (properties == null)
            {
                properties = new AddInPropertyCollection(addIn);
                this.SetAddInSettings(properties);
            }

            properties.Add(property);
        }

        /// <summary>
        /// Clears a setting for the given add-in.
        /// </summary>
        /// <param name="addIn">The add-in.</param>
        /// <param name="propertyName">The name of the property to clear.</param>
        internal void ClearAddInSettingInternal(StyleCopAddIn addIn, string propertyName)
        {
            Param.AssertNotNull(addIn, "addIn");
            Param.AssertValidString(propertyName, "propertyName");

            PropertyCollection properties = this.GetAddInSettings(addIn);
            if (properties != null)
            {
                properties.Remove(propertyName);

                if (properties.Count == 0)
                {
                    Dictionary<string, AddInPropertyCollection> collection = this.GetPropertyCollectionDictionary(addIn);
                    collection.Remove(addIn.Id);
                }
            }
        }

        /// <summary>
        /// Adds an excluded file.
        /// </summary>
        /// <param name="fileName">The name of the file to add.</param>
        internal void AddExcludedFile(string fileName)
        {
            Param.AssertNotNull(fileName, "fileName");

            if (this.excludedFiles == null)
            {
                this.excludedFiles = new Dictionary<string, string>();
            }

            string fileNameUpper = fileName.ToUpperInvariant();

            if (!this.excludedFiles.ContainsKey(fileNameUpper))
            {
                this.excludedFiles.Add(fileNameUpper, fileName);
            }
        }

        /// <summary>
        /// Merges the excluded files from the two given settings files into this settings file.
        /// </summary>
        /// <param name="settings1">The first settings.</param>
        /// <param name="settings2">The second settings.</param>
        internal void MergeExcludedFiles(Settings settings1, Settings settings2)
        {
            Param.AssertNotNull(settings1, "settings1");
            Param.AssertNotNull(settings2, "settings2");

            Debug.Assert(this.excludedFiles == null, "This method should only be called when the dictionary has not been initialized yet");

            // This method attempts to take advantage of the fact that a dictionary can be passed into the constructor of another dictionary.
            // Since we are merging two dictionaries, the most efficient way is to pass the larger of the two dictionaries into the constructor
            // of the new dictionary, and then add each of the items from the smaller dictionary to the merged dictionary one by one.
            IDictionary<string, string> baseSettings = settings1.excludedFiles;
            IDictionary<string, string> additionalSettings = settings2.excludedFiles;

            if (settings1.excludedFiles == null)
            {
                if (settings2.excludedFiles == null)
                {
                    // 1 and 2 are null.
                    baseSettings = additionalSettings = null;
                }
                else
                {
                    // 1 is null.
                    baseSettings = settings2.excludedFiles;
                    additionalSettings = null;
                }
            }
            else
            {
                if (settings2.excludedFiles == null)
                {
                    // 2 is null.
                    additionalSettings = null;
                }
                else
                {
                    // Neither are null.
                    if (settings2.excludedFiles.Count > settings1.excludedFiles.Count)
                    {
                        baseSettings = settings2.excludedFiles;
                        additionalSettings = settings1.excludedFiles;
                    }
                }
            }

            if (baseSettings != null)
            {
                this.excludedFiles = new Dictionary<string, string>(baseSettings);

                if (additionalSettings != null)
                {
                    foreach (string file in additionalSettings.Values)
                    {
                        this.AddExcludedFile(file);
                    }
                }
            }
        }

        #endregion Internal Methods

        #region Private Methods

        /// <summary>
        /// Loads the settings from the document.
        /// </summary>
        private void LoadSettingsDocument()
        {
            // Reinitialize the settings collections.
            this.globalSettings.Clear();
            this.parserSettings.Clear();
            this.analyzerSettings.Clear();

            if (this.contents != null)
            {
                // Check the version number of the file.
                XmlAttribute versionAttribute = this.contents.DocumentElement.Attributes["Version"];
                string version = versionAttribute == null ? string.Empty : versionAttribute.Value;
                if (string.Equals(version, "4.3", StringComparison.Ordinal))
                {
                    V43Settings.Load(this.contents, this);
                }
                else if (string.Equals(version, "4.2", StringComparison.Ordinal))
                {
                    V42Settings.Load(this.contents, this);
                }
                else if (string.Equals(version, "4.1", StringComparison.Ordinal))
                {
                    V41Settings.Load(this.contents, this);
                }
                else
                {
                    V40Settings.Load(this.contents, this);
                }
            }
        }

        /// <summary>
        /// Gets the correct property collection dictionary depending on whether the given add-in
        /// is a parser or an analyzer.
        /// </summary>
        /// <param name="addIn">The add-in.</param>
        /// <returns>Returns the correct dictionary.</returns>
        private Dictionary<string, AddInPropertyCollection> GetPropertyCollectionDictionary(StyleCopAddIn addIn)
        {
            Param.AssertNotNull(addIn, "addIn");

            Dictionary<string, AddInPropertyCollection> collection = this.parserSettings;
            if (addIn is SourceAnalyzer)
            {
                collection = this.analyzerSettings;
            }

            return collection;
        }

        #endregion Private Methods
    }
}
