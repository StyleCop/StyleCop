//-----------------------------------------------------------------------
// <copyright file="LineDirective.cs">
//     MS-PL
// </copyright>
// <license>
//   This source code is subject to terms and conditions of the Microsoft 
//   Public License. A copy of the license can be found in the License.html 
//   file at the root of this distribution. 
//   By using this source code in any fashion, you are agreeing to be bound 
//   by the terms of the Microsoft Public License. You must not remove this 
//   notice, or any other, from this software.
// </license>
//-----------------------------------------------------------------------
namespace StyleCop.CSharp.CodeModel
{
    using System;

    /// <summary>
    /// Describes a line directive.
    /// </summary>
    /// <subcategory>preprocessor</subcategory>
    public sealed class LineDirective : SimplePreprocessorDirective
    {
        /// <summary>
        /// Initializes a new instance of the LineDirective class.
        /// </summary>
        /// <param name="document">The parent document.</param>
        /// <param name="text">The text within the directive.</param>
        /// <param name="location">The location of the preprocessor directive in the code.</param>
        /// <param name="generated">Indicates whether the item is generated.</param>
        internal LineDirective(CsDocument document, string text, CodeLocation location, bool generated)
            : base(document, text, PreprocessorType.Line, location, generated)
        {
            Param.AssertNotNull(document, "document");
            Param.Ignore(text, location, generated);
        }
    }
}
