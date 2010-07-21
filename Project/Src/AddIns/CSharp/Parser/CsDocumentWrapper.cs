//-----------------------------------------------------------------------
// <copyright file="CsDocumentWrapper.cs" company="Microsoft">
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
    using System.IO;
    using Microsoft.StyleCop.CSharp.CodeModel;

    /// <summary>
    /// Wraps a <see cref="CsDocument" /> to add necessary StyleCop document support.
    /// </summary>
    internal class CsDocumentWrapper : ElementWrapper, ICodeDocument
    {
        /// <summary>
        /// The source code that this document is based on.
        /// </summary>
        private SourceCode sourceCode;

        /// <summary>
        /// The wrapped document.
        /// </summary>
        private CsDocument document;

        /// <summary>
        /// Indicates whether the document is read-only.
        /// </summary>
        private bool readOnly = true;

        /// <summary>
        /// The parser associated with this element.
        /// </summary>
        private CsParser parser;

        /// <summary>
        /// Storage space for analyzer data.
        /// </summary>
        private Dictionary<string, object> analyzerData = new Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the CsDocumentWrapper class.
        /// </summary>
        /// <param name="parser">The parser.</param>
        /// <param name="sourceCode">The original source code.</param>
        public CsDocumentWrapper(CsParser parser, SourceCode sourceCode) 
        {
            Param.AssertNotNull(parser, "parser");
            Param.AssertNotNull(sourceCode, "sourceCode");

            this.parser = parser;
            this.sourceCode = sourceCode;
        }

        /// <summary>
        /// Initializes a new instance of the CsDocumentWrapper class.
        /// </summary>
        /// <param name="parser">The parser.</param>
        /// <param name="sourceCode">The original source code.</param>
        /// <param name="document">The document to wrap.</param>
        public CsDocumentWrapper(CsParser parser, SourceCode sourceCode, CsDocument document) 
            : base(document)
        {
            Param.AssertNotNull(parser, "parser");
            Param.AssertNotNull(sourceCode, "sourceCode");
            Param.AssertNotNull(document, "document");

            this.parser = parser;
            this.sourceCode = sourceCode;
            this.document = document;
        }

        /// <summary>
        /// Gets the inner document.
        /// </summary>
        public CsDocument CsDocument
        {
            get
            {
                return this.document;
            }
        }

        /// <summary>
        /// Gets the parsed contents of the document.
        /// </summary>
        public ICodeElement DocumentContents 
        {
            get
            {
                return this;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the document is read-only.
        /// </summary>
        /// <summary>
        /// Gets or sets a value indicating whether the document is read-only.
        /// </summary>
        public bool ReadOnly
        {
            get
            {
                return this.readOnly;
            }

            set
            {
                Param.Ignore(value);
                this.readOnly = value;
            }
        }

        /// <summary>
        /// Gets the settings for the the project that contains the document.
        /// </summary>
        public Settings Settings
        {
            get
            {
                if (this.sourceCode != null)
                {
                    return this.sourceCode.Settings;
                }

                return null;
            }
        }

        /// <summary>
        /// Gets the analyzer data dictionary for the document.
        /// </summary>
        public Dictionary<string, object> AnalyzerData
        {
            get
            {
                return this.analyzerData;
            }
        }

        /// <summary>
        /// Gets the original source code document.
        /// </summary>
        public SourceCode SourceCode 
        {
            get
            {
                return this.sourceCode;
            }
        }

        /// <summary>
        /// Gets the parser that this document is associated with.
        /// </summary>
        public CsParser Parser
        {
            get
            {
                return this.parser;
            }
        }

        /// <summary>
        /// Gets a document wrapper for the given document.
        /// </summary>
        /// <param name="document">The document.</param>
        /// <returns>Returns the wrapper.</returns>
        public static CsDocumentWrapper Wrapper(CsDocument document)
        {
            Param.AssertNotNull(document, "document");

            Debug.Assert(document.Tag != null, "Wrapper has not been set");
            return (CsDocumentWrapper)document.Tag;
        }

        /// <summary>
        /// Disposes the contents of the class.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Writes the contents of the document to the given writer.
        /// </summary>
        /// <param name="writer">The writer.</param>
        public void Write(TextWriter writer)
        {
            Param.AssertNotNull(writer, "writer");
            this.document.Write(writer);
        }

        /// <summary>
        /// Disposes the contents of the class.
        /// </summary>
        /// <param name="disposing">Indicates whether to dispose unmanaged resources.</param>
        private void Dispose(bool disposing)
        {
            Param.Ignore(disposing);
        }
    }
}
