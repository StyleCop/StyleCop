// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AnonymousMethodExpression.cs" company="https://github.com/StyleCop">
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
//   An expression representing an anonymous method.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    /// <summary>
    /// An expression representing an anonymous method.
    /// </summary>
    /// <subcategory>expression</subcategory>
    public sealed class AnonymousMethodExpression : ExpressionWithParameters
    {
        #region Fields

        /// <summary>
        /// Is this expression sync or async.
        /// </summary>
        private bool asyncExpression;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the AnonymousMethodExpression class.
        /// </summary>
        internal AnonymousMethodExpression()
            : base(ExpressionType.AnonymousMethod)
        {
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets a value indicating whether this anonymous expression is async or sync.
        /// </summary>
        public bool Async
        {
            get
            {
                return this.asyncExpression;
            }

            internal set
            {
                Param.AssertNotNull(value, "Async");
                this.asyncExpression = value;
            }
        }

        #endregion
    }
}