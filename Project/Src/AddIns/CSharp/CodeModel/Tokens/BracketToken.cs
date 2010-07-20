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
namespace Microsoft.StyleCop.CSharp.CodeModel
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// Describes one curly bracket, square bracket, parenthesis,
    /// attribute bracket, or generic bracket.
    /// </summary>
    /// <subcategory>token</subcategory>
    public abstract class BracketToken : SimpleToken
    {
        #region Private Fields

        /// <summary>
        /// The matching bracket.
        /// </summary>
        private CodeUnitProperty<BracketToken> matchingBracket;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the BracketToken class.
        /// </summary>
        /// <param name="document">The parent document.</param>
        /// <param name="text">The token string.</param>
        /// <param name="tokenType">The token type.</param>
        /// <param name="location">The location of the token within the code document.</param>
        /// <param name="generated">True if the token is inside of a block of generated code.</param>
        internal BracketToken(CsDocument document, string text, TokenType tokenType, CodeLocation location, bool generated)
            : base(document, text, tokenType, location, generated)
        {
            Param.Ignore(document, text, tokenType, location, generated);

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
                this.ValidateEditVersion();

                if (!this.matchingBracket.Initialized)
                {
                    this.matchingBracket.Value = this.FindMatchingBracket();
                    if (this.matchingBracket.Value == null)
                    {
                        throw new SyntaxException(this.Document, this.LineNumber);
                    }
                }

                return this.matchingBracket.Value;
            }

            internal set
            {
                this.matchingBracket.Value = value;
            }
        }

        #endregion Public Properties

        #region Protected Abstract Properties

        /// <summary>
        /// Gets the matching bracket type for this bracket.
        /// </summary>
        protected abstract TokenType MatchingBracketType
        {
            get;
        }

        #endregion Protected Abstract Properties

        #region Protected Override Methods

        /// <summary>
        /// Resets the contents of the item.
        /// </summary>
        protected override void Reset()
        {
            base.Reset();

            this.matchingBracket.Reset();
        }

        #endregion Protected Override Methods

        #region Protected Abstract Methods

        /// <summary>
        /// Finds the matching bracket token.
        /// </summary>
        /// <returns>The matching bracket token.</returns>
        protected abstract BracketToken FindMatchingBracket();

        #endregion Protected Abstract Methods
    }
}
