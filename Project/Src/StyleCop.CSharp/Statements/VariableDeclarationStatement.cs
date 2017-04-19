// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VariableDeclarationStatement.cs" company="https://github.com/StyleCop">
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
//   A statement declaring a new variable.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// A statement declaring a new variable.
    /// </summary>
    /// <subcategory>statement</subcategory>
    public sealed class VariableDeclarationStatement : Statement
    {
        #region Fields

        /// <summary>
        /// Indicates whether the item is constant.
        /// </summary>
        private readonly bool constant;

        /// <summary>
        /// Indicates whether the item is a ref.
        /// </summary>
        private readonly bool isRef;

        /// <summary>
        /// The inner expression.
        /// </summary>
        private readonly VariableDeclarationExpression expression;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the VariableDeclarationStatement class.
        /// </summary>
        /// <param name="tokens">
        /// The list of tokens that form the statement.
        /// </param>
        /// <param name="constant">
        /// Indicates whether the item is constant.
        /// </param>
        /// <param name="isRef">
        /// Indicates whether the item is a ref.
        /// </param>
        /// <param name="expression">
        /// The inner expression.
        /// </param>
        internal VariableDeclarationStatement(CsTokenList tokens, bool constant, bool isRef, VariableDeclarationExpression expression)
            : base(StatementType.VariableDeclaration, tokens)
        {
            Param.AssertNotNull(tokens, "tokens");
            Param.Ignore(constant);
            Param.Ignore(isRef);
            Param.AssertNotNull(expression, "expression");

            this.constant = constant;
            this.isRef = isRef;
            this.expression = expression;

            this.AddExpression(expression);
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets a value indicating whether the item is constant.
        /// </summary>
        public bool Constant => this.constant;

        /// <summary>
        /// Gets a value indicating whether the item is a ref.
        /// </summary>
        public bool IsRef => this.isRef;

        /// <summary>
        /// Gets the list of declarators for the expression.
        /// </summary>
        public ICollection<VariableDeclaratorExpression> Declarators => this.expression.Declarators;

        /// <summary>
        /// Gets the inner expression for this statement.
        /// </summary>
        public VariableDeclarationExpression InnerExpression => this.expression;

        /// <summary>
        /// Gets the type of the variable.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1721:PropertyNamesShouldNotMatchGetMethods", Justification = "API has already been published and should not be changed.")]
        public TypeToken Type => this.expression.Type;

        #endregion
    }
}