//-----------------------------------------------------------------------
// <copyright file="UsingStatement.cs" company="Microsoft">
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
    /// A using-statement.
    /// </summary>
    /// <subcategory>statement</subcategory>
    public sealed class UsingStatement : Statement
    {
        #region Private Fields

        /// <summary>
        /// The expression declared in the using-statement.
        /// </summary>
        private Expression resource;

        /// <summary>
        /// The statement that is embedded within this using-statement.
        /// </summary>
        private Statement embeddedStatement;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the UsingStatement class.
        /// </summary>
        /// <param name="proxy">Proxy object for the statement.</param>
        /// <param name="resource">The resource aquisition expression declared in the using statement.</param>
        internal UsingStatement(CodeUnitProxy proxy, Expression resource)
            : base(proxy, StatementType.Using)
        {
            Param.AssertNotNull(proxy, "proxy");
            Param.AssertNotNull(resource, "resource");

            this.resource = resource;
        }

        #endregion Internal Constructors

        #region Public Properties

        /// <summary>
        /// Gets the resource aquisition expression assigned to the obtained resource.
        /// </summary>
        public Expression Resource
        {
            get
            {
                return this.resource;
            }
        }

        /// <summary>
        /// Gets the statement that is embedded within this while-statement.
        /// </summary>
        public Statement EmbeddedStatement
        {
            get
            {
                return this.embeddedStatement;
            }

            internal set
            {
                Param.AssertNotNull(value, "EmbeddedStatement");
                this.embeddedStatement = value;
            }
        }

        /// <summary>
        /// Gets the variables defined within this code unit.
        /// </summary>
        /// <returns>Returns the collection of variables.</returns>
        public override IList<IVariable> Variables
        {
            get
            {
                VariableDeclarationExpression item = this.FindFirstChild<VariableDeclarationExpression>();
                if (item != null)
                {
                    return item.GetVariables();
                }

                return CsParser.EmptyVariableArray;
            }
        }

        #endregion Public Properties
    }
}
