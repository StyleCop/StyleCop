// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProjectSettingsFactory.cs" company="http://stylecop.codeplex.com">
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
//   The project settings factory.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.ReSharper.Core
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Security;
    using System.Xml;

    using JetBrains.Application.FileSystemTracker;
    using JetBrains.DataFlow;
    using JetBrains.Util;

    using StyleCop.Diagnostics;

    /// <summary>
    /// The project settings factory.
    /// </summary>
    public class ProjectSettingsFactory
    {
        // This can be confusing. This is a cache of Settings, keyed by settings file path
        // StyleCopSettings maintains a cache of merged Settings, keyed by project file
        // Note that we can't share this cache between instances, as Settings maintains
        // data keyed by object instances that aren't considered equal
        private readonly Dictionary<string, Settings> cache = new Dictionary<string, Settings>();

        private readonly Lifetime lifetime;

        private readonly IFileSystemTracker fileSystemTracker;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectSettingsFactory"/> class.
        /// </summary>
        /// <param name="lifetime">
        /// The lifetime.
        /// </param>
        /// <param name="fileSystemTracker">
        /// The file system tracker.
        /// </param>
        public ProjectSettingsFactory(Lifetime lifetime, IFileSystemTracker fileSystemTracker)
        {
            this.lifetime = lifetime;
            this.fileSystemTracker = fileSystemTracker;
        }

        /// <summary>
        /// Gets or sets StyleCopCore.
        /// </summary>
        public StyleCopCore StyleCopCore { get; set; }

        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="settingsFilePath">
        /// The settings file path.
        /// </param>
        /// <param name="readOnly">
        /// The read only.
        /// </param>
        /// <returns>
        /// A Settings object.
        /// </returns>
        public Settings Create(string settingsFilePath, bool readOnly)
        {
            StyleCopTrace.In(settingsFilePath);

            string cacheKey = string.Format("{0}::{1}", settingsFilePath, readOnly);

            Settings result;

            if (this.cache.TryGetValue(cacheKey, out result))
            {
                StyleCopTrace.Out();

                return result;
            }

            try
            {
                // Determine whether the file exists.
                if (File.Exists(settingsFilePath))
                {
                    // Load the settings document.
                    XmlDocument document = new XmlDocument();
                    document.Load(settingsFilePath);

                    // Get the last write time for the time.
                    DateTime writeTime = File.GetLastWriteTime(settingsFilePath);

                    // Create the settings container.
                    Settings settings = readOnly
                                            ? new Settings(this.StyleCopCore, settingsFilePath, document, writeTime)
                                            : new WritableSettings(this.StyleCopCore, settingsFilePath, document, writeTime);

                    StyleCopTrace.Out();
                    this.AddFileWatcher(settingsFilePath);
                    this.cache[cacheKey] = settings;

                    return settings;
                }

                StyleCopTrace.Out();

                // The file does not exist.
                return null;
            }
            catch (IOException)
            {
                StyleCopTrace.Out();

                return null;
            }
            catch (SecurityException)
            {
                StyleCopTrace.Out();

                return null;
            }
            catch (UnauthorizedAccessException)
            {
                StyleCopTrace.Out();

                return null;
            }
            catch (XmlException)
            {
                StyleCopTrace.Out();

                return null;
            }
        }

        /// <summary>
        /// Creates a FileWatcher.
        /// </summary>
        /// <param name="path">
        /// The file to watch.
        /// </param>
        private void AddFileWatcher(string path)
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
                delta => this.cache.Clear());

            StyleCopTrace.Out();
        }
    }
}