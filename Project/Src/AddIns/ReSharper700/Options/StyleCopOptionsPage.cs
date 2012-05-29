// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StyleCopOptionsPage.cs" company="http://stylecop.codeplex.com">
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
//   Defines the StyleCopOptionsPage type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
extern alias JB;

namespace StyleCop.ReSharper700.Options
{
    #region Using Directives

    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Windows.Forms;

    using JetBrains.Application;
    using JetBrains.Application.Settings;
    using JetBrains.ProjectModel;
    using JetBrains.ReSharper.Feature.Services.CodeCleanup;
    using JetBrains.ReSharper.Psi.CSharp.CodeStyle;
    using JetBrains.ReSharper.Psi.CSharp.CodeStyle.FormatSettings;
    using JetBrains.ReSharper.Psi.CSharp.Naming2;
    using JetBrains.ReSharper.Psi.Naming.Settings;
    using JetBrains.Threading;
    using JetBrains.UI.Options;

    using StyleCop.ReSharper700.Core;

    #endregion

    /// <summary>
    /// Options page to allow the plugins options to be set from within the Resharper Options window.
    /// </summary>
    [OptionsPage(PID, "StyleCop", "StyleCop.ReSharper700.Resources.StyleCop.png", ParentId = "Tools")]
    public partial class StyleCopOptionsPage : UserControl, IOptionsPage
    {
        #region Constants

        /// <summary>
        /// The unique name of this options page.
        /// </summary>
        public const string PID = "StyleCopOptionsPage";

        /// <summary>
        /// The order of modifiers for StyleCop.
        /// </summary>
        private const string ModifiersOrder = "public protected internal private static new abstract virtual override sealed readonly extern unsafe volatile async";

        #endregion

        #region Static Fields

        /// <summary>
        /// The detected StyleCop path.
        /// </summary>
        private static string styleCopDetectedPath;

        #endregion

        #region Fields

        /// <summary>
        /// Reference to the IOptionsDialog that opened our page.
        /// </summary>
        private readonly IOptionsDialog dialog;

        /// <summary>
        /// The lifetime for this instance.
        /// </summary>
        private readonly JB::JetBrains.DataFlow.Lifetime lifetime;

