//-----------------------------------------------------------------------
// <copyright file="SwitchCaseStatement.cs" company="Microsoft">
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

    /// <summary>
    /// A case-statement within a switch-statement.
    /// </summary>
    /// <subcategory>statement</subcategory>
    public sealed class SwitchCaseStatement : Statement
    {
        #region Private Fields

        /// <summary>
        /// The case label identifier.
        /// </summary>
        private CodeUnitProperty<Expression> identifier;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the SwitchCaseStatement class.
        /// </summary>
        /// <param name="proxy">Proxy object for the statement.</param>
        /// <param name="identifier">The case label identifier.</param>
        internal SwitchCaseStatement(CodeUnitProxy proxy, Expression identifier) 
            : base(proxy, StatementType.SwitchCase)
        {
            Param.AssertNotNull(proxy, "proxy");
            Param.AssertNotNull(identifier, "identifier");

            this.identifier.Value = identifier;
        }

        #endregion Internal Constructors

        #region Public Properties

        /// <summary>
        /// Gets the case label identifier.
        /// </summary>
        public Expression Identifier
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.identifier.Initialized)
                {
                    this.identifier.Value = this.FindFirstChild<Expression>();
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
