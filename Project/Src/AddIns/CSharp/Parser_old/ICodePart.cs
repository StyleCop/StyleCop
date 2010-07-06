//-----------------------------------------------------------------------
// <copyright file="ICodePart.cs" company="Microsoft">
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

    /// <summary>
    /// The various types of code units.
    /// </summary>
    public enum CodePartType
    {
        /// <summary>
        /// A simple token.
        /// </summary>
        Token,

        /// <summary>
        /// An element.
        /// </summary>
        Element,

        /// <summary>
        /// A statement.
        /// </summary>
        Statement,

        /// <summary>
        /// An expression.
        /// </summary>
        Expression,

        /// <summary>
        /// A query clause.
        /// </summary>
        QueryClause,

        /// <summary>
        /// A type constraint clause.
        /// </summary>
        ConstraintClause,

        /// <summary>
        /// A method call argument.
        /// </summary>
        Argument,

        /// <summary>
        /// A method parameter.
        /// </summary>
        Parameter,

        /// <summary>
        /// A variable declaration.
        /// </summary>
        Variable,

        /// <summary>
        /// A file header.
        /// </summary>
        FileHeader,

        /// <summary>
        /// A code document.
        /// </summary>
        Document
    }

    /// <summary>
    /// An interface implemented by types that describe a code part.
    /// </summary>
    public interface ICodePart
    {
        /// <summary>
        /// Gets the type of the code part.
        /// </summary>
        CodePartType CodePartType
        {
            get;
        }

        /// <summary>
        /// Gets the location of this code unit within the document.
        /// </summary>
        CodeLocation Location
        {
            get;
        }

        /// <summary>
        /// Gets the line number that this code unit appears on in the document.
        /// </summary>
        int LineNumber
        {
            get;
        }

        /// <summary>
        /// Gets the parent of this code part.
        /// </summary>
        ICodePart Parent
        {
            get;
        }
    }

    /// <summary>
    /// Extension methods for the ICodePart class.
    /// </summary>
    public static class ICodePartExtensions
    {
        /// <summary>
        /// Gets the element that contains this code unit, if there is one.
        /// </summary>
        /// <param name="part">The code part.</param>
        /// <returns>Returns the element or null if there is no parent expression.</returns>
        public static CsElement FindParentElement(this ICodePart part)
        {
            Param.RequireNotNull(part, "part");

            ICodePart parentCodePart = part.Parent;
            while (parentCodePart != null)
            {
                if (parentCodePart.CodePartType == CodePartType.Element)
                {
                    return (CsElement)parentCodePart;
                }

                parentCodePart = parentCodePart.Parent;
            }

            return null;
        }

        /// <summary>
        /// Gets the statement that contains this code unit, if there is one.
        /// </summary>
        /// <param name="part">The code part.</param>
        /// <returns>Returns the statement or null if there is no parent expression.</returns>
        public static Statement FindParentStatement(this ICodePart part)
        {
            Param.RequireNotNull(part, "part");

            ICodePart parentCodeUnit = part.Parent;
            while (parentCodeUnit != null)
            {
                if (parentCodeUnit.CodePartType == CodePartType.Statement)
                {
                    return (Statement)parentCodeUnit;
                }

                // If we hit an element, then there is no parent statement.
                if (parentCodeUnit.CodePartType == CodePartType.Element)
                {
                    return null;
                }

                parentCodeUnit = parentCodeUnit.Parent;
            }

            return null;
        }

        /// <summary>
        /// Gets the expression that contains this code part, if there is one.
        /// </summary>
        /// <param name="part">The code part.</param>
        /// <returns>Returns the expression or null if there is no parent expression.</returns>
        public static Expression FindParentExpression(this ICodePart part)
        {
            Param.RequireNotNull(part, "part");

            ICodePart parentCodeUnit = part.Parent;
            while (parentCodeUnit != null)
            {
                if (parentCodeUnit.CodePartType == CodePartType.Expression)
                {
                    return (Expression)parentCodeUnit;
                }

                // If we hit an element, then there is no parent statement.
                if (parentCodeUnit.CodePartType == CodePartType.Element)
                {
                    return null;
                }

                parentCodeUnit = parentCodeUnit.Parent;
            }

            return null;
        }
    }
}
