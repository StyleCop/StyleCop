// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NameofExpression.cs" company="https://github.com/StyleCop">
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
//   An expression representing a nameof operation.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    /// <summary>
    /// An expression representing a nameof operation.
    /// </summary>
    /// <subcategory>expression</subcategory>
    public sealed class NameofExpression : Expression
    {
        /// <summary>
        /// Initializes a new instance of the NameofExpression class.
        /// </summary>
        /// <param name="tokens">
        /// The list of tokens that form the expression.
        /// </param>
        /// <param name="name">
        /// The type literal to get the name of.
        /// </param>
        internal NameofExpression(CsTokenList tokens, Expression name)
            : base(ExpressionType.NameOf, tokens)
        {
            Param.AssertNotNull(tokens, "tokens");
            Param.AssertNotNull(name, "name");
            
            this.AddExpression(name);
        }
    }
}