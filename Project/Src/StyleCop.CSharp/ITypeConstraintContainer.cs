// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ITypeConstraintContainer.cs" company="https://github.com/StyleCop">
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
//   Implemented by elements containing a list of type constraints.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    using System.Collections.Generic;

    /// <summary>
    /// Implemented by elements containing a list of type constraints.
    /// </summary>
    /// <subcategory>interface</subcategory>
    public interface ITypeConstraintContainer
    {
        #region Public Properties

        /// <summary>
        /// Gets the list of type constraints in the container.
        /// </summary>
        ICollection<TypeParameterConstraintClause> TypeConstraints { get; }

        #endregion
    }
}