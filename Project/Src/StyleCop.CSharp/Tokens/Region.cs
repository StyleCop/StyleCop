// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Region.cs" company="https://github.com/StyleCop">
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
// <summary>
//   Describes a region directive.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    using System;

    /// <summary>
    /// Describes a region directive.
    /// </summary>
    /// <subcategory>token</subcategory>
    public sealed class Region : Preprocessor
    {
        #region Fields

        /// <summary>
        /// Indicates whether this is a beginning region.
        /// </summary>
        private readonly bool beginning;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the Region class.
        /// </summary>
        /// <param name="text">
        /// The line text.
        /// </param>
        /// <param name="location">
        /// The location of the preprocessor in the code.
        /// </param>
        /// <param name="parent">
        /// The parent of the region.
        /// </param>
        /// <param name="beginning">
        /// Indicates whether this is a beginning region.
        /// </param>
        /// <param name="generated">
        /// Indicates whether the preprocessor lies within a block of generated code.
        /// </param>
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

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets a value indicating whether this is the beginning of a region block.
        /// </summary>
        /// <remarks>A value of False indicates that this is the end of a region.</remarks>
        public bool Beginning
        {
            get
            {
                return this.beginning;
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

        /// <summary>
        /// Gets the partner of this region tag.
        /// </summary>
        public Region Partner { get; internal set; }

        #endregion
    }
}