//-----------------------------------------------------------------------
// <copyright file="GenericTypeParameter.cs" company="Microsoft">
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
namespace Microsoft.StyleCop.CSharp_old
{
    using System;

    /// <summary>
    /// Describes parameter within a generic type token.
    /// </summary>
    public sealed class GenericTypeParameter
    {
        #region Private Fields

        /// <summary>
        /// The generic type parameter.
        /// </summary>
        private TypeToken type;

        /// <summary>
        /// Optional modifiers on the parameter;
        /// </summary>
        private ParameterModifiers modifiers = ParameterModifiers.None;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the GenericTypeParameter class.
        /// </summary>
        /// <param name="type">The generic type parameter.</param>
        /// <param name="modifiers">Optional modifiers.</param>
        internal GenericTypeParameter(TypeToken type, ParameterModifiers modifiers)
        {
            Param.AssertNotNull(type, "type");
            Param.Ignore(modifiers);

            this.type = type;
            this.modifiers = modifiers;
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
                return this.type;
            }
        }

        /// <summary>
        /// Gets the optional modifiers on the parameter;
        /// </summary>
        public ParameterModifiers Modifiers
        {
            get
            {
                return this.modifiers;
            }
        }
        
        #endregion Public Properties
    }
}
