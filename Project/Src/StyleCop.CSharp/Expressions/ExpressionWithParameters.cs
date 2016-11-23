// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExpressionWithParameters.cs" company="https://github.com/StyleCop">
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
//   An expression which defines a parameter list.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    using System.Collections.Generic;

    /// <summary>
    /// An expression which defines a parameter list.
    /// </summary>
    public class ExpressionWithParameters : Expression, IParameterContainer
    {
        #region Fields

        /// <summary>
        /// The parameters defines in the expression.
        /// </summary>
        private List<Parameter> parameters;

        /// <summary>
        /// The parameters list as a read-only collection.
        /// </summary>
        private IList<Parameter> readOnlyParameters;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the ExpressionWithParameters class.
        /// </summary>
        /// <param name="type">
        /// The type of the expression.
        /// </param>
        internal ExpressionWithParameters(ExpressionType type)
            : base(type)
        {
            Param.Ignore(type);
        }

        #endregion

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
                    return Parameter.EmptyParameterArray;
                }

                if (this.readOnlyParameters == null)
                {
                    this.readOnlyParameters = this.parameters.AsReadOnly();
                }

                return this.readOnlyParameters;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Adds a parameter to the expression.
        /// </summary>
        /// <param name="parameter">
        /// The parameter to add.
        /// </param>
        internal void AddParameter(Parameter parameter)
        {
            Param.AssertNotNull(parameter, "parameter");

            if (this.parameters == null)
            {
                this.parameters = new List<Parameter>();
            }

            this.parameters.Add(parameter);
        }

        /// <summary>
        /// Adds a range of parameters to the expression.
        /// </summary>
        /// <param name="items">
        /// The parameters to add.
        /// </param>
        internal void AddParameters(IEnumerable<Parameter> items)
        {
            Param.AssertNotNull(items, "items");

            if (this.parameters == null)
            {
                this.parameters = new List<Parameter>();
            }

            this.parameters.AddRange(items);
        }

        #endregion
    }
}