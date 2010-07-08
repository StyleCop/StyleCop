//-----------------------------------------------------------------------
// <copyright file="ArrayAccessExpression.cs" company="Microsoft">
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
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// An expression representing an array access operation.
    /// </summary>
    /// <subcategory>expression</subcategory>
    public sealed class ArrayAccessExpression : Expression
    {
        #region Private Fields

        /// <summary>
        /// Represents the item being indexed.
        /// </summary>
        private Expression array;

        /// <summary>
        /// The array access arguments.
        /// </summary>
        private IList<Argument> arguments;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the ArrayAccessExpression class.
        /// </summary>
        /// <param name="proxy">Proxy object for the expression.</param>
        /// <param name="array">Represents the item being indexed.</param>
        internal ArrayAccessExpression(CodeUnitProxy proxy, Expression array)
            : base(proxy, ExpressionType.ArrayAccess)
        {
            Param.AssertNotNull(proxy, "proxy");
            Param.AssertNotNull(array, "array");

            this.array = array;
        }

        #endregion Internal Constructors

        #region Public Properties

        /// <summary>
        /// Gets the item being indexed.
        /// </summary>
        public Expression Array
        {
            get
            {
                return this.array;
            }
        }

        /// <summary>
        /// Gets the array access arguments.
        /// </summary>
        public IList<Argument> Arguments
        {
            get
            {
                if (this.arguments == null)
                {
                    this.arguments = this.CollectArguments();
                }

                return this.arguments;
            }
        }

        #endregion Public Properties
    }
}
