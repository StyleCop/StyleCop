// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UpdateFileHeaderStyle.cs" company="http://stylecop.codeplex.com">
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
//   Enumeration to define the behavior for updating the file header.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.ReSharper.CodeCleanup
{
    using System.ComponentModel;

    /// <summary>
    /// Enumeration to define the behavior for updating the file header.
    /// </summary>
    public enum UpdateFileHeaderStyle
    {
        /// <summary>
        /// Do not change.
        /// </summary>
        [Description("Do not change")]
        Ignore, 

        /// <summary>
        /// Only insert if missing.
        /// </summary>
        [Description("Insert header if it's missing")]
        InsertMissing, 

        /// <summary>
        /// Replaces the copyright element completely.
        /// </summary>
        [Description("Replace copyright element completely")]
        ReplaceCopyrightElement, 

        /// <summary>
        /// Replace all.
        /// </summary>
        [Description("Replace entire header")]
        ReplaceAll
    }
}