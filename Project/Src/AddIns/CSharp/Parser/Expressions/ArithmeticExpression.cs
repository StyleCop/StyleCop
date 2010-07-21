//-----------------------------------------------------------------------
// <copyright file="ArithmeticExpression.cs" company="Microsoft">
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
    using System.Diagnostics.CodeAnalysis;
    using System.Text;

    /// <summary>
    /// An expression representing an arithmetic operation.
    /// </summary>
    /// <subcategory>expression</subcategory>
    public sealed class ArithmeticExpression : Expression
    {
        #region Private Fields

        /// <summary>
        /// The type of arithmetic operation being performed.
        /// </summary>
        private CodeUnitProperty<Operator> operatorType;

        /// <summary>
        /// The left hand size of the expression.
        /// </summary>
        private CodeUnitProperty<Expression> leftHandSide;

        /// <summary>
        /// The right hand size of the expression.
        /// </summary>
        private CodeUnitProperty<Expression> rightHandSide;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the ArithmeticExpression class.
        /// </summary>
        /// <param name="proxy">Proxy object for the expression.</param>
        /// <param name="operatorType">The type of operation being performed.</param>
        /// <param name="leftHandSide">The left hand side of the expression.</param>
        /// <param name="rightHandSide">The right hand side of the expression.</param>
        internal ArithmeticExpression(
            CodeUnitProxy proxy,
            Operator operatorType,
            Expression leftHandSide,
            Expression rightHandSide)
            : base(proxy, ExpressionType.Arithmetic)
        {
            Param.AssertNotNull(proxy, "proxy");
            Param.Ignore(operatorType);
            Param.AssertNotNull(leftHandSide, "leftHandSide");
            Param.AssertNotNull(rightHandSide, "rightHandSide");

            this.operatorType.Value = operatorType;
            this.leftHandSide.Value = leftHandSide;
            this.rightHandSide.Value = rightHandSide;
        }

        #endregion Internal Constructors

        #region Public Enums

        /// <summary>
        /// The various arithmetic operator types.
        /// </summary>
        /// <subcategory>expression</subcategory>
        [SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible", Justification = "Leave nested to avoid changing external interface.")] 
        [SuppressMessage("Microsoft.Naming", "CA1716:IdentifiersShouldNotMatchKeywords", Justification = "Describes a C# operator type")]
        public enum Operator
        {
            /// <summary>
            /// The + operator.
            /// </summary>
            Addition,

            /// <summary>
            /// The - operator.
            /// </summary>
            Subtraction,

            /// <summary>
            /// The * operator.
            /// </summary>
            Multiplication,

            /// <summary>
            /// The / operator.
            /// </summary>
            Division,

            /// <summary>
            /// The % operator.
            /// </summary>
            Mod,

            /// <summary>
            /// The right-shift operator.
            /// </summary>
            RightShift,

            /// <summary>
            /// The left-shift operator.
            /// </summary>
            LeftShift
        }

        #endregion Public Enums

        #region Public Properties

        /// <summary>
        /// Gets the type of arithmetic operation being performed.
        /// </summary>
        public Operator OperatorType
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.operatorType.Initialized)
                {
                    this.Initialize();
                }

                return this.operatorType.Value;
            }
        }

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

            this.operatorType.Reset();
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

            OperatorSymbolToken o = this.leftHandSide.Value.FindNextSibling<OperatorSymbolToken>();
            if (o == null)
            {
                throw new SyntaxException(this.Document, this.LineNumber);
            }

            switch (o.SymbolType)
            {
                case CSharp.OperatorType.Plus:
                    this.operatorType.Value = Operator.Addition;
                    break;

                case CSharp.OperatorType.Minus:
                    this.operatorType.Value = Operator.Subtraction;
                    break;

                case CSharp.OperatorType.Multiplication:
                    this.operatorType.Value = Operator.Multiplication;
                    break;

                case CSharp.OperatorType.Division:
                    this.operatorType.Value = Operator.Division;
                    break;

                case CSharp.OperatorType.Mod:
                    this.operatorType.Value = Operator.Mod;
                    break;

                case CSharp.OperatorType.LeftShift:
                    this.operatorType.Value = Operator.LeftShift;
                    break;

                case CSharp.OperatorType.RightShift:
                    this.operatorType.Value = Operator.RightShift;
                    break;

                default:
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
