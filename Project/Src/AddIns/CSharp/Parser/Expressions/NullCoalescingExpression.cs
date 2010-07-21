//-----------------------------------------------------------------------
// <copyright file="NullCoalescingExpression.cs" company="Microsoft">
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
    using System.Diagnostics;
    using System.Text;

    /// <summary>
    /// An expression representing a null coalescing operation.
    /// </summary>
    /// <subcategory>expression</subcategory>
    public sealed class NullCoalescingExpression : Expression
    {
        #region Private Fields

        /// <summary>
        /// The left hand side of the expression.
        /// </summary>
        private CodeUnitProperty<Expression> leftHandSide;

        /// <summary>
        /// The right hand side of the expression.
        /// </summary>
        private CodeUnitProperty<Expression> rightHandSide;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the NullCoalescingExpression class.
        /// </summary>
        /// <param name="proxy">Proxy object for the expression.</param>
        /// <param name="leftHandSide">The left hand side of the expression.</param>
        /// <param name="rightHandSide">The right hand side of the expression.</param>
        internal NullCoalescingExpression(CodeUnitProxy proxy, Expression leftHandSide, Expression rightHandSide)
            : base(proxy, ExpressionType.NullCoalescing)
        {
            Param.AssertNotNull(proxy, "proxy");
            Param.AssertNotNull(leftHandSide, "leftHandSide");
            Param.AssertNotNull(rightHandSide, "rightHandSide");

            this.leftHandSide.Value = leftHandSide;
            this.rightHandSide.Value = rightHandSide;
        }

        #endregion Internal Constructors

        #region Public Properties

        /// <summary>
        /// Gets the left hand side of the expression.
        /// </summary>
        public Expression LeftHandSide
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.leftHandSide.Initialized)
                {
                    this.Initialize();
                    Debug.Assert(this.leftHandSide.Value != null, "Failed to initialize");
                }

                return this.leftHandSide.Value;
            }
        }

        /// <summary>
        /// Gets the right hand side of the expression.
        /// </summary>
        public Expression RightHandSide
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.rightHandSide.Initialized)
                {
                    this.Initialize();
                    Debug.Assert(this.rightHandSide.Value != null, "Failed to initialize");
                }

                return this.rightHandSide.Value;
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

            this.leftHandSide.Reset();
            this.rightHandSide.Reset();
        }

        #endregion Protected Override Methods

        #region Private Methods

        /// <summary>
        /// Initializes the contents of the expression.
        /// </summary>
        private void Initialize()
        {
            this.leftHandSide.Value = this.FindFirstChild<Expression>();
            if (this.leftHandSide.Value == null)
            {
                throw new SyntaxException(this.Document, this.LineNumber);
            }

            NullCoalescingSymbolOperator o = this.leftHandSide.Value.FindNextSibling<NullCoalescingSymbolOperator>();
            if (o == null)
            {
                throw new SyntaxException(this.Document, this.LineNumber);
            }

            this.rightHandSide.Value = o.FindNextSibling<Expression>();
            if (this.rightHandSide.Value == null)
            {
                throw new SyntaxException(this.Document, this.LineNumber);
            }
        }

        #endregion Private Methods
    }
}
