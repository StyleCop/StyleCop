//-----------------------------------------------------------------------
// <copyright file="DoWhileStatement.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
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
    /// A do-while-statement.
    /// </summary>
    /// <subcategory>statement</subcategory>
    public sealed class DoWhileStatement : Statement
    {
        #region Private Fields

        /// <summary>
        /// The statement that is embedded within this do-while-statement.
        /// </summary>
        private Statement embeddedStatement;

        /// <summary>
        /// The expression within the while statement.
        /// </summary>
        private Expression conditionExpression;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the DoWhileStatement class.
        /// </summary>
        /// <param name="proxy">Proxy object for the statement.</param>
        /// <param name="conditionExpression">The expression within the while statement.</param>
        /// <param name="embeddedStatement">The statement that is embedded within this do-while-statement.</param>
        internal DoWhileStatement(CodeUnitProxy proxy, Expression conditionExpression, Statement embeddedStatement)
            : base(proxy, StatementType.DoWhile)
        {
            Param.AssertNotNull(proxy, "proxy");
            Param.AssertNotNull(conditionExpression, "conditionExpression");
            Param.AssertNotNull(embeddedStatement, "embeddedStatement");

            this.conditionExpression = conditionExpression;
            this.embeddedStatement = embeddedStatement;
        }

        #endregion Internal Constructors

        #region Public Properties

        /// <summary>
        /// Gets the expression within the while statement.
        /// </summary>
        public Expression ConditionalExpression
        {
            get
            {
                return this.conditionExpression;
            }
        }

        /// <summary>
        /// Gets the statement that is embedded within this do-while-statement.
        /// </summary>
        public Statement EmbeddedStatement
        {
            get
            {
                return this.embeddedStatement;
            }
        }

        #endregion Public Properties
    }
}
