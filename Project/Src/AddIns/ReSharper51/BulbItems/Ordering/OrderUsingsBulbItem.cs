// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OrderUsingsBulbItem.cs" company="http://stylecop.codeplex.com">
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
//   BulbItem - OrderUsingsBulbItem : Qualifies all usings, the orders them, groups them and removes duplicates.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace StyleCop.ReSharper51.BulbItems.Ordering
{
    #region Using Directives

    using JetBrains.ProjectModel;
    using JetBrains.TextControl;

    using StyleCop.ReSharper51.BulbItems.Framework;
    using StyleCop.ReSharper51.CodeCleanup.Options;
    using StyleCop.ReSharper51.CodeCleanup.Rules;
    using StyleCop.ReSharper51.CodeCleanup.Styles;
    using StyleCop.ReSharper51.Core;

    #endregion

    /// <summary>
    /// BulbItem - OrderUsingsBulbItem : Qualifies all usings, the orders them, groups them and removes duplicates.
    /// </summary>
    public class OrderUsingsBulbItem : V5BulbItemImpl
    {
        #region Public Methods

        /// <summary>
        /// The execute transaction inner.
        /// </summary>
        /// <param name="solution">
        /// The solution.
        /// </param>
        /// <param name="textControl">
        /// The text control.
        /// </param>
        public override void ExecuteTransactionInner(ISolution solution, ITextControl textControl)
        {
            var file = Utils.GetCSharpFile(solution, textControl);

            var options = new OrderingOptions { AlphabeticalUsingDirectives = AlphabeticalUsingsStyle.Alphabetical, ExpandUsingDirectives = ExpandUsingsStyle.FullyQualify };

            // Fixes SA1208, SA1209, SA1210, SA1211
            new OrderingRules().Execute(options, file);
        }

        #endregion
    }
}