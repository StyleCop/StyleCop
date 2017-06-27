// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CodeParser.Elements.cs" company="https://github.com/StyleCop">
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
//   The code parser.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// The code parser.
    /// </summary>
    /// <content>
    /// Contains code for parsing elements within a C# file.
    /// </content>
    internal partial class CodeParser
    {
        #region Static Fields

        /// <summary>
        /// The allowable modifiers on a class element.
        /// </summary>
        private static readonly string[] ClassModifiers = new[] { "new", "unsafe", "abstract", "sealed", "static", "partial" };

        /// <summary>
        /// The allowable modifiers on a constructor element.
        /// </summary>
        private static readonly string[] ConstructorModifiers = new[] { "unsafe", "static", "extern" };

        /// <summary>
        /// The allowable modifiers on a delegate element.
        /// </summary>
        private static readonly string[] DelegateModifiers = new[] { "new", "unsafe" };

        /// <summary>
        /// The allowable modifiers on a destructor element.
        /// </summary>
        private static readonly string[] DestructorModifiers = new[] { "unsafe", "extern", "static" };

        /// <summary>
        /// The allowable modifiers on an <see cref="Enum"/> element.
        /// </summary>
        private static readonly string[] EnumModifiers = new[] { "new" };

        /// <summary>
        /// The allowable modifiers on an event element.
        /// </summary>
        private static readonly string[] EventModifiers = new[] { "new", "unsafe", "static", "virtual", "sealed", "override", "abstract", "extern" };

        /// <summary>
        /// The allowable modifiers on a field element.
        /// </summary>
        private static readonly string[] FieldModifiers = new[] { "new", "unsafe", "const", "readonly", "static", "volatile", "fixed" };

        /// <summary>
        /// The allowable modifiers on an indexer element.
        /// </summary>
        private static readonly string[] IndexerModifiers = new[] { "new", "unsafe", "virtual", "sealed", "override", "abstract", "extern" };

        /// <summary>
        /// The allowable modifiers on a method element.
        /// </summary>
        private static readonly string[] MethodModifiers = new[]
                                                               {
                                                                   "new", "unsafe", "static", "virtual", "sealed", "override", "abstract", "extern", "partial", "implicit",
                                                                   "explicit", "async"
                                                               };

        /// <summary>
        /// The allowable modifiers on a property element.
        /// </summary>
        private static readonly string[] PropertyModifiers = new[] { "new", "unsafe", "static", "virtual", "sealed", "override", "abstract", "extern" };

        #endregion

        #region Methods

        /// <summary>
        /// Adds an element to the list of partial elements, if necessary.
        /// </summary>
        /// <param name="element">
        /// The element to add.
        /// </param>
        /// <param name="partialElements">
        /// The collection of partial elements.
        /// </param>
        private static void AddElementToPartialElementsList(CsElement element, Dictionary<string, List<CsElement>> partialElements)
        {
            Param.AssertNotNull(element, "element");
            Param.Ignore(partialElements);

            // If the element is partial, add it to the partial elements list.
            if (element.Declaration.ContainsModifier(CsTokenType.Partial) && element is ClassBase)
            {
                // Ensure that the partialElements parameter is set whenever it needs to be set.
                Debug.Assert(partialElements != null, "The partialElements parameter should always be provided when adding a class, struct, or interface.");

                // If we get here at the partialElements parameter is not set, then, assuming this is not a bug, the only way this
                // can happen is if the code we are parsing contains a class, struct, or interface someplace where it does not belong,
                // for example within a property.
                if (partialElements == null)
                {
                    throw new SyntaxException(element.Document.SourceCode, element.LineNumber);
                }

                List<CsElement> elementList = null;

                lock (partialElements)
                {
                    // Get the partial element list for this element.
                    partialElements.TryGetValue(element.FullNamespaceName, out elementList);

                    if (elementList == null)
                    {
                        // Create a new partial element list for this element name.
                        elementList = new List<CsElement>();
                        partialElements.Add(element.FullNamespaceName, elementList);
                    }
                    else if (elementList.Count > 0)
                    {
                        // Make sure this elements is the same type as the item(s) already in the list.
                        if (elementList[0].ElementType != element.ElementType)
                        {
                            throw new SyntaxException(element.Document.SourceCode, element.Declaration.Tokens.First.Value.LineNumber);
                        }
                    }

                    // Add the element to the list.
                    elementList.Add(element);
                }
            }
        }

        /// <summary>
        /// Attempts to extract a string from the given attribute expression, it if is a literal expression containing a string.
        /// </summary>
        /// <param name="expression">
        /// The expression.
        /// </param>
        /// <returns>
        /// Returns the string or null.
        /// </returns>
        private static string ExtractStringFromAttributeExpression(Expression expression)
        {
            Param.Ignore(expression);

            if (expression == null || expression.ExpressionType != ExpressionType.Literal)
            {
                return null;
            }

            LiteralExpression literalExpression = (LiteralExpression)expression;
            if (literalExpression.Token.CsTokenType != CsTokenType.String)
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

        /// <summary>
        /// Determines whether the given expression is the start of a CodeAnalysis SuppressMessage attribute.
        /// </summary>
        /// <param name="name">
        /// The expression to check.
        /// </param>
        /// <returns>
        /// Returns true if the expression is a CodeAnalysis SuppressMessage; false otherwise.
        /// </returns>
        private static bool IsCodeAnalysisSuppression(Expression name)
        {
            Param.AssertNotNull(name, "name");

            if (name.ExpressionType == ExpressionType.Literal)
            {
                string nameText = name.Text;
                if (string.Equals(nameText, "SuppressMessage", StringComparison.Ordinal) || string.Equals(nameText, "SuppressMessageAttribute"))
                {
                    return true;
                }
            }
            else if (name.ExpressionType == ExpressionType.MemberAccess)
            {
                if (name.Tokens.MatchTokens(new[] { "System", ".", "Diagnostics", ".", "CodeAnalysis", ".", "SuppressMessage" })
                    || name.Tokens.MatchTokens(new[] { "System", ".", "Diagnostics", ".", "CodeAnalysis", ".", "SuppressMessageAttribute" })
                    || name.Tokens.Last.Value.Text.EndsWith("SuppressMessage", StringComparison.Ordinal)
                    || name.Tokens.Last.Value.Text.EndsWith("SuppressMessageAttribute", StringComparison.Ordinal))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Checks the type of an element against the type of its parent to verify that the
        /// parent type can have a child of the given type.
        /// </summary>
        /// <param name="elementType">
        /// The type of the element.
        /// </param>
        /// <param name="parent">
        /// The parent.
        /// </param>
        /// <returns>
        /// Returns true if the parent can have a child of the given type.
        /// </returns>
        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "The method is not complex.")]
        private static bool SanityCheckElementTypeAgainstParent(ElementType elementType, CsElement parent)
        {
            Param.Ignore(elementType);
            Param.Ignore(parent);

            switch (elementType)
            {
                case ElementType.Accessor:
                    return parent != null
                           && (parent.ElementType == ElementType.Property || parent.ElementType == ElementType.Indexer || parent.ElementType == ElementType.Event);

                case ElementType.Class:
                case ElementType.Struct:
                case ElementType.Interface:
                case ElementType.Delegate:
                case ElementType.Enum:
                    return parent != null
                           && (parent.ElementType == ElementType.Root || parent.ElementType == ElementType.Namespace || parent.ElementType == ElementType.Class
                               || parent.ElementType == ElementType.Struct);

                case ElementType.Constructor:
                case ElementType.Destructor:
                    return parent != null && (parent.ElementType == ElementType.Class || parent.ElementType == ElementType.Struct);

                // Field can have a parent of type property (C#6 property initializer).
                case ElementType.Field:
                    return parent != null && (parent.ElementType == ElementType.Class || parent.ElementType == ElementType.Struct || parent.ElementType == ElementType.Property);

                case ElementType.Event:
                case ElementType.Indexer:
                case ElementType.Method:
                case ElementType.Property:
                    return parent != null
                           && (parent.ElementType == ElementType.Class || parent.ElementType == ElementType.Struct || parent.ElementType == ElementType.Interface);

                case ElementType.ConstructorInitializer:
                    return parent != null && parent.ElementType == ElementType.Constructor;

                case ElementType.EnumItem:
                    return parent != null && parent.ElementType == ElementType.Enum;

                case ElementType.File:
                case ElementType.Root:
                    return parent == null;

                case ElementType.ExternAliasDirective:
                case ElementType.Namespace:
                case ElementType.UsingDirective:
                    return parent != null && (parent.ElementType == ElementType.Root || parent.ElementType == ElementType.Namespace);

                case ElementType.AssemblyOrModuleAttribute:
                    return parent != null && parent.ElementType == ElementType.Root;

                case ElementType.EmptyElement:
                    break;

                default:
                    Debug.Fail("Unexpected element type.");
                    break;
            }

            return true;
        }

        /// <summary>
        /// Extracts the CheckID for the rule being suppressed, from the given Code Analysis SuppressMessage attribute expression.
        /// </summary>
        /// <param name="codeAnalysisAttributeExpression">
        /// The expression to parse.
        /// </param>
        /// <param name="ruleId">
        /// Returns the rule ID.
        /// </param>
        /// <param name="ruleName">
        /// Returns the rule name.
        /// </param>
        /// <param name="ruleNamespace">
        /// Returns the namespace that contains the rule.
        /// </param>
        /// <returns>
        /// Returns true if the ID, name, and namespace were successfully extracted from the suppression.
        /// </returns>
        private static bool TryCrackCodeAnalysisSuppression(
            MethodInvocationExpression codeAnalysisAttributeExpression, out string ruleId, out string ruleName, out string ruleNamespace)
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

                // Here we support the old SupressMessage format for Microsoft.StyleCop
                if (ruleNamespace.StartsWith("Microsoft.StyleCop."))
                {
                    ruleNamespace = ruleNamespace.Substring("Microsoft.".Length);
                }

                // The checkID and rule name sit in the second argument.
                string nameAndId = ExtractStringFromAttributeExpression(codeAnalysisAttributeExpression.Arguments[1].Expression);
                if (string.IsNullOrEmpty(nameAndId))
                {
                    return false;
                }

                // When the nameAndId field just contains a *, this means to supress all rules in the given namespace.
                if (nameAndId == "*")
                {
                    ruleId = "*";
                    return true;
                }

                // Split the rule name and ID.
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
        /// Adds any suppressions for the given element by scanning the attributes on the element.
        /// </summary>
        /// <param name="element">
        /// The element.
        /// </param>
        private void AddRuleSuppressionsForElement(CsElement element)
        {
            Param.Ignore(element);

            if (element == null || element.Attributes == null || element.Attributes.Count <= 0)
            {
                return;
            }

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
                                        Debug.Assert(checkId == "*" || !string.IsNullOrEmpty(ruleName), "Rule Name should not be null");
                                        Debug.Assert(!string.IsNullOrEmpty(ruleNamespace), "Rule Namespace should not be null");

                                        CsElement elementToAddSuppressionToo = element is AssemblyOrModuleAttribute ? element.Parent as CsElement : element;

                                        this.parser.AddRuleSuppression(elementToAddSuppressionToo, checkId, ruleName, ruleNamespace);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Gets the modifiers from an element's declaration.
        /// </summary>
        /// <param name="elementReference">
        /// A reference to the element being created.
        /// </param>
        /// <param name="accessModifier">
        /// Returns the access modifier type for the element.
        /// </param>
        /// <param name="allowedModifiers">
        /// The list of keyword modifiers allowed on the element.
        /// </param>
        /// <returns>
        /// Returns the collection of modifiers.
        /// </returns>
        private Dictionary<CsTokenType, CsToken> GetElementModifiers(
            Reference<ICodePart> elementReference, ref AccessModifierType accessModifier, string[] allowedModifiers)
        {
            Param.AssertNotNull(elementReference, "elementReference");
            Param.Ignore(accessModifier);
            Param.Ignore(allowedModifiers);

            Symbol accessModifierSeen = null;
            Dictionary<CsTokenType, CsToken> modifiers = new Dictionary<CsTokenType, CsToken>();

            Symbol symbol = this.GetNextSymbol(elementReference);

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

                    CsToken token = this.GetToken(CsTokenType.Public, SymbolType.Public, elementReference);
                    this.tokens.Add(token);
                    modifiers.Add(CsTokenType.Public, token);
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

                    CsToken token = this.GetToken(CsTokenType.Private, SymbolType.Private, elementReference);
                    this.tokens.Add(token);
                    modifiers.Add(CsTokenType.Private, token);
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

                    CsToken token = this.GetToken(CsTokenType.Internal, SymbolType.Internal, elementReference);
                    this.tokens.Add(token);
                    modifiers.Add(CsTokenType.Internal, token);
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

                    CsToken token = this.GetToken(CsTokenType.Protected, SymbolType.Protected, elementReference);
                    this.tokens.Add(token);
                    modifiers.Add(CsTokenType.Protected, token);
                }
                else
                {
                    if (!this.GetOtherElementModifier(elementReference, allowedModifiers, modifiers, symbol))
                    {
                        break;
                    }
                }

                symbol = this.GetNextSymbol(elementReference);
            }

            return modifiers;
        }

        /// <summary>
        /// Gets a token representing the name of an element.
        /// </summary>
        /// <param name="elementReference">
        /// A reference to the element being created.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code is unsafe.
        /// </param>
        /// <returns>
        /// Returns the name token.
        /// </returns>
        private CsToken GetElementNameToken(Reference<ICodePart> elementReference, bool unsafeCode)
        {
            Param.AssertNotNull(elementReference, "elementReference");
            Param.Ignore(unsafeCode);

            return this.GetElementNameToken(elementReference, unsafeCode, false);
        }

        /// <summary>
        /// Gets a token representing the name of an element.
        /// </summary>
        /// <param name="elementReference">
        /// A reference to the element being created.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code is unsafe.
        /// </param>
        /// <param name="allowArrayBrackets">
        /// Indicates whether the name is allowed to contain array brackets.
        /// </param>
        /// <returns>
        /// Returns the name token.
        /// </returns>
        private CsToken GetElementNameToken(Reference<ICodePart> elementReference, bool unsafeCode, bool allowArrayBrackets)
        {
            Param.AssertNotNull(elementReference, "elementReference");
            Param.Ignore(unsafeCode);
            Param.Ignore(allowArrayBrackets);

            Symbol symbol = this.GetNextSymbol(elementReference);
            if (symbol.SymbolType == SymbolType.This)
            {
                // The name of an indexer is 'this'.
                return this.GetToken(CsTokenType.Other, SymbolType.This, elementReference);
            }
            else
            {
                TypeToken typeToken = this.GetTypeToken(elementReference, unsafeCode, allowArrayBrackets);
                Debug.Assert(typeToken != null && typeToken.ChildTokens.Count > 0, "The name token is invalid.");

                // If the name of the element consists only of a single token, then just return the single token. If the name
                // of the element consists of more than one token, then it is likely a generic element or an explicit interface
                // member implementation, and we need to return the entire type token.
                if (typeToken.ChildTokens.Count == 1)
                {
                    return typeToken.ChildTokens.First.Value;
                }

                return typeToken;
            }
        }

        /// <summary>
        /// Figures out the type of the next element.
        /// </summary>
        /// <param name="parent">
        /// The parent of the element.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the element is contained within a block of unsafe code.
        /// </param>
        /// <returns>
        /// Returns the element type or null if the element type cannot be determined..
        /// </returns>
        /// <remarks>
        /// This method assumes that the symbol manager has been advanced past all whitespace,
        /// comments, headers, preprocessors etc., and that it is sitting at the beginning
        /// of the next element.
        /// </remarks>
        [SuppressMessage("Microsoft.Maintainability", "CA1505:AvoidUnmaintainableCode", Justification = "May be simplified later.")]
        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "May be simplified later.")]
        private ElementType? GetElementType(CsElement parent, bool unsafeCode)
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

            // Indicates we've found an assembly attribute.
            bool assemblyOrModuleAttribute = false;

            // Indicates whether we've seen an operator keyword.
            bool operatorKeyword = false;

            // Count of open angle brackets that are not closed yet.
            int openAngleBracketsNotClosedCount = 0;

            // Count of possible type type declaration inside generics.
            int tupleTypeInsideGenericsCount = 0;

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

                    case SymbolType.Equals:
                        elementType = ElementType.Field;
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
                        // Proceed only if we are not inside an angle bracket, 
                        // Otherwise this could be a generic with tuple inside.
                        if (openAngleBracketsNotClosedCount == 0)
                        {
                            elementType = this.DetectElementTypeForOpenParenthesis(index - 1);
                            loop = false;                            
                        }

                        tupleTypeInsideGenericsCount++;
                        break;

                    case SymbolType.CloseParenthesis:
                        // Allow closing parenthesis if we are in generics with tuple type declaration.
                        if (tupleTypeInsideGenericsCount > 0)
                        {
                            tupleTypeInsideGenericsCount--;
                        }
                        else
                        {
                            loop = false;
                        }

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

                    case SymbolType.OpenSquareBracket:
                        temp = this.GetNextCodeSymbolIndex(index + 1);
                        if (temp != -1 && (this.symbols.Peek(temp).Text == "assembly" || this.symbols.Peek(temp).Text == "module"))
                        {
                            assemblyOrModuleAttribute = true;
                        }

                        break;

                    // Used to check expression bodied
                    case SymbolType.Lambda:
                        // If we are here then this is not a method bodied expression because we don't have parenthesis checked previously.
                        elementType = ElementType.Property;
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
                    case SymbolType.CloseSquareBracket:
                    case SymbolType.MultiLineComment:
                    case SymbolType.SingleLineComment:
                    case SymbolType.PreprocessorDirective:
                    case SymbolType.Dot:
                    case SymbolType.QuestionMark:
                    case SymbolType.Ref:

                        if (symbol.SymbolType == SymbolType.LessThan)
                        {
                            openAngleBracketsNotClosedCount++;
                        }
                        else if (symbol.SymbolType == SymbolType.GreaterThan)
                        {
                            openAngleBracketsNotClosedCount--;                            
                        }

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
                else if (assemblyOrModuleAttribute)
                {
                    elementType = ElementType.AssemblyOrModuleAttribute;
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
                            string symbolText = symbol.Text.TrimStart('@');

                            // Check whether the name of the method matches the name of the parent, and the parent is a class or a struct.
                            if (parent.Declaration.Name.StartsWith(symbolText, StringComparison.Ordinal)
                                && (parent.ElementType == ElementType.Struct || parent.ElementType == ElementType.Class))
                            {
                                if (parent.Declaration.Name.Length == symbolText.Length || parent.Declaration.Name[symbolText.Length] == ' '
                                    || parent.Declaration.Name[symbolText.Length] == '<')
                                {
                                    // This is a constructor.
                                    elementType = ElementType.Constructor;
                                    break;
                                }
                            }
                            else if (symbol.Text.StartsWith("~", StringComparison.Ordinal))
                            {
                                string name = symbol.Text.Substring(1, symbol.Text.Length - 1).TrimStart('@');
                                if (parent.Declaration.Name.StartsWith(name, StringComparison.Ordinal))
                                {
                                    if (parent.Declaration.Name.Length == name.Length || parent.Declaration.Name[name.Length] == ' '
                                        || parent.Declaration.Name[name.Length] == '<')
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
        /// Gets another type of modifier for an element declaration.
        /// </summary>
        /// <param name="elementReference">
        /// A reference to the element being created.
        /// </param>
        /// <param name="allowedModifiers">
        /// The types of allowed modifiers for the element.
        /// </param>
        /// <param name="modifiers">
        /// The collection of modifiers on the element.
        /// </param>
        /// <param name="symbol">
        /// The modifier symbol.
        /// </param>
        /// <returns>
        /// true to continue collecting modifiers; false to quit.
        /// </returns>
        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "The method contains a switch statement, but it not complex.")]
        private bool GetOtherElementModifier(Reference<ICodePart> elementReference, string[] allowedModifiers, Dictionary<CsTokenType, CsToken> modifiers, Symbol symbol)
        {
            Param.AssertNotNull(elementReference, "elementReference");
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
                        CsTokenType modifierType;
                        switch (symbol.SymbolType)
                        {
                            case SymbolType.Abstract:
                                modifierType = CsTokenType.Abstract;
                                break;

                            case SymbolType.Const:
                                modifierType = CsTokenType.Const;
                                break;

                            case SymbolType.Explicit:
                                modifierType = CsTokenType.Explicit;
                                break;

                            case SymbolType.Extern:
                                modifierType = CsTokenType.Extern;
                                break;

                            case SymbolType.Implicit:
                                modifierType = CsTokenType.Implicit;
                                break;

                            case SymbolType.New:
                                modifierType = CsTokenType.New;
                                break;

                            case SymbolType.Override:
                                modifierType = CsTokenType.Override;
                                break;

                            case SymbolType.Readonly:
                                modifierType = CsTokenType.Readonly;
                                break;

                            case SymbolType.Sealed:
                                modifierType = CsTokenType.Sealed;
                                break;

                            case SymbolType.Static:
                                modifierType = CsTokenType.Static;
                                break;

                            case SymbolType.Unsafe:
                                modifierType = CsTokenType.Unsafe;
                                break;

                            case SymbolType.Virtual:
                                modifierType = CsTokenType.Virtual;
                                break;

                            case SymbolType.Volatile:
                                modifierType = CsTokenType.Volatile;
                                break;

                            case SymbolType.Fixed:
                                modifierType = CsTokenType.Fixed;
                                break;

                            case SymbolType.Other:
                                switch (symbol.Text)
                                {
                                    case "partial":
                                        modifierType = CsTokenType.Partial;
                                        break;
                                    case "async":
                                        modifierType = CsTokenType.Async;
                                        break;
                                    default:
                                        goto default;
                                }

                                break;

                            default:
                                throw this.CreateSyntaxException();
                        }

                        CsToken modifier = this.GetToken(modifierType, symbol.SymbolType, elementReference);
                        modifiers.Add(modifierType, modifier);
                        this.tokens.Add(modifier);
                        stop = false;
                        break;
                    }
                }
            }

            return !stop;
        }

        /// <summary>
        /// Gets an xml header.
        /// </summary>
        /// <param name="elementReference">
        /// A reference to the element being created.
        /// </param>
        /// <returns>
        /// Returns the header or null if there is no header.
        /// </returns>
        private XmlHeader GetXmlHeader(Reference<ICodePart> elementReference)
        {
            Param.AssertNotNull(elementReference, "elementReference");

            // Get the first symbol and make sure it is the right type.
            int index = 1;
            Symbol firstSymbol = this.symbols.Peek(index);
            Debug.Assert(firstSymbol != null && firstSymbol.SymbolType == SymbolType.XmlHeaderLine, "Expected an xml documentation header line");

            // Marks the end of the header.
            int end = -1;
            int endOfLineCount = 0;

            Reference<ICodePart> xmlHeaderReference = new Reference<ICodePart>();

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
                else if (symbol.SymbolType == SymbolType.WhiteSpace || symbol.SymbolType == SymbolType.SingleLineComment)
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
            MasterList<CsToken> headerTokens = new MasterList<CsToken>();
            for (int i = 1; i <= end; ++i)
            {
                this.symbols.Advance();
                Debug.Assert(this.symbols.Current != null, "The current symbol should not be null");

                headerTokens.Add(this.ConvertSymbol(this.symbols.Current, TokenTypeFromSymbolType(this.symbols.Current.SymbolType), xmlHeaderReference));
            }

            // Get the location of the header.
            CodeLocation location = CodeLocation.Join(firstSymbol.Location, this.symbols.Current.Location);

            // Create the Xml header object.
            XmlHeader xmlHeader = new XmlHeader(headerTokens, location, elementReference, this.symbols.Generated);
            xmlHeaderReference.Target = xmlHeader;

            return xmlHeader;
        }

        /// <summary>
        /// Initializes a new element.
        /// </summary>
        /// <param name="element">
        /// The element.
        /// </param>
        private void InitializeElement(CsElement element)
        {
            Param.AssertNotNull(element, "element");

            // Get the first token in the element, which is the first token in the element's declaration.
            Debug.Assert(element.Declaration.Tokens.First != null, "The declaration should not be empty");
            Node<CsToken> firstTokenNode = element.Declaration.Tokens.First;

            // Get the last token in the element, which should also be the last token in the document's token list currently.
            Node<CsToken> lastTokenNode = this.tokens.Last;

            // Fill in the token list for the element.
            element.Tokens = new CsTokenList(element.Declaration.Tokens.MasterList, firstTokenNode, lastTokenNode);

            // Fill in the location for the element.
            element.Location = CsToken.JoinLocations(firstTokenNode, lastTokenNode);

            // Now allow the element to parse itself.
            element.Initialize();
        }

        /// <summary>
        /// Moves past whitespace, comments, preprocessors and xml headers up to the start of the next element.
        /// </summary>
        /// <param name="element">
        /// The parent element.
        /// </param>
        /// <param name="parentElementReference">
        /// A reference to the parent element.
        /// </param>
        /// <param name="childElementReference">
        /// A reference to the child element about to be created.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code is unsafe.
        /// </param>
        /// <param name="xmlHeader">
        /// Returns the xml header, if any.
        /// </param>
        /// <param name="attributes">
        /// Returns the list of attributes, if any.
        /// </param>
        private void MoveToElementDeclaration(
            CsElement element,
            Reference<ICodePart> parentElementReference,
            Reference<ICodePart> childElementReference,
            bool unsafeCode,
            out XmlHeader xmlHeader,
            out ICollection<Attribute> attributes)
        {
            Param.AssertNotNull(parentElementReference, "parentElementReference");
            Param.AssertNotNull(childElementReference, "childElementReference");
            Param.Ignore(unsafeCode);

            // Initialize the out parameters.
            xmlHeader = null;

            List<Attribute> tempAttributes = new List<Attribute>();

            SkipSymbols skip = SkipSymbols.All;
            skip &= ~SkipSymbols.XmlHeader;

            Reference<ICodePart> currentElementReference = parentElementReference;

            // Loop past any comments, whitespace, preprocessor statements, xml headers, and element attributes. Keep
            // going until we get to the element itself.
            bool loop = true;
            Symbol symbol = this.GetNextSymbol(skip, currentElementReference, true);
            while (symbol != null && loop)
            {
                switch (symbol.SymbolType)
                {
                    case SymbolType.XmlHeaderLine:

                        // Get the xml header.
                        currentElementReference = childElementReference;
                        xmlHeader = this.GetXmlHeader(childElementReference);
                        if (xmlHeader == null)
                        {
                            throw new SyntaxException(this.document.SourceCode, symbol.LineNumber);
                        }

                        // Add the header to the document.
                        this.tokens.Add(xmlHeader);
                        break;

                    case SymbolType.OpenSquareBracket:

                        // Need to see if its an assembly attribute.
                        // If it is don't process it here.
                        ElementType? nextElementType = this.GetElementType(element, unsafeCode);

                        if (nextElementType == ElementType.AssemblyOrModuleAttribute)
                        {
                            loop = false;
                        }
                        else
                        {
                            // Get the attribute statement.
                            currentElementReference = childElementReference;
                            Attribute attribute = this.GetAttribute(childElementReference, unsafeCode);
                            if (attribute == null)
                            {
                                throw new SyntaxException(this.document.SourceCode, symbol.LineNumber);
                            }

                            tempAttributes.Add(attribute);

                            // Add the attribute to the document.
                            this.tokens.Add(attribute);
                        }

                        break;

                    default:

                        // This must be the start of the element.
                        loop = false;
                        break;
                }

                symbol = this.GetNextSymbol(skip, currentElementReference, true);
            }

            // Set the attributes as a read-only collection.
            attributes = tempAttributes.ToArray();
        }

        /// <summary>
        /// Parses and returns a property, indexer, or event accessor.
        /// </summary>
        /// <param name="parent">
        /// The parent of the element.
        /// </param>
        /// <param name="elementReference">
        /// A reference to the element being created.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code is marked as unsafe.
        /// </param>
        /// <param name="generated">
        /// Indicates whether the code is marked as generated code.
        /// </param>
        /// <param name="xmlHeader">
        /// The element's documentation header.
        /// </param>
        /// <param name="attributes">
        /// The attributes on the element.
        /// </param>
        /// <returns>
        /// Returns the element.
        /// </returns>
        private Accessor ParseAccessor(
            CsElement parent, Reference<ICodePart> elementReference, bool unsafeCode, bool generated, XmlHeader xmlHeader, ICollection<Attribute> attributes)
        {
            Param.AssertNotNull(parent, "parent");
            Param.AssertNotNull(elementReference, "elementReference");
            Param.Ignore(unsafeCode);
            Param.Ignore(generated);
            Param.Ignore(xmlHeader);
            Param.Ignore(attributes);

            Node<CsToken> previousTokenNode = this.tokens.Last;

            // Get the modifiers and access.
            AccessModifierType accessModifier = AccessModifierType.Private;
            Dictionary<CsTokenType, CsToken> modifiers = this.GetElementModifiers(elementReference, ref accessModifier, null);

            // Get the accessor type token.
            AccessorType accessorType = AccessorType.Get;
            CsToken accessorName = null;

            Symbol symbol = this.GetNextSymbol(elementReference);
            if (symbol.Text == "get")
            {
                accessorName = this.GetToken(CsTokenType.Get, SymbolType.Other, elementReference);

                if (parent.ElementType != ElementType.Property && parent.ElementType != ElementType.Indexer)
                {
                    throw this.CreateSyntaxException();
                }
            }
            else if (symbol.Text == "set")
            {
                accessorType = AccessorType.Set;
                accessorName = this.GetToken(CsTokenType.Set, SymbolType.Other, elementReference);

                if (parent.ElementType != ElementType.Property && parent.ElementType != ElementType.Indexer)
                {
                    throw this.CreateSyntaxException();
                }
            }
            else if (symbol.Text == "add")
            {
                accessorType = AccessorType.Add;
                accessorName = this.GetToken(CsTokenType.Add, SymbolType.Other, elementReference);

                if (parent.ElementType != ElementType.Event)
                {
                    throw this.CreateSyntaxException();
                }
            }
            else if (symbol.Text == "remove")
            {
                accessorType = AccessorType.Remove;
                accessorName = this.GetToken(CsTokenType.Remove, SymbolType.Other, elementReference);

                if (parent.ElementType != ElementType.Event)
                {
                    throw this.CreateSyntaxException();
                }
            }
            else
            {
                throw this.CreateSyntaxException();
            }

            this.tokens.Add(accessorName);

            // Create the declaration.
            Node<CsToken> firstTokenNode = previousTokenNode == null ? this.tokens.First : previousTokenNode.Next;
            CsTokenList declarationTokens = new CsTokenList(this.tokens, firstTokenNode, this.tokens.Last);
            Declaration declaration = new Declaration(declarationTokens, accessorName.Text, ElementType.Accessor, accessModifier, modifiers);

            Accessor accessor = new Accessor(this.document, parent, accessorType, xmlHeader, attributes, declaration, unsafeCode, generated);
            elementReference.Target = accessor;

            // Get the method body.
            this.ParseStatementContainer(accessor, true, unsafeCode);

            return accessor;
        }

        /// <summary>
        /// Parses an anonymous method or lambda expression's parameter list.
        /// </summary>
        /// <param name="elementReference">
        /// A reference to the element being created.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code is marked as unsafe.
        /// </param>
        /// <returns>
        /// Returns the collection of parameters.
        /// </returns>
        private ICollection<Parameter> ParseAnonymousMethodParameterList(Reference<ICodePart> elementReference, bool unsafeCode)
        {
            Param.AssertNotNull(elementReference, "elementReference");
            Param.Ignore(unsafeCode);

            // Get the opening bracket.
            Bracket openingParenthesis = this.GetBracketToken(CsTokenType.OpenParenthesis, SymbolType.OpenParenthesis, elementReference);
            Node<CsToken> openingParenthesisNode = this.tokens.InsertLast(openingParenthesis);

            List<Parameter> parameters = new List<Parameter>();

            // Get each of the parameters.
            Symbol symbol = this.GetNextSymbol(elementReference);

            while (symbol.SymbolType != SymbolType.CloseParenthesis)
            {
                Reference<ICodePart> parameterReference = new Reference<ICodePart>();
                Node<CsToken> previousToken = this.tokens.Last;

                ParameterModifiers modifiers = ParameterModifiers.None;

                // If there is a parameter modifier, get it.
                if (symbol.SymbolType == SymbolType.Ref)
                {
                    this.tokens.Add(this.GetToken(CsTokenType.Ref, SymbolType.Ref, parameterReference));
                    modifiers |= ParameterModifiers.Ref;
                }
                else if (symbol.SymbolType == SymbolType.Out)
                {
                    this.tokens.Add(this.GetToken(CsTokenType.Out, SymbolType.Out, parameterReference));
                    modifiers |= ParameterModifiers.Out;
                }
                else if (symbol.SymbolType == SymbolType.Params)
                {
                    this.tokens.Add(this.GetToken(CsTokenType.Params, SymbolType.Params, parameterReference));
                    modifiers |= ParameterModifiers.Params;
                }

                // The first token is either the parameter type in an explicit parameter list, or the parameter name
                // in an implicit parameter list.
                TypeToken firstToken = this.GetTypeToken(parameterReference, unsafeCode, true);

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
                    if (firstToken.ChildTokens.Count > 1)
                    {
                        throw this.CreateSyntaxException();
                    }

                    CsToken nameToken = firstToken.ChildTokens.First.Value;
                    nameToken.ParentRef = parameterReference;
                    this.tokens.Add(nameToken);

                    Parameter parameter = new Parameter(
                        null,
                        nameToken.Text,
                        elementReference,
                        modifiers,
                        null,
                        nameToken.Location,
                        new CsTokenList(this.tokens, previousToken.Next, this.tokens.Last),
                        nameToken.Generated);

                    parameterReference.Target = parameter;
                    parameters.Add(parameter);
                }
                else
                {
                    // There is a type and a name.
                    this.tokens.Add(firstToken);

                    // Get the parameter name.
                    CsToken nameToken = this.GetToken(CsTokenType.Other, SymbolType.Other, parameterReference);
                    this.tokens.Add(nameToken);

                    Parameter parameter = new Parameter(
                        firstToken,
                        nameToken.Text,
                        elementReference,
                        modifiers,
                        null,
                        CodeLocation.Join(firstToken.Location, nameToken.Location),
                        new CsTokenList(this.tokens, previousToken.Next, this.tokens.Last),
                        firstToken.Generated || nameToken.Generated);

                    parameterReference.Target = parameter;
                    parameters.Add(parameter);
                }

                // If the next symbol is a comma, get the next parameter.
                symbol = this.GetNextSymbol(elementReference);
                if (symbol.SymbolType == SymbolType.Comma)
                {
                    this.tokens.Add(this.GetToken(CsTokenType.Comma, SymbolType.Comma, elementReference));
                    symbol = this.GetNextSymbol(elementReference);
                }
            }

            // Get the closing bracket.
            Bracket closingParenthesis = this.GetBracketToken(CsTokenType.CloseParenthesis, SymbolType.CloseParenthesis, elementReference);
            Node<CsToken> closingParenthesisNode = this.tokens.InsertLast(closingParenthesis);

            openingParenthesis.MatchingBracketNode = closingParenthesisNode;
            closingParenthesis.MatchingBracketNode = openingParenthesisNode;

            return parameters;
        }

        ///// <summary>
        ///// Parses and returns an assembly or module attribute.
        ///// </summary>
        ///// <param name="parent">The parent of the namespace.</param>
        ///// <param name="elementReference">A reference to the element being created.</param>
        ///// <param name="generated">Indicates whether the code is marked as generated code.</param>
        ///// <returns>Returns the element.</returns>
        private AssemblyOrModuleAttribute ParseAssemblyOrModuleAttribute(CsElement parent, Reference<ICodePart> elementReference, bool generated)
        {
            Param.AssertNotNull(parent, "parent");
            Param.AssertNotNull(elementReference, "elementReference");
            Param.Ignore(generated);

            Attribute attribute = this.GetAttribute(elementReference, false);

            Node<CsToken> firstToken = this.tokens.InsertLast(attribute);

            // Create the declaration.
            CsTokenList declarationTokens = new CsTokenList(this.tokens, firstToken, this.tokens.Last);

            Declaration declaration = new Declaration(declarationTokens, attribute.Text, ElementType.AssemblyOrModuleAttribute, AccessModifierType.Public);

            ICollection<Attribute> attributes = new List<Attribute>(1) { attribute }.ToArray();

            AssemblyOrModuleAttribute element = new AssemblyOrModuleAttribute(this.document, parent, declaration, generated, attributes);
            elementReference.Target = element;
            return element;
        }

        /// <summary>
        /// Parses and returns a class, struct, or interface.
        /// </summary>
        /// <param name="elementType">
        /// The type of the element.
        /// </param>
        /// <param name="parent">
        /// The parent of the element.
        /// </param>
        /// <param name="elementReference">
        /// A reference to the element being created.
        /// </param>
        /// <param name="partialElements">
        /// The collection of partial elements found while parsing the files.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code is marked as unsafe.
        /// </param>
        /// <param name="generated">
        /// Indicates whether the code is marked as generated code.
        /// </param>
        /// <param name="xmlHeader">
        /// The element's documentation header.
        /// </param>
        /// <param name="attributes">
        /// The attributes on the element.
        /// </param>
        /// <returns>
        /// Returns the element.
        /// </returns>
        private ClassBase ParseClass(
            ElementType elementType,
            CsElement parent,
            Reference<ICodePart> elementReference,
            Dictionary<string, List<CsElement>> partialElements,
            bool unsafeCode,
            bool generated,
            XmlHeader xmlHeader,
            ICollection<Attribute> attributes)
        {
            Param.Ignore(elementType);
            Param.AssertNotNull(parent, "parent");
            Param.AssertNotNull(elementReference, "elementReference");
            Param.AssertNotNull(partialElements, "partialElements");
            Param.Ignore(unsafeCode);
            Param.Ignore(generated);
            Param.Ignore(xmlHeader);
            Param.Ignore(attributes);

            Node<CsToken> previousTokenNode = this.tokens.Last;

            // Top-level classes, structs, and interfaces received Internal access by default, while classes, structs, and interfaces
            // declared within a class receive Private access by default.
            AccessModifierType accessModifier = AccessModifierType.Internal;
            if (parent.ElementType == ElementType.Class)
            {
                accessModifier = AccessModifierType.Private;
            }

            // Get the modifiers and access.
            Dictionary<CsTokenType, CsToken> modifiers = this.GetElementModifiers(elementReference, ref accessModifier, ClassModifiers);

            unsafeCode |= modifiers.ContainsKey(CsTokenType.Unsafe);

            // Get the element keyword, depending on the element type.
            CsTokenType keywordType = CsTokenType.Class;
            SymbolType symbolType = SymbolType.Class;
            if (elementType == ElementType.Struct)
            {
                keywordType = CsTokenType.Struct;
                symbolType = SymbolType.Struct;
            }
            else if (elementType == ElementType.Interface)
            {
                keywordType = CsTokenType.Interface;
                symbolType = SymbolType.Interface;
            }
            else
            {
                Debug.Assert(elementType == ElementType.Class, "The method can only be called for a class, struct, or interface");
            }

            // Add the keyword token.
            this.tokens.Add(this.GetToken(keywordType, symbolType, elementReference));

            // Add the class name token.
            CsToken name = this.GetElementNameToken(elementReference, unsafeCode);
            this.tokens.Add(name);

            // Get the base classes.
            Symbol symbol = this.GetNextSymbol(elementReference);

            if (symbol.SymbolType == SymbolType.Colon)
            {
                // Add the colon token.
                this.tokens.Add(this.GetToken(CsTokenType.BaseColon, SymbolType.Colon, elementReference));

                // Get each of the base classes and interfaces.
                while (true)
                {
                    this.tokens.Add(this.GetTypeToken(elementReference, unsafeCode, false));

                    symbol = this.GetNextSymbol(elementReference);
                    if (symbol.SymbolType != SymbolType.Comma)
                    {
                        break;
                    }

                    this.tokens.Add(this.GetToken(CsTokenType.Comma, SymbolType.Comma, elementReference));
                }
            }

            // Check whether there are any type constraint clauses.
            ICollection<TypeParameterConstraintClause> typeConstraints = null;
            symbol = this.GetNextSymbol(elementReference);
            if (symbol.Text == "where")
            {
                typeConstraints = this.ParseTypeConstraintClauses(elementReference, unsafeCode);
            }

            // Create the declaration.
            Node<CsToken> firstTokenNode = previousTokenNode == null ? this.tokens.First : previousTokenNode.Next;
            CsTokenList declarationTokens = new CsTokenList(this.tokens, firstTokenNode, this.tokens.Last);
            Declaration declaration = new Declaration(declarationTokens, name.Text, elementType, accessModifier, modifiers);

            // Create the element.
            ClassBase item = null;
            if (keywordType == CsTokenType.Class)
            {
                item = new Class(this.document, parent, xmlHeader, attributes, declaration, typeConstraints, unsafeCode, generated);
            }
            else if (keywordType == CsTokenType.Struct)
            {
                item = new Struct(this.document, parent, xmlHeader, attributes, declaration, typeConstraints, unsafeCode, generated);
            }
            else
            {
                Debug.Assert(keywordType == CsTokenType.Interface, "Invalid element type");
                item = new Interface(this.document, parent, xmlHeader, attributes, declaration, typeConstraints, unsafeCode, generated);
            }

            elementReference.Target = item;

            // Parse the body of the element.
            this.ParseElementContainer(item, elementReference, partialElements, unsafeCode);

            return item;
        }

        /// <summary>
        /// Parses and returns a constructor.
        /// </summary>
        /// <param name="parent">
        /// The parent of the element.
        /// </param>
        /// <param name="elementReference">
        /// A reference to the element being created.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code is marked as unsafe.
        /// </param>
        /// <param name="generated">
        /// Indicates whether the code is marked as generated code.
        /// </param>
        /// <param name="xmlHeader">
        /// The element's documentation header.
        /// </param>
        /// <param name="attributes">
        /// The attributes on the element.
        /// </param>
        /// <returns>
        /// Returns the element.
        /// </returns>
        private Constructor ParseConstructor(
            CsElement parent, Reference<ICodePart> elementReference, bool unsafeCode, bool generated, XmlHeader xmlHeader, ICollection<Attribute> attributes)
        {
            Param.AssertNotNull(parent, "parent");
            Param.AssertNotNull(elementReference, "elementReference");
            Param.Ignore(unsafeCode);
            Param.Ignore(generated);
            Param.Ignore(xmlHeader);
            Param.Ignore(attributes);

            Node<CsToken> previousTokenNode = this.tokens.Last;

            // Get the modifiers and access.
            AccessModifierType accessModifier = AccessModifierType.Private;
            Dictionary<CsTokenType, CsToken> modifiers = this.GetElementModifiers(elementReference, ref accessModifier, ConstructorModifiers);

            unsafeCode |= modifiers.ContainsKey(CsTokenType.Unsafe);

            // Get the name of the constructor.
            CsToken name = this.GetElementNameToken(elementReference, unsafeCode);
            this.tokens.Add(name);

            // Get the parameter list.
            IList<Parameter> parameters = this.ParseParameterList(elementReference, unsafeCode, SymbolType.OpenParenthesis);

            // Get the constructor initializer if there is one.
            MethodInvocationExpression constructorInitializer = null;

            Symbol symbol = this.GetNextSymbol(elementReference);
            if (symbol.SymbolType == SymbolType.Colon)
            {
                this.tokens.Add(this.GetToken(CsTokenType.BaseColon, SymbolType.Colon, elementReference));

                // The next symbol must be the keyword base or this.
                symbol = this.GetNextSymbol(elementReference);
                if (symbol.SymbolType != SymbolType.This && symbol.SymbolType != SymbolType.Base)
                {
                    throw this.CreateSyntaxException();
                }

                Reference<ICodePart> initializerNameExpressionReference = new Reference<ICodePart>();
                Node<CsToken> initializerNameTokenNode = this.tokens.InsertLast(this.GetToken(CsTokenType.Other, symbol.SymbolType, initializerNameExpressionReference));

                // Get the name expression.
                LiteralExpression initializerNameExpression = new LiteralExpression(this.tokens, initializerNameTokenNode);
                initializerNameExpressionReference.Target = initializerNameExpression;

                // Get the initializer expression.
                constructorInitializer = this.GetMethodInvocationExpression(initializerNameExpression, ExpressionPrecedence.None, unsafeCode);
            }

            // Create the declaration.
            Node<CsToken> firstTokenNode = previousTokenNode == null ? this.tokens.First : previousTokenNode.Next;
            CsTokenList declarationTokens = new CsTokenList(this.tokens, firstTokenNode, this.tokens.Last);
            Declaration declaration = new Declaration(declarationTokens, name.Text, ElementType.Constructor, accessModifier, modifiers);

            Constructor constructor = new Constructor(
                this.document, parent, xmlHeader, attributes, declaration, parameters, constructorInitializer, unsafeCode, generated);

            elementReference.Target = constructor;

            // If the constructor is extern, it will not have a body.
            if (modifiers.ContainsKey(CsTokenType.Extern))
            {
                // Get the closing semicolon.
                this.tokens.Add(this.GetToken(CsTokenType.Semicolon, SymbolType.Semicolon, elementReference));
            }
            else
            {
                // Get the body.
                this.ParseStatementContainer(constructor, true, unsafeCode);
            }

            return constructor;
        }

        /// <summary>
        /// Parses and returns a delegate.
        /// </summary>
        /// <param name="parent">
        /// The parent of the element.
        /// </param>
        /// <param name="elementReference">
        /// A reference to the element being created.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code is marked as unsafe.
        /// </param>
        /// <param name="generated">
        /// Indicates whether the code is marked as generated code.
        /// </param>
        /// <param name="xmlHeader">
        /// The element's documentation header.
        /// </param>
        /// <param name="attributes">
        /// The attributes on the element.
        /// </param>
        /// <returns>
        /// Returns the element.
        /// </returns>
        private Delegate ParseDelegate(
            CsElement parent, Reference<ICodePart> elementReference, bool unsafeCode, bool generated, XmlHeader xmlHeader, ICollection<Attribute> attributes)
        {
            Param.AssertNotNull(parent, "parent");
            Param.AssertNotNull(elementReference, "elementReference");
            Param.Ignore(unsafeCode);
            Param.Ignore(generated);
            Param.Ignore(xmlHeader);
            Param.Ignore(attributes);

            Node<CsToken> previousTokenNode = this.tokens.Last;

            // The access defaults to public for a top-level element, or private for a nested element.
            AccessModifierType accessModifier = AccessModifierType.Public;
            if (parent.ElementType == ElementType.Class || parent.ElementType == ElementType.Struct)
            {
                accessModifier = AccessModifierType.Private;
            }

            // Get the modifiers and access.
            Dictionary<CsTokenType, CsToken> modifiers = this.GetElementModifiers(elementReference, ref accessModifier, DelegateModifiers);

            unsafeCode |= modifiers.ContainsKey(CsTokenType.Unsafe);

            // Get the delegate keyword.
            this.tokens.Add(this.GetToken(CsTokenType.Delegate, SymbolType.Delegate, elementReference));

            // Get the return type.
            TypeToken returnType = this.GetTypeToken(elementReference, unsafeCode, true);
            this.tokens.Add(returnType);

            // Get the name of the delegate.
            CsToken name = this.GetElementNameToken(elementReference, unsafeCode);
            this.tokens.Add(name);

            // Get the parameter list.
            IList<Parameter> parameters = this.ParseParameterList(elementReference, unsafeCode, SymbolType.OpenParenthesis);

            // Check whether there are any type constraint clauses.
            ICollection<TypeParameterConstraintClause> typeConstraints = null;
            Symbol symbol = this.GetNextSymbol(elementReference);
            if (symbol.Text == "where")
            {
                typeConstraints = this.ParseTypeConstraintClauses(elementReference, unsafeCode);
            }

            // Create the declaration.
            Node<CsToken> firstTokenNode = previousTokenNode == null ? this.tokens.First : previousTokenNode.Next;
            CsTokenList declarationTokens = new CsTokenList(this.tokens, firstTokenNode, this.tokens.Last);
            Declaration declaration = new Declaration(declarationTokens, name.Text, ElementType.Delegate, accessModifier, modifiers);

            // Get the closing semicolon.
            this.tokens.Add(this.GetToken(CsTokenType.Semicolon, SymbolType.Semicolon, elementReference));

            Delegate element = new Delegate(this.document, parent, xmlHeader, attributes, declaration, returnType, parameters, typeConstraints, unsafeCode, generated);

            elementReference.Target = element;
            return element;
        }

        /// <summary>
        /// Parses and returns a destructor.
        /// </summary>
        /// <param name="parent">
        /// The parent of the element.
        /// </param>
        /// <param name="elementReference">
        /// A reference to the element being created.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code is marked as unsafe.
        /// </param>
        /// <param name="generated">
        /// Indicates whether the code is marked as generated code.
        /// </param>
        /// <param name="xmlHeader">
        /// The element's documentation header.
        /// </param>
        /// <param name="attributes">
        /// The attributes on the element.
        /// </param>
        /// <returns>
        /// Returns the element.
        /// </returns>
        private Destructor ParseDestructor(
            CsElement parent, Reference<ICodePart> elementReference, bool unsafeCode, bool generated, XmlHeader xmlHeader, ICollection<Attribute> attributes)
        {
            Param.AssertNotNull(parent, "parent");
            Param.AssertNotNull(elementReference, "elementReference");
            Param.Ignore(unsafeCode);
            Param.Ignore(generated);
            Param.Ignore(xmlHeader);
            Param.Ignore(attributes);

            Node<CsToken> previousTokenNode = this.tokens.Last;

            // Get the modifiers and access.
            AccessModifierType accessModifier = AccessModifierType.Private;
            Dictionary<CsTokenType, CsToken> modifiers = this.GetElementModifiers(elementReference, ref accessModifier, DestructorModifiers);

            unsafeCode |= modifiers.ContainsKey(CsTokenType.Unsafe);

            // Move past the tilde symbol.
            this.tokens.Add(this.GetToken(CsTokenType.DestructorTilde, SymbolType.Tilde, elementReference));

            // Get the name of the destructor.
            CsToken nameToken = this.GetElementNameToken(elementReference, unsafeCode);
            this.tokens.Add(nameToken);

            string destructorName = "~" + nameToken.Text;

            // Get the opening and closing parenthesis.
            Bracket openingParenthesis = this.GetBracketToken(CsTokenType.OpenParenthesis, SymbolType.OpenParenthesis, elementReference);
            Node<CsToken> openingParenthesisNode = this.tokens.InsertLast(openingParenthesis);

            Bracket closingParenthesis = this.GetBracketToken(CsTokenType.CloseParenthesis, SymbolType.CloseParenthesis, elementReference);
            Node<CsToken> closingParenthesisNode = this.tokens.InsertLast(closingParenthesis);

            openingParenthesis.MatchingBracketNode = closingParenthesisNode;
            closingParenthesis.MatchingBracketNode = openingParenthesisNode;

            // Create the declaration.
            Node<CsToken> firstTokenNode = previousTokenNode == null ? this.tokens.First : previousTokenNode.Next;
            CsTokenList declarationTokens = new CsTokenList(this.tokens, firstTokenNode, this.tokens.Last);
            Declaration declaration = new Declaration(declarationTokens, destructorName, ElementType.Destructor, accessModifier, modifiers);

            Destructor destructor = new Destructor(this.document, parent, xmlHeader, attributes, declaration, unsafeCode, generated);
            elementReference.Target = destructor;

            // If the destructor is extern, it will not have a body.
            if (modifiers.ContainsKey(CsTokenType.Extern))
            {
                // Get the closing semicolon.
                this.tokens.Add(this.GetToken(CsTokenType.Semicolon, SymbolType.Semicolon, elementReference));
            }
            else
            {
                // Get the body.
                this.ParseStatementContainer(destructor, true, unsafeCode);
            }

            return destructor;
        }

        /// <summary>
        /// Parses and returns an element.
        /// </summary>
        /// <param name="elementType">
        /// The type of element to parse.
        /// </param>
        /// <param name="parent">
        /// The parent of the element.
        /// </param>
        /// <param name="elementReference">
        /// A reference to the element being created.
        /// </param>
        /// <param name="partialElements">
        /// The collection of partial elements found while parsing the files.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code is marked as unsafe.
        /// </param>
        /// <param name="generated">
        /// Indicates whether the code is marked as generated code.
        /// </param>
        /// <param name="xmlHeader">
        /// The element's documentation header.
        /// </param>
        /// <param name="attributes">
        /// The attributes on the element.
        /// </param>
        /// <returns>
        /// Returns the element.
        /// </returns>
        private CsElement ParseElement(
            ElementType elementType,
            CsElement parent,
            Reference<ICodePart> elementReference,
            Dictionary<string, List<CsElement>> partialElements,
            bool unsafeCode,
            bool generated,
            XmlHeader xmlHeader,
            ICollection<Attribute> attributes)
        {
            Param.Ignore(elementType);
            Param.AssertNotNull(parent, "parent");
            Param.AssertNotNull(elementReference, "elementReference");
            Param.Ignore(partialElements);
            Param.Ignore(unsafeCode);
            Param.Ignore(generated);
            Param.Ignore(xmlHeader);
            Param.Ignore(attributes);

            switch (elementType)
            {
                case ElementType.Namespace:
                    return this.ParseNamespace(parent, elementReference, partialElements, unsafeCode, generated, xmlHeader, attributes);

                case ElementType.ExternAliasDirective:
                    return this.ParseExternAliasDirective(parent, elementReference, generated);

                case ElementType.UsingDirective:
                    return this.ParseUsingDirective(parent, elementReference, unsafeCode, generated);

                case ElementType.AssemblyOrModuleAttribute:
                    return this.ParseAssemblyOrModuleAttribute(parent, elementReference, generated);

                case ElementType.Class:
                case ElementType.Struct:
                case ElementType.Interface:
                    return this.ParseClass(elementType, parent, elementReference, partialElements, unsafeCode, generated, xmlHeader, attributes);

                case ElementType.Enum:
                    return this.ParseEnum(parent, elementReference, unsafeCode, generated, xmlHeader, attributes);

                case ElementType.Delegate:
                    return this.ParseDelegate(parent, elementReference, unsafeCode, generated, xmlHeader, attributes);

                case ElementType.Field:
                    return this.ParseField(parent, elementReference, unsafeCode, generated, xmlHeader, attributes);

                case ElementType.Method:
                    return this.ParseMethod(parent, elementReference, unsafeCode, generated, xmlHeader, attributes);

                case ElementType.Constructor:
                    return this.ParseConstructor(parent, elementReference, unsafeCode, generated, xmlHeader, attributes);

                case ElementType.Destructor:
                    return this.ParseDestructor(parent, elementReference, unsafeCode, generated, xmlHeader, attributes);

                case ElementType.Property:
                    return this.ParseProperty(parent, elementReference, unsafeCode, generated, xmlHeader, attributes);

                case ElementType.Indexer:
                    return this.ParseIndexer(parent, elementReference, unsafeCode, generated, xmlHeader, attributes);

                case ElementType.Event:
                    return this.ParseEvent(parent, elementReference, unsafeCode, generated, xmlHeader, attributes);

                case ElementType.Accessor:
                    return this.ParseAccessor(parent, elementReference, unsafeCode, generated, xmlHeader, attributes);

                case ElementType.EmptyElement:
                    return this.ParseEmptyElement(parent, elementReference, unsafeCode, generated);

                default:
                    Debug.Fail("Unexpected element type.");
                    throw new StyleCopException();
            }
        }

        /// <summary>
        /// Parses the body of an element that is enclosed in curly brackets and contains other elements as children.
        /// </summary>
        /// <param name="element">
        /// The element to parse.
        /// </param>
        /// <param name="elementReference">
        /// Reference to the element being created.
        /// </param>
        /// <param name="partialElements">
        /// The collection of partial elements found while parsing the files.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code being parsed resides in an unsafe code block.
        /// </param>
        private void ParseElementContainer(CsElement element, Reference<ICodePart> elementReference, Dictionary<string, List<CsElement>> partialElements, bool unsafeCode)
        {
            Param.AssertNotNull(element, "element");
            Param.AssertNotNull(elementReference, "elementReference");
            Param.Ignore(partialElements);
            Param.Ignore(unsafeCode);

            // Check to see if the item is unsafe. This is the case if the item's parent is unsafe, or if it
            // has the unsafe keyword itself.
            if (!unsafeCode)
            {
                unsafeCode = element.Declaration.ContainsModifier(CsTokenType.Unsafe);
            }

            // The next symbol must be an opening curly bracket.
            Symbol symbol = this.GetNextSymbol(elementReference);

            if (symbol.SymbolType != SymbolType.OpenCurlyBracket)
            {
                throw this.CreateSyntaxException();
            }

            // Add the bracket token to the document.
            Bracket openingBracket = this.GetBracketToken(CsTokenType.OpenCurlyBracket, SymbolType.OpenCurlyBracket, elementReference);
            Node<CsToken> openingBracketNode = this.tokens.InsertLast(openingBracket);

            // Parse the contents of the element.
            Node<CsToken> closingBracketNode = this.ParseElementContainerBody(element, elementReference, partialElements, unsafeCode);

            if (closingBracketNode == null)
            {
                // If we failed to get a closing bracket back, then there is a syntax
                // error in the document since there is an opening bracket with no matching
                // closing bracket.
                throw this.CreateSyntaxException();
            }

            Bracket closingBracket = (Bracket)closingBracketNode.Value;

            openingBracket.MatchingBracketNode = closingBracketNode;
            closingBracket.MatchingBracketNode = openingBracketNode;
        }

        /// <summary>
        /// Parses the body of a container element.
        /// </summary>
        /// <param name="element">
        /// The element to parse.
        /// </param>
        /// <param name="elementReference">
        /// A reference to the element being created.
        /// </param>
        /// <param name="partialElements">
        /// The collection of partial elements found while parsing the files.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code being parsed resides in an unsafe code block.
        /// </param>
        /// <returns>
        /// Returns the closing curly bracket.
        /// </returns>
        private Node<CsToken> ParseElementContainerBody(
            CsElement element, Reference<ICodePart> elementReference, Dictionary<string, List<CsElement>> partialElements, bool unsafeCode)
        {
            Param.AssertNotNull(element, "element");
            Param.AssertNotNull(elementReference, "elementReference");
            Param.Ignore(partialElements);
            Param.Ignore(unsafeCode);

            Node<CsToken> closingBracketNode = null;

            // Keep looping until all the child elements within this container element have been processed.
            while (true)
            {
                // Saves the attributes and xml header for the element, if any exist.
                XmlHeader xmlHeader = null;
                ICollection<Attribute> attributes;

                Reference<ICodePart> childElementReference = new Reference<ICodePart>();

                // Move past whitespace, preprocessors, comments and xml headers up to the start of the element.
                this.MoveToElementDeclaration(element, elementReference, childElementReference, unsafeCode, out xmlHeader, out attributes);

                // Now record whether the element is within a generated code block.
                bool generated = this.symbols.Generated;

                // If the next symbol is a closing curly bracket, or we've reached the end of the symbols list, 
                // we're done with this element.
                Symbol symbol = this.symbols.Peek(1);

                if (symbol == null)
                {
                    // We've reached the end of the document.
                    childElementReference.Target = element;
                    break;
                }
                else if (symbol.SymbolType == SymbolType.CloseCurlyBracket)
                {
                    // We've reached the end of the element. Save the closing bracket end exit.
                    Bracket bracket = this.GetBracketToken(CsTokenType.CloseCurlyBracket, SymbolType.CloseCurlyBracket, elementReference);
                    closingBracketNode = this.tokens.InsertLast(bracket);
                    childElementReference.Target = element;
                    break;
                }

                // Figure out the type of the next child element.
                ElementType? childElementType = this.GetElementType(element, unsafeCode);

                // If the type of the element could not be determined, then there must be 
                // a syntax error in the code.
                if (childElementType == null || !SanityCheckElementTypeAgainstParent(childElementType.Value, element))
                {
                    throw this.CreateSyntaxException();
                }

                // Parse the element.
                CsElement childElement = this.ParseElement(
                   childElementType.Value, element, childElementReference, partialElements, unsafeCode, generated, xmlHeader, attributes);

                // Add the element to its parent.
                element.AddElement(childElement);

                // Add any suppressed rules.
                // This has to be done after the parent is set above.
                this.AddRuleSuppressionsForElement(childElement);

                // Set up the new element.
                this.InitializeElement(childElement);

                // Add the element to the collection of partial elements, if necessary.
                AddElementToPartialElementsList(childElement, partialElements);
            }

            return closingBracketNode;
        }

        /// <summary>
        /// Parses and returns an empty element.
        /// </summary>
        /// <param name="parent">
        /// The parent of the namespace.
        /// </param>
        /// <param name="elementReference">
        /// A reference to the element being created.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code is marked as unsafe.
        /// </param>
        /// <param name="generated">
        /// Indicates whether the code is marked as generated code.
        /// </param>
        /// <returns>
        /// Returns the element.
        /// </returns>
        private EmptyElement ParseEmptyElement(CsElement parent, Reference<ICodePart> elementReference, bool unsafeCode, bool generated)
        {
            Param.AssertNotNull(parent, "parent");
            Param.AssertNotNull(elementReference, "elementReference");
            Param.Ignore(unsafeCode);
            Param.Ignore(generated);

            this.tokens.Add(this.GetToken(CsTokenType.Semicolon, SymbolType.Semicolon, elementReference));

            // Create the declaration.
            CsTokenList declarationTokens = new CsTokenList(this.tokens, this.tokens.Last, this.tokens.Last);
            Declaration declaration = new Declaration(declarationTokens, string.Empty, ElementType.EmptyElement, AccessModifierType.Public);

            // Create the element.
            EmptyElement element = new EmptyElement(this.document, parent, declaration, unsafeCode, generated);
            elementReference.Target = element;

            return element;
        }

        /// <summary>
        /// Parses and returns an <see cref="Enum"/>.
        /// </summary>
        /// <param name="parent">
        /// The parent of the element.
        /// </param>
        /// <param name="elementReference">
        /// A reference to the element being created.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code is marked as unsafe.
        /// </param>
        /// <param name="generated">
        /// Indicates whether the code is marked as generated code.
        /// </param>
        /// <param name="xmlHeader">
        /// The element's documentation header.
        /// </param>
        /// <param name="attributes">
        /// The attributes on the element.
        /// </param>
        /// <returns>
        /// Returns the element.
        /// </returns>
        private Enum ParseEnum(
            CsElement parent, Reference<ICodePart> elementReference, bool unsafeCode, bool generated, XmlHeader xmlHeader, ICollection<Attribute> attributes)
        {
            Param.AssertNotNull(parent, "parent");
            Param.AssertNotNull(elementReference, "elementReference");
            Param.Ignore(unsafeCode);
            Param.Ignore(generated);
            Param.Ignore(xmlHeader);
            Param.Ignore(attributes);

            Node<CsToken> previousTokenNode = this.tokens.Last;

            // The access defaults to public for a top-level element, or private for a nested element.
            AccessModifierType accessModifier = AccessModifierType.Public;
            if (parent.ElementType == ElementType.Class || parent.ElementType == ElementType.Struct)
            {
                accessModifier = AccessModifierType.Private;
            }

            // Get the modifiers and access.
            Dictionary<CsTokenType, CsToken> modifiers = this.GetElementModifiers(elementReference, ref accessModifier, EnumModifiers);

            // Get the enum keyword.
            this.tokens.Add(this.GetToken(CsTokenType.Enum, SymbolType.Enum, elementReference));

            // Add the enum name token.
            CsToken name = this.GetElementNameToken(elementReference, unsafeCode);
            this.tokens.Add(name);

            // Get the base type.
            Symbol symbol = this.GetNextSymbol(elementReference);

            if (symbol.SymbolType == SymbolType.Colon)
            {
                // Add the colon token and the base item name.
                this.tokens.Add(this.GetToken(CsTokenType.BaseColon, SymbolType.Colon, elementReference));
                this.tokens.Add(this.GetTypeToken(elementReference, unsafeCode, false));
            }

            // Create the declaration.
            Node<CsToken> firstTokenNode = previousTokenNode == null ? this.tokens.First : previousTokenNode.Next;
            CsTokenList declarationTokens = new CsTokenList(this.tokens, firstTokenNode, this.tokens.Last);
            Declaration declaration = new Declaration(declarationTokens, name.Text, ElementType.Enum, accessModifier, modifiers);

            // Create the enum element.
            Enum @enum = new Enum(this.document, parent, xmlHeader, attributes, declaration, unsafeCode, generated);
            elementReference.Target = @enum;

            // Get the opening curly bracket.
            Bracket openingCurlyBracket = this.GetBracketToken(CsTokenType.OpenCurlyBracket, SymbolType.OpenCurlyBracket, elementReference);
            Node<CsToken> openingCurlyBracketNode = this.tokens.InsertLast(openingCurlyBracket);

            // Get each of the enum items.
            @enum.Items = this.ParseEnumItems(@enum, elementReference, unsafeCode);

            // Get the closing curly bracket.
            Bracket closingCurlyBracket = this.GetBracketToken(CsTokenType.CloseCurlyBracket, SymbolType.CloseCurlyBracket, elementReference);
            Node<CsToken> closingCurlyBracketNode = this.tokens.InsertLast(closingCurlyBracket);

            openingCurlyBracket.MatchingBracketNode = closingCurlyBracketNode;
            closingCurlyBracket.MatchingBracketNode = openingCurlyBracketNode;

            return @enum;
        }

        /// <summary>
        /// Parses and returns the items within an <see cref="Enum"/> element.
        /// </summary>
        /// <param name="parent">
        /// The parent <see cref="Enum"/> element.
        /// </param>
        /// <param name="parentReference">
        /// Reference to the parent of the items we're creating.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code is marked as unsafe.
        /// </param>
        /// <returns>
        /// Returns the element.
        /// </returns>
        private ICollection<EnumItem> ParseEnumItems(Enum parent, Reference<ICodePart> parentReference, bool unsafeCode)
        {
            Param.AssertNotNull(parent, "parent");
            Param.Ignore(unsafeCode);
            Param.AssertNotNull(parentReference, "parentReference");

            List<EnumItem> enumItems = new List<EnumItem>();

            SkipSymbols skip = SkipSymbols.All;
            skip &= ~SkipSymbols.XmlHeader;
            Symbol symbol = this.GetNextSymbol(skip, parentReference);

            while (symbol.SymbolType != SymbolType.CloseCurlyBracket)
            {
                // Get the enum header.
                XmlHeader xmlHeader = null;
                ICollection<Attribute> attributes;

                Reference<ICodePart> enumItemReference = new Reference<ICodePart>();

                this.MoveToElementDeclaration(parent, parentReference, enumItemReference, unsafeCode, out xmlHeader, out attributes);

                // If the next symbol is a close curly bracket, quit.
                symbol = this.GetNextSymbol(enumItemReference);
                if (symbol.SymbolType == SymbolType.CloseCurlyBracket)
                {
                    break;
                }

                // Get the enum item name.
                Node<CsToken> firstEnumItemToken = this.tokens.InsertLast(this.GetToken(CsTokenType.Other, SymbolType.Other, enumItemReference));

                Expression initializationExpression = null;

                // See if there is an equals sign.
                symbol = this.GetNextSymbol(enumItemReference);
                if (symbol.SymbolType == SymbolType.Equals)
                {
                    this.tokens.Add(this.GetOperatorToken(OperatorType.Equals, enumItemReference));

                    // Get the constant expression being assigned.
                    initializationExpression = this.GetNextExpression(ExpressionPrecedence.None, enumItemReference, unsafeCode);
                }

                CsTokenList enumItemTokens = new CsTokenList(this.tokens, firstEnumItemToken, this.tokens.Last);

                Declaration enumItemDeclaration = new Declaration(enumItemTokens, firstEnumItemToken.Value.Text, ElementType.EnumItem, AccessModifierType.Public);

                EnumItem enumItem = new EnumItem(
                    this.document, parent, xmlHeader, attributes, enumItemDeclaration, initializationExpression, unsafeCode, this.symbols.Generated);

                enumItemReference.Target = enumItem;
                enumItem.Tokens = new CsTokenList(this.tokens, firstEnumItemToken, this.tokens.Last);

                enumItems.Add(enumItem);

                // Add any suppressed rules.
                this.AddRuleSuppressionsForElement(enumItem);

                parent.AddElement(enumItem);

                symbol = this.GetNextSymbol(parentReference);

                // If the symbol is not a comma, quit.
                if (symbol.SymbolType == SymbolType.Comma)
                {
                    this.tokens.Add(this.GetToken(CsTokenType.Comma, SymbolType.Comma, parentReference));
                }
                else
                {
                    break;
                }

                symbol = this.GetNextSymbol(skip, parentReference);
            }

            // Return the enum items as a read-only collection.
            return enumItems.ToArray();
        }

        /// <summary>
        /// Parses and returns a event.
        /// </summary>
        /// <param name="parent">
        /// The parent of the element.
        /// </param>
        /// <param name="elementReference">
        /// A reference to the element being created.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code is marked as unsafe.
        /// </param>
        /// <param name="generated">
        /// Indicates whether the code is marked as generated code.
        /// </param>
        /// <param name="xmlHeader">
        /// The element's documentation header.
        /// </param>
        /// <param name="attributes">
        /// The attributes on the element.
        /// </param>
        /// <returns>
        /// Returns the element.
        /// </returns>
        private Event ParseEvent(
            CsElement parent, Reference<ICodePart> elementReference, bool unsafeCode, bool generated, XmlHeader xmlHeader, ICollection<Attribute> attributes)
        {
            Param.AssertNotNull(parent, "parent");
            Param.AssertNotNull(elementReference, "elementReference");
            Param.Ignore(unsafeCode);
            Param.Ignore(generated);
            Param.Ignore(xmlHeader);
            Param.Ignore(attributes);

            Node<CsToken> previousTokenNode = this.tokens.Last;

            // Get the modifiers and access.
            AccessModifierType accessModifier = AccessModifierType.Private;

            // Events within interfaces always have the access of the parent interface.
            Interface parentInterface = parent as Interface;
            if (parentInterface != null)
            {
                accessModifier = parentInterface.AccessModifier;
            }

            // Get declared modifiers.
            Dictionary<CsTokenType, CsToken> modifiers = this.GetElementModifiers(elementReference, ref accessModifier, EventModifiers);

            unsafeCode |= modifiers.ContainsKey(CsTokenType.Unsafe);

            // Get the event keyword.
            this.tokens.Add(this.GetToken(CsTokenType.Event, SymbolType.Event, elementReference));

            // Get the event type.
            TypeToken eventHandlerType = this.GetTypeToken(elementReference, unsafeCode, true);
            this.tokens.Add(eventHandlerType);

            List<EventDeclaratorExpression> declarators = new List<EventDeclaratorExpression>();
            string firstEventName = null;

            while (true)
            {
                Symbol symbol = this.GetNextSymbol(SymbolType.Other, elementReference);

                Reference<ICodePart> declaratorExpressionReference = new Reference<ICodePart>();

                // Get the identifier.
                LiteralExpression identifier = this.GetTypeTokenExpression(declaratorExpressionReference, unsafeCode, false);
                if (identifier == null || identifier.Tokens.First == null)
                {
                    throw new SyntaxException(this.document.SourceCode, symbol.LineNumber);
                }

                if (firstEventName == null)
                {
                    firstEventName = identifier.Token.Text;
                }

                // Get the initializer if it exists.
                Expression initializer = null;

                symbol = this.GetNextSymbol(declaratorExpressionReference);
                if (symbol.SymbolType == SymbolType.Equals)
                {
                    // Add the equals token.
                    this.tokens.Add(this.GetOperatorToken(OperatorType.Equals, declaratorExpressionReference));

                    initializer = this.GetNextExpression(ExpressionPrecedence.None, declaratorExpressionReference, unsafeCode);
                }

                // Create the token list for the declarator.
                CsTokenList partialTokens = new CsTokenList(this.tokens, identifier.Tokens.First, this.tokens.Last);

                // Create and add the declarator.
                EventDeclaratorExpression declaratorExpression = new EventDeclaratorExpression(partialTokens, identifier, initializer);

                declaratorExpressionReference.Target = declaratorExpression;
                declarators.Add(declaratorExpression);

                // Now check if the next character is a comma. If so there is another declarator.
                symbol = this.GetNextSymbol(elementReference);
                if (symbol.SymbolType != SymbolType.Comma)
                {
                    // There are no more declarators.
                    break;
                }

                // Add the comma.
                this.tokens.Add(this.GetToken(CsTokenType.Comma, SymbolType.Comma, elementReference));
            }

            // Create the declaration.
            Node<CsToken> firstTokenNode = previousTokenNode == null ? this.tokens.First : previousTokenNode.Next;
            CsTokenList declarationTokens = new CsTokenList(this.tokens, firstTokenNode, this.tokens.Last);
            Declaration declaration = new Declaration(declarationTokens, firstEventName, ElementType.Event, accessModifier, modifiers);

            Event @event = new Event(this.document, parent, xmlHeader, attributes, declaration, eventHandlerType, declarators.ToArray(), unsafeCode, generated);
            elementReference.Target = @event;

            Symbol s = this.GetNextSymbol(elementReference);

            if (s.SymbolType == SymbolType.Semicolon)
            {
                this.tokens.Add(this.GetToken(CsTokenType.Semicolon, SymbolType.Semicolon, elementReference));
            }
            else
            {
                // Parse the body of the event.
                this.ParseElementContainer(@event, elementReference, null, unsafeCode);
            }

            return @event;
        }

        /// <summary>
        /// Parses and returns a extern alias directive.
        /// </summary>
        /// <param name="parent">
        /// The parent of the namespace.
        /// </param>
        /// <param name="elementReference">
        /// A reference to the element being created.
        /// </param>
        /// <param name="generated">
        /// Indicates whether the code is marked as generated code.
        /// </param>
        /// <returns>
        /// Returns the element.
        /// </returns>
        private ExternAliasDirective ParseExternAliasDirective(CsElement parent, Reference<ICodePart> elementReference, bool generated)
        {
            Param.AssertNotNull(parent, "parent");
            Param.AssertNotNull(elementReference, "elementReference");
            Param.Ignore(generated);

            // Add the extern token.
            Node<CsToken> firstToken = this.tokens.InsertLast(this.GetToken(CsTokenType.Extern, SymbolType.Extern, elementReference));

            // Add the alias token.
            this.tokens.Add(this.GetToken(CsTokenType.Alias, SymbolType.Other, elementReference));

            // Add the identifier token.
            CsToken identifier = this.GetToken(CsTokenType.Other, SymbolType.Other, elementReference);
            this.tokens.Add(identifier);

            // Create the declaration.
            CsTokenList declarationTokens = new CsTokenList(this.tokens, firstToken, this.tokens.Last);
            Declaration declaration = new Declaration(declarationTokens, identifier.Text, ElementType.ExternAliasDirective, AccessModifierType.Public);

            // Get the closing semicolon.
            this.tokens.Add(this.GetToken(CsTokenType.Semicolon, SymbolType.Semicolon, elementReference));

            // Create the extern alias directive.
            ExternAliasDirective element = new ExternAliasDirective(this.document, parent, declaration, generated);
            elementReference.Target = element;

            return element;
        }

        /// <summary>
        /// Parses and returns a field.
        /// </summary>
        /// <param name="parent">
        /// The parent of the element.
        /// </param>
        /// <param name="elementReference">
        /// A reference to the element being created.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code is marked as unsafe.
        /// </param>
        /// <param name="generated">
        /// Indicates whether the code is marked as generated code.
        /// </param>
        /// <param name="xmlHeader">
        /// The element's documentation header.
        /// </param>
        /// <param name="attributes">
        /// The attributes on the element.
        /// </param>
        /// <returns>
        /// Returns the element.
        /// </returns>
        private Field ParseField(
            CsElement parent, Reference<ICodePart> elementReference, bool unsafeCode, bool generated, XmlHeader xmlHeader, ICollection<Attribute> attributes)
        {
            Param.AssertNotNull(parent, "parent");
            Param.AssertNotNull(elementReference, "elementReference");
            Param.Ignore(unsafeCode);
            Param.Ignore(generated);
            Param.Ignore(xmlHeader);
            Param.Ignore(attributes);

            Node<CsToken> previousTokenNode = this.tokens.Last;

            // Get the modifiers and access.
            AccessModifierType accessModifier = AccessModifierType.Private;
            Dictionary<CsTokenType, CsToken> modifiers = this.GetElementModifiers(elementReference, ref accessModifier, FieldModifiers);

            unsafeCode |= modifiers.ContainsKey(CsTokenType.Unsafe);

            // Get the field type.
            TypeToken fieldType = this.GetTypeToken(elementReference, unsafeCode, true);
            Node<CsToken> fieldTypeNode = this.tokens.InsertLast(fieldType);

            // Get all of the variable declarators.
            IList<VariableDeclaratorExpression> declarators = this.ParseFieldDeclarators(elementReference, unsafeCode, fieldType);

            if (declarators.Count == 0)
            {
                throw this.CreateSyntaxException();
            }

            VariableDeclarationExpression declarationExpression =
                new VariableDeclarationExpression(
                    new CsTokenList(this.tokens, declarators[0].Tokens.First, this.tokens.Last), new LiteralExpression(this.tokens, fieldTypeNode), declarators);

            // Create the field.
            Node<CsToken> firstTokenNode = previousTokenNode == null ? this.tokens.First : previousTokenNode.Next;
            CsTokenList declarationTokens = new CsTokenList(this.tokens, firstTokenNode, this.tokens.Last);
            Declaration declaration = new Declaration(declarationTokens, declarators[0].Identifier.Text, ElementType.Field, accessModifier, modifiers);

            Field field = new Field(this.document, parent, xmlHeader, attributes, declaration, fieldType, unsafeCode, generated);
            elementReference.Target = field;

            // Get the trailing semicolon.
            this.tokens.Add(this.GetToken(CsTokenType.Semicolon, SymbolType.Semicolon, elementReference));

            // Create the variable declaration statement and add it to the field.
            field.VariableDeclarationStatement = new VariableDeclarationStatement(
                new CsTokenList(this.tokens, declarators[0].Tokens.First, this.tokens.Last), field.Const, false, declarationExpression);

            return field;
        }

        /// <summary>
        /// Parses and returns the declarators for a field.
        /// </summary>
        /// <param name="fieldReference">
        /// A reference to the field.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code is marked as unsafe.
        /// </param>
        /// <param name="fieldType">
        /// The field type.
        /// </param>
        /// <returns>
        /// Returns the declarators.
        /// </returns>
        private IList<VariableDeclaratorExpression> ParseFieldDeclarators(Reference<ICodePart> fieldReference, bool unsafeCode, TypeToken fieldType)
        {
            Param.AssertNotNull(fieldReference, "fieldReference");
            Param.Ignore(unsafeCode);
            Param.AssertNotNull(fieldType, "fieldType");

            List<VariableDeclaratorExpression> declarators = new List<VariableDeclaratorExpression>();
            Symbol symbol = this.GetNextSymbol(fieldReference);

            while (symbol.SymbolType != SymbolType.Semicolon)
            {
                Reference<ICodePart> expressionReference = new Reference<ICodePart>();

                // Get the identifier.
                CsToken identifier = this.GetElementNameToken(expressionReference, unsafeCode, true);
                Node<CsToken> identifierTokenNode = this.tokens.InsertLast(identifier);

                Expression initialization = null;

                // Check whether there is an equals sign.
                symbol = this.GetNextSymbol(expressionReference);
                if (symbol.SymbolType == SymbolType.Equals)
                {
                    this.tokens.Add(this.GetOperatorToken(OperatorType.Equals, expressionReference));

                    // Get the expression after the equals sign. If the expression starts with an
                    // opening curly bracket, then this is an initialization expression or an
                    // anonymous type initialization expression.
                    symbol = this.GetNextSymbol(expressionReference);
                    if (symbol.SymbolType == SymbolType.OpenCurlyBracket)
                    {
                        // Determine whether this is an array or an anonymous type.
                        if (fieldType.Text == "var" || (fieldType.Text != "Array" && fieldType.Text != "System.Array" && !fieldType.Text.Contains("[")))
                        {
                            initialization = this.GetAnonymousTypeInitializerExpression(expressionReference, unsafeCode);
                        }
                        else
                        {
                            initialization = this.GetArrayInitializerExpression(unsafeCode);
                        }
                    }
                    else
                    {
                        initialization = this.GetNextExpression(ExpressionPrecedence.None, expressionReference, unsafeCode);
                    }

                    if (initialization == null)
                    {
                        throw this.CreateSyntaxException();
                    }
                }

                VariableDeclaratorExpression variableDeclarationExpression =
                    new VariableDeclaratorExpression(
                        new CsTokenList(this.tokens, identifierTokenNode, this.tokens.Last), new LiteralExpression(this.tokens, identifierTokenNode), initialization);

                expressionReference.Target = variableDeclarationExpression;
                declarators.Add(variableDeclarationExpression);

                // If the next symbol is a comma, continue.
                symbol = this.GetNextSymbol(fieldReference);
                if (symbol.SymbolType == SymbolType.Comma)
                {
                    this.tokens.Add(this.GetToken(CsTokenType.Comma, SymbolType.Comma, fieldReference));
                    symbol = this.GetNextSymbol(fieldReference);
                }
            }

            // Return the declarators as a read-only collection.
            return declarators.ToArray();
        }

        /// <summary>
        /// Parses and returns an indexer.
        /// </summary>
        /// <param name="parent">
        /// The parent of the element.
        /// </param>
        /// <param name="elementReference">
        /// A reference to the element being created.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code is marked as unsafe.
        /// </param>
        /// <param name="generated">
        /// Indicates whether the code is marked as generated code.
        /// </param>
        /// <param name="xmlHeader">
        /// The element's documentation header.
        /// </param>
        /// <param name="attributes">
        /// The attributes on the element.
        /// </param>
        /// <returns>
        /// Returns the element.
        /// </returns>
        private Indexer ParseIndexer(
            CsElement parent, Reference<ICodePart> elementReference, bool unsafeCode, bool generated, XmlHeader xmlHeader, ICollection<Attribute> attributes)
        {
            Param.AssertNotNull(parent, "parent");
            Param.AssertNotNull(elementReference, "elementReference");
            Param.Ignore(unsafeCode);
            Param.Ignore(generated);
            Param.Ignore(xmlHeader);
            Param.Ignore(attributes);

            Node<CsToken> previousTokenNode = this.tokens.Last;

            // Get the modifiers and access.
            AccessModifierType accessModifier = AccessModifierType.Private;

            // Indexers within interfaces always have the access of the parent interface.
            Interface parentInterface = parent as Interface;
            if (parentInterface != null)
            {
                accessModifier = parentInterface.AccessModifier;
            }

            // Get declared modifiers.
            Dictionary<CsTokenType, CsToken> modifiers = this.GetElementModifiers(elementReference, ref accessModifier, IndexerModifiers);

            unsafeCode |= modifiers.ContainsKey(CsTokenType.Unsafe);

            // Get the return type.
            TypeToken returnType = this.GetTypeToken(elementReference, unsafeCode, true);
            this.tokens.Add(returnType);

            // Get the name of the indexer.
            CsToken name = this.GetElementNameToken(elementReference, unsafeCode);
            this.tokens.Add(name);

            // Get the parameter list.
            IList<Parameter> parameters = this.ParseParameterList(elementReference, unsafeCode, SymbolType.OpenSquareBracket);

            // Create the declaration.
            Node<CsToken> firstTokenNode = previousTokenNode == null ? this.tokens.First : previousTokenNode.Next;
            CsTokenList declarationTokens = new CsTokenList(this.tokens, firstTokenNode, this.tokens.Last);
            Declaration declaration = new Declaration(declarationTokens, name.Text, ElementType.Indexer, accessModifier, modifiers);

            Indexer indexer = new Indexer(this.document, parent, xmlHeader, attributes, declaration, returnType, parameters, unsafeCode, generated);
            elementReference.Target = indexer;

            Symbol symbol = this.GetNextSymbol(SkipSymbols.All, elementReference);
            if (symbol.SymbolType == SymbolType.OpenCurlyBracket)
            {
                // Parse the body of the indexer.
                this.ParseElementContainer(indexer, elementReference, null, unsafeCode);
            }
            else if (symbol.SymbolType == SymbolType.Lambda)
            {
                // Parse the expression body statement of the indexer.
                this.ParseStatementContainer(indexer, true, unsafeCode);
            }

            return indexer;
        }

        /// <summary>
        /// Parses and returns a method.
        /// </summary>
        /// <param name="parent">
        /// The parent of the element.
        /// </param>
        /// <param name="elementReference">
        /// A reference to the element being created.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code is marked as unsafe.
        /// </param>
        /// <param name="generated">
        /// Indicates whether the code is marked as generated code.
        /// </param>
        /// <param name="xmlHeader">
        /// The element's documentation header.
        /// </param>
        /// <param name="attributes">
        /// The attributes on the element.
        /// </param>
        /// <returns>
        /// Returns the element.
        /// </returns>
        private Method ParseMethod(
            CsElement parent, Reference<ICodePart> elementReference, bool unsafeCode, bool generated, XmlHeader xmlHeader, ICollection<Attribute> attributes)
        {
            Param.AssertNotNull(parent, "parent");
            Param.AssertNotNull(elementReference, "elementReference");
            Param.Ignore(unsafeCode);
            Param.Ignore(generated);
            Param.Ignore(xmlHeader);
            Param.Ignore(attributes);

            Node<CsToken> previousTokenNode = this.tokens.Last;

            // Get the modifiers and access.
            AccessModifierType accessModifier = AccessModifierType.Private;

            // Get the declared modifiers for the method.
            Dictionary<CsTokenType, CsToken> modifiers = this.GetElementModifiers(elementReference, ref accessModifier, MethodModifiers);

            // Methods within interfaces always have the access of the parent interface.
            Interface parentInterface = parent as Interface;
            if (parentInterface != null)
            {
                accessModifier = parentInterface.AccessModifier;
            }

            unsafeCode |= modifiers.ContainsKey(CsTokenType.Unsafe);

            // Check if the method's return type is ref.
            Symbol nextSymbol = this.PeekNextSymbol(SkipSymbols.All, false);
            bool returnTypeIsRef = false;

            if (nextSymbol.SymbolType == SymbolType.Ref)
            {
                this.tokens.Add(this.GetToken(CsTokenType.Ref, SymbolType.Ref, elementReference));
                returnTypeIsRef = true;
            }

            TypeToken returnType = null;
            if (!modifiers.ContainsKey(CsTokenType.Implicit) && !modifiers.ContainsKey(CsTokenType.Explicit))
            {
                // Get the return type.
                returnType = this.GetTypeToken(elementReference, unsafeCode, true);
                this.tokens.Add(returnType);
            }

            // Get the name of the method.
            string methodName = null;

            Symbol symbol = this.GetNextSymbol(elementReference);
            if (symbol.SymbolType == SymbolType.Operator)
            {
                this.tokens.Add(this.GetToken(CsTokenType.Operator, SymbolType.Operator, elementReference));

                // Advance up to the next symbol.
                this.AdvanceToNextCodeSymbol(elementReference);

                // The overloaded item will either be a type or a symbol.
                int endIndex = -1;
                CsToken operatorType = null;

                if (this.HasTypeSignature(1, unsafeCode, out endIndex))
                {
                    // The overloaded item is a type.
                    operatorType = this.GetTypeToken(elementReference, unsafeCode, true);
                }
                else
                {
                    // The overloaded item is a symbol.
                    operatorType = this.ConvertOperatorOverloadSymbol(elementReference);
                }

                this.tokens.Add(operatorType);
                methodName = "operator " + operatorType.Text;
            }
            else
            {
                CsToken name = this.GetElementNameToken(elementReference, unsafeCode);
                methodName = name.Text;
                this.tokens.Add(name);
            }

            // Get the parameter list.
            IList<Parameter> parameters = this.ParseParameterList(elementReference, unsafeCode, SymbolType.OpenParenthesis, modifiers.ContainsKey(CsTokenType.Static));

            // Check whether there are any type constraint clauses.
            ICollection<TypeParameterConstraintClause> typeConstraints = null;
            symbol = this.GetNextSymbol(elementReference);
            if (symbol.Text == "where")
            {
                typeConstraints = this.ParseTypeConstraintClauses(elementReference, unsafeCode);
            }

            // Create the declaration.
            Node<CsToken> firstTokenNode = previousTokenNode == null ? this.tokens.First : previousTokenNode.Next;
            CsTokenList declarationTokens = new CsTokenList(this.tokens, firstTokenNode, this.tokens.Last);
            Declaration declaration = new Declaration(declarationTokens, methodName, ElementType.Method, accessModifier, modifiers);

            Method method = new Method(this.document, parent, xmlHeader, attributes, declaration, returnType, returnTypeIsRef, parameters, typeConstraints, unsafeCode, generated);
            elementReference.Target = method;

            // If the element is extern, abstract, or containing within an interface, it will not have a body.
             if (modifiers.ContainsKey(CsTokenType.Abstract) || modifiers.ContainsKey(CsTokenType.Extern) || parent.ElementType == ElementType.Interface)
            {
                // Get the closing semicolon.
                this.tokens.Add(this.GetToken(CsTokenType.Semicolon, SymbolType.Semicolon, elementReference));
            }
            else
            {
                // Get the method body or bodied expression C# 6.
                this.ParseStatementContainer(method, true, unsafeCode);
            }

            return method;
        }

        /// <summary>
        /// Parses and returns a namespace.
        /// </summary>
        /// <param name="parent">
        /// The parent of the namespace.
        /// </param>
        /// <param name="elementReference">
        /// A reference to the element being created.
        /// </param>
        /// <param name="partialElements">
        /// The collection of partial elements found while parsing the files.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code is marked as unsafe.
        /// </param>
        /// <param name="generated">
        /// Indicates whether the code is marked as generated code.
        /// </param>
        /// <param name="xmlHeader">
        /// The element's documentation header.
        /// </param>
        /// <param name="attributes">
        /// The attributes on the element.
        /// </param>
        /// <returns>
        /// Returns the element.
        /// </returns>
        private Namespace ParseNamespace(
            CsElement parent,
            Reference<ICodePart> elementReference,
            Dictionary<string, List<CsElement>> partialElements,
            bool unsafeCode,
            bool generated,
            XmlHeader xmlHeader,
            ICollection<Attribute> attributes)
        {
            Param.AssertNotNull(parent, "parent");
            Param.AssertNotNull(elementReference, "elementReference");
            Param.AssertNotNull(partialElements, "partialElements");
            Param.Ignore(unsafeCode);
            Param.Ignore(generated);
            Param.Ignore(xmlHeader);
            Param.Ignore(attributes);

            // Add the namespace token.
            Node<CsToken> firstToken = this.tokens.InsertLast(this.GetToken(CsTokenType.Namespace, SymbolType.Namespace, elementReference));

            // Add the namespace name token.
            CsToken name = this.GetElementNameToken(elementReference, unsafeCode);
            this.tokens.Add(name);

            // Create the declaration.
            CsTokenList declarationTokens = new CsTokenList(this.tokens, firstToken, this.tokens.Last);
            Declaration declaration = new Declaration(declarationTokens, name.Text, ElementType.Namespace, AccessModifierType.Public);

            // Create the namespace.
            Namespace @namespace = new Namespace(this.document, parent, xmlHeader, attributes, declaration, unsafeCode, generated);
            elementReference.Target = @namespace;

            // Parse the body of the namespace.
            this.ParseElementContainer(@namespace, elementReference, partialElements, unsafeCode);

            return @namespace;
        }

        /// <summary>
        /// Parses an element's parameter list.
        /// </summary>
        /// <param name="elementReference">
        /// A reference to the element being created.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code is marked as unsafe.
        /// </param>
        /// <param name="openingBracketType">
        /// The type of the bracket which opens the parameter list.
        /// </param>
        /// <returns>
        /// Returns the collection of parameters.
        /// </returns>
        private IList<Parameter> ParseParameterList(Reference<ICodePart> elementReference, bool unsafeCode, SymbolType openingBracketType)
        {
            Param.AssertNotNull(elementReference, "elementReference");
            Param.Ignore(unsafeCode);
            Param.Ignore(openingBracketType);

            return this.ParseParameterList(elementReference, unsafeCode, openingBracketType, false);
        }

        /// <summary>
        /// Parses an element's parameter list.
        /// </summary>
        /// <param name="elementReference">
        /// A reference to the element being created.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code is marked as unsafe.
        /// </param>
        /// <param name="openingBracketType">
        /// The type of the bracket which opens the parameter list.
        /// </param>
        /// <param name="staticMethod">
        /// Indicates whether the parameters are part of a static method.
        /// </param>
        /// <returns>
        /// Returns the collection of parameters.
        /// </returns>
        private IList<Parameter> ParseParameterList(Reference<ICodePart> elementReference, bool unsafeCode, SymbolType openingBracketType, bool staticMethod)
        {
            Param.AssertNotNull(elementReference, "elementReference");
            Param.Ignore(unsafeCode);
            Param.Ignore(openingBracketType);
            Param.Ignore(staticMethod);

            CsTokenType openingBracketTokenType = CsTokenType.OpenParenthesis;
            CsTokenType closingBracketTokenType = CsTokenType.CloseParenthesis;
            SymbolType closingBracketType = SymbolType.CloseParenthesis;

            if (openingBracketType == SymbolType.OpenSquareBracket)
            {
                openingBracketTokenType = CsTokenType.OpenSquareBracket;
                closingBracketTokenType = CsTokenType.CloseSquareBracket;
                closingBracketType = SymbolType.CloseSquareBracket;
            }
            else
            {
                Debug.Assert(openingBracketType == SymbolType.OpenParenthesis, "The opening bracket type can only be a parenthesis or a square bracket.");
            }

            // Get the opening bracket.
            Bracket openingParenthesis = this.GetBracketToken(openingBracketTokenType, openingBracketType, elementReference);
            Node<CsToken> openingParenthesisNode = this.tokens.InsertLast(openingParenthesis);

            // Get each of the parameters.
            Symbol symbol = this.GetNextSymbol(elementReference);

            List<Parameter> parameters = new List<Parameter>();

            while (symbol.SymbolType != closingBracketType)
            {
                Reference<ICodePart> parameterReference = new Reference<ICodePart>();
                Node<CsToken> previousToken = this.tokens.Last;

                // Collect attributes on the parameter.
                while (symbol.SymbolType == SymbolType.OpenSquareBracket)
                {
                    Attribute attribute = this.GetAttribute(parameterReference, unsafeCode);
                    if (attribute == null)
                    {
                        throw this.CreateSyntaxException();
                    }

                    this.tokens.Add(attribute);
                    symbol = this.GetNextSymbol(parameterReference);
                }

                ParameterModifiers modifiers = ParameterModifiers.None;

                // If there is a parameter modifier, get it.
                if (symbol.SymbolType == SymbolType.Ref)
                {
                    this.tokens.Add(this.GetToken(CsTokenType.Ref, SymbolType.Ref, parameterReference));
                    modifiers |= ParameterModifiers.Ref;
                }
                else if (symbol.SymbolType == SymbolType.Out)
                {
                    this.tokens.Add(this.GetToken(CsTokenType.Out, SymbolType.Out, parameterReference));
                    modifiers |= ParameterModifiers.Out;
                }
                else if (symbol.SymbolType == SymbolType.Params)
                {
                    this.tokens.Add(this.GetToken(CsTokenType.Params, SymbolType.Params, parameterReference));
                    modifiers |= ParameterModifiers.Params;
                }
                else if (symbol.SymbolType == SymbolType.This)
                {
                    // The this keyword indicates that this is an extension method. This is only allowed if 
                    // both of the following are true:
                    // 1. This must be the first parameter.
                    // 2. The element must be a static method.
                    if (parameters.Count == 0 && staticMethod)
                    {
                        this.tokens.Add(this.GetToken(CsTokenType.This, SymbolType.This, parameterReference));
                        modifiers |= ParameterModifiers.This;
                    }
                }

                // Get the parameter type.
                TypeToken parameterType = this.GetTypeToken(parameterReference, unsafeCode, true);

                CsToken parameterName = null;
                if (parameterType.Text.Equals("__arglist", StringComparison.Ordinal))
                {
                    // When the parameterType is __arglist, this means that there is actually no parameter type at
                    // all, and the parameter name should be set to the __arglist token.
                    parameterName = parameterType.ChildTokens.First.Value;
                    parameterType = null;

                    parameterName.ParentRef = parameterReference;
                    this.tokens.Add(parameterName);
                }
                else
                {
                    this.tokens.Add(parameterType);

                    // Get the parameter name.
                    parameterName = this.GetToken(CsTokenType.Other, SymbolType.Other, parameterReference);
                    parameterName.ParentRef = parameterReference;

                    this.tokens.Add(parameterName);
                }

                // Get the optional default value for the parameter.
                Expression defaultArgument = null;

                symbol = this.GetNextSymbol(parameterReference);
                if (symbol.SymbolType == SymbolType.Equals)
                {
                    this.tokens.Add(this.GetOperatorToken(OperatorType.Equals, parameterReference));

                    // Get the default value expression.
                    defaultArgument = this.GetNextExpression(ExpressionPrecedence.None, parameterReference, unsafeCode);
                }

                // Create the list of tokens comprising the parameter, and trim any whitespace off the beginning and end.
                CsTokenList tokenList = new CsTokenList(this.tokens, previousToken.Next, this.tokens.Last);
                tokenList.Trim();

                Parameter parameter = new Parameter(
                    parameterType,
                    parameterName.Text,
                    elementReference,
                    modifiers,
                    defaultArgument,
                    parameterType == null ? parameterName.Location : CodeLocation.Join(parameterType.Location, parameterName.Location),
                    tokenList,
                    parameterType == null ? parameterName.Generated : parameterType.Generated || parameterName.Generated);

                parameterReference.Target = parameter;
                parameters.Add(parameter);

                if (defaultArgument != null)
                {
                    IWriteableCodeUnit writeableCodeUnit = (IWriteableCodeUnit)defaultArgument;
                    writeableCodeUnit.SetParent(parameter);
                }

                // If the next symbol, is a comma, get the next parameter.
                symbol = this.GetNextSymbol(elementReference);
                if (symbol.SymbolType == SymbolType.Comma)
                {
                    this.tokens.Add(this.GetToken(CsTokenType.Comma, SymbolType.Comma, elementReference));
                    symbol = this.GetNextSymbol(elementReference);
                }
            }

            // Get the closing bracket.
            Bracket closingParenthesis = this.GetBracketToken(closingBracketTokenType, closingBracketType, elementReference);
            Node<CsToken> closingParenthesisNode = this.tokens.InsertLast(closingParenthesis);

            openingParenthesis.MatchingBracketNode = closingParenthesisNode;
            closingParenthesis.MatchingBracketNode = openingParenthesisNode;

            // Return the parameters as a read-only collection.
            return parameters.ToArray();
        }

        /// <summary>
        /// Parses and returns a property.
        /// </summary>
        /// <param name="parent">The parent of the element.</param>
        /// <param name="elementReference">A reference to the element being created.</param>
        /// <param name="unsafeCode">Indicates whether the code is marked as unsafe.</param>
        /// <param name="generated">Indicates whether the code is marked as generated code.</param>
        /// <param name="xmlHeader">The element's documentation header.</param>
        /// <param name="attributes">The attributes on the element.</param>
        /// <returns>
        /// Returns the element.
        /// </returns>
        private Property ParseProperty(
            CsElement parent, Reference<ICodePart> elementReference, bool unsafeCode, bool generated, XmlHeader xmlHeader, ICollection<Attribute> attributes)
        {
            Param.AssertNotNull(parent, "parent");
            Param.AssertNotNull(elementReference, "elementReference");
            Param.Ignore(unsafeCode);
            Param.Ignore(generated);
            Param.Ignore(xmlHeader);
            Param.Ignore(attributes);

            Node<CsToken> previousTokenNode = this.tokens.Last;

            // Get the modifiers and access.
            AccessModifierType accessModifier = AccessModifierType.Private;

            // Properties within interfaces always have the access of the parent interface.
            Interface parentInterface = parent as Interface;
            if (parentInterface != null)
            {
                accessModifier = parentInterface.AccessModifier;
            }

            // Get declared modifiers.
            Dictionary<CsTokenType, CsToken> modifiers = this.GetElementModifiers(elementReference, ref accessModifier, PropertyModifiers);
            unsafeCode |= modifiers.ContainsKey(CsTokenType.Unsafe);

            // Check if the return type for the property is ref.
            Symbol nextSymbol = this.PeekNextSymbol(SkipSymbols.All, false);
            bool returnTypeIsRef = false;

            if (nextSymbol.SymbolType == SymbolType.Ref)
            {
                this.tokens.Add(this.GetToken(CsTokenType.Ref, SymbolType.Ref, elementReference));
                returnTypeIsRef = true;
            }

            // Get the field type.
            TypeToken propertyType = this.GetTypeToken(elementReference, unsafeCode, true);
            Node<CsToken> propertyTypeNode = this.tokens.InsertLast(propertyType);

            // Get the name of the property.
            CsToken name = this.GetElementNameToken(elementReference, unsafeCode);
            Node<CsToken> propertyNameNode = this.tokens.InsertLast(name);

            // Create the declaration.
            Node<CsToken> firstTokenNode = previousTokenNode == null ? this.tokens.First : previousTokenNode.Next;
            CsTokenList declarationTokens = new CsTokenList(this.tokens, firstTokenNode, this.tokens.Last);
            Declaration declaration = new Declaration(declarationTokens, name.Text, ElementType.Property, accessModifier, modifiers);

            Property property = new Property(this.document, parent, xmlHeader, attributes, declaration, propertyType, returnTypeIsRef, unsafeCode, generated);
            elementReference.Target = property;
            
            if (this.IsBodiedExpression())
            {
                this.ParseStatementContainer(property, true, unsafeCode);
            }
            else
            {
                // Parse the body of the property.
                this.ParseElementContainer(property, elementReference, null, unsafeCode);

                // Check if current property has initializer (C#6).
                nextSymbol = this.PeekNextSymbol(SkipSymbols.All, true);
                if (nextSymbol != null && nextSymbol.SymbolType == SymbolType.Equals)
                {
                    nextSymbol = this.GetNextSymbol(SkipSymbols.All, elementReference, true);

                    // Get all of the variable declarators.
                    IList<VariableDeclaratorExpression> declarators = this.ParsePropertyDeclarators(elementReference, unsafeCode, propertyType, propertyNameNode);

                    if (declarators.Count == 0)
                    {
                        throw this.CreateSyntaxException();
                    }

                    VariableDeclarationExpression declarationExpression =
                        new VariableDeclarationExpression(
                            new CsTokenList(this.tokens, declarators[0].Tokens.First, this.tokens.Last),
                            new LiteralExpression(this.tokens, propertyTypeNode),
                            declarators);

                    // Get the trailing semicolon.
                    this.tokens.Add(this.GetToken(CsTokenType.Semicolon, SymbolType.Semicolon, elementReference));

                    // Create the variable declaration statement and add it to the field.
                    property.VariableDeclarationStatement = new VariableDeclarationStatement(
                        new CsTokenList(this.tokens, declarators[0].Tokens.First, this.tokens.Last), false, false, declarationExpression);
                }
                else
                {
                    this.GetNextSymbol(SkipSymbols.WhiteSpace, elementReference, true);
                }
            }

            return property;
        }

        /// <summary>
        /// Parses and returns the declarators for a property (C#6).
        /// </summary>
        /// <param name="propertyReference">A reference to the field.</param>
        /// <param name="unsafeCode">Indicates whether the code is marked as unsafe.</param>
        /// <param name="propertyType">The field type.</param>
        /// <param name="identifierTokenNode">The identifier token node (Should be the property name).</param>
        /// <returns>
        /// Returns the declarators.
        /// </returns>
        private IList<VariableDeclaratorExpression> ParsePropertyDeclarators(Reference<ICodePart> propertyReference, bool unsafeCode, TypeToken propertyType, Node<CsToken> identifierTokenNode)
        {
            Param.AssertNotNull(propertyReference, "propertyReference");
            Param.Ignore(unsafeCode);
            Param.AssertNotNull(propertyType, "propertyType");
            Param.AssertNotNull(identifierTokenNode, "propertyType");

            List<VariableDeclaratorExpression> declarators = new List<VariableDeclaratorExpression>();
            Symbol symbol = this.GetNextSymbol(propertyReference);

            Reference<ICodePart> expressionReference = new Reference<ICodePart>();
            Expression initialization = null;

            while (symbol.SymbolType != SymbolType.Semicolon)
            {
                symbol = this.GetNextSymbol(expressionReference);
                if (symbol.SymbolType == SymbolType.Equals)
                {
                    this.tokens.Add(this.GetOperatorToken(OperatorType.Equals, expressionReference));

                    initialization = this.GetNextExpression(ExpressionPrecedence.None, expressionReference, unsafeCode);
                    if (initialization == null)
                    {
                        throw this.CreateSyntaxException();
                    }
                }

                VariableDeclaratorExpression variableDeclarationExpression =
                    new VariableDeclaratorExpression(
                        new CsTokenList(this.tokens, identifierTokenNode, this.tokens.Last), new LiteralExpression(this.tokens, identifierTokenNode), initialization);

                expressionReference.Target = variableDeclarationExpression;
                declarators.Add(variableDeclarationExpression);

                // Get next symbol without change index.
                symbol = this.symbols.Peek(1);
            }

            // Return the declarators as a read-only collection.
            return declarators.ToArray();
        }

        /// <summary>
        /// Parses one or more type constraint clauses.
        /// </summary>
        /// <param name="elementReference">
        /// A reference to the element being created.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code is marked as unsafe.
        /// </param>
        /// <returns>
        /// Returns the clauses.
        /// </returns>
        private ICollection<TypeParameterConstraintClause> ParseTypeConstraintClauses(Reference<ICodePart> elementReference, bool unsafeCode)
        {
            Param.AssertNotNull(elementReference, "elementReference");
            Param.Ignore(unsafeCode);

            List<TypeParameterConstraintClause> constraintClauses = new List<TypeParameterConstraintClause>();

            Symbol symbol = this.GetNextSymbol(elementReference);

            while (symbol.Text == "where")
            {
                Reference<ICodePart> constraintClauseReference = new Reference<ICodePart>();

                Node<CsToken> firstToken = this.tokens.InsertLast(this.GetToken(CsTokenType.Where, SymbolType.Other, constraintClauseReference));
                Node<CsToken> typeToken = this.tokens.InsertLast(this.GetToken(CsTokenType.Other, SymbolType.Other, constraintClauseReference));
                this.tokens.Add(this.GetToken(CsTokenType.WhereColon, SymbolType.Colon, constraintClauseReference));

                List<CsToken> constraints = new List<CsToken>();

                while (true)
                {
                    symbol = this.GetNextSymbol(constraintClauseReference);

                    CsToken constraintToken = null;

                    if (symbol.SymbolType == SymbolType.Class || symbol.SymbolType == SymbolType.Struct)
                    {
                        // A constraint of type class or struct.
                        constraintToken = this.GetToken(CsTokenType.Other, symbol.SymbolType, constraintClauseReference);
                    }
                    else if (symbol.SymbolType == SymbolType.New)
                    {
                        Reference<ICodePart> constructorConstraintReference = new Reference<ICodePart>();

                        // A constructor constraint.
                        MasterList<CsToken> childTokens = new MasterList<CsToken>();
                        childTokens.Add(this.GetToken(CsTokenType.Other, SymbolType.New, constraintClauseReference));

                        Bracket openParenthesis = this.GetBracketToken(CsTokenType.OpenParenthesis, SymbolType.OpenParenthesis, constraintClauseReference);
                        Bracket closeParenthesis = this.GetBracketToken(CsTokenType.CloseParenthesis, SymbolType.CloseParenthesis, constraintClauseReference);

                        Node<CsToken> openParenthesisNode = childTokens.InsertLast(openParenthesis);
                        Node<CsToken> closeParenthesisNode = childTokens.InsertLast(closeParenthesis);

                        openParenthesis.MatchingBracketNode = closeParenthesisNode;
                        closeParenthesis.MatchingBracketNode = openParenthesisNode;

                        constraintToken = new ConstructorConstraint(
                            childTokens, CsToken.JoinLocations(childTokens.First, childTokens.Last), constraintClauseReference, childTokens.First.Value.Generated);

                        constructorConstraintReference.Target = constraintToken;
                    }
                    else
                    {
                        // A type constraint.
                        constraintToken = this.GetTypeToken(constraintClauseReference, unsafeCode, true);
                    }

                    this.tokens.Add(constraintToken);
                    constraints.Add(constraintToken);

                    symbol = this.GetNextSymbol(constraintClauseReference);
                    if (symbol.SymbolType != SymbolType.Comma)
                    {
                        break;
                    }

                    this.tokens.Add(this.GetToken(CsTokenType.Comma, SymbolType.Comma, constraintClauseReference));
                }

                // Add the constraints as a read-only collection in a constraint clause.
                TypeParameterConstraintClause constraintClause = new TypeParameterConstraintClause(
                    new CsTokenList(this.tokens, firstToken, this.tokens.Last), typeToken.Value, constraints.ToArray(), elementReference);

                constraintClauseReference.Target = constraintClause;
                constraintClauses.Add(constraintClause);

                symbol = this.GetNextSymbol(elementReference);
            }

            // Return the constraint clauses as a read-only collection.
            return constraintClauses.ToArray();
        }

        /// <summary>
        /// Parses and returns a using directive.
        /// </summary>
        /// <param name="parent">
        /// The parent of the namespace.
        /// </param>
        /// <param name="elementReference">
        /// A reference to the element being created.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the code is marked as unsafe.
        /// </param>
        /// <param name="generated">
        /// Indicates whether the code is marked as generated code.
        /// </param>
        /// <returns>
        /// Returns the element.
        /// </returns>
        private UsingDirective ParseUsingDirective(CsElement parent, Reference<ICodePart> elementReference, bool unsafeCode, bool generated)
        {
            Param.AssertNotNull(parent, "parent");
            Param.AssertNotNull(elementReference, "elementReference");
            Param.Ignore(unsafeCode);
            Param.Ignore(generated);

            // Add the using token.
            Node<CsToken> firstToken = this.tokens.InsertLast(this.GetToken(CsTokenType.Using, SymbolType.Using, elementReference));

            int index = this.GetNextCodeSymbolIndex(2);
            if (index == -1)
            {
                throw this.CreateSyntaxException();
            }

            // Check static word introduce in C# 6
            Symbol staticSymbol = this.symbols.Peek(index);
            if (staticSymbol != null && staticSymbol.SymbolType == SymbolType.Static)
            {
                CsToken staticToken = this.GetToken(CsTokenType.Static, SymbolType.Static, elementReference);
                this.tokens.Add(staticToken);
            }

            // The next symbol will either be the namespace, or an alias. To determine this, look past this to see if there is an equals sign.
            Symbol peekAhead = this.GetNextSymbol(SymbolType.Other, elementReference);

            index = this.GetNextCodeSymbolIndex(2);
            if (index == -1)
            {
                throw this.CreateSyntaxException();
            }

            CsToken alias = null;

            peekAhead = this.symbols.Peek(index);
            if (peekAhead.SymbolType == SymbolType.Equals)
            {
                // There is an alias. First collect the alias.
                alias = this.GetToken(CsTokenType.Other, SymbolType.Other, elementReference);
                this.tokens.Add(alias);

                // Next collect the equals sign.
                this.tokens.Add(this.GetOperatorToken(OperatorType.Equals, elementReference));
            }

            // Collect and add the namespace token.
            TypeToken @namespace = this.GetTypeToken(elementReference, unsafeCode, false);
            this.tokens.Add(@namespace);

            // Create the declaration.
            CsTokenList declarationTokens = new CsTokenList(this.tokens, firstToken, this.tokens.Last);
            Declaration declaration = new Declaration(
                declarationTokens, alias == null ? @namespace.Text : alias.Text, ElementType.UsingDirective, AccessModifierType.Public);

            // Get the closing semicolon.
            this.tokens.Add(this.GetToken(CsTokenType.Semicolon, SymbolType.Semicolon, elementReference));

            // Create the using directive.
            UsingDirective element = new UsingDirective(this.document, parent, declaration, generated, staticSymbol.SymbolType == SymbolType.Static, @namespace.Text, alias == null ? null : alias.Text);
            elementReference.Target = element;

            return element;
        }

        /// <summary>
        /// Inspects the next few symbols after the open parenthesis and identifies the element type.
        /// </summary>
        /// <param name="testPosition">The position from current, at which the open parenthesis symbol exists</param>
        /// <returns>The element type that was detected.</returns>
        private ElementType DetectElementTypeForOpenParenthesis(int testPosition)
        {
            int foundPosition = this.DetectTupleType(testPosition);

            if (foundPosition == testPosition)
            {
                return ElementType.Method;
            }

            SymbolType symbolType = this.PeekNextSymbolFrom(foundPosition, SkipSymbols.All, false, out foundPosition).SymbolType;

            // The next symbol should be a 'this' keyword or a variable name.
            if (symbolType != SymbolType.This && symbolType != SymbolType.Other)
            {
                return ElementType.Method;
            }

            // Grab the next symbol, to detect the statement type.
            symbolType = this.PeekNextSymbolFrom(foundPosition, SkipSymbols.All, false, out foundPosition).SymbolType;

            if (symbolType == SymbolType.Semicolon || symbolType == SymbolType.Equals)
            {
                return ElementType.Field;
            }

            if (symbolType == SymbolType.OpenCurlyBracket || symbolType == SymbolType.Lambda)
            {
                return ElementType.Property;
            }

            if (symbolType == SymbolType.OpenSquareBracket)
            {
                return ElementType.Indexer;
            }

            return ElementType.Method;
        }

        #endregion
    }
}