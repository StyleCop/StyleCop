//-----------------------------------------------------------------------
// <copyright file="OperatorSymbolToken.cs" company="Microsoft">
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
    using System.Diagnostics;
    using System.Text;

    /// <summary>
    /// Describes an operator symbol.
    /// </summary>
    /// <subcategory>token</subcategory>
    public abstract class OperatorSymbolToken : SimpleToken
    {
        #region Private Fields

        /// <summary>
        /// The category of the operator.
        /// </summary>
        private OperatorCategory category;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the OperatorSymbolToken class.
        /// </summary>
        /// <param name="document">The parent document.</param>
        /// <param name="text">The text of the operator symbol.</param>
        /// <param name="category">The category of the operator.</param>
        /// <param name="symbolType">The specific symbol type.</param>
        /// <param name="location">The location of the operator symbol in the code document.</param>
        /// <param name="generated">Indicates whether the operator lies within a block of generated code.</param>
        internal OperatorSymbolToken(CsDocument document, string text, OperatorCategory category, OperatorType symbolType, CodeLocation location, bool generated)
            : base(document, text, (int)symbolType, location, generated)
        {
            Param.AssertNotNull(document, "document");
            Param.AssertValidString(text, "text");
            Param.Ignore(category);
            Param.Ignore(symbolType);
            Param.AssertNotNull(location, "location");
            Param.Ignore(generated);

            this.category = category;
            Debug.Assert(System.Enum.IsDefined(typeof(OperatorType), this.SymbolType), "The type is invalid.");
        }

        #endregion Internal Constructors

        #region Public Properties

        /// <summary>
        /// Gets the category of the operator symbol.
        /// </summary>
        public OperatorCategory Category
        {
            get
            {
                return this.category;
            }
        }

        /// <summary>
        /// Gets the specific symbol type.
        /// </summary>
        public OperatorType SymbolType
        {
            get
            {
                return (OperatorType)(this.FundamentalType & (int)FundamentalTypeMasks.Operator);
            }
        }

        #endregion Public Properties
    }
}
