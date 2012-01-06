// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StyleCopOptionsPage.cs" company="http://stylecop.codeplex.com">
//   MS-PL
// </copyright>
// <license>//   This source code is subject to terms and conditions of the Microsoft //   Public License. A copy of the license can be found in the License.html //   file at the root of this distribution. If you cannot locate the  //   Microsoft Public License, please send an email to dlr@microsoft.com. //   By using this source code in any fashion, you are agreeing to be bound //   by the terms of the Microsoft Public License. You must not remove this //   notice, or any other, from this software.// </license>
// <summary>
//   Defines the StyleCopOptionsPage type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace StyleCop.ReSharper.Options
{
    #region Using Directives

    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Windows.Forms;

    using JetBrains.IDE;
    using JetBrains.ProjectModel;
    using JetBrains.ReSharper.Feature.Services.CodeCleanup;
    using JetBrains.ReSharper.Psi.CodeStyle;
    using JetBrains.ReSharper.Psi.CSharp;
    using JetBrains.ReSharper.Psi.CSharp.CodeStyle;
    using JetBrains.ReSharper.Psi.Naming.Settings;
    using JetBrains.UI.Options;

    using StyleCop.ReSharper.Core;

    #endregion

    /// <summary>
    /// Options page to allow the plugins options to be set from within the Resharper Options window.
    /// </summary>
    [OptionsPage(PageName, "StyleCop", "StyleCop.ReSharper.Resources.StyleCop.png", ParentId = "Tools")]
    public partial class StyleCopOptionsPage : UserControl, IOptionsPage
    {
        #region Constants and Fields

        /// <summary>
        /// The unique name of this options page.
        /// </summary>
        public const string PageName = "StyleCop.StyleCopOptionsPage";

        /// <summary>
        /// Reference to the IOptionsDialog that opened our page.
        /// </summary>
        private readonly IOptionsDialog dialog;

        /// <summary>
        /// The order of modifiers for StyleCop.
        /// </summary>
        private static readonly string[] ModifiersOrder = new[]
            {
                "public", "protected", "internal", "private", "static", "new", "abstract", "virtual", "override", "sealed", "readonly", "extern", "unsafe", "volatile"
            };
        
        /// <summary>
        /// The instance of this options page.
        /// </summary>
        private static StyleCopOptionsPage instance;

        /// <summary>
        /// The currently open solution.
        /// </summary>
        private ISolution solution;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="StyleCopOptionsPage"/> class.
        /// </summary>
        /// <param name="dialog">The options dialog reference opening our page.</param>
        public StyleCopOptionsPage(IOptionsDialog dialog)
        {
            instance = this;
            this.dialog = dialog;

            this.solution = dialog.DataContext.GetData(DataConstants.SOLUTION);
            if (this.solution != null)
            {
                this.InitializeComponent();
                this.daysMaskedTextBox.ValidatingType = typeof(int);
                this.dashesCountMaskedTextBox.ValidatingType = typeof(int);
                this.warningPanel.Visible = !CodeStyleOptionsValid(this.solution);
            }
            else
            {
                Controls.Add(JetBrains.UI.Options.Helpers.Controls.CreateNoSolutionCueBanner());
            }
        }

        #endregion
        
        #region Properties

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>
        /// The instance.
        /// </value>
        public static StyleCopOptionsPage Instance
        {
            get
            {
                return instance;
            }
        }

        /// <summary>
        /// Gets the Control to be shown as page.
        /// </summary>
        /// <value>
        /// </value>
        public Control Control
        {
            get
            {
                return this;
            }
        }

        /// <summary>
        /// Gets the ID of this option page.
        /// <see cref="T:JetBrains.UI.Options.IOptionsDialog"/>or <see cref="T:JetBrains.UI.Options.OptionsPageDescriptor"/> could be used to retrieve the <see cref="T:JetBrains.UI.Options.OptionsManager"/> out of it.
        /// </summary>
        /// <value>
        /// </value>
        public string Id
        {
            get
            {
                return PageName;
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Resets the CodeStyleOptions to be StyleCop compatible.
        /// </summary>
        /// <param name="solution">The solution to reset.</param>
        public static void ResetCodeStyleOptions(ISolution solution)
        {
            CodeStyleSettings settings = solution == null ? CodeStyleSettingsManager.Instance.CodeStyleSettings : SolutionCodeStyleSettings.GetInstance(solution).CodeStyleSettings;

            CSharpCodeStyleSettings codeStyleSettings = settings.Get<CSharpCodeStyleSettings>();

            var formatSettings = codeStyleSettings.FormatSettings;

            formatSettings.ALIGN_FIRST_ARG_BY_PAREN = false;
            formatSettings.ALIGN_LINQ_QUERY = true;
            formatSettings.ALIGN_MULTILINE_ARGUMENT = false;
            formatSettings.ALIGN_MULTILINE_ARRAY_AND_OBJECT_INITIALIZER = true;
            formatSettings.ALIGN_MULTILINE_EXPRESSION = true;
            formatSettings.ALIGN_MULTILINE_EXTENDS_LIST = true;
            formatSettings.ALIGN_MULTILINE_FOR_STMT = true;
            formatSettings.ALIGN_MULTILINE_PARAMETER = true;
            formatSettings.ALIGN_MULTIPLE_DECLARATION = true;
            formatSettings.ALIGN_MULTLINE_TYPE_PARAMETER_CONSTRAINS = true;
            formatSettings.ALIGN_MULTLINE_TYPE_PARAMETER_LIST = true;
            formatSettings.ALLOW_COMMENT_AFTER_LBRACE = false;
            formatSettings.ANONYMOUS_METHOD_DECLARATION_BRACES = BraceFormatStyle.NEXT_LINE_SHIFTED_2;
            formatSettings.ARRANGE_MODIFIER_IN_EXISTING_CODE = true;
            formatSettings.BLANK_LINES_AFTER_START_COMMENT = 1;
            formatSettings.BLANK_LINES_AFTER_USING = 1;
            formatSettings.BLANK_LINES_AFTER_USING_LIST = 1;
            formatSettings.BLANK_LINES_AROUND_FIELD = 1;
            formatSettings.BLANK_LINES_AROUND_INVOCABLE = 1;
            formatSettings.BLANK_LINES_AROUND_NAMESPACE = 1;
            formatSettings.BLANK_LINES_AROUND_REGION = 1;
            formatSettings.BLANK_LINES_AROUND_SINGLE_LINE_FIELD = 1;
            formatSettings.BLANK_LINES_AROUND_SINGLE_LINE_INVOCABLE = 1;
            formatSettings.BLANK_LINES_AROUND_TYPE = 1;
            formatSettings.BLANK_LINES_BEFORE_USING = 0;
            formatSettings.BLANK_LINES_BETWEEN_USING_GROUPS = 1;
            formatSettings.BLANK_LINES_INSIDE_REGION = 1;
            formatSettings.CASE_BLOCK_BRACES = BraceFormatStyle.NEXT_LINE_SHIFTED_2;
            formatSettings.CONTINUOUS_INDENT_MULTIPLIER = 1;
            formatSettings.EMPTY_BLOCK_STYLE = EmptyBlockStyle.MULTILINE;
            formatSettings.EXPLICIT_INTERNAL_MODIFIER = true;
            formatSettings.EXPLICIT_PRIVATE_MODIFIER = true;
            formatSettings.FORCE_ATTRIBUTE_STYLE = ForceAttributeStyle.SEPARATE;
            formatSettings.FORCE_CHOP_COMPOUND_DO_EXPRESSION = false;
            formatSettings.FORCE_CHOP_COMPOUND_IF_EXPRESSION = false;
            formatSettings.FORCE_CHOP_COMPOUND_WHILE_EXPRESSION = false;
            formatSettings.FORCE_FIXED_BRACES_STYLE = ForceBraceStyle.ALWAYS_ADD;
            formatSettings.FORCE_FOR_BRACES_STYLE = ForceBraceStyle.ALWAYS_ADD;
            formatSettings.FORCE_FOREACH_BRACES_STYLE = ForceBraceStyle.ALWAYS_ADD;
            formatSettings.FORCE_IFELSE_BRACES_STYLE = ForceBraceStyle.ALWAYS_ADD;
            formatSettings.FORCE_USING_BRACES_STYLE = ForceBraceStyle.DO_NOT_CHANGE;
            formatSettings.FORCE_WHILE_BRACES_STYLE = ForceBraceStyle.ALWAYS_ADD;
            formatSettings.INDENT_ANONYMOUS_METHOD_BLOCK = false;
            formatSettings.INDENT_CASE_FROM_SWITCH = true;
            formatSettings.INDENT_EMBRACED_INITIALIZER_BLOCK = false;
            formatSettings.INDENT_NESTED_FIXED_STMT = false;
            formatSettings.INDENT_NESTED_USINGS_STMT = false;
            formatSettings.INITIALIZER_BRACES = BraceFormatStyle.NEXT_LINE_SHIFTED_2;
            formatSettings.INVOCABLE_DECLARATION_BRACES = BraceFormatStyle.NEXT_LINE;
            formatSettings.KEEP_BLANK_LINES_IN_CODE = 1;
            formatSettings.KEEP_BLANK_LINES_IN_DECLARATIONS = 1;
            formatSettings.KEEP_USER_LINEBREAKS = false;
            formatSettings.LINE_FEED_AT_FILE_END = false;
            formatSettings.MODIFIERS_ORDER = ModifiersOrder;
            formatSettings.OTHER_BRACES = BraceFormatStyle.NEXT_LINE;
            formatSettings.PLACE_ABSTRACT_ACCESSORHOLDER_ON_SINGLE_LINE = true;
            formatSettings.PLACE_ACCESSORHOLDER_ATTRIBUTE_ON_SAME_LINE = false;
            formatSettings.PLACE_CATCH_ON_NEW_LINE = true;
            formatSettings.PLACE_CONSTRUCTOR_INITIALIZER_ON_SAME_LINE = false;
            formatSettings.PLACE_ELSE_ON_NEW_LINE = true;
            formatSettings.PLACE_FIELD_ATTRIBUTE_ON_SAME_LINE = false;
            formatSettings.PLACE_FINALLY_ON_NEW_LINE = true;
            formatSettings.PLACE_METHOD_ATTRIBUTE_ON_SAME_LINE = false;
            formatSettings.PLACE_SIMPLE_ACCESSOR_ON_SINGLE_LINE = false;
            formatSettings.PLACE_SIMPLE_ACCESSORHOLDER_ON_SINGLE_LINE = false;
            formatSettings.PLACE_SIMPLE_ANONYMOUSMETHOD_ON_SINGLE_LINE = true;
            formatSettings.PLACE_SIMPLE_INITIALIZER_ON_SINGLE_LINE = true;
            formatSettings.PLACE_SIMPLE_LINQ_ON_SINGLE_LINE = true;
            formatSettings.PLACE_SIMPLE_METHOD_ON_SINGLE_LINE = false;
            formatSettings.PLACE_TYPE_ATTRIBUTE_ON_SAME_LINE = false;
            formatSettings.PLACE_TYPE_CONSTRAINTS_ON_SAME_LINE = false;
            formatSettings.PLACE_WHILE_ON_NEW_LINE = true;
            formatSettings.REDUNDANT_THIS_QUALIFIER_STYLE = ThisQualifierStyle.ALWAYS_USE;
            formatSettings.SIMPLE_EMBEDDED_STATEMENT_STYLE = SimpleEmbeddedStatementStyle.ON_SINGLE_LINE;
            formatSettings.SPACE_AFTER_AMPERSAND_OP = false;
            formatSettings.SPACE_AFTER_ASTERIK_OP = false;
            formatSettings.SPACE_AFTER_ATTRIBUTE_COLON = true;
            formatSettings.SPACE_AFTER_COMMA = true;
            formatSettings.SPACE_AFTER_EXTENDS_COLON = true;
            formatSettings.SPACE_AFTER_FOR_SEMICOLON = true;
            formatSettings.SPACE_AFTER_TERNARY_COLON = true;
            formatSettings.SPACE_AFTER_TERNARY_QUEST = true;
            formatSettings.SPACE_AFTER_TYPE_PARAMETER_CONSTRAINT_COLON = true;
            formatSettings.SPACE_AFTER_TYPECAST_PARENTHESES = false;
            formatSettings.SPACE_AROUND_ADDITIVE_OP = true;
            formatSettings.SPACE_AROUND_ALIAS_EQ = true;
            formatSettings.SPACE_AROUND_ARROW_OP = false;
            formatSettings.SPACE_AROUND_ASSIGNMENT_OP = true;
            formatSettings.SPACE_AROUND_BITWISE_OP = true;
            formatSettings.SPACE_AROUND_DOT = false;
            formatSettings.SPACE_AROUND_EQUALITY_OP = true;
            formatSettings.SPACE_AROUND_LAMBDA_ARROW = true;
            formatSettings.SPACE_AROUND_LOGICAL_OP = true;
            formatSettings.SPACE_AROUND_MULTIPLICATIVE_OP = true;
            formatSettings.SPACE_AROUND_NULLCOALESCING_OP = true;
            formatSettings.SPACE_AROUND_RELATIONAL_OP = true;
            formatSettings.SPACE_AROUND_SHIFT_OP = true;
            formatSettings.SPACE_BEFORE_ARRAY_ACCESS_BRACKETS = false;
            formatSettings.SPACE_BEFORE_ARRAY_CREATION_BRACE = true;
            formatSettings.SPACE_BEFORE_ARRAY_RANK_BRACKETS = false;
            formatSettings.SPACE_BEFORE_ATTRIBUTE_COLON = false;
            formatSettings.SPACE_BEFORE_CATCH_PARENTHESES = true;
            formatSettings.SPACE_BEFORE_COLON_IN_CASE = false;
            formatSettings.SPACE_BEFORE_COMMA = false;
            formatSettings.SPACE_BEFORE_EMPTY_METHOD_CALL_PARENTHESES = false;
            formatSettings.SPACE_BEFORE_EMPTY_METHOD_PARENTHESES = false;
            formatSettings.SPACE_BEFORE_EXTENDS_COLON = true;
            formatSettings.SPACE_BEFORE_FIXED_PARENTHESES = true;
            formatSettings.SPACE_BEFORE_FOR_PARENTHESES = true;
            formatSettings.SPACE_BEFORE_FOR_SEMICOLON = false;
            formatSettings.SPACE_BEFORE_FOREACH_PARENTHESES = true;
            formatSettings.SPACE_BEFORE_IF_PARENTHESES = true;
            formatSettings.SPACE_BEFORE_LOCK_PARENTHESES = true;
            formatSettings.SPACE_BEFORE_METHOD_CALL_PARENTHESES = false;
            formatSettings.SPACE_BEFORE_METHOD_PARENTHESES = false;
            formatSettings.SPACE_BEFORE_NULLABLE_MARK = false;
            formatSettings.SPACE_BEFORE_POINTER_ASTERIK_DECLARATION = false;
            formatSettings.SPACE_BEFORE_SEMICOLON = false;
            formatSettings.SPACE_BEFORE_SINGLELINE_ACCESSORHOLDER = true;
            formatSettings.SPACE_BEFORE_SIZEOF_PARENTHESES = false;
            formatSettings.SPACE_BEFORE_SWITCH_PARENTHESES = true;
            formatSettings.SPACE_BEFORE_TERNARY_COLON = true;
            formatSettings.SPACE_BEFORE_TERNARY_QUEST = true;
            formatSettings.SPACE_BEFORE_TRAILING_COMMENT = true;
            formatSettings.SPACE_BEFORE_TYPE_ARGUMENT_ANGLE = false;
            formatSettings.SPACE_BEFORE_TYPE_PARAMETER_ANGLE = false;
            formatSettings.SPACE_BEFORE_TYPE_PARAMETER_CONSTRAINT_COLON = true;
            formatSettings.SPACE_BEFORE_TYPEOF_PARENTHESES = false;
            formatSettings.SPACE_BEFORE_USING_PARENTHESES = true;
            formatSettings.SPACE_BEFORE_WHILE_PARENTHESES = true;
            formatSettings.SPACE_BETWEEN_ACCESSORS_IN_SINGLELINE_PROPERTY = true;
            formatSettings.SPACE_IN_SINGLELINE_ACCESSOR = true;
            formatSettings.SPACE_IN_SINGLELINE_ANONYMOUS_METHOD = true;
            formatSettings.SPACE_IN_SINGLELINE_METHOD = true;
            formatSettings.SPACE_WITHIN_ARRAY_ACCESS_BRACKETS = false;
            formatSettings.SPACE_WITHIN_ARRAY_RANK_BRACKETS = false;
            formatSettings.SPACE_WITHIN_ARRAY_RANK_EMPTY_BRACKETS = false;
            formatSettings.SPACE_WITHIN_ATTRIBUTE_BRACKETS = false;
            formatSettings.SPACE_WITHIN_CATCH_PARENTHESES = false;
            formatSettings.SPACE_WITHIN_EMPTY_METHOD_CALL_PARENTHESES = false;
            formatSettings.SPACE_WITHIN_EMPTY_METHOD_PARENTHESES = false;
            formatSettings.SPACE_WITHIN_FIXED_PARENTHESES = false;
            formatSettings.SPACE_WITHIN_FOR_PARENTHESES = false;
            formatSettings.SPACE_WITHIN_FOREACH_PARENTHESES = false;
            formatSettings.SPACE_WITHIN_IF_PARENTHESES = false;
            formatSettings.SPACE_WITHIN_LOCK_PARENTHESES = false;
            formatSettings.SPACE_WITHIN_METHOD_CALL_PARENTHESES = false;
            formatSettings.SPACE_WITHIN_METHOD_PARENTHESES = false;
            formatSettings.SPACE_WITHIN_PARENTHESES = false;
            formatSettings.SPACE_WITHIN_SINGLE_LINE_ARRAY_INITIALIZER_BRACES = true;
            formatSettings.SPACE_WITHIN_SIZEOF_PARENTHESES = false;
            formatSettings.SPACE_WITHIN_SWITCH_PARENTHESES = false;
            formatSettings.SPACE_WITHIN_TYPE_ARGUMENT_ANGLES = false;
            formatSettings.SPACE_WITHIN_TYPE_PARAMETER_ANGLES = false;
            formatSettings.SPACE_WITHIN_TYPECAST_PARENTHESES = false;
            formatSettings.SPACE_WITHIN_TYPEOF_PARENTHESES = false;
            formatSettings.SPACE_WITHIN_USING_PARENTHESES = false;
            formatSettings.SPACE_WITHIN_WHILE_PARENTHESES = false;
            formatSettings.SPECIAL_ELSE_IF_TREATMENT = true;
            formatSettings.STICK_COMMENT = false;
            formatSettings.TYPE_DECLARATION_BRACES = BraceFormatStyle.NEXT_LINE;
            formatSettings.WRAP_AFTER_BINARY_OPSIGN = false;
            formatSettings.WRAP_AFTER_DECLARATION_LPAR = true;
            formatSettings.WRAP_AFTER_INVOCATION_LPAR = true;
            formatSettings.WRAP_ARGUMENTS_STYLE = WrapStyle.CHOP_IF_LONG;
            formatSettings.WRAP_BEFORE_BINARY_OPSIGN = true;
            formatSettings.WRAP_BEFORE_DECLARATION_LPAR = false;
            formatSettings.WRAP_BEFORE_EXTENDS_COLON = false;
            formatSettings.WRAP_BEFORE_FIRST_TYPE_PARAMETER_CONSTRAINT = true;
            formatSettings.WRAP_BEFORE_INVOCATION_LPAR = false;
            formatSettings.WRAP_BEFORE_TYPE_PARAMETER_LANGLE = false;
            formatSettings.WRAP_EXTENDS_LIST_STYLE = WrapStyle.CHOP_IF_LONG;
            formatSettings.WRAP_FOR_STMT_HEADER_STYLE = WrapStyle.CHOP_IF_LONG;
            formatSettings.WRAP_LIMIT = formatSettings.WRAP_LIMIT; // We don't need to set this. It's here for completeness.
            formatSettings.WRAP_LINES = true;
            formatSettings.WRAP_MULTIPLE_DECLARATION_STYLE = WrapStyle.CHOP_IF_LONG;
            formatSettings.WRAP_MULTIPLE_TYPE_PARAMEER_CONSTRAINTS_STYLE = WrapStyle.CHOP_IF_LONG;
            formatSettings.WRAP_OBJECT_AND_COLLECTION_INITIALIZER_STYLE = WrapStyle.CHOP_IF_LONG;
            formatSettings.WRAP_PARAMETERS_STYLE = WrapStyle.CHOP_IF_LONG;
            formatSettings.WRAP_TERNARY_EXPR_STYLE = WrapStyle.CHOP_IF_LONG;

            var namingSettings = codeStyleSettings.GetNamingSettings2();

            namingSettings.OverrideDefaultSettings = true;

            namingSettings.EventHandlerPatternLong = "$object$_On$event$";
            namingSettings.EventHandlerPatternShort = "$event$Handler";

            foreach (var predefinedRule in namingSettings.PredefinedNamingRules)
            {
                NamingRule rule = predefinedRule.Value.NamingRule;
                rule.Suffix = string.Empty;

                switch (predefinedRule.Key)
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
            }

            var usingsSettings = codeStyleSettings.UsingsSettings;

            usingsSettings.AddImportsToDeepestScope = true;
            usingsSettings.QualifiedUsingAtNestedScope = true;

            usingsSettings.AllowAlias = true;
            usingsSettings.CanUseGlobalAlias = true;
            usingsSettings.KeepNontrivialAlias = true;
            usingsSettings.PreferQualifiedReference = false;
            usingsSettings.SortUsings = true;

            string reorderingPatterns;
            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("StyleCop.ReSharper.Resources.ReorderingPatterns.xml"))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    reorderingPatterns = reader.ReadToEnd();
                }
            }

            codeStyleSettings.CustomMembersReorderingPatterns = reorderingPatterns;

            CodeCleanupProfile styleCopProfile = null;

            CodeCleanup codeCleanupInstance = CodeCleanup.GetInstance(solution);

            List<CodeCleanupProfile> profiles = new List<CodeCleanupProfile>();

            // Find the StyleCop profile
            foreach (CodeCleanupProfile profile in codeCleanupInstance.Profiles)
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
                styleCopProfile = codeCleanupInstance.CreateEmptyProfile();
                styleCopProfile.Name = "StyleCop";
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
            SetCodeCleanupProfileSetting(codeCleanupInstance, styleCopProfile, "StyleCop.Documentation", "SA1626SingleLineCommentsMustNotUseDocumentationStyleSlashes", true);
            SetCodeCleanupProfileSetting(codeCleanupInstance, styleCopProfile, "StyleCop.Documentation", "SA1628DocumentationTextMustBeginWithACapitalLetter", true);
            SetCodeCleanupProfileSetting(codeCleanupInstance, styleCopProfile, "StyleCop.Documentation", "SA1629DocumentationTextMustEndWithAPeriod", true);
            SetCodeCleanupProfileSetting(codeCleanupInstance, styleCopProfile, "StyleCop.Documentation", "SA1633SA1641UpdateFileHeader", 2); // Replace Copyright
            SetCodeCleanupProfileSetting(codeCleanupInstance, styleCopProfile, "StyleCop.Documentation", "SA1639FileHeaderMustHaveSummary", true);
            SetCodeCleanupProfileSetting(codeCleanupInstance, styleCopProfile, "StyleCop.Documentation", "SA1642ConstructorSummaryDocumentationMustBeginWithStandardText", true);
            SetCodeCleanupProfileSetting(codeCleanupInstance, styleCopProfile, "StyleCop.Documentation", "SA1643DestructorSummaryDocumentationMustBeginWithStandardText", true);
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

            SetCodeCleanupProfileSetting(codeCleanupInstance, styleCopProfile, "StyleCop.Readability", "SA1100DoNotPrefixCallsWithBaseUnlessLocalImplementationExists", true);
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

            codeCleanupInstance.Profiles = profiles;
            codeCleanupInstance.SilentCleanupProfileName = styleCopProfile.Name;
        }

        /// <summary>
        /// Confirms that the ReSharper code style options are all valid to ensure no StyleCop issues on cleanup.
        /// </summary>
        /// <param name="solution">The solution to use to validate the settings.</param>
        /// <returns>True if options are all valid, otherwise false.</returns>
        public static bool CodeStyleOptionsValid(ISolution solution)
        {
            CodeStyleSettings settings = solution == null ? CodeStyleSettingsManager.Instance.CodeStyleSettings : SolutionCodeStyleSettings.GetInstance(solution).CodeStyleSettings;

            CSharpCodeStyleSettings codeStyleSettings = settings.Get<CSharpCodeStyleSettings>();

            var formatSettings = codeStyleSettings.FormatSettings;

            if (formatSettings.ALIGN_FIRST_ARG_BY_PAREN)
            {
                return false;
            }

            if (!formatSettings.ALIGN_LINQ_QUERY)
            {
                return false;
            }

            if (formatSettings.ALIGN_MULTILINE_ARGUMENT)
            {
                return false;
            }

            if (!formatSettings.ALIGN_MULTILINE_ARRAY_AND_OBJECT_INITIALIZER)
            {
                return false;
            }

            if (!formatSettings.ALIGN_MULTILINE_EXPRESSION)
            {
                return false;
            }

            if (!formatSettings.ALIGN_MULTILINE_EXTENDS_LIST)
            {
                return false;
            }

            if (!formatSettings.ALIGN_MULTILINE_FOR_STMT)
            {
                return false;
            }

            if (!formatSettings.ALIGN_MULTILINE_PARAMETER)
            {
                return false;
            }

            if (!formatSettings.ALIGN_MULTIPLE_DECLARATION)
            {
                return false;
            }

            if (!formatSettings.ALIGN_MULTLINE_TYPE_PARAMETER_CONSTRAINS)
            {
                return false;
            }

            if (!formatSettings.ALIGN_MULTLINE_TYPE_PARAMETER_LIST)
            {
                return false;
            }

            if (formatSettings.ALLOW_COMMENT_AFTER_LBRACE)
            {
                return false;
            }

            if (formatSettings.ANONYMOUS_METHOD_DECLARATION_BRACES != BraceFormatStyle.NEXT_LINE_SHIFTED_2)
            {
                return false;
            }

            if (!formatSettings.ARRANGE_MODIFIER_IN_EXISTING_CODE)
            {
                return false;
            }

            if (formatSettings.BLANK_LINES_AFTER_START_COMMENT != 1)
            {
                return false;
            }

            if (formatSettings.BLANK_LINES_AFTER_USING != 1)
            {
                return false;
            }

            if (formatSettings.BLANK_LINES_AFTER_USING_LIST != 1)
            {
                return false;
            }

            if (formatSettings.BLANK_LINES_AROUND_FIELD != 1)
            {
                return false;
            }

            if (formatSettings.BLANK_LINES_AROUND_INVOCABLE != 1)
            {
                return false;
            }

            if (formatSettings.BLANK_LINES_AROUND_NAMESPACE != 1)
            {
                return false;
            }

            if (formatSettings.BLANK_LINES_AROUND_REGION != 1)
            {
                return false;
            }

            if (formatSettings.BLANK_LINES_AROUND_SINGLE_LINE_FIELD != 1)
            {
                return false;
            }

            if (formatSettings.BLANK_LINES_AROUND_SINGLE_LINE_INVOCABLE != 1)
            {
                return false;
            }

            if (formatSettings.BLANK_LINES_AROUND_TYPE != 1)
            {
                return false;
            }

            if (formatSettings.BLANK_LINES_BEFORE_USING != 0)
            {
                return false;
            }

            if (formatSettings.BLANK_LINES_BETWEEN_USING_GROUPS != 1)
            {
                return false;
            }

            if (formatSettings.BLANK_LINES_INSIDE_REGION != 1)
            {
                return false;
            }

            if (formatSettings.CASE_BLOCK_BRACES != BraceFormatStyle.NEXT_LINE_SHIFTED_2)
            {
                return false;
            }

            if (formatSettings.CONTINUOUS_INDENT_MULTIPLIER != 1)
            {
                return false;
            }

            if (formatSettings.EMPTY_BLOCK_STYLE != EmptyBlockStyle.MULTILINE)
            {
                return false;
            }

            if (!formatSettings.EXPLICIT_INTERNAL_MODIFIER)
            {
                return false;
            }

            if (!formatSettings.EXPLICIT_PRIVATE_MODIFIER)
            {
                return false;
            }

            if (formatSettings.FORCE_ATTRIBUTE_STYLE != ForceAttributeStyle.SEPARATE)
            {
                return false;
            }

            if (formatSettings.FORCE_CHOP_COMPOUND_DO_EXPRESSION)
            {
                return false;
            }

            if (formatSettings.FORCE_CHOP_COMPOUND_IF_EXPRESSION)
            {
                return false;
            }

            if (formatSettings.FORCE_CHOP_COMPOUND_WHILE_EXPRESSION)
            {
                return false;
            }

            if (formatSettings.FORCE_FIXED_BRACES_STYLE != ForceBraceStyle.ALWAYS_ADD)
            {
                return false;
            }

            if (formatSettings.FORCE_FOR_BRACES_STYLE != ForceBraceStyle.ALWAYS_ADD)
            {
                return false;
            }

            if (formatSettings.FORCE_FOREACH_BRACES_STYLE != ForceBraceStyle.ALWAYS_ADD)
            {
                return false;
            }

            if (formatSettings.FORCE_IFELSE_BRACES_STYLE != ForceBraceStyle.ALWAYS_ADD)
            {
                return false;
            }

            if (formatSettings.FORCE_USING_BRACES_STYLE != ForceBraceStyle.DO_NOT_CHANGE)
            {
                return false;
            }

            if (formatSettings.FORCE_WHILE_BRACES_STYLE != ForceBraceStyle.ALWAYS_ADD)
            {
                return false;
            }

            if (formatSettings.INDENT_ANONYMOUS_METHOD_BLOCK)
            {
                return false;
            }

            if (!formatSettings.INDENT_CASE_FROM_SWITCH)
            {
                return false;
            }

            if (formatSettings.INDENT_EMBRACED_INITIALIZER_BLOCK)
            {
                return false;
            }

            if (formatSettings.INDENT_NESTED_FIXED_STMT)
            {
                return false;
            }

            if (formatSettings.INDENT_NESTED_USINGS_STMT)
            {
                return false;
            }

            if (formatSettings.INITIALIZER_BRACES != BraceFormatStyle.NEXT_LINE_SHIFTED_2)
            {
                return false;
            }

            if (formatSettings.INVOCABLE_DECLARATION_BRACES != BraceFormatStyle.NEXT_LINE)
            {
                return false;
            }

            if (formatSettings.KEEP_BLANK_LINES_IN_CODE != 1)
            {
                return false;
            }

            if (formatSettings.KEEP_BLANK_LINES_IN_DECLARATIONS != 1)
            {
                return false;
            }

            if (formatSettings.KEEP_USER_LINEBREAKS)
            {
                return false;
            }

            if (formatSettings.LINE_FEED_AT_FILE_END)
            {
                return false;
            }

            if (!formatSettings.MODIFIERS_ORDER.SequenceEqual(ModifiersOrder))
            {
                return false;
            }

            if (formatSettings.OTHER_BRACES != BraceFormatStyle.NEXT_LINE)
            {
                return false;
            }

            if (!formatSettings.PLACE_ABSTRACT_ACCESSORHOLDER_ON_SINGLE_LINE)
            {
                return false;
            }

            if (formatSettings.PLACE_ACCESSORHOLDER_ATTRIBUTE_ON_SAME_LINE)
            {
                return false;
            }

            if (!formatSettings.PLACE_CATCH_ON_NEW_LINE)
            {
                return false;
            }

            if (formatSettings.PLACE_CONSTRUCTOR_INITIALIZER_ON_SAME_LINE)
            {
                return false;
            }

            if (!formatSettings.PLACE_ELSE_ON_NEW_LINE)
            {
                return false;
            }

            if (formatSettings.PLACE_FIELD_ATTRIBUTE_ON_SAME_LINE)
            {
                return false;
            }

            if (!formatSettings.PLACE_FINALLY_ON_NEW_LINE)
            {
                return false;
            }

            if (formatSettings.PLACE_METHOD_ATTRIBUTE_ON_SAME_LINE)
            {
                return false;
            }

            if (formatSettings.PLACE_SIMPLE_ACCESSOR_ON_SINGLE_LINE)
            {
                return false;
            }

            if (formatSettings.PLACE_SIMPLE_ACCESSORHOLDER_ON_SINGLE_LINE)
            {
                return false;
            }

            if (!formatSettings.PLACE_SIMPLE_ANONYMOUSMETHOD_ON_SINGLE_LINE)
            {
                return false;
            }

            if (!formatSettings.PLACE_SIMPLE_INITIALIZER_ON_SINGLE_LINE)
            {
                return false;
            }

            if (!formatSettings.PLACE_SIMPLE_LINQ_ON_SINGLE_LINE)
            {
                return false;
            }

            if (formatSettings.PLACE_SIMPLE_METHOD_ON_SINGLE_LINE)
            {
                return false;
            }

            if (formatSettings.PLACE_TYPE_ATTRIBUTE_ON_SAME_LINE)
            {
                return false;
            }

            if (formatSettings.PLACE_TYPE_CONSTRAINTS_ON_SAME_LINE)
            {
                return false;
            }

            if (!formatSettings.PLACE_WHILE_ON_NEW_LINE)
            {
                return false;
            }

            if (formatSettings.REDUNDANT_THIS_QUALIFIER_STYLE != ThisQualifierStyle.ALWAYS_USE)
            {
                return false;
            }

            if (formatSettings.SIMPLE_EMBEDDED_STATEMENT_STYLE != SimpleEmbeddedStatementStyle.ON_SINGLE_LINE)
            {
                return false;
            }

            if (formatSettings.SPACE_AFTER_AMPERSAND_OP)
            {
                return false;
            }

            if (formatSettings.SPACE_AFTER_ASTERIK_OP)
            {
                return false;
            }

            if (!formatSettings.SPACE_AFTER_ATTRIBUTE_COLON)
            {
                return false;
            }

            if (!formatSettings.SPACE_AFTER_COMMA)
            {
                return false;
            }

            if (!formatSettings.SPACE_AFTER_EXTENDS_COLON)
            {
                return false;
            }

            if (!formatSettings.SPACE_AFTER_FOR_SEMICOLON)
            {
                return false;
            }

            if (!formatSettings.SPACE_AFTER_TERNARY_COLON)
            {
                return false;
            }

            if (!formatSettings.SPACE_AFTER_TERNARY_QUEST)
            {
                return false;
            }

            if (!formatSettings.SPACE_AFTER_TYPE_PARAMETER_CONSTRAINT_COLON)
            {
                return false;
            }

            if (formatSettings.SPACE_AFTER_TYPECAST_PARENTHESES)
            {
                return false;
            }

            if (!formatSettings.SPACE_AROUND_ADDITIVE_OP)
            {
                return false;
            }

            if (!formatSettings.SPACE_AROUND_ALIAS_EQ)
            {
                return false;
            }

            if (formatSettings.SPACE_AROUND_ARROW_OP)
            {
                return false;
            }

            if (!formatSettings.SPACE_AROUND_ASSIGNMENT_OP)
            {
                return false;
            }

            if (!formatSettings.SPACE_AROUND_BITWISE_OP)
            {
                return false;
            }

            if (formatSettings.SPACE_AROUND_DOT)
            {
                return false;
            }

            if (!formatSettings.SPACE_AROUND_EQUALITY_OP)
            {
                return false;
            }

            if (!formatSettings.SPACE_AROUND_LAMBDA_ARROW)
            {
                return false;
            }

            if (!formatSettings.SPACE_AROUND_LOGICAL_OP)
            {
                return false;
            }

            if (!formatSettings.SPACE_AROUND_MULTIPLICATIVE_OP)
            {
                return false;
            }

            if (!formatSettings.SPACE_AROUND_NULLCOALESCING_OP)
            {
                return false;
            }

            if (!formatSettings.SPACE_AROUND_RELATIONAL_OP)
            {
                return false;
            }

            if (!formatSettings.SPACE_AROUND_SHIFT_OP)
            {
                return false;
            }

            if (formatSettings.SPACE_BEFORE_ARRAY_ACCESS_BRACKETS)
            {
                return false;
            }

            if (!formatSettings.SPACE_BEFORE_ARRAY_CREATION_BRACE)
            {
                return false;
            }

            if (formatSettings.SPACE_BEFORE_ARRAY_RANK_BRACKETS)
            {
                return false;
            }

            if (formatSettings.SPACE_BEFORE_ATTRIBUTE_COLON)
            {
                return false;
            }

            if (!formatSettings.SPACE_BEFORE_CATCH_PARENTHESES)
            {
                return false;
            }

            if (formatSettings.SPACE_BEFORE_COLON_IN_CASE)
            {
                return false;
            }

            if (formatSettings.SPACE_BEFORE_COMMA)
            {
                return false;
            }

            if (formatSettings.SPACE_BEFORE_EMPTY_METHOD_CALL_PARENTHESES)
            {
                return false;
            }

            if (formatSettings.SPACE_BEFORE_EMPTY_METHOD_PARENTHESES)
            {
                return false;
            }

            if (!formatSettings.SPACE_BEFORE_EXTENDS_COLON)
            {
                return false;
            }

            if (!formatSettings.SPACE_BEFORE_FIXED_PARENTHESES)
            {
                return false;
            }

            if (!formatSettings.SPACE_BEFORE_FOR_PARENTHESES)
            {
                return false;
            }

            if (formatSettings.SPACE_BEFORE_FOR_SEMICOLON)
            {
                return false;
            }

            if (!formatSettings.SPACE_BEFORE_FOREACH_PARENTHESES)
            {
                return false;
            }

            if (!formatSettings.SPACE_BEFORE_IF_PARENTHESES)
            {
                return false;
            }

            if (!formatSettings.SPACE_BEFORE_LOCK_PARENTHESES)
            {
                return false;
            }

            if (formatSettings.SPACE_BEFORE_METHOD_CALL_PARENTHESES)
            {
                return false;
            }

            if (formatSettings.SPACE_BEFORE_METHOD_PARENTHESES)
            {
                return false;
            }

            if (formatSettings.SPACE_BEFORE_NULLABLE_MARK)
            {
                return false;
            }

            if (formatSettings.SPACE_BEFORE_POINTER_ASTERIK_DECLARATION)
            {
                return false;
            }

            if (formatSettings.SPACE_BEFORE_SEMICOLON)
            {
                return false;
            }

            if (!formatSettings.SPACE_BEFORE_SINGLELINE_ACCESSORHOLDER)
            {
                return false;
            }

            if (formatSettings.SPACE_BEFORE_SIZEOF_PARENTHESES)
            {
                return false;
            }

            if (!formatSettings.SPACE_BEFORE_SWITCH_PARENTHESES)
            {
                return false;
            }

            if (!formatSettings.SPACE_BEFORE_TERNARY_COLON)
            {
                return false;
            }

            if (!formatSettings.SPACE_BEFORE_TERNARY_QUEST)
            {
                return false;
            }

            if (!formatSettings.SPACE_BEFORE_TRAILING_COMMENT)
            {
                return false;
            }

            if (formatSettings.SPACE_BEFORE_TYPE_ARGUMENT_ANGLE)
            {
                return false;
            }

            if (formatSettings.SPACE_BEFORE_TYPE_PARAMETER_ANGLE)
            {
                return false;
            }

            if (!formatSettings.SPACE_BEFORE_TYPE_PARAMETER_CONSTRAINT_COLON)
            {
                return false;
            }

            if (formatSettings.SPACE_BEFORE_TYPEOF_PARENTHESES)
            {
                return false;
            }

            if (!formatSettings.SPACE_BEFORE_USING_PARENTHESES)
            {
                return false;
            }

            if (!formatSettings.SPACE_BEFORE_WHILE_PARENTHESES)
            {
                return false;
            }

            if (!formatSettings.SPACE_BETWEEN_ACCESSORS_IN_SINGLELINE_PROPERTY)
            {
                return false;
            }

            if (!formatSettings.SPACE_IN_SINGLELINE_ACCESSOR)
            {
                return false;
            }

            if (!formatSettings.SPACE_IN_SINGLELINE_ANONYMOUS_METHOD)
            {
                return false;
            }

            if (!formatSettings.SPACE_IN_SINGLELINE_METHOD)
            {
                return false;
            }

            if (formatSettings.SPACE_WITHIN_ARRAY_ACCESS_BRACKETS)
            {
                return false;
            }

            if (formatSettings.SPACE_WITHIN_ARRAY_RANK_BRACKETS)
            {
                return false;
            }

            if (formatSettings.SPACE_WITHIN_ARRAY_RANK_EMPTY_BRACKETS)
            {
                return false;
            }

            if (formatSettings.SPACE_WITHIN_ATTRIBUTE_BRACKETS)
            {
                return false;
            }

            if (formatSettings.SPACE_WITHIN_CATCH_PARENTHESES)
            {
                return false;
            }

            if (formatSettings.SPACE_WITHIN_EMPTY_METHOD_CALL_PARENTHESES)
            {
                return false;
            }

            if (formatSettings.SPACE_WITHIN_EMPTY_METHOD_PARENTHESES)
            {
                return false;
            }

            if (formatSettings.SPACE_WITHIN_FIXED_PARENTHESES)
            {
                return false;
            }

            if (formatSettings.SPACE_WITHIN_FOR_PARENTHESES)
            {
                return false;
            }

            if (formatSettings.SPACE_WITHIN_FOREACH_PARENTHESES)
            {
                return false;
            }

            if (formatSettings.SPACE_WITHIN_IF_PARENTHESES)
            {
                return false;
            }

            if (formatSettings.SPACE_WITHIN_LOCK_PARENTHESES)
            {
                return false;
            }

            if (formatSettings.SPACE_WITHIN_METHOD_CALL_PARENTHESES)
            {
                return false;
            }

            if (formatSettings.SPACE_WITHIN_METHOD_PARENTHESES)
            {
                return false;
            }

            if (formatSettings.SPACE_WITHIN_PARENTHESES)
            {
                return false;
            }

            if (!formatSettings.SPACE_WITHIN_SINGLE_LINE_ARRAY_INITIALIZER_BRACES)
            {
                return false;
            }

            if (formatSettings.SPACE_WITHIN_SIZEOF_PARENTHESES)
            {
                return false;
            }

            if (formatSettings.SPACE_WITHIN_SWITCH_PARENTHESES)
            {
                return false;
            }

            if (formatSettings.SPACE_WITHIN_TYPE_ARGUMENT_ANGLES)
            {
                return false;
            }

            if (formatSettings.SPACE_WITHIN_TYPE_PARAMETER_ANGLES)
            {
                return false;
            }

            if (formatSettings.SPACE_WITHIN_TYPECAST_PARENTHESES)
            {
                return false;
            }

            if (formatSettings.SPACE_WITHIN_TYPEOF_PARENTHESES)
            {
                return false;
            }

            if (formatSettings.SPACE_WITHIN_USING_PARENTHESES)
            {
                return false;
            }

            if (formatSettings.SPACE_WITHIN_WHILE_PARENTHESES)
            {
                return false;
            }

            if (!formatSettings.SPECIAL_ELSE_IF_TREATMENT)
            {
                return false;
            }

            if (formatSettings.STICK_COMMENT)
            {
                return false;
            }

            if (formatSettings.TYPE_DECLARATION_BRACES != BraceFormatStyle.NEXT_LINE)
            {
                return false;
            }

            if (formatSettings.WRAP_AFTER_BINARY_OPSIGN)
            {
                return false;
            }

            if (!formatSettings.WRAP_AFTER_DECLARATION_LPAR)
            {
                return false;
            }

            if (!formatSettings.WRAP_AFTER_INVOCATION_LPAR)
            {
                return false;
            }

            if (formatSettings.WRAP_ARGUMENTS_STYLE != WrapStyle.CHOP_IF_LONG)
            {
                return false;
            }

            if (!formatSettings.WRAP_BEFORE_BINARY_OPSIGN)
            {
                return false;
            }

            if (formatSettings.WRAP_BEFORE_DECLARATION_LPAR)
            {
                return false;
            }

            if (formatSettings.WRAP_BEFORE_EXTENDS_COLON)
            {
                return false;
            }

            if (!formatSettings.WRAP_BEFORE_FIRST_TYPE_PARAMETER_CONSTRAINT)
            {
                return false;
            }

            if (formatSettings.WRAP_BEFORE_INVOCATION_LPAR)
            {
                return false;
            }

            if (formatSettings.WRAP_BEFORE_TYPE_PARAMETER_LANGLE)
            {
                return false;
            }

            if (formatSettings.WRAP_EXTENDS_LIST_STYLE != WrapStyle.CHOP_IF_LONG)
            {
                return false;
            }

            if (formatSettings.WRAP_FOR_STMT_HEADER_STYLE != WrapStyle.CHOP_IF_LONG)
            {
                return false;
            }

            // We don't need to change this. It's here for completeness.
            if (formatSettings.WRAP_LIMIT != formatSettings.WRAP_LIMIT)
            {
                return false;
            }

            if (!formatSettings.WRAP_LINES)
            {
                return false;
            }

            if (formatSettings.WRAP_MULTIPLE_DECLARATION_STYLE != WrapStyle.CHOP_IF_LONG)
            {
                return false;
            }

            if (formatSettings.WRAP_MULTIPLE_TYPE_PARAMEER_CONSTRAINTS_STYLE != WrapStyle.CHOP_IF_LONG)
            {
                return false;
            }

            if (formatSettings.WRAP_OBJECT_AND_COLLECTION_INITIALIZER_STYLE != WrapStyle.CHOP_IF_LONG)
            {
                return false;
            }

            if (formatSettings.WRAP_PARAMETERS_STYLE != WrapStyle.CHOP_IF_LONG)
            {
                return false;
            }

            if (formatSettings.WRAP_TERNARY_EXPR_STYLE != WrapStyle.CHOP_IF_LONG)
            {
                return false;
            }

            var namingSettings = codeStyleSettings.GetNamingSettings2();

            if (!namingSettings.OverrideDefaultSettings)
            {
                return false;
            }

            if (namingSettings.EventHandlerPatternLong != "$object$_On$event$")
            {
                return false;
            }

            if (namingSettings.EventHandlerPatternShort != "$event$Handler")
            {
                return false;
            }

            foreach (var predefinedRule in namingSettings.PredefinedNamingRules)
            {
                NamingRule rule = predefinedRule.Value.NamingRule;
                if (rule.Suffix != string.Empty)
                {
                    return false;
                }

                switch (predefinedRule.Key)
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

            var usingsSettings = codeStyleSettings.UsingsSettings;

            if (!usingsSettings.AddImportsToDeepestScope)
            {
                return false;
            }

            if (!usingsSettings.QualifiedUsingAtNestedScope)
            {
                return false;
            }

            if (!usingsSettings.AllowAlias)
            {
                return false;
            }

            if (!usingsSettings.CanUseGlobalAlias)
            {
                return false;
            }

            if (!usingsSettings.KeepNontrivialAlias)
            {
                return false;
            }

            if (usingsSettings.PreferQualifiedReference)
            {
                return false;
            }

            if (!usingsSettings.SortUsings)
            {
                return false;
            }

            if (codeStyleSettings.CustomMembersReorderingPatterns == null)
            {
                return false;
            }

            string reorderingPatterns;
            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("StyleCop.ReSharper.Resources.ReorderingPatterns.xml"))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    reorderingPatterns = reader.ReadToEnd();
                }
            }

            if (!codeStyleSettings.CustomMembersReorderingPatterns.Equals(reorderingPatterns, StringComparison.InvariantCulture))
            {
                return false;
            }

            CodeCleanup codeCleanupInstance = CodeCleanup.GetInstance(solution);

            CodeCleanupProfile styleCopProfile = null;

            // Find the StyleCop profile
            foreach (CodeCleanupProfile profile in codeCleanupInstance.Profiles)
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

            if (!GetCodeCleanupProfileSetting<bool>(codeCleanupInstance, styleCopProfile, "CSharpFormatDocComments", null))
            {
                return false;
            }

            if (!GetCodeCleanupProfileSetting<bool>(codeCleanupInstance, styleCopProfile, "CSReorderTypeMembers", null))
            {
                return false;
            }

            // We can only check the StyleCop profile settings if a solution is loaded.
            if (solution != null)
            {
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

                if (!GetCodeCleanupProfileSetting<bool>(codeCleanupInstance, styleCopProfile, "StyleCop.Documentation", "SA1626SingleLineCommentsMustNotUseDocumentationStyleSlashes"))
                {
                    return false;
                }

                if (!GetCodeCleanupProfileSetting<bool>(codeCleanupInstance, styleCopProfile, "StyleCop.Documentation", "SA1628DocumentationTextMustBeginWithACapitalLetter"))
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

                if (!GetCodeCleanupProfileSetting<bool>(codeCleanupInstance, styleCopProfile, "StyleCop.Documentation", "SA1642ConstructorSummaryDocumentationMustBeginWithStandardText"))
                {
                    return false;
                }

                if (!GetCodeCleanupProfileSetting<bool>(codeCleanupInstance, styleCopProfile, "StyleCop.Documentation", "SA1643DestructorSummaryDocumentationMustBeginWithStandardText"))
                {
                    return false;
                }

                if (!GetCodeCleanupProfileSetting<bool>(codeCleanupInstance, styleCopProfile, "StyleCop.Documentation", "SA1644DocumentationHeadersMustNotContainBlankLines"))
                {
                    return false;
                }

                if (!GetCodeCleanupProfileSetting<bool>(codeCleanupInstance, styleCopProfile, "StyleCop.Layout", "SA1500CurlyBracketsForMultiLineStatementsMustNotShareLine"))
                {
                    return false;
                }

                if (!GetCodeCleanupProfileSetting<bool>(codeCleanupInstance, styleCopProfile, "StyleCop.Layout", "SA1509OpeningCurlyBracketsMustNotBePrecededByBlankLine"))
                {
                    return false;
                }

                if (!GetCodeCleanupProfileSetting<bool>(codeCleanupInstance, styleCopProfile, "StyleCop.Layout", "SA1510ChainedStatementBlocksMustNotBePrecededByBlankLine"))
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

                if (!GetCodeCleanupProfileSetting<bool>(codeCleanupInstance, styleCopProfile, "StyleCop.Layout", "SA1514ElementDocumentationHeaderMustBePrecededByBlankLine"))
                {
                    return false;
                }

                if (!GetCodeCleanupProfileSetting<bool>(codeCleanupInstance, styleCopProfile, "StyleCop.Layout", "SA1515SingleLineCommentMustBeProceededByBlankLine"))
                {
                    return false;
                }

                if (!GetCodeCleanupProfileSetting<bool>(codeCleanupInstance, styleCopProfile, "StyleCop.Maintainability", "SA1119StatementMustNotUseUnnecessaryParenthesis"))
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

                if (!GetCodeCleanupProfileSetting<bool>(codeCleanupInstance, styleCopProfile, "StyleCop.Readability", "SA1100DoNotPrefixCallsWithBaseUnlessLocalImplementationExists"))
                {
                    return false;
                }

                if (!GetCodeCleanupProfileSetting<bool>(codeCleanupInstance, styleCopProfile, "StyleCop.Readability", "SA1106CodeMustNotContainEmptyStatements"))
                {
                    return false;
                }

                if (!GetCodeCleanupProfileSetting<bool>(codeCleanupInstance, styleCopProfile, "StyleCop.Readability", "SA1108BlockStatementsMustNotContainEmbeddedComments"))
                {
                    return false;
                }

                if (!GetCodeCleanupProfileSetting<bool>(codeCleanupInstance, styleCopProfile, "StyleCop.Readability", "SA1109BlockStatementsMustNotContainEmbeddedRegions"))
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
        /// Commits this instance.
        /// </summary>
        public void Commit()
        {
            string newLocation = null;
            var oldLocation = StyleCopOptions.Instance.SpecifiedAssemblyPath;

            if (!this.autoDetectCheckBox.Checked)
            {
                newLocation = this.StyleCopLocationTextBox.Text;
            }

            if (newLocation != oldLocation)
            {
                MessageBox.Show("These changes may require you to restart Visual Studio before they take effect.", "StyleCop", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                StyleCopOptions.Instance.SpecifiedAssemblyPath = newLocation;
            }

            StyleCopOptions.Instance.ParsingPerformance = this.performanceTrackBar.Value;

            StyleCopOptions.Instance.InsertTextIntoDocumentation = this.insertTextCheckBox.Checked;

            StyleCopOptions.Instance.AutomaticallyCheckForUpdates = this.autoUpdateCheckBox.Checked;

            StyleCopOptions.Instance.AlwaysCheckForUpdatesWhenVisualStudioStarts = this.everyTimeRadioButton.Checked;

            if (this.autoUpdateCheckBox.Checked && !this.everyTimeRadioButton.Checked)
            {
                StyleCopOptions.Instance.DaysBetweenUpdateChecks = int.Parse(this.daysMaskedTextBox.Text);
            }

            StyleCopOptions.Instance.DashesCountInFileHeader = int.Parse(this.dashesCountMaskedTextBox.Text);

            StyleCopOptions.Instance.UseExcludeFromStyleCopSetting = this.useExcludeFromStyleCopCheckBox.Checked;

            StyleCopOptions.Instance.SuppressStyleCopAttributeJustificationText = this.justificationTextBox.Text.Trim();

            StyleCopOptions.Instance.UseSingleLineDeclarationComments = this.useSingleLineForDeclarationCommentsCheckBox.Checked;
        }

        /// <summary>
        /// Displays this instance.
        /// </summary>
        public void Display()
        {
            this.autoDetectCheckBox.Checked = string.IsNullOrEmpty(StyleCopOptions.Instance.SpecifiedAssemblyPath);

            if (this.autoDetectCheckBox.Checked)
            {
                this.ShowDetectedAssemblyLocation();
            }
            else
            {
                this.ShowSpecifiedAssemblyLocation();
            }

            this.performanceTrackBar.Value = StyleCopOptions.Instance.ParsingPerformance;
            this.insertTextCheckBox.Checked = StyleCopOptions.Instance.InsertTextIntoDocumentation;
            this.autoUpdateCheckBox.Checked = StyleCopOptions.Instance.AutomaticallyCheckForUpdates;

            this.everyTimeRadioButton.Checked = StyleCopOptions.Instance.AlwaysCheckForUpdatesWhenVisualStudioStarts;
            this.frequencyCheckRadioButton.Checked = !StyleCopOptions.Instance.AlwaysCheckForUpdatesWhenVisualStudioStarts;
            this.daysMaskedTextBox.Text = StyleCopOptions.Instance.DaysBetweenUpdateChecks.ToString();
            this.dashesCountMaskedTextBox.Text = StyleCopOptions.Instance.DashesCountInFileHeader.ToString();
            this.daysMaskedTextBox.Enabled = !this.everyTimeRadioButton.Checked;

            this.useExcludeFromStyleCopCheckBox.Checked = StyleCopOptions.Instance.UseExcludeFromStyleCopSetting;
            this.justificationTextBox.Text = StyleCopOptions.Instance.SuppressStyleCopAttributeJustificationText;

            this.useSingleLineForDeclarationCommentsCheckBox.Checked = StyleCopOptions.Instance.UseSingleLineDeclarationComments;
        }
        
        #endregion

        #region Implemented Interfaces

        #region IOptionsPage

        /// <summary>
        /// Invoked when OK button in the options dialog is pressed
        /// If the page returns 
        /// <c>False.</c>, the the options dialog won't be closed, and focus
        /// will be put into this page.
        /// </summary>
        /// <returns>
        /// Returns a boolean to represent if the page should be closed.
        /// </returns>
        public bool OnOk()
        {
            if (this.solution == null)
            {
                return true;
            }

            if (this.ValidatePage())
            {
                this.Commit();
                return true;
            }

            return false;
        }

        /// <summary>
        /// Check if the settings on the page are consistent, and page could be closed.
        /// </summary>
        /// <returns>
        /// <c>True.</c>if page data is consistent.
        /// </returns>
        public bool ValidatePage()
        {
            if (this.solution == null)
            {
                return true;
            }

            if (!this.autoDetectCheckBox.Checked)
            {
                if (!StyleCopReferenceHelper.LocationValid(this.StyleCopLocationTextBox.Text))
                {
                    var message = string.Format("Unable to find StyleCop assembly ({0}) at specified location.", StyleCopReferenceHelper.StyleCopAssemblyName);

                    MessageBox.Show(message, "StyleCop", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            if (this.daysMaskedTextBox.Enabled && (!this.daysMaskedTextBox.MaskCompleted || this.daysMaskedTextBox.Text == string.Empty))
            {
                this.toolTip.ToolTipTitle = "Invalid number";
                this.toolTip.Show("Enter a valid number.", this.daysMaskedTextBox, this.daysMaskedTextBox.Width - 16, -50, 5000);
                return false;
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
            if (this.solution != null)
            {
                this.toolTip.SetToolTip(this.dashesCountMaskedTextBox, string.Empty);
                this.toolTip.SetToolTip(this.daysMaskedTextBox, string.Empty);

                base.OnLoad(e);

                this.Display();
            }
        }
       
        /// <summary>
        /// Returns a setting for the profile, descriptor and property name supplied.
        /// </summary>
        /// <typeparam name="T">The return type.</typeparam>
        /// <param name="codeCleanup">The CodeCleanup object to use.</param>
        /// <param name="profile">The Cleanup profile to set.</param>
        /// <param name="descriptorName">The name to match.</param>
        /// <param name="propertyName">The property name to match.</param>
        /// <returns>The property value.</returns>
        private static T GetCodeCleanupProfileSetting<T>(CodeCleanup codeCleanup, CodeCleanupProfile profile, string descriptorName, string propertyName)
        {
            var cleanupOptionDescriptor = GetDescriptor(codeCleanup, descriptorName);

            if (cleanupOptionDescriptor == null)
            {
                return default(T);
            }

            if (cleanupOptionDescriptor.Type == typeof(bool) || (cleanupOptionDescriptor.Type == typeof(string) || cleanupOptionDescriptor.Type.IsEnum))
            {
                return (T)profile[cleanupOptionDescriptor];
            }

            var propertyInfo = GetPropertyInfo(cleanupOptionDescriptor, propertyName);

            return propertyInfo != null ? (T)propertyInfo.GetValue(profile[cleanupOptionDescriptor], null) : default(T);
        }

        /// <summary>
        /// Sets a CodeCleanupProfile setting for the profile, descriptor and property name passed in.
        /// </summary>
        /// <param name="codeCleanup">The CodeCleanup object to use.</param>
        /// <param name="profile">The Cleanup profile to set.</param>
        /// <param name="descriptorName">The descriptor name to match.</param>
        /// <param name="propertyName">The property name to match.</param>
        /// <param name="value">The new value.</param>
        private static void SetCodeCleanupProfileSetting(CodeCleanup codeCleanup, CodeCleanupProfile profile, string descriptorName, string propertyName, object value)
        {
            var cleanupOptionDescriptor = GetDescriptor(codeCleanup, descriptorName);

            if (cleanupOptionDescriptor == null)
            {
                return;
            }

            if (cleanupOptionDescriptor.Type == typeof(bool) || (cleanupOptionDescriptor.Type == typeof(string) || cleanupOptionDescriptor.Type.IsEnum))
            {
                profile[cleanupOptionDescriptor] = value;
                return;
            }

            var propertyInfo = GetPropertyInfo(cleanupOptionDescriptor, propertyName);

            if (propertyInfo == null)
            {
                return;
            }

            object descriptorOptionsContainer = profile[cleanupOptionDescriptor];
            propertyInfo.SetValue(descriptorOptionsContainer, value, null);
            profile[cleanupOptionDescriptor] = descriptorOptionsContainer;
        }

        /// <summary>
        /// Geta a PropertyInfo object matching the descriptor and the property name supplied.
        /// </summary>
        /// <param name="descriptor">The name to match.</param>
        /// <param name="propertyName">The property name to match.</param>
        /// <returns>A PropertyInfo matching.</returns>
        private static PropertyInfo GetPropertyInfo(CodeCleanupOptionDescriptor descriptor, string propertyName)
        {
            return (from info in descriptor.Type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    let browsableAttributes = (BrowsableAttribute[])info.GetCustomAttributes(typeof(BrowsableAttribute), false)
                    where (browsableAttributes.Length != 1) || browsableAttributes[0].Browsable
                    select info).FirstOrDefault(info => info.Name == propertyName);
        }

        /// <summary>
        /// Gets a CleanupOptionsDescriptor matching the descriptor name passed in.
        /// </summary>
        /// <param name="codeCleanup">The CodeCleanup object to use.</param>
        /// <param name="descriptorName">The name to match.</param>
        /// <returns>The CodeCleanupOptionDescriptor for the descriptor.</returns>
        private static CodeCleanupOptionDescriptor GetDescriptor(CodeCleanup codeCleanup, string descriptorName)
        {
            foreach (ICodeCleanupModule module in codeCleanup.Modules)
            {
                if (module.LanguageType == CSharpLanguageService.CSHARP)
                {
                    foreach (CodeCleanupOptionDescriptor descriptor in module.Descriptors)
                    {
                        if (descriptor.Name == descriptorName)
                        {
                            return descriptor;
                        }
                    }
                }
            }

            return null;
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

        private void AutoUpdateCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.everyTimeRadioButton.Enabled = this.autoUpdateCheckBox.Checked;
            this.frequencyCheckRadioButton.Enabled = this.autoUpdateCheckBox.Checked;
            this.daysMaskedTextBox.Enabled = this.autoUpdateCheckBox.Checked && !this.everyTimeRadioButton.Checked;
            this.daysLabel.Enabled = this.autoUpdateCheckBox.Checked;
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

        private void DaysMaskedTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            this.toolTip.Hide(this.daysMaskedTextBox);
        }

        private void EveryTimeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            this.daysMaskedTextBox.Enabled = !this.everyTimeRadioButton.Checked;
            this.toolTip.Hide(this.daysMaskedTextBox);
        }

        /// <summary>
        /// Shows the detected assembly location.
        /// </summary>
        private void ShowDetectedAssemblyLocation()
        {
            var location = StyleCopOptions.Instance.DetectStyleCopPath();

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
            var location = StyleCopOptions.Instance.SpecifiedAssemblyPath;
            this.StyleCopLocationTextBox.Text = location;
            this.BrowseButton.Enabled = true;
            this.StyleCopLocationTextBox.Enabled = true;
        }

        private void ResetFormatOptionsButton_Click(object sender, EventArgs e)
        {
            ResetCodeStyleOptions(this.dialog.DataContext.GetData(DataConstants.SOLUTION));
            MessageBox.Show(
               @"C# code style options have been set in order to fix StyleCop violations. Your UserSettings.xml will be saved when you exit Visual Studio.", @"StyleCop", MessageBoxButtons.OK);
            this.resetFormatOptionsButton.Enabled = false;
        }
        
        #endregion
    }
}