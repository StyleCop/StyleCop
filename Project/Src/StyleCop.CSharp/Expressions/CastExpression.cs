// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CastExpression.cs" company="https://github.com/StyleCop">
//   MS-PL
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
// <summary>
//   An expression representing a cast operation.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// An expression representing a cast operation.
    /// </summary>
    /// <subcategory>expression</subcategory>
    public sealed class CastExpression : Expression
    {
        #region Fields

        /// <summary>
        /// The expression being casted.
        /// </summary>
        private readonly Expression castedExpression;

        /// <summary>
        /// The cast type.
        /// </summary>
        private readonly TypeToken type;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the CastExpression class.
        /// </summary>
        /// <param name="tokens">
        /// The list of tokens that form the expression.
        /// </param>
        /// <param name="type">
        /// The cast type.
        /// </param>
        /// <param name="castedExpression">
        /// The expression being casted.
        /// </param>
        internal CastExpression(CsTokenList tokens, LiteralExpression type, Expression castedExpression)
            : base(ExpressionType.Cast, tokens)
        {
            Param.AssertNotNull(tokens, "tokens");
            Param.AssertNotNull(type, "type");
            Param.AssertNotNull(castedExpression, "castedExpression");

            this.type = CodeParser.ExtractTypeTokenFromLiteralExpression(type);
            this.castedExpression = castedExpression;

            this.AddExpression(type);
            this.AddExpression(castedExpression);
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the expression being casted.
        /// </summary>
        public Expression CastedExpression
        {
            get
            {
                return this.castedExpression;
            }
        }

        /// <summary>
        /// Gets the cast type.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1721:PropertyNamesShouldNotMatchGetMethods", Justification = "API has already been published and should not be changed.")]
        public TypeToken Type
        {
            get
            {
                return this.type;
            }
        }

        #endregion
    }
}