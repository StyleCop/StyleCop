//-----------------------------------------------------------------------
// <copyright file="SpacingRules.cs">
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
//-----------------------------------------------------------------------
namespace StyleCop.CSharp
{
    using System;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using StyleCop;

    /// <summary>
    /// Tracks spacing in a piece of code.
    /// </summary>
    [SourceAnalyzer(typeof(CsParser))]
    public class SpacingRules : SourceAnalyzer
    {
        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the SpacingRules class.
        /// </summary>
        public SpacingRules()
        {
        }

        #endregion Public Constructors

        #region Public Override Methods

        /// <summary>
        /// Checks the spacing of items within the given document.
        /// </summary>
        /// <param name="document">The document to check.</param>
        public override void AnalyzeDocument(CodeDocument document)
        {
            Param.RequireNotNull(document, "document");

            CsDocument csdocument = (CsDocument)document;

            if (csdocument.RootElement != null && !csdocument.RootElement.Generated)
            {
                this.CheckSpacing(csdocument.Tokens, false);
            }
        }

        /// <inheritdoc />
        public override bool DoAnalysis(CodeDocument document)
        {
            Param.RequireNotNull(document, "document");

            CsDocument csdocument = (CsDocument)document;

            return csdocument.FileHeader == null || !csdocument.FileHeader.UnStyled;
        }

        #endregion Public Override Methods

        #region Private Static Methods

        /// <summary>
        /// Determines whether the type of the given token is allowed
        /// to appear after a closing parenthesis, with no space between
        /// the parenthesis and the token.
        /// </summary>
        /// <param name="token">The token to check.</param>
        /// <returns>True if it is allowed; false otherwise.</returns>
        private static bool IsAllowedAfterClosingParenthesis(CsToken token)
        {
            Param.AssertNotNull(token, "token");

            CsTokenType type = token.CsTokenType;

            if (type == CsTokenType.CloseParenthesis ||
                type == CsTokenType.OpenParenthesis ||
                type == CsTokenType.CloseSquareBracket ||
                type == CsTokenType.OpenSquareBracket ||
                type == CsTokenType.CloseAttributeBracket ||
                type == CsTokenType.Semicolon ||
                type == CsTokenType.Comma)
            {
                return true;
            }
            else if (type == CsTokenType.OperatorSymbol)
            {
                OperatorSymbol symbol = (OperatorSymbol)token;
                if (symbol.SymbolType == OperatorType.Decrement ||
                    symbol.SymbolType == OperatorType.Increment ||
                    symbol.SymbolType == OperatorType.MemberAccess ||
                    symbol.SymbolType == OperatorType.Pointer)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Compares the token to the Operator symbol and to a dot '.'.
        /// </summary>
        /// <param name="token">The token to check.</param>
        /// <returns>True is the token is an operator and a dot '.', otherwise false.</returns>
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

        #endregion Private Static Methods

        #region Private Methods

        /// <summary>
        /// Checks the spacing of a root.
        /// </summary>
        /// <param name="tokens">The list of tokens.</param>
        /// <param name="type">Indicates whether the tokens are part of a type declaration.</param>
        [SuppressMessage("Microsoft.Maintainability", "CA1505:AvoidUnmaintainableCode", Justification = "Minimizing refactoring before release.")]
        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Minimizing refactoring before release.")]
        private void CheckSpacing(MasterList<CsToken> tokens, bool type)
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
                            case CsTokenType.Catch:
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
                                this.CheckSemicolonAndComma(tokenNode);
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
                                this.CheckCloseSquareBracket(tokens, tokenNode);
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
                                this.CheckAttributeTokenCloseBracket(tokenNode);
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
                                StyleCop.CSharp.Attribute attribute = tokenNode.Value as StyleCop.CSharp.Attribute;
                                this.CheckSpacing(attribute.ChildTokens, false);
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
                                                this.CheckUnsafeAccessSymbols(tokenNode, type);
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
                                        // Symbols should have whitespace on both sides
                                        this.CheckSymbol(tokens, tokenNode);
                                        break;

                                    case OperatorCategory.IncrementDecrement:
                                        this.CheckIncrementDecrement(tokenNode);
                                        break;

                                    case OperatorCategory.Unary:
                                        if (operatorSymbol.SymbolType == OperatorType.Negative)
                                        {
                                            this.CheckNegativeSign(tokenNode);
                                        }
                                        else if (operatorSymbol.SymbolType == OperatorType.Positive)
                                        {
                                            this.CheckPositiveSign(tokenNode);
                                        }
                                        else
                                        {
                                            this.CheckUnarySymbol(tokenNode);
                                        }

                                        break;
                                }

                                break;
                        }

