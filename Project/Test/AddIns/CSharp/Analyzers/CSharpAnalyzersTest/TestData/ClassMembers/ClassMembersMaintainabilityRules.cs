//-----------------------------------------------------------------------
// <copyright file="MaintainabilityRules.cs">
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
//-----------------------------------------------------------------------
namespace CSharpAnalyzersTest.TestData.ClassMembers
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Xml;
    using StyleCop;
    using StyleCop.CSharp;

    /// <summary>
    /// Checks compliance with the maintainability rules.
    /// </summary>
    [SourceAnalyzer(typeof(CsParser))]
    public class MaintainabilityRules : SourceAnalyzer
    {
        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the MaintainabilityRules class.
        /// </summary>
        public MaintainabilityRules()
        {
        }

        #endregion Public Constructors

        #region Public Override Methods

        /// <summary>
        /// Checks the methods within the given document.
        /// </summary>
        /// <param name="document">The document to check.</param>
        public override void AnalyzeDocument(CodeDocument document)
        {
            Param.RequireNotNull(document, "document");

            CsDocument csdocument = (CsDocument)document;

            if (csdocument.RootElement != null && !csdocument.RootElement.Generated)
            {
                // Check the access modifier rules.
                TopLevelElements topLevelElements = new TopLevelElements();

                csdocument.WalkDocument<TopLevelElements>(
                    new CodeWalkerElementVisitor<TopLevelElements>(this.ProcessElement),
                    new CodeWalkerStatementVisitor<TopLevelElements>(this.ProcessStatement),
                    new CodeWalkerExpressionVisitor<TopLevelElements>(this.ProcessExpression),
                    topLevelElements);

                // If there is more than one top-level class in the file, make sure they are all
                // partial classes and are all of the same type.
                if (topLevelElements.Classes.Count > 1)
                {
                    string name = string.Empty;
                    foreach (Class classElement in topLevelElements.Classes)
                    {
                        if (!classElement.Declaration.ContainsModifier(CsTokenType.Partial) ||
                            (!string.IsNullOrEmpty(name) && string.Compare(name, classElement.FullNamespaceName, StringComparison.Ordinal) != 0))
                        {
                            // Set the violation line number to the second class in the file.
                            int count = 0;
                            foreach (Class c in topLevelElements.Classes)
                            {
                                if (count == 1)
                                {
                                    this.AddViolation(c, c.LineNumber, Rules.FileMayOnlyContainASingleClass);
                                    break;
                                }

                                ++count;
                            }

                            break;
                        }

                        name = classElement.FullNamespaceName;
                    }
                }

                // If there is more than one namespace in the file, this is a violation.
                if (topLevelElements.Namespaces.Count > 1)
                {
                    // Set the violation line number to the second namespace in the file.
                    int count = 0;
                    foreach (Namespace n in topLevelElements.Namespaces)
                    {
                        if (count == 1)
                        {
                            this.AddViolation(n, n.LineNumber, Rules.FileMayOnlyContainASingleNamespace);
                            break;
                        }

                        ++count;
                    }
                }
            }
        }

        /// <inheritdoc />
        public override bool DoAnalysis(CodeDocument document)
        {
            Param.RequireNotNull(document, "document");

            CsDocument csdocument = (CsDocument)document;

            return csdocument.FileHeader == null || !csdocument.FileHeader.UnStyled;
        }

        #endregion Public Override Methods

        #region Private Static Methods

        /// <summary>
        /// Processes the given element.
        /// </summary>
        /// <param name="element">The element being visited.</param>
        /// <param name="parentElement">The parent of the element.</param>
        /// <param name="topLevelElements">The number of classes and namespaces seen in the document.</param>
        private static void CheckFileContents(
            CsElement element, CsElement parentElement, TopLevelElements topLevelElements)
        {
            Param.AssertNotNull(element, "element");
            Param.Ignore(parentElement);
            Param.AssertNotNull(topLevelElements, "topLevelElements");

            if (element.ElementType == ElementType.Class)
            {
                if (parentElement == null ||
                    parentElement.ElementType == ElementType.Root ||
                    parentElement.ElementType == ElementType.Namespace)
                {
                    topLevelElements.Classes.Add((Class)element);
                }
            }
            else if (element.ElementType == ElementType.Namespace)
            {
                topLevelElements.Namespaces.Add((Namespace)element);
            }
        }

        /// <summary>
        /// Determines whether the given text contains an empty string, which can be represented as "" or @"".
        /// </summary>
        /// <param name="text">The text to check.</param>
        /// <returns>Returns true if the </returns>
        private static bool IsEmptyString(string text)
        {
            Param.AssertNotNull(text, "text");

            // A string is always considered empty if it is two characters or less, because then it must have at least
            // the opening and closing quotes plus something in between.
            if (text.Length > 2)
            {
                // If this is a literal string, then it must be more than three characters.
                if (text[0] == '@')
                {
                    if (text.Length > 3)
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            // This is an empty string.
            return true;
        }

        /// <summary>
        /// Determines whether the given method invocation expression contains a code analysis SuppressMessage call.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <returns>Returns true if the method is SuppressMessage.</returns>
        private static bool IsSuppressMessage(MethodInvocationExpression expression)
        {
            Param.AssertNotNull(expression, "expression");

            Node<CsToken> first = expression.Name.Tokens.First;
            if (first != null)
            {
                string text = first.Value.Text;
                if (text.Equals("SuppressMessage", StringComparison.Ordinal) || text.Equals("SuppressMessageAttribute", StringComparison.Ordinal))
                {
                    return true;
                }

                string expressionText = expression.Name.Text;
                if (expressionText.EndsWith(".SuppressMessage", StringComparison.Ordinal) || expressionText.EndsWith(".SuppressMessageAttribute", StringComparison.Ordinal))
                {
                    return true;
                }

                if (text.Equals("System"))
                {
                    if (expression.Name.Tokens.MatchTokens(new[] { "System", ".", "Diagnostics", ".", "CodeAnalysis", ".", "SuppressMessage" }) ||
                   expression.Name.Tokens.MatchTokens(new[] { "System", ".", "Diagnostics", ".", "CodeAnalysis", ".", "SuppressMessageAttribute" }))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Checks the statement, which is a parent of a block statement, to make sure that it is not empty.
        /// </summary>
        /// <param name="statement">The statement to check.</param>
        /// <returns>Returns true if the statement was empty.</returns>
        private static bool IsEmptyParentOfBlockStatement(Statement statement)
        {
            Param.AssertNotNull(statement, "statement");

            // Find the block statement under this statement.
            foreach (Statement childStatement in statement.ChildStatements)
            {
                if (childStatement.StatementType == StatementType.Block)
                {
                    if (childStatement.ChildStatements == null || childStatement.ChildStatements.Count == 0)
                    {
                        return true;
                    }

                    break;
                }
            }

            return false;
        }

        /// <summary>
        /// Checks the element, to indicate whether it is empty or unnecessary.
        /// </summary>
        /// <param name="element">The element to check.</param>
        /// <returns>Returns true if the statement was empty.</returns>
        private static bool IsEmptyElement(CsElement element)
        {
            Param.AssertNotNull(element, "element");

            if ((element.ChildElements != null && element.ChildElements.Count > 0) ||
                (element.ChildStatements != null && element.ChildStatements.Count > 0))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Checks the given try statement to make sure that it is needed.
        /// </summary>
        /// <param name="tryStatement">The try statement to check.</param>
        /// <returns>Returns true if the try statement is not needed, false otherwise.</returns>
        private static bool IsUnnecessaryTryStatement(TryStatement tryStatement)
        {
            Param.AssertNotNull(tryStatement, "tryStatement");

            // If the body of the try-statement is empty, it is not needed.
            if (IsEmptyParentOfBlockStatement(tryStatement))
            {
                // If the try-statement contains a non-empty finally or a non-empty catch statement, then it is allowed to be empty.
                // This is because an empty try-statement can be used to create a critical execution region and the finally or catch areas
                // will run even in the case of a ThreadAbortException.
                if (tryStatement.FinallyStatement != null && !IsEmptyParentOfBlockStatement(tryStatement.FinallyStatement))
                {
                    return false;
                }

                if (tryStatement.CatchStatements != null && tryStatement.CatchStatements.Count > 0)
                {
                    foreach (CatchStatement catchStatement in tryStatement.CatchStatements)
                    {
                        if (!IsEmptyParentOfBlockStatement(catchStatement))
                        {
                            return false;
                        }
                    }
                }

                return true;
            }
            else
            {
                // If the try-statement does not contain any catch statements or finally statements, it is not needed.
                if (tryStatement.CatchStatements == null || tryStatement.CatchStatements.Count == 0)
                {
                    if (tryStatement.FinallyStatement == null || IsEmptyParentOfBlockStatement(tryStatement.FinallyStatement))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Determine whether the argument passed in is equivalent to ""
        /// </summary>
        /// <param name="argument">The Argument to check.</param>
        /// <returns>True if equivalent to string.empty otherwise false.</returns>
        private static bool ArgumentTokensMatchStringEmpty(Argument argument)
        {
            CsToken firstToken = argument.Tokens.First.Value;

            if (firstToken.CsTokenType == CsTokenType.String && IsEmptyString(firstToken.Text))
            {
                return true;
            }

            if (firstToken.CsTokenType == CsTokenType.Null)
            {
                return true;
            }

            if (argument.Tokens.MatchTokens(StringComparison.OrdinalIgnoreCase, "string", ".", "empty"))
            {
                return true;
            }

            if (argument.Tokens.MatchTokens(StringComparison.OrdinalIgnoreCase, "system", ".", "string", ".", "empty"))
            {
                return true;
            }

            if (argument.Tokens.MatchTokens(StringComparison.OrdinalIgnoreCase, "global", "::", "system", ".", "string", ".", "empty"))
            {
                return true;
            }

            return false;
        }

        #endregion Private Static Methods

        #region Private Methods

        /// <summary>
        /// Processes the given element.
        /// </summary>
        /// <param name="element">The element being visited.</param>
        /// <param name="parentElement">The parent element, if any.</param>
        /// <param name="topLevelElements">The number of classes and namespaces seen in the document.</param>
        /// <returns>Returns true to continue, or false to stop the walker.</returns>
        private bool ProcessElement(
            CsElement element,
            CsElement parentElement,
            TopLevelElements topLevelElements)
        {
            Param.AssertNotNull(element, "element");
            Param.Ignore(parentElement);
            Param.AssertNotNull(topLevelElements, "topLevelElements");

            this.CheckAccessModifierRulesForElement(element);
            this.CheckCodeAnalysisAttributeJustifications(element);
            this.CheckForEmptyElements(element);
            CheckFileContents(element, parentElement, topLevelElements);

            this.CheckParenthesisForAttributeConstructors(element);
            return true;
        }

        /// <summary>
        /// Checks that empty parenthesis do not exist for attributes.
        /// </summary>
        /// <param name="element">The element to check.</param>
        private void CheckParenthesisForAttributeConstructors(CsElement element)
        {
            Param.AssertNotNull(element, "element");

            if (element.Attributes != null && element.Attributes.Count > 0)
            {
                foreach (var attribute in element.Attributes)
                {
                    var attributeExpressions = attribute.AttributeExpressions;

                    foreach (var attributeExpression in attributeExpressions)
                    {
                        if (attributeExpression.Initialization.ExpressionType == ExpressionType.MethodInvocation)
                        {
                            var invocationExpression = (MethodInvocationExpression)attributeExpression.Initialization;

                            if (invocationExpression.Arguments.Count == 0)
                            {
                                var elementTokens = attribute.ChildTokens;

                                // Check for parenthesis.
                                for (Node<CsToken> tokenNode = elementTokens.First; tokenNode != elementTokens.Last; tokenNode = tokenNode.Next)
                                {
                                    if (tokenNode.Value.CsTokenType == CsTokenType.OpenParenthesis)
                                    {
                                        Node<CsToken> nextToken = tokenNode.Next;
                                        if (nextToken.Value.CsTokenType == CsTokenType.CloseParenthesis)
                                        {
                                            this.AddViolation(element, tokenNode.Value.LineNumber, Rules.AttributeConstructorMustNotUseUnnecessaryParenthesis);
                                        }

                                        break;
                                    }
                                }
                            }

                            break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Checks the access modifier on the element.
        /// </summary>
        /// <param name="element">The element being visited.</param>
        private void CheckAccessModifierRulesForElement(CsElement element)
        {
            Param.AssertNotNull(element, "element");

            // Make sure this element is not generated.
            if (!element.Generated)
            {
                // Skip these rules if the element is a child of an interface.
                CsElement parent = element.FindParentElement();
                if (parent == null || parent.ElementType != ElementType.Interface)
                {
                    this.CheckForAccessModifier(element);
                    this.CheckFieldAccessModifiers(element);
                }
            }
        }

        /// <summary>
        /// Verifies that elements have access modifiers.
        /// </summary>
        /// <param name="element">The element to check.</param>
        private void CheckForAccessModifier(CsElement element)
        {
            Param.AssertNotNull(element, "element");

            if (element.ElementType == ElementType.Method ||
                element.ElementType == ElementType.Property ||
                element.ElementType == ElementType.Indexer ||
                element.ElementType == ElementType.Event)
            {
                // A Method, property, indexer or event must have access an modifier unless it
                // is an explicit implementation of an interface member, in which case it is public by
                // default and you are not allowed to specify an access modifier. Partial methods are not allowed
                // to have access modifier so we skip those as well.
                if (!element.Declaration.AccessModifier && !element.Declaration.ContainsModifier(CsTokenType.Partial))
                {
                    if (element.Name.IndexOf(".", StringComparison.Ordinal) == -1 ||
                        element.Name.StartsWith("this.", StringComparison.Ordinal))
                    {
                        this.AddViolation(element, Rules.AccessModifierMustBeDeclared, element.FriendlyTypeText);
                    }
                }
            }
            else if (element.ElementType == ElementType.Class ||
                element.ElementType == ElementType.Field ||
                element.ElementType == ElementType.Enum ||
                element.ElementType == ElementType.Struct ||
                element.ElementType == ElementType.Interface ||
                element.ElementType == ElementType.Delegate)
            {
                if (!element.Declaration.AccessModifier)
                {
                    this.AddViolation(element, Rules.AccessModifierMustBeDeclared, element.FriendlyTypeText);
                }
            }
            else if (element.ElementType == ElementType.Constructor)
            {
                // If a constructor is not static it must have an access modifier.
                if (!element.Declaration.AccessModifier && !element.Declaration.ContainsModifier(CsTokenType.Static))
                {
                    this.AddViolation(element, Rules.AccessModifierMustBeDeclared, element.FriendlyTypeText);
                }
            }
        }

        /// <summary>
        /// Verifies that fields are not declared public.
        /// </summary>
        /// <param name="element">The element to check.</param>
        private void CheckFieldAccessModifiers(CsElement element)
        {
            Param.AssertNotNull(element, "element");

            CsElement parent = element.FindParentElement();

            if (element.ElementType == ElementType.Field &&
                (element.Declaration.AccessModifierType != AccessModifierType.Private) &&
                parent != null &&
                parent.ElementType != ElementType.Struct)
            {
                // If the field is located within a native methods class, and the class that contains
                // the field is private or internal, then do not check the access modifiers on the field.
                bool nativeMethods = false;
                bool privateOrInternal = false;
                while (parent != null)
                {
                    if (parent.ElementType != ElementType.Class && parent.ElementType != ElementType.Struct)
                    {
                        break;
                    }

                    if (parent.ActualAccess == AccessModifierType.Private ||
                        parent.ActualAccess == AccessModifierType.Internal)
                    {
                        privateOrInternal = true;
                    }

                    if (parent.Declaration.Name.EndsWith("NativeMethods", StringComparison.Ordinal))
                    {
                        nativeMethods = true;
                        break;
                    }

                    parent = parent.FindParentElement();
                }

                if (!nativeMethods || !privateOrInternal)
                {
                    Field field = (Field)element;
                    if (!field.Const && !field.Readonly && !field.Generated)
                    {
                        this.AddViolation(element, Rules.FieldsMustBePrivate);
                    }
                }
            }
        }

        /// <summary>
        /// Checks any code analysis SupressMessage attributes on the element to make sure
        /// they all have justification text.
        /// </summary>
        /// <param name="element">The element being visited.</param>
        private void CheckCodeAnalysisAttributeJustifications(CsElement element)
        {
            Param.AssertNotNull(element, "element");

            // Make sure this element is not generated.
            if (!element.Generated && element.Attributes != null)
            {
                foreach (Attribute attribute in element.Attributes)
                {
                    foreach (AttributeExpression expression in attribute.AttributeExpressions)
                    {
                        foreach (Expression childExpression in expression.ChildExpressions)
                        {
                            if (childExpression.ExpressionType == ExpressionType.MethodInvocation)
                            {
                                MethodInvocationExpression methodInvocation = (MethodInvocationExpression)childExpression;

                                if (IsSuppressMessage(methodInvocation))
                                {
                                    // This is a suppression. Determine whether it contains a justification.
                                    this.CheckCodeAnalysisSuppressionForJustification(element, methodInvocation);
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Checks the given code analysis suppression call to ensure that it contains a justifiction parameter.
        /// </summary>
        /// <param name="element">The element that contains the suppression attribute.</param>
        /// <param name="suppression">The suppression to check.</param>
        private void CheckCodeAnalysisSuppressionForJustification(CsElement element, MethodInvocationExpression suppression)
        {
            Param.AssertNotNull(element, "element");
            Param.AssertNotNull(suppression, "suppression");

            bool justification = false;
            foreach (Argument argument in suppression.Arguments)
            {
                if (argument.Expression.ExpressionType == ExpressionType.Assignment)
                {
                    AssignmentExpression assignmentExpression = (AssignmentExpression)argument.Expression;
                    if (assignmentExpression.LeftHandSide.Tokens.First.Value.Text.Equals("Justification", StringComparison.Ordinal))
                    {
                        Expression rightHandSide = assignmentExpression.RightHandSide;

                        if (rightHandSide == null || rightHandSide.Tokens == null)
                        {
                            break;
                        }

                        Node<CsToken> rightSideTokenNode = rightHandSide.Tokens.First;
                        if (rightSideTokenNode == null)
                        {
                            break;
                        }

                        if (rightHandSide.ExpressionType == ExpressionType.MemberAccess)
                        {
                            justification = true;
                            break;
                        }

                        if (rightSideTokenNode.Value.CsTokenType == CsTokenType.Other && rightHandSide.ExpressionType == ExpressionType.Literal)
                        {
                            justification = true;
                            break;
                        }

                        if (rightSideTokenNode.Value.CsTokenType == CsTokenType.String && rightSideTokenNode.Value.Text != null && !IsEmptyString(rightSideTokenNode.Value.Text))
                        {
                            justification = true;
                            break;
                        }
                    }
                }
            }

            if (!justification)
            {
                this.AddViolation(element, suppression.LineNumber, Rules.CodeAnalysisSuppressionMustHaveJustification);
            }
        }

        /// <summary>
        /// Called when a statement is visited.
        /// </summary>
        /// <param name="statement">The statement being visited.</param>
        /// <param name="parentExpression">The parent expression, if any.</param>
        /// <param name="parentStatement">The parent statement, if any.</param>
        /// <param name="parentElement">The parent element, if any.</param>
        /// <param name="context">The optional visitor context data.</param>
        /// <returns>Returns true to continue, or false to stop the walker.</returns>
        private bool ProcessStatement(
            Statement statement,
            Expression parentExpression,
            Statement parentStatement,
            CsElement parentElement,
            TopLevelElements context)
        {
            Param.AssertNotNull(statement, "statement");
            Param.Ignore(parentExpression);
            Param.Ignore(parentStatement);
            Param.AssertNotNull(parentElement, "parentElement");
            Param.Ignore(context);

            this.CheckForUnnecessaryStatements(statement, parentElement);

            return true;
        }

        /// <summary>
        /// Checks to see if the statement is unnecessary.
        /// </summary>
        /// <param name="statement">The statement to check.</param>
        /// <param name="parentElement">The parent element of the statement.</param>
        private void CheckForUnnecessaryStatements(Statement statement, CsElement parentElement)
        {
            Param.AssertNotNull(statement, "statement");
            Param.AssertNotNull(parentElement, "parentElement");

            if (!parentElement.Generated)
            {
                if (statement.StatementType == StatementType.Finally ||
                    statement.StatementType == StatementType.Checked ||
                    statement.StatementType == StatementType.Unchecked ||
                    statement.StatementType == StatementType.Lock ||
                    statement.StatementType == StatementType.Unsafe)
                {
                    if (IsEmptyParentOfBlockStatement(statement))
                    {
                        this.AddViolation(parentElement, statement.LineNumber, Rules.RemoveUnnecessaryCode, statement.FriendlyTypeText);
                    }
                }
                else if (statement.StatementType == StatementType.Try)
                {
                    if (IsUnnecessaryTryStatement((TryStatement)statement))
                    {
                        this.AddViolation(parentElement, statement.LineNumber, Rules.RemoveUnnecessaryCode, statement.FriendlyTypeText);
                    }
                }
            }
        }

        /// <summary>
        /// Checks to see if the element is unnecessary.
        /// </summary>
        /// <param name="element">The element to check.</param>
        private void CheckForEmptyElements(CsElement element)
        {
            Param.AssertNotNull(element, "element");

            if (!element.Generated)
            {
                if (element.ElementType == ElementType.Constructor && element.Declaration.ContainsModifier(CsTokenType.Static))
                {
                    if (IsEmptyElement(element))
                    {
                        this.AddViolation(element, Rules.RemoveUnnecessaryCode, element.FriendlyTypeText);
                    }
                }
            }
        }

        /// <summary>
        /// Called when an expression is visited.
        /// </summary>
        /// <param name="expression">The expression being visited.</param>
        /// <param name="parentExpression">The parent expression, if any.</param>
        /// <param name="parentStatement">The parent statement, if any.</param>
        /// <param name="parentElement">The parent element, if any.</param>
        /// <param name="context">The optional visitor context data.</param>
        /// <returns>Returns true to continue, or false to stop the walker.</returns>
        private bool ProcessExpression(
            Expression expression,
            Expression parentExpression,
            Statement parentStatement,
            CsElement parentElement,
            TopLevelElements context)
        {
            Param.AssertNotNull(expression, "expression");
            Param.Ignore(parentExpression);
            Param.Ignore(parentStatement);
            Param.AssertNotNull(parentElement, "parentElement");
            Param.Ignore(context);

            if (!parentElement.Generated)
            {
                // Determine whether this expression is a method invocation which contains call to Debug.Fail or Debug.Assert.
                if (expression.ExpressionType == ExpressionType.MethodInvocation)
                {
                    MethodInvocationExpression methodInvocation = (MethodInvocationExpression)expression;
                    if (methodInvocation.Name.Tokens.MatchTokens("Debug", ".", "Assert") ||
                        methodInvocation.Name.Tokens.MatchTokens("System", ".", "Diagnostics", ".", "Debug", ".", "Assert"))
                    {
                        this.CheckDebugAssertMessage(parentElement, methodInvocation);
                    }
                    else if (methodInvocation.Name.Tokens.MatchTokens("Debug", ".", "Fail") ||
                        methodInvocation.Name.Tokens.MatchTokens("System", ".", "Diagnostics", ".", "Debug", ".", "Fail"))
                    {
                        this.CheckDebugFailMessage(parentElement, methodInvocation);
                    }
                }
                else if (expression.ExpressionType == ExpressionType.Parenthesized)
                {
                    this.CheckParenthesizedExpression(parentElement, (ParenthesizedExpression)expression);
                }
                else if (expression.ExpressionType == ExpressionType.Arithmetic)
                {
                    this.CheckArithmeticExpressionParenthesis(parentElement, (ArithmeticExpression)expression);
                }
                else if (expression.ExpressionType == ExpressionType.ConditionalLogical)
                {
                    this.CheckConditionalLogicalExpressionParenthesis(parentElement, (ConditionalLogicalExpression)expression);
                }
                else if (expression.ExpressionType == ExpressionType.AnonymousMethod)
                {
                    this.CheckAnonymousMethodParenthesis(parentElement, (AnonymousMethodExpression)expression);
                }
            }

            return true;
        }

        /// <summary>
        /// Checks the given call into Debug.Assert to ensure that it contains a valid debug message.
        /// </summary>
        /// <param name="element">The parent element.</param>
        /// <param name="debugAssertMethodCall">The call to Debug.Assert.</param>
        private void CheckDebugAssertMessage(CsElement element, MethodInvocationExpression debugAssertMethodCall)
        {
            Param.AssertNotNull(element, "element");
            Param.AssertNotNull(debugAssertMethodCall, "debugAssertMethodCall");

            // Extract the second argument.
            Argument secondArgument = null;
            if (debugAssertMethodCall.Arguments.Count >= 2)
            {
                secondArgument = debugAssertMethodCall.Arguments[1];
            }

            if (secondArgument == null || secondArgument.Tokens.First == null)
            {
                // There is no message argument or the message argument is empty.
                this.AddViolation(element, debugAssertMethodCall.LineNumber, Rules.DebugAssertMustProvideMessageText);
            }
            else if (ArgumentTokensMatchStringEmpty(secondArgument))
            {
                // The message argument contains an empty string or null.
                this.AddViolation(element, debugAssertMethodCall.LineNumber, Rules.DebugAssertMustProvideMessageText);
            }
        }

        /// <summary>
        /// Checks the given call into Debug.Fail to ensure that it contains a valid debug message.
        /// </summary>
        /// <param name="element">The parent element.</param>
        /// <param name="debugFailMethodCall">The call to Debug.Fail.</param>
        private void CheckDebugFailMessage(CsElement element, MethodInvocationExpression debugFailMethodCall)
        {
            Param.AssertNotNull(element, "element");
            Param.AssertNotNull(debugFailMethodCall, "debugFailMethodCall");

            // Extract the first argument.
            Argument firstArgument = null;
            foreach (Argument argument in debugFailMethodCall.Arguments)
            {
                firstArgument = argument;
                break;
            }

            if (firstArgument == null || firstArgument.Tokens.First == null)
            {
                // There is no message argument or the message argument is empty.
                this.AddViolation(element, debugFailMethodCall.LineNumber, Rules.DebugFailMustProvideMessageText);
            }
            else if (ArgumentTokensMatchStringEmpty(firstArgument))
            {
                // The message argument contains an empty string or null.
                this.AddViolation(element, debugFailMethodCall.LineNumber, Rules.DebugFailMustProvideMessageText);
            }
        }

        /// <summary>
        /// Checks the given parenthesized expression to make sure that it is not unnecessary.
        /// </summary>
        /// <param name="element">The element containing the expression.</param>
        /// <param name="parenthesizedExpression">The parenthesized expression to check.</param>
        private void CheckParenthesizedExpression(CsElement element, ParenthesizedExpression parenthesizedExpression)
        {
            Param.AssertNotNull(element, "element");
            Param.AssertNotNull(parenthesizedExpression, "parenthesizedExpression");

            // Check the type of the inner expression to determine if it is one of types allowed to be wrapped within parenthesis.
            if (parenthesizedExpression.InnerExpression != null)
            {
                // The following types of expressions are allowed to be placed within a set of parenthesis.
                Expression innerExpression = parenthesizedExpression.InnerExpression;
                if (innerExpression.ExpressionType != ExpressionType.Arithmetic &&
                    innerExpression.ExpressionType != ExpressionType.As &&
                    innerExpression.ExpressionType != ExpressionType.Assignment &&
                    innerExpression.ExpressionType != ExpressionType.Cast &&
                    innerExpression.ExpressionType != ExpressionType.Conditional &&
                    innerExpression.ExpressionType != ExpressionType.ConditionalLogical &&
                    innerExpression.ExpressionType != ExpressionType.Decrement &&
                    innerExpression.ExpressionType != ExpressionType.Increment &&
                    innerExpression.ExpressionType != ExpressionType.Is &&
                    innerExpression.ExpressionType != ExpressionType.Lambda &&
                    innerExpression.ExpressionType != ExpressionType.Logical &&
                    innerExpression.ExpressionType != ExpressionType.New &&
                    innerExpression.ExpressionType != ExpressionType.NewArray &&
                    innerExpression.ExpressionType != ExpressionType.NullCoalescing &&
                    innerExpression.ExpressionType != ExpressionType.Query &&
                    innerExpression.ExpressionType != ExpressionType.Relational &&
                    innerExpression.ExpressionType != ExpressionType.Unary &&
                    innerExpression.ExpressionType != ExpressionType.UnsafeAccess)
                {
                    this.AddViolation(element, parenthesizedExpression.Location, Rules.StatementMustNotUseUnnecessaryParenthesis);
                }
                else
                {
                    // These types of expressions are allowed in some cases to be surrounded by parenthesis,
                    // as long as the parenthesized expression is within another expression. They are not allowed
                    // to be within parenthesis within a variable declarator expression. For example:
                    // int x = (2 + 3);
                    if (!(parenthesizedExpression.Parent is Expression) ||
                        parenthesizedExpression.Parent is VariableDeclaratorExpression ||
                        parenthesizedExpression.Parent is CheckedExpression ||
                        parenthesizedExpression.Parent is UncheckedExpression ||
                        parenthesizedExpression.Parent is MethodInvocationExpression)
                    {
                        this.AddViolation(element, parenthesizedExpression.Location, Rules.StatementMustNotUseUnnecessaryParenthesis);
                    }
                    else
                    {
                        // This is also not allowed when the expression is on the right-hand side of an assignment.
                        AssignmentExpression assignment = parenthesizedExpression.Parent as AssignmentExpression;
                        if (assignment != null && assignment.RightHandSide == parenthesizedExpression)
                        {
                            this.AddViolation(element, parenthesizedExpression.Location, Rules.StatementMustNotUseUnnecessaryParenthesis);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Checks that parenthesis are used correctly within an arithmetic expression.
        /// </summary>
        /// <param name="element">The parent element.</param>
        /// <param name="expression">The expression to check.</param>
        private void CheckArithmeticExpressionParenthesis(CsElement element, ArithmeticExpression expression)
        {
            Param.AssertNotNull(element, "element");
            Param.AssertNotNull(expression, "expression");

            if (expression.LeftHandSide.ExpressionType == ExpressionType.Arithmetic)
            {
                if (!this.CheckArithmeticParenthesisForExpressionAndChild(
                    element, expression, (ArithmeticExpression)expression.LeftHandSide))
                {
                    return;
                }
            }

            if (expression.RightHandSide.ExpressionType == ExpressionType.Arithmetic)
            {
                this.CheckArithmeticParenthesisForExpressionAndChild(
                    element, expression, (ArithmeticExpression)expression.RightHandSide);
            }
        }

        /// <summary>
        /// Checks whether parenthesis are needed within the arithmetic expressions.
        /// </summary>
        /// <param name="element">The parent element.</param>
        /// <param name="expression">The parent arithmetic expression.</param>
        /// <param name="childExpression">The child arithmetic expression.</param>
        /// <returns>Returns true if there is no violation, or false if there is a violation.</returns>
        private bool CheckArithmeticParenthesisForExpressionAndChild(
            CsElement element, ArithmeticExpression expression, ArithmeticExpression childExpression)
        {
            Param.AssertNotNull(element, "element");
            Param.AssertNotNull(expression, "expression");
            Param.AssertNotNull(childExpression, "childExpression");

            // Parenthesis are only required when the two expressions are not the same operator,
            // and when the two operators come from different families. 
            if (expression.OperatorType != childExpression.OperatorType)
            {
                bool sameFamily =
                    ((expression.OperatorType == ArithmeticExpression.Operator.Addition ||
                      expression.OperatorType == ArithmeticExpression.Operator.Subtraction) &&
                     (childExpression.OperatorType == ArithmeticExpression.Operator.Addition ||
                      childExpression.OperatorType == ArithmeticExpression.Operator.Subtraction)) ||
                    ((expression.OperatorType == ArithmeticExpression.Operator.Multiplication ||
                      expression.OperatorType == ArithmeticExpression.Operator.Division) &&
                     (childExpression.OperatorType == ArithmeticExpression.Operator.Multiplication ||
                      childExpression.OperatorType == ArithmeticExpression.Operator.Division)) ||
                    ((expression.OperatorType == ArithmeticExpression.Operator.LeftShift ||
                      expression.OperatorType == ArithmeticExpression.Operator.RightShift) &&
                     (childExpression.OperatorType == ArithmeticExpression.Operator.LeftShift ||
                      childExpression.OperatorType == ArithmeticExpression.Operator.RightShift));

                if (!sameFamily)
                {
                    this.AddViolation(element, expression.LineNumber, Rules.ArithmeticExpressionsMustDeclarePrecedence);
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Checks that parenthesis are used correctly within a conditional logical expression.
        /// </summary>
        /// <param name="element">The parent element.</param>
        /// <param name="expression">The expression to check.</param>
        private void CheckConditionalLogicalExpressionParenthesis(
            CsElement element, ConditionalLogicalExpression expression)
        {
            Param.AssertNotNull(element, "element");
            Param.AssertNotNull(expression, "expression");

            if (expression.LeftHandSide.ExpressionType == ExpressionType.ConditionalLogical)
            {
                if (!this.CheckConditionalLogicalParenthesisForExpressionAndChild(
                    element, expression, (ConditionalLogicalExpression)expression.LeftHandSide))
                {
                    return;
                }
            }

            if (expression.RightHandSide.ExpressionType == ExpressionType.ConditionalLogical)
            {
                this.CheckConditionalLogicalParenthesisForExpressionAndChild(
                    element, expression, (ConditionalLogicalExpression)expression.RightHandSide);
            }
        }

        /// <summary>
        /// Checks whether parenthesis are needed within the conditional logical expressions.
        /// </summary>
        /// <param name="element">The parent element.</param>
        /// <param name="expression">The parent conditional logical expression.</param>
        /// <param name="childExpression">The child conditional logical expression.</param>
        /// <returns>Returns true if there is no violation, or false if there is a violation.</returns>
        private bool CheckConditionalLogicalParenthesisForExpressionAndChild(
            CsElement element, ConditionalLogicalExpression expression, ConditionalLogicalExpression childExpression)
        {
            Param.AssertNotNull(element, "element");
            Param.AssertNotNull(expression, "expression");
            Param.AssertNotNull(childExpression, "childExpression");

            // If the two expressions are both of the same type (OR or AND), then there is 
            // no need for parenthesis.
            if (expression.OperatorType != childExpression.OperatorType)
            {
                // The expressions are not of the same type. One of them should be enclosed
                // by parenthesis to indicate the precedence.
                this.AddViolation(element, expression.LineNumber, Rules.ConditionalExpressionsMustDeclarePrecedence);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Checks that parenthesis are used correctly within an anonymous method.
        /// </summary>
        /// <param name="element">The parent element.</param>
        /// <param name="expression">The expression to check.</param>
        private void CheckAnonymousMethodParenthesis(CsElement element, AnonymousMethodExpression expression)
        {
            Param.AssertNotNull(element, "element");
            Param.AssertNotNull(expression, "expression");

            if (expression.Parameters == null || expression.Parameters.Count == 0)
            {
                // Check for parenthesis.
                for (Node<CsToken> tokenNode = expression.Tokens.First; tokenNode != expression.Tokens.Last; tokenNode = tokenNode.Next)
                {
                    if (tokenNode.Value.CsTokenType == CsTokenType.OpenCurlyBracket)
                    {
                        break;
                    }
                    else if (tokenNode.Value.CsTokenType == CsTokenType.OpenParenthesis)
                    {
                        // If we're inside a MethodInvocation and the method being called is a method on our class
                        // with at least 2 signatures then the parens are required.
                        if (expression.Parent is MethodInvocationExpression)
                        {
                            MethodInvocationExpression parentExpression = expression.Parent as MethodInvocationExpression;

                            CsToken classMemberName = CSharp.Utils.ExtractBaseClassMemberName(parentExpression, parentExpression.Tokens.First);

                            if (classMemberName == null)
                            {
                                break;
                            }

                            ClassBase classBase = CSharp.Utils.GetClassBase(element);

                            Dictionary<string, List<CsElement>> allClassMembers = CSharp.Utils.CollectClassMembers(classBase);

                            var classMembers = CSharp.Utils.FindClassMember(classMemberName.Text, classBase, allClassMembers, false);

                            if (classMembers != null && classMembers.Count > 1)
                            {
                                break;
                            }
                        }

                        this.AddViolation(element, tokenNode.Value.LineNumber, Rules.RemoveDelegateParenthesisWhenPossible);
                        break;
                    }
                }
            }
        }

        #endregion Private Methods

        #region Private Structs

        /// <summary>
        /// Keeps track of the number of classes and namespaces seen in the document.
        /// </summary>
        private class TopLevelElements
        {
            /// <summary>
            /// The classes seen in the document.
            /// </summary>
            private List<Class> classes = new List<Class>();

            /// <summary>
            /// The namespaces seen in the document.
            /// </summary>
            private List<Namespace> namespaces = new List<Namespace>();

            /// <summary>
            /// Gets the classes seen in the document.
            /// </summary>
            public ICollection<Class> Classes
            {
                get { return this.classes; }
            }

            /// <summary>
            /// Gets the namespaces seen in the document.
            /// </summary>
            public ICollection<Namespace> Namespaces
            {
                get { return this.namespaces; }
            }
        }

        #endregion Private Structs
    }
}
