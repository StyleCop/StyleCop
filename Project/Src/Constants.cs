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
// --------------------------------------------------------------------------------------------------------------------

namespace StyleCop
{
    /// <summary>
    /// Defines the core constants.
    /// </summary>
    public static class Constants
    {
        #region Constants and Fields
        
        /// <summary>
        /// Name of the Product i.e. StyleCop.
        /// </summary>
        public const string ProductName = "StyleCop";

        /// <summary>
        /// The Major.Minor version number of the product a.b.
        /// </summary>
        public const string ProductVersionMajorMinor = "4.7";

        /// <summary>
        /// The full version number of the product a.b.c.d.
        /// </summary>
        public const string ProductVersionFull = "4.7.38.0";

        /// <summary>
        /// Name of the Product with the version i.e. StyleCop (4.7.x.y).
        /// </summary>
        public const string ProductNameWithVersion = ProductName + " (" + ProductVersionFull + ")";

        /// <summary>
        /// The name of the StyleCop assembly.
        /// </summary>
        public const string StyleCopAssemblyName = ProductName + ".dll";
        
        /// <summary>
        /// Name of the Vendor i.e. http://stylecop.codeplex.com/ .
        /// </summary>
        public const string Vendor = "http://stylecop.codeplex.com";

        #endregion
    }
}