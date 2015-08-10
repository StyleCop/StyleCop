// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DocumentationOptions.cs" company="http://stylecop.codeplex.com">
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
//   Defines options for DocumentationOptions.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.ReSharper611.CodeCleanup.Options
{
    #region Using Directives

    using ReSharperBase.CodeCleanup.Options;
    using ReSharperBase.CodeCleanup.Styles;

    using StyleCop.ReSharper611.Core;

    #endregion

    /// <summary>
    /// Defines options for DocumentationOptions.
    /// </summary>
    public class DocumentationOptions : DocumentationOptionsBase
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the DocumentationOptions class.
        /// </summary>
        public DocumentationOptions()
        {
            this.InitPropertiesDefaults(Utils.GetStyleCopSettings());
            this.SA1633SA1641UpdateFileHeader = this.IsFileHeaderSettingDisabled ? UpdateFileHeaderStyle.Ignore : UpdateFileHeaderStyle.ReplaceCopyrightElement;
        }

        #endregion
    }
}