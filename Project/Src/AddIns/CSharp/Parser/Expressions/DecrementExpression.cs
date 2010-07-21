//-----------------------------------------------------------------------
// <copyright file="DecrementExpression.cs" company="Microsoft">
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
    /// An expression representing a decrement operation.
    /// </summary>
    /// <subcategory>expression</subcategory>
    public sealed class DecrementExpression : Expression
    {
        #region Private Fields

        /// <summary>
        /// The type of decrement being performed.
        /// </summary>
        private DecrementType decrementType;

        /// <summary>
        /// The value being decremented.
        /// </summary>
        private Expression value;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the DecrementExpression class.
        /// </summary>
        /// <param name="proxy">Proxy object for the expression.</param>
        /// <param name="value">The value being decremented.</param>
        /// <param name="decrementType">The type of decrement being performed.</param>
        internal DecrementExpression(CodeUnitProxy proxy, Expression value, DecrementType decrementType)
            : base(proxy, ExpressionType.Decrement)
        {
            Param.AssertNotNull(proxy, "proxy");
            Param.AssertNotNull(value, "value");
            Param.Ignore(decrementType);

            this.value = value;
            this.decrementType = decrementType;
        }

        #endregion Internal Constructors

        #region Public Enums

        /// <summary>
        /// The various types of decrement operations.
        /// </summary>
        /// <subcategory>expression</subcategory>
        [SuppressMessage(
            "Microsoft.Design",
            "CA1034:NestedTypesShouldNotBeVisible",
            Justification = "API has already been published and should not be changed.")]
        public enum DecrementType
        {
            /// <summary>
            /// A prefix decrement: --x.
            /// </summary>
            Prefix,

            /// <summary>
            /// A postfix decrement: x--.
            /// </summary>
            Postfix
        }

        #endregion Public Enums

        #region Public Properties

        /// <summary>
        /// Gets the type of decrement being performed.
        /// </summary>
        [SuppressMessage(
            "Microsoft.Naming", 
            "CA1721:PropertyNamesShouldNotMatchGetMethods",
            Justification = "API has already been published and should not be changed.")]
        public DecrementType Type
        {
            get
            {
                return this.decrementType;
            }
        }

        /// <summary>
        /// Gets the value being decremented.
        /// </summary>
        public Expression Value
        {
            get
            {
                return this.value;
            }
        }

        #endregion Public Properties
    }
}
