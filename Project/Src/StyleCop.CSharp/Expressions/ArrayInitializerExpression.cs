// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ArrayInitializerExpression.cs" company="https://github.com/StyleCop">
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
//   An expression initializing a new array initialization.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// An expression initializing a new array initialization.
    /// </summary>
    /// <subcategory>expression</subcategory>
    public sealed class ArrayInitializerExpression : Expression
    {
        #region Fields

        /// <summary>
        /// The list of variable initializers within the array initializer expression.
        /// </summary>
        private readonly ICollection<Expression> initializers;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the ArrayInitializerExpression class.
        /// </summary>
        /// <param name="tokens">
        /// The list of tokens that form the expression.
        /// </param>
        /// <param name="initializers">
        /// The list of variable initializers within the 
        /// array initializer expression.
        /// </param>
        internal ArrayInitializerExpression(CsTokenList tokens, ICollection<Expression> initializers)
            : base(ExpressionType.ArrayInitializer, tokens)
        {
            Param.AssertNotNull(tokens, "tokens");
            Param.AssertNotNull(initializers, "initializers");

            this.initializers = initializers;
            Debug.Assert(initializers.IsReadOnly, "The initializers collection should be read-only.");

            this.AddExpressions(initializers);
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the list of variable initializers within the array initializer expression.
        /// </summary>
        public ICollection<Expression> Initializers
        {
            get
            {
                return this.initializers;
            }
        }

        #endregion
    }
}