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
        public IEnumerable<XmlHeaderLine> HeaderLines
        {
            get
            {
                return this.GetChildren<XmlHeaderLine>();
            }
        }

        /// <summary>
        /// Gets a value indicating whether the header contains anything other than whitespace.
        /// </summary>
        public bool IsEmpty
        {
            get
            {
                for (XmlHeaderLine headerLine = this.FindFirstChild<XmlHeaderLine>(); headerLine != null; headerLine = headerLine.FindNextSibling<XmlHeaderLine>())
                {
                    string text = headerLine.Text;
                    if (!string.IsNullOrEmpty(text))
                    {
                        // Start searching at index 3 to move past the initial '///' slashes.
                        for (int i = 3; i < text.Length; ++i)
                        {
                            if (!char.IsWhiteSpace(text[i]))
                            {
                                return false;
                            }
                        }
                    }
                }

                return true;
            }
        }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Gets the header Xml.
        /// </summary>
        /// <returns>Returnst the Xml</returns>
        public string GetHeaderXml()
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

            return text.ToString();
        }

        /// <summary>
        /// Gets the header Xml with original formatting included.
        /// </summary>
        /// <returns>Returns the formatted Xml.</returns>
        public string GetFormattedHeaderXml()
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

            return text.ToString();
        }

        #endregion Public Methods
    }
}
