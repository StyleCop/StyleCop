//-----------------------------------------------------------------------
// <copyright file="ICodeUnit.cs" company="Microsoft">
//   Copyright (c) Microsoft Corporation.
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
    using System.Diagnostics.CodeAnalysis;
    using System.Text;

    /// <summary>
    /// Describes an argument list within a method call.
    /// </summary>
    /// <subcategory>codeunit</subcategory>
    public sealed class ArgumentList : CodeUnit
    {
        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the ArgumentList class.
        /// </summary>
        /// <param name="proxy">The proxy class.</param>
        internal ArgumentList(CodeUnitProxy proxy)
            : base(proxy, CodeUnitType.ArgumentList)
        {
            Param.AssertNotNull(proxy, "proxy");
        }

        #endregion Internal Constructors
    }
}
