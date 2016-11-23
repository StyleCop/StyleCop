// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Delegate.cs" company="https://github.com/StyleCop">
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
//   Describes a delegate element.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Describes a delegate element.
    /// </summary>
    /// <subcategory>element</subcategory>
    [SuppressMessage("Microsoft.Naming", "CA1716:IdentifiersShouldNotMatchKeywords", Justification = "The class describes a C# delegate.")]
    [SuppressMessage("Microsoft.Naming", "CA1711:IdentifiersShouldNotHaveIncorrectSuffix", Justification = "The class should not have any suffix.")]
    public sealed class Delegate : CsElement, IParameterContainer, ITypeConstraintContainer
    {
        #region Fields

        /// <summary>
        /// The delegate's input parameters.
        /// </summary>
        private readonly IList<Parameter> parameters;

        /// <summary>
        /// The delegate's return type.
        /// </summary>
        private readonly TypeToken returnType;

        /// <summary>
        /// The list if type constraints on the item, if any.
        /// </summary>
        private readonly ICollection<TypeParameterConstraintClause> typeConstraints;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the Delegate class.
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
        /// The return type.
        /// </param>
        /// <param name="parameters">
        /// The parameters to the delegate.
        /// </param>
        /// <param name="typeConstraints">
        /// The list of type constraints on the element.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the element resides within a block of unsafe code.
        /// </param>
        /// <param name="generated">
        /// Indicates whether this is generated code.
        /// </param>
        internal Delegate(
            CsDocument document, 
            CsElement parent, 
            XmlHeader header, 
            ICollection<Attribute> attributes, 
            Declaration declaration, 
            TypeToken returnType, 
            IList<Parameter> parameters, 
            ICollection<TypeParameterConstraintClause> typeConstraints, 
            bool unsafeCode, 
            bool generated)
            : base(document, parent, ElementType.Delegate, "delegate " + declaration.Name, header, attributes, declaration, unsafeCode, generated)
        {
            Param.AssertNotNull(document, "document");
            Param.AssertNotNull(parent, "parent");
            Param.Ignore(header);
            Param.Ignore(attributes);
            Param.AssertNotNull(declaration, "declaration");
            Param.AssertNotNull(returnType, "returnType");
            Param.AssertNotNull(parameters, "parameters");
            Param.Ignore(typeConstraints);
            Param.Ignore(unsafeCode);
            Param.Ignore(generated);

            this.returnType = returnType;
            this.typeConstraints = typeConstraints;
            this.parameters = parameters;

            Debug.Assert(parameters.IsReadOnly, "The parameters collection should be read-only.");

            // Add the qualifications
            this.QualifiedName = CodeParser.AddQualifications(this.parameters, this.QualifiedName);

            // Set the parent of the type constraint clauses.
            if (typeConstraints != null)
            {
                Debug.Assert(typeConstraints.IsReadOnly, "The collection of type constraints should be read-only.");

                foreach (TypeParameterConstraintClause constraint in typeConstraints)
                {
                    constraint.ParentElement = this;
                }
            }
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the list of input parameters in the delegate's declaration.
        /// </summary>
        public IList<Parameter> Parameters
        {
            get
            {
                return this.parameters;
            }
        }

        /// <summary>
        /// Gets the delegate's return type.
        /// </summary>
        public TypeToken ReturnType
        {
            get
            {
                return this.returnType;
            }
        }

        /// <summary>
        /// Gets the list of type constraints on the delegate, if any.
        /// </summary>
        public ICollection<TypeParameterConstraintClause> TypeConstraints
        {
            get
            {
                return this.typeConstraints;
            }
        }

        #endregion
    }
}