// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TypeToken.cs" company="https://github.com/StyleCop">
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
//   Describes a type token in a code file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Text;

    /// <summary>
    /// Describes a type token in a code file.
    /// </summary>
    /// <subcategory>token</subcategory>
    public class TypeToken : CsToken, ITokenContainer
    {
        #region Fields

        /// <summary>
        /// The list of child tokens within this token.
        /// </summary>
        private readonly MasterList<CsToken> childTokens;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the TypeToken class.
        /// </summary>
        /// <param name="childTokens">
        /// The list of child tokens that form the token.
        /// </param>
        /// <param name="location">
        /// The location of the token in the code.
        /// </param>
        /// <param name="parent">
        /// The parent of the token.
        /// </param>
        /// <param name="generated">
        /// True if the token is inside of a block of generated code.
        /// </param>
        internal TypeToken(MasterList<CsToken> childTokens, CodeLocation location, Reference<ICodePart> parent, bool generated)
            : base(CsTokenType.Other, CsTokenClass.Type, location, parent, generated)
        {
            Param.AssertNotNull(childTokens, "childTokens");
            Param.AssertNotNull(location, "location");
            Param.AssertNotNull(parent, "parent");
            Param.Ignore(generated);

            this.childTokens = childTokens;
        }

        /// <summary>
        /// Initializes a new instance of the TypeToken class.
        /// </summary>
        /// <param name="childTokens">
        /// The list of child tokens that form the token.
        /// </param>
        /// <param name="location">
        /// The location of the token in the code.
        /// </param>
        /// <param name="parent">
        /// The parent of the token.
        /// </param>
        /// <param name="tokenClass">
        /// The token class.
        /// </param>
        /// <param name="generated">
        /// True if the token is inside of a block of generated code.
        /// </param>
        internal TypeToken(MasterList<CsToken> childTokens, CodeLocation location, Reference<ICodePart> parent, CsTokenClass tokenClass, bool generated)
            : base(CsTokenType.Other, tokenClass, location, parent, generated)
        {
            Param.AssertNotNull(childTokens, "childTokens");
            Param.AssertNotNull(location, "location");
            Param.AssertNotNull(parent, "parent");
            Param.AssertNotNull(tokenClass, "tokenClass");
            Param.Ignore(generated);

            this.childTokens = childTokens;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the list of child tokens within this token.
        /// </summary>
        public MasterList<CsToken> ChildTokens
        {
            get
            {
                return this.childTokens.AsReadOnly;
            }
        }

        #endregion

        #region Explicit Interface Properties

        /// <summary>
        /// Gets the list of child tokens contained within this object.
        /// </summary>
        [SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes", Justification = "The tokens list should be hidden")]
        ICollection<CsToken> ITokenContainer.Tokens
        {
            get
            {
                return this.childTokens.AsReadOnly;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Creates a text string based on the child tokens in the token.
        /// </summary>
        protected override void CreateTextString()
        {
            StringBuilder text = new StringBuilder();
            foreach (CsToken token in this.childTokens)
            {
                // Strip out comments and whitespace.
                if (token.CsTokenType != CsTokenType.WhiteSpace && token.CsTokenType != CsTokenType.EndOfLine && token.CsTokenType != CsTokenType.SingleLineComment
                    && token.CsTokenType != CsTokenType.MultiLineComment && token.CsTokenType != CsTokenType.PreprocessorDirective)
                {
                    text.Append(token.Text);
                }
            }

            this.Text = text.ToString();
        }

        #endregion
    }
}