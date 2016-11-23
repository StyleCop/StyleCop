// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DictionaryInitializerExpression.cs" company="https://github.com/StyleCop">
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
//   An expression representing a collection initializer.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    using System.Collections.Generic;

    /// <summary>
    /// An expression representing a dictionary initializer introduced in C# 6.
    /// </summary>
    /// <subcategory>expression</subcategory>
    public sealed class DictionaryInitializerExpression : Expression
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the DictionaryInitializerExpression class.
        /// </summary>
        /// <param name="tokens">
        /// The list of tokens that form the expression.
        /// </param>
        /// <param name="initializers">
        /// The list of variable initializers within the 
        /// dictionary initializer expression.
        /// </param>
        internal DictionaryInitializerExpression(CsTokenList tokens, IEnumerable<Expression> initializers)
            : base(ExpressionType.CollectionInitializer, tokens)
        {
            Param.AssertNotNull(tokens, "tokens");
            Param.AssertNotNull(initializers, "initializers");

            this.AddExpressions(initializers);
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the list of initializers within the expression.
        /// </summary>
        public ICollection<Expression> Initializers
        {
            get
            {
                return this.ChildExpressions;
            }
        }

        #endregion
    }
}