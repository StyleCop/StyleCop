// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MoveUsings.cs" company="http://stylecop.codeplex.com">
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
//   BulbItem - MoveUsings : Moves Using statements inside the closest namespace.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.ReSharper.BulbItems.Ordering
{
    using JetBrains.ProjectModel;
    using JetBrains.ReSharper.Psi.CSharp.Tree;
    using JetBrains.ReSharper.Psi.Tree;
    using JetBrains.TextControl;

    using StyleCop.ReSharper.BulbItems.Framework;
    using StyleCop.ReSharper.Core;

    /// <summary>
    /// BulbItem - MoveUsings : Moves Using statements inside the closest namespace.
    /// </summary>
    internal class MoveUsings : V5BulbItemImpl
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

            if (element == null)
            {
                return;
            }

            IUsingList usingList = element.GetContainingNode(typeof(IUsingList), false) as IUsingList;

            if (usingList == null)
            {
                return;
            }

            ICSharpFile file = Utils.GetCSharpFile(solution, textControl);

            // This violation will only run if there are some using statements and definately at least 1 namespace
            // so [0] index will always be OK.
            ICSharpNamespaceDeclaration firstNamespace = file.NamespaceDeclarations[0];

            foreach (IUsingDirective usingDirectiveNode in usingList.Imports)
            {
                firstNamespace.AddImportBefore(usingDirectiveNode, null);

                file.RemoveImport(usingDirectiveNode);
            }

            // Now sort the Usings into order.
            OrderUsingsBulbItem orderUsingsBulbItem = new OrderUsingsBulbItem();
            orderUsingsBulbItem.ExecuteTransactionInner(solution, textControl);
        }
    }
}