// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CodeParser.Statements.cs" company="https://github.com/StyleCop">
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
//   The code parser.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// The code parser.
    /// </summary>
    /// <content>
    /// Contains code for parsing statements within a C# code file.
    /// </content>
    internal partial class CodeParser
    {
        #region Methods

        /// <summary>
        /// Looks for a catch-statement, and if it is found, parses and returns it.
        /// </summary>
        /// <param name="tryStatement">
        /// The parent try statement.
        /// </param>
        /// <param name="parentReference">
        /// The parent code unit.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code being parsed resides in an unsafe code block.
        /// </param>
        /// <returns>
        /// Returns the statement.
        /// </returns>
        private CatchStatement GetAttachedCatchStatement(TryStatement tryStatement, Reference<ICodePart> parentReference, bool unsafeCode)
        {
            Param.AssertNotNull(tryStatement, "tryStatement");
            Param.AssertNotNull(parentReference, "parentReference");
            Param.Ignore(unsafeCode);

            CatchStatement catchStatement = null;

            // Look for a catch keyword.
            Symbol symbol = this.GetNextSymbol(parentReference);
            if (symbol.SymbolType == SymbolType.Catch)
            {
                Reference<ICodePart> statementReference = new Reference<ICodePart>();

                // Move up to the catch keyword and add it.
                CsToken firstToken = this.GetToken(CsTokenType.Catch, SymbolType.Catch, statementReference);
                Node<CsToken> firstTokenNode = this.tokens.InsertLast(firstToken);

                Expression catchExpression = null;

                // Get the opening parenthesis, if there is one.
                symbol = this.GetNextSymbol(statementReference);
                if (symbol.SymbolType == SymbolType.OpenParenthesis)
                {
                    Bracket openParenthesis = this.GetBracketToken(CsTokenType.OpenParenthesis, SymbolType.OpenParenthesis, statementReference);
                    Node<CsToken> openParenthesisNode = this.tokens.InsertLast(openParenthesis);

                    // Get the type, if there is one.
                    symbol = this.GetNextSymbol(statementReference);
                    if (symbol.SymbolType == SymbolType.Other)
                    {
                        catchExpression = this.GetNextExpression(ExpressionPrecedence.None, statementReference, unsafeCode, true, true);
                    }

                    // Get the closing parenthesis.
                    Bracket closeParenthesis = this.GetBracketToken(CsTokenType.CloseParenthesis, SymbolType.CloseParenthesis, statementReference);
                    Node<CsToken> closeParenthesisNode = this.tokens.InsertLast(closeParenthesis);

                    openParenthesis.MatchingBracketNode = closeParenthesisNode;
                    closeParenthesis.MatchingBracketNode = openParenthesisNode;
                }

                BlockStatement childStatement = null;
                Statement nextStatement = this.GetNextStatement(statementReference, unsafeCode);

                // Search if when statement is present. C# 6.
                WhenStatement whenStatement = nextStatement as WhenStatement;
                if (whenStatement != null)
                {
                    // Get the embedded statement. This must be a block statement.
                    childStatement = this.GetNextStatement(statementReference, unsafeCode) as BlockStatement;
                }
                else
                {
                    childStatement = nextStatement as BlockStatement;
                }

                if (childStatement == null)
                {
                    throw new SyntaxException(this.document.SourceCode, firstToken.LineNumber);
                }

                // Create the token list for the statement.
                CsTokenList partialTokens = new CsTokenList(this.tokens, firstTokenNode, this.tokens.Last);

                // Create the catch statement.
                catchStatement = new CatchStatement(partialTokens, tryStatement, catchExpression, childStatement, whenStatement);
                ((IWriteableCodeUnit)catchStatement).SetParent(tryStatement);
                statementReference.Target = catchStatement;

                if (catchStatement.ClassType != null && catchStatement.Identifier != null)
                {
                    // Add the variable.
                    Variable variable = new Variable(
                        catchStatement.ClassType,
                        catchStatement.Identifier.Text,
                        VariableModifiers.None,
                        CodeLocation.Join(catchStatement.ClassType.Location, catchStatement.Identifier.Location),
                        statementReference,
                        catchStatement.ClassType.Generated);

                    // If there is already a variable in this scope with the same name, ignore this one.
                    if (!catchStatement.Variables.Contains(catchStatement.Identifier.Text))
                    {
                        catchStatement.Variables.Add(variable);
                    }
                }
            }

            return catchStatement;
        }

        /// <summary>
        /// Looks for an else-statement, and if it is found, parses and returns it.
        /// </summary>
        /// <param name="parentReference">
        /// The parent code unit.
        /// </param>
        /// <param name="parentStatement">
        /// The parent of the else-statement.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code being parsed resides in an unsafe code block.
        /// </param>
        /// <returns>
        /// Returns the statement.
        /// </returns>
        private ElseStatement GetAttachedElseStatement(Reference<ICodePart> parentReference, Statement parentStatement, bool unsafeCode)
        {
            Param.AssertNotNull(parentReference, "parentReference");
            Param.AssertNotNull(parentStatement, "parentStatement");
            Param.Ignore(unsafeCode);

            ElseStatement statement = null;

            // Check if the next keyword is an else.
            Symbol symbol = this.GetNextSymbol(parentReference);
            if (symbol.SymbolType == SymbolType.Else)
            {
                Reference<ICodePart> statementReference = new Reference<ICodePart>();

                // Advance to this keyword and add it.
                Node<CsToken> firstTokenNode = this.tokens.InsertLast(this.GetToken(CsTokenType.Else, SymbolType.Else, statementReference));

                // Check if the next keyword is an if.
                Expression conditional = null;

                symbol = this.GetNextSymbol(statementReference);
                if (symbol != null && symbol.SymbolType == SymbolType.If)
                {
                    // Advance to this keyword and add it.
                    this.tokens.Add(this.GetToken(CsTokenType.If, SymbolType.If, statementReference));

                    // Get the opening parenthesis.
                    Bracket openParenthesis = this.GetBracketToken(CsTokenType.OpenParenthesis, SymbolType.OpenParenthesis, statementReference);
                    Node<CsToken> openParenthesisNode = this.tokens.InsertLast(openParenthesis);

                    // Get the expression within the parenthesis.
                    conditional = this.GetNextExpression(ExpressionPrecedence.None, statementReference, unsafeCode);
                    if (conditional == null)
                    {
                        throw new SyntaxException(this.document.SourceCode, symbol.LineNumber);
                    }

                    // Get the closing parenthesis.
                    Bracket closeParenthesis = this.GetBracketToken(CsTokenType.CloseParenthesis, SymbolType.CloseParenthesis, statementReference);
                    Node<CsToken> closeParenthesisNode = this.tokens.InsertLast(closeParenthesis);

                    openParenthesis.MatchingBracketNode = closeParenthesisNode;
                    closeParenthesis.MatchingBracketNode = openParenthesisNode;
                }

                // Get the embedded statement.
                Statement childStatement = this.GetNextStatement(statementReference, unsafeCode);
                if (childStatement == null)
                {
                    throw this.CreateSyntaxException();
                }

                // Create the token list for the statement.
                CsTokenList partialTokens = new CsTokenList(this.tokens, firstTokenNode, this.tokens.Last);

                // Create the else-statement.
                statement = new ElseStatement(partialTokens, conditional);
                statement.EmbeddedStatement = childStatement;
                ((IWriteableCodeUnit)statement).SetParent(parentStatement);

                // Check if there is another else or an else-if attached to this statement.
                ElseStatement attached = this.GetAttachedElseStatement(statementReference, statement, unsafeCode);
                if (attached != null)
                {
                    statement.AttachedElseStatement = attached;
                }

                statementReference.Target = statement;
            }

            return statement;
        }

        /// <summary>
        /// Looks for a finally-statement, and if it is found, parses and returns it.
        /// </summary>
        /// <param name="tryStatement">
        /// The parent try statement.
        /// </param>
        /// <param name="parentReference">
        /// The parent code unit.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code being parsed resides in an unsafe code block.
        /// </param>
        /// <returns>
        /// Returns the statement.
        /// </returns>
        private FinallyStatement GetAttachedFinallyStatement(TryStatement tryStatement, Reference<ICodePart> parentReference, bool unsafeCode)
        {
            Param.AssertNotNull(tryStatement, "tryStatement");
            Param.AssertNotNull(parentReference, "parentReference");
            Param.Ignore(unsafeCode);

            FinallyStatement finallyStatement = null;

            // Look for a finally keyword.
            Symbol symbol = this.GetNextSymbol(parentReference);
            if (symbol.SymbolType == SymbolType.Finally)
            {
                Reference<ICodePart> statementReference = new Reference<ICodePart>();

                // Move up to the finally keyword and add it.
                CsToken firstToken = this.GetToken(CsTokenType.Finally, SymbolType.Finally, statementReference);
                Node<CsToken> firstTokenNode = this.tokens.InsertLast(firstToken);

                // Get the embedded statement. This must be a block statement.
                BlockStatement childStatement = this.GetNextStatement(statementReference, unsafeCode) as BlockStatement;
                if (childStatement == null)
                {
                    throw new SyntaxException(this.document.SourceCode, firstToken.LineNumber);
                }

                // Create the token list for the statement.
                CsTokenList partialTokens = new CsTokenList(this.tokens, firstTokenNode, this.tokens.Last);

                // Create and return the finally statement.
                finallyStatement = new FinallyStatement(partialTokens, tryStatement, childStatement);
                ((IWriteableCodeUnit)finallyStatement).SetParent(tryStatement);
                statementReference.Target = finallyStatement;
            }

            return finallyStatement;
        }

        /// <summary>
        /// Reads the next statement from the file and returns it.
        /// </summary>
        /// <param name="parentReference">
        /// The parent code part.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code being parsed resides in an unsafe code block.
        /// </param>
        /// <returns>
        /// Returns the statement.
        /// </returns>
        private Statement GetNextStatement(Reference<ICodePart> parentReference, bool unsafeCode)
        {
            Param.AssertNotNull(parentReference, "parentReference");
            Param.Ignore(unsafeCode);

            return this.GetNextStatement(parentReference, unsafeCode, null);
        }

        /// <summary>
        /// Reads the next statement from the file and returns it.
        /// </summary>
        /// <param name="parentReference">
        /// The parent code part.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code being parsed resides in an unsafe code block.
        /// </param>
        /// <param name="variables">
        /// Returns the list of variables defined in the statement.
        /// </param>
        /// <returns>
        /// Returns the statement.
        /// </returns>
        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "May be simplified later.")]
        private Statement GetNextStatement(Reference<ICodePart> parentReference, bool unsafeCode, VariableCollection variables)
        {
            Param.AssertNotNull(parentReference, "parentReference");
            Param.Ignore(unsafeCode);
            Param.Ignore(variables);

            // Saves the next statement.
            Statement statement = null;

            // Move past comments and whitepace.
            if (this.MoveToStatement(parentReference))
            {
                // Get the next symbol.
                Symbol symbol = this.GetNextSymbol(parentReference);
                if (symbol != null)
                {
                    switch (symbol.SymbolType)
                    {
                        case SymbolType.True:
                        case SymbolType.False:
                        case SymbolType.Other:
                        case SymbolType.Number:
                        case SymbolType.String:
                            if (symbol.Text == "yield")
                            {
                                statement = this.ParseYieldStatement(parentReference, unsafeCode);
                                if (statement != null)
                                {
                                    break;
                                }
                            }

                            if (symbol.Text == "await")
                            {
                                statement = this.ParseAwaitStatement(parentReference, unsafeCode);
                                if (statement != null)
                                {
                                    break;
                                }
                            }

                            if (symbol.Text == "when")
                            {
                                if (this.IsWhenExpression())
                                {
                                    statement = this.ParseWhenStatement(parentReference, unsafeCode);
                                    if (statement != null)
                                    {
                                        break;
                                    }
                                }
                            }

                            if (this.IsLocalFunctionStatement(symbol))
                            {
                                statement = this.ParseLocalFunctionStatement(unsafeCode);
                                break;
                            }

                            statement = this.ParseOtherStatement(parentReference, unsafeCode, variables);
                            break;

                        case SymbolType.OpenCurlyBracket:
                            statement = this.ParseBlockStatement(unsafeCode);
                            break;

                        case SymbolType.If:
                            statement = this.ParseIfStatement(parentReference, unsafeCode);
                            break;

                        case SymbolType.While:
                            statement = this.ParseWhileStatement(parentReference, unsafeCode);
                            break;

                        case SymbolType.Do:
                            statement = this.ParseDoWhileStatement(parentReference, unsafeCode);
                            break;

                        case SymbolType.For:
                            statement = this.ParseForStatement(parentReference, unsafeCode);
                            break;

                        case SymbolType.Foreach:
                            statement = this.ParseForeachStatement(parentReference, unsafeCode);
                            break;

                        case SymbolType.Switch:
                            statement = this.ParseSwitchStatement(parentReference, unsafeCode);
                            break;

                        case SymbolType.Try:
                            statement = this.ParseTryStatement(parentReference, unsafeCode);
                            break;

                        case SymbolType.Lock:
                            statement = this.ParseLockStatement(parentReference, unsafeCode);
                            break;

                        case SymbolType.Using:
                            statement = this.ParseUsingStatement(parentReference, unsafeCode);
                            break;

                        case SymbolType.Checked:
                            statement = this.ParseCheckedStatement(parentReference, unsafeCode);
                            break;

                        case SymbolType.Unchecked:
                            statement = this.ParseUncheckedStatement(parentReference, unsafeCode);
                            break;

                        case SymbolType.Fixed:
                            statement = this.ParseFixedStatement(parentReference, unsafeCode);
                            break;

                        case SymbolType.Unsafe:
                            statement = this.ParseUnsafeStatement(parentReference);
                            break;

                        case SymbolType.Break:
                            statement = this.ParseBreakStatement(parentReference);
                            break;

                        case SymbolType.Continue:
                            statement = this.ParseContinueStatement(parentReference);
                            break;

                        case SymbolType.Goto:
                            statement = this.ParseGotoStatement(parentReference, unsafeCode);
                            break;

                        case SymbolType.Return:
                            statement = this.ParseReturnStatement(parentReference, unsafeCode);
                            break;

                        case SymbolType.Throw:
                            statement = this.ParseThrowStatement(parentReference, unsafeCode);
                            break;

                        case SymbolType.Typeof:
                        case SymbolType.Sizeof:
                        case SymbolType.Default:
                        case SymbolType.Lambda:
                            statement = this.ParseExpressionStatement(unsafeCode);
                            break;

                        case SymbolType.Const:
                            statement = this.ParseVariableDeclarationStatement(parentReference, unsafeCode, variables);
                            break;

                        case SymbolType.Ref:
                            if (this.IsLocalFunctionStatement(symbol))
                            {
                                statement = this.ParseLocalFunctionStatement(unsafeCode);
                            }
                            else
                            {
                                statement = this.ParseVariableDeclarationStatement(parentReference, unsafeCode, variables);
                            }

                            break;

                        case SymbolType.Increment:
                        case SymbolType.Decrement:
                        case SymbolType.New:
                        case SymbolType.This:
                        case SymbolType.Base:
                        case SymbolType.OpenParenthesis:
                            statement = this.DetectAndGetStatementForOpenParenthesis(parentReference, unsafeCode, variables);
                            break;

                        case SymbolType.Semicolon:
                            Reference<ICodePart> emptyStatementReference = new Reference<ICodePart>();
                            Node<CsToken> tokenNode = this.tokens.InsertLast(this.GetToken(CsTokenType.Semicolon, SymbolType.Semicolon, emptyStatementReference));

                            statement = new EmptyStatement(new CsTokenList(this.tokens, tokenNode, tokenNode));
                            emptyStatementReference.Target = statement;
                            break;

                        case SymbolType.Multiplication:
                            if (!unsafeCode)
                            {
                                goto default;
                            }

                            statement = this.ParseExpressionStatement(unsafeCode);
                            break;

                        case SymbolType.LogicalAnd:
                            if (!unsafeCode)
                            {
                                goto default;
                            }

                            statement = this.ParseExpressionStatement(unsafeCode);
                            break;

                        default:

                            throw new SyntaxException(this.document.SourceCode, symbol.LineNumber);
                    }
                }
            }

            return statement;
        }

        /// <summary>
        /// Determines whether [is when expression].
        /// </summary>
        /// <returns>True if when expression else false</returns>
        private bool IsWhenExpression()
        {
            // Search next code symbol.
            int index = 1;
            Symbol symbol = this.symbols.Peek(index);

            if (symbol.SymbolType == SymbolType.Other && symbol.Text == "when")
            {
                index++;

                // Advance to the next non-whitespace symbol.
                for (;; ++index)
                {
                    symbol = this.symbols.Peek(index);
                    if (symbol == null)
                    {
                        return false;
                    }

                    if (symbol.SymbolType != SymbolType.EndOfLine && symbol.SymbolType != SymbolType.WhiteSpace && symbol.SymbolType != SymbolType.MultiLineComment
                        && symbol.SymbolType != SymbolType.SingleLineComment)
                    {
                        break;
                    }
                }

                // We wait only an open parenthesis after when keyword.
                if (symbol.SymbolType != SymbolType.OpenParenthesis)
                {
                    return false;
                }

                return true;
            }

            return false;
        }

        /// <summary>
        /// Determines if the current statement being examined is a local function statement.
        /// </summary>
        /// <param name="currentSymbol">
        /// The current symbol on which the examination is being made.
        /// </param>
        /// <returns>
        /// True, if the statement is a local function, False if not.
        /// </returns>
        private bool IsLocalFunctionStatement(Symbol currentSymbol)
        {
            Param.AssertNotNull(currentSymbol, nameof(currentSymbol));
            SymbolType expectingNextSymbolType = SymbolType.Other;

            // If ref, then move past 'ref'/'await' + white space which would be the type declaration.
            // Othwerwise, the next symbol would be the type declaration.
            bool isAsyncKeyword = currentSymbol.SymbolType == SymbolType.Other && currentSymbol.Text == "async";
            int testPosition = currentSymbol.SymbolType == SymbolType.Ref || isAsyncKeyword ? 3 : 1;

            int angleBracketCount = 0;
            int squareBracketCount = 0;

            while (true)
            {
                // Get the symbol next to the proposed type declaration symbol.
                Symbol symbol = this.PeekNextSymbolFrom(testPosition, SkipSymbols.All, false, out testPosition);

                // Skip, if we are still reading nullable return type
                if (symbol.SymbolType == SymbolType.QuestionMark)
                {
                    continue;
                }

                // if we found a symbol that could be used as part of type declaration,
                // reset our expectation symbol, to read past it.
                if (symbol.SymbolType == SymbolType.OpenSquareBracket)
                {
                    expectingNextSymbolType = SymbolType.CloseSquareBracket;
                    squareBracketCount++;
                    continue;
                }

                if (symbol.SymbolType == SymbolType.LessThan)
                {
                    expectingNextSymbolType = SymbolType.GreaterThanOrEquals;
                    angleBracketCount++;
                    continue;
                }

                // Reset our expectation if we reached the end of type declaration.
                if (symbol.SymbolType == SymbolType.CloseSquareBracket)
                {
                    if (--squareBracketCount == 0)
                    {
                        expectingNextSymbolType = SymbolType.Other;
                    }

                    continue;
                }

                if (symbol.SymbolType == SymbolType.GreaterThan)
                {
                    if (--angleBracketCount == 0)
                    {
                        expectingNextSymbolType = SymbolType.Other;
                    }

                    continue;
                }

                // Skip, if we are still reading variable declaration
                if (symbol.SymbolType != expectingNextSymbolType &&
                    expectingNextSymbolType != SymbolType.Other)
                {
                    continue;
                }

                Symbol nextSymbol = this.PeekNextSymbolFrom(testPosition, SkipSymbols.WhiteSpace, false, out testPosition);

                // If we are '.' or the next symbol is a '.' , then we could be in a namespace of fully qualified return type.
                if (symbol.SymbolType == SymbolType.Dot || nextSymbol.SymbolType == SymbolType.Dot)
                {
                    continue;
                }

                // We are at the right place, evaluate our expectation that next symbol is open paranthesis, or <.
                return symbol.SymbolType == SymbolType.Other
                    && (nextSymbol.SymbolType == SymbolType.OpenParenthesis || nextSymbol.SymbolType == SymbolType.LessThan);
            }
        }

        /// <summary>
        /// Parses the when statement.
        /// </summary>
        /// <param name="parentReference">The parent reference.</param>
        /// <param name="unsafeCode">If set to <c>true</c> [unsafe code].</param>
        /// <returns>The when statement.</returns>
        private Statement ParseWhenStatement(Reference<ICodePart> parentReference, bool unsafeCode)
        {
            Param.AssertNotNull(parentReference, "parentReference");
            Param.Ignore(unsafeCode);

            Reference<ICodePart> statementReference = new Reference<ICodePart>();

            // Move past the when keyword.
            CsToken firstToken = this.GetToken(CsTokenType.When, SymbolType.Other, parentReference);
            if (firstToken.Text.ToLowerInvariant() != "when")
            {
                this.CreateSyntaxException();
            }

            Node<CsToken> firstTokenNode = this.tokens.InsertLast(firstToken);

            // Get the open paren.
            this.tokens.Add(this.GetBracketToken(CsTokenType.OpenParenthesis, SymbolType.OpenParenthesis, statementReference));

            // Get the expression.
            Expression whenValue = this.GetNextExpression(ExpressionPrecedence.None, statementReference, unsafeCode);
            if (whenValue == null)
            {
                throw this.CreateSyntaxException();
            }

            // Get the closing paren.
            this.tokens.Add(this.GetBracketToken(CsTokenType.CloseParenthesis, SymbolType.CloseParenthesis, statementReference));

            // Create the token list for the statement.
            CsTokenList partialTokens = new CsTokenList(this.tokens, firstTokenNode, this.tokens.Last);

            // Create and return the statement.
            WhenStatement statement = new WhenStatement(partialTokens, whenValue);
            statementReference.Target = statement;

            return statement;
        }

        /// <summary>
        /// Moves past whitespace, comments, and preprocessors, up to the start of the next statement.
        /// </summary>
        /// <param name="parentReference">
        /// The parent code part.
        /// </param>
        /// <returns>
        /// Returns true if there is another statement to parse.
        /// </returns>
        private bool MoveToStatement(Reference<ICodePart> parentReference)
        {
            Param.AssertNotNull(parentReference, "parentReference");

            bool finished = false;

            // Loop past any comments, whitespace, and preprocessor statements. Keep
            // going until we get to the statement itself.
            Symbol symbol = this.GetNextSymbol(parentReference);
            while (symbol != null)
            {
                if (symbol.SymbolType == SymbolType.PreprocessorDirective)
                {
                    // Get the preprocessor statement.
                    Preprocessor preprocessor = this.GetPreprocessorDirectiveToken(symbol, parentReference, this.symbols.Generated);
                    if (preprocessor == null)
                    {
                        throw new SyntaxException(this.document.SourceCode, symbol.LineNumber);
                    }

                    this.symbols.Advance();
                    this.tokens.Add(preprocessor);
                }
                else if (symbol.SymbolType == SymbolType.XmlHeaderLine)
                {
                    // Get the xml header.
                    XmlHeader header = this.GetXmlHeader(parentReference);
                    if (header == null)
                    {
                        throw new SyntaxException(this.document.SourceCode, symbol.LineNumber);
                    }

                    // Add the header to the document.
                    this.tokens.Add(header);
                }
                else
                {
                    if (symbol.SymbolType == SymbolType.CloseCurlyBracket)
                    {
                        finished = true;
                    }

                    break;
                }

                symbol = this.GetNextSymbol(parentReference);
            }

            return !finished;
        }

        /// <summary>
        /// Reads the next await-statement from the file and returns it.
        /// </summary>
        /// <param name="parentReference">
        /// The parent code unit.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code being parsed resides in an unsafe code block.
        /// </param>
        /// <returns>
        /// Returns the statement.
        /// </returns>
        private AwaitStatement ParseAwaitStatement(Reference<ICodePart> parentReference, bool unsafeCode)
        {
            Param.AssertNotNull(parentReference, "parentReference");
            Param.Ignore(unsafeCode);

            Reference<ICodePart> statementReference = new Reference<ICodePart>();

            // Move past the await keyword.
            CsToken firstToken = this.GetToken(CsTokenType.Await, SymbolType.Other, parentReference, statementReference);
            Node<CsToken> firstTokenNode = this.tokens.InsertLast(firstToken);

            // Get the expression.
            Expression awaitValue = this.GetNextExpression(ExpressionPrecedence.None, statementReference, unsafeCode);
            if (awaitValue == null)
            {
                throw this.CreateSyntaxException();
            }

            // Get the closing semicolon.
            this.tokens.Add(this.GetToken(CsTokenType.Semicolon, SymbolType.Semicolon, statementReference));

            // Create the token list for the statement.
            CsTokenList partialTokens = new CsTokenList(this.tokens, firstTokenNode, this.tokens.Last);

            // Create and return the statement.
            AwaitStatement statement = new AwaitStatement(partialTokens, awaitValue);
            statementReference.Target = statement;

            return statement;
        }

        /// <summary>
        /// Reads the next block statement from the file and returns it.
        /// </summary>
        /// <param name="unsafeCode">
        /// Indicates whether the code being parsed resides in an unsafe code block.
        /// </param>
        /// <returns>
        /// Returns the statement.
        /// </returns>
        private BlockStatement ParseBlockStatement(bool unsafeCode)
        {
            Param.Ignore(unsafeCode);

            Reference<ICodePart> statementReference = new Reference<ICodePart>();

            // Get the opening bracket keyword.
            Bracket openingBracket = this.GetBracketToken(CsTokenType.OpenCurlyBracket, SymbolType.OpenCurlyBracket, statementReference);
            Node<CsToken> openingBracketNode = this.tokens.InsertLast(openingBracket);

            // Create the block statement.
            BlockStatement block = new BlockStatement();

            // Get the rest of the statement.
            Node<CsToken> closingBracketNode = this.ParseStatementScope(block, statementReference, unsafeCode);
            if (closingBracketNode == null)
            {
                // If we failed to get a closing bracket back, then there is a syntax
                // error in the document since there is an opening bracket with no matching
                // closing bracket.
                throw this.CreateSyntaxException();
            }

            openingBracket.MatchingBracketNode = closingBracketNode;
            ((Bracket)closingBracketNode.Value).MatchingBracketNode = openingBracketNode;

            // Create the token list for this statement.
            CsTokenList partialTokens = new CsTokenList(this.tokens, openingBracketNode, this.tokens.Last);

            block.Tokens = partialTokens;
            statementReference.Target = block;

            return block;
        }

        /// <summary>
        /// Reads the next break-statement from the file and returns it.
        /// </summary>
        /// <param name="parentReference">
        /// The parent code unit.
        /// </param>
        /// <returns>
        /// Returns the statement.
        /// </returns>
        private BreakStatement ParseBreakStatement(Reference<ICodePart> parentReference)
        {
            Param.AssertNotNull(parentReference, "parentReference");
            Reference<ICodePart> statementReference = new Reference<ICodePart>();

            // Move past the break keyword.
            CsToken firstToken = this.GetToken(CsTokenType.Break, SymbolType.Break, parentReference, statementReference);
            Node<CsToken> firstTokenNode = this.tokens.InsertLast(firstToken);

            // Get the closing semicolon.
            this.tokens.Add(this.GetToken(CsTokenType.Semicolon, SymbolType.Semicolon, statementReference));

            // Create the token list for the statement.
            CsTokenList partialTokens = new CsTokenList(this.tokens, firstTokenNode, firstTokenNode);

            // Create and return the break-statement.
            BreakStatement statement = new BreakStatement(partialTokens);
            statementReference.Target = statement;

            return statement;
        }

        /// <summary>
        /// Reads the next checked-statement from the file and returns it.
        /// </summary>
        /// <param name="parentReference">
        /// The parent code unit.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code being parsed resides in an unsafe code block.
        /// </param>
        /// <returns>
        /// Returns the statement.
        /// </returns>
        private CheckedStatement ParseCheckedStatement(Reference<ICodePart> parentReference, bool unsafeCode)
        {
            Param.AssertNotNull(parentReference, "parentReference");
            Param.Ignore(unsafeCode);

            Reference<ICodePart> statementReference = new Reference<ICodePart>();

            // Move past the checked keyword.
            CsToken firstToken = this.GetToken(CsTokenType.Checked, SymbolType.Checked, parentReference, statementReference);
            Node<CsToken> firstTokenNode = this.tokens.InsertLast(firstToken);

            // Get the embedded statement. It must be a block statement.
            BlockStatement childStatement = this.GetNextStatement(statementReference, unsafeCode) as BlockStatement;
            if (childStatement == null)
            {
                throw this.CreateSyntaxException();
            }

            // Create the token list for the statement.
            CsTokenList partialTokens = new CsTokenList(this.tokens, firstTokenNode, this.tokens.Last);

            // Create and return the checked-statement.
            CheckedStatement statement = new CheckedStatement(partialTokens, childStatement);
            statementReference.Target = statement;

            return statement;
        }

        /// <summary>
        /// Reads the next continue-statement from the file and returns it.
        /// </summary>
        /// <param name="parentReference">
        /// The parent code unit.
        /// </param>
        /// <returns>
        /// Returns the statement.
        /// </returns>
        private ContinueStatement ParseContinueStatement(Reference<ICodePart> parentReference)
        {
            Param.AssertNotNull(parentReference, "parentReference");
            Reference<ICodePart> statementReference = new Reference<ICodePart>();

            // Move past the continue keyword.
            CsToken firstToken = this.GetToken(CsTokenType.Continue, SymbolType.Continue, parentReference, statementReference);
            Node<CsToken> firstTokenNode = this.tokens.InsertLast(firstToken);

            // Get the closing semicolon.
            this.tokens.Add(this.GetToken(CsTokenType.Semicolon, SymbolType.Semicolon, statementReference));

            // Create the token list for the statement.
            CsTokenList partialTokens = new CsTokenList(this.tokens, firstTokenNode, firstTokenNode);

            // Create and return the continue-statement.
            ContinueStatement statement = new ContinueStatement(partialTokens);
            statementReference.Target = statement;

            return statement;
        }

        /// <summary>
        /// Reads the next do-while-statement from the file and returns it.
        /// </summary>
        /// <param name="parentReference">
        /// The parent code unit.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code being parsed resides in an unsafe code block.
        /// </param>
        /// <returns>
        /// Returns the statement.
        /// </returns>
        private DoWhileStatement ParseDoWhileStatement(Reference<ICodePart> parentReference, bool unsafeCode)
        {
            Param.AssertNotNull(parentReference, "parentReference");
            Param.Ignore(unsafeCode);

            Reference<ICodePart> statementReference = new Reference<ICodePart>();

            // Add the do keyword.
            CsToken firstToken = this.GetToken(CsTokenType.Do, SymbolType.Do, parentReference, statementReference);
            Node<CsToken> firstTokenNode = this.tokens.InsertLast(firstToken);

            // Get the attached statement.
            Statement childStatement = this.GetNextStatement(statementReference, unsafeCode);
            if (childStatement == null || childStatement.Tokens.First == null)
            {
                throw new SyntaxException(this.document.SourceCode, firstToken.LineNumber);
            }

            // Get the while keyword and add it.
            this.tokens.Add(this.GetToken(CsTokenType.WhileDo, SymbolType.While, statementReference));

            // Get the opening parenthesis and add it.
            Bracket openParenthesis = this.GetBracketToken(CsTokenType.OpenParenthesis, SymbolType.OpenParenthesis, statementReference);
            Node<CsToken> openParenthesisNode = this.tokens.InsertLast(openParenthesis);

            // Get the expression within the parenthesis.
            Expression expression = this.GetNextExpression(ExpressionPrecedence.None, statementReference, unsafeCode);
            if (expression == null)
            {
                throw this.CreateSyntaxException();
            }

            // Get the closing parenthesis.
            Bracket closeParenthesis = this.GetBracketToken(CsTokenType.CloseParenthesis, SymbolType.CloseParenthesis, statementReference);
            Node<CsToken> closeParenthesisNode = this.tokens.InsertLast(closeParenthesis);

            openParenthesis.MatchingBracketNode = closeParenthesisNode;
            closeParenthesis.MatchingBracketNode = openParenthesisNode;

            // Get the closing semicolon.
            this.tokens.Add(this.GetToken(CsTokenType.Semicolon, SymbolType.Semicolon, statementReference));

            // Create the token list for the statement.
            CsTokenList partialTokens = new CsTokenList(this.tokens, firstTokenNode, this.tokens.Last);

            // Create and return the do-while-statement.
            DoWhileStatement statement = new DoWhileStatement(partialTokens, expression, childStatement);
            statementReference.Target = statement;

            return statement;
        }

        /// <summary>
        /// Reads the next expression statement from the file and returns it.
        /// </summary>
        /// <param name="unsafeCode">
        /// Indicates whether the code being parsed resides in an unsafe code block.
        /// </param>
        /// <returns>
        /// Returns the statement.
        /// </returns>
        private ExpressionStatement ParseExpressionStatement(bool unsafeCode)
        {
            Param.Ignore(unsafeCode);

            Reference<ICodePart> statementReference = new Reference<ICodePart>();

            // Get the expression.
            Expression expression = this.GetNextExpression(ExpressionPrecedence.None, statementReference, unsafeCode);
            if (expression == null || expression.Tokens.First == null)
            {
                throw this.CreateSyntaxException();
            }

            // Read up to the semicolon.
            this.tokens.Add(this.GetToken(CsTokenType.Semicolon, SymbolType.Semicolon, statementReference));

            // Create the token list for the statement.
            CsTokenList partialTokens = new CsTokenList(this.tokens, expression.Tokens.First, this.tokens.Last);

            // Create and return the statement.
            ExpressionStatement statement = new ExpressionStatement(partialTokens, expression);
            statementReference.Target = statement;

            return statement;
        }

        /// <summary>
        /// Reads the next fixed-statement from the file and returns it.
        /// </summary>
        /// <param name="parentReference">
        /// The parent code unit.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code being parsed resides in an unsafe code block.
        /// </param>
        /// <returns>
        /// Returns the statement.
        /// </returns>
        private FixedStatement ParseFixedStatement(Reference<ICodePart> parentReference, bool unsafeCode)
        {
            Param.AssertNotNull(parentReference, "parentReference");
            Param.Ignore(unsafeCode);

            Reference<ICodePart> statementReference = new Reference<ICodePart>();

            // Move past the fixed keyword.
            CsToken firstToken = this.GetToken(CsTokenType.Fixed, SymbolType.Fixed, parentReference, statementReference);
            Node<CsToken> firstTokenNode = this.tokens.InsertLast(firstToken);

            // Make sure we're sitting on the opening parenthesis now.
            Bracket openParenthesis = this.GetBracketToken(CsTokenType.OpenParenthesis, SymbolType.OpenParenthesis, statementReference);
            Node<CsToken> openParenthesisNode = this.tokens.InsertLast(openParenthesis);

            // Get the expression within the parenthesis. It must be a variable declaration.
            VariableDeclarationExpression expression =
                this.GetNextExpression(ExpressionPrecedence.None, statementReference, unsafeCode, true, false) as VariableDeclarationExpression;
            if (expression == null)
            {
                throw this.CreateSyntaxException();
            }

            // Get the closing parenthesis.
            Bracket closeParenthesis = this.GetBracketToken(CsTokenType.CloseParenthesis, SymbolType.CloseParenthesis, statementReference);
            Node<CsToken> closeParenthesisNode = this.tokens.InsertLast(closeParenthesis);

            openParenthesis.MatchingBracketNode = closeParenthesisNode;
            closeParenthesis.MatchingBracketNode = openParenthesisNode;

            // Get the embedded statement.
            Statement childStatement = this.GetNextStatement(statementReference, unsafeCode);
            if (childStatement == null)
            {
                throw this.CreateSyntaxException();
            }

            // Create the token list for the statement.
            CsTokenList partialTokens = new CsTokenList(this.tokens, firstTokenNode, this.tokens.Last);

            // Create the fixed-statement.
            FixedStatement statement = new FixedStatement(partialTokens, expression);
            statement.EmbeddedStatement = childStatement;
            statementReference.Target = statement;

            // Add the variable if there is one.
            foreach (VariableDeclaratorExpression declarator in expression.Declarators)
            {
                Variable variable = new Variable(
                    expression.Type,
                    declarator.Identifier.Token.Text,
                    VariableModifiers.None,
                    CodeLocation.Join(expression.Type.Location, declarator.Identifier.Token.Location),
                    statementReference,
                    expression.Type.Generated || declarator.Identifier.Token.Generated);

                // If there is already a variable in this scope with the same name, ignore this one.
                if (!statement.Variables.Contains(declarator.Identifier.Token.Text))
                {
                    statement.Variables.Add(variable);
                }
            }

            return statement;
        }

        /// <summary>
        /// Reads the next for-statement from the file and returns it.
        /// </summary>
        /// <param name="parentReference">
        /// The parent code unit.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code being parsed resides in an unsafe code block.
        /// </param>
        /// <returns>
        /// Returns the statement.
        /// </returns>
        private ForStatement ParseForStatement(Reference<ICodePart> parentReference, bool unsafeCode)
        {
            Param.AssertNotNull(parentReference, "parentReference");
            Param.Ignore(unsafeCode);

            Reference<ICodePart> statementReference = new Reference<ICodePart>();

            // Add the for keyword.
            CsToken firstToken = this.GetToken(CsTokenType.For, SymbolType.For, parentReference, statementReference);
            Node<CsToken> firstTokenNode = this.tokens.InsertLast(firstToken);

            // Get the opening parenthesis.
            Bracket openParenthesis = this.GetBracketToken(CsTokenType.OpenParenthesis, SymbolType.OpenParenthesis, statementReference);
            Node<CsToken> openParenthesisNode = this.tokens.InsertLast(openParenthesis);

            // Get each of the initializers.
            List<Expression> initializers = this.ParseForStatementInitializers(statementReference, unsafeCode);

            // Get the condition expression.
            Expression condition = this.ParseForStatementCondition(statementReference, unsafeCode);

            // Get the iterators.
            List<Expression> iterators = this.ParseForStatementIterators(statementReference, unsafeCode, openParenthesis, openParenthesisNode);

            // Get the embedded statement.
            Statement childStatement = this.GetNextStatement(statementReference, unsafeCode);
            if (childStatement == null || childStatement.Tokens.First == null)
            {
                throw new SyntaxException(this.document.SourceCode, firstToken.LineNumber);
            }

            // Create the token list for the statement.
            CsTokenList partialTokens = new CsTokenList(this.tokens, firstTokenNode, this.tokens.Last);

            // Create and return the for-statement.
            ForStatement statement = new ForStatement(partialTokens, initializers.ToArray(), condition, iterators.ToArray());
            statement.EmbeddedStatement = childStatement;
            statementReference.Target = statement;

            // Add the variables declared in the statement.
            foreach (Expression initializer in initializers)
            {
                VariableDeclarationExpression variableDeclaration = initializer as VariableDeclarationExpression;
                if (variableDeclaration != null)
                {
                    Reference<ICodePart> initializerReference = new Reference<ICodePart>(initializer);
                    foreach (VariableDeclaratorExpression declarator in variableDeclaration.Declarators)
                    {
                        Variable variable = new Variable(
                            variableDeclaration.Type,
                            declarator.Identifier.Token.Text,
                            VariableModifiers.None,
                            CodeLocation.Join(variableDeclaration.Type.Location, declarator.Identifier.Token.Location),
                            initializerReference,
                            variableDeclaration.Type.Generated || declarator.Identifier.Token.Generated);

                        // If there is already a variable in this scope with the same name, ignore this one.
                        if (!statement.Variables.Contains(declarator.Identifier.Token.Text))
                        {
                            statement.Variables.Add(variable);
                        }
                    }
                }
            }

            return statement;
        }

        /// <summary>
        /// Parses the condition expression from a for-statement.
        /// </summary>
        /// <param name="statementReference">
        /// A reference to the statement being created.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code is located within an unsafe block.
        /// </param>
        /// <returns>
        /// Returns the condition expression.
        /// </returns>
        private Expression ParseForStatementCondition(Reference<ICodePart> statementReference, bool unsafeCode)
        {
            Param.AssertNotNull(statementReference, "statementReference");
            Param.Ignore(unsafeCode);

            // Now get the condition expression if there is one.
            Symbol symbol = this.GetNextSymbol(statementReference);

            Expression condition = null;
            if (symbol.SymbolType != SymbolType.Semicolon)
            {
                condition = this.GetNextExpression(ExpressionPrecedence.None, statementReference, unsafeCode);
                if (condition == null || condition.Tokens.First == null)
                {
                    throw new SyntaxException(this.document.SourceCode, symbol.LineNumber);
                }

                // Get the next symbol.
                symbol = this.GetNextSymbol(statementReference);
            }

            // The next symbol must be a semicolon.
            if (symbol.SymbolType != SymbolType.Semicolon)
            {
                throw new SyntaxException(this.document.SourceCode, symbol.LineNumber);
            }

            // Add the semicolon.
            this.tokens.Add(this.GetToken(CsTokenType.Semicolon, SymbolType.Semicolon, statementReference));

            return condition;
        }

        /// <summary>
        /// Parses the initializers from a for-statement.
        /// </summary>
        /// <param name="statementReference">
        /// A reference to the statement being created.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code is located within an unsafe block.
        /// </param>
        /// <returns>
        /// Returns the list of initializers.
        /// </returns>
        private List<Expression> ParseForStatementInitializers(Reference<ICodePart> statementReference, bool unsafeCode)
        {
            Param.AssertNotNull(statementReference, "statementReference");
            Param.Ignore(unsafeCode);

            List<Expression> initializers = new List<Expression>();

            while (true)
            {
                // Check the type of the next symbol.
                Symbol symbol = this.GetNextSymbol(statementReference);

                if (symbol.SymbolType == SymbolType.Semicolon)
                {
                    // This is the end of the initializer list. Add the semicolon and break.
                    this.tokens.Add(this.GetToken(CsTokenType.Semicolon, SymbolType.Semicolon, statementReference));
                    break;
                }

                // Get the next identifier expression.
                Expression initializer = this.GetNextExpression(ExpressionPrecedence.None, statementReference, unsafeCode, true, false);
                if (initializer == null || initializer.Tokens.First == null)
                {
                    throw new SyntaxException(this.document.SourceCode, symbol.LineNumber);
                }

                // Add the initializer to the list.
                initializers.Add(initializer);

                // If the next symbol is a comma, save it.
                symbol = this.GetNextSymbol(statementReference);

                if (symbol.SymbolType == SymbolType.Comma)
                {
                    this.tokens.Add(this.GetToken(CsTokenType.Comma, SymbolType.Comma, statementReference));
                }
                else if (symbol.SymbolType != SymbolType.Semicolon)
                {
                    // If it's not a comma it must be a semicolon.
                    throw new SyntaxException(this.document.SourceCode, symbol.LineNumber);
                }
            }

            return initializers;
        }

        /// <summary>
        /// Parses the iterators from a for-statement.
        /// </summary>
        /// <param name="statementReference">
        /// A reference to the statement being created.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code is located within an unsafe block.
        /// </param>
        /// <param name="openParenthesis">
        /// The opening parenthesis.
        /// </param>
        /// <param name="openParenthesisNode">
        /// The opening parenthesis node.
        /// </param>
        /// <returns>
        /// Returns the list of iterators.
        /// </returns>
        private List<Expression> ParseForStatementIterators(
            Reference<ICodePart> statementReference, bool unsafeCode, Bracket openParenthesis, Node<CsToken> openParenthesisNode)
        {
            Param.AssertNotNull(statementReference, "statementReference");
            Param.Ignore(unsafeCode);
            Param.AssertNotNull(openParenthesis, "openParenthesis");
            Param.AssertNotNull(openParenthesisNode, "openParenthesisNode");

            // Get the iterators.
            List<Expression> iterators = new List<Expression>();

            while (true)
            {
                // Check the type of the next symbol.
                Symbol symbol = this.GetNextSymbol(statementReference);

                if (symbol.SymbolType == SymbolType.CloseParenthesis)
                {
                    // This is the end of the iterator list. Add the parenthesis and break.
                    Bracket closeParenthesis = this.GetBracketToken(CsTokenType.CloseParenthesis, SymbolType.CloseParenthesis, statementReference);
                    Node<CsToken> closeParenthesisNode = this.tokens.InsertLast(closeParenthesis);

                    openParenthesis.MatchingBracketNode = closeParenthesisNode;
                    closeParenthesis.MatchingBracketNode = openParenthesisNode;
                    break;
                }

                // Get the next iterator expression.
                Expression iterator = this.GetNextExpression(ExpressionPrecedence.None, statementReference, unsafeCode);
                if (iterator == null || iterator.Tokens.First == null)
                {
                    throw new SyntaxException(this.document.SourceCode, symbol.LineNumber);
                }

                // Add the initializer to the list.
                iterators.Add(iterator);

                // If the next symbol is a comma, save it.
                symbol = this.GetNextSymbol(statementReference);

                if (symbol.SymbolType == SymbolType.Comma)
                {
                    this.tokens.Add(this.GetToken(CsTokenType.Comma, SymbolType.Comma, statementReference));
                }
                else if (symbol.SymbolType != SymbolType.CloseParenthesis)
                {
                    // If it's not a comma it must be a closing parenthesis.
                    throw new SyntaxException(this.document.SourceCode, symbol.LineNumber);
                }
            }

            return iterators;
        }

        /// <summary>
        /// Reads the next foreach statement from the file and returns it.
        /// </summary>
        /// <param name="parentReference">
        /// The parent code unit.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code being parsed resides in an unsafe code block.
        /// </param>
        /// <returns>
        /// Returns the statement.
        /// </returns>
        private ForeachStatement ParseForeachStatement(Reference<ICodePart> parentReference, bool unsafeCode)
        {
            Param.AssertNotNull(parentReference, "parentReference");
            Param.Ignore(unsafeCode);

            Reference<ICodePart> statementReference = new Reference<ICodePart>();

            // Get the foreach keyword.
            CsToken firstToken = this.GetToken(CsTokenType.Foreach, SymbolType.Foreach, parentReference, statementReference);
            Node<CsToken> firstTokenNode = this.tokens.InsertLast(firstToken);

            // Get the opening parenthesis.
            Bracket openParenthesis = this.GetBracketToken(CsTokenType.OpenParenthesis, SymbolType.OpenParenthesis, statementReference);
            Node<CsToken> openParenthesisNode = this.tokens.InsertLast(openParenthesis);

            // Get the variable. 
            Expression variable = this.GetNextExpression(ExpressionPrecedence.None, statementReference, unsafeCode, true, false);

            // This could be a single variable declaration or a tuple expression.
            IEnumerable<VariableDeclaratorExpression> declarators;
            TypeToken variableTypeToken;

            VariableDeclarationExpression singleVariable;
            TupleExpression tupleVariable;
            if ((singleVariable = variable as VariableDeclarationExpression) != null)
            {
                variableTypeToken = singleVariable.Type;
                declarators = singleVariable.Declarators;
            }
            else if ((tupleVariable = variable as TupleExpression) != null)
            {
                CsToken firstNode = tupleVariable.Tokens.First.Value;
                variableTypeToken = new TypeToken(tupleVariable.Tokens.MasterList, tupleVariable.Location, firstNode.ParentRef, firstNode.Generated);
                var tupleVariableDeclarators = new List<VariableDeclaratorExpression>();

                foreach (var declaration in tupleVariable.VariableDeclarations)
                {
                    tupleVariableDeclarators.AddRange(declaration.Declarators);
                }

                declarators = tupleVariableDeclarators;
            }
            else
            {
                throw this.CreateSyntaxException();
            }

            // Get the 'in' keyword and add it.
            this.tokens.Add(this.GetToken(CsTokenType.In, SymbolType.In, statementReference));

            // Get the item being iterated over.
            Expression item = this.GetNextExpression(ExpressionPrecedence.None, statementReference, unsafeCode);
            if (item == null)
            {
                throw this.CreateSyntaxException();
            }

            // Get the closing parenthesis.
            Bracket closeParenthesis = this.GetBracketToken(CsTokenType.CloseParenthesis, SymbolType.CloseParenthesis, statementReference);
            Node<CsToken> closeParenthesisNode = this.tokens.InsertLast(closeParenthesis);

            openParenthesis.MatchingBracketNode = closeParenthesisNode;
            closeParenthesis.MatchingBracketNode = openParenthesisNode;

            // Get the embedded statement.
            Statement childStatement = this.GetNextStatement(statementReference, unsafeCode);
            if (childStatement == null)
            {
                throw this.CreateSyntaxException();
            }

            // Create the token list for the statement.
            CsTokenList partialTokens = new CsTokenList(this.tokens, firstTokenNode, this.tokens.Last);

            // Create the foreach-statement.
            ForeachStatement statement = new ForeachStatement(partialTokens, variable, item);
            statement.EmbeddedStatement = childStatement;
            statementReference.Target = statement;

            // Add the variable.
            foreach (VariableDeclaratorExpression declarator in declarators)
            {
                Variable localVariable = new Variable(
                    variableTypeToken,
                    declarator.Identifier.Token.Text,
                    VariableModifiers.None,
                    CodeLocation.Join(variableTypeToken.Location, declarator.Identifier.Token.Location),
                    statementReference,
                    variableTypeToken.Generated);

                // If there is already a variable in this scope with the same name, ignore this one.
                if (!statement.Variables.Contains(declarator.Identifier.Token.Text))
                {
                    statement.Variables.Add(localVariable);
                }
            }

            return statement;
        }

        /// <summary>
        /// Reads the next goto statement from the file and returns it.
        /// </summary>
        /// <param name="parentReference">
        /// The parent code unit.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code being parsed resides in an unsafe code block.
        /// </param>
        /// <returns>
        /// Returns the statement.
        /// </returns>
        private GotoStatement ParseGotoStatement(Reference<ICodePart> parentReference, bool unsafeCode)
        {
            Param.AssertNotNull(parentReference, "parentReference");
            Param.Ignore(unsafeCode);

            Reference<ICodePart> statementReference = new Reference<ICodePart>();

            // Move past the goto keyword.
            CsToken firstToken = this.GetToken(CsTokenType.Goto, SymbolType.Goto, parentReference, statementReference);
            Node<CsToken> firstTokenNode = this.tokens.InsertLast(firstToken);

            // Get the next symbol.
            Symbol symbol = this.GetNextSymbol(statementReference);

            Expression identifier = null;
            if (symbol.SymbolType == SymbolType.Default)
            {
                Node<CsToken> tokenNode = this.tokens.InsertLast(this.GetToken(CsTokenType.Other, SymbolType.Default, statementReference));
                identifier = new LiteralExpression(new CsTokenList(this.tokens, tokenNode, tokenNode), tokenNode);
            }
            else if (symbol.SymbolType == SymbolType.Case)
            {
                this.tokens.Add(this.GetToken(CsTokenType.Other, SymbolType.Case, statementReference));
                identifier = this.GetNextExpression(ExpressionPrecedence.None, statementReference, unsafeCode);
            }
            else
            {
                identifier = this.GetNextExpression(ExpressionPrecedence.None, statementReference, unsafeCode);
            }

            // Get the closing semicolon.
            this.tokens.Add(this.GetToken(CsTokenType.Semicolon, SymbolType.Semicolon, statementReference));

            // Create the token list for the statement.
            CsTokenList partialTokens = new CsTokenList(this.tokens, firstTokenNode, firstTokenNode);

            // Create and return the goto-statement.
            GotoStatement statement = new GotoStatement(partialTokens, identifier);
            statementReference.Target = statement;

            return statement;
        }

        /// <summary>
        /// Reads the next if-statement from the file and returns it.
        /// </summary>
        /// <param name="parentReference">
        /// The parent code unit.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code being parsed resides in an unsafe code block.
        /// </param>
        /// <returns>
        /// Returns the statement.
        /// </returns>
        private IfStatement ParseIfStatement(Reference<ICodePart> parentReference, bool unsafeCode)
        {
            Param.AssertNotNull(parentReference, "parentReference");
            Param.Ignore(unsafeCode);

            Reference<ICodePart> statementReference = new Reference<ICodePart>();

            // Move past the if keyword.
            CsToken firstToken = this.GetToken(CsTokenType.If, SymbolType.If, parentReference, statementReference);
            Node<CsToken> firstTokenNode = this.tokens.InsertLast(firstToken);

            // Get the opening parenthesis.
            Bracket openParenthesis = this.GetBracketToken(CsTokenType.OpenParenthesis, SymbolType.OpenParenthesis, statementReference);
            Node<CsToken> openParenthesisNode = this.tokens.InsertLast(openParenthesis);

            // Get the expression within the parenthesis.
            Expression expression = this.GetNextExpression(ExpressionPrecedence.None, statementReference, unsafeCode);
            if (expression == null)
            {
                throw this.CreateSyntaxException();
            }

            // Get the closing parenthesis.
            Bracket closeParenthesis = this.GetBracketToken(CsTokenType.CloseParenthesis, SymbolType.CloseParenthesis, statementReference);
            Node<CsToken> closeParenthesisNode = this.tokens.InsertLast(closeParenthesis);

            openParenthesis.MatchingBracketNode = closeParenthesisNode;
            closeParenthesis.MatchingBracketNode = openParenthesisNode;

            // Get the embedded statement.
            Statement childStatement = this.GetNextStatement(statementReference, unsafeCode);
            if (childStatement == null)
            {
                throw new SyntaxException(this.document.SourceCode, firstToken.LineNumber);
            }

            // Create the token list for the statement.
            CsTokenList partialTokens = new CsTokenList(this.tokens, firstTokenNode, this.tokens.Last);

            // Create the if-statement.
            IfStatement statement = new IfStatement(partialTokens, expression);
            statement.EmbeddedStatement = childStatement;
            statementReference.Target = statement;

            // Check if there is an else or an else-if attached to this statement.
            ElseStatement attached = this.GetAttachedElseStatement(statementReference, statement, unsafeCode);
            if (attached != null)
            {
                statement.AttachedElseStatement = attached;
            }

            return statement;
        }

        /// <summary>
        /// Reads a label statement.
        /// </summary>
        /// <param name="parentReference">
        /// The parent code unit.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code is marked as unsafe.
        /// </param>
        /// <returns>
        /// Returns the statement.
        /// </returns>
        private LabelStatement ParseLabelStatement(Reference<ICodePart> parentReference, bool unsafeCode)
        {
            Param.AssertNotNull(parentReference, "parentReference");
            Param.Ignore(unsafeCode);

            // The first symbol must be an unknown word.
            this.GetNextSymbol(SymbolType.Other, parentReference);

            Reference<ICodePart> statementReference = new Reference<ICodePart>();

            // Get the literal expression for this symbol.
            LiteralExpression identifier = this.GetLiteralExpression(statementReference, unsafeCode);
            if (identifier == null || identifier.Tokens.First == null)
            {
                throw this.CreateSyntaxException();
            }

            // The next symbol must be the colon.
            this.tokens.Add(this.GetToken(CsTokenType.LabelColon, SymbolType.Colon, statementReference));

            // Create the token list for the statement.
            CsTokenList partialTokens = new CsTokenList(this.tokens, identifier.Tokens.First, this.tokens.Last);

            LabelStatement statement = new LabelStatement(partialTokens, identifier);
            statementReference.Target = statement;

            return statement;
        }

        /// <summary>
        /// Reads the next lock-statement from the file and returns it.
        /// </summary>
        /// <param name="parentReference">
        /// The parent code unit.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code being parsed resides in an unsafe code block.
        /// </param>
        /// <returns>
        /// Returns the statement.
        /// </returns>
        private LockStatement ParseLockStatement(Reference<ICodePart> parentReference, bool unsafeCode)
        {
            Param.AssertNotNull(parentReference, "parentReference");
            Param.Ignore(unsafeCode);

            Reference<ICodePart> statementReference = new Reference<ICodePart>();

            // Move past the lock keyword.
            CsToken firstToken = this.GetToken(CsTokenType.Lock, SymbolType.Lock, parentReference, statementReference);
            Node<CsToken> firstTokenNode = this.tokens.InsertLast(firstToken);

            // Get the opening parenthesis.
            Bracket openParenthesis = this.GetBracketToken(CsTokenType.OpenParenthesis, SymbolType.OpenParenthesis, statementReference);
            Node<CsToken> openParenthesisNode = this.tokens.InsertLast(openParenthesis);

            // Get the expression within the parenthesis.
            Expression expression = this.GetNextExpression(ExpressionPrecedence.None, statementReference, unsafeCode);
            if (expression == null)
            {
                throw this.CreateSyntaxException();
            }

            // Get the closing parenthesis.
            Bracket closeParenthesis = this.GetBracketToken(CsTokenType.CloseParenthesis, SymbolType.CloseParenthesis, statementReference);
            Node<CsToken> closeParenthesisNode = this.tokens.InsertLast(closeParenthesis);

            openParenthesis.MatchingBracketNode = closeParenthesisNode;
            closeParenthesis.MatchingBracketNode = openParenthesisNode;

            // Get the embedded statement.
            Statement childStatement = this.GetNextStatement(statementReference, unsafeCode);
            if (childStatement == null)
            {
                throw this.CreateSyntaxException();
            }

            // Create the token list for the statement.
            CsTokenList partialTokens = new CsTokenList(this.tokens, firstTokenNode, this.tokens.Last);

            // Create the lock-statement.
            LockStatement statement = new LockStatement(partialTokens, expression);
            statement.EmbeddedStatement = childStatement;
            statementReference.Target = statement;

            // Add the variable if there is one.
            VariableDeclarationExpression variableDeclaration = expression as VariableDeclarationExpression;
            if (variableDeclaration != null)
            {
                foreach (VariableDeclaratorExpression declarator in variableDeclaration.Declarators)
                {
                    Variable variable = new Variable(
                        variableDeclaration.Type,
                        declarator.Identifier.Token.Text,
                        VariableModifiers.None,
                        CodeLocation.Join(variableDeclaration.Type.Location, declarator.Identifier.Token.Location),
                        statementReference,
                        variableDeclaration.Type.Generated || declarator.Identifier.Token.Generated);

                    // If there is already a variable in this scope with the same name, ignore this one.
                    if (!statement.Variables.Contains(declarator.Identifier.Token.Text))
                    {
                        statement.Variables.Add(variable);
                    }
                }
            }

            return statement;
        }

        /// <summary>
        /// Reads a statement beginning with an unknown word.
        /// </summary>
        /// <param name="parentReference">
        /// The parent code part.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code being parsed resides in an unsafe code block.
        /// </param>
        /// <param name="variables">
        /// Returns the list of variables defined in the statement.
        /// </param>
        /// <returns>
        /// Returns the statement.
        /// </returns>
        private Statement ParseOtherStatement(Reference<ICodePart> parentReference, bool unsafeCode, VariableCollection variables)
        {
            Param.AssertNotNull(parentReference, "parentReference");
            Param.Ignore(unsafeCode);
            Param.Ignore(variables);

            // Get the first symbol, which will be the unknown word.
            // Holds the statement to return.
            Statement statement = null;

            // Determine whether this has the signature of a type.
            bool variableDeclaration = false;
            int endIndex;
            if (this.HasTypeSignature(1, unsafeCode, out endIndex))
            {
                // Get the next symbol and check if it is another unknown word.
                int nextIndex = this.GetNextCodeSymbolIndex(endIndex + 1);
                if (nextIndex != -1)
                {
                    if (this.symbols.Peek(nextIndex).SymbolType == SymbolType.Other)
                    {
                        // If the next symbol is a semicolon, comma or equals then this is a variable
                        // declaration statement.
                        nextIndex = this.GetNextCodeSymbolIndex(nextIndex + 1);
                        if (nextIndex != -1)
                        {
                            Symbol temp = this.symbols.Peek(nextIndex);
                            if (temp.SymbolType == SymbolType.Equals || temp.SymbolType == SymbolType.Semicolon || temp.SymbolType == SymbolType.Comma)
                            {
                                // This is a variable declaration statement.
                                variableDeclaration = true;
                            }
                        }
                    }
                }
            }

            if (variableDeclaration)
            {
                statement = this.ParseVariableDeclarationStatement(parentReference, unsafeCode, variables);
            }
            else
            {
                // Get the next symbol after the name.
                int index = this.GetNextCodeSymbolIndex(2);
                if (index == -1 || this.symbols.Peek(index).SymbolType != SymbolType.Colon)
                {
                    statement = this.ParseExpressionStatement(unsafeCode);
                }
                else
                {
                    statement = this.ParseLabelStatement(parentReference, unsafeCode);
                }
            }

            return statement;
        }

        /// <summary>
        /// Reads the next return-statement from the file and returns it.
        /// </summary>
        /// <param name="parentReference">
        /// The parent code unit.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code being parsed resides in an unsafe code block.
        /// </param>
        /// <returns>
        /// Returns the statement.
        /// </returns>
        private ReturnStatement ParseReturnStatement(Reference<ICodePart> parentReference, bool unsafeCode)
        {
            Param.AssertNotNull(parentReference, "parentReference");
            Param.Ignore(unsafeCode);

            Reference<ICodePart> statementReference = new Reference<ICodePart>();

            // Move past the return keyword.
            CsToken firstToken = this.GetToken(CsTokenType.Return, SymbolType.Return, parentReference, statementReference);
            Node<CsToken> firstTokenNode = this.tokens.InsertLast(firstToken);

            // Check the next symbol and see if there is an expression to return.
            Symbol symbol = this.GetNextSymbol(statementReference);

            Expression expression = null;
            if (symbol.SymbolType != SymbolType.Semicolon)
            {
                // Get the expression to return.
                expression = this.GetNextExpression(ExpressionPrecedence.None, statementReference, unsafeCode);
                if (expression == null)
                {
                    throw this.CreateSyntaxException();
                }
            }

            this.tokens.Add(this.GetToken(CsTokenType.Semicolon, SymbolType.Semicolon, statementReference));

            // Create the token list for the statement.
            CsTokenList partialTokens = new CsTokenList(this.tokens, firstTokenNode, firstTokenNode);

            // Create and return the statement.
            ReturnStatement statement = new ReturnStatement(partialTokens, expression);
            statementReference.Target = statement;

            return statement;
        }

        /// <summary>
        /// Parses the body of an element that contains a list of statements as children.
        /// </summary>
        /// <param name="element">
        /// The element to parse.
        /// </param>
        /// <param name="interfaceType">
        /// Indicates whether this type of statement container can appear in an interface.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code being parsed resides in an unsafe code block.
        /// </param>
        private void ParseStatementContainer(CsElement element, bool interfaceType, bool unsafeCode)
        {
            Param.AssertNotNull(element, "element");
            Param.Ignore(interfaceType);
            Param.Ignore(unsafeCode);

            // Check to see if the item is unsafe. This is the case if the item's parent is unsafe, or if it
            // has the unsafe keyword itself.
            unsafeCode |= element.Declaration.ContainsModifier(CsTokenType.Unsafe);

            Reference<ICodePart> parentReference = new Reference<ICodePart>(element);

            // The next symbol must be an opening curly bracket.
            Symbol symbol = this.GetNextSymbol(parentReference);
            if (symbol == null)
            {
                throw this.CreateSyntaxException();
            }

            if (symbol.SymbolType == SymbolType.OpenCurlyBracket)
            {
                // Add the bracket token to the document.
                Bracket openingBracket = this.GetBracketToken(CsTokenType.OpenCurlyBracket, SymbolType.OpenCurlyBracket, parentReference);
                Node<CsToken> openingBracketNode = this.tokens.InsertLast(openingBracket);

                // Parse the contents of the element.
                Node<CsToken> closingBracketNode = this.ParseStatementScope(element, parentReference, unsafeCode);
                if (closingBracketNode == null)
                {
                    // If we failed to get a closing bracket back, then there is a syntax
                    // error in the document since there is an opening bracket with no matching
                    // closing bracket.
                    throw this.CreateSyntaxException();
                }

                openingBracket.MatchingBracketNode = closingBracketNode;
                ((Bracket)closingBracketNode.Value).MatchingBracketNode = openingBracketNode;
            }
            else if (symbol.SymbolType == SymbolType.Lambda)
            {
                // Parse the contents of the element.
                this.ParseStatementScope(element, parentReference, unsafeCode);
            }
            else if (interfaceType && symbol.SymbolType == SymbolType.Semicolon)
            {
                // Add the semicolon to the document.
                this.tokens.Add(this.GetToken(CsTokenType.Semicolon, SymbolType.Semicolon, parentReference));
            }
            else
            {
                throw new SyntaxException(this.document.SourceCode, symbol.LineNumber);
            }
        }

        /// <summary>
        /// Parses the body of an element that contains a list of statements as children.
        /// </summary>
        /// <param name="parent">
        /// The parent of the scope.
        /// </param>
        /// <param name="parentReference">
        /// The parent code unit.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code being parsed resides in an unsafe code block.
        /// </param>
        /// <returns>
        /// Returns the closing curly bracket.
        /// </returns>
        private Node<CsToken> ParseStatementScope(IWriteableCodeUnit parent, Reference<ICodePart> parentReference, bool unsafeCode)
        {
            Param.AssertNotNull(parent, "parent");
            Param.AssertNotNull(parentReference, "parentReference");
            Param.Ignore(unsafeCode);

            Node<CsToken> closeBracketNode = null;

            // Keep looping until all the child elements within this container element have been processed.
            while (true)
            {
                // If the next symbol is a closing curly bracket, or we've reached the end of the symbols list, 
                // we're done with this scope.
                Symbol symbol = this.GetNextSymbol(parentReference);
                if (symbol == null)
                {
                    // We've reached the end of the document.
                    break;
                }
                else if (symbol.SymbolType == SymbolType.CloseCurlyBracket)
                {
                    // We've reached the end of the element. Save the closing bracket and exit.
                    Bracket closeBracket = this.GetBracketToken(CsTokenType.CloseCurlyBracket, SymbolType.CloseCurlyBracket, parentReference);
                    closeBracketNode = this.tokens.InsertLast(closeBracket);
                    break;
                }
                else
                {
                    Statement statement = this.GetNextStatement(parentReference, unsafeCode, parent.Variables);
                    if (statement != null)
                    {
                        parent.AddStatement(statement);

                        if (statement is ExpressionStatement)
                        {
                            // if bodied statement we shouldn't have more expression or statement.
                            if (((ExpressionStatement)statement).Expression.ExpressionType == ExpressionType.Bodied)
                            {
                                break;
                            }
                        }

                        foreach (Statement attachedStatement in statement.AttachedStatements)
                        {
                            parent.AddStatement(attachedStatement);
                        }
                    }
                }
            }

            return closeBracketNode;
        }

        /// <summary>
        /// Reads the next case-statement from the file and returns it.
        /// </summary>
        /// <param name="parentReference">
        /// The parent code unit.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code being parsed resides in an unsafe code block.
        /// </param>
        /// <returns>
        /// Returns the statement.
        /// </returns>
        private SwitchCaseStatement ParseSwitchCaseStatement(Reference<ICodePart> parentReference, bool unsafeCode)
        {
            Param.AssertNotNull(parentReference, "parentReference");
            Param.Ignore(unsafeCode);

            Reference<ICodePart> statementReference = new Reference<ICodePart>();

            // Move past the case keyword.
            CsToken firstToken = this.GetToken(CsTokenType.Case, SymbolType.Case, parentReference, statementReference);
            Node<CsToken> firstTokenNode = this.tokens.InsertLast(firstToken);

            // Get the name.
            Symbol symbol = this.GetNextSymbol(statementReference);
            if (symbol.SymbolType != SymbolType.Other && symbol.SymbolType != SymbolType.String && symbol.SymbolType != SymbolType.Number
                && symbol.SymbolType != SymbolType.Null && symbol.SymbolType != SymbolType.OpenParenthesis && symbol.SymbolType != SymbolType.Minus
                && symbol.SymbolType != SymbolType.Plus && symbol.SymbolType != SymbolType.True && symbol.SymbolType != SymbolType.False
                && symbol.SymbolType != SymbolType.Sizeof && symbol.SymbolType != SymbolType.Typeof && symbol.SymbolType != SymbolType.Checked
                && symbol.SymbolType != SymbolType.Unchecked && symbol.SymbolType != SymbolType.NameOf)
            {
                throw this.CreateSyntaxException();
            }

            Expression identifier = this.GetNextExpression(ExpressionPrecedence.None, statementReference, unsafeCode);

            // The next symbol could be a vairable definition, the when keyword, a variable definition followed by when keyword, or a ':'
            // Get the variable definition as part of pattern match, if available.
            Expression matchVariable = null;
            Expression whenExpression = null;
            Symbol nextSymbol = this.PeekNextSymbol(SkipSymbols.All, unsafeCode);

            if (nextSymbol.SymbolType == SymbolType.Other)
            {
                // If next symbol is not 'when', then it's a variable declartion, read it and rest nextSymbol to the following one.
                if (nextSymbol.Text != "when")
                {
                    this.GetNextSymbol(SkipSymbols.All, statementReference, false);
                    matchVariable = this.GetNextExpression(ExpressionPrecedence.Primary, statementReference, unsafeCode);
                    nextSymbol = this.PeekNextSymbol(SkipSymbols.All, unsafeCode);
                }

                // Either a variable was not found, or was found and we moved to the next symbol. Check if this is a 'when' symbol.
                if (nextSymbol.SymbolType == SymbolType.Other && nextSymbol.Text == "when")
                {
                    this.tokens.Add(this.GetToken(CsTokenType.Other, SymbolType.Other, statementReference));
                    whenExpression = this.GetNextExpression(ExpressionPrecedence.None, statementReference, unsafeCode);
                }
            }

            // Get the colon.
            this.tokens.Add(this.GetToken(CsTokenType.LabelColon, SymbolType.Colon, statementReference));

            // Create the statement.
            SwitchCaseStatement caseStatement = new SwitchCaseStatement(identifier, matchVariable, whenExpression);

            // Get each of the sub-statements beneath this statement.
            while (true)
            {
                // Check the type of the next symbol.
                symbol = this.GetNextSymbol(statementReference);

                // Check if we've reached the end of the case statement.
                if (symbol.SymbolType == SymbolType.CloseCurlyBracket || symbol.SymbolType == SymbolType.Case || symbol.SymbolType == SymbolType.Default)
                {
                    break;
                }

                // Read the next child statement.
                Statement statement = this.GetNextStatement(statementReference, unsafeCode, caseStatement.Variables);
                if (statement == null)
                {
                    throw this.CreateSyntaxException();
                }

                // Add it to the case statement.
                caseStatement.AddStatement(statement);
            }

            // Create the token list for the case statement.
            caseStatement.Tokens = new CsTokenList(this.tokens, firstTokenNode, this.tokens.Last);

            statementReference.Target = caseStatement;
            return caseStatement;
        }

        /// <summary>
        /// Reads the next default-statement from the file and returns it.
        /// </summary>
        /// <param name="parentReference">
        /// The parent code unit.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code being parsed resides in an unsafe code block.
        /// </param>
        /// <returns>
        /// Returns the statement.
        /// </returns>
        private SwitchDefaultStatement ParseSwitchDefaultStatement(Reference<ICodePart> parentReference, bool unsafeCode)
        {
            Param.AssertNotNull(parentReference, "parentReference");
            Param.Ignore(unsafeCode);

            Reference<ICodePart> statementReference = new Reference<ICodePart>();

            // Move past the default keyword.
            CsToken firstToken = this.GetToken(CsTokenType.Default, SymbolType.Default, parentReference, statementReference);
            Node<CsToken> firstTokenNode = this.tokens.InsertLast(firstToken);

            // Get the colon.
            this.tokens.Add(this.GetToken(CsTokenType.LabelColon, SymbolType.Colon, statementReference));

            // Create the statement.
            SwitchDefaultStatement defaultStatement = new SwitchDefaultStatement();

            // Get each of the sub-statements beneath this statement.
            while (true)
            {
                // Check the type of the next symbol.
                Symbol symbol = this.GetNextSymbol(statementReference);

                // Check if we've reached the end of the default statement.
                if (symbol.SymbolType == SymbolType.CloseCurlyBracket || symbol.SymbolType == SymbolType.Case || symbol.SymbolType == SymbolType.Default)
                {
                    break;
                }

                // Read the next child statement.
                Statement statement = this.GetNextStatement(statementReference, unsafeCode, defaultStatement.Variables);
                if (statement == null)
                {
                    throw this.CreateSyntaxException();
                }

                // Add it to the default statement.
                defaultStatement.AddStatement(statement);
            }

            // Create the token list for the default statement.
            defaultStatement.Tokens = new CsTokenList(this.tokens, firstTokenNode, this.tokens.Last);

            statementReference.Target = defaultStatement;
            return defaultStatement;
        }

        /// <summary>
        /// Reads the next switch-statement from the file and returns it.
        /// </summary>
        /// <param name="parentReference">
        /// The parent code unit.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code being parsed resides in an unsafe code block.
        /// </param>
        /// <returns>
        /// Returns the statement.
        /// </returns>
        private SwitchStatement ParseSwitchStatement(Reference<ICodePart> parentReference, bool unsafeCode)
        {
            Param.AssertNotNull(parentReference, "parentReference");
            Param.Ignore(unsafeCode);

            Reference<ICodePart> statementReference = new Reference<ICodePart>();

            // Move past the switch keyword.
            CsToken firstToken = this.GetToken(CsTokenType.Switch, SymbolType.Switch, parentReference, statementReference);
            Node<CsToken> firstTokenNode = this.tokens.InsertLast(firstToken);

            // Get the opening parenthesis.
            Bracket openParenthesis = this.GetBracketToken(CsTokenType.OpenParenthesis, SymbolType.OpenParenthesis, statementReference);
            Node<CsToken> openParenthesisNode = this.tokens.InsertLast(openParenthesis);

            // Get the inner expression.
            Expression expression = this.GetNextExpression(ExpressionPrecedence.None, statementReference, unsafeCode);
            if (expression == null)
            {
                throw this.CreateSyntaxException();
            }

            // Get the closing parenthesis.
            Bracket closeParenthesis = this.GetBracketToken(CsTokenType.CloseParenthesis, SymbolType.CloseParenthesis, statementReference);
            Node<CsToken> closeParenthesisNode = this.tokens.InsertLast(closeParenthesis);

            openParenthesis.MatchingBracketNode = closeParenthesisNode;
            closeParenthesis.MatchingBracketNode = openParenthesisNode;

            // Get the opening curly bracket.
            Bracket openingBracket = this.GetBracketToken(CsTokenType.OpenCurlyBracket, SymbolType.OpenCurlyBracket, statementReference);
            Node<CsToken> openingBracketNode = this.tokens.InsertLast(openingBracket);

            // Get the case and default statements.
            SwitchDefaultStatement defaultStatement;
            List<SwitchCaseStatement> caseStatements = this.ParseSwitchStatementCaseStatements(statementReference, unsafeCode, out defaultStatement);

            // Get the closing curly bracket.
            Bracket closingBracket = this.GetBracketToken(CsTokenType.CloseCurlyBracket, SymbolType.CloseCurlyBracket, statementReference);
            Node<CsToken> closingBracketNode = this.tokens.InsertLast(closingBracket);

            openingBracket.MatchingBracketNode = closingBracketNode;
            closingBracket.MatchingBracketNode = openingBracketNode;

            // Create the token list for the statement.
            CsTokenList partialTokens = new CsTokenList(this.tokens, firstTokenNode, this.tokens.Last);

            // Create and return the switch-statement.
            SwitchStatement statement = new SwitchStatement(partialTokens, expression, caseStatements.ToArray(), defaultStatement);
            statementReference.Target = statement;

            return statement;
        }

        /// <summary>
        /// Parses the case and default statements within a switch statement.
        /// </summary>
        /// <param name="statementReference">
        /// A reference to the statement being created.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the statement lies within a block of unsafe code.
        /// </param>
        /// <param name="defaultStatement">
        /// Returns the default statement.
        /// </param>
        /// <returns>
        /// Returns the list of case statements.
        /// </returns>
        private List<SwitchCaseStatement> ParseSwitchStatementCaseStatements(
            Reference<ICodePart> statementReference, bool unsafeCode, out SwitchDefaultStatement defaultStatement)
        {
            Param.AssertNotNull(statementReference, "statementReference");
            Param.Ignore(unsafeCode);

            defaultStatement = null;
            List<SwitchCaseStatement> caseStatements = new List<SwitchCaseStatement>();

            // Find each of the case and default blocks.
            while (true)
            {
                // Get the next symbol and check the type.
                Symbol symbol = this.GetNextSymbol(statementReference);

                if (symbol.SymbolType == SymbolType.Case)
                {
                    caseStatements.Add(this.ParseSwitchCaseStatement(statementReference, unsafeCode));
                }
                else if (symbol.SymbolType == SymbolType.Default)
                {
                    if (defaultStatement != null)
                    {
                        throw new SyntaxException(this.document.SourceCode, symbol.LineNumber);
                    }

                    defaultStatement = this.ParseSwitchDefaultStatement(statementReference, unsafeCode);
                }
                else if (symbol.SymbolType == SymbolType.CloseCurlyBracket)
                {
                    break;
                }
                else
                {
                    // Unexpected symbol.
                    throw new SyntaxException(this.document.SourceCode, symbol.LineNumber);
                }
            }

            return caseStatements;
        }

        /// <summary>
        /// Reads the next throw-statement from the file and returns it.
        /// </summary>
        /// <param name="parentReference">
        /// The parent code unit.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code being parsed resides in an unsafe code block.
        /// </param>
        /// <returns>
        /// Returns the statement.
        /// </returns>
        private ThrowStatement ParseThrowStatement(Reference<ICodePart> parentReference, bool unsafeCode)
        {
            Param.AssertNotNull(parentReference, "parentReference");
            Param.Ignore(unsafeCode);

            Reference<ICodePart> statementReference = new Reference<ICodePart>();

            // Move past the throw keyword.
            CsToken firstToken = this.GetToken(CsTokenType.Throw, SymbolType.Throw, parentReference, statementReference);
            Node<CsToken> firstTokenNode = this.tokens.InsertLast(firstToken);

            // Check the type of the next symbol.
            Symbol symbol = this.GetNextSymbol(statementReference);

            Expression thrownExpression = null;

            if (symbol.SymbolType != SymbolType.Semicolon)
            {
                // Get the expression to throw.
                thrownExpression = this.GetNextExpression(ExpressionPrecedence.None, statementReference, unsafeCode);
                if (thrownExpression == null)
                {
                    throw this.CreateSyntaxException();
                }
            }

            this.tokens.Add(this.GetToken(CsTokenType.Semicolon, SymbolType.Semicolon, statementReference));

            // Create the token list for the statement.
            CsTokenList partialTokens = new CsTokenList(this.tokens, firstTokenNode, firstTokenNode);

            // Create and return the statement.
            ThrowStatement statement = new ThrowStatement(partialTokens, thrownExpression);
            statementReference.Target = statement;

            return statement;
        }

        /// <summary>
        /// Reads the next try-statement from the file and returns it.
        /// </summary>
        /// <param name="parentReference">
        /// The parent code unit.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code being parsed resides in an unsafe code block.
        /// </param>
        /// <returns>
        /// Returns the statement.
        /// </returns>
        private TryStatement ParseTryStatement(Reference<ICodePart> parentReference, bool unsafeCode)
        {
            Param.AssertNotNull(parentReference, "parentReference");
            Param.Ignore(unsafeCode);

            Reference<ICodePart> statementReference = new Reference<ICodePart>();

            // Move past the try keyword.
            CsToken firstToken = this.GetToken(CsTokenType.Try, SymbolType.Try, parentReference, statementReference);
            Node<CsToken> firstTokenNode = this.tokens.InsertLast(firstToken);

            // Get the embedded statement. It must be a block statement.
            BlockStatement childStatement = this.GetNextStatement(statementReference, unsafeCode) as BlockStatement;
            if (childStatement == null)
            {
                throw this.CreateSyntaxException();
            }

            // Create the try-statement now.
            TryStatement statement = new TryStatement(childStatement);

            // Get the attached catch statements, if any.
            List<CatchStatement> catchStatements = new List<CatchStatement>();
            while (true)
            {
                CatchStatement catchStatement = this.GetAttachedCatchStatement(statement, statementReference, unsafeCode);
                if (catchStatement == null)
                {
                    break;
                }

                catchStatements.Add(catchStatement);
            }

            // Get the attached finally statement, if any.
            FinallyStatement finallyStatement = this.GetAttachedFinallyStatement(statement, statementReference, unsafeCode);

            // Create the full token list for the try-statement and add it.
            statement.Tokens = new CsTokenList(this.tokens, firstTokenNode, this.tokens.Last);

            // Add the catch and finally statements to the try statement.
            statement.CatchStatements = catchStatements.ToArray();
            statement.FinallyStatement = finallyStatement;

            // Return the statement.
            statementReference.Target = statement;
            return statement;
        }

        /// <summary>
        /// Reads the next unchecked-statement from the file and returns it.
        /// </summary>
        /// <param name="parentReference">
        /// The parent code unit.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code being parsed resides in an unsafe code block.
        /// </param>
        /// <returns>
        /// Returns the statement.
        /// </returns>
        private UncheckedStatement ParseUncheckedStatement(Reference<ICodePart> parentReference, bool unsafeCode)
        {
            Param.AssertNotNull(parentReference, "parentReference");
            Param.Ignore(unsafeCode);

            Reference<ICodePart> statementReference = new Reference<ICodePart>();

            // Move past the unchecked keyword.
            CsToken firstToken = this.GetToken(CsTokenType.Unchecked, SymbolType.Unchecked, parentReference, statementReference);
            Node<CsToken> firstTokenNode = this.tokens.InsertLast(firstToken);

            // Get the embedded statement. It must be a block statement.
            BlockStatement childStatement = this.GetNextStatement(statementReference, unsafeCode) as BlockStatement;
            if (childStatement == null)
            {
                throw this.CreateSyntaxException();
            }

            // Create the token list for the statement.
            CsTokenList partialTokens = new CsTokenList(this.tokens, firstTokenNode, this.tokens.Last);

            // Create and return the unchecked-statement.
            UncheckedStatement statement = new UncheckedStatement(partialTokens, childStatement);
            statementReference.Target = statement;

            return statement;
        }

        /// <summary>
        /// Reads the next unsafe-statement from the file and returns it.
        /// </summary>
        /// <param name="parentReference">
        /// The parent code unit.
        /// </param>
        /// <returns>
        /// Returns the statement.
        /// </returns>
        private UnsafeStatement ParseUnsafeStatement(Reference<ICodePart> parentReference)
        {
            Param.AssertNotNull(parentReference, "parentReference");
            Reference<ICodePart> statementReference = new Reference<ICodePart>();

            // Move past the unsafe keyword.
            CsToken firstToken = this.GetToken(CsTokenType.Unsafe, SymbolType.Unsafe, parentReference, statementReference);
            Node<CsToken> firstTokenNode = this.tokens.InsertLast(firstToken);

            // Get the embedded statement. It must be a block statement.
            BlockStatement childStatement = this.GetNextStatement(statementReference, true) as BlockStatement;
            if (childStatement == null)
            {
                throw this.CreateSyntaxException();
            }

            // Create the token list for the statement.
            CsTokenList partialTokens = new CsTokenList(this.tokens, firstTokenNode, this.tokens.Last);

            // Create and return the unsafe-statement.
            UnsafeStatement statement = new UnsafeStatement(partialTokens, childStatement);
            statementReference.Target = statement;

            return statement;
        }

        /// <summary>
        /// Reads the next using-statement from the file and returns it.
        /// </summary>
        /// <param name="parentReference">
        /// The parent code unit.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code being parsed resides in an unsafe code block.
        /// </param>
        /// <returns>
        /// Returns the statement.
        /// </returns>
        private UsingStatement ParseUsingStatement(Reference<ICodePart> parentReference, bool unsafeCode)
        {
            Param.AssertNotNull(parentReference, "parentReference");
            Param.Ignore(unsafeCode);

            Reference<ICodePart> statementReference = new Reference<ICodePart>();

            // Move past the using keyword.
            CsToken firstToken = this.GetToken(CsTokenType.Using, SymbolType.Using, parentReference, statementReference);
            Node<CsToken> firstTokenNode = this.tokens.InsertLast(firstToken);

            // Get the opening parenthesis.
            Bracket openParenthesis = this.GetBracketToken(CsTokenType.OpenParenthesis, SymbolType.OpenParenthesis, statementReference);
            Node<CsToken> openParenthesisNode = this.tokens.InsertLast(openParenthesis);

            // Get the expression within the parenthesis.
            Expression expression = this.GetNextExpression(ExpressionPrecedence.None, statementReference, unsafeCode, true, false);
            if (expression == null)
            {
                throw this.CreateSyntaxException();
            }

            // Get the closing parenthesis.
            Bracket closeParenthesis = this.GetBracketToken(CsTokenType.CloseParenthesis, SymbolType.CloseParenthesis, statementReference);
            Node<CsToken> closeParenthesisNode = this.tokens.InsertLast(closeParenthesis);

            openParenthesis.MatchingBracketNode = closeParenthesisNode;
            closeParenthesis.MatchingBracketNode = openParenthesisNode;

            // Get the embedded statement.
            Statement childStatement = this.GetNextStatement(statementReference, unsafeCode);
            if (childStatement == null)
            {
                throw this.CreateSyntaxException();
            }

            // Create the token list for the statement.
            CsTokenList partialTokens = new CsTokenList(this.tokens, firstTokenNode, this.tokens.Last);

            // Create the using-statement.
            UsingStatement statement = new UsingStatement(partialTokens, expression);
            statement.EmbeddedStatement = childStatement;
            statementReference.Target = statement;

            // Add the variable if there is one.
            VariableDeclarationExpression variableDeclaration = expression as VariableDeclarationExpression;
            if (variableDeclaration != null)
            {
                foreach (VariableDeclaratorExpression declarator in variableDeclaration.Declarators)
                {
                    Variable variable = new Variable(
                        variableDeclaration.Type,
                        declarator.Identifier.Token.Text,
                        VariableModifiers.None,
                        CodeLocation.Join(variableDeclaration.Type.Location, declarator.Identifier.Token.Location),
                        statementReference,
                        variableDeclaration.Type.Generated || declarator.Identifier.Token.Generated);

                    // If there is already a variable in this scope with the same name, ignore this one.
                    if (!statement.Variables.Contains(declarator.Identifier.Token.Text))
                    {
                        statement.Variables.Add(variable);
                    }
                }
            }

            return statement;
        }

        /// <summary>
        /// Reads the next variable declaration statement from the file and returns it.
        /// </summary>
        /// <param name="parentReference">
        /// The parent code unit.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code being parsed resides in an unsafe code block.
        /// </param>
        /// <param name="variables">
        /// Returns the list of variables defined in the statement.
        /// </param>
        /// <returns>
        /// Returns the statement.
        /// </returns>
        private VariableDeclarationStatement ParseVariableDeclarationStatement(Reference<ICodePart> parentReference, bool unsafeCode, VariableCollection variables)
        {
            Param.AssertNotNull(parentReference, "parentReference");
            Param.Ignore(unsafeCode);
            Param.Ignore(variables);

            bool constant = false;
            bool isRef = false;

            // Get the first symbol and make sure it is an unknown word or a const.
            Symbol symbol = this.GetNextSymbol(parentReference);

            CsToken firstToken = null;
            Node<CsToken> firstTokenNode = null;

            Reference<ICodePart> statementReference = new Reference<ICodePart>();

            if (symbol.SymbolType == SymbolType.Const)
            {
                constant = true;

                firstToken = new CsToken(symbol.Text, CsTokenType.Const, symbol.Location, statementReference, this.symbols.Generated);
                firstTokenNode = this.tokens.InsertLast(this.GetToken(CsTokenType.Const, SymbolType.Const, statementReference));

                symbol = this.GetNextSymbol(statementReference);
            }
            else if (symbol.SymbolType == SymbolType.Ref)
            {
                isRef = true;

                firstToken = new CsToken(symbol.Text, CsTokenType.Ref, symbol.Location, statementReference, this.symbols.Generated);
                firstTokenNode = this.tokens.InsertLast(this.GetToken(CsTokenType.Ref, SymbolType.Ref, statementReference));

                symbol = this.GetNextSymbol(statementReference);
            }

            if (symbol.SymbolType != SymbolType.Other && symbol.SymbolType != SymbolType.OpenParenthesis)
            {
                throw this.CreateSyntaxException();
            }

            // Get the expression representing the type.
            LiteralExpression type = this.GetTypeTokenExpression(statementReference, unsafeCode, true);
            if (type == null || type.Tokens.First == null)
            {
                throw new SyntaxException(this.document.SourceCode, firstToken.LineNumber);
            }

            if (firstTokenNode == null)
            {
                firstTokenNode = type.Tokens.First;
            }

            // Get the rest of the declaration.
            VariableDeclarationExpression expression = this.GetVariableDeclarationExpression(type, ExpressionPrecedence.None, unsafeCode);

            // Get the closing semicolon.
            this.tokens.Add(this.GetToken(CsTokenType.Semicolon, SymbolType.Semicolon, statementReference));

            // Add each of the variables defined in this statement to the variable list being returned.
            if (variables != null)
            {
                VariableModifiers modifiers = constant ? VariableModifiers.Const : VariableModifiers.None;
                foreach (VariableDeclaratorExpression declarator in expression.Declarators)
                {
                    Variable variable = new Variable(
                        expression.Type,
                        declarator.Identifier.Token.Text,
                        modifiers,
                        CodeLocation.Join(expression.Type.Location, declarator.Identifier.Token.Location),
                        statementReference,
                        expression.Tokens.First.Value.Generated || declarator.Identifier.Token.Generated);

                    // There might already be a variable in this scope with the same name. This can happen
                    // in valid situation when there are ifdef's surrounding portions of the code.
                    // Just accept the first variable and ignore others.
                    if (!variables.Contains(declarator.Identifier.Token.Text))
                    {
                        variables.Add(variable);
                    }
                }
            }

            // Create the token list for the statement.
            CsTokenList partialTokens = new CsTokenList(this.tokens, firstTokenNode, this.tokens.Last);

            VariableDeclarationStatement statement = new VariableDeclarationStatement(partialTokens, constant, isRef, expression);
            statementReference.Target = statement;

            return statement;
        }

        /// <summary>
        /// Reads the next while-statement from the file and returns it.
        /// </summary>
        /// <param name="parentReference">
        /// The parent code unit.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code being parsed resides in an unsafe code block.
        /// </param>
        /// <returns>
        /// Returns the statement.
        /// </returns>
        private WhileStatement ParseWhileStatement(Reference<ICodePart> parentReference, bool unsafeCode)
        {
            Param.AssertNotNull(parentReference, "parentReference");
            Param.Ignore(unsafeCode);

            Reference<ICodePart> statementReference = new Reference<ICodePart>();

            // Add the while keyword.
            CsToken firstToken = this.GetToken(CsTokenType.While, SymbolType.While, parentReference, statementReference);
            Node<CsToken> firstTokenNode = this.tokens.InsertLast(firstToken);

            // Get the opening parenthesis.
            Bracket openParenthesis = this.GetBracketToken(CsTokenType.OpenParenthesis, SymbolType.OpenParenthesis, statementReference);
            Node<CsToken> openParenthesisNode = this.tokens.InsertLast(openParenthesis);

            // Get the expression within the parenthesis.
            Expression expression = this.GetNextExpression(ExpressionPrecedence.None, statementReference, unsafeCode);
            if (expression == null)
            {
                throw this.CreateSyntaxException();
            }

            // Get the closing parenthesis.
            Bracket closeParenthesis = this.GetBracketToken(CsTokenType.CloseParenthesis, SymbolType.CloseParenthesis, statementReference);
            Node<CsToken> closeParenthesisNode = this.tokens.InsertLast(closeParenthesis);

            openParenthesis.MatchingBracketNode = closeParenthesisNode;
            closeParenthesis.MatchingBracketNode = openParenthesisNode;

            // Get the embedded statement.
            Statement childStatement = this.GetNextStatement(statementReference, unsafeCode);
            if (childStatement == null)
            {
                throw new SyntaxException(this.document.SourceCode, firstToken.LineNumber);
            }

            // Create the token list for the statement.
            CsTokenList partialTokens = new CsTokenList(this.tokens, firstTokenNode, this.tokens.Last);

            // Create and return the while-statement.
            WhileStatement statement = new WhileStatement(partialTokens, expression);
            statement.EmbeddedStatement = childStatement;
            statementReference.Target = statement;

            return statement;
        }

        /// <summary>
        /// Reads the next yield-statement from the file and returns it.
        /// </summary>
        /// <param name="parentReference">
        /// The parent code unit.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code being parsed resides in an unsafe code block.
        /// </param>
        /// <returns>
        /// Returns the statement.
        /// </returns>
        private YieldStatement ParseYieldStatement(Reference<ICodePart> parentReference, bool unsafeCode)
        {
            Param.AssertNotNull(parentReference, "parentReference");
            Param.Ignore(unsafeCode);

            Symbol symbol = this.PeekNextSymbolFrom(1, SkipSymbols.All, false, out _);

            // If the next symbol is not one of these, then in this context, yield is not a keyword
            if (symbol.SymbolType != SymbolType.Return && symbol.SymbolType != SymbolType.Break)
            {
                return null;
            }

            Reference<ICodePart> statementReference = new Reference<ICodePart>();

            // Move past the yield keyword.
            CsToken firstToken = this.GetToken(CsTokenType.Yield, SymbolType.Other, parentReference, statementReference);
            Node<CsToken> firstTokenNode = this.tokens.InsertLast(firstToken);

            // Get the next word, which must either be break or return.
            symbol = this.GetNextSymbol(statementReference);

            YieldStatement.Type yieldType;
            Expression returnValue = null;

            if (symbol.SymbolType == SymbolType.Return)
            {
                yieldType = YieldStatement.Type.Return;
                this.tokens.Add(this.GetToken(CsTokenType.Return, SymbolType.Return, statementReference));

                // Get the expression to return.
                returnValue = this.GetNextExpression(ExpressionPrecedence.None, statementReference, unsafeCode);
                if (returnValue == null)
                {
                    throw this.CreateSyntaxException();
                }
            }
            else if (symbol.SymbolType == SymbolType.Break)
            {
                yieldType = YieldStatement.Type.Break;
                this.tokens.Add(this.GetToken(CsTokenType.Break, SymbolType.Break, statementReference));
            }
            else
            {
                throw this.CreateSyntaxException();
            }

            // Get the closing semicolon.
            this.tokens.Add(this.GetToken(CsTokenType.Semicolon, SymbolType.Semicolon, statementReference));

            // Create the token list for the statement.
            CsTokenList partialTokens = new CsTokenList(this.tokens, firstTokenNode, firstTokenNode);

            // Create and return the statement.
            YieldStatement statement = new YieldStatement(partialTokens, yieldType, returnValue);
            statementReference.Target = statement;

            return statement;
        }

        /// <summary>
        /// Reads the next local function statement from the file and returns it.
        /// </summary>
        /// <param name="unsafeCode">
        /// Indicates whether the code being parsed resides in an unsafe code block.
        /// </param>
        /// <returns>
        /// Returns the statement.
        /// </returns>
        private LocalFunctionStatement ParseLocalFunctionStatement(bool unsafeCode)
        {
            Param.Ignore(unsafeCode);

            Reference<ICodePart> statementReference = new Reference<ICodePart>();
            Node<CsToken> previousToken = this.tokens.Last;

            // Check if the method's return type is ref.
            Symbol nextSymbol = this.PeekNextSymbol(SkipSymbols.All, false);
            bool returnTypeIsRef = false;

            if (nextSymbol.SymbolType == SymbolType.Ref)
            {
                this.tokens.Add(this.GetToken(CsTokenType.Ref, SymbolType.Ref, statementReference));
                returnTypeIsRef = true;
            }
            else if (nextSymbol.SymbolType == SymbolType.Other && nextSymbol.Text == "async")
            {
                this.tokens.Add(this.GetToken(CsTokenType.Async, SymbolType.Other, statementReference));
            }

            // Get the return type.
            TypeToken returnType = this.GetTypeToken(statementReference, unsafeCode, true);
            this.tokens.Add(returnType);

            // Get the name of the method.
            LiteralExpression name = this.GetLiteralExpression(statementReference, unsafeCode);

            // Get the parameter list.
            IList<Parameter> parameters = this.ParseParameterList(statementReference, unsafeCode, SymbolType.OpenParenthesis, false);

            // Check whether there are any type constraint clauses.
            ICollection<TypeParameterConstraintClause> typeConstraints = null;
            nextSymbol = this.GetNextSymbol(statementReference);
            if (nextSymbol.Text == "where")
            {
                typeConstraints = this.ParseTypeConstraintClauses(statementReference, unsafeCode);
            }

            // Prepare a partial list of tokens for this statement.
            CsTokenList partialTokens = new CsTokenList(this.tokens, previousToken?.Next ?? this.tokens.First, this.tokens.Last);

            // Now get the function body, which could be a block or an expression;
            nextSymbol = this.PeekNextSymbol(SkipSymbols.All, false);
            LocalFunctionStatement statement = null;

            if (nextSymbol.SymbolType == SymbolType.Lambda)
            {
                // Get expression and the closing semicolon.
                Expression expression = this.GetNextExpression(ExpressionPrecedence.None, statementReference, unsafeCode);
                this.tokens.Add(this.GetToken(CsTokenType.Semicolon, SymbolType.Semicolon, statementReference));

                statement = new LocalFunctionStatement(
                    partialTokens,
                    returnType,
                    returnTypeIsRef,
                    name,
                    parameters,
                    typeConstraints,
                    expression);
            }
            else if (nextSymbol.SymbolType == SymbolType.OpenCurlyBracket)
            {
                Statement functionBody = this.GetNextStatement(statementReference, unsafeCode);
                statement = new LocalFunctionStatement(
                    partialTokens,
                    returnType,
                    returnTypeIsRef,
                    name,
                    parameters,
                    typeConstraints,
                    functionBody);
            }
            else
            {
                this.CreateSyntaxException();
            }

            // Create the statement and return it.
            statementReference.Target = statement;
            return statement;
        }

        /// <summary>
        /// Inspects the next few symbols after the open parenthesis and identifies the statement type.
        /// </summary>
        /// <param name="parentReference">
        /// The parent code unit.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code being parsed resides in an unsafe code block.
        /// </param>
        /// <param name="variables">
        /// Returns the list of variables defined in the statement.
        /// </param>
        /// <returns>The statement that starts with open parenthesis.</returns>
        private Statement DetectAndGetStatementForOpenParenthesis(Reference<ICodePart> parentReference, bool unsafeCode, VariableCollection variables)
        {
            int foundPosition = this.DetectTupleType(0);

            if (foundPosition == 0)
            {
                return this.ParseExpressionStatement(unsafeCode);
            }

            SymbolType symbolType = this.PeekNextSymbolFrom(foundPosition, SkipSymbols.All, false, out foundPosition).SymbolType;

            // The next symbol should be (variable/method name) or a this keyword.
            if (symbolType != SymbolType.Other)
            {
                return this.ParseExpressionStatement(unsafeCode);
            }

            // Grab the next symbol, to detect the statement type.
            symbolType = this.PeekNextSymbolFrom(foundPosition, SkipSymbols.All, false, out foundPosition).SymbolType;

            if (symbolType == SymbolType.Semicolon || symbolType == SymbolType.Equals)
            {
                // Starts with a tuple type, this is a tuple vairable declaration.
                return this.ParseVariableDeclarationStatement(parentReference, unsafeCode, variables);
            }

            if (symbolType == SymbolType.OpenParenthesis || symbolType == SymbolType.LessThan)
            {
                // Local function statement that returns a tuple.
                return this.ParseLocalFunctionStatement(unsafeCode);
            }

            return this.ParseExpressionStatement(unsafeCode);
        }

        #endregion
    }
}