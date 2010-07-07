//-----------------------------------------------------------------------
// <copyright file="CodeWalker.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
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
namespace Microsoft.StyleCop.CSharp
{
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Delegate for a callback executed when a code unit is visited.
    /// </summary>
    /// <param name="codeUnit">The code unit being visited.</param>
    /// <param name="parentElement">The parent element, if any.</param>
    /// <param name="parentStatement">The parent statement, if any.</param>
    /// <param name="parentExpression">The parent expression, if any.</param>
    /// <param name="parentClause">The parent query clause, if any.</param>
    /// <param name="parentToken">The parent token, if any.</param>
    /// <param name="context">The optional visitor context data.</param>
    /// <returns>Returns true to continue, or false to stop the walker.</returns>
    /// <typeparam name="T">The type of the visitor context data.</typeparam>
    public delegate bool CodeUnitVisitor<T>(
        CodeUnit codeUnit, 
        Element parentElement, 
        Statement parentStatement,
        Expression parentExpression,
        QueryClause parentClause,
        Token parentToken,
        T context);

    /// <summary>
    /// Walks through the code object model.
    /// </summary>
    /// <typeparam name="T">The type of the visitor context data.</typeparam>
    internal static class CodeWalker<T>
    {
        #region Public Static Methods

        /// <summary>
        /// Creates and starts a code walker.
        /// </summary>
        /// <param name="document">The document to walk through.</param>
        /// <param name="callback">Callback executed when a code unit is visited.</param>
        /// <param name="context">The optional visitor context data.</param>
        /// <param name="codeUnitTypes">The types of code units to visit.</param>
        public static void Start(CsDocument document, CodeUnitVisitor<T> callback, T context, params CodeUnitType[] codeUnitTypes)
        {
            Param.AssertNotNull(document, "document");
            Param.AssertNotNull(callback, "callback");
            Param.Ignore(context);
            Param.Ignore(codeUnitTypes);

            if (document.RootElement != null)
            {
                WalkCodeUnit(document.RootElement, callback, context, codeUnitTypes);
            }
        }

        /// <summary>
        /// Creates and starts a code walker.
        /// </summary>
        /// <param name="root">The root code unit to walk through.</param>
        /// <param name="callback">Callback executed when a code unit is visited.</param>
        /// <param name="context">The optional visitor context data.</param>
        /// <param name="codeUnitTypes">The types of code units to visit.</param>
        public static void Start(CodeUnit root, CodeUnitVisitor<T> callback, T context, params CodeUnitType[] codeUnitTypes)
        {
            Param.AssertNotNull(root, "root");
            Param.AssertNotNull(callback, "callback");
            Param.Ignore(context);
            Param.Ignore(codeUnitTypes);

            WalkCodeUnit(root, callback, context, codeUnitTypes);
        }

        #endregion Public Static Methods

        #region Private Static Methods

        /// <summary>
        /// Visits the given code unit and walks through its children.
        /// </summary>
        /// <param name="codeUnit">The code unit to walk.</param>
        /// <param name="callback">Callback executed when a code unit is visited.</param>
        /// <param name="context">Optional context.</param>
        /// <param name="codeUnitTypes">The types of code units to visit.</param>
        /// <returns>Returns true to continue walking, false otherwise.</returns>
        private static bool WalkCodeUnit(CodeUnit codeUnit, CodeUnitVisitor<T> callback, T context, CodeUnitType[] codeUnitTypes)
        {
            Param.AssertNotNull(codeUnit, "codeUnit");
            Param.AssertNotNull(callback, "callback");
            Param.Ignore(context);
            Param.Ignore(codeUnitTypes);

            // Gather up the various parent types for this code unit.
            Element parentElement = null;
            Statement parentStatement = null;
            Expression parentExpression = null;
            QueryClause parentQueryClause = null;
            Token parentToken = null;

            CodeUnit parent = codeUnit.Parent;
            while (parent != null)
            {
                switch (parent.CodeUnitType)
                {
                    case CodeUnitType.Element:
                        if (parentElement != null)
                        {
                            parentElement = (Element)parent;

                            // Elements are the top-level code units, so we can stop now.
                            parent = null;
                        }
                        
                        break;

                    case CodeUnitType.Statement:
                        if (parentStatement != null)
                        {
                            parentStatement = (Statement)parent;
                        }

                        break;

                    case CodeUnitType.Expression:
                        if (parentExpression != null)
                        {
                            parentExpression = (Expression)parent;
                        }

                        break;

                    case CodeUnitType.QueryClause:
                        if (parentQueryClause != null)
                        {
                            parentQueryClause = (QueryClause)parent;
                        }

                        break;

                    case CodeUnitType.LexicalElement:
                        if (parentToken != null)
                        {
                            parentToken = (Token)parent;
                        }

                        break;
                }

                parent = parent == null ? null : parent.Parent;
            }

            return WalkCodeUnit(codeUnit, callback, parentElement, parentStatement, parentExpression, parentQueryClause, parentToken, context, codeUnitTypes);
        }

