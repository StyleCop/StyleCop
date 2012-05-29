//-----------------------------------------------------------------------
// <copyright file="ReadabilityRules.ClassMembers.cs">
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

namespace StyleCop.CSharp
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    /// <content>Checks rules related to class member calls.</content>
    public partial class ReadabilityRules
    {
        #region Public Methods and Operators

        /// <summary>
        ///   Returns a value indicating whether to delay analysis of this document until the next pass.
        /// </summary>
        /// <param name="document"> The document to analyze. </param>
        /// <param name="passNumber"> The current pass number. </param>
        /// <returns> Returns true if analysis should be delayed. </returns>
        public override bool DelayAnalysis(CodeDocument document, int passNumber)
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

        #endregion

        #region Methods

        /// <summary>
        ///   Determines whether a matching local variable is contained in the given variable list.
        /// </summary>
        /// <param name="variables"> The variable list. </param>
        /// <param name="word"> The variable name to check. </param>
        /// <param name="item"> The token containing the variable name. </param>
        /// <returns> Returns true if there is a matching local variable. </returns>
        private static bool ContainsVariable(VariableCollection variables, string word, CsToken item)
        {
            Param.AssertNotNull(variables, "variables");
            Param.AssertValidString(word, "word");
            Param.AssertNotNull(item, "item");

            word = word.SubstringAfter('@');
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
        ///   Determines whether the given token is preceded by a member access symbol.
        /// </summary>
        /// <param name="literalTokenNode"> The token to check. </param>
        /// <param name="masterList"> The list containing the token. </param>
        /// <returns> Returns true if the token is preceded by a member access symbol. </returns>
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
                if (symbol.SymbolType == OperatorType.MemberAccess || symbol.SymbolType == OperatorType.Pointer || symbol.SymbolType == OperatorType.QualifiedAlias)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        ///   Determines whether the given word is the name of a local variable.
        /// </summary>
        /// <param name="word"> The name to check. </param>
        /// <param name="item"> The token containing the word. </param>
        /// <param name="parent"> The code unit that the word appears in. </param>
        /// <returns> True if the word is the name of a local variable, false if not. </returns>
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
        ///   Determines whether the given expression is the left-hand-side literal in any of the assignment expressions within an object initialize expression.
        /// </summary>
        /// <param name="expression"> The expression to check. </param>
        /// <returns> Returns true if the expression is the left-hand-side literal in any of the assignment expressions within an object initializer expression. </returns>
        /// <remarks>
        ///   This method checks for the following situation: class MyClass { public bool Member { get { return true; } } public void SomeMethod() { MyObjectType someObject = new MyObjectType { Member = this.Member }; } } In this case, StyleCop will raise a violation since it looks like the Member token should be prefixed by 'this.', however, it is actually referring to a property on the MyObjectType type.
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

        private static bool IsThisRequiredFromMemberList(ICollection<CsElement> matchesForPassedMethod)
        {
            foreach (var classMember in matchesForPassedMethod)
            {
                if (classMember.Declaration.ContainsModifier(CsTokenType.Static) || (classMember.ElementType == ElementType.Field && ((Field)classMember).Const))
                {
                    // There is a member with a matching name that is static or is a const field. In this case, 
                    // ignore the issue and continue.
                    return false;
                }

                if (classMember.ElementType == ElementType.Class || classMember.ElementType == ElementType.Struct || classMember.ElementType == ElementType.Delegate
                    || classMember.ElementType == ElementType.Enum || classMember.ElementType == ElementType.Constructor)
                {
                    return false;
                }

                if (classMember.ElementType == ElementType.Property)
                {
                    // If the property's name and type are the same, then this is not a violation.
                    // In this case, the type is being accessed, not the property.
                    Property property = (Property)classMember;
                    if (property.ReturnType.Text == property.Declaration.Name)
                    {
                        return false;
                    }
                }
            }

            return true;
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

        /// <summary>
        ///   Checks the items within the given element.
        /// </summary>
        /// <param name="element"> The element to check. </param>
        /// <param name="parentClass"> The class that the element belongs to. </param>
        /// <param name="members"> The collection of members of the parent class. </param>
        /// <returns> Returns false if the analyzer should quit. </returns>
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

            if (element.ElementType == ElementType.Class || element.ElementType == ElementType.Struct || element.ElementType == ElementType.Interface)
            {
                parentClass = element as ClassBase;
                members = Utils.CollectClassMembers(parentClass);
            }

            foreach (CsElement child in element.ChildElements)
            {
                if (!child.Generated)
                {
                    if (child.ElementType == ElementType.Method || child.ElementType == ElementType.Constructor || child.ElementType == ElementType.Destructor
                        || child.ElementType == ElementType.Accessor)
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
        ///   Parses the given expression.
        /// </summary>
        /// <param name="expression"> The expression. </param>
        /// <param name="parentExpression"> The parent expression, if there is one. </param>
        /// <param name="parentElement"> The element that contains the expressions. </param>
        /// <param name="parentClass"> The class that the element belongs to. </param>
        /// <param name="members"> The collection of members of the parent class. </param>
        private void CheckClassMemberRulesForExpression(
            Expression expression, Expression parentExpression, CsElement parentElement, ClassBase parentClass, Dictionary<string, List<CsElement>> members)
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
                    this.CheckClassMemberRulesForLiteralToken(literalExpression.TokenNode, expression, parentExpression, parentElement, parentClass, members);
                }
            }
            else
            {
                if (expression.ExpressionType == ExpressionType.Assignment && parentExpression != null
                    && parentExpression.ExpressionType == ExpressionType.CollectionInitializer)
                {
                    // When we encounter assignment expressions within collection initializer expressions, we ignore the expression
                    // on the left-hand side of the assignment. This is because we know that the left-hand side refers to a property on
                    // the type being initialized, not a property on the local class. Thus, it does not ever need to be prefixed by this.
                    // Without this check we can get name collisions, such as:
                    // public sealed class Person
                    //// {
                    ////     public string FirstName { get; }
                    ////     public void CreateAnonymousType()
                    ////     {
                    ////         var anonymousType = new { FirstName = this.FirstName };
                    ////     }
                    //// }
                    this.CheckClassMemberRulesForExpression(((AssignmentExpression)expression).RightHandSide, expression, parentElement, parentClass, members);
                }
                else if (expression.ChildExpressions.Count > 0)
                {
                    // Check each child expression within this expression.
                    this.CheckClassMemberRulesForExpressions(expression.ChildExpressions, expression, parentElement, parentClass, members);
                }

                // Check if this is an anonymous method expression, which contains a child statement list.
                if (expression.ExpressionType == ExpressionType.AnonymousMethod)
                {
                    // Check the statements under this anonymous method.
                    this.CheckClassMemberRulesForStatements(expression.ChildStatements, parentElement, parentClass, members);
                }
                else if (expression.ExpressionType == ExpressionType.MethodInvocation)
                {
                    // Check each of the arguments passed into the method call.
                    MethodInvocationExpression methodInvocation = (MethodInvocationExpression)expression;
                    foreach (Argument argument in methodInvocation.Arguments)
                    {
                        // Check each expression within this child expression.
                        if (argument.Expression.ExpressionType != ExpressionType.MethodInvocation)
                        {
                            this.CheckClassMemberRulesForExpression(argument.Expression, null, parentElement, parentClass, members);
                        }
                    }
                }
            }
        }

        /// <summary>
        ///   Parses the list of expressions.
        /// </summary>
        /// <param name="expressions"> The list of expressions. </param>
        /// <param name="parentExpression"> The parent expression, if there is one. </param>
        /// <param name="parentElement"> The element that contains the expressions. </param>
        /// <param name="parentClass"> The class that the element belongs to. </param>
        /// <param name="members"> The collection of members of the parent class. </param>
        private void CheckClassMemberRulesForExpressions(
            ICollection<Expression> expressions, Expression parentExpression, CsElement parentElement, ClassBase parentClass, Dictionary<string, List<CsElement>> members)
        {
            Param.AssertNotNull(expressions, "expressions");
            Param.AssertNotNull(parentElement, "parentElement");
            Param.Ignore(parentExpression);
            Param.Ignore(parentClass);
            Param.Ignore(members);

            // Loop through each of the expressions in the list.
            foreach (Expression expression in expressions)
            {
                // If the expression is a variable declarator expression, we don't want to match against the identifier tokens.
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
        ///   Parses the given literal token.
        /// </summary>
        /// <param name="tokenNode"> The literal token node. </param>
        /// <param name="expression"> The expression that contains the token. </param>
        /// <param name="parentExpression"> The parent of the expression that contains the token. </param>
        /// <param name="parentElement"> The element that contains the expression. </param>
        /// <param name="parentClass"> The class that the element belongs to. </param>
        /// <param name="members"> The collection of members of the parent class. </param>
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
            if (!(tokenNode.Value is TypeToken) || tokenNode.Value.CsTokenClass == CsTokenClass.GenericType)
            {
                // If the name starts with a dot, ignore it.
                if (!tokenNode.Value.Text.StartsWith(".", StringComparison.Ordinal))
                {
                    if (tokenNode.Value.Text == "base" && parentExpression != null)
                    {
                        CsToken name = Utils.ExtractBaseClassMemberName(parentExpression, tokenNode);
                        if (name != null)
                        {
                            if (!this.IsBaseRequired(name.Text, parentClass, members))
                            {
                                this.AddViolation(parentElement, name.Location, Rules.DoNotPrefixCallsWithBaseUnlessLocalImplementationExists, name);
                            }
                        }
                    }
                    else if (tokenNode.Value.Text != "this")
                    {
                        if (this.IsThisRequired(tokenNode, expression, parentClass, members))
                        {
                            if ((parentClass.BaseClass != string.Empty) || (tokenNode.Value.Text == "Equals" || tokenNode.Value.Text == "ReferenceEquals"))
                            {
                                string className = parentClass.FullyQualifiedName.SubstringAfterLast('.');
                                this.AddViolation(parentElement, tokenNode.Value.Location, Rules.PrefixCallsCorrectly, tokenNode.Value.Text, className);
                            }
                            else
                            {
                                this.AddViolation(parentElement, tokenNode.Value.Location, Rules.PrefixLocalCallsWithThis, tokenNode.Value.Text);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        ///   Parses the given statement list.
        /// </summary>
        /// <param name="statements"> The list of statements to parse. </param>
        /// <param name="parentElement"> The element that contains the statements. </param>
        /// <param name="parentClass"> The class that the element belongs to. </param>
        /// <param name="members"> The collection of members of the parent class. </param>
        private void CheckClassMemberRulesForStatements(
            ICollection<Statement> statements, CsElement parentElement, ClassBase parentClass, Dictionary<string, List<CsElement>> members)
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
        ///   Determines whether the given element contains any partial members.
        /// </summary>
        /// <param name="element"> The element to check. </param>
        /// <returns> Returns true if the element contains at least one partial member. </returns>
        private bool ContainsPartialMembers(CsElement element)
        {
            Param.AssertNotNull(element, "element");

            if (element.ElementType == ElementType.Class || element.ElementType == ElementType.Struct || element.ElementType == ElementType.Interface)
            {
                if (element.Declaration.ContainsModifier(CsTokenType.Partial))
                {
                    return true;
                }
            }

            if (element.ElementType == ElementType.Root || element.ElementType == ElementType.Namespace || element.ElementType == ElementType.Class
                || element.ElementType == ElementType.Struct)
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

        /// <summary>
        ///   Calculates whether the base prefix is required.
        /// </summary>
        /// <param name="memberName"> The text of the method call to check. </param>
        /// <param name="parentClass"> The class this this member belongs to. </param>
        /// <param name="members"> All the members of this class. </param>
        /// <returns> True if base is required otherise false. </returns>
        private bool IsBaseRequired(string memberName, ClassBase parentClass, Dictionary<string, List<CsElement>> members)
        {
            // An item is only allowed to start with base if there is an implementation of the
            // item in the local class and the caller is trying to explicitly call the base
            // class implementation instead of the local class implementation.
            bool memberNameHasGeneric = memberName.IndexOf('<') > -1;

            bool overrideOnTrimmedMethod = false;
            bool overrideOnGenericMethod = false;
            bool overrideOnPassedMethod = false;

            bool newOnPassedMethod = false;
            bool newOnGenericMethod = false;

            ICollection<CsElement> matchesForTrimmedMethod = null;
            ICollection<CsElement> matchesForGenericMethod = null;
            ICollection<CsElement> matchesForPassedMethod = Utils.FindClassMember(memberName, parentClass, members, true);

            if (memberNameHasGeneric)
            {
                var trimmedName = memberName.Substring(0, memberName.IndexOf('<'));

                matchesForTrimmedMethod = Utils.FindClassMember(trimmedName, parentClass, members, true);

                if (matchesForTrimmedMethod != null)
                {
                    foreach (CsElement match in matchesForTrimmedMethod)
                    {
                        if (match.Declaration.ContainsModifier(CsTokenType.Override))
                        {
                            overrideOnTrimmedMethod = true;
                            break;
                        }
                    }
                }
            }
            else
            {
                matchesForGenericMethod = Utils.FindClassMember(memberName + "<T>", parentClass, members, true);

                if (matchesForGenericMethod != null)
                {
                    foreach (CsElement match in matchesForGenericMethod)
                    {
                        if (match.Declaration.ContainsModifier(CsTokenType.Override))
                        {
                            overrideOnGenericMethod = true;
                        }

                        if (match.Declaration.ContainsModifier(CsTokenType.New))
                        {
                            newOnGenericMethod = true;
                        }
                    }
                }
            }

            // We check for a method marked override and a method marked new
            if (matchesForPassedMethod != null)
            {
                foreach (CsElement match in matchesForPassedMethod)
                {
                    if (match.Declaration.ContainsModifier(CsTokenType.Override))
                    {
                        overrideOnPassedMethod = true;
                    }

                    if (match.Declaration.ContainsModifier(CsTokenType.New))
                    {
                        newOnPassedMethod = true;
                        break;
                    }
                }
            }

            // method A1 marked override OR 
            // method A1<T> marked new OR
            // method A1<T> marked override OR
            // base is ok
            bool baseIsRequired = memberNameHasGeneric && (overrideOnTrimmedMethod || newOnPassedMethod || overrideOnPassedMethod);

            if (!memberNameHasGeneric && (overrideOnPassedMethod || newOnGenericMethod || overrideOnGenericMethod || matchesForPassedMethod != null))
            {
                // method A1 marked override OR
                // method A1<T> marked new OR 
                // method A1 OR
                // method A1<T> marked override
                // If found then base is ok.
                // base is ok
                baseIsRequired = true;
            }

            if (memberNameHasGeneric && (overrideOnTrimmedMethod || matchesForTrimmedMethod != null))
            {
                // method A1 marked override OR
                // method A1 
                // base is ok
                baseIsRequired = true;
            }

            return baseIsRequired;
        }

        /// <summary>
        ///   Checks a token to see if it should be prefixed (with this. or maybe another prefix).
        /// </summary>
        /// <param name="tokenNode"> The TokenNode to check. </param>
        /// <param name="expression"> The expression the word appears within. </param>
        /// <param name="parentClass"> The parent class that this element belongs to. </param>
        /// <param name="members"> The collection of members of the parent class. </param>
        /// <returns> True if the prefix is required otherwise false. </returns>
        private bool IsThisRequired(Node<CsToken> tokenNode, Expression expression, ClassBase parentClass, Dictionary<string, List<CsElement>> members)
        {
            string memberName = tokenNode.Value.Text;

            if (IsLocalMember(memberName, tokenNode.Value, expression) || IsObjectInitializerLeftHandSideExpression(expression))
            {
                return false;
            }

            ICollection<CsElement> matchesForGenericMethod = null;
            ICollection<CsElement> matchesForTrimmedMethod = null;
            ICollection<CsElement> matchesForPassedMethod = Utils.FindClassMember(memberName, parentClass, members, true);

            bool memberNameHasGeneric = memberName.IndexOf('<') > -1;

            if (memberNameHasGeneric)
            {
                if (expression.ExpressionType == ExpressionType.MethodInvocation)
                {
                    return false;
                }

                var expressionParent = expression.Parent as Expression;

                if (expressionParent != null && (expressionParent.ExpressionType == ExpressionType.Cast || expressionParent.ExpressionType == ExpressionType.Is))
                {
                    return false;
                }

                var expressionParentParent = expression.Parent.Parent as Expression;

                if (expressionParentParent != null && expressionParentParent.ExpressionType == ExpressionType.New)
                {
                    return false;
                }

                if (tokenNode.Value.CsTokenType != CsTokenType.Other)
                {
                    return false;
                }

                if (matchesForPassedMethod != null)
                {
                    return IsThisRequiredFromMemberList(matchesForPassedMethod);
                }

                var trimmedName = memberName.Substring(0, memberName.IndexOf('<'));

                matchesForGenericMethod = Utils.FindClassMember(trimmedName + "<T>", parentClass, members, true);

                if (matchesForGenericMethod != null)
                {
                    return IsThisRequiredFromMemberList(matchesForGenericMethod);
                }

                matchesForTrimmedMethod = Utils.FindClassMember(trimmedName, parentClass, members, true);

                if (matchesForTrimmedMethod != null)
                {
                    return IsThisRequiredFromMemberList(matchesForTrimmedMethod);
                }

                if (parentClass.BaseClass != string.Empty)
                {
                    if (Utils.IsExpressionInsideContainer(expression, typeof(AsExpression), typeof(NewExpression), typeof(MemberAccessExpression), typeof(CatchStatement), typeof(VariableDeclarationExpression)))
                    {
                        return false;
                    }

                    return true;
                }

                return false;
            }

            if (tokenNode.Value.CsTokenType != CsTokenType.Other)
            {
                return false;
            }

            if (memberName == "object")
            {
                return false;
            }

            matchesForGenericMethod = Utils.FindClassMember(memberName + "<T>", parentClass, members, true);

            if (matchesForPassedMethod != null)
            {
                return IsThisRequiredFromMemberList(matchesForPassedMethod);
            }

            if (matchesForGenericMethod != null)
            {
                return IsThisRequiredFromMemberList(matchesForGenericMethod); 
            }

            if (parentClass.BaseClass != string.Empty)
            {
                if (Utils.IsExpressionInsideContainer(expression, typeof(AsExpression), typeof(NewExpression), typeof(MemberAccessExpression), typeof(CatchStatement), typeof(VariableDeclarationExpression)))
                {
                    return false;
                }

                return true;
            }

            if (memberName == "Equals")
            {
                return true;
            }

            return false;
        }

        #endregion
    }
}