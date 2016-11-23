// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MethodInvocationExpression.cs" company="https://github.com/StyleCop">
//   MS-PL
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
// <summary>
//   An expression representing a method invocation operation.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// An expression representing a method invocation operation.
    /// </summary>
    /// <subcategory>expression</subcategory>
    public sealed class MethodInvocationExpression : Expression
    {
        #region Fields

        /// <summary>
        /// The arguments passed to the method.
        /// </summary>
        private readonly IList<Argument> arguments;

        /// <summary>
        /// The method name.
        /// </summary>
        private readonly Expression name;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the MethodInvocationExpression class.
        /// </summary>
        /// <param name="tokens">
        /// The list of tokens that form the expression.
        /// </param>
        /// <param name="name">
        /// The name of the method.
        /// </param>
        /// <param name="arguments">
        /// The arguments passed to the method.
        /// </param>
        internal MethodInvocationExpression(CsTokenList tokens, Expression name, IList<Argument> arguments)
            : base(ExpressionType.MethodInvocation, tokens)
        {
            Param.AssertNotNull(tokens, "tokens");
            Param.AssertNotNull(name, "name");
            Param.AssertNotNull(arguments, "arguments");

            this.name = name;
            this.arguments = arguments;
            Debug.Assert(arguments.IsReadOnly, "The arguments collection should be read-only.");

            this.AddExpression(name);

            for (int i = 0; i < arguments.Count; ++i)
            {
                this.AddExpression(arguments[i].Expression);
            }
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the list of arguments passed to the method.
        /// </summary>
        public IList<Argument> Arguments
        {
            get
            {
                return this.arguments;
            }
        }

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

        #endregion
    }
}