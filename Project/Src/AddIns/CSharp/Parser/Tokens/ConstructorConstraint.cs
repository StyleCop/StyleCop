//-----------------------------------------------------------------------
// <copyright file="ConstructorConstraint.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.
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
//-----------------------------------------------------------------------
namespace Microsoft.StyleCop.CSharp
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// A token describing a constructor constraint.
    /// </summary>
    /// <subcategory>token</subcategory>
    public sealed class ConstructorConstraint : ComplexToken
    {
        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the ConstructorConstraint class.
        /// </summary>
        /// <param name="proxy">The proxy object.</param>
        /// <param name="location">The location of the token in the code.</param>
        /// <param name="generated">True if the token is inside of a block of generated code.</param>
        internal ConstructorConstraint(CodeUnitProxy proxy, CodeLocation location, bool generated)
            : base(proxy, TokenType.ConstructorConstraint, location, generated)
        {
            Param.AssertNotNull(proxy, "proxy");
            Param.AssertNotNull(location, "location");
            Param.Ignore(generated);
        }

        #endregion Internal Constructors
    }
}
