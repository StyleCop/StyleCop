//-----------------------------------------------------------------------
// <copyright file="CloseParenthesisToken.cs" company="Microsoft">
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
    /// Describes a closing parenthesis.
    /// </summary>
    /// <subcategory>token</subcategory>
    public sealed class CloseParenthesisToken : BracketToken
    {
        /// <summary>
        /// Initializes a new instance of the CloseParenthesisToken class.
        /// </summary>
        /// <param name="text">The text within the parenthesis.</param>
        /// <param name="location">The location of the parenthesis.</param>
        /// <param name="generated">Indicates whether the codeUnit lies within a block of generated code.</param>
        internal CloseParenthesisToken(string text, CodeLocation location, bool generated)
            : base(text, TokenType.CloseParenthesis, location, generated)
        {
            Param.AssertValidString(text, "text");
            Param.AssertNotNull(location, "location");
            Param.Ignore(generated);
        }
    }
}
