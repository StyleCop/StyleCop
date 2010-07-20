//-----------------------------------------------------------------------
// <copyright file="CodeUnitExtensions.cs" company="Microsoft">
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
namespace Microsoft.StyleCop.CSharp.CodeModel
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using Microsoft.StyleCop.CSharp.CodeModel.Collections;

    /// <summary>
    /// Extension methods for the CodeUnit class.
    /// </summary>
    public static class CodeUnitExtensions
    {
        /// <summary>
        /// Determines whether the given start token lies at the start of a string of tokens matching the given array of strings.
        /// comments.
        /// </summary>
        /// <param name="codeUnit">The code unit that contains the tokens.</param>
        /// <param name="start">Begins matching the given strings with this token.</param>
        /// <param name="values">The collection of strings to match against.</param>
        /// <returns>Returns true if the tokens match the collection of strings.</returns>
        /// <remarks>Only considers tokens at the same level in the hierarchy as the start token.</remarks>
        public static bool MatchTokens(this CodeUnit codeUnit, Token start, params string[] values)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.RequireNotNull(start, "start");
            Param.RequireNotNull(values, "values");

            int index = 0;

            for (Token token = start; token != null && index < values.Length; token = token.FindNextInTree<Token>(codeUnit))
            {
                if (!token.Text.Equals(values[index], StringComparison.Ordinal))
                {
                    return false;
                }

                ++index;
            }

            return index >= values.Length;
        }

        /// <summary>
        /// Gets the collection of expressions one level beneath this code unit.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <returns>Returns the collection of child expressions.</returns>
        public static ICollection<Expression> FindChildExpressions(this CodeUnit codeUnit)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");

            if (codeUnit.Children == null)
            {
                return Expression.EmptyExpressionArray;
            }

            return codeUnit.Children.GetExpressionCollection();
        }

        /// <summary>
        /// Gets the collection of statements one level beneath this code unit.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <returns>Returns the collection of child statements.</returns>
        public static ICollection<Statement> FindChildStatements(this CodeUnit codeUnit)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");

            if (codeUnit.Children == null)
            {
                return Statement.EmptyStatementArray;
            }

            return codeUnit.Children.GetStatementCollection();
        }

        /// <summary>
        /// Gets the collection of elements one level beneath this code unit.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <returns>Returns the collection of child elements.</returns>
        public static ICollection<Element> FindChildElements(this CodeUnit codeUnit)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");

            if (codeUnit.Children == null)
            {
                return Element.EmptyElementArray;
            }

            return codeUnit.Children.GetElementCollection();
        }

        /// <summary>
        /// Gets the collection of query clauses one level beneath this code unit.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <returns>Returns the collection of child query clauses.</returns>
        public static ICollection<QueryClause> FindChildQueryClauses(this CodeUnit codeUnit)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");

            if (codeUnit.Children == null)
            {
                return QueryClause.EmptyQueryClauseArray;
            }

            return codeUnit.Children.GetQueryClauseCollection();
        }

        /// <summary>
        /// Gets the collection of lexical elements one level beneath this code unit.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <returns>Returns the collection of child lexical elements.</returns>
        public static ICollection<LexicalElement> FindChildLexicalElements(this CodeUnit codeUnit)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");

            if (codeUnit.Children == null)
            {
                return LexicalElement.EmptyLexicalElementArray;
            }

            return codeUnit.Children.GetLexicalElementCollection();
        }

        /// <summary>
        /// Given a parent code unit, traverses through the parent hierarchy to find a parent element, if there is one.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <typeparam name="T">The type of the parent to return.</typeparam>
        /// <returns>Returns the parent element or null if there is none.</returns>
        public static T FindParent<T>(this CodeUnit codeUnit) where T : CodeUnit
        {
            Param.RequireNotNull(codeUnit, "codeUnit");

            CodeUnit parentCodeUnit = codeUnit.Parent;
            while (parentCodeUnit != null)
            {
                T item = parentCodeUnit as T;
                if (item != null)
                {
                    return item;
                }

                parentCodeUnit = parentCodeUnit.Parent;
            }

            return null;
        }

        /// <summary>
        /// Gets the next code unit of the given type at any level in the hierarchy.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <typeparam name="T">The type of the item to return.</typeparam>
        /// <returns>Returns the next code unit or null if there are no code units of the requested type.</returns>
        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Justification = "The method does not require a parameter of type T.")]
        public static T FindNext<T>(this CodeUnit codeUnit) where T : CodeUnit
        {
            Param.RequireNotNull(codeUnit, "codeUnit");

            CodeUnit item = codeUnit;
            while (item != null)
            {
                if (item != codeUnit)
                {
                    T typedItem = Compare<T>(item);
                    if (typedItem != null)
                    {
                        return typedItem;
                    }
                }

                // Move down to the first of the item's children.
                if (item.Children != null && item.Children.Count > 0)
                {
                    item = item.Children.First;
                }
                else if (item.LinkNode.Next != null)
                {
                    // The item has no children. Move to its next sibling.
                    item = item.LinkNode.Next;
                }
                else
                {
                    // The item has no children and no siblings. Find the first ancestor with a sibling.
                    // If the root is set, then ensure that we do not navigate above the root.
                    CodeUnit parent = item.Parent;
                    while (parent != null && parent.LinkNode.Next == null)
                    {
                        parent = parent.Parent;
                    }

                    if (parent != null)
                    {
                        item = parent.LinkNode.Next;
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
        /// Gets the next code unit of the given type which is a descendent of the given root.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="root">The root ancenstor of the next codeUnit.</param>
        /// <typeparam name="T">The type of the item to return.</typeparam>
        /// <returns>Returns the next code unit or null if there are no code units of the requested type.</returns>
        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Justification = "The method does not require a parameter of type T.")]
        public static T FindNextDescendentOf<T>(this CodeUnit codeUnit, CodeUnit root) where T : CodeUnit
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(root);

            CodeUnit item = codeUnit;
            while (item != null)
            {
                if (item != codeUnit)
                {
                    T typedItem = Compare<T>(item);
                    if (typedItem != null)
                    {
                        return typedItem;
                    }
                }

                // Move down to the first of the item's children.
                if (item.Children != null && item.Children.Count > 0)
                {
                    item = item.Children.First;
                }
                else if (item.LinkNode.Next != null)
                {
                    // The item has no children. Move to its next sibling.
                    item = item.LinkNode.Next;
                }
                else
                {
                    // The item has no children and no siblings. Find the first ancestor with a sibling.
                    // Ensure that we do not navigate above the root.
                    if (item != root)
                    {
                        CodeUnit parent = item.Parent;
                        while (parent != null && parent.LinkNode.Next == null && parent != root)
                        {
                            parent = parent.Parent;
                        }

                        if (parent != null && parent != root)
                        {
                            item = parent.LinkNode.Next;
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
        /// Gets the next code unit of the given type which is a descendent of the given root or is the root itself.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="root">The root code unit.</param>
        /// <typeparam name="T">The type of the item to return.</typeparam>
        /// <returns>Returns the next code unit or null if there are no code units of the requested type.</returns>
        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Justification = "The method does not require a parameter of type T.")]
        public static T FindNextInTree<T>(this CodeUnit codeUnit, CodeUnit root) where T : CodeUnit
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(root);

            CodeUnit item = codeUnit;
            while (item != null)
            {
                if (item != codeUnit)
                {
                    T typedItem = Compare<T>(item);
                    if (typedItem != null)
                    {
                        return typedItem;
                    }
                }

                // Move down to the first of the item's children.
                if (item.Children != null && item.Children.Count > 0)
                {
                    item = item.Children.First;
                }
                else if (item.LinkNode.Next != null && item != root)
                {
                    // The item has no children. Move to its next sibling.
                    item = item.LinkNode.Next;
                }
                else
                {
                    // The item has no children and no siblings. Find the first ancestor with a sibling.
                    if (item != root)
                    {
                        CodeUnit parent = item.Parent;
                        while (parent != null && parent.LinkNode.Next == null && parent != root)
                        {
                            parent = parent.Parent;
                        }

                        if (parent != null && parent != root)
                        {
                            item = parent.LinkNode.Next;
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
        /// Gets the next code unit of the given type which is a direct child of the given parent.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <typeparam name="T">The type of the item to return.</typeparam>
        /// <returns>Returns the next code unit or null if there are no code units of the requested type.</returns>
        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Justification = "The method does not require a parameter of type T.")]
        public static T FindNextSibling<T>(this CodeUnit codeUnit) where T : CodeUnit
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            CodeUnit item = codeUnit.LinkNode.Next;
            while (item != null)
            {
                T typedItem = Compare<T>(item);
                if (typedItem != null)
                {
                    return typedItem;
                }

                item = item.LinkNode.Next;
            }

            return null;
        }

        /// <summary>
        /// Gets the previous code unit of the given type at any level in the hierarchy.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <typeparam name="T">The type of the item to return.</typeparam>
        /// <returns>Returns the previous code unit or null if there are no code units of the requested type.</returns>
        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Justification = "The method does not require a parameter of type T.")]
        public static T FindPrevious<T>(this CodeUnit codeUnit) where T : CodeUnit
        {
            Param.RequireNotNull(codeUnit, "codeUnit");

            CodeUnit item = codeUnit;
            while (item != null)
            {
                if (item != codeUnit)
                {
                    T typedItem = Compare<T>(item);
                    if (typedItem != null)
                    {
                        // We've found an item which is of the requested type and passes all the checks.
                        return typedItem;
                    }
                }

                // Move to the previous sibling if one exists.
                if (item.LinkNode.Previous != null)
                {
                    item = item.LinkNode.Previous;

                    // If the previous item has any children, move to the very last item
                    // under this node.
                    if (item.Children != null && item.Children.Count > 0)
                    {
                        item = item.FindLastDescendent<T>();
                    }
                }
                else if (item.Parent != null)
                {
                    // The item has no previous sibling. Move to the item's parent.
                    item = item.Parent;
                }
                else
                {
                    // The item has no previous sibling and no parent. 
                    break;
                }
            }

            return null;
        }

        /// <summary>
        /// Gets the previous code unit of the given type at any level in the hierarchy which is not a parent or ancestor of this code unit.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <typeparam name="T">The type of the codeUnit to return.</typeparam>
        /// <returns>Returns the previous code unit or null if there are no code units of the requested type.</returns>
        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Justification = "The method does not require a parameter of type T.")]
        public static T FindPreviousNonParent<T>(this CodeUnit codeUnit) where T : CodeUnit
        {
            Param.RequireNotNull(codeUnit, "codeUnit");

            CodeUnit item = codeUnit;
            bool itemIsParent = false;

            while (item != null)
            {
                if (item != codeUnit && !itemIsParent)
                {
                    T typedItem = Compare<T>(item);
                    if (typedItem != null)
                    {
                        // We've found an item which is of the requested type and passes all the checks.
                        return typedItem;
                    }
                }

                itemIsParent = false;

                // Move to the previous sibling if one exists.
                if (item.LinkNode.Previous != null)
                {
                    item = item.LinkNode.Previous;

                    // If the previous item has any children, move to the very last item
                    // under this node.
                    if (item.Children != null && item.Children.Count > 0)
                    {
                        item = item.FindLastDescendent<T>();
                    }
                }
                else if (item.Parent != null)
                {
                    // The item has no previous sibling. Move to the item's parent.
                    item = item.Parent;
                    itemIsParent = true;
                }
                else
                {
                    // The item has no previous sibling and no parent. 
                    break;
                }
            }

            return null;
        }

        /// <summary>
        /// Gets the previous code unit of the given type which is a descendent of the given root.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="root">The root ancenstor of the previous codeUnit.</param>
        /// <typeparam name="T">The type of the codeUnit to return.</typeparam>
        /// <returns>Returns the previous code unit or null if there are no code units of the requested type.</returns>
        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Justification = "The method does not require a parameter of type T.")]
        public static T FindPreviousDescendentOf<T>(this CodeUnit codeUnit, CodeUnit root) where T : CodeUnit
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(root);

            CodeUnit item = codeUnit;
            while (item != null && item != root)
            {
                if (item != codeUnit)
                {
                    T typedItem = Compare<T>(item);
                    if (typedItem != null)
                    {
                        // We've found an item which is of the requested type and passes all the checks.
                        return typedItem;
                    }
                }

                // Move to the previous sibling if one exists.
                if (item.LinkNode.Previous != null)
                {
                    item = item.LinkNode.Previous;

                    // If the previous item has any children, move to the very last item
                    // under this node.
                    if (item.Children != null && item.Children.Count > 0)
                    {
                        item = item.FindLastDescendent<T>();
                    }
                }
                else if (item.Parent != null)
                {
                    // The item has no previous sibling. Move to the item's parent.
                    item = item.Parent;
                }
                else
                {
                    // The item has no previous sibling and no parent. 
                    break;
                }
            }

            return null;
        }

        /// <summary>
        /// Gets the previous code unit of the given type which is a descendent of the given root or is the root itself.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="root">The root item.</param>
        /// <typeparam name="T">The type of the item to return.</typeparam>
        /// <returns>Returns the previous code unit or null if there are no code units of the requested type.</returns>
        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Justification = "The method does not require a parameter of type T.")]
        public static T FindPreviousInTree<T>(this CodeUnit codeUnit, CodeUnit root) where T : CodeUnit
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(root);

            CodeUnit item = codeUnit;
            while (item != null)
            {
                if (item != codeUnit)
                {
                    T typedItem = Compare<T>(item);
                    if (typedItem != null)
                    {
                        // We've found an item which is of the requested type and passes all the checks.
                        return typedItem;
                    }
                }

                // Move to the previous sibling if one exists.
                if (item.LinkNode.Previous != null && item != root)
                {
                    item = item.LinkNode.Previous;

                    // If the previous item has any children, move to the very last item
                    // under this node.
                    if (item.Children != null && item.Children.Count > 0)
                    {
                        item = item.FindLastDescendent<T>();
                    }
                }
                else if (item.Parent != null && item != root)
                {
                    // The item has no previous sibling. Move to the item's parent.
                    item = item.Parent;
                }
                else
                {
                    // The item has no previous sibling and no parent. 
                    break;
                }
            }

            return null;
        }

        /// <summary>
        /// Gets the previous code unit of the given type which is a direct child of the given parent.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <typeparam name="T">The type of the item to return.</typeparam>
        /// <returns>Returns the previous code unit or null if there are no code units of the requested type.</returns>
        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Justification = "The method does not require a parameter of type T.")]
        public static T FindPreviousSibling<T>(this CodeUnit codeUnit) where T : CodeUnit
        {
            Param.RequireNotNull(codeUnit, "codeUnit");

            CodeUnit item = codeUnit.LinkNode.Previous;
            while (item != null)
            {
                T typedItem = Compare<T>(item);
                if (typedItem != null)
                {
                    // We've found an item which is of the requested type and passes all the checks.
                    return typedItem;
                }

                item = item.LinkNode.Previous;
            }

            return null;
        }

        /// <summary>
        /// Gets the first code unit of the given type which is a direct child of this code unit.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <typeparam name="T">The type of the item to return.</typeparam>
        /// <returns>Returns the first code unit or null if there are no code units of the requested type.</returns>
        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Justification = "The method does not require a parameter of type T.")]
        public static T FindFirstChild<T>(this CodeUnit codeUnit) where T : CodeUnit
        {
            Param.RequireNotNull(codeUnit, "codeUnit");

            CodeUnit item = codeUnit.Children.First;
            while (item != null)
            {
                T typedItem = Compare<T>(item);
                if (typedItem != null)
                {
                    return typedItem;
                }

                item = item.LinkNode.Next;
            }

            return null;
        }

        /// <summary>
        /// Gets the first code unit of the given type which is a descendent of this code unit.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <typeparam name="T">The type of the item to return.</typeparam>
        /// <returns>Returns the first code unit or null if there are no code units of the requested type.</returns>
        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Justification = "The method does not require a parameter of type T.")]
        public static T FindFirstDescendent<T>(this CodeUnit codeUnit) where T : CodeUnit
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            return codeUnit.FindNextDescendentOf<T>(codeUnit);
        }

        /// <summary>
        /// Gets the first code unit of the given type which is a descendent of this code unit or this code unit itself.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <typeparam name="T">The type of the item to return.</typeparam>
        /// <returns>Returns the first code unit or null if there are no code units of the requested type.</returns>
        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Justification = "The method does not require a parameter of type T.")]
        public static T FindFirstInTree<T>(this CodeUnit codeUnit) where T : CodeUnit
        {
            Param.RequireNotNull(codeUnit, "codeUnit");

            CodeUnit item = codeUnit;
            while (item != null)
            {
                T typedItem = Compare<T>(item);
                if (typedItem != null)
                {
                    return typedItem;
                }

                // Move down to the first of the item's children.
                if (item.Children != null && item.Children.Count > 0)
                {
                    item = item.Children.First;
                }
                else if (item.LinkNode.Next != null)
                {
                    // The item has no children. Move to its next sibling.
                    item = item.LinkNode.Next;
                }
                else
                {
                    // The item has no children and no siblings. Find the first ancestor with a sibling.
                    // Ensure that we do not navigate above this instance.
                    if (item != codeUnit)
                    {
                        CodeUnit parent = item.Parent;
                        while (parent != null && parent.LinkNode.Next == null && parent != codeUnit)
                        {
                            parent = parent.Parent;
                        }

                        if (parent != null && parent != codeUnit)
                        {
                            item = parent.LinkNode.Next;
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
        /// Gets the last code unit of the given type which is a direct child of this code unit.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <typeparam name="T">The type of the item to return.</typeparam>
        /// <returns>Returns the last code unit or null if there are no code units of the requested type.</returns>
        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Justification = "The method does not require a parameter of type T.")]
        public static T FindLastChild<T>(this CodeUnit codeUnit) where T : CodeUnit
        {
            Param.RequireNotNull(codeUnit, "codeUnit");

            CodeUnit item = codeUnit.Children.Last;
            while (item != null)
            {
                T typedItem = Compare<T>(item);
                if (typedItem != null)
                {
                    return typedItem;
                }

                item = item.LinkNode.Previous;
            }

            return null;
        }

        /// <summary>
        /// Gets the last code unit of the given type which is a descendent of this code unit.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <typeparam name="T">The type of the item to return.</typeparam>
        /// <returns>Returns the last code unit or null if there are no code units of the requested type.</returns>
        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Justification = "The method does not require a parameter of type T.")]
        public static T FindLastDescendent<T>(this CodeUnit codeUnit) where T : CodeUnit
        {
            Param.RequireNotNull(codeUnit, "codeUnit");

            // Move to the very last item in the hierarchy.
            CodeUnit item = codeUnit.Children.Last;
            while (item != null && item.Children.Count > 0)
            {
                item = item.Children.Last;
            }

            // Check to see if the last descendent matches the filter.
            if (item != null)
            {
                T typedItem = Compare<T>(item);
                if (typedItem != null)
                {
                    return typedItem;
                }

                // The very last item does not match, so find the previous descendent of this item that matches.
                return item.FindPreviousDescendentOf<T>(codeUnit);
            }

            return null;
        }

        /// <summary>
        /// Gets the last code unit of the given type which is a descendent of this code unit or this code unit itself.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <typeparam name="T">The type of the item to return.</typeparam>
        /// <returns>Returns the last code unit or null if there are no code units of the requested type.</returns>
        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Justification = "The method does not require a parameter of type T.")]
        public static T FindLastInTree<T>(this CodeUnit codeUnit) where T : CodeUnit
        {
            Param.RequireNotNull(codeUnit, "codeUnit");

            // Move to the very last item in the hierarchy.
            CodeUnit item = codeUnit;
            while (item != null && item.Children.Count > 0)
            {
                item = item.Children.Last;
            }

            // Check to see if the last descendent matches the filter.
            if (item != null)
            {
                T typedItem = Compare<T>(item);
                if (typedItem != null)
                {
                    return typedItem;
                }

                // The very last item does not match, so find the previous descendent of this item that matches.
                return item.FindPreviousInTree<T>(codeUnit);
            }

            return null;
        }

        /// <summary>
        /// Iterates through the descendents of the CodeUnit.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <typeparam name="T">The type of the items to return.</typeparam>
        /// <returns>Returns the enumerable object.</returns>
        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Justification = "The method does not require a parameter of type T.")]
        public static IEnumerable<T> GetDescendents<T>(this CodeUnit codeUnit) where T : CodeUnit
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            return new CodeUnitDescendentEnumerable<T>(codeUnit);
        }

        /// <summary>
        /// Iterates through the direct children of the CodeUnit.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <typeparam name="T">The type of the items to return.</typeparam>
        /// <returns>Returns the enumerable object.</returns>
        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Justification = "The method does not require a parameter of type T.")]
        public static IEnumerable<T> GetChildren<T>(this CodeUnit codeUnit) where T : CodeUnit
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            return new CodeUnitChildrenEnumerable<T>(codeUnit);
        }

        /// <summary>
        /// Determines whether the item is of the given type.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type to compare against.</param>
        /// <returns>Returns true if the item is of the given type; false otherwise.</returns>
        public static bool Is(this CodeUnit codeUnit, CodeUnitType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return codeUnit.Is((int)type, FundamentalTypeMasks.CodeUnit);
        }

        /// <summary>
        /// Determines whether the item is of the given type.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="lexicalElementType">The type to compare against.</param>
        /// <returns>Returns true if the item is of the given type; false otherwise.</returns>
        public static bool Is(this CodeUnit codeUnit, LexicalElementType lexicalElementType)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(lexicalElementType);

            return codeUnit.Is((int)lexicalElementType, FundamentalTypeMasks.LexicalElement);
        }

        /// <summary>
        /// Determines whether the item is of the given type.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="tokenType">The type to compare against.</param>
        /// <returns>Returns true if the item is of the given type; false otherwise.</returns>
        public static bool Is(this CodeUnit codeUnit, TokenType tokenType)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(tokenType);

            return codeUnit.Is((int)tokenType, FundamentalTypeMasks.Token);
        }

        /// <summary>
        /// Determines whether the item is of the given type.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="operatorType">The type to compare against.</param>
        /// <returns>Returns true if the item is of the given type; false otherwise.</returns>
        public static bool Is(this CodeUnit codeUnit, OperatorType operatorType)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(operatorType);

            return codeUnit.Is((int)operatorType, FundamentalTypeMasks.Operator);
        }

        /// <summary>
        /// Determines whether the item is of the given type.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="commentType">The type to compare against.</param>
        /// <returns>Returns true if the item is of the given type; false otherwise.</returns>
        public static bool Is(this CodeUnit codeUnit, CommentType commentType)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(commentType);

            return codeUnit.Is((int)commentType, FundamentalTypeMasks.Comment);
        }

        /// <summary>
        /// Determines whether the item is of the given type.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="preprocessorType">The type to compare against.</param>
        /// <returns>Returns true if the item is of the given type; false otherwise.</returns>
        public static bool Is(this CodeUnit codeUnit, PreprocessorType preprocessorType)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(preprocessorType);

            return codeUnit.Is((int)preprocessorType, FundamentalTypeMasks.Preprocessor);
        }

        /// <summary>
        /// Determines whether the item is of the given type.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="queryClauseType">The type to compare against.</param>
        /// <returns>Returns true if the item is of the given type; false otherwise.</returns>
        public static bool Is(this CodeUnit codeUnit, QueryClauseType queryClauseType)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(queryClauseType);

            return codeUnit.Is((int)queryClauseType, FundamentalTypeMasks.QueryClause);
        }

        /// <summary>
        /// Determines whether the item is of the given type.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="expressionType">The type to compare against.</param>
        /// <returns>Returns true if the item is of the given type; false otherwise.</returns>
        public static bool Is(this CodeUnit codeUnit, ExpressionType expressionType)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(expressionType);

            return codeUnit.Is((int)expressionType, FundamentalTypeMasks.Expression);
        }

        /// <summary>
        /// Determines whether the item is of the given type.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="statementType">The type to compare against.</param>
        /// <returns>Returns true if the item is of the given type; false otherwise.</returns>
        public static bool Is(this CodeUnit codeUnit, StatementType statementType)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(statementType);

            return codeUnit.Is((int)statementType, FundamentalTypeMasks.Statement);
        }

        /// <summary>
        /// Determines whether the item is of the given type.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="elementType">The type to compare against.</param>
        /// <returns>Returns true if the item is of the given type; false otherwise.</returns>
        public static bool Is(this CodeUnit codeUnit, ElementType elementType)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(elementType);

            return codeUnit.Is((int)elementType, FundamentalTypeMasks.Element);
        }

        /// <summary>
        /// Walks through the code units beneath this code unit.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="callback">Callback executed when a code unit is visited.</param>
        /// <param name="context">The optional visitor context data.</param>
        /// <param name="codeUnitTypes">The types of the code units to return.</param>
        /// <typeparam name="T">The type of the context item.</typeparam>
        public static void WalkCodeModel<T>(this CodeUnit codeUnit, CodeUnitVisitor<T> callback, T context, params CodeUnitType[] codeUnitTypes)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.RequireNotNull(callback, "callback");
            Param.Ignore(context);
            Param.Ignore(codeUnitTypes);

            CodeWalker<T>.Start(codeUnit, callback, context, codeUnitTypes);
        }

        /// <summary>
        /// Walks through the code units beneath this code unit.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="callback">Callback executed when a code unit is visited.</param>
        /// <param name="context">The optional visitor context data.</param>
        /// <typeparam name="T">The type of the context item.</typeparam>
        public static void WalkCodeModel<T>(this CodeUnit codeUnit, CodeUnitVisitor<T> callback, T context)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.RequireNotNull(callback, "callback");
            Param.Ignore(context);

            CodeWalker<T>.Start(codeUnit, callback, context, null);
        }

        /// <summary>
        /// Walks through the code units beneath this code unit.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="callback">Callback executed when a code unit is visited.</param>
        /// <param name="codeUnitTypes">The types of code units to visit.</param>
        public static void WalkCodeModel(this CodeUnit codeUnit, CodeUnitVisitor<object> callback, params CodeUnitType[] codeUnitTypes)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.RequireNotNull(callback, "callback");
            Param.Ignore(codeUnitTypes);

            CodeWalker<object>.Start(codeUnit, callback, null, codeUnitTypes);
        }

        /// <summary>
        /// Walks through the code units beneath this code unit.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="callback">Callback executed when a code unit is visited.</param>
        public static void WalkCodeModel(this CodeUnit codeUnit, CodeUnitVisitor<object> callback)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.RequireNotNull(callback, "callback");

            CodeWalker<object>.Start(codeUnit, callback, null, null);
        }

        #region Private Static Methods

        /// <summary>
        /// Checks the given CodeUnit to see if it is of the expected type and passes the filter.
        /// </summary>
        /// <typeparam name="T">The type of the item to match against.</typeparam>
        /// <param name="item">The item to check.</param>
        /// <returns>Returns true if the item matches; false otherwise.</returns>
        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Justification = "The method does not require a parameter of type T.")]
        private static T Compare<T>(CodeUnit item) where T : CodeUnit
        {
            Param.Ignore(item);

            T typedItem = item as T;
            if (typedItem != null)
            {
                return typedItem;
            }

            return null;
        }

        /// <summary>
        /// Determines whether the item is of the given type.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of CodeUnit to search for.</param>
        /// <param name="mask">The mask to apply to the type.</param>
        /// <returns>Returns true if the item is of the given type; false otherwise.</returns>
        private static bool Is(this CodeUnit codeUnit, int type, FundamentalTypeMasks mask)
        {
            Param.AssertNotNull(codeUnit, "codeUnit");
            Param.Ignore(type, mask);

            return (codeUnit.FundamentalType & (int)mask) == type;
        }

        #endregion Private Statics Methods

        #region Private Classes

        /// <summary>
        /// Gets an enumerator for iterating through the descendents of a CodeUnit.
        /// </summary>
        /// <typeparam name="T">The type of CodeUnits the enumerator should return.</typeparam>
        [SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix", Justification = "The class is not a collection.")]
        private class CodeUnitDescendentEnumerable<T> : IEnumerable<T> where T : CodeUnit
        {
            /// <summary>
            /// The CodeUnit to iterate through.
            /// </summary>
            private CodeUnit codeUnit;

            /// <summary>
            /// Initializes a new instance of the CodeUnitDescendentEnumerable class.
            /// </summary>
            /// <param name="codeUnit">The CodeUnit to iterate through.</param>
            public CodeUnitDescendentEnumerable(CodeUnit codeUnit)
            {
                Param.AssertNotNull(codeUnit, "codeUnit");
                this.codeUnit = codeUnit;
            }

            /// <summary>
            /// Gets an enumerator for iterating through the descendents of the CodeUnit.
            /// </summary>
            /// <returns>Returns the enumerator.</returns>
            public IEnumerator<T> GetEnumerator()
            {
                return new CodeUnitDescendentEnumerator<T>(this.codeUnit);
            }

            /// <summary>
            /// Gets an enumerator for iterating through the descendents of the CodeUnit.
            /// </summary>
            /// <returns>Returns the enumerator.</returns>
            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }
        }

        /// <summary>
        /// Enumerates through the descendents of a CodeUnit.
        /// </summary>
        /// <typeparam name="T">The type of the CodeUnits to return.</typeparam>
        private class CodeUnitDescendentEnumerator<T> : IEnumerator<T> where T : CodeUnit
        {
            /// <summary>
            /// The code unit to iterate through.
            /// </summary>
            private CodeUnit codeUnit;

            /// <summary>
            /// The current item.
            /// </summary>
            private T currentItem;

            /// <summary>
            /// Initializes a new instance of the CodeUnitDescendentEnumerator class.
            /// </summary>
            /// <param name="codeUnit">The code unit to iterate through.</param>
            public CodeUnitDescendentEnumerator(CodeUnit codeUnit)
            {
                Param.AssertNotNull(codeUnit, "codeUnit");
                this.codeUnit = codeUnit;
            }

            /// <summary>
            /// Gets the current item.
            /// </summary>
            public T Current
            {
                get
                {
                    return this.currentItem;
                }
            }

            /// <summary>
            /// Gets the current item.
            /// </summary>
            object System.Collections.IEnumerator.Current
            {
                get
                {
                    return this.currentItem;
                }
            }

            /// <summary>
            /// Moves to the next item in the collection.
            /// </summary>
            /// <returns>Returns true if the index was moved; false if there are no more items in the collection.</returns>
            public bool MoveNext()
            {
                if (this.currentItem == null)
                {
                    this.currentItem = this.codeUnit.FindFirstDescendent<T>();
                }
                else
                {
                    this.currentItem = this.currentItem.FindNextDescendentOf<T>(this.codeUnit);
                }

                return this.currentItem != null;
            }

            /// <summary>
            /// Resets the enumerator.
            /// </summary>
            public void Reset()
            {
                this.currentItem = null;
            }

            /// <summary>
            /// Disposes the contents of the class.
            /// </summary>
            public void Dispose()
            {
                GC.SuppressFinalize(this);
            }
        }

        /// <summary>
        /// Gets an enumerator for iterating through the direct children of a CodeUnit.
        /// </summary>
        /// <typeparam name="T">The type of CodeUnits the enumerator should return.</typeparam>
        [SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix", Justification = "The class is not a collection.")]
        private class CodeUnitChildrenEnumerable<T> : IEnumerable<T> where T : CodeUnit
        {
            /// <summary>
            /// The CodeUnit to iterate through.
            /// </summary>
            private CodeUnit codeUnit;

            /// <summary>
            /// Initializes a new instance of the CodeUnitChildrenEnumerable class.
            /// </summary>
            /// <param name="codeUnit">The CodeUnit to iterate through.</param>
            public CodeUnitChildrenEnumerable(CodeUnit codeUnit)
            {
                Param.AssertNotNull(codeUnit, "codeUnit");
                this.codeUnit = codeUnit;
            }

            /// <summary>
            /// Gets an enumerator for iterating through the direct children of the CodeUnit.
            /// </summary>
            /// <returns>Returns the enumerator.</returns>
            public IEnumerator<T> GetEnumerator()
            {
                return new CodeUnitChildrenEnumerator<T>(this.codeUnit);
            }

            /// <summary>
            /// Gets an enumerator for iterating through the direct children of the CodeUnit.
            /// </summary>
            /// <returns>Returns the enumerator.</returns>
            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }
        }

        /// <summary>
        /// Enumerates through the direct children of a CodeUnit.
        /// </summary>
        /// <typeparam name="T">The type of the CodeUnits to return.</typeparam>
        private class CodeUnitChildrenEnumerator<T> : IEnumerator<T> where T : CodeUnit
        {
            /// <summary>
            /// The code unit to iterate through.
            /// </summary>
            private CodeUnit codeUnit;

            /// <summary>
            /// The current item.
            /// </summary>
            private T currentItem;

            /// <summary>
            /// Initializes a new instance of the CodeUnitChildrenEnumerator class.
            /// </summary>
            /// <param name="codeUnit">The code unit to iterate through.</param>
            public CodeUnitChildrenEnumerator(CodeUnit codeUnit)
            {
                Param.AssertNotNull(codeUnit, "codeUnit");
                this.codeUnit = codeUnit;
            }

            /// <summary>
            /// Gets the current item.
            /// </summary>
            public T Current
            {
                get
                {
                    return this.currentItem;
                }
            }

            /// <summary>
            /// Gets the current item.
            /// </summary>
            object System.Collections.IEnumerator.Current
            {
                get
                {
                    return this.currentItem;
                }
            }

            /// <summary>
            /// Moves to the next item in the collection.
            /// </summary>
            /// <returns>Returns true if the index was moved; false if there are no more items in the collection.</returns>
            public bool MoveNext()
            {
                if (this.currentItem == null)
                {
                    this.currentItem = this.codeUnit.FindFirstChild<T>();
                }
                else
                {
                    this.currentItem = this.currentItem.FindNextSibling<T>();
                }

                return this.currentItem != null;
            }

            /// <summary>
            /// Resets the enumerator.
            /// </summary>
            public void Reset()
            {
                this.currentItem = null;
            }

            /// <summary>
            /// Disposes the contents of the class.
            /// </summary>
            public void Dispose()
            {
                GC.SuppressFinalize(this);
            }
        }

        #endregion Private Classes
    }
}