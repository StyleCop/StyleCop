// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InvalidCommentType.cs" company="https://github.com/StyleCop">
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
//   The possible return values from the IsGarbageComment method.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    using System;

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
        NoWhitespace = 0x0020, 

        /// <summary>
        /// The comment has spelling mistakes.
        /// </summary>
        IncorrectSpelling = 0x0040
    }
}