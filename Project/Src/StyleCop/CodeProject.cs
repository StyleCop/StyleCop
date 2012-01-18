//-----------------------------------------------------------------------
// <copyright file="CodeProject.cs">
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
namespace StyleCop
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Describes a project containing one or more source code documents.
    /// </summary>
    public class CodeProject
    {
        #region Private Fields

        /// <summary>
        /// The location where the project is contained.
        /// </summary>
        private string location;

        /// <summary>
        /// The unique key for the project.
        /// </summary>
        private int key;

        /// <summary>
        /// The configuration for the project.
        /// </summary>
        private Configuration configuration;

        /// <summary>
        /// The list of source code documents in the project.
        /// </summary>
        private List<SourceCode> sourceCodes = new List<SourceCode>();

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

        /// <summary>
        /// Indicates whether we should automatically check for StyleCop updates.
        /// </summary>
        private bool? automaticallyCheckForUpdates;

        /// <summary>
        /// How many days to wait before checking for updates.
        /// </summary>
        private int? daysToCheckForUpdates;
        
        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the CodeProject class.
        /// </summary>
        /// <param name="key">The unique key for the project.</param>
        /// <param name="location">The location where the project is contained.</param>
        /// <param name="configuration">The active configuration.</param>
        public CodeProject(int key, string location, Configuration configuration)
        {
            Param.Ignore(key);
            Param.Ignore(location);
            Param.RequireNotNull(configuration, "configuration");

            this.key = key;
            this.configuration = configuration;

            if (location != null)
            {
                // Trim the path and convert it to lowercase characters
                // so that we can do string matches and find other files and
                // projects under the same location.
                this.location = StyleCopCore.CleanPath(location);
            }
        }

        #endregion Public Constructors

        #region Public Properties

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
        /// Gets a value indicating whether to automatically check for updates to StyleCop.
        /// </summary>
        public virtual bool AutomaticallyCheckForUpdates
        {
            get
            {
                if (this.automaticallyCheckForUpdates == null && this.settingsLoaded)
                {
                    if (this.settings != null)
                    {
                        var descriptor = this.settings.Core.PropertyDescriptors["AutoCheckForUpdate"] as PropertyDescriptor<bool>;
                        if (descriptor != null)
                        {
                            var property = this.settings.GlobalSettings.GetProperty(descriptor.PropertyName) as BooleanProperty;
                            this.automaticallyCheckForUpdates = property == null ? descriptor.DefaultValue : property.Value;
                        }
                        else
                        {
                            this.automaticallyCheckForUpdates = true;
                        }
                    }
                    else
                    {
                        this.automaticallyCheckForUpdates = true;
                    }
                }

                return this.automaticallyCheckForUpdates == null || this.automaticallyCheckForUpdates.Value;
            }
        }

        /// <summary>
        /// Gets a value indicating how many days to wait before checking for updates.
        /// </summary>
        public virtual int DaysToCheckForUpdates
        {
            get
            {
                if (this.daysToCheckForUpdates == null && this.settingsLoaded)
                {
                    if (this.settings != null)
                    {
                        var descriptor = this.settings.Core.PropertyDescriptors["DaysToCheckForUpdates"] as PropertyDescriptor<int>;
                        if (descriptor != null)
                        {
                            var property = this.settings.GlobalSettings.GetProperty(descriptor.PropertyName) as IntProperty;
                            this.daysToCheckForUpdates = property == null ? descriptor.DefaultValue : property.Value;
                        }
                        else
                        {
                            this.daysToCheckForUpdates = 2;
                        }
                    }
                    else
                    {
                        this.daysToCheckForUpdates = 2;
                    }
                }

                return this.daysToCheckForUpdates == null ? 2 : this.daysToCheckForUpdates.Value;
            }
        }

        #endregion Public Properties

        #region Internal Virtual Methods

        /// <summary>
        /// Adds the given source code document to the project.
        /// </summary>
        /// <param name="sourceCode">The source code to add.</param>
        internal virtual void AddSourceCode(SourceCode sourceCode)
        {
            Param.AssertNotNull(sourceCode, "sourceCode");

            if (string.IsNullOrEmpty(sourceCode.Type))
            {
                throw new ArgumentException(Strings.SourceCodeTypePropertyNotSet);
            }

            this.sourceCodes.Add(sourceCode);
        }

        #endregion Internal Virtual Methods
    }
}