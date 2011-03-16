//-----------------------------------------------------------------------
// <copyright file="PrefixDecrementExpression.cs">
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
    /// An expression representing a prefixed decrement operation.
    /// </summary>
    public sealed class PrefixDecrementExpression : DecrementExpression
    {
        /// <summary>
        /// Initializes a new instance of the PrefixDecrementExpression class.
        /// </summary>
        /// <param name="proxy">Proxy object for the expression.</param>
        /// <param name="value">The value being incremented.</param>
        internal PrefixDecrementExpression(CodeUnitProxy proxy, Expression value)
            : base(proxy, value, DecrementExpressionType.Prefix)
        {
            Param.Ignore(proxy, value);
        }
    }
}
