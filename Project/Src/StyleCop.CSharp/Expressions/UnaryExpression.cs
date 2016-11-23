// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnaryExpression.cs" company="https://github.com/StyleCop">
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
//   An expression representing a unary operation.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// An expression representing a unary operation.
    /// </summary>
    /// <subcategory>expression</subcategory>
    public sealed class UnaryExpression : Expression
    {
        #region Fields

        /// <summary>
        /// The type of operation being performed.
        /// </summary>
        private readonly Operator operatorType;

        /// <summary>
        /// The expression the operator is being applied to.
        /// </summary>
        private readonly Expression value;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the UnaryExpression class.
        /// </summary>
        /// <param name="tokens">
        /// The list of tokens that form the expression.
        /// </param>
        /// <param name="operatorType">
        /// The type of operation being performed.
        /// </param>
        /// <param name="value">
        /// The value the operator is being applied to.
        /// </param>
        internal UnaryExpression(CsTokenList tokens, Operator operatorType, Expression value)
            : base(ExpressionType.Unary, tokens)
        {
            Param.AssertNotNull(tokens, "tokens");
            Param.Ignore(operatorType);
            Param.AssertNotNull(value, "value");

            this.operatorType = operatorType;
            this.value = value;

            this.AddExpression(value);
        }

        #endregion

        #region Enums

        /// <summary>
        /// The possible unary operator types.
        /// </summary>
        /// <subcategory>expression</subcategory>
        [SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible", Justification = "Leave nested to avoid changing external interface.")]
        [SuppressMessage("Microsoft.Naming", "CA1716:IdentifiersShouldNotMatchKeywords", Justification = "The enum describes a C# operator type.")]
        public enum Operator
        {
            /// <summary>
            /// The + operator.
            /// </summary>
            Positive, 

            /// <summary>
            /// The - operator.
            /// </summary>
            Negative, 

            /// <summary>
            /// The ! operator.
            /// </summary>
            Not, 

            /// <summary>
            /// The ~ operator.
            /// </summary>
            BitwiseCompliment
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the type of operation being performed.
        /// </summary>
        public Operator OperatorType
        {
            get
            {
                return this.operatorType;
            }
        }

        /// <summary>
        /// Gets the value of the expression.
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