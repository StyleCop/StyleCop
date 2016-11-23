// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DecrementExpression.cs" company="https://github.com/StyleCop">
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
//   An expression representing a decrement operation.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// An expression representing a decrement operation.
    /// </summary>
    /// <subcategory>expression</subcategory>
    public sealed class DecrementExpression : Expression
    {
        #region Fields

        /// <summary>
        /// The type of decrement being performed.
        /// </summary>
        private readonly DecrementType decrementType;

        /// <summary>
        /// The value being decremented.
        /// </summary>
        private readonly Expression value;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the DecrementExpression class.
        /// </summary>
        /// <param name="tokens">
        /// The list of tokens that form the expression.
        /// </param>
        /// <param name="value">
        /// The value being decremented.
        /// </param>
        /// <param name="decrementType">
        /// The type of decrement being performed.
        /// </param>
        internal DecrementExpression(CsTokenList tokens, Expression value, DecrementType decrementType)
            : base(ExpressionType.Decrement, tokens)
        {
            Param.AssertNotNull(tokens, "tokens");
            Param.AssertNotNull(value, "value");
            Param.Ignore(decrementType);

            this.value = value;
            this.decrementType = decrementType;

            this.AddExpression(value);
        }

        #endregion

        #region Enums

        /// <summary>
        /// The various types of decrement operations.
        /// </summary>
        /// <subcategory>expression</subcategory>
        [SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible", Justification = "API has already been published and should not be changed.")]
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

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the type of decrement being performed.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1721:PropertyNamesShouldNotMatchGetMethods", Justification = "API has already been published and should not be changed.")]
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

        #endregion
    }
}