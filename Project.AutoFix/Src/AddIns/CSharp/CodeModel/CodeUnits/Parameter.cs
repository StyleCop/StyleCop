//-----------------------------------------------------------------------
// <copyright file="Parameter.cs">
//   MS-PL
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
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Describes a single method parameter.
    /// </summary>
    /// <subcategory>other</subcategory>
    public sealed partial class Parameter : CodeUnit
    {
        #region Internal Static Fields

        /// <summary>
        /// An empty array of parameters.
        /// </summary>
        internal static readonly Parameter[] EmptyParameterArray = new Parameter[] { };

        #endregion Internal Static Fields

        #region Private Fields

        /// <summary>
        /// The token representing the name of the parameter.
        /// </summary>
        private CodeUnitProperty<Token> nameToken;

        /// <summary>
        /// The token representing the type of the parameter.
        /// </summary>
        private CodeUnitProperty<TypeToken> parameterTypeToken;

        /// <summary>
        /// The optional modifiers on the parameter.
        /// </summary>
        private CodeUnitProperty<ParameterModifiers> modifiers;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the Parameter class.
        /// </summary>
        /// <param name="proxy">The proxy class.</param>
        internal Parameter(CodeUnitProxy proxy) : base(proxy, CodeUnitType.Parameter)
        {
            Param.Ignore(proxy);
        }

        #endregion Internal Constructors

        #region Public Properties

        /// <summary>
        /// Gets the parameter name.
        /// </summary>
        public string Name
        {
            get
            {
                Token name = this.NameToken;
                return name == null ? string.Empty : name.Text;
            }
        }

        /// <summary>
        /// Gets the parameter name token.
        /// </summary>
        public Token NameToken
        {
            get 
            {
                this.ValidateEditVersion();

                if (!this.nameToken.Initialized)
                {
                    this.nameToken.Value = null;
                    bool foundType = false;

                    for (Token token = this.FindFirstChildToken(); token != null; token = token.FindNextSiblingToken())
                    {
                        if (!foundType)
                        {
                            if (token.TokenType != TokenType.Ref &&
                                token.TokenType != TokenType.Out &&
                                token.TokenType != TokenType.Params &&
                                token.TokenType != TokenType.This)
                            {
                                foundType = true;

                                // If the first thing we encounter is __arglist, then there is no type and only a name.
                                if (token.Text.Equals("__arglist", StringComparison.Ordinal))
                                {
                                    this.nameToken.Value = token;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            this.nameToken.Value = token;
                            break;
                        }
                    }
                }

                return this.nameToken.Value;
            }
        }

        /// <summary>
        /// Gets the parameter type.
        /// </summary>
        public string ParameterType
        {
            get
            {
                Token typeToken = this.ParameterTypeToken;
                return typeToken == null ? string.Empty : typeToken.Text;
            }
        }

        /// <summary>
        /// Gets the parameter type token.
        /// </summary>
        public TypeToken ParameterTypeToken
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.parameterTypeToken.Initialized)
                {
                    this.parameterTypeToken.Value = null;

                    for (Token token = this.FindFirstChildToken(); token != null; token = token.FindNextSiblingToken())
                    {
                        if (token.TokenType == TokenType.Type)
                        {
                            // If the first thing we encounter is __arglist, then there is no type and only a name.
                            if (!token.Text.Equals("__arglist", StringComparison.Ordinal))
                            {
                                this.parameterTypeToken.Value = (TypeToken)token;
                            }

                            break;
                        }
                    }
                }

                return this.parameterTypeToken.Value;
            }
        }

        /// <summary>
        /// Gets the modifiers applied to this parameter.
        /// </summary>
        public ParameterModifiers Modifiers
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.modifiers.Initialized)
                {
                    this.modifiers.Value = ParameterModifiers.None;

                    for (Token token = this.FindFirstChildToken(); token != null; token = token.FindNextSiblingToken())
                    {
                        if (token.TokenType == TokenType.Ref)
                        {
                            this.modifiers.Value |= ParameterModifiers.Ref;
                        }
                        else if (token.TokenType == TokenType.Out)
                        {
                            this.modifiers.Value |= ParameterModifiers.Out;
                        }
                        else if (token.TokenType == TokenType.Params)
                        {
                            this.modifiers.Value |= ParameterModifiers.Params;
                        }
                        else if (token.TokenType == TokenType.This)
                        {
                            this.modifiers.Value |= ParameterModifiers.This;
                        }
                        else
                        {
                            break;
                        }
                    }
                }

                return this.modifiers.Value; 
            }
        }

        #endregion Public Properties

        #region Protected Override Methods

        /// <summary>
        /// Resets the contents of the parameter.
        /// </summary>
        protected override void Reset()
        {
            base.Reset();

            this.nameToken.Reset();
            this.parameterTypeToken.Reset();
            this.modifiers.Reset();
        }

        #endregion Protected Override Methods
    }

    /// <content>
    /// Implements the IVariable interface.
    /// </content>
    public partial class Parameter : IVariable
    {
        /// <summary>
        /// Gets the variable name.
        /// </summary>
        public string VariableName
        {
            get
            {
                return this.Name;
            }
        }

        /// <summary>
        /// Gets the variable type.
        /// </summary>
        public TypeToken VariableType
        {
            get
            {
                return this.ParameterTypeToken;
            }
        }

        /// <summary>
        /// Gets the modifiers applied to this variable.
        /// </summary>
        public VariableModifiers VariableModifiers
        {
            get
            {
                return VariableModifiers.None;
            }
        }
    }
}
