//-----------------------------------------------------------------------
// <copyright file="NewExpression.cs" company="Microsoft">
//   Copyright (c) Microsoft Corporation.
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
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// An expression representing a new allocation operation.
    /// </summary>
    /// <subcategory>expression</subcategory>
    public sealed class NewExpression : Expression
    {
        #region Private Fields

        /// <summary>
        /// The type creation expression.
        /// </summary>
        private Expression typeCreationExpression;

        /// <summary>
        /// The optional initializer expression.
        /// </summary>
        private Expression initializerExpression;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the NewExpression class.
        /// </summary>
        /// <param name="tokens">The list of tokens that form the expression.</param>
        /// <param name="typeCreationExpression">The type creation expression, or null
        /// for an anonymous type.</param>
        /// <param name="initializerExpression">The optional initializer expression.</param>
        internal NewExpression(CsTokenList tokens, Expression typeCreationExpression, Expression initializerExpression)
            : base(ExpressionType.New, tokens)
        {
            Param.AssertNotNull(tokens, "tokens");

            Param.Assert(
                typeCreationExpression == null ||
                typeCreationExpression.ExpressionType == ExpressionType.Literal ||
                typeCreationExpression.ExpressionType == ExpressionType.MemberAccess ||
                typeCreationExpression.ExpressionType == ExpressionType.MethodInvocation,
                "typeCreationExpression",
                "The type creation expression must be a valid expression type.");

            Param.Assert(
                initializerExpression == null ||
                initializerExpression.ExpressionType == ExpressionType.ObjectInitializer ||
                initializerExpression.ExpressionType == ExpressionType.CollectionInitializer,
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

        #endregion Internal Constructors

        #region Public Properties

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

        #endregion Public Properties
    }
}
