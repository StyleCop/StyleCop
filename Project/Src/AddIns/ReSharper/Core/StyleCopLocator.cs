// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StyleCopLocator.cs" company="http://stylecop.codeplex.com">
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
//   The style cop locator.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace StyleCop.ReSharper.Core
{
    #region Using Directives

    using System.IO;

    using Microsoft.Win32;

    #endregion

    /// <summary>
    /// The style cop locator.
    /// </summary>
    public static class StyleCopLocator
    {
        #region Public Methods

        /// <summary>
        /// Gets the StyleCop assembly path.
        /// </summary>
        /// <returns>
        /// The path to the StyleCop assembly.
        /// </returns>
        public static string GetStyleCopPath()
        {
            var directory = RetrieveFromRegistry();

            return Path.Combine(directory, StyleCopReferenceHelper.StyleCopAssemblyName);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the StyleCop install location from the registry. This reg key is created by StyleCop 4.5 during install.
        /// </summary>
        /// <returns>
        /// The retrieve from registry.
        /// </returns>
        private static string RetrieveFromRegistry()
        {
            var subKey = @"SOFTWARE\CodePlex\StyleCop";
            var key = "InstallLocation";

            return Registry.LocalMachine.OpenSubKey(subKey).GetValue(key) as string;
        }

        #endregion
    }
}