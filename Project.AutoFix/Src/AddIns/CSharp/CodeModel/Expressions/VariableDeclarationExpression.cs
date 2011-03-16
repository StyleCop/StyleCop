//-----------------------------------------------------------------------
// <copyright file="VariableDeclarationExpression.cs">
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
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// An expression declaring a new variable.
    /// </summary>
    /// <subcategory>expression</subcategory>
    public sealed class VariableDeclarationExpression : Expression
    {
        #region Private Fields

        /// <summary>
        /// The type of the variable being declared.
        /// </summary>
        private CodeUnitProperty<TypeToken> type;

        /// <summary>
        /// The declarators in the expression.
        /// </summary>
        private CodeUnitProperty<ICollection<VariableDeclaratorExpression>> declarators;

        /// <summary>
        /// The variables defined within the expression.
        /// </summary>
        private CodeUnitProperty<VariableCollection> variables;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the VariableDeclarationExpression class.
        /// </summary>
        /// <param name="proxy">Proxy object for the expression.</param>
        /// <param name="type">The type of the variable or variables being declared.</param>
        /// <param name="declarators">The collection of declarators on the expression.</param>
        internal VariableDeclarationExpression(CodeUnitProxy proxy, LiteralExpression type, ICollection<VariableDeclaratorExpression> declarators = null)
            : base(proxy, ExpressionType.VariableDeclaration)
        {
            Param.AssertNotNull(proxy, "proxy");
            Param.AssertNotNull(type, "type");
            Param.Ignore(declarators);

            this.type.Value = CodeParser.ExtractTypeTokenFromLiteralExpression(type);

            if (declarators != null && declarators.Count > 0)
            {
                this.declarators.Value = new List<VariableDeclaratorExpression>(declarators);
            }
        }

        #endregion Internal Constructors

        #region Public Properties

        /// <summary>
        /// Gets the variables defined within this expression.
        /// </summary>
        /// <returns>Returns the collection of variables.</returns>
        public override VariableCollection Variables
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.variables.Initialized)
                {
                    this.variables.Value = new VariableCollection();
                    if (this.Declarators != null)
                    {
                        this.variables.Value.AddRange(this.Declarators);
                    }
                }

                return this.variables.Value;
            }
        }

        /// <summary>
        /// Gets the type of the variable.
        /// </summary>
        [SuppressMessage(
            "Microsoft.Naming",
            "CA1721:PropertyNamesShouldNotMatchGetMethods",
            Justification = "API has already been published and should not be changed.")]
        public TypeToken Type
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.type.Initialized)
                {
                    this.type.Value = null;

                    for (CodeUnit c = this.FindFirstChild(); c != null; c = c.FindNextSibling())
                    {
                        if (c.Is(ExpressionType.Literal))
                        {
                            LiteralExpression literal = (LiteralExpression)c;
                            if (literal.Token != null && literal.Token.Is(TokenType.Type))
                            {
                                this.type.Value = (TypeToken)literal.Token;
                                break;
                            }
                        }
                        else if (c.Is(ExpressionType.VariableDeclarator))
                        {
                            break;
                        }
                    }

                    if (this.type.Value == null)
                    {
                        throw new SyntaxException(this.Document, this.LineNumber);
                    }
                }

                return this.type.Value;
            }
        }

        /// <summary>
        /// Gets the list of declarators for the expression.
        /// </summary>
        public ICollection<VariableDeclaratorExpression> Declarators
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.declarators.Initialized)
                {
                    this.declarators.Value = new List<VariableDeclaratorExpression>(this.GetChildren<VariableDeclaratorExpression>()).AsReadOnly();
                }

                return this.declarators.Value;
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

            this.declarators.Reset();
            this.variables.Reset();
        }

        #endregion Protected Override Methods
    }
}
