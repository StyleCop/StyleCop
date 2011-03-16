//-----------------------------------------------------------------------
// <copyright file="ReadabilityRules.MethodParameters.cs">
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
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Xml;
    using StyleCop;
    using StyleCop.CSharp;
    using StyleCop.CSharp.CodeModel;

    /// <content>
    /// Checks rules related to placement of method parameters.
    /// </content>
    public partial class ReadabilityRules
    {
        #region Private Interfaces

        /// <summary>
        /// Represents a list of arguments.
        /// </summary>
        private interface IArgumentList
        {
            /// <summary>
            /// Gets the number of arguments in the list.
            /// </summary>
            int Count
            {
                get;
            }

            /// <summary>
            /// Gets the location of one of the arguments in the list.
            /// </summary>
            /// <param name="index">The index of an argument in the list.</param>
            /// <returns>Returns the location of the arguments.</returns>
            CodeLocation Location(int index);

            /// <summary>
            /// Gets the argument at the given index.
            /// </summary>
            /// <param name="index">The index of an argument in the list.</param>
            /// <returns>Returns the argument at the given index.</returns>
            CodeUnit Argument(int index);

            /// <summary>
            /// Indicates whether an argument is allowed to span across multiple lines.
            /// </summary>
            /// <param name="index">The index of an argument in the list.</param>
            /// <returns>Returns true if the argument is allowed to span across multiple lines.</returns>
            bool MaySpanMultipleLines(int index);
        }

        #endregion Private Interfaces

        #region Private Static Methods

        /// <summary>
        /// Determines the amount of offset to add to the line number of the next argument
        /// for a comment or attribute. 
        /// </summary>
        /// <param name="item">The starting item.</param>
        /// <returns>Returns the amount of offset to add.</returns>
        private static int ParameterPrewordOffset(CodeUnit item)
        {
            Param.AssertNotNull(item, "tokenNode");

            Debug.Assert(item.Is(CodeUnitType.Attribute) || item.Is(LexicalElementType.Comment), "The item must be an attribute or a comment.");

            // Find the start of the next argument.
            for (CodeUnit next = item.FindLast().FindNext(); next != null; next = next.FindNext())
            {
                if (next.Is(LexicalElementType.EndOfLine))
                {
                    return item.Location.LineSpan;
                }
                else if (!next.Is(LexicalElementType.WhiteSpace) &&
                    !next.Is(LexicalElementType.WhiteSpace) &&
                    !next.Is(CodeUnitType.Attribute))
                {
                    return Math.Max(0, next.Location.StartPoint.LineNumber - item.Location.StartPoint.LineNumber);
                }
            }

            return 0;
        }

        /// <summary>
        /// Determines whether a method's parameters share lines or are on different lines.
        /// </summary>
        /// <param name="arguments">The method arguments.</param>
        /// <param name="someParametersShareLine">Returns true if some of the parameters are on the same line.</param>
        /// <param name="someParameterOnDifferentLines">Returns true if some of the parameters are on different lines.</param>
        private static void DetermineMethodParameterPlacementScheme(
            IArgumentList arguments, out bool someParametersShareLine, out bool someParameterOnDifferentLines)
        {
            Param.AssertNotNull(arguments, "arguments");

            someParametersShareLine = false;
            someParameterOnDifferentLines = false;

            CodeLocation previousArgumentLocation = null;
            for (int i = 0; i < arguments.Count; ++i)
            {
                CodeLocation argumentLocation = arguments.Location(i);

                if (i > 0)
                {
                    if (previousArgumentLocation.StartPoint.LineNumber == argumentLocation.EndPoint.LineNumber)
                    {
                        someParametersShareLine = true;
                    }
                    else
                    {
                        someParameterOnDifferentLines = true;
                    }
                }

                previousArgumentLocation = argumentLocation;
            }
        }

        /// <summary>
        /// Measures the number of lines taken up by comments between two tokens.
        /// </summary>
        /// <param name="start">The start token.</param>
        /// <param name="end">The end token.</param>
        /// <param name="includeAttributes">Indicates whether to also count attributes.</param>
        /// <returns>Returns the number of lines takes up by comments.</returns>
        private static int MeasureCommentLinesBetween(CodeUnit start, CodeUnit end, bool includeAttributes)
        {
            Param.AssertNotNull(start, "start");
            Param.AssertNotNull(end, "end");
            Param.Ignore(includeAttributes);

            int lineSpan = 0;

            int previousLineSpan = -1;
            int previousEndLineNumber = -1;
            for (CodeUnit next = start.FindNext(); next != null && next != end; next = next.FindNext())
            {
                if (next.Is(LexicalElementType.Comment) || (next.Is(CodeUnitType.Attribute) && includeAttributes))
                {
                    int itemLineSpan = ParameterPrewordOffset(next);

                    if (previousEndLineNumber > 0 && next.LineNumber == previousEndLineNumber && previousLineSpan > 0)
                    {
                        --itemLineSpan;
                    }

                    lineSpan += itemLineSpan;
                    previousLineSpan = itemLineSpan;
                    previousEndLineNumber = next.Location.EndPoint.LineNumber;
                }
            }

            return lineSpan;
        }

        /// <summary>
        /// Measures the number of lines taken up by comments after the start item before the first word.
        /// </summary>
        /// <param name="start">The start item.</param>
        /// <returns>Returns the number of lines takes up by comments.</returns>
        private static int MeasureCommentLinesAfter(CodeUnit start)
        {
            Param.AssertNotNull(start, "start");

            int lineSpan = 0;

            int previousLineSpan = -1;
            int previousEndLineNumber = -1;
            for (CodeUnit next = start.FindNext(); next != null; next = next.FindNext())
            {
                if (next.Is(LexicalElementType.Comment) || next.Is(CodeUnitType.Attribute))
                {
                    int itemLineSpan = ParameterPrewordOffset(next);

                    if (previousEndLineNumber > 0 && next.LineNumber == previousEndLineNumber && previousLineSpan > 0)
                    {
                        --itemLineSpan;
                    }

                    lineSpan += itemLineSpan;
                    previousLineSpan = itemLineSpan;
                    previousEndLineNumber = next.Location.EndPoint.LineNumber;
                    next = next.FindLast();
                }
                else if (!next.Is(LexicalElementType.WhiteSpace) && 
                    !next.Is(LexicalElementType.EndOfLine) &&
                    !next.Is(CodeUnitType.ParameterList) &&
                    !next.Is(CodeUnitType.ArgumentList) &&
                    !next.Is(CodeUnitType.Parameter) &&
                    !next.Is(CodeUnitType.Argument))
                {
                    break;
                }
            }

            return lineSpan;
        }

        #endregion Private Static Methods

        #region Private Methods

        /// <summary>
        /// Processes the given element.
        /// </summary>
        /// <param name="element">The element being visited.</param>
        private void CheckMethodParameters(Element element)
        {
            Param.AssertNotNull(element, "element");

            ParameterList parameterList = null;
            TokenType openBracketType = TokenType.OpenParenthesis;
            TokenType closeBracketType = TokenType.CloseParenthesis;

            if (element.ElementType == ElementType.Constructor)
            {
                parameterList = ((Constructor)element).ParameterList;
            }
            else if (element.ElementType == ElementType.Delegate)
            {
                parameterList = ((CodeModel.Delegate)element).ParameterList;
            }
            else if (element.ElementType == ElementType.Method)
            {
                parameterList = ((Method)element).ParameterList;
            }
            else if (element.ElementType == ElementType.Indexer)
            {
                parameterList = ((Indexer)element).ParameterList;
                openBracketType = TokenType.OpenSquareBracket;
                closeBracketType = TokenType.CloseSquareBracket;
            }

            if (parameterList != null)
            {
                this.CheckParameters(element, parameterList, new ParameterListWrapper(parameterList), element.LineNumber, openBracketType, closeBracketType);
            }
        }

        /// <summary>
        /// Checks a method invocation expression to make that the parameters are positioned correctly.
        /// </summary>
        /// <param name="element">The element containing the expression.</param>
        /// <param name="expression">The expression to check.</param>
        private void CheckMethodInvocationParameters(Element element, MethodInvocationExpression expression)
        {
            Param.AssertNotNull(element, "element");
            Param.AssertNotNull(expression, "expression");

            if (!expression.Generated)
            {
                ArgumentList argumentList = expression.ArgumentList;
                if (argumentList != null)
                {
                    this.CheckParameters(element, argumentList, new ArgumentListWrapper(argumentList), expression.LineNumber, TokenType.OpenParenthesis, TokenType.CloseParenthesis);
                }
            }
        }

        /// <summary>
        /// Checks the placement and formatting of parameters to a method invocation or a method declaration.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="parameterList">The argument list.</param>
        /// <param name="methodArguments">The arguments or parameters to the method.</param>
        /// <param name="methodStartLineNumber">The line number on which the method begins.</param>
        /// <param name="openBracketType">The type of the argument list opening bracket.</param>
        /// <param name="closeBracketType">The type of the argument list closing bracket.</param>
        private void CheckParameters(
            Element element,
            CodeUnit parameterList,
            IArgumentList methodArguments,
            int methodStartLineNumber,
            TokenType openBracketType,
            TokenType closeBracketType)
        {
            Param.AssertNotNull(element, "element");
            Param.AssertNotNull(parameterList, "parameterList");
            Param.AssertNotNull(methodArguments, "methodArguments");
            Param.AssertGreaterThanZero(methodStartLineNumber, "methodStartLineNumber");
            Param.Ignore(openBracketType);
            Param.Ignore(closeBracketType);

            OpenBracketToken openingBracket = this.CheckMethodOpeningBracket(element, parameterList, openBracketType);

            if (openingBracket != null)
            {
                this.CheckMethodClosingBracket(element, parameterList, openingBracket, closeBracketType, methodArguments);

                if (methodArguments.Count > 0)
                {
                    this.CheckMethodArgumentList(element, parameterList, methodArguments, openingBracket, methodStartLineNumber);
                }
            }
        }

        /// <summary>
        /// Checks a method or method invocation to ensure that the opening bracket is
        /// on the same line as the method declaration.
        /// </summary>
        /// <param name="element">The element containing the expression.</param>
        /// <param name="parameterList">The argument list.</param>
        /// <param name="openingBracketType">The type of the bracket that opens the argument list.</param>
        /// <returns>Returns the opening bracket.</returns>
        private OpenBracketToken CheckMethodOpeningBracket(Element element, CodeUnit parameterList, TokenType openingBracketType)
        {
            Param.AssertNotNull(element, "element");
            Param.AssertNotNull(parameterList, "parameterList");
            Param.Ignore(openingBracketType);

            // Find the opening bracket.
            OpenBracketToken openingBracket = null;

            Token firstDeclarationToken = element.FirstDeclarationToken;
            if (firstDeclarationToken != null)
            {
                Token previous = parameterList.FindPreviousSiblingToken();
                if (previous != null && previous.Is(openingBracketType))
                {
                    openingBracket = (OpenBracketToken)previous;
                }

                if (openingBracket != null)
                {
                    // Find the last word before the opening bracket.
                    Token lastWord = openingBracket.FindPreviousToken();

                    if (lastWord != null && openingBracket.LineNumber != lastWord.LineNumber)
                    {
                        this.AddViolation(
                            element,
                            openingBracket.LineNumber,
                            Rules.OpeningParenthesisMustBeOnDeclarationLine,
                            element.FriendlyTypeText);
                    }
                }
            }

            return openingBracket;
        }

        /// <summary>
        /// Checks a method or method invocation to ensure that the closing bracket is
        /// on the same line as the last argument.
        /// </summary>
        /// <param name="element">The element containing the expression.</param>
        /// <param name="parameterList">The argument list.</param>
        /// <param name="openingBracket">The opening bracket.</param>
        /// <param name="closingBracketType">The type of the closing bracket.</param>
        /// <param name="arguments">The arguments to the method.</param>
        private void CheckMethodClosingBracket(
            Element element, CodeUnit parameterList, OpenBracketToken openingBracket, TokenType closingBracketType, IArgumentList arguments)
        {
            Param.AssertNotNull(element, "element");
            Param.AssertNotNull(parameterList, "parameterList");
            Param.AssertNotNull(openingBracket, "openingBracket");
            Param.Ignore(closingBracketType);
            Param.AssertNotNull(arguments, "arguments");

            // Find the closing bracket.
            CloseBracketToken closingBracket = null;

            Token next = parameterList.FindNextSiblingToken();
            if (next != null && next.Is(closingBracketType))
            {
                closingBracket = (CloseBracketToken)next;
            }

            if (closingBracket != null)
            {
                if (arguments.Count == 0)
                {
                    // The closing bracket must be on the same line as the opening bracket.
                    if (openingBracket.LineNumber != closingBracket.LineNumber)
                    {
                        // If the brackets are not on the same line, determine if this is because there are comments
                        // between the brackets.
                        int commentLineSpan = MeasureCommentLinesBetween(openingBracket, closingBracket, false);

                        if (openingBracket.LineNumber + commentLineSpan != closingBracket.LineNumber)
                        {
                            this.AddViolation(element, closingBracket.LineNumber, Rules.ClosingParenthesisMustBeOnLineOfOpeningParenthesis);
                        }
                    }
                }
                else
                {
                    // The closing bracket must be on the same line as the end of the last method argument.
                    int lastArgumentEndLine = arguments.Location(arguments.Count - 1).EndPoint.LineNumber;
                    if (lastArgumentEndLine != closingBracket.LineNumber)
                    {
                        int commentLineSpan = MeasureCommentLinesBetween(arguments.Argument(arguments.Count - 1).FindLastDescendentToken(), closingBracket, false);

                        if (lastArgumentEndLine + commentLineSpan != closingBracket.LineNumber)
                        {
                            this.AddViolation(element, closingBracket.LineNumber, Rules.ClosingParenthesisMustBeOnLineOfLastParameter);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Checks the argument list to a method or method invocation to ensure that the arguments are 
        /// positioned correctly.
        /// </summary>
        /// <param name="element">The element containing the expression.</param>
        /// <param name="parameterList">The element's argument list.</param>
        /// <param name="arguments">The arguments to the method.</param>
        /// <param name="openingBracket">The opening bracket token.</param>
        /// <param name="methodLineNumber">The line number on which the method begins.</param>
        private void CheckMethodArgumentList(Element element, CodeUnit parameterList, IArgumentList arguments, OpenBracketToken openingBracket, int methodLineNumber)
        {
            Param.AssertNotNull(element, "element");
            Param.AssertNotNull(parameterList, "parameterList");
            Param.AssertNotNull(arguments, "arguments");
            Param.AssertNotNull(openingBracket, "openingBracket");
            Param.AssertGreaterThanZero(methodLineNumber, "methodLineNumber");

            // Determine whether all of the parameters are on the same line as one another.
            bool someParametersShareLine;
            bool someParameterOnDifferentLines;

            DetermineMethodParameterPlacementScheme(
                arguments, out someParametersShareLine, out someParameterOnDifferentLines);

            // All parameters must either be on the same line, or each argument must begin on its own line.
            if (someParametersShareLine && someParameterOnDifferentLines)
            {
                this.AddViolation(
                    element,
                    methodLineNumber,
                    Rules.ParametersMustBeOnSameLineOrSeparateLines,
                    element.FriendlyTypeText);
            }

            // Determine whether all of the parameters are on the same line as one another.
            if (someParameterOnDifferentLines)
            {
                this.CheckSplitMethodArgumentList(element, parameterList, arguments, openingBracket);
            }
            else if (arguments.Count > 0)
            {
                // The first argument must start on the same line as the opening bracket, or 
                // on the line after it.
                int firstArgumentStartLine = arguments.Location(0).LineNumber;

                if (firstArgumentStartLine != openingBracket.LineNumber &&
                    firstArgumentStartLine != openingBracket.LineNumber + 1)
                {
                    int commentLineSpan = MeasureCommentLinesAfter(openingBracket);

                    if (firstArgumentStartLine != openingBracket.LineNumber + commentLineSpan + 1)
                    {
                        this.AddViolation(element, firstArgumentStartLine, Rules.ParameterListMustFollowDeclaration);
                    }
                }
            }
        }

        /// <summary>
        /// Checks the positioning of method parameters which are split across multiple lines.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="parameterList">The argument list.</param>
        /// <param name="arguments">The method arguments.</param>
        /// <param name="openingBracket">The opening bracket token.</param>
        private void CheckSplitMethodArgumentList(Element element, CodeUnit parameterList, IArgumentList arguments, OpenBracketToken openingBracket)
        {
            Param.AssertNotNull(element, "element");
            Param.AssertNotNull(parameterList, "parameterList");
            Param.AssertNotNull(arguments, "arguments");
            Param.AssertNotNull(openingBracket, "openingBracket");

            Token previousComma = null;
            bool commaOnSameLineAsPreviousParameterViolation = false;

            for (int i = 0; i < arguments.Count; ++i)
            {
                CodeLocation location = arguments.Location(i);
                int argumentStartLine = location.LineNumber;

                CodeUnit argument = arguments.Argument(i);

                // Some types of parameters or arguments are not allowed to span across multiple lines.
                if (location.LineSpan > 1 && !arguments.MaySpanMultipleLines(i))
                {
                    this.AddViolation(element, argumentStartLine, Rules.ParameterMustNotSpanMultipleLines);
                }

                if (i == 0)
                {
                    // The first argument must start on the line after the opening bracket
                    if (argumentStartLine != openingBracket.LineNumber + 1)
                    {
                        int commentLineSpan = MeasureCommentLinesAfter(openingBracket);

                        if (argumentStartLine != openingBracket.LineNumber + commentLineSpan + 1)
                        {
                            this.AddViolation(element, argumentStartLine, Rules.SplitParametersMustStartOnLineAfterDeclaration, element.FriendlyTypeText);
                        }
                    }
                }
                else
                {
                    // The argument must begin on the line after the previous comma.
                    Debug.Assert(previousComma != null, "The previous comma should have been set.");
                    if (!commaOnSameLineAsPreviousParameterViolation)
                    {
                        if (argumentStartLine != previousComma.LineNumber + 1)
                        {
                            int commentLineSpan = MeasureCommentLinesAfter(previousComma);

                            if (argumentStartLine != previousComma.LineNumber + commentLineSpan + 1)
                            {
                                this.AddViolation(element, argumentStartLine, Rules.ParameterMustFollowComma);
                            }
                        }
                    }
                }

                commaOnSameLineAsPreviousParameterViolation = false;

                // Find the comma after the token list.
                if (i < arguments.Count - 1)
                {
                    Token lastTokenInArgument = argument.FindLastDescendentToken();
                    if (lastTokenInArgument != null)
                    {
                        for (Token token = lastTokenInArgument.FindNextDescendentTokenOf(parameterList); token != null; token = token.FindNextDescendentTokenOf(parameterList))
                        {
                            if (token.TokenType == TokenType.Comma)
                            {
                                previousComma = token;

                                // The comma must be on the same line as the previous argument.
                                if (previousComma.LineNumber != location.EndPoint.LineNumber)
                                {
                                    int commentLineSpan = MeasureCommentLinesBetween(argument.FindLastChildToken(), previousComma, false);

                                    if (previousComma.LineNumber != location.EndPoint.LineNumber + commentLineSpan)
                                    {
                                        this.AddViolation(element, token.LineNumber, Rules.CommaMustBeOnSameLineAsPreviousParameter);
                                        commaOnSameLineAsPreviousParameterViolation = true;
                                    }
                                }

                                break;
                            }
                        }
                    }
                }
            }
        }

        #endregion Private Methods

        #region Private Classes

        /// <summary>
        /// Represents a list of parameters.
        /// </summary>
        private class ParameterListWrapper : IArgumentList
        {
            /// <summary>
            /// The list of parameters.
            /// </summary>
            private ParameterList parameterList;

            /// <summary>
            /// Initializes a new instance of the ParameterListWrapper class.
            /// </summary>
            /// <param name="parameterList">The list of parameters.</param>
            public ParameterListWrapper(ParameterList parameterList)
            {
                Param.AssertNotNull(parameterList, "parameterList");
                this.parameterList = parameterList;
            }

            /// <summary>
            /// Gets the number of parameters in the list.
            /// </summary>
            public int Count
            {
                get { return this.parameterList.Count; }
            }

            /// <summary>
            /// Gets the location of one of the parameters in the list.
            /// </summary>
            /// <param name="index">The index of a argument in the list.</param>
            /// <returns>Returns the location of the parameters.</returns>
            public CodeLocation Location(int index)
            {
                Param.AssertValueBetween(index, 0, this.parameterList.Count - 1, "index");

                Parameter parameter = this.parameterList[index];

                // The location must be calculated by finding the first and last items
                // in the argument and joining their locations.
                CodeUnit firstItem = null;

                for (CodeUnit item = parameter.FindFirstChild(); item != null; item = item.FindNextSibling())
                {
                    if (!item.Is(CodeUnitType.Attribute) &&
                        !item.Is(LexicalElementType.WhiteSpace) &&
                        !item.Is(LexicalElementType.EndOfLine) &&
                        !item.Is(CommentType.SingleLineComment) &&
                        !item.Is(CommentType.MultilineComment))
                    {
                        firstItem = item;
                        break;
                    }
                }

                if (firstItem != null)
                {
                    return CodeLocation.Join(firstItem.Location, parameter.FindLast().Location);
                }

                return parameter.Location;
            }

            /// <summary>
            /// Gets the argument at the given index.
            /// </summary>
            /// <param name="index">The index of an argument in the list.</param>
            /// <returns>Returns the argument for the argument.</returns>
            public CodeUnit Argument(int index)
            {
                Param.AssertValueBetween(index, 0, this.parameterList.Count - 1, "index");
                return this.parameterList[index];
            }

            /// <summary>
            /// Indicates whether a argument is allowed to span across multiple lines.
            /// </summary>
            /// <param name="index">The index of a argument in the list.</param>
            /// <returns>Returns true if the argument is allowed to span across multiple lines.</returns>
            public bool MaySpanMultipleLines(int index)
            {
                Param.Ignore(index);

                // In a method declaration, none of the parameters are allowed to span across multiple lines.
                return false;
            }
        }

        /// <summary>
        /// Represents a list of arguments.
        /// </summary>
        private class ArgumentListWrapper : IArgumentList
        {
            /// <summary>
            /// The list of arguments.
            /// </summary>
            private ArgumentList argumentList;

            /// <summary>
            /// Initializes a new instance of the ArgumentListWrapper class.
            /// </summary>
            /// <param name="argumentList">The list of arguments.</param>
            public ArgumentListWrapper(ArgumentList argumentList)
            {
                Param.AssertNotNull(argumentList, "argumentList");
                this.argumentList = argumentList;
            }

            /// <summary>
            /// Gets the number of arguments in the list.
            /// </summary>
            public int Count
            {
                get { return this.argumentList.Count; }
            }

            /// <summary>
            /// Gets the location of one of the arguments in the list.
            /// </summary>
            /// <param name="index">The index of an argument in the list.</param>
            /// <returns>Returns the location of the arguments.</returns>
            public CodeLocation Location(int index)
            {
                Param.AssertValueBetween(index, 0, this.argumentList.Count - 1, "index");

                Argument argument = this.argumentList[index];

                // The location must be calculated by finding the first and last items
                // in the argument and joining their locations.
                CodeUnit firstItem = null;

                for (CodeUnit item = argument.FindFirstChild(); item != null; item = item.FindNextSibling())
                {
                    if (!item.Is(LexicalElementType.WhiteSpace) &&
                        !item.Is(LexicalElementType.EndOfLine) &&
                        !item.Is(CommentType.SingleLineComment) &&
                        !item.Is(CommentType.MultilineComment))
                    {
                        firstItem = item;
                        break;
                    }
                }

                if (firstItem != null)
                {
                    return CodeLocation.Join(firstItem.Location, argument.FindLast().Location);
                }

                return argument.Location;
            }

            /// <summary>
            /// Gets the argument at the given index.
            /// </summary>
            /// <param name="index">The index of an argument in the list.</param>
            /// <returns>Returns the argument for the argument.</returns>
            public CodeUnit Argument(int index)
            {
                Param.AssertValueBetween(index, 0, this.argumentList.Count - 1, "index");
                return this.argumentList[index];
            }

            /// <summary>
            /// Indicates whether an argument is allowed to span across multiple lines.
            /// </summary>
            /// <param name="index">The index of an argument in the list.</param>
            /// <returns>Returns true if the argument is allowed to span across multiple lines.</returns>
            public bool MaySpanMultipleLines(int index)
            {
                Param.AssertValueBetween(index, 0, this.argumentList.Count - 1, "index");

                // The first argument in an argument list is always allowed to span across multiple lines.
                if (index == 0)
                {
                    return true;
                }

                // An anonymous method expression or lambda expression passed in as an argument is always allowed
                // to span multiple lines. Other types of arguments are not.
                Expression expression = this.argumentList[index].Expression;
                return expression.ExpressionType == ExpressionType.Lambda || expression.ExpressionType == ExpressionType.AnonymousMethod;
            }
        }

        #endregion Private Classes
    }
}
