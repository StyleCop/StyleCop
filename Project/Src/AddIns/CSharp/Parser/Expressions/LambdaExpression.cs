//-----------------------------------------------------------------------
// <copyright file="LambdaExpression.cs" company="Microsoft">
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
    /// <summary>
    /// A lambda expression.
    /// </summary>
    public sealed class LambdaExpression : ExpressionWithParameters
    {
        #region Private Fields

        /// <summary>
        /// The body of the lambda expression.
        /// </summary>
        private CodeUnit anonymousFunctionBody;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the LambdaExpression class.
        /// </summary>
        /// <param name="proxy">Proxy object for the expression.</param>
        internal LambdaExpression(CodeUnitProxy proxy) 
            : base(proxy, ExpressionType.Lambda)
        {
            Param.Ignore(proxy);
        }

        #endregion Internal Constructors

        #region Public Properties

        /// <summary>
        /// Gets the body of the lambda expression, either an expression or a statement.
        /// </summary>
        public CodeUnit AnonymousFunctionBody
        {
            get
            {
                return this.anonymousFunctionBody;
            }

            internal set
            {
                this.anonymousFunctionBody = value;
            }
        }

        #endregion Public Properties
    }
}
