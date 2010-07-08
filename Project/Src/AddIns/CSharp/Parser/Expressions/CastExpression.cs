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
        private TypeToken type;

        /// <summary>
        /// The expression being casted.
        /// </summary>
        private Expression castedExpression;

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

            this.type = CodeParser.ExtractTypeTokenFromLiteralExpression(type);
            this.castedExpression = castedExpression;
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
                return this.type;
            }
        }

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

        #endregion Public Properties
    }
}
