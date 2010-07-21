//-----------------------------------------------------------------------
// <copyright file="CodeParser.Statements.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.
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
namespace Microsoft.StyleCop.CSharp
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using Microsoft.StyleCop;

    /// <content>
    /// Contains code for parsing statements within a C# code file.
    /// </content>
    internal partial class CodeParser
    {
        #region Private Methods

        /// <summary>
        /// Parses the body of an element that contains a list of statements as children.
        /// </summary>
        /// <param name="elementProxy">Proxy for the element being created.</param>
        /// <param name="element">The element to parse.</param>
        /// <param name="interfaceType">Indicates whether this type of statement container can appear in an interface.</param>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        private void ParseStatementContainer(CodeUnitProxy elementProxy, Element element, bool interfaceType, bool unsafeCode)
        {
            Param.AssertNotNull(elementProxy, "elementProxy");
            Param.AssertNotNull(element, "element");
            Param.Ignore(interfaceType);
            Param.Ignore(unsafeCode);

            // Check to see if the item is unsafe. This is the case if the item's parent is unsafe, or if it
            // has the unsafe keyword itself.
            unsafeCode |= element.ContainsModifier(TokenType.Unsafe);

            // The next symbol must be an opening curly bracket.
            Symbol symbol = this.PeekNextSymbol();
            if (symbol == null)
            {
                throw this.CreateSyntaxException();
            }

            if (symbol.SymbolType == SymbolType.OpenCurlyBracket)
            {
                // Add the bracket token to the document.
                BracketToken openingBracket = (BracketToken)this.GetToken(elementProxy, TokenType.OpenCurlyBracket, SymbolType.OpenCurlyBracket);

                // Parse the contents of the element.
                BracketToken closingBracket = this.ParseStatementScope(elementProxy, unsafeCode);
                if (closingBracket == null)
                {
                    // If we failed to get a closing bracket back, then there is a syntax
                    // error in the document since there is an opening bracket with no matching
                    // closing bracket.
                    throw this.CreateSyntaxException();
                }

                openingBracket.MatchingBracket = closingBracket;
                closingBracket.MatchingBracket = openingBracket;
            }
            else if (interfaceType && symbol.SymbolType == SymbolType.Semicolon)
            {
                // Add the semicolon to the document.
                this.GetToken(elementProxy, TokenType.Semicolon, SymbolType.Semicolon);
            }
            else
            {
                throw new SyntaxException(this.document, symbol.LineNumber);
            }
        }

        /// <summary>
        /// Parses the body of an element that contains a list of statements as children.
        /// </summary>
        /// <param name="parentProxy">Represents the parent item.</param>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <returns>Returns the closing curly bracket.</returns>
        private BracketToken ParseStatementScope(CodeUnitProxy parentProxy, bool unsafeCode)
        {
            Param.AssertNotNull(parentProxy, "parentProxy");
            Param.Ignore(unsafeCode);

            BracketToken closeBracket = null;

            // Keep looping until all the child elements within this container element have been processed.
            while (true)
            {
                // If the next symbol is a closing curly bracket, or we've reached the end of the symbols list, 
                // we're done with this scope.
                Symbol symbol = this.PeekNextSymbol(true);
                if (symbol == null)
                {
                    // We've reached the end of the document.
                    break;
                }
                else if (symbol.SymbolType == SymbolType.CloseCurlyBracket)
                {
                    // We've reached the end of the element. Save the closing bracket and exit.
                    closeBracket = (BracketToken)this.GetToken(parentProxy, TokenType.CloseCurlyBracket, SymbolType.CloseCurlyBracket);
                    break;
                }
                else
                {
                    this.GetNextStatement(parentProxy, unsafeCode);
                }
            }

            return closeBracket;
        }

        /// <summary>
        /// Reads the next statement from the file and returns it.
        /// </summary>
        /// <param name="parentProxy">Represents the parent item.</param>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <returns>Returns the statement.</returns>
        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "May be simplified later.")]
        private Statement GetNextStatement(CodeUnitProxy parentProxy, bool unsafeCode)
        {
            Param.AssertNotNull(parentProxy, "parentProxy");
            Param.Ignore(unsafeCode);

            // Saves the next statement.
            Statement statement = null;

            Symbol symbol = this.PeekNextSymbol();
            if (symbol.SymbolType != SymbolType.CloseCurlyBracket)
            {
                // Collect everything up to the start of the statement.
                this.AdvanceToNextCodeSymbol(parentProxy);

                switch (symbol.SymbolType)
                {
                    case SymbolType.Other:
                        if (symbol.Text == "yield")
                        {
                            statement = this.GetYieldStatement(parentProxy, unsafeCode);
                            if (statement != null)
                            {
                                break;
                            }
                        }

                        statement = this.GetOtherStatement(parentProxy, unsafeCode);
                        break;

                    case SymbolType.OpenCurlyBracket:
                        statement = this.GetBlockStatement(parentProxy, unsafeCode);
                        break;

                    case SymbolType.If:
                        statement = this.GetIfStatement(parentProxy, unsafeCode);
                        break;

                    case SymbolType.While:
                        statement = this.GetWhileStatement(parentProxy, unsafeCode);
                        break;

                    case SymbolType.Do:
                        statement = this.GetDoWhileStatement(parentProxy, unsafeCode);
                        break;

                    case SymbolType.For:
                        statement = this.GetForStatement(parentProxy, unsafeCode);
                        break;

                    case SymbolType.Foreach:
                        statement = this.GetForeachStatement(parentProxy, unsafeCode);
                        break;

                    case SymbolType.Switch:
                        statement = this.GetSwitchStatement(parentProxy, unsafeCode);
                        break;

                    case SymbolType.Try:
                        statement = this.GetTryStatement(parentProxy, unsafeCode);
                        break;

                    case SymbolType.Lock:
                        statement = this.GetLockStatement(parentProxy, unsafeCode);
                        break;

                    case SymbolType.Using:
                        statement = this.GetUsingStatement(parentProxy, unsafeCode);
                        break;

                    case SymbolType.Checked:
                        statement = this.GetCheckedStatement(parentProxy, unsafeCode);
                        break;

                    case SymbolType.Unchecked:
                        statement = this.GetUncheckedStatement(parentProxy, unsafeCode);
                        break;

                    case SymbolType.Fixed:
                        statement = this.GetFixedStatement(parentProxy, unsafeCode);
                        break;

                    case SymbolType.Unsafe:
                        statement = this.GetUnsafeStatement(parentProxy);
                        break;

                    case SymbolType.Break:
                        statement = this.GetBreakStatement(parentProxy);
                        break;

                    case SymbolType.Continue:
                        statement = this.GetContinueStatement(parentProxy);
                        break;

                    case SymbolType.Goto:
                        statement = this.GetGotoStatement(parentProxy, unsafeCode);
                        break;

                    case SymbolType.Return:
                        statement = this.GetReturnStatement(parentProxy, unsafeCode);
                        break;

                    case SymbolType.Throw:
                        statement = this.GetThrowStatement(parentProxy, unsafeCode);
                        break;

                    case SymbolType.Typeof:
                    case SymbolType.Sizeof:
                        statement = this.GetExpressionStatement(parentProxy, unsafeCode);
                        break;

                    case SymbolType.Const:
                        statement = this.GetVariableDeclarationStatement(parentProxy, unsafeCode);
                        break;

                    case SymbolType.Increment:
                    case SymbolType.Decrement:
                    case SymbolType.New:
                    case SymbolType.This:
                    case SymbolType.Base:
                    case SymbolType.OpenParenthesis:
                        statement = this.GetExpressionStatement(parentProxy, unsafeCode);
                        break;

                    case SymbolType.Semicolon:
                        var emptyStatementProxy = new CodeUnitProxy(this.document);
                        this.GetToken(emptyStatementProxy, TokenType.Semicolon, SymbolType.Semicolon);
                        statement = new EmptyStatement(emptyStatementProxy);
                        parentProxy.Children.Add(statement);
                        break;

                    case SymbolType.Multiplication:
                        if (!unsafeCode)
                        {
                            goto default;
                        }

                        statement = this.GetExpressionStatement(parentProxy, unsafeCode);
                        break;

                    case SymbolType.LogicalAnd:
                        if (!unsafeCode)
                        {
                            goto default;
                        }

                        statement = this.GetExpressionStatement(parentProxy, unsafeCode);
                        break;

                    default:
                        throw new SyntaxException(this.document, symbol.LineNumber);
                }
            }

            return statement;
        }

        /// <summary>
        /// Reads a statement beginning with an unknown word.
        /// </summary>
        /// <param name="parentProxy">Represents the parent item.</param>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <returns>Returns the statement.</returns>
        private Statement GetOtherStatement(CodeUnitProxy parentProxy, bool unsafeCode)
        {
            Param.AssertNotNull(parentProxy, "parentProxy");
            Param.Ignore(unsafeCode);

            // Determine whether this has the signature of a type.
            if (this.IsVariableDeclarationStatement(unsafeCode))
            {
                return this.GetVariableDeclarationStatement(parentProxy, unsafeCode);
            }
            else
            {
                // Get the next symbol after the name.
                int index = this.GetNextCodeSymbolIndex(2);
                if (index == -1 || this.symbols.Peek(index).SymbolType != SymbolType.Colon)
                {
                    return this.GetExpressionStatement(parentProxy, unsafeCode);
                }
                else
                {
                    return this.GetLabelStatement(parentProxy, unsafeCode);
                }
            }
        }

        /// <summary>
        /// Determines whether the symbol manager is advanced up to the start of a variable declaration statement.
        /// </summary>
        /// <param name="unsafeCode">Indicates whether the code is unsafe.</param>
        /// <returns>Returns true if the next statement is a variable declaration statement.</returns>
        private bool IsVariableDeclarationStatement(bool unsafeCode)
        {
            Param.Ignore(unsafeCode);

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
                            if (temp.SymbolType == SymbolType.Equals ||
                                temp.SymbolType == SymbolType.Semicolon ||
                                temp.SymbolType == SymbolType.Comma)
                            {
                                // This is a variable declaration statement.
                                variableDeclaration = true;
                            }
                        }
                    }
                }
            }

            return variableDeclaration;
        }

        /// <summary>
        /// Reads the next variable declaration statement from the file and returns it.
        /// </summary>
        /// <param name="parentProxy">Represents the parent item.</param>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <returns>Returns the statement.</returns>
        private VariableDeclarationStatement GetVariableDeclarationStatement(CodeUnitProxy parentProxy, bool unsafeCode)
        {
            Param.AssertNotNull(parentProxy, "parentProxy");
            Param.Ignore(unsafeCode);

            bool constant = false;
            var statementProxy = new CodeUnitProxy(this.document);

            // Get the first symbol and make sure it is an unknown word or a const.
            Symbol symbol = this.PeekNextSymbol();

            Token firstToken = null;

            if (symbol.SymbolType == SymbolType.Const)
            {
                this.AdvanceToNextCodeSymbol(statementProxy);
                constant = true;

                this.GetToken(statementProxy, TokenType.Const, SymbolType.Const);

                symbol = this.PeekNextSymbol();
            }

            if (symbol.SymbolType != SymbolType.Other)
            {
                throw this.CreateSyntaxException();
            }

            // Get the expression representing the type.
            var variableDeclarationExpressionProxy = new CodeUnitProxy(this.document);
            LiteralExpression type = this.GetTypeTokenExpression(variableDeclarationExpressionProxy, unsafeCode, true);
            if (type == null || type.Children.Count == 0)
            {
                throw new SyntaxException(this.document, firstToken.LineNumber);
            }

            // Get the rest of the declaration.
            this.AdvanceToNextCodeSymbol(variableDeclarationExpressionProxy);
            VariableDeclarationExpression variableDeclarationExpression = this.GetVariableDeclarationExpression(variableDeclarationExpressionProxy, statementProxy, type, ExpressionPrecedence.None, unsafeCode);

            // Get the closing semicolon.
            this.GetToken(statementProxy, TokenType.Semicolon, SymbolType.Semicolon);
            
            var statement = new VariableDeclarationStatement(statementProxy, constant, variableDeclarationExpression);
            parentProxy.Children.Add(statement);

            return statement;
        }

        /// <summary>
        /// Reads a label statement.
        /// </summary>
        /// <param name="parentProxy">Represents the parent item.</param>
        /// <param name="unsafeCode">Indicates whether the code is marked as unsafe.</param>
        /// <returns>Returns the statement.</returns>
        private LabelStatement GetLabelStatement(CodeUnitProxy parentProxy, bool unsafeCode)
        {
            Param.AssertNotNull(parentProxy, "parentProxy");
            Param.Ignore(unsafeCode);

            var statementProxy = new CodeUnitProxy(this.document);
            
            // The first symbol must be an unknown word.
            Symbol symbol = this.PeekNextSymbol();
            if (symbol.SymbolType != SymbolType.Other)
            {
                throw this.CreateSyntaxException();
            }

            // Get the literal expression for this symbol.
            LiteralExpression identifier = this.GetLiteralExpression(statementProxy, unsafeCode);
            if (identifier == null || identifier.Children.Count == 0)
            {
                throw this.CreateSyntaxException();
            }

            // The next symbol must be the colon.
            this.GetToken(statementProxy, TokenType.LabelColon, SymbolType.Colon);

            var statement = new LabelStatement(statementProxy, identifier);
            parentProxy.Children.Add(statement);

            return statement;
        }

        /// <summary>
        /// Reads the next expression statement from the file and returns it.
        /// </summary>
        /// <param name="parentProxy">Represents the parent item.</param>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <returns>Returns the statement.</returns>
        private ExpressionStatement GetExpressionStatement(CodeUnitProxy parentProxy, bool unsafeCode)
        {
            Param.AssertNotNull(parentProxy, "parentProxy");
            Param.Ignore(unsafeCode);

            var statementProxy = new CodeUnitProxy(this.document);

            // Get the expression.
            Expression expression = this.GetNextExpression(statementProxy, ExpressionPrecedence.None, unsafeCode);
            if (expression == null || expression.Children.Count == 0)
            {
                throw this.CreateSyntaxException();
            }

            // Read up to the semicolon.
            this.GetToken(statementProxy, TokenType.Semicolon, SymbolType.Semicolon);

            // Create and return the statement.
            var statement = new ExpressionStatement(statementProxy, expression);
            parentProxy.Children.Add(statement);

            return statement;
        }

        /// <summary>
        /// Reads the next block statement from the file and returns it.
        /// </summary>
        /// <param name="parentProxy">Represents the parent item.</param>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <returns>Returns the statement.</returns>
        private BlockStatement GetBlockStatement(CodeUnitProxy parentProxy, bool unsafeCode)
        {
            Param.AssertNotNull(parentProxy, "parentProxy");
            Param.Ignore(unsafeCode);

            // Create the block statement.
            var statementProxy = new CodeUnitProxy(this.document);
            var block = new BlockStatement(statementProxy);

            // Get the opening bracket keyword.
            BracketToken openingBracket = (BracketToken)this.GetToken(statementProxy, TokenType.OpenCurlyBracket, SymbolType.OpenCurlyBracket);

            // Get the rest of the statement.
            BracketToken closingBracket = this.ParseStatementScope(statementProxy, unsafeCode);
            if (closingBracket == null)
            {
                // If we failed to get a closing bracket back, then there is a syntax
                // error in the document since there is an opening bracket with no matching
                // closing bracket.
                throw this.CreateSyntaxException();
            }

            openingBracket.MatchingBracket = closingBracket;
            closingBracket.MatchingBracket = openingBracket;

            parentProxy.Children.Add(block);

            return block;
        }

        /// <summary>
        /// Reads the next if-statement from the file and returns it.
        /// </summary>
        /// <param name="parentProxy">Represents the parent item.</param>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <returns>Returns the statement.</returns>
        private IfStatement GetIfStatement(CodeUnitProxy parentProxy, bool unsafeCode)
        {
            Param.AssertNotNull(parentProxy, "parentProxy");
            Param.Ignore(unsafeCode);

            var statementProxy = new CodeUnitProxy(this.document);
            
            // Move past the if keyword.
            this.GetToken(statementProxy, TokenType.If, SymbolType.If);

            // Get the opening parenthesis.
            BracketToken openParenthesis = (BracketToken)this.GetToken(statementProxy, TokenType.OpenParenthesis, SymbolType.OpenParenthesis);

            // Get the expression within the parenthesis.
            Expression expression = this.GetNextExpression(statementProxy, ExpressionPrecedence.None, unsafeCode);
            if (expression == null)
            {
                throw this.CreateSyntaxException();
            }

            // Get the closing parenthesis.
            BracketToken closeParenthesis = (BracketToken)this.GetToken(statementProxy, TokenType.CloseParenthesis, SymbolType.CloseParenthesis);

            openParenthesis.MatchingBracket = closeParenthesis;
            closeParenthesis.MatchingBracket = openParenthesis;

            // Get the embedded statement.
            Statement childStatement = this.GetNextStatement(statementProxy, unsafeCode);
            if (childStatement == null)
            {
                throw this.CreateSyntaxException();
            }

            // Create the if-statement.
            var statement = new IfStatement(statementProxy, expression);
            parentProxy.Children.Add(statement);

            // Check if there is an else or an else-if attached to this statement.
            this.GetAttachedElseStatement(parentProxy, unsafeCode);

            return statement;
        }

        /// <summary>
        /// Looks for an else-statement, and if it is found, parses and returns it.
        /// </summary>
        /// <param name="parentProxy">Represents the parent item.</param>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <returns>Returns the statement.</returns>
        private ElseStatement GetAttachedElseStatement(CodeUnitProxy parentProxy, bool unsafeCode)
        {
            Param.AssertNotNull(parentProxy, "parentProxy");
            Param.Ignore(unsafeCode);

            // Check to see whether there is an attached else statement.
            Symbol symbol = this.PeekNextSymbol();
            if (symbol.SymbolType != SymbolType.Else)
            {
                return null;
            }

            this.AdvanceToNextCodeSymbol(parentProxy);
            var statementProxy = new CodeUnitProxy(this.document);

            // Advance to this keyword and add it.
            this.GetToken(statementProxy, TokenType.Else, SymbolType.Else);

            // Check if the next keyword is an if.
            Expression conditional = null;
            
            symbol = this.PeekNextSymbol();
            if (symbol.SymbolType == SymbolType.If)
            {
                // Advance to this keyword and add it.
                this.GetToken(statementProxy, TokenType.If, SymbolType.If); 

                // Get the opening parenthesis.
                BracketToken openParenthesis = (BracketToken)this.GetToken(statementProxy, TokenType.OpenParenthesis, SymbolType.OpenParenthesis);

                // Get the expression within the parenthesis.
                conditional = this.GetNextExpression(statementProxy, ExpressionPrecedence.None, unsafeCode);
                if (conditional == null)
                {
                    throw new SyntaxException(this.document, symbol.LineNumber);
                }

                // Get the closing parenthesis.
                BracketToken closeParenthesis = (BracketToken)this.GetToken(statementProxy, TokenType.CloseParenthesis, SymbolType.CloseParenthesis);

                openParenthesis.MatchingBracket = closeParenthesis;
                closeParenthesis.MatchingBracket = openParenthesis;
            }

            // Get the embedded statement.
            Statement childStatement = this.GetNextStatement(statementProxy, unsafeCode);
            if (childStatement == null)
            {
                throw this.CreateSyntaxException();
            }

            // Create the else-statement.
            var statement = new ElseStatement(statementProxy, conditional);
            parentProxy.Children.Add(statement);

            // Check if there is another else or an else-if attached to this statement.
            this.GetAttachedElseStatement(parentProxy, unsafeCode);

            return statement;
        }

        /// <summary>
        /// Reads the next while-statement from the file and returns it.
        /// </summary>
        /// <param name="parentProxy">Represents the parent item.</param>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <returns>Returns the statement.</returns>
        private WhileStatement GetWhileStatement(CodeUnitProxy parentProxy, bool unsafeCode)
        {
            Param.AssertNotNull(parentProxy, "parentProxy");
            Param.Ignore(unsafeCode);

            var statementProxy = new CodeUnitProxy(this.document);
            
            // Add the while keyword.
            this.GetToken(statementProxy, TokenType.While, SymbolType.While);

            // Get the opening parenthesis.
            BracketToken openParenthesis = (BracketToken)this.GetToken(statementProxy, TokenType.OpenParenthesis, SymbolType.OpenParenthesis);

            // Get the expression within the parenthesis.
            Expression expression = this.GetNextExpression(statementProxy, ExpressionPrecedence.None, unsafeCode);
            if (expression == null)
            {
                throw this.CreateSyntaxException();
            }

            // Get the closing parenthesis.
            BracketToken closeParenthesis = (BracketToken)this.GetToken(statementProxy, TokenType.CloseParenthesis, SymbolType.CloseParenthesis);

            openParenthesis.MatchingBracket = closeParenthesis;
            closeParenthesis.MatchingBracket = openParenthesis;

            // Get the embedded statement.
            Statement childStatement = this.GetNextStatement(statementProxy, unsafeCode);
            if (childStatement == null)
            {
                throw this.CreateSyntaxException();
            }

            // Create and return the while-statement.
            var statement = new WhileStatement(statementProxy, expression);
            parentProxy.Children.Add(statement);

            return statement;
        }

        /// <summary>
        /// Reads the next do-while-statement from the file and returns it.
        /// </summary>
        /// <param name="parentProxy">Represents the parent item.</param>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <returns>Returns the statement.</returns>
        private DoWhileStatement GetDoWhileStatement(CodeUnitProxy parentProxy, bool unsafeCode)
        {
            Param.AssertNotNull(parentProxy, "parentProxy");
            Param.Ignore(unsafeCode);

            var statementProxy = new CodeUnitProxy(this.document);
            
            // Add the do keyword.
            this.GetToken(statementProxy, TokenType.Do, SymbolType.Do);

            // Get the attached statement.
            Statement childStatement = this.GetNextStatement(statementProxy, unsafeCode);
            if (childStatement == null || childStatement.Children.Count == 0)
            {
                throw this.CreateSyntaxException();
            }

            // Get the while keyword and add it.
            this.GetToken(statementProxy, TokenType.WhileDo, SymbolType.While);

            // Get the opening parenthesis and add it.
            BracketToken openParenthesis = (BracketToken)this.GetToken(statementProxy, TokenType.OpenParenthesis, SymbolType.OpenParenthesis);

            // Get the expression within the parenthesis.
            Expression expression = this.GetNextExpression(statementProxy, ExpressionPrecedence.None, unsafeCode);
            if (expression == null)
            {
                throw this.CreateSyntaxException();
            }

            // Get the closing parenthesis.
            BracketToken closeParenthesis = (BracketToken)this.GetToken(statementProxy, TokenType.CloseParenthesis, SymbolType.CloseParenthesis);

            openParenthesis.MatchingBracket = closeParenthesis;
            closeParenthesis.MatchingBracket = openParenthesis;

            // Get the closing semicolon.
            this.GetToken(statementProxy, TokenType.Semicolon, SymbolType.Semicolon);

            // Create and return the do-while-statement.
            var statement = new DoWhileStatement(statementProxy, expression, childStatement);
            parentProxy.Children.Add(statement);

            return statement;
        }

        /// <summary>
        /// Reads the next for-statement from the file and returns it.
        /// </summary>
        /// <param name="parentProxy">Represents the parent item.</param>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <returns>Returns the statement.</returns>
        private ForStatement GetForStatement(CodeUnitProxy parentProxy, bool unsafeCode)
        {
            Param.AssertNotNull(parentProxy, "parentProxy");
            Param.Ignore(unsafeCode);

            var statementProxy = new CodeUnitProxy(this.document);
            
            // Add the for keyword.
            this.GetToken(statementProxy, TokenType.For, SymbolType.For);

            // Get the opening parenthesis.
            BracketToken openParenthesis = (BracketToken)this.GetToken(statementProxy, TokenType.OpenParenthesis, SymbolType.OpenParenthesis);

            // Get each of the initializers.
            List<Expression> initializers = this.GetForStatementInitializers(statementProxy, unsafeCode);

            // Get the condition expression.
            Expression condition = this.GetForStatementCondition(statementProxy, unsafeCode);

            // Get the iterators.
            List<Expression> iterators = this.GetForStatementIterators(statementProxy, unsafeCode, openParenthesis);

            // Get the embedded statement.
            Statement childStatement = this.GetNextStatement(statementProxy, unsafeCode);
            if (childStatement == null || childStatement.Children.Count == 0)
            {
                throw this.CreateSyntaxException();
            }

            // Create and return the for-statement.
            var statement = new ForStatement(statementProxy, initializers.AsReadOnly(), condition, iterators.ToArray());
            parentProxy.Children.Add(statement);

            return statement;
        }

        /// <summary>
        /// Parses the initializers from a for-statement.
        /// </summary>
        /// <param name="forStatementProxy">Proxy object for the statement being created.</param>
        /// <param name="unsafeCode">Indicates whether the code is located within an unsafe block.</param>
        /// <returns>Returns the list of initializers.</returns>
        private List<Expression> GetForStatementInitializers(CodeUnitProxy forStatementProxy, bool unsafeCode)
        {
            Param.AssertNotNull(forStatementProxy, "forStatementProxy");
            Param.Ignore(unsafeCode);

            var initializers = new List<Expression>();

            while (true)
            {
                // Check the type of the next symbol.
                Symbol symbol = this.PeekNextSymbol();

                if (symbol.SymbolType == SymbolType.Semicolon)
                {
                    // This is the end of the initializer list. Add the semicolon and break.
                    this.GetToken(forStatementProxy, TokenType.Semicolon, SymbolType.Semicolon);
                    break;
                }

                // Get the next identifier expression.
                Expression initializer = this.GetNextExpression(forStatementProxy, ExpressionPrecedence.None, unsafeCode, true, false);
                if (initializer == null || initializer.Children.Count == 0)
                {
                    throw this.CreateSyntaxException();
                }

                // Add the initializer to the list.
                initializers.Add(initializer);

                // If the next symbol is a comma, save it.
                symbol = this.PeekNextSymbol();

                if (symbol.SymbolType == SymbolType.Comma)
                {
                    this.GetToken(forStatementProxy, TokenType.Comma, SymbolType.Comma);
                }
                else if (symbol.SymbolType != SymbolType.Semicolon)
                {
                    // If it's not a comma it must be a semicolon.
                    throw new SyntaxException(this.document, symbol.LineNumber);
                }
            }

            return initializers;
        }

        /// <summary>
        /// Parses the condition expression from a for-statement.
        /// </summary>
        /// <param name="forStatementProxy">Proxy object for the statement being created.</param>
        /// <param name="unsafeCode">Indicates whether the code is located within an unsafe block.</param>
        /// <returns>Returns the condition expression.</returns>
        private Expression GetForStatementCondition(CodeUnitProxy forStatementProxy, bool unsafeCode)
        {
            Param.AssertNotNull(forStatementProxy, "forStatementProxy");
            Param.Ignore(unsafeCode);
        
            // Now get the condition expression if there is one.
            Symbol symbol = this.PeekNextSymbol();

            Expression condition = null;
            if (symbol.SymbolType != SymbolType.Semicolon)
            {
                condition = this.GetNextExpression(forStatementProxy, ExpressionPrecedence.None, unsafeCode);
                if (condition == null || condition.Children.Count == 0)
                {
                    throw this.CreateSyntaxException();
                }

                // Get the next symbol.
                symbol = this.PeekNextSymbol();
            }

            // The next symbol must be a semicolon.
            if (symbol.SymbolType != SymbolType.Semicolon)
            {
                throw new SyntaxException(this.document, symbol.LineNumber);
            }

            // Add the semicolon.
            this.GetToken(forStatementProxy, TokenType.Semicolon, SymbolType.Semicolon);

            return condition;
        }

        /// <summary>
        /// Parses the iterators from a for-statement.
        /// </summary>
        /// <param name="forStatementProxy">Proxy object for the statement being created.</param>
        /// <param name="unsafeCode">Indicates whether the code is located within an unsafe block.</param>
        /// <param name="openParenthesis">The opening parentheis.</param>
        /// <returns>Returns the list of iterators.</returns>
        private List<Expression> GetForStatementIterators(CodeUnitProxy forStatementProxy, bool unsafeCode, BracketToken openParenthesis)
        {
            Param.AssertNotNull(forStatementProxy, "forStatementProxy");
            Param.Ignore(unsafeCode);
            Param.AssertNotNull(openParenthesis, "openParenthesis");

            // Get the iterators.
            var iterators = new List<Expression>();

            while (true)
            {
                // Check the type of the next symbol.
                Symbol symbol = this.PeekNextSymbol();

                if (symbol.SymbolType == SymbolType.CloseParenthesis)
                {
                    // This is the end of the iterator list. Add the parenthesis and break.
                    BracketToken closeParenthesis = (BracketToken)this.GetToken(forStatementProxy, TokenType.CloseParenthesis, SymbolType.CloseParenthesis);

                    openParenthesis.MatchingBracket = closeParenthesis;
                    closeParenthesis.MatchingBracket = openParenthesis;
                    break;
                }

                // Get the next iterator expression.
                Expression iterator = this.GetNextExpression(forStatementProxy, ExpressionPrecedence.None, unsafeCode);
                if (iterator == null || iterator.Children.Count == 0)
                {
                    throw new SyntaxException(this.document, symbol.LineNumber);
                }

                // Add the initializer to the list.
                iterators.Add(iterator);

                // If the next symbol is a comma, save it.
                symbol = this.PeekNextSymbol();

                if (symbol.SymbolType == SymbolType.Comma)
                {
                    this.GetToken(forStatementProxy, TokenType.Comma, SymbolType.Comma);
                }
                else if (symbol.SymbolType != SymbolType.CloseParenthesis)
                {
                    // If it's not a comma it must be a closing parenthesis.
                    throw new SyntaxException(this.document, symbol.LineNumber);
                }
            }

            return iterators;
        }

        /// <summary>
        /// Reads the next foreach-statement from the file and returns it.
        /// </summary>
        /// <param name="parentProxy">Represents the parent item.</param>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <returns>Returns the statement.</returns>
        private ForeachStatement GetForeachStatement(CodeUnitProxy parentProxy, bool unsafeCode)
        {
            Param.AssertNotNull(parentProxy, "parentProxy");
            Param.Ignore(unsafeCode);

            var statementProxy = new CodeUnitProxy(this.document);
            
            // Get the foreach keyword.
            this.GetToken(statementProxy, TokenType.Foreach, SymbolType.Foreach);

            // Get the opening parenthesis.
            BracketToken openParenthesis = (BracketToken)this.GetToken(statementProxy, TokenType.OpenParenthesis, SymbolType.OpenParenthesis);

            // Get the variable.
            VariableDeclarationExpression variable = this.GetNextExpression(
                statementProxy, ExpressionPrecedence.None, unsafeCode, true, false) as VariableDeclarationExpression;
            if (variable == null)
            {
                throw this.CreateSyntaxException();
            }

            // Get the 'in' keyword.
            this.GetToken(statementProxy, TokenType.In, SymbolType.In);

            // Get the item being iterated over.
            Expression item = this.GetNextExpression(statementProxy, ExpressionPrecedence.None, unsafeCode);
            if (item == null)
            {
                throw this.CreateSyntaxException();
            }

            // Get the closing parenthesis.
            BracketToken closeParenthesis = (BracketToken)this.GetToken(statementProxy, TokenType.CloseParenthesis, SymbolType.CloseParenthesis);

            openParenthesis.MatchingBracket = closeParenthesis;
            closeParenthesis.MatchingBracket = openParenthesis;

            // Get the embedded statement.
            Statement childStatement = this.GetNextStatement(statementProxy, unsafeCode);
            if (childStatement == null)
            {
                throw this.CreateSyntaxException();
            }

            // Create the foreach-statement.
            var statement = new ForeachStatement(statementProxy, variable, item);
            parentProxy.Children.Add(statement);

            return statement;
        }

        /// <summary>
        /// Reads the next switch-statement from the file and returns it.
        /// </summary>
        /// <param name="parentProxy">Represents the parent item.</param>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <returns>Returns the statement.</returns>
        private SwitchStatement GetSwitchStatement(CodeUnitProxy parentProxy, bool unsafeCode)
        {
            Param.AssertNotNull(parentProxy, "parentProxy");
            Param.Ignore(unsafeCode);

            var statementProxy = new CodeUnitProxy(this.document);
            
            // Move past the switch keyword.
            this.GetToken(statementProxy, TokenType.Switch, SymbolType.Switch);

            // Get the opening parenthesis.
            BracketToken openParenthesis = (BracketToken)this.GetToken(statementProxy, TokenType.OpenParenthesis, SymbolType.OpenParenthesis);

            // Get the inner expression.
            Expression expression = this.GetNextExpression(statementProxy, ExpressionPrecedence.None, unsafeCode);
            if (expression == null)
            {
                throw this.CreateSyntaxException();
            }

            // Get the closing parenthesis.
            BracketToken closeParenthesis = (BracketToken)this.GetToken(statementProxy, TokenType.CloseParenthesis, SymbolType.CloseParenthesis);

            openParenthesis.MatchingBracket = closeParenthesis;
            closeParenthesis.MatchingBracket = openParenthesis;

            // Get the opening curly bracket.
            BracketToken openingBracket = (BracketToken)this.GetToken(statementProxy, TokenType.OpenCurlyBracket, SymbolType.OpenCurlyBracket);

            // Get the case and default statements.
            SwitchDefaultStatement defaultStatement;
            List<SwitchCaseStatement> caseStatements = this.GetSwitchStatementCaseStatements(statementProxy, unsafeCode, out defaultStatement);

            // Get the closing curly bracket.
            BracketToken closingBracket = (BracketToken)this.GetToken(statementProxy, TokenType.CloseCurlyBracket, SymbolType.CloseCurlyBracket);

            openingBracket.MatchingBracket = closingBracket;
            closingBracket.MatchingBracket = openingBracket;

            // Create and return the switch-statement.
            var statement = new SwitchStatement(statementProxy, expression, caseStatements.AsReadOnly(), defaultStatement);
            parentProxy.Children.Add(statement);

            return statement;
        }

        /// <summary>
        /// Parses the case and default statements within a switch statement.
        /// </summary>
        /// <param name="switchStatementProxy">Proxy object for the statement being created.</param>
        /// <param name="unsafeCode">Indicates whether the statement lies within a block of unsafe code.</param>
        /// <param name="defaultStatement">Returns the default statement.</param>
        /// <returns>Returns the list of case statements.</returns>
        private List<SwitchCaseStatement> GetSwitchStatementCaseStatements(
            CodeUnitProxy switchStatementProxy, bool unsafeCode, out SwitchDefaultStatement defaultStatement)
        {
            Param.AssertNotNull(switchStatementProxy, "switchStatementProxy");
            Param.Ignore(unsafeCode);

            defaultStatement = null;
            var caseStatements = new List<SwitchCaseStatement>();

            // Find each of the case and default blocks.
            while (true)
            {
                // Get the next symbol and check the type.
                Symbol symbol = this.PeekNextSymbol();

                if (symbol.SymbolType == SymbolType.Case)
                {
                    caseStatements.Add(this.GetSwitchCaseStatement(switchStatementProxy, unsafeCode));
                }
                else if (symbol.SymbolType == SymbolType.Default)
                {
                    if (defaultStatement != null)
                    {
                        throw new SyntaxException(this.document, symbol.LineNumber);
                    }

                    defaultStatement = this.GetSwitchDefaultStatement(switchStatementProxy, unsafeCode);
                }
                else if (symbol.SymbolType == SymbolType.CloseCurlyBracket)
                {
                    break;
                }
                else
                {
                    // Unexpected symbol.
                    throw new SyntaxException(this.document, symbol.LineNumber);
                }
            }

            return caseStatements;
        }

        /// <summary>
        /// Reads the next case-statement from the file and returns it.
        /// </summary>
        /// <param name="parentProxy">Represents the parent item.</param>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <returns>Returns the statement.</returns>
        private SwitchCaseStatement GetSwitchCaseStatement(CodeUnitProxy parentProxy, bool unsafeCode)
        {
            Param.AssertNotNull(parentProxy, "parentProxy");
            Param.Ignore(unsafeCode);

            var statementProxy = new CodeUnitProxy(this.document);

            // Move past the case keyword.
            this.GetToken(statementProxy, TokenType.Case, SymbolType.Case);

            // Get the name.
            Symbol symbol = this.PeekNextSymbol();
            if (symbol.SymbolType != SymbolType.Other &&
                symbol.SymbolType != SymbolType.String &&
                symbol.SymbolType != SymbolType.Number &&
                symbol.SymbolType != SymbolType.Null &&
                symbol.SymbolType != SymbolType.OpenParenthesis &&
                symbol.SymbolType != SymbolType.Minus &&
                symbol.SymbolType != SymbolType.Plus &&
                symbol.SymbolType != SymbolType.True &&
                symbol.SymbolType != SymbolType.False)
            {
                throw this.CreateSyntaxException();
            }

            Expression identifier = this.GetNextExpression(statementProxy, ExpressionPrecedence.None, unsafeCode);

            // Get the colon.
            this.GetToken(statementProxy, TokenType.LabelColon, SymbolType.Colon);

            // Create the statement.
            var caseStatement = new SwitchCaseStatement(statementProxy, identifier);
            parentProxy.Children.Add(caseStatement);

            // Get each of the sub-statements beneath this statement.
            while (true)
            {
                // Check the type of the next symbol.
                symbol = this.PeekNextSymbol();

                // Check if we've reached the end of the case statement.
                if (symbol.SymbolType == SymbolType.CloseCurlyBracket ||
                    symbol.SymbolType == SymbolType.Case ||
                    symbol.SymbolType == SymbolType.Default)
                {
                    break;
                }

                // Read the next child statement.
                Statement statement = this.GetNextStatement(statementProxy, unsafeCode);
                if (statement == null)
                {
                    throw this.CreateSyntaxException();
                }
            }

            return caseStatement;
        }

        /// <summary>
        /// Reads the next default-statement from the file and returns it.
        /// </summary>
        /// <param name="parentProxy">Represents the parent item.</param>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <returns>Returns the statement.</returns>
        private SwitchDefaultStatement GetSwitchDefaultStatement(CodeUnitProxy parentProxy, bool unsafeCode)
        {
            Param.AssertNotNull(parentProxy, "parentProxy");
            Param.Ignore(unsafeCode);

            var statementProxy = new CodeUnitProxy(this.document);

            // Move past the default keyword.
            this.GetToken(statementProxy, TokenType.Default, SymbolType.Default);

            // Get the colon.
            this.GetToken(statementProxy, TokenType.LabelColon, SymbolType.Colon);

            // Create the statement.
            var defaultStatement = new SwitchDefaultStatement(statementProxy);
            parentProxy.Children.Add(defaultStatement);

            // Get each of the sub-statements beneath this statement.
            while (true)
            {
                // Check the type of the next symbol.
                Symbol symbol = this.PeekNextSymbol();

                // Check if we've reached the end of the default statement.
                if (symbol.SymbolType == SymbolType.CloseCurlyBracket ||
                    symbol.SymbolType == SymbolType.Case ||
                    symbol.SymbolType == SymbolType.Default)
                {
                    break;
                }

                // Read the next child statement.
                Statement statement = this.GetNextStatement(statementProxy, unsafeCode);
                if (statement == null)
                {
                    throw this.CreateSyntaxException();
                }
            }

            return defaultStatement;
        }

        /// <summary>
        /// Reads the next try-statement from the file and returns it.
        /// </summary>
        /// <param name="parentProxy">Represents the parent item.</param>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <returns>Returns the statement.</returns>
        private TryStatement GetTryStatement(CodeUnitProxy parentProxy, bool unsafeCode)
        {
            Param.AssertNotNull(parentProxy, "parentProxy");
            Param.Ignore(unsafeCode);

            var statementProxy = new CodeUnitProxy(this.document);
            
            // Move past the try keyword.
            this.GetToken(statementProxy, TokenType.Try, SymbolType.Try);

            // Get the embedded statement. It must be a block statement.
            BlockStatement childStatement = this.GetNextStatement(statementProxy, unsafeCode) as BlockStatement;
            if (childStatement == null)
            {
                throw this.CreateSyntaxException();
            }

            // Create the try-statement now.
            var statement = new TryStatement(statementProxy, childStatement);
            parentProxy.Children.Add(statement);

            // Get the attached catch statements, if any.
            while (true)
            {
                CatchStatement catchStatement = this.GetAttachedCatchStatement(parentProxy, statement, unsafeCode);
                if (catchStatement == null)
                {
                    break;
                }
            }

            // Get the attached finally statement, if any.
            this.GetAttachedFinallyStatement(parentProxy, statement, unsafeCode);

            // Return the statement.
            return statement;
        }

        /// <summary>
        /// Looks for a catch-statement, and if it is found, parses and returns it.
        /// </summary>
        /// <param name="parentProxy">Represents the parent item.</param>
        /// <param name="tryStatement">The parent try statement.</param>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <returns>Returns the statement.</returns>
        private CatchStatement GetAttachedCatchStatement(CodeUnitProxy parentProxy, TryStatement tryStatement, bool unsafeCode)
        {
            Param.AssertNotNull(parentProxy, "parentProxy");
            Param.AssertNotNull(tryStatement, "tryStatement");
            Param.Ignore(unsafeCode);

            CatchStatement catchStatement = null;

            // Look for a catch keyword.
            Symbol symbol = this.PeekNextSymbol();
            if (symbol.SymbolType == SymbolType.Catch)
            {
                this.AdvanceToNextCodeSymbol(parentProxy);
                var statementProxy = new CodeUnitProxy(this.document);

                // Move up to the catch keyword and add it.
                this.GetToken(statementProxy, TokenType.Catch, SymbolType.Catch);

                Expression catchExpression = null;

                // Get the opening parenthesis, if there is one.
                symbol = this.PeekNextSymbol();
                if (symbol.SymbolType == SymbolType.OpenParenthesis)
                {
                    BracketToken openParenthesis = (BracketToken)this.GetToken(statementProxy, TokenType.OpenParenthesis, SymbolType.OpenParenthesis);

                    // Get the type, if there is one.
                    symbol = this.PeekNextSymbol();
                    if (symbol.SymbolType == SymbolType.Other)
                    {
                        catchExpression = this.GetNextExpression(statementProxy, ExpressionPrecedence.None, unsafeCode, true, true);
                    }

                    // Get the closing parenthesis.
                    BracketToken closeParenthesis = (BracketToken)this.GetToken(statementProxy, TokenType.CloseParenthesis, SymbolType.CloseParenthesis);

                    openParenthesis.MatchingBracket = closeParenthesis;
                    closeParenthesis.MatchingBracket = openParenthesis;
                }

                // Get the embedded statement. This must be a block statement.
                BlockStatement childStatement = this.GetNextStatement(statementProxy, unsafeCode) as BlockStatement;
                if (childStatement == null)
                {
                    throw this.CreateSyntaxException();
                }

                // Create the catch statement.
                catchStatement = new CatchStatement(statementProxy, tryStatement, catchExpression, childStatement);
                parentProxy.Children.Add(catchStatement);
            }

            return catchStatement;
        }

        /// <summary>
        /// Looks for a finally-statement, and if it is found, parses and returns it.
        /// </summary>
        /// <param name="parentProxy">Represents the parent item.</param>
        /// <param name="tryStatement">The parent try statement.</param>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <returns>Returns the statement.</returns>
        private FinallyStatement GetAttachedFinallyStatement(CodeUnitProxy parentProxy, TryStatement tryStatement, bool unsafeCode)
        {
            Param.AssertNotNull(parentProxy, "parentProxy");
            Param.AssertNotNull(tryStatement, "tryStatement");
            Param.Ignore(unsafeCode);

            FinallyStatement finallyStatement = null;

            // Look for a finally keyword.
            Symbol symbol = this.PeekNextSymbol();
            if (symbol.SymbolType == SymbolType.Finally)
            {
                this.AdvanceToNextCodeSymbol(parentProxy);
                var statementProxy = new CodeUnitProxy(this.document);

                // Move up to the finally keyword and add it.
                this.GetToken(statementProxy, TokenType.Finally, SymbolType.Finally);

                // Get the embedded statement. This must be a block statement.
                BlockStatement childStatement = this.GetNextStatement(statementProxy, unsafeCode) as BlockStatement;
                if (childStatement == null)
                {
                    throw this.CreateSyntaxException();
                }

                // Create and return the finally statement.
                finallyStatement = new FinallyStatement(statementProxy, tryStatement, childStatement);
                parentProxy.Children.Add(finallyStatement);
            }

            return finallyStatement;
        }

        /// <summary>
        /// Reads the next lock-statement from the file and returns it.
        /// </summary>
        /// <param name="parentProxy">Represents the parent item.</param>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <returns>Returns the statement.</returns>
        private LockStatement GetLockStatement(CodeUnitProxy parentProxy, bool unsafeCode)
        {
            Param.AssertNotNull(parentProxy, "parentProxy");
            Param.Ignore(unsafeCode);

            var statementProxy = new CodeUnitProxy(this.document);
            
            // Move past the lock keyword.
            this.GetToken(statementProxy, TokenType.Lock, SymbolType.Lock);

            // Get the opening parenthesis.
            BracketToken openParenthesis = (BracketToken)this.GetToken(statementProxy, TokenType.OpenParenthesis, SymbolType.OpenParenthesis);

            // Get the expression within the parenthesis.
            Expression expression = this.GetNextExpression(statementProxy, ExpressionPrecedence.None, unsafeCode);
            if (expression == null)
            {
                throw this.CreateSyntaxException();
            }

            // Get the closing parenthesis.
            BracketToken closeParenthesis = (BracketToken)this.GetToken(statementProxy, TokenType.CloseParenthesis, SymbolType.CloseParenthesis);

            openParenthesis.MatchingBracket = closeParenthesis;
            closeParenthesis.MatchingBracket = openParenthesis;

            // Get the embedded statement.
            Statement childStatement = this.GetNextStatement(statementProxy, unsafeCode);
            if (childStatement == null)
            {
                throw this.CreateSyntaxException();
            }

            // Create the lock-statement.
            var statement = new LockStatement(statementProxy, expression);
            parentProxy.Children.Add(statement);

            return statement;
        }

        /// <summary>
        /// Reads the next using-statement from the file and returns it.
        /// </summary>
        /// <param name="parentProxy">Represents the parent item.</param>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <returns>Returns the statement.</returns>
        private UsingStatement GetUsingStatement(CodeUnitProxy parentProxy, bool unsafeCode)
        {
            Param.AssertNotNull(parentProxy, "parentProxy");
            Param.Ignore(unsafeCode);

            var statementProxy = new CodeUnitProxy(this.document);
            
            // Move past the using keyword.
            this.GetToken(statementProxy, TokenType.Using, SymbolType.Using);

            // Get the opening parenthesis.
            BracketToken openParenthesis = (BracketToken)this.GetToken(statementProxy, TokenType.OpenParenthesis, SymbolType.OpenParenthesis);

            // Get the expression within the parenthesis.
            Expression expression = this.GetNextExpression(statementProxy, ExpressionPrecedence.None, unsafeCode, true, false);
            if (expression == null)
            {
                throw this.CreateSyntaxException();
            }

            // Get the closing parenthesis.
            BracketToken closeParenthesis = (BracketToken)this.GetToken(statementProxy, TokenType.CloseParenthesis, SymbolType.CloseParenthesis);

            openParenthesis.MatchingBracket = closeParenthesis;
            closeParenthesis.MatchingBracket = openParenthesis;

            // Get the embedded statement.
            Statement childStatement = this.GetNextStatement(statementProxy, unsafeCode);
            if (childStatement == null)
            {
                throw this.CreateSyntaxException();
            }

            // Create the using-statement.
            var statement = new UsingStatement(statementProxy, expression);
            parentProxy.Children.Add(statement);

            return statement;
        }

        /// <summary>
        /// Reads the next checked-statement from the file and returns it.
        /// </summary>
        /// <param name="parentProxy">Represents the parent item.</param>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <returns>Returns the statement.</returns>
        private CheckedStatement GetCheckedStatement(CodeUnitProxy parentProxy, bool unsafeCode)
        {
            Param.AssertNotNull(parentProxy, "parentProxy");
            Param.Ignore(unsafeCode);

            var statementProxy = new CodeUnitProxy(this.document);
            
            // Move past the checked keyword.
            this.GetToken(statementProxy, TokenType.Checked, SymbolType.Checked);

            // Get the embedded statement. It must be a block statement.
            BlockStatement childStatement = this.GetNextStatement(statementProxy, unsafeCode) as BlockStatement;
            if (childStatement == null)
            {
                throw this.CreateSyntaxException();
            }

            // Create and return the checked-statement.
            var statement = new CheckedStatement(statementProxy, childStatement);
            parentProxy.Children.Add(statement);

            return statement;
        }

        /// <summary>
        /// Reads the next unchecked-statement from the file and returns it.
        /// </summary>
        /// <param name="parentProxy">Represents the parent item.</param>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <returns>Returns the statement.</returns>
        private UncheckedStatement GetUncheckedStatement(CodeUnitProxy parentProxy, bool unsafeCode)
        {
            Param.AssertNotNull(parentProxy, "parentProxy");
            Param.Ignore(unsafeCode);

            var statementProxy = new CodeUnitProxy(this.document);
            
            // Move past the unchecked keyword.
            this.GetToken(statementProxy, TokenType.Unchecked, SymbolType.Unchecked);

            // Get the embedded statement. It must be a block statement.
            BlockStatement childStatement = this.GetNextStatement(statementProxy, unsafeCode) as BlockStatement;
            if (childStatement == null)
            {
                throw this.CreateSyntaxException();
            }

            // Create and return the unchecked-statement.
            var statement = new UncheckedStatement(statementProxy, childStatement);
            parentProxy.Children.Add(statement);

            return statement;
        }

        /// <summary>
        /// Reads the next fixed-statement from the file and returns it.
        /// </summary>
        /// <param name="parentProxy">Represents the parent item.</param>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <returns>Returns the statement.</returns>
        private FixedStatement GetFixedStatement(CodeUnitProxy parentProxy, bool unsafeCode)
        {
            Param.AssertNotNull(parentProxy, "parentProxy");
            Param.Ignore(unsafeCode);

            var statementProxy = new CodeUnitProxy(this.document);
            
            // Move past the fixed keyword.
            this.GetToken(statementProxy, TokenType.Fixed, SymbolType.Fixed);

            // Make sure we're sitting on the opening parenthesis now.
            BracketToken openParenthesis = (BracketToken)this.GetToken(statementProxy, TokenType.OpenParenthesis, SymbolType.OpenParenthesis);

            // Get the expression within the parenthesis. It must be a variable declaration.
            VariableDeclarationExpression expression = this.GetNextExpression(
                statementProxy, ExpressionPrecedence.None, unsafeCode, true, false) as VariableDeclarationExpression;
            if (expression == null)
            {
                throw this.CreateSyntaxException();
            }

            // Get the closing parenthesis.
            BracketToken closeParenthesis = (BracketToken)this.GetToken(statementProxy, TokenType.CloseParenthesis, SymbolType.CloseParenthesis);

            openParenthesis.MatchingBracket = closeParenthesis;
            closeParenthesis.MatchingBracket = openParenthesis;

            // Get the embedded statement.
            Statement childStatement = this.GetNextStatement(statementProxy, unsafeCode);
            if (childStatement == null)
            {
                throw this.CreateSyntaxException();
            }

            // Create the fixed-statement.
            var statement = new FixedStatement(statementProxy, expression);
            parentProxy.Children.Add(statement);

            return statement;
        }

        /// <summary>
        /// Reads the next unsafe-statement from the file and returns it.
        /// </summary>
        /// <param name="parentProxy">Represents the parent item.</param>
        /// <returns>Returns the statement.</returns>
        private UnsafeStatement GetUnsafeStatement(CodeUnitProxy parentProxy)
        {
            Param.AssertNotNull(parentProxy, "parentProxy");

            var statementProxy = new CodeUnitProxy(this.document);
            
            // Move past the unsafe keyword.
            this.GetToken(statementProxy, TokenType.Unsafe, SymbolType.Unsafe);

            // Get the embedded statement. It must be a block statement.
            BlockStatement childStatement = this.GetNextStatement(statementProxy, true) as BlockStatement;
            if (childStatement == null)
            {
                throw this.CreateSyntaxException();
            }

            // Create and return the unsafe-statement.
            var statement = new UnsafeStatement(statementProxy, childStatement);
            parentProxy.Children.Add(statement);

            return statement;
        }

        /// <summary>
        /// Reads the next break-statement from the file and returns it.
        /// </summary>
        /// <param name="parentProxy">Represents the parent item.</param>
        /// <returns>Returns the statement.</returns>
        private BreakStatement GetBreakStatement(CodeUnitProxy parentProxy)
        {
            Param.AssertNotNull(parentProxy, "parentProxy");

            var statementProxy = new CodeUnitProxy(this.document);
            
            // Move past the break keyword.
            this.GetToken(statementProxy, TokenType.Break, SymbolType.Break);

            // Get the closing semicolon.
            this.GetToken(statementProxy, TokenType.Semicolon, SymbolType.Semicolon);

            // Create and return the break-statement.
            var statement = new BreakStatement(statementProxy);
            parentProxy.Children.Add(statement);

            return statement;
        }

        /// <summary>
        /// Reads the next continue-statement from the file and returns it.
        /// </summary>
        /// <param name="parentProxy">Represents the parent item.</param>
        /// <returns>Returns the statement.</returns>
        private ContinueStatement GetContinueStatement(CodeUnitProxy parentProxy)
        {
            Param.AssertNotNull(parentProxy, "parentProxy");

            var statementProxy = new CodeUnitProxy(this.document);
            
            // Move past the continue keyword.
            this.GetToken(statementProxy, TokenType.Continue, SymbolType.Continue);

            // Get the closing semicolon.
            this.GetToken(statementProxy, TokenType.Semicolon, SymbolType.Semicolon);

            // Create and return the continue-statement.
            var statement = new ContinueStatement(statementProxy);
            parentProxy.Children.Add(statement);

            return statement;
        }

        /// <summary>
        /// Reads the next goto-statement from the file and returns it.
        /// </summary>
        /// <param name="parentProxy">Represents the parent item.</param>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <returns>Returns the statement.</returns>
        private GotoStatement GetGotoStatement(CodeUnitProxy parentProxy, bool unsafeCode)
        {
            Param.Ignore(unsafeCode);
            Param.AssertNotNull(parentProxy, "parentProxy");

            var statementProxy = new CodeUnitProxy(this.document);
            
            // Move past the goto keyword.
            this.GetToken(statementProxy, TokenType.Goto, SymbolType.Goto);

            // Get the next symbol.
            Symbol symbol = this.PeekNextSymbol();

            Expression identifier = null;
            if (symbol.SymbolType == SymbolType.Default)
            {
                CodeUnitProxy identifierProxy = new CodeUnitProxy(this.document);
                Token token = this.GetToken(identifierProxy, TokenType.Literal, SymbolType.Default);
                identifier = new LiteralExpression(identifierProxy, token);
            }
            else if (symbol.SymbolType == SymbolType.Case)
            {
                this.GetToken(statementProxy, TokenType.Literal, SymbolType.Case);
                identifier = this.GetNextExpression(statementProxy, ExpressionPrecedence.None, unsafeCode);
            }
            else
            {
                identifier = this.GetNextExpression(statementProxy, ExpressionPrecedence.None, unsafeCode);
            }

            // Get the closing semicolon.
            this.GetToken(statementProxy, TokenType.Semicolon, SymbolType.Semicolon);

            // Create and return the goto-statement.
            var statement = new GotoStatement(statementProxy, identifier);
            parentProxy.Children.Add(statement);

            return statement;
        }

        /// <summary>
        /// Reads the next return-statement from the file and returns it.
        /// </summary>
        /// <param name="parentProxy">Represents the parent item.</param>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <returns>Returns the statement.</returns>
        private ReturnStatement GetReturnStatement(CodeUnitProxy parentProxy, bool unsafeCode)
        {
            Param.AssertNotNull(parentProxy, "parentProxy");
            Param.Ignore(unsafeCode);

            var statementProxy = new CodeUnitProxy(this.document);
            
            // Move past the return keyword.
            this.GetToken(statementProxy, TokenType.Return, SymbolType.Return);

            // Check the next symbol and see if there is an expression to return.
            Symbol symbol = this.PeekNextSymbol();

            Expression expression = null;
            if (symbol.SymbolType != SymbolType.Semicolon)
            {
                // Get the expression to return.
                expression = this.GetNextExpression(statementProxy, ExpressionPrecedence.None, unsafeCode);
                if (expression == null)
                {
                    throw this.CreateSyntaxException();
                }
            }

            this.GetToken(statementProxy, TokenType.Semicolon, SymbolType.Semicolon);

            // Create and return the statement.
            var statement = new ReturnStatement(statementProxy, expression);
            parentProxy.Children.Add(statement);

            return statement;
        }

        /// <summary>
        /// Reads the next yield-statement from the file and returns it.
        /// </summary>
        /// <param name="parentProxy">Represents the parent item.</param>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <returns>Returns the statement.</returns>
        private YieldStatement GetYieldStatement(CodeUnitProxy parentProxy, bool unsafeCode)
        {
            Param.AssertNotNull(parentProxy, "parentProxy");
            Param.Ignore(unsafeCode);

            var statementProxy = new CodeUnitProxy(this.document);
            
            // Move past the yield keyword.
            this.GetToken(statementProxy, TokenType.Yield, SymbolType.Other);

            // Get the next word, which must either be break or return.
            Symbol symbol = this.PeekNextSymbol();

            YieldStatement.Type yieldType;
            Expression returnValue = null;

            if (symbol.SymbolType == SymbolType.Return)
            {
                yieldType = YieldStatement.Type.Return;
                this.GetToken(statementProxy, TokenType.Return, SymbolType.Return);

                // Get the expression to return.
                returnValue = this.GetNextExpression(statementProxy, ExpressionPrecedence.None, unsafeCode);
                if (returnValue == null)
                {
                    throw this.CreateSyntaxException();
                }
            }
            else if (symbol.SymbolType == SymbolType.Break)
            {
                yieldType = YieldStatement.Type.Break;
                this.GetToken(statementProxy, TokenType.Break, SymbolType.Break);
            }
            else
            {
                throw this.CreateSyntaxException();
            }

            // Get the closing semicolon.
            this.GetToken(statementProxy, TokenType.Semicolon, SymbolType.Semicolon);

            // Create and return the statement.
            var statement = new YieldStatement(statementProxy, yieldType, returnValue);
            parentProxy.Children.Add(statement);

            return statement;
        }

        /// <summary>
        /// Reads the next throw-statement from the file and returns it.
        /// </summary>
        /// <param name="parentProxy">Represents the parent item.</param>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <returns>Returns the statement.</returns>
        private ThrowStatement GetThrowStatement(CodeUnitProxy parentProxy, bool unsafeCode)
        {
            Param.AssertNotNull(parentProxy, "parentProxy");
            Param.Ignore(unsafeCode);

            var statementProxy = new CodeUnitProxy(this.document);
            
            // Move past the throw keyword.
            this.GetToken(statementProxy, TokenType.Throw, SymbolType.Throw);

            // Check the type of the next symbol.
            Symbol symbol = this.PeekNextSymbol();

            Expression thrownExpression = null;

            if (symbol.SymbolType != SymbolType.Semicolon)
            {
                // Get the expression to throw.
                thrownExpression = this.GetNextExpression(statementProxy, ExpressionPrecedence.None, unsafeCode);
                if (thrownExpression == null)
                {
                    throw this.CreateSyntaxException();
                }
            }

            this.GetToken(statementProxy, TokenType.Semicolon, SymbolType.Semicolon);

            // Create and return the statement.
            var statement = new ThrowStatement(statementProxy, thrownExpression);
            parentProxy.Children.Add(statement);

            return statement;
        }

        #endregion Private Methods
    }
}
