//-----------------------------------------------------------------------
// <copyright file="XmlHeader.cs" company="Microsoft">
//   Copyright (c) Microsoft Corporation.
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
    using System.Text;

    /// <summary>
    /// Represents an Xml element header.
    /// </summary>
    public sealed class XmlHeader : CodeUnit
    {
        #region Private Fields

        /// <summary>
        /// The collection of lines within the header.
        /// </summary>
        private ICollection<XmlHeaderLine> headerLines;

        /// <summary>
        /// Indicates whether the header is empty.
        /// </summary>
        private bool? empty;

        /// <summary>
        /// The raw header xml.
        /// </summary>
        private string headerXml;

        /// <summary>
        /// The header xml with formatting included.
        /// </summary>
        private string formattedHeaderXml;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the XmlHeader class.
        /// </summary>
        /// <param name="proxy">Proxy object for the header.</param>
        internal XmlHeader(CodeUnitProxy proxy) 
            : base(proxy, CodeUnitType.XmlHeader)
        {
            Param.AssertNotNull(proxy, "proxy");
        }

        #endregion Internal Constructors

        #region Public Properties

        /// <summary>
        /// Gets the collection of header lines within the header.
        /// </summary>
        public ICollection<XmlHeaderLine> HeaderLines
        {
            get
            {
                this.ValidateEditVersion();
                if (this.headerLines == null)
                {
                    this.headerLines = new List<XmlHeaderLine>(this.GetChildren<XmlHeaderLine>()).AsReadOnly();
                }

                return this.headerLines;
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
                if (this.empty == null)
                {
                    this.empty = true;

                    for (XmlHeaderLine headerLine = this.FindFirstChild<XmlHeaderLine>(); headerLine != null; headerLine = headerLine.FindNextSibling<XmlHeaderLine>())
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
                                    this.empty = false;
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
                if (this.headerXml == null)
                {
                    StringBuilder text = new StringBuilder();

                    for (XmlHeaderLine headerLine = this.FindFirstChild<XmlHeaderLine>(); headerLine != null; headerLine = headerLine.FindNextSibling<XmlHeaderLine>())
                    {
                        string headerLineText = headerLine.Text;
                        if (headerLineText.StartsWith("///", StringComparison.Ordinal))
                        {
                            headerLineText = headerLineText.Substring(3, headerLineText.Length - 3);
                        }

                        text.Append(headerLineText);
                    }

                    this.headerXml = text.ToString();
                }

                return this.headerXml;
            }
        }

        /// <summary>
        /// Gets the header Xml with original formatting included.
        /// </summary>
        public string FormattedHeaderXml
        {
            get
            {
                this.ValidateEditVersion();
                if (this.formattedHeaderXml == null)
                {
                    StringBuilder text = new StringBuilder();

                    for (CodeUnit item = this.FindFirstChild<CodeUnit>(); item != null; item = item.FindNextSibling<CodeUnit>())
                    {
                        if (item.Is(CommentType.XmlHeaderLine))
                        {
                            string headerLineText = ((XmlHeaderLine)item).Text;
                            if (headerLineText.StartsWith("///", StringComparison.Ordinal))
                            {
                                headerLineText = headerLineText.Substring(3, headerLineText.Length - 3);
                            }

                            text.Append(headerLineText);
                        }
                        else if (item.Is(LexicalElementType.EndOfLine))
                        {
                            text.Append('\n');
                        }
                    }

                    this.formattedHeaderXml = text.ToString();
                }

                return this.formattedHeaderXml;
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

            this.headerLines = null;
            this.empty = null;
            this.headerXml = null;
            this.formattedHeaderXml = null;
        }

        #endregion Protected Override Methods
    }
}
