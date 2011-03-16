//-----------------------------------------------------------------------
// <copyright file="ReturnStatement.cs">
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

    /// <summary>
    /// A return-statement.
    /// </summary>
    /// <subcategory>statement</subcategory>
    public sealed class ReturnStatement : Statement
    {
        #region Private Fields

        /// <summary>
        /// The return value expression, if there is one.
        /// </summary>
        private CodeUnitProperty<Expression> returnValue;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the ReturnStatement class.
        /// </summary>
        /// <param name="proxy">Proxy object for the statement.</param>
        /// <param name="returnValue">The return value expression, if there is one.</param>
        internal ReturnStatement(CodeUnitProxy proxy, Expression returnValue)
            : base(proxy, StatementType.Return)
        {
            Param.AssertNotNull(proxy, "proxy");
            Param.Ignore(returnValue);

            this.returnValue.Value = returnValue;
        }

        #endregion Internal Constructors

        #region Public Properties

        /// <summary>
        /// Gets the return value expression, if there is one.
        /// </summary>
        public Expression ReturnValue
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.returnValue.Initialized)
                {
                    this.returnValue.Value = this.FindFirstChildExpression();
                }

                return this.returnValue.Value;
            }
        }

        #endregion Public Properties

        #region Protected Override Methods

        /// <summary>
        /// Resets the contents of the class.
        /// </summary>
        protected override void Reset()
        {
            base.Reset();

            this.returnValue.Reset();
        }

        #endregion Protected Override Methods
    }
}
