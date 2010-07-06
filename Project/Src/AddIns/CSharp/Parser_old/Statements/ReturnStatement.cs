//-----------------------------------------------------------------------
// <copyright file="ReturnStatement.cs" company="Microsoft">
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
    /// A return-statement.
    /// </summary>
    /// <subcategory>statement</subcategory>
    public sealed class ReturnStatement : Statement
    {
        #region Private Fields

        /// <summary>
        /// The return value expression, if there is one.
        /// </summary>
        private Expression returnValue;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the ReturnStatement class.
        /// </summary>
        /// <param name="tokens">The list of tokens that form the statement.</param>
        /// <param name="returnValue">The return value expression, if there is one.</param>
        internal ReturnStatement(CsTokenList tokens, Expression returnValue)
            : base(StatementType.Return, tokens)
        {
            Param.AssertNotNull(tokens, "tokens");
            Param.Ignore(returnValue);

            this.returnValue = returnValue;

            if (returnValue != null)
            {
                this.AddExpression(returnValue);
            }
        }

        #endregion Internal Constructors

        #region Public Properties

        /// <summary>
        /// Gets the return value expression, if there is one.
        /// </summary>
        public Expression ReturnValue
        {
            get
            {
                return this.returnValue;
            }
        }

        #endregion Public Properties
    }
}
