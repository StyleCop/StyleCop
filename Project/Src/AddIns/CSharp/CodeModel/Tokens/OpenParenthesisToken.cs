//-----------------------------------------------------------------------
// <copyright file="OpenParenthesisToken.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.
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
namespace Microsoft.StyleCop.CSharp.CodeModel
{
    using System;

    /// <summary>
    /// Describes an opening parenthesis.
    /// </summary>
    /// <subcategory>token</subcategory>
    public sealed class OpenParenthesisToken : OpenBracketToken
    {
        /// <summary>
        /// Initializes a new instance of the OpenParenthesisToken class.
        /// </summary>
        /// <param name="document">The parent document.</param>
        /// <param name="text">The text within the parenthesis.</param>
        /// <param name="location">The location of the parenthesis.</param>
        /// <param name="generated">Indicates whether the item lies within a block of generated code.</param>
        internal OpenParenthesisToken(CsDocument document, string text, CodeLocation location, bool generated)
            : base(document, text, TokenType.OpenParenthesis, location, generated)
        {
            Param.AssertNotNull(document, "document");
            Param.AssertValidString(text, "text");
            Param.AssertNotNull(location, "location");
            Param.Ignore(generated);
        }

        /// <summary>
        /// Gets the matching bracket type for this bracket.
        /// </summary>
        protected override TokenType MatchingBracketType
        {
            get
            {
                return TokenType.CloseParenthesis;
            }
        }
    }
}
