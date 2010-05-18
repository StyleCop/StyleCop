//-----------------------------------------------------------------------
// <copyright file="ObjectInitializerExpression.cs" company="Microsoft">
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
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// An expression representing an object initializer.
    /// </summary>
    /// <subcategory>expression</subcategory>
    public sealed class ObjectInitializerExpression : Expression
    {
        #region Private Fields

        /// <summary>
        /// The collection of initializers within the expression.
        /// </summary>
        private ICollection<AssignmentExpression> initializers;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the ObjectInitializerExpression class.
        /// </summary>
        /// <param name="tokens">The list of tokens that form the expression.</param>
        /// <param name="initializers">The list of variable initializers within the 
        /// array initializer expression.</param>
        internal ObjectInitializerExpression(CsTokenList tokens, ICollection<AssignmentExpression> initializers)
            : base(ExpressionType.ObjectInitializer, tokens)
        {
            Param.AssertNotNull(tokens, "tokens");
            Param.AssertNotNull(initializers, "initializers");

            this.initializers = initializers;
            Debug.Assert(initializers.IsReadOnly, "The collection of initializers should be read-only.");

            foreach (AssignmentExpression initializer in initializers)
            {
                this.AddExpression(initializer);
            }
        }

        #endregion Internal Constructors

        #region Public Properties

        /// <summary>
        /// Gets the list of initializers within the expression.
        /// </summary>
        public ICollection<AssignmentExpression> Initializers
        {
            get
            {
                return this.initializers;
            }
        }

        #endregion Public Properties
    }
}
