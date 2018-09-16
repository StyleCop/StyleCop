// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CodeParser.Symbols.cs" company="https://github.com/StyleCop">
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
    using System;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// The code parser.
    /// </summary>
    /// <content>
    /// Contains code for parsing symbols within a C# code file.
    /// </content>
    internal partial class CodeParser
    {
        #region Methods

        /// <summary>
        /// Creates an operator token from the given symbol.
        /// </summary>
        /// <param name="symbol">
        /// The symbol to convert.
        /// </param>
        /// <param name="parentReference">
        /// The parent code part.
        /// </param>
        /// <param name="generated">
        /// Indicates whether the symbol lies within a generated code block.
        /// </param>
        /// <returns>
        /// Returns the operator symbol.
        /// </returns>
        private static OperatorSymbol CreateOperatorToken(Symbol symbol, Reference<ICodePart> parentReference, bool generated)
        {
            Param.AssertNotNull(symbol, "symbol");
            Param.AssertNotNull(parentReference, "parentReference");
            Param.Ignore(generated);

            // Get the type of the operator.
            OperatorType type;
            OperatorCategory category;
            if (!GetOperatorType(symbol, out type, out category))
            {
                // This should never happen unless there is a bug in the code.
                Debug.Fail("Unexpected operator type");
                throw new InvalidOperationException();
            }

            // Create and return the operator.
            return new OperatorSymbol(symbol.Text, category, type, symbol.Location, parentReference, generated);
        }

        /// <summary>
        /// Gets the type of the given operator symbol.
        /// </summary>
        /// <param name="symbol">
        /// The symbol to check.
        /// </param>
        /// <param name="type">
        /// Returns the operator type.
        /// </param>
        /// <param name="category">
        /// Returns the operator category.
        /// </param>
        /// <returns>
        /// Returns true if the symbol is an operator.
        /// </returns>
        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "The method is not complex.")]
        private static bool GetOperatorType(Symbol symbol, out OperatorType type, out OperatorCategory category)
        {
            Param.AssertNotNull(symbol, "symbol");

            bool isOperator = true;

            switch (symbol.SymbolType)
            {
                case SymbolType.LogicalAnd:
                    type = OperatorType.LogicalAnd;
                    category = OperatorCategory.Logical;
                    break;
                case SymbolType.LogicalOr:
                    type = OperatorType.LogicalOr;
                    category = OperatorCategory.Logical;
                    break;
                case SymbolType.LogicalXor:
                    type = OperatorType.LogicalXor;
                    category = OperatorCategory.Logical;
                    break;
                case SymbolType.ConditionalAnd:
                    type = OperatorType.ConditionalAnd;
                    category = OperatorCategory.Logical;
                    break;
                case SymbolType.ConditionalOr:
                    type = OperatorType.ConditionalOr;
                    category = OperatorCategory.Logical;
                    break;
                case SymbolType.NullCoalescingSymbol:
                    type = OperatorType.NullCoalescingSymbol;
                    category = OperatorCategory.Logical;
                    break;
                case SymbolType.Equals:
                    type = OperatorType.Equals;
                    category = OperatorCategory.Assignment;
                    break;
                case SymbolType.AndEquals:
                    type = OperatorType.AndEquals;
                    category = OperatorCategory.Assignment;
                    break;
                case SymbolType.OrEquals:
                    type = OperatorType.OrEquals;
                    category = OperatorCategory.Assignment;
                    break;
                case SymbolType.PlusEquals:
                    type = OperatorType.PlusEquals;
                    category = OperatorCategory.Assignment;
                    break;
                case SymbolType.MinusEquals:
                    type = OperatorType.MinusEquals;
                    category = OperatorCategory.Assignment;
                    break;
                case SymbolType.MultiplicationEquals:
                    type = OperatorType.MultiplicationEquals;
                    category = OperatorCategory.Assignment;
                    break;
                case SymbolType.DivisionEquals:
                    type = OperatorType.DivisionEquals;
                    category = OperatorCategory.Assignment;
                    break;
                case SymbolType.ModEquals:
                    type = OperatorType.ModEquals;
                    category = OperatorCategory.Assignment;
                    break;
                case SymbolType.XorEquals:
                    type = OperatorType.XorEquals;
                    category = OperatorCategory.Assignment;
                    break;
                case SymbolType.LeftShiftEquals:
                    type = OperatorType.LeftShiftEquals;
                    category = OperatorCategory.Assignment;
                    break;
                case SymbolType.RightShiftEquals:
                    type = OperatorType.RightShiftEquals;
                    category = OperatorCategory.Assignment;
                    break;
                case SymbolType.ConditionalEquals:
                    type = OperatorType.ConditionalEquals;
                    category = OperatorCategory.Relational;
                    break;
                case SymbolType.NotEquals:
                    type = OperatorType.NotEquals;
                    category = OperatorCategory.Relational;
                    break;
                case SymbolType.LessThan:
                    type = OperatorType.LessThan;
                    category = OperatorCategory.Relational;
                    break;
                case SymbolType.GreaterThan:
                    type = OperatorType.GreaterThan;
                    category = OperatorCategory.Relational;
                    break;
                case SymbolType.LessThanOrEquals:
                    type = OperatorType.LessThanOrEquals;
                    category = OperatorCategory.Relational;
                    break;
                case SymbolType.GreaterThanOrEquals:
                    type = OperatorType.GreaterThanOrEquals;
                    category = OperatorCategory.Relational;
                    break;
                case SymbolType.Plus:
                    type = OperatorType.Plus;
                    category = OperatorCategory.Arithmetic;
                    break;
                case SymbolType.Minus:
                    type = OperatorType.Minus;
                    category = OperatorCategory.Arithmetic;
                    break;
                case SymbolType.Multiplication:
                    type = OperatorType.Multiplication;
                    category = OperatorCategory.Arithmetic;
                    break;
                case SymbolType.Division:
                    type = OperatorType.Division;
                    category = OperatorCategory.Arithmetic;
                    break;
                case SymbolType.Mod:
                    type = OperatorType.Mod;
                    category = OperatorCategory.Arithmetic;
                    break;
                case SymbolType.LeftShift:
                    type = OperatorType.LeftShift;
                    category = OperatorCategory.Shift;
                    break;
                case SymbolType.RightShift:
                    type = OperatorType.RightShift;
                    category = OperatorCategory.Shift;
                    break;
                case SymbolType.Increment:
                    type = OperatorType.Increment;
                    category = OperatorCategory.IncrementDecrement;
                    break;
                case SymbolType.Decrement:
                    type = OperatorType.Decrement;
                    category = OperatorCategory.IncrementDecrement;
                    break;
                case SymbolType.QuestionMark:
                    type = OperatorType.ConditionalQuestionMark;
                    category = OperatorCategory.Conditional;
                    break;
                case SymbolType.Colon:
                    type = OperatorType.ConditionalColon;
                    category = OperatorCategory.Conditional;
                    break;
                case SymbolType.Pointer:
                    type = OperatorType.Pointer;
                    category = OperatorCategory.Reference;
                    break;
                case SymbolType.Dot:
                    type = OperatorType.MemberAccess;
                    category = OperatorCategory.Reference;
                    break;
                case SymbolType.QualifiedAlias:
                    type = OperatorType.QualifiedAlias;
                    category = OperatorCategory.Reference;
                    break;
                case SymbolType.Not:
                    type = OperatorType.Not;
                    category = OperatorCategory.Unary;
                    break;
                case SymbolType.Tilde:
                    type = OperatorType.BitwiseCompliment;
                    category = OperatorCategory.Unary;
                    break;
                case SymbolType.Lambda:
                    type = OperatorType.Lambda;
                    category = OperatorCategory.Lambda;
                    break;
                case SymbolType.NullConditional:
                    type = OperatorType.NullConditional;
                    category = OperatorCategory.Logical;
                    break;
                default:

                    // Assign random values.
                    type = OperatorType.AddressOf;
                    category = OperatorCategory.Arithmetic;

                    // Signal that the symbol is not an operator.
                    isOperator = false;
                    break;
            }

            return isOperator;
        }

        /// <summary>
        /// Gets the symbol type corresponding to the given operator type.
        /// </summary>
        /// <param name="operatorType">
        /// The operator type to convert.
        /// </param>
        /// <returns>
        /// Returns the symbol type.
        /// </returns>
        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "The method is not complex.")]
        private static SymbolType SymbolTypeFromOperatorType(OperatorType operatorType)
        {
            Param.Ignore(operatorType);

            switch (operatorType)
            {
                case OperatorType.ConditionalEquals:
                    return SymbolType.ConditionalEquals;
                case OperatorType.NotEquals:
                    return SymbolType.NotEquals;
                case OperatorType.LessThan:
                    return SymbolType.LessThan;
                case OperatorType.GreaterThan:
                    return SymbolType.GreaterThan;
                case OperatorType.LessThanOrEquals:
                    return SymbolType.LessThanOrEquals;
                case OperatorType.GreaterThanOrEquals:
                    return SymbolType.GreaterThanOrEquals;
                case OperatorType.LogicalAnd:
                    return SymbolType.LogicalAnd;
                case OperatorType.LogicalOr:
                    return SymbolType.LogicalOr;
                case OperatorType.LogicalXor:
                    return SymbolType.LogicalXor;
                case OperatorType.ConditionalAnd:
                    return SymbolType.ConditionalAnd;
                case OperatorType.ConditionalOr:
                    return SymbolType.ConditionalOr;
                case OperatorType.NullCoalescingSymbol:
                    return SymbolType.NullCoalescingSymbol;
                case OperatorType.Equals:
                    return SymbolType.Equals;
                case OperatorType.PlusEquals:
                    return SymbolType.PlusEquals;
                case OperatorType.MinusEquals:
                    return SymbolType.MinusEquals;
                case OperatorType.MultiplicationEquals:
                    return SymbolType.MultiplicationEquals;
                case OperatorType.DivisionEquals:
                    return SymbolType.DivisionEquals;
                case OperatorType.LeftShiftEquals:
                    return SymbolType.LeftShiftEquals;
                case OperatorType.RightShiftEquals:
                    return SymbolType.RightShiftEquals;
                case OperatorType.AndEquals:
                    return SymbolType.AndEquals;
                case OperatorType.OrEquals:
                    return SymbolType.OrEquals;
                case OperatorType.XorEquals:
                    return SymbolType.XorEquals;
                case OperatorType.Plus:
                    return SymbolType.Plus;
                case OperatorType.Minus:
                    return SymbolType.Minus;
                case OperatorType.Multiplication:
                    return SymbolType.Multiplication;
                case OperatorType.Division:
                    return SymbolType.Division;
                case OperatorType.Mod:
                    return SymbolType.Mod;
                case OperatorType.ModEquals:
                    return SymbolType.ModEquals;
                case OperatorType.LeftShift:
                    return SymbolType.LeftShift;
                case OperatorType.RightShift:
                    return SymbolType.RightShift;
                case OperatorType.ConditionalColon:
                    return SymbolType.Colon;
                case OperatorType.ConditionalQuestionMark:
                    return SymbolType.QuestionMark;
                case OperatorType.Increment:
                    return SymbolType.Increment;
                case OperatorType.Decrement:
                    return SymbolType.Decrement;
                case OperatorType.Not:
                    return SymbolType.Not;
                case OperatorType.BitwiseCompliment:
                    return SymbolType.Tilde;
                case OperatorType.Positive:
                    return SymbolType.Plus;
                case OperatorType.Negative:
                    return SymbolType.Minus;
                case OperatorType.Dereference:
                    return SymbolType.Multiplication;
                case OperatorType.AddressOf:
                    return SymbolType.LogicalAnd;
                case OperatorType.Pointer:
                    return SymbolType.Pointer;
                case OperatorType.MemberAccess:
                    return SymbolType.Dot;
                case OperatorType.QualifiedAlias:
                    return SymbolType.QualifiedAlias;
                case OperatorType.Lambda:
                    return SymbolType.Lambda;
                case OperatorType.NullConditional:
                    return SymbolType.NullConditional;
                default:
                    Debug.Fail("Invalid operator type.");
                    throw new StyleCopException();
            }
        }

        /// <summary>
        /// Converts a symbol type to a token type.
        /// </summary>
        /// <param name="symbolType">
        /// The symbol type to convert.
        /// </param>
        /// <returns>
        /// Returns the token type.
        /// </returns>
        /// <remarks>
        /// This method should only be used for converting whitespace and comment symbol types.
        /// </remarks>
        private static CsTokenType TokenTypeFromSymbolType(SymbolType symbolType)
        {
            Param.Ignore(symbolType);

            switch (symbolType)
            {
                case SymbolType.WhiteSpace:
                    return CsTokenType.WhiteSpace;
                case SymbolType.EndOfLine:
                    return CsTokenType.EndOfLine;
                case SymbolType.SingleLineComment:
                    return CsTokenType.SingleLineComment;
                case SymbolType.MultiLineComment:
                    return CsTokenType.MultiLineComment;
                case SymbolType.PreprocessorDirective:
                    return CsTokenType.PreprocessorDirective;
                case SymbolType.XmlHeaderLine:
                    return CsTokenType.XmlHeaderLine;
                default:
                    Debug.Fail("This method should only be used for whitespace, comments, xml header lines, and preprocessors");
                    throw new StyleCopException();
            }
        }

        /// <summary>
        /// Converts an operator overload symbol.
        /// </summary>
        /// <param name="parentReference">
        /// The parent code part.
        /// </param>
        /// <returns>
        /// Returns the corresponding token.
        /// </returns>
        [SuppressMessage("Microsoft.Globalization", "CA1303:DoNotPassLiteralsAsLocalizedParameters", 
            MessageId = "StyleCop.CSharp.SymbolManager.Combine(System.Int32,System.Int32,System.String,StyleCop.CSharp.SymbolType)", 
            Justification = "The literal represents a C# operator and is not localizable.")]
        private CsToken ConvertOperatorOverloadSymbol(Reference<ICodePart> parentReference)
        {
            Param.AssertNotNull(parentReference, "parentReference");

            CsToken token = null;

            Symbol symbol = this.symbols.Peek(1);
            if (symbol != null)
            {
                if (symbol.SymbolType == SymbolType.GreaterThan)
                {
                    Symbol next = this.symbols.Peek(2);
                    if (next != null && next.SymbolType == SymbolType.GreaterThan)
                    {
                        // This could be a right-shift-equals.
                        next = this.symbols.Peek(3);
                        if (next != null && next.SymbolType == SymbolType.Equals)
                        {
                            // This is a right-shift-equals.
                            this.symbols.Combine(1, 3, ">>=", SymbolType.RightShiftEquals);
                        }
                        else
                        {
                            // This is a right-shift.
                            this.symbols.Combine(1, 2, ">>", SymbolType.RightShift);
                        }
                    }

                    symbol = this.symbols.Peek(1);
                    token = new CsToken(symbol.Text, CsTokenType.Other, symbol.Location, parentReference, this.symbols.Generated);
                    this.symbols.Advance();
                }
                else
                {
                    token = new CsToken(symbol.Text, CsTokenType.Other, symbol.Location, parentReference, this.symbols.Generated);
                    this.symbols.Advance();
                }
            }

            return token;
        }

        /// <summary>
        /// Converts a symbol to the given token type.
        /// </summary>
        /// <param name="symbol">
        /// The symbol to convert.
        /// </param>
        /// <param name="tokenType">
        /// The type of the token to retrieve.
        /// </param>
        /// <param name="parentReference">
        /// The parent code part.
        /// </param>
        /// <returns>
        /// Returns the token.
        /// </returns>
        private CsToken ConvertSymbol(Symbol symbol, CsTokenType tokenType, Reference<ICodePart> parentReference)
        {
            Param.AssertNotNull(symbol, "symbol");
            Param.Ignore(tokenType);
            Param.AssertNotNull(parentReference, "parentReference");

            // Create the appropriate token based on the type of the symbol.
            if (symbol.SymbolType == SymbolType.WhiteSpace)
            {
                Debug.Assert(tokenType == CsTokenType.WhiteSpace, "The token type is wrong.");
                return new Whitespace(symbol.Text, symbol.Location, parentReference, this.symbols.Generated);
            }
            else if (symbol.SymbolType == SymbolType.Number)
            {
                Debug.Assert(tokenType == CsTokenType.Number, "The token type is wrong.");
                return new Number(symbol.Text, symbol.Location, parentReference, this.symbols.Generated);
            }
            else if (symbol.SymbolType == SymbolType.PreprocessorDirective)
            {
                Debug.Assert(tokenType == CsTokenType.PreprocessorDirective, "The token type is wrong.");
                return this.GetPreprocessorDirectiveToken(symbol, parentReference, this.symbols.Generated);
            }
            else
            {
                // Brackets are created using the GetBracketToken method.
                Debug.Assert(symbol.SymbolType != SymbolType.OpenParenthesis, "Do not use this method for converting brackets.");
                Debug.Assert(symbol.SymbolType != SymbolType.CloseParenthesis, "Do not use this method for converting brackets.");
                Debug.Assert(symbol.SymbolType != SymbolType.OpenSquareBracket, "Do not use this method for converting brackets.");
                Debug.Assert(symbol.SymbolType != SymbolType.CloseSquareBracket, "Do not use this method for converting brackets.");
                Debug.Assert(symbol.SymbolType != SymbolType.OpenCurlyBracket, "Do not use this method for converting brackets.");
                Debug.Assert(symbol.SymbolType != SymbolType.CloseCurlyBracket, "Do not use this method for converting brackets.");
                Debug.Assert(symbol.SymbolType != SymbolType.Attribute, "Do not use this method for converting attributes.");

                return new CsToken(symbol.Text, tokenType, CsTokenClass.Token, symbol.Location, parentReference, this.symbols.Generated);
            }
        }

        /// <summary>
        /// Gets a bracket token of a specific type.
        /// </summary>
        /// <param name="tokenType">
        /// The type of the token to retrieve.
        /// </param>
        /// <param name="symbolType">
        /// The type of the symbol.
        /// </param>
        /// <param name="parentReference">
        /// The parent code unit.
        /// </param>
        /// <returns>
        /// Returns the token.
        /// </returns>
        private Bracket GetBracketToken(CsTokenType tokenType, SymbolType symbolType, Reference<ICodePart> parentReference)
        {
            Param.Ignore(tokenType);
            Param.Ignore(symbolType);
            Param.AssertNotNull(parentReference, "parentReference");

            Debug.Assert(
                tokenType == CsTokenType.OpenParenthesis || tokenType == CsTokenType.CloseParenthesis || tokenType == CsTokenType.OpenSquareBracket
                || tokenType == CsTokenType.CloseSquareBracket || tokenType == CsTokenType.OpenCurlyBracket || tokenType == CsTokenType.CloseCurlyBracket
                || tokenType == CsTokenType.OpenAttributeBracket || tokenType == CsTokenType.CloseAttributeBracket || tokenType == CsTokenType.OpenGenericBracket
                || tokenType == CsTokenType.CloseGenericBracket, 
                "The token type is not a bracket.");

            Symbol symbol = this.GetNextSymbol(symbolType, parentReference);
            this.symbols.Advance();

            return new Bracket(symbol.Text, tokenType, symbol.Location, parentReference, this.symbols.Generated);
        }

        /// <summary>
        /// Gets an operator token of a specific type.
        /// </summary>
        /// <param name="operatorType">
        /// The type of the operator token to retrieve.
        /// </param>
        /// <param name="parentReference">
        /// The parent code part.
        /// </param>
        /// <returns>
        /// Returns the token.
        /// </returns>
        private OperatorSymbol GetOperatorToken(OperatorType operatorType, Reference<ICodePart> parentReference)
        {
            Param.Ignore(operatorType);
            Param.AssertNotNull(parentReference, "parentReference");

            SymbolType symbolType = SymbolTypeFromOperatorType(operatorType);
            Symbol symbol = this.GetNextSymbol(symbolType, parentReference);

            OperatorSymbol token = CreateOperatorToken(symbol, parentReference, this.symbols.Generated);
            if (token == null || token.SymbolType != operatorType)
            {
                throw this.CreateSyntaxException();
            }

            this.symbols.Advance();

            return token;
        }

        /// <summary>
        /// Gets a token of a specific type.
        /// </summary>
        /// <param name="tokenType">
        /// The type of the token to retrieve.
        /// </param>
        /// <param name="symbolType">
        /// The type of the expected symbol.
        /// </param>
        /// <param name="parentReference">
        /// Reference to the parent code part.
        /// </param>
        /// <returns>
        /// Returns the token.
        /// </returns>
        private CsToken GetToken(CsTokenType tokenType, SymbolType symbolType, Reference<ICodePart> parentReference)
        {
            Param.Ignore(tokenType);
            Param.Ignore(symbolType);
            Param.AssertNotNull(parentReference, "parentReference");

            return this.GetToken(tokenType, symbolType, parentReference, parentReference);
        }

        /// <summary>
        /// Gets a token of a specific type.
        /// </summary>
        /// <param name="tokenType">
        /// The type of the token to retrieve.
        /// </param>
        /// <param name="symbolType">
        /// The type of the expected symbol.
        /// </param>
        /// <param name="parentReference">
        /// Reference to the parent code part.
        /// </param>
        /// <param name="tokenParentReference">
        /// Reference to the parent of the new token.
        /// </param>
        /// <returns>
        /// Returns the token.
        /// </returns>
        private CsToken GetToken(CsTokenType tokenType, SymbolType symbolType, Reference<ICodePart> parentReference, Reference<ICodePart> tokenParentReference)
        {
            Param.Ignore(tokenType);
            Param.Ignore(symbolType);
            Param.AssertNotNull(parentReference, "parentReference");
            Param.AssertNotNull(tokenParentReference, "tokenParentReference");

            // Determine whether to skip past all standard types, or whether we should stop when we get
            // to one of these types, if that is the type we're looking for.
            SkipSymbols skip = SkipSymbols.All;
            if (symbolType == SymbolType.WhiteSpace)
            {
                skip &= ~SkipSymbols.WhiteSpace;
            }
            else if (symbolType == SymbolType.EndOfLine)
            {
                skip &= ~SkipSymbols.EndOfLine;
            }
            else if (symbolType == SymbolType.SingleLineComment)
            {
                skip &= ~SkipSymbols.SingleLineComment;
            }
            else if (symbolType == SymbolType.MultiLineComment)
            {
                skip &= ~SkipSymbols.MultiLineComment;
            }
            else if (symbolType == SymbolType.PreprocessorDirective)
            {
                skip &= ~SkipSymbols.Preprocessor;
            }
            else if (symbolType == SymbolType.XmlHeaderLine)
            {
                skip &= ~SkipSymbols.XmlHeader;
            }

            // Get the next symbol.
            Symbol symbol = this.GetNextSymbol(symbolType, skip, parentReference);
            this.symbols.Advance();

            // Convert the symbol and return the token.
            return this.ConvertSymbol(symbol, tokenType, tokenParentReference);
        }

        /// <summary>
        /// Gets a token representing a type identifier.
        /// </summary>
        /// <param name="parentReference">
        /// The parent code unit.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code being parsed resides in an unsafe code block.
        /// </param>
        /// <param name="includeArrayBrackets">
        /// Indicates whether to include array brackets in the type token.
        /// </param>
        /// <returns>
        /// Returns the token.
        /// </returns>
        private TypeToken GetTypeToken(Reference<ICodePart> parentReference, bool unsafeCode, bool includeArrayBrackets)
        {
            Param.AssertNotNull(parentReference, "parentReference");
            Param.Ignore(unsafeCode);
            Param.Ignore(includeArrayBrackets);

            return this.GetTypeToken(parentReference, unsafeCode, includeArrayBrackets, false);
        }

        /// <summary>
        /// Gets a token representing a type identifier.
        /// </summary>
        /// <param name="parentReference">
        /// The parent code unit.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code being parsed resides in an unsafe code block.
        /// </param>
        /// <param name="includeArrayBrackets">
        /// Indicates whether to include array brackets in the type token.
        /// </param>
        /// <param name="isExpression">
        /// Indicates whether this type token comes at the end of an 'is' expression.
        /// </param>
        /// <returns>
        /// Returns the token.
        /// </returns>
        private TypeToken GetTypeToken(Reference<ICodePart> parentReference, bool unsafeCode, bool includeArrayBrackets, bool isExpression)
        {
            Param.AssertNotNull(parentReference, "parentReference");
            Param.Ignore(unsafeCode);
            Param.Ignore(includeArrayBrackets);
            Param.Ignore(isExpression);

            // Collect all tokens up to the first code token and make sure that this is of type Other.
            Symbol nextSymbol = this.GetNextSymbol(parentReference);

            Reference<ICodePart> typeTokenReference = new Reference<ICodePart>();

            // Get the type token.
            TypeToken token = null;

            if (nextSymbol.SymbolType == SymbolType.OpenParenthesis)
            {
                token = this.GetTupleTypeToken(typeTokenReference, parentReference, includeArrayBrackets, isExpression);
            }
            else if (nextSymbol.SymbolType == SymbolType.Other)
            {
                int endIndex;
                token = this.GetTypeTokenAux(typeTokenReference, parentReference, unsafeCode, includeArrayBrackets, isExpression, 1, out endIndex);
                if (token != null)
                {
                    this.symbols.CurrentIndex += endIndex;
                }
            }
            else
            {
                this.CreateSyntaxException();
            }

            return token;
        }

        /// <summary>
        /// Gets array brackets symbol for a type token, if they exist.
        /// </summary>
        /// <param name="typeTokenReference">
        /// A reference to the type token.
        /// </param>
        /// <param name="typeTokens">
        /// The tokens within the type token.
        /// </param>
        /// <param name="startIndex">
        /// The start index within the symbols.
        /// </param>
        private void GetTypeTokenArrayBrackets(Reference<ICodePart> typeTokenReference, MasterList<CsToken> typeTokens, ref int startIndex)
        {
            Param.AssertNotNull(typeTokenReference, "typeTokenReference");
            Param.AssertNotNull(typeTokens, "typeTokens");
            Param.AssertGreaterThanOrEqualToZero(startIndex, "startIndex");

            int index = this.GetNextCodeSymbolIndex(startIndex);
            if (index != -1)
            {
                Symbol symbol = this.symbols.Peek(index);
                if (symbol.SymbolType == SymbolType.OpenSquareBracket)
                {
                    // Add the tokens up to this point.
                    for (int i = startIndex; i <= index - 1; ++i)
                    {
                        Symbol symbolToConvert = this.symbols.Peek(startIndex);
                        typeTokens.Add(this.ConvertSymbol(symbolToConvert, TokenTypeFromSymbolType(symbolToConvert.SymbolType), typeTokenReference));

                        ++startIndex;
                    }

                    // Now collect the brackets.
                    Node<CsToken> openingBracketNode = null;
                    while (true)
                    {
                        symbol = this.symbols.Peek(startIndex);
                        if (symbol.SymbolType == SymbolType.WhiteSpace || symbol.SymbolType == SymbolType.EndOfLine || symbol.SymbolType == SymbolType.SingleLineComment
                            || symbol.SymbolType == SymbolType.MultiLineComment || symbol.SymbolType == SymbolType.PreprocessorDirective)
                        {
                            typeTokens.Add(this.ConvertSymbol(symbol, TokenTypeFromSymbolType(symbol.SymbolType), typeTokenReference));
                            ++startIndex;
                        }
                        else if (symbol.SymbolType == SymbolType.Number)
                        {
                            typeTokens.Add(this.ConvertSymbol(symbol, CsTokenType.Number, typeTokenReference));
                            ++startIndex;
                        }
                        else if (symbol.SymbolType == SymbolType.Other)
                        {
                            // Could be a constant or a reference to a constant.
                            typeTokens.Add(this.ConvertSymbol(symbol, CsTokenType.Other, typeTokenReference));
                            ++startIndex;
                        }
                        else if (symbol.SymbolType == SymbolType.Dot)
                        {
                            // Could be a dot in here like: int a[Constants.DefaultSize];
                            typeTokens.Add(this.ConvertSymbol(symbol, CsTokenType.Other, typeTokenReference));
                            ++startIndex;
                        }
                        else if (symbol.SymbolType == SymbolType.Comma)
                        {
                            typeTokens.Add(this.ConvertSymbol(symbol, CsTokenType.Comma, typeTokenReference));
                            ++startIndex;
                        }
                        else if (symbol.SymbolType == SymbolType.OpenSquareBracket)
                        {
                            if (openingBracketNode != null)
                            {
                                throw new SyntaxException(this.document.SourceCode, symbol.LineNumber);
                            }

                            Bracket openingBracket = new Bracket(symbol.Text, CsTokenType.OpenSquareBracket, symbol.Location, typeTokenReference, this.symbols.Generated);
                            openingBracketNode = typeTokens.InsertLast(openingBracket);
                            ++startIndex;
                        }
                        else if (symbol.SymbolType == SymbolType.CloseSquareBracket)
                        {
                            if (openingBracketNode == null)
                            {
                                throw new SyntaxException(this.document.SourceCode, symbol.LineNumber);
                            }

                            Bracket closingBracket = new Bracket(symbol.Text, CsTokenType.CloseSquareBracket, symbol.Location, typeTokenReference, this.symbols.Generated);
                            Node<CsToken> closingBracketNode = typeTokens.InsertLast(closingBracket);
                            ++startIndex;

                            ((Bracket)openingBracketNode.Value).MatchingBracketNode = closingBracketNode;
                            closingBracket.MatchingBracketNode = openingBracketNode;

                            openingBracketNode = null;

                            // Check whether the next character is another opening bracket.
                            int temp = this.GetNextCodeSymbolIndex(startIndex);
                            if (temp != -1 && this.symbols.Peek(temp).SymbolType != SymbolType.OpenSquareBracket)
                            {
                                break;
                            }
                        }
                        else
                        {
                            if (openingBracketNode != null)
                            {
                                throw new SyntaxException(this.document.SourceCode, symbol.LineNumber);
                            }

                            break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Gets a token representing a type identifier.
        /// </summary>
        /// <param name="typeTokenReference">
        /// A reference to the type token.
        /// </param>
        /// <param name="parentReference">
        /// The parent code unit.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code being parsed resides in an unsafe code block.
        /// </param>
        /// <param name="includeArrayBrackets">
        /// Indicates whether to include array brackets in the type token.
        /// </param>
        /// <param name="isExpression">
        /// Indicates whether this type token comes at the end of an 'is' expression.
        /// </param>
        /// <param name="startIndex">
        /// The start position in the symbol list of the first symbol in the type token.
        /// </param>
        /// <param name="endIndex">
        /// Returns the index of the last symbol in the type token.
        /// </param>
        /// <returns>
        /// Returns the token.
        /// </returns>
        private TypeToken GetTypeTokenAux(
            Reference<ICodePart> typeTokenReference, 
            Reference<ICodePart> parentReference, 
            bool unsafeCode, 
            bool includeArrayBrackets, 
            bool isExpression, 
            int startIndex, 
            out int endIndex)
        {
            Param.AssertNotNull(typeTokenReference, "typeTokenReference");
            Param.AssertNotNull(parentReference, "parentReference");
            Param.Ignore(unsafeCode);
            Param.Ignore(includeArrayBrackets);
            Param.Ignore(isExpression);
            Param.AssertGreaterThanOrEqualToZero(startIndex, "startIndex");

            // Get the next symbol and make sure it is an unknown word.
            Symbol symbol = this.symbols.Peek(startIndex);
            Debug.Assert(symbol != null && symbol.SymbolType == SymbolType.Other, "Expected a text symbol");

            // Create a token list to store all the tokens forming the type.
            MasterList<CsToken> typeTokens = new MasterList<CsToken>();

            // Get the name of the type token plus any generic symbols and types.
            GenericType generic;

            this.GetTypeTokenBaseName(typeTokenReference, ref typeTokens, ref startIndex, out generic, unsafeCode);

            bool allowNullableType = true;

            // Add dereference symbols if they exist.
            if (unsafeCode)
            {
                if (this.GetTypeTokenDereferenceSymbols(typeTokenReference, typeTokens, ref startIndex))
                {
                    allowNullableType = false;
                }
            }

            // Now look for the nullable type symbol, if needed.
            if (allowNullableType)
            {
                this.GetTypeTokenNullableTypeSymbol(typeTokenReference, typeTokens, isExpression, ref startIndex);
            }

            // Get the array brackets if they exist.
            if (includeArrayBrackets)
            {
                this.GetTypeTokenArrayBrackets(typeTokenReference, typeTokens, ref startIndex);
            }

            if (typeTokens.Count == 0)
            {
                throw this.CreateSyntaxException();
            }

            // Set the end index.
            endIndex = startIndex - 1;

            // If the type is a generic type, determine whether to just return the generic type directly.
            if (generic != null && typeTokens.Count == 1)
            {
                // This type is only composed of the generic type and nothing else. Just return the generic type.
                generic.ParentRef = parentReference;
                return generic;
            }

            // The type is either not generic, or else it is composed of a more complex type which includes a generic 
            // (for example, an array of a generic type). Return the more complex type.
            CodeLocation location = CsToken.JoinLocations(typeTokens.First, typeTokens.Last);
            TypeToken typeToken = new TypeToken(typeTokens, location, parentReference, this.symbols.Generated);
            typeTokenReference.Target = typeToken;

            return typeToken;
        }

        /// <summary>
        /// Gets the base name and generic symbols for a type token.
        /// </summary>
        /// <param name="typeTokenReference">
        /// A reference to the type token.
        /// </param>
        /// <param name="typeTokens">
        /// The list of tokens in the type.
        /// </param>
        /// <param name="startIndex">
        /// The start index within the symbol list.
        /// </param>
        /// <param name="generic">
        /// Returns a value indicating whether the type is generic.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the type is within a block of unsafe code.
        /// </param>
        private void GetTypeTokenBaseName(
            Reference<ICodePart> typeTokenReference, ref MasterList<CsToken> typeTokens, ref int startIndex, out GenericType generic, bool unsafeCode)
        {
            Param.AssertNotNull(typeTokenReference, "typeTokenReference");
            Param.AssertNotNull(typeTokens, "typeTokens");
            Param.AssertGreaterThanOrEqualToZero(startIndex, "startIndex");
            Param.Ignore(unsafeCode);

            generic = null;
            Symbol symbol = this.symbols.Peek(startIndex);

            // First get the full name of the type.
            int index = -1;
            while (true)
            {
                // Add any whitespace.
                while (symbol != null
                       && (symbol.SymbolType == SymbolType.WhiteSpace || symbol.SymbolType == SymbolType.EndOfLine || symbol.SymbolType == SymbolType.SingleLineComment
                           || symbol.SymbolType == SymbolType.MultiLineComment || symbol.SymbolType == SymbolType.PreprocessorDirective))
                {
                    typeTokens.Add(this.ConvertSymbol(symbol, TokenTypeFromSymbolType(symbol.SymbolType), typeTokenReference));
                    symbol = this.symbols.Peek(++startIndex);
                }

                // Add the next word. The type of the next word must either be an unknown
                // word type, which will be the name of the next item in the type, or else
                // it must be the 'this' keyword. This is used when implementing an explicit
                // interface member which is an indexer.
                if (symbol.SymbolType == SymbolType.Other || symbol.SymbolType == SymbolType.This)
                {
                    typeTokens.Add(new CsToken(symbol.Text, CsTokenType.Other, symbol.Location, typeTokenReference, this.symbols.Generated));
                }
                else
                {
                    throw new SyntaxException(this.document.SourceCode, symbol.LineNumber);
                }

                ++startIndex;

                // Look at the type of the next non-whitespace character.
                index = this.GetNextCodeSymbolIndex(startIndex);
                if (index == -1)
                {
                    break;
                }

                // If the next character is an opening generic bracket, get the generic.
                symbol = this.symbols.Peek(index);
                if (symbol.SymbolType == SymbolType.LessThan)
                {
                    int end;
                    MasterList<CsToken> genericTypeTokens = this.GetGenericArgumentList(typeTokenReference, unsafeCode, null, startIndex, out end);

                    if (genericTypeTokens != null)
                    {
                        // Add the tokens from this generic into our token list.
                        typeTokens.AddRange(genericTypeTokens);

                        // Create a new GenericTypeToken which represents this generic type.
                        CodeLocation genericTypeLocation = CsToken.JoinLocations(typeTokens.First, typeTokens.Last);
                        generic = new GenericType(typeTokens, genericTypeLocation, typeTokenReference, this.symbols.Generated);

                        Reference<ICodePart> genericReference = new Reference<ICodePart>(generic);
                        foreach (CsToken token in typeTokens)
                        {
                            token.ParentRef = genericReference;
                        }

                        // Reset the token list and add this generic token as the first item in the list.
                        typeTokens = new MasterList<CsToken>();
                        typeTokens.Add(generic);

                        // Advance the symbol index.
                        startIndex = end + 1;

                        // Look at the type of the next non-whitespace character.
                        index = this.GetNextCodeSymbolIndex(startIndex);
                        if (index == -1)
                        {
                            break;
                        }
                    }
                }

                // If the next character is not a dot or a qualified alias, break now.
                symbol = this.symbols.Peek(index);
                if (symbol.SymbolType != SymbolType.Dot && symbol.SymbolType != SymbolType.QualifiedAlias)
                {
                    break;
                }

                // Add any whitspace.
                symbol = this.symbols.Peek(startIndex);
                while (symbol != null
                       && (symbol.SymbolType == SymbolType.WhiteSpace || symbol.SymbolType == SymbolType.EndOfLine || symbol.SymbolType == SymbolType.SingleLineComment
                           || symbol.SymbolType == SymbolType.MultiLineComment || symbol.SymbolType == SymbolType.PreprocessorDirective))
                {
                    typeTokens.Add(this.ConvertSymbol(symbol, TokenTypeFromSymbolType(symbol.SymbolType), typeTokenReference));
                    symbol = this.symbols.Peek(++startIndex);
                }

                // Add the dot or qualified alias.
                if (symbol.SymbolType == SymbolType.Dot)
                {
                    typeTokens.Add(
                        new OperatorSymbol(
                            symbol.Text, OperatorCategory.Reference, OperatorType.MemberAccess, symbol.Location, typeTokenReference, this.symbols.Generated));
                }
                else
                {
                    Debug.Assert(symbol.SymbolType == SymbolType.QualifiedAlias, "Expected a qualified alias keyword");

                    typeTokens.Add(
                        new OperatorSymbol(
                            symbol.Text, OperatorCategory.Reference, OperatorType.QualifiedAlias, symbol.Location, typeTokenReference, this.symbols.Generated));
                }

                // Get the next symbol.
                symbol = this.symbols.Peek(++startIndex);
            }
        }

        /// <summary>
        /// Gets the dereference symbols from a type token.
        /// </summary>
        /// <param name="typeTokenReference">
        /// A reference to the type token.
        /// </param>
        /// <param name="typeTokens">
        /// The type tokens list.
        /// </param>
        /// <param name="startIndex">
        /// The start index within the symbols list.
        /// </param>
        /// <returns>
        /// Returns true if there were one or more dereference symbols.
        /// </returns>
        private bool GetTypeTokenDereferenceSymbols(Reference<ICodePart> typeTokenReference, MasterList<CsToken> typeTokens, ref int startIndex)
        {
            Param.AssertNotNull(typeTokenReference, "typeTokenReference");
            Param.AssertNotNull(typeTokens, "typeTokens");
            Param.AssertGreaterThanOrEqualToZero(startIndex, "startIndex");

            bool foundDereferenceSymbol = false;

            while (true)
            {
                // Look at the type of the next non-whitespace character.
                int index = this.GetNextCodeSymbolIndex(startIndex);
                if (index == -1)
                {
                    break;
                }

                // If the next character is not a deference, break now.
                Symbol symbol = this.symbols.Peek(index);
                if (symbol.SymbolType != SymbolType.Multiplication)
                {
                    break;
                }

                // Add any whitspace.
                symbol = this.symbols.Peek(startIndex);
                while (symbol != null
                       && (symbol.SymbolType == SymbolType.WhiteSpace || symbol.SymbolType == SymbolType.EndOfLine || symbol.SymbolType == SymbolType.SingleLineComment
                           || symbol.SymbolType == SymbolType.MultiLineComment || symbol.SymbolType == SymbolType.PreprocessorDirective))
                {
                    typeTokens.Add(this.ConvertSymbol(symbol, TokenTypeFromSymbolType(symbol.SymbolType), typeTokenReference));
                    symbol = this.symbols.Peek(++startIndex);
                }

                // Add the dereference symbol.
                typeTokens.Add(
                    new OperatorSymbol(symbol.Text, OperatorCategory.Reference, OperatorType.Dereference, symbol.Location, typeTokenReference, this.symbols.Generated));
                ++startIndex;

                // Nullable types are not allowed with dereferences.
                foundDereferenceSymbol = true;
            }

            return foundDereferenceSymbol;
        }

        /// <summary>
        /// Gets a token representing a tuple type.
        /// </summary>
        /// <param name="typeTokenReference">
        /// A reference to the type token.
        /// </param>
        /// <param name="parentReference">
        /// The parent code unit.
        /// </param>
        /// <param name="includeArrayBrackets">
        /// Indicates whether to include array brackets in the type token.
        /// </param>
        /// <param name="isExpression">
        /// Indicates whether this type token comes at the end of an 'is' expression.
        /// </param>
        /// <returns>A TypeToken representing the Tuple type.</returns>
        private TypeToken GetTupleTypeToken(Reference<ICodePart> typeTokenReference, Reference<ICodePart> parentReference, bool includeArrayBrackets, bool isExpression)
        {
            Param.AssertNotNull(typeTokenReference, nameof(typeTokenReference));
            Param.AssertNotNull(parentReference, nameof(parentReference));
            Param.Ignore(includeArrayBrackets);
            Param.Ignore(isExpression);

            // Create a token list to store all the tokens forming the type.
            MasterList<CsToken> typeTokens = new MasterList<CsToken>();

            Symbol symbol = this.GetNextSymbol(SkipSymbols.All, typeTokenReference);

            // Ensure that we read a open parenthesis.
            if (symbol.SymbolType != SymbolType.OpenParenthesis)
            {
                this.CreateSyntaxException();
            }

            typeTokens.Add(this.GetBracketToken(CsTokenType.OpenParenthesis, SymbolType.OpenParenthesis, typeTokenReference));
            int parenthesisCount = 1;
            
            while (true)
            {
                symbol = this.PeekNextSymbol(SkipSymbols.None, false);

                if (symbol.SymbolType == SymbolType.Other)
                {
                    typeTokens.Add(this.GetToken(CsTokenType.Other, SymbolType.Other, typeTokenReference));
                }
                else if (symbol.SymbolType == SymbolType.Comma)
                {
                    typeTokens.Add(this.GetToken(CsTokenType.Comma, SymbolType.Comma, typeTokenReference));
                }
                else if (symbol.SymbolType == SymbolType.OpenSquareBracket)
                {
                    typeTokens.Add(this.GetBracketToken(CsTokenType.OpenSquareBracket, SymbolType.OpenSquareBracket, typeTokenReference));
                }
                else if (symbol.SymbolType == SymbolType.CloseSquareBracket)
                {
                    typeTokens.Add(this.GetBracketToken(CsTokenType.CloseSquareBracket, SymbolType.CloseSquareBracket, typeTokenReference));
                }
                else if (symbol.SymbolType == SymbolType.LessThan)
                {
                    typeTokens.Add(this.GetBracketToken(CsTokenType.OpenGenericBracket, SymbolType.LessThan, typeTokenReference));
                }
                else if (symbol.SymbolType == SymbolType.GreaterThan)
                {
                    typeTokens.Add(this.GetBracketToken(CsTokenType.CloseGenericBracket, SymbolType.GreaterThan, typeTokenReference));
                }
                else if (symbol.SymbolType == SymbolType.WhiteSpace || symbol.SymbolType == SymbolType.EndOfLine || 
                         symbol.SymbolType == SymbolType.SingleLineComment || symbol.SymbolType == SymbolType.MultiLineComment 
                         || symbol.SymbolType == SymbolType.PreprocessorDirective)
                {
                    typeTokens.Add(this.GetToken(TokenTypeFromSymbolType(symbol.SymbolType), symbol.SymbolType, typeTokenReference));
                }
                else if (symbol.SymbolType == SymbolType.OpenParenthesis)
                {
                    typeTokens.Add(this.GetBracketToken(CsTokenType.OpenParenthesis, SymbolType.OpenParenthesis, typeTokenReference));
                    parenthesisCount++;
                }
                else if (symbol.SymbolType == SymbolType.CloseParenthesis)
                {
                    typeTokens.Add(this.GetBracketToken(CsTokenType.CloseParenthesis, SymbolType.CloseParenthesis, typeTokenReference));
                    parenthesisCount--;
                }
                else
                {
                    this.CreateSyntaxException();
                }

                if (parenthesisCount == 0)
                {
                    break;
                }
            }

            int startPosition = 1;

            this.GetTypeTokenNullableTypeSymbol(typeTokenReference, typeTokens, isExpression, ref startPosition);

            if (includeArrayBrackets)
            {
                // Read any array brackets and advance to the position of the last token read.
                this.GetTypeTokenArrayBrackets(typeTokenReference, typeTokens, ref startPosition);
                this.symbols.CurrentIndex += startPosition - 1;
            }

            if (typeTokens.Count == 0)
            {
                this.CreateSyntaxException();
            }

            CodeLocation location = CsToken.JoinLocations(typeTokens.First, typeTokens.Last);
            TypeToken typeToken = new TypeToken(typeTokens, location, parentReference, this.symbols.Generated);
            typeTokenReference.Target = typeToken;

            return typeToken;
        }

        /// <summary>
        /// Gets a token representing a type identifier.
        /// </summary>
        /// <param name="parentReference">
        /// The parent code unit.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code being parsed resides in an unsafe code block.
        /// </param>
        /// <param name="includeArrayBrackets">
        /// Indicates whether to include array brackets in the type token.
        /// </param>
        /// <returns>
        /// Returns the token.
        /// </returns>
        private LiteralExpression GetTypeTokenExpression(Reference<ICodePart> parentReference, bool unsafeCode, bool includeArrayBrackets)
        {
            Param.AssertNotNull(parentReference, "parentReference");
            Param.Ignore(unsafeCode);
            Param.Ignore(includeArrayBrackets);

            return this.GetTypeTokenExpression(parentReference, unsafeCode, includeArrayBrackets, false);
        }

        /// <summary>
        /// Gets a token representing a type identifier.
        /// </summary>
        /// <param name="parentReference">
        /// The parent code unit.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code being parsed resides in an unsafe code block.
        /// </param>
        /// <param name="includeArrayBrackets">
        /// Indicates whether to include array brackets in the type token.
        /// </param>
        /// <param name="isExpression">
        /// Indicates whether this type token comes at the end of an 'is' expression.
        /// </param>
        /// <returns>
        /// Returns the token.
        /// </returns>
        private LiteralExpression GetTypeTokenExpression(Reference<ICodePart> parentReference, bool unsafeCode, bool includeArrayBrackets, bool isExpression)
        {
            Param.AssertNotNull(parentReference, "parentReference");
            Param.Ignore(unsafeCode);
            Param.Ignore(includeArrayBrackets);
            Param.Ignore(isExpression);

            TypeToken token = this.GetTypeToken(parentReference, unsafeCode, includeArrayBrackets, isExpression);
            Node<CsToken> tokenNode = this.tokens.InsertLast(token);

            // Create a partial token list containing this token.
            CsTokenList partialTokenList = new CsTokenList(this.tokens, tokenNode, tokenNode);

            // Create and return the literal expression.
            return new LiteralExpression(partialTokenList, tokenNode);
        }

        /// <summary>
        /// Gets a <see cref="Nullable"/> type symbol for a type token, if one exists.
        /// </summary>
        /// <param name="typeTokenReference">
        /// A reference to the type token.
        /// </param>
        /// <param name="typeTokens">
        /// The tokens within the type token.
        /// </param>
        /// <param name="isExpression">
        /// Indicates whether this is in an is expression.
        /// </param>
        /// <param name="startIndex">
        /// The start index within the symbols.
        /// </param>
        private void GetTypeTokenNullableTypeSymbol(Reference<ICodePart> typeTokenReference, MasterList<CsToken> typeTokens, bool isExpression, ref int startIndex)
        {
            Param.AssertNotNull(typeTokenReference, "typeTokenReference");
            Param.AssertNotNull(typeTokens, "typeTokens");
            Param.Ignore(isExpression);
            Param.AssertGreaterThanOrEqualToZero(startIndex, "startIndex");

            // Look at the type of the next non-whitespace character and see if it is a nullable type symbol.
            int index = this.GetNextCodeSymbolIndex(startIndex);
            if (index == -1)
            {
                throw this.CreateSyntaxException();
            }

            Symbol symbol = this.symbols.Peek(index);
            if (symbol.SymbolType == SymbolType.QuestionMark)
            {
                // If this type token resides within an 'is' expression, check to make sure
                // that this is actually a nullable type symbol. In some cases, this can be a
                // conditional question mark, not a nullable type symbol.
                if (!isExpression || this.IsNullableTypeSymbolFromIsExpression(index))
                {
                    // Add any whitspace.
                    symbol = this.symbols.Peek(startIndex);
                    while (symbol != null
                           && (symbol.SymbolType == SymbolType.WhiteSpace || symbol.SymbolType == SymbolType.EndOfLine
                               || symbol.SymbolType == SymbolType.SingleLineComment || symbol.SymbolType == SymbolType.MultiLineComment
                               || symbol.SymbolType == SymbolType.PreprocessorDirective))
                    {
                        typeTokens.Add(this.ConvertSymbol(symbol, TokenTypeFromSymbolType(symbol.SymbolType), typeTokenReference));
                        symbol = this.symbols.Peek(++startIndex);
                    }

                    // Add the nullable type symbol.
                    typeTokens.Add(new CsToken(symbol.Text, CsTokenType.NullableTypeSymbol, symbol.Location, typeTokenReference, this.symbols.Generated));
                    ++startIndex;
                }
            }
        }

        /// <summary>
        /// Determines whether a question mark following the type from an 'is' or an 'as' statement is
        /// actually a <see cref="Nullable"/> type question mark rather than a conditional question mark.
        /// </summary>
        /// <param name="index">
        /// The peek index of the question mark within the symbol manager.
        /// </param>
        /// <returns>
        /// Returns true if the question mark is a <see cref="Nullable"/> type question mark.
        /// </returns>
        private bool IsNullableTypeSymbolFromIsExpression(int index)
        {
            Param.AssertGreaterThanZero(index, "index");

            // Get the index of the next code symbol after the question mark.
            index = this.GetNextCodeSymbolIndex(index + 1);
            Symbol nextSymbol = this.symbols.Peek(index);
            if (nextSymbol != null)
            {
                // The question mark can only be a nullable type symbol if the next symbol
                // in the document is a closing symbol (semicolon, comma, or closing bracket),
                // or an operator symbol (logical AND, logical OR, etc.), or an opening array bracket.
                SymbolType type = nextSymbol.SymbolType;
                if (type == SymbolType.CloseCurlyBracket || type == SymbolType.CloseParenthesis || type == SymbolType.CloseSquareBracket || type == SymbolType.Comma
                    || type == SymbolType.Semicolon || type == SymbolType.ConditionalAnd || type == SymbolType.ConditionalOr || type == SymbolType.ConditionalEquals
                    || type == SymbolType.NotEquals || type == SymbolType.QuestionMark || type == SymbolType.OpenSquareBracket)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            // There is no next symbol. A syntax error will soon ensue.
            return true;
        }

        #endregion
    }
}