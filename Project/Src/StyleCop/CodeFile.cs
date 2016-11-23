// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CodeFile.cs" company="https://github.com/StyleCop">
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
//   Describes a source code file on disk.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Security;
    using System.Text;

    /// <summary>
    ///   Describes a source code file on disk.
    /// </summary>
    public class CodeFile : SourceCode
    {
        #region Fields

        /// <summary>
        ///   The file type extension of this file.
        /// </summary>
        private readonly string fileType;

        /// <summary>
        ///   The folder that the file appears in.
        /// </summary>
        private readonly string folder;

        /// <summary>
        ///   The name of the file.
        /// </summary>
        private readonly string name;

        /// <summary>
        ///   The path to the file.
        /// </summary>
        private readonly string path;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the CodeFile class.
        /// </summary>
        /// <param name="path">
        /// The path to the code file. 
        /// </param>
        /// <param name="project">
        /// The project that contains this file. 
        /// </param>
        /// <param name="parser">
        /// The parser that created this file object. 
        /// </param>
        public CodeFile(string path, CodeProject project, SourceParser parser)
            : this(path, project, parser, null)
        {
            Param.Ignore(path, project, parser);
        }

        /// <summary>
        /// Initializes a new instance of the CodeFile class.
        /// </summary>
        /// <param name="path">
        /// The path to the code file. 
        /// </param>
        /// <param name="project">
        /// The project that contains this file. 
        /// </param>
        /// <param name="parser">
        /// The parser that created this file object. 
        /// </param>
        /// <param name="configurations">
        /// The list of configurations for the file. 
        /// </param>
        public CodeFile(string path, CodeProject project, SourceParser parser, IEnumerable<Configuration> configurations)
            : base(project, parser, configurations)
        {
            Param.RequireNotNull(path, "path");
            Param.RequireNotNull(project, "project");
            Param.RequireNotNull(parser, "parser");
            Param.Ignore(configurations);

            // If this is not a full path, then we need to add the current directory.
            if (!path.StartsWith(@"\\", StringComparison.Ordinal) && path.Length >= 2 && path[1] != ':')
            {
                path = System.IO.Path.GetFullPath(path);
            }

            // BugFix 6777 - Update the path field after correcting the local path variable
            this.path = path;
            this.name = System.IO.Path.GetFileName(path);
            this.folder = StyleCopCore.CleanPath(System.IO.Path.GetDirectoryName(path));

            // Strip out the file extension.
            this.fileType = System.IO.Path.GetExtension(this.name).ToUpperInvariant();
            if (this.fileType.Length > 0)
            {
                this.fileType = this.fileType.Substring(1);
            }
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///   Gets a value indicating whether the source code document currently exists and is accessible.
        /// </summary>
        public override bool Exists
        {
            get
            {
                return !string.IsNullOrEmpty(this.path) && File.Exists(this.path);
            }
        }

        /// <summary>
        ///   Gets the path to the folder that contains this file.
        /// </summary>
        public string Folder
        {
            get
            {
                return this.folder;
            }
        }

        /// <summary>
        ///   Gets the full path name of the file, spaced by underscores.
        /// </summary>
        public string FullPathName
        {
            get
            {
                char[] fullPathName = this.name.ToCharArray();
                for (int i = 0; i < fullPathName.Length; ++i)
                {
                    if (fullPathName[i] == '\\' || fullPathName[i] == '.' || fullPathName[i] == ':')
                    {
                        fullPathName[i] = '_';
                    }
                }

                return new string(fullPathName);
            }
        }

        /// <summary>
        ///   Gets the file name.
        /// </summary>
        public override string Name
        {
            get
            {
                return this.name;
            }
        }

        /// <summary>
        ///   Gets the path to the file.
        /// </summary>
        public override string Path
        {
            get
            {
                return this.path;
            }
        }

        /// <summary>
        ///   Gets the time that the source code was last edited or updated.
        /// </summary>
        public override DateTime TimeStamp
        {
            get
            {
                try
                {
                    if (this.Exists)
                    {
                        return File.GetLastWriteTime(this.path);
                    }
                }
                catch (UnauthorizedAccessException)
                {
                }
                catch (SecurityException)
                {
                }
                catch (IOException)
                {
                }

                return new DateTime();
            }
        }

        /// <summary>
        ///   Gets the code type identifier.
        /// </summary>
        /// <remarks>
        ///   This is equivalent to the file extension.
        /// </remarks>
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
        /// Reads the contents of the source code into a TextReader.
        /// </summary>
        /// <returns>
        /// Returns the TextReader containing the source code.
        /// </returns>
        public override TextReader Read()
        {
            if (this.Exists)
            {
                try
                {
                    // Read the file from the disk.
                    // Using the StreamReader to auto-detect the Encoding was failing. Internally the StreamReader defaults to UTF8 until you actually
                    // read from it. We now detect it ourselves.
                    Encoding encoding = Utils.GetFileEncoding(this.path);
                    return new StreamReader(File.OpenRead(this.path), encoding);
                }
                catch (UnauthorizedAccessException)
                {
                }
                catch (IOException)
                {
                }
            }

            return null;
        }

        #endregion
    }
}