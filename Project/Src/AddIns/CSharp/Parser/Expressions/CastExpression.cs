//-----------------------------------------------------------------------
// <copyright file="CastExpression.cs" company="Microsoft">
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
    /// An expression representing a cast operation.
    /// </summary>
    /// <subcategory>expression</subcategory>
    public sealed class CastExpression : Expression
    {
        #region Private Fields

        /// <summary>
        /// The cast type.
        /// </summary>
        private CodeUnitProperty<TypeToken> type;

        /// <summary>
        /// The expression being casted.
        /// </summary>
        private CodeUnitProperty<Expression> castedExpression;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the CastExpression class.
        /// </summary>
        /// <param name="proxy">Proxy object for the expression.</param>
        /// <param name="type">The cast type.</param>
        /// <param name="castedExpression">The expression being casted.</param>
        internal CastExpression(CodeUnitProxy proxy, LiteralExpression type, Expression castedExpression)
            : base(proxy, ExpressionType.Cast)
        {
            Param.AssertNotNull(proxy, "proxy");
            Param.AssertNotNull(type, "type");
            Param.AssertNotNull(castedExpression, "castedExpression");

            this.type.Value = CodeParser.ExtractTypeTokenFromLiteralExpression(type);
            this.castedExpression.Value = castedExpression;
        }

        #endregion Internal Constructors

        #region Public Properties

        /// <summary>
        /// Gets the cast type.
        /// </summary>
        [SuppressMessage(
            "Microsoft.Naming", 
            "CA1721:PropertyNamesShouldNotMatchGetMethods",
            Justification = "API has already been published and should not be changed.")]
        public TypeToken Type
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.type.Initialized)
                {
                    this.Initialize();
                    Debug.Assert(this.type.Value != null, "Failed to initialize");
                }

                return this.type.Value;
            }
        }

        /// <summary>
        /// Gets the expression being casted.
        /// </summary>
        public Expression CastedExpression
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.castedExpression.Initialized)
                {
                    this.Initialize();
                    Debug.Assert(this.type.Value != null, "Failed to initialize");
                }

                return this.castedExpression.Value;
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

            this.type.Reset();
            this.castedExpression.Reset();
        }

        #endregion Protected Override Methods

        #region Private Methods

        /// <summary>
        /// Initializes the contents of the expression.
        /// </summary>
        private void Initialize()
        {
            OpenParenthesisToken openParen = this.FindFirstChild<OpenParenthesisToken>();
            if (openParen == null)
            {
                throw new SyntaxException(this.Document, this.LineNumber);
            }

            LiteralExpression literal = openParen.FindNextSibling<LiteralExpression>();
            if (literal == null)
            {
                throw new SyntaxException(this.Document, this.LineNumber);
            }

            this.type.Value = CodeParser.ExtractTypeTokenFromLiteralExpression(literal);

            CloseParenthesisToken closeParen = literal.FindNextSibling<CloseParenthesisToken>();
            if (closeParen == null)
            {
                throw new SyntaxException(this.Document, this.LineNumber);
            }

            this.castedExpression.Value = closeParen.FindNextSibling<LiteralExpression>();
            if (this.castedExpression.Value == null)
            {
                throw new SyntaxException(this.Document, this.LineNumber);
            }
        }

        #endregion Private Methods
    }
}
