//-----------------------------------------------------------------------
// <copyright file="VariableDeclarationExpression.cs">
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
//-----------------------------------------------------------------------
namespace StyleCop.CSharp
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// An expression declaring a new variable.
    /// </summary>
    /// <subcategory>expression</subcategory>
    public sealed class VariableDeclarationExpression : Expression
    {
        #region Private Fields

        /// <summary>
        /// The type of the variable being declared.
        /// </summary>
        private TypeToken type;

        /// <summary>
        /// The list of declarators.
        /// </summary>
        private ICollection<VariableDeclaratorExpression> declarators;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the VariableDeclarationExpression class.
        /// </summary>
        /// <param name="tokens">The list of tokens that form the statement.</param>
        /// <param name="type">The type of the variable or variables being declared.</param>
        /// <param name="declarators">The list of declarators in the expression.</param>
        internal VariableDeclarationExpression(
            CsTokenList tokens, 
            LiteralExpression type, 
            ICollection<VariableDeclaratorExpression> declarators)
            : base(ExpressionType.VariableDeclaration, tokens)
        {
            Param.AssertNotNull(tokens, "tokens");
            Param.AssertNotNull(type, "type");
            Param.AssertNotNull(declarators, "declarators");

            this.declarators = declarators;

            Debug.Assert(declarators.IsReadOnly, "The declarators collection should be read-only.");

            this.AddExpression(type);
            this.type = CodeParser.ExtractTypeTokenFromLiteralExpression(type);

            foreach (VariableDeclaratorExpression expression in declarators)
            {
                this.AddExpression(expression);
                expression.ParentVariable = this;
            }
        }

        #endregion Internal Constructors

        #region Public Properties

        /// <summary>
        /// Gets the type of the variable.
        /// </summary>
        [SuppressMessage(
            "Microsoft.Naming", 
            "CA1721:PropertyNamesShouldNotMatchGetMethods",
            Justification = "API has already been published and should not be changed.")]
        public TypeToken Type
        {
            get
            {
                return this.type;
            }
        }

        /// <summary>
        /// Gets the list of declarators for the expression.
        /// </summary>
        public ICollection<VariableDeclaratorExpression> Declarators
        {
            get
            {
                return this.declarators;
            }
        }

        #endregion Public Properties
    }
}