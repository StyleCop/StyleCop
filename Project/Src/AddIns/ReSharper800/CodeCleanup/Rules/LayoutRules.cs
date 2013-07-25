// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LayoutRules.cs" company="http://stylecop.codeplex.com">
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
//   Layout rules.
// </summary>
// --------------------------------------------------------------------------------------------------------------------


namespace StyleCop.ReSharper800.CodeCleanup.Rules
{
    #region Using Directives

    using System.Collections.Generic;

    using JetBrains.DocumentModel;
    using JetBrains.ReSharper.Psi;
    using JetBrains.ReSharper.Psi.CodeStyle;
    using JetBrains.ReSharper.Psi.CSharp;
    using JetBrains.ReSharper.Psi.CSharp.CodeStyle;
    using JetBrains.ReSharper.Psi.CSharp.Impl.Tree;
    using JetBrains.ReSharper.Psi.CSharp.Parsing;
    using JetBrains.ReSharper.Psi.CSharp.Tree;
    using JetBrains.ReSharper.Psi.Impl.CodeStyle;
    using JetBrains.ReSharper.Psi.Parsing;
    using JetBrains.ReSharper.Psi.Tree;

    using StyleCop.Diagnostics;
    using StyleCop.ReSharper800.CodeCleanup.Options;
    using StyleCop.ReSharper800.Core;
    using StyleCop.ReSharper800.Extensions;

    #endregion

    /// <summary>
    /// Layout rules.
    /// </summary>
    internal class LayoutRules
    {
        #region Public Methods and Operators

