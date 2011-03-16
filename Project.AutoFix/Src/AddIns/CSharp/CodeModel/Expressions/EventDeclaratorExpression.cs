//-----------------------------------------------------------------------
// <copyright file="EventDeclaratorExpression.cs">
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

    /// <summary>
    /// A single declarator within a event.
    /// </summary>
    /// <subcategory>expression</subcategory>
    public sealed partial class EventDeclaratorExpression : Expression
    {
        #region Private Fields

        /// <summary>
        /// The identifier of the event.
        /// </summary>
        private CodeUnitProperty<LiteralExpression> identifier;

        /// <summary>
        /// The initialization expression for the event.
        /// </summary>
        private CodeUnitProperty<Expression> initializer;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the EventDeclaratorExpression class.
        /// </summary>
        /// <param name="proxy">Proxy object for the expression.</param>
        /// <param name="identifier">The identifier name of the event.</param>
        /// <param name="initializer">The initialization expression for the event.</param>
        internal EventDeclaratorExpression(
            CodeUnitProxy proxy,
            LiteralExpression identifier, 
            Expression initializer)
            : base(proxy, ExpressionType.EventDeclarator)
        {
            Param.AssertNotNull(proxy, "proxy");
            Param.AssertNotNull(identifier, "identifier");
            Param.Ignore(initializer);

            this.identifier.Value = identifier;
            this.initializer.Value = initializer;
        }

        #endregion Internal Constructors

        #region Public Properties

        /// <summary>
        /// Gets the identifier name of the event.
        /// </summary>
        public LiteralExpression Identifier
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.identifier.Initialized)
                {
                    this.Initialize();
                    CsLanguageService.Debug.Assert(this.identifier.Value != null, "Failed to initialize");
                }

                return this.identifier.Value;
            }
        }

        /// <summary>
        /// Gets the initialization statement for the event.
        /// </summary>
        public Expression Initializer
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.initializer.Initialized)
                {
                    this.Initialize();
                }

                return this.initializer.Value;
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

            this.identifier.Reset();
            this.initializer.Reset();
        }

        #endregion Protected Override Methods

        #region Private Methods

        /// <summary>
        /// Initializes the contents of the expression.
        /// </summary>
        private void Initialize()
        {
            this.identifier.Value = this.FindFirstChild<LiteralExpression>();
            if (this.identifier.Value == null)
            {
                throw new SyntaxException(this.Document, this.LineNumber);
            }

            EqualsOperator equals = this.identifier.Value.FindNextSibling<EqualsOperator>();
            if (equals == null)
            {
                this.initializer.Value = null;
            }
            else
            {
                this.initializer.Value = equals.FindNextSiblingExpression();
                if (this.initializer.Value == null)
                {
                    throw new SyntaxException(this.Document, this.LineNumber);
                }
            }
        }

        #endregion Private Methods
    }
}
