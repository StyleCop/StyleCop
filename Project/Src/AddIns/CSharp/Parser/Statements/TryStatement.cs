//-----------------------------------------------------------------------
// <copyright file="TryStatement.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
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
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// A try-statement.
    /// </summary>
    /// <subcategory>statement</subcategory>
    public sealed class TryStatement : Statement
    {
        #region Private Fields

        /// <summary>
        /// The statement embedded within the try-statement.
        /// </summary>
        private BlockStatement embeddedStatement;

        /// <summary>
        /// The finally-statement attached to this try-statement, if there is one.
        /// </summary>
        private FinallyStatement finallyStatement;

        /// <summary>
        /// The list of catch-statements attached to this try-statement.
        /// </summary>
        private ICollection<CatchStatement> catchStatements;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the TryStatement class.
        /// </summary>
        /// <param name="proxy">Proxy object for the statement.</param>
        /// <param name="embeddedStatement">The statement embedded within this try-statement.</param>
        internal TryStatement(CodeUnitProxy proxy, BlockStatement embeddedStatement)
            : base(proxy, StatementType.Try)
        {
            Param.AssertNotNull(proxy, "proxy");
            Param.AssertNotNull(embeddedStatement, "embeddedStatement");

            this.embeddedStatement = embeddedStatement;
        }

        #endregion Internal Constructors

        #region Public Properties

        /// <summary>
        /// Gets the block embedded within this try-statement.
        /// </summary>
        public BlockStatement EmbeddedStatement
        {
            get
            {
                return this.embeddedStatement;
            }
        }

        /// <summary>
        /// Gets the finally-statement attached to this try-statement, if there is one.
        /// </summary>
        public FinallyStatement FinallyStatement
        {
            get
            {
                return this.finallyStatement;
            }

            internal set
            {
                this.finallyStatement = value;
            }
        }

        /// <summary>
        /// Gets the list of catch-statements attached to this try-statement.
        /// </summary>
        public ICollection<CatchStatement> CatchStatements
        {
            get
            {
                return this.catchStatements;
            }

            internal set
            {
                Param.Ignore(value);
                this.catchStatements = value;

                Debug.Assert(
                    this.catchStatements == null || this.catchStatements.IsReadOnly,
                    "The collection of catch statements should be read-only.");
            }
        }

        #endregion Public Properties

        #region Public Override Properties

        /// <summary>
        /// Gets the collection of statements attached to this try-statement.
        /// </summary>
        public override IEnumerable<Statement> AttachedStatements
        {
            get
            {
                if (this.catchStatements.Count > 0)
                {
                    foreach (CatchStatement catchStatement in this.catchStatements)
                    {
                        yield return catchStatement;
                    }
                }

                if (this.finallyStatement != null)
                {
                    yield return this.finallyStatement;
                }

                yield break;
            }
        }

        #endregion Public Override Properties
    }
}
