// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Constants.cs" company="http://stylecop.codeplex.com">
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
//   Defines the core settings and value for the plugin.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace StyleCop.ReSharper611.Properties
{
    /// <summary>
    /// Defines the core settings and value for the plugin.
    /// </summary>
    public static class Constants
    {
        #region Constants and Fields

        /// <summary>
        /// Long description of the Plugin.
        /// </summary>
        public const string DescriptionLong =
            "R# plugin for StyleCop. This plugin allows StyleCop to be run as you type, generating real-time syntax highlighting of violations. It also provides a series of Quick-Fixes and Code Clean Up Modules to help automatically fix violations. See http://stylecop.codeplex.com for more info.";

        /// <summary>
        /// Short description of the plugin.
        /// </summary>
        public const string DescriptionShort = "R# plugin for StyleCop";

        /// <summary>
        /// Name of the Plugin.
        /// </summary>
        public const string ProductName = "StyleCop";
        
        /// <summary>
        /// Name of the Vendor of the Plugin.
        /// </summary>
        public const string Vendor = "http://stylecop.codeplex.com";

        #endregion
    }
}