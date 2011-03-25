//-----------------------------------------------------------------------
// <copyright file="">
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

namespace StyleCop.ReSharper.Core
{
    #region Using Directives

    using System;
    using System.Collections.Generic;
    using System.IO;

    using Microsoft.Win32;

    using StyleCop.ReSharper.Properties;

    #endregion

    public static class StyleCopLocator
    {
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
        
        /// <summary>
        /// Gets the StyleCop install location from the registry. This reg key is created by StyleCop 4.5 during install.
        /// </summary>
        /// <returns></returns>
        private static string RetrieveFromRegistry()
        {
            var subKey = @"SOFTWARE\CodePlex\StyleCop";
            var key = "InstallLocation";

            return Registry.LocalMachine.OpenSubKey(subKey).GetValue(key) as string;
        }
    }
}