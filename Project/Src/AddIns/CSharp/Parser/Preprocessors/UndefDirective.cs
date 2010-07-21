//-----------------------------------------------------------------------
// <copyright file="UndefDirective.cs" company="Microsoft">
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
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Describes an undef directive.
    /// </summary>
    /// <subcategory>preprocessor</subcategory>
    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Undef", Justification = "Matches the C# undef directive.")]
    public sealed class UndefDirective : PreprocessorDirective
    {
        /// <summary>
        /// Initializes a new instance of the UndefDirective class.
        /// </summary>
        /// <param name="document">The parent document.</param>
        /// <param name="text">The text within the directive.</param>
        /// <param name="location">The location of the preprocessor directive in the code.</param>
        /// <param name="generated">Indicates whether the item is generated.</param>
        internal UndefDirective(CsDocument document, string text, CodeLocation location, bool generated)
            : base(document, text, PreprocessorType.Undef, location, generated)
        {
            Param.AssertNotNull(document, "document");
            Param.Ignore(text, location, generated);
        }
    }
}
