//-----------------------------------------------------------------------
// <copyright file="UncheckedStatement.cs" company="Microsoft">
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

    /// <summary>
    /// A unchecked-statement.
    /// </summary>
    /// <subcategory>statement</subcategory>
    public sealed class UncheckedStatement : Statement
    {
        #region Private Fields

        /// <summary>
        /// The statement embedded within this unchecked statement, if any.
        /// </summary>
        private CodeUnitProperty<BlockStatement> embeddedStatement;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the UncheckedStatement class.
        /// </summary>
        /// <param name="proxy">Proxy object for the statement.</param>
        /// <param name="embeddedStatement">The block statement embedded within this unchecked statement, if any.</param>
        internal UncheckedStatement(CodeUnitProxy proxy, BlockStatement embeddedStatement)
            : base(proxy, StatementType.Unchecked)
        {
            Param.AssertNotNull(proxy, "proxy");
            Param.AssertNotNull(embeddedStatement, "embeddedStatement");

            this.embeddedStatement.Value = embeddedStatement;
        }

        #endregion Internal Constructors

        #region Public Properties

        /// <summary>
        /// Gets the block statement embedded within this unchecked statement, if any.
        /// </summary>
        public BlockStatement EmbeddedStatement
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.embeddedStatement.Initialized)
                {
                    this.embeddedStatement.Value = this.FindFirstChild<BlockStatement>();
                    if (this.embeddedStatement.Value == null)
                    {
                        throw new SyntaxException(this.Document, this.LineNumber);
                    }
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

            this.embeddedStatement.Reset();
        }

        #endregion Protected Override Methods
    }
}
