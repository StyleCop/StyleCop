//-----------------------------------------------------------------------
// <copyright file="VisualStudioCodeFile.cs">
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
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Security;
    using EnvDTE;

    /// <summary>
    /// Describes a source code file on disk.
    /// </summary>
    internal class VisualStudioCodeFile : CodeFile
    {
        /// <summary>
        /// The Visual Studio IDE document mapping to this file.
        /// </summary>
        private Document document;

        /// <summary>
        /// The Visual Studio IDE project item mapping to this file.
        /// </summary>
        private ProjectItem projectItem;

        /// <summary>
        /// Initializes a new instance of the VisualStudioCodeFile class.
        /// </summary>
        /// <param name="path">The path to the code file.</param>
        /// <param name="project">The project that contains this file.</param>
        /// <param name="parser">The parser that created this file object.</param>
        internal VisualStudioCodeFile(string path, CodeProject project, SourceParser parser)
            : base(path, project, parser, null)
        {
            Param.Ignore(path, project, parser);
        }

        /// <summary>
        /// Initializes a new instance of the VisualStudioCodeFile class.
        /// </summary>
        /// <param name="path">The path to the code file.</param>
        /// <param name="project">The project that contains this file.</param>
        /// <param name="parser">The parser that created this file object.</param>
        /// <param name="document">The Visual Studio IDE document mapping to this file.</param>
        internal VisualStudioCodeFile(string path, CodeProject project, SourceParser parser, Document document)
            : base(path, project, parser, null)
        {
            Param.Ignore(path, project, parser, document);
            this.document = document;
        }

        /// <summary>
        /// Initializes a new instance of the VisualStudioCodeFile class.
        /// </summary>
        /// <param name="path">The path to the code file.</param>
        /// <param name="project">The project that contains this file.</param>
        /// <param name="parser">The parser that created this file object.</param>
        /// <param name="projectItem">The Visual Studio IDE project item mapping to this file.</param>
        internal VisualStudioCodeFile(string path, CodeProject project, SourceParser parser, ProjectItem projectItem)
            : base(path, project, parser, null)
        {
            Param.Ignore(path, project, parser, projectItem);
            this.projectItem = projectItem;
        }

        /// <summary>
        /// Initializes a new instance of the VisualStudioCodeFile class.
        /// </summary>
        /// <param name="path">The path to the code file.</param>
        /// <param name="project">The project that contains this file.</param>
        /// <param name="parser">The parser that created this file object.</param>
        /// <param name="configurations">The list of configurations for the file.</param>
        internal VisualStudioCodeFile(string path, CodeProject project, SourceParser parser, IEnumerable<Configuration> configurations)
            : base(path, project, parser, configurations)
        {
            Param.AssertNotNull(path, "path");
            Param.AssertNotNull(project, "project");
            Param.AssertNotNull(parser, "parser");
            Param.Ignore(configurations);
        }

        /// <summary>
        /// Initializes a new instance of the VisualStudioCodeFile class.
        /// </summary>
        /// <param name="path">The path to the code file.</param>
        /// <param name="project">The project that contains this file.</param>
        /// <param name="parser">The parser that created this file object.</param>
        /// <param name="document">The Visual Studio IDE document mapping to this file.</param>
        /// <param name="configurations">The list of configurations for the file.</param>
        internal VisualStudioCodeFile(string path, CodeProject project, SourceParser parser, Document document, IEnumerable<Configuration> configurations)
            : base(path, project, parser, configurations)
        {
            Param.AssertNotNull(path, "path");
            Param.AssertNotNull(project, "project");
            Param.AssertNotNull(parser, "parser");
            Param.Ignore(document);
            Param.Ignore(configurations);

            this.document = document;
        }

        /// <summary>
        /// Initializes a new instance of the VisualStudioCodeFile class.
        /// </summary>
        /// <param name="path">The path to the code file.</param>
        /// <param name="project">The project that contains this file.</param>
        /// <param name="parser">The parser that created this file object.</param>
        /// <param name="projectItem">The Visual Studio IDE project item mapping to this file.</param>
        /// <param name="configurations">The list of configurations for the file.</param>
        internal VisualStudioCodeFile(string path, CodeProject project, SourceParser parser, ProjectItem projectItem, IEnumerable<Configuration> configurations)
            : base(path, project, parser, configurations)
        {
            Param.AssertNotNull(path, "path");
            Param.AssertNotNull(project, "project");
            Param.AssertNotNull(parser, "parser");
            Param.Ignore(projectItem);
            Param.Ignore(configurations);

            this.projectItem = projectItem;
        }

        /// <summary>
        /// Reads the contents of the source code into a TextReader.
        /// </summary>
        /// <returns>Returns the TextReader containing the source code.</returns>
        public override TextReader Read()
        {
            return base.Read();
        }

        /// <summary>
        /// Writes the final document back to the source.
        /// </summary>
        /// <param name="document">The document to write.</param>
        /// <param name="exception">Returns an exception if the write operation fails.</param>
        /// <returns>Returns true if the document was written successfully; false otherwise.</returns>
        public override bool Write(ICodeDocument document, out Exception exception)
        {
            Param.AssertNotNull(document, "document");

            exception = null;
            Document d = this.document;

            if (d == null)
            {
                if (this.projectItem != null)
                {
                    this.projectItem.Open(Constants.vsViewKindCode);
                    d = this.projectItem.Document;
                }
            }

            if (d != null)
            {
                try
                {
                    StringWriter writer = new StringWriter();
                    document.Write(writer);

                    TextDocument td = (TextDocument)d.Object("TextDocument");
                    EditPoint edit = td.StartPoint.CreateEditPoint();
                    edit.ReplaceText(td.EndPoint, writer.ToString(), (int)vsEPReplaceTextOptions.vsEPReplaceTextKeepMarkers);
                    return true;
                }
                catch (COMException ex)
                {
                    exception = ex;
                    return false;
                }
            }
            else
            {
                return base.Write(document, out exception);
            }
        }
    }
}
