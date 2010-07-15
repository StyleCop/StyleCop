//-----------------------------------------------------------------------
// <copyright file="AsExpression.cs" company="Microsoft">
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
    /// An expression representing an as-operation.
    /// </summary>
    /// <subcategory>expression</subcategory>
    public sealed class AsExpression : Expression
    {
        #region Private Properties

        /// <summary>
        /// The value to convert.
        /// </summary>
        private CodeUnitProperty<Expression> value;

        /// <summary>
        /// The type to convert to.
        /// </summary>
        private CodeUnitProperty<TypeToken> type;

        #endregion Private Properties

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the AsExpression class.
        /// </summary>
        /// <param name="proxy">Proxy object for the expression.</param>
        /// <param name="value">The value to convert.</param>
        /// <param name="type">The type of the conversion.</param>
        internal AsExpression(CodeUnitProxy proxy, Expression value, LiteralExpression type)
            : base(proxy, ExpressionType.As)
        {
            Param.AssertNotNull(proxy, "proxy");
            Param.AssertNotNull(value, "value");
            Param.AssertNotNull(type, "type");

            this.value.Value = value;
            this.type.Value = CodeParser.ExtractTypeTokenFromLiteralExpression(type);
        }

        #endregion Internal Constructors

        #region Public Properties

        /// <summary>
        /// Gets the value to convert.
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

        /// <summary>
        /// Gets the type of the conversion.
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

        #endregion Public Properties

        #region Protected Override Methods

        /// <summary>
        /// Resets the contents of the class.
        /// </summary>
        protected override void Reset()
        {
            base.Reset();

            this.value.Reset();
            this.type.Reset();
        }

        #endregion Protected Override Methods

        #region Private Methods

        /// <summary>
        /// Initializes the contents of the expression.
        /// </summary>
        private void Initialize()
        {
            this.value.Value = this.FindFirstChild<Expression>();
            if (this.value.Value == null)
            {
                throw new SyntaxException(this.Document, this.LineNumber);
            }

            AsToken @as = this.value.Value.FindNextSibling<AsToken>();
            if (@as == null)
            {
                throw new SyntaxException(this.Document, this.LineNumber);
            }

            LiteralExpression literal = @as.FindNextSibling<LiteralExpression>();
            if (literal == null)
            {
                throw new SyntaxException(this.Document, this.LineNumber);
            }

            this.type.Value = CodeParser.ExtractTypeTokenFromLiteralExpression(literal);
        }

        #endregion Private Methods
    }
}
