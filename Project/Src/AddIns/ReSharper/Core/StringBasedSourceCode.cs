//-----------------------------------------------------------------------
// <copyright file="">
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

namespace StyleCop.ReSharper.Core
{
    #region Using Directives

    using System;
    using System.IO;

    using StyleCop;

    #endregion

    internal class StringBasedSourceCode : SourceCode
    {
        #region Constants and Fields

        private readonly string fileType;

        private readonly string folder;

        private readonly string name;

        private readonly string path;

        private readonly string source;

        #endregion

        public StringBasedSourceCode(CodeProject project, SourceParser parser, string path, string source)
            : base(project, parser)
        {
            this.source = source;

            this.path = path;

            // Strip out the name of the file.
            var index = path.LastIndexOf(@"\", StringComparison.Ordinal);
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

        #region Properties

        public override bool Exists
        {
            get
            {
                return true;
            }
        }

        public override string Name
        {
            get
            {
                return this.name;
            }
        }

        public override string Path
        {
            get
            {
                return this.path;
            }
        }

        public override DateTime TimeStamp
        {
            get
            {
                return DateTime.Now;
            }
        }

        public override string Type
        {
            get
            {
                return this.fileType;
            }
        }

        #endregion

        public override TextReader Read()
        {
            return new StringReader(this.source);
        }

        /// <summary>
        /// Cleans up the given path so that it can always be matched against other paths.
        /// </summary>
        /// <param name="path">The path to clean.</param>
        /// <returns>Returns the cleaned path.</returns>
        internal static string CleanPath(string path)
        {
            Param.Ignore(path);

            var cleanedPath = path;
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
    }
}