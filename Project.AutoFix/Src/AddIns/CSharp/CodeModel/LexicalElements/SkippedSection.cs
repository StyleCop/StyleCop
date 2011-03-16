//-----------------------------------------------------------------------
// <copyright file="SkippedSection.cs">
//   MS-PL
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
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Text;

    /// <summary>
    /// A conditional section which is skipped, and not included in the code object model.
    /// </summary>
    /// <subcategory>token</subcategory>
    public sealed partial class SkippedSection : SimpleLexicalElement
    {
        /// <summary>
        /// Initializes a new instance of the SkippedSection class.
        /// </summary>
        /// <param name="document">The document that contains the section.</param>
        /// <param name="location">The location of the section.</param>
        /// <param name="generated">Indicates whether the section lies within a block of generated code.</param>
        /// <param name="contents">The contents of the section.</param>
        internal SkippedSection(CsDocument document, CodeLocation location, bool generated, string contents)
            : base(document, LexicalElementType.SkippedSection, location, generated)
        {
            Param.AssertNotNull(document, "document");
            Param.AssertNotNull(location, "location");
            Param.Ignore(generated);
            Param.AssertNotNull(contents, "contents");

            this.Text = contents;
        }
    }
}
