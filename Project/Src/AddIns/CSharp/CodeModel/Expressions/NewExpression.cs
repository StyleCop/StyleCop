//-----------------------------------------------------------------------
// <copyright file="NewExpression.cs" company="Microsoft">
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
namespace Microsoft.StyleCop.CSharp.CodeModel
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Text;

    /// <summary>
    /// An expression representing a new allocation operation.
    /// </summary>
    /// <subcategory>expression</subcategory>
    public sealed class NewExpression : Expression
    {
        #region Private Fields

        /// <summary>
        /// The type creation expression.
        /// </summary>
        private CodeUnitProperty<Expression> typeCreationExpression;

        /// <summary>
        /// The optional initializer expression.
        /// </summary>
        private CodeUnitProperty<Expression> initializerExpression;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the NewExpression class.
        /// </summary>
        /// <param name="proxy">Proxy object for the expression.</param>
        /// <param name="typeCreationExpression">The type creation expression, or null
        /// for an anonymous type.</param>
        /// <param name="initializerExpression">The optional initializer expression.</param>
        internal NewExpression(CodeUnitProxy proxy, Expression typeCreationExpression, Expression initializerExpression)
            : base(proxy, ExpressionType.New)
        {
            Param.AssertNotNull(proxy, "proxy");

            Param.Assert(
                typeCreationExpression == null ||
                typeCreationExpression.ExpressionType == ExpressionType.Literal ||
                typeCreationExpression.ExpressionType == ExpressionType.MemberAccess ||
                typeCreationExpression.ExpressionType == ExpressionType.MethodInvocation,
                "typeCreationExpression",
                "The type creation expression must be a valid expression type.");

            Param.Assert(
                initializerExpression == null ||
                initializerExpression.ExpressionType == ExpressionType.ObjectInitializer ||
                initializerExpression.ExpressionType == ExpressionType.CollectionInitializer,
                "initializerExpression",
                "The initializer expression must be null or a valid initializer expression type.");

            this.typeCreationExpression.Value = typeCreationExpression;
            this.initializerExpression.Value = initializerExpression;
        }

        #endregion Internal Constructors

        #region Public Properties

        /// <summary>
        /// Gets the type creation expression.
        /// </summary>
        public Expression TypeCreationExpression
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.typeCreationExpression.Initialized)
                {
                    this.Initialize();
                    Debug.Assert(this.typeCreationExpression.Value != null, "Failed to initialize");
                }

                return this.typeCreationExpression.Value;
            }
        }

        /// <summary>
        /// Gets the optional initializer expression.
        /// </summary>
        public Expression InitializerExpression
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.initializerExpression.Initialized)
                {
                    this.Initialize();
                    Debug.Assert(this.initializerExpression.Value != null, "Failed to initialize");
                }

                return this.initializerExpression.Value;
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

            this.typeCreationExpression.Reset();
            this.initializerExpression.Reset();
        }

        #endregion Protected Override Methods

        #region Private Methods

        /// <summary>
        /// Initializes the contents of the expression.
        /// </summary>
        private void Initialize()
        {
            Expression firstExpression = this.FindFirstChild<Expression>();
            if (firstExpression == null ||
                (firstExpression.ExpressionType != ExpressionType.Literal &&
                 firstExpression.ExpressionType != ExpressionType.MemberAccess &&
                 firstExpression.ExpressionType != ExpressionType.MethodInvocation))
            {
                throw new SyntaxException(this.Document, this.LineNumber);
            }

            this.typeCreationExpression.Value = firstExpression;

            Expression nextExpression = firstExpression.FindNextSibling<Expression>();
            if (nextExpression != null &&
                (nextExpression.ExpressionType == ExpressionType.ObjectInitializer ||
                 nextExpression.ExpressionType == ExpressionType.CollectionInitializer))
            {
                this.initializerExpression.Value = nextExpression;
            }
            else
            {
                this.initializerExpression.Value = null;
            }
        }

        #endregion Private Methods
    }
}
