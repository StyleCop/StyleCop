// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICodeUnit.cs" company="https://github.com/StyleCop">
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
//   An interface implemented by types that describe a unit of code.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    using System.Collections.Generic;

    /// <summary>
    /// An interface implemented by types that describe a unit of code.
    /// </summary>
    public interface ICodeUnit : ICodePart
    {
        #region Public Properties

        /// <summary>
        /// Gets the collection of expressions beneath this code unit.
        /// </summary>
        ICollection<Expression> ChildExpressions { get; }

        /// <summary>
        /// Gets the collection of statements beneath this code unit.
        /// </summary>
        ICollection<Statement> ChildStatements { get; }

        /// <summary>
        /// Gets the friendly name of the code unit type as a plural noun, which can be used in user output.
        /// </summary>
        string FriendlyPluralTypeText { get; }

        /// <summary>
        /// Gets the friendly name of the code unit type, which can be used in user output.
        /// </summary>
        string FriendlyTypeText { get; }

        /// <summary>
        /// Gets the list of tokens within this code unit.
        /// </summary>
        CsTokenList Tokens { get; }

        /// <summary>
        /// Gets the list of variables and constants defined by this code unit.
        /// </summary>
        VariableCollection Variables { get; }

        #endregion
    }
}