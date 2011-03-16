//-----------------------------------------------------------------------
// <copyright file="ElementHeader.cs">
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
    using System.Text;

    /// <summary>
    /// Represents an <see cref="Element"/> header.
    /// </summary>
    public sealed class ElementHeader : CodeUnit
    {
        #region Private Fields

        /// <summary>
        /// The collection of lines within the header.
        /// </summary>
        private CodeUnitProperty<ICollection<ElementHeaderLine>> headerLines;

        /// <summary>
        /// Indicates whether the header is empty.
        /// </summary>
        private CodeUnitProperty<bool> empty;

        /// <summary>
        /// The raw header xml.
        /// </summary>
        private CodeUnitProperty<string> headerXml;

        /// <summary>
        /// The header xml with formatting included.
        /// </summary>
        private CodeUnitProperty<string> headerXmlWithNewlines;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the ElementHeader class.
        /// </summary>
        /// <param name="proxy">Proxy object for the header.</param>
        internal ElementHeader(CodeUnitProxy proxy) 
            : base(proxy, CodeUnitType.ElementHeader)
        {
            Param.AssertNotNull(proxy, "proxy");
        }

        #endregion Internal Constructors

        #region Public Properties

        /// <summary>
        /// Gets the collection of header lines within the header.
        /// </summary>
        public ICollection<ElementHeaderLine> HeaderLines
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.headerLines.Initialized)
                {
                    this.headerLines.Value = new List<ElementHeaderLine>(this.GetChildren<ElementHeaderLine>()).AsReadOnly();
                }

                return this.headerLines.Value;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the header contains anything other than whitespace.
        /// </summary>
        public bool IsEmpty
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.empty.Initialized)
                {
                    this.empty.Value = true;

                    for (ElementHeaderLine headerLine = this.FindFirstChild<ElementHeaderLine>(); headerLine != null; headerLine = headerLine.FindNextSibling<ElementHeaderLine>())
                    {
                        if (!this.empty.Value)
                        {
                            break;
                        }

                        string text = headerLine.Text;
                        if (!string.IsNullOrEmpty(text))
                        {
                            // Start searching at index 3 to move past the initial '///' slashes.
                            for (int i = 3; i < text.Length; ++i)
                            {
                                if (!char.IsWhiteSpace(text[i]))
                                {
                                    this.empty.Value = false;
                                    break;
                                }
                            }
                        }
                    }
                }

                return this.empty.Value;
            }
        }

        /// <summary>
        /// Gets the header Xml.
        /// </summary>
        public string HeaderXml
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.headerXml.Initialized)
                {
                    StringBuilder text = new StringBuilder();

                    for (ElementHeaderLine headerLine = this.FindFirstChild<ElementHeaderLine>(); headerLine != null; headerLine = headerLine.FindNextSibling<ElementHeaderLine>())
                    {
                        text.Append(ExtractHeaderLineText(headerLine));
                    }

                    this.headerXml.Value = text.ToString();
                }

                return this.headerXml.Value;
            }
        }

        /// <summary>
        /// Gets the header Xml with original newlines included.
        /// </summary>
        public string HeaderXmlWithNewlines
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.headerXmlWithNewlines.Initialized)
                {
                    StringBuilder text = new StringBuilder();

                    for (CodeUnit item = this.FindFirstChild(); item != null; item = item.FindNextSibling())
                    {
                        if (item.Is(CommentType.ElementHeaderLine))
                        {
                            text.Append(ExtractHeaderLineText((ElementHeaderLine)item));
                        }
                        else if (item.Is(LexicalElementType.EndOfLine))
                        {
                            text.Append('\n');
                        }
                    }

                    this.headerXmlWithNewlines.Value = text.ToString();
                }

                return this.headerXmlWithNewlines.Value;
            }
        }
        
        #endregion Public Properties

        #region Protected Override Methods

        /// <summary>
        /// Resets the contents of the item.
        /// </summary>
        protected override void Reset()
        {
            base.Reset();

            this.headerLines.Reset();
            this.empty.Reset();
            this.headerXml.Reset();
            this.headerXmlWithNewlines.Reset();
        }

        #endregion Protected Override Methods

        #region Private Static Methods

        /// <summary>
        /// Extracts the raw text from a header line.
        /// </summary>
        /// <param name="headerLine">The header line.</param>
        /// <returns>Returns the raw text.</returns>
        private static string ExtractHeaderLineText(ElementHeaderLine headerLine)
        {
            Param.AssertNotNull(headerLine, "headerLine");

            string headerLineText = headerLine.Text;
            if (headerLineText.StartsWith("///", StringComparison.Ordinal))
            {
                // Typically, the header line will begin with a single space after the three slashes. We should not
                // consider this space to be part of the documentation, so skip past it.
                int startIndex = 3;
                if (headerLineText.Length > 3 && headerLineText[3] == ' ')
                {
                    startIndex = 4;
                }

                headerLineText = headerLineText.Substring(startIndex, headerLineText.Length - startIndex);
            }

            return headerLineText;
        }

        #endregion Private Static Methods
    }
}
