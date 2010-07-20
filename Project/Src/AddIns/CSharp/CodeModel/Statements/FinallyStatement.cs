//-----------------------------------------------------------------------
// <copyright file="FinallyStatement.cs" company="Microsoft">
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
    using System.Diagnostics;

    /// <summary>
    /// A finally-statement.
    /// </summary>
    /// <subcategory>statement</subcategory>
    public sealed class FinallyStatement : Statement
    {
        #region Private Fields

        /// <summary>
        /// The try-statement that this finally-statement is attached to.
        /// </summary>
        private CodeUnitProperty<TryStatement> tryStatement;

        /// <summary>
        /// The statement embedded within the catch-statement.
        /// </summary>
        private CodeUnitProperty<BlockStatement> embeddedStatement;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the FinallyStatement class.
        /// </summary>
        /// <param name="proxy">Proxy object for the statement.</param>
        /// <param name="tryStatement">The try-statement that this finally-statement is embedded to.</param>
        /// <param name="embeddedStatement">The statement embedded within the finally-statement.</param>
        internal FinallyStatement(CodeUnitProxy proxy, TryStatement tryStatement, BlockStatement embeddedStatement)
            : base(proxy, StatementType.Finally)        
        {
            Param.AssertNotNull(proxy, "proxy");
            Param.AssertNotNull(tryStatement, "tryStatement");
            Param.AssertNotNull(embeddedStatement, "embeddedStatement");

            this.tryStatement.Value = tryStatement;
            this.embeddedStatement.Value = embeddedStatement;
        }

        #endregion Internal Constructors

        #region Public Properties

        /// <summary>
        /// Gets the try-statement that this finally-statement is attached to.
        /// </summary>
        public TryStatement TryStatement
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.tryStatement.Initialized)
                {
                    this.Initialize();
                    Debug.Assert(this.tryStatement.Value != null, "Failed to initialize.");
                }

                return this.tryStatement.Value;
            }
        }

        /// <summary>
        /// Gets the statement embedded within the finally-statement.
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

        #endregion Public Properties

        #region Protected Override Methods

        /// <summary>
        /// Resets the contents of the class.
        /// </summary>
        protected override void Reset()
        {
            base.Reset();

            this.tryStatement.Reset();
            this.embeddedStatement.Reset();
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

            // Look for the try-statement that this finally-statement is attached to.
            this.tryStatement.Value = null;

            for (CodeUnit c = this.FindPreviousSibling<CodeUnit>(); c != null; c = c.FindNext<CodeUnit>())
            {
                if (c.Is(StatementType.Try))
                {
                    this.tryStatement.Value = (TryStatement)c;
                }
                else if (!c.Is(StatementType.Catch) && (!c.Is(CodeUnitType.LexicalElement) || c.Is(LexicalElementType.Token)))
                {
                    break;
                }
            }

            if (this.tryStatement.Value == null)
            {
                throw new SyntaxException(this.Document, this.LineNumber);
            }
        }

        #endregion Private Methods
    }
}
