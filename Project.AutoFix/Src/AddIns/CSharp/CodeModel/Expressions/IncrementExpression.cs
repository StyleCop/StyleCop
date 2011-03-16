//-----------------------------------------------------------------------
// <copyright file="IncrementExpression.cs">
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
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// An expression representing an increment operation.
    /// </summary>
    public abstract class IncrementExpression : Expression
    {
        #region Private Fields

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
        /// <param name="type">The type of increment being performed.</param>
        internal IncrementExpression(CodeUnitProxy proxy, Expression value, IncrementExpressionType type)
            : base(proxy, (int)type)
        {
            Param.AssertNotNull(proxy, "proxy");
            Param.AssertNotNull(value, "value");
            Param.Ignore(type);

            CsLanguageService.Debug.Assert(System.Enum.IsDefined(typeof(IncrementExpressionType), this.IncrementExpressionType), "The type is invalid.");

            this.value.Value = value;
        }

        #endregion Internal Constructors

        #region Public Properties

        /// <summary>
        /// Gets the type of the expression.
        /// </summary>
        public IncrementExpressionType IncrementExpressionType
        {
            get
            {
                return (IncrementExpressionType)(this.FundamentalType & (int)FundamentalTypeMasks.IncrementExpression);
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
                    CsLanguageService.Debug.Assert(this.value.Value != null, "Failed to initialize");
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

        #region Private Methods

        /// <summary>
        /// Initializes the contents of the expression.
        /// </summary>
        private void Initialize()
        {
            this.value.Value = null;

            for (CodeUnit c = this.FindFirstChild(); c != null; c = c.FindNextSibling())
            {
                if (c.Is(OperatorType.Increment))
                {
                    this.value.Value = c.FindNextSiblingExpression();
                    if (this.value.Value == null)
                    {
                        throw new SyntaxException(this.Document, this.LineNumber);
                    }

                    break;
                }
                else if (c.Is(CodeUnitType.Expression))
                {
                    this.value.Value = (Expression)c;
                    var operatorSymbol = c.FindNextSibling<IncrementOperator>();
                    if (operatorSymbol == null)
                    {
                        throw new SyntaxException(this.Document, this.LineNumber);
                    }

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
