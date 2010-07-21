//-----------------------------------------------------------------------
// <copyright file="QueryJoinClause.cs" company="Microsoft">
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
    /// Describes a join clause in a query expression.
    /// </summary>
    public sealed class QueryJoinClause : QueryClause
    {
        #region Private Fields

        /// <summary>
        /// The expression after the 'in' keyword.
        /// </summary>
        private Expression inExpression;

        /// <summary>
        /// The expression after the 'on' keyword.
        /// </summary>
        private Expression onKeyExpression;

        /// <summary>
        /// The expression after the 'equals' keyword.
        /// </summary>
        private Expression equalsKeyExpression;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the QueryJoinClause class.
        /// </summary>
        /// <param name="proxy">Proxy object for the clause.</param>
        /// <param name="inExpression">The expression after the 'in' keyword.</param>
        /// <param name="onKeyExpression">The expression after the 'on' keyword.</param>
        /// <param name="equalsKeyExpression">The expression after the 'equals' keyword.</param>
        internal QueryJoinClause(
            CodeUnitProxy proxy,
            Expression inExpression, 
            Expression onKeyExpression,
            Expression equalsKeyExpression)
            : base(proxy, QueryClauseType.Join)
        {
            Param.AssertNotNull(proxy, "proxy");
            Param.AssertNotNull(inExpression, "inExpression");
            Param.AssertNotNull(onKeyExpression, "onKeyExpression");
            Param.AssertNotNull(equalsKeyExpression, "equalsKeyExpression");

            this.inExpression = inExpression;
            this.onKeyExpression = onKeyExpression;
            this.equalsKeyExpression = equalsKeyExpression;
        }

        #endregion Internal Constructors

        #region Public Override Properties

        /// <summary>
        /// Gets the variables defined within this clause.
        /// </summary>
        public override IList<IVariable> Variables
        {
            get
            {
                IVariable rangeVariable = this.RangeVariable;
                IVariable intoVariable = this.IntoVariable;

                if (rangeVariable != null)
                {
                    if (intoVariable != null)
                    {
                        return new IVariable[] { rangeVariable, intoVariable };
                    }
                    else
                    {
                        return new IVariable[] { rangeVariable };
                    }
                }
                else if (intoVariable != null)
                {
                    return new IVariable[] { intoVariable };
                }

                return CsParser.EmptyVariableArray;
            }
        }

        #endregion Public Override Properties

        #region Public Properties

        /// <summary>
        /// Gets the variable that ranges over the values in the query result.
        /// </summary>
        public IVariable RangeVariable
        {
            get
            {
                // Find the 'join' keyword.
                JoinToken joinToken = this.FindFirstChild<JoinToken>();
                if (joinToken == null)
                {
                    return null;
                }

                return ExtractQueryVariable(joinToken.FindNextSibling<Token>(), true, false);
            }
        }

        /// <summary>
        /// Gets the expression after the 'in' keyword.
        /// </summary>
        public Expression InExpression
        {
            get
            {
                return this.inExpression;
            }
        }

        /// <summary>
        /// Gets the expression after the 'on' keyword.
        /// </summary>
        public Expression OnKeyExpression
        {
            get
            {
                return this.onKeyExpression;
            }
        }

        /// <summary>
        /// Gets the expression after the 'equals' keyword.
        /// </summary>
        public Expression EqualsKeyExpression
        {
            get
            {
                return this.equalsKeyExpression;
            }
        }

        /// <summary>
        /// Gets the optional variable that the result is placed into.
        /// </summary>
        public IVariable IntoVariable
        {
            get
            {
                // Find the 'into' keyword.
                IntoToken intoToken = this.FindFirstChild<IntoToken>();
                if (intoToken == null)
                {
                    return null;
                }

                return ExtractQueryVariable(intoToken.FindNextSibling<Token>(), true, true);
            }
        }

        #endregion Public Properties
    }
}
