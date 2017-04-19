// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IsExpression.cs" company="https://github.com/StyleCop">
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
//   An expression representing an is-operation.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// An expression representing an is-operation.
    /// </summary>
    /// <subcategory>expression</subcategory>
    public sealed class IsExpression : Expression
    {
        #region Fields

        /// <summary>
        /// The left hand side of the IS expression.
        /// </summary>
        private readonly Expression leftHandSideExpression;

        /// <summary>
        /// The right hand side of the expression.
        /// </summary>
        private readonly Expression rightHandSideExpression;

        /// <summary>
        /// The right hand side of the expression, which is usually a type being compare with.
        /// In the case of pattern match, this will be null.
        /// </summary>
        private readonly TypeToken type;

        /// <summary>
        /// The variable declared as part of pattern match of the expression, if available.
        /// </summary>
        private readonly Expression matchVariable;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the IsExpression class.
        /// </summary>
        /// <param name="tokens">
        /// The list of tokens that form the expression.
        /// </param>
        /// <param name="leftSideExpression">
        /// The left hand side of the expression.
        /// </param>
        /// <param name="rightSideExpression">
        /// The right hand side of the expression.
        /// </param>
        /// <param name="matchVariable">
        /// The variable declared as part of pattern match of the expression.
        /// </param>
        internal IsExpression(CsTokenList tokens, Expression leftSideExpression, Expression rightSideExpression, Expression matchVariable)
            : base(ExpressionType.Is, tokens)
        {
            Param.AssertNotNull(tokens, "tokens");
            Param.AssertNotNull(leftSideExpression, "leftSideExpression");
            Param.AssertNotNull(rightSideExpression, "rightSideExpression");
            Param.Ignore(matchVariable);

            this.leftHandSideExpression = leftSideExpression;
            this.rightHandSideExpression = rightSideExpression;
            this.matchVariable = matchVariable;

            // Extract the type being compared to, if possible.
            LiteralExpression le = this.rightHandSideExpression as LiteralExpression; 
            if (le != null)
            {
                this.type = CodeParser.TryExtractTypeTokenFromLiteralExpression(le);                
            }

            this.AddExpression(this.leftHandSideExpression);
            this.AddExpression(this.rightHandSideExpression);

            if (this.matchVariable != null)
            {
                this.AddExpression(this.matchVariable);
            }
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the left hand side of the expression.
        /// </summary>
        public Expression Value => this.leftHandSideExpression;

        /// <summary>
        /// Gets the right hand side of the expression.
        /// </summary>
        public Expression RightHandSideExpression => this.rightHandSideExpression;

        /// <summary>
        /// Gets the TypeToken of the right hand side expression, if available.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1721:PropertyNamesShouldNotMatchGetMethods", Justification = "API has already been published and should not be changed.")]
        public TypeToken Type => this.type;

        /// <summary>
        /// Gets the variable declared as part of pattern match of the expression, if available.
        /// </summary>
        public Expression MatchVariable => this.matchVariable;

        #endregion
    }
}