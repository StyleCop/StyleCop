//-----------------------------------------------------------------------
// <copyright file="DereferenceExpression.cs">
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
    /// An expression representing an unsafe address-of operation.
    /// </summary>
    public sealed class DereferenceExpression : UnsafeAccessExpression
    {
        /// <summary>
        /// Initializes a new instance of the DereferenceExpression class.
        /// </summary>
        /// <param name="proxy">Proxy object for the expression.</param>
        /// <param name="value">The value the operator is being applied to.</param>
        internal DereferenceExpression(CodeUnitProxy proxy, Expression value)
            : base(proxy, UnsafeAccessExpressionType.Dereference, value)
        {
            Param.Ignore(proxy, value);
        }
    }
}
