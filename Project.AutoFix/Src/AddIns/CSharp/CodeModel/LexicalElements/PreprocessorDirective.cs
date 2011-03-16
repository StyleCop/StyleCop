//-----------------------------------------------------------------------
// <copyright file="PreprocessorDirective.cs">
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
    using System.Text;

    /// <summary>
    /// Describes a preprocessor directive.
    /// </summary>
    /// <subcategory>lexicalelement</subcategory>
    public abstract class PreprocessorDirective : LexicalElement
    {
        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the PreprocessorDirective class.
        /// </summary>
        /// <param name="proxy">Proxy object for the directive.</param>
        /// <param name="preprocessorType">The type of the preprocessor.</param>
        /// <param name="location">The location of the code unit.</param>
        internal PreprocessorDirective(CodeUnitProxy proxy, PreprocessorType preprocessorType, CodeLocation location)
            : base(proxy, (int)preprocessorType, location)
        {
            Param.AssertNotNull(proxy, "proxy");
            Param.Ignore(preprocessorType);
            Param.Ignore(location);

            CsLanguageService.Debug.Assert(System.Enum.IsDefined(typeof(PreprocessorType), this.PreprocessorType), "The type is invalid.");
        }

        /// <summary>
        /// Initializes a new instance of the PreprocessorDirective class.
        /// </summary>
        /// <param name="proxy">Proxy object for the directive.</param>
        /// <param name="preprocessorType">The type of the preprocessor.</param>
        internal PreprocessorDirective(CodeUnitProxy proxy, PreprocessorType preprocessorType)
            : base(proxy, (int)preprocessorType)
        {
            Param.AssertNotNull(proxy, "proxy");
            Param.Ignore(preprocessorType);

            CsLanguageService.Debug.Assert(System.Enum.IsDefined(typeof(PreprocessorType), this.PreprocessorType), "The type is invalid.");
        }

        #endregion Internal Constructors

        #region Public Properties

        /// <summary>
        /// Gets the type of the preprocessor directive.
        /// </summary>
        public PreprocessorType PreprocessorType
        {
            get
            {
                return (PreprocessorType)(this.FundamentalType & (int)FundamentalTypeMasks.Preprocessor);
            }
        }

        #endregion Public Properties
    }
}
