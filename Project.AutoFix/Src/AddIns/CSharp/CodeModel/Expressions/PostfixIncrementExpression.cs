//-----------------------------------------------------------------------
// <copyright file="PostfixIncrementExpression.cs">
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
    /// An expression representing a postfixed increment operation.
    /// </summary>
    public sealed class PostfixIncrementExpression : IncrementExpression
    {
        /// <summary>
        /// Initializes a new instance of the PostfixIncrementExpression class.
        /// </summary>
        /// <param name="proxy">Proxy object for the expression.</param>
        /// <param name="value">The value being incremented.</param>
        internal PostfixIncrementExpression(CodeUnitProxy proxy, Expression value)
            : base(proxy, value, IncrementExpressionType.Postfix)
        {
            Param.Ignore(proxy, value);
        }
    }
}
