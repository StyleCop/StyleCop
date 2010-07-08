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

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the LexicalElement class.
        /// </summary>
        /// <param name="proxy">Proxy object for the lexical element.</param>
        /// <param name="lexicalElementType">The lexical element type.</param>
        /// <param name="location">The location of the lexical element within the code document.</param>
        /// <param name="generated">True if the lexical element is inside of a block of generated code.</param>
        internal LexicalElement(CodeUnitProxy proxy, int lexicalElementType, CodeLocation location, bool generated)
            : base(proxy, lexicalElementType, generated)
        {
            Param.Ignore(proxy);
            Param.Ignore(lexicalElementType);
            Param.AssertNotNull(location, "location");
            Param.Ignore(generated);

            Debug.Assert(System.Enum.IsDefined(typeof(LexicalElementType), this.LexicalElementType), "The type is invalid.");
            this.location = location;
        }

        #endregion Internal Constructors

        #region Protected Constructors

        /// <summary>
        /// Initializes a new instance of the LexicalElement class.
        /// </summary>
        /// <param name="lexicalElementType">The lexical element type.</param>
        /// <param name="location">The location of the lexical element within the code document.</param>
        /// <param name="generated">True if the lexical element is inside of a block of generated code.</param>
        protected LexicalElement(LexicalElementType lexicalElementType, CodeLocation location, bool generated)
            : this(null, (int)lexicalElementType, location, generated)
        {
            Param.Ignore(lexicalElementType, location, generated);
        }

        #endregion Protected Constructors

        #region Public Override Properties

        /// <summary>
        /// Gets the location of this code unit within the document.
        /// </summary>
        public override CodeLocation Location
        {
            get
            {
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
                return this.location.StartPoint.LineNumber;
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
