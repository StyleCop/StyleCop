//-----------------------------------------------------------------------
// <copyright file="CsDocument.cs" company="Microsoft">
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
namespace Microsoft.StyleCop.CSharp_old
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Xml;
    using Microsoft.StyleCop;

    /// <summary>
    /// Represents a parsed C# document.
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1706:ShortAcronymsShouldBeUppercase", Justification = "Camel case better serves in this case.")]
    public sealed class CsDocument : CodeDocument, ICodePart, ITokenContainer
    {
        #region Private Fields

        /// <summary>
        /// The contents at the root of the document.
        /// </summary>
        private DocumentRoot contents;

        /// <summary>
        /// The list of tokens in the document.
        /// </summary>
        private MasterList<CsToken> tokens;

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
        /// <param name="tokens">The tokens in the document.</param>
        internal CsDocument(SourceCode sourceCode, CsParser parser, MasterList<CsToken> tokens)
            : base(sourceCode)
        {
            Param.AssertNotNull(sourceCode, "sourceCode");
            Param.AssertNotNull(parser, "parser");
            Param.Ignore(tokens);

            this.parser = parser;
            this.tokens = tokens;
        }

        /// <summary>
        /// Initializes a new instance of the CsDocument class.
        /// </summary>
        /// <param name="sourceCode">The source code that this document represents.</param>
        /// <param name="parser">The parser that is creating this object.</param>
        internal CsDocument(SourceCode sourceCode, CsParser parser)
            : this(sourceCode, parser, null)
        {
            Param.AssertNotNull(sourceCode, "sourceCode");
            Param.AssertNotNull(parser, "parser");

            this.tokens = new MasterList<CsToken>();
        }

        #endregion Internal Constructors

        #region Public Override Properties

        /// <summary>
        /// Gets the contents of the document at the root level.
        /// </summary>
        public override ICodeElement DocumentContents
        {
            get
            {
                return this.contents;
            }
        }

        #endregion Public Override Properties

        #region Public Properties

        /// <summary>
        /// Gets the list of tokens in the document.
        /// </summary>
        public MasterList<CsToken> Tokens
        {
            get
            {
                return this.tokens.AsReadOnly;
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

        /// <summary>
        /// Gets the parent of the document.
        /// </summary>
        public ICodePart Parent
        {
            get
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the location of the document.
        /// </summary>
        public CodeLocation Location
        {
            get
            {
                return CsToken.JoinLocations(this.tokens.First, this.tokens.Last);
            }
        }

        /// <summary>
        /// Gets the line number on which the document begins.
        /// </summary>
        public int LineNumber
        {
            get
            {
                return 1;
            }
        }

        /// <summary>
        /// Gets the type of this code part.
        /// </summary>
        public CodePartType CodePartType
        {
            get
            {
                return CodePartType.Document;
            }
        }

        #endregion Public Properties

        #region ITokenContainer Interface Properties

        /// <summary>
        /// Gets the list of child tokens contained within this object.
        /// </summary>
        ICollection<CsToken> ITokenContainer.Tokens
        {
            get
            {
                return this.tokens.AsReadOnly;
            }
        }

        #endregion ITokenContainer Interface Properties

        #region Internal Properties

        /// <summary>
        /// Gets a reference to a writable version of the token list for this document.
        /// </summary>
        internal MasterList<CsToken> MasterTokenList
        {
            get
            {
                return this.tokens;
            }
        }

        #endregion Internal Properties

        #region Public Methods

        /// <summary>
        /// Walks through the code units in the document.
        /// </summary>
        /// <param name="elementCallback">Callback executed when an element is visited.</param>
        /// <param name="statementCallback">Callback executed when a statement is visited.</param>
        /// <param name="expressionCallback">Callback executed when an expression is visited.</param>
        /// <param name="queryClauseCallback">Callback executed when a query clause is visited.</param>
        /// <param name="context">The optional visitor context data.</param>
        /// <typeparam name="T">The type of the context item.</typeparam>
        public void WalkDocument<T>(
            CodeWalkerElementVisitor<T> elementCallback,
            CodeWalkerStatementVisitor<T> statementCallback,
            CodeWalkerExpressionVisitor<T> expressionCallback,
            CodeWalkerQueryClauseVisitor<T> queryClauseCallback,
            T context)
        {
            Param.Ignore(elementCallback, statementCallback, expressionCallback, queryClauseCallback, context);
            CodeWalker<T>.Start(this, elementCallback, statementCallback, expressionCallback, queryClauseCallback, context);
        }

        /// <summary>
        /// Walks through the code units in the document.
        /// </summary>
        /// <param name="elementCallback">Callback executed when an element is visited.</param>
        /// <param name="statementCallback">Callback executed when a statement is visited.</param>
        /// <param name="expressionCallback">Callback executed when an expression is visited.</param>
        /// <param name="context">The optional visitor context data.</param>
        /// <typeparam name="T">The type of the context item.</typeparam>
        public void WalkDocument<T>(
            CodeWalkerElementVisitor<T> elementCallback,
            CodeWalkerStatementVisitor<T> statementCallback,
            CodeWalkerExpressionVisitor<T> expressionCallback,
            T context)
        {
            Param.Ignore(elementCallback, statementCallback, expressionCallback, context);
            this.WalkDocument(elementCallback, statementCallback, expressionCallback, null, context);
        }

        /// <summary>
        /// Walks through the code units in the document.
        /// </summary>
        /// <param name="elementCallback">Callback executed when an element is visited.</param>
        /// <param name="statementCallback">Callback executed when a statement is visited.</param>
        /// <param name="context">The optional visitor context data.</param>
        /// <typeparam name="T">The type of the context item.</typeparam>
        public void WalkDocument<T>(
            CodeWalkerElementVisitor<T> elementCallback,
            CodeWalkerStatementVisitor<T> statementCallback,
            T context)
        {
            Param.Ignore(elementCallback, statementCallback, context);
            this.WalkDocument(elementCallback, statementCallback, null, null, context);
        }

        /// <summary>
        /// Walks through the code units in the document.
        /// </summary>
        /// <param name="elementCallback">Callback executed when an element is visited.</param>
        /// <param name="context">The optional visitor context data.</param>
        /// <typeparam name="T">The type of the context item.</typeparam>
        public void WalkDocument<T>(
            CodeWalkerElementVisitor<T> elementCallback,
            T context)
        {
            Param.Ignore(elementCallback, context);
            this.WalkDocument(elementCallback, null, null, null, context);
        }

        /// <summary>
        /// Walks through the code units in the document.
        /// </summary>
        /// <param name="elementCallback">Callback executed when an element is visited.</param>
        /// <param name="statementCallback">Callback executed when a statement is visited.</param>
        /// <param name="expressionCallback">Callback executed when an expression is visited.</param>
        /// <param name="queryClauseCallback">Callback executed when a query clause is visited.</param>
        public void WalkDocument(
            CodeWalkerElementVisitor<object> elementCallback,
            CodeWalkerStatementVisitor<object> statementCallback,
            CodeWalkerExpressionVisitor<object> expressionCallback,
            CodeWalkerQueryClauseVisitor<object> queryClauseCallback)
        {
            Param.Ignore(elementCallback, statementCallback, expressionCallback, queryClauseCallback);
            CodeWalker<object>.Start(this, elementCallback, statementCallback, expressionCallback, queryClauseCallback, null);
        }

        /// <summary>
        /// Walks through the code units in the document.
        /// </summary>
        /// <param name="elementCallback">Callback executed when an element is visited.</param>
        /// <param name="statementCallback">Callback executed when a statement is visited.</param>
        /// <param name="expressionCallback">Callback executed when an expression is visited.</param>
        public void WalkDocument(
            CodeWalkerElementVisitor<object> elementCallback,
            CodeWalkerStatementVisitor<object> statementCallback,
            CodeWalkerExpressionVisitor<object> expressionCallback)
        {
            Param.Ignore(elementCallback, statementCallback, expressionCallback);
            this.WalkDocument(elementCallback, statementCallback, expressionCallback, null, null);
        }

        /// <summary>
        /// Walks through the code units in the document.
        /// </summary>
        /// <param name="elementCallback">Callback executed when an element is visited.</param>
        /// <param name="statementCallback">Callback executed when a statement is visited.</param>
        public void WalkDocument(
            CodeWalkerElementVisitor<object> elementCallback,
            CodeWalkerStatementVisitor<object> statementCallback)
        {
            Param.Ignore(elementCallback, statementCallback);
            this.WalkDocument(elementCallback, statementCallback, null, null, null);
        }

        /// <summary>
        /// Walks through the code units in the document.
        /// </summary>
        /// <param name="elementCallback">Callback executed when an element is visited.</param>
        public void WalkDocument(CodeWalkerElementVisitor<object> elementCallback)
        {
            Param.Ignore(elementCallback);
            this.WalkDocument(elementCallback, null, null, null, null);
        }

        #endregion Public Methods

        #region Protected Override Methods

        /// <summary>
        /// Disposes the contents of the class.
        /// </summary>
        /// <param name="disposing">Indicates whether to dispose unmanaged resources.</param>
        [SuppressMessage("Microsoft.Usage", "CA2215:DisposeMethodsShouldCallBaseClassDispose", Justification = "base.Dispose is called")]
        protected override void Dispose(bool disposing)
        {
            Param.Ignore(disposing);
            base.Dispose(disposing);

            if (disposing)
            {
                this.contents = null;
                this.tokens = null;
                this.fileHeader = null;
            }
        }

        #endregion Protected Override Methods
    }
}
