// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SwitchDefaultStatement.cs" company="https://github.com/StyleCop">
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
//   A default-statement within a switch-statement.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    /// <summary>
    /// A default-statement within a switch-statement.
    /// </summary>
    /// <subcategory>statement</subcategory>
    public sealed class SwitchDefaultStatement : Statement
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the SwitchDefaultStatement class.
        /// </summary>
        internal SwitchDefaultStatement()
            : base(StatementType.SwitchDefault)
        {
        }

        #endregion
    }
}