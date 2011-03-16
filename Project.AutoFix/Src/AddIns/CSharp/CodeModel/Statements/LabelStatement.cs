//-----------------------------------------------------------------------
// <copyright file="LabelStatement.cs">
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
    /// A label within the code.
    /// </summary>
    /// <subcategory>statement</subcategory>
    public sealed class LabelStatement : Statement
    {
        #region Private Fields

        /// <summary>
        /// The label identifier.
        /// </summary>
        private CodeUnitProperty<LiteralExpression> identifier;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the LabelStatement class.
        /// </summary>
        /// <param name="proxy">Proxy object for the statement.</param>
        /// <param name="identifier">The label identifier.</param>
        internal LabelStatement(CodeUnitProxy proxy, LiteralExpression identifier)
            : base(proxy, StatementType.Label)
        {
            Param.AssertNotNull(proxy, "proxy");
            Param.AssertNotNull(identifier, "identifier");

            this.identifier.Value = identifier;
        }

        #endregion Internal Constructors

        #region Public Properties

        /// <summary>
        /// Gets the label identifier.
        /// </summary>
        public LiteralExpression Identifier
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.identifier.Initialized)
                {
                    this.identifier.Value = this.FindFirstChild<LiteralExpression>();
                    if (this.identifier.Value == null)
                    {
                        throw new SyntaxException(this.Document, this.LineNumber);
                    }
                }

                return this.identifier.Value;
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

            this.identifier.Reset();
        }

        #endregion Protected Override Methods
    }
}
