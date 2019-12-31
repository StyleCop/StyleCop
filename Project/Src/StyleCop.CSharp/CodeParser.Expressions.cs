// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CodeParser.Expressions.cs" company="https://github.com/StyleCop">
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
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// The code parser.
    /// </summary>
    /// <content>
    /// Contains code for parsing expressions within a C# code file.
    /// </content>
    internal partial class CodeParser
    {
        #region Enums

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
            /// An assignment expression.
            /// </summary>
            Assignment = 14,

            /// <summary>
            /// A conditional expression.
            /// </summary>
            Conditional = 15,

            /// <summary>
            /// A query expression.
            /// </summary>
            Query = 16,

            /// <summary>
            /// No precedence.
            /// </summary>
            None = 17
        }

        #endregion

        #region Methods

        /// <summary>
        /// Compares the precedence of the previous expression with the precedence of the next expression,
        /// to determine which has the higher precedence value.
        /// </summary>
        /// <param name="previousPrecedence">
        /// The previous expression's precedence.
        /// </param>
        /// <param name="nextPrecedence">
        /// The next expression's precedence.
        /// </param>
        /// <returns>
        /// Returns true if the next expression has greater precedence than the next expression.
        /// </returns>
        private static bool CheckPrecedence(ExpressionPrecedence previousPrecedence, ExpressionPrecedence nextPrecedence)
        {
            Param.AssertNotNull(previousPrecedence, "previousPrecedence");
            Param.AssertNotNull(nextPrecedence, "nextPrecedence");

            // Two expressions with no precendence can be chained back to back, and conditional expressions
            // are allowed to be embedded within other conditional expressions.
            if ((previousPrecedence == ExpressionPrecedence.None && nextPrecedence == ExpressionPrecedence.None)
                || (previousPrecedence == ExpressionPrecedence.Conditional && nextPrecedence == ExpressionPrecedence.Conditional))
            {
                return true;
            }

            return (int)previousPrecedence > (int)nextPrecedence;
        }

        /// <summary>
        /// Gets the precedence of the given operator type.
        /// </summary>
        /// <param name="type">
        /// The operator type.
        /// </param>
        /// <returns>
        /// Returns the precedence of the type.
        /// </returns>
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
                case OperatorType.NullConditional:
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
        /// Moves to the closing bracket of the current generic symbol.
        /// </summary>
        /// <param name="startIndex">
        /// The index just past the opening bracket of the generic.
        /// </param>
        /// <returns>
        /// Returns the index of the closing bracket in the generic, or -1 if this
        /// is not a generic.
        /// </returns>
        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "May be simplified later.")]
        private int AdvanceToClosingGenericSymbol(int startIndex)
        {
            Param.AssertGreaterThanOrEqualToZero(startIndex, "startIndex");

            bool other = false;
            bool comma = false;
            bool memberAccess = false;
            bool openSquareBracket = false;
            bool insideTupleDeclaration = false;
            int tupleDeclarationCount = 0;

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
                    // Consecutive unknown are allowed inside tuple type declaration.
                    if ((other || openSquareBracket) && !insideTupleDeclaration)
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
                else if (symbol.SymbolType == SymbolType.OpenParenthesis)
                {
                    insideTupleDeclaration = true;
                    tupleDeclarationCount++;
                }
                else if (symbol.SymbolType == SymbolType.CloseParenthesis)
                {
                    tupleDeclarationCount--;
                    insideTupleDeclaration = tupleDeclarationCount == 0;
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
        /// <param name="expression">
        /// The expression to convert.
        /// </param>
        /// <returns>
        /// Returns the converted expression.
        /// </returns>
        private LiteralExpression ConvertTypeExpression(Expression expression)
        {
            Param.AssertNotNull(expression, "expression");

            // Get the first and last token in the expression.
            Node<CsToken> firstTokenNode = expression.Tokens.First;
            Node<CsToken> lastTokenNode = expression.Tokens.Last;

            Reference<ICodePart> typeTokenReference = new Reference<ICodePart>();
            Reference<ICodePart> expressionReference = new Reference<ICodePart>();

            // Create a new token list containing these tokens.
            List<CsToken> tokenList = new List<CsToken>();
            foreach (CsToken token in expression.Tokens)
            {
                tokenList.Add(token);
                token.ParentRef = typeTokenReference;
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
            TypeToken typeToken = new TypeToken(childTokens, CsToken.JoinLocations(firstTokenNode, lastTokenNode), expressionReference, firstTokenNode.Value.Generated);
            typeTokenReference.Target = typeToken;

            // Insert the new token.
            Node<CsToken> typeTokenNode = this.tokens.Replace(firstTokenNode, typeToken);

            // Create the literal expression.
            LiteralExpression literalExpression = new LiteralExpression(new CsTokenList(this.tokens, firstTokenNode, firstTokenNode), typeTokenNode);

            expressionReference.Target = literalExpression;

            return literalExpression;
        }

        /// <summary>
        /// Reads an anonymous method from the code.
        /// </summary>
        /// <param name="parentReference">
        /// The parent code unit.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code being parsed resides in an unsafe code block.
        /// </param>
        /// <returns>
        /// Returns the expression.
        /// </returns>
        private AnonymousMethodExpression GetAnonymousMethodExpression(Reference<ICodePart> parentReference, bool unsafeCode)
        {
            Param.AssertNotNull(parentReference, "parentReference");
            Param.Ignore(unsafeCode);

            Reference<ICodePart> expressionReference = new Reference<ICodePart>();

            // Create the anonymous method object now.
            AnonymousMethodExpression anonymousMethod = new AnonymousMethodExpression();

            Node<CsToken> previousTokenNode = this.tokens.Last;

            // First symbol could be 'async' for asynchronous delegates.
            Symbol nextSymbol = this.symbols.Peek(1);
            if (nextSymbol.SymbolType == SymbolType.Other && nextSymbol.Text == "async")
            {
                this.tokens.Add(this.GetToken(CsTokenType.Async, SymbolType.Other, expressionReference));
                anonymousMethod.Async = true;
            }

            // Get the delegate keyword.
            this.tokens.Add(this.GetToken(CsTokenType.Delegate, SymbolType.Delegate, parentReference, expressionReference));

            // Check whether the next symbol is an opening parenthesis.
            Symbol symbol = this.GetNextSymbol(expressionReference);

            ICollection<Parameter> parameters = null;
            if (symbol.SymbolType == SymbolType.OpenParenthesis)
            {
                parameters = this.ParseAnonymousMethodParameterList(expressionReference, unsafeCode);
            }

            // The next symbol must be an opening curly bracket.
            Bracket openingBracket = this.GetBracketToken(CsTokenType.OpenCurlyBracket, SymbolType.OpenCurlyBracket, expressionReference);
            Node<CsToken> openingBracketNode = this.tokens.InsertLast(openingBracket);

            // Read the child statements.
            Node<CsToken> closingBracketNode = this.ParseStatementScope(anonymousMethod, expressionReference, unsafeCode);

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
            Node<CsToken> firstNode = previousTokenNode == null ? this.tokens.First : previousTokenNode.Next;

            anonymousMethod.Tokens = new CsTokenList(this.tokens, firstNode, this.tokens.Last);

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
                    anonymousMethod.Variables.Add(
                        new Variable(parameter.Type, parameter.Name, VariableModifiers.None, parameter.Location, expressionReference, parameter.Generated));
                }
            }

            // Return the expression.
            expressionReference.Target = anonymousMethod;
            return anonymousMethod;
        }

        /// <summary>
        /// Reads an anonymous type initializer expression from the code.
        /// </summary>
        /// <param name="parentReference">
        /// The parent code unit.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code being parsed resides in an unsafe code block.
        /// </param>
        /// <returns>
        /// Returns the expression.
        /// </returns>
        private CollectionInitializerExpression GetAnonymousTypeInitializerExpression(Reference<ICodePart> parentReference, bool unsafeCode)
        {
            Param.AssertNotNull(parentReference, "parentReference");
            Param.Ignore(unsafeCode);

            // If the next symbol is an opening curly bracket, then there is an object
            // or collection initializer attached which must also be parsed.
            this.GetNextSymbol(SymbolType.OpenCurlyBracket, parentReference);

            Reference<ICodePart> expressionReference = new Reference<ICodePart>();

            CollectionInitializerExpression initializer = this.GetCollectionInitializerExpression(unsafeCode);
            expressionReference.Target = initializer;

            if (initializer == null || initializer.Tokens.First == null)
            {
                throw this.CreateSyntaxException();
            }

            // Ensure that all of the initializer expressions are either simple literals,
            // member access expressions, or assignment expressions, since these are the
            // only types of expressions allowed within an anonymous type definition.
            foreach (Expression initializerExpression in initializer.ChildExpressions)
            {
                if (initializerExpression.ExpressionType != ExpressionType.Literal && initializerExpression.ExpressionType != ExpressionType.MemberAccess
                    && initializerExpression.ExpressionType != ExpressionType.Assignment)
                {
                    throw this.CreateSyntaxException();
                }
            }

            return initializer;
        }

        /// <summary>
        /// Reads the argument list for a method invocation expression.
        /// </summary>
        /// <param name="closingSymbol">
        /// The symbol that closes the argument list.
        /// </param>
        /// <param name="parentReference">
        /// The parent code part.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code being parsed resides in an unsafe code block.
        /// </param>
        /// <returns>
        /// Returns the list of arguments in the method invocation.
        /// </returns>
        private IList<Argument> GetArgumentList(SymbolType closingSymbol, Reference<ICodePart> parentReference, bool unsafeCode)
        {
            Param.AssertNotNull(closingSymbol, "closingSymbol");
            Param.AssertNotNull(parentReference, "parentReference");
            Param.Ignore(unsafeCode);

            List<Argument> arguments = new List<Argument>();

            while (true)
            {
                // Save the current last token.
                Node<CsToken> previousTokenNode = this.tokens.Last;

                // Move to the next code token.
                Symbol firstSymbol = this.GetNextSymbol(parentReference);

                if (firstSymbol.SymbolType == closingSymbol)
                {
                    break;
                }

                if (firstSymbol.SymbolType != SymbolType.Comma)
                {
                    arguments.Add(this.GetNextArgument(parentReference, unsafeCode, firstSymbol, false, previousTokenNode));
                }

                // If the next symbol is a comma, add the comma and proceed.
                Symbol nextSymbol = this.PeekNextSymbol(SkipSymbols.All, true);

                if (nextSymbol?.SymbolType == SymbolType.Comma)
                {
                    this.tokens.Add(this.GetToken(CsTokenType.Comma, SymbolType.Comma, parentReference));
                }
            }

            // Trim the list down to a small array before returning it.
            return arguments.ToArray();
        }

        /// <summary>
        /// Reads the next Argument expression.
        /// </summary>
        /// <param name="parentReference">
        /// The parent code part.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code being parsed resides in an unsafe code block.
        /// </param>
        /// <param name="firstSymbol">
        /// The first symbol of the Argument.
        /// </param>
        /// <param name="firstSymbolRead">
        /// The first symbol was already read.
        /// </param>
        /// <param name="previousTokenNode">
        /// A token node, that was read prior to making this function call.
        /// </param>
        /// <returns>
        /// Returns the next argument in the expression.
        /// </returns>
        private Argument GetNextArgument(
            Reference<ICodePart> parentReference, 
            bool unsafeCode, 
            Symbol firstSymbol, 
            bool firstSymbolRead,
            Node<CsToken> previousTokenNode)
        {
            Param.AssertNotNull(parentReference, nameof(parentReference));
            Param.Ignore(unsafeCode);
            Param.AssertNotNull(firstSymbol, nameof(firstSymbol));
            Param.AssertNotNull(previousTokenNode, nameof(previousTokenNode));

            Reference<ICodePart> argumentReference = new Reference<ICodePart>();
            ParameterModifiers modifiers = ParameterModifiers.None;
            CsToken argumentName = null;
            Symbol symbol = firstSymbol;
            bool isInlineVariableDeclaration = false;

            if (firstSymbol.SymbolType == SymbolType.Other)
            {
                // Gather the parameter name label if it exists.
                // Look at the next symbol after the label.
                int foundPosition;
                symbol = this.PeekNextSymbolFrom(
                    firstSymbolRead ? 0 : 1, 
                    SkipSymbols.All, 
                    false, 
                    out foundPosition);

                if (symbol.SymbolType == SymbolType.Colon)
                {
                    // This is an argument name label. Add the name label and the colon.
                    if (firstSymbolRead)
                    {
                        // Aready read the symbol, so it should be the last token.
                        argumentName = previousTokenNode.Value;
                    }
                    else
                    {
                        argumentName = this.GetToken(CsTokenType.Other, SymbolType.Other, argumentReference);                        
                        this.tokens.Add(argumentName);
                    }

                    // The next symbol must be the colon.
                    this.tokens.Add(this.GetToken(CsTokenType.LabelColon, SymbolType.Colon, argumentReference));

                    // Reset the symbol used for further processing.
                    symbol = this.PeekNextSymbol(SkipSymbols.All, false);
                }
                else
                {
                    symbol = firstSymbol;
                }
            }

            if (symbol.SymbolType == SymbolType.Ref)
            {
                this.tokens.Add(this.GetToken(CsTokenType.Ref, SymbolType.Ref, argumentReference));
                modifiers = ParameterModifiers.Ref;
            }
            else if (symbol.SymbolType == SymbolType.Out)
            {
                this.tokens.Add(this.GetToken(CsTokenType.Out, SymbolType.Out, argumentReference));
                modifiers = ParameterModifiers.Out;
                isInlineVariableDeclaration = this.IsInlineVariableDeclaration();
            }
            else if (symbol.SymbolType == SymbolType.Params)
            {
                this.tokens.Add(this.GetToken(CsTokenType.Params, SymbolType.Params, argumentReference));
                modifiers = ParameterModifiers.Params;
            }

            // The argument body expression must come next.
            Expression argumentExpression;
            if (isInlineVariableDeclaration)
            {
                Expression typeExpression = this.GetTypeTokenExpression(argumentReference, false, true);
                argumentExpression = this.GetSingleVariableDeclarationExpression(typeExpression, ExpressionPrecedence.None, unsafeCode);
            }
            else
            {
                argumentExpression = this.GetNextExpression(ExpressionPrecedence.None, argumentReference, unsafeCode);
            }

            // Create the collection of tokens that form the argument, and strip off whitesace from the beginning and end.
            CsTokenList argumentTokenList = new CsTokenList(this.tokens, previousTokenNode.Next, this.tokens.Last);
            argumentTokenList.Trim(CsTokenType.EndOfLine, CsTokenType.WhiteSpace);

            // Create the argument.
            Argument argument = new Argument(
                argumentName,
                modifiers,
                argumentExpression,
                CodeLocation.Join(firstSymbol.Location, argumentExpression.Location),
                parentReference,
                argumentTokenList,
                this.symbols.Generated);

            // Return the argument.
            argumentReference.Target = argument;
            return argument;
        }

        /// <summary>
        /// Reads an arithmetic expression.
        /// </summary>
        /// <param name="leftHandSide">
        /// The expression on the left hand side of the operator.
        /// </param>
        /// <param name="previousPrecedence">
        /// The precedence of the expression just before this one.
        /// </param>
        /// <param name="parentReference">
        /// The parent code unit.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code being parsed resides in an unsafe code block.
        /// </param>
        /// <returns>
        /// Returns the expression.
        /// </returns>
        private ArithmeticExpression GetArithmeticExpression(
            Expression leftHandSide, ExpressionPrecedence previousPrecedence, Reference<ICodePart> parentReference, bool unsafeCode)
        {
            Param.AssertNotNull(leftHandSide, "leftHandSide");
            Param.Ignore(previousPrecedence);
            Param.AssertNotNull(parentReference, "parentReference");
            Param.Ignore(unsafeCode);

            ArithmeticExpression expression = null;
            Reference<ICodePart> expressionReference = new Reference<ICodePart>();

            // Read the details of the expression.
            OperatorSymbol operatorToken = this.PeekOperatorToken(parentReference, expressionReference);
            Debug.Assert(
                operatorToken.Category == OperatorCategory.Arithmetic || operatorToken.Category == OperatorCategory.Shift, "Expected an arithmetic or shift operator");

            // Check the precedence of the operators to make sure we can gather this statement now.
            ExpressionPrecedence precedence = GetOperatorPrecedence(operatorToken.SymbolType);
            if (CheckPrecedence(previousPrecedence, precedence))
            {
                // Add the operator token to the document and advance the symbol manager up to it.
                this.symbols.Advance();
                this.tokens.Add(operatorToken);

                // Get the expression on the right-hand side of the operator.
                Expression rightHandSide = this.GetOperatorRightHandExpression(precedence, expressionReference, unsafeCode);

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
                expressionReference.Target = expression;
            }

            return expression;
        }

        /// <summary>
        /// Reads an array access expression.
        /// </summary>
        /// <param name="array">
        /// The array being accessed.
        /// </param>
        /// <param name="previousPrecedence">
        /// The precedence of the previous expression.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code being parsed resides in an unsafe code block.
        /// </param>
        /// <returns>
        /// Returns the expression.
        /// </returns>
        private ArrayAccessExpression GetArrayAccessExpression(Expression array, ExpressionPrecedence previousPrecedence, bool unsafeCode)
        {
            Param.AssertNotNull(array, "array");
            Param.Ignore(previousPrecedence);
            Param.Ignore(unsafeCode);

            ArrayAccessExpression expression = null;

            if (CheckPrecedence(previousPrecedence, ExpressionPrecedence.Primary))
            {
                Reference<ICodePart> expressionReference = new Reference<ICodePart>();

                // The next symbol will be the opening bracket.
                Bracket openingBracket = this.GetBracketToken(CsTokenType.OpenSquareBracket, SymbolType.OpenSquareBracket, expressionReference);
                Node<CsToken> openingBracketNode = this.tokens.InsertLast(openingBracket);

                // Get the argument list now.
                IList<Argument> argumentList = this.GetArgumentList(SymbolType.CloseSquareBracket, expressionReference, unsafeCode);

                // Get the closing bracket.
                Bracket closingBracket = this.GetBracketToken(CsTokenType.CloseSquareBracket, SymbolType.CloseSquareBracket, expressionReference);
                Node<CsToken> closingBracketNode = this.tokens.InsertLast(closingBracket);

                openingBracket.MatchingBracketNode = closingBracketNode;
                closingBracket.MatchingBracketNode = openingBracketNode;

                // Pull out the first token from the array.
                Node<CsToken> firstTokenNode = array.Tokens.First;

                // Create the token list for the method invocation expression.
                CsTokenList partialTokens = new CsTokenList(this.tokens, firstTokenNode, this.tokens.Last);

                // Create and return the expression.
                expression = new ArrayAccessExpression(partialTokens, array, argumentList);
                expressionReference.Target = expression;
            }

            return expression;
        }

        /// <summary>
        /// Reads an array initializer expression.
        /// </summary>
        /// <param name="unsafeCode">
        /// Indicates whether the code being parsed resides in an unsafe code block.
        /// </param>
        /// <returns>
        /// Returns the expression.
        /// </returns>
        private ArrayInitializerExpression GetArrayInitializerExpression(bool unsafeCode)
        {
            Param.Ignore(unsafeCode);

            Reference<ICodePart> expressionReference = new Reference<ICodePart>();

            // Get the first symbol and make sure it is an opening curly bracket.
            Bracket openingBracket = this.GetBracketToken(CsTokenType.OpenCurlyBracket, SymbolType.OpenCurlyBracket, expressionReference);
            Node<CsToken> openingBracketNode = this.tokens.InsertLast(openingBracket);

            // Get each of the initializers.
            List<Expression> initializers = new List<Expression>();

            while (true)
            {
                // If this initializer starts with an opening curly bracket, it is another
                // array initializer expression. Otherwise, parse it like a normal expression.
                Symbol symbol = this.GetNextSymbol(expressionReference);

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
                    initializers.Add(this.GetNextExpression(ExpressionPrecedence.None, expressionReference, unsafeCode));
                }

                // Now check the type of the next symbol and see if it is a comma.
                symbol = this.GetNextSymbol(expressionReference);

                if (symbol.SymbolType == SymbolType.Comma)
                {
                    // Add the comma and advance.
                    this.tokens.Add(this.GetToken(CsTokenType.Comma, SymbolType.Comma, expressionReference));
                }
            }

            // Add the closing curly bracket.
            Bracket closingBracket = this.GetBracketToken(CsTokenType.CloseCurlyBracket, SymbolType.CloseCurlyBracket, expressionReference);
            Node<CsToken> closingBracketNode = this.tokens.InsertLast(closingBracket);

            openingBracket.MatchingBracketNode = closingBracketNode;
            closingBracket.MatchingBracketNode = openingBracketNode;

            // Create the token list for the expression.
            CsTokenList partialTokens = new CsTokenList(this.tokens, openingBracketNode, this.tokens.Last);

            // Return the expression.
            ArrayInitializerExpression expression = new ArrayInitializerExpression(partialTokens, initializers.ToArray());
            expressionReference.Target = expression;

            return expression;
        }

        /// <summary>
        /// Reads an as expression.
        /// </summary>
        /// <param name="leftHandSide">
        /// The expression on the left hand side of the operator.
        /// </param>
        /// <param name="previousPrecedence">
        /// The precedence of the expression just before this one.
        /// </param>
        /// <param name="parentReference">
        /// The parent code unit.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code being parsed resides in an unsafe code block.
        /// </param>
        /// <returns>
        /// Returns the expression.
        /// </returns>
        private AsExpression GetAsExpression(Expression leftHandSide, ExpressionPrecedence previousPrecedence, Reference<ICodePart> parentReference, bool unsafeCode)
        {
            Param.AssertNotNull(leftHandSide, "leftHandSide");
            Param.Ignore(previousPrecedence);
            Param.AssertNotNull(parentReference, "parentReference");
            Param.Ignore(unsafeCode);

            AsExpression expression = null;

            // Check the previous precedence to see if we are allowed to gather up the as expression.
            if (CheckPrecedence(previousPrecedence, ExpressionPrecedence.Relational))
            {
                Reference<ICodePart> expressionReference = new Reference<ICodePart>();

                // Make sure the left hand side has at least one token.
                Debug.Assert(leftHandSide.Tokens.First != null, "The left hand side should not be empty");

                // Get the as symbol.
                this.tokens.Add(this.GetToken(CsTokenType.As, SymbolType.As, parentReference, expressionReference));

                // The next token must be the type.
                this.GetNextSymbol(SymbolType.Other, expressionReference);

                // Get the expression representing the type.
                LiteralExpression rightHandSide = this.GetTypeTokenExpression(expressionReference, unsafeCode, true);
                if (rightHandSide == null || rightHandSide.Tokens.First == null)
                {
                    throw this.CreateSyntaxException();
                }

                // Create the partial token list for the expression.
                CsTokenList partialTokens = new CsTokenList(this.tokens, leftHandSide.Tokens.First, this.tokens.Last);

                // Create and return the expression.
                expression = new AsExpression(partialTokens, leftHandSide, rightHandSide);
                expressionReference.Target = expression;
            }

            return expression;
        }

        /// <summary>
        /// Reads an assignment expression.
        /// </summary>
        /// <param name="leftHandSide">
        /// The expression on the left hand side of the operator.
        /// </param>
        /// <param name="previousPrecedence">
        /// The precedence of the expression just before this one.
        /// </param>
        /// <param name="parentReference">
        /// The parent code part.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code being parsed resides in an unsafe code block.
        /// </param>
        /// <returns>
        /// Returns the expression.
        /// </returns>
        private AssignmentExpression GetAssignmentExpression(
            Expression leftHandSide, ExpressionPrecedence previousPrecedence, Reference<ICodePart> parentReference, bool unsafeCode)
        {
            Param.AssertNotNull(leftHandSide, "leftHandSide");
            Param.Ignore(previousPrecedence);
            Param.Ignore(parentReference, "parentReference");
            Param.Ignore(unsafeCode);

            AssignmentExpression expression = null;
            Reference<ICodePart> expressionReference = new Reference<ICodePart>();

            // Read the details of the expression.
            OperatorSymbol operatorToken = this.PeekOperatorToken(parentReference, expressionReference);
            Debug.Assert(operatorToken.Category == OperatorCategory.Assignment, "Expected an assignment operator");

            // Check the precedence of the operators to make sure we can gather this statement now.
            ExpressionPrecedence precedence = GetOperatorPrecedence(operatorToken.SymbolType);
            if (CheckPrecedence(previousPrecedence, precedence))
            {
                // Add the operator token to the document and advance the symbol manager up to it.
                this.symbols.Advance();
                this.tokens.Add(operatorToken);

                // Get the expression on the right-hand side of the operator.
                Expression rightHandSide = this.GetOperatorRightHandExpression(ExpressionPrecedence.None, expressionReference, unsafeCode);

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
                expressionReference.Target = expression;
            }

            return expression;
        }

        /// <summary>
        /// Reads an await expression from the code.
        /// </summary>
        /// <param name="parentReference">
        /// The parent code unit.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code being parsed resides in an unsafe code block.
        /// </param>
        /// <returns>
        /// Returns the expression.
        /// </returns>
        private Expression GetAwaitExpression(Reference<ICodePart> parentReference, bool unsafeCode)
        {
            Param.AssertNotNull(parentReference, "parentReference");
            Param.Ignore(unsafeCode);

            Reference<ICodePart> expressionReference = new Reference<ICodePart>();

            // The first symbol must be the await keyword.
            Node<CsToken> firstTokenNode = this.tokens.InsertLast(this.GetToken(CsTokenType.Await, SymbolType.Other, parentReference, expressionReference));

            // Get the inner expression.
            Expression innerExpression = this.GetNextExpression(ExpressionPrecedence.None, expressionReference, unsafeCode);

            // Create the token list for the expression.
            CsTokenList partialTokens = new CsTokenList(this.tokens, firstTokenNode, this.tokens.Last);

            // Create and return the expression.
            AwaitExpression expression = new AwaitExpression(partialTokens, innerExpression);
            expressionReference.Target = expression;

            return expression;
        }

        /// <summary>
        /// Reads a null condition expression from the code.
        /// </summary>
        /// <param name="leftHandSide">The left hand side.</param>
        /// <param name="previousPrecedence">The previous precedence.</param>
        /// <param name="parentReference">The parent code unit.</param>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <returns>
        /// Returns the expression.
        /// </returns>
        private Expression GetNullConditionExpression(
            Expression leftHandSide, ExpressionPrecedence previousPrecedence, Reference<ICodePart> parentReference, bool unsafeCode)
        {
            Param.AssertNotNull(leftHandSide, "leftHandSide");
            Param.Ignore(previousPrecedence);
            Param.AssertNotNull(parentReference, "parentReference");
            Param.Ignore(unsafeCode);

            NullConditionExpression expression = null;
            Reference<ICodePart> expressionReference = new Reference<ICodePart>();

            // Read the details of the expression.
            OperatorSymbol operatorToken = this.PeekOperatorToken(parentReference, expressionReference);
            Debug.Assert(operatorToken.SymbolType == OperatorType.NullConditional, "Expected a null-conditional symbol");

            // Check the precedence of the operators to make sure we can gather this statement now.
            ExpressionPrecedence precedence = GetOperatorPrecedence(operatorToken.SymbolType);
            if (CheckPrecedence(previousPrecedence, precedence))
            {
                // Add the operator token to the document and advance the symbol manager up to it.
                this.symbols.Advance();
                this.tokens.Add(operatorToken);

                Expression rightHandSide = null;
                Symbol nextSymbol = this.symbols.Peek(1);

                // Check if next symbol is an open square bracket.
                if (nextSymbol.SymbolType == SymbolType.OpenSquareBracket)
                {
                    rightHandSide = this.GetArrayAccessExpression(leftHandSide, previousPrecedence, unsafeCode);
                }
                else
                {
                    rightHandSide = this.GetOperatorRightHandExpression(precedence, expressionReference, unsafeCode);
                }

                // We must find an expression else there is a syntax exception.
                if (rightHandSide == null)
                {
                    this.CreateSyntaxException();
                }

                // Create the partial token list for the expression.
                CsTokenList partialTokens = new CsTokenList(this.tokens, leftHandSide.Tokens.First, this.tokens.Last);

                // Create and return the expression.
                expression = new NullConditionExpression(partialTokens, leftHandSide, rightHandSide);
                expressionReference.Target = expression;
            }

            return expression;
        }

        /// <summary>
        /// Reads a cast expression.
        /// </summary>
        /// <param name="unsafeCode">
        /// Indicates whether the code being parsed resides in an unsafe code block.
        /// </param>
        /// <returns>
        /// Returns the expression.
        /// </returns>
        private CastExpression GetCastExpression(bool unsafeCode)
        {
            Param.Ignore(unsafeCode);

            Reference<ICodePart> expressionReference = new Reference<ICodePart>();

            // Get the opening parenthesis.
            Bracket openParenthesis = this.GetBracketToken(CsTokenType.OpenParenthesis, SymbolType.OpenParenthesis, expressionReference);
            Node<CsToken> openParenthesisNode = this.tokens.InsertLast(openParenthesis);

            // Get the next token. It must be an unknown word.
            this.GetNextSymbol(SymbolType.Other, expressionReference);

            // Get the casted expression.
            LiteralExpression type = this.GetTypeTokenExpression(expressionReference, unsafeCode, true);
            if (type == null || type.Tokens.First == null)
            {
                throw this.CreateSyntaxException();
            }

            // Get the closing parenthesis.
            Bracket closeParenthesis = this.GetBracketToken(CsTokenType.CloseParenthesis, SymbolType.CloseParenthesis, expressionReference);
            Node<CsToken> closeParenthesisNode = this.tokens.InsertLast(closeParenthesis);

            openParenthesis.MatchingBracketNode = closeParenthesisNode;
            closeParenthesis.MatchingBracketNode = openParenthesisNode;

            // Get the embedded expression being casted.
            Expression castedExpression = this.GetNextExpression(ExpressionPrecedence.Unary, expressionReference, unsafeCode);
            if (castedExpression == null || castedExpression.Tokens.First == null)
            {
                throw this.CreateSyntaxException();
            }

            // Create the token list for the expression.
            CsTokenList partialTokens = new CsTokenList(this.tokens, openParenthesisNode, this.tokens.Last);

            // Create and return the expression.
            CastExpression expression = new CastExpression(partialTokens, type, castedExpression);
            expressionReference.Target = expression;

            return expression;
        }

        /// <summary>
        /// Reads a checked expression from the code.
        /// </summary>
        /// <param name="parentReference">
        /// The parent code unit.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code being parsed resides in an unsafe code block.
        /// </param>
        /// <returns>
        /// Returns the expression.
        /// </returns>
        private CheckedExpression GetCheckedExpression(Reference<ICodePart> parentReference, bool unsafeCode)
        {
            Param.AssertNotNull(parentReference, "parentReference");
            Param.Ignore(unsafeCode);

            Reference<ICodePart> expressionReference = new Reference<ICodePart>();

            // Get the checked keyword.
            Node<CsToken> firstTokenNode = this.tokens.InsertLast(this.GetToken(CsTokenType.Checked, SymbolType.Checked, parentReference, expressionReference));

            // The next symbol will be the opening parenthesis.
            Bracket openParenthesis = this.GetBracketToken(CsTokenType.OpenParenthesis, SymbolType.OpenParenthesis, expressionReference);
            Node<CsToken> openParenthesisNode = this.tokens.InsertLast(openParenthesis);

            // Get the inner expression.
            Expression innerExpression = this.GetNextExpression(ExpressionPrecedence.None, expressionReference, unsafeCode);

            // Get the closing parenthesis.
            Bracket closeParenthesis = this.GetBracketToken(CsTokenType.CloseParenthesis, SymbolType.CloseParenthesis, expressionReference);
            Node<CsToken> closeParenthesisNode = this.tokens.InsertLast(closeParenthesis);

            openParenthesis.MatchingBracketNode = closeParenthesisNode;
            closeParenthesis.MatchingBracketNode = openParenthesisNode;

            // Create the token list for the method invocation expression.
            CsTokenList partialTokens = new CsTokenList(this.tokens, firstTokenNode, this.tokens.Last);

            // Create and return the expression.
            CheckedExpression expression = new CheckedExpression(partialTokens, innerExpression);
            expressionReference.Target = expression;

            return expression;
        }

        /// <summary>
        /// Gets a collection initializer expression.
        /// </summary>
        /// <param name="unsafeCode">
        /// Indicates whether the code being parsed resides in an unsafe code block.
        /// </param>
        /// <returns>
        /// Returns the expression.
        /// </returns>
        private CollectionInitializerExpression GetCollectionInitializerExpression(bool unsafeCode)
        {
            Param.Ignore(unsafeCode);

            Reference<ICodePart> expressionReference = new Reference<ICodePart>();
            List<Expression> initializerExpessions = new List<Expression>();

            // Add and move past the opening curly bracket.
            Bracket openingBracket = this.GetBracketToken(CsTokenType.OpenCurlyBracket, SymbolType.OpenCurlyBracket, expressionReference);
            Node<CsToken> openingBracketNode = this.tokens.InsertLast(openingBracket);

            while (true)
            {
                // If the next symbol is the closing curly bracket, then we are done.
                Symbol symbol = this.GetNextSymbol(expressionReference);
                if (symbol.SymbolType == SymbolType.CloseCurlyBracket)
                {
                    break;
                }

                Reference<ICodePart> initializerExpressionReference = new Reference<ICodePart>();

                // Get the next expression.
                Expression initializerExpression;

                switch (symbol.SymbolType)
                {
                    case SymbolType.OpenCurlyBracket:
                        initializerExpression = this.GetCollectionInitializerExpression(unsafeCode);
                        break;
                    case SymbolType.OpenSquareBracket:
                        initializerExpression = this.GetDictionaryInitializerExpression(expressionReference, unsafeCode);
                        break;
                    default:
                        initializerExpression = this.GetNextExpression(ExpressionPrecedence.None, expressionReference, unsafeCode);
                        break;
                }

                initializerExpressionReference.Target = initializerExpression;
                initializerExpessions.Add(initializerExpression);

                // Check whether we're done.
                symbol = this.GetNextSymbol(expressionReference);
                if (symbol.SymbolType == SymbolType.Comma)
                {
                    this.tokens.Add(this.GetToken(CsTokenType.Comma, SymbolType.Comma, expressionReference));

                    symbol = this.GetNextSymbol(expressionReference);

                    // If the next symbol after this is the closing curly bracket, then we are done.
                    if (symbol.SymbolType == SymbolType.CloseCurlyBracket)
                    {
                        break;
                    }
                }
                else if (symbol.SymbolType != SymbolType.CloseCurlyBracket)
                {
                    this.CreateSyntaxException();
                }
            }

            // Add and move past the closing curly bracket.
            Bracket closingBracket = this.GetBracketToken(CsTokenType.CloseCurlyBracket, SymbolType.CloseCurlyBracket, expressionReference);
            Node<CsToken> closingBracketNode = this.tokens.InsertLast(closingBracket);

            openingBracket.MatchingBracketNode = closingBracketNode;
            closingBracket.MatchingBracketNode = openingBracketNode;

            // Create the token list for the overall expression.
            CsTokenList expressionTokens = new CsTokenList(this.tokens, openingBracketNode, closingBracketNode);

            // Create and return the expression.
            CollectionInitializerExpression expression = new CollectionInitializerExpression(expressionTokens, initializerExpessions);
            expressionReference.Target = expression;

            return expression;
        }

        /// <summary>
        /// Gets the dictionary item initialization.
        /// </summary>
        /// <param name="parentReference">The parent reference.</param>
        /// <param name="unsafeCode">If set to <c>true</c> [unsafe code].</param>
        /// <returns>The dictionary item initialization expression.</returns>
        private DictionaryItemInitializationExpression GetDictionaryInitializerExpression(Reference<ICodePart> parentReference, bool unsafeCode)
        {
            Param.AssertNotNull(parentReference, "parentReference");
            Param.Ignore(unsafeCode);

            Reference<ICodePart> expressionReference = new Reference<ICodePart>();
            Node<CsToken> previousTokenNode = this.tokens.Last;

            // Check whether the next symbol is an opening parenthesis.
            Symbol symbol = this.GetNextSymbol(parentReference);

            if (symbol.SymbolType == SymbolType.Other)
            {
                CsToken token = this.GetToken(CsTokenType.Other, SymbolType.Other, parentReference);
                this.tokens.Add(token);

                symbol = this.GetNextSymbol(parentReference);
            }

            if (symbol.SymbolType != SymbolType.OpenSquareBracket)
            {
                throw new SyntaxException(
                    this.document.SourceCode,
                    symbol.LineNumber,
                    "A dictionary initializer expression must begin with an open square bracket.");
            }

            Bracket openBracket = this.GetBracketToken(CsTokenType.OpenSquareBracket, SymbolType.OpenSquareBracket, expressionReference);
            this.tokens.Add(openBracket);

            Expression identifier = this.GetNextExpression(ExpressionPrecedence.None, expressionReference, unsafeCode);

            Bracket closeBracket = this.GetBracketToken(CsTokenType.CloseSquareBracket, SymbolType.CloseSquareBracket, expressionReference);
            this.tokens.Add(closeBracket);

            symbol = this.GetNextSymbol(expressionReference);

            if (symbol.SymbolType == SymbolType.Equals)
            {
                // Get the equal operator.
                this.tokens.Add(this.GetOperatorToken(OperatorType.Equals, expressionReference));

                // Get the body of the expression. This can either be an expression or a statement.
                // If it starts with an opening curly bracket, it's a statement, otherwise it's an expression.
                symbol = this.GetNextSymbol(expressionReference);

                Expression declaration = this.GetNextExpression(ExpressionPrecedence.None, expressionReference, unsafeCode);
                Symbol nextSymbol = this.GetNextSymbol(parentReference);
            }

            Node<CsToken> lastTokenNode = this.tokens.Last;

            // Create the token list for the overall expression.
            CsTokenList expressionTokens = new CsTokenList(this.tokens, previousTokenNode, lastTokenNode);
            DictionaryItemInitializationExpression itemInitializationExpression
                = new DictionaryItemInitializationExpression(expressionTokens);

            // Return the expression.
            expressionReference.Target = itemInitializationExpression;
            return itemInitializationExpression;
        }

        /// <summary>
        /// Reads a conditional expression.
        /// </summary>
        /// <param name="leftHandSide">
        /// The expression on the left hand side of the operator.
        /// </param>
        /// <param name="previousPrecedence">
        /// The precedence of the expression just before this one.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code being parsed resides in an unsafe code block.
        /// </param>
        /// <returns>
        /// Returns the expression.
        /// </returns>
        private ConditionalExpression GetConditionalExpression(Expression leftHandSide, ExpressionPrecedence previousPrecedence, bool unsafeCode)
        {
            Param.AssertNotNull(leftHandSide, "leftHandSide");
            Param.Ignore(unsafeCode);
            Param.Ignore(previousPrecedence);

            ConditionalExpression expression = null;

            if (CheckPrecedence(previousPrecedence, ExpressionPrecedence.Conditional))
            {
                Reference<ICodePart> expressionReference = new Reference<ICodePart>();

                // Get the first operator.
                this.tokens.Add(this.GetOperatorToken(OperatorType.ConditionalQuestionMark, expressionReference));

                // Get the expression on the right-hand side of the operator.
                Expression trueValue = this.GetOperatorRightHandExpression(ExpressionPrecedence.Conditional, expressionReference, unsafeCode);

                // Get the next operator and make sure it is the correct type.
                this.tokens.Add(this.GetOperatorToken(OperatorType.ConditionalColon, expressionReference));

                // Get the expression on the right-hand side of the operator.
                Expression falseValue = this.GetOperatorRightHandExpression(ExpressionPrecedence.None, expressionReference, unsafeCode);

                // Create the partial token list for the expression.
                CsTokenList partialTokens = new CsTokenList(this.tokens, leftHandSide.Tokens.First, this.tokens.Last);

                // Create and return the expression.
                expression = new ConditionalExpression(partialTokens, leftHandSide, trueValue, falseValue);
                expressionReference.Target = expression;
            }

            return expression;
        }

        /// <summary>
        /// Reads a conditional logical expression.
        /// </summary>
        /// <param name="leftHandSide">
        /// The expression on the left hand side of the operator.
        /// </param>
        /// <param name="previousPrecedence">
        /// The precedence of the expression just before this one.
        /// </param>
        /// <param name="parentReference">
        /// The parent code part.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code being parsed resides in an unsafe code block.
        /// </param>
        /// <returns>
        /// Returns the expression.
        /// </returns>
        private ConditionalLogicalExpression GetConditionalLogicalExpression(
            Expression leftHandSide, ExpressionPrecedence previousPrecedence, Reference<ICodePart> parentReference, bool unsafeCode)
        {
            Param.AssertNotNull(leftHandSide, "leftHandSide");
            Param.Ignore(previousPrecedence);
            Param.AssertNotNull(parentReference, "parentReference");
            Param.Ignore(unsafeCode);

            ConditionalLogicalExpression expression = null;
            Reference<ICodePart> expressionReference = new Reference<ICodePart>();

            // Read the details of the expression.
            OperatorSymbol operatorToken = this.PeekOperatorToken(parentReference, expressionReference);
            Debug.Assert(operatorToken.Category == OperatorCategory.Logical, "Expected a logical operator");

            // Check the precedence of the operators to make sure we can gather this statement now.
            ExpressionPrecedence precedence = GetOperatorPrecedence(operatorToken.SymbolType);
            if (CheckPrecedence(previousPrecedence, precedence))
            {
                // Add the operator token to the document and advance the symbol manager up to it.
                this.symbols.Advance();
                this.tokens.Add(operatorToken);

                // Get the expression on the right-hand side of the operator.
                Expression rightHandSide = this.GetOperatorRightHandExpression(precedence, expressionReference, unsafeCode);

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
                expressionReference.Target = expression;
            }

            return expression;
        }

        /// <summary>
        /// Reads a default value expression from the code.
        /// </summary>
        /// <param name="parentReference">
        /// The parent code unit.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code being parsed resides in an unsafe code block.
        /// </param>
        /// <returns>
        /// Returns the expression.
        /// </returns>
        private DefaultValueExpression GetDefaultValueExpression(Reference<ICodePart> parentReference, bool unsafeCode)
        {
            Param.AssertNotNull(parentReference, "parentReference");
            Param.Ignore(unsafeCode);

            Reference<ICodePart> expressionReference = new Reference<ICodePart>();

            // Get the default keyword.
            Node<CsToken> firstTokenNode = this.tokens.InsertLast(this.GetToken(CsTokenType.DefaultValue, SymbolType.Default, parentReference, expressionReference));

            LiteralExpression typeTokenExpression = null;

            // The next symbol must be an opening curly bracket.
            Symbol symbol = this.GetNextSymbol(expressionReference);

            if (symbol.SymbolType == SymbolType.OpenParenthesis)
            {
                // The next symbol will be the opening parenthesis.
                Bracket openParenthesis = this.GetBracketToken(CsTokenType.OpenParenthesis, SymbolType.OpenParenthesis, expressionReference);
                Node<CsToken> openParenthesisNode = this.tokens.InsertLast(openParenthesis);

                // Get the inner expression.
                typeTokenExpression = this.GetTypeTokenExpression(expressionReference, unsafeCode, true);

                if (typeTokenExpression == null)
                {
                    throw this.CreateSyntaxException();
                }

                // Get the closing parenthesis.
                Bracket closeParenthesis = this.GetBracketToken(CsTokenType.CloseParenthesis, SymbolType.CloseParenthesis, expressionReference);
                Node<CsToken> closeParenthesisNode = this.tokens.InsertLast(closeParenthesis);

                openParenthesis.MatchingBracketNode = closeParenthesisNode;
                closeParenthesis.MatchingBracketNode = openParenthesisNode;
            }

            // Create the token list for the method invocation expression.
            CsTokenList partialTokens = new CsTokenList(this.tokens, firstTokenNode, this.tokens.Last);

            // Create and return the expression.
            DefaultValueExpression expression = new DefaultValueExpression(partialTokens, typeTokenExpression, parentReference);
            expressionReference.Target = expression;

            return expression;
        }

        /// <summary>
        /// Given an expression, reads further to see if it is actually a sub-expression 
        /// within a larger expression.
        /// </summary>
        /// <param name="leftSide">
        /// The known expression which might have an extension.
        /// </param>
        /// <param name="previousPrecedence">
        /// The precedence of the expression just before this one.
        /// </param>
        /// <param name="parentReference">
        /// The parent code part.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code being parsed resides in an unsafe code block.
        /// </param>
        /// <param name="typeExpression">
        /// Indicates whether only components of a type expression are allowed.
        /// </param>
        /// <param name="allowVariableDeclaration">
        /// Indicates whether variable declaration expressions are allowed.
        /// </param>
        /// <returns>
        /// Returns the expression.
        /// </returns>
        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "May be simplified later.")]
        [SuppressMessage("Microsoft.Globalization", "CA1303:DoNotPassLiteralsAsLocalizedParameters",
            MessageId = "StyleCop.CSharp.SymbolManager.Combine(System.Int32,System.Int32,System.String,StyleCop.CSharp.SymbolType)",
            Justification = "The literal represents a non-localizable C# operator symbol")]
        private Expression GetExpressionExtension(
            Expression leftSide,
            ExpressionPrecedence previousPrecedence,
            Reference<ICodePart> parentReference,
            bool unsafeCode,
            bool typeExpression,
            bool allowVariableDeclaration)
        {
            Param.AssertNotNull(leftSide, "leftSide");
            Param.Ignore(previousPrecedence);
            Param.AssertNotNull(parentReference, "parentReference");
            Param.Ignore(unsafeCode);
            Param.Ignore(typeExpression);
            Param.Ignore(allowVariableDeclaration);

            // The expression to return.
            Expression expression = null;

            Symbol symbol = this.GetNextSymbol(parentReference);

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
                        if (allowVariableDeclaration && (leftSide.ExpressionType == ExpressionType.Literal || leftSide.ExpressionType == ExpressionType.MemberAccess))
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
                        expression = this.GetAsExpression(leftSide, previousPrecedence, parentReference, unsafeCode);
                        break;

                    case SymbolType.Is:
                        expression = this.GetIsExpression(leftSide, previousPrecedence, parentReference, unsafeCode);
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
                        if (GetOperatorType(symbol, out type, out category))
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
                                            expression = this.GetUnsafeTypeExpression(leftSide, previousPrecedence, parentReference);
                                        }
                                        else
                                        {
                                            expression = this.GetArithmeticExpression(leftSide, previousPrecedence, parentReference, unsafeCode);
                                        }
                                    }
                                    else
                                    {
                                        expression = this.GetArithmeticExpression(leftSide, previousPrecedence, parentReference, unsafeCode);
                                    }

                                    break;

                                case OperatorCategory.Shift:
                                    expression = this.GetArithmeticExpression(leftSide, previousPrecedence, parentReference, unsafeCode);
                                    break;

                                case OperatorCategory.Assignment:
                                    expression = this.GetAssignmentExpression(leftSide, previousPrecedence, parentReference, unsafeCode);
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

                                    expression = this.GetRelationalExpression(leftSide, previousPrecedence, parentReference, unsafeCode);
                                    break;

                                case OperatorCategory.Logical:
                                    switch (type)
                                    {
                                        case OperatorType.LogicalAnd:
                                        case OperatorType.LogicalOr:
                                        case OperatorType.LogicalXor:
                                            expression = this.GetLogicalExpression(leftSide, previousPrecedence, parentReference, unsafeCode);
                                            break;

                                        case OperatorType.ConditionalAnd:
                                        case OperatorType.ConditionalOr:
                                            expression = this.GetConditionalLogicalExpression(leftSide, previousPrecedence, parentReference, unsafeCode);
                                            break;

                                        case OperatorType.NullCoalescingSymbol:
                                            expression = this.GetNullCoalescingExpression(leftSide, previousPrecedence, parentReference, unsafeCode);
                                            break;

                                        case OperatorType.NullConditional:
                                            expression = this.GetNullConditionExpression(leftSide, previousPrecedence, parentReference, unsafeCode);
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
        /// Reads an is expression.
        /// </summary>
        /// <param name="leftHandSide">
        /// The expression on the left hand side of the operator.
        /// </param>
        /// <param name="previousPrecedence">
        /// The precedence of the expression just before this one.
        /// </param>
        /// <param name="parentReference">
        /// The parent code unit.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code being parsed resides in an unsafe code block.
        /// </param>
        /// <returns>
        /// Returns the expression.
        /// </returns>
        private IsExpression GetIsExpression(Expression leftHandSide, ExpressionPrecedence previousPrecedence, Reference<ICodePart> parentReference, bool unsafeCode)
        {
            Param.AssertNotNull(leftHandSide, "leftHandSide");
            Param.Ignore(previousPrecedence);
            Param.AssertNotNull(parentReference, "parentReference");
            Param.Ignore(unsafeCode);

            IsExpression expression = null;

            // Check the previous precedence to see if we are allowed to gather up the is expression.
            if (CheckPrecedence(previousPrecedence, ExpressionPrecedence.Relational))
            {
                Reference<ICodePart> expressionReference = new Reference<ICodePart>();

                // Make sure the left hand side has at least one token.
                Debug.Assert(leftHandSide.Tokens.First != null, "The left hand side should not be empty");

                // Get the is symbol.
                this.tokens.Add(this.GetToken(CsTokenType.Is, SymbolType.Is, parentReference, expressionReference));

                // The next token could be a type or a constant.
                Expression rightHandSide;
                Expression matchVariable = null;
                Symbol nextSymbol = this.PeekNextSymbol(SkipSymbols.All, false);

                if (nextSymbol.SymbolType == SymbolType.Null || nextSymbol.SymbolType == SymbolType.String
                    || nextSymbol.SymbolType == SymbolType.Number || nextSymbol.SymbolType == SymbolType.True
                    || nextSymbol.SymbolType == SymbolType.False)
                {
                    // Get the expression representing the constant.
                    this.GetNextSymbol(SkipSymbols.All, expressionReference, false);
                    rightHandSide = this.GetNextExpression(ExpressionPrecedence.Primary, expressionReference, unsafeCode);
                }
                else
                {
                    // Get the expression representing the type.
                    this.GetNextSymbol(SymbolType.Other, expressionReference);
                    rightHandSide = this.GetTypeTokenExpression(expressionReference, unsafeCode, true, true);

                    // Check if we have a variable declared as part of pattern match.
                    // Next symbol must be other, and the following symbol must be ')', ';' or start of another operator).
                    int foundPosition;
                    OperatorCategory operatorCategory;
                    OperatorType operatorType;

                    nextSymbol = this.PeekNextSymbolFrom(0, SkipSymbols.All, false, out foundPosition);
                    Symbol followingSymbol = this.PeekNextSymbolFrom(foundPosition, SkipSymbols.All, false, out foundPosition);

                    if (nextSymbol.SymbolType == SymbolType.Other &&
                        (followingSymbol.SymbolType == SymbolType.CloseParenthesis
                        || followingSymbol.SymbolType == SymbolType.Semicolon
                        || GetOperatorType(followingSymbol, out operatorType, out operatorCategory)))
                    {
                        matchVariable = this.GetNextExpression(ExpressionPrecedence.Primary, parentReference, unsafeCode);
                    }
                }

                if (rightHandSide?.Tokens.First == null)
                {
                    throw this.CreateSyntaxException();
                }

                // Create the partial token list for the expression.
                CsTokenList partialTokens = new CsTokenList(this.tokens, leftHandSide.Tokens.First, this.tokens.Last);

                // Create and return the expression.
                expression = new IsExpression(partialTokens, leftHandSide, rightHandSide, matchVariable);
                expressionReference.Target = expression;
            }

            return expression;
        }

        /// <summary>
        /// Reads a lambda expression.
        /// </summary>
        /// <param name="parentReference">
        /// The parent code unit.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code being parsed resides in an unsafe code block.
        /// </param>
        /// <returns>
        /// Returns the expression.
        /// </returns>
        private LambdaExpression GetLambdaExpression(Reference<ICodePart> parentReference, bool unsafeCode)
        {
            Param.AssertNotNull(parentReference, "parentReference");
            Param.Ignore(unsafeCode);

            // Create an empty lambda expression.
            LambdaExpression lambdaExpression = new LambdaExpression();
            Reference<ICodePart> expressionReference = new Reference<ICodePart>();

            Node<CsToken> previousTokenNode = this.tokens.Last;

            // First symbol could be 'async' for asynchronous anonymous functions.
            Symbol nextSymbol = this.symbols.Peek(1);
            if (nextSymbol.SymbolType == SymbolType.Other && nextSymbol.Text == "async")
            {
                this.tokens.Add(this.GetToken(CsTokenType.Async, SymbolType.Other, expressionReference));
                lambdaExpression.Async = true;
            }

            // Check whether the next symbol is an opening parenthesis.
            Symbol symbol = this.GetNextSymbol(parentReference);

            ICollection<Parameter> parameters = null;

            if (symbol.SymbolType == SymbolType.OpenParenthesis)
            {
                parameters = this.ParseAnonymousMethodParameterList(expressionReference, unsafeCode);
            }
            else
            {
                // Since the statement did not begin with an opening parenthesis,
                // it must begin with a single unknown symbol.
                if (symbol.SymbolType != SymbolType.Other)
                {
                    throw new SyntaxException(this.document.SourceCode, symbol.LineNumber);
                }

                CsToken token = this.GetToken(CsTokenType.Other, SymbolType.Other, expressionReference);
                this.tokens.Add(token);

                // Add the single parameter.
                lambdaExpression.AddParameter(
                    new Parameter(
                        null,
                        token.Text,
                        expressionReference,
                        ParameterModifiers.None,
                        null,
                        token.Location,
                        new CsTokenList(this.tokens, this.tokens.Last, this.tokens.Last),
                        token.Generated));
            }

            // Get the lambda operator.
            this.tokens.Add(this.GetOperatorToken(OperatorType.Lambda, expressionReference));

            // Get the body of the expression. This can either be an expression or a statement.
            // If it starts with an opening curly bracket, it's a statement, otherwise it's an expression.
            symbol = this.GetNextSymbol(expressionReference);

            if (symbol.SymbolType == SymbolType.OpenCurlyBracket)
            {
                lambdaExpression.AnonymousFunctionBody = this.GetNextStatement(expressionReference, unsafeCode);
            }
            else
            {
                lambdaExpression.AnonymousFunctionBody = this.GetNextExpression(ExpressionPrecedence.None, expressionReference, unsafeCode);
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
                    lambdaExpression.Variables.Add(
                        new Variable(parameter.Type, parameter.Name, VariableModifiers.None, parameter.Location, expressionReference, parameter.Generated));
                }
            }

            // Return the expression.
            expressionReference.Target = lambdaExpression;
            return lambdaExpression;
        }

        /// <summary>
        /// Reads a bodied expression.
        /// </summary>
        /// <param name="parentReference">
        /// The parent code unit.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code being parsed resides in an unsafe code block.
        /// </param>
        /// <returns>
        /// Returns the expression.
        /// </returns>
        private BodiedExpression GetBodiedExpression(Reference<ICodePart> parentReference, bool unsafeCode)
        {
            Param.AssertNotNull(parentReference, "parentReference");
            Param.Ignore(unsafeCode);

            // Create an empty bodied expression.
            BodiedExpression bodiedExpression = new BodiedExpression();
            Reference<ICodePart> expressionReference = new Reference<ICodePart>();

            Node<CsToken> previousTokenNode = this.tokens.Last;

            // Check whether the next symbol is an opening parenthesis.
            Symbol symbol = this.GetNextSymbol(parentReference);
            ICollection<Parameter> parameters = null;

            // The statement must begin with an lambda operator
            if (symbol.SymbolType != SymbolType.Lambda)
            {
                throw new SyntaxException(this.document.SourceCode, symbol.LineNumber);
            }

            // Get the lambda operator.
            this.tokens.Add(this.GetOperatorToken(OperatorType.Lambda, expressionReference));

            // Get the body of the expression. This can either be an expression or a statement.
            // If it starts with an opening curly bracket, it's a statement, otherwise it's an expression.
            symbol = this.GetNextSymbol(expressionReference);

            if (symbol.SymbolType == SymbolType.OpenCurlyBracket)
            {
                bodiedExpression.AnonymousFunctionBody = this.GetNextStatement(expressionReference, unsafeCode);
            }
            else
            {
                bodiedExpression.AnonymousFunctionBody = this.GetNextExpression(ExpressionPrecedence.None, expressionReference, unsafeCode);
            }

            // Create the overall token list for the expression.
            Node<CsToken> firstNode = previousTokenNode == null ? this.tokens.First : previousTokenNode.Next;
            bodiedExpression.Tokens = new CsTokenList(this.tokens, firstNode, this.tokens.Last);

            // Get the item's argument list if necessary.
            if (parameters != null && parameters.Count > 0)
            {
                bodiedExpression.AddParameters(parameters);
            }

            // Add a variable for each of the parameters.
            if (bodiedExpression.Parameters != null && bodiedExpression.Parameters.Count > 0)
            {
                // Add a variable for each of the parameters.
                foreach (Parameter parameter in bodiedExpression.Parameters)
                {
                    bodiedExpression.Variables.Add(
                        new Variable(parameter.Type, parameter.Name, VariableModifiers.None, parameter.Location, expressionReference, parameter.Generated));
                }
            }

            // Return the expression.
            expressionReference.Target = bodiedExpression;
            return bodiedExpression;
        }

        /// <summary>
        /// Reads an expression starting with an unknown word.
        /// </summary>
        /// <param name="parentReference">
        /// The parent code part.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code is marked as unsafe.
        /// </param>
        /// <returns>
        /// Returns the expression.
        /// </returns>
        private LiteralExpression GetLiteralExpression(Reference<ICodePart> parentReference, bool unsafeCode)
        {
            Param.Ignore(unsafeCode);
            Param.AssertNotNull(parentReference, "parentReference");

            // Get the first symbol.
            Symbol symbol = this.GetNextSymbol(parentReference);

            // Create a reference to the literal expression we're creating.
            Reference<ICodePart> expressionReference = new Reference<ICodePart>();

            // First, check if this is a generic.
            CsToken literalToken = null;
            int temp;
            bool generic = false;
            if (symbol.SymbolType == SymbolType.Other && this.HasTypeSignature(1, false, out temp, out generic) && generic)
            {
                literalToken = this.GetGenericToken(expressionReference, unsafeCode);
            }

            if (literalToken == null)
            {
                // This is not a generic. Just convert the symbol to a token.
                literalToken = this.GetToken(CsTokenType.Other, SymbolType.Other, expressionReference);
            }

            // Add the token to the document.
            Node<CsToken> literalTokenNode = this.tokens.InsertLast(literalToken);

            // Create a literal expression from this token.
            LiteralExpression expression = new LiteralExpression(this.tokens, literalTokenNode);
            expressionReference.Target = expression;

            return expression;
        }

        /// <summary>
        /// Reads a logical expression.
        /// </summary>
        /// <param name="leftHandSide">
        /// The expression on the left hand side of the operator.
        /// </param>
        /// <param name="previousPrecedence">
        /// The precedence of the expression just before this one.
        /// </param>
        /// <param name="parentReference">
        /// The parent code part.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code being parsed resides in an unsafe code block.
        /// </param>
        /// <returns>
        /// Returns the expression.
        /// </returns>
        private LogicalExpression GetLogicalExpression(
            Expression leftHandSide, ExpressionPrecedence previousPrecedence, Reference<ICodePart> parentReference, bool unsafeCode)
        {
            Param.AssertNotNull(leftHandSide, "leftHandSide");
            Param.Ignore(previousPrecedence);
            Param.AssertNotNull(parentReference, "parentReference");
            Param.Ignore(unsafeCode);

            LogicalExpression expression = null;
            Reference<ICodePart> expressionReference = new Reference<ICodePart>();

            // Read the details of the expression.
            OperatorSymbol operatorToken = this.PeekOperatorToken(parentReference, expressionReference);
            Debug.Assert(operatorToken.Category == OperatorCategory.Logical, "Expected a logical operator");

            // Check the precedence of the operators to make sure we can gather this statement now.
            ExpressionPrecedence precedence = GetOperatorPrecedence(operatorToken.SymbolType);
            if (CheckPrecedence(previousPrecedence, precedence))
            {
                // Add the operator token to the document and advance the symbol manager up to it.
                this.symbols.Advance();
                this.tokens.Add(operatorToken);

                // Get the expression on the right-hand side of the operator.
                Expression rightHandSide = this.GetOperatorRightHandExpression(precedence, expressionReference, unsafeCode);

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
                expressionReference.Target = expression;
            }

            return expression;
        }

        /// <summary>
        /// Reads a member access expression.
        /// </summary>
        /// <param name="leftSide">
        /// The left side of the expression.
        /// </param>
        /// <param name="previousPrecedence">
        /// The precedence of the previous expression.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code is marked as unsafe.
        /// </param>
        /// <returns>
        /// Returns the expression.
        /// </returns>
        private MemberAccessExpression GetMemberAccessExpression(Expression leftSide, ExpressionPrecedence previousPrecedence, bool unsafeCode)
        {
            Param.AssertNotNull(leftSide, "leftSide");
            Param.Ignore(previousPrecedence);
            Param.Ignore(unsafeCode);

            MemberAccessExpression expression = null;

            OperatorType operatorType;
            MemberAccessExpression.Operator expressionOperatorType;
            ExpressionPrecedence precedence;

            Reference<ICodePart> expressionReference = new Reference<ICodePart>();

            // The next symbol must one of the member access types.
            Symbol symbol = this.GetNextSymbol(expressionReference);

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
                // Add this to the document.
                this.tokens.Add(this.GetOperatorToken(operatorType, expressionReference));

                // Get the member being accessed. This must be a literal.
                LiteralExpression member = this.GetLiteralExpression(expressionReference, unsafeCode);
                if (member == null)
                {
                    throw this.CreateSyntaxException();
                }

                // Create the token list.
                CsTokenList partialTokens = new CsTokenList(this.tokens, leftSide.Tokens.First, this.tokens.Last);

                // Create the expression.
                expression = new MemberAccessExpression(partialTokens, expressionOperatorType, leftSide, member);
                expressionReference.Target = expression;
            }

            return expression;
        }

        /// <summary>
        /// Reads a method access expression.
        /// </summary>
        /// <param name="methodName">
        /// The name of the method being called.
        /// </param>
        /// <param name="previousPrecedence">
        /// The precedence of the previous expression.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code being parsed resides in an unsafe code block.
        /// </param>
        /// <returns>
        /// Returns the expression.
        /// </returns>
        private MethodInvocationExpression GetMethodInvocationExpression(Expression methodName, ExpressionPrecedence previousPrecedence, bool unsafeCode)
        {
            Param.AssertNotNull(methodName, "methodName");
            Param.Ignore(previousPrecedence);
            Param.Ignore(unsafeCode);

            MethodInvocationExpression expression = null;
            if (CheckPrecedence(previousPrecedence, ExpressionPrecedence.Primary))
            {
                Reference<ICodePart> expressionReference = new Reference<ICodePart>();

                // The next symbol will be the opening parenthesis.
                Bracket openParenthesis = this.GetBracketToken(CsTokenType.OpenParenthesis, SymbolType.OpenParenthesis, expressionReference);
                Node<CsToken> openParenthesisNode = this.tokens.InsertLast(openParenthesis);

                // Get the argument list now.
                IList<Argument> argumentList = this.GetArgumentList(SymbolType.CloseParenthesis, expressionReference, unsafeCode);

                // Get the closing parenthesis.
                Bracket closeParenthesis = this.GetBracketToken(CsTokenType.CloseParenthesis, SymbolType.CloseParenthesis, expressionReference);
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
                expressionReference.Target = expression;
            }

            return expression;
        }

        /// <summary>
        /// Reads a new allocation expression from the code.
        /// </summary>
        /// <param name="parentReference">
        /// The parent code unit.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code being parsed resides in an unsafe code block.
        /// </param>
        /// <returns>
        /// Returns the expression.
        /// </returns>
        private Expression GetNewAllocationExpression(Reference<ICodePart> parentReference, bool unsafeCode)
        {
            Param.AssertNotNull(parentReference, "parentReference");
            Param.Ignore(unsafeCode);

            Reference<ICodePart> expressionReference = new Reference<ICodePart>();

            // The first symbol must be the new keyword.
            Node<CsToken> firstTokenNode = this.tokens.InsertLast(this.GetToken(CsTokenType.New, SymbolType.New, parentReference, expressionReference));

            // The next token must be a type identifier, or an opening curly bracket for an anonymous type creation, 
            // or an opening square bracket for a implicitly typed array creation or an open parenthesis for tuple type.
            Symbol symbol = this.GetNextSymbol(expressionReference);
            if (symbol.SymbolType == SymbolType.OpenCurlyBracket)
            {
                return this.GetNewAnonymousTypeExpression(unsafeCode, firstTokenNode, expressionReference);
            }
            else if (symbol.SymbolType == SymbolType.OpenSquareBracket)
            {
                return this.GetNewArrayTypeExpression(unsafeCode, firstTokenNode, null, expressionReference);
            }
            else if (symbol.SymbolType != SymbolType.Other && symbol.SymbolType != SymbolType.OpenParenthesis)
            {
                throw this.CreateSyntaxException();
            }

            // Get the type expression.
            Expression type = this.GetTypeTokenExpression(expressionReference, unsafeCode, false);
            if (type == null || type.Tokens.First == null)
            {
                throw this.CreateSyntaxException();
            }

            // Figure out the type of the new expression. If we hit an open parenthesis first,
            // then this is standard new type expression. If we hit an open square bracket first,
            // then this is a new array expression. If we hit an opening curly bracket first,
            // then this is a new expression which omits the argument list and uses an object 
            // or collection initializer.
            symbol = this.GetNextSymbol(expressionReference);

            // If this is a new array expression, get and return it.
            if (symbol.SymbolType == SymbolType.OpenSquareBracket || (symbol.Text == "?" && this.symbols.Peek(2).SymbolType == SymbolType.OpenSquareBracket))
            {
                return this.GetNewArrayTypeExpression(unsafeCode, firstTokenNode, type, expressionReference);
            }

            return this.GetNewNonArrayTypeExpression(unsafeCode, firstTokenNode, type, expressionReference);
        }

        /// <summary>
        /// Reads a new anonymous type allocation expression from the code.
        /// </summary>
        /// <param name="unsafeCode">
        /// Indicates whether the code being parsed resides in an unsafe code block.
        /// </param>
        /// <param name="firstTokenNode">
        /// The first token in the expression.
        /// </param>
        /// <param name="expressionReference">
        /// A reference to the expression being created.
        /// </param>
        /// <returns>
        /// Returns the expression.
        /// </returns>
        private NewExpression GetNewAnonymousTypeExpression(bool unsafeCode, Node<CsToken> firstTokenNode, Reference<ICodePart> expressionReference)
        {
            Param.Ignore(unsafeCode);
            Param.AssertNotNull(firstTokenNode, "firstTokenNode");
            Param.AssertNotNull(expressionReference, "expressionReference");

            // Get the anonymous type initializer expression.
            CollectionInitializerExpression initializer = this.GetAnonymousTypeInitializerExpression(expressionReference, unsafeCode);

            // Create the token list for the expression.
            CsTokenList partialTokens = new CsTokenList(this.tokens, firstTokenNode, initializer.Tokens.Last);

            // Create and return the expression.
            NewExpression expression = new NewExpression(partialTokens, null, initializer);
            expressionReference.Target = expression;

            return expression;
        }

        /// <summary>
        /// Reads a new array allocation expression from the code.
        /// </summary>
        /// <param name="unsafeCode">
        /// Indicates whether the code being parsed resides in an unsafe code block.
        /// </param>
        /// <param name="firstTokenNode">
        /// The first token in the expression.
        /// </param>
        /// <param name="type">
        /// The type of the array. This may be null for an implicitly typed array.
        /// </param>
        /// <param name="expressionReference">
        /// A reference to the expression being created.
        /// </param>
        /// <returns>
        /// Returns the expression.
        /// </returns>
        private NewArrayExpression GetNewArrayTypeExpression(bool unsafeCode, Node<CsToken> firstTokenNode, Expression type, Reference<ICodePart> expressionReference)
        {
            Param.Ignore(unsafeCode);
            Param.AssertNotNull(firstTokenNode, "firstTokenNode");
            Param.Ignore(type);
            Param.AssertNotNull(expressionReference, "expressionReference");

            Symbol questionMark = this.GetNextSymbol(SkipSymbols.WhiteSpace, expressionReference, true);

            if (questionMark != null && questionMark.SymbolType == SymbolType.NullConditional)
            {
                CsToken tok = this.GetToken(CsTokenType.NullableTypeSymbol, SymbolType.NullConditional, expressionReference);
                this.tokens.Add(tok);
            }

            // Get the next symbol.
            Symbol symbol = this.GetNextSymbol(SymbolType.OpenSquareBracket, expressionReference);

            // If the type is null, then this is an implicitly typed array and we will only find
            // array brackets here. Otherwise, we must get the array access expression which includes the type.
            if (type == null)
            {
                this.MovePastArrayBrackets(expressionReference);
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

                    symbol = this.GetNextSymbol(expressionReference);
                }
            }

            // Make sure there was at least one array access.
            if (type != null && type.ExpressionType != ExpressionType.ArrayAccess)
            {
                throw this.CreateSyntaxException();
            }

            // Get the next symbol and check the type.
            symbol = this.GetNextSymbol(expressionReference);

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
            NewArrayExpression expression = new NewArrayExpression(partialTokens, type as ArrayAccessExpression, initializer);
            expressionReference.Target = expression;

            return expression;
        }

        /// <summary>
        /// Reads a new non-array type allocation expression from the code.
        /// </summary>
        /// <param name="unsafeCode">
        /// Indicates whether the code being parsed resides in an unsafe code block.
        /// </param>
        /// <param name="firstTokenNode">
        /// The first token in the expression.
        /// </param>
        /// <param name="type">
        /// The type of the array.
        /// </param>
        /// <param name="expressionReference">
        /// A reference to the expression being created.
        /// </param>
        /// <returns>
        /// Returns the expression.
        /// </returns>
        private NewExpression GetNewNonArrayTypeExpression(bool unsafeCode, Node<CsToken> firstTokenNode, Expression type, Reference<ICodePart> expressionReference)
        {
            Param.Ignore(unsafeCode);
            Param.AssertNotNull(firstTokenNode, "firstTokenNode");
            Param.AssertNotNull(type, "type");
            Param.AssertNotNull(expressionReference, "expressionReference");

            Expression typeCreationExpression = type;

            // If the next symbol is an opening parenthesis, then there is an argument
            // list which must be attached to the type creation expression.
            Symbol symbol = this.GetNextSymbol(expressionReference);

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
            symbol = this.GetNextSymbol(expressionReference);

            Expression initializer = null;
            if (symbol.SymbolType == SymbolType.OpenCurlyBracket)
            {
                initializer = this.GetObjectOrCollectionInitializerExpression(expressionReference, unsafeCode);

                if (initializer == null || initializer.Tokens.First == null)
                {
                    throw this.CreateSyntaxException();
                }
            }

            // Create the token list for the expression.
            CsTokenList partialTokens = new CsTokenList(this.tokens, firstTokenNode, this.tokens.Last);

            // Create and return the expression.
            NewExpression expression = new NewExpression(partialTokens, typeCreationExpression, initializer);
            expressionReference.Target = expression;

            return expression;
        }

        /// <summary>
        /// Reads the next expression from the file and returns it.
        /// </summary>
        /// <param name="previousPrecedence">
        /// The precedence of the expression just before this one.
        /// </param>
        /// <param name="parentReference">
        /// Reference to the parent code part.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code being parsed resides in an unsafe code block.
        /// </param>
        /// <returns>
        /// Returns the expression.
        /// </returns>
        private Expression GetNextExpression(ExpressionPrecedence previousPrecedence, Reference<ICodePart> parentReference, bool unsafeCode)
        {
            Param.Ignore(previousPrecedence);
            Param.AssertNotNull(parentReference, "parentReference");
            Param.Ignore(unsafeCode);

            return this.GetNextExpression(previousPrecedence, parentReference, unsafeCode, false, false);
        }

        /// <summary>
        /// Reads the next expression from the file and returns it.
        /// </summary>
        /// <param name="previousPrecedence">
        /// The precedence of the expression just before this one.
        /// </param>
        /// <param name="parentReference">
        /// Reference to the parent code part.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code being parsed resides in an unsafe code block.
        /// </param>
        /// <param name="allowVariableDeclaration">
        /// Indicates whether this expression can be a variable declaration expression.
        /// </param>
        /// <param name="typeExpression">
        /// Indicates whether only components of a type expression are allowed.
        /// </param>
        /// <returns>
        /// Returns the expression.
        /// </returns>
        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "May be simplified later.")]
        private Expression GetNextExpression(
            ExpressionPrecedence previousPrecedence, Reference<ICodePart> parentReference, bool unsafeCode, bool allowVariableDeclaration, bool typeExpression)
        {
            Param.Ignore(previousPrecedence);
            Param.AssertNotNull(parentReference, "parentReference");
            Param.Ignore(unsafeCode);
            Param.Ignore(allowVariableDeclaration);
            Param.Ignore(typeExpression);

            // Saves the next expression.
            Expression expression = null;

            // Get the next symbol.
            Symbol symbol = this.GetNextSymbol(parentReference);

            if (symbol != null)
            {
                switch (symbol.SymbolType)
                {
                    case SymbolType.Other:
                        if (this.IsDelegateExpression())
                        {
                            expression = this.GetAnonymousMethodExpression(parentReference, unsafeCode);
                        }
                        else if (this.IsLambdaExpression())
                        {
                            expression = this.GetLambdaExpression(parentReference, unsafeCode);
                        }
                        else if (this.IsQueryExpression(unsafeCode))
                        {
                            expression = this.GetQueryExpression(parentReference, unsafeCode);
                        }
                        else if (this.IsAwaitExpression())
                        {
                            expression = this.GetAwaitExpression(parentReference, unsafeCode);
                        }
                        else if (symbol.Text == "var" && DetectTupleType(0) > 0)
                        {
                            expression = this.GetTupleTypeDeclarationExpression(unsafeCode, true);
                        }

                        // If the expression is still null now, this is just a regular 'other' expression.
                        if (expression == null)
                        {
                            expression = this.GetOtherExpression(parentReference, allowVariableDeclaration, unsafeCode);
                        }

                        break;

                    case SymbolType.Checked:
                        expression = this.GetCheckedExpression(parentReference, unsafeCode);
                        break;

                    case SymbolType.Unchecked:
                        expression = this.GetUncheckedExpression(parentReference, unsafeCode);
                        break;

                    case SymbolType.NameOf:
                        expression = this.GetNameofExpression(parentReference, unsafeCode);
                        break;

                    case SymbolType.New:
                        expression = this.GetNewAllocationExpression(parentReference, unsafeCode);
                        break;

                    case SymbolType.Stackalloc:
                        expression = this.GetStackallocExpression(parentReference, unsafeCode);
                        break;

                    case SymbolType.Sizeof:
                        expression = this.GetSizeofExpression(parentReference, unsafeCode);
                        break;

                    case SymbolType.Typeof:
                        expression = this.GetTypeofExpression(parentReference, unsafeCode);
                        break;

                    case SymbolType.Default:
                        expression = this.GetDefaultValueExpression(parentReference, unsafeCode);
                        break;

                    case SymbolType.Delegate:
                        expression = this.GetAnonymousMethodExpression(parentReference, unsafeCode);
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
                            expression = this.GetUnaryExpression(parentReference, unsafeCode);
                        }

                        break;

                    case SymbolType.Not:
                    case SymbolType.Tilde:
                        expression = this.GetUnaryExpression(parentReference, unsafeCode);
                        break;

                    case SymbolType.OpenParenthesis:
                        if (this.IsLambdaExpression())
                        {
                            expression = this.GetLambdaExpression(parentReference, unsafeCode);
                        }
                        else
                        {
                            expression = this.GetOpenParenthesisExpression(previousPrecedence, unsafeCode);
                        }

                        break;

                    case SymbolType.Lambda:
                        if (this.IsBodiedExpression())
                        {
                            expression = this.GetBodiedExpression(parentReference, unsafeCode);
                        }

                        break;

                    case SymbolType.OpenSquareBracket:
                        expression = this.GetOpenParenthesisExpression(previousPrecedence, unsafeCode);
                        break;

                    case SymbolType.Number:
                        Reference<ICodePart> numberExpressionReference = new Reference<ICodePart>();
                        Node<CsToken> tokenNode = this.tokens.InsertLast(this.GetToken(CsTokenType.Number, SymbolType.Number, numberExpressionReference));
                        expression = new LiteralExpression(new CsTokenList(this.tokens, tokenNode, tokenNode), tokenNode);
                        numberExpressionReference.Target = expression;
                        break;

                    case SymbolType.String:
                        Reference<ICodePart> stringExpressionReference = new Reference<ICodePart>();
                        tokenNode = this.tokens.InsertLast(this.GetToken(CsTokenType.String, SymbolType.String, stringExpressionReference));
                        expression = new LiteralExpression(new CsTokenList(this.tokens, tokenNode, tokenNode), tokenNode);
                        stringExpressionReference.Target = expression;
                        break;

                    case SymbolType.True:
                        Reference<ICodePart> trueExpressionReference = new Reference<ICodePart>();
                        tokenNode = this.tokens.InsertLast(this.GetToken(CsTokenType.True, SymbolType.True, trueExpressionReference));
                        expression = new LiteralExpression(new CsTokenList(this.tokens, tokenNode, tokenNode), tokenNode);
                        trueExpressionReference.Target = expression;
                        break;

                    case SymbolType.False:
                        Reference<ICodePart> falseExpressionReference = new Reference<ICodePart>();
                        tokenNode = this.tokens.InsertLast(this.GetToken(CsTokenType.False, SymbolType.False, falseExpressionReference));
                        expression = new LiteralExpression(new CsTokenList(this.tokens, tokenNode, tokenNode), tokenNode);
                        falseExpressionReference.Target = expression;
                        break;

                    case SymbolType.Null:
                        Reference<ICodePart> nullExpressionReference = new Reference<ICodePart>();
                        tokenNode = this.tokens.InsertLast(this.GetToken(CsTokenType.Null, SymbolType.Null, nullExpressionReference));
                        expression = new LiteralExpression(new CsTokenList(this.tokens, tokenNode, tokenNode), tokenNode);
                        nullExpressionReference.Target = expression;
                        break;

                    case SymbolType.This:
                        Reference<ICodePart> thisExpressionReference = new Reference<ICodePart>();
                        tokenNode = this.tokens.InsertLast(this.GetToken(CsTokenType.This, SymbolType.This, thisExpressionReference));
                        expression = new LiteralExpression(new CsTokenList(this.tokens, tokenNode, tokenNode), tokenNode);
                        thisExpressionReference.Target = expression;
                        break;

                    case SymbolType.Base:
                        Reference<ICodePart> baseExpressionReference = new Reference<ICodePart>();
                        tokenNode = this.tokens.InsertLast(this.GetToken(CsTokenType.Base, SymbolType.Base, baseExpressionReference));
                        expression = new LiteralExpression(new CsTokenList(this.tokens, tokenNode, tokenNode), tokenNode);
                        baseExpressionReference.Target = expression;
                        break;

                    case SymbolType.Multiplication:
                        if (!unsafeCode)
                        {
                            goto default;
                        }

                        expression = this.GetUnsafeAccessExpression(parentReference, unsafeCode);
                        break;

                    case SymbolType.LogicalAnd:
                        if (!unsafeCode)
                        {
                            goto default;
                        }

                        expression = this.GetUnsafeAccessExpression(parentReference, unsafeCode);
                        break;

                    case SymbolType.OpenCurlyBracket:
                        expression = this.GetCollectionInitializerExpression(unsafeCode);
                        break;

                    case SymbolType.Throw:
                        expression = this.GetThrowExpression(parentReference, unsafeCode);
                        break;

                    case SymbolType.Ref:
                        expression = this.GetRefExpression(parentReference, unsafeCode);
                        break;

                    default:
                        throw new SyntaxException(this.document.SourceCode, symbol.LineNumber);
                }
            }

            // Gather up all extensions to this expression.
            while (expression != null)
            {
                Reference<ICodePart> expressionReference = new Reference<ICodePart>(expression);

                // Check if there is an extension to this expression.
                Expression extension = this.GetExpressionExtension(
                    expression, previousPrecedence, expressionReference, unsafeCode, typeExpression, allowVariableDeclaration);
                if (extension == null)
                {
                    // There are no more extensions.
                    break;
                }

                // The larger expression is what we want to return here.
                expression = extension;
            }

            // Return the expression.
            return expression;
        }

        /// <summary>
        /// Reads a null coalescing expression.
        /// </summary>
        /// <param name="leftHandSide">
        /// The expression on the left hand side of the operator.
        /// </param>
        /// <param name="previousPrecedence">
        /// The precedence of the expression just before this one.
        /// </param>
        /// <param name="parentReference">
        /// The parent code unit.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code being parsed resides in an unsafe code block.
        /// </param>
        /// <returns>
        /// Returns the expression.
        /// </returns>
        private NullCoalescingExpression GetNullCoalescingExpression(
            Expression leftHandSide, ExpressionPrecedence previousPrecedence, Reference<ICodePart> parentReference, bool unsafeCode)
        {
            Param.AssertNotNull(leftHandSide, "leftHandSide");
            Param.Ignore(previousPrecedence);
            Param.AssertNotNull(parentReference, "parentReference");
            Param.Ignore(unsafeCode);

            NullCoalescingExpression expression = null;
            Reference<ICodePart> expressionReference = new Reference<ICodePart>();

            // Read the details of the expression.
            OperatorSymbol operatorToken = this.PeekOperatorToken(parentReference, expressionReference);
            Debug.Assert(operatorToken.SymbolType == OperatorType.NullCoalescingSymbol, "Expected a null-coalescing symbol");

            // Check the precedence of the operators to make sure we can gather this statement now.
            ExpressionPrecedence precedence = GetOperatorPrecedence(operatorToken.SymbolType);
            if (CheckPrecedence(previousPrecedence, precedence))
            {
                // Add the operator token to the document and advance the symbol manager up to it.
                this.symbols.Advance();
                this.tokens.Add(operatorToken);

                // Get the expression on the right-hand side of the operator.
                Expression rightHandSide = this.GetOperatorRightHandExpression(precedence, expressionReference, unsafeCode);

                // Create the partial token list for the expression.
                CsTokenList partialTokens = new CsTokenList(this.tokens, leftHandSide.Tokens.First, this.tokens.Last);

                // Create and return the expression.
                expression = new NullCoalescingExpression(partialTokens, leftHandSide, rightHandSide);
                expressionReference.Target = expression;
            }

            return expression;
        }

        /// <summary>
        /// Gets an object initializer expression.
        /// </summary>
        /// <param name="unsafeCode">
        /// Indicates whether the code being parsed resides in an unsafe code block.
        /// </param>
        /// <returns>
        /// Returns the expression.
        /// </returns>
        private ObjectInitializerExpression GetObjectInitializerExpression(bool unsafeCode)
        {
            Param.Ignore(unsafeCode);

            Reference<ICodePart> expressionReference = new Reference<ICodePart>();
            List<AssignmentExpression> initializerExpressions = new List<AssignmentExpression>();

            // Add and move past the opening curly bracket.
            Bracket openingBracket = this.GetBracketToken(CsTokenType.OpenCurlyBracket, SymbolType.OpenCurlyBracket, expressionReference);
            Node<CsToken> openingBracketNode = this.tokens.InsertLast(openingBracket);

            while (true)
            {
                // If the next symbol is the closing curly bracket, then we are done.
                Symbol symbol = this.GetNextSymbol(expressionReference);
                if (symbol.SymbolType == SymbolType.CloseCurlyBracket)
                {
                    break;
                }

                Reference<ICodePart> initializerExpressionReference = new Reference<ICodePart>();

                // Get the identifier.
                LiteralExpression identifier = this.GetLiteralExpression(initializerExpressionReference, unsafeCode);

                // Get the equals sign.
                symbol = this.GetNextSymbol(initializerExpressionReference);
                if (symbol.SymbolType != SymbolType.Equals)
                {
                    throw this.CreateSyntaxException();
                }

                this.tokens.Add(this.GetOperatorToken(OperatorType.Equals, initializerExpressionReference));

                // Get the initializer value. If this begins with an opening curly bracket,
                // this is an embedded object or collection initializer. Otherwise, it is
                // some other kind of expression.
                Expression initializerValue = null;

                symbol = this.GetNextSymbol(initializerExpressionReference);
                if (symbol.SymbolType == SymbolType.OpenCurlyBracket)
                {
                    initializerValue = this.GetObjectOrCollectionInitializerExpression(initializerExpressionReference, unsafeCode);
                }
                else
                {
                    initializerValue = this.GetNextExpression(ExpressionPrecedence.None, initializerExpressionReference, unsafeCode);
                }

                // Create and add this initializer.
                CsTokenList initializerTokens = new CsTokenList(this.tokens, identifier.Tokens.First, initializerValue.Tokens.Last);
                AssignmentExpression initializerExpression = new AssignmentExpression(
                    initializerTokens, AssignmentExpression.Operator.Equals, identifier, initializerValue);

                initializerExpressionReference.Target = initializerExpression;
                initializerExpressions.Add(initializerExpression);

                // Check whether we're done.
                symbol = this.GetNextSymbol(expressionReference);
                if (symbol.SymbolType == SymbolType.Comma)
                {
                    this.tokens.Add(this.GetToken(CsTokenType.Comma, SymbolType.Comma, expressionReference));

                    // If the next symbol after this is the closing curly bracket, then we are done.
                    symbol = this.GetNextSymbol(expressionReference);
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
            Bracket closingBracket = this.GetBracketToken(CsTokenType.CloseCurlyBracket, SymbolType.CloseCurlyBracket, expressionReference);
            Node<CsToken> closingBracketNode = this.tokens.InsertLast(closingBracket);

            openingBracket.MatchingBracketNode = closingBracketNode;
            closingBracket.MatchingBracketNode = openingBracketNode;

            // Create the token list for the overall expression.
            CsTokenList expressionTokens = new CsTokenList(this.tokens, openingBracketNode, closingBracketNode);

            // Create and return the expression.
            ObjectInitializerExpression expression = new ObjectInitializerExpression(expressionTokens, initializerExpressions.ToArray());
            expressionReference.Target = expression;

            return expression;
        }

        /// <summary>
        /// Gets an object initializer or collection initializer expression.
        /// </summary>
        /// <param name="parentReference">
        /// The parent code unit.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code being parsed resides in an unsafe code block.
        /// </param>
        /// <returns>
        /// Returns the expression.
        /// </returns>
        private Expression GetObjectOrCollectionInitializerExpression(Reference<ICodePart> parentReference, bool unsafeCode)
        {
            Param.AssertNotNull(parentReference, "parentReference");
            Param.Ignore(unsafeCode);

            Symbol symbol = this.GetNextSymbol(SymbolType.OpenCurlyBracket, parentReference);

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
        /// Reads an expression beginning with an opening parenthesis.
        /// </summary>
        /// <param name="previousPrecedence">
        /// The precedence of the previous expression.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code being parsed resides in an unsafe code block.
        /// </param>
        /// <returns>
        /// Returns the expression.
        /// </returns>
        private Expression GetOpenParenthesisExpression(ExpressionPrecedence previousPrecedence, bool unsafeCode)
        {
            Param.Ignore(previousPrecedence, unsafeCode);

            Expression expression = null;

            // Now check whether this is a cast.
            if (this.IsCastExpression(previousPrecedence, unsafeCode))
            {
                expression = this.GetCastExpression(unsafeCode);
            }
            else
            {
                // This is an expression wrapped in parenthesis.
                expression = this.GetTupleOrParenthesizedExpression(unsafeCode);
            }

            return expression;
        }

        /// <summary>
        /// Reads and returns the right-hand expression of an operator expression.
        /// </summary>
        /// <param name="precedence">
        /// The precedence of this operator expression.
        /// </param>
        /// <param name="parentReference">
        /// The parent code unit.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code being parsed resides in an unsafe code block.
        /// </param>
        /// <returns>
        /// Returns the expression.
        /// </returns>
        private Expression GetOperatorRightHandExpression(ExpressionPrecedence precedence, Reference<ICodePart> parentReference, bool unsafeCode)
        {
            Param.AssertNotNull(precedence, "precedence");
            Param.AssertNotNull(parentReference, "parentReference");
            Param.Ignore(unsafeCode);

            // Get the right hand expression.
            Expression rightHandSide = this.GetNextExpression(precedence, parentReference, unsafeCode);
            if (rightHandSide == null)
            {
                throw this.CreateSyntaxException();
            }

            // Make sure the right hand side has at least one token.
            Debug.Assert(rightHandSide.Tokens.First != null, "The right-hand side should not be empty.");

            return rightHandSide;
        }

        /// <summary>
        /// Gets an expression that starts with an unknown word.
        /// </summary>
        /// <param name="parentReference">
        /// The parent code unit.
        /// </param>
        /// <param name="allowVariableDeclaration">
        /// Indicates whether this expression can be a variable declaration expression.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the expression resides within a block of unsafe code.
        /// </param>
        /// <returns>
        /// Returns the expression.
        /// </returns>
        private Expression GetOtherExpression(Reference<ICodePart> parentReference, bool allowVariableDeclaration, bool unsafeCode)
        {
            Param.AssertNotNull(parentReference, "parentReference");
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
                                if (temp.SymbolType == SymbolType.Equals || temp.SymbolType == SymbolType.Semicolon || temp.SymbolType == SymbolType.CloseParenthesis
                                    || temp.SymbolType == SymbolType.Comma || temp.SymbolType == SymbolType.In)
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
                Reference<ICodePart> variableDeclarationExpressionReference = new Reference<ICodePart>();
                LiteralExpression type = this.GetTypeTokenExpression(variableDeclarationExpressionReference, unsafeCode, true);
                if (type == null || type.Tokens.First == null)
                {
                    throw this.CreateSyntaxException();
                }

                // Then get the rest of the expression.
                expression = this.GetVariableDeclarationExpression(type, ExpressionPrecedence.None, unsafeCode);
                variableDeclarationExpressionReference.Target = expression;
            }
            else
            {
                // This is just a literal expression.
                expression = this.GetLiteralExpression(parentReference, unsafeCode);
            }

            return expression;
        }

        /// <summary>
        /// Reads an expression wrapped in parenthesis expression, or a tuple expression.
        /// </summary>
        /// <param name="unsafeCode">
        /// Indicates whether the code being parsed resides in an unsafe code block.
        /// </param>
        /// <returns>
        /// Returns a TupleExpression or ParenthesizedExpression.
        /// </returns>
        private Expression GetTupleOrParenthesizedExpression(bool unsafeCode)
        {
            Param.Ignore(unsafeCode);

            Reference<ICodePart> expressionReference = new Reference<ICodePart>();

            // Get the opening parenthesis.
            Bracket openParenthesis = this.GetBracketToken(CsTokenType.OpenParenthesis, SymbolType.OpenParenthesis, expressionReference);
            Node<CsToken> openParenthesisNode = this.tokens.InsertLast(openParenthesis);

            // Get the first expression.
            Expression firstExpression = this.GetNextExpression(ExpressionPrecedence.None, expressionReference, unsafeCode);

            if (firstExpression == null)
            {
                throw this.CreateSyntaxException();
            }

            Bracket closeParenthesis;
            Node<CsToken> closeParenthesisNode;
            CsTokenList partialTokens;
            Expression resultExpression;

            Symbol nextSymbol = this.PeekNextSymbol(SkipSymbols.All, false);

            // If this is a regular parenthesized expression, return it now.
            if (nextSymbol.SymbolType == SymbolType.CloseParenthesis)
            {
                // Get the closing parenthesis.
                closeParenthesis = this.GetBracketToken(CsTokenType.CloseParenthesis, SymbolType.CloseParenthesis, expressionReference);
                closeParenthesisNode = this.tokens.InsertLast(closeParenthesis);

                // Create the token list for the expression.
                partialTokens = new CsTokenList(this.tokens, openParenthesisNode, this.tokens.Last);

                // Create the expression.
                resultExpression = new ParenthesizedExpression(partialTokens, firstExpression);
            }
            else
            {
                // We are parsing a Tuple variable or declaration.
                List<Argument> tupleArguments = null;
                List<VariableDeclarationExpression> tupleVariables = null;

                if (nextSymbol.SymbolType == SymbolType.Comma)
                {
                    // We already read the expression, just create an Argument out it.
                    var firstArgument = new Argument(
                        null,
                        ParameterModifiers.None,
                        firstExpression,
                        firstExpression.Location,
                        expressionReference,
                        firstExpression.Tokens,
                        this.symbols.Generated);
                    this.tokens.Add(this.GetToken(CsTokenType.Comma, SymbolType.Comma, expressionReference));
                    tupleArguments = this.ReadRemainingTupleArguments(expressionReference, firstArgument, unsafeCode);
                }
                else if ((nextSymbol.SymbolType == SymbolType.Colon) && firstExpression.Tokens.First == firstExpression.Tokens.Last)
                {
                    // This is a named Argument or type declaration in tuple, and we partially read it, discard the firstExpression and read the Argument.
                    var firstArgument = this.GetNextArgument(
                        expressionReference,
                        unsafeCode,
                        this.symbols.Current,
                        true,
                        this.tokens.Last.Previous);
                    tupleArguments = this.ReadRemainingTupleArguments(expressionReference, firstArgument, unsafeCode);
                }
                else if (nextSymbol.SymbolType == SymbolType.Other && firstExpression.Tokens.First == firstExpression.Tokens.Last)
                {
                    // We are in tuple type declaration.
                    tupleVariables = this.ReadRemainingTupleVariables(expressionReference, firstExpression, unsafeCode);
                }
                else
                {
                    this.CreateSyntaxException();
                }

                // Get the closing parenthesis.
                closeParenthesis = this.GetBracketToken(CsTokenType.CloseParenthesis, SymbolType.CloseParenthesis, expressionReference);
                closeParenthesisNode = this.tokens.InsertLast(closeParenthesis);

                // Create the token list for the expression.
                partialTokens = new CsTokenList(this.tokens, openParenthesisNode, this.tokens.Last);

                // Create the expression.
                if (tupleArguments != null)
                {
                    resultExpression = new TupleExpression(partialTokens, tupleArguments.ToArray());
                }
                else
                {
                    resultExpression = new TupleExpression(partialTokens, tupleVariables);
                }
            }

            // Link the opening and closing parenthesis and return the expression.
            openParenthesis.MatchingBracketNode = closeParenthesisNode;
            closeParenthesis.MatchingBracketNode = openParenthesisNode;

            expressionReference.Target = resultExpression;
            return resultExpression;
        }

        private List<Argument> ReadRemainingTupleArguments(Reference<ICodePart> expressionReference, Argument firstArgument, bool unsafeCode)
        {
            // Get the remaining list of arguments.
            IList<Argument> argumentsList = this.GetArgumentList(SymbolType.CloseParenthesis, expressionReference, unsafeCode);

            // Prepare a new list that includes our first argument.
            List<Argument> tupleLiteralArguments = new List<Argument> { firstArgument };
            tupleLiteralArguments.AddRange(argumentsList);

            // Should have more than one argument.
            if (tupleLiteralArguments.Count == 1)
            {
                this.CreateSyntaxException();
            }

            return tupleLiteralArguments;
        }

        private List<VariableDeclarationExpression> ReadRemainingTupleVariables(Reference<ICodePart> expressionReference, Expression firstVariableType, bool unsafeCode)
        {
            List<VariableDeclarationExpression> result = new List<VariableDeclarationExpression>();
            
            // Add the first variable
            result.Add(this.GetSingleVariableDeclarationExpression(firstVariableType, ExpressionPrecedence.None, unsafeCode));

            // Read the comma.
            Symbol symbol = this.GetNextSymbol(SkipSymbols.All, expressionReference, false);
            this.tokens.Add(this.GetToken(CsTokenType.Comma, SymbolType.Comma, expressionReference));

            while (symbol.SymbolType != SymbolType.CloseParenthesis)
            {
                Expression variableType;

                // Get the variable type and declaration.
                variableType = this.GetNextExpression(ExpressionPrecedence.None, expressionReference, unsafeCode);
                result.Add(this.GetSingleVariableDeclarationExpression(variableType, ExpressionPrecedence.None, unsafeCode));

                // Now check if the next character is a comma. If so there is another variable declared.
                symbol = this.GetNextSymbol(SkipSymbols.All, expressionReference, false);

                // Break if there are no more declarations.
                if (symbol.SymbolType != SymbolType.Comma)
                {
                    break;
                }

                // Add the comma and continue reading the next declaration.
                this.tokens.Add(this.GetToken(CsTokenType.Comma, SymbolType.Comma, expressionReference));
            }

            return result;
        }

        /// <summary>
        /// Reads tuple type expression.
        /// </summary>
        /// <param name="unsafeCode">
        /// Indicates whether the code being parsed resides in an unsafe code block.
        /// </param>
        /// <param name="isVar">Indicates if this expression is preceded by a <c>var</c> keyword.</param>
        /// <returns>
        /// Returns a TupleExpression or ParenthesizedExpression.
        /// </returns>
        private TupleExpression GetTupleTypeDeclarationExpression(bool unsafeCode, bool isVar)
        {
            //// Note: What we do here is slightly different from roslyn syntax tree.
            //// (string fname, string lname) = person is read as, TupleExpression with arguments that are declaration expressions
            //// var (fname, lname) = person is read as, declaration exrpression with parenthesized variable designation.
            //// For our purposes we read both as TupleExpression with variable declaration so we can apply naming rules over them.

            Reference<ICodePart> expressionReference = new Reference<ICodePart>();
            Expression varExpression = null;

            if (isVar)
            {
                varExpression = this.GetLiteralExpression(expressionReference, unsafeCode);
            }

            // Get the opening parenthesis.
            Bracket openParenthesis = this.GetBracketToken(CsTokenType.OpenParenthesis, SymbolType.OpenParenthesis, expressionReference);
            Node<CsToken> openParenthesisNode = this.tokens.InsertLast(openParenthesis);

            // Get the list of arguments.
            List<VariableDeclarationExpression> variables = new List<VariableDeclarationExpression>();

            Symbol symbol = this.GetNextSymbol(expressionReference);

            while (symbol.SymbolType != SymbolType.CloseParenthesis)
            {
                Expression variableType;
                if (isVar)
                {
                    // Keep using the var expression for every variable declaration.
                    variableType = varExpression;
                }
                else
                {
                    // Get the variable type and declaration.
                    variableType = this.GetNextExpression(ExpressionPrecedence.None, expressionReference, unsafeCode);
                }

                variables.Add(this.GetSingleVariableDeclarationExpression(variableType, ExpressionPrecedence.None, unsafeCode));

                // Now check if the next character is a comma. If so there is another variable declared.
                symbol = this.GetNextSymbol(expressionReference);

                // Break if there are no more declarations.
                if (symbol.SymbolType != SymbolType.Comma)
                {
                    break;
                }

                // Add the comma and continue reading the next declaration.
                this.tokens.Add(this.GetToken(CsTokenType.Comma, SymbolType.Comma, expressionReference));
            }

            // Get the closing parenthesis.
            Bracket closeParenthesis = this.GetBracketToken(CsTokenType.CloseParenthesis, SymbolType.CloseParenthesis, expressionReference);
            Node<CsToken> closeParenthesisNode = this.tokens.InsertLast(closeParenthesis);

            // Create the token list for the expression.
            CsTokenList partialTokens = new CsTokenList(this.tokens, openParenthesisNode, this.tokens.Last);

            // Create the expression.
            TupleExpression resultExpression = new TupleExpression(partialTokens, variables);

            // Link the opening and closing parenthesis and return the expression.
            openParenthesis.MatchingBracketNode = closeParenthesisNode;
            closeParenthesis.MatchingBracketNode = openParenthesisNode;

            expressionReference.Target = resultExpression;
            return resultExpression;
        }

        /// <summary>
        /// Reads a primary decrement expression.
        /// </summary>
        /// <param name="leftHandSide">
        /// The expression on the left hand side of the operator.
        /// </param>
        /// <param name="previousPrecedence">
        /// The precedence of the expression just before this one.
        /// </param>
        /// <returns>
        /// Returns the expression.
        /// </returns>
        private DecrementExpression GetPrimaryDecrementExpression(Expression leftHandSide, ExpressionPrecedence previousPrecedence)
        {
            Param.AssertNotNull(leftHandSide, "leftHandSide");
            Param.Ignore(previousPrecedence);

            DecrementExpression expression = null;

            // Check the previous precedence to see if we are allowed to gather up the as expression.
            if (CheckPrecedence(previousPrecedence, ExpressionPrecedence.Primary))
            {
                Reference<ICodePart> expressionReference = new Reference<ICodePart>();

                // Make sure the left hand side has at least one token.
                Debug.Assert(leftHandSide.Tokens.First != null, "The left hand side should not be empty");

                // Get the decrement symbol.
                this.tokens.Add(this.GetOperatorToken(OperatorType.Decrement, expressionReference));

                // Create the partial token list for the expression.
                CsTokenList partialTokens = new CsTokenList(this.tokens, leftHandSide.Tokens.First, this.tokens.Last);

                // Create and return the expression.
                expression = new DecrementExpression(partialTokens, leftHandSide, DecrementExpression.DecrementType.Postfix);
                expressionReference.Target = expression;
            }

            return expression;
        }

        /// <summary>
        /// Reads a primary increment expression.
        /// </summary>
        /// <param name="leftHandSide">
        /// The expression on the left hand side of the operator.
        /// </param>
        /// <param name="previousPrecedence">
        /// The precedence of the expression just before this one.
        /// </param>
        /// <returns>
        /// Returns the expression.
        /// </returns>
        private IncrementExpression GetPrimaryIncrementExpression(Expression leftHandSide, ExpressionPrecedence previousPrecedence)
        {
            Param.AssertNotNull(leftHandSide, "leftHandSide");
            Param.Ignore(previousPrecedence);

            IncrementExpression expression = null;

            // Check the previous precedence to see if we are allowed to gather up the as expression.
            if (CheckPrecedence(previousPrecedence, ExpressionPrecedence.Primary))
            {
                Reference<ICodePart> expressionReference = new Reference<ICodePart>();

                // Make sure the left hand side has at least one token.
                Debug.Assert(leftHandSide.Tokens.First != null, "The left hand side should not be empty.");

                // Get the increment symbol.
                this.tokens.Add(this.GetOperatorToken(OperatorType.Increment, expressionReference));

                // Create the partial token list for the expression.
                CsTokenList partialTokens = new CsTokenList(this.tokens, leftHandSide.Tokens.First, this.tokens.Last);

                // Create and return the expression.
                expression = new IncrementExpression(partialTokens, leftHandSide, IncrementExpression.IncrementType.Postfix);
                expressionReference.Target = expression;
            }

            return expression;
        }

        /// <summary>
        /// Gets a query continuation clause.
        /// </summary>
        /// <param name="parentReference">
        /// The parent code unit.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code being parsed resides 
        /// in an unsafe code block.
        /// </param>
        /// <returns>
        /// Returns the query continuation clause.
        /// </returns>
        private QueryContinuationClause GetQueryContinuationClause(Reference<ICodePart> parentReference, bool unsafeCode)
        {
            Param.AssertNotNull(parentReference, "parentReference");
            Param.Ignore(unsafeCode);

            // Get and add the 'into' symbol.
            Symbol symbol = this.GetNextSymbol(SymbolType.Other, parentReference);
            Debug.Assert(symbol.Text == "into", "Expected an into keyword");

            Reference<ICodePart> clauseReference = new Reference<ICodePart>();

            Node<CsToken> firstTokenNode = this.tokens.InsertLast(this.GetToken(CsTokenType.Into, SymbolType.Other, clauseReference));

            // Get the identifier.
            Variable rangeVariable = this.GetVariable(clauseReference, unsafeCode, true, true);
            if (rangeVariable == null)
            {
                throw this.CreateSyntaxException();
            }

            // Get the continuation clauses.
            List<QueryClause> clauses = new List<QueryClause>();

            // The variables defined by the clauses under this continuation clause.
            List<Variable> variables = new List<Variable>();

            // Extract the clauses.
            CsTokenList continuationClauseTokens = this.GetQueryExpressionClauses(clauseReference, unsafeCode, clauses, variables);
            if (clauses.Count == 0 || continuationClauseTokens.First == null)
            {
                throw this.CreateSyntaxException();
            }

            // Create and return the clause.
            QueryContinuationClause continuationClause = new QueryContinuationClause(
                new CsTokenList(this.tokens, firstTokenNode, continuationClauseTokens.Last), rangeVariable, clauses.ToArray());

            clauseReference.Target = continuationClause;
            continuationClause.Variables.AddRange(variables);

            return continuationClause;
        }

        /// <summary>
        /// Reads a query expression.
        /// </summary>
        /// <param name="parentReference">
        /// The parent code unit.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code being parsed resides 
        /// in an unsafe code block.
        /// </param>
        /// <returns>
        /// Returns the expression.
        /// </returns>
        private QueryExpression GetQueryExpression(Reference<ICodePart> parentReference, bool unsafeCode)
        {
            Param.AssertNotNull(parentReference, "parentReference");
            Param.Ignore(unsafeCode);

            // Ensure that the expression starts with the keyword 'from'.
            Symbol symbol = this.GetNextSymbol(parentReference);

            Debug.Assert(symbol != null && symbol.SymbolType == SymbolType.Other && string.CompareOrdinal(symbol.Text, "from") == 0, "Expected a from keyword");

            Reference<ICodePart> expressionReference = new Reference<ICodePart>();

            // Stores the list of clauses in the expression.
            List<QueryClause> clauses = new List<QueryClause>();

            // The variables defined by the clauses in this expression.
            List<Variable> variables = new List<Variable>();

            // Extract the clauses.
            CsTokenList clauseTokens = this.GetQueryExpressionClauses(expressionReference, unsafeCode, clauses, variables);
            if (clauses.Count == 0 || clauseTokens.First == null)
            {
                throw this.CreateSyntaxException();
            }

            // Create and return the expression.
            QueryExpression queryExpression = new QueryExpression(clauseTokens, clauses.ToArray());
            expressionReference.Target = queryExpression;
            queryExpression.Variables.AddRange(variables);

            return queryExpression;
        }

        /// <summary>
        /// Gets the collection of query clauses.
        /// </summary>
        /// <param name="parentReference">
        /// The parent code unit.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code being parsed resides 
        /// in an unsafe code block.
        /// </param>
        /// <param name="clauses">
        /// The list in which to store the clauses.
        /// </param>
        /// <param name="variables">
        /// The list in which to store variables defined by the clauses.
        /// </param>
        /// <returns>
        /// Returns the list of this.tokens that make up the clauses.
        /// </returns>
        private CsTokenList GetQueryExpressionClauses(Reference<ICodePart> parentReference, bool unsafeCode, List<QueryClause> clauses, List<Variable> variables)
        {
            Param.AssertNotNull(parentReference, "parentReference");
            Param.Ignore(unsafeCode);
            Param.AssertNotNull(clauses, "clauses");
            Param.AssertNotNull(variables, "variables");

            Node<CsToken> firstToken = null;

            while (true)
            {
                // Get the rest of the clauses.
                Symbol symbol = this.GetNextSymbol(parentReference);
                if (symbol.SymbolType != SymbolType.Other)
                {
                    break;
                }

                QueryClause clause = null;

                switch (symbol.Text)
                {
                    case "from":
                        QueryFromClause fromClause = this.GetQueryFromClause(parentReference, unsafeCode);
                        variables.Add(fromClause.RangeVariable);
                        clause = fromClause;
                        break;

                    case "let":
                        QueryLetClause letClause = this.GetQueryLetClause(parentReference, unsafeCode);
                        variables.Add(letClause.RangeVariable);
                        clause = letClause;
                        break;

                    case "where":
                        clause = this.GetQueryWhereClause(parentReference, unsafeCode);
                        break;

                    case "join":
                        QueryJoinClause joinClause = this.GetQueryJoinClause(parentReference, unsafeCode);
                        variables.Add(joinClause.RangeVariable);

                        if (joinClause.IntoVariable != null)
                        {
                            variables.Add(joinClause.IntoVariable);
                        }

                        clause = joinClause;
                        break;

                    case "orderby":
                        clause = this.GetQueryOrderByClause(parentReference, unsafeCode);
                        break;

                    case "select":
                        clause = this.GetQuerySelectClause(parentReference, unsafeCode);
                        break;

                    case "group":
                        clause = this.GetQueryGroupClause(parentReference, unsafeCode);
                        break;

                    case "into":
                        QueryContinuationClause continuationClause = this.GetQueryContinuationClause(parentReference, unsafeCode);
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
        /// Gets a query from clause.
        /// </summary>
        /// <param name="parentReference">
        /// The parent code unit.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code being parsed resides 
        /// in an unsafe code block.
        /// </param>
        /// <returns>
        /// Returns the query from clause.
        /// </returns>
        private QueryFromClause GetQueryFromClause(Reference<ICodePart> parentReference, bool unsafeCode)
        {
            Param.AssertNotNull(parentReference, "parentReference");
            Param.Ignore(unsafeCode);

            // Get and add the 'from' symbol.
            Symbol symbol = this.GetNextSymbol(SymbolType.Other, parentReference);
            Debug.Assert(symbol.Text == "from", "Expected a from keyword");

            Reference<ICodePart> clauseReference = new Reference<ICodePart>();

            Node<CsToken> firstTokenNode = this.tokens.InsertLast(this.GetToken(CsTokenType.From, SymbolType.Other, clauseReference));

            // Get the range variable.
            Variable rangeVariable = this.GetVariable(clauseReference, unsafeCode, true, false);
            if (rangeVariable == null)
            {
                throw this.CreateSyntaxException();
            }

            // The next symbol must be the 'in' keyword.
            this.tokens.Add(this.GetToken(CsTokenType.In, SymbolType.In, clauseReference));

            // Now get the from clause expression.
            Expression fromClauseExpression = this.GetNextExpression(ExpressionPrecedence.Query, clauseReference, unsafeCode);
            if (fromClauseExpression == null)
            {
                throw this.CreateSyntaxException();
            }

            // Create and return the clause.
            QueryFromClause queryFromClause = new QueryFromClause(new CsTokenList(this.tokens, firstTokenNode, this.tokens.Last), rangeVariable, fromClauseExpression);

            clauseReference.Target = queryFromClause;
            return queryFromClause;
        }

        /// <summary>
        /// Gets a query group clause.
        /// </summary>
        /// <param name="parentReference">
        /// The parent code unit.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code being parsed resides 
        /// in an unsafe code block.
        /// </param>
        /// <returns>
        /// Returns the query group clause.
        /// </returns>
        private QueryGroupClause GetQueryGroupClause(Reference<ICodePart> parentReference, bool unsafeCode)
        {
            Param.AssertNotNull(parentReference, "parentReference");
            Param.Ignore(unsafeCode);

            // Get and add the 'group' symbol.
            Symbol symbol = this.GetNextSymbol(SymbolType.Other, parentReference);
            Debug.Assert(symbol.Text == "group", "Expected a group keyword.");

            Reference<ICodePart> clauseReference = new Reference<ICodePart>();
            Node<CsToken> firstTokenNode = this.tokens.InsertLast(this.GetToken(CsTokenType.Group, SymbolType.Other, clauseReference));

            // Get the group expression.
            Expression groupExpression = this.GetNextExpression(ExpressionPrecedence.Query, clauseReference, unsafeCode);
            if (groupExpression == null)
            {
                throw this.CreateSyntaxException();
            }

            // The next symbol must be the 'by' keyword.
            symbol = this.GetNextSymbol(SymbolType.Other, clauseReference);
            if (symbol.Text != "by")
            {
                throw this.CreateSyntaxException();
            }

            this.tokens.Add(this.GetToken(CsTokenType.By, SymbolType.Other, clauseReference));

            // Now get the by expression.
            Expression groupByExpression = this.GetNextExpression(ExpressionPrecedence.Query, clauseReference, unsafeCode);
            if (groupByExpression == null)
            {
                throw this.CreateSyntaxException();
            }

            // Create and return the clause.
            QueryGroupClause clause = new QueryGroupClause(new CsTokenList(this.tokens, firstTokenNode, this.tokens.Last), groupExpression, groupByExpression);

            clauseReference.Target = clause;
            return clause;
        }

        /// <summary>
        /// Gets a query join clause.
        /// </summary>
        /// <param name="parentReference">
        /// The parent code unit.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code being parsed resides 
        /// in an unsafe code block.
        /// </param>
        /// <returns>
        /// Returns the query from clause.
        /// </returns>
        private QueryJoinClause GetQueryJoinClause(Reference<ICodePart> parentReference, bool unsafeCode)
        {
            Param.AssertNotNull(parentReference, "parentReference");
            Param.Ignore(unsafeCode);

            // Get and add the 'from' symbol.
            Symbol symbol = this.GetNextSymbol(SymbolType.Other, parentReference);
            Debug.Assert(symbol.Text == "join", "Expected a join keyword");

            Reference<ICodePart> clauseReference = new Reference<ICodePart>();
            Node<CsToken> firstTokenNode = this.tokens.InsertLast(this.GetToken(CsTokenType.Join, SymbolType.Other, clauseReference));

            // Get the variable.
            Variable variable = this.GetVariable(clauseReference, unsafeCode, true, false);
            if (variable == null)
            {
                throw this.CreateSyntaxException();
            }

            // The next symbol must be the 'in' keyword.
            this.tokens.Add(this.GetToken(CsTokenType.In, SymbolType.In, clauseReference));

            // Now get the in expression.
            Expression inExpression = this.GetNextExpression(ExpressionPrecedence.Query, clauseReference, unsafeCode);
            if (inExpression == null)
            {
                throw this.CreateSyntaxException();
            }

            // The next symbol must be the 'on' keyword.
            CsToken token = this.GetToken(CsTokenType.On, SymbolType.Other, clauseReference);
            if (token.Text != "on")
            {
                throw this.CreateSyntaxException();
            }

            this.tokens.Add(token);

            // Now get the on expression.
            Expression onKeyExpression = this.GetNextExpression(ExpressionPrecedence.Query, clauseReference, unsafeCode);
            if (onKeyExpression == null)
            {
                throw this.CreateSyntaxException();
            }

            // The next symbol must be the 'equals' keyword.
            token = this.GetToken(CsTokenType.Equals, SymbolType.Other, clauseReference);
            if (token.Text != "equals")
            {
                throw this.CreateSyntaxException();
            }

            this.tokens.Add(token);

            // Now get the equals expression.
            Expression equalsKeyExpression = this.GetNextExpression(ExpressionPrecedence.Query, clauseReference, unsafeCode);
            if (equalsKeyExpression == null)
            {
                throw this.CreateSyntaxException();
            }

            // Get the optional 'into' variable if it exists.
            Variable intoVariable = null;

            symbol = this.GetNextSymbol(clauseReference);
            if (symbol.SymbolType == SymbolType.Other && symbol.Text == "into")
            {
                this.tokens.Add(this.GetToken(CsTokenType.Into, SymbolType.Other, clauseReference));
                intoVariable = this.GetVariable(clauseReference, unsafeCode, true, true);
            }

            // Create and return the clause.
            QueryJoinClause clause = new QueryJoinClause(
                new CsTokenList(this.tokens, firstTokenNode, this.tokens.Last), variable, inExpression, onKeyExpression, equalsKeyExpression, intoVariable);

            clauseReference.Target = clause;
            return clause;
        }

        /// <summary>
        /// Gets a query let clause.
        /// </summary>
        /// <param name="parentReference">
        /// The parent code unit.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code being parsed resides 
        /// in an unsafe code block.
        /// </param>
        /// <returns>
        /// Returns the query let clause.
        /// </returns>
        private QueryLetClause GetQueryLetClause(Reference<ICodePart> parentReference, bool unsafeCode)
        {
            Param.AssertNotNull(parentReference, "parentReference");
            Param.Ignore(unsafeCode);

            // Get and add the 'let' symbol.
            Symbol symbol = this.GetNextSymbol(SymbolType.Other, parentReference);
            Debug.Assert(symbol.Text == "let", "Expected a let keyword");

            Reference<ICodePart> clauseReference = new Reference<ICodePart>();

            Node<CsToken> firstTokenNode = this.tokens.InsertLast(this.GetToken(CsTokenType.Let, SymbolType.Other, clauseReference));

            // Get the identifier.
            Variable rangeVariable = this.GetVariable(clauseReference, unsafeCode, true, true);
            if (rangeVariable == null)
            {
                throw this.CreateSyntaxException();
            }

            // The next symbol must be the = sign.
            this.tokens.Add(this.GetOperatorToken(OperatorType.Equals, clauseReference));

            // Now get the let clause expression.
            Expression letClauseExpression = this.GetNextExpression(ExpressionPrecedence.Query, clauseReference, unsafeCode);
            if (letClauseExpression == null)
            {
                throw this.CreateSyntaxException();
            }

            // Create and return the clause.
            QueryLetClause clause = new QueryLetClause(new CsTokenList(this.tokens, firstTokenNode, this.tokens.Last), rangeVariable, letClauseExpression);

            clauseReference.Target = clause;
            return clause;
        }

        /// <summary>
        /// Gets a query order-by clause.
        /// </summary>
        /// <param name="parentReference">
        /// The parent code unit.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code being parsed resides 
        /// in an unsafe code block.
        /// </param>
        /// <returns>
        /// Returns the query order-by clause.
        /// </returns>
        private QueryOrderByClause GetQueryOrderByClause(Reference<ICodePart> parentReference, bool unsafeCode)
        {
            Param.AssertNotNull(parentReference, "parentReference");
            Param.Ignore(unsafeCode);

            // Get and add the 'orderby' symbol.
            Symbol symbol = this.GetNextSymbol(SymbolType.Other, parentReference);
            Debug.Assert(symbol.Text == "orderby", "Expected an orderby keyword");

            Reference<ICodePart> clauseReference = new Reference<ICodePart>();
            Node<CsToken> firstTokenNode = this.tokens.InsertLast(this.GetToken(CsTokenType.OrderBy, SymbolType.Other, clauseReference));

            // Get each of the orderings in the clause.
            List<QueryOrderByOrdering> orderings = new List<QueryOrderByOrdering>();

            while (true)
            {
                QueryOrderByOrdering ordering = new QueryOrderByOrdering();

                // Get the ordering expression.
                ordering.Expression = this.GetNextExpression(ExpressionPrecedence.Query, clauseReference, unsafeCode);
                if (ordering.Expression == null)
                {
                    throw this.CreateSyntaxException();
                }

                // Get the order direction if it exists.
                symbol = this.GetNextSymbol(clauseReference);

                ordering.Direction = QueryOrderByDirection.Undefined;

                if (symbol.Text == "ascending")
                {
                    ordering.Direction = QueryOrderByDirection.Ascending;
                    this.tokens.Add(this.GetToken(CsTokenType.Ascending, SymbolType.Other, clauseReference));
                }
                else if (symbol.Text == "descending")
                {
                    ordering.Direction = QueryOrderByDirection.Descending;
                    this.tokens.Add(this.GetToken(CsTokenType.Descending, SymbolType.Other, clauseReference));
                }

                // Add the ordering to the list.
                orderings.Add(ordering);

                // If the next symbol is a comma, then we should continue and get the next ordering expression.
                symbol = this.GetNextSymbol(clauseReference);

                if (symbol.SymbolType == SymbolType.Comma)
                {
                    this.tokens.Add(this.GetToken(CsTokenType.Comma, SymbolType.Comma, clauseReference));
                }
                else
                {
                    // This was the last ordering expression.
                    break;
                }
            }

            // Create and return the clause.
            QueryOrderByClause clause = new QueryOrderByClause(new CsTokenList(this.tokens, firstTokenNode, this.tokens.Last), orderings);
            clauseReference.Target = clause;

            return clause;
        }

        /// <summary>
        /// Gets a query select clause.
        /// </summary>
        /// <param name="parentReference">
        /// The parent code unit.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code being parsed resides 
        /// in an unsafe code block.
        /// </param>
        /// <returns>
        /// Returns the query select clause.
        /// </returns>
        private QuerySelectClause GetQuerySelectClause(Reference<ICodePart> parentReference, bool unsafeCode)
        {
            Param.AssertNotNull(parentReference, "parentReference");
            Param.Ignore(unsafeCode);

            // Get and add the 'select' symbol.
            Symbol symbol = this.GetNextSymbol(SymbolType.Other, parentReference);
            Debug.Assert(symbol.Text == "select", "Expected a select keyword");

            Reference<ICodePart> clauseReference = new Reference<ICodePart>();
            Node<CsToken> firstTokenNode = this.tokens.InsertLast(this.GetToken(CsTokenType.Select, SymbolType.Other, clauseReference));

            // Get the select expression.
            Expression selectClauseExpression = this.GetNextExpression(ExpressionPrecedence.Query, clauseReference, unsafeCode);
            if (selectClauseExpression == null)
            {
                throw this.CreateSyntaxException();
            }

            // Create and return the clause.
            QuerySelectClause clause = new QuerySelectClause(new CsTokenList(this.tokens, firstTokenNode, this.tokens.Last), selectClauseExpression);
            clauseReference.Target = clause;
            return clause;
        }

        /// <summary>
        /// Gets a query where clause.
        /// </summary>
        /// <param name="parentReference">
        /// The parent code unit.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code being parsed resides 
        /// in an unsafe code block.
        /// </param>
        /// <returns>
        /// Returns the query where clause.
        /// </returns>
        private QueryWhereClause GetQueryWhereClause(Reference<ICodePart> parentReference, bool unsafeCode)
        {
            Param.AssertNotNull(parentReference, "parentReference");
            Param.Ignore(unsafeCode);

            // Get and add the 'where' symbol.
            Symbol symbol = this.GetNextSymbol(SymbolType.Other, parentReference);
            Debug.Assert(symbol.Text == "where", "Expected a where keyword");

            Reference<ICodePart> clauseReference = new Reference<ICodePart>();

            Node<CsToken> firstTokenNode = this.tokens.InsertLast(this.GetToken(CsTokenType.Where, SymbolType.Other, clauseReference));

            // Get the where expression.
            Expression whereClauseExpression = this.GetNextExpression(ExpressionPrecedence.Query, clauseReference, unsafeCode);
            if (whereClauseExpression == null)
            {
                throw this.CreateSyntaxException();
            }

            // Create and return the clause.
            QueryWhereClause clause = new QueryWhereClause(new CsTokenList(this.tokens, firstTokenNode, this.tokens.Last), whereClauseExpression);

            clauseReference.Target = clause;
            return clause;
        }

        /// <summary>
        /// Reads a relational expression.
        /// </summary>
        /// <param name="leftHandSide">
        /// The expression on the left hand side of the operator.
        /// </param>
        /// <param name="previousPrecedence">
        /// The precedence of the expression just before this one.
        /// </param>
        /// <param name="parentReference">
        /// The parent code part.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code being parsed resides in an unsafe code block.
        /// </param>
        /// <returns>
        /// Returns the expression.
        /// </returns>
        private RelationalExpression GetRelationalExpression(
            Expression leftHandSide, ExpressionPrecedence previousPrecedence, Reference<ICodePart> parentReference, bool unsafeCode)
        {
            Param.AssertNotNull(leftHandSide, "leftHandSide");
            Param.Ignore(previousPrecedence);
            Param.AssertNotNull(parentReference, "parentReference");
            Param.Ignore(unsafeCode);

            RelationalExpression expression = null;
            Reference<ICodePart> expressionReference = new Reference<ICodePart>();

            // Read the details of the expression.
            OperatorSymbol operatorToken = this.PeekOperatorToken(parentReference, expressionReference);
            Debug.Assert(operatorToken.Category == OperatorCategory.Relational, "Expected a relational operator");

            // Check the precedence of the operators to make sure we can gather this statement now.
            ExpressionPrecedence precedence = GetOperatorPrecedence(operatorToken.SymbolType);
            if (CheckPrecedence(previousPrecedence, precedence))
            {
                // Add the operator token to the document and advance the symbol manager up to it.
                this.symbols.Advance();
                this.tokens.Add(operatorToken);

                // Get the expression on the right-hand side of the operator.
                Expression rightHandSide = this.GetOperatorRightHandExpression(precedence, expressionReference, unsafeCode);

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
                expressionReference.Target = expression;
            }

            return expression;
        }

        /// <summary>
        /// Reads a sizeof expression from the code.
        /// </summary>
        /// <param name="parentReference">
        /// The parent code unit.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code being parsed resides in an unsafe code block.
        /// </param>
        /// <returns>
        /// Returns the expression.
        /// </returns>
        private SizeofExpression GetSizeofExpression(Reference<ICodePart> parentReference, bool unsafeCode)
        {
            Param.AssertNotNull(parentReference, "parentReference");
            Param.Ignore(unsafeCode);

            Reference<ICodePart> expressionReference = new Reference<ICodePart>();

            // Get the sizeof keyword.
            Node<CsToken> firstTokenNode = this.tokens.InsertLast(this.GetToken(CsTokenType.Sizeof, SymbolType.Sizeof, parentReference, expressionReference));

            // The next symbol will be the opening parenthesis.
            Bracket openParenthesis = this.GetBracketToken(CsTokenType.OpenParenthesis, SymbolType.OpenParenthesis, expressionReference);
            Node<CsToken> openParenthesisNode = this.tokens.InsertLast(openParenthesis);

            // Get the inner expression representing the type.
            Expression typeTokenExpression = this.GetTypeTokenExpression(expressionReference, unsafeCode, true);
            if (typeTokenExpression == null)
            {
                throw this.CreateSyntaxException();
            }

            // Get the closing parenthesis.
            Bracket closeParenthesis = this.GetBracketToken(CsTokenType.CloseParenthesis, SymbolType.CloseParenthesis, expressionReference);
            Node<CsToken> closeParenthesisNode = this.tokens.InsertLast(closeParenthesis);

            openParenthesis.MatchingBracketNode = closeParenthesisNode;
            closeParenthesis.MatchingBracketNode = openParenthesisNode;

            // Create the token list for the method invocation expression.
            CsTokenList partialTokens = new CsTokenList(this.tokens, firstTokenNode, this.tokens.Last);

            // Create and return the expression.
            SizeofExpression expression = new SizeofExpression(partialTokens, typeTokenExpression);
            expressionReference.Target = expression;

            return expression;
        }

        /// <summary>
        /// Reads a stackalloc expression from the code.
        /// </summary>
        /// <param name="parentReference">
        /// The parent code unit.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code being parsed resides in an unsafe code block.
        /// </param>
        /// <returns>
        /// Returns the expression.
        /// </returns>
        private StackallocExpression GetStackallocExpression(Reference<ICodePart> parentReference, bool unsafeCode)
        {
            Param.AssertNotNull(parentReference, "parentReference");
            Param.Ignore(unsafeCode);

            Reference<ICodePart> expressionReference = new Reference<ICodePart>();

            // The first symbol must be the new keyword.
            Node<CsToken> firstTokenNode = this.tokens.InsertLast(this.GetToken(CsTokenType.Stackalloc, SymbolType.Stackalloc, parentReference, expressionReference));

            // The next token must be the type identifier.
            this.GetNextSymbol(SymbolType.Other, expressionReference);

            // Get the type expression.
            Expression type = this.GetTypeTokenExpression(expressionReference, unsafeCode, false);
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
            StackallocExpression expression = new StackallocExpression(partialTokens, arrayAccess);
            expressionReference.Target = expression;

            return expression;
        }

        /// <summary>
        /// Reads a typeof expression from the code.
        /// </summary>
        /// <param name="parentReference">
        /// The parent code unit.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code being parsed resides in an unsafe code block.
        /// </param>
        /// <returns>
        /// Returns the expression.
        /// </returns>
        private TypeofExpression GetTypeofExpression(Reference<ICodePart> parentReference, bool unsafeCode)
        {
            Param.AssertNotNull(parentReference, "parentReference");
            Param.Ignore(unsafeCode);

            Reference<ICodePart> expressionReference = new Reference<ICodePart>();

            // Get the typeof keyword.
            Node<CsToken> firstTokenNode = this.tokens.InsertLast(this.GetToken(CsTokenType.Typeof, SymbolType.Typeof, parentReference, expressionReference));

            // The next symbol will be the opening parenthesis.
            Bracket openParenthesis = this.GetBracketToken(CsTokenType.OpenParenthesis, SymbolType.OpenParenthesis, expressionReference);
            Node<CsToken> openParenthesisNode = this.tokens.InsertLast(openParenthesis);

            // Get the inner expression representing the type.
            LiteralExpression typeTokenExpression = this.GetTypeTokenExpression(expressionReference, unsafeCode, true);
            if (typeTokenExpression == null)
            {
                throw this.CreateSyntaxException();
            }

            // Get the closing parenthesis.
            Bracket closeParenthesis = this.GetBracketToken(CsTokenType.CloseParenthesis, SymbolType.CloseParenthesis, expressionReference);
            Node<CsToken> closeParenthesisNode = this.tokens.InsertLast(closeParenthesis);

            openParenthesis.MatchingBracketNode = closeParenthesisNode;
            closeParenthesis.MatchingBracketNode = openParenthesisNode;

            // Create the token list for the method invocation expression.
            CsTokenList partialTokens = new CsTokenList(this.tokens, firstTokenNode, this.tokens.Last);

            // Create and return the expression.
            TypeofExpression expression = new TypeofExpression(partialTokens, typeTokenExpression);
            expressionReference.Target = expression;

            return expression;
        }

        /// <summary>
        /// Reads a nameof expression from the code.
        /// </summary>
        /// <param name="parentReference">
        /// The parent code unit.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code being parsed resides in an unsafe code block.
        /// </param>
        /// <returns>
        /// Returns the expression.
        /// </returns>
        private NameofExpression GetNameofExpression(Reference<ICodePart> parentReference, bool unsafeCode)
        {
            Param.AssertNotNull(parentReference, "parentReference");
            Param.Ignore(unsafeCode);

            Reference<ICodePart> expressionReference = new Reference<ICodePart>();

            // Get the nameof keyword.
            Node<CsToken> firstTokenNode = this.tokens.InsertLast(this.GetToken(CsTokenType.Nameof, SymbolType.NameOf, parentReference, expressionReference));

            // The next symbol will be the opening parenthesis.
            Bracket openParenthesis = this.GetBracketToken(CsTokenType.OpenParenthesis, SymbolType.OpenParenthesis, expressionReference);
            Node<CsToken> openParenthesisNode = this.tokens.InsertLast(openParenthesis);

            // Get the inner expression representing the name.
            Expression innerExpression = this.GetNextExpression(ExpressionPrecedence.None, expressionReference, unsafeCode) as Expression;
            if (innerExpression == null)
            {
                throw this.CreateSyntaxException();
            }

            // Get the closing parenthesis.
            Bracket closeParenthesis = this.GetBracketToken(CsTokenType.CloseParenthesis, SymbolType.CloseParenthesis, expressionReference);
            Node<CsToken> closeParenthesisNode = this.tokens.InsertLast(closeParenthesis);

            openParenthesis.MatchingBracketNode = closeParenthesisNode;
            closeParenthesis.MatchingBracketNode = openParenthesisNode;

            // Create the token list for the method invocation expression.
            CsTokenList partialTokens = new CsTokenList(this.tokens, firstTokenNode, this.tokens.Last);

            // Create and return the expression.
            NameofExpression expression = new NameofExpression(partialTokens, innerExpression);
            expressionReference.Target = expression;

            return expression;
        }

        /// <summary>
        /// Reads a unary decrement expression.
        /// </summary>
        /// <param name="unsafeCode">
        /// Indicates whether the code being parsed resides in an unsafe code block.
        /// </param>
        /// <returns>
        /// Returns the expression.
        /// </returns>
        private DecrementExpression GetUnaryDecrementExpression(bool unsafeCode)
        {
            Param.Ignore(unsafeCode);

            Reference<ICodePart> expressionReference = new Reference<ICodePart>();

            // Get the decrement symbol.
            Node<CsToken> tokenNode = this.tokens.InsertLast(this.GetOperatorToken(OperatorType.Decrement, expressionReference));

            // Get the expression being decremented.
            Expression valueExpression = this.GetNextExpression(ExpressionPrecedence.Unary, expressionReference, unsafeCode);
            if (valueExpression == null || valueExpression.Tokens.First == null)
            {
                throw this.CreateSyntaxException();
            }

            // Create the partial token list for the expression.
            CsTokenList partialTokens = new CsTokenList(this.tokens, tokenNode, this.tokens.Last);

            // Create and return the expression.
            DecrementExpression expression = new DecrementExpression(partialTokens, valueExpression, DecrementExpression.DecrementType.Prefix);
            expressionReference.Target = expression;

            return expression;
        }

        /// <summary>
        /// Reads a unary expression.
        /// </summary>
        /// <param name="parentReference">
        /// The parent code part.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code being parsed resides in an unsafe code block.
        /// </param>
        /// <returns>
        /// Returns the expression.
        /// </returns>
        private UnaryExpression GetUnaryExpression(Reference<ICodePart> parentReference, bool unsafeCode)
        {
            Param.AssertNotNull(parentReference, "parentReference");
            Param.Ignore(unsafeCode);

            Reference<ICodePart> expressionReference = new Reference<ICodePart>();

            // Create the token based on the type of the symbol.
            Symbol symbol = this.GetNextSymbol(parentReference);

            OperatorSymbol token;
            UnaryExpression.Operator operatorType;
            if (symbol.SymbolType == SymbolType.Plus)
            {
                operatorType = UnaryExpression.Operator.Positive;
                token = new OperatorSymbol(symbol.Text, OperatorCategory.Unary, OperatorType.Positive, symbol.Location, expressionReference, this.symbols.Generated);
            }
            else if (symbol.SymbolType == SymbolType.Minus)
            {
                operatorType = UnaryExpression.Operator.Negative;
                token = new OperatorSymbol(symbol.Text, OperatorCategory.Unary, OperatorType.Negative, symbol.Location, expressionReference, this.symbols.Generated);
            }
            else if (symbol.SymbolType == SymbolType.Not)
            {
                operatorType = UnaryExpression.Operator.Not;
                token = new OperatorSymbol(symbol.Text, OperatorCategory.Unary, OperatorType.Not, symbol.Location, expressionReference, this.symbols.Generated);
            }
            else if (symbol.SymbolType == SymbolType.Tilde)
            {
                operatorType = UnaryExpression.Operator.BitwiseCompliment;
                token = new OperatorSymbol(
                    symbol.Text, OperatorCategory.Unary, OperatorType.BitwiseCompliment, symbol.Location, expressionReference, this.symbols.Generated);
            }
            else
            {
                // This is not a unary type.
                Debug.Fail("Unexpected operator type");
                throw new StyleCopException();
            }

            Node<CsToken> tokenNode = this.tokens.InsertLast(token);
            this.symbols.Advance();

            // Get the expression after the operator.
            Expression innerExpression = this.GetNextExpression(ExpressionPrecedence.Unary, expressionReference, unsafeCode);
            if (innerExpression == null || innerExpression.Tokens.First == null)
            {
                throw this.CreateSyntaxException();
            }

            // Create the partial token list for the expression.
            CsTokenList partialTokens = new CsTokenList(this.tokens, tokenNode, this.tokens.Last);

            // Create and return the expression.
            UnaryExpression expression = new UnaryExpression(partialTokens, operatorType, innerExpression);
            expressionReference.Target = expression;

            return expression;
        }

        /// <summary>
        /// Reads a unary increment expression.
        /// </summary>
        /// <param name="unsafeCode">
        /// Indicates whether the code being parsed resides in an unsafe code block.
        /// </param>
        /// <returns>
        /// Returns the expression.
        /// </returns>
        private IncrementExpression GetUnaryIncrementExpression(bool unsafeCode)
        {
            Param.Ignore(unsafeCode);

            Reference<ICodePart> expressionReference = new Reference<ICodePart>();

            // Get the increment symbol.
            Node<CsToken> tokenNode = this.tokens.InsertLast(this.GetOperatorToken(OperatorType.Increment, expressionReference));

            // Get the expression being incremented.
            Expression valueExpression = this.GetNextExpression(ExpressionPrecedence.Unary, expressionReference, unsafeCode);
            if (valueExpression == null || valueExpression.Tokens.First == null)
            {
                throw this.CreateSyntaxException();
            }

            // Create the partial token list for the expression.
            CsTokenList partialTokens = new CsTokenList(this.tokens, tokenNode, this.tokens.Last);

            // Create and return the expression.
            IncrementExpression expression = new IncrementExpression(partialTokens, valueExpression, IncrementExpression.IncrementType.Prefix);
            expressionReference.Target = expression;

            return expression;
        }

        /// <summary>
        /// Reads an unchecked expression from the code.
        /// </summary>
        /// <param name="parentReference">
        /// The parent code unit.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code being parsed resides in an unsafe code block.
        /// </param>
        /// <returns>
        /// Returns the expression.
        /// </returns>
        private UncheckedExpression GetUncheckedExpression(Reference<ICodePart> parentReference, bool unsafeCode)
        {
            Param.AssertNotNull(parentReference, "parentReference");
            Param.Ignore(unsafeCode);

            Reference<ICodePart> expressionReference = new Reference<ICodePart>();

            // Get the unchecked keyword.
            Node<CsToken> firstTokenNode = this.tokens.InsertLast(this.GetToken(CsTokenType.Unchecked, SymbolType.Unchecked, parentReference, expressionReference));

            // The next symbol will be the opening parenthesis.
            Bracket openParenthesis = this.GetBracketToken(CsTokenType.OpenParenthesis, SymbolType.OpenParenthesis, expressionReference);
            Node<CsToken> openParenthesisNode = this.tokens.InsertLast(openParenthesis);

            // Get the inner expression.
            Expression innerExpression = this.GetNextExpression(ExpressionPrecedence.None, expressionReference, unsafeCode);

            // Get the closing parenthesis.
            Bracket closeParenthesis = this.GetBracketToken(CsTokenType.CloseParenthesis, SymbolType.CloseParenthesis, expressionReference);
            Node<CsToken> closeParenthesisNode = this.tokens.InsertLast(closeParenthesis);

            openParenthesis.MatchingBracketNode = closeParenthesisNode;
            closeParenthesis.MatchingBracketNode = openParenthesisNode;

            // Create the token list for the method invocation expression.
            CsTokenList partialTokens = new CsTokenList(this.tokens, firstTokenNode, this.tokens.Last);

            // Create and return the expression.
            UncheckedExpression expression = new UncheckedExpression(partialTokens, innerExpression);
            expressionReference.Target = expression;

            return expression;
        }

        /// <summary>
        /// Reads an unsafe access expression.
        /// </summary>
        /// <param name="parentReference">
        /// The parent code unit.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code being parsed resides in an unsafe code block.
        /// </param>
        /// <returns>
        /// Returns the expression.
        /// </returns>
        private UnsafeAccessExpression GetUnsafeAccessExpression(Reference<ICodePart> parentReference, bool unsafeCode)
        {
            Param.AssertNotNull(parentReference, "parentReference");
            Param.Assert(unsafeCode, "unsafeCode", "Un unsafe access must reside in an unsafe code block.");

            // Get the operator symbol.
            Symbol symbol = this.GetNextSymbol(parentReference);

            Reference<ICodePart> expressionReference = new Reference<ICodePart>();

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
            OperatorSymbol token = new OperatorSymbol(symbol.Text, OperatorCategory.Reference, operatorType, symbol.Location, expressionReference, this.symbols.Generated);

            Node<CsToken> tokenNode = this.tokens.InsertLast(token);

            // Get the expression being accessed.
            Expression innerExpression = this.GetNextExpression(ExpressionPrecedence.Unary, expressionReference, unsafeCode);
            if (innerExpression == null || innerExpression.Tokens.First == null)
            {
                throw new SyntaxException(this.document.SourceCode, symbol.LineNumber);
            }

            // Create the partial token list for the expression.
            CsTokenList partialTokens = new CsTokenList(this.tokens, tokenNode, this.tokens.Last);

            // Create and return the expression.
            UnsafeAccessExpression expression = new UnsafeAccessExpression(partialTokens, unsafeOperatorType, innerExpression);
            expressionReference.Target = expression;

            return expression;
        }

        /// <summary>
        /// Reads an unsafe type expression.
        /// </summary>
        /// <param name="type">
        /// The type expression.
        /// </param>
        /// <param name="previousPrecedence">
        /// The precedence of the previous expression.
        /// </param>
        /// <param name="parentReference">
        /// The parent code unit.
        /// </param>
        /// <returns>
        /// Returns the expression.
        /// </returns>
        private UnsafeAccessExpression GetUnsafeTypeExpression(Expression type, ExpressionPrecedence previousPrecedence, Reference<ICodePart> parentReference)
        {
            Param.Ignore(type);
            Param.AssertNotNull(previousPrecedence, "previousPrecedence");
            Param.AssertNotNull(parentReference, "parentReference");

            UnsafeAccessExpression expression = null;

            if (CheckPrecedence(previousPrecedence, ExpressionPrecedence.Unary))
            {
                // Get the operator symbol.
                Symbol symbol = this.GetNextSymbol(parentReference);

                Reference<ICodePart> expressionReference = new Reference<ICodePart>();

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
                    symbol.Text, OperatorCategory.Reference, operatorType, symbol.Location, expressionReference, this.symbols.Generated);

                this.tokens.Add(token);

                // Create the partial token list for the expression.
                CsTokenList partialTokens = new CsTokenList(this.tokens, type.Tokens.First, this.tokens.Last);

                // Create and return the expression.
                expression = new UnsafeAccessExpression(partialTokens, unsafeOperatorType, type);
                expressionReference.Target = expression;
            }

            return expression;
        }

        /// <summary>
        /// Reads an expression beginning with two unknown words.
        /// </summary>
        /// <param name="type">
        /// The type of the variable.
        /// </param>
        /// <param name="previousPrecedence">
        /// The precedence of the previous expression.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code being parsed resides in an unsafe code block.
        /// </param>
        /// <returns>
        /// Returns the expression.
        /// </returns>
        private VariableDeclarationExpression GetVariableDeclarationExpression(Expression type, ExpressionPrecedence previousPrecedence, bool unsafeCode)
        {
            Param.AssertNotNull(type, "type");
            Param.Ignore(previousPrecedence);
            Param.Ignore(unsafeCode);

            Debug.Assert(
                type.ExpressionType == ExpressionType.Literal || type.ExpressionType == ExpressionType.MemberAccess,
                "The left side of a variable declaration must either be a literal or a member access.");

            VariableDeclarationExpression expression = null;
            if (CheckPrecedence(previousPrecedence, ExpressionPrecedence.None))
            {
                Reference<ICodePart> expressionReference = new Reference<ICodePart>();

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
                    Symbol symbol = this.GetNextSymbol(SymbolType.Other, expressionReference);

                    // Get the identifier.
                    LiteralExpression identifier = this.GetLiteralExpression(expressionReference, unsafeCode);
                    if (identifier == null || identifier.Tokens.First == null)
                    {
                        throw new SyntaxException(this.document.SourceCode, symbol.LineNumber);
                    }

                    // Get the initializer if it exists.
                    Expression initializer = null;

                    symbol = this.GetNextSymbol(expressionReference);
                    if (symbol.SymbolType == SymbolType.Equals)
                    {
                        // Add the equals token.
                        this.tokens.Add(this.GetOperatorToken(OperatorType.Equals, expressionReference));

                        // Check whether this is an array initializer.
                        symbol = this.GetNextSymbol(expressionReference);

                        if (symbol.SymbolType == SymbolType.OpenCurlyBracket)
                        {
                            initializer = this.GetArrayInitializerExpression(unsafeCode);
                        }
                        else
                        {
                            initializer = this.GetNextExpression(ExpressionPrecedence.None, expressionReference, unsafeCode);
                        }
                    }

                    // Create the token list for the declarator.
                    CsTokenList partialTokens = new CsTokenList(this.tokens, identifier.Tokens.First, this.tokens.Last);

                    // Create and add the declarator.
                    declarators.Add(new VariableDeclaratorExpression(partialTokens, identifier, initializer));

                    // Now check if the next character is a comma. If so there is another declarator.
                    symbol = this.GetNextSymbol(expressionReference);
                    if (symbol.SymbolType != SymbolType.Comma)
                    {
                        // There are no more declarators.
                        break;
                    }

                    // Add the comma.
                    this.tokens.Add(this.GetToken(CsTokenType.Comma, SymbolType.Comma, expressionReference));
                }

                // Create the token list for the expression.
                CsTokenList tokenList = new CsTokenList(this.tokens, type.Tokens.First, this.tokens.Last);

                // Create the expression.
                expression = new VariableDeclarationExpression(tokenList, literalType, declarators.ToArray());
                expressionReference.Target = expression;
            }

            return expression;
        }

        /// <summary>
        /// Reads an expression that contains with two unknown words.
        /// </summary>
        /// <param name="type">
        /// The type of the variable.
        /// </param>
        /// <param name="previousPrecedence">
        /// The precedence of the previous expression.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code being parsed resides in an unsafe code block.
        /// </param>
        /// <returns>
        /// Returns the expression.
        /// </returns>
        private VariableDeclarationExpression GetSingleVariableDeclarationExpression(Expression type, ExpressionPrecedence previousPrecedence, bool unsafeCode)
        {
            Param.AssertNotNull(type, "type");
            Param.Ignore(previousPrecedence);
            Param.Ignore(unsafeCode);

            Debug.Assert(
                type.ExpressionType == ExpressionType.Literal || type.ExpressionType == ExpressionType.MemberAccess,
                "The left side of a variable declaration must either be a literal or a member access.");

            VariableDeclarationExpression expression = null;
            if (CheckPrecedence(previousPrecedence, ExpressionPrecedence.None))
            {
                Reference<ICodePart> expressionReference = new Reference<ICodePart>();

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

                // Get single declarator.
                List<VariableDeclaratorExpression> declarators = new List<VariableDeclaratorExpression>();

                // Get the next word.
                Symbol symbol = this.GetNextSymbol(SymbolType.Other, expressionReference);

                // Get the identifier.
                LiteralExpression identifier = this.GetLiteralExpression(expressionReference, unsafeCode);
                if (identifier == null || identifier.Tokens.First == null)
                {
                    throw new SyntaxException(this.document.SourceCode, symbol.LineNumber);
                }

                // Get the initializer if it exists.
                Expression initializer = null;

                symbol = this.GetNextSymbol(expressionReference);
                if (symbol.SymbolType == SymbolType.Equals)
                {
                    // Add the equals token.
                    this.tokens.Add(this.GetOperatorToken(OperatorType.Equals, expressionReference));

                    // Check whether this is an array initializer.
                    symbol = this.GetNextSymbol(expressionReference);

                    if (symbol.SymbolType == SymbolType.OpenCurlyBracket)
                    {
                        initializer = this.GetArrayInitializerExpression(unsafeCode);
                    }
                    else
                    {
                        initializer = this.GetNextExpression(ExpressionPrecedence.None, expressionReference, unsafeCode);
                    }
                }

                // Create the token list for the declarator.
                CsTokenList partialTokens = new CsTokenList(this.tokens, identifier.Tokens.First, this.tokens.Last);

                // Create and add the declarator.
                declarators.Add(new VariableDeclaratorExpression(partialTokens, identifier, initializer));

                // Create the token list for the expression.
                CsTokenList tokenList = new CsTokenList(this.tokens, type.Tokens.First, this.tokens.Last);

                // Create the expression.
                expression = new VariableDeclarationExpression(tokenList, literalType, declarators.ToArray());
                expressionReference.Target = expression;
            }

            return expression;
        }

        /// <summary>
        /// Reads the expression that begins with a throw keyword
        /// </summary>
        /// <param name="parentReference">
        /// The parent code unit.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code being parsed resides in an unsafe code block.
        /// </param>
        /// <returns>
        /// Returns the expression.
        /// </returns>
        private ThrowExpression GetThrowExpression(Reference<ICodePart> parentReference, bool unsafeCode)
        {
            Reference<ICodePart> expressionReference = new Reference<ICodePart>();

            // Move past the throw keyword.
            CsToken firstToken = this.GetToken(CsTokenType.Throw, SymbolType.Throw, parentReference, expressionReference);
            Node<CsToken> firstTokenNode = this.tokens.InsertLast(firstToken);

            Expression exceptionExpression = this.GetNextExpression(ExpressionPrecedence.None, expressionReference, unsafeCode);

            if (exceptionExpression == null)
            {
                throw this.CreateSyntaxException();
            }
            
            // Create the token list for the expression.
            CsTokenList tokenList = new CsTokenList(this.tokens, firstTokenNode, this.tokens.Last);

            // Create the expression.
            ThrowExpression expression = new ThrowExpression(tokenList, exceptionExpression);
            expressionReference.Target = expression;

            return expression;
        }

        /// <summary>
        /// Reads the expression that begins with a ref keyword
        /// </summary>
        /// <param name="parentReference">
        /// The parent code unit.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code being parsed resides in an unsafe code block.
        /// </param>
        /// <returns>
        /// Returns the expression.
        /// </returns>
        private RefExpression GetRefExpression(Reference<ICodePart> parentReference, bool unsafeCode)
        {
            Reference<ICodePart> expressionReference = new Reference<ICodePart>();

            // Move past the ref keyword.
            CsToken firstToken = this.GetToken(CsTokenType.Ref, SymbolType.Ref, parentReference, expressionReference);
            Node<CsToken> firstTokenNode = this.tokens.InsertLast(firstToken);

            Expression exceptionExpression = this.GetNextExpression(ExpressionPrecedence.None, expressionReference, unsafeCode);

            if (exceptionExpression == null)
            {
                throw this.CreateSyntaxException();
            }
            
            // Create the token list for the expression.
            CsTokenList tokenList = new CsTokenList(this.tokens, firstTokenNode, this.tokens.Last);

            // Create the expression.
            RefExpression expression = new RefExpression(tokenList, exceptionExpression);
            expressionReference.Target = expression;

            return expression;
        }

        /// <summary>
        /// Checks whether the symbol manager is currently sitting on an expression that looks like a type.
        /// </summary>
        /// <param name="startIndex">
        /// The first index of the expression.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code being parsed resides in an unsafe code block.
        /// </param>
        /// <param name="endIndex">
        /// Returns the last index of the type, or -1 if this is not a type.
        /// </param>
        /// <returns>
        /// Returns true if the next expression is a cast.
        /// </returns>
        private bool HasTypeSignature(int startIndex, bool unsafeCode, out int endIndex)
        {
            Param.Ignore(startIndex, unsafeCode);

            bool generic;
            return this.HasTypeSignature(startIndex, unsafeCode, out endIndex, out generic);
        }

        /// <summary>
        /// Checks whether the symbol manager is currently sitting on an expression that looks like a type.
        /// </summary>
        /// <param name="startIndex">
        /// The first index of the expression.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code being parsed resides in an unsafe code block.
        /// </param>
        /// <param name="endIndex">
        /// Returns the last index of the type, or -1 if this is not a type.
        /// </param>
        /// <param name="generic">
        /// Returns a value indicating whether the type is generic.
        /// </param>
        /// <returns>
        /// Returns true if the next expression is a cast.
        /// </returns>
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

                    index = this.AdvanceToEndOfName(index, out generic);
                    endIndex = index;

                    // Check if there are one or more dereference symbols.
                    bool loop = true;
                    while (loop)
                    {
                        loop = false;

                        if (index != -1)
                        {
                            index = this.GetNextCodeSymbolIndex(index + 1);
                            if (index != -1)
                            {
                                symbol = this.symbols.Peek(index);
                                if (symbol.SymbolType == SymbolType.Multiplication && unsafeCode)
                                {
                                    allowNullableType = false;
                                    endIndex = index;
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
                                if (symbol.SymbolType == SymbolType.WhiteSpace || symbol.SymbolType == SymbolType.EndOfLine
                                    || symbol.SymbolType == SymbolType.SingleLineComment || symbol.SymbolType == SymbolType.MultiLineComment
                                    || symbol.SymbolType == SymbolType.PreprocessorDirective || symbol.SymbolType == SymbolType.Number
                                    || symbol.SymbolType == SymbolType.Comma)
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
        /// Determines whether the next expression is an 'await' expression.
        /// </summary>
        /// <returns>Returns true if the next expression is an await expression.</returns>
        private bool IsAwaitExpression()
        {
            int index = 1;
            Symbol symbol = this.symbols.Peek(index);

            if (symbol.SymbolType == SymbolType.Other && symbol.Text == "await")
            {
                index++;

                // Advance to the next non-whitespace symbol.
                for (;; ++index)
                {
                    symbol = this.symbols.Peek(index);
                    if (symbol == null)
                    {
                        return false;
                    }

                    if (symbol.SymbolType != SymbolType.EndOfLine && symbol.SymbolType != SymbolType.WhiteSpace && symbol.SymbolType != SymbolType.MultiLineComment
                        && symbol.SymbolType != SymbolType.SingleLineComment)
                    {
                        break;
                    }
                }

                if (symbol.SymbolType == SymbolType.CloseParenthesis || symbol.SymbolType == SymbolType.Semicolon)
                {
                    return false;
                }

                return true;
            }

            return false;
        }

        /// <summary>
        /// Checks whether the symbol manager is currently sitting on a cast expression.
        /// </summary>
        /// <param name="previousPrecedence">
        /// The precedence of the previous expression.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code being parsed resides in an unsafe code block.
        /// </param>
        /// <returns>
        /// Returns true if the next expression is a cast.
        /// </returns>
        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "May be simplified later.")]
        private bool IsCastExpression(ExpressionPrecedence previousPrecedence, bool unsafeCode)
        {
            Param.Ignore(previousPrecedence);
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
                                            Symbol nextSymbol = this.symbols.Peek(index);
                                            SymbolType symbolType = nextSymbol.SymbolType;
                                            if (symbolType == SymbolType.Other)
                                            {
                                                // Check if user don't use a query word as variable name.
                                                index = this.GetNextCodeSymbolIndex(index + 1);
                                                Symbol lastSymbol = this.symbols.Peek(index);
                                                SymbolType lastSymbolType = lastSymbol.SymbolType;

                                                // This could be an expression like:
                                                // from type in x where (type.IsClass) select type;
                                                // bug 6711
                                                // if the expression is like:
                                                // from type in x where true && (type.IsClass) select type;
                                                // from type in x where true || (type.IsClass) select type;
                                                // then the previous precendence in not query but ConditionalAnd, ConditionalOr
                                                if ((previousPrecedence != ExpressionPrecedence.Query && previousPrecedence != ExpressionPrecedence.ConditionalAnd
                                                     && previousPrecedence != ExpressionPrecedence.ConditionalOr && previousPrecedence != ExpressionPrecedence.Equality)
                                                    || (nextSymbol.Text != "where" && nextSymbol.Text != "select" && nextSymbol.Text != "group"
                                                        && nextSymbol.Text != "into" && nextSymbol.Text != "orderby" && nextSymbol.Text != "join"
                                                        && nextSymbol.Text != "let" && nextSymbol.Text != "equals" && nextSymbol.Text != "by" && nextSymbol.Text != "on") || lastSymbolType == SymbolType.CloseParenthesis || lastSymbolType == SymbolType.Dot)
                                                {
                                                    cast = true;
                                                }
                                            }
                                            else if (symbolType == SymbolType.OpenParenthesis || symbolType == SymbolType.Number || symbolType == SymbolType.Tilde
                                                     || symbolType == SymbolType.Not || symbolType == SymbolType.New || symbolType == SymbolType.Sizeof
                                                     || symbolType == SymbolType.Typeof || symbolType == SymbolType.Default || symbolType == SymbolType.Checked
                                                     || symbolType == SymbolType.Unchecked || symbolType == SymbolType.This || symbolType == SymbolType.Base
                                                     || symbolType == SymbolType.Null || symbolType == SymbolType.True || symbolType == SymbolType.False
                                                     || symbolType == SymbolType.Plus || symbolType == SymbolType.Minus || symbolType == SymbolType.String
                                                     || symbolType == SymbolType.Delegate)
                                            {
                                                cast = true;
                                            }
                                            else if (symbolType == SymbolType.Increment || symbolType == SymbolType.Decrement)
                                            {
                                                // This could be a cast if the symbol following the cast is an "other" or an opening parenthesis. For instance:
                                                // object x = (object)++y;
                                                // object x = (object)++(y);
                                                // object x = (object)++this.y;
                                                // However this is not a cast when:
                                                // object x = (x)++;
                                                int next = this.GetNextCodeSymbolIndex(index + 1);
                                                if (next != -1)
                                                {
                                                    SymbolType nextSymbolType = this.symbols.Peek(next).SymbolType;
                                                    if (nextSymbolType == SymbolType.Other || nextSymbolType == SymbolType.This || nextSymbolType == SymbolType.Base
                                                        || nextSymbolType == SymbolType.OpenParenthesis)
                                                    {
                                                        cast = true;
                                                    }
                                                }
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
        /// Determines whether the next expression is a delegate expression, skipping the optional async keyword as required.
        /// </summary>
        /// <returns>Returns true if the next expression is a delegate expression.</returns>
        private bool IsDelegateExpression()
        {
            int index = 1;
            Symbol symbol = this.symbols.Peek(index);

            // move past optional async keyword
            if (symbol.SymbolType == SymbolType.Other && symbol.Text == "async")
            {
                index += 2;
                symbol = this.symbols.Peek(index);
            }

            if (symbol.SymbolType == SymbolType.Delegate)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Analyzes the current expression to determine whether it is a dereference expression.
        /// </summary>
        /// <param name="leftSide">
        /// The left side of the expression.
        /// </param>
        /// <returns>
        /// Returns true if the expression is a dereference expression.
        /// </returns>
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
                if ( /*leftSide is LiteralExpression ||
                    leftSide is MemberAccessExpression ||*/
                    leftSide is UnsafeAccessExpression)
                {
                    // This is a dereference expression if the next word is an unknown word, and 
                    // the next symbol after that is either an equals sign or a semicolon.
                    int index = this.GetNextCodeSymbolIndex(2);
                    if (index != -1)
                    {
                        symbol = this.symbols.Peek(index);
                        if (symbol.SymbolType == SymbolType.CloseParenthesis || symbol.SymbolType == SymbolType.Multiplication)
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
        /// Determines whether the next expression is a lambda expression.
        /// </summary>
        /// <returns>Returns true if the next expression is a lambda expression.</returns>
        private bool IsLambdaExpression()
        {
            int index = 1;
            Symbol symbol = this.symbols.Peek(index);

            // move past optional async keyword
            if (symbol.SymbolType == SymbolType.Other && symbol.Text == "async")
            {
                index += 2;
                symbol = this.symbols.Peek(index);
            }

            if (symbol.SymbolType == SymbolType.OpenParenthesis)
            {
                // Advance to the closing parenthesis.
                int parenthesisCount = 0;

                for (;; ++index)
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

            // Move past the current symbol, which is either an "other" symbol or a closing parenthesis.
            ++index;

            // Advance to the next non-whitespace symbol.
            for (;; ++index)
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

                if (symbol.SymbolType != SymbolType.EndOfLine && symbol.SymbolType != SymbolType.WhiteSpace && symbol.SymbolType != SymbolType.MultiLineComment
                    && symbol.SymbolType != SymbolType.SingleLineComment)
                {
                    break;
                }
            }

            return false;
        }

        /// <summary>
        /// Determines whether the next expression is a bodied expression.
        /// </summary>
        /// <returns>Returns true if the next expression is a bodied expression.</returns>
        private bool IsBodiedExpression()
        {
            int index = 1;
            Symbol symbol = this.symbols.Peek(index);

            // Advance to the next non-whitespace symbol.
            for (;; ++index)
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

                if (symbol.SymbolType != SymbolType.EndOfLine && symbol.SymbolType != SymbolType.WhiteSpace && symbol.SymbolType != SymbolType.MultiLineComment
                    && symbol.SymbolType != SymbolType.SingleLineComment)
                {
                    break;
                }
            }

            return false;
        }

        /// <summary>
        /// Determines whether the next expression is a query expression.
        /// </summary>
        /// <param name="unsafeCode">
        /// Indicates whether the code being parsed is unsafe.
        /// </param>
        /// <returns>
        /// Returns true if the next expression is a lambda expression.
        /// </returns>
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
                if (symbol == null
                    || (symbol.SymbolType != SymbolType.WhiteSpace && symbol.SymbolType != SymbolType.EndOfLine && symbol.SymbolType != SymbolType.SingleLineComment
                        && symbol.SymbolType != SymbolType.MultiLineComment && symbol.SymbolType != SymbolType.PreprocessorDirective))
                {
                    break;
                }

                --index;
            }

            // An expression can only be unary if it comes after one of the following types.
            if (symbol != null)
            {
                if (symbol.SymbolType == SymbolType.Equals || symbol.SymbolType == SymbolType.PlusEquals || symbol.SymbolType == SymbolType.MinusEquals
                    || symbol.SymbolType == SymbolType.MultiplicationEquals || symbol.SymbolType == SymbolType.DivisionEquals || symbol.SymbolType == SymbolType.OrEquals
                    || symbol.SymbolType == SymbolType.AndEquals || symbol.SymbolType == SymbolType.XorEquals || symbol.SymbolType == SymbolType.LeftShiftEquals
                    || symbol.SymbolType == SymbolType.RightShiftEquals || symbol.SymbolType == SymbolType.ModEquals || symbol.SymbolType == SymbolType.ConditionalEquals
                    || symbol.SymbolType == SymbolType.NotEquals || symbol.SymbolType == SymbolType.GreaterThan || symbol.SymbolType == SymbolType.GreaterThanOrEquals
                    || symbol.SymbolType == SymbolType.LessThan || symbol.SymbolType == SymbolType.LessThanOrEquals || symbol.SymbolType == SymbolType.OpenCurlyBracket
                    || symbol.SymbolType == SymbolType.CloseCurlyBracket || symbol.SymbolType == SymbolType.OpenParenthesis
                    || symbol.SymbolType == SymbolType.CloseParenthesis || symbol.SymbolType == SymbolType.OpenSquareBracket || symbol.SymbolType == SymbolType.LogicalAnd
                    || symbol.SymbolType == SymbolType.LogicalOr || symbol.SymbolType == SymbolType.LogicalXor || symbol.SymbolType == SymbolType.ConditionalAnd
                    || symbol.SymbolType == SymbolType.ConditionalOr || symbol.SymbolType == SymbolType.Plus || symbol.SymbolType == SymbolType.Minus
                    || symbol.SymbolType == SymbolType.Multiplication || symbol.SymbolType == SymbolType.Division || symbol.SymbolType == SymbolType.LeftShift
                    || symbol.SymbolType == SymbolType.RightShift || symbol.SymbolType == SymbolType.Mod || symbol.SymbolType == SymbolType.Tilde
                    || symbol.SymbolType == SymbolType.Case || symbol.SymbolType == SymbolType.QuestionMark || symbol.SymbolType == SymbolType.Colon
                    || symbol.SymbolType == SymbolType.NullCoalescingSymbol || symbol.SymbolType == SymbolType.Comma || symbol.SymbolType == SymbolType.Semicolon
                    || symbol.SymbolType == SymbolType.Return || symbol.SymbolType == SymbolType.Throw || symbol.SymbolType == SymbolType.Else || symbol.SymbolType == SymbolType.NullConditional
                    || symbol.SymbolType == SymbolType.Lambda || (symbol.SymbolType == SymbolType.Other && symbol.Text == "await") || symbol.Text == "select")
                {
                    unary = true;
                }
            }

            return unary;
        }

        /// <summary>
        /// Moves past all array brackets. This assumes that the brackets are part of a new array allocation.
        /// </summary>
        /// <param name="parentReference">
        /// The parent code unit.
        /// </param>
        private void MovePastArrayBrackets(Reference<ICodePart> parentReference)
        {
            Param.AssertNotNull(parentReference, "parentReference");

            // The next symbol must be an opening array bracket.
            Symbol symbol = this.GetNextSymbol(SymbolType.OpenSquareBracket, parentReference);

            while (symbol.SymbolType == SymbolType.OpenSquareBracket)
            {
                // Add the opening array bracket.
                Bracket openingBracket = this.GetBracketToken(CsTokenType.OpenSquareBracket, SymbolType.OpenSquareBracket, parentReference);
                Node<CsToken> openingBracketNode = this.tokens.InsertLast(openingBracket);

                // Get the next symbol.
                symbol = this.GetNextSymbol(parentReference);

                // Move past any commas.
                while (symbol.SymbolType == SymbolType.Comma)
                {
                    this.tokens.Add(this.GetToken(CsTokenType.Comma, SymbolType.Comma, parentReference));
                    symbol = this.GetNextSymbol(parentReference);
                }

                // Add the closing array bracket.
                Bracket closingBracket = this.GetBracketToken(CsTokenType.CloseSquareBracket, SymbolType.CloseSquareBracket, parentReference);
                Node<CsToken> closingBracketNode = this.tokens.InsertLast(closingBracket);

                openingBracket.MatchingBracketNode = closingBracketNode;
                closingBracket.MatchingBracketNode = openingBracketNode;

                // If the next symbol is another opening square bracket, repeat.
                symbol = this.GetNextSymbol(parentReference);
            }
        }

        /// <summary>
        /// Reads an operator token.
        /// </summary>
        /// <param name="parentReference">
        /// The parent code part.
        /// </param>
        /// <param name="tokenParent">
        /// The parent of the token.
        /// </param>
        /// <returns>
        /// Returns the token.
        /// </returns>
        private OperatorSymbol PeekOperatorToken(Reference<ICodePart> parentReference, Reference<ICodePart> tokenParent)
        {
            Param.AssertNotNull(parentReference, "parentReference");
            Param.AssertNotNull(tokenParent, "tokenParent");

            // Get the operator symbol.
            Symbol operatorSymbol = this.GetNextSymbol(parentReference);

            // Convert it to a token and add it to the document.
            OperatorSymbol operatorToken = CreateOperatorToken(operatorSymbol, tokenParent, this.symbols.Generated);
            if (operatorToken == null)
            {
                throw this.CreateSyntaxException();
            }

            return operatorToken;
        }

        /// <summary>
        /// Peeks the next few symbols to check if this is an inline variable declaration of an out argument.
        /// </summary>
        /// <returns>
        /// Returns true, if an inline variable declaration was detected.
        /// </returns>
        private bool IsInlineVariableDeclaration()
        {
            int nextSymbolPosition = 1;
            int angleBracketCount = 0;
            int squareBracketCount = 0;
            int parenthesisCount = 0;
            Symbol checkSymbol = null;

            while (true)
            {
                // Get the symbol next to the proposed type declaration symbol.
                checkSymbol = this.PeekNextSymbolFrom(nextSymbolPosition, SkipSymbols.All, false, out nextSymbolPosition);

                // if we found a symbol that could be used as part of type declaration,
                // reset our expectation symbol, to read past it.
                if (checkSymbol.SymbolType == SymbolType.OpenSquareBracket)
                {
                    squareBracketCount++;
                    continue;
                }

                if (checkSymbol.SymbolType == SymbolType.LessThan)
                {
                    angleBracketCount++;
                    continue;
                }

                if (checkSymbol.SymbolType == SymbolType.OpenParenthesis)
                {
                    parenthesisCount++;
                }

                if (checkSymbol.SymbolType == SymbolType.CloseSquareBracket && squareBracketCount > 0)
                {
                    squareBracketCount--;
                }

                if (checkSymbol.SymbolType == SymbolType.GreaterThan && angleBracketCount > 0)
                {
                    angleBracketCount--;
                }

                if (checkSymbol.SymbolType == SymbolType.CloseParenthesis && parenthesisCount > 0)
                {
                    parenthesisCount--;
                }

                // Skip, if we are still reading variable declaration
                if (squareBracketCount > 0 || angleBracketCount > 0 || parenthesisCount > 0)
                {
                    continue;
                }

                Symbol nextSymbol = this.PeekNextSymbolFrom(nextSymbolPosition, SkipSymbols.All, false, out _);
                SymbolType nextSymbolType = nextSymbol.SymbolType;

                if (checkSymbol.SymbolType == SymbolType.QuestionMark || checkSymbol.SymbolType == SymbolType.Dot
                    || nextSymbolType == SymbolType.Dot || nextSymbolType == SymbolType.LessThan || nextSymbolType == SymbolType.OpenSquareBracket
                    || nextSymbolType == SymbolType.OpenParenthesis)
                {
                    continue;
                }

                return nextSymbolType != SymbolType.Comma && nextSymbolType != SymbolType.CloseParenthesis;
            }
        }

        #endregion
    }
}