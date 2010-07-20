//-----------------------------------------------------------------------
// <copyright file="Symbol.cs" company="Microsoft">
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
namespace Microsoft.StyleCop.CSharp.CodeModel
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// One token, word, symbol, or line read from a C# code file.
    /// </summary>
    internal class Symbol
    {
        #region Private Fields

        /// <summary>
        /// The item text.
        /// </summary>
        private string text = String.Empty;

        /// <summary>
        /// The location of this token in the code document.
        /// </summary>
        private CodeLocation location;

        /// <summary>
        /// The type of this symbol.
        /// </summary>
        private SymbolType symbolType;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the Symbol class.
        /// </summary>
        /// <param name="text">The item text.</param>
        /// <param name="symbolType">The symbol type.</param>
        /// <param name="location">The location of the token within the code document.</param>
        internal Symbol(string text, SymbolType symbolType, CodeLocation location)
        {
            Param.AssertValidString(text, "text");
            Param.Ignore(symbolType);
            Param.AssertNotNull(location, "location");

            this.text = text;
            this.symbolType = symbolType;
            this.location = location;
        }

        #endregion Internal Constructors

        #region Public Properties

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
        /// Gets the line number that this symbol appears on in the document.
        /// </summary>
        public int LineNumber
        {
            get
            {
                return this.location.StartPoint.LineNumber;
            }
        }

        #endregion Public Properties

        #region Public Override Methods

        /// <summary>
        /// Returns the contents of the symbol as s string.
        /// </summary>
        /// <returns>Returns the symbol string.</returns>
        public override string ToString()
        {
            return this.text;
        }

        #endregion Public Override Methods
    }
}
