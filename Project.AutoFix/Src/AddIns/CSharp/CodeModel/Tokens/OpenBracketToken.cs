//-----------------------------------------------------------------------
// <copyright file="OpenBracketToken.cs">
//     MS-PL
// </copyright>
// <license>
//   This source code is subject to terms and conditions of the Microsoft 
//   Public License. A copy of the license can be found in the License.html 
//   file at the root of this distribution. 
//   By using this source code in any fashion, you are agreeing to be bound 
//   by the terms of the Microsoft Public License. You must not remove this 
//   notice, or any other, from this software.
// </license>
//-----------------------------------------------------------------------
namespace StyleCop.CSharp.CodeModel
{
    using System;

    /// <summary>
    /// Describes one opening curly bracket, square bracket, parenthesis,
    /// attribute bracket, or generic bracket.
    /// </summary>
    /// <subcategory>token</subcategory>
    public abstract class OpenBracketToken : BracketToken
    {
        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the OpenBracketToken class.
        /// </summary>
        /// <param name="document">The parent document.</param>
        /// <param name="text">The token string.</param>
        /// <param name="tokenType">The token type.</param>
        internal OpenBracketToken(CsDocument document, string text, TokenType tokenType)
            : base(document, text, tokenType)
        {
            Param.Ignore(document, text, tokenType);

            CsLanguageService.Debug.Assert(
                tokenType == TokenType.OpenCurlyBracket ||
                tokenType == TokenType.OpenSquareBracket ||
                tokenType == TokenType.OpenParenthesis ||
                tokenType == TokenType.OpenGenericBracket ||
                tokenType == TokenType.OpenAttributeBracket,
                "The symbol is not a bracket type.");
        }

        /// <summary>
        /// Initializes a new instance of the OpenBracketToken class.
        /// </summary>
        /// <param name="document">The parent document.</param>
        /// <param name="text">The token string.</param>
        /// <param name="tokenType">The token type.</param>
        /// <param name="location">The location of the token within the code document.</param>
        /// <param name="generated">True if the token is inside of a block of generated code.</param>
        internal OpenBracketToken(CsDocument document, string text, TokenType tokenType, CodeLocation location, bool generated)
            : base(document, text, tokenType, location, generated)
        {
            Param.Ignore(document, text, tokenType, location, generated);

            CsLanguageService.Debug.Assert(
                tokenType == TokenType.OpenCurlyBracket ||
                tokenType == TokenType.OpenSquareBracket ||
                tokenType == TokenType.OpenParenthesis ||
                tokenType == TokenType.OpenGenericBracket ||
                tokenType == TokenType.OpenAttributeBracket,
                "The symbol is not a bracket type.");
        }

        #endregion Internal Constructors

        #region Protected Override Methods

        /// <summary>
        /// Finds the matching bracket token.
        /// </summary>
        /// <returns>The matching bracket token.</returns>
        protected override BracketToken FindMatchingBracket()
        {
            return this.FindNextSibling<CloseBracketToken>();
        }

        #endregion Protected Override Methods
    }
}
