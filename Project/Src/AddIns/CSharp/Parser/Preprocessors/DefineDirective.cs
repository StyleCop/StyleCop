//-----------------------------------------------------------------------
// <copyright file="DefineDirective.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
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
    /// Describes a define directive.
    /// </summary>
    /// <subcategory>preprocessor</subcategory>
    public sealed class DefineDirective : PreprocessorDirective
    {
        /// <summary>
        /// Initializes a new instance of the DefineDirective class.
        /// </summary>
        /// <param name="text">The text within the directive.</param>
        /// <param name="location">The location of the preprocessor directive in the code.</param>
        /// <param name="generated">Indicates whether the item is generated.</param>
        internal DefineDirective(string text, CodeLocation location, bool generated)
            : base(text, PreprocessorType.Define, location, generated)
        {
            Param.Ignore(text, location, generated);
        }
    }
}
