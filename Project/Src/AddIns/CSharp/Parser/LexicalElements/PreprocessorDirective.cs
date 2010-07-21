//-----------------------------------------------------------------------
// <copyright file="PreprocessorDirective.cs" company="Microsoft">
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
        internal PreprocessorDirective(CodeUnitProxy proxy, PreprocessorType preprocessorType)
            : base(proxy, (int)preprocessorType)
        {
            Param.AssertNotNull(proxy, "proxy");
            Param.Ignore(preprocessorType);

            Debug.Assert(System.Enum.IsDefined(typeof(PreprocessorType), this.PreprocessorType), "The type is invalid.");

            this.Initialize();
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

        #region Private Methods

        /// <summary>
        /// Initializes the contents of the class.
        /// </summary>
        private void Initialize()
        {
            string text = this.Text;
            if (!string.IsNullOrEmpty(text))
            {
                // Extract the type of the preprocessor statement.
                int startIndex = 0;
                while (true)
                {
                    if (text[startIndex] == '#')
                    {
                        break;
                    }

                    ++startIndex;
                }

                // Extract the name.
                int index = startIndex;
                while (index + 1 < text.Length)
                {
                    if (!char.IsLetter(text[index + 1]))
                    {
                        break;
                    }

                    ++index;
                }
            }
        }

        #endregion Private Methods
    }
}
