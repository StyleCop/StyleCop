//-----------------------------------------------------------------------
// <copyright file="CodeParser.Elements.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
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
    using System.IO;
    using System.Text;
    using System.Threading;
    using System.Xml;
    using Microsoft.StyleCop;

    /// <content>
    /// Contains code for parsing elements within a C# file.
    /// </content>
    internal partial class CodeParser
    {
        #region Internal Static Fields

        /// <summary>
        /// The allowable modifiers on a class element.
        /// </summary>
        internal static readonly string[] ClassModifiers = new string[] 
        { 
            "new", "unsafe", "abstract", "sealed", "static", "partial"        
        };

        /// <summary>
        /// The allowable modifiers on an enum element.
        /// </summary>
        internal static readonly string[] EnumModifiers = new string[]
        {
            "new"
        };

        /// <summary>
        /// The allowable modifiers on a delegate element.
        /// </summary>
        internal static readonly string[] DelegateModifiers = new string[]
        {
            "new", "unsafe"
        };

        /// <summary>
        /// The allowable modifiers on a field element.
        /// </summary>
        internal static readonly string[] FieldModifiers = new string[]
        {
            "new", "unsafe", "const", "readonly", "static", "volatile", "fixed"
        };

        /// <summary>
        /// The allowable modifiers on a method element.
        /// </summary>
        internal static readonly string[] MethodModifiers = new string[]
        {
            "new", "unsafe", "static", "virtual", "sealed", "override", "abstract", "extern", "partial", "implicit", "explicit"
        };

        /// <summary>
        /// The allowable modifiers on a constructor element.
        /// </summary>
        internal static readonly string[] ConstructorModifiers = new string[]
        {
            "unsafe", "static", "extern"
        };

        /// <summary>
        /// The allowable modifiers on a destructor element.
        /// </summary>
        internal static readonly string[] DestructorModifiers = new string[]
        {
            "unsafe", "extern", "static"
        };

        /// <summary>
        /// The allowable modifiers on a property element.
        /// </summary>
        internal static readonly string[] PropertyModifiers = new string[]
        {
            "new", "unsafe", "static", "virtual", "sealed", "override", "abstract", "extern"
        };

        /// <summary>
        /// The allowable modifiers on an indexer element.
        /// </summary>
        internal static readonly string[] IndexerModifiers = new string[]
        {
            "new", "unsafe", "virtual", "sealed", "override", "abstract", "extern"
        };

        /// <summary>
        /// The allowable modifiers on an event element.
        /// </summary>
        internal static readonly string[] EventModifiers = new string[]
        {
            "new", "unsafe", "static", "virtual", "sealed", "override", "abstract", "extern"
        };

        #endregion Internal Static Fields

        #region Private Static Methods

        /// <summary>
        /// Adds an element to the list of partial elements, if necessary.
        /// </summary>
        /// <param name="element">The element to add.</param>
        /// <param name="partialElements">The collection of partial elements.</param>
        private static void AddElementToPartialElementsList(Element element, Dictionary<string, List<Element>> partialElements)
        {
            Param.AssertNotNull(element, "element");
            Param.Ignore(partialElements);

            // If the element is partial, add it to the partial elements list.
            if (element.ContainsModifier(TokenType.Partial) && element is ClassBase)
            {
                // Ensure that the partialElements parameter is set whenever it needs to be set.
                Debug.Assert(
                    partialElements != null,
                    "The partialElements parameter should always be provided when adding a class, struct, or interface.");

                // If we get here at the partialElements parameter is not set, then, assuming this is not a bug, the only way this
                // can happen is if the code we are parsing contains a class, struct, or interface someplace where it does not belong,
                // for example within a property.
                if (partialElements == null)
                {
                    throw new SyntaxException(element.Document.SourceCode, element.LineNumber);
                }

                List<Element> elementList = null;

                lock (partialElements)
                {
                    // Get the partial element list for this element.
                    string elementFullyQualifiedName = element.FullyQualifiedName;
                    partialElements.TryGetValue(elementFullyQualifiedName, out elementList);

                    if (elementList == null)
                    {
                        // Create a new partial element list for this element name.
                        elementList = new List<Element>();
                        partialElements.Add(elementFullyQualifiedName, elementList);
                    }
                    else if (elementList.Count > 0)
                    {
                        // Make sure this elements is the same type as the codeUnit(s) already in the list.
                        if (elementList[0].ElementType != element.ElementType)
                        {
                            throw new SyntaxException(element.Document.SourceCode, element.LineNumber);
                        }
                    }
                }

                // Add the element to the list.
                elementList.Add(element);
            }
        }

        /// <summary>
        /// Checks the type of an element against the type of its parent to verify that the
        /// parent type can have a child of the given type.
        /// </summary>
        /// <param name="elementType">The type of the element.</param>
        /// <param name="parent">The parent.</param>
        /// <returns>Returns true if the parent can have a child of the given type.</returns>
        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "The method is not complex.")]
        private static bool SanityCheckElementTypeAgainstParent(ElementType elementType, Element parent)
        {
            Param.Ignore(elementType);
            Param.Ignore(parent);

            switch (elementType)
            {
                case ElementType.Accessor:
                    return
                        parent != null &&
                        (parent.ElementType == ElementType.Property ||
                         parent.ElementType == ElementType.Indexer ||
                         parent.ElementType == ElementType.Event);

                case ElementType.Class:
                case ElementType.Struct:
                case ElementType.Interface:
                case ElementType.Delegate:
                case ElementType.Enum:
                    return
                        parent != null &&
                        (parent.ElementType == ElementType.Root ||
                         parent.ElementType == ElementType.Namespace ||
                         parent.ElementType == ElementType.Class ||
                         parent.ElementType == ElementType.Struct);

                case ElementType.Constructor:
                case ElementType.Destructor:
                case ElementType.Field:
                    return
                        parent != null &&
                        (parent.ElementType == ElementType.Class ||
                         parent.ElementType == ElementType.Struct);

                case ElementType.Event:
                case ElementType.Indexer:
                case ElementType.Method:
                case ElementType.Property:
                    return
                        parent != null &&
                        (parent.ElementType == ElementType.Class ||
                         parent.ElementType == ElementType.Struct ||
                         parent.ElementType == ElementType.Interface);

                case ElementType.ConstructorInitializer:
                    return
                        parent != null &&
                        parent.ElementType == ElementType.Constructor;

                case ElementType.EnumItem:
                    return
                        parent != null &&
                        parent.ElementType == ElementType.Enum;

                case ElementType.ExternAliasDirective:
                    return
                        parent != null &&
                        (parent.ElementType == ElementType.Namespace ||
                         parent.ElementType == ElementType.Root);

                case ElementType.File:
                case ElementType.Root:
                    return parent == null;

                case ElementType.Namespace:
                case ElementType.UsingDirective:
                    return
                        parent != null &&
                        (parent.ElementType == ElementType.Root ||
                         parent.ElementType == ElementType.Namespace);

                case ElementType.EmptyElement:
                    break;

                default:
                    Debug.Fail("Unexpected element type.");
                    break;
            }

            return true;
        }

        /// <summary>
        /// Determines whether the given expression is the start of a CodeAnalysis SuppressMessage attribute.
        /// </summary>
        /// <param name="name">The expression to check.</param>
        /// <returns>Returns true if the expression is a CodeAnalysis SuppressMessage; false otherwise.</returns>
        private static bool IsCodeAnalysisSuppression(Expression name)
        {
            Param.AssertNotNull(name, "name");

            if (name.ExpressionType == ExpressionType.Literal)
            {
                string nameText = ((LiteralExpression)name).Text;
                if (string.Equals(nameText, "SuppressMessage", StringComparison.Ordinal) || string.Equals(nameText, "SuppressMessageAttribute"))
                {
                    return true;
                }
            }
            else if (name.ExpressionType == ExpressionType.MemberAccess)
            {
                Token start = name.FindFirstChild<Token>();
                if (name.MatchTokens(start, new string[] { "System", ".", "Diagnostics", ".", "CodeAnalysis", ".", "SuppressMessage" }) ||
                    name.MatchTokens(start, new string[] { "System", ".", "Diagnostics", ".", "CodeAnalysis", ".", "SuppressMessageAttribute" }))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Extracts the CheckID for the rule being suppressed, from the given Code Analysis SuppressMessage attribute expression.
        /// </summary>
        /// <param name="codeAnalysisAttributeExpression">The expression to parse.</param>
        /// <param name="ruleId">Returns the rule ID.</param>
        /// <param name="ruleName">Returns the rule name.</param>
        /// <param name="ruleNamespace">Returns the namespace that contains the rule.</param>
        /// <returns>Returns true if the ID, name, and namespace were successfully extracted from the suppression.</returns>
        private static bool TryCrackCodeAnalysisSuppression(MethodInvocationExpression codeAnalysisAttributeExpression, out string ruleId, out string ruleName, out string ruleNamespace)
        {
            Param.AssertNotNull(codeAnalysisAttributeExpression, "codeAnalysisAttributeExpression");

            // Initialize all out fields to null.
            ruleId = ruleName = ruleNamespace = null;

            if (codeAnalysisAttributeExpression.Arguments != null && codeAnalysisAttributeExpression.Arguments.Count >= 2)
            {
                // The rule namespace sits in the first argument.
                ruleNamespace = ExtractStringFromAttributeExpression(codeAnalysisAttributeExpression.Arguments[0].Expression);
                if (string.IsNullOrEmpty(ruleNamespace))
                {
                    return false;
                }

                // The checkID and rule name sit in the second argument.
                string nameAndId = ExtractStringFromAttributeExpression(codeAnalysisAttributeExpression.Arguments[1].Expression);
                if (string.IsNullOrEmpty(nameAndId))
                {
                    return false;
                }

                int separatorIndex = nameAndId.IndexOf(':');
                if (separatorIndex == -1)
                {
                    return false;
                }

                ruleId = nameAndId.Substring(0, separatorIndex);
                ruleName = nameAndId.Substring(separatorIndex + 1, nameAndId.Length - separatorIndex - 1);

                return ruleId.Length > 0 && ruleName.Length > 0;
            }
            
            return false;
        }

        /// <summary>
        /// Attempts to extract a string from the given attribute expression, it if is a literal expression containing a string.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <returns>Returns the string or null.</returns>
        private static string ExtractStringFromAttributeExpression(Expression expression)
        {
            Param.Ignore(expression);

            if (expression == null || expression.ExpressionType != ExpressionType.Literal)
            {
                return null;
            }

            LiteralExpression literalExpression = (LiteralExpression)expression;
            if (literalExpression.Token.TokenType != TokenType.String)
            {
                return null;
            }

            string text = literalExpression.Token.Text;
            if (text.StartsWith("\"", StringComparison.Ordinal) && text.EndsWith("\"", StringComparison.Ordinal) && text.Length >= 2)
            {
                return text.Substring(1, text.Length - 2);
            }

            return text;
        }

        #endregion Private Static Methods

        #region Private Methods

        /// <summary>
        /// Parses the body of an element that is enclosed in curly brackets and contains other elements as children.
        /// </summary>
        /// <param name="elementProxy">Proxy for the element being created.</param>
        /// <param name="element">The element to parse.</param>
        /// <param name="partialElements">The collection of partial elements found while parsing the files.</param>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        private void ParseElementContainer(CodeUnitProxy elementProxy, Element element, Dictionary<string, List<Element>> partialElements, bool unsafeCode)
        {
            Param.AssertNotNull(elementProxy, "elementProxy");
            Param.AssertNotNull(element, "element");
            Param.Ignore(partialElements);
            Param.Ignore(unsafeCode);

            // Check to see if the codeUnit is unsafe. This is the case if the codeUnit's parent is unsafe, or if it
            // has the unsafe keyword itself.
            if (!unsafeCode)
            {
                unsafeCode = element.ContainsModifier(TokenType.Unsafe);
            }

            // The next symbol must be an opening curly bracket.
            Symbol symbol = this.PeekNextSymbol();
            if (symbol.SymbolType != SymbolType.OpenCurlyBracket)
            {
                throw this.CreateSyntaxException();
            }

            // Add the bracket token to the document.
            BracketToken openingBracket = (BracketToken)this.GetToken(elementProxy, TokenType.OpenCurlyBracket, SymbolType.OpenCurlyBracket);

            // Parse the contents of the element.
            BracketToken closingBracket = this.ParseElementContainerBody(elementProxy, element, partialElements, unsafeCode);
            
            if (closingBracket == null)
            {
                // If we failed to get a closing bracket back, then there is a syntax
                // error in the document since there is an opening bracket with no matching
                // closing bracket.
                throw this.CreateSyntaxException();
            }

            openingBracket.MatchingBracket = closingBracket;
            closingBracket.MatchingBracket = openingBracket;
        }

        /// <summary>
        /// Parses the body of a container element.
        /// </summary>
        /// <param name="elementProxy">Proxy for the element being created.</param>
        /// <param name="element">The element.</param>
        /// <param name="partialElements">The collection of partial elements found while parsing the files.</param>
        /// <param name="unsafeCode">Indicates whether the code being parsed resides in an unsafe code block.</param>
        /// <returns>Returns the closing curly bracket.</returns>
        private BracketToken ParseElementContainerBody(CodeUnitProxy elementProxy, Element element, Dictionary<string, List<Element>> partialElements, bool unsafeCode)
        {
            Param.AssertNotNull(elementProxy, "elementProxy");
            Param.AssertNotNull(element, "element");
            Param.Ignore(partialElements);
            Param.Ignore(unsafeCode);

            BracketToken closingBracket = null;

            // Keep looping until all the child elements within this container element have been processed.
            while (true)
            {
                var childElementProxy = new CodeUnitProxy();

                // Move past whitespace, preprocessors, comments, xml headers, and attributes, up to the 
                // start of the element.
                ICollection<Attribute> attributes = this.MoveToElementDeclaration(unsafeCode, elementProxy, childElementProxy);

                // Now record whether the element is within a generated code block.
                bool generated = this.symbols.Generated;

                // If the next symbol is a closing curly bracket, or we've reached the end of the symbols list, 
                // we're done with this element.
                Symbol symbol = this.symbols.Peek(1);
                if (symbol == null)
                {
                    // We've reached the end of the document.
                    break;
                }
                else if (symbol.SymbolType == SymbolType.CloseCurlyBracket)
                {
                    // In case anything was referenced to the childElementReference object, which is never going to get assigned
                    // to an element since there aren't anymore elements, point this referece to the parent element.
                    foreach (CodeUnit codeUnit in childElementProxy.Children)
                    {
                        elementProxy.Children.Add(codeUnit);
                    }

                    // We've reached the end of the parent element. Save the closing bracket and exit.
                    closingBracket = (BracketToken)this.GetToken(elementProxy, TokenType.CloseCurlyBracket, SymbolType.CloseCurlyBracket);
                    break;
                }

                // Figure out the type of the next child element.
                ElementType? childElementType = this.GetElementType(element, unsafeCode);

                // If the type of the element could not be determined, then there must be a syntax error in the code.
                if (childElementType == null || !SanityCheckElementTypeAgainstParent(childElementType.Value, element))
                {
                    throw this.CreateSyntaxException();
                }

                // Parse the element.
                Element childElement = this.GetElement(childElementProxy, childElementType.Value, element, partialElements, unsafeCode, generated, attributes);
                elementProxy.Children.Add(childElement);

                // Add any suppressed rules.
                this.AddRuleSuppressionsForElement(childElement);

                // Set up the new element.
                childElement.Initialize(this.document);

                // Add the element to the collection of partial elements, if necessary.
                AddElementToPartialElementsList(childElement, partialElements);
            }

            return closingBracket;
        }

        /// <summary>
        /// Moves past whitespace, comments, preprocessors, xml headers, and attributes, 
        /// up to the start of the next element.
        /// </summary>
        /// <param name="unsafeCode">Indicates whether the code is unsafe.</param>
        /// <param name="parentProxy">Represents the parent codeUnit.</param>
        /// <param name="elementProxy">Proxy for the element.</param>
        /// <returns>Returns the collection of attributes on the element, if any.</returns>
        private ICollection<Attribute> MoveToElementDeclaration(bool unsafeCode, CodeUnitProxy parentProxy, CodeUnitProxy elementProxy)
        {
            Param.Ignore(unsafeCode);
            Param.AssertNotNull(parentProxy, "parentProxy");
            Param.AssertNotNull(elementProxy, "elementProxy");

            var attributes = new List<Attribute>();

            CodeUnitProxy proxyForNonTokens = parentProxy;
            SkipSymbols skip = SkipSymbols.All & ~SkipSymbols.XmlHeader;

            // Loop past any comments, whitespace, preprocessor statements, xml headers, and element attributes. Keep
            // going until we get to the element itself.
            bool loop = true;
            Symbol symbol = this.PeekNextSymbol(skip, true);
            while (symbol != null && loop)
            {
                this.AdvanceToNextCodeSymbol(proxyForNonTokens, skip);

                switch (symbol.SymbolType)
                {
                    case SymbolType.OpenSquareBracket:
                        // Get the attribute statement.
                        Attribute attribute = this.GetAttribute(elementProxy, unsafeCode);
                        if (attribute == null)
                        {
                            throw new SyntaxException(this.document.SourceCode, symbol.LineNumber);
                        }

                        // Add the attribute to the list of attributes for this element.
                        bool assemblyAttribute = false;
                        foreach (AttributeExpression attributeExpression in attribute.AttributeExpressions)
                        {
                            if (attributeExpression.IsAssemblyAttribute)
                            {
                                assemblyAttribute = true;
                                break;
                            }
                        }

                        if (!assemblyAttribute)
                        {
                            attributes.Add(attribute);
                        }

                        proxyForNonTokens = elementProxy;
                        break;

                    case SymbolType.XmlHeaderLine:
                        // Add the xml header to the element.
                        elementProxy.Children.Add(new XmlHeaderLine(symbol.Text, symbol.Location, this.symbols.Generated));
                        this.symbols.Advance();
                        proxyForNonTokens = elementProxy;
                        break;

                    default:
                        // This must be the start of the element.
                        loop = false;
                        break;
                }

                symbol = this.PeekNextSymbol(skip, true);
            }

            if (symbol == null)
            {
                // We're at the end of the document. Gather up any whitespace, comments, etc., that are below the elements.
                CodeUnit itemToMove = elementProxy.Children.First;
                while (itemToMove != null)
                {
                    CodeUnit nextItem = itemToMove.LinkNode.Next;
                    itemToMove.Detach();
                    parentProxy.Children.Add(itemToMove);
                    itemToMove = nextItem;
                }

                this.AdvanceToNextCodeSymbol(parentProxy);
            }

            // If there aren't any attributes, we want to send null. Otherwise,
            // trim the collection of attributes down to a small array.
            if (attributes.Count == 0)
            {
                return null;
            }

            // Set the attributes as a read-only collection.
            return attributes.ToArray();
        }

        /// <summary>
        /// Figures out the type of the next element.
        /// </summary>
        /// <param name="parent">The parent of the element.</param>
        /// <param name="unsafeCode">Indicates whether the element is contained within a block of unsafe code.</param>
        /// <returns>Returns the element type or null if the element type cannot be determined..</returns>
        /// <remarks>This method assumes that the symbol manager has been advanced past all whitespace,
        /// comments, headers, preprocessors, attributes, etc., and that it is sitting at the beginning
        /// of the next element.</remarks>
        [SuppressMessage(
            "Microsoft.Maintainability", 
            "CA1505:AvoidUnmaintainableCode",
            Justification = "May be simplified later.")] 
        [SuppressMessage(
            "Microsoft.Maintainability", 
            "CA1502:AvoidExcessiveComplexity", 
            Justification = "May be simplified later.")]
        private ElementType? GetElementType(Element parent, bool unsafeCode)
        {
            Param.Ignore(parent);
            Param.Ignore(unsafeCode);

            // Get the next symbol.
            int index = 1;
            Symbol symbol = this.symbols.Peek(index);

            // Indicates whether the element contains a body surrounded by curly brackets.
            bool hasCurlyBrackets = false;

            // Indicates whether this looks like an extern alias directive.
            bool externAlias = false;

            // Indicates whether we've seen an operator keyword.
            bool operatorKeyword = false;

            // Indicates whether to keep going.
            bool loop = true;

            // Returns the element type.
            ElementType? elementType = null;

            // Loop until we've got all the information we need to discover the current element type.
            while (symbol != null && loop)
            {
                switch (symbol.SymbolType)
                {
                    case SymbolType.Class:
                        elementType = ElementType.Class;
                        loop = false;
                        break;

                    case SymbolType.Delegate:
                        elementType = ElementType.Delegate;
                        loop = false;
                        break;

                    case SymbolType.Enum:
                        elementType = ElementType.Enum;
                        loop = false;
                        break;

                    case SymbolType.Event:
                        elementType = ElementType.Event;
                        loop = false;
                        break;

                    case SymbolType.Interface:
                        elementType = ElementType.Interface;
                        loop = false;
                        break;

                    case SymbolType.Namespace:
                        elementType = ElementType.Namespace;
                        loop = false;
                        break;

                    case SymbolType.Struct:
                        elementType = ElementType.Struct;
                        loop = false;
                        break;

                    case SymbolType.Using:
                        elementType = ElementType.UsingDirective;
                        loop = false;
                        break;

                    case SymbolType.Extern:
                        // If the next symbol is 'alias', then this is possibly an extern alias directive.
                        int temp = this.GetNextCodeSymbolIndex(index + 1);
                        if (temp != -1 && this.symbols.Peek(temp).Text == "alias")
                        {
                            externAlias = true;
                        }

                        break;

                    case SymbolType.This:
                        elementType = ElementType.Indexer;
                        loop = false;
                        break;

                    case SymbolType.OpenParenthesis:
                        elementType = ElementType.Method;
                        loop = false;
                        break;

                    case SymbolType.OpenCurlyBracket:
                        hasCurlyBrackets = true;
                        loop = false;
                        break;

                    case SymbolType.Tilde:
                        elementType = ElementType.Destructor;
                        loop = false;
                        break;

                    case SymbolType.Operator:
                        elementType = ElementType.Method;
                        operatorKeyword = false;
                        loop = false;
                        break;

                    case SymbolType.WhiteSpace:
                    case SymbolType.EndOfLine:
                    case SymbolType.Abstract:
                    case SymbolType.Const:
                    case SymbolType.Explicit:
                    case SymbolType.Fixed:
                    case SymbolType.Implicit:
                    case SymbolType.Internal:
                    case SymbolType.New:
                    case SymbolType.Override:
                    case SymbolType.Private:
                    case SymbolType.Protected:
                    case SymbolType.Public:
                    case SymbolType.Readonly:
                    case SymbolType.QualifiedAlias:
                    case SymbolType.Sealed:
                    case SymbolType.Static:
                    case SymbolType.Virtual:
                    case SymbolType.Volatile:
                    case SymbolType.GreaterThan:
                    case SymbolType.LessThan:
                    case SymbolType.Comma:
                    case SymbolType.OpenSquareBracket:
                    case SymbolType.CloseSquareBracket:
                    case SymbolType.MultiLineComment:
                    case SymbolType.SingleLineComment:
                    case SymbolType.PreprocessorDirective:
                    case SymbolType.Dot:
                    case SymbolType.QuestionMark:
                        // Ignore these symbol types and continue.
                        break;

                    case SymbolType.Unsafe:
                        unsafeCode |= true;
                        break;

                    case SymbolType.Multiplication:
                    case SymbolType.LogicalAnd:
                        if (!unsafeCode)
                        {
                            goto default;
                        }

                        break;

                    case SymbolType.Other:
                        if (parent != null)
                        {
                            if (symbol.Text == "get" || symbol.Text == "set")
                            {
                                if (parent is Property || parent is Indexer)
                                {
                                    elementType = ElementType.Accessor;
                                    loop = false;
                                    break;
                                }
                            }
                            else if (symbol.Text == "add" || symbol.Text == "remove")
                            {
                                if (parent is Event)
                                {
                                    elementType = ElementType.Accessor;
                                    loop = false;
                                    break;
                                }
                            }
                        }

                        break;

                    default:
                        // Anything else indicates that we are past the end of the declaration, so we should quit.
                        loop = false;
                        break;
                }

                // Get the next symbol.
                symbol = this.symbols.Peek(++index);
            }

            // If we still don't know the type of the element, it must either be a property or a field.
            if (elementType == null)
            {
                if (hasCurlyBrackets)
                {
                    elementType = ElementType.Property;
                }
                else if (externAlias)
                {
                    elementType = ElementType.ExternAliasDirective;
                }
                else if (index == 2)
                {
                    // Check if this symbol is a semicolon.
                    symbol = this.symbols.Peek(1);
                    if (symbol != null && symbol.SymbolType == SymbolType.Semicolon)
                    {
                        elementType = ElementType.EmptyElement;
                    }
                }
                else
                {
                    elementType = ElementType.Field;
                }
            }
            else if (elementType == ElementType.Method && parent != null && !operatorKeyword)
            {
                // Check whether this is actually a constructor or destructor.
                // Find the first unknown word in the declaration.
                index = 1;
                symbol = this.symbols.Peek(index);
                while (symbol != null)
                {
                    if (symbol.SymbolType == SymbolType.Other)
                    {
                        // Make sure the next symbol is the opening parenthesis, which means this is the name.
                        int temp = this.GetNextCodeSymbolIndex(index + 1);
                        if (temp != -1 && this.symbols.Peek(temp).SymbolType == SymbolType.OpenParenthesis)
                        {
                            if (parent.Name.StartsWith(symbol.Text, StringComparison.Ordinal))
                            {
                                if (parent.Name.Length == symbol.Text.Length ||
                                    parent.Name[symbol.Text.Length] == ' ' ||
                                    parent.Name[symbol.Text.Length] == '<')
                                {
                                    // This is a constructor.
                                    elementType = ElementType.Constructor;
                                    break;
                                }
                            }
                            else if (symbol.Text.StartsWith("~", StringComparison.Ordinal))
                            {
                                string name = symbol.Text.Substring(1, symbol.Text.Length - 1);
                                if (parent.Name.StartsWith(name, StringComparison.Ordinal))
                                {
                                    if (parent.Name.Length == name.Length ||
                                        parent.Name[name.Length] == ' ' ||
                                        parent.Name[name.Length] == '<')
                                    {
                                        // This is a destructor.
                                        elementType = ElementType.Destructor;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    else if (symbol.SymbolType == SymbolType.OpenParenthesis)
                    {
                        // We've gone past the method name.
                        break;
                    }
                    else if (symbol.SymbolType == SymbolType.Dot || symbol.SymbolType == SymbolType.Operator)
                    {
                        // If the declaration contains a dot or an operator keyword, then this cannot be a constructor or destructor.
                        break;
                    }

                    symbol = this.symbols.Peek(++index);
                }
            }

            return elementType;
        }

        /// <summary>
        /// Parses and returns an element.
        /// </summary>
        /// <param name="elementProxy">Proxy object for the element being created.</param>
        /// <param name="elementType">The type of element to parse.</param>
        /// <param name="parentElement">The parent element.</param>
        /// <param name="partialElements">The collection of partial elements found while parsing the files.</param>
        /// <param name="unsafeCode">Indicates whether the code is marked as unsafe.</param>
        /// <param name="generated">Indicates whether the code is marked as generated code.</param>
        /// <param name="attributes">The attributes on the element.</param>
        /// <returns>Returns the element.</returns>
        private Element GetElement(
            CodeUnitProxy elementProxy,
            ElementType elementType,
            Element parentElement,
            Dictionary<string, List<Element>> partialElements,
            bool unsafeCode,
            bool generated,
            ICollection<Attribute> attributes)
        {
            Param.AssertNotNull(elementProxy, "elementProxy");
            Param.Ignore(elementType);
            Param.Ignore(parentElement);
            Param.Ignore(partialElements);
            Param.Ignore(unsafeCode);
            Param.Ignore(generated);
            Param.Ignore(attributes);

            switch (elementType)
            {
                case ElementType.Namespace:
                    return this.GetNamespace(elementProxy, partialElements, unsafeCode, generated, attributes);

                case ElementType.ExternAliasDirective:
                    return this.GetExternAliasDirective(elementProxy, parentElement, generated);

                case ElementType.UsingDirective:
                    return this.GetUsingDirective(elementProxy, parentElement, unsafeCode, generated);

                case ElementType.Class:
                case ElementType.Struct:
                case ElementType.Interface:
                    return this.GetClass(elementProxy, elementType, parentElement, partialElements, unsafeCode, generated, attributes);

                case ElementType.Enum:
                    return this.GetEnum(elementProxy, parentElement, unsafeCode, generated, attributes);

                case ElementType.Delegate:
                    return this.GetDelegate(elementProxy, parentElement, unsafeCode, generated, attributes);

                case ElementType.Field:
                    return this.GetField(elementProxy, parentElement, unsafeCode, generated, attributes);

                case ElementType.Method:
                    return this.GetMethod(elementProxy, parentElement, unsafeCode, generated, attributes);

                case ElementType.Constructor:
                    return this.GetConstructor(elementProxy, parentElement, unsafeCode, generated, attributes);

                case ElementType.Destructor:
                    return this.GetDestructor(elementProxy, parentElement, unsafeCode, generated, attributes);

                case ElementType.Property:
                    return this.GetProperty(elementProxy, parentElement, unsafeCode, generated, attributes);

                case ElementType.Indexer:
                    return this.GetIndexer(elementProxy, parentElement, unsafeCode, generated, attributes);

                case ElementType.Event:
                    return this.GetEvent(elementProxy, parentElement, unsafeCode, generated, attributes);

                case ElementType.Accessor:
                    return this.GetAccessor(elementProxy, parentElement, unsafeCode, generated, attributes);

                case ElementType.EmptyElement:
                    return this.GetEmptyElement(elementProxy, parentElement, unsafeCode, generated);

                default:
                    Debug.Fail("Unexpected element type.");
                    throw new StyleCopException();
            }
        }

        /// <summary>
        /// Parses and returns a namespace.
        /// </summary>
        /// <param name="elementProxy">Proxy for the element being created.</param>
        /// <param name="partialElements">The collection of partial elements found while parsing the files.</param>
        /// <param name="unsafeCode">Indicates whether the code is marked as unsafe.</param>
        /// <param name="generated">Indicates whether the code is marked as generated code.</param>
        /// <param name="attributes">The attributes on the element.</param>
        /// <returns>Returns the element.</returns>
        private Namespace GetNamespace(CodeUnitProxy elementProxy, Dictionary<string, List<Element>> partialElements, bool unsafeCode, bool generated, ICollection<Attribute> attributes)
        {
            Param.AssertNotNull(elementProxy, "elementProxy");
            Param.AssertNotNull(partialElements, "partialElements");
            Param.Ignore(unsafeCode);
            Param.Ignore(generated);
            Param.Ignore(attributes);

            // Add the namespace token.
            this.GetToken(elementProxy, TokenType.Namespace, SymbolType.Namespace);

            // Add the namespace name token.
            Token name = this.GetElementNameToken(elementProxy, unsafeCode);

            // Create the namespace.
            var @namespace = new Namespace(elementProxy, name.Text, attributes, unsafeCode);

            // Parse the body of the namespace.
            this.ParseElementContainer(elementProxy, @namespace, partialElements, unsafeCode);

            return @namespace;
        }

        /// <summary>
        /// Parses and returns a using directive.
        /// </summary>
        /// <param name="elementProxy">Proxy for the element being created.</param>
        /// <param name="parent">The parent of the namespace.</param>
        /// <param name="unsafeCode">Indicates whether the code is marked as unsafe.</param>
        /// <param name="generated">Indicates whether the code is marked as generated code.</param>
        /// <returns>Returns the element.</returns>
        private UsingDirective GetUsingDirective(CodeUnitProxy elementProxy, Element parent, bool unsafeCode, bool generated)
        {
            Param.AssertNotNull(elementProxy, "elementProxy");
            Param.AssertNotNull(parent, "parent");
            Param.Ignore(unsafeCode);
            Param.Ignore(generated);

            // Add the using token.
            this.GetToken(elementProxy, TokenType.UsingDirective, SymbolType.Using);

            // The next symbol will either be the namespace, or an alias. To determine this, look past this to see if there is an equals sign.
            int index = this.GetNextCodeSymbolIndex(1);
            if (index == -1)
            {
                throw this.CreateSyntaxException();
            }

            Symbol peekAhead = this.symbols.Peek(index);
            if (peekAhead.SymbolType != SymbolType.Other)
            {
                throw this.CreateSyntaxException();
            }

            index = this.GetNextCodeSymbolIndex(index + 1);
            if (index == -1)
            {
                throw this.CreateSyntaxException();
            }

            Token alias = null;

            peekAhead = this.symbols.Peek(index);
            if (peekAhead.SymbolType == SymbolType.Equals)
            {
                // There is an alias. First collect the alias.
                alias = this.GetToken(elementProxy, TokenType.Literal, SymbolType.Other);

                // Next collect the equals sign.
                this.GetOperatorSymbolToken(elementProxy, OperatorType.Equals);
            }

            // Collect and add the namespace token.
            TypeToken @namespace = this.GetTypeToken(elementProxy, unsafeCode, false);

            // Get the closing semicolon.
            this.GetToken(elementProxy, TokenType.Semicolon, SymbolType.Semicolon);

            // Create the using directive.
            return new UsingDirective(elementProxy, alias == null ? @namespace.Text : alias.Text, @namespace.Text, alias == null ? null : alias.Text);
        }

        /// <summary>
        /// Parses and returns a extern alias directive.
        /// </summary>
        /// <param name="elementProxy">Proxy for the element being created.</param>
        /// <param name="parent">The parent of the namespace.</param>
        /// <param name="generated">Indicates whether the code is marked as generated code.</param>
        /// <returns>Returns the element.</returns>
        private ExternAliasDirective GetExternAliasDirective(CodeUnitProxy elementProxy, Element parent, bool generated)
        {
            Param.AssertNotNull(elementProxy, "elementProxy");
            Param.AssertNotNull(parent, "parent");
            Param.Ignore(generated);

            // Add the extern token.
            this.GetToken(elementProxy, TokenType.ExternDirective, SymbolType.Extern);

            // Add the alias token.
            this.GetToken(elementProxy, TokenType.Alias, SymbolType.Other);

            // Add the identifier token.
            Token identifier = this.GetToken(elementProxy, TokenType.Literal, SymbolType.Other);

            // Get the closing semicolon.
            this.GetToken(elementProxy, TokenType.Semicolon, SymbolType.Semicolon);

            // Create the extern alias directive.
            return new ExternAliasDirective(elementProxy, identifier.Text);
        }

        /// <summary>
        /// Parses and returns a class, struct, or interface.
        /// </summary>
        /// <param name="elementProxy">Proxy object for the element being created.</param>
        /// <param name="elementType">The type of the element.</param>
        /// <param name="parentElement">The parent of the element.</param>
        /// <param name="partialElements">The collection of partial elements found while parsing the files.</param>
        /// <param name="unsafeCode">Indicates whether the code is marked as unsafe.</param>
        /// <param name="generated">Indicates whether the code is marked as generated code.</param>
        /// <param name="attributes">The attributes on the element.</param>
        /// <returns>Returns the element.</returns>
        private ClassBase GetClass(
            CodeUnitProxy elementProxy,
            ElementType elementType,
            Element parentElement,
            Dictionary<string, List<Element>> partialElements,
            bool unsafeCode,
            bool generated,
            ICollection<Attribute> attributes)
        {
            Param.AssertNotNull(elementProxy, "elementProxy");
            Param.Ignore(elementType);
            Param.AssertNotNull(parentElement, "parentElement");
            Param.AssertNotNull(partialElements, "partialElements");
            Param.Ignore(unsafeCode);
            Param.Ignore(generated);
            Param.Ignore(attributes);

            // Top-level classes, structs, and interfaces received Internal access by default, while classes, structs, and interfaces
            // declared within a class receive Private access by default.
            AccessModifierType accessModifier = AccessModifierType.Internal;
            if (parentElement.ElementType == ElementType.Class)
            {
                accessModifier = AccessModifierType.Private;
            }

            // Get the modifiers and access.
            Dictionary<TokenType, Token> modifiers = this.GetElementModifiers(elementProxy, ref accessModifier, ClassModifiers);

            unsafeCode |= modifiers.ContainsKey(TokenType.Unsafe);

            // Get the element keyword, depending on the element type.
            TokenType keywordType = TokenType.Class;
            SymbolType symbolType = SymbolType.Class;
            if (elementType == ElementType.Struct)
            {
                keywordType = TokenType.Struct;
                symbolType = SymbolType.Struct;
            }
            else if (elementType == ElementType.Interface)
            {
                keywordType = TokenType.Interface;
                symbolType = SymbolType.Interface;
            }
            else
            {
                Debug.Assert(
                    elementType == ElementType.Class, 
                    "The method can only be called for a class, struct, or interface");
            }

            // Add the keyword token.
            this.GetToken(elementProxy, keywordType, symbolType);
            
            // Add the class name token.
            Token name = this.GetElementNameToken(elementProxy, unsafeCode);

            // Get the base classes.
            Symbol symbol = this.PeekNextSymbol();

            if (symbol.SymbolType == SymbolType.Colon)
            {
                // Add the colon token.
                this.GetToken(elementProxy, TokenType.BaseColon, SymbolType.Colon);

                // Get each of the base classes and interfaces.
                while (true)
                {
                    this.GetTypeToken(elementProxy, unsafeCode, false);

                    symbol = this.PeekNextSymbol();
                    if (symbol.SymbolType != SymbolType.Comma)
                    {
                        break;
                    }

                    this.GetToken(elementProxy, TokenType.Comma, SymbolType.Comma);
                }
            }

            // Check whether there are any type constraint clauses.
            ICollection<TypeParameterConstraintClause> typeConstraints = null;
            symbol = this.PeekNextSymbol();
            if (symbol.Text == "where")
            {
                typeConstraints = this.GetTypeConstraintClauses(elementProxy, unsafeCode);
            }

            // Create the element.
            ClassBase item = null;
            if (keywordType == TokenType.Class)
            {
                item = new Class(elementProxy, name.Text, attributes, typeConstraints, unsafeCode);
            }
            else if (keywordType == TokenType.Struct)
            {
                item = new Struct(elementProxy, name.Text, attributes, typeConstraints, unsafeCode);
            }
            else
            {
                Debug.Assert(keywordType == TokenType.Interface, "Invalid element type");
                item = new Interface(elementProxy, name.Text, attributes, typeConstraints, unsafeCode);
            }

            // Parse the body of the element.
            this.ParseElementContainer(elementProxy, item, partialElements, unsafeCode);

            return item;
        }

        /// <summary>
        /// Parses and returns an enum.
        /// </summary>
        /// <param name="elementProxy">Proxy for the element being created.</param>
        /// <param name="parent">The parent of the element.</param>
        /// <param name="unsafeCode">Indicates whether the code is marked as unsafe.</param>
        /// <param name="generated">Indicates whether the code is marked as generated code.</param>
        /// <param name="attributes">The attributes on the element.</param>
        /// <returns>Returns the element.</returns>
        private Enum GetEnum(CodeUnitProxy elementProxy, Element parent, bool unsafeCode, bool generated, ICollection<Attribute> attributes)
        {
            Param.AssertNotNull(elementProxy, "elementProxy");
            Param.AssertNotNull(parent, "parent");
            Param.Ignore(unsafeCode);
            Param.Ignore(generated);
            Param.Ignore(attributes);

            // The access defaults to public for a top-level element, or private for a nested element.
            AccessModifierType accessModifier = AccessModifierType.Public;
            if (parent.ElementType == ElementType.Class || parent.ElementType == ElementType.Struct)
            {
                accessModifier = AccessModifierType.Private;
            }

            // Get the modifiers and access.
            this.GetElementModifiers(elementProxy, ref accessModifier, EnumModifiers);

            // Get the enum keyword.
            this.GetToken(elementProxy, TokenType.Enum, SymbolType.Enum);

            // Add the enum name token.
            Token name = this.GetElementNameToken(elementProxy, unsafeCode);

            // Get the base type.
            Symbol symbol = this.PeekNextSymbol();

            if (symbol.SymbolType == SymbolType.Colon)
            {
                // Add the colon token and the base codeUnit name.
                this.GetToken(elementProxy, TokenType.BaseColon, SymbolType.Colon);
                this.GetTypeToken(elementProxy, unsafeCode, false);
            }

            // Create the enum element.
            var @enum = new Enum(elementProxy, name.Text, attributes, unsafeCode);

            // Get the opening curly bracket.
            BracketToken openingCurlyBracket = (BracketToken)this.GetToken(elementProxy, TokenType.OpenCurlyBracket, SymbolType.OpenCurlyBracket);

            // Get each of the enum items.
            @enum.Items = this.GetEnumItems(elementProxy, @enum, unsafeCode);

            // Get the closing curly bracket.
            BracketToken closingCurlyBracket = (BracketToken)this.GetToken(elementProxy, TokenType.CloseCurlyBracket, SymbolType.CloseCurlyBracket);

            openingCurlyBracket.MatchingBracket = closingCurlyBracket;
            closingCurlyBracket.MatchingBracket = openingCurlyBracket;

            return @enum;
        }

        /// <summary>
        /// Parses and returns the items within an enum element.
        /// </summary>
        /// <param name="parentProxy">Represents the parent codeUnit.</param>
        /// <param name="parent">The parent enum element.</param>
        /// <param name="unsafeCode">Indicates whether the enum lies within unsafe code.</param>
        /// <returns>Returns the element.</returns>
        private ICollection<EnumItem> GetEnumItems(CodeUnitProxy parentProxy, Enum parent, bool unsafeCode)
        {
            Param.AssertNotNull(parentProxy, "parentProxy");
            Param.AssertNotNull(parent, "parent");
            Param.Ignore(unsafeCode);

            var enumItems = new List<EnumItem>();

            SkipSymbols skip = SkipSymbols.All;
            Symbol symbol = this.PeekNextSymbol(skip);

            while (symbol.SymbolType != SymbolType.CloseCurlyBracket)
            {
                var enumItemProxy = new CodeUnitProxy();
                ICollection<Attribute> attributes = this.MoveToElementDeclaration(unsafeCode, parentProxy, enumItemProxy);

                // If the next symbol is a close curly bracket, quit.
                symbol = this.PeekNextSymbol();
                if (symbol.SymbolType == SymbolType.CloseCurlyBracket)
                {
                    break;
                }

                // Get the enum codeUnit name.
                Token name = this.GetToken(enumItemProxy, TokenType.Literal, SymbolType.Other);

                Expression initializationExpression = null;

                // See if there is an equals sign.
                symbol = this.PeekNextSymbol();
                if (symbol.SymbolType == SymbolType.Equals)
                {
                    this.GetOperatorSymbolToken(enumItemProxy, OperatorType.Equals);

                    // Get the constant expression being assigned.
                    initializationExpression = this.GetNextExpression(enumItemProxy, ExpressionPrecedence.None, unsafeCode);
                }

                var enumItem = new EnumItem(enumItemProxy, name.Text, attributes, initializationExpression, unsafeCode);

                parentProxy.Children.Add(enumItem);
                enumItems.Add(enumItem);
                
                symbol = this.PeekNextSymbol();

                // If the symbol is not a comma, quit.
                if (symbol.SymbolType == SymbolType.Comma)
                {
                    this.GetToken(parentProxy, TokenType.Comma, SymbolType.Comma);
                }
                else
                {
                    break;
                }

                symbol = this.PeekNextSymbol(skip);
            }

            // Return the enum items as a read-only collection.
            return enumItems.ToArray();
        }

        /// <summary>
        /// Parses and returns a delegate.
        /// </summary>
        /// <param name="elementProxy">Proxy for the element being created.</param>
        /// <param name="parent">The parent of the element.</param>
        /// <param name="unsafeCode">Indicates whether the code is marked as unsafe.</param>
        /// <param name="generated">Indicates whether the code is marked as generated code.</param>
        /// <param name="attributes">The attributes on the element.</param>
        /// <returns>Returns the element.</returns>
        private Delegate GetDelegate(CodeUnitProxy elementProxy, Element parent, bool unsafeCode, bool generated, ICollection<Attribute> attributes)
        {
            Param.AssertNotNull(elementProxy, "elementProxy");
            Param.AssertNotNull(parent, "parent");
            Param.Ignore(unsafeCode);
            Param.Ignore(generated);
            Param.Ignore(attributes);

            // The access defaults to public for a top-level element, or private for a nested element.
            AccessModifierType accessModifier = AccessModifierType.Public;
            if (parent.ElementType == ElementType.Class || parent.ElementType == ElementType.Struct)
            {
                accessModifier = AccessModifierType.Private;
            }

            // Get the modifiers and access.
            Dictionary<TokenType, Token> modifiers = this.GetElementModifiers(elementProxy, ref accessModifier, DelegateModifiers);

            unsafeCode |= modifiers.ContainsKey(TokenType.Unsafe);

            // Get the delegate keyword.
            this.GetToken(elementProxy, TokenType.Delegate, SymbolType.Delegate);

            // Get the return type.
            TypeToken returnType = this.GetTypeToken(elementProxy, unsafeCode, true);

            // Get the name of the delegate.
            Token name = this.GetElementNameToken(elementProxy, unsafeCode);

            // Get the parameter list.
            this.GetParameterList(elementProxy, unsafeCode, SymbolType.OpenParenthesis);

            // Check whether there are any type constraint clauses.
            ICollection<TypeParameterConstraintClause> typeConstraints = null;
            Symbol symbol = this.PeekNextSymbol();
            if (symbol.Text == "where")
            {
                typeConstraints = this.GetTypeConstraintClauses(elementProxy, unsafeCode);
            }

            // Get the closing semicolon.
            this.GetToken(elementProxy, TokenType.Semicolon, SymbolType.Semicolon);

            return new Delegate(elementProxy, name.Text, attributes, returnType, typeConstraints, unsafeCode);
        }

        /// <summary>
        /// Parses and returns a field.
        /// </summary>
        /// <param name="elementProxy">Proxy for the element being created.</param>
        /// <param name="parent">The parent of the element.</param>
        /// <param name="unsafeCode">Indicates whether the code is marked as unsafe.</param>
        /// <param name="generated">Indicates whether the code is marked as generated code.</param>
        /// <param name="attributes">The attributes on the element.</param>
        /// <returns>Returns the element.</returns>
        private Field GetField(CodeUnitProxy elementProxy, Element parent, bool unsafeCode, bool generated, ICollection<Attribute> attributes)
        {
            Param.AssertNotNull(elementProxy, "elementProxy");
            Param.AssertNotNull(parent, "parent");
            Param.Ignore(unsafeCode);
            Param.Ignore(generated);
            Param.Ignore(attributes);

            // Get the modifiers and access.
            AccessModifierType accessModifier = AccessModifierType.Private;
            Dictionary<TokenType, Token> modifiers = this.GetElementModifiers(elementProxy, ref accessModifier, FieldModifiers);

            unsafeCode |= modifiers.ContainsKey(TokenType.Unsafe);

            var declarationExpressionProxy = new CodeUnitProxy();

            // Get the field type.
            var fieldTypeExpressionProxy = new CodeUnitProxy();
            TypeToken fieldType = this.GetTypeToken(fieldTypeExpressionProxy, unsafeCode, true);
            var fieldTypeExpression = new LiteralExpression(fieldTypeExpressionProxy, fieldType);
            declarationExpressionProxy.Children.Add(fieldTypeExpression);

            // Get all of the variable declarators.
            IList<VariableDeclaratorExpression> declarators = this.GetFieldDeclarators(declarationExpressionProxy, unsafeCode, fieldType);

            if (declarators.Count == 0)
            {
                throw this.CreateSyntaxException();
            }

            var variableDeclarationStatementProxy = new CodeUnitProxy();
            var declarationExpression = new VariableDeclarationExpression(declarationExpressionProxy, fieldTypeExpression, declarators);
            variableDeclarationStatementProxy.Children.Add(declarationExpression);

            var field = new Field(elementProxy, declarators[0].Identifier.Text, attributes, fieldType, unsafeCode);

            var variableDeclarationStatement = new VariableDeclarationStatement(variableDeclarationStatementProxy, field.Const, declarationExpression);
            elementProxy.Children.Add(variableDeclarationStatement);

            // Get the trailing semicolon.
            this.GetToken(elementProxy, TokenType.Semicolon, SymbolType.Semicolon);

            return field;
        }

        /// <summary>
        /// Parses and returns the declarators for a field.
        /// </summary>
        /// <param name="parentProxy">Represents the parent codeUnit.</param>
        /// <param name="unsafeCode">Indicates whether the code is marked as unsafe.</param>
        /// <param name="fieldType">The field type.</param>
        /// <returns>Returns the declarators.</returns>
        private IList<VariableDeclaratorExpression> GetFieldDeclarators(CodeUnitProxy parentProxy, bool unsafeCode, TypeToken fieldType)
        {
            Param.AssertNotNull(parentProxy, "parentProxy");
            Param.Ignore(unsafeCode);
            Param.AssertNotNull(fieldType, "fieldType");

            var declarators = new List<VariableDeclaratorExpression>();
            Symbol symbol = this.PeekNextSymbol();

            while (symbol.SymbolType != SymbolType.Semicolon)
            {
                this.AdvanceToNextCodeSymbol(parentProxy);
                var declaratorProxy = new CodeUnitProxy();

                // Get the identifier.
                var identifierExpressionProxy = new CodeUnitProxy();
                Token identifier = this.GetElementNameToken(identifierExpressionProxy, unsafeCode, true);

                var identifierExpression = new LiteralExpression(identifierExpressionProxy, identifier);
                declaratorProxy.Children.Add(identifierExpression);

                Expression initialization = null;

                // Check whether there is an equals sign.
                symbol = this.PeekNextSymbol();
                if (symbol.SymbolType == SymbolType.Equals)
                {
                    this.GetOperatorSymbolToken(declaratorProxy, OperatorType.Equals);

                    // Get the expression after the equals sign. If the expression starts with an
                    // opening curly bracket, then this is an initialization expression or an
                    // anonymous type initialization expression.
                    symbol = this.PeekNextSymbol();
                    if (symbol.SymbolType == SymbolType.OpenCurlyBracket)
                    {
                        // Determine whether this is an array or an anonymous type.
                        if (fieldType.Text == "var" || (
                            fieldType.Text != "Array" && fieldType.Text != "System.Array" && !fieldType.Text.Contains("[")))
                        {
                            initialization = this.GetAnonymousTypeInitializerExpression(declaratorProxy, unsafeCode);
                        }
                        else
                        {
                            initialization = this.GetArrayInitializerExpression(declaratorProxy, unsafeCode);
                        }
                    }
                    else
                    {
                        initialization = this.GetNextExpression(declaratorProxy, ExpressionPrecedence.None, unsafeCode);
                    }

                    if (initialization == null)
                    {
                        throw this.CreateSyntaxException();
                    }
                }

                var declaratorExpression = new VariableDeclaratorExpression(declaratorProxy, identifierExpression, initialization);

                parentProxy.Children.Add(declaratorExpression);
                declarators.Add(declaratorExpression);

                // If the next symbol is a comma, continue.
                symbol = this.PeekNextSymbol();
                if (symbol.SymbolType == SymbolType.Comma)
                {
                    this.GetToken(parentProxy, TokenType.Comma, SymbolType.Comma);
                    symbol = this.PeekNextSymbol();
                }
            }

            // Return the declarators as a read-only collection.
            return declarators.ToArray();
        }

        /// <summary>
        /// Parses and returns a method.
        /// </summary>
        /// <param name="elementProxy">Proxy for the element being created.</param>
        /// <param name="parentElement">The parent of the element.</param>
        /// <param name="unsafeCode">Indicates whether the code is marked as unsafe.</param>
        /// <param name="generated">Indicates whether the code is marked as generated code.</param>
        /// <param name="attributes">The attributes on the element.</param>
        /// <returns>Returns the element.</returns>
        private Method GetMethod(CodeUnitProxy elementProxy, Element parentElement, bool unsafeCode, bool generated, ICollection<Attribute> attributes)
        {
            Param.AssertNotNull(elementProxy, "elementProxy");
            Param.AssertNotNull(parentElement, "parentElement");
            Param.Ignore(unsafeCode);
            Param.Ignore(generated);
            Param.Ignore(attributes);

            // Get the modifiers and access.
            AccessModifierType accessModifier = AccessModifierType.Private;

            // Methods within interfaces always have the access of the parent interface.
            Interface parentInterface = parentElement as Interface;
            if (parentInterface != null)
            {
                accessModifier = parentInterface.AccessLevel;
            }

            // Get the declared modifiers for the method.
            Dictionary<TokenType, Token> modifiers = this.GetElementModifiers(elementProxy, ref accessModifier, MethodModifiers);
            unsafeCode |= modifiers.ContainsKey(TokenType.Unsafe);

            TypeToken returnType = null;
            if (!modifiers.ContainsKey(TokenType.Implicit) && !modifiers.ContainsKey(TokenType.Explicit))
            {
                // Get the return type.
                returnType = this.GetTypeToken(elementProxy, unsafeCode, true);
            }

            // Get the name of the method.
            string methodName = null;
            
            Symbol symbol = this.PeekNextSymbol();
            if (symbol.SymbolType == SymbolType.Operator)
            {
                this.GetToken(elementProxy, TokenType.Operator, SymbolType.Operator);

                // Advance up to the next symbol.
                this.AdvanceToNextCodeSymbol(elementProxy);

                // The overloaded codeUnit will either be a type or a symbol.
                int endIndex = -1;
                Token operatorType = null;
                
                if (this.HasTypeSignature(1, unsafeCode, out endIndex))
                {
                    // The overloaded codeUnit is a type.
                    operatorType = this.GetTypeToken(elementProxy, unsafeCode, true);
                }
                else
                {
                    // The overloaded codeUnit is a symbol.
                    operatorType = this.ConvertOperatorOverloadSymbol();
                    elementProxy.Children.Add(operatorType);
                }

                methodName = "operator " + operatorType.Text;
            }
            else
            {
                Token name = this.GetElementNameToken(elementProxy, unsafeCode);
                methodName = name.Text;
            }

            // Get the parameter list.
            this.GetParameterList(elementProxy, unsafeCode, SymbolType.OpenParenthesis, modifiers.ContainsKey(TokenType.Static));

            // Check whether there are any type constraint clauses.
            ICollection<TypeParameterConstraintClause> typeConstraints = null;
            symbol = this.PeekNextSymbol();
            if (symbol.Text == "where")
            {
                typeConstraints = this.GetTypeConstraintClauses(elementProxy, unsafeCode);
            }

            // Create the declaration.
            var method = new Method(elementProxy, methodName, attributes, returnType, typeConstraints, unsafeCode);

            // If the element is extern, abstract, or containing within an interface, it will not have a body.
            if (modifiers.ContainsKey(TokenType.Abstract) || modifiers.ContainsKey(TokenType.Extern) || parentElement.ElementType == ElementType.Interface)
            {
                // Get the closing semicolon.
                this.GetToken(elementProxy, TokenType.Semicolon, SymbolType.Semicolon);
            }
            else
            {
                // Get the method body.
                this.ParseStatementContainer(elementProxy, method, true, unsafeCode);
            }

            return method;
        }

        /// <summary>
        /// Parses and returns a constructor.
        /// </summary>
        /// <param name="elementProxy">Proxy for the element being created.</param>
        /// <param name="parent">The parent of the element.</param>
        /// <param name="unsafeCode">Indicates whether the code is marked as unsafe.</param>
        /// <param name="generated">Indicates whether the code is marked as generated code.</param>
        /// <param name="attributes">The attributes on the element.</param>
        /// <returns>Returns the element.</returns>
        private Constructor GetConstructor(CodeUnitProxy elementProxy, Element parent, bool unsafeCode, bool generated, ICollection<Attribute> attributes)
        {
            Param.AssertNotNull(elementProxy, "elementProxy");
            Param.AssertNotNull(parent, "parent");
            Param.Ignore(unsafeCode);
            Param.Ignore(generated);
            Param.Ignore(attributes);

            // Get the modifiers and access.
            AccessModifierType accessModifier = AccessModifierType.Private;
            Dictionary<TokenType, Token> modifiers = this.GetElementModifiers(elementProxy, ref accessModifier, ConstructorModifiers);

            unsafeCode |= modifiers.ContainsKey(TokenType.Unsafe);

            // Get the name of the constructor.
            Token name = this.GetElementNameToken(elementProxy, unsafeCode);

            // Get the parameter list.
            this.GetParameterList(elementProxy, unsafeCode, SymbolType.OpenParenthesis);

            // Get the constructor initializer if there is one.
            ConstructorInitializerStatement constructorInitializerStatement = null;

            Symbol symbol = this.PeekNextSymbol();
            if (symbol.SymbolType == SymbolType.Colon)
            {
                this.GetToken(elementProxy, TokenType.BaseColon, SymbolType.Colon);

                var constructorInitializerStatementProxy = new CodeUnitProxy();
                var constructorInitializerExpressionProxy = new CodeUnitProxy();

                // The next symbol must be the keyword base or this.
                symbol = this.PeekNextSymbol();
                if (symbol.SymbolType != SymbolType.This && symbol.SymbolType != SymbolType.Base)
                {
                    throw this.CreateSyntaxException();
                }

                var initializerNameExpressionProxy = new CodeUnitProxy();
                Token initializerNameToken = this.GetToken(initializerNameExpressionProxy, TokenType.Literal, symbol.SymbolType);

                // Get the name expression.
                var initializerNameExpression = new LiteralExpression(initializerNameExpressionProxy, initializerNameToken);
                constructorInitializerExpressionProxy.Children.Add(initializerNameExpression);

                // Get the initializer expression.
                var constructorInitializerExpression = this.GetMethodInvocationExpression(constructorInitializerExpressionProxy, initializerNameExpression, ExpressionPrecedence.None, unsafeCode);
                constructorInitializerStatementProxy.Children.Add(constructorInitializerExpression);

                // Create the constructor initializer statement
                constructorInitializerStatement = new ConstructorInitializerStatement(constructorInitializerStatementProxy, constructorInitializerExpression);
                elementProxy.Children.Add(constructorInitializerStatement);
            }

            var constructor = new Constructor(elementProxy, name.Text, attributes, unsafeCode);

            // If the constructor is extern, it will not have a body.
            if (modifiers.ContainsKey(TokenType.Extern))
            {
                // Get the closing semicolon.
                this.GetToken(elementProxy, TokenType.Semicolon, SymbolType.Semicolon);
            }
            else
            {
                // Get the body.
                this.ParseStatementContainer(elementProxy, constructor, true, unsafeCode);
            }

            return constructor;
        }

        /// <summary>
        /// Parses and returns a destructor.
        /// </summary>
        /// <param name="elementProxy">Proxy for the element being created.</param>
        /// <param name="parent">The parent of the element.</param>
        /// <param name="unsafeCode">Indicates whether the code is marked as unsafe.</param>
        /// <param name="generated">Indicates whether the code is marked as generated code.</param>
        /// <param name="attributes">The attributes on the element.</param>
        /// <returns>Returns the element.</returns>
        private Destructor GetDestructor(CodeUnitProxy elementProxy, Element parent, bool unsafeCode, bool generated, ICollection<Attribute> attributes)
        {
            Param.AssertNotNull(elementProxy, "elementProxy");
            Param.AssertNotNull(parent, "parent");
            Param.Ignore(unsafeCode);
            Param.Ignore(generated);
            Param.Ignore(attributes);

            // Get the modifiers and access.
            AccessModifierType accessModifier = AccessModifierType.Private;
            Dictionary<TokenType, Token> modifiers = this.GetElementModifiers(elementProxy, ref accessModifier, DestructorModifiers);

            unsafeCode |= modifiers.ContainsKey(TokenType.Unsafe);

            // Move past the tilde symbol.
            this.GetToken(elementProxy, TokenType.DestructorTilde, SymbolType.Tilde);

            // Get the name of the destructor.
            Token nameToken = this.GetElementNameToken(elementProxy, unsafeCode);

            string destructorName = "~" + nameToken.Text;

            // Get the opening and closing parenthesis.
            BracketToken openingParenthesis = (BracketToken)this.GetToken(elementProxy, TokenType.OpenParenthesis, SymbolType.OpenParenthesis);
            BracketToken closingParenthesis = (BracketToken)this.GetToken(elementProxy, TokenType.CloseParenthesis, SymbolType.CloseParenthesis);

            openingParenthesis.MatchingBracket = closingParenthesis;
            closingParenthesis.MatchingBracket = openingParenthesis;

            var destructor = new Destructor(elementProxy, destructorName, attributes, unsafeCode);

            // If the destructor is extern, it will not have a body.
            if (modifiers.ContainsKey(TokenType.Extern))
            {
                // Get the closing semicolon.
                this.GetToken(elementProxy, TokenType.Semicolon, SymbolType.Semicolon);
            }
            else
            {
                // Get the body.
                this.ParseStatementContainer(elementProxy, destructor, true, unsafeCode);
            }

            return destructor;
        }

        /// <summary>
        /// Parses and returns a property.
        /// </summary>
        /// <param name="elementProxy">Proxy for the element being created.</param>
        /// <param name="parent">The parent of the element.</param>
        /// <param name="unsafeCode">Indicates whether the code is marked as unsafe.</param>
        /// <param name="generated">Indicates whether the code is marked as generated code.</param>
        /// <param name="attributes">The attributes on the element.</param>
        /// <returns>Returns the element.</returns>
        private Property GetProperty(CodeUnitProxy elementProxy, Element parent, bool unsafeCode, bool generated, ICollection<Attribute> attributes)
        {
            Param.AssertNotNull(elementProxy, "elementProxy");
            Param.AssertNotNull(parent, "parent");
            Param.Ignore(unsafeCode);
            Param.Ignore(generated);
            Param.Ignore(attributes);

            // Get the modifiers and access.
            AccessModifierType accessModifier = AccessModifierType.Private;

            // Properties within interfaces always have the access of the parent interface.
            Interface parentInterface = parent as Interface;
            if (parentInterface != null)
            {
                accessModifier = parentInterface.AccessLevel;
            }

            // Get declared modifiers.
            Dictionary<TokenType, Token> modifiers = this.GetElementModifiers(elementProxy, ref accessModifier, PropertyModifiers);

            unsafeCode |= modifiers.ContainsKey(TokenType.Unsafe);

            // Get the return type.
            TypeToken returnType = this.GetTypeToken(elementProxy, unsafeCode, true);

            // Get the name of the property.
            Token name = this.GetElementNameToken(elementProxy, unsafeCode);

            var property = new Property(elementProxy, name.Text, attributes, returnType, unsafeCode);

            // Parse the body of the property.
            this.ParseElementContainer(elementProxy, property, null, unsafeCode);

            return property;
        }

        /// <summary>
        /// Parses and returns an indexer.
        /// </summary>
        /// <param name="elementProxy">Proxy for the element being created.</param>
        /// <param name="parent">The parent of the element.</param>
        /// <param name="unsafeCode">Indicates whether the code is marked as unsafe.</param>
        /// <param name="generated">Indicates whether the code is marked as generated code.</param>
        /// <param name="attributes">The attributes on the element.</param>
        /// <returns>Returns the element.</returns>
        private Indexer GetIndexer(CodeUnitProxy elementProxy, Element parent, bool unsafeCode, bool generated, ICollection<Attribute> attributes)
        {
            Param.AssertNotNull(elementProxy, "elementProxy");
            Param.AssertNotNull(parent, "parent");
            Param.Ignore(unsafeCode);
            Param.Ignore(generated);
            Param.Ignore(attributes);

            // Get the modifiers and access.
            AccessModifierType accessModifier = AccessModifierType.Private;

            // Indexers within interfaces always have the access of the parent interface.
            Interface parentInterface = parent as Interface;
            if (parentInterface != null)
            {
                accessModifier = parentInterface.AccessLevel;
            }

            // Get declared modifiers.
            Dictionary<TokenType, Token> modifiers = this.GetElementModifiers(elementProxy, ref accessModifier, IndexerModifiers);

            unsafeCode |= modifiers.ContainsKey(TokenType.Unsafe);

            // Get the return type.
            TypeToken returnType = this.GetTypeToken(elementProxy, unsafeCode, true);

            // Get the name of the indexer.
            Token name = this.GetElementNameToken(elementProxy, unsafeCode);

            // Get the parameter list.
            this.GetParameterList(elementProxy, unsafeCode, SymbolType.OpenSquareBracket);

            var indexer = new Indexer(elementProxy, name.Text, attributes, returnType, unsafeCode);

            // Parse the body of the indexer.
            this.ParseElementContainer(elementProxy, indexer, null, unsafeCode);

            return indexer;
        }

        /// <summary>
        /// Parses and returns a event.
        /// </summary>
        /// <param name="elementProxy">Proxy for the element being created.</param>
        /// <param name="parent">The parent of the element.</param>
        /// <param name="unsafeCode">Indicates whether the code is marked as unsafe.</param>
        /// <param name="generated">Indicates whether the code is marked as generated code.</param>
        /// <param name="attributes">The attributes on the element.</param>
        /// <returns>Returns the element.</returns>
        private Event GetEvent(CodeUnitProxy elementProxy, Element parent, bool unsafeCode, bool generated, ICollection<Attribute> attributes)
        {
            Param.AssertNotNull(elementProxy, "elementProxy");
            Param.AssertNotNull(parent, "parent");
            Param.Ignore(unsafeCode);
            Param.Ignore(generated);
            Param.Ignore(attributes);

            // Get the modifiers and access.
            AccessModifierType accessModifier = AccessModifierType.Private;

            // Events within interfaces always have the access of the parent interface.
            Interface parentInterface = parent as Interface;
            if (parentInterface != null)
            {
                accessModifier = parentInterface.AccessLevel;
            }

            // Get declared modifiers.
            Dictionary<TokenType, Token> modifiers = this.GetElementModifiers(elementProxy, ref accessModifier, EventModifiers);

            unsafeCode |= modifiers.ContainsKey(TokenType.Unsafe);

            // Get the event keyword.
            this.GetToken(elementProxy, TokenType.Event, SymbolType.Event);

            // Get the event type.
            TypeToken eventHandlerType = this.GetTypeToken(elementProxy, unsafeCode, true);

            // Get the name of the event.
            Token name = this.GetElementNameToken(elementProxy, unsafeCode);

            var @event = new Event(elementProxy, name.Text, attributes, eventHandlerType, unsafeCode);

            Symbol symbol = this.PeekNextSymbol();

            if (symbol.SymbolType == SymbolType.Equals)
            {
                this.GetToken(elementProxy, TokenType.Equals, SymbolType.Equals);
                @event.InitializationExpression = this.GetNextExpression(elementProxy, ExpressionPrecedence.None, unsafeCode);

                this.GetToken(elementProxy, TokenType.Semicolon, SymbolType.Semicolon);
            }
            else if (symbol.SymbolType == SymbolType.Semicolon)
            {
                this.GetToken(elementProxy, TokenType.Semicolon, SymbolType.Semicolon);
            }
            else
            {
                // Parse the body of the event.
                this.ParseElementContainer(elementProxy, @event, null, unsafeCode);
            }

            return @event;
        }

        /// <summary>
        /// Parses and returns a property, indexer, or event accessor.
        /// </summary>
        /// <param name="elementProxy">Proxy for the element being created.</param>
        /// <param name="parent">The parent of the element.</param>
        /// <param name="unsafeCode">Indicates whether the code is marked as unsafe.</param>
        /// <param name="generated">Indicates whether the code is marked as generated code.</param>
        /// <param name="attributes">The attributes on the element.</param>
        /// <returns>Returns the element.</returns>
        private Accessor GetAccessor(CodeUnitProxy elementProxy, Element parent, bool unsafeCode, bool generated, ICollection<Attribute> attributes)
        {
            Param.AssertNotNull(elementProxy, "elementProxy");
            Param.AssertNotNull(parent, "parent");
            Param.Ignore(unsafeCode);
            Param.Ignore(generated);
            Param.Ignore(attributes);

            // Get the modifiers and access.
            AccessModifierType accessModifier = AccessModifierType.Private;
            this.GetElementModifiers(elementProxy, ref accessModifier, null);

            // Get the accessor type token.
            AccessorType accessorType = AccessorType.Get;
            Token accessorName = null;

            Symbol symbol = this.PeekNextSymbol();
            if (symbol.Text == "get")
            {
                accessorName = this.GetToken(elementProxy, TokenType.Get, SymbolType.Other);
                
                if (parent.ElementType != ElementType.Property && parent.ElementType != ElementType.Indexer)
                {
                    throw this.CreateSyntaxException();
                }
            }
            else if (symbol.Text == "set")
            {
                accessorType = AccessorType.Set;
                accessorName = this.GetToken(elementProxy, TokenType.Set, SymbolType.Other);

                if (parent.ElementType != ElementType.Property && parent.ElementType != ElementType.Indexer)
                {
                    throw this.CreateSyntaxException();
                }
            }
            else if (symbol.Text == "add")
            {
                accessorType = AccessorType.Add;
                accessorName = this.GetToken(elementProxy, TokenType.Add, SymbolType.Other);

                if (parent.ElementType != ElementType.Event)
                {
                    throw this.CreateSyntaxException();
                }
            }
            else if (symbol.Text == "remove")
            {
                accessorType = AccessorType.Remove;
                accessorName = this.GetToken(elementProxy, TokenType.Remove, SymbolType.Other);

                if (parent.ElementType != ElementType.Event)
                {
                    throw this.CreateSyntaxException();
                }
            }
            else
            {
                throw this.CreateSyntaxException();
            }

            var accessor = new Accessor(elementProxy, accessorName.Text, accessorType, attributes, unsafeCode);

            // Get the method body.
            this.ParseStatementContainer(elementProxy, accessor, true, unsafeCode);

            return accessor;
        }

        /// <summary>
        /// Parses an element's parameter list.
        /// </summary>
        /// <param name="parentProxy">Represents the parent codeUnit.</param>
        /// <param name="unsafeCode">Indicates whether the code is marked as unsafe.</param>
        /// <param name="openingBracketType">The type of the bracket which opens the parameter list.</param>
        /// <returns>Returns the collection of parameters.</returns>
        private ParameterList GetParameterList(CodeUnitProxy parentProxy, bool unsafeCode, SymbolType openingBracketType)
        {
            Param.AssertNotNull(parentProxy, "parentProxy");
            Param.Ignore(unsafeCode);
            Param.Ignore(openingBracketType);

            return this.GetParameterList(parentProxy, unsafeCode, openingBracketType, false);
        }

        /// <summary>
        /// Parses an element's parameter list.
        /// </summary>
        /// <param name="parentProxy">Represents the parent codeUnit.</param>
        /// <param name="unsafeCode">Indicates whether the code is marked as unsafe.</param>
        /// <param name="openingBracketType">The type of the bracket which opens the parameter list.</param>
        /// <param name="staticMethod">Indicates whether the parameters are part of a static method.</param>
        /// <returns>Returns the collection of parameters.</returns>
        private ParameterList GetParameterList(CodeUnitProxy parentProxy, bool unsafeCode, SymbolType openingBracketType, bool staticMethod)
        {
            Param.AssertNotNull(parentProxy, "parentProxy");
            Param.Ignore(unsafeCode);
            Param.Ignore(openingBracketType);
            Param.Ignore(staticMethod);

            TokenType openingBracketTokenType = TokenType.OpenParenthesis;
            TokenType closingBracketTokenType = TokenType.CloseParenthesis;
            SymbolType closingBracketType = SymbolType.CloseParenthesis;

            if (openingBracketType == SymbolType.OpenSquareBracket)
            {
                openingBracketTokenType = TokenType.OpenSquareBracket;
                closingBracketTokenType = TokenType.CloseSquareBracket;
                closingBracketType = SymbolType.CloseSquareBracket;
            }
            else
            {
                Debug.Assert(
                    openingBracketType == SymbolType.OpenParenthesis, 
                    "The opening bracket type can only be a parenthesis or a square bracket.");
            }

            // Get the opening bracket.
            BracketToken openingParenthesis = (BracketToken)this.GetToken(parentProxy, openingBracketTokenType, openingBracketType);

            // Get each of the parameters.
            Symbol symbol = this.PeekNextSymbol();

            CodeUnitProxy parameterListProxy = new CodeUnitProxy();

            int parameterIndex = 0;

            while (symbol.SymbolType != closingBracketType)
            {
                this.AdvanceToNextCodeSymbol(parameterListProxy);
                CodeUnitProxy parameterProxy = new CodeUnitProxy();

                // Collect attributes on the parameter.
                while (symbol.SymbolType == SymbolType.OpenSquareBracket)
                {
                    this.AdvanceToNextCodeSymbol(parameterProxy);
                    Attribute attribute = this.GetAttribute(parameterProxy, unsafeCode);
                    if (attribute == null)
                    {
                        throw this.CreateSyntaxException();
                    }

                    symbol = this.PeekNextSymbol();
                }

                // If there is a parameter modifier, get it.
                if (symbol.SymbolType == SymbolType.Ref)
                {
                    this.GetToken(parameterProxy, TokenType.Ref, SymbolType.Ref);
                }
                else if (symbol.SymbolType == SymbolType.Out)
                {
                    this.GetToken(parameterProxy, TokenType.Out, SymbolType.Out);
                }
                else if (symbol.SymbolType == SymbolType.Params)
                {
                    this.GetToken(parameterProxy, TokenType.Params, SymbolType.Params);
                }
                else if (symbol.SymbolType == SymbolType.This)
                {
                    // The this keyword indicates that this is an extension method. This is only allowed if 
                    // both of the following are true:
                    // 1. This must be the first parameter.
                    // 2. The element must be a static method.
                    if (parameterIndex == 0 && staticMethod)
                    {
                        this.GetToken(parameterProxy, TokenType.This, SymbolType.This);
                    }
                }

                // Get the parameter type.
                this.GetTypeToken(parameterProxy, unsafeCode, true);

                // Get the parameter name.
                this.GetToken(parameterProxy, TokenType.Literal, SymbolType.Other);

                // Create and add the parameter.
                parameterListProxy.Children.Add(new Parameter(parameterProxy));

                // If the next symbol, is a comma, get the next parameter.
                symbol = this.PeekNextSymbol();
                if (symbol.SymbolType == SymbolType.Comma)
                {
                    this.GetToken(parameterListProxy, TokenType.Comma, SymbolType.Comma);
                    symbol = this.PeekNextSymbol();
                }

                ++parameterIndex;
            }

            // Create and add the parameter list.
            ParameterList parameterList = new ParameterList(parameterListProxy);
            parentProxy.Children.Add(parameterList);

            // Get the closing bracket.
            BracketToken closingParenthesis = (BracketToken)this.GetToken(parentProxy, closingBracketTokenType, closingBracketType);

            openingParenthesis.MatchingBracket = closingParenthesis;
            closingParenthesis.MatchingBracket = openingParenthesis;

            return parameterList;
        }

        /// <summary>
        /// Parses an anonymous method or lambda expression's parameter list.
        /// </summary>
        /// <param name="parentProxy">Represents the parent codeUnit.</param>
        /// <param name="unsafeCode">Indicates whether the code is marked as unsafe.</param>
        /// <returns>Returns the collection of parameters.</returns>
        private ParameterList GetAnonymousMethodParameterList(CodeUnitProxy parentProxy, bool unsafeCode)
        {
            Param.AssertNotNull(parentProxy, "parentProxy");
            Param.Ignore(unsafeCode);

            // Get the opening bracket.
            BracketToken openingParenthesis = (BracketToken)this.GetToken(parentProxy, TokenType.OpenParenthesis, SymbolType.OpenParenthesis);

            var parameterListProxy = new CodeUnitProxy();
            var parameters = new List<Parameter>();

            // Get each of the parameters.
            Symbol symbol = this.PeekNextSymbol();

            while (symbol.SymbolType != SymbolType.CloseParenthesis)
            {
                this.AdvanceToNextCodeSymbol(parameterListProxy);

                var parameterProxy = new CodeUnitProxy();
                ParameterModifiers modifiers = ParameterModifiers.None;

                // If there is a parameter modifier, get it.
                if (symbol.SymbolType == SymbolType.Ref)
                {
                    this.GetToken(parameterProxy, TokenType.Ref, SymbolType.Ref);
                    modifiers |= ParameterModifiers.Ref;
                }
                else if (symbol.SymbolType == SymbolType.Out)
                {
                    this.GetToken(parameterProxy, TokenType.Out, SymbolType.Out);
                    modifiers |= ParameterModifiers.Out;
                }
                else if (symbol.SymbolType == SymbolType.Params)
                {
                    this.GetToken(parameterProxy, TokenType.Params, SymbolType.Params);
                    modifiers |= ParameterModifiers.Params;
                }

                // The first token is either the parameter type in an explicit parameter list, or the parameter name
                // in an implicit parameter list.
                TypeToken firstToken = this.GetTypeToken(parameterProxy, unsafeCode, true);

                // Peek ahead and look at the type of the next token.
                int index = this.GetNextCodeSymbolIndex(1);
                if (index == -1)
                {
                    throw this.CreateSyntaxException();
                }

                symbol = this.symbols.Peek(index);
                if (symbol.SymbolType == SymbolType.Comma || symbol.SymbolType == SymbolType.CloseParenthesis)
                {
                    // There is no type.
                    if (firstToken.Children.Count > 1)
                    {
                        throw this.CreateSyntaxException();
                    }
                }
                else
                {
                    // There is a type and a name. Get the parameter name.
                    this.GetToken(parameterProxy, TokenType.Literal, SymbolType.Other);
                }

                var parameter = new Parameter(parameterProxy);
                parameterListProxy.Children.Add(parameter);
                parameters.Add(parameter);

                // If the next symbol is a comma, get the next parameter.
                symbol = this.PeekNextSymbol();
                if (symbol.SymbolType == SymbolType.Comma)
                {
                    this.GetToken(parameterListProxy, TokenType.Comma, SymbolType.Comma);
                    symbol = this.PeekNextSymbol();
                }
            }

            var parameterList = new ParameterList(parameterListProxy);
            parentProxy.Children.Add(parameterList);

            // Get the closing bracket.
            BracketToken closingParenthesis = (BracketToken)this.GetToken(parentProxy, TokenType.CloseParenthesis, SymbolType.CloseParenthesis);
            
            openingParenthesis.MatchingBracket = closingParenthesis;
            closingParenthesis.MatchingBracket = openingParenthesis;

            return parameterList;
        }

        /// <summary>
        /// Gets the modifiers from an element's declaration.
        /// </summary>
        /// <param name="elementProxy">Proxy for the element being created.</param>
        /// <param name="accessModifier">Returns the access modifier type for the element.</param>
        /// <param name="allowedModifiers">The list of keyword modifiers allowed on the element.</param>
        /// <returns>Returns the collection of modifiers.</returns>
        private Dictionary<TokenType, Token> GetElementModifiers(CodeUnitProxy elementProxy, ref AccessModifierType accessModifier, string[] allowedModifiers)
        {
            Param.AssertNotNull(elementProxy, "elementProxy");
            Param.Ignore(accessModifier);
            Param.Ignore(allowedModifiers);

            Symbol accessModifierSeen = null;
            var modifiers = new Dictionary<TokenType, Token>();

            Symbol symbol = this.PeekNextSymbol();

            while (true)
            {
                if (symbol.SymbolType == SymbolType.Public)
                {
                    // A public access modifier can only be specified if there have been no other access modifiers.
                    if (accessModifierSeen != null)
                    {
                        throw this.CreateSyntaxException();
                    }

                    accessModifier = AccessModifierType.Public;
                    accessModifierSeen = symbol;

                    Token token = this.GetToken(elementProxy, TokenType.Public, SymbolType.Public);
                    modifiers.Add(TokenType.Public, token);
                }
                else if (symbol.SymbolType == SymbolType.Private)
                {
                    // A private access modifier can only be specified if there have been no other access modifiers.
                    if (accessModifierSeen != null)
                    {
                        throw this.CreateSyntaxException();
                    }

                    accessModifier = AccessModifierType.Private;
                    accessModifierSeen = symbol;

                    Token token = this.GetToken(elementProxy, TokenType.Private, SymbolType.Private);
                    modifiers.Add(TokenType.Private, token);
                }
                else if (symbol.SymbolType == SymbolType.Internal)
                {
                    // The access is internal unless we have already seen a protected access
                    // modifier, in which case it is protected internal.
                    if (accessModifierSeen == null)
                    {
                        accessModifier = AccessModifierType.Internal;
                    }
                    else if (accessModifierSeen.SymbolType == SymbolType.Protected)
                    {
                        accessModifier = AccessModifierType.ProtectedInternal;
                    }
                    else
                    {
                        throw this.CreateSyntaxException();
                    }

                    accessModifierSeen = symbol;
                    
                    Token token = this.GetToken(elementProxy, TokenType.Internal, SymbolType.Internal);
                    modifiers.Add(TokenType.Internal, token);
                }
                else if (symbol.SymbolType == SymbolType.Protected)
                {
                    // The access is protected unless we have already seen an internal access
                    // modifier, in which case it is protected internal.
                    if (accessModifierSeen == null)
                    {
                        accessModifier = AccessModifierType.Protected;
                    }
                    else if (accessModifierSeen.SymbolType == SymbolType.Internal)
                    {
                        accessModifier = AccessModifierType.ProtectedInternal;
                    }
                    else
                    {
                        throw this.CreateSyntaxException();
                    }

                    accessModifierSeen = symbol;

                    Token token = this.GetToken(elementProxy, TokenType.Protected, SymbolType.Protected);
                    modifiers.Add(TokenType.Protected, token);
                }
                else
                {
                    if (!this.GetOtherElementModifier(elementProxy, allowedModifiers, modifiers, symbol))
                    {
                        break;
                    }
                }

                symbol = this.PeekNextSymbol();
            }

            return modifiers;
        }

        /// <summary>
        /// Gets another type of modifier for an element declaration.
        /// </summary>
        /// <param name="elementProxy">Proxy for the element being created.</param>
        /// <param name="allowedModifiers">The types of allowed modifiers for the element.</param>
        /// <param name="modifiers">The collection of modifiers on the element.</param>
        /// <param name="symbol">The modifier symbol.</param>
        /// <returns>true to continue collecting modifiers; false to quit.</returns>
        [SuppressMessage(
            "Microsoft.Maintainability", 
            "CA1502:AvoidExcessiveComplexity",
            Justification = "The method contains a switch statement, but it not complex.")]
        private bool GetOtherElementModifier(CodeUnitProxy elementProxy, string[] allowedModifiers, Dictionary<TokenType, Token> modifiers, Symbol symbol)
        {
            Param.AssertNotNull(elementProxy, "elementProxy");
            Param.Ignore(allowedModifiers);
            Param.AssertNotNull(modifiers, "modifiers");
            Param.AssertNotNull(symbol, "symbol");

            bool stop = true;

            // If the modifier is one of the allowed modifiers, store it. Otherwise, we are done.
            if (allowedModifiers != null)
            {
                for (int i = 0; i < allowedModifiers.Length; ++i)
                {
                    if (string.Equals(symbol.Text, allowedModifiers[i], StringComparison.Ordinal))
                    {
                        TokenType modifierType;
                        switch (symbol.SymbolType)
                        {
                            case SymbolType.Abstract:
                                modifierType = TokenType.Abstract;
                                break;

                            case SymbolType.Const:
                                modifierType = TokenType.Const;
                                break;

                            case SymbolType.Explicit:
                                modifierType = TokenType.Explicit;
                                break;

                            case SymbolType.Extern:
                                modifierType = TokenType.Extern;
                                break;

                            case SymbolType.Implicit:
                                modifierType = TokenType.Implicit;
                                break;

                            case SymbolType.New:
                                modifierType = TokenType.New;
                                break;

                            case SymbolType.Override:
                                modifierType = TokenType.Override;
                                break;

                            case SymbolType.Readonly:
                                modifierType = TokenType.Readonly;
                                break;

                            case SymbolType.Sealed:
                                modifierType = TokenType.Sealed;
                                break;

                            case SymbolType.Static:
                                modifierType = TokenType.Static;
                                break;

                            case SymbolType.Unsafe:
                                modifierType = TokenType.Unsafe;
                                break;

                            case SymbolType.Virtual:
                                modifierType = TokenType.Virtual;
                                break;

                            case SymbolType.Volatile:
                                modifierType = TokenType.Volatile;
                                break;

                            case SymbolType.Fixed:
                                modifierType = TokenType.Fixed;
                                break;

                            case SymbolType.Other:
                                if (symbol.Text != "partial")
                                {
                                    goto default;
                                }

                                modifierType = TokenType.Partial;
                                break;

                            default:
                                throw this.CreateSyntaxException();
                        }

                        Token modifier = this.GetToken(elementProxy, modifierType, symbol.SymbolType);
                        modifiers.Add(modifierType, modifier);
                        stop = false;
                        break;
                    }
                }
            }

            return !stop;
        }

        /// <summary>
        /// Parses one or more type constraint clauses.
        /// </summary>
        /// <param name="parentProxy">Represents the parent codeUnit.</param>
        /// <param name="unsafeCode">Indicates whether the code is marked as unsafe.</param>
        /// <returns>Returns the clauses.</returns>
        private ICollection<TypeParameterConstraintClause> GetTypeConstraintClauses(CodeUnitProxy parentProxy, bool unsafeCode)
        {
            Param.AssertNotNull(parentProxy, "parentProxy");
            Param.Ignore(unsafeCode);

            this.AdvanceToNextCodeSymbol(parentProxy);
            var constraintClauses = new List<TypeParameterConstraintClause>();

            Symbol symbol = this.PeekNextSymbol();
            while (symbol.Text == "where")
            {
                var constraintClauseProxy = new CodeUnitProxy();

                this.GetToken(constraintClauseProxy, TokenType.Literal, SymbolType.Other);
                Token typeToken = this.GetToken(constraintClauseProxy, TokenType.Literal, SymbolType.Other);
                this.GetToken(constraintClauseProxy, TokenType.WhereColon, SymbolType.Colon);

                var constraints = new List<Token>();

                while (true)
                {
                    symbol = this.PeekNextSymbol();
                    
                    Token constraintToken = null;

                    if (symbol.SymbolType == SymbolType.Class || symbol.SymbolType == SymbolType.Struct)
                    {
                        // A constraint of type class or struct.
                        constraintToken = this.GetToken(constraintClauseProxy, TokenType.Literal, symbol.SymbolType);
                    }
                    else if (symbol.SymbolType == SymbolType.New)
                    {
                        var constraintTokenProxy = new CodeUnitProxy();

                        // A constructor constraint.
                        this.GetToken(constraintTokenProxy, TokenType.Literal, SymbolType.New);

                        BracketToken openParenthesis = (BracketToken)this.GetToken(constraintTokenProxy, TokenType.OpenParenthesis, SymbolType.OpenParenthesis);
                        BracketToken closeParenthesis = (BracketToken)this.GetToken(constraintTokenProxy, TokenType.CloseParenthesis, SymbolType.CloseParenthesis);

                        openParenthesis.MatchingBracket = closeParenthesis;
                        closeParenthesis.MatchingBracket = openParenthesis;

                        constraintToken = new ConstructorConstraintToken(
                            constraintTokenProxy,
                            CodeUnit.JoinLocations(constraintTokenProxy.Children.First, constraintTokenProxy.Children.Last),
                            constraintTokenProxy.Children.First.Generated);

                        constraintClauseProxy.Children.Add(constraintToken);
                    }
                    else
                    {
                        // A type constraint.
                        constraintToken = this.GetTypeToken(constraintClauseProxy, unsafeCode, true);
                    }

                    constraints.Add(constraintToken);

                    symbol = this.PeekNextSymbol();
                    if (symbol.SymbolType != SymbolType.Comma)
                    {
                        break;
                    }

                    this.GetToken(constraintClauseProxy, TokenType.Comma, SymbolType.Comma);
                }

                // Add the constraints as a read-only collection in a constraint clause.
                var constraintClause = new TypeParameterConstraintClause(constraintClauseProxy, typeToken, constraints.ToArray());
                constraintClauses.Add(constraintClause);

                parentProxy.Children.Add(constraintClause);

                symbol = this.PeekNextSymbol();
            }

            // Return the constraint clauses as a read-only collection.
            return constraintClauses.ToArray();
        }

        /// <summary>
        /// Parses and returns an empty element.
        /// </summary>
        /// <param name="elementProxy">Proxy for the element being created.</param>
        /// <param name="parent">The parent of the namespace.</param>
        /// <param name="unsafeCode">Indicates whether the code is marked as unsafe.</param>
        /// <param name="generated">Indicates whether the code is marked as generated code.</param>
        /// <returns>Returns the element.</returns>
        private EmptyElement GetEmptyElement(CodeUnitProxy elementProxy, Element parent, bool unsafeCode, bool generated)
        {
            Param.AssertNotNull(elementProxy, "elementProxy");
            Param.AssertNotNull(parent, "parent");
            Param.Ignore(unsafeCode);
            Param.Ignore(generated);

            this.GetToken(elementProxy, TokenType.Semicolon, SymbolType.Semicolon);

            // Create the element.
            return new EmptyElement(elementProxy, unsafeCode);
        }

        /// <summary>
        /// Gets a token representing the name of an element.
        /// </summary>
        /// <param name="parentProxy">Represents the parent codeUnit.</param>
        /// <param name="unsafeCode">Indicates whether the code is unsafe.</param>
        /// <returns>Returns the name token.</returns>
        private Token GetElementNameToken(CodeUnitProxy parentProxy, bool unsafeCode)
        {
            Param.AssertNotNull(parentProxy, "parentProxy");
            Param.Ignore(unsafeCode);

            return this.GetElementNameToken(parentProxy, unsafeCode, false);
        }

        /// <summary>
        /// Gets a token representing the name of an element.
        /// </summary>
        /// <param name="parentProxy">Represents the parent of the token.</param>
        /// <param name="unsafeCode">Indicates whether the code is unsafe.</param>
        /// <param name="allowArrayBrackets">Indicates whether the name is allowed to contain array brackets.</param>
        /// <returns>Returns the name token.</returns>
        private Token GetElementNameToken(CodeUnitProxy parentProxy, bool unsafeCode, bool allowArrayBrackets)
        {
            Param.AssertNotNull(parentProxy, "parentProxy");
            Param.Ignore(unsafeCode);
            Param.Ignore(allowArrayBrackets);

            Symbol symbol = this.PeekNextSymbol();
            if (symbol.SymbolType == SymbolType.This)
            {
                // The name of an indexer is 'this'.
                return this.GetToken(parentProxy, TokenType.Literal, SymbolType.This);
            }
            else
            {
                this.AdvanceToNextCodeSymbol(parentProxy);
                TypeToken typeToken = this.GetTypeToken(null, unsafeCode, allowArrayBrackets);
                Debug.Assert(typeToken != null && typeToken.Children.Count > 0, "The name token is invalid.");

                // If the name of the element consists only of a single token, then just return the single token. If the name
                // of the element consists of more than one token, then it is likely a generic element or an explicit interface
                // member implementation, and we need to return the entire type token.
                if (typeToken.Children.Count == 1)
                {
                    Token nameToken = typeToken.FindFirstChild<Token>();
                    Debug.Assert(nameToken != null, "Expected a child token");

                    nameToken.Detach();
                    parentProxy.Children.Add(nameToken);
                    return nameToken;
                }

                parentProxy.Children.Add(typeToken);
                return typeToken;
            }
        }

        /*
        /// <summary>
        /// Gets an xml header.
        /// </summary>
        /// <returns>Returns the header or null if there is no header.</returns>
        /// <param name="parentReference">Reference to the parent code unit.</param>
        private XmlHeader GetXmlHeader(CodeUnitProxy parent)
        {
            Param.AssertNotNull(parent, "parent");

            // Get the first symbol and make sure it is the right type.
            int index = 1;
            Symbol firstSymbol = this.symbols.Peek(index);
            Debug.Assert(firstSymbol != null && firstSymbol.SymbolType == SymbolType.XmlHeaderLine, "Expected an xml documentation header line");

            // Reference to the xml header.
            var xmlHeader = new CodeUnitProxy();

            // Marks the end of the header.
            int end = -1;

            int endOfLineCount = 0;

            // Loop until the entire header is found.
            Symbol symbol = firstSymbol;
            while (symbol != null)
            {
                if (symbol.SymbolType == SymbolType.XmlHeaderLine)
                {
                    // This type of token belongs in the header.
                    end = index;
                    endOfLineCount = 0;
                }
                else if (symbol.SymbolType == SymbolType.EndOfLine)
                {
                    if (++endOfLineCount > 1)
                    {
                        // If there are two newlines in a row, this is the
                        // end of the Xml header.
                        break;
                    }
                }
                else if (symbol.SymbolType == SymbolType.WhiteSpace ||
                    symbol.SymbolType == SymbolType.SingleLineComment)
                {
                    endOfLineCount = 0;
                }
                else
                {
                    // This is the end of the header.
                    break;
                }

                // Advance the index and get the next symbol.
                symbol = this.symbols.Peek(++index);
            }

            // Make sure we've advanced at least one symbol.
            Debug.Assert(end != -1, "Should have advanced at least one symbol");

            // Add all of the symbols for the header to a token list.
            for (int i = 1; i <= end; ++i)
            {
                this.symbols.Advance();
                Debug.Assert(this.symbols.Current != null, "The current symbol should not be null");

                xmlHeader.Children.Add(this.ConvertSymbol(this.symbols.Current, TokenTypeFromSymbolType(this.symbols.Current.SymbolType), xmlHeader.Reference));
            }

            // Get the location of the header.
            CodeLocation location = CodeLocation.Join(firstSymbol.Location, this.symbols.Current.Location);

            // Create the Xml header object.
            return new XmlHeader(xmlHeader, location, this.symbols.Generated, parent.Reference);
        }
        */

        /// <summary>
        /// Adds any suppressions for the given element by scanning the attributes on the element.
        /// </summary>
        /// <param name="element">The element.</param>
        private void AddRuleSuppressionsForElement(Element element)
        {
            Param.Ignore(element);

            if (element != null && element.Attributes != null && element.Attributes.Count > 0)
            {
                foreach (Attribute attribute in element.Attributes)
                {
                    if (attribute.AttributeExpressions != null)
                    {
                        foreach (AttributeExpression attributeExpression in attribute.AttributeExpressions)
                        {
                            if (attributeExpression.Initialization != null)
                            {
                                MethodInvocationExpression methodInvocation = attributeExpression.Initialization as MethodInvocationExpression;
                                if (methodInvocation != null)
                                {
                                    if (IsCodeAnalysisSuppression(methodInvocation.Name))
                                    {
                                        // Crack open the expression and extract the rule checkID.
                                        string checkId;
                                        string ruleName;
                                        string ruleNamespace;

                                        if (TryCrackCodeAnalysisSuppression(methodInvocation, out checkId, out ruleName, out ruleNamespace))
                                        {
                                            Debug.Assert(!string.IsNullOrEmpty(checkId), "Rule ID should not be null");
                                            Debug.Assert(!string.IsNullOrEmpty(ruleName), "Rule Name should not be null");
                                            Debug.Assert(!string.IsNullOrEmpty(ruleNamespace), "Rule Namespace should not be null");

                                            this.parser.AddRuleSuppression(element, checkId, ruleName, ruleNamespace);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        #endregion Private Methods
    }
}
