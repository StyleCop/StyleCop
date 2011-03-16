//-----------------------------------------------------------------------
// <copyright file="SpacingRules.cs">
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
    using System;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using StyleCop;
    using StyleCop.CSharp.CodeModel;

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
        public override void AnalyzeDocument(ICodeDocument document)
        {
            Param.RequireNotNull(document, "document");

            CsDocument csdocument = document.AsCsDocument();

            if (csdocument != null && !csdocument.Generated)
            {
                this.CheckSpacing(csdocument, false);
            }
        }

        #endregion Public Override Methods

        #region Private Static Methods

        /// <summary>
        /// Determines whether the type of the given token is allowed
        /// to appear after a closing parenthesis, with no space between
        /// the parenthesis and the token.
        /// </summary>
        /// <param name="item">The item to check.</param>
        /// <returns>True if it is allowed; false otherwise.</returns>
        private static bool IsAllowedAfterClosingParenthesis(LexicalElement item)
        {
            Param.AssertNotNull(item, "item");

            if (item.Is(TokenType.CloseParenthesis) ||
                item.Is(TokenType.OpenParenthesis) ||
                item.Is(TokenType.CloseSquareBracket) ||
                item.Is(TokenType.OpenSquareBracket) ||
                item.Is(TokenType.CloseAttributeBracket) ||
                item.Is(TokenType.Semicolon) ||
                item.Is(TokenType.Comma) ||
                item.Is(OperatorType.Decrement) ||
                item.Is(OperatorType.Increment) ||
                item.Is(OperatorType.MemberAccess) ||
                item.Is(OperatorType.Pointer))
            {
                return true;
            }

            return false;
        }

        #endregion Private Static Methods

        #region Private Methods

        /// <summary>
        /// Checks the spacing of a root.
        /// </summary>
        /// <param name="root">The root item.</param>
        /// <param name="type">Indicates whether the tokens are part of a type declaration.</param>
        [SuppressMessage("Microsoft.Maintainability", "CA1505:AvoidUnmaintainableCode", Justification = "Minimizing refactoring before release.")]
        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Minimizing refactoring before release.")]
        private void CheckSpacing(CodeUnit root, bool type)
        {
            Param.AssertNotNull(root, "root");
            Param.Ignore(type);

            // Make sure it contains at least one token.
            for (CodeUnit item = root.FindFirst(); item != null; item = item.FindNext(root))
            {
                if (this.Cancel)
                {
                    break;
                }

                if (!item.Generated)
                {
                    if (item.Is(TokenType.OperatorSymbol))
                    {
                        OperatorSymbolToken operatorSymbol = (OperatorSymbolToken)item;

                        switch (operatorSymbol.Category)
                        {
                            case OperatorCategory.Reference:
                                switch (operatorSymbol.SymbolType)
                                {
                                    case OperatorType.QualifiedAlias:
                                    case OperatorType.Pointer:
                                    case OperatorType.MemberAccess:
                                        this.CheckMemberAccessSymbol(root, operatorSymbol);
                                        break;

                                    case OperatorType.AddressOf:
                                    case OperatorType.Dereference:
                                        this.CheckUnsafeAccessSymbols(operatorSymbol, type);
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
                                this.CheckSymbol(root, operatorSymbol);
                                break;

                            case OperatorCategory.IncrementDecrement:
                                this.CheckIncrementDecrement(operatorSymbol);
                                break;

                            case OperatorCategory.Unary:
                                if (operatorSymbol.SymbolType == OperatorType.Negative)
                                {
                                    this.CheckNegativeSign(operatorSymbol);
                                }
                                else if (operatorSymbol.SymbolType == OperatorType.Positive)
                                {
                                    this.CheckPositiveSign(operatorSymbol);
                                }
                                else
                                {
                                    this.CheckUnarySymbol(operatorSymbol);
                                }

                                break;
                        }
                    }
                    else if (item.Is(LexicalElementType.Token))
                    {
                        Token token = (Token)item;
                        switch (token.TokenType)
                        {
                            case TokenType.Catch:
                            case TokenType.Fixed:
                            case TokenType.For:
                            case TokenType.Foreach:
                            case TokenType.From:
                            case TokenType.Group:
                            case TokenType.If:
                            case TokenType.In:
                            case TokenType.Into:
                            case TokenType.Join:
                            case TokenType.Let:
                            case TokenType.Lock:
                            case TokenType.OrderBy:
                            case TokenType.Return:
                            case TokenType.Select:
                            case TokenType.Stackalloc:
                            case TokenType.Switch:
                            case TokenType.Throw:
                            case TokenType.Using:
                            case TokenType.Where:
                            case TokenType.While:
                            case TokenType.WhileDo:
                            case TokenType.Yield:
                                // These keywords must be followed by a space before the open parenthesis.
                                this.CheckKeywordWithSpace(token);
                                break;

                            case TokenType.New:
                                this.CheckNewKeywordSpacing(root, token);
                                break;

                            case TokenType.Checked:
                            case TokenType.Unchecked:
                            case TokenType.Sizeof:
                            case TokenType.Typeof:
                            case TokenType.DefaultValue:
                                // These keywords must not contain any space before the open parenthesis.
                                this.CheckKeywordWithoutSpace(root, token);
                                break;

                            case TokenType.Comma:
                            case TokenType.Semicolon:
                                this.CheckSemicolonAndComma(token);
                                break;

                            case TokenType.OpenParenthesis:
                                this.CheckOpenParen(root, token);
                                break;

                            case TokenType.CloseParenthesis:
                                this.CheckCloseParen(root, token);
                                break;

                            case TokenType.OpenSquareBracket:
                                this.CheckOpenSquareBracket(token);
                                break;

                            case TokenType.CloseSquareBracket:
                                this.CheckCloseSquareBracket(root, token);
                                break;

                            case TokenType.OpenCurlyBracket:
                                this.CheckOpenCurlyBracket(root, token);
                                break;

                            case TokenType.CloseCurlyBracket:
                                this.CheckCloseCurlyBracket(root, token);
                                break;

                            case TokenType.OpenAttributeBracket:
                                this.CheckAttributeTokenOpenBracket(token);
                                break;

                            case TokenType.CloseAttributeBracket:
                                this.CheckAttributeTokenCloseBracket(token);
                                break;

                            case TokenType.BaseColon:
                            case TokenType.WhereColon:
                                this.CheckSymbol(root, token);
                                break;

                            case TokenType.AttributeColon:
                            case TokenType.LabelColon:
                                this.CheckLabelColon(token);
                                break;

                            case TokenType.NullableTypeSymbol:
                                this.CheckNullableTypeSymbol(token);
                                break;

                            case TokenType.Operator:
                                this.CheckOperatorKeyword(token);
                                break;

                            case TokenType.OpenGenericBracket:
                                this.CheckGenericTokenOpenBracket(token);
                                break;

                            case TokenType.CloseGenericBracket:
                                this.CheckGenericTokenCloseBracket(token);
                                break;
                        }
                    }
                    else if (item.Is(CodeUnitType.LexicalElement))
                    {
                        LexicalElement lex = (LexicalElement)item;
                        switch (lex.LexicalElementType)
                        {
                            case LexicalElementType.WhiteSpace:
                                this.CheckWhitespace((Whitespace)item);
                                break;

                            case LexicalElementType.PreprocessorDirective:
                                this.CheckPreprocessorSpacing((PreprocessorDirective)item);
                                break;
                        }
                    }
                    else if (item.Is(LexicalElementType.Comment))
                    {
                        Comment comment = (Comment)item;
                        switch (comment.CommentType)
                        {
                            case CommentType.SingleLineComment:
                                // Look for tabs in the comment string.
                                this.CheckTabsInComment(comment);

                                // Check spacing in the comment.
                                this.CheckSingleLineComment(root, comment);
                                break;

                            case CommentType.MultilineComment:
                                // Look for tabs in the comment string.
                                this.CheckTabsInComment(comment);
                                break;
                        }
                    }
                    else
                    {
                        switch (item.CodeUnitType)
                        {
                            case CodeUnitType.ElementHeader:
                                ElementHeader header = (ElementHeader)item;
                                this.CheckXmlHeaderComment((ElementHeader)item);

                                // Look for tabs in the xml header string. Look at 
                                // each sub-token in the header individually to get the
                                // line numbers correct.
                                for (LexicalElement xmlHeaderItem = header.FindFirstDescendentLexicalElement(); xmlHeaderItem != null; xmlHeaderItem = xmlHeaderItem.FindNextDescendentLexicalElementOf(header))
                                {
                                    this.CheckTabsInComment(xmlHeaderItem);
                                }

                                break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Checks a keyword that should be followed by a space.
        /// </summary>
        /// <param name="token">The token to check.</param>
        private void CheckKeywordWithSpace(Token token)
        {
            Param.AssertNotNull(token, "token");

            // Keywords must be followed by a space before the open parenthesis.
            // Sometimes keywords appear within attributes and are allowed to be
            // followed immediately by an attribute colon.
            LexicalElement temp = token.FindNextLexicalElement();
            if (temp == null ||
                (temp.LexicalElementType != LexicalElementType.WhiteSpace &&
                temp.LexicalElementType != LexicalElementType.EndOfLine &&
                !temp.Is(TokenType.Semicolon) &&
                !temp.Is(TokenType.AttributeColon)))
            {
                this.AddViolation(
                    token.FindParentElement(), 
                    token.LineNumber, 
                    Rules.KeywordsMustBeSpacedCorrectly, 
                    token.Text);
            }
        }

        /// <summary>
        /// Checks a keyword that should not be followed by a space.
        /// </summary>
        /// <param name="root">The container to parse.</param>
        /// <param name="token">The token to check.</param>
        private void CheckKeywordWithoutSpace(CodeUnit root, Token token)
        {
            Param.AssertNotNull(root, "root");
            Param.AssertNotNull(token, "token");

            // Keywords must not contain any space before the open parenthesis.
            LexicalElement temp = token.FindNextLexicalElement();
            if (temp != null &&
                (temp.LexicalElementType == LexicalElementType.WhiteSpace || temp.LexicalElementType == LexicalElementType.EndOfLine))
            {
                // Make sure the next non-whitespace character is not an open parenthesis.
                for (LexicalElement nextNonWhitespaceItem = temp.FindNextLexicalElement(); nextNonWhitespaceItem != null; nextNonWhitespaceItem = nextNonWhitespaceItem.FindNextLexicalElement())
                {
                    if (nextNonWhitespaceItem.Is(TokenType.OpenParenthesis))
                    {
                        this.AddViolation(token.FindParentElement(), token.LineNumber, Rules.KeywordsMustBeSpacedCorrectly, token.Text);
                        break;
                    }
                    else if (nextNonWhitespaceItem.LexicalElementType != LexicalElementType.WhiteSpace && nextNonWhitespaceItem.LexicalElementType != LexicalElementType.EndOfLine)
                    {
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Checks the spacing around a 'new' keyword.
        /// </summary>
        /// <param name="root">The token container list.</param>
        /// <param name="token">The token to check.</param>
        private void CheckNewKeywordSpacing(CodeUnit root, Token token)
        {
            Param.AssertNotNull(root, "root");
            Param.AssertNotNull(token, "token");

            // The keywords must be followed by a space, unless the next token is an opening square bracket, in which case
            // there should be no space.
            LexicalElement temp = token.FindNextLexicalElement();
            if (temp != null)
            {
                if (temp.LexicalElementType == LexicalElementType.WhiteSpace || temp.LexicalElementType == LexicalElementType.EndOfLine)
                {
                    // The keyword is followed by whitespace. Make sure the next non-whitespace character is not an opening bracket.
                    for (LexicalElement nextNonWhitespaceItem = temp.FindNextLexicalElement(); nextNonWhitespaceItem != null; nextNonWhitespaceItem = nextNonWhitespaceItem.FindNextLexicalElement())
                    {
                        if (nextNonWhitespaceItem.Is(TokenType.OpenSquareBracket))
                        {
                            this.AddViolation(token.FindParentElement(), token.LineNumber, Rules.CodeMustNotContainSpaceAfterNewKeywordInImplicitlyTypedArrayAllocation);
                            break;
                        }
                        else if (nextNonWhitespaceItem.LexicalElementType != LexicalElementType.WhiteSpace && nextNonWhitespaceItem.LexicalElementType != LexicalElementType.EndOfLine)
                        {
                            break;
                        }
                    }
                }
                else if (!temp.Is(TokenType.OpenSquareBracket))
                {
                    // The keyword is not followed by whitespace.
                    this.AddViolation(token.FindParentElement(), token.LineNumber, Rules.KeywordsMustBeSpacedCorrectly, token.Text);
                }
            }
        }

        /// <summary>
        /// Checks a semicolon or comma for spacing.
        /// </summary>
        /// <param name="token">The token to check.</param>
        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Minimizing refactoring before release.")]
        private void CheckSemicolonAndComma(Token token)
        {
            Param.AssertNotNull(token, "token");

            bool comma = false;
            if (token.Text == ",")
            {
                comma = true;
            }
            else
            {
                Debug.Assert(token.Text == ";", "The token should either be a comma or a semicolon");
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
            LexicalElement item = token.FindPreviousLexicalElement();
            if (item != null)
            {
                for (int i = 0; i < open.Length; ++i)
                {
                    if (item.Text == open[i])
                    {
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    if (item.Text == token.Text)
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
            item = token.FindNextLexicalElement();
            if (item != null)
            {
                for (int i = 0; i < close.Length; ++i)
                {
                    if (item.Text == close[i])
                    {
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    if (item.Text == token.Text)
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
                LexicalElement previousItem = token.FindPreviousLexicalElement();

                // Make sure this is not preceded by whitespace.
                if (previousItem != null &&
                    (previousItem.LexicalElementType == LexicalElementType.WhiteSpace || previousItem.LexicalElementType == LexicalElementType.EndOfLine))
                {
                    this.AddViolation(
                        token.FindParentElement(),
                        token.LineNumber, 
                        comma ? Rules.CommasMustBeSpacedCorrectly : Rules.SemicolonsMustBeSpacedCorrectly);
                }
            }

            if (!specialCaseForwards)
            {
                LexicalElement nextItem = token.FindNextLexicalElement();

                // Make sure this is followed by whitespace or a close paren.
                if (nextItem != null &&
                    nextItem.LexicalElementType != LexicalElementType.WhiteSpace &&
                    nextItem.LexicalElementType != LexicalElementType.EndOfLine &&
                    !nextItem.Is(TokenType.CloseParenthesis))
                {
                    this.AddViolation(
                        token.FindParentElement(),
                        token.LineNumber, 
                        comma ? Rules.CommasMustBeSpacedCorrectly : Rules.SemicolonsMustBeSpacedCorrectly);
                }
            }
        }

        /// <summary>
        /// Checks a symbol for spacing.
        /// </summary>
        /// <param name="root">The container to parse.</param>
        /// <param name="token">The token to check.</param>
        private void CheckSymbol(CodeUnit root, Token token)
        {
            Param.AssertNotNull(root, "root");
            Param.AssertNotNull(token, "token");

            // Symbols should have whitespace on both sides.
            LexicalElement previousItem = token.FindPreviousLexicalElement();
            if (previousItem != null &&
                previousItem.LexicalElementType != LexicalElementType.WhiteSpace &&
                previousItem.LexicalElementType != LexicalElementType.EndOfLine)
            {
                this.AddViolation(token.FindParentElement(), token.LineNumber, Rules.SymbolsMustBeSpacedCorrectly, token.Text);
            }

            LexicalElement nextItem = token.FindNextLexicalElement();
            if (nextItem != null &&
                nextItem.LexicalElementType != LexicalElementType.WhiteSpace &&
                nextItem.LexicalElementType != LexicalElementType.EndOfLine)
            {
                // Make sure the previous token is not operator.
                if (previousItem != null)
                {
                    for (LexicalElement item = previousItem.FindPreviousLexicalElement(); item != null; item = item.FindPreviousLexicalElement())
                    {
                        if (item.Is(TokenType.Operator))
                        {
                            return;
                        }
                        else if (item.LexicalElementType != LexicalElementType.WhiteSpace &&
                            item.LexicalElementType != LexicalElementType.EndOfLine &&
                            !item.Is(CommentType.SingleLineComment) &&
                            !item.Is(CommentType.MultilineComment) &&
                            item.LexicalElementType != LexicalElementType.PreprocessorDirective)
                        {
                            break;
                        }
                    }
                }

                this.AddViolation(token.FindParentElement(), token.LineNumber, Rules.SymbolsMustBeSpacedCorrectly, token.Text);
            }
        }

        /// <summary>
        /// Checks to make sure that the slashes in in the Xml header are followed by a space.
        /// </summary>
        /// <param name="header">The Xml header token.</param>
        private void CheckXmlHeaderComment(ElementHeader header)
        {
            Param.AssertNotNull(header, "header");

            for (ElementHeaderLine item = header.FindFirstDescendent<ElementHeaderLine>(); item != null; item = item.FindNextDescendentOf<ElementHeaderLine>(header))
            {
                if (item.Text.Length > 3)
                {
                    if (item.Text[3] != ' ' &&
                        item.Text[3] != '\t' &&
                        item.Text[3] != '/' &&
                        item.Text[2] != '\n' &&
                        item.Text[2] != '\r')
                    {
                        // The header line does not start with any spaces.
                        this.AddViolation(item.FindParentElement(), item.LineNumber, Rules.DocumentationLinesMustBeginWithSingleSpace);
                    }
                    else if (item.Text.Length > 4 && (item.Text[4] == ' ' || item.Text[4] == '\t'))
                    {
                        // The header line starts with more than one space. This is only allowed when the 
                        // header line is not the first or last line in the header.
                        bool error = true;
                        for (LexicalElement previous = item.FindPreviousLexicalElement(); previous != null; previous = previous.FindPreviousLexicalElement())
                        {
                            if (previous.Is(CommentType.ElementHeaderLine))
                            {
                                for (LexicalElement next = item.FindNextLexicalElement(); next != null; next = next.FindNextLexicalElement())
                                {
                                    if (next.Is(CommentType.ElementHeaderLine))
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
                            this.AddViolation(item.FindParentElement(), item.LineNumber, Rules.DocumentationLinesMustBeginWithSingleSpace);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Checks to make sure that the slashes in in the comment are followed by a space.
        /// </summary>
        /// <param name="root">The container to parse.</param>
        /// <param name="comment">The comment.</param>
        private void CheckSingleLineComment(CodeUnit root, Comment comment)
        {
            Param.AssertNotNull(root, "root");
            Param.AssertNotNull(comment, "comment");

            // If the token length is less then two, this is not a valid comment so just ignore it.
            string text = comment.Text;
            if (text.Length > 2)
            {
                // The first character in the comment must be a space, except for the following four cases:
                // 1. The comment may start with three or more slashes: ///whatever
                // 2. The command may start with a backwards slash: //\whatever
                // 3. The comment may start with a dash if there are at last two dashes: //--
                // 4. The character after the second slash may be a newline character.
                if (text[2] != ' ' &&
                    text[2] != '\t' &&
                    text[2] != '/' &&
                    text[2] != '\\' &&
                    text[1] != '\n' &&
                    text[1] != '\r' &&
                    (text.Length < 4 || text[2] != '-' || text[3] != '-'))
                {
                    // The comment does not start with a single space.
                    this.AddViolation(comment.FindParentElement(), comment.LineNumber, Rules.SingleLineCommentsMustBeginWithSingleSpace);
                }
                else if (text.Length > 3 && (text[3] == ' ' || text[3] == '\t') && text[2] != '\\')
                {
                    // The comment starts with more than one space. This is only a violation if this is the first 
                    // single-line comment in a row. If there is another single-line comment directly above this one
                    // with no blank line between them, this is not a violation.
                    bool first = true;
                    int newLineCount = 0;

                    for (LexicalElement previousItem = comment.FindPreviousLexicalElement(); previousItem != null; previousItem = previousItem.FindPreviousLexicalElement())
                    {
                        if (previousItem.LexicalElementType == LexicalElementType.EndOfLine)
                        {
                            if (++newLineCount == 2)
                            {
                                break;
                            }
                        }
                        else if (previousItem.Is(CommentType.SingleLineComment))
                        {
                            first = false;
                            break;
                        }
                        else if (previousItem.LexicalElementType != LexicalElementType.WhiteSpace)
                        {
                            break;
                        }
                    }

                    if (first)
                    {
                        this.AddViolation(comment.FindParentElement(), comment.LineNumber, Rules.SingleLineCommentsMustBeginWithSingleSpace);
                    }
                }
            }
        }

        /// <summary>
        /// Checks to make sure that preprocessor type keyword is not preceded by a space.
        /// </summary>
        /// <param name="preprocessor">The preprocessor token.</param>
        private void CheckPreprocessorSpacing(PreprocessorDirective preprocessor)
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
        /// <param name="token">The token to check.</param>
        private void CheckOperatorKeyword(Token token)
        {
            Param.AssertNotNull(token, "token");

            // Operator keywords should be followed by whitespace.
            LexicalElement next = token.FindNextLexicalElement();
            if (next != null && next.LexicalElementType != LexicalElementType.WhiteSpace)
            {
                this.AddViolation(token.FindParentElement(), token.LineNumber, Rules.OperatorKeywordMustBeFollowedBySpace);
            }
        }

        /// <summary>
        /// Checks an open parenthesis for spacing.
        /// </summary>
        /// <param name="root">The container to parse.</param>
        /// <param name="token">The token to check.</param>
        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Minimizing refactoring before release.")]
        private void CheckOpenParen(CodeUnit root, Token token)
        {
            Param.AssertNotNull(root, "root");
            Param.AssertNotNull(token, "token");

            bool firstOnLine = false;
            bool lastOnLine = false;
            
            // Open parenthesis should never be preceded by whitespace unless it is the
            // first thing on the line or it follows a keyword or it follows a symbol or a number.
            LexicalElement previousItem = token.FindPreviousLexicalElement();
            if (previousItem != null)
            {
                if (previousItem.LexicalElementType == LexicalElementType.WhiteSpace)
                {
                    for (LexicalElement item = previousItem.FindPreviousLexicalElement(); item != null; item = item.FindPreviousLexicalElement())
                    {
                        if (item.LexicalElementType == LexicalElementType.WhiteSpace)
                        {
                            continue;
                        }
                        else if (item.LexicalElementType == LexicalElementType.EndOfLine)
                        {
                            firstOnLine = true;
                            break;
                        }
                        else if (
                            item.Is(TokenType.Case) ||
                            item.Is(TokenType.Catch) ||
                            item.Is(TokenType.CloseSquareBracket) ||
                            item.Is(TokenType.Comma) ||
                            item.Is(TokenType.Equals) ||
                            item.Is(TokenType.Fixed) ||
                            item.Is(TokenType.For) ||
                            item.Is(TokenType.Foreach) ||
                            item.Is(TokenType.From) ||
                            ////item.Is(TokenType.Goto) ||
                            item.Is(TokenType.Group) ||
                            item.Is(TokenType.If) ||
                            item.Is(TokenType.In) ||
                            item.Is(TokenType.Into) ||
                            item.Is(TokenType.Join) ||
                            item.Is(TokenType.Let) ||
                            item.Is(TokenType.Lock) ||
                            item.Is(CommentType.MultilineComment) ||
                            ////item.Is(TokenType.New) ||
                            item.Is(TokenType.Number) ||
                            item.Is(TokenType.OperatorSymbol) ||
                            item.Is(TokenType.OpenCurlyBracket) ||
                            item.Is(TokenType.OrderBy) ||
                            item.Is(TokenType.Return) ||
                            item.Is(TokenType.Select) ||
                            item.Is(TokenType.Semicolon) ||
                            ////item.Is(CommentType.SingleLineComment) ||
                            item.Is(TokenType.Switch) ||
                            item.Is(TokenType.Throw) ||
                            item.Is(TokenType.Using) ||
                            item.Is(TokenType.Where) ||
                            item.Is(TokenType.While) ||
                            item.Is(TokenType.WhileDo) ||
                            item.Is(TokenType.Yield))
                        {
                            break;
                        }
                        else
                        {
                            this.AddViolation(token.FindParentElement(), token.LineNumber, Rules.OpeningParenthesisMustBeSpacedCorrectly);
                        }
                    }
                }
            }

            // Open parens should never be followed by whitespace unless
            // it is the last thing on the line.
            LexicalElement next = token.FindPreviousLexicalElement();
            if (next != null &&
                (next.LexicalElementType == LexicalElementType.WhiteSpace || next.LexicalElementType == LexicalElementType.EndOfLine))
            {
                // Look to see if there is any non whitespace character
                // on this line other than a comment.
                for (LexicalElement item = next.FindNextLexicalElement(); item != null; item = item.FindNextLexicalElement())
                {
                    if (item.LexicalElementType == LexicalElementType.EndOfLine)
                    {
                        lastOnLine = true;
                        break;
                    }
                    else if (item.LexicalElementType != LexicalElementType.WhiteSpace &&
                        !item.Is(CommentType.SingleLineComment) &&
                        !item.Is(CommentType.MultilineComment))
                    {
                        this.AddViolation(token.FindParentElement(), token.LineNumber, Rules.OpeningParenthesisMustBeSpacedCorrectly);
                        break;
                    }
                }
            }

            // Open parens cannot be the only thing on the line.
            if (firstOnLine && lastOnLine)
            {
                this.AddViolation(token.FindParentElement(), token.LineNumber, Rules.OpeningParenthesisMustBeSpacedCorrectly);
            }
        }

        /// <summary>
        /// Checks a close paren for spacing.
        /// </summary>
        /// <param name="root">The container to parse.</param>
        /// <param name="token">The token to check.</param>
        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Minimizing refactoring before release.")]
        private void CheckCloseParen(CodeUnit root, Token token)
        {
            Param.AssertNotNull(root, "root");
            Param.AssertNotNull(token, "token");

            // Close parens should never be preceded by whitespace.
            LexicalElement previousItem = token.FindPreviousLexicalElement();
            if (previousItem != null &&
                (previousItem.LexicalElementType == LexicalElementType.WhiteSpace || previousItem.LexicalElementType == LexicalElementType.EndOfLine))
            {
                this.AddViolation(token.FindParentElement(), token.LineNumber, Rules.ClosingParenthesisMustBeSpacedCorrectly);
            }

            // Find out what comes after the closing paren.
            LexicalElement nextItem = token.FindNextLexicalElement();
            LexicalElement nextNextItem = nextItem == null ? null : nextItem.FindNextLexicalElement();

            if (nextItem != null)
            {
                if (token.Parent is CastExpression)
                {
                    // There should not be any whitespace after the closing parenthesis in a cast expression.
                    if (nextItem.LexicalElementType == LexicalElementType.WhiteSpace)
                    {
                        this.AddViolation(token.FindParentElement(), token.LineNumber, Rules.ClosingParenthesisMustBeSpacedCorrectly);
                    }
                }
                else if (nextItem.Is(TokenType.LabelColon) || (nextNextItem != null && nextNextItem.Is(TokenType.LabelColon)))
                {
                    // If the next token is a colon, it's allowed to omit the whitespace only if we are in a switch\case statement.
                    bool followsCase = false;

                    for (LexicalElement item = token.FindPreviousLexicalElement(); item != null; item = item.FindPreviousLexicalElement())
                    {
                        if (item.LexicalElementType == LexicalElementType.EndOfLine)
                        {
                            break;
                        }
                        else if (item.Is(TokenType.Case))
                        {
                            followsCase = true;
                            break;
                        }
                    }

                    if ((followsCase && nextItem.LexicalElementType == LexicalElementType.WhiteSpace) ||
                        (!followsCase && nextItem.LexicalElementType != LexicalElementType.WhiteSpace))
                    {
                        this.AddViolation(token.FindParentElement(), token.LineNumber, Rules.ClosingParenthesisMustBeSpacedCorrectly);
                    }
                }
                else if (nextItem.LexicalElementType == LexicalElementType.WhiteSpace)
                {
                    if (nextNextItem != null)
                    {
                        // Make sure that the character just after the whitespace is not a paren, bracket, a comma, or a semicolon.
                        for (LexicalElement item = nextNextItem; item != null; item = item.FindNextLexicalElement())
                        {
                            if (IsAllowedAfterClosingParenthesis(item))
                            {
                                this.AddViolation(token.FindParentElement(), token.LineNumber, Rules.ClosingParenthesisMustBeSpacedCorrectly);
                            }
                            else if (item.LexicalElementType != LexicalElementType.WhiteSpace)
                            {
                                break;
                            }
                        }
                    }
                }
                else
                {
                    // For all other types, the parenthesis must be followed by whitespace, unless the next character is a paren, bracket, comma, or a semicolon.
                    if (nextItem.LexicalElementType != LexicalElementType.EndOfLine &&
                        !IsAllowedAfterClosingParenthesis(nextItem))
                    {
                        this.AddViolation(token.FindParentElement(), token.LineNumber, Rules.ClosingParenthesisMustBeSpacedCorrectly);
                    }
                }
            }
        }

        /// <summary>
        /// Checks a open bracket for spacing.
        /// </summary>
        /// <param name="token">The token to check.</param>
        private void CheckOpenSquareBracket(Token token)
        {
            Param.AssertNotNull(token, "token");

            // Open brackets should be never be preceded by whitespace.
            LexicalElement previousItem = token.FindPreviousLexicalElement();
            if (previousItem != null)
            {
                if (previousItem.LexicalElementType == LexicalElementType.WhiteSpace ||
                    previousItem.LexicalElementType == LexicalElementType.EndOfLine)
                {
                    this.AddViolation(token.FindParentElement(), token.LineNumber, Rules.OpeningSquareBracketsMustBeSpacedCorrectly);
                }
            }

            // Open brackets should never be followed by whitespace.
            LexicalElement nextItem = token.FindNextLexicalElement();
            if (nextItem != null &&
                (nextItem.LexicalElementType == LexicalElementType.WhiteSpace || nextItem.LexicalElementType == LexicalElementType.EndOfLine))
            {
                this.AddViolation(token.FindParentElement(), token.LineNumber, Rules.OpeningSquareBracketsMustBeSpacedCorrectly);
            }
        }

        /// <summary>
        /// Checks a close bracket for spacing.
        /// </summary>
        /// <param name="root">The container to parse.</param>
        /// <param name="token">The token to check.</param>
        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Minimizing refactoring before release.")]
        private void CheckCloseSquareBracket(CodeUnit root, Token token)
        {
            Param.AssertNotNull(root, "root");
            Param.AssertNotNull(token, "token");

            // Close brackets should never be preceded by whitespace.
            LexicalElement previousItem = token.FindNextLexicalElement();
            if (previousItem != null &&
                (previousItem.LexicalElementType == LexicalElementType.WhiteSpace || previousItem.LexicalElementType == LexicalElementType.EndOfLine))
            {
                this.AddViolation(token.FindParentElement(), token.LineNumber, Rules.ClosingSquareBracketsMustBeSpacedCorrectly);
            }

            // Close brackets should be followed either by whitespace, a bracket,
            // a paren, a semicolon, a comma, a period, or an increment or decrement symbol.
            LexicalElement nextItem = token.FindNextLexicalElement();
            if (nextItem != null)
            {
                if (nextItem.LexicalElementType != LexicalElementType.WhiteSpace &&
                    nextItem.LexicalElementType != LexicalElementType.EndOfLine &&
                    !nextItem.Is(TokenType.CloseParenthesis) &&
                    !nextItem.Is(TokenType.OpenParenthesis) &&      // someDictionary["Test"]();
                    !nextItem.Is(TokenType.CloseSquareBracket) &&   // someIndexer[someArray[1]] = 2;
                    !nextItem.Is(TokenType.OpenSquareBracket) &&    // someArray[1][2] = 2;
                    !nextItem.Is(TokenType.Semicolon) &&
                    !nextItem.Is(TokenType.Comma) &&
                    !nextItem.Is(TokenType.CloseGenericBracket) &&
                    nextItem.Text != "++" &&
                    nextItem.Text != "--" &&
                    !nextItem.Text.StartsWith(".", StringComparison.Ordinal))
                {
                    this.AddViolation(token.FindParentElement(), token.LineNumber, Rules.ClosingSquareBracketsMustBeSpacedCorrectly);
                }

                if (nextItem.LexicalElementType == LexicalElementType.WhiteSpace)
                {
                    // If this is followed by whitespace, make sure that the character just
                    // after the whitespace is not a paren, bracket, comma, or semicolon.
                    for (LexicalElement item = nextItem.FindNextLexicalElement(); item != null; item = item.FindNextLexicalElement())
                    {
                        if (item.Is(TokenType.CloseParenthesis) ||
                            item.Is(TokenType.OpenParenthesis) ||
                            item.Is(TokenType.CloseSquareBracket) ||
                            item.Is(TokenType.OpenSquareBracket) ||
                            item.Is(TokenType.Semicolon) ||
                            item.Is(TokenType.Comma))
                        {
                            this.AddViolation(token.FindParentElement(), token.LineNumber, Rules.ClosingSquareBracketsMustBeSpacedCorrectly);
                        }
                        else if (item.LexicalElementType != LexicalElementType.WhiteSpace)
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
        /// <param name="root">The container to parse.</param>
        /// <param name="token">The token to check.</param>
        private void CheckOpenCurlyBracket(CodeUnit root, Token token)
        {
            Param.AssertNotNull(root, "root");
            Param.AssertNotNull(token, "token");

            // Open curly brackets should be preceded either by whitespace, or an open paren.
            LexicalElement previousItem = token.FindPreviousLexicalElement();
            if (previousItem != null)
            {
                if (previousItem.LexicalElementType != LexicalElementType.WhiteSpace &&
                    previousItem.LexicalElementType != LexicalElementType.EndOfLine &&
                    !previousItem.Is(TokenType.OpenParenthesis))
                {
                    this.AddViolation(token.FindParentElement(), token.LineNumber, Rules.OpeningCurlyBracketsMustBeSpacedCorrectly);
                }

                if (previousItem.LexicalElementType == LexicalElementType.WhiteSpace)
                {
                    // If this is preceded by whitespace, make sure that the character just
                    // before the whitespace is not an open paren.
                    for (LexicalElement item = previousItem.FindPreviousLexicalElement(); item != null; item = item.FindPreviousLexicalElement())
                    {
                        if (item.Is(TokenType.OpenParenthesis))
                        {
                            this.AddViolation(token.FindParentElement(), token.LineNumber, Rules.OpeningCurlyBracketsMustBeSpacedCorrectly);
                        }
                        else if (item.LexicalElementType != LexicalElementType.WhiteSpace)
                        {
                            break;
                        }
                    }
                }
            }

            // Open curly brackets should always be followed by whitespace.
            LexicalElement nextItem = token.FindNextLexicalElement();
            if (nextItem != null &&
                nextItem.LexicalElementType != LexicalElementType.WhiteSpace &&
                nextItem.LexicalElementType != LexicalElementType.EndOfLine)
            {
                this.AddViolation(token.FindParentElement(), token.LineNumber, Rules.OpeningCurlyBracketsMustBeSpacedCorrectly);
            }
        }

        /// <summary>
        /// Checks a close bracket for spacing.
        /// </summary>
        /// <param name="root">The container to parse.</param>
        /// <param name="token">The token to check.</param>
        private void CheckCloseCurlyBracket(CodeUnit root, Token token)
        {
            Param.AssertNotNull(root, "root");
            Param.AssertNotNull(token, "token");

            // Close curly brackets should always be preceded by whitespace.
            LexicalElement previousItem = token.FindPreviousLexicalElement();
            if (previousItem != null &&
                previousItem.LexicalElementType != LexicalElementType.WhiteSpace &&
                previousItem.LexicalElementType != LexicalElementType.EndOfLine)
            {
                this.AddViolation(token.FindParentElement(), token.LineNumber, Rules.ClosingCurlyBracketsMustBeSpacedCorrectly);
            }

            // Close curly brackets should be followed either by whitespace, a close paren,
            // a semicolon, or a comma.
            LexicalElement nextItem = token.FindNextLexicalElement();
            if (nextItem != null)
            {
                if (nextItem.LexicalElementType != LexicalElementType.WhiteSpace &&
                    nextItem.LexicalElementType != LexicalElementType.EndOfLine &&
                    !nextItem.Is(TokenType.CloseParenthesis) &&
                    !nextItem.Is(TokenType.Semicolon) &&
                    !nextItem.Is(TokenType.Comma))
                {
                    this.AddViolation(token.FindParentElement(), token.LineNumber, Rules.ClosingCurlyBracketsMustBeSpacedCorrectly);
                }

                if (nextItem.LexicalElementType == LexicalElementType.WhiteSpace)
                {
                    // If this is followed by whitespace, make sure that the character just
                    // after the whitespace is not a close paren, semicolon, or comma.
                    for (LexicalElement item = nextItem.FindNextLexicalElement(); item != null; item = item.FindNextLexicalElement())
                    {
                        if (item.Is(TokenType.CloseParenthesis) ||
                            item.Is(TokenType.Semicolon) ||
                            item.Is(TokenType.Comma))
                        {
                            this.AddViolation(token.FindParentElement(), token.LineNumber, Rules.ClosingCurlyBracketsMustBeSpacedCorrectly);
                        }
                        else if (item.LexicalElementType != LexicalElementType.WhiteSpace)
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
        /// <param name="token">The token to check.</param>
        private void CheckGenericTokenOpenBracket(Token token)
        {
            Param.AssertNotNull(token, "token");

            // Open generic brackets should be never be preceded by whitespace.
            LexicalElement previousItem = token.FindPreviousLexicalElement();
            if (previousItem != null)
            {
                if (previousItem.LexicalElementType == LexicalElementType.WhiteSpace ||
                    previousItem.LexicalElementType == LexicalElementType.EndOfLine)
                {
                    this.AddViolation(token.FindParentElement(), token.LineNumber, Rules.OpeningGenericBracketsMustBeSpacedCorrectly);
                }
            }

            // Open brackets should never be followed by whitespace.
            LexicalElement nextItem = token.FindNextLexicalElement();
            if (nextItem != null &&
                (nextItem.LexicalElementType == LexicalElementType.WhiteSpace || nextItem.LexicalElementType == LexicalElementType.EndOfLine))
            {
                this.AddViolation(token.FindParentElement(), token.LineNumber, Rules.OpeningGenericBracketsMustBeSpacedCorrectly);
            }
        }

        /// <summary>
        /// Checks a closing generic bracket for spacing.
        /// </summary>
        /// <param name="token">The token to check.</param>
        private void CheckGenericTokenCloseBracket(Token token)
        {
            Param.AssertNotNull(token, "token");

            // Closing generic brackets should be never be preceded by whitespace.
            LexicalElement previousItem = token.FindPreviousLexicalElement();
            if (previousItem != null)
            {
                if (previousItem.LexicalElementType == LexicalElementType.WhiteSpace ||
                    previousItem.LexicalElementType == LexicalElementType.EndOfLine)
                {
                    this.AddViolation(token.FindParentElement(), token.LineNumber, Rules.ClosingGenericBracketsMustBeSpacedCorrectly);
                }
            }
        }

        /// <summary>
        /// Checks a open attribute bracket for spacing.
        /// </summary>
        /// <param name="token">The token to check.</param>
        private void CheckAttributeTokenOpenBracket(Token token)
        {
            Param.AssertNotNull(token, "token");

            // Open brackets should never be followed by whitespace.
            LexicalElement nextItem = token.FindNextLexicalElement();
            if (nextItem != null &&
                (nextItem.LexicalElementType == LexicalElementType.WhiteSpace || nextItem.LexicalElementType == LexicalElementType.EndOfLine))
            {
                this.AddViolation(token.FindParentElement(), token.LineNumber, Rules.OpeningAttributeBracketsMustBeSpacedCorrectly);
            }
        }

        /// <summary>
        /// Checks a closing attribute bracket for spacing.
        /// </summary>
        /// <param name="token">The token to check.</param>
        private void CheckAttributeTokenCloseBracket(Token token)
        {
            Param.AssertNotNull(token, "token");

            // Closing attribute brackets should be never be preceded by whitespace.
            LexicalElement previousItem = token.FindPreviousLexicalElement();
            if (previousItem != null)
            {
                if (previousItem.LexicalElementType == LexicalElementType.WhiteSpace ||
                    previousItem.LexicalElementType == LexicalElementType.EndOfLine)
                {
                    this.AddViolation(token.FindParentElement(), token.LineNumber, Rules.ClosingAttributeBracketsMustBeSpacedCorrectly);
                }
            }
        }

        /// <summary>
        /// Checks a nullable type symbol for spacing.
        /// </summary>
        /// <param name="token">The token to check.</param>
        private void CheckNullableTypeSymbol(Token token)
        {
            Param.AssertNotNull(token, "token");

            // Nullable type symbols should never be preceded by whitespace.
            LexicalElement previousItem = token.FindPreviousLexicalElement();
            if (previousItem != null &&
                (previousItem.LexicalElementType == LexicalElementType.WhiteSpace || previousItem.LexicalElementType == LexicalElementType.EndOfLine))
            {
                this.AddViolation(token.FindParentElement(), token.LineNumber, Rules.NullableTypeSymbolsMustNotBePrecededBySpace);
            }
        }

        /// <summary>
        /// Checks a member access symbol for spacing.
        /// </summary>
        /// <param name="root">The container to parse.</param>
        /// <param name="token">The token to check.</param>
        private void CheckMemberAccessSymbol(CodeUnit root, Token token)
        {
            Param.AssertNotNull(root, "root");
            Param.AssertNotNull(token, "token");

            // Member access symbols should not have any whitespace on either side.
            LexicalElement previousItem = token.FindPreviousLexicalElement();
            if (previousItem == null)
            {
                if (previousItem.LexicalElementType == LexicalElementType.WhiteSpace ||
                    previousItem.LexicalElementType == LexicalElementType.EndOfLine ||
                    previousItem.Is(CommentType.SingleLineComment) ||
                    previousItem.Is(CommentType.MultilineComment))
                {
                    this.AddViolation(token.FindParentElement(), token.LineNumber, Rules.MemberAccessSymbolsMustBeSpacedCorrectly);
                }
            }

            LexicalElement nextItem = token.FindNextLexicalElement();
            if (nextItem == null)
            {
                if (nextItem.LexicalElementType == LexicalElementType.WhiteSpace ||
                    nextItem.LexicalElementType == LexicalElementType.EndOfLine ||
                    nextItem.Is(CommentType.SingleLineComment) ||
                    nextItem.Is(CommentType.MultilineComment))
                {
                    // Make sure the previous token is not the operator keyword.
                    if (previousItem != null)
                    {
                        for (LexicalElement item = previousItem.FindPreviousLexicalElement(); item != null; item = item.FindPreviousLexicalElement())
                        {
                            if (item.Is(TokenType.Operator))
                            {
                                return;
                            }
                            else if (item.LexicalElementType != LexicalElementType.WhiteSpace &&
                                item.LexicalElementType != LexicalElementType.EndOfLine &&
                                !item.Is(CommentType.SingleLineComment) &&
                                !item.Is(CommentType.MultilineComment))
                            {
                                break;
                            }
                        }
                    }

                    this.AddViolation(token.FindParentElement(), token.LineNumber, Rules.MemberAccessSymbolsMustBeSpacedCorrectly);
                }
            }
        }    

        /// <summary>
        /// Checks an increment or decrement sign for spacing.
        /// </summary>
        /// <param name="token">The token to check.</param>
        private void CheckIncrementDecrement(Token token)
        {
            Param.AssertNotNull(token, "token");

            // Increment and decrement symbols should have whitespace on only one side. The non-whitespace
            // side is also allowed to butt up against a bracket or a parenthesis, however.
            bool before = false;
            bool after = false;

            LexicalElement previousItem = token.FindPreviousLexicalElement();
            if (previousItem == null)
            {
                before = true;
            }
            else
            {
                if (previousItem.LexicalElementType == LexicalElementType.WhiteSpace ||
                    previousItem.LexicalElementType == LexicalElementType.EndOfLine ||
                    previousItem.Is(CommentType.SingleLineComment) ||
                    previousItem.Is(CommentType.MultilineComment))
                {
                    before = true;
                }
            }

            LexicalElement nextItem = token.FindNextLexicalElement();
            if (nextItem == null)
            {
                after = true;
            }
            else
            {
                if (nextItem.LexicalElementType == LexicalElementType.WhiteSpace ||
                    nextItem.LexicalElementType == LexicalElementType.EndOfLine ||
                    nextItem.Is(CommentType.SingleLineComment) ||
                    nextItem.Is(CommentType.MultilineComment))
                {
                    after = true;
                }
            }

            // If there is no whitespace on either side, then make sure that at least one of the sides
            // is touching a square bracket or a parenthesis. The right side of the symbol is also
            // allowed to be up against a comma or a semicolon.
            if (!before && !after)
            {
                if (previousItem != null &&
                    (previousItem.Is(TokenType.OpenSquareBracket) || previousItem.Is(TokenType.OpenParenthesis)))
                {
                    return;
                }

                if (nextItem != null)
                {
                    if (nextItem.Is(TokenType.CloseSquareBracket) ||
                        nextItem.Is(TokenType.CloseParenthesis) ||
                        nextItem.Is(TokenType.Comma) ||
                        nextItem.Is(TokenType.Semicolon))
                    {
                        return;
                    }
                }

                // This is a violation.
                this.AddViolation(token.FindParentElement(), token.LineNumber, Rules.IncrementDecrementSymbolsMustBeSpacedCorrectly);
            }
            else if (before && after)
            {
                // There is whitespace on both sides.
                this.AddViolation(token.FindParentElement(), token.LineNumber, Rules.IncrementDecrementSymbolsMustBeSpacedCorrectly);
            }
        }

        /// <summary>
        /// Checks a negative sign for spacing.
        /// </summary>
        /// <param name="token">The token to check.</param>
        private void CheckNegativeSign(Token token)
        {
            Param.AssertNotNull(token, "token");

            // A negative sign should be preceded by whitespace. It 
            // can also be preceded by an open paren or an open bracket.
            LexicalElement previousItem = token.FindPreviousLexicalElement();
            if (previousItem != null)
            {
                if (previousItem.LexicalElementType != LexicalElementType.WhiteSpace &&
                    previousItem.LexicalElementType != LexicalElementType.EndOfLine &&
                    !previousItem.Is(TokenType.OpenParenthesis) &&
                    !previousItem.Is(TokenType.OpenSquareBracket) &&
                    !previousItem.Is(TokenType.CloseParenthesis))
                {
                    this.AddViolation(token.FindParentElement(), token.LineNumber, Rules.NegativeSignsMustBeSpacedCorrectly);
                }
            }

            LexicalElement nextItem = token.FindNextLexicalElement();
            if (nextItem != null)
            {
                if (nextItem.LexicalElementType == LexicalElementType.WhiteSpace ||
                    nextItem.LexicalElementType == LexicalElementType.EndOfLine ||
                    nextItem.Is(CommentType.SingleLineComment) ||
                    nextItem.Is(CommentType.MultilineComment))
                {
                    this.AddViolation(token.FindParentElement(), token.LineNumber, Rules.NegativeSignsMustBeSpacedCorrectly);
                }
            }
        }

        /// <summary>
        /// Checks a positive sign for spacing.
        /// </summary>
        /// <param name="token">The token to check.</param>
        private void CheckPositiveSign(Token token)
        {
            Param.AssertNotNull(token, "token");

            // A positive sign should be preceded by whitespace. It 
            // can also be preceded by an open paren or an open bracket.
            LexicalElement previousItem = token.FindPreviousLexicalElement();
            if (previousItem != null)
            {
                if (previousItem.LexicalElementType != LexicalElementType.WhiteSpace &&
                    previousItem.LexicalElementType != LexicalElementType.EndOfLine &&
                    !previousItem.Is(TokenType.OpenParenthesis) &&
                    !previousItem.Is(TokenType.OpenSquareBracket) &&
                    !previousItem.Is(TokenType.CloseParenthesis))
                {
                    this.AddViolation(token.FindParentElement(), token.LineNumber, Rules.PositiveSignsMustBeSpacedCorrectly);
                }
            }

            LexicalElement nextItem = token.FindNextLexicalElement();
            if (nextItem != null)
            {
                if (nextItem.LexicalElementType == LexicalElementType.WhiteSpace ||
                    nextItem.LexicalElementType == LexicalElementType.EndOfLine ||
                    nextItem.Is(CommentType.SingleLineComment) ||
                    nextItem.Is(CommentType.MultilineComment))
                {
                    this.AddViolation(token.FindParentElement(), token.LineNumber, Rules.PositiveSignsMustBeSpacedCorrectly);
                }
            }
        }

        /// <summary>
        /// Checks an unsafe pointer access symbol sign for spacing.
        /// </summary>
        /// <param name="token">The token to check.</param>
        /// <param name="type">Indicates whether the token is part of a type declaration.</param>
        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Minimizing refactoring before release.")]
        private void CheckUnsafeAccessSymbols(Token token, bool type)
        {
            Param.AssertNotNull(token, "token");
            Param.Ignore(type);

            // In a type declaration, the symbol must have whitespace on the right but
            // not on the left. If this is not a type declaration, the opposite is true.
            if (type)
            {
                // The symbol should be followed by whitespace. It 
                // can also be followed by a closing paren or a closing bracket,
                // or another token of the same type.
                LexicalElement nextItem = token.FindNextLexicalElement();
                if (nextItem != null)
                {
                    if (nextItem.LexicalElementType != LexicalElementType.WhiteSpace &&
                        nextItem.LexicalElementType != LexicalElementType.EndOfLine &&
                        !nextItem.Is(TokenType.OpenParenthesis) &&
                        !nextItem.Is(TokenType.OpenSquareBracket) &&
                        !nextItem.Is(TokenType.CloseParenthesis) &&
                        !nextItem.Is(token.TokenType))
                    {
                        this.AddViolation(token.FindParentElement(), token.LineNumber, Rules.DereferenceAndAccessOfSymbolsMustBeSpacedCorrectly);
                    }
                }

                // The symbol must not be preceded by whitespace.
                LexicalElement previousItem = token.FindPreviousLexicalElement();
                if (previousItem != null)
                {
                    if (previousItem.LexicalElementType == LexicalElementType.WhiteSpace ||
                        previousItem.LexicalElementType == LexicalElementType.EndOfLine ||
                        previousItem.Is(CommentType.SingleLineComment) ||
                        previousItem.Is(CommentType.MultilineComment))
                    {
                        this.AddViolation(token.FindParentElement(), token.LineNumber, Rules.DereferenceAndAccessOfSymbolsMustBeSpacedCorrectly);
                    }
                }
            }
            else
            {
                // The symbol should be preceded by whitespace. It 
                // can also be preceded by an open paren or an open bracket, or
                // another token of the same type.
                LexicalElement previousItem = token.FindPreviousLexicalElement();
                if (previousItem != null)
                {
                    if (previousItem.LexicalElementType != LexicalElementType.WhiteSpace &&
                        previousItem.LexicalElementType != LexicalElementType.EndOfLine &&
                        !previousItem.Is(TokenType.OpenParenthesis) &&
                        !previousItem.Is(TokenType.OpenSquareBracket) &&
                        !previousItem.Is(TokenType.CloseParenthesis) &&
                        !previousItem.Is(token.TokenType))
                    {
                        this.AddViolation(token.FindParentElement(), token.LineNumber, Rules.DereferenceAndAccessOfSymbolsMustBeSpacedCorrectly);
                    }
                }

                // The symbol must not be followed by whitespace.
                LexicalElement nextItem = token.FindNextLexicalElement();
                if (nextItem == null)
                {
                    if (nextItem.LexicalElementType == LexicalElementType.WhiteSpace ||
                        nextItem.LexicalElementType == LexicalElementType.EndOfLine ||
                        nextItem.Is(CommentType.SingleLineComment) ||
                        nextItem.Is(CommentType.MultilineComment))
                    {
                        this.AddViolation(token.FindParentElement(), token.LineNumber, Rules.DereferenceAndAccessOfSymbolsMustBeSpacedCorrectly);
                    }
                }
            }
        }

        /// <summary>
        /// Checks a label colon for spacing.
        /// </summary>
        /// <param name="token">The token to check.</param>
        private void CheckLabelColon(Token token)
        {
            Param.AssertNotNull(token, "token");

            // A colon should always be followed by whitespace, but never preceded by whitespace.
            LexicalElement nextItem = token.FindNextLexicalElement();
            if (nextItem == null)
            {
                if (nextItem.LexicalElementType != LexicalElementType.WhiteSpace &&
                    nextItem.LexicalElementType != LexicalElementType.EndOfLine)
                {
                    this.AddViolation(token.FindParentElement(), token.LineNumber, Rules.ColonsMustBeSpacedCorrectly);
                }
            }

            LexicalElement previousItem = token.FindPreviousLexicalElement();
            if (previousItem != null)
            {
                if (previousItem.LexicalElementType == LexicalElementType.WhiteSpace ||
                    previousItem.LexicalElementType == LexicalElementType.EndOfLine ||
                    previousItem.Is(CommentType.SingleLineComment) ||
                    previousItem.Is(CommentType.MultilineComment))
                {
                    this.AddViolation(token.FindParentElement(), token.LineNumber, Rules.ColonsMustBeSpacedCorrectly);
                }
            }
        }

        /// <summary>
        /// Checks a unary symbol for spacing.
        /// </summary>
        /// <param name="token">The token to check.</param>
        private void CheckUnarySymbol(Token token)
        {
            Param.AssertNotNull(token, "token");

            // These symbols should be preceded by whitespace but not followed by whitespace. They can
            // also be preceded by an open paren or an open square bracket.
            LexicalElement previousItem = token.FindPreviousLexicalElement();
            if (previousItem != null)
            {
                if (previousItem.LexicalElementType != LexicalElementType.WhiteSpace &&
                    previousItem.LexicalElementType != LexicalElementType.EndOfLine &&
                    !previousItem.Is(TokenType.OpenParenthesis) &&
                    !previousItem.Is(TokenType.OpenSquareBracket))
                {
                    this.AddViolation(token.FindParentElement(), token.LineNumber, Rules.SymbolsMustBeSpacedCorrectly, token.Text);
                }
            }

            LexicalElement nextItem = token.FindNextLexicalElement();
            if (nextItem == null)
            {
                if (nextItem.LexicalElementType == LexicalElementType.WhiteSpace ||
                    nextItem.LexicalElementType == LexicalElementType.EndOfLine ||
                    nextItem.Is(CommentType.SingleLineComment) ||
                    nextItem.Is(CommentType.MultilineComment))
                {
                    this.AddViolation(token.FindParentElement(), token.LineNumber, Rules.SymbolsMustBeSpacedCorrectly, token.Text);
                }
            }
        }

        /// <summary>
        /// Checks to make sure that there is not too many whitespace symbols in a row.
        /// </summary>
        /// <param name="whitespace">The whitespace to check.</param>
        private void CheckWhitespace(Whitespace whitespace)
        {
            Param.AssertNotNull(whitespace, "whitespace");

            if (whitespace.TabCount > 0)
            {
                // Tabs are not allowed.
                this.AddViolation(whitespace.FindParentElement(), whitespace.LineNumber, Rules.TabsMustNotBeUsed);
            }
            else if (whitespace.TabCount == 0 && whitespace.SpaceCount > 1)
            {
                // Multiple spaces in a row are only allowed at the beginning of a line, following 
                // a comma or semicolon, preceding a symbol, or at the end of a line.
                LexicalElement nextItem = whitespace.FindNextLexicalElement();
                LexicalElement previousItem = whitespace.FindPreviousLexicalElement();
                if (previousItem != null &&
                    previousItem.LexicalElementType != LexicalElementType.EndOfLine &&
                    !previousItem.Is(TokenType.Comma) &&
                    !previousItem.Is(TokenType.Semicolon) &&
                    nextItem != null &&
                    !nextItem.Is(TokenType.OperatorSymbol) &&
                    !nextItem.Is(LexicalElementType.EndOfLine) &&
                    !nextItem.Is(CommentType.SingleLineComment) &&
                    !nextItem.Is(CommentType.MultilineComment))
                {
                    this.AddViolation(whitespace.FindParentElement(), whitespace.LineNumber, Rules.CodeMustNotContainMultipleWhitespaceInARow);
                }
            }
        }

        /// <summary>
        /// Checks for tabs in the given comment.
        /// </summary>
        /// <param name="comment">The comment token.</param>
        private void CheckTabsInComment(LexicalElement comment)
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
