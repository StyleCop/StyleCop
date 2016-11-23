// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Declaration.cs" company="https://github.com/StyleCop">
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
//   Describes an element declaration.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    using System.Collections.Generic;

    /// <summary>
    /// Describes an element declaration.
    /// </summary>
    /// <subcategory>element</subcategory>
    public sealed class Declaration
    {
        #region Fields

        /// <summary>
        /// The item's element type.
        /// </summary>
        private readonly ElementType elementType;

        /// <summary>
        /// The list of modifiers in the declaration.
        /// </summary>
        private readonly Dictionary<CsTokenType, CsToken> modifiers;

        /// <summary>
        /// The item name.
        /// </summary>
        private readonly string name;

        /// <summary>
        /// The list of tokens that make up the declaration.
        /// </summary>
        private readonly CsTokenList tokens;

        /// <summary>
        /// The item's access type.
        /// </summary>
        private AccessModifierType accessModifierType = AccessModifierType.Private;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the Declaration class.
        /// </summary>
        /// <param name="tokens">
        /// The array of tokens that make up the declaration.
        /// </param>
        /// <param name="name">
        /// The name of the element.
        /// </param>
        /// <param name="elementType">
        /// The type of the element.
        /// </param>
        /// <param name="accessModifierType">
        /// The access type of the element.
        /// </param>
        internal Declaration(CsTokenList tokens, string name, ElementType elementType, AccessModifierType accessModifierType)
            : this(tokens, name, elementType, accessModifierType, new Dictionary<CsTokenType, CsToken>(0))
        {
            Param.Ignore(tokens, name, elementType, accessModifierType);
        }

        /// <summary>
        /// Initializes a new instance of the Declaration class.
        /// </summary>
        /// <param name="tokens">
        /// The array of tokens that make up the declaration.
        /// </param>
        /// <param name="name">
        /// The name of the element.
        /// </param>
        /// <param name="elementType">
        /// The type of the element.
        /// </param>
        /// <param name="accessModifierType">
        /// The access type of the element.
        /// </param>
        /// <param name="modifiers">
        /// The list of modifier keywords in the declaration.
        /// </param>
        internal Declaration(CsTokenList tokens, string name, ElementType elementType, AccessModifierType accessModifierType, Dictionary<CsTokenType, CsToken> modifiers)
        {
            Param.AssertNotNull(tokens, "tokens");
            Param.AssertNotNull(name, "name");
            Param.Ignore(elementType);
            Param.Ignore(accessModifierType);
            Param.AssertNotNull(modifiers, "modifiers");

            this.tokens = tokens;
            this.name = CodeLexer.DecodeEscapedText(name, true);
            this.elementType = elementType;
            this.accessModifierType = accessModifierType;
            this.modifiers = modifiers;

            this.tokens.Trim();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets a value indicating whether the element has an access modifier.
        /// </summary>
        public bool AccessModifier
        {
            get
            {
                return this.ContainsModifier(CsTokenType.Public, CsTokenType.Private, CsTokenType.Protected, CsTokenType.Internal);
            }
        }

        /// <summary>
        /// Gets the access modifier type for the element.
        /// </summary>
        public AccessModifierType AccessModifierType
        {
            get
            {
                return this.accessModifierType;
            }

            internal set
            {
                this.accessModifierType = value;
            }
        }

        /// <summary>
        /// Gets the element type.
        /// </summary>
        public ElementType ElementType
        {
            get
            {
                return this.elementType;
            }
        }

        /// <summary>
        /// Gets the name of the element.
        /// </summary>
        public string Name
        {
            get
            {
                return this.name;
            }
        }

        /// <summary>
        /// Gets the list of tokens contained within the declaration.
        /// </summary>
        public CsTokenList Tokens
        {
            get
            {
                return this.tokens;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Indicates whether the declaration contains one of the given modifiers.
        /// </summary>
        /// <param name="types">
        /// The modifier types to check for.
        /// </param>
        /// <returns>
        /// Returns true if the declaration contains at least one
        /// of the given modifiers.
        /// </returns>
        public bool ContainsModifier(params CsTokenType[] types)
        {
            Param.RequireNotNull(types, "types");

            for (int i = 0; i < types.Length; ++i)
            {
                if (this.modifiers.ContainsKey(types[i]))
                {
                    return true;
                }
            }

            return false;
        }

        #endregion
    }
}