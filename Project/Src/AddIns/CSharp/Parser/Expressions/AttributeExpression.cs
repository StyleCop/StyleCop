//-----------------------------------------------------------------------
// <copyright file="AttributeExpression.cs" company="Microsoft">
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
    using System.Diagnostics;

    /// <summary>
    /// An expression representing an element or assembly attribute.
    /// </summary>
    /// <subcategory>expression</subcategory>
    public sealed class AttributeExpression : Expression
    {
        #region Private Fields

        /// <summary>
        /// The attribute target, if any.
        /// </summary>
        private CodeUnitProperty<LiteralExpression> target;

        /// <summary>
        /// The attribute initialization call.
        /// </summary>
        private CodeUnitProperty<Expression> initialization;
        
        /// <summary>
        /// Indicates whether the attribute is an assembly-level attribute.
        /// </summary>
        private CodeUnitProperty<bool> isAssemblyAttribute;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the AttributeExpression class.
        /// </summary>
        /// <param name="proxy">Proxy object for the expression.</param>
        /// <param name="target">The attribute target, if any.</param>
        /// <param name="initialization">The attribute initialization call.</param>
        internal AttributeExpression(CodeUnitProxy proxy, LiteralExpression target, Expression initialization)
            : base(proxy, ExpressionType.Attribute)
        {
            Param.AssertNotNull(proxy, "proxy");
            Param.Ignore(target);
            Param.AssertNotNull(initialization, "initialization");

            this.target.Value = target;
            this.initialization.Value = initialization;
        }

        #endregion Internal Constructors

        #region Public Properties

        /// <summary>
        /// Gets the attribute target.
        /// </summary>
        public LiteralExpression Target
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.target.Initialized)
                {
                    this.Initialize();
                }

                return this.target.Value;
            }
        }

        /// <summary>
        /// Gets the attribute initialization call expression.
        /// </summary>
        public Expression Initialization
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.initialization.Initialized)
                {
                    this.Initialize();
                    Debug.Assert(this.initialization.Value != null, "Failed to initialize");
                }

                return this.initialization.Value;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this is an assembly attribute.
        /// </summary>
        public bool IsAssemblyAttribute
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.isAssemblyAttribute.Initialized)
                {
                    this.isAssemblyAttribute.Value = false;
                    bool assembly = false;

                    for (Token token = this.FindFirstChild<Token>(); token != null; token = token.FindNextSibling<Token>())
                    {
                        if (!assembly)
                        {
                            if (token.Text == "assembly")
                            {
                                assembly = true;
                            }
                        }
                        else if (token.Text == ":")
                        {
                            this.isAssemblyAttribute.Value = true;
                            break;
                        }
                    }
                }

                return this.isAssemblyAttribute.Value;
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

            this.initialization.Reset();
            this.target.Reset();
            this.isAssemblyAttribute.Reset();
        }

        #endregion Protected Override Methods

        #region Private Methods

        /// <summary>
        /// Initializes the contents of the expression.
        /// </summary>
        private void Initialize()
        {
            this.target.Value = null;

            Expression firstExpression = this.FindFirstChild<Expression>();
            if (firstExpression == null)
            {
                throw new SyntaxException(this.Document, this.LineNumber);
            }

            if (firstExpression.ExpressionType == ExpressionType.Literal)
            {
                AttributeColonToken colon = firstExpression.FindNextSibling<AttributeColonToken>();
                if (colon != null)
                {
                    this.target.Value = (LiteralExpression)firstExpression;
                }
            }

            if (this.target.Value == null)
            {
                this.initialization.Value = firstExpression;
            }
            else
            {
                this.initialization.Value = firstExpression.FindNextSibling<Expression>();
                if (this.initialization.Value == null)
                {
                    throw new SyntaxException(this.Document, this.LineNumber);
                }
            }
        }

        #endregion Private Methods
    }
}
