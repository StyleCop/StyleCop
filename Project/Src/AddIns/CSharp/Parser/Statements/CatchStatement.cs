//-----------------------------------------------------------------------
// <copyright file="CatchStatement.cs" company="Microsoft">
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

    /// <summary>
    /// A catch-statement.
    /// </summary>
    /// <subcategory>statement</subcategory>
    public sealed class CatchStatement : Statement
    {
        #region Private Fields

        /// <summary>
        /// The try-statement that this catch-statement is attached to.
        /// </summary>
        private TryStatement tryStatement;

        /// <summary>
        /// The inner expression.
        /// </summary>
        private Expression catchExpression;

        /// <summary>
        /// The exception variable identifier.
        /// </summary>
        private string identifier;

        /// <summary>
        /// The class type of the exception being caught.
        /// </summary>
        private TypeToken classType;

        /// <summary>
        /// The statement embedded within the catch-statement.
        /// </summary>
        private BlockStatement embeddedStatement;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the CatchStatement class.
        /// </summary>
        /// <param name="proxy">Proxy object for the statement.</param>
        /// <param name="tryStatement">The try-statement that this catch-statement is attached to.</param>
        /// <param name="classExpression">The inner expression.</param>
        /// <param name="embeddedStatement">The statement embedded within the catch-statement.</param>
        internal CatchStatement(
            CodeUnitProxy proxy,
            TryStatement tryStatement,
            Expression classExpression,
            BlockStatement embeddedStatement)
            : base(proxy, StatementType.Catch)
        {
            Param.AssertNotNull(proxy, "proxy");
            Param.AssertNotNull(tryStatement, "tryStatement");
            Param.Ignore(classExpression);
            Param.AssertNotNull(embeddedStatement, "embeddedStatement");

            this.tryStatement = tryStatement;
            this.catchExpression = classExpression;
            this.embeddedStatement = embeddedStatement;

            if (classExpression != null)
            {
                if (classExpression != null)
                {
                    if (classExpression.ExpressionType == ExpressionType.Literal)
                    {
                        this.classType = ((LiteralExpression)classExpression).Token as TypeToken;
                    }
                    else if (classExpression.ExpressionType == ExpressionType.VariableDeclaration)
                    {
                        VariableDeclarationExpression variableDeclaration = (VariableDeclarationExpression)classExpression;

                        this.classType = variableDeclaration.Type;

                        foreach (VariableDeclaratorExpression declarator in variableDeclaration.Declarators)
                        {
                            this.identifier = declarator.Identifier.Text;
                            break;
                        }
                    }
                }
            }
        }

        #endregion Internal Constructors

        #region Public Properties

        /// <summary>
        /// Gets the try-statement that this catch-statement is attached to.
        /// </summary>
        public TryStatement TryStatement
        {
            get
            {
                return this.tryStatement;
            }
        }

        /// <summary>
        /// Gets the class type of the exception being caught.
        /// </summary>
        public TypeToken ClassType
        {
            get
            {
                return this.classType;
            }
        }

        /// <summary>
        /// Gets the exception variable identifier.
        /// </summary>
        public string Identifier
        {
            get
            {
                return this.identifier;
            }
        }

        /// <summary>
        /// Gets the expression within the catch statement.
        /// </summary>
        public Expression CatchExpression
        {
            get
            {
                return this.catchExpression;
            }
        }

        /// <summary>
        /// Gets the statement embedded within the catch-statement.
        /// </summary>
        public BlockStatement EmbeddedStatement
        {
            get
            {
                return this.embeddedStatement;
            }
        }

        #endregion Public Properties

        #region Public Override Methods

        /// <summary>
        /// Gets the variables defined within this code unit.
        /// </summary>
        /// <returns>Returns the collection of variables.</returns>
        public override IList<IVariable> GetVariables()
        {
            if (this.catchExpression != null)
            {
                var expression = this.catchExpression.FindFirstInTree<VariableDeclarationExpression>();
                if (expression != null)
                {
                    return expression.GetVariables();
                }
            }

            return CsParser.EmptyVariableArray;
        }

        #endregion Public Override Methods
    }
}
