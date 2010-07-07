//-----------------------------------------------------------------------
// <copyright file="AnonymousMethodExpression.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
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
    using System.Text;

    /// <summary>
    /// An expression representing an anonymous method.
    /// </summary>
    /// <subcategory>expression</subcategory>
    public sealed class AnonymousMethodExpression : ExpressionWithParameters
    {
        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the AnonymousMethodExpression class.
        /// </summary>
        /// <param name="proxy">Proxy object for the expression.</param>
        internal AnonymousMethodExpression(CodeUnitProxy proxy)
            : base(proxy, ExpressionType.AnonymousMethod)
        {
            Param.Ignore(proxy);
        }

        #endregion Internal Constructors
    }
}
