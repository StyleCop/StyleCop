// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TupleExpression.cs" company="https://github.com/StyleCop">
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
//   An expression that represents a Tuple literal.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    using System.Collections.Generic;

    /// <summary>
    /// An expression that represents a Tuple literal.
    /// </summary>
    /// <subcategory>expression</subcategory>
    public class TupleExpression : Expression
    {
        #region Fields

        /// <summary>
        /// The arguments that form the Tuple expression.
        /// </summary>
        private readonly IList<Argument> arguments;

        /// <summary>
        /// The variable declarations that form the Tuple type.
        /// </summary>
        private readonly IList<VariableDeclarationExpression> variableDeclarations;

        #endregion
        
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the TupleExpression class.
        /// </summary>
        /// <param name="tokens">
        /// The list of tokens that form the expression.
        /// </param>
        /// <param name="arguments">
        /// The arguments that form the Tuple literal.
        /// </param>
        internal TupleExpression(CsTokenList tokens, IList<Argument> arguments)
            : base(ExpressionType.Tuple, tokens)
        {
            Param.AssertNotNull(arguments, nameof(arguments));
            Param.AssertGreaterThanZero(arguments.Count, nameof(arguments));

            this.arguments = arguments;

            for (int i = 0; i < arguments.Count; ++i)
            {
                this.AddExpression(arguments[i].Expression);
            }
        }

        /// <summary>
        /// Initializes a new instance of the TupleExpression class.
        /// </summary>
        /// <param name="tokens">
        /// The list of tokens that form the expression.
        /// </param>
        /// <param name="variableDeclarations">
        /// The variable declaration in the Tuple type.
        /// </param>
        internal TupleExpression(CsTokenList tokens, IList<VariableDeclarationExpression> variableDeclarations)
            : base(ExpressionType.Tuple, tokens)
        {
            Param.AssertNotNull(variableDeclarations, nameof(variableDeclarations));
            Param.AssertGreaterThanZero(variableDeclarations.Count, nameof(variableDeclarations));

            this.variableDeclarations = variableDeclarations;

            for (int i = 0; i < variableDeclarations.Count; ++i)
            {
                this.AddExpression(variableDeclarations[i]);
            }
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the list of arguments that form the Tuple literal.
        /// </summary>
        public IList<Argument> Arguments => this.arguments;

        /// <summary>
        /// Gets the list of variable declarations that form the Tuple Type.
        /// </summary>
        public IList<VariableDeclarationExpression> VariableDeclarations => this.variableDeclarations;

        #endregion
    }
}
