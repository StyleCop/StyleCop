// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CsToken.cs" company="https://github.com/StyleCop">
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
//   Describes a single token within a C# document.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Describes a single token within a C# document.
    /// </summary>
    /// <subcategory>token</subcategory>
    [SuppressMessage("Microsoft.Naming", "CA1706:ShortAcronymsShouldBeUppercase", Justification = "Camel case better serves in this case.")]
    public class CsToken : ICodePart
    {
        #region Fields

        /// <summary>
        /// True if the token is part of a generated code block.
        /// </summary>
        private readonly bool generated;

        /// <summary>
        /// The location of this token in the code document.
        /// </summary>
        private readonly CodeLocation location;

        /// <summary>
        /// THe class of the token.
        /// </summary>
        private readonly CsTokenClass tokenClass;

        /// <summary>
        /// The type of this token.
        /// </summary>
        private readonly CsTokenType tokenType;

        /// <summary>
        /// The parent of the token.
        /// </summary>
        private Reference<ICodePart> parent;

        /// <summary>
        /// The token text.
        /// </summary>
        private string text;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the CsToken class.
        /// </summary>
        /// <param name="text">
        /// The token string.
        /// </param>
        /// <param name="tokenType">
        /// The token type.
        /// </param>
        /// <param name="location">
        /// The location of the token within the code document.
        /// </param>
        /// <param name="parent">
        /// References the parent code part.
        /// </param>
        /// <param name="generated">
        /// True if the token is inside of a block of generated code.
        /// </param>
        internal CsToken(string text, CsTokenType tokenType, CodeLocation location, Reference<ICodePart> parent, bool generated)
            : this(text, tokenType, CsTokenClass.Token, location, parent, generated)
        {
            Param.Ignore(text, tokenType, location, parent, generated);
        }

        /// <summary>
        /// Initializes a new instance of the CsToken class.
        /// </summary>
        /// <param name="tokenType">
        /// The token type.
        /// </param>
        /// <param name="tokenClass">
        /// The token class.
        /// </param>
        /// <param name="location">
        /// The location of the token within the code document.
        /// </param>
        /// <param name="parent">
        /// References the parent code part.
        /// </param>
        /// <param name="generated">
        /// True if the token is inside of a block of generated code.
        /// </param>
        internal CsToken(CsTokenType tokenType, CsTokenClass tokenClass, CodeLocation location, Reference<ICodePart> parent, bool generated)
        {
            Param.Ignore(tokenType);
            Param.Ignore(tokenClass);
            Param.AssertNotNull(location, "location");
            Param.AssertNotNull(parent, "parent");
            Param.Ignore(generated);

            this.tokenType = tokenType;
            this.tokenClass = tokenClass;
            this.location = location;
            this.parent = parent;
            this.generated = generated;
        }

        /// <summary>
        /// Initializes a new instance of the CsToken class.
        /// </summary>
        /// <param name="text">
        /// The token string.
        /// </param>
        /// <param name="tokenType">
        /// The token type.
        /// </param>
        /// <param name="tokenClass">
        /// The token class.
        /// </param>
        /// <param name="location">
        /// The location of the token within the code document.
        /// </param>
        /// <param name="parent">
        /// References the parent code part.
        /// </param>
        /// <param name="generated">
        /// True if the token is inside of a block of generated code.
        /// </param>
        internal CsToken(string text, CsTokenType tokenType, CsTokenClass tokenClass, CodeLocation location, Reference<ICodePart> parent, bool generated)
        {
            Param.AssertNotNull(text, "text");
            Param.Ignore(tokenType);
            Param.Ignore(tokenClass);
            Param.Ignore(location);
            Param.AssertNotNull(parent, "parent");
            Param.Ignore(generated);

            this.text = text;
            this.tokenType = tokenType;
            this.tokenClass = tokenClass;
            this.location = location;
            this.parent = parent;
            this.generated = generated;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the type of this code part.
        /// </summary>
        public CodePartType CodePartType
        {
            get
            {
                return CodePartType.Token;
            }
        }

        /// <summary>
        /// Gets the token class.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1706:ShortAcronymsShouldBeUppercase", MessageId = "Member", Justification = "Camel case better serves in this case.")]
        public CsTokenClass CsTokenClass
        {
            get
            {
                return this.tokenClass;
            }
        }

        /// <summary>
        /// Gets the token type.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1706:ShortAcronymsShouldBeUppercase", MessageId = "Member", Justification = "Camel case better serves in this case.")]
        public CsTokenType CsTokenType
        {
            get
            {
                return this.tokenType;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the token is within a block of generated code.
        /// </summary>
        public bool Generated
        {
            get
            {
                return this.generated;
            }
        }

        /// <summary>
        /// Gets the line number that the token appears on in the document.
        /// </summary>
        public virtual int LineNumber
        {
            get
            {
                return this.location.LineNumber;
            }
        }

        /// <summary>
        /// Gets the location of the token in the code document.
        /// </summary>
        public virtual CodeLocation Location
        {
            get
            {
                return this.location;
            }
        }

        /// <summary>
        /// Gets the parent of the token.
        /// </summary>
        public ICodePart Parent
        {
            get
            {
                return this.parent.Target;
            }
        }

        /// <summary>
        /// Gets or sets the token string.
        /// </summary>
        public virtual string Text
        {
            get
            {
                if (this.text == null)
                {
                    this.CreateTextString();

                    if (this.text == null)
                    {
                        this.text = string.Empty;
                    }
                }

                return this.text;
            }

            protected set
            {
                this.text = value;
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the parent reference.
        /// </summary>
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Properties must always have a get.")]
        internal Reference<ICodePart> ParentRef
        {
            get
            {
                return this.parent;
            }

            set
            {
                Param.Ignore(value);
                this.parent = value;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Returns the contents of the token as a string.
        /// </summary>
        /// <returns>Returns the token string.</returns>
        public override string ToString()
        {
            return this.Text;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Joins the locations of the two tokens.
        /// </summary>
        /// <param name="location1">
        /// The first location.
        /// </param>
        /// <param name="token2">
        /// The second token.
        /// </param>
        /// <returns>
        /// Returns the joined locations.
        /// </returns>
        internal static CodeLocation JoinLocations(CodeLocation location1, CsToken token2)
        {
            Param.Ignore(location1, token2);
            return token2 == null ? CodeLocation.Join(location1, null) : CodeLocation.Join(location1, token2.Location);
        }

        /////// <summary>
        /////// Joins the locations of the two tokens.
        /////// </summary>
        /////// <param name="token1">The first token.</param>
        /////// <param name="location2">The second location.</param>
        /////// <returns>Returns the joined locations.</returns>
        ////internal static CodeLocation JoinLocations(CsToken token1, CodeLocation location2)
        ////{
        ////    Param.Ignore(token1, location2);
        ////    return CodeLocation.Join(token1 == null ? null : token1.Location, location2);
        ////}

        /// <summary>
        /// Joins the locations of the two tokens.
        /// </summary>
        /// <param name="location1">
        /// The first location.
        /// </param>
        /// <param name="token2">
        /// The second token.
        /// </param>
        /// <returns>
        /// Returns the joined locations.
        /// </returns>
        internal static CodeLocation JoinLocations(CodeLocation location1, Node<CsToken> token2)
        {
            Param.Ignore(location1, token2);
            return CsToken.JoinLocations(location1, token2 == null ? null : token2.Value);
        }

        /////// <summary>
        /////// Joins the locations of the two tokens.
        /////// </summary>
        /////// <param name="token1">The first token.</param>
        /////// <param name="location2">The second location.</param>
        /////// <returns>Returns the joined locations.</returns>
        ////internal static CodeLocation JoinLocations(Node<CsToken> token1, CodeLocation location2)
        ////{
        ////    Param.Ignore(token1, location2);
        ////    return CsToken.JoinLocations(token1 == null ? null : token1.Value, location2);
        ////}

        /// <summary>
        /// Joins the locations of the two tokens.
        /// </summary>
        /// <param name="token1">
        /// The first token.
        /// </param>
        /// <param name="token2">
        /// The second token.
        /// </param>
        /// <returns>
        /// Returns the joined locations.
        /// </returns>
        internal static CodeLocation JoinLocations(CsToken token1, CsToken token2)
        {
            Param.AssertNotNull(token1, "token1");
            Param.AssertNotNull(token2, "token2");
            
            return CodeLocation.Join(token1.Location, token2.Location);
        }

        /////// <summary>
        /////// Joins the locations of the two tokens.
        /////// </summary>
        /////// <param name="token1">The first token.</param>
        /////// <param name="token2">The second token.</param>
        /////// <returns>Returns the joined locations.</returns>
        ////internal static CodeLocation JoinLocations(Node<CsToken> token1, CsToken token2)
        ////{
        ////    Param.Ignore(token1, token2);
        ////    return CsToken.JoinLocations(token1 == null ? null : token1.Value, token2);
        ////}

        /////// <summary>
        /////// Joins the locations of the two tokens.
        /////// </summary>
        /////// <param name="token1">The first token.</param>
        /////// <param name="token2">The second token.</param>
        /////// <returns>Returns the joined locations.</returns>
        ////internal static CodeLocation JoinLocations(CsToken token1, Node<CsToken> token2)
        ////{
        ////    Param.Ignore(token1, token2);
        ////    return CsToken.JoinLocations(token1, token2 == null ? null : token2.Value);
        ////}

        /// <summary>
        /// Joins the locations of the two tokens.
        /// </summary>
        /// <param name="token1">
        /// The first token.
        /// </param>
        /// <param name="token2">
        /// The second token.
        /// </param>
        /// <returns>
        /// Returns the joined locations.
        /// </returns>
        internal static CodeLocation JoinLocations(Node<CsToken> token1, Node<CsToken> token2)
        {
            Param.Ignore(token1, token2);
            return CsToken.JoinLocations(token1 == null ? null : token1.Value, token2 == null ? null : token2.Value);
        }

        /// <summary>
        /// Creates the text string for the token.
        /// </summary>
        protected virtual void CreateTextString()
        {
        }

        #endregion
    }
}