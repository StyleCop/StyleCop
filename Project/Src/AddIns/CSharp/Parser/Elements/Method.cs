//-----------------------------------------------------------------------
// <copyright file="ICodeUnit.cs" company="Microsoft">
//   Copyright (c) Microsoft Corporation.
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
namespace Microsoft.StyleCop.CSharp
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// Describes a method element.
    /// </summary>
    /// <subcategory>element</subcategory>
    public sealed class Method : Element, IParameterContainer, ITypeConstraintContainer
    {
        #region Private Fields

        /// <summary>
        /// The method's return type.
        /// </summary>
        private TypeToken returnType;

        /// <summary>
        /// The list if type constraints on the codeUnit, if any.
        /// </summary>
        private ICollection<TypeParameterConstraintClause> typeConstraints;

        /// <summary>
        /// Indicates whether this is an extension method. 
        /// </summary>
        private bool extensionMethod;

        /// <summary>
        /// The parameters within the methods formal parameter list.
        /// </summary>
        private IList<Parameter> parameters;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the Method class.
        /// </summary>
        /// <param name="proxy">Proxy object for the method.</param>
        /// <param name="name">The name of the method.</param>
        /// <param name="attributes">The list of attributes attached to this element.</param>
        /// <param name="returnType">The method's return type.</param>
        /// <param name="typeConstraints">The list of type constraints on the element.</param>
        /// <param name="unsafeCode">Indicates whether the element resides within a block of unsafe code.</param>
        internal Method(CodeUnitProxy proxy, string name, ICollection<Attribute> attributes, TypeToken returnType, ICollection<TypeParameterConstraintClause> typeConstraints, bool unsafeCode)
            : base(proxy, ElementType.Method, name, attributes, unsafeCode)
        {
            Param.AssertNotNull(proxy, "proxy");
            Param.AssertValidString(name, "name");
            Param.Ignore(attributes);
            Param.Ignore(returnType);
            Param.Ignore(typeConstraints);
            Param.Ignore(unsafeCode);

            Debug.Assert(
                returnType != null || this.ContainsModifier(TokenType.Explicit, TokenType.Implicit),
                "A method's return type can only be null in an explicit or implicit operator overload method.");

            this.returnType = returnType;
            this.typeConstraints = typeConstraints;

            // Determine whether this is an extension method. The method must be static.
            if (this.Parameters.Count > 0 && this.ContainsModifier(TokenType.Static))
            {
                // Look at this first parameter. 
                if ((this.Parameters[0].Modifiers & ParameterModifiers.This) != 0)
                {
                    this.extensionMethod = true;
                }
            }

            // If this is an explicit interface member implementation and our access modifier
            // is currently set to private because we don't have one, then it should be public instead.
            if (name.IndexOf(".", StringComparison.Ordinal) > -1 && !name.StartsWith("this.", StringComparison.Ordinal))
            {
                this.AccessLevel = AccessModifierType.Public;
            }
        }

        #endregion Internal Constructors

        #region Public Override Properties

        /// <summary>
        /// Gets the fully qualified name of the element.
        /// </summary>
        public override string FullyQualifiedName
        {
            get
            {
                return CodeParser.AddQualifications(this.Parameters, base.FullyQualifiedName);
            }
        }

        #endregion Public Override Properties

        #region Public Properties

        /// <summary>
        /// Gets the method's return type.
        /// </summary>
        public TypeToken ReturnType
        {
            get
            {
                return this.returnType;
            }
        }

        /// <summary>
        /// Gets the list of input parameters in the method's declaration.
        /// </summary>
        public IList<Parameter> Parameters
        {
            get
            {
                if (this.parameters == null)
                {
                    this.parameters = this.CollectFormalParameters(this.FirstDeclarationToken, TokenType.CloseParenthesis);
                }

                return this.parameters;
            }
        }

        /// <summary>
        /// Gets the list of type constraints on the method, if any.
        /// </summary>
        public ICollection<TypeParameterConstraintClause> TypeConstraints
        {
            get
            {
                return this.typeConstraints;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this is an extension method. 
        /// </summary>
        public bool IsExtensionMethod
        {
            get
            {
                return this.extensionMethod;
            }
        }

        #endregion Public Properties

        #region Protected Override Properties

        /// <summary>
        /// Gets the collection of modifiers allowed on this element.
        /// </summary>
        protected override IEnumerable<string> AllowedModifiers
        {
            get
            {
                return CodeParser.MethodModifiers;
            }
        }

        #endregion Protected Override Properties

        #region Public Override Methods

        /// <summary>
        /// Gets the variables defined within this element.
        /// </summary>
        /// <returns>Returns the collection of variables.</returns>
        public override IVariable[] GetVariables()
        {
            return GatherVariablesForElementWithParametersAndChildStatements(this, this.Parameters);
        }

        #endregion Public Override Methods

        #region Internal Static Methods

        /// <summary>
        /// Gets the variables defined by an element with parameters and child statements, such as a method or a constructor.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="parameters">The element's parameters.</param>
        /// <returns>Returns the variables.</returns>
        internal static IVariable[] GatherVariablesForElementWithParametersAndChildStatements(Element element, IList<Parameter> parameters)
        {
            Param.AssertNotNull(element, "element");
            Param.Ignore(parameters);

            var variables = new List<IVariable>();

            if (parameters != null && parameters.Count > 0)
            {
                for (int i = 0; i < parameters.Count; ++i)
                {
                    variables.Add(parameters[i]);
                }
            }

            for (VariableDeclarationStatement variableStatement = element.FindFirstChild<VariableDeclarationStatement>();
                variableStatement != null;
                variableStatement = variableStatement.FindNextSibling<VariableDeclarationStatement>())
            {
                variables.AddRange(variableStatement.GetVariables());
            }

            return variables.Count > 0 ? variables.ToArray() : null;
        }

        #endregion Internal Static Methods
    }
}
