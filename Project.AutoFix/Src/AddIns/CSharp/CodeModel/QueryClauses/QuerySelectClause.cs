//-----------------------------------------------------------------------
// <copyright file="QuerySelectClause.cs">
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

    /// <summary>
    /// Describes a select clause in a query expression.
    /// </summary>
    public sealed class QuerySelectClause : QueryClause
    {
        #region Private Fields

        /// <summary>
        /// The range expression.
        /// </summary>
        private CodeUnitProperty<Expression> expression;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the QuerySelectClause class.
        /// </summary>
        /// <param name="proxy">Proxy object for the clause.</param>
        /// <param name="expression">The expression.</param>
        internal QuerySelectClause(CodeUnitProxy proxy, Expression expression)
            : base(proxy, QueryClauseType.Select)
        {
            Param.AssertNotNull(proxy, "proxy");
            Param.AssertNotNull(expression, "expression");

            this.expression.Value = expression;
        }

        #endregion Internal Constructors

        #region Public Properties

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
                    SelectToken selectToken = this.FindFirstChild<SelectToken>();
                    if (selectToken == null)
                    {
                        throw new SyntaxException(this.Document, this.LineNumber);
                    }

                    this.expression.Value = selectToken.FindNextSiblingExpression();
                    if (this.expression.Value == null)
                    {
                        throw new SyntaxException(this.Document, this.LineNumber);
                    }
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

            this.expression.Reset();
        }

        #endregion Protected Override Methods
    }
}
