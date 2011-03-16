//-----------------------------------------------------------------------
// <copyright file="StackallocExpression.cs">
//   MS-PL
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
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// An expression representing a stackalloc operation.
    /// </summary>
    /// <subcategory>expression</subcategory>
    public sealed class StackallocExpression : Expression
    {
        #region Private Fields

        /// <summary>
        /// The type of the array.
        /// </summary>
        private CodeUnitProperty<ArrayAccessExpression> type;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the StackallocExpression class.
        /// </summary>
        /// <param name="proxy">Proxy object for the expression.</param>
        /// <param name="type">The array type.</param>
        internal StackallocExpression(CodeUnitProxy proxy, ArrayAccessExpression type)
            : base(proxy, ExpressionType.Stackalloc)
        {
            Param.AssertNotNull(proxy, "proxy");
            Param.AssertNotNull(type, "type");

            this.type.Value = type;
        }

        #endregion Internal Constructors

        #region Public Properties

        /// <summary>
        /// Gets the array type.
        /// </summary>
        [SuppressMessage(
            "Microsoft.Naming", 
            "CA1721:PropertyNamesShouldNotMatchGetMethods",
            Justification = "API has already been published and should not be changed.")]
        public ArrayAccessExpression Type
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.type.Initialized)
                {
                    this.type.Value = this.FindFirstChild<ArrayAccessExpression>();

                    if (this.type.Value == null)
                    {
                        throw new SyntaxException(this.Document, this.LineNumber);
                    }
                }

                return this.type.Value;
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

            this.type.Reset();
        }

        #endregion Protected Override Methods
    }
}
