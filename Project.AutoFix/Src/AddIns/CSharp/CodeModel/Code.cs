//-----------------------------------------------------------------------
// <copyright file="Code.cs">
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
namespace StyleCop.CSharp.CodeModel
{
    using System;
    using System.IO;

    /// <summary>
    /// Represents a C# source code stream to be translated into a document.
    /// </summary>
    internal class Code 
    {
        /// <summary>
        /// The source code.
        /// </summary>
        private TextReader source;

        /// <summary>
        /// The name of the source code.
        /// </summary>
        private string name;

        /// <summary>
        /// The path to the source code.
        /// </summary>
        private string path;

        /// <summary>
        /// Initializes a new instance of the Code class.
        /// </summary>
        /// <param name="source">The original source.</param>
        /// <param name="name">The name of the source.</param>
        /// <param name="path">The path to the source.</param>
        public Code(TextReader source, string name, string path)
        {
            Param.AssertNotNull(source, "source");
            Param.AssertValidString(name, "name");
            Param.AssertValidString(path, "path");

            this.source = source;
            this.name = name;
            this.path = path;
        }

        /// <summary>
        /// Initializes a new instance of the Code class.
        /// </summary>
        /// <param name="source">The original source.</param>
        /// <param name="name">The name of the source.</param>
        /// <param name="path">The path to the source.</param>
        public Code(string source, string name, string path)
        {
            Param.AssertNotNull(source, "source");
            Param.AssertValidString(name, "name");
            Param.AssertValidString(path, "path");

            this.source = new StringReader(source);
            this.name = name;
            this.path = path;
        }

        /// <summary>
        /// Gets the original source code.
        /// </summary>
        public TextReader Source
        {
            get
            {
                return this.source;
            }
        }

        /// <summary>
        /// Gets the path to the source.
        /// </summary>
        public string Path
        {
            get
            {
                return this.path;
            }
        }

        /// <summary>
        /// Gets the name of the source.
        /// </summary>
        public string Name
        {
            get
            {
                return this.name;
            }
        }
    }
}
