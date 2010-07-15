//-----------------------------------------------------------------------
// <copyright file="TypeofExpression.cs" company="Microsoft">
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
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// An expression representing a typeof operation.
    /// </summary>
    /// <subcategory>expression</subcategory>
    public sealed class TypeofExpression : Expression
    {
        #region Private Fields

        /// <summary>
        /// The type literal to get the type of.
        /// </summary>
        private CodeUnitProperty<TypeToken> type;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the TypeofExpression class.
        /// </summary>
        /// <param name="proxy">Proxy object for the expression.</param>
        /// <param name="type">The type literal to get the type of.</param>
        internal TypeofExpression(CodeUnitProxy proxy, LiteralExpression type)
            : base(proxy, ExpressionType.Typeof)
        {
            Param.AssertNotNull(proxy, "proxy");
            Param.AssertNotNull(type, "type");

            this.type.Value = CodeParser.ExtractTypeTokenFromLiteralExpression(type);
        }

        #endregion Internal Constructors

        #region Public Properties

        /// <summary>
        /// Gets the type literal to get the type of.
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
                    this.type.Value = null;
                    LiteralExpression literal = this.FindFirstChild<LiteralExpression>();
                    if (literal != null)
                    {
                        this.type.Value = CodeParser.ExtractTypeTokenFromLiteralExpression(literal);
                    }

                    if (this.type.Value == null)
                    {
                        throw new SyntaxException(this.Document, this.LineNumber);
                    }
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

            this.type.Reset();
        }

        #endregion Protected Override Methods
    }
}
