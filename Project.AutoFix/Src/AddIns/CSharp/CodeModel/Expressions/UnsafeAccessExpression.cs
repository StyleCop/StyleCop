//-----------------------------------------------------------------------
// <copyright file="UnsafeAccessExpression.cs">
//   MS-PL
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
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Text;

    /// <summary>
    /// An expression representing a dereference or address-of operation.
    /// </summary>
    /// <subcategory>expression</subcategory>
    public abstract class UnsafeAccessExpression : Expression
    {
        #region Private Fields

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
        /// <param name="type">The type of operation being performed.</param>
        /// <param name="value">The value the operator is being applied to.</param>
        internal UnsafeAccessExpression(CodeUnitProxy proxy, UnsafeAccessExpressionType type, Expression value)
            : base(proxy, (int)type)
        {
            Param.AssertNotNull(proxy, "proxy");
            Param.Ignore(type);
            Param.AssertNotNull(value, "value");

            CsLanguageService.Debug.Assert(System.Enum.IsDefined(typeof(UnsafeAccessExpressionType), this.UnsafeAccessExpressionType), "The type is invalid.");

            this.value.Value = value;
        }

        #endregion Internal Constructors

        #region Public Properties

        /// <summary>
        /// Gets the type of the expression.
        /// </summary>
        public UnsafeAccessExpressionType UnsafeAccessExpressionType
        {
            get
            {
                return (UnsafeAccessExpressionType)(this.FundamentalType & (int)FundamentalTypeMasks.UnsafeAccessExpression);
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
                    this.value.Value = this.FindFirstChildExpression();
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
            this.value.Reset();
        }

        #endregion Protected Override Methods
    }
}
