//-----------------------------------------------------------------------
// <copyright file="ExpressionWithParameters.cs" company="Microsoft">
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
    using System.Text;

    /// <summary>
    /// An expression which defines a parameter list.
    /// </summary>
    public class ExpressionWithParameters : Expression, IParameterContainer
    {
        #region Private Fields

        /// <summary>
        /// The parameters defines in the expression.
        /// </summary>
        private IList<Parameter> parameters;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the ExpressionWithParameters class.
        /// </summary>
        /// <param name="proxy">Proxy object for the expression.</param>
        /// <param name="type">The type of the expression.</param>
        internal ExpressionWithParameters(CodeUnitProxy proxy, ExpressionType type)
            : base(proxy, type)
        {
            Param.AssertNotNull(proxy, "proxy");
            Param.Ignore(type);
        }

        #endregion Internal Constructors

        #region Public Properties

        /// <summary>
        /// Gets the parameters passed to the expression.
        /// </summary>
        public IList<Parameter> Parameters
        {
            get
            {
                if (this.parameters == null)
                {
                    this.parameters = this.CollectFormalParameters(this.FindFirstChild<Token>(), TokenType.CloseParenthesis);
                }

                return this.parameters;
            }
        }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Gets the variables defined within this element.
        /// </summary>
        /// <returns>Returns the collection of variables.</returns>
        public IList<IVariable> GetVariables()
        {
            IList<Parameter> parameters = this.Parameters;

            if (parameters != null && parameters.Count > 0)
            {
                IVariable[] variables = new IVariable[parameters.Count];
                for (int i = 0; i < parameters.Count; ++i)
                {
                    variables[i] = parameters[i];
                }

                return variables;
            }

            return CsParser.EmptyVariableArray;
        }

        #endregion Public Methods
    }
}
