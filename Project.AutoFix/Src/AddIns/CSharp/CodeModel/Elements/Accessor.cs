//-----------------------------------------------------------------------
// <copyright file="Accessor.cs">
//   MS-PL
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
    using System.Collections.Generic;

    /// <summary>
    /// Describes an accessor within a property, indexer, or event.
    /// </summary>
    /// <subcategory>element</subcategory>
    public class Accessor : Element
    {
        #region Private Fields

        /// <summary>
        /// The variables on the accessor.
        /// </summary>
        private CodeUnitProperty<VariableCollection> variables;

        /// <summary>
        /// The return type for the accessor.
        /// </summary>
        private CodeUnitProperty<TypeToken> returnType;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the Accessor class.
        /// </summary>
        /// <param name="proxy">Proxy object for the accessor.</param>
        /// <param name="name">The name of the accessor.</param>
        /// <param name="accessorType">The type of the accessor.</param>
        /// <param name="unsafeCode">Indicates whether the element resides within a block of unsafe code.</param>
        internal Accessor(CodeUnitProxy proxy, string name, AccessorType accessorType, bool unsafeCode)
            : base(proxy, (int)accessorType, name, null, unsafeCode)
        {
            Param.AssertNotNull(proxy, "proxy");
            Param.AssertValidString(name, "name");
            Param.Ignore(accessorType);
            Param.Ignore(unsafeCode);

            // Make sure the type and name match.
            CsLanguageService.Debug.Assert(
                (accessorType == AccessorType.Get && name == "get") ||
                (accessorType == AccessorType.Set && name == "set") ||
                (accessorType == AccessorType.Add && name == "add") ||
                (accessorType == AccessorType.Remove && name == "remove"),
                "The accessor type does not match its name.");
        }

        #endregion Internal Constructors

        #region Public Override Properties

        /// <summary>
        /// Gets the variables defined within this element.
        /// </summary>
        /// <returns>Returns the collection of variables.</returns>
        public override VariableCollection Variables
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.variables.Initialized)
                {
                    var vars = new VariableCollection();

                    AccessorType accessorType = this.AccessorType;
                    if (accessorType == AccessorType.Set ||
                        accessorType == AccessorType.Add ||
                        accessorType == AccessorType.Remove)
                    {
                        vars.Add(new VirtualAccessorParameter(this));
                    }

                    for (VariableDeclarationStatement variableStatement = this.FindFirstChild<VariableDeclarationStatement>();
                        variableStatement != null;
                        variableStatement = variableStatement.FindNextSibling<VariableDeclarationStatement>())
                    {
                        vars.AddRange(variableStatement.Variables);
                    }

                    this.variables.Value = vars;
                }

                return this.variables.Value;
            }
        }

        #endregion Public Override Properties

        #region Public Properties

        /// <summary>
        /// Gets the type of the accessor.
        /// </summary>
        public AccessorType AccessorType
        {
            get
            {
                return (AccessorType)(this.FundamentalType & (int)FundamentalTypeMasks.Accessor);
            }
        }

        /// <summary>
        /// Gets the accessor's return type.
        /// </summary>
        public TypeToken ReturnType
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.returnType.Initialized)
                {
                    // Set the return type and parameters.
                    if (this.AccessorType == AccessorType.Get)
                    {
                        Element parent = this.FindParentElement();
                        if (parent != null)
                        {
                            Property property = parent as Property;
                            if (property != null)
                            {
                                // Get accessors on properties have the return type of their parent property, 
                                // and have no input parameters.
                                this.returnType.Value = property.ReturnType;
                            }
                            else
                            {
                                // Get accessors on indexers have the return type of their parent indexer, 
                                // and have the input parameters of the parent indexer.
                                Indexer indexer = (Indexer)parent;
                                this.returnType.Value = indexer.ReturnType;
                            }
                        }
                    }

                    // Set accessors do not have a return type.
                    this.returnType.Value = this.CreateVoidTypeToken(this.Document);
                }

                return this.returnType.Value;
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
                return new string[] { };
            }
        }

        #endregion Protected Override Properties

        #region Protected Override Methods

        /// <summary>
        /// Gets the name of the element.
        /// </summary>
        /// <returns>The name of the element.</returns>
        protected override string GetElementName()
        {
            Token nameToken = null;
            switch (this.AccessorType)
            {
                case AccessorType.Set:
                    nameToken = this.FindFirstChild<SetToken>();
                    break;
                case AccessorType.Add:
                    nameToken = this.FindFirstChild<AddToken>();
                    break;
                case AccessorType.Remove:
                    nameToken = this.FindFirstChild<RemoveToken>();
                    break;
                default:
                    CsLanguageService.Debug.Assert(this.AccessorType == AccessorType.Get, "Invalid accessor type");
                    nameToken = this.FindFirstChild<GetToken>();
                    break;
            }

            if (nameToken == null)
            {
                throw new SyntaxException(this.Document, this.LineNumber);
            }

            return nameToken.Text;
        }

        #endregion Protected Override Methods

        #region Protected Override Methods

        /// <summary>
        /// Resets the contents of the class.
        /// </summary>
        protected override void Reset()
        {
            base.Reset();

            this.variables.Reset();
            this.returnType.Reset();
        }

        #endregion Protected Override Methods

        #region Private Methods

        /// <summary>
        /// Creates a TypeToken of type void.
        /// </summary>
        /// <param name="document">The parent document.</param>
        /// <returns>Returns the token.</returns>
        private TypeToken CreateVoidTypeToken(CsDocument document)
        {
            Param.AssertNotNull(document, "document");

            var tokenProxy = new CodeUnitProxy(document);
            tokenProxy.Children.Add(new LiteralToken(document, "void", CodeLocation.Empty, this.Generated));
            
            return new TypeToken(tokenProxy);
        }

        #endregion Private Methods

        #region Private Classes

        /// <summary>
        /// Represents a virtual parameter for certain accessor types.
        /// </summary>
        private class VirtualAccessorParameter : IVariable
        {
            /// <summary>
            /// The parent accessor.
            /// </summary>
            private Accessor parentAccessor;

            /// <summary>
            /// Tnhe type of the variable.
            /// </summary>
            private CodeUnitProperty<TypeToken> variableType;

            /// <summary>
            /// Initializes a new instance of the VirtualAccessorParameter class.
            /// </summary>
            /// <param name="parentAccessor">The parent accessor.</param>
            public VirtualAccessorParameter(Accessor parentAccessor)
            {
                Param.AssertNotNull(parentAccessor, "parentAccessor");
                this.parentAccessor = parentAccessor;
            }

            /// <summary>
            /// Gets the variable name.
            /// </summary>
            public string VariableName
            {
                get
                {
                    return "value";
                }
            }
            
            /// <summary>
            /// Gets the variable type.
            /// </summary>
            public TypeToken VariableType
            {
                get
                {
                    if (!this.variableType.Initialized)
                    {
                        if (this.parentAccessor.AccessorType == AccessorType.Add ||
                            this.parentAccessor.AccessorType == AccessorType.Remove)
                        {
                            this.variableType.Value = ((Event)this.parentAccessor.FindParentElement()).EventHandlerType;
                        }
                        else if (this.parentAccessor.AccessorType == AccessorType.Set)
                        {
                            this.variableType.Value = ((Property)this.parentAccessor.FindParentElement()).ReturnType;
                        }
                        else
                        {
                            CsLanguageService.Debug.Fail("Invalid accessor type.");
                            this.variableType.Value = null;
                        }
                    }

                    return this.variableType.Value;
                }
            }

            /// <summary>
            /// Gets the modifiers applied to this variable.
            /// </summary>
            public VariableModifiers VariableModifiers
            {
                get
                {
                    return VariableModifiers.None;
                }
            }

            /// <summary>
            /// Gets the location of the variable.
            /// </summary>
            public CodeLocation Location
            {
                get
                {
                    return this.parentAccessor.Location;
                }
            }

            /// <summary>
            /// Gets a value indicating whether the variable is located within a block of generated code.
            /// </summary>
            public bool Generated
            {
                get
                {
                    return this.parentAccessor.Generated;
                }
            }
        }

        #endregion Private Classes
    }
}