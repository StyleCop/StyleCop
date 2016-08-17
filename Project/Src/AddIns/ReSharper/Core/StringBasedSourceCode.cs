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
namespace StyleCop.ReSharper.Core
{
    using System;
    using System.IO;

    /// <summary>
    /// The string based source code.
    /// </summary>
    internal class StringBasedSourceCode : SourceCode
    {
        private readonly string fileType;

        private readonly string name;

        private readonly string path;

        private readonly string source;

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
    }
}