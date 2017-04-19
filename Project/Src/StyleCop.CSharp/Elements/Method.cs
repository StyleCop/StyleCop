// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Method.cs" company="https://github.com/StyleCop">
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
//   Describes a method element.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// Describes a method element.
    /// </summary>
    /// <subcategory>element</subcategory>
    public sealed class Method : CsElement, IParameterContainer, ITypeConstraintContainer
    {
        #region Fields

        /// <summary>
        /// Indicates whether this is an extension method. 
        /// </summary>
        private readonly bool extensionMethod;

        /// <summary>
        /// The method's input parameters.
        /// </summary>
        private readonly IList<Parameter> parameters;

        /// <summary>
        /// The method's return type.
        /// </summary>
        private readonly TypeToken returnType;

        /// <summary>
        /// The method's return type is ref.
        /// </summary>
        private readonly bool returnTypeIsRef;

        /// <summary>
        /// The list if type constraints on the item, if any.
        /// </summary>
        private readonly ICollection<TypeParameterConstraintClause> typeConstraints;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the Method class.
        /// </summary>
        /// <param name="document">
        /// The document that contains the element.
        /// </param>
        /// <param name="parent">
        /// The parent of the element.
        /// </param>
        /// <param name="header">
        /// The Xml header for this element.
        /// </param>
        /// <param name="attributes">
        /// The list of attributes attached to this element.
        /// </param>
        /// <param name="declaration">
        /// The declaration code for this element.
        /// </param>
        /// <param name="returnType">
        /// The method's return type.
        /// </param>
        /// <param name="returnTypeIsRef">
        /// The method's return type is ref.
        /// </param>
        /// <param name="parameters">
        /// The parameters to the method.
        /// </param>
        /// <param name="typeConstraints">
        /// The list of type constraints on the element.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the element resides within a block of unsafe code.
        /// </param>
        /// <param name="generated">
        /// Indicates whether the code element was generated or written by hand.
        /// </param>
        internal Method(
            CsDocument document, 
            CsElement parent, 
            XmlHeader header, 
            ICollection<Attribute> attributes, 
            Declaration declaration, 
            TypeToken returnType, 
            bool returnTypeIsRef,
            IList<Parameter> parameters, 
            ICollection<TypeParameterConstraintClause> typeConstraints, 
            bool unsafeCode, 
            bool generated)
            : base(document, parent, ElementType.Method, "method " + declaration.Name, header, attributes, declaration, unsafeCode, generated)
        {
            Param.AssertNotNull(document, "document");
            Param.AssertNotNull(parent, "parent");
            Param.Ignore(header);
            Param.Ignore(attributes);
            Param.AssertNotNull(declaration, "declaration");
            Param.Ignore(returnType);
            Param.Ignore(returnTypeIsRef);
            Param.AssertNotNull(parameters, "parameters");
            Param.Ignore(typeConstraints);
            Param.Ignore(unsafeCode);
            Param.Ignore(generated);

            Debug.Assert(
                returnType != null || declaration.ContainsModifier(CsTokenType.Explicit, CsTokenType.Implicit), 
                "A method's return type can only be null in an explicit or implicit operator overload method.");

            this.returnType = returnType;
            this.returnTypeIsRef = returnTypeIsRef;
            this.parameters = parameters;
            this.typeConstraints = typeConstraints;

            Debug.Assert(parameters.IsReadOnly, "The parameters collection should be read-only.");

            // Determine whether this is an extension method. The method must be static.
            if (this.parameters.Count > 0 && this.Declaration.ContainsModifier(CsTokenType.Static))
            {
                // Look at this first parameter. Since the parameters collection is not an indexable list, the 
                // easiest way to do this is to foreach through the parameter list and break after the first one.
                foreach (Parameter parameter in this.parameters)
                {
                    if ((parameter.Modifiers & ParameterModifiers.This) != 0)
                    {
                        this.extensionMethod = true;
                    }

                    break;
                }
            }

            // Add the qualifications.
            this.QualifiedName = CodeParser.AddQualifications(this.parameters, this.QualifiedName);

            // If this is an explicit interface member implementation and our access modifier
            // is currently set to private because we don't have one, then it should be public instead.
            if (this.Declaration.Name.IndexOf(".", StringComparison.Ordinal) > -1 && !this.Declaration.Name.StartsWith("this.", StringComparison.Ordinal))
            {
                this.Declaration.AccessModifierType = AccessModifierType.Public;
            }

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
        /// Gets a value indicating whether this is an extension method. 
        /// </summary>
        public bool IsExtensionMethod => this.extensionMethod;

        /// <summary>
        /// Gets the list of input parameters in the method's declaration.
        /// </summary>
        public IList<Parameter> Parameters => this.parameters;

        /// <summary>
        /// Gets the method's return type.
        /// </summary>
        public TypeToken ReturnType => this.returnType;

        /// <summary>
        /// Gets a value that indicates if the return type of the method is ref.
        /// </summary>
        public bool ReturnTypeIsRef => this.returnTypeIsRef;

        /// <summary>
        /// Gets the list of type constraints on the method, if any.
        /// </summary>
        public ICollection<TypeParameterConstraintClause> TypeConstraints => this.typeConstraints;

        #endregion

        #region Methods

        /// <summary>
        /// Initializes the method.
        /// </summary>
        internal override void Initialize()
        {
            base.Initialize();

            if (this.parameters != null)
            {
                Reference<ICodePart> methodReference = new Reference<ICodePart>(this);

                // Create a variable for each of the parameters.
                foreach (Parameter parameter in this.parameters)
                {
                    Variable variable = new Variable(parameter.Type, parameter.Name, VariableModifiers.None, parameter.Location, methodReference, parameter.Generated);

                    this.Variables.Add(variable);
                }
            }
        }

        #endregion
    }
}