//-----------------------------------------------------------------------
// <copyright file="ReadabilityRules.Comments.cs">
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
namespace StyleCop.CSharp.Rules
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using StyleCop;
    using StyleCop.CSharp.CodeModel;

    /// <content>
    /// Checks rules related to comments.
    /// </content>
    public partial class ReadabilityRules
    {
        #region Private Methods

        /// <summary>
        /// Looks for empty comments.
        /// </summary>
        /// <param name="comment">The comment to check.</param>
        /// <param name="parentElement">The parent element.</param>
        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Minimizing refactoring before release.")]
        private void CheckForEmptyComments(Comment comment, Element parentElement)
        {
            Param.AssertNotNull(comment, "comment");
            Param.AssertNotNull(parentElement, "parentElement");

            // Skip generated code.
            if (!comment.Generated)
            {
                // Check for the two comment types.
                if (comment.CommentType == CommentType.SingleLineComment)
                {
                    this.CheckSingleLineComment(comment, parentElement);
                }
                else if (comment.CommentType == CommentType.MultilineComment)
                {
                    this.CheckMultilineComment(comment, parentElement);
                }
            }
        }

        /// <summary>
        /// Checks a single-line comment to see if it is empty.
        /// </summary>
        /// <param name="comment">The comment.</param>
        /// <param name="parentElement">The parent element.</param>
        private void CheckSingleLineComment(Comment comment, Element parentElement)
        {
            Param.AssertNotNull(comment, "comment");
            Param.AssertNotNull(parentElement, "parentElement");

            // This is a single line comment.
            int slashCount = 0;
            bool found = false;

            // Loop through the characters in the comment text.
            for (int character = 0; character < comment.Text.Length; ++character)
            {
                // See if we've found the slashes at the beginning of the comment
                if (slashCount == 2)
                {
                    // Check whether there's anything here other than whitespace.
                    // If so, then this comment is ok.
                    if (comment.Text[character] != ' ' &&
                        comment.Text[character] != '\t' &&
                        comment.Text[character] != '\r' &&
                        comment.Text[character] != '\n')
                    {
                        found = true;
                        break;
                    }
                }
                else if (comment.Text[character] == '/')
                {
                    ++slashCount;
                }
            }

            // Check whether the comment contained any text.
            if (!found)
            {
                // This is only allowed if this comment is sandwiched in between two other comments.
                bool isComment = false;
                int lines = 0;
                for (LexicalElement item = comment.FindPreviousLexicalElement(); item != null; item = item.FindPreviousLexicalElement())
                {
                    if (item.Text == "\n")
                    {
                        ++lines;
                        if (lines > 1)
                        {
                            break;
                        }
                    }
                    else if (item.Is(CommentType.SingleLineComment))
                    {
                        isComment = true;
                        break;
                    }
                    else if (item.LexicalElementType != LexicalElementType.WhiteSpace)
                    {
                        break;
                    }
                }

                if (!isComment)
                {
                    this.AddViolation(parentElement, comment.LineNumber, Rules.CommentsMustContainText);
                }
                else
                {
                    isComment = false;
                    lines = 0;
                    for (LexicalElement item = comment.FindNextLexicalElement(); item != null; item = item.FindNextLexicalElement())
                    {
                        if (item.Text == "\n")
                        {
                            ++lines;
                            if (lines > 1)
                            {
                                break;
                            }
                        }
                        else if (item.Is(CommentType.SingleLineComment))
                        {
                            isComment = true;
                            break;
                        }
                        else if (item.LexicalElementType != LexicalElementType.WhiteSpace)
                        {
                            break;
                        }
                    }

                    if (!isComment)
                    {
                        this.AddViolation(parentElement, comment.LineNumber, Rules.CommentsMustContainText);
                    }
                }
            }
        }

        /// <summary>
        /// Checks a single-line comment to see if it is empty.
        /// </summary>
        /// <param name="comment">The comment.</param>
        /// <param name="parentElement">The parent element.</param>
        private void CheckMultilineComment(Comment comment, Element parentElement)
        {
            Param.AssertNotNull(comment, "comment");
            Param.AssertNotNull(parentElement, "parentElement");

            // The is a multi-line comment. Get the start of the comment.
            int start = comment.Text.IndexOf("/*", StringComparison.Ordinal);
            if (start > -1)
            {
                // Get the end of the comment
                int end = comment.Text.IndexOf("*/", start + 2, StringComparison.Ordinal);
                if (end > -1)
                {
                    // Look at the characters between the start and the end and see if there
                    // is anything here besides whitespace.
                    bool found = false;
                    for (int character = start + 2; character < end; ++character)
                    {
                        if (comment.Text[character] != ' ' &&
                            comment.Text[character] != '\t' &&
                            comment.Text[character] != '\r' &&
                            comment.Text[character] != '\n')
                        {
                            found = true;
                            break;
                        }
                    }

                    // Check whether the comment contained any text.
                    if (!found)
                    {
                        this.AddViolation(parentElement, comment.LineNumber, Rules.CommentsMustContainText);
                    }
                }
            }
        }

        #endregion Private Methods
    }
}
