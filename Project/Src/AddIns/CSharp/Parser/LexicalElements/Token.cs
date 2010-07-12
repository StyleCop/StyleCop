//-----------------------------------------------------------------------
// <copyright file="Token.cs" company="Microsoft">
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
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Describes a single token within a C# document.
    /// </summary>
    /// <subcategory>token</subcategory>
    public abstract class Token : LexicalElement
    {
        #region Internal Static Fields

        ///// <summary>
        ///// An empty array of tokens.
        ///// </summary>
        ////internal static readonly Token[] EmptyTokenArray = new Token[] { };

        #endregion Internal Static Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the Token class.
        /// </summary>
        /// <param name="document">The parent document.</param>
        /// <param name="text">The token string.</param>
        /// <param name="tokenType">The token type.</param>
        /// <param name="location">The location of the token within the code document.</param>
        /// <param name="generated">True if the token is inside of a block of generated code.</param>
        internal Token(CsDocument document, string text, TokenType tokenType, CodeLocation location, bool generated)
            : this(document, text, (int)tokenType, location, generated)
        {
            Param.Ignore(document, text, tokenType, location, generated);
        }

        /// <summary>
        /// Initializes a new instance of the Token class.
        /// </summary>
        /// <param name="document">The parent document.</param>
        /// <param name="text">The token string.</param>
        /// <param name="tokenType">The token type.</param>
        /// <param name="location">The location of the token within the code document.</param>
        /// <param name="generated">True if the token is inside of a block of generated code.</param>
        internal Token(CsDocument document, string text, int tokenType, CodeLocation location, bool generated)
            : base(document, tokenType, location, generated)
        {
            Param.Ignore(document, text, tokenType, location, generated);

            this.Text = text;
        }

        /// <summary>
        /// Initializes a new instance of the Token class.
        /// </summary>
        /// <param name="tokenType">The token type.</param>
        /// <param name="proxy">Proxy object for the token.</param>
        internal Token(TokenType tokenType, CodeUnitProxy proxy)
            : this((int)tokenType, proxy)
        {
            Param.Ignore(tokenType);
            Param.AssertNotNull(proxy, "proxy");
        }

        /// <summary>
        /// Initializes a new instance of the Token class.
        /// </summary>
        /// <param name="tokenType">The token type.</param>
        /// <param name="proxy">Proxy object for the token.</param>
        internal Token(int tokenType, CodeUnitProxy proxy)
            : base(tokenType, proxy)
        {
            Param.Ignore(tokenType);
            Param.AssertNotNull(proxy, "proxy");
            Debug.Assert(System.Enum.IsDefined(typeof(TokenType), this.TokenType), "The type is invalid.");
        }

        /// <summary>
        /// Initializes a new instance of the Token class.
        /// </summary>
        /// <param name="text">The token string.</param>
        /// <param name="tokenType">The token type.</param>
        /// <param name="proxy">Proxy object for the expression.</param>
        internal Token(string text, int tokenType, CodeUnitProxy proxy)
            : this(tokenType, proxy)
        {
            Param.AssertNotNull(text, "text");
            Param.Ignore(tokenType);
            Param.AssertNotNull(proxy, "proxy");

            this.Text = text;
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
