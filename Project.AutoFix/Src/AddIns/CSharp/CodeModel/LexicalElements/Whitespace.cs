//-----------------------------------------------------------------------
// <copyright file="Whitespace.cs">
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
    using System.Diagnostics.CodeAnalysis;
    using System.Text;

    /// <summary>
    /// Describes a chunk of whitespace.
    /// </summary>
    /// <subcategory>lexicalelement</subcategory>
    [SuppressMessage(
        "Microsoft.Naming", 
        "CA1702:CompoundWordsShouldBeCasedCorrectly", 
        MessageId = "Whitespace",
        Justification = "API has already been published and should not be changed.")]
    public sealed class Whitespace : SimpleLexicalElement
    {
        #region Private Fields

        /// <summary>
        /// The number of tabs in this whitespace.
        /// </summary>
        private int tabCount;

        /// <summary>
        /// The number of spaces in this whitespace.
        /// </summary>
        private int spaceCount;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the Whitespace class.
        /// </summary>
        /// <param name="document">The parent document.</param>
        /// <param name="text">The whitespace text.</param>
        internal Whitespace(CsDocument document, string text)
            : base(document, LexicalElementType.WhiteSpace)
        {
            Param.AssertNotNull(document, "document");
            Param.AssertValidString(text, "text");

            this.Text = text;
        }

        /// <summary>
        /// Initializes a new instance of the Whitespace class.
        /// </summary>
        /// <param name="document">The parent document.</param>
        /// <param name="text">The whitespace text.</param>
        /// <param name="location">The location of the whitespace in the code.</param>
        /// <param name="generated">True if the token is inside of a block of generated code.</param>
        internal Whitespace(CsDocument document, string text, CodeLocation location, bool generated) 
            : base(document, LexicalElementType.WhiteSpace, location, generated)
        {
            Param.AssertNotNull(document, "document");
            Param.AssertValidString(text, "text");
            Param.AssertNotNull(location, "location");
            Param.Ignore(generated);

            this.Text = text;
        }

        #endregion Internal Constructors

        #region Public Properties

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

        #endregion Public Properties

        #region Protected Override Methods

        /// <summary>
        /// Called when the value of the Text property changes.
        /// </summary>
        protected override void OnTextChanged()
        {
            base.OnTextChanged();

            this.spaceCount = this.tabCount = 0;
            string text = this.Text;

            for (int i = 0; i < text.Length; ++i)
            {
                if (text[i] == ' ')
                {
                    ++this.spaceCount;
                }
                else if (text[i] == '\t')
                {
                    ++this.tabCount;
                }
            }
        }

        #endregion Protected Override Methods
    }
}
