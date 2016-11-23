// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QueryExpression.cs" company="https://github.com/StyleCop">
//   MS-PL
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
// <summary>
//   An expression representing a query.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// An expression representing a query.
    /// </summary>
    /// <subcategory>expression</subcategory>
    public sealed class QueryExpression : Expression
    {
        #region Fields

        /// <summary>
        /// The list of clauses in the expression.
        /// </summary>
        private readonly CodeUnitCollection<QueryClause> clauses;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the QueryExpression class.
        /// </summary>
        /// <param name="tokens">
        /// The list of tokens that form the expression.
        /// </param>
        /// <param name="clauses">
        /// The collection of clauses in the expression.
        /// </param>
        internal QueryExpression(CsTokenList tokens, ICollection<QueryClause> clauses)
            : base(ExpressionType.Query, tokens)
        {
            Param.AssertNotNull(tokens, "tokens");
            Param.AssertNotNull(clauses, "clauses");

            this.clauses = new CodeUnitCollection<QueryClause>(this);
            this.clauses.AddRange(clauses);
            this.InitializeFromClauses(clauses);

            Debug.Assert(clauses.IsReadOnly, "The collection of query clauses should be read-only.");
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the list of query clauses within this expression.
        /// </summary>
        public ICollection<QueryClause> ChildClauses
        {
            get
            {
                return this.clauses;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Initializes the expression from the list of clauses.
        /// </summary>
        /// <param name="items">
        /// The list of clauses in the expression.
        /// </param>
        private void InitializeFromClauses(IEnumerable<QueryClause> items)
        {
            Param.AssertNotNull(items, "items");

            foreach (QueryClause clause in items)
            {
                foreach (Expression expression in clause.ChildExpressions)
                {
                    this.AddExpression(expression);
                }

                QueryContinuationClause continuationClause = clause as QueryContinuationClause;
                if (continuationClause != null)
                {
                    this.InitializeFromClauses(continuationClause.ChildClauses);
                }
            }
        }

        #endregion
    }
}