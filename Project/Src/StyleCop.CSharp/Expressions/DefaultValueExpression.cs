// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultValueExpression.cs" company="https://github.com/StyleCop">
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
//   An expression representing a default value operation.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// An expression representing a default value operation.
    /// </summary>
    /// <subcategory>expression</subcategory>
    public sealed class DefaultValueExpression : Expression, ICodePart
    {
        #region Fields

        /// <summary>
        /// The parent of the parameter.
        /// </summary>
        private readonly Reference<ICodePart> parent;

        /// <summary>
        /// The type to obtain the default value of.
        /// </summary>
        private readonly TypeToken type;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the DefaultValueExpression class.
        /// </summary>
        /// <param name="tokens">
        /// The list of tokens that form the expression.
        /// </param>
        /// <param name="type">
        /// The type to obtain the default value of.
        /// </param>
        /// <param name="parent">
        /// The parent reference of this expression.
        /// </param>
        internal DefaultValueExpression(CsTokenList tokens, LiteralExpression type, Reference<ICodePart> parent)
            : base(ExpressionType.DefaultValue, tokens)
        {
            Param.AssertNotNull(tokens, "tokens");
            Param.Ignore(type);

            if (type != null)
            {
                this.type = CodeParser.ExtractTypeTokenFromLiteralExpression(type);
                this.AddExpression(type);
            }

            this.parent = parent;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the type to obtain the default value of.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1721:PropertyNamesShouldNotMatchGetMethods", Justification = "API has already been published and should not be changed.")]
        public TypeToken Type
        {
            get
            {
                return this.type;
            }
        }

        #endregion

        #region Explicit Interface Properties

        /// <summary>
        /// Gets the actual parent ICodePart of this expression. Normally a Parameter.
        /// </summary>
        ICodePart ICodePart.Parent
        {
            get
            {
                return this.parent.Target;
            }
        }

        #endregion
    }
}