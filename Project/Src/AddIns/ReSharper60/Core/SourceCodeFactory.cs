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

namespace StyleCop.ReSharper60.Core
{
    #region Using Directives

    using StyleCop.Diagnostics;

    #endregion

    /// <summary>
    /// The source code factory.
    /// </summary>
    public class SourceCodeFactory
    {
        #region Public Methods

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
        /// A new StringBasedSourcecode object.
        /// </returns>
        public SourceCode Create(string path, CodeProject project, SourceParser parser, object context)
        {
            StyleCopTrace.In();

            var source = (string)context;

            StyleCopTrace.Out();

            return new StringBasedSourceCode(project, parser, path, source);
        }

        #endregion
    }
}