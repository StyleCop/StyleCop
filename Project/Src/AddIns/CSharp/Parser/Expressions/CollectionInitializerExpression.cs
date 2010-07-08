//-----------------------------------------------------------------------
// <copyright file="CollectionInitializerExpression.cs" company="Microsoft">
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

    /// <summary>
    /// An expression representing a collection initializer.
    /// </summary>
    /// <subcategory>expression</subcategory>
    public sealed class CollectionInitializerExpression : Expression
    {
        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the CollectionInitializerExpression class.
        /// </summary>
        /// <param name="proxy">Proxy object for the expression.</param>
        /// <param name="initializers">The list of variable initializers within the 
        /// array initializer expression.</param>
        internal CollectionInitializerExpression(CodeUnitProxy proxy, IEnumerable<Expression> initializers)
            : base(proxy, ExpressionType.CollectionInitializer)
        {
            Param.AssertNotNull(proxy, "proxy");
            Param.AssertNotNull(initializers, "initializers");
        }

        #endregion Internal Constructors

        #region Public Method

        /// <summary>
        /// Gets the list of initializers within the expression.
        /// </summary>
        /// <returns>Returns the initializer expressions.</returns>
        public ICollection<Expression> FindInitializers()
        {
            return this.FindChildExpressions();
        }

        #endregion Public Method
    }
}
