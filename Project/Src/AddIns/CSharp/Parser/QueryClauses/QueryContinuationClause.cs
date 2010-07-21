//-----------------------------------------------------------------------
// <copyright file="QueryContinuationClause.cs" company="Microsoft">
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
    using System.Diagnostics;

    /// <summary>
    /// Describes a continuation clause in a query expression.
    /// </summary>
    public sealed class QueryContinuationClause : QueryClause
    {
        #region Private Fields

        /// <summary>
        /// The list of clauses in the expression.
        /// </summary>
        private ICollection<QueryClause> clauses;

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

            this.clauses = clauses;
            Debug.Assert(clauses.IsReadOnly, "The collection of query clauses should be read-only.");
        }

        #endregion Internal Constructors

        #region Public Properties

        /// <summary>
        /// Gets the continuation clause variable.
        /// </summary>
        public IVariable Variable
        {
            get
            {
                // Find the 'into' keyword.
                IntoToken intoToken = this.FindFirstChild<IntoToken>();
                if (intoToken == null)
                {
                    return null;
                }

                return this.ExtractQueryVariable(intoToken.FindNextSibling<Token>(), true, true);
            }
        }

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

        #endregion Public Properties

        #region Public Override Methods

        /// <summary>
        /// Gets the variables defined within this clause.
        /// </summary>
        /// <returns>Returns the collection of variables.</returns>
        public override IList<IVariable> GetVariables()
        {
            IVariable variable = this.Variable;
            if (variable != null)
            {
                return new IVariable[] { variable };
            }

            return CsParser.EmptyVariableArray;
        }

        #endregion Public Override Methods
    }
}
