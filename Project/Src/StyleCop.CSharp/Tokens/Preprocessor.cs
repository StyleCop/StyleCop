// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Preprocessor.cs" company="https://github.com/StyleCop">
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
//   Describes a preprocessor directive.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    /// <summary>
    /// Describes a preprocessor directive.
    /// </summary>
    /// <subcategory>token</subcategory>
    public class Preprocessor : CsToken
    {
        #region Fields

        /// <summary>
        /// The type of the preprocessor statement.
        /// </summary>
        private readonly string preprocessorType = string.Empty;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the Preprocessor class.
        /// </summary>
        /// <param name="text">
        /// The line text.
        /// </param>
        /// <param name="tokenClass">
        /// The class of the token.
        /// </param>
        /// <param name="location">
        /// The location of the preprocessor in the code.
        /// </param>
        /// <param name="parent">
        /// The parent code part.
        /// </param>
        /// <param name="generated">
        /// Indicates whether the preprocessor lies within a block of generated code.
        /// </param>
        internal Preprocessor(string text, CsTokenClass tokenClass, CodeLocation location, Reference<ICodePart> parent, bool generated)
            : base(text, CsTokenType.PreprocessorDirective, tokenClass, location, parent, generated)
        {
            Param.AssertNotNull(text, "text");
            Param.AssertNotNull(tokenClass, "tokenClass");
            Param.AssertNotNull(location, "location");
            Param.AssertNotNull(parent, "parent");
            Param.Ignore(generated);

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
            string name = string.Empty;
            int index = startIndex;
            while (index + 1 < text.Length)
            {
                if (!char.IsLetter(text[index + 1]))
                {
                    break;
                }

                ++index;
            }

            if (index > startIndex)
            {
                name = text.Substring(startIndex + 1, index - startIndex);
            }

            this.preprocessorType = name;
        }

        /// <summary>
        /// Initializes a new instance of the Preprocessor class.
        /// </summary>
        /// <param name="text">
        /// The line text.
        /// </param>
        /// <param name="location">
        /// The location of the preprocessor in the code.
        /// </param>
        /// <param name="parent">
        /// The parent code part.
        /// </param>
        /// <param name="generated">
        /// Indicates whether the preprocessor lies within a block of generated code.
        /// </param>
        internal Preprocessor(string text, CodeLocation location, Reference<ICodePart> parent, bool generated)
            : this(text, CsTokenClass.PreprocessorDirective, location, parent, generated)
        {
            Param.Ignore(text, location, parent, generated);
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the type of the preprocessor directive.
        /// </summary>
        public string PreprocessorType
        {
            get
            {
                return this.preprocessorType;
            }
        }

        #endregion
    }
}