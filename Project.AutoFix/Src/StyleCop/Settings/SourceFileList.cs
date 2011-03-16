//-----------------------------------------------------------------------
// <copyright file="SourceFileList.cs">
//   MS-PL
// </copyright>
// <license>
//   This source code is subject to terms and conditions of the Microsoft 
//   Public License. A copy of the license can be found in the License.html 
//   file at the root of this distribution. 
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
    /// Represents a collection of named source files which has specific settings applied to them.
    /// </summary>
    public class SourceFileListSettings
    {
        /// <summary>
        /// The custom settings for this file list.
        /// </summary>
        private Settings settings;

        /// <summary>
        /// The collection of files in the file list.
        /// </summary>
        private Dictionary<string, string> files = new Dictionary<string, string>();

        /// <summary>
        /// Initializes a new instance of the SourceFileListSettings class.
        /// </summary>
        /// <param name="settings">The settings for this file list.</param>
        internal SourceFileListSettings(Settings settings)
        {
            Param.Ignore(settings);
            this.settings = settings;
        }

        /// <summary>
        /// Gets the custom settings for this file list.
        /// </summary>
        public Settings Settings
        {
            get
            {
                return this.settings;
            }

            internal set
            {
                this.settings = value;
            }
        }

        /// <summary>
        /// Gets the collection of files in the file list.
        /// </summary>
        public IEnumerable<string> SourceFiles
        {
            get
            {
                return this.files.Values;
            }
        }

        /// <summary>
        /// Determines whether the given file exists within the file list.
        /// </summary>
        /// <param name="fileName">The name of the file.</param>
        /// <returns>true if the file exists; false otherwise.</returns>
        public bool ContainsFile(string fileName)
        {
            Param.Ignore(fileName);

            if (fileName == null)
            {
                return false;
            }

            return this.files.ContainsKey(fileName.ToUpperInvariant());
        }

        /// <summary>
        /// Adds a file to the file list.
        /// </summary>
        /// <param name="fileName">The name of the file to add.</param>
        internal void AddFile(string fileName)
        {
            Param.AssertValidString(fileName, "fileName");

            string fileNameToUpper = fileName.ToUpperInvariant();
            if (!this.files.ContainsKey(fileNameToUpper))
            {
                this.files.Add(fileNameToUpper, fileName);
            }
        }
    }
}
