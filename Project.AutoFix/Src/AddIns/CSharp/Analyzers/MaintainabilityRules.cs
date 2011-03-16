//-----------------------------------------------------------------------
// <copyright file="MaintainabilityRules.cs">
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
        public override void AnalyzeDocument(ICodeDocument document)
        {
            Param.RequireNotNull(document, "document");

            CsDocument csdocument = document.AsCsDocument();

            if (csdocument != null && !csdocument.Generated)
            {
                // Check the access modifier rules.
                TopLevelElements topLevelElements = new TopLevelElements();

                csdocument.WalkCodeModel<TopLevelElements>(this.VisitCodeUnit, topLevelElements);

                // If there is more than one top-level class in the file, make sure they are all
                // partial classes and are all of the same type.
                if (topLevelElements.Classes.Count > 1)
                {
                    string name = string.Empty;
                    foreach (Class classElement in topLevelElements.Classes)
                    {
                        if (!classElement.ContainsModifier(TokenType.Partial) ||
                            (!string.IsNullOrEmpty(name) && string.Compare(name, classElement.FullyQualifiedName, StringComparison.Ordinal) != 0))
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

                        name = classElement.FullyQualifiedName;
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

        #endregion Public Override Methods

        #region Private Static Methods

        /// <summary>
        /// Processes the given element.
        /// </summary>
        /// <param name="element">The element being visited.</param>
        /// <param name="parentElement">The parent of the element.</param>
        /// <param name="topLevelElements">The number of classes and namespaces seen in the document.</param>
        private static void CheckFileContents(
            Element element, Element parentElement, TopLevelElements topLevelElements)
        {
            Param.AssertNotNull(element, "element");
            Param.Ignore(parentElement);
            Param.AssertNotNull(topLevelElements, "topLevelElements");

            if (element.ElementType == ElementType.Class)
            {
                if (parentElement == null ||
                    parentElement.ElementType == ElementType.Document ||
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

            Token first = expression.Name.FindFirstDescendentToken();
            if (first != null)
            {
                if (first.Text.Equals("SuppressMessage", StringComparison.Ordinal))
                {
                    return true;
                }
                
                if (first.Text.Equals("System"))
                {
                    return expression.Name.MatchTokensFrom(first, "System", ".", "Diagnostics", ".", "CodeAnalysis", ".", "SuppressMessage");
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
            for (Statement childStatement = statement.FindFirstChildStatement(); childStatement != null; childStatement = childStatement.FindNextSiblingStatement())
            {
                if (childStatement.StatementType == StatementType.Block)
                {
                    if (childStatement.Children.StatementCount == 0)
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
        private static bool IsEmptyElement(Element element)
        {
            Param.AssertNotNull(element, "element");

            if (element.Children.ElementCount > 0 || element.Children.StatementCount > 0)
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

        #endregion Private Static Methods

        #region Private Methods

        /// <summary>
        /// Visits one code unit in the document.
        /// </summary>
        /// <param name="codeUnit">The item being visited.</param>
        /// <param name="parentElement">The parent element, if any.</param>
        /// <param name="parentStatement">The parent statement, if any.</param>
        /// <param name="parentExpression">The parent expression, if any.</param>
        /// <param name="parentClause">The parent query clause, if any.</param>
        /// <param name="parentToken">The parent token, if any.</param>
        /// <param name="topLevelElements">The number of classes and namespaces seen in the document.</param>
        /// <returns>Returns true to continue, or false to stop the walker.</returns>
        private bool VisitCodeUnit(
            CodeUnit codeUnit,
            Element parentElement,
            Statement parentStatement,
            Expression parentExpression,
            QueryClause parentClause,
            Token parentToken,
            TopLevelElements topLevelElements)
        {
            Param.AssertNotNull(codeUnit, "codeUnit");
            Param.Ignore(parentElement, parentStatement, parentExpression, parentClause, parentToken);
            Param.AssertNotNull(topLevelElements, "topLevelElements");

            if (codeUnit.CodeUnitType == CodeUnitType.Element)
            {
                return this.VisitElement((Element)codeUnit, parentElement, topLevelElements);
            }
            else if (codeUnit.CodeUnitType == CodeUnitType.Statement)
            {
                return this.VisitStatement((Statement)codeUnit, parentExpression, parentStatement, parentElement);
            }
            else if (codeUnit.CodeUnitType == CodeUnitType.Expression)
            {
                return this.VisitExpression((Expression)codeUnit, parentExpression, parentStatement, parentElement);
            }

            return !this.Cancel;
        }

        /// <summary>
        /// Processes the given element.
        /// </summary>
        /// <param name="element">The element being visited.</param>
        /// <param name="parentElement">The parent element, if any.</param>
        /// <param name="topLevelElements">The number of classes and namespaces seen in the document.</param>
        /// <returns>Returns true to continue, or false to stop the walker.</returns>
        private bool VisitElement(
            Element element,
            Element parentElement,
            TopLevelElements topLevelElements)
        {
            Param.AssertNotNull(element, "element");
            Param.Ignore(parentElement);
            Param.AssertNotNull(topLevelElements, "topLevelElements");

            this.CheckAccessModifierRulesForElement(element);
            this.CheckCodeAnalysisAttributeJustifications(element);
            this.CheckForEmptyElements(element);
            CheckFileContents(element, parentElement, topLevelElements);

            return true;
        }

        /// <summary>
        /// Checks the access modifier on the element.
        /// </summary>
        /// <param name="element">The element being visited.</param>
        private void CheckAccessModifierRulesForElement(Element element)
        {
            Param.AssertNotNull(element, "element");
            
            // Make sure this element is not generated.
            if (!element.Generated)
            {
                // Skip these rules if the element is a child of an interface.
                Element parent = element.FindParentElement();
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
        private void CheckForAccessModifier(Element element)
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
                if (!element.DeclaresAccessModifier && !element.ContainsModifier(TokenType.Partial))
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
                if (!element.DeclaresAccessModifier)
                {
                    this.AddViolation(element, Rules.AccessModifierMustBeDeclared, element.FriendlyTypeText);
                }
            }
            else if (element.ElementType == ElementType.Constructor)
            {
                // If a constructor is not static it must have an access modifier.
                if (!element.DeclaresAccessModifier && !element.ContainsModifier(TokenType.Static))
                {
                    this.AddViolation(element, Rules.AccessModifierMustBeDeclared, element.FriendlyTypeText);
                }
            }
        }

        /// <summary>
        /// Verifies that fields are not declared public.
        /// </summary>
        /// <param name="element">The element to check.</param>
        private void CheckFieldAccessModifiers(Element element)
        {
            Param.AssertNotNull(element, "element");

            Element parent = element.FindParentElement();

            if (element.ElementType == ElementType.Field &&
                (element.AccessModifierType != AccessModifierType.Private) &&
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

                    if (parent.ActualAccessLevel == AccessModifierType.Private ||
                        parent.ActualAccessLevel == AccessModifierType.Internal)
                    {
                        privateOrInternal = true;
                    }

                    if (parent.Name.EndsWith("NativeMethods", StringComparison.Ordinal))
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
        private void CheckCodeAnalysisAttributeJustifications(Element element)
        {
            Param.AssertNotNull(element, "element");

            // Make sure this element is not generated.
            if (!element.Generated && element.Attributes != null)
            {
                foreach (var attribute in element.Attributes)
                {
                    foreach (var expression in attribute.AttributeExpressions)
                    {
                        for (var methodInvocation = expression.FindFirstChild<MethodInvocationExpression>(); methodInvocation != null; methodInvocation = methodInvocation.FindNextSibling<MethodInvocationExpression>())
                        {
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

        /// <summary>
        /// Checks the given code analysis suppression call to ensure that it contains a justifiction argument.
        /// </summary>
        /// <param name="element">The element that contains the suppression attribute.</param>
        /// <param name="suppression">The suppression to check.</param>
        private void CheckCodeAnalysisSuppressionForJustification(Element element, MethodInvocationExpression suppression)
        {
            Param.AssertNotNull(element, "element");
            Param.AssertNotNull(suppression, "suppression");

            bool justifiction = false;
            if (suppression.ArgumentList != null)
            {
                foreach (Argument argument in suppression.ArgumentList.Arguments)
                {
                    if (argument.Expression.ExpressionType == ExpressionType.Assignment)
                    {
                        AssignmentExpression assignmentExpression = (AssignmentExpression)argument.Expression;
                        Token firstAssignmentExpressionToken = assignmentExpression.LeftHandSide.FindFirstDescendentToken();
                        if (firstAssignmentExpressionToken != null && firstAssignmentExpressionToken.Text.Equals("Justification", StringComparison.Ordinal))
                        {
                            Token rightSideToken = assignmentExpression.RightHandSide.FindFirstDescendentToken();
                            if (rightSideToken != null &&
                                rightSideToken.TokenType == TokenType.String &&
                                rightSideToken.Text != null &&
                                !IsEmptyString(rightSideToken.Text))
                            {
                                justifiction = true;
                                break;
                            }
                        }
                    }
                }

                if (!justifiction)
                {
                    this.AddViolation(element, suppression.LineNumber, Rules.CodeAnalysisSuppressionMustHaveJustification);
                }
            }
        }

        /// <summary>
        /// Called when a statement is visited.
        /// </summary>
        /// <param name="statement">The statement being visited.</param>
        /// <param name="parentExpression">The parent expression, if any.</param>
        /// <param name="parentStatement">The parent statement, if any.</param>
        /// <param name="parentElement">The parent element, if any.</param>
        /// <returns>Returns true to continue, or false to stop the walker.</returns>
        private bool VisitStatement(Statement statement, Expression parentExpression, Statement parentStatement, Element parentElement)
        {
            Param.AssertNotNull(statement, "statement");
            Param.Ignore(parentExpression);
            Param.Ignore(parentStatement);
            Param.AssertNotNull(parentElement, "parentElement");

            this.CheckForUnnecessaryStatements(statement, parentElement);

            return true;
        }

        /// <summary>
        /// Checks to see if the statement is unnecessary.
        /// </summary>
        /// <param name="statement">The statement to check.</param>
        /// <param name="parentElement">The parent element of the statement.</param>
        private void CheckForUnnecessaryStatements(Statement statement, Element parentElement)
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
        private void CheckForEmptyElements(Element element)
        {
            Param.AssertNotNull(element, "element");

            if (!element.Generated)
            {
                if (element.ElementType == ElementType.Constructor && element.ContainsModifier(TokenType.Static))
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
        /// <returns>Returns true to continue, or false to stop the walker.</returns>
        private bool VisitExpression(Expression expression, Expression parentExpression, Statement parentStatement, Element parentElement)
        {
            Param.AssertNotNull(expression, "expression");
            Param.Ignore(parentExpression);
            Param.Ignore(parentStatement);
            Param.AssertNotNull(parentElement, "parentElement");

            if (!parentElement.Generated)
            {
                // Determine whether this expression is a method invocation which contains call to Debug.Fail or Debug.Assert.
                if (expression.ExpressionType == ExpressionType.MethodInvocation)
                {
                    MethodInvocationExpression methodInvocation = (MethodInvocationExpression)expression;
                    if (methodInvocation.Name.MatchTokens("Debug", ".", "Assert") ||
                        methodInvocation.Name.MatchTokens("System", ".", "Diagnostics", ".", "Debug", ".", "Assert"))
                    {
                        this.CheckDebugAssertMessage(parentElement, methodInvocation);
                    }
                    else if (methodInvocation.Name.MatchTokens("Debug", ".", "Fail") ||
                        methodInvocation.Name.MatchTokens("System", ".", "Diagnostics", ".", "Debug", ".", "Fail"))
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
        private void CheckDebugAssertMessage(Element element, MethodInvocationExpression debugAssertMethodCall)
        {
            Param.AssertNotNull(element, "element");
            Param.AssertNotNull(debugAssertMethodCall, "debugAssertMethodCall");

            // Extract the second argument.
            Argument secondArgument = null;
            if (debugAssertMethodCall.ArgumentList != null && debugAssertMethodCall.ArgumentList.Count >= 2)
            {
                secondArgument = debugAssertMethodCall.ArgumentList[1];
            }

            if (secondArgument == null)
            {
                // There is no message argument.
                this.AddViolation(element, debugAssertMethodCall.LineNumber, Rules.DebugAssertMustProvideMessageText);
            }
            else
            {
                Token secondArgumentStartToken = secondArgument.FindFirstDescendentToken();    
                if (secondArgumentStartToken == null)
                {
                    // The message argument is empty.
                    this.AddViolation(element, debugAssertMethodCall.LineNumber, Rules.DebugAssertMustProvideMessageText);
                }
                else if (secondArgumentStartToken.TokenType == TokenType.String && IsEmptyString(secondArgumentStartToken.Text))
                {
                    // The message argument contains an empty string.
                    this.AddViolation(element, debugAssertMethodCall.LineNumber, Rules.DebugAssertMustProvideMessageText);
                }
            }
        }

        /// <summary>
        /// Checks the given call into Debug.Fail to ensure that it contains a valid debug message.
        /// </summary>
        /// <param name="element">The parent element.</param>
        /// <param name="debugFailMethodCall">The call to Debug.Fail.</param>
        private void CheckDebugFailMessage(Element element, MethodInvocationExpression debugFailMethodCall)
        {
            Param.AssertNotNull(element, "element");
            Param.AssertNotNull(debugFailMethodCall, "debugFailMethodCall");

            // Extract the first argument.
            Argument firstArgument = null;
            if (debugFailMethodCall.ArgumentList != null && debugFailMethodCall.ArgumentList.Count > 0)
            {
                firstArgument = debugFailMethodCall.ArgumentList[0];
            }

            if (firstArgument == null)
            {
                // There is no message argument.
                this.AddViolation(element, debugFailMethodCall.LineNumber, Rules.DebugFailMustProvideMessageText);
            }
            else
            {
                Token firstArgumentStartToken = firstArgument.FindFirstDescendentToken();    
                if (firstArgumentStartToken == null)
                {
                    // The message argument is empty.
                    this.AddViolation(element, debugFailMethodCall.LineNumber, Rules.DebugFailMustProvideMessageText);
                }
                else if (firstArgumentStartToken.TokenType == TokenType.String && IsEmptyString(firstArgumentStartToken.Text))
                {
                    // The message argument contains an empty string.
                    this.AddViolation(element, debugFailMethodCall.LineNumber, Rules.DebugFailMustProvideMessageText);
                }
            }
        }

        /// <summary>
        /// Checks the given parenthesized expression to make sure that it is not unnecessary.
        /// </summary>
        /// <param name="element">The element containing the expression.</param>
        /// <param name="parenthesizedExpression">The parenthesized expression to check.</param>
        private void CheckParenthesizedExpression(Element element, ParenthesizedExpression parenthesizedExpression)
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
                    this.AddViolation(element, parenthesizedExpression.LineNumber, Rules.StatementMustNotUseUnnecessaryParenthesis);
                }
                else
                {
                    // These types of expressions are allowed in some cases to be surrounded by parenthesis,
                    // as long as the parenthesized expression is within another expression. They are not allowed
                    // to be within parenthesis within a variable declarator expression. For example:
                    // int x = (2 + 3);
                    if (!(parenthesizedExpression.Parent is Expression) || parenthesizedExpression.Parent is VariableDeclaratorExpression)
                    {
                        this.AddViolation(element, parenthesizedExpression.LineNumber, Rules.StatementMustNotUseUnnecessaryParenthesis);
                    }
                    else
                    {
                        // This is also not allowed when the expression is on the right-hand side of an assignment.
                        AssignmentExpression assignment = parenthesizedExpression.Parent as AssignmentExpression;
                        if (assignment != null && assignment.RightHandSide == parenthesizedExpression)
                        {
                            this.AddViolation(element, parenthesizedExpression.LineNumber, Rules.StatementMustNotUseUnnecessaryParenthesis);
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
        private void CheckArithmeticExpressionParenthesis(Element element, ArithmeticExpression expression)
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
            Element element, ArithmeticExpression expression, ArithmeticExpression childExpression)
        {
            Param.AssertNotNull(element, "element");
            Param.AssertNotNull(expression, "expression");
            Param.AssertNotNull(childExpression, "childExpression");

            // Parenthesis are only required when the two expressions are not the same operator,
            // and when the two operators come from different families. 
            if (expression.ArithmeticExpressionType != childExpression.ArithmeticExpressionType)
            {
                bool sameFamily =
                    ((expression.ArithmeticExpressionType == ArithmeticExpressionType.Addition ||
                      expression.ArithmeticExpressionType == ArithmeticExpressionType.Subtraction) &&
                     (childExpression.ArithmeticExpressionType == ArithmeticExpressionType.Addition ||
                      childExpression.ArithmeticExpressionType == ArithmeticExpressionType.Subtraction)) ||
                    ((expression.ArithmeticExpressionType == ArithmeticExpressionType.Multiplication ||
                      expression.ArithmeticExpressionType == ArithmeticExpressionType.Division) &&
                     (childExpression.ArithmeticExpressionType == ArithmeticExpressionType.Multiplication ||
                      childExpression.ArithmeticExpressionType == ArithmeticExpressionType.Division)) ||
                    ((expression.ArithmeticExpressionType == ArithmeticExpressionType.LeftShift ||
                      expression.ArithmeticExpressionType == ArithmeticExpressionType.RightShift) &&
                     (childExpression.ArithmeticExpressionType == ArithmeticExpressionType.LeftShift ||
                      childExpression.ArithmeticExpressionType == ArithmeticExpressionType.RightShift));

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
            Element element, ConditionalLogicalExpression expression)
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
            Element element, ConditionalLogicalExpression expression, ConditionalLogicalExpression childExpression)
        {
            Param.AssertNotNull(element, "element");
            Param.AssertNotNull(expression, "expression");
            Param.AssertNotNull(childExpression, "childExpression");

            // If the two expressions are both of the same type (OR or AND), then there is 
            // no need for parenthesis.
            if (expression.ConditionalLogicalExpressionType != childExpression.ConditionalLogicalExpressionType)
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
        private void CheckAnonymousMethodParenthesis(Element element, AnonymousMethodExpression expression)
        {
            Param.AssertNotNull(element, "element");
            Param.AssertNotNull(expression, "expression");

            if (expression.ParameterList == null || expression.ParameterList.Count == 0)
            {
                // Check for parenthesis.
                for (Token token = expression.FindFirstChildToken(); token != null; token = token.FindNextSiblingToken())
                {
                    if (token.TokenType == TokenType.OpenCurlyBracket)
                    {
                        break;
                    }
                    else if (token.TokenType == TokenType.OpenParenthesis)
                    {
                        this.AddViolation(element, token.LineNumber, Rules.RemoveDelegateParenthesisWhenPossible);
                        break;
                    }
                }
            }
        }

        #endregion Private Methods

        #region Private Classes

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

        #endregion Private Classes
    }
}
