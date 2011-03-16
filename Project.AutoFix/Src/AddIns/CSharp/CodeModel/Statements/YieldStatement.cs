//-----------------------------------------------------------------------
// <copyright file="YieldStatement.cs">
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
    /// A yield-statement.
    /// </summary>
    /// <subcategory>statement</subcategory>
    public sealed class YieldStatement : Statement
    {
        #region Private Fields

        /// <summary>
        /// The type of the yield statement.
        /// </summary>
        private CodeUnitProperty<Type> type;

        /// <summary>
        /// The expression being returned, if any.
        /// </summary>
        private CodeUnitProperty<Expression> returnValue;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the YieldStatement class.
        /// </summary>
        /// <param name="proxy">Proxy object for the statement.</param>
        /// <param name="type">The type of the yield statement.</param>
        /// <param name="returnValue">The yield return value expression.</param>
        internal YieldStatement(CodeUnitProxy proxy, Type type, Expression returnValue)
            : base(proxy, StatementType.Yield)
        {
            Param.AssertNotNull(proxy, "proxy");
            Param.Ignore(type);
            Param.Ignore(returnValue);

            this.type.Value = type;
            this.returnValue.Value = returnValue;
        }

        #endregion Internal Constructors

        #region Public Enums

        /// <summary>
        /// The yield statement type.
        /// </summary>
        /// <subcategory>statement</subcategory>
        [SuppressMessage(
            "Microsoft.Design",
            "CA1034:NestedTypesShouldNotBeVisible",
            Justification = "API has already been published and should not be changed.")]
        public enum Type
        {
            /// <summary>
            /// A yield break statement.
            /// </summary>
            Break,

            /// <summary>
            /// A yield return statement.
            /// </summary>
            Return
        }

        #endregion Public Enums

        #region Public Properties

        /// <summary>
        /// Gets the type of the yield statement.
        /// </summary>
        public Type YieldType
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
        /// Gets the yield return value expression, if there is one.
        /// </summary>
        public Expression ReturnValue
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.returnValue.Initialized)
                {
                    this.Initialize();
                }

                return this.returnValue.Value;
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
            this.returnValue.Reset();
        }

        #endregion Protected Override Methods

        #region Private Methods

        /// <summary>
        /// Initializes the contents of the statement.
        /// </summary>
        private void Initialize()
        {
            Token token = this.FindFirstChildToken();
            if (token == null)
            {
                throw new SyntaxException(this.Document, this.LineNumber);
            }
            else if (token.Is(TokenType.Break))
            {
                this.type.Value = YieldStatement.Type.Break;
                this.returnValue.Value = null;
            }
            else if (token.Is(TokenType.Return))
            {
                this.type.Value = YieldStatement.Type.Return;
                this.returnValue.Value = token.FindNextSiblingExpression();
            }
            else
            {
                throw new SyntaxException(this.Document, this.LineNumber);
            }
        }

        #endregion Private Methods
    }
}
