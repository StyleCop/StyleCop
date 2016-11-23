// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Utils.cs" company="https://github.com/StyleCop">
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
//   Utility functions used by multiple rules.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    ///   Utility functions used by multiple rules.
    /// </summary>
    internal class Utils
    {
        #region Public Methods and Operators

        /// <summary>
        /// Adds all members of a class to a dictionary, taking into account partial classes.
        /// </summary>
        /// <param name="parentClass">
        /// The class to collect. 
        /// </param>
        /// <returns>
        /// Returns the dictionary of class members. 
        /// </returns>
        public static Dictionary<string, List<CsElement>> CollectClassMembers(ClassBase parentClass)
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
        /// Determines whether the given element contains any partial members.
        /// </summary>
        /// <param name="element">
        /// The element to check. 
        /// </param>
        /// <returns>
        /// Returns true if the element contains at least one partial member. 
        /// </returns>
        public static bool ContainsPartialMembers(CsElement element)
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
                    if (ContainsPartialMembers(child))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Extracts the name of the member being called from the base class.
        /// </summary>
        /// <param name="parentExpression">
        /// The expression containing the tokens. 
        /// </param>
        /// <param name="baseTokenNode">
        /// The 'base' keyword token. 
        /// </param>
        /// <returns>
        /// Returns the name of the member or null if there is no member name. 
        /// </returns>
        public static CsToken ExtractBaseClassMemberName(Expression parentExpression, Node<CsToken> baseTokenNode)
        {
            Param.AssertNotNull(parentExpression, "parentExpression");
            Param.AssertNotNull(baseTokenNode, "baseTokenNode");

            bool foundMemberAccessSymbol = false;
            foreach (CsToken token in parentExpression.Tokens.ForwardIterator(baseTokenNode.Next))
            {
                if (token.CsTokenType != CsTokenType.WhiteSpace && token.CsTokenType != CsTokenType.EndOfLine && token.CsTokenType != CsTokenType.SingleLineComment
                    && token.CsTokenType != CsTokenType.MultiLineComment && token.CsTokenType != CsTokenType.PreprocessorDirective)
                {
                    if (foundMemberAccessSymbol)
                    {
                        if (token.CsTokenType == CsTokenType.Other)
                        {
                            return token;
                        }

                        break;
                    }

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

            return null;
        }

        /// <summary>
        /// Finds the given class member in the given class.
        /// </summary>
        /// <param name="word">
        /// The word to check. 
        /// </param>
        /// <param name="parentClass">
        /// The class the word appears in. 
        /// </param>
        /// <param name="members">
        /// The collection of members of the parent class. 
        /// </param>
        /// <param name="interfaces">
        /// True if interface implementations should be included. 
        /// </param>
        /// <returns>
        /// Returns the class members that match against the given name. 
        /// </returns>
        public static ICollection<CsElement> FindClassMember(string word, ClassBase parentClass, Dictionary<string, List<CsElement>> members, bool interfaces)
        {
            Param.AssertNotNull(word, "word");
            Param.AssertNotNull(parentClass, "parentClass");
            Param.AssertNotNull(members, "members");
            Param.Ignore(interfaces);

            // If the word is the same as the class name, then this is a constructor and we
            // don't want to match against it.
            if (word != parentClass.Declaration.Name)
            {
                ICollection<CsElement> matches = MatchClassMember(word, members, interfaces);
                if (matches != null && matches.Count > 0)
                {
                    return matches;
                }
            }

            return null;
        }

        /// <summary>
        /// Finds the ClassBase object above this element representing a Class or Struct.
        /// </summary>
        /// <param name="element">
        /// The element to start at. 
        /// </param>
        /// <returns>
        /// The ClassBase for the element. 
        /// </returns>
        public static ClassBase GetClassBase(CsElement element)
        {
            bool foundParentClass = false;

            ICodePart parent = element.Parent;

            while (!foundParentClass && parent != null)
            {
                if (parent is ClassBase)
                {
                    foundParentClass = true;
                }
                else
                {
                    parent = parent.Parent;
                }
            }

            return parent as ClassBase;
        }

        /// <summary>
        /// Returns True if this class or any of its Partial Classes has a BaseClass specified.
        /// </summary>
        /// <param name="classBase">
        /// The class to check.
        /// </param>
        /// <returns>
        /// True if it finds a BaseClass.
        /// </returns>
        public static bool HasABaseClassSpecified(ClassBase classBase)
        {
            return !string.IsNullOrEmpty(classBase.BaseClass)
                   || (classBase.PartialElementList != null && classBase.PartialElementList.OfType<Class>().Any(d => !string.IsNullOrEmpty(d.BaseClass)));
        }

        /// <summary>
        /// Returns True if this class or any of its Partial Classes has a BaseClass specified.
        /// </summary>
        /// <param name="classBase">
        /// The class to check.
        /// </param>
        /// <returns>
        /// True if it finds a BaseClass.
        /// </returns>
        public static bool HasImplementedInterfaces(ClassBase classBase)
        {
            return classBase.ImplementedInterfaces.Count > 0
                   || (classBase.PartialElementList != null && classBase.PartialElementList.OfType<Class>().Any(d => d.ImplementedInterfaces.Count > 0));
        }

        /// <summary>
        /// Checks the token text matches a ReSharper suppression.
        /// </summary>
        /// <param name="token">
        /// The token to check. 
        /// </param>
        /// <returns>
        /// True if its a ReSharper token otherwise false. 
        /// </returns>
        public static bool IsAReSharperComment(CsToken token)
        {
            Param.AssertNotNull(token, "token");

            if (token.CsTokenType != CsTokenType.MultiLineComment && token.CsTokenType != CsTokenType.SingleLineComment && token.CsTokenType != CsTokenType.XmlHeader
                && token.CsTokenType != CsTokenType.XmlHeaderLine)
            {
                return false;
            }

            string tokenText = token.Text;
            return tokenText.StartsWith("// ReSharper disable ") || tokenText.StartsWith("// ReSharper restore ");
        }

        /// <summary>
        /// Returns true if we're inside one of the container types..
        /// </summary>
        /// <param name="expresion">
        /// The expression to start at.
        /// </param>
        /// <param name="codeUnits">
        /// The containers to check.
        /// </param>
        /// <returns>
        /// True if found.
        /// </returns>
        public static bool IsExpressionInsideContainer(Expression expresion, params Type[] codeUnits)
        {
            ICodePart parent = expresion.Parent;

            while (parent != null)
            {
                foreach (Type codeUnit in codeUnits)
                {
                    if (parent.GetType() == codeUnit)
                    {
                        return true;
                    }
                }

                parent = parent.Parent;
            }

            return false;
        }

        /// <summary>
        /// Returns true if the node Contains any sort of <see cref="Nullable"/>.
        /// </summary>
        /// <param name="token">
        /// The token to check. 
        /// </param>
        /// <returns>
        /// True if <see cref="Nullable"/> otherwise False. 
        /// </returns>
        public static bool TokenContainNullable(Node<CsToken> token)
        {
            if (CsTokenList.MatchTokens(StringComparison.Ordinal, token, new[] { "System", ".", "Nullable" })
                || CsTokenList.MatchTokens(StringComparison.Ordinal, token, new[] { "global", "::", "System", ".", "Nullable" })
                || token.Value.Text.Equals("Nullable", StringComparison.Ordinal))
            {
                return true;
            }

            return false;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Adds a class members to the dictionary.
        /// </summary>
        /// <param name="members">
        /// The dictionary of class members. 
        /// </param>
        /// <param name="child">
        /// The class member. 
        /// </param>
        /// <param name="name">
        /// The name of the class member. 
        /// </param>
        private static void AddClassMember(Dictionary<string, List<CsElement>> members, CsElement child, string name)
        {
            Param.AssertNotNull(members, "members");
            Param.AssertNotNull(child, "member");
            Param.AssertValidString(name, "name");

            int angleBracketPosition = name.IndexOf('<');

            if (angleBracketPosition > -1)
            {
                AddClassMemberAux(members, child, name.Substring(0, angleBracketPosition));
            }

            AddClassMemberAux(members, child, name);
        }

        /// <summary>
        /// Adds a class members to the dictionary.
        /// </summary>
        /// <param name="members">
        /// The dictionary of class members. 
        /// </param>
        /// <param name="child">
        /// The class member. 
        /// </param>
        /// <param name="name">
        /// The name of the class member. 
        /// </param>
        private static void AddClassMemberAux(Dictionary<string, List<CsElement>> members, CsElement child, string name)
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
        /// Adds all members of a class to a dictionary.
        /// </summary>
        /// <param name="class">
        /// The class to collect. 
        /// </param>
        /// <param name="members">
        /// Adds all members of the class to the given dictionary. 
        /// </param>
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
        /// Matches the given word with members of the given class.
        /// </summary>
        /// <param name="word">
        /// The word to check. 
        /// </param>
        /// <param name="members">
        /// The collection of members of the parent class. 
        /// </param>
        /// <param name="interfaces">
        /// True if interface implementations should be included. 
        /// </param>
        /// <returns>
        /// Returns the class members that matches against the given name. 
        /// </returns>
        private static ICollection<CsElement> MatchClassMember(string word, Dictionary<string, List<CsElement>> members, bool interfaces)
        {
            Param.AssertNotNull(word, "word");
            Param.AssertNotNull(members, "members");
            Param.Ignore(interfaces);

            List<CsElement> matchesFound = null;

            // Look through all the children of this class to see if the word matches
            // against any item in the class.
            List<CsElement> matches;

            if (members.TryGetValue(word, out matches))
            {
                foreach (CsElement match in matches)
                {
                    // Check if there is a match.
                    if (match.ElementType == ElementType.Field || match.Declaration.Name == word
                        || (interfaces && match.Declaration.Name.EndsWith("." + word, StringComparison.Ordinal)))
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

        #endregion
    }
}