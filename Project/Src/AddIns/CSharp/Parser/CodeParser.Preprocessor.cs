//-----------------------------------------------------------------------
// <copyright file="CodeParser.Preprocessor.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
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
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Text;
    using System.Threading;
    using System.Xml;
    using Microsoft.StyleCop;

    /// <content>
    /// Contains code for parsing preprocessor directives within a C# file.
    /// </content>
    internal partial class CodeParser
    {
        #region Internal Static Methods

        /// <summary>
        /// Extracts the body of the given preprocessor directive symbol, parses it, and returns the parsed expression.
        /// </summary>
        /// <param name="parentProxy">Represents the parent item.</param>
        /// <param name="parser">The C# parser.</param>
        /// <param name="sourceCode">The source code containing the preprocessor directive symbol.</param>
        /// <param name="preprocessorSymbol">The preprocessor directive symbol.</param>
        /// <param name="startIndex">The index of the start of the expression body within the text string.</param>
        /// <returns>Returns the expression.</returns>
        internal static Expression GetConditionalPreprocessorBodyExpression(
             CodeUnitProxy parentProxy, CsParser parser, SourceCode sourceCode, Symbol preprocessorSymbol, int startIndex)
        {
            Param.AssertNotNull(parentProxy, "parentProxy");
            Param.AssertNotNull(parser, "parser");
            Param.AssertNotNull(sourceCode, "sourceCode");
            Param.AssertNotNull(preprocessorSymbol, "preprocessorSymbol");
            Param.AssertGreaterThanOrEqualToZero(startIndex, "startIndex");
            Debug.Assert(preprocessorSymbol.SymbolType == SymbolType.PreprocessorDirective, "The symbol is not a preprocessor directive.");

            string text = preprocessorSymbol.Text.Substring(startIndex, preprocessorSymbol.Text.Length - startIndex).TrimEnd(null);
            if (text.Length > 0)
            {
                // Trim off the whitespace at the beginning and advance the start index.
                int trimIndex = 0;
                for (int i = 0; i < text.Length; ++i)
                {
                    if (char.IsWhiteSpace(text[i]))
                    {
                        ++trimIndex;
                    }
                    else
                    {
                        break;
                    }
                }

                if (trimIndex > 0)
                {
                    text = text.Substring(trimIndex, text.Length - trimIndex);
                    startIndex += trimIndex;
                }

                if (text.Length > 0)
                {
                    var reader = new StringReader(text);

                    // Extract the symbols within this text.
                    var lexer = new CodeLexer(
                        parser,
                        sourceCode,
                        new CodeReader(reader),
                        preprocessorSymbol.Location.StartPoint.Index + startIndex,
                        preprocessorSymbol.Location.StartPoint.IndexOnLine + startIndex,
                        preprocessorSymbol.Location.StartPoint.LineNumber);

                    List<Symbol> symbolList = lexer.GetSymbols(sourceCode, null);
                    var directiveSymbols = new SymbolManager(symbolList);

                    var preprocessorBodyParser = new CodeParser(parser, directiveSymbols);

                    // Parse these symbols to create the body expression.
                    return preprocessorBodyParser.GetNextConditionalPreprocessorExpression(parentProxy, sourceCode);
                }
            }

            // The directive has no body.
            return null;
        }

        #endregion Internal Static Methods

        #region Internal Methods

        /// <summary>
        /// Reads the next expression from a conditional preprocessor directive.
        /// </summary>
        /// <param name="parentProxy">Represents the parent item.</param>
        /// <param name="sourceCode">The source code.</param>
        /// <returns>Returns the expression.</returns>
        internal Expression GetNextConditionalPreprocessorExpression(CodeUnitProxy parentProxy, SourceCode sourceCode)
        {
            Param.AssertNotNull(parentProxy, "parentProxy");
            Param.AssertNotNull(sourceCode, "sourceCode");
            return this.GetNextConditionalPreprocessorExpression(parentProxy, sourceCode, ExpressionPrecedence.None);
        }

        #endregion Internal Methods

        #region Private Methods

        /// <summary>
        /// Reads the next expression from a conditional preprocessor directive.
        /// </summary>
        /// <param name="parentProxy">Represents the parent item.</param>
        /// <param name="sourceCode">The source code.</param>
        /// <param name="previousPrecedence">The precedence of the expression just before this one.</param>
        /// <returns>Returns the expression.</returns>
        private Expression GetNextConditionalPreprocessorExpression(CodeUnitProxy parentProxy, SourceCode sourceCode, ExpressionPrecedence previousPrecedence)
        {
            Param.AssertNotNull(parentProxy, "parentProxy");
            Param.AssertNotNull(sourceCode, "sourceCode");
            Param.Ignore(previousPrecedence);

            // Move past comments and whitepace.
            this.AdvanceToNextConditionalDirectiveCodeSymbol(parentProxy);

            // Saves the next expression.
            Expression expression = null;

            // Get the next symbol.
            Symbol symbol = this.symbols.Peek(1);
            if (symbol != null)
            {
                switch (symbol.SymbolType)
                {
                    case SymbolType.Other:
                        expression = this.GetConditionalPreprocessorConstantExpression(parentProxy);
                        break;

                    case SymbolType.Not:
                        expression = this.GetConditionalPreprocessorNotExpression(parentProxy, sourceCode);
                        break;

                    case SymbolType.OpenParenthesis:
                        expression = this.GetConditionalPreprocessorParenthesizedExpression(parentProxy, sourceCode);
                        break;
                            
                    case SymbolType.False:
                        expression = this.CreateLiteralExpression(parentProxy, symbol.SymbolType, TokenType.False);
                        break;

                    case SymbolType.True:
                        expression = this.CreateLiteralExpression(parentProxy, symbol.SymbolType, TokenType.True);
                        break;

                    default:
                        throw new SyntaxException(sourceCode, symbol.LineNumber);
                }
            }

            // Gather up all extensions to this expression.
            while (expression != null)
            {
                // Check if there is an extension to this expression.
                Expression extension = this.GetConditionalPreprocessorExpressionExtension(null, sourceCode, expression, previousPrecedence);
                if (extension != null)
                {
                    // The larger expression is what we want to return here.
                    expression = extension;
                }
                else
                {
                    // There are no more extensions.
                    break;
                }
            }

            // Return the expression.
            return expression;
        }

        /// <summary>
        /// Creates a new token and adds it to a new literal expression.
        /// </summary>
        /// <param name="parentProxy">Represents the parent item.</param>
        /// <param name="symbolType">The type of the symbol.</param>
        /// <param name="tokenType">The type of the token.</param>
        /// <returns>Returns the literal expression.</returns>
        private LiteralExpression CreateLiteralExpression(CodeUnitProxy parentProxy, SymbolType symbolType, TokenType tokenType)
        {
            Param.AssertNotNull(parentProxy, "parentProxy");
            Param.Ignore(symbolType, tokenType);

            this.AdvanceToNextCodeSymbol(parentProxy);
            var expressionProxy = new CodeUnitProxy();

            Token token = this.GetToken(expressionProxy, tokenType, symbolType);

            var expression = new LiteralExpression(expressionProxy, token);
            parentProxy.Children.Add(expression);

            return expression;
        }

        /// <summary>
        /// Given an expression, reads further to see if it is actually a sub-expression within a larger expression.
        /// </summary>
        /// <param name="parentProxy">Represents the parent item.</param>
        /// <param name="sourceCode">The source code.</param>
        /// <param name="leftSide">The known expression which might have an extension.</param>
        /// <param name="previousPrecedence">The precedence of the expression just before this one.</param>
        /// <returns>Returns the expression.</returns>
        private Expression GetConditionalPreprocessorExpressionExtension(CodeUnitProxy parentProxy, SourceCode sourceCode, Expression leftSide, ExpressionPrecedence previousPrecedence)
        {
            Param.Ignore(parentProxy);
            Param.AssertNotNull(sourceCode, "sourceCode");
            Param.AssertNotNull(leftSide, "leftSide");
            Param.Ignore(previousPrecedence);

            // The expression to return.
            Expression expression = null;

            // Move past whitespace.
            this.AdvanceToNextConditionalDirectiveCodeSymbol(parentProxy);

            Symbol symbol = this.symbols.Peek(1);
            if (symbol != null)
            {
                // Check the type of the next symbol.
                if (symbol.SymbolType != SymbolType.CloseParenthesis)
                {
                    // Check whether this is an operator symbol.
                    OperatorType type;
                    OperatorCategory category;
                    if (GetOperatorType(symbol, out type, out category))
                    {
                        switch (type)
                        {
                            case OperatorType.ConditionalEquals:
                            case OperatorType.NotEquals:
                                expression = this.GetConditionalPreprocessorEqualityExpression(parentProxy, sourceCode, leftSide, previousPrecedence);
                                break;

                            case OperatorType.ConditionalAnd:
                            case OperatorType.ConditionalOr:
                                expression = this.GetConditionalPreprocessorAndOrExpression(parentProxy, sourceCode, leftSide, previousPrecedence);
                                break;
                        }
                    }
                }
            }

            return expression;
        }

        /// <summary>
        /// Advances past any whitespace and comments in the code.
        /// </summary>
        /// <param name="parentProxy">Proxy object for the parent item.</param>
        private void AdvanceToNextConditionalDirectiveCodeSymbol(CodeUnitProxy parentProxy)
        {
            Param.Ignore(parentProxy);

            Symbol symbol = this.symbols.Peek(1);
            while (symbol != null)
            {
                if (symbol.SymbolType == SymbolType.WhiteSpace)
                {
                    parentProxy.Children.Add(new Whitespace(symbol.Text, symbol.Location, this.symbols.Generated));
                    this.symbols.Advance();
                }
                else if (symbol.SymbolType == SymbolType.EndOfLine)
                {
                    parentProxy.Children.Add(new EndOfLine(symbol.Text, symbol.Location, this.symbols.Generated));
                    this.symbols.Advance();
                }
                else if (symbol.SymbolType == SymbolType.SingleLineComment)
                {
                    parentProxy.Children.Add(new SingleLineComment(symbol.Text, symbol.Location, this.symbols.Generated));
                    this.symbols.Advance();
                }
                else if (symbol.SymbolType == SymbolType.MultiLineComment)
                {
                    parentProxy.Children.Add(new MultilineComment(symbol.Text, symbol.Location, this.symbols.Generated));
                    this.symbols.Advance();
                }
                else
                {
                    break;
                }

                symbol = this.symbols.Peek(1);
            }
        }

        /// <summary>
        /// Reads an expression starting with an unknown word.
        /// </summary>
        /// <param name="parentProxy">Proxy object for the parent item.</param>
        /// <returns>Returns the expression.</returns>
        private LiteralExpression GetConditionalPreprocessorConstantExpression(CodeUnitProxy parentProxy)
        {
            Param.AssertNotNull(parentProxy, "parentProxy");

            this.AdvanceToNextConditionalDirectiveCodeSymbol(parentProxy);
            var expressionProxy = new CodeUnitProxy();

            // Get the first symbol.
            Symbol symbol = this.symbols.Peek(1);
            Debug.Assert(symbol != null && symbol.SymbolType == SymbolType.Other, "Expected a text symbol");

            // Convert the symbol to a token.
            this.symbols.Advance();

            var literalToken = new LiteralToken(symbol.Text, symbol.Location, this.symbols.Generated);
            expressionProxy.Children.Add(literalToken);

            // Create a literal expression from this token.
            var literalExpression = new LiteralExpression(expressionProxy, literalToken);
            parentProxy.Children.Add(literalExpression);

            return literalExpression;
        }

        /// <summary>
        /// Reads a NOT expression.
        /// </summary>
        /// <param name="parentProxy">Represents the parent item.</param>
        /// <param name="sourceCode">The source code containing the expression.</param>
        /// <returns>Returns the expression.</returns>
        private UnaryExpression GetConditionalPreprocessorNotExpression(CodeUnitProxy parentProxy, SourceCode sourceCode)
        {
            Param.AssertNotNull(parentProxy, "parentProxy");
            Param.AssertNotNull(sourceCode, "sourceCode");

            this.AdvanceToNextConditionalDirectiveCodeSymbol(parentProxy);
            var expressionProxy = new CodeUnitProxy();

            Symbol symbol = this.symbols.Peek(1);
            Debug.Assert(symbol != null, "The next symbol should not be null");

            // Create the token based on the type of the symbol.
            var token = new NotOperator(symbol.Text, symbol.Location, this.symbols.Generated);
            expressionProxy.Children.Add(token);

            // Advance up to the symbol and add it to the document.
            this.symbols.Advance();

            // Get the expression after the operator.
            Expression expression = this.GetNextConditionalPreprocessorExpression(expressionProxy, sourceCode, ExpressionPrecedence.Unary);
            if (expression == null || expression.Children.Count == 0)
            {
                throw new SyntaxException(sourceCode, symbol.LineNumber);
            }

            // Create and return the expression.
            var unaryExpression = new UnaryExpression(expressionProxy, UnaryExpression.Operator.Not, expression);
            parentProxy.Children.Add(unaryExpression);

            return unaryExpression;
        }

        /// <summary>
        /// Reads an expression wrapped in parenthesis.
        /// </summary>
        /// <param name="parentProxy">Represents the parent item.</param>
        /// <param name="sourceCode">The source code containing the expression.</param>
        /// <returns>Returns the expression.</returns>
        private ParenthesizedExpression GetConditionalPreprocessorParenthesizedExpression(CodeUnitProxy parentProxy, SourceCode sourceCode)
        {
            Param.AssertNotNull(parentProxy, "parentProxy");
            Param.AssertNotNull(sourceCode, "sourceCode");

            this.AdvanceToNextConditionalDirectiveCodeSymbol(parentProxy);
            var expressionProxy = new CodeUnitProxy();

            // Get the opening parenthesis.
            Symbol firstSymbol = this.symbols.Peek(1);
            if (firstSymbol == null || firstSymbol.SymbolType != SymbolType.OpenParenthesis)
            {
                throw new SyntaxException(sourceCode, firstSymbol.LineNumber);
            }

            this.symbols.Advance();
            var openParenthesis = new OpenParenthesisToken(firstSymbol.Text, firstSymbol.Location, this.symbols.Generated);
            expressionProxy.Children.Add(openParenthesis);

            // Get the inner expression.
            Expression expression = this.GetNextConditionalPreprocessorExpression(expressionProxy, sourceCode, ExpressionPrecedence.None);
            if (expression == null)
            {
                throw new SyntaxException(sourceCode, firstSymbol.LineNumber);
            }

            // Get the closing parenthesis.
            this.AdvanceToNextConditionalDirectiveCodeSymbol(expressionProxy);
            Symbol symbol = this.symbols.Peek(1);
            if (symbol == null || symbol.SymbolType != SymbolType.CloseParenthesis)
            {
                throw new SyntaxException(sourceCode, firstSymbol.LineNumber);
            }

            this.symbols.Advance();
            var closeParenthesis = new CloseParenthesisToken(symbol.Text, symbol.Location, this.symbols.Generated);
            expressionProxy.Children.Add(closeParenthesis);

            openParenthesis.MatchingBracket = closeParenthesis;
            closeParenthesis.MatchingBracket = openParenthesis;

            // Create and return the expression.
            var parenthesizedExpression = new ParenthesizedExpression(expressionProxy, expression);
            parentProxy.Children.Add(parenthesizedExpression);

            return parenthesizedExpression;
        }

        /// <summary>
        /// Reads a relational expression.
        /// </summary>
        /// <param name="parentProxy">Represents the parent item.</param>
        /// <param name="sourceCode">The file containing the expression.</param>
        /// <param name="leftHandSide">The expression on the left hand side of the operator.</param>
        /// <param name="previousPrecedence">The precedence of the previous expression.</param>
        /// <returns>Returns the expression.</returns>
        private RelationalExpression GetConditionalPreprocessorEqualityExpression(
            CodeUnitProxy parentProxy, SourceCode sourceCode, Expression leftHandSide, ExpressionPrecedence previousPrecedence)
        {
            Param.AssertNotNull(parentProxy, "parentProxy");
            Param.AssertNotNull(sourceCode, "sourceCode");
            Param.AssertNotNull(leftHandSide, "leftHandSide");
            Param.Ignore(previousPrecedence);

            RelationalExpression expression = null;

            this.AdvanceToNextConditionalDirectiveCodeSymbol(parentProxy);
            var expressionProxy = new CodeUnitProxy();

            // Create the operator symbol.
            OperatorSymbolToken operatorToken = this.PeekOperatorSymbolToken();

            // Check the precedence of the operators to make sure we can gather this statement now.
            ExpressionPrecedence precedence = GetOperatorPrecedence(operatorToken.SymbolType);
            if (CheckPrecedence(previousPrecedence, precedence))
            {
                // Add the operator token to the document and advance the symbol manager up to it.
                this.symbols.Advance();
                expressionProxy.Children.Add(operatorToken);

                // Get the expression on the right-hand side of the operator.
                Expression rightHandSide = this.GetNextConditionalPreprocessorExpression(expressionProxy, sourceCode, precedence);
                if (rightHandSide == null)
                {
                    throw new SyntaxException(sourceCode, operatorToken.LineNumber);
                }

                // Get the expression operator type.
                RelationalExpression.Operator relationalType;
                switch (operatorToken.SymbolType)
                {
                    case OperatorType.ConditionalEquals:
                        relationalType = RelationalExpression.Operator.EqualTo;
                        break;

                    case OperatorType.NotEquals:
                        relationalType = RelationalExpression.Operator.NotEqualTo;
                        break;

                    default:
                        throw new SyntaxException(sourceCode, operatorToken.LineNumber);
                }

                // Create and return the expression.
                expression = new RelationalExpression(expressionProxy, relationalType, leftHandSide, rightHandSide);
                parentProxy.Children.Add(expression);
            }

            return expression;
        }

        /// <summary>
        /// Reads a conditional logical expression.
        /// </summary>
        /// <param name="parentProxy">Represents the parent item.</param>
        /// <param name="sourceCode">The source code containing the expression.</param>
        /// <param name="leftHandSide">The expression on the left hand side of the operator.</param>
        /// <param name="previousPrecedence">The precedence of the expression just before this one.</param>
        /// <returns>Returns the expression.</returns>
        private ConditionalLogicalExpression GetConditionalPreprocessorAndOrExpression(
            CodeUnitProxy parentProxy,  SourceCode sourceCode, Expression leftHandSide, ExpressionPrecedence previousPrecedence)
        {
            Param.AssertNotNull(parentProxy, "parentProxy");
            Param.AssertNotNull(sourceCode, "sourceCode");
            Param.AssertNotNull(leftHandSide, "leftHandSide");
            Param.Ignore(previousPrecedence);

            ConditionalLogicalExpression expression = null;

            this.AdvanceToNextConditionalDirectiveCodeSymbol(parentProxy);
            var expressionProxy = new CodeUnitProxy();

            // Create the operator symbol.
            OperatorSymbolToken operatorToken = this.PeekOperatorSymbolToken();

            // Check the precedence of the operators to make sure we can gather this statement now.
            ExpressionPrecedence precedence = GetOperatorPrecedence(operatorToken.SymbolType);
            if (CheckPrecedence(previousPrecedence, precedence))
            {
                // Add the operator token to the document and advance the symbol manager up to it.
                this.symbols.Advance();
                expressionProxy.Children.Add(operatorToken);

                // Get the expression on the right-hand side of the operator.
                Expression rightHandSide = this.GetNextConditionalPreprocessorExpression(expressionProxy, sourceCode, precedence);
                if (rightHandSide == null)
                {
                    throw new SyntaxException(sourceCode, operatorToken.LineNumber);
                }

                // Get the expression operator type.
                ConditionalLogicalExpression.Operator conditionalType;
                switch (operatorToken.SymbolType)
                {
                    case OperatorType.ConditionalAnd:
                        conditionalType = ConditionalLogicalExpression.Operator.And;
                        break;

                    case OperatorType.ConditionalOr:
                        conditionalType = ConditionalLogicalExpression.Operator.Or;
                        break;

                    default:
                        throw new SyntaxException(sourceCode, operatorToken.LineNumber);
                }

                // Create and return the expression.
                expression = new ConditionalLogicalExpression(expressionProxy, conditionalType, leftHandSide, rightHandSide);
                parentProxy.Children.Add(expression);
            }

            return expression;
        }

        #endregion Private Methods
    }
}
