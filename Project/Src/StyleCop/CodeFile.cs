//-----------------------------------------------------------------------
// <copyright file="CodeFile.cs">
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
    using System.IO;
    using System.Security;
    using System.Text;

    /// <summary>
    /// Describes a source code file on disk.
    /// </summary>
    public class CodeFile : SourceCode
    {
        #region Private Fields

        /// <summary>
        /// The path to the file.
        /// </summary>
        private string path;

        /// <summary>
        /// The name of the file.
        /// </summary>
        private string name;

        /// <summary>
        /// The file type extension of this file.
        /// </summary>
        private string fileType;

        /// <summary>
        /// The folder that the file appears in.
        /// </summary>
        private string folder;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the CodeFile class.
        /// </summary>
        /// <param name="path">The path to the code file.</param>
        /// <param name="project">The project that contains this file.</param>
        /// <param name="parser">The parser that created this file object.</param>
        public CodeFile(string path, CodeProject project, SourceParser parser) 
            : this(path, project, parser, null)
        {
            Param.Ignore(path, project, parser);
        }

        /// <summary>
        /// Initializes a new instance of the CodeFile class.
        /// </summary>
        /// <param name="path">The path to the code file.</param>
        /// <param name="project">The project that contains this file.</param>
        /// <param name="parser">The parser that created this file object.</param>
        /// <param name="configurations">The list of configurations for the file.</param>
        public CodeFile(string path, CodeProject project, SourceParser parser, IEnumerable<Configuration> configurations)
            : base(project, parser, configurations)
        {
            Param.RequireNotNull(path, "path");
            Param.RequireNotNull(project, "project");
            Param.RequireNotNull(parser, "parser");
            Param.Ignore(configurations);

            this.path = path;

            // If this is not a full path, then we need to add the current directory.
            if (!path.StartsWith(@"\\", StringComparison.Ordinal) && path.Length >= 2 && path[1] != ':')
            {
                // Get the current directory. Remove the trailing slash if it exists.
                string directory = Directory.GetCurrentDirectory();
                if (directory.EndsWith(@"\", StringComparison.Ordinal))
                {
                    directory = directory.Substring(0, directory.Length - 1);
                }

                // Check whether the path starts with a single slash or not.
                if (path.StartsWith(@"\", StringComparison.Ordinal))
                {
                    // Prepend the drive letter.
                    string newPath = directory.Substring(0, 2) + path;
                    path = newPath;
                }
                else
                {
                    // Prepend the current directory.
                    string newPath = directory + @"\" + path;
                    path = newPath;
                }
            }

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
                    this.folder = StyleCopCore.CleanPath(this.folder);
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

        #endregion public Constructors

        #region Public Override Properties

        /// <summary>
        /// Gets the file name.
        /// </summary>
        public override string Name
        {
            get
            {
                return this.name;
            }
        }

        /// <summary>
        /// Gets the path to the file.
        /// </summary>
        public override string Path
        {
            get
            {
                return this.path;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the source code document currently exists and is accessible.
        /// </summary>
        public override bool Exists
        {
            get
            {
                return !string.IsNullOrEmpty(this.path) && File.Exists(this.path);
            }
        }

        /// <summary>
        /// Gets the time that the source code was last edited or updated.
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
        /// Gets the code type identifier.
        /// </summary>
        /// <remarks>This is eqivalent to the file extension.</remarks>
        public override string Type
        {
            get
            {
                return this.fileType;
            }
        }

        #endregion Public Override Properties

        #region Public Properties

        /// <summary>
        /// Gets the path to the folder that contains this file.
        /// </summary>
        public string Folder
        {
            get
            {
                return this.folder;
            }
        }

        /// <summary>
        /// Gets the full path name of the file, spaced by underscores.
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

        #endregion Public Properties

        #region Public Override Methods

        /// <summary>
        /// Reads the contents of the source code into a TextReader.
        /// </summary>
        /// <returns>Returns the TextReader containing the source code.</returns>
        public override TextReader Read()
        {
            if (this.Exists)
            {
                try
                {
                    // Read the file from the disk.
                    // Using the StreamReader to auto-detect the Encoding was failing. Internally the StreamReader defaults to UTF8 until you actually
                    // read from it. We now detect it ourselves.
                    Encoding encoding = GetFileEncoding(this.path);
                    return new StreamReader(this.path, encoding);
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

        /// <summary>
        /// Detects the encoding used by the file at the path provided.
        /// </summary>
        /// <param name="path">A path to a file.</param>
        /// <returns>An Encoding of the file passed in.</returns>
        private static Encoding GetFileEncoding(string path)
        {
            Param.AssertNotNull(path, "path");

            var encoding = Encoding.Default;

            var buffer = new byte[5];
            var file = new FileStream(path, FileMode.Open);
            file.Read(buffer, 0, 5);
            file.Close();

            if (buffer[0] == 0xef && buffer[1] == 0xbb && buffer[2] == 0xbf)
            {
                encoding = Encoding.UTF8;
            }
            else if (buffer[0] == 0xfe && buffer[1] == 0xff)
            {
                encoding = Encoding.Unicode;
            }
            else if (buffer[0] == 0 && buffer[1] == 0 && buffer[2] == 0xfe && buffer[3] == 0xff)
            {
                encoding = Encoding.UTF32;
            }
            else if (buffer[0] == 0x2b && buffer[1] == 0x2f && buffer[2] == 0x76)
            {
                encoding = Encoding.UTF7;
            }

            return encoding;
        }

        #endregion Public Override Methods
    }
}
