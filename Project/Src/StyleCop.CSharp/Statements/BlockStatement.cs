// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BlockStatement.cs" company="https://github.com/StyleCop">
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
//   A statement representing a new scope block.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    /// <summary>
    /// A statement representing a new scope block.
    /// </summary>
    /// <subcategory>statement</subcategory>
    public sealed class BlockStatement : Statement
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the BlockStatement class.
        /// </summary>
        internal BlockStatement()
            : base(StatementType.Block)
        {
        }

        #endregion
    }
}