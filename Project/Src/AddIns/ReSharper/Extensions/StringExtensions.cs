//-----------------------------------------------------------------------
// <copyright file="">
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

namespace System
{
    #region Using Directives

    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text.RegularExpressions;

    #endregion

    /// <summary>
    /// Extension methods for the <see cref="string"/> class.
    /// </summary>
    public static class StringExtensions
    {
        #region Public Methods

        /// <summary>
        /// Replaces the format item in a <see cref="string"/> with the text equivalent of the value of a corresponding <see cref="object"/> 
        /// instance in a specified array, using the <see cref="CultureInfo.InvariantCulture"/>.
        /// </summary>
        /// <param name="format">
        /// A composite format string.
        /// </param>
        /// <param name="args">
        /// An <see cref="object"/> array containing zero or more objects to format.
        /// </param>
        /// <returns>
        /// A copy of format in which the format items have been replaced by the <see cref="string"/> equivalent of the corresponding instances 
        /// of <see cref="object"/>  in args.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Either <paramref name="format"/> or <paramref name="args"/> is <c>Null.</c>.
        /// </exception>
        /// <exception cref="FormatException">
        /// <paramref name="format"/>is invalid.
        /// <para>
        /// - or -.
        /// </para>
        /// The number indicating an argument to format is less than zero, or greater than or equal to the length of the <paramref name="args"/> array.
        /// </exception>
        public static string FormatWith(this string format, params object[] args)
        {
            return string.Format(CultureInfo.InvariantCulture, format, args);
        }

        /// <summary>
        /// Replaces the format item in a <see cref="string"/> with the text equivalent of the value of a corresponding <see cref="object"/> 
        /// instance in a specified array. A specified parameter supplies culture-specific formatting information.
        /// </summary>
        /// <param name="format">
        /// A composite format string.
        /// </param>
        /// <param name="provider">
        /// An <see cref="IFormatProvider"/> that supplies culture-specific formatting information.
        /// </param>
        /// <param name="args">
        /// An <see cref="object"/> array containing zero or more objects to format.
        /// </param>
        /// <returns>
        /// A copy of format in which the format items have been replaced by the <see cref="string"/> equivalent of the corresponding instances 
        /// of <see cref="object"/>  in args.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Either <paramref name="format"/> or <paramref name="args"/> is <c>Null.</c>.
        /// </exception>
        /// <exception cref="FormatException">
        /// <paramref name="format"/>is invalid.
        /// <para>
        /// - or -.
        /// </para>
        /// The number indicating an argument to format is less than zero, or greater than or equal to the length of the <paramref name="args"/> array.
        /// </exception>
        public static string FormatWith(this string format, IFormatProvider provider, params object[] args)
        {
            return string.Format(provider, format, args);
        }

        /// <summary>
        /// Indicates whether the specified <see cref="string"/> is null or an <see cref="string.Empty"/> string.
        /// </summary>
        /// <param name="s">
        /// The <see cref="string"/> to check.
        /// </param>
        /// <returns>
        /// <c>False.</c>if the value is null or an <see cref="string.Empty"/> string; otherwise, 
        /// <c>True.</c>.
        /// </returns>
        public static bool HasValue(this string s)
        {
            return !string.IsNullOrEmpty(s);
        }

        /// <summary>
        /// Indicates whether the regular expression finds a match in the input string, using the regular expression specified.
        /// </summary>
        /// <param name="s">
        /// The string to search for a match.
        /// </param>
        /// <param name="regex">
        /// The regular expression pattern to match.
        /// </param>
        /// <returns>
        /// <c>True.</c>if the regular expression finds a match; otherwise 
        /// <c>False.</c>.
        /// </returns>
        public static bool IsMatch(this string s, string regex)
        {
            return Regex.IsMatch(s, regex);
        }

        /// <summary>
        /// Indicates whether the regular expression finds a match in the input string, using the regular expression specified 
        /// and the matching options supplied in the options parameter.
        /// </summary>
        /// <param name="s">
        /// The string to search for a match.
        /// </param>
        /// <param name="regex">
        /// The regular expression pattern to match.
        /// </param>
        /// <param name="options">
        /// The regex options.
        /// A bitwise OR combination of <see cref="RegexOptions"/> enumeration values.
        /// </param>
        /// <returns>
        /// <c>True.</c>if the regular expression finds a match; otherwise 
        /// <c>False.</c>.
        /// </returns>
        public static bool IsMatch(this string s, string regex, RegexOptions options)
        {
            return Regex.IsMatch(s, regex, options);
        }

