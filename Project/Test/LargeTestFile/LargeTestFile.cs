//-----------------------------------------------------------------------
// <copyright file="CodeParser.Expressions.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// <author>Jason Allor</author>
//-----------------------------------------------------------------------
namespace Microsoft.SourceAnalysis.CSharp
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
    using Microsoft.SourceAnalysis;

    /// <content>
    /// Contains code for parsing expressions within a C# code file.
    /// </content>
    internal partial class CodeParser
    {
        #region Private Enums

        /// <summary>
        /// The operator type of an expression.
        /// </summary>
        private enum ExpressionPrecedence
        {
            /// <summary>
            /// A global expression.
            /// </summary>
            Global = 0,

            /// <summary>
            /// A primary expression.
            /// </summary>
            Primary = 1,

            /// <summary>
            /// A unary expression.
            /// </summary>
            Unary = 2,

            /// <summary>
            /// A multiplication, division, or modulation expression.
            /// </summary>
            Multiplicative = 3,

            /// <summary>
            /// An addition or subtraction expression.
            /// </summary>
            Additive = 4,

            /// <summary>
            /// A shift expression.
            /// </summary>
            Shift = 5,

            /// <summary>
            /// A relational or type nesting expression.
            /// </summary>
            Relational = 6,

            /// <summary>
            /// An equality or non-equality expression.
            /// </summary>
            Equality = 7,

            /// <summary>
            /// A logical AND expression.
            /// </summary>
            LogicalAnd = 8,

            /// <summary>
            /// A logical XOR expression.
            /// </summary>
            LogicalXor = 9,

            /// <summary>
            /// A logical OR expression.
            /// </summary>
            LogicalOr = 10,

            /// <summary>
            /// A conditional AND expression.
            /// </summary>
            ConditionalAnd = 11,

            /// <summary>
            /// A condition OR expression.
            /// </summary>
            ConditionalOr = 12,

            /// <summary>
            /// A null coalescing expression.
            /// </summary>
            NullCoalescing = 13,

            /// <summary>
            /// A conditional expression.
            /// </summary>
            Conditional = 14,

            /// <summary>
            /// An assignment expression.
            /// </summary>
            Assignment = 15,

            /// <summary>
            /// A query expression.
            /// </summary>
            Query = 16,

            /// <summary>
            /// No precedence.
            /// </summary>
            None = 17
        }

        #endregion Private Enums

        #region Private Methods

        /// <summary>
        /// Reads the next expression from the file and returns it.
        /// </summary>
        /// <param name="previousPrecedence">The precedence of the expression just before this one.</param>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <returns>Returns the expression.</returns>
        private Expression GetNextExpression(ExpressionPrecedence previousPrecedence, bool unsafeCode)
        {
            Param.Ignore(previousPrecedence);
            Param.Ignore(unsafeCode);

            return this.GetNextExpression(previousPrecedence, unsafeCode, false, false);
        }

        /// <summary>
        /// Reads the next expression from the file and returns it.
        /// </summary>
        /// <param name="previousPrecedence">The precedence of the expression just before this one.</param>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <param name="allowVariableDeclaration">Indicates whether this expression can be a variable declaration expression.</param>
        /// <param name="typeExpression">Indicates whether only components of a type expression are allowed.</param>
        /// <returns>Returns the expression.</returns>
        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "The method should be refactored")]
        private Expression GetNextExpression(
            ExpressionPrecedence previousPrecedence, bool unsafeCode, bool allowVariableDeclaration, bool typeExpression)
        {
            Param.Ignore(previousPrecedence);
            Param.Ignore(unsafeCode);
            Param.Ignore(allowVariableDeclaration);
            Param.Ignore(typeExpression);

            // Saves the next expression.
            Expression expression = null;

            // Get the next symbol.
            Symbol symbol = this.GetNextSymbol();

            if (symbol != null)
            {
                switch (symbol.SymbolType)
                {
                    case SymbolType.Other:
                        if (this.IsLambdaExpression())
                        {
                            expression = this.GetLambdaExpression(unsafeCode);
                        }
                        else if (this.IsQueryExpression(unsafeCode))
                        {
                            expression = this.GetQueryExpression(unsafeCode);
                        }

                        // If the expression is still null now, this is just a regular 'other' expression.
                        if (expression == null)
                        {
                            expression = this.GetOtherExpression(allowVariableDeclaration, unsafeCode);
                        }

                        break;

                    case SymbolType.Checked:
                        expression = this.GetCheckedExpression(unsafeCode);
                        break;

                    case SymbolType.Unchecked:
                        expression = this.GetUncheckedExpression(unsafeCode);
                        break;

                    case SymbolType.New:
                        expression = this.GetNewAllocationExpression(unsafeCode);
                        break;

                    case SymbolType.Stackalloc:
                        expression = this.GetStackallocExpression(unsafeCode);
                        break;

                    case SymbolType.Sizeof:
                        expression = this.GetSizeofExpression(unsafeCode);
                        break;

                    case SymbolType.Typeof:
                        expression = this.GetTypeofExpression(unsafeCode);
                        break;

                    case SymbolType.Default:
                        expression = this.GetDefaultValueExpression(unsafeCode);
                        break;

                    case SymbolType.Delegate:
                        expression = this.GetAnonymousMethodExpression(unsafeCode);
                        break;

                    case SymbolType.Increment:
                        if (this.IsUnaryExpression())
                        {
                            expression = this.GetUnaryIncrementExpression(unsafeCode);
                        }

                        break;

                    case SymbolType.Decrement:
                        if (this.IsUnaryExpression())
                        {
                            expression = this.GetUnaryDecrementExpression(unsafeCode);
                        }

                        break;

                    case SymbolType.Plus:
                    case SymbolType.Minus:
                        if (this.IsUnaryExpression())
                        {
                            expression = this.GetUnaryExpression(unsafeCode);
                        }

                        break;

                    case SymbolType.Not:
                    case SymbolType.Tilde:
                        expression = this.GetUnaryExpression(unsafeCode);
                        break;

                    case SymbolType.OpenParenthesis:
                        if (this.IsLambdaExpression())
                        {
                            expression = this.GetLambdaExpression(unsafeCode);
                        }
                        else
                        {
                            expression = this.GetOpenParenthesisExpression(unsafeCode);
                        }

                        break;
                            
                    case SymbolType.Number:
                        Node<CsToken> tokenNode = this.tokens.InsertLast(this.GetToken(CsTokenType.Number, SymbolType.Number));
                        expression = new LiteralExpression(new CsTokenList(this.tokens, tokenNode, tokenNode), tokenNode);
                        break;

                    case SymbolType.String:
                        tokenNode = this.tokens.InsertLast(this.GetToken(CsTokenType.String, SymbolType.String));
                        expression = new LiteralExpression(new CsTokenList(this.tokens, tokenNode, tokenNode), tokenNode);
                        break;

                    case SymbolType.True:
                        tokenNode = this.tokens.InsertLast(this.GetToken(CsTokenType.True, SymbolType.True));
                        expression = new LiteralExpression(new CsTokenList(this.tokens, tokenNode, tokenNode), tokenNode);
                        break;

                    case SymbolType.False:
                        tokenNode = this.tokens.InsertLast(this.GetToken(CsTokenType.False, SymbolType.False));
                        expression = new LiteralExpression(new CsTokenList(this.tokens, tokenNode, tokenNode), tokenNode);
                        break;

                    case SymbolType.Null:
                        tokenNode = this.tokens.InsertLast(this.GetToken(CsTokenType.Null, SymbolType.Null));
                        expression = new LiteralExpression(new CsTokenList(this.tokens, tokenNode, tokenNode), tokenNode);
                        break;

                    case SymbolType.This:
                        tokenNode = this.tokens.InsertLast(this.GetToken(CsTokenType.This, SymbolType.This));
                        expression = new LiteralExpression(new CsTokenList(this.tokens, tokenNode, tokenNode), tokenNode);
                        break;

                    case SymbolType.Base:
                        tokenNode = this.tokens.InsertLast(this.GetToken(CsTokenType.Base, SymbolType.Base));
                        expression = new LiteralExpression(new CsTokenList(this.tokens, tokenNode, tokenNode), tokenNode);
                        break;

                    case SymbolType.Multiplication:
                        if (!unsafeCode)
                        {
                            goto default;
                        }

                        expression = this.GetUnsafeAccessExpression(unsafeCode);
                        break;

                    case SymbolType.LogicalAnd:
                        if (!unsafeCode)
                        {
                            goto default;
                        }

                        expression = this.GetUnsafeAccessExpression(unsafeCode);
                        break;

                    default:
                        throw new SyntaxException(this.document.SourceCode, symbol.LineNumber);
                }
            }

            // Gather up all extensions to this expression.
            while (expression != null)
            {
                // Check if there is an extension to this expression.
                Expression extension = this.GetExpressionExtension(expression, previousPrecedence, unsafeCode, typeExpression);
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

        /// <summary>
        /// Given an expression, reads further to see if it is actually a sub-expression 
        /// within a larger expression.
        /// </summary>
        /// <param name="leftSide">The known expression which might have an extension.</param>
        /// <param name="previousPrecedence">The precedence of the expression just before this one.</param>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <param name="typeExpression">Indicates whether only components of a type expression are allowed.</param>
        /// <returns>Returns the expression.</returns>
        [SuppressMessage(
            "Microsoft.Globalization", 
            "CA1303:DoNotPassLiteralsAsLocalizedParameters", 
            MessageId = "Microsoft.SourceAnalysis.CSharp.SymbolManager.Combine(System.Int32,System.Int32,System.String,Microsoft.SourceAnalysis.CSharp.SymbolType)",
            Justification = "The literal represents a non-localizable C# operator symbol")]
        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "The method should be refactored")]
        private Expression GetExpressionExtension(
            Expression leftSide, ExpressionPrecedence previousPrecedence, bool unsafeCode, bool typeExpression)
        {
            Param.AssertNotNull(leftSide, "leftSide");
            Param.Ignore(previousPrecedence);
            Param.Ignore(unsafeCode);
            Param.Ignore(typeExpression);

            // The expression to return.
            Expression expression = null;

            Symbol symbol = this.GetNextSymbol();

            if (typeExpression)
            {
                // A type expression can only be extended by a member access expression.
                if (symbol.SymbolType == SymbolType.Dot || symbol.SymbolType == SymbolType.QualifiedAlias)
                {
                    expression = this.GetMemberAccessExpression(leftSide, previousPrecedence, unsafeCode);
                }
            }
            else
            {
                // Check the type of the next symbol.
                switch (symbol.SymbolType)
                {
                    case SymbolType.CloseParenthesis:
                    case SymbolType.CloseSquareBracket:
                    case SymbolType.Semicolon:
                    case SymbolType.Comma:
                        break;

                    case SymbolType.Dot:
                    case SymbolType.QualifiedAlias:
                    case SymbolType.Pointer:
                        expression = this.GetMemberAccessExpression(leftSide, previousPrecedence, unsafeCode);
                        break;

                    case SymbolType.Other:
                        // This can only be a variable declaration expression if the left
                        // side expression is a simple Literal or a MemberAccess which represents the type.
                        if (leftSide.ExpressionType == ExpressionType.Literal ||
                            leftSide.ExpressionType == ExpressionType.MemberAccess)
                        {
                            expression = this.GetVariableDeclarationExpression(leftSide, previousPrecedence, unsafeCode);
                        }

                        break;

                    case SymbolType.OpenParenthesis:
                        expression = this.GetMethodInvocationExpression(leftSide, previousPrecedence, unsafeCode);
                        break;

                    case SymbolType.OpenSquareBracket:
                        expression = this.GetArrayAccessExpression(leftSide, previousPrecedence, unsafeCode);
                        break;

                    case SymbolType.As:
                        expression = this.GetAsExpression(leftSide, previousPrecedence, unsafeCode);
                        break;

                    case SymbolType.Is:
                        expression = this.GetIsExpression(leftSide, previousPrecedence, unsafeCode);
                        break;

                    case SymbolType.Increment:
                        expression = this.GetPrimaryIncrementExpression(leftSide, previousPrecedence);
                        break;

                    case SymbolType.Decrement:
                        expression = this.GetPrimaryDecrementExpression(leftSide, previousPrecedence);
                        break;

                    default:
                        // Check whether this is an operator symbol.
                        OperatorType type;
                        OperatorCategory category;
                        if (this.GetOperatorType(symbol, out type, out category))
                        {
                            switch (category)
                            {
                                case OperatorCategory.Conditional:
                                    // The question mark must come before the colon.
                                    if (type == OperatorType.ConditionalQuestionMark)
                                    {
                                        expression = this.GetConditionalExpression(leftSide, previousPrecedence, unsafeCode);
                                    }

                                    break;

                                case OperatorCategory.Arithmetic:
                                    if (unsafeCode && type == OperatorType.Multiplication)
                                    {
                                        if (this.IsDereferenceExpression(leftSide))
                                        {
                                            expression = this.GetUnsafeTypeExpression(leftSide, previousPrecedence, unsafeCode);
                                        }
                                        else
                                        {
                                            expression = this.GetArithmeticExpression(leftSide, previousPrecedence, unsafeCode);
                                        }
                                    }
                                    else
                                    {
                                        expression = this.GetArithmeticExpression(leftSide, previousPrecedence, unsafeCode);
                                    }

                                    break;

                                case OperatorCategory.Shift:
                                    expression = this.GetArithmeticExpression(leftSide, previousPrecedence, unsafeCode);
                                    break;

                                case OperatorCategory.Assignment:
                                    expression = this.GetAssignmentExpression(leftSide, previousPrecedence, unsafeCode);
                                    break;

                                case OperatorCategory.Relational:
                                    // If this is a greater-than symbol, make sure it is not really a right-shift.
                                    if (type == OperatorType.GreaterThan)
                                    {
                                        // If the very next symbol is a greater-than or equals, then this is really a right-shift.
                                        Symbol next = this.symbols.Peek(2);
                                        if (next != null)
                                        {
                                            if (next.SymbolType == SymbolType.GreaterThanOrEquals)
                                            {
                                                // This is a right-shift-equals.
                                                this.symbols.Combine(1, 2, ">>=", SymbolType.RightShiftEquals);
                                                goto case OperatorCategory.Assignment;
                                            }
                                            else if (next.SymbolType == SymbolType.GreaterThan)
                                            {
                                                // This is a right-shift.
                                                this.symbols.Combine(1, 2, ">>", SymbolType.RightShift);
                                                goto case OperatorCategory.Shift;
                                            }
                                        }
                                    }

                                    expression = this.GetRelationalExpression(leftSide, previousPrecedence, unsafeCode);
                                    break;

                                case OperatorCategory.Logical:
                                    switch (type)
                                    {
                                        case OperatorType.LogicalAnd:
                                        case OperatorType.LogicalOr:
                                        case OperatorType.LogicalXor:
                                            expression = this.GetLogicalExpression(leftSide, previousPrecedence, unsafeCode);
                                            break;

                                        case OperatorType.ConditionalAnd:
                                        case OperatorType.ConditionalOr:
                                            expression = this.GetConditionalLogicalExpression(leftSide, previousPrecedence, unsafeCode);
                                            break;

                                        case OperatorType.NullCoalescingSymbol:
                                            expression = this.GetNullCoalescingExpression(leftSide, previousPrecedence, unsafeCode);
                                            break;

                                        default:
                                            break;
                                    }

                                    break;
                            }
                        }

                        break;
                }
            }

            return expression;
        }

        /// <summary>
        /// Gets an expression that starts with an unknown word.
        /// </summary>
        /// <param name="allowVariableDeclaration">Indicates whether this expression can be a variable declaration expression.</param>
        /// <param name="unsafeCode">Indicates whether the expression resides within a block of unsafe code.</param>
        /// <returns>Returns the expression.</returns>
        private Expression GetOtherExpression(bool allowVariableDeclaration, bool unsafeCode)
        {
            Param.Ignore(allowVariableDeclaration);
            Param.Ignore(unsafeCode);

            // Get the first symbol, which will be the unknown word.
            Symbol firstSymbol = this.GetNextSymbol(SymbolType.Other);

            // Holds the expression to return.
            Expression expression = null;

            // Determine whether this has the signature of a type.
            bool variableDeclaration = false;

            if (allowVariableDeclaration)
            {
                int endIndex;
                if (this.HasTypeSignature(1, unsafeCode, out endIndex))
                {
                    // Get the next symbol and check if it is another unknown word.
                    int nextIndex = this.GetNextCodeSymbolIndex(endIndex + 1);
                    if (nextIndex != -1)
                    {
                        if (this.symbols.Peek(nextIndex).SymbolType == SymbolType.Other)
                        {
                            // Determine whether this looks like a variable declaration expression.
                            nextIndex = this.GetNextCodeSymbolIndex(nextIndex + 1);
                            if (nextIndex != -1)
                            {
                                Symbol temp = this.symbols.Peek(nextIndex);

                                // Covers the following cases:
                                // int x = 0;
                                // int x;
                                // void Method(int x)
                                // int x, y;
                                // foreach (int x in y)
                                if (temp.SymbolType == SymbolType.Equals ||           
                                    temp.SymbolType == SymbolType.Semicolon ||        
                                    temp.SymbolType == SymbolType.CloseParenthesis || 
                                    temp.SymbolType == SymbolType.Comma ||            
                                    temp.SymbolType == SymbolType.In)                 
                                {
                                    // This is a variable declaration statement.
                                    variableDeclaration = true;
                                }
                            }
                        }
                    }
                }
            }

            if (variableDeclaration)
            {
                // Get the type expression.
                LiteralExpression type = this.GetTypeTokenExpression(unsafeCode, true, false);
                if (type == null || type.Tokens.First == null)
                {
                    throw this.CreateSyntaxException();
                }

                // Then get the rest of the expression.
                expression = this.GetVariableDeclarationExpression(type, ExpressionPrecedence.None, unsafeCode);
            }
            else
            {
                // This is just a literal expression.
                expression = this.GetLiteralExpression(unsafeCode);
            }

            return expression;
        }

        /// <summary>
        /// Reads an expression starting with an unknown word.
        /// </summary>
        /// <param name="unsafeCode">Indicates whether the code is marked as unsafe.</param>
        /// <returns>Returns the expression.</returns>
        private LiteralExpression GetLiteralExpression(bool unsafeCode)
        {
            Param.Ignore(unsafeCode);

            // Get the first symbol.
            Symbol symbol = this.GetNextSymbol();

            // First, check if this is a generic.
            CsToken literalToken = null;
            int temp;
            bool generic = false;
            if (symbol.SymbolType == SymbolType.Other && this.HasTypeSignature(1, false, out temp, out generic) && generic)
            {
                literalToken = this.GetGenericToken(unsafeCode);
            }

            if (literalToken == null)
            {
                // This is not a generic. Just convert the symbol to a token.
                literalToken = this.GetToken(CsTokenType.Other, SymbolType.Other);
            }

            // Add the token to the document.
            Node<CsToken> literalTokenNode = this.tokens.InsertLast(literalToken);

            // Create a literal expression from this token.
            return new LiteralExpression(this.tokens, literalTokenNode);
        }

        /// <summary>
        /// Reads a method access expression.
        /// </summary>
        /// <param name="methodName">The name of the method being called.</param>
        /// <param name="previousPrecedence">The precedence of the previous expression.</param>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <returns>Returns the expression.</returns>
        private MethodInvocationExpression GetMethodInvocationExpression(
            Expression methodName, ExpressionPrecedence previousPrecedence, bool unsafeCode)
        {
            Param.AssertNotNull(methodName, "methodName");
            Param.Ignore(previousPrecedence);
            Param.Ignore(unsafeCode);

            MethodInvocationExpression expression = null;
            if (this.CheckPrecedence(previousPrecedence, ExpressionPrecedence.Primary))
            {
                // The next symbol will be the opening parenthesis.
                Bracket openParenthesis = this.GetBracketToken(CsTokenType.OpenParenthesis, SymbolType.OpenParenthesis);
                Node<CsToken> openParenthesisNode = this.tokens.InsertLast(openParenthesis);

                // Get the argument list now.
                IList<Expression> argumentList = this.GetArgumentList(SymbolType.CloseParenthesis, unsafeCode);

                // Get the closing parenthesis.
                Bracket closeParenthesis = this.GetBracketToken(CsTokenType.CloseParenthesis, SymbolType.CloseParenthesis);
                Node<CsToken> closeParenthesisNode = this.tokens.InsertLast(closeParenthesis);

                openParenthesis.MatchingBracketNode = closeParenthesisNode;
                closeParenthesis.MatchingBracketNode = openParenthesisNode;

                // Pull out the first token from the method name.
                Debug.Assert(methodName.Tokens.First != null, "The method name should not be empty");
                Node<CsToken> firstTokenNode = methodName.Tokens.First;

                // Create the token list for the method invocation expression.
                CsTokenList partialTokens = new CsTokenList(this.tokens, firstTokenNode, this.tokens.Last);

                // Create and return the expression.
                expression = new MethodInvocationExpression(partialTokens, methodName, argumentList);
            }

            return expression;
        }

        /// <summary>
        /// Reads an array access expression.
        /// </summary>
        /// <param name="array">The array being accessed.</param>
        /// <param name="previousPrecedence">The precedence of the previous expression.</param>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <returns>Returns the expression.</returns>
        private ArrayAccessExpression GetArrayAccessExpression(
            Expression array, ExpressionPrecedence previousPrecedence, bool unsafeCode)
        {
            Param.AssertNotNull(array, "array");
            Param.Ignore(previousPrecedence);
            Param.Ignore(unsafeCode);

            ArrayAccessExpression expression = null;

            if (this.CheckPrecedence(previousPrecedence, ExpressionPrecedence.Primary))
            {
                // The next symbol will be the opening bracket.
                Bracket openingBracket = this.GetBracketToken(CsTokenType.OpenSquareBracket, SymbolType.OpenSquareBracket);
                Node<CsToken> openingBracketNode = this.tokens.InsertLast(openingBracket);

                // Get the argument list now.
                ICollection<Expression> argumentList = this.GetArgumentList(SymbolType.CloseSquareBracket, unsafeCode);

                // Get the closing bracket.
                Bracket closingBracket = this.GetBracketToken(CsTokenType.CloseSquareBracket, SymbolType.CloseSquareBracket);
                Node<CsToken> closingBracketNode = this.tokens.InsertLast(closingBracket);

                openingBracket.MatchingBracketNode = closingBracketNode;
                closingBracket.MatchingBracketNode = openingBracketNode;

                // Pull out the first token from the array.
                Node<CsToken> firstTokenNode = array.Tokens.First;

                // Create the token list for the method invocation expression.
                CsTokenList partialTokens = new CsTokenList(this.tokens, firstTokenNode, this.tokens.Last);

                // Create and return the expression.
                expression = new ArrayAccessExpression(partialTokens, array, argumentList);
            }

            return expression;
        }

        /// <summary>
        /// Reads a member access expression.
        /// </summary>
        /// <param name="leftSide">The left side of the expression.</param>
        /// <param name="previousPrecedence">The precedence of the previous expression.</param>
        /// <param name="unsafeCode">Indicates whether the code is marked as unsafe.</param>
        /// <returns>Returns the expression.</returns>
        private MemberAccessExpression GetMemberAccessExpression(
            Expression leftSide, ExpressionPrecedence previousPrecedence, bool unsafeCode)
        {
            Param.AssertNotNull(leftSide, "leftSide");
            Param.Ignore(previousPrecedence);
            Param.Ignore(unsafeCode);

            MemberAccessExpression expression = null;

            OperatorType operatorType;
            MemberAccessExpression.Operator expressionOperatorType;
            ExpressionPrecedence precedence;

            // The next symbol must one of the member access types.
            Symbol symbol = this.GetNextSymbol();

            if (symbol.SymbolType == SymbolType.Dot)
            {
                operatorType = OperatorType.MemberAccess;
                expressionOperatorType = MemberAccessExpression.Operator.Dot;
                precedence = ExpressionPrecedence.Primary;
            }
            else if (symbol.SymbolType == SymbolType.Pointer)
            {
                operatorType = OperatorType.Pointer;
                expressionOperatorType = MemberAccessExpression.Operator.Pointer;
                precedence = ExpressionPrecedence.Primary;
            }
            else if (symbol.SymbolType == SymbolType.QualifiedAlias)
            {
                operatorType = OperatorType.QualifiedAlias;
                expressionOperatorType = MemberAccessExpression.Operator.QualifiedAlias;
                precedence = ExpressionPrecedence.Global;
            }
            else
            {
                Debug.Fail("Unexpected operator type");
                throw new InvalidOperationException();
            }

            // Check the precedence. A member access has primary precedence.
            if (this.CheckPrecedence(previousPrecedence, precedence))
            {
                // Add this to the document.
                this.tokens.Add(this.GetOperatorToken(operatorType));

                // Get the member being accessed. This must be a literal.
                LiteralExpression member = this.GetLiteralExpression(unsafeCode);
                if (member == null)
                {
                    throw this.CreateSyntaxException();
                }

                // Create the token list.
                CsTokenList partialTokens = new CsTokenList(this.tokens, leftSide.Tokens.First, this.tokens.Last);

                // Create the expression.
                expression = new MemberAccessExpression(partialTokens, expressionOperatorType, leftSide, member);
            }

            return expression;
        }

        /// <summary>
        /// Reads an expression beginning with two unknown words.
        /// </summary>
        /// <param name="type">The type of the variable.</param>
        /// <param name="previousPrecedence">The precedence of the previous expression.</param>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <returns>Returns the expression.</returns>
        private VariableDeclarationExpression GetVariableDeclarationExpression(
            Expression type, ExpressionPrecedence previousPrecedence, bool unsafeCode)
        {
            Param.AssertNotNull(type, "type");
            Param.Ignore(previousPrecedence);
            Param.Ignore(unsafeCode);

            Debug.Assert(
                type.ExpressionType == ExpressionType.Literal ||
                type.ExpressionType == ExpressionType.MemberAccess,
                "The left side of a variable declaration must either be a literal or a member access.");

            VariableDeclarationExpression expression = null;
            if (this.CheckPrecedence(previousPrecedence, ExpressionPrecedence.None))
            {
                // Convert the type expression to a literal type token expression.
                LiteralExpression literalType = null;
                if (type.ExpressionType == ExpressionType.Literal)
                {
                    literalType = type as LiteralExpression;
                    if (!(literalType.Token is TypeToken))
                    {
                        literalType = null;
                    }
                }

                if (literalType == null)
                {
                    literalType = this.ConvertTypeExpression(type);
                }

                // Get each declarator.
                List<VariableDeclaratorExpression> declarators = new List<VariableDeclaratorExpression>();

                while (true)
                {
                    // Get the next word.
                    Symbol symbol = this.GetNextSymbol(SymbolType.Other);

                    // Get the identifier.
                    LiteralExpression identifier = this.GetLiteralExpression(unsafeCode);
                    if (identifier == null || identifier.Tokens.First == null)
                    {
                        throw new SyntaxException(this.document.SourceCode, symbol.LineNumber);
                    }

                    // Get the initializer if it exists.
                    Expression initializer = null;

                    symbol = this.GetNextSymbol();
                    if (symbol.SymbolType == SymbolType.Equals)
                    {
                        // Add the equals token.
                        this.tokens.Add(this.GetOperatorToken(OperatorType.Equals));

                        // Check whether this is an array initializer.
                        symbol = this.GetNextSymbol();

                        if (symbol.SymbolType == SymbolType.OpenCurlyBracket)
                        {
                            initializer = this.GetArrayInitializerExpression(unsafeCode);
                        }
                        else
                        {
                            initializer = this.GetNextExpression(ExpressionPrecedence.None, unsafeCode);
                        }
                    }

                    // Create the token list for the declarator.
                    CsTokenList partialTokens = new CsTokenList(
                        this.tokens, identifier.Tokens.First, this.tokens.Last);

                    // Create and add the declarator.
                    declarators.Add(new VariableDeclaratorExpression(partialTokens, identifier, initializer));

                    // Now check if the next character is a comma. If so there is another declarator.
                    symbol = this.GetNextSymbol();
                    if (symbol.SymbolType != SymbolType.Comma)
                    {
                        // There are no more declarators.
                        break;
                    }

                    // Add the comma.
                    this.tokens.Add(this.GetToken(CsTokenType.Comma, SymbolType.Comma));
                }

                // Create the token list for the expression.
                CsTokenList tokenList = new CsTokenList(this.tokens, type.Tokens.First, this.tokens.Last);

                // Create the expression.
                expression = new VariableDeclarationExpression(tokenList, literalType, declarators.ToArray());
            }

            return expression;
        }

        /// <summary>
        /// Reads an array initializer expression.
        /// </summary>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <returns>Returns the expression.</returns>
        private ArrayInitializerExpression GetArrayInitializerExpression(bool unsafeCode)
        {
            Param.Ignore(unsafeCode);

            // Get the first symbol and make sure it is an opening curly bracket.
            Bracket openingBracket = this.GetBracketToken(CsTokenType.OpenCurlyBracket, SymbolType.OpenCurlyBracket);
            Node<CsToken> openingBracketNode = this.tokens.InsertLast(openingBracket);

            // Get each of the initializers.
            List<Expression> initializers = new List<Expression>();

            while (true)
            {
                // If this initializer starts with an opening curly bracket, it is another
                // array initializer expression. Otherwise, parse it like a normal expression.
                Symbol symbol = this.GetNextSymbol();

                if (symbol.SymbolType == SymbolType.OpenCurlyBracket)
                {
                    initializers.Add(this.GetArrayInitializerExpression(unsafeCode));
                }
                else if (symbol.SymbolType == SymbolType.CloseCurlyBracket)
                {
                    break;
                }
                else
                {
                    initializers.Add(this.GetNextExpression(ExpressionPrecedence.None, unsafeCode));
                }

                // Now check the type of the next symbol and see if it is a comma.
                symbol = this.GetNextSymbol();

                if (symbol.SymbolType == SymbolType.Comma)
                {
                    // Add the comma and advance.
                    this.tokens.Add(this.GetToken(CsTokenType.Comma, SymbolType.Comma));
                }
            }

            // Add the closing curly bracket.
            Bracket closingBracket = this.GetBracketToken(CsTokenType.CloseCurlyBracket, SymbolType.CloseCurlyBracket);
            Node<CsToken> closingBracketNode = this.tokens.InsertLast(closingBracket);

            openingBracket.MatchingBracketNode = closingBracketNode;
            closingBracket.MatchingBracketNode = openingBracketNode;

            // Create the token list for the expression.
            CsTokenList partialTokens = new CsTokenList(this.tokens, openingBracketNode, this.tokens.Last);

            // Return the expression.
            return new ArrayInitializerExpression(partialTokens, initializers.ToArray());
        }

        /// <summary>
        /// Reads an expression beginning with an opening parenthesis.
        /// </summary>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <returns>Returns the expression.</returns>
        private Expression GetOpenParenthesisExpression(bool unsafeCode)
        {
            Param.Ignore(unsafeCode);

            Expression expression = null;

            // Now check whether this is a cast.
            if (this.IsCastExpression(unsafeCode))
            {
                expression = this.GetCastExpression(unsafeCode);
            }
            else
            {
                // This is an expression wrapped in parenthesis.
                expression = this.GetParenthesizedExpression(unsafeCode);
            }

            return expression;
        }

        /// <summary>
        /// Reads a cast expression.
        /// </summary>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <returns>Returns the expression.</returns>
        private CastExpression GetCastExpression(bool unsafeCode)
        {
            Param.Ignore(unsafeCode);

            // Get the opening parenthesis.
            Bracket openParenthesis = this.GetBracketToken(CsTokenType.OpenParenthesis, SymbolType.OpenParenthesis);
            Node<CsToken> openParenthesisNode = this.tokens.InsertLast(openParenthesis);

            // Get the next token. It must be an unknown word.
            this.GetNextSymbol(SymbolType.Other);

            // Get the casted expression.
            LiteralExpression type = this.GetTypeTokenExpression(unsafeCode, true, false);
            if (type == null || type.Tokens.First == null)
            {
                throw this.CreateSyntaxException();
            }

            // Get the closing parenthesis.
            Bracket closeParenthesis = this.GetBracketToken(CsTokenType.CloseParenthesis, SymbolType.CloseParenthesis);
            Node<CsToken> closeParenthesisNode = this.tokens.InsertLast(closeParenthesis);

            openParenthesis.MatchingBracketNode = closeParenthesisNode;
            closeParenthesis.MatchingBracketNode = openParenthesisNode;

            // Get the embedded expression being casted.
            Expression castedExpression = this.GetNextExpression(ExpressionPrecedence.Unary, unsafeCode);
            if (castedExpression == null || castedExpression.Tokens.First == null)
            {
                throw this.CreateSyntaxException();
            }

            // Create the token list for the expression.
            CsTokenList partialTokens = new CsTokenList(this.tokens, openParenthesisNode, this.tokens.Last);

            // Create and return the expression.
            return new CastExpression(partialTokens, type, castedExpression);
        }

        /// <summary>
        /// Reads an expression wrapped in parenthesis expression.
        /// </summary>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <returns>Returns the expression.</returns>
        private ParenthesizedExpression GetParenthesizedExpression(bool unsafeCode)
        {
            Param.Ignore(unsafeCode);

            // Get the opening parenthesis.
            Bracket openParenthesis = this.GetBracketToken(CsTokenType.OpenParenthesis, SymbolType.OpenParenthesis);
            Node<CsToken> openParenthesisNode = this.tokens.InsertLast(openParenthesis);

            // Get the inner expression.
            Expression expression = this.GetNextExpression(ExpressionPrecedence.None, unsafeCode);
            if (expression == null)
            {
                throw this.CreateSyntaxException();
            }

            // Get the closing parenthesis.
            Bracket closeParenthesis = this.GetBracketToken(CsTokenType.CloseParenthesis, SymbolType.CloseParenthesis);
            Node<CsToken> closeParenthesisNode = this.tokens.InsertLast(closeParenthesis);

            openParenthesis.MatchingBracketNode = closeParenthesisNode;
            closeParenthesis.MatchingBracketNode = openParenthesisNode;

            // Create the token list for the expression.
            CsTokenList partialTokens = new CsTokenList(this.tokens, openParenthesisNode, this.tokens.Last);

            // Create and return the expression.
            return new ParenthesizedExpression(partialTokens, expression);
        }

        /// <summary>
        /// Reads the argument list for a method invocation expression.
        /// </summary>
        /// <param name="closingSymbol">The symbol that closes the argument list.</param>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <returns>Returns the list of arguments in the method invocation.</returns>
        private IList<Expression> GetArgumentList(SymbolType closingSymbol, bool unsafeCode)
        {
            Param.AssertNotNull(closingSymbol, "closingSymbol");
            Param.Ignore(unsafeCode);

            List<Expression> arguments = new List<Expression>();

            while (true)
            {
                // Move to the next code token.
                Symbol symbol = this.GetNextSymbol();

                if (symbol.SymbolType == closingSymbol)
                {
                    break;
                }
                else if (symbol.SymbolType == SymbolType.Comma)
                {
                    this.tokens.Add(this.GetToken(CsTokenType.Comma, SymbolType.Comma));
                }
                else if (symbol.SymbolType == SymbolType.Ref)
                {
                    this.tokens.Add(this.GetToken(CsTokenType.Ref, SymbolType.Ref));
                }
                else if (symbol.SymbolType == SymbolType.Out)
                {
                    this.tokens.Add(this.GetToken(CsTokenType.Out, SymbolType.Out));
                }
                else if (symbol.SymbolType == SymbolType.Params)
                {
                    this.tokens.Add(this.GetToken(CsTokenType.Params, SymbolType.Params));
                }
                else
                {
                    arguments.Add(this.GetNextExpression(ExpressionPrecedence.None, unsafeCode));
                }
            }

            // Trim the list down to a small array before returning it.
            return arguments.ToArray();
        }

        /// <summary>
        /// Reads an as expression.
        /// </summary>
        /// <param name="leftHandSide">The expression on the left hand side of the operator.</param>
        /// <param name="previousPrecedence">The precedence of the expression just before this one.</param>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <returns>Returns the expression.</returns>
        private AsExpression GetAsExpression(
            Expression leftHandSide, ExpressionPrecedence previousPrecedence, bool unsafeCode)
        {
            Param.AssertNotNull(leftHandSide, "leftHandSide");
            Param.Ignore(previousPrecedence);
            Param.Ignore(unsafeCode);

            AsExpression expression = null;

            // Check the previous precedence to see if we are allowed to gather up the as expression.
            if (this.CheckPrecedence(previousPrecedence, ExpressionPrecedence.Relational))
            {
                // Make sure the left hand side has at least one token.
                Debug.Assert(leftHandSide.Tokens.First != null, "The left hand side should not be empty");

                // Get the as symbol.
                this.tokens.Add(this.GetToken(CsTokenType.As, SymbolType.As));

                // The next token must be the type.
                this.GetNextSymbol(SymbolType.Other);

                // Get the expression representing the type.
                LiteralExpression rightHandSide = this.GetTypeTokenExpression(unsafeCode, true, true);
                if (rightHandSide == null || rightHandSide.Tokens.First == null)
                {
                    throw this.CreateSyntaxException();
                }

                // Create the partial token list for the expression.
                CsTokenList partialTokens = new CsTokenList(this.tokens, leftHandSide.Tokens.First, this.tokens.Last);

                // Create and return the expression.
                expression = new AsExpression(partialTokens, leftHandSide, rightHandSide);
            }

            return expression;
        }

        /// <summary>
        /// Reads an is expression.
        /// </summary>
        /// <param name="leftHandSide">The expression on the left hand side of the operator.</param>
        /// <param name="previousPrecedence">The precedence of the expression just before this one.</param>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <returns>Returns the expression.</returns>
        private IsExpression GetIsExpression(
            Expression leftHandSide, ExpressionPrecedence previousPrecedence, bool unsafeCode)
        {
            Param.AssertNotNull(leftHandSide, "leftHandSide");
            Param.Ignore(previousPrecedence);
            Param.Ignore(unsafeCode);

            IsExpression expression = null;

            // Check the previous precedence to see if we are allowed to gather up the is expression.
            if (this.CheckPrecedence(previousPrecedence, ExpressionPrecedence.Relational))
            {
                // Make sure the left hand side has at least one token.
                Debug.Assert(leftHandSide.Tokens.First != null, "The left hand side should not be empty");

                // Get the is symbol.
                this.tokens.Add(this.GetToken(CsTokenType.Is, SymbolType.Is));

                // The next token must be the type.
                this.GetNextSymbol(SymbolType.Other);

                // Get the expression representing the type.
                LiteralExpression rightHandSide = this.GetTypeTokenExpression(unsafeCode, true, true);
                if (rightHandSide == null || rightHandSide.Tokens.First == null)
                {
                    throw this.CreateSyntaxException();
                }

                // Create the partial token list for the expression.
                CsTokenList partialTokens = new CsTokenList(this.tokens, leftHandSide.Tokens.First, this.tokens.Last);

                // Create and return the expression.
                expression = new IsExpression(partialTokens, leftHandSide, rightHandSide);
            }

            return expression;
        }

        /// <summary>
        /// Reads a primary increment expression.
        /// </summary>
        /// <param name="leftHandSide">The expression on the left hand side of the operator.</param>
        /// <param name="previousPrecedence">The precedence of the expression just before this one.</param>
        /// <returns>Returns the expression.</returns>
        private IncrementExpression GetPrimaryIncrementExpression(
            Expression leftHandSide, ExpressionPrecedence previousPrecedence)
        {
            Param.AssertNotNull(leftHandSide, "leftHandSide");
            Param.Ignore(previousPrecedence);

            IncrementExpression expression = null;

            // Check the previous precedence to see if we are allowed to gather up the as expression.
            if (this.CheckPrecedence(previousPrecedence, ExpressionPrecedence.Primary))
            {
                // Make sure the left hand side has at least one token.
                Debug.Assert(leftHandSide.Tokens.First != null, "The left hand side should not be empty.");

                // Get the increment symbol.
                this.tokens.Add(this.GetOperatorToken(OperatorType.Increment));
                
                // Create the partial token list for the expression.
                CsTokenList partialTokens = new CsTokenList(this.tokens, leftHandSide.Tokens.First, this.tokens.Last);

                // Create and return the expression.
                expression = new IncrementExpression(partialTokens, leftHandSide, IncrementExpression.IncrementType.Postfix);
            }

            return expression;
        }

        /// <summary>
        /// Reads a primary decrement expression.
        /// </summary>
        /// <param name="leftHandSide">The expression on the left hand side of the operator.</param>
        /// <param name="previousPrecedence">The precedence of the expression just before this one.</param>
        /// <returns>Returns the expression.</returns>
        private DecrementExpression GetPrimaryDecrementExpression(
            Expression leftHandSide, ExpressionPrecedence previousPrecedence)
        {
            Param.AssertNotNull(leftHandSide, "leftHandSide");
            Param.Ignore(previousPrecedence);

            DecrementExpression expression = null;

            // Check the previous precedence to see if we are allowed to gather up the as expression.
            if (this.CheckPrecedence(previousPrecedence, ExpressionPrecedence.Primary))
            {
                // Make sure the left hand side has at least one token.
                Debug.Assert(leftHandSide.Tokens.First != null, "The left hand side should not be empty");

                // Get the decrement symbol.
                this.tokens.Add(this.GetOperatorToken(OperatorType.Decrement));
                
                // Create the partial token list for the expression.
                CsTokenList partialTokens = new CsTokenList(this.tokens, leftHandSide.Tokens.First, this.tokens.Last);

                // Create and return the expression.
                expression = new DecrementExpression(partialTokens, leftHandSide, DecrementExpression.DecrementType.Postfix);
            }

            return expression;
        }

        /// <summary>
        /// Reads a unary increment expression.
        /// </summary>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <returns>Returns the expression.</returns>
        private IncrementExpression GetUnaryIncrementExpression(bool unsafeCode)
        {
            Param.Ignore(unsafeCode);

            // Get the increment symbol.
            Node<CsToken> tokenNode = this.tokens.InsertLast(this.GetOperatorToken(OperatorType.Increment));

            // Get the expression being incremented.
            Expression valueExpression = this.GetNextExpression(ExpressionPrecedence.Unary, unsafeCode);
            if (valueExpression == null || valueExpression.Tokens.First == null)
            {
                throw this.CreateSyntaxException();
            }
            
            // Create the partial token list for the expression.
            CsTokenList partialTokens = new CsTokenList(this.tokens, tokenNode, this.tokens.Last);

            // Create and return the expression.
            return new IncrementExpression(partialTokens, valueExpression, IncrementExpression.IncrementType.Prefix);
        }

        /// <summary>
        /// Reads a unary decrement expression.
        /// </summary>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <returns>Returns the expression.</returns>
        private DecrementExpression GetUnaryDecrementExpression(bool unsafeCode)
        {
            Param.Ignore(unsafeCode);

            // Get the decrement symbol.
            Node<CsToken> tokenNode = this.tokens.InsertLast(this.GetOperatorToken(OperatorType.Decrement));

            // Get the expression being decremented.
            Expression valueExpression = this.GetNextExpression(ExpressionPrecedence.Unary, unsafeCode);
            if (valueExpression == null || valueExpression.Tokens.First == null)
            {
                throw this.CreateSyntaxException();
            }

            // Create the partial token list for the expression.
            CsTokenList partialTokens = new CsTokenList(this.tokens, tokenNode, this.tokens.Last);

            // Create and return the expression.
            return new DecrementExpression(partialTokens, valueExpression, DecrementExpression.DecrementType.Prefix);
        }

        /// <summary>
        /// Reads a unary expression.
        /// </summary>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <returns>Returns the expression.</returns>
        private UnaryExpression GetUnaryExpression(bool unsafeCode)
        {
            Param.Ignore(unsafeCode);

            // Create the token based on the type of the symbol.
            Symbol symbol = this.GetNextSymbol();

            OperatorSymbol token;
            UnaryExpression.Operator operatorType;
            if (symbol.SymbolType == SymbolType.Plus)
            {
                operatorType = UnaryExpression.Operator.Positive;
                token = new OperatorSymbol(symbol.Text, OperatorCategory.Unary, OperatorType.Positive, symbol.Location, this.symbols.Generated);
            }
            else if (symbol.SymbolType == SymbolType.Minus)
            {
                operatorType = UnaryExpression.Operator.Negative;
                token = new OperatorSymbol(symbol.Text, OperatorCategory.Unary, OperatorType.Negative, symbol.Location, this.symbols.Generated);
            }
            else if (symbol.SymbolType == SymbolType.Not)
            {
                operatorType = UnaryExpression.Operator.Not;
                token = new OperatorSymbol(symbol.Text, OperatorCategory.Unary, OperatorType.Not, symbol.Location, this.symbols.Generated);
            }
            else if (symbol.SymbolType == SymbolType.Tilde)
            {
                operatorType = UnaryExpression.Operator.BitwiseCompliment;
                token = new OperatorSymbol(symbol.Text, OperatorCategory.Unary, OperatorType.BitwiseCompliment, symbol.Location, this.symbols.Generated);
            }
            else
            {
                // This is not a unary type.
                Debug.Fail("Unexpected operator type");
                throw new SourceAnalysisException();
            }

            Node<CsToken> tokenNode = this.tokens.InsertLast(token);
            this.symbols.Advance();

            // Get the expression after the operator.
            Expression expression = this.GetNextExpression(ExpressionPrecedence.Unary, unsafeCode);
            if (expression == null || expression.Tokens.First == null)
            {
                throw this.CreateSyntaxException();
            }

            // Create the partial token list for the expression.
            CsTokenList partialTokens = new CsTokenList(this.tokens, tokenNode, this.tokens.Last);

            // Create and return the expression.
            return new UnaryExpression(partialTokens, operatorType, expression);
        }

        /// <summary>
        /// Reads a conditional expression.
        /// </summary>
        /// <param name="leftHandSide">The expression on the left hand side of the operator.</param>
        /// <param name="previousPrecedence">The precedence of the expression just before this one.</param>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <returns>Returns the expression.</returns>
        private ConditionalExpression GetConditionalExpression(
            Expression leftHandSide, ExpressionPrecedence previousPrecedence, bool unsafeCode)
        {
            Param.AssertNotNull(leftHandSide, "leftHandSide");
            Param.Ignore(unsafeCode);
            Param.Ignore(previousPrecedence);

            ConditionalExpression expression = null;

            if (this.CheckPrecedence(previousPrecedence, ExpressionPrecedence.Conditional))
            {
                // Get the first operator.
                this.tokens.Add(this.GetOperatorToken(OperatorType.ConditionalQuestionMark));

                // Get the expression on the right-hand side of the operator.
                Expression trueValue = this.GetOperatorRightHandExpression(ExpressionPrecedence.Conditional, unsafeCode);

                // Get the next operator and make sure it is the correct type.
                this.tokens.Add(this.GetOperatorToken(OperatorType.ConditionalColon));

                // Get the expression on the right-hand side of the operator.
                Expression falseValue = this.GetOperatorRightHandExpression(ExpressionPrecedence.None, unsafeCode);

                // Create the partial token list for the expression.
                CsTokenList partialTokens = new CsTokenList(this.tokens, leftHandSide.Tokens.First, this.tokens.Last);

                // Create and return the expression.
                expression = new ConditionalExpression(partialTokens, leftHandSide, trueValue, falseValue);
            }

            return expression;
        }

        /// <summary>
        /// Reads an arithmetic expression.
        /// </summary>
        /// <param name="leftHandSide">The expression on the left hand side of the operator.</param>
        /// <param name="previousPrecedence">The precedence of the expression just before this one.</param>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <returns>Returns the expression.</returns>
        private ArithmeticExpression GetArithmeticExpression(
            Expression leftHandSide, ExpressionPrecedence previousPrecedence, bool unsafeCode)
        {
            Param.AssertNotNull(leftHandSide, "leftHandSide");
            Param.Ignore(previousPrecedence);
            Param.Ignore(unsafeCode);

            ArithmeticExpression expression = null;
            
            // Read the details of the expression.
            OperatorSymbol operatorToken = this.PeekOperatorToken();
            Debug.Assert(
                operatorToken.Category == OperatorCategory.Arithmetic || operatorToken.Category == OperatorCategory.Shift, 
                "Expected an arithmetic or shift operator");

            // Check the precedence of the operators to make sure we can gather this statement now.
            ExpressionPrecedence precedence = this.GetOperatorPrecedence(operatorToken.SymbolType);
            if (this.CheckPrecedence(previousPrecedence, precedence))
            {
                // Add the operator token to the document and advance the symbol manager up to it.
                this.symbols.Advance();
                this.tokens.Add(operatorToken);

                // Get the expression on the right-hand side of the operator.
                Expression rightHandSide = this.GetOperatorRightHandExpression(precedence, unsafeCode);

                // Create the partial token list for the expression.
                CsTokenList partialTokens = new CsTokenList(this.tokens, leftHandSide.Tokens.First, this.tokens.Last);

                // Get the expression operator type.
                ArithmeticExpression.Operator type;
                switch (operatorToken.SymbolType)
                {
                    case OperatorType.Plus:
                        type = ArithmeticExpression.Operator.Addition;
                        break;

                    case OperatorType.Minus:
                        type = ArithmeticExpression.Operator.Subtraction;
                        break;

                    case OperatorType.Multiplication:
                        type = ArithmeticExpression.Operator.Multiplication;
                        break;

                    case OperatorType.Division:
                        type = ArithmeticExpression.Operator.Division;
                        break;

                    case OperatorType.Mod:
                        type = ArithmeticExpression.Operator.Mod;
                        break;

                    case OperatorType.LeftShift:
                        type = ArithmeticExpression.Operator.LeftShift;
                        break;

                    case OperatorType.RightShift:
                        type = ArithmeticExpression.Operator.RightShift;
                        break;

                    default:
                        Debug.Fail("Unexpected operator type");
                        throw new InvalidOperationException();
                }

                // Create and return the expression.
                expression = new ArithmeticExpression(partialTokens, type, leftHandSide, rightHandSide);
            }

            return expression;
        }

        /// <summary>
        /// Reads an assignment expression.
        /// </summary>
        /// <param name="leftHandSide">The expression on the left hand side of the operator.</param>
        /// <param name="previousPrecedence">The precedence of the expression just before this one.</param>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <returns>Returns the expression.</returns>
        private AssignmentExpression GetAssignmentExpression(
            Expression leftHandSide, ExpressionPrecedence previousPrecedence, bool unsafeCode)
        {
            Param.AssertNotNull(leftHandSide, "leftHandSide");
            Param.Ignore(previousPrecedence);
            Param.Ignore(unsafeCode);

            AssignmentExpression expression = null;

            // Read the details of the expression.
            OperatorSymbol operatorToken = this.PeekOperatorToken();
            Debug.Assert(operatorToken.Category == OperatorCategory.Assignment, "Expected an assignment operator");

            // Check the precedence of the operators to make sure we can gather this statement now.
            ExpressionPrecedence precedence = this.GetOperatorPrecedence(operatorToken.SymbolType);
            if (this.CheckPrecedence(previousPrecedence, precedence))
            {
                // Add the operator token to the document and advance the symbol manager up to it.
                this.symbols.Advance();
                this.tokens.Add(operatorToken);

                // Get the expression on the right-hand side of the operator.
                Expression rightHandSide = this.GetOperatorRightHandExpression(precedence, unsafeCode);

                // Create the partial token list for the expression.
                CsTokenList partialTokens = new CsTokenList(this.tokens, leftHandSide.Tokens.First, this.tokens.Last);

                // Get the expression operator type.
                AssignmentExpression.Operator type;
                switch (operatorToken.SymbolType)
                {
                    case OperatorType.Equals:
                        type = AssignmentExpression.Operator.Equals;
                        break;

                    case OperatorType.PlusEquals:
                        type = AssignmentExpression.Operator.PlusEquals;
                        break;

                    case OperatorType.MinusEquals:
                        type = AssignmentExpression.Operator.MinusEquals;
                        break;

                    case OperatorType.MultiplicationEquals:
                        type = AssignmentExpression.Operator.MultiplicationEquals;
                        break;

                    case OperatorType.DivisionEquals:
                        type = AssignmentExpression.Operator.DivisionEquals;
                        break;

                    case OperatorType.AndEquals:
                        type = AssignmentExpression.Operator.AndEquals;
                        break;

                    case OperatorType.OrEquals:
                        type = AssignmentExpression.Operator.OrEquals;
                        break;

                    case OperatorType.XorEquals:
                        type = AssignmentExpression.Operator.XorEquals;
                        break;

                    case OperatorType.ModEquals:
                        type = AssignmentExpression.Operator.ModEquals;
                        break;

                    case OperatorType.LeftShiftEquals:
                        type = AssignmentExpression.Operator.LeftShiftEquals;
                        break;

                    case OperatorType.RightShiftEquals:
                        type = AssignmentExpression.Operator.RightShiftEquals;
                        break;

                    default:
                        Debug.Fail("Unexpected operator type");
                        throw new InvalidOperationException();
                }

                // Create and return the expression.
                expression = new AssignmentExpression(partialTokens, type, leftHandSide, rightHandSide);
            }

            return expression;
        }

        /// <summary>
        /// Reads a relational expression.
        /// </summary>
        /// <param name="leftHandSide">The expression on the left hand side of the operator.</param>
        /// <param name="previousPrecedence">The precedence of the expression just before this one.</param>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <returns>Returns the expression.</returns>
        private RelationalExpression GetRelationalExpression(
            Expression leftHandSide, ExpressionPrecedence previousPrecedence, bool unsafeCode)
        {
            Param.AssertNotNull(leftHandSide, "leftHandSide");
            Param.Ignore(previousPrecedence);
            Param.Ignore(unsafeCode);

            RelationalExpression expression = null;

            // Read the details of the expression.
            OperatorSymbol operatorToken = this.PeekOperatorToken();
            Debug.Assert(operatorToken.Category == OperatorCategory.Relational, "Expected a relational operator");

            // Check the precedence of the operators to make sure we can gather this statement now.
            ExpressionPrecedence precedence = this.GetOperatorPrecedence(operatorToken.SymbolType);
            if (this.CheckPrecedence(previousPrecedence, precedence))
            {
                // Add the operator token to the document and advance the symbol manager up to it.
                this.symbols.Advance();
                this.tokens.Add(operatorToken);

                // Get the expression on the right-hand side of the operator.
                Expression rightHandSide = this.GetOperatorRightHandExpression(precedence, unsafeCode);

                // Create the partial token list for the expression.
                CsTokenList partialTokens = new CsTokenList(this.tokens, leftHandSide.Tokens.First, this.tokens.Last);

                // Get the expression operator type.
                RelationalExpression.Operator type;
                switch (operatorToken.SymbolType)
                {
                    case OperatorType.ConditionalEquals:
                        type = RelationalExpression.Operator.EqualTo;
                        break;

                    case OperatorType.NotEquals:
                        type = RelationalExpression.Operator.NotEqualTo;
                        break;

                    case OperatorType.GreaterThan:
                        type = RelationalExpression.Operator.GreaterThan;
                        break;

                    case OperatorType.GreaterThanOrEquals:
                        type = RelationalExpression.Operator.GreaterThanOrEqualTo;
                        break;

                    case OperatorType.LessThan:
                        type = RelationalExpression.Operator.LessThan;
                        break;

                    case OperatorType.LessThanOrEquals:
                        type = RelationalExpression.Operator.LessThanOrEqualTo;
                        break;

                    default:
                        Debug.Fail("Unexpected operator type");
                        throw new InvalidOperationException();
                }

                // Create and return the expression.
                expression = new RelationalExpression(partialTokens, type, leftHandSide, rightHandSide);
            }

            return expression;
        }

        /// <summary>
        /// Reads a logical expression.
        /// </summary>
        /// <param name="leftHandSide">The expression on the left hand side of the operator.</param>
        /// <param name="previousPrecedence">The precedence of the expression just before this one.</param>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <returns>Returns the expression.</returns>
        private LogicalExpression GetLogicalExpression(
            Expression leftHandSide, ExpressionPrecedence previousPrecedence, bool unsafeCode)
        {
            Param.AssertNotNull(leftHandSide, "leftHandSide");
            Param.Ignore(previousPrecedence);
            Param.Ignore(unsafeCode);

            LogicalExpression expression = null;

            // Read the details of the expression.
            OperatorSymbol operatorToken = this.PeekOperatorToken();
            Debug.Assert(operatorToken.Category == OperatorCategory.Logical, "Expected a logical operator");

            // Check the precedence of the operators to make sure we can gather this statement now.
            ExpressionPrecedence precedence = this.GetOperatorPrecedence(operatorToken.SymbolType);
            if (this.CheckPrecedence(previousPrecedence, precedence))
            {
                // Add the operator token to the document and advance the symbol manager up to it.
                this.symbols.Advance();
                this.tokens.Add(operatorToken);

                // Get the expression on the right-hand side of the operator.
                Expression rightHandSide = this.GetOperatorRightHandExpression(precedence, unsafeCode);

                // Create the partial token list for the expression.
                CsTokenList partialTokens = new CsTokenList(this.tokens, leftHandSide.Tokens.First, this.tokens.Last);

                // Get the expression operator type.
                LogicalExpression.Operator type;
                switch (operatorToken.SymbolType)
                {
                    case OperatorType.LogicalAnd:
                        type = LogicalExpression.Operator.And;
                        break;

                    case OperatorType.LogicalOr:
                        type = LogicalExpression.Operator.Or;
                        break;

                    case OperatorType.LogicalXor:
                        type = LogicalExpression.Operator.Xor;
                        break;

                    default:
                        Debug.Fail("Unexpected operator type");
                        throw new InvalidOperationException();
                }

                // Create and return the expression.
                expression = new LogicalExpression(partialTokens, type, leftHandSide, rightHandSide);
            }

            return expression;
        }

        /// <summary>
        /// Reads a conditional logical expression.
        /// </summary>
        /// <param name="leftHandSide">The expression on the left hand side of the operator.</param>
        /// <param name="previousPrecedence">The precedence of the expression just before this one.</param>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <returns>Returns the expression.</returns>
        private ConditionalLogicalExpression GetConditionalLogicalExpression(
            Expression leftHandSide, ExpressionPrecedence previousPrecedence, bool unsafeCode)
        {
            Param.AssertNotNull(leftHandSide, "leftHandSide");
            Param.Ignore(previousPrecedence);
            Param.Ignore(unsafeCode);

            ConditionalLogicalExpression expression = null;

            // Read the details of the expression.
            OperatorSymbol operatorToken = this.PeekOperatorToken();
            Debug.Assert(operatorToken.Category == OperatorCategory.Logical, "Expected a logical operator");

            // Check the precedence of the operators to make sure we can gather this statement now.
            ExpressionPrecedence precedence = this.GetOperatorPrecedence(operatorToken.SymbolType);
            if (this.CheckPrecedence(previousPrecedence, precedence))
            {
                // Add the operator token to the document and advance the symbol manager up to it.
                this.symbols.Advance();
                this.tokens.Add(operatorToken);

                // Get the expression on the right-hand side of the operator.
                Expression rightHandSide = this.GetOperatorRightHandExpression(precedence, unsafeCode);

                // Create the partial token list for the expression.
                CsTokenList partialTokens = new CsTokenList(this.tokens, leftHandSide.Tokens.First, this.tokens.Last);

                // Get the expression operator type.
                ConditionalLogicalExpression.Operator type;
                switch (operatorToken.SymbolType)
                {
                    case OperatorType.ConditionalAnd:
                        type = ConditionalLogicalExpression.Operator.And;
                        break;

                    case OperatorType.ConditionalOr:
                        type = ConditionalLogicalExpression.Operator.Or;
                        break;

                    default:
                        Debug.Fail("Unexpected operator type");
                        throw new InvalidOperationException();
                }

                // Create and return the expression.
                expression = new ConditionalLogicalExpression(partialTokens, type, leftHandSide, rightHandSide);
            }

            return expression;
        }

        /// <summary>
        /// Reads a null coalescing expression.
        /// </summary>
        /// <param name="leftHandSide">The expression on the left hand side of the operator.</param>
        /// <param name="previousPrecedence">The precedence of the expression just before this one.</param>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <returns>Returns the expression.</returns>
        private NullCoalescingExpression GetNullCoalescingExpression(
            Expression leftHandSide, ExpressionPrecedence previousPrecedence, bool unsafeCode)
        {
            Param.AssertNotNull(leftHandSide, "leftHandSide");
            Param.Ignore(previousPrecedence);
            Param.Ignore(unsafeCode);

            NullCoalescingExpression expression = null;

            // Read the details of the expression.
            OperatorSymbol operatorToken = this.PeekOperatorToken();
            Debug.Assert(operatorToken.SymbolType == OperatorType.NullCoalescingSymbol, "Expected a null-coalescing symbol");

            // Check the precedence of the operators to make sure we can gather this statement now.
            ExpressionPrecedence precedence = this.GetOperatorPrecedence(operatorToken.SymbolType);
            if (this.CheckPrecedence(previousPrecedence, precedence))
            {
                // Add the operator token to the document and advance the symbol manager up to it.
                this.symbols.Advance();
                this.tokens.Add(operatorToken);

                // Get the expression on the right-hand side of the operator.
                Expression rightHandSide = this.GetOperatorRightHandExpression(precedence, unsafeCode);

                // Create the partial token list for the expression.
                CsTokenList partialTokens = new CsTokenList(this.tokens, leftHandSide.Tokens.First, this.tokens.Last);

                // Create and return the expression.
                expression = new NullCoalescingExpression(partialTokens, leftHandSide, rightHandSide);
            }

            return expression;
        }

        /// <summary>
        /// Reads and an operator token.
        /// </summary>
        /// <returns>Returns the token.</returns>
        private OperatorSymbol GetOperatorToken()
        {
            OperatorSymbol token = this.PeekOperatorToken();
            this.symbols.Advance();

            return token;
        }

        /// <summary>
        /// Reads an operator token.
        /// </summary>
        /// <returns>Returns the token.</returns>
        private OperatorSymbol PeekOperatorToken()
        {
            // Get the operator symbol.
            Symbol operatorSymbol = this.GetNextSymbol();

            // Convert it to a token and add it to the document.
            OperatorSymbol operatorToken = this.CreateOperatorToken(operatorSymbol, this.symbols.Generated);
            if (operatorToken == null)
            {
                throw this.CreateSyntaxException();
            }

            return operatorToken;
        }

        /// <summary>
        /// Reads and returns the right-hand expression of an operator expression.
        /// </summary>
        /// <param name="precedence">The precendence of this operator expression.</param>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <returns>Returns the expression.</returns>
        private Expression GetOperatorRightHandExpression(ExpressionPrecedence precedence, bool unsafeCode)
        {
            Param.AssertNotNull(precedence, "precedence");
            Param.Ignore(unsafeCode);

            // Get the right hand expression.
            Expression rightHandSide = this.GetNextExpression(precedence, unsafeCode);
            if (rightHandSide == null)
            {
                throw this.CreateSyntaxException();
            }

            // Make sure the right hand side has at least one token.
            Debug.Assert(rightHandSide.Tokens.First != null, "The right-hand side should not be empty.");

            return rightHandSide;
        }

        /// <summary>
        /// Reads a checked expression from the code.
        /// </summary>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <returns>Returns the expression.</returns>
        private CheckedExpression GetCheckedExpression(bool unsafeCode)
        {
            Param.Ignore(unsafeCode);

            // Get the checked keyword.
            Node<CsToken> firstTokenNode = this.tokens.InsertLast(
                this.GetToken(CsTokenType.Checked, SymbolType.Checked));

            // The next symbol will be the opening parenthesis.
            Bracket openParenthesis = this.GetBracketToken(CsTokenType.OpenParenthesis, SymbolType.OpenParenthesis);
            Node<CsToken> openParenthesisNode = this.tokens.InsertLast(openParenthesis);

            // Get the inner expression.
            Expression innerExpression = this.GetNextExpression(ExpressionPrecedence.None, unsafeCode);

            // Get the closing parenthesis.
            Bracket closeParenthesis = this.GetBracketToken(CsTokenType.CloseParenthesis, SymbolType.CloseParenthesis);
            Node<CsToken> closeParenthesisNode = this.tokens.InsertLast(closeParenthesis);

            openParenthesis.MatchingBracketNode = closeParenthesisNode;
            closeParenthesis.MatchingBracketNode = openParenthesisNode;

            // Create the token list for the method invocation expression.
            CsTokenList partialTokens = new CsTokenList(this.tokens, firstTokenNode, this.tokens.Last);

            // Create and return the expression.
            return new CheckedExpression(partialTokens, innerExpression);
        }

        /// <summary>
        /// Reads an unchecked expression from the code.
        /// </summary>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <returns>Returns the expression.</returns>
        private UncheckedExpression GetUncheckedExpression(bool unsafeCode)
        {
            Param.Ignore(unsafeCode);

            // Get the unchecked keyword.
            Node<CsToken> firstTokenNode = this.tokens.InsertLast(
                this.GetToken(CsTokenType.Unchecked, SymbolType.Unchecked));

            // The next symbol will be the opening parenthesis.
            Bracket openParenthesis = this.GetBracketToken(CsTokenType.OpenParenthesis, SymbolType.OpenParenthesis);
            Node<CsToken> openParenthesisNode = this.tokens.InsertLast(openParenthesis);

            // Get the inner expression.
            Expression innerExpression = this.GetNextExpression(ExpressionPrecedence.None, unsafeCode);

            // Get the closing parenthesis.
            Bracket closeParenthesis = this.GetBracketToken(CsTokenType.CloseParenthesis, SymbolType.CloseParenthesis);
            Node<CsToken> closeParenthesisNode = this.tokens.InsertLast(closeParenthesis);

            openParenthesis.MatchingBracketNode = closeParenthesisNode;
            closeParenthesis.MatchingBracketNode = openParenthesisNode;

            // Create the token list for the method invocation expression.
            CsTokenList partialTokens = new CsTokenList(this.tokens, firstTokenNode, this.tokens.Last);

            // Create and return the expression.
            return new UncheckedExpression(partialTokens, innerExpression);
        }

        /// <summary>
        /// Reads a new allocation expression from the code.
        /// </summary>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <returns>Returns the expression.</returns>
        private Expression GetNewAllocationExpression(bool unsafeCode)
        {
            Param.Ignore(unsafeCode);

            // The first symbol must be the new keyword.
            Node<CsToken> firstTokenNode = this.tokens.InsertLast(this.GetToken(CsTokenType.New, SymbolType.New));

            // The next token must be a type identifier, or an opening curly bracket for an anonymous type creation, 
            // or an opening square bracket for a implicitly typed array creation.
            Symbol symbol = this.GetNextSymbol();
            if (symbol.SymbolType == SymbolType.OpenCurlyBracket)
            {
                return this.GetNewAnonymousTypeExpression(unsafeCode, firstTokenNode);
            }
            else if (symbol.SymbolType == SymbolType.OpenSquareBracket)
            {
                return this.GetNewArrayTypeExpression(unsafeCode, firstTokenNode, null);
            }
            else if (symbol.SymbolType != SymbolType.Other)
            {
                throw this.CreateSyntaxException();
            }

            // Get the type expression.
            Expression type = this.GetTypeTokenExpression(unsafeCode, false, false);
            if (type == null || type.Tokens.First == null)
            {
                throw this.CreateSyntaxException();
            }

            // Figure out the type of the new expression. If we hit an open parenthesis first,
            // then this is standard new type expression. If we hit an open square bracket first,
            // then this is a new array expression. If we hit an opening curly bracket first,
            // then this is a new expression which omits the argument list and uses an object 
            // or collection initializer.
            symbol = this.GetNextSymbol();

            // If this is a new array expression, get and return it.
            if (symbol.SymbolType == SymbolType.OpenSquareBracket)
            {
                return this.GetNewArrayTypeExpression(unsafeCode, firstTokenNode, type);
            }

            return this.GetNewNonArrayTypeExpression(unsafeCode, firstTokenNode, type);
        }

        /// <summary>
        /// Reads a new non-array type allocation expression from the code.
        /// </summary>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <param name="firstTokenNode">The first token in the expression.</param>
        /// <param name="type">The type of the array.</param>
        /// <returns>Returns the expression.</returns>
        private NewExpression GetNewNonArrayTypeExpression(
            bool unsafeCode, Node<CsToken> firstTokenNode, Expression type)
        {
            Param.Ignore(unsafeCode);
            Param.AssertNotNull(firstTokenNode, "firstTokenNode");
            Param.AssertNotNull(type, "type");

            Expression typeCreationExpression = type;

            // If the next symbol is an opening parenthesis, then there is an argument
            // list which must be attached to the type creation expression.
            Symbol symbol = this.GetNextSymbol();

            if (symbol.SymbolType == SymbolType.OpenParenthesis)
            {
                typeCreationExpression = this.GetMethodInvocationExpression(type, ExpressionPrecedence.None, unsafeCode);
                if (typeCreationExpression == null || typeCreationExpression.Tokens.First == null)
                {
                    throw this.CreateSyntaxException();
                }
            }

            // If the next symbol is an opening curly bracket, then there is an object
            // or collection initializer attached which must also be parsed.
            symbol = this.GetNextSymbol();

            Expression initializer = null;
            if (symbol.SymbolType == SymbolType.OpenCurlyBracket)
            {
                initializer = this.GetObjectOrCollectionInitializerExpression(unsafeCode);

                if (initializer == null || initializer.Tokens.First == null)
                {
                    throw this.CreateSyntaxException();
                }
            }

            // Create the token list for the expression.
            CsTokenList partialTokens = new CsTokenList(this.tokens, firstTokenNode, this.tokens.Last);

            // Create and return the expression.
            return new NewExpression(partialTokens, typeCreationExpression, initializer);
        }

        /// <summary>
        /// Reads a new anonymous type allocation expression from the code.
        /// </summary>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <param name="firstTokenNode">The first token in the expression.</param>
        /// <returns>Returns the expression.</returns>
        private NewExpression GetNewAnonymousTypeExpression(bool unsafeCode, Node<CsToken> firstTokenNode)
        {
            Param.Ignore(unsafeCode);
            Param.AssertNotNull(firstTokenNode, "firstTokenNode");

            // Get the anonymous type initializer expression.
            CollectionInitializerExpression initializer = this.GetAnonymousTypeInitializerExpression(unsafeCode);

            // Create the token list for the expression.
            CsTokenList partialTokens = new CsTokenList(this.tokens, firstTokenNode, initializer.Tokens.Last);

            // Create and return the expression.
            return new NewExpression(partialTokens, null, initializer);
        }

        /// <summary>
        /// Reads an anonymous type initializer expression from the code.
        /// </summary>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <returns>Returns the expression.</returns>
        private CollectionInitializerExpression GetAnonymousTypeInitializerExpression(bool unsafeCode)
        {
            Param.Ignore(unsafeCode);

            // If the next symbol is an opening curly bracket, then there is an object
            // or collection initializer attached which must also be parsed.
            this.GetNextSymbol(SymbolType.OpenCurlyBracket);

            CollectionInitializerExpression initializer = this.GetCollectionInitializerExpression(unsafeCode);

            if (initializer == null || initializer.Tokens.First == null)
            {
                throw this.CreateSyntaxException();
            }

            // Ensure that all of the initializer expressions are either simple literals,
            // member access expressions, or assignment expressions, since these are the
            // only types of expressions allowed within an anonymous type definition.
            foreach (Expression initializerExpression in initializer.ChildExpressions)
            {
                if (initializerExpression.ExpressionType != ExpressionType.Literal &&
                    initializerExpression.ExpressionType != ExpressionType.MemberAccess &&
                    initializerExpression.ExpressionType != ExpressionType.Assignment)
                {
                    throw this.CreateSyntaxException();
                }
            }

            return initializer;
        }

        /// <summary>
        /// Reads a new array allocation expression from the code.
        /// </summary>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <param name="firstTokenNode">The first token in the expression.</param>
        /// <param name="type">The type of the array. This may be null for an implicitly typed array.</param>
        /// <returns>Returns the expression.</returns>
        private NewArrayExpression GetNewArrayTypeExpression(
            bool unsafeCode, Node<CsToken> firstTokenNode, Expression type)
        {
            Param.Ignore(unsafeCode);
            Param.AssertNotNull(firstTokenNode, "firstTokenNode");
            Param.Ignore(type);

            // Get the next symbol.
            Symbol symbol = this.GetNextSymbol(SymbolType.OpenSquareBracket);

            // If the type is null, then this is an implicitly typed array and we will only find
            // array brackets here. Otherwise, we must get the array access expression which includes the type.
            if (type == null)
            {
                this.MovePastArrayBrackets();
            }
            else
            {
                // Get all of the array access expressions.
                while (symbol.SymbolType == SymbolType.OpenSquareBracket)
                {
                    type = this.GetArrayAccessExpression(type, ExpressionPrecedence.None, unsafeCode);
                    if (type == null || type.Tokens.First == null)
                    {
                        throw this.CreateSyntaxException();
                    }

                    symbol = this.GetNextSymbol();
                }
            }

            // Make sure there was at least one array access.
            if (type != null && type.ExpressionType != ExpressionType.ArrayAccess)
            {
                throw this.CreateSyntaxException();
            }

            // Get the next symbol and check the type.
            symbol = this.GetNextSymbol();

            // Get the initializer if there is one.
            ArrayInitializerExpression initializer = null;
            if (symbol.SymbolType == SymbolType.OpenCurlyBracket)
            {
                initializer = this.GetArrayInitializerExpression(unsafeCode);
            }

            // For an implicitly typed array, an array initializer is required.
            if (type == null && initializer == null)
            {
                throw this.CreateSyntaxException();
            }

            // Create the token list for the new array expression.
            CsTokenList partialTokens = new CsTokenList(this.tokens, firstTokenNode, this.tokens.Last);

            // Create and return the expression.
            return new NewArrayExpression(partialTokens, type as ArrayAccessExpression, initializer);
        }

        /// <summary>
        /// Moves past all array brackets. This assumes that the brackets are part of a new array allocation.
        /// </summary>
        private void MovePastArrayBrackets()
        {
            // The next symbol must be an opening array bracket.
            Symbol symbol = this.GetNextSymbol(SymbolType.OpenSquareBracket);

            while (symbol.SymbolType == SymbolType.OpenSquareBracket)
            {
                // Add the opening array bracket.
                Bracket openingBracket = this.GetBracketToken(CsTokenType.OpenSquareBracket, SymbolType.OpenSquareBracket);
                Node<CsToken> openingBracketNode = this.tokens.InsertLast(openingBracket);

                // Get the next symbol.
                symbol = this.GetNextSymbol();

                // Move past any commas.
                while (symbol.SymbolType == SymbolType.Comma)
                {
                    this.tokens.Add(this.GetToken(CsTokenType.Comma, SymbolType.Comma));
                    symbol = this.GetNextSymbol();
                }

                // Add the closing array bracket.
                Bracket closingBracket = this.GetBracketToken(CsTokenType.CloseSquareBracket, SymbolType.CloseSquareBracket);
                Node<CsToken> closingBracketNode = this.tokens.InsertLast(closingBracket);

                openingBracket.MatchingBracketNode = closingBracketNode;
                closingBracket.MatchingBracketNode = openingBracketNode;

                // If the next symbol is another opening square bracket, repeat.
                symbol = this.GetNextSymbol();
            }
        }

        /// <summary>
        /// Gets an object initializer or collection initializer expression.
        /// </summary>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <returns>Returns the expression.</returns>
        private Expression GetObjectOrCollectionInitializerExpression(bool unsafeCode)
        {
            Param.Ignore(unsafeCode);

            Symbol symbol = this.GetNextSymbol(SymbolType.OpenCurlyBracket);

            // Determine whether this is an object initializer or a collection initializer.
            bool objectInitializer = false;

            // Peek at the next symbol after the curly bracket.
            int index = this.GetNextCodeSymbolIndex(2);
            if (index == -1)
            {
                throw this.CreateSyntaxException();
            }

            symbol = this.symbols.Peek(index);
            Debug.Assert(symbol != null, "The next symbol should not be null");

            if (symbol.SymbolType == SymbolType.Other)
            {
                // Peek at the symbol after this to see if it is an equals sign.
                index = this.GetNextCodeSymbolIndex(index + 1);
                if (index != -1)
                {
                    symbol = this.symbols.Peek(index);
                    Debug.Assert(symbol != null, "The next symbol should not be null");

                    if (symbol.SymbolType == SymbolType.Equals)
                    {
                        objectInitializer = true;
                    }
                }
            }

            if (objectInitializer)
            {
                return this.GetObjectInitializerExpression(unsafeCode);
            }
            else
            {
                return this.GetCollectionInitializerExpression(unsafeCode);
            }
        }

        /// <summary>
        /// Gets an object initializer expression.
        /// </summary>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <returns>Returns the expression.</returns>
        private ObjectInitializerExpression GetObjectInitializerExpression(bool unsafeCode)
        {
            Param.Ignore(unsafeCode);

            List<AssignmentExpression> initializerExpressions = new List<AssignmentExpression>();

            // Add and move past the opening curly bracket.
            Bracket openingBracket = this.GetBracketToken(CsTokenType.OpenCurlyBracket, SymbolType.OpenCurlyBracket);
            Node<CsToken> openingBracketNode = this.tokens.InsertLast(openingBracket);

            while (true)
            {
                // If the next symbol is the closing curly bracket, then we are done.
                Symbol symbol = this.GetNextSymbol();
                if (symbol.SymbolType == SymbolType.CloseCurlyBracket)
                {
                    break;
                }

                // Get the identifier.
                LiteralExpression identifier = this.GetLiteralExpression(unsafeCode);

                // Get the equals sign.
                symbol = this.GetNextSymbol();
                if (symbol.SymbolType != SymbolType.Equals)
                {
                    throw this.CreateSyntaxException();
                }

                this.tokens.Add(this.GetOperatorToken(OperatorType.Equals));

                // Get the initializer value. If this begins with an opening curly bracket,
                // this is an embedded object or collection initializer. Otherwise, it is
                // some other kind of expression.
                Expression initializerValue = null;

                symbol = this.GetNextSymbol();
                if (symbol.SymbolType == SymbolType.OpenCurlyBracket)
                {
                    initializerValue = this.GetObjectOrCollectionInitializerExpression(unsafeCode);
                }
                else
                {
                    initializerValue = this.GetNextExpression(ExpressionPrecedence.None, unsafeCode);
                }

                // Create and add this initializer.
                CsTokenList initializerTokens = new CsTokenList(this.tokens, identifier.Tokens.First, initializerValue.Tokens.Last);
                initializerExpressions.Add(new AssignmentExpression(
                    initializerTokens, AssignmentExpression.Operator.Equals, identifier, initializerValue));

                // Check whether we're done.
                symbol = this.GetNextSymbol();
                if (symbol.SymbolType == SymbolType.Comma)
                {
                    this.tokens.Add(this.GetToken(CsTokenType.Comma, SymbolType.Comma));

                    // If the next symbol after this is the closing curly bracket, then we are done.
                    symbol = this.GetNextSymbol();
                    if (symbol.SymbolType == SymbolType.CloseCurlyBracket)
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
            }

            // Add and move past the closing curly bracket.
            Bracket closingBracket = this.GetBracketToken(CsTokenType.CloseCurlyBracket, SymbolType.CloseCurlyBracket);
            Node<CsToken> closingBracketNode = this.tokens.InsertLast(closingBracket);

            openingBracket.MatchingBracketNode = closingBracketNode;
            closingBracket.MatchingBracketNode = openingBracketNode;

            // Create the token list for the overall expression.
            CsTokenList expressionTokens = new CsTokenList(this.tokens, openingBracketNode, closingBracketNode);

            // Create and return the expression.
            return new ObjectInitializerExpression(expressionTokens, initializerExpressions.ToArray());
        }

        /// <summary>
        /// Gets a collection initializer expression.
        /// </summary>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <returns>Returns the expression.</returns>
        private CollectionInitializerExpression GetCollectionInitializerExpression(bool unsafeCode)
        {
            Param.Ignore(unsafeCode);

            List<Expression> expressions = new List<Expression>();

            // Add and move past the opening curly bracket.
            Bracket openingBracket = this.GetBracketToken(CsTokenType.OpenCurlyBracket, SymbolType.OpenCurlyBracket);
            Node<CsToken> openingBracketNode = this.tokens.InsertLast(openingBracket);

            while (true)
            {
                // If the next symbol is the closing curly bracket, then we are done.
                Symbol symbol = this.GetNextSymbol();
                if (symbol.SymbolType == SymbolType.CloseCurlyBracket)
                {
                    break;
                }

                // Get the next expression.
                Expression expression = null;
                if (symbol.SymbolType == SymbolType.OpenCurlyBracket)
                {
                    expression = this.GetCollectionInitializerExpression(unsafeCode);
                }
                else
                {
                    expression = this.GetNextExpression(ExpressionPrecedence.None, unsafeCode);
                }

                expressions.Add(expression);

                // Check whether we're done.
                symbol = this.GetNextSymbol();
                if (symbol.SymbolType == SymbolType.Comma)
                {
                    this.tokens.Add(this.GetToken(CsTokenType.Comma, SymbolType.Comma));

                    // If the next symbol after this is the closing curly bracket, then we are done.
                    symbol = this.GetNextSymbol();
                    if (symbol.SymbolType == SymbolType.CloseCurlyBracket)
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
            }

            // Add and move past the closing curly bracket.
            Bracket closingBracket = this.GetBracketToken(CsTokenType.CloseCurlyBracket, SymbolType.CloseCurlyBracket);
            Node<CsToken> closingBracketNode = this.tokens.InsertLast(closingBracket);

            openingBracket.MatchingBracketNode = closingBracketNode;
            closingBracket.MatchingBracketNode = openingBracketNode;

            // Create the token list for the overall expression.
            CsTokenList expressionTokens = new CsTokenList(this.tokens, openingBracketNode, closingBracketNode);

            // Create and return the expression.
            return new CollectionInitializerExpression(expressionTokens, expressions);
        }

        /// <summary>
        /// Reads a stackalloc expression from the code.
        /// </summary>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <returns>Returns the expression.</returns>
        private StackallocExpression GetStackallocExpression(bool unsafeCode)
        {
            Param.Ignore(unsafeCode);

            // The first symbol must be the new keyword.
            Node<CsToken> firstTokenNode = this.tokens.InsertLast(
                this.GetToken(CsTokenType.Stackalloc, SymbolType.Stackalloc));

            // The next token must be the type identifier.
            this.GetNextSymbol(SymbolType.Other);

            // Get the type expression.
            Expression type = this.GetTypeTokenExpression(unsafeCode, false, false);
            if (type == null || type.Tokens.First == null)
            {
                throw this.CreateSyntaxException();
            }

            // Get the array access expression.
            ArrayAccessExpression arrayAccess = this.GetArrayAccessExpression(type, ExpressionPrecedence.None, unsafeCode);
            if (arrayAccess == null || arrayAccess.Tokens.First == null)
            {
                throw this.CreateSyntaxException();
            }

            // Create the token list for the new array expression.
            CsTokenList partialTokens = new CsTokenList(this.tokens, firstTokenNode, this.tokens.Last);

            // Create and return the expression.
            return new StackallocExpression(partialTokens, arrayAccess);
        }

        /// <summary>
        /// Reads a sizeof expression from the code.
        /// </summary>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <returns>Returns the expression.</returns>
        private SizeofExpression GetSizeofExpression(bool unsafeCode)
        {
            Param.Ignore(unsafeCode);

            // Get the sizeof keyword.
            Node<CsToken> firstTokenNode = this.tokens.InsertLast(this.GetToken(CsTokenType.Sizeof, SymbolType.Sizeof));

            // The next symbol will be the opening parenthesis.
            Bracket openParenthesis = this.GetBracketToken(CsTokenType.OpenParenthesis, SymbolType.OpenParenthesis);
            Node<CsToken> openParenthesisNode = this.tokens.InsertLast(openParenthesis);

            // Get the inner expression representing the type.
            Expression expression = this.GetTypeTokenExpression(unsafeCode, true, false);
            if (expression == null)
            {
                throw this.CreateSyntaxException();
            }

            // Get the closing parenthesis.
            Bracket closeParenthesis = this.GetBracketToken(CsTokenType.CloseParenthesis, SymbolType.CloseParenthesis);
            Node<CsToken> closeParenthesisNode = this.tokens.InsertLast(closeParenthesis);

            openParenthesis.MatchingBracketNode = closeParenthesisNode;
            closeParenthesis.MatchingBracketNode = openParenthesisNode;

            // Create the token list for the method invocation expression.
            CsTokenList partialTokens = new CsTokenList(this.tokens, firstTokenNode, this.tokens.Last);

            // Create and return the expression.
            return new SizeofExpression(partialTokens, expression);
        }

        /// <summary>
        /// Reads a typeof expression from the code.
        /// </summary>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <returns>Returns the expression.</returns>
        private TypeofExpression GetTypeofExpression(bool unsafeCode)
        {
            Param.Ignore(unsafeCode);

            // Get the typeof keyword.
            Node<CsToken> firstTokenNode = this.tokens.InsertLast(this.GetToken(CsTokenType.Typeof, SymbolType.Typeof));

            // The next symbol will be the opening parenthesis.
            Bracket openParenthesis = this.GetBracketToken(CsTokenType.OpenParenthesis, SymbolType.OpenParenthesis);
            Node<CsToken> openParenthesisNode = this.tokens.InsertLast(openParenthesis);

            // Get the inner expression representing the type.
            LiteralExpression expression = this.GetTypeTokenExpression(unsafeCode, true, false);
            if (expression == null)
            {
                throw this.CreateSyntaxException();
            }

            // Get the closing parenthesis.
            Bracket closeParenthesis = this.GetBracketToken(CsTokenType.CloseParenthesis, SymbolType.CloseParenthesis);
            Node<CsToken> closeParenthesisNode = this.tokens.InsertLast(closeParenthesis);

            openParenthesis.MatchingBracketNode = closeParenthesisNode;
            closeParenthesis.MatchingBracketNode = openParenthesisNode;

            // Create the token list for the method invocation expression.
            CsTokenList partialTokens = new CsTokenList(this.tokens, firstTokenNode, this.tokens.Last);

            // Create and return the expression.
            return new TypeofExpression(partialTokens, expression);
        }

        /// <summary>
        /// Reads a default value expression from the code.
        /// </summary>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <returns>Returns the expression.</returns>
        private DefaultValueExpression GetDefaultValueExpression(bool unsafeCode)
        {
            Param.Ignore(unsafeCode);

           // Get the default keyword.
            Node<CsToken> firstTokenNode = this.tokens.InsertLast(
                this.GetToken(CsTokenType.DefaultValue, SymbolType.Default));

            // The next symbol will be the opening parenthesis.
            Bracket openParenthesis = this.GetBracketToken(CsTokenType.OpenParenthesis, SymbolType.OpenParenthesis);
            Node<CsToken> openParenthesisNode = this.tokens.InsertLast(openParenthesis);

            // Get the inner expression.
            LiteralExpression expression = this.GetTypeTokenExpression(unsafeCode, false, false);
            if (expression == null)
            {
                throw this.CreateSyntaxException();
            }

            // Get the closing parenthesis.
            Bracket closeParenthesis = this.GetBracketToken(CsTokenType.CloseParenthesis, SymbolType.CloseParenthesis);
            Node<CsToken> closeParenthesisNode = this.tokens.InsertLast(closeParenthesis);

            openParenthesis.MatchingBracketNode = closeParenthesisNode;
            closeParenthesis.MatchingBracketNode = openParenthesisNode;

            // Create the token list for the method invocation expression.
            CsTokenList partialTokens = new CsTokenList(this.tokens, firstTokenNode, this.tokens.Last);

            // Create and return the expression.
            return new DefaultValueExpression(partialTokens, expression);
        }

        /// <summary>
        /// Reads an anonymous method from the code.
        /// </summary>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <returns>Returns the expression.</returns>
        private AnonymousMethodExpression GetAnonymousMethodExpression(bool unsafeCode)
        {
            Param.Ignore(unsafeCode);

            // Get the delegate keyword.
            Node<CsToken> firstTokenNode = this.tokens.InsertLast(this.GetToken(CsTokenType.Delegate, SymbolType.Delegate));

            // Check whether the next symbol is an opening parenthesis.
            Symbol symbol = this.GetNextSymbol();

            ICollection<Parameter> parameters = null;
            if (symbol.SymbolType == SymbolType.OpenParenthesis)
            {
                parameters = this.ParseAnonymousMethodParameterList(unsafeCode);
            }

            // Create the anonymous method object now.
            AnonymousMethodExpression anonymousMethod = new AnonymousMethodExpression();

            // The next symbol must be an opening curly bracket.
            Bracket openingBracket = this.GetBracketToken(CsTokenType.OpenCurlyBracket, SymbolType.OpenCurlyBracket);
            Node<CsToken> openingBracketNode = this.tokens.InsertLast(openingBracket);

            // Read the child statements.
            Node<CsToken> closingBracketNode = this.ParseStatementScope(anonymousMethod, unsafeCode);
            
            if (closingBracketNode == null)
            {
                // If we failed to get a closing bracket back, then there is a syntax
                // error in the document since there is an opening bracket with no matching
                // closing bracket.
                throw this.CreateSyntaxException();
            }

            openingBracket.MatchingBracketNode = closingBracketNode;
            ((Bracket)closingBracketNode.Value).MatchingBracketNode = openingBracketNode;

            // Create the token list for the anonymous method expression.
            anonymousMethod.Tokens = new CsTokenList(this.tokens, firstTokenNode, this.tokens.Last);

            // Get the item's argument list if necessary.
            if (parameters != null && parameters.Count > 0)
            {
                anonymousMethod.AddParameters(parameters);
            }

            // Add a variable for each of the parameters.
            if (anonymousMethod.Parameters != null && anonymousMethod.Parameters.Count > 0)
            {
                // Add a variable for each of the parameters.
                foreach (Parameter parameter in anonymousMethod.Parameters)
                {
                    anonymousMethod.Variables.Add(new Variable(
                        parameter.Type, parameter.Name, VariableModifiers.None, parameter.Location.StartPoint));
                }
            }

            // Return the expression.
            return anonymousMethod;
        }

        /// <summary>
        /// Determines whether the next expression is a lambda expression.
        /// </summary>
        /// <returns>Returns true if the next expression is a lambda expression.</returns>
        private bool IsLambdaExpression()
        {
            int index = 1;
            Symbol symbol = this.symbols.Peek(index);

            if (symbol.SymbolType == SymbolType.OpenParenthesis)
            {
                // Advance to the closing parenthesis.
                int parenthesisCount = 0;
                
                for (; true; ++index)
                {
                    symbol = this.symbols.Peek(index);
                    if (symbol == null)
                    {
                        break;
                    }
                    else if (symbol.SymbolType == SymbolType.OpenParenthesis)
                    {
                        ++parenthesisCount;
                    }
                    else if (symbol.SymbolType == SymbolType.CloseParenthesis)
                    {
                        --parenthesisCount;
                        if (parenthesisCount == 0)
                        {
                            break;
                        }
                    }
                }
            }
            else if (symbol.SymbolType != SymbolType.Other)
            {
                Debug.Fail("IsLambdaExpression called incorrectly.");
            }

            // Move past the current symbol, which is either an "other" symbol or a closing parenthesis.
            ++index;

            // Advance to the next non-whitespace symbol.
            for (; true; ++index)
            {
                symbol = this.symbols.Peek(index);
                if (symbol == null)
                {
                    break;
                }

                if (symbol.SymbolType == SymbolType.Lambda)
                {
                    return true;
                }

                if (symbol.SymbolType != SymbolType.EndOfLine &&
                    symbol.SymbolType != SymbolType.WhiteSpace &&
                    symbol.SymbolType != SymbolType.MultiLineComment &&
                    symbol.SymbolType != SymbolType.SingleLineComment)
                {
                    break;
                }
            }

            return false;
        }

        /// <summary>
        /// Reads a lambda expression.
        /// </summary>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <returns>Returns the expression.</returns>
        private LambdaExpression GetLambdaExpression(bool unsafeCode)
        {
            Param.Ignore(unsafeCode);

            // Create an empty lambda expression.
            LambdaExpression lambdaExpression = new LambdaExpression();

            // Check whether the next symbol is an opening parenthesis.
            Symbol symbol = this.GetNextSymbol();

            Node<CsToken> previousTokenNode = this.tokens.Last;
            ICollection<Parameter> parameters = null;

            if (symbol.SymbolType == SymbolType.OpenParenthesis)
            {
                parameters = this.ParseAnonymousMethodParameterList(unsafeCode);
            }
            else
            {
                // Since the statement did not begin with an opening parenthesis,
                // it must begin with a single unknown symbol.
                if (symbol.SymbolType != SymbolType.Other)
                {
                    throw new SyntaxException(this.document.SourceCode, symbol.LineNumber);
                }

                CsToken token = this.GetToken(CsTokenType.Other, SymbolType.Other);
                this.tokens.Add(token);

                // Add the single parameter.
                lambdaExpression.AddParameter(new Parameter(
                    null, 
                    token.Text, 
                    ParameterModifiers.None, 
                    token.Location,
                    new CsTokenList(this.tokens, this.tokens.Last, this.tokens.Last)));
            }

            // Get the lambda operator.
            this.tokens.Add(this.GetOperatorToken(OperatorType.Lambda));

            // Get the body of the expression. This can either be an expression or a statement.
            // If it starts with an opening curly bracket, it's a statement, otherwise it's an expression.
            symbol = this.GetNextSymbol();

            if (symbol.SymbolType == SymbolType.OpenCurlyBracket)
            {
                lambdaExpression.AnonymousFunctionBody = this.GetNextStatement(unsafeCode);
            }
            else
            {
                lambdaExpression.AnonymousFunctionBody = this.GetNextExpression(ExpressionPrecedence.None, unsafeCode);
            }

            // Create the overall token list for the expression.
            Node<CsToken> firstNode = previousTokenNode == null ? this.tokens.First : previousTokenNode.Next;
            lambdaExpression.Tokens = new CsTokenList(this.tokens, firstNode, this.tokens.Last);

            // Get the item's argument list if necessary.
            if (parameters != null && parameters.Count > 0)
            {
                lambdaExpression.AddParameters(parameters);
            }

            // Add a variable for each of the parameters.
            if (lambdaExpression.Parameters != null && lambdaExpression.Parameters.Count > 0)
            {
                // Add a variable for each of the parameters.
                foreach (Parameter parameter in lambdaExpression.Parameters)
                {
                    lambdaExpression.Variables.Add(new Variable(
                        parameter.Type, parameter.Name, VariableModifiers.None, parameter.Location.StartPoint));
                }
            }

            // Return the expression.
            return lambdaExpression;
        }

        /// <summary>
        /// Determines whether the next expression is a query expression.
        /// </summary>
        /// <param name="unsafeCode">Indicates whether the code being parsed is unsafe.</param>
        /// <returns>Returns true if the next expression is a lambda expression.</returns>
        private bool IsQueryExpression(bool unsafeCode)
        {
            Param.Ignore(unsafeCode);

            int index = 1;
            Symbol symbol = this.symbols.Peek(index);
            if (symbol == null)
            {
                return false;
            }

            // A query expression must start with the word "from".
            if (symbol.SymbolType == SymbolType.Other && string.CompareOrdinal(symbol.Text, "from") == 0)
            {
                // Advance past this symbol.
                index = this.GetNextCodeSymbolIndex(index + 1);

                // The next item must either be a type or an identifier.
                int endIndex = -1;
                if (this.HasTypeSignature(index, unsafeCode, out endIndex))
                {
                    // Advance past this.
                    index = this.GetNextCodeSymbolIndex(endIndex + 1);

                    // The next symbol must either be the 'in' keyword or the identifier if the previous item is a type.
                    symbol = this.symbols.Peek(index);
                    if (symbol != null)
                    {
                        // If this symbol is an 'in' keyword, then this is a query expression.
                        if (symbol.SymbolType == SymbolType.In)
                        {
                            return true;
                        }

                        // The next symbol must be the type identifier.
                        if (symbol.SymbolType == SymbolType.Other)
                        {
                            // This symbol is the identifier. Most past it.
                            index = this.GetNextCodeSymbolIndex(index + 1);

                            // The next symbol must be the 'in' keyword.
                            symbol = this.symbols.Peek(index);
                            if (symbol != null && symbol.SymbolType == SymbolType.In)
                            {
                                return true;
                            }
                        }
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Reads a query expression.
        /// </summary>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides 
        /// in an unsafe code block.</param>
        /// <returns>Returns the expression.</returns>
        private QueryExpression GetQueryExpression(bool unsafeCode)
        {
            Param.Ignore(unsafeCode);

            // Ensure that the expression starts with the keyword 'from'.
            Symbol symbol = this.GetNextSymbol();

            Debug.Assert(
                symbol != null &&
                symbol.SymbolType == SymbolType.Other &&
                string.CompareOrdinal(symbol.Text, "from") == 0, 
                "Expected a from keyword");

            // Stores the list of clauses in the expression.
            List<QueryClause> clauses = new List<QueryClause>();
            
            // The variables defined by the clauses in this expression.
            List<Variable> variables = new List<Variable>();

            // Extract the clauses.
            CsTokenList clauseTokens = this.GetQueryExpressionClauses(unsafeCode, clauses, variables);
            if (clauses.Count == 0 || clauseTokens.First == null)
            {
                throw this.CreateSyntaxException();
            }

            // Create and return the expression.
            QueryExpression queryExpression = new QueryExpression(clauseTokens, clauses.ToArray());
            queryExpression.Variables.AddRange(variables);

            return queryExpression;
        }

        /// <summary>
        /// Gets the collection of query clauses.
        /// </summary>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides 
        /// in an unsafe code block.</param>
        /// <param name="clauses">The list in which to store the clauses.</param>
        /// <param name="variables">The list in which to store variables defined by the clauses.</param>
        /// <returns>Returns the list of this.tokens that make up the clauses.</returns>
        private CsTokenList GetQueryExpressionClauses(
            bool unsafeCode, List<QueryClause> clauses, List<Variable> variables)
        {
            Param.Ignore(unsafeCode);
            Param.AssertNotNull(clauses, "clauses");
            Param.AssertNotNull(variables, "variables");

            Node<CsToken> firstToken = null;

            while (true)
            {
                // Get the rest of the clauses.
                Symbol symbol = this.GetNextSymbol();
                if (symbol.SymbolType != SymbolType.Other)
                {
                    break;
                }

                QueryClause clause = null;

                switch (symbol.Text)
                {
                    case "from":
                        QueryFromClause fromClause = this.GetQueryFromClause(unsafeCode);
                        variables.Add(fromClause.RangeVariable);
                        clause = fromClause;
                        break;

                    case "let":
                        QueryLetClause letClause = this.GetQueryLetClause(unsafeCode);
                        variables.Add(letClause.RangeVariable);
                        clause = letClause;
                        break;

                    case "where":
                        clause = this.GetQueryWhereClause(unsafeCode);
                        break;

                    case "join":
                        QueryJoinClause joinClause = this.GetQueryJoinClause(unsafeCode);
                        variables.Add(joinClause.RangeVariable);

                        if (joinClause.IntoVariable != null)
                        {
                            variables.Add(joinClause.IntoVariable);
                        }

                        clause = joinClause;
                        break;

                    case "orderby":
                        clause = this.GetQueryOrderByClause(unsafeCode);
                        break;

                    case "select":
                        clause = this.GetQuerySelectClause(unsafeCode);
                        break;

                    case "group":
                        clause = this.GetQueryGroupClause(unsafeCode);
                        break;

                    case "into":
                        QueryContinuationClause continuationClause = this.GetQueryContinuationClause(unsafeCode);
                        variables.Add(continuationClause.Variable);
                        clause = continuationClause;
                        break;

                    default:
                        break;
                }

                if (clause == null)
                {
                    break;
                }

                if (firstToken == null)
                {
                    firstToken = clause.Tokens.First;
                }

                clauses.Add(clause);
            }

            if (firstToken == null)
            {
                throw this.CreateSyntaxException();
            }

            // Create and return the token list.
            return new CsTokenList(this.tokens, firstToken, this.tokens.Last);
        }

        /// <summary>
        /// Gets a query continuation clause.
        /// </summary>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides 
        /// in an unsafe code block.</param>
        /// <returns>Returns the query continuation clause.</returns>
        private QueryContinuationClause GetQueryContinuationClause(bool unsafeCode)
        {
            Param.Ignore(unsafeCode);

            // Get and add the 'into' symbol.
            Symbol symbol = this.GetNextSymbol(SymbolType.Other);
            Debug.Assert(symbol.Text == "into", "Expected an into keyword");

            Node<CsToken> firstTokenNode = this.tokens.InsertLast(this.GetToken(CsTokenType.Into, SymbolType.Other));

            // Get the identifier.
            Variable rangeVariable = this.GetVariable(unsafeCode, true, true);
            if (rangeVariable == null)
            {
                throw this.CreateSyntaxException();
            }

            // Get the continuation clauses.
            List<QueryClause> clauses = new List<QueryClause>();

            // The variables defined by the clauses under this continuation clause.
            List<Variable> variables = new List<Variable>();

            // Extract the clauses.
            CsTokenList continuationClauseTokens = this.GetQueryExpressionClauses(unsafeCode, clauses, variables);
            if (clauses.Count == 0 || continuationClauseTokens.First == null)
            {
                throw this.CreateSyntaxException();
            }

            // Create and return the clause.
            QueryContinuationClause continuationClause = new QueryContinuationClause(
                new CsTokenList(this.tokens, firstTokenNode, continuationClauseTokens.Last),
                rangeVariable,
                clauses.ToArray());

            continuationClause.Variables.AddRange(variables);

            return continuationClause;
        }

        /// <summary>
        /// Gets a query from clause.
        /// </summary>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides 
        /// in an unsafe code block.</param>
        /// <returns>Returns the query from clause.</returns>
        private QueryFromClause GetQueryFromClause(bool unsafeCode)
        {
            Param.Ignore(unsafeCode);

            // Get and add the 'from' symbol.
            Symbol symbol = this.GetNextSymbol(SymbolType.Other);
            Debug.Assert(symbol.Text == "from", "Expected a from keyword");

            Node<CsToken> firstTokenNode = this.tokens.InsertLast(this.GetToken(CsTokenType.From, SymbolType.Other));

            // Get the range variable.
            Variable rangeVariable = this.GetVariable(unsafeCode, true, false);
            if (rangeVariable == null)
            {
                throw this.CreateSyntaxException();
            }

            // The next symbol must be the 'in' keyword.
            this.tokens.Add(this.GetToken(CsTokenType.In, SymbolType.In));

            // Now get the from clause expression.
            Expression fromClauseExpression = this.GetNextExpression(ExpressionPrecedence.Query, unsafeCode);
            if (fromClauseExpression == null)
            {
                throw this.CreateSyntaxException();
            }

            // Create and return the clause.
            return new QueryFromClause(
                new CsTokenList(this.tokens, firstTokenNode, this.tokens.Last),
                rangeVariable,
                fromClauseExpression);
        }

        /// <summary>
        /// Gets a query let clause.
        /// </summary>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides 
        /// in an unsafe code block.</param>
        /// <returns>Returns the query let clause.</returns>
        private QueryLetClause GetQueryLetClause(bool unsafeCode)
        {
            Param.Ignore(unsafeCode);

            // Get and add the 'let' symbol.
            Symbol symbol = this.GetNextSymbol(SymbolType.Other);
            Debug.Assert(symbol.Text == "let", "Expected a let keyword");

            Node<CsToken> firstTokenNode = this.tokens.InsertLast(this.GetToken(CsTokenType.Let, SymbolType.Other));

            // Get the identifier.
            Variable rangeVariable = this.GetVariable(unsafeCode, true, true);
            if (rangeVariable == null)
            {
                throw this.CreateSyntaxException();
            }

            // The next symbol must be the = sign.
            this.tokens.Add(this.GetOperatorToken(OperatorType.Equals));

            // Now get the let clause expression.
            Expression letClauseExpression = this.GetNextExpression(ExpressionPrecedence.Query, unsafeCode);
            if (letClauseExpression == null)
            {
                throw this.CreateSyntaxException();
            }

            // Create and return the clause.
            return new QueryLetClause(
                new CsTokenList(this.tokens, firstTokenNode, this.tokens.Last),
                rangeVariable,
                letClauseExpression);
        }

        /// <summary>
        /// Gets a query where clause.
        /// </summary>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides 
        /// in an unsafe code block.</param>
        /// <returns>Returns the query where clause.</returns>
        private QueryWhereClause GetQueryWhereClause(bool unsafeCode)
        {
            Param.Ignore(unsafeCode);

            // Get and add the 'where' symbol.
            Symbol symbol = this.GetNextSymbol(SymbolType.Other);
            Debug.Assert(symbol.Text == "where", "Expected a where keyword");

            Node<CsToken> firstTokenNode = this.tokens.InsertLast(this.GetToken(CsTokenType.Where, SymbolType.Other));

            // Get the where expression.
            Expression whereClauseExpression = this.GetNextExpression(ExpressionPrecedence.Query, unsafeCode);
            if (whereClauseExpression == null)
            {
                throw this.CreateSyntaxException();
            }

            // Create and return the clause.
            return new QueryWhereClause(
                new CsTokenList(this.tokens, firstTokenNode, this.tokens.Last),
                whereClauseExpression);
        }

        /// <summary>
        /// Gets a query join clause.
        /// </summary>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides 
        /// in an unsafe code block.</param>
        /// <returns>Returns the query from clause.</returns>
        private QueryJoinClause GetQueryJoinClause(bool unsafeCode)
        {
            Param.Ignore(unsafeCode);

            // Get and add the 'from' symbol.
            Symbol symbol = this.GetNextSymbol(SymbolType.Other);
            Debug.Assert(symbol.Text == "join", "Expected a join keyword");

            Node<CsToken> firstTokenNode = this.tokens.InsertLast(this.GetToken(CsTokenType.Join, SymbolType.Other));

            // Get the variable.
            Variable variable = this.GetVariable(unsafeCode, true, false);
            if (variable == null)
            {
                throw this.CreateSyntaxException();
            }

            // The next symbol must be the 'in' keyword.
            this.tokens.Add(this.GetToken(CsTokenType.In, SymbolType.In));

            // Now get the in expression.
            Expression inExpression = this.GetNextExpression(ExpressionPrecedence.Query, unsafeCode);
            if (inExpression == null)
            {
                throw this.CreateSyntaxException();
            }

            // The next symbol must be the 'on' keyword.
            CsToken token = this.GetToken(CsTokenType.On, SymbolType.Other);
            if (token.Text != "on")
            {
                throw this.CreateSyntaxException();
            }

            this.tokens.Add(token);

            // Now get the on expression.
            Expression onKeyExpression = this.GetNextExpression(ExpressionPrecedence.Query, unsafeCode);
            if (onKeyExpression == null)
            {
                throw this.CreateSyntaxException();
            }

            // The next symbol must be the 'equals' keyword.
            token = this.GetToken(CsTokenType.Equals, SymbolType.Other);
            if (token.Text != "equals")
            {
                throw this.CreateSyntaxException();
            }

            this.tokens.Add(token);

            // Now get the equals expression.
            Expression equalsKeyExpression = this.GetNextExpression(ExpressionPrecedence.Query, unsafeCode);
            if (equalsKeyExpression == null)
            {
                throw this.CreateSyntaxException();
            }

            // Get the optional 'into' variable if it exists.
            Variable intoVariable = null;

            symbol = this.GetNextSymbol();
            if (symbol.SymbolType == SymbolType.Other && symbol.Text == "into")
            {
                this.tokens.Add(this.GetToken(CsTokenType.Into, SymbolType.Other));
                intoVariable = this.GetVariable(unsafeCode, true, true);
            }

            // Create and return the clause.
            return new QueryJoinClause(
                new CsTokenList(this.tokens, firstTokenNode, this.tokens.Last),
                variable,
                inExpression,
                onKeyExpression,
                equalsKeyExpression,
                intoVariable);
        }

        /// <summary>
        /// Gets a query order-by clause.
        /// </summary>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides 
        /// in an unsafe code block.</param>
        /// <returns>Returns the query order-by clause.</returns>
        private QueryOrderByClause GetQueryOrderByClause(bool unsafeCode)
        {
            Param.Ignore(unsafeCode);

            // Get and add the 'orderby' symbol.
            Symbol symbol = this.GetNextSymbol(SymbolType.Other);
            Debug.Assert(symbol.Text == "orderby", "Expected an orderby keyword");

            Node<CsToken> firstTokenNode = this.tokens.InsertLast(this.GetToken(CsTokenType.OrderBy, SymbolType.Other));

            // Get each of the orderings in the clause.
            List<QueryOrderByOrdering> orderings = new List<QueryOrderByOrdering>();

            while (true)
            {
                QueryOrderByOrdering ordering = new QueryOrderByOrdering();

                // Get the ordering expression.
                ordering.Expression = this.GetNextExpression(ExpressionPrecedence.Query, unsafeCode);
                if (ordering.Expression == null)
                {
                    throw this.CreateSyntaxException();
                }

                // Get the order direction if it exists.
                symbol = this.GetNextSymbol();

                ordering.Direction = QueryOrderByDirection.Undefined;

                if (symbol.Text == "ascending")
                {
                    ordering.Direction = QueryOrderByDirection.Ascending;
                    this.tokens.Add(this.GetToken(CsTokenType.Ascending, SymbolType.Other));
                }
                else if (symbol.Text == "descending")
                {
                    ordering.Direction = QueryOrderByDirection.Descending;
                    this.tokens.Add(this.GetToken(CsTokenType.Descending, SymbolType.Other));
                }

                // Add the ordering to the list.
                orderings.Add(ordering);

                // If the next symbol is a comma, then we should continue and get the next ordering expression.
                symbol = this.GetNextSymbol();

                if (symbol.SymbolType == SymbolType.Comma)
                {
                    this.tokens.Add(this.GetToken(CsTokenType.Comma, SymbolType.Comma));
                }
                else
                {
                    // This was the last ordering expression.
                    break;
                }
            }

            // Create and return the clause.
            return new QueryOrderByClause(
                new CsTokenList(this.tokens, firstTokenNode, this.tokens.Last),
                orderings);
        }

        /// <summary>
        /// Gets a query select clause.
        /// </summary>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides 
        /// in an unsafe code block.</param>
        /// <returns>Returns the query select clause.</returns>
        private QuerySelectClause GetQuerySelectClause(bool unsafeCode)
        {
            Param.Ignore(unsafeCode);

            // Get and add the 'select' symbol.
            Symbol symbol = this.GetNextSymbol(SymbolType.Other);
            Debug.Assert(symbol.Text == "select", "Expected a select keyword");

            Node<CsToken> firstTokenNode = this.tokens.InsertLast(this.GetToken(CsTokenType.Select, SymbolType.Other));

            // Get the select expression.
            Expression selectClauseExpression = this.GetNextExpression(ExpressionPrecedence.Query, unsafeCode);
            if (selectClauseExpression == null)
            {
                throw this.CreateSyntaxException();
            }

            // Create and return the clause.
            return new QuerySelectClause(
                new CsTokenList(this.tokens, firstTokenNode, this.tokens.Last),
                selectClauseExpression);
        }

        /// <summary>
        /// Gets a query group clause.
        /// </summary>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides 
        /// in an unsafe code block.</param>
        /// <returns>Returns the query group clause.</returns>
        private QueryGroupClause GetQueryGroupClause(bool unsafeCode)
        {
            Param.Ignore(unsafeCode);

            // Get and add the 'group' symbol.
            Symbol symbol = this.GetNextSymbol(SymbolType.Other);
            Debug.Assert(symbol.Text == "group", "Expected a group keyword.");

            Node<CsToken> firstTokenNode = this.tokens.InsertLast(this.GetToken(CsTokenType.Group, SymbolType.Other));

            // Get the group expression.
            Expression groupExpression = this.GetNextExpression(ExpressionPrecedence.Query, unsafeCode);
            if (groupExpression == null)
            {
                throw this.CreateSyntaxException();
            }

            // The next symbol must be the 'by' keyword.
            symbol = this.GetNextSymbol(SymbolType.Other);
            if (symbol.Text != "by")
            {
                throw this.CreateSyntaxException();
            }

            this.tokens.Add(this.GetToken(CsTokenType.By, SymbolType.Other));

            // Now get the by expression.
            Expression groupByExpression = this.GetNextExpression(ExpressionPrecedence.Query, unsafeCode);
            if (groupByExpression == null)
            {
                throw this.CreateSyntaxException();
            }

            // Create and return the clause.
            return new QueryGroupClause(
                new CsTokenList(this.tokens, firstTokenNode, this.tokens.Last),
                groupExpression,
                groupByExpression);
        }

        /// <summary>
        /// Reads an unsafe type expression.
        /// </summary>
        /// <param name="type">The type expression.</param>
        /// <param name="previousPrecedence">The precedence of the previous expression.</param>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <returns>Returns the expression.</returns>
        private UnsafeAccessExpression GetUnsafeTypeExpression(
            Expression type, ExpressionPrecedence previousPrecedence, bool unsafeCode)
        {
            Param.Ignore(type);
            Param.AssertNotNull(previousPrecedence, "previousPrecedence");
            Param.Assert(unsafeCode == true, "unsafeCode", "An unsafe type must reside in an unsafe code block.");

            UnsafeAccessExpression expression = null;

            if (this.CheckPrecedence(previousPrecedence, ExpressionPrecedence.Unary))
            {
                // Get the operator symbol.
                Symbol symbol = this.GetNextSymbol();

                OperatorType operatorType;
                UnsafeAccessExpression.Operator unsafeOperatorType;
                if (symbol.SymbolType == SymbolType.LogicalAnd)
                {
                    operatorType = OperatorType.AddressOf;
                    unsafeOperatorType = UnsafeAccessExpression.Operator.AddressOf;
                }
                else if (symbol.SymbolType == SymbolType.Multiplication)
                {
                    operatorType = OperatorType.Dereference;
                    unsafeOperatorType = UnsafeAccessExpression.Operator.Dereference;
                }
                else
                {
                    Debug.Fail("Unexpected operator type.");
                    throw new InvalidOperationException();
                }

                // Create a token for the operator symbol.
                this.symbols.Advance();
                OperatorSymbol token = new OperatorSymbol(
                    symbol.Text,
                    OperatorCategory.Reference,
                    operatorType,
                    symbol.Location,
                    this.symbols.Generated);

                this.tokens.Add(token);

                // Create the partial token list for the expression.
                CsTokenList partialTokens = new CsTokenList(this.tokens, type.Tokens.First, this.tokens.Last);

                // Create and return the expression.
                expression = new UnsafeAccessExpression(partialTokens, unsafeOperatorType, type);
            }

            return expression;
        }

        /// <summary>
        /// Reads an unsafe access expression.
        /// </summary>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <returns>Returns the expression.</returns>
        private UnsafeAccessExpression GetUnsafeAccessExpression(bool unsafeCode)
        {
            Param.Assert(unsafeCode == true, "unsafeCode", "Un unsafe access must reside in an unsafe code block.");

            // Get the operator symbol.
            Symbol symbol = this.GetNextSymbol();

            OperatorType operatorType;
            UnsafeAccessExpression.Operator unsafeOperatorType;
            if (symbol.SymbolType == SymbolType.LogicalAnd)
            {
                operatorType = OperatorType.AddressOf;
                unsafeOperatorType = UnsafeAccessExpression.Operator.AddressOf;
            }
            else if (symbol.SymbolType == SymbolType.Multiplication)
            {
                operatorType = OperatorType.Dereference;
                unsafeOperatorType = UnsafeAccessExpression.Operator.Dereference;
            }
            else
            {
                Debug.Fail("Unexpected operator type.");
                throw new InvalidOperationException();
            }
            
            // Create a token for the operator symbol.
            this.symbols.Advance();
            OperatorSymbol token = new OperatorSymbol(
                symbol.Text,
                OperatorCategory.Reference,
                operatorType,
                symbol.Location,
                this.symbols.Generated);

            Node<CsToken> tokenNode = this.tokens.InsertLast(token);

            // Get the expression being accessed.
            Expression expression = this.GetNextExpression(ExpressionPrecedence.Unary, unsafeCode);
            if (expression == null || expression.Tokens.First == null)
            {
                throw new SyntaxException(this.document.SourceCode, symbol.LineNumber);
            }
            
            // Create the partial token list for the expression.
            CsTokenList partialTokens = new CsTokenList(this.tokens, tokenNode, this.tokens.Last);

            // Create and return the expression.
            return new UnsafeAccessExpression(partialTokens, unsafeOperatorType, expression);
        }

        /// <summary>
        /// Gets the precedence of the given opereator type.
        /// </summary>
        /// <param name="type">The operator type.</param>
        /// <returns>Returns the precendece of the type.</returns>
        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "The method is not overly complex.")]
        private ExpressionPrecedence GetOperatorPrecedence(OperatorType type)
        {
            Param.Ignore(type);

            // Get the precendence type of this operator.
            ExpressionPrecedence precedence = ExpressionPrecedence.None;
            
            switch (type)
            {
                case OperatorType.Plus:
                case OperatorType.Minus:
                    precedence = ExpressionPrecedence.Additive;
                    break;

                case OperatorType.Multiplication:
                case OperatorType.Division:
                case OperatorType.Mod:
                    precedence = ExpressionPrecedence.Multiplicative;
                    break;

                case OperatorType.Equals:
                case OperatorType.AndEquals:
                case OperatorType.OrEquals:
                case OperatorType.XorEquals:
                case OperatorType.PlusEquals:
                case OperatorType.MinusEquals:
                case OperatorType.MultiplicationEquals:
                case OperatorType.DivisionEquals:
                case OperatorType.LeftShiftEquals:
                case OperatorType.RightShiftEquals:
                case OperatorType.ModEquals:
                    precedence = ExpressionPrecedence.Assignment;
                    break;

                case OperatorType.ConditionalColon:
                case OperatorType.ConditionalQuestionMark:
                    precedence = ExpressionPrecedence.Conditional;
                    break;

                case OperatorType.Increment:
                case OperatorType.Decrement:
                case OperatorType.Not:
                case OperatorType.BitwiseCompliment:
                    precedence = ExpressionPrecedence.Unary;
                    break;

                case OperatorType.LogicalAnd:
                    precedence = ExpressionPrecedence.LogicalAnd;
                    break;

                case OperatorType.LogicalOr:
                    precedence = ExpressionPrecedence.LogicalOr;
                    break;

                case OperatorType.LogicalXor:
                    precedence = ExpressionPrecedence.LogicalXor;
                    break;

                case OperatorType.ConditionalAnd:
                    precedence = ExpressionPrecedence.ConditionalAnd;
                    break;

                case OperatorType.ConditionalOr:
                    precedence = ExpressionPrecedence.ConditionalOr;
                    break;

                case OperatorType.NullCoalescingSymbol:
                    precedence = ExpressionPrecedence.NullCoalescing;
                    break;

                case OperatorType.ConditionalEquals:
                case OperatorType.NotEquals:
                    precedence = ExpressionPrecedence.Equality;
                    break;

                case OperatorType.LessThan:
                case OperatorType.GreaterThan:
                case OperatorType.LessThanOrEquals:
                case OperatorType.GreaterThanOrEquals:
                    precedence = ExpressionPrecedence.Relational;
                    break;

                case OperatorType.LeftShift:
                case OperatorType.RightShift:
                    precedence = ExpressionPrecedence.Shift;
                    break;
            }

            return precedence;
        }

        /// <summary>
        /// Compares the precendence of the previous expression with the precedence of the next expression,
        /// to determine which has the higher precedence value.
        /// </summary>
        /// <param name="previousPrecedence">The previous expression's precedence.</param>
        /// <param name="nextPrecedence">The next expression's precendence.</param>
        /// <returns>Returns true if the next expression has greater precedence than the next expression.</returns>
        private bool CheckPrecedence(ExpressionPrecedence previousPrecedence, ExpressionPrecedence nextPrecedence)
        {
            Param.AssertNotNull(previousPrecedence, "previousPrecedence");
            Param.AssertNotNull(nextPrecedence, "nextPrecedence");

            // Two expressions with no precendence can be chained back to back, and conditional expressions
            // are allowed to be embedded within other conditional expressions.
            if (previousPrecedence == ExpressionPrecedence.None && nextPrecedence == ExpressionPrecedence.None ||
                previousPrecedence == ExpressionPrecedence.Conditional && nextPrecedence == ExpressionPrecedence.Conditional)
            {
                return true;
            }

            return ((int)previousPrecedence > (int)nextPrecedence);
        }

        /// <summary>
        /// Checks whether the next expression can be a unary expression.
        /// </summary>
        /// <returns>Returns true if the next expression can be a unary expression.</returns>
        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "The method should be refactored")]
        private bool IsUnaryExpression()
        {
            bool unary = false;

            // Work back to the previous non whitespace symbol.
            int index = this.symbols.CurrentIndex;
            Symbol symbol = null;
            while (true)
            {
                symbol = this.symbols[index];
                if (symbol == null ||
                    (symbol.SymbolType != SymbolType.WhiteSpace &&
                     symbol.SymbolType != SymbolType.EndOfLine &&
                     symbol.SymbolType != SymbolType.SingleLineComment &&
                     symbol.SymbolType != SymbolType.MultiLineComment &&
                     symbol.SymbolType != SymbolType.PreprocessorDirective))
                {
                    break;
                }

                --index;
            }

            // An expression can only be unary if it comes after one of the following types.
            if (symbol != null)
            {
                if (symbol.SymbolType == SymbolType.Equals ||
                    symbol.SymbolType == SymbolType.PlusEquals ||
                    symbol.SymbolType == SymbolType.MinusEquals ||
                    symbol.SymbolType == SymbolType.MultiplicationEquals ||
                    symbol.SymbolType == SymbolType.DivisionEquals ||
                    symbol.SymbolType == SymbolType.OrEquals ||
                    symbol.SymbolType == SymbolType.AndEquals ||
                    symbol.SymbolType == SymbolType.XorEquals ||
                    symbol.SymbolType == SymbolType.LeftShiftEquals ||
                    symbol.SymbolType == SymbolType.RightShiftEquals ||
                    symbol.SymbolType == SymbolType.ModEquals ||
                    symbol.SymbolType == SymbolType.ConditionalEquals ||
                    symbol.SymbolType == SymbolType.NotEquals ||
                    symbol.SymbolType == SymbolType.GreaterThan ||
                    symbol.SymbolType == SymbolType.GreaterThanOrEquals ||
                    symbol.SymbolType == SymbolType.LessThan ||
                    symbol.SymbolType == SymbolType.LessThanOrEquals ||
                    symbol.SymbolType == SymbolType.OpenCurlyBracket ||
                    symbol.SymbolType == SymbolType.CloseCurlyBracket ||
                    symbol.SymbolType == SymbolType.OpenParenthesis ||
                    symbol.SymbolType == SymbolType.CloseParenthesis ||
                    symbol.SymbolType == SymbolType.OpenSquareBracket ||
                    symbol.SymbolType == SymbolType.LogicalAnd ||
                    symbol.SymbolType == SymbolType.LogicalOr ||
                    symbol.SymbolType == SymbolType.LogicalXor ||
                    symbol.SymbolType == SymbolType.ConditionalAnd ||
                    symbol.SymbolType == SymbolType.ConditionalOr ||
                    symbol.SymbolType == SymbolType.Plus ||
                    symbol.SymbolType == SymbolType.Minus ||
                    symbol.SymbolType == SymbolType.Multiplication ||
                    symbol.SymbolType == SymbolType.Division ||
                    symbol.SymbolType == SymbolType.LeftShift ||
                    symbol.SymbolType == SymbolType.RightShift ||
                    symbol.SymbolType == SymbolType.Mod ||
                    symbol.SymbolType == SymbolType.Tilde ||
                    symbol.SymbolType == SymbolType.Case ||
                    symbol.SymbolType == SymbolType.QuestionMark ||
                    symbol.SymbolType == SymbolType.Colon ||
                    symbol.SymbolType == SymbolType.NullCoalescingSymbol ||
                    symbol.SymbolType == SymbolType.Comma ||
                    symbol.SymbolType == SymbolType.Semicolon ||
                    symbol.SymbolType == SymbolType.Return ||
                    symbol.SymbolType == SymbolType.Throw ||
                    symbol.SymbolType == SymbolType.Else)
                {
                    unary = true;
                }
            }

            return unary;
        }

        /// <summary>
        /// Checks whether the symbol manager is currently sitting on a cast expression.
        /// </summary>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <returns>Returns true if the next expression is a cast.</returns>
        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "The method should be refactored.")]
        private bool IsCastExpression(bool unsafeCode)
        {
            Param.Ignore(unsafeCode);

            bool cast = false;

            // The first symbol must be an opening parenthesis.
            int index = this.GetNextCodeSymbolIndex(1);
            if (index != -1)
            {
                Symbol symbol = this.symbols.Peek(index);
                if (symbol.SymbolType == SymbolType.OpenParenthesis)
                {
                    // The inner expression must have a type signature.
                    if (this.HasTypeSignature(index + 1, unsafeCode, out index))
                    {
                        if (index != -1)
                        {
                            symbol = this.symbols.Peek(index);
                            if (symbol.SymbolType == SymbolType.Other)
                            {
                                index = this.AdvanceToEndOfName(index);
                            }

                            // The next character must be a closing parenthesis or this is not a cast.
                            if (index != -1)
                            {
                                index = this.GetNextCodeSymbolIndex(index + 1);
                                if (index != -1)
                                {
                                    symbol = this.symbols.Peek(index);
                                    if (symbol.SymbolType == SymbolType.CloseParenthesis)
                                    {
                                        // This looks like it might be a cast, but a cast can only appear in front 
                                        // of the following types of symbols.
                                        index = this.GetNextCodeSymbolIndex(index + 1);
                                        if (index != -1)
                                        {
                                            SymbolType symbolType = this.symbols.Peek(index).SymbolType;
                                            if (symbolType == SymbolType.Other ||
                                                symbolType == SymbolType.OpenParenthesis ||
                                                symbolType == SymbolType.Number ||
                                                symbolType == SymbolType.Tilde ||
                                                symbolType == SymbolType.Not ||
                                                symbolType == SymbolType.New ||
                                                symbolType == SymbolType.Sizeof ||
                                                symbolType == SymbolType.Typeof ||
                                                symbolType == SymbolType.Default ||
                                                symbolType == SymbolType.Checked ||
                                                symbolType == SymbolType.Unchecked ||
                                                symbolType == SymbolType.This ||
                                                symbolType == SymbolType.Base ||
                                                symbolType == SymbolType.Null ||
                                                symbolType == SymbolType.Plus ||
                                                symbolType == SymbolType.Minus ||
                                                symbolType == SymbolType.String ||
                                                symbolType == SymbolType.Delegate)
                                            {
                                                cast = true;
                                            }
                                            else if (symbolType == SymbolType.LogicalAnd && unsafeCode)
                                            {
                                                // For example: (IntPtr*)&rc.left
                                                cast = true;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return cast;
        }

        /// <summary>
        /// Checks whether the symbol manager is currently sitting on an expression that looks like a type.
        /// </summary>
        /// <param name="startIndex">The first index of the expression.</param>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <param name="endIndex">Returns the last index of the type, or -1 if this is not a type.</param>
        /// <returns>Returns true if the next expression is a cast.</returns>
        private bool HasTypeSignature(int startIndex, bool unsafeCode, out int endIndex)
        {
            Param.Ignore(startIndex, unsafeCode);

            bool generic;
            return this.HasTypeSignature(startIndex, unsafeCode, out endIndex, out generic);
        }

        /// <summary>
        /// Checks whether the symbol manager is currently sitting on an expression that looks like a type.
        /// </summary>
        /// <param name="startIndex">The first index of the expression.</param>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <param name="endIndex">Returns the last index of the type, or -1 if this is not a type.</param>
        /// <param name="generic">Returns a value indicating whether the type is generic.</param>
        /// <returns>Returns true if the next expression is a cast.</returns>
        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "The method should be refactored.")]
        private bool HasTypeSignature(int startIndex, bool unsafeCode, out int endIndex, out bool generic)
        {
            Param.AssertGreaterThanOrEqualToZero(startIndex, "startIndex");
            Param.Ignore(unsafeCode);

            endIndex = -1;
            generic = false;
            bool type = false;

            // The next symbol must be an unknown word.
            int index = this.GetNextCodeSymbolIndex(startIndex);
            if (index != -1)
            {
                bool allowNullableType = true;

                Symbol symbol = this.symbols.Peek(index);
                if (symbol.SymbolType == SymbolType.Other)
                {
                    type = true;

                    index = this.AdvanceToEndOfName(index);
                    endIndex = index;

                    // If the next character is a less-than symbol, then this might be a generic type.
                    index = this.GetNextCodeSymbolIndex(index + 1);
                    if (index != -1)
                    {
                        symbol = this.symbols.Peek(index);
                        if (symbol.SymbolType == SymbolType.LessThan)
                        {
                            // Move up to the closing bracket and check that this is actually a generic type.
                            index = this.AdvanceToClosingGenericSymbol(index + 1);
                            if (index != -1)
                            {
                                generic = true;
                                allowNullableType = false;
                                endIndex = index;
                                ++index;
                            }
                        }
                    }

                    // Check if there are one or more dereference symbols.
                    bool loop = true;
                    while (loop)
                    {
                        loop = false;

                        if (index != -1)
                        {
                            index = this.GetNextCodeSymbolIndex(index);
                            if (index != -1)
                            {
                                symbol = this.symbols.Peek(index);
                                if (symbol.SymbolType == SymbolType.Multiplication && unsafeCode)
                                {
                                    allowNullableType = false;
                                    endIndex = index;
                                    ++index;
                                    loop = true;
                                }
                            }
                        }
                    }

                    // If the next character is a nullable type character, move past it.
                    if (allowNullableType && index != -1)
                    {
                        index = this.GetNextCodeSymbolIndex(index);
                        if (index != -1)
                        {
                            symbol = this.symbols.Peek(index);
                            if (symbol.SymbolType == SymbolType.QuestionMark)
                            {
                                endIndex = index;
                                ++index;
                            }
                        }
                    }

                    // If the next character is an opening square bracket, move past the brackets.
                    bool open = false;
                    while (index != -1)
                    {
                        index = this.GetNextCodeSymbolIndex(index);
                        if (index != -1)
                        {
                            symbol = this.symbols.Peek(index);
                            if (open)
                            {
                                if (symbol.SymbolType == SymbolType.WhiteSpace ||
                                    symbol.SymbolType == SymbolType.EndOfLine ||
                                    symbol.SymbolType == SymbolType.SingleLineComment ||
                                    symbol.SymbolType == SymbolType.MultiLineComment ||
                                    symbol.SymbolType == SymbolType.PreprocessorDirective ||
                                    symbol.SymbolType == SymbolType.Number ||
                                    symbol.SymbolType == SymbolType.Comma)
                                {
                                    ++index;
                                }
                                else if (symbol.SymbolType == SymbolType.CloseSquareBracket)
                                {
                                    endIndex = index;
                                    ++index;
                                    open = false;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            else
                            {
                                if (symbol.SymbolType != SymbolType.OpenSquareBracket)
                                {
                                    break;
                                }

                                allowNullableType = false;
                                ++index;
                                open = true;
                            }
                        }
                    }
                }
            }

            return type;
        }

        /// <summary>
        /// Analyzes the current expression to determine whether it is a dereference expression.
        /// </summary>
        /// <param name="leftSide">The left side of the expression.</param>
        /// <returns>Returns true if the expression is a dereference expression.</returns>
        private bool IsDereferenceExpression(Expression leftSide)
        {
            Param.AssertNotNull(leftSide, "leftSide");

            // The current symbol must be a * or we shouldn't be here.
            Symbol symbol = this.symbols.Peek(1);
            Debug.Assert(symbol != null && symbol.SymbolType == SymbolType.Multiplication, "The next symbol must be a dereference symbol or a multiplication symbol.");

            bool dereference = false;

            // Check the type of the left side expression if it is not null.
            if (leftSide != null)
            {
                if (/*leftSide is LiteralExpression ||
                    leftSide is MemberAccessExpression ||*/
                    leftSide is UnsafeAccessExpression)
                {
                    // This is a dereference expression if the next word is an unknown word, and 
                    // the next symbol after that is either an equals sign or a semicolon.
                    int index = this.GetNextCodeSymbolIndex(2);
                    if (index != -1)
                    {
                        if (symbol.SymbolType == SymbolType.CloseParenthesis ||
                            symbol.SymbolType == SymbolType.Multiplication)
                        {
                            dereference = true;
                        }
                    }
                }
            }
            else
            {
                // If the left side is null then this is always a dereferencd type.
                dereference = true;
            }

            return dereference;
        }

        /// <summary>
        /// Moves to the closing bracket of the current generic symbol.
        /// </summary>
        /// <param name="startIndex">The index just past the opening bracket of the generic.</param>
        /// <returns>Returns the index of the closing bracket in the generic, or -1 if this
        /// is not a generic.</returns>
        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "The method should be refactored.")]
        private int AdvanceToClosingGenericSymbol(int startIndex)
        {
            Param.AssertGreaterThanOrEqualToZero(startIndex, "startIndex");

            bool other = false;
            bool comma = false;
            bool memberAccess = false;
            bool openSquareBracket = false;

            int index = this.GetNextCodeSymbolIndex(startIndex);
            while (index != -1)
            {
                // Check the type of the symbol.
                Symbol symbol = this.symbols.Peek(index);
                if (symbol.SymbolType == SymbolType.GreaterThan)
                {
                    // If the last character was a comma or a member access symbol, 
                    // this is not a valid generic statement.
                    if (comma || memberAccess)
                    {
                        index = -1;
                    }

                    // This is the end of the generic.
                    break;   
                }
                else if (symbol.SymbolType == SymbolType.Comma)
                {
                    // If the last word was not an unknown word or an opening square bracket, this is not a valid generic statement.
                    if ((comma && !openSquareBracket) || memberAccess || (!other && !openSquareBracket))
                    {
                        index = -1;
                        break;
                    }

                    comma = true;
                    other = false;
                }
                else if (symbol.SymbolType == SymbolType.Dot || symbol.SymbolType == SymbolType.QualifiedAlias)
                {
                    // If the last word not an unknown word, this is not a valid generic statement.
                    if (!other || comma || memberAccess)
                    {
                        index = -1;
                        break;
                    }

                    memberAccess = true;
                    other = false;
                }
                else if (symbol.SymbolType == SymbolType.OpenSquareBracket)
                {
                    // If we've already seen an opening square bracket or if this is coming after a comma, this 
                    // is not a valid generic statement.
                    if (openSquareBracket || comma)
                    {
                        index = -1;
                        break;
                    }

                    openSquareBracket = true;
                    other = false;
                }
                else if (symbol.SymbolType == SymbolType.CloseSquareBracket)
                {
                    // Make sure this is coming after an opening square bracket.
                    if (!openSquareBracket)
                    {
                        index = -1;
                        break;
                    }

                    comma = false;
                    openSquareBracket = false;
                    other = true;
                }
                else if (symbol.SymbolType == SymbolType.QuestionMark)
                {
                    // If this is coming after an unknown word, it may be a nullable type symbol.
                    if (!other)
                    {
                        index = -1;
                        break;
                    }
                }
                else if (symbol.SymbolType == SymbolType.Other)
                {
                    // If the last word was also an unknown word, or if we're in the middle of a
                    // set of square brackets, this is not a valid generic statement.
                    if (other || openSquareBracket)
                    {
                        index = -1;
                        break;
                    }

                    other = true;
                    comma = false;
                    memberAccess = false;
                }
                else if (symbol.SymbolType == SymbolType.LessThan)
                {
                    // This might be the start of an internal generic, but only if the last word was an unknown word.
                    if (!other)
                    {
                        index = -1;
                        break;
                    }

                    // Find the end of this generic.
                    index = this.AdvanceToClosingGenericSymbol(index + 1);
                    if (index == -1)
                    {
                        break;
                    }
                }
                else
                {
                    // This symbol type cannot exist inside of a generic. 
                    index = -1;
                    break;
                }

                // Get the next word.
                index = this.GetNextCodeSymbolIndex(index + 1);
            }

            return index;
        }

        /// <summary>
        /// Converts the given expression into a literal expression containing a type token.
        /// </summary>
        /// <param name="expression">The expression to convert.</param>
        /// <returns>Returns the converted expression.</returns>
        private LiteralExpression ConvertTypeExpression(Expression expression)
        {
            Param.AssertNotNull(expression, "expression");

            // Get the first and last token in the expression.
            Node<CsToken> firstTokenNode = expression.Tokens.First;
            Node<CsToken> lastTokenNode = expression.Tokens.Last;

            // Create a new token list containing these tokens.
            List<CsToken> tokenList = new List<CsToken>();
            foreach (CsToken token in expression.Tokens)
            {
                tokenList.Add(token);
            }

            // Remove the extra tokens from the master list.
            if (firstTokenNode != null && expression.Tokens.First != null)
            {
                Node<CsToken> temp = firstTokenNode.Next;
                if (!expression.Tokens.OutOfBounds(temp))
                {
                    this.tokens.RemoveRange(temp, expression.Tokens.Last);
                }
            }

            // Add the child tokens to a token list.
            MasterList<CsToken> childTokens = new MasterList<CsToken>(tokenList);

            // Create the new type token.
            TypeToken typeToken = new TypeToken(
                childTokens, CodeLocation.Join(firstTokenNode, lastTokenNode), firstTokenNode.Value.Generated);

            // Insert the new token.
            Node<CsToken> typeTokenNode = this.tokens.Replace(firstTokenNode, typeToken);

            // Create the literal expression.
            return new LiteralExpression(
                new CsTokenList(this.tokens, firstTokenNode, firstTokenNode),
                typeTokenNode);
        }

        #endregion Private Methods
    }
}
