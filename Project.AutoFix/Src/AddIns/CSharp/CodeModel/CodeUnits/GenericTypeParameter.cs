//-----------------------------------------------------------------------
// <copyright file="GenericTypeParameter.cs">
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

    /// <summary>
    /// Describes parameter within a generic type token.
    /// </summary>
    public sealed class GenericTypeParameter : CodeUnit
    {
        #region Internal Static Readonly Fields

        /// <summary>
        /// An empty array.
        /// </summary>
        internal static readonly GenericTypeParameter[] EmptyGenericTypeParameterArray = new GenericTypeParameter[] { };

        #endregion Internal Static Readonly Fields

        #region Private Fields

        /// <summary>
        /// The generic type parameter.
        /// </summary>
        private CodeUnitProperty<TypeToken> type;

        /// <summary>
        /// Optional modifiers on the parameter;
        /// </summary>
        private CodeUnitProperty<ParameterModifiers> modifiers;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the GenericTypeParameter class.
        /// </summary>
        /// <param name="proxy">The proxy class.</param>
        internal GenericTypeParameter(CodeUnitProxy proxy)
            : base(proxy, CodeUnitType.GenericTypeParameter)
        {
            Param.Ignore(proxy);
        }

        #endregion Internal Constructors

        #region Public Properties

        /// <summary>
        /// Gets the generic type parameter.
        /// </summary>
        public TypeToken Type
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.type.Initialized)
                {
                    this.type.Value = this.FindFirstChild<TypeToken>();
                }

                return this.type.Value;
            }
        }

        /// <summary>
        /// Gets the optional modifiers on the parameter;
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
                        if (token.TokenType == TokenType.Out)
                        {
                            this.modifiers.Value |= ParameterModifiers.Out;
                        }
                        else if (token.TokenType == TokenType.In)
                        {
                            this.modifiers.Value |= ParameterModifiers.In;
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
        /// Resets the contents of the item.
        /// </summary>
        protected override void Reset()
        {
            base.Reset();

            this.type.Reset();
            this.modifiers.Reset();
        }

        #endregion Protected Override Methods
    }
}
