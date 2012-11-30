// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExpandUsingsStyle.cs" company="http://stylecop.codeplex.com">
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
//   Enumeration to define the behavior of Usings declarations.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.ReSharper513.CodeCleanup.Styles
{
    #region Using Directives

    using System.ComponentModel;

    #endregion

    /// <summary>
    /// Enumeration to define the behavior of Usings declarations.
    /// </summary>
    public enum ExpandUsingsStyle
    {
        /// <summary>
        /// Do not change.
        /// </summary>
        [Description("Do not change")]
        Ignore = 0, 

        /// <summary>
        /// Fully Qualify.
        /// </summary>
        [Description("Fully qualify")]
        FullyQualify = 1, 
    }
}