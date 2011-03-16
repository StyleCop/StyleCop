//-----------------------------------------------------------------------
// <copyright file="NewArrayExpression.cs">
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
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// An expression representing a new array allocation operation.
    /// </summary>
    /// <subcategory>expression</subcategory>
    public sealed class NewArrayExpression : Expression
    {
        #region Private Fields

        /// <summary>
        /// The type of the array.
        /// </summary>
        private CodeUnitProperty<ArrayAccessExpression> type;

        /// <summary>
        /// The type creation expression.
        /// </summary>
        private CodeUnitProperty<ArrayInitializerExpression> initializer;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the NewArrayExpression class.
        /// </summary>
        /// <param name="proxy">Proxy object for the expression.</param>
        /// <param name="type">The array type.</param>
        /// <param name="initializer">The array initializer expression.</param>
        internal NewArrayExpression(
            CodeUnitProxy proxy, ArrayAccessExpression type, ArrayInitializerExpression initializer)
            : base(proxy, ExpressionType.NewArray)
        {
            Param.AssertNotNull(proxy, "proxy");
            Param.Ignore(type, "type");
            Param.Ignore(initializer);

            this.type.Value = type;
            this.initializer.Value = initializer;
        }

        #endregion Internal Constructors

        #region Public Properties

        /// <summary>
        /// Gets the array type.
        /// </summary>
        /// <remarks>The type will be null if this instance represents the creation of an implicitly typed array.</remarks>
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
                    this.Initialize();
                }

                return this.type.Value;
            }
        }

        /// <summary>
        /// Gets the array initializer expression, if there is one.
        /// </summary>
        public ArrayInitializerExpression Initializer
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.initializer.Initialized)
                {
                    this.Initialize();
                }

                return this.initializer.Value;
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
            this.initializer.Reset();
        }

        #endregion Protected Override Methods

        #region Private Methods

        /// <summary>
        /// Initializes the contents of the expression.
        /// </summary>
        private void Initialize()
        {
            this.type.Value = this.FindFirstChild<ArrayAccessExpression>();
            this.initializer.Value = this.FindFirstChild<ArrayInitializerExpression>();
        }

        #endregion Private Methods
    }
}
