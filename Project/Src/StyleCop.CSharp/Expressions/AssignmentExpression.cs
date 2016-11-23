// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AssignmentExpression.cs" company="https://github.com/StyleCop">
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
//   An expression representing an assignment operation.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// An expression representing an assignment operation.
    /// </summary>
    /// <subcategory>expression</subcategory>
    public sealed class AssignmentExpression : Expression
    {
        #region Fields

        /// <summary>
        /// The left hand size of the expression.
        /// </summary>
        private readonly Expression leftHandSide;

        /// <summary>
        /// The type of operator being performed.
        /// </summary>
        private readonly Operator operatorType;

        /// <summary>
        /// The right hand size of the expression.
        /// </summary>
        private readonly Expression rightHandSide;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the AssignmentExpression class.
        /// </summary>
        /// <param name="tokens">
        /// The list of tokens that form the expression.
        /// </param>
        /// <param name="operatorType">
        /// The type of operation being performed.
        /// </param>
        /// <param name="leftHandSide">
        /// The left hand side of the expression.
        /// </param>
        /// <param name="rightHandSide">
        /// The right hand side of the expression.
        /// </param>
        internal AssignmentExpression(CsTokenList tokens, Operator operatorType, Expression leftHandSide, Expression rightHandSide)
            : base(ExpressionType.Assignment, tokens)
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
        /// The various assignment operator types.
        /// </summary>
        /// <subcategory>expression</subcategory>
        [SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible", Justification = "Leave nested to avoid changing external interface.")]
        [SuppressMessage("Microsoft.Naming", "CA1716:IdentifiersShouldNotMatchKeywords", Justification = "Describes a C# operator type")]
        public enum Operator
        {
            /// <summary>
            /// The = operator.
            /// </summary>
            Equals, 

            /// <summary>
            /// The += operator.
            /// </summary>
            PlusEquals, 

            /// <summary>
            /// The -= operator.
            /// </summary>
            MinusEquals, 

            /// <summary>
            /// The *= operator.
            /// </summary>
            MultiplicationEquals, 

            /// <summary>
            /// The /= operator.
            /// </summary>
            DivisionEquals, 

            /// <summary>
            /// The %= operator.
            /// </summary>
            ModEquals, 

            /// <summary>
            /// The |= operator.
            /// </summary>
            OrEquals, 

            /// <summary>
            /// The and-equals operator.
            /// </summary>
            AndEquals, 

            /// <summary>
            /// The exclusive-or operator.
            /// </summary>
            XorEquals, 

            /// <summary>
            /// The left-shift equals operator.
            /// </summary>
            LeftShiftEquals, 

            /// <summary>
            /// The right-shift equals operator.
            /// </summary>
            RightShiftEquals
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the left hand side of the expression.
        /// </summary>
        public Expression LeftHandSide
        {
            get
            {
                return this.leftHandSide;
            }
        }

        /// <summary>
        /// Gets the type of assignment being performed.
        /// </summary>
        public Operator OperatorType
        {
            get
            {
                return this.operatorType;
            }
        }

        /// <summary>
        /// Gets the right hand side of the expression.
        /// </summary>
        public Expression RightHandSide
        {
            get
            {
                return this.rightHandSide;
            }
        }

        #endregion
    }
}