// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LayoutRules.cs" company="https://github.com/StyleCop">
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
//   Checks layout rules.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    using System;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    /// <summary>
    /// Checks layout rules.
    /// </summary>
    [SourceAnalyzer(typeof(CsParser))]
    public class LayoutRules : SourceAnalyzer
    {
        #region Public Methods and Operators

        /// <summary>
        /// Checks the placement of brackets within the given document.
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
                // Check placement of curly brackets.
                csdocument.WalkDocument(this.VisitElement, this.CheckStatementCurlyBracketPlacement, this.CheckExpressionCurlyBracketPlacement);

                // Check line spacing rules.
                this.CheckLineSpacing(csdocument);
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
        /// Determines whether the given bracket is the only thing on its line or whether it shares the line.
        /// </summary>
        /// <param name="bracketNode">
        /// The bracket to check.
        /// </param>
        /// <param name="allowTrailingCharacters">
        /// Indicates whether a semicolon, comma or closing parenthesis after the 
        /// bracket is allowed.
        /// </param>
        /// <returns>
        /// Returns true if the bracket shares the line with something else.
        /// </returns>
        private static bool BracketSharesLine(Node<CsToken> bracketNode, bool allowTrailingCharacters)
        {
            Param.AssertNotNull(bracketNode, "bracketNode");
            Param.Ignore(allowTrailingCharacters);

            // Look forward.
            bool sharesLine = false;

            // Find the next non-whitespace or comment token.
            CsToken nextToken = null;
            for (Node<CsToken> tokenNode = bracketNode.Next; tokenNode != null; tokenNode = tokenNode.Next)
            {
                CsToken token = tokenNode.Value;
                if (token.CsTokenType == CsTokenType.EndOfLine)
                {
                    break;
                }
                else if (token.CsTokenType != CsTokenType.WhiteSpace && token.CsTokenType != CsTokenType.SingleLineComment
                         && token.CsTokenType != CsTokenType.MultiLineComment)
                {
                    nextToken = token;
                    break;
                }
            }

            if (nextToken != null)
            {
                if (!allowTrailingCharacters
                    || (nextToken.CsTokenType != CsTokenType.Semicolon && nextToken.CsTokenType != CsTokenType.Comma && !IsTokenADot(nextToken)
                        && nextToken.CsTokenType != CsTokenType.CloseParenthesis && nextToken.CsTokenType != CsTokenType.CloseSquareBracket))
                {
                    sharesLine = true;
                }
            }

            if (!sharesLine)
            {
                // Look backwards.
                for (Node<CsToken> tokenNode = bracketNode.Previous; tokenNode != null; tokenNode = tokenNode.Previous)
                {
                    CsToken token = tokenNode.Value;

                    if (token.CsTokenType == CsTokenType.EndOfLine)
                    {
                        break;
                    }
                    else if (token.CsTokenType != CsTokenType.WhiteSpace && token.CsTokenType != CsTokenType.SingleLineComment)
                    {
                        sharesLine = true;
                        break;
                    }
                }
            }

            return sharesLine;
        }

        /// <summary>
        /// 4
        /// Determines whether the given accessor contains a body. 
        /// </summary>
        /// <param name="accessor">
        /// The accessor to check.
        /// </param>
        /// <returns>
        /// Returns true if the accessor contains a body.
        /// </returns>
        private static bool DoesAccessorHaveBody(Accessor accessor)
        {
            Param.AssertNotNull(accessor, "accessor");

            for (Node<CsToken> node = accessor.Tokens.First; node != accessor.Tokens.Last; node = node.Next)
            {
                if (node.Value.CsTokenType == CsTokenType.OpenCurlyBracket)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Gets the first child statement of the given statement, if one exists.
        /// </summary>
        /// <param name="statement">
        /// The statement.
        /// </param>
        /// <returns>
        /// Returns the first child statement or null if none exist.
        /// </returns>
        private static Statement GetFirstChildStatement(Statement statement)
        {
            Param.AssertNotNull(statement, "statement");

            if (statement.ChildStatements != null && statement.ChildStatements.Count > 0)
            {
                foreach (Statement childStatement in statement.ChildStatements)
                {
                    return childStatement;
                }
            }

            return null;
        }

        /// <summary>
        /// Gets the first open curly bracket in the token list.
        /// </summary>
        /// <param name="tokens">
        /// The list of tokens.
        /// </param>
        /// <returns>
        /// Returns the first open curly bracket or -1 if there are none.
        /// </returns>
        private static Node<CsToken> GetOpenBracket(CsTokenList tokens)
        {
            Param.AssertNotNull(tokens, "tokens");

            for (Node<CsToken> tokenNode = tokens.First; !tokens.OutOfBounds(tokenNode); tokenNode = tokenNode.Next)
            {
                if (tokenNode.Value.CsTokenType == CsTokenType.OpenCurlyBracket)
                {
                    return tokenNode;
                }
            }

            return null;
        }

        /// <summary>
        /// Gets friendly output text for "opening" or "closing", depending on the type of the bracket.
        /// </summary>
        /// <param name="bracket">
        /// The bracket.
        /// </param>
        /// <returns>
        /// Returns the opening or closing text.
        /// </returns>
        private static string GetOpeningOrClosingBracketText(Bracket bracket)
        {
            Param.AssertNotNull(bracket, "bracket");

            switch (bracket.CsTokenType)
            {
                case CsTokenType.OpenAttributeBracket:
                case CsTokenType.OpenCurlyBracket:
                case CsTokenType.OpenGenericBracket:
                case CsTokenType.OpenParenthesis:
                case CsTokenType.OpenSquareBracket:
                    return Strings.Opening;

                case CsTokenType.CloseAttributeBracket:
                case CsTokenType.CloseCurlyBracket:
                case CsTokenType.CloseGenericBracket:
                case CsTokenType.CloseParenthesis:
                case CsTokenType.CloseSquareBracket:
                    return Strings.Closing;

                default:
                    Debug.Fail("Invalid bracket type.");
                    return string.Empty;
            }
        }

        /// <summary>
        /// Determines whether the given property is an automatic property.
        /// </summary>
        /// <param name="property">
        /// The property to check.
        /// </param>
        /// <returns>
        /// Returns true if the property is an automatic property.
        /// </returns>
        private static bool IsAutomaticProperty(Property property)
        {
            Param.AssertNotNull(property, "property");

            if (property.GetAccessor != null)
            {
                return !DoesAccessorHaveBody(property.GetAccessor);
            }

            if (property.SetAccessor != null)
            {
                return !DoesAccessorHaveBody(property.SetAccessor);
            }

            return false;
        }

        /// <summary>
        /// Determines whether the given token is part of a file header. It is considered
        /// part of a file header if the only tokens in front of it are single-line comments,
        /// preprocessor directives, whitespace, or newlines.
        /// </summary>
        /// <param name="comment">
        /// The comment to check.
        /// </param>
        /// <returns>
        /// Returns true if the comment is part of a file header.
        /// </returns>
        private static bool IsCommentInFileHeader(Node<CsToken> comment)
        {
            Param.AssertNotNull(comment, "comment");

            Node<CsToken> token = comment;
            while (token != null)
            {
                if (token.Value.CsTokenType != CsTokenType.SingleLineComment && token.Value.CsTokenType != CsTokenType.WhiteSpace
                    && token.Value.CsTokenType != CsTokenType.EndOfLine && token.Value.CsTokenType != CsTokenType.PreprocessorDirective)
                {
                    return false;
                }

                token = token.Previous;
            }

            return true;
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
        /// Checks the placement of curly brackets within the given item.
        /// </summary>
        /// <param name="parentElement">
        /// The element containing the brackets.
        /// </param>
        /// <param name="parentStatement">
        /// The statement containing the brackets, if any.
        /// </param>
        /// <param name="tokens">
        /// The statement or element token list.
        /// </param>
        /// <param name="openBracketNode">
        /// The opening curly bracket within the token list.
        /// </param>
        /// <param name="allowAllOnOneLine">
        /// Indicates whether the brackets are allowed to be all on one line.
        /// </param>
        private void CheckBracketPlacement(CsElement parentElement, Statement parentStatement, CsTokenList tokens, Node<CsToken> openBracketNode, bool allowAllOnOneLine)
        {
            Param.AssertNotNull(parentElement, "parentElement");
            Param.Ignore(parentStatement);
            Param.AssertNotNull(tokens, "tokens");
            Param.AssertNotNull(openBracketNode, "openBracketNode");
            Param.Ignore(allowAllOnOneLine);

            Bracket openBracket = (Bracket)openBracketNode.Value;

            if (openBracket.MatchingBracket != null && !openBracket.Generated && !openBracket.MatchingBracket.Generated)
            {
                // Check if the two brackets are on the same line as each other.
                if (openBracket.LineNumber == openBracket.MatchingBracket.LineNumber)
                {
                    // This is an error if the brackets are not allowed to be all on the same line.
                    if (!allowAllOnOneLine)
                    {
                        // Statements within constructor initializers are allowed to be all on the same line
                        // since sometimes this is the only way to write the statement.
                        if (parentStatement == null)
                        {
                            this.AddViolation(parentElement, openBracket.LineNumber, Rules.ElementMustNotBeOnSingleLine, parentElement.FriendlyTypeText);
                        }
                        else if (parentStatement.StatementType != StatementType.ConstructorInitializer)
                        {
                            this.AddViolation(parentElement, openBracket.LineNumber, Rules.StatementMustNotBeOnSingleLine);
                        }
                    }
                    else
                    {
                        // The brackets are only allowed to be on the same line if the entire statement is on the same line
                        // or if the next line contains property initializers.
                        if (tokens.First.Value.LineNumber != tokens.Last.Value.LineNumber)
                        {
                            bool isViolation = true;

                            if (parentStatement is VariableDeclarationStatement)
                            {
                                VariableDeclarationStatement variableDeclarationStatement = parentStatement as VariableDeclarationStatement;

                                foreach (VariableDeclaratorExpression declarator in variableDeclarationStatement.Declarators)
                                {
                                    if (declarator.Initializer.ChildExpressions.Any(
                                            initializerExpressions => initializerExpressions.ExpressionType == ExpressionType.ObjectInitializer))
                                    {
                                        isViolation = false;
                                        break;
                                    }
                                }
                            }
                            else if (parentElement is Property)
                            {
                                int closingBracketIndex = openBracket.MatchingBracket.Location.EndPoint.Index;

                                var propertyElement = (Property)parentElement;
                                if (propertyElement.Tokens
                                    .SkipWhile(token => token.Location.EndPoint.Index < closingBracketIndex)
                                    .OfType<OperatorSymbol>()
                                    .Any(token => token.SymbolType == OperatorType.Equals))
                                {
                                    isViolation = false;
                                }
                            }
                            
                            if (isViolation)
                            {
                                this.AddViolation(
                                    parentElement, 
                                    openBracket.LineNumber, 
                                    Rules.CurlyBracketsForMultiLineStatementsMustNotShareLine, 
                                    GetOpeningOrClosingBracketText(openBracket));
                            }
                        }
                    }
                }
                else
                {
                    // The brackets are on different lines. Both brackets must be on a line all by themselves.
                    if (LayoutRules.BracketSharesLine(openBracketNode, false))
                    {
                        this.AddViolation(
                            parentElement, openBracket.LineNumber, Rules.CurlyBracketsForMultiLineStatementsMustNotShareLine, GetOpeningOrClosingBracketText(openBracket));
                    }

                    if (LayoutRules.BracketSharesLine(openBracket.MatchingBracketNode, true))
                    {
                        this.AddViolation(
                            parentElement, 
                            openBracket.MatchingBracket.LineNumber, 
                            Rules.CurlyBracketsForMultiLineStatementsMustNotShareLine, 
                            GetOpeningOrClosingBracketText(openBracket.MatchingBracket));
                    }
                }
            }
        }

        /// <summary>
        /// Checks the spacing of child elements of the given element, to ensure that elements
        /// are separated by a blank line.
        /// </summary>
        /// <param name="element">
        /// The element being visited.
        /// </param>
        private void CheckChildElementSpacing(CsElement element)
        {
            Param.AssertNotNull(element, "element");

            CsElement previousElement = null;

            if (element.ChildElements != null && element.ChildElements.Count > 0)
            {
                foreach (CsElement childElement in element.ChildElements)
                {
                    // Check the line spacing between the two elements if:
                    // - There was a previous element
                    // - AND neither of the elements are generated
                    // - AND the previous element and the current element are of different types
                    // - - OR the current element has a header
                    // - - OR the previous element spans multiple lines (if not an assembly attribute)
                    // - - OR the elements are not using directives, extern alias directives, accessors, enum items, or fields.
                    if (previousElement != null && (!previousElement.Generated && !childElement.Generated))
                    {
                        if (previousElement.ElementType != childElement.ElementType || childElement.Header != null
                            || (previousElement.Location.LineSpan > 1 && childElement.ElementType != ElementType.AssemblyOrModuleAttribute)
                            || (childElement.ElementType != ElementType.UsingDirective && childElement.ElementType != ElementType.ExternAliasDirective
                                && childElement.ElementType != ElementType.Accessor && childElement.ElementType != ElementType.EnumItem
                                && childElement.ElementType != ElementType.Field && childElement.ElementType != ElementType.AssemblyOrModuleAttribute))
                        {
                            // The start line of this element is the first line of the header if there is one,
                            // or the first line of the element itself if there is no header.
                            int startLine = childElement.LineNumber;
                            if (childElement.Header != null)
                            {
                                startLine = childElement.Header.LineNumber;
                            }

                            if (startLine == previousElement.Location.EndPoint.LineNumber || startLine == previousElement.Location.EndPoint.LineNumber + 1)
                            {
                                this.AddViolation(childElement, Rules.ElementsMustBeSeparatedByBlankLine);
                            }
                        }
                    }

                    previousElement = childElement;
                }
            }
        }

        /// <summary>
        /// Checks the placement of curly brackets on the current element.
        /// </summary>
        /// <param name="element">
        /// The element to check.
        /// </param>
        /// <param name="allowAllOnOneLine">
        /// Indicates whether the brackets are allowed to be all on one line.
        /// </param>
        private void CheckElementBracketPlacement(CsElement element, bool allowAllOnOneLine)
        {
            Param.AssertNotNull(element, "element");
            Param.Ignore(allowAllOnOneLine);

            // Get the absolute index of the last token from the element declaration.
            CsToken lastDeclarationToken = null;
            if (element.Declaration.Tokens.First != null)
            {
                lastDeclarationToken = element.Declaration.Tokens.Last.Value;
            }

            // Find the opening curly bracket within this element.
            bool last = false;
            for (Node<CsToken> tokenNode = element.Tokens.First; !element.Tokens.OutOfBounds(tokenNode); tokenNode = tokenNode.Next)
            {
                if (lastDeclarationToken == null || last)
                {
                    if (tokenNode.Value.CsTokenType == CsTokenType.Equals)
                    {
                        // If we have found an equals sign in the element declaration before finding any opening curly bracket
                        // then this is not a bracketed element. This could be something like the following examples:
                        // int[] x = new int[] { 1, 2, 3 };
                        // event EventHandler x = (sender, e) => { };
                        // In both of these cases, it's allowed to put the statement on a single line.
                        allowAllOnOneLine = true;
                    }
                    else if (tokenNode.Value.CsTokenType == CsTokenType.OpenCurlyBracket)
                    {
                        this.CheckBracketPlacement(element, null, element.Tokens, tokenNode, allowAllOnOneLine);

                        if (allowAllOnOneLine && element.ElementType == ElementType.Accessor)
                        {
                            // If this accessor is all one one line, any other accessors in this 
                            // property must also be all on one line.
                            this.CheckSiblingAccessors(element, tokenNode);
                        }

                        break;
                    }
                }

                if (!last)
                {
                    last = tokenNode.Value == lastDeclarationToken;
                }
            }
        }

        /// <summary>
        /// Checks the curly brackets under the given element.
        /// </summary>
        /// <param name="element">
        /// The element being visited.
        /// </param>
        private void CheckElementCurlyBracketPlacement(CsElement element)
        {
            Param.AssertNotNull(element, "element");

            if (!element.Generated)
            {
                // Check the type of the element.
                if (element.ElementType == ElementType.Accessor)
                {
                    // Curly brackets are allowed to be all on one line for accessors.
                    this.CheckElementBracketPlacement(element, true);
                }
                else if (element.ElementType == ElementType.Class || element.ElementType == ElementType.Constructor || element.ElementType == ElementType.Destructor
                         || element.ElementType == ElementType.Enum || element.ElementType == ElementType.Event || element.ElementType == ElementType.Indexer
                         || element.ElementType == ElementType.Interface || element.ElementType == ElementType.Method || element.ElementType == ElementType.Namespace
                         || element.ElementType == ElementType.Struct)
                {
                    bool allowOnOneLine = false;

                    // Curly brackets for these types cannot be all on one line.
                    if (element.ElementType == ElementType.Indexer)
                    {
                        CsElement parentElement = element.FindParentElement();

                        // If its an indexer on an interface then it can be on one line.
                        // An indexer on an abstract class is also ok.
                        if (parentElement != null)
                        {
                            if (parentElement.ElementType == ElementType.Interface
                                || (parentElement.ElementType == ElementType.Class && parentElement.Declaration.ContainsModifier(CsTokenType.Abstract)))
                            {
                                allowOnOneLine = true;
                            }
                        }
                    }

                    this.CheckElementBracketPlacement(element, allowOnOneLine);
                }
                else if (element.ElementType == ElementType.Property)
                {
                    Property itemBeingInspected = (Property)element;

                    // Automatic/Expression bodied properties are allowed to be on a single line, but normal properties are not.
                    bool allowAllOnOneLine = IsAutomaticProperty(itemBeingInspected) ||
                        (itemBeingInspected.ChildStatements.Count == 1 &&
                         itemBeingInspected.ChildStatements.First() is ExpressionStatement);

                    this.CheckElementBracketPlacement(element, allowAllOnOneLine);
                }
            }
        }

        /// <summary>
        /// Checks the curly brackets under the given expression.
        /// </summary>
        /// <param name="expression">
        /// The expression being visited.
        /// </param>
        /// <param name="parentExpression">
        /// The parent expression, if any.
        /// </param>
        /// <param name="parentStatement">
        /// The parent statement, if any.
        /// </param>
        /// <param name="parentElement">
        /// The parent element, if any.
        /// </param>
        /// <param name="context">
        /// The optional visitor context data.
        /// </param>
        /// <returns>
        /// Returns true to continue, or false to stop the walker.
        /// </returns>
        private bool CheckExpressionCurlyBracketPlacement(
            Expression expression, Expression parentExpression, Statement parentStatement, CsElement parentElement, object context)
        {
            Param.AssertNotNull(expression, "expression");
            Param.Ignore(parentExpression);
            Param.Ignore(parentStatement);
            Param.AssertNotNull(parentElement, "parentElement");
            Param.Ignore(context);

            switch (expression.ExpressionType)
            {
                case ExpressionType.AnonymousMethod:
                case ExpressionType.Lambda:

                    // An anonymous method or lambda expression is allowed to be all on a single line as long as the entire
                    // expression is on one line.
                    Node<CsToken> openBracketNode = LayoutRules.GetOpenBracket(expression.Tokens);

                    if (openBracketNode != null && openBracketNode.Value.Parent == expression)
                    {
                        bool allowAllOnOneLine = expression.Location.StartPoint.LineNumber == expression.Location.EndPoint.LineNumber;

                        this.CheckBracketPlacement(parentElement, parentStatement, expression.Tokens, openBracketNode, allowAllOnOneLine);
                    }

                    break;

                case ExpressionType.ArrayInitializer:
                case ExpressionType.ObjectInitializer:
                case ExpressionType.CollectionInitializer:

                    // If this object or collection initializer is a direct child of another
                    // expression, then use the token list of the parent expression.
                    // This ensures that the initializer cannot only exist all on
                    // one single line if it is also on the same line as the rest of the
                    // parent expression. If this is not a direct child of aanother expression, 
                    // this restriction does not apply.
                    CsTokenList tokens = expression.Tokens;
                    Expression expressionParent = expression.Parent as Expression;
                    if (expressionParent != null)
                    {
                        tokens = expressionParent.Tokens;
                    }

                    this.CheckBracketPlacement(parentElement, parentStatement, tokens, LayoutRules.GetOpenBracket(tokens), true);

                    break;

                default:
                    break;
            }

            return true;
        }

        /// <summary>
        /// Checks the line spacing within the given document.
        /// </summary>
        /// <param name="document">
        /// The document to check.
        /// </param>
        private void CheckLineSpacing(CsDocument document)
        {
            Param.AssertNotNull(document, "document");

            // Set up some variables.
            int count = 0;
            Node<CsToken> precedingTokenNode = null;
            bool fileHeader = true;
            bool firstTokenOnLine = true;
            bool lineHasNonWhiteSpace = false;
            bool onlyBlankLinesProcessed = true;
            bool thrownBlankLinesViolation = false;

            // Loop through all the tokens in the document.
            for (Node<CsToken> tokenNode = document.Tokens.First; tokenNode != null; tokenNode = tokenNode.Next)
            {
                // Check for cancel.
                if (this.Cancel)
                {
                    break;
                }

                CsToken token = tokenNode.Value;

                // Check whether we're through the file header yet.
                if (fileHeader && token.CsTokenType != CsTokenType.EndOfLine && token.CsTokenType != CsTokenType.WhiteSpace
                    && token.CsTokenType != CsTokenType.SingleLineComment && token.CsTokenType != CsTokenType.MultiLineComment)
                {
                    fileHeader = false;
                }

                if (tokenNode == document.Tokens.Last)
                {
                    if (token.CsTokenType == CsTokenType.EndOfLine || token.CsTokenType == CsTokenType.WhiteSpace)
                    {
                        if (precedingTokenNode != null)
                        {
                            int preceedingLineLumber = precedingTokenNode.Value is ITokenContainer
                                                           ? ((ITokenContainer)precedingTokenNode.Value).Tokens.Last().LineNumber
                                                           : precedingTokenNode.Value.LineNumber;

                            if (preceedingLineLumber != token.LineNumber)
                            {
                                this.AddViolation(token.FindParentElement(), token.LineNumber, Rules.CodeMustNotContainBlankLinesAtEndOfFile);
                            }
                        }
                    }
                }

                // Check whether this token is an end-of-line character.
                if (token.Text == "\n")
                {
                    ++count;

                    if (!lineHasNonWhiteSpace && onlyBlankLinesProcessed && !thrownBlankLinesViolation)
                    {
                        this.AddViolation(token.FindParentElement(), token.LineNumber, Rules.CodeMustNotContainBlankLinesAtStartOfFile);
                        thrownBlankLinesViolation = true;
                    }

                    // This sets up for the next token, which will the be first token on its line.
                    firstTokenOnLine = true;

                    lineHasNonWhiteSpace = false;

                    // Process the newline character.
                    this.CheckLineSpacingNewline(precedingTokenNode, tokenNode, count);
                }
                else if (token.CsTokenType != CsTokenType.WhiteSpace)
                {
                    lineHasNonWhiteSpace = true;
                    onlyBlankLinesProcessed = false;

                    // Process the non-whitespace character.
                    this.CheckLineSpacingNonWhitespace(document, precedingTokenNode, token, fileHeader, firstTokenOnLine, count);

                    count = 0;

                    precedingTokenNode = tokenNode;

                    if (firstTokenOnLine && token.CsTokenType != CsTokenType.SingleLineComment && token.CsTokenType != CsTokenType.MultiLineComment)
                    {
                        firstTokenOnLine = false;
                    }
                }
            }
        }

        /// <summary>
        /// Processes a newline character found while checking line spacing rules.
        /// </summary>
        /// <param name="precedingTokenNode">
        /// The preceding non-whitespace token before the newline.
        /// </param>
        /// <param name="node">
        /// The newline token.
        /// </param>
        /// <param name="count">
        /// The current newline count.
        /// </param>
        private void CheckLineSpacingNewline(Node<CsToken> precedingTokenNode, Node<CsToken> node, int count)
        {
            Param.Ignore(precedingTokenNode);
            Param.AssertNotNull(node, "node");
            Param.AssertGreaterThanOrEqualToZero(count, "count");

            // If we've seen two end-of-line characters in a row, then there is a blank
            // line in the code. 
            if (count == 2)
            {
                // Check whether we've seen at least one token before this blank line.
                if (precedingTokenNode != null && !precedingTokenNode.Value.Generated)
                {
                    if (precedingTokenNode.Value.CsTokenType == CsTokenType.OpenCurlyBracket)
                    {
                        // The blank line comes just after an opening curly bracket.
                        this.AddViolation(
                            precedingTokenNode.Value.FindParentElement(), precedingTokenNode.Value.LineNumber, Rules.OpeningCurlyBracketsMustNotBeFollowedByBlankLine);
                    }
                    else if (precedingTokenNode.Value.CsTokenType == CsTokenType.XmlHeader)
                    {
                        // The blank line comes just after an Xml header.
                        this.AddViolation(
                            precedingTokenNode.Value.FindParentElement(), 
                            precedingTokenNode.Value.LineNumber, 
                            Rules.ElementDocumentationHeadersMustNotBeFollowedByBlankLine);
                    }
                }
            }

            Node<CsToken> previousTokenNode = node.Previous;
            Node<CsToken> previousPreviousTokenNode = null;

            if (previousTokenNode != null)
            {
                previousPreviousTokenNode = previousTokenNode.Previous;
            }

            if (count > 2
                || (count == 2
                    && (!node.Value.Generated
                        && (previousTokenNode == null || previousPreviousTokenNode == null
                            || (previousTokenNode.Value.CsTokenType == CsTokenType.EndOfLine && previousPreviousTokenNode.Value.CsTokenType == CsTokenType.EndOfLine)
                            || node.Next == null))))
            {
                // There are two or more blank lines in a row.
                this.AddViolation(node.Value.FindParentElement(), node.Value.LineNumber, Rules.CodeMustNotContainMultipleBlankLinesInARow);
            }
        }

        /// <summary>
        /// Processes a non-whitespace character seen while checking line spacing.
        /// </summary>
        /// <param name="document">
        /// The document containing the token.
        /// </param>
        /// <param name="precedingTokenNode">
        /// The token before the non-whitespace token.
        /// </param>
        /// <param name="token">
        /// The non-whitespace token.
        /// </param>
        /// <param name="fileHeader">
        /// Indicates whether a file header has been seen.
        /// </param>
        /// <param name="firstTokenOnLine">
        /// Indicates whether this is a the first token on the line.
        /// </param>
        /// <param name="count">
        /// The current newline count.
        /// </param>
        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Minimizing refactoring before release.")]
        private void CheckLineSpacingNonWhitespace(
            CsDocument document, Node<CsToken> precedingTokenNode, CsToken token, bool fileHeader, bool firstTokenOnLine, int count)
        {
            Param.AssertNotNull(document, "document");
            Param.Ignore(precedingTokenNode);
            Param.AssertNotNull(token, "token");
            Param.Ignore(fileHeader);
            Param.Ignore(firstTokenOnLine);
            Param.AssertGreaterThanOrEqualToZero(count, "count");

            // Skip generated tokens.
            if (!token.Generated)
            {
                // If there is at least one blank line in front of the current token.
                if (count > 1)
                {
                    if (token.CsTokenType == CsTokenType.CloseCurlyBracket)
                    {
                        // The blank line is just before a closing curly bracket.
                        this.AddViolation(token.FindParentElement(), token.LineNumber, Rules.ClosingCurlyBracketsMustNotBePrecededByBlankLine);
                    }
                    else if (token.CsTokenType == CsTokenType.OpenCurlyBracket)
                    {
                        bool throwViolation = false;

                        // The blank line is just before an opening curly bracket.
                        // If next element back is if,while,catch,try,finally,do,else,lock,switch,unsafe, using, array init, delegate, it's a violation.
                        if (precedingTokenNode == null)
                        {
                            throwViolation = true;
                        }
                        else
                        {
                            Statement parentStatement = precedingTokenNode.Value.FindParentStatement();
                            if (parentStatement == null)
                            {
                                throwViolation = true;
                            }
                            else
                            {
                                StatementType statementType = parentStatement.StatementType;

                                if (statementType == StatementType.If || statementType == StatementType.While || statementType == StatementType.Catch
                                    || statementType == StatementType.Try || statementType == StatementType.Finally || statementType == StatementType.DoWhile
                                    || statementType == StatementType.Else || statementType == StatementType.Lock || statementType == StatementType.Switch
                                    || statementType == StatementType.Unsafe || statementType == StatementType.Using)
                                {
                                    throwViolation = true;
                                }
                                else if (statementType == StatementType.VariableDeclaration && precedingTokenNode.Value.CsTokenType != CsTokenType.Semicolon)
                                {
                                    throwViolation = true;
                                }
                                else if (statementType == StatementType.Expression && precedingTokenNode.Value.CsTokenType == CsTokenType.Delegate)
                                {
                                    throwViolation = true;
                                }
                            }
                        }

                        if (throwViolation)
                        {
                            this.AddViolation(token.FindParentElement(), token.Location, Rules.OpeningCurlyBracketsMustNotBePrecededByBlankLine);
                        }
                    }
                    else if (token.CsTokenType == CsTokenType.Else || token.CsTokenType == CsTokenType.Catch || token.CsTokenType == CsTokenType.Finally)
                    {
                        // The blank line is just before an else, catch, or finally statement.
                        this.AddViolation(token.FindParentElement(), token.LineNumber, Rules.ChainedStatementBlocksMustNotBePrecededByBlankLine);
                    }
                    else if (token.CsTokenType == CsTokenType.WhileDo)
                    {
                        // The blank line is just before the while keyword from a do/while statement.
                        this.AddViolation(token.FindParentElement(), token.LineNumber, Rules.WhileDoFooterMustNotBePrecededByBlankLine);
                    }

                    // Check if there is a blank line after a single-line comment. The exceptions
                    // are if this is the file header, or if the line after the blank line contains
                    // another comment or an Xml header. This is ok if the comment is not
                    // the first item on its line.
                    if (!fileHeader && precedingTokenNode != null && precedingTokenNode.Value.CsTokenType == CsTokenType.SingleLineComment
                        && token.CsTokenType != CsTokenType.SingleLineComment && token.CsTokenType != CsTokenType.MultiLineComment
                        && token.CsTokenType != CsTokenType.XmlHeader)
                    {
                        // Now check whether the comment is the first item on its line. If the comment
                        // is not the first item on the line, then this is not a violation.
                        bool tokenSeen = false;
                        if (precedingTokenNode != null)
                        {
                            foreach (CsToken lineToken in document.Tokens.ReverseIterator(precedingTokenNode.Previous))
                            {
                                if (lineToken.CsTokenType == CsTokenType.EndOfLine)
                                {
                                    break;
                                }
                                else if (lineToken.CsTokenType != CsTokenType.WhiteSpace)
                                {
                                    tokenSeen = true;
                                    break;
                                }
                            }
                        }

                        // Now make sure this comment does not begin with '////'. If so, this is the signal
                        // that StyleCop should ignore this particular error. This is used when the 
                        // developer is commenting out a line of code. In this case it is not a true comment.
                        string trimmedComment = precedingTokenNode.Value.Text.Trim();
                        if (!tokenSeen && !trimmedComment.StartsWith(@"////", StringComparison.Ordinal))
                        {
                            // The blank line appears after a file header, we want to allow this.
                            if (!IsCommentInFileHeader(precedingTokenNode))
                            {
                                this.AddViolation(
                                    precedingTokenNode.Value.FindParentElement(), 
                                    precedingTokenNode.Value.LineNumber, 
                                    Rules.SingleLineCommentsMustNotBeFollowedByBlankLine);
                            }
                        }
                    }
                }
                else if (count == 1)
                {
                    // There is one line return in front of the current token, which means
                    // the line in front of the current token is not blank. Check if the current
                    // token is an Xml header.
                    if (token.CsTokenType == CsTokenType.XmlHeader)
                    {
                        // This is a violation unless the previous line contains another
                        // Xml header, an opening curly bracket, or a preprocessor directive.
                        if (precedingTokenNode != null && precedingTokenNode.Value.CsTokenType != CsTokenType.XmlHeader
                            && precedingTokenNode.Value.CsTokenType != CsTokenType.OpenCurlyBracket
                            && precedingTokenNode.Value.CsTokenType != CsTokenType.PreprocessorDirective)
                        {
                            this.AddViolation(token.FindParentElement(), token.LineNumber, Rules.ElementDocumentationHeaderMustBePrecededByBlankLine);
                        }
                    }
                    else if (token.CsTokenType == CsTokenType.SingleLineComment)
                    {
                        // The current line contains a single line comment and the previous line
                        // is not blank. This is a violation unless the previous line contains
                        // another single line comment, an opening curly bracket, a preprocessor
                        // directive, or if the last character on the previous line is a colon,
                        // which can only mean that it is a label or a case statement, in which
                        // case this is ok.
                        if (precedingTokenNode != null && precedingTokenNode.Value.CsTokenType != CsTokenType.SingleLineComment
                            && precedingTokenNode.Value.CsTokenType != CsTokenType.OpenCurlyBracket && precedingTokenNode.Value.CsTokenType != CsTokenType.LabelColon
                            && precedingTokenNode.Value.CsTokenType != CsTokenType.PreprocessorDirective)
                        {
                            // Now make sure this comment does not begin with '////'. If so, this is the signal
                            // that StyleCop should ignore this particular error. This is used when the 
                            // developer is commenting out a line of code. In this case it is not a true comment.
                            string trimmedComment = token.Text.Trim();
                            if (!trimmedComment.StartsWith(@"////", StringComparison.Ordinal) && !Utils.IsAReSharperComment(token))
                            {
                                CsElement element = token.FindParentElement();

                                if (element != null)
                                {
                                    this.AddViolation(element, token.LineNumber, Rules.SingleLineCommentMustBePrecededByBlankLine);
                                }
                            }
                        }
                    }
                    else if (precedingTokenNode != null && precedingTokenNode.Value.CsTokenType == CsTokenType.CloseCurlyBracket)
                    {
                        // Closing curly brackets cannot be followed directly by another bracket keyword.
                        Bracket closingCurlyBracket = precedingTokenNode.Value as Bracket;
                        if (closingCurlyBracket.MatchingBracket != null && closingCurlyBracket.MatchingBracket.LineNumber != closingCurlyBracket.LineNumber
                            && firstTokenOnLine && token.CsTokenType != CsTokenType.CloseCurlyBracket && token.CsTokenType != CsTokenType.Finally
                            && token.CsTokenType != CsTokenType.Catch && token.CsTokenType != CsTokenType.WhileDo && token.CsTokenType != CsTokenType.Else
                            && token.CsTokenType != CsTokenType.PreprocessorDirective && token.CsTokenType != CsTokenType.Select && token.CsTokenType != CsTokenType.From
                            && token.CsTokenType != CsTokenType.Let && token.CsTokenType != CsTokenType.OperatorSymbol && token.CsTokenType != CsTokenType.By
                            && token.CsTokenType != CsTokenType.Into && token.CsTokenType != CsTokenType.Equals)
                        {
                            this.AddViolation(closingCurlyBracket.FindParentElement(), closingCurlyBracket.LineNumber, Rules.ClosingCurlyBracketMustBeFollowedByBlankLine);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Checks to make sure that if, while, for, and foreach statements are followed by a curly bracket block.
        /// </summary>
        /// <param name="parentElement">
        /// The element containing the statement.
        /// </param>
        /// <param name="statement">
        /// The statement which may or may not be missing the child block
        /// </param>
        /// <param name="embeddedStatement">
        /// The statement embedded within the if, while, for, or foreach statement.
        /// </param>
        /// <param name="statementType">
        /// The user-friendly type of the statement.
        /// </param>
        /// <param name="allowStacks">
        /// True to allow statements of the same type to be stacked together where only the last statement in the stack has curly brackets.
        /// </param>
        private void CheckMissingBlock(CsElement parentElement, Statement statement, Statement embeddedStatement, string statementType, bool allowStacks)
        {
            Param.AssertNotNull(parentElement, "parentElement");
            Param.AssertNotNull(statement, "statement");
            Param.Ignore(embeddedStatement);
            Param.AssertValidString(statementType, "statementType");
            Param.Ignore(allowStacks);

            if (embeddedStatement != null && embeddedStatement.StatementType != StatementType.Block)
            {
                if (!allowStacks || statement.ChildStatements == null || statement.ChildStatements.Count == 0
                    || GetFirstChildStatement(statement).StatementType != statement.StatementType)
                {
                    this.AddViolation(parentElement, embeddedStatement.LineNumber, Rules.CurlyBracketsMustNotBeOmitted, statementType);
                }
            }
        }

        /// <summary>
        /// Checks an accessor and its siblings. If the accessor is all on one line, its siblings
        /// must also be all on one line.
        /// </summary>
        /// <param name="accessor">
        /// The accessor to check.
        /// </param>
        /// <param name="openingBracketNode">
        /// The opening bracket within the accessor.
        /// </param>
        private void CheckSiblingAccessors(CsElement accessor, Node<CsToken> openingBracketNode)
        {
            Param.AssertNotNull(accessor, "accessor");
            Param.AssertNotNull(openingBracketNode, "openingBracketNode");

            Bracket openingBracket = (Bracket)openingBracketNode.Value;

            if (openingBracket.MatchingBracket != null && openingBracket.LineNumber == openingBracket.MatchingBracket.LineNumber)
            {
                // Check the siblings of this accessor.
                CsElement property = accessor.FindParentElement();
                if (property != null)
                {
                    foreach (CsElement sibling in property.ChildElements)
                    {
                        if (sibling != accessor)
                        {
                            // Check this sibling to make sure it is all on one line.
                            Node<CsToken> openBracketNode = LayoutRules.GetOpenBracket(sibling.Tokens);
                            if (openBracketNode != null)
                            {
                                openingBracket = (Bracket)openBracketNode.Value;
                                if (openingBracket != null && openingBracket.MatchingBracket != null)
                                {
                                    if (openingBracket.LineNumber != openingBracket.MatchingBracket.LineNumber)
                                    {
                                        this.AddViolation(accessor, accessor.LineNumber, Rules.AllAccessorsMustBeMultiLineOrSingleLine, property.FriendlyTypeText);

                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Checks the curly brackets under the given statement.
        /// </summary>
        /// <param name="statement">
        /// The statement being visited.
        /// </param>
        /// <param name="parentExpression">
        /// The parent expression, if any.
        /// </param>
        /// <param name="parentStatement">
        /// The parent statement, if any.
        /// </param>
        /// <param name="parentElement">
        /// The parent element, if any.
        /// </param>
        /// <param name="context">
        /// The optional visitor context data.
        /// </param>
        /// <returns>
        /// Returns true to continue, or false to stop the walker.
        /// </returns>
        private bool CheckStatementCurlyBracketPlacement(
            Statement statement, Expression parentExpression, Statement parentStatement, CsElement parentElement, object context)
        {
            Param.AssertNotNull(statement, "statement");
            Param.Ignore(parentExpression);
            Param.Ignore(parentStatement);
            Param.AssertNotNull(parentElement, "parentElement");
            Param.Ignore(context);

            switch (statement.StatementType)
            {
                case StatementType.Block:

                    // A block statement can be the right-hand statement in a lambda expression. In this case, we allow
                    // the block to be written all on a single line if the whole parent statement is on a single line.
                    bool allowAllOnOneLine = false;

                    LambdaExpression lambdaParent = statement.Parent as LambdaExpression;
                    if (lambdaParent != null && lambdaParent.Location.StartPoint.LineNumber == lambdaParent.Location.EndPoint.LineNumber)
                    {
                        allowAllOnOneLine = true;
                    }

                    // Curly bracket block statements may not be all on one line.
                    this.CheckBracketPlacement(parentElement, statement, statement.Tokens, LayoutRules.GetOpenBracket(statement.Tokens), allowAllOnOneLine);
                    break;

                case StatementType.Switch:

                    // Switch statements may not be all on one line.
                    this.CheckBracketPlacement(parentElement, statement, statement.Tokens, LayoutRules.GetOpenBracket(statement.Tokens), false);
                    break;

                case StatementType.If:

                    // If-statements should always be followed by a curly bracket block.
                    this.CheckMissingBlock(parentElement, statement, ((IfStatement)statement).EmbeddedStatement, statement.FriendlyTypeText, false);
                    break;

                case StatementType.Else:

                    // Else-statements should always be followed by a curly bracket block.
                    this.CheckMissingBlock(parentElement, statement, ((ElseStatement)statement).EmbeddedStatement, statement.FriendlyTypeText, false);
                    break;

                case StatementType.While:

                    // While-statements should always be followed by a curly bracket block.
                    this.CheckMissingBlock(parentElement, statement, ((WhileStatement)statement).EmbeddedStatement, statement.FriendlyTypeText, false);
                    break;

                case StatementType.For:

                    // For-statements should always be followed by a curly bracket block.
                    this.CheckMissingBlock(parentElement, statement, ((ForStatement)statement).EmbeddedStatement, statement.FriendlyTypeText, false);
                    break;

                case StatementType.Foreach:

                    // Foreach-statements should always be followed by a curly bracket block.
                    this.CheckMissingBlock(parentElement, statement, ((ForeachStatement)statement).EmbeddedStatement, statement.FriendlyTypeText, false);
                    break;

                case StatementType.DoWhile:

                    // Do-while-statements should always be followed by a curly bracket block.
                    this.CheckMissingBlock(parentElement, statement, ((DoWhileStatement)statement).EmbeddedStatement, statement.FriendlyTypeText, false);
                    break;

                case StatementType.Using:

                    // Using-statements should always be followed by a curly bracket block.
                    this.CheckMissingBlock(parentElement, statement, ((UsingStatement)statement).EmbeddedStatement, statement.FriendlyTypeText, true);
                    break;

                case StatementType.Lock:

                    // lock-statements should always be followed by a curly bracket block.
                    this.CheckMissingBlock(parentElement, statement, ((LockStatement)statement).EmbeddedStatement, statement.FriendlyTypeText, false);
                    break;

                default:
                    break;
            }

            return true;
        }

        /// <summary>
        /// Visits an element.
        /// </summary>
        /// <param name="element">
        /// The element being visited.
        /// </param>
        /// <param name="parentElement">
        /// The parent element, if any.
        /// </param>
        /// <param name="context">
        /// The optional visitor context data.
        /// </param>
        /// <returns>
        /// Returns true to continue, or false to stop the walker.
        /// </returns>
        private bool VisitElement(CsElement element, CsElement parentElement, object context)
        {
            Param.AssertNotNull(element, "element");
            Param.Ignore(parentElement);
            Param.Ignore(context);

            this.CheckElementCurlyBracketPlacement(element);
            this.CheckChildElementSpacing(element);

            return true;
        }

        #endregion
    }
}