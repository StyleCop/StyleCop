// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LocalFunctionStatement.cs" company="https://github.com/StyleCop">
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
//   Describes a local function statement.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    using System.Collections.Generic;

    /// <summary>
    /// A local function within a method element.
    /// </summary>
    /// <subcategory>statement</subcategory>
    public class LocalFunctionStatement : Statement, ITypeConstraintContainer
    {
        #region Fields

        /// <summary>
        /// The return type of this local function.
        /// </summary>
        private readonly TypeToken returnType;

        /// <summary>
        /// The return type of this local function is ref.
        /// </summary>
        private readonly bool returnTypeIsRef;

        /// <summary>
        /// The identifier of this local function.
        /// </summary>
        private readonly LiteralExpression identifier;

        /// <summary>
        /// The parameters to this local function.
        /// </summary>
        private readonly IList<Parameter> parameters;

        /// <summary>
        /// The list if type constraints on the item, if any.
        /// </summary>
        private readonly ICollection<TypeParameterConstraintClause> typeConstraints;
        
        /// <summary>
        /// The code unit that represents this local functions body.
        /// </summary>
        private readonly CodeUnit functionBody;

        #endregion
        
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the LocalFunctionStatement class.
        /// </summary>
        /// <param name="tokens">
        /// The list of tokens that form the statement.
        /// </param>
        /// <param name="returnType">
        /// The return type of this local function.
        /// </param>
        /// <param name="returnTypeIsRef">
        /// The return type of this local function is ref.
        /// </param>
        /// <param name="identifier">
        /// The identifier of this local function.
        /// </param>
        /// <param name="parameters">
        /// The parameter information of this local function.
        /// </param>
        /// <param name="typeConstraints">
        /// The list of type constraints on the element.
        /// </param>
        /// <param name="functionBodyExpression">
        /// An expression that represents the body of this local function.
        /// </param>
        internal LocalFunctionStatement(
            CsTokenList tokens, 
            TypeToken returnType, 
            bool returnTypeIsRef, 
            LiteralExpression identifier, 
            IList<Parameter> parameters,
            ICollection<TypeParameterConstraintClause> typeConstraints, 
            Expression functionBodyExpression)
            : this(tokens, returnType, returnTypeIsRef, identifier, parameters, typeConstraints)
        {
            Param.AssertNotNull(functionBodyExpression, nameof(functionBodyExpression));
            this.functionBody = functionBodyExpression;
            this.AddExpression(functionBodyExpression);
        }

        /// <summary>
        /// Initializes a new instance of the LocalFunctionStatement class.
        /// </summary>
        /// <param name="tokens">
        /// The list of tokens that form the statement.
        /// </param>
        /// <param name="returnType">
        /// The return type of this local function.
        /// </param>
        /// <param name="returnTypeIsRef">
        /// The return type of this local function is ref.
        /// </param>
        /// <param name="identifier">
        /// The identifier of this local function.
        /// </param>
        /// <param name="parameters">
        /// The parameter information of this local function.
        /// </param>
        /// <param name="typeConstraints">
        /// The list of type constraints on the element.
        /// </param>
        /// <param name="functionBody">
        /// An statement that represents the body of this local function.
        /// </param>
        internal LocalFunctionStatement(
            CsTokenList tokens, 
            TypeToken returnType, 
            bool returnTypeIsRef, 
            LiteralExpression identifier, 
            IList<Parameter> parameters,
            ICollection<TypeParameterConstraintClause> typeConstraints, 
            Statement functionBody)
            : this(tokens, returnType, returnTypeIsRef, identifier, parameters, typeConstraints)
        {
            Param.AssertNotNull(functionBody, nameof(functionBody));
            this.functionBody = functionBody;
            this.AddStatement(functionBody);
        }

        /// <summary>
        /// Initializes a new instance of the LocalFunctionStatement class.
        /// </summary>
        /// <param name="tokens">
        /// The list of tokens that form the statement.
        /// </param>
        /// <param name="returnType">
        /// The return type of this local function.
        /// </param>
        /// <param name="returnTypeIsRef">
        /// The return type of this local function is ref.
        /// </param>
        /// <param name="identifier">
        /// The identifier of this local function.
        /// </param>
        /// <param name="parameters">
        /// The parameter information of this local function.
        /// </param>
        /// <param name="typeConstraints">
        /// The list of type constraints on the element.
        /// </param>
        private LocalFunctionStatement(
            CsTokenList tokens, 
            TypeToken returnType, 
            bool returnTypeIsRef, 
            LiteralExpression identifier, 
            IList<Parameter> parameters,
            ICollection<TypeParameterConstraintClause> typeConstraints)
            : base(StatementType.LocalFunction, tokens)
        {
            Param.AssertNotNull(returnType, nameof(returnType));
            Param.Ignore(returnTypeIsRef);
            Param.AssertNotNull(identifier, nameof(identifier));
            Param.AssertNotNull(parameters, nameof(parameters));
            Param.Ignore(typeConstraints);

            this.returnType = returnType;
            this.returnTypeIsRef = returnTypeIsRef;
            this.identifier = identifier;
            this.parameters = parameters;
            this.typeConstraints = typeConstraints;

            this.AddExpression(this.identifier);

            // Set the parent of the type constraint clauses.
            if (typeConstraints != null)
            {
                foreach (TypeParameterConstraintClause constraint in typeConstraints)
                {
                    constraint.ParentElement = this;
                }
            }
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the return type of this local function.
        /// </summary>
        public TypeToken ReturnType => this.returnType;

        /// <summary>
        /// Gets a value that indicates if the return type of the local function is ref.
        /// </summary>
        public bool ReturnTypeIsRef => this.returnTypeIsRef;

        /// <summary>
        /// Gets the identifier of this local function.
        /// </summary>
        public LiteralExpression Identifier => this.identifier;

        /// <summary>
        /// Gets the parameters of this local function.
        /// </summary>
        public IList<Parameter> Parameters => this.parameters;

        /// <summary>
        /// Gets the expression or statement that represents the body of this local function.
        /// </summary>
        public CodeUnit FunctionBody => this.functionBody;

        /// <summary>
        /// Gets the list of type constraints on the element, if any.
        /// </summary>
        public ICollection<TypeParameterConstraintClause> TypeConstraints => this.typeConstraints;

        #endregion
    }
}
