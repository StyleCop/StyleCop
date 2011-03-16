//-----------------------------------------------------------------------
// <copyright file="ExpressionWithParameters.cs">
//     MS-PL
// </copyright>
// <license>
//   This source code is subject to terms and conditions of the Microsoft 
//   Public License. A copy of the license can be found in the License.html 
//   file at the root of this distribution. 
//   By using this source code in any fashion, you are agreeing to be bound 
//   by the terms of the Microsoft Public License. You must not remove this 
//   notice, or any other, from this software.
// </license>
//-----------------------------------------------------------------------
namespace StyleCop.CSharp.CodeModel
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// An expression which defines a parameter list.
    /// </summary>
    public class ExpressionWithParameters : Expression
    {
        #region Private Fields

        /// <summary>
        /// The parameters defines in the expression.
        /// </summary>
        private CodeUnitProperty<ParameterList> parameterList;

        /// <summary>
        /// The variables on the expression.
        /// </summary>
        private CodeUnitProperty<VariableCollection> variables;

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
        /// Gets the variables defined within this element.
        /// </summary>
        /// <returns>Returns the collection of variables.</returns>
        public override VariableCollection Variables
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.variables.Initialized)
                {
                    this.variables.Value = new VariableCollection();
                    if (this.ParameterList != null)
                    {
                        this.variables.Value.AddRange(this.ParameterList.Parameters);
                    }
                }

                return this.variables.Value;
            }
        }

        /// <summary>
        /// Gets the parameters passed to the expression.
        /// </summary>
        public ParameterList ParameterList
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.parameterList.Initialized)
                {
                    this.parameterList.Value = this.FindFirstChild<ParameterList>();
                }

                return this.parameterList.Value;
            }
        }

        #endregion Public Properties
    }
}
