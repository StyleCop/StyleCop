//-----------------------------------------------------------------------
// <copyright file="MultiLineComment.cs">
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
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Describes a C++ style comment.
    /// </summary>
    /// <subcategory>token</subcategory>
    [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "MultilineComment", Justification = "Suggested casing is poor.")]
    public sealed class MultilineComment : Comment
    {
        /// <summary>
        /// Initializes a new instance of the MultilineComment class.
        /// </summary>
        /// <param name="document">The parent document.</param>
        /// <param name="text">The text of the item.</param>
        internal MultilineComment(CsDocument document, string text)
            : base(document, text, CommentType.MultilineComment)
        {
            Param.AssertNotNull(document, "document");
            Param.AssertValidString(text, "text");
        }

        /// <summary>
        /// Initializes a new instance of the MultilineComment class.
        /// </summary>
        /// <param name="document">The parent document.</param>
        /// <param name="text">The text of the item.</param>
        /// <param name="location">The location of the item.</param>
        /// <param name="generated">Indicates whether the item is generated.</param>
        internal MultilineComment(CsDocument document, string text, CodeLocation location, bool generated)
            : base(document, text, CommentType.MultilineComment, location, generated)
        {
            Param.AssertNotNull(document, "document");
            Param.AssertValidString(text, "text");
            Param.AssertNotNull(location, "location");
            Param.Ignore(generated);
        }
    }
}
