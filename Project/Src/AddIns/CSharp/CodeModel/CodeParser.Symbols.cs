//-----------------------------------------------------------------------
// <copyright file="CodeParser.Symbols.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.
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
namespace Microsoft.StyleCop.CSharp.CodeModel
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Text;
    using System.Threading;
    using System.Xml;
    using Microsoft.StyleCop;

    /// <content>
    /// Contains code for parsing symbols within a C# code file.
    /// </content>
    internal partial class CodeParser
    {
        #region Private Static Methods

        /// <summary>
        /// Gets the type of the given operator symbol.
        /// </summary>
        /// <param name="symbol">The symbol to check.</param>
        /// <param name="type">Returns the operator type.</param>
        /// <param name="category">Returns the operator category.</param>
        /// <returns>Returns true if the symbol is an operator.</returns>
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

        /*
        /// <summary>
        /// Gets the symbol type corresponding to the given operator type.
        /// </summary>
        /// <param name="operatorType">The operator type to convert.</param>
        /// <returns>Returns the symbol type.</returns>
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
                default:
                    Debug.Fail("Invalid operator type.");
                    throw new StyleCopException();
            }
        }
        */

        #endregion Private Static Methods
        
        #region Private Methods

        /// <summary>
        /// Converts an operator overload symbol.
        /// </summary>
        /// <returns>Returns the corresponding token.</returns>
        [SuppressMessage(
            "Microsoft.Globalization", 
            "CA1303:DoNotPassLiteralsAsLocalizedParameters",
            MessageId = "Microsoft.StyleCop.CSharp.SymbolManager.Combine(System.Int32,System.Int32,System.String,Microsoft.StyleCop.CSharp.SymbolType)",
            Justification = "The literal represents a C# operator and is not localizable.")]
        private Token ConvertOperatorOverloadSymbol()
        {
            Token token = null;

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
                    token = new LiteralToken(this.document, symbol.Text, symbol.Location, this.symbols.Generated);
                    this.symbols.Advance();
                }
                else
                {
                    token = new LiteralToken(this.document, symbol.Text, symbol.Location, this.symbols.Generated);
                    this.symbols.Advance();
                }
            }

            return token;
        }

        /*
        /// <summary>
        /// Gets a lexical element of a specific type.
        /// </summary>
        /// <param name="parentProxy">Represents the parent item.</param>
        /// <param name="lexicalElementType">The type of the lexical element to retrieve.</param>
        /// <param name="symbolType">The type of the symbol.</param>
        /// <returns>Returns the token.</returns>
        private LexicalElement GetLexicalElement(CodeUnitProxy parentProxy, LexicalElementType lexicalElementType, SymbolType symbolType)
        {
            Param.AssertNotNull(parentProxy, "parentProxy");
            Param.Ignore(lexicalElementType);
            Param.Ignore(symbolType);

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

            this.AdvanceToNextCodeSymbol(parentProxy, skip);

            // Get the next symbol.
            Symbol symbol = this.PeekNextSymbol(skip);
            if (symbol.SymbolType != symbolType)
            {
                throw this.CreateSyntaxException();
            }

            this.symbols.Advance();

            // Convert the symbol and return the token.
            LexicalElement lexicalElement = this.ConvertLexicalSymbol(symbol, lexicalElementType);
            parentProxy.Children.Add(lexicalElement);

            return lexicalElement;
        }
        */

        /// <summary>
        /// Gets a token of a specific type.
        /// </summary>
        /// <param name="parentProxy">Represents the parent item.</param>
        /// <param name="tokenType">The type of the token to retrieve.</param>
        /// <param name="symbolType">The type of the expected symbol.</param>
        /// <returns>Returns the token.</returns>
        private Token GetToken(CodeUnitProxy parentProxy, TokenType tokenType, SymbolType symbolType)
        {
            Param.AssertNotNull(parentProxy, "parentProxy");
            Param.Ignore(tokenType);
            Param.Ignore(symbolType);

            this.AdvanceToNextCodeSymbol(parentProxy);

            // Get the next symbol.
            Symbol symbol = this.PeekNextSymbol();
            if (symbol.SymbolType != symbolType)
            {
                throw this.CreateSyntaxException();
            }
            
            this.symbols.Advance();

            // Convert the symbol and return the token.
            Token token = this.ConvertTokenSymbol(symbol, tokenType);
            parentProxy.Children.Add(token);

            return token;
        }

        /*
        /// <summary>
        /// Converts a symbol to the given comment type.
        /// </summary>
        /// <param name="symbol">The symbol to convert.</param>
        /// <param name="commentType">The type of comment to convert.</param>
        /// <returns>Returns the comment.</returns>
        private Comment ConvertSymbol(Symbol symbol, CommentType commentType)
        {
            Param.AssertNotNull(symbol, "symbol");
            Param.Ignore(commentType);

            // Create the appropriate token based on the type of the symbol.
            if (symbol.SymbolType == SymbolType.SingleLineComment)
            {
                Debug.Assert(commentType == CommentType.SingleLineComment, "The type is wrong.");
                return new SingleLineComment(symbol.Text, symbol.Location, this.symbols.Generated);
            }
            else if (symbol.SymbolType == SymbolType.MultiLineComment)
            {
                Debug.Assert(commentType == CommentType.MultilineComment, "The type is wrong.");
                return new MultilineComment(symbol.Text, symbol.Location, this.symbols.Generated);
            }
            else if (symbol.SymbolType == SymbolType.XmlHeaderLine)
            {
                Debug.Assert(commentType == CommentType.XmlHeaderLine, "The type is wrong.");
                return new XmlHeaderLine(symbol.Text, symbol.Location, this.symbols.Generated);
            }
            else
            {
                Debug.Fail("Invalid comment type");
                return null;
            }
        }
        */

        /*
        /// <summary>
        /// Converts a symbol to the given lexical element type.
        /// </summary>
        /// <param name="symbol">The symbol to convert.</param>
        /// <param name="lexicalElementType">The type of the lexical element to convert.</param>
        /// <returns>Returns the lexical element.</returns>
        private LexicalElement ConvertLexicalSymbol(Symbol symbol, LexicalElementType lexicalElementType)
        {
            Param.AssertNotNull(symbol, "symbol");
            Param.Ignore(lexicalElementType);

            // Create the appropriate token based on the type of the symbol.
            if (symbol.SymbolType == SymbolType.WhiteSpace)
            {
                Debug.Assert(lexicalElementType == LexicalElementType.WhiteSpace, "The type is wrong.");
                return new Whitespace(symbol.Text, symbol.Location, this.symbols.Generated);
            }
            else if (symbol.SymbolType == SymbolType.PreprocessorDirective)
            {
                Debug.Assert(lexicalElementType == LexicalElementType.PreprocessorDirective, "The type is wrong.");
                return this.PeekPreprocessorDirective(symbol, this.symbols.Generated);
            }
            else if (symbol.SymbolType == SymbolType.EndOfLine)
            {
                Debug.Assert(lexicalElementType == LexicalElementType.EndOfLine, "The type is wrong.");
                return new EndOfLine(symbol.Location, this.symbols.Generated);
            }
            else
            {
                Debug.Fail("Invalid Lexical element type");
                return null;
            }
        }
        */

        /// <summary>
        /// Converts a symbol to the given token type.
        /// </summary>
        /// <param name="symbol">The symbol to convert.</param>
        /// <param name="tokenType">The type of the token to retrieve.</param>
        /// <returns>Returns the token.</returns>
        [SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling", Justification = "The method is a factory.")]
        [SuppressMessage("Microsoft.Maintainability", "CA1505:AvoidUnmaintainableCode", Justification = "Complexity is due to simple switch statements.")]
        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Complexity is due to simple switch statements.")]
        private Token ConvertTokenSymbol(Symbol symbol, TokenType tokenType)
        {
            Param.AssertNotNull(symbol, "symbol");
            Param.Ignore(tokenType);

            switch (symbol.SymbolType)
            {
                case SymbolType.Abstract:
                    return new AbstractToken(this.document, symbol.Text, symbol.Location, this.symbols.Generated);
                case SymbolType.As:
                    return new AsToken(this.document, symbol.Text, symbol.Location, this.symbols.Generated);
                case SymbolType.Base:
                    return new BaseToken(this.document, symbol.Text, symbol.Location, this.symbols.Generated);
                case SymbolType.Break:
                    return new BreakToken(this.document, symbol.Text, symbol.Location, this.symbols.Generated);
                case SymbolType.Case:
                    return new CaseToken(this.document, symbol.Text, symbol.Location, this.symbols.Generated);
                case SymbolType.Catch:
                    return new CatchToken(this.document, symbol.Text, symbol.Location, this.symbols.Generated);
                case SymbolType.Checked:
                    return new CheckedToken(this.document, symbol.Text, symbol.Location, this.symbols.Generated);
                case SymbolType.Class:
                    return new ClassToken(this.document, symbol.Text, symbol.Location, this.symbols.Generated);
                case SymbolType.CloseCurlyBracket:
                    return new CloseCurlyBracketToken(this.document, symbol.Text, symbol.Location, this.symbols.Generated);
                case SymbolType.CloseParenthesis:
                    return new CloseParenthesisToken(this.document, symbol.Text, symbol.Location, this.symbols.Generated);
                case SymbolType.CloseSquareBracket:
                    return new CloseSquareBracketToken(this.document, symbol.Text, symbol.Location, this.symbols.Generated);
                case SymbolType.Colon:
                    switch (tokenType)
                    {
                        case TokenType.BaseColon:
                            return new BaseColonToken(this.document, symbol.Text, symbol.Location, this.symbols.Generated);
                        case TokenType.LabelColon:
                            return new LabelColonToken(this.document, symbol.Text, symbol.Location, this.symbols.Generated);
                        case TokenType.WhereColon:
                            return new WhereColonToken(this.document, symbol.Text, symbol.Location, this.symbols.Generated);
                    }

                    break;
                case SymbolType.Comma:
                    return new CommaToken(this.document, symbol.Text, symbol.Location, this.symbols.Generated);
                case SymbolType.Const:
                    return new ConstToken(this.document, symbol.Text, symbol.Location, this.symbols.Generated);
                case SymbolType.Continue:
                    return new ContinueToken(this.document, symbol.Text, symbol.Location, this.symbols.Generated);
                case SymbolType.Default:
                    if (tokenType == TokenType.DefaultValue)
                    {
                        return new DefaultValueToken(this.document, symbol.Text, symbol.Location, this.symbols.Generated);
                    }

                    return new DefaultToken(this.document, symbol.Text, symbol.Location, this.symbols.Generated);
                case SymbolType.Delegate:
                    return new DelegateToken(this.document, symbol.Text, symbol.Location, this.symbols.Generated);
                case SymbolType.Do:
                    return new DoToken(this.document, symbol.Text, symbol.Location, this.symbols.Generated);
                case SymbolType.Else:
                    return new ElseToken(this.document, symbol.Text, symbol.Location, this.symbols.Generated);
                case SymbolType.Enum:
                    return new EnumToken(this.document, symbol.Text, symbol.Location, this.symbols.Generated);
                case SymbolType.Equals:
                    if (tokenType == TokenType.Equals)
                    {
                        return new EqualsToken(this.document, symbol.Text, symbol.Location, this.symbols.Generated);
                    }

                    break;

                case SymbolType.Event:
                    return new EventToken(this.document, symbol.Text, symbol.Location, this.symbols.Generated);
                case SymbolType.Explicit:
                    return new ExplicitToken(this.document, symbol.Text, symbol.Location, this.symbols.Generated);
                case SymbolType.Extern:
                    if (tokenType == TokenType.ExternDirective)
                    {
                        return new ExternDirectiveToken(this.document, symbol.Text, symbol.Location, this.symbols.Generated);
                    }

                    return new ExternToken(this.document, symbol.Text, symbol.Location, this.symbols.Generated);
                case SymbolType.False:
                    return new FalseToken(this.document, symbol.Text, symbol.Location, this.symbols.Generated);
                case SymbolType.Finally:
                    return new FinallyToken(this.document, symbol.Text, symbol.Location, this.symbols.Generated);
                case SymbolType.Fixed:
                    return new FixedToken(this.document, symbol.Text, symbol.Location, this.symbols.Generated);
                case SymbolType.For:
                    return new ForToken(this.document, symbol.Text, symbol.Location, this.symbols.Generated);
                case SymbolType.Foreach:
                    return new ForeachToken(this.document, symbol.Text, symbol.Location, this.symbols.Generated);
                case SymbolType.Goto:
                    return new GotoToken(this.document, symbol.Text, symbol.Location, this.symbols.Generated);
                case SymbolType.If:
                    return new IfToken(this.document, symbol.Text, symbol.Location, this.symbols.Generated);
                case SymbolType.Implicit:
                    return new ImplicitToken(this.document, symbol.Text, symbol.Location, this.symbols.Generated);
                case SymbolType.In:
                    return new InToken(this.document, symbol.Text, symbol.Location, this.symbols.Generated);
                case SymbolType.Interface:
                    return new InterfaceToken(this.document, symbol.Text, symbol.Location, this.symbols.Generated);
                case SymbolType.Internal:
                    return new InternalToken(this.document, symbol.Text, symbol.Location, this.symbols.Generated);
                case SymbolType.Is:
                    return new IsToken(this.document, symbol.Text, symbol.Location, this.symbols.Generated);
                case SymbolType.Lock:
                    return new LockToken(this.document, symbol.Text, symbol.Location, this.symbols.Generated);
                case SymbolType.Namespace:
                    return new NamespaceToken(this.document, symbol.Text, symbol.Location, this.symbols.Generated);
                case SymbolType.New:
                    return new NewToken(this.document, symbol.Text, symbol.Location, this.symbols.Generated);
                case SymbolType.Null:
                    return new NullToken(this.document, symbol.Text, symbol.Location, this.symbols.Generated);
                case SymbolType.Number:
                    return new NumberToken(this.document, symbol.Text, symbol.Location, this.symbols.Generated);
                case SymbolType.OpenCurlyBracket:
                    return new OpenCurlyBracketToken(this.document, symbol.Text, symbol.Location, this.symbols.Generated);
                case SymbolType.OpenParenthesis:
                    return new OpenParenthesisToken(this.document, symbol.Text, symbol.Location, this.symbols.Generated);
                case SymbolType.OpenSquareBracket:
                    return new OpenSquareBracketToken(this.document, symbol.Text, symbol.Location, this.symbols.Generated);
                case SymbolType.Operator:
                    return new OperatorToken(this.document, symbol.Text, symbol.Location, this.symbols.Generated);
                case SymbolType.Other:
                    switch (tokenType)
                    {
                        case TokenType.Add:
                            return new AddToken(this.document, symbol.Text, symbol.Location, this.symbols.Generated);
                        case TokenType.Alias:
                            return new AliasToken(this.document, symbol.Text, symbol.Location, this.symbols.Generated);
                        case TokenType.Ascending:
                            return new AscendingToken(this.document, symbol.Text, symbol.Location, this.symbols.Generated);
                        case TokenType.By:
                            return new ByToken(this.document, symbol.Text, symbol.Location, this.symbols.Generated);
                        case TokenType.Descending:
                            return new DescendingToken(this.document, symbol.Text, symbol.Location, this.symbols.Generated);
                        case TokenType.Equals:
                            return new EqualsToken(this.document, symbol.Text, symbol.Location, this.symbols.Generated);
                        case TokenType.From:
                            return new FromToken(this.document, symbol.Text, symbol.Location, this.symbols.Generated);
                        case TokenType.Get:
                            return new GetToken(this.document, symbol.Text, symbol.Location, this.symbols.Generated);
                        case TokenType.Group:
                            return new GroupToken(this.document, symbol.Text, symbol.Location, this.symbols.Generated);
                        case TokenType.Into:
                            return new IntoToken(this.document, symbol.Text, symbol.Location, this.symbols.Generated);
                        case TokenType.Join:
                            return new JoinToken(this.document, symbol.Text, symbol.Location, this.symbols.Generated);
                        case TokenType.Let:
                            return new LetToken(this.document, symbol.Text, symbol.Location, this.symbols.Generated);
                        case TokenType.Literal:
                            return new LiteralToken(this.document, symbol.Text, symbol.Location, this.symbols.Generated);
                        case TokenType.On:
                            return new OnToken(this.document, symbol.Text, symbol.Location, this.symbols.Generated);
                        case TokenType.OrderBy:
                            return new OrderByToken(this.document, symbol.Text, symbol.Location, this.symbols.Generated);
                        case TokenType.Partial:
                            return new PartialToken(this.document, symbol.Text, symbol.Location, this.symbols.Generated);
                        case TokenType.Remove:
                            return new RemoveToken(this.document, symbol.Text, symbol.Location, this.symbols.Generated);
                        case TokenType.Select:
                            return new SelectToken(this.document, symbol.Text, symbol.Location, this.symbols.Generated);
                        case TokenType.Set:
                            return new SetToken(this.document, symbol.Text, symbol.Location, this.symbols.Generated);
                        case TokenType.Where:
                            return new WhereToken(this.document, symbol.Text, symbol.Location, this.symbols.Generated);
                        case TokenType.Yield:
                            return new YieldToken(this.document, symbol.Text, symbol.Location, this.symbols.Generated);
                    }

                    break;
                case SymbolType.Out:
                    return new OutToken(this.document, symbol.Text, symbol.Location, this.symbols.Generated);
                case SymbolType.Override:
                    return new OverrideToken(this.document, symbol.Text, symbol.Location, this.symbols.Generated);
                case SymbolType.Params:
                    return new ParamsToken(this.document, symbol.Text, symbol.Location, this.symbols.Generated);
                case SymbolType.Private:
                    return new PrivateToken(this.document, symbol.Text, symbol.Location, this.symbols.Generated);
                case SymbolType.Protected:
                    return new ProtectedToken(this.document, symbol.Text, symbol.Location, this.symbols.Generated);
                case SymbolType.Public:
                    return new PublicToken(this.document, symbol.Text, symbol.Location, this.symbols.Generated);
                case SymbolType.Readonly:
                    return new ReadonlyToken(this.document,  symbol.Text, symbol.Location, this.symbols.Generated);
                case SymbolType.Ref:
                    return new RefToken(this.document, symbol.Text, symbol.Location, this.symbols.Generated);
                case SymbolType.Return:
                    return new ReturnToken(this.document, symbol.Text, symbol.Location, this.symbols.Generated);
                case SymbolType.Sealed:
                    return new SealedToken(this.document, symbol.Text, symbol.Location, this.symbols.Generated);
                case SymbolType.Semicolon:
                    return new SemicolonToken(this.document, symbol.Text, symbol.Location, this.symbols.Generated);
                case SymbolType.Sizeof:
                    return new SizeofToken(this.document, symbol.Text, symbol.Location, this.symbols.Generated);
                case SymbolType.Stackalloc:
                    return new StackallocToken(this.document, symbol.Text, symbol.Location, this.symbols.Generated);
                case SymbolType.Static:
                    return new StaticToken(this.document, symbol.Text, symbol.Location, this.symbols.Generated);
                case SymbolType.String:
                    return new StringToken(this.document, symbol.Text, symbol.Location, this.symbols.Generated);
                case SymbolType.Struct:
                    return new StructToken(this.document, symbol.Text, symbol.Location, this.symbols.Generated);
                case SymbolType.Switch:
                    return new SwitchToken(this.document, symbol.Text, symbol.Location, this.symbols.Generated);
                case SymbolType.This:
                    return new ThisToken(this.document, symbol.Text, symbol.Location, this.symbols.Generated);
                case SymbolType.Throw:
                    return new ThrowToken(this.document, symbol.Text, symbol.Location, this.symbols.Generated);
                case SymbolType.Tilde:
                    if (tokenType == TokenType.DestructorTilde)
                    {
                        return new DestructorTildeToken(this.document, symbol.Text, symbol.Location, this.symbols.Generated);
                    }

                    break;

                case SymbolType.True:
                    return new TrueToken(this.document, symbol.Text, symbol.Location, this.symbols.Generated);
                case SymbolType.Try:
                    return new TryToken(this.document, symbol.Text, symbol.Location, this.symbols.Generated);
                case SymbolType.Typeof:
                    return new TypeofToken(this.document, symbol.Text, symbol.Location, this.symbols.Generated);
                case SymbolType.Unchecked:
                    return new UncheckedToken(this.document, symbol.Text, symbol.Location, this.symbols.Generated);
                case SymbolType.Unsafe:
                    return new UnsafeToken(this.document, symbol.Text, symbol.Location, this.symbols.Generated);
                case SymbolType.Using:
                    if (tokenType == TokenType.UsingDirective)
                    {
                        return new UsingDirectiveToken(this.document, symbol.Text, symbol.Location, this.symbols.Generated);
                    }

                    return new UsingToken(this.document, symbol.Text, symbol.Location, this.symbols.Generated);
                case SymbolType.Virtual:
                    return new VirtualToken(this.document, symbol.Text, symbol.Location, this.symbols.Generated);
                case SymbolType.Volatile:
                    return new VolatileToken(this.document, symbol.Text, symbol.Location, this.symbols.Generated);
                case SymbolType.While:
                    if (tokenType == TokenType.WhileDo)
                    {
                        return new WhileDoToken(this.document, symbol.Text, symbol.Location, this.symbols.Generated);
                    }

                    return new WhileToken(this.document, symbol.Text, symbol.Location, this.symbols.Generated);
            }

            Debug.Fail("Cannot create a token of the given symbol type using this method.");
            return null;
        }

        /// <summary>
        /// Gets an operator token of a specific type.
        /// </summary>
        /// <param name="parentProxy">Proxy object for the parent item.</param>
        /// <returns>Returns the token.</returns>
        private OperatorSymbolToken GetOperatorSymbolToken(CodeUnitProxy parentProxy)
        {
            Param.AssertNotNull(parentProxy, "parentProxy");
            this.AdvanceToNextCodeSymbol(parentProxy);

            OperatorSymbolToken operatorToken = this.PeekOperatorSymbolToken();

            // Advance past the operator symbol.
            this.symbols.Advance();

            parentProxy.Children.Add(operatorToken);
            return operatorToken;
        }

        /// <summary>
        /// Gets an operator token of a specific type.
        /// </summary>
        /// <param name="parentProxy">Represents the parent item.</param>
        /// <param name="operatorType">The type of the operator token to retrieve.</param>
        /// <returns>Returns the token.</returns>
        private OperatorSymbolToken GetOperatorSymbolToken(CodeUnitProxy parentProxy, OperatorType operatorType)
        {
            Param.AssertNotNull(parentProxy, "parentProxy");
            Param.Ignore(operatorType);

            OperatorSymbolToken operatorToken = this.GetOperatorSymbolToken(parentProxy);
            if (operatorToken == null || operatorToken.SymbolType != operatorType)
            {
                throw this.CreateSyntaxException();
            }

            return operatorToken;
        }

        /// <summary>
        /// Reads an operator token.
        /// </summary>
        /// <returns>Returns the token.</returns>
        private OperatorSymbolToken PeekOperatorSymbolToken()
        {
            // Get the operator symbol.
            Symbol operatorSymbol = this.PeekNextSymbol();

            // Convert it to a token.
            OperatorSymbolToken operatorToken = this.CreateOperatorSymbolToken(operatorSymbol, this.symbols.Generated);
            if (operatorToken == null)
            {
                throw this.CreateSyntaxException();
            }

            return operatorToken;
        }

        /// <summary>
        /// Creates an operator token from the given symbol.
        /// </summary>
        /// <param name="symbol">The symbol to convert.</param>
        /// <param name="generated">Indicates whether the symbol lies within a generated code block.</param>
        /// <returns>Returns the operator symbol.</returns>
        [SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling", Justification = "The method is a factory.")]
        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Complexity is due to simple switch statements.")]
        private OperatorSymbolToken CreateOperatorSymbolToken(Symbol symbol, bool generated)
        {
            Param.AssertNotNull(symbol, "symbol");
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

            // Create the appropriate operator token based on the type.
            switch (type)
            {
                case OperatorType.AddressOf:
                    return new AddressOfOperator(this.document, symbol.Text, symbol.Location, generated);
                case OperatorType.AndEquals:
                    return new AndEqualsOperator(this.document, symbol.Text, symbol.Location, generated);
                case OperatorType.BitwiseCompliment:
                    return new BitwiseComplementOperator(this.document, symbol.Text, symbol.Location, generated);
                case OperatorType.ConditionalAnd:
                    return new ConditionalAndOperator(this.document, symbol.Text, symbol.Location, generated);
                case OperatorType.ConditionalColon:
                    return new ConditionalColonOperator(this.document, symbol.Text, symbol.Location, generated);
                case OperatorType.ConditionalEquals:
                    return new ConditionalEqualsOperator(this.document, symbol.Text, symbol.Location, generated);
                case OperatorType.ConditionalOr:
                    return new ConditionalOrOperator(this.document, symbol.Text, symbol.Location, generated);
                case OperatorType.ConditionalQuestionMark:
                    return new ConditionalQuestionMarkOperator(this.document, symbol.Text, symbol.Location, generated);
                case OperatorType.Decrement:
                    return new DecrementOperator(this.document, symbol.Text, symbol.Location, generated);
                case OperatorType.Dereference:
                    return new DereferenceOperator(this.document, symbol.Text, symbol.Location, generated);
                case OperatorType.Division:
                    return new DivisionOperator(this.document, symbol.Text, symbol.Location, generated);
                case OperatorType.DivisionEquals:
                    return new DivisionEqualsOperator(this.document, symbol.Text, symbol.Location, generated);
                case OperatorType.Equals:
                    return new EqualsOperator(this.document, symbol.Text, symbol.Location, generated);
                case OperatorType.GreaterThan:
                    return new GreaterThanOperator(this.document, symbol.Text, symbol.Location, generated);
                case OperatorType.GreaterThanOrEquals:
                    return new GreaterThanOrEqualsOperator(this.document, symbol.Text, symbol.Location, generated);
                case OperatorType.Increment:
                    return new IncrementOperator(this.document, symbol.Text, symbol.Location, generated);
                case OperatorType.Lambda:
                    return new LambdaOperator(this.document, symbol.Text, symbol.Location, generated);
                case OperatorType.LeftShift:
                    return new LeftShiftOperator(this.document, symbol.Text, symbol.Location, generated);
                case OperatorType.LeftShiftEquals:
                    return new LeftShiftEqualsOperator(this.document, symbol.Text, symbol.Location, generated);
                case OperatorType.LessThan:
                    return new LessThanOperator(this.document, symbol.Text, symbol.Location, generated);
                case OperatorType.LessThanOrEquals:
                    return new LessThanOrEqualsOperator(this.document, symbol.Text, symbol.Location, generated);
                case OperatorType.LogicalAnd:
                    return new LogicalAndOperator(this.document, symbol.Text, symbol.Location, generated);
                case OperatorType.LogicalOr:
                    return new LogicalOrOperator(this.document, symbol.Text, symbol.Location, generated);
                case OperatorType.LogicalXor:
                    return new LogicalXorOperator(this.document, symbol.Text, symbol.Location, generated);
                case OperatorType.MemberAccess:
                    return new MemberAccessOperator(this.document, symbol.Text, symbol.Location, generated);
                case OperatorType.Minus:
                    return new MinusOperator(this.document, symbol.Text, symbol.Location, generated);
                case OperatorType.MinusEquals:
                    return new MinusEqualsOperator(this.document, symbol.Text, symbol.Location, generated);
                case OperatorType.Mod:
                    return new ModOperator(this.document, symbol.Text, symbol.Location, generated);
                case OperatorType.ModEquals:
                    return new ModEqualsOperator(this.document, symbol.Text, symbol.Location, generated);
                case OperatorType.Multiplication:
                    return new MultiplicationOperator(this.document, symbol.Text, symbol.Location, generated);
                case OperatorType.MultiplicationEquals:
                    return new MultiplicationEqualsOperator(this.document, symbol.Text, symbol.Location, generated);
                case OperatorType.Negative:
                    return new NegativeOperator(this.document, symbol.Text, symbol.Location, generated);
                case OperatorType.Not:
                    return new NotOperator(this.document, symbol.Text, symbol.Location, generated);
                case OperatorType.NotEquals:
                    return new NotEqualsOperator(this.document, symbol.Text, symbol.Location, generated);
                case OperatorType.NullCoalescingSymbol:
                    return new NullCoalescingSymbolOperator(this.document, symbol.Text, symbol.Location, generated);
                case OperatorType.OrEquals:
                    return new OrEqualsOperator(this.document, symbol.Text, symbol.Location, generated);
                case OperatorType.Plus:
                    return new PlusOperator(this.document, symbol.Text, symbol.Location, generated);
                case OperatorType.PlusEquals:
                    return new PlusEqualsOperator(this.document, symbol.Text, symbol.Location, generated);
                case OperatorType.Pointer:
                    return new PointerOperator(this.document, symbol.Text, symbol.Location, generated);
                case OperatorType.Positive:
                    return new PositiveOperator(this.document, symbol.Text, symbol.Location, generated);
                case OperatorType.QualifiedAlias:
                    return new QualifiedAliasOperator(this.document, symbol.Text, symbol.Location, generated);
                case OperatorType.RightShift:
                    return new RightShiftOperator(this.document, symbol.Text, symbol.Location, generated);
                case OperatorType.RightShiftEquals:
                    return new RightShiftEqualsOperator(this.document, symbol.Text, symbol.Location, generated);
                case OperatorType.XorEquals:
                    return new XorEqualsOperator(this.document, symbol.Text, symbol.Location, generated);
                default:
                    Debug.Fail("Invalid operator type");
                    return null;
            }
        }

        /// <summary>
        /// Gets a token representing a type identifier.
        /// </summary>
        /// <param name="parentProxy">Represents the parent item.</param>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <param name="includeArrayBrackets">Indicates whether to include array brackets in the type token.</param>
        /// <returns>Returns the token.</returns>
        private TypeToken GetTypeToken(CodeUnitProxy parentProxy, bool unsafeCode, bool includeArrayBrackets)
        {
            Param.Ignore(parentProxy);
            Param.Ignore(unsafeCode);
            Param.Ignore(includeArrayBrackets);

            return this.GetTypeToken(parentProxy, unsafeCode, includeArrayBrackets, false);
        }

        /// <summary>
        /// Gets a token representing a type identifier.
        /// </summary>
        /// <param name="parentProxy">Represents the parent item.</param>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <param name="includeArrayBrackets">Indicates whether to include array brackets in the type token.</param>
        /// <param name="isExpression">Indicates whether this type token comes at the end of an 'is' expression.</param>
        /// <returns>Returns the token.</returns>
        private TypeToken GetTypeToken(CodeUnitProxy parentProxy, bool unsafeCode, bool includeArrayBrackets, bool isExpression)
        {
            Param.Ignore(parentProxy);
            Param.Ignore(unsafeCode);
            Param.Ignore(includeArrayBrackets);
            Param.Ignore(isExpression);

            // Collect all tokens up to the first code token and make sure that this is of type Other.
            Symbol symbol = this.PeekNextSymbol();
            if (symbol.SymbolType != SymbolType.Other)
            {
                throw this.CreateSyntaxException();
            }

            // If there is no parent proxy then an assumption is made that the symbol pointer is already advanced
            // to the start of the token.
            if (parentProxy != null)
            {
                this.AdvanceToNextCodeSymbol(parentProxy);
            }

            // Get the type token.
            int endIndex;
            TypeToken token = this.GetTypeTokenAux(unsafeCode, includeArrayBrackets, isExpression, 1, out endIndex);
            if (token != null)
            {
                this.symbols.CurrentIndex += endIndex;
            }

            if (parentProxy != null)
            {
                parentProxy.Children.Add(token);
            }

            return token;
        }

        /// <summary>
        /// Gets a token representing a type identifier.
        /// </summary>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <param name="includeArrayBrackets">Indicates whether to include array brackets in the type token.</param>
        /// <param name="isExpression">Indicates whether this type token comes at the end of an 'is' expression.</param>
        /// <param name="startIndex">The start position in the symbol list of the first symbol in the type token.</param>
        /// <param name="endIndex">Returns the index of the last symbol in the type token.</param>
        /// <returns>Returns the token.</returns>
        private TypeToken GetTypeTokenAux(bool unsafeCode, bool includeArrayBrackets, bool isExpression, int startIndex, out int endIndex)
        {
            Param.Ignore(unsafeCode);
            Param.Ignore(includeArrayBrackets);
            Param.Ignore(isExpression);
            Param.AssertGreaterThanOrEqualToZero(startIndex, "startIndex");

            // Get the next symbol and make sure it is an unknown word.
            Symbol symbol = this.symbols.Peek(startIndex);
            Debug.Assert(symbol != null && symbol.SymbolType == SymbolType.Other, "Expected a text symbol");

            var typeTokenProxy = new CodeUnitProxy(this.document);

            // Get the name of the type token plus any generic symbols and types.
            GenericTypeToken generic;
            this.GetTypeTokenBaseName(ref typeTokenProxy, ref startIndex, out generic, unsafeCode);

            bool allowNullableType = true;

            // Add dereference symbols if they exist.
            if (unsafeCode)
            {
                if (this.GetTypeTokenDereferenceSymbols(typeTokenProxy, ref startIndex))
                {
                    allowNullableType = false;
                }
            }

            // Now look for the nullable type symbol, if needed.
            if (allowNullableType)
            {
                this.GetTypeTokenNullableTypeSymbol(typeTokenProxy, isExpression, ref startIndex);
            }

            // Get the array brackets if they exist.
            if (includeArrayBrackets)
            {
                this.GetTypeTokenArrayBrackets(typeTokenProxy, ref startIndex);
            }

            if (typeTokenProxy.Children.Count == 0)
            {
                throw this.CreateSyntaxException();
            }

            // Set the end index.
            endIndex = startIndex - 1;

            // If the type is a generic type, determine whether to just return the generic type directly.
            if (generic != null && typeTokenProxy.Children.Count == 1)
            {
                generic.Detach();
                return generic;
            }

            // The type is either not generic, or else it is composed of a more complex type which includes a generic 
            // (for example, an array of a generic type). Return the more complex type.
            return new TypeToken(typeTokenProxy);
        }

        /// <summary>
        /// Gets the base name and generic symbols for a type token.
        /// </summary>
        /// <param name="typeTokenProxy">Proxy object for the TypeToken being created.</param>
        /// <param name="startIndex">The start index within the symbol list.</param>
        /// <param name="generic">Returns a value indicating whether the type is generic.</param>
        /// <param name="unsafeCode">Indicates whether the type is within a block of unsafe code.</param>
        private void GetTypeTokenBaseName(ref CodeUnitProxy typeTokenProxy, ref int startIndex, out GenericTypeToken generic, bool unsafeCode)
        {
            Param.AssertNotNull(typeTokenProxy, "typeTokenProxy");
            Param.AssertGreaterThanOrEqualToZero(startIndex, "startIndex");
            Param.Ignore(unsafeCode);

            generic = null;
            Symbol symbol = this.symbols.Peek(startIndex);

            // First get the full name of the type.
            int index = -1;
            while (true)
            {
                this.GatherNonTokenSymbols(typeTokenProxy, ref startIndex);
                symbol = this.symbols.Peek(startIndex);

                // Add the next word. The type of the next word must either be an unknown
                // word type, which will be the name of the next item in the type, or else
                // it must be the 'this' keyword. This is used when implementing an explicit
                // interface member which is an indexer.
                if (symbol.SymbolType == SymbolType.Other || symbol.SymbolType == SymbolType.This)
                {
                    typeTokenProxy.Children.Add(new LiteralToken(this.document, symbol.Text, symbol.Location, this.symbols.Generated));
                }
                else
                {
                    throw new SyntaxException(this.document, symbol.LineNumber);
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
                    if (this.GetGenericArgumentList(typeTokenProxy, unsafeCode, null, startIndex, out end))
                    {
                        // Create a new GenericTypeToken which represents this generic type.
                        generic = new GenericTypeToken(typeTokenProxy);

                        // Reset the token list and add this generic token as the first item in the list.
                        typeTokenProxy = new CodeUnitProxy(this.document);
                        typeTokenProxy.Children.Add(generic);

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
                this.GatherNonTokenSymbols(typeTokenProxy, ref startIndex);
                symbol = this.symbols.Peek(startIndex);

                // Add the dot or qualified alias.
                if (symbol.SymbolType == SymbolType.Dot)
                {
                    typeTokenProxy.Children.Add(new MemberAccessOperator(this.document, symbol.Text, symbol.Location, this.symbols.Generated));
                }
                else
                {
                    Debug.Assert(symbol.SymbolType == SymbolType.QualifiedAlias, "Expected a qualified alias keyword");
                    typeTokenProxy.Children.Add(new QualifiedAliasOperator(this.document, symbol.Text, symbol.Location, this.symbols.Generated));
                }

                // Get the next symbol.
                symbol = this.symbols.Peek(++startIndex);
            }
        }

        /// <summary>
        /// Gets all non-Token symbols starting at the given index.
        /// </summary>
        /// <param name="typeTokenProxy">Proxy object for the TypeToken being created.</param>
        /// <param name="startIndex">The start index within the symbols collection.</param>
        private void GatherNonTokenSymbols(CodeUnitProxy typeTokenProxy, ref int startIndex)
        {
            Param.AssertNotNull(typeTokenProxy, "typeTokenProxy");
            Param.Ignore(startIndex);

            Symbol symbol = this.symbols.Peek(startIndex);
            while (symbol != null)
            {
                if (!this.GatherNonTokenSymbol(typeTokenProxy, symbol))
                {
                    break;
                }

                symbol = this.symbols.Peek(++startIndex);
            }
        }

        /// <summary>
        /// Gets the next non-Token symbol.
        /// </summary>
        /// <param name="typeTokenProxy">Proxy object for the TypeToken being created.</param>
        /// <param name="symbol">The current symbol.</param>
        /// <returns>Returns the non-Token symbol.</returns>
        private bool GatherNonTokenSymbol(CodeUnitProxy typeTokenProxy, Symbol symbol)
        {
            Param.AssertNotNull(typeTokenProxy, "typeTokenProxy");
            Param.AssertNotNull(symbol, "symbol");

            LexicalElement item = this.PeekNonTokenSymbol(symbol);
            if (item != null)
            {
                typeTokenProxy.Children.Add(item);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Peeks ahead to the next non-Token symbol, without moving the index.
        /// </summary>
        /// <param name="symbol">The current symbol.</param>
        /// <returns>Gets the next non-Token symbol.</returns>
        private LexicalElement PeekNonTokenSymbol(Symbol symbol)
        {
            Param.AssertNotNull(symbol, "symbol");

            if (symbol.SymbolType == SymbolType.WhiteSpace)
            {
                return new Whitespace(this.document, symbol.Text, symbol.Location, this.symbols.Generated);
            }
            else if (symbol.SymbolType == SymbolType.EndOfLine)
            {
                return new EndOfLine(this.document, symbol.Text, symbol.Location, this.symbols.Generated);
            }
            else if (symbol.SymbolType == SymbolType.SingleLineComment)
            {
                return new SingleLineComment(this.document, symbol.Text, symbol.Location, this.symbols.Generated);
            }
            else if (symbol.SymbolType == SymbolType.MultiLineComment)
            {
                return new MultilineComment(this.document, symbol.Text, symbol.Location, this.symbols.Generated);
            }
            else if (symbol.SymbolType == SymbolType.PreprocessorDirective)
            {
                return this.PeekPreprocessorDirective(symbol, this.symbols.Generated);
            }

            return null;
        }

        /// <summary>
        /// Gets array brackets symbol for a type token, if they exist.
        /// </summary>
        /// <param name="typeTokenProxy">Proxy object for the TypeToken being created.</param>
        /// <param name="startIndex">The start index within the symbols.</param>
        private void GetTypeTokenArrayBrackets(CodeUnitProxy typeTokenProxy, ref int startIndex)
        {
            Param.AssertNotNull(typeTokenProxy, "typeTokenProxy");
            Param.AssertGreaterThanOrEqualToZero(startIndex, "startIndex");

            int index = this.GetNextCodeSymbolIndex(startIndex);
            if (index != -1)
            {
                Symbol symbol = this.symbols.Peek(index);
                if (symbol.SymbolType == SymbolType.OpenSquareBracket)
                {
                    // Add the tokens up to this point.
                    this.AdvanceToNextCodeSymbol(typeTokenProxy);
                    startIndex = index;

                    // Now collect the brackets.
                    BracketToken openingBracket = null;
                    while (true)
                    {
                        symbol = this.symbols.Peek(startIndex);
                        if (symbol.SymbolType == SymbolType.WhiteSpace)
                        {
                            typeTokenProxy.Children.Add(new Whitespace(this.document, symbol.Text, symbol.Location, this.symbols.Generated));
                            ++startIndex;
                        }
                        else if (symbol.SymbolType == SymbolType.EndOfLine)
                        {
                            typeTokenProxy.Children.Add(new EndOfLine(this.document, symbol.Text, symbol.Location, this.symbols.Generated));
                            ++startIndex;
                        }
                        else if (symbol.SymbolType == SymbolType.SingleLineComment)
                        {
                            typeTokenProxy.Children.Add(new SingleLineComment(this.document, symbol.Text, symbol.Location, this.symbols.Generated));
                            ++startIndex;
                        }
                        else if (symbol.SymbolType == SymbolType.MultiLineComment)
                        {
                            typeTokenProxy.Children.Add(new MultilineComment(this.document, symbol.Text, symbol.Location, this.symbols.Generated));
                            ++startIndex;
                        }
                        else if (symbol.SymbolType == SymbolType.PreprocessorDirective)
                        {
                            typeTokenProxy.Children.Add(this.PeekPreprocessorDirective(symbol, this.symbols.Generated));
                            ++startIndex;
                        }
                        else if (symbol.SymbolType == SymbolType.Number)
                        {
                            typeTokenProxy.Children.Add(this.ConvertTokenSymbol(symbol, TokenType.Number));
                            ++startIndex;
                        }
                        else if (symbol.SymbolType == SymbolType.Comma)
                        {
                            typeTokenProxy.Children.Add(this.ConvertTokenSymbol(symbol, TokenType.Comma));
                            ++startIndex;
                        }
                        else if (symbol.SymbolType == SymbolType.OpenSquareBracket)
                        {
                            if (openingBracket != null)
                            {
                                throw new SyntaxException(this.document, symbol.LineNumber);
                            }

                            openingBracket = new OpenSquareBracketToken(this.document, symbol.Text, symbol.Location, this.symbols.Generated);
                            typeTokenProxy.Children.Add(openingBracket);
                            ++startIndex;
                        }
                        else if (symbol.SymbolType == SymbolType.CloseSquareBracket)
                        {
                            if (openingBracket == null)
                            {
                                throw new SyntaxException(this.document, symbol.LineNumber);
                            }

                            var closingBracket = new CloseSquareBracketToken(this.document, symbol.Text, symbol.Location, this.symbols.Generated);
                            typeTokenProxy.Children.Add(closingBracket);
                            ++startIndex;

                            openingBracket.MatchingBracket = closingBracket;
                            closingBracket.MatchingBracket = openingBracket;

                            openingBracket = null;

                            // Check whether the next character is another opening bracket.
                            int temp = this.GetNextCodeSymbolIndex(startIndex);
                            if (temp != -1 && this.symbols.Peek(temp).SymbolType != SymbolType.OpenSquareBracket)
                            {
                                break;
                            }
                        }
                        else
                        {
                            if (openingBracket != null)
                            {
                                throw new SyntaxException(this.document, symbol.LineNumber);
                            }

                            break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Gets a nullable type symbol for a type token, if one exists.
        /// </summary>
        /// <param name="typeTokenProxy">Proxy object for the TypeToken being created..</param>
        /// <param name="isExpression">Indicates whether this is in an is expression.</param>
        /// <param name="startIndex">The start index within the symbols.</param>
        private void GetTypeTokenNullableTypeSymbol(CodeUnitProxy typeTokenProxy, bool isExpression, ref int startIndex)
        {
            Param.AssertNotNull(typeTokenProxy, "typeTokenProxy");
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
                    this.GatherNonTokenSymbols(typeTokenProxy, ref startIndex);
                    symbol = this.symbols.Peek(startIndex);

                    // Add the nullable type symbol.
                    typeTokenProxy.Children.Add(new NullableTypeToken(this.document, symbol.Text, symbol.Location, this.symbols.Generated));
                    ++startIndex;
                }
            }
        }

        /// <summary>
        /// Gets the dereference symbols from a type token.
        /// </summary>
        /// <param name="typeTokenProxy">Proxy for the TypeToken being created..</param>
        /// <param name="startIndex">The start index within the symbols list.</param>
        /// <returns>Returns true if there were one or more dereference symbols.</returns>
        private bool GetTypeTokenDereferenceSymbols(CodeUnitProxy typeTokenProxy, ref int startIndex)
        {
            Param.AssertNotNull(typeTokenProxy, "typeTokenProxy");
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
                this.GatherNonTokenSymbols(typeTokenProxy, ref startIndex);
                symbol = this.symbols.Peek(startIndex);

                // Add the dereference symbol.
                typeTokenProxy.Children.Add(new DereferenceOperator(this.document, symbol.Text, symbol.Location, this.symbols.Generated));
                ++startIndex;

                // Nullable types are not allowed with dereferences.
                foundDereferenceSymbol = true;
            }

            return foundDereferenceSymbol;
        }

        /// <summary>
        /// Determines whether a question mark following the type from an 'is' or an 'as' statement is
        /// actually a nullable type question mark rather than a conditional question mark.
        /// </summary>
        /// <param name="index">The peek index of the question mark within the symbol manager.</param>
        /// <returns>Returns true if the question mark is a nullable type question mark.</returns>
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
                if (type == SymbolType.CloseCurlyBracket ||
                    type == SymbolType.CloseParenthesis ||
                    type == SymbolType.CloseSquareBracket ||
                    type == SymbolType.Comma ||
                    type == SymbolType.Semicolon ||
                    type == SymbolType.ConditionalAnd ||
                    type == SymbolType.ConditionalOr ||
                    type == SymbolType.ConditionalEquals ||
                    type == SymbolType.NotEquals ||
                    type == SymbolType.QuestionMark ||
                    type == SymbolType.OpenSquareBracket)
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

        #endregion Private Methods
    }
}
