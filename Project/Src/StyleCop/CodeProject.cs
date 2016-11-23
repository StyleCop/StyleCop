// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CodeProject.cs" company="https://github.com/StyleCop">
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
//   Describes a project containing one or more source code documents.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Globalization;

    /// <summary>
    /// Describes a project containing one or more source code documents.
    /// </summary>
    public class CodeProject
    {
        #region Constants

        /// <summary>
        /// The default culture.
        /// </summary>
        private const string DefaultCulture = "en-US";

        /// <summary>
        /// The default maximum violation count.
        /// </summary>
        private const int DefaultMaxViolationCount = 1000;

        #endregion

        #region Fields

        /// <summary>
        /// The configuration for the project.
        /// </summary>
        private readonly Configuration configuration;

        /// <summary>
        /// The unique key for the project.
        /// </summary>
        private readonly int key;

        /// <summary>
        /// The location where the project is contained.
        /// </summary>
        private readonly string location;

        /// <summary>
        /// The target framework version used to check new specification features.
        /// </summary>
        private readonly double targetFrameworkVersion;

        /// <summary>
        /// The list of source code documents in the project.
        /// </summary>
        private readonly List<SourceCode> sourceCodes = new List<SourceCode>();

        /// <summary>
        /// The CultureInfo to use during analysis.
        /// </summary>
        private CultureInfo culture;

        /// <summary>
        /// Deprecated words for the spell checker.
        /// </summary>
        private Dictionary<string, string> deprecatedWords;

        /// <summary>
        /// Folders to scan for CustomDictionary.xml files.
        /// </summary>
        private ICollection<string> dictionaryFolders;

        /// <summary>
        /// Maximum number of violations to occur before cancelling analysis.
        /// </summary>
        private int? maxViolationCount;

        /// <summary>
        /// Recognized words for the spell checker.
        /// </summary>
        private ICollection<string> recognizedWords;

        /// <summary>
        /// The settings for the project.
        /// </summary>
        private Settings settings;

        /// <summary>
        /// Indicates whether settings have been loaded into the project.
        /// </summary>
        private bool settingsLoaded;

        /// <summary>
        /// Indicates whether to write cache results for the project.
        /// </summary>
        private bool? writeCache;

        private bool? violationsAsErrors;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the CodeProject class.
        /// </summary>
        /// <param name="key">The unique key for the project.</param>
        /// <param name="location">The location where the project is contained.</param>
        /// <param name="configuration">The active configuration.</param>
        /// <param name="frameworkVersion">The framework version for current code project, default 0 if not found.</param>
        public CodeProject(int key, string location, Configuration configuration, double frameworkVersion = 0)
        {
            Param.Ignore(key);
            Param.Ignore(location);
            Param.Ignore(frameworkVersion);
            Param.RequireNotNull(configuration, "configuration");

            this.key = key;
            this.configuration = configuration;
            this.targetFrameworkVersion = frameworkVersion;

            if (location != null)
            {
                // Trim the path and convert it to lowercase characters
                // so that we can do string matches and find other files and
                // projects under the same location.
                this.location = StyleCopCore.CleanPath(location);
            }
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the project configuration.
        /// </summary>
        public Configuration Configuration
        {
            get
            {
                return this.configuration;
            }
        }

        /// <summary>
        /// Gets the CultureInfo to use during analysis.
        /// </summary>
        public virtual CultureInfo Culture
        {
            get
            {
                if (this.culture == null && this.settingsLoaded)
                {
                    if (this.settings != null)
                    {
                        PropertyDescriptor<string> descriptor = this.settings.Core.PropertyDescriptors["Culture"] as PropertyDescriptor<string>;
                        if (descriptor != null)
                        {
                            StringProperty property = this.settings.GlobalSettings.GetProperty(descriptor.PropertyName) as StringProperty;
                            this.culture = property == null ? new CultureInfo(descriptor.DefaultValue) : new CultureInfo(property.Value);
                        }
                        else
                        {
                            this.culture = new CultureInfo(DefaultCulture);
                        }
                    }
                    else
                    {
                        this.culture = new CultureInfo(DefaultCulture);
                    }
                }

                return this.culture ?? new CultureInfo(DefaultCulture);
            }
        }

        /// <summary>
        /// Gets the dictionary of deprecated words and their alternatives.
        /// </summary>
        public virtual IDictionary<string, string> DeprecatedWords
        {
            get
            {
                if (this.deprecatedWords == null && this.settingsLoaded)
                {
                    if (this.settings != null)
                    {
                        CollectionPropertyDescriptor descriptor = this.settings.Core.PropertyDescriptors["DeprecatedWords"] as CollectionPropertyDescriptor;
                        if (descriptor != null)
                        {
                            CollectionProperty property = this.settings.GlobalSettings.GetProperty(descriptor.PropertyName) as CollectionProperty;
                            if (property == null)
                            {
                                this.deprecatedWords = null;
                            }
                            else
                            {
                                this.deprecatedWords = new Dictionary<string, string>();

                                foreach (string propertyValue in property.Values)
                                {
                                    string[] propertyParts = propertyValue.Split(',');
                                    if (propertyParts.Length == 2)
                                    {
                                        string word = propertyParts[0].Trim();
                                        string alternativeWord = propertyParts[1].Trim();

                                        if (!this.deprecatedWords.ContainsKey(word))
                                        {
                                            this.deprecatedWords.Add(word, alternativeWord);
                                        }

                                        string lowercaseWord = word.ToLower(this.culture);
                                        string lowerAlternativeWord = alternativeWord.ToLower(this.culture);

                                        if (!this.deprecatedWords.ContainsKey(lowercaseWord))
                                        {
                                            this.deprecatedWords.Add(lowercaseWord, lowerAlternativeWord);
                                        }

                                        string properCaseWord = char.ToUpper(lowercaseWord[0], this.culture) + lowercaseWord.Substring(1);
                                        string properCaseAlternativeWord = char.ToUpper(lowerAlternativeWord[0], this.culture) + lowerAlternativeWord.Substring(1);

                                        if (!this.deprecatedWords.ContainsKey(properCaseWord))
                                        {
                                            this.deprecatedWords.Add(properCaseWord, properCaseAlternativeWord);
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            this.deprecatedWords = new Dictionary<string, string>();
                        }
                    }
                    else
                    {
                        this.deprecatedWords = new Dictionary<string, string>();
                    }
                }

                return this.deprecatedWords ?? new Dictionary<string, string>();
            }
        }

        /// <summary>
        /// Gets the dictionary of folders that will be scanned for CustomDictionary.xml files.
        /// </summary>
        public virtual ICollection<string> DictionaryFolders
        {
            get
            {
                if (this.dictionaryFolders == null && this.settingsLoaded)
                {
                    if (this.settings != null)
                    {
                        CollectionPropertyDescriptor descriptor = this.settings.Core.PropertyDescriptors["DictionaryFolders"] as CollectionPropertyDescriptor;
                        if (descriptor != null)
                        {
                            CollectionProperty property = this.settings.GlobalSettings.GetProperty(descriptor.PropertyName) as CollectionProperty;
                            if (property == null)
                            {
                                this.dictionaryFolders = null;
                            }
                            else
                            {
                                this.dictionaryFolders = new Collection<string>();

                                foreach (string propertyValue in property.Values)
                                {
                                    string path = Environment.ExpandEnvironmentVariables(propertyValue);
                                    this.dictionaryFolders.Add(path);
                                }
                            }
                        }
                        else
                        {
                            this.dictionaryFolders = new Collection<string>();
                        }
                    }
                    else
                    {
                        this.dictionaryFolders = new Collection<string>();
                    }
                }

                return this.dictionaryFolders ?? new Collection<string>();
            }
        }

        /// <summary>
        /// Gets the unique key for the project.
        /// </summary>
        public int Key
        {
            get
            {
                return this.key;
            }
        }

        /// <summary>
        /// Gets the location where the project is contained.
        /// </summary>
        public string Location
        {
            get
            {
                return this.location;
            }
        }

        /// <summary>
        /// Gets the target framework version for current project.
        /// </summary>
        public double TargetFrameworkVersion
        {
            get
            {
                return this.targetFrameworkVersion;
            }
        }

        /// <summary>
        /// Gets a value indicating how many violations should occur before cancelling analysis.
        /// </summary>
        public virtual int MaxViolationCount
        {
            get
            {
                if (this.maxViolationCount == null && this.settingsLoaded)
                {
                    if (this.settings != null)
                    {
                        PropertyDescriptor<int> descriptor = this.settings.Core.PropertyDescriptors["MaxViolationCount"] as PropertyDescriptor<int>;
                        if (descriptor != null)
                        {
                            IntProperty property = this.settings.GlobalSettings.GetProperty(descriptor.PropertyName) as IntProperty;
                            this.maxViolationCount = property == null ? descriptor.DefaultValue : property.Value;
                        }
                        else
                        {
                            this.maxViolationCount = DefaultMaxViolationCount;
                        }
                    }
                    else
                    {
                        this.maxViolationCount = DefaultMaxViolationCount;
                    }
                }

                return this.maxViolationCount == null ? DefaultMaxViolationCount : this.maxViolationCount.Value;
            }
        }

        /// <summary>
        /// Gets the list of recognized words.
        /// </summary>
        public virtual ICollection<string> RecognizedWords
        {
            get
            {
                if (this.recognizedWords == null && this.settingsLoaded)
                {
                    if (this.settings != null)
                    {
                        CollectionPropertyDescriptor descriptor = this.settings.Core.PropertyDescriptors["RecognizedWords"] as CollectionPropertyDescriptor;
                        if (descriptor != null)
                        {
                            CollectionProperty property = this.settings.GlobalSettings.GetProperty(descriptor.PropertyName) as CollectionProperty;
                            if (property == null)
                            {
                                this.recognizedWords = null;
                            }
                            else
                            {
                                this.recognizedWords = new Collection<string>();
                                foreach (string word in property.Values)
                                {
                                    if (!this.recognizedWords.Contains(word))
                                    {
                                        this.recognizedWords.Add(word);
                                    }

                                    string lowercaseWord = word.ToLower(this.culture);
                                    if (!this.recognizedWords.Contains(lowercaseWord))
                                    {
                                        this.recognizedWords.Add(lowercaseWord);
                                    }

                                    string properCaseWord = char.ToUpper(lowercaseWord[0], this.culture) + lowercaseWord.Substring(1);
                                    if (!this.recognizedWords.Contains(properCaseWord))
                                    {
                                        this.recognizedWords.Add(properCaseWord);
                                    }
                                }
                            }
                        }
                        else
                        {
                            this.recognizedWords = new Collection<string>();
                        }
                    }
                    else
                    {
                        this.recognizedWords = new Collection<string>();
                    }
                }

                return this.recognizedWords ?? new Collection<string>();
            }
        }

        /// <summary>
        /// Gets or sets the settings for the project.
        /// </summary>
        public Settings Settings
        {
            get
            {
                return this.settings;
            }

            set
            {
                Param.Ignore(value);
                this.settings = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether settings have been loaded into the project.
        /// </summary>
        public bool SettingsLoaded
        {
            get
            {
                return this.settingsLoaded;
            }

            set
            {
                Param.Ignore(value);
                this.settingsLoaded = value;
            }
        }

        /// <summary>
        /// Gets the list of source code documents in the project.
        /// </summary>
        public IList<SourceCode> SourceCodeInstances
        {
            get
            {
                // Convert to array to make it read-only. It is
                // efficient to convert a List<> to an array.
                return this.sourceCodes.ToArray();
            }
        }

        /// <summary>
        /// Gets a value indicating whether to write cache results for the project.
        /// </summary>
        public virtual bool WriteCache
        {
            get
            {
                if (this.writeCache == null && this.settingsLoaded)
                {
                    if (this.settings != null)
                    {
                        PropertyDescriptor<bool> descriptor = this.settings.Core.PropertyDescriptors["WriteCache"] as PropertyDescriptor<bool>;
                        if (descriptor != null)
                        {
                            BooleanProperty property = this.settings.GlobalSettings.GetProperty(descriptor.PropertyName) as BooleanProperty;
                            if (property == null)
                            {
                                this.writeCache = descriptor.DefaultValue;
                            }
                            else
                            {
                                this.writeCache = property.Value;
                            }
                        }
                        else
                        {
                            this.writeCache = true;
                        }
                    }
                    else
                    {
                        this.writeCache = true;
                    }
                }

                if (this.writeCache == null)
                {
                    return true;
                }

                return this.writeCache.Value;
            }
        }

        /// <summary>
        /// Gets a value indicating whether to treat violations as errors.
        /// </summary>
        public bool ViolationsAsErrors
        {
            get
            {
                if (this.violationsAsErrors == null && this.settingsLoaded)
                {
                    if (this.settings != null)
                    {
                        PropertyDescriptor<bool> descriptor = this.settings.Core.PropertyDescriptors["ViolationsAsErrors"] as PropertyDescriptor<bool>;
                        if (descriptor != null)
                        {
                            BooleanProperty property = this.settings.GlobalSettings.GetProperty(descriptor.PropertyName) as BooleanProperty;
                            if (property == null)
                            {
                                this.violationsAsErrors = descriptor.DefaultValue;
                            }
                            else
                            {
                                this.violationsAsErrors = property.Value;
                            }
                        }
                        else
                        {
                            this.violationsAsErrors = true;
                        }
                    }
                    else
                    {
                        this.violationsAsErrors = true;
                    }
                }

                if (this.violationsAsErrors == null)
                {
                    return true;
                }

                return this.violationsAsErrors.Value;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Adds the given source code document to the project.
        /// </summary>
        /// <param name="sourceCode">
        /// The source code to add.
        /// </param>
        internal virtual void AddSourceCode(SourceCode sourceCode)
        {
            Param.AssertNotNull(sourceCode, "sourceCode");

            if (string.IsNullOrEmpty(sourceCode.Type))
            {
                throw new ArgumentException(Strings.SourceCodeTypePropertyNotSet);
            }

            this.sourceCodes.Add(sourceCode);
        }

        #endregion
    }
}