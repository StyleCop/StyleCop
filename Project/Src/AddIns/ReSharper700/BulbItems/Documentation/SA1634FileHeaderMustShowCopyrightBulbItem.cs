// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SA1634FileHeaderMustShowCopyrightBulbItem.cs" company="http://stylecop.codeplex.com">
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
//   BulbItem - SA1634FileHeaderMustShowCopyrightBulbItem.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace StyleCop.ReSharper700.BulbItems.Documentation
{
    #region Using Directives

    using JetBrains.ProjectModel;
    using JetBrains.TextControl;

    using StyleCop.ReSharper700.BulbItems.Framework;
    using StyleCop.ReSharper700.CodeCleanup.Rules;
    using StyleCop.ReSharper700.Core;

    #endregion

    /// <summary>
    /// BulbItem - SA1634FileHeaderMustShowCopyrightBulbItem.
    /// </summary>
    internal class SA1634FileHeaderMustShowCopyrightBulbItem : V5BulbItemImpl
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

            new DocumentationRules().InsertCopyrightText(file);
        }

        #endregion
    }
}