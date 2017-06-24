// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CatchStatement.cs" company="https://github.com/StyleCop">
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
//   A catch-statement.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    /// <summary>
    /// A catch-statement.
    /// </summary>
    /// <subcategory>statement</subcategory>
    public sealed class CatchStatement : Statement
    {
        #region Fields

        /// <summary>
        /// The inner expression.
        /// </summary>
        private readonly Expression catchExpression;

        /// <summary>
        /// The class type of the exception being caught.
        /// </summary>
        private readonly TypeToken classType;

        /// <summary>
        /// The statement embedded within the catch-statement.
        /// </summary>
        private readonly BlockStatement embeddedStatement;

        /// <summary>
        /// The when statement.
        /// </summary>
        private readonly WhenStatement whenStatement;

        /// <summary>
        /// The exception variable identifier.
        /// </summary>
        private readonly LiteralExpression identifier;

        /// <summary>
        /// The try-statement that this catch-statement is attached to.
        /// </summary>
        private readonly TryStatement tryStatement;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the CatchStatement class.
        /// </summary>
        /// <param name="tokens">The list of tokens that form the statement.</param>
        /// <param name="tryStatement">The try-statement that this catch-statement is attached to.</param>
        /// <param name="classExpression">The inner expression.</param>
        /// <param name="embeddedStatement">The statement embedded within the catch-statement.</param>
        /// <param name="whenStatement">The when statement.</param>
        internal CatchStatement(CsTokenList tokens, TryStatement tryStatement, Expression classExpression, BlockStatement embeddedStatement, WhenStatement whenStatement)
            : base(StatementType.Catch, tokens)
        {
            Param.AssertNotNull(tokens, "tokens");
            Param.AssertNotNull(tryStatement, "tryStatement");
            Param.Ignore(classExpression);
            Param.AssertNotNull(embeddedStatement, "embeddedStatement");
            Param.Ignore(whenStatement); // When statement can be null and not found for a try catch.

            this.tryStatement = tryStatement;
            this.catchExpression = classExpression;
            this.embeddedStatement = embeddedStatement;
            this.whenStatement = whenStatement;

            if (classExpression != null)
            {
                this.AddExpression(classExpression);

                if (classExpression != null)
                {
                    if (classExpression.ExpressionType == ExpressionType.Literal)
                    {
                        this.classType = ((LiteralExpression)classExpression).Token as TypeToken;
                    }
                    else if (classExpression.ExpressionType == ExpressionType.VariableDeclaration)
                    {
                        VariableDeclarationExpression variableDeclaration = (VariableDeclarationExpression)classExpression;

                        this.classType = variableDeclaration.Type;

                        foreach (VariableDeclaratorExpression declarator in variableDeclaration.Declarators)
                        {
                            this.identifier = declarator.Identifier;
                            break;
                        }
                    }
                }
            }

            if (whenStatement != null)
            {
                this.AddStatement(whenStatement);
            }

            this.AddStatement(embeddedStatement);
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the expression within the catch statement.
        /// </summary>
        public Expression CatchExpression
        {
            get
            {
                return this.catchExpression;
            }
        }

        /// <summary>
        /// Gets the class type of the exception being caught.
        /// </summary>
        public TypeToken ClassType
        {
            get
            {
                return this.classType;
            }
        }

        /// <summary>
        /// Gets the statement embedded within the catch-statement.
        /// </summary>
        public BlockStatement EmbeddedStatement
        {
            get
            {
                return this.embeddedStatement;
            }
        }

        /// <summary>
        /// Gets the exception variable identifier.
        /// </summary>
        public CsToken Identifier
        {
            get
            {
                return this.identifier == null ? null : this.identifier.Token;
            }
        }

        /// <summary>
        /// Gets the try-statement that this catch-statement is attached to.
        /// </summary>
        public TryStatement TryStatement
        {
            get
            {
                return this.tryStatement;
            }
        }

        /// <summary>
        /// Gets the when statement to filter a catch expression introduced in C# 6.
        /// </summary>
        public WhenStatement WhenStatement
        {
            get
            {
                return this.whenStatement;
            }
        }

        #endregion
    }
}