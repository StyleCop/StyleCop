// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CodeParser.Preprocessor.cs" company="https://github.com/StyleCop">
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
    using System.Diagnostics;
    using System.IO;

    /// <summary>
    /// The code parser.
    /// </summary>
    /// <content>
    /// Contains code for parsing preprocessor directives within a C# file.
    /// </content>
    internal partial class CodeParser
    {
        #region Methods

        /// <summary>
        /// Extracts the body of the given preprocessor directive symbol, parses it, and returns the parsed expression.
        /// </summary>
        /// <param name="parser">
        /// The C# parser.
        /// </param>
        /// <param name="sourceCode">
        /// The source code containing the preprocessor directive symbol.
        /// </param>
        /// <param name="preprocessorSymbol">
        /// The preprocessor directive symbol.
        /// </param>
        /// <param name="startIndex">
        /// The index of the start of the expression body within the text string.
        /// </param>
        /// <returns>
        /// Returns the expression.
        /// </returns>
        internal static Expression GetConditionalPreprocessorBodyExpression(CsParser parser, SourceCode sourceCode, Symbol preprocessorSymbol, int startIndex)
        {
            Param.AssertNotNull(parser, "parser");
            Param.AssertNotNull(sourceCode, "sourceCode");
            Param.AssertNotNull(preprocessorSymbol, "preprocessorSymbol");
            Param.AssertGreaterThanOrEqualToZero(startIndex, "startIndex");
            Debug.Assert(preprocessorSymbol.SymbolType == SymbolType.PreprocessorDirective, "The symbol is not a preprocessor directive.");

            string text = preprocessorSymbol.Text.Substring(startIndex, preprocessorSymbol.Text.Length - startIndex).Trim();
            if (text.Length > 0)
            {
                using (StringReader reader = new StringReader(text))
                {
                    // Extract the symbols within this text.
                    CodeLexer lexer = new CodeLexer(parser, sourceCode, new CodeReader(reader));
                    List<Symbol> symbolList = lexer.GetSymbols(sourceCode, null);
                    SymbolManager directiveSymbols = new SymbolManager(symbolList);

                    CodeParser preprocessorBodyParser = new CodeParser(parser, directiveSymbols);

                    // Parse these symbols to create the body expression.
                    return preprocessorBodyParser.GetNextConditionalPreprocessorExpression(sourceCode);
                }
            }

            // The directive has no body.
            return null;
        }

        /// <summary>
        /// Reads the next expression from a conditional preprocessor directive.
        /// </summary>
        /// <param name="sourceCode">
        /// The source code.
        /// </param>
        /// <returns>
        /// Returns the expression.
        /// </returns>
        internal Expression GetNextConditionalPreprocessorExpression(SourceCode sourceCode)
        {
            Param.AssertNotNull(sourceCode, "sourceCode");
            return this.GetNextConditionalPreprocessorExpression(sourceCode, ExpressionPrecedence.None);
        }

        /// <summary>
        /// Advances past any whitespace and comments in the code.
        /// </summary>
        /// <param name="parentReference">
        /// The parent code part.
        /// </param>
        private void AdvanceToNextConditionalDirectiveCodeSymbol(Reference<ICodePart> parentReference)
        {
            Param.AssertNotNull(parentReference, "parentReference");

            Symbol symbol = this.symbols.Peek(1);
            while (symbol != null)
            {
                if (symbol.SymbolType == SymbolType.WhiteSpace)
                {
                    this.tokens.Add(new Whitespace(symbol.Text, symbol.Location, parentReference, this.symbols.Generated));
                    this.symbols.Advance();
                }
                else if (symbol.SymbolType == SymbolType.EndOfLine)
                {
                    this.tokens.Add(new CsToken(symbol.Text, CsTokenType.EndOfLine, symbol.Location, parentReference, this.symbols.Generated));
                    this.symbols.Advance();
                }
                else if (symbol.SymbolType == SymbolType.SingleLineComment)
                {
                    this.tokens.Add(new CsToken(symbol.Text, CsTokenType.SingleLineComment, symbol.Location, parentReference, this.symbols.Generated));
                    this.symbols.Advance();
                }
                else if (symbol.SymbolType == SymbolType.MultiLineComment)
                {
                    this.tokens.Add(new CsToken(symbol.Text, CsTokenType.MultiLineComment, symbol.Location, parentReference, this.symbols.Generated));
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
        /// Reads a conditional logical expression.
        /// </summary>
        /// <param name="sourceCode">
        /// The source code containing the expression.
        /// </param>
        /// <param name="parentReference">
        /// The parent code unit.
        /// </param>
        /// <param name="leftHandSide">
        /// The expression on the left hand side of the operator.
        /// </param>
        /// <param name="previousPrecedence">
        /// The precedence of the expression just before this one.
        /// </param>
        /// <returns>
        /// Returns the expression.
        /// </returns>
        private ConditionalLogicalExpression GetConditionalPreprocessorAndOrExpression(
            SourceCode sourceCode, Reference<ICodePart> parentReference, Expression leftHandSide, ExpressionPrecedence previousPrecedence)
        {
            Param.AssertNotNull(sourceCode, "sourceCode");
            Param.AssertNotNull(parentReference, "parentReference");
            Param.AssertNotNull(leftHandSide, "leftHandSide");
            Param.Ignore(previousPrecedence);

            ConditionalLogicalExpression expression = null;

            this.AdvanceToNextConditionalDirectiveCodeSymbol(parentReference);
            Symbol firstSymbol = this.symbols.Peek(1);
            if (firstSymbol == null)
            {
                throw new SyntaxException(sourceCode, firstSymbol.LineNumber);
            }

            Reference<ICodePart> expressionReference = new Reference<ICodePart>();

            // Create the operator symbol.
            OperatorType type;
            OperatorCategory category;
            GetOperatorType(firstSymbol, out type, out category);
            OperatorSymbol operatorToken = new OperatorSymbol(firstSymbol.Text, category, type, firstSymbol.Location, expressionReference, this.symbols.Generated);

            // Check the precedence of the operators to make sure we can gather this statement now.
            ExpressionPrecedence precedence = GetOperatorPrecedence(operatorToken.SymbolType);
            if (CheckPrecedence(previousPrecedence, precedence))
            {
                // Add the operator token to the document and advance the symbol manager up to it.
                this.symbols.Advance();
                this.tokens.Add(operatorToken);

                // Get the expression on the right-hand side of the operator.
                Expression rightHandSide = this.GetNextConditionalPreprocessorExpression(sourceCode, precedence);
                if (rightHandSide == null)
                {
                    throw new SyntaxException(sourceCode, operatorToken.LineNumber);
                }

                // Create the partial token list for the expression.
                CsTokenList partialTokens = new CsTokenList(this.tokens, leftHandSide.Tokens.First, this.tokens.Last);

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
                expression = new ConditionalLogicalExpression(partialTokens, conditionalType, leftHandSide, rightHandSide);
            }

            return expression;
        }

        /// <summary>
        /// Reads an expression starting with an unknown word.
        /// </summary>
        /// <returns>Returns the expression.</returns>
        private LiteralExpression GetConditionalPreprocessorConstantExpression()
        {
            // Get the first symbol.
            Symbol symbol = this.symbols.Peek(1);
            Debug.Assert(symbol != null && symbol.SymbolType == SymbolType.Other, "Expected a text symbol");

            Reference<ICodePart> expressionReference = new Reference<ICodePart>();

            // Convert the symbol to a token.
            this.symbols.Advance();
            CsToken literalToken = new CsToken(symbol.Text, CsTokenType.Other, symbol.Location, expressionReference, this.symbols.Generated);
            Node<CsToken> literalTokenNode = this.tokens.InsertLast(literalToken);

            // Create a literal expression from this token.
            LiteralExpression expression = new LiteralExpression(this.tokens, literalTokenNode);
            expressionReference.Target = expression;

            return expression;
        }

        /// <summary>
        /// Reads a relational expression.
        /// </summary>
        /// <param name="sourceCode">
        /// The file containing the expression.
        /// </param>
        /// <param name="parentReference">
        /// The parent code unit.
        /// </param>
        /// <param name="leftHandSide">
        /// The expression on the left hand side of the operator.
        /// </param>
        /// <param name="previousPrecedence">
        /// The precedence of the expression just before this one.
        /// </param>
        /// <returns>
        /// Returns the expression.
        /// </returns>
        private RelationalExpression GetConditionalPreprocessorEqualityExpression(
            SourceCode sourceCode, Reference<ICodePart> parentReference, Expression leftHandSide, ExpressionPrecedence previousPrecedence)
        {
            Param.AssertNotNull(sourceCode, "sourceCode");
            Param.AssertNotNull(parentReference, "parentReference");
            Param.AssertNotNull(leftHandSide, "leftHandSide");
            Param.Ignore(previousPrecedence);

            RelationalExpression expression = null;

            this.AdvanceToNextConditionalDirectiveCodeSymbol(parentReference);
            Symbol firstSymbol = this.symbols.Peek(1);
            if (firstSymbol == null)
            {
                throw new SyntaxException(sourceCode, firstSymbol.LineNumber);
            }

            Reference<ICodePart> expressionReference = new Reference<ICodePart>();

            // Create the operator symbol.
            OperatorType type;
            OperatorCategory category;
            GetOperatorType(firstSymbol, out type, out category);
            OperatorSymbol operatorToken = new OperatorSymbol(firstSymbol.Text, category, type, firstSymbol.Location, expressionReference, this.symbols.Generated);

            // Check the precedence of the operators to make sure we can gather this statement now.
            ExpressionPrecedence precedence = GetOperatorPrecedence(operatorToken.SymbolType);
            if (CheckPrecedence(previousPrecedence, precedence))
            {
                // Add the operator token to the document and advance the symbol manager up to it.
                this.symbols.Advance();
                this.tokens.Add(operatorToken);

                // Get the expression on the right-hand side of the operator.
                Expression rightHandSide = this.GetNextConditionalPreprocessorExpression(sourceCode, precedence);
                if (rightHandSide == null)
                {
                    throw new SyntaxException(sourceCode, operatorToken.LineNumber);
                }

                // Create the partial token list for the expression.
                CsTokenList partialTokens = new CsTokenList(this.tokens, leftHandSide.Tokens.First, this.tokens.Last);

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
                expression = new RelationalExpression(partialTokens, relationalType, leftHandSide, rightHandSide);
                expressionReference.Target = expression;
            }

            return expression;
        }

        /// <summary>
        /// Given an expression, reads further to see if it is actually a sub-expression within a larger expression.
        /// </summary>
        /// <param name="sourceCode">
        /// The source code.
        /// </param>
        /// <param name="parentReference">
        /// The parent code part.
        /// </param>
        /// <param name="leftSide">
        /// The known expression which might have an extension.
        /// </param>
        /// <param name="previousPrecedence">
        /// The precedence of the expression just before this one.
        /// </param>
        /// <returns>
        /// Returns the expression.
        /// </returns>
        private Expression GetConditionalPreprocessorExpressionExtension(
            SourceCode sourceCode, Reference<ICodePart> parentReference, Expression leftSide, ExpressionPrecedence previousPrecedence)
        {
            Param.AssertNotNull(sourceCode, "sourceCode");
            Param.AssertNotNull(parentReference, "parentReference");
            Param.AssertNotNull(leftSide, "leftSide");
            Param.Ignore(previousPrecedence);

            // The expression to return.
            Expression expression = null;

            // Move past whitespace.
            this.AdvanceToNextConditionalDirectiveCodeSymbol(parentReference);

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
                                expression = this.GetConditionalPreprocessorEqualityExpression(sourceCode, parentReference, leftSide, previousPrecedence);
                                break;

                            case OperatorType.ConditionalAnd:
                            case OperatorType.ConditionalOr:
                                expression = this.GetConditionalPreprocessorAndOrExpression(sourceCode, parentReference, leftSide, previousPrecedence);
                                break;
                        }
                    }
                }
            }

            return expression;
        }

        /// <summary>
        /// Reads a NOT expression.
        /// </summary>
        /// <param name="sourceCode">
        /// The source code containing the expression.
        /// </param>
        /// <param name="parentReference">
        /// The parent code part.
        /// </param>
        /// <returns>
        /// Returns the expression.
        /// </returns>
        private UnaryExpression GetConditionalPreprocessorNotExpression(SourceCode sourceCode, Reference<ICodePart> parentReference)
        {
            Param.AssertNotNull(sourceCode, "sourceCode");
            Param.AssertNotNull(parentReference, "parentReference");

            Reference<ICodePart> expressionReference = new Reference<ICodePart>();

            // Get the symbol.
            this.AdvanceToNextConditionalDirectiveCodeSymbol(parentReference);
            Symbol symbol = this.symbols.Peek(1);
            Debug.Assert(symbol != null, "The next symbol should not be null");

            // Create the token based on the type of the symbol.
            OperatorSymbol token = new OperatorSymbol(symbol.Text, OperatorCategory.Unary, OperatorType.Not, symbol.Location, expressionReference, this.symbols.Generated);

            Node<CsToken> tokenNode = this.tokens.InsertLast(token);

            // Advance up to the symbol and add it to the document.
            this.symbols.Advance();

            // Get the expression after the operator.
            Expression innerExpression = this.GetNextConditionalPreprocessorExpression(sourceCode, ExpressionPrecedence.Unary);
            if (innerExpression == null || innerExpression.Tokens.First == null)
            {
                throw new SyntaxException(sourceCode, symbol.LineNumber);
            }

            // Create the partial token list for the expression.
            CsTokenList partialTokens = new CsTokenList(this.tokens, tokenNode, this.tokens.Last);

            // Create and return the expression.
            UnaryExpression expression = new UnaryExpression(partialTokens, UnaryExpression.Operator.Not, innerExpression);
            expressionReference.Target = expression;

            return expression;
        }

        /// <summary>
        /// Reads an expression wrapped in parenthesis.
        /// </summary>
        /// <param name="sourceCode">
        /// The source code containing the expression.
        /// </param>
        /// <param name="parentReference">
        /// The parent code part.
        /// </param>
        /// <returns>
        /// Returns the expression.
        /// </returns>
        private ParenthesizedExpression GetConditionalPreprocessorParenthesizedExpression(SourceCode sourceCode, Reference<ICodePart> parentReference)
        {
            Param.AssertNotNull(sourceCode, "sourceCode");
            Param.AssertNotNull(parentReference, "parentReference");

            // Get the opening parenthesis.
            this.AdvanceToNextConditionalDirectiveCodeSymbol(parentReference);
            Symbol firstSymbol = this.symbols.Peek(1);
            if (firstSymbol == null || firstSymbol.SymbolType != SymbolType.OpenParenthesis)
            {
                throw new SyntaxException(sourceCode, firstSymbol.LineNumber);
            }

            Reference<ICodePart> expressionReference = new Reference<ICodePart>();

            this.symbols.Advance();
            Bracket openParenthesis = new Bracket(firstSymbol.Text, CsTokenType.OpenParenthesis, firstSymbol.Location, expressionReference, this.symbols.Generated);

            Node<CsToken> openParenthesisNode = this.tokens.InsertLast(openParenthesis);

            // Get the inner expression.
            Expression innerExpression = this.GetNextConditionalPreprocessorExpression(sourceCode, ExpressionPrecedence.None);
            if (innerExpression == null)
            {
                throw new SyntaxException(sourceCode, firstSymbol.LineNumber);
            }

            // Get the closing parenthesis.
            this.AdvanceToNextConditionalDirectiveCodeSymbol(expressionReference);
            Symbol symbol = this.symbols.Peek(1);
            if (symbol == null || symbol.SymbolType != SymbolType.CloseParenthesis)
            {
                throw new SyntaxException(sourceCode, firstSymbol.LineNumber);
            }

            this.symbols.Advance();
            Bracket closeParenthesis = new Bracket(symbol.Text, CsTokenType.CloseParenthesis, symbol.Location, expressionReference, this.symbols.Generated);
            Node<CsToken> closeParenthesisNode = this.tokens.InsertLast(closeParenthesis);

            openParenthesis.MatchingBracketNode = closeParenthesisNode;
            closeParenthesis.MatchingBracketNode = openParenthesisNode;

            // Create the token list for the expression.
            CsTokenList partialTokens = new CsTokenList(this.tokens, openParenthesisNode, this.tokens.Last);

            // Create and return the expression.
            ParenthesizedExpression expression = new ParenthesizedExpression(partialTokens, innerExpression);
            expressionReference.Target = expression;

            return expression;
        }

        /// <summary>
        /// Reads the next expression from a conditional preprocessor directive.
        /// </summary>
        /// <param name="sourceCode">
        /// The source code.
        /// </param>
        /// <param name="previousPrecedence">
        /// The precedence of the expression just before this one.
        /// </param>
        /// <returns>
        /// Returns the expression.
        /// </returns>
        private Expression GetNextConditionalPreprocessorExpression(SourceCode sourceCode, ExpressionPrecedence previousPrecedence)
        {
            Param.AssertNotNull(sourceCode, "sourceCode");
            Param.Ignore(previousPrecedence);

            Reference<ICodePart> parentReference = new Reference<ICodePart>();

            // Move past comments and whitepace.
            this.AdvanceToNextConditionalDirectiveCodeSymbol(parentReference);

            // Saves the next expression.
            Expression expression = null;

            // Get the next symbol.
            Symbol symbol = this.symbols.Peek(1);
            if (symbol != null)
            {
                switch (symbol.SymbolType)
                {
                    case SymbolType.Other:
                        expression = this.GetConditionalPreprocessorConstantExpression();
                        break;

                    case SymbolType.Not:
                        expression = this.GetConditionalPreprocessorNotExpression(sourceCode, parentReference);
                        break;

                    case SymbolType.OpenParenthesis:
                        expression = this.GetConditionalPreprocessorParenthesizedExpression(sourceCode, parentReference);
                        break;

                    case SymbolType.False:
                        this.symbols.Advance();

                        Reference<ICodePart> falseExpressionReference = new Reference<ICodePart>();
                        CsToken token = new CsToken(symbol.Text, CsTokenType.False, symbol.Location, falseExpressionReference, this.symbols.Generated);
                        Node<CsToken> tokenNode = this.tokens.InsertLast(token);
                        expression = new LiteralExpression(new CsTokenList(this.tokens, tokenNode, tokenNode), tokenNode);
                        falseExpressionReference.Target = expression;
                        break;

                    case SymbolType.True:
                        this.symbols.Advance();

                        Reference<ICodePart> trueExpressionReference = new Reference<ICodePart>();
                        token = new CsToken(symbol.Text, CsTokenType.True, symbol.Location, trueExpressionReference, this.symbols.Generated);
                        tokenNode = this.tokens.InsertLast(token);
                        expression = new LiteralExpression(new CsTokenList(this.tokens, tokenNode, tokenNode), tokenNode);
                        trueExpressionReference.Target = expression;
                        break;

                    default:
                        throw new SyntaxException(sourceCode, symbol.LineNumber);
                }
            }

            // Gather up all extensions to this expression.
            while (expression != null)
            {
                Reference<ICodePart> expressionReference = new Reference<ICodePart>(expression);

                // Check if there is an extension to this expression.
                Expression extension = this.GetConditionalPreprocessorExpressionExtension(sourceCode, expressionReference, expression, previousPrecedence);
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

        #endregion
    }
}