// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SourceCodeFactory.cs" company="http://stylecop.codeplex.com">
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
//   The source code factory.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.ReSharper.Core
{
    using StyleCop.Diagnostics;

    /// <summary>
    /// The source code factory.
    /// </summary>
    public class SourceCodeFactory
    {
        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="path">
        /// The path.
        /// </param>
        /// <param name="project">
        /// The project.
        /// </param>
        /// <param name="parser">
        /// The parser.
        /// </param>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <returns>
        /// A new StringBasedSourceCode object.
        /// </returns>
        public SourceCode Create(string path, CodeProject project, SourceParser parser, object context)
        {
            StyleCopTrace.In();

            string source = (string)context;

            SourceCode sourceCode = source == null ? (SourceCode)new CodeFile(path, project, parser) : new StringBasedSourceCode(project, parser, path, source);

            return StyleCopTrace.Out(sourceCode);
        }
    }
}