// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MaintainabilityRules.cs" company="http://stylecop.codeplex.com">
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
//   Maintainability rules.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace StyleCop.ReSharper.CodeCleanup.Rules
{
    using JetBrains.ReSharper.Psi.CSharp.Impl.Tree;
    using JetBrains.ReSharper.Psi.CSharp.Tree;
    using JetBrains.ReSharper.Psi.ExtensionsAPI;
    using JetBrains.ReSharper.Psi.ExtensionsAPI.Tree;
    using JetBrains.ReSharper.Psi.Tree;
    using JetBrains.ReSharper.Resources.Shell;

    using StyleCop.Diagnostics;

    /// <summary>
    /// Maintainability rules.
    /// </summary>
    internal class MaintainabilityRules
    {
        /// <summary>
        /// Remove parenthesis from node.
        /// </summary>
        /// <param name="node">
        /// The node.
        /// </param>
        public static void RemoveParenthesisFromNode(ITreeNode node)
        {
            IParenthesizedExpression parenthesizedExpressionNode = node as IParenthesizedExpression;
            if (parenthesizedExpressionNode != null)
            {
                using (WriteLockCookie.Create(true))
                {
                    ICSharpExpression innerExpression = parenthesizedExpressionNode.Expression;

                    if (innerExpression != null && node.Parent != null)
                    {
                        NodeType innerExpressionNodeType = (innerExpression as TreeElement).NodeType;

                        if (innerExpressionNodeType != ElementType.ADDITIVE_EXPRESSION && innerExpressionNodeType != ElementType.MULTIPLICATIVE_EXPRESSION
                            && innerExpressionNodeType != ElementType.SHIFT_EXPRESSION && innerExpressionNodeType != ElementType.AS_EXPRESSION
                            && innerExpressionNodeType != ElementType.ASSIGNMENT_EXPRESSION && innerExpressionNodeType != ElementType.CAST_EXPRESSION
                            && innerExpressionNodeType != ElementType.CONDITIONAL_AND_EXPRESSION && innerExpressionNodeType != ElementType.CONDITIONAL_OR_EXPRESSION
                            && innerExpressionNodeType != ElementType.CONDITIONAL_TERNARY_EXPRESSION && innerExpressionNodeType != ElementType.POSTFIX_OPERATOR_EXPRESSION
                            && innerExpressionNodeType != ElementType.PREFIX_OPERATOR_EXPRESSION && innerExpressionNodeType != ElementType.IS_EXPRESSION
                            && innerExpressionNodeType != ElementType.LAMBDA_EXPRESSION && innerExpressionNodeType != ElementType.BITWISE_AND_EXPRESSION
                            && innerExpressionNodeType != ElementType.BITWISE_INCLUSIVE_OR_EXPRESSION
                            && innerExpressionNodeType != ElementType.BITWISE_EXCLUSIVE_OR_EXPRESSION && innerExpressionNodeType != ElementType.OBJECT_CREATION_EXPRESSION
                            && innerExpressionNodeType != ElementType.ARRAY_CREATION_EXPRESSION && innerExpressionNodeType != ElementType.NULL_COALESCING_EXPRESSION
                            && innerExpressionNodeType != ElementType.QUERY_EXPRESSION && innerExpressionNodeType != ElementType.RELATIONAL_EXPRESSION
                            && innerExpressionNodeType != ElementType.UNARY_OPERATOR_EXPRESSION && innerExpressionNodeType != ElementType.EQUALITY_EXPRESSION
                            && innerExpressionNodeType != ElementType.AWAIT_EXPRESSION)
                        {
                            LowLevelModificationUtil.ReplaceChildRange(node, node, new ITreeNode[] { innerExpression });
                            return;
                        }

                        if ((!(node.Parent is IExpression)) || node.Parent is IVariableDeclaration)
                        {
                            LowLevelModificationUtil.ReplaceChildRange(node, node, new ITreeNode[] { innerExpression });
                            return;
                        }

                        IAssignmentExpression parent = node.Parent as IAssignmentExpression;

                        if (parent != null && parent.Source == node)
                        {
                            LowLevelModificationUtil.ReplaceChildRange(node, node, new ITreeNode[] { innerExpression });
                            return;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Remove unnecessary parenthesis from statements.
        /// </summary>
        /// <param name="node">
        /// The node.
        /// </param>
        public static void RemoveUnnecessaryParenthesisFromStatements(ITreeNode node)
        {
            for (ITreeNode currentNode = node; currentNode != null; currentNode = currentNode.NextSibling)
            {
                RemoveParenthesisFromNode(currentNode);

                if (currentNode.FirstChild != null)
                {
                    RemoveUnnecessaryParenthesisFromStatements(currentNode.FirstChild);
                }
            }
        }

        /// <summary>
        /// The Execute method.
        /// </summary>
        /// <param name="file">
        /// The file to fix
        /// </param>
        /// <param name="settings">
        /// The settings to use in the fix.
        /// </param>
        public static void ExecuteAll(ICSharpFile file, Settings settings)
        {
            StyleCopTrace.In(file, settings);

            var analyzerSettings = new AnalyzerSettings(settings, "StyleCop.CSharp.MaintainabilityRules");

            if (analyzerSettings.IsRuleEnabled("StatementMustNotUseUnnecessaryParenthesis"))
            {
                RemoveUnnecessaryParenthesisFromStatements(file.FirstChild);
            }

            StyleCopTrace.Out();
        }
    }
}