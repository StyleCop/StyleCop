//-----------------------------------------------------------------------
// <copyright file="ContinueStatement.cs">
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
    using System;

    /// <summary>
    /// A continue-statement.
    /// </summary>
    /// <subcategory>statement</subcategory>
    public sealed class ContinueStatement : Statement
    {
        /// <summary>
        /// Initializes a new instance of the ContinueStatement class.
        /// </summary>
        /// <param name="proxy">Proxy object for the statement.</param>
        internal ContinueStatement(CodeUnitProxy proxy)
            : base(proxy, StatementType.Continue)
        {
            Param.AssertNotNull(proxy, "proxy");
        }
    }
}
