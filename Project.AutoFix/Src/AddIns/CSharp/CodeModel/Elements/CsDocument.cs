//-----------------------------------------------------------------------
// <copyright file="CsDocument.cs">
//     MS-PL
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
    using System.IO;
    using StyleCop;

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

        /// <summary>
        /// Indicates whether the document has been altered since it was first initialized.
        /// </summary>
        private bool dirty;

        /// <summary>
        /// The optional partial elements service.
        /// </summary>
        private IPartialElementsService partialElementsService;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the CsDocument class.
        /// </summary>
        /// <param name="proxy">Proxy object for the document.</param>
        /// <param name="name">The name of the document.</param>
        /// <param name="path">The path to the original source.</param>
        /// <param name="partialElementsService">The optional partial elements service.</param>
        internal CsDocument(CodeUnitProxy proxy, string name, string path, IPartialElementsService partialElementsService)
            : base(proxy, ElementType.Document, name, null, false)
        {
            Param.AssertNotNull(proxy, "proxy");
            Param.AssertValidString(name, "name");
            Param.AssertValidString(path, "path");
            Param.Ignore(partialElementsService);

            this.name = name;
            this.path = path;
            this.partialElementsService = partialElementsService;
        }

        #endregion Internal Constructors

        #region Public Override Properties

        /// <summary>
        /// Gets a value indicating whether the document contains generated code.
        /// </summary>
        public override bool Generated
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.GeneratedProperty.Initialized)
                {
                    this.Generated = this.FileHeader == null ? false : this.FileHeader.Generated;
                }

                return this.GeneratedProperty.Value;
            }
        }

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

        /// <summary>
        /// Gets the optional partial elements service, if one has been provided.
        /// </summary>
        public IPartialElementsService PartialElementsService
        {
            get
            {
                return this.partialElementsService;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the document has been altered since it was first initialized.
        /// </summary>
        public bool Dirty
        {
            get
            {
                return this.dirty;
            }

            set
            {
                Param.Ignore(value);
                this.dirty = value;
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

            for (LexicalElement item = this.FindFirstLexicalElement(); item != null; item = item.FindNextLexicalElement())
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
                    item = item.FindLastLexicalElement();
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

        #region Internal Methods

        /// <summary>
        /// Increments the edit version of the document.
        /// </summary>
        internal void IncrementEditVersion()
        {
            if (this.EditVersion == uint.MaxValue)
            {
                this.EditVersion = 0;
            }
            else
            {
                this.EditVersion = this.EditVersion + 1;
            }

            // The document is dirty, since it was edited.
            this.dirty = true;
        }

        /// <summary>
        /// Updates the regions, generated code status, and locations of items in the document.
        /// </summary>
        internal void Update()
        {
            int lineNumber = 1;
            int indexOnLine = 0;
            int indexInDocument = 0;

            int generatedCount = 0;
            Stack<RegionDirective> regionStack = new Stack<RegionDirective>();

            // If the document is marked as generated, then treat everything in the document as generated.
            if (this.Generated)
            {
                ++generatedCount;
            }

            for (LexicalElement lex = this.FindFirstLexicalElement(); lex != null; lex = lex.FindNextLexicalElement())
            {
                if (!lex.Parent.Is(CodeUnitType.LexicalElement))
                {
                    lex.Location = CalculateLocation(lex, ref lineNumber, ref indexOnLine, ref indexInDocument);
                }

                if (lex.Children.LexicalElementCount > 0)
                {
                    SetLexicalElementChildLocations(lex);
                }

                lex.Generated = generatedCount > 0;

                if (lex.Is(PreprocessorType.Region))
                {
                    RegionDirective region = (RegionDirective)lex;
                    regionStack.Push(region);

                    if (region.IsGeneratedCodeRegion)
                    {
                        ++generatedCount;
                    }
                }
                else if (lex.Is(PreprocessorType.EndRegion))
                {
                    EndRegionDirective endRegion = (EndRegionDirective)lex;

                    if (regionStack.Count == 0)
                    {
                        throw new SyntaxException(this.Document, endRegion.LineNumber, Strings.NoMatchingRegion);
                    }

                    RegionDirective region = regionStack.Pop();

                    endRegion.Partner = region;
                    region.Partner = endRegion;

                    if (region.IsGeneratedCodeRegion)
                    {
                        --generatedCount;
                    }
                }
            }

            if (regionStack.Count > 0)
            {
                throw new SyntaxException(this.Document, this.LineNumber, Strings.NoMatchingEndregion);
            }
        }

        #endregion Internal Methods

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

        #region Private Static Methods

        /// <summary>
        /// Calculates the location of the given element, and advances the starting location past this element for the next item.
        /// </summary>
        /// <param name="lex">The element.</param>
        /// <param name="lineNumber">The starting line number.</param>
        /// <param name="indexOnLine">The starting index of the item on the line.</param>
        /// <param name="indexInDocument">The start index of the item within the document.</param>
        /// <returns>Returns the location of the item.</returns>
        private static CodeLocation CalculateLocation(LexicalElement lex, ref int lineNumber, ref int indexOnLine, ref int indexInDocument)
        {
            Param.AssertNotNull(lex, "lex");
            Param.AssertGreaterThanZero(lineNumber, "lineNumber");
            Param.AssertGreaterThanOrEqualToZero(indexOnLine, "indexOnLine");
            Param.AssertGreaterThanOrEqualToZero(indexInDocument, "indexInDocument");

            string text = lex.Text;
            if (string.IsNullOrEmpty(text))
            {
                return new CodeLocation(indexInDocument, indexInDocument, indexOnLine, indexOnLine, lineNumber, lineNumber);
            }

            int endLineNumber = lineNumber;
            int endIndexOnLine = indexOnLine;
            int endIndexInDocument = indexInDocument;

            for (int i = 0; i < text.Length; ++i)
            {
                ++endIndexInDocument;

                if (i > 0 && text[i - 1] == '\n')
                {
                    ++endLineNumber;
                    endIndexOnLine = 0;
                }
                else
                {
                    ++endIndexOnLine;
                }
            }

            var location = new CodeLocation(indexInDocument, endIndexInDocument, indexOnLine, endIndexOnLine, lineNumber, endLineNumber);

            lineNumber = endLineNumber;
            indexOnLine = endIndexOnLine + 1;
            indexInDocument = endIndexInDocument + 1;

            if (text[text.Length - 1] == '\n')
            {
                ++lineNumber;
                indexOnLine = 0;
            }

            return location;
        }

        /// <summary>
        /// Fills in the locations of child elements within a lexical element.
        /// </summary>
        /// <param name="lex">The lexical element.</param>
        private static void SetLexicalElementChildLocations(LexicalElement lex)
        {
            Param.AssertNotNull(lex, "lex");

            int lineNumber = lex.Location.StartPoint.LineNumber;
            int indexOnLine = lex.Location.StartPoint.Index;
            int indexInDocument = lex.Location.StartPoint.Index;

            for (LexicalElement child = lex.FindFirstChildLexicalElement(); child != null; child = child.FindNextSiblingLexicalElement())
            {
                child.Location = CalculateLocation(child, ref lineNumber, ref indexOnLine, ref indexInDocument);

                if (child.Children.Count > 0)
                {
                    SetLexicalElementChildLocations(child);
                }
            }
        }

        #endregion Private Static Methods
    }
}
