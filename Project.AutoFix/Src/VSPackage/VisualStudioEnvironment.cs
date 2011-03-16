//-----------------------------------------------------------------------
// <copyright file="VisualStudioEnvironment.cs">
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
    using System.Reflection;
    using System.Security;
    using System.Xml;
    using EnvDTE;

    /// <summary>
    /// An environment which is running inside the Visual Studio IDE.
    /// </summary>
    internal class VisualStudioEnvironment : FileBasedEnvironment
    {
        /// <summary>
        /// Initializes a new instance of the VisualStudioEnvironment class.
        /// </summary>
        internal VisualStudioEnvironment()
        {
        }

        /// <summary>
        /// Creates a new <see cref="CodeFile"/> instance with the given values.
        /// </summary>
        /// <param name="path">The path to the code file.</param>
        /// <param name="project">The project that contains this file.</param>
        /// <param name="parser">The parser that created this file object.</param>
        /// <param name="context">Optional context information.</param>
        /// <returns>Returns the newly created <see cref="CodeFile"/>.</returns>
        protected override CodeFile CreateCodeFile(string path, CodeProject project, SourceParser parser, object context)
        {
            Param.Ignore(path, project, parser, context);

            ProjectItem p = context as ProjectItem;
            if (p != null)
            {
                return new VisualStudioCodeFile(path, project, parser, p);
            }

            Document d = context as Document;
            if (d != null)
            {
                return new VisualStudioCodeFile(path, project, parser, d);
            }

            return new VisualStudioCodeFile(path, project, parser);
        }
    }
}
