//-----------------------------------------------------------------------
// <copyright file="GuidList.cs">
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
    using System;

    /// <summary>
    /// Guids defining components of the package.
    /// </summary>
    /// <remarks>The guids defined in this class must match those in guids.h.</remarks>
    internal static class GuidList
    {
        #region Public Constants

        /// <summary>
        /// The ID of the package in string form.
        /// </summary>
        public const string StyleCopPackageIdString = "629EB7CC-69C2-43AC-9BC9-482B0F810C4E";

        /// <summary>
        /// The ID of the package's command set in string form.
        /// </summary>
        public const string StyleCopCommandSetIdString = "CE99DB75-E6A6-41C9-9091-434390724FAC";

        #endregion Public Constants

        #region Public Static Readonly Fields

        /// <summary>
        /// The ID of the package's command set.
        /// </summary>
        public static readonly Guid StyleCopCommandSetId = new Guid(StyleCopCommandSetIdString);

        #endregion Public Static Readonly Fields
    }
}