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
namespace Microsoft.StyleCop.CSharp.CodeModel
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
        private CodeUnitProperty<IList<Parameter>> parameters;

        /// <summary>
        /// The variables on the expression.
        /// </summary>
        private CodeUnitProperty<IList<IVariable>> variables;

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
                this.ValidateEditVersion();

                if (!this.parameters.Initialized)
                {
                    this.parameters.Value = this.CollectFormalParameters(this.FindFirstChild<Token>(), TokenType.CloseParenthesis);
                }

                return this.parameters.Value;
            }
        }

        /// <summary>
        /// Gets the variables defined within this element.
        /// </summary>
        /// <returns>Returns the collection of variables.</returns>
        public IList<IVariable> Variables
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.variables.Initialized)
                {
                    this.variables.Value = new List<IVariable>(this.Parameters).AsReadOnly();
                }

                return this.variables.Value;
            }
        }

        #endregion Public Properties
    }
}
