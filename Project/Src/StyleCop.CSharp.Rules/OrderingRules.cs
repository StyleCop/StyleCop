// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OrderingRules.cs" company="https://github.com/StyleCop">
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
//   Check code ordering rules.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Linq;

    /// <summary>
    /// Check code ordering rules.
    /// </summary>
    [SourceAnalyzer(typeof(CsParser))]
    public class OrderingRules : SourceAnalyzer
    {
        #region Constants

        /// <summary>
        /// The default value of the generated code order property.
        /// </summary>
        internal const bool GeneratedCodeElementOrderDefaultValueProperty = true;

        /// <summary>
        /// The name of the generated code order property. 
        /// </summary>
        internal const string GeneratedCodeElementOrderProperty = "GeneratedCodeElementOrder";

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Checks the order of the elements within the given document.
        /// </summary>
        /// <param name="document">
        /// The document to check.
        /// </param>
        public override void AnalyzeDocument(CodeDocument document)
        {
            Param.RequireNotNull(document, "document");

            CsDocument csdocument = (CsDocument)document;

            if (csdocument.RootElement != null)
            {
                // Get the value of the GeneratedCodeElementOrder property.
                bool checkGeneratedCode = OrderingRules.GeneratedCodeElementOrderDefaultValueProperty;

                if (document.Settings != null)
                {
                    BooleanProperty setting = this.GetSetting(document.Settings, OrderingRules.GeneratedCodeElementOrderProperty) as BooleanProperty;
                    if (setting != null)
                    {
                        checkGeneratedCode = setting.Value;
                    }

                    // Check the rest of the elements.
                    this.ProcessElements(csdocument.RootElement, checkGeneratedCode);
                }

                this.CheckUsingDirectiveOrder(csdocument.RootElement);
            }
        }

        /// <inheritdoc />
        public override bool DoAnalysis(CodeDocument document)
        {
            Param.RequireNotNull(document, "document");

            CsDocument csdocument = (CsDocument)document;

            return csdocument.FileHeader == null || !csdocument.FileHeader.UnStyled;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Converts an access modifier type to a human readable string.
        /// </summary>
        /// <param name="type">
        /// The type to convert.
        /// </param>
        /// <returns>
        /// Returns the human readable string.
        /// </returns>
        private static string AccessModifierTypeString(AccessModifierType type)
        {
            Param.Ignore(type);

            switch (type)
            {
                case AccessModifierType.Public:
                    return "public";
                case AccessModifierType.Internal:
                    return "internal";
                case AccessModifierType.Protected:
                    return "protected";
                case AccessModifierType.Private:
                    return "private";
                case AccessModifierType.ProtectedInternal:
                    return "protected internal";
                default:
                    Debug.Fail("Unexpected access modifier keyword");
                    throw new InvalidOperationException();
            }
        }

        /// <summary>
        /// Determines whether the two namespaces are ordered correctly.
        /// </summary>
        /// <param name="namespace1">
        /// The first namespace.
        /// </param>
        /// <param name="namespace2">
        /// The second namespace.
        /// </param>
        /// <returns>
        /// Returns true if the namespaces are ordered correctly, false otherwise.
        /// </returns>
        [SuppressMessage("Microsoft.Globalization", "CA1309:UseOrdinalStringComparison", 
            MessageId = "System.String.Compare(System.String,System.String,System.StringComparison)", 
            Justification = "InvariantCulture comparison is necessary for correct namespace comparison.")]
        private static bool CheckNamespaceOrdering(string namespace1, string namespace2)
        {
            // Use the CurrentCulture to compare namespaces for languages with different compare styles
            Param.AssertNotNull(namespace1, "namespace1");
            Param.AssertNotNull(namespace2, "namespace2");

            // Split each namespace into parts.
            string[] namespace1Parts = namespace1.Split('.');
            string[] namespace2Parts = namespace2.Split('.');

            namespace1Parts[0] = namespace1Parts[0].SubstringAfter("global::", StringComparison.CurrentCulture);
            namespace2Parts[0] = namespace2Parts[0].SubstringAfter("global::", StringComparison.CurrentCulture);

            // Figure out which namespace has fewer parts.
            int partCount = Math.Min(namespace1Parts.Length, namespace2Parts.Length);

            // Compare each part of the namespaces.
            for (int i = 0; i < partCount; ++i)
            {
                int comparison = string.Compare(namespace1Parts[i], namespace2Parts[i], StringComparison.CurrentCultureIgnoreCase);
                if (comparison < 0)
                {
                    // The order is correct. For example: 
                    // A.B.C
                    // A.C.D
                    return true;
                }

                if (comparison > 0)
                {
                    // The order is incorrect. For example:
                    // A.C.D
                    // A.B.C
                    return false;
                }

                // The two parts are equal or differ only by case.
                comparison = string.Compare(namespace1Parts[i], namespace2Parts[i], StringComparison.CurrentCulture);
                if (comparison < 0)
                {
                    // The order is correct. For example:
                    // A.Ab.C
                    // A.AB.C
                    return true;
                }

                if (comparison > 0)
                {
                    // The order is incorrect. For example:
                    // A.AB.C
                    // A.Ab.C
                    return false;
                }
            }

            // The namespaces are either equal, or one is longer than the other.
            if (namespace1Parts.Length == namespace2Parts.Length)
            {
                // The namespaces are identical.
                return true;
            }

            // If the first namespace is shorter than the second namespace, then they are in the right order.
            return namespace1Parts.Length < namespace2Parts.Length;
        }

        /// <summary>
        /// Returns an order number for the passed in element.
        /// </summary>
        /// <param name="element">
        /// The element to calculate the order of.
        /// </param>
        /// <returns>
        /// The calculated order of the element.
        /// </returns>
        private static int GetElementOrder(CsElement element)
        {
            Param.AssertNotNull(element, "first");

            bool isReadonly = element.Declaration.ContainsModifier(CsTokenType.Readonly);
            bool isStatic = element.Declaration.ContainsModifier(CsTokenType.Static);

            if (element.Declaration.ContainsModifier(CsTokenType.Const))
            {
                return 0;
            }

            if (isStatic && isReadonly)
            {
                return 1;
            }

            if (isStatic)
            {
                return 2;
            }

            if (isReadonly)
            {
                return 3;
            }

            return 4;
        }

        /// <summary>
        /// Checks the order of child elements of the given element.
        /// </summary>
        /// <param name="element">
        /// The element to check.
        /// </param>
        /// <param name="checkGeneratedCode">
        /// Indicates whether to check the order of elements
        /// within generated blocks of code.
        /// </param>
        private void CheckChildElementOrdering(CsElement element, bool checkGeneratedCode)
        {
            Param.AssertNotNull(element, "element");
            Param.Ignore(checkGeneratedCode);

            // Check the ordering of this element compared with other elements at the same level.
            if (element.ChildElements.Count > 0)
            {
                bool firstValid = true;

                CsElement[] elementsArray = new CsElement[element.ChildElements.Count];
                element.ChildElements.CopyTo(elementsArray, 0);

                for (int i = 0; i < elementsArray.Length; ++i)
                {
                    CsElement first = elementsArray[i];

                    if (first.AnalyzerTag == null)
                    {
                        for (int j = i + 1; j < elementsArray.Length; ++j)
                        {
                            CsElement second = elementsArray[j];

                            if (second.AnalyzerTag == null)
                            {
                                // If we're supposed to be checking the order of generated code as well,
                                // then only perform this check if at least one of the two elements is not 
                                // generated code. Otherwise, only perform this check if both of the two 
                                // elements is not generated code.
                                if ((checkGeneratedCode && (!first.Generated || !second.Generated)) || (!checkGeneratedCode && !first.Generated && !second.Generated))
                                {
                                    // Determine whether first is actually supposed to come before second
                                    if (!this.CompareItems(first, second, !firstValid))
                                    {
                                        // Determine whether this means that first is out of order or second
                                        // is out of order. If we have not found the first item in the list that
                                        // is in the correct order, then first is marked out of order, otherwise
                                        // second is marked out of order.
                                        if (firstValid)
                                        {
                                            first.AnalyzerTag = false;
                                        }
                                        else
                                        {
                                            second.AnalyzerTag = false;
                                        }
                                    }
                                    else
                                    {
                                        // At this point we know that we've found an item that is in the correct order.
                                        if (firstValid)
                                        {
                                            firstValid = false;
                                        }
                                    }

                                    // If both of the elements are accessors, check that they appear in the correct order.
                                    if (first.ElementType == ElementType.Accessor && second.ElementType == ElementType.Accessor)
                                    {
                                        Accessor firstAccessor = (Accessor)first;
                                        Accessor secondAccessor = (Accessor)second;

                                        if (firstAccessor.AccessorType == AccessorType.Set && secondAccessor.AccessorType == AccessorType.Get)
                                        {
                                            this.AddViolation(first, Rules.PropertyAccessorsMustFollowOrder);
                                        }
                                        else if (firstAccessor.AccessorType == AccessorType.Remove && secondAccessor.AccessorType == AccessorType.Add)
                                        {
                                            this.AddViolation(first, Rules.EventAccessorsMustFollowOrder);
                                        }
                                    }
                                }
                            }
                        }
                    }

                    this.CheckElementOrder(first, checkGeneratedCode);
                }
            }
        }

        /// <summary>
        /// Checks the order of the declarations in a keyword. Access modifier should come first,
        /// followed by the 'static' keyword if the element is static, followed by all other keywords.
        /// </summary>
        /// <param name="element">
        /// The element of code to check.
        /// </param>
        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Minimizing refactoring before release.")]
        private void CheckDeclarationKeywordOrder(CsElement element)
        {
            Param.AssertNotNull(element, "element");

            int accessModifierIndex = -1;
            int staticIndex = -1;
            int otherWordIndex = -1;

            int index = 0;

            foreach (CsToken token in element.Declaration.Tokens)
            {
                CsTokenType type = token.CsTokenType;
                if (type == CsTokenType.Private || type == CsTokenType.Public || type == CsTokenType.Protected || type == CsTokenType.Internal)
                {
                    if (accessModifierIndex == -1)
                    {
                        accessModifierIndex = index++;
                    }
                }
                else if (type == CsTokenType.Static)
                {
                    if (staticIndex == -1)
                    {
                        staticIndex = index++;
                    }
                }
                else if (type != CsTokenType.WhiteSpace && type != CsTokenType.EndOfLine && type != CsTokenType.SingleLineComment && type != CsTokenType.MultiLineComment)
                {
                    if (otherWordIndex == -1)
                    {
                        otherWordIndex = index++;
                    }
                }
            }

            if (accessModifierIndex != -1)
            {
                if (staticIndex > -1 && staticIndex < accessModifierIndex)
                {
                    this.AddViolation(
                        element, Rules.DeclarationKeywordsMustFollowOrder, Strings.AccessModifier, string.Format(CultureInfo.InvariantCulture, "'{0}'", Strings.Static));
                }

                if (otherWordIndex > -1 && otherWordIndex < accessModifierIndex)
                {
                    this.AddViolation(
                        element, Rules.DeclarationKeywordsMustFollowOrder, Strings.AccessModifier, string.Format(CultureInfo.InvariantCulture, "'{0}'", Strings.Other));
                }
            }

            if (staticIndex > -1)
            {
                if (otherWordIndex > -1 && otherWordIndex < staticIndex)
                {
                    this.AddViolation(
                        element, 
                        Rules.DeclarationKeywordsMustFollowOrder, 
                        string.Format(CultureInfo.InvariantCulture, "'{0}'", Strings.Static), 
                        string.Format(CultureInfo.InvariantCulture, "'{0}'", Strings.Other));
                }
            }

            // Check to make sure that 'protected' comes just before 'internal'.
            if (element.Declaration.AccessModifierType == AccessModifierType.ProtectedInternal)
            {
                bool foundProtected = false;
                foreach (CsToken token in element.Declaration.Tokens)
                {
                    if (foundProtected)
                    {
                        if (token.CsTokenType == CsTokenType.Internal)
                        {
                            break;
                        }
                        else if (token.CsTokenType != CsTokenType.WhiteSpace)
                        {
                            this.AddViolation(element, Rules.ProtectedMustComeBeforeInternal);
                            break;
                        }
                    }
                    else
                    {
                        if (token.CsTokenType == CsTokenType.Protected)
                        {
                            foundProtected = true;
                        }
                        else if (token.CsTokenType == CsTokenType.Internal)
                        {
                            this.AddViolation(element, Rules.ProtectedMustComeBeforeInternal);
                            break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Checks the order of elements that appear within the given element.
        /// </summary>
        /// <param name="element">
        /// The element to check.
        /// </param>
        /// <param name="checkGeneratedCode">
        /// True to check the element order of generated code blocks.
        /// </param>
        private void CheckElementOrder(CsElement element, bool checkGeneratedCode)
        {
            Param.AssertNotNull(element, "element");
            Param.Ignore(checkGeneratedCode);

            // Check the ordering of the keywords in the element's declaration.
            if (!element.Generated
                && (element.ElementType == ElementType.Class || element.ElementType == ElementType.Field || element.ElementType == ElementType.Enum
                    || element.ElementType == ElementType.Struct || element.ElementType == ElementType.Interface || element.ElementType == ElementType.Delegate
                    || element.ElementType == ElementType.Event || element.ElementType == ElementType.Property || element.ElementType == ElementType.Indexer
                    || element.ElementType == ElementType.Method || element.ElementType == ElementType.Constructor || element.ElementType == ElementType.Accessor))
            {
                this.CheckDeclarationKeywordOrder(element);
            }

            // Make sure that using directives are inside of namespace elements. 
            this.CheckUsingDirectivePlacement(element);

            // Checks the order of the children of this element.
            this.CheckChildElementOrdering(element, checkGeneratedCode);
        }

        /// <summary>
        /// Checks the order of the using directives in the given list.
        /// </summary>
        /// <param name="usings">
        /// The list of using directives.
        /// </param>
        private void CheckOrderOfUsingDirectivesInList(List<UsingDirective> usings)
        {
            Param.AssertNotNull(usings, "usings");

            for (int i = 0; i < usings.Count; ++i)
            {
                UsingDirective firstUsing = usings[i];

                for (int j = i + 1; j < usings.Count; ++j)
                {
                    UsingDirective secondUsing = usings[j];

                    if (!this.CompareOrderOfUsingDirectives(firstUsing, secondUsing))
                    {
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Checks the order of any using directives found under this element.
        /// </summary>
        /// <param name="element">
        /// The element containing the using directives.
        /// </param>
        private void CheckOrderOfUsingDirectivesUnderElement(CsElement element)
        {
            Param.AssertNotNull(element, "element");

            // Add each of the using directives to an array.
            List<UsingDirective> usings = null;

            foreach (CsElement childElement in element.ChildElements)
            {
                if (childElement.ElementType == ElementType.UsingDirective)
                {
                    if (usings == null)
                    {
                        usings = new List<UsingDirective>();
                    }

                    usings.Add((UsingDirective)childElement);
                }
                else if (childElement.ElementType != ElementType.ExternAliasDirective)
                {
                    break;
                }
            }

            if (usings != null)
            {
                this.CheckOrderOfUsingDirectivesInList(usings);
            }
        }

        /// <summary>
        /// Checks the order of using directives within the document.
        /// </summary>
        /// <param name="rootElement">
        /// The root element containing the using directives.
        /// </param>
        private void CheckUsingDirectiveOrder(CsElement rootElement)
        {
            Param.AssertNotNull(rootElement, "rootElement");

            if (!rootElement.Generated)
            {
                this.CheckOrderOfUsingDirectivesUnderElement(rootElement);

                // Find any namespace elements within this element.
                foreach (CsElement childElement in rootElement.ChildElements)
                {
                    if (childElement.ElementType == ElementType.Namespace)
                    {
                        this.CheckUsingDirectiveOrder(childElement);
                    }
                }
            }
        }

        /// <summary>
        /// Checks that using-directives are placed within the namespace element.
        /// </summary>
        /// <param name="element">
        /// The element to check.
        /// </param>
        private void CheckUsingDirectivePlacement(CsElement element)
        {
            Param.AssertNotNull(element, "element");

            // Only check the positioning of using directives which are not within generated code.
            if (!element.Generated && element.ElementType == ElementType.UsingDirective)
            {
                CsElement parentElement = element.FindParentElement();
                if (parentElement != null && parentElement.ElementType != ElementType.Namespace)
                {
                    // This is acceptable if there is no namespace in the file at all.
                    bool foundNamespace = false;
                    if (parentElement.ElementType == ElementType.Root)
                    {
                        foreach (CsElement child in parentElement.ChildElements)
                        {
                            if (child.ElementType == ElementType.Namespace)
                            {
                                foundNamespace = true;
                                break;
                            }
                        }
                    }

                    // Its also acceptable if there is an assembly attribute too.
                    bool foundAssemblyAttribute = false;
                    if (parentElement.ElementType == ElementType.Root)
                    {
                        foreach (CsElement child in parentElement.ChildElements)
                        {
                            if (child.ElementType == ElementType.AssemblyOrModuleAttribute)
                            {
                                foundAssemblyAttribute = true;
                                break;
                            }
                        }
                    }

                    if (foundNamespace && !foundAssemblyAttribute)
                    {
                        this.AddViolation(element, Rules.UsingDirectivesMustBePlacedWithinNamespace);
                    }
                }
            }
        }

        /// <summary>
        /// Compares two items to determine if they are in the correct order.
        /// </summary>
        /// <param name="first">
        /// The first item to compare.
        /// </param>
        /// <param name="second">
        /// The second item to compare.
        /// </param>
        /// <param name="foundFirst">
        /// Determines whether we've found the first item
        /// in the code that is in the correct order.
        /// </param>
        /// <returns>
        /// Returns true if the first item should come before the second item, or false if vice-versa.
        /// </returns>
        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Minimizing refactoring before release.")]
        private bool CompareItems(CsElement first, CsElement second, bool foundFirst)
        {
            Param.AssertNotNull(first, "first");
            Param.AssertNotNull(second, "second");
            Param.Ignore(foundFirst);

            // We don't care about the order of accessors and we don't care about the order of empty elements.
            if ((first.ElementType != ElementType.EmptyElement && second.ElementType != ElementType.EmptyElement)
                && (first.ElementType != ElementType.Accessor || second.ElementType != ElementType.Accessor))
            {
                // If the order turns out to be incorrect, determine which of the items is at fault.
                CsElement invalidElement = second;
                if (!foundFirst)
                {
                    invalidElement = first;
                }

                // Check the item types to see if the second item type should appear before the first item type.
                if (first.ElementType > second.ElementType)
                {
                    this.AddViolation(
                        first, invalidElement.LineNumber, Rules.ElementsMustAppearInTheCorrectOrder, first.FriendlyPluralTypeText, second.FriendlyPluralTypeText);

                    return false;
                }
                else if (first.ElementType == second.ElementType)
                {
                    // Make sure that both items have a declaration, or else we can go no further.
                    if (first.Declaration != null && second.Declaration != null)
                    {
                        // Check the access modifiers to see if they are in the correct order.
                        if (first.Declaration.AccessModifierType > second.Declaration.AccessModifierType)
                        {
                            if (!this.IsSpecialCaseExclusion(first, second))
                            {
                                // If one of the elements is partial and does not have an access modifier defined, and the element
                                // is not a method, show a special message. Partial methods are not allowed to have modifiers and are 
                                // private by default.
                                if ((!first.Declaration.AccessModifier && first.ElementType != ElementType.Method
                                     && first.Declaration.ContainsModifier(CsTokenType.Partial))
                                    || (!second.Declaration.AccessModifier && second.ElementType != ElementType.Method
                                        && second.Declaration.ContainsModifier(CsTokenType.Partial)))
                                {
                                    // Make sure to use the line number of the partial element which does not contain
                                    // an access modifier.
                                    CsElement elementWithoutAccessModifier = first;
                                    if (first.Declaration.AccessModifier || !first.Declaration.ContainsModifier(CsTokenType.Partial))
                                    {
                                        elementWithoutAccessModifier = second;
                                    }

                                    this.AddViolation(
                                        elementWithoutAccessModifier, 
                                        Rules.PartialElementsMustDeclareAccess, 
                                        elementWithoutAccessModifier.FriendlyTypeText, 
                                        elementWithoutAccessModifier.FriendlyPluralTypeText);
                                }
                                else
                                {
                                    this.AddViolation(
                                        first, 
                                        invalidElement.LineNumber, 
                                        Rules.ElementsMustBeOrderedByAccess, 
                                        OrderingRules.AccessModifierTypeString(first.Declaration.AccessModifierType), 
                                        first.FriendlyPluralTypeText, 
                                        OrderingRules.AccessModifierTypeString(second.Declaration.AccessModifierType), 
                                        second.FriendlyPluralTypeText);
                                }

                                return false;
                            }
                        }
                        else if (first.Declaration.AccessModifierType == second.Declaration.AccessModifierType)
                        {
                            // order should be :
                            // 0  const
                            // 1  static readonly
                            // 2  static non-readonly
                            // 3  instance readonly
                            // 4  instance non-readonly
                            int firstOrder = GetElementOrder(first);
                            int secondOrder = GetElementOrder(second);

                            // Check to make sure that constant are first
                            if (secondOrder == 0 && firstOrder > 0)
                            {
                                this.AddViolation(first, invalidElement.LineNumber, Rules.ConstantsMustAppearBeforeFields);
                                return false;
                            }

                            // Static Readonly fields are next
                            if (secondOrder == 1 && firstOrder == 2)
                            {
                                this.AddViolation(
                                    first, 
                                    invalidElement.LineNumber, 
                                    Rules.StaticReadonlyElementsMustAppearBeforeStaticNonReadonlyElements, 
                                    OrderingRules.AccessModifierTypeString(first.Declaration.AccessModifierType), 
                                    first.FriendlyPluralTypeText, 
                                    OrderingRules.AccessModifierTypeString(second.Declaration.AccessModifierType), 
                                    second.FriendlyPluralTypeText);

                                return false;
                            }

                            if (secondOrder == 1 && firstOrder > 2)
                            {
                                this.AddViolation(
                                    first, 
                                    invalidElement.LineNumber, 
                                    Rules.StaticElementsMustAppearBeforeInstanceElements, 
                                    OrderingRules.AccessModifierTypeString(first.Declaration.AccessModifierType), 
                                    first.FriendlyPluralTypeText, 
                                    OrderingRules.AccessModifierTypeString(second.Declaration.AccessModifierType), 
                                    second.FriendlyPluralTypeText);

                                return false;
                            }

                            // Static non-Readonly fields are next
                            if (secondOrder == 2 && firstOrder > 2)
                            {
                                this.AddViolation(
                                    first, 
                                    invalidElement.LineNumber, 
                                    Rules.StaticElementsMustAppearBeforeInstanceElements, 
                                    OrderingRules.AccessModifierTypeString(first.Declaration.AccessModifierType), 
                                    first.FriendlyPluralTypeText, 
                                    OrderingRules.AccessModifierTypeString(second.Declaration.AccessModifierType), 
                                    second.FriendlyPluralTypeText);

                                return false;
                            }

                            // instance readonly
                            if (secondOrder == 3 && firstOrder > 3)
                            {
                                this.AddViolation(
                                    first, 
                                    invalidElement.LineNumber, 
                                    Rules.InstanceReadonlyElementsMustAppearBeforeInstanceNonReadonlyElements, 
                                    OrderingRules.AccessModifierTypeString(first.Declaration.AccessModifierType), 
                                    first.FriendlyPluralTypeText, 
                                    OrderingRules.AccessModifierTypeString(second.Declaration.AccessModifierType), 
                                    second.FriendlyPluralTypeText);

                                return false;
                            }
                        }
                        else if (first.ElementType == ElementType.Constructor && second.ElementType == ElementType.Constructor
                                 && second.Declaration.ContainsModifier(CsTokenType.Static) && !first.Declaration.ContainsModifier(CsTokenType.Static))
                        {
                            // If we have 2 constructors and the second one is static then they're in the wrong order, since static 
                            // constructors must always come in front of all instance constructors.
                            this.AddViolation(
                                first, 
                                invalidElement.LineNumber, 
                                Rules.StaticElementsMustAppearBeforeInstanceElements, 
                                OrderingRules.AccessModifierTypeString(second.Declaration.AccessModifierType), 
                                second.FriendlyPluralTypeText, 
                                OrderingRules.AccessModifierTypeString(first.Declaration.AccessModifierType), 
                                first.FriendlyPluralTypeText);

                            return false;
                        }
                    }
                }
            }

            return true;
        }

        private bool IsSpecialCaseExclusion(CsElement first, CsElement second)
        {
            //// Note: While many checks here are redundant/unnecessary, they are explictly specified to
            //// avoid any ambiguity.
            
            // Special case for static constructors, which are always private but should still appear in front of all other constructors.
            if (first.ElementType == ElementType.Constructor && second.ElementType == ElementType.Constructor
                && first.Declaration.ContainsModifier(CsTokenType.Static) && !second.Declaration.ContainsModifier(CsTokenType.Static))
            {
                return true;
            }

            // Special case for readonly dependency property pattern.
            if (first.ElementType == ElementType.Field && second.ElementType == ElementType.Field && 
                first.Declaration.ContainsModifier(CsTokenType.Static) && second.Declaration.ContainsModifier(CsTokenType.Static)
                && first.AccessModifier == AccessModifierType.Private && second.AccessModifier == AccessModifierType.Public
                && first.Declaration.Tokens.Any(t => t.CsTokenClass == CsTokenClass.Type && t.Text == "DependencyPropertyKey"))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Compares the order of two using directives.
        /// </summary>
        /// <param name="firstUsing">
        /// The first using directive.
        /// </param>
        /// <param name="secondUsing">
        /// The second using directive.
        /// </param>
        /// <returns>
        /// Returns false if the elements are out of order.
        /// </returns>
        private bool CompareOrderOfUsingDirectives(UsingDirective firstUsing, UsingDirective secondUsing)
        {
            Param.AssertNotNull(firstUsing, "firstUsing");
            Param.AssertNotNull(secondUsing, "secondUsing");

            // UsingNamespace
            if (!firstUsing.IsStatic && string.IsNullOrEmpty(firstUsing.Alias))
            {
                if (secondUsing.IsStatic || !string.IsNullOrEmpty(secondUsing.Alias))
                {
                    // A UsingNamespace is followed by a UsingStatic or UsingAlias
                    return true;
                }
            }

            // UsingStatic
            if (firstUsing.IsStatic)
            {
                if (!string.IsNullOrEmpty(secondUsing.Alias))
                {
                    // A UsingStatic is followed by a UsingAlias
                    return true;
                }

                if (!secondUsing.IsStatic)
                {
                    // A UsingStatic is followed by a UsingNamespace
                    this.AddViolation(firstUsing, Rules.UsingStaticDirectivesMustBePlacedAtTheCorrectLocation);
                    return false;
                }
            }

            // UsingAlias
            if (!string.IsNullOrEmpty(firstUsing.Alias))
            {
                if (string.IsNullOrEmpty(secondUsing.Alias) || secondUsing.IsStatic)
                {
                    // A UsingAlias is followed by a UsingNamespace or UsingStatic
                    this.AddViolation(firstUsing, Rules.UsingAliasDirectivesMustBePlacedAfterOtherUsingDirectives);
                    return false;
                }

                if (!string.IsNullOrEmpty(secondUsing.Alias))
                {
                    // Both of the usings are aliases. Verify that they are sorted alphabetically by the alias name.
                    if (string.Compare(firstUsing.Alias, secondUsing.Alias, StringComparison.OrdinalIgnoreCase) > 0)
                    {
                        // The usings are not sorted alphabetically by the alias.
                        this.AddViolation(firstUsing, Rules.UsingAliasDirectivesMustBeOrderedAlphabeticallyByAliasName);
                        return false;
                    }

                    return true;
                }
            }

            bool isFirstSystem = firstUsing.NamespaceType.StartsWith("System", StringComparison.Ordinal)
                || firstUsing.NamespaceType.StartsWith("global::System", StringComparison.Ordinal);
            bool isSecondSystem = secondUsing.NamespaceType.StartsWith("System", StringComparison.Ordinal)
                || secondUsing.NamespaceType.StartsWith("global::System", StringComparison.Ordinal);

            // Neither of the usings is an alias. First, ensure that System namespaces are placed above all
            // non-System namespaces.
            if (isSecondSystem && !isFirstSystem)
            {
                this.AddViolation(secondUsing, Rules.SystemUsingDirectivesMustBePlacedBeforeOtherUsingDirectives);
                return false;
            }
            else if ((isFirstSystem && isSecondSystem) || (!isFirstSystem && !isSecondSystem))
            {
                if (!CheckNamespaceOrdering(firstUsing.NamespaceType, secondUsing.NamespaceType))
                {
                    // The usings are not in alphabetical order by namespace.
                    this.AddViolation(firstUsing, Rules.UsingDirectivesMustBeOrderedAlphabeticallyByNamespace);
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Checks the given code element.
        /// </summary>
        /// <param name="element">
        /// The code element to check.
        /// </param>
        /// <param name="checkGeneratedCode">
        /// True to check the element order of generated code blocks.
        /// </param>
        /// <returns>
        /// Returns false if the analyzer should quit.
        /// </returns>
        private bool ProcessElements(CsElement element, bool checkGeneratedCode)
        {
            Param.AssertNotNull(element, "element");
            Param.Ignore(checkGeneratedCode);

            if (this.Cancel)
            {
                return false;
            }

            this.CheckElementOrder(element, checkGeneratedCode);

            return true;
        }

        #endregion
    }
}