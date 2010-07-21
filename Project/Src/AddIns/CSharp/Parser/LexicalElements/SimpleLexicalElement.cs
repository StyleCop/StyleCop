//-----------------------------------------------------------------------
// <copyright file="SimpleLexicalElement.cs" company="Microsoft">
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
    /// Describes a lexical element that contains no children.
    /// </summary>
    /// <subcategory>lexicalelement</subcategory>
    public abstract class SimpleLexicalElement : LexicalElement
    {
        #region Private Fields

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
        /// Initializes a new instance of the SimpleLexicalElement class.
        /// </summary>
        /// <param name="document">The parent document.</param>
        /// <param name="lexicalElementType">The lexical element type.</param>
        /// <param name="location">The location of the lexical element within the code document.</param>
        /// <param name="generated">True if the lexical element is inside of a block of generated code.</param>
        internal SimpleLexicalElement(CsDocument document, LexicalElementType lexicalElementType, CodeLocation location, bool generated)
            : this(document, (int)lexicalElementType, location, generated)
        {
            Param.Ignore(document, lexicalElementType, location, generated);
        }

        /// <summary>
        /// Initializes a new instance of the SimpleLexicalElement class.
        /// </summary>
        /// <param name="document">The parent document.</param>
        /// <param name="lexicalElementType">The lexical element type.</param>
        /// <param name="location">The location of the lexical element within the code document.</param>
        /// <param name="generated">True if the lexical element is inside of a block of generated code.</param>
        internal SimpleLexicalElement(CsDocument document, int lexicalElementType, CodeLocation location, bool generated)
            : base(new CodeUnitProxy(document), lexicalElementType)
        {
            Param.AssertNotNull(document, "document");
            Param.Ignore(lexicalElementType, generated);
            Param.AssertNotNull(location, "location");
            Param.Ignore(generated);

            Debug.Assert(System.Enum.IsDefined(typeof(LexicalElementType), this.LexicalElementType), "The type is invalid.");
            this.location = location;
            this.generated = generated;
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

        /// <summary>
        /// Gets a value indicating whether the item comes from generated code.
        /// </summary>
        public override bool Generated
        {
            get
            {
                this.ValidateEditVersion();
                if (this.generated == null)
                {
                    this.generated = this.Parent.Generated;
                }

                return this.generated.Value;
            }
        }

        #endregion Public Override Properties

        #region Protected Override Methods

        /// <summary>
        /// Resets the contents of the item.
        /// </summary>
        protected override void Reset()
        {
            base.Reset();

            this.generated = null;
        }

        #endregion Protected Override Methods
    }
}
