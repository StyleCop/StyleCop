// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SpacingRules.cs" company="http://stylecop.codeplex.com">
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
//   Spacing rules.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
extern alias JB;

namespace StyleCop.ReSharper611.CodeCleanup.Rules
{
    #region Using Directives

    using System.Collections.Generic;

    using JetBrains.Application;
    using JetBrains.ReSharper.Psi;
    using JetBrains.ReSharper.Psi.CSharp.Parsing;
    using JetBrains.ReSharper.Psi.CSharp.Tree;
    using JetBrains.ReSharper.Psi.ExtensionsAPI;
    using JetBrains.ReSharper.Psi.ExtensionsAPI.Tree;
    using JetBrains.ReSharper.Psi.Parsing;
    using JetBrains.ReSharper.Psi.Tree;

    using StyleCop.Diagnostics;
    using StyleCop.ReSharper611.CodeCleanup.Options;

    #endregion

    /// <summary>
    /// Spacing rules.
    /// </summary>
    internal class SpacingRules
    {
        #region Public Methods

        /// <summary>
        /// The code must not contain multiple whitespace in a row.
        /// </summary>
        /// <param name="node">
        /// The node.
        /// </param>
        public void CodeMustNotContainMultipleWhitespaceInARow(ITreeNode node)
        {
            for (var currentNode = node; currentNode != null; currentNode = currentNode.NextSibling)
            {
                if (currentNode is ITokenNode)
                {
                    var currentToken = currentNode as ITokenNode;
                    var previousToken = currentToken.GetPrevToken();

                    if (previousToken != null)
                    {
                        if (currentToken.GetTokenType() == CSharpTokenType.WHITE_SPACE && previousToken.GetTokenType() == CSharpTokenType.WHITE_SPACE)
                        {
                            using (WriteLockCookie.Create(true))
                            {
                                LowLevelModificationUtil.DeleteChild(currentToken);
                            }
                        }
                    }
                }

                if (currentNode.FirstChild != null)
                {
                    this.CodeMustNotContainMultipleWhitespaceInARow(currentNode.FirstChild);
                }
            }
        }

        /// <summary>
        /// Commas must be spaced correctly.
        /// </summary>
        /// <param name="node">
        /// The node to use.
        /// </param>
        public void CommasMustBeSpacedCorrectly(ITreeNode node)
        {
            var tokensThatCanBeRightSideOfComma = new List<TokenNodeType> { CSharpTokenType.WHITE_SPACE, CSharpTokenType.RBRACKET, CSharpTokenType.GT, CSharpTokenType.COMMA, CSharpTokenType.RPARENTH };

            const string WhiteSpace = " ";

            for (var currentNode = node; currentNode != null; currentNode = currentNode.NextSibling)
            {
                if (currentNode is ITokenNode)
                {
                    var tokenNode = currentNode as ITokenNode;

                    if (tokenNode.GetTokenType() == CSharpTokenType.COMMA)
                    {
                        var nextToken = tokenNode.GetNextToken();

                        if (!tokensThatCanBeRightSideOfComma.Contains(nextToken.GetTokenType()))
                        {
                            using (WriteLockCookie.Create(true))
                            {
                                // insert a space
                                var leafElement = TreeElementFactory.CreateLeafElement(CSharpTokenType.WHITE_SPACE, new JB::JetBrains.Text.StringBuffer(WhiteSpace), 0, WhiteSpace.Length);
                                LowLevelModificationUtil.AddChildBefore(nextToken, new ITreeNode[] { leafElement });
                            }
                        }
                    }
                }

                if (currentNode.FirstChild != null)
                {
                    this.CommasMustBeSpacedCorrectly(currentNode.FirstChild);
                }
            }
        }

