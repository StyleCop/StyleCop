//-----------------------------------------------------------------------
// <copyright file="">
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
//-----------------------------------------------------------------------

namespace StyleCop.ReSharper.BulbItems.Readability
{
    #region Using Directives

    using JetBrains.ProjectModel;
    using JetBrains.ReSharper.Psi.CSharp.Tree;
    using JetBrains.ReSharper.Psi.Tree;
    using JetBrains.TextControl;

    using StyleCop.ReSharper.BulbItems.Framework;
    using StyleCop.ReSharper.CodeCleanup.Rules;
    using StyleCop.ReSharper.Core;

    #endregion

    public class SA1121UseBuiltInTypeAliasBulbItem : V5BulbItemImpl
    {
        public override void ExecuteTransactionInner(ISolution solution, ITextControl textControl)
        {
            var tokensForLine = Utils.GetTokensForLineFromTextControl(solution, textControl);

            foreach (var tokenNode in tokensForLine)
            {
                var typeArgumentListNode = tokenNode.GetContainingElement<ITypeArgumentListNode>(true);

                if (typeArgumentListNode != null)
                {
                    ReadabilityRules.SwapToBuiltInTypeAlias(typeArgumentListNode);
                }

                var objectCreationExpressionNode = tokenNode.GetContainingElement<IObjectCreationExpressionNode>(true);

                if (objectCreationExpressionNode != null)
                {
                    ReadabilityRules.SwapToBuiltInTypeAlias(objectCreationExpressionNode);
                }

                var arrayCreationExpressionNode = tokenNode.GetContainingElement<IArrayCreationExpressionNode>(true);

                if (arrayCreationExpressionNode != null)
                {
                    ReadabilityRules.SwapToBuiltInTypeAlias(arrayCreationExpressionNode);
                }

                var methodDeclaration = tokenNode.GetContainingElement<IMethodDeclaration>(true);

                if (methodDeclaration != null)
                {
                    ReadabilityRules.SwapToBuiltInTypeAlias((ITreeNode)methodDeclaration);
                }

                var variableDeclaration = tokenNode.GetContainingElement<IVariableDeclaration>(true);

                if (variableDeclaration != null)
                {
                    ReadabilityRules.SwapToBuiltInTypeAlias((ITreeNode)variableDeclaration);
                }

                var multipleDeclarationNode = tokenNode.GetContainingElement<IMultipleDeclarationNode>(true);

                if (multipleDeclarationNode != null)
                {
                    ReadabilityRules.SwapToBuiltInTypeAlias(multipleDeclarationNode);
                }
            }
        }
    }
}