        /// <summary>
        /// Closing curly bracket must be followed by blank line.
        /// </summary>
        /// <param name="node">
        /// The node to use.
        /// </param>
        public static void ClosingCurlyBracketMustBeFollowedByBlankLine(ITreeNode node)
        {
            // Closing curly brackets must be followed by a newline unless they are closing an object initializer or 
            // followed by one of the endtokens defined here.
            // catch
            // finally 
            // else
            // rbrace
            // dowhile
            // preprocessor directives
            List<TokenNodeType> tokensThatFollowClosingCurlyBracketWithoutNewLine = new List<TokenNodeType>
                                                                                        {
                                                                                            CSharpTokenType.RBRACE, 
                                                                                            CSharpTokenType.DO_KEYWORD, 
                                                                                            CSharpTokenType.ELSE_KEYWORD, 
                                                                                            CSharpTokenType.CATCH_KEYWORD, 
                                                                                            CSharpTokenType.FINALLY_KEYWORD
                                                                                        };

            List<TokenNodeType> objectInitializerFollowers = new List<TokenNodeType>
                                                                 {
                                                                     CSharpTokenType.AS_KEYWORD, 
                                                                     CSharpTokenType.IS_KEYWORD, 
                                                                     CSharpTokenType.COMMA, 
                                                                     CSharpTokenType.SEMICOLON, 
                                                                     CSharpTokenType.DOT, 
                                                                     CSharpTokenType.QUEST, 
                                                                     CSharpTokenType.COLON, 
                                                                     CSharpTokenType.RPARENTH, 
                                                                     CSharpTokenType.EQEQ, 
                                                                     CSharpTokenType.GE, 
                                                                     CSharpTokenType.GT, 
                                                                     CSharpTokenType.LE, 
                                                                     CSharpTokenType.LT, 
                                                                     CSharpTokenType.NE, 
                                                                     CSharpTokenType.MINUS, 
                                                                     CSharpTokenType.PLUS, 
                                                                     CSharpTokenType.DIV, 
                                                                     CSharpTokenType.ASTERISK, 
                                                                     CSharpTokenType.PERC, 
                                                                     CSharpTokenType.MINUSMINUS, 
                                                                     CSharpTokenType.PLUSPLUS
                                                                 };

            for (ITreeNode currentNode = node; currentNode != null; currentNode = currentNode.NextSibling)
            {
                if (currentNode is ITokenNode)
                {
                    ITokenNode tokenNode = currentNode as ITokenNode;

                    if (tokenNode.GetTokenType() == CSharpTokenType.RBRACE)
                    {
                        IBlock blockNode = tokenNode.Parent as IBlock;

                        if (blockNode != null)
                        {
                            JetBrains.Util.dataStructures.TypedIntrinsics.Int32<DocLine> lineNumberForLBrace = Utils.GetLineNumberForElement(blockNode.LBrace);
                            JetBrains.Util.dataStructures.TypedIntrinsics.Int32<DocLine> lineNumberForRBrace = Utils.GetLineNumberForElement(blockNode.RBrace);

                            if (lineNumberForLBrace != lineNumberForRBrace)
                            {
                                ITokenNode currentToken = tokenNode.GetNextToken();

                                int newLineCount = 0;
                                while (currentToken != null)
                                {
                                    if (currentToken.IsWhitespace())
                                    {
                                        if (currentToken.IsNewLine())
                                        {
                                            newLineCount++;
                                            if (newLineCount == 2)
                                            {
                                                // if we get 2 new lines we've already got a blank line after the closing curly bracket so jog on.
                                                break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if ((!tokensThatFollowClosingCurlyBracketWithoutNewLine.Contains(currentToken.GetTokenType())
                                             && !objectInitializerFollowers.Contains(currentToken.GetTokenType()))
                                            || (objectInitializerFollowers.Contains(currentToken.GetTokenType()) && newLineCount == 1))
                                        {
                                            tokenNode.GetNextToken().InsertNewLineBefore();
                                        }

                                        break;
                                    }

                                    currentToken = currentToken.GetNextToken();
                                }
                            }
                        }
                    }
                }

                if (currentNode.FirstChild != null)
                {
                    ClosingCurlyBracketMustBeFollowedByBlankLine(currentNode.FirstChild);
                }
            }
        }

        /// <summary>
        /// Curly brackets for multi line statements must not share line.
        /// </summary>
        /// <param name="node">
        /// The node.
        /// </param>
        public void CurlyBracketsForMultiLineStatementsMustNotShareLine(ITreeNode node)
        {
            int offsetColumn = 0;
            for (ITreeNode currentNode = node; currentNode != null; currentNode = currentNode.NextSibling)
            {
                if (currentNode is ITokenNode)
                {
                    ITokenNode tokenNode = currentNode as ITokenNode;
                    if (tokenNode.GetTokenType() == CSharpTokenType.LBRACE)
                    {
                        // check to see if this LBRACE { is on a line with another non whitespace token
                        if (tokenNode.Parent is ICreationExpressionInitializer)
                        {
                            ICreationExpressionInitializer creationExpressionInitializerNode = tokenNode.Parent as ICreationExpressionInitializer;
                            if (creationExpressionInitializerNode != null)
                            {
                                ITokenNode leftBrace = creationExpressionInitializerNode.LBrace;
                                ITokenNode rightBrace = creationExpressionInitializerNode.RBrace;
                                ICreationExpression creationExpressionNode = tokenNode.GetContainingNode<ICreationExpression>(true);

                                if (creationExpressionNode != null)
                                {
                                    ITreeNode first = creationExpressionNode.FirstChild;
                                    ITreeNode last = creationExpressionNode.LastChild;

                                    if (Utils.HasLineBreakBetween(first, last))
                                    {
                                        if (Utils.TokenHasNonWhitespaceTokenToRightOnSameLine(leftBrace))
                                        {
                                            // We'll be 4-1 honest.
                                            offsetColumn = Utils.GetOffsetToStartOfLine(leftBrace);
                                            ITreeNode newLine = leftBrace.InsertNewLineAfter();

                                            Utils.InsertWhitespaceAfter(newLine, offsetColumn + 3);
                                        }

                                        if (rightBrace != null)
                                        {
                                            // check to see if this RBRACE { is on a line with another non whitespace token
                                            if (Utils.TokenHasNonWhitespaceTokenToLeftOnSameLine(rightBrace))
                                            {
                                                ITreeNode newLine = rightBrace.InsertNewLineBefore();
                                                Utils.InsertWhitespaceAfter(newLine, offsetColumn);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                if (currentNode.FirstChild != null)
                {
                    this.CurlyBracketsForMultiLineStatementsMustNotShareLine(currentNode.FirstChild);
                }
            }
        }

        /// <summary>
        /// The Execute method.
        /// </summary>
        /// <param name="options">
        /// The options.
        /// </param>
        /// <param name="file">
        /// The file.
        /// </param>
        public void Execute(LayoutOptions options, ICSharpFile file)
        {
            StyleCopTrace.In(options, file);

            Param.RequireNotNull(options, "options");
            Param.RequireNotNull(file, "file");

            bool curlyBracketsForMultiLineStatementsMustNotShareLine = options.SA1500CurlyBracketsForMultiLineStatementsMustNotShareLine;
            bool openingCurlyBracketsMustNotBePrecededByBlankLine = options.SA1509OpeningCurlyBracketsMustNotBePrecededByBlankLine;
            bool chainedStatementBlocksMustNotBePrecededByBlankLine = options.SA1510ChainedStatementBlocksMustNotBePrecededByBlankLine;
            bool whileDoFooterMustNotBePrecededByBlankLine = options.SA1511WhileDoFooterMustNotBePrecededByBlankLine;
            bool singleLineCommentsMustNotBeFollowedByBlankLine = options.SA1512SingleLineCommentsMustNotBeFollowedByBlankLine;
            bool closingCurlyBracketMustBeFollowedByBlankLine = options.SA1513ClosingCurlyBracketMustBeFollowedByBlankLine;
            bool elementDocumentationHeadersMustBePrecededByBlankLine = options.SA1514ElementDocumentationHeaderMustBePrecededByBlankLine;
            bool singleLineCommentsMustBeProceededByBlankLine = options.SA1515SingleLineCommentMustBeProceededByBlankLine;

            if (singleLineCommentsMustBeProceededByBlankLine)
            {
                this.CommentsMustBePreceededByBlankLine(file.FirstChild);
            }

            if (singleLineCommentsMustNotBeFollowedByBlankLine)
            {
                this.CommentsMustNotBeFollowedByBlankLine(file.FirstChild);
            }

            if (closingCurlyBracketMustBeFollowedByBlankLine)
            {
                ClosingCurlyBracketMustBeFollowedByBlankLine(file.FirstChild);
            }

            if (whileDoFooterMustNotBePrecededByBlankLine)
            {
                this.WhileDoFooterMustNotBePrecededByBlankLine(file.FirstChild);
            }

            if (chainedStatementBlocksMustNotBePrecededByBlankLine)
            {
                this.ChainedStatementBlocksMustNotBePrecededByBlankLine(file.FirstChild);
            }

            if (openingCurlyBracketsMustNotBePrecededByBlankLine)
            {
                this.OpeningCurlyBracketsMustNotBePrecededByBlankLine(file.FirstChild);
            }

            if (elementDocumentationHeadersMustBePrecededByBlankLine)
            {
                this.ElementDocumentationHeadersMustBePrecededByBlankLine(file.FirstChild);
            }

            if (curlyBracketsForMultiLineStatementsMustNotShareLine)
            {
                this.CurlyBracketsForMultiLineStatementsMustNotShareLine(file.FirstChild);
            }

            StyleCopTrace.Out();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Remove line if previous tokens are new lines.
        /// </summary>
        /// <param name="tokenNode">
        /// The token node.
        /// </param>
        private static void RemoveLineIfPreviousTokensAreNewLines(ITokenNode tokenNode)
        {
            // first prev token will be whitespace padding out the line
            ITokenNode prevToken1 = tokenNode.GetPrevToken();
            ITokenNode prevToken2 = prevToken1.GetPrevToken();
            ITokenNode prevToken3 = prevToken2.GetPrevToken();

            IWhitespaceNode prevToken2WhiteSpaceNode = prevToken2 as IWhitespaceNode;
            IWhitespaceNode prevToken3WhiteSpaceNode = prevToken3 as IWhitespaceNode;

            if (prevToken2WhiteSpaceNode != null && prevToken2WhiteSpaceNode.IsNewLine && prevToken3WhiteSpaceNode != null && prevToken3WhiteSpaceNode.IsNewLine)
            {
                Utils.RemoveNewLineBefore(tokenNode);
            }
        }

        /// <summary>
        /// Chained statement blocks must not be preceded by blank line.
        /// </summary>
        /// <param name="node">
        /// The node.
        /// </param>
        private void ChainedStatementBlocksMustNotBePrecededByBlankLine(ITreeNode node)
        {
            // chained statement blocks are:
            // try catch finally
            // if else
            // so we'll be looking for catch finally and else
            List<TokenNodeType> searchTokens = new List<TokenNodeType> { CSharpTokenType.CATCH_KEYWORD, CSharpTokenType.FINALLY_KEYWORD, CSharpTokenType.ELSE_KEYWORD };

            for (ITreeNode currentNode = node; currentNode != null; currentNode = currentNode.NextSibling)
            {
                if (currentNode is ITokenNode)
                {
                    ITokenNode tokenNode = currentNode as ITokenNode;

                    if (searchTokens.Contains(tokenNode.GetTokenType()))
                    {
                        RemoveLineIfPreviousTokensAreNewLines(tokenNode);
                    }
                }

                if (currentNode.FirstChild != null)
                {
                    this.ChainedStatementBlocksMustNotBePrecededByBlankLine(currentNode.FirstChild);
                }
            }
        }

        /// <summary>
        /// Comments must be preceded by blank line.
        /// </summary>
        /// <param name="node">
        /// The node.
        /// </param>
        private void CommentsMustBePreceededByBlankLine(ITreeNode node)
        {
            ITreeNode siblingMinus2;
            ITreeNode siblingMinus1;
            ITreeNode siblingMinus3;

            for (ITreeNode currentNode = node; currentNode != null; currentNode = currentNode.NextSibling)
            {
                if (currentNode is ICommentNode && !(currentNode is IDocCommentNode))
                {
                    if (Utils.IsFirstNodeOnLine(currentNode) && !(currentNode.Parent is ICSharpFile))
                    {
                        siblingMinus1 = currentNode.PrevSibling;

                        if (siblingMinus1 != null)
                        {
                            siblingMinus2 = siblingMinus1.PrevSibling;

                            if (siblingMinus2 != null)
                            {
                                siblingMinus3 = siblingMinus2.PrevSibling;

                                ITokenNode siblingMinus3Token = siblingMinus3 as ITokenNode;
                                IWhitespaceNode siblingMinus2WhitespaceNode = siblingMinus2 as IWhitespaceNode;
                                IWhitespaceNode siblingMinus3WhitespaceNode = siblingMinus3 as IWhitespaceNode;

                                ICommentNode siblingMinus3CommentNode = siblingMinus3 as ICommentNode;
                                if (siblingMinus3CommentNode != null)
                                {
                                    // if the previous sibling is a comment then it doesn't need a new line.
                                    continue;
                                }

                                if (siblingMinus3Token != null && siblingMinus3Token.GetTokenType() == TokenType.LBRACE)
                                {
                                    // if we're the start of a code block then don't insert a new line.
                                    continue;
                                }

                                if (siblingMinus2WhitespaceNode == null || siblingMinus3WhitespaceNode == null || !siblingMinus2WhitespaceNode.IsNewLine
                                    || !siblingMinus3WhitespaceNode.IsNewLine)
                                {
                                    currentNode.InsertNewLineBefore();

                                    ////CSharpFormatterHelper.FormatterInstance.Format(currentNode.Parent);
                                    ICSharpCodeFormatter codeFormatter = (ICSharpCodeFormatter)CSharpLanguage.Instance.LanguageService().CodeFormatter;
                                    codeFormatter.Format(currentNode.Parent);
                                }
                            }
                        }
                    }
                }

                if (currentNode.FirstChild != null)
                {
                    this.CommentsMustBePreceededByBlankLine(currentNode.FirstChild);
                }
            }
        }

        /// <summary>
        /// Comments must not be followed by blank line.
        /// </summary>
        /// <param name="node">
        /// The node.
        /// </param>
        private void CommentsMustNotBeFollowedByBlankLine(ITreeNode node)
        {
            for (ITreeNode currentNode = node; currentNode != null; currentNode = currentNode.NextSibling)
            {
                if (currentNode is ICommentNode && !(currentNode is IDocCommentNode))
                {
                    if (Utils.IsFirstNodeOnLine(currentNode))
                    {
                        ICommentNode tokenNode = currentNode as ICommentNode;

                        ITokenNode nextToken = tokenNode.GetNextToken();

                        if (nextToken != null && nextToken.IsNewLine())
                        {
                            ITokenNode nextNextToken = nextToken.GetNextToken();

                            if (nextNextToken != null)
                            {
                                ITokenNode nextNextNextToken = Utils.GetFirstNonWhitespaceTokenToRight(nextNextToken);

                                if (nextNextToken.IsNewLine() && !(nextNextNextToken is ICommentNode))
                                {
                                    ITreeNode rightNode = currentNode.FindFormattingRangeToRight();
                                    Utils.RemoveNewLineBefore(rightNode);
                                }
                            }
                        }
                    }
                }

                if (currentNode.FirstChild != null)
                {
                    this.CommentsMustNotBeFollowedByBlankLine(currentNode.FirstChild);
                }
            }
        }

        /// <summary>
        /// Element documentation headers must be preceded by blank line.
        /// </summary>
        /// <param name="node">
        /// The node.
        /// </param>
        private void ElementDocumentationHeadersMustBePrecededByBlankLine(ITreeNode node)
        {
            // go back to first new line to the left
            // thisnew line must be immeidately preceded by a new line and if not insert one
            for (ITreeNode currentNode = node; currentNode != null; currentNode = currentNode.NextSibling)
            {
                if (currentNode is IDocCommentNode)
                {
                    ITokenNode token = currentNode as ITokenNode;
                    ITokenNode firstNewLineToLeft = Utils.GetFirstNewLineTokenToLeft(token);
                    if (firstNewLineToLeft != null)
                    {
                        ITokenNode tokenBeforeNewLine = firstNewLineToLeft.GetPrevToken();

                        // if we're the start of a code block then don't insert a new line.
                        if (!tokenBeforeNewLine.IsNewLine() && tokenBeforeNewLine.GetTokenType() != CSharpTokenType.LBRACE
                            && tokenBeforeNewLine.GetTokenType() != CSharpTokenType.END_OF_LINE_COMMENT)
                        {
                            firstNewLineToLeft.GetNextToken().InsertNewLineBefore();
                        }
                    }
                }

                if (currentNode.FirstChild != null)
                {
                    this.ElementDocumentationHeadersMustBePrecededByBlankLine(currentNode.FirstChild);
                }
            }
        }

        /// <summary>
        /// Opening curly brackets must not be preceded by blank line.
        /// </summary>
        /// <param name="node">
        /// The node.
        /// </param>
        private void OpeningCurlyBracketsMustNotBePrecededByBlankLine(ITreeNode node)
        {
            for (ITreeNode currentNode = node; currentNode != null; currentNode = currentNode.NextSibling)
            {
                if (currentNode is ITokenNode)
                {
                    ITokenNode tokenNode = currentNode as ITokenNode;

                    if (tokenNode.GetTokenType() == CSharpTokenType.LBRACE)
                    {
                        RemoveLineIfPreviousTokensAreNewLines(tokenNode);
                    }
                }

                if (currentNode.FirstChild != null)
                {
                    this.OpeningCurlyBracketsMustNotBePrecededByBlankLine(currentNode.FirstChild);
                }
            }
        }

        /// <summary>
        /// While do footer must not be preceded by blank line.
        /// </summary>
        /// <param name="node">
        /// The node.
        /// </param>
        private void WhileDoFooterMustNotBePrecededByBlankLine(ITreeNode node)
        {
            for (ITreeNode currentNode = node; currentNode != null; currentNode = currentNode.NextSibling)
            {
                if (currentNode is ITokenNode)
                {
                    ITokenNode tokenNode = currentNode as ITokenNode;

                    if (tokenNode.GetTokenType() == CSharpTokenType.WHILE_KEYWORD)
                    {
                        if (currentNode.Parent is IDoStatement)
                        {
                            RemoveLineIfPreviousTokensAreNewLines(tokenNode);
                        }
                    }
                }

                if (currentNode.FirstChild != null)
                {
                    this.WhileDoFooterMustNotBePrecededByBlankLine(currentNode.FirstChild);
                }
            }
        }

        #endregion
    }
}