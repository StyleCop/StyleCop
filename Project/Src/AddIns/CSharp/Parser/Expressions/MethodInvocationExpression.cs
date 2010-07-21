//-----------------------------------------------------------------------
// <copyright file="MethodInvocationExpression.cs" company="Microsoft">
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
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// An expression representing a method invocation operation.
    /// </summary>
    /// <subcategory>expression</subcategory>
    public sealed class MethodInvocationExpression : Expression
    {
        #region Private Fields

        /// <summary>
        /// The method name.
        /// </summary>
        private Expression name;

        /// <summary>
        /// The arguments passed to the method.
        /// </summary>
        private IList<Argument> arguments;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the MethodInvocationExpression class.
        /// </summary>
        /// <param name="proxy">Proxy object for the expression.</param>
        /// <param name="name">The name of the method.</param>
        internal MethodInvocationExpression(CodeUnitProxy proxy, Expression name)
            : base(proxy, ExpressionType.MethodInvocation)
        {
            Param.Ignore(proxy);
            Param.AssertNotNull(name, "name");

            this.name = name;
        }

        #endregion Internal Constructors

        #region Public Properties

        /// <summary>
        /// Gets the name of the method.
        /// </summary>
        public Expression Name
        {
            get
            {
                return this.name;
            }
        }

        /// <summary>
        /// Gets the list of arguments passed to the method.
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

        #endregion Protected Properties
    }
}