        /// <summary>
        /// Visits the given code unit and walks through its children.
        /// </summary>
        /// <param name="codeUnit">The code unit to walk.</param>
        /// <param name="callback">Callback executed when a code unit is visited.</param>
        /// <param name="parentElement">The parent element of the code unit, if any.</param>
        /// <param name="parentStatement">The parent statement of the code unit, if any.</param>
        /// <param name="parentExpression">The parent expression of the code unit, if any.</param>
        /// <param name="parentQueryClause">The parent query clause of the code unit, if any.</param>
        /// <param name="parentToken">The parent token of the code unit, if any.</param>
        /// <param name="context">Optional context.</param>
        /// <param name="codeUnitTypes">The types of code units to visit.</param>
        /// <returns>Returns true to continue walking, false otherwise.</returns>
        private static bool WalkCodeUnit(
            CodeUnit codeUnit,
            CodeUnitVisitor<T> callback,
            Element parentElement,
            Statement parentStatement,
            Expression parentExpression,
            QueryClause parentQueryClause,
            Token parentToken,
            T context,
            CodeUnitType[] codeUnitTypes)
        {
            Param.AssertNotNull(codeUnit, "codeUnit");
            Param.AssertNotNull(callback, "callback");
            Param.Ignore(parentElement);
            Param.Ignore(parentStatement);
            Param.Ignore(parentExpression);
            Param.Ignore(parentQueryClause);
            Param.Ignore(parentToken);
            Param.Ignore(context);
            Param.Ignore(codeUnitTypes);

            if (CompareCodeUnitType(codeUnitTypes, codeUnit.CodeUnitType))
            {
                if (!callback(codeUnit, parentElement, parentStatement, parentExpression, parentQueryClause, parentToken, context))
                {
                    return false;
                }
            }

            if (codeUnit.Children != null && codeUnit.Children.Count > 0)
            {
                switch (codeUnit.CodeUnitType)
                {
                    case CodeUnitType.Element:
                        parentElement = (Element)codeUnit;
                        break;

                    case CodeUnitType.Statement:
                        parentStatement = (Statement)codeUnit;
                        break;

                    case CodeUnitType.Expression:
                        parentExpression = (Expression)codeUnit;
                        break;

                    case CodeUnitType.QueryClause:
                        parentQueryClause = (QueryClause)codeUnit;
                        break;

                    case CodeUnitType.LexicalElement:
                        if (codeUnit.Is(LexicalElementType.Token))
                        {
                            parentToken = (Token)codeUnit;
                        }

                        break;
                }

                return WalkCodeUnitChildren(codeUnit, callback, parentElement, parentStatement, parentExpression, parentQueryClause, parentToken, context, codeUnitTypes);
            }

            return true;
        }

        /// <summary>
        /// Walks through the children of the given code unit.
        /// </summary>
        /// <param name="codeUnit">The code unit to walk.</param>
        /// <param name="callback">Callback executed when a code unit is visited.</param>
        /// <param name="parentElement">The parent element of the code unit, if any.</param>
        /// <param name="parentStatement">The parent statement of the code unit, if any.</param>
        /// <param name="parentExpression">The parent expression of the code unit, if any.</param>
        /// <param name="parentQueryClause">The parent query clause of the code unit, if any.</param>
        /// <param name="parentToken">The parent token of the code unit, if any.</param>
        /// <param name="context">Optional context.</param>
        /// <param name="codeUnitTypes">The types of code units to visit.</param>
        /// <returns>Returns true to continue walking, false otherwise.</returns>
        private static bool WalkCodeUnitChildren(
            CodeUnit codeUnit,
            CodeUnitVisitor<T> callback,
            Element parentElement,
            Statement parentStatement,
            Expression parentExpression,
            QueryClause parentQueryClause,
            Token parentToken,
            T context,
            CodeUnitType[] codeUnitTypes)
        {
            Param.AssertNotNull(codeUnit, "codeUnit");
            Param.Ignore(codeUnitTypes);
            Param.AssertNotNull(callback, "callback");
            Param.Ignore(parentElement);
            Param.Ignore(parentStatement);
            Param.Ignore(parentExpression);
            Param.Ignore(parentQueryClause);
            Param.Ignore(parentToken);
            Param.Ignore(context);

            if (codeUnit.Children != null && codeUnit.Children.Count > 0)
            {
                for (CodeUnit child = codeUnit.FindFirstChild<CodeUnit>(); child != null; child = child.FindNextSibling<CodeUnit>())
                {
                    if (!WalkCodeUnit(child, callback, parentElement, parentStatement, parentExpression, parentQueryClause, parentToken, context, codeUnitTypes))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Determines whether the given code unit type is present within the array of types.
        /// </summary>
        /// <param name="codeUnitTypes">The array of types.</param>
        /// <param name="itemType">The type to search for.</param>
        /// <returns>Returns true if the type is present within the array; otherwise false.</returns>
        private static bool CompareCodeUnitType(CodeUnitType[] codeUnitTypes, CodeUnitType itemType)
        {
            Param.Ignore(codeUnitTypes);
            Param.Ignore(itemType);

            if (codeUnitTypes == null || codeUnitTypes.Length == 0)
            {
                return true;
            }

            for (int i = 0; i < codeUnitTypes.Length; ++i)
            {
                if (codeUnitTypes[i] == itemType)
                {
                    return true;
                }
            }

            return false;
        }

        #endregion Private Static Methods
    }
}
