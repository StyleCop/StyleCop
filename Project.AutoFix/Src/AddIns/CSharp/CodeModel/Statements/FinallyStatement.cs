//-----------------------------------------------------------------------
// <copyright file="FinallyStatement.cs">
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
        /// The body of the finally-statement.
        /// </summary>
        private CodeUnitProperty<BlockStatement> body;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the FinallyStatement class.
        /// </summary>
        /// <param name="proxy">Proxy object for the statement.</param>
        /// <param name="tryStatement">The try-statement that this finally-statement is embedded to.</param>
        /// <param name="body">The body of the finally-statement.</param>
        internal FinallyStatement(CodeUnitProxy proxy, TryStatement tryStatement, BlockStatement body)
            : base(proxy, StatementType.Finally)        
        {
            Param.AssertNotNull(proxy, "proxy");
            Param.AssertNotNull(tryStatement, "tryStatement");
            Param.AssertNotNull(body, "body");

            this.tryStatement.Value = tryStatement;
            this.body.Value = body;
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
                    CsLanguageService.Debug.Assert(this.tryStatement.Value != null, "Failed to initialize.");
                }

                return this.tryStatement.Value;
            }
        }

        /// <summary>
        /// Gets the body of the finally-statement.
        /// </summary>
        public BlockStatement Body
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.body.Initialized)
                {
                    this.Initialize();
                    CsLanguageService.Debug.Assert(this.body.Value != null, "Failed to initialize.");
                }

                return this.body.Value;
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
            this.body.Reset();
        }

        #endregion Protected Override Methods

        #region Private Methods

        /// <summary>
        /// Initializes the contents of the statement.
        /// </summary>
        private void Initialize()
        {
            this.body.Value = this.FindFirstChild<BlockStatement>();
            if (this.body.Value == null)
            {
                throw new SyntaxException(this.Document, this.LineNumber);
            }

            // Look for the try-statement that this finally-statement is attached to.
            this.tryStatement.Value = null;

            for (CodeUnit c = this.FindPreviousSibling(); c != null; c = c.FindNext())
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
