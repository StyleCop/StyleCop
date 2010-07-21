//-----------------------------------------------------------------------
// <copyright file="LabelStatement.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
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

    /// <summary>
    /// A label within the code.
    /// </summary>
    /// <subcategory>statement</subcategory>
    public sealed class LabelStatement : Statement
    {
        #region Private Fields

        /// <summary>
        /// The label identifier.
        /// </summary>
        private LiteralExpression identifier;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the LabelStatement class.
        /// </summary>
        /// <param name="proxy">Proxy object for the statement.</param>
        /// <param name="identifier">The label identifier.</param>
        internal LabelStatement(CodeUnitProxy proxy, LiteralExpression identifier)
            : base(proxy, StatementType.Label)
        {
            Param.AssertNotNull(proxy, "proxy");
            Param.AssertNotNull(identifier, "identifier");

            this.identifier = identifier;
        }

        #endregion Internal Constructors

        #region Public Properties

        /// <summary>
        /// Gets the label identifier.
        /// </summary>
        public LiteralExpression Identifier
        {
            get
            {
                return this.identifier;
            }
        }

        #endregion Public Properties
    }
}
