// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SA1500CurlyBracketsForMultiLineStatementsMustNotShareLineBulbItem.cs" company="http://stylecop.codeplex.com">
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
//   The s a 1500 curly brackets for multi line statements must not share line bulb item.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.ReSharper.BulbItems.Layout
{
    using JetBrains.ProjectModel;
    using JetBrains.ReSharper.Psi;
    using JetBrains.ReSharper.Psi.CodeStyle;
    using JetBrains.ReSharper.Psi.CSharp;
    using JetBrains.ReSharper.Psi.CSharp.CodeStyle;
    using JetBrains.ReSharper.Psi.CSharp.Tree;
    using JetBrains.ReSharper.Psi.Tree;
    using JetBrains.TextControl;

    using StyleCop.ReSharper.BulbItems.Framework;
    using StyleCop.ReSharper.CodeCleanup.Rules;
    using StyleCop.ReSharper.Core;

    /// <summary>
    /// The s a 1500 curly brackets for multi line statements must not share line bulb item.
    /// </summary>
    public class SA1500CurlyBracketsForMultiLineStatementsMustNotShareLineBulbItem : V5BulbItemImpl
    {
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
            ITreeNode element = Utils.GetElementAtCaret(solution, textControl);
            IBlock containingBlock = element.GetContainingNode<IBlock>(true);

            if (containingBlock != null)
            {
                //// CSharpFormatterHelper.FormatterInstance.Format(containingBlock);
                ICSharpCodeFormatter codeFormatter = (ICSharpCodeFormatter)CSharpLanguage.Instance.LanguageService().CodeFormatter;
                codeFormatter.Format(containingBlock);

                LayoutRules.CurlyBracketsForMultiLineStatementsMustNotShareLine(containingBlock);
            }
            else
            {
                IFieldDeclaration fieldDeclarationNode = element.GetContainingNode<IFieldDeclaration>(true);
                if (fieldDeclarationNode != null)
                {
                    //// CSharpFormatterHelper.FormatterInstance.Format(fieldDeclarationNode);
                    ICSharpCodeFormatter codeFormatter = (ICSharpCodeFormatter)CSharpLanguage.Instance.LanguageService().CodeFormatter;
                    codeFormatter.Format(fieldDeclarationNode);

                    LayoutRules.CurlyBracketsForMultiLineStatementsMustNotShareLine(fieldDeclarationNode);
                }
            }
        }
    }
}