// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProjectStatus.cs" company="https://github.com/StyleCop">
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
//   Keeps track of the analysis status for a single code project.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop
{
    /// <summary>
    /// Keeps track of the analysis status for a single code project.
    /// </summary>
    internal class ProjectStatus
    {
        #region Fields

        /// <summary>
        /// Indicates whether to ignore the cached results for all files in this project.
        /// </summary>
        private bool ignoreResultsCache;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets a value indicating whether to ignore the cached results for all source code 
        /// documents within this project.
        /// </summary>
        public bool IgnoreResultsCache
        {
            get
            {
                return this.ignoreResultsCache;
            }

            set
            {
                Param.Ignore(value);
                this.ignoreResultsCache = value;
            }
        }

        #endregion
    }
}