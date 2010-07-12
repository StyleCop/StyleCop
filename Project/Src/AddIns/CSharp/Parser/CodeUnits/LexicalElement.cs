//-----------------------------------------------------------------------
// <copyright file="LexicalElement.cs" company="Microsoft">
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
        private string text;

        /// <summary>
        /// The location of the element.
        /// </summary>
        private CodeLocation location;

        /// <summary>
        /// Indicates whether the item is generated.
        /// </summary>
        private bool? generated;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the LexicalElement class.
        /// </summary>
        /// <param name="document">The parent document.</param>
        /// <param name="lexicalElementType">The lexical element type.</param>
        /// <param name="location">The location of the lexical element within the code document.</param>
        /// <param name="generated">True if the lexical element is inside of a block of generated code.</param>
        internal LexicalElement(CsDocument document, LexicalElementType lexicalElementType, CodeLocation location, bool generated)
            : this(document, (int)lexicalElementType, location, generated)
        {
            Param.Ignore(document, lexicalElementType, location, generated);
        }

        /// <summary>
        /// Initializes a new instance of the LexicalElement class.
        /// </summary>
        /// <param name="document">The parent document.</param>
        /// <param name="lexicalElementType">The lexical element type.</param>
        /// <param name="location">The location of the lexical element within the code document.</param>
        /// <param name="generated">True if the lexical element is inside of a block of generated code.</param>
        internal LexicalElement(CsDocument document, int lexicalElementType, CodeLocation location, bool generated)
            : base(document, (int)lexicalElementType)
        {
            Param.AssertNotNull(document, "document");
            Param.Ignore(lexicalElementType, generated);
            Param.AssertNotNull(location, "location");
            Param.Ignore(generated);

            Debug.Assert(System.Enum.IsDefined(typeof(LexicalElementType), this.LexicalElementType), "The type is invalid.");
            this.location = location;
            this.generated = generated;
        }

        /// <summary>
        /// Initializes a new instance of the LexicalElement class.
        /// </summary>
        /// <param name="lexicalElementType">The lexical element type.</param>
        /// <param name="proxy">The proxy for the element.</param>
        internal LexicalElement(LexicalElementType lexicalElementType, CodeUnitProxy proxy)
            : this((int)lexicalElementType, proxy)
        {
            Param.Ignore(lexicalElementType, proxy);
        }

        /// <summary>
        /// Initializes a new instance of the LexicalElement class.
        /// </summary>
        /// <param name="lexicalElementType">The lexical element type.</param>
        /// <param name="proxy">The proxy for the element.</param>
        internal LexicalElement(int lexicalElementType, CodeUnitProxy proxy)
            : base(proxy, (int)lexicalElementType)
        {
            Param.Ignore(lexicalElementType);
            Param.AssertNotNull(proxy, "proxy");

            Debug.Assert(System.Enum.IsDefined(typeof(LexicalElementType), this.LexicalElementType), "The type is invalid.");
        }

        #endregion Internal Constructors

        #region Public Override Properties

        /// <summary>
        /// Gets the location of this code unit within the document.
        /// </summary>
        public override CodeLocation Location
        {
            get
            {
                if (this.location == null)
                {
                    return base.Location;
                }

                return this.location;
            }
        }

        /// <summary>
        /// Gets the line number that this code unit appears on in the document.
        /// </summary>
        public override int LineNumber
        {
            get
            {
                if (this.location == null)
                {
                    return base.LineNumber;
                }

                return this.location.StartPoint.LineNumber;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the item comes from generated code.
        /// </summary>
        public override bool Generated
        {
            get
            {
                if (this.generated == null)
                {
                    return base.Generated;
                }

                return this.generated.Value;
            }
        }

        #endregion Public Override Properties

        #region Public Properties

        /// <summary>
        /// Gets or sets the lexical element string.
        /// </summary>
        public string Text
        {
            get
            {
                if (this.text == null)
                {
                    this.CreateTextString();

                    if (this.text == null)
                    {
                        this.text = string.Empty;
                    }
                }

                return this.text;
            }

            protected set
            {
                this.text = value;
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

        #endregion Protected Virtual Methods
    }
}
