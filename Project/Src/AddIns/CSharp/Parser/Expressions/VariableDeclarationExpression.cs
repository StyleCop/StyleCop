//-----------------------------------------------------------------------
// <copyright file="VariableDeclarationExpression.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.
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

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the VariableDeclarationExpression class.
        /// </summary>
        /// <param name="proxy">Proxy object for the expression.</param>
        /// <param name="type">The type of the variable or variables being declared.</param>
        internal VariableDeclarationExpression(CodeUnitProxy proxy, LiteralExpression type)
            : base(proxy, ExpressionType.VariableDeclaration)
        {
            Param.AssertNotNull(proxy, "proxy");
            Param.AssertNotNull(type, "type");

            this.type = CodeParser.ExtractTypeTokenFromLiteralExpression(type);
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
        public IEnumerable<VariableDeclaratorExpression> Declarators
        {
            get
            {
                return this.GetChildren<VariableDeclaratorExpression>();
            }
        }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Gets the variables defined within this expression.
        /// </summary>
        /// <returns>Returns the collection of variables.</returns>
        public IList<IVariable> GetVariables()
        {
            List<IVariable> variables = new List<IVariable>();
            for (VariableDeclaratorExpression declarator = this.FindFirstChild<VariableDeclaratorExpression>(); declarator != null; declarator = declarator.FindNextSibling<VariableDeclaratorExpression>())
            {
                variables.Add(declarator);
            }

            return variables.AsReadOnly();
        }

        #endregion Public Methods
    }
}
