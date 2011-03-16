//-----------------------------------------------------------------------
// <copyright file="QueryExpression.cs">
//   MS-PL
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
    using System.Collections.Generic;

    /// <summary>
    /// An expression representing a query.
    /// </summary>
    /// <subcategory>expression</subcategory>
    public sealed class QueryExpression : Expression
    {
        /// <summary>
        /// The variables defined within the expression.
        /// </summary>
        private CodeUnitProperty<VariableCollection> variables;

        /// <summary>
        /// The collection of query clauses within the expression.
        /// </summary>
        private CodeUnitProperty<ICollection<QueryClause>> clauses;

        /// <summary>
        /// Initializes a new instance of the QueryExpression class.
        /// </summary>
        /// <param name="proxy">Proxy object for the expression.</param>
        internal QueryExpression(CodeUnitProxy proxy)
            : base(proxy, ExpressionType.Query)
        {
            Param.AssertNotNull(proxy, "proxy");
        }

        /// <summary>
        /// Gets the variables defined within this expression.
        /// </summary>
        /// <returns>Returns the collection of variables.</returns>
        public override VariableCollection Variables
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.variables.Initialized)
                {
                    this.variables.Value = new VariableCollection();
                    for (QueryClause clause = this.FindFirstChildQueryClause(); clause != null; clause = clause.FindNextSiblingQueryClause())
                    {
                        this.variables.Value.AddRange(clause.Variables);
                    }
                }

                return this.variables.Value;
            }
        }

        /// <summary>
        /// Gets the collection of query clauses within the expression.
        /// </summary>
        public ICollection<QueryClause> QueryClauses
        {
            get
            {
                this.ValidateEditVersion();
                
                if (!this.clauses.Initialized)
                {
                    this.clauses.Value = new List<QueryClause>(this.GetChildren<QueryClause>()).AsReadOnly();
                }

                return this.clauses.Value;
            }
        }

        /// <summary>
        /// Resets the contents of the class.
        /// </summary>
        protected override void Reset()
        {
            base.Reset();
            this.variables.Reset();
            this.clauses.Reset();
        }
    }
}
