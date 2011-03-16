//-----------------------------------------------------------------------
// <copyright file="CodeUnitExtensions.cs">
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
namespace StyleCop.CSharp.CodeModel
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using StyleCop.CSharp.CodeModel.Collections;

    /// <summary>
    /// Extension methods for the CodeUnit class.
    /// </summary>
    public static class CodeUnitExtensions
    {
        #region MatchDelegate

        /// <summary>
        /// Matches a code unit.
        /// </summary>
        /// <param name="item">The code unit to match.</param>
        /// <returns>Returns true on a match; false otherwise.</returns>
        private delegate bool MatchDelegate(CodeUnit item);

        #endregion MatchDelegate

        #region MatchTokens

        /// <summary>
        /// Determines whether the given start token lies at the start of a string of tokens matching the given array of strings.
        /// comments.
        /// </summary>
        /// <param name="codeUnit">The code unit that contains the tokens.</param>
        /// <param name="values">The collection of strings to match against.</param>
        /// <returns>Returns true if the tokens match the collection of strings.</returns>
        /// <remarks>Only considers tokens at the same level in the hierarchy as the start token.</remarks>
        public static bool MatchTokens(this CodeUnit codeUnit, params string[] values)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.RequireNotNull(values, "values");

            Token start = codeUnit.FindFirstToken();
            if (start == null)
            {
                return false;
            }

            return codeUnit.MatchTokensFrom(start, values);
        }

        /// <summary>
        /// Determines whether the given start token lies at the start of a string of tokens matching the given array of strings.
        /// comments.
        /// </summary>
        /// <param name="codeUnit">The code unit that contains the tokens.</param>
        /// <param name="start">Begins matching the given strings with this token.</param>
        /// <param name="values">The collection of strings to match against.</param>
        /// <returns>Returns true if the tokens match the collection of strings.</returns>
        /// <remarks>Only considers tokens at the same level in the hierarchy as the start token.</remarks>
        public static bool MatchTokensFrom(this CodeUnit codeUnit, Token start, params string[] values)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.RequireNotNull(start, "start");
            Param.RequireNotNull(values, "values");

            int index = 0;

            for (Token token = start; token != null && index < values.Length; token = token.FindNextToken(codeUnit))
            {
                if (token.Children.Count == 0)
                {
                    if (!token.Text.Equals(values[index], StringComparison.Ordinal))
                    {
                        return false;
                    }

                    ++index;
                }
            }

            return index >= values.Length;
        }

        #endregion MatchTokens

        #region FindChildItems

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

        #endregion FindChildItems

        #region FindParent

        /// <summary>
        /// Given a parent code unit, traverses through the parent hierarchy to find a parent of the given type, if there is one.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <typeparam name="T">The type of the parent to return.</typeparam>
        /// <returns>Returns the parent or null if there is none.</returns>
        public static T FindParent<T>(this CodeUnit codeUnit) where T : CodeUnit
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            return (T)FindParent(codeUnit, c => c is T);
        }

        /// <summary>
        /// Given a parent code unit, traverses through the parent hierarchy to find a parent of the given type, if there is one.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of item to return.</param>
        /// <returns>Returns the parent or null if there is none.</returns>
        public static CodeUnit FindParent(this CodeUnit codeUnit, CodeUnitType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindParent(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Given a parent code unit, traverses through the parent hierarchy to find a parent of the given type, if there is one.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of item to return.</param>
        /// <returns>Returns the parent or null if there is none.</returns>
        public static CodeUnit FindParent(this CodeUnit codeUnit, LexicalElementType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindParent(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Given a parent code unit, traverses through the parent hierarchy to find a parent of the given type, if there is one.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of item to return.</param>
        /// <returns>Returns the parent or null if there is none.</returns>
        public static CodeUnit FindParent(this CodeUnit codeUnit, TokenType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindParent(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Given a parent code unit, traverses through the parent hierarchy to find a parent of the given type, if there is one.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of item to return.</param>
        /// <returns>Returns the parent or null if there is none.</returns>
        public static CodeUnit FindParent(this CodeUnit codeUnit, OperatorType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindParent(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Given a parent code unit, traverses through the parent hierarchy to find a parent of the given type, if there is one.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of item to return.</param>
        /// <returns>Returns the parent or null if there is none.</returns>
        public static CodeUnit FindParent(this CodeUnit codeUnit, CommentType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindParent(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Given a parent code unit, traverses through the parent hierarchy to find a parent of the given type, if there is one.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of item to return.</param>
        /// <returns>Returns the parent or null if there is none.</returns>
        public static CodeUnit FindParent(this CodeUnit codeUnit, PreprocessorType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindParent(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Given a parent code unit, traverses through the parent hierarchy to find a parent of the given type, if there is one.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of item to return.</param>
        /// <returns>Returns the parent or null if there is none.</returns>
        public static CodeUnit FindParent(this CodeUnit codeUnit, QueryClauseType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindParent(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Given a parent code unit, traverses through the parent hierarchy to find a parent of the given type, if there is one.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of item to return.</param>
        /// <returns>Returns the parent or null if there is none.</returns>
        public static CodeUnit FindParent(this CodeUnit codeUnit, ExpressionType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindParent(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Given a parent code unit, traverses through the parent hierarchy to find a parent of the given type, if there is one.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of item to return.</param>
        /// <returns>Returns the parent or null if there is none.</returns>
        public static CodeUnit FindParent(this CodeUnit codeUnit, StatementType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindParent(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Given a parent code unit, traverses through the parent hierarchy to find a parent of the given type, if there is one.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of item to return.</param>
        /// <returns>Returns the parent or null if there is none.</returns>
        public static CodeUnit FindParent(this CodeUnit codeUnit, ElementType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindParent(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Given a parent code unit, traverses through the parent hierarchy to find a parent, if there is one.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <returns>Returns the parent or null if there is none.</returns>
        public static CodeUnit FindParent(this CodeUnit codeUnit)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            return codeUnit.Parent;
        }

        /// <summary>
        /// Given a parent code unit, traverses through the parent hierarchy to find a parent, if there is one.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <returns>Returns the parent or null if there is none.</returns>
        public static LexicalElement FindParentLexicalElement(this CodeUnit codeUnit)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            return (LexicalElement)FindParent(codeUnit, c => c.Is(CodeUnitType.LexicalElement));
        }

        /// <summary>
        /// Given a parent code unit, traverses through the parent hierarchy to find a parent, if there is one.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <returns>Returns the parent or null if there is none.</returns>
        public static Token FindParentToken(this CodeUnit codeUnit)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            return (Token)FindParent(codeUnit, c => c.Is(LexicalElementType.Token));
        }

        /// <summary>
        /// Given a parent code unit, traverses through the parent hierarchy to find a parent, if there is one.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <returns>Returns the parent or null if there is none.</returns>
        public static QueryClause FindParentQueryClause(this CodeUnit codeUnit)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            return (QueryClause)FindParent(codeUnit, c => c.Is(CodeUnitType.QueryClause));
        }

        /// <summary>
        /// Given a parent code unit, traverses through the parent hierarchy to find a parent, if there is one.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <returns>Returns the parent or null if there is none.</returns>
        public static Expression FindParentExpression(this CodeUnit codeUnit)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            return (Expression)FindParent(codeUnit, c => c.Is(CodeUnitType.Expression));
        }

        /// <summary>
        /// Given a parent code unit, traverses through the parent hierarchy to find a parent, if there is one.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <returns>Returns the parent or null if there is none.</returns>
        public static Statement FindParentStatement(this CodeUnit codeUnit)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            return (Statement)FindParent(codeUnit, c => c.Is(CodeUnitType.Statement));
        }

        /// <summary>
        /// Given a parent code unit, traverses through the parent hierarchy to find a parent, if there is one.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <returns>Returns the parent or null if there is none.</returns>
        public static Element FindParentElement(this CodeUnit codeUnit)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            return (Element)FindParent(codeUnit, c => c.Is(CodeUnitType.Element));
        }

        #endregion FindParent

        #region FindNext

        /// <summary>
        /// Gets the next item of the given type at any level in the hierarchy.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <typeparam name="T">The type of the item to return.</typeparam>
        /// <returns>Returns the next item or null if there are no items of the requested type.</returns>
        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Justification = "The method does not require a parameter of type T.")]
        public static T FindNext<T>(this CodeUnit codeUnit) where T : CodeUnit
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            return (T)FindNext(codeUnit, c => c is T);
        }

        /// <summary>
        /// Gets the next item of the given type which is a descendent of the given root or is the root itself.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="root">The root item.</param>
        /// <typeparam name="T">The type of the item to return.</typeparam>
        /// <returns>Returns the next item or null if there are no items of the requested type.</returns>
        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Justification = "The method does not require a parameter of type T.")]
        public static T FindNext<T>(this CodeUnit codeUnit, CodeUnit root) where T : CodeUnit
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(root);

            return (T)FindNext(codeUnit, c => c is T, root);
        }

        /// <summary>
        /// Gets the next item of the given type at any level in the hierarchy.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the next item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindNext(this CodeUnit codeUnit, CodeUnitType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindNext(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the next item of the given type which is a descendent of the given root or is the root itself.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <param name="root">The root item.</param>
        /// <returns>Returns the next item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindNext(this CodeUnit codeUnit, CodeUnitType type, CodeUnit root)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);
            Param.Ignore(root);

            return FindNext(codeUnit, c => c.Is(type), root);
        }

        /// <summary>
        /// Gets the next item of the given type at any level in the hierarchy.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the next item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindNext(this CodeUnit codeUnit, LexicalElementType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindNext(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the next item of the given type which is a descendent of the given root or is the root itself.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <param name="root">The root item.</param>
        /// <returns>Returns the next item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindNext(this CodeUnit codeUnit, LexicalElementType type, CodeUnit root)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);
            Param.Ignore(root);

            return FindNext(codeUnit, c => c.Is(type), root);
        }

        /// <summary>
        /// Gets the next item of the given type at any level in the hierarchy.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the next item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindNext(this CodeUnit codeUnit, TokenType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindNext(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the next item of the given type which is a descendent of the given root or is the root itself.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <param name="root">The root item.</param>
        /// <returns>Returns the next item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindNext(this CodeUnit codeUnit, TokenType type, CodeUnit root)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);
            Param.Ignore(root);

            return FindNext(codeUnit, c => c.Is(type), root);
        }

        /// <summary>
        /// Gets the next item of the given type at any level in the hierarchy.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the next item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindNext(this CodeUnit codeUnit, OperatorType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindNext(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the next item of the given type which is a descendent of the given root or is the root itself.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <param name="root">The root item.</param>
        /// <returns>Returns the next item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindNext(this CodeUnit codeUnit, OperatorType type, CodeUnit root)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(root);
            Param.Ignore(type);

            return FindNext(codeUnit, c => c.Is(type), root);
        }

        /// <summary>
        /// Gets the next item of the given type at any level in the hierarchy.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the next item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindNext(this CodeUnit codeUnit, CommentType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindNext(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the next item of the given type which is a descendent of the given root or is the root itself.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <param name="root">The root item.</param>
        /// <returns>Returns the next item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindNext(this CodeUnit codeUnit, CommentType type, CodeUnit root)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);
            Param.Ignore(root);

            return FindNext(codeUnit, c => c.Is(type), root);
        }

        /// <summary>
        /// Gets the next item of the given type at any level in the hierarchy.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the next item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindNext(this CodeUnit codeUnit, PreprocessorType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindNext(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the next item of the given type which is a descendent of the given root or is the root itself.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <param name="root">The root item.</param>
        /// <returns>Returns the next item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindNext(this CodeUnit codeUnit, PreprocessorType type, CodeUnit root)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);
            Param.Ignore(root);

            return FindNext(codeUnit, c => c.Is(type), root);
        }

        /// <summary>
        /// Gets the next item of the given type at any level in the hierarchy.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the next item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindNext(this CodeUnit codeUnit, QueryClauseType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindNext(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the next item of the given type which is a descendent of the given root or is the root itself.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <param name="root">The root item.</param>
        /// <returns>Returns the next item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindNext(this CodeUnit codeUnit, QueryClauseType type, CodeUnit root)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);
            Param.Ignore(root);

            return FindNext(codeUnit, c => c.Is(type), root);
        }

        /// <summary>
        /// Gets the next item of the given type at any level in the hierarchy.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the next item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindNext(this CodeUnit codeUnit, ExpressionType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindNext(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the next item of the given type which is a descendent of the given root or is the root itself.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <param name="root">The root item.</param>
        /// <returns>Returns the next item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindNext(this CodeUnit codeUnit, ExpressionType type, CodeUnit root)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);
            Param.Ignore(root);

            return FindNext(codeUnit, c => c.Is(type), root);
        }

        /// <summary>
        /// Gets the next item of the given type at any level in the hierarchy.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the next item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindNext(this CodeUnit codeUnit, ArithmeticExpressionType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindNext(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the next item of the given type which is a descendent of the given root or is the root itself.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <param name="root">The root item.</param>
        /// <returns>Returns the next item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindNext(this CodeUnit codeUnit, ArithmeticExpressionType type, CodeUnit root)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);
            Param.Ignore(root);

            return FindNext(codeUnit, c => c.Is(type), root);
        }

        /// <summary>
        /// Gets the next item of the given type at any level in the hierarchy.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the next item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindNext(this CodeUnit codeUnit, AssignmentExpressionType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindNext(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the next item of the given type which is a descendent of the given root or is the root itself.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <param name="root">The root item.</param>
        /// <returns>Returns the next item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindNext(this CodeUnit codeUnit, AssignmentExpressionType type, CodeUnit root)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);
            Param.Ignore(root);

            return FindNext(codeUnit, c => c.Is(type), root);
        }

        /// <summary>
        /// Gets the next item of the given type at any level in the hierarchy.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the next item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindNext(this CodeUnit codeUnit, ConditionalLogicalExpressionType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindNext(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the next item of the given type which is a descendent of the given root or is the root itself.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <param name="root">The root item.</param>
        /// <returns>Returns the next item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindNext(this CodeUnit codeUnit, ConditionalLogicalExpressionType type, CodeUnit root)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);
            Param.Ignore(root);

            return FindNext(codeUnit, c => c.Is(type), root);
        }

        /// <summary>
        /// Gets the next item of the given type at any level in the hierarchy.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the next item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindNext(this CodeUnit codeUnit, LogicalExpressionType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindNext(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the next item of the given type which is a descendent of the given root or is the root itself.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <param name="root">The root item.</param>
        /// <returns>Returns the next item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindNext(this CodeUnit codeUnit, LogicalExpressionType type, CodeUnit root)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);
            Param.Ignore(root);

            return FindNext(codeUnit, c => c.Is(type), root);
        }

        /// <summary>
        /// Gets the next item of the given type at any level in the hierarchy.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the next item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindNext(this CodeUnit codeUnit, RelationalExpressionType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindNext(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the next item of the given type which is a descendent of the given root or is the root itself.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <param name="root">The root item.</param>
        /// <returns>Returns the next item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindNext(this CodeUnit codeUnit, RelationalExpressionType type, CodeUnit root)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);
            Param.Ignore(root);

            return FindNext(codeUnit, c => c.Is(type), root);
        }

        /// <summary>
        /// Gets the next item of the given type at any level in the hierarchy.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the next item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindNext(this CodeUnit codeUnit, UnaryExpressionType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindNext(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the next item of the given type which is a descendent of the given root or is the root itself.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <param name="root">The root item.</param>
        /// <returns>Returns the next item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindNext(this CodeUnit codeUnit, UnaryExpressionType type, CodeUnit root)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);
            Param.Ignore(root);

            return FindNext(codeUnit, c => c.Is(type), root);
        }

        /// <summary>
        /// Gets the next item of the given type at any level in the hierarchy.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the next item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindNext(this CodeUnit codeUnit, UnsafeAccessExpressionType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindNext(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the next item of the given type which is a descendent of the given root or is the root itself.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <param name="root">The root item.</param>
        /// <returns>Returns the next item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindNext(this CodeUnit codeUnit, UnsafeAccessExpressionType type, CodeUnit root)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);
            Param.Ignore(root);

            return FindNext(codeUnit, c => c.Is(type), root);
        }

        /// <summary>
        /// Gets the next item of the given type at any level in the hierarchy.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the next item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindNext(this CodeUnit codeUnit, StatementType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindNext(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the next item of the given type which is a descendent of the given root or is the root itself.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <param name="root">The root item.</param>
        /// <returns>Returns the next item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindNext(this CodeUnit codeUnit, StatementType type, CodeUnit root)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);
            Param.Ignore(root);

            return FindNext(codeUnit, c => c.Is(type), root);
        }

        /// <summary>
        /// Gets the next item of the given type at any level in the hierarchy.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the next item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindNext(this CodeUnit codeUnit, ElementType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindNext(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the next item of the given type which is a descendent of the given root or is the root itself.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <param name="root">The root item.</param>
        /// <returns>Returns the next item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindNext(this CodeUnit codeUnit, ElementType type, CodeUnit root)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);
            Param.Ignore(root);

            return FindNext(codeUnit, c => c.Is(type), root);
        }

        /// <summary>
        /// Gets the next item at any level in the hierarchy.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <returns>Returns the next item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindNext(this CodeUnit codeUnit)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            return FindNext(codeUnit, c => true);
        }

        /// <summary>
        /// Gets the next item of the given type which is a descendent of the given root or is the root itself.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="root">The root item.</param>
        /// <returns>Returns the next item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindNext(this CodeUnit codeUnit, CodeUnit root)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(root);

            return FindNext(codeUnit, c => true, root);
        }

        /// <summary>
        /// Gets the next item at any level in the hierarchy.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <returns>Returns the next item or null if there are no items of the requested type.</returns>
        public static LexicalElement FindNextLexicalElement(this CodeUnit codeUnit)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            return (LexicalElement)FindNext(codeUnit, c => c.Is(CodeUnitType.LexicalElement));
        }

        /// <summary>
        /// Gets the next item of the given type which is a descendent of the given root or is the root itself.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="root">The root item.</param>
        /// <returns>Returns the next item or null if there are no items of the requested type.</returns>
        public static LexicalElement FindNextLexicalElement(this CodeUnit codeUnit, CodeUnit root)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(root);

            return (LexicalElement)FindNext(codeUnit, c => c.Is(CodeUnitType.LexicalElement), root);
        }

        /// <summary>
        /// Gets the next item at any level in the hierarchy.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <returns>Returns the next item or null if there are no items of the requested type.</returns>
        public static Token FindNextToken(this CodeUnit codeUnit)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            return (Token)FindNext(codeUnit, c => c.Is(LexicalElementType.Token));
        }

        /// <summary>
        /// Gets the next item of the given type which is a descendent of the given root or is the root itself.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="root">The root item.</param>
        /// <returns>Returns the next item or null if there are no items of the requested type.</returns>
        public static Token FindNextToken(this CodeUnit codeUnit, CodeUnit root)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(root);

            return (Token)FindNext(codeUnit, c => c.Is(LexicalElementType.Token), root);
        }

        /// <summary>
        /// Gets the next item at any level in the hierarchy.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <returns>Returns the next item or null if there are no items of the requested type.</returns>
        public static QueryClause FindNextQueryClause(this CodeUnit codeUnit)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            return (QueryClause)FindNext(codeUnit, c => c.Is(CodeUnitType.QueryClause));
        }

        /// <summary>
        /// Gets the next item of the given type which is a descendent of the given root or is the root itself.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="root">The root item.</param>
        /// <returns>Returns the next item or null if there are no items of the requested type.</returns>
        public static QueryClause FindNextQueryClause(this CodeUnit codeUnit, CodeUnit root)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(root);

            return (QueryClause)FindNext(codeUnit, c => c.Is(CodeUnitType.QueryClause), root);
        }

        /// <summary>
        /// Gets the next item at any level in the hierarchy.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <returns>Returns the next item or null if there are no items of the requested type.</returns>
        public static Expression FindNextExpression(this CodeUnit codeUnit)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            return (Expression)FindNext(codeUnit, c => c.Is(CodeUnitType.Expression));
        }

        /// <summary>
        /// Gets the next item of the given type which is a descendent of the given root or is the root itself.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="root">The root item.</param>
        /// <returns>Returns the next item or null if there are no items of the requested type.</returns>
        public static Expression FindNextExpression(this CodeUnit codeUnit, CodeUnit root)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(root);

            return (Expression)FindNext(codeUnit, c => c.Is(CodeUnitType.Expression), root);
        }

        /// <summary>
        /// Gets the next item at any level in the hierarchy.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <returns>Returns the next item or null if there are no items of the requested type.</returns>
        public static Statement FindNextStatement(this CodeUnit codeUnit)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            return (Statement)FindNext(codeUnit, c => c.Is(CodeUnitType.Statement));
        }

        /// <summary>
        /// Gets the next item of the given type which is a descendent of the given root or is the root itself.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="root">The root item.</param>
        /// <returns>Returns the next item or null if there are no items of the requested type.</returns>
        public static Statement FindNextStatement(this CodeUnit codeUnit, CodeUnit root)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(root);

            return (Statement)FindNext(codeUnit, c => c.Is(CodeUnitType.Statement), root);
        }

        /// <summary>
        /// Gets the next item at any level in the hierarchy.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <returns>Returns the next item or null if there are no items of the requested type.</returns>
        public static Element FindNextElement(this CodeUnit codeUnit)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            return (Element)FindNext(codeUnit, c => c.Is(CodeUnitType.Element));
        }

        /// <summary>
        /// Gets the next item of the given type which is a descendent of the given root or is the root itself.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="root">The root item.</param>
        /// <returns>Returns the next item or null if there are no items of the requested type.</returns>
        public static Element FindNextElement(this CodeUnit codeUnit, CodeUnit root)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(root);

            return (Element)FindNext(codeUnit, c => c.Is(CodeUnitType.Element), root);
        }

        #endregion FindNext

        #region FindNextDescendentOf

        /// <summary>
        /// Gets the next item of the given type which is a descendent of the given root.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="root">The root ancenstor of the next item.</param>
        /// <typeparam name="T">The type of the item to return.</typeparam>
        /// <returns>Returns the next item or null if there are no items of the requested type.</returns>
        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Justification = "The method does not require a parameter of type T.")]
        public static T FindNextDescendentOf<T>(this CodeUnit codeUnit, CodeUnit root) where T : CodeUnit
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(root);

            return (T)FindNextDescendentOf(codeUnit, c => c is T, root);
        }

        /// <summary>
        /// Gets the next item of the given type which is a descendent of the given root.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <param name="root">The root ancenstor of the next item.</param>
        /// <returns>Returns the next item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindNextDescendentOf(this CodeUnit codeUnit, CodeUnitType type, CodeUnit root)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);
            Param.Ignore(root);

            return FindNextDescendentOf(codeUnit, c => c.Is(type), root);
        }

        /// <summary>
        /// Gets the next item of the given type which is a descendent of the given root.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <param name="root">The root ancenstor of the next item.</param>
        /// <returns>Returns the next item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindNextDescendentOf(this CodeUnit codeUnit, LexicalElementType type, CodeUnit root)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);
            Param.Ignore(root);

            return FindNextDescendentOf(codeUnit, c => c.Is(type), root);
        }

        /// <summary>
        /// Gets the next item of the given type which is a descendent of the given root.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <param name="root">The root ancenstor of the next item.</param>
        /// <returns>Returns the next item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindNextDescendentOf(this CodeUnit codeUnit, TokenType type, CodeUnit root)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);
            Param.Ignore(root);

            return FindNextDescendentOf(codeUnit, c => c.Is(type), root);
        }

        /// <summary>
        /// Gets the next item of the given type which is a descendent of the given root.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <param name="root">The root ancenstor of the next item.</param>
        /// <returns>Returns the next item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindNextDescendentOf(this CodeUnit codeUnit, OperatorType type, CodeUnit root)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);
            Param.Ignore(root);

            return FindNextDescendentOf(codeUnit, c => c.Is(type), root);
        }

        /// <summary>
        /// Gets the next item of the given type which is a descendent of the given root.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <param name="root">The root ancenstor of the next item.</param>
        /// <returns>Returns the next item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindNextDescendentOf(this CodeUnit codeUnit, CommentType type, CodeUnit root)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);
            Param.Ignore(root);

            return FindNextDescendentOf(codeUnit, c => c.Is(type), root);
        }

        /// <summary>
        /// Gets the next item of the given type which is a descendent of the given root.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <param name="root">The root ancenstor of the next item.</param>
        /// <returns>Returns the next item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindNextDescendentOf(this CodeUnit codeUnit, PreprocessorType type, CodeUnit root)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);
            Param.Ignore(root);

            return FindNextDescendentOf(codeUnit, c => c.Is(type), root);
        }

        /// <summary>
        /// Gets the next item of the given type which is a descendent of the given root.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <param name="root">The root ancenstor of the next item.</param>
        /// <returns>Returns the next item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindNextDescendentOf(this CodeUnit codeUnit, QueryClauseType type, CodeUnit root)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);
            Param.Ignore(root);

            return FindNextDescendentOf(codeUnit, c => c.Is(type), root);
        }

        /// <summary>
        /// Gets the next item of the given type which is a descendent of the given root.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <param name="root">The root ancenstor of the next item.</param>
        /// <returns>Returns the next item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindNextDescendentOf(this CodeUnit codeUnit, ExpressionType type, CodeUnit root)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);
            Param.Ignore(root);

            return FindNextDescendentOf(codeUnit, c => c.Is(type), root);
        }

        /// <summary>
        /// Gets the next item of the given type which is a descendent of the given root.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <param name="root">The root ancenstor of the next item.</param>
        /// <returns>Returns the next item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindNextDescendentOf(this CodeUnit codeUnit, StatementType type, CodeUnit root)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);
            Param.Ignore(root);

            return FindNextDescendentOf(codeUnit, c => c.Is(type), root);
        }

        /// <summary>
        /// Gets the next item of the given type which is a descendent of the given root.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <param name="root">The root ancenstor of the next item.</param>
        /// <returns>Returns the next item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindNextDescendentOf(this CodeUnit codeUnit, ElementType type, CodeUnit root)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);
            Param.Ignore(root);

            return FindNextDescendentOf(codeUnit, c => c.Is(type), root);
        }

        /// <summary>
        /// Gets the next item of the given type which is a descendent of the given root.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="root">The root ancenstor of the next item.</param>
        /// <returns>Returns the next item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindNextDescendentOf(this CodeUnit codeUnit, CodeUnit root)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(root);

            return FindNextDescendentOf(codeUnit, c => true, root);
        }

        /// <summary>
        /// Gets the next item of the given type which is a descendent of the given root.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="root">The root ancenstor of the next item.</param>
        /// <returns>Returns the next item or null if there are no items of the requested type.</returns>
        public static LexicalElement FindNextDescendentLexicalElementOf(this CodeUnit codeUnit, CodeUnit root)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(root);

            return (LexicalElement)FindNextDescendentOf(codeUnit, c => c.Is(CodeUnitType.LexicalElement), root);
        }

        /// <summary>
        /// Gets the next item of the given type which is a descendent of the given root.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="root">The root ancenstor of the next item.</param>
        /// <returns>Returns the next item or null if there are no items of the requested type.</returns>
        public static Token FindNextDescendentTokenOf(this CodeUnit codeUnit, CodeUnit root)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(root);

            return (Token)FindNextDescendentOf(codeUnit, c => c.Is(LexicalElementType.Token), root);
        }

        /// <summary>
        /// Gets the next item of the given type which is a descendent of the given root.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="root">The root ancenstor of the next item.</param>
        /// <returns>Returns the next item or null if there are no items of the requested type.</returns>
        public static QueryClause FindNextDescendentQueryClauseOf(this CodeUnit codeUnit, CodeUnit root)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(root);

            return (QueryClause)FindNextDescendentOf(codeUnit, c => c.Is(CodeUnitType.QueryClause), root);
        }

        /// <summary>
        /// Gets the next item of the given type which is a descendent of the given root.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="root">The root ancenstor of the next item.</param>
        /// <returns>Returns the next item or null if there are no items of the requested type.</returns>
        public static Expression FindNextDescendentExpressionOf(this CodeUnit codeUnit, CodeUnit root)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(root);

            return (Expression)FindNextDescendentOf(codeUnit, c => c.Is(CodeUnitType.Expression), root);
        }

        /// <summary>
        /// Gets the next item of the given type which is a descendent of the given root.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="root">The root ancenstor of the next item.</param>
        /// <returns>Returns the next item or null if there are no items of the requested type.</returns>
        public static Statement FindNextDescendentStatementOf(this CodeUnit codeUnit, CodeUnit root)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(root);

            return (Statement)FindNextDescendentOf(codeUnit, c => c.Is(CodeUnitType.Statement), root);
        }

        /// <summary>
        /// Gets the next item of the given type which is a descendent of the given root.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="root">The root ancenstor of the next item.</param>
        /// <returns>Returns the next item or null if there are no items of the requested type.</returns>
        public static Element FindNextDescendentElementOf(this CodeUnit codeUnit, CodeUnit root)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(root);

            return (Element)FindNextDescendentOf(codeUnit, c => c.Is(CodeUnitType.Element), root);
        }
        
        #endregion FindNextDescendentOf

        #region FindNextSibling

        /// <summary>
        /// Gets the next item of the given type which is a direct child of the given parent.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <typeparam name="T">The type of the item to return.</typeparam>
        /// <returns>Returns the next item or null if there are no items of the requested type.</returns>
        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Justification = "The method does not require a parameter of type T.")]
        public static T FindNextSibling<T>(this CodeUnit codeUnit) where T : CodeUnit
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            return (T)FindNextSibling(codeUnit, c => c is T);
        }

        /// <summary>
        /// Gets the next item of the given type which is a direct child of the given parent.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the next item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindNextSibling(this CodeUnit codeUnit, CodeUnitType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindNextSibling(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the next item of the given type which is a direct child of the given parent.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the next item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindNextSibling(this CodeUnit codeUnit, LexicalElementType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindNextSibling(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the next item of the given type which is a direct child of the given parent.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the next item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindNextSibling(this CodeUnit codeUnit, TokenType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindNextSibling(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the next item of the given type which is a direct child of the given parent.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the next item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindNextSibling(this CodeUnit codeUnit, OperatorType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindNextSibling(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the next item of the given type which is a direct child of the given parent.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the next item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindNextSibling(this CodeUnit codeUnit, CommentType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindNextSibling(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the next item of the given type which is a direct child of the given parent.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the next item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindNextSibling(this CodeUnit codeUnit, PreprocessorType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindNextSibling(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the next item of the given type which is a direct child of the given parent.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the next item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindNextSibling(this CodeUnit codeUnit, QueryClauseType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindNextSibling(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the next item of the given type which is a direct child of the given parent.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the next item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindNextSibling(this CodeUnit codeUnit, ExpressionType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindNextSibling(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the next item of the given type which is a direct child of the given parent.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the next item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindNextSibling(this CodeUnit codeUnit, ArithmeticExpressionType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindNextSibling(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the next item of the given type which is a direct child of the given parent.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the next item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindNextSibling(this CodeUnit codeUnit, AssignmentExpressionType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindNextSibling(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the next item of the given type which is a direct child of the given parent.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the next item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindNextSibling(this CodeUnit codeUnit, ConditionalLogicalExpressionType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindNextSibling(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the next item of the given type which is a direct child of the given parent.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the next item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindNextSibling(this CodeUnit codeUnit, LogicalExpressionType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindNextSibling(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the next item of the given type which is a direct child of the given parent.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the next item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindNextSibling(this CodeUnit codeUnit, RelationalExpressionType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindNextSibling(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the next item of the given type which is a direct child of the given parent.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the next item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindNextSibling(this CodeUnit codeUnit, UnaryExpressionType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindNextSibling(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the next item of the given type which is a direct child of the given parent.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the next item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindNextSibling(this CodeUnit codeUnit, UnsafeAccessExpressionType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindNextSibling(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the next item of the given type which is a direct child of the given parent.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the next item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindNextSibling(this CodeUnit codeUnit, StatementType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindNextSibling(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the next item of the given type which is a direct child of the given parent.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the next item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindNextSibling(this CodeUnit codeUnit, ElementType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindNextSibling(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the next item of the given type which is a direct child of the given parent.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <returns>Returns the next item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindNextSibling(this CodeUnit codeUnit)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            return FindNextSibling(codeUnit, c => true);
        }

        /// <summary>
        /// Gets the next item of the given type which is a direct child of the given parent.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <returns>Returns the next item or null if there are no items of the requested type.</returns>
        public static LexicalElement FindNextSiblingLexicalElement(this CodeUnit codeUnit)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            return (LexicalElement)FindNextSibling(codeUnit, c => c.Is(CodeUnitType.LexicalElement));
        }

        /// <summary>
        /// Gets the next item of the given type which is a direct child of the given parent.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <returns>Returns the next item or null if there are no items of the requested type.</returns>
        public static Token FindNextSiblingToken(this CodeUnit codeUnit)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            return (Token)FindNextSibling(codeUnit, c => c.Is(LexicalElementType.Token));
        }

        /// <summary>
        /// Gets the next item of the given type which is a direct child of the given parent.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <returns>Returns the next item or null if there are no items of the requested type.</returns>
        public static QueryClause FindNextSiblingQueryClause(this CodeUnit codeUnit)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            return (QueryClause)FindNextSibling(codeUnit, c => c.Is(CodeUnitType.QueryClause));
        }

        /// <summary>
        /// Gets the next item of the given type which is a direct child of the given parent.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <returns>Returns the next item or null if there are no items of the requested type.</returns>
        public static Expression FindNextSiblingExpression(this CodeUnit codeUnit)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            return (Expression)FindNextSibling(codeUnit, c => c.Is(CodeUnitType.Expression));
        }

        /// <summary>
        /// Gets the next item of the given type which is a direct child of the given parent.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <returns>Returns the next item or null if there are no items of the requested type.</returns>
        public static Statement FindNextSiblingStatement(this CodeUnit codeUnit)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            return (Statement)FindNextSibling(codeUnit, c => c.Is(CodeUnitType.Statement));
        }

        /// <summary>
        /// Gets the next item of the given type which is a direct child of the given parent.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <returns>Returns the next item or null if there are no items of the requested type.</returns>
        public static Element FindNextSiblingElement(this CodeUnit codeUnit)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            return (Element)FindNextSibling(codeUnit, c => c.Is(CodeUnitType.Element));
        }
        
        #endregion FindNextSibling

        #region FindPrevious

        /// <summary>
        /// Gets the previous item of the given type at any level in the hierarchy.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <typeparam name="T">The type of the item to return.</typeparam>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Justification = "The method does not require a parameter of type T.")]
        public static T FindPrevious<T>(this CodeUnit codeUnit) where T : CodeUnit
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            return (T)FindPrevious(codeUnit, c => c is T);
        }

        /// <summary>
        /// Gets the previous item of the given type which is a descendent of the given root or is the root itself.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <typeparam name="T">The type of the item to return.</typeparam>
        /// <param name="root">The root item.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Justification = "The method does not require a parameter of type T.")]
        public static T FindPrevious<T>(this CodeUnit codeUnit, CodeUnit root) where T : CodeUnit
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(root);

            return (T)FindPrevious(codeUnit, c => c is T, root);
        }

        /// <summary>
        /// Gets the previous item of the given type at any level in the hierarchy.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindPrevious(this CodeUnit codeUnit, CodeUnitType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindPrevious(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the previous item of the given type which is a descendent of the given root or is the root itself.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <param name="root">The root item.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindPrevious(this CodeUnit codeUnit, CodeUnitType type, CodeUnit root)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);
            Param.Ignore(root);

            return FindPrevious(codeUnit, c => c.Is(type), root);
        }

        /// <summary>
        /// Gets the previous item of the given type at any level in the hierarchy.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindPrevious(this CodeUnit codeUnit, LexicalElementType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindPrevious(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the previous item of the given type which is a descendent of the given root or is the root itself.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <param name="root">The root item.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindPrevious(this CodeUnit codeUnit, LexicalElementType type, CodeUnit root)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);
            Param.Ignore(root);

            return FindPrevious(codeUnit, c => c.Is(type), root);
        }

        /// <summary>
        /// Gets the previous item of the given type at any level in the hierarchy.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindPrevious(this CodeUnit codeUnit, TokenType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindPrevious(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the previous item of the given type which is a descendent of the given root or is the root itself.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <param name="root">The root item.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindPrevious(this CodeUnit codeUnit, TokenType type, CodeUnit root)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);
            Param.Ignore(root);

            return FindPrevious(codeUnit, c => c.Is(type), root);
        }

        /// <summary>
        /// Gets the previous item of the given type at any level in the hierarchy.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindPrevious(this CodeUnit codeUnit, OperatorType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindPrevious(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the previous item of the given type which is a descendent of the given root or is the root itself.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <param name="root">The root item.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindPrevious(this CodeUnit codeUnit, OperatorType type, CodeUnit root)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);
            Param.Ignore(root);

            return FindPrevious(codeUnit, c => c.Is(type), root);
        }

        /// <summary>
        /// Gets the previous item of the given type at any level in the hierarchy.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindPrevious(this CodeUnit codeUnit, CommentType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindPrevious(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the previous item of the given type which is a descendent of the given root or is the root itself.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <param name="root">The root item.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindPrevious(this CodeUnit codeUnit, CommentType type, CodeUnit root)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);
            Param.Ignore(root);

            return FindPrevious(codeUnit, c => c.Is(type), root);
        }

        /// <summary>
        /// Gets the previous item of the given type at any level in the hierarchy.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindPrevious(this CodeUnit codeUnit, PreprocessorType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindPrevious(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the previous item of the given type which is a descendent of the given root or is the root itself.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <param name="root">The root item.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindPrevious(this CodeUnit codeUnit, PreprocessorType type, CodeUnit root)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);
            Param.Ignore(root);

            return FindPrevious(codeUnit, c => c.Is(type), root);
        }

        /// <summary>
        /// Gets the previous item of the given type at any level in the hierarchy.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindPrevious(this CodeUnit codeUnit, QueryClauseType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindPrevious(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the previous item of the given type which is a descendent of the given root or is the root itself.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <param name="root">The root item.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindPrevious(this CodeUnit codeUnit, QueryClauseType type, CodeUnit root)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);
            Param.Ignore(root);

            return FindPrevious(codeUnit, c => c.Is(type), root);
        }

        /// <summary>
        /// Gets the previous item of the given type at any level in the hierarchy.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindPrevious(this CodeUnit codeUnit, ExpressionType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindPrevious(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the previous item of the given type which is a descendent of the given root or is the root itself.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <param name="root">The root item.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindPrevious(this CodeUnit codeUnit, ExpressionType type, CodeUnit root)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);
            Param.Ignore(root);

            return FindPrevious(codeUnit, c => c.Is(type), root);
        }

        /// <summary>
        /// Gets the previous item of the given type at any level in the hierarchy.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindPrevious(this CodeUnit codeUnit, ArithmeticExpressionType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindPrevious(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the previous item of the given type which is a descendent of the given root or is the root itself.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <param name="root">The root item.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindPrevious(this CodeUnit codeUnit, ArithmeticExpressionType type, CodeUnit root)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);
            Param.Ignore(root);

            return FindPrevious(codeUnit, c => c.Is(type), root);
        }

        /// <summary>
        /// Gets the previous item of the given type at any level in the hierarchy.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindPrevious(this CodeUnit codeUnit, AssignmentExpressionType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindPrevious(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the previous item of the given type which is a descendent of the given root or is the root itself.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <param name="root">The root item.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindPrevious(this CodeUnit codeUnit, AssignmentExpressionType type, CodeUnit root)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);
            Param.Ignore(root);

            return FindPrevious(codeUnit, c => c.Is(type), root);
        }

        /// <summary>
        /// Gets the previous item of the given type at any level in the hierarchy.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindPrevious(this CodeUnit codeUnit, ConditionalLogicalExpressionType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindPrevious(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the previous item of the given type which is a descendent of the given root or is the root itself.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <param name="root">The root item.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindPrevious(this CodeUnit codeUnit, ConditionalLogicalExpressionType type, CodeUnit root)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);
            Param.Ignore(root);

            return FindPrevious(codeUnit, c => c.Is(type), root);
        }

        /// <summary>
        /// Gets the previous item of the given type at any level in the hierarchy.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindPrevious(this CodeUnit codeUnit, LogicalExpressionType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindPrevious(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the previous item of the given type which is a descendent of the given root or is the root itself.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <param name="root">The root item.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindPrevious(this CodeUnit codeUnit, LogicalExpressionType type, CodeUnit root)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);
            Param.Ignore(root);

            return FindPrevious(codeUnit, c => c.Is(type), root);
        }

        /// <summary>
        /// Gets the previous item of the given type at any level in the hierarchy.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindPrevious(this CodeUnit codeUnit, RelationalExpressionType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindPrevious(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the previous item of the given type which is a descendent of the given root or is the root itself.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <param name="root">The root item.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindPrevious(this CodeUnit codeUnit, RelationalExpressionType type, CodeUnit root)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);
            Param.Ignore(root);

            return FindPrevious(codeUnit, c => c.Is(type), root);
        }

        /// <summary>
        /// Gets the previous item of the given type at any level in the hierarchy.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindPrevious(this CodeUnit codeUnit, UnaryExpressionType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindPrevious(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the previous item of the given type which is a descendent of the given root or is the root itself.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <param name="root">The root item.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindPrevious(this CodeUnit codeUnit, UnaryExpressionType type, CodeUnit root)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);
            Param.Ignore(root);

            return FindPrevious(codeUnit, c => c.Is(type), root);
        }

        /// <summary>
        /// Gets the previous item of the given type at any level in the hierarchy.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindPrevious(this CodeUnit codeUnit, UnsafeAccessExpressionType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindPrevious(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the previous item of the given type which is a descendent of the given root or is the root itself.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <param name="root">The root item.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindPrevious(this CodeUnit codeUnit, UnsafeAccessExpressionType type, CodeUnit root)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);
            Param.Ignore(root);

            return FindPrevious(codeUnit, c => c.Is(type), root);
        }

        /// <summary>
        /// Gets the previous item of the given type at any level in the hierarchy.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindPrevious(this CodeUnit codeUnit, StatementType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindPrevious(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the previous item of the given type which is a descendent of the given root or is the root itself.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <param name="root">The root item.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindPrevious(this CodeUnit codeUnit, StatementType type, CodeUnit root)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);
            Param.Ignore(root);

            return FindPrevious(codeUnit, c => c.Is(type), root);
        }

        /// <summary>
        /// Gets the previous item of the given type at any level in the hierarchy.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindPrevious(this CodeUnit codeUnit, ElementType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindPrevious(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the previous item of the given type which is a descendent of the given root or is the root itself.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <param name="root">The root item.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindPrevious(this CodeUnit codeUnit, ElementType type, CodeUnit root)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);
            Param.Ignore(root);

            return FindPrevious(codeUnit, c => c.Is(type), root);
        }

        /// <summary>
        /// Gets the previous item of the given type at any level in the hierarchy.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindPrevious(this CodeUnit codeUnit)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            return FindPrevious(codeUnit, c => true);
        }

        /// <summary>
        /// Gets the previous item of the given type which is a descendent of the given root or is the root itself.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="root">The root item.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindPrevious(this CodeUnit codeUnit, CodeUnit root)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(root);

            return FindPrevious(codeUnit, c => true, root);
        }

        /// <summary>
        /// Gets the previous item of the given type at any level in the hierarchy.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static LexicalElement FindPreviousLexicalElement(this CodeUnit codeUnit)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            return (LexicalElement)FindPrevious(codeUnit, c => c.Is(CodeUnitType.LexicalElement));
        }

        /// <summary>
        /// Gets the previous item of the given type which is a descendent of the given root or is the root itself.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="root">The root item.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static LexicalElement FindPreviousLexicalElement(this CodeUnit codeUnit, CodeUnit root)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(root);

            return (LexicalElement)FindPrevious(codeUnit, c => c.Is(CodeUnitType.LexicalElement), root);
        }

        /// <summary>
        /// Gets the previous item of the given type at any level in the hierarchy.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static Token FindPreviousToken(this CodeUnit codeUnit)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            return (Token)FindPrevious(codeUnit, c => c.Is(LexicalElementType.Token));
        }

        /// <summary>
        /// Gets the previous item of the given type which is a descendent of the given root or is the root itself.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="root">The root item.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static Token FindPreviousToken(this CodeUnit codeUnit, CodeUnit root)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(root);

            return (Token)FindPrevious(codeUnit, c => c.Is(LexicalElementType.Token), root);
        }

        /// <summary>
        /// Gets the previous item of the given type at any level in the hierarchy.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static QueryClause FindPreviousQueryClause(this CodeUnit codeUnit)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            return (QueryClause)FindPrevious(codeUnit, c => c.Is(CodeUnitType.QueryClause));
        }

        /// <summary>
        /// Gets the previous item of the given type which is a descendent of the given root or is the root itself.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="root">The root item.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static QueryClause FindPreviousQueryClause(this CodeUnit codeUnit, CodeUnit root)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(root);

            return (QueryClause)FindPrevious(codeUnit, c => c.Is(CodeUnitType.QueryClause), root);
        }

        /// <summary>
        /// Gets the previous item of the given type at any level in the hierarchy.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static Expression FindPreviousExpression(this CodeUnit codeUnit)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            return (Expression)FindPrevious(codeUnit, c => c.Is(CodeUnitType.Expression));
        }

        /// <summary>
        /// Gets the previous item of the given type which is a descendent of the given root or is the root itself.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="root">The root item.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static Expression FindPreviousExpression(this CodeUnit codeUnit, CodeUnit root)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(root);

            return (Expression)FindPrevious(codeUnit, c => c.Is(CodeUnitType.Expression), root);
        }

        /// <summary>
        /// Gets the previous item of the given type at any level in the hierarchy.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static Statement FindPreviousStatement(this CodeUnit codeUnit)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            return (Statement)FindPrevious(codeUnit, c => c.Is(CodeUnitType.Statement));
        }

        /// <summary>
        /// Gets the previous item of the given type which is a descendent of the given root or is the root itself.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="root">The root item.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static Statement FindPreviousStatement(this CodeUnit codeUnit, CodeUnit root)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(root);

            return (Statement)FindPrevious(codeUnit, c => c.Is(CodeUnitType.Statement), root);
        }

        /// <summary>
        /// Gets the previous item of the given type at any level in the hierarchy.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static Element FindPreviousElement(this CodeUnit codeUnit)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            return (Element)FindPrevious(codeUnit, c => c.Is(CodeUnitType.Element));
        }

        /// <summary>
        /// Gets the previous item of the given type which is a descendent of the given root or is the root itself.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="root">The root item.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static Element FindPreviousElement(this CodeUnit codeUnit, CodeUnit root)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(root);

            return (Element)FindPrevious(codeUnit, c => c.Is(CodeUnitType.Element), root);
        }
        
        #endregion FindPrevious

        #region FindPreviousNonParent

        /// <summary>
        /// Gets the previous item of the given type at any level in the hierarchy which is not a parent or ancestor of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <typeparam name="T">The type of the item to return.</typeparam>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Justification = "The method does not require a parameter of type T.")]
        public static T FindPreviousNonParent<T>(this CodeUnit codeUnit) where T : CodeUnit
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            return (T)FindPreviousNonParent(codeUnit, c => c is T);
        }

        /// <summary>
        /// Gets the previous item of the given type at any level in the hierarchy which is not a parent or ancestor of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindPreviousNonParent(this CodeUnit codeUnit, CodeUnitType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindPreviousNonParent(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the previous item of the given type at any level in the hierarchy which is not a parent or ancestor of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindPreviousNonParent(this CodeUnit codeUnit, LexicalElementType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindPreviousNonParent(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the previous item of the given type at any level in the hierarchy which is not a parent or ancestor of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindPreviousNonParent(this CodeUnit codeUnit, TokenType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindPreviousNonParent(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the previous item of the given type at any level in the hierarchy which is not a parent or ancestor of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindPreviousNonParent(this CodeUnit codeUnit, OperatorType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindPreviousNonParent(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the previous item of the given type at any level in the hierarchy which is not a parent or ancestor of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindPreviousNonParent(this CodeUnit codeUnit, CommentType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindPreviousNonParent(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the previous item of the given type at any level in the hierarchy which is not a parent or ancestor of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindPreviousNonParent(this CodeUnit codeUnit, PreprocessorType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindPreviousNonParent(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the previous item of the given type at any level in the hierarchy which is not a parent or ancestor of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindPreviousNonParent(this CodeUnit codeUnit, QueryClauseType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindPreviousNonParent(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the previous item of the given type at any level in the hierarchy which is not a parent or ancestor of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindPreviousNonParent(this CodeUnit codeUnit, ExpressionType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindPreviousNonParent(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the previous item of the given type at any level in the hierarchy which is not a parent or ancestor of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindPreviousNonParent(this CodeUnit codeUnit, ArithmeticExpressionType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindPreviousNonParent(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the previous item of the given type at any level in the hierarchy which is not a parent or ancestor of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindPreviousNonParent(this CodeUnit codeUnit, AssignmentExpressionType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindPreviousNonParent(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the previous item of the given type at any level in the hierarchy which is not a parent or ancestor of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindPreviousNonParent(this CodeUnit codeUnit, ConditionalLogicalExpressionType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindPreviousNonParent(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the previous item of the given type at any level in the hierarchy which is not a parent or ancestor of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindPreviousNonParent(this CodeUnit codeUnit, LogicalExpressionType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindPreviousNonParent(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the previous item of the given type at any level in the hierarchy which is not a parent or ancestor of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindPreviousNonParent(this CodeUnit codeUnit, RelationalExpressionType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindPreviousNonParent(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the previous item of the given type at any level in the hierarchy which is not a parent or ancestor of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindPreviousNonParent(this CodeUnit codeUnit, UnaryExpressionType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindPreviousNonParent(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the previous item of the given type at any level in the hierarchy which is not a parent or ancestor of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindPreviousNonParent(this CodeUnit codeUnit, UnsafeAccessExpressionType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindPreviousNonParent(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the previous item of the given type at any level in the hierarchy which is not a parent or ancestor of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindPreviousNonParent(this CodeUnit codeUnit, StatementType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindPreviousNonParent(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the previous item of the given type at any level in the hierarchy which is not a parent or ancestor of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindPreviousNonParent(this CodeUnit codeUnit, ElementType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindPreviousNonParent(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the previous item of the given type at any level in the hierarchy which is not a parent or ancestor of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindPreviousNonParent(this CodeUnit codeUnit)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            return FindPreviousNonParent(codeUnit, c => true);
        }

        /// <summary>
        /// Gets the previous item of the given type at any level in the hierarchy which is not a parent or ancestor of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static LexicalElement FindPreviousNonParentLexicalElement(this CodeUnit codeUnit)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            return (LexicalElement)FindPreviousNonParent(codeUnit, c => c.Is(CodeUnitType.LexicalElement));
        }

        /// <summary>
        /// Gets the previous item of the given type at any level in the hierarchy which is not a parent or ancestor of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static Token FindPreviousNonParentToken(this CodeUnit codeUnit)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            return (Token)FindPreviousNonParent(codeUnit, c => c.Is(LexicalElementType.Token));
        }

        /// <summary>
        /// Gets the previous item of the given type at any level in the hierarchy which is not a parent or ancestor of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static QueryClause FindPreviousNonParentQueryClause(this CodeUnit codeUnit)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            return (QueryClause)FindPreviousNonParent(codeUnit, c => c.Is(CodeUnitType.QueryClause));
        }

        /// <summary>
        /// Gets the previous item of the given type at any level in the hierarchy which is not a parent or ancestor of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static Expression FindPreviousNonParentExpression(this CodeUnit codeUnit)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            return (Expression)FindPreviousNonParent(codeUnit, c => c.Is(CodeUnitType.Expression));
        }

        /// <summary>
        /// Gets the previous item of the given type at any level in the hierarchy which is not a parent or ancestor of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static Statement FindPreviousNonParentStatement(this CodeUnit codeUnit)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            return (Statement)FindPreviousNonParent(codeUnit, c => c.Is(CodeUnitType.Statement));
        }

        /// <summary>
        /// Gets the previous item of the given type at any level in the hierarchy which is not a parent or ancestor of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static Element FindPreviousNonParentElement(this CodeUnit codeUnit)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            return (Element)FindPreviousNonParent(codeUnit, c => c.Is(CodeUnitType.Element));
        }
        
        #endregion FindPreviousNonParent

        #region FindPreviousDescendentOf

        /// <summary>
        /// Gets the previous item of the given type which is a descendent of the given root.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="root">The root ancenstor of the previous item.</param>
        /// <typeparam name="T">The type of the item to return.</typeparam>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Justification = "The method does not require a parameter of type T.")]
        public static T FindPreviousDescendentOf<T>(this CodeUnit codeUnit, CodeUnit root) where T : CodeUnit
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(root);

            return (T)FindPreviousDescendentOf(codeUnit, c => c is T, root);
        }

        /// <summary>
        /// Gets the previous item of the given type which is a descendent of the given root.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="root">The root ancenstor of the previous item.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindPreviousDescendentOf(this CodeUnit codeUnit, CodeUnit root, CodeUnitType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(root);
            Param.Ignore(type);

            return FindPreviousDescendentOf(codeUnit, c => c.Is(type), root);
        }

        /// <summary>
        /// Gets the previous item of the given type which is a descendent of the given root.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="root">The root ancenstor of the previous item.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindPreviousDescendentOf(this CodeUnit codeUnit, CodeUnit root, LexicalElementType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(root);
            Param.Ignore(type);

            return FindPreviousDescendentOf(codeUnit, c => c.Is(type), root);
        }

        /// <summary>
        /// Gets the previous item of the given type which is a descendent of the given root.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="root">The root ancenstor of the previous item.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindPreviousDescendentOf(this CodeUnit codeUnit, CodeUnit root, TokenType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(root);
            Param.Ignore(type);

            return FindPreviousDescendentOf(codeUnit, c => c.Is(type), root);
        }

        /// <summary>
        /// Gets the previous item of the given type which is a descendent of the given root.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="root">The root ancenstor of the previous item.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindPreviousDescendentOf(this CodeUnit codeUnit, CodeUnit root, OperatorType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(root);
            Param.Ignore(type);

            return FindPreviousDescendentOf(codeUnit, c => c.Is(type), root);
        }

        /// <summary>
        /// Gets the previous item of the given type which is a descendent of the given root.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="root">The root ancenstor of the previous item.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindPreviousDescendentOf(this CodeUnit codeUnit, CodeUnit root, CommentType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(root);
            Param.Ignore(type);

            return FindPreviousDescendentOf(codeUnit, c => c.Is(type), root);
        }

        /// <summary>
        /// Gets the previous item of the given type which is a descendent of the given root.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="root">The root ancenstor of the previous item.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindPreviousDescendentOf(this CodeUnit codeUnit, CodeUnit root, PreprocessorType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(root);
            Param.Ignore(type);

            return FindPreviousDescendentOf(codeUnit, c => c.Is(type), root);
        }

        /// <summary>
        /// Gets the previous item of the given type which is a descendent of the given root.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="root">The root ancenstor of the previous item.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindPreviousDescendentOf(this CodeUnit codeUnit, CodeUnit root, QueryClauseType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(root);
            Param.Ignore(type);

            return FindPreviousDescendentOf(codeUnit, c => c.Is(type), root);
        }

        /// <summary>
        /// Gets the previous item of the given type which is a descendent of the given root.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="root">The root ancenstor of the previous item.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindPreviousDescendentOf(this CodeUnit codeUnit, CodeUnit root, ExpressionType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(root);
            Param.Ignore(type);

            return FindPreviousDescendentOf(codeUnit, c => c.Is(type), root);
        }

        /// <summary>
        /// Gets the previous item of the given type which is a descendent of the given root.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="root">The root ancenstor of the previous item.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindPreviousDescendentOf(this CodeUnit codeUnit, CodeUnit root, StatementType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(root);
            Param.Ignore(type);

            return FindPreviousDescendentOf(codeUnit, c => c.Is(type), root);
        }

        /// <summary>
        /// Gets the previous item of the given type which is a descendent of the given root.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="root">The root ancenstor of the previous item.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindPreviousDescendentOf(this CodeUnit codeUnit, CodeUnit root, ElementType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(root);
            Param.Ignore(type);

            return FindPreviousDescendentOf(codeUnit, c => c.Is(type), root);
        }

        /// <summary>
        /// Gets the previous item of the given type which is a descendent of the given root.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="root">The root ancenstor of the previous item.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindPreviousDescendentOf(this CodeUnit codeUnit, CodeUnit root)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(root);

            return FindPreviousDescendentOf(codeUnit, c => true, root);
        }

        /// <summary>
        /// Gets the previous item of the given type which is a descendent of the given root.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="root">The root ancenstor of the previous item.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static LexicalElement FindPreviousLexicalElementDescendentOf(this CodeUnit codeUnit, CodeUnit root)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(root);

            return (LexicalElement)FindPreviousDescendentOf(codeUnit, c => c.Is(CodeUnitType.LexicalElement), root);
        }

        /// <summary>
        /// Gets the previous item of the given type which is a descendent of the given root.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="root">The root ancenstor of the previous item.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static Token FindPreviousTokenDescendentOf(this CodeUnit codeUnit, CodeUnit root)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(root);

            return (Token)FindPreviousDescendentOf(codeUnit, c => c.Is(LexicalElementType.Token), root);
        }

        /// <summary>
        /// Gets the previous item of the given type which is a descendent of the given root.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="root">The root ancenstor of the previous item.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static QueryClause FindPreviousQueryClauseDescendentOf(this CodeUnit codeUnit, CodeUnit root)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(root);

            return (QueryClause)FindPreviousDescendentOf(codeUnit, c => c.Is(CodeUnitType.QueryClause), root);
        }

        /// <summary>
        /// Gets the previous item of the given type which is a descendent of the given root.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="root">The root ancenstor of the previous item.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static Expression FindPreviousExpressionDescendentOf(this CodeUnit codeUnit, CodeUnit root)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(root);

            return (Expression)FindPreviousDescendentOf(codeUnit, c => c.Is(CodeUnitType.Expression), root);
        }

        /// <summary>
        /// Gets the previous item of the given type which is a descendent of the given root.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="root">The root ancenstor of the previous item.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static Statement FindPreviousStatementDescendentOf(this CodeUnit codeUnit, CodeUnit root)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(root);

            return (Statement)FindPreviousDescendentOf(codeUnit, c => c.Is(CodeUnitType.Statement), root);
        }

        /// <summary>
        /// Gets the previous item of the given type which is a descendent of the given root.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="root">The root ancenstor of the previous item.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static Element FindPreviousElementDescendentOf(this CodeUnit codeUnit, CodeUnit root)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(root);

            return (Element)FindPreviousDescendentOf(codeUnit, c => c.Is(CodeUnitType.Element), root);
        }
        
        #endregion FindPreviousDescendentOf

        #region FindPreviousSibling

        /// <summary>
        /// Gets the previous item of the given type which is a direct child of the given parent.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <typeparam name="T">The type of the item to return.</typeparam>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Justification = "The method does not require a parameter of type T.")]
        public static T FindPreviousSibling<T>(this CodeUnit codeUnit) where T : CodeUnit
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            return (T)FindPreviousSibling(codeUnit, c => c is T);
        }

        /// <summary>
        /// Gets the previous item of the given type which is a direct child of the given parent.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindPreviousSibling(this CodeUnit codeUnit, CodeUnitType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindPreviousSibling(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the previous item of the given type which is a direct child of the given parent.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindPreviousSibling(this CodeUnit codeUnit, LexicalElementType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindPreviousSibling(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the previous item of the given type which is a direct child of the given parent.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindPreviousSibling(this CodeUnit codeUnit, TokenType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindPreviousSibling(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the previous item of the given type which is a direct child of the given parent.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindPreviousSibling(this CodeUnit codeUnit, OperatorType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindPreviousSibling(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the previous item of the given type which is a direct child of the given parent.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindPreviousSibling(this CodeUnit codeUnit, CommentType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindPreviousSibling(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the previous item of the given type which is a direct child of the given parent.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindPreviousSibling(this CodeUnit codeUnit, PreprocessorType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindPreviousSibling(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the previous item of the given type which is a direct child of the given parent.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindPreviousSibling(this CodeUnit codeUnit, QueryClauseType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindPreviousSibling(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the previous item of the given type which is a direct child of the given parent.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindPreviousSibling(this CodeUnit codeUnit, ExpressionType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindPreviousSibling(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the previous item of the given type which is a direct child of the given parent.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindPreviousSibling(this CodeUnit codeUnit, ArithmeticExpressionType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindPreviousSibling(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the previous item of the given type which is a direct child of the given parent.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindPreviousSibling(this CodeUnit codeUnit, AssignmentExpressionType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindPreviousSibling(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the previous item of the given type which is a direct child of the given parent.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindPreviousSibling(this CodeUnit codeUnit, ConditionalLogicalExpressionType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindPreviousSibling(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the previous item of the given type which is a direct child of the given parent.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindPreviousSibling(this CodeUnit codeUnit, LogicalExpressionType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindPreviousSibling(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the previous item of the given type which is a direct child of the given parent.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindPreviousSibling(this CodeUnit codeUnit, RelationalExpressionType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindPreviousSibling(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the previous item of the given type which is a direct child of the given parent.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindPreviousSibling(this CodeUnit codeUnit, UnaryExpressionType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindPreviousSibling(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the previous item of the given type which is a direct child of the given parent.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindPreviousSibling(this CodeUnit codeUnit, UnsafeAccessExpressionType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindPreviousSibling(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the previous item of the given type which is a direct child of the given parent.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindPreviousSibling(this CodeUnit codeUnit, StatementType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindPreviousSibling(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the previous item of the given type which is a direct child of the given parent.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindPreviousSibling(this CodeUnit codeUnit, ElementType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindPreviousSibling(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the previous item of the given type which is a direct child of the given parent.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindPreviousSibling(this CodeUnit codeUnit)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            return FindPreviousSibling(codeUnit, c => true);
        }

        /// <summary>
        /// Gets the previous item of the given type which is a direct child of the given parent.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static LexicalElement FindPreviousSiblingLexicalElement(this CodeUnit codeUnit)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            return (LexicalElement)FindPreviousSibling(codeUnit, c => c.Is(CodeUnitType.LexicalElement));
        }

        /// <summary>
        /// Gets the previous item of the given type which is a direct child of the given parent.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static Token FindPreviousSiblingToken(this CodeUnit codeUnit)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            return (Token)FindPreviousSibling(codeUnit, c => c.Is(LexicalElementType.Token));
        }

        /// <summary>
        /// Gets the previous item of the given type which is a direct child of the given parent.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static QueryClause FindPreviousSiblingQueryClause(this CodeUnit codeUnit)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            return (QueryClause)FindPreviousSibling(codeUnit, c => c.Is(CodeUnitType.QueryClause));
        }

        /// <summary>
        /// Gets the previous item of the given type which is a direct child of the given parent.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static Expression FindPreviousSiblingExpression(this CodeUnit codeUnit)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            return (Expression)FindPreviousSibling(codeUnit, c => c.Is(CodeUnitType.Expression));
        }

        /// <summary>
        /// Gets the previous item of the given type which is a direct child of the given parent.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static Statement FindPreviousSiblingStatement(this CodeUnit codeUnit)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            return (Statement)FindPreviousSibling(codeUnit, c => c.Is(CodeUnitType.Statement));
        }

        /// <summary>
        /// Gets the previous item of the given type which is a direct child of the given parent.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <returns>Returns the previous item or null if there are no items of the requested type.</returns>
        public static Element FindPreviousSiblingElement(this CodeUnit codeUnit)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            return (Element)FindPreviousSibling(codeUnit, c => c.Is(CodeUnitType.Element));
        }
        
        #endregion FindPreviousSibling

        #region FindFirst

        /// <summary>
        /// Gets the first item of the given type which is a descendent of this item or this item itself.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <typeparam name="T">The type of the item to return.</typeparam>
        /// <returns>Returns the first item or null if there are no items of the requested type.</returns>
        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Justification = "The method does not require a parameter of type T.")]
        public static T FindFirst<T>(this CodeUnit codeUnit) where T : CodeUnit
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            return (T)FindFirst(codeUnit, c => c is T);
        }

        /// <summary>
        /// Gets the first item of the given type which is a descendent of this item or this item itself.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the first item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindFirst(this CodeUnit codeUnit, CodeUnitType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindFirst(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the first item of the given type which is a descendent of this item or this item itself.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the first item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindFirst(this CodeUnit codeUnit, LexicalElementType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindFirst(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the first item of the given type which is a descendent of this item or this item itself.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the first item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindFirst(this CodeUnit codeUnit, TokenType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindFirst(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the first item of the given type which is a descendent of this item or this item itself.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the first item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindFirst(this CodeUnit codeUnit, OperatorType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindFirst(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the first item of the given type which is a descendent of this item or this item itself.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the first item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindFirst(this CodeUnit codeUnit, CommentType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindFirst(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the first item of the given type which is a descendent of this item or this item itself.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the first item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindFirst(this CodeUnit codeUnit, PreprocessorType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindFirst(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the first item of the given type which is a descendent of this item or this item itself.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the first item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindFirst(this CodeUnit codeUnit, QueryClauseType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindFirst(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the first item of the given type which is a descendent of this item or this item itself.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the first item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindFirst(this CodeUnit codeUnit, ExpressionType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindFirst(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the first item of the given type which is a descendent of this item or this item itself.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the first item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindFirst(this CodeUnit codeUnit, ArithmeticExpressionType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindFirst(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the first item of the given type which is a descendent of this item or this item itself.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the first item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindFirst(this CodeUnit codeUnit, AssignmentExpressionType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindFirst(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the first item of the given type which is a descendent of this item or this item itself.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the first item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindFirst(this CodeUnit codeUnit, ConditionalLogicalExpressionType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindFirst(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the first item of the given type which is a descendent of this item or this item itself.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the first item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindFirst(this CodeUnit codeUnit, LogicalExpressionType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindFirst(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the first item of the given type which is a descendent of this item or this item itself.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the first item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindFirst(this CodeUnit codeUnit, RelationalExpressionType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindFirst(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the first item of the given type which is a descendent of this item or this item itself.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the first item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindFirst(this CodeUnit codeUnit, UnaryExpressionType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindFirst(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the first item of the given type which is a descendent of this item or this item itself.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the first item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindFirst(this CodeUnit codeUnit, UnsafeAccessExpressionType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindFirst(codeUnit, c => c.Is(type));
        }
        
        /// <summary>
        /// Gets the first item of the given type which is a descendent of this item or this item itself.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the first item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindFirst(this CodeUnit codeUnit, StatementType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindFirst(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the first item of the given type which is a descendent of this item or this item itself.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the first item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindFirst(this CodeUnit codeUnit, ElementType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindFirst(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the first item of the given type which is a descendent of this item or this item itself.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <returns>Returns the first item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindFirst(this CodeUnit codeUnit)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            return FindFirst(codeUnit, c => true);
        }

        /// <summary>
        /// Gets the first item of the given type which is a descendent of this item or this item itself.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <returns>Returns the first item or null if there are no items of the requested type.</returns>
        public static LexicalElement FindFirstLexicalElement(this CodeUnit codeUnit)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            return (LexicalElement)FindFirst(codeUnit, c => c.Is(CodeUnitType.LexicalElement));
        }

        /// <summary>
        /// Gets the first item of the given type which is a descendent of this item or this item itself.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <returns>Returns the first item or null if there are no items of the requested type.</returns>
        public static Token FindFirstToken(this CodeUnit codeUnit)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            return (Token)FindFirst(codeUnit, c => c.Is(LexicalElementType.Token));
        }

        /// <summary>
        /// Gets the first item of the given type which is a descendent of this item or this item itself.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <returns>Returns the first item or null if there are no items of the requested type.</returns>
        public static QueryClause FindFirstQueryClause(this CodeUnit codeUnit)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            return (QueryClause)FindFirst(codeUnit, c => c.Is(CodeUnitType.QueryClause));
        }

        /// <summary>
        /// Gets the first item of the given type which is a descendent of this item or this item itself.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <returns>Returns the first item or null if there are no items of the requested type.</returns>
        public static Expression FindFirstExpression(this CodeUnit codeUnit)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            return (Expression)FindFirst(codeUnit, c => c.Is(CodeUnitType.Expression));
        }

        /// <summary>
        /// Gets the first item of the given type which is a descendent of this item or this item itself.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <returns>Returns the first item or null if there are no items of the requested type.</returns>
        public static Statement FindFirstStatement(this CodeUnit codeUnit)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            return (Statement)FindFirst(codeUnit, c => c.Is(CodeUnitType.Statement));
        }

        /// <summary>
        /// Gets the first item of the given type which is a descendent of this item or this item itself.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <returns>Returns the first item or null if there are no items of the requested type.</returns>
        public static Element FindFirstElement(this CodeUnit codeUnit)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            return (Element)FindFirst(codeUnit, c => c.Is(CodeUnitType.Element));
        }

        #endregion FindFirst

        #region FindFirstChild

        /// <summary>
        /// Gets the first item of the given type which is a direct child of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <typeparam name="T">The type of the item to return.</typeparam>
        /// <returns>Returns the first item or null if there are no items of the requested type.</returns>
        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Justification = "The method does not require a parameter of type T.")]
        public static T FindFirstChild<T>(this CodeUnit codeUnit) where T : CodeUnit
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            return (T)FindFirstChild(codeUnit, c => c is T);
        }

        /// <summary>
        /// Gets the first item of the given type which is a direct child of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the first item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindFirstChild(this CodeUnit codeUnit, CodeUnitType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindFirstChild(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the first item of the given type which is a direct child of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the first item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindFirstChild(this CodeUnit codeUnit, LexicalElementType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindFirstChild(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the first item of the given type which is a direct child of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the first item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindFirstChild(this CodeUnit codeUnit, TokenType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindFirstChild(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the first item of the given type which is a direct child of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the first item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindFirstChild(this CodeUnit codeUnit, OperatorType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindFirstChild(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the first item of the given type which is a direct child of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the first item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindFirstChild(this CodeUnit codeUnit, CommentType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindFirstChild(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the first item of the given type which is a direct child of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the first item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindFirstChild(this CodeUnit codeUnit, PreprocessorType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindFirstChild(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the first item of the given type which is a direct child of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the first item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindFirstChild(this CodeUnit codeUnit, QueryClauseType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindFirstChild(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the first item of the given type which is a direct child of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the first item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindFirstChild(this CodeUnit codeUnit, ExpressionType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindFirstChild(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the first item of the given type which is a direct child of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the first item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindFirstChild(this CodeUnit codeUnit, ArithmeticExpressionType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindFirstChild(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the first item of the given type which is a direct child of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the first item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindFirstChild(this CodeUnit codeUnit, AssignmentExpressionType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindFirstChild(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the first item of the given type which is a direct child of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the first item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindFirstChild(this CodeUnit codeUnit, ConditionalLogicalExpressionType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindFirstChild(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the first item of the given type which is a direct child of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the first item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindFirstChild(this CodeUnit codeUnit, LogicalExpressionType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindFirstChild(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the first item of the given type which is a direct child of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the first item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindFirstChild(this CodeUnit codeUnit, RelationalExpressionType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindFirstChild(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the first item of the given type which is a direct child of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the first item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindFirstChild(this CodeUnit codeUnit, UnaryExpressionType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindFirstChild(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the first item of the given type which is a direct child of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the first item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindFirstChild(this CodeUnit codeUnit, UnsafeAccessExpressionType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindFirstChild(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the first item of the given type which is a direct child of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the first item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindFirstChild(this CodeUnit codeUnit, StatementType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindFirstChild(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the first item of the given type which is a direct child of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the first item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindFirstChild(this CodeUnit codeUnit, ElementType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindFirstChild(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the first item of the given type which is a direct child of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <returns>Returns the first item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindFirstChild(this CodeUnit codeUnit)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            return FindFirstChild(codeUnit, c => true);
        }

        /// <summary>
        /// Gets the first item of the given type which is a direct child of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <returns>Returns the first item or null if there are no items of the requested type.</returns>
        public static LexicalElement FindFirstChildLexicalElement(this CodeUnit codeUnit)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            return (LexicalElement)FindFirstChild(codeUnit, c => c.Is(CodeUnitType.LexicalElement));
        }

        /// <summary>
        /// Gets the first item of the given type which is a direct child of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <returns>Returns the first item or null if there are no items of the requested type.</returns>
        public static Token FindFirstChildToken(this CodeUnit codeUnit)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            return (Token)FindFirstChild(codeUnit, c => c.Is(LexicalElementType.Token));
        }

        /// <summary>
        /// Gets the first item of the given type which is a direct child of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <returns>Returns the first item or null if there are no items of the requested type.</returns>
        public static QueryClause FindFirstChildQueryClause(this CodeUnit codeUnit)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            return (QueryClause)FindFirstChild(codeUnit, c => c.Is(CodeUnitType.QueryClause));
        }

        /// <summary>
        /// Gets the first item of the given type which is a direct child of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <returns>Returns the first item or null if there are no items of the requested type.</returns>
        public static Expression FindFirstChildExpression(this CodeUnit codeUnit)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            return (Expression)FindFirstChild(codeUnit, c => c.Is(CodeUnitType.Expression));
        }

        /// <summary>
        /// Gets the first item of the given type which is a direct child of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <returns>Returns the first item or null if there are no items of the requested type.</returns>
        public static Statement FindFirstChildStatement(this CodeUnit codeUnit)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            return (Statement)FindFirstChild(codeUnit, c => c.Is(CodeUnitType.Statement));
        }

        /// <summary>
        /// Gets the first item of the given type which is a direct child of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <returns>Returns the first item or null if there are no items of the requested type.</returns>
        public static Element FindFirstChildElement(this CodeUnit codeUnit)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            return (Element)FindFirstChild(codeUnit, c => c.Is(CodeUnitType.Element));
        }
        
        #endregion FindFirstChild

        #region FindFirstDescendent

        /// <summary>
        /// Gets the first item of the given type which is a descendent of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <typeparam name="T">The type of the item to return.</typeparam>
        /// <returns>Returns the first item or null if there are no items of the requested type.</returns>
        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Justification = "The method does not require a parameter of type T.")]
        public static T FindFirstDescendent<T>(this CodeUnit codeUnit) where T : CodeUnit
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            return (T)FindFirstDescendent(codeUnit, c => c is T);
        }

        /// <summary>
        /// Gets the first item of the given type which is a descendent of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the first item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindFirstDescendent(this CodeUnit codeUnit, CodeUnitType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindFirstDescendent(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the first item of the given type which is a descendent of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the first item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindFirstDescendent(this CodeUnit codeUnit, LexicalElementType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindFirstDescendent(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the first item of the given type which is a descendent of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the first item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindFirstDescendent(this CodeUnit codeUnit, TokenType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindFirstDescendent(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the first item of the given type which is a descendent of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the first item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindFirstDescendent(this CodeUnit codeUnit, OperatorType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindFirstDescendent(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the first item of the given type which is a descendent of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the first item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindFirstDescendent(this CodeUnit codeUnit, CommentType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindFirstDescendent(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the first item of the given type which is a descendent of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the first item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindFirstDescendent(this CodeUnit codeUnit, PreprocessorType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindFirstDescendent(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the first item of the given type which is a descendent of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the first item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindFirstDescendent(this CodeUnit codeUnit, QueryClauseType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindFirstDescendent(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the first item of the given type which is a descendent of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the first item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindFirstDescendent(this CodeUnit codeUnit, ExpressionType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindFirstDescendent(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the first item of the given type which is a descendent of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the first item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindFirstDescendent(this CodeUnit codeUnit, ArithmeticExpressionType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindFirstDescendent(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the first item of the given type which is a descendent of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the first item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindFirstDescendent(this CodeUnit codeUnit, AssignmentExpressionType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindFirstDescendent(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the first item of the given type which is a descendent of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the first item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindFirstDescendent(this CodeUnit codeUnit, ConditionalLogicalExpressionType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindFirstDescendent(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the first item of the given type which is a descendent of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the first item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindFirstDescendent(this CodeUnit codeUnit, LogicalExpressionType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindFirstDescendent(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the first item of the given type which is a descendent of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the first item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindFirstDescendent(this CodeUnit codeUnit, RelationalExpressionType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindFirstDescendent(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the first item of the given type which is a descendent of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the first item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindFirstDescendent(this CodeUnit codeUnit, UnaryExpressionType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindFirstDescendent(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the first item of the given type which is a descendent of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the first item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindFirstDescendent(this CodeUnit codeUnit, UnsafeAccessExpressionType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindFirstDescendent(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the first item of the given type which is a descendent of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the first item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindFirstDescendent(this CodeUnit codeUnit, StatementType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindFirstDescendent(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the first item of the given type which is a descendent of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the first item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindFirstDescendent(this CodeUnit codeUnit, ElementType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindFirstDescendent(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the first item of the given type which is a descendent of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <returns>Returns the first item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindFirstDescendent(this CodeUnit codeUnit)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            return FindFirstDescendent(codeUnit, c => true);
        }

        /// <summary>
        /// Gets the first item of the given type which is a descendent of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <returns>Returns the first item or null if there are no items of the requested type.</returns>
        public static LexicalElement FindFirstDescendentLexicalElement(this CodeUnit codeUnit)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            return (LexicalElement)FindFirstDescendent(codeUnit, c => c.Is(CodeUnitType.LexicalElement));
        }

        /// <summary>
        /// Gets the first item of the given type which is a descendent of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <returns>Returns the first item or null if there are no items of the requested type.</returns>
        public static Token FindFirstDescendentToken(this CodeUnit codeUnit)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            return (Token)FindFirstDescendent(codeUnit, c => c.Is(LexicalElementType.Token));
        }

        /// <summary>
        /// Gets the first item of the given type which is a descendent of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <returns>Returns the first item or null if there are no items of the requested type.</returns>
        public static QueryClause FindFirstDescendentQueryClause(this CodeUnit codeUnit)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            return (QueryClause)FindFirstDescendent(codeUnit, c => c.Is(CodeUnitType.QueryClause));
        }

        /// <summary>
        /// Gets the first item of the given type which is a descendent of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <returns>Returns the first item or null if there are no items of the requested type.</returns>
        public static Expression FindFirstDescendentExpression(this CodeUnit codeUnit)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            return (Expression)FindFirstDescendent(codeUnit, c => c.Is(CodeUnitType.Expression));
        }

        /// <summary>
        /// Gets the first item of the given type which is a descendent of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <returns>Returns the first item or null if there are no items of the requested type.</returns>
        public static Statement FindFirstDescendentStatement(this CodeUnit codeUnit)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            return (Statement)FindFirstDescendent(codeUnit, c => c.Is(CodeUnitType.Statement));
        }

        /// <summary>
        /// Gets the first item of the given type which is a descendent of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <returns>Returns the first item or null if there are no items of the requested type.</returns>
        public static Element FindFirstDescendentElement(this CodeUnit codeUnit)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            return (Element)FindFirstDescendent(codeUnit, c => c.Is(CodeUnitType.Element));
        }
        
        #endregion FindFirstDescendent

        #region FindLast

        /// <summary>
        /// Gets the last item of the given type which is a descendent of this item or this item itself.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <typeparam name="T">The type of the item to return.</typeparam>
        /// <returns>Returns the last item or null if there are no items of the requested type.</returns>
        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Justification = "The method does not require a parameter of type T.")]
        public static T FindLast<T>(this CodeUnit codeUnit) where T : CodeUnit
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            return (T)FindLast(codeUnit, c => c is T);
        }

        /// <summary>
        /// Gets the last item of the given type which is a descendent of this item or this item itself.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the last item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindLast(this CodeUnit codeUnit, CodeUnitType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindLast(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the last item of the given type which is a descendent of this item or this item itself.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the last item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindLast(this CodeUnit codeUnit, LexicalElementType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindLast(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the last item of the given type which is a descendent of this item or this item itself.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the last item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindLast(this CodeUnit codeUnit, TokenType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindLast(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the last item of the given type which is a descendent of this item or this item itself.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the last item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindLast(this CodeUnit codeUnit, OperatorType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindLast(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the last item of the given type which is a descendent of this item or this item itself.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the last item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindLast(this CodeUnit codeUnit, CommentType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindLast(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the last item of the given type which is a descendent of this item or this item itself.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the last item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindLast(this CodeUnit codeUnit, PreprocessorType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindLast(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the last item of the given type which is a descendent of this item or this item itself.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the last item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindLast(this CodeUnit codeUnit, QueryClauseType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindLast(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the last item of the given type which is a descendent of this item or this item itself.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the last item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindLast(this CodeUnit codeUnit, ExpressionType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindLast(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the last item of the given type which is a descendent of this item or this item itself.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the last item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindLast(this CodeUnit codeUnit, ArithmeticExpressionType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindLast(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the last item of the given type which is a descendent of this item or this item itself.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the last item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindLast(this CodeUnit codeUnit, AssignmentExpressionType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindLast(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the last item of the given type which is a descendent of this item or this item itself.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the last item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindLast(this CodeUnit codeUnit, ConditionalLogicalExpressionType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindLast(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the last item of the given type which is a descendent of this item or this item itself.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the last item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindLast(this CodeUnit codeUnit, LogicalExpressionType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindLast(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the last item of the given type which is a descendent of this item or this item itself.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the last item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindLast(this CodeUnit codeUnit, RelationalExpressionType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindLast(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the last item of the given type which is a descendent of this item or this item itself.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the last item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindLast(this CodeUnit codeUnit, UnaryExpressionType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindLast(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the last item of the given type which is a descendent of this item or this item itself.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the last item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindLast(this CodeUnit codeUnit, UnsafeAccessExpressionType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindLast(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the last item of the given type which is a descendent of this item or this item itself.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the last item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindLast(this CodeUnit codeUnit, StatementType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindLast(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the last item of the given type which is a descendent of this item or this item itself.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the last item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindLast(this CodeUnit codeUnit, ElementType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindLast(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the last item of the given type which is a descendent of this item or this item itself.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <returns>Returns the last item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindLast(this CodeUnit codeUnit)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            return FindLast(codeUnit, c => true);
        }

        /// <summary>
        /// Gets the last item of the given type which is a descendent of this item or this item itself.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <returns>Returns the last item or null if there are no items of the requested type.</returns>
        public static LexicalElement FindLastLexicalElement(this CodeUnit codeUnit)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            return (LexicalElement)FindLast(codeUnit, c => c.Is(CodeUnitType.LexicalElement));
        }

        /// <summary>
        /// Gets the last item of the given type which is a descendent of this item or this item itself.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <returns>Returns the last item or null if there are no items of the requested type.</returns>
        public static Token FindLastToken(this CodeUnit codeUnit)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            return (Token)FindLast(codeUnit, c => c.Is(LexicalElementType.Token));
        }

        /// <summary>
        /// Gets the last item of the given type which is a descendent of this item or this item itself.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <returns>Returns the last item or null if there are no items of the requested type.</returns>
        public static QueryClause FindLastQueryClause(this CodeUnit codeUnit)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            return (QueryClause)FindLast(codeUnit, c => c.Is(CodeUnitType.QueryClause));
        }

        /// <summary>
        /// Gets the last item of the given type which is a descendent of this item or this item itself.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <returns>Returns the last item or null if there are no items of the requested type.</returns>
        public static Expression FindLastExpression(this CodeUnit codeUnit)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            return (Expression)FindLast(codeUnit, c => c.Is(CodeUnitType.Expression));
        }

        /// <summary>
        /// Gets the last item of the given type which is a descendent of this item or this item itself.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <returns>Returns the last item or null if there are no items of the requested type.</returns>
        public static Statement FindLastStatement(this CodeUnit codeUnit)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            return (Statement)FindLast(codeUnit, c => c.Is(CodeUnitType.Statement));
        }

        /// <summary>
        /// Gets the last item of the given type which is a descendent of this item or this item itself.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <returns>Returns the last item or null if there are no items of the requested type.</returns>
        public static Element FindLastElement(this CodeUnit codeUnit)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            return (Element)FindLast(codeUnit, c => c.Is(CodeUnitType.Element));
        }

        #endregion FindLast

        #region FindLastChild

        /// <summary>
        /// Gets the last item of the given type which is a direct child of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <typeparam name="T">The type of the item to return.</typeparam>
        /// <returns>Returns the last item or null if there are no items of the requested type.</returns>
        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Justification = "The method does not require a parameter of type T.")]
        public static T FindLastChild<T>(this CodeUnit codeUnit) where T : CodeUnit
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            return (T)FindLastChild(codeUnit, c => c is T);
        }

        /// <summary>
        /// Gets the last item of the given type which is a direct child of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the last item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindLastChild(this CodeUnit codeUnit, CodeUnitType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindLastChild(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the last item of the given type which is a direct child of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the last item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindLastChild(this CodeUnit codeUnit, LexicalElementType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindLastChild(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the last item of the given type which is a direct child of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the last item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindLastChild(this CodeUnit codeUnit, TokenType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindLastChild(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the last item of the given type which is a direct child of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the last item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindLastChild(this CodeUnit codeUnit, OperatorType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindLastChild(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the last item of the given type which is a direct child of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the last item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindLastChild(this CodeUnit codeUnit, CommentType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindLastChild(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the last item of the given type which is a direct child of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the last item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindLastChild(this CodeUnit codeUnit, PreprocessorType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindLastChild(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the last item of the given type which is a direct child of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the last item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindLastChild(this CodeUnit codeUnit, QueryClauseType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindLastChild(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the last item of the given type which is a direct child of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the last item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindLastChild(this CodeUnit codeUnit, ExpressionType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindLastChild(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the last item of the given type which is a direct child of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the last item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindLastChild(this CodeUnit codeUnit, ArithmeticExpressionType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindLastChild(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the last item of the given type which is a direct child of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the last item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindLastChild(this CodeUnit codeUnit, AssignmentExpressionType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindLastChild(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the last item of the given type which is a direct child of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the last item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindLastChild(this CodeUnit codeUnit, ConditionalLogicalExpressionType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindLastChild(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the last item of the given type which is a direct child of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the last item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindLastChild(this CodeUnit codeUnit, LogicalExpressionType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindLastChild(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the last item of the given type which is a direct child of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the last item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindLastChild(this CodeUnit codeUnit, RelationalExpressionType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindLastChild(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the last item of the given type which is a direct child of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the last item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindLastChild(this CodeUnit codeUnit, UnaryExpressionType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindLastChild(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the last item of the given type which is a direct child of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the last item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindLastChild(this CodeUnit codeUnit, UnsafeAccessExpressionType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindLastChild(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the last item of the given type which is a direct child of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the last item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindLastChild(this CodeUnit codeUnit, StatementType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindLastChild(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the last item of the given type which is a direct child of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the last item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindLastChild(this CodeUnit codeUnit, ElementType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindLastChild(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the last item of the given type which is a direct child of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <returns>Returns the last item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindLastChild(this CodeUnit codeUnit)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            return FindLastChild(codeUnit, c => true);
        }

        /// <summary>
        /// Gets the last item of the given type which is a direct child of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <returns>Returns the last item or null if there are no items of the requested type.</returns>
        public static LexicalElement FindLastChildLexicalElement(this CodeUnit codeUnit)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            return (LexicalElement)FindLastChild(codeUnit, c => c.Is(CodeUnitType.LexicalElement));
        }

        /// <summary>
        /// Gets the last item of the given type which is a direct child of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <returns>Returns the last item or null if there are no items of the requested type.</returns>
        public static Token FindLastChildToken(this CodeUnit codeUnit)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            return (Token)FindLastChild(codeUnit, c => c.Is(LexicalElementType.Token));
        }

        /// <summary>
        /// Gets the last item of the given type which is a direct child of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <returns>Returns the last item or null if there are no items of the requested type.</returns>
        public static QueryClause FindLastChildQueryClause(this CodeUnit codeUnit)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            return (QueryClause)FindLastChild(codeUnit, c => c.Is(CodeUnitType.QueryClause));
        }

        /// <summary>
        /// Gets the last item of the given type which is a direct child of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <returns>Returns the last item or null if there are no items of the requested type.</returns>
        public static Expression FindLastChildExpression(this CodeUnit codeUnit)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            return (Expression)FindLastChild(codeUnit, c => c.Is(CodeUnitType.Expression));
        }

        /// <summary>
        /// Gets the last item of the given type which is a direct child of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <returns>Returns the last item or null if there are no items of the requested type.</returns>
        public static Statement FindLastChildStatement(this CodeUnit codeUnit)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            return (Statement)FindLastChild(codeUnit, c => c.Is(CodeUnitType.Statement));
        }

        /// <summary>
        /// Gets the last item of the given type which is a direct child of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <returns>Returns the last item or null if there are no items of the requested type.</returns>
        public static Element FindLastChildElement(this CodeUnit codeUnit)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            return (Element)FindLastChild(codeUnit, c => c.Is(CodeUnitType.Element));
        }
        
        #endregion FindLastChild

        #region FindLastDescendent

        /// <summary>
        /// Gets the last item of the given type which is a descendent of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <typeparam name="T">The type of the item to return.</typeparam>
        /// <returns>Returns the last item or null if there are no items of the requested type.</returns>
        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Justification = "The method does not require a parameter of type T.")]
        public static T FindLastDescendent<T>(this CodeUnit codeUnit) where T : CodeUnit
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            return (T)FindLastDescendent(codeUnit, c => c is T);
        }

        /// <summary>
        /// Gets the last item of the given type which is a descendent of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the last item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindLastDescendent(this CodeUnit codeUnit, CodeUnitType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindLastDescendent(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the last item of the given type which is a descendent of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the last item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindLastDescendent(this CodeUnit codeUnit, LexicalElementType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindLastDescendent(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the last item of the given type which is a descendent of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the last item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindLastDescendent(this CodeUnit codeUnit, TokenType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindLastDescendent(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the last item of the given type which is a descendent of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the last item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindLastDescendent(this CodeUnit codeUnit, OperatorType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindLastDescendent(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the last item of the given type which is a descendent of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the last item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindLastDescendent(this CodeUnit codeUnit, CommentType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindLastDescendent(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the last item of the given type which is a descendent of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the last item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindLastDescendent(this CodeUnit codeUnit, PreprocessorType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindLastDescendent(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the last item of the given type which is a descendent of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the last item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindLastDescendent(this CodeUnit codeUnit, QueryClauseType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindLastDescendent(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the last item of the given type which is a descendent of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the last item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindLastDescendent(this CodeUnit codeUnit, ExpressionType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindLastDescendent(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the last item of the given type which is a descendent of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the last item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindLastDescendent(this CodeUnit codeUnit, ArithmeticExpressionType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindLastDescendent(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the last item of the given type which is a descendent of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the last item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindLastDescendent(this CodeUnit codeUnit, AssignmentExpressionType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindLastDescendent(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the last item of the given type which is a descendent of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the last item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindLastDescendent(this CodeUnit codeUnit, ConditionalLogicalExpressionType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindLastDescendent(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the last item of the given type which is a descendent of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the last item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindLastDescendent(this CodeUnit codeUnit, LogicalExpressionType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindLastDescendent(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the last item of the given type which is a descendent of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the last item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindLastDescendent(this CodeUnit codeUnit, RelationalExpressionType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindLastDescendent(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the last item of the given type which is a descendent of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the last item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindLastDescendent(this CodeUnit codeUnit, UnaryExpressionType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindLastDescendent(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the last item of the given type which is a descendent of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the last item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindLastDescendent(this CodeUnit codeUnit, UnsafeAccessExpressionType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindLastDescendent(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the last item of the given type which is a descendent of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the last item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindLastDescendent(this CodeUnit codeUnit, StatementType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindLastDescendent(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the last item of the given type which is a descendent of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="type">The type of the item to return.</param>
        /// <returns>Returns the last item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindLastDescendent(this CodeUnit codeUnit, ElementType type)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(type);

            return FindLastDescendent(codeUnit, c => c.Is(type));
        }

        /// <summary>
        /// Gets the last item of the given type which is a descendent of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <returns>Returns the last item or null if there are no items of the requested type.</returns>
        public static CodeUnit FindLastDescendent(this CodeUnit codeUnit)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            return FindLastDescendent(codeUnit, c => true);
        }

        /// <summary>
        /// Gets the last item of the given type which is a descendent of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <returns>Returns the last item or null if there are no items of the requested type.</returns>
        public static LexicalElement FindLastDescendentLexicalElement(this CodeUnit codeUnit)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            return (LexicalElement)FindLastDescendent(codeUnit, c => c.Is(CodeUnitType.LexicalElement));
        }

        /// <summary>
        /// Gets the last item of the given type which is a descendent of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <returns>Returns the last item or null if there are no items of the requested type.</returns>
        public static Token FindLastDescendentToken(this CodeUnit codeUnit)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            return (Token)FindLastDescendent(codeUnit, c => c.Is(LexicalElementType.Token));
        }

        /// <summary>
        /// Gets the last item of the given type which is a descendent of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <returns>Returns the last item or null if there are no items of the requested type.</returns>
        public static QueryClause FindLastDescendentQueryClause(this CodeUnit codeUnit)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            return (QueryClause)FindLastDescendent(codeUnit, c => c.Is(CodeUnitType.QueryClause));
        }

        /// <summary>
        /// Gets the last item of the given type which is a descendent of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <returns>Returns the last item or null if there are no items of the requested type.</returns>
        public static Expression FindLastDescendentExpression(this CodeUnit codeUnit)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            return (Expression)FindLastDescendent(codeUnit, c => c.Is(CodeUnitType.Expression));
        }

        /// <summary>
        /// Gets the last item of the given type which is a descendent of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <returns>Returns the last item or null if there are no items of the requested type.</returns>
        public static Statement FindLastDescendentStatement(this CodeUnit codeUnit)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            return (Statement)FindLastDescendent(codeUnit, c => c.Is(CodeUnitType.Statement));
        }

        /// <summary>
        /// Gets the last item of the given type which is a descendent of this item.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <returns>Returns the last item or null if there are no items of the requested type.</returns>
        public static Element FindLastDescendentElement(this CodeUnit codeUnit)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            return (Element)FindLastDescendent(codeUnit, c => c.Is(CodeUnitType.Element));
        }
        
        #endregion FindLastDescendent

        #region GetDescendents

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

        #endregion GetDescendents

        #region GetChildren

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

        #endregion GetChildren

        #region Is

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
        /// <param name="arithmeticExpressionType">The type to compare against.</param>
        /// <returns>Returns true if the item is of the given type; false otherwise.</returns>
        public static bool Is(this CodeUnit codeUnit, ArithmeticExpressionType arithmeticExpressionType)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(arithmeticExpressionType);

            return codeUnit.Is((int)arithmeticExpressionType, FundamentalTypeMasks.ArithmeticExpression);
        }

        /// <summary>
        /// Determines whether the item is of the given type.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="assignmentExpressionType">The type to compare against.</param>
        /// <returns>Returns true if the item is of the given type; false otherwise.</returns>
        public static bool Is(this CodeUnit codeUnit, AssignmentExpressionType assignmentExpressionType)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(assignmentExpressionType);

            return codeUnit.Is((int)assignmentExpressionType, FundamentalTypeMasks.AssignmentExpression);
        }

        /// <summary>
        /// Determines whether the item is of the given type.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="conditionalLogicalExpressionType">The type to compare against.</param>
        /// <returns>Returns true if the item is of the given type; false otherwise.</returns>
        public static bool Is(this CodeUnit codeUnit, ConditionalLogicalExpressionType conditionalLogicalExpressionType)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(conditionalLogicalExpressionType);

            return codeUnit.Is((int)conditionalLogicalExpressionType, FundamentalTypeMasks.ConditionalLogicalExpression);
        }

        /// <summary>
        /// Determines whether the item is of the given type.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="logicalExpressionType">The type to compare against.</param>
        /// <returns>Returns true if the item is of the given type; false otherwise.</returns>
        public static bool Is(this CodeUnit codeUnit, LogicalExpressionType logicalExpressionType)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(logicalExpressionType);

            return codeUnit.Is((int)logicalExpressionType, FundamentalTypeMasks.LogicalExpression);
        }

        /// <summary>
        /// Determines whether the item is of the given type.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="relationalExpressionType">The type to compare against.</param>
        /// <returns>Returns true if the item is of the given type; false otherwise.</returns>
        public static bool Is(this CodeUnit codeUnit, RelationalExpressionType relationalExpressionType)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(relationalExpressionType);

            return codeUnit.Is((int)relationalExpressionType, FundamentalTypeMasks.RelationalExpression);
        }

        /// <summary>
        /// Determines whether the item is of the given type.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="unaryExpressionType">The type to compare against.</param>
        /// <returns>Returns true if the item is of the given type; false otherwise.</returns>
        public static bool Is(this CodeUnit codeUnit, UnaryExpressionType unaryExpressionType)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(unaryExpressionType);

            return codeUnit.Is((int)unaryExpressionType, FundamentalTypeMasks.UnaryExpression);
        }

        /// <summary>
        /// Determines whether the item is of the given type.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="unsafeAccessExpressionType">The type to compare against.</param>
        /// <returns>Returns true if the item is of the given type; false otherwise.</returns>
        public static bool Is(this CodeUnit codeUnit, UnsafeAccessExpressionType unsafeAccessExpressionType)
        {
            Param.RequireNotNull(codeUnit, "codeUnit");
            Param.Ignore(unsafeAccessExpressionType);

            return codeUnit.Is((int)unsafeAccessExpressionType, FundamentalTypeMasks.UnsafeAccessExpression);
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

        #endregion Is

        #region WalkCodeModel

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

        #endregion WalkCodeModel

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

        /// <summary>
        /// Given a parent code unit, traverses through the parent hierarchy to find a parent element, if there is one.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="match">The delegate used for matching the code unit.</param>
        /// <returns>Returns the parent element or null if there is none.</returns>
        private static CodeUnit FindParent(CodeUnit codeUnit, MatchDelegate match)
        {
            Param.AssertNotNull(codeUnit, "codeUnit");
            Param.AssertNotNull(match, "match");

            CodeUnit parentCodeUnit = codeUnit.Parent;
            while (parentCodeUnit != null)
            {
                if (match(parentCodeUnit))
                {
                    return parentCodeUnit;
                }

                parentCodeUnit = parentCodeUnit.Parent;
            }

            return null;
        }

        /// <summary>
        /// Gets the next code unit of the given type at any level in the hierarchy.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="match">The delegate used for matching the code unit.</param>
        /// <returns>Returns the next code unit or null if there are no code units of the requested type.</returns>
        private static CodeUnit FindNext(CodeUnit codeUnit, MatchDelegate match)
        {
            Param.AssertNotNull(codeUnit, "codeUnit");
            Param.AssertNotNull(match, "match");

            CodeUnit item = codeUnit;
            while (item != null)
            {
                if (item != codeUnit)
                {
                    if (match(item))
                    {
                        return item;
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
        /// Gets the next code unit of the given type which is a descendent of the given root or is the root itself.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="match">The delegate used for matching the code unit.</param>
        /// <param name="root">The root code unit.</param>
        /// <returns>Returns the next code unit or null if there are no code units of the requested type.</returns>
        private static CodeUnit FindNext(CodeUnit codeUnit, MatchDelegate match, CodeUnit root)
        {
            Param.AssertNotNull(codeUnit, "codeUnit");
            Param.AssertNotNull(match, "match");
            Param.Ignore(root);

            CodeUnit item = codeUnit;
            while (item != null)
            {
                if (item != codeUnit)
                {
                    if (match(item))
                    {
                        return item;
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
        /// Gets the next code unit of the given type which is a descendent of the given root.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="match">The delegate used for matching the code unit.</param>
        /// <param name="root">The root ancenstor of the next codeUnit.</param>
        /// <returns>Returns the next code unit or null if there are no code units of the requested type.</returns>
        private static CodeUnit FindNextDescendentOf(CodeUnit codeUnit, MatchDelegate match, CodeUnit root)
        {
            Param.AssertNotNull(codeUnit, "codeUnit");
            Param.AssertNotNull(match, "match");
            Param.Ignore(root);

            CodeUnit item = codeUnit;
            while (item != null)
            {
                if (item != codeUnit)
                {
                    if (match(item))
                    {
                        return item;
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
        /// Gets the next code unit of the given type which is a direct child of the given parent.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="match">The delegate used for matching the code unit.</param>
        /// <returns>Returns the next code unit or null if there are no code units of the requested type.</returns>
        private static CodeUnit FindNextSibling(CodeUnit codeUnit, MatchDelegate match)
        {
            Param.AssertNotNull(codeUnit, "codeUnit");
            Param.AssertNotNull(match, "match");

            CodeUnit item = codeUnit.LinkNode.Next;
            while (item != null)
            {
                if (match(item))
                {
                    return item;
                }

                item = item.LinkNode.Next;
            }

            return null;
        }

        /// <summary>
        /// Gets the previous code unit of the given type at any level in the hierarchy.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="match">The delegate used for matching the code unit.</param>
        /// <returns>Returns the previous code unit or null if there are no code units of the requested type.</returns>
        private static CodeUnit FindPrevious(CodeUnit codeUnit, MatchDelegate match)
        {
            Param.AssertNotNull(codeUnit, "codeUnit");
            Param.AssertNotNull(match, "match");

            CodeUnit item = codeUnit;
            while (item != null)
            {
                if (item != codeUnit)
                {
                    if (match(item))
                    {
                        return item;
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
                        item = item.FindLastDescendent(match);
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
        /// <param name="match">The delegate used for matching the code unit.</param>
        /// <param name="root">The root item.</param>
        /// <returns>Returns the previous code unit or null if there are no code units of the requested type.</returns>
        private static CodeUnit FindPrevious(CodeUnit codeUnit, MatchDelegate match, CodeUnit root)
        {
            Param.AssertNotNull(codeUnit, "codeUnit");
            Param.AssertNotNull(match, "match");
            Param.Ignore(root);

            CodeUnit item = codeUnit;
            while (item != null)
            {
                if (item != codeUnit)
                {
                    if (match(item))
                    {
                        return item;
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
                        item = item.FindLastDescendent(match);
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
        /// Gets the previous code unit of the given type at any level in the hierarchy which is not a parent or ancestor of this code unit.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="match">The delegate used for matching the code unit.</param>
        /// <returns>Returns the previous code unit or null if there are no code units of the requested type.</returns>
        private static CodeUnit FindPreviousNonParent(CodeUnit codeUnit, MatchDelegate match)
        {
            Param.AssertNotNull(codeUnit, "codeUnit");
            Param.AssertNotNull(match, "match");

            CodeUnit item = codeUnit;
            bool itemIsParent = false;

            while (item != null)
            {
                if (item != codeUnit && !itemIsParent)
                {
                    if (match(item))
                    {
                        return item;
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
                        item = item.FindLastDescendent(match);
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
        /// <param name="match">The delegate used for matching the code unit.</param>
        /// <param name="root">The root ancenstor of the previous codeUnit.</param>
        /// <returns>Returns the previous code unit or null if there are no code units of the requested type.</returns>
        private static CodeUnit FindPreviousDescendentOf(CodeUnit codeUnit, MatchDelegate match, CodeUnit root)
        {
            Param.AssertNotNull(codeUnit, "codeUnit");
            Param.AssertNotNull(match, "match");
            Param.Ignore(root);

            CodeUnit item = codeUnit;
            while (item != null && item != root)
            {
                if (item != codeUnit)
                {
                    if (match(item))
                    {
                        return item;
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
                        item = item.FindLastDescendent(match);
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
        /// Gets the previous code unit of the given type which is a direct child of the given parent.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="match">The delegate used for matching the code unit.</param>
        /// <returns>Returns the previous code unit or null if there are no code units of the requested type.</returns>
        private static CodeUnit FindPreviousSibling(CodeUnit codeUnit, MatchDelegate match)
        {
            Param.AssertNotNull(codeUnit, "codeUnit");
            Param.AssertNotNull(match, "match");

            CodeUnit item = codeUnit.LinkNode.Previous;
            while (item != null)
            {
                if (match(item))
                {
                    return item;
                }

                item = item.LinkNode.Previous;
            }

            return null;
        }

        /// <summary>
        /// Gets the first code unit of the given type which is a descendent of this code unit or this code unit itself.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="match">The delegate used for matching the code unit.</param>
        /// <returns>Returns the first code unit or null if there are no code units of the requested type.</returns>
        private static CodeUnit FindFirst(CodeUnit codeUnit, MatchDelegate match)
        {
            Param.AssertNotNull(codeUnit, "codeUnit");
            Param.AssertNotNull(match, "match");

            CodeUnit item = codeUnit;
            while (item != null)
            {
                if (match(item))
                {
                    return item;
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
        /// Gets the first code unit of the given type which is a direct child of this code unit.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="match">The delegate used for matching the code unit.</param>
        /// <returns>Returns the first code unit or null if there are no code units of the requested type.</returns>
        private static CodeUnit FindFirstChild(CodeUnit codeUnit, MatchDelegate match)
        {
            Param.AssertNotNull(codeUnit, "codeUnit");
            Param.AssertNotNull(match, "match");

            CodeUnit item = codeUnit.Children.First;
            while (item != null)
            {
                if (match(item))
                {
                    return item;
                }

                item = item.LinkNode.Next;
            }

            return null;
        }

        /// <summary>
        /// Gets the first code unit of the given type which is a descendent of this code unit.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="match">The delegate used for matching the code unit.</param>
        /// <returns>Returns the first code unit or null if there are no code units of the requested type.</returns>
        private static CodeUnit FindFirstDescendent(CodeUnit codeUnit, MatchDelegate match)
        {
            Param.AssertNotNull(codeUnit, "codeUnit");
            Param.AssertNotNull(match, "match");

            return FindNextDescendentOf(codeUnit, match, codeUnit);
        }

        /// <summary>
        /// Gets the last code unit of the given type which is a descendent of this code unit or this code unit itself.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="match">The delegate used for matching the code unit.</param>
        /// <returns>Returns the last code unit or null if there are no code units of the requested type.</returns>
        private static CodeUnit FindLast(CodeUnit codeUnit, MatchDelegate match)
        {
            Param.AssertNotNull(codeUnit, "codeUnit");
            Param.AssertNotNull(match, "match");

            // Move to the very last item in the hierarchy.
            CodeUnit item = codeUnit;
            while (item != null && item.Children.Count > 0)
            {
                item = item.Children.Last;
            }

            // Check to see if the last descendent matches the filter.
            if (item != null)
            {
                if (match(item))
                {
                    return item;
                }

                // The very last item does not match, so find the previous descendent of this item that matches.
                return FindPrevious(item, match, codeUnit);
            }

            return null;
        }

        /// <summary>
        /// Gets the last code unit of the given type which is a direct child of this code unit.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="match">The delegate used for matching the code unit.</param>
        /// <returns>Returns the last code unit or null if there are no code units of the requested type.</returns>
        private static CodeUnit FindLastChild(CodeUnit codeUnit, MatchDelegate match)
        {
            Param.AssertNotNull(codeUnit, "codeUnit");
            Param.AssertNotNull(match, "match");

            CodeUnit item = codeUnit.Children.Last;
            while (item != null)
            {
                if (match(item))
                {
                    return item;
                }

                item = item.LinkNode.Previous;
            }

            return null;
        }

        /// <summary>
        /// Gets the last code unit of the given type which is a descendent of this code unit.
        /// </summary>
        /// <param name="codeUnit">The code unit.</param>
        /// <param name="match">The delegate used for matching the code unit.</param>
        /// <returns>Returns the last code unit or null if there are no code units of the requested type.</returns>
        private static CodeUnit FindLastDescendent(this CodeUnit codeUnit, MatchDelegate match)
        {
            Param.AssertNotNull(codeUnit, "codeUnit");
            Param.AssertNotNull(match, "match");

            // Move to the very last item in the hierarchy.
            CodeUnit item = codeUnit.Children.Last;
            while (item != null && item.Children.Count > 0)
            {
                item = item.Children.Last;
            }

            // Check to see if the last descendent matches the filter.
            if (item != null)
            {
                if (match(item))
                {
                    return item;
                }

                // The very last item does not match, so find the previous descendent of this item that matches.
                return FindPreviousDescendentOf(item, match, codeUnit);
            }

            return null;
        }

        #endregion Private Static Methods

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