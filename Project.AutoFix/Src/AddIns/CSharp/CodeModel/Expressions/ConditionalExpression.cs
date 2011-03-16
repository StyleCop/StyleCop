//-----------------------------------------------------------------------
// <copyright file="ConditionalExpression.cs">
//     MS-PL
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
    using System.Text;

    /// <summary>
    /// An expression representing a conditional operation.
    /// </summary>
    /// <subcategory>expression</subcategory>
    public sealed class ConditionalExpression : Expression
    {
        #region Private Fields

        /// <summary>
        /// The condition being evaluated.
        /// </summary>
        private CodeUnitProperty<Expression> condition;

        /// <summary>
        /// The expression that is evaluated if the condition is true.
        /// </summary>
        private CodeUnitProperty<Expression> trueValue;

        /// <summary>
        /// The expression that is evaluated if the condition is false.
        /// </summary>
        private CodeUnitProperty<Expression> falseValue;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the ConditionalExpression class.
        /// </summary>
        /// <param name="proxy">Proxy object for the expression.</param>
        /// <param name="condition">The condition being evaluated.</param>
        /// <param name="trueValue">The expression that is evaluated if the condition is true.</param>
        /// <param name="falseValue">The expression that is evaluated if the condition is false.</param>
        internal ConditionalExpression(
            CodeUnitProxy proxy, Expression condition, Expression trueValue, Expression falseValue)
            : base(proxy, ExpressionType.Conditional)
        {
            Param.AssertNotNull(proxy, "proxy");
            Param.AssertNotNull(condition, "condition");
            Param.AssertNotNull(trueValue, "trueValue");
            Param.AssertNotNull(falseValue, "falseValue");

            this.condition.Value = condition;
            this.trueValue.Value = trueValue;
            this.falseValue.Value = falseValue;
        }

        #endregion Internal Constructors

        #region Public Properties

        /// <summary>
        /// Gets the condition that is being evaluated.
        /// </summary>
        public Expression Condition
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.condition.Initialized)
                {
                    this.Initialize();
                    CsLanguageService.Debug.Assert(this.condition.Value != null, "Failed to initialize");
                }

                return this.condition.Value;
            }
        }

        /// <summary>
        /// Gets the expression that is evaluated if the condition is true.
        /// </summary>
        public Expression TrueExpression
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.trueValue.Initialized)
                {
                    this.Initialize();
                    CsLanguageService.Debug.Assert(this.trueValue.Value != null, "Failed to initialize");
                }

                return this.trueValue.Value;
            }
        }

        /// <summary>
        /// Gets the expression that is evaluated if the condition is false.
        /// </summary>
        public Expression FalseExpression
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.falseValue.Initialized)
                {
                    this.Initialize();
                    CsLanguageService.Debug.Assert(this.falseValue.Value != null, "Failed to initialize");
                }

                return this.falseValue.Value;
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

            this.condition.Reset();
            this.trueValue.Reset();
            this.falseValue.Reset();
        }

        #endregion Protected Override Methods

        #region Private Methods

        /// <summary>
        /// Initializes the contents of the expression.
        /// </summary>
        private void Initialize()
        {
            this.condition.Value = this.FindFirstChildExpression();
            if (this.condition.Value == null)
            {
                throw new SyntaxException(this.Document, this.LineNumber);
            }

            ConditionalQuestionMarkOperator questionMark = this.condition.Value.FindNextSibling<ConditionalQuestionMarkOperator>();
            if (questionMark == null)
            {
                throw new SyntaxException(this.Document, this.LineNumber);
            }

            this.trueValue.Value = questionMark.FindNextSiblingExpression();
            if (this.trueValue.Value == null)
            {
                throw new SyntaxException(this.Document, this.LineNumber);
            }

            ConditionalColonOperator colon = this.condition.Value.FindNextSibling<ConditionalColonOperator>();
            if (colon == null)
            {
                throw new SyntaxException(this.Document, this.LineNumber);
            }

            this.falseValue.Value = colon.FindNextSiblingExpression();
            if (this.falseValue.Value == null)
            {
                throw new SyntaxException(this.Document, this.LineNumber);
            }
        }

        #endregion Private Methods
    }
}
