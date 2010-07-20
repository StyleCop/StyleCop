//-----------------------------------------------------------------------
// <copyright file="TryStatement.cs" company="Microsoft">
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
        private CodeUnitProperty<BlockStatement> embeddedStatement;

        /// <summary>
        /// The finally-statement attached to this try-statement, if there is one.
        /// </summary>
        private CodeUnitProperty<FinallyStatement> finallyStatement;

        /// <summary>
        /// The list of catch-statements attached to this try-statement.
        /// </summary>
        private CodeUnitProperty<ICollection<CatchStatement>> catchStatements;

        /// <summary>
        /// Statements attached to this statement.
        /// </summary>
        private CodeUnitProperty<ICollection<Statement>> attachedStatements;

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

            this.embeddedStatement.Value = embeddedStatement;
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
                this.ValidateEditVersion();

                if (!this.embeddedStatement.Initialized)
                {
                    this.Initialize();
                    Debug.Assert(this.embeddedStatement.Value != null, "Failed to initialize.");
                }

                return this.embeddedStatement.Value;
            }
        }

        /// <summary>
        /// Gets the finally-statement attached to this try-statement, if there is one.
        /// </summary>
        public FinallyStatement FinallyStatement
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.finallyStatement.Initialized)
                {
                    this.Initialize();
                }

                return this.finallyStatement.Value;
            }
        }

        /// <summary>
        /// Gets the list of catch-statements attached to this try-statement.
        /// </summary>
        public ICollection<CatchStatement> CatchStatements
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.catchStatements.Initialized)
                {
                    this.Initialize();
                    Debug.Assert(this.catchStatements.Value != null, "Failed to initialize.");
                }

                return this.catchStatements.Value;
            }
        }

        #endregion Public Properties

        #region Public Override Properties

        /// <summary>
        /// Gets the collection of statements attached to this try-statement.
        /// </summary>
        public override ICollection<Statement> AttachedStatements
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.attachedStatements.Initialized)
                {
                    List<Statement> statements = new List<Statement>();

                    if (this.CatchStatements.Count > 0)
                    {
                        statements.AddRange(this.CatchStatements);
                    }

                    if (this.FinallyStatement != null)
                    {
                        statements.Add(this.FinallyStatement);
                    }

                    this.attachedStatements.Value = statements.AsReadOnly();
                }

                return this.attachedStatements.Value;
            }
        }

        #endregion Public Override Properties

        #region Protected Override Methods

        /// <summary>
        /// Resets the contents of the class.
        /// </summary>
        protected override void Reset()
        {
            base.Reset();

            this.embeddedStatement.Reset();
            this.finallyStatement.Reset();
            this.catchStatements.Reset();
            this.attachedStatements.Reset();
        }

        #endregion Protected Override Methods

        #region Private Methods

        /// <summary>
        /// Initializes the contents of the statement.
        /// </summary>
        private void Initialize()
        {
            this.embeddedStatement.Value = this.FindFirstChild<BlockStatement>();
            if (this.embeddedStatement.Value == null)
            {
                throw new SyntaxException(this.Document, this.LineNumber);
            }

            List<CatchStatement> catchList = new List<CatchStatement>();
            for (CodeUnit c = this.FindNextSibling<CodeUnit>(); c != null; c = c.FindNext<CodeUnit>())
            {
                if (c.Is(StatementType.Catch))
                {
                    catchList.Add((CatchStatement)c);
                }
                else if (c.Is(StatementType.Finally))
                {
                    this.finallyStatement.Value = (FinallyStatement)c;
                    break;
                }
                else if (!c.Is(CodeUnitType.LexicalElement) || c.Is(LexicalElementType.Token))
                {
                    break;
                }
            }

            this.catchStatements.Value = catchList.AsReadOnly();
        }

        #endregion Private Methods
    }
}