        /// <summary>
        /// Concatenates a specified separator string between each element of a specified sequence, yielding a single concatenated string.
        /// </summary>
        /// <param name="source">
        /// The sequence of strings to join.
        /// </param>
        /// <param name="separator">
        /// The separator to join the strings with.
        /// </param>
        /// <returns>
        /// A single concatenated string.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Either <paramref name="source"/> or <paramref name="separator"/> is <c>Null.</c>.
        /// </exception>
        //public static string JoinWith(this IEnumerable<string> source, string separator)
        //{
        //    var array = source as string[] ?? source.ToArray();
        //    return string.Join(separator, array);
        //}

        /// <summary>
        /// Retrieves a substring after the first instance of a character.
        /// </summary>
        /// <param name="s">
        /// The string to retrieve the substring from.
        /// </param>
        /// <param name="c">
        /// The character to seek.
        /// </param>
        /// <returns>
        /// The substring after the first occurrence of <paramref name="c"/>, or <paramref name="s"/> if <paramref name="c"/> is not found.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="s"/>is <c>Null.</c>.
        /// </exception>
        public static string SubstringAfter(this string s, char c)
        {
            var index = s.IndexOf(c);
            if (index == -1)
            {
                return s;
            }

            return index < s.Length - 1 ? s.Substring(index + 1) : string.Empty;
        }

        /// <summary>
        /// Retrieves a substring after the last instance of a character.
        /// </summary>
        /// <param name="s">
        /// The string to retrieve the substring from.
        /// </param>
        /// <param name="c">
        /// The character to seek.
        /// </param>
        /// <returns>
        /// The substring after the last occurrence of <paramref name="c"/>, or <paramref name="s"/> if <paramref name="c"/> is not found.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="s"/>is <c>Null.</c>.
        /// </exception>
        public static string SubstringAfterLast(this string s, char c)
        {
            var index = s.LastIndexOf(c);
            if (index == -1)
            {
                return s;
            }

            return index < s.Length - 1 ? s.Substring(index + 1) : string.Empty;
        }

        /// <summary>
        /// Retrieves a substring before the first instance of a character.
        /// </summary>
        /// <param name="s">
        /// The string to retrieve the substring from.
        /// </param>
        /// <param name="c">
        /// The character to seek.
        /// </param>
        /// <returns>
        /// The substring before the first occurrence of <paramref name="c"/>, or <paramref name="s"/> if <paramref name="c"/> is not found.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="s"/>is <c>Null.</c>.
        /// </exception>
        //public static string SubstringBefore(this string s, char c)
        //{
        //    var index = s.IndexOf(c);
        //    return index != -1 ? s.Substring(0, index) : s;
        //}

        /// <summary>
        /// Retrieves a substring before the last instance of a character.
        /// </summary>
        /// <param name="s">
        /// The string to retrieve the substring from.
        /// </param>
        /// <param name="c">
        /// The character to seek.
        /// </param>
        /// <returns>
        /// The substring before the last occurrence of <paramref name="c"/>, or <paramref name="s"/> if <paramref name="c"/> is not found.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="s"/>is <c>Null.</c>.
        /// </exception>
        public static string SubstringBeforeLast(this string s, char c)
        {
            var index = s.LastIndexOf(c);
            return index != -1 ? s.Substring(0, index) : s;
        }

        /// <summary>
        /// Truncates a string to a specified length, suffixing the truncated string with an ellipsis (…).
        /// </summary>
        /// <param name="s">
        /// The string to truncate.
        /// </param>
        /// <param name="length">
        /// The maximum length of the truncated string, including the ellipsis.
        /// </param>
        /// <returns>
        /// The truncated string.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="s"/>is <c>Null.</c>.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="length"/>is less than or equal to 1.
        /// </exception>
        public static string Truncate(this string s, int length)
        {
            return s.Length > length ? s.Substring(0, length - 1) + "…" : s;
        }

        #endregion
    }
}