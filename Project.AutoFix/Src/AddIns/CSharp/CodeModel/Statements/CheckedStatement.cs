//-----------------------------------------------------------------------
// <copyright file="CheckedStatement.cs">
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
    /// A checked-statement.
    /// </summary>
    /// <subcategory>statement</subcategory>
    public sealed class CheckedStatement : Statement
    {
        #region Private Fields

        /// <summary>
        /// The body of the checked statement, if any.
        /// </summary>
        private CodeUnitProperty<BlockStatement> body;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the CheckedStatement class.
        /// </summary>
        /// <param name="proxy">Proxy object for the statement.</param>
        /// <param name="body">The body of the checked statement, if any.</param>
        internal CheckedStatement(CodeUnitProxy proxy, BlockStatement body)
            : base(proxy, StatementType.Checked)
        {
            Param.AssertNotNull(proxy, "proxy");
            Param.AssertNotNull(body, "body");

            this.body.Value = body;
        }

        #endregion Internal Constructors

        #region Public Properties

        /// <summary>
        /// Gets the body of the checked statement, if any.
        /// </summary>
        public BlockStatement Body
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.body.Initialized)
                {
                    this.body.Value = this.FindFirstChild<BlockStatement>();
                    if (this.body.Value == null)
                    {
                        throw new SyntaxException(this.Document, this.LineNumber);
                    }
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

            this.body.Reset();
        }

        #endregion Protected Override Methods
    }
}
