//-----------------------------------------------------------------------
// <copyright file="QueryLetClause.cs" company="Microsoft">
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

    /// <summary>
    /// Describes a let clause in a query expression.
    /// </summary>
    public sealed class QueryLetClause : QueryClauseWithExpression
    {
        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the QueryLetClause class.
        /// </summary>
        /// <param name="proxy">Proxy object for the clause.</param>
        /// <param name="expression">The range expression.</param>
        internal QueryLetClause(CodeUnitProxy proxy, Expression expression)
            : base(proxy, QueryClauseType.Let, expression)
        {
            Param.AssertNotNull(proxy, "proxy");
            Param.AssertNotNull(expression, "expression");
        }

        #endregion Internal Constructors

        #region Public Properties

        /// <summary>
        /// Gets the variable that ranges over the values in the query result.
        /// </summary>
        public IVariable RangeVariable
        {
            get
            {
                // Find the 'let' keyword.
                LetToken letToken = this.FindFirstChild<LetToken>();
                if (letToken == null)
                {
                    return null;
                }

                return this.ExtractQueryVariable(letToken.FindNextSibling<Token>(), true, true);
            }
        }

        #endregion Public Properties

        #region Public Override Methods

        /// <summary>
        /// Gets the variables defined within this clause.
        /// </summary>
        /// <returns>Returns the collection of variables.</returns>
        public override IList<IVariable> GetVariables()
        {
            IVariable rangeVariable = this.RangeVariable;
            if (rangeVariable != null)
            {
                return new IVariable[] { rangeVariable };
            }

            return CsParser.EmptyVariableArray;
        }

        #endregion Public Override Methods
    }
}
