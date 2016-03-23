// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FormatLineBulbItem.cs" company="http://stylecop.codeplex.com">
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
//   QuickFix action which formats multiple statements on a single line.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace StyleCop.ReSharper.BulbItems.Readability
{
    using JetBrains.DocumentModel;
    using JetBrains.ProjectModel;
    using JetBrains.ReSharper.Psi.CSharp.Tree;
    using JetBrains.ReSharper.Psi.Tree;
    using JetBrains.TextControl;

    using StyleCop.ReSharper.BulbItems.Framework;
    using StyleCop.ReSharper.CodeCleanup.Rules;
    using StyleCop.ReSharper.Core;

    /// <summary>
    /// QuickFix action which formats multiple statements on a single line.
    /// </summary>
    public class FormatLineBulbItem : V5BulbItemImpl
    {
        /// <summary>
        /// Formats the current line using the settings as defined in ReSharper &gt; Option &gt; Languages &gt; Common &gt; Code Style Sharing.
        /// </summary>
        /// <param name="solution">
        /// Current Solution.
        /// </param>
        /// <param name="textControl">
        /// Current Text Control.
        /// </param>
        public override void ExecuteTransactionInner(ISolution solution, ITextControl textControl)
        {
            JetBrains.Util.dataStructures.TypedIntrinsics.Int32<DocLine> line = Utils.GetLineNumberForTextControl(textControl);
            ITreeNode element = Utils.GetElementAtCaret(solution, textControl);
            IUsingDirective containingElement = element.GetContainingNode<IUsingDirective>(true);

            Utils.FormatLines(solution, textControl.Document, line.Minus1(), line.Plus1());

            if (containingElement != null)
            {
                new SpacingRules().EqualsMustBeSpacedCorrectly(containingElement);
            }
        }
    }
}