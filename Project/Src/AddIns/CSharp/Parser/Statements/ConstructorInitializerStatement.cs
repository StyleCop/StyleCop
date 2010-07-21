//-----------------------------------------------------------------------
// <copyright file="ConstructorInitializerStatement.cs" company="Microsoft">
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

    /// <summary>
    /// A constructor initialization statement.
    /// </summary>
    /// <subcategory>statement</subcategory>
    public sealed class ConstructorInitializerStatement : Statement
    {
        #region Private Fields

        /// <summary>
        /// The expression within this statement.
        /// </summary>
        private MethodInvocationExpression expression;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the ConstructorInitializerStatement class.
        /// </summary>
        /// <param name="proxy">Proxy object for the statement.</param>
        /// <param name="expression">The expression within this statement.</param>
        internal ConstructorInitializerStatement(CodeUnitProxy proxy, MethodInvocationExpression expression)
            : base(proxy, StatementType.ConstructorInitializer)
        {
            Param.AssertNotNull(proxy, "proxy");
            Param.AssertNotNull(expression, "expression");

            this.expression = expression;
        }

        #endregion Internal Constructors

        #region Public Properties

        /// <summary>
        /// Gets the expression within this statement.
        /// </summary>
        public MethodInvocationExpression Expression
        {
            get
            {
                return this.expression;
            }
        }

        #endregion Public Properties
    }
}
