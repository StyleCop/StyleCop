// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OrderingOptions.cs" company="http://stylecop.codeplex.com">
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
//   Defines options for Ordering.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.ReSharper800.CodeCleanup.Options
{
    #region Using Directives

    using ReSharperBase.CodeCleanup.Options;
    using ReSharperBase.CodeCleanup.Styles;

    using StyleCop.ReSharper800.Core;

    #endregion

    /// <summary>
    /// Defines options for Ordering.
    /// </summary>
    public class OrderingOptions : OrderingOptionsBase
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the OrderingOptions class.
        /// </summary>
        public OrderingOptions()
        {
            this.InitPropertiesDefaults(Utils.GetStyleCopSettings());
            this.AlphabeticalUsingDirectives = AlphabeticalUsingsStyle.Alphabetical;
            this.ExpandUsingDirectives = ExpandUsingsStyle.FullyQualify;
        }

        #endregion
    }
}