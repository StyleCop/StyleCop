// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DictionaryItemInitializationExpression.cs" company="https://github.com/StyleCop">
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
//   A dictionary item initialisation expression.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace StyleCop.CSharp
{
    using System.Collections.Generic;

    /// <summary>
    /// A single variable declarator within a variable declaration expression.
    /// </summary>
    /// <subcategory>expression</subcategory>
    public sealed class DictionaryItemInitializationExpression : Expression
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the DictionaryItemInitializationExpression class.
        /// </summary>
        /// <param name="tokens">The list of tokens that form the statement.</param>
        internal DictionaryItemInitializationExpression(CsTokenList tokens)
            : base(ExpressionType.ArrayInitializer, tokens)
        {
            Param.AssertNotNull(tokens, "tokens");
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