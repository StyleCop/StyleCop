//-----------------------------------------------------------------------
// <copyright file="CsDocument.cs" company="Microsoft">
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
namespace Microsoft.StyleCop.CSharp.CodeModel
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using Microsoft.StyleCop;

    /// <summary>
    /// Represents a parsed C# code stream.
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1706:ShortAcronymsShouldBeUppercase", Justification = "Camel case better serves in this case.")]
    public sealed partial class CsDocument : Element
    {
        #region Private Fields

        /// <summary>
        /// The optional file header.
        /// </summary>
        private CodeUnitProperty<FileHeader> fileHeader;

        /// <summary>
        /// The name of the document.
        /// </summary>
        private string name;

        /// <summary>
        /// The path to the original source.
        /// </summary>
        private string path;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the CsDocument class.
        /// </summary>
        /// <param name="proxy">Proxy object for the document.</param>
        /// <param name="name">The name of the document.</param>
        /// <param name="path">The path to the original source.</param>
        internal CsDocument(CodeUnitProxy proxy, string name, string path)
            : base(proxy, ElementType.Document, name, null, false)
        {
            Param.AssertNotNull(proxy, "proxy");
            Param.AssertValidString(name, "name");
            Param.AssertValidString(path, "path");

            this.name = name;
            this.path = path;
        }

        #endregion Internal Constructors

        #region Public Override Properties

        /// <summary>
        /// Gets this document.
        /// </summary>
        public override CsDocument Document
        {
            get
            {
                return this;
            }
        }

        #endregion Public Override Properties

        #region Public Properties

        /// <summary>
        /// Gets the file header, if any.
        /// </summary>
        public FileHeader FileHeader
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.fileHeader.Initialized)
                {
                    this.fileHeader.Value = this.FindFirstChild<FileHeader>();
                }

                return this.fileHeader.Value;
            }
        }

        /// <summary>
        /// Gets the path to the original source code from which this document was created.
        /// </summary>
        public string Path
        {
            get
            {
                return this.path;
            }
        }

        #endregion Public Properties

        #region Protected Override Properties

        /// <summary>
        /// Gets the default access modifier for this type.
        /// </summary>
        protected override AccessModifierType DefaultAccessModifierType
        {
            get
            {
                return AccessModifierType.Public;
            }
        }

        #endregion Protected Override Properties

        #region Public Methods

        /// <summary>
        /// Writes the contents of the document to the given writer.
        /// </summary>
        /// <param name="writer">The writer.</param>
        public void Write(TextWriter writer)
        {
            Param.RequireNotNull(writer, "writer");

            for (LexicalElement item = this.FindFirstInTree<LexicalElement>(); item != null; item = item.FindNext<LexicalElement>())
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

        #region Protected Override Methods

        /// <summary>
        /// Resets the contents of the class.
        /// </summary>
        protected override void Reset()
        {
            base.Reset();

            this.fileHeader.Reset();
        }

        /// <summary>
        /// Gets the name of the element.
        /// </summary>
        /// <returns>The name of the element.</returns>
        protected override string GetElementName()
        {
            return this.name;
        }

        #endregion Protected Override Methods
    }
}
