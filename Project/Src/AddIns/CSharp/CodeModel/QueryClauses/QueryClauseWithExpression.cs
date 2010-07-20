//-----------------------------------------------------------------------
// <copyright file="QueryClauseWithExpression.cs" company="Microsoft">
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
////namespace Microsoft.StyleCop.CSharp.CodeModel
////{
////    using System;

////    /// <summary>
////    /// A base class for a query clause which contains an embedded expression.
////    /// </summary>
////    public abstract class QueryClauseWithExpression : QueryClause
////    {
////        #region Private Fields

////        /// <summary>
////        /// The range expression.
////        /// </summary>
////        private Expression expression;

////        #endregion Private Fields

////        #region Internal Constructors

////        /// <summary>
////        /// Initializes a new instance of the QueryClauseWithExpression class.
////        /// </summary>
////        /// <param name="proxy">Proxy object for the expression.</param>
////        /// <param name="type">The type of the query clause.</param>
////        /// <param name="expression">The range expression.</param>
////        internal QueryClauseWithExpression(CodeUnitProxy proxy, QueryClauseType type, Expression expression) 
////            : base(proxy, type)
////        {
////            Param.AssertNotNull(proxy, "proxy");
////            Param.Ignore(type);
////            Param.AssertNotNull(expression, "expression");

////            this.expression = expression;
////        }

////        #endregion Internal Constructors

////        #region Public Properties

////        /// <summary>
////        /// Gets the range expression.
////        /// </summary>
////        public Expression Expression
////        {
////            get
////            {
////                return this.expression;
////            }
////        }

////        #endregion Public Properties
////    }
////}
