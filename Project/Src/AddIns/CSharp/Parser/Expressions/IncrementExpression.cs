//-----------------------------------------------------------------------
// <copyright file="IncrementExpression.cs">
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
//-----------------------------------------------------------------------
namespace StyleCop.CSharp
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// An expression representing an increment operation.
    /// </summary>
    /// <subcategory>expression</subcategory>
    public sealed class IncrementExpression : Expression
    {
        #region Private Fields

        /// <summary>
        /// The type of increment being performed.
        /// </summary>
        private IncrementType incrementType;

        /// <summary>
        /// The value being incremented.
        /// </summary>
        private Expression value;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the IncrementExpression class.
        /// </summary>
        /// <param name="tokens">The list of tokens that form the expression.</param>
        /// <param name="value">The value being incremented.</param>
        /// <param name="incrementType">The type of increment being performed.</param>
        internal IncrementExpression(CsTokenList tokens, Expression value, IncrementType incrementType)
            : base(ExpressionType.Increment, tokens)
        {
            Param.AssertNotNull(tokens, "tokens");
            Param.AssertNotNull(value, "value");
            Param.Ignore(incrementType);

            this.value = value;
            this.incrementType = incrementType;

            this.AddExpression(value);
        }

        #endregion Internal Constructors

        #region Public Enums

        /// <summary>
        /// The various types of increment operations.
        /// </summary>
        /// <subcategory>expression</subcategory>
        [SuppressMessage(
            "Microsoft.Design", 
            "CA1034:NestedTypesShouldNotBeVisible",
            Justification = "API has already been published and should not be changed.")]
        public enum IncrementType
        {
            /// <summary>
            /// A prefix increment: ++x.
            /// </summary>
            Prefix,

            /// <summary>
            /// A postfix increment: x++.
            /// </summary>
            Postfix
        }

        #endregion Public Enums

        #region Public Properties

        /// <summary>
        /// Gets the type of increment being performed.
        /// </summary>
        [SuppressMessage(
            "Microsoft.Naming", 
            "CA1721:PropertyNamesShouldNotMatchGetMethods",
            Justification = "API has already been published and should not be changed.")]
        public IncrementType Type
        {
            get
            {
                return this.incrementType;
            }
        }

        /// <summary>
        /// Gets the value being incremented.
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
