//-----------------------------------------------------------------------
// <copyright file="CommentVerifier.cs">
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
//-----------------------------------------------------------------------
namespace StyleCop.CSharp
{
    using System.Globalization;
    using System.Text;
    using System.Xml;

    using StyleCop.Spelling;
    
    /// <summary>
    /// Contains helper methods for verifying the validity and style of comments.
    /// </summary>
    internal static class CommentVerifier
    {
        #region Internal Constants

        /// <summary>
        /// The minimum length for a valid comment.
        /// </summary>
        internal const int MinimumHeaderCommentLength = 10;

        /// <summary>
        /// The minimum number of characters in a valid comment.
        /// </summary>
        internal const int MinimumCharacterPercentage = 40;

        #endregion Internal Constants

        #region Public Static Methods

        /// <summary>
        /// Checks the contents of the given comment string to determine whether the comment appears
        /// to be a valid English-language sentence, or whether it appears to be garbage.
        /// </summary>
        /// <param name="comment">The comment to check.</param>
        /// <param name="culture">The culture to use to spell check the comment.</param>
        /// <param name="spellingError">Returns the first word encountered as a spelling error.</param>
        /// <returns>Returns the type of the comment.</returns>
        public static InvalidCommentType IsGarbageComment(string comment, CultureInfo culture, out string spellingError)
        {
            Param.AssertNotNull(comment, "comment");
            spellingError = null;

            InvalidCommentType invalid = InvalidCommentType.Valid;
            string trimmedComment = comment.Trim();

            string trimmedCommentWithoutPeriod = trimmedComment.TrimEnd(new[] { '.' }).Trim();

            // Make sure the comment string is valid.
            if (string.IsNullOrEmpty(trimmedComment))
            {
                invalid |= InvalidCommentType.Empty;
            }
            else
            {
                // Check the comment spelling
                if (TextContainsIncorectSpelling(culture, trimmedCommentWithoutPeriod, out spellingError))
                {
                    invalid |= InvalidCommentType.IncorrectSpelling;
                }

                // Check for the minimum length.
                if (trimmedComment.Length < MinimumHeaderCommentLength)
                {
                    invalid |= InvalidCommentType.TooShort;
                }

                // Verify that the comment starts with a capital letter.
                if (!char.IsUpper(trimmedComment[0]) && !char.IsDigit(trimmedComment[0]))
                {
                    invalid |= InvalidCommentType.NoCapitalLetter;
                }

                // Verify that the comment ends with a period.
                if (trimmedComment[trimmedComment.Length - 1] != '.')
                {
                    invalid |= InvalidCommentType.NoPeriod;
                }

                // Verify that at least 40% of the characters in the comment are letters, and that the comment contains
                // at least one space between words.
                float charCount = 0;
                float nonCharCount = 0;
                bool space = false;

                foreach (char character in trimmedCommentWithoutPeriod)
                {
                    if (char.IsLetter(character))
                    {
                        ++charCount;
                    }
                    else
                    {
                        if (char.IsWhiteSpace(character))
                        {
                            space = true;
                        }
                        else
                        {
                            ++nonCharCount;
                        }
                    }
                }

                if (charCount == 0 || ((charCount / (charCount + nonCharCount)) * 100) < MinimumCharacterPercentage)
                {
                    invalid |= InvalidCommentType.TooFewCharacters;
                }

                if (!space)
                {
                    invalid |= InvalidCommentType.NoWhitespace;
                }
            }

            return invalid;
        }
        
        /// <summary>
        /// Checks the contents of the given comment string to determine whether the comment appears
        /// to be a valid English-language sentence, or whether it appears to be garbage.
        /// </summary>
        /// <param name="commentXml">The comment to check.</param>
        /// <param name="culture">The culture to use to spell check the comment.</param>
        /// <param name="spellingError">Returns the first word encountered as a spelling error.</param>
        /// <returns>Returns the type of the comment.</returns>
        public static InvalidCommentType IsGarbageComment(XmlNode commentXml, CultureInfo culture, out string spellingError)
        {
            Param.AssertNotNull(commentXml, "commentXml");

            string comment = commentXml.InnerText;

            if (commentXml.HasChildNodes &&
                (commentXml.ChildNodes.Count > 1 || commentXml.ChildNodes[0].NodeType != XmlNodeType.Text))
            {
                comment = ExtractTextFromCommentXml(commentXml);
            }

            return IsGarbageComment(comment, culture, out spellingError);
        }

        /// <summary>
        /// Extracts text from a comment Xml, including special values in attributes.
        /// </summary>
        /// <param name="commentXml">The comment Xml.</param>
        /// <returns>Returns the text.</returns>
        public static string ExtractTextFromCommentXml(XmlNode commentXml)
        {
            Param.AssertNotNull(commentXml, "commentXml");

            StringBuilder commentBuilder = new StringBuilder();

            foreach (XmlNode childNode in commentXml.ChildNodes)
            {
                if (childNode.NodeType == XmlNodeType.Text)
                {
                    commentBuilder.Append(childNode.Value);
                }
                else
                {
                    if (childNode.Name == "c" || childNode.Name == "code")
                    {
                        continue;
                    }
                }

                if (childNode.HasChildNodes &&
                    (childNode.ChildNodes.Count > 0 || childNode.ChildNodes[0].NodeType != XmlNodeType.Text))
                {
                    commentBuilder.Append(ExtractTextFromCommentXml(childNode));
                }
            }

            return commentBuilder.ToString().Trim();
        }

        #endregion Public Static Methods

        /// <summary>
        /// Returns True if the text has incorrect spelling.
        /// </summary>
        /// <param name="culture">The culture to use to spell check the comment.</param>
        /// <param name="text">The text to check.</param>
        /// <param name="spellingError">Returns the first word encountered as a spelling error.</param>
        /// <returns>True if the text contains an incorrect spelling.</returns>
        private static bool TextContainsIncorectSpelling(CultureInfo culture, string text, out string spellingError)
        {
            var namingService = NamingService.GetNamingService(culture);

            if (namingService.SupportsSpelling)
            {
                WordParser parser = new WordParser(text, WordParserOptions.SplitCompoundWords);
                if (parser.PeekWord() != null)
                {
                    string word = parser.NextWord();
                    do
                    {
                        if (!IsSpelledCorrectly(namingService, word))
                        {
                            spellingError = word;
                            return true;
                        }
                    }
                    while ((word = parser.NextWord()) != null);
                }
            }

            spellingError = null;

            return false;
        }

        /// <summary>
        /// Returns true if the word is spelled correctly.
        /// </summary>
        /// <param name="namingService">The naming service to use.</param>
        /// <param name="word">The word to check.</param>
        /// <returns>True if spelled correct.</returns>
        private static bool IsSpelledCorrectly(NamingService namingService, string word)
        {
            return (namingService.GetPreferredAlternateForDeprecatedWord(word) != null) || (namingService.GetCompoundAlternateForDiscreteWord(word) != null) || (namingService.CheckSpelling(word) != WordSpelling.Unrecognized);
        }
    }
}