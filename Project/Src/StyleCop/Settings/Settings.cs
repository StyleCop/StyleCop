// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Settings.cs" company="https://github.com/StyleCop">
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
//   Represents a single StyleCop settings file in read-only mode.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading;
    using System.Xml;

    /// <summary>
    /// Represents a single StyleCop settings file in read-only mode.
    /// </summary>
    public class Settings
    {
        #region Constants

        /// <summary>
        /// The alternate settings file name.
        /// </summary>
        public const string AlternateFileName = "Settings.SourceAnalysis";

        /// <summary>
        /// The default settings file name.
        /// </summary>
        public const string DefaultFileName = "Settings.StyleCop";

        #endregion

        #region Fields

        /// <summary>
        /// The settings for the analyzers.
        /// </summary>
        private readonly Dictionary<string, AddInPropertyCollection> analyzerSettings = new Dictionary<string, AddInPropertyCollection>();

        /// <summary>
        /// The contents of the settings document.
        /// </summary>
        private readonly XmlDocument contents;

        /// <summary>
        /// The StyleCop core instance.
        /// </summary>
        private readonly StyleCopCore core;

        /// <summary>
        /// Lock object for enabled rules dictionary
        /// </summary>
        private readonly ReaderWriterLock enabledRulesLock = new ReaderWriterLock();

        /// <summary>
        /// The global settings.
        /// </summary>
        private readonly PropertyCollection globalSettings = new PropertyCollection();

        /// <summary>
        /// The path to the settings document.
        /// </summary>
        private readonly string location;

        /// <summary>
        /// The settings for the parsers.
        /// </summary>
        private readonly Dictionary<string, AddInPropertyCollection> parserSettings = new Dictionary<string, AddInPropertyCollection>();

        /// <summary>
        /// The collection of excluded files specified in the settings.
        /// </summary>
        private readonly List<SourceFileListSettings> sourceFileLists = new List<SourceFileListSettings>();

        /// <summary>
        /// Indicates whether this is the default settings file for the installation.
        /// </summary>
        private bool defaultSettings;

        /// <summary>
        /// The collection of enabled analyzers based on the settings.
        /// </summary>
        private Dictionary<StyleCopAddIn, Dictionary<string, Rule>> enabledRules;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the Settings class.
        /// </summary>
        /// <param name="core">
        /// The StyleCop core instance. 
        /// </param>
        /// <param name="location">
        /// The location of the settings document. 
        /// </param>
        public Settings(StyleCopCore core, string location)
            : this(core, location, null, new DateTime())
        {
            Param.Ignore(core, location);
        }

        /// <summary>
        /// Initializes a new instance of the Settings class.
        /// </summary>
        /// <param name="core">
        /// The StyleCop core instance. 
        /// </param>
        /// <param name="location">
        /// The path to the settings document. 
        /// </param>
        /// <param name="contents">
        /// The initial contents of the settings document. 
        /// </param>
        /// <param name="writeTime">
        /// The time when the settings were last updated. 
        /// </param>
        public Settings(StyleCopCore core, string location, XmlDocument contents, DateTime writeTime)
        {
            Param.RequireNotNull(core, "core");
            Param.Ignore(location);
            Param.Ignore(contents);
            Param.Ignore(writeTime);

            this.core = core;
            this.location = location;
            this.contents = contents;
            this.WriteTime = writeTime;

            this.LoadSettingsDocument();
        }

        /// <summary>
        /// Initializes a new instance of the Settings class.
        /// </summary>
        /// <param name="core">
        /// The StyleCop core instance. 
        /// </param>
        internal Settings(StyleCopCore core)
        {
            Param.AssertNotNull(core, "core");
            this.core = core;
        }

        #endregion

        #region Public Properties

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
        [SuppressMessage("Microsoft.Design", "CA1059:MembersShouldNotExposeCertainConcreteTypes", MessageId = "System.Xml.XmlNode", 
            Justification = "Compliance would break public API.")]
        public XmlDocument Contents
        {
            get
            {
                return this.contents;
            }
        }

        /// <summary>
        /// Gets the collection of enabled analyzers for these settings.
        /// </summary>
        public IEnumerable<SourceAnalyzer> EnabledAnalyzers
        {
            get
            {
                this.enabledRulesLock.AcquireReaderLock(Timeout.Infinite);

                try
                {
                    this.InitializeEnabledRules();

                    foreach (StyleCopAddIn addIn in this.enabledRules.Keys)
                    {
                        SourceAnalyzer analyzer = addIn as SourceAnalyzer;
                        if (analyzer != null)
                        {
                            yield return analyzer;
                        }
                    }
                }
                finally
                {
                    this.enabledRulesLock.ReleaseReaderLock();
                }
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
        /// Gets the location of the settings file.
        /// </summary>
        public string Location
        {
            get
            {
                return this.location;
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
        /// Gets a value indicating whether rules for this file list are enabled or disabled by default.
        /// </summary>
        public bool RulesEnabledByDefault
        {
            get
            {
                if (this.globalSettings != null)
                {
                    BooleanProperty property = this.globalSettings["RulesEnabledByDefault"] as BooleanProperty;
                    return property == null || property.Value;
                }

                return true;
            }
        }

        /// <summary>
        /// Gets the collection of source files lists.
        /// </summary>
        public ICollection<SourceFileListSettings> SourceFileLists
        {
            get
            {
                return this.sourceFileLists.AsReadOnly();
            }
        }

        /// <summary>
        /// Gets the time when the settings were last updated.
        /// </summary>
        public DateTime WriteTime { get; internal set; }

        #endregion

        #region Properties

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

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Gets a setting for the given add-in.
        /// </summary>
        /// <param name="addIn">
        /// The add-in. 
        /// </param>
        /// <param name="propertyName">
        /// The name of the setting property. 
        /// </param>
        /// <returns>
        /// Returns the setting or null if the setting does not exist for the add-in. 
        /// </returns>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "InSetting", 
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
        /// Gets the settings for the given add-in.
        /// </summary>
        /// <param name="addIn">
        /// The add-in. 
        /// </param>
        /// <returns>
        /// Returns the add-in settings or null if there are no settings for the add-in. 
        /// </returns>
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
        /// Gets the custom settings for a file with the given name, if any.
        /// </summary>
        /// <param name="fileName">
        /// The name of the file. 
        /// </param>
        /// <returns>
        /// Returns the custom settings or null if there are no custom settings specified for this file. 
        /// </returns>
        /// <remarks>
        /// Custom settings are specified through a SourceFileList node in the settings file.
        /// </remarks>
        public Settings GetCustomSettingsForFile(string fileName)
        {
            Param.Ignore(fileName);

            if (!string.IsNullOrEmpty(fileName))
            {
                for (int i = 0; i < this.sourceFileLists.Count; ++i)
                {
                    if (this.sourceFileLists[i].ContainsFile(fileName))
                    {
                        return this.sourceFileLists[i].Settings;
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Gets a value indicating whether the given rule is enabled for the given document.
        /// </summary>
        /// <param name="analyzer">
        /// The analyzer which contains the rule. 
        /// </param>
        /// <param name="ruleName">
        /// The rule to check. 
        /// </param>
        /// <returns>
        /// Returns true if the rule is enabled; otherwise false. 
        /// </returns>
        public bool IsRuleEnabled(SourceAnalyzer analyzer, string ruleName)
        {
            Param.RequireNotNull(analyzer, "analyzer");
            Param.RequireValidString(ruleName, "ruleName");

            this.enabledRulesLock.AcquireReaderLock(Timeout.Infinite);

            try
            {
                this.InitializeEnabledRules();

                if (this.enabledRules != null)
                {
                    Dictionary<string, Rule> enabledRulesForAnalyzer = null;
                    if (this.enabledRules.TryGetValue(analyzer, out enabledRulesForAnalyzer) && enabledRulesForAnalyzer != null)
                    {
                        return enabledRulesForAnalyzer.ContainsKey(ruleName);
                    }
                }
            }
            finally
            {
                this.enabledRulesLock.ReleaseReaderLock();
            }

            return false;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Adds a set of custom source file settings.
        /// </summary>
        /// <param name="sourceFileList">
        /// The source file list settings. 
        /// </param>
        internal void AddSourceFileList(SourceFileListSettings sourceFileList)
        {
            Param.AssertNotNull(sourceFileList, "sourceFileList");
            this.sourceFileLists.Add(sourceFileList);
        }

        /// <summary>
        /// Clears a setting for the given add-in.
        /// </summary>
        /// <param name="addIn">
        /// The add-in. 
        /// </param>
        /// <param name="propertyName">
        /// The name of the property to clear. 
        /// </param>
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
        /// Sets a setting for the given add-in.
        /// </summary>
        /// <param name="addIn">
        /// The add-in. 
        /// </param>
        /// <param name="property">
        /// The setting property to set. 
        /// </param>
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
        /// Sets the settings for the given add-in.
        /// </summary>
        /// <param name="properties">
        /// The properties to set. 
        /// </param>
        /// <remarks>
        /// This overrides any existing settings for the add-in.
        /// </remarks>
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
        /// Gets the correct property collection dictionary depending on whether the given add-in is a parser or an analyzer.
        /// </summary>
        /// <param name="addIn">
        /// The add-in. 
        /// </param>
        /// <returns>
        /// Returns the correct dictionary. 
        /// </returns>
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

        /// <summary>
        /// Initializes the collection of enabled analyzers and rules based on these settings.
        /// </summary>
        private void InitializeEnabledRules()
        {
            if (this.enabledRules == null)
            {
                LockCookie cookie = this.enabledRulesLock.UpgradeToWriterLock(Timeout.Infinite);

                try
                {
                    if (this.enabledRules == null)
                    {
                        this.enabledRules = new Dictionary<StyleCopAddIn, Dictionary<string, Rule>>();

                        // Determine whether addins are enabled or disabled by default.
                        bool enabledByDefault = this.RulesEnabledByDefault;

                        // Iterate through all loaded parsers.
                        foreach (SourceParser parser in this.core.Parsers)
                        {
                            // Iterate through each analyzer attached to this parser.
                            foreach (SourceAnalyzer analyzer in parser.Analyzers)
                            {
                                // Create a dictionary to hold each enabled rule for the analyzer.
                                Dictionary<string, Rule> enabledRulesForAnalyzer = new Dictionary<string, Rule>();

                                // Get the settings for this analyzer, if there are any.
                                AddInPropertyCollection analyzerSettings = this.GetAddInSettings(analyzer);

                                // Iterate through each of the analyzer's rules.
                                foreach (Rule rule in analyzer.AddInRules)
                                {
                                    // Determine whether the rule is currently enabled.
                                    bool ruleEnabled = enabledByDefault && rule.EnabledByDefault;

                                    // Determine whether there is a setting which enables or disables the rules.
                                    // If the rule is set to CanDisable = false, then ignore the setting unless
                                    // we are in disabled by default mode.
                                    if (analyzerSettings != null && (!ruleEnabled || rule.CanDisable))
                                    {
                                        BooleanProperty property = analyzerSettings[rule.Name + "#Enabled"] as BooleanProperty;
                                        if (property != null)
                                        {
                                            ruleEnabled = property.Value;
                                        }
                                    }

                                    // If the rule is enabled, add it to the enabled rules dictionary.
                                    if (ruleEnabled)
                                    {
                                        enabledRulesForAnalyzer.Add(rule.Name, rule);
                                    }
                                }

                                // If the analyzer has at least one enabled rule, add the analyzer to the list 
                                // of enabled analyzers.
                                if (enabledRulesForAnalyzer.Count > 0)
                                {
                                    // The rules list should not already be set for this project on this analyzer.
                                    // If so, something is wrong.
                                    Debug.Assert(!this.enabledRules.ContainsKey(analyzer), "The rule list for this analyzer should not be set yet.");

                                    this.enabledRules.Add(analyzer, enabledRulesForAnalyzer);
                                }
                            }
                        }
                    }
                }
                finally
                {
                    this.enabledRulesLock.DowngradeFromWriterLock(ref cookie);
                }
            }
        }

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
                if (string.Equals(version, "105", StringComparison.Ordinal))
                {
                    V105Settings.Load(this.contents, this);
                }
                else if (string.Equals(version, "4.3", StringComparison.Ordinal))
                {
                    V104Settings.Load(this.contents, this);
                }
                else if (string.Equals(version, "4.2", StringComparison.Ordinal))
                {
                    V103Settings.Load(this.contents, this);
                }
                else if (string.Equals(version, "4.1", StringComparison.Ordinal))
                {
                    V102Settings.Load(this.contents, this);
                }
                else
                {
                    V101Settings.Load(this.contents, this);
                }
            }
        }

        #endregion
    }
}