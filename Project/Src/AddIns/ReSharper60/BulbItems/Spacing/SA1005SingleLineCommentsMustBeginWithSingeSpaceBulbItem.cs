// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SA1005SingleLineCommentsMustBeginWithSingeSpaceBulbItem.cs" company="http://stylecop.codeplex.com">
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
//   The s a 1005 single line comments must begin with singe space.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace StyleCop.ReSharper60.BulbItems.Spacing
{
    #region Using Directives

    using JetBrains.ProjectModel;
    using JetBrains.ReSharper.Psi.CSharp.Tree;
    using JetBrains.TextControl;

    using StyleCop.ReSharper60.BulbItems.Framework;
    using StyleCop.ReSharper60.CodeCleanup.Rules;
    using StyleCop.ReSharper60.Core;

    #endregion

    /// <summary>
    /// The s a 1005 single line comments must begin with singe space.
    /// </summary>
    public class SA1005SingleLineCommentsMustBeginWithSingeSpaceBulbItem : V5BulbItemImpl
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
                new SpacingRules().SingleLineCommentsMustBeginWithSingleSpace(element);
            }
        }

        #endregion
    }
}