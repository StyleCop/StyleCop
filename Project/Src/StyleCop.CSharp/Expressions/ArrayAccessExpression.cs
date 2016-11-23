// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ArrayAccessExpression.cs" company="https://github.com/StyleCop">
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
//   An expression representing an array access operation.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// An expression representing an array access operation.
    /// </summary>
    /// <subcategory>expression</subcategory>
    public sealed class ArrayAccessExpression : Expression
    {
        #region Fields

        /// <summary>
        /// The arguments passed to the method.
        /// </summary>
        private readonly IList<Argument> arguments;

        /// <summary>
        /// Represents the item being indexed.
        /// </summary>
        private readonly Expression array;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the ArrayAccessExpression class.
        /// </summary>
        /// <param name="tokens">
        /// The list of tokens that form the expression.
        /// </param>
        /// <param name="array">
        /// Represents the item being indexed.
        /// </param>
        /// <param name="arguments">
        /// The array access arguments.
        /// </param>
        internal ArrayAccessExpression(CsTokenList tokens, Expression array, IList<Argument> arguments)
            : base(ExpressionType.ArrayAccess, tokens)
        {
            Param.AssertNotNull(tokens, "tokens");
            Param.AssertNotNull(array, "array");
            Param.AssertNotNull(arguments, "arguments");

            this.array = array;
            this.arguments = arguments;
            Debug.Assert(arguments.IsReadOnly, "The arguments collection should be read-only.");

            this.AddExpression(array);

            for (int i = 0; i < arguments.Count; ++i)
            {
                this.AddExpression(arguments[i].Expression);
            }
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the array access arguments.
        /// </summary>
        public IList<Argument> Arguments
        {
            get
            {
                return this.arguments;
            }
        }

        /// <summary>
        /// Gets the item being indexed.
        /// </summary>
        public Expression Array
        {
            get
            {
                return this.array;
            }
        }

        #endregion
    }
}