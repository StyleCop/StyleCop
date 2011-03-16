//-----------------------------------------------------------------------
// <copyright file="QualifiedAliasExpression.cs">
//     MS-PL
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
    /// <summary>
    /// An expression representing a qualified alias operation.
    /// </summary>
    public sealed class QualifiedAliasExpression : ChildAccessExpression
    {
        /// <summary>
        /// Initializes a new instance of the QualifiedAliasExpression class.
        /// </summary>
        /// <param name="proxy">Proxy object for the expression.</param>
        /// <param name="leftHandSide">The left side of the operation.</param>
        /// <param name="rightHandSide">The member being accessed.</param>
        internal QualifiedAliasExpression(CodeUnitProxy proxy, Expression leftHandSide, LiteralExpression rightHandSide)
            : base(proxy, ExpressionType.QualifiedAlias, leftHandSide, rightHandSide)
        {
            Param.Ignore(proxy, leftHandSide, rightHandSide);
        }
    }
}
