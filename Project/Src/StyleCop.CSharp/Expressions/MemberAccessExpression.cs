// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MemberAccessExpression.cs" company="https://github.com/StyleCop">
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
//   An expression representing a member access operation.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// An expression representing a member access operation.
    /// </summary>
    /// <subcategory>expression</subcategory>
    public sealed class MemberAccessExpression : Expression
    {
        #region Fields

        /// <summary>
        /// The expression on the left-hand side of the operator.
        /// </summary>
        private readonly Expression leftHandSide;

        /// <summary>
        /// The type of operation being performed.
        /// </summary>
        private readonly Operator operatorType;

        /// <summary>
        /// The member expression on the right hand side of the operator.
        /// </summary>
        private readonly LiteralExpression rightHandSide;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the MemberAccessExpression class.
        /// </summary>
        /// <param name="tokens">
        /// The list of tokens that form the expression.
        /// </param>
        /// <param name="operatorType">
        /// The type of operation being performed.
        /// </param>
        /// <param name="leftHandSide">
        /// The left side of the operation.
        /// </param>
        /// <param name="rightHandSide">
        /// The member being accessed.
        /// </param>
        internal MemberAccessExpression(CsTokenList tokens, Operator operatorType, Expression leftHandSide, LiteralExpression rightHandSide)
            : base(ExpressionType.MemberAccess, tokens)
        {
            Param.AssertNotNull(tokens, "tokens");
            Param.Ignore(operatorType);
            Param.AssertNotNull(leftHandSide, "leftHandSide");
            Param.AssertNotNull(rightHandSide, "rightHandSide");

            this.operatorType = operatorType;
            this.leftHandSide = leftHandSide;
            this.rightHandSide = rightHandSide;

            this.AddExpression(leftHandSide);
            this.AddExpression(rightHandSide);
        }

        #endregion

        #region Enums

        /// <summary>
        /// The various member access operation types.
        /// </summary>
        /// <subcategory>expression</subcategory>
        [SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible", Justification = "Leave nested to avoid changing external interface.")]
        [SuppressMessage("Microsoft.Naming", "CA1716:IdentifiersShouldNotMatchKeywords", Justification = "Describes a C# operator type")]
        public enum Operator
        {
            /// <summary>
            /// The -> operator.
            /// </summary>
            Pointer, 

            /// <summary>
            /// The . operator.
            /// </summary>
            Dot, 

            /// <summary>
            /// The :: operator.
            /// </summary>
            QualifiedAlias
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the expression on the left-hand side of the operator.
        /// </summary>
        public Expression LeftHandSide
        {
            get
            {
                return this.leftHandSide;
            }
        }

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
        /// Gets the member expression on the right-hand side of the operator.
        /// </summary>
        public LiteralExpression RightHandSide
        {
            get
            {
                return this.rightHandSide;
            }
        }

        #endregion
    }
}