        /// <summary>
        /// Commas must be spaced correctly.
        /// </summary>
        /// <param name="node">
        /// The node to use.
        /// </param>
        public void EqualsMustBeSpacedCorrectly(ITreeNode node)
        {
            var tokensThatCanBeLeftSideOfEquals = new List<TokenNodeType> { CSharpTokenType.WHITE_SPACE, CSharpTokenType.NE, CSharpTokenType.LT, CSharpTokenType.GT };

            const string WhiteSpace = " ";

            for (var currentNode = node; currentNode != null; currentNode = currentNode.NextSibling)
            {
                if (currentNode is ITokenNode)
                {
                    var tokenNode = currentNode as ITokenNode;

                    if (tokenNode.GetTokenType() == CSharpTokenType.EQ)
                    {
                        var nextToken = tokenNode.GetNextToken();

                        var previousToken = tokenNode.GetPrevToken();

                        if (!nextToken.IsWhitespace())
                        {
                            using (WriteLockCookie.Create(true))
                            {
                                // insert a space
                                var leafElement = TreeElementFactory.CreateLeafElement(CSharpTokenType.WHITE_SPACE, new JB::JetBrains.Text.StringBuffer(WhiteSpace), 0, WhiteSpace.Length);
                                LowLevelModificationUtil.AddChildBefore(nextToken, new ITreeNode[] { leafElement });
                            }
                        }

                        if (!tokensThatCanBeLeftSideOfEquals.Contains(previousToken.GetTokenType()))
                        {
                            using (WriteLockCookie.Create(true))
                            {
                                // insert a space
                                var leafElement = TreeElementFactory.CreateLeafElement(CSharpTokenType.WHITE_SPACE, new JB::JetBrains.Text.StringBuffer(WhiteSpace), 0, WhiteSpace.Length);
                                LowLevelModificationUtil.AddChildBefore(tokenNode, new ITreeNode[] { leafElement });
                            }
                        }
                    }
                }

                if (currentNode.FirstChild != null)
                {
                    this.EqualsMustBeSpacedCorrectly(currentNode.FirstChild);
                }
            }
        }

        /// <summary>
        /// Implement the Execute method.
        /// </summary>
        /// <param name="options">
        /// The options.
        /// </param>
        /// <param name="file">
        /// The file to use.
        /// </param>
        public void Execute(SpacingOptions options, ICSharpFile file)
        {
            StyleCopTrace.In(options, file);

            Param.RequireNotNull(options, "options");
            Param.RequireNotNull(file, "file");

            var commasMustBeSpacedCorrectly = options.SA1001CommasMustBeSpacedCorrectly;
            var singleLineCommentsMustBeginWithSingleSpace = options.SA1005SingleLineCommentsMustBeginWithSingleSpace;
            var preprocessorKeywordsMustNotBePrecededBySpace = options.SA1006PreprocessorKeywordsMustNotBePrecededBySpace;
            var negativeSignsMustBeSpacedCorrectly = options.SA1021NegativeSignsMustBeSpacedCorrectly;
            var positiveSignsMustBeSpacedCorrectly = options.SA1022PositiveSignsMustBeSpacedCorrectly;
            var codeMustNotContainMultipleWhitespaceInARow = options.SA1025CodeMustNotContainMultipleWhitespaceInARow;
            
            if (codeMustNotContainMultipleWhitespaceInARow)
            {
                this.CodeMustNotContainMultipleWhitespaceInARow(file.FirstChild);
            }

            if (commasMustBeSpacedCorrectly)
            {
                this.CommasMustBeSpacedCorrectly(file.FirstChild);
            }

            if (singleLineCommentsMustBeginWithSingleSpace)
            {
                this.SingleLineCommentsMustBeginWithSingleSpace(file.FirstChild);
            }

            if (preprocessorKeywordsMustNotBePrecededBySpace)
            {
                this.PreprocessorKeywordsMustNotBePrecededBySpace(file.FirstChild);
            }

            if (negativeSignsMustBeSpacedCorrectly)
            {
                this.NegativeAndPositiveSignsMustBeSpacedCorrectly(file.FirstChild, CSharpTokenType.MINUS);
            }

            if (positiveSignsMustBeSpacedCorrectly)
            {
                this.NegativeAndPositiveSignsMustBeSpacedCorrectly(file.FirstChild, CSharpTokenType.PLUS);
            }

            StyleCopTrace.Out();
        }

