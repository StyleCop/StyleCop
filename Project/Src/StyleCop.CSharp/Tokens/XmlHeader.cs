// --------------------------------------------------------------------------------------------------------------------
// <copyright file="XmlHeader.cs" company="https://github.com/StyleCop">
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
//   Represents an Xml element header.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Text;

    /// <summary>
    /// Represents an Xml element header.
    /// </summary>
    /// <subcategory>token</subcategory>
    public sealed class XmlHeader : CsToken, ITokenContainer
    {
        #region Fields

        /// <summary>
        /// The list of tokens in the header.
        /// </summary>
        private readonly MasterList<CsToken> childTokens;

        /// <summary>
        /// The text string with formatting still in place.
        /// </summary>
        private string rawText;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the XmlHeader class.
        /// </summary>
        /// <param name="childTokens">
        /// The list of tokens in the header.
        /// </param>
        /// <param name="location">
        /// The location of the header within the code.
        /// </param>
        /// <param name="parent">
        /// The parent of the header.
        /// </param>
        /// <param name="generated">
        /// Indicates whether the header resides within generated code.
        /// </param>
        internal XmlHeader(MasterList<CsToken> childTokens, CodeLocation location, Reference<ICodePart> parent, bool generated)
            : base(CsTokenType.XmlHeader, CsTokenClass.XmlHeader, location, parent, generated)
        {
            Param.AssertNotNull(childTokens, "childDokens");
            Param.AssertNotNull(location, "location");
            Param.AssertNotNull(parent, "parent");
            Param.Ignore(generated);

            this.childTokens = childTokens;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the list of tokens in the header.
        /// </summary>
        public MasterList<CsToken> ChildTokens
        {
            get
            {
                return this.childTokens.AsReadOnly;
            }
        }

        /// <summary>
        /// Gets the element that this header is attached to, if any.
        /// </summary>
        public CsElement Element { get; internal set; }

        /// <summary>
        /// Gets the contents of the header with whitespace, newlines, and formatting left in place.
        /// </summary>
        public string RawText
        {
            get
            {
                if (this.rawText == null)
                {
                    this.CreateRawTextString();
                }

                return this.rawText;
            }
        }

        #endregion

        #region Explicit Interface Properties

        /// <summary>
        /// Gets the list of child tokens contained within this object.
        /// </summary>
        [SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes", Justification = "The tokens list should be hidden.")]
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
        /// Creates a text string from the contents of the header.
        /// </summary>
        protected override void CreateTextString()
        {
            // Create a StringBuilder for putting together the parts of the header text.
            StringBuilder text = new StringBuilder();

            // Loop through all the tokens in the header.
            foreach (CsToken token in this.childTokens)
            {
                // Add the Xml header lines to the text string.
                if (token.CsTokenType == CsTokenType.XmlHeaderLine)
                {
                    text.Append(ExtractTextFromHeaderLine(token.Text));
                }
            }

            // Set the final text string.
            this.Text = text.ToString();
        }

        /// <summary>
        /// Extracts the header text from the header line.
        /// </summary>
        /// <param name="originalText">
        /// The original header line text.
        /// </param>
        /// <returns>
        /// Returns the extracted text.
        /// </returns>
        private static string ExtractTextFromHeaderLine(string originalText)
        {
            Param.Assert(originalText != null && originalText.StartsWith("///", StringComparison.Ordinal), "originalText", "Expected the text to start with ///");

            // Typically, the header line will begin with a single space after the three slashes. We should not
            // consider this space to be part of the documentation, so skip past it.
            int startIndex = 3;
            if (originalText.Length > 3 && originalText[3] == ' ')
            {
                startIndex = 4;
            }

            return originalText.Substring(startIndex, originalText.Length - startIndex);
        }

        /// <summary>
        /// Creates a raw text string with whitespace and newlines left in place.
        /// </summary>
        private void CreateRawTextString()
        {
            // Create a StringBuilder for putting together the parts of the header text.
            StringBuilder text = new StringBuilder();

            // Loop through all the tokens in the header.
            foreach (CsToken token in this.childTokens)
            {
                // Add the Xml header lines to the text string.
                if (token.CsTokenType == CsTokenType.XmlHeaderLine)
                {
                    text.Append(ExtractTextFromHeaderLine(token.Text));
                }
                else if (token.CsTokenType == CSharp.CsTokenType.EndOfLine)
                {
                    text.Append('\n');
                }
            }

            // Set the final text string.
            this.rawText = text.ToString();
        }

        #endregion
    }
}