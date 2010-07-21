//-----------------------------------------------------------------------
// <copyright file="ArrayInitializerExpression.cs" company="Microsoft">
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

    /// <summary>
    /// An expression initializing a new array initialization.
    /// </summary>
    /// <subcategory>expression</subcategory>
    public sealed class ArrayInitializerExpression : Expression
    {
        #region Private Fields

        /// <summary>
        /// The list of variable initializers within the array initializer expression.
        /// </summary>
        private CodeUnitProperty<ICollection<Expression>> initializers;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the ArrayInitializerExpression class.
        /// </summary>
        /// <param name="proxy">Proxy object for the expression.</param>
        /// <param name="initializers">The list of variable initializers within the 
        /// array initializer expression.</param>
        internal ArrayInitializerExpression(CodeUnitProxy proxy, ICollection<Expression> initializers)
            : base(proxy, ExpressionType.ArrayInitializer)
        {
            Param.AssertNotNull(proxy, "proxy");
            Param.AssertNotNull(initializers, "initializers");

            this.initializers.Value = initializers;
            Debug.Assert(initializers.IsReadOnly, "The initializers collection should be read-only.");
        }

        #endregion Internal Constructors

        #region Public Properties

        /// <summary>
        /// Gets the list of variable initializers within the array initializer expression.
        /// </summary>
        public ICollection<Expression> Initializers
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.initializers.Initialized)
                {
                    List<Expression> expressions = new List<Expression>();
                    Expression expression = this.FindFirstChild<Expression>();
                    if (expression == null)
                    {
                        throw new SyntaxException(this.Document, this.LineNumber);
                    }

                    expressions.Add(expression);

                    while (true)
                    {
                        CommaToken comma = expression.FindNextSibling<CommaToken>();
                        if (comma == null)
                        {
                            break;
                        }

                        expression = comma.FindNextSibling<Expression>();
                        if (expression == null)
                        {
                            break;
                        }

                        expressions.Add(expression);
                    }

                    this.initializers.Value = expressions.AsReadOnly();
                }

                return this.initializers.Value;
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

            this.initializers.Reset();
        }

        #endregion Protected Override Methods
    }
}