        /// <summary>
        /// The settings context to use.
        /// </summary>
        private readonly OptionsSettingsSmartContext smartContext;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the StyleCopOptionsPage class.
        /// </summary>
        /// <param name="settingsSmartContext">
        /// Our settings context. 
        /// </param>
        /// <param name="threading">
        /// Our threading model. 
        /// </param>
        /// <param name="lifetime">
        /// The lifetime of the settings. 
        /// </param>
        public StyleCopOptionsPage(OptionsSettingsSmartContext settingsSmartContext, IThreading threading, JB::JetBrains.DataFlow.Lifetime lifetime)
        {
            this.smartContext = settingsSmartContext;
            this.lifetime = lifetime;
            this.InitializeComponent();
            this.dashesCountMaskedTextBox.ValidatingType = typeof(int);
            this.warningPanel.Visible = !CodeStyleOptionsValid(settingsSmartContext);
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the Control to be shown as page.
        /// </summary>
        /// <value>
        /// </value>
        public JetBrains.UI.CrossFramework.EitherControl Control
        {
            get
            {
                return this;
            }
        }

        /// <summary>
        /// Gets the ID of this option page. <see cref="T:JetBrains.UI.Options.IOptionsDialog"/> or <see cref="T:JetBrains.UI.Options.OptionsPageDescriptor"/> could be used to retrieve the <see cref="T:JetBrains.UI.Options.OptionsManager"/> out of it.
        /// </summary>
        /// <value>
        /// </value>
        public string Id
        {
            get
            {
                return PID;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Resets the CodeStyleOptions to be StyleCop compatible.
        /// </summary>
        /// <param name="settingsStore">
        /// The settings store to use. 
        /// </param>
        public static void CodeStyleOptionsReset(IContextBoundSettingsStore settingsStore)
        {
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
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.ARRANGE_MODIFIER_IN_EXISTING_CODE, true);
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
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.EXPLICIT_INTERNAL_MODIFIER, true);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.EXPLICIT_PRIVATE_MODIFIER, true);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.FORCE_ATTRIBUTE_STYLE, ForceAttributeStyle.SEPARATE);
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
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.INDENT_EMBRACED_INITIALIZER_BLOCK, false);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.INDENT_NESTED_FIXED_STMT, false);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.INDENT_NESTED_USINGS_STMT, false);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.INITIALIZER_BRACES, BraceFormatStyle.NEXT_LINE_SHIFTED_2);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.INVOCABLE_DECLARATION_BRACES, BraceFormatStyle.NEXT_LINE);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.KEEP_BLANK_LINES_IN_CODE, 1);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.KEEP_BLANK_LINES_IN_DECLARATIONS, 1);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.KEEP_USER_LINEBREAKS, false);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.LINE_FEED_AT_FILE_END, false);
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.MODIFIERS_ORDER, ModifiersOrder);
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
            settingsStore.SetValue((CSharpFormatSettingsKey key) => key.REDUNDANT_THIS_QUALIFIER_STYLE, ThisQualifierStyle.ALWAYS_USE);
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
                var policy = settingsStore.GetIndexedValue<CSharpNamingSettings, NamedElementKinds, NamingPolicy>(key => key.PredefinedNamingRules, kindOfElement)
                             ?? ClrPolicyProviderBase.GetDefaultPolicy(kindOfElement);

                NamingRule rule = policy.NamingRule;

                rule.Suffix = string.Empty;

                switch (kindOfElement)
                {
                    case NamedElementKinds.Locals:
                    case NamedElementKinds.Parameters:
                    case NamedElementKinds.PrivateInstanceFields:
                    case NamedElementKinds.PrivateStaticFields:
                    case NamedElementKinds.PrivateStaticReadonly:
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
            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("StyleCop.ReSharper700.Resources.ReorderingPatterns.xml"))
            {
                using (var reader = new StreamReader(stream))
                {
                    reorderingPatterns = reader.ReadToEnd();
                }
            }

            settingsStore.SetValue((CSharpMemberOrderPatternSettings key) => key.CustomPattern, reorderingPatterns);

            ISolution solution = Utils.GetSolution();

            if (solution != null)
            {
                CodeCleanupProfile styleCopProfile = null;

                CodeCleanup codeCleanupInstance = CodeCleanup.GetInstance(solution);

                var profiles = new List<CodeCleanupProfile>();

                var codeCleanupSettings = Shell.Instance.GetComponent<CodeCleanupSettingsComponent>();
                var currentProfiles = codeCleanupSettings.GetProfiles(settingsStore);

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

                SetCodeCleanupProfileSetting(codeCleanupInstance, styleCopProfile, "CSArrangeThisQualifier", null, true);

                SetCodeCleanupProfileSetting(codeCleanupInstance, styleCopProfile, "CSUpdateFileHeader", null, false);

                SetCodeCleanupProfileSetting(codeCleanupInstance, styleCopProfile, "CSOptimizeUsings", "OptimizeUsings", true);
                SetCodeCleanupProfileSetting(codeCleanupInstance, styleCopProfile, "CSOptimizeUsings", "EmbraceInRegion", false);
                SetCodeCleanupProfileSetting(codeCleanupInstance, styleCopProfile, "CSOptimizeUsings", "RegionName", string.Empty);

                SetCodeCleanupProfileSetting(codeCleanupInstance, styleCopProfile, "CSReformatCode", null, true);

                SetCodeCleanupProfileSetting(codeCleanupInstance, styleCopProfile, "CSharpFormatDocComments", null, true);

                SetCodeCleanupProfileSetting(codeCleanupInstance, styleCopProfile, "CSReorderTypeMembers", null, true);

                SetCodeCleanupProfileSetting(codeCleanupInstance, styleCopProfile, "StyleCop.Documentation", "SA1600ElementsMustBeDocumented", true);
                SetCodeCleanupProfileSetting(codeCleanupInstance, styleCopProfile, "StyleCop.Documentation", "SA1604ElementDocumentationMustHaveSummary", true);
                SetCodeCleanupProfileSetting(codeCleanupInstance, styleCopProfile, "StyleCop.Documentation", "SA1609PropertyDocumentationMustHaveValue", true);
                SetCodeCleanupProfileSetting(codeCleanupInstance, styleCopProfile, "StyleCop.Documentation", "SA1611ElementParametersMustBeDocumented", true);
                SetCodeCleanupProfileSetting(codeCleanupInstance, styleCopProfile, "StyleCop.Documentation", "SA1615ElementReturnValueMustBeDocumented", true);
                SetCodeCleanupProfileSetting(codeCleanupInstance, styleCopProfile, "StyleCop.Documentation", "SA1617VoidReturnValueMustNotBeDocumented", true);
                SetCodeCleanupProfileSetting(codeCleanupInstance, styleCopProfile, "StyleCop.Documentation", "SA1618GenericTypeParametersMustBeDocumented", true);
                SetCodeCleanupProfileSetting(
                    codeCleanupInstance, styleCopProfile, "StyleCop.Documentation", "SA1626SingleLineCommentsMustNotUseDocumentationStyleSlashes", true);
                SetCodeCleanupProfileSetting(codeCleanupInstance, styleCopProfile, "StyleCop.Documentation", "SA1628DocumentationTextMustBeginWithACapitalLetter", true);
                SetCodeCleanupProfileSetting(codeCleanupInstance, styleCopProfile, "StyleCop.Documentation", "SA1629DocumentationTextMustEndWithAPeriod", true);
                SetCodeCleanupProfileSetting(codeCleanupInstance, styleCopProfile, "StyleCop.Documentation", "SA1633SA1641UpdateFileHeader", 2); // Replace Copyright
                SetCodeCleanupProfileSetting(codeCleanupInstance, styleCopProfile, "StyleCop.Documentation", "SA1639FileHeaderMustHaveSummary", true);
                SetCodeCleanupProfileSetting(
                    codeCleanupInstance, styleCopProfile, "StyleCop.Documentation", "SA1642ConstructorSummaryDocumentationMustBeginWithStandardText", true);
                SetCodeCleanupProfileSetting(
                    codeCleanupInstance, styleCopProfile, "StyleCop.Documentation", "SA1643DestructorSummaryDocumentationMustBeginWithStandardText", true);
                SetCodeCleanupProfileSetting(codeCleanupInstance, styleCopProfile, "StyleCop.Documentation", "SA1644DocumentationHeadersMustNotContainBlankLines", true);

                SetCodeCleanupProfileSetting(codeCleanupInstance, styleCopProfile, "StyleCop.Layout", "SA1500CurlyBracketsForMultiLineStatementsMustNotShareLine", true);
                SetCodeCleanupProfileSetting(codeCleanupInstance, styleCopProfile, "StyleCop.Layout", "SA1509OpeningCurlyBracketsMustNotBePrecededByBlankLine", true);
                SetCodeCleanupProfileSetting(codeCleanupInstance, styleCopProfile, "StyleCop.Layout", "SA1510ChainedStatementBlocksMustNotBePrecededByBlankLine", true);
                SetCodeCleanupProfileSetting(codeCleanupInstance, styleCopProfile, "StyleCop.Layout", "SA1511WhileDoFooterMustNotBePrecededByBlankLine", true);
                SetCodeCleanupProfileSetting(codeCleanupInstance, styleCopProfile, "StyleCop.Layout", "SA1512SingleLineCommentsMustNotBeFollowedByBlankLine", true);
                SetCodeCleanupProfileSetting(codeCleanupInstance, styleCopProfile, "StyleCop.Layout", "SA1513ClosingCurlyBracketMustBeFollowedByBlankLine", true);
                SetCodeCleanupProfileSetting(codeCleanupInstance, styleCopProfile, "StyleCop.Layout", "SA1514ElementDocumentationHeaderMustBePrecededByBlankLine", true);
                SetCodeCleanupProfileSetting(codeCleanupInstance, styleCopProfile, "StyleCop.Layout", "SA1515SingleLineCommentMustBeProceededByBlankLine", true);

                SetCodeCleanupProfileSetting(codeCleanupInstance, styleCopProfile, "StyleCop.Maintainability", "SA1119StatementMustNotUseUnnecessaryParenthesis", true);

                SetCodeCleanupProfileSetting(codeCleanupInstance, styleCopProfile, "StyleCop.Ordering", "AlphabeticalUsingDirectives", 1); // Alphabetical
                SetCodeCleanupProfileSetting(codeCleanupInstance, styleCopProfile, "StyleCop.Ordering", "ExpandUsingDirectives", 1); // FullyQualify
                SetCodeCleanupProfileSetting(codeCleanupInstance, styleCopProfile, "StyleCop.Ordering", "SA1212PropertyAccessorsMustFollowOrder", true);
                SetCodeCleanupProfileSetting(codeCleanupInstance, styleCopProfile, "StyleCop.Ordering", "SA1213EventAccessorsMustFollowOrder", true);

                SetCodeCleanupProfileSetting(
                    codeCleanupInstance, styleCopProfile, "StyleCop.Readability", "SA1100DoNotPrefixCallsWithBaseUnlessLocalImplementationExists", true);
                SetCodeCleanupProfileSetting(codeCleanupInstance, styleCopProfile, "StyleCop.Readability", "SA1106CodeMustNotContainEmptyStatements", true);
                SetCodeCleanupProfileSetting(codeCleanupInstance, styleCopProfile, "StyleCop.Readability", "SA1108BlockStatementsMustNotContainEmbeddedComments", true);
                SetCodeCleanupProfileSetting(codeCleanupInstance, styleCopProfile, "StyleCop.Readability", "SA1109BlockStatementsMustNotContainEmbeddedRegions", true);
                SetCodeCleanupProfileSetting(codeCleanupInstance, styleCopProfile, "StyleCop.Readability", "SA1120CommentsMustContainText", true);
                SetCodeCleanupProfileSetting(codeCleanupInstance, styleCopProfile, "StyleCop.Readability", "SA1121UseBuiltInTypeAlias", true);
                SetCodeCleanupProfileSetting(codeCleanupInstance, styleCopProfile, "StyleCop.Readability", "SA1122UseStringEmptyForEmptyStrings", true);
                SetCodeCleanupProfileSetting(codeCleanupInstance, styleCopProfile, "StyleCop.Readability", "SA1123DoNotPlaceRegionsWithinElements", true);
                SetCodeCleanupProfileSetting(codeCleanupInstance, styleCopProfile, "StyleCop.Readability", "SA1124CodeMustNotContainEmptyRegions", true);

                SetCodeCleanupProfileSetting(codeCleanupInstance, styleCopProfile, "StyleCop.Spacing", "SA1001CommasMustBeSpacedCorrectly", true);
                SetCodeCleanupProfileSetting(codeCleanupInstance, styleCopProfile, "StyleCop.Spacing", "SA1005SingleLineCommentsMustBeginWithSingleSpace", true);
                SetCodeCleanupProfileSetting(codeCleanupInstance, styleCopProfile, "StyleCop.Spacing", "SA1006PreprocessorKeywordsMustNotBePrecededBySpace", true);
                SetCodeCleanupProfileSetting(codeCleanupInstance, styleCopProfile, "StyleCop.Spacing", "SA1021NegativeSignsMustBeSpacedCorrectly", true);
                SetCodeCleanupProfileSetting(codeCleanupInstance, styleCopProfile, "StyleCop.Spacing", "SA1022PositiveSignsMustBeSpacedCorrectly", true);
                SetCodeCleanupProfileSetting(codeCleanupInstance, styleCopProfile, "StyleCop.Spacing", "SA1025CodeMustNotContainMultipleWhitespaceInARow", true);

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

            if (!settingsStore.GetValue((CSharpFormatSettingsKey key) => key.ARRANGE_MODIFIER_IN_EXISTING_CODE))
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

            if (!settingsStore.GetValue((CSharpFormatSettingsKey key) => key.EXPLICIT_INTERNAL_MODIFIER))
            {
                return false;
            }

            if (!settingsStore.GetValue((CSharpFormatSettingsKey key) => key.EXPLICIT_PRIVATE_MODIFIER))
            {
                return false;
            }

            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.FORCE_ATTRIBUTE_STYLE) != ForceAttributeStyle.SEPARATE)
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

            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.INDENT_EMBRACED_INITIALIZER_BLOCK))
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

            if (!settingsStore.GetValue((CSharpFormatSettingsKey key) => key.MODIFIERS_ORDER).SequenceEqual(ModifiersOrder))
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

            if (settingsStore.GetValue((CSharpFormatSettingsKey key) => key.REDUNDANT_THIS_QUALIFIER_STYLE) != ThisQualifierStyle.ALWAYS_USE)
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
                var policy = settingsStore.GetIndexedValue<CSharpNamingSettings, NamedElementKinds, NamingPolicy>(key => key.PredefinedNamingRules, kindOfElement);

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
                    case NamedElementKinds.PrivateStaticReadonly:
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

            if (settingsStore.GetValue((CSharpMemberOrderPatternSettings key) => key.CustomPattern) == null)
            {
                return false;
            }

            string reorderingPatterns;
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("StyleCop.ReSharper700.Resources.ReorderingPatterns.xml"))
            {
                using (var reader = new StreamReader(stream))
                {
                    reorderingPatterns = reader.ReadToEnd();
                }
            }

            if (!settingsStore.GetValue((CSharpMemberOrderPatternSettings key) => key.CustomPattern).Equals(reorderingPatterns, StringComparison.InvariantCulture))
            {
                return false;
            }

            var solution = Utils.GetSolution();

            // We can only check the StyleCop profile settings if a solution is loaded.
            if (solution != null)
            {
                CodeCleanup codeCleanupInstance = CodeCleanup.GetInstance(solution);

                CodeCleanupProfile styleCopProfile = null;

                var codeCleanupSettings = Shell.Instance.GetComponent<CodeCleanupSettingsComponent>();
                var currentProfiles = codeCleanupSettings.GetProfiles(settingsStore);

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

                if (!GetCodeCleanupProfileSetting<bool>(codeCleanupInstance, styleCopProfile, "CSArrangeThisQualifier", null))
                {
                    return false;
                }

                if (GetCodeCleanupProfileSetting<bool>(codeCleanupInstance, styleCopProfile, "CSUpdateFileHeader", null))
                {
                    return false;
                }

                if (!GetCodeCleanupProfileSetting<bool>(codeCleanupInstance, styleCopProfile, "CSOptimizeUsings", "OptimizeUsings"))
                {
                    return false;
                }

                if (GetCodeCleanupProfileSetting<bool>(codeCleanupInstance, styleCopProfile, "CSOptimizeUsings", "EmbraceInRegion"))
                {
                    return false;
                }

                if (GetCodeCleanupProfileSetting<string>(codeCleanupInstance, styleCopProfile, "CSOptimizeUsings", "RegionName") != string.Empty)
                {
                    return false;
                }

                if (!GetCodeCleanupProfileSetting<bool>(codeCleanupInstance, styleCopProfile, "CSReformatCode", null))
                {
                    return false;
                }

                if (GetCodeCleanupProfileSetting<bool>(codeCleanupInstance, styleCopProfile, "CSharpFormatDocComments", null))
                {
                    return false;
                }

                if (!GetCodeCleanupProfileSetting<bool>(codeCleanupInstance, styleCopProfile, "CSReorderTypeMembers", null))
                {
                    return false;
                }

                if (!GetCodeCleanupProfileSetting<bool>(codeCleanupInstance, styleCopProfile, "StyleCop.Documentation", "SA1600ElementsMustBeDocumented"))
                {
                    return false;
                }

                if (!GetCodeCleanupProfileSetting<bool>(codeCleanupInstance, styleCopProfile, "StyleCop.Documentation", "SA1604ElementDocumentationMustHaveSummary"))
                {
                    return false;
                }

                if (!GetCodeCleanupProfileSetting<bool>(codeCleanupInstance, styleCopProfile, "StyleCop.Documentation", "SA1609PropertyDocumentationMustHaveValue"))
                {
                    return false;
                }

                if (!GetCodeCleanupProfileSetting<bool>(codeCleanupInstance, styleCopProfile, "StyleCop.Documentation", "SA1611ElementParametersMustBeDocumented"))
                {
                    return false;
                }

                if (!GetCodeCleanupProfileSetting<bool>(codeCleanupInstance, styleCopProfile, "StyleCop.Documentation", "SA1615ElementReturnValueMustBeDocumented"))
                {
                    return false;
                }

                if (!GetCodeCleanupProfileSetting<bool>(codeCleanupInstance, styleCopProfile, "StyleCop.Documentation", "SA1617VoidReturnValueMustNotBeDocumented"))
                {
                    return false;
                }

                if (!GetCodeCleanupProfileSetting<bool>(codeCleanupInstance, styleCopProfile, "StyleCop.Documentation", "SA1618GenericTypeParametersMustBeDocumented"))
                {
                    return false;
                }

                if (
                    !GetCodeCleanupProfileSetting<bool>(
                        codeCleanupInstance, styleCopProfile, "StyleCop.Documentation", "SA1626SingleLineCommentsMustNotUseDocumentationStyleSlashes"))
                {
                    return false;
                }

                if (
                    !GetCodeCleanupProfileSetting<bool>(
                        codeCleanupInstance, styleCopProfile, "StyleCop.Documentation", "SA1628DocumentationTextMustBeginWithACapitalLetter"))
                {
                    return false;
                }

                if (!GetCodeCleanupProfileSetting<bool>(codeCleanupInstance, styleCopProfile, "StyleCop.Documentation", "SA1629DocumentationTextMustEndWithAPeriod"))
                {
                    return false;
                }

                if (GetCodeCleanupProfileSetting<int>(codeCleanupInstance, styleCopProfile, "StyleCop.Documentation", "SA1633SA1641UpdateFileHeader") != 2)
                {
                    return false;
                }

                if (!GetCodeCleanupProfileSetting<bool>(codeCleanupInstance, styleCopProfile, "StyleCop.Documentation", "SA1639FileHeaderMustHaveSummary"))
                {
                    return false;
                }

                if (
                    !GetCodeCleanupProfileSetting<bool>(
                        codeCleanupInstance, styleCopProfile, "StyleCop.Documentation", "SA1642ConstructorSummaryDocumentationMustBeginWithStandardText"))
                {
                    return false;
                }

                if (
                    !GetCodeCleanupProfileSetting<bool>(
                        codeCleanupInstance, styleCopProfile, "StyleCop.Documentation", "SA1643DestructorSummaryDocumentationMustBeginWithStandardText"))
                {
                    return false;
                }

                if (
                    !GetCodeCleanupProfileSetting<bool>(
                        codeCleanupInstance, styleCopProfile, "StyleCop.Documentation", "SA1644DocumentationHeadersMustNotContainBlankLines"))
                {
                    return false;
                }

                if (
                    !GetCodeCleanupProfileSetting<bool>(
                        codeCleanupInstance, styleCopProfile, "StyleCop.Layout", "SA1500CurlyBracketsForMultiLineStatementsMustNotShareLine"))
                {
                    return false;
                }

                if (!GetCodeCleanupProfileSetting<bool>(codeCleanupInstance, styleCopProfile, "StyleCop.Layout", "SA1509OpeningCurlyBracketsMustNotBePrecededByBlankLine"))
                {
                    return false;
                }

                if (
                    !GetCodeCleanupProfileSetting<bool>(
                        codeCleanupInstance, styleCopProfile, "StyleCop.Layout", "SA1510ChainedStatementBlocksMustNotBePrecededByBlankLine"))
                {
                    return false;
                }

                if (!GetCodeCleanupProfileSetting<bool>(codeCleanupInstance, styleCopProfile, "StyleCop.Layout", "SA1511WhileDoFooterMustNotBePrecededByBlankLine"))
                {
                    return false;
                }

                if (!GetCodeCleanupProfileSetting<bool>(codeCleanupInstance, styleCopProfile, "StyleCop.Layout", "SA1512SingleLineCommentsMustNotBeFollowedByBlankLine"))
                {
                    return false;
                }

                if (!GetCodeCleanupProfileSetting<bool>(codeCleanupInstance, styleCopProfile, "StyleCop.Layout", "SA1513ClosingCurlyBracketMustBeFollowedByBlankLine"))
                {
                    return false;
                }

                if (
                    !GetCodeCleanupProfileSetting<bool>(
                        codeCleanupInstance, styleCopProfile, "StyleCop.Layout", "SA1514ElementDocumentationHeaderMustBePrecededByBlankLine"))
                {
                    return false;
                }

                if (!GetCodeCleanupProfileSetting<bool>(codeCleanupInstance, styleCopProfile, "StyleCop.Layout", "SA1515SingleLineCommentMustBeProceededByBlankLine"))
                {
                    return false;
                }

                if (
                    !GetCodeCleanupProfileSetting<bool>(
                        codeCleanupInstance, styleCopProfile, "StyleCop.Maintainability", "SA1119StatementMustNotUseUnnecessaryParenthesis"))
                {
                    return false;
                }

                // Alphabetical
                if (GetCodeCleanupProfileSetting<int>(codeCleanupInstance, styleCopProfile, "StyleCop.Ordering", "AlphabeticalUsingDirectives") != 1)
                {
                    return false;
                }

                // FullyQualify
                if (GetCodeCleanupProfileSetting<int>(codeCleanupInstance, styleCopProfile, "StyleCop.Ordering", "ExpandUsingDirectives") != 1)
                {
                    return false;
                }

                if (!GetCodeCleanupProfileSetting<bool>(codeCleanupInstance, styleCopProfile, "StyleCop.Ordering", "SA1212PropertyAccessorsMustFollowOrder"))
                {
                    return false;
                }

                if (!GetCodeCleanupProfileSetting<bool>(codeCleanupInstance, styleCopProfile, "StyleCop.Ordering", "SA1213EventAccessorsMustFollowOrder"))
                {
                    return false;
                }

                if (
                    !GetCodeCleanupProfileSetting<bool>(
                        codeCleanupInstance, styleCopProfile, "StyleCop.Readability", "SA1100DoNotPrefixCallsWithBaseUnlessLocalImplementationExists"))
                {
                    return false;
                }

                if (!GetCodeCleanupProfileSetting<bool>(codeCleanupInstance, styleCopProfile, "StyleCop.Readability", "SA1106CodeMustNotContainEmptyStatements"))
                {
                    return false;
                }

                if (
                    !GetCodeCleanupProfileSetting<bool>(
                        codeCleanupInstance, styleCopProfile, "StyleCop.Readability", "SA1108BlockStatementsMustNotContainEmbeddedComments"))
                {
                    return false;
                }

                if (
                    !GetCodeCleanupProfileSetting<bool>(
                        codeCleanupInstance, styleCopProfile, "StyleCop.Readability", "SA1109BlockStatementsMustNotContainEmbeddedRegions"))
                {
                    return false;
                }

                if (!GetCodeCleanupProfileSetting<bool>(codeCleanupInstance, styleCopProfile, "StyleCop.Readability", "SA1120CommentsMustContainText"))
                {
                    return false;
                }

                if (!GetCodeCleanupProfileSetting<bool>(codeCleanupInstance, styleCopProfile, "StyleCop.Readability", "SA1121UseBuiltInTypeAlias"))
                {
                    return false;
                }

                if (!GetCodeCleanupProfileSetting<bool>(codeCleanupInstance, styleCopProfile, "StyleCop.Readability", "SA1122UseStringEmptyForEmptyStrings"))
                {
                    return false;
                }

                if (!GetCodeCleanupProfileSetting<bool>(codeCleanupInstance, styleCopProfile, "StyleCop.Readability", "SA1123DoNotPlaceRegionsWithinElements"))
                {
                    return false;
                }

                if (!GetCodeCleanupProfileSetting<bool>(codeCleanupInstance, styleCopProfile, "StyleCop.Readability", "SA1124CodeMustNotContainEmptyRegions"))
                {
                    return false;
                }

                if (!GetCodeCleanupProfileSetting<bool>(codeCleanupInstance, styleCopProfile, "StyleCop.Spacing", "SA1001CommasMustBeSpacedCorrectly"))
                {
                    return false;
                }

                if (!GetCodeCleanupProfileSetting<bool>(codeCleanupInstance, styleCopProfile, "StyleCop.Spacing", "SA1005SingleLineCommentsMustBeginWithSingleSpace"))
                {
                    return false;
                }

                if (!GetCodeCleanupProfileSetting<bool>(codeCleanupInstance, styleCopProfile, "StyleCop.Spacing", "SA1006PreprocessorKeywordsMustNotBePrecededBySpace"))
                {
                    return false;
                }

                if (!GetCodeCleanupProfileSetting<bool>(codeCleanupInstance, styleCopProfile, "StyleCop.Spacing", "SA1021NegativeSignsMustBeSpacedCorrectly"))
                {
                    return false;
                }

                if (!GetCodeCleanupProfileSetting<bool>(codeCleanupInstance, styleCopProfile, "StyleCop.Spacing", "SA1022PositiveSignsMustBeSpacedCorrectly"))
                {
                    return false;
                }

                if (!GetCodeCleanupProfileSetting<bool>(codeCleanupInstance, styleCopProfile, "StyleCop.Spacing", "SA1025CodeMustNotContainMultipleWhitespaceInARow"))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Displays this instance.
        /// </summary>
        public void Display()
        {
            this.autoDetectCheckBox.Checked = string.IsNullOrEmpty(this.smartContext.GetValue<StyleCopOptionsSettingsKey, string>(key => key.SpecifiedAssemblyPath));

            if (this.autoDetectCheckBox.Checked)
            {
                this.ShowDetectedAssemblyLocation();
            }
            else
            {
                this.ShowSpecifiedAssemblyLocation();
            }

            this.performanceTrackBar.Value = this.smartContext.GetValue<StyleCopOptionsSettingsKey, int>(key => key.ParsingPerformance);
            this.insertTextCheckBox.Checked = this.smartContext.GetValue<StyleCopOptionsSettingsKey, bool>(key => key.InsertTextIntoDocumentation);
            this.dashesCountMaskedTextBox.Text =
                this.smartContext.GetValue<StyleCopOptionsSettingsKey, int>(key => key.DashesCountInFileHeader).ToString(CultureInfo.InvariantCulture);
            this.useExcludeFromStyleCopCheckBox.Checked = this.smartContext.GetValue<StyleCopOptionsSettingsKey, bool>(key => key.UseExcludeFromStyleCopSetting);
            this.justificationTextBox.Text = this.smartContext.GetValue<StyleCopOptionsSettingsKey, string>(key => key.SuppressStyleCopAttributeJustificationText);
            this.useSingleLineForDeclarationCommentsCheckBox.Checked =
                this.smartContext.GetValue<StyleCopOptionsSettingsKey, bool>(key => key.UseSingleLineDeclarationComments);
            this.enableAnalysisCheckBox.Checked = this.smartContext.GetValue<StyleCopOptionsSettingsKey, bool>(key => key.AnalysisEnabled);
            this.checkCodeStyleOptionsAtStartUpCheckBox.Checked =
                this.smartContext.GetValue<StyleCopOptionsSettingsKey, bool>(key => key.CheckReSharperCodeStyleOptionsAtStartUp);
            this.analyseReadOnlyFilesCheckBox.Checked = this.smartContext.GetValue<StyleCopOptionsSettingsKey, bool>(key => key.AnalyseReadOnlyFiles);
            this.insertToDoTextCheckBox.Checked = this.smartContext.GetValue<StyleCopOptionsSettingsKey, bool>(key => key.InsertToDoText);
        }

        /// <summary>
        /// Invoked when OK button in the options dialog is pressed If the page returns <c>False.</c> , the the options dialog won't be closed, and focus will be put into this page.
        /// </summary>
        /// <returns>
        /// Returns a boolean to represent if the page should be closed. 
        /// </returns>
        public bool OnOk()
        {
            if (this.ValidatePage())
            {
                string newLocation = string.Empty;
                var oldLocation = this.smartContext.GetValue<StyleCopOptionsSettingsKey, string>(key => key.SpecifiedAssemblyPath);

                if (!this.autoDetectCheckBox.Checked)
                {
                    newLocation = this.StyleCopLocationTextBox.Text.Trim();
                }

                if (newLocation != oldLocation)
                {
                    MessageBox.Show(
                        "These changes may require you to restart Visual Studio before they take effect.", "StyleCop", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.smartContext.SetValue<StyleCopOptionsSettingsKey, string>(key => key.SpecifiedAssemblyPath, newLocation);
                }

                this.smartContext.SetValue<StyleCopOptionsSettingsKey, int>(key => key.ParsingPerformance, this.performanceTrackBar.Value);
                this.smartContext.SetValue<StyleCopOptionsSettingsKey, bool>(key => key.InsertTextIntoDocumentation, this.insertTextCheckBox.Checked);
                this.smartContext.SetValue<StyleCopOptionsSettingsKey, int>(key => key.DashesCountInFileHeader, int.Parse(this.dashesCountMaskedTextBox.Text));
                this.smartContext.SetValue<StyleCopOptionsSettingsKey, bool>(key => key.UseExcludeFromStyleCopSetting, this.useExcludeFromStyleCopCheckBox.Checked);
                this.smartContext.SetValue<StyleCopOptionsSettingsKey, string>(
                    key => key.SuppressStyleCopAttributeJustificationText, this.justificationTextBox.Text.Trim());
                this.smartContext.SetValue<StyleCopOptionsSettingsKey, bool>(
                    key => key.UseSingleLineDeclarationComments, this.useSingleLineForDeclarationCommentsCheckBox.Checked);
                this.smartContext.SetValue<StyleCopOptionsSettingsKey, bool>(key => key.AnalysisEnabled, this.enableAnalysisCheckBox.Checked);
                this.smartContext.SetValue<StyleCopOptionsSettingsKey, bool>(
                    key => key.CheckReSharperCodeStyleOptionsAtStartUp, this.checkCodeStyleOptionsAtStartUpCheckBox.Checked);
                this.smartContext.SetValue<StyleCopOptionsSettingsKey, bool>(key => key.AnalyseReadOnlyFiles, this.analyseReadOnlyFilesCheckBox.Checked);
                this.smartContext.SetValue<StyleCopOptionsSettingsKey, bool>(key => key.InsertToDoText, this.insertToDoTextCheckBox.Checked);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Check if the settings on the page are consistent, and page could be closed.
        /// </summary>
        /// <returns>
        /// <c>True.</c> if page data is consistent. 
        /// </returns>
        public bool ValidatePage()
        {
            if (!this.autoDetectCheckBox.Checked)
            {
                if (!StyleCopReferenceHelper.LocationValid(this.StyleCopLocationTextBox.Text))
                {
                    var message = string.Format("Unable to find StyleCop assembly ({0}) at specified location.", Constants.StyleCopAssemblyName);

                    MessageBox.Show(message, "StyleCop", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            if (!this.dashesCountMaskedTextBox.MaskCompleted || this.dashesCountMaskedTextBox.Text == string.Empty)
            {
                this.toolTip.ToolTipTitle = "Invalid number";
                this.toolTip.Show("Enter a valid number.", this.dashesCountMaskedTextBox, this.dashesCountMaskedTextBox.Width - 16, -50, 5000);
                return false;
            }

            return true;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.UserControl.Load"/> event.
        /// </summary>
        /// <param name="e">
        /// An <see cref="T:System.EventArgs"/> that contains the event data. 
        /// </param>
        protected override void OnLoad(EventArgs e)
        {
            this.toolTip.SetToolTip(this.dashesCountMaskedTextBox, string.Empty);
            base.OnLoad(e);
            this.Display();
        }

        /// <summary>
        /// Returns a setting for the profile, descriptor and property name supplied.
        /// </summary>
        /// <typeparam name="T">
        /// The return type. 
        /// </typeparam>
        /// <param name="codeCleanup">
        /// The CodeCleanup object to use. 
        /// </param>
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
        private static T GetCodeCleanupProfileSetting<T>(CodeCleanup codeCleanup, CodeCleanupProfile profile, string descriptorName, string propertyName)
        {
            var cleanupOptionDescriptor = GetDescriptor(codeCleanup, descriptorName);

            if (cleanupOptionDescriptor == null)
            {
                return default(T);
            }

            if (cleanupOptionDescriptor.Type == typeof(bool) || (cleanupOptionDescriptor.Type == typeof(string) || cleanupOptionDescriptor.Type.IsEnum))
            {
                return (T)profile.GetSetting(cleanupOptionDescriptor);
            }

            var propertyInfo = GetPropertyInfo(cleanupOptionDescriptor, propertyName);

            return propertyInfo != null ? (T)propertyInfo.GetValue(profile.GetSetting(cleanupOptionDescriptor), null) : default(T);
        }

        /// <summary>
        /// Gets a CleanupOptionsDescriptor matching the descriptor name passed in.
        /// </summary>
        /// <param name="codeCleanup">
        /// The CodeCleanup object to use. 
        /// </param>
        /// <param name="descriptorName">
        /// The name to match. 
        /// </param>
        /// <returns>
        /// The CodeCleanupOptionDescriptor for the descriptor. 
        /// </returns>
        private static CodeCleanupOptionDescriptor GetDescriptor(CodeCleanup codeCleanup, string descriptorName)
        {
            var codeCleanupSettings = Shell.Instance.GetComponent<CodeCleanupSettingsComponent>();
            var currentModules = codeCleanupSettings.Modules;

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
        /// Geta a PropertyInfo object matching the descriptor and the property name supplied.
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
        /// <param name="codeCleanup">
        /// The CodeCleanup object to use. 
        /// </param>
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
        private static void SetCodeCleanupProfileSetting(CodeCleanup codeCleanup, CodeCleanupProfile profile, string descriptorName, string propertyName, object value)
        {
            var cleanupOptionDescriptor = GetDescriptor(codeCleanup, descriptorName);

            if (cleanupOptionDescriptor == null)
            {
                return;
            }

            if (cleanupOptionDescriptor.Type == typeof(bool) || (cleanupOptionDescriptor.Type == typeof(string) || cleanupOptionDescriptor.Type.IsEnum))
            {
                profile.SetSetting(cleanupOptionDescriptor, value);
                return;
            }

            var propertyInfo = GetPropertyInfo(cleanupOptionDescriptor, propertyName);

            if (propertyInfo == null)
            {
                return;
            }

            object descriptorOptionsContainer = profile.GetSetting(cleanupOptionDescriptor);
            propertyInfo.SetValue(descriptorOptionsContainer, value, null);
            profile.SetSetting(cleanupOptionDescriptor, descriptorOptionsContainer);
        }

        /// <summary>
        /// Handles the CheckedChanged event of the AutoDetectCheckBox control.
        /// </summary>
        /// <param name="sender">
        /// The source of the event. 
        /// </param>
        /// <param name="e">
        /// The <see cref="System.EventArgs"/> instance containing the event data. 
        /// </param>
        private void AutoDetectCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (this.autoDetectCheckBox.Checked)
            {
                this.ShowDetectedAssemblyLocation();
            }
            else
            {
                this.ShowSpecifiedAssemblyLocation();
            }
        }

        /// <summary>
        /// Handles the Click event of the BrowseButton control.
        /// </summary>
        /// <param name="sender">
        /// The source of the event. 
        /// </param>
        /// <param name="e">
        /// The <see cref="System.EventArgs"/> instance containing the event data. 
        /// </param>
        private void BrowseButton_Click(object sender, EventArgs e)
        {
            this.ShowFileDialog();
        }

        private void DashesCountMaskedTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            this.toolTip.Hide(this.dashesCountMaskedTextBox);
        }

        private void ResetFormatOptionsButton_Click(object sender, EventArgs e)
        {
            CodeStyleOptionsReset(this.smartContext);
            MessageBox.Show(
                @"C# code style options have been set in order to fix StyleCop violations. Ensure your R# Settings are saved.", @"StyleCop", MessageBoxButtons.OK);
            this.resetFormatOptionsButton.Enabled = false;
        }

        /// <summary>
        /// Shows the detected assembly location.
        /// </summary>
        private void ShowDetectedAssemblyLocation()
        {
            var location = StyleCopOptionsSettingsKey.DetectStyleCopPath();

            if (string.IsNullOrEmpty(location))
            {
                this.StyleCopLocationTextBox.Text = "Failed to detect location.";
            }
            else
            {
                this.StyleCopLocationTextBox.Text = location;
            }

            this.BrowseButton.Enabled = false;
            this.StyleCopLocationTextBox.Enabled = false;
        }

        /// <summary>
        /// Shows the file dialog.
        /// </summary>
        private void ShowFileDialog()
        {
            if (!string.IsNullOrEmpty(this.StyleCopLocationTextBox.Text))
            {
                var dir = Path.GetDirectoryName(this.StyleCopLocationTextBox.Text);

                if (!string.IsNullOrEmpty(dir))
                {
                    this.StyleCopLocationDialog.InitialDirectory = dir;
                }
            }

            if (this.StyleCopLocationDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            this.StyleCopLocationTextBox.Text = this.StyleCopLocationDialog.FileName;
        }

        /// <summary>
        /// Shows the specified assembly location.
        /// </summary>
        private void ShowSpecifiedAssemblyLocation()
        {
            this.StyleCopLocationTextBox.Text = this.smartContext.GetValue<StyleCopOptionsSettingsKey, string>(key => key.SpecifiedAssemblyPath);
            this.BrowseButton.Enabled = true;
            this.StyleCopLocationTextBox.Enabled = true;
        }

        #endregion
    }
}