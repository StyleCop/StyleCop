//-----------------------------------------------------------------------
// <copyright file="IncrementExpression.cs" company="Microsoft">
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
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// An expression representing an increment operation.
    /// </summary>
    /// <subcategory>expression</subcategory>
    public sealed class IncrementExpression : Expression
    {
        #region Private Fields

        /// <summary>
        /// The type of increment being performed.
        /// </summary>
        private CodeUnitProperty<IncrementType> incrementType;

        /// <summary>
        /// The value being incremented.
        /// </summary>
        private CodeUnitProperty<Expression> value;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the IncrementExpression class.
        /// </summary>
        /// <param name="proxy">Proxy object for the expression.</param>
        /// <param name="value">The value being incremented.</param>
        /// <param name="incrementType">The type of increment being performed.</param>
        internal IncrementExpression(CodeUnitProxy proxy, Expression value, IncrementType incrementType)
            : base(proxy, ExpressionType.Increment)
        {
            Param.AssertNotNull(proxy, "proxy");
            Param.AssertNotNull(value, "value");
            Param.Ignore(incrementType);

            this.value.Value = value;
            this.incrementType.Value = incrementType;
        }

        #endregion Internal Constructors

        #region Public Enums

        /// <summary>
        /// The various types of increment operations.
        /// </summary>
        /// <subcategory>expression</subcategory>
        [SuppressMessage(
            "Microsoft.Design", 
            "CA1034:NestedTypesShouldNotBeVisible",
            Justification = "API has already been published and should not be changed.")]
        public enum IncrementType
        {
            /// <summary>
            /// A prefix increment: ++x.
            /// </summary>
            Prefix,

            /// <summary>
            /// A postfix increment: x++.
            /// </summary>
            Postfix
        }

        #endregion Public Enums

        #region Public Properties

        /// <summary>
        /// Gets the type of increment being performed.
        /// </summary>
        [SuppressMessage(
            "Microsoft.Naming", 
            "CA1721:PropertyNamesShouldNotMatchGetMethods",
            Justification = "API has already been published and should not be changed.")]
        public IncrementType Type
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.incrementType.Initialized)
                {
                    this.Initialize();
                }

                return this.incrementType.Value;
            }
        }

        /// <summary>
        /// Gets the value being incremented.
        /// </summary>
        public Expression Value
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.value.Initialized)
                {
                    this.Initialize();
                    Debug.Assert(this.value.Value != null, "Failed to initialize");
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

            this.incrementType.Reset();
            this.value.Reset();
        }

        #endregion Protected Override Methods

        #region Private Methods

        /// <summary>
        /// Initializes the contents of the expression.
        /// </summary>
        private void Initialize()
        {
            this.value.Value = null;

            for (CodeUnit c = this.FindFirstChild<CodeUnit>(); c != null; c = c.FindNextSibling<CodeUnit>())
            {
                if (c.Is(OperatorType.Increment))
                {
                    this.incrementType.Value = IncrementType.Prefix;
                    this.value.Value = c.FindNextSibling<Expression>();
                    if (this.value.Value == null)
                    {
                        throw new SyntaxException(this.Document, this.LineNumber);
                    }

                    break;
                }
                else if (c.Is(CodeUnitType.Expression))
                {
                    this.value.Value = (Expression)c;
                    var operatorSymbol = this.FindNextSibling<IncrementOperator>();
                    if (operatorSymbol == null)
                    {
                        throw new SyntaxException(this.Document, this.LineNumber);
                    }

                    this.incrementType.Value = IncrementType.Postfix;
                    break;
                }
            }

            if (this.value.Value == null)
            {
                throw new SyntaxException(this.Document, this.LineNumber);
            }
        }

        #endregion Private Methods
    }
}
