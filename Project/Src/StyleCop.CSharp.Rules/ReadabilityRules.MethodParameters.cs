// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReadabilityRules.MethodParameters.cs" company="https://github.com/StyleCop">
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
//   The readability rules.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    /// <summary>
    /// The readability rules.
    /// </summary>
    /// <content>
    /// Checks rules related to placement of method parameters.
    /// </content>
    public partial class ReadabilityRules
    {
        #region Interfaces

        /// <summary>
        /// Represents a list of arguments.
        /// </summary>
        private interface IArgumentList
        {
            #region Public Properties

            /// <summary>
            /// Gets the number of arguments in the list.
            /// </summary>
            int Count { get; }

            #endregion

            #region Public Methods and Operators

            /// <summary>
            /// Gets the location of one of the arguments in the list.
            /// </summary>
            /// <param name="index">
            /// The index of an argument in the list.
            /// </param>
            /// <returns>
            /// Returns the location of the arguments.
            /// </returns>
            CodeLocation Location(int index);

            /// <summary>
            /// Indicates whether an argument is allowed to span across multiple lines.
            /// </summary>
            /// <param name="index">
            /// The index of an argument in the list.
            /// </param>
            /// <returns>
            /// Returns true if the argument is allowed to span across multiple lines.
            /// </returns>
            bool MaySpanMultipleLines(int index);

            /// <summary>
            /// Gets the token list for one of the arguments in the list.
            /// </summary>
            /// <param name="index">
            /// The index of an argument in the list.
            /// </param>
            /// <returns>
            /// Returns the list of tokens for the argument.
            /// </returns>
            CsTokenList Tokens(int index);

            #endregion
        }

        #endregion

        #region Methods

        /// <summary>
        /// Determines whether a method's parameters share lines or are on different lines.
        /// </summary>
        /// <param name="arguments">
        /// The method arguments.
        /// </param>
        /// <param name="someParametersShareLine">
        /// Returns true if some of the parameters are on the same line.
        /// </param>
        /// <param name="someParameterOnDifferentLines">
        /// Returns true if some of the parameters are on different lines.
        /// </param>
        private static void DetermineMethodParameterPlacementScheme(IArgumentList arguments, out bool someParametersShareLine, out bool someParameterOnDifferentLines)
        {
            Param.AssertNotNull(arguments, "arguments");

            someParametersShareLine = false;
            someParameterOnDifferentLines = false;

            CodeLocation previousArgumentLocation = new CodeLocation();
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

        /*
        /// <summary>
        /// Measures the number of lines taken up by comments and attributes before the given word.
        /// </summary>
        /// <param name="start">The start token.</param>
        /// <returns>Returs the number of lines taken up.</returns>
        private static int MeasureCommentLinesBefore(Node<CsToken> start)
        {
            Param.AssertNotNull(start, "start");

            int lineSpan = 0;
            int nextLineSpan = -1;
            int nextStartLineNumber = -1;

            for (Node<CsToken> tokenNode = start.Previous; tokenNode != null; tokenNode = tokenNode.Previous)
            {
                if (tokenNode.Value.CsTokenType == CsTokenType.SingleLineComment ||
                    tokenNode.Value.CsTokenType == CsTokenType.MultiLineComment ||
                    tokenNode.Value.CsTokenType == CsTokenType.Attribute)
                {
                    int itemLineSpan = ParameterPrewordOffset(tokenNode);

                    if (nextStartLineNumber > 0 && tokenNode.Value.Location.EndPoint.LineNumber == nextStartLineNumber && nextLineSpan > 0)
                    {
                        --itemLineSpan;
                    }

                    lineSpan += itemLineSpan;
                    nextLineSpan = itemLineSpan;
                    nextStartLineNumber = tokenNode.Value.LineNumber;
                }
            }

            return lineSpan;
        }
        */

        /// <summary>
        /// Gets the tokens forming the argument list for a method call.
        /// </summary>
        /// <param name="tokens">
        /// The tokens forming the method call.
        /// </param>
        /// <param name="methodNameLastToken">
        /// The last token before the argument list begins.
        /// </param>
        /// <param name="openBracketType">
        /// The type of the opening bracket.
        /// </param>
        /// <param name="closeBracketType">
        /// The type of the closing bracket.
        /// </param>
        /// <returns>
        /// Returns the argument list or null if it cannot be found.
        /// </returns>
        private static CsTokenList GetArgumentListTokens(CsTokenList tokens, Node<CsToken> methodNameLastToken, CsTokenType openBracketType, CsTokenType closeBracketType)
        {
            Param.AssertNotNull(tokens, "tokens");
            Param.AssertNotNull(methodNameLastToken, "methodNameLastToken");
            Param.Ignore(openBracketType);
            Param.Ignore(closeBracketType);

            Debug.Assert(methodNameLastToken.Index <= tokens.Last.Index && methodNameLastToken.Index >= tokens.First.Index, "The token is not within the given list");

            Node<CsToken> start = null;
            Node<CsToken> end = null;

            int bracketCount = 0;
            for (Node<CsToken> tokenNode = methodNameLastToken.Next; tokenNode != null; tokenNode = tokenNode.Next)
            {
                if (tokenNode.Value.CsTokenType == openBracketType)
                {
                    ++bracketCount;
                    if (bracketCount == 1)
                    {
                        start = tokenNode;
                    }
                }
                else if (tokenNode.Value.CsTokenType == closeBracketType)
                {
                    --bracketCount;
                    if (bracketCount == 0)
                    {
                        end = tokenNode;
                        break;
                    }
                }
            }

            if (start == null || end == null)
            {
                return null;
            }

            return new CsTokenList(tokens.MasterList, start, end);
        }

        /// <summary>
        /// Gets the tokens forming the parameter list for a method declaration.
        /// </summary>
        /// <param name="tokens">
        /// The tokens forming the method declaration.
        /// </param>
        /// <param name="openBracketType">
        /// The type of the opening bracket.
        /// </param>
        /// <param name="closeBracketType">
        /// The type of the closing bracket.
        /// </param>
        /// <returns>
        /// Returns the parameter list or null if it cannot be found.
        /// </returns>
        private static CsTokenList GetParameterListTokens(CsTokenList tokens, CsTokenType openBracketType, CsTokenType closeBracketType)
        {
            Param.AssertNotNull(tokens, "tokens");
            Param.Ignore(openBracketType);
            Param.Ignore(closeBracketType);

            return GetArgumentListTokens(tokens, tokens.First, openBracketType, closeBracketType);
        }

        /// <summary>
        /// Measures the number of lines taken up by comments after the start token before the first word.
        /// </summary>
        /// <param name="start">
        /// The start token.
        /// </param>
        /// <returns>
        /// Returns the number of lines takes up by comments.
        /// </returns>
        private static int MeasureCommentLinesAfter(Node<CsToken> start)
        {
            Param.AssertNotNull(start, "start");

            int lineSpan = 0;

            int previousLineSpan = -1;
            int previousEndLineNumber = -1;
            for (Node<CsToken> tokenNode = start.Next; tokenNode != null; tokenNode = tokenNode.Next)
            {
                if (tokenNode.Value.CsTokenType == CsTokenType.SingleLineComment || tokenNode.Value.CsTokenType == CsTokenType.MultiLineComment
                    || tokenNode.Value.CsTokenType == CsTokenType.Attribute)
                {
                    int itemLineSpan = ParameterPrewordOffset(tokenNode);

                    if (previousEndLineNumber > 0 && tokenNode.Value.LineNumber == previousEndLineNumber && previousLineSpan > 0)
                    {
                        --itemLineSpan;
                    }

                    if ((start.Value.LineNumber == tokenNode.Value.LineNumber) && tokenNode.Value.CsTokenType == CsTokenType.SingleLineComment)
                    {
                        --itemLineSpan;
                    }

                    lineSpan += itemLineSpan;
                    previousLineSpan = itemLineSpan;
                    previousEndLineNumber = tokenNode.Value.Location.EndPoint.LineNumber;
                }
                else if (tokenNode.Value.CsTokenType != CsTokenType.WhiteSpace && tokenNode.Value.CsTokenType != CsTokenType.EndOfLine)
                {
                    break;
                }
            }

            return lineSpan;
        }

        /// <summary>
        /// Measures the number of lines taken up by comments between two tokens.
        /// </summary>
        /// <param name="start">
        /// The start token.
        /// </param>
        /// <param name="end">
        /// The end token.
        /// </param>
        /// <param name="includeAttributes">
        /// Indicates whether to also count attributes.
        /// </param>
        /// <returns>
        /// Returns the number of lines takes up by comments.
        /// </returns>
        private static int MeasureCommentLinesBetween(Node<CsToken> start, Node<CsToken> end, bool includeAttributes)
        {
            Param.AssertNotNull(start, "start");
            Param.AssertNotNull(end, "end");
            Param.Ignore(includeAttributes);

            Debug.Assert(start.NodesInSameList(end), "The two tokens are not from the same list.");
            Debug.Assert(end.Index > start.Index, "The end token must come after the start token.");

            int lineSpan = 0;

            int previousLineSpan = -1;
            int previousEndLineNumber = -1;
            for (Node<CsToken> tokenNode = start.Next; tokenNode != null && tokenNode != end; tokenNode = tokenNode.Next)
            {
                if (tokenNode.Value.CsTokenType == CsTokenType.SingleLineComment || tokenNode.Value.CsTokenType == CsTokenType.MultiLineComment
                    || (tokenNode.Value.CsTokenType == CsTokenType.Attribute && includeAttributes))
                {
                    int itemLineSpan = ParameterPrewordOffset(tokenNode);

                    if (previousEndLineNumber > 0 && tokenNode.Value.LineNumber == previousEndLineNumber && previousLineSpan > 0)
                    {
                        --itemLineSpan;
                    }

                    lineSpan += itemLineSpan;
                    previousLineSpan = itemLineSpan;
                    previousEndLineNumber = tokenNode.Value.Location.EndPoint.LineNumber;
                }
            }

            return lineSpan;
        }

        /// <summary>
        /// Determines the amount of offset to add to the line number of the next parameter
        /// for a comment or attribute. 
        /// </summary>
        /// <param name="tokenNode">
        /// The token node.
        /// </param>
        /// <returns>
        /// Returns the amount of offset to add.
        /// </returns>
        private static int ParameterPrewordOffset(Node<CsToken> tokenNode)
        {
            Param.AssertNotNull(tokenNode, "tokenNode");

            Debug.Assert(
                tokenNode.Value.CsTokenType == CsTokenType.Attribute || tokenNode.Value.CsTokenType == CsTokenType.SingleLineComment
                || tokenNode.Value.CsTokenType == CsTokenType.MultiLineComment, 
                "The token must be an attribute or a comment.");

            // Find the start of the next parameter.
            for (Node<CsToken> node = tokenNode.Next; node != null; node = node.Next)
            {
                CsTokenType tokenType = node.Value.CsTokenType;

                if (tokenType == CsTokenType.EndOfLine)
                {
                    return tokenNode.Value.Location.LineSpan;
                }
                else if (tokenType != CsTokenType.WhiteSpace && tokenType != CsTokenType.MultiLineComment && tokenType != CsTokenType.SingleLineComment
                         && tokenType != CsTokenType.Attribute)
                {
                    return Math.Max(0, node.Value.Location.StartPoint.LineNumber - tokenNode.Value.Location.StartPoint.LineNumber);
                }
            }

            return 0;
        }

        /// <summary>
        /// Checks an array access expression to make that the parameters are positioned correctly.
        /// </summary>
        /// <param name="element">
        /// The element containing the expression.
        /// </param>
        /// <param name="expression">
        /// The expression to check.
        /// </param>
        private void CheckIndexerAccessParameters(CsElement element, ArrayAccessExpression expression)
        {
            Param.AssertNotNull(element, "element");
            Param.AssertNotNull(expression, "expression");

            if (expression.Tokens.First != null && !expression.Tokens.First.Value.Generated)
            {
                ArgumentList argumentList = new ArgumentList(expression.Arguments);
                CsTokenList argumentListTokens = GetArgumentListTokens(
                    expression.Tokens, expression.Array.Tokens.Last, CsTokenType.OpenSquareBracket, CsTokenType.CloseSquareBracket);

                if (argumentListTokens != null)
                {
                    this.CheckParameters(
                        element, argumentListTokens, argumentList, expression.LineNumber, CsTokenType.OpenSquareBracket, CsTokenType.CloseSquareBracket, "indexer");
                }
            }
        }

        /// <summary>
        /// Checks the argument list to a method or method invocation to ensure that the arguments are 
        /// positioned correctly.
        /// </summary>
        /// <param name="element">
        /// The element containing the expression.
        /// </param>
        /// <param name="arguments">
        /// The arguments to the method.
        /// </param>
        /// <param name="openingBracketNode">
        /// The opening bracket token.
        /// </param>
        /// <param name="methodLineNumber">
        /// The line number on which the method begins.
        /// </param>
        /// <param name="friendlyTypeText">
        /// The text to use for the type in reporting violations.
        /// </param>
        private void CheckMethodArgumentList(CsElement element, IArgumentList arguments, Node<CsToken> openingBracketNode, int methodLineNumber, string friendlyTypeText)
        {
            Param.AssertNotNull(element, "element");
            Param.AssertNotNull(arguments, "arguments");
            Param.AssertNotNull(openingBracketNode, "openingBracketNode");
            Param.AssertGreaterThanZero(methodLineNumber, "methodLineNumber");

            // Determine whether all of the parameters are on the same line as one another.
            bool someParametersShareLine;
            bool someParameterOnDifferentLines;

            DetermineMethodParameterPlacementScheme(arguments, out someParametersShareLine, out someParameterOnDifferentLines);

            // All parameters must either be on the same line, or each parameter must begin on its own line.
            if (someParametersShareLine && someParameterOnDifferentLines)
            {
                this.AddViolation(element, methodLineNumber, Rules.ParametersMustBeOnSameLineOrSeparateLines, friendlyTypeText);
            }

            // Determine whether all of the parameters are on the same line as one another.
            if (someParameterOnDifferentLines)
            {
                this.CheckSplitMethodArgumentList(element, arguments, openingBracketNode, friendlyTypeText);
            }
            else if (arguments.Count > 0)
            {
                // The first argument must start on the same line as the opening bracket, or 
                // on the line after it.
                int firstArgumentStartLine = arguments.Location(0).LineNumber;

                if (firstArgumentStartLine != openingBracketNode.Value.LineNumber && firstArgumentStartLine != openingBracketNode.Value.LineNumber + 1)
                {
                    int commentLineSpan = MeasureCommentLinesAfter(openingBracketNode);

                    if (firstArgumentStartLine != openingBracketNode.Value.LineNumber + commentLineSpan + 1)
                    {
                        this.AddViolation(element, firstArgumentStartLine, Rules.ParameterListMustFollowDeclaration);
                    }
                }
            }
        }

        /// <summary>
        /// Checks a method or method invocation to ensure that the closing bracket is
        /// on the same line as the last parameter.
        /// </summary>
        /// <param name="element">
        /// The element containing the expression.
        /// </param>
        /// <param name="parameterListTokens">
        /// The tokens that form the parameter list.
        /// </param>
        /// <param name="openingBracketNode">
        /// The opening bracket.
        /// </param>
        /// <param name="closingBracketType">
        /// The type of the closing bracket.
        /// </param>
        /// <param name="arguments">
        /// The arguments to the method.
        /// </param>
        private void CheckMethodClosingBracket(
            CsElement element, CsTokenList parameterListTokens, Node<CsToken> openingBracketNode, CsTokenType closingBracketType, IArgumentList arguments)
        {
            Param.AssertNotNull(element, "element");
            Param.AssertNotNull(parameterListTokens, "parameterListTokens");
            Param.AssertNotNull(openingBracketNode, "openingBracket");
            Param.Ignore(closingBracketType);
            Param.AssertNotNull(arguments, "arguments");

            // Find the closing bracket.
            Node<CsToken> closingBracketNode = null;
            for (Node<CsToken> tokenNode = parameterListTokens.Last; tokenNode != null; tokenNode = tokenNode.Previous)
            {
                if (tokenNode.Value.CsTokenType == closingBracketType)
                {
                    closingBracketNode = tokenNode;
                    break;
                }
            }

            if (closingBracketNode != null)
            {
                if (arguments.Count == 0)
                {
                    // The closing bracket must be on the same line as the opening bracket.
                    if (openingBracketNode.Value.LineNumber != closingBracketNode.Value.LineNumber)
                    {
                        // If the brackets are not on the same line, determine if this is because there are comments
                        // between the brackets.
                        int commentLineSpan = MeasureCommentLinesBetween(openingBracketNode, closingBracketNode, false);

                        if (openingBracketNode.Value.LineNumber + commentLineSpan != closingBracketNode.Value.LineNumber)
                        {
                            this.AddViolation(element, closingBracketNode.Value.LineNumber, Rules.ClosingParenthesisMustBeOnLineOfOpeningParenthesis);
                        }
                    }
                }
                else
                {
                    // The closing bracket must be on the same line as the end of the last method argument.
                    int lastArgumentEndLine = arguments.Location(arguments.Count - 1).EndPoint.LineNumber;
                    if (lastArgumentEndLine != closingBracketNode.Value.LineNumber)
                    {
                        int commentLineSpan = MeasureCommentLinesBetween(arguments.Tokens(arguments.Count - 1).Last, closingBracketNode, false);

                        if (lastArgumentEndLine + commentLineSpan != closingBracketNode.Value.LineNumber)
                        {
                            this.AddViolation(element, closingBracketNode.Value.LineNumber, Rules.ClosingParenthesisMustBeOnLineOfLastParameter);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Checks a method invocation expression to make that the parameters are positioned correctly.
        /// </summary>
        /// <param name="element">
        /// The element containing the expression.
        /// </param>
        /// <param name="expression">
        /// The expression to check.
        /// </param>
        private void CheckMethodInvocationParameters(CsElement element, MethodInvocationExpression expression)
        {
            Param.AssertNotNull(element, "element");
            Param.AssertNotNull(expression, "expression");

            if (expression.Tokens.First != null && !expression.Tokens.First.Value.Generated)
            {
                ArgumentList argumentList = new ArgumentList(expression.Arguments);
                CsTokenList argumentListTokens = GetArgumentListTokens(
                    expression.Tokens, expression.Name.Tokens.Last, CsTokenType.OpenParenthesis, CsTokenType.CloseParenthesis);

                if (argumentListTokens != null)
                {
                    this.CheckParameters(
                        element, 
                        argumentListTokens, 
                        argumentList, 
                        expression.LineNumber, 
                        CsTokenType.OpenParenthesis, 
                        CsTokenType.CloseParenthesis, 
                        element.FriendlyTypeText);
                }
            }
        }

        /// <summary>
        /// Checks a method or method invocation to ensure that the opening bracket is
        /// on the same line as the method declaration.
        /// </summary>
        /// <param name="element">
        /// The element containing the expression.
        /// </param>
        /// <param name="parameterListTokens">
        /// The tokens in the parameter list.
        /// </param>
        /// <param name="openingBracketType">
        /// The type of the bracket that opens the parameter list.
        /// </param>
        /// <param name="textToUseForContainingElement">
        /// The text to use in the violation.
        /// </param>
        /// <returns>
        /// Returns the opening bracket.
        /// </returns>
        private Node<CsToken> CheckMethodOpeningBracket(
            CsElement element, CsTokenList parameterListTokens, CsTokenType openingBracketType, string textToUseForContainingElement)
        {
            Param.AssertNotNull(element, "element");
            Param.AssertNotNull(parameterListTokens, "parameterListTokens");
            Param.Ignore(openingBracketType);

            // Find the opening bracket.
            Node<CsToken> openingBracketNode = null;

            for (Node<CsToken> tokenNode = parameterListTokens.First; tokenNode != null; tokenNode = tokenNode.Next)
            {
                if (tokenNode.Value.CsTokenType == openingBracketType)
                {
                    openingBracketNode = tokenNode;
                    break;
                }
            }

            CsToken lastWord = null;

            if (openingBracketNode != null)
            {
                // Find the last word before the opening bracket.
                for (Node<CsToken> tokenNode = openingBracketNode.Previous; tokenNode != null; tokenNode = tokenNode.Previous)
                {
                    if (tokenNode.Value.CsTokenType != CsTokenType.WhiteSpace && tokenNode.Value.CsTokenType != CsTokenType.EndOfLine
                        && tokenNode.Value.CsTokenType != CsTokenType.SingleLineComment && tokenNode.Value.CsTokenType != CsTokenType.MultiLineComment)
                    {
                        lastWord = tokenNode.Value;
                        break;
                    }
                }
            }

            if (lastWord != null)
            {
                if (openingBracketNode.Value.LineNumber != lastWord.LineNumber)
                {
                    this.AddViolation(element, openingBracketNode.Value.LineNumber, Rules.OpeningParenthesisMustBeOnDeclarationLine, textToUseForContainingElement);
                }
            }

            return openingBracketNode;
        }

        /// <summary>
        /// Processes the given element.
        /// </summary>
        /// <param name="element">
        /// The element being visited.
        /// </param>
        private void CheckMethodParameters(CsElement element)
        {
            Param.AssertNotNull(element, "element");

            IList<Parameter> parameters = null;
            CsTokenType openBracketType = CsTokenType.OpenParenthesis;
            CsTokenType closeBracketType = CsTokenType.CloseParenthesis;

            if (element.ElementType == ElementType.Constructor)
            {
                parameters = ((Constructor)element).Parameters;
            }
            else if (element.ElementType == ElementType.Delegate)
            {
                parameters = ((Delegate)element).Parameters;
            }
            else if (element.ElementType == ElementType.Method)
            {
                parameters = ((Method)element).Parameters;
            }
            else if (element.ElementType == ElementType.Indexer)
            {
                parameters = ((Indexer)element).Parameters;
                openBracketType = CsTokenType.OpenSquareBracket;
                closeBracketType = CsTokenType.CloseSquareBracket;
            }

            if (parameters != null)
            {
                ParameterList parameterList = new ParameterList(parameters);
                CsTokenList parameterListTokens = GetParameterListTokens(element.Declaration.Tokens, openBracketType, closeBracketType);
                if (parameterListTokens != null)
                {
                    this.CheckParameters(element, parameterListTokens, parameterList, element.LineNumber, openBracketType, closeBracketType, element.FriendlyTypeText);
                }
            }
        }

        /// <summary>
        /// Checks the placement and formatting of parameters to a method invocation or a method declaration.
        /// </summary>
        /// <param name="element">
        /// The element.
        /// </param>
        /// <param name="parameterListTokens">
        /// The tokens that form the parameter list.
        /// </param>
        /// <param name="methodArguments">
        /// The arguments or parameters to the method.
        /// </param>
        /// <param name="methodStartLineNumber">
        /// The line number on which the method begins.
        /// </param>
        /// <param name="openBracketType">
        /// The type of the parameter list opening bracket.
        /// </param>
        /// <param name="closeBracketType">
        /// The type of the parameter list closing bracket.
        /// </param>
        /// <param name="friendlyTypeText">
        /// The text to use for violations.
        /// </param>
        private void CheckParameters(
            CsElement element, 
            CsTokenList parameterListTokens, 
            IArgumentList methodArguments, 
            int methodStartLineNumber, 
            CsTokenType openBracketType, 
            CsTokenType closeBracketType, 
            string friendlyTypeText)
        {
            Param.AssertNotNull(element, "element");
            Param.AssertNotNull(parameterListTokens, "parameterListTokens");
            Param.AssertNotNull(methodArguments, "methodArguments");
            Param.AssertGreaterThanZero(methodStartLineNumber, "methodStartLineNumber");
            Param.Ignore(openBracketType);
            Param.Ignore(closeBracketType);

            Node<CsToken> openingBracketNode = this.CheckMethodOpeningBracket(element, parameterListTokens, openBracketType, friendlyTypeText);

            if (openingBracketNode != null)
            {
                this.CheckMethodClosingBracket(element, parameterListTokens, openingBracketNode, closeBracketType, methodArguments);

                if (methodArguments.Count > 0)
                {
                    this.CheckMethodArgumentList(element, methodArguments, openingBracketNode, methodStartLineNumber, friendlyTypeText);
                }
            }
        }

        /// <summary>
        /// Checks the positioning of method parameters which are split across multiple lines.
        /// </summary>
        /// <param name="element">
        /// The element.
        /// </param>
        /// <param name="arguments">
        /// The method arguments.
        /// </param>
        /// <param name="openingBracketNode">
        /// The opening bracket token.
        /// </param>
        /// <param name="friendlyTypeText">
        /// The friendly type text to use in reporting violations.
        /// </param>
        private void CheckSplitMethodArgumentList(CsElement element, IArgumentList arguments, Node<CsToken> openingBracketNode, string friendlyTypeText)
        {
            Param.AssertNotNull(element, "element");
            Param.AssertNotNull(arguments, "arguments");
            Param.AssertNotNull(openingBracketNode, "openingBracketNode");

            Node<CsToken> previousComma = null;
            bool commaOnSameLineAsPreviousParameterViolation = false;

            for (int i = 0; i < arguments.Count; ++i)
            {
                CodeLocation location = arguments.Location(i);
                int argumentStartLine = location.LineNumber;

                CsTokenList tokens = arguments.Tokens(i);

                // Some types of parameters or arguments are not allowed to span across multiple lines.
                if (location.LineSpan > 1 && !arguments.MaySpanMultipleLines(i))
                {
                    this.AddViolation(element, argumentStartLine, Rules.ParameterMustNotSpanMultipleLines);
                }

                if (i == 0)
                {
                    // The first argument must start on the line after the opening bracket
                    if (argumentStartLine != openingBracketNode.Value.LineNumber + 1)
                    {
                        int commentLineSpan = MeasureCommentLinesAfter(openingBracketNode);

                        if (argumentStartLine != openingBracketNode.Value.LineNumber + commentLineSpan + 1)
                        {
                            this.AddViolation(element, argumentStartLine, Rules.SplitParametersMustStartOnLineAfterDeclaration, friendlyTypeText);
                        }
                    }
                }
                else
                {
                    // The parameter must begin on the line after the previous comma.
                    Debug.Assert(previousComma != null, "The previous comma should have been set.");
                    if (!commaOnSameLineAsPreviousParameterViolation)
                    {
                        if (argumentStartLine != previousComma.Value.LineNumber + 1)
                        {
                            int commentLineSpan = MeasureCommentLinesAfter(previousComma);

                            if (argumentStartLine != previousComma.Value.LineNumber + commentLineSpan + 1)
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
                    for (Node<CsToken> tokenNode = tokens.Last.Next; tokenNode != null; tokenNode = tokenNode.Next)
                    {
                        if (tokenNode.Value.CsTokenType == CsTokenType.Comma)
                        {
                            previousComma = tokenNode;

                            // The comma must be on the same line as the previous parameter.
                            if (previousComma.Value.LineNumber != location.EndPoint.LineNumber)
                            {
                                int commentLineSpan = MeasureCommentLinesBetween(tokens.Last, previousComma, false);

                                if (previousComma.Value.LineNumber != location.EndPoint.LineNumber + commentLineSpan)
                                {
                                    this.AddViolation(element, tokenNode.Value.LineNumber, Rules.CommaMustBeOnSameLineAsPreviousParameter);
                                    commaOnSameLineAsPreviousParameterViolation = true;
                                }
                            }

                            break;
                        }
                    }
                }
            }
        }

        #endregion

        /// <summary>
        /// Represents a list of arguments.
        /// </summary>
        private class ArgumentList : IArgumentList
        {
            #region Fields

            /// <summary>
            /// The list of arguments.
            /// </summary>
            private readonly IList<Argument> arguments;

            #endregion

            #region Constructors and Destructors

            /// <summary>
            /// Initializes a new instance of the ArgumentList class.
            /// </summary>
            /// <param name="arguments">
            /// The list of arguments.
            /// </param>
            public ArgumentList(IList<Argument> arguments)
            {
                Param.AssertNotNull(arguments, "arguments");
                this.arguments = arguments;
            }

            #endregion

            #region Public Properties

            /// <summary>
            /// Gets the number of arguments in the list.
            /// </summary>
            public int Count
            {
                get
                {
                    return this.arguments.Count;
                }
            }

            #endregion

            #region Public Methods and Operators

            /// <summary>
            /// Gets the location of one of the arguments in the list.
            /// </summary>
            /// <param name="index">
            /// The index of an argument in the list.
            /// </param>
            /// <returns>
            /// Returns the location of the arguments.
            /// </returns>
            public CodeLocation Location(int index)
            {
                Param.AssertValueBetween(index, 0, this.arguments.Count - 1, "index");

                // The location must be calculated by finding the first and last tokens
                // in the argument and joining their locations.
                CsTokenList tokens = this.arguments[index].Tokens;

                CsToken firstToken = null;
                for (Node<CsToken> tokenNode = tokens.First.Previous; tokenNode != null; tokenNode = tokenNode.Previous)
                {
                    if (tokenNode.Value.CsTokenType == CsTokenType.Comma || tokenNode.Value.CsTokenType == CsTokenType.OpenSquareBracket
                        || tokenNode.Value.CsTokenType == CsTokenType.OpenParenthesis)
                    {
                        // We've found the start of the parameter list. Now move forward to find the first word.
                        for (tokenNode = tokenNode.Next; tokenNode != null; tokenNode = tokenNode.Next)
                        {
                            if (tokenNode.Value.CsTokenType != CsTokenType.WhiteSpace && tokenNode.Value.CsTokenType != CsTokenType.EndOfLine
                                && tokenNode.Value.CsTokenType != CsTokenType.SingleLineComment && tokenNode.Value.CsTokenType != CsTokenType.MultiLineComment)
                            {
                                firstToken = tokenNode.Value;
                                break;
                            }
                        }

                        break;
                    }
                }

                if (firstToken != null)
                {
                    return CodeLocation.Join(firstToken.Location, tokens.Last.Value.Location);
                }

                return this.arguments[index].Location;
            }

            /// <summary>
            /// Indicates whether an argument is allowed to span across multiple lines.
            /// </summary>
            /// <param name="index">
            /// The index of an argument in the list.
            /// </param>
            /// <returns>
            /// Returns true if the argument is allowed to span across multiple lines.
            /// </returns>
            public bool MaySpanMultipleLines(int index)
            {
                Param.AssertValueBetween(index, 0, this.arguments.Count - 1, "index");

                // The first argument in an argument list is always allowed to span across multiple lines.
                if (index == 0)
                {
                    return true;
                }

                // An anonymous method expression or lambda expression passed in as an argument is always allowed
                // to span multiple lines. Other types of arguments are not.
                // Multi line arguments to a constructor initializer are allowed.
                Expression expression = this.arguments[index].Expression;

                if (expression.ExpressionType == ExpressionType.MethodInvocation)
                {
                    if (expression.ChildExpressions.Count > 0
                        && expression.ChildExpressions.Any(
                            childExpression =>
                            childExpression.ExpressionType == ExpressionType.Lambda || childExpression.ExpressionType == ExpressionType.AnonymousMethod
                            || childExpression.ExpressionType == ExpressionType.New))
                    {
                        return true;
                    }
                }

                return expression.ExpressionType == ExpressionType.Lambda || expression.ExpressionType == ExpressionType.AnonymousMethod
                       || expression.ExpressionType == ExpressionType.New;
            }

            /// <summary>
            /// Gets the token list for one of the arguments in the list.
            /// </summary>
            /// <param name="index">
            /// The index of an argument in the list.
            /// </param>
            /// <returns>
            /// Returns the list of tokens for the argument.
            /// </returns>
            public CsTokenList Tokens(int index)
            {
                Param.AssertValueBetween(index, 0, this.arguments.Count - 1, "index");
                return this.arguments[index].Tokens;
            }

            #endregion
        }

        /// <summary>
        /// Represents a list of parameters.
        /// </summary>
        private class ParameterList : IArgumentList
        {
            #region Fields

            /// <summary>
            /// The list of parameters.
            /// </summary>
            private readonly IList<Parameter> parameters;

            #endregion

            #region Constructors and Destructors

            /// <summary>
            /// Initializes a new instance of the ParameterList class.
            /// </summary>
            /// <param name="parameters">
            /// The list of parameters.
            /// </param>
            public ParameterList(IList<Parameter> parameters)
            {
                Param.AssertNotNull(parameters, "parameters");
                this.parameters = parameters;
            }

            #endregion

            #region Public Properties

            /// <summary>
            /// Gets the number of parameters in the list.
            /// </summary>
            public int Count
            {
                get
                {
                    return this.parameters.Count;
                }
            }

            #endregion

            #region Public Methods and Operators

            /// <summary>
            /// Gets the location of one of the parameters in the list.
            /// </summary>
            /// <param name="index">
            /// The index of a parameter in the list.
            /// </param>
            /// <returns>
            /// Returns the location of the parameters.
            /// </returns>
            public CodeLocation Location(int index)
            {
                Param.AssertValueBetween(index, 0, this.parameters.Count - 1, "index");

                // The location must be calculated by finding the first and last tokens
                // in the parameter and joining their locations.
                CsTokenList tokens = this.parameters[index].Tokens;

                CsToken firstToken = null;
                for (Node<CsToken> tokenNode = tokens.First.Previous; tokenNode != null; tokenNode = tokenNode.Previous)
                {
                    if (tokenNode.Value.CsTokenType == CsTokenType.Comma || tokenNode.Value.CsTokenType == CsTokenType.OpenSquareBracket
                        || tokenNode.Value.CsTokenType == CsTokenType.OpenParenthesis)
                    {
                        // We've found the start of the parameter list. Now move forward to find the first word.
                        for (tokenNode = tokenNode.Next; tokenNode != null; tokenNode = tokenNode.Next)
                        {
                            if (tokenNode.Value.CsTokenType != CsTokenType.Attribute && tokenNode.Value.CsTokenType != CsTokenType.WhiteSpace
                                && tokenNode.Value.CsTokenType != CsTokenType.EndOfLine && tokenNode.Value.CsTokenType != CsTokenType.SingleLineComment
                                && tokenNode.Value.CsTokenType != CsTokenType.MultiLineComment)
                            {
                                firstToken = tokenNode.Value;
                                break;
                            }
                        }

                        break;
                    }
                }

                if (firstToken != null)
                {
                    return CodeLocation.Join(firstToken.Location, tokens.Last.Value.Location);
                }

                return this.parameters[index].Location;
            }

            /// <summary>
            /// Indicates whether a parameter is allowed to span across multiple lines.
            /// </summary>
            /// <param name="index">
            /// The index of a parameter in the list.
            /// </param>
            /// <returns>
            /// Returns true if the parameter is allowed to span across multiple lines.
            /// </returns>
            public bool MaySpanMultipleLines(int index)
            {
                Param.Ignore(index);

                // In a method declaration, none of the parameters are allowed to span across multiple lines.
                return false;
            }

            /// <summary>
            /// Gets the token list for one of the parameters in the list.
            /// </summary>
            /// <param name="index">
            /// The index of a parameter in the list.
            /// </param>
            /// <returns>
            /// Returns the list of tokens for the parameter.
            /// </returns>
            public CsTokenList Tokens(int index)
            {
                Param.AssertValueBetween(index, 0, this.parameters.Count - 1, "index");
                return this.parameters[index].Tokens;
            }

            #endregion
        }
    }
}