//-----------------------------------------------------------------------
// <copyright file="BlockStatement.cs">
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

    /// <summary>
    /// A statement representing a new scope block.
    /// </summary>
    public sealed class BlockStatement : Statement
    {
        #region Private Fields

        /// <summary>
        /// The variables defined within the statement.
        /// </summary>
        private CodeUnitProperty<VariableCollection> variables;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the BlockStatement class.
        /// </summary>
        /// <param name="proxy">Proxy object for the statement.</param>
        internal BlockStatement(CodeUnitProxy proxy) 
            : base(proxy, StatementType.Block)
        {
            Param.Ignore(proxy);
        }

        #endregion Internal Constructors

        #region Public Override Properties

        /// <summary>
        /// Gets the variables defined within this code unit.
        /// </summary>
        public override VariableCollection Variables
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.variables.Initialized)
                {
                    this.variables.Value = new VariableCollection();

                    for (VariableDeclarationStatement variableStatement = this.FindFirstChild<VariableDeclarationStatement>();
                        variableStatement != null;
                        variableStatement = variableStatement.FindNextSibling<VariableDeclarationStatement>())
                    {
                        this.variables.Value.AddRange(variableStatement.Variables);
                    }
                }

                return this.variables.Value;
            }
        }

        #endregion Public Override Properties

        #region Protected Override Methods

        /// <summary>
        /// Resets the contents of the item.
        /// </summary>
        protected override void Reset()
        {
            base.Reset();
            this.variables.Reset();
        }

        #endregion Protected Override Methods
    }
}
