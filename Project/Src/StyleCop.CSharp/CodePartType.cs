// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CodePartType.cs" company="https://github.com/StyleCop">
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
//   The various types of code units.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
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
}