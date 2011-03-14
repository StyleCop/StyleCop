//-----------------------------------------------------------------------
// <copyright file="Region.cs">
//   MS-PL
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
namespace StyleCop.CSharp
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text;

    /// <summary>
    /// Describes a region directive.
    /// </summary>
    /// <subcategory>token</subcategory>
    public sealed class Region : Preprocessor
    {
        #region Private Fields

        /// <summary>
        /// Indicates whether this is a beginning region.
        /// </summary>
        private bool beginning;

        /// <summary>
        /// The partner of this region tag.
        /// </summary>
        private Region partner;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the Region class.
        /// </summary>
        /// <param name="text">The line text.</param>
        /// <param name="location">The location of the preprocessor in the code.</param>
        /// <param name="parent">The parent of the region.</param>
        /// <param name="beginning">Indicates whether this is a beginning region.</param>
        /// <param name="generated">Indicates whether the preprocessor lies within a block of generated code.</param>
        internal Region(string text, CodeLocation location, Reference<ICodePart> parent, bool beginning, bool generated)
            : base(text, CsTokenClass.RegionDirective, location, parent, generated)
        {
            Param.AssertValidString(text, "text");
            Param.AssertNotNull(location, "location");
            Param.AssertNotNull(parent, "parent");
            Param.Ignore(beginning);
            Param.Ignore(generated);

            this.beginning = beginning;
        }

        #endregion Internal Constructors

        #region Public Properties

        /// <summary>
        /// Gets a value indicating whether this is the beginning of a region block.
        /// </summary>
        /// <remarks>A value of false indicates that this is an endregion tag.</remarks>
        public bool Beginning
        {
            get
            {
                return this.beginning;
            }
        }

        /// <summary>
        /// Gets the partner of this region tag.
        /// </summary>
        public Region Partner
        {
            get
            {
                return this.partner;
            }

            internal set
            {
                this.partner = value;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this is the start of a generated code block.
        /// </summary>
        public bool IsGeneratedCodeRegion
        {
            get
            {
                return this.PreprocessorType == "region" && this.Text.IndexOf("generated code", StringComparison.OrdinalIgnoreCase) != -1;
            }
        }

        #endregion Public Properties
    }
}