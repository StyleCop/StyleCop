// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SA1121UseBuiltInTypeAliasBulbItem.cs" company="http://stylecop.codeplex.com">
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
//   The s a 1121 use built in type alias bulb item.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace StyleCop.ReSharper611.BulbItems.Readability
{
    #region Using Directives

    using JetBrains.ProjectModel;
    using JetBrains.ReSharper.Psi.CSharp.Tree;
    using JetBrains.ReSharper.Psi.Tree;
    using JetBrains.TextControl;

    using StyleCop.ReSharper611.BulbItems.Framework;
    using StyleCop.ReSharper611.CodeCleanup.Rules;
    using StyleCop.ReSharper611.Core;

    #endregion

    /// <summary>
    /// The s a 1121 use built in type alias bulb item.
    /// </summary>
    public class SA1121UseBuiltInTypeAliasBulbItem : V5BulbItemImpl
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
            var tokensForLine = Utils.GetTokensForLineFromTextControl(solution, textControl);

            foreach (var tokenNode in tokensForLine)
            {
                var typeArgumentListNode = tokenNode.GetContainingNode<ITypeArgumentList>(true);

                if (typeArgumentListNode != null)
                {
                    ReadabilityRules.SwapToBuiltInTypeAlias(typeArgumentListNode);
                }

                var objectCreationExpressionNode = tokenNode.GetContainingNode<IObjectCreationExpression>(true);

                if (objectCreationExpressionNode != null)
                {
                    ReadabilityRules.SwapToBuiltInTypeAlias(objectCreationExpressionNode);
                }

                var arrayCreationExpressionNode = tokenNode.GetContainingNode<IArrayCreationExpression>(true);

                if (arrayCreationExpressionNode != null)
                {
                    ReadabilityRules.SwapToBuiltInTypeAlias(arrayCreationExpressionNode);
                }

                var methodDeclaration = tokenNode.GetContainingNode<IMethodDeclaration>(true);

                if (methodDeclaration != null)
                {
                    ReadabilityRules.SwapToBuiltInTypeAlias(methodDeclaration);
                }

                var variableDeclaration = tokenNode.GetContainingNode<IVariableDeclaration>(true);

                if (variableDeclaration != null)
                {
                    ReadabilityRules.SwapToBuiltInTypeAlias((ITreeNode)variableDeclaration);
                }

                var multipleDeclarationNode = tokenNode.GetContainingNode<IMultipleDeclaration>(true);

                if (multipleDeclarationNode != null)
                {
                    ReadabilityRules.SwapToBuiltInTypeAlias(multipleDeclarationNode);
                }
            }
        }

        #endregion
    }
}