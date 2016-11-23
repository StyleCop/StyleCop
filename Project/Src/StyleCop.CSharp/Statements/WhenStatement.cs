// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WhenStatement.cs" company="https://github.com/StyleCop">
//   MS-PL
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
// <summary>
//   A when statement.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    /// <summary>
    /// An when statement.
    /// </summary>
    /// <subcategory>statement</subcategory>
    public sealed class WhenStatement : Statement
    {
        #region Fields

        /// <summary>
        /// The when value expression.
        /// </summary>
        private readonly Expression whenValue;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the WhenStatement class.
        /// </summary>
        /// <param name="tokens">
        /// The list of tokens that form the statement.
        /// </param>
        /// <param name="whenValue">
        /// The await value expression.
        /// </param>
        internal WhenStatement(CsTokenList tokens, Expression whenValue)
            : base(StatementType.When, tokens)
        {
            Param.AssertNotNull(tokens, "tokens");
            Param.Ignore(whenValue);

            this.whenValue = whenValue;

            if (whenValue != null)
            {
                this.AddExpression(whenValue);
            }
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the when value expression.
        /// </summary>
        public Expression WhenValue
        {
            get
            {
                return this.whenValue;
            }
        }

        #endregion
    }
}