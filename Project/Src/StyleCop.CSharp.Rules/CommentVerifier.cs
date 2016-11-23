// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CommentVerifier.cs" company="https://github.com/StyleCop">
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
//   Contains helper methods for verifying the validity and style of comments.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text;
    using System.Xml;

    using StyleCop.Spelling;

    /// <summary>
    /// Contains helper methods for verifying the validity and style of comments.
    /// </summary>
    internal static class CommentVerifier
    {
        #region Constants

        /// <summary>
        /// The minimum number of characters in a valid comment.
        /// </summary>
        internal const int MinimumCharacterPercentage = 40;

        /// <summary>
        /// The minimum length for a valid comment.
        /// </summary>
        internal const int MinimumHeaderCommentLength = 10;

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Extracts text from a comment Xml, including special values in attributes.
        /// </summary>
        /// <param name="commentXml">
        /// The comment Xml.
        /// </param>
        /// <param name="textWithAttributesRemoved">
        /// The text from the XmlNode with all attributes values and code elements removed.
        /// </param>
        /// <param name="textWithAttributesPreserved">
        /// The text with all attribute and code elements inserted into text.
        /// </param>
        public static void ExtractTextFromCommentXml(XmlNode commentXml, out string textWithAttributesRemoved, out string textWithAttributesPreserved)
        {
            Param.AssertNotNull(commentXml, "commentXml");

            StringBuilder commentWithAttributesRemovedBuilder = new StringBuilder();
            StringBuilder commentWithAttributesPreservedBuilder = new StringBuilder();

            foreach (XmlNode childNode in commentXml.ChildNodes)
            {
                if (childNode.NodeType == XmlNodeType.Text)
                {
                    commentWithAttributesRemovedBuilder.Append(childNode.Value);
                    commentWithAttributesPreservedBuilder.Append(childNode.Value);
                }
                else
                {
                    switch (childNode.Name)
                    {
                        case "typeparamref":
                        case "typeparam":
                        case "paramref":
                        case "param":
                            AddAttributeValue(commentWithAttributesPreservedBuilder, childNode, "name");
                            break;

                        case "exception":
                        case "event":
                        case "permission":
                            AddAttributeValue(commentWithAttributesPreservedBuilder, childNode, "cref");
                            break;

                        case "see":
                            if (childNode.ChildNodes.Count == 0)
                            {
                                // This is a tag of the form <see cref="something"/>. Since the tag has no
                                // child text, the value of the cref attribute will be inserted as text into the
                                // comment.
                                AddAttributeValue(commentWithAttributesPreservedBuilder, childNode, "cref");
                                AddAttributeValue(commentWithAttributesPreservedBuilder, childNode, "href");
                                AddAttributeValue(commentWithAttributesPreservedBuilder, childNode, "langword");
                            }

                            break;

                        case "seealso":
                            if (childNode.ChildNodes.Count == 0)
                            {
                                // This is a tag of the form <seealso cref="something"/>. Since the tag has no
                                // child text, the value of the cref attribute will be inserted as text into the
                                // comment.
                                AddAttributeValue(commentWithAttributesPreservedBuilder, childNode, "cref");
                                AddAttributeValue(commentWithAttributesPreservedBuilder, childNode, "href");
                            }

                            break;
                    }
                }

                if (childNode.HasChildNodes)
                {
                    string textWithAttRemoved;
                    string textWithAttPreserved;
                    ExtractTextFromCommentXml(childNode, out textWithAttRemoved, out textWithAttPreserved);

                    commentWithAttributesRemovedBuilder.Append(" ");
                    commentWithAttributesPreservedBuilder.Append(" ");

                    if (childNode.Name != "c" && childNode.Name != "code")
                    {
                        commentWithAttributesRemovedBuilder.Append(textWithAttRemoved);
                    }

                    commentWithAttributesPreservedBuilder.Append(textWithAttPreserved);
                }
            }

            textWithAttributesRemoved = commentWithAttributesRemovedBuilder.ToString().Trim();
            textWithAttributesPreserved = commentWithAttributesPreservedBuilder.ToString().Trim();
        }

        /// <summary>
        /// Checks the contents of the given comment string to determine whether the comment appears
        /// to be a valid English-language sentence, or whether it appears to be garbage.
        /// </summary>
        /// <param name="commentWithAttributesRemoved">
        /// The comment to check (which has had its attributes removed).
        /// </param>
        /// <param name="commentWithAttributesPreserved">
        /// The comment to check with attribute values inserted into the text.
        /// </param>
        /// <param name="element">
        /// The element containing the text we're checking.
        /// </param>
        /// <param name="spellingError">
        /// Returns the first word encountered as a spelling error.
        /// </param>
        /// <returns>
        /// Returns the type of the comment.
        /// </returns>
        public static InvalidCommentType IsGarbageComment(
            string commentWithAttributesRemoved, string commentWithAttributesPreserved, CsElement element, out string spellingError)
        {
            Param.AssertNotNull(commentWithAttributesRemoved, "commentWithAttributesRemoved");
            Param.AssertNotNull(commentWithAttributesPreserved, "commentWithAttributesPreserved");
            spellingError = null;

            InvalidCommentType invalid = InvalidCommentType.Valid;

            string trimmedCommentWithoutAttributes = commentWithAttributesRemoved.Trim();

            string trimmedCommentWithAttributesPreserved = commentWithAttributesPreserved.Trim();

            string trimmedCommentWithAttributesPreservedWithoutPeriod = trimmedCommentWithAttributesPreserved.TrimEnd(new[] { '.' }).Trim();

            // Make sure the comment string is valid.
            if (string.IsNullOrEmpty(trimmedCommentWithAttributesPreserved))
            {
                invalid |= InvalidCommentType.Empty;
            }
            else
            {
                // Check the comment spelling
                if (TextContainsIncorectSpelling(element, trimmedCommentWithoutAttributes, out spellingError))
                {
                    invalid |= InvalidCommentType.IncorrectSpelling;
                }

                // Check for the minimum length.
                if (trimmedCommentWithAttributesPreserved.Length < MinimumHeaderCommentLength)
                {
                    invalid |= InvalidCommentType.TooShort;
                }

                // Verify that the comment starts with a capital letter.
                if (!char.IsUpper(trimmedCommentWithAttributesPreserved[0]) && !char.IsDigit(trimmedCommentWithAttributesPreserved[0]))
                {
                    invalid |= InvalidCommentType.NoCapitalLetter;
                }

                // Verify that the comment ends with a period.
                if (trimmedCommentWithAttributesPreserved[trimmedCommentWithAttributesPreserved.Length - 1] != '.')
                {
                    invalid |= InvalidCommentType.NoPeriod;
                }

                // Verify that at least 40% of the characters in the comment are letters, and that the comment contains
                // at least one space between words.
                int charCount = 0;
                int nonCharCount = 0;
                bool space = false;

                foreach (char character in trimmedCommentWithAttributesPreservedWithoutPeriod)
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

                if (charCount == 0 || (((charCount * 100) / (charCount + nonCharCount)) < MinimumCharacterPercentage))
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
        /// <param name="commentXml">
        /// The comment to check.
        /// </param>
        /// <param name="element">
        /// The element containing the text we're checking.
        /// </param>
        /// <param name="spellingError">
        /// Returns the first word encountered as a spelling error.
        /// </param>
        /// <returns>
        /// Returns the type of the comment.
        /// </returns>
        public static InvalidCommentType IsGarbageComment(XmlNode commentXml, CsElement element, out string spellingError)
        {
            Param.AssertNotNull(commentXml, "commentXml");

            string commentWithAttributesRemoved = commentXml.InnerText;
            string commentWithAttributesPreserved = commentXml.InnerText;

            if (commentXml.HasChildNodes && (commentXml.ChildNodes.Count > 1 || commentXml.ChildNodes[0].NodeType != XmlNodeType.Text))
            {
                ExtractTextFromCommentXml(commentXml, out commentWithAttributesRemoved, out commentWithAttributesPreserved);
            }

            return IsGarbageComment(commentWithAttributesRemoved, commentWithAttributesPreserved, element, out spellingError);
        }

        #endregion

        #region Methods

        private static void AddAttributeValue(StringBuilder commentWithAttributesBuilder, XmlNode childNode, string attributeName)
        {
            if (childNode.Attributes != null)
            {
                XmlAttribute attribute = childNode.Attributes[attributeName];
                if (attribute != null)
                {
                    commentWithAttributesBuilder.Append(attribute.Value);
                }
            }
        }

        /// <summary>
        /// Returns true if the word is spelled correctly.
        /// </summary>
        /// <param name="namingService">
        /// The naming service to use.
        /// </param>
        /// <param name="word">
        /// The word to check.
        /// </param>
        /// <param name="hint">
        /// A message indicating why the word isn't spelled correctly, or <see langword="null"/> if there is none.
        /// </param>
        /// <returns>
        /// True if spelled correctly; otherwise, False.
        /// </returns>
        private static bool IsSpelledCorrectly(NamingService namingService, string word, out string hint)
        {
            string alternate;

            alternate = namingService.GetPreferredAlternateForDeprecatedWord(word);
            if (alternate != null)
            {
                // Deprecated word, preferred alternate should be used.
                hint = (alternate.Length > 0)
                        ? string.Format(CultureInfo.InvariantCulture, Strings.SpellingPreferredAlternate, alternate)
                        : null;
                return false;
            }

            alternate = namingService.GetCompoundAlternateForDiscreteWord(word);
            if (alternate != null)
            {
                // Compound alternate should be used.
                hint = (alternate.Length > 0)
                        ? string.Format(CultureInfo.InvariantCulture, Strings.SpellingUseCompoundWord, alternate)
                        : null;
                return false;
            }

            if (namingService.CheckSpelling(word) == WordSpelling.Unrecognized)
            {
                // Spelling error.
                hint = null;
                return false;
            }

            // No error.
            hint = null;
            return true;
        }

        /// <summary>
        /// Returns True if the text has incorrect spelling.
        /// </summary>
        /// <param name="element">
        /// The element containing the text we're checking.
        /// </param>
        /// <param name="text">
        /// The text to check.
        /// </param>
        /// <param name="spellingError">
        /// Returns a comma separated list of words encountered as spelling errors.
        /// </param>
        /// <returns>
        /// True if the text contains an incorrect spelling.
        /// </returns>
        private static bool TextContainsIncorectSpelling(CsElement element, string text, out string spellingError)
        {
            NamingService namingService = NamingService.GetNamingService(element.Document.SourceCode.Project.Culture);

            spellingError = string.Empty;

            if (namingService.SupportsSpelling)
            {
                ICollection<string> recognizedWords = element.Document.SourceCode.Project.RecognizedWords;

                WordParser parser = new WordParser(text, WordParserOptions.SplitCompoundWords, recognizedWords);
                if (parser.PeekWord() != null)
                {
                    string word = parser.NextWord();
                    do
                    {
                        // Ignore words starting and ending with '$'.
                        // Ignore if in our recognized words list or correct spelling
                        string hint = null;
                        if ((word.StartsWith("$") && word.EndsWith("$")) || (recognizedWords.Contains(word) || IsSpelledCorrectly(namingService, word, out hint)))
                        {
                            continue;
                        }

                        // If we already have a spelling error for this element, add a comma to separate them.
                        if (!string.IsNullOrEmpty(spellingError))
                        {
                            spellingError += ", ";
                        }

                        spellingError += "'" + word + "'";

                        // Append a hint message to this spelling error if we have one.
                        if (hint != null && hint.Trim().Length > 0)
                        {
                            spellingError += " " + hint;
                        }
                    }
                    while ((word = parser.NextWord()) != null);
                }
            }

            return !string.IsNullOrEmpty(spellingError);
        }

        #endregion
    }
}