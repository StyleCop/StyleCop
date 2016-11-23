// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Bracket.cs" company="https://github.com/StyleCop">
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
//   Describes one curly bracket, square bracket, parenthesis,
//   attribute bracket, or generic bracket.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    using System.Diagnostics;

    /// <summary>
    /// Describes one curly bracket, square bracket, parenthesis,
    /// attribute bracket, or generic bracket.
    /// </summary>
    /// <subcategory>token</subcategory>
    public sealed class Bracket : CsToken
    {
        #region Fields

        /// <summary>
        /// The matching bracket.
        /// </summary>
        private Node<CsToken> matchingBracketNode;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the Bracket class.
        /// </summary>
        /// <param name="text">
        /// The token string.
        /// </param>
        /// <param name="tokenType">
        /// The token type.
        /// </param>
        /// <param name="location">
        /// The location of the token within the code document.
        /// </param>
        /// <param name="parent">
        /// The parent code part.
        /// </param>
        /// <param name="generated">
        /// True if the token is inside of a block of generated code.
        /// </param>
        internal Bracket(string text, CsTokenType tokenType, CodeLocation location, Reference<ICodePart> parent, bool generated)
            : base(text, tokenType, CsTokenClass.Bracket, location, parent, generated)
        {
            Param.Ignore(text, tokenType, location, parent, generated);

            Debug.Assert(
                tokenType == CsTokenType.OpenCurlyBracket || tokenType == CsTokenType.CloseCurlyBracket || tokenType == CsTokenType.OpenSquareBracket
                || tokenType == CsTokenType.CloseSquareBracket || tokenType == CsTokenType.OpenParenthesis || tokenType == CsTokenType.CloseParenthesis
                || tokenType == CsTokenType.OpenGenericBracket || tokenType == CsTokenType.CloseGenericBracket || tokenType == CsTokenType.OpenAttributeBracket
                || tokenType == CsTokenType.CloseAttributeBracket, 
                "The symbol is not a bracket type.");
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the matching bracket, if there is one.
        /// </summary>
        public Bracket MatchingBracket
        {
            get
            {
                if (this.matchingBracketNode == null)
                {
                    return null;
                }

                return this.matchingBracketNode.Value as Bracket;
            }
        }

        /// <summary>
        /// Gets the matching bracket node, if there is one.
        /// </summary>
        public Node<CsToken> MatchingBracketNode
        {
            get
            {
                return this.matchingBracketNode;
            }

            internal set
            {
                this.matchingBracketNode = value;
            }
        }

        #endregion
    }
}