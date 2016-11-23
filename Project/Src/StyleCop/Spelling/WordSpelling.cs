// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WordSpelling.cs" company="https://github.com/StyleCop">
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
//   The result of the spelling check.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.Spelling
{
    /// <summary>
    /// The result of the spelling check.
    /// </summary>
    public enum WordSpelling
    {
        /// <summary>
        /// The word was spelled correctly.
        /// </summary>
        SpelledCorrectly, 

        /// <summary>
        /// The word was unrecognized.
        /// </summary>
        Unrecognized, 

        /// <summary>
        /// The word was cased incorrectly.
        /// </summary>
        CasedIncorrectly
    }
}