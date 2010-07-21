//-----------------------------------------------------------------------
// <copyright file="GotoStatement.cs" company="Microsoft">
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

    /// <summary>
    /// A goto-statement.
    /// </summary>
    /// <subcategory>statement</subcategory>
    public sealed class GotoStatement : Statement
    {
        #region Private Fields

        /// <summary>
        /// The identifier of the label to jump to.
        /// </summary>
        private Expression identifier;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the GotoStatement class.
        /// </summary>
        /// <param name="tokens">The list of tokens that form the statement.</param>
        /// <param name="identifier">The identifier of the label to jump to.</param>
        internal GotoStatement(CsTokenList tokens, Expression identifier)
            : base(StatementType.Goto, tokens)
        {
            Param.AssertNotNull(tokens, "tokens");
            Param.AssertNotNull(identifier, "identifier");

            this.identifier = identifier;

            this.AddExpression(identifier);
        }

        #endregion Internal Constructors

        #region Public Properties

        /// <summary>
        /// Gets the identifier of the label to jump to.
        /// </summary>
        public Expression Identifier
        {
            get
            {
                return this.identifier;
            }
        }

        #endregion Public Properties
    }
}
