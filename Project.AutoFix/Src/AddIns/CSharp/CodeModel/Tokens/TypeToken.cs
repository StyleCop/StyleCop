//-----------------------------------------------------------------------
// <copyright file="TypeToken.cs">
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
        internal TypeToken(CodeUnitProxy proxy)
            : base(proxy, TokenType.Type)
        {
            Param.AssertNotNull(proxy, "proxy");
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
