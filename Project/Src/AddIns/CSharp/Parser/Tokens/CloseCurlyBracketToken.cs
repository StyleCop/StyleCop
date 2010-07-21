//-----------------------------------------------------------------------
// <copyright file="CloseCurlyBracketToken.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
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

    /// <summary>
    /// Describes a closing curly bracket.
    /// </summary>
    /// <subcategory>token</subcategory>
    public sealed class CloseCurlyBracketToken : BracketToken
    {
        /// <summary>
        /// Initializes a new instance of the CloseCurlyBracketToken class.
        /// </summary>
        /// <param name="text">The text within the bracket.</param>
        /// <param name="location">The location of the bracket.</param>
        /// <param name="generated">Indicates whether the codeUnit lies within a block of generated code.</param>
        internal CloseCurlyBracketToken(string text, CodeLocation location, bool generated)
            : base(text, TokenType.CloseCurlyBracket, location, generated)
        {
            Param.AssertValidString(text, "text");
            Param.AssertNotNull(location, "location");
            Param.Ignore(generated);
        }
    }
}
