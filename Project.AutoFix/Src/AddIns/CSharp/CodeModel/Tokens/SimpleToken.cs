//-----------------------------------------------------------------------
// <copyright file="SimpleToken.cs">
//   MS-PL
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
    /// Describes a token that contains no children.
    /// </summary>
    /// <subcategory>lexicalelement</subcategory>
    public abstract class SimpleToken : Token
    {
        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the SimpleToken class.
        /// </summary>
        /// <param name="document">The parent document.</param>
        /// <param name="text">The token string.</param>
        /// <param name="tokenType">The token type.</param>
        internal SimpleToken(CsDocument document, string text, TokenType tokenType)
            : this(document, text, (int)tokenType)
        {
            Param.Ignore(document, text, tokenType);
        }

        /// <summary>
        /// Initializes a new instance of the SimpleToken class.
        /// </summary>
        /// <param name="document">The parent document.</param>
        /// <param name="text">The token string.</param>
        /// <param name="tokenType">The token type.</param>
        /// <param name="location">The location of the token within the code document.</param>
        /// <param name="generated">True if the token is inside of a block of generated code.</param>
        internal SimpleToken(CsDocument document, string text, TokenType tokenType, CodeLocation location, bool generated)
            : this(document, text, (int)tokenType, location, generated)
        {
            Param.Ignore(document, text, tokenType, location, generated);
        }

        /// <summary>
        /// Initializes a new instance of the SimpleToken class.
        /// </summary>
        /// <param name="document">The parent document.</param>
        /// <param name="text">The token string.</param>
        /// <param name="tokenType">The token type.</param>
        /// <param name="location">The location of the token within the code document.</param>
        /// <param name="generated">True if the token is inside of a block of generated code.</param>
        internal SimpleToken(CsDocument document, string text, int tokenType, CodeLocation location, bool generated)
            : base(new CodeUnitProxy(document), tokenType, location)
        {
            Param.Ignore(document, text, tokenType, location, generated);

            this.Text = text;
            this.Generated = generated;
        }

        /// <summary>
        /// Initializes a new instance of the SimpleToken class.
        /// </summary>
        /// <param name="document">The parent document.</param>
        /// <param name="text">The token string.</param>
        /// <param name="tokenType">The token type.</param>
        internal SimpleToken(CsDocument document, string text, int tokenType)
            : base(new CodeUnitProxy(document), tokenType)
        {
            Param.Ignore(document, text, tokenType);
            this.Text = text;
        }

        #endregion Internal Constructors

        #region Public Override Properties

        /// <summary>
        /// Gets the line number that this code unit appears on in the document.
        /// </summary>
        public override int LineNumber
        {
            get
            {
                return this.Location.StartPoint.LineNumber;
            }
        }

        #endregion Public Override Properties
    }
}
