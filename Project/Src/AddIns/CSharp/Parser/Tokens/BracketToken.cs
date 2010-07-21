//-----------------------------------------------------------------------
// <copyright file="BracketToken.cs" company="Microsoft">
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
namespace Microsoft.StyleCop.CSharp
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// Describes one curly bracket, square bracket, parenthesis,
    /// attribute bracket, or generic bracket.
    /// </summary>
    /// <subcategory>token</subcategory>
    public abstract class BracketToken : Token
    {
        #region Private Fields

        /// <summary>
        /// The matching bracket.
        /// </summary>
        private BracketToken matchingBracket;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the BracketToken class.
        /// </summary>
        /// <param name="text">The token string.</param>
        /// <param name="tokenType">The token type.</param>
        /// <param name="location">The location of the token within the code document.</param>
        /// <param name="generated">True if the token is inside of a block of generated code.</param>
        internal BracketToken(string text, TokenType tokenType, CodeLocation location, bool generated)
            : base(text, tokenType, location, generated)
        {
            Param.Ignore(text, tokenType, location, generated);

            Debug.Assert(
                tokenType == TokenType.OpenCurlyBracket ||
                tokenType == TokenType.CloseCurlyBracket ||
                tokenType == TokenType.OpenSquareBracket ||
                tokenType == TokenType.CloseSquareBracket ||
                tokenType == TokenType.OpenParenthesis ||
                tokenType == TokenType.CloseParenthesis ||
                tokenType == TokenType.OpenGenericBracket ||
                tokenType == TokenType.CloseGenericBracket ||
                tokenType == TokenType.OpenAttributeBracket ||
                tokenType == TokenType.CloseAttributeBracket,
                "The symbol is not a bracket type.");
        }

        #endregion Internal Constructors

        #region Public Properties

        /// <summary>
        /// Gets the matching bracket, if there is one.
        /// </summary>
        public BracketToken MatchingBracket
        {
            get
            {
                return this.matchingBracket;
            }

            internal set
            {
                this.matchingBracket = value;
            }
        }

        #endregion Public Properties
    }
}
