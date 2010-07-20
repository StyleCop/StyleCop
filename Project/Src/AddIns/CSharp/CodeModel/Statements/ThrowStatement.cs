//-----------------------------------------------------------------------
// <copyright file="ThrowStatement.cs" company="Microsoft">
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

    /// <summary>
    /// A throw-statement.
    /// </summary>
    /// <subcategory>statement</subcategory>
    public sealed class ThrowStatement : Statement
    {
        #region Private Fields

        /// <summary>
        /// The expression being thrown, if any.
        /// </summary>
        private CodeUnitProperty<Expression> thrownExpression;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the ThrowStatement class.
        /// </summary>
        /// <param name="proxy">Proxy object for the statement.</param>
        /// <param name="thrownExpression">The expression being thrown, if any.</param>
        internal ThrowStatement(CodeUnitProxy proxy, Expression thrownExpression)
            : base(proxy, StatementType.Throw)
        {
            Param.Ignore(proxy);
            Param.Ignore(thrownExpression);

            this.thrownExpression.Value = thrownExpression;
        }

        #endregion Internal Constructors

        #region Public Properties

        /// <summary>
        /// Gets the expression being thrown, if any.
        /// </summary>
        public Expression ThrownExpression
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.thrownExpression.Initialized)
                {
                    this.thrownExpression.Value = this.FindFirstChild<Expression>();
                    if (this.thrownExpression.Value == null)
                    {
                        throw new SyntaxException(this.Document, this.LineNumber);
                    }
                }

                return this.thrownExpression.Value;
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

            this.thrownExpression.Reset();
        }

        #endregion Protected Override Methods
    }
}
