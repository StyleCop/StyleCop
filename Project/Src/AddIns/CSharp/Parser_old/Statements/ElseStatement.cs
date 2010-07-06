//-----------------------------------------------------------------------
// <copyright file="ElseStatement.cs" company="Microsoft">
//   Copyright (c) Microsoft Corporation.
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
namespace Microsoft.StyleCop.CSharp_old
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// An else-statement.
    /// </summary>
    /// <subcategory>statement</subcategory>
    public sealed class ElseStatement : Statement
    {
        #region Private Fields

        /// <summary>
        /// The statement that is embedded within this else-statement.
        /// </summary>
        private Statement embeddedStatement;

        /// <summary>
        /// The expression within the if portion of this else-statement, if any.
        /// </summary>
        private Expression conditionExpression;

        /// <summary>
        /// The else-statement attached to the end of this else-statement, if any.
        /// </summary>
        private ElseStatement elseStatement;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the ElseStatement class.
        /// </summary>
        /// <param name="tokens">The list of tokens that form the statement.</param>
        /// <param name="conditionExpression">The expression within the if portion of this 
        /// else-statement, if any.</param>
        internal ElseStatement(CsTokenList tokens, Expression conditionExpression)
            : base(StatementType.Else, tokens)
        {
            Param.AssertNotNull(tokens, "tokens");
            Param.Ignore(conditionExpression);

            this.conditionExpression = conditionExpression;

            if (conditionExpression != null)
            {
                this.AddExpression(conditionExpression);
            }
        }

        #endregion Internal Constructors

        #region Public Properties

        /// <summary>
        /// Gets the expression within the if portion of this else-statement, if any.
        /// </summary>
        public Expression ConditionExpression
        {
            get
            {
                return this.conditionExpression;
            }
        }

        /// <summary>
        /// Gets the statement that is embedded within this else-statement.
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
                this.AddStatement(this.embeddedStatement);
            }
        }

        /// <summary>
        /// Gets the next else-statement attached to the end of this else-statement, if any.
        /// </summary>
        public ElseStatement AttachedElseStatement
        {
            get
            {
                return this.elseStatement;
            }

            internal set
            {
                this.elseStatement = value;
            }
        }

        #endregion Public Properties

        #region Public Override Properties

        /// <summary>
        /// Gets the collection of statements attached to this else-statement.
        /// </summary>
        public override IEnumerable<Statement> AttachedStatements
        {
            get
            {
                ElseStatement elseStatement = this.elseStatement;
                while (elseStatement != null)
                {
                    yield return this.elseStatement;
                    elseStatement = elseStatement.AttachedElseStatement;
                }

                yield break;
            }
        }

        #endregion Public Override Properties
    }
}
