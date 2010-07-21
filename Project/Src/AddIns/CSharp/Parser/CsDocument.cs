//-----------------------------------------------------------------------
// <copyright file="CsDocument.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
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
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using Microsoft.StyleCop;

    /// <summary>
    /// Represents a parsed C# document.
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1706:ShortAcronymsShouldBeUppercase", Justification = "Camel case better serves in this case.")]
    public sealed class CsDocument : ICodeDocument
    {
        #region Private Fields

        /// <summary>
        /// The original source code document.
        /// </summary>
        private SourceCode sourceCode;

        /// <summary>
        /// Storage space for analyzer data.
        /// </summary>
        private Dictionary<string, object> analyzerData = new Dictionary<string, object>();

        /// <summary>
        /// Indicates whether the document is read-only.
        /// </summary>
        private bool readOnly = true;

        /// <summary>
        /// The contents at the root of the document.
        /// </summary>
        private DocumentRoot contents;

        /// <summary>
        /// The file header.
        /// </summary>
        private FileHeader fileHeader;

        /// <summary>
        /// The parser that created this object.
        /// </summary>        
        private CsParser parser;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the CsDocument class.
        /// </summary>
        /// <param name="sourceCode">The source code that this document represents.</param>
        /// <param name="parser">The parser that is creating this object.</param>
        internal CsDocument(SourceCode sourceCode, CsParser parser)
        {
            Param.AssertNotNull(sourceCode, "sourceCode");
            Param.AssertNotNull(parser, "parser");

            this.sourceCode = sourceCode;
            this.parser = parser;
        }

        #endregion Internal Constructors

        #region Public Properties

        /// <summary>
        /// Gets the contents of the document at the root level.
        /// </summary>
        public ICodeElement DocumentContents
        {
            get
            {
                return this.contents;
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
                this.readOnly = value;
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
        /// Gets the root element for this document.
        /// </summary>
        public DocumentRoot RootElement
        {
            get
            {
                return this.contents;
            }

            internal set
            {
                this.contents = value;
            }
        }

        /// <summary>
        /// Gets the file header, if any.
        /// </summary>
        public FileHeader FileHeader
        {
            get
            {
                return this.fileHeader;
            }

            internal set
            {
                this.fileHeader = value;
            }
        }

        /// <summary>
        /// Gets the parser that created this document.
        /// </summary>
        public CsParser Parser
        {
            get
            {
                return this.parser;
            }
        }

        #endregion Public Properties

        #region Public Methods

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
            Param.RequireNotNull(writer, "writer");

            if (this.contents != null)
            {
                for (LexicalElement item = this.contents.FindFirstInTree<LexicalElement>(); item != null; item = item.FindNext<LexicalElement>())
                {
                    if (item.LexicalElementType == LexicalElementType.PreprocessorDirective || item.Children.LexicalElementCount == 0)
                    {
                        if (item.LexicalElementType == LexicalElementType.EndOfLine)
                        {
                            writer.WriteLine();
                        }
                        else
                        {
                            writer.Write(item.Text);
                        }
                    }

                    if (item.LexicalElementType == LexicalElementType.PreprocessorDirective)
                    {
                        item = item.FindLastInTree<LexicalElement>();
                    }
                }
            }
        }

        /// <summary>
        /// Walks through the code units beneath this document.
        /// </summary>
        /// <param name="callback">Callback executed when a code unit is visited.</param>
        /// <param name="context">The optional visitor context data.</param>
        /// <param name="codeUnitTypes">The types of code units to visit.</param>
        /// <typeparam name="T">The type of the context item.</typeparam>
        public void WalkCodeModel<T>(CodeUnitVisitor<T> callback, T context, params CodeUnitType[] codeUnitTypes)
        {
            Param.RequireNotNull(callback, "callback");
            Param.Ignore(context);
            Param.Ignore(codeUnitTypes);

            CodeWalker<T>.Start(this, callback, context, codeUnitTypes);
        }

        /// <summary>
        /// Walks through the code units beneath this document.
        /// </summary>
        /// <param name="callback">Callback executed when a code unit is visited.</param>
        /// <param name="context">The optional visitor context data.</param>
        /// <typeparam name="T">The type of the context item.</typeparam>
        public void WalkCodeModel<T>(CodeUnitVisitor<T> callback, T context)
        {
            Param.RequireNotNull(callback, "callback");
            Param.Ignore(context);

            CodeWalker<T>.Start(this, callback, context, null);
        }

        /// <summary>
        /// Walks through the code units beneath this document.
        /// </summary>
        /// <param name="callback">Callback executed when a code unit is visited.</param>
        /// <param name="codeUnitTypes">The types of code units to visit.</param>
        public void WalkCodeModel(CodeUnitVisitor<object> callback, params CodeUnitType[] codeUnitTypes)
        {
            Param.RequireNotNull(callback, "callback");
            Param.Ignore(codeUnitTypes);

            CodeWalker<object>.Start(this, callback, null, codeUnitTypes);
        }

        /// <summary>
        /// Walks through the code units beneath this document.
        /// </summary>
        /// <param name="callback">Callback executed when a code unit is visited.</param>
        public void WalkCodeModel(CodeUnitVisitor<object> callback)
        {
            Param.RequireNotNull(callback, "callback");

            CodeWalker<object>.Start(this, callback, null, null);
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Disposes the contents of the class.
        /// </summary>
        /// <param name="disposing">Indicates whether to dispose unmanaged resources.</param>
        private void Dispose(bool disposing)
        {
            Param.Ignore(disposing);

            if (disposing)
            {
                this.contents = null;
                this.fileHeader = null;
            }
        }

        #endregion Private Methods
    }
}
