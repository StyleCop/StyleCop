//-----------------------------------------------------------------------
// <copyright file="BlockStatement.cs" company="Microsoft">
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

    /// <summary>
    /// A statement representing a new scope block.
    /// </summary>
    /// <subcategory>statement</subcategory>
    public sealed class BlockStatement : Statement
    {
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
        public override IList<IVariable> Variables
        {
            get
            {
                List<IVariable> variables = null;

                for (VariableDeclarationStatement variableStatement = this.FindFirstChild<VariableDeclarationStatement>();
                    variableStatement != null;
                    variableStatement = variableStatement.FindNextSibling<VariableDeclarationStatement>())
                {
                    if (variables == null)
                    {
                        variables = new List<IVariable>();
                    }

                    variables.AddRange(variableStatement.Variables);
                }

                if (variables != null && variables.Count > 0)
                {
                    return variables.AsReadOnly();
                }

                return CsParser.EmptyVariableArray;
            }
        }

        #endregion Public Override Properties
    }
}
