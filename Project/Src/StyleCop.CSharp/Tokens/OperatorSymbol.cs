// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OperatorSymbol.cs" company="https://github.com/StyleCop">
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
//   Describes an operator symbol.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    /// <summary>
    /// Describes an operator symbol.
    /// </summary>
    /// <subcategory>token</subcategory>
    public class OperatorSymbol : CsToken
    {
        #region Fields

        /// <summary>
        /// The category of the operator.
        /// </summary>
        private readonly OperatorCategory category;

        /// <summary>
        /// The specific symbol type.
        /// </summary>
        private readonly OperatorType symbolType;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the OperatorSymbol class.
        /// </summary>
        /// <param name="text">
        /// The text of the operator symbol.
        /// </param>
        /// <param name="category">
        /// The category of the operator.
        /// </param>
        /// <param name="symbolType">
        /// The specific symbol type.
        /// </param>
        /// <param name="location">
        /// The location of the operator symbol in the code document.
        /// </param>
        /// <param name="parent">
        /// Reference to the parent code part.
        /// </param>
        /// <param name="generated">
        /// Indicates whether the operator lies within a block of generated code.
        /// </param>
        internal OperatorSymbol(string text, OperatorCategory category, OperatorType symbolType, CodeLocation location, Reference<ICodePart> parent, bool generated)
            : base(text, CsTokenType.OperatorSymbol, CsTokenClass.OperatorSymbol, location, parent, generated)
        {
            Param.AssertValidString(text, "text");
            Param.Ignore(category);
            Param.Ignore(symbolType);
            Param.AssertNotNull(location, "location");
            Param.AssertNotNull(parent, "parent");
            Param.Ignore(generated);

            this.category = category;
            this.symbolType = symbolType;
        }

        #endregion

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
                return this.symbolType;
            }
        }

        #endregion
    }
}