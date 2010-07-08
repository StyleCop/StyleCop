//-----------------------------------------------------------------------
// <copyright file="QualifiedAliasOperator.cs" company="Microsoft">
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

    /// <summary>
    /// Describes a qualified alias operator symbol.
    /// </summary>
    /// <subcategory>token</subcategory>
    public sealed class QualifiedAliasOperator : OperatorSymbolToken
    {
        /// <summary>
        /// Initializes a new instance of the QualifiedAliasOperator class.
        /// </summary>
        /// <param name="text">The text of the item.</param>
        /// <param name="location">The location of the item.</param>
        /// <param name="generated">Indicates whether the item is generated.</param>
        internal QualifiedAliasOperator(string text, CodeLocation location, bool generated)
            : base(text, OperatorCategory.Reference, OperatorType.QualifiedAlias, location, generated)
        {
            Param.AssertValidString(text, "text");
            Param.AssertNotNull(location, "location");
            Param.Ignore(generated);
        }
    }
}
