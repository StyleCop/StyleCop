//-----------------------------------------------------------------------
// <copyright file="CodeParser.Expressions.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
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
namespace Microsoft.StyleCop.CSharp
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

        #region Private Static Methods

        /// <summary>
        /// Compares the precendence of the previous expression with the precedence of the next expression,
        /// to determine which has the higher precedence value.
        /// </summary>
        /// <param name="previousPrecedence">The previous expression's precedence.</param>
        /// <param name="nextPrecedence">The next expression's precendence.</param>
        /// <returns>Returns true if the next expression has greater precedence than the next expression.</returns>
        private static bool CheckPrecedence(ExpressionPrecedence previousPrecedence, ExpressionPrecedence nextPrecedence)
        {
            Param.AssertNotNull(previousPrecedence, "previousPrecedence");
            Param.AssertNotNull(nextPrecedence, "nextPrecedence");

            // Two expressions with no precendence can be chained back to back, and conditional expressions
            // are allowed to be embedded within other conditional expressions.
            if ((previousPrecedence == ExpressionPrecedence.None && nextPrecedence == ExpressionPrecedence.None) ||
                (previousPrecedence == ExpressionPrecedence.Conditional && nextPrecedence == ExpressionPrecedence.Conditional))
            {
                return true;
            }

            return (int)previousPrecedence > (int)nextPrecedence;
        }

        /// <summary>
        /// Gets the precedence of the given opereator type.
        /// </summary>
        /// <param name="type">The operator type.</param>
        /// <returns>Returns the precendece of the type.</returns>
        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "The method is not complex.")]
        private static ExpressionPrecedence GetOperatorPrecedence(OperatorType type)
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
        /// Converts the given expression into a literal expression containing a type token.
        /// </summary>
        /// <param name="expression">The expression to convert.</param>
        /// <returns>Returns the converted expression.</returns>
        private static LiteralExpression ConvertTypeExpression(Expression expression)
        {
            // todo; handle this.
            Param.AssertNotNull(expression, "expression");

            // Get the first and last token in the expression.
            Token firstToken = expression.FindFirstDescendent<Token>();

            // Create a new token list containing these tokens.
            var typeTokenProxy = new CodeUnitProxy();
            for (Token token = firstToken; token != null; token = token.FindNextDescendentOf<Token>(expression))
            {
                typeTokenProxy.Children.Add(token);
            }

            // Create the new type token.
            var typeToken = new TypeToken(typeTokenProxy, CodeUnit.JoinLocations(firstToken, typeTokenProxy.Children.Last), firstToken.Generated);

            var expressionProxy = new CodeUnitProxy();
            expressionProxy.Children.Add(typeToken);

            // Create the literal expression.
            return new LiteralExpression(expressionProxy, typeToken);
        }

        /// <summary>
        /// Replaces the given TypeToken with the first child of that token.
        /// </summary>
        /// <param name="typeToken">The TypeToken to replace.</param>
        private static void ReplaceTypeTokenWithFirstChildToken(TypeToken typeToken)
        {
            Param.AssertNotNull(typeToken, "typeToken");
            Debug.Assert(typeToken.Children.Count == 1, "This operation only makes sense when the type token contains a single child.");

            // Detach the child token from the parent TypeToken.
            Token token = typeToken.FindFirstChild<Token>();
            Debug.Assert(token != null, "The child token of the type token should be a token.");

            token.Detach();

            CodeUnit parent = typeToken.Parent;
            Debug.Assert(parent != null, "The type token has not been added to a collection");

            parent.Children.Replace(typeToken, token);
        }

        #endregion Private Static Methods

        #region Private Methods

        /// <summary>
        /// Reads the next expression from the file and returns it.
        /// </summary>
        /// <param name="parentProxy">Represents the parent codeUnit.</param>
        /// <param name="previousPrecedence">The precedence of the expression just before this one.</param>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <returns>Returns the expression.</returns>
        private Expression GetNextExpression(CodeUnitProxy parentProxy, ExpressionPrecedence previousPrecedence, bool unsafeCode)
        {
            Param.AssertNotNull(parentProxy, "parentProxy");
            Param.Ignore(previousPrecedence);
            Param.Ignore(unsafeCode);

            return this.GetNextExpression(parentProxy, previousPrecedence, unsafeCode, false, false);
        }

        /// <summary>
        /// Reads the next expression from the file and returns it.
        /// </summary>
        /// <param name="parentProxy">Represents the parent codeUnit.</param>
        /// <param name="previousPrecedence">The precedence of the expression just before this one.</param>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <param name="allowVariableDeclaration">Indicates whether this expression can be a variable declaration expression.</param>
        /// <param name="typeExpression">Indicates whether only components of a type expression are allowed.</param>
        /// <returns>Returns the expression.</returns>
        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "May be simplified later.")]
        private Expression GetNextExpression(
            CodeUnitProxy parentProxy, ExpressionPrecedence previousPrecedence, bool unsafeCode, bool allowVariableDeclaration, bool typeExpression)
        {
            Param.AssertNotNull(parentProxy, "parentProxy");
            Param.Ignore(previousPrecedence);
            Param.Ignore(unsafeCode);
            Param.Ignore(allowVariableDeclaration);
            Param.Ignore(typeExpression);

            // Saves the next expression.
            Expression expression = null;
            CodeUnitProxy expressionExtensionProxy = new CodeUnitProxy();

            // Get the next symbol.
            Symbol symbol = this.PeekNextSymbol();

            if (symbol != null)
            {
                this.AdvanceToNextCodeSymbol(parentProxy);

                switch (symbol.SymbolType)
                {
                    case SymbolType.Other:
                        if (this.IsLambdaExpression())
                        {
                            expression = this.GetLambdaExpression(expressionExtensionProxy, unsafeCode);
                        }
                        else if (this.IsQueryExpression(unsafeCode))
                        {
                            expression = this.GetQueryExpression(expressionExtensionProxy, unsafeCode);
                        }

                        // If the expression is still null now, this is just a regular 'other' expression.
                        if (expression == null)
                        {
                            expression = this.GetOtherExpression(expressionExtensionProxy, allowVariableDeclaration, unsafeCode);
                        }

                        break;

                    case SymbolType.Checked:
                        expression = this.GetCheckedExpression(expressionExtensionProxy, unsafeCode);
                        break;

                    case SymbolType.Unchecked:
                        expression = this.GetUncheckedExpression(expressionExtensionProxy, unsafeCode);
                        break;

                    case SymbolType.New:
                        expression = this.GetNewAllocationExpression(expressionExtensionProxy, unsafeCode);
                        break;

                    case SymbolType.Stackalloc:
                        expression = this.GetStackallocExpression(expressionExtensionProxy, unsafeCode);
                        break;

                    case SymbolType.Sizeof:
                        expression = this.GetSizeofExpression(expressionExtensionProxy, unsafeCode);
                        break;

                    case SymbolType.Typeof:
                        expression = this.GetTypeofExpression(expressionExtensionProxy, unsafeCode);
                        break;

                    case SymbolType.Default:
                        expression = this.GetDefaultValueExpression(expressionExtensionProxy, unsafeCode);
                        break;

                    case SymbolType.Delegate:
                        expression = this.GetAnonymousMethodExpression(expressionExtensionProxy, unsafeCode);
                        break;

                    case SymbolType.Increment:
                        if (this.IsUnaryExpression())
                        {
                            expression = this.GetUnaryIncrementExpression(expressionExtensionProxy, unsafeCode);
                        }

                        break;

                    case SymbolType.Decrement:
                        if (this.IsUnaryExpression())
                        {
                            expression = this.GetUnaryDecrementExpression(expressionExtensionProxy, unsafeCode);
                        }

                        break;

                    case SymbolType.Plus:
                    case SymbolType.Minus:
                        if (this.IsUnaryExpression())
                        {
                            expression = this.GetUnaryExpression(expressionExtensionProxy, unsafeCode);
                        }

                        break;

                    case SymbolType.Not:
                    case SymbolType.Tilde:
                        expression = this.GetUnaryExpression(expressionExtensionProxy, unsafeCode);
                        break;

                    case SymbolType.OpenParenthesis:
                        if (this.IsLambdaExpression())
                        {
                            expression = this.GetLambdaExpression(expressionExtensionProxy, unsafeCode);
                        }
                        else
                        {
                            expression = this.GetOpenParenthesisExpression(expressionExtensionProxy, unsafeCode);
                        }

                        break;
                            
                    case SymbolType.Number:
                        expression = this.CreateLiteralExpression(expressionExtensionProxy, SymbolType.Number, TokenType.Number);
                        break;

                    case SymbolType.String:
                        expression = this.CreateLiteralExpression(expressionExtensionProxy, SymbolType.String, TokenType.String);
                        break;

                    case SymbolType.True:
                        expression = this.CreateLiteralExpression(expressionExtensionProxy, SymbolType.True, TokenType.True);
                        break;

                    case SymbolType.False:
                        expression = this.CreateLiteralExpression(expressionExtensionProxy, SymbolType.False, TokenType.False);
                        break;

                    case SymbolType.Null:
                        expression = this.CreateLiteralExpression(expressionExtensionProxy, SymbolType.Null, TokenType.Null);
                        break;

                    case SymbolType.This:
                        expression = this.CreateLiteralExpression(expressionExtensionProxy, SymbolType.This, TokenType.This);
                        break;

                    case SymbolType.Base:
                        expression = this.CreateLiteralExpression(expressionExtensionProxy, SymbolType.Base, TokenType.Base);
                        break;

                    case SymbolType.Multiplication:
                        if (!unsafeCode)
                        {
                            goto default;
                        }

                        expression = this.GetUnsafeAccessExpression(expressionExtensionProxy, unsafeCode);
                        break;

                    case SymbolType.LogicalAnd:
                        if (!unsafeCode)
                        {
                            goto default;
                        }

                        expression = this.GetUnsafeAccessExpression(expressionExtensionProxy, unsafeCode);
                        break;

                    default:
                        throw new SyntaxException(this.document.SourceCode, symbol.LineNumber);
                }
            }

            // Gather up all extensions to this expression.
            Expression topLevelExpression = expression;

            while (expression != null)
            {
                // Check if there is an extension to this expression.
                expression = this.GetExpressionExtension(expressionExtensionProxy, expression, previousPrecedence, unsafeCode, typeExpression, allowVariableDeclaration);
                if (expression != null)
                {
                    // Save the expression extension proxy and create a new one for the next expression extension.
                    expressionExtensionProxy = new CodeUnitProxy();
                    expressionExtensionProxy.Children.Add(expression);

                    topLevelExpression = expression;
                }
            }

            // There are no more extensions. The children of the current top-level expression extension proxy
            // should actually be children of the parent proxy, since there are no more extensions.
            CodeUnit unit = expressionExtensionProxy.Children.First;
            while (unit != null)
            {
                CodeUnit next = unit.LinkNode.Next;
                unit.Detach();
                parentProxy.Children.Add(unit);
                unit = next;
            }

            // Return the expression.
            return topLevelExpression;
        }

        /// <summary>
        /// Given an expression, reads further to see if it is actually a sub-expression 
        /// within a larger expression.
        /// </summary>
        /// <param name="expressionExtensionProxy">Proxy for the expression extension being created.</param>
        /// <param name="leftSide">The known expression which might have an extension.</param>
        /// <param name="previousPrecedence">The precedence of the expression just before this one.</param>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <param name="typeExpression">Indicates whether only components of a type expression are allowed.</param>
        /// <param name="allowVariableDeclaration">Indicates whether variable declaration expressions are allowed.</param>
        /// <returns>Returns the expression.</returns>
        [SuppressMessage(
            "Microsoft.Maintainability", 
            "CA1502:AvoidExcessiveComplexity",
            Justification = "May be simplified later.")]
        [SuppressMessage(
            "Microsoft.Globalization", 
            "CA1303:DoNotPassLiteralsAsLocalizedParameters",
            MessageId = "Microsoft.StyleCop.CSharp.SymbolManager.Combine(System.Int32,System.Int32,System.String,Microsoft.StyleCop.CSharp.SymbolType)",
            Justification = "The literal represents a non-localizable C# operator symbol")]
        private Expression GetExpressionExtension(
            CodeUnitProxy expressionExtensionProxy, Expression leftSide, ExpressionPrecedence previousPrecedence, bool unsafeCode, bool typeExpression, bool allowVariableDeclaration)
        {
            Param.AssertNotNull(expressionExtensionProxy, "expressionExtensionProxy");
            Param.AssertNotNull(leftSide, "leftSide");
            Param.Ignore(previousPrecedence);
            Param.Ignore(unsafeCode);
            Param.Ignore(typeExpression);
            Param.Ignore(allowVariableDeclaration);

            // The expression to return.
            Expression expression = null;

            Symbol symbol = this.PeekNextSymbol();

            if (typeExpression)
            {
                // A type expression can only be extended by a member access expression.
                if (symbol.SymbolType == SymbolType.Dot || symbol.SymbolType == SymbolType.QualifiedAlias)
                {
                    expression = this.GetMemberAccessExpression(expressionExtensionProxy, leftSide, previousPrecedence, unsafeCode);
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
                        expression = this.GetMemberAccessExpression(expressionExtensionProxy, leftSide, previousPrecedence, unsafeCode);
                        break;

                    case SymbolType.Other:
                        // This can only be a variable declaration expression if the left
                        // side expression is a simple Literal or a MemberAccess which represents the type.
                        if (allowVariableDeclaration && 
                            (leftSide.ExpressionType == ExpressionType.Literal || leftSide.ExpressionType == ExpressionType.MemberAccess))
                        {
                            expression = this.GetVariableDeclarationExpression(expressionExtensionProxy, leftSide, previousPrecedence, unsafeCode);
                        }

                        break;

                    case SymbolType.OpenParenthesis:
                        expression = this.GetMethodInvocationExpression(expressionExtensionProxy, leftSide, previousPrecedence, unsafeCode);
                        break;

                    case SymbolType.OpenSquareBracket:
                        expression = this.GetArrayAccessExpression(expressionExtensionProxy, leftSide, previousPrecedence, unsafeCode);
                        break;

                    case SymbolType.As:
                        expression = this.GetAsExpression(expressionExtensionProxy, leftSide, previousPrecedence, unsafeCode);
                        break;

                    case SymbolType.Is:
                        expression = this.GetIsExpression(expressionExtensionProxy, leftSide, previousPrecedence, unsafeCode);
                        break;

                    case SymbolType.Increment:
                        expression = this.GetPrimaryIncrementExpression(expressionExtensionProxy, leftSide, previousPrecedence);
                        break;

                    case SymbolType.Decrement:
                        expression = this.GetPrimaryDecrementExpression(expressionExtensionProxy, leftSide, previousPrecedence);
                        break;

                    default:
                        // Check whether this is an operator symbol.
                        OperatorType type;
                        OperatorCategory category;
                        if (GetOperatorType(symbol, out type, out category))
                        {
                            switch (category)
                            {
                                case OperatorCategory.Conditional:
                                    // The question mark must come before the colon.
                                    if (type == OperatorType.ConditionalQuestionMark)
                                    {
                                        expression = this.GetConditionalExpression(expressionExtensionProxy, leftSide, previousPrecedence, unsafeCode);
                                    }

                                    break;

                                case OperatorCategory.Arithmetic:
                                    if (unsafeCode && type == OperatorType.Multiplication)
                                    {
                                        if (this.IsDereferenceExpression(leftSide))
                                        {
                                            expression = this.GetUnsafeTypeExpression(expressionExtensionProxy, leftSide, previousPrecedence);
                                        }
                                        else
                                        {
                                            expression = this.GetArithmeticExpression(expressionExtensionProxy, leftSide, previousPrecedence, unsafeCode);
                                        }
                                    }
                                    else
                                    {
                                        expression = this.GetArithmeticExpression(expressionExtensionProxy,  leftSide, previousPrecedence, unsafeCode);
                                    }

                                    break;

                                case OperatorCategory.Shift:
                                    expression = this.GetArithmeticExpression(expressionExtensionProxy, leftSide, previousPrecedence, unsafeCode);
                                    break;

                                case OperatorCategory.Assignment:
                                    expression = this.GetAssignmentExpression(expressionExtensionProxy, leftSide, previousPrecedence, unsafeCode);
                                    break;

                                case OperatorCategory.Relational:
                                    // If this is a greater-than symbol, make sure it is not really a right-shift.
                                    if (type == OperatorType.GreaterThan)
                                    {
                                        int index = this.GetNextCodeSymbolIndex(1);

                                        // If the very next symbol is a greater-than or equals, then this is really a right-shift.
                                        Symbol next = this.symbols.Peek(index + 1);
                                        if (next != null)
                                        {
                                            if (next.SymbolType == SymbolType.GreaterThanOrEquals)
                                            {
                                                // This is a right-shift-equals.
                                                this.symbols.Combine(index, index + 1, ">>=", SymbolType.RightShiftEquals);
                                                goto case OperatorCategory.Assignment;
                                            }
                                            else if (next.SymbolType == SymbolType.GreaterThan)
                                            {
                                                // This is a right-shift.
                                                this.symbols.Combine(index, index + 1, ">>", SymbolType.RightShift);
                                                goto case OperatorCategory.Shift;
                                            }
                                        }
                                    }

                                    expression = this.GetRelationalExpression(expressionExtensionProxy, leftSide, previousPrecedence, unsafeCode);
                                    break;

                                case OperatorCategory.Logical:
                                    switch (type)
                                    {
                                        case OperatorType.LogicalAnd:
                                        case OperatorType.LogicalOr:
                                        case OperatorType.LogicalXor:
                                            expression = this.GetLogicalExpression(expressionExtensionProxy, leftSide, previousPrecedence, unsafeCode);
                                            break;

                                        case OperatorType.ConditionalAnd:
                                        case OperatorType.ConditionalOr:
                                            expression = this.GetConditionalLogicalExpression(expressionExtensionProxy, leftSide, previousPrecedence, unsafeCode);
                                            break;

                                        case OperatorType.NullCoalescingSymbol:
                                            expression = this.GetNullCoalescingExpression(expressionExtensionProxy, leftSide, previousPrecedence, unsafeCode);
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
        /// <param name="parentProxy">Represents the parent codeUnit.</param>
        /// <param name="allowVariableDeclaration">Indicates whether this expression can be a variable declaration expression.</param>
        /// <param name="unsafeCode">Indicates whether the expression resides within a block of unsafe code.</param>
        /// <returns>Returns the expression.</returns>
        private Expression GetOtherExpression(CodeUnitProxy parentProxy, bool allowVariableDeclaration, bool unsafeCode)
        {
            Param.AssertNotNull(parentProxy, "parentProxy");
            Param.Ignore(allowVariableDeclaration);
            Param.Ignore(unsafeCode);

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
                LiteralExpression type = this.GetTypeTokenExpression(parentProxy, unsafeCode, true);
                if (type == null || type.Children.Count == 0)
                {
                    throw this.CreateSyntaxException();
                }

                // Then get the rest of the expression.
                expression = this.GetVariableDeclarationExpression(parentProxy, type, ExpressionPrecedence.None, unsafeCode);
            }
            else
            {
                // This is just a literal expression.
                expression = this.GetLiteralExpression(parentProxy, unsafeCode);
            }

            return expression;
        }

        /// <summary>
        /// Reads an expression starting with an unknown word.
        /// </summary>
        /// <param name="parentProxy">Represents the parent codeUnit.</param>
        /// <param name="unsafeCode">Indicates whether the code is marked as unsafe.</param>
        /// <returns>Returns the expression.</returns>
        private LiteralExpression GetLiteralExpression(CodeUnitProxy parentProxy, bool unsafeCode)
        {
            Param.AssertNotNull(parentProxy, "parentProxy");
            Param.Ignore(unsafeCode);

            // Get the first symbol.
            this.AdvanceToNextCodeSymbol(parentProxy);
            Symbol symbol = this.PeekNextSymbol();

            var expressionProxy = new CodeUnitProxy();

            // First, check if this is a generic.
            Token literalToken = null;
            int temp;
            bool generic = false;
            if (symbol.SymbolType == SymbolType.Other && this.HasTypeSignature(1, false, out temp, out generic) && generic)
            {
                literalToken = this.GetGenericToken(expressionProxy, unsafeCode);
            }

            if (literalToken == null)
            {
                // This is not a generic. Just convert the symbol to a token.
                literalToken = this.GetToken(expressionProxy, TokenType.Literal, SymbolType.Other);
            }

            // Create a literal expression from this token.
            var literal = new LiteralExpression(expressionProxy, literalToken);
            parentProxy.Children.Add(literal);

            return literal;
        }

        /// <summary>
        /// Reads a method access expression.
        /// </summary>
        /// <param name="expressionProxy">Proxy object for the expression being created.</param>
        /// <param name="methodName">The name of the method being called.</param>
        /// <param name="previousPrecedence">The precedence of the previous expression.</param>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <returns>Returns the expression.</returns>
        private MethodInvocationExpression GetMethodInvocationExpression(
            CodeUnitProxy expressionProxy, Expression methodName, ExpressionPrecedence previousPrecedence, bool unsafeCode)
        {
            Param.AssertNotNull(expressionProxy, "expressionProxy");
            Param.AssertNotNull(methodName, "methodName");
            Param.Ignore(previousPrecedence);
            Param.Ignore(unsafeCode);

            MethodInvocationExpression expression = null;
            if (CheckPrecedence(previousPrecedence, ExpressionPrecedence.Primary))
            {
                // The next symbol will be the opening parenthesis.
                BracketToken openParenthesis = (BracketToken)this.GetToken(expressionProxy, TokenType.OpenParenthesis, SymbolType.OpenParenthesis);

                // Get the argument list now.
                this.GetArgumentList(expressionProxy, SymbolType.CloseParenthesis, unsafeCode);

                // Get the closing parenthesis.
                BracketToken closeParenthesis = (BracketToken)this.GetToken(expressionProxy, TokenType.CloseParenthesis, SymbolType.CloseParenthesis);

                openParenthesis.MatchingBracket = closeParenthesis;
                closeParenthesis.MatchingBracket = openParenthesis;

                // Create and return the expression.
                expression = new MethodInvocationExpression(expressionProxy, methodName);
            }

            return expression;
        }

        /// <summary>
        /// Reads an array access expression.
        /// </summary>
        /// <param name="expressionProxy">Proxy object for the expression being created.</param>
        /// <param name="array">The array being accessed.</param>
        /// <param name="previousPrecedence">The precedence of the previous expression.</param>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <returns>Returns the expression.</returns>
        private ArrayAccessExpression GetArrayAccessExpression(
            CodeUnitProxy expressionProxy, Expression array, ExpressionPrecedence previousPrecedence, bool unsafeCode)
        {
            Param.AssertNotNull(expressionProxy, "expressionProxy");
            Param.AssertNotNull(array, "array");
            Param.Ignore(previousPrecedence);
            Param.Ignore(unsafeCode);

            ArrayAccessExpression expression = null;

            if (CheckPrecedence(previousPrecedence, ExpressionPrecedence.Primary))
            {
                // The next symbol will be the opening bracket.
                BracketToken openingBracket = (BracketToken)this.GetToken(expressionProxy, TokenType.OpenSquareBracket, SymbolType.OpenSquareBracket);

                // Get the argument list now.
                this.GetArgumentList(expressionProxy, SymbolType.CloseSquareBracket, unsafeCode);

                // Get the closing bracket.
                BracketToken closingBracket = (BracketToken)this.GetToken(expressionProxy, TokenType.CloseSquareBracket, SymbolType.CloseSquareBracket);

                openingBracket.MatchingBracket = closingBracket;
                closingBracket.MatchingBracket = openingBracket;

                // Create and return the expression.
                expression = new ArrayAccessExpression(expressionProxy, array);
            }

            return expression;
        }

        /// <summary>
        /// Reads a member access expression.
        /// </summary>
        /// <param name="expressionProxy">Proxy object for the expression being created.</param>
        /// <param name="leftSide">The left side of the expression.</param>
        /// <param name="previousPrecedence">The precedence of the previous expression.</param>
        /// <param name="unsafeCode">Indicates whether the code is marked as unsafe.</param>
        /// <returns>Returns the expression.</returns>
        private MemberAccessExpression GetMemberAccessExpression(
            CodeUnitProxy expressionProxy, Expression leftSide, ExpressionPrecedence previousPrecedence, bool unsafeCode)
        {
            Param.AssertNotNull(expressionProxy, "expressionProxy");
            Param.AssertNotNull(leftSide, "leftSide");
            Param.Ignore(previousPrecedence);
            Param.Ignore(unsafeCode);

            MemberAccessExpression expression = null;

            OperatorType operatorType;
            MemberAccessExpression.Operator expressionOperatorType;
            ExpressionPrecedence precedence;

            // The next symbol must one of the member access types.
            Symbol symbol = this.PeekNextSymbol();

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
            if (CheckPrecedence(previousPrecedence, precedence))
            {
                this.AdvanceToNextCodeSymbol(expressionProxy);

                // Add this to the document.
                this.GetOperatorSymbolToken(expressionProxy, operatorType);

                // Get the member being accessed. This must be a literal.
                LiteralExpression member = this.GetLiteralExpression(expressionProxy, unsafeCode);
                if (member == null)
                {
                    throw this.CreateSyntaxException();
                }

                // Create the expression.
                expression = new MemberAccessExpression(expressionProxy, expressionOperatorType, leftSide, member);
            }

            return expression;
        }

        /// <summary>
        /// Reads an expression beginning with two unknown words.
        /// </summary>
        /// <param name="parentProxy">Represents the parent codeUnit.</param>
        /// <param name="type">The type of the variable.</param>
        /// <param name="previousPrecedence">The precedence of the previous expression.</param>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <returns>Returns the expression.</returns>
        private VariableDeclarationExpression GetVariableDeclarationExpression(
            CodeUnitProxy parentProxy, Expression type, ExpressionPrecedence previousPrecedence, bool unsafeCode)
        {
            Param.AssertNotNull(parentProxy, "parentProxy");
            Param.AssertNotNull(type, "type");
            Param.Ignore(previousPrecedence);
            Param.Ignore(unsafeCode);

            return this.GetVariableDeclarationExpression(new CodeUnitProxy(), parentProxy, type, previousPrecedence, unsafeCode);
        }

        /// <summary>
        /// Reads an expression beginning with two unknown words.
        /// </summary>
        /// <param name="expressionProxy">Proxy object for the expression being created.</param>
        /// <param name="parentProxy">Represents the parent codeUnit.</param>
        /// <param name="type">The type of the variable.</param>
        /// <param name="previousPrecedence">The precedence of the previous expression.</param>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <returns>Returns the expression.</returns>
        private VariableDeclarationExpression GetVariableDeclarationExpression(
            CodeUnitProxy expressionProxy, CodeUnitProxy parentProxy, Expression type, ExpressionPrecedence previousPrecedence, bool unsafeCode)
        {
            Param.AssertNotNull(expressionProxy, "expressionProxy");
            Param.AssertNotNull(parentProxy, "parentProxy");
            Param.AssertNotNull(type, "type");
            Param.Ignore(previousPrecedence);
            Param.Ignore(unsafeCode);

            Debug.Assert(
                type.ExpressionType == ExpressionType.Literal || type.ExpressionType == ExpressionType.MemberAccess,
                "The left side of a variable declaration must either be a literal or a member access.");

            VariableDeclarationExpression expression = null;
            if (CheckPrecedence(previousPrecedence, ExpressionPrecedence.None))
            {
                this.AdvanceToNextCodeSymbol(parentProxy);

                // Convert the type expression to a literal type token expression.
                LiteralExpression literalType = null;
                if (type.ExpressionType == ExpressionType.Literal)
                {
                    literalType = (LiteralExpression)type;
                    if (!literalType.Token.Is(TokenType.Type))
                    {
                        literalType = null;
                    }
                }

                if (literalType == null)
                {
                    literalType = ConvertTypeExpression(type);
                }

                // Get each declarator.
                var declarators = new List<VariableDeclaratorExpression>();

                while (true)
                {
                    var variableDeclaratorExpressionProxy = new CodeUnitProxy();

                    // Get the next word.
                    Symbol symbol = this.PeekNextSymbol();
                    if (symbol.SymbolType != SymbolType.Other)
                    {
                        throw this.CreateSyntaxException();
                    }

                    // Get the identifier.
                    LiteralExpression identifier = this.GetLiteralExpression(variableDeclaratorExpressionProxy, unsafeCode);
                    if (identifier == null || identifier.Children.Count == 0)
                    {
                        throw new SyntaxException(this.document.SourceCode, symbol.LineNumber);
                    }

                    // Get the initializer if it exists.
                    Expression initializer = null;

                    symbol = this.PeekNextSymbol();
                    if (symbol.SymbolType == SymbolType.Equals)
                    {
                        // Add the equals token.
                        this.GetOperatorSymbolToken(variableDeclaratorExpressionProxy, OperatorType.Equals);

                        // Check whether this is an array initializer.
                        symbol = this.PeekNextSymbol();

                        if (symbol.SymbolType == SymbolType.OpenCurlyBracket)
                        {
                            initializer = this.GetArrayInitializerExpression(variableDeclaratorExpressionProxy, unsafeCode);
                        }
                        else
                        {
                            initializer = this.GetNextExpression(variableDeclaratorExpressionProxy, ExpressionPrecedence.None, unsafeCode);
                        }
                    }

                    // Create and add the declarator.
                    var declarator = new VariableDeclaratorExpression(variableDeclaratorExpressionProxy, identifier, initializer);
                    declarators.Add(declarator);
                    expressionProxy.Children.Add(declarator);

                    // Now check if the next character is a comma. If so there is another declarator.
                    symbol = this.PeekNextSymbol();
                    if (symbol.SymbolType != SymbolType.Comma)
                    {
                        // There are no more declarators.
                        break;
                    }

                    // Add the comma.
                    this.GetToken(expressionProxy, TokenType.Comma, SymbolType.Comma);
                }

                // Create the expression.
                expression = new VariableDeclarationExpression(expressionProxy, literalType, declarators.ToArray());
                parentProxy.Children.Add(expression);
            }

            return expression;
        }

        /// <summary>
        /// Reads an array initializer expression.
        /// </summary>
        /// <param name="parentProxy">Represents the parent codeUnit.</param>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <returns>Returns the expression.</returns>
        private ArrayInitializerExpression GetArrayInitializerExpression(CodeUnitProxy parentProxy, bool unsafeCode)
        {
            Param.AssertNotNull(parentProxy, "parentProxy");
            Param.Ignore(unsafeCode);

            this.AdvanceToNextCodeSymbol(parentProxy);
            var expressionProxy = new CodeUnitProxy();

            // Get the first symbol and make sure it is an opening curly bracket.
            BracketToken openingBracket = (BracketToken)this.GetToken(expressionProxy, TokenType.OpenCurlyBracket, SymbolType.OpenCurlyBracket);

            // Get each of the initializers.
            var initializers = new List<Expression>();

            while (true)
            {
                // If this initializer starts with an opening curly bracket, it is another
                // array initializer expression. Otherwise, parse it like a normal expression.
                Symbol symbol = this.PeekNextSymbol();

                if (symbol.SymbolType == SymbolType.OpenCurlyBracket)
                {
                    initializers.Add(this.GetArrayInitializerExpression(expressionProxy, unsafeCode));
                }
                else if (symbol.SymbolType == SymbolType.CloseCurlyBracket)
                {
                    break;
                }
                else
                {
                    initializers.Add(this.GetNextExpression(expressionProxy, ExpressionPrecedence.None, unsafeCode));
                }

                // Now check the type of the next symbol and see if it is a comma.
                symbol = this.PeekNextSymbol();

                if (symbol.SymbolType == SymbolType.Comma)
                {
                    // Add the comma and advance.
                    this.GetToken(expressionProxy, TokenType.Comma, SymbolType.Comma);
                }
            }

            // Add the closing curly bracket.
            BracketToken closingBracket = (BracketToken)this.GetToken(expressionProxy, TokenType.CloseCurlyBracket, SymbolType.CloseCurlyBracket);

            openingBracket.MatchingBracket = closingBracket;
            closingBracket.MatchingBracket = openingBracket;

            // Return the expression.
            var expression = new ArrayInitializerExpression(expressionProxy, initializers.ToArray());
            parentProxy.Children.Add(expression);

            return expression;
        }

        /// <summary>
        /// Gets a token representing a type identifier.
        /// </summary>
        /// <param name="parentProxy">Represents the parent codeUnit.</param>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <param name="includeArrayBrackets">Indicates whether to include array brackets in the type token.</param>
        /// <returns>Returns the token.</returns>
        private LiteralExpression GetTypeTokenExpression(CodeUnitProxy parentProxy, bool unsafeCode, bool includeArrayBrackets)
        {
            Param.AssertNotNull(parentProxy, "parentProxy");
            Param.Ignore(unsafeCode);
            Param.Ignore(includeArrayBrackets);

            return this.GetTypeTokenExpression(parentProxy, unsafeCode, includeArrayBrackets, false);
        }

        /// <summary>
        /// Gets a token representing a type identifier.
        /// </summary>
        /// <param name="parentProxy">Represents the parent codeUnit.</param>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <param name="includeArrayBrackets">Indicates whether to include array brackets in the type token.</param>
        /// <param name="isExpression">Indicates whether this type token comes at the end of an 'is' expression.</param>
        /// <returns>Returns the token.</returns>
        private LiteralExpression GetTypeTokenExpression(CodeUnitProxy parentProxy, bool unsafeCode, bool includeArrayBrackets, bool isExpression)
        {
            Param.AssertNotNull(parentProxy, "parentProxy");
            Param.Ignore(unsafeCode);
            Param.Ignore(includeArrayBrackets);
            Param.Ignore(isExpression);

            this.AdvanceToNextCodeSymbol(parentProxy);
            var expressionProxy = new CodeUnitProxy();

            TypeToken token = this.GetTypeToken(expressionProxy, unsafeCode, includeArrayBrackets, isExpression);

            // Create and return the literal expression.
            var expression = new LiteralExpression(expressionProxy, token);
            parentProxy.Children.Add(expression);

            return expression;
        }

        /// <summary>
        /// Reads an expression beginning with an opening parenthesis.
        /// </summary>
        /// <param name="parentProxy">Represents the parent codeUnit.</param>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <returns>Returns the expression.</returns>
        private Expression GetOpenParenthesisExpression(CodeUnitProxy parentProxy, bool unsafeCode)
        {
            Param.AssertNotNull(parentProxy, "parentProxy");
            Param.Ignore(unsafeCode);

            Expression expression = null;

            // Now check whether this is a cast.
            if (this.IsCastExpression(unsafeCode))
            {
                expression = this.GetCastExpression(parentProxy, unsafeCode);
            }
            else
            {
                // This is an expression wrapped in parenthesis.
                expression = this.GetParenthesizedExpression(parentProxy, unsafeCode);
            }

            return expression;
        }

        /// <summary>
        /// Reads a cast expression.
        /// </summary>
        /// <param name="parentProxy">Represents the parent codeUnit.</param>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <returns>Returns the expression.</returns>
        private CastExpression GetCastExpression(CodeUnitProxy parentProxy, bool unsafeCode)
        {
            Param.AssertNotNull(parentProxy, "parentProxy");
            Param.Ignore(unsafeCode);

            this.AdvanceToNextCodeSymbol(parentProxy);
            var expressionProxy = new CodeUnitProxy();

            // Get the opening parenthesis.
            BracketToken openParenthesis = (BracketToken)this.GetToken(expressionProxy, TokenType.OpenParenthesis, SymbolType.OpenParenthesis);

            // Get the next token. It must be an unknown word.
            Symbol symbol = this.PeekNextSymbol();
            if (symbol.SymbolType != SymbolType.Other)
            {
                throw this.CreateSyntaxException();
            }

            // Get the casted expression.
            LiteralExpression type = this.GetTypeTokenExpression(expressionProxy, unsafeCode, true);
            if (type == null || type.Children.Count == 0)
            {
                throw this.CreateSyntaxException();
            }

            // Get the closing parenthesis.
            BracketToken closeParenthesis = (BracketToken)this.GetToken(expressionProxy, TokenType.CloseParenthesis, SymbolType.CloseParenthesis);

            openParenthesis.MatchingBracket = closeParenthesis;
            closeParenthesis.MatchingBracket = openParenthesis;

            // Get the embedded expression being casted.
            Expression castedExpression = this.GetNextExpression(expressionProxy, ExpressionPrecedence.Unary, unsafeCode);
            if (castedExpression == null || castedExpression.Children.Count == 0)
            {
                throw this.CreateSyntaxException();
            }

            // Create and return the expression.
            var expression = new CastExpression(expressionProxy, type, castedExpression);
            parentProxy.Children.Add(expression);

            return expression;
        }

        /// <summary>
        /// Reads an expression wrapped in parenthesis expression.
        /// </summary>
        /// <param name="parentProxy">Represents the parent codeUnit.</param>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <returns>Returns the expression.</returns>
        private ParenthesizedExpression GetParenthesizedExpression(CodeUnitProxy parentProxy, bool unsafeCode)
        {
            Param.AssertNotNull(parentProxy, "parentProxy");
            Param.Ignore(unsafeCode);

            this.AdvanceToNextCodeSymbol(parentProxy);
            var expressionProxy = new CodeUnitProxy();

            // Get the opening parenthesis.
            BracketToken openParenthesis = (BracketToken)this.GetToken(expressionProxy, TokenType.OpenParenthesis, SymbolType.OpenParenthesis);

            // Get the inner expression.
            Expression innerExpression = this.GetNextExpression(expressionProxy, ExpressionPrecedence.None, unsafeCode);
            if (innerExpression == null)
            {
                throw this.CreateSyntaxException();
            }

            // Get the closing parenthesis.
            BracketToken closeParenthesis = (BracketToken)this.GetToken(expressionProxy, TokenType.CloseParenthesis, SymbolType.CloseParenthesis);

            openParenthesis.MatchingBracket = closeParenthesis;
            closeParenthesis.MatchingBracket = openParenthesis;

            // Create and return the expression.
            var expression = new ParenthesizedExpression(expressionProxy, innerExpression);
            parentProxy.Children.Add(expression);

            return expression;
        }

        /// <summary>
        /// Reads the argument list for a method invocation expression.
        /// </summary>
        /// <param name="expressionProxy">Proxy object for the expression being created.</param>
        /// <param name="closingSymbol">The symbol that closes the argument list.</param>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <returns>Returns the list of arguments in the method invocation.</returns>
        private ArgumentList GetArgumentList(CodeUnitProxy expressionProxy, SymbolType closingSymbol, bool unsafeCode)
        {
            Param.AssertNotNull(expressionProxy, "expressionProxy");
            Param.AssertNotNull(closingSymbol, "closingSymbol");
            Param.Ignore(unsafeCode);

            var argumentListProxy = new CodeUnitProxy();

            Symbol symbol = this.PeekNextSymbol();

            while (symbol != null)
            {
                this.AdvanceToNextCodeSymbol(argumentListProxy);

                symbol = this.PeekNextSymbol();
                if (symbol.SymbolType == closingSymbol)
                {
                    break;
                }

                var argumentProxy = new CodeUnitProxy();
                if (symbol.SymbolType == SymbolType.Ref)
                {
                    this.GetToken(argumentProxy, TokenType.Ref, SymbolType.Ref);
                }
                else if (symbol.SymbolType == SymbolType.Out)
                {
                    this.GetToken(argumentProxy, TokenType.Out, SymbolType.Out);
                }
                else if (symbol.SymbolType == SymbolType.Params)
                {
                    this.GetToken(argumentProxy, TokenType.Params, SymbolType.Params);
                }

                this.GetNextExpression(argumentProxy, ExpressionPrecedence.None, unsafeCode);
                argumentListProxy.Children.Add(new Argument(argumentProxy));

                symbol = this.PeekNextSymbol();
                if (symbol.SymbolType == SymbolType.Comma)
                {
                    this.GetToken(argumentListProxy, TokenType.Comma, SymbolType.Comma);
                }
            }

            var argumentList = new ArgumentList(argumentListProxy);
            expressionProxy.Children.Add(argumentList);

            return argumentList;
        }

        /// <summary>
        /// Reads an as expression.
        /// </summary>
        /// <param name="expressionProxy">Proxy object for the expression being created.</param>
        /// <param name="leftHandSide">The expression on the left hand side of the operator.</param>
        /// <param name="previousPrecedence">The precedence of the expression just before this one.</param>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <returns>Returns the expression.</returns>
        private AsExpression GetAsExpression(
            CodeUnitProxy expressionProxy, Expression leftHandSide, ExpressionPrecedence previousPrecedence, bool unsafeCode)
        {
            Param.AssertNotNull(expressionProxy, "expressionProxy");
            Param.AssertNotNull(leftHandSide, "leftHandSide");
            Param.Ignore(previousPrecedence);
            Param.Ignore(unsafeCode);

            AsExpression expression = null;

            // Check the previous precedence to see if we are allowed to gather up the as expression.
            if (CheckPrecedence(previousPrecedence, ExpressionPrecedence.Relational))
            {
                // Make sure the left hand side has at least one token.
                Debug.Assert(leftHandSide.Children.Count > 0, "The left hand side should not be empty");

                // Get the as symbol.
                this.GetToken(expressionProxy, TokenType.As, SymbolType.As);

                // The next token must be the type.
                Symbol symbol = this.PeekNextSymbol();
                if (symbol.SymbolType != SymbolType.Other)
                {
                    throw this.CreateSyntaxException();
                }

                // Get the expression representing the type.
                LiteralExpression rightHandSide = this.GetTypeTokenExpression(expressionProxy, unsafeCode, true);
                if (rightHandSide == null || rightHandSide.Children.Count == 0)
                {
                    throw this.CreateSyntaxException();
                }

                // Create and return the expression.
                expression = new AsExpression(expressionProxy, leftHandSide, rightHandSide);
            }

            return expression;
        }

        /// <summary>
        /// Reads an is expression.
        /// </summary>
        /// <param name="expressionProxy">Proxy object for the expression being created.</param>
        /// <param name="leftHandSide">The expression on the left hand side of the operator.</param>
        /// <param name="previousPrecedence">The precedence of the expression just before this one.</param>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <returns>Returns the expression.</returns>
        private IsExpression GetIsExpression(
            CodeUnitProxy expressionProxy, Expression leftHandSide, ExpressionPrecedence previousPrecedence, bool unsafeCode)
        {
            Param.AssertNotNull(expressionProxy, "expressionProxy");
            Param.AssertNotNull(leftHandSide, "leftHandSide");
            Param.Ignore(previousPrecedence);
            Param.Ignore(unsafeCode);

            IsExpression expression = null;

            // Check the previous precedence to see if we are allowed to gather up the is expression.
            if (CheckPrecedence(previousPrecedence, ExpressionPrecedence.Relational))
            {
                // Make sure the left hand side has at least one token.
                Debug.Assert(leftHandSide.Children.Count > 0, "The left hand side should not be empty");

                // Get the is symbol.
                this.GetToken(expressionProxy, TokenType.Is, SymbolType.Is);

                // The next token must be the type.
                Symbol symbol = this.PeekNextSymbol();
                if (symbol.SymbolType != SymbolType.Other)
                {
                    throw this.CreateSyntaxException();
                }

                // Get the expression representing the type.
                LiteralExpression rightHandSide = this.GetTypeTokenExpression(expressionProxy, unsafeCode, true, true);
                if (rightHandSide == null || rightHandSide.Children.Count == 0)
                {
                    throw this.CreateSyntaxException();
                }

                // Create and return the expression.
                expression = new IsExpression(expressionProxy, leftHandSide, rightHandSide);
            }

            return expression;
        }

        /// <summary>
        /// Reads a primary increment expression.
        /// </summary>
        /// <param name="expressionProxy">Proxy object for the expression being created.</param>
        /// <param name="leftHandSide">The expression on the left hand side of the operator.</param>
        /// <param name="previousPrecedence">The precedence of the expression just before this one.</param>
        /// <returns>Returns the expression.</returns>
        private IncrementExpression GetPrimaryIncrementExpression(
            CodeUnitProxy expressionProxy, Expression leftHandSide, ExpressionPrecedence previousPrecedence)
        {
            Param.AssertNotNull(expressionProxy, "expressionProxy");
            Param.AssertNotNull(leftHandSide, "leftHandSide");
            Param.Ignore(previousPrecedence);

            IncrementExpression expression = null;

            // Check the previous precedence to see if we are allowed to gather up the as expression.
            if (CheckPrecedence(previousPrecedence, ExpressionPrecedence.Primary))
            {
                // Make sure the left hand side has at least one token.
                Debug.Assert(leftHandSide.Children.Count > 0, "The left hand side should not be empty.");

                // Get the increment symbol.
                this.GetOperatorSymbolToken(expressionProxy, OperatorType.Increment);
                
                // Create and return the expression.
                expression = new IncrementExpression(expressionProxy, leftHandSide, IncrementExpression.IncrementType.Postfix);
            }

            return expression;
        }

        /// <summary>
        /// Reads a primary decrement expression.
        /// </summary>
        /// <param name="expressionProxy">Proxy object for the expression being created.</param>
        /// <param name="leftHandSide">The expression on the left hand side of the operator.</param>
        /// <param name="previousPrecedence">The precedence of the expression just before this one.</param>
        /// <returns>Returns the expression.</returns>
        private DecrementExpression GetPrimaryDecrementExpression(
            CodeUnitProxy expressionProxy, Expression leftHandSide, ExpressionPrecedence previousPrecedence)
        {
            Param.AssertNotNull(expressionProxy, "expressionProxy");
            Param.AssertNotNull(leftHandSide, "leftHandSide");
            Param.Ignore(previousPrecedence);

            DecrementExpression expression = null;

            // Check the previous precedence to see if we are allowed to gather up the as expression.
            if (CheckPrecedence(previousPrecedence, ExpressionPrecedence.Primary))
            {
                // Make sure the left hand side has at least one token.
                Debug.Assert(leftHandSide.Children.Count > 0, "The left hand side should not be empty");

                // Get the decrement symbol.
                this.GetOperatorSymbolToken(expressionProxy, OperatorType.Decrement);
                
                // Create and return the expression.
                expression = new DecrementExpression(expressionProxy, leftHandSide, DecrementExpression.DecrementType.Postfix);
            }

            return expression;
        }

        /// <summary>
        /// Reads a unary increment expression.
        /// </summary>
        /// <param name="parentProxy">Represents the parent codeUnit.</param>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <returns>Returns the expression.</returns>
        private IncrementExpression GetUnaryIncrementExpression(CodeUnitProxy parentProxy, bool unsafeCode)
        {
            Param.AssertNotNull(parentProxy, "parentProxy");
            Param.Ignore(unsafeCode);

            this.AdvanceToNextCodeSymbol(parentProxy);
            var expressionProxy = new CodeUnitProxy();

            // Get the increment symbol.
            this.GetOperatorSymbolToken(expressionProxy, OperatorType.Increment);

            // Get the expression being incremented.
            Expression valueExpression = this.GetNextExpression(expressionProxy, ExpressionPrecedence.Unary, unsafeCode);
            if (valueExpression == null || valueExpression.Children.Count == 0)
            {
                throw this.CreateSyntaxException();
            }
            
            // Create and return the expression.
            var expression = new IncrementExpression(expressionProxy, valueExpression, IncrementExpression.IncrementType.Prefix);
            parentProxy.Children.Add(expression);

            return expression;
        }

        /// <summary>
        /// Reads a unary decrement expression.
        /// </summary>
        /// <param name="parentProxy">Represents the parent codeUnit.</param>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <returns>Returns the expression.</returns>
        private DecrementExpression GetUnaryDecrementExpression(CodeUnitProxy parentProxy, bool unsafeCode)
        {
            Param.AssertNotNull(parentProxy, "parentProxy");
            Param.Ignore(unsafeCode);

            this.AdvanceToNextCodeSymbol(parentProxy);

            CodeUnitProxy expressionProxy = new CodeUnitProxy();

            // Get the decrement symbol.
            this.GetOperatorSymbolToken(expressionProxy, OperatorType.Decrement);

            // Get the expression being decremented.
            Expression valueExpression = this.GetNextExpression(expressionProxy, ExpressionPrecedence.Unary, unsafeCode);
            if (valueExpression == null || valueExpression.Children.Count == 0)
            {
                throw this.CreateSyntaxException();
            }

            // Create and return the expression.
            var expression = new DecrementExpression(expressionProxy, valueExpression, DecrementExpression.DecrementType.Prefix);
            parentProxy.Children.Add(expression);

            return expression;
        }

        /// <summary>
        /// Reads a unary expression.
        /// </summary>
        /// <param name="parentProxy">Represents the parent codeUnit.</param>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <returns>Returns the expression.</returns>
        private UnaryExpression GetUnaryExpression(CodeUnitProxy parentProxy, bool unsafeCode)
        {
            Param.AssertNotNull(parentProxy, "parentProxy");
            Param.Ignore(unsafeCode);

            this.AdvanceToNextCodeSymbol(parentProxy);
            var expressionProxy = new CodeUnitProxy();

            // Create the token based on the type of the symbol.
            Symbol symbol = this.PeekNextSymbol();

            OperatorSymbolToken token;
            UnaryExpression.Operator operatorType;
            if (symbol.SymbolType == SymbolType.Plus)
            {
                operatorType = UnaryExpression.Operator.Positive;
                token = new PositiveOperator(symbol.Text, symbol.Location, this.symbols.Generated);
            }
            else if (symbol.SymbolType == SymbolType.Minus)
            {
                operatorType = UnaryExpression.Operator.Negative;
                token = new NegativeOperator(symbol.Text, symbol.Location, this.symbols.Generated);
            }
            else if (symbol.SymbolType == SymbolType.Not)
            {
                operatorType = UnaryExpression.Operator.Not;
                token = new NotOperator(symbol.Text, symbol.Location, this.symbols.Generated);
            }
            else if (symbol.SymbolType == SymbolType.Tilde)
            {
                operatorType = UnaryExpression.Operator.BitwiseCompliment;
                token = new BitwiseComplementOperator(symbol.Text, symbol.Location, this.symbols.Generated);
            }
            else
            {
                // This is not a unary type.
                Debug.Fail("Unexpected operator type");
                throw new StyleCopException();
            }

            expressionProxy.Children.Add(token);
            this.symbols.Advance();

            // Get the expression after the operator.
            Expression operatorExpression = this.GetNextExpression(expressionProxy, ExpressionPrecedence.Unary, unsafeCode);
            if (operatorExpression == null || operatorExpression.Children.Count == 0)
            {
                throw this.CreateSyntaxException();
            }

            // Create and return the expression.
            var expression = new UnaryExpression(expressionProxy, operatorType, operatorExpression);
            parentProxy.Children.Add(expression);

            return expression;
        }

        /// <summary>
        /// Reads a conditional expression.
        /// </summary>
        /// <param name="expressionProxy">Proxy object for the expression being created.</param>
        /// <param name="leftHandSide">The expression on the left hand side of the operator.</param>
        /// <param name="previousPrecedence">The precedence of the expression just before this one.</param>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <returns>Returns the expression.</returns>
        private ConditionalExpression GetConditionalExpression(
            CodeUnitProxy expressionProxy, Expression leftHandSide, ExpressionPrecedence previousPrecedence, bool unsafeCode)
        {
            Param.AssertNotNull(expressionProxy, "expressionProxy");
            Param.AssertNotNull(leftHandSide, "leftHandSide");
            Param.Ignore(unsafeCode);
            Param.Ignore(previousPrecedence);

            ConditionalExpression expression = null;

            if (CheckPrecedence(previousPrecedence, ExpressionPrecedence.Conditional))
            {
                // Get the first operator.
                this.GetOperatorSymbolToken(expressionProxy, OperatorType.ConditionalQuestionMark);

                // Get the expression on the right-hand side of the operator.
                Expression trueValue = this.GetOperatorRightHandExpression(expressionProxy, ExpressionPrecedence.Conditional, unsafeCode);

                // Get the next operator and make sure it is the correct type.
                this.GetOperatorSymbolToken(expressionProxy, OperatorType.ConditionalColon);

                // Get the expression on the right-hand side of the operator.
                Expression falseValue = this.GetOperatorRightHandExpression(expressionProxy, ExpressionPrecedence.None, unsafeCode);

                // Create and return the expression.
                expression = new ConditionalExpression(expressionProxy, leftHandSide, trueValue, falseValue);
            }

            return expression;
        }

        /// <summary>
        /// Reads an arithmetic expression.
        /// </summary>
        /// <param name="expressionProxy">Proxy object for the expression being created.</param>
        /// <param name="leftHandSide">The expression on the left hand side of the operator.</param>
        /// <param name="previousPrecedence">The precedence of the expression just before this one.</param>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <returns>Returns the expression.</returns>
        private ArithmeticExpression GetArithmeticExpression(
            CodeUnitProxy expressionProxy, Expression leftHandSide, ExpressionPrecedence previousPrecedence, bool unsafeCode)
        {
            Param.AssertNotNull(expressionProxy, "expressionProxy");
            Param.AssertNotNull(leftHandSide, "leftHandSide");
            Param.Ignore(previousPrecedence);
            Param.Ignore(unsafeCode);

            ArithmeticExpression expression = null;
            
            // Read the details of the expression.
            OperatorSymbolToken operatorToken = this.PeekOperatorSymbolToken();
            Debug.Assert(
                operatorToken.Category == OperatorCategory.Arithmetic || operatorToken.Category == OperatorCategory.Shift, 
                "Expected an arithmetic or shift operator");

            // Check the precedence of the operators to make sure we can gather this statement now.
            ExpressionPrecedence precedence = GetOperatorPrecedence(operatorToken.SymbolType);
            if (CheckPrecedence(previousPrecedence, precedence))
            {
                // Create the operator toke again and save it.
                operatorToken = this.GetOperatorSymbolToken(expressionProxy);

                // Get the expression on the right-hand side of the operator.
                Expression rightHandSide = this.GetOperatorRightHandExpression(expressionProxy, precedence, unsafeCode);

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
                expression = new ArithmeticExpression(expressionProxy, type, leftHandSide, rightHandSide);
            }

            return expression;
        }

        /// <summary>
        /// Reads an assignment expression.
        /// </summary>
        /// <param name="expressionProxy">Proxy object for the expression being created.</param>
        /// <param name="leftHandSide">The expression on the left hand side of the operator.</param>
        /// <param name="previousPrecedence">The precedence of the expression just before this one.</param>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <returns>Returns the expression.</returns>
        private AssignmentExpression GetAssignmentExpression(
            CodeUnitProxy expressionProxy, Expression leftHandSide, ExpressionPrecedence previousPrecedence, bool unsafeCode)
        {
            Param.AssertNotNull(expressionProxy, "expressionProxy");
            Param.AssertNotNull(leftHandSide, "leftHandSide");
            Param.Ignore(previousPrecedence);
            Param.Ignore(unsafeCode);

            AssignmentExpression expression = null;

            // Read the details of the expression.
            OperatorSymbolToken operatorToken = this.PeekOperatorSymbolToken();
            Debug.Assert(operatorToken.Category == OperatorCategory.Assignment, "Expected an assignment operator");

            // Check the precedence of the operators to make sure we can gather this statement now.
            ExpressionPrecedence precedence = GetOperatorPrecedence(operatorToken.SymbolType);
            if (CheckPrecedence(previousPrecedence, precedence))
            {
                // Create the operator toke again and save it.
                operatorToken = this.GetOperatorSymbolToken(expressionProxy);

                // Get the expression on the right-hand side of the operator.
                Expression rightHandSide = this.GetOperatorRightHandExpression(expressionProxy, precedence, unsafeCode);

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
                expression = new AssignmentExpression(expressionProxy, type, leftHandSide, rightHandSide);
            }

            return expression;
        }

        /// <summary>
        /// Reads a relational expression.
        /// </summary>
        /// <param name="expressionProxy">Proxy object for the expression being created.</param>
        /// <param name="leftHandSide">The expression on the left hand side of the operator.</param>
        /// <param name="previousPrecedence">The precedence of the expression just before this one.</param>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <returns>Returns the expression.</returns>
        private RelationalExpression GetRelationalExpression(
            CodeUnitProxy expressionProxy, Expression leftHandSide, ExpressionPrecedence previousPrecedence, bool unsafeCode)
        {
            Param.AssertNotNull(expressionProxy, "expressionProxy");
            Param.AssertNotNull(leftHandSide, "leftHandSide");
            Param.Ignore(previousPrecedence);
            Param.Ignore(unsafeCode);

            RelationalExpression expression = null;

            // Read the details of the expression.
            OperatorSymbolToken operatorToken = this.PeekOperatorSymbolToken();
            Debug.Assert(operatorToken.Category == OperatorCategory.Relational, "Expected a relational operator");

            // Check the precedence of the operators to make sure we can gather this statement now.
            ExpressionPrecedence precedence = GetOperatorPrecedence(operatorToken.SymbolType);
            if (CheckPrecedence(previousPrecedence, precedence))
            {
                // Create the operator toke again and save it.
                operatorToken = this.GetOperatorSymbolToken(expressionProxy);

                // Get the expression on the right-hand side of the operator.
                Expression rightHandSide = this.GetOperatorRightHandExpression(expressionProxy, precedence, unsafeCode);

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
                expression = new RelationalExpression(expressionProxy, type, leftHandSide, rightHandSide);
            }

            return expression;
        }

        /// <summary>
        /// Reads a logical expression.
        /// </summary>
        /// <param name="expressionProxy">Proxy object for the expression being created.</param>
        /// <param name="leftHandSide">The expression on the left hand side of the operator.</param>
        /// <param name="previousPrecedence">The precedence of the expression just before this one.</param>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <returns>Returns the expression.</returns>
        private LogicalExpression GetLogicalExpression(
            CodeUnitProxy expressionProxy, Expression leftHandSide, ExpressionPrecedence previousPrecedence, bool unsafeCode)
        {
            Param.AssertNotNull(expressionProxy, "expressionProxy");
            Param.AssertNotNull(leftHandSide, "leftHandSide");
            Param.Ignore(previousPrecedence);
            Param.Ignore(unsafeCode);

            LogicalExpression expression = null;

            // Read the details of the expression.
            OperatorSymbolToken operatorToken = this.PeekOperatorSymbolToken();
            Debug.Assert(operatorToken.Category == OperatorCategory.Logical, "Expected a logical operator");

            // Check the precedence of the operators to make sure we can gather this statement now.
            ExpressionPrecedence precedence = GetOperatorPrecedence(operatorToken.SymbolType);
            if (CheckPrecedence(previousPrecedence, precedence))
            {
                // Create the operator toke again and save it.
                operatorToken = this.GetOperatorSymbolToken(expressionProxy);

                // Get the expression on the right-hand side of the operator.
                Expression rightHandSide = this.GetOperatorRightHandExpression(expressionProxy, precedence, unsafeCode);

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
                expression = new LogicalExpression(expressionProxy, type, leftHandSide, rightHandSide);
            }

            return expression;
        }

        /// <summary>
        /// Reads a conditional logical expression.
        /// </summary>
        /// <param name="expressionProxy">Proxy object for the expression being created.</param>
        /// <param name="leftHandSide">The expression on the left hand side of the operator.</param>
        /// <param name="previousPrecedence">The precedence of the expression just before this one.</param>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <returns>Returns the expression.</returns>
        private ConditionalLogicalExpression GetConditionalLogicalExpression(
            CodeUnitProxy expressionProxy, Expression leftHandSide, ExpressionPrecedence previousPrecedence, bool unsafeCode)
        {
            Param.AssertNotNull(expressionProxy, "expressionProxy");
            Param.AssertNotNull(leftHandSide, "leftHandSide");
            Param.Ignore(previousPrecedence);
            Param.Ignore(unsafeCode);

            ConditionalLogicalExpression expression = null;

            // Read the details of the expression.
            OperatorSymbolToken operatorToken = this.PeekOperatorSymbolToken();
            Debug.Assert(operatorToken.Category == OperatorCategory.Logical, "Expected a logical operator");

            // Check the precedence of the operators to make sure we can gather this statement now.
            ExpressionPrecedence precedence = GetOperatorPrecedence(operatorToken.SymbolType);
            if (CheckPrecedence(previousPrecedence, precedence))
            {
                // Create the operator toke again and save it.
                operatorToken = this.GetOperatorSymbolToken(expressionProxy);

                // Get the expression on the right-hand side of the operator.
                Expression rightHandSide = this.GetOperatorRightHandExpression(expressionProxy, precedence, unsafeCode);

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
                expression = new ConditionalLogicalExpression(expressionProxy, type, leftHandSide, rightHandSide);
            }

            return expression;
        }

        /// <summary>
        /// Reads a null coalescing expression.
        /// </summary>
        /// <param name="expressionProxy">Proxy object for the expression being created.</param>
        /// <param name="leftHandSide">The expression on the left hand side of the operator.</param>
        /// <param name="previousPrecedence">The precedence of the expression just before this one.</param>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <returns>Returns the expression.</returns>
        private NullCoalescingExpression GetNullCoalescingExpression(
            CodeUnitProxy expressionProxy, Expression leftHandSide, ExpressionPrecedence previousPrecedence, bool unsafeCode)
        {
            Param.AssertNotNull(expressionProxy, "expressionProxy");
            Param.AssertNotNull(leftHandSide, "leftHandSide");
            Param.Ignore(previousPrecedence);
            Param.Ignore(unsafeCode);

            NullCoalescingExpression expression = null;

            // Read the details of the expression.
            OperatorSymbolToken operatorToken = this.PeekOperatorSymbolToken();
            Debug.Assert(operatorToken.SymbolType == OperatorType.NullCoalescingSymbol, "Expected a null-coalescing symbol");

            // Check the precedence of the operators to make sure we can gather this statement now.
            ExpressionPrecedence precedence = GetOperatorPrecedence(operatorToken.SymbolType);
            if (CheckPrecedence(previousPrecedence, precedence))
            {
                // Create the operator toke again and save it.
                operatorToken = this.GetOperatorSymbolToken(expressionProxy);

                // Get the expression on the right-hand side of the operator.
                Expression rightHandSide = this.GetOperatorRightHandExpression(expressionProxy, precedence, unsafeCode);

                // Create and return the expression.
                expression = new NullCoalescingExpression(expressionProxy, leftHandSide, rightHandSide);
            }

            return expression;
        }

        /// <summary>
        /// Reads and returns the right-hand expression of an operator expression.
        /// </summary>
        /// <param name="parentProxy">Represents the parent codeUnit.</param>
        /// <param name="precedence">The precendence of this operator expression.</param>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <returns>Returns the expression.</returns>
        private Expression GetOperatorRightHandExpression(CodeUnitProxy parentProxy, ExpressionPrecedence precedence, bool unsafeCode)
        {
            Param.AssertNotNull(parentProxy, "parentProxy");
            Param.AssertNotNull(precedence, "precedence");
            Param.Ignore(unsafeCode);

            // Get the right hand expression.
            Expression rightHandSide = this.GetNextExpression(parentProxy, precedence, unsafeCode);
            if (rightHandSide == null)
            {
                throw this.CreateSyntaxException();
            }

            // Make sure the right hand side has at least one token.
            Debug.Assert(rightHandSide.Children.Count > 0, "The right-hand side should not be empty.");

            return rightHandSide;
        }

        /// <summary>
        /// Reads a checked expression from the code.
        /// </summary>
        /// <param name="parentProxy">Represents the parent codeUnit.</param>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <returns>Returns the expression.</returns>
        private CheckedExpression GetCheckedExpression(CodeUnitProxy parentProxy, bool unsafeCode)
        {
            Param.AssertNotNull(parentProxy, "parentProxy");
            Param.Ignore(unsafeCode);

            this.AdvanceToNextCodeSymbol(parentProxy);
            var expressionProxy = new CodeUnitProxy();

            // Get the checked keyword.
            this.GetToken(expressionProxy, TokenType.Checked, SymbolType.Checked);

            // The next symbol will be the opening parenthesis.
            BracketToken openParenthesis = (BracketToken)this.GetToken(expressionProxy, TokenType.OpenParenthesis, SymbolType.OpenParenthesis);

            // Get the inner expression.
            Expression innerExpression = this.GetNextExpression(expressionProxy, ExpressionPrecedence.None, unsafeCode);

            // Get the closing parenthesis.
            BracketToken closeParenthesis = (BracketToken)this.GetToken(expressionProxy, TokenType.CloseParenthesis, SymbolType.CloseParenthesis);

            openParenthesis.MatchingBracket = closeParenthesis;
            closeParenthesis.MatchingBracket = openParenthesis;

            // Create and return the expression.
            var expression = new CheckedExpression(expressionProxy, innerExpression);
            parentProxy.Children.Add(expression);

            return expression;
        }

        /// <summary>
        /// Reads an unchecked expression from the code.
        /// </summary>
        /// <param name="parentProxy">Represents the parent codeUnit.</param>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <returns>Returns the expression.</returns>
        private UncheckedExpression GetUncheckedExpression(CodeUnitProxy parentProxy, bool unsafeCode)
        {
            Param.AssertNotNull(parentProxy, "parentProxy");
            Param.Ignore(unsafeCode);

            this.AdvanceToNextCodeSymbol(parentProxy);
            var expressionProxy = new CodeUnitProxy();

            // Get the unchecked keyword.
            this.GetToken(expressionProxy, TokenType.Unchecked, SymbolType.Unchecked);

            // The next symbol will be the opening parenthesis.
            BracketToken openParenthesis = (BracketToken)this.GetToken(expressionProxy, TokenType.OpenParenthesis, SymbolType.OpenParenthesis);

            // Get the inner expression.
            Expression innerExpression = this.GetNextExpression(expressionProxy, ExpressionPrecedence.None, unsafeCode);

            // Get the closing parenthesis.
            BracketToken closeParenthesis = (BracketToken)this.GetToken(expressionProxy, TokenType.CloseParenthesis, SymbolType.CloseParenthesis);

            openParenthesis.MatchingBracket = closeParenthesis;
            closeParenthesis.MatchingBracket = openParenthesis;

            // Create and return the expression.
            var expression = new UncheckedExpression(expressionProxy, innerExpression);
            parentProxy.Children.Add(expression);

            return expression;
        }

        /// <summary>
        /// Reads a new allocation expression from the code.
        /// </summary>
        /// <param name="parentProxy">Represents the parent codeUnit.</param>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <returns>Returns the expression.</returns>
        private Expression GetNewAllocationExpression(CodeUnitProxy parentProxy, bool unsafeCode)
        {
            Param.AssertNotNull(parentProxy, "parentProxy");
            Param.Ignore(unsafeCode);

            this.AdvanceToNextCodeSymbol(parentProxy);
            var expressionProxy = new CodeUnitProxy();

            // The first symbol must be the new keyword.
            this.GetToken(expressionProxy, TokenType.New, SymbolType.New);

            Expression expression = null;

            // The next token must be a type identifier, or an opening curly bracket for an anonymous type creation, 
            // or an opening square bracket for a implicitly typed array creation.
            Symbol symbol = this.PeekNextSymbol();
            if (symbol.SymbolType == SymbolType.OpenCurlyBracket)
            {
                expression = this.GetNewAnonymousTypeExpression(expressionProxy, parentProxy, unsafeCode);
            }
            else if (symbol.SymbolType == SymbolType.OpenSquareBracket)
            {
                expression = this.GetNewArrayTypeExpression(expressionProxy, parentProxy, unsafeCode, null);
            }
            else if (symbol.SymbolType != SymbolType.Other)
            {
                throw this.CreateSyntaxException();
            }

            if (expression == null)
            {
                // Get the type expression.
                Expression type = this.GetTypeTokenExpression(expressionProxy, unsafeCode, false);
                if (type == null || type.Children.Count == 0)
                {
                    throw this.CreateSyntaxException();
                }

                // Figure out the type of the new expression. If we hit an open parenthesis first,
                // then this is standard new type expression. If we hit an open square bracket first,
                // then this is a new array expression. If we hit an opening curly bracket first,
                // then this is a new expression which omits the argument list and uses an object 
                // or collection initializer.
                symbol = this.PeekNextSymbol();

                // If this is a new array expression, get and return it.
                if (symbol.SymbolType == SymbolType.OpenSquareBracket)
                {
                    expression = this.GetNewArrayTypeExpression(expressionProxy, parentProxy, unsafeCode, type);
                }
                else
                {
                    expression = this.GetNewNonArrayTypeExpression(expressionProxy, parentProxy, unsafeCode, type);
                }
            }

            return expression;
        }

        /// <summary>
        /// Reads a new non-array type allocation expression from the code.
        /// </summary>
        /// <param name="expressionProxy">The proxy object for this expression.</param>
        /// <param name="parentProxy">The proxy object for the parent.</param>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <param name="type">The type of the array.</param>
        /// <returns>Returns the expression.</returns>
        private NewExpression GetNewNonArrayTypeExpression(CodeUnitProxy expressionProxy, CodeUnitProxy parentProxy, bool unsafeCode, Expression type)
        {
            Param.AssertNotNull(expressionProxy, "expressionProxy");
            Param.AssertNotNull(parentProxy, "parentProxy");
            Param.Ignore(unsafeCode);
            Param.AssertNotNull(type, "type");

            this.AdvanceToNextCodeSymbol(expressionProxy); 

            Expression typeCreationExpression = type;

            // If the next symbol is an opening parenthesis, then there is an argument
            // list which must be attached to the type creation expression.
            Symbol symbol = this.PeekNextSymbol();

            if (symbol.SymbolType == SymbolType.OpenParenthesis)
            {
                typeCreationExpression = this.GetMethodInvocationExpression(expressionProxy, type, ExpressionPrecedence.None, unsafeCode);
                if (typeCreationExpression == null || typeCreationExpression.Children.Count == 0)
                {
                    throw this.CreateSyntaxException();
                }
            }

            // If the next symbol is an opening curly bracket, then there is an object
            // or collection initializer attached which must also be parsed.
            symbol = this.PeekNextSymbol();

            Expression initializer = null;
            if (symbol.SymbolType == SymbolType.OpenCurlyBracket)
            {
                initializer = this.GetObjectOrCollectionInitializerExpression(expressionProxy, unsafeCode);

                if (initializer == null || initializer.Children.Count == 0)
                {
                    throw this.CreateSyntaxException();
                }
            }

            // Create and return the expression.
            var expression = new NewExpression(expressionProxy, typeCreationExpression, initializer);
            parentProxy.Children.Add(expression);

            return expression;
        }

        /// <summary>
        /// Reads a new anonymous type allocation expression from the code.
        /// </summary>
        /// <param name="expressionProxy">The proxy object for this expression.</param>
        /// <param name="parentProxy">The proxy object for the parent.</param>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <returns>Returns the expression.</returns>
        private NewExpression GetNewAnonymousTypeExpression(CodeUnitProxy expressionProxy, CodeUnitProxy parentProxy, bool unsafeCode)
        {
            Param.AssertNotNull(expressionProxy, "expressionProxy");
            Param.AssertNotNull(parentProxy, "parentProxy");
            Param.Ignore(unsafeCode);

            this.AdvanceToNextCodeSymbol(expressionProxy);

            // Get the anonymous type initializer expression.
            CollectionInitializerExpression initializer = this.GetAnonymousTypeInitializerExpression(expressionProxy, unsafeCode);

            // Create and return the expression.
            var expression = new NewExpression(expressionProxy, null, initializer);
            parentProxy.Children.Add(expression);

            return expression;
        }

        /// <summary>
        /// Reads an anonymous type initializer expression from the code.
        /// </summary>
        /// <param name="parentProxy">Represents the parent codeUnit.</param>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <returns>Returns the expression.</returns>
        private CollectionInitializerExpression GetAnonymousTypeInitializerExpression(CodeUnitProxy parentProxy, bool unsafeCode)
        {
            Param.AssertNotNull(parentProxy, "parentProxy");
            Param.Ignore(unsafeCode);

            // If the next symbol is an opening curly bracket, then there is an object
            // or collection initializer attached which must also be parsed.
            this.AdvanceToNextCodeSymbol(parentProxy);

            CollectionInitializerExpression initializer = this.GetCollectionInitializerExpression(parentProxy, unsafeCode);

            if (initializer == null || initializer.Children.Count == 0)
            {
                throw this.CreateSyntaxException();
            }

            // Ensure that all of the initializer expressions are either simple literals,
            // member access expressions, or assignment expressions, since these are the
            // only types of expressions allowed within an anonymous type definition.
            for (Expression initializerExpression = initializer.FindFirstChild<Expression>(); 
                initializerExpression != null;
                initializerExpression = initializerExpression.FindNextSibling<Expression>())
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
        /// <param name="expressionProxy">The proxy object for this expression.</param>
        /// <param name="parentProxy">The proxy object for the parent.</param>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <param name="type">The type of the array. This may be null for an implicitly typed array.</param>
        /// <returns>Returns the expression.</returns>
        private NewArrayExpression GetNewArrayTypeExpression(CodeUnitProxy expressionProxy, CodeUnitProxy parentProxy, bool unsafeCode, Expression type)
        {
            Param.AssertNotNull(expressionProxy, "expressionProxy");
            Param.AssertNotNull(parentProxy, "parentProxy");
            Param.Ignore(unsafeCode);
            Param.Ignore(type);

            this.AdvanceToNextCodeSymbol(expressionProxy);

            // If the type is null, then this is an implicitly typed array and we will only find
            // array brackets here. Otherwise, we must get the array access expression which includes the type.
            if (type == null)
            {
                this.MovePastArrayBrackets(expressionProxy);
            }
            else
            {
                Symbol symbol = this.PeekNextSymbol();

                // Get all of the array access expressions.
                while (symbol.SymbolType == SymbolType.OpenSquareBracket)
                {
                    type = this.GetArrayAccessExpression(expressionProxy, type, ExpressionPrecedence.None, unsafeCode);
                    if (type == null || type.Children.Count == 0)
                    {
                        throw this.CreateSyntaxException();
                    }

                    symbol = this.PeekNextSymbol();
                }
            }

            // Make sure there was at least one array access.
            if (type != null && type.ExpressionType != ExpressionType.ArrayAccess)
            {
                throw this.CreateSyntaxException();
            }

            // Get the next symbol and check the type.
            Symbol nextSymbol = this.PeekNextSymbol();

            // Get the initializer if there is one.
            ArrayInitializerExpression initializer = null;
            if (nextSymbol.SymbolType == SymbolType.OpenCurlyBracket)
            {
                initializer = this.GetArrayInitializerExpression(expressionProxy, unsafeCode);
            }

            // For an implicitly typed array, an array initializer is required.
            if (type == null && initializer == null)
            {
                throw this.CreateSyntaxException();
            }

            // Create and return the expression.
            var expression = new NewArrayExpression(expressionProxy, type as ArrayAccessExpression, initializer);
            parentProxy.Children.Add(expression);

            return expression;
        }

        /// <summary>
        /// Moves past all array brackets. This assumes that the brackets are part of a new array allocation.
        /// </summary>
        /// <param name="parentProxy">Proxy for the parent codeUnit..</param>
        private void MovePastArrayBrackets(CodeUnitProxy parentProxy)
        {
            Param.AssertNotNull(parentProxy, "parentProxy");

            // The next symbol must be an opening array bracket.
            Symbol symbol = this.PeekNextSymbol();

            while (symbol.SymbolType == SymbolType.OpenSquareBracket)
            {
                this.AdvanceToNextCodeSymbol(parentProxy);

                // Add the opening array bracket.
                BracketToken openingBracket = (BracketToken)this.GetToken(parentProxy, TokenType.OpenSquareBracket, SymbolType.OpenSquareBracket);

                // Get the next symbol.
                symbol = this.PeekNextSymbol();

                // Move past any commas.
                while (symbol.SymbolType == SymbolType.Comma)
                {
                    this.GetToken(parentProxy, TokenType.Comma, SymbolType.Comma);
                    symbol = this.PeekNextSymbol();
                }

                // Add the closing array bracket.
                BracketToken closingBracket = (BracketToken)this.GetToken(parentProxy, TokenType.CloseSquareBracket, SymbolType.CloseSquareBracket);

                openingBracket.MatchingBracket = closingBracket;
                closingBracket.MatchingBracket = openingBracket;

                // If the next symbol is another opening square bracket, repeat.
                symbol = this.PeekNextSymbol();
            }
        }

        /// <summary>
        /// Gets an object initializer or collection initializer expression.
        /// </summary>
        /// <param name="parentProxy">Represents the parent codeUnit.</param>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <returns>Returns the expression.</returns>
        private Expression GetObjectOrCollectionInitializerExpression(CodeUnitProxy parentProxy, bool unsafeCode)
        {
            Param.AssertNotNull(parentProxy, "parentProxy");
            Param.Ignore(unsafeCode);

            this.AdvanceToNextCodeSymbol(parentProxy);

            // Determine whether this is an object initializer or a collection initializer.
            bool objectInitializer = false;

            // Peek at the next symbol after the curly bracket.
            int index = this.GetNextCodeSymbolIndex(2);
            if (index == -1)
            {
                throw this.CreateSyntaxException();
            }

            Symbol symbol = this.symbols.Peek(index);
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
                return this.GetObjectInitializerExpression(parentProxy, unsafeCode);
            }
            else
            {
                return this.GetCollectionInitializerExpression(parentProxy, unsafeCode);
            }
        }

        /// <summary>
        /// Gets an object initializer expression.
        /// </summary>
        /// <param name="parentProxy">Represents the parent codeUnit.</param>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <returns>Returns the expression.</returns>
        private ObjectInitializerExpression GetObjectInitializerExpression(CodeUnitProxy parentProxy, bool unsafeCode)
        {
            Param.AssertNotNull(parentProxy, "parentProxy");
            Param.Ignore(unsafeCode);

            this.AdvanceToNextCodeSymbol(parentProxy);
            var expressionProxy = new CodeUnitProxy();
            var initializerExpressions = new List<AssignmentExpression>();

            // Add and move past the opening curly bracket.
            BracketToken openingBracket = (BracketToken)this.GetToken(expressionProxy, TokenType.OpenCurlyBracket, SymbolType.OpenCurlyBracket);

            while (true)
            {
                // If the next symbol is the closing curly bracket, then we are done.
                Symbol symbol = this.PeekNextSymbol();
                if (symbol.SymbolType == SymbolType.CloseCurlyBracket)
                {
                    break;
                }

                var initializerExpressionProxy = new CodeUnitProxy();

                // Get the identifier.
                this.AdvanceToNextCodeSymbol(expressionProxy);
                LiteralExpression identifier = this.GetLiteralExpression(initializerExpressionProxy, unsafeCode);

                // Get the equals sign.
                symbol = this.PeekNextSymbol();
                if (symbol.SymbolType != SymbolType.Equals)
                {
                    throw this.CreateSyntaxException();
                }

                this.GetOperatorSymbolToken(initializerExpressionProxy, OperatorType.Equals);

                // Get the initializer value. If this begins with an opening curly bracket,
                // this is an embedded object or collection initializer. Otherwise, it is
                // some other kind of expression.
                Expression initializerValue = null;

                symbol = this.PeekNextSymbol();
                if (symbol.SymbolType == SymbolType.OpenCurlyBracket)
                {
                    initializerValue = this.GetObjectOrCollectionInitializerExpression(initializerExpressionProxy, unsafeCode);
                }
                else
                {
                    initializerValue = this.GetNextExpression(initializerExpressionProxy, ExpressionPrecedence.None, unsafeCode);
                }

                // Create and add this initializer.
                var initializerExpression = new AssignmentExpression(initializerExpressionProxy, AssignmentExpression.Operator.Equals, identifier, initializerValue);
                expressionProxy.Children.Add(initializerExpression);
                initializerExpressions.Add(initializerExpression);

                // Check whether we're done.
                symbol = this.PeekNextSymbol();
                if (symbol.SymbolType == SymbolType.Comma)
                {
                    this.GetToken(expressionProxy, TokenType.Comma, SymbolType.Comma);

                    // If the next symbol after this is the closing curly bracket, then we are done.
                    symbol = this.PeekNextSymbol();
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
            BracketToken closingBracket = (BracketToken)this.GetToken(expressionProxy, TokenType.CloseCurlyBracket, SymbolType.CloseCurlyBracket);

            openingBracket.MatchingBracket = closingBracket;
            closingBracket.MatchingBracket = openingBracket;

            // Create and return the expression.
            var expression = new ObjectInitializerExpression(expressionProxy, initializerExpressions.ToArray());
            parentProxy.Children.Add(expression);

            return expression;
        }

        /// <summary>
        /// Gets a collection initializer expression.
        /// </summary>
        /// <param name="parentProxy">Represents the parent codeUnit.</param>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <returns>Returns the expression.</returns>
        private CollectionInitializerExpression GetCollectionInitializerExpression(CodeUnitProxy parentProxy, bool unsafeCode)
        {
            Param.AssertNotNull(parentProxy, "parentProxy");
            Param.Ignore(unsafeCode);

            this.AdvanceToNextCodeSymbol(parentProxy);
            var expressionProxy = new CodeUnitProxy();
            var initializerExpressions = new List<Expression>();

            // Add and move past the opening curly bracket.
            BracketToken openingBracket = (BracketToken)this.GetToken(expressionProxy, TokenType.OpenCurlyBracket, SymbolType.OpenCurlyBracket);

            while (true)
            {
                // If the next symbol is the closing curly bracket, then we are done.
                Symbol symbol = this.PeekNextSymbol();
                if (symbol.SymbolType == SymbolType.CloseCurlyBracket)
                {
                    break;
                }

                // Get the next expression.
                Expression initializerExpression = null;
                if (symbol.SymbolType == SymbolType.OpenCurlyBracket)
                {
                    initializerExpression = this.GetCollectionInitializerExpression(expressionProxy, unsafeCode);
                }
                else
                {
                    initializerExpression = this.GetNextExpression(expressionProxy, ExpressionPrecedence.None, unsafeCode);
                }

                initializerExpressions.Add(initializerExpression);

                // Check whether we're done.
                symbol = this.PeekNextSymbol();
                if (symbol.SymbolType == SymbolType.Comma)
                {
                    this.GetToken(expressionProxy, TokenType.Comma, SymbolType.Comma);

                    // If the next symbol after this is the closing curly bracket, then we are done.
                    symbol = this.PeekNextSymbol();
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
            BracketToken closingBracket = (BracketToken)this.GetToken(expressionProxy, TokenType.CloseCurlyBracket, SymbolType.CloseCurlyBracket);

            openingBracket.MatchingBracket = closingBracket;
            closingBracket.MatchingBracket = openingBracket;

            // Create and return the expression.
            var expression = new CollectionInitializerExpression(expressionProxy, initializerExpressions);
            parentProxy.Children.Add(expression);

            return expression;
        }

        /// <summary>
        /// Reads a stackalloc expression from the code.
        /// </summary>
        /// <param name="parentProxy">Represents the parent codeUnit.</param>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <returns>Returns the expression.</returns>
        private StackallocExpression GetStackallocExpression(CodeUnitProxy parentProxy, bool unsafeCode)
        {
            Param.AssertNotNull(parentProxy, "parentProxy");
            Param.Ignore(unsafeCode);

            this.AdvanceToNextCodeSymbol(parentProxy);
            var expressionProxy = new CodeUnitProxy();

            // The first symbol must be the stackalloc keyword.
            this.GetToken(expressionProxy, TokenType.Stackalloc, SymbolType.Stackalloc);

            // The next token must be the type identifier.
            Symbol symbol = this.PeekNextSymbol();
            if (symbol.SymbolType != SymbolType.Other)
            {
                throw this.CreateSyntaxException();
            }

            // Get the type expression.
            Expression type = this.GetTypeTokenExpression(expressionProxy, unsafeCode, false);
            if (type == null || type.Children.Count == 0)
            {
                throw this.CreateSyntaxException();
            }

            // Get the array access expression.
            ArrayAccessExpression arrayAccess = this.GetArrayAccessExpression(expressionProxy, type, ExpressionPrecedence.None, unsafeCode);
            if (arrayAccess == null || arrayAccess.Children.Count == 0)
            {
                throw this.CreateSyntaxException();
            }

            // Create and return the expression.
            var expression = new StackallocExpression(expressionProxy, arrayAccess);
            parentProxy.Children.Add(expression);

            return expression;
        }

        /// <summary>
        /// Reads a sizeof expression from the code.
        /// </summary>
        /// <param name="parentProxy">Represents the parent codeUnit.</param>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <returns>Returns the expression.</returns>
        private SizeofExpression GetSizeofExpression(CodeUnitProxy parentProxy, bool unsafeCode)
        {
            Param.AssertNotNull(parentProxy, "parentProxy");
            Param.Ignore(unsafeCode);

            this.AdvanceToNextCodeSymbol(parentProxy);
            var expressionProxy = new CodeUnitProxy();

            // Get the sizeof keyword.
            this.GetToken(expressionProxy, TokenType.Sizeof, SymbolType.Sizeof);

            // The next symbol will be the opening parenthesis.
            BracketToken openParenthesis = (BracketToken)this.GetToken(expressionProxy, TokenType.OpenParenthesis, SymbolType.OpenParenthesis);

            // Get the inner expression representing the type.
            Expression typeTokenExpression = this.GetTypeTokenExpression(expressionProxy, unsafeCode, true);
            if (typeTokenExpression == null)
            {
                throw this.CreateSyntaxException();
            }

            // Get the closing parenthesis.
            BracketToken closeParenthesis = (BracketToken)this.GetToken(expressionProxy, TokenType.CloseParenthesis, SymbolType.CloseParenthesis);

            openParenthesis.MatchingBracket = closeParenthesis;
            closeParenthesis.MatchingBracket = openParenthesis;

            // Create and return the expression.
            var expression = new SizeofExpression(expressionProxy, typeTokenExpression);
            parentProxy.Children.Add(expression);

            return expression;
        }

        /// <summary>
        /// Reads a typeof expression from the code.
        /// </summary>
        /// <param name="parentProxy">Represents the parent codeUnit.</param>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <returns>Returns the expression.</returns>
        private TypeofExpression GetTypeofExpression(CodeUnitProxy parentProxy, bool unsafeCode)
        {
            Param.AssertNotNull(parentProxy, "parentProxy");
            Param.Ignore(unsafeCode);

            this.AdvanceToNextCodeSymbol(parentProxy);
            var expressionProxy = new CodeUnitProxy();

            // Get the typeof keyword.
            this.GetToken(expressionProxy, TokenType.Typeof, SymbolType.Typeof);

            // The next symbol will be the opening parenthesis.
            BracketToken openParenthesis = (BracketToken)this.GetToken(expressionProxy, TokenType.OpenParenthesis, SymbolType.OpenParenthesis);

            // Get the inner expression representing the type.
            LiteralExpression typeTokenExpression = this.GetTypeTokenExpression(expressionProxy, unsafeCode, true);
            if (typeTokenExpression == null)
            {
                throw this.CreateSyntaxException();
            }

            // Get the closing parenthesis.
            BracketToken closeParenthesis = (BracketToken)this.GetToken(expressionProxy, TokenType.CloseParenthesis, SymbolType.CloseParenthesis);

            openParenthesis.MatchingBracket = closeParenthesis;
            closeParenthesis.MatchingBracket = openParenthesis;

            // Create and return the expression.
            var expression = new TypeofExpression(expressionProxy, typeTokenExpression);
            parentProxy.Children.Add(expression);

            return expression;
        }

        /// <summary>
        /// Reads a default value expression from the code.
        /// </summary>
        /// <param name="parentProxy">Represents the parent codeUnit.</param>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <returns>Returns the expression.</returns>
        private DefaultValueExpression GetDefaultValueExpression(CodeUnitProxy parentProxy, bool unsafeCode)
        {
            Param.AssertNotNull(parentProxy, "parentProxy");
            Param.Ignore(unsafeCode);

            this.AdvanceToNextCodeSymbol(parentProxy);
            var expressionProxy = new CodeUnitProxy();

            // Get the default keyword.
            this.GetToken(expressionProxy, TokenType.DefaultValue, SymbolType.Default);

            // The next symbol will be the opening parenthesis.
            BracketToken openParenthesis = (BracketToken)this.GetToken(expressionProxy, TokenType.OpenParenthesis, SymbolType.OpenParenthesis);

            // Get the inner expression.
            LiteralExpression typeTokenExpression = this.GetTypeTokenExpression(expressionProxy, unsafeCode, true);
            if (typeTokenExpression == null)
            {
                throw this.CreateSyntaxException();
            }

            // Get the closing parenthesis.
            BracketToken closeParenthesis = (BracketToken)this.GetToken(expressionProxy, TokenType.CloseParenthesis, SymbolType.CloseParenthesis);

            openParenthesis.MatchingBracket = closeParenthesis;
            closeParenthesis.MatchingBracket = openParenthesis;

            // Create and return the expression.
            var expression = new DefaultValueExpression(expressionProxy, typeTokenExpression);
            parentProxy.Children.Add(expression);

            return expression;
        }

        /// <summary>
        /// Reads an anonymous method from the code.
        /// </summary>
        /// <param name="parentProxy">Represents the parent codeUnit.</param>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <returns>Returns the expression.</returns>
        private AnonymousMethodExpression GetAnonymousMethodExpression(CodeUnitProxy parentProxy, bool unsafeCode)
        {
            Param.AssertNotNull(parentProxy, "parentProxy");
            Param.Ignore(unsafeCode);

            this.AdvanceToNextCodeSymbol(parentProxy);
            var expressionProxy = new CodeUnitProxy();

            // Get the delegate keyword.
            this.GetToken(expressionProxy, TokenType.Delegate, SymbolType.Delegate);

            // Check whether the next symbol is an opening parenthesis.
            Symbol symbol = this.PeekNextSymbol();

            if (symbol.SymbolType == SymbolType.OpenParenthesis)
            {
                this.GetAnonymousMethodParameterList(expressionProxy, unsafeCode);
            }

            // Create the anonymous method object now.
            var anonymousMethodExpression = new AnonymousMethodExpression(expressionProxy);

            // The next symbol must be an opening curly bracket.
            BracketToken openingBracket = (BracketToken)this.GetToken(expressionProxy, TokenType.OpenCurlyBracket, SymbolType.OpenCurlyBracket);

            // Read the child statements.
            BracketToken closingBracket = this.ParseStatementScope(expressionProxy, unsafeCode);
            
            if (closingBracket == null)
            {
                // If we failed to get a closing bracket back, then there is a syntax
                // error in the document since there is an opening bracket with no matching
                // closing bracket.
                throw this.CreateSyntaxException();
            }

            openingBracket.MatchingBracket = closingBracket;
            closingBracket.MatchingBracket = openingBracket;

            // Return the expression.
            parentProxy.Children.Add(anonymousMethodExpression);
            return anonymousMethodExpression;
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
        /// <param name="parentProxy">Represents the parent codeUnit.</param>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <returns>Returns the expression.</returns>
        private LambdaExpression GetLambdaExpression(CodeUnitProxy parentProxy, bool unsafeCode)
        {
            Param.AssertNotNull(parentProxy, "parentProxy");
            Param.Ignore(unsafeCode);

            this.AdvanceToNextCodeSymbol(parentProxy);

            // Create an empty lambda expression.
            var expressionProxy = new CodeUnitProxy();
            var lambdaExpression = new LambdaExpression(expressionProxy);

            // Check whether the next symbol is an opening parenthesis.
            Symbol symbol = this.PeekNextSymbol();

            if (symbol.SymbolType == SymbolType.OpenParenthesis)
            {
                this.GetAnonymousMethodParameterList(expressionProxy, unsafeCode);
            }
            else
            {
                // Since the statement did not begin with an opening parenthesis,
                // it must begin with a single unknown symbol.
                if (symbol.SymbolType != SymbolType.Other)
                {
                    throw new SyntaxException(this.document.SourceCode, symbol.LineNumber);
                }

                var parameterProxy = new CodeUnitProxy();
                this.GetToken(parameterProxy, TokenType.Literal, SymbolType.Other);

                var parameter = new Parameter(parameterProxy);

                expressionProxy.Children.Add(parameter);
            }

            // Get the lambda operator.
            this.GetOperatorSymbolToken(expressionProxy, OperatorType.Lambda);

            // Get the body of the expression. This can either be an expression or a statement.
            // If it starts with an opening curly bracket, it's a statement, otherwise it's an expression.
            symbol = this.PeekNextSymbol();

            if (symbol.SymbolType == SymbolType.OpenCurlyBracket)
            {
                lambdaExpression.AnonymousFunctionBody = this.GetNextStatement(expressionProxy, unsafeCode);
            }
            else
            {
                lambdaExpression.AnonymousFunctionBody = this.GetNextExpression(expressionProxy, ExpressionPrecedence.None, unsafeCode);
            }

            // Return the expression.
            parentProxy.Children.Add(lambdaExpression);
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

                // The next codeUnit must either be a type or an identifier.
                int endIndex = -1;
                if (this.HasTypeSignature(index, unsafeCode, out endIndex))
                {
                    // Advance past this.
                    index = this.GetNextCodeSymbolIndex(endIndex + 1);

                    // The next symbol must either be the 'in' keyword or the identifier if the previous codeUnit is a type.
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
        /// <param name="parentProxy">Represents the parent codeUnit.</param>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides 
        /// in an unsafe code block.</param>
        /// <returns>Returns the query expression.</returns>
        private QueryExpression GetQueryExpression(CodeUnitProxy parentProxy, bool unsafeCode)
        {
            Param.AssertNotNull(parentProxy, "parentProxy");
            Param.Ignore(unsafeCode);

            this.AdvanceToNextCodeSymbol(parentProxy);
            var expressionProxy = new CodeUnitProxy();

            #if DEBUG
            // Ensure that the expression starts with the keyword 'from'.
            Symbol symbol = this.PeekNextSymbol();

            Debug.Assert(
                symbol != null &&
                symbol.SymbolType == SymbolType.Other &&
                string.CompareOrdinal(symbol.Text, "from") == 0, 
                "Expected a from keyword");
            #endif

            // Extract the clauses.
            QueryClause[] clauses = this.GetQueryExpressionClauses(expressionProxy, unsafeCode);
            if (clauses.Length == 0)
            {
                throw this.CreateSyntaxException();
            }

            // Create and return the expression.
            var queryExpression = new QueryExpression(expressionProxy);
            parentProxy.Children.Add(queryExpression);

            return queryExpression;
        }

        /// <summary>
        /// Gets the collection of query clauses.
        /// </summary>
        /// <param name="parentProxy">Represents the parent codeUnit.</param>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides 
        /// in an unsafe code block.</param>
        /// <returns>Returns the query clauses.</returns>
        private QueryClause[] GetQueryExpressionClauses(CodeUnitProxy parentProxy, bool unsafeCode)
        {
            Param.AssertNotNull(parentProxy, "parentProxy");
            Param.Ignore(unsafeCode);

            List<QueryClause> clauses = new List<QueryClause>();
            
            while (true)
            {
                // Get the rest of the clauses.
                Symbol symbol = this.PeekNextSymbol();
                if (symbol.SymbolType != SymbolType.Other)
                {
                    break;
                }

                QueryClause clause = null;

                switch (symbol.Text)
                {
                    case "from":
                        QueryFromClause fromClause = this.GetQueryFromClause(parentProxy, unsafeCode);
                        clause = fromClause;
                        break;

                    case "let":
                        QueryLetClause letClause = this.GetQueryLetClause(parentProxy, unsafeCode);
                        clause = letClause;
                        break;

                    case "where":
                        clause = this.GetQueryWhereClause(parentProxy, unsafeCode);
                        break;

                    case "join":
                        clause = this.GetQueryJoinClause(parentProxy, unsafeCode);
                        break;

                    case "orderby":
                        clause = this.GetQueryOrderByClause(parentProxy, unsafeCode);
                        break;

                    case "select":
                        clause = this.GetQuerySelectClause(parentProxy, unsafeCode);
                        break;

                    case "group":
                        clause = this.GetQueryGroupClause(parentProxy, unsafeCode);
                        break;

                    case "into":
                        clause = this.GetQueryContinuationClause(parentProxy, unsafeCode);
                        break;

                    default:
                        break;
                }

                if (clause == null)
                {
                    break;
                }

                clauses.Add(clause);
            }

            return clauses.ToArray();
        }

        /// <summary>
        /// Gets a query continuation clause.
        /// </summary>
        /// <param name="parentProxy">Represents the parent codeUnit.</param>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides 
        /// in an unsafe code block.</param>
        /// <returns>Returns the query continuation clause.</returns>
        private QueryContinuationClause GetQueryContinuationClause(CodeUnitProxy parentProxy, bool unsafeCode)
        {
            Param.AssertNotNull(parentProxy, "parentProxy");
            Param.Ignore(unsafeCode);

            this.AdvanceToNextCodeSymbol(parentProxy);
            var queryClauseProxy = new CodeUnitProxy();

            #if DEBUG
            Symbol symbol = this.PeekNextSymbol();
            Debug.Assert(symbol.SymbolType == SymbolType.Other && symbol.Text == "into", "Expected an into keyword");
            #endif

            // Get and add the 'into' symbol.
            this.GetToken(queryClauseProxy, TokenType.Into, SymbolType.Other);

            // Get the identifier.
            this.GetQueryVariable(queryClauseProxy, unsafeCode, true, true);

            // Extract the clauses.
            QueryClause[] clauses = this.GetQueryExpressionClauses(queryClauseProxy, unsafeCode);

            // Create and return the clause.
            var continuationClause = new QueryContinuationClause(queryClauseProxy, clauses);
            parentProxy.Children.Add(continuationClause);

            return continuationClause;
        }

        /// <summary>
        /// Gets a query from clause.
        /// </summary>
        /// <param name="parentProxy">Represents the parent codeUnit.</param>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides 
        /// in an unsafe code block.</param>
        /// <returns>Returns the query from clause.</returns>
        private QueryFromClause GetQueryFromClause(CodeUnitProxy parentProxy, bool unsafeCode)
        {
            Param.AssertNotNull(parentProxy, "parentProxy");
            Param.Ignore(unsafeCode);

            this.AdvanceToNextCodeSymbol(parentProxy);
            var queryClauseProxy = new CodeUnitProxy();

            #if DEBUG
            Symbol symbol = this.PeekNextSymbol();
            Debug.Assert(symbol.SymbolType == SymbolType.Other && symbol.Text == "from", "Expected a from keyword");
            #endif

            // Get and add the 'from' symbol.
            this.GetToken(queryClauseProxy, TokenType.From, SymbolType.Other);

            // Get the range variable.
            this.GetQueryVariable(queryClauseProxy, unsafeCode, true, false);

            // The next symbol must be the 'in' keyword.
            this.GetToken(queryClauseProxy, TokenType.In, SymbolType.In);

            // Now get the from clause expression.
            Expression fromClauseExpression = this.GetNextExpression(queryClauseProxy, ExpressionPrecedence.Query, unsafeCode);
            if (fromClauseExpression == null)
            {
                throw this.CreateSyntaxException();
            }

            // Create and return the clause.
            var fromClause = new QueryFromClause(queryClauseProxy, fromClauseExpression);

            parentProxy.Children.Add(fromClause);
            return fromClause;
        }

        /// <summary>
        /// Gets a query let clause.
        /// </summary>
        /// <param name="parentProxy">Represents the parent codeUnit.</param>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides 
        /// in an unsafe code block.</param>
        /// <returns>Returns the query let clause.</returns>
        private QueryLetClause GetQueryLetClause(CodeUnitProxy parentProxy, bool unsafeCode)
        {
            Param.AssertNotNull(parentProxy, "parentProxy");
            Param.Ignore(unsafeCode);

            this.AdvanceToNextCodeSymbol(parentProxy);
            var queryClauseProxy = new CodeUnitProxy();

            #if DEBUG
            Symbol symbol = this.PeekNextSymbol();
            Debug.Assert(symbol.SymbolType == SymbolType.Other && symbol.Text == "let", "Expected a let keyword");
            #endif

            // Get and add the 'let' symbol.
            this.GetToken(queryClauseProxy, TokenType.Let, SymbolType.Other);

            // Get the identifier.
            this.GetQueryVariable(queryClauseProxy, unsafeCode, true, true);

            // The next symbol must be the = sign.
            this.GetOperatorSymbolToken(queryClauseProxy, OperatorType.Equals);

            // Now get the let clause expression.
            Expression letClauseExpression = this.GetNextExpression(queryClauseProxy, ExpressionPrecedence.Query, unsafeCode);
            if (letClauseExpression == null)
            {
                throw this.CreateSyntaxException();
            }

            // Create and return the clause.
            var letClause = new QueryLetClause(queryClauseProxy, letClauseExpression);

            parentProxy.Children.Add(letClause);
            return letClause;
        }

        /// <summary>
        /// Gets a query where clause.
        /// </summary>
        /// <param name="parentProxy">Represents the parent codeUnit.</param>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides 
        /// in an unsafe code block.</param>
        /// <returns>Returns the query where clause.</returns>
        private QueryWhereClause GetQueryWhereClause(CodeUnitProxy parentProxy, bool unsafeCode)
        {
            Param.AssertNotNull(parentProxy, "parentProxy");
            Param.Ignore(unsafeCode);

            this.AdvanceToNextCodeSymbol(parentProxy);
            var queryClauseProxy = new CodeUnitProxy();

            #if DEBUG
            Symbol symbol = this.PeekNextSymbol();
            Debug.Assert(symbol.SymbolType == SymbolType.Other && symbol.Text == "where", "Expected a where keyword");
            #endif

            // Get and add the 'where' symbol.
            this.GetToken(queryClauseProxy, TokenType.Where, SymbolType.Other);

            // Get the where expression.
            Expression whereClauseExpression = this.GetNextExpression(queryClauseProxy, ExpressionPrecedence.Query, unsafeCode);
            if (whereClauseExpression == null)
            {
                throw this.CreateSyntaxException();
            }

            // Create and return the clause.
            var whereClause = new QueryWhereClause(queryClauseProxy, whereClauseExpression);
            parentProxy.Children.Add(whereClause);

            return whereClause;
        }

        /// <summary>
        /// Gets a query join clause.
        /// </summary>
        /// <param name="parentProxy">Represents the parent codeUnit.</param>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides 
        /// in an unsafe code block.</param>
        /// <returns>Returns the query from clause.</returns>
        private QueryJoinClause GetQueryJoinClause(CodeUnitProxy parentProxy, bool unsafeCode)
        {
            Param.AssertNotNull(parentProxy, "parentProxy");
            Param.Ignore(unsafeCode);

            this.AdvanceToNextCodeSymbol(parentProxy);
            var queryClauseProxy = new CodeUnitProxy();

            #if DEBUG
            Symbol symbol = this.PeekNextSymbol();
            Debug.Assert(symbol.SymbolType == SymbolType.Other && symbol.Text == "join", "Expected a join keyword");
            #endif

            // Get and add the 'from' symbol.
            this.GetToken(queryClauseProxy, TokenType.Join, SymbolType.Other);

            // Get the variable.
            this.GetQueryVariable(queryClauseProxy, unsafeCode, true, false);

            // The next symbol must be the 'in' keyword.
            this.GetToken(queryClauseProxy, TokenType.In, SymbolType.In);

            // Now get the in expression.
            Expression inExpression = this.GetNextExpression(queryClauseProxy, ExpressionPrecedence.Query, unsafeCode);
            if (inExpression == null)
            {
                throw this.CreateSyntaxException();
            }

            // The next symbol must be the 'on' keyword.
            Token token = this.GetToken(queryClauseProxy, TokenType.On, SymbolType.Other);
            if (token.Text != "on")
            {
                throw this.CreateSyntaxException();
            }

            // Now get the on expression.
            Expression onKeyExpression = this.GetNextExpression(queryClauseProxy, ExpressionPrecedence.Query, unsafeCode);
            if (onKeyExpression == null)
            {
                throw this.CreateSyntaxException();
            }

            // The next symbol must be the 'equals' keyword.
            token = this.GetToken(queryClauseProxy, TokenType.Equals, SymbolType.Other);
            if (token.Text != "equals")
            {
                throw this.CreateSyntaxException();
            }

            // Now get the equals expression.
            Expression equalsKeyExpression = this.GetNextExpression(queryClauseProxy, ExpressionPrecedence.Query, unsafeCode);
            if (equalsKeyExpression == null)
            {
                throw this.CreateSyntaxException();
            }

            // Get the optional 'into' variable if it exists.
            Symbol nextSymbol = this.PeekNextSymbol();
            if (nextSymbol.SymbolType == SymbolType.Other && nextSymbol.Text == "into")
            {
                this.GetToken(queryClauseProxy, TokenType.Into, SymbolType.Other);
                this.GetQueryVariable(queryClauseProxy, unsafeCode, true, true);
            }

            // Create and return the clause.
            var joinClause = new QueryJoinClause(
                queryClauseProxy,
                inExpression,
                onKeyExpression,
                equalsKeyExpression);

            parentProxy.Children.Add(joinClause);
            return joinClause;
        }

        /// <summary>
        /// Gets a query order-by clause.
        /// </summary>
        /// <param name="parentProxy">Represents the parent codeUnit.</param>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides 
        /// in an unsafe code block.</param>
        /// <returns>Returns the query order-by clause.</returns>
        private QueryOrderByClause GetQueryOrderByClause(CodeUnitProxy parentProxy, bool unsafeCode)
        {
            Param.AssertNotNull(parentProxy, "parentProxy");
            Param.Ignore(unsafeCode);

            this.AdvanceToNextCodeSymbol(parentProxy);
            var queryClauseProxy = new CodeUnitProxy();

            Symbol symbol = this.PeekNextSymbol();
            Debug.Assert(symbol.SymbolType == SymbolType.Other && symbol.Text == "orderby", "Expected an orderby keyword");

            // Get and add the 'orderby' symbol.
            this.GetToken(queryClauseProxy, TokenType.OrderBy, SymbolType.Other);

            // Get each of the orderings in the clause.
            var orderings = new List<QueryOrderByOrdering>();

            while (true)
            {
                var ordering = new QueryOrderByOrdering();

                // Get the ordering expression.
                ordering.Expression = this.GetNextExpression(queryClauseProxy, ExpressionPrecedence.Query, unsafeCode);
                if (ordering.Expression == null)
                {
                    throw this.CreateSyntaxException();
                }

                // Get the order direction if it exists.
                symbol = this.PeekNextSymbol();

                ordering.Direction = QueryOrderByDirection.Undefined;

                if (symbol.Text == "ascending")
                {
                    ordering.Direction = QueryOrderByDirection.Ascending;
                    this.GetToken(queryClauseProxy, TokenType.Ascending, SymbolType.Other);
                }
                else if (symbol.Text == "descending")
                {
                    ordering.Direction = QueryOrderByDirection.Descending;
                    this.GetToken(queryClauseProxy, TokenType.Descending, SymbolType.Other);
                }

                // Add the ordering to the list.
                orderings.Add(ordering);

                // If the next symbol is a comma, then we should continue and get the next ordering expression.
                symbol = this.PeekNextSymbol();

                if (symbol.SymbolType == SymbolType.Comma)
                {
                    this.GetToken(queryClauseProxy, TokenType.Comma, SymbolType.Comma);
                }
                else
                {
                    // This was the last ordering expression.
                    break;
                }
            }

            // Create and return the clause.
            var orderByClause = new QueryOrderByClause(queryClauseProxy, orderings);

            parentProxy.Children.Add(orderByClause);
            return orderByClause;
        }

        /// <summary>
        /// Gets a query select clause.
        /// </summary>
        /// <param name="parentProxy">Represents the parent codeUnit.</param>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides 
        /// in an unsafe code block.</param>
        /// <returns>Returns the query select clause.</returns>
        private QuerySelectClause GetQuerySelectClause(CodeUnitProxy parentProxy, bool unsafeCode)
        {
            Param.AssertNotNull(parentProxy, "parentProxy");
            Param.Ignore(unsafeCode);

            this.AdvanceToNextCodeSymbol(parentProxy);
            var queryClauseProxy = new CodeUnitProxy();

            #if DEBUG
            Symbol symbol = this.PeekNextSymbol();
            Debug.Assert(symbol.SymbolType == SymbolType.Other && symbol.Text == "select", "Expected a select keyword");
            #endif

            // Get and add the 'select' symbol.
            this.GetToken(queryClauseProxy, TokenType.Select, SymbolType.Other);

            // Get the select expression.
            Expression selectClauseExpression = this.GetNextExpression(queryClauseProxy, ExpressionPrecedence.Query, unsafeCode);
            if (selectClauseExpression == null)
            {
                throw this.CreateSyntaxException();
            }

            // Create and return the clause.
            var selectClause = new QuerySelectClause(queryClauseProxy, selectClauseExpression);

            parentProxy.Children.Add(selectClause);
            return selectClause;
        }

        /// <summary>
        /// Gets a query group clause.
        /// </summary>
        /// <param name="parentProxy">Represents the parent codeUnit.</param>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides 
        /// in an unsafe code block.</param>
        /// <returns>Returns the query group clause.</returns>
        private QueryGroupClause GetQueryGroupClause(CodeUnitProxy parentProxy, bool unsafeCode)
        {
            Param.AssertNotNull(parentProxy, "parentProxy");
            Param.Ignore(unsafeCode);

            this.AdvanceToNextCodeSymbol(parentProxy);
            var queryClauseProxy = new CodeUnitProxy();

            Symbol symbol = this.PeekNextSymbol();
            Debug.Assert(symbol.SymbolType == SymbolType.Other && symbol.Text == "group", "Expected a group keyword.");

            // Get and add the 'group' symbol.
            this.GetToken(queryClauseProxy, TokenType.Group, SymbolType.Other);

            // Get the group expression.
            Expression groupExpression = this.GetNextExpression(queryClauseProxy, ExpressionPrecedence.Query, unsafeCode);
            if (groupExpression == null)
            {
                throw this.CreateSyntaxException();
            }

            // The next symbol must be the 'by' keyword.
            symbol = this.PeekNextSymbol();
            if (symbol.Text != "by")
            {
                throw this.CreateSyntaxException();
            }

            this.GetToken(queryClauseProxy, TokenType.By, SymbolType.Other);

            // Now get the by expression.
            Expression groupByExpression = this.GetNextExpression(queryClauseProxy, ExpressionPrecedence.Query, unsafeCode);
            if (groupByExpression == null)
            {
                throw this.CreateSyntaxException();
            }

            // Create and return the clause.
            var groupClause = new QueryGroupClause(queryClauseProxy, groupExpression, groupByExpression);

            parentProxy.Children.Add(groupClause);
            return groupClause;
        }

        /// <summary>
        /// Gets the next query clause variable.
        /// </summary>
        /// <param name="parentProxy">Represents the parent of the variable.</param>
        /// <param name="unsafeCode">Indicates whether the code is within an unsafe block.</param>
        /// <param name="allowTypelessVariable">Indicates whether to allow a variable with no type defined.</param>
        /// <param name="onlyTypelessVariable">Indicates whether to only get a typeless variable.</param>
        private void GetQueryVariable(CodeUnitProxy parentProxy, bool unsafeCode, bool allowTypelessVariable, bool onlyTypelessVariable)
        {
            Param.AssertNotNull(parentProxy, "parentProxy");
            Param.Ignore(unsafeCode);
            Param.Ignore(allowTypelessVariable);
            Param.Ignore(onlyTypelessVariable);

            this.AdvanceToNextCodeSymbol(parentProxy);

            // Get the type token representing either the type or the identifier.
            TypeToken type = this.GetTypeToken(null, unsafeCode, true, false);
            if (type == null)
            {
                throw this.CreateSyntaxException();
            }

            if (onlyTypelessVariable)
            {
                // The token is not a type, just an identifier. Detach the child token and ignore the TypeToken.
                Debug.Assert(type.Children.Count == 1, "This operation only makes sense when the type token contains a single child.");
                
                Token token = type.FindFirstChild<Token>();
                Debug.Assert(token != null, "The child token of the type token should be a token.");

                token.Detach();
                parentProxy.Children.Add(token);
            }
            else
            {
                this.AdvanceToNextCodeSymbol(parentProxy);

                // Look ahead to the next symbol to see what it is.
                Symbol symbol = this.symbols.Peek(1);
                if (symbol == null || symbol.SymbolType != SymbolType.Other)
                {
                    // This variable has no type, only an identifier.
                    if (!allowTypelessVariable)
                    {
                        throw this.CreateSyntaxException();
                    }

                    // The token is not a type, just an identifier.
                    Debug.Assert(type.Children.Count == 1, "This operation only makes sense when the type token contains a single child.");

                    Token token = type.FindFirstChild<Token>();
                    Debug.Assert(token != null, "The child token of the type token should be a token.");

                    token.Detach();
                    parentProxy.Children.Add(token);
                }
                else
                {
                    // There is a type so add the type token.
                    parentProxy.Children.Add(type);

                    // Create and add the identifier token.
                    var identifier = new LiteralToken(symbol.Text, symbol.Location, this.symbols.Generated);
                    parentProxy.Children.Add(identifier);

                    this.symbols.Advance();
                }
            }
        }

        /// <summary>
        /// Reads an unsafe type expression.
        /// </summary>
        /// <param name="expressionProxy">Proxy object for the expression being created.</param>
        /// <param name="type">The type expression.</param>
        /// <param name="previousPrecedence">The precedence of the previous expression.</param>
        /// <returns>Returns the expression.</returns>
        private UnsafeAccessExpression GetUnsafeTypeExpression(CodeUnitProxy expressionProxy, Expression type, ExpressionPrecedence previousPrecedence)
        {
            Param.AssertNotNull(expressionProxy, "expressionProxy");
            Param.Ignore(type);
            Param.AssertNotNull(previousPrecedence, "previousPrecedence");

            UnsafeAccessExpression expression = null;

            if (CheckPrecedence(previousPrecedence, ExpressionPrecedence.Unary))
            {
                // Get the operator symbol.
                Symbol symbol = this.PeekNextSymbol();

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
                this.GetOperatorSymbolToken(expressionProxy, operatorType);

                // Create and return the expression.
                expression = new UnsafeAccessExpression(expressionProxy, unsafeOperatorType, type);
            }

            return expression;
        }

        /// <summary>
        /// Reads an unsafe access expression.
        /// </summary>
        /// <param name="parentProxy">Represents the parent codeUnit.</param>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <returns>Returns the expression.</returns>
        private UnsafeAccessExpression GetUnsafeAccessExpression(CodeUnitProxy parentProxy, bool unsafeCode)
        {
            Param.AssertNotNull(parentProxy, "parentProxy");
            Param.Assert(unsafeCode == true, "unsafeCode", "Unsafe access must reside in an unsafe code block.");

            this.AdvanceToNextCodeSymbol(parentProxy);
            var expressionProxy = new CodeUnitProxy();

            // Get the operator symbol.
            Symbol symbol = this.PeekNextSymbol();

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
            this.GetOperatorSymbolToken(expressionProxy, operatorType);

            // Get the expression being accessed.
            Expression innerExpression = this.GetNextExpression(expressionProxy, ExpressionPrecedence.Unary, unsafeCode);
            if (innerExpression == null || innerExpression.Children.Count == 0)
            {
                throw new SyntaxException(this.document.SourceCode, symbol.LineNumber);
            }
            
            // Create and return the expression.
            var expression = new UnsafeAccessExpression(expressionProxy, unsafeOperatorType, innerExpression);
            parentProxy.Children.Add(expression);

            return expression;
        }

        /// <summary>
        /// Checks whether the next expression can be a unary expression.
        /// </summary>
        /// <returns>Returns true if the next expression can be a unary expression.</returns>
        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "The method is not complex.")]
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
        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "May be simplified later.")]
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
                                                symbolType == SymbolType.True ||
                                                symbolType == SymbolType.False ||
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
        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "May be simplified later.")]
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
                                ////allowNullableType = false;
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
        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "May be simplified later.")]
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

        #endregion Private Methods
    }
}
