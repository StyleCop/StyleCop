// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SA1643DestructorSummaryDocumentationMustBeginWithStandardTextBulbItem.cs" company="http://stylecop.codeplex.com">
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
//   SA1642: SA1643DestructorSummaryDocumentationMustBeginWithStandardTextBulbItem.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.ReSharper.BulbItems.Documentation
{
    using JetBrains.ProjectModel;
    using JetBrains.ReSharper.Psi.CSharp.Tree;
    using JetBrains.ReSharper.Psi.Tree;
    using JetBrains.TextControl;

    using StyleCop.ReSharper.BulbItems.Framework;
    using StyleCop.ReSharper.CodeCleanup.Rules;
    using StyleCop.ReSharper.Core;

    /// <summary>
    /// SA1642: SA1643DestructorSummaryDocumentationMustBeginWithStandardTextBulbItem.
    /// </summary>
    public class SA1643DestructorSummaryDocumentationMustBeginWithStandardTextBulbItem : V5BulbItemImpl
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

            if (element != null)
            {
                IDestructorDeclaration destructorDeclaration = element.GetContainingNode<IDestructorDeclaration>(true);
                if (destructorDeclaration != null)
                {
                    DocumentationRules.EnsureDestructorSummaryDocBeginsWithStandardText(destructorDeclaration);
                }
            }
        }
    }
}