// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReadabilityRules.Statements.cs" company="https://github.com/StyleCop">
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
//   The readability rules.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// The readability rules.
    /// </summary>
    /// <content>
    /// Checks rules related to formatting of statements.
    /// </content>
    public partial class ReadabilityRules
    {
        #region Methods

        /// <summary>
        /// Gets the child block statement from the given statement. If the statement itself is a block statement,
        /// it will be returned instead.
        /// </summary>
        /// <param name="statement">
        /// The statement.
        /// </param>
        /// <returns>
        /// Returns the block statement or null if there is none.
        /// </returns>
        private static BlockStatement GetChildBlockStatement(Statement statement)
        {
            Param.AssertNotNull(statement, "statement");

            BlockStatement blockStatement = null;
            if (statement.StatementType == StatementType.Block)
            {
                blockStatement = statement as BlockStatement;
            }

            if (blockStatement == null)
            {
                foreach (Statement childStatement in statement.ChildStatements)
                {
                    if (childStatement.StatementType == StatementType.Block)
                    {
                        blockStatement = childStatement as BlockStatement;
                        break;
                    }
                }
            }

            return blockStatement;
        }

        /// <summary>
        /// Gets the closing curly bracket from the block statement.
        /// </summary>
        /// <param name="statement">
        /// The block statement.
        /// </param>
        /// <returns>
        /// Returns the closing curly bracket or null if there is none.
        /// </returns>
        private static Node<CsToken> GetClosingBracketFromStatement(Statement statement)
        {
            Param.AssertNotNull(statement, "statement");

            BlockStatement blockStatement = GetChildBlockStatement(statement);
            if (blockStatement != null)
            {
                for (Node<CsToken> tokenNode = blockStatement.Tokens.Last; tokenNode != null; tokenNode = tokenNode.Previous)
                {
                    if (tokenNode.Value.CsTokenType == CsTokenType.CloseCurlyBracket)
                    {
                        return tokenNode;
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Gets the non-whitespace token that appears after the given token.
        /// </summary>
        /// <param name="tokenNode">
        /// The token node.
        /// </param>
        /// <param name="tokenList">
        /// The list that contains the token.
        /// </param>
        /// <returns>
        /// Returns the next token.
        /// </returns>
        private static CsToken GetNextToken(Node<CsToken> tokenNode, MasterList<CsToken> tokenList)
        {
            Param.AssertNotNull(tokenNode, "tokenNode");
            Param.AssertNotNull(tokenList, "tokenList");

            foreach (CsToken temp in tokenList.ForwardIterator(tokenNode))
            {
                if (temp.CsTokenType != CsTokenType.EndOfLine && temp.CsTokenType != CsTokenType.WhiteSpace)
                {
                    return temp;
                }
            }

            return null;
        }

        /// <summary>
        /// Gets the opening curly bracket from the block statement.
        /// </summary>
        /// <param name="statement">
        /// The block statement.
        /// </param>
        /// <returns>
        /// Returns the opening curly bracket or null if there is none.
        /// </returns>
        private static Node<CsToken> GetOpeningCurlyBracketFromStatement(Statement statement)
        {
            Param.AssertNotNull(statement, "statement");

            Statement blockStatement = null;

            // We have to match a special case for switch statement because they are the only bracketed
            // statements which do not have a child block statement, due to the current design of the parser.
            // It's a bit annoying to put the special case here, but not too bad.
            if (statement.StatementType == StatementType.Switch)
            {
                blockStatement = statement;
            }
            else
            {
                blockStatement = GetChildBlockStatement(statement);
            }

            if (blockStatement != null)
            {
                for (Node<CsToken> tokenNode = blockStatement.Tokens.First; tokenNode != null; tokenNode = tokenNode.Next)
                {
                    if (tokenNode.Value.CsTokenType == CsTokenType.OpenCurlyBracket)
                    {
                        return tokenNode;
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Gets the non-whitespace token that appears before the given token.
        /// </summary>
        /// <param name="tokenNode">
        /// The token node.
        /// </param>
        /// <param name="tokenList">
        /// The list that contains the token.
        /// </param>
        /// <returns>
        /// Returns the previous token.
        /// </returns>
        private static CsToken GetPreviousToken(Node<CsToken> tokenNode, MasterList<CsToken> tokenList)
        {
            Param.AssertNotNull(tokenNode, "tokenNode");
            Param.AssertNotNull(tokenList, "tokenList");

            foreach (CsToken temp in tokenList.ReverseIterator(tokenNode))
            {
                if (temp.CsTokenType != CsTokenType.EndOfLine && temp.CsTokenType != CsTokenType.WhiteSpace)
                {
                    return temp;
                }
            }

            return null;
        }

        /// <summary>
        /// Checks the curly bracket placement on a block statement.
        /// </summary>
        /// <param name="element">
        /// The element containing the statement.
        /// </param>
        /// <param name="statement">
        /// The statement to check.
        /// </param>
        private void CheckBlockStatementsCurlyBracketPlacement(CsElement element, Statement statement)
        {
            Param.AssertNotNull(element, "element");
            Param.AssertNotNull(statement, "statement");

            // Find the opening curly bracket.
            Node<CsToken> curlyBracket = GetOpeningCurlyBracketFromStatement(statement);
            if (curlyBracket != null)
            {
                // Find the previous token before this opening curly bracket.
                CsToken previousToken = GetPreviousToken(curlyBracket.Previous, statement.Tokens.MasterList);
                if (previousToken != null)
                {
                    this.CheckTokenPrecedingOrFollowingCurlyBracket(element, previousToken);
                }
            }
        }

        /// <summary>
        /// Checks the curly bracket placement on a statement which is chained from another statement.
        /// </summary>
        /// <param name="element">
        /// The element containing the statement.
        /// </param>
        /// <param name="statement">
        /// The statement to check.
        /// </param>
        private void CheckChainedStatementCurlyBracketPlacement(CsElement element, Statement statement)
        {
            Param.AssertNotNull(element, "element");
            Param.AssertNotNull(statement, "statement");

            // Get the previous token before the start of this statement.
            if (statement.Tokens.First != null)
            {
                // Find the opening curly bracket.
                Node<CsToken> curlyBracket = GetOpeningCurlyBracketFromStatement(statement);
                if (curlyBracket != null)
                {
                    // Find the previous token before this opening curly bracket.
                    CsToken previousToken = GetPreviousToken(curlyBracket.Previous, statement.Tokens.MasterList);
                    if (previousToken != null)
                    {
                        this.CheckTokenPrecedingOrFollowingCurlyBracket(element, previousToken);
                    }
                }
            }
        }

        /// <summary>
        /// Checks the curly bracket placement on a statement.
        /// </summary>
        /// <param name="element">
        /// The element containing the statement.
        /// </param>
        /// <param name="statement">
        /// The statement to check.
        /// </param>
        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Minimizing refactoring before release.")]
        private void CheckStatementCurlyBracketPlacement(CsElement element, Statement statement)
        {
            Param.AssertNotNull(element, "element");
            Param.AssertNotNull(statement, "statement");

            switch (statement.StatementType)
            {
                case StatementType.Else:

                    // Check that there is nothing between the starting else keyword and the opening bracket.
                    this.CheckChainedStatementCurlyBracketPlacement(element, statement);
                    this.CheckBlockStatementsCurlyBracketPlacement(element, statement);

                    // Check that there is nothing between the closing bracket and the else keyword of the attached else statement.
                    ElseStatement elseStatement = (ElseStatement)statement;
                    if (elseStatement.AttachedElseStatement != null)
                    {
                        this.CheckTrailingStatementCurlyBracketPlacement(element, statement);
                    }

                    break;

                case StatementType.Catch:
                case StatementType.Finally:

                    // Check that there is nothing between the starting catch or finally keyword and the opening bracket.
                    this.CheckChainedStatementCurlyBracketPlacement(element, statement);
                    this.CheckBlockStatementsCurlyBracketPlacement(element, statement);
                    break;

                case StatementType.If:
                    this.CheckBlockStatementsCurlyBracketPlacement(element, statement);

                    // Check that there is nothing between the closing bracket and the else keyword of the attached else statement.
                    IfStatement ifStatement = (IfStatement)statement;
                    if (ifStatement.AttachedElseStatement != null)
                    {
                        this.CheckTrailingStatementCurlyBracketPlacement(element, statement);
                    }

                    break;

                case StatementType.Try:

                    // Check that there is nothing between the starting try keyword and the opening bracket.
                    this.CheckBlockStatementsCurlyBracketPlacement(element, statement);

                    TryStatement tryStatement = (TryStatement)statement;
                    if (tryStatement.FinallyStatement != null || (tryStatement.CatchStatements != null && tryStatement.CatchStatements.Count > 0))
                    {
                        // There is something attached to the end of this try statement. Check that there is nothing between
                        // the closing bracket of the try statement and the start of the attached statement.
                        this.CheckTrailingStatementCurlyBracketPlacement(element, tryStatement);
                    }

                    if (tryStatement.CatchStatements != null && tryStatement.CatchStatements.Count > 0)
                    {
                        CatchStatement[] catchStatementArray = new CatchStatement[tryStatement.CatchStatements.Count];
                        tryStatement.CatchStatements.CopyTo(catchStatementArray, 0);

                        for (int i = 0; i < catchStatementArray.Length; ++i)
                        {
                            if (catchStatementArray.Length > i + 1 || tryStatement.FinallyStatement != null)
                            {
                                // There is something attached to the end of this catch statement, either another catch or a finally.
                                // Check that there is nothing between the closing bracket of this catch statement and the start of the attached
                                // statement.
                                this.CheckTrailingStatementCurlyBracketPlacement(element, catchStatementArray[i]);
                            }
                        }
                    }

                    break;

                case StatementType.Checked:
                case StatementType.Fixed:
                case StatementType.For:
                case StatementType.Foreach:
                case StatementType.Lock:
                case StatementType.Switch:
                case StatementType.Unchecked:
                case StatementType.Unsafe:
                case StatementType.Using:
                case StatementType.While:

                    // Check that there is nothing between the starting keyword and the opening bracket.
                    this.CheckBlockStatementsCurlyBracketPlacement(element, statement);
                    break;

                case StatementType.DoWhile:
                    this.CheckBlockStatementsCurlyBracketPlacement(element, statement);
                    this.CheckTrailingStatementCurlyBracketPlacement(element, statement);
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// Checks the placement of statements within the given element.
        /// </summary>
        /// <param name="element">
        /// The element to check.
        /// </param>
        private void CheckStatementFormattingRulesForElement(CsElement element)
        {
            Param.AssertNotNull(element, "element");

            if (!element.Generated)
            {
                if (element.ElementType == ElementType.EmptyElement)
                {
                    this.AddViolation(element, element.LineNumber, Rules.CodeMustNotContainEmptyStatements);
                }
                else
                {
                    this.CheckStatementFormattingRulesForStatements(element, element.ChildStatements);

                    foreach (CsElement child in element.ChildElements)
                    {
                        this.CheckStatementFormattingRulesForElement(child);
                    }
                }
            }
        }

        /// <summary>
        /// Checks the given list of expressions.
        /// </summary>
        /// <param name="element">
        /// The element containing the expressions.
        /// </param>
        /// <param name="expressions">
        /// The list of expressions.
        /// </param>
        private void CheckStatementFormattingRulesForExpressions(CsElement element, ICollection<Expression> expressions)
        {
            Param.AssertNotNull(element, "element");
            Param.AssertNotNull(expressions, "expressions");

            foreach (Expression expression in expressions)
            {
                if (expression.ExpressionType == ExpressionType.AnonymousMethod)
                {
                    // Check the statements within this anonymous method expression.
                    AnonymousMethodExpression anonymousMethod = expression as AnonymousMethodExpression;
                    this.CheckStatementFormattingRulesForStatements(element, anonymousMethod.ChildStatements);
                }
                else
                {
                    // Check the child expressions under this expression.
                    this.CheckStatementFormattingRulesForExpressions(element, expression.ChildExpressions);
                }
            }
        }

        /// <summary>
        /// Checks the placement of the given statement.
        /// </summary>
        /// <param name="element">
        /// The element containing the statement.
        /// </param>
        /// <param name="statement">
        /// The statement to check.
        /// </param>
        /// <param name="previousStatement">
        /// The statement just before this statement.
        /// </param>
        private void CheckStatementFormattingRulesForStatement(CsElement element, Statement statement, Statement previousStatement)
        {
            Param.AssertNotNull(element, "element");
            Param.AssertNotNull(statement, "statement");
            Param.Ignore(previousStatement);

            // Check if the statement is empty.
            if (statement.StatementType == StatementType.Empty)
            {
                Debug.Assert(statement.Tokens.First != null, "The statement has no tokens.");

                // There is a special case where an empty statement is allowed. In some cases, a label statement must be used to mark the end of a 
                // scope. C# requires that labels have at least one statement after them. In the developer wants to use a label to mark the end of the
                // scope, he does not want to put a statement after the label. The best course of action is to insert a single semicolon here. For example:\
                ////    {
                ////       if (true)
                ////        {
                ////            goto end;
                ////        }
                ////        end:;
                ////    }
                if (previousStatement == null || previousStatement.StatementType != StatementType.Label)
                {
                    this.AddViolation(element, statement.LineNumber, Rules.CodeMustNotContainEmptyStatements);
                }
            }
            else if (previousStatement != null)
            {
                // Make sure this statement is not on the same line as the previous statement.
                Node<CsToken> statementFirstTokenNode = statement.Tokens.First;
                Node<CsToken> previousStatementLastTokenNode = previousStatement.Tokens.Last;

                if (statementFirstTokenNode.Value.Location.StartPoint.LineNumber == previousStatementLastTokenNode.Value.Location.EndPoint.LineNumber)
                {
                    this.AddViolation(element, statementFirstTokenNode.Value.LineNumber, Rules.CodeMustNotContainMultipleStatementsOnOneLine);
                }
            }

            // Check the curly bracket spacing in this statement.
            this.CheckStatementCurlyBracketPlacement(element, statement);

            // Check the child statements under this statement.
            this.CheckStatementFormattingRulesForStatements(element, statement.ChildStatements);

            // Check the expressions under this statement.
            this.CheckStatementFormattingRulesForExpressions(element, statement.ChildExpressions);
        }

        /// <summary>
        /// Checks the given list of statements.
        /// </summary>
        /// <param name="element">
        /// The element containing the statements.
        /// </param>
        /// <param name="statements">
        /// The list of statements.
        /// </param>
        private void CheckStatementFormattingRulesForStatements(CsElement element, ICollection<Statement> statements)
        {
            Param.AssertNotNull(element, "element");
            Param.AssertNotNull(statements, "statements");

            Statement previousStatement = null;

            // Check each statement in the list.
            foreach (Statement statement in statements)
            {
                this.CheckStatementFormattingRulesForStatement(element, statement, previousStatement);
                previousStatement = statement;
            }
        }

        /// <summary>
        /// Checks the token that follows or precedes a curly bracket in a blocked statement to verify
        /// that there is no comment or region embedded within the statement.
        /// </summary>
        /// <param name="element">
        /// The element containing the statement.
        /// </param>
        /// <param name="previousOrNextToken">
        /// The previous or next token.
        /// </param>
        private void CheckTokenPrecedingOrFollowingCurlyBracket(CsElement element, CsToken previousOrNextToken)
        {
            Param.AssertNotNull(element, "element");
            Param.AssertNotNull(previousOrNextToken, "previousOrNextToken");

            if (previousOrNextToken.CsTokenType == CsTokenType.MultiLineComment || previousOrNextToken.CsTokenType == CsTokenType.SingleLineComment
                || previousOrNextToken.CsTokenType == CsTokenType.XmlHeader || previousOrNextToken.CsTokenType == CsTokenType.XmlHeaderLine)
            {
                if (!Utils.IsAReSharperComment(previousOrNextToken))
                {
                    this.AddViolation(element, previousOrNextToken.LineNumber, Rules.BlockStatementsMustNotContainEmbeddedComments);
                }
            }
            else if (previousOrNextToken.CsTokenType == CsTokenType.PreprocessorDirective && previousOrNextToken is Region)
            {
                this.AddViolation(element, previousOrNextToken.LineNumber, Rules.BlockStatementsMustNotContainEmbeddedRegions);
            }
        }

        /// <summary>
        /// Checks the curly at the end of a statement which trails the rest of the statement.
        /// </summary>
        /// <param name="element">
        /// The element containing the statement.
        /// </param>
        /// <param name="statement">
        /// The statement to check.
        /// </param>
        private void CheckTrailingStatementCurlyBracketPlacement(CsElement element, Statement statement)
        {
            Param.AssertNotNull(element, "element");
            Param.AssertNotNull(statement, "statement");

            Node<CsToken> curlyBracket = GetClosingBracketFromStatement(statement);
            if (curlyBracket != null)
            {
                // Find the next token after this closing curly bracket.
                CsToken nextToken = GetNextToken(curlyBracket.Next, statement.Tokens.MasterList);
                if (nextToken != null)
                {
                    this.CheckTokenPrecedingOrFollowingCurlyBracket(element, nextToken);
                }
            }
        }

        #endregion
    }
}