//--------------------------------------------------------------------------
// <copyright file="AnalysisType.cs">
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
namespace StyleCop.VisualStudio
{
    /// <summary>
    /// Different analysis types.
    /// </summary>
    internal enum AnalysisType
    {
        /// <summary>
        /// Analyze all files in the solution.
        /// </summary>
        Solution,

        /// <summary>
        /// Analyzes the files in the selected project.
        /// </summary>
        Project,

        /// <summary>
        /// Analyze the given file list.
        /// </summary>
        File,

        /// <summary>
        /// Analyzes a selected item in the solution explorer.
        /// </summary>
        Item,

        /// <summary>
        /// Analyzes a selected folder in the solution explorer.
        /// </summary>
        Folder
    }
}