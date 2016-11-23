// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GenericType.cs" company="https://github.com/StyleCop">
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
//   Describes a generic type token.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Describes a generic type token.
    /// </summary>
    /// <subcategory>token</subcategory>
    public sealed class GenericType : TypeToken
    {
        #region Fields

        /// <summary>
        /// The types within the generic type.
        /// </summary>
        private ICollection<GenericTypeParameter> typeParameters;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the GenericType class.
        /// </summary>
        /// <param name="childTokens">
        /// The list of child tokens that form the generic token.
        /// </param>
        /// <param name="location">
        /// The location of the generic in the code.
        /// </param>
        /// <param name="parent">
        /// The parent of the token.
        /// </param>
        /// <param name="generated">
        /// True if the token is inside of a block of generated code.
        /// </param>
        internal GenericType(MasterList<CsToken> childTokens, CodeLocation location, Reference<ICodePart> parent, bool generated)
            : base(childTokens, location, parent, CsTokenClass.GenericType, generated)
        {
            Param.AssertNotNull(childTokens, "childTokens");
            Param.AssertGreaterThanOrEqualTo(childTokens.Count, 3, "childTokens");
            Param.AssertNotNull(location, "location");
            Param.AssertNotNull(parent, "parent");
            Param.Ignore(generated);
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the types within the generic type.
        /// </summary>
        public ICollection<GenericTypeParameter> GenericTypesParameters
        {
            get
            {
                if (this.typeParameters == null)
                {
                    this.ExtractGenericTypes();
                }

                return this.typeParameters;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Creates a text string based on the child tokens in the token.
        /// </summary>
        protected override void CreateTextString()
        {
            int genericTagCount = 0;

            StringBuilder text = new StringBuilder();
            foreach (CsToken token in this.ChildTokens)
            {
                if (token.CsTokenType == CSharp.CsTokenType.OpenGenericBracket)
                {
                    ++genericTagCount;
                }
                else if (token.CsTokenType == CSharp.CsTokenType.CloseGenericBracket)
                {
                    --genericTagCount;
                }

                // Strip out comments and whitespace.
                if (token.CsTokenType != CsTokenType.WhiteSpace && token.CsTokenType != CsTokenType.EndOfLine && token.CsTokenType != CsTokenType.SingleLineComment
                    && token.CsTokenType != CsTokenType.MultiLineComment && token.CsTokenType != CsTokenType.PreprocessorDirective)
                {
                    text.Append(token.Text);
                }

                // Insert a space after the out or in keyword found within a generic argument list.
                if (genericTagCount > 0 && (token.CsTokenType == CSharp.CsTokenType.Out || token.CsTokenType == CSharp.CsTokenType.In))
                {
                    text.Append(" ");
                }
            }

            this.Text = text.ToString();
        }

        /// <summary>
        /// Extracts the generic types from the type list and saves them.
        /// </summary>
        private void ExtractGenericTypes()
        {
            List<GenericTypeParameter> genericTypes = new List<GenericTypeParameter>();

            bool start = false;
            ParameterModifiers modifiers = ParameterModifiers.None;
            TypeToken type = null;

            for (Node<CsToken> tokenNode = this.ChildTokens.First; tokenNode != null; tokenNode = tokenNode.Next)
            {
                if (tokenNode.Value.CsTokenType == CsTokenType.OpenGenericBracket)
                {
                    start = true;
                }
                else if (start)
                {
                    if (tokenNode.Value.CsTokenType == CSharp.CsTokenType.CloseGenericBracket)
                    {
                        if (type != null)
                        {
                            genericTypes.Add(new GenericTypeParameter(type, modifiers));
                        }

                        break;
                    }

                    if (tokenNode.Value.CsTokenType == CsTokenType.Comma)
                    {
                        if (type != null)
                        {
                            genericTypes.Add(new GenericTypeParameter(type, modifiers));
                        }

                        type = null;
                        modifiers = ParameterModifiers.None;
                    }
                    else if (tokenNode.Value.CsTokenType == CsTokenType.Out)
                    {
                        modifiers = ParameterModifiers.Out;
                    }
                    else if (tokenNode.Value.CsTokenType == CsTokenType.In)
                    {
                        modifiers = ParameterModifiers.In;
                    }
                    else if (tokenNode.Value.CsTokenType == CsTokenType.Other && type == null)
                    {
                        type = tokenNode.Value as TypeToken;
                    }
                }
            }

            this.typeParameters = genericTypes.ToArray();
        }

        #endregion
    }
}