        /// <summary>
        /// Negative and positive signs must be spaced correctly.
        /// </summary>
        /// <param name="node">
        /// The node to use.
        /// </param>
        /// <param name="tokenToCheck">
        /// The token to check.
        /// </param>
        public void NegativeAndPositiveSignsMustBeSpacedCorrectly(ITreeNode node, TokenNodeType tokenToCheck)
        {
            for (var currentNode = node; currentNode != null; currentNode = currentNode.NextSibling)
            {
                if (currentNode is ITokenNode)
                {
                    var tokenNode = currentNode as ITokenNode;

                    if (tokenNode.GetTokenType() == tokenToCheck)
                    {
                        if (tokenNode.Parent is IOperatorExpression && !(tokenNode.Parent is IAdditiveExpression))
                        {
                            var nextToken = tokenNode.GetNextToken();

                            if (nextToken.IsWhitespace())
                            {
                                using (WriteLockCookie.Create(true))
                                {
                                    // remove the whitespace or new line
                                    LowLevelModificationUtil.DeleteChild(nextToken);
                                }
                            }
                        }
                    }
                }

                if (currentNode.FirstChild != null)
                {
                    this.NegativeAndPositiveSignsMustBeSpacedCorrectly(currentNode.FirstChild, tokenToCheck);
                }
            }
        }

        /// <summary>
        /// Preprocessor keywords must not be preceded by space.
        /// </summary>
        /// <param name="node">
        /// The node to use.
        /// </param>
        public void PreprocessorKeywordsMustNotBePrecededBySpace(ITreeNode node)
        {
            for (var currentNode = node; currentNode != null; currentNode = currentNode.NextSibling)
            {
                if (currentNode is IPreprocessorDirective)
                {
                    var preprocessorDirectiveNode = currentNode as IPreprocessorDirective;

                    var directiveTokenNodeOffset = preprocessorDirectiveNode.Directive.GetTreeStartOffset();

                    var numberSignTokenNodeOffset = preprocessorDirectiveNode.NumberSign.GetTreeStartOffset();

                    if (directiveTokenNodeOffset - 1 != numberSignTokenNodeOffset)
                    {
                        // There is a gap between them
                        var tokenNode = preprocessorDirectiveNode.NumberSign;

                        var nextToken = tokenNode.GetNextToken();

                        using (WriteLockCookie.Create(true))
                        {
                            // remove the whitespace or new line
                            LowLevelModificationUtil.DeleteChild(nextToken);
                        }
                    }
                }

                if (currentNode.FirstChild != null)
                {
                    this.PreprocessorKeywordsMustNotBePrecededBySpace(currentNode.FirstChild);
                }
            }
        }

        /// <summary>
        /// Single line comments must begin with single space.
        /// </summary>
        /// <param name="node">
        /// The node to use.
        /// </param>
        public void SingleLineCommentsMustBeginWithSingleSpace(ITreeNode node)
        {
            for (var currentNode = node; currentNode != null; currentNode = currentNode.NextSibling)
            {
                if (currentNode is ICommentNode && !(currentNode is IDocCommentNode))
                {
                    var commentNode = currentNode as ICommentNode;

                    if (commentNode.GetTokenType() == CSharpTokenType.END_OF_LINE_COMMENT && !(commentNode.Parent is ICSharpFile))
                    {
                        var originalCommentText = commentNode.CommentText;

                        // This check is to exclude comments starting with ////
                        if (!originalCommentText.StartsWith("//"))
                        {
                            var originalCommentTextLength = originalCommentText.Length;

                            var trimmedCommentText = originalCommentText.TrimStart(' ');
                            var trimmedCommentTextLength = trimmedCommentText.Length;

                            if (trimmedCommentTextLength != originalCommentTextLength - 1)
                            {
                                using (WriteLockCookie.Create(true))
                                {
                                    var newText = string.Format("// {0}", trimmedCommentText);
                                    var newCommentNode =
                                        (ICommentNode)CSharpTokenType.END_OF_LINE_COMMENT.Create(new JB::JetBrains.Text.StringBuffer(newText), new TreeOffset(0), new TreeOffset(newText.Length));
                                    LowLevelModificationUtil.ReplaceChildRange(currentNode, currentNode, new ITreeNode[] { newCommentNode });

                                    currentNode = newCommentNode;
                                }
                            }
                        }
                    }
                }

                if (currentNode.FirstChild != null)
                {
                    this.SingleLineCommentsMustBeginWithSingleSpace(currentNode.FirstChild);
                }
            }
        }

        #endregion
    }
}