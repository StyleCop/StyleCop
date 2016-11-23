// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SourceFileListSettings.cs" company="https://github.com/StyleCop">
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
//   Represents a collection of named source files which has specific settings applied to them.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents a collection of named source files which has specific settings applied to them.
    /// </summary>
    public class SourceFileListSettings
    {
        #region Fields

        /// <summary>
        /// The collection of files in the file list.
        /// </summary>
        private readonly Dictionary<string, string> files = new Dictionary<string, string>();

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the SourceFileListSettings class.
        /// </summary>
        /// <param name="settings">
        /// The settings for this file list.
        /// </param>
        internal SourceFileListSettings(Settings settings)
        {
            Param.Ignore(settings);
            this.Settings = settings;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the custom settings for this file list.
        /// </summary>
        public Settings Settings { get; internal set; }

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

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Determines whether the given file exists within the file list.
        /// </summary>
        /// <param name="fileName">
        /// The name of the file.
        /// </param>
        /// <returns>
        /// true if the file exists; false otherwise.
        /// </returns>
        public bool ContainsFile(string fileName)
        {
            Param.Ignore(fileName);

            if (fileName == null)
            {
                return false;
            }

            return this.files.ContainsKey(fileName.ToUpperInvariant());
        }

        #endregion

        #region Methods

        /// <summary>
        /// Adds a file to the file list.
        /// </summary>
        /// <param name="fileName">
        /// The name of the file to add.
        /// </param>
        internal void AddFile(string fileName)
        {
            Param.AssertValidString(fileName, "fileName");

            string fileNameToUpper = fileName.ToUpperInvariant();
            if (!this.files.ContainsKey(fileNameToUpper))
            {
                this.files.Add(fileNameToUpper, fileName);
            }
        }

        #endregion
    }
}