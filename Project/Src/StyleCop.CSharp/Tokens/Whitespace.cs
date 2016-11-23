// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Whitespace.cs" company="https://github.com/StyleCop">
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
//   Describes a chunk of whitespace.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    using System.Diagnostics.CodeAnalysis;
    using System.Text;

    /// <summary>
    /// Describes a chunk of whitespace.
    /// </summary>
    /// <subcategory>token</subcategory>
    [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "Whitespace", 
        Justification = "API has already been published and should not be changed.")]
    public sealed class Whitespace : CsToken
    {
        #region Fields

        /// <summary>
        /// The number of spaces in this whitespace.
        /// </summary>
        private readonly int spaceCount;

        /// <summary>
        /// The number of tabs in this whitespace.
        /// </summary>
        private readonly int tabCount;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the Whitespace class.
        /// </summary>
        /// <param name="text">
        /// The whitespace text.
        /// </param>
        /// <param name="location">
        /// The location of the whitespace in the code.
        /// </param>
        /// <param name="parent">
        /// The parent code unit.
        /// </param>
        /// <param name="generated">
        /// True if the token is inside of a block of generated code.
        /// </param>
        internal Whitespace(string text, CodeLocation location, Reference<ICodePart> parent, bool generated)
            : base(text, CsTokenType.WhiteSpace, CsTokenClass.Whitespace, location, parent, generated)
        {
            Param.AssertValidString(text, "text");
            Param.AssertNotNull(location, "location");
            Param.AssertNotNull(parent, "parent");
            Param.Ignore(generated);

            for (int i = 0; i < text.Length; ++i)
            {
                if (text[i] == '\t')
                {
                    ++this.tabCount;
                }
                else
                {
                    ++this.spaceCount;
                }
            }
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the number of spaces in the whitespace.
        /// </summary>
        public int SpaceCount
        {
            get
            {
                return this.spaceCount;
            }
        }

        /// <summary>
        /// Gets the number of tabs in the whitespace.
        /// </summary>
        public int TabCount
        {
            get
            {
                return this.tabCount;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Gets the whitespace interpreted as a string.
        /// </summary>
        /// <returns>Returns the whitespace interpreted as a string.</returns>
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            if (this.tabCount >= 1)
            {
                output.Append("\t");
            }

            if (this.spaceCount == 1)
            {
                output.Append(" ");
            }
            else if (this.spaceCount > 1)
            {
                output.Append("  ");
            }

            return output.ToString();
        }

        #endregion
    }
}