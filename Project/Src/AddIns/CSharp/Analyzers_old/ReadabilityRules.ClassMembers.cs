//-----------------------------------------------------------------------
// <copyright file="ReadabilityRules.ClassMembers.cs" company="Microsoft">
//   Copyright (c) Microsoft Corporation.
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
namespace Microsoft.StyleCop.CSharp_old
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using Microsoft.StyleCop;

    /// <content>
    /// Checks rules related to class member calls.
    /// </content>
    public partial class ReadabilityRules
    {
        #region Public Override Methods

        /// <summary>
        /// Returns a value indicating whether to delay analysis of this document until the next pass.
        /// </summary>
        /// <param name="document">The document to analyze.</param>
        /// <param name="passNumber">The current pass number.</param>
        /// <returns>Returns true if analysis should be delayed.</returns>
        public override bool DelayAnalysis(ICodeDocument document, int passNumber)
        {
            Param.RequireNotNull(document, "document");
            Param.Ignore(passNumber);

            bool delay = false;

            // We sometimes delay pass zero, but never pass one.
            if (passNumber == 0)
            {
                // Get the root element.
                CsDocument csdocument = document as CsDocument;
                if (csdocument != null && csdocument.RootElement != null)
                {
                    // If the element has any partial classes, structs, or interfaces, delay. This is due
                    // to the fact that the class members rules need knowledge about all parts of the class
                    // in order to find all class members.
                    delay = this.ContainsPartialMembers(csdocument.RootElement);
                }
            }

            return delay;
        }

        #endregion Public Override Methods

        #region Private Static Methods

        /// <summary>
        /// Finds the given class member in the given class.
        /// </summary>
        /// <param name="word">The word to check.</param>
        /// <param name="parentClass">The class the word appears in.</param>
        /// <param name="members">The collection of members of the parent class.</param>
        /// <param name="interfaces">True if interface implementations should be included.</param>
        /// <returns>Returns the class members that match against the given name.</returns>
        private static ICollection<CsElement> FindClassMember(
            string word, ClassBase parentClass, Dictionary<string, List<CsElement>> members, bool interfaces)
        {
            Param.AssertNotNull(word, "word");
            Param.AssertNotNull(parentClass, "parentClass");
            Param.AssertNotNull(members, "members");
            Param.Ignore(interfaces);

            // If the word is the same as the class name, then this is a constructor and we
            // don't want to match against it.
            if (word != parentClass.Declaration.Name)
            {
                ICollection<CsElement> matches = ReadabilityRules.MatchClassMember(word, members, interfaces);
                if (matches != null && matches.Count > 0)
                {
                    return matches;
                }
            }

            return null;
        }

        /// <summary>
        /// Matches the given word with members of the given class.
        /// </summary>
        /// <param name="word">The word to check.</param>
        /// <param name="members">The collection of members of the parent class.</param>
        /// <param name="interfaces">True if interface implementations should be included.</param>
        /// <returns>Returns the class members that matches against the given name.</returns>
        private static ICollection<CsElement> MatchClassMember(string word, Dictionary<string, List<CsElement>> members, bool interfaces)
        {
            Param.AssertNotNull(word, "word");
            Param.AssertNotNull(members, "members");
            Param.Ignore(interfaces);

            List<CsElement> matchesFound = null;

            // Look through all the children of this class to see if the word matches
            // against any item in the class.
            List<CsElement> matches = null;
            if (members.TryGetValue(word, out matches))
            {
                foreach (CsElement match in matches)
                {
                    // Check if there is a match.
                    if (match.ElementType == ElementType.Field ||
                        match.Declaration.Name == word ||
                       (interfaces && match.Declaration.Name.EndsWith("." + word, StringComparison.Ordinal)))
                    {
                        if (matchesFound == null)
                        {
                            matchesFound = new List<CsElement>();
                        }

                        matchesFound.Add(match);
                    }
                }
            }

            return matchesFound;
        }

        /// <summary>
        /// Extracts the name of the member being called from the base class.
        /// </summary>
        /// <param name="parentExpression">The expression containing the tokens.</param>
        /// <param name="baseTokenNode">The 'base' keyword token.</param>
        /// <returns>Returns the name of the member or null if there is no member name.</returns>
        private static CsToken ExtractBaseClassMemberName(Expression parentExpression, Node<CsToken> baseTokenNode)
        {
            Param.AssertNotNull(parentExpression, "parentExpression");
            Param.AssertNotNull(baseTokenNode, "baseTokenNode");

            bool foundMemberAccessSymbol = false;
            foreach (CsToken token in parentExpression.Tokens.ForwardIterator(baseTokenNode.Next))
            {
                if (token.CsTokenType != CsTokenType.WhiteSpace &&
                    token.CsTokenType != CsTokenType.EndOfLine &&
                    token.CsTokenType != CsTokenType.SingleLineComment &&
                    token.CsTokenType != CsTokenType.MultiLineComment &&
                    token.CsTokenType != CsTokenType.PreprocessorDirective)
                {
                    if (foundMemberAccessSymbol)
                    {
                        if (token.CsTokenType == CsTokenType.Other)
                        {
                            return token;
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        if (token.CsTokenType == CsTokenType.OperatorSymbol)
                        {
                            if (((OperatorSymbol)token).SymbolType == OperatorType.MemberAccess)
                            {
                                foundMemberAccessSymbol = true;
                            }
                            else
                            {
                                break;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Determines whether a matching local variable is contained in the given variable list.
        /// </summary>
        /// <param name="variables">The variable list.</param>
        /// <param name="word">The variable name to check.</param>
        /// <param name="item">The token containing the variable name.</param>
        /// <returns>Returns true if there is a matching local variable.</returns>
        private static bool ContainsVariable(VariableCollection variables, string word, CsToken item)
        {
            Param.AssertNotNull(variables, "variables");
            Param.AssertValidString(word, "word");
            Param.AssertNotNull(item, "item");

            Variable variable = variables[word];
            if (variable != null)
            {
                // Make sure the variable appears before the word.
                if (variable.Location.LineNumber < item.LineNumber)
                {
                    return true;
                }
                else if (variable.Location.LineNumber == item.LineNumber)
                {
                    if (variable.Location.StartPoint.IndexOnLine < item.Location.StartPoint.IndexOnLine)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Adds a class members to the dictionary.
        /// </summary>
        /// <param name="members">The dictionary of class members.</param>
        /// <param name="child">The class member.</param>
        /// <param name="name">The name of the class member.</param>
        private static void AddClassMember(Dictionary<string, List<CsElement>> members, CsElement child, string name)
        {
            Param.AssertNotNull(members, "members");
            Param.AssertNotNull(child, "member");
            Param.AssertValidString(name, "name");

            List<CsElement> items = null;
            if (!members.TryGetValue(name, out items))
            {
                items = new List<CsElement>(1);
                members.Add(name, items);
            }

            items.Add(child);
        }

        /// <summary>
        /// Adds all members of a class to a dictionary, taking into account partial classes.
        /// </summary>
        /// <param name="parentClass">The class to collect.</param>
        /// <returns>Returns the dictionary of class members.</returns>
        private static Dictionary<string, List<CsElement>> CollectClassMembers(ClassBase parentClass)
        {
            Param.AssertNotNull(parentClass, "parentClass");

            Dictionary<string, List<CsElement>> members = new Dictionary<string, List<CsElement>>();

            if (parentClass.Declaration.ContainsModifier(CsTokenType.Partial))
            {
                foreach (ClassBase @class in parentClass.PartialElementList)
                {
                    CollectClassMembersAux(@class, members);
                }
            }
            else
            {
                CollectClassMembersAux(parentClass, members);
            }

            return members;
        }

        /// <summary>
        /// Adds all members of a class to a dictionary.
        /// </summary>
        /// <param name="class">The class to collect.</param>
        /// <param name="members">Adds all members of the class to the given dictionary.</param>
        private static void CollectClassMembersAux(ClassBase @class, Dictionary<string, List<CsElement>> members)
        {
            Param.AssertNotNull(@class, "class");
            Param.AssertNotNull(members, "members");

            foreach (CsElement child in @class.ChildElements)
            {
                if (child.ElementType == ElementType.Field)
                {
                    // Look through each of the declarators in the field.
                    foreach (VariableDeclaratorExpression declarator in ((Field)child).VariableDeclarationStatement.Declarators)
                    {
                        AddClassMember(members, child, declarator.Identifier.Text);
                    }
                }
                else if (child.ElementType == ElementType.Event)
                {
                    // Look through each of the declarators in the event.
                    foreach (EventDeclaratorExpression declarator in ((Event)child).Declarators)
                    {
                        AddClassMember(members, child, declarator.Identifier.Text);
                    }
                }
                else if (child.ElementType != ElementType.EmptyElement)
                {
                    AddClassMember(members, child, child.Declaration.Name);
                }
            }
        }

        /// <summary>
        /// Determines whether the given word is the name of a local variable.
        /// </summary>
        /// <param name="word">The name to check.</param>
        /// <param name="item">The token containing the word.</param>
        /// <param name="parent">The code unit that the word appears in.</param>
        /// <returns>True if the word is the name of a local variable, false if not.</returns>
        private static bool IsLocalMember(string word, CsToken item, ICodeUnit parent)
        {
            Param.AssertValidString(word, "word");
            Param.AssertNotNull(item, "item");
            Param.AssertNotNull(parent, "parent");

            while (parent != null)
            {
                // Check to see if the name matches a local variable.
                if (ReadabilityRules.ContainsVariable(parent.Variables, word, item))
                {
                    return true;
                }

                // If the parent is an element, do not look any higher up the stack than this.
                if (parent.CodePartType == CodePartType.Element)
                {
                    break;
                }

                // Check to see whether the variable is defined within the parent.
                parent = parent.Parent as ICodeUnit;
            }

            return false;
        }

        /// <summary>
        /// Determines whether the given expression is the left-hand-side literal in any of the assignment expressions
        /// within an object initialize expression.
        /// </summary>
        /// <param name="expression">The expression to check.</param>
        /// <returns>Returns true if the expression is the left-hand-side literal in any of the assignment expressions 
        /// within an object initializer expression.</returns>
        /// <remarks>This method checks for the following situation:
        /// class MyClass
        /// {
        ///     public bool Member { get { return true; } }
        ///     public void SomeMethod()
        ///     {
        ///         MyObjectType someObject = new MyObjectType { Member = this.Member }; 
        ///     }
        /// }
        /// In this case, StyleCop will raise a violation since it looks like the Member token should be prefixed by 'this.', however,
        /// it is actually referring to a property on the MyObjectType type.
        /// </remarks>
        private static bool IsObjectInitializerLeftHandSideExpression(Expression expression)
        {
            Param.AssertNotNull(expression, "expression");

            // The expression should be a literal expression if it represents the keyword being checked.
            if (expression.ExpressionType == ExpressionType.Literal)
            {
                // The literal should be a child-expression of an assignment expression.
                AssignmentExpression assignmentExpression = expression.Parent as AssignmentExpression;
                if (assignmentExpression != null)
                {
                    // The left-hand-side of the assignment expression should be the literal expression.
                    if (assignmentExpression.LeftHandSide == expression)
                    {
                        // The assignment expression should be the child of an object initializer expression.
                        ObjectInitializerExpression objectInitializeExpression = assignmentExpression.Parent as ObjectInitializerExpression;
                        if (objectInitializeExpression != null)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Determines whether the given token is preceded by a member access symbol.
        /// </summary>
        /// <param name="literalTokenNode">The token to check.</param>
        /// <param name="masterList">The list containing the token.</param>
        /// <returns>Returns true if the token is preceded by a member access symbol.</returns>
        private static bool IsLiteralTokenPrecededByMemberAccessSymbol(Node<CsToken> literalTokenNode, MasterList<CsToken> masterList)
        {
            Param.AssertNotNull(literalTokenNode, "literalTokenNode");
            Param.AssertNotNull(masterList, "masterList");

            // Get the previous non-whitespace token.
            CsToken previousToken = ReadabilityRules.GetPreviousToken(literalTokenNode.Previous, masterList);
            if (previousToken == null)
            {
                return false;
            }

            if (previousToken.CsTokenType == CsTokenType.OperatorSymbol)
            {
                OperatorSymbol symbol = (OperatorSymbol)previousToken;
                if (symbol.SymbolType == OperatorType.MemberAccess ||
                    symbol.SymbolType == OperatorType.Pointer ||
                    symbol.SymbolType == OperatorType.QualifiedAlias)
                {
                    return true;
                }
            }

            return false;
        }

        /////// <summary>
        /////// Determines whether the given expression is the left-most expression within it's call graph. For example, 
        /////// within the expression 'Member.Property.Method()', 'Member' is the left-most expression. Within the expression
        /////// 'Method()', 'Method' is the left-most expression.
        /////// </summary>
        /////// <param name="expression">The expression to check.</param>
        /////// <param name="parent">The parent of the expression.</param>
        /////// <returns>Returns true if the expression is the left-most expression.</returns>
        ////private static bool IsLeftmostExpression(Expression expression, Expression parent)
        ////{
        ////    Param.AssertNotNull(expression, "literal");
        ////    Param.Ignore(parent);

        ////    // If the expression has no parent, it is the left-most because it is the only expression.
        ////    if (parent == null)
        ////    {
        ////        return true;
        ////    }

        ////    // If the parent of the expression is not a member-access expression, then this is the left-most expression.
        ////    if (parent.ExpressionType != ExpressionType.MemberAccess)
        ////    {
        ////        return IsLeftmostExpression(parent, parent.ParentExpression);
        ////    }

        ////    // The parent of this expression is a member access expression. If this expression is on the left-hand-side
        ////    // of the parent member access expression, then recurse one level up the expression tree and check again.
        ////    MemberAccessExpression parentMemberAccess = (MemberAccessExpression)parent;
        ////    if (parentMemberAccess.LeftHandSide == expression)
        ////    {
        ////        return IsLeftmostExpression(parentMemberAccess, parentMemberAccess.ParentExpression);
        ////    }

        ////    // The expression is not on the left.
        ////    return false;
        ////}

        #endregion Private Static Methods

        #region Private Methods

        /// <summary>
        /// Checks the items within the given element.
        /// </summary>
        /// <param name="element">The element to check.</param>
        /// <param name="parentClass">The class that the element belongs to.</param>
        /// <param name="members">The collection of members of the parent class.</param>
        /// <returns>Returns false if the analyzer should quit.</returns>
        private bool CheckClassMemberRulesForElements(CsElement element, ClassBase parentClass, Dictionary<string, List<CsElement>> members)
        {
            Param.AssertNotNull(element, "element");
            Param.Ignore(parentClass);
            Param.Ignore(members);

            // Check whether processing has been cancelled by the user.
            if (this.Cancel)
            {
                return false;
            }

            if (element.ElementType == ElementType.Class ||
                element.ElementType == ElementType.Struct ||
                element.ElementType == ElementType.Interface)
            {
                parentClass = element as ClassBase;
                members = CollectClassMembers(parentClass);
            }

            foreach (CsElement child in element.ChildElements)
            {
                if (!child.Generated)
                {
                    if (child.ElementType == ElementType.Method ||
                        child.ElementType == ElementType.Constructor ||
                        child.ElementType == ElementType.Destructor ||
                        child.ElementType == ElementType.Accessor)
                    {
                        // If the parent class is null, then this element is sitting outside of a class.
                        // This is illegal in C# so the code will not compile, but we still attempt to
                        // parse it. In this case there is no use of this prefixes since there is no class.
                        if (parentClass != null)
                        {
                            this.CheckClassMemberRulesForStatements(child.ChildStatements, child, parentClass, members);
                        }
                    }
                    else
                    {
                        if (child.ElementType == ElementType.Class || child.ElementType == ElementType.Struct)
                        {
                            ClassBase elementContainer = child as ClassBase;
                            Debug.Assert(elementContainer != null, "The element is not a class.");

                            this.CheckClassMemberRulesForElements(child, elementContainer, members);
                        }
                        else if (!this.CheckClassMemberRulesForElements(child, parentClass, members))
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Parses the given statement list.
        /// </summary>
        /// <param name="statements">The list of statements to parse.</param>
        /// <param name="parentElement">The element that contains the statements.</param>
        /// <param name="parentClass">The class that the element belongs to.</param>
        /// <param name="members">The collection of members of the parent class.</param>
        private void CheckClassMemberRulesForStatements(
            ICollection<Statement> statements,
            CsElement parentElement,
            ClassBase parentClass,
            Dictionary<string, List<CsElement>> members)
        {
            Param.AssertNotNull(statements, "statements");
            Param.AssertNotNull(parentElement, "parentElement");
            Param.Ignore(parentClass);
            Param.Ignore(members);

            // Loop through each of the statements.
            foreach (Statement statement in statements)
            {
                if (statement.ChildStatements.Count > 0)
                {
                    // Parse the sub-statements.
                    this.CheckClassMemberRulesForStatements(statement.ChildStatements, parentElement, parentClass, members);
                }

                // Parse the expressions in the statement.
                this.CheckClassMemberRulesForExpressions(statement.ChildExpressions, null, parentElement, parentClass, members);
            }
        }

        /// <summary>
        /// Parses the list of expressions.
        /// </summary>
        /// <param name="expressions">The list of expressions.</param>
        /// <param name="parentExpression">The parent expression, if there is one.</param>
        /// <param name="parentElement">The element that contains the expressions.</param>
        /// <param name="parentClass">The class that the element belongs to.</param>
        /// <param name="members">The collection of members of the parent class.</param>
        private void CheckClassMemberRulesForExpressions(
            ICollection<Expression> expressions,
            Expression parentExpression,
            CsElement parentElement,
            ClassBase parentClass,
            Dictionary<string, List<CsElement>> members)
        {
            Param.AssertNotNull(expressions, "expressions");
            Param.AssertNotNull(parentElement, "parentElement");
            Param.Ignore(parentExpression);
            Param.Ignore(parentClass);
            Param.Ignore(members);

            // Loop through each of the expressions in the list.
            foreach (Expression expression in expressions)
            {
                // If the expression is a variable declarator expression, we don't 
                // want to match against the identifier tokens.
                if (expression.ExpressionType == ExpressionType.VariableDeclarator)
                {
                    VariableDeclaratorExpression declarator = expression as VariableDeclaratorExpression;
                    if (declarator.Initializer != null)
                    {
                        this.CheckClassMemberRulesForExpression(declarator.Initializer, parentExpression, parentElement, parentClass, members);
                    }
                }
                else
                {
                    this.CheckClassMemberRulesForExpression(expression, parentExpression, parentElement, parentClass, members);
                }
            }
        }

        /// <summary>
        /// Parses the given expression.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <param name="parentExpression">The parent expression, if there is one.</param>
        /// <param name="parentElement">The element that contains the expressions.</param>
        /// <param name="parentClass">The class that the element belongs to.</param>
        /// <param name="members">The collection of members of the parent class.</param>
        private void CheckClassMemberRulesForExpression(
            Expression expression,
            Expression parentExpression,
            CsElement parentElement,
            ClassBase parentClass,
            Dictionary<string, List<CsElement>> members)
        {
            Param.AssertNotNull(expression, "expression");
            Param.Ignore(parentExpression);
            Param.AssertNotNull(parentElement, "parentElement");
            Param.AssertNotNull(parentClass, "parentClass");
            Param.AssertNotNull(members, "members");

            if (expression.ExpressionType == ExpressionType.Literal)
            {
                LiteralExpression literalExpression = (LiteralExpression)expression;

                // Check to see whether this literal is preceded by a member access symbol. If not
                // then we want to check whether this is a reference to one of our class members.
                if (!IsLiteralTokenPrecededByMemberAccessSymbol(literalExpression.TokenNode, expression.Tokens.MasterList))
                {
                    // Process the literal.
                    this.CheckClassMemberRulesForLiteralToken(
                        literalExpression.TokenNode,
                        expression,
                        parentExpression,
                        parentElement,
                        parentClass,
                        members);
                }
            }
            else
            {
                if (expression.ExpressionType == ExpressionType.Assignment &&
                    parentExpression != null &&
                    parentExpression.ExpressionType == ExpressionType.CollectionInitializer)
                {
                    // When we encounter assignment expressions within collection initializer expressions, we ignore the expression
                    // on the left-hand side of the assignment. This is because we know that the left-hand side refers to a property on
                    // the type being initialized, not a property on the local class. Thus, it does not ever need to be prefixed by this.
                    // Without this check we can get name collisions, such as:
                    // public sealed class Person
                    // {
                    //     public string FirstName { get; }
                    //     public void CreateAnonymousType()
                    //     {
                    //         var anonymousType = new { FirstName = this.FirstName };
                    //     }
                    // }
                    this.CheckClassMemberRulesForExpression(((AssignmentExpression)expression).RightHandSide, expression, parentElement, parentClass, members);
                }
                else if (expression.ChildExpressions.Count > 0)
                {
                    // Check each child expression within this expression.
                    this.CheckClassMemberRulesForExpressions(
                        expression.ChildExpressions,
                        expression,
                        parentElement,
                        parentClass,
                        members);
                }

                // Check if this is an anonymous method expression, which contains a child statement list.
                if (expression.ExpressionType == ExpressionType.AnonymousMethod)
                {
                    // Check the statements under this anonymous method.
                    this.CheckClassMemberRulesForStatements(
                        expression.ChildStatements,
                        parentElement,
                        parentClass,
                        members);
                }
                else if (expression.ExpressionType == ExpressionType.MethodInvocation)
                {
                    // Check each of the arguments passed into the method call.
                    MethodInvocationExpression methodInvocation = (MethodInvocationExpression)expression;
                    foreach (Argument argument in methodInvocation.Arguments)
                    {
                        // Check each expression within this child expression.
                        this.CheckClassMemberRulesForExpression(
                            argument.Expression,
                            null,
                            parentElement,
                            parentClass,
                            members);
                    }
                }
                ////else if (expression.ExpressionType == ExpressionType.MemberAccess)
                ////{
                ////    MemberAccessExpression memberAccess = (MemberAccessExpression)expression;
                ////    if (memberAccess.OperatorType != MemberAccessExpression.Operator.QualifiedAlias)
                ////    {
                ////        this.CheckClassMemberRulesForLiteralToken(
                ////            memberAccess.Tokens.First,
                ////            expression,
                ////            parentElement,
                ////            parentClass,
                ////            members);
                ////    }
                ////}
            }
        }

        ////private void CheckClassMemberRulesForChildExpressions(
        ////    Expression expression,
        ////    Expression parentExpression,
        ////    CsElement parentElement,
        ////    ClassBase parentClass,
        ////    Dictionary<string, List<CsElement>> members)
        ////{
        ////    Param.AssertNotNull(expression, "expression");
        ////    Param.Ignore(parentExpression);
        ////    Param.AssertNotNull(parentElement, "parentElement");
        ////    Param.AssertNotNull(parentClass, "parentClass");
        ////    Param.AssertNotNull(members, "members");

        ////    foreach (Expression childExpression in expression.ChildExpressions)
        ////    {
        ////        ExpressionWithParameters expressionWithParameters = childExpression as ExpressionWithParameters;
        ////        if (expressionWithParameters != null)
        ////        {
        ////            foreach (Parameter parameter in expressionWithParameters.Parameters)
        ////            {
        ////                if (parameter.Type == null && parameter.Name != null)
        ////                {
        ////                    //todo
        ////                }
        ////            }
        ////        }
        ////        else if (childExpression.ExpressionType == ExpressionType.MethodInvocation)
        ////        {
        ////            MethodInvocationExpression methodInvocation = childExpression as MethodInvocationExpression;
        ////            foreach (Expression argument in methodInvocation.Arguments)
        ////            {
        ////                // Check each expression within this child expression.
        ////                this.CheckClassMemberRulesForExpressions(
        ////                    argument.ChildExpressions,
        ////                    argument,
        ////                    parentElement,
        ////                    parentClass,
        ////                    members);
        ////            }
        ////        }

        ////        this.CheckClassMemberRulesForChildExpressions(childExpression, expression, parentElement, parentClass, members);
        ////    }
        ////}

        /// <summary>
        /// Parses the given literal token.
        /// </summary>
        /// <param name="tokenNode">The literal token node.</param>
        /// <param name="expression">The expression that contains the token.</param>
        /// <param name="parentExpression">The parent of the expression that contains the token.</param>
        /// <param name="parentElement">The element that contains the expression.</param>
        /// <param name="parentClass">The class that the element belongs to.</param>
        /// <param name="members">The collection of members of the parent class.</param>
        private void CheckClassMemberRulesForLiteralToken(
            Node<CsToken> tokenNode,
            Expression expression,
            Expression parentExpression,
            CsElement parentElement,
            ClassBase parentClass,
            Dictionary<string, List<CsElement>> members)
        {
            Param.AssertNotNull(tokenNode, "token");
            Param.AssertNotNull(expression, "expression");
            Param.Ignore(parentExpression);
            Param.AssertNotNull(parentElement, "parentElement");
            Param.Ignore(parentClass);
            Param.Ignore(members);

            // Skip types. We only care about named members.
            if (!(tokenNode.Value is TypeToken))
            {
                // If the name starts with a dot, ignore it.
                if (!tokenNode.Value.Text.StartsWith(".", StringComparison.Ordinal))
                {
                    if (tokenNode.Value.Text == "base" && parentExpression != null)
                    {
                        // An item is only allowed to start with base if there is an implementation of the
                        // item in the local class and the caller is trying to explicitly call the base
                        // class implementation instead of the local class implementation. Extract the name
                        // of the item being accessed.
                        CsToken name = ReadabilityRules.ExtractBaseClassMemberName(parentExpression, tokenNode);
                        if (name != null)
                        {
                            ICollection<CsElement> matches = ReadabilityRules.FindClassMember(name.Text, parentClass, members, true);

                            // Check to see if there is a non-static match.
                            bool found = false;
                            if (matches != null)
                            {
                                foreach (CsElement match in matches)
                                {
                                    if (!match.Declaration.ContainsModifier(CsTokenType.Static))
                                    {
                                        found = true;
                                        break;
                                    }
                                }
                            }

                            if (!found)
                            {
                                this.AddViolation(parentElement, name.LineNumber, Rules.DoNotPrefixCallsWithBaseUnlessLocalImplementationExists, name);
                            }
                        }
                    }
                    else if (tokenNode.Value.Text != "this")
                    {
                        // Check whether this word should really start with this.
                        this.CheckWordUsageAgainstClassMemberRules(
                            tokenNode.Value.Text,
                            tokenNode.Value,
                            tokenNode.Value.LineNumber,
                            expression,
                            parentElement,
                            parentClass,
                            members);
                    }
                }
            }
        }

        /// <summary>
        /// Checks a word to see if it should start with this. or base.
        /// </summary>
        /// <param name="word">The word text to check.</param>
        /// <param name="item">The word being checked.</param>
        /// <param name="line">The line that the word appears on.</param>
        /// <param name="expression">The expression the word appears within.</param>
        /// <param name="parentElement">The element that contains the word.</param>
        /// <param name="parentClass">The parent class that this element belongs to.</param>
        /// <param name="members">The collection of members of the parent class.</param>
        private void CheckWordUsageAgainstClassMemberRules(
            string word,
            CsToken item,
            int line,
            Expression expression,
            CsElement parentElement,
            ClassBase parentClass,
            Dictionary<string, List<CsElement>> members)
        {
            Param.AssertValidString(word, "word");
            Param.AssertNotNull(item, "item");
            Param.AssertGreaterThanZero(line, "line");
            Param.AssertNotNull(expression, "expression");
            Param.AssertNotNull(parentElement, "parentElement");
            Param.Ignore(parentClass);
            Param.Ignore(members);

            // If there is a local variable with the same name, or if the item we're checking is within the left-hand side
            // of an object initializer expression, then ignore it.
            if (!IsLocalMember(word, item, expression) && !IsObjectInitializerLeftHandSideExpression(expression))
            {
                // Determine if this is a member of our class.
                CsElement foundMember = null;
                ICollection<CsElement> classMembers = ReadabilityRules.FindClassMember(word, parentClass, members, false);
                if (classMembers != null)
                {
                    if (classMembers != null)
                    {
                        foreach (CsElement classMember in classMembers)
                        {
                            if (classMember.Declaration.ContainsModifier(CsTokenType.Static) ||
                                (classMember.ElementType == ElementType.Field && ((Field)classMember).Const))
                            {
                                // There is a member with a matching name that is static or is a const field. In this case, 
                                // ignore the issue and quit.
                                foundMember = null;
                                break;
                            }
                            else if (classMember.ElementType != ElementType.Class &&
                                classMember.ElementType != ElementType.Struct &&
                                classMember.ElementType != ElementType.Delegate &&
                                classMember.ElementType != ElementType.Enum)
                            {
                                // Found a matching member.
                                if (foundMember == null)
                                {
                                    foundMember = classMember;
                                }
                            }
                        }
                    }

                    if (foundMember != null)
                    {
                        if (foundMember.ElementType == ElementType.Property)
                        {
                            // If the property's name and type are the same, then this is not a violation.
                            // In this case, the type is being accessed, not the property.
                            Property property = (Property)foundMember;
                            if (property.ReturnType.Text != property.Declaration.Name)
                            {
                                this.AddViolation(parentElement, line, Rules.PrefixLocalCallsWithThis, word);
                            }
                        }
                        else
                        {
                            this.AddViolation(parentElement, line, Rules.PrefixLocalCallsWithThis, word);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Determines whether the given element contains any partial members.
        /// </summary>
        /// <param name="element">The element to check.</param>
        /// <returns>Returns true if the element contains at least one partial member.</returns>
        private bool ContainsPartialMembers(CsElement element)
        {
            Param.AssertNotNull(element, "element");

            if (element.ElementType == ElementType.Class ||
                element.ElementType == ElementType.Struct ||
                element.ElementType == ElementType.Interface)
            {
                if (element.Declaration.ContainsModifier(CsTokenType.Partial))
                {
                    return true;
                }
            }

            if (element.ElementType == ElementType.Root ||
                element.ElementType == ElementType.Namespace ||
                element.ElementType == ElementType.Class ||
                element.ElementType == ElementType.Struct)
            {
                foreach (CsElement child in element.ChildElements)
                {
                    if (this.ContainsPartialMembers(child))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        #endregion Private Methods
    }
}
