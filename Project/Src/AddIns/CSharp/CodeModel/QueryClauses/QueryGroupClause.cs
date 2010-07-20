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
namespace Microsoft.StyleCop.CSharp.CodeModel
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// Describes a group clause in a query expression.
    /// </summary>
    public sealed class QueryGroupClause : QueryClause
    {
        #region Private Fields

        /// <summary>
        /// The range expression.
        /// </summary>
        private CodeUnitProperty<Expression> expression;

        /// <summary>
        /// The expression to group by.
        /// </summary>
        private CodeUnitProperty<Expression> groupByExpression;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the QueryGroupClause class.
        /// </summary>
        /// <param name="proxy">Proxy object for the clause.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="groupByExpression">The group by expression.</param>
        internal QueryGroupClause(CodeUnitProxy proxy, Expression expression, Expression groupByExpression)
            : base(proxy, QueryClauseType.Group)
        {
            Param.AssertNotNull(proxy, "proxy");
            Param.AssertNotNull(expression, "expression");
            Param.AssertNotNull(groupByExpression, "groupByExpression");

            this.groupByExpression.Value = groupByExpression;
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
                this.ValidateEditVersion();

                if (!this.groupByExpression.Initialized)
                {
                    this.Initialize();
                    Debug.Assert(this.groupByExpression.Value != null, "Failed to initialize");
                }

                return this.groupByExpression.Value;
            }
        }

        /// <summary>
        /// Gets the range expression.
        /// </summary>
        public Expression Expression
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.expression.Initialized)
                {
                    this.Initialize();
                    Debug.Assert(this.expression.Value != null, "Failed to initialize");
                }

                return this.expression.Value;
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

            this.groupByExpression.Reset();
            this.expression.Reset();
        }

        #endregion Protected Override Methods

        #region Private Methods

        /// <summary>
        /// Initializes the contents of the class.
        /// </summary>
        private void Initialize()
        {
            GroupToken groupToken = this.FindFirstChild<GroupToken>();
            if (groupToken == null)
            {
                throw new SyntaxException(this.Document, this.LineNumber);
            }

            this.expression.Value = groupToken.FindNextSibling<Expression>();
            if (this.expression.Value == null)
            {
                throw new SyntaxException(this.Document, this.LineNumber);
            }

            ByToken by = this.expression.Value.FindNextSibling<ByToken>();
            if (by == null)
            {
                throw new SyntaxException(this.Document, this.LineNumber);
            }

            this.groupByExpression.Value = by.FindNextSibling<Expression>();
            if (this.groupByExpression.Value == null)
            {
                throw new SyntaxException(this.Document, this.LineNumber);
            }
        }

        #endregion Private Methods
    }
}
