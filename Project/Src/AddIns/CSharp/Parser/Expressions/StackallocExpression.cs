//-----------------------------------------------------------------------
// <copyright file="StackallocExpression.cs" company="Microsoft">
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
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// An expression representing a stackalloc operation.
    /// </summary>
    /// <subcategory>expression</subcategory>
    public sealed class StackallocExpression : Expression
    {
        #region Private Fields

        /// <summary>
        /// The type of the array.
        /// </summary>
        private ArrayAccessExpression type;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the StackallocExpression class.
        /// </summary>
        /// <param name="tokens">The list of tokens that form the expression.</param>
        /// <param name="type">The array type.</param>
        internal StackallocExpression(CsTokenList tokens, ArrayAccessExpression type)
            : base(ExpressionType.Stackalloc, tokens)
        {
            Param.AssertNotNull(tokens, "tokens");
            Param.AssertNotNull(type, "type");

            this.type = type;
            this.AddExpression(type);
        }

        #endregion Internal Constructors

        #region Public Properties

        /// <summary>
        /// Gets the array type.
        /// </summary>
        [SuppressMessage(
            "Microsoft.Naming", 
            "CA1721:PropertyNamesShouldNotMatchGetMethods",
            Justification = "API has already been published and should not be changed.")]
        public ArrayAccessExpression Type
        {
            get
            {
                return this.type;
            }
        }

        #endregion Public Properties
    }
}
