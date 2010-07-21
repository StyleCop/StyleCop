//-----------------------------------------------------------------------
// <copyright file="CommentVerifier.cs" company="Microsoft">
//   Copyright (c) Microsoft Corporation.
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
    using System.Collections.Generic;
    using System.Text;
    using System.Xml;

    /// <summary>
    /// The possible return values from the IsGarbageComment method.
    /// </summary>
    [Flags]
    internal enum InvalidCommentType
    {
        /// <summary>
        /// The comment appears to be a valid comment.
        /// </summary>
        Valid = 0x0000,

        /// <summary>
        /// The comment is empty or consists only of whitespace.
        /// </summary>
        Empty = 0x0001,

        /// <summary>
        /// The comment is shorter than the minimum comment length.
        /// </summary>
        TooShort = 0x0002,

        /// <summary>
        /// The comment does not start with a capital letter.
        /// </summary>
        NoCapitalLetter = 0x0004,

        /// <summary>
        /// The comment does not end in a period.
        /// </summary>
        NoPeriod = 0x0008,

        /// <summary>
        /// The comments consists of too many symbols and too few characters.
        /// </summary>
        TooFewCharacters = 0x0010,

        /// <summary>
        /// The comment does not contain any whitespace.
        /// </summary>
        NoWhitespace = 0x0020
    }

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
        /// <returns>Returns the type of the comment.</returns>
        public static InvalidCommentType IsGarbageComment(string comment)
        {
            Param.AssertNotNull(comment, "comment");

            InvalidCommentType invalid = InvalidCommentType.Valid;
            string trimmedComment = comment.Trim();

            // Make sure the comment string is valid.
            if (string.IsNullOrEmpty(trimmedComment))
            {
                invalid |= InvalidCommentType.Empty;
            }
            else
            {
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

                foreach (char character in trimmedComment)
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
        /// <returns>Returns the type of the comment.</returns>
        public static InvalidCommentType IsGarbageComment(XmlNode commentXml)
        {
            Param.AssertNotNull(commentXml, "commentXml");

            string comment = commentXml.InnerText;

            if (commentXml.HasChildNodes &&
                (commentXml.ChildNodes.Count > 1 || commentXml.ChildNodes[0].NodeType != XmlNodeType.Text))
            {
                comment = ExtractTextFromCommentXml(commentXml);
            }

            return IsGarbageComment(comment);
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
                    if (childNode.Name == "paramref")
                    {
                        XmlAttribute name = childNode.Attributes["name"];
                        if (name != null)
                        {
                            commentBuilder.Append(name.Value);
                        }
                    }
                    else if ((childNode.Name == "see" || childNode.Name == "seealso") && childNode.ChildNodes.Count == 0)
                    {
                        // This is a tag of the form <see cref="something"/>. Since the tag has no
                        // child text, the value of the cref attribute will be inserted as text into the
                        // comment.
                        XmlAttribute crefAttribute = childNode.Attributes["cref"];
                        if (crefAttribute != null)
                        {
                            commentBuilder.Append(crefAttribute.Value);
                        }
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

        #region Private Static Methods

        /////// <summary>
        /////// Strips out any namespaces or generic parameters from the class name.
        /////// </summary>
        /////// <param name="name">The class name to strip.</param>
        /////// <returns>Returns the stripped class name.</returns>
        ////private static string StripClassName(string name)
        ////{
        ////    Param.AssertNotNull(name, "name");

        ////    int index = name.LastIndexOf('.');
        ////    if (index > 0)
        ////    {
        ////        name = name.Substring(index + 1, name.Length - index - 1);
        ////    }

        ////    index = name.IndexOf('{');
        ////    if (index > 0)
        ////    {
        ////        name = name.Substring(0, index);
        ////    }

        ////    return name;
        ////}

        #endregion Private Static Methods
    }
}
