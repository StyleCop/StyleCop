//-----------------------------------------------------------------------
// <copyright file="LockStatement.cs" company="Microsoft">
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
    /// A lock-statement.
    /// </summary>
    /// <subcategory>statement</subcategory>
    public sealed class LockStatement : Statement
    {
        #region Private Fields

        /// <summary>
        /// The object to lock.
        /// </summary>
        private Expression lockedExpression;

        /// <summary>
        /// The statement that is embedded within this lock-statement.
        /// </summary>
        private Statement embeddedStatement;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the LockStatement class.
        /// </summary>
        /// <param name="proxy">Proxy object for the statement.</param>
        /// <param name="lockedExpression">The item to lock.</param>
        internal LockStatement(CodeUnitProxy proxy, Expression lockedExpression)
            : base(proxy, StatementType.Lock)
        {
            Param.AssertNotNull(proxy, "proxy");
            Param.AssertNotNull(lockedExpression, "lockedExpression");

            this.lockedExpression = lockedExpression;
        }

        #endregion Internal Constructors

        #region Public Properties

        /// <summary>
        /// Gets the item to lock.
        /// </summary>
        public Expression LockedExpression
        {
            get
            {
                return this.lockedExpression;
            }
        }

        /// <summary>
        /// Gets the statement that is embedded within this lock-statement.
        /// </summary>
        public Statement EmbeddedStatement
        {
            get
            {
                return this.embeddedStatement;
            }

            internal set
            {
                Param.AssertNotNull(value, "EmbeddedStatement");
                this.embeddedStatement = value;
            }
        }

        #endregion Public Properties
    }
}
