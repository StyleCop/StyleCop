// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NewExpression.cs" company="https://github.com/StyleCop">
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
//   An expression representing a new allocation operation.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    /// <summary>
    /// An expression representing a new allocation operation.
    /// </summary>
    /// <subcategory>expression</subcategory>
    public sealed class NewExpression : Expression
    {
        #region Fields

        /// <summary>
        /// The optional initializer expression.
        /// </summary>
        private readonly Expression initializerExpression;

        /// <summary>
        /// The type creation expression.
        /// </summary>
        private readonly Expression typeCreationExpression;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the NewExpression class.
        /// </summary>
        /// <param name="tokens">
        /// The list of tokens that form the expression.
        /// </param>
        /// <param name="typeCreationExpression">
        /// The type creation expression, or null
        /// for an anonymous type.
        /// </param>
        /// <param name="initializerExpression">
        /// The optional initializer expression.
        /// </param>
        internal NewExpression(CsTokenList tokens, Expression typeCreationExpression, Expression initializerExpression)
            : base(ExpressionType.New, tokens)
        {
            Param.AssertNotNull(tokens, "tokens");

            Param.Assert(
                typeCreationExpression == null || typeCreationExpression.ExpressionType == ExpressionType.Literal
                || typeCreationExpression.ExpressionType == ExpressionType.MemberAccess || typeCreationExpression.ExpressionType == ExpressionType.MethodInvocation, 
                "typeCreationExpression", 
                "The type creation expression must be a valid expression type.");

            Param.Assert(
                initializerExpression == null || initializerExpression.ExpressionType == ExpressionType.ObjectInitializer
                || initializerExpression.ExpressionType == ExpressionType.CollectionInitializer, 
                "initializerExpression", 
                "The initializer expression must be null or a valid initializer expression type.");

            this.typeCreationExpression = typeCreationExpression;
            this.initializerExpression = initializerExpression;

            if (typeCreationExpression != null)
            {
                this.AddExpression(typeCreationExpression);
            }

            if (initializerExpression != null)
            {
                this.AddExpression(initializerExpression);
            }
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the optional initializer expression.
        /// </summary>
        public Expression InitializerExpression
        {
            get
            {
                return this.initializerExpression;
            }
        }

        /// <summary>
        /// Gets the type creation expression.
        /// </summary>
        public Expression TypeCreationExpression
        {
            get
            {
                return this.typeCreationExpression;
            }
        }

        #endregion
    }
}