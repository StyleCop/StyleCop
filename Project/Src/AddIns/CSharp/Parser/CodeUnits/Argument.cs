//-----------------------------------------------------------------------
// <copyright file="ICodeUnit.cs" company="Microsoft">
//   Copyright (c) Microsoft Corporation.
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
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Describes a single argument to a method invocation call.
    /// </summary>
    /// <subcategory>other</subcategory>
    public sealed class Argument : CodeUnit
    {
        #region Internal Static Fields

        /// <summary>
        /// An empty array of arguments.
        /// </summary>
        internal static readonly Argument[] EmptyArgumentArray = new Argument[] { };

        #endregion Internal Static Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the Argument class.
        /// </summary>
        /// <param name="proxy">The proxy class.</param>
        internal Argument(CodeUnitProxy proxy)
            : base(proxy, CodeUnitType.Argument)
        {
            Param.AssertNotNull(proxy, "proxy");
        }

        #endregion Internal Constructors

        #region Public Properties

        /// <summary>
        /// Gets the argument expression.
        /// </summary>
        public Expression Expression
        {
            get
            {
                return this.FindFirstChild<Expression>();
            }
        }

        /// <summary>
        /// Gets the modifiers applied to this parameter.
        /// </summary>
        public ParameterModifiers Modifiers
        {
            get
            {
                ParameterModifiers modifiers = ParameterModifiers.None;

                for (CodeUnit item = this.FindFirstChild<CodeUnit>(); item != null; item = item.FindNextSibling<CodeUnit>())
                {
                    if (item.CodeUnitType != CodeUnitType.LexicalElement)
                    {
                        break;
                    }

                    Token token = item as Token;
                    if (token != null)
                    {
                        if (token.TokenType == TokenType.Ref)
                        {
                            modifiers |= ParameterModifiers.Ref;
                        }
                        else if (token.TokenType == TokenType.Out)
                        {
                            modifiers |= ParameterModifiers.Out;
                        }
                        else if (token.TokenType == TokenType.Params)
                        {
                            modifiers |= ParameterModifiers.Params;
                        }
                        else if (token.TokenType == TokenType.This)
                        {
                            modifiers |= ParameterModifiers.This;
                        }
                        else
                        {
                            break;
                        }
                    }
                }

                return modifiers;
            }
        }

        #endregion Public Properties
    }
}
