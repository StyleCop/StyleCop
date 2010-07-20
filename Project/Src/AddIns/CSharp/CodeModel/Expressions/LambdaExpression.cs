//-----------------------------------------------------------------------
// <copyright file="LambdaExpression.cs" company="Microsoft">
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
namespace Microsoft.StyleCop.CSharp.CodeModel
{
    /// <summary>
    /// A lambda expression.
    /// </summary>
    public sealed class LambdaExpression : ExpressionWithParameters
    {
        #region Private Fields

        /// <summary>
        /// The body of the lambda expression.
        /// </summary>
        private CodeUnitProperty<CodeUnit> anonymousFunctionBody;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the LambdaExpression class.
        /// </summary>
        /// <param name="proxy">Proxy object for the expression.</param>
        internal LambdaExpression(CodeUnitProxy proxy) 
            : base(proxy, ExpressionType.Lambda)
        {
            Param.Ignore(proxy);
        }

        #endregion Internal Constructors

        #region Public Properties

        /// <summary>
        /// Gets the body of the lambda expression, either an expression or a statement.
        /// </summary>
        public CodeUnit AnonymousFunctionBody
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.anonymousFunctionBody.Initialized)
                {
                    this.anonymousFunctionBody.Value = null;

                    LambdaOperator lambda = this.FindFirstChild<LambdaOperator>();
                    if (lambda != null)
                    {
                        for (CodeUnit c = lambda.FindNextSibling<CodeUnit>(); c != null; c = c.FindNextSibling<CodeUnit>())
                        {
                            if (c.Is(CodeUnitType.Expression) || c.Is(CodeUnitType.Statement))
                            {
                                this.anonymousFunctionBody.Value = c;
                                break;
                            }
                            else if (!c.Is(CodeUnitType.LexicalElement) || c.Is(LexicalElementType.PreprocessorDirective) || c.Is(LexicalElementType.Token))
                            {
                                break;
                            }
                        }
                    }

                    if (this.anonymousFunctionBody.Value == null)
                    {
                        throw new SyntaxException(this.Document, this.LineNumber);
                    }
                }

                return this.anonymousFunctionBody.Value;
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

            this.anonymousFunctionBody.Reset();
        }

        #endregion Protected Override Methods
    }
}
