//-----------------------------------------------------------------------
// <copyright file="TypeToken.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.
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
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Text;

    /// <summary>
    /// Describes a type token in a code file.
    /// </summary>
    /// <subcategory>token</subcategory>
    public class TypeToken : ComplexToken
    {
        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the TypeToken class.
        /// </summary>
        /// <param name="proxy">Proxy object for the statement.</param>
        /// <param name="location">The location of the token in the code.</param>
        /// <param name="generated">True if the token is inside of a block of generated code.</param>
        internal TypeToken(CodeUnitProxy proxy, CodeLocation location, bool generated)
            : base(proxy, TokenType.Type, location, generated)
        {
            Param.AssertNotNull(proxy, "proxy");
            Param.AssertNotNull(location, "location");
            Param.Ignore(generated);
        }

        #endregion Internal Constructors

        #region Public Properties

        /// <summary>
        /// Gets or sets a value indicating whether the type is a generic type.
        /// </summary>
        public bool IsGeneric
        {
            get;
            protected set;
        }

        #endregion Public Properties
    }
}
