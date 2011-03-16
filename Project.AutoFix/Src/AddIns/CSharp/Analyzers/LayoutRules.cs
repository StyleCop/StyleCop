//-----------------------------------------------------------------------
// <copyright file="LayoutRules.cs">
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
    /// Checks layout rules.
    /// </summary>
    [SourceAnalyzer(typeof(CsParser))]
    public class LayoutRules : SourceAnalyzer
    {
        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the LayoutRules class.
        /// </summary>
        public LayoutRules()
        {
        }

        #endregion Public Constructors

        #region Public Override Methods

        /// <summary>
        /// Checks the placement of brackets within the given document.
        /// </summary>
        /// <param name="document">The document to check.</param>
        public override void AnalyzeDocument(ICodeDocument document)
        {
            Param.RequireNotNull(document, "document");

            CsDocument csdocument = document.AsCsDocument();

            if (csdocument != null && !csdocument.Generated)
            {
                csdocument.WalkCodeModel(this.VisitCodeUnit);

                // Check line spacing rules.
                this.CheckLineSpacing(csdocument);
            }
        }

        #endregion Public Override Methods

        #region Private Static Methods

        /// <summary>
        /// Determines whether the given item is an Xml header or an Xml header line.
        /// </summary>
        /// <param name="item">The item to check.</param>
        /// <returns>Returns true if so; false otherwise.</returns>
        private static bool IsXmlHeader(CodeUnit item)
        {
            Param.AssertNotNull(item, "item");
            return item.Is(CodeUnitType.ElementHeader) || item.Is(CommentType.ElementHeaderLine);
        }

        /// <summary>
        /// Determines whether the given item is a preprocessor directive or an item within a preprocessor directive.
        /// </summary>
        /// <param name="item">The item to check.</param>
        /// <returns>Returns true if so; false otherwise.</returns>
        private static bool IsPreprocessorDirective(CodeUnit item)
        {
            Param.AssertNotNull(item, "item");

            if (item.Is(LexicalElementType.PreprocessorDirective))
            {
                return true;
            }

            return item.FindParent<PreprocessorDirective>() != null;
        }

        /// <summary>
        /// Determines whether the given bracket is the only thing on its line or whether it shares the line.
        /// </summary>
        /// <param name="bracketNode">The bracket to check.</param>
        /// <param name="allowTrailingCharacters">Indicates whether a semicolon, comma or closing parenthesis after the 
        /// bracket is allowed.</param>
        /// <returns>Returns true if the bracket shares the line with something else.</returns>
        private static bool BracketSharesLine(Token bracketNode, bool allowTrailingCharacters)
        {
            Param.AssertNotNull(bracketNode, "bracketNode");
            Param.Ignore(allowTrailingCharacters);

            // Look forward.
            bool sharesLine = false;

            // Find the next non-whitespace or comment item.
            LexicalElement nextItem = null;
            for (LexicalElement item = bracketNode.FindNextLexicalElement(); item != null; item = item.FindNextLexicalElement())
            {
                if (item.LexicalElementType == LexicalElementType.EndOfLine)
                {
                    break;
                }
                else if (item.LexicalElementType != LexicalElementType.WhiteSpace &&
                    item.LexicalElementType != LexicalElementType.Comment)
                {
                    nextItem = item;
                    break;
                }
            }

            if (nextItem != null)
            {
                if (!allowTrailingCharacters ||
                    (!nextItem.Is(TokenType.Semicolon) &&
                     !nextItem.Is(TokenType.Comma) &&
                     !nextItem.Is(TokenType.CloseParenthesis) &&
                     !nextItem.Is(TokenType.CloseSquareBracket)))
                {
                    sharesLine = true;
                }
            }

            if (!sharesLine)
            {
                // Look backwards.
                for (LexicalElement item = bracketNode.FindPreviousLexicalElement(); item != null; item = item.FindPreviousLexicalElement())
                {
                    if (item.LexicalElementType == LexicalElementType.EndOfLine)
                    {
                        break;
                    }
                    else if (item.LexicalElementType != LexicalElementType.WhiteSpace && !item.Is(CommentType.SingleLineComment))
                    {
                        sharesLine = true;
                        break;
                    }
                }
            }

            return sharesLine;
        }

        /// <summary>
        /// Gets friendly output text for "opening" or "closing", depending on the type of the bracket.
        /// </summary>
        /// <param name="bracket">The bracket.</param>
        /// <returns>Returns the opening or closing text.</returns>
        private static string GetOpeningOrClosingBracketText(BracketToken bracket)
        {
            Param.AssertNotNull(bracket, "bracket");

            switch (bracket.TokenType)
            {
                case TokenType.OpenAttributeBracket:
                case TokenType.OpenCurlyBracket:
                case TokenType.OpenGenericBracket:
                case TokenType.OpenParenthesis:
                case TokenType.OpenSquareBracket:
                    return Strings.Opening;

                case TokenType.CloseAttributeBracket:
                case TokenType.CloseCurlyBracket:
                case TokenType.CloseGenericBracket:
                case TokenType.CloseParenthesis:
                case TokenType.CloseSquareBracket:
                    return Strings.Closing;

                default:
                    Debug.Fail("Invalid bracket type.");
                    return string.Empty;
            }
        }

        /// <summary>
        /// Determines whether the given token is part of a file header. It is considered
        /// part of a file header if the only tokens in front of it are single-line comments,
        /// whitespace, or newlines.
        /// </summary>
        /// <param name="comment">The comment to check.</param>
        /// <returns>Returns true if the comment is part of a file header.</returns>
        private static bool IsCommentInFileHeader(Comment comment)
        {
            Param.AssertNotNull(comment, "comment");

            LexicalElement item = comment;
            while (item != null)
            {
                if (!item.Is(CommentType.SingleLineComment) &&
                    item.LexicalElementType != LexicalElementType.WhiteSpace &&
                    item.LexicalElementType != LexicalElementType.EndOfLine)
                {
                    return false;
                }

                item = item.FindPreviousLexicalElement();
            }

            return true;
        }

        /// <summary>
        /// Determines whether the given property is an automatic property.
        /// </summary>
        /// <param name="property">The property to check.</param>
        /// <returns>Returns true if the property is an automatic property.</returns>
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

        /// <summary>4
        /// Determines whether the given accessor contains a body. 
        /// </summary>
        /// <param name="accessor">The accessor to check.</param>
        /// <returns>Returns true if the accessor contains a body.</returns>
        private static bool DoesAccessorHaveBody(Accessor accessor)
        {
            Param.AssertNotNull(accessor, "accessor");
            return accessor.FindFirstChild<OpenCurlyBracketToken>() != null;
        }

        #endregion Private Static Methods

        #region Private Methods

        /// <summary>
        /// Visits one code unit in the document.
        /// </summary>
        /// <param name="codeUnit">The item being visited.</param>
        /// <param name="parentElement">The parent element, if any.</param>
        /// <param name="parentStatement">The parent statement, if any.</param>
        /// <param name="parentExpression">The parent expression, if any.</param>
        /// <param name="parentClause">The parent query clause, if any.</param>
        /// <param name="parentToken">The parent token, if any.</param>
        /// <param name="context">The context.</param>
        /// <returns>Returns true to continue, or false to stop the walker.</returns>
        private bool VisitCodeUnit(
            CodeUnit codeUnit,
            Element parentElement,
            Statement parentStatement,
            Expression parentExpression,
            QueryClause parentClause,
            Token parentToken,
            object context)
        {
            Param.AssertNotNull(codeUnit, "codeUnit");
            Param.Ignore(parentElement, parentStatement, parentExpression, parentClause, parentToken);
            Param.Ignore(context);

            if (codeUnit.CodeUnitType == CodeUnitType.Element)
            {
                return this.VisitElement((Element)codeUnit, parentElement);
            }
            else if (codeUnit.CodeUnitType == CodeUnitType.Statement)
            {
                return this.VisitStatement((Statement)codeUnit, parentExpression, parentStatement, parentElement);
            }
            else if (codeUnit.CodeUnitType == CodeUnitType.Expression)
            {
                return this.VisitExpression((Expression)codeUnit, parentExpression, parentStatement, parentElement);
            }

            return !this.Cancel;
        }

        /// <summary>
        /// Visits an element.
        /// </summary>
        /// <param name="element">The element being visited.</param>
        /// <param name="parentElement">The parent element, if any.</param>
        /// <returns>Returns true to continue, or false to stop the walker.</returns>
        private bool VisitElement(Element element, Element parentElement)
        {
            Param.AssertNotNull(element, "element");
            Param.Ignore(parentElement);

            this.CheckElementCurlyBracketPlacement(element);
            this.CheckChildElementSpacing(element);

            return true;
        }

        /// <summary>
        /// Checks the spacing of child elements of the given element, to ensure that elements
        /// are separated by a blank line.
        /// </summary>
        /// <param name="element">The element being visited.</param>
        private void CheckChildElementSpacing(Element element)
        {
            Param.AssertNotNull(element, "element");

            Element previousElement = null;

            if (element.Children.ElementCount > 0)
            {
                for (Element childElement = element.FindFirstChildElement(); childElement != null; childElement = childElement.FindNextSiblingElement())
                {
                    // Check the line spacing between the two elements if:
                    // - There was a previous element
                    // - AND neither of the elements are generated
                    // - AND the previous element and the current element are of different types
                    // - - OR the current element has a header
                    // - - OR the previous element spans multiple lines
                    // - - OR the elements are not using directives, extern alias directives, accessors, enum items, or fields.
                    if (previousElement != null && 
                        !previousElement.Generated &&
                        !childElement.Generated &&
                        (previousElement.ElementType != childElement.ElementType ||
                         childElement.Header != null ||
                         previousElement.Location.LineSpan > 1 ||
                         (childElement.ElementType != ElementType.UsingDirective &&
                          childElement.ElementType != ElementType.ExternAliasDirective &&
                          childElement.ElementType != ElementType.Accessor &&
                          childElement.ElementType != ElementType.EnumItem &&
                          childElement.ElementType != ElementType.Field)))
                    {
                        // The start line of this element is the first line of the header if there is one,
                        // or the first line of the element itself if there is no header.
                        int startLine = childElement.LineNumber;
                        if (childElement.Header != null)
                        {
                            startLine = childElement.Header.LineNumber;
                        }

                        if (startLine == previousElement.Location.EndPoint.LineNumber || 
                            startLine == previousElement.Location.EndPoint.LineNumber + 1)
                        {
                            this.AddViolation(childElement, Rules.ElementsMustBeSeparatedByBlankLine);
                        }
                    }

                    previousElement = childElement;
                }
            }
        }

        /// <summary>
        /// Checks the curly brackets under the given element.
        /// </summary>
        /// <param name="element">The element being visited.</param>
        private void CheckElementCurlyBracketPlacement(Element element)
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
                else if (element.ElementType == ElementType.Class ||
                    element.ElementType == ElementType.Constructor ||
                    element.ElementType == ElementType.Destructor ||
                    element.ElementType == ElementType.Enum ||
                    element.ElementType == ElementType.Event ||
                    element.ElementType == ElementType.Indexer ||
                    element.ElementType == ElementType.Interface ||
                    element.ElementType == ElementType.Method ||
                    element.ElementType == ElementType.Namespace ||
                    element.ElementType == ElementType.Struct)
                {
                    // Curly brackets for these types cannot be all on one line.
                    this.CheckElementBracketPlacement(element, false);
                }
                else if (element.ElementType == ElementType.Property)
                {
                    // Automatic properties are allowed to be on a single line, but normal properties are not.
                    this.CheckElementBracketPlacement(element, IsAutomaticProperty((Property)element));
                }
            }
        }

        /// <summary>
        /// Checks the curly brackets under the given statement.
        /// </summary>
        /// <param name="statement">The statement being visited.</param>
        /// <param name="parentExpression">The parent expression, if any.</param>
        /// <param name="parentStatement">The parent statement, if any.</param>
        /// <param name="parentElement">The parent element, if any.</param>
        /// <returns>Returns true to continue, or false to stop the walker.</returns>
        private bool VisitStatement(
            Statement statement, 
            Expression parentExpression, 
            Statement parentStatement, 
            Element parentElement)
        {
            Param.AssertNotNull(statement, "statement");
            Param.Ignore(parentExpression);
            Param.Ignore(parentStatement);
            Param.AssertNotNull(parentElement, "parentElement");

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
                    this.CheckBracketPlacement(
                        statement,
                        parentElement,
                        statement,
                        statement.FindFirstChild<OpenCurlyBracketToken>(),
                        allowAllOnOneLine);
                    break;

                case StatementType.Switch:
                    // Switch statements may not be all on one line.
                    this.CheckBracketPlacement(
                        statement,
                        parentElement,
                        statement,
                        statement.FindFirstChild<OpenCurlyBracketToken>(),
                        false);
                    break;

                case StatementType.If:
                    // If-statements should always be followed by a curly bracket block.
                    this.CheckMissingBlock(parentElement, statement, ((IfStatement)statement).Body, statement.FriendlyTypeText, false);
                    break;

                case StatementType.Else:
                    // Else-statements should always be followed by a curly bracket block.
                    this.CheckMissingBlock(parentElement, statement, ((ElseStatement)statement).Body, statement.FriendlyTypeText, false);
                    break;

                case StatementType.While:
                    // While-statements should always be followed by a curly bracket block.
                    this.CheckMissingBlock(parentElement, statement, ((WhileStatement)statement).Body, statement.FriendlyTypeText, false);
                    break;

                case StatementType.For:
                    // For-statements should always be followed by a curly bracket block.
                    this.CheckMissingBlock(parentElement, statement, ((ForStatement)statement).Body, statement.FriendlyTypeText, false);
                    break;

                case StatementType.Foreach:
                    // Foreach-statements should always be followed by a curly bracket block.
                    this.CheckMissingBlock(parentElement, statement, ((ForeachStatement)statement).Body, statement.FriendlyTypeText, false);
                    break;

                case StatementType.DoWhile:
                    // Do-while-statements should always be followed by a curly bracket block.
                    this.CheckMissingBlock(parentElement, statement, ((DoWhileStatement)statement).Body, statement.FriendlyTypeText, false);
                    break;

                case StatementType.Using:
                    // Using-statements should always be followed by a curly bracket block.
                    this.CheckMissingBlock(parentElement, statement, ((UsingStatement)statement).Body, statement.FriendlyTypeText, true);
                    break;

                default:
                    break;
            }

            return true;
        }

        /// <summary>
        /// Checks the curly brackets under the given expression.
        /// </summary>
        /// <param name="expression">The expression being visited.</param>
        /// <param name="parentExpression">The parent expression, if any.</param>
        /// <param name="parentStatement">The parent statement, if any.</param>
        /// <param name="parentElement">The parent element, if any.</param>
        /// <returns>Returns true to continue, or false to stop the walker.</returns>
        private bool VisitExpression(
            Expression expression, 
            Expression parentExpression, 
            Statement parentStatement, 
            Element parentElement)
        {
            Param.AssertNotNull(expression, "expression");
            Param.Ignore(parentExpression);
            Param.Ignore(parentStatement);
            Param.AssertNotNull(parentElement, "parentElement");

            switch (expression.ExpressionType)
            {
                case ExpressionType.AnonymousMethod:
                case ExpressionType.Lambda:
                    // An anonymous method or lambda expression is allowed to be all on a single line as long as the entire
                    // expression is on one line.
                    OpenCurlyBracketToken openBracket = expression.FindFirstChild<OpenCurlyBracketToken>();

                    if (openBracket != null)
                    {
                        bool allowAllOnOneLine = expression.Location.StartPoint.LineNumber == expression.Location.EndPoint.LineNumber;

                        this.CheckBracketPlacement(
                            expression,
                            parentElement,
                            parentStatement,
                            openBracket,
                            allowAllOnOneLine);
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
                    CodeUnit openBracketParent = expression;
                    Expression expressionParent = expression.Parent as Expression;
                    if (expressionParent != null)
                    {
                        openBracketParent = expressionParent;
                    }

                    var openCurlyBracket = expression.FindFirstChild<OpenCurlyBracketToken>();
                    if (openCurlyBracket != null)
                    {
                        this.CheckBracketPlacement(
                            openBracketParent,
                            parentElement,
                            parentStatement,
                            openCurlyBracket,
                            true);
                    }

                    break;

                default:
                    break;
            }

            return true;
        }
        
        /// <summary>
        /// Checks the placement of curly brackets on the current element.
        /// </summary>
        /// <param name="element">The element to check.</param>
        /// <param name="allowAllOnOneLine">Indicates whether the brackets are allowed to be all on one line.</param>
        private void CheckElementBracketPlacement(Element element, bool allowAllOnOneLine)
        {
            Param.AssertNotNull(element, "element");
            Param.Ignore(allowAllOnOneLine);

            // Get the absolute index of the last token from the element declaration.
            Token lastDeclarationToken = element.LastDeclarationToken;
            if (lastDeclarationToken != null)
            {
                // Find the opening curly bracket within this element.
                for (Token token = lastDeclarationToken.FindNextDescendentTokenOf(element); token != null; token = token.FindNextDescendentTokenOf(element))
                {
                    if (token.Is(OperatorType.Equals))
                    {
                        // If we have found an equals sign in the element declaration before finding any opening curly bracket
                        // then this is not a bracketed element. This could be something like the following examples:
                        // int[] x = new int[] { 1, 2, 3 };
                        // event EventHandler x = (sender, e) => { };
                        // In both of these cases, it's allowed to put the statement on a single line.
                        allowAllOnOneLine = true;
                    }
                    else if (token.TokenType == TokenType.OpenCurlyBracket)
                    {
                        OpenCurlyBracketToken openCurlyBracket = (OpenCurlyBracketToken)token;
                        this.CheckBracketPlacement(element, element, null, openCurlyBracket, allowAllOnOneLine);

                        if (allowAllOnOneLine && element.ElementType == ElementType.Accessor)
                        {
                            // If this accessor is all one one line, any other accessors in this 
                            // property must also be all on one line.
                            this.CheckSiblingAccessors(element, openCurlyBracket);
                        }

                        break;
                    }
                }
            }
        }
        
        /// <summary>
        /// Checks the placement of curly brackets within the given item.
        /// </summary>
        /// <param name="item">The item containing the brackets to check.</param>
        /// <param name="parentElement">The element containing the brackets.</param>
        /// <param name="parentStatement">The statement containing the brackets, if any.</param>
        /// <param name="openBracket">The opening curly bracket within the token list.</param>
        /// <param name="allowAllOnOneLine">Indicates whether the brackets are allowed to be all on one line.</param>
        private void CheckBracketPlacement(
            CodeUnit item,
            Element parentElement, 
            Statement parentStatement, 
            OpenBracketToken openBracket, 
            bool allowAllOnOneLine)
        {
            Param.AssertNotNull(item, "item");
            Param.AssertNotNull(parentElement, "parentElement");
            Param.Ignore(parentStatement);
            Param.AssertNotNull(openBracket, "openBracket");
            Param.Ignore(allowAllOnOneLine);

            if (openBracket.MatchingBracket != null &&
                !openBracket.Generated && 
                !openBracket.MatchingBracket.Generated)
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
                        // The brackets are only allowed to be on the same line if the entire statement is on the same line.
                        Token first = item.FindFirstDescendentToken();
                        Token last = item.FindLastDescendentToken();

                        if (first != null && last != null && first.LineNumber != last.LineNumber)
                        {
                            this.AddViolation(parentElement, openBracket.LineNumber, Rules.CurlyBracketsForMultiLineStatementsMustNotShareLine, GetOpeningOrClosingBracketText(openBracket));
                        }
                    }
                }
                else
                {
                    // The brackets are on different lines. Both brackets must be on a line all by themselves.
                    if (LayoutRules.BracketSharesLine(openBracket, false))
                    {
                        this.AddViolation(parentElement, openBracket.LineNumber, Rules.CurlyBracketsForMultiLineStatementsMustNotShareLine, GetOpeningOrClosingBracketText(openBracket));
                    }

                    if (LayoutRules.BracketSharesLine(openBracket.MatchingBracket, true))
                    {
                        this.AddViolation(parentElement, openBracket.MatchingBracket.LineNumber, Rules.CurlyBracketsForMultiLineStatementsMustNotShareLine, GetOpeningOrClosingBracketText(openBracket.MatchingBracket));
                    }
                }
            }
        }

        /// <summary>
        /// Checks to make sure that if, while, for, and foreach statements are followed by a curly bracket block.
        /// </summary>
        /// <param name="parentElement">The element containing the statement.</param>
        /// <param name="statement">The statement which may or may not be missing the child block</param>
        /// <param name="embeddedStatement">The statement embedded within the if, while, for, or foreach statement.</param>
        /// <param name="statementType">The user-friendly type of the statement.</param>
        /// <param name="allowStacks">True to allow statements of the same type to be stacked together where only the last statement in the stack has curly brackets.</param>
        private void CheckMissingBlock(Element parentElement, Statement statement, Statement embeddedStatement, string statementType, bool allowStacks)
        {
            Param.AssertNotNull(parentElement, "parentElement");
            Param.AssertNotNull(statement, "statement");
            Param.Ignore(embeddedStatement);
            Param.AssertValidString(statementType, "statementType");
            Param.Ignore(allowStacks);

            if (embeddedStatement != null && embeddedStatement.StatementType != StatementType.Block)
            {
                Statement firstChildStatement = statement.FindFirstChildStatement();

                if (!allowStacks ||
                    firstChildStatement == null ||
                    firstChildStatement.StatementType != statement.StatementType)
                {
                    this.AddViolation(parentElement, embeddedStatement.LineNumber, Rules.CurlyBracketsMustNotBeOmitted, statementType);
                }
            }
        }

        /// <summary>
        /// Checks an accessor and its siblings. If the access is all on one line, its siblings
        /// must also be all on one line.
        /// </summary>
        /// <param name="accessor">The accessor to check.</param>
        /// <param name="openingBracket">The opening bracket within the accessor.</param>
        private void CheckSiblingAccessors(Element accessor, OpenCurlyBracketToken openingBracket)
        {
            Param.AssertNotNull(accessor, "accessor");
            Param.AssertNotNull(openingBracket, "openingBracket");

            if (openingBracket.MatchingBracket != null &&
                openingBracket.LineNumber == openingBracket.MatchingBracket.LineNumber)
            {
                // Check the siblings of this accessor.
                Element property = accessor.Parent as Element;
                if (property != null)
                {
                    for (Element sibling = property.FindFirstChildElement(); sibling != null; sibling = sibling.FindNextSiblingElement())
                    {
                        if (sibling != accessor)
                        {
                            // Check this sibling to make sure it is all on one line.
                            openingBracket = sibling.FindFirstChild<OpenCurlyBracketToken>();
                            if (openingBracket != null && openingBracket.MatchingBracket != null)
                            {
                                if (openingBracket.LineNumber != openingBracket.MatchingBracket.LineNumber)
                                {
                                    this.AddViolation(
                                        accessor,
                                        accessor.LineNumber,
                                        Rules.AllAccessorsMustBeMultiLineOrSingleLine,
                                        property.FriendlyTypeText);

                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Checks the line spacing within the given document.
        /// </summary>
        /// <param name="document">The document to check.</param>
        private void CheckLineSpacing(CsDocument document)
        {
            Param.AssertNotNull(document, "document");

            // Set up some variables.
            int count = 0;
            LexicalElement precedingItem = null;
            bool fileHeader = true;
            bool firstTokenOnLine = true;

            // Loop through all the tokens in the document.
            for (LexicalElement item = document.FindFirstDescendentLexicalElement(); item != null; item = item.FindNextDescendentLexicalElementOf(document))
            {
                // Check for cancel.
                if (this.Cancel)
                {
                    break;
                }

                // Check whether we're through the file header yet.
                if (fileHeader &&
                    item.LexicalElementType != LexicalElementType.EndOfLine &&
                    item.LexicalElementType != LexicalElementType.WhiteSpace &&
                    item.LexicalElementType != LexicalElementType.Comment)
                {
                    fileHeader = false;
                }

                // Check whether this token is an end-of-line character.
                if (item.Text == "\n")
                {
                    ++count;

                    // This sets up for the next token, which will the be first token on its line.
                    firstTokenOnLine = true;
                    
                    // Process the newline character.
                    this.CheckLineSpacingNewline(precedingItem, item, count);
                }
                else if (item.LexicalElementType != LexicalElementType.WhiteSpace)
                {
                    // Process the non-whitespace character.
                    this.CheckLineSpacingNonWhitespace(document, precedingItem, item, fileHeader, firstTokenOnLine, count);

                    count = 0;

                    precedingItem = item;

                    if (firstTokenOnLine && item.LexicalElementType != LexicalElementType.Comment)
                    {
                        firstTokenOnLine = false;
                    }
                }
            }
        }

        /// <summary>
        /// Processes a non-whitespace character seen while checking line spacing.
        /// </summary>
        /// <param name="document">The document containing the token.</param>
        /// <param name="precedingItem">The token before the non-whitespace token.</param>
        /// <param name="item">The non-whitespace token.</param>
        /// <param name="fileHeader">Indicates whether a file header has been seen.</param>
        /// <param name="firstTokenOnLine">Indicates whether this is a the first token on the line.</param>
        /// <param name="count">The current newline count.</param>
        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Minimizing refactoring before release.")]
        private void CheckLineSpacingNonWhitespace(
            CsDocument document, LexicalElement precedingItem, LexicalElement item, bool fileHeader, bool firstTokenOnLine, int count)
        {
            Param.AssertNotNull(document, "document");
            Param.Ignore(precedingItem);
            Param.AssertNotNull(item, "item");
            Param.Ignore(fileHeader);
            Param.Ignore(firstTokenOnLine);
            Param.AssertGreaterThanOrEqualToZero(count, "count");

            // Skip generated tokens.
            if (!item.Generated)
            {
                // If there is at least one blank line in front of the current token.
                if (count > 1)
                {
                    if (item.Is(TokenType.CloseCurlyBracket))
                    {
                        // The blank line is just before a closing curly bracket.
                        this.AddViolation(
                            item.FindParentElement(),
                            item.LineNumber,
                            Rules.ClosingCurlyBracketsMustNotBePrecededByBlankLine);
                    }
                    else if (item.Is(TokenType.OpenCurlyBracket))
                    {
                        // The blank line is just before an opening curly bracket.
                        this.AddViolation(
                            item.FindParentElement(),
                            item.LineNumber,
                            Rules.OpeningCurlyBracketsMustNotBePrecededByBlankLine);
                    }
                    else if (item.Is(TokenType.Else) ||
                        item.Is(TokenType.Catch) ||
                        item.Is(TokenType.Finally))
                    {
                        // The blank line is just before an else, catch, or finally statement.
                        this.AddViolation(
                            item.FindParentElement(),
                            item.LineNumber,
                            Rules.ChainedStatementBlocksMustNotBePrecededByBlankLine);
                    }
                    else if (item.Is(TokenType.WhileDo))
                    {
                        // The blank line is just before the while keyword from a do/while statement.
                        this.AddViolation(
                            item.FindParentElement(),
                            item.LineNumber,
                            Rules.WhileDoFooterMustNotBePrecededByBlankLine);
                    }

                    // Check if there is a blank line after a single-line comment. The exceptions
                    // are if this is the file header, or if the line after the blank line contains
                    // another comment or an Xml header. This is ok if the comment is not
                    // the first item on its line.
                    if (!fileHeader &&
                        precedingItem != null &&
                        precedingItem.Is(CommentType.SingleLineComment) &&
                        !item.Is(LexicalElementType.Comment) &&
                        !IsXmlHeader(item))
                    {
                        Comment precedingComment = (Comment)precedingItem;

                        // Now check whether the comment is the first item on its line. If the comment
                        // is not the first item on the line, then this is not a violation.
                        bool itemSeen = false;
                        for (LexicalElement lineItem = precedingComment.FindPreviousLexicalElement(); lineItem != null; lineItem = lineItem.FindPreviousLexicalElement())
                        {
                            if (lineItem.LexicalElementType == LexicalElementType.EndOfLine)
                            {
                                break;
                            }
                            else if (lineItem.LexicalElementType != LexicalElementType.WhiteSpace)
                            {
                                itemSeen = true;
                                break;
                            }
                        }

                        // Now make sure this comment does not begin with '////'. If so, this is the signal
                        // that StyleCop should ignore this particular error. This is used when the 
                        // developer is commenting out a line of code. In this case it is not a true comment.
                        string trimmedComment = precedingComment.Text.Trim();
                        if (!itemSeen && !trimmedComment.StartsWith(@"////", StringComparison.Ordinal))
                        {
                            // The blank line appears after a file header, we want to allow this.
                            if (!IsCommentInFileHeader(precedingComment))
                            {
                                this.AddViolation(
                                    precedingComment.FindParentElement(),
                                    precedingComment.LineNumber,
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
                    if (IsXmlHeader(item))
                    {
                        // This is a violation unless the previous line contains another
                        // Xml header, an opening curly bracket, or a preprocessor directive.
                        if (precedingItem != null &&
                            !IsXmlHeader(precedingItem) &&
                            !precedingItem.Is(TokenType.OpenCurlyBracket) &&
                            !IsPreprocessorDirective(precedingItem))
                        {
                            this.AddViolation(
                                item.FindParentElement(),
                                item.LineNumber,
                                Rules.ElementDocumentationHeaderMustBePrecededByBlankLine);
                        }
                    }
                    else if (item.Is(CommentType.SingleLineComment))
                    {
                        // The current line contains a single line comment and the previous line
                        // is not blank. This is a violation unless the previous line contains
                        // another single line comment, an opening curly bracket, a preprocessor
                        // directive, or if the last character on the previous line is a colon,
                        // which can only mean that it is a label or a case statement, in which
                        // case this is ok.
                        if (precedingItem != null &&
                            !precedingItem.Is(CommentType.SingleLineComment) &&
                            !precedingItem.Is(TokenType.OpenCurlyBracket) &&
                            !precedingItem.Is(TokenType.LabelColon) &&
                            !IsPreprocessorDirective(precedingItem))
                        {
                            // Now make sure this comment does not begin with '////'. If so, this is the signal
                            // that StyleCop should ignore this particular error. This is used when the 
                            // developer is commenting out a line of code. In this case it is not a true comment.
                            string trimmedComment = item.Text.Trim();
                            if (!trimmedComment.StartsWith(@"////", StringComparison.Ordinal))
                            {
                                this.AddViolation(
                                    item.FindParentElement(),
                                    item.LineNumber,
                                    Rules.SingleLineCommentMustBePrecededByBlankLine);
                            }
                        }
                    }

                    if (precedingItem != null && precedingItem.Is(TokenType.CloseCurlyBracket))
                    {
                        // Closing curly brackets cannot be followed directly by another bracket keyword.
                        CloseCurlyBracketToken closingCurlyBracket = (CloseCurlyBracketToken)precedingItem;
                        if (closingCurlyBracket.MatchingBracket != null &&
                            closingCurlyBracket.MatchingBracket.LineNumber != closingCurlyBracket.LineNumber &&
                            firstTokenOnLine &&
                            !item.Is(TokenType.CloseCurlyBracket) &&
                            !item.Is(TokenType.Finally) &&
                            !item.Is(TokenType.Catch) &&
                            !item.Is(TokenType.WhileDo) &&
                            !item.Is(TokenType.Else) &&
                            !IsPreprocessorDirective(item))
                        {
                            this.AddViolation(
                                closingCurlyBracket.FindParentElement(),
                                closingCurlyBracket.LineNumber,
                                Rules.ClosingCurlyBracketMustBeFollowedByBlankLine);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Processes a newline character found while checking line spacing rules.
        /// </summary>
        /// <param name="precedingItem">The preceding item before the newline.</param>
        /// <param name="item">The newline item.</param>
        /// <param name="count">The current newline count.</param>
        private void CheckLineSpacingNewline(LexicalElement precedingItem, LexicalElement item, int count)
        {
            Param.Ignore(precedingItem);
            Param.AssertNotNull(item, "item");
            Param.AssertGreaterThanOrEqualToZero(count, "count");

            // If we've seen two end-of-line characters in a row, then there is a blank
            // line in the code. 
            if (count == 2)
            {
                // Check whether we've seen at least one token before this blank line.
                if (precedingItem != null && !precedingItem.Generated)
                {
                    if (precedingItem.Is(TokenType.OpenCurlyBracket))
                    {
                        // The blank line comes just after an opening curly bracket.
                        this.AddViolation(
                            precedingItem.FindParentElement(),
                            precedingItem.LineNumber,
                            Rules.OpeningCurlyBracketsMustNotBeFollowedByBlankLine);
                    }
                    else if (IsXmlHeader(precedingItem))
                    {
                        // The blank line comes just after an Xml header.
                        this.AddViolation(
                            precedingItem.FindParentElement(),
                            precedingItem.LineNumber,
                            Rules.ElementDocumentationHeadersMustNotBeFollowedByBlankLine);
                    }
                }
            }
            else if (count == 3 && !item.Generated)
            {
                // There are two or more blank lines in a row.
                this.AddViolation(
                    item.FindParentElement(),
                    item.LineNumber,
                    Rules.CodeMustNotContainMultipleBlankLinesInARow);
            }
        }

        #endregion Private Methods
    }
}
