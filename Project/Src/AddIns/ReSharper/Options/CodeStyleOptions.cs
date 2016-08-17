// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CodeStyleOptions.cs" company="http://stylecop.codeplex.com">
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
//   Verify and reset the options.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace StyleCop.ReSharper.Options
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Reflection;

    using JetBrains.Application.Settings;
    using JetBrains.ReSharper.Daemon.CSharp.CodeCleanup;
    using JetBrains.ReSharper.Feature.Services.CodeCleanup;
    using JetBrains.ReSharper.Psi.CodeStyle;
    using JetBrains.ReSharper.Psi.CSharp.CodeStyle;
    using JetBrains.ReSharper.Psi.CSharp.CodeStyle.FormatSettings;
    using JetBrains.ReSharper.Psi.CSharp.CodeStyle.Settings;
    using JetBrains.ReSharper.Psi.CSharp.Naming2;
    using JetBrains.ReSharper.Psi.Naming.Settings;
    using JetBrains.ReSharper.Resources.Shell;

    using StyleCop.ReSharper.CodeCleanup;

    /// <summary>
    /// Options for code style
    /// </summary>
    public static class CodeStyleOptions
    {
        /// <summary>
        /// The order of modifiers for StyleCop.
        /// </summary>
        private const string ModifiersOrder = "public protected internal private static new abstract virtual override sealed readonly extern unsafe volatile async";

        /// <summary>
        /// Resets the CodeStyleOptions to be StyleCop compatible.
        /// </summary>
        /// <param name="settingsStore">
        /// The settings store to use. 
        /// </param>
        public static void CodeStyleOptionsReset(IContextBoundSettingsStore settingsStore)
        {
            settingsStore.SetValue((CSharpCodeStyleSettingsKey key) => key.MODIFIERS_ORDER, ModifiersOrder);
            settingsStore.SetValue((CSharpCodeStyleSettingsKey key) => key.DEFAULT_INTERNAL_MODIFIER, DefaultModifierDefinition.Explicit);
            settingsStore.SetValue((CSharpCodeStyleSettingsKey key) => key.DEFAULT_PRIVATE_MODIFIER, DefaultModifierDefinition.Explicit);
            settingsStore.SetValue((CSharpCodeStyleSettingsKey key) => key.FORCE_ATTRIBUTE_STYLE, AttributeStyle.Separate);

            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.ALIGN_FIRST_ARG_BY_PAREN, false);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.ALIGN_LINQ_QUERY, true);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.ALIGN_MULTILINE_ARGUMENT, false);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.ALIGN_MULTILINE_ARRAY_AND_OBJECT_INITIALIZER, true);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.ALIGN_MULTILINE_EXPRESSION, true);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.ALIGN_MULTILINE_EXTENDS_LIST, true);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.ALIGN_MULTILINE_FOR_STMT, true);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.ALIGN_MULTILINE_PARAMETER, true);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.ALIGN_MULTIPLE_DECLARATION, true);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.ALIGN_MULTLINE_TYPE_PARAMETER_CONSTRAINS, true);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.ALIGN_MULTLINE_TYPE_PARAMETER_LIST, true);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.ALLOW_COMMENT_AFTER_LBRACE, false);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.ANONYMOUS_METHOD_DECLARATION_BRACES, BraceFormatStyle.NEXT_LINE_SHIFTED_2);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.BLANK_LINES_AFTER_START_COMMENT, 1);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.BLANK_LINES_AFTER_USING_LIST, 1);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.BLANK_LINES_AROUND_FIELD, 1);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.BLANK_LINES_AROUND_INVOCABLE, 1);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.BLANK_LINES_AROUND_NAMESPACE, 1);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.BLANK_LINES_AROUND_REGION, 1);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.BLANK_LINES_AROUND_SINGLE_LINE_FIELD, 1);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.BLANK_LINES_AROUND_SINGLE_LINE_INVOCABLE, 1);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.BLANK_LINES_AROUND_TYPE, 1);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.BLANK_LINES_BETWEEN_USING_GROUPS, 1);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.BLANK_LINES_INSIDE_REGION, 1);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.CASE_BLOCK_BRACES, BraceFormatStyle.NEXT_LINE_SHIFTED_2);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.CONTINUOUS_INDENT_MULTIPLIER, 1);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.EMPTY_BLOCK_STYLE, EmptyBlockStyle.MULTILINE);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.FORCE_CHOP_COMPOUND_DO_EXPRESSION, false);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.FORCE_CHOP_COMPOUND_IF_EXPRESSION, false);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.FORCE_CHOP_COMPOUND_WHILE_EXPRESSION, false);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.FORCE_FIXED_BRACES_STYLE, ForceBraceStyle.ALWAYS_ADD);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.FORCE_FOR_BRACES_STYLE, ForceBraceStyle.ALWAYS_ADD);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.FORCE_FOREACH_BRACES_STYLE, ForceBraceStyle.ALWAYS_ADD);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.FORCE_IFELSE_BRACES_STYLE, ForceBraceStyle.ALWAYS_ADD);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.FORCE_USING_BRACES_STYLE, ForceBraceStyle.DO_NOT_CHANGE);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.FORCE_WHILE_BRACES_STYLE, ForceBraceStyle.ALWAYS_ADD);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.INDENT_ANONYMOUS_METHOD_BLOCK, false);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.INDENT_CASE_FROM_SWITCH, true);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.INDENT_NESTED_FIXED_STMT, false);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.INDENT_NESTED_USINGS_STMT, false);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.INITIALIZER_BRACES, BraceFormatStyle.NEXT_LINE_SHIFTED_2);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.INVOCABLE_DECLARATION_BRACES, BraceFormatStyle.NEXT_LINE);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.KEEP_BLANK_LINES_IN_CODE, 1);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.KEEP_BLANK_LINES_IN_DECLARATIONS, 1);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.KEEP_USER_LINEBREAKS, false);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.LINE_FEED_AT_FILE_END, false);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.OTHER_BRACES, BraceFormatStyle.NEXT_LINE);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.PLACE_ABSTRACT_ACCESSORHOLDER_ON_SINGLE_LINE, true);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.PLACE_ACCESSORHOLDER_ATTRIBUTE_ON_SAME_LINE, false);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.PLACE_CATCH_ON_NEW_LINE, true);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.PLACE_CONSTRUCTOR_INITIALIZER_ON_SAME_LINE, false);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.PLACE_ELSE_ON_NEW_LINE, true);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.PLACE_FIELD_ATTRIBUTE_ON_SAME_LINE, false);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.PLACE_FINALLY_ON_NEW_LINE, true);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.PLACE_METHOD_ATTRIBUTE_ON_SAME_LINE, false);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.PLACE_SIMPLE_ACCESSOR_ON_SINGLE_LINE, false);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.PLACE_SIMPLE_ACCESSORHOLDER_ON_SINGLE_LINE, false);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.PLACE_SIMPLE_ANONYMOUSMETHOD_ON_SINGLE_LINE, true);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.PLACE_SIMPLE_INITIALIZER_ON_SINGLE_LINE, true);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.PLACE_SIMPLE_LINQ_ON_SINGLE_LINE, true);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.PLACE_SIMPLE_METHOD_ON_SINGLE_LINE, false);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.PLACE_TYPE_ATTRIBUTE_ON_SAME_LINE, false);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.PLACE_TYPE_CONSTRAINTS_ON_SAME_LINE, false);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.PLACE_WHILE_ON_NEW_LINE, true);

            // TODO: Set the appropriate Code Style setting
            // settingsStore.SetValue((CSharpFormatSettingsKey key) => key.REDUNDANT_THIS_QUALIFIER_STYLE, ThisQualifierStyle.This);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.SIMPLE_EMBEDDED_STATEMENT_STYLE, SimpleEmbeddedStatementStyle.ON_SINGLE_LINE);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.SPACE_AFTER_AMPERSAND_OP, false);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.SPACE_AFTER_ASTERIK_OP, false);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.SPACE_AFTER_ATTRIBUTE_COLON, true);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.SPACE_AFTER_COMMA, true);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.SPACE_AFTER_EXTENDS_COLON, true);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.SPACE_AFTER_FOR_SEMICOLON, true);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.SPACE_AFTER_TERNARY_COLON, true);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.SPACE_AFTER_TERNARY_QUEST, true);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.SPACE_AFTER_TYPE_PARAMETER_CONSTRAINT_COLON, true);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.SPACE_AFTER_TYPECAST_PARENTHESES, false);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.SPACE_AROUND_ADDITIVE_OP, true);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.SPACE_AROUND_ALIAS_EQ, true);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.SPACE_AROUND_ARROW_OP, false);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.SPACE_AROUND_ASSIGNMENT_OP, true);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.SPACE_AROUND_BITWISE_OP, true);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.SPACE_AROUND_DOT, false);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.SPACE_AROUND_EQUALITY_OP, true);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.SPACE_AROUND_LAMBDA_ARROW, true);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.SPACE_AROUND_LOGICAL_OP, true);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.SPACE_AROUND_MULTIPLICATIVE_OP, true);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.SPACE_AROUND_NULLCOALESCING_OP, true);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.SPACE_AROUND_RELATIONAL_OP, true);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.SPACE_AROUND_SHIFT_OP, true);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.SPACE_BEFORE_ARRAY_ACCESS_BRACKETS, false);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.SPACE_BEFORE_ARRAY_RANK_BRACKETS, false);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.SPACE_BEFORE_ATTRIBUTE_COLON, false);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.SPACE_BEFORE_CATCH_PARENTHESES, true);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.SPACE_BEFORE_COLON_IN_CASE, false);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.SPACE_BEFORE_COMMA, false);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.SPACE_BEFORE_EMPTY_METHOD_CALL_PARENTHESES, false);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.SPACE_BEFORE_EMPTY_METHOD_PARENTHESES, false);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.SPACE_BEFORE_EXTENDS_COLON, true);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.SPACE_BEFORE_FIXED_PARENTHESES, true);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.SPACE_BEFORE_FOR_PARENTHESES, true);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.SPACE_BEFORE_FOR_SEMICOLON, false);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.SPACE_BEFORE_FOREACH_PARENTHESES, true);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.SPACE_BEFORE_IF_PARENTHESES, true);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.SPACE_BEFORE_LOCK_PARENTHESES, true);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.SPACE_BEFORE_METHOD_CALL_PARENTHESES, false);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.SPACE_BEFORE_METHOD_PARENTHESES, false);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.SPACE_BEFORE_NULLABLE_MARK, false);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.SPACE_BEFORE_POINTER_ASTERIK_DECLARATION, false);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.SPACE_BEFORE_SEMICOLON, false);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.SPACE_BEFORE_SINGLELINE_ACCESSORHOLDER, true);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.SPACE_BEFORE_SIZEOF_PARENTHESES, false);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.SPACE_BEFORE_SWITCH_PARENTHESES, true);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.SPACE_BEFORE_TERNARY_COLON, true);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.SPACE_BEFORE_TERNARY_QUEST, true);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.SPACE_BEFORE_TRAILING_COMMENT, true);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.SPACE_BEFORE_TYPE_ARGUMENT_ANGLE, false);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.SPACE_BEFORE_TYPE_PARAMETER_ANGLE, false);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.SPACE_BEFORE_TYPE_PARAMETER_CONSTRAINT_COLON, true);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.SPACE_BEFORE_TYPEOF_PARENTHESES, false);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.SPACE_BEFORE_USING_PARENTHESES, true);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.SPACE_BEFORE_WHILE_PARENTHESES, true);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.SPACE_BETWEEN_ACCESSORS_IN_SINGLELINE_PROPERTY, true);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.SPACE_IN_SINGLELINE_ACCESSORHOLDER, true);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.SPACE_IN_SINGLELINE_ANONYMOUS_METHOD, true);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.SPACE_IN_SINGLELINE_METHOD, true);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.SPACE_WITHIN_ARRAY_ACCESS_BRACKETS, false);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.SPACE_WITHIN_ARRAY_RANK_BRACKETS, false);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.SPACE_WITHIN_ARRAY_RANK_EMPTY_BRACKETS, false);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.SPACE_WITHIN_ATTRIBUTE_BRACKETS, false);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.SPACE_WITHIN_CATCH_PARENTHESES, false);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.SPACE_WITHIN_EMPTY_METHOD_CALL_PARENTHESES, false);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.SPACE_WITHIN_EMPTY_METHOD_PARENTHESES, false);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.SPACE_WITHIN_FIXED_PARENTHESES, false);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.SPACE_WITHIN_FOR_PARENTHESES, false);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.SPACE_WITHIN_FOREACH_PARENTHESES, false);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.SPACE_WITHIN_IF_PARENTHESES, false);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.SPACE_WITHIN_LOCK_PARENTHESES, false);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.SPACE_WITHIN_METHOD_CALL_PARENTHESES, false);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.SPACE_WITHIN_METHOD_PARENTHESES, false);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.SPACE_WITHIN_PARENTHESES, false);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.SPACE_WITHIN_SINGLE_LINE_ARRAY_INITIALIZER_BRACES, true);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.SPACE_WITHIN_SIZEOF_PARENTHESES, false);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.SPACE_WITHIN_SWITCH_PARENTHESES, false);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.SPACE_WITHIN_TYPE_ARGUMENT_ANGLES, false);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.SPACE_WITHIN_TYPE_PARAMETER_ANGLES, false);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.SPACE_WITHIN_TYPECAST_PARENTHESES, false);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.SPACE_WITHIN_TYPEOF_PARENTHESES, false);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.SPACE_WITHIN_USING_PARENTHESES, false);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.SPACE_WITHIN_WHILE_PARENTHESES, false);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.SPECIAL_ELSE_IF_TREATMENT, true);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.STICK_COMMENT, false);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.TYPE_DECLARATION_BRACES, BraceFormatStyle.NEXT_LINE);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.WRAP_AFTER_DECLARATION_LPAR, true);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.WRAP_AFTER_INVOCATION_LPAR, true);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.WRAP_ARGUMENTS_STYLE, WrapStyle.CHOP_IF_LONG);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.WRAP_BEFORE_BINARY_OPSIGN, true);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.WRAP_BEFORE_DECLARATION_LPAR, false);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.WRAP_BEFORE_EXTENDS_COLON, false);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.WRAP_BEFORE_FIRST_TYPE_PARAMETER_CONSTRAINT, true);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.WRAP_BEFORE_INVOCATION_LPAR, false);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.WRAP_BEFORE_TYPE_PARAMETER_LANGLE, false);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.WRAP_EXTENDS_LIST_STYLE, WrapStyle.CHOP_IF_LONG);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.WRAP_FOR_STMT_HEADER_STYLE, WrapStyle.CHOP_IF_LONG);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.WRAP_LIMIT, settingsStore.GetValue((CSharpFormatSettingsKey key) => key.WRAP_LIMIT));

            // We don't need to set this. It's here for completeness.
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.WRAP_LINES, true);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.WRAP_MULTIPLE_DECLARATION_STYLE, WrapStyle.CHOP_IF_LONG);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.WRAP_MULTIPLE_TYPE_PARAMEER_CONSTRAINTS_STYLE, WrapStyle.CHOP_IF_LONG);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.WRAP_OBJECT_AND_COLLECTION_INITIALIZER_STYLE, WrapStyle.CHOP_IF_LONG);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.WRAP_PARAMETERS_STYLE, WrapStyle.CHOP_IF_LONG);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.WRAP_TERNARY_EXPR_STYLE, WrapStyle.CHOP_IF_LONG);

            settingsStore.SetValue((CSharpNamingSettings key) => key.EventHandlerPatternLong, "$object$_On$event$");
            settingsStore.SetValue((CSharpNamingSettings key) => key.EventHandlerPatternShort, "$event$Handler");

            foreach (NamedElementKinds kindOfElement in Enum.GetValues(typeof(NamedElementKinds)))
            {
                NamingPolicy policy = settingsStore.GetIndexedValue<CSharpNamingSettings, NamedElementKinds, NamingPolicy>(
                    key => key.PredefinedNamingRules, kindOfElement) ?? ClrPolicyProviderBase.GetDefaultPolicy(kindOfElement);

                NamingRule rule = policy.NamingRule;

                rule.Suffix = string.Empty;

                switch (kindOfElement)
                {
                    case NamedElementKinds.Locals:
                    case NamedElementKinds.Parameters:
                    case NamedElementKinds.PrivateInstanceFields:
                    case NamedElementKinds.PrivateStaticFields:
                        rule.Prefix = string.Empty;
                        rule.NamingStyleKind = NamingStyleKinds.aaBb;
                        break;
                    case NamedElementKinds.Interfaces:
                        rule.Prefix = "I";
                        rule.NamingStyleKind = NamingStyleKinds.AaBb;
                        break;
                    case NamedElementKinds.TypeParameters:
                        rule.Prefix = "T";
                        rule.NamingStyleKind = NamingStyleKinds.AaBb;
                        break;
                    default:
                        rule.Prefix = string.Empty;
                        rule.NamingStyleKind = NamingStyleKinds.AaBb;
                        break;
                }

                settingsStore.SetIndexedValue<CSharpNamingSettings, NamedElementKinds, NamingPolicy>(key => key.PredefinedNamingRules, kindOfElement, policy);
            }

            settingsStore.SetValue(CSharpUsingSettingsAccessor.AddImportsToDeepestScope, true);
            settingsStore.SetValue(CSharpUsingSettingsAccessor.QualifiedUsingAtNestedScope, true);
            settingsStore.SetValue(CSharpUsingSettingsAccessor.AllowAlias, true);
            settingsStore.SetValue(CSharpUsingSettingsAccessor.CanUseGlobalAlias, true);
            settingsStore.SetValue(CSharpUsingSettingsAccessor.KeepNontrivialAlias, true);
            settingsStore.SetValue(CSharpUsingSettingsAccessor.PreferQualifiedReference, false);
            settingsStore.SetValue(CSharpUsingSettingsAccessor.SortUsings, true);

            string reorderingPatterns;
            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("StyleCop.ReSharper.Resources.ReorderingPatterns.xml"))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    reorderingPatterns = reader.ReadToEnd();
                }
            }

            settingsStore.SetValue((CSharpFileLayoutPatternsSettings key) => key.Pattern, reorderingPatterns);

            {
                CodeCleanupProfile styleCopProfile = null;

                List<CodeCleanupProfile> profiles = new List<CodeCleanupProfile>();

                CodeCleanupSettingsComponent codeCleanupSettings = Shell.Instance.GetComponent<CodeCleanupSettingsComponent>();
                ICollection<CodeCleanupProfile> currentProfiles = codeCleanupSettings.GetProfiles(settingsStore);

                // Find the StyleCop profile
                foreach (CodeCleanupProfile profile in currentProfiles)
                {
                    if (!profile.IsDefault)
                    {
                        CodeCleanupProfile clone = profile.Clone();

                        profiles.Add(clone);

                        if (clone.Name == "StyleCop")
                        {
                            styleCopProfile = clone;
                        }
                    }
                }

                if (styleCopProfile == null)
                {
                    styleCopProfile = codeCleanupSettings.CreateEmptyProfile("StyleCop");
                    profiles.Add(styleCopProfile);
                }

                styleCopProfile.SetSetting(CSharpHighlightingCleanupModule.ARRANGE_QUALIFIERS_DESCRIPTOR, true);

                SetCodeCleanupProfileSetting(styleCopProfile, "CSUpdateFileHeader", null, false);

                OptimizeUsings.OptimizeUsingsOptions optimizeUsingsOptions = new OptimizeUsings.OptimizeUsingsOptions
                                                                                 {
                                                                                     OptimizeUsings = true,
                                                                                     EmbraceUsingsInRegion = false,
                                                                                     RegionName = string.Empty
                                                                                 };
                styleCopProfile.SetSetting(OptimizeUsings.OPTIMIZE_USINGS_DESCRIPTOR, optimizeUsingsOptions);

                SetCodeCleanupProfileSetting(styleCopProfile, "CSReformatCode", null, true);

                SetCodeCleanupProfileSetting(styleCopProfile, "CSharpFormatDocComments", null, false);

                SetCodeCleanupProfileSetting(styleCopProfile, "CSReorderTypeMembers", null, true);

                styleCopProfile.SetSetting(StyleCopCodeCleanupModule.Descriptor, new StyleCopCodeCleanupOptions());

                codeCleanupSettings.SetProfiles(profiles, settingsStore);
                codeCleanupSettings.SetSilentCleanupProfileName(settingsStore, styleCopProfile.Name);
            }
        }

        /// <summary>
        /// Confirms that the ReSharper code style options are all valid to ensure no StyleCop issues on cleanup.
        /// </summary>
        /// <param name="settingsStore">
        /// The settings store to use. 
        /// </param>
        /// <returns>
        /// True if options are all valid, otherwise false. 
        /// </returns>
        public static bool CodeStyleOptionsValid(IContextBoundSettingsStore settingsStore)
        {
            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.ALIGN_FIRST_ARG_BY_PAREN))
            {
                return false;
            }

            if (!settingsStore.GetValue((CSharpFormatSettingsKey key) => key.ALIGN_LINQ_QUERY))
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.ALIGN_MULTILINE_ARGUMENT))
            {
                return false;
            }

            if (!settingsStore.GetValue((CSharpFormatSettingsKey key) => key.ALIGN_MULTILINE_ARRAY_AND_OBJECT_INITIALIZER))
            {
                return false;
            }

            if (!settingsStore.GetValue((CSharpFormatSettingsKey key) => key.ALIGN_MULTILINE_EXPRESSION))
            {
                return false;
            }

            if (!settingsStore.GetValue((CSharpFormatSettingsKey key) => key.ALIGN_MULTILINE_EXTENDS_LIST))
            {
                return false;
            }

            if (!settingsStore.GetValue((CSharpFormatSettingsKey key) => key.ALIGN_MULTILINE_FOR_STMT))
            {
                return false;
            }

            if (!settingsStore.GetValue((CSharpFormatSettingsKey key) => key.ALIGN_MULTILINE_PARAMETER))
            {
                return false;
            }

            if (!settingsStore.GetValue((CSharpFormatSettingsKey key) => key.ALIGN_MULTIPLE_DECLARATION))
            {
                return false;
            }

            if (!settingsStore.GetValue((CSharpFormatSettingsKey key) => key.ALIGN_MULTLINE_TYPE_PARAMETER_CONSTRAINS))
            {
                return false;
            }

            if (!settingsStore.GetValue((CSharpFormatSettingsKey key) => key.ALIGN_MULTLINE_TYPE_PARAMETER_LIST))
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.ALLOW_COMMENT_AFTER_LBRACE))
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.ANONYMOUS_METHOD_DECLARATION_BRACES) != BraceFormatStyle.NEXT_LINE_SHIFTED_2)
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.BLANK_LINES_AFTER_START_COMMENT) != 1)
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.BLANK_LINES_AFTER_USING_LIST) != 1)
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.BLANK_LINES_AROUND_FIELD) != 1)
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.BLANK_LINES_AROUND_INVOCABLE) != 1)
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.BLANK_LINES_AROUND_NAMESPACE) != 1)
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.BLANK_LINES_AROUND_REGION) != 1)
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.BLANK_LINES_AROUND_SINGLE_LINE_FIELD) != 1)
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.BLANK_LINES_AROUND_SINGLE_LINE_INVOCABLE) != 1)
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.BLANK_LINES_AROUND_TYPE) != 1)
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.BLANK_LINES_BETWEEN_USING_GROUPS) != 1)
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.BLANK_LINES_INSIDE_REGION) != 1)
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.CASE_BLOCK_BRACES) != BraceFormatStyle.NEXT_LINE_SHIFTED_2)
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.CONTINUOUS_INDENT_MULTIPLIER) != 1)
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.EMPTY_BLOCK_STYLE) != EmptyBlockStyle.MULTILINE)
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpCodeStyleSettingsKey key) => key.DEFAULT_INTERNAL_MODIFIER) != DefaultModifierDefinition.Explicit)
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpCodeStyleSettingsKey key) => key.DEFAULT_PRIVATE_MODIFIER) != DefaultModifierDefinition.Explicit)
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpCodeStyleSettingsKey key) => key.FORCE_ATTRIBUTE_STYLE) != AttributeStyle.Separate)
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.FORCE_CHOP_COMPOUND_DO_EXPRESSION))
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.FORCE_CHOP_COMPOUND_IF_EXPRESSION))
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.FORCE_CHOP_COMPOUND_WHILE_EXPRESSION))
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.FORCE_FIXED_BRACES_STYLE) != ForceBraceStyle.ALWAYS_ADD)
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.FORCE_FOR_BRACES_STYLE) != ForceBraceStyle.ALWAYS_ADD)
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.FORCE_FOREACH_BRACES_STYLE) != ForceBraceStyle.ALWAYS_ADD)
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.FORCE_IFELSE_BRACES_STYLE) != ForceBraceStyle.ALWAYS_ADD)
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.FORCE_USING_BRACES_STYLE) != ForceBraceStyle.DO_NOT_CHANGE)
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.FORCE_WHILE_BRACES_STYLE) != ForceBraceStyle.ALWAYS_ADD)
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.INDENT_ANONYMOUS_METHOD_BLOCK))
            {
                return false;
            }

            if (!settingsStore.GetValue((CSharpFormatSettingsKey key) => key.INDENT_CASE_FROM_SWITCH))
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.INDENT_NESTED_FIXED_STMT))
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.INDENT_NESTED_USINGS_STMT))
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.INITIALIZER_BRACES) != BraceFormatStyle.NEXT_LINE_SHIFTED_2)
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.INVOCABLE_DECLARATION_BRACES) != BraceFormatStyle.NEXT_LINE)
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.KEEP_BLANK_LINES_IN_CODE) != 1)
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.KEEP_BLANK_LINES_IN_DECLARATIONS) != 1)
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.KEEP_USER_LINEBREAKS))
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.LINE_FEED_AT_FILE_END))
            {
                return false;
            }

            if (!settingsStore.GetValue((CSharpCodeStyleSettingsKey key) => key.MODIFIERS_ORDER).SequenceEqual(ModifiersOrder))
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.OTHER_BRACES) != BraceFormatStyle.NEXT_LINE)
            {
                return false;
            }

            if (!settingsStore.GetValue((CSharpFormatSettingsKey key) => key.PLACE_ABSTRACT_ACCESSORHOLDER_ON_SINGLE_LINE))
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.PLACE_ACCESSORHOLDER_ATTRIBUTE_ON_SAME_LINE))
            {
                return false;
            }

            if (!settingsStore.GetValue((CSharpFormatSettingsKey key) => key.PLACE_CATCH_ON_NEW_LINE))
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.PLACE_CONSTRUCTOR_INITIALIZER_ON_SAME_LINE))
            {
                return false;
            }

            if (!settingsStore.GetValue((CSharpFormatSettingsKey key) => key.PLACE_ELSE_ON_NEW_LINE))
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.PLACE_FIELD_ATTRIBUTE_ON_SAME_LINE))
            {
                return false;
            }

            if (!settingsStore.GetValue((CSharpFormatSettingsKey key) => key.PLACE_FINALLY_ON_NEW_LINE))
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.PLACE_METHOD_ATTRIBUTE_ON_SAME_LINE))
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.PLACE_SIMPLE_ACCESSOR_ON_SINGLE_LINE))
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.PLACE_SIMPLE_ACCESSORHOLDER_ON_SINGLE_LINE))
            {
                return false;
            }

            if (!settingsStore.GetValue((CSharpFormatSettingsKey key) => key.PLACE_SIMPLE_ANONYMOUSMETHOD_ON_SINGLE_LINE))
            {
                return false;
            }

            if (!settingsStore.GetValue((CSharpFormatSettingsKey key) => key.PLACE_SIMPLE_INITIALIZER_ON_SINGLE_LINE))
            {
                return false;
            }

            if (!settingsStore.GetValue((CSharpFormatSettingsKey key) => key.PLACE_SIMPLE_LINQ_ON_SINGLE_LINE))
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.PLACE_SIMPLE_METHOD_ON_SINGLE_LINE))
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.PLACE_TYPE_ATTRIBUTE_ON_SAME_LINE))
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.PLACE_TYPE_CONSTRAINTS_ON_SAME_LINE))
            {
                return false;
            }

            if (!settingsStore.GetValue((CSharpFormatSettingsKey key) => key.PLACE_WHILE_ON_NEW_LINE))
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.SIMPLE_EMBEDDED_STATEMENT_STYLE) != SimpleEmbeddedStatementStyle.ON_SINGLE_LINE)
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.SPACE_AFTER_AMPERSAND_OP))
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.SPACE_AFTER_ASTERIK_OP))
            {
                return false;
            }

            if (!settingsStore.GetValue((CSharpFormatSettingsKey key) => key.SPACE_AFTER_ATTRIBUTE_COLON))
            {
                return false;
            }

            if (!settingsStore.GetValue((CSharpFormatSettingsKey key) => key.SPACE_AFTER_COMMA))
            {
                return false;
            }

            if (!settingsStore.GetValue((CSharpFormatSettingsKey key) => key.SPACE_AFTER_EXTENDS_COLON))
            {
                return false;
            }

            if (!settingsStore.GetValue((CSharpFormatSettingsKey key) => key.SPACE_AFTER_FOR_SEMICOLON))
            {
                return false;
            }

            if (!settingsStore.GetValue((CSharpFormatSettingsKey key) => key.SPACE_AFTER_TERNARY_COLON))
            {
                return false;
            }

            if (!settingsStore.GetValue((CSharpFormatSettingsKey key) => key.SPACE_AFTER_TERNARY_QUEST))
            {
                return false;
            }

            if (!settingsStore.GetValue((CSharpFormatSettingsKey key) => key.SPACE_AFTER_TYPE_PARAMETER_CONSTRAINT_COLON))
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.SPACE_AFTER_TYPECAST_PARENTHESES))
            {
                return false;
            }

            if (!settingsStore.GetValue((CSharpFormatSettingsKey key) => key.SPACE_AROUND_ADDITIVE_OP))
            {
                return false;
            }

            if (!settingsStore.GetValue((CSharpFormatSettingsKey key) => key.SPACE_AROUND_ALIAS_EQ))
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.SPACE_AROUND_ARROW_OP))
            {
                return false;
            }

            if (!settingsStore.GetValue((CSharpFormatSettingsKey key) => key.SPACE_AROUND_ASSIGNMENT_OP))
            {
                return false;
            }

            if (!settingsStore.GetValue((CSharpFormatSettingsKey key) => key.SPACE_AROUND_BITWISE_OP))
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.SPACE_AROUND_DOT))
            {
                return false;
            }

            if (!settingsStore.GetValue((CSharpFormatSettingsKey key) => key.SPACE_AROUND_EQUALITY_OP))
            {
                return false;
            }

            if (!settingsStore.GetValue((CSharpFormatSettingsKey key) => key.SPACE_AROUND_LAMBDA_ARROW))
            {
                return false;
            }

            if (!settingsStore.GetValue((CSharpFormatSettingsKey key) => key.SPACE_AROUND_LOGICAL_OP))
            {
                return false;
            }

            if (!settingsStore.GetValue((CSharpFormatSettingsKey key) => key.SPACE_AROUND_MULTIPLICATIVE_OP))
            {
                return false;
            }

            if (!settingsStore.GetValue((CSharpFormatSettingsKey key) => key.SPACE_AROUND_NULLCOALESCING_OP))
            {
                return false;
            }

            if (!settingsStore.GetValue((CSharpFormatSettingsKey key) => key.SPACE_AROUND_RELATIONAL_OP))
            {
                return false;
            }

            if (!settingsStore.GetValue((CSharpFormatSettingsKey key) => key.SPACE_AROUND_SHIFT_OP))
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.SPACE_BEFORE_ARRAY_ACCESS_BRACKETS))
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.SPACE_BEFORE_ARRAY_RANK_BRACKETS))
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.SPACE_BEFORE_ATTRIBUTE_COLON))
            {
                return false;
            }

            if (!settingsStore.GetValue((CSharpFormatSettingsKey key) => key.SPACE_BEFORE_CATCH_PARENTHESES))
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.SPACE_BEFORE_COLON_IN_CASE))
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.SPACE_BEFORE_COMMA))
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.SPACE_BEFORE_EMPTY_METHOD_CALL_PARENTHESES))
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.SPACE_BEFORE_EMPTY_METHOD_PARENTHESES))
            {
                return false;
            }

            if (!settingsStore.GetValue((CSharpFormatSettingsKey key) => key.SPACE_BEFORE_EXTENDS_COLON))
            {
                return false;
            }

            if (!settingsStore.GetValue((CSharpFormatSettingsKey key) => key.SPACE_BEFORE_FIXED_PARENTHESES))
            {
                return false;
            }

            if (!settingsStore.GetValue((CSharpFormatSettingsKey key) => key.SPACE_BEFORE_FOR_PARENTHESES))
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.SPACE_BEFORE_FOR_SEMICOLON))
            {
                return false;
            }

            if (!settingsStore.GetValue((CSharpFormatSettingsKey key) => key.SPACE_BEFORE_FOREACH_PARENTHESES))
            {
                return false;
            }

            if (!settingsStore.GetValue((CSharpFormatSettingsKey key) => key.SPACE_BEFORE_IF_PARENTHESES))
            {
                return false;
            }

            if (!settingsStore.GetValue((CSharpFormatSettingsKey key) => key.SPACE_BEFORE_LOCK_PARENTHESES))
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.SPACE_BEFORE_METHOD_CALL_PARENTHESES))
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.SPACE_BEFORE_METHOD_PARENTHESES))
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.SPACE_BEFORE_NULLABLE_MARK))
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.SPACE_BEFORE_POINTER_ASTERIK_DECLARATION))
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.SPACE_BEFORE_SEMICOLON))
            {
                return false;
            }

            if (!settingsStore.GetValue((CSharpFormatSettingsKey key) => key.SPACE_BEFORE_SINGLELINE_ACCESSORHOLDER))
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.SPACE_BEFORE_SIZEOF_PARENTHESES))
            {
                return false;
            }

            if (!settingsStore.GetValue((CSharpFormatSettingsKey key) => key.SPACE_BEFORE_SWITCH_PARENTHESES))
            {
                return false;
            }

            if (!settingsStore.GetValue((CSharpFormatSettingsKey key) => key.SPACE_BEFORE_TERNARY_COLON))
            {
                return false;
            }

            if (!settingsStore.GetValue((CSharpFormatSettingsKey key) => key.SPACE_BEFORE_TERNARY_QUEST))
            {
                return false;
            }

            if (!settingsStore.GetValue((CSharpFormatSettingsKey key) => key.SPACE_BEFORE_TRAILING_COMMENT))
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.SPACE_BEFORE_TYPE_ARGUMENT_ANGLE))
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.SPACE_BEFORE_TYPE_PARAMETER_ANGLE))
            {
                return false;
            }

            if (!settingsStore.GetValue((CSharpFormatSettingsKey key) => key.SPACE_BEFORE_TYPE_PARAMETER_CONSTRAINT_COLON))
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.SPACE_BEFORE_TYPEOF_PARENTHESES))
            {
                return false;
            }

            if (!settingsStore.GetValue((CSharpFormatSettingsKey key) => key.SPACE_BEFORE_USING_PARENTHESES))
            {
                return false;
            }

            if (!settingsStore.GetValue((CSharpFormatSettingsKey key) => key.SPACE_BEFORE_WHILE_PARENTHESES))
            {
                return false;
            }

            if (!settingsStore.GetValue((CSharpFormatSettingsKey key) => key.SPACE_BETWEEN_ACCESSORS_IN_SINGLELINE_PROPERTY))
            {
                return false;
            }

            if (!settingsStore.GetValue((CSharpFormatSettingsKey key) => key.SPACE_IN_SINGLELINE_ACCESSORHOLDER))
            {
                return false;
            }

            if (!settingsStore.GetValue((CSharpFormatSettingsKey key) => key.SPACE_IN_SINGLELINE_ANONYMOUS_METHOD))
            {
                return false;
            }

            if (!settingsStore.GetValue((CSharpFormatSettingsKey key) => key.SPACE_IN_SINGLELINE_METHOD))
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.SPACE_WITHIN_ARRAY_ACCESS_BRACKETS))
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.SPACE_WITHIN_ARRAY_RANK_BRACKETS))
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.SPACE_WITHIN_ARRAY_RANK_EMPTY_BRACKETS))
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.SPACE_WITHIN_ATTRIBUTE_BRACKETS))
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.SPACE_WITHIN_CATCH_PARENTHESES))
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.SPACE_WITHIN_EMPTY_METHOD_CALL_PARENTHESES))
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.SPACE_WITHIN_EMPTY_METHOD_PARENTHESES))
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.SPACE_WITHIN_FIXED_PARENTHESES))
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.SPACE_WITHIN_FOR_PARENTHESES))
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.SPACE_WITHIN_FOREACH_PARENTHESES))
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.SPACE_WITHIN_IF_PARENTHESES))
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.SPACE_WITHIN_LOCK_PARENTHESES))
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.SPACE_WITHIN_METHOD_CALL_PARENTHESES))
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.SPACE_WITHIN_METHOD_PARENTHESES))
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.SPACE_WITHIN_PARENTHESES))
            {
                return false;
            }

            if (!settingsStore.GetValue((CSharpFormatSettingsKey key) => key.SPACE_WITHIN_SINGLE_LINE_ARRAY_INITIALIZER_BRACES))
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.SPACE_WITHIN_SIZEOF_PARENTHESES))
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.SPACE_WITHIN_SWITCH_PARENTHESES))
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.SPACE_WITHIN_TYPE_ARGUMENT_ANGLES))
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.SPACE_WITHIN_TYPE_PARAMETER_ANGLES))
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.SPACE_WITHIN_TYPECAST_PARENTHESES))
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.SPACE_WITHIN_TYPEOF_PARENTHESES))
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.SPACE_WITHIN_USING_PARENTHESES))
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.SPACE_WITHIN_WHILE_PARENTHESES))
            {
                return false;
            }

            if (!settingsStore.GetValue((CSharpFormatSettingsKey key) => key.SPECIAL_ELSE_IF_TREATMENT))
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.STICK_COMMENT))
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.TYPE_DECLARATION_BRACES) != BraceFormatStyle.NEXT_LINE)
            {
                return false;
            }

            if (!settingsStore.GetValue((CSharpFormatSettingsKey key) => key.WRAP_AFTER_DECLARATION_LPAR))
            {
                return false;
            }

            if (!settingsStore.GetValue((CSharpFormatSettingsKey key) => key.WRAP_AFTER_INVOCATION_LPAR))
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.WRAP_ARGUMENTS_STYLE) != WrapStyle.CHOP_IF_LONG)
            {
                return false;
            }

            if (!settingsStore.GetValue((CSharpFormatSettingsKey key) => key.WRAP_BEFORE_BINARY_OPSIGN))
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.WRAP_BEFORE_DECLARATION_LPAR))
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.WRAP_BEFORE_EXTENDS_COLON))
            {
                return false;
            }

            if (!settingsStore.GetValue((CSharpFormatSettingsKey key) => key.WRAP_BEFORE_FIRST_TYPE_PARAMETER_CONSTRAINT))
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.WRAP_BEFORE_INVOCATION_LPAR))
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.WRAP_BEFORE_TYPE_PARAMETER_LANGLE))
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.WRAP_EXTENDS_LIST_STYLE) != WrapStyle.CHOP_IF_LONG)
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.WRAP_FOR_STMT_HEADER_STYLE) != WrapStyle.CHOP_IF_LONG)
            {
                return false;
            }

            if (!settingsStore.GetValue((CSharpFormatSettingsKey key) => key.WRAP_LINES))
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.WRAP_MULTIPLE_DECLARATION_STYLE) != WrapStyle.CHOP_IF_LONG)
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.WRAP_MULTIPLE_TYPE_PARAMEER_CONSTRAINTS_STYLE) != WrapStyle.CHOP_IF_LONG)
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.WRAP_OBJECT_AND_COLLECTION_INITIALIZER_STYLE) != WrapStyle.CHOP_IF_LONG)
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.WRAP_PARAMETERS_STYLE) != WrapStyle.CHOP_IF_LONG)
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.WRAP_TERNARY_EXPR_STYLE) != WrapStyle.CHOP_IF_LONG)
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpNamingSettings key) => key.EventHandlerPatternLong) != "$object$_On$event$")
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpNamingSettings key) => key.EventHandlerPatternShort) != "$event$Handler")
            {
                return false;
            }

            foreach (NamedElementKinds kindOfElement in Enum.GetValues(typeof(NamedElementKinds)))
            {
                NamingPolicy policy = settingsStore.GetIndexedValue<CSharpNamingSettings, NamedElementKinds, NamingPolicy>(
                    key => key.PredefinedNamingRules, kindOfElement);

                if (policy == null)
                {
                    policy = ClrPolicyProviderBase.GetDefaultPolicy(kindOfElement);
                }

                NamingRule rule = policy.NamingRule;
                if (rule.Suffix != string.Empty)
                {
                    return false;
                }

                switch (kindOfElement)
                {
                    case NamedElementKinds.Locals:
                    case NamedElementKinds.Parameters:
                    case NamedElementKinds.PrivateInstanceFields:
                    case NamedElementKinds.PrivateStaticFields:
                        if (rule.Prefix != string.Empty || rule.NamingStyleKind != NamingStyleKinds.aaBb)
                        {
                            return false;
                        }

                        break;

                    case NamedElementKinds.Interfaces:
                        if (rule.Prefix != "I" || rule.NamingStyleKind != NamingStyleKinds.AaBb)
                        {
                            return false;
                        }

                        break;

                    case NamedElementKinds.TypeParameters:
                        if (rule.Prefix != "T" || rule.NamingStyleKind != NamingStyleKinds.AaBb)
                        {
                            return false;
                        }

                        break;

                    default:
                        if (rule.Prefix != string.Empty || rule.NamingStyleKind != NamingStyleKinds.AaBb)
                        {
                            return false;
                        }

                        break;
                }
            }

            if (!settingsStore.GetValue(CSharpUsingSettingsAccessor.AddImportsToDeepestScope))
            {
                return false;
            }

            if (!settingsStore.GetValue(CSharpUsingSettingsAccessor.QualifiedUsingAtNestedScope))
            {
                return false;
            }

            if (!settingsStore.GetValue(CSharpUsingSettingsAccessor.AllowAlias))
            {
                return false;
            }

            if (!settingsStore.GetValue(CSharpUsingSettingsAccessor.CanUseGlobalAlias))
            {
                return false;
            }

            if (!settingsStore.GetValue(CSharpUsingSettingsAccessor.KeepNontrivialAlias))
            {
                return false;
            }

            if (settingsStore.GetValue(CSharpUsingSettingsAccessor.PreferQualifiedReference))
            {
                return false;
            }

            if (!settingsStore.GetValue(CSharpUsingSettingsAccessor.SortUsings))
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpFileLayoutPatternsSettings key) => key.Pattern) == null)
            {
                return false;
            }

            string reorderingPatterns;
            using (
                Stream stream =
                    Assembly.GetExecutingAssembly()
                        .GetManifestResourceStream("StyleCop.ReSharper.Resources.ReorderingPatterns.xml"))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    reorderingPatterns = reader.ReadToEnd();
                }
            }

            var value = settingsStore.GetValue((CSharpFileLayoutPatternsSettings key) => key.Pattern);
            if (!value.Equals(reorderingPatterns, StringComparison.InvariantCulture))
            {
                return false;
            }

            CodeCleanupProfile styleCopProfile = null;

            CodeCleanupSettingsComponent codeCleanupSettings =
                Shell.Instance.GetComponent<CodeCleanupSettingsComponent>();
            ICollection<CodeCleanupProfile> currentProfiles = codeCleanupSettings.GetProfiles(settingsStore);

            // Find the StyleCop profile
            foreach (CodeCleanupProfile profile in currentProfiles)
            {
                if (!profile.IsDefault)
                {
                    if (profile.Name == "StyleCop")
                    {
                        styleCopProfile = profile;
                    }
                }
            }

            if (styleCopProfile == null)
            {
                return false;
            }

            if (!styleCopProfile.GetSetting(CSharpHighlightingCleanupModule.ARRANGE_QUALIFIERS_DESCRIPTOR))
            {
                return false;
            }

            if (GetCodeCleanupProfileSetting<bool>(styleCopProfile, "CSUpdateFileHeader", null))
            {
                return false;
            }

            OptimizeUsings.OptimizeUsingsOptions optimizeUsingsOptions = styleCopProfile.GetSetting(OptimizeUsings.OPTIMIZE_USINGS_DESCRIPTOR);
            if (!optimizeUsingsOptions.OptimizeUsings)
            {
                return false;
            }

            if (optimizeUsingsOptions.EmbraceUsingsInRegion)
            {
                return false;
            }

            if (optimizeUsingsOptions.RegionName != string.Empty)
            {
                return false;
            }

            if (!GetCodeCleanupProfileSetting<bool>(styleCopProfile, "CSReformatCode", null))
            {
                return false;
            }

            if (GetCodeCleanupProfileSetting<bool>(styleCopProfile, "CSharpFormatDocComments", null))
            {
                return false;
            }

            if (!GetCodeCleanupProfileSetting<bool>(styleCopProfile, "CSReorderTypeMembers", null))
            {
                return false;
            }

            StyleCopCodeCleanupOptions options = styleCopProfile.GetSetting(StyleCopCodeCleanupModule.Descriptor);
            if (!options.FixViolations || options.CreateXmlDocStubs)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Returns a setting for the profile, descriptor and property name supplied.
        /// </summary>
        /// <typeparam name="T">
        /// The return type. 
        /// </typeparam>
        /// <param name="profile">
        /// The Cleanup profile to set. 
        /// </param>
        /// <param name="descriptorName">
        /// The name to match. 
        /// </param>
        /// <param name="propertyName">
        /// The property name to match. 
        /// </param>
        /// <returns>
        /// The property value. 
        /// </returns>
        private static T GetCodeCleanupProfileSetting<T>(CodeCleanupProfile profile, string descriptorName, string propertyName)
        {
            CodeCleanupOptionDescriptor cleanupOptionDescriptor = GetDescriptor(descriptorName);

            if (cleanupOptionDescriptor == null)
            {
                return default(T);
            }

            if (cleanupOptionDescriptor.Type == typeof(bool) || (cleanupOptionDescriptor.Type == typeof(string) || cleanupOptionDescriptor.Type.IsEnum))
            {
                return (T)profile.GetSetting(cleanupOptionDescriptor);
            }

            PropertyInfo propertyInfo = GetPropertyInfo(cleanupOptionDescriptor, propertyName);

            return propertyInfo != null ? (T)propertyInfo.GetValue(profile.GetSetting(cleanupOptionDescriptor), null) : default(T);
        }

        /// <summary>
        /// Gets a CleanupOptionsDescriptor matching the descriptor name passed in.
        /// </summary>
        /// <param name="descriptorName">
        /// The name to match. 
        /// </param>
        /// <returns>
        /// The CodeCleanupOptionDescriptor for the descriptor. 
        /// </returns>
        private static CodeCleanupOptionDescriptor GetDescriptor(string descriptorName)
        {
            CodeCleanupSettingsComponent codeCleanupSettings = Shell.Instance.GetComponent<CodeCleanupSettingsComponent>();
            IEnumerable<ICodeCleanupModule> currentModules = codeCleanupSettings.Modules;

            foreach (ICodeCleanupModule module in currentModules)
            {
                foreach (CodeCleanupOptionDescriptor descriptor in module.Descriptors)
                {
                    if (descriptor.Name == descriptorName && module.LanguageType.Name == "CSHARP")
                    {
                        return descriptor;
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Gets a PropertyInfo object matching the descriptor and the property name supplied.
        /// </summary>
        /// <param name="descriptor">
        /// The name to match. 
        /// </param>
        /// <param name="propertyName">
        /// The property name to match. 
        /// </param>
        /// <returns>
        /// A PropertyInfo matching. 
        /// </returns>
        private static PropertyInfo GetPropertyInfo(CodeCleanupOptionDescriptor descriptor, string propertyName)
        {
            return (from info in descriptor.Type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    let browsableAttributes = (BrowsableAttribute[])info.GetCustomAttributes(typeof(BrowsableAttribute), false)
                    where (browsableAttributes.Length != 1) || browsableAttributes[0].Browsable
                    select info).FirstOrDefault(info => info.Name == propertyName);
        }

        /// <summary>
        /// Sets a CodeCleanupProfile setting for the profile, descriptor and property name passed in.
        /// </summary>
        /// <param name="profile">
        /// The Cleanup profile to set. 
        /// </param>
        /// <param name="descriptorName">
        /// The descriptor name to match. 
        /// </param>
        /// <param name="propertyName">
        /// The property name to match. 
        /// </param>
        /// <param name="value">
        /// The new value. 
        /// </param>
        private static void SetCodeCleanupProfileSetting(CodeCleanupProfile profile, string descriptorName, string propertyName, object value)
        {
            CodeCleanupOptionDescriptor cleanupOptionDescriptor = GetDescriptor(descriptorName);

            if (cleanupOptionDescriptor == null)
            {
                return;
            }

            if (cleanupOptionDescriptor.Type == typeof(bool) || (cleanupOptionDescriptor.Type == typeof(string) || cleanupOptionDescriptor.Type.IsEnum))
            {
                profile.SetSetting(cleanupOptionDescriptor, value);
                return;
            }

            PropertyInfo propertyInfo = GetPropertyInfo(cleanupOptionDescriptor, propertyName);

            if (propertyInfo == null)
            {
                return;
            }

            object descriptorOptionsContainer = profile.GetSetting(cleanupOptionDescriptor);
            propertyInfo.SetValue(descriptorOptionsContainer, value, null);
            profile.SetSetting(cleanupOptionDescriptor, descriptorOptionsContainer);
        }
    }
}