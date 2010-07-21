//-----------------------------------------------------------------------
// <copyright file="RegionDirective.cs" company="Microsoft">
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
namespace Microsoft.StyleCop.CSharp
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Globalization;
    using System.Text;

    /// <summary>
    /// Describes a region directive.
    /// </summary>
    /// <subcategory>preprocessor</subcategory>
    public sealed class RegionDirective : PreprocessorDirective
    {
        #region Private Fields

        /// <summary>
        /// The partner of this region tag.
        /// </summary>
        private EndRegionDirective partner;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the RegionDirective class.
        /// </summary>
        /// <param name="text">The line text.</param>
        /// <param name="location">The location of the preprocessor in the code.</param>
        /// <param name="generated">Indicates whether the preprocessor lies within a block of generated code.</param>
        internal RegionDirective(string text, CodeLocation location, bool generated)
            : base(text, PreprocessorType.Region, location, generated)
        {
            Param.AssertValidString(text, "text");
            Param.AssertNotNull(location, "location");
            Param.Ignore(generated);
        }

        #endregion Internal Constructors

        #region Public Properties

        /// <summary>
        /// Gets the partner of this region tag.
        /// </summary>
        public EndRegionDirective Partner
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
                return this.Text.IndexOf("generated code", StringComparison.OrdinalIgnoreCase) != -1;
            }
        }

        #endregion Public Properties
    }
}
