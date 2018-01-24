// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NamingRules.cs" company="https://github.com/StyleCop">
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
//   Checks the names of code elements.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Checks the names of code elements.
    /// </summary>
    [SourceAnalyzer(typeof(CsParser))]
    public class NamingRules : SourceAnalyzer
    {
        #region Constants

        /// <summary>
        /// The name of the property containing the list of allowable prefixes.
        /// </summary>
        internal const string AllowedPrefixesProperty = "Hungarian";

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the property pages to expose on the StyleCop settings dialog for this analyzer.
        /// </summary>
        [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = "The form will be disposed by the caller.")]
        public override ICollection<IPropertyControlPage> SettingsPages
        {
            get
            {
                return new IPropertyControlPage[] { new ValidPrefixes(this) };
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Checks the case of element names within the given document.
        /// </summary>
        /// <param name="document">
        /// The document to check.
        /// </param>
        public override void AnalyzeDocument(CodeDocument document)
        {
            Param.RequireNotNull(document, "document");

            CsDocument csdocument = (CsDocument)document;

            if (csdocument.RootElement != null && !csdocument.RootElement.Generated)
            {
                Dictionary<string, string> validPrefixes = this.GetPrefixes(document.Settings);
                this.ProcessElement(csdocument.RootElement, validPrefixes, false);
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
        /// Determines whether the given variable name begins with a standard prefix notation.
        /// </summary>
        /// <param name="name">
        /// The variable name.
        /// </param>
        /// <returns>
        /// Returns the first index in the name string that lies just past the prefix,
        /// or zero if there is no prefix.
        /// </returns>
        private static int MovePastPrefix(string name)
        {
            Param.AssertValidString(name, "name");

            // If the variable name contains a prefix, skip past it.
            if (name.StartsWith("s_", StringComparison.Ordinal) || name.StartsWith("m_", StringComparison.Ordinal) || name.StartsWith("__", StringComparison.Ordinal))
            {
                return 2;
            }
            else if (name.StartsWith("_", StringComparison.Ordinal) || name.StartsWith("@", StringComparison.Ordinal))
            {
                if (name.Length > 1)
                {
                    return 1;
                }
            }

            return 0;
        }

        /// <summary>
        /// Checks the case of the first character in the given word.
        /// </summary>
        /// <param name="element">
        /// The element that the word appears in.
        /// </param>
        /// <param name="name">
        /// The word to check.
        /// </param>
        /// <param name="line">
        /// The line that the word appears on.
        /// </param>
        /// <param name="upper">
        /// True if the character should be upper, false if it should be lower.
        /// </param>
        private void CheckCase(CsElement element, string name, int line, bool upper)
        {
            Param.AssertNotNull(element, "element");
            Param.AssertValidString(name, "name");
            Param.AssertGreaterThanZero(line, "line");
            Param.Ignore(upper);

            if (name.Length >= 1)
            {
                char firstLetter = name[0];

                // If the first character is not a letter, then it does not make any sense to check
                // for upper or lower case.
                if (char.IsLetter(firstLetter))
                {
                    if (upper)
                    {
                        if (char.IsLower(firstLetter))
                        {
                            // We check for IsLower and not for !isUpper. This is for cultures that don't have Upper or Lower case
                            // letters like Chinese.
                            this.AddViolation(element, line, Rules.ElementMustBeginWithUpperCaseLetter, element.FriendlyTypeText, name);
                        }
                    }
                    else
                    {
                        if (char.IsUpper(firstLetter))
                        {
                            this.AddViolation(element, line, Rules.ElementMustBeginWithLowerCaseLetter, element.FriendlyTypeText, name);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Checks a field for compliance with naming prefix rules.
        /// </summary>
        /// <param name="field">
        /// The field element.
        /// </param>
        /// <param name="validPrefixes">
        /// A list of valid prefixes that should not be considered hungarian.
        /// </param>
        private void CheckFieldPrefix(Field field, Dictionary<string, string> validPrefixes)
        {
            Param.AssertNotNull(field, "field");
            Param.Ignore(validPrefixes);

            // Skip past any prefixes in the name.
            int index = NamingRules.MovePastPrefix(field.Declaration.Name);

            // Check whether the name starts with a lower-case letter.
            if (char.IsLower(field.Declaration.Name, index))
            {
                // Check for hungarian notation.
                this.CheckHungarian(field.Declaration.Name, index, field.LineNumber, field, validPrefixes);

                // Check casing on the field.
                if (field.Const)
                {
                    // Const fields must start with an upper-case letter.
                    this.AddViolation(field, field.LineNumber, Rules.ConstFieldNamesMustBeginWithUpperCaseLetter, field.Declaration.Name);
                }
                else if (field.AccessModifier == AccessModifierType.Public || field.AccessModifier == AccessModifierType.Internal
                         || field.AccessModifier == AccessModifierType.ProtectedInternal)
                {
                    // Public or internal fields must start with an upper-case letter.
                    this.AddViolation(field, field.LineNumber, Rules.AccessibleFieldsMustBeginWithUpperCaseLetter, field.Declaration.Name);
                }

                // Readonly fields non-private must start with an upper-case letter.
                if (field.Readonly && field.AccessModifier != AccessModifierType.Private)
                {
                    this.AddViolation(field, field.LineNumber, Rules.NonPrivateReadonlyFieldsMustBeginWithUpperCaseLetter, field.Declaration.Name);
                }

                // Readonly static fields must start with an upper-case letter.
                if (field.Readonly && field.Static)
                {
                    this.AddViolation(field, field.LineNumber, Rules.StaticReadonlyFieldsMustBeginWithUpperCaseLetter, field.Declaration.Name);
                }
            }
            else if (char.IsUpper(field.Declaration.Name, index))
            {
                // We check for IsUpper here as some languages don't have Upper/Lower case liek Chinese.
                // Constants must always start with an upper-case letter.
                if (field.Const)
                {
                    return;
                }

                // Readonly non-private fields must start with an upper-case letter.
                if (field.Readonly && field.AccessModifier != AccessModifierType.Private)
                {
                    return;
                }

                // Readonly static fields must start with an upper-case letter.
                if (field.Readonly && field.Static)
                {
                    return;
                }

                // Public, internal or protected-internal fields also must always start with an upper-case letter.
                if (field.AccessModifier == AccessModifierType.Public)
                {
                    return;
                }

                if (field.AccessModifier == AccessModifierType.Internal)
                {
                    return;
                }

                if (field.AccessModifier == AccessModifierType.ProtectedInternal)
                {
                    return;
                }

                this.AddViolation(field, field.LineNumber, Rules.FieldNamesMustBeginWithLowerCaseLetter, field.Declaration.Name);
            }
        }

        /// <summary>
        /// Checks the field name to look for underscores.
        /// </summary>
        /// <param name="field">
        /// The field to check.
        /// </param>
        private void CheckFieldUnderscores(CsElement field)
        {
            Param.AssertNotNull(field, "field");

            if (field.Declaration.Name.StartsWith("s_", StringComparison.Ordinal) || field.Declaration.Name.StartsWith("m_", StringComparison.Ordinal))
            {
                this.AddViolation(field, Rules.VariableNamesMustNotBePrefixed);
            }
            else if (field.Declaration.Name.StartsWith("_", StringComparison.Ordinal))
            {
                this.AddViolation(field, Rules.FieldNamesMustNotBeginWithUnderscore);
            }
            else if (field.Declaration.Name.IndexOf("_", StringComparison.Ordinal) > -1)
            {
                this.AddViolation(field, Rules.FieldNamesMustNotContainUnderscore);
            }
        }

        /// <summary>
        /// Checks a variable for hungarian notation.
        /// </summary>
        /// <param name="name">
        /// The variable name.
        /// </param>
        /// <param name="startIndex">
        /// The index in the name where the actual name begins.
        /// </param>
        /// <param name="line">
        /// The number number that this variable appears on, or if 0, uses the line number
        /// from the element object.
        /// </param>
        /// <param name="element">
        /// The element that the variable appears in.
        /// </param>
        /// <param name="validPrefixes">
        /// A list of valid prefixes that should not be considered hungarian.
        /// </param>
        private void CheckHungarian(string name, int startIndex, int line, CsElement element, Dictionary<string, string> validPrefixes)
        {
            Param.AssertValidString(name, "name");
            Param.AssertGreaterThanOrEqualToZero(startIndex, "startIndex");
            Param.AssertGreaterThanZero(line, "line");
            Param.AssertNotNull(element, "element");
            Param.Ignore(validPrefixes);

            if (name.Length - startIndex > 3)
            {
                string prefix = null;
                for (int i = startIndex + 1; i < 3 + startIndex; ++i)
                {
                    if (char.IsUpper(name, i))
                    {
                        prefix = name.Substring(startIndex, i - startIndex);
                        break;
                    }
                }

                if (prefix != null)
                {
                    bool found = false;
                    if (validPrefixes != null)
                    {
                        if (validPrefixes.ContainsKey(prefix))
                        {
                            found = true;
                        }
                    }

                    if (!found)
                    {
                        this.AddViolation(element, line, Rules.FieldNamesMustNotUseHungarianNotation, name);
                    }
                }
            }
        }

        /// <summary>
        /// Checks the prefix for a variable defined within a method or property.
        /// </summary>
        /// <param name="variable">
        /// The variable to check.
        /// </param>
        /// <param name="element">
        /// The element that contains the variable.
        /// </param>
        /// <param name="validPrefixes">
        /// A list of valid prefixes that should not be considered hungarian.
        /// </param>
        private void CheckMethodVariablePrefix(Variable variable, CsElement element, Dictionary<string, string> validPrefixes)
        {
            Param.AssertNotNull(variable, "variable");
            Param.AssertNotNull(element, "element");
            Param.Ignore(validPrefixes);

            // Skip past any prefixes in the name.
            int index = NamingRules.MovePastPrefix(variable.Name);

            // Check whether the name starts with a lower-case letter.
            if (variable.Name.Length > index && char.IsLower(variable.Name, index))
            {
                // Check for hungarian notation.
                this.CheckHungarian(variable.Name, index, variable.Location.LineNumber, element, validPrefixes);

                // Check casing on the variable.
                if ((variable.Modifiers & VariableModifiers.Const) == VariableModifiers.Const)
                {
                    // Constants must start with an upper-case letter.
                    this.AddViolation(element, variable.Location.LineNumber, Rules.ConstFieldNamesMustBeginWithUpperCaseLetter, variable.Name);
                }
            }
            else if ((variable.Modifiers & VariableModifiers.Const) == 0 && char.IsUpper(variable.Name, index))
            {
                // We check for IsUpper again to support languages that dont have upper or lower case like Chinese.
                // Method variables must start with a lower-case letter.
                this.AddViolation(element, variable.Location.LineNumber, Rules.FieldNamesMustBeginWithLowerCaseLetter, variable.Name);
            }
        }

        /// <summary>
        /// Checks variables to look for underscores.
        /// </summary>
        /// <param name="element">
        /// The parent element.
        /// </param>
        /// <param name="variables">
        /// The variables to check.
        /// </param>
        private void CheckUnderscores(CsElement element, VariableCollection variables)
        {
            Param.AssertNotNull(element, "element");
            Param.AssertNotNull(variables, "variables");

            foreach (Variable variable in variables)
            {
                if (variable.Name.StartsWith("_", StringComparison.Ordinal) && variable.Name != "__arglist" && variable.Name != "_")
                {
                    this.AddViolation(element, variable.Location.LineNumber, Rules.FieldNamesMustNotBeginWithUnderscore);
                }
            }
        }

        /// <summary>
        /// Gets the list of valid prefixes for the given project.
        /// </summary>
        /// <param name="settings">
        /// The settings for the document being parsed.
        /// </param>
        /// <returns>
        /// Returns the list of prefixes.
        /// </returns>
        private Dictionary<string, string> GetPrefixes(Settings settings)
        {
            Param.Ignore(settings);

            Dictionary<string, string> validPrefixes = new Dictionary<string, string>();

            if (settings != null)
            {
                // Get the allowed hungarian prefixes from the local settings file.
                CollectionProperty list = this.GetSetting(settings, NamingRules.AllowedPrefixesProperty) as CollectionProperty;
                if (list != null && list.Count > 0)
                {
                    foreach (string value in list)
                    {
                        if (!string.IsNullOrEmpty(value) && !validPrefixes.ContainsKey(value))
                        {
                            validPrefixes.Add(value, value);
                        }
                    }
                }
            }

            return validPrefixes;
        }

        /// <summary>
        /// Processes one element and its children.
        /// </summary>
        /// <param name="element">
        /// The element to process.
        /// </param>
        /// <param name="validPrefixes">
        /// The list of valid prefixes for this element.
        /// </param>
        /// <param name="nativeMethods">
        /// Indicates whether the element is within a NativeMethods class.
        /// </param>
        /// <returns>
        /// Returns false if the analyzer should quit.
        /// </returns>
        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Minimizing refactoring before release.")]
        private bool ProcessElement(CsElement element, Dictionary<string, string> validPrefixes, bool nativeMethods)
        {
            Param.AssertNotNull(element, "element");
            Param.AssertNotNull(validPrefixes, "validPrefixes");
            Param.Ignore(nativeMethods);

            if (this.Cancel)
            {
                return false;
            }

            if (!element.Generated && element.Declaration != null && element.Declaration.Name != null)
            {
                switch (element.ElementType)
                {
                    case ElementType.Namespace:
                        if (!nativeMethods)
                        {
                            string[] namespaceParts = element.Declaration.Name.Split('.');
                            foreach (string namespacePart in namespaceParts)
                            {
                                this.CheckCase(element, namespacePart, element.LineNumber, true);
                            }
                        }

                        break;

                    case ElementType.Class:
                    case ElementType.Enum:
                    case ElementType.Struct:
                    case ElementType.Delegate:
                    case ElementType.Property:
                        if (!nativeMethods)
                        {
                            this.CheckCase(element, element.Declaration.Name, element.LineNumber, true);
                        }

                        break;

                    case ElementType.Event:
                        if (!nativeMethods)
                        {
                            foreach (EventDeclaratorExpression declarator in ((Event)element).Declarators)
                            {
                                this.CheckCase(element, declarator.Identifier.Text, declarator.LineNumber, true);
                            }
                        }

                        break;

                    case ElementType.Method:
                        if (!nativeMethods && !element.Declaration.Name.StartsWith("operator", StringComparison.Ordinal) && element.Declaration.Name != "foreach")
                        {
                            this.CheckCase(element, element.Declaration.Name, element.LineNumber, true);
                        }

                        break;

                    case ElementType.Interface:
                        if (element.Declaration.Name.Length < 1 || element.Declaration.Name[0] != 'I')
                        {
                            this.AddViolation(element, Rules.InterfaceNamesMustBeginWithI, element.Declaration.Name);
                        }

                        break;

                    case ElementType.Field:
                        if (!nativeMethods)
                        {
                            this.CheckFieldUnderscores(element);
                            this.CheckFieldPrefix(element as Field, validPrefixes);
                        }

                        break;

                    default:
                        break;
                }
            }

            if (!nativeMethods && (element.ElementType == ElementType.Class || element.ElementType == ElementType.Struct)
                && element.Declaration.Name.EndsWith("NativeMethods", StringComparison.Ordinal))
            {
                nativeMethods = true;
            }

            bool doneAccessor = false;
            foreach (CsElement child in element.ChildElements)
            {
                if ((element.ElementType == ElementType.Indexer && !doneAccessor) || element.ElementType != ElementType.Indexer)
                {
                    if (child.ElementType == ElementType.Accessor)
                    {
                        doneAccessor = true;
                    }

                    if (!this.ProcessElement(child, validPrefixes, nativeMethods))
                    {
                        return false;
                    }
                }
            }

            if (!nativeMethods)
            {
                this.ProcessStatementContainer(element, validPrefixes);
            }

            return true;
        }

        /// <summary>
        /// Processes the given expression.
        /// </summary>
        /// <param name="expression">
        /// The expression to process.
        /// </param>
        /// <param name="element">
        /// The parent element.
        /// </param>
        /// <param name="validPrefixes">
        /// The list of acceptable Hungarian-type prefixes.
        /// </param>
        private void ProcessExpression(Expression expression, CsElement element, Dictionary<string, string> validPrefixes)
        {
            Param.AssertNotNull(expression, "expression");
            Param.AssertNotNull(element, "element");
            Param.AssertNotNull(validPrefixes, "validPrefixes");

            // Check the type of the expression.
            if (expression.ExpressionType == ExpressionType.AnonymousMethod)
            {
                AnonymousMethodExpression anonymousMethod = (AnonymousMethodExpression)expression;

                // Check the anonymous method's variables.
                if (anonymousMethod.Variables != null)
                {
                    foreach (Variable variable in anonymousMethod.Variables)
                    {
                        this.CheckMethodVariablePrefix(variable, element, validPrefixes);
                    }

                    // Check the statements under the anonymous method.
                    foreach (Statement statement in anonymousMethod.ChildStatements)
                    {
                        this.ProcessStatement(statement, element, validPrefixes);
                    }
                }
            }

            // Check the child expressions under this expression.
            foreach (Expression childExpression in expression.ChildExpressions)
            {
                this.ProcessExpression(childExpression, element, validPrefixes);
            }
        }

        /// <summary>
        /// Processes the given statement.
        /// </summary>
        /// <param name="statement">
        /// The statement to process.
        /// </param>
        /// <param name="element">
        /// The parent element.
        /// </param>
        /// <param name="validPrefixes">
        /// The list of acceptable Hungarian-type prefixes.
        /// </param>
        private void ProcessStatement(Statement statement, CsElement element, Dictionary<string, string> validPrefixes)
        {
            Param.AssertNotNull(statement, "statement");
            Param.AssertNotNull(element, "element");
            Param.AssertNotNull(validPrefixes, "validPrefixes");

            // Check the statement's variables.
            if (statement.Variables != null)
            {
                foreach (Variable variable in statement.Variables)
                {
                    this.CheckMethodVariablePrefix(variable, element, validPrefixes);
                    this.CheckUnderscores(element, statement.Variables);
                }
            }

            // Check the expressions under this statement.
            foreach (Expression expression in statement.ChildExpressions)
            {
                this.ProcessExpression(expression, element, validPrefixes);
            }

            // Check each of the statements under this statement.
            foreach (Statement childStatement in statement.ChildStatements)
            {
                this.ProcessStatement(childStatement, element, validPrefixes);
            }
        }

        /// <summary>
        /// Processes the given statement container.
        /// </summary>
        /// <param name="element">
        /// The statement container element to process.
        /// </param>
        /// <param name="validPrefixes">
        /// The list of acceptable Hungarian-type prefixes.
        /// </param>
        private void ProcessStatementContainer(CsElement element, Dictionary<string, string> validPrefixes)
        {
            Param.AssertNotNull(element, "element");
            Param.AssertNotNull(validPrefixes, "validPrefixes");

            // Check the statement container's variables.
            if (element.Variables != null)
            {
                foreach (Variable variable in element.Variables)
                {
                    if (!variable.Generated)
                    {
                        this.CheckMethodVariablePrefix(variable, element, validPrefixes);
                        this.CheckUnderscores(element, element.Variables);
                    }
                }
            }

            // Check each of the statements under this container.
            foreach (Statement statement in element.ChildStatements)
            {
                this.ProcessStatement(statement, element, validPrefixes);
            }
        }

        #endregion
    }
}