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
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Text;

    /// <summary>
    /// Describes a single element in a C# code file.
    /// </summary>
    /// <subcategory>element</subcategory>
    [SuppressMessage("Microsoft.Naming", "CA1706:ShortAcronymsShouldBeUppercase", Justification = "Camel case better serves in this case.")]
    public abstract class Element : CodeUnit, ICodeElement
    {
        #region Internal Static Fields

        /// <summary>
        /// An empty array of elements.
        /// </summary>
        internal static readonly Element[] EmptyElementArray = new Element[] { };

        #endregion Internal Static Fields
        
        #region Private Fields

        /// <summary>
        /// The list of attributes attached to the element.
        /// </summary>
        private ICollection<Attribute> attributes;

        /// <summary>
        /// The name of the element.
        /// </summary>
        private string name;

        /// <summary>
        /// The element's access modifier type.
        /// </summary>
        private AccessModifierType accessModifier = AccessModifierType.Private;

        /// <summary>
        /// The list of modifiers in the declaration.
        /// </summary>
        private Dictionary<TokenType, Token> modifiers;

        /// <summary>
        /// Indicates whether this element is unsafe.
        /// </summary>
        private bool unsafeCode;

        /// <summary>
        /// The contents of the header.
        /// </summary>
        private string header;

        /// <summary>
        /// The lines within the header.
        /// </summary>
        private ICollection<Comment> headerLines;

        /// <summary>
        /// The list of violations in this element.
        /// </summary>
        private Dictionary<string, Violation> violations = new Dictionary<string, Violation>();

        /// <summary>
        /// A private tag which can be used by the current analyzer.
        /// </summary>
        private object analyzerTag;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the Element class.
        /// </summary>
        /// <param name="proxy">Proxy object for the element.</param>
        /// <param name="type">The element type.</param>
        /// <param name="name">The name of this element.</param>
        /// <param name="attributes">The list of attributes attached to this element.</param>
        /// <param name="unsafeCode">Indicates whether the element is unsafe.</param>
        internal Element(
            CodeUnitProxy proxy,
            ElementType type,
            string name,
            ICollection<Attribute> attributes,
            bool unsafeCode) 
            : base(proxy, (int)type)
        {
            Param.Ignore(proxy);
            Param.Ignore(type);
            Param.AssertNotNull(name, "name");
            Param.Ignore(attributes);
            Param.Ignore(unsafeCode);

            Debug.Assert(System.Enum.IsDefined(typeof(ElementType), this.ElementType), "The type is invalid.");

            this.name = name;
            this.attributes = attributes;
            this.unsafeCode = unsafeCode;

            if (!unsafeCode && this.ContainsModifier(TokenType.Unsafe))
            {
                this.unsafeCode = true;
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

            // There is only one type of element which is allowed to have a token
            // list consisting of nothing other than whitespace, newlines, etc., 
            // which is the document root. This happens if you have a document which
            // contains nothing other than whitespace. Due to this we do not want to
            // trim down the token list for the root element, but we do want to for
            // all other types of elements.
            if (this.ElementType == ElementType.Root)
            {
                ////this.TrimTokens = false;
            }
        }

        #endregion Internal Constructors

        #region Public Virtual Properties

        /// <summary>
        /// Gets the fully qualified name of the element.
        /// </summary>
        public virtual string FullyQualifiedName
        {
            get
            {
                string parentFullyQualifiedName = null;

                Element parentElement = this.ParentCastedToElement;
                if (parentElement != null && parentElement.ElementType != ElementType.Root)
                {
                    parentFullyQualifiedName = parentElement.FullyQualifiedName;
                }

                if (string.IsNullOrEmpty(parentFullyQualifiedName))
                {
                    return this.name;
                }

                var fullyQualifiedName = new StringBuilder();
                fullyQualifiedName.Append(parentFullyQualifiedName);
                fullyQualifiedName.Append(".");

                if (!string.IsNullOrEmpty(this.name))
                {
                    fullyQualifiedName.Append(this.name);
                }

                return fullyQualifiedName.ToString();
            }
        }

        /// <summary>
        /// Gets the element's access level, without taking into account the access level of the element's parent.
        /// </summary>
        public virtual AccessModifierType AccessLevel
        {
            get
            {
                return this.accessModifier;
            }

            protected set
            {
                this.accessModifier = value;
            }
        }

        #endregion Public Virtual Properties

        #region ICodeElement Properties

        /// <summary>
        /// Gets the collection of child elements beneath this element.
        /// </summary>
        IEnumerable<ICodeElement> ICodeElement.ChildCodeElements
        {
            get
            {
                return this.FindChildElements();
            }
        }

        #endregion ICodeElement Properties

        #region Public Properties

        /// <summary>
        /// Gets a value indicating whether the element declares an access modifier within its declaration.
        /// </summary>
        public bool DeclaresAccessModifier
        {
            get
            {
                return this.ContainsModifier(TokenType.Public, TokenType.Internal, TokenType.Protected, TokenType.Private);
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
        /// Gets the contents of the Xml header, if any.
        /// </summary>
        public string HeaderText
        {
            get
            {
                if (this.header == null)
                {
                    this.GetHeader();
                }

                return this.header;
            }
        }

        /// <summary>
        /// Gets the collection of header lines from the element's Xml header, if any.
        /// </summary>
        public ICollection<Comment> HeaderLines
        {
            get
            {
                if (this.headerLines == null)
                {
                    this.GetHeader();
                }

                return this.headerLines;
            }
        }

        /// <summary>
        /// Gets the type of the element.
        /// </summary>
        public ElementType ElementType
        {
            get 
            {
                return (ElementType)(this.FundamentalType & (int)FundamentalTypeMasks.Element);
            }
        }

        /// <summary>
        /// Gets the document that contains this element.
        /// </summary>
        public virtual ICodeDocument Document
        {
            get
            {
                Element root = this;
                while (root != null)
                {
                    if (root.ElementType == ElementType.Root)
                    {
                        return root.Document;
                    }

                    root = root.FindParent<Element>();
                }

                return null;
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
        /// Gets the first token in the element's declaration.
        /// </summary>
        public Token FirstDeclarationToken
        {
            get
            {
                for (CodeUnit item = this.FindFirstDescendent<CodeUnit>(); item != null; item = item.FindNextDescendentOf<CodeUnit>(this))
                {
                    if (item.Is(CodeUnitType.Attribute))
                    {
                        // Move to the end of the attribute.
                        item = item.FindLastDescendent<CodeUnit>();
                    }
                    else if (item.Is(LexicalElementType.Token))
                    {
                        return (Token)item;
                    }
                }

                return null;
            }
        }

        #endregion Public Properties

        #region Protected Abstract Properties

        /// <summary>
        /// Gets the collection of modifiers allowed on this element.
        /// </summary>
        protected abstract IEnumerable<string> AllowedModifiers
        {
            get;
        }

        #endregion Protected Abstract Properties

        #region Private Properties

        /// <summary>
        /// Gets the parent of the element hard-casted to an element.
        /// </summary>
        /// <remarks>The parent of an element must always be an element.</remarks>
        private Element ParentCastedToElement
        {
            get
            {
                if (this.Parent == null)
                {
                    return null;
                }

                Debug.Assert(this.Parent is Element, "The parent of an Element must always be an Element.");
                return (Element)this.Parent;
            }
        }

        #endregion Private Properties

        #region Public Virtual Methods

        /// <summary>
        /// Gets the variables defined within this code unit.
        /// </summary>
        /// <returns>Returns the collection of variables.</returns>
        public virtual IVariable[] GetVariables()
        {
            return null;
        }

        /// <summary>
        /// Gets the actual access level of this element, taking into account the
        /// access level of the element's parent.
        /// </summary>
        /// <returns>Returns the actual access level.</returns>
        public virtual AccessModifierType GetActualAccessLevel()
        {
            return this.ComputeActualAccess();
        }

        /// <summary>
        /// Clears the analyzer tags for this element.
        /// </summary>
        /// <remarks>This method should only be called by the StyleCop framework.</remarks>
        public virtual void ClearAnalyzerTags()
        {
            this.analyzerTag = null;
        }

        #endregion Public Virtual Methods

        #region Public Methods

        /// <summary>
        /// Indicates whether the element declaration contains one of the given modifiers.
        /// </summary>
        /// <param name="types">The modifier types to check for.</param>
        /// <returns>Returns true if the declaration contains at least one of the given modifiers.</returns>
        public bool ContainsModifier(params TokenType[] types)
        {
            Param.RequireNotNull(types, "types");

            if (this.modifiers == null)
            {
                this.GatherDeclarationModifiers(this.AllowedModifiers);
                Debug.Assert(this.modifiers != null, "Modifiers should be non-null now.");
            }

            for (int i = 0; i < types.Length; ++i)
            {
                if (this.modifiers.ContainsKey(types[i]))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Adds one violation to this element.
        /// </summary>
        /// <param name="violation">The violation to add.</param>
        /// <returns>Returns false if there is already an identical violation in the element.</returns>
        public bool AddViolation(Violation violation)
        {
            Param.RequireNotNull(violation, "violation");
            string key = violation.Key;

            if (!this.violations.ContainsKey(key))
            {
                this.violations.Add(violation.Key, violation);
                return true;
            }

            return false;
        }

        #endregion Public Methods

        #region Internal Virtual Methods

        /// <summary>
        /// Initializes the element.
        /// </summary>
        /// <param name="document">The document that contains the element.</param>
        internal virtual void Initialize(CsDocument document)
        {
            Param.Ignore(document);
        }

        #endregion Internal Virtual Methods

        #region Private Static Methods

        /// <summary>
        /// Gets another type of modifier for an element declaration.
        /// </summary>
        /// <param name="allowedModifiers">The types of allowed modifiers for the element.</param>
        /// <param name="elementModifiers">The collection of modifiers on the element.</param>
        /// <param name="token">The modifier token.</param>
        /// <returns>true to continue collecting modifiers; false to quit.</returns>
        private static bool GetOtherElementModifier(IEnumerable<string> allowedModifiers, Dictionary<TokenType, Token> elementModifiers, Token token)
        {
            Param.Ignore(allowedModifiers);
            Param.AssertNotNull(elementModifiers, "elementModifiers");
            Param.AssertNotNull(token, "token");

            bool stop = true;

            // If the modifier is one of the allowed modifiers, store it. Otherwise, we are done.
            if (allowedModifiers != null)
            {
                foreach (string allowedModifier in allowedModifiers)
                {
                    if (string.Equals(token.Text, allowedModifier, StringComparison.Ordinal))
                    {
                        elementModifiers.Add(token.TokenType, token);
                        stop = false;
                        break;
                    }
                }
            }

            return !stop;
        }

        /// <summary>
        /// Determines whether the given text string contains an xml header summary tag.
        /// </summary>
        /// <param name="text">The text to check.</param>
        /// <returns>Returns true if the text is a summary; false otherwise.</returns>
        private static bool IsXmlHeaderSummaryLine(string text)
        {
            Param.AssertNotNull(text, "text");

            const string Summary = "summary";

            for (int i = 0; i < text.Length; ++i)
            {
                if (text[i] == '<')
                {
                    for (int j = 0; j < Summary.Length; ++j)
                    {
                        int index = i + j + 1;
                        if (text.Length <= index)
                        {
                            return false;
                        }

                        if (Summary[j] != text[index])
                        {
                            return false;
                        }
                    }

                    return true;
                }
                else if (!char.IsWhiteSpace(text[i]))
                {
                    break;
                }
            }

            return false;
        }

        #endregion Private Static Methods

        #region Private Methods

        /// <summary>
        /// Merges the access of this element with the access of its parent to determine
        /// the actual visibility of this item outside of the class.
        /// </summary>
        /// <returns>Returns the actual access level.</returns>
        private AccessModifierType ComputeActualAccess()
        {
            if (this.accessModifier == AccessModifierType.Private)
            {
                return this.accessModifier;
            }

            Element parentElement = this.ParentCastedToElement;
            if (parentElement == null)
            {
                return this.accessModifier;
            }

            AccessModifierType parentActualAccess = parentElement.GetActualAccessLevel();
            AccessModifierType actualAccess = this.accessModifier;

            if (parentActualAccess == AccessModifierType.Public)
            {
                return actualAccess;
            }
            else if (parentActualAccess == AccessModifierType.ProtectedInternal)
            {
                if (actualAccess == AccessModifierType.Public)
                {
                    return AccessModifierType.ProtectedInternal;
                }
                else
                {
                    return actualAccess;
                }
            }
            else if (parentActualAccess == AccessModifierType.Protected)
            {
                if (actualAccess == AccessModifierType.Public ||
                    actualAccess == AccessModifierType.ProtectedInternal)
                {
                    return AccessModifierType.Protected;
                }
                else if (actualAccess == AccessModifierType.Internal)
                {
                    return AccessModifierType.ProtectedAndInternal;
                }
                else 
                {
                    return actualAccess;
                }
            }
            else if (parentActualAccess == AccessModifierType.Internal)
            {
                if (actualAccess == AccessModifierType.Public ||
                    actualAccess == AccessModifierType.ProtectedInternal)
                {
                    return AccessModifierType.Internal;
                }
                else if (actualAccess == AccessModifierType.Protected)
                {
                    return AccessModifierType.ProtectedAndInternal;
                }
                else
                {
                    return actualAccess;
                }
            }
            else if (parentActualAccess == AccessModifierType.ProtectedAndInternal)
            {
                if (actualAccess == AccessModifierType.Public ||
                    actualAccess == AccessModifierType.ProtectedInternal ||
                    actualAccess == AccessModifierType.Protected ||
                    actualAccess == AccessModifierType.Internal)
                {
                    return AccessModifierType.ProtectedAndInternal;
                }
                else
                {
                    return actualAccess;
                }
            }
            else
            {
                return AccessModifierType.Private;
            }
        }

        /// <summary>
        /// Walks the element declaration and gathers the element modifiers.
        /// </summary>
        /// <param name="allowedModifiers">The modifiers which are allowed for the current element type.</param>
        private void GatherDeclarationModifiers(IEnumerable<string> allowedModifiers)
        {
            Param.Ignore(allowedModifiers);

            this.modifiers = new Dictionary<TokenType, Token>();

            Token accessModifierSeen = null;

            for (Token token = this.FirstDeclarationToken; token != null; token = token.FindNextSibling<Token>())
            {
                if (token.TokenType == TokenType.Public)
                {
                    // A public access modifier can only be specified if there have been no other access modifiers.
                    if (accessModifierSeen != null)
                    {
                        throw new SyntaxException(this.Document.SourceCode, token.LineNumber);
                    }

                    this.accessModifier = AccessModifierType.Public;
                    accessModifierSeen = token;
                    this.modifiers.Add(TokenType.Public, token);
                }
                else if (token.TokenType == TokenType.Private)
                {
                    // A private access modifier can only be specified if there have been no other access modifiers.
                    if (accessModifierSeen != null)
                    {
                        throw new SyntaxException(this.Document.SourceCode, token.LineNumber);
                    }

                    this.accessModifier = AccessModifierType.Private;
                    accessModifierSeen = token;
                    this.modifiers.Add(TokenType.Private, token);
                }
                else if (token.TokenType == TokenType.Internal)
                {
                    // The access is internal unless we have already seen a protected access
                    // modifier, in which case it is protected internal.
                    if (accessModifierSeen == null)
                    {
                        this.accessModifier = AccessModifierType.Internal;
                    }
                    else if (accessModifierSeen.TokenType == TokenType.Protected)
                    {
                        this.accessModifier = AccessModifierType.ProtectedInternal;
                    }
                    else
                    {
                        throw new SyntaxException(this.Document.SourceCode, token.LineNumber);
                    }

                    accessModifierSeen = token;
                    this.modifiers.Add(TokenType.Internal, token);
                }
                else if (token.TokenType == TokenType.Protected)
                {
                    // The access is protected unless we have already seen an internal access
                    // modifier, in which case it is protected internal.
                    if (accessModifierSeen == null)
                    {
                        this.accessModifier = AccessModifierType.Protected;
                    }
                    else if (accessModifierSeen.TokenType == TokenType.Internal)
                    {
                        this.accessModifier = AccessModifierType.ProtectedInternal;
                    }
                    else
                    {
                        throw new SyntaxException(this.Document.SourceCode, token.LineNumber);
                    }

                    accessModifierSeen = token;
                    this.modifiers.Add(TokenType.Protected, token);
                }
                else
                {
                    if (!GetOtherElementModifier(allowedModifiers, this.modifiers, token))
                    {
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Gets the Xml header.
        /// </summary>
        private void GetHeader()
        {
            List<Comment> lines = null;
            StringBuilder text = null;
            int summaryCount = 0;

            for (CodeUnit item = this.FindFirstDescendent<CodeUnit>(); item != null; item = item.FindNextDescendentOf<CodeUnit>(this))
            {
                if (item.CodeUnitType == CodeUnitType.Attribute || item.Is(LexicalElementType.Token))
                {
                    break;
                }
                else if (item.Is(LexicalElementType.PreprocessorDirective))
                {
                    // Move past the preprocessor.
                    item = item.FindLastInTree<CodeUnit>();
                }
                else if (item.Is(LexicalElementType.EndOfLine) || 
                    item.Is(LexicalElementType.WhiteSpace) ||
                    item.Is(CommentType.SingleLineComment) ||
                    item.Is(CommentType.MultilineComment))
                {
                    continue;
                }
                else if (item.Is(CommentType.XmlHeaderLine))
                {
                    Comment xmlHeaderLine = (Comment)item;
                    string headerLineText = xmlHeaderLine.Text;
                    if (headerLineText.StartsWith("///", StringComparison.Ordinal))
                    {
                        headerLineText = headerLineText.Substring(3, headerLineText.Length - 3);
                    }

                    if (text == null)
                    {
                        text = new StringBuilder();
                        lines = new List<Comment>();
                    }

                    if (IsXmlHeaderSummaryLine(headerLineText) && ++summaryCount > 1)
                    {
                        text = new StringBuilder();
                        lines = new List<Comment>();
                    }

                    text.Append(headerLineText);
                    lines.Add(xmlHeaderLine);
                }
                else
                {
                    break;
                }
            }

            if (text != null && text.Length > 0)
            {
                this.header = text.ToString();
                this.headerLines = lines.ToArray();
            }
            else
            {
                this.header = null;
                this.headerLines = Comment.EmptyCommentArray;
            }
        }

        #endregion Private Methods
    }
}
