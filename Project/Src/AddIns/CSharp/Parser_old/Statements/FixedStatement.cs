//-----------------------------------------------------------------------
// <copyright file="FixedStatement.cs" company="Microsoft">
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
    /// A fixed-statement.
    /// </summary>
    /// <subcategory>statement</subcategory>
    public sealed class FixedStatement : Statement
    {
        #region Private Fields

        /// <summary>
        /// The fixed variable.
        /// </summary>
        private VariableDeclarationExpression fixedVariable;

        /// <summary>
        /// The statement that is embedded within this fixed-statement.
        /// </summary>
        private Statement embeddedStatement;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the FixedStatement class.
        /// </summary>
        /// <param name="tokens">The list of tokens that form the statement.</param>
        /// <param name="fixedVariable">The fixed variable.</param>
        internal FixedStatement(
            CsTokenList tokens, VariableDeclarationExpression fixedVariable)
            : base(StatementType.Fixed, tokens)
        {
            Param.AssertNotNull(tokens, "tokens");
            Param.AssertNotNull(fixedVariable, "fixedVariable");

            this.fixedVariable = fixedVariable;
            this.AddExpression(fixedVariable);
        }

        #endregion Internal Constructors

        #region Public Properties

        /// <summary>
        /// Gets the fixed variable.
        /// </summary>
        public VariableDeclarationExpression FixedVariable
        {
            get
            {
                return this.fixedVariable;
            }
        }

        /// <summary>
        /// Gets the statement that is embedded within this fixed-statement.
        /// </summary>
        public Statement EmbeddedStatement
        {
            get
            {
                return this.embeddedStatement;
            }

            internal set
            {
                Param.AssertNotNull(value, "EmbeddedStatement");
                this.embeddedStatement = value;
                this.AddStatement(this.embeddedStatement);
            }
        }

        #endregion Public Properties
    }
}
