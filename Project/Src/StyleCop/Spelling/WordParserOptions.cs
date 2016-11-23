// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WordParserOptions.cs" company="https://github.com/StyleCop">
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
//   The options for the word parser.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.Spelling
{
    using System;

    /// <summary>
    /// The options for the word parser. 
    /// </summary>
    [Flags]
    public enum WordParserOptions
    {
        /// <summary>
        /// No parser options.
        /// </summary>
        None, 

        /// <summary>
        /// If set mnemonics will be ignored.
        /// </summary>
        IgnoreMnemonicsIndicators, 

        /// <summary>
        /// If set it will split compound words.
        /// </summary>
        SplitCompoundWords
    }
}