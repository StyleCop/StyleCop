//-----------------------------------------------------------------------
// <copyright file="NamingRules.cs">
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
namespace StyleCop.CSharp.Rules
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using StyleCop;
    using StyleCop.CSharp;
    using StyleCop.CSharp.CodeModel;

    /// <summary>
    /// Checks the names of code elements.
    /// </summary>
    [SourceAnalyzer(typeof(CsParser))]
    public class NamingRules : SourceAnalyzer
    {
        #region Internal Constants

        /// <summary>
        /// The name of the property containing the list of allowable prefixes.
        /// </summary>
        internal const string AllowedPrefixesProperty = "Hungarian";

        #endregion Internal Constants

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the NamingRules class.
        /// </summary>
        public NamingRules()
        {
        }

        #endregion Public Constructors

        #region Public Override Properties

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

        #endregion Public Override Properties

        #region Public Override Methods

        /// <summary>
        /// Checks the case of element names within the given document.
        /// </summary>
        /// <param name="document">The document to check.</param>
        public override void AnalyzeDocument(ICodeDocument document)
        {
            Param.RequireNotNull(document, "document");

            CsDocument csdocument = document.AsCsDocument();

            if (!csdocument.Generated)
            {
                Dictionary<string, string> validPrefixes = this.GetPrefixes(document.Settings);
                this.ProcessElement(csdocument, validPrefixes, false);
            }
        }

        #endregion Public Override Methods

        #region Private Static Methods

        /// <summary>
        /// Determines whether the given variable name begins with a standard prefix notation.
        /// </summary>
        /// <param name="name">The variable name.</param>
        /// <returns>Returns the first index in the name string that lies just past the prefix,
        /// or zero if there is no prefix.</returns>
        private static int MovePastPrefix(string name)
        {
            Param.AssertValidString(name, "name");

            // If the variable name contains a prefix, skip past it.
            if (name.StartsWith("s_", StringComparison.Ordinal) ||
                name.StartsWith("m_", StringComparison.Ordinal) ||
                name.StartsWith("__", StringComparison.Ordinal))
            {
                return 2;
            }
            else if (name.StartsWith("_", StringComparison.Ordinal) ||
                name.StartsWith("@", StringComparison.Ordinal))
            {
                return 1;
            }

            return 0;
        }

        #endregion Private Static Methods

        #region Private Methods

        /// <summary>
        /// Gets the list of valid prefixes for the given project.
        /// </summary>
        /// <param name="settings">The settings for the document being parsed.</param>
        /// <returns>Returns the list of prefixes.</returns>
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
        /// Checks a variable for hungarian notation.
        /// </summary>
        /// <param name="name">The variable name.</param>
        /// <param name="startIndex">The index in the name where the actual name begins.</param>
        /// <param name="line">The number number that this variable appears on, or if 0, uses the line number
        /// from the element object.</param>
        /// <param name="element">The element that the variable appears in.</param>
        /// <param name="validPrefixes">A list of valid prefixes that should not be considered hungarian.</param>
        private void CheckHungarian(
            string name, int startIndex, int line, Element element, Dictionary<string, string> validPrefixes)
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
                    string character = name.Substring(i, 1);
                    if (character == character.ToUpper(CultureInfo.InvariantCulture))
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
        /// Checks variables to look for underscores.
        /// </summary>
        /// <param name="element">The parent element.</param>
        /// <param name="variables">The variables to check.</param>
        private void CheckUnderscores(Element element, VariableCollection variables)
        {
            Param.AssertNotNull(element, "element");
            Param.AssertNotNull(variables, "variables");

            foreach (IVariable variable in variables)
            {
                if (variable.VariableName.StartsWith("_", StringComparison.Ordinal) && variable.VariableName != "__arglist")
                {
                    this.AddViolation(element, variable.Location.LineNumber, Rules.FieldNamesMustNotBeginWithUnderscore);
                }
            }
        }

        /// <summary>
        /// Checks the field name to look for underscores.
        /// </summary>
        /// <param name="field">The field ot check.</param>
        private void CheckFieldUnderscores(Element field)
        {
            Param.AssertNotNull(field, "field");

            if (field.Name.StartsWith("s_", StringComparison.Ordinal) ||
                field.Name.StartsWith("m_", StringComparison.Ordinal))
            {
                this.AddViolation(field, Rules.VariableNamesMustNotBePrefixed);
            }
            else if (field.Name.StartsWith("_", StringComparison.Ordinal))
            {
                this.AddViolation(field, Rules.FieldNamesMustNotBeginWithUnderscore);
            }
            else if (field.Name.IndexOf("_", StringComparison.Ordinal) > -1)
            {
                this.AddViolation(field, Rules.FieldNamesMustNotContainUnderscore);
            }
        }

        /// <summary>
        /// Checks a field for compliance with naming prefix rules.
        /// </summary>
        /// <param name="field">The field element.</param>
        /// <param name="validPrefixes">A list of valid prefixes that should not be considered hungarian.</param>
        private void CheckFieldPrefix(Field field, Dictionary<string, string> validPrefixes)
        {
            Param.AssertNotNull(field, "field");
            Param.Ignore(validPrefixes);

            // Skip past any prefixes in the name.
            int index = NamingRules.MovePastPrefix(field.Name);

            // Check whether the name starts with a lower-case letter.
            if (char.IsLower(field.Name, index))
            {
                // Check for hungarian notation.
                this.CheckHungarian(field.Name, index, field.LineNumber, field, validPrefixes);

                // Check casing on the field.
                if (field.Const)
                {
                    // Const fields must start with an upper-case letter.
                    this.AddViolation(
                        field,
                        field.LineNumber,
                        Rules.ConstFieldNamesMustBeginWithUpperCaseLetter,
                        field.Name);
                }
                else if (field.AccessModifierType == AccessModifierType.Public ||
                    field.AccessModifierType == AccessModifierType.Internal ||
                    field.AccessModifierType == AccessModifierType.ProtectedInternal)
                {
                    // Public or internal fields must start with an upper-case letter.
                    this.AddViolation(
                        field,
                        field.LineNumber,
                        Rules.AccessibleFieldsMustBeginWithUpperCaseLetter,
                        field.Name);
                }

                // Readonly fields which are not declared private must start with an upper-case letter.
                if (field.Readonly && field.AccessModifierType != AccessModifierType.Private)
                {
                    this.AddViolation(
                        field,
                        field.LineNumber,
                        Rules.NonPrivateReadonlyFieldsMustBeginWithUpperCaseLetter,
                        field.Name);
                }
            }
            else
            {
                // Constants must always start with an upper-case letter,
                // while readonly fields may start with either an upper-case or
                // a lower-case letter. Public or internal fields 
                // also must always start with an upper-case letter.
                if (!field.Const &&
                    !field.Readonly &&
                    field.AccessModifierType != AccessModifierType.Public &&
                    field.AccessModifierType != AccessModifierType.Internal &&
                    field.AccessModifierType != AccessModifierType.ProtectedInternal)
                {
                    this.AddViolation(
                        field,
                        field.LineNumber,
                        Rules.FieldNamesMustBeginWithLowerCaseLetter,
                        field.Name);
                }
            }
        }

        /// <summary>
        /// Checks the prefix for a variable defined within a method or property.
        /// </summary>
        /// <param name="variable">The variable to check.</param>
        /// <param name="element">The element that contains the variable.</param>
        /// <param name="validPrefixes">A list of valid prefixes that should not be considered hungarian.</param>
        private void CheckMethodVariablePrefix(
            IVariable variable, Element element, Dictionary<string, string> validPrefixes)
        {
            Param.AssertNotNull(variable, "variable");
            Param.AssertNotNull(element, "element");
            Param.Ignore(validPrefixes);

            // Skip past any prefixes in the name.
            int index = NamingRules.MovePastPrefix(variable.VariableName);

            // Do not check for name casing on fields and events. These are checked elsewhere since they are elements, not simple variables,
            // and therefor fall under different rules.
            bool checkCasing = element.ElementType != ElementType.Field && element.ElementType != ElementType.Event;

            // Check whether the name starts with a lower-case letter.
            if (variable.VariableName.Length > index && char.IsLower(variable.VariableName, index))
            {
                // Check for hungarian notation.
                this.CheckHungarian(variable.VariableName, index, variable.Location.LineNumber, element, validPrefixes);

                // Check casing on the variable.
                if (checkCasing && (variable.VariableModifiers & VariableModifiers.Const) == VariableModifiers.Const)
                {
                    // Constants must start with an upper-case letter.
                    this.AddViolation(element, variable.Location.LineNumber, Rules.ConstFieldNamesMustBeginWithUpperCaseLetter, variable.VariableName);
                }
            }
            else if (checkCasing && (variable.VariableModifiers & VariableModifiers.Const) == 0)
            {
                // Non-constant method variables must start with a lower-case letter.
                this.AddViolation(element, variable.Location.LineNumber, Rules.FieldNamesMustBeginWithLowerCaseLetter, variable.VariableName);
            }
        }

        /// <summary>
        /// Processes one element and its children.
        /// </summary>
        /// <param name="element">The element to process.</param>
        /// <param name="validPrefixes">The list of valid prefixes for this element.</param>
        /// <param name="nativeMethods">Indicates whether the element is within a NativeMethods class.</param>
        /// <returns>Returns false if the analyzer should quit.</returns>
        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Minimizing refactoring before release.")]
        private bool ProcessElement(Element element, Dictionary<string, string> validPrefixes, bool nativeMethods)
        {
            Param.AssertNotNull(element, "element");
            Param.AssertNotNull(validPrefixes, "validPrefixes");
            Param.Ignore(nativeMethods);

            if (this.Cancel)
            {
                return false;
            }

            if (!element.Generated && element.Name != null)
            {
                switch (element.ElementType)
                {
                    case ElementType.Namespace:
                    case ElementType.Class:
                    case ElementType.Enum:
                    case ElementType.Struct:
                    case ElementType.Delegate:
                    case ElementType.Property:
                        if (!nativeMethods)
                        {
                            this.CheckCase(element, element.Name, element.LineNumber, true);
                        }

                        break;

                    case ElementType.Event:
                        if (!nativeMethods)
                        { 
                            for (EventDeclaratorExpression declarator = element.FindFirstChild<EventDeclaratorExpression>(); declarator != null; declarator = declarator.FindNextSibling<EventDeclaratorExpression>())
                            {
                                this.CheckCase(element, declarator.Identifier.Text, declarator.LineNumber, true);
                            }
                        }

                        break;

                    case ElementType.Method:
                        if (!nativeMethods &&
                            !element.Name.StartsWith("operator", StringComparison.Ordinal) &&
                            element.Name != "foreach")
                        {
                            this.CheckCase(element, element.Name, element.LineNumber, true);
                        }

                        break;

                    case ElementType.Interface:
                        if (element.Name.Length < 1 || element.Name[0] != 'I')
                        {
                            this.AddViolation(element, Rules.InterfaceNamesMustBeginWithI, element.Name);
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

            if (!nativeMethods &&
                (element.ElementType == ElementType.Class || element.ElementType == ElementType.Struct) &&
                element.Name.EndsWith("NativeMethods", StringComparison.Ordinal))
            {
                nativeMethods = true;
            }

            if (element.Children.ElementCount > 0)
            {
                for (Element child = element.FindFirstChildElement(); child != null; child = child.FindNextSiblingElement())
                {
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
        /// Processes the given statement container.
        /// </summary>
        /// <param name="element">The statement container element to process.</param>
        /// <param name="validPrefixes">The list of acceptable Hungarian-type prefixes.</param>
        private void ProcessStatementContainer(Element element, Dictionary<string, string> validPrefixes)
        {
            Param.AssertNotNull(element, "element");
            Param.AssertNotNull(validPrefixes, "validPrefixes");

            // Check the statement container's variables.
            VariableCollection variables = element.Variables;

            if (variables != null)
            {
                foreach (IVariable variable in variables)
                {
                    if (!variable.Generated)
                    {
                        this.CheckMethodVariablePrefix(variable, element, validPrefixes);
                        this.CheckUnderscores(element, variables);
                    }
                }
            }

            // Check each of the statements under this container.
            if (element.Children.StatementCount > 0)
            {
                for (Statement statement = element.FindFirstChildStatement(); statement != null; statement = statement.FindNextSiblingStatement())
                {
                    this.ProcessStatement(statement, element, validPrefixes);
                }
            }
        }

        /// <summary>
        /// Processes the given statement.
        /// </summary>
        /// <param name="statement">The statement to process.</param>
        /// <param name="element">The parent element.</param>
        /// <param name="validPrefixes">The list of acceptable Hungarian-type prefixes.</param>
        private void ProcessStatement(Statement statement, Element element, Dictionary<string, string> validPrefixes)
        {
            Param.AssertNotNull(statement, "statement");
            Param.AssertNotNull(element, "element");
            Param.AssertNotNull(validPrefixes, "validPrefixes");

            // Check the statement's variables.
            VariableCollection variables = statement.Variables;

            if (variables != null)
            {
                foreach (IVariable variable in variables)
                {
                    this.CheckMethodVariablePrefix(variable, element, validPrefixes);
                    this.CheckUnderscores(element, variables);
                }
            }

            // Check the expressions under this statement.
            if (statement.Children.ExpressionCount > 0)
            {
                for (Expression expression = statement.FindFirstChildExpression(); expression != null; expression = expression.FindNextSiblingExpression())
                {
                    this.ProcessExpression(expression, element, validPrefixes);
                }
            }

            // Check each of the statements under this statement.
            if (statement.Children.StatementCount > 0)
            {
                for (Statement childStatement = statement.FindFirstChildStatement(); childStatement != null; childStatement = childStatement.FindNextSiblingStatement())
                {
                    this.ProcessStatement(childStatement, element, validPrefixes);
                }
            }
        }

        /// <summary>
        /// Processes the given expression.
        /// </summary>
        /// <param name="expression">The expression to process.</param>
        /// <param name="element">The parent element.</param>
        /// <param name="validPrefixes">The list of acceptable Hungarian-type prefixes.</param>
        private void ProcessExpression(Expression expression, Element element, Dictionary<string, string> validPrefixes)
        {
            Param.AssertNotNull(expression, "expression");
            Param.AssertNotNull(element, "element");
            Param.AssertNotNull(validPrefixes, "validPrefixes");

            // Check the type of the expression.
            if (expression.ExpressionType == ExpressionType.AnonymousMethod)
            {
                AnonymousMethodExpression anonymousMethod = (AnonymousMethodExpression)expression;

                // Check the anonymous method's variables.
                VariableCollection variables = anonymousMethod.Variables;
                if (variables != null)
                {
                    foreach (IVariable variable in variables)
                    {
                        this.CheckMethodVariablePrefix(variable, element, validPrefixes);
                    }

                    // Check the statements under the anonymous method.
                    if (anonymousMethod.Children.StatementCount > 0)
                    {
                        for (Statement statement = anonymousMethod.FindFirstChildStatement(); statement != null; statement = statement.FindNextSiblingStatement())
                        {
                            this.ProcessStatement(statement, element, validPrefixes);
                        }
                    }
                }
            }

            // Check the child expressions under this expression.
            if (expression.Children.StatementCount > 0)
            {
                for (Expression childExpression = expression.FindFirstChildExpression(); childExpression != null; childExpression = childExpression.FindNextSiblingExpression())
                {
                    this.ProcessExpression(childExpression, element, validPrefixes);
                }
            }
        }

        /// <summary>
        /// Checks the case of the first character in the given word.
        /// </summary>
        /// <param name="element">The element that the word appears in.</param>
        /// <param name="name">The word to check.</param>
        /// <param name="line">The line that the word appears on.</param>
        /// <param name="upper">True if the character should be upper, false if it should be lower.</param>
        private void CheckCase(Element element, string name, int line, bool upper)
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
                        if (!char.IsUpper(firstLetter))
                        {
                            this.AddViolation(element, line, Rules.ElementMustBeginWithUpperCaseLetter, element.FriendlyTypeText, name);
                        }
                    }
                    else
                    {
                        if (!char.IsLower(firstLetter))
                        {
                            this.AddViolation(element, line, Rules.ElementMustBeginWithLowerCaseLetter, element.FriendlyTypeText, name);
                        }
                    }
                }
            }
        }

        #endregion Private Methods
    }
}
