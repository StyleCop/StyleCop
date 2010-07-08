//-----------------------------------------------------------------------
// <copyright file="EndOfLine.cs" company="Microsoft">
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
    using System.Diagnostics.CodeAnalysis;
    using System.Text;

    /// <summary>
    /// Describes an end-of-line element.
    /// </summary>
    /// <subcategory>lexicalelement</subcategory>
    public sealed class EndOfLine : LexicalElement
    {
        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the EndOfLine class.
        /// </summary>
        /// <param name="text">The text of the newline.</param>
        /// <param name="location">The location of the end-of-line in the code.</param>
        /// <param name="generated">True if the token is inside of a block of generated code.</param>
        internal EndOfLine(string text, CodeLocation location, bool generated)
            : base(
            LexicalElementType.EndOfLine,
            location,
            generated)
        {
            Param.AssertValidString(text, "text");
            Param.AssertNotNull(location, "location");
            Param.Ignore(generated);

            this.Text = text;
        }

        #endregion Internal Constructors
    }
}
