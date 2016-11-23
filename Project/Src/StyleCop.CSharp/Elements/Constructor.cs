// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Constructor.cs" company="https://github.com/StyleCop">
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
//   Describes a class constructor..
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// Describes a class constructor..
    /// </summary>
    /// <subcategory>element</subcategory>
    public sealed class Constructor : CsElement, IParameterContainer
    {
        #region Fields

        /// <summary>
        /// The constructor's class initializer.
        /// </summary>
        private readonly MethodInvocationExpression initializer;

        /// <summary>
        /// The constructor's input parameters.
        /// </summary>
        private readonly IList<Parameter> parameters;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the Constructor class.
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
        /// <param name="parameters">
        /// The parameters to the constructor.
        /// </param>
        /// <param name="initializerExpression">
        /// The constructor initializer, if there is one.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the element resides within a block of unsafe code.
        /// </param>
        /// <param name="generated">
        /// Indicates whether the code element was generated or written by hand.
        /// </param>
        internal Constructor(
            CsDocument document, 
            CsElement parent, 
            XmlHeader header, 
            ICollection<Attribute> attributes, 
            Declaration declaration, 
            IList<Parameter> parameters, 
            MethodInvocationExpression initializerExpression, 
            bool unsafeCode, 
            bool generated)
            : base(document, parent, ElementType.Constructor, "constructor " + declaration.Name, header, attributes, declaration, unsafeCode, generated)
        {
            Param.AssertNotNull(document, "document");
            Param.AssertNotNull(parent, "parent");
            Param.Ignore(header);
            Param.Ignore(attributes);
            Param.AssertNotNull(declaration, "declaration");
            Param.AssertNotNull(parameters, "parameters");
            Param.Ignore(initializerExpression);
            Param.Ignore(unsafeCode);
            Param.Ignore(generated);

            // Static constructors are treated as private and handled as a special case for ordering.
            if (this.Declaration.ContainsModifier(CsTokenType.Static))
            {
                this.Declaration.AccessModifierType = AccessModifierType.Private;
            }

            this.parameters = parameters;
            Debug.Assert(parameters.IsReadOnly, "The parameters collection should be read-only.");

            // Add the qualifications
            this.QualifiedName = CodeParser.AddQualifications(this.parameters, this.QualifiedName);

            // If there is an initializer expression, add it to the statement list for this constructor.
            if (initializerExpression != null)
            {
                this.initializer = initializerExpression;

                ConstructorInitializerStatement initializerStatement = new ConstructorInitializerStatement(initializerExpression.Tokens, initializerExpression);
                this.AddStatement(initializerStatement);
            }
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the class initializer for the constructor, if any.
        /// </summary>
        public MethodInvocationExpression Initializer
        {
            get
            {
                return this.initializer;
            }
        }

        /// <summary>
        /// Gets the list of input parameters in the constructor's declaration.
        /// </summary>
        public IList<Parameter> Parameters
        {
            get
            {
                return this.parameters;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Initializes the contents of the constructor.
        /// </summary>
        internal override void Initialize()
        {
            if (this.parameters != null)
            {
                // Create a variable for each of the parameters.
                Reference<ICodePart> constructorReference = new Reference<ICodePart>(this);
                foreach (Parameter parameter in this.parameters)
                {
                    this.Variables.Add(
                        new Variable(parameter.Type, parameter.Name, VariableModifiers.None, parameter.Location, constructorReference, parameter.Generated));
                }
            }
        }

        #endregion
    }
}