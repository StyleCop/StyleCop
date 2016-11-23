// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReadabilityRules.Comments.cs" company="https://github.com/StyleCop">
//   MS-PL
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
// <summary>
//   The readability rules.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// The readability rules.
    /// </summary>
    /// <content>
    /// Checks rules related to comments.
    /// </content>
    public partial class ReadabilityRules
    {
        #region Methods

        /// <summary>
        /// Looks for empty comments.
        /// </summary>
        /// <param name="element">
        /// The element to process.
        /// </param>
        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Minimizing refactoring before release.")]
        private void CheckForEmptyComments(DocumentRoot element)
        {
            Param.AssertNotNull(element, "element");

            // Loop through all the tokens in the file looking for comments.
            for (Node<CsToken> tokenNode = element.Tokens.First; !element.Tokens.OutOfBounds(tokenNode); tokenNode = tokenNode.Next)
            {
                if (this.Cancel)
                {
                    break;
                }

                CsToken token = tokenNode.Value;

                // Skip generated code.
                if (!token.Generated)
                {
                    // Check for the two comment types.
                    if (token.CsTokenType == CsTokenType.SingleLineComment)
                    {
                        // This is a single line comment.
                        int slashCount = 0;
                        bool found = false;

                        // Loop through the characters in the comment text.
                        for (int character = 0; character < token.Text.Length; ++character)
                        {
                            // See if we've found the slashes at the beginning of the comment
                            if (slashCount == 2)
                            {
                                // Check whether there's anything here other than whitespace.
                                // If so, then this comment is ok.
                                if (token.Text[character] != ' ' && token.Text[character] != '\t' && token.Text[character] != '\r' && token.Text[character] != '\n')
                                {
                                    found = true;
                                    break;
                                }
                            }
                            else if (token.Text[character] == '/')
                            {
                                ++slashCount;
                            }
                        }

                        // Check whether the comment contained any text.
                        if (!found)
                        {
                            // This is only allowed if this comment is sandwiched in between two other comments.
                            bool comment = false;
                            int lines = 0;
                            foreach (CsToken item in element.Tokens.ReverseIterator(tokenNode.Previous))
                            {
                                if (item.Text == "\n")
                                {
                                    ++lines;
                                    if (lines > 1)
                                    {
                                        break;
                                    }
                                }
                                else if (item.CsTokenType == CsTokenType.SingleLineComment)
                                {
                                    comment = true;
                                    break;
                                }
                                else if (item.CsTokenType != CsTokenType.WhiteSpace)
                                {
                                    break;
                                }
                            }

                            if (!comment)
                            {
                                CsElement errorElement = token.Parent as CsElement ?? element;
                                this.AddViolation(errorElement, token.Location, Rules.CommentsMustContainText);
                            }
                            else
                            {
                                comment = false;
                                lines = 0;
                                foreach (CsToken item in element.Tokens.ForwardIterator(tokenNode.Next))
                                {
                                    if (item.Text == "\n")
                                    {
                                        ++lines;
                                        if (lines > 1)
                                        {
                                            break;
                                        }
                                    }
                                    else if (item.CsTokenType == CsTokenType.SingleLineComment)
                                    {
                                        comment = true;
                                        break;
                                    }
                                    else if (item.CsTokenType != CsTokenType.WhiteSpace)
                                    {
                                        break;
                                    }
                                }

                                if (!comment)
                                {
                                    CsElement errorElement = token.Parent as CsElement ?? element;
                                    this.AddViolation(errorElement, token.Location, Rules.CommentsMustContainText);
                                }
                            }
                        }
                    }
                    else if (token.CsTokenType == CsTokenType.MultiLineComment)
                    {
                        // The is a multi-line comment. Get the start of the comment.
                        int start = token.Text.IndexOf("/*", StringComparison.Ordinal);
                        if (start > -1)
                        {
                            // Get the end of the comment
                            int end = token.Text.IndexOf("*/", start + 2, StringComparison.Ordinal);
                            if (end > -1)
                            {
                                // Look at the characters between the start and the end and see if there
                                // is anything here besides whitespace.
                                bool found = false;
                                for (int character = start + 2; character < end; ++character)
                                {
                                    if (token.Text[character] != ' ' && token.Text[character] != '\t' && token.Text[character] != '\r' && token.Text[character] != '\n')
                                    {
                                        found = true;
                                        break;
                                    }
                                }

                                // Check whether the comment contained any text.
                                if (!found)
                                {
                                    CsElement errorElement = token.Parent as CsElement ?? element;
                                    this.AddViolation(errorElement, token.Location, Rules.CommentsMustContainText);
                                }
                            }
                        }
                    }
                }
            }
        }

        #endregion
    }
}