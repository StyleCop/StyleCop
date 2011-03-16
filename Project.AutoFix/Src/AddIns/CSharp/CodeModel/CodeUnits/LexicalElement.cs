//-----------------------------------------------------------------------
// <copyright file="LexicalElement.cs">
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

    /// <summary>
    /// Describes a primitive lexical element within a C# document.
    /// </summary>
    /// <subcategory>lexicalelement</subcategory>
    public abstract class LexicalElement : CodeUnit
    {
        #region Internal Static Fields

        /// <summary>
        /// An empty array of lexical elements.
        /// </summary>
        internal static readonly LexicalElement[] EmptyLexicalElementArray = new LexicalElement[] { };

        #endregion Internal Static Fields

        #region Private Fields

        /// <summary>
        /// The element's text.
        /// </summary>
        private CodeUnitProperty<string> text;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the LexicalElement class.
        /// </summary>
        /// <param name="proxy">The proxy for the element.</param>
        /// <param name="lexicalElementType">The lexical element type.</param>
        /// <param name="location">The location of the element.</param>
        internal LexicalElement(CodeUnitProxy proxy, LexicalElementType lexicalElementType, CodeLocation location)
            : this(proxy, (int)lexicalElementType, location)
        {
            Param.Ignore(proxy, lexicalElementType, location);
        }

        /// <summary>
        /// Initializes a new instance of the LexicalElement class.
        /// </summary>
        /// <param name="proxy">The proxy for the element.</param>
        /// <param name="lexicalElementType">The lexical element type.</param>
        /// <param name="location">The location of the element.</param>
        internal LexicalElement(CodeUnitProxy proxy, int lexicalElementType, CodeLocation location)
            : base(proxy, (int)lexicalElementType, location)
        {
            Param.AssertNotNull(proxy, "proxy");
            Param.Ignore(lexicalElementType);
            Param.AssertNotNull(location, "location");

            CsLanguageService.Debug.Assert(System.Enum.IsDefined(typeof(LexicalElementType), this.LexicalElementType), "The type is invalid.");
        }

        /// <summary>
        /// Initializes a new instance of the LexicalElement class.
        /// </summary>
        /// <param name="proxy">The proxy for the element.</param>
        /// <param name="lexicalElementType">The lexical element type.</param>
        internal LexicalElement(CodeUnitProxy proxy, int lexicalElementType)
            : base(proxy, (int)lexicalElementType)
        {
            Param.AssertNotNull(proxy, "proxy");
            Param.Ignore(lexicalElementType);

            CsLanguageService.Debug.Assert(System.Enum.IsDefined(typeof(LexicalElementType), this.LexicalElementType), "The type is invalid.");
        }

        #endregion Internal Constructors

        #region Public Properties

        /// <summary>
        /// Gets or sets the lexical element string.
        /// </summary>
        public string Text
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.text.Initialized)
                {
                    this.text.Value = null;

                    this.CreateTextString();

                    if (this.text.Value == null)
                    {
                        this.text.Value = string.Empty;
                    }
                }

                return this.text.Value;
            }

            protected set
            {
                if (!this.text.Initialized || this.text.Value != value)
                {
                    this.text.Value = value;
                    this.OnTextChanged();
                }
            }
        }

        /// <summary>
        /// Gets the lexical element type.
        /// </summary>
        public LexicalElementType LexicalElementType
        {
            get
            {
                return (LexicalElementType)(this.FundamentalType & (int)FundamentalTypeMasks.LexicalElement);
            }
        }

        #endregion Public Properties

        #region Public Override Properties

        /// <summary>
        /// Gets a value indicating whether this is generated code.
        /// </summary>
        public override bool Generated
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.GeneratedProperty.Initialized)
                {
                    if (!this.AttachedToDocument)
                    {
                        this.Generated = false;
                    }
                    else
                    {
                        this.Document.Update();
                        CsLanguageService.Debug.Assert(this.GeneratedProperty.Initialized, "LexicalElement failed to initialize Generated property.");
                    }
                }

                return this.GeneratedProperty.Value;
            }
        }

        /// <summary>
        /// Gets the location of this code unit within the document.
        /// </summary>
        public override CodeLocation Location
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.LocationProperty.Initialized)
                {
                    if (this.Parent == null)
                    {
                        this.Location = CodeLocation.Empty;
                    }
                    else
                    {
                        this.Document.Update();
                        CsLanguageService.Debug.Assert(this.LocationProperty.Initialized, "LexicalElement failed to initialize Location property.");
                    }
                }

                return this.LocationProperty.Value;
            }
        }

        #endregion Public Override Properties

        #region Public Override Methods

        /// <summary>
        /// Returns the contents of the lexical element as a string.
        /// </summary>
        /// <returns>Returns the lexical element string.</returns>
        public override string ToString()
        {
            return this.Text;
        }

        #endregion Public Override Methods

        #region Protected Virtual Methods

        /// <summary>
        /// Creates the text string for the lexical element.
        /// </summary>
        protected virtual void CreateTextString()
        {
        }

        /// <summary>
        /// Called when the value of the text property changes.
        /// </summary>
        protected virtual void OnTextChanged()
        {
        }

        #endregion Protected Virtual Methods

        #region Protected Override Methods

        /// <summary>
        /// Resets the contents of the item.
        /// </summary>
        protected override void Reset()
        {
            base.Reset();

            // Only clear out the text if the item contains at least one child. Otherwise
            // this is a simple lexical element and we should allow it to keep its text intact
            // when something in the document changes.
            if (this.Children.Count > 0)
            {
                this.text.Reset();
            }
        }

        #endregion Protected Override Methods
    }
}
