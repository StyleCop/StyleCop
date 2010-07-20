//-----------------------------------------------------------------------
// <copyright file="ElifDirective.cs" company="Microsoft">
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
namespace Microsoft.StyleCop.CSharp.CodeModel
{
    using System;

    /// <summary>
    /// Describes an elif directive.
    /// </summary>
    /// <subcategory>preprocessor</subcategory>
    public sealed class ElifDirective : ConditionalCompilationDirective
    {
        /// <summary>
        /// Initializes a new instance of the ElifDirective class.
        /// </summary>
        /// <param name="text">The text within the directive.</param>
        /// <param name="proxy">The proxy.</param>
        /// <param name="body">The body expression.</param>
        internal ElifDirective(string text, CodeUnitProxy proxy, Expression body)
            : base(text, proxy, PreprocessorType.Elif, body)
        {
            Param.Ignore(text, proxy, body);
        }
    }
}
