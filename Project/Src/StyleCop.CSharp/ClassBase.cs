// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ClassBase.cs" company="https://github.com/StyleCop">
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
//   The base class for classes, structs and interfaces.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// The base class for classes, structs and interfaces.
    /// </summary>
    /// <subcategory>element</subcategory>
    public abstract class ClassBase : CsElement, ITypeConstraintContainer
    {
        #region Fields

        /// <summary>
        /// The list of type constraints on the item, if any.
        /// </summary>
        private readonly ICollection<TypeParameterConstraintClause> typeConstraints;

        /// <summary>
        /// The name of the base class that this item inherits from.
        /// </summary>
        private string baseClass = string.Empty;

        /// <summary>
        /// The list of interfaces that this item implements.
        /// </summary>
        private string[] implementedInterfaces = new string[] { };

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the ClassBase class.
        /// </summary>
        /// <param name="document">
        /// The document that contains the element.
        /// </param>
        /// <param name="parent">
        /// The parent of the element.
        /// </param>
        /// <param name="type">
        /// The element type.
        /// </param>
        /// <param name="name">
        /// The name of this element.
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
        /// <param name="typeConstraints">
        /// The list of type constraints on the element.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the element resides within a block of unsafe code.
        /// </param>
        /// <param name="generated">
        /// Indicates whether the code element was generated or written by hand.
        /// </param>
        internal ClassBase(
            CsDocument document, 
            CsElement parent, 
            ElementType type, 
            string name, 
            XmlHeader header, 
            ICollection<Attribute> attributes, 
            Declaration declaration, 
            ICollection<TypeParameterConstraintClause> typeConstraints, 
            bool unsafeCode, 
            bool generated)
            : base(document, parent, type, name, header, attributes, declaration, unsafeCode, generated)
        {
            Param.Ignore(document, parent, type, name, header, attributes, declaration, typeConstraints, unsafeCode, generated);

            this.typeConstraints = typeConstraints;

            // Set the parent of the type constraint clauses.
            if (typeConstraints != null)
            {
                Debug.Assert(typeConstraints.IsReadOnly, "The typeconstraints collection should be read-only.");

                foreach (TypeParameterConstraintClause constraint in typeConstraints)
                {
                    constraint.ParentElement = this;
                }
            }
        }

        #endregion

        #region Public Properties

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
        /// Gets the list of partial interfaces with the same fully qualified name as this element.
        /// </summary>
        /// <remarks>If this is not a partial element, this property returns null.</remarks>
        public ICollection<CsElement> PartialElementList
        {
            get
            {
                if (this.Declaration.ContainsModifier(CsTokenType.Partial))
                {
                    CsDocument doc = (CsDocument)this.Document;
                    lock (doc.Parser.PartialElements)
                    {
                        List<CsElement> partialElementList;
                        if (doc.Parser.PartialElements.TryGetValue(this.FullNamespaceName, out partialElementList))
                        {
                            return partialElementList.ToArray();
                        }
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

        #endregion

        #region Methods

        /// <summary>
        /// Sets the inherited items of the class.
        /// </summary>
        /// <param name="declaration">
        /// The class declaration.
        /// </param>
        protected void SetInheritedItems(Declaration declaration)
        {
            Param.RequireNotNull(declaration, "declaration");

            // Pull out the name of the base class and any implemented interfaces 
            // from the declaration of this class.
            bool colon = false;
            bool comma = false;
            List<string> interfaces = new List<string>();

            foreach (CsToken token in declaration.Tokens)
            {
                if (colon)
                {
                    if (token.CsTokenType != CsTokenType.WhiteSpace && token.CsTokenType != CsTokenType.EndOfLine && token.CsTokenType != CsTokenType.SingleLineComment
                        && token.CsTokenType != CsTokenType.MultiLineComment && token.CsTokenType != CsTokenType.PreprocessorDirective)
                    {
                        if (token.Text.Length >= 2 && token.Text[0] == 'I' && char.IsUpper(token.Text[1]))
                        {
                            interfaces.Add(CodeParser.TrimType(token.Text));
                        }
                        else
                        {
                            this.baseClass = CodeParser.TrimType(token.Text);
                        }

                        colon = false;
                    }
                }
                else if (comma)
                {
                    if (token.CsTokenType != CsTokenType.WhiteSpace && token.CsTokenType != CsTokenType.EndOfLine && token.CsTokenType != CsTokenType.SingleLineComment
                        && token.CsTokenType != CsTokenType.MultiLineComment && token.CsTokenType != CsTokenType.PreprocessorDirective)
                    {
                        interfaces.Add(CodeParser.TrimType(token.Text));
                        comma = false;
                    }
                }
                else
                {
                    if (token.CsTokenType == CsTokenType.Where)
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
                    else if (token.CsTokenType == CsTokenType.Comma)
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

        #endregion
    }
}