//-----------------------------------------------------------------------
// <copyright file="ExpressionStatement.cs" company="Microsoft">
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
    using System.Collections.Generic;

    /// <summary>
    /// A statement containing a single expression.
    /// </summary>
    /// <subcategory>statement</subcategory>
    public sealed class ExpressionStatement : Statement
    {
        #region Private Fields

        /// <summary>
        /// The expression within this statement.
        /// </summary>
        private CodeUnitProperty<Expression> expression;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the ExpressionStatement class.
        /// </summary>
        /// <param name="proxy">Proxy object for the statement.</param>
        /// <param name="expression">The expression within this statement.</param>
        internal ExpressionStatement(CodeUnitProxy proxy, Expression expression)
            : base(proxy, StatementType.Expression)
        {
            Param.AssertNotNull(proxy, "proxy");
            Param.AssertNotNull(expression, "expression");

            this.expression.Value = expression;
        }

        #endregion Internal Constructors

        #region Public Properties

        /// <summary>
        /// Gets the expression within this statement.
        /// </summary>
        public Expression Expression
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.expression.Initialized)
                {
                    this.expression.Value = this.FindFirstChild<Expression>();
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
