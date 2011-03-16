//-----------------------------------------------------------------------
// <copyright file="ReadabilityRules.Statements.cs">
//   MS-PL
// </copyright>
// <license>
//   This source code is subject to terms and conditions of the Microsoft 
//   Public License. A copy of the license can be found in the License.html 
//   file at the root of this distribution. 
//   By using this source code in any fashion, you are agreeing to be bound 
//   by the terms of the Microsoft Public License. You must not remove this 
//   notice, or any other, from this software.
// </license>
//-----------------------------------------------------------------------
namespace StyleCop.CSharp.Rules
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using StyleCop;
    using StyleCop.CSharp.CodeModel;

    /// <content>
    /// Checks rules related to formatting of statements.
    /// </content>
    public partial class ReadabilityRules
    {
        #region Private Static Methods

        /// <summary>
        /// Gets the non-whitespace item that appears before the given item.
        /// </summary>
        /// <param name="item">The original item.</param>
        /// <returns>Returns the previous item.</returns>
        private static LexicalElement GetPreviousNonWhitespaceItem(CodeUnit item)
        {
            Param.AssertNotNull(item, "item");

            for (LexicalElement previous = item.FindPreviousLexicalElement(); previous != null; previous = previous.FindPreviousLexicalElement())
            {
                if (!previous.Is(LexicalElementType.EndOfLine) && !previous.Is(LexicalElementType.WhiteSpace))
                {
                    return previous;
                }
            }

            return null;
        }

        /// <summary>
        /// Gets the non-whitespace item that appears after the given item.
        /// </summary>
        /// <param name="item">The original item.</param>
        /// <returns>Returns the next item.</returns>
        private static CodeUnit GetNextNonWhitespaceItem(CodeUnit item)
        {
            Param.AssertNotNull(item, "item");

            for (CodeUnit next = item.FindNext(); next != null; next = next.FindNext())
            {
                if (!next.Is(LexicalElementType.EndOfLine) && !next.Is(LexicalElementType.WhiteSpace))
                {
                    return next;
                }
            }

            return null;
        }

        /// <summary>
        /// Gets the child block statement from the given statement. If the statement itself is a block statement,
        /// it will be returned instead.
        /// </summary>
        /// <param name="statement">The statement.</param>
        /// <returns>Returns the block statement or null if there is none.</returns>
        private static BlockStatement GetChildBlockStatement(Statement statement)
        {
            Param.AssertNotNull(statement, "statement");

            if (statement.StatementType == StatementType.Block)
            {
                return (BlockStatement)statement;
            }

            return statement.FindFirstChild<BlockStatement>();
        }

        /// <summary>
        /// Gets the opening curly bracket from the block statement.
        /// </summary>
        /// <param name="statement">The block statement.</param>
        /// <returns>Returns the opening curly bracket or null if there is none.</returns>
        private static OpenCurlyBracketToken GetOpeningCurlyBracketFromStatement(Statement statement)
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
                return blockStatement.FindFirstChild<OpenCurlyBracketToken>();
            }

            return null;
        }

        /// <summary>
        /// Gets the closing curly bracket from the block statement.
        /// </summary>
        /// <param name="statement">The block statement.</param>
        /// <returns>Returns the closing curly bracket or null if there is none.</returns>
        private static CloseCurlyBracketToken GetClosingBracketFromStatement(Statement statement)
        {
            Param.AssertNotNull(statement, "statement");

            BlockStatement blockStatement = GetChildBlockStatement(statement);
            if (blockStatement != null)
            {
                return blockStatement.FindFirstChild<CloseCurlyBracketToken>();
            }

            return null;
        }

        #endregion Private Static Methods

        #region Private Methods

        /// <summary>
        /// Checks the placement of statements within the given element.
        /// </summary>
        /// <param name="element">The element to check.</param>
        private void CheckStatementFormattingRulesForElement(Element element)
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
                    this.CheckStatementFormattingRulesForStatements(element, element);

                    for (Element child = element.FindFirstChildElement(); child != null; child = child.FindNextSiblingElement())
                    {
                        this.CheckStatementFormattingRulesForElement(child);
                    }
                }
            }
        }

        /// <summary>
        /// Checks the given list of statements.
        /// </summary>
        /// <param name="element">The element containing the statements.</param>
        /// <param name="statementParent">The parent of the statement to check.</param>
        private void CheckStatementFormattingRulesForStatements(Element element, CodeUnit statementParent)
        {
            Param.AssertNotNull(element, "element");
            Param.AssertNotNull(statementParent, "statementParent");

            Statement previousStatement = null;

            // Check each statement in the list.
            for (Statement statement = statementParent.FindFirstChildStatement(); statement != null; statement = statement.FindNextSiblingStatement())
            {
                this.CheckStatementFormattingRulesForStatement(element, statement, previousStatement);
                previousStatement = statement;
            }
        }

        /// <summary>
        /// Checks the placement of the given statement.
        /// </summary>
        /// <param name="element">The element containing the statement.</param>
        /// <param name="statement">The statement to check.</param>
        /// <param name="previousStatement">The statement just before this statement.</param>
        private void CheckStatementFormattingRulesForStatement(Element element, Statement statement, Statement previousStatement)
        {
            Param.AssertNotNull(element, "element");
            Param.AssertNotNull(statement, "statement");
            Param.Ignore(previousStatement);

            // Check if the statement is empty.
            if (statement.StatementType == StatementType.Empty)
            {
                Debug.Assert(statement.FindFirstDescendentToken() != null, "The statement has no tokens.");

                // There is a special case where an empty statement is allowed. In some cases, a label statement must be used to mark the end of a 
                // scope. C# requires that labels have at least one statement after them. In the developer wants to use a label to mark the end of the
                // scope, he does not want to put a statement after the label. The best course of action is to insert a single semicolon here. For example:\
                //    {
                //        if (true)
                //        {
                //            goto end;
                //        }
                //        end:;
                //    }
                if (previousStatement == null || previousStatement.StatementType != StatementType.Label)
                {
                    this.AddViolation(element, statement.LineNumber, Rules.CodeMustNotContainEmptyStatements);
                }
            }
            else if (previousStatement != null)
            {
                // Make sure this statement is not on the same line as the previous statement.
                Token statementFirstToken = statement.FindFirstDescendentToken();
                Token previousStatementLastToken = previousStatement.FindLastDescendentToken();

                if (statementFirstToken.Location.StartPoint.LineNumber ==
                    previousStatementLastToken.Location.EndPoint.LineNumber)
                {
                    this.AddViolation(element, statementFirstToken.LineNumber, Rules.CodeMustNotContainMultipleStatementsOnOneLine);
                }
            }

            // Check the curly bracket spacing in this statement.
            this.CheckStatementCurlyBracketPlacement(element, statement);

            // Check the child statements under this statement.
            this.CheckStatementFormattingRulesForStatements(element, statement);

            // Check the expressions under this statement.
            this.CheckStatementFormattingRulesForExpressions(element, statement);
        }

        /// <summary>
        /// Checks the given list of expressions.
        /// </summary>
        /// <param name="element">The element containing the expressions.</param>
        /// <param name="expressionParent">The parent of the expressions to check.</param>
        private void CheckStatementFormattingRulesForExpressions(Element element, CodeUnit expressionParent)
        {
            Param.AssertNotNull(element, "element");
            Param.AssertNotNull(expressionParent, "expressionParent");

            for (Expression expression = expressionParent.FindFirstChildExpression(); expression != null; expression = expression.FindNextSiblingExpression())
            {
                if (expression.ExpressionType == ExpressionType.AnonymousMethod)
                {
                    // Check the statements within this anonymous method expression.
                    AnonymousMethodExpression anonymousMethod = expression as AnonymousMethodExpression;
                    this.CheckStatementFormattingRulesForStatements(element, anonymousMethod);
                }
                else
                {
                    // Check the child expressions under this expression.
                    this.CheckStatementFormattingRulesForExpressions(element, expression);
                }
            }
        }

        /// <summary>
        /// Checks the curly bracket placement on a statement.
        /// </summary>
        /// <param name="element">The element containing the statement.</param>
        /// <param name="statement">The statement to check.</param>
        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Minimizing refactoring before release.")]
        private void CheckStatementCurlyBracketPlacement(Element element, Statement statement)
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
        /// Checks the curly bracket placement on a block statement.
        /// </summary>
        /// <param name="element">The element containing the statement.</param>
        /// <param name="statement">The statement to check.</param>
        private void CheckBlockStatementsCurlyBracketPlacement(Element element, Statement statement)
        {
            Param.AssertNotNull(element, "element");
            Param.AssertNotNull(statement, "statement");

            // Find the opening curly bracket.
            var curlyBracket = GetOpeningCurlyBracketFromStatement(statement);
            if (curlyBracket != null)
            {
                // Find the previous item before this opening curly bracket.
                var previousItem = GetPreviousNonWhitespaceItem(curlyBracket.FindPrevious());
                if (previousItem != null)
                {
                    this.CheckTokenPrecedingOrFollowingCurlyBracket(element, previousItem);
                }
            }
        }

        /// <summary>
        /// Checks the curly bracket placement on a statement which is chained from another statement.
        /// </summary>
        /// <param name="element">The element containing the statement.</param>
        /// <param name="statement">The statement to check.</param>
        private void CheckChainedStatementCurlyBracketPlacement(Element element, Statement statement)
        {
            Param.AssertNotNull(element, "element");
            Param.AssertNotNull(statement, "statement");

            // Get the previous token before the start of this statement.
            if (statement.FindFirstChildToken() != null)
            {
                // Find the opening curly bracket.
                var curlyBracket = GetOpeningCurlyBracketFromStatement(statement);
                if (curlyBracket != null)
                {
                    // Find the previous token before this opening curly bracket.
                    var previousItem = GetPreviousNonWhitespaceItem(curlyBracket.FindPrevious());
                    if (previousItem != null)
                    {
                        this.CheckTokenPrecedingOrFollowingCurlyBracket(element, previousItem);
                    }
                }
            }
        }

        /// <summary>
        /// Checks the curly at the end of a statement which trails the rest of the statement.
        /// </summary>
        /// <param name="element">The element containing the statement.</param>
        /// <param name="statement">The statement to check.</param>
        private void CheckTrailingStatementCurlyBracketPlacement(Element element, Statement statement)
        {
            Param.AssertNotNull(element, "element");
            Param.AssertNotNull(statement, "statement");

            var curlyBracket = GetClosingBracketFromStatement(statement);
            if (curlyBracket != null)
            {
                // Find the next token after this closing curly bracket.
                var nextItem = GetNextNonWhitespaceItem(curlyBracket.FindNext());
                if (nextItem != null)
                {
                    this.CheckTokenPrecedingOrFollowingCurlyBracket(element, nextItem);
                }
            }
        }

        /// <summary>
        /// Checks the item that follows or precedes a curly bracket in a blocked statement to verify
        /// that there is no comment or region embedded within the statement.
        /// </summary>
        /// <param name="element">The element containing the statement.</param>
        /// <param name="previousOrNextItem">The previous or next item.</param>
        private void CheckTokenPrecedingOrFollowingCurlyBracket(Element element, CodeUnit previousOrNextItem)
        {
            Param.AssertNotNull(element, "element");
            Param.AssertNotNull(previousOrNextItem, "previousOrNextItem");

            if (previousOrNextItem.Is(LexicalElementType.Comment) || previousOrNextItem.Is(CodeUnitType.ElementHeader))
            {
                this.AddViolation(element, previousOrNextItem.LineNumber, Rules.BlockStatementsMustNotContainEmbeddedComments);
            }
            else if (previousOrNextItem.Is(PreprocessorType.Region) || previousOrNextItem.Is(PreprocessorType.EndRegion))
            {
                this.AddViolation(element, previousOrNextItem.LineNumber, Rules.BlockStatementsMustNotContainEmbeddedRegions);
            }
        }

        #endregion Private Methods
    }
}
