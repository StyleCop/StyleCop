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
    /// The base class for classes, structs and interfaces.
    /// </summary>
    /// <subcategory>element</subcategory>
    public abstract class ClassBase : Element, ITypeConstraintContainer
    {
        #region Private Fields

        /// <summary>
        /// The name of the base class that this codeUnit inherits from.
        /// </summary>
        private string baseClass = string.Empty;

        /// <summary>
        /// The list of interfaces that this codeUnit implements.
        /// </summary>
        private string[] implementedInterfaces = new string[] { };

        /// <summary>
        /// The list of type constraints on the codeUnit, if any.
        /// </summary>
        private ICollection<TypeParameterConstraintClause> typeConstraints;

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

            this.typeConstraints = typeConstraints;

            #if DEBUG
            if (typeConstraints != null)
            {
                Debug.Assert(typeConstraints.IsReadOnly, "The typeconstraints collection should be read-only.");
            }
            #endif
        }

        #endregion Internal Constructors

        #region Public Properties

        /// <summary>
        /// Gets the list of interfaces that this element implements.
        /// </summary>
        public ICollection<string> ImplementedInterfaces
        {
            get
            {
                return this.implementedInterfaces;
            }
        }

        /// <summary>
        /// Gets the name of the base element that this element inherits from.
        /// </summary>
        public string BaseClass
        {
            get
            {
                return this.baseClass;
            }
        }

        /// <summary>
        /// Gets the list of partial interfaces with the same fully qualified name as this element.
        /// </summary>
        /// <remarks>If this is not a partial element, this property returns null.</remarks>
        public ICollection<Element> PartialElementList
        {
            get
            {
                if (this.ContainsModifier(TokenType.Partial))
                {
                    List<Element> partialElementList;
                    CsDocument document = (CsDocument)this.Document;

                    if (document.Parser.PartialElements.TryGetValue(this.FullyQualifiedName, out partialElementList))
                    {
                        return partialElementList.AsReadOnly();
                    }
                }

                return null;
            }
        }

        /// <summary>
        /// Gets the list of type constraints on the element, if any.
        /// </summary>
        public ICollection<TypeParameterConstraintClause> TypeConstraints
        {
            get
            {
                return this.typeConstraints;
            }
        }

        #endregion Public Properties

        #region Public Override Methods

        /// <summary>
        /// Gets the variables defined within this element.
        /// </summary>
        /// <returns>Returns the collection of variables.</returns>
        public override IVariable[] GetVariables()
        {
            if (!this.Is(ElementType.Interface))
            {
                var variables = new List<IVariable>();

                for (Field field = this.FindFirstChild<Field>(); field != null; field = field.FindNextSibling<Field>())
                {
                    variables.AddRange(field.GetVariables());
                }

                if (variables.Count > 0)
                {
                    return variables.ToArray();
                }
            }

            return null;
        }

        #endregion Public Override Methods

        #region Protected Methods

        /// <summary>
        /// Sets the inherited items of the class.
        /// </summary>
        protected void SetInheritedItems()
        {
            // Pull out the name of the base class and any implemented interfaces 
            // from the declaration of this class.
            bool colon = false;
            bool comma = false;
            var interfaces = new List<string>();

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
                        this.baseClass = CodeParser.TrimType(token.Text);
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
                        if (this.baseClass.Length > 0)
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

            if (interfaces.Count > 0)
            {
                this.implementedInterfaces = interfaces.ToArray();
            }
        }

        #endregion Protected Methods
    }
}
