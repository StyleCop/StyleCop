//-----------------------------------------------------------------------
// <copyright file="UnsafeAccessExpression.cs" company="Microsoft">
//   Copyright (c) Microsoft Corporation.
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
    using System.Diagnostics.CodeAnalysis;
    using System.Text;

    /// <summary>
    /// An expression representing a dereference or address-of operation.
    /// </summary>
    /// <subcategory>expression</subcategory>
    public sealed class UnsafeAccessExpression : Expression
    {
        #region Private Fields

        /// <summary>
        /// The type of operation being performed.
        /// </summary>
        private CodeUnitProperty<Operator> operatorType;

        /// <summary>
        /// The expression the operator is being applied to.
        /// </summary>
        private CodeUnitProperty<Expression> value;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the UnsafeAccessExpression class.
        /// </summary>
        /// <param name="proxy">Proxy object for the expression.</param>
        /// <param name="operatorType">The type of operation being performed.</param>
        /// <param name="value">The value the operator is being applied to.</param>
        internal UnsafeAccessExpression(CodeUnitProxy proxy, Operator operatorType, Expression value)
            : base(proxy, ExpressionType.UnsafeAccess)
        {
            Param.AssertNotNull(proxy, "proxy");
            Param.Ignore(operatorType);
            Param.AssertNotNull(value, "value");

            this.operatorType.Value = operatorType;
            this.value.Value = value;
        }

        #endregion Internal Constructors

        #region Public Enums

        /// <summary>
        /// The various unsafe access operator types.
        /// </summary>
        /// <subcategory>expression</subcategory>
        [SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible", Justification = "Leave nested to avoid changing external interface.")]
        [SuppressMessage("Microsoft.Naming", "CA1716:IdentifiersShouldNotMatchKeywords", Justification = "The enum describes a C# operator.")]
        public enum Operator
        {
            /// <summary>
            /// The * operator.
            /// </summary>
            Dereference,

            /// <summary>
            /// The ampersand address-of operator.
            /// </summary>
            AddressOf
        }

        #endregion Public Enums

        #region Public Properties

        /// <summary>
        /// Gets the type of operation being performed.
        /// </summary>
        public Operator OperatorType
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.operatorType.Initialized)
                {
                    var operatorToken = this.FindFirstChild<OperatorSymbolToken>();
                    if (operatorToken != null)
                    {
                        if (operatorToken.SymbolType == CSharp.OperatorType.AddressOf)
                        {
                            this.operatorType.Value = Operator.AddressOf;
                        }
                        else if (operatorToken.SymbolType == CSharp.OperatorType.Dereference)
                        {
                            this.operatorType.Value = Operator.Dereference;
                        }
                    }

                    if (!this.operatorType.Initialized)
                    {
                        throw new SyntaxException(this.Document, this.LineNumber);
                    }
                }

                return this.operatorType.Value;
            }
        }

        /// <summary>
        /// Gets the value of the expression.
        /// </summary>
        public Expression Value
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.value.Initialized)
                {
                    this.value.Value = this.FindFirstChild<Expression>();
                    if (this.value.Value == null)
                    {
                        throw new SyntaxException(this.Document, this.LineNumber);
                    }
                }

                return this.value.Value;
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

            this.operatorType.Reset();
            this.value.Reset();
        }

        #endregion Protected Override Methods
    }
}
