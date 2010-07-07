//-----------------------------------------------------------------------
// <copyright file="IsExpression.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
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
    /// An expression representing an is-operation.
    /// </summary>
    /// <subcategory>expression</subcategory>
    public sealed class IsExpression : Expression
    {
        #region Private Properties

        /// <summary>
        /// The value to check.
        /// </summary>
        private Expression value;

        /// <summary>
        /// The type to check.
        /// </summary>
        private TypeToken type;

        #endregion Private Properties

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the IsExpression class.
        /// </summary>
        /// <param name="proxy">Proxy object for the expression.</param>
        /// <param name="value">The value to check.</param>
        /// <param name="type">The type to check.</param>
        internal IsExpression(CodeUnitProxy proxy, Expression value, LiteralExpression type)
            : base(proxy, ExpressionType.Is)
        {
            Param.AssertNotNull(proxy, "proxy");
            Param.AssertNotNull(value, "value");
            Param.AssertNotNull(type, "type");

            this.value = value;
            this.type = CodeParser.ExtractTypeTokenFromLiteralExpression(type);
        }

        #endregion Internal Constructors

        #region Public Properties

        /// <summary>
        /// Gets the value to check.
        /// </summary>
        public Expression Value
        {
            get
            {
                return this.value;
            }
        }

        /// <summary>
        /// Gets the type to check.
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

        #endregion Public Properties
    }
}
