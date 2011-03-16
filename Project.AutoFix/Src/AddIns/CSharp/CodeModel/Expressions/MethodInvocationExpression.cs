//-----------------------------------------------------------------------
// <copyright file="MethodInvocationExpression.cs">
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
    /// An expression representing a method invocation operation.
    /// </summary>
    /// <subcategory>expression</subcategory>
    public sealed class MethodInvocationExpression : Expression
    {
        #region Private Fields

        /// <summary>
        /// The method name.
        /// </summary>
        private CodeUnitProperty<Expression> name;

        /// <summary>
        /// The arguments passed to the method.
        /// </summary>
        private CodeUnitProperty<ArgumentList> argumentList;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the MethodInvocationExpression class.
        /// </summary>
        /// <param name="proxy">Proxy object for the expression.</param>
        /// <param name="name">The name of the method.</param>
        internal MethodInvocationExpression(CodeUnitProxy proxy, Expression name)
            : base(proxy, ExpressionType.MethodInvocation)
        {
            Param.Ignore(proxy);
            Param.AssertNotNull(name, "name");

            this.name.Value = name;
        }

        /// <summary>
        /// Initializes a new instance of the MethodInvocationExpression class.
        /// </summary>
        /// <param name="proxy">Proxy object for the expression.</param>
        /// <param name="name">The name of the method.</param>
        /// <param name="argumentList">The method argument list.</param>
        internal MethodInvocationExpression(CodeUnitProxy proxy, Expression name, ArgumentList argumentList)
            : base(proxy, ExpressionType.MethodInvocation)
        {
            Param.Ignore(proxy);
            Param.AssertNotNull(name, "name");
            Param.AssertNotNull(argumentList, "argumentList");

            this.name.Value = name;
            this.argumentList.Value = argumentList;
        }

        #endregion Internal Constructors

        #region Public Properties

        /// <summary>
        /// Gets the name of the method.
        /// </summary>
        public Expression Name
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.name.Initialized)
                {
                    this.name.Value = this.FindFirstChildExpression();
                    if (this.name.Value == null)
                    {
                        throw new SyntaxException(this.Document, this.LineNumber);
                    }
                }

                return this.name.Value;
            }
        }

        /// <summary>
        /// Gets the list of arguments passed to the method.
        /// </summary>
        public ArgumentList ArgumentList
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.argumentList.Initialized)
                {
                    this.argumentList.Value = this.FindFirstChild<ArgumentList>();
                    CsLanguageService.Debug.Assert(this.argumentList.Value != null, "Failed to initialize.");
                }

                return this.argumentList.Value;
            }
        }

        #endregion Protected Properties

        #region Protected Override Methods

        /// <summary>
        /// Resets the contents of the class.
        /// </summary>
        protected override void Reset()
        {
            base.Reset();

            this.name.Reset();
            this.argumentList.Reset();
        }

        #endregion Protected Override Methods
    }
}
