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
namespace Microsoft.StyleCop.CSharp.CodeModel
{
    using System;
    using System.Diagnostics;

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
        private CodeUnitProperty<LiteralExpression> identifier;

        /// <summary>
        /// The initialization expression for the variable.
        /// </summary>
        private CodeUnitProperty<Expression> initializer;

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

            this.identifier.Value = identifier;
            this.initializer.Value = initializer;
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
                this.ValidateEditVersion();

                if (!this.identifier.Initialized)
                {
                    this.Initialize();
                    Debug.Assert(this.identifier.Value != null, "Failed to initialize");
                }

                return this.identifier.Value;
            }
        }

        /// <summary>
        /// Gets the initialization statement for the variable.
        /// </summary>
        public Expression Initializer
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.initializer.Initialized)
                {
                    this.Initialize();
                }

                return this.initializer.Value;
            }
        }

        #endregion Public Properties

        #region Protected Override Methods

        /// <summary>
        /// Resets the contents of the class.
        /// </summary>
        protected override void Reset()
        {
            base.Reset();

            this.identifier.Reset();
            this.initializer.Reset();
        }

        #endregion Protected Override Methods

        #region Private Methods

        /// <summary>
        /// Initializes the contents of the expression.
        /// </summary>
        private void Initialize()
        {
            this.identifier.Value = this.FindFirstChild<LiteralExpression>();
            if (this.identifier.Value == null)
            {
                throw new SyntaxException(this.Document, this.LineNumber);
            }

            EqualsOperator equals = this.identifier.Value.FindNextSibling<EqualsOperator>();
            if (equals == null)
            {
                this.initializer.Value = null;
            }
            else
            {
                this.initializer.Value = equals.FindNextSibling<Expression>();
                if (this.initializer.Value == null)
                {
                    throw new SyntaxException(this.Document, this.LineNumber);
                }
            }
        }

        #endregion Private Methods
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
                return this.identifier.Value == null ? null : this.identifier.Value.Text;
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
