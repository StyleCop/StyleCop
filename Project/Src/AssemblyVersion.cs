// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AssemblyVersion.cs" company="http://stylecop.codeplex.com">
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
//   AssemblyVersion.cs
// </summary>
// --------------------------------------------------------------------------------------------------------------------

#region Using Directives

using System.Reflection;

#endregion

[assembly: AssemblyVersion("4.7.1000.0")] // Fixed at 4.7.1000.0 until version 5.
[assembly: AssemblyFileVersion("4.7.16.0")]

namespace StyleCop
{
    /// <summary>
    /// Defines the core constants.
    /// </summary>
    public static class Constants
    {
        #region Constants and Fields
        
        /// <summary>
        /// Name of the Plugin.
        /// </summary>
        public const string ProductName = "StyleCop";

        /// <summary>
        /// Name of the Plugin.
        /// </summary>
        public const string ProductNameWithVersion = "StyleCop (4.7.16.0)";
        
        #endregion
    }
}