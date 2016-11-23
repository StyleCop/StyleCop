// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Accessor.cs" company="https://github.com/StyleCop">
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
//   Describes an accessor within a property, indexer, or event.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Describes an accessor within a property, indexer, or event.
    /// </summary>
    /// <subcategory>element</subcategory>
    public sealed class Accessor : CsElement, IParameterContainer
    {
        #region Fields

        /// <summary>
        /// The type of the accessor.
        /// </summary>
        private readonly AccessorType accessorType;

        /// <summary>
        /// The input parameters.
        /// </summary>
        private IList<Parameter> parameters;

        /// <summary>
        /// The return type.
        /// </summary>
        private TypeToken returnType;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the Accessor class.
        /// </summary>
        /// <param name="document">
        /// The document that contains the element.
        /// </param>
        /// <param name="parent">
        /// The parent of the element.
        /// </param>
        /// <param name="accessorType">
        /// The type of the accessor.
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
        /// <param name="unsafeCode">
        /// Indicates whether the element resides within a block of unsafe code.
        /// </param>
        /// <param name="generated">
        /// Indicates whether the code element was generated or written by hand.
        /// </param>
        internal Accessor(
            CsDocument document, 
            CsElement parent, 
            AccessorType accessorType, 
            XmlHeader header, 
            ICollection<Attribute> attributes, 
            Declaration declaration, 
            bool unsafeCode, 
            bool generated)
            : base(document, parent, ElementType.Accessor, declaration.Name + " accessor", header, attributes, declaration, unsafeCode, generated)
        {
            Param.AssertNotNull(document, "document");
            Param.AssertNotNull(parent, "parent");
            Param.Ignore(accessorType);
            Param.Ignore(header);
            Param.Ignore(attributes);
            Param.AssertNotNull(declaration, "declaration");
            Param.Ignore(unsafeCode);
            Param.Ignore(generated);

            this.accessorType = accessorType;

            // Make sure the type and name match.
            Debug.Assert(
                (accessorType == AccessorType.Get && declaration.Name == "get") || (accessorType == AccessorType.Set && declaration.Name == "set")
                || (accessorType == AccessorType.Add && declaration.Name == "add") || (accessorType == AccessorType.Remove && declaration.Name == "remove"), 
                "The accessor type does not match its name.");

            this.FillDetails(parent);
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the type of the accessor.
        /// </summary>
        public AccessorType AccessorType
        {
            get
            {
                return this.accessorType;
            }
        }

        /// <summary>
        /// Gets the list of input parameters for the accessor.
        /// </summary>
        public IList<Parameter> Parameters
        {
            get
            {
                if (this.parameters == null)
                {
                    return Parameter.EmptyParameterArray;
                }

                return this.parameters;
            }
        }

        /// <summary>
        /// Gets the return type.
        /// </summary>
        public TypeToken ReturnType
        {
            get
            {
                return this.returnType;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Initializes the contents of the accessor.
        /// </summary>
        internal override void Initialize()
        {
            base.Initialize();

            if (this.parameters != null)
            {
                Reference<ICodePart> accessorReference = new Reference<ICodePart>(this);

                // Create a variable for each of the parameters.
                foreach (Parameter parameter in this.parameters)
                {
                    Variable variable = new Variable(parameter.Type, parameter.Name, VariableModifiers.None, parameter.Location, accessorReference, parameter.Generated);

                    this.Variables.Add(variable);
                }
            }
        }

        /// <summary>
        /// Creates a TypeToken of type void.
        /// </summary>
        /// <param name="parentReference">
        /// The parent code part.
        /// </param>
        /// <returns>
        /// Returns the token.
        /// </returns>
        [SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "*", 
            Justification = "void is a standard C# keyword")]
        private static TypeToken CreateVoidTypeToken(Reference<ICodePart> parentReference)
        {
            Param.AssertNotNull(parentReference, "parentReference");
            Reference<ICodePart> typeTokenReference = new Reference<ICodePart>();

            return
                new TypeToken(
                    new MasterList<CsToken>(new[] { new CsToken("void", CsTokenType.Other, CsTokenClass.Token, CodeLocation.Empty, typeTokenReference, false) }), 
                    CodeLocation.Empty, 
                    parentReference, 
                    false);
        }

        /// <summary>
        /// Fills in the details of the accessor based on its type.
        /// </summary>
        /// <param name="parent">
        /// The parent of the accessor.
        /// </param>
        private void FillDetails(CsElement parent)
        {
            Param.AssertNotNull(parent, "parent");

            // Set the return type and parameters.
            if (this.accessorType == AccessorType.Get)
            {
                this.FillGetAccessorDetails(parent);
            }
            else if (this.accessorType == AccessorType.Set)
            {
                this.FillSetAccessorDetails(parent);
            }
            else
            {
                // Add and remove accessors have no return type but have an implied
                // parameter based on the type of the event handler.
                Event parentEvent = (Event)parent;
                Reference<ICodePart> accessorReference = new Reference<ICodePart>(this);

                this.returnType = CreateVoidTypeToken(accessorReference);

                this.parameters = new[]
                                      {
                                          new Parameter(
                                              parentEvent.EventHandlerType, 
                                              "value", 
                                              accessorReference, 
                                              ParameterModifiers.None, 
                                              null, 
                                              CodeLocation.Empty, 
                                              null, 
                                              parentEvent.EventHandlerType.Generated)
                                      };
            }
        }

        /// <summary>
        /// Fills in the details of the get accessor.
        /// </summary>
        /// <param name="parent">
        /// The parent of the accessor.
        /// </param>
        private void FillGetAccessorDetails(CsElement parent)
        {
            Param.AssertNotNull(parent, "parent");

            Property property = parent as Property;
            if (property != null)
            {
                // Get accessors on properties have the return type of their parent property, 
                // and have no input parameters.
                this.returnType = property.ReturnType;
            }
            else
            {
                // Get accessors on indexers have the return type of their parent indexer, 
                // and have the input parameters of the parent indexer.
                Indexer indexer = (Indexer)parent;

                this.returnType = indexer.ReturnType;
                this.parameters = indexer.Parameters;
            }
        }

        /// <summary>
        /// Fills in the details of the set accessor.
        /// </summary>
        /// <param name="parent">
        /// The parent of the accessor.
        /// </param>
        private void FillSetAccessorDetails(CsElement parent)
        {
            Param.AssertNotNull(parent, "parent");

            Reference<ICodePart> accessorReference = new Reference<ICodePart>(this);

            Property property = parent as Property;
            if (property != null)
            {
                // Set accessors on properties do not have a return type but have an 
                // implied input parameter.
                this.returnType = CreateVoidTypeToken(accessorReference);

                this.parameters = new[]
                                      {
                                          new Parameter(
                                              property.ReturnType, 
                                              "value", 
                                              accessorReference, 
                                              ParameterModifiers.None, 
                                              null, 
                                              CodeLocation.Empty, 
                                              null, 
                                              property.ReturnType.Generated)
                                      };
            }
            else
            {
                // Set accessors on indexers do not have a return type but, but have the input
                // parameters of the parent indexer.
                Indexer indexer = (Indexer)parent;

                this.returnType = CreateVoidTypeToken(accessorReference);

                Parameter[] tempParameters = new Parameter[indexer.Parameters.Count + 1];
                int i = 0;
                foreach (Parameter parameter in indexer.Parameters)
                {
                    tempParameters[i++] = parameter;
                }

                // Add the implicit value parameter since this is a set accessor.
                tempParameters[i] = new Parameter(
                    indexer.ReturnType, "value", accessorReference, ParameterModifiers.None, null, CodeLocation.Empty, null, indexer.ReturnType.Generated);

                this.parameters = tempParameters;
            }
        }

        #endregion
    }
}