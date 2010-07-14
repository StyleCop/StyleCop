//-----------------------------------------------------------------------
// <copyright file="ClassBase.cs" company="Microsoft">
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
    /// The base class for classes, structs and interfaces.
    /// </summary>
    /// <subcategory>element</subcategory>
    public abstract class ClassBase : Element, ITypeConstraintContainer
    {
        #region Private Fields

        /// <summary>
        /// The name of the base class that this item inherits from.
        /// </summary>
        private CodeUnitProperty<string> baseClass;

        /// <summary>
        /// The list of interfaces that this item implements.
        /// </summary>
        private CodeUnitProperty<IList<string>> implementedInterfaces;

        /// <summary>
        /// The list of type constraints on the item, if any.
        /// </summary>
        private CodeUnitProperty<ICollection<TypeParameterConstraintClause>> typeConstraints;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the ClassBase class.
        /// </summary>
        /// <param name="proxy">Proxy object for the class.</param>
        /// <param name="type">The element type.</param>
        /// <param name="name">The name of this element.</param>
        /// <param name="attributes">The list of attributes attached to this element.</param>
        /// <param name="typeConstraints">The list of type constraints on the element.</param>
        /// <param name="unsafeCode">Indicates whether the element resides within a block of unsafe code.</param>
        internal ClassBase(
            CodeUnitProxy proxy,
            ElementType type,
            string name,
            ICollection<Attribute> attributes,
            ICollection<TypeParameterConstraintClause> typeConstraints,
            bool unsafeCode)
            : base(proxy, type, name, attributes, unsafeCode)
        {
            Param.AssertNotNull(proxy, "proxy");
            Param.Ignore(type, name, attributes, typeConstraints, unsafeCode);

            this.typeConstraints.Value = typeConstraints;
            Debug.Assert(typeConstraints == null || typeConstraints.IsReadOnly, "The typeconstraints collection should be read-only.");
        }

        #endregion Internal Constructors

        #region Public Override Properties

        /*
        /// <summary>
        /// Gets the variables defined within this element.
        /// </summary>
        public override IList<IVariable> Variables
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.variables.Initialized)
                {
                    List<IVariable> vars = new List<IVariable>();

                    if (!this.Is(ElementType.Interface))
                    {
                        for (Field field = this.FindFirstChild<Field>(); field != null; field = field.FindNextSibling<Field>())
                        {
                            vars.AddRange(field.Variables);
                        }
                    }

                    this.variables.Value = vars.AsReadOnly();
                }

                return this.variables.Value;
            }
        }
         * */

        #endregion Public Override Properties

        #region Public Properties

        /// <summary>
        /// Gets the list of interfaces that this element implements.
        /// </summary>
        public ICollection<string> ImplementedInterfaces
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.implementedInterfaces.Initialized)
                {
                    this.SetInheritedItems();
                    Debug.Assert(this.implementedInterfaces.Value != null, "Not set");
                }

                return this.implementedInterfaces.Value;
            }
        }

        /// <summary>
        /// Gets the name of the base element that this element inherits from.
        /// </summary>
        public string BaseClass
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.baseClass.Initialized)
                {
                    this.SetInheritedItems();
                    Debug.Assert(this.baseClass.Value != null, "Not set");
                }

                return this.baseClass.Value;
            }
        }

        /// <summary>
        /// Gets the list of type constraints on the element, if any.
        /// </summary>
        public ICollection<TypeParameterConstraintClause> TypeConstraints
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.typeConstraints.Initialized)
                {
                    this.typeConstraints.Value = new List<TypeParameterConstraintClause>(this.GetChildren<TypeParameterConstraintClause>()).AsReadOnly();
                }

                return this.typeConstraints.Value;
            }
        }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Gets the list of partial elements with the same fully qualified name as this element.
        /// </summary>
        /// <returns>Returns the collection of partial elements of this type.</returns>
        /// <remarks>If this is not a partial element, this property returns null.</remarks>
        public ICollection<Element> DiscoverPartialElementList()
        {
            if (this.ContainsModifier(TokenType.Partial))
            {
                List<Element> partialElementList;

                if (this.Document.Parser.PartialElements.TryGetValue(this.FullyQualifiedName, out partialElementList))
                {
                    return partialElementList.AsReadOnly();
                }
            }

            return Element.EmptyElementArray;
        }

        #endregion Public Methods

        #region Protected Override Methods

        /// <summary>
        /// Resets the contents of the class.
        /// </summary>
        protected override void Reset()
        {
            base.Reset();

            this.baseClass.Reset();
            this.implementedInterfaces.Reset();
            this.typeConstraints.Reset();
        }

        #endregion Protected Override Methods

        #region Private Methods

        /// <summary>
        /// Sets the inherited items of the class.
        /// </summary>
        private void SetInheritedItems()
        {
            // Pull out the name of the base class and any implemented interfaces 
            // from the declaration of this class.
            bool colon = false;
            bool comma = false;
            var interfaces = new List<string>();

            this.baseClass.Value = string.Empty;

            for (Token token = this.FindFirstChild<Token>(); token != null; token = token.FindNextSibling<Token>())
            {
                if (colon)
                {
                    if (token.Text.Length >= 2 &&
                        token.Text[0] == 'I' &&
                        char.IsUpper(token.Text[1]))
                    {
                        interfaces.Add(CodeParser.TrimType(token.Text));
                    }
                    else
                    {
                        this.baseClass.Value = CodeParser.TrimType(token.Text);
                    }

                    colon = false;
                }
                else if (comma)
                {
                    interfaces.Add(CodeParser.TrimType(token.Text));
                    comma = false;
                }
                else
                {
                    if (token.TokenType == TokenType.Where)
                    {
                        break;
                    }
                    else if (token.Text == ":")
                    {
                        if (this.baseClass.Value.Length > 0)
                        {
                            break;
                        }
                        else
                        {
                            colon = true;
                        }
                    }
                    else if (token.TokenType == TokenType.Comma)
                    {
                        comma = true;
                    }
                }
            }

            this.implementedInterfaces.Value = interfaces.AsReadOnly();
        }

        #endregion Private Methods
    }
}
