// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICodePartExtensions.cs" company="https://github.com/StyleCop">
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
//   Extension methods for the ICodePart class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    /// <summary>
    /// Extension methods for the ICodePart class.
    /// </summary>
    public static class ICodePartExtensions
    {
        #region Public Methods and Operators

        /// <summary>
        /// Gets the element that contains this code unit, if there is one.
        /// </summary>
        /// <param name="part">
        /// The code part.
        /// </param>
        /// <returns>
        /// Returns the element or null if there is no parent expression.
        /// </returns>
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
        /// Gets the expression that contains this code part, if there is one.
        /// </summary>
        /// <param name="part">
        /// The code part.
        /// </param>
        /// <returns>
        /// Returns the expression or null if there is no parent expression.
        /// </returns>
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

        /// <summary>
        /// Gets the statement that contains this code unit, if there is one.
        /// </summary>
        /// <param name="part">
        /// The code part.
        /// </param>
        /// <returns>
        /// Returns the statement or null if there is no parent expression.
        /// </returns>
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

        #endregion
    }
}