// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OperatorCategory.cs" company="https://github.com/StyleCop">
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
//   The various categories of operators.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    /// <summary>
    /// The various categories of operators.
    /// </summary>
    /// <subcategory>token</subcategory>
    public enum OperatorCategory
    {
        /// <summary>
        /// A relational symbol: '==', '!=', etc.
        /// </summary>
        Relational, 

        /// <summary>
        /// A logical symbol: '||', '|', etc.
        /// </summary>
        Logical, 

        /// <summary>
        /// Assignment symbols: '=', '+=', etc. 
        /// </summary>
        Assignment, 

        /// <summary>
        /// Arithmetic symbol: '+', '-', '*', '/', etc.
        /// </summary>
        Arithmetic, 

        /// <summary>
        /// Shift operators.
        /// </summary>
        Shift, 

        /// <summary>
        /// A conditional colon or question mark.
        /// </summary>
        Conditional, 

        /// <summary>
        /// An increment or decrement symbol.
        /// </summary>
        IncrementDecrement, 

        /// <summary>
        /// A unary operation: '!', '~', '+', '-'.
        /// </summary>
        Unary, 

        /// <summary>
        /// A pointer, address-of, or dereference symbol.
        /// </summary>
        Reference, 

        /// <summary>
        /// A lambda operator.
        /// </summary>
        Lambda
    }
}