//-----------------------------------------------------------------------
// <copyright file="QueryGroupClause.cs" company="Microsoft">
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

    /// <summary>
    /// Describes a group clause in a query expression.
    /// </summary>
    public sealed class QueryGroupClause : QueryClauseWithExpression
    {
        #region Private Fields

        /// <summary>
        /// The expression to group by.
        /// </summary>
        private Expression groupByExpression;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the QueryGroupClause class.
        /// </summary>
        /// <param name="proxy">Proxy object for the clause.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="groupByExpression">The group by expression.</param>
        internal QueryGroupClause(CodeUnitProxy proxy, Expression expression, Expression groupByExpression)
            : base(proxy, QueryClauseType.Group, expression)
        {
            Param.AssertNotNull(proxy, "proxy");
            Param.AssertNotNull(expression, "expression");
            Param.AssertNotNull(groupByExpression, "groupByExpression");

            this.groupByExpression = groupByExpression;
        }

        #endregion Internal Constructors

        #region Public Properties

        /// <summary>
        /// Gets the expression to group by.
        /// </summary>
        public Expression GroupByExpression
        {
            get
            {
                return this.groupByExpression;
            }
        }

        #endregion Public Properties
    }
}
