//-----------------------------------------------------------------------
// <copyright file="QueryContinuationClause.cs">
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

    /// <summary>
    /// Describes a continuation clause in a query expression.
    /// </summary>
    public sealed class QueryContinuationClause : QueryClause
    {
        #region Private Fields

        /// <summary>
        /// The list of clauses in the expression.
        /// </summary>
        private CodeUnitProperty<ICollection<QueryClause>> clauses;

        /// <summary>
        /// The variable declared within the clause.
        /// </summary>
        private CodeUnitProperty<IVariable> variable;

        /// <summary>
        /// The variables declared on the clause.
        /// </summary>
        private CodeUnitProperty<VariableCollection> variables;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the QueryContinuationClause class.
        /// </summary>
        /// <param name="proxy">Proxy object for the clause.</param>
        /// <param name="clauses">The collection of clauses in the expression.</param>
        internal QueryContinuationClause(CodeUnitProxy proxy, ICollection<QueryClause> clauses) 
            : base(proxy, QueryClauseType.Continuation)
        {
            Param.AssertNotNull(proxy, "proxy");
            Param.AssertNotNull(clauses, "clauses");

            this.clauses.Value = clauses;
            CsLanguageService.Debug.Assert(clauses.IsReadOnly, "The collection of query clauses should be read-only.");
        }

        #endregion Internal Constructors

        #region Public Override Properties

        /// <summary>
        /// Gets the variables defined within this clause.
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

                    IVariable variable = this.Variable;
                    if (variable != null)
                    {
                        this.variables.Value.Add(variable);
                    }
                }

                return this.variables.Value;
            }
        }

        #endregion Public Override Properties

        #region Public Properties

        /// <summary>
        /// Gets the continuation clause variable.
        /// </summary>
        public IVariable Variable
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.variable.Initialized)
                {
                    // Find the 'into' keyword.
                    IntoToken intoToken = this.FindFirstChild<IntoToken>();
                    if (intoToken == null)
                    {
                        this.variable.Value = null;
                    }
                    else
                    {
                        this.variable.Value = ExtractQueryVariable(intoToken.FindNextSiblingToken(), true, true);
                    }
                }

                return this.variable.Value;
            }
        }

        /// <summary>
        /// Gets the list of query clauses within this expression.
        /// </summary>
        public ICollection<QueryClause> ChildClauses
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

        #endregion Public Properties

        #region Protected Override Methods

        /// <summary>
        /// Resets the contents of the class.
        /// </summary>
        protected override void Reset()
        {
            base.Reset();

            this.clauses.Reset();
            this.variable.Reset();
            this.variables.Reset();
        }

        #endregion Protected Override Methods
    }
}
