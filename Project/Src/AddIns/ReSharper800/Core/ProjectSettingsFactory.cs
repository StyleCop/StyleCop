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
namespace StyleCop.ReSharper800.Core
{
    #region Using Directives

    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Security;
    using System.Xml;

    using StyleCop.Diagnostics;

    #endregion

    /// <summary>
    /// The project settings factory.
    /// </summary>
    public class ProjectSettingsFactory
    {
        #region Static Fields

        private static readonly Dictionary<string, Settings> Cache = new Dictionary<string, Settings>();

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets StyleCopCore.
        /// </summary>
        public StyleCopCore StyleCopCore { get; set; }

        #endregion

        #region Public Methods and Operators

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

            if (Cache.TryGetValue(cacheKey, out result))
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
                    Cache[cacheKey] = settings;

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

        #endregion

        #region Methods

        /// <summary>
        /// Called when the file changes.
        /// </summary>
        /// <param name="source">
        /// The source of the event.
        /// </param>
        /// <param name="e">
        /// The FileSystemEventArgs for the changing file.
        /// </param>
        private static void FileChanged(object source, FileSystemEventArgs e)
        {
            StyleCopTrace.In(source, e);
            Cache.Clear();
            StyleCopTrace.Out();
        }

        /// <summary>
        /// Called when the file renames.
        /// </summary>
        /// <param name="source">
        /// The source of the event.
        /// </param>
        /// <param name="e">
        /// The RenamedEventArgs for the changing file.
        /// </param>
        private static void OnRenamed(object source, RenamedEventArgs e)
        {
            StyleCopTrace.In(source, e);
            Cache.Clear();
            StyleCopTrace.Out();
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

            FileSystemWatcher watch = new FileSystemWatcher();
            string directoryName = Path.GetDirectoryName(path);
            watch.Path = directoryName;
            watch.Filter = Path.GetFileName(path);
            watch.Changed += FileChanged;
            watch.Created += FileChanged;
            watch.Deleted += FileChanged;
            watch.Renamed += OnRenamed;
            watch.EnableRaisingEvents = true;
            StyleCopTrace.Out();
        }

        #endregion
    }
}