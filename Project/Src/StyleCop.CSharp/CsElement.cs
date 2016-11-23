// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CsElement.cs" company="https://github.com/StyleCop">
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
//   Describes a single element in a C# code file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Describes a single element in a C# code file.
    /// </summary>
    /// <subcategory>element</subcategory>
    [SuppressMessage("Microsoft.Naming", "CA1706:ShortAcronymsShouldBeUppercase", Justification = "Camel case better serves in this case.")]
    public abstract class CsElement : CodeUnit, ICodeElement
    {
        #region Static Fields

        /// <summary>
        /// An empty array of elements.
        /// </summary>
        private static readonly CsElement[] EmptyElementArray = new CsElement[0];

        #endregion

        #region Fields

        /// <summary>
        /// The list of attributes attached to the element.
        /// </summary>
        private readonly ICollection<Attribute> attributes;

        /// <summary>
        /// The element declaration.
        /// </summary>
        private readonly Declaration declaration;

        /// <summary>
        /// The document that owns this element.
        /// </summary>
        private readonly CsDocument document;

        /// <summary>
        /// The full namespace name of this element.
        /// </summary>
        private readonly string fullNamespaceName;

        /// <summary>
        /// The fully qualified base name of this element.
        /// </summary>
        private readonly string fullyQualifiedBase;

        /// <summary>
        /// Indicates whether this element resides within a block of generated code.
        /// </summary>
        private readonly bool generated;

        /// <summary>
        /// The Xml header of the element.
        /// </summary>
        private readonly XmlHeader header;

        /// <summary>
        /// The name of the element.
        /// </summary>
        private readonly string name;

        /// <summary>
        /// The element type.
        /// </summary>
        private readonly ElementType type;

        /// <summary>
        /// Indicates whether this element is unsafe.
        /// </summary>
        private readonly bool unsafeCode;

        /// <summary>
        /// The list of violations in this element.
        /// </summary>
        private readonly Dictionary<int, Violation> violations = new Dictionary<int, Violation>();

        /// <summary>
        /// The actual access of this item, considering the access of its parents.
        /// </summary>
        private AccessModifierType actualAccess;

        /// <summary>
        /// A private tag which can be used by the current analyzer.
        /// </summary>
        private object analyzerTag;

        /// <summary>
        /// The collection of child elements of this element.
        /// </summary>
        private CodeUnitCollection<CsElement> elements;

        /// <summary>
        /// The fully qualified name of this element.
        /// </summary>
        private string fullyQualifiedName;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the CsElement class.
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
        /// <param name="unsafeCode">
        /// Indicates whether the element is unsafe.
        /// </param>
        /// <param name="generated">
        /// Indicates whether the element was generated or written by hand.
        /// </param>
        internal CsElement(
            CsDocument document, 
            CsElement parent, 
            ElementType type, 
            string name, 
            XmlHeader header, 
            ICollection<Attribute> attributes, 
            Declaration declaration, 
            bool unsafeCode, 
            bool generated)
            : base(CodePartType.Element)
        {
            Param.AssertNotNull(document, "document");
            Param.Ignore(parent);
            Param.Ignore(type);
            Param.AssertNotNull(name, "name");
            Param.Ignore(header);
            Param.Ignore(attributes);
            Param.Ignore(declaration);
            Param.Ignore(unsafeCode);
            Param.Ignore(generated);

            this.document = document;
            if (this.document == null)
            {
                throw new ArgumentException(Strings.DocumentMustBeCsDocument, "document");
            }

            if (parent != null && parent.Document != document)
            {
                throw new ArgumentException(Strings.ElementMustBeInParentsDocument, "parent");
            }

            this.type = type;
            this.name = CodeLexer.DecodeEscapedText(name, true);
            this.header = header;
            this.attributes = attributes;
            this.declaration = declaration;
            this.unsafeCode = unsafeCode;
            this.generated = generated;

            if (!unsafeCode && this.declaration.ContainsModifier(CsTokenType.Unsafe))
            {
                this.unsafeCode = true;
            }

            // Fill in the element reference in the header object.
            if (this.header != null)
            {
                Debug.Assert(this.header.Element == null, "The header element should not be empty.");
                this.header.Element = this;
            }

            // Fill in the element reference in the attributes list items.
            if (this.attributes != null)
            {
                Debug.Assert(this.attributes.IsReadOnly, "The attributes collection should be read-only.");

                foreach (Attribute attribute in this.attributes)
                {
                    Debug.Assert(attribute.Element == null, "The attribute element should not be empty");
                    attribute.Element = this;
                }
            }

            // Set the fully qualified base name
            if (parent != null)
            {
                this.fullyQualifiedBase = parent.FullyQualifiedName;
                this.MergeAccess(parent.ActualAccess);
            }
            else
            {
                if (this.declaration != null)
                {
                    this.actualAccess = this.declaration.AccessModifierType;
                }
                else
                {
                    this.actualAccess = AccessModifierType.Public;
                }
            }

            // Set the fully qualified name
            this.fullyQualifiedName = this.fullyQualifiedBase;
            if (this.declaration != null && this.declaration.Name != null && this.declaration.Name.Length > 0)
            {
                if (this.fullyQualifiedBase != null && this.fullyQualifiedBase.Length > 0)
                {
                    this.fullyQualifiedName += ".";
                }

                int index = this.declaration.Name.LastIndexOf("\\", StringComparison.Ordinal);
                if (index != -1)
                {
                    this.fullyQualifiedName += this.declaration.Name.Substring(index + 1, this.declaration.Name.Length - index - 1);
                }
                else
                {
                    this.fullyQualifiedName += this.declaration.Name;
                }

                index = this.fullyQualifiedName.IndexOf(".cs.", StringComparison.OrdinalIgnoreCase);
                if (-1 == index)
                {
                    this.fullNamespaceName = this.fullyQualifiedName;
                }
                else
                {
                    this.fullNamespaceName = this.fullyQualifiedName.Substring(index + 4, this.fullyQualifiedName.Length - index - 4);
                }
            }

            // There is only one type of element which is allowed to have a token
            // list consisting of nothing other than whitespace, newlines, etc., 
            // which is the document root. This happens if you have a document which
            // contains nothing other than whitespace. Due to this we do not want to
            // trim down the token list for the root element, but we do want to for
            // all other types of elements.
            if (type == ElementType.Root)
            {
                this.TrimTokens = false;
            }
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the element's access modifier.
        /// </summary>
        public AccessModifierType AccessModifier
        {
            get
            {
                return this.declaration == null ? this.actualAccess : this.declaration.AccessModifierType;
            }
        }

        /// <summary>
        /// Gets the actual visibility of this element outside of the current class, taking into account the
        /// access of the element's parent.
        /// </summary>
        public AccessModifierType ActualAccess
        {
            get
            {
                return this.actualAccess;
            }
        }

        /// <summary>
        /// Gets or sets the analyzer tag.
        /// </summary>
        /// <remarks>A StyleCop rules analyzer can temporarily store and retrieve a value in this property. This value will be lost once 
        /// the rules analyzer has completed its analysis of the document containing this code element.</remarks>
        public object AnalyzerTag
        {
            get
            {
                return this.analyzerTag;
            }

            set
            {
                Param.Ignore(value);
                this.analyzerTag = value;
            }
        }

        /// <summary>
        /// Gets the list of attributes attached to the element.
        /// </summary>
        public ICollection<Attribute> Attributes
        {
            get
            {
                return this.attributes;
            }
        }

        /// <summary>
        /// Gets the collection of child elements beneath this element.
        /// </summary>
        public IEnumerable<ICodeElement> ChildCodeElements
        {
            get
            {
                return new EnumerableAdapter<CsElement, ICodeElement>(this.elements, e => { return e; });
            }
        }

        /// <summary>
        /// Gets the collection of child elements one level under this element, if any.
        /// </summary>
        public ICollection<CsElement> ChildElements
        {
            get
            {
                if (this.elements == null)
                {
                    return EmptyElementArray;
                }

                return this.elements;
            }
        }

        /// <summary>
        /// Gets the element declaration.
        /// </summary>
        public Declaration Declaration
        {
            get
            {
                return this.declaration;
            }
        }

        /// <summary>
        /// Gets the document that contains this element.
        /// </summary>
        public CodeDocument Document
        {
            get
            {
                return this.document;
            }
        }

        /// <summary>
        /// Gets the collection of tokens in the element.
        /// </summary>
        public IEnumerable<CsToken> ElementTokens
        {
            get
            {
                return this.Tokens;
            }
        }

        /// <summary>
        /// Gets the type of the element.
        /// </summary>
        public ElementType ElementType
        {
            get
            {
                return this.type;
            }
        }

        /// <summary>
        /// Gets the full name of the element.
        /// </summary>
        public string FullNamespaceName
        {
            get
            {
                return this.fullNamespaceName;
            }
        }

        /// <summary>
        /// Gets the fully qualified name of the element.
        /// </summary>
        public string FullyQualifiedName
        {
            get
            {
                return this.fullyQualifiedName;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the element resides within a block of generated code.
        /// </summary>
        public bool Generated
        {
            get
            {
                return this.generated;
            }
        }

        /// <summary>
        /// Gets the Xml header for the element.
        /// </summary>
        public XmlHeader Header
        {
            get
            {
                return this.header;
            }
        }

        /// <summary>
        /// Gets the name of the element.
        /// </summary>
        public string Name
        {
            get
            {
                return this.name;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the element resides within a block of unsafe code,
        /// or whether the element declares itself as unsafe.
        /// </summary>
        public bool Unsafe
        {
            get
            {
                return this.unsafeCode;
            }
        }

        /// <summary>
        /// Gets the violations found in this element.
        /// </summary>
        public ICollection<Violation> Violations
        {
            get
            {
                return this.violations.Values;
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the fully qualified name of the element.
        /// </summary>
        protected string QualifiedName
        {
            get
            {
                return this.fullyQualifiedName;
            }

            set
            {
                Param.RequireValidString(value, "QualifiedName");
                this.fullyQualifiedName = value;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Adds one violation to this element.
        /// </summary>
        /// <param name="violation">
        /// The violation to add.
        /// </param>
        /// <returns>
        /// Returns false if there is already an identical violation in the element.
        /// </returns>
        public bool AddViolation(Violation violation)
        {
            Param.RequireNotNull(violation, "violation");
            int key = violation.Key;

            if (!this.violations.ContainsKey(key))
            {
                this.violations.Add(violation.Key, violation);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Clears the analyzer tags for this element.
        /// </summary>
        /// <remarks>This method should only be called by the StyleCop framework.</remarks>
        public virtual void ClearAnalyzerTags()
        {
            this.analyzerTag = null;
        }

        /// <summary>
        /// Walks through the code units in the element.
        /// </summary>
        /// <param name="elementCallback">
        /// Callback executed when an element is visited.
        /// </param>
        /// <param name="statementCallback">
        /// Callback executed when a statement is visited.
        /// </param>
        /// <param name="expressionCallback">
        /// Callback executed when an expression is visited.
        /// </param>
        /// <param name="queryClauseCallback">
        /// Callback executed when a query clause is visited.
        /// </param>
        /// <param name="context">
        /// The optional visitor context data.
        /// </param>
        /// <typeparam name="T">
        /// The type of the context item.
        /// </typeparam>
        public void WalkElement<T>(
            CodeWalkerElementVisitor<T> elementCallback, 
            CodeWalkerStatementVisitor<T> statementCallback, 
            CodeWalkerExpressionVisitor<T> expressionCallback, 
            CodeWalkerQueryClauseVisitor<T> queryClauseCallback, 
            T context)
        {
            Param.Ignore(elementCallback, statementCallback, expressionCallback, queryClauseCallback, context);
            CodeWalker<T>.Start(this, elementCallback, statementCallback, expressionCallback, queryClauseCallback, context);
        }

        /// <summary>
        /// Walks through the code units in the element.
        /// </summary>
        /// <param name="elementCallback">
        /// Callback executed when an element is visited.
        /// </param>
        /// <param name="statementCallback">
        /// Callback executed when a statement is visited.
        /// </param>
        /// <param name="expressionCallback">
        /// Callback executed when an expression is visited.
        /// </param>
        /// <param name="context">
        /// The optional visitor context data.
        /// </param>
        /// <typeparam name="T">
        /// The type of the context item.
        /// </typeparam>
        public void WalkElement<T>(
            CodeWalkerElementVisitor<T> elementCallback, CodeWalkerStatementVisitor<T> statementCallback, CodeWalkerExpressionVisitor<T> expressionCallback, T context)
        {
            Param.Ignore(elementCallback, statementCallback, expressionCallback, context);
            this.WalkElement(elementCallback, statementCallback, expressionCallback, null, context);
        }

        /// <summary>
        /// Walks through the code units in the element.
        /// </summary>
        /// <param name="elementCallback">
        /// Callback executed when an element is visited.
        /// </param>
        /// <param name="statementCallback">
        /// Callback executed when a statement is visited.
        /// </param>
        /// <param name="context">
        /// The optional visitor context data.
        /// </param>
        /// <typeparam name="T">
        /// The type of the context item.
        /// </typeparam>
        public void WalkElement<T>(CodeWalkerElementVisitor<T> elementCallback, CodeWalkerStatementVisitor<T> statementCallback, T context)
        {
            Param.Ignore(elementCallback, statementCallback, context);
            this.WalkElement(elementCallback, statementCallback, null, null, context);
        }

        /// <summary>
        /// Walks through the code units in the element.
        /// </summary>
        /// <param name="elementCallback">
        /// Callback executed when an element is visited.
        /// </param>
        /// <param name="context">
        /// The optional visitor context data.
        /// </param>
        /// <typeparam name="T">
        /// The type of the context item.
        /// </typeparam>
        public void WalkElement<T>(CodeWalkerElementVisitor<T> elementCallback, T context)
        {
            Param.Ignore(elementCallback, context);
            this.WalkElement(elementCallback, null, null, null, context);
        }

        /// <summary>
        /// Walks through the code units in the element.
        /// </summary>
        /// <param name="elementCallback">
        /// Callback executed when an element is visited.
        /// </param>
        /// <param name="statementCallback">
        /// Callback executed when a statement is visited.
        /// </param>
        /// <param name="expressionCallback">
        /// Callback executed when an expression is visited.
        /// </param>
        /// <param name="queryClauseCallback">
        /// Callback executed when a query clause is visited.
        /// </param>
        public void WalkElement(
            CodeWalkerElementVisitor<object> elementCallback, 
            CodeWalkerStatementVisitor<object> statementCallback, 
            CodeWalkerExpressionVisitor<object> expressionCallback, 
            CodeWalkerQueryClauseVisitor<object> queryClauseCallback)
        {
            Param.Ignore(elementCallback, statementCallback, expressionCallback, queryClauseCallback);
            CodeWalker<object>.Start(this, elementCallback, statementCallback, expressionCallback, queryClauseCallback, null);
        }

        /// <summary>
        /// Walks through the code units in the element.
        /// </summary>
        /// <param name="elementCallback">
        /// Callback executed when an element is visited.
        /// </param>
        /// <param name="statementCallback">
        /// Callback executed when a statement is visited.
        /// </param>
        /// <param name="expressionCallback">
        /// Callback executed when an expression is visited.
        /// </param>
        public void WalkElement(
            CodeWalkerElementVisitor<object> elementCallback, CodeWalkerStatementVisitor<object> statementCallback, CodeWalkerExpressionVisitor<object> expressionCallback)
        {
            Param.Ignore(elementCallback, statementCallback, expressionCallback);
            this.WalkElement(elementCallback, statementCallback, expressionCallback, null, null);
        }

        /// <summary>
        /// Walks through the code units in the element.
        /// </summary>
        /// <param name="elementCallback">
        /// Callback executed when an element is visited.
        /// </param>
        /// <param name="statementCallback">
        /// Callback executed when a statement is visited.
        /// </param>
        public void WalkElement(CodeWalkerElementVisitor<object> elementCallback, CodeWalkerStatementVisitor<object> statementCallback)
        {
            Param.Ignore(elementCallback, statementCallback);
            this.WalkElement(elementCallback, statementCallback, null, null, null);
        }

        /// <summary>
        /// Walks through the code units in the element.
        /// </summary>
        /// <param name="elementCallback">
        /// Callback executed when an element is visited.
        /// </param>
        public void WalkElement(CodeWalkerElementVisitor<object> elementCallback)
        {
            Param.Ignore(elementCallback);
            this.WalkElement(elementCallback, null, null, null, null);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Adds a child element to this element.
        /// </summary>
        /// <param name="element">
        /// The child element to add.
        /// </param>
        internal virtual void AddElement(CsElement element)
        {
            Param.AssertNotNull(element, "element");

            if (this.elements == null)
            {
                this.elements = new CodeUnitCollection<CsElement>(this);
            }

            this.elements.Add(element);
        }

        /// <summary>
        /// Initializes the element.
        /// </summary>
        internal virtual void Initialize()
        {
        }

        /// <summary>
        /// Merges the access of this element with the access of its parent to determine
        /// the actual visibility of this item outside of the class.
        /// </summary>
        /// <param name="parentAccess">
        /// The parent's actual access type.
        /// </param>
        private void MergeAccess(AccessModifierType parentAccess)
        {
            Param.Ignore(parentAccess);

            AccessModifierType access = this.declaration.AccessModifierType;

            if (parentAccess == AccessModifierType.Public)
            {
                this.actualAccess = access;
            }
            else if (parentAccess == AccessModifierType.ProtectedInternal)
            {
                if (access == AccessModifierType.Public)
                {
                    this.actualAccess = AccessModifierType.ProtectedInternal;
                }
                else
                {
                    this.actualAccess = access;
                }
            }
            else if (parentAccess == AccessModifierType.Protected)
            {
                if (access == AccessModifierType.Public || access == AccessModifierType.ProtectedInternal)
                {
                    this.actualAccess = AccessModifierType.Protected;
                }
                else if (access == AccessModifierType.Internal)
                {
                    this.actualAccess = AccessModifierType.ProtectedAndInternal;
                }
                else
                {
                    this.actualAccess = access;
                }
            }
            else if (parentAccess == AccessModifierType.Internal)
            {
                if (access == AccessModifierType.Public || access == AccessModifierType.ProtectedInternal)
                {
                    this.actualAccess = AccessModifierType.Internal;
                }
                else if (access == AccessModifierType.Protected)
                {
                    this.actualAccess = AccessModifierType.ProtectedAndInternal;
                }
                else
                {
                    this.actualAccess = access;
                }
            }
            else if (parentAccess == AccessModifierType.ProtectedAndInternal)
            {
                if (access == AccessModifierType.Public || access == AccessModifierType.ProtectedInternal || access == AccessModifierType.Protected
                    || access == AccessModifierType.Internal)
                {
                    this.actualAccess = AccessModifierType.ProtectedAndInternal;
                }
                else
                {
                    this.actualAccess = access;
                }
            }
            else
            {
                this.actualAccess = AccessModifierType.Private;
            }
        }

        #endregion
    }
}