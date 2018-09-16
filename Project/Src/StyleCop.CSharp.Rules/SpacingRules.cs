// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SpacingRules.cs" company="https://github.com/StyleCop">
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
//   Tracks spacing in a piece of code.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    using System;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Tracks spacing in a piece of code.
    /// </summary>
    [SourceAnalyzer(typeof(CsParser))]
    public class SpacingRules : SourceAnalyzer
    {
        #region Public Methods and Operators

        /// <summary>
        /// Checks the spacing of items within the given document.
        /// </summary>
        /// <param name="document">
        /// The document to check.
        /// </param>
        public override void AnalyzeDocument(CodeDocument document)
        {
            Param.RequireNotNull(document, "document");

            CsDocument csdocument = (CsDocument)document;

            if (csdocument.RootElement != null && !csdocument.RootElement.Generated)
            {
                this.CheckSpacing(csdocument.Tokens, false, null);
            }
        }

        /// <inheritdoc />
        public override bool DoAnalysis(CodeDocument document)
        {
            Param.RequireNotNull(document, "document");

            CsDocument csdocument = (CsDocument)document;

            return csdocument.FileHeader == null || !csdocument.FileHeader.UnStyled;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Determines whether the type of the given token is allowed
        /// to appear after a closing parenthesis, with no space between
        /// the parenthesis and the token.
        /// </summary>
        /// <param name="token">
        /// The token to check.
        /// </param>
        /// <returns>
        /// True if it is allowed; false otherwise.
        /// </returns>
        private static bool IsAllowedAfterClosingParenthesis(CsToken token)
        {
            Param.AssertNotNull(token, "token");

            CsTokenType type = token.CsTokenType;

            if (type == CsTokenType.CloseParenthesis || type == CsTokenType.OpenParenthesis || type == CsTokenType.CloseSquareBracket
                || type == CsTokenType.OpenSquareBracket || type == CsTokenType.CloseAttributeBracket || type == CsTokenType.Semicolon || type == CsTokenType.Comma)
            {
                return true;
            }
            else if (type == CsTokenType.OperatorSymbol)
            {
                OperatorSymbol symbol = (OperatorSymbol)token;
                if (symbol.SymbolType == OperatorType.Decrement || symbol.SymbolType == OperatorType.Increment || symbol.SymbolType == OperatorType.MemberAccess
                    || symbol.SymbolType == OperatorType.Pointer || symbol.SymbolType == OperatorType.NullConditional)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Compares the token to the Operator symbol and to a dot '.'.
        /// </summary>
        /// <param name="token">
        /// The token to check.
        /// </param>
        /// <returns>
        /// True is the token is an operator and a dot '.', otherwise false.
        /// </returns>
        private static bool IsTokenADot(CsToken token)
        {
            Param.AssertNotNull(token, "token");

            if (token.CsTokenType == CsTokenType.OperatorSymbol)
            {
                OperatorSymbol symbol = (OperatorSymbol)token;
                if (symbol.SymbolType == OperatorType.MemberAccess)
                {
                    return symbol.Text == ".";
                }
            }

            return false;
        }

        /// <summary>
        /// Checks a closing attribute bracket for spacing.
        /// </summary>
        /// <param name="tokens">
        /// The list of tokens being parsed.
        /// </param>
        /// <param name="tokenNode">
        /// The token to check.
        /// </param>
        private void CheckAttributeTokenCloseBracket(MasterList<CsToken> tokens, Node<CsToken> tokenNode)
        {
            Param.AssertNotNull(tokenNode, "tokenNode");

            // Closing attribute brackets should be never be preceded by whitespace but end of line is ok.
            Node<CsToken> previousNode = tokenNode.Previous;
            if (previousNode != null && previousNode.Value.CsTokenType == CsTokenType.WhiteSpace)
            {
                if (!this.IsTokenFirstNonWhitespaceTokenOnLine(tokens, tokenNode))
                {
                    this.AddViolation(tokenNode.Value.FindParentElement(), tokenNode.Value.Location, Rules.ClosingAttributeBracketsMustBeSpacedCorrectly);
                }
            }
        }

        /// <summary>
        /// Checks a open attribute bracket for spacing.
        /// </summary>
        /// <param name="tokenNode">
        /// The token to check.
        /// </param>
        private void CheckAttributeTokenOpenBracket(Node<CsToken> tokenNode)
        {
            Param.AssertNotNull(tokenNode, "tokenNode");

            // Open brackets should never be followed by whitespace but end of line is ok.
            Node<CsToken> nextNode = tokenNode.Next;
            if (nextNode != null && nextNode.Value.CsTokenType == CsTokenType.WhiteSpace)
            {
                this.AddViolation(tokenNode.Value.FindParentElement(), tokenNode.Value.Location, Rules.OpeningAttributeBracketsMustBeSpacedCorrectly);
            }
        }

        /// <summary>
        /// Checks a close bracket for spacing.
        /// </summary>
        /// <param name="tokens">
        /// The list of tokens being parsed.
        /// </param>
        /// <param name="tokenNode">
        /// The token to check.
        /// </param>
        private void CheckCloseCurlyBracket(MasterList<CsToken> tokens, Node<CsToken> tokenNode)
        {
            Param.AssertNotNull(tokens, "tokens");
            Param.AssertNotNull(tokenNode, "tokenNode");

            // Close curly brackets should always be preceded by whitespace.
            Node<CsToken> previousNode = tokenNode.Previous;
            if (previousNode != null && previousNode.Value.CsTokenType != CsTokenType.WhiteSpace && previousNode.Value.CsTokenType != CsTokenType.EndOfLine)
            {
                this.AddViolation(tokenNode.Value.FindParentElement(), tokenNode.Value.Location, Rules.ClosingCurlyBracketsMustBeSpacedCorrectly);
            }

            // Close curly brackets should be followed either by:
            // whitespace
            // a close paren
            // a dot,
            // a semicolon
            // open square bracket
            // or a comma.
            Node<CsToken> nextNode = tokenNode.Next;
            if (nextNode != null)
            {
                CsTokenType nextType = nextNode.Value.CsTokenType;
                if (nextType != CsTokenType.WhiteSpace && nextType != CsTokenType.EndOfLine && nextType != CsTokenType.CloseParenthesis && !IsTokenADot(nextNode.Value)
                    && nextType != CsTokenType.Semicolon && nextType != CsTokenType.OpenSquareBracket && nextType != CsTokenType.Comma)
                {
                    this.AddViolation(tokenNode.Value.FindParentElement(), tokenNode.Value.Location, Rules.ClosingCurlyBracketsMustBeSpacedCorrectly);
                }

                if (nextType == CsTokenType.WhiteSpace)
                {
                    // If this is followed by whitespace, make sure that the character just
                    // after the whitespace is not a close paren, semicolon, comma or dot.
                    foreach (CsToken item in tokens.ForwardIterator(tokenNode.Next.Next))
                    {
                        CsTokenType itemType = item.CsTokenType;
                        if (itemType == CsTokenType.CloseParenthesis || itemType == CsTokenType.Semicolon || itemType == CsTokenType.Comma || IsTokenADot(item))
                        {
                            this.AddViolation(tokenNode.Value.FindParentElement(), tokenNode.Value.Location, Rules.ClosingCurlyBracketsMustBeSpacedCorrectly);
                        }
                        else if (itemType != CsTokenType.WhiteSpace)
                        {
                            break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Checks a close parenthesis for spacing.
        /// </summary>
        /// <param name="tokens">
        /// The list of tokens being parsed.
        /// </param>
        /// <param name="tokenNode">
        /// The token to check.
        /// </param>
        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Minimizing refactoring before release.")]
        private void CheckCloseParen(MasterList<CsToken> tokens, Node<CsToken> tokenNode)
        {
            Param.AssertNotNull(tokens, "tokens");
            Param.AssertNotNull(tokenNode, "tokenNode");

            // Close parens should never be preceded by whitespace.
            Node<CsToken> previousNode = tokenNode.Previous;
            if (previousNode != null)
            {
                if (previousNode.Value.CsTokenType == CsTokenType.WhiteSpace
                    || (previousNode.Value.CsTokenType == CsTokenType.EndOfLine && previousNode.Previous.Value.CsTokenType != CsTokenType.SingleLineComment))
                {
                    this.AddViolation(tokenNode.Value.FindParentElement(), previousNode.Value.Location, Rules.ClosingParenthesisMustBeSpacedCorrectly);
                }
            }

            // Find out what comes after the closing paren.
            Node<CsToken> nextNode = tokenNode.Next;

            if (nextNode != null)
            {
                CsTokenType nextType = nextNode.Value.CsTokenType;
                CsTokenType nextNextType = nextNode.Next == null ? CsTokenType.Other : nextNode.Next.Value.CsTokenType;

                if (tokenNode.Value.Parent is CastExpression || tokenNode.Value.Parent is GenericType)
                {
                    // There should not be any whitespace after the closing parenthesis in a CastExpression.
                    // There should not be any whitspace after tuple type declaration in a GenericType
                    if (nextType == CsTokenType.WhiteSpace)
                    {
                        this.AddViolation(tokenNode.Value.FindParentElement(), nextNode.Value.Location, Rules.ClosingParenthesisMustBeSpacedCorrectly);
                    }
                }
                else if (nextType == CsTokenType.LabelColon || nextNextType == CsTokenType.LabelColon)
                {
                    // If the next token is a colon, it's allowed to omit the whitespace only if we are in a switch\case statement.
                    bool followsCase = false;

                    foreach (CsToken item in tokens.ReverseIterator(tokenNode.Previous))
                    {
                        CsTokenType itemType = item.CsTokenType;
                        if (itemType == CsTokenType.EndOfLine)
                        {
                            break;
                        }
                        else if (itemType == CsTokenType.Case)
                        {
                            followsCase = true;
                            break;
                        }
                    }

                    if ((followsCase && nextType == CsTokenType.WhiteSpace) || (!followsCase && nextType != CsTokenType.WhiteSpace))
                    {
                        this.AddViolation(tokenNode.Value.FindParentElement(), nextNode.Value.Location, Rules.ClosingParenthesisMustBeSpacedCorrectly);
                    }
                }
                else if (nextType == CsTokenType.WhiteSpace)
                {
                    // Make sure that the character just after the whitespace is not a paren, bracket, a comma, or a semicolon.
                    foreach (CsToken item in tokens.ForwardIterator(tokenNode.Next.Next))
                    {
                        if (IsAllowedAfterClosingParenthesis(item))
                        {
                            this.AddViolation(tokenNode.Value.FindParentElement(), nextNode.Value.Location, Rules.ClosingParenthesisMustBeSpacedCorrectly);
                        }
                        else if (item.CsTokenType != CsTokenType.WhiteSpace)
                        {
                            break;
                        }
                    }
                }
                else
                {
                    // For all other types, the parenthesis must be followed by whitespace, unless the next character is a paren, bracket, comma, or a semicolon.
                    if (nextNode.Value.CsTokenType != CsTokenType.EndOfLine && !IsAllowedAfterClosingParenthesis(nextNode.Value))
                    {
                        this.AddViolation(tokenNode.Value.FindParentElement(), nextNode.Value.Location, Rules.ClosingParenthesisMustBeSpacedCorrectly);
                    }
                }
            }
        }

        /// <summary>
        /// Checks a close bracket for spacing.
        /// </summary>
        /// <param name="tokens">
        /// The list of tokens being parsed.
        /// </param>
        /// <param name="tokenNode">
        /// The token to check.
        /// </param>
        /// <param name="parentTokenNode">
        /// The parent token of the token node being checked.
        /// </param>
        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Minimizing refactoring before release.")]
        private void CheckCloseSquareBracket(MasterList<CsToken> tokens, Node<CsToken> tokenNode, Node<CsToken> parentTokenNode)
        {
            Param.AssertNotNull(tokens, "tokens");
            Param.AssertNotNull(tokenNode, "tokenNode");
            Param.Ignore(parentTokenNode);

            // Close brackets should never be preceded by whitespace.
            Node<CsToken> previousNode = tokenNode.Previous;
            if (previousNode != null && (previousNode.Value.CsTokenType == CsTokenType.WhiteSpace || previousNode.Value.CsTokenType == CsTokenType.EndOfLine))
            {
                this.AddViolation(tokenNode.Value.FindParentElement(), tokenNode.Value.Location, Rules.ClosingSquareBracketsMustBeSpacedCorrectly);
            }

            // Close brackets should be followed either by whitespace, a bracket,
            // a paren, a semicolon, a comma, a period, or an increment or decrement symbol.
            Node<CsToken> nextNode = tokenNode.Next ?? parentTokenNode.Next;

            if (nextNode != null)
            {
                CsTokenType nextType = nextNode.Value.CsTokenType;
                if (nextType != CsTokenType.WhiteSpace && nextType != CsTokenType.EndOfLine && nextType != CsTokenType.CloseParenthesis
                    && nextType != CsTokenType.OpenParenthesis && // someDictionary["Test"]();
                    nextType != CsTokenType.CloseSquareBracket && // someIndexer[someArray[1]] = 2;
                    nextType != CsTokenType.OpenSquareBracket && // someArray[1][2] = 2;
                    nextType != CsTokenType.Semicolon && nextType != CsTokenType.Comma && nextType != CsTokenType.CloseGenericBracket && nextNode.Value.Text != "++"
                    && nextNode.Value.Text != "--" && nextNode.Value.Text != "?." && nextNode.Value.Text != "?" && !nextNode.Value.Text.StartsWith(".", StringComparison.Ordinal))
                {
                    this.AddViolation(tokenNode.Value.FindParentElement(), tokenNode.Value.Location, Rules.ClosingSquareBracketsMustBeSpacedCorrectly);
                }

                if (nextType == CsTokenType.WhiteSpace)
                {
                    // If this is followed by whitespace, make sure that the character just
                    // after the whitespace is not a paren, bracket, comma, or semicolon.
                    foreach (CsToken item in tokens.ForwardIterator(nextNode.Next))
                    {
                        CsTokenType itemType = item.CsTokenType;
                        if (itemType == CsTokenType.CloseParenthesis || itemType == CsTokenType.OpenParenthesis || itemType == CsTokenType.CloseSquareBracket
                            || itemType == CsTokenType.OpenSquareBracket || itemType == CsTokenType.Semicolon || itemType == CsTokenType.Comma)
                        {
                            this.AddViolation(tokenNode.Value.FindParentElement(), tokenNode.Value.Location, Rules.ClosingSquareBracketsMustBeSpacedCorrectly);
                        }
                        else if (itemType != CsTokenType.WhiteSpace)
                        {
                            break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Checks the spacing of the tokens within the given generic type token.
        /// </summary>
        /// <param name="tokens">
        /// The master list of tokens.
        /// </param>
        /// <param name="genericTokenNode">
        /// The generic type token to check.
        /// </param>
        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Minimizing refactoring before release.")]
        private void CheckGenericSpacing(MasterList<CsToken> tokens, Node<CsToken> genericTokenNode)
        {
            Param.AssertNotNull(tokens, "tokens");
            Param.AssertNotNull(genericTokenNode, "genericTokenNode");

            GenericType generic = genericTokenNode.Value as GenericType;

            // Make sure it contains at least one token.
            if (generic.ChildTokens.Count > 0)
            {
                for (Node<CsToken> tokenNode = generic.ChildTokens.First; tokenNode != null; tokenNode = tokenNode.Next)
                {
                    if (this.Cancel)
                    {
                        break;
                    }

                    // Check whether this token is a generic and if so parse the tokens within
                    // the generic statement.
                    if (tokenNode.Value.CsTokenClass == CsTokenClass.GenericType)
                    {
                        this.CheckGenericSpacing(tokens, tokenNode);
                    }

                    if (!tokenNode.Value.Generated)
                    {
                        switch (tokenNode.Value.CsTokenType)
                        {
                            case CsTokenType.Comma:
                                this.CheckSemicolonAndComma(tokens, tokenNode);
                                break;

                            case CsTokenType.OpenParenthesis:
                                this.CheckOpenParen(generic.ChildTokens, tokenNode);
                                break;

                            case CsTokenType.CloseParenthesis:
                                this.CheckCloseParen(generic.ChildTokens, tokenNode);
                                break;

                            case CsTokenType.OpenSquareBracket:
                                this.CheckOpenSquareBracket(tokenNode);
                                break;

                            case CsTokenType.CloseSquareBracket:
                                this.CheckCloseSquareBracket(generic.ChildTokens, tokenNode, genericTokenNode);
                                break;

                            case CsTokenType.WhiteSpace:
                                this.CheckWhitespace(tokenNode);
                                break;

                            case CsTokenType.OpenGenericBracket:
                                this.CheckGenericTokenOpenBracket(tokenNode);
                                break;

                            case CsTokenType.CloseGenericBracket:
                                this.CheckGenericTokenCloseBracket(tokenNode, genericTokenNode);
                                break;

                            case CsTokenType.PreprocessorDirective:
                                this.CheckPreprocessorSpacing(tokenNode.Value);
                                break;

                            case CsTokenType.OperatorSymbol:
                                OperatorSymbol symbol = tokenNode.Value as OperatorSymbol;
                                if (symbol.SymbolType == OperatorType.MemberAccess || symbol.SymbolType == OperatorType.QualifiedAlias)
                                {
                                    this.CheckMemberAccessSymbol(generic.ChildTokens, tokenNode);
                                }
                                else
                                {
                                    goto default;
                                }

                                break;

                            case CsTokenType.Other:
                            case CsTokenType.EndOfLine:
                            case CsTokenType.In:
                            case CsTokenType.Out:

                                // Ignore these.
                                break;

                            default:

                                // There shouldn't be anything else within a generic type token.
                                Debug.Fail("Unexpected token type.");
                                break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Checks a closing generic bracket for spacing.
        /// </summary>
        /// <param name="closeBracketTokenNode">
        /// The token to check.
        /// </param>
        /// <param name="genericTokenNode">
        /// The generic token which is the parent of the close bracket.
        /// </param>
        private void CheckGenericTokenCloseBracket(Node<CsToken> closeBracketTokenNode, Node<CsToken> genericTokenNode)
        {
            Param.AssertNotNull(closeBracketTokenNode, "tokenNode");
            Param.AssertNotNull(genericTokenNode, "genericTokenNode");

            // Closing generic brackets should be never be preceded by whitespace.
            Node<CsToken> previousNode = closeBracketTokenNode.Previous;
            if (previousNode != null)
            {
                if (previousNode.Value.CsTokenType == CsTokenType.WhiteSpace || previousNode.Value.CsTokenType == CsTokenType.EndOfLine)
                {
                    this.AddViolation(
                        closeBracketTokenNode.Value.FindParentElement(), closeBracketTokenNode.Value.Location, Rules.ClosingGenericBracketsMustBeSpacedCorrectly);
                }
            }

            bool addViolation = false;

            // A generic close bracketshould be followed by whitespace (but not whitespace and an open paran),
            // open paren, close paren, close generic bracket, comma, period, semicolon open square bracket or endofline.
            Node<CsToken> nextNode = genericTokenNode.Next;
            if (nextNode == null)
            {
                addViolation = true;
            }
            else
            {
                CsTokenType nextNodeTokenType = nextNode.Value.CsTokenType;

                if (nextNodeTokenType != CsTokenType.WhiteSpace && nextNodeTokenType != CsTokenType.EndOfLine && nextNodeTokenType != CsTokenType.OpenParenthesis
                    && nextNodeTokenType != CsTokenType.CloseParenthesis && nextNodeTokenType != CsTokenType.CloseGenericBracket
                    && nextNodeTokenType != CsTokenType.NullableTypeSymbol && nextNodeTokenType != CsTokenType.OperatorSymbol
                    && nextNodeTokenType != CsTokenType.OpenSquareBracket && nextNodeTokenType != CsTokenType.Comma && nextNodeTokenType != CsTokenType.Semicolon)
                {
                    addViolation = true;
                }

                if (nextNodeTokenType == CsTokenType.WhiteSpace)
                {
                    Node<CsToken> nextNextNode = nextNode.Next;
                    if (nextNextNode == null || nextNextNode.Value.CsTokenType == CsTokenType.OpenParenthesis)
                    {
                        addViolation = true;
                    }
                }
            }

            if (addViolation)
            {
                this.AddViolation(
                    closeBracketTokenNode.Value.FindParentElement(), closeBracketTokenNode.Value.Location, Rules.ClosingGenericBracketsMustBeSpacedCorrectly);
            }
        }

        /// <summary>
        /// Checks a open generic bracket for spacing.
        /// </summary>
        /// <param name="tokenNode">
        /// The token to check.
        /// </param>
        private void CheckGenericTokenOpenBracket(Node<CsToken> tokenNode)
        {
            Param.AssertNotNull(tokenNode, "tokenNode");

            // Open generic brackets should be never be preceded by whitespace.
            Node<CsToken> previousNode = tokenNode.Previous;
            if (previousNode != null)
            {
                if (previousNode.Value.CsTokenType == CsTokenType.WhiteSpace || previousNode.Value.CsTokenType == CsTokenType.EndOfLine)
                {
                    this.AddViolation(tokenNode.Value.FindParentElement(), tokenNode.Value.Location, Rules.OpeningGenericBracketsMustBeSpacedCorrectly);
                }
            }

            // Open brackets should never be followed by whitespace.
            Node<CsToken> nextNode = tokenNode.Next;
            if (nextNode != null && (nextNode.Value.CsTokenType == CsTokenType.WhiteSpace || nextNode.Value.CsTokenType == CsTokenType.EndOfLine))
            {
                this.AddViolation(tokenNode.Value.FindParentElement(), tokenNode.Value.Location, Rules.OpeningGenericBracketsMustBeSpacedCorrectly);
            }
        }

        /// <summary>
        /// Checks an increment or decrement sign for spacing.
        /// </summary>
        /// <param name="tokenNode">
        /// The token to check.
        /// </param>
        private void CheckIncrementDecrement(Node<CsToken> tokenNode)
        {
            Param.AssertNotNull(tokenNode, "tokenNode");

            // Increment and decrement symbols should have whitespace on only one side. The non-whitespace
            // side is also allowed to butt up against a bracket or a parenthesis, however.
            bool before = false;
            bool after = false;

            Node<CsToken> previousNode = tokenNode.Previous;
            if (previousNode == null)
            {
                before = true;
            }
            else
            {
                CsTokenType tokenType = previousNode.Value.CsTokenType;
                if (tokenType == CsTokenType.WhiteSpace || tokenType == CsTokenType.EndOfLine || tokenType == CsTokenType.SingleLineComment
                    || tokenType == CsTokenType.MultiLineComment)
                {
                    before = true;
                }
            }

            Node<CsToken> nextNode = tokenNode.Next;
            if (nextNode == null)
            {
                after = true;
            }
            else
            {
                CsTokenType tokenType = nextNode.Value.CsTokenType;
                if (tokenType == CsTokenType.WhiteSpace || tokenType == CsTokenType.EndOfLine || tokenType == CsTokenType.SingleLineComment
                    || tokenType == CsTokenType.MultiLineComment)
                {
                    after = true;
                }
            }

            bool addViolation = false;

            // If there is no whitespace on either side, then make sure that at least one of the sides
            // is touching a square bracket or a parenthesis. The right side of the symbol is also
            // allowed to be up against a comma or a semicolon.
            if (!before && !after)
            {
                if (previousNode.Value.CsTokenType == CsTokenType.OpenSquareBracket || previousNode.Value.CsTokenType == CsTokenType.OpenParenthesis)
                {
                    return;
                }

                CsTokenType tokenType = nextNode.Value.CsTokenType;
                if (tokenType == CsTokenType.CloseSquareBracket || tokenType == CsTokenType.CloseParenthesis || tokenType == CsTokenType.Comma
                    || tokenType == CsTokenType.Semicolon)
                {
                    return;
                }

                // This is a violation.
                addViolation = true;
            }
            else if (before && after)
            {
                // There is whitespace on both sides.
                addViolation = true;
            }
            else if (before)
            {
                // Whitespace before but not after
                // In this case if we are followed by a semi colon, close paran, comma, close square
                // Then its a violation
                CsTokenType tokenType = nextNode.Value.CsTokenType;
                if (tokenType == CsTokenType.CloseSquareBracket || tokenType == CsTokenType.CloseParenthesis || tokenType == CsTokenType.Comma
                    || tokenType == CsTokenType.Semicolon)
                {
                    addViolation = true;
                }
            }
            else
            {
                // Whitespace after but not before
                // In this case if we are preceded by an open square or open paran
                // Then its a violation
                if (previousNode.Value.CsTokenType == CsTokenType.OpenSquareBracket || previousNode.Value.CsTokenType == CsTokenType.OpenParenthesis)
                {
                    addViolation = true;
                }
            }

            if (addViolation)
            {
                this.AddViolation(tokenNode.Value.FindParentElement(), tokenNode.Value.Location, Rules.IncrementDecrementSymbolsMustBeSpacedCorrectly);
            }
        }

        /// <summary>
        /// Checks a keyword that should be followed by a space.
        /// </summary>
        /// <param name="tokenNode">
        /// The token node to check.
        /// </param>
        private void CheckKeywordWithSpace(Node<CsToken> tokenNode)
        {
            Param.AssertNotNull(tokenNode, "tokenNode");

            // Keywords must be followed by a space before the open parenthesis.
            // Sometimes keywords appear within attributes and are allowed to be
            // followed immediately by an attribute colon.
            Node<CsToken> temp = tokenNode.Next;
            if (temp == null
                || (temp.Value.CsTokenType != CsTokenType.WhiteSpace && temp.Value.CsTokenType != CsTokenType.EndOfLine && temp.Value.CsTokenType != CsTokenType.Semicolon
                    && temp.Value.CsTokenType != CsTokenType.AttributeColon))
            {
                this.AddViolation(tokenNode.Value.FindParentElement(), tokenNode.Value.Location, Rules.KeywordsMustBeSpacedCorrectly, tokenNode.Value.Text);
            }
        }

        /// <summary>
        /// Checks a keyword that should not be followed by a space.
        /// </summary>
        /// <param name="tokens">
        /// The list of tokens being parsed.
        /// </param>
        /// <param name="tokenNode">
        /// The token to check.
        /// </param>
        private void CheckKeywordWithoutSpace(MasterList<CsToken> tokens, Node<CsToken> tokenNode)
        {
            Param.AssertNotNull(tokens, "tokens");
            Param.AssertNotNull(tokenNode, "tokenNode");

            // Keywords must not contain any space before the open parenthesis.
            Node<CsToken> temp = tokenNode.Next;
            if (temp != null && (temp.Value.CsTokenType == CsTokenType.WhiteSpace || temp.Value.CsTokenType == CsTokenType.EndOfLine))
            {
                // Make sure the next non-whitespace character is not an open parenthesis.
                foreach (CsToken nextNonWhitespaceToken in tokens.ForwardIterator(temp.Next))
                {
                    if (nextNonWhitespaceToken.CsTokenType == CsTokenType.OpenParenthesis)
                    {
                        this.AddViolation(tokenNode.Value.FindParentElement(), tokenNode.Value.Location, Rules.KeywordsMustBeSpacedCorrectly, tokenNode.Value.Text);

                        break;
                    }
                    else if (nextNonWhitespaceToken.CsTokenType != CsTokenType.WhiteSpace && nextNonWhitespaceToken.CsTokenType != CsTokenType.EndOfLine)
                    {
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Checks a label colon for spacing.
        /// </summary>
        /// <param name="tokenNode">
        /// The token to check.
        /// </param>
        private void CheckLabelColon(Node<CsToken> tokenNode)
        {
            Param.AssertNotNull(tokenNode, "tokenNode");

            // A colon should always be followed by whitespace, but never preceded by whitespace.
            Node<CsToken> nextNode = tokenNode.Next;
            if (nextNode != null)
            {
                CsTokenType tokenType = nextNode.Value.CsTokenType;
                if (tokenType != CsTokenType.WhiteSpace && tokenType != CsTokenType.EndOfLine)
                {
                    this.AddViolation(tokenNode.Value.FindParentElement(), tokenNode.Value.Location, Rules.ColonsMustBeSpacedCorrectly);
                }
            }

            Node<CsToken> previousNode = tokenNode.Previous;
            if (previousNode != null)
            {
                CsTokenType tokenType = previousNode.Value.CsTokenType;
                if (tokenType == CsTokenType.WhiteSpace || tokenType == CsTokenType.EndOfLine || tokenType == CsTokenType.SingleLineComment
                    || tokenType == CsTokenType.MultiLineComment)
                {
                    this.AddViolation(tokenNode.Value.FindParentElement(), tokenNode.Value.Location, Rules.ColonsMustBeSpacedCorrectly);
                }
            }
        }

        /// <summary>
        /// Checks a member access symbol for spacing.
        /// </summary>
        /// <param name="tokens">
        /// The list of tokens being parsed.
        /// </param>
        /// <param name="tokenNode">
        /// The token to check.
        /// </param>
        private void CheckMemberAccessSymbol(MasterList<CsToken> tokens, Node<CsToken> tokenNode)
        {
            Param.AssertNotNull(tokens, "tokens");
            Param.AssertNotNull(tokenNode, "tokenNode");

            // Member access symbols should not have any whitespace on either side.
            Node<CsToken> previousNode = tokenNode.Previous;
            if (previousNode != null)
            {
                CsTokenType previousTokenType = previousNode.Value.CsTokenType;
                if (previousTokenType == CsTokenType.WhiteSpace || previousTokenType == CsTokenType.EndOfLine || previousTokenType == CsTokenType.SingleLineComment
                    || previousTokenType == CsTokenType.MultiLineComment)
                {
                    if (!this.IsTokenFirstNonWhitespaceTokenOnLine(tokens, tokenNode))
                    {
                        this.AddViolation(tokenNode.Value.FindParentElement(), tokenNode.Value.Location, Rules.MemberAccessSymbolsMustBeSpacedCorrectly);
                    }
                }
            }

            Node<CsToken> nextNode = tokenNode.Next;
            if (nextNode != null)
            {
                CsTokenType tokenType = nextNode.Value.CsTokenType;
                if (tokenType == CsTokenType.WhiteSpace || tokenType == CsTokenType.EndOfLine || tokenType == CsTokenType.SingleLineComment
                    || tokenType == CsTokenType.MultiLineComment)
                {
                    // Make sure the previous token is not the operator keyword.
                    if (previousNode != null)
                    {
                        foreach (CsToken item in tokens.ReverseIterator(previousNode))
                        {
                            CsTokenType itemType = item.CsTokenType;
                            if (itemType == CsTokenType.Operator)
                            {
                                return;
                            }
                            else if (itemType != CsTokenType.WhiteSpace && itemType != CsTokenType.EndOfLine && itemType != CsTokenType.SingleLineComment
                                     && itemType != CsTokenType.MultiLineComment)
                            {
                                break;
                            }
                        }
                    }

                    this.AddViolation(tokenNode.Value.FindParentElement(), tokenNode.Value.Location, Rules.MemberAccessSymbolsMustBeSpacedCorrectly);
                }
            }
        }

        /// <summary>
        /// Checks the spacing around a 'new' keyword.
        /// </summary>
        /// <param name="tokens">
        /// The token list.
        /// </param>
        /// <param name="tokenNode">
        /// The token node to check.
        /// </param>
        private void CheckNewKeywordSpacing(MasterList<CsToken> tokens, Node<CsToken> tokenNode)
        {
            Param.AssertNotNull(tokens, "tokens");
            Param.AssertNotNull(tokenNode, "tokenNode");

            // The keywords must be followed by a space, unless the next token is an opening square bracket, in which case
            // there should be no space.
            Node<CsToken> temp = tokenNode.Next;
            if (temp != null)
            {
                if (temp.Value.CsTokenType == CsTokenType.WhiteSpace || temp.Value.CsTokenType == CsTokenType.EndOfLine)
                {
                    // The keyword is followed by whitespace. Make sure the next non-whitespace character is not an opening bracket.
                    foreach (CsToken nextNonWhitespaceToken in tokens.ForwardIterator(temp.Next))
                    {
                        if (nextNonWhitespaceToken.CsTokenType == CsTokenType.OpenSquareBracket)
                        {
                            this.AddViolation(
                                tokenNode.Value.FindParentElement(),
                                tokenNode.Value.Location,
                                Rules.CodeMustNotContainSpaceAfterNewKeywordInImplicitlyTypedArrayAllocation);
                            break;
                        }
                        else if (nextNonWhitespaceToken.CsTokenType != CsTokenType.WhiteSpace && nextNonWhitespaceToken.CsTokenType != CsTokenType.EndOfLine)
                        {
                            break;
                        }
                    }
                }
                else if (temp.Value.CsTokenType != CsTokenType.OpenSquareBracket)
                {
                    // The keyword is not followed by whitespace.
                    this.AddViolation(tokenNode.Value.FindParentElement(), tokenNode.Value.Location, Rules.KeywordsMustBeSpacedCorrectly, tokenNode.Value.Text);
                }
            }
        }

        /// <summary>
        /// Checks a <see cref="Nullable"/> type symbol for spacing.
        /// </summary>
        /// <param name="tokenNode">
        /// The token to check.
        /// </param>
        private void CheckNullableTypeSymbol(Node<CsToken> tokenNode)
        {
            Param.AssertNotNull(tokenNode, "tokenNode");

            // Nullable type symbols should never be preceded by whitespace.
            Node<CsToken> previousNode = tokenNode.Previous;
            if (previousNode != null && (previousNode.Value.CsTokenType == CsTokenType.WhiteSpace || previousNode.Value.CsTokenType == CsTokenType.EndOfLine))
            {
                this.AddViolation(tokenNode.Value.FindParentElement(), tokenNode.Value.Location, Rules.NullableTypeSymbolsMustNotBePrecededBySpace);
            }
        }

        /// <summary>
        /// Checks a open bracket for spacing.
        /// </summary>
        /// <param name="tokens">
        /// The list of tokens being parsed.
        /// </param>
        /// <param name="tokenNode">
        /// The token to check.
        /// </param>
        private void CheckOpenCurlyBracket(MasterList<CsToken> tokens, Node<CsToken> tokenNode)
        {
            Param.AssertNotNull(tokens, "tokens");
            Param.AssertNotNull(tokenNode, "tokenNode");

            // Open curly brackets should be preceded either by whitespace, or an open paren.
            Node<CsToken> previousNode = tokenNode.Previous;
            if (previousNode != null)
            {
                CsTokenType lastType = previousNode.Value.CsTokenType;
                if (lastType != CsTokenType.WhiteSpace && lastType != CsTokenType.EndOfLine && lastType != CsTokenType.OpenParenthesis)
                {
                    this.AddViolation(tokenNode.Value.FindParentElement(), tokenNode.Value.Location, Rules.OpeningCurlyBracketsMustBeSpacedCorrectly);
                }

                if (lastType == CsTokenType.WhiteSpace)
                {
                    // If this is preceded by whitespace, make sure that the character just
                    // before the whitespace is not an open paren.
                    foreach (CsToken item in tokens.ReverseIterator(previousNode))
                    {
                        CsTokenType itemType = item.CsTokenType;
                        if (itemType == CsTokenType.OpenParenthesis)
                        {
                            this.AddViolation(tokenNode.Value.FindParentElement(), tokenNode.Value.Location, Rules.OpeningCurlyBracketsMustBeSpacedCorrectly);
                        }
                        else if (itemType != CsTokenType.WhiteSpace)
                        {
                            break;
                        }
                    }
                }
            }

            // Open curly brackets should always be followed by whitespace.
            Node<CsToken> nextNode = tokenNode.Next;
            if (nextNode != null && nextNode.Value.CsTokenType != CsTokenType.WhiteSpace && nextNode.Value.CsTokenType != CsTokenType.EndOfLine)
            {
                this.AddViolation(tokenNode.Value.FindParentElement(), tokenNode.Value.Location, Rules.OpeningCurlyBracketsMustBeSpacedCorrectly);
            }
        }

        /// <summary>
        /// Checks an open parenthesis for spacing.
        /// </summary>
        /// <param name="tokens">
        /// The list of tokens being parsed.
        /// </param>
        /// <param name="tokenNode">
        /// The token to check.
        /// </param>
        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Minimizing refactoring before release.")]
        private void CheckOpenParen(MasterList<CsToken> tokens, Node<CsToken> tokenNode)
        {
            Param.AssertNotNull(tokens, "tokens");
            Param.AssertNotNull(tokenNode, "tokenNode");

            bool firstOnLine = false;
            bool lastOnLine = false;

            // Open parenthesis should never be preceded by whitespace unless it is the
            // first thing on the line or it follows a keyword or it follows a symbol or a number.
            Node<CsToken> previousNode = tokenNode.Previous;
            if (previousNode != null)
            {
                if (previousNode.Value.CsTokenType == CsTokenType.WhiteSpace)
                {
                    foreach (CsToken item in tokens.ReverseIterator(previousNode))
                    {
                        CsTokenType itemType = item.CsTokenType;
                        if (itemType == CsTokenType.WhiteSpace)
                        {
                            continue;
                        }

                        if (itemType == CsTokenType.EndOfLine)
                        {
                            firstOnLine = true;
                            break;
                        }

                        if (itemType == CsTokenType.Case || itemType == CsTokenType.Catch || itemType == CsTokenType.CloseSquareBracket || itemType == CsTokenType.Comma
                            || itemType == CsTokenType.Equals || itemType == CsTokenType.Fixed || itemType == CsTokenType.For || itemType == CsTokenType.Foreach
                            || itemType == CsTokenType.From || ////itemType == CsTokenType.Goto ||
                            itemType == CsTokenType.Group || itemType == CsTokenType.If || itemType == CsTokenType.In || itemType == CsTokenType.Into
                            || itemType == CsTokenType.Join || itemType == CsTokenType.Let || itemType == CsTokenType.Lock || itemType == CsTokenType.MultiLineComment
                            || ////itemType == CsTokenType.New ||
                            itemType == CsTokenType.Number || itemType == CsTokenType.OperatorSymbol || itemType == CsTokenType.OpenCurlyBracket
                            || itemType == CsTokenType.OrderBy || itemType == CsTokenType.Return || itemType == CsTokenType.Select || itemType == CsTokenType.Semicolon
                            || ////itemType == CsTokenType.SingleLineComment ||
                            itemType == CsTokenType.Switch || itemType == CsTokenType.Throw || itemType == CsTokenType.Using || itemType == CsTokenType.Where
                            || itemType == CsTokenType.While || itemType == CsTokenType.WhileDo || itemType == CsTokenType.Yield || itemType == CsTokenType.LabelColon
                            || itemType == CsTokenType.Async || itemType == CsTokenType.By || itemType == CsTokenType.When || item.Text == "var")
                        {
                            break;
                        }

                        this.AddViolation(tokenNode.Value.FindParentElement(), previousNode.Value.Location, Rules.OpeningParenthesisMustBeSpacedCorrectly);
                    }
                }
            }

            // Open parens should never be followed by whitespace unless
            // it is the last thing on the line.
            Node<CsToken> next = tokenNode.Next;
            if (next != null && (next.Value.CsTokenType == CsTokenType.WhiteSpace || next.Value.CsTokenType == CsTokenType.EndOfLine))
            {
                // Look to see if there is any non whitespace character
                // on this line other than a comment.
                foreach (CsToken item in tokens.ForwardIterator(next))
                {
                    CsTokenType itemType = item.CsTokenType;
                    if (itemType == CsTokenType.EndOfLine)
                    {
                        lastOnLine = true;
                        break;
                    }
                    else if (itemType != CsTokenType.WhiteSpace && itemType != CsTokenType.SingleLineComment && itemType != CsTokenType.MultiLineComment)
                    {
                        this.AddViolation(tokenNode.Value.FindParentElement(), next.Value.Location, Rules.OpeningParenthesisMustBeSpacedCorrectly);
                        break;
                    }
                }
            }

            // Open parens cannot be the only thing on the line.
            if (firstOnLine && lastOnLine)
            {
                this.AddViolation(tokenNode.Value.FindParentElement(), tokenNode.Value.Location, Rules.OpeningParenthesisMustBeSpacedCorrectly);
            }
        }

        /// <summary>
        /// Checks a open bracket for spacing.
        /// </summary>
        /// <param name="tokenNode">
        /// The token to check.
        /// </param>
        private void CheckOpenSquareBracket(Node<CsToken> tokenNode)
        {
            Param.AssertNotNull(tokenNode, "tokenNode");

            // Open brackets should be never be preceded by whitespace.
            Node<CsToken> previousNode = tokenNode.Previous;
            if (previousNode != null)
            {
                if (previousNode.Value.CsTokenType == CsTokenType.WhiteSpace || previousNode.Value.CsTokenType == CsTokenType.EndOfLine)
                {
                    // Check if parent expression is an array, initialization was introduced in C# 6.
                    Expression parentExpression = tokenNode.Value.Parent as Expression;
                    if (parentExpression != null
                        && parentExpression.ExpressionType != ExpressionType.ArrayInitializer)
                    {
                        this.AddViolation(tokenNode.Value.FindParentElement(), tokenNode.Value.Location, Rules.OpeningSquareBracketsMustBeSpacedCorrectly);
                    }
                    else
                    {
                        TypeToken parentTypeToken = tokenNode.Value.Parent as TypeToken;
                        if (parentTypeToken != null && parentTypeToken.CsTokenClass == CsTokenClass.Type)
                        {
                            this.AddViolation(tokenNode.Value.FindParentElement(), tokenNode.Value.Location, Rules.OpeningSquareBracketsMustBeSpacedCorrectly);
                        }
                    }
                }
            }

            // Open brackets should never be followed by whitespace.
            Node<CsToken> nextNode = tokenNode.Next;
            if (nextNode != null && (nextNode.Value.CsTokenType == CsTokenType.WhiteSpace || nextNode.Value.CsTokenType == CsTokenType.EndOfLine))
            {
                this.AddViolation(tokenNode.Value.FindParentElement(), tokenNode.Value.Location, Rules.OpeningSquareBracketsMustBeSpacedCorrectly);
            }
        }

        /// <summary>
        /// Checks the operator keyword for spacing.
        /// </summary>
        /// <param name="tokenNode">
        /// The token to check.
        /// </param>
        private void CheckOperatorKeyword(Node<CsToken> tokenNode)
        {
            Param.AssertNotNull(tokenNode, "tokenNode");

            // Operator keywords should be followed by whitespace.
            Node<CsToken> next = tokenNode.Next;
            if (next != null && next.Value.CsTokenType != CsTokenType.WhiteSpace)
            {
                this.AddViolation(tokenNode.Value.FindParentElement(), tokenNode.Value.Location, Rules.OperatorKeywordMustBeFollowedBySpace);
            }
        }

        /// <summary>
        /// Checks a positive/negative sign for spacing.
        /// </summary>
        /// <param name="tokenNode">
        /// The token to check.
        /// </param>
        /// <param name="positiveToken">
        /// True is the token is positive.
        /// </param>
        private void CheckPositiveOrNegativeSign(Node<CsToken> tokenNode, bool positiveToken)
        {
            Param.AssertNotNull(tokenNode, "tokenNode");
            Param.Ignore(positiveToken, "positiveToken");

            bool addViolation = false;

            Node<CsToken> previousNode = tokenNode.Previous;

            if (previousNode == null)
            {
                addViolation = true;
            }
            else
            {
                CsTokenType previousTokenType = previousNode.Value.CsTokenType;

                if (previousTokenType != CsTokenType.WhiteSpace && previousTokenType != CsTokenType.EndOfLine && previousTokenType != CsTokenType.CloseParenthesis
                    && previousTokenType != CsTokenType.OpenParenthesis && previousTokenType != CsTokenType.OpenSquareBracket)
                {
                    addViolation = true;
                }
                else
                {
                    if (previousTokenType == CsTokenType.WhiteSpace || previousTokenType == CsTokenType.EndOfLine)
                    {
                        Node<CsToken> previousPreviousNode = previousNode.Previous;
                        if (previousPreviousNode != null)
                        {
                            CsTokenType previousPreviousTokenType = previousPreviousNode.Value.CsTokenType;

                            if (previousPreviousTokenType == CsTokenType.OpenParenthesis || previousPreviousTokenType == CsTokenType.OpenSquareBracket)
                            {
                                addViolation = true;
                            }
                        }
                    }
                }
            }

            if (addViolation)
            {
                this.AddViolation(
                    tokenNode.Value.FindParentElement(),
                    tokenNode.Value.Location,
                    positiveToken ? Rules.PositiveSignsMustBeSpacedCorrectly : Rules.NegativeSignsMustBeSpacedCorrectly);
            }

            Node<CsToken> nextNode = tokenNode.Next;
            if (nextNode != null)
            {
                CsTokenType tokenType = nextNode.Value.CsTokenType;
                if (tokenType == CsTokenType.WhiteSpace || tokenType == CsTokenType.EndOfLine || tokenType == CsTokenType.SingleLineComment
                    || tokenType == CsTokenType.MultiLineComment)
                {
                    this.AddViolation(
                        tokenNode.Value.FindParentElement(),
                        tokenNode.Value.Location,
                        positiveToken ? Rules.PositiveSignsMustBeSpacedCorrectly : Rules.NegativeSignsMustBeSpacedCorrectly);
                }
            }
        }

        /// <summary>
        /// Checks to make sure that preprocessor type keyword is not preceded by a space.
        /// </summary>
        /// <param name="preprocessor">
        /// The preprocessor token.
        /// </param>
        private void CheckPreprocessorSpacing(CsToken preprocessor)
        {
            Param.AssertNotNull(preprocessor, "preprocessor");

            if (preprocessor.Text.Length > 1)
            {
                if (preprocessor.Text[0] == '#')
                {
                    if (preprocessor.Text[1] == ' ' || preprocessor.Text[1] == '\t')
                    {
                        this.AddViolation(preprocessor.FindParentElement(), preprocessor.Location, Rules.PreprocessorKeywordsMustNotBePrecededBySpace);
                    }
                }
            }
        }

        /// <summary>
        /// Checks a semicolon or comma for spacing.
        /// </summary>
        /// <param name="tokens">
        /// The master list of tokens.
        /// </param>
        /// <param name="tokenNode">
        /// The token node to check.
        /// </param>
        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Minimizing refactoring before release.")]
        private void CheckSemicolonAndComma(MasterList<CsToken> tokens, Node<CsToken> tokenNode)
        {
            Param.AssertNotNull(tokenNode, "tokenNode");
            Param.AssertNotNull(tokens, "tokens");

            bool comma = false;
            if (tokenNode.Value.Text == ",")
            {
                comma = true;
            }
            else
            {
                Debug.Assert(tokenNode.Value.Text == ";", "The token should either be a comma or a semicolon");
            }

            // There is a special case here where we allow <,,> [,,] or (;;), or variations thereof.
            // In these cases, there should be no spaces around the comma or semicolon.
            string[] open = new[] { "[", "<" };
            string[] close = new[] { "]", ">" };

            if (!comma)
            {
                open = new[] { "(" };
                close = new[] { ")" };
            }

            bool specialCaseBackwards = true;
            bool specialCaseForwards = true;

            // Work backwards and look for the previous character on this line.
            bool found = false;
            Node<CsToken> itemNode = tokenNode.Previous;
            if (itemNode != null)
            {
                for (int i = 0; i < open.Length; ++i)
                {
                    if (itemNode.Value.Text == open[i])
                    {
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    if (itemNode.Value.Text == tokenNode.Value.Text)
                    {
                        found = true;
                    }
                    else
                    {
                        specialCaseBackwards = false;
                    }
                }
            }

            if (!found)
            {
                specialCaseBackwards = false;
            }

            // Work backwards until the first non-whitespace or newline.
            // If thats a LabelColon then thats fine too. Fix for #7183
            foreach (CsToken previousNonWhitespaceToken in tokens.ReverseIterator(tokenNode.Previous))
            {
                if (previousNonWhitespaceToken.CsTokenType == CsTokenType.LabelColon)
                {
                    specialCaseBackwards = true;
                    break;
                }

                if (previousNonWhitespaceToken.CsTokenType != CsTokenType.WhiteSpace && previousNonWhitespaceToken.CsTokenType != CsTokenType.EndOfLine)
                {
                    break;
                }
            }

            // Work forwards and look for the next character on this line.
            found = false;
            itemNode = tokenNode.Next;
            if (itemNode != null)
            {
                for (int i = 0; i < close.Length; ++i)
                {
                    if (itemNode.Value.Text == close[i])
                    {
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    if (itemNode.Value.Text == tokenNode.Value.Text)
                    {
                        found = true;
                    }
                    else
                    {
                        specialCaseForwards = false;
                    }
                }
            }

            if (!found)
            {
                specialCaseForwards = false;
            }

            if (!specialCaseBackwards)
            {
                Node<CsToken> previousNode = tokenNode.Previous;

                // Make sure this is not preceded by whitespace.
                if (previousNode != null && (previousNode.Value.CsTokenType == CsTokenType.WhiteSpace || previousNode.Value.CsTokenType == CsTokenType.EndOfLine))
                {
                    this.AddViolation(
                        tokenNode.Value.FindParentElement(), tokenNode.Value.Location, comma ? Rules.CommasMustBeSpacedCorrectly : Rules.SemicolonsMustBeSpacedCorrectly);
                }
            }

            if (!specialCaseForwards)
            {
                Node<CsToken> nextNode = tokenNode.Next;

                // Make sure this is followed by whitespace or a close paren.
                if (nextNode != null && nextNode.Value.CsTokenType != CsTokenType.WhiteSpace && nextNode.Value.CsTokenType != CsTokenType.EndOfLine
                    && nextNode.Value.CsTokenType != CsTokenType.CloseParenthesis)
                {
                    this.AddViolation(
                        tokenNode.Value.FindParentElement(), tokenNode.Value.Location, comma ? Rules.CommasMustBeSpacedCorrectly : Rules.SemicolonsMustBeSpacedCorrectly);
                }
            }
        }

        /// <summary>
        /// Checks to make sure that the slashes in in the comment are followed by a space.
        /// </summary>
        /// <param name="tokens">
        /// The list of tokens being parsed.
        /// </param>
        /// <param name="tokenNode">
        /// The comment token.
        /// </param>
        private void CheckSingleLineComment(MasterList<CsToken> tokens, Node<CsToken> tokenNode)
        {
            Param.AssertNotNull(tokens, "tokens");
            Param.AssertNotNull(tokenNode, "tokenNode");

            // If the token length is less then two, this is not a valid comment so just ignore it.
            if (tokenNode.Value.Text.Length > 2)
            {
                bool addViolation = false;

                // The first character in the comment must be a space, except for the following four cases:
                // 1. The comment may start with three or more slashes: ///whatever
                // 2. The command may start with a backwards slash: //\whatever
                // 3. The comment may start with a dash if there are at last two dashes: //--
                // 4. The character after the second slash may be a newline character.
                string text = tokenNode.Value.Text;
                if (text[2] != ' ' && text[2] != '\t' && text[2] != '/' && text[2] != '\\' && text[1] != '\n' && text[1] != '\r'
                    && (text.Length < 4 || text[2] != '-' || text[3] != '-'))
                {
                    // The comment does not start with a single space.
                    addViolation = true;
                }
                else if (text.Length > 3 && (text[3] == ' ' || text[3] == '\t') && text[2] != '\\')
                {
                    // The comment starts with more than one space. This is only a violation if this is the first 
                    // single-line comment in a row. If there is another single-line comment directly above this one
                    // with no blank line between them, this is not a violation.
                    bool first = true;
                    int newLineCount = 0;

                    foreach (CsToken previousToken in tokens.ReverseIterator(tokenNode.Previous))
                    {
                        if (previousToken.CsTokenType == CsTokenType.EndOfLine)
                        {
                            if (++newLineCount == 2)
                            {
                                break;
                            }
                        }
                        else if (previousToken.CsTokenType == CsTokenType.SingleLineComment)
                        {
                            first = false;
                            break;
                        }
                        else if (previousToken.CsTokenType != CsTokenType.WhiteSpace)
                        {
                            break;
                        }
                    }

                    if (first)
                    {
                        addViolation = true;
                    }

                    if (tokenNode.Value.Parent is FileHeader)
                    {
                        // Starting with multiple spaces is only an issue if we're outside the FileHeader
                        addViolation = false;
                    }
                }

                if (addViolation)
                {
                    this.AddViolation(tokenNode.Value.FindParentElement(), tokenNode.Value.Location, Rules.SingleLineCommentsMustBeginWithSingleSpace);
                }
            }
        }

        /// <summary>
        /// Checks the spacing of a root.
        /// </summary>
        /// <param name="tokens">
        /// The list of tokens.
        /// </param>
        /// <param name="type">
        /// Indicates whether the tokens are part of a type declaration.
        /// </param>
        /// <param name="parentTokenNode">
        /// The parent token of the token node being checked.
        /// </param>
        [SuppressMessage("Microsoft.Maintainability", "CA1505:AvoidUnmaintainableCode", Justification = "Minimizing refactoring before release.")]
        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Minimizing refactoring before release.")]
        private void CheckSpacing(MasterList<CsToken> tokens, bool type, Node<CsToken> parentTokenNode)
        {
            Param.AssertNotNull(tokens, "tokens");
            Param.Ignore(type);

            // Make sure it contains at least one token.
            if (tokens.Count > 0)
            {
                for (Node<CsToken> tokenNode = tokens.First; tokenNode != null; tokenNode = tokenNode.Next)
                {
                    if (this.Cancel)
                    {
                        break;
                    }

                    if (!tokenNode.Value.Generated)
                    {
                        switch (tokenNode.Value.CsTokenType)
                        {
                            case CsTokenType.Async:
                            case CsTokenType.By:
                            case CsTokenType.Catch:
                            case CsTokenType.Equals:
                            case CsTokenType.Fixed:
                            case CsTokenType.For:
                            case CsTokenType.Foreach:
                            case CsTokenType.From:
                            case CsTokenType.Group:
                            case CsTokenType.If:
                            case CsTokenType.In:
                            case CsTokenType.Into:
                            case CsTokenType.Join:
                            case CsTokenType.Let:
                            case CsTokenType.Lock:
                            case CsTokenType.On:
                            case CsTokenType.OrderBy:
                            case CsTokenType.Return:
                            case CsTokenType.Select:
                            case CsTokenType.Stackalloc:
                            case CsTokenType.Switch:
                            case CsTokenType.Throw:
                            case CsTokenType.Using:
                            case CsTokenType.Where:
                            case CsTokenType.While:
                            case CsTokenType.WhileDo:
                            case CsTokenType.Yield:

                                // These keywords must be followed by a space before the open parenthesis.
                                this.CheckKeywordWithSpace(tokenNode);
                                break;

                            case CsTokenType.New:
                                this.CheckNewKeywordSpacing(tokens, tokenNode);
                                break;

                            case CsTokenType.Checked:
                            case CsTokenType.Unchecked:
                            case CsTokenType.Sizeof:
                            case CsTokenType.Typeof:
                            case CsTokenType.DefaultValue:

                                // These keywords must not contain any space before the open parenthesis.
                                this.CheckKeywordWithoutSpace(tokens, tokenNode);
                                break;

                            case CsTokenType.Comma:
                            case CsTokenType.Semicolon:
                                this.CheckSemicolonAndComma(tokens, tokenNode);
                                break;

                            case CsTokenType.OpenParenthesis:
                                this.CheckOpenParen(tokens, tokenNode);
                                break;

                            case CsTokenType.CloseParenthesis:
                                this.CheckCloseParen(tokens, tokenNode);
                                break;

                            case CsTokenType.OpenSquareBracket:
                                this.CheckOpenSquareBracket(tokenNode);
                                break;

                            case CsTokenType.CloseSquareBracket:
                                this.CheckCloseSquareBracket(tokens, tokenNode, parentTokenNode);
                                break;

                            case CsTokenType.OpenCurlyBracket:
                                this.CheckOpenCurlyBracket(tokens, tokenNode);
                                break;

                            case CsTokenType.CloseCurlyBracket:
                                this.CheckCloseCurlyBracket(tokens, tokenNode);
                                break;

                            case CsTokenType.OpenAttributeBracket:
                                this.CheckAttributeTokenOpenBracket(tokenNode);
                                break;

                            case CsTokenType.CloseAttributeBracket:
                                this.CheckAttributeTokenCloseBracket(tokens, tokenNode);
                                break;

                            case CsTokenType.BaseColon:
                            case CsTokenType.WhereColon:
                                this.CheckSymbol(tokens, tokenNode);
                                break;

                            case CsTokenType.AttributeColon:
                            case CsTokenType.LabelColon:
                                this.CheckLabelColon(tokenNode);
                                break;

                            case CsTokenType.WhiteSpace:
                                this.CheckWhitespace(tokenNode);
                                break;

                            case CsTokenType.XmlHeader:
                                XmlHeader header = (XmlHeader)tokenNode.Value;
                                this.CheckXmlHeaderComment(header);

                                // Look for tabs in the xml header string. Look at 
                                // each sub-token in the header individually to get the
                                // line numbers correct.
                                for (Node<CsToken> xmlHeaderToken = header.ChildTokens.First; xmlHeaderToken != null; xmlHeaderToken = xmlHeaderToken.Next)
                                {
                                    this.CheckTabsInComment(xmlHeaderToken.Value);
                                }

                                break;

                            case CsTokenType.Attribute:
                                Attribute attribute = tokenNode.Value as StyleCop.CSharp.Attribute;
                                this.CheckSpacing(attribute.ChildTokens, false, tokenNode);
                                break;

                            case CsTokenType.PreprocessorDirective:
                                this.CheckPreprocessorSpacing(tokenNode.Value as Preprocessor);
                                break;

                            case CsTokenType.SingleLineComment:

                                // Look for tabs in the comment string.
                                this.CheckTabsInComment(tokenNode.Value);

                                // Check spacing in the comment.
                                this.CheckSingleLineComment(tokens, tokenNode);
                                break;

                            case CsTokenType.MultiLineComment:

                                // Look for tabs in the comment string.
                                this.CheckTabsInComment(tokenNode.Value);
                                break;

                            case CsTokenType.NullableTypeSymbol:
                                this.CheckNullableTypeSymbol(tokenNode);
                                break;

                            case CsTokenType.Operator:
                                this.CheckOperatorKeyword(tokenNode);
                                break;

                            case CsTokenType.OperatorSymbol:
                                OperatorSymbol operatorSymbol = tokenNode.Value as OperatorSymbol;
                                switch (operatorSymbol.Category)
                                {
                                    case OperatorCategory.Reference:
                                        switch (operatorSymbol.SymbolType)
                                        {
                                            case OperatorType.QualifiedAlias:
                                            case OperatorType.Pointer:
                                            case OperatorType.MemberAccess:
                                                this.CheckMemberAccessSymbol(tokens, tokenNode);
                                                break;

                                            case OperatorType.AddressOf:
                                            case OperatorType.Dereference:
                                                this.CheckUnsafeAccessSymbols(tokenNode, type, parentTokenNode);
                                                break;

                                            default:
                                                Debug.Fail("Unexpected operator category.");
                                                break;
                                        }

                                        break;

                                    case OperatorCategory.Arithmetic:
                                    case OperatorCategory.Assignment:
                                    case OperatorCategory.Conditional:
                                    case OperatorCategory.Logical:
                                    case OperatorCategory.Relational:
                                    case OperatorCategory.Shift:
                                    case OperatorCategory.Lambda:

                                        // Symbols should have whitespace on both sides except null conditional '?.'
                                        this.CheckSymbol(tokens, tokenNode);
                                        break;

                                    case OperatorCategory.IncrementDecrement:
                                        this.CheckIncrementDecrement(tokenNode);
                                        break;

                                    case OperatorCategory.Unary:
                                        if (operatorSymbol.SymbolType == OperatorType.Negative)
                                        {
                                            this.CheckPositiveOrNegativeSign(tokenNode, false);
                                        }
                                        else if (operatorSymbol.SymbolType == OperatorType.Positive)
                                        {
                                            this.CheckPositiveOrNegativeSign(tokenNode, true);
                                        }
                                        else
                                        {
                                            this.CheckUnarySymbol(tokens, tokenNode);
                                        }

                                        break;
                                }

                                break;
                        }

                        switch (tokenNode.Value.CsTokenClass)
                        {
                            case CsTokenClass.ConstructorConstraint:
                                this.CheckSpacing(((ConstructorConstraint)tokenNode.Value).ChildTokens, false, tokenNode);
                                break;

                            case CsTokenClass.GenericType:
                                this.CheckGenericSpacing(tokens, tokenNode);
                                goto case CsTokenClass.Type;

                            case CsTokenClass.Type:
                                this.CheckSpacing(((TypeToken)tokenNode.Value).ChildTokens, true, tokenNode);
                                break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Checks a symbol for spacing.
        /// </summary>
        /// <param name="tokens">
        /// The list of tokens being parsed.
        /// </param>
        /// <param name="tokenNode">
        /// The token to check.
        /// </param>
        private void CheckSymbol(MasterList<CsToken> tokens, Node<CsToken> tokenNode)
        {
            Param.AssertNotNull(tokens, "tokens");
            Param.AssertNotNull(tokenNode, "tokenNode");

            OperatorSymbol operatorSymbol = tokenNode.Value as OperatorSymbol;
            if (operatorSymbol != null && operatorSymbol.SymbolType == OperatorType.NullConditional)
            {
                // Symbols should not have whitespace on both sides for operator '?.'.
                Node<CsToken> previousNode = tokenNode.Previous;
                if (previousNode != null && previousNode.Value.CsTokenType == CsTokenType.WhiteSpace)
                {
                    while (previousNode != null && previousNode.Value.CsTokenType != CsTokenType.EndOfLine)
                    {
                        if (previousNode.Value.CsTokenType != CsTokenType.WhiteSpace)
                        {
                            this.AddViolation(tokenNode.Value.FindParentElement(), tokenNode.Value.Location, Rules.SymbolsMustBeSpacedCorrectly, tokenNode.Value.Text);
                            break;
                        }

                        previousNode = previousNode.Previous;
                    }
                }

                Node<CsToken> nextNode = tokenNode.Next;
                if (nextNode != null && nextNode.Value.CsTokenType == CsTokenType.WhiteSpace)
                {
                    while (nextNode != null && nextNode.Value.CsTokenType != CsTokenType.EndOfLine)
                    {
                        if (nextNode.Value.CsTokenType != CsTokenType.WhiteSpace)
                        {
                            this.AddViolation(tokenNode.Value.FindParentElement(), tokenNode.Value.Location, Rules.SymbolsMustBeSpacedCorrectly, tokenNode.Value.Text);
                            break;
                        }

                        nextNode = nextNode.Next;
                    }
                }

                if (operatorSymbol.Text.Length > 2 || operatorSymbol.Text.Contains("\r") || operatorSymbol.Text.Contains("\n") || operatorSymbol.Text.Contains(" "))
                {
                    this.AddViolation(tokenNode.Value.FindParentElement(), tokenNode.Value.Location, Rules.DoNotSplitNullConditionalOperators, tokenNode.Value.Text);
                }
            }
            else
            {
                // Symbols should have whitespace on both sides.
                Node<CsToken> previousNode = tokenNode.Previous;
                if (previousNode != null && previousNode.Value.CsTokenType != CsTokenType.WhiteSpace && previousNode.Value.CsTokenType != CsTokenType.EndOfLine)
                {
                    this.AddViolation(tokenNode.Value.FindParentElement(), tokenNode.Value.Location, Rules.SymbolsMustBeSpacedCorrectly, tokenNode.Value.Text);
                }

                Node<CsToken> nextNode = tokenNode.Next;
                if (nextNode != null && nextNode.Value.CsTokenType != CsTokenType.WhiteSpace && nextNode.Value.CsTokenType != CsTokenType.EndOfLine)
                {
                    // Make sure the previous token is not operator.
                    if (previousNode != null)
                    {
                        foreach (CsToken item in tokens.ReverseIterator(previousNode))
                        {
                            if (item.CsTokenType == CsTokenType.Operator)
                            {
                                return;
                            }
                            else if (item.CsTokenType != CsTokenType.WhiteSpace && item.CsTokenType != CsTokenType.EndOfLine
                                     && item.CsTokenType != CsTokenType.SingleLineComment && item.CsTokenType != CsTokenType.MultiLineComment
                                     && item.CsTokenType != CsTokenType.PreprocessorDirective)
                            {
                                break;
                            }
                        }
                    }

                    this.AddViolation(tokenNode.Value.FindParentElement(), tokenNode.Value.LineNumber, Rules.SymbolsMustBeSpacedCorrectly, tokenNode.Value.Text);
                }
            }
        }

        /// <summary>
        /// Checks for tabs in the given comment.
        /// </summary>
        /// <param name="comment">
        /// The comment token.
        /// </param>
        private void CheckTabsInComment(CsToken comment)
        {
            Param.AssertNotNull(comment, "comment");

            int lineEnds = 0;

            for (int i = 0; i < comment.Text.Length; ++i)
            {
                if (comment.Text[i] == '\t')
                {
                    this.AddViolation(comment.FindParentElement(), comment.Location, Rules.TabsMustNotBeUsed);
                }
                else if (comment.Text[i] == '\n')
                {
                    ++lineEnds;
                }
            }
        }

        /// <summary>
        /// Checks a unary symbol for spacing.
        /// </summary>
        /// <param name="tokens">
        /// The master list of tokens.
        /// </param>
        /// <param name="tokenNode">
        /// The token to check.
        /// </param>
        private void CheckUnarySymbol(MasterList<CsToken> tokens, Node<CsToken> tokenNode)
        {
            Param.AssertNotNull(tokens, "tokens");
            Param.AssertNotNull(tokenNode, "tokenNode");

            // These symbols should be preceded by whitespace but not followed by whitespace. They can
            // also be preceded by an open paren or an open square bracket.
            Node<CsToken> previousNode = tokenNode.Previous;
            if (previousNode != null)
            {
                CsTokenType previousNodeTokenType = previousNode.Value.CsTokenType;
                if (previousNodeTokenType != CsTokenType.WhiteSpace && previousNodeTokenType != CsTokenType.EndOfLine
                    && previousNodeTokenType != CsTokenType.OpenParenthesis && previousNodeTokenType != CsTokenType.OpenSquareBracket
                    && previousNodeTokenType != CsTokenType.CloseParenthesis)
                {
                    this.AddViolation(tokenNode.Value.FindParentElement(), tokenNode.Value.Location, Rules.SymbolsMustBeSpacedCorrectly, tokenNode.Value.Text);
                }

                // They should not be preceded by whitespace if the whitespace is preceded by a paranthesis.
                if (previousNodeTokenType == CsTokenType.WhiteSpace || previousNodeTokenType == CsTokenType.EndOfLine)
                {
                    foreach (CsToken item in tokens.ReverseIterator(previousNode))
                    {
                        if (item.CsTokenType == CsTokenType.OpenParenthesis || item.CsTokenType == CsTokenType.OpenSquareBracket)
                        {
                            this.AddViolation(tokenNode.Value.FindParentElement(), tokenNode.Value.Location, Rules.SymbolsMustBeSpacedCorrectly, tokenNode.Value.Text);
                        }
                        else if (item.CsTokenType == CsTokenType.WhiteSpace)
                        {
                            continue;
                        }

                        if (item.CsTokenType != CsTokenType.OpenParenthesis && item.CsTokenType != CsTokenType.OpenSquareBracket
                            && item.CsTokenType != CsTokenType.WhiteSpace)
                        {
                            break;
                        }
                    }
                }
            }

            Node<CsToken> nextNode = tokenNode.Next;
            if (nextNode != null)
            {
                CsTokenType tokenType = nextNode.Value.CsTokenType;
                if (tokenType == CsTokenType.WhiteSpace || tokenType == CsTokenType.EndOfLine || tokenType == CsTokenType.SingleLineComment
                    || tokenType == CsTokenType.MultiLineComment)
                {
                    this.AddViolation(tokenNode.Value.FindParentElement(), tokenNode.Value.Location, Rules.SymbolsMustBeSpacedCorrectly, tokenNode.Value.Text);
                }
            }
        }

        /// <summary>
        /// Checks an unsafe pointer access symbol sign for spacing.
        /// </summary>
        /// <param name="tokenNode">
        /// The token to check.
        /// </param>
        /// <param name="type">
        /// Indicates whether the token is part of a type declaration.
        /// </param>
        /// <param name="parentTokenNode">
        /// The parent token of the token node being checked.
        /// </param>
        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Minimizing refactoring before release.")]
        private void CheckUnsafeAccessSymbols(Node<CsToken> tokenNode, bool type, Node<CsToken> parentTokenNode)
        {
            Param.AssertNotNull(tokenNode, "tokenNode");
            Param.Ignore(type);

            // In a type declaration, the symbol must have whitespace on the right but
            // not on the left. If this is not a type declaration, the opposite is true.
            if (type)
            {
                // The symbol should be followed by whitespace. It 
                // can also be followed by a closing paren or a closing bracket,
                // or another token of the same type.
                bool addViolation = false;

                Node<CsToken> nextNode = tokenNode.Next ?? parentTokenNode.Next;
                if (nextNode == null)
                {
                    addViolation = true;
                }
                else
                {
                    CsTokenType tokenType = nextNode.Value.CsTokenType;
                    if (tokenType != CsTokenType.WhiteSpace && tokenType != CsTokenType.EndOfLine && tokenType != CsTokenType.OpenParenthesis
                        && tokenType != CsTokenType.OpenSquareBracket && tokenType != CsTokenType.CloseParenthesis && tokenType != tokenNode.Value.CsTokenType)
                    {
                        addViolation = true;
                    }
                }

                if (addViolation)
                {
                    this.AddViolation(tokenNode.Value.FindParentElement(), tokenNode.Value.Location, Rules.DereferenceAndAccessOfSymbolsMustBeSpacedCorrectly);
                }

                // The symbol must not be preceded by whitespace.
                Node<CsToken> previousNode = tokenNode.Previous;
                if (previousNode != null)
                {
                    CsTokenType tokenType = previousNode.Value.CsTokenType;
                    if (tokenType == CsTokenType.WhiteSpace || tokenType == CsTokenType.EndOfLine || tokenType == CsTokenType.SingleLineComment
                        || tokenType == CsTokenType.MultiLineComment)
                    {
                        this.AddViolation(tokenNode.Value.FindParentElement(), tokenNode.Value.Location, Rules.DereferenceAndAccessOfSymbolsMustBeSpacedCorrectly);
                    }
                }
            }
            else
            {
                // The symbol should be preceded by whitespace. It 
                // can also be preceded by an open paren or an open bracket, or
                // another token of the same type.
                bool addViolation = false;
                Node<CsToken> previousNode = tokenNode.Previous;
                if (previousNode == null)
                {
                    addViolation = true;
                }
                else
                {
                    CsTokenType tokenType = previousNode.Value.CsTokenType;
                    if (tokenType != CsTokenType.WhiteSpace && tokenType != CsTokenType.EndOfLine && tokenType != CsTokenType.OpenParenthesis
                        && tokenType != CsTokenType.OpenSquareBracket && tokenType != CsTokenType.CloseParenthesis && tokenType != tokenNode.Value.CsTokenType)
                    {
                        addViolation = true;
                    }
                }

                if (addViolation)
                {
                    this.AddViolation(tokenNode.Value.FindParentElement(), tokenNode.Value.Location, Rules.DereferenceAndAccessOfSymbolsMustBeSpacedCorrectly);
                }

                // The symbol must not be followed by whitespace.
                Node<CsToken> nextNode = tokenNode.Next;
                if (nextNode != null)
                {
                    CsTokenType tokenType = nextNode.Value.CsTokenType;
                    if (tokenType == CsTokenType.WhiteSpace || tokenType == CsTokenType.EndOfLine || tokenType == CsTokenType.SingleLineComment
                        || tokenType == CsTokenType.MultiLineComment)
                    {
                        this.AddViolation(tokenNode.Value.FindParentElement(), tokenNode.Value.Location, Rules.DereferenceAndAccessOfSymbolsMustBeSpacedCorrectly);
                    }
                }
            }
        }

        /// <summary>
        /// Checks to make sure that there is not too many whitespace symbols in a row.
        /// </summary>
        /// <param name="tokenNode">
        /// The whitespace to check.
        /// </param>
        private void CheckWhitespace(Node<CsToken> tokenNode)
        {
            Param.AssertNotNull(tokenNode, "tokenNode");

            Whitespace whitespace = (Whitespace)tokenNode.Value;

            if (whitespace.TabCount > 0)
            {
                // Tabs are not allowed.
                ICodeElement parentElement = tokenNode.Value.FindParentElement();

                if (parentElement != null)
                {
                    this.AddViolation(parentElement, whitespace.Location, Rules.TabsMustNotBeUsed);
                }
            }
            else if (whitespace.TabCount == 0 && whitespace.SpaceCount > 1)
            {
                // Multiple spaces in a row are only allowed at the beginning of a line, following 
                // a comma or semicolon, preceding a symbol, or at the end of a line.
                Node<CsToken> nextNode = tokenNode.Next;
                Node<CsToken> previousNode = tokenNode.Previous;
                if (previousNode != null && previousNode.Value.CsTokenType != CsTokenType.EndOfLine && previousNode.Value.CsTokenType != CsTokenType.Comma
                    && previousNode.Value.CsTokenType != CsTokenType.Semicolon && nextNode != null && nextNode.Value.CsTokenType != CsTokenType.OperatorSymbol
                    && nextNode.Value.CsTokenType != CsTokenType.EndOfLine && nextNode.Value.CsTokenType != CsTokenType.SingleLineComment
                    && nextNode.Value.CsTokenType != CsTokenType.MultiLineComment)
                {
                    CsElement parentElement = tokenNode.Value.FindParentElement() ?? previousNode.Value.FindParentElement();
                    if (parentElement != null)
                    {
                        this.AddViolation(parentElement, whitespace.Location, Rules.CodeMustNotContainMultipleWhitespaceInARow);
                    }
                }
            }
        }

        /// <summary>
        /// Checks to make sure that the slashes in in the Xml header are followed by a space.
        /// </summary>
        /// <param name="header">
        /// The Xml header token.
        /// </param>
        private void CheckXmlHeaderComment(XmlHeader header)
        {
            Param.AssertNotNull(header, "header");

            for (Node<CsToken> tokenNode = header.ChildTokens.First; tokenNode != null; tokenNode = tokenNode.Next)
            {
                CsToken token = tokenNode.Value;

                if (token.CsTokenType == CsTokenType.XmlHeaderLine)
                {
                    if (token.Text.Length > 3)
                    {
                        if (token.Text[3] != ' ' && token.Text[3] != '\t' && token.Text[3] != '/' && token.Text[2] != '\n' && token.Text[2] != '\r')
                        {
                            // The header line does not start with any spaces.
                            this.AddViolation(tokenNode.Value.FindParentElement(), token.Location, Rules.DocumentationLinesMustBeginWithSingleSpace);
                        }
                        else if (token.Text.Length > 4 && (token.Text[4] == ' ' || token.Text[4] == '\t'))
                        {
                            // The header line starts with more than one space. This is only allowed when the 
                            // header line is not the first or last line in the header.
                            bool error = true;
                            for (Node<CsToken> previous = tokenNode.Previous; previous != null; previous = previous.Previous)
                            {
                                if (previous.Value.CsTokenType == CsTokenType.XmlHeaderLine)
                                {
                                    for (Node<CsToken> next = tokenNode.Next; next != null; next = next.Next)
                                    {
                                        if (next.Value.CsTokenType == CsTokenType.XmlHeaderLine)
                                        {
                                            error = false;
                                            break;
                                        }
                                    }

                                    break;
                                }
                            }

                            if (error)
                            {
                                this.AddViolation(token.FindParentElement(), token.Location, Rules.DocumentationLinesMustBeginWithSingleSpace);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Checks to see if the passed in node is the first node on its line.
        /// </summary>
        /// <param name="tokens">
        /// The master list of tokens.
        /// </param>
        /// <param name="node">
        /// The node to check.
        /// </param>
        /// <returns>
        /// True if this node is the first on the line, otherwise false.
        /// </returns>
        private bool IsTokenFirstNonWhitespaceTokenOnLine(MasterList<CsToken> tokens, Node<CsToken> node)
        {
            Param.AssertNotNull(tokens, "tokens");
            Param.AssertNotNull(node, "node");

            Node<CsToken> previousNode = node.Previous;
            if (previousNode == null)
            {
                return true;
            }

            bool returnValue = true;
            foreach (CsToken item in tokens.ReverseIterator(previousNode))
            {
                if (item.LineNumber != node.Value.LineNumber)
                {
                    break;
                }

                if (item.CsTokenType != CsTokenType.WhiteSpace)
                {
                    returnValue = false;
                    break;
                }
            }

            return returnValue;
        }

        #endregion
    }
}