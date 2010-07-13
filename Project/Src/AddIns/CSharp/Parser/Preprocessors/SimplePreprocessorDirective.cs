//-----------------------------------------------------------------------
// <copyright file="SimplePreprocessorDirective.cs" company="Microsoft">
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
    /// Describes a preprocessor directive that contains no children.
    /// </summary>
    /// <subcategory>lexicalelement</subcategory>
    public abstract class SimplePreprocessorDirective : PreprocessorDirective
    {
        #region Private Fields

        /// <summary>
        /// The location of the item.
        /// </summary>
        private CodeLocation location;

        /// <summary>
        /// Indicates whether the item is generated.
        /// </summary>
        private bool? generated;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the SimplePreprocessorDirective class.
        /// </summary>
        /// <param name="document">The parent document.</param>
        /// <param name="text">The preprocessor directive text.</param>
        /// <param name="preprocessorDirectiveType">The preprocessor directive type.</param>
        /// <param name="location">The location of the directive within the code document.</param>
        /// <param name="generated">True if the directive is inside of a block of generated code.</param>
        internal SimplePreprocessorDirective(CsDocument document, string text, PreprocessorType preprocessorDirectiveType, CodeLocation location, bool generated)
            : base(new CodeUnitProxy(document), preprocessorDirectiveType)
        {
            Param.AssertNotNull(document, "document");
            Param.AssertValidString(text, "text");
            Param.Ignore(preprocessorDirectiveType);
            Param.AssertNotNull(location, "location");
            Param.Ignore(generated);

            this.Text = text;
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
