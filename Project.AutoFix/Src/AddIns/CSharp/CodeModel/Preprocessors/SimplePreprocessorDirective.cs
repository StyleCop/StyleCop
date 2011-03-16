//-----------------------------------------------------------------------
// <copyright file="SimplePreprocessorDirective.cs">
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
    /// Describes a preprocessor directive that contains no children.
    /// </summary>
    /// <subcategory>lexicalelement</subcategory>
    public abstract class SimplePreprocessorDirective : PreprocessorDirective
    {
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
            : base(new CodeUnitProxy(document), preprocessorDirectiveType, location)
        {
            Param.AssertNotNull(document, "document");
            Param.AssertValidString(text, "text");
            Param.Ignore(preprocessorDirectiveType);
            Param.AssertNotNull(location, "location");
            Param.Ignore(generated);

            this.Text = text;
            this.Generated = generated;
        }

        #endregion Internal Constructors
    }
}
