//-----------------------------------------------------------------------
// <copyright file="ArrayAccessExpression.cs">
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
    using System.Collections.Generic;

    /// <summary>
    /// An expression representing an array access operation.
    /// </summary>
    /// <subcategory>expression</subcategory>
    public sealed class ArrayAccessExpression : Expression
    {
        #region Private Fields

        /// <summary>
        /// Represents the item being indexed.
        /// </summary>
        private CodeUnitProperty<Expression> array;

        /// <summary>
        /// The array access arguments.
        /// </summary>
        private CodeUnitProperty<IList<Argument>> arguments;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the ArrayAccessExpression class.
        /// </summary>
        /// <param name="proxy">Proxy object for the expression.</param>
        /// <param name="array">Represents the item being indexed.</param>
        internal ArrayAccessExpression(CodeUnitProxy proxy, Expression array)
            : base(proxy, ExpressionType.ArrayAccess)
        {
            Param.AssertNotNull(proxy, "proxy");
            Param.AssertNotNull(array, "array");

            this.array.Value = array;
        }

        #endregion Internal Constructors

        #region Public Properties

        /// <summary>
        /// Gets the item being indexed.
        /// </summary>
        public Expression Array
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.array.Initialized)
                {
                    this.array.Value = this.FindFirstChildExpression();
                    if (this.array.Value == null)
                    {
                        throw new SyntaxException(this.Document, this.LineNumber);
                    }
                }

                return this.array.Value;
            }
        }

        /// <summary>
        /// Gets the array access arguments.
        /// </summary>
        public IList<Argument> Arguments
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.arguments.Initialized)
                {
                    this.arguments.Value = this.CollectArguments();
                }

                return this.arguments.Value;
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

            this.array.Reset();
            this.arguments.Reset();
        }

        #endregion Protected Override Methods
    }
}
