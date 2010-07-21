//-----------------------------------------------------------------------
// <copyright file="VariableDeclaratorExpression.cs" company="Microsoft">
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
    using System;

    /// <summary>
    /// A single variable declarator within a variable declaration expression.
    /// </summary>
    /// <subcategory>expression</subcategory>
    public sealed partial class VariableDeclaratorExpression : Expression
    {
        #region Private Fields

        /// <summary>
        /// The identifier of the variable.
        /// </summary>
        private LiteralExpression identifier;

        /// <summary>
        /// The initialization expression for the variable.
        /// </summary>
        private Expression initializer;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the VariableDeclaratorExpression class.
        /// </summary>
        /// <param name="proxy">Proxy object for the expression.</param>
        /// <param name="identifier">The identifier name of the variable.</param>
        /// <param name="initializer">The initialization expression for the variable.</param>
        internal VariableDeclaratorExpression(
            CodeUnitProxy proxy,
            LiteralExpression identifier, 
            Expression initializer)
            : base(proxy, ExpressionType.VariableDeclarator)
        {
            Param.AssertNotNull(proxy, "proxy");
            Param.AssertNotNull(identifier, "identifier");
            Param.Ignore(initializer);

            this.identifier = identifier;
            this.initializer = initializer;
        }

        #endregion Internal Constructors

        #region Public Properties

        /// <summary>
        /// Gets the identifier name of the variable.
        /// </summary>
        public LiteralExpression Identifier
        {
            get
            {
                return this.identifier;
            }
        }

        /// <summary>
        /// Gets the initialization statement for the variable.
        /// </summary>
        public Expression Initializer
        {
            get
            {
                return this.initializer;
            }
        }

        #endregion Public Properties
    }

    /// <content>
    /// Implements the IVariable interface.
    /// </content>
    public partial class VariableDeclaratorExpression : IVariable
    {
        #region Public Properties 

        /// <summary>
        /// Gets the variable name.
        /// </summary>
        public string VariableName
        {
            get
            {
                return this.identifier == null ? null : this.identifier.Text;
            }
        }

        /// <summary>
        /// Gets the variable type.
        /// </summary>
        public TypeToken VariableType
        {
            get
            {
                VariableDeclarationExpression declaration = this.Parent as VariableDeclarationExpression;
                if (declaration != null)
                {
                    return declaration.Type;
                }

                return null;
            }
        }

        /// <summary>
        /// Gets the modifiers applied to this variable.
        /// </summary>
        public VariableModifiers VariableModifiers
        {
            get
            {
                VariableModifiers modifiers = VariableModifiers.None;

                VariableDeclarationStatement parent = this.FindParent<Statement>() as VariableDeclarationStatement;
                if (parent != null && parent.Constant)
                {
                    modifiers = VariableModifiers.Const;
                }

                return modifiers;
            }
        }

        #endregion Public Methods
    }
}
