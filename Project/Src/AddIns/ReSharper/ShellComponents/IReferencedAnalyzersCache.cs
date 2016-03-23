// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IReferencedAnalyzersCache.cs" company="http://stylecop.codeplex.com">
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
//   Interface for referenced analyzers cache
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace StyleCop.ReSharper.ShellComponents
{
    using JetBrains.ProjectModel;

    /// <summary>
    /// Caches Roslyn analyzers referenced by Visual Studio 2015
    /// </summary>
    public interface IReferencedAnalyzersCache
    {
        /// <summary>
        /// Returns true if the specified analyzer is referenced
        /// </summary>
        /// <param name="project">
        /// The project that the analyzer is referenced in
        /// </param>
        /// <param name="analyzerName">
        /// The name of the analyzer assembly, minus the '.dll' suffix
        /// </param>
        /// <returns>Returns true if the analyzer is referenced in the given project</returns>
        bool IsAnalyzerReferenced(IProject project, string analyzerName);
    }

    /// <summary>
    /// Default analyzer reference cache for pre-Visual Studio 2015
    /// </summary>
    [SolutionComponent]
    public class PreRoslynReferencedAnalyzersCache : IReferencedAnalyzersCache
    {
        /// <summary>
        /// Returns true if the specified analyzer is referenced
        /// </summary>
        /// <param name="project">
        /// The project that the analyzer is referenced in
        /// </param>
        /// <param name="analyzerName">
        /// The name of the analyzer assembly, minus the '.dll' suffix
        /// </param>
        /// <returns>Returns true if the analyzer is referenced in the given project</returns>
        public virtual bool IsAnalyzerReferenced(IProject project, string analyzerName)
        {
            return false;
        }
    }
}