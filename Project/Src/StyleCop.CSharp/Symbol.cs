// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Symbol.cs" company="https://github.com/StyleCop">
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
//   One token, word, symbol, or line read from a C# code file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    /// <summary>
    /// One token, word, symbol, or line read from a C# code file.
    /// </summary>
    internal class Symbol
    {
        #region Fields

        /// <summary>
        /// The location of this token in the code document.
        /// </summary>
        private readonly CodeLocation location;

        /// <summary>
        /// The item text.
        /// </summary>
        private readonly string text = string.Empty;

        /// <summary>
        /// The type of this symbol.
        /// </summary>
        private SymbolType symbolType;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the Symbol class.
        /// </summary>
        /// <param name="text">
        /// The item text.
        /// </param>
        /// <param name="symbolType">
        /// The symbol type.
        /// </param>
        /// <param name="location">
        /// The location of the token within the code document.
        /// </param>
        internal Symbol(string text, SymbolType symbolType, CodeLocation location)
        {
            Param.AssertValidString(text, "text");
            Param.Ignore(symbolType);
            Param.AssertNotNull(location, "location");

            this.text = text;
            this.symbolType = symbolType;
            this.location = location;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the line number that this symbol appears on in the document.
        /// </summary>
        public int LineNumber
        {
            get
            {
                return this.location.LineNumber;
            }
        }

        /// <summary>
        /// Gets the location of this symbol in the code document.
        /// </summary>
        public CodeLocation Location
        {
            get
            {
                return this.location;
            }
        }

        /// <summary>
        /// Gets or sets the type of the symbol.
        /// </summary>
        public SymbolType SymbolType
        {
            get
            {
                return this.symbolType;
            }

            set
            {
                Param.Ignore(value);
                this.symbolType = value;
            }
        }

        /// <summary>
        /// Gets the symbol string.
        /// </summary>
        public string Text
        {
            get
            {
                return this.text;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Returns the contents of the symbol as s string.
        /// </summary>
        /// <returns>Returns the symbol string.</returns>
        public override string ToString()
        {
            return this.text;
        }

        #endregion
    }
}