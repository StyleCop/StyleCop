// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CodeParser.cs" company="https://github.com/StyleCop">
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
//   Parses a C# code file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Text;

    /// <summary>
    /// Parses a C# code file.
    /// </summary>
    [SuppressMessage("Microsoft.Design", "CA1001:TypesThatOwnDisposableFieldsShouldBeDisposable", 
        Justification = "The class does not create anything that it should dispose.")]
    [SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling", Justification = "Class is split across multiple files for added maintainability.")
    ]
    internal partial class CodeParser
    {
        #region Fields

        /// <summary>
        /// The code lexer.
        /// </summary>
        private readonly CodeLexer lexer;

        /// <summary>
        /// The C# parser.
        /// </summary>
        private readonly CsParser parser;

        /// <summary>
        /// The collection of tokens in the document.
        /// </summary>
        private readonly MasterList<CsToken> tokens = new MasterList<CsToken>();

        /// <summary>
        /// The document being parsed.
        /// </summary>
        private CsDocument document;

        /// <summary>
        /// The collection of symbols in the document.
        /// </summary>
        private SymbolManager symbols;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the CodeParser class.
        /// </summary>
        /// <param name="parser">
        /// The C# parser.
        /// </param>
        /// <param name="lexer">
        /// The lexer to use for parsing the code.
        /// </param>
        public CodeParser(CsParser parser, CodeLexer lexer)
        {
            Param.AssertNotNull(parser, "parser");
            Param.AssertNotNull(lexer, "lexer");

            this.parser = parser;
            this.lexer = lexer;
        }

        /// <summary>
        /// Initializes a new instance of the CodeParser class.
        /// </summary>
        /// <param name="parser">
        /// The C# parser.
        /// </param>
        /// <param name="symbols">
        /// The symbols in the document to parse.
        /// </param>
        public CodeParser(CsParser parser, SymbolManager symbols)
        {
            Param.AssertNotNull(parser, "parser");
            Param.AssertNotNull(symbols, "symbols");

            this.parser = parser;
            this.symbols = symbols;
        }

        #endregion

        #region Enums

        /// <summary>
        /// The types of symbols to skip while advancing past symbols.
        /// </summary>
        [Flags]
        private enum SkipSymbols
        {
            /// <summary>
            /// Don't skip any symbols.
            /// </summary>
            None = 0x00, 

            /// <summary>
            /// Skip past all whitespace symbols.
            /// </summary>
            WhiteSpace = 0x01, 

            /// <summary>
            /// Skip past all end-of-line characters.
            /// </summary>
            EndOfLine = 0x02, 

            /// <summary>
            /// Skip past all single-line comments.
            /// </summary>
            SingleLineComment = 0x04, 

            /// <summary>
            /// Skip past all multi-line comments.
            /// </summary>
            MultiLineComment = 0x08, 

            /// <summary>
            /// Skip past all Xml header lines.
            /// </summary>
            XmlHeader = 0x10, 

            /// <summary>
            /// Skip past all preprocessor directives.
            /// </summary>
            Preprocessor = 0x20, 

            /// <summary>
            /// Skip past all of these types of symbols.
            /// </summary>
            All = 0xFF
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the parsed document.
        /// </summary>
        public CsDocument Document
        {
            get
            {
                return this.document;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Adds parameters to the fully qualified name of the item.
        /// </summary>
        /// <param name="parameters">
        /// The list of parameters on the element.
        /// </param>
        /// <param name="fullyQualifiedName">
        /// The fully qualified name of the element.
        /// </param>
        /// <returns>
        /// Returns the new fully qualified name string.
        /// </returns>
        internal static string AddQualifications(ICollection<Parameter> parameters, string fullyQualifiedName)
        {
            Param.AssertNotNull(parameters, "parameters");
            Param.AssertNotNull(fullyQualifiedName, "fullyQualifiedName");

            foreach (Parameter parameter in parameters)
            {
                fullyQualifiedName += "%" + parameter.Type;
            }

            return fullyQualifiedName;
        }

        /// <summary>
        /// Extracts a TypeToken from the literal expression.
        /// </summary>
        /// <param name="literal">
        /// The literal expression.
        /// </param>
        /// <returns>
        /// Returns the type token.
        /// </returns>
        internal static TypeToken ExtractTypeTokenFromLiteralExpression(LiteralExpression literal)
        {
            TypeToken result = TryExtractTypeTokenFromLiteralExpression(literal);
            Debug.Assert(result != null, "The literal expression does not contain a TypeToken");
            return result;
        }

        /// <summary>
        /// Extracts a TypeToken from the literal expression, if available.
        /// </summary>
        /// <param name="literal">
        /// The literal expression.
        /// </param>
        /// <returns>
        /// Returns the type token if available, null if not.
        /// </returns>
        internal static TypeToken TryExtractTypeTokenFromLiteralExpression(LiteralExpression literal)
        {
            Param.AssertNotNull(literal, "literal");

            return literal.TokenNode != null && literal.TokenNode.Value != null
                   && (literal.TokenNode.Value.CsTokenClass == CsTokenClass.Type || literal.TokenNode.Value.CsTokenClass == CsTokenClass.GenericType)
                       ? literal.TokenNode.Value as TypeToken
                       : null;
        }

        /// <summary>
        /// Finds the end of the given name, moving past member access operators.
        /// </summary>
        /// <param name="document">
        /// The document containing the name.
        /// </param>
        /// <param name="tokens">
        /// The token list.
        /// </param>
        /// <param name="startTokenNode">
        /// The first token of the name within the token list.
        /// </param>
        /// <returns>
        /// Returns the last token of the name within the token list.
        /// </returns>
        internal static Node<CsToken> FindEndOfName(CsDocument document, CsTokenList tokens, Node<CsToken> startTokenNode)
        {
            Param.AssertNotNull(document, "document");
            Param.AssertNotNull(tokens, "tokens");
            Param.AssertNotNull(startTokenNode, "startTokenNode");

            Node<CsToken> endTokenNode = startTokenNode;
            Node<CsToken> tokenNode = startTokenNode;

            if (tokenNode == null)
            {
                CsTokenType tokenType = tokenNode.Value.CsTokenType;
                if (tokenType != CsTokenType.Other && tokenType != CsTokenType.Get && tokenType != CsTokenType.Set && tokenType != CsTokenType.Add
                    && tokenType != CsTokenType.Remove)
                {
                    throw new SyntaxException(document.SourceCode, tokenNode == null ? document.MasterTokenList.Last.Value.LineNumber : tokenNode.Value.LineNumber);
                }
            }

            bool accessSymbol = false;

            for (Node<CsToken> temp = tokens.First; !tokens.OutOfBounds(temp); temp = temp.Next)
            {
                CsTokenType tempTokenType = temp.Value.CsTokenType;
                if (tempTokenType != CsTokenType.WhiteSpace && tempTokenType != CsTokenType.EndOfLine && tempTokenType != CsTokenType.SingleLineComment
                    && tempTokenType != CsTokenType.MultiLineComment && tempTokenType != CsTokenType.PreprocessorDirective)
                {
                    if (accessSymbol)
                    {
                        if (tempTokenType != CsTokenType.Other)
                        {
                            throw new SyntaxException(document.SourceCode, temp.Value.LineNumber);
                        }

                        endTokenNode = tokenNode;
                        accessSymbol = false;
                    }
                    else
                    {
                        if (temp.Value.Text == "." || temp.Value.Text == "::")
                        {
                            accessSymbol = true;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }

            return endTokenNode;
        }

        /// <summary>
        /// Finds the end of a name, moving past member access operators.
        /// </summary>
        /// <param name="document">
        /// The document containing the tokens.
        /// </param>
        /// <param name="tokens">
        /// The token list.
        /// </param>
        /// <param name="startTokenNode">
        /// The first token of the name.
        /// </param>
        /// <param name="endTokenNode">
        /// Returns the last token of the name.
        /// </param>
        /// <returns>
        /// Returns the full name.
        /// </returns>
        internal static string GetFullName(CsDocument document, CsTokenList tokens, Node<CsToken> startTokenNode, out Node<CsToken> endTokenNode)
        {
            Param.AssertNotNull(document, "document");
            Param.AssertNotNull(tokens, "tokens");
            Param.AssertNotNull(startTokenNode, "startToken");

            endTokenNode = CodeParser.FindEndOfName(document, tokens, startTokenNode);
            Debug.Assert(endTokenNode != null, "Did not find the end of the name");

            // Create the text string.
            StringBuilder text = new StringBuilder();

            for (Node<CsToken> tokenNode = startTokenNode; !tokens.OutOfBounds(tokenNode); tokenNode = tokenNode.Next)
            {
                CsTokenType tokenType = tokenNode.Value.CsTokenType;
                if (tokenType != CsTokenType.WhiteSpace && tokenType != CsTokenType.EndOfLine && tokenType != CsTokenType.SingleLineComment
                    && tokenType != CsTokenType.MultiLineComment && tokenType != CsTokenType.PreprocessorDirective)
                {
                    text.Append(tokenNode.Value.Text);
                }

                if (tokenNode == endTokenNode)
                {
                    break;
                }
            }

            return text.ToString();
        }

        /// <summary>
        /// Moves the index past any tokens that are not pure code. This includes whitespace, comments,
        /// assembly tags, preprocessors, etc.
        /// </summary>
        /// <param name="tokens">
        /// The token list.
        /// </param>
        /// <param name="start">
        /// The first token to move past.
        /// </param>
        /// <returns>
        /// Returns false if the end of the token list was reached.
        /// </returns>
        internal static bool MoveToNextCodeToken(CsTokenList tokens, ref Node<CsToken> start)
        {
            Param.AssertNotNull(tokens, "tokens");
            Param.AssertNotNull(start, "start");

            return MovePastTokens(
                tokens, 
                ref start, 
                CsTokenType.WhiteSpace, 
                CsTokenType.EndOfLine, 
                CsTokenType.SingleLineComment, 
                CsTokenType.MultiLineComment, 
                CsTokenType.PreprocessorDirective, 
                CsTokenType.Attribute);
        }

        /// <summary>
        /// Given a string containing a type, trims out all whitespace and comments from the type string. 
        /// </summary>
        /// <param name="type">
        /// The original type string.
        /// </param>
        /// <returns>
        /// Returns the trimmed string.
        /// </returns>
        internal static string TrimType(string type)
        {
            Param.Ignore(type);

            if (type == null)
            {
                return null;
            }

            int index = 0;
            char[] chars = new char[type.Length];

            bool multiLineComment = false;
            bool singleLineComment = false;

            for (int i = 0; i < type.Length; ++i)
            {
                char typeCharacter = type[i];

                if (singleLineComment)
                {
                    // When we're in a single-line comment, ignore everything up through the end of the line.
                    if (typeCharacter == '\r' || typeCharacter == '\n')
                    {
                        singleLineComment = false;
                    }
                }
                else if (multiLineComment)
                {
                    // When we're in a multi-line comment, ignore everythrough up through the end of the comment.
                    if (typeCharacter == '*' && i < type.Length - 1 && type[i + 1] == '/')
                    {
                        ++i;
                        multiLineComment = false;
                    }
                }
                else if (!char.IsWhiteSpace(typeCharacter))
                {
                    if (typeCharacter == '/' && i < type.Length - 1)
                    {
                        if (type[i + 1] == '/')
                        {
                            singleLineComment = true;
                        }
                        else if (type[i + 1] == '*')
                        {
                            multiLineComment = true;
                        }
                    }

                    if (!singleLineComment && !multiLineComment)
                    {
                        chars[index++] = typeCharacter;
                    }
                }
            }

            // If nothing was trimmed, just return the original string.
            if (index == type.Length)
            {
                return type;
            }

            return new string(chars, 0, index);
        }

        /// <summary>
        /// Parses an attribute.
        /// </summary>
        /// <param name="parentReference">
        /// The parent code unit.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the attribute lies within a block of unsafe code.
        /// </param>
        /// <param name="masterDocument">
        /// The master document object.
        /// </param>
        /// <returns>
        /// Returns the attribute.
        /// </returns>
        internal Attribute ParseAttribute(Reference<ICodePart> parentReference, bool unsafeCode, CsDocument masterDocument)
        {
            Param.AssertNotNull(parentReference, "parentReference");
            Param.Ignore(unsafeCode);
            Param.AssertNotNull(masterDocument, "masterDocument");

            Debug.Assert(this.document == null, "A CodeParser instance may only be used once.");
            this.document = masterDocument;

            Reference<ICodePart> attributeReference = new Reference<ICodePart>();

            // Get the first symbol and make sure it is the right type.
            Symbol firstSymbol = this.symbols.Peek(1);
            Debug.Assert(firstSymbol != null && firstSymbol.SymbolType == SymbolType.OpenSquareBracket, "Expected an opening square bracket");

            // The list of attribute expressions in the attribute.
            List<AttributeExpression> attributeExpressions = new List<AttributeExpression>();

            // Move past the opening square bracket.
            Bracket openingBracket = new Bracket(firstSymbol.Text, CsTokenType.OpenAttributeBracket, firstSymbol.Location, attributeReference, this.symbols.Generated);
            Node<CsToken> openingBracketNode = this.tokens.InsertLast(openingBracket);
            this.symbols.Advance();

            // Get each of the child attribute expressions within this attribute.
            while (true)
            {
                // Move to the next symbol.
                this.AdvanceToNextCodeSymbol(attributeReference);
                Symbol symbol = this.symbols.Peek(1);
                if (symbol == null)
                {
                    throw new SyntaxException(this.document.SourceCode, firstSymbol.LineNumber);
                }

                // Check the type. If this is the closing bracket then we are done.
                if (symbol.SymbolType == SymbolType.CloseSquareBracket)
                {
                    Bracket closingBracket = new Bracket(symbol.Text, CsTokenType.CloseAttributeBracket, symbol.Location, attributeReference, this.symbols.Generated);
                    Node<CsToken> closingBracketNode = this.tokens.InsertLast(closingBracket);
                    this.symbols.Advance();

                    openingBracket.MatchingBracketNode = closingBracketNode;
                    closingBracket.MatchingBracketNode = openingBracketNode;

                    break;
                }

                // Check to see if there is a target specified.
                LiteralExpression target = null;

                this.AdvanceToNextCodeSymbol(attributeReference);
                symbol = this.symbols.Peek(1);
                if (symbol == null)
                {
                    throw new SyntaxException(this.document.SourceCode, firstSymbol.LineNumber);
                }

                Node<CsToken> previousTokenNode = this.tokens.Last;
                Reference<ICodePart> attributeExpressionReference = new Reference<ICodePart>();

                if (symbol.SymbolType == SymbolType.Other || symbol.SymbolType == SymbolType.Return)
                {
                    // Peek ahead to the next symbol and check if it's a colon.
                    int index = this.GetNextCodeSymbolIndex(2);
                    if (index != -1)
                    {
                        Symbol colon = this.symbols.Peek(index);

                        if (colon.SymbolType == SymbolType.Colon)
                        {
                            // This is a target. Get the literal target expression and move past the colon.
                            // Change the type of the target symbol to OTHER so that it will be parsed
                            // correctly by the literal expression parser.
                            symbol.SymbolType = SymbolType.Other;

                            // Get the literal expression.
                            Reference<ICodePart> targetReference = new Reference<ICodePart>();
                            target = this.GetLiteralExpression(targetReference, unsafeCode);
                            Debug.Assert(target != null, "We should always succeed getting a Literal here since we have already seen a type of Other.");

                            targetReference.Target = target;

                            // Add the colon.
                            this.AdvanceToNextCodeSymbol(attributeExpressionReference);
                            this.tokens.Add(new CsToken(colon.Text, CsTokenType.AttributeColon, colon.Location, attributeExpressionReference, this.symbols.Generated));

                            this.symbols.Advance();

                            this.AdvanceToNextCodeSymbol(attributeExpressionReference);
                        }
                    }
                }

                // Now get the attribute call expression.
                Expression initialization = this.GetNextExpression(ExpressionPrecedence.None, attributeExpressionReference, unsafeCode);
                if (initialization == null)
                {
                    throw new SyntaxException(this.document.SourceCode, firstSymbol.LineNumber);
                }

                // Create and add the attribute expression.
                Debug.Assert(previousTokenNode.Next != null, "Nothing was added to the token list!");

                AttributeExpression attributeExpression = new AttributeExpression(
                    new CsTokenList(this.tokens, previousTokenNode.Next, this.tokens.Last), target, initialization);

                attributeExpressions.Add(attributeExpression);
                attributeExpressionReference.Target = attributeExpression;

                // Get the next item, which must either be a comma or the closing attribute bracket.
                this.AdvanceToNextCodeSymbol(attributeReference);
                symbol = this.symbols.Peek(1);
                if (symbol == null)
                {
                    throw new SyntaxException(this.document.SourceCode, firstSymbol.LineNumber);
                }

                if (symbol.SymbolType == SymbolType.Comma)
                {
                    // Add the comma and continue.
                    this.tokens.Add(this.GetToken(CsTokenType.Comma, SymbolType.Comma, attributeReference));
                }
                else if (symbol.SymbolType != SymbolType.CloseSquareBracket)
                {
                    // This type of symbol is unexpected.
                    throw new SyntaxException(this.document.SourceCode, firstSymbol.LineNumber);
                }
            }

            // Get the location of the attribute.
            CodeLocation location = CsToken.JoinLocations(this.tokens.First, this.tokens.Last);

            // Create and return the attribute.
            Attribute attribute = new Attribute(
                this.tokens, location, parentReference, attributeExpressions.ToArray(), this.tokens.First.Value.Generated || this.tokens.Last.Value.Generated);

            attributeReference.Target = attribute;
            return attribute;
        }

        /// <summary>
        /// Parses the contents of the document.
        /// </summary>
        internal void ParseDocument()
        {
            Debug.Assert(this.document == null, "A CodeParser instance may only be used once.");

            // Find the list of symbols in the document.
            List<Symbol> symbolList = this.lexer.GetSymbols(this.lexer.SourceCode, this.lexer.SourceCode.Project.Configuration);

            // Create the symbol manager class.
            this.symbols = new SymbolManager(symbolList);

            // Create the document object.
            this.document = new CsDocument(this.lexer.SourceCode, this.parser, this.tokens);

            Reference<ICodePart> documentRootReference = new Reference<ICodePart>();

            // Get the file header if it exists.
            FileHeader fileHeader = this.GetFileHeader(documentRootReference);

            // Let the symbol manager know if this document contains generated code.
            if (fileHeader.Generated)
            {
                this.symbols.IncrementGeneratedCodeBlocks();
            }

            this.document.FileHeader = fileHeader;

            // Create a declaration for the root element.
            Declaration declaration = new Declaration(
                new CsTokenList(this.document.Tokens), Strings.Root, ElementType.Root, AccessModifierType.Public, new Dictionary<CsTokenType, CsToken>());

            // Create the root element for the document.
            DocumentRoot root = new DocumentRoot(this.document, declaration, fileHeader.Generated);
            documentRootReference.Target = root;

            // Parse the contents of the document.
            this.ParseElementContainerBody(root, documentRootReference, this.parser.PartialElements, false);

            // Check if there are any tokens in the document.
            if (this.document.Tokens.Count > 0)
            {
                // Fill in the token list for the root element.
                root.Tokens = new CsTokenList(this.document.Tokens, this.document.Tokens.First, this.document.Tokens.Last);

                // Fill in the location for the element.
                root.Location = CsToken.JoinLocations(this.document.Tokens.First, this.document.Tokens.Last);
            }

            // Add the root element to the document.
            this.document.RootElement = root;

            // When in debug mode, ensure that all tokens are correctly mapped to a parent element.
            this.DebugValidateParentReferences();
        }

        /// <summary>
        /// Moves the index past any whitespace characters.
        /// </summary>
        /// <param name="tokens">
        /// The collection containing the start token.
        /// </param>
        /// <param name="start">
        /// The first token to move past.
        /// </param>
        /// <param name="movePastTypes">
        /// The types of tokens to move past.
        /// </param>
        /// <returns>
        /// Returns false if the end of the token list was reached.
        /// </returns>
        private static bool MovePastTokens(CsTokenList tokens, ref Node<CsToken> start, params CsTokenType[] movePastTypes)
        {
            Param.AssertNotNull(tokens, "tokens");
            Param.AssertNotNull(start, "start");
            Param.Ignore(movePastTypes);

            for (Node<CsToken> tokenNode = start; !tokens.OutOfBounds(tokenNode); tokenNode = tokenNode.Next)
            {
                bool found = false;

                for (int i = 0; i < movePastTypes.Length; ++i)
                {
                    if (tokenNode.Value.CsTokenType == movePastTypes[i])
                    {
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    start = tokenNode;
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Find the end of a name.
        /// </summary>
        /// <param name="startIndex">
        /// The first index of the name.
        /// </param>
        /// <returns>
        /// Returns the last index of the name.
        /// </returns>
        private int AdvanceToEndOfName(int startIndex)
        {
            Param.AssertGreaterThanOrEqualToZero(startIndex, "startIndex");

            bool generic;
            return this.AdvanceToEndOfName(startIndex, out generic);
        }

        /// <summary>
        /// Find the end of a name.
        /// </summary>
        /// <param name="startIndex">
        /// The first index of the name.
        /// </param>
        /// <param name="generic">
        /// Returns true if the first part of the name is a generic.
        /// </param>
        /// <returns>
        /// Returns the last index of the name.
        /// </returns>
        private int AdvanceToEndOfName(int startIndex, out bool generic)
        {
            Param.AssertGreaterThanOrEqualToZero(startIndex, "startIndex");

            generic = false;

            Symbol symbol = this.symbols.Peek(startIndex);
            Debug.Assert(symbol != null && symbol.SymbolType == SymbolType.Other, "Expected a name symbol");

            int index = startIndex;
            int endIndex = startIndex;

            int leadingGenericIndex = this.GetNextCodeSymbolIndex(index + 1);
            if (leadingGenericIndex != -1)
            {
                symbol = this.symbols.Peek(leadingGenericIndex);
                if (symbol.SymbolType == SymbolType.LessThan)
                {
                    // Move up to the closing bracket and check that this is actually a generic type.
                    leadingGenericIndex = this.AdvanceToClosingGenericSymbol(leadingGenericIndex + 1);
                    if (leadingGenericIndex != -1)
                    {
                        index = leadingGenericIndex;
                        endIndex = index;
                        generic = true;
                    }
                }
            }

            bool dot = false;
            while (true)
            {
                index = this.GetNextCodeSymbolIndex(index + 1);
                if (index == -1)
                {
                    break;
                }

                symbol = this.symbols.Peek(index);
                if (symbol.SymbolType == SymbolType.Other)
                {
                    if (dot)
                    {
                        // Peek ahead and see if this looks like a generic.
                        int temp = this.GetNextCodeSymbolIndex(index + 1);
                        if (temp != -1 && this.symbols.Peek(temp).SymbolType == SymbolType.LessThan)
                        {
                            temp = this.AdvanceToClosingGenericSymbol(temp + 1);
                            if (temp == -1)
                            {
                                break;
                            }
                            else
                            {
                                index = temp;
                            }
                        }

                        endIndex = index;
                        dot = false;
                    }
                    else
                    {
                        break;
                    }
                }
                else if (symbol.SymbolType == SymbolType.Dot || symbol.SymbolType == SymbolType.QualifiedAlias)
                {
                    if (dot)
                    {
                        break;
                    }
                    else
                    {
                        dot = true;
                    }
                }
                else
                {
                    break;
                }
            }

            return endIndex;
        }

        /// <summary>
        /// Advances past any whitespace and comments in the code.
        /// </summary>
        /// <param name="parentReference">
        /// The parent code part.
        /// </param>
        private void AdvanceToNextCodeSymbol(Reference<ICodePart> parentReference)
        {
            Param.AssertNotNull(parentReference, "parentReference");
            this.AdvanceToNextCodeSymbol(SkipSymbols.All, parentReference);
        }

        /// <summary>
        /// Advances past any whitespace and comments in the code.
        /// </summary>
        /// <param name="skip">
        /// Indicates the types of tokens to advance past.
        /// </param>
        /// <param name="parentReference">
        /// The parent code part.
        /// </param>
        private void AdvanceToNextCodeSymbol(SkipSymbols skip, Reference<ICodePart> parentReference)
        {
            Param.Ignore(skip);
            Param.AssertNotNull(parentReference, "parentReference");

            Symbol symbol = this.symbols.Peek(1);
            while (symbol != null)
            {
                if (symbol.SymbolType == SymbolType.WhiteSpace && (skip & SkipSymbols.WhiteSpace) != 0)
                {
                    this.tokens.Add(new Whitespace(symbol.Text, symbol.Location, parentReference, this.symbols.Generated));
                    this.symbols.Advance();
                }
                else if (symbol.SymbolType == SymbolType.EndOfLine && (skip & SkipSymbols.EndOfLine) != 0)
                {
                    this.tokens.Add(new CsToken(symbol.Text, CsTokenType.EndOfLine, symbol.Location, parentReference, this.symbols.Generated));
                    this.symbols.Advance();
                }
                else if (symbol.SymbolType == SymbolType.SingleLineComment && (skip & SkipSymbols.SingleLineComment) != 0)
                {
                    this.tokens.Add(new CsToken(symbol.Text, CsTokenType.SingleLineComment, symbol.Location, parentReference, this.symbols.Generated));
                    this.symbols.Advance();
                }
                else if (symbol.SymbolType == SymbolType.MultiLineComment && (skip & SkipSymbols.MultiLineComment) != 0)
                {
                    this.tokens.Add(new CsToken(symbol.Text, CsTokenType.MultiLineComment, symbol.Location, parentReference, this.symbols.Generated));
                    this.symbols.Advance();
                }
                else if (symbol.SymbolType == SymbolType.PreprocessorDirective && (skip & SkipSymbols.Preprocessor) != 0)
                {
                    this.tokens.Add(this.GetPreprocessorDirectiveToken(symbol, parentReference, this.symbols.Generated));
                    this.symbols.Advance();
                }
                else if (symbol.SymbolType == SymbolType.XmlHeaderLine && (skip & SkipSymbols.XmlHeader) != 0)
                {
                    this.tokens.Add(new CsToken(symbol.Text, CsTokenType.XmlHeaderLine, symbol.Location, parentReference, this.symbols.Generated));
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
        /// Creates a new syntax exception which attempts to find the best line number 
        /// given the current set up symbols and tokens.
        /// </summary>
        /// <returns>Returns the exception.</returns>
        private SyntaxException CreateSyntaxException()
        {
            throw new SyntaxException(this.document.SourceCode, this.GetBestLineNumber());
        }

        /// <summary>
        /// Walks through the document model and ensures that every item in the model is 
        /// correctly mapped to a parent code part.
        /// </summary>
        [Conditional("DEBUG")]
        private void DebugValidateParentReferences()
        {
            for (Node<CsToken> token = this.document.Tokens.First; token != null; token = token.Next)
            {
                if (token.Value.Parent == null)
                {
                    Debug.Fail("The parent target has not been set for a token.");
                }
            }
        }

        /// <summary>
        /// Gets an attribute from the code.
        /// </summary>
        /// <param name="parentReference">
        /// The parent code unit.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the attribute lies within an unsafe code block.
        /// </param>
        /// <returns>
        /// Returns the attribute.
        /// </returns>
        private Attribute GetAttribute(Reference<ICodePart> parentReference, bool unsafeCode)
        {
            Param.AssertNotNull(parentReference, "parentReference");
            Param.Ignore(unsafeCode);

            CodeParser attributeParser = new CodeParser(this.parser, this.symbols);
            return attributeParser.ParseAttribute(parentReference, unsafeCode, this.document);
        }

        /// <summary>
        /// Gets the closest line number to the current part of the file being parsed.
        /// </summary>
        /// <returns>Returns the best line number.</returns>
        private int GetBestLineNumber()
        {
            int lineNumber = 1;
            if (this.symbols.Current != null)
            {
                lineNumber = this.symbols.Current.LineNumber;
            }
            else if (this.tokens.Count > 1)
            {
                lineNumber = this.tokens.Last.Value.LineNumber;
            }

            return lineNumber;
        }

        /// <summary>
        /// Gets the next conditional compilation directive from the code.
        /// </summary>
        /// <param name="preprocessorSymbol">
        /// The symbol representing the directive.
        /// </param>
        /// <param name="type">
        /// The type of the conditional compilation directive.
        /// </param>
        /// <param name="startIndex">
        /// The start index of the body of the directive.
        /// </param>
        /// <param name="parent">
        /// The parent code part.
        /// </param>
        /// <param name="generated">
        /// Indicates whether the directive lies within a block of generated code.
        /// </param>
        /// <returns>
        /// Returns the directive.
        /// </returns>
        private ConditionalCompilationDirective GetConditionalCompilationDirective(
            Symbol preprocessorSymbol, ConditionalCompilationDirectiveType type, int startIndex, Reference<ICodePart> parent, bool generated)
        {
            Param.AssertNotNull(preprocessorSymbol, "preprocessorSymbol");
            Param.Ignore(type);
            Param.AssertGreaterThanOrEqualToZero(startIndex, "startIndex");
            Param.AssertNotNull(parent, "parent");
            Param.Ignore(generated);

            Expression body = null;

            // Extract the body of the directive if necessary.
            if (type != ConditionalCompilationDirectiveType.Endif && startIndex < preprocessorSymbol.Text.Length)
            {
                body = CodeParser.GetConditionalPreprocessorBodyExpression(this.parser, this.document.SourceCode, preprocessorSymbol, startIndex);
            }

            // Create and return the directive.
            return new ConditionalCompilationDirective(preprocessorSymbol.Text, type, body, preprocessorSymbol.Location, parent, generated);
        }

        /// <summary>
        /// Gets the file header from a piece of code. The file header must start on the first
        /// line of code, and it must follow the format shown below. This method will strip off
        /// the first and last lines, as well as the leading slashes on all lines, and return only
        /// the header text.
        /// </summary>
        /// <param name="parentReference">
        /// The parent code unit.
        /// </param>
        /// <returns>
        /// Returns the file header.
        /// </returns>
        private FileHeader GetFileHeader(Reference<ICodePart> parentReference)
        {
            Param.AssertNotNull(parentReference, "parentReference");

            // Make sure that we are starting at the beginning of the file.
            Debug.Assert(this.symbols.CurrentIndex == -1, "Expected to be at the  beginning of the file");

            // Stores the header text.
            StringBuilder header = new StringBuilder();

            // Move past whitespace and pragmas.
            while (true)
            {
                Symbol symbol = this.symbols.Peek(1);
                if (symbol == null
                    || (symbol.SymbolType != SymbolType.WhiteSpace && symbol.SymbolType != SymbolType.EndOfLine && symbol.SymbolType != SymbolType.PreprocessorDirective))
                {
                    break;
                }

                this.document.MasterTokenList.Add(this.GetToken(TokenTypeFromSymbolType(symbol.SymbolType), symbol.SymbolType, parentReference));
            }

            Reference<ICodePart> headerReference = new Reference<ICodePart>();
            Node<CsToken> firstTokenNode = null;

            // Loop until the entire header has been read.
            bool finished = false;
            int newLineCount = 0;
            while (!finished)
            {
                // Grab the next symbol but do not advance the index.
                Symbol symbol = this.symbols.Peek(1);
                if (symbol == null)
                {
                    break;
                }
                else if (symbol.SymbolType == SymbolType.SingleLineComment)
                {
                    newLineCount = 0;

                    // Ignore lines that start with //- since these are borders. We only want the body.
                    if (!symbol.Text.StartsWith("//-", StringComparison.Ordinal))
                    {
                        // Copy everything after the comment slashes.
                        header.Append(symbol.Text.Substring(2, symbol.Text.Length - 2));
                    }

                    // Advance the symbol manager.
                    Node<CsToken> tokenNode =
                        this.document.MasterTokenList.InsertLast(this.GetToken(CsTokenType.SingleLineComment, SymbolType.SingleLineComment, headerReference));

                    if (firstTokenNode == null)
                    {
                        firstTokenNode = tokenNode;
                    }
                }
                else if (symbol.SymbolType == SymbolType.WhiteSpace)
                {
                    this.document.MasterTokenList.Add(this.GetToken(CsTokenType.WhiteSpace, SymbolType.WhiteSpace, headerReference));
                }
                else if (symbol.SymbolType == SymbolType.EndOfLine)
                {
                    // If we've seen more than one newline in a row, we are past the end of the file header.
                    if (++newLineCount > 1)
                    {
                        break;
                    }

                    this.document.MasterTokenList.Add(this.GetToken(CsTokenType.EndOfLine, SymbolType.EndOfLine, headerReference));
                }
                else
                {
                    break;
                }
            }

            // Find the last token in the header. Work backwards to find the previous comment line.
            Node<CsToken> lastTokenNode = null;
            for (Node<CsToken> token = this.document.MasterTokenList.Last; token != null; token = token.Previous)
            {
                if (token.Value.CsTokenType == CsTokenType.SingleLineComment)
                {
                    lastTokenNode = token;
                    break;
                }
            }

            CsTokenList fileHeaderTokens = null;
            if (firstTokenNode == null)
            {
                fileHeaderTokens = new CsTokenList(this.document.MasterTokenList);
            }
            else
            {
                fileHeaderTokens = new CsTokenList(this.document.MasterTokenList, firstTokenNode, lastTokenNode);
            }

            FileHeader fileHeader = new FileHeader(header.ToString(), fileHeaderTokens, parentReference);
            headerReference.Target = fileHeader;

            return fileHeader;
        }

        /// <summary>
        /// Gets the argument list from a generic type.
        /// </summary>
        /// <param name="genericTypeReference">
        /// A reference to the generic type.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code is marked as unsafe.
        /// </param>
        /// <param name="name">
        /// Optional name of the generic type.
        /// </param>
        /// <param name="startIndex">
        /// The first index of the generic.
        /// </param>
        /// <param name="endIndex">
        /// Returns the index of the last token in the generic argument list.
        /// </param>
        /// <returns>
        /// Returns a list of tokens containing the arguments.
        /// </returns>
        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "May be simplified later.")]
        private MasterList<CsToken> GetGenericArgumentList(Reference<ICodePart> genericTypeReference, bool unsafeCode, CsToken name, int startIndex, out int endIndex)
        {
            Param.AssertNotNull(genericTypeReference, "genericTypeReference");
            Param.Ignore(unsafeCode);
            Param.Ignore(name);
            Param.AssertGreaterThanOrEqualToZero(startIndex, "startIndex");

            endIndex = -1;
            MasterList<CsToken> genericArgumentListTokens = null;

            // Move past whitespace and comments.
            int index = startIndex;
            while (true)
            {
                Symbol next = this.symbols.Peek(index);
                if (next == null
                    || (next.SymbolType != SymbolType.WhiteSpace && next.SymbolType != SymbolType.EndOfLine && next.SymbolType != SymbolType.SingleLineComment
                        && next.SymbolType != SymbolType.MultiLineComment && next.SymbolType != SymbolType.PreprocessorDirective))
                {
                    break;
                }

                ++index;
            }

            // The next symbol should be an opening bracket, if this is a generic.
            Symbol symbol = this.symbols.Peek(index);
            if (symbol != null && symbol.SymbolType == SymbolType.LessThan)
            {
                // This might be a generic. Assume that it is and start creating tokens.
                genericArgumentListTokens = new MasterList<CsToken>();

                // Add the name if one was provided.
                if (name != null)
                {
                    genericArgumentListTokens.Add(name);
                }

                Node<CsToken> openingGenericBracketNode = null;

                // Add everything up to the opening bracket into the token list.
                for (int i = startIndex; i <= index; ++i)
                {
                    symbol = this.symbols.Peek(i);
                    Debug.Assert(symbol != null, "The next symbol should not be null");

                    if (symbol.SymbolType == SymbolType.LessThan)
                    {
                        if (openingGenericBracketNode != null)
                        {
                            // This is not a generic statement.
                            return null;
                        }

                        Bracket openingGenericBracket = new Bracket(
                            symbol.Text, CsTokenType.OpenGenericBracket, symbol.Location, genericTypeReference, this.symbols.Generated);
                        openingGenericBracketNode = genericArgumentListTokens.InsertLast(openingGenericBracket);
                    }
                    else
                    {
                        genericArgumentListTokens.Add(this.ConvertSymbol(symbol, TokenTypeFromSymbolType(symbol.SymbolType), genericTypeReference));
                    }
                }

                // Loop through the rest of the symbols.
                while (true)
                {
                    symbol = this.symbols.Peek(++index);
                    if (symbol == null)
                    {
                        // The code ran out before we found the end of the generic.
                        throw new SyntaxException(this.document.SourceCode, name.LineNumber);
                    }
                    else if (symbol.SymbolType == SymbolType.GreaterThan)
                    {
                        if (openingGenericBracketNode == null)
                        {
                            // This is not a generic statement.
                            return null;
                        }

                        // This is the end of the generic statement. Add the closing bracket to the token list.
                        Bracket closingGenericBracket = new Bracket(
                            symbol.Text, CsTokenType.CloseGenericBracket, symbol.Location, genericTypeReference, this.symbols.Generated);
                        Node<CsToken> closingGenericBracketNode = genericArgumentListTokens.InsertLast(closingGenericBracket);

                        ((Bracket)openingGenericBracketNode.Value).MatchingBracketNode = closingGenericBracketNode;
                        closingGenericBracket.MatchingBracketNode = openingGenericBracketNode;

                        endIndex = index;
                        break;
                    }
                    else if (symbol.SymbolType == SymbolType.Out || symbol.SymbolType == SymbolType.In)
                    {
                        // Get the in or out keyword.
                        genericArgumentListTokens.Add(
                            this.ConvertSymbol(symbol, symbol.SymbolType == SymbolType.In ? CsTokenType.In : CsTokenType.Out, genericTypeReference));
                    }
                    else if (symbol.SymbolType == SymbolType.OpenParenthesis)
                    {
                        // Tuple type definition is starting.
                        genericArgumentListTokens.InsertLast(new Bracket(
                            symbol.Text, CsTokenType.OpenParenthesis, symbol.Location, genericTypeReference, this.symbols.Generated)); 
                    }
                    else if (symbol.SymbolType == SymbolType.CloseParenthesis)
                    {
                        // Tuple type definition is finishing.
                        genericArgumentListTokens.InsertLast(new Bracket(
                            symbol.Text, CsTokenType.CloseParenthesis, symbol.Location, genericTypeReference, this.symbols.Generated)); 
                    }
                    else if (symbol.SymbolType == SymbolType.Other)
                    {
                        int lastIndex = 0;
                        Reference<ICodePart> wordReference = new Reference<ICodePart>();
                        CsToken word = this.GetTypeTokenAux(wordReference, genericTypeReference, unsafeCode, true, false, index, out lastIndex);
                        if (word == null)
                        {
                            throw new SyntaxException(this.document.SourceCode, symbol.LineNumber);
                        }

                        // Advance the index to the end of the token.
                        index = lastIndex;

                        // Add the token.
                        genericArgumentListTokens.Add(word);
                    }
                    else if (symbol.SymbolType == SymbolType.WhiteSpace || symbol.SymbolType == SymbolType.EndOfLine || symbol.SymbolType == SymbolType.SingleLineComment
                             || symbol.SymbolType == SymbolType.MultiLineComment || symbol.SymbolType == SymbolType.PreprocessorDirective)
                    {
                        // Add these to the token list.
                        genericArgumentListTokens.Add(this.ConvertSymbol(symbol, TokenTypeFromSymbolType(symbol.SymbolType), genericTypeReference));
                    }
                    else if (symbol.SymbolType == SymbolType.Comma)
                    {
                        genericArgumentListTokens.Add(this.ConvertSymbol(symbol, CsTokenType.Comma, genericTypeReference));
                    }
                    else if (symbol.SymbolType == SymbolType.OpenSquareBracket)
                    {
                        // An attribute on the generic type.
                        genericArgumentListTokens.Add(this.GetAttribute(genericTypeReference, unsafeCode));
                    }
                    else
                    {
                        // Any other symbol signifies that this is not a generic statement.
                        genericArgumentListTokens = null;
                        break;
                    }
                }
            }

            return genericArgumentListTokens;
        }

        /// <summary>
        /// Checks whether the symbol manager is currently sitting on the start of a generic token. 
        /// If so, reads the generic and returns it as a token.
        /// </summary>
        /// <param name="parentReference">
        /// The parent code unit.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code is marked as unsafe.
        /// </param>
        /// <returns>
        /// Returns the generic token, or null if the symbol manager is not sitting on a generic.
        /// </returns>
        private GenericType GetGenericToken(Reference<ICodePart> parentReference, bool unsafeCode)
        {
            Param.AssertNotNull(parentReference, "parentReference");
            Param.Ignore(unsafeCode);

            int lastSymbolIndex = -1;

            GenericType generic = this.GetGenericTokenAux(parentReference, unsafeCode, 1, out lastSymbolIndex);
            if (generic != null)
            {
                this.symbols.CurrentIndex += lastSymbolIndex;
            }

            return generic;
        }

        /// <summary>
        /// Reads a generic token from the document.
        /// </summary>
        /// <param name="genericTokenReference">
        /// A reference to the generic token.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code is marked as unsafe.
        /// </param>
        /// <param name="startIndex">
        /// The first index of the generic.
        /// </param>
        /// <param name="lastIndex">
        /// Returns the last index of the generic.
        /// </param>
        /// <returns>
        /// Returns the generic token, or null if the symbol manager is not sitting on a generic.
        /// </returns>
        /// <remarks>
        /// This should only be called by GetGenericToken.
        /// </remarks>
        private GenericType GetGenericTokenAux(Reference<ICodePart> genericTokenReference, bool unsafeCode, int startIndex, out int lastIndex)
        {
            Param.AssertNotNull(genericTokenReference, "genericTokenReference");
            Param.Ignore(unsafeCode);
            Param.AssertGreaterThanOrEqualToZero(startIndex, "startIndex");

            lastIndex = -1;

            // Get the first symbol. This should be an unknown word type.
            Symbol firstSymbol = this.symbols.Peek(startIndex);
            Debug.Assert(firstSymbol != null && firstSymbol.SymbolType == SymbolType.Other, "Expected a text symbol");

            // This will hold the generic type if we create one.
            GenericType generic = null;

            // Create a token for the name.
            CsToken name = new CsToken(firstSymbol.Text, CsTokenType.Other, firstSymbol.Location, genericTokenReference, this.symbols.Generated);

            // Get the argument list. This will return null if this is not a generic.
            MasterList<CsToken> genericArgumentTokens = this.GetGenericArgumentList(genericTokenReference, unsafeCode, name, startIndex + 1, out lastIndex);

            if (genericArgumentTokens != null)
            {
                generic = new GenericType(
                    genericArgumentTokens, CsToken.JoinLocations(firstSymbol.Location, genericArgumentTokens.Last), genericTokenReference, this.symbols.Generated);

                Reference<ICodePart> genericTypeReference = new Reference<ICodePart>(generic);
                foreach (CsToken token in genericArgumentTokens)
                {
                    token.ParentRef = genericTypeReference;
                }
            }

            return generic;
        }

        /// <summary>
        /// Advances past any whitespace and comments in the code.
        /// </summary>
        /// <param name="startIndex">
        /// The first index to peek.
        /// </param>
        /// <returns>
        /// Returns the peek index of the next code symbol or -1 if there 
        /// are no more code symbols.
        /// </returns>
        private int GetNextCodeSymbolIndex(int startIndex)
        {
            Param.AssertGreaterThanOrEqualToZero(startIndex, "startIndex");

            int index = -1;

            while (true)
            {
                Symbol symbol = this.symbols.Peek(startIndex);
                if (symbol == null)
                {
                    break;
                }
                else if (symbol.SymbolType != SymbolType.WhiteSpace && symbol.SymbolType != SymbolType.EndOfLine && symbol.SymbolType != SymbolType.SingleLineComment
                         && symbol.SymbolType != SymbolType.MultiLineComment && symbol.SymbolType != SymbolType.PreprocessorDirective)
                {
                    index = startIndex;
                    break;
                }

                ++startIndex;
            }

            return index;
        }

        /// <summary>
        /// Advances to the next code symbol and returns it.
        /// </summary>
        /// <param name="symbolType">
        /// The expected type of the symbol.
        /// </param>
        /// <param name="parentReference">
        /// The parent code unit.
        /// </param>
        /// <returns>
        /// Returns the next code symbol.
        /// </returns>
        /// <exception cref="SyntaxException">
        /// Will be thrown if there are no more symbols in the document or if the 
        /// next symbol is not of the expected type.
        /// </exception>
        private Symbol GetNextSymbol(SymbolType symbolType, Reference<ICodePart> parentReference)
        {
            Param.Ignore(symbolType);
            Param.AssertNotNull(parentReference, "parentReference");

            return this.GetNextSymbol(symbolType, SkipSymbols.All, parentReference);
        }

        /// <summary>
        /// Advances to the next code symbol and returns it.
        /// </summary>
        /// <param name="symbolType">
        /// The expected type of the symbol.
        /// </param>
        /// <param name="skip">
        /// The types of symbols to skip past.
        /// </param>
        /// <param name="parentReference">
        /// The parent code part.
        /// </param>
        /// <returns>
        /// Returns the next code symbol.
        /// </returns>
        /// <exception cref="SyntaxException">
        /// Will be thrown if there are no more symbols in the document or if the 
        /// next symbol is not of the expected type.
        /// </exception>
        private Symbol GetNextSymbol(SymbolType symbolType, SkipSymbols skip, Reference<ICodePart> parentReference)
        {
            Param.Ignore(symbolType, skip);
            Param.AssertNotNull(parentReference, "parentReference");

            Symbol symbol = this.GetNextSymbol(skip, parentReference);
            if (symbol.SymbolType != symbolType)
            {
                throw this.CreateSyntaxException();
            }

            return symbol;
        }

        /// <summary>
        /// Advances to the next code symbol and returns it.
        /// </summary>
        /// <param name="parentReference">
        /// The parent code part.
        /// </param>
        /// <returns>
        /// Returns the next code symbol.
        /// </returns>
        /// <exception cref="SyntaxException">
        /// Will be thrown if there are no more symbols in the document.
        /// </exception>
        private Symbol GetNextSymbol(Reference<ICodePart> parentReference)
        {
            Param.AssertNotNull(parentReference, "parentReference");
            return this.GetNextSymbol(SkipSymbols.All, parentReference);
        }

        /// <summary>
        /// Advances to the next code symbol and returns it.
        /// </summary>
        /// <param name="skip">
        /// Indicates the types of symbols to skip past.
        /// </param>
        /// <param name="parentReference">
        /// The parent code part.
        /// </param>
        /// <returns>
        /// Returns the next code symbol.
        /// </returns>
        /// <exception cref="SyntaxException">
        /// Will be thrown if there are no more symbols in the document.
        /// </exception>
        private Symbol GetNextSymbol(SkipSymbols skip, Reference<ICodePart> parentReference)
        {
            Param.Ignore(skip);
            Param.AssertNotNull(parentReference, "parentReference");

            return this.GetNextSymbol(skip, parentReference, false);
        }

        /// <summary>
        /// Advances to the next code symbol and returns it.
        /// </summary>
        /// <param name="skip">
        /// Indicates the types of symbols to skip past.
        /// </param>
        /// <param name="parentReference">
        /// The parent code part.
        /// </param>
        /// <param name="allowNull">
        /// If true, indicates that this method is allowed to return a null symbol, if there are no
        /// more symbols in the document. If false, the method will throw an exception if it is unable to get another symbol.
        /// </param>
        /// <returns>
        /// Returns the next code symbol.
        /// </returns>
        /// <exception cref="SyntaxException">
        /// Will be thrown if there are no more symbols in the document.
        /// </exception>
        private Symbol GetNextSymbol(SkipSymbols skip, Reference<ICodePart> parentReference, bool allowNull)
        {
            Param.Ignore(skip);
            Param.AssertNotNull(parentReference, "parentReference");
            Param.Ignore(allowNull);

            this.AdvanceToNextCodeSymbol(skip, parentReference);

            Symbol symbol = this.symbols.Peek(1);
            if (symbol == null && !allowNull)
            {
                throw this.CreateSyntaxException();
            }

            return symbol;
        }

        /// <summary>
        /// Returns the next code symbol without advancing to it.
        /// </summary>
        /// <param name="skip">Indicates the types of symbols to skip past.</param>
        /// <param name="allowNull">If true, indicates that this method is allowed to return a null symbol, if
        /// there are no more symbols in the document. If false, the method will throw an exception if it is unable
        /// to get another symbol.</param>
        /// <returns>Returns the next code symbol.</returns>
        /// <exception cref="SyntaxException">Will be thrown if there are no more symbols in the document.
        /// </exception>
        private Symbol PeekNextSymbol(SkipSymbols skip, bool allowNull)
        {
            int foundPosition;
            return this.PeekNextSymbolFrom(0, skip, allowNull, out foundPosition);
        }

        /// <summary>
        /// Returns the next code symbol from the requested position without advancing to it.
        /// </summary>
        /// <param name="position">The relative position to current index, from which the next symbol should be peeked.</param>
        /// <param name="skip">Indicates the types of symbols to skip past.</param>
        /// <param name="allowNull">If true, indicates that this method is allowed to return a null symbol, if
        /// there are no more symbols in the document. If false, the method will throw an exception if it is unable
        /// to get another symbol.</param>
        /// <param name="foundAtPosition"> The position from current at which the returned symbol was found. </param>
        /// <returns>Returns the next code symbol.</returns>
        /// <exception cref="SyntaxException">Will be thrown if there are no more symbols in the document.
        /// </exception>
        private Symbol PeekNextSymbolFrom(int position, SkipSymbols skip, bool allowNull, out int foundAtPosition)
        {
            Param.AssertGreaterThanOrEqualToZero(position, nameof(position));
            Param.Ignore(skip);

            int index = position + 1;
            Symbol symbol = this.symbols.Peek(index);

            while (symbol != null)
            {
                if (symbol.SymbolType == SymbolType.WhiteSpace && (skip & SkipSymbols.WhiteSpace) != 0)
                {
                    index += 1;
                }
                else if (symbol.SymbolType == SymbolType.EndOfLine && (skip & SkipSymbols.EndOfLine) != 0)
                {
                    index += 1;
                }
                else if (symbol.SymbolType == SymbolType.SingleLineComment && (skip & SkipSymbols.SingleLineComment) != 0)
                {
                    index += 1;
                }
                else if (symbol.SymbolType == SymbolType.MultiLineComment && (skip & SkipSymbols.MultiLineComment) != 0)
                {
                    index += 1;
                }
                else if (symbol.SymbolType == SymbolType.PreprocessorDirective && (skip & SkipSymbols.Preprocessor) != 0)
                {
                    index += 1;
                }
                else if (symbol.SymbolType == SymbolType.XmlHeaderLine && (skip & SkipSymbols.XmlHeader) != 0)
                {
                    index += 1;
                }
                else
                {
                    break;
                }

                symbol = this.symbols.Peek(index);
            }

            if (symbol == null && !allowNull)
            {
                throw this.CreateSyntaxException();
            }

            foundAtPosition = index;
            return symbol;
        }

        /// <summary>
        /// Gets and converts preprocessor directive.
        /// </summary>
        /// <param name="preprocessorSymbol">
        /// The preprocessor symbol.
        /// </param>
        /// <param name="parent">
        /// The parent code part.
        /// </param>
        /// <param name="generated">
        /// Indicates whether the preprocessor directive lies within a block of generated code.
        /// </param>
        /// <returns>
        /// Returns the preprocessor directive.
        /// </returns>
        private Preprocessor GetPreprocessorDirectiveToken(Symbol preprocessorSymbol, Reference<ICodePart> parent, bool generated)
        {
            Param.AssertNotNull(preprocessorSymbol, "preprocessorSymbol");
            Param.AssertNotNull(parent, "parent");
            Param.Ignore(generated);

            Debug.Assert(preprocessorSymbol != null && preprocessorSymbol.SymbolType == SymbolType.PreprocessorDirective, "Expected a preprocessor directive");

            // Get the type of the preprocessor directive.
            int bodyIndex;
            string type = CsParser.GetPreprocessorDirectiveType(preprocessorSymbol, out bodyIndex);
            if (type == null)
            {
                throw new SyntaxException(this.document.SourceCode, preprocessorSymbol.LineNumber);
            }

            // Create the correct preprocessor object type.
            Preprocessor preprocessor = null;
            if (type == "region")
            {
                Region region = new Region(preprocessorSymbol.Text, preprocessorSymbol.Location, parent, true, generated);
                this.symbols.PushRegion(region);
                preprocessor = region;
            }
            else if (type == "endregion")
            {
                Region endregion = new Region(preprocessorSymbol.Text, preprocessorSymbol.Location, parent, false, generated);
                Region startregion = this.symbols.PopRegion();

                if (startregion == null)
                {
                    throw new SyntaxException(this.document.SourceCode, preprocessorSymbol.LineNumber);
                }

                startregion.Partner = endregion;
                endregion.Partner = startregion;

                preprocessor = endregion;
            }
            else if (type == "if")
            {
                preprocessor = this.GetConditionalCompilationDirective(preprocessorSymbol, ConditionalCompilationDirectiveType.If, bodyIndex, parent, generated);
            }
            else if (type == "elif")
            {
                preprocessor = this.GetConditionalCompilationDirective(preprocessorSymbol, ConditionalCompilationDirectiveType.Elif, bodyIndex, parent, generated);
            }
            else if (type == "else")
            {
                preprocessor = this.GetConditionalCompilationDirective(preprocessorSymbol, ConditionalCompilationDirectiveType.Else, bodyIndex, parent, generated);
            }
            else if (type == "endif")
            {
                preprocessor = this.GetConditionalCompilationDirective(preprocessorSymbol, ConditionalCompilationDirectiveType.Endif, bodyIndex, parent, generated);
            }
            else
            {
                preprocessor = new Preprocessor(preprocessorSymbol.Text, preprocessorSymbol.Location, parent, generated);
            }

            return preprocessor;
        }

        /// <summary>
        /// Gets the next variable.
        /// </summary>
        /// <param name="parentReference">
        /// The parent code unit.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code is within an unsafe block.
        /// </param>
        /// <param name="allowTypelessVariable">
        /// Indicates whether to allow a variable with no type defined.
        /// </param>
        /// <param name="onlyTypelessVariable">
        /// Indicates whether to only get a typeless variable.
        /// </param>
        /// <returns>
        /// Returns the variable.
        /// </returns>
        private Variable GetVariable(Reference<ICodePart> parentReference, bool unsafeCode, bool allowTypelessVariable, bool onlyTypelessVariable)
        {
            Param.AssertNotNull(parentReference, "parentReference");
            Param.Ignore(unsafeCode);
            Param.Ignore(allowTypelessVariable);
            Param.Ignore(onlyTypelessVariable);

            this.AdvanceToNextCodeSymbol(parentReference);

            Reference<ICodePart> variableReference = new Reference<ICodePart>();

            // Get the type token representing either the type or the identifier.
            TypeToken type = this.GetTypeToken(variableReference, unsafeCode, true, false);
            if (type == null)
            {
                throw this.CreateSyntaxException();
            }

            Variable variable = null;

            if (onlyTypelessVariable)
            {
                // The token is not a type, just an identifier.
                Debug.Assert(type.ChildTokens.Count == 1, "The count is invalid");
                CsToken identifierToken = type.ChildTokens.First.Value;
                this.tokens.Add(identifierToken);
                variable = new Variable(null, type.Text, VariableModifiers.None, type.Location, parentReference, type.Generated);
                identifierToken.ParentRef = new Reference<ICodePart>(variable);
            }
            else
            {
                int index = this.GetNextCodeSymbolIndex(1);
                if (index != -1)
                {
                    // Look ahead to the next symbol to see what it is.
                    Symbol symbol = this.symbols.Peek(index);

                    if (symbol == null || symbol.SymbolType != SymbolType.Other)
                    {
                        // This variable has no type, only an identifier.
                        if (!allowTypelessVariable)
                        {
                            throw this.CreateSyntaxException();
                        }

                        // The token is not a type, just an identifier.
                        Debug.Assert(type.ChildTokens.Count == 1, "The count is invalid");
                        this.tokens.Add(type.ChildTokens.First.Value);

                        variable = new Variable(null, type.Text, VariableModifiers.None, type.Location, parentReference, type.Generated);
                    }
                    else
                    {
                        // There is a type so add the type token.
                        this.tokens.Add(type);
                        this.AdvanceToNextCodeSymbol(variableReference);

                        // Create and add the identifier token.
                        CsToken identifier = new CsToken(symbol.Text, CsTokenType.Other, CsTokenClass.Token, symbol.Location, variableReference, this.symbols.Generated);

                        this.tokens.Add(identifier);
                        this.symbols.Advance();

                        // The variable has both a type and an identifier.
                        variable = new Variable(
                            type, 
                            identifier.Text, 
                            VariableModifiers.None, 
                            CodeLocation.Join(type.Location, identifier.Location), 
                            parentReference, 
                            type.Generated || identifier.Generated);
                    }
                }
            }

            variableReference.Target = variable;
            return variable;
        }

        /// <summary>
        /// Inspects the next few symbols after the open parenthesis and identifies if a tuple type is defined.
        /// </summary>
        /// <param name="testPosition">The position from current, at which the open parenthesis symbol exists</param>
        /// <returns>The end position of the tuple type if found, otherwise testPosition is returned.</returns>
        private int DetectTupleType(int testPosition)
        {
            Param.AssertGreaterThanOrEqualToZero(testPosition, nameof(testPosition));

            bool foundComma = false;
            int parenthesisCount = 0;
            SymbolType symbolType;
            int originalTestPosition = testPosition;

            // Keep checking for allowed symbols. Note that this check is only tuple types and not for tuple literals.
            while (true)
            {
                symbolType = this.PeekNextSymbolFrom(testPosition, SkipSymbols.All, false, out testPosition).SymbolType;

                if (symbolType == SymbolType.Other || symbolType == SymbolType.OpenSquareBracket || symbolType == SymbolType.CloseSquareBracket
                    || symbolType == SymbolType.LessThan || symbolType == SymbolType.GreaterThan)
                {
                    continue;
                }

                if (symbolType == SymbolType.Comma)
                {
                    foundComma = true;
                    continue;
                }

                if (symbolType == SymbolType.OpenParenthesis)
                {
                    parenthesisCount++;
                    continue;
                }

                if (symbolType == SymbolType.CloseParenthesis)
                {
                    parenthesisCount--;

                    if (parenthesisCount == 0)
                    {
                        break;
                    }

                    continue;
                }

                // Unexpected symbol.
                return originalTestPosition;
            }

            if (!foundComma)
            {
                return originalTestPosition;
            }

            int resultPosition = testPosition;
            symbolType = this.PeekNextSymbolFrom(testPosition, SkipSymbols.All, false, out testPosition).SymbolType;
            int squareBracketCount = 0;

            // Move past array declaration brackets if any.
            if (symbolType == SymbolType.OpenSquareBracket)
            {
                squareBracketCount = 1;

                while (true)
                {
                    symbolType = this.PeekNextSymbolFrom(testPosition, SkipSymbols.All, false, out testPosition).SymbolType;
                    if (symbolType == SymbolType.OpenSquareBracket)
                    {
                        squareBracketCount++;
                    }
                    else if (symbolType == SymbolType.CloseSquareBracket)
                    {
                        squareBracketCount--;
                        resultPosition = testPosition;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            // We should have parsed all brackets. 
            return squareBracketCount == 0 ? resultPosition : originalTestPosition;
        }

        #endregion
    }
}