                        switch (tokenNode.Value.CsTokenClass)
                        {
                            case CsTokenClass.ConstructorConstraint:
                                this.CheckSpacing(((ConstructorConstraint)tokenNode.Value).ChildTokens, false);
                                break;

                            case CsTokenClass.GenericType:
                                this.CheckGenericSpacing(tokenNode.Value as GenericType);
                                goto case CsTokenClass.Type;

                            case CsTokenClass.Type:
                                this.CheckSpacing(((TypeToken)tokenNode.Value).ChildTokens, true);
                                break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Checks the spacing of the tokens within the given generic type token.
        /// </summary>
        /// <param name="generic">The generic type token to check.</param>
        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Minimizing refactoring before release.")]
        private void CheckGenericSpacing(GenericType generic)
        {
            Param.AssertNotNull(generic, "generic");

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
                        this.CheckGenericSpacing(tokenNode.Value as GenericType);
                    }

                    if (!tokenNode.Value.Generated)
                    {
                        switch (tokenNode.Value.CsTokenType)
                        {
                            case CsTokenType.Comma:
                                this.CheckSemicolonAndComma(tokenNode);
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
                                this.CheckCloseSquareBracket(generic.ChildTokens, tokenNode);
                                break;

                            case CsTokenType.WhiteSpace:
                                this.CheckWhitespace(tokenNode);
                                break;

                            case CsTokenType.OpenGenericBracket:
                                this.CheckGenericTokenOpenBracket(tokenNode);
                                break;

                            case CsTokenType.CloseGenericBracket:
                                this.CheckGenericTokenCloseBracket(tokenNode);
                                break;

                            case CsTokenType.PreprocessorDirective:
                                this.CheckPreprocessorSpacing(tokenNode.Value);
                                break;

                            case CsTokenType.OperatorSymbol:
                                OperatorSymbol symbol = tokenNode.Value as OperatorSymbol;
                                if (symbol.SymbolType == OperatorType.MemberAccess ||
                                    symbol.SymbolType == OperatorType.QualifiedAlias)
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
        /// Checks a keyword that should be followed by a space.
        /// </summary>
        /// <param name="tokenNode">The token node to check.</param>
        private void CheckKeywordWithSpace(Node<CsToken> tokenNode)
        {
            Param.AssertNotNull(tokenNode, "tokenNode");

            // Keywords must be followed by a space before the open parenthesis.
            // Sometimes keywords appear within attributes and are allowed to be
            // followed immediately by an attribute colon.
            Node<CsToken> temp = tokenNode.Next;
            if (temp == null ||
                (temp.Value.CsTokenType != CsTokenType.WhiteSpace &&
                temp.Value.CsTokenType != CsTokenType.EndOfLine &&
                temp.Value.CsTokenType != CsTokenType.Semicolon &&
                temp.Value.CsTokenType != CsTokenType.AttributeColon))
            {
                this.AddViolation(
                    tokenNode.Value.FindParentElement(), 
                    tokenNode.Value.LineNumber, 
                    Rules.KeywordsMustBeSpacedCorrectly, 
                    tokenNode.Value.Text);
            }
        }

        /// <summary>
        /// Checks a keyword that should not be followed by a space.
        /// </summary>
        /// <param name="tokens">The list of tokens being parsed.</param>
        /// <param name="tokenNode">The token to check.</param>
        private void CheckKeywordWithoutSpace(MasterList<CsToken> tokens, Node<CsToken> tokenNode)
        {
            Param.AssertNotNull(tokens, "tokens");
            Param.AssertNotNull(tokenNode, "tokenNode");

            // Keywords must not contain any space before the open parenthesis.
            Node<CsToken> temp = tokenNode.Next;
            if (temp != null &&
                (temp.Value.CsTokenType == CsTokenType.WhiteSpace || temp.Value.CsTokenType == CsTokenType.EndOfLine))
            {
                // Make sure the next non-whitespace character is not an open parenthesis.
                foreach (CsToken nextNonWhitespaceToken in tokens.ForwardIterator(temp.Next))
                {
                    if (nextNonWhitespaceToken.CsTokenType == CsTokenType.OpenParenthesis)
                    {
                        this.AddViolation(tokenNode.Value.FindParentElement(), tokenNode.Value.LineNumber, Rules.KeywordsMustBeSpacedCorrectly, tokenNode.Value.Text);

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
        /// Checks the spacing around a 'new' keyword.
        /// </summary>
        /// <param name="tokens">The token list.</param>
        /// <param name="tokenNode">The token node to check.</param>
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
                            this.AddViolation(tokenNode.Value.FindParentElement(), tokenNode.Value.LineNumber, Rules.CodeMustNotContainSpaceAfterNewKeywordInImplicitlyTypedArrayAllocation);
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
                    this.AddViolation(tokenNode.Value.FindParentElement(), tokenNode.Value.LineNumber, Rules.KeywordsMustBeSpacedCorrectly, tokenNode.Value.Text);
                }
            }
        }

        /// <summary>
        /// Checks a semicolon or comma for spacing.
        /// </summary>
        /// <param name="tokenNode">The token node to check.</param>
        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Minimizing refactoring before release.")]
        private void CheckSemicolonAndComma(Node<CsToken> tokenNode)
        {
            Param.AssertNotNull(tokenNode, "tokenNode");

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
            string[] open = new string[] { "[", "<" };
            string[] close = new string[] { "]", ">" };

            if (!comma)
            {
                open = new string[] { "(" };
                close = new string[] { ")" };
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
                if (previousNode != null &&
                    (previousNode.Value.CsTokenType == CsTokenType.WhiteSpace || previousNode.Value.CsTokenType == CsTokenType.EndOfLine))
                {
                    this.AddViolation(
                        tokenNode.Value.FindParentElement(), 
                        tokenNode.Value.LineNumber, 
                        comma ? Rules.CommasMustBeSpacedCorrectly : Rules.SemicolonsMustBeSpacedCorrectly);
                }
            }

            if (!specialCaseForwards)
            {
                Node<CsToken> nextNode = tokenNode.Next;

                // Make sure this is followed by whitespace or a close paren.
                if (nextNode != null &&
                    nextNode.Value.CsTokenType != CsTokenType.WhiteSpace &&
                    nextNode.Value.CsTokenType != CsTokenType.EndOfLine &&
                    nextNode.Value.CsTokenType != CsTokenType.CloseParenthesis)
                {
                    this.AddViolation(
                        tokenNode.Value.FindParentElement(), 
                        tokenNode.Value.LineNumber, 
                        comma ? Rules.CommasMustBeSpacedCorrectly : Rules.SemicolonsMustBeSpacedCorrectly);
                }
            }
        }

        /// <summary>
        /// Checks a symbol for spacing.
        /// </summary>
        /// <param name="tokens">The list of tokens being parsed.</param>
        /// <param name="tokenNode">The token to check.</param>
        private void CheckSymbol(MasterList<CsToken> tokens, Node<CsToken> tokenNode)
        {
            Param.AssertNotNull(tokens, "tokens");
            Param.AssertNotNull(tokenNode, "tokenNode");

            // Symbols should have whitespace on both sides.
            Node<CsToken> previousNode = tokenNode.Previous;
            if (previousNode != null &&
                previousNode.Value.CsTokenType != CsTokenType.WhiteSpace &&
                previousNode.Value.CsTokenType != CsTokenType.EndOfLine)
            {
                this.AddViolation(tokenNode.Value.FindParentElement(), tokenNode.Value.LineNumber, Rules.SymbolsMustBeSpacedCorrectly, tokenNode.Value.Text);
            }

            Node<CsToken> nextNode = tokenNode.Next;
            if (nextNode != null &&
                nextNode.Value.CsTokenType != CsTokenType.WhiteSpace &&
                nextNode.Value.CsTokenType != CsTokenType.EndOfLine)
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
                        else if (item.CsTokenType != CsTokenType.WhiteSpace &&
                            item.CsTokenType != CsTokenType.EndOfLine &&
                            item.CsTokenType != CsTokenType.SingleLineComment &&
                            item.CsTokenType != CsTokenType.MultiLineComment &&
                            item.CsTokenType != CsTokenType.PreprocessorDirective)
                        {
                            break;
                        }
                    }
                }

                this.AddViolation(tokenNode.Value.FindParentElement(), tokenNode.Value.LineNumber, Rules.SymbolsMustBeSpacedCorrectly, tokenNode.Value.Text);
            }
        }

        /// <summary>
        /// Checks to make sure that the slashes in in the Xml header are followed by a space.
        /// </summary>
        /// <param name="header">The Xml header token.</param>
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
                        if (token.Text[3] != ' ' &&
                            token.Text[3] != '\t' &&
                            token.Text[3] != '/' &&
                            token.Text[2] != '\n' &&
                            token.Text[2] != '\r')
                        {
                            // The header line does not start with any spaces.
                            this.AddViolation(tokenNode.Value.FindParentElement(), token.LineNumber, Rules.DocumentationLinesMustBeginWithSingleSpace);
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
                                this.AddViolation(token.FindParentElement(), token.LineNumber, Rules.DocumentationLinesMustBeginWithSingleSpace);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Checks to make sure that the slashes in in the comment are followed by a space.
        /// </summary>
        /// <param name="tokens">The list of tokens being parsed.</param>
        /// <param name="tokenNode">The comment token.</param>
        private void CheckSingleLineComment(MasterList<CsToken> tokens, Node<CsToken> tokenNode)
        {
            Param.AssertNotNull(tokens, "tokens");
            Param.AssertNotNull(tokenNode, "tokenNode");

            // If the token length is less then two, this is not a valid comment so just ignore it.
            if (tokenNode.Value.Text.Length > 2)
            {
                // The first character in the comment must be a space, except for the following four cases:
                // 1. The comment may start with three or more slashes: ///whatever
                // 2. The command may start with a backwards slash: //\whatever
                // 3. The comment may start with a dash if there are at last two dashes: //--
                // 4. The character after the second slash may be a newline character.
                string text = tokenNode.Value.Text;
                if (text[2] != ' ' &&
                    text[2] != '\t' &&
                    text[2] != '/' &&
                    text[2] != '\\' &&
                    text[1] != '\n' &&
                    text[1] != '\r' &&
                    (text.Length < 4 || text[2] != '-' || text[3] != '-'))
                {
                    // The comment does not start with a single space.
                    this.AddViolation(tokenNode.Value.FindParentElement(), tokenNode.Value.LineNumber, Rules.SingleLineCommentsMustBeginWithSingleSpace);
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
                        this.AddViolation(tokenNode.Value.FindParentElement(), tokenNode.Value.LineNumber, Rules.SingleLineCommentsMustBeginWithSingleSpace);
                    }
                }
            }
        }

        /// <summary>
        /// Checks to make sure that preprocessor type keyword is not preceded by a space.
        /// </summary>
        /// <param name="preprocessor">The preprocessor token.</param>
        private void CheckPreprocessorSpacing(CsToken preprocessor)
        {
            Param.AssertNotNull(preprocessor, "preprocessor");

            if (preprocessor.Text.Length > 1)
            {
                if (preprocessor.Text[0] == '#')
                {
                    if (preprocessor.Text[1] == ' ' || preprocessor.Text[1] == '\t')
                    {
                        this.AddViolation(preprocessor.FindParentElement(), preprocessor.LineNumber, Rules.PreprocessorKeywordsMustNotBePrecededBySpace);
                    }
                }
            }
        }

        /// <summary>
        /// Checks the operator keyword for spacing.
        /// </summary>
        /// <param name="tokenNode">The token to check.</param>
        private void CheckOperatorKeyword(Node<CsToken> tokenNode)
        {
            Param.AssertNotNull(tokenNode, "tokenNode");

            // Operator keywords should be followed by whitespace.
            Node<CsToken> next = tokenNode.Next;
            if (next != null && next.Value.CsTokenType != CsTokenType.WhiteSpace)
            {
                this.AddViolation(tokenNode.Value.FindParentElement(), tokenNode.Value.LineNumber, Rules.OperatorKeywordMustBeFollowedBySpace);
            }
        }

        /// <summary>
        /// Checks an open parenthesis for spacing.
        /// </summary>
        /// <param name="tokens">The list of tokens being parsed.</param>
        /// <param name="tokenNode">The token to check.</param>
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
                        else if (itemType == CsTokenType.EndOfLine)
                        {
                            firstOnLine = true;
                            break;
                        }
                        else if (
                            itemType == CsTokenType.Case ||
                            itemType == CsTokenType.Catch ||
                            itemType == CsTokenType.CloseSquareBracket ||
                            itemType == CsTokenType.Comma ||
                            itemType == CsTokenType.Equals ||
                            itemType == CsTokenType.Fixed ||
                            itemType == CsTokenType.For ||
                            itemType == CsTokenType.Foreach ||
                            itemType == CsTokenType.From ||
                            ////itemType == CsTokenType.Goto ||
                            itemType == CsTokenType.Group ||
                            itemType == CsTokenType.If ||
                            itemType == CsTokenType.In ||
                            itemType == CsTokenType.Into ||
                            itemType == CsTokenType.Join ||
                            itemType == CsTokenType.Let ||
                            itemType == CsTokenType.Lock ||
                            itemType == CsTokenType.MultiLineComment ||
                            ////itemType == CsTokenType.New ||
                            itemType == CsTokenType.Number ||
                            itemType == CsTokenType.OperatorSymbol ||
                            itemType == CsTokenType.OpenCurlyBracket ||
                            itemType == CsTokenType.OrderBy ||
                            itemType == CsTokenType.Return ||
                            itemType == CsTokenType.Select ||
                            itemType == CsTokenType.Semicolon ||
                            ////itemType == CsTokenType.SingleLineComment ||
                            itemType == CsTokenType.Switch ||
                            itemType == CsTokenType.Throw ||
                            itemType == CsTokenType.Using ||
                            itemType == CsTokenType.Where ||
                            itemType == CsTokenType.While ||
                            itemType == CsTokenType.WhileDo ||
                            itemType == CsTokenType.Yield ||
                            itemType == CsTokenType.LabelColon)
                        {
                            break;
                        }
                        else
                        {
                            this.AddViolation(tokenNode.Value.FindParentElement(), tokenNode.Value.LineNumber, Rules.OpeningParenthesisMustBeSpacedCorrectly);
                        }
                    }
                }
            }

            // Open parens should never be followed by whitespace unless
            // it is the last thing on the line.
            Node<CsToken> next = tokenNode.Next;
            if (next != null &&
                (next.Value.CsTokenType == CsTokenType.WhiteSpace || next.Value.CsTokenType == CsTokenType.EndOfLine))
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
                    else if (itemType != CsTokenType.WhiteSpace &&
                        itemType != CsTokenType.SingleLineComment &&
                        itemType != CsTokenType.MultiLineComment)
                    {
                        this.AddViolation(tokenNode.Value.FindParentElement(), tokenNode.Value.LineNumber, Rules.OpeningParenthesisMustBeSpacedCorrectly);
                        break;
                    }
                }
            }

            // Open parens cannot be the only thing on the line.
            if (firstOnLine && lastOnLine)
            {
                this.AddViolation(tokenNode.Value.FindParentElement(), tokenNode.Value.LineNumber, Rules.OpeningParenthesisMustBeSpacedCorrectly);
            }
        }

        /// <summary>
        /// Checks a close paren for spacing.
        /// </summary>
        /// <param name="tokens">The list of tokens being parsed.</param>
        /// <param name="tokenNode">The token to check.</param>
        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Minimizing refactoring before release.")]
        private void CheckCloseParen(MasterList<CsToken> tokens, Node<CsToken> tokenNode)
        {
            Param.AssertNotNull(tokens, "tokens");
            Param.AssertNotNull(tokenNode, "tokenNode");

            // Close parens should never be preceded by whitespace.
            Node<CsToken> previousNode = tokenNode.Previous;
            if (previousNode != null)
            {
                if (previousNode.Value.CsTokenType == CsTokenType.WhiteSpace || (previousNode.Value.CsTokenType == CsTokenType.EndOfLine && previousNode.Previous.Value.CsTokenType != CsTokenType.SingleLineComment))
                {
                    this.AddViolation(tokenNode.Value.FindParentElement(), tokenNode.Value.LineNumber, Rules.ClosingParenthesisMustBeSpacedCorrectly);
                }
            }

            // Find out what comes after the closing paren.
            Node<CsToken> nextNode = tokenNode.Next;

            if (nextNode != null)
            {
                CsTokenType nextType = nextNode.Value.CsTokenType;
                CsTokenType nextNextType = nextNode.Next == null ? CsTokenType.Other : nextNode.Next.Value.CsTokenType;

                if (tokenNode.Value.Parent is CastExpression)
                {
                    // There should not be any whitespace after the closing parenthesis in a cast expression.
                    if (nextType == CsTokenType.WhiteSpace)
                    {
                        this.AddViolation(tokenNode.Value.FindParentElement(), tokenNode.Value.LineNumber, Rules.ClosingParenthesisMustBeSpacedCorrectly);
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

                    if ((followsCase && nextType == CsTokenType.WhiteSpace) ||
                        (!followsCase && nextType != CsTokenType.WhiteSpace))
                    {
                        this.AddViolation(tokenNode.Value.FindParentElement(), tokenNode.Value.LineNumber, Rules.ClosingParenthesisMustBeSpacedCorrectly);
                    }
                }
                else if (nextType == CsTokenType.WhiteSpace)
                {
                    // Make sure that the character just after the whitespace is not a paren, bracket, a comma, or a semicolon.
                    foreach (CsToken item in tokens.ForwardIterator(tokenNode.Next.Next))
                    {
                        if (IsAllowedAfterClosingParenthesis(item))
                        {
                            this.AddViolation(tokenNode.Value.FindParentElement(), tokenNode.Value.LineNumber, Rules.ClosingParenthesisMustBeSpacedCorrectly);
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
                    if (nextNode.Value.CsTokenType != CsTokenType.EndOfLine &&
                        !IsAllowedAfterClosingParenthesis(nextNode.Value))
                    {
                        this.AddViolation(tokenNode.Value.FindParentElement(), tokenNode.Value.LineNumber, Rules.ClosingParenthesisMustBeSpacedCorrectly);
                    }
                }
            }
        }

        /// <summary>
        /// Checks a open bracket for spacing.
        /// </summary>
        /// <param name="tokenNode">The token to check.</param>
        private void CheckOpenSquareBracket(Node<CsToken> tokenNode)
        {
            Param.AssertNotNull(tokenNode, "tokenNode");

            // Open brackets should be never be preceded by whitespace.
            Node<CsToken> previousNode = tokenNode.Previous;
            if (previousNode != null)
            {
                if (previousNode.Value.CsTokenType == CsTokenType.WhiteSpace ||
                    previousNode.Value.CsTokenType == CsTokenType.EndOfLine)
                {
                    this.AddViolation(tokenNode.Value.FindParentElement(), tokenNode.Value.LineNumber, Rules.OpeningSquareBracketsMustBeSpacedCorrectly);
                }
            }

            // Open brackets should never be followed by whitespace.
            Node<CsToken> nextNode = tokenNode.Next;
            if (nextNode != null &&
                (nextNode.Value.CsTokenType == CsTokenType.WhiteSpace || nextNode.Value.CsTokenType == CsTokenType.EndOfLine))
            {
                this.AddViolation(tokenNode.Value.FindParentElement(), tokenNode.Value.LineNumber, Rules.OpeningSquareBracketsMustBeSpacedCorrectly);
            }
        }

        /// <summary>
        /// Checks a close bracket for spacing.
        /// </summary>
        /// <param name="tokens">The list of tokens being parsed.</param>
        /// <param name="tokenNode">The token to check.</param>
        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Minimizing refactoring before release.")]
        private void CheckCloseSquareBracket(MasterList<CsToken> tokens, Node<CsToken> tokenNode)
        {
            Param.AssertNotNull(tokens, "tokens");
            Param.AssertNotNull(tokenNode, "tokenNode");

            // Close brackets should never be preceded by whitespace.
            Node<CsToken> previousNode = tokenNode.Previous;
            if (previousNode != null &&
                (previousNode.Value.CsTokenType == CsTokenType.WhiteSpace || previousNode.Value.CsTokenType == CsTokenType.EndOfLine))
            {
                this.AddViolation(tokenNode.Value.FindParentElement(), tokenNode.Value.LineNumber, Rules.ClosingSquareBracketsMustBeSpacedCorrectly);
            }

            // Close brackets should be followed either by whitespace, a bracket,
            // a paren, a semicolon, a comma, a period, or an increment or decrement symbol.
            Node<CsToken> nextNode = tokenNode.Next;
            if (nextNode != null)
            {
                CsTokenType nextType = nextNode.Value.CsTokenType;
                if (nextType != CsTokenType.WhiteSpace &&
                    nextType != CsTokenType.EndOfLine &&
                    nextType != CsTokenType.CloseParenthesis &&
                    nextType != CsTokenType.OpenParenthesis &&      // someDictionary["Test"]();
                    nextType != CsTokenType.CloseSquareBracket &&   // someIndexer[someArray[1]] = 2;
                    nextType != CsTokenType.OpenSquareBracket &&    // someArray[1][2] = 2;
                    nextType != CsTokenType.Semicolon &&
                    nextType != CsTokenType.Comma &&
                    nextType != CsTokenType.CloseGenericBracket &&
                    nextNode.Value.Text != "++" &&
                    nextNode.Value.Text != "--" &&
                    !nextNode.Value.Text.StartsWith(".", StringComparison.Ordinal))
                {
                    this.AddViolation(tokenNode.Value.FindParentElement(), tokenNode.Value.LineNumber, Rules.ClosingSquareBracketsMustBeSpacedCorrectly);
                }

                if (nextType == CsTokenType.WhiteSpace)
                {
                    // If this is followed by whitespace, make sure that the character just
                    // after the whitespace is not a paren, bracket, comma, or semicolon.
                    foreach (CsToken item in tokens.ForwardIterator(tokenNode.Next.Next))
                    {
                        CsTokenType itemType = item.CsTokenType;
                        if (itemType == CsTokenType.CloseParenthesis ||
                            itemType == CsTokenType.OpenParenthesis ||
                            itemType == CsTokenType.CloseSquareBracket ||
                            itemType == CsTokenType.OpenSquareBracket ||
                            itemType == CsTokenType.Semicolon ||
                            itemType == CsTokenType.Comma)
                        {
                            this.AddViolation(tokenNode.Value.FindParentElement(), tokenNode.Value.LineNumber, Rules.ClosingSquareBracketsMustBeSpacedCorrectly);
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
        /// Checks a open bracket for spacing.
        /// </summary>
        /// <param name="tokens">The list of tokens being parsed.</param>
        /// <param name="tokenNode">The token to check.</param>
        private void CheckOpenCurlyBracket(MasterList<CsToken> tokens, Node<CsToken> tokenNode)
        {
            Param.AssertNotNull(tokens, "tokens");
            Param.AssertNotNull(tokenNode, "tokenNode");

            // Open curly brackets should be preceded either by whitespace, or an open paren.
            Node<CsToken> previousNode = tokenNode.Previous;
            if (previousNode != null)
            {
                CsTokenType lastType = previousNode.Value.CsTokenType;
                if (lastType != CsTokenType.WhiteSpace &&
                    lastType != CsTokenType.EndOfLine &&
                    lastType != CsTokenType.OpenParenthesis)
                {
                    this.AddViolation(tokenNode.Value.FindParentElement(), tokenNode.Value.LineNumber, Rules.OpeningCurlyBracketsMustBeSpacedCorrectly);
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
                            this.AddViolation(tokenNode.Value.FindParentElement(), tokenNode.Value.LineNumber, Rules.OpeningCurlyBracketsMustBeSpacedCorrectly);
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
            if (nextNode != null &&
                nextNode.Value.CsTokenType != CsTokenType.WhiteSpace &&
                nextNode.Value.CsTokenType != CsTokenType.EndOfLine)
            {
                this.AddViolation(tokenNode.Value.FindParentElement(), tokenNode.Value.LineNumber, Rules.OpeningCurlyBracketsMustBeSpacedCorrectly);
            }
        }
        
        /// <summary>
        /// Checks a close bracket for spacing.
        /// </summary>
        /// <param name="tokens">The list of tokens being parsed.</param>
        /// <param name="tokenNode">The token to check.</param>
        private void CheckCloseCurlyBracket(MasterList<CsToken> tokens, Node<CsToken> tokenNode)
        {
            Param.AssertNotNull(tokens, "tokens");
            Param.AssertNotNull(tokenNode, "tokenNode");

            // Close curly brackets should always be preceded by whitespace.
            Node<CsToken> previousNode = tokenNode.Previous;
            if (previousNode != null &&
                previousNode.Value.CsTokenType != CsTokenType.WhiteSpace &&
                previousNode.Value.CsTokenType != CsTokenType.EndOfLine)
            {
                this.AddViolation(tokenNode.Value.FindParentElement(), tokenNode.Value.LineNumber, Rules.ClosingCurlyBracketsMustBeSpacedCorrectly);
            }

            // Close curly brackets should be followed either by whitespace, a close paren, a dot,
            // a semicolon, or a comma.
            Node<CsToken> nextNode = tokenNode.Next;
            if (nextNode != null)
            {
                CsTokenType nextType = nextNode.Value.CsTokenType;
                if (nextType != CsTokenType.WhiteSpace &&
                    nextType != CsTokenType.EndOfLine &&
                    nextType != CsTokenType.CloseParenthesis &&
                    !IsTokenADot(nextNode.Value) &&
                    nextType != CsTokenType.Semicolon &&
                    nextType != CsTokenType.Comma)
                {
                    this.AddViolation(tokenNode.Value.FindParentElement(), tokenNode.Value.LineNumber, Rules.ClosingCurlyBracketsMustBeSpacedCorrectly);
                }

                if (nextType == CsTokenType.WhiteSpace)
                {
                    // If this is followed by whitespace, make sure that the character just
                    // after the whitespace is not a close paren, semicolon, comma or dot.
                    foreach (CsToken item in tokens.ForwardIterator(tokenNode.Next.Next))
                    {
                        CsTokenType itemType = item.CsTokenType;
                        if (itemType == CsTokenType.CloseParenthesis ||
                            itemType == CsTokenType.Semicolon ||
                            itemType == CsTokenType.Comma ||
                            IsTokenADot(item))
                        {
                            this.AddViolation(tokenNode.Value.FindParentElement(), tokenNode.Value.LineNumber, Rules.ClosingCurlyBracketsMustBeSpacedCorrectly);
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
        /// Checks a open generic bracket for spacing.
        /// </summary>
        /// <param name="tokenNode">The token to check.</param>
        private void CheckGenericTokenOpenBracket(Node<CsToken> tokenNode)
        {
            Param.AssertNotNull(tokenNode, "tokenNode");

            // Open generic brackets should be never be preceded by whitespace.
            Node<CsToken> previousNode = tokenNode.Previous;
            if (previousNode != null)
            {
                if (previousNode.Value.CsTokenType == CsTokenType.WhiteSpace ||
                    previousNode.Value.CsTokenType == CsTokenType.EndOfLine)
                {
                    this.AddViolation(tokenNode.Value.FindParentElement(), tokenNode.Value.LineNumber, Rules.OpeningGenericBracketsMustBeSpacedCorrectly);
                }
            }

            // Open brackets should never be followed by whitespace.
            Node<CsToken> nextNode = tokenNode.Next;
            if (nextNode != null &&
                (nextNode.Value.CsTokenType == CsTokenType.WhiteSpace || nextNode.Value.CsTokenType == CsTokenType.EndOfLine))
            {
                this.AddViolation(tokenNode.Value.FindParentElement(), tokenNode.Value.LineNumber, Rules.OpeningGenericBracketsMustBeSpacedCorrectly);
            }
        }

        /// <summary>
        /// Checks a closing generic bracket for spacing.
        /// </summary>
        /// <param name="tokenNode">The token to check.</param>
        private void CheckGenericTokenCloseBracket(Node<CsToken> tokenNode)
        {
            Param.AssertNotNull(tokenNode, "tokenNode");

            // Closing generic brackets should be never be preceded by whitespace.
            Node<CsToken> previousNode = tokenNode.Previous;
            if (previousNode != null)
            {
                if (previousNode.Value.CsTokenType == CsTokenType.WhiteSpace ||
                    previousNode.Value.CsTokenType == CsTokenType.EndOfLine)
                {
                    this.AddViolation(tokenNode.Value.FindParentElement(), tokenNode.Value.LineNumber, Rules.ClosingGenericBracketsMustBeSpacedCorrectly);
                }
            }
        }

        /// <summary>
        /// Checks a open attribute bracket for spacing.
        /// </summary>
        /// <param name="tokenNode">The token to check.</param>
        private void CheckAttributeTokenOpenBracket(Node<CsToken> tokenNode)
        {
            Param.AssertNotNull(tokenNode, "tokenNode");

            // Open brackets should never be followed by whitespace.
            Node<CsToken> nextNode = tokenNode.Next;
            if (nextNode != null &&
                (nextNode.Value.CsTokenType == CsTokenType.WhiteSpace || nextNode.Value.CsTokenType == CsTokenType.EndOfLine))
            {
                this.AddViolation(tokenNode.Value.FindParentElement(), tokenNode.Value.LineNumber, Rules.OpeningAttributeBracketsMustBeSpacedCorrectly);
            }
        }

        /// <summary>
        /// Checks a closing attribute bracket for spacing.
        /// </summary>
        /// <param name="tokenNode">The token to check.</param>
        private void CheckAttributeTokenCloseBracket(Node<CsToken> tokenNode)
        {
            Param.AssertNotNull(tokenNode, "tokenNode");

            // Closing attribute brackets should be never be preceded by whitespace.
            Node<CsToken> previousNode = tokenNode.Previous;
            if (previousNode != null)
            {
                if (previousNode.Value.CsTokenType == CsTokenType.WhiteSpace ||
                    previousNode.Value.CsTokenType == CsTokenType.EndOfLine)
                {
                    this.AddViolation(tokenNode.Value.FindParentElement(), tokenNode.Value.LineNumber, Rules.ClosingAttributeBracketsMustBeSpacedCorrectly);
                }
            }
        }

        /// <summary>
        /// Checks a nullable type symbol for spacing.
        /// </summary>
        /// <param name="tokenNode">The token to check.</param>
        private void CheckNullableTypeSymbol(Node<CsToken> tokenNode)
        {
            Param.AssertNotNull(tokenNode, "tokenNode");

            // Nullable type symbols should never be preceded by whitespace.
            Node<CsToken> previousNode = tokenNode.Previous;
            if (previousNode != null &&
                (previousNode.Value.CsTokenType == CsTokenType.WhiteSpace || previousNode.Value.CsTokenType == CsTokenType.EndOfLine))
            {
                this.AddViolation(tokenNode.Value.FindParentElement(), tokenNode.Value.LineNumber, Rules.NullableTypeSymbolsMustNotBePrecededBySpace);
            }
        }

        /// <summary>
        /// Checks a member access symbol for spacing.
        /// </summary>
        /// <param name="tokens">The list of tokens being parsed.</param>
        /// <param name="tokenNode">The token to check.</param>
        private void CheckMemberAccessSymbol(MasterList<CsToken> tokens, Node<CsToken> tokenNode)
        {
            Param.AssertNotNull(tokens, "tokens");
            Param.AssertNotNull(tokenNode, "tokenNode");

            // Member access symbols should not have any whitespace on either side.
            Node<CsToken> previousNode = tokenNode.Previous;
            if (previousNode != null)
            {
                CsTokenType previousTokenType = previousNode.Value.CsTokenType;
                if (previousTokenType == CsTokenType.WhiteSpace || previousTokenType == CsTokenType.EndOfLine || previousTokenType == CsTokenType.SingleLineComment || previousTokenType == CsTokenType.MultiLineComment)
                {
                    if (!this.IsTokenFirstNonWhitespaceTokenOnLine(tokens, tokenNode))
                    {
                        this.AddViolation(tokenNode.Value.FindParentElement(), tokenNode.Value.LineNumber, Rules.MemberAccessSymbolsMustBeSpacedCorrectly);
                    }
                }
            }

            Node<CsToken> nextNode = tokenNode.Next;
            if (nextNode != null)
            {
                CsTokenType tokenType = nextNode.Value.CsTokenType;
                if (tokenType == CsTokenType.WhiteSpace ||
                    tokenType == CsTokenType.EndOfLine ||
                    tokenType == CsTokenType.SingleLineComment ||
                    tokenType == CsTokenType.MultiLineComment)
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
                            else if (itemType != CsTokenType.WhiteSpace &&
                                itemType != CsTokenType.EndOfLine &&
                                itemType != CsTokenType.SingleLineComment &&
                                itemType != CsTokenType.MultiLineComment)
                            {
                                break;
                            }
                        }
                    }

                    this.AddViolation(tokenNode.Value.FindParentElement(), tokenNode.Value.LineNumber, Rules.MemberAccessSymbolsMustBeSpacedCorrectly);
                }
            }
        }    

        /// <summary>
        /// Checks to see if the passed in node is the first node on its line.
        /// </summary>
        /// <param name="tokens">The masterlist of tokens.</param>
        /// <param name="node">The node to check.</param>
        /// <returns>True if this node is the first on the line, otherwise false.</returns>
        private bool IsTokenFirstNonWhitespaceTokenOnLine(MasterList<CsToken> tokens, Node<CsToken> node)
        {
            var previousNode = node.Previous;
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

        /// <summary>
        /// Checks an increment or decrement sign for spacing.
        /// </summary>
        /// <param name="tokenNode">The token to check.</param>
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
                if (tokenType == CsTokenType.WhiteSpace ||
                    tokenType == CsTokenType.EndOfLine ||
                    tokenType == CsTokenType.SingleLineComment ||
                    tokenType == CsTokenType.MultiLineComment)
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
                if (tokenType == CsTokenType.WhiteSpace ||
                    tokenType == CsTokenType.EndOfLine ||
                    tokenType == CsTokenType.SingleLineComment ||
                    tokenType == CsTokenType.MultiLineComment)
                {
                    after = true;
                }
            }

            // If there is no whitespace on either side, then make sure that at least one of the sides
            // is touching a square bracket or a parenthesis. The right side of the symbol is also
            // allowed to be up against a comma or a semicolon.
            if (!before && !after)
            {
                if (previousNode != null &&
                    (previousNode.Value.CsTokenType == CsTokenType.OpenSquareBracket || previousNode.Value.CsTokenType == CsTokenType.OpenParenthesis))
                {
                    return;
                }

                if (nextNode != null)
                {
                    CsTokenType tokenType = nextNode.Value.CsTokenType;
                    if (tokenType == CsTokenType.CloseSquareBracket ||
                        tokenType == CsTokenType.CloseParenthesis ||
                        tokenType == CsTokenType.Comma ||
                        tokenType == CsTokenType.Semicolon)
                    {
                        return;
                    }
                }

                // This is a violation.
                this.AddViolation(tokenNode.Value.FindParentElement(), tokenNode.Value.LineNumber, Rules.IncrementDecrementSymbolsMustBeSpacedCorrectly);
            }
            else if (before && after)
            {
                // There is whitespace on both sides.
                this.AddViolation(tokenNode.Value.FindParentElement(), tokenNode.Value.LineNumber, Rules.IncrementDecrementSymbolsMustBeSpacedCorrectly);
            }
        }

        /// <summary>
        /// Checks a negative sign for spacing.
        /// </summary>
        /// <param name="tokenNode">The token to check.</param>
        private void CheckNegativeSign(Node<CsToken> tokenNode)
        {
            Param.AssertNotNull(tokenNode, "tokenNode");

            // A negative sign should be preceded by whitespace. It 
            // can also be preceded by an open paren or an open bracket.
            Node<CsToken> previousNode = tokenNode.Previous;
            if (previousNode != null)
            {
                CsTokenType tokenType = previousNode.Value.CsTokenType;
                if (tokenType != CsTokenType.WhiteSpace &&
                    tokenType != CsTokenType.EndOfLine &&
                    tokenType != CsTokenType.OpenParenthesis &&
                    tokenType != CsTokenType.OpenSquareBracket &&
                    tokenType != CsTokenType.CloseParenthesis)
                {
                    this.AddViolation(tokenNode.Value.FindParentElement(), tokenNode.Value.LineNumber, Rules.NegativeSignsMustBeSpacedCorrectly);
                }
            }

            Node<CsToken> nextNode = tokenNode.Next;
            if (nextNode != null)
            {
                CsTokenType tokenType = nextNode.Value.CsTokenType;
                if (tokenType == CsTokenType.WhiteSpace ||
                    tokenType == CsTokenType.EndOfLine ||
                    tokenType == CsTokenType.SingleLineComment ||
                    tokenType == CsTokenType.MultiLineComment)
                {
                    this.AddViolation(tokenNode.Value.FindParentElement(), tokenNode.Value.LineNumber, Rules.NegativeSignsMustBeSpacedCorrectly);
                }
            }
        }

        /// <summary>
        /// Checks a positive sign for spacing.
        /// </summary>
        /// <param name="tokenNode">The token to check.</param>
        private void CheckPositiveSign(Node<CsToken> tokenNode)
        {
            Param.AssertNotNull(tokenNode, "tokenNode");

            // A positive sign should be preceded by whitespace. It 
            // can also be preceded by an open paren or an open bracket.
            Node<CsToken> previousNode = tokenNode.Previous;
            if (previousNode != null)
            {
                CsTokenType tokenType = previousNode.Value.CsTokenType;
                if (tokenType != CsTokenType.WhiteSpace &&
                    tokenType != CsTokenType.EndOfLine &&
                    tokenType != CsTokenType.OpenParenthesis &&
                    tokenType != CsTokenType.OpenSquareBracket &&
                    tokenType != CsTokenType.CloseParenthesis)
                {
                    this.AddViolation(tokenNode.Value.FindParentElement(), tokenNode.Value.LineNumber, Rules.PositiveSignsMustBeSpacedCorrectly);
                }
            }

            Node<CsToken> nextNode = tokenNode.Next;
            if (nextNode != null)
            {
                CsTokenType tokenType = nextNode.Value.CsTokenType;
                if (tokenType == CsTokenType.WhiteSpace ||
                    tokenType == CsTokenType.EndOfLine ||
                    tokenType == CsTokenType.SingleLineComment ||
                    tokenType == CsTokenType.MultiLineComment)
                {
                    this.AddViolation(tokenNode.Value.FindParentElement(), tokenNode.Value.LineNumber, Rules.PositiveSignsMustBeSpacedCorrectly);
                }
            }
        }

        /// <summary>
        /// Checks an unsafe pointer access symbol sign for spacing.
        /// </summary>
        /// <param name="tokenNode">The token to check.</param>
        /// <param name="type">Indicates whether the token is part of a type declaration.</param>
        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Minimizing refactoring before release.")]
        private void CheckUnsafeAccessSymbols(Node<CsToken> tokenNode, bool type)
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
                Node<CsToken> nextNode = tokenNode.Next;
                if (nextNode != null)
                {
                    CsTokenType tokenType = nextNode.Value.CsTokenType;
                    if (tokenType != CsTokenType.WhiteSpace &&
                        tokenType != CsTokenType.EndOfLine &&
                        tokenType != CsTokenType.OpenParenthesis &&
                        tokenType != CsTokenType.OpenSquareBracket &&
                        tokenType != CsTokenType.CloseParenthesis &&
                        tokenType != tokenNode.Value.CsTokenType)
                    {
                        this.AddViolation(tokenNode.Value.FindParentElement(), tokenNode.Value.LineNumber, Rules.DereferenceAndAccessOfSymbolsMustBeSpacedCorrectly);
                    }
                }

                // The symbol must not be preceded by whitespace.
                Node<CsToken> previousNode = tokenNode.Previous;
                if (previousNode != null)
                {
                    CsTokenType tokenType = previousNode.Value.CsTokenType;
                    if (tokenType == CsTokenType.WhiteSpace ||
                        tokenType == CsTokenType.EndOfLine ||
                        tokenType == CsTokenType.SingleLineComment ||
                        tokenType == CsTokenType.MultiLineComment)
                    {
                        this.AddViolation(tokenNode.Value.FindParentElement(), tokenNode.Value.LineNumber, Rules.DereferenceAndAccessOfSymbolsMustBeSpacedCorrectly);
                    }
                }
            }
            else
            {
                // The symbol should be preceded by whitespace. It 
                // can also be preceded by an open paren or an open bracket, or
                // another token of the same type.
                Node<CsToken> previousNode = tokenNode.Previous;
                if (previousNode != null)
                {
                    CsTokenType tokenType = previousNode.Value.CsTokenType;
                    if (tokenType != CsTokenType.WhiteSpace &&
                        tokenType != CsTokenType.EndOfLine &&
                        tokenType != CsTokenType.OpenParenthesis &&
                        tokenType != CsTokenType.OpenSquareBracket &&
                        tokenType != CsTokenType.CloseParenthesis &&
                        tokenType != tokenNode.Value.CsTokenType)
                    {
                        this.AddViolation(tokenNode.Value.FindParentElement(), tokenNode.Value.LineNumber, Rules.DereferenceAndAccessOfSymbolsMustBeSpacedCorrectly);
                    }
                }

                // The symbol must not be followed by whitespace.
                Node<CsToken> nextNode = tokenNode.Next;
                if (nextNode == null)
                {
                    CsTokenType tokenType = nextNode.Value.CsTokenType;
                    if (tokenType == CsTokenType.WhiteSpace ||
                        tokenType == CsTokenType.EndOfLine ||
                        tokenType == CsTokenType.SingleLineComment ||
                        tokenType == CsTokenType.MultiLineComment)
                    {
                        this.AddViolation(tokenNode.Value.FindParentElement(), tokenNode.Value.LineNumber, Rules.DereferenceAndAccessOfSymbolsMustBeSpacedCorrectly);
                    }
                }
            }
        }

        /// <summary>
        /// Checks a label colon for spacing.
        /// </summary>
        /// <param name="tokenNode">The token to check.</param>
        private void CheckLabelColon(Node<CsToken> tokenNode)
        {
            Param.AssertNotNull(tokenNode, "tokenNode");

            // A colon should always be followed by whitespace, but never preceded by whitespace.
            Node<CsToken> nextNode = tokenNode.Next;
            if (nextNode != null)
            {
                CsTokenType tokenType = nextNode.Value.CsTokenType;
                if (tokenType != CsTokenType.WhiteSpace &&
                    tokenType != CsTokenType.EndOfLine)
                {
                    this.AddViolation(tokenNode.Value.FindParentElement(), tokenNode.Value.LineNumber, Rules.ColonsMustBeSpacedCorrectly);
                }
            }

            Node<CsToken> previousNode = tokenNode.Previous;
            if (previousNode != null)
            {
                CsTokenType tokenType = previousNode.Value.CsTokenType;
                if (tokenType == CsTokenType.WhiteSpace ||
                    tokenType == CsTokenType.EndOfLine ||
                    tokenType == CsTokenType.SingleLineComment ||
                    tokenType == CsTokenType.MultiLineComment)
                {
                    this.AddViolation(tokenNode.Value.FindParentElement(), tokenNode.Value.LineNumber, Rules.ColonsMustBeSpacedCorrectly);
                }
            }
        }

        /// <summary>
        /// Checks a unary symbol for spacing.
        /// </summary>
        /// <param name="tokenNode">The token to check.</param>
        private void CheckUnarySymbol(Node<CsToken> tokenNode)
        {
            Param.AssertNotNull(tokenNode, "tokenNode");

            // These symbols should be preceded by whitespace but not followed by whitespace. They can
            // also be preceded by an open paren or an open square bracket.
            Node<CsToken> previousNode = tokenNode.Previous;
            if (previousNode != null)
            {
                CsTokenType tokenType = previousNode.Value.CsTokenType;
                if (tokenType != CsTokenType.WhiteSpace &&
                    tokenType != CsTokenType.EndOfLine &&
                    tokenType != CsTokenType.OpenParenthesis &&
                    tokenType != CsTokenType.OpenSquareBracket)
                {
                    this.AddViolation(tokenNode.Value.FindParentElement(), tokenNode.Value.LineNumber, Rules.SymbolsMustBeSpacedCorrectly, tokenNode.Value.Text);
                }
            }

            Node<CsToken> nextNode = tokenNode.Next;
            if (nextNode == null)
            {
                CsTokenType tokenType = nextNode.Value.CsTokenType;
                if (tokenType == CsTokenType.WhiteSpace ||
                    tokenType == CsTokenType.EndOfLine ||
                    tokenType == CsTokenType.SingleLineComment ||
                    tokenType == CsTokenType.MultiLineComment)
                {
                    this.AddViolation(tokenNode.Value.FindParentElement(), tokenNode.Value.LineNumber, Rules.SymbolsMustBeSpacedCorrectly, tokenNode.Value.Text);
                }
            }
        }

        /// <summary>
        /// Checks to make sure that there is not too many whitespace symbols in a row.
        /// </summary>
        /// <param name="tokenNode">The whitespace to check.</param>
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
                    this.AddViolation(parentElement, whitespace.LineNumber, Rules.TabsMustNotBeUsed);
                }
            }
            else if (whitespace.TabCount == 0 && whitespace.SpaceCount > 1)
            {
                // Multiple spaces in a row are only allowed at the beginning of a line, following 
                // a comma or semicolon, preceding a symbol, or at the end of a line.
                Node<CsToken> nextNode = tokenNode.Next;
                Node<CsToken> previousNode = tokenNode.Previous;
                if (previousNode != null &&
                    previousNode.Value.CsTokenType != CsTokenType.EndOfLine &&
                    previousNode.Value.CsTokenType != CsTokenType.Comma &&
                    previousNode.Value.CsTokenType != CsTokenType.Semicolon &&
                    nextNode != null &&
                    nextNode.Value.CsTokenType != CsTokenType.OperatorSymbol &&
                    nextNode.Value.CsTokenType != CsTokenType.EndOfLine &&
                    nextNode.Value.CsTokenType != CsTokenType.SingleLineComment &&
                    nextNode.Value.CsTokenType != CsTokenType.MultiLineComment)
                {
                    this.AddViolation(tokenNode.Value.FindParentElement(), whitespace.LineNumber, Rules.CodeMustNotContainMultipleWhitespaceInARow);
                }
            }
        }

        /// <summary>
        /// Checks for tabs in the given comment.
        /// </summary>
        /// <param name="comment">The comment token.</param>
        private void CheckTabsInComment(CsToken comment)
        {
            Param.AssertNotNull(comment, "comment");

            int lineEnds = 0;

            for (int i = 0; i < comment.Text.Length; ++i)
            {
                if (comment.Text[i] == '\t')
                {
                    this.AddViolation(comment.FindParentElement(), comment.LineNumber + lineEnds, Rules.TabsMustNotBeUsed);
                }
                else if (comment.Text[i] == '\n')
                {
                    ++lineEnds;
                }
            }
        }

        #endregion Private Methods
    }
}