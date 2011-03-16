//-----------------------------------------------------------------------
// <copyright file="Token.cs">
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
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Describes a single token within a C# document.
    /// </summary>
    /// <subcategory>token</subcategory>
    public abstract class Token : LexicalElement
    {
        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the Token class.
        /// </summary>
        /// <param name="proxy">Proxy object for the token.</param>
        /// <param name="tokenType">The token type.</param>
        internal Token(CodeUnitProxy proxy, TokenType tokenType)
            : base(proxy, (int)tokenType)
        {
            Param.Ignore(tokenType);
            Param.AssertNotNull(proxy, "proxy");
        }

        /// <summary>
        /// Initializes a new instance of the Token class.
        /// </summary>
        /// <param name="proxy">Proxy object for the token.</param>
        /// <param name="tokenType">The token type.</param>
        internal Token(CodeUnitProxy proxy, int tokenType)
            : base(proxy, tokenType)
        {
            Param.Ignore(tokenType);
            Param.AssertNotNull(proxy, "proxy");
            CsLanguageService.Debug.Assert(System.Enum.IsDefined(typeof(TokenType), this.TokenType), "The type is invalid.");
        }

        /// <summary>
        /// Initializes a new instance of the Token class.
        /// </summary>
        /// <param name="proxy">Proxy object for the token.</param>
        /// <param name="tokenType">The token type.</param>
        /// <param name="location">The location of the code unit.</param>
        internal Token(CodeUnitProxy proxy, int tokenType, CodeLocation location)
            : base(proxy, tokenType, location)
        {
            Param.Ignore(tokenType);
            Param.AssertNotNull(proxy, "proxy");
            Param.Ignore(location);

            CsLanguageService.Debug.Assert(System.Enum.IsDefined(typeof(TokenType), this.TokenType), "The type is invalid.");
        }
 
        #endregion Internal Constructors

        #region Public Properties

        /// <summary>
        /// Gets the token Type.
        /// </summary>
        public TokenType TokenType
        {
            get
            {
                return (TokenType)(this.FundamentalType & (int)FundamentalTypeMasks.Token);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the token is composed of multiple child tokens.
        /// </summary>
        public bool IsComplexToken
        {
            get;
            protected set;
        }

        #endregion Public Properties
    }
}
