// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StringBasedSourceCode.cs" company="http://stylecop.codeplex.com">
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
//   The string based source code.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.ReSharper710.Core
{
    #region Using Directives

    using System;
    using System.IO;

    #endregion

    /// <summary>
    /// The string based source code.
    /// </summary>
    internal class StringBasedSourceCode : SourceCode
    {
        #region Fields

        private readonly string fileType;

        private readonly string folder;

        private readonly string name;

        private readonly string path;

        private readonly string source;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="StringBasedSourceCode"/> class.
        /// </summary>
        /// <param name="project">
        /// The project.
        /// </param>
        /// <param name="parser">
        /// The parser.
        /// </param>
        /// <param name="path">
        /// The path.
        /// </param>
        /// <param name="source">
        /// The source.
        /// </param>
        public StringBasedSourceCode(CodeProject project, SourceParser parser, string path, string source)
            : base(project, parser)
        {
            this.source = source;

            this.path = path;

            // Strip out the name of the file.
            int index = path.LastIndexOf(@"\", StringComparison.Ordinal);
            if (-1 == index)
            {
                this.name = this.path;
            }
            else
            {
                this.name = path.Substring(index + 1, path.Length - index - 1);
                this.folder = path.Substring(0, index);

                if (this.folder != null)
                {
                    // Trim the path and convert it to lowercase characters
                    // so that we can do string matches and find other files and
                    // projects under the same path.
                    this.folder = CleanPath(this.folder);
                }
            }

            // Strip out the file extension.
            index = this.name.LastIndexOf(".", StringComparison.Ordinal);
            if (-1 == index)
            {
                this.fileType = string.Empty;
            }
            else
            {
                this.fileType = this.name.Substring(index + 1, this.name.Length - index - 1).ToUpperInvariant();
            }
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets a value indicating whether the source code exists.
        /// </summary>
        public override bool Exists
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Gets the name of the file.
        /// </summary>
        public override string Name
        {
            get
            {
                return this.name;
            }
        }

        /// <summary>
        /// Gets the path of the file.
        /// </summary>
        public override string Path
        {
            get
            {
                return this.path;
            }
        }

        /// <summary>
        /// Gets the TimeStamp of the file.
        /// </summary>
        public override DateTime TimeStamp
        {
            get
            {
                return DateTime.Now;
            }
        }

        /// <summary>
        /// Gets Type.
        /// </summary>
        public override string Type
        {
            get
            {
                return this.fileType;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The read.
        /// </summary>
        /// <returns>
        /// A TextReader instance.
        /// </returns>
        public override TextReader Read()
        {
            return new StringReader(this.source);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Cleans up the given path so that it can always be matched against other paths.
        /// </summary>
        /// <param name="path">
        /// The path to clean.
        /// </param>
        /// <returns>
        /// Returns the cleaned path.
        /// </returns>
        internal static string CleanPath(string path)
        {
            Param.Ignore(path);

            string cleanedPath = path;
            if (cleanedPath != null)
            {
                // Remove backslashes from the end of the path.
                while (cleanedPath.Length > 0 && cleanedPath[cleanedPath.Length - 1] == '\\')
                {
                    cleanedPath = cleanedPath.Substring(0, cleanedPath.Length - 1);
                }

                cleanedPath = cleanedPath.ToUpperInvariant();
            }

            return cleanedPath;
        }

        #endregion
    }
}