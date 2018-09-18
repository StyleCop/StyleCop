// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CodeLexer.cs" company="https://github.com/StyleCop">
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
//   Breaks the components of a C# code file down into individual symbols.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Breaks the components of a C# code file down into individual symbols.
    /// </summary>
    internal partial class CodeLexer
    {
        #region Fields

        /// <summary>
        /// Used for reading the source code.
        /// </summary>
        private readonly CodeReader codeReader;

        /// <summary>
        /// Keeps track of conditional directives found in the code.
        /// </summary>
        private readonly Stack<bool> conditionalDirectives = new Stack<bool>();

        /// <summary>
        /// Keeps track of whether we're evaluating symbols as we enter nested #if statements
        /// </summary>
        private readonly Stack<bool> evaluatingSymbolsStatus = new Stack<bool>();

        /// <summary>
        /// The current marker in the code string.
        /// </summary>
        private readonly MarkerData marker = new MarkerData();

        /// <summary>
        /// The C# parser.
        /// </summary>
        private readonly CsParser parser;

        /// <summary>
        /// The source to read.
        /// </summary>
        private readonly SourceCode source;

        /// <summary>
        /// The list of defines in the file.
        /// </summary>
        private Dictionary<string, string> defines;

        /// <summary>
        /// Tracks if we are currently evaluating Symbols as we parse.
        /// </summary>
        private bool evaluatingSymbols = true;

        /// <summary>
        /// The list of undefines in the file.
        /// </summary>
        private Dictionary<string, string> undefines;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the CodeLexer class.
        /// </summary>
        /// <param name="parser">
        /// The C# parser.
        /// </param>
        /// <param name="source">
        /// The source to read.
        /// </param>
        /// <param name="codeReader">
        /// Used for reading the source code.
        /// </param>
        internal CodeLexer(CsParser parser, SourceCode source, CodeReader codeReader)
        {
            Param.AssertNotNull(parser, "parser");
            Param.AssertNotNull(source, "source");
            Param.AssertNotNull(codeReader, "codeReader");

            this.parser = parser;
            this.source = source;
            this.codeReader = codeReader;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the source code.
        /// </summary>
        internal SourceCode SourceCode
        {
            get
            {
                return this.source;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Decodes escaping characters in specified text.
        /// </summary>
        /// <param name="text">
        /// The text containing encoded characters.
        /// </param>
        /// <param name="allowRemoveAt">
        /// True if the at sign can be removed.
        /// </param>
        /// <returns>
        /// Returns decoded text.
        /// </returns>
        internal static string DecodeEscapedText(string text, bool allowRemoveAt)
        {
            Param.AssertNotNull(text, "text");
            Param.Ignore(allowRemoveAt);

            // Check whether unescaping is needed.
            if (!text.Contains("@") && !text.Contains("\\"))
            {
                return text;
            }

            // Perform unescaping process.
            StringBuilder sb = new StringBuilder();
            bool canRemoveAt = true;
            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];

                // Remove "at" sign from beginning.
                if (allowRemoveAt && canRemoveAt && c == '@')
                {
                    canRemoveAt = false;
                    continue;
                }

                // Check whether short syntax is used.
                if (i < text.Length - 5)
                {
                    char[] sequence = new[] { c, text[i + 1], text[i + 2], text[i + 3], text[i + 4], text[i + 5], };

                    char value;
                    if (IsLetterEncoded(sequence, out value))
                    {
                        i += 5;
                        sb.Append(value);
                        continue;
                    }
                }

                // Check whether long syntax is used.
                if (i < text.Length - 9)
                {
                    char[] sequence = new char[]
                    {
                        c,
                        text[i + 1],
                        text[i + 2],
                        text[i + 3],
                        text[i + 4],
                        text[i + 5],
                        text[i + 6],
                        text[i + 7],
                        text[i + 8],
                        text[i + 9],
                    };

                    char value;
                    if (IsLetterEncoded(sequence, out value))
                    {
                        i += 9;
                        sb.Append(value);
                        continue;
                    }
                }

                if (c == '.')
                {
                    canRemoveAt = true;
                }
                else
                {
                    if (c != '~')
                    {
                        canRemoveAt = false;
                    }
                }

                sb.Append(c);
            }

            return sb.ToString();
        }

        /// <summary>
        /// Gets the next symbol in the code, starting at the current marker.
        /// </summary>
        /// <param name="symbols">
        /// The List of symbols we've processed.
        /// </param>
        /// <param name="sourceCode">
        /// The source code containing the symbol.
        /// </param>
        /// <param name="configuration">
        /// The active configuration.
        /// </param>
        /// <returns>
        /// Returns the next symbol in the document.
        /// </returns>
        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "The method is not overly complex.")]
        [SuppressMessage("Microsoft.Globalization", "CA1303:DoNotPassLiteralsAsLocalizedParameters",
            Justification = "The literals represent non-localizable C# operators.")]
        internal Symbol GetSymbol(List<Symbol> symbols, SourceCode sourceCode, Configuration configuration)
        {
            Param.AssertNotNull(symbols, "symbols");
            Param.AssertNotNull(sourceCode, "sourceCode");
            Param.Ignore(configuration);

            Symbol symbol = null;

            // Look at the next character from the buffer.
            char firstCharacter = this.codeReader.Peek();
            if (firstCharacter != char.MinValue)
            {
                switch (firstCharacter)
                {
                    case '\t':
                        symbol = this.GetWhitespace();
                        break;

                    case '\'':
                    case '\"':
                        symbol = this.GetString();
                        break;

                    case '$':
                        symbol = this.GetInterpolatedString();
                        break;

                    case '@':
                        symbol = this.GetLiteral();
                        break;

                    case '/':

                        // Try to get this as a comment. If it is not a comment, it is an operator symbol.
                        symbol = this.GetComment() ?? this.GetOperatorSymbol('/');

                        break;

                    case '\r':
                    case '\n':
                        symbol = this.GetNewLine();
                        break;

                    case '~':
                    case '+':
                    case '-':
                    case '*':
                    case '|':
                    case '&':
                    case '!':
                    case '^':
                    case '>':
                    case '<':
                    case '=':
                    case '%':
                    case ':':
                    case '?':
                        symbol = this.GetOperatorSymbol(firstCharacter);
                        break;

                    case '#':
                        symbol = this.GetPreprocessorDirectiveSymbol(symbols, sourceCode, configuration);
                        break;

                    case '(':
                        symbol = this.CreateAndMovePastSymbol("(", SymbolType.OpenParenthesis);
                        break;

                    case ')':
                        symbol = this.CreateAndMovePastSymbol(")", SymbolType.CloseParenthesis);
                        break;

                    case '[':
                        symbol = this.CreateAndMovePastSymbol("[", SymbolType.OpenSquareBracket);
                        break;

                    case ']':
                        symbol = this.CreateAndMovePastSymbol("]", SymbolType.CloseSquareBracket);
                        break;

                    case '{':
                        symbol = this.CreateAndMovePastSymbol("{", SymbolType.OpenCurlyBracket);
                        break;

                    case '}':
                        symbol = this.CreateAndMovePastSymbol("}", SymbolType.CloseCurlyBracket);
                        break;

                    case ',':
                        symbol = this.CreateAndMovePastSymbol(",", SymbolType.Comma);
                        break;

                    case ';':
                        symbol = this.CreateAndMovePastSymbol(";", SymbolType.Semicolon);
                        break;

                    case '.':
                        symbol = this.GetNumber() ?? this.GetOperatorSymbol('.');
                        break;

                    default:

                        // Skip any unknown formatting characters, and skip any unassigned characters.
                        UnicodeCategory category = char.GetUnicodeCategory(firstCharacter);
                        if (category != UnicodeCategory.Format && category != UnicodeCategory.Control && category != UnicodeCategory.OtherNotAssigned)
                        {
                            if (category == UnicodeCategory.SpaceSeparator)
                            {
                                symbol = this.GetWhitespace();
                                break;
                            }

                            symbol = this.GetNumber() ?? this.GetOtherSymbol(this.source);
                        }

                        break;
                }
            }

            Debug.Assert(symbol == null || symbol.Text.Length > 0, "The symbol is invalid.");
            return symbol;
        }

        /// <summary>
        /// Gets the list of symbols from the code file.
        /// </summary>
        /// <param name="sourceCode">
        /// The source code containing the symbols.
        /// </param>
        /// <param name="configuration">
        /// The active configuration.
        /// </param>
        /// <returns>
        /// Returns the list of symbols in the code file.
        /// </returns>
        internal List<Symbol> GetSymbols(SourceCode sourceCode, Configuration configuration)
        {
            Param.AssertNotNull(sourceCode, "sourceCode");
            Param.Ignore(configuration);

            // Create the symbol list.
            List<Symbol> symbols = new List<Symbol>();

            // Loop until all the symbols have been read.
            while (true)
            {
                Symbol symbol = this.GetSymbol(symbols, sourceCode, configuration);
                if (symbol == null)
                {
                    break;
                }

                if (this.evaluatingSymbols || symbol.SymbolType == SymbolType.PreprocessorDirective)
                {
                    symbols.Add(symbol);
                }
            }

            // Return the list of symbols.
            return symbols;
        }

        /// <summary>
        /// Creates a CodeLocation from the given marker.
        /// </summary>
        /// <param name="marker">
        /// The marker.
        /// </param>
        /// <returns>
        /// Returns the CodeLocation.
        /// </returns>
        private static CodeLocation CodeLocationFromMarker(MarkerData marker)
        {
            Param.AssertNotNull(marker, "marker");

            return new CodeLocation(marker.Index, marker.Index, marker.IndexOnLine, marker.IndexOnLine, marker.LineNumber, marker.LineNumber);
        }

        /// <summary>
        /// Gets the type of the given symbol.
        /// </summary>
        /// <param name="text">
        /// The symbol to look up.
        /// </param>
        /// <returns>
        /// Returns the type of the symbol.
        /// </returns>
        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "The method consists of a simple switch statement.")]
        private static SymbolType GetOtherSymbolType(string text)
        {
            Param.AssertValidString(text, "text");

            switch (text)
            {
                case "abstract":
                    return SymbolType.Abstract;

                case "as":
                    return SymbolType.As;

                case "base":
                    return SymbolType.Base;

                case "break":
                    return SymbolType.Break;

                case "case":
                    return SymbolType.Case;

                case "catch":
                    return SymbolType.Catch;

                case "checked":
                    return SymbolType.Checked;

                case "class":
                    return SymbolType.Class;

                case "const":
                    return SymbolType.Const;

                case "continue":
                    return SymbolType.Continue;

                case "default":
                    return SymbolType.Default;

                case "delegate":
                    return SymbolType.Delegate;

                case "do":
                    return SymbolType.Do;

                case "else":
                    return SymbolType.Else;

                case "enum":
                    return SymbolType.Enum;

                case "event":
                    return SymbolType.Event;

                case "explicit":
                    return SymbolType.Explicit;

                case "extern":
                    return SymbolType.Extern;

                case "false":
                    return SymbolType.False;

                case "finally":
                    return SymbolType.Finally;

                case "fixed":
                    return SymbolType.Fixed;

                case "for":
                    return SymbolType.For;

                case "foreach":
                    return SymbolType.Foreach;

                case "goto":
                    return SymbolType.Goto;

                case "if":
                    return SymbolType.If;

                case "implicit":
                    return SymbolType.Implicit;

                case "in":
                    return SymbolType.In;

                case "interface":
                    return SymbolType.Interface;

                case "internal":
                    return SymbolType.Internal;

                case "is":
                    return SymbolType.Is;

                case "lock":
                    return SymbolType.Lock;

                case "nameof":
                    return SymbolType.NameOf;

                case "namespace":
                    return SymbolType.Namespace;

                case "new":
                    return SymbolType.New;

                case "null":
                    return SymbolType.Null;

                case "operator":
                    return SymbolType.Operator;

                case "out":
                    return SymbolType.Out;

                case "override":
                    return SymbolType.Override;

                case "params":
                    return SymbolType.Params;

                case "private":
                    return SymbolType.Private;

                case "protected":
                    return SymbolType.Protected;

                case "public":
                    return SymbolType.Public;

                case "readonly":
                    return SymbolType.Readonly;

                case "ref":
                    return SymbolType.Ref;

                case "return":
                    return SymbolType.Return;

                case "sealed":
                    return SymbolType.Sealed;

                case "sizeof":
                    return SymbolType.Sizeof;

                case "stackalloc":
                    return SymbolType.Stackalloc;

                case "static":
                    return SymbolType.Static;

                case "struct":
                    return SymbolType.Struct;

                case "switch":
                    return SymbolType.Switch;

                case "this":
                    return SymbolType.This;

                case "throw":
                    return SymbolType.Throw;

                case "true":
                    return SymbolType.True;

                case "try":
                    return SymbolType.Try;

                case "typeof":
                    return SymbolType.Typeof;

                case "unchecked":
                    return SymbolType.Unchecked;

                case "unsafe":
                    return SymbolType.Unsafe;

                case "using":
                    return SymbolType.Using;

                case "virtual":
                    return SymbolType.Virtual;

                case "volatile":
                    return SymbolType.Volatile;

                case "while":
                    return SymbolType.While;

                default:
                    return SymbolType.Other;
            }
        }

        /// <summary>
        /// Indicates whether specified character can be used as hexadecimal digit.
        /// </summary>
        /// <param name="character">
        /// The character.
        /// </param>
        /// <returns>
        /// Returns true if the character looks like hexadecimal digit.
        /// </returns>
        private static bool IsHexadecimalChar(char character)
        {
            Param.Ignore(character);

            if (char.IsNumber(character)
                || (character >= 'a' && character <= 'f')
                || (character >= 'A' && character <= 'F'))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Indicates whether specified character sequence represents encoded character value.
        /// </summary>
        /// <param name="sequence">
        /// Specified character sequence.
        /// </param>
        /// <param name="character">
        /// Reference parameter holding character value.
        /// </param>
        /// <returns>
        /// Returns true if code reader contains encoded letter.
        /// </returns>
        private static bool IsLetterEncoded(char[] sequence, out char character)
        {
            Param.AssertNotNull(sequence, "sequence");

            character = char.MinValue;

            // Short syntax is used.
            if (sequence.Length == 6
                && sequence[0] == '\\'
                && sequence[1] == 'u'
                && IsHexadecimalChar(sequence[2])
                && IsHexadecimalChar(sequence[3])
                && IsHexadecimalChar(sequence[4])
                && IsHexadecimalChar(sequence[5]))
            {
                character = (char)Convert.ToInt32(
                    new string(new[]
                        {
                            sequence[2],
                            sequence[3],
                            sequence[4],
                            sequence[5]
                        }),
                    16);

                return true;
            }

            // Long syntax is used.
            if (sequence.Length == 10
                && sequence[0] == '\\'
                && sequence[1] == 'U'
                && IsHexadecimalChar(sequence[2])
                && IsHexadecimalChar(sequence[3])
                && IsHexadecimalChar(sequence[4])
                && IsHexadecimalChar(sequence[5])
                && IsHexadecimalChar(sequence[6])
                && IsHexadecimalChar(sequence[7])
                && IsHexadecimalChar(sequence[8])
                && IsHexadecimalChar(sequence[9]))
            {
                character = (char)Convert.ToInt32(
                    new string(new[]
                        {
                            sequence[2],
                            sequence[3],
                            sequence[4],
                            sequence[5],
                            sequence[6],
                            sequence[7],
                            sequence[8],
                            sequence[9]
                        }),
                    16);

                return true;
            }

            return false;
        }

        /// <summary>
        /// Indicates whether the character is considered a letter for the purposes of keywords and type names.
        /// </summary>
        /// <param name="character">
        /// The character.
        /// </param>
        /// <returns>
        /// Returns true if the character looks like a letter.
        /// </returns>
        private static bool IsLetterExtended(char character)
        {
            Param.Ignore(character);

            if (character == '_')
            {
                return true;
            }

            UnicodeCategory category = char.GetUnicodeCategory(character);
            if (category == UnicodeCategory.LowercaseLetter || category == UnicodeCategory.UppercaseLetter || category == UnicodeCategory.OtherSymbol
                || category == UnicodeCategory.OtherLetter || category == UnicodeCategory.ModifierLetter || category == UnicodeCategory.NonSpacingMark
                || category == UnicodeCategory.SpacingCombiningMark || category == UnicodeCategory.EnclosingMark)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Advances to the next end of line character and adds all characters to the given text buffer.
        /// </summary>
        /// <param name="text">
        /// The text buffer in which to store the rest of the line.
        /// </param>
        private void AdvanceToEndOfLine(StringBuilder text)
        {
            Param.AssertNotNull(text, "text");

            int offsetIndex = this.FindNextEndOfLine();
            if (offsetIndex != -1)
            {
                text.Append(this.codeReader.ReadString(offsetIndex));
            }
        }

        /// <summary>
        /// Checks the given preprocessor symbol to determine whether it is a conditional preprocessor directive.
        /// If so, determines whether we should skip past code which is out of scope.
        /// </summary>
        /// <param name="symbols">
        /// The List of symbols we've processed.
        /// </param>
        /// <param name="sourceCode">
        /// The source code file containing this directive.
        /// </param>
        /// <param name="preprocessorSymbol">
        /// The symbol to check.
        /// </param>
        /// <param name="configuration">
        /// The active configuration.
        /// </param>
        private void CheckForConditionalCompilationDirective(List<Symbol> symbols, SourceCode sourceCode, Symbol preprocessorSymbol, Configuration configuration)
        {
            Param.AssertNotNull(symbols, "symbols");
            Param.AssertNotNull(sourceCode, "sourceCode");
            Param.AssertNotNull(preprocessorSymbol, "preprocessorSymbol");
            Param.Ignore(configuration);

            // Get the type of this preprocessor directive.
            int bodyIndex;
            string type = CsParser.GetPreprocessorDirectiveType(preprocessorSymbol, out bodyIndex);
            switch (type)
            {
                case "define":
                    this.GetDefinePreprocessorDirective(sourceCode, preprocessorSymbol, bodyIndex);
                    break;

                case "undef":
                    this.GetUndefinePreprocessorDirective(sourceCode, preprocessorSymbol, bodyIndex);
                    break;

                case "endif":
                    if (this.conditionalDirectives.Count == 0)
                    {
                        throw new SyntaxException(sourceCode, preprocessorSymbol.LineNumber);
                    }

                    this.conditionalDirectives.Pop();
                    this.evaluatingSymbols = this.conditionalDirectives.Count == 0 || this.evaluatingSymbolsStatus.Pop();
                    break;

                case "else":
                case "elif":
                case "if":
                    this.SetEvaluatingSymbolsForIfElifElse(sourceCode, preprocessorSymbol, configuration, bodyIndex, type);
                    break;
            }
        }

        /// <summary>
        /// Reads, creates, and moves past a symbol.
        /// </summary>
        /// <param name="text">
        /// The symbol text.
        /// </param>
        /// <param name="type">
        /// The type of the symbol.
        /// </param>
        /// <returns>
        /// Returns the symbol.
        /// </returns>
        private Symbol CreateAndMovePastSymbol(string text, SymbolType type)
        {
            Param.AssertValidString(text, "text");
            Param.Ignore(type);

            this.codeReader.ReadNext();
            Symbol symbol = new Symbol(text, type, CodeLocationFromMarker(this.marker));
            ++this.marker.Index;
            ++this.marker.IndexOnLine;

            return symbol;
        }

        /// <summary>
        /// Evaluates an expression from within a conditional compilation directive to determine
        /// whether it resolves to true or false.
        /// </summary>
        /// <param name="sourceCode">
        /// The source code containing the expression.
        /// </param>
        /// <param name="expression">
        /// The expression to evaluate.
        /// </param>
        /// <param name="configuration">
        /// The active configuration.
        /// </param>
        /// <returns>
        /// Returns true if the expression evaluates to true, otherwise returns false.
        /// </returns>
        private bool EvaluateConditionalDirectiveExpression(SourceCode sourceCode, Expression expression, Configuration configuration)
        {
            Param.AssertNotNull(sourceCode, "sourceCode");
            Param.AssertNotNull(expression, "expression");
            Param.Ignore(configuration);

            bool value = false;

            // Switch on the possible expression type.
            switch (expression.ExpressionType)
            {
                case ExpressionType.Literal:

                    // Check the value of the literal.
                    LiteralExpression literal = expression as LiteralExpression;
                    if (literal.Text == "false")
                    {
                        // This is the 'false' keyword.
                        value = false;
                    }
                    else if (literal.Text == "true")
                    {
                        // This is the 'true' keyword.
                        value = true;
                    }
                    else
                    {
                        // Check whether this flag is defined in the document. If so, this resolves to true.
                        // Otherwise, this resolves to false.
                        if (this.undefines != null && this.undefines.ContainsKey(literal.Text))
                        {
                            value = false;
                        }
                        else if (this.defines != null && this.defines.ContainsKey(literal.Text))
                        {
                            value = true;
                        }
                        else
                        {
                            value = configuration != null && configuration.Contains(literal.Text);
                        }
                    }

                    break;

                case ExpressionType.ConditionalLogical:
                    ConditionalLogicalExpression conditionalLogicalExpression = expression as ConditionalLogicalExpression;

                    // Evaluate the left side of the expression.
                    bool leftSide = this.EvaluateConditionalDirectiveExpression(sourceCode, conditionalLogicalExpression.LeftHandSide, configuration);

                    // Evaluate the right side of the expression.
                    bool rightSide = this.EvaluateConditionalDirectiveExpression(sourceCode, conditionalLogicalExpression.RightHandSide, configuration);

                    // Check whether this is a conditional OR or a conditional AND expression.
                    if (conditionalLogicalExpression.OperatorType == ConditionalLogicalExpression.Operator.And)
                    {
                        value = leftSide && rightSide;
                    }
                    else
                    {
                        value = leftSide || rightSide;
                    }

                    break;

                case ExpressionType.Relational:
                    RelationalExpression relationalExpression = expression as RelationalExpression;

                    // Evaluate the left side of the expression.
                    leftSide = this.EvaluateConditionalDirectiveExpression(sourceCode, relationalExpression.LeftHandSide, configuration);

                    // Evaluate the right side of the expression.
                    rightSide = this.EvaluateConditionalDirectiveExpression(sourceCode, relationalExpression.RightHandSide, configuration);

                    // Check whether this is an equality or an inequality expression.
                    if (relationalExpression.OperatorType == RelationalExpression.Operator.EqualTo)
                    {
                        value = leftSide == rightSide;
                    }
                    else if (relationalExpression.OperatorType == RelationalExpression.Operator.NotEqualTo)
                    {
                        value = leftSide != rightSide;
                    }
                    else
                    {
                        // Any other type of relational operator is not allowed in a conditional compilation directive.
                        throw new SyntaxException(sourceCode, expression.Tokens.First.Value.LineNumber);
                    }

                    break;

                case ExpressionType.Unary:
                    UnaryExpression unaryExpression = expression as UnaryExpression;
                    if (unaryExpression.OperatorType == UnaryExpression.Operator.Not)
                    {
                        // Evaluate the right side of the expression.
                        value = !this.EvaluateConditionalDirectiveExpression(sourceCode, unaryExpression.Value, configuration);
                    }
                    else
                    {
                        // Any other type of unary operator is not allowed in a conditional compilation directive.
                        throw new SyntaxException(sourceCode, expression.Tokens.First.Value.LineNumber);
                    }

                    break;

                case ExpressionType.Parenthesized:

                    // Evaluate the inner expression.
                    ParenthesizedExpression parenthesizedExpression = expression as ParenthesizedExpression;
                    value = this.EvaluateConditionalDirectiveExpression(sourceCode, parenthesizedExpression.InnerExpression, configuration);
                    break;

                default:

                    // Any other type of expression is not allowed within a conditional compilation directive.
                    throw new SyntaxException(sourceCode, expression.Tokens.First.Value.LineNumber);
            }

            return value;
        }

        /// <summary>
        /// Finds the offset index of the next end-of-line character.
        /// </summary>
        /// <returns>Returns the offset index of the next end-of-line character. If there are no more end-of-line
        /// characters, returns the index of the character past the end of the file.</returns>
        private int FindNextEndOfLine()
        {
            int endOfLine = -1;
            int carriageReturn = -1;

            int index = 0;
            while (true)
            {
                char character = this.codeReader.Peek(index);
                if (character == char.MinValue)
                {
                    break;
                }
                else if (character == '\r')
                {
                    if (carriageReturn == -1)
                    {
                        carriageReturn = index;

                        if (endOfLine != -1)
                        {
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                else if (character == '\n')
                {
                    if (endOfLine == -1)
                    {
                        endOfLine = index;

                        if (carriageReturn != -1)
                        {
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                }

                ++index;
            }

            if (endOfLine != -1 && carriageReturn != -1)
            {
                return Math.Min(endOfLine, carriageReturn);
            }
            else if (carriageReturn != -1)
            {
                return carriageReturn;
            }
            else if (endOfLine != -1)
            {
                return endOfLine;
            }

            // No end of line character was found. This means that we read all the way to the end of the
            // file. In this case the index is sitting at one past the end of the file, so return the
            // offset index of the last character in the file.
            return index;
        }

        /// <summary>
        /// Gets the next comment.
        /// </summary>
        /// <returns>Returns the comment.</returns>
        private Symbol GetComment()
        {
            Symbol symbol = null;

            // The current character must be a forward slash.
            Debug.Assert(this.codeReader.Peek() == '/', "Expected a forward slash character");

            StringBuilder text = new StringBuilder();

            // Peek at the type of the next character.
            char character = this.codeReader.Peek(1);

            if (character != char.MinValue)
            {
                if (character == '*')
                {
                    // This looks like a comment. Move past the first slash.
                    text.Append(this.codeReader.ReadNext());

                    // Get the rest of the comment.
                    symbol = this.GetMultiLineComment(text);
                }
                else if (character == '/')
                {
                    // This looks like a comment. Move past the first slash.
                    text.Append(this.codeReader.ReadNext());

                    // Add this second slash as well.
                    text.Append(this.codeReader.ReadNext());

                    // Peek at the type of the next character.
                    character = this.codeReader.Peek();
                    if (character == '/')
                    {
                        // Add this character and move past it.
                        text.Append(this.codeReader.ReadNext());

                        // Peek at the type of the next character.
                        character = this.codeReader.Peek();
                        if (character != '/')
                        {
                            // The line starts with three slashes in a row.
                            symbol = this.GetXmlHeaderLine(text);
                        }
                        else
                        {
                            // The line starts with four slashes in a row.
                            symbol = this.GetSingleLineComment(text);
                        }
                    }
                    else
                    {
                        symbol = this.GetSingleLineComment(text);
                    }
                }
            }

            return symbol;
        }

        /// <summary>
        /// Gets the decimal digits that appear after a decimal point in a real literal.
        /// </summary>
        /// <param name="index">
        /// The start index of the remainder numbers.
        /// </param>
        /// <returns>
        /// Returns the last index of the remainder numbers.
        /// </returns>
        private int GetDecimalFraction(int index)
        {
            Param.AssertGreaterThanOrEqualToZero(index, "index");

            // Get the decimal digits that appear after a decimal point.
            int startIndex = index;

            while (true)
            {
                char character = this.codeReader.Peek(index - this.marker.Index);

                // Break if this is not a valid decimal digit or digit separator.
                // '_' is not allowed as the first char following a '.'
                if ((character < '0' || character > '9') && (character != '_' || index == startIndex))
                {
                    break;
                }

                ++index;
            }

            // The last index of the number is one less than the current index.
            --index;

            // If there is not at least one decimal digit, return -1.
            if (index < startIndex)
            {
                index = -1;
            }

            return index;
        }

        /// <summary>
        /// Extracts a decimal integer literal from the code.
        /// </summary>
        /// <param name="index">
        /// The first index of the decimal integer literal.
        /// </param>
        /// <returns>
        /// Returns the last index of the decimal integer literal.
        /// </returns>
        private int GetDecimalLiteral(int index)
        {
            Param.AssertGreaterThanOrEqualToZero(index, "index");

            int startIndex = index;

            char character;

            while (true)
            {
                character = this.codeReader.Peek(index - this.marker.Index);

                // Break if this is not a valid decimal digit or digit separator.
                // If the digit seperator is the first char, then this is not a number.
                if ((character < '0' || character > '9') && (character != '_' || index == startIndex))
                {
                    break;
                }

                ++index;
            }

            // If the last character we read is an '_', this is not a number.
            if (character == '_')
            {
                return -1;
            }

            // The last index of the number is one less than the current index.
            --index;

            // See whether we've found at least one digit.
            if (index >= startIndex)
            {
                // Now check whether there is a trailing integer type suffix.
                int endIndex = this.GetIntegerTypeSuffix(index + 1);
                if (endIndex != -1)
                {
                    index = endIndex;
                }
                else
                {
                    // There was no trailing type suffix. This might actually be a real literal.
                    // check if there are any trailing characters which would indicate this.
                    endIndex = this.GetRealLiteralTrailingCharacters(index, false);
                    if (endIndex != -1)
                    {
                        index = endIndex;
                    }
                }
            }
            else
            {
                // No digits were found. This might be a real literal starting with a decimal point.
                // Check if it matches that signature.
                int endIndex = this.GetRealLiteralTrailingCharacters(index, true);
                if (endIndex != -1)
                {
                    index = endIndex;
                }

                // If there are still no digits, then this is not a number.
                if (index < startIndex)
                {
                    index = -1;
                }
            }

            return index;
        }

        /// <summary>
        /// Gets a define preprocessor directive from the code.
        /// </summary>
        /// <param name="sourceCode">
        /// The source code being parsed.
        /// </param>
        /// <param name="preprocessorSymbol">
        /// The preprocessor symbol being parsed.
        /// </param>
        /// <param name="startIndex">
        /// The start index within the symbols.
        /// </param>
        private void GetDefinePreprocessorDirective(SourceCode sourceCode, Symbol preprocessorSymbol, int startIndex)
        {
            Param.AssertNotNull(sourceCode, "sourceCode");
            Param.AssertNotNull(preprocessorSymbol, "preprocessorSymbol");
            Param.AssertGreaterThanOrEqualToZero(startIndex, "startIndex");

            // Get the body of the define directive.
            LiteralExpression body = CodeParser.GetConditionalPreprocessorBodyExpression(this.parser, sourceCode, preprocessorSymbol, startIndex) as LiteralExpression;
            if (body == null)
            {
                throw new SyntaxException(sourceCode, preprocessorSymbol.LineNumber);
            }

            // Create the defines list if necessary.
            if (this.defines == null)
            {
                this.defines = new Dictionary<string, string>();
            }

            // Add the item to the list.
            if (!this.defines.ContainsKey(body.Text))
            {
                this.defines.Add(body.Text, body.Text);
            }

            // Remove the item from the undefines list if it exists.
            if (this.undefines != null)
            {
                this.undefines.Remove(body.Text);
            }
        }

        /// <summary>
        /// Extracts a hexadecimal integer literal from the code.
        /// </summary>
        /// <param name="index">
        /// The first index of the hexadecimal integer literal.
        /// </param>
        /// <returns>
        /// Returns the last index of the hexadecimal integer literal.
        /// </returns>
        private int GetHexadecimalIntegerLiteral(int index)
        {
            Param.AssertGreaterThanOrEqualToZero(index, "index");

            int startIndex = index;

            while (true)
            {
                char character = this.codeReader.Peek(index - this.marker.Index);

                // Break if this is not a valid hexadecimal digit, or a digit separator.
                // If the digit seperator is the first char, then this is not a number.
                if (!(character >= '0' && character <= '9') && !(character >= 'a' && character <= 'f') 
                    && !(character >= 'A' && character <= 'F') && (character != '_' || index == startIndex))
                {
                    break;
                }

                ++index;
            }

            // The last index of the number is one less than the current index.
            --index;

            // See whether we've found at least one digit.
            if (index >= startIndex)
            {
                // Now check whether there is a trailing integer type suffix.
                int endIndex = this.GetIntegerTypeSuffix(index + 1);
                if (endIndex != -1)
                {
                    index = endIndex;
                }
            }
            else
            {
                // If there are no digits, this is not a number.
                index = -1;
            }

            return index;
        }

        /// <summary>
        /// Extracts a binary literal from the code.
        /// </summary>
        /// <param name="index">
        /// The first index of the binary literal.
        /// </param>
        /// <returns>
        /// Returns the last index of the binary literal.
        /// </returns>
        private int GetBinaryLiteral(int index)
        {
            Param.AssertGreaterThanOrEqualToZero(index, "index");

            int startIndex = index;

            while (true)
            {
                char character = this.codeReader.Peek(index - this.marker.Index);

                // Break if this is not a valid binary digit, or a digit separator.
                // if the digit seperator is the first char, then this is not a number.
                if ((character < '0' || character > '1') && (character != '_' || index == startIndex))
                {
                    break;
                }

                ++index;
            }

            // The last index of the number is one less than the current index.
            --index;

            // See whether we've found at least one digit.
            if (index >= startIndex)
            {
                // Now check whether there is a trailing integer type suffix.
                int endIndex = this.GetIntegerTypeSuffix(index + 1);
                if (endIndex != -1)
                {
                    index = endIndex;
                }
            }
            else
            {
                // If there are no digits, this is not a number.
                index = -1;
            }

            return index;
        }

        /// <summary>
        /// Gets the type suffix tacked onto the end of an integer literal.
        /// </summary>
        /// <param name="index">
        /// The start index of the literal.
        /// </param>
        /// <returns>
        /// Returns the index of the integer type suffix, if there is one.
        /// </returns>
        private int GetIntegerTypeSuffix(int index)
        {
            Param.AssertGreaterThanOrEqualToZero(index, "index");

            int endIndex = -1;

            // Now check whether the current character is an integer type suffix.
            char character = this.codeReader.Peek(index - this.marker.Index);

            if (character == 'u' || character == 'U')
            {
                // This is a uint suffix.
                endIndex = index;

                // Check whether this is actually a ulong suffix.
                character = this.codeReader.Peek(index + 1 - this.marker.Index);

                if (character == 'l' || character == 'L')
                {
                    endIndex = index + 1;
                }
            }
            else if (character == 'l' || character == 'L')
            {
                // This is a long suffix.
                endIndex = index;

                // Check whether this is actually a ulong suffix.
                character = this.codeReader.Peek(index + 1 - this.marker.Index);

                if (character == 'u' || character == 'U')
                {
                    endIndex = index + 1;
                }
            }

            return endIndex;
        }

        /// <summary>
        /// Gets the next literal from the code.
        /// </summary>
        /// <returns>Returns the literal.</returns>
        private Symbol GetLiteral()
        {
            StringBuilder text = new StringBuilder();

            // Read the literal string character and add it to the string buffer.
            char character = this.codeReader.ReadNext();
            Debug.Assert(character == '@', "Expected an @ keyword");
            text.Append(character);

            // Make sure there is enough code left to contain at least @ plus one additional character.
            character = this.codeReader.Peek();
            if (character == char.MinValue)
            {
                throw new SyntaxException(this.source, this.marker.LineNumber);
            }

            // Get the next character to determine what type this is.
            if (character == '\'' || character == '\"')
            {
                return this.GetLiteralString(text);
            }
            else if (char.IsLetter(character) || character == '_')
            {
                return this.GetLiteralKeyword(text);
            }
            else
            {
                // This is an unexpected character.
                throw new SyntaxException(this.source, this.marker.LineNumber);
            }
        }

        /// <summary>
        /// Gets the next literal keyword token from the code.
        /// </summary>
        /// <param name="text">
        /// The text buffer to add the string text to.
        /// </param>
        /// <returns>
        /// Returns the literal keyword token.
        /// </returns>
        private Symbol GetLiteralKeyword(StringBuilder text)
        {
            Param.AssertNotNull(text, "text");
            Debug.Assert(text.Length > 0 && text[0] == '@', "Expected an @ character");

            // Advance to the end of the token.
            this.ReadToEndOfOtherSymbol(text);
            if (text.Length == 1)
            {
                // Nothing was read.
                throw new SyntaxException(this.source, this.marker.LineNumber);
            }

            // Get the token location.
            CodeLocation location = new CodeLocation(
                this.marker.Index,
                this.marker.Index + text.Length - 1,
                this.marker.IndexOnLine,
                this.marker.IndexOnLine + text.Length - 1,
                this.marker.LineNumber,
                this.marker.LineNumber);

            // Create the symbol.
            Symbol symbol = new Symbol(text.ToString(), SymbolType.Other, location);

            // Reset the marker index.
            this.marker.Index += text.Length;
            this.marker.IndexOnLine += text.Length;

            // Return the symbol.
            return symbol;
        }

        /// <summary>
        /// Gets the next literal string from the code.
        /// </summary>
        /// <param name="text">
        /// The text buffer to add the string text to.
        /// </param>
        /// <returns>
        /// Returns the literal string.
        /// </returns>
        private Symbol GetLiteralString(StringBuilder text)
        {
            Param.AssertNotNull(text, "text");
            Debug.Assert(text.Length == 1 && text[0] == '@', "Expected an @ symbol");

            // Initialize the location of the start of the string.
            int startIndex = this.marker.Index;
            int endIndex = this.marker.Index;
            int startIndexOnLine = this.marker.IndexOnLine;
            int endIndexOnLine = this.marker.IndexOnLine;
            int lineNumber = this.marker.LineNumber;
            int endLineNumber = this.marker.LineNumber;

            // Get the opening string character to determine what type of string this is.
            char stringType = this.codeReader.Peek();
            Debug.Assert(stringType == '\'' || stringType == '\"', "Expected a quote character");

            // Add the opening quote character and move past it.
            text.Append(stringType);
            this.codeReader.ReadNext();

            // Advance the end indexes past the literal character and the open quote character.
            endIndex += 2;
            endIndexOnLine += 2;

            while (true)
            {
                char character = this.codeReader.Peek();
                if (character == char.MinValue)
                {
                    // No more characters in the buffer.
                    break;
                }
                else if (character == stringType)
                {
                    // Read the character and add it to the text buffer.
                    this.codeReader.ReadNext();
                    text.Append(character);
                    ++endIndex;
                    ++endIndexOnLine;

                    // If the next character is also the same string type, then this is internal to the string.
                    character = this.codeReader.Peek();
                    if (character == stringType)
                    {
                        // Also move past this character and add it.
                        this.codeReader.ReadNext();
                        text.Append(character);

                        ++endIndex;
                        ++endIndexOnLine;
                        continue;
                    }
                    else
                    {
                        // This is the end of the string. We're done now.
                        break;
                    }
                }
                else if (character == '\r' || character == '\n')
                {
                    if (stringType == '\'')
                    {
                        // This is a syntax error in the code as single-quoted literal strings
                        // cannot allowed to span across multiple lines, although double-quoted 
                        // strings can.
                        throw new SyntaxException(this.source, this.marker.LineNumber);
                    }
                    else if (character == '\n')
                    {
                        ++endLineNumber;
                        endIndexOnLine = -1;
                    }
                    else if (character == '\r')
                    {
                        // Just move past this character without adding it.
                        this.codeReader.ReadNext();
                        continue;
                    }
                }

                this.codeReader.ReadNext();
                text.Append(character);
                ++endIndex;
                ++endIndexOnLine;
            }

            // Make sure the end index is correct now.
            if (text.Length <= 2 || text[text.Length - 1] != stringType)
            {
                throw new SyntaxException(this.source, this.marker.LineNumber);
            }

            // Create the location object.
            CodeLocation location = new CodeLocation(startIndex, endIndex, startIndexOnLine, endIndexOnLine, lineNumber, endLineNumber);

            // Create the symbol.
            Symbol token = new Symbol(text.ToString(), SymbolType.String, location);

            // Update the marker.
            this.marker.Index = endIndex;
            this.marker.IndexOnLine = endIndexOnLine;
            this.marker.LineNumber = endLineNumber;

            // Return the token.
            return token;
        }

        /// <summary>
        /// Gets the next multi-line comment.
        /// </summary>
        /// <param name="text">
        /// The buffer to add the text to.
        /// </param>
        /// <returns>
        /// Returns the comment.
        /// </returns>
        private Symbol GetMultiLineComment(StringBuilder text)
        {
            Param.AssertNotNull(text, "text");

            // Initialize the location of the start of the comment. Add one to the end indexes since we know the 
            // comment starts with /*, which is two characters long.
            int startIndex = this.marker.Index;
            int endIndex = this.marker.Index + 1;
            int startIndexOnLine = this.marker.IndexOnLine;
            int endIndexOnLine = this.marker.IndexOnLine + 1;
            int lineNumber = this.marker.LineNumber;
            int endLineNumber = this.marker.LineNumber;

            // Initialize loop trackers.
            bool asterisk = false;
            bool first = false;

            // Find the end of the comment.
            while (true)
            {
                char character = this.codeReader.Peek();
                if (character == char.MinValue)
                {
                    break;
                }

                // Add the character and move the index past it.
                text.Append(this.codeReader.ReadNext());

                if (asterisk && character == '/')
                {
                    // This is the end of the comment.
                    break;
                }
                else
                {
                    if (character == '*')
                    {
                        if (first)
                        {
                            // Mark the asterisk.
                            asterisk = true;
                        }
                        else
                        {
                            first = true;
                        }
                    }
                    else
                    {
                        // This is not an asterisk.
                        asterisk = false;

                        // Check for newlines.
                        if (character == '\n')
                        {
                            ++endLineNumber;
                            endIndexOnLine = -1;
                        }
                        else if (character == '\r')
                        {
                            // Peek at the next character and check the type.
                            character = this.codeReader.Peek();
                            if (character != '\n')
                            {
                                ++endLineNumber;
                                endIndexOnLine = -1;
                            }
                        }
                    }
                }

                ++endIndex;
                ++endIndexOnLine;
            }

            // Create the location object.
            CodeLocation location = new CodeLocation(startIndex, endIndex, startIndexOnLine, endIndexOnLine, lineNumber, endLineNumber);

            // Create the symbol object.
            Symbol symbol = new Symbol(text.ToString(), SymbolType.MultiLineComment, location);

            // Update the marker.
            this.marker.Index = endIndex + 1;
            this.marker.IndexOnLine = endIndexOnLine + 1;
            this.marker.LineNumber = endLineNumber;

            // Return the symbol.
            return symbol;
        }

        /// <summary>
        /// Gets the next newline character from the document.
        /// </summary>
        /// <returns>Returns the newline.</returns>
        [SuppressMessage("Microsoft.Globalization", "CA1303:DoNotPassLiteralsAsLocalizedParameters",
            MessageId = "StyleCop.CSharp.Symbol.#ctor(System.String,StyleCop.CSharp.SymbolType,StyleCop.CodeLocation)",
            Justification = "The literal is a non-localizable newline character")]
        private Symbol GetNewLine()
        {
            Symbol symbol = null;

            char character = this.codeReader.Peek();
            if (character != char.MinValue)
            {
                // Get the character
                this.codeReader.ReadNext();

                // Save the original start and end indexes of the newline character.
                int startIndex = this.marker.Index;
                int endIndex = this.marker.Index;

                // Check if this is an \r\n sequence in which case we need to adjust the end index.
                if (character == '\r')
                {
                    character = this.codeReader.Peek();
                    if (character == '\n')
                    {
                        this.codeReader.ReadNext();
                        ++this.marker.Index;
                        ++endIndex;
                    }
                }

                // Create the code location.
                CodeLocation location = new CodeLocation(
                    startIndex, endIndex, this.marker.IndexOnLine, this.marker.IndexOnLine + (endIndex - startIndex), this.marker.LineNumber, this.marker.LineNumber);

                // Create the symbol.
                symbol = new Symbol("\n", SymbolType.EndOfLine, location);

                // Update the marker.
                ++this.marker.Index;
                ++this.marker.LineNumber;
                this.marker.IndexOnLine = 0;
            }

            return symbol;
        }

        /// <summary>
        /// Gets the next number.
        /// </summary>
        /// <returns>Returns the number.</returns>
        private Symbol GetNumber()
        {
            // The last index of the number.
            int endIndex = -1;

            // The first few characters in the number tell us the type of the number.
            char character = this.codeReader.Peek();
            int markerIndex = this.marker.Index;

            if (character == '-' || character == '+')
            {
                // This could be a number starting with a negative or positive sign.
                // If that's true, the next character must be a digit between 0 and 9.
                character = this.codeReader.Peek(1);
                if (character >= '0' && character <= '9')
                {
                    endIndex = this.GetPositiveNumber(markerIndex + 1);
                }
            }
            else
            {
                // Get the body of the number.
                endIndex = this.GetPositiveNumber(markerIndex);
            }

            // Create the NumberSymbol now.
            Symbol number = null;

            // Make sure a number was found.
            // If we found '_' at the end, then this is not a number.
            // Note that '_' is not allowed at the beginning too, GetPositiveNumber already handle this.
            // There are other positions where '_' is not allowed (i.e in an exponent),
            // but for parsing purposes, we include those. The compiler will complain anyway.
            if (endIndex >= markerIndex && this.codeReader.Peek(endIndex - markerIndex) != '_')
            {
                // Get the text string for this number.
                int length = endIndex - markerIndex + 1;
                string numberText = this.codeReader.ReadString(length);
                Debug.Assert(!string.IsNullOrEmpty(numberText), "The text should not be empty");

                // Create the location object.
                CodeLocation location = new CodeLocation(
                    markerIndex,
                    markerIndex + length - 1,
                    this.marker.IndexOnLine,
                    this.marker.IndexOnLine + length - 1,
                    this.marker.LineNumber,
                    this.marker.LineNumber);

                number = new Symbol(numberText, SymbolType.Number, location);

                // Update the marker.
                this.marker.Index += length;
                this.marker.IndexOnLine += length;
            }

            return number;
        }

        /// <summary>
        /// Gets the next operator symbol.
        /// </summary>
        /// <param name="character">
        /// The first character of the symbol.
        /// </param>
        /// <returns>
        /// Returns the next operator symbol.
        /// </returns>
        [SuppressMessage("Microsoft.Maintainability", "CA1505:AvoidUnmaintainableCode", Justification = "The method long, but simple.")]
        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "The method long, but simple.")]
        private Symbol GetOperatorSymbol(char character)
        {
            Param.Ignore(character);

            SymbolType type = SymbolType.Other;
            StringBuilder text = new StringBuilder();
            int endLineIndex = this.marker.LineNumber;
            bool updateEndLineIndex = false;

            if (character == '.')
            {
                text.Append(".");
                type = SymbolType.Dot;
                this.codeReader.ReadNext();
            }
            else if (character == '~')
            {
                text.Append("~");
                type = SymbolType.Tilde;
                this.codeReader.ReadNext();
            }
            else if (character == '+')
            {
                text.Append("+");
                type = SymbolType.Plus;
                this.codeReader.ReadNext();

                character = this.codeReader.Peek();
                if (character == '+')
                {
                    text.Append("+");
                    type = SymbolType.Increment;
                    this.codeReader.ReadNext();
                }
                else if (character == '=')
                {
                    text.Append("=");
                    type = SymbolType.PlusEquals;
                    this.codeReader.ReadNext();
                }
            }
            else if (character == '-')
            {
                text.Append("-");
                type = SymbolType.Minus;
                this.codeReader.ReadNext();

                character = this.codeReader.Peek();
                if (character == '-')
                {
                    text.Append("-");
                    type = SymbolType.Decrement;
                    this.codeReader.ReadNext();
                }
                else if (character == '=')
                {
                    text.Append("=");
                    type = SymbolType.MinusEquals;
                    this.codeReader.ReadNext();
                }
                else if (character == '>')
                {
                    text.Append(">");
                    type = SymbolType.Pointer;
                    this.codeReader.ReadNext();
                }
            }
            else if (character == '*')
            {
                text.Append("*");
                type = SymbolType.Multiplication;
                this.codeReader.ReadNext();

                character = this.codeReader.Peek();
                if (character == '=')
                {
                    text.Append("=");
                    type = SymbolType.MultiplicationEquals;
                    this.codeReader.ReadNext();
                }
            }
            else if (character == '/')
            {
                text.Append("/");
                type = SymbolType.Division;
                this.codeReader.ReadNext();

                character = this.codeReader.Peek();
                if (character == '=')
                {
                    text.Append("=");
                    type = SymbolType.DivisionEquals;
                    this.codeReader.ReadNext();
                }
            }
            else if (character == '|')
            {
                text.Append("|");
                type = SymbolType.LogicalOr;
                this.codeReader.ReadNext();

                character = this.codeReader.Peek();
                if (character == '=')
                {
                    text.Append("=");
                    type = SymbolType.OrEquals;
                    this.codeReader.ReadNext();
                }
                else if (character == '|')
                {
                    text.Append("|");
                    type = SymbolType.ConditionalOr;
                    this.codeReader.ReadNext();
                }
            }
            else if (character == '&')
            {
                text.Append("&");
                type = SymbolType.LogicalAnd;
                this.codeReader.ReadNext();

                character = this.codeReader.Peek();
                if (character == '=')
                {
                    text.Append("=");
                    type = SymbolType.AndEquals;
                    this.codeReader.ReadNext();
                }
                else if (character == '&')
                {
                    text.Append("&");
                    type = SymbolType.ConditionalAnd;
                    this.codeReader.ReadNext();
                }
            }
            else if (character == '^')
            {
                text.Append("^");
                type = SymbolType.LogicalXor;
                this.codeReader.ReadNext();

                character = this.codeReader.Peek();
                if (character == '=')
                {
                    text.Append("=");
                    type = SymbolType.XorEquals;
                    this.codeReader.ReadNext();
                }
            }
            else if (character == '!')
            {
                text.Append("!");
                type = SymbolType.Not;
                this.codeReader.ReadNext();

                character = this.codeReader.Peek();
                if (character == '=')
                {
                    text.Append("=");
                    type = SymbolType.NotEquals;
                    this.codeReader.ReadNext();
                }
            }
            else if (character == '%')
            {
                text.Append("%");
                type = SymbolType.Mod;
                this.codeReader.ReadNext();

                character = this.codeReader.Peek();
                if (character == '=')
                {
                    text.Append("=");
                    type = SymbolType.ModEquals;
                    this.codeReader.ReadNext();
                }
            }
            else if (character == '=')
            {
                text.Append("=");
                type = SymbolType.Equals;
                this.codeReader.ReadNext();

                character = this.codeReader.Peek();
                if (character == '=')
                {
                    text.Append("=");
                    type = SymbolType.ConditionalEquals;
                    this.codeReader.ReadNext();
                }
                else if (character == '>')
                {
                    text.Append(">");
                    type = SymbolType.Lambda;
                    this.codeReader.ReadNext();
                }
            }
            else if (character == '<')
            {
                text.Append("<");
                type = SymbolType.LessThan;
                this.codeReader.ReadNext();

                character = this.codeReader.Peek();
                if (character == '=')
                {
                    text.Append("=");
                    type = SymbolType.LessThanOrEquals;
                    this.codeReader.ReadNext();
                }
                else if (character == '<')
                {
                    text.Append("<");
                    type = SymbolType.LeftShift;
                    this.codeReader.ReadNext();

                    character = this.codeReader.Peek();
                    if (character == '=')
                    {
                        text.Append("=");
                        type = SymbolType.LeftShiftEquals;
                        this.codeReader.ReadNext();
                    }
                }
            }
            else if (character == '>')
            {
                text.Append(">");
                type = SymbolType.GreaterThan;
                this.codeReader.ReadNext();

                character = this.codeReader.Peek();
                if (character == '=')
                {
                    text.Append("=");
                    type = SymbolType.GreaterThanOrEquals;
                    this.codeReader.ReadNext();
                }

                // Note: The right-shift symbol confuses the parsing of generics. 
                // If there are two greater-thans in a row then this may be a right-shift
                // symbol, but we cannot create it as such right now because it may also
                // be a couple of closing generic symbols in a row. This will have to be 
                // parsed out in the code. If this is a right-shift-equals then this will 
                // be created as three separate symbols, two greater-thans and then an 
                // equals. Later on we will recombine these.
            }
            else if (character == '?')
            {
                text.Append("?");
                type = SymbolType.QuestionMark;
                this.codeReader.ReadNext();
                character = this.codeReader.Peek();

                StringBuilder checkNullCondition = new StringBuilder();
                int checkIndex = 0;

                while (true)
                {
                    if (character == '\r' || character == '\n' || character == ' ')
                    {
                        if (character == '\r')
                        {
                            endLineIndex++;
                        }
                        else if (character == '\n'
                            && checkIndex > 0
                            && this.codeReader.Peek(checkIndex - 1) != '\r')
                        {
                            endLineIndex++;
                        }

                        checkNullCondition.Append(character);
                    }
                    else if (character == '/')
                    {
                        if (this.codeReader.Peek(checkIndex + 1) == '/')
                        {
                            this.codeReader.ReadNext(checkIndex);
                            Symbol nextComment = this.GetComment();
                            checkNullCondition.Append(nextComment.Text);
                            checkIndex = -1;
                        }
                    }
                    else
                    {
                        break;
                    }

                    checkIndex++;
                    character = this.codeReader.Peek(checkIndex);
                }

                if (character == '?' && checkNullCondition.Length == 0)
                {
                    text.Append("?");
                    type = SymbolType.NullCoalescingSymbol;
                    this.codeReader.ReadNext();
                }
                else if (character == '.')
                {
                    // Check split for null conditional operator.
                    if (!string.IsNullOrEmpty(checkNullCondition.ToString()))
                    {
                        text.Append(checkNullCondition.ToString());

                        // Advance cursor for next symbol.
                        this.codeReader.ReadNext(checkIndex);

                        updateEndLineIndex = true;
                    }

                    text.Append(".");
                    type = SymbolType.NullConditional;
                    this.codeReader.ReadNext();
                }
                else if (character == '[')
                {
                    // ']' indicates that it's a 1-dimensional array, not an indexer
                    // ',' indicates that it's a multi-dimensional array, not an indexer.
                    if (this.codeReader.Peek(1) != ']' && this.codeReader.PeekNonWhitespace(1) != ',')
                    {
                        // Check split for null conditional operator.
                        if (!string.IsNullOrEmpty(checkNullCondition.ToString()))
                        {
                            text.Append(checkNullCondition.ToString());

                            // Advance cursor for next symbol.
                            this.codeReader.ReadNext(checkIndex);

                            updateEndLineIndex = true;
                        }

                        // null conditional against an opening bracket like foo?[0];
                        type = SymbolType.NullConditional;
                    }
                }
            }
            else if (character == ':')
            {
                text.Append(":");
                type = SymbolType.Colon;
                this.codeReader.ReadNext();

                character = this.codeReader.Peek();
                if (character == ':')
                {
                    text.Append(":");
                    type = SymbolType.QualifiedAlias;
                    this.codeReader.ReadNext();
                }
            }

            // Make sure we have a symbol now.
            if (text == null || text.Length == 0)
            {
                throw new SyntaxException(this.source, this.marker.LineNumber);
            }

            if (!updateEndLineIndex)
            {
                endLineIndex = this.marker.LineNumber;
            }

            // Create the code location.
            CodeLocation location = new CodeLocation(
                this.marker.Index,
                this.marker.Index + text.Length - 1,
                this.marker.IndexOnLine,
                this.marker.IndexOnLine + text.Length - 1,
                this.marker.LineNumber,
                endLineIndex);

            if (updateEndLineIndex)
            {
                this.marker.LineNumber = endLineIndex;
            }

            // Create the token.
            Symbol symbol = new Symbol(text.ToString(), type, location);

            // Update the marker.
            this.marker.Index += text.Length;
            this.marker.IndexOnLine += text.Length;

            // Return the symbol.
            return symbol;
        }

        /// <summary>
        /// Gets an unknown symbol type.
        /// </summary>
        /// <param name="sourceCode">
        /// The source code containing the symbols.
        /// </param>
        /// <returns>
        /// Returns the item.
        /// </returns>
        private Symbol GetOtherSymbol(SourceCode sourceCode)
        {
            Param.AssertNotNull(sourceCode, "sourceCode");

            StringBuilder text = new StringBuilder();
            this.ReadToEndOfOtherSymbol(text);
            if (text.Length == 0)
            {
                throw new SyntaxException(sourceCode, this.marker.LineNumber);
            }

            string symbolText = text.ToString();

            // Get the token location.
            CodeLocation location = new CodeLocation(
                this.marker.Index,
                this.marker.Index + text.Length - 1,
                this.marker.IndexOnLine,
                this.marker.IndexOnLine + text.Length - 1,
                this.marker.LineNumber,
                this.marker.LineNumber);

            // Create the symbol.
            Symbol symbol = new Symbol(symbolText, CodeLexer.GetOtherSymbolType(symbolText), location);

            // Reset the marker index.
            this.marker.Index += text.Length;
            this.marker.IndexOnLine += text.Length;

            // Return the symbol.
            return symbol;
        }

        /// <summary>
        /// Extracts the body of a positive number from the code.
        /// </summary>
        /// <param name="index">
        /// The first index of the number.
        /// </param>
        /// <returns>
        /// Returns the last index of the number.
        /// </returns>
        private int GetPositiveNumber(int index)
        {
            Param.AssertGreaterThanOrEqualToZero(index, "index");

            // First, check if this is a hexadecimal number.
            char character = this.codeReader.Peek();
            if (character == '0')
            {
                character = this.codeReader.Peek(1);
                if (character == 'x' || character == 'X')
                {
                    return this.GetHexadecimalIntegerLiteral(index + 2);
                }

                if (character == 'b' || character == 'B')
                {
                    return this.GetBinaryLiteral(index + 2);
                }
            }

            // Treat this like a decimal literal.
            return this.GetDecimalLiteral(index);
        }

        /// <summary>
        /// Gets the next preprocessor directive keyword.
        /// </summary>
        /// <param name="symbols">
        /// The List of symbols we've processed.
        /// </param>
        /// <param name="sourceCode">
        /// The source code.
        /// </param>
        /// <param name="configuration">
        /// The active configuration.
        /// </param>
        /// <returns>
        /// Returns the next preprocessor directive keyword.
        /// </returns>
        private Symbol GetPreprocessorDirectiveSymbol(List<Symbol> symbols, SourceCode sourceCode, Configuration configuration)
        {
            Param.AssertNotNull(symbols, "symbols");
            Param.AssertNotNull(sourceCode, "sourceCode");
            Param.Ignore(configuration);

            // Find the end of the current line.
            StringBuilder text = new StringBuilder();
            this.AdvanceToEndOfLine(text);
            if (text.Length == 1)
            {
                throw new SyntaxException(sourceCode, 1, Strings.UnexpectedEndOfFile);
            }

            // Create the code location.
            CodeLocation location = new CodeLocation(
                this.marker.Index,
                this.marker.Index + text.Length - 1,
                this.marker.IndexOnLine,
                this.marker.IndexOnLine + text.Length - 1,
                this.marker.LineNumber,
                this.marker.LineNumber);

            // Create the symbol.
            Symbol symbol = new Symbol(text.ToString(), SymbolType.PreprocessorDirective, location);

            // Update the marker.
            this.marker.Index += text.Length;
            this.marker.IndexOnLine += text.Length;

            // If this is a conditional preprocessor symbol which resolves to false,
            // then we need to figure out which code is not in scope.
            this.CheckForConditionalCompilationDirective(symbols, sourceCode, symbol, configuration);

            // Return the symbol.
            return symbol;
        }

        /// <summary>
        /// Gets an exponent at the end of a real literal number.
        /// </summary>
        /// <param name="index">
        /// The start index of the exponent.
        /// </param>
        /// <returns>
        /// Returns the last index of the exponent.
        /// </returns>
        private int GetRealLiteralExponent(int index)
        {
            Param.AssertGreaterThanOrEqualToZero(index, "index");

            int endIndex = -1;

            // The exponent must start with e or E.
            char character = this.codeReader.Peek(index - this.marker.Index);
            if (character == 'e' || character == 'E')
            {
                ++index;

                // The exponent can optionally contain a positive or negative sign.
                character = this.codeReader.Peek(index - this.marker.Index);
                {
                    if (character == '-' || character == '+')
                    {
                        ++index;
                    }
                }

                // The rest of the numbers must be decimal digits.
                while (true)
                {
                    character = this.codeReader.Peek(index - this.marker.Index);
                    if (character >= '0' && character <= '9')
                    {
                        endIndex = index;
                        ++index;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return endIndex;
        }

        /// <summary>
        /// Gets the characters trailing behind a real literal number, if there are any.
        /// </summary>
        /// <param name="index">
        /// The start index of the trailing characters.
        /// </param>
        /// <param name="requiresDecimalPoint">
        /// Indicates whether the number is required to start with a decimal point.
        /// </param>
        /// <returns>
        /// Returns the last index of the trailing characters.
        /// </returns>
        private int GetRealLiteralTrailingCharacters(int index, bool requiresDecimalPoint)
        {
            Param.Ignore(index);
            Param.Ignore(requiresDecimalPoint);

            bool hasTrailingCharacters = false;
            bool hasDecimal = false;

            char character = this.codeReader.Peek(index - this.marker.Index + 1);

            // First, check if the next character is a decimal point.
            if (character == '.')
            {
                int endIndex = this.GetDecimalFraction(index + 2);
                if (endIndex != -1)
                {
                    index = endIndex;
                    hasDecimal = true;
                    hasTrailingCharacters = true;
                }
            }

            if (!requiresDecimalPoint || hasDecimal)
            {
                // Now check whether the number contains an exponent part.
                character = this.codeReader.Peek(index - this.marker.Index + 1);
                if (character == 'e' || character == 'E')
                {
                    int endIndex = this.GetRealLiteralExponent(index + 1);
                    if (endIndex != -1)
                    {
                        index = endIndex;
                        hasTrailingCharacters = true;
                    }
                }

                // Now check whether the number ends in a real type suffix.
                character = this.codeReader.Peek(index - this.marker.Index + 1);
                if (character == 'm' || character == 'M' || character == 'd' || character == 'D' || character == 'f' || character == 'F')
                {
                    ++index;
                    hasTrailingCharacters = true;
                }
            }

            if (!hasTrailingCharacters)
            {
                index = -1;
            }

            return index;
        }

        /// <summary>
        /// Gets the next single line comment from the code.
        /// </summary>
        /// <param name="text">
        /// The buffer in which to store the text.
        /// </param>
        /// <returns>
        /// Returns the single line comment.
        /// </returns>
        private Symbol GetSingleLineComment(StringBuilder text)
        {
            Param.AssertNotNull(text, "text");

            // Find the end of the current line.
            this.AdvanceToEndOfLine(text);

            // Create the code location.
            CodeLocation location = new CodeLocation(
                this.marker.Index,
                this.marker.Index + text.Length - 1,
                this.marker.IndexOnLine,
                this.marker.IndexOnLine + text.Length - 1,
                this.marker.LineNumber,
                this.marker.LineNumber);

            // Create the symbol.
            Symbol symbol = new Symbol(text.ToString(), SymbolType.SingleLineComment, location);

            // Update the marker.
            this.marker.Index += text.Length;
            this.marker.IndexOnLine += text.Length;

            // Return the symbol.
            return symbol;
        }

        /// <summary>
        /// Gets the next string from the code.
        /// </summary>
        /// <returns>Returns the string.</returns>
        private Symbol GetString()
        {
            StringBuilder text = new StringBuilder();

            this.ReadStringText(text, false);

            // Create the code location.
            CodeLocation location = new CodeLocation(
                this.marker.Index,
                this.marker.Index + text.Length - 1,
                this.marker.IndexOnLine,
                this.marker.IndexOnLine + text.Length - 1,
                this.marker.LineNumber,
                this.marker.LineNumber);

            // Create the symbol.
            Symbol symbol = new Symbol(text.ToString(), SymbolType.String, location);

            // Update the marker.
            this.marker.Index += text.Length;
            this.marker.IndexOnLine += text.Length;

            // Return the symbol.
            return symbol;
        }

        private void ReadStringText(StringBuilder text, bool isVerbatim)
        {
            if (isVerbatim)
            {
                char verbatimChar = this.codeReader.ReadNext();
                Debug.Assert(verbatimChar == '@', "Expected a verbatim character");
                text.Append(verbatimChar);
            }

            // Read the opening quote character and add it to the string.
            char quoteType = this.codeReader.ReadNext();
            Debug.Assert(quoteType == '\'' || quoteType == '\"', "Expected a quote character");
            text.Append(quoteType);

            bool slash = false;

            // Read through to the end of the string.
            while (true)
            {
                char character = this.codeReader.Peek();
                if (character == char.MinValue || (character == quoteType && !slash))
                {
                    // This is the end of the string. Add the character and quit.
                    text.Append(character);
                    this.codeReader.ReadNext();
                    break;
                }

                if (character == '\\')
                {
                    // Toggle when we move in and out of a slash, only if not a verbatim string.
                    slash = !isVerbatim && !slash;
                }
                else
                {
                    slash = false;

                    if (character == '\r' || character == '\n')
                    {
                        // We've hit the end of the line. Just exit.
                        break;
                    }
                }

                text.Append(character);

                // Advance past this character.
                this.codeReader.ReadNext();
            }
        }

        /// <summary>
        /// Gets the next interpolated string from the code.
        /// </summary>
        /// <returns>Returns the interpolated string.</returns>
        private Symbol GetInterpolatedString()
        {
            StringBuilder text = new StringBuilder();
            int endLineNumber = this.marker.LineNumber;
            int endLineStartIndex = 0;
            this.ReadInterpolatedStringText(text, ref endLineNumber, ref endLineStartIndex);

            // Create the code location.
            CodeLocation location = new CodeLocation(
                this.marker.Index,
                this.marker.Index + text.Length - 1,
                this.marker.IndexOnLine + 1,
                (endLineNumber == this.marker.LineNumber ? this.marker.IndexOnLine : -1) + text.Length - endLineStartIndex,
                this.marker.LineNumber,
                endLineNumber);

            // Create the symbol.
            Symbol symbol = new Symbol(text.ToString(), SymbolType.String, location);

            // Update the marker.
            this.marker.Index += text.Length;
            this.marker.IndexOnLine += text.Length - endLineStartIndex;
            this.marker.LineNumber = endLineNumber;

            // Return the symbol.
            return symbol;
        }

        private void ReadInterpolatedStringText(StringBuilder text, ref int endLineNumber, ref int endLineStartIndex)
        {
            char dollarSign = this.codeReader.ReadNext();
            Debug.Assert(dollarSign == '$', "Interoplated strings must begin with a dollar sign ('$').");
            text.Append(dollarSign);

            bool isVerbatim;
            if (this.codeReader.Peek() == '@')
            {
                text.Append(this.codeReader.ReadNext());
                isVerbatim = true;
            }
            else
            {
                isVerbatim = false;
            }

            // Read the opening quote character and add it to the string.
            char character = this.codeReader.ReadNext();
            Debug.Assert(character == '\"', "Expected a quote character");
            text.Append(character);

            Stack<char> openingCharacters = new Stack<char>();
            openingCharacters.Push(character);

            bool slash = false;

            // Read through to the end of the string.
            while (openingCharacters.Count > 0)
            {
                character = this.codeReader.Peek();
                if (character == char.MinValue)
                {
                    // This is the end of the code file
                    return;
                }

                if (!slash)
                {
                    if (openingCharacters.Peek() == '{')
                    {
                        if (character == '@')
                        {
                            this.ReadStringText(text, true);
                            continue;
                        }

                        if (character == '"')
                        {
                            // There is a string within the interpolated string
                            this.ReadStringText(text, false);
                            continue;
                        }

                        if (character == '$')
                        {
                            // There is an interpolated string within the interpolated string
                            this.ReadInterpolatedStringText(text, ref endLineNumber, ref endLineStartIndex);
                            continue;
                        }

                        if (character == '}')
                        {
                            // This is a closing curly bracket
                            text.Append(character);
                            openingCharacters.Pop();
                            this.codeReader.ReadNext();
                            continue;
                        }
                    }

                    if (openingCharacters.Peek() == '"'
                        && (character == '{' || character == '}')
                        && character == this.codeReader.Peek(1))
                    {
                        // This is an escaped curly bracket
                        text.Append(this.codeReader.ReadString(2));
                        continue;
                    }

                    if (character == '"')
                    {
                        if (isVerbatim)
                        {
                            if (this.codeReader.Peek(1) == '"')
                            {
                                // This is a double-quote escaped by another double-quote
                                text.Append(this.codeReader.ReadString(2));
                                continue;
                            }
                            else
                            {
                                // This is a closing double-quote
                                text.Append(character);
                                openingCharacters.Pop();
                                this.codeReader.ReadNext();
                                continue;
                            }
                        }
                        else
                        {
                            if (openingCharacters.Peek() == '"')
                            {
                                text.Append(character);
                                openingCharacters.Pop();
                                this.codeReader.ReadNext();
                                continue;
                            }

                            text.Append(character);
                            openingCharacters.Push(character);
                            this.codeReader.ReadNext();
                            continue;
                        }
                    }

                    if (character == '{')
                    {
                        text.Append(character);
                        openingCharacters.Push(character);
                        this.codeReader.ReadNext();
                        continue;
                    }
                }

                if (character == '\\' && !isVerbatim)
                {
                    slash = !slash;
                }
                else
                {
                    slash = false;

                    if (character == '\r' || character == '\n')
                    {
                        if (!isVerbatim)
                        {
                            // We've hit the end of the line. Just exit.
                            return;
                        }

                        if (character == '\n')
                        {
                            // Increment line number as we are in a verbatim string
                            endLineNumber++;
                            endLineStartIndex = text.Length;
                        }
                    }
                }

                text.Append(character);

                // Advance past this character.
                this.codeReader.ReadNext();
            }
        }

        private bool IsClosingCharacter(char character, char openingCharacter)
        {
            switch (character)
            {
                case '"':
                    return openingCharacter == '"';
                case '}':
                    return openingCharacter == '{';
                default:
                    return false;
            }
        }

        /// <summary>
        /// Gets an undefine preprocessor directive from the code.
        /// </summary>
        /// <param name="sourceCode">
        /// The source code being parsed.
        /// </param>
        /// <param name="preprocessorSymbol">
        /// The preprocessor symbol being parsed.
        /// </param>
        /// <param name="startIndex">
        /// The start index within the symbols.
        /// </param>
        private void GetUndefinePreprocessorDirective(SourceCode sourceCode, Symbol preprocessorSymbol, int startIndex)
        {
            Param.AssertNotNull(sourceCode, "sourceCode");
            Param.AssertNotNull(preprocessorSymbol, "preprocessorSymbol");
            Param.AssertGreaterThanOrEqualToZero(startIndex, "startIndex");

            // Get the body of the undefine directive.
            LiteralExpression body = CodeParser.GetConditionalPreprocessorBodyExpression(this.parser, sourceCode, preprocessorSymbol, startIndex) as LiteralExpression;
            if (body == null)
            {
                throw new SyntaxException(sourceCode, preprocessorSymbol.LineNumber);
            }

            // Create the undefines list if necessary.
            if (this.undefines == null)
            {
                this.undefines = new Dictionary<string, string>();
            }

            // Add the item to the list.
            if (!this.undefines.ContainsKey(body.Text))
            {
                this.undefines.Add(body.Text, body.Text);
            }

            // Remove the item from the defines list if it exists.
            if (this.defines != null)
            {
                this.defines.Remove(body.Text);
            }
        }

        /// <summary>
        /// Gets the next whitespace stream.
        /// </summary>
        /// <returns>Returns the whitespace.</returns>
        private Symbol GetWhitespace()
        {
            StringBuilder text = new StringBuilder();

            // Get all of the characters in the whitespace.
            while (true)
            {
                char character = this.codeReader.Peek();
                UnicodeCategory category = char.GetUnicodeCategory(character);

                if (character == char.MinValue || (category != UnicodeCategory.SpaceSeparator && character != '\t'))
                {
                    break;
                }

                text.Append(character);

                // Advance past this character.
                this.codeReader.ReadNext();
            }

            // Create the whitespace location object.
            CodeLocation location = new CodeLocation(
                this.marker.Index,
                this.marker.Index + text.Length - 1,
                this.marker.IndexOnLine,
                this.marker.IndexOnLine + text.Length - 1,
                this.marker.LineNumber,
                this.marker.LineNumber);

            // Create the whitespace object.
            Symbol whitespace = new Symbol(text.ToString(), SymbolType.WhiteSpace, location);

            // Update the marker.
            this.marker.Index += text.Length;
            this.marker.IndexOnLine += text.Length;

            // Return the whitespace object.
            return whitespace;
        }

        /// <summary>
        /// Gets the next Xml header line from the code.
        /// </summary>
        /// <param name="text">
        /// The buffer in which to store the text.
        /// </param>
        /// <returns>
        /// Returns the Xml header line.
        /// </returns>
        private Symbol GetXmlHeaderLine(StringBuilder text)
        {
            Param.AssertNotNull(text, "text");

            // Find the end of the current line.
            this.AdvanceToEndOfLine(text);

            // Create the code location.
            CodeLocation location = new CodeLocation(
                this.marker.Index,
                this.marker.Index + text.Length - 1,
                this.marker.IndexOnLine,
                this.marker.IndexOnLine + text.Length - 1,
                this.marker.LineNumber,
                this.marker.LineNumber);

            // Create the symbol.
            Symbol symbol = new Symbol(text.ToString(), SymbolType.XmlHeaderLine, location);

            // Update the marker.
            this.marker.Index += text.Length;
            this.marker.IndexOnLine += text.Length;

            // Return the symbol.
            return symbol;
        }

        /// <summary>
        /// Checks whether code reader contains encoded letter at the current position.
        /// </summary>
        /// <param name="sequence">
        /// Reference parameter holding character sequence.
        /// </param>
        /// <param name="character">
        /// Reference parameter holding character value.
        /// </param>
        /// <returns>
        /// Returns true if code reader contains encoded letter.
        /// </returns>
        private bool IsLetterEncoded(ref char[] sequence, ref char character)
        {
            Param.Ignore(sequence, character);

            if (this.codeReader.Peek(0) != '\\')
            {
                return false;
            }

            // Check whether short syntax is used.
            sequence = new[]
            {
                this.codeReader.Peek(0),
                this.codeReader.Peek(1),
                this.codeReader.Peek(2),
                this.codeReader.Peek(3),
                this.codeReader.Peek(4),
                this.codeReader.Peek(5)
            };

            if (IsLetterEncoded(sequence, out character))
            {
                return true;
            }

            // Check whether long syntax is used.
            sequence = new[]
            {
                this.codeReader.Peek(0),
                this.codeReader.Peek(1),
                this.codeReader.Peek(2),
                this.codeReader.Peek(3),
                this.codeReader.Peek(4),
                this.codeReader.Peek(5),
                this.codeReader.Peek(6),
                this.codeReader.Peek(7),
                this.codeReader.Peek(8),
                this.codeReader.Peek(9)
            };

            if (IsLetterEncoded(sequence, out character))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Gathers all the characters up to the last index of an unknown word.
        /// </summary>
        /// <param name="text">
        /// The text buffer to add the symbol text to.
        /// </param>
        private void ReadToEndOfOtherSymbol(StringBuilder text)
        {
            Param.AssertNotNull(text, "text");

            bool seenLetter = false;

            // Loop until we find the end of the word.
            while (true)
            {
                // Check whether there is no more code.
                if (this.codeReader.Peek() == char.MinValue)
                {
                    break;
                }

                char characterValue = char.MinValue;
                char[] characterSequence = null;

                // Read character sequence as well as character value from code reader.
                // If usual character is being read then sequence array will contain the same character as value.
                // If Unicode character escape sequence is being read then sequence array will contain
                // exact characters from the reader and value character will contain character represented by the sequence.
                if (this.IsLetterEncoded(ref characterSequence, ref characterValue))
                {
                    // All required data has been already stored into variables.
                }
                else
                {
                    characterValue = this.codeReader.Peek();
                    characterSequence = new[] { characterValue };
                }

                // Decide whether we should stop continuing the current word.
                if (IsLetterExtended(characterValue))
                {
                    // Mark that we've seen a letter in this word, and continue.
                    seenLetter = true;
                }
                else if (seenLetter && char.IsNumber(characterValue))
                {
                    // Numbers are ok as long as we've previously seen at least one
                    // letter in this word.
                }
                else
                {
                    // This is an invalid character, so break out of the loop.
                    break;
                }

                // Add the character(s) to the text buffer and advance the reader past it.
                foreach (char c in characterSequence)
                {
                    text.Append(c);
                    this.codeReader.ReadNext();
                }
            }
        }

        /// <summary>
        /// Extracts an if, endif, or else directive.
        /// </summary>
        /// <param name="sourceCode">
        /// The source code being parsed.
        /// </param>
        /// <param name="preprocessorSymbol">
        /// The preprocessor symbol being parsed.
        /// </param>
        /// <param name="configuration">
        /// The current code configuration.
        /// </param>
        /// <param name="startIndex">
        /// The start index of the item within the symbols.
        /// </param>
        /// <param name="type">
        /// The type of the preprocessor symbol.
        /// </param>
        private void SetEvaluatingSymbolsForIfElifElse(SourceCode sourceCode, Symbol preprocessorSymbol, Configuration configuration, int startIndex, string type)
        {
            Param.AssertNotNull(sourceCode, "sourceCode");
            Param.AssertNotNull(preprocessorSymbol, "preprocessorSymbol");
            Param.AssertNotNull(configuration, "configuration");
            Param.AssertGreaterThanOrEqualToZero(startIndex, "startIndex");
            Param.AssertValidString(type, "type");

            switch (type)
            {
                case "if":
                    this.evaluatingSymbolsStatus.Push(this.evaluatingSymbols);
                    if (this.evaluatingSymbols)
                    {
                        // Extract the body of the directive.
                        Expression body = CodeParser.GetConditionalPreprocessorBodyExpression(this.parser, sourceCode, preprocessorSymbol, startIndex);
                        if (body == null)
                        {
                            throw new SyntaxException(sourceCode, preprocessorSymbol.LineNumber);
                        }

                        // Determine whether the code under this directive needs to be skipped.
                        this.evaluatingSymbols = this.EvaluateConditionalDirectiveExpression(sourceCode, body, configuration);
                    }

                    this.conditionalDirectives.Push(this.evaluatingSymbols);
                    break;

                case "elif":
                    {
                        if (this.conditionalDirectives.Count == 0)
                        {
                            throw new SyntaxException(sourceCode, preprocessorSymbol.LineNumber);
                        }

                        bool conditionalValue = this.conditionalDirectives.Peek();

                        // If the #if we are part of was 'true' then we stop evaluating.
                        if (conditionalValue)
                        {
                            this.evaluatingSymbols = false;
                        }
                        else
                        {
                            // If we were evaluatingSymbols before this #if started then check again now.
                            if (this.evaluatingSymbolsStatus.Peek())
                            {
                                // Extract the body of the directive.
                                Expression body = CodeParser.GetConditionalPreprocessorBodyExpression(this.parser, sourceCode, preprocessorSymbol, startIndex);
                                if (body == null)
                                {
                                    throw new SyntaxException(sourceCode, preprocessorSymbol.LineNumber);
                                }

                                // Determine whether the code under this directive needs to be skipped.
                                this.evaluatingSymbols = this.EvaluateConditionalDirectiveExpression(sourceCode, body, configuration);

                                if (this.evaluatingSymbols)
                                {
                                    this.conditionalDirectives.Pop();
                                    this.conditionalDirectives.Push(true);
                                }
                            }
                        }
                    }

                    break;

                case "else":
                    if (this.conditionalDirectives.Count == 0)
                    {
                        throw new SyntaxException(sourceCode, preprocessorSymbol.LineNumber);
                    }

                    // If we were evaluatingSymbols before this #if started then check again now.
                    if (this.evaluatingSymbolsStatus.Peek())
                    {
                        bool conditionalValue = this.conditionalDirectives.Peek();

                        // If the #if we are part of was 'true' then we stop evaluating.
                        this.evaluatingSymbols = !conditionalValue;
                    }

                    break;
            }
        }

        #endregion
    }
}