// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IWriteableCodeUnit.cs" company="https://github.com/StyleCop">
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
//   An interface implemented by all types that describe a unit of code.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    using System.Collections.Generic;

    /// <summary>
    /// An interface implemented by all types that describe a unit of code.
    /// </summary>
    internal interface IWriteableCodeUnit : ICodeUnit
    {
        #region Public Methods and Operators

        /// <summary>
        /// Adds a child expression.
        /// </summary>
        /// <param name="expression">
        /// The expression to add.
        /// </param>
        void AddExpression(Expression expression);

        /// <summary>
        /// Adds a range of child expressions.
        /// </summary>
        /// <param name="expressions">
        /// The expressions to add.
        /// </param>
        void AddExpressions(IEnumerable<Expression> expressions);

        /// <summary>
        /// Adds a child statement.
        /// </summary>
        /// <param name="statement">
        /// The statement to add.
        /// </param>
        void AddStatement(Statement statement);

        /// <summary>
        /// Adds a range of child statements.
        /// </summary>
        /// <param name="statements">
        /// The statements to add.
        /// </param>
        void AddStatements(IEnumerable<Statement> statements);

        /// <summary>
        /// Sets the parent of this code unit.
        /// </summary>
        /// <param name="parent">
        /// The parent of the code unit.
        /// </param>
        void SetParent(ICodePart parent);

        #endregion
    }
}