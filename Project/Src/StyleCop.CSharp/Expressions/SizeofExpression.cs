// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SizeofExpression.cs" company="https://github.com/StyleCop">
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
//   An expression representing a sizeof operation.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// An expression representing a sizeof operation.
    /// </summary>
    /// <subcategory>expression</subcategory>
    public sealed class SizeofExpression : Expression
    {
        #region Fields

        /// <summary>
        /// The type to get the size of.
        /// </summary>
        private readonly Expression type;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the SizeofExpression class.
        /// </summary>
        /// <param name="tokens">
        /// The list of tokens that form the expression.
        /// </param>
        /// <param name="type">
        /// The type to get the size of.
        /// </param>
        internal SizeofExpression(CsTokenList tokens, Expression type)
            : base(ExpressionType.Sizeof, tokens)
        {
            Param.AssertNotNull(tokens, "tokens");
            Param.AssertNotNull(type, "type");

            this.type = type;
            this.AddExpression(type);
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the type to get the size of.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1721:PropertyNamesShouldNotMatchGetMethods", Justification = "API has already been published and should not be changed.")]
        public Expression Type
        {
            get
            {
                return this.type;
            }
        }

        #endregion
    }
}