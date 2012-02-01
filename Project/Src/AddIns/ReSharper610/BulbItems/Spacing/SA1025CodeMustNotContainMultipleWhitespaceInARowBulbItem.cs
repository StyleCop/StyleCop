// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SA1025CodeMustNotContainMultipleWhitespaceInARowBulbItem.cs" company="http://stylecop.codeplex.com">
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
//   The s a 1025 code must not contain multiple whitespace in a row bulb item.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace StyleCop.ReSharper610.BulbItems.Spacing
{
    #region Using Directives

    using JetBrains.ProjectModel;
    using JetBrains.ReSharper.Psi.CSharp.Tree;
    using JetBrains.TextControl;

    using StyleCop.ReSharper610.BulbItems.Framework;
    using StyleCop.ReSharper610.CodeCleanup.Rules;
    using StyleCop.ReSharper610.Core;

    #endregion

    /// <summary>
    /// The s a 1025 code must not contain multiple whitespace in a row bulb item.
    /// </summary>
    public class SA1025CodeMustNotContainMultipleWhitespaceInARowBulbItem : V5BulbItemImpl
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
            Utils.FormatLineForTextControl(solution, textControl);

            var element = Utils.GetElementAtCaret(solution, textControl);
            var containingBlock = element.GetContainingNode<IBlock>(true);

            if (containingBlock != null)
            {
                new SpacingRules().CodeMustNotContainMultipleWhitespaceInARow(element);
            }
        }

        #endregion
    }
}