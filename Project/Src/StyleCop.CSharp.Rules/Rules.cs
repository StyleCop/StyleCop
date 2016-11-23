// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Rules.cs" company="https://github.com/StyleCop">
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
//   The list of rules triggered by this module.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    using System;

    /// <summary>
    /// The list of rules triggered by this module.
    /// </summary>
    internal enum Rules
    {
        /// <summary>
        /// The element does not have an access modifier.
        /// </summary>
        AccessModifierMustBeDeclared, 

        /// <summary>
        /// The curly bracket must be on a line by itself, unless the entire statement is on a single line.
        /// </summary>
        CurlyBracketsForMultiLineStatementsMustNotShareLine, 

        /// <summary>
        /// The statement wrapped in curly brackets must not be entirely on the same line.
        /// </summary>
        StatementMustNotBeOnSingleLine, 

        /// <summary>
        /// The {0} must not be placed entirely on the same line.
        /// </summary>
        ElementMustNotBeOnSingleLine, 

        /// <summary>
        /// The body of the statement must be wrapped in curly brackets.
        /// </summary>
        CurlyBracketsMustNotBeOmitted, 

        /// <summary>
        /// If an accessor is completely on a single line, its sibling accessors must also each be on a single line.
        /// </summary>
        AllAccessorsMustBeMultiLineOrSingleLine, 

        /// <summary>
        /// The Xml header is missing.
        /// </summary>
        ElementsMustBeDocumented, 

        /// <summary>
        /// The Xml header is missing from a partial element.
        /// </summary>
        PartialElementsMustBeDocumented, 

        /// <summary>
        /// The header is missing the summary tag.
        /// </summary>
        ElementDocumentationMustHaveSummary, 

        /// <summary>
        /// The header is missing the summary tag.
        /// </summary>
        PartialElementDocumentationMustHaveSummary, 

        /// <summary>
        /// The summary tag is empty.
        /// </summary>
        ElementDocumentationMustHaveSummaryText, 

        /// <summary>
        /// The summary tag is empty.
        /// </summary>
        PartialElementDocumentationMustHaveSummaryText, 

        /// <summary>
        /// The element has parameters but the header does not contain <c>param</c> tags.
        /// </summary>
        ElementParametersMustBeDocumented, 

        /// <summary>
        /// The header has a  <c>param</c> tag with no name.
        /// </summary>
        ElementParameterDocumentationMustDeclareParameterName, 

        /// <summary>
        /// The  <c>param</c> tag is empty.
        /// </summary>
        ElementParameterDocumentationMustHaveText, 

        /// <summary>
        /// The method does not return void but the header does not have a returns tag.
        /// </summary>
        ElementReturnValueMustBeDocumented, 

        /// <summary>
        /// The returns tag is empty.
        /// </summary>
        ElementReturnValueDocumentationMustHaveText, 

        /// <summary>
        /// The method returns void but the header contains a returns tag.
        /// </summary>
        VoidReturnValueMustNotBeDocumented, 

        /// <summary>
        /// The partial element has generic types but the Xml header has no '<c>typeparam</c>' tags.
        /// </summary>
        GenericTypeParametersMustBeDocumented, 

        /// <summary>
        /// The documentation header must contain <c>typeparam</c> tags matching the generic types for the {0}.
        /// </summary>
        GenericTypeParametersMustBeDocumentedPartialClass, 

        /// <summary>
        /// The element's generic type parameters do not match the '<c>typeparam</c>' tags in the header.
        /// </summary>
        GenericTypeParameterDocumentationMustMatchTypeParameters, 

        /// <summary>
        /// The Xml header has a '<c>typeparam</c>' tag with no 'name' attribute.
        /// </summary>
        GenericTypeParameterDocumentationMustDeclareParameterName, 

        /// <summary>
        /// The element header '<c>typeparam</c>' tag is empty for the '{0}' item.
        /// </summary>
        GenericTypeParameterDocumentationMustHaveText, 

        /// <summary>
        /// The summary tag has the default text generated by Visual Studio.
        /// </summary>
        ElementDocumentationMustNotHaveDefaultSummary, 

        /// <summary>
        /// The header is invalid Xml.
        /// </summary>
        DocumentationMustContainValidXml, 

        /// <summary>
        /// The <see cref="Enum"/> sub-item has no header.
        /// </summary>
        EnumerationItemsMustBeDocumented, 

        /// <summary>
        /// The method parameters do not match those in the header.
        /// </summary>
        ElementParameterDocumentationMustMatchElementParameters, 

        /// <summary>
        /// The property is missing a value tag.
        /// </summary>
        PropertyDocumentationMustHaveValue, 

        /// <summary>
        /// The property has a value tag but it has no text.
        /// </summary>
        PropertyDocumentationMustHaveValueText, 

        /// <summary>
        /// The text in a documentation string must not be empty.
        /// </summary>
        DocumentationTextMustNotBeEmpty, 

        /// <summary>
        /// Documentation text must end with a period.
        /// </summary>
        DocumentationTextMustEndWithAPeriod, 

        /// <summary>
        /// Documentation text must begin with a capital letter.
        /// </summary>
        DocumentationTextMustBeginWithACapitalLetter, 

        /// <summary>
        /// Documentation text must contain whitespace.
        /// </summary>
        DocumentationTextMustContainWhitespace, 

        /// <summary>
        /// Documentation text must consist of a certain percentage of characters.
        /// </summary>
        DocumentationMustMeetCharacterPercentage, 

        /// <summary>
        /// Documentation text must be a certain length.
        /// </summary>
        DocumentationTextMustMeetMinimumCharacterLength, 

        /// <summary>
        /// The documentation text within the constructor's summary tag must begin with the text.
        /// </summary>
        ConstructorSummaryDocumentationMustBeginWithStandardText, 

        /// <summary>
        /// The documentation text within the destructor's summary tag must begin with the text.
        /// </summary>
        DestructorSummaryDocumentationMustBeginWithStandardText, 

        /// <summary>
        /// Verifies that a documentation header does not contain blank lines.
        /// </summary>
        DocumentationHeadersMustNotContainBlankLines, 

        /// <summary>
        /// Verifies that an included documentation header file can be loaded.
        /// </summary>
        IncludedDocumentationFileDoesNotExist, 

        /// <summary>
        /// Verifies that an included documentation tag's XPath expression is valid.
        /// </summary>
        IncludedDocumentationXPathDoesNotExist, 

        /// <summary>
        /// Verifies that an 'include' tag contains a valid file and path attribute.
        /// </summary>
        IncludeNodeDoesNotContainValidFileAndPath, 

        /// <summary>
        /// Verifies that an <c>includedoc</c> tag is not used when the class does not inherit from a base class.
        /// </summary>
        InheritDocMustBeUsedWithInheritingClass, 

        /// <summary>
        /// The property's summary tag starts with invalid text.
        /// </summary>
        PropertySummaryDocumentationMustMatchAccessors, 

        /// <summary>
        /// The property only has a get accessor but the summary starts with 'gets or sets'.
        /// </summary>
        PropertySummaryDocumentationMustOmitSetAccessorWithRestrictedAccess, 

        /// <summary>
        /// The element's documentation header contains two or more identical strings.
        /// </summary>
        ElementDocumentationMustNotBeCopiedAndPasted, 

        /// <summary>
        /// A single line comment begins with a triple slash like an Xml header.
        /// </summary>
        SingleLineCommentsMustNotUseDocumentationStyleSlashes, 

        /// <summary>
        /// There is no file header.
        /// </summary>
        FileMustHaveHeader, 

        /// <summary>
        /// The copyright node is missing.
        /// </summary>
        FileHeaderMustShowCopyright, 

        /// <summary>
        /// The copyright tag is empty.
        /// </summary>
        FileHeaderMustHaveCopyrightText, 

        /// <summary>
        /// The copyright tag must match the required value.
        /// </summary>
        FileHeaderCopyrightTextMustMatch, 

        /// <summary>
        /// The copyright's file attribute is missing.
        /// </summary>
        FileHeaderMustContainFileName, 

        /// <summary>
        /// The copyright's file attribute does not contain the name of the file.
        /// </summary>
        FileHeaderFileNameDocumentationMustMatchFileName, 

        /// <summary>
        /// The copyright's company tag is missing or empty.
        /// </summary>
        FileHeaderMustHaveValidCompanyText, 

        /// <summary>
        /// The company text must match.
        /// </summary>
        FileHeaderCompanyNameTextMustMatch, 

        /// <summary>
        /// The summary tag is missing or empty.
        /// </summary>
        FileHeaderMustHaveSummary, 

        /// <summary>
        /// A this prefix is missing.
        /// </summary>
        ThisMissing, 

        /// <summary>
        /// A base prefix was used when it should be this.
        /// </summary>
        BaseUsed, 

        /// <summary>
        /// A constant field starts with a lower case letter.
        /// </summary>
        ConstFieldNamesMustBeginWithUpperCaseLetter, 

        /// <summary>
        /// Readonly variables that are not declared private must start with an upper case letter.
        /// </summary>
        NonPrivateReadonlyFieldsMustBeginWithUpperCaseLetter, 

        /// <summary>
        /// A variable starts with an upper case letter.
        /// </summary>
        AccessibleFieldsMustBeginWithUpperCaseLetter, 

        /// <summary>
        /// A variable starts with an upper case letter.
        /// </summary>
        FieldNamesMustBeginWithLowerCaseLetter, 

        /// <summary>
        /// A variable name contains Hungarian notation.
        /// </summary>
        FieldNamesMustNotUseHungarianNotation, 

        /// <summary>
        /// A variable name contains a m_ or s_ prefix.
        /// </summary>
        VariableNamesMustNotBePrefixed, 

        /// <summary>
        /// A word that should start with a lower-case letter start with an upper-case letter.
        /// </summary>
        ElementMustBeginWithLowerCaseLetter, 

        /// <summary>
        /// A word that should start with an upper-case letter start with a lower-case letter.
        /// </summary>
        ElementMustBeginWithUpperCaseLetter, 

        /// <summary>
        /// An interface name does not begin with I.
        /// </summary>
        InterfaceNamesMustBeginWithI, 

        /// <summary>
        /// A variable name starts with an underscore.
        /// </summary>
        FieldNamesMustNotBeginWithUnderscore, 

        /// <summary>
        /// A variable name contains an underscore.
        /// </summary>
        FieldNamesMustNotContainUnderscore, 

        /// <summary>
        /// Multiple blank lines in a row.
        /// </summary>
        CodeMustNotContainMultipleBlankLinesInARow, 

        /// <summary>
        /// Blank line before an opening curly bracket.
        /// </summary>
        ClosingCurlyBracketsMustNotBePrecededByBlankLine, 

        /// <summary>
        /// Blank line before an opening curly bracket.
        /// </summary>
        OpeningCurlyBracketsMustNotBePrecededByBlankLine, 

        /// <summary>
        /// Blank line after an opening curly bracket.
        /// </summary>
        OpeningCurlyBracketsMustNotBeFollowedByBlankLine, 

        /// <summary>
        /// A closing curly bracket is not followed by a blank line.
        /// </summary>
        ClosingCurlyBracketMustBeFollowedByBlankLine, 

        /// <summary>
        /// No blank line appears before a single-line comment.
        /// </summary>
        SingleLineCommentMustBePrecededByBlankLine, 

        /// <summary>
        /// Adjacent elements must be separated by a blank line.
        /// </summary>
        ElementsMustBeSeparatedByBlankLine, 

        /// <summary>
        /// No blank line appears before an Xml header.
        /// </summary>
        ElementDocumentationHeaderMustBePrecededByBlankLine, 

        /// <summary>
        /// A blank line appears after an Xml header.
        /// </summary>
        ElementDocumentationHeadersMustNotBeFollowedByBlankLine, 

        /// <summary>
        /// A blank line appears after an else, catch, or finally statement.
        /// </summary>
        ChainedStatementBlocksMustNotBePrecededByBlankLine, 

        /// <summary>
        /// A single-line comment must not be followed by a blank line. 
        /// </summary>
        SingleLineCommentsMustNotBeFollowedByBlankLine, 

        /// <summary>
        /// A blank line appears before a while/do statement.
        /// </summary>
        WhileDoFooterMustNotBePrecededByBlankLine, 

        /// <summary>
        /// Elements in the wrong order.
        /// </summary>
        ElementsMustAppearInTheCorrectOrder, 

        /// <summary>
        /// Partial elements in the wrong order.
        /// </summary>
        PartialElementsMustDeclareAccess, 

        /// <summary>
        /// Access modifiers in the wrong order.
        /// </summary>
        ElementsMustBeOrderedByAccess, 

        /// <summary>
        /// Static elements in the wrong order.
        /// </summary>
        StaticElementsMustAppearBeforeInstanceElements, 

        /// <summary>
        /// Multiple classes at the top level of a file.
        /// </summary>
        FileMayOnlyContainASingleClass, 

        /// <summary>
        /// Multiple namespaces within a file.
        /// </summary>
        FileMayOnlyContainASingleNamespace, 

        /// <summary>
        /// A Code Analysis suppression must contain a non-empty justification 
        /// describing the reason for the suppression.
        /// </summary>
        CodeAnalysisSuppressionMustHaveJustification, 

        /// <summary>
        /// A call to Debug.Assert must provide a message in the second parameter describing 
        /// the reason for the assert.
        /// </summary>
        DebugAssertMustProvideMessageText, 

        /// <summary>
        /// A call to Debug.Fail must provide a message in the first parameter describing 
        /// the reason for the failure.
        /// </summary>
        DebugFailMustProvideMessageText, 

        /// <summary>
        /// Insert parenthesis within the arithmetic expression to declare the operator precedence.
        /// </summary>
        ArithmeticExpressionsMustDeclarePrecedence, 

        /// <summary>
        /// Insert parenthesis within the conditional AND and OR expressions to declare the operator precedence.
        /// </summary>
        ConditionalExpressionsMustDeclarePrecedence, 

        /// <summary>
        /// Verifies that the code does not contain empty elements or statements which can be safely removed.
        /// </summary>
        RemoveUnnecessaryCode, 

        /// <summary>
        /// Verifies that parenthesis are removed from anonymous methods when there are no method parameters.
        /// </summary>
        RemoveDelegateParenthesisWhenPossible, 

        /// <summary>
        /// Publicly exposed fields.
        /// </summary>
        FieldsMustBePrivate, 

        /// <summary>
        /// Constant elements in the wrong order.
        /// </summary>
        ConstantsMustAppearBeforeFields, 

        /// <summary>
        /// The spacing around the keyword '{0}' is invalid.
        /// </summary>
        KeywordsMustBeSpacedCorrectly, 

        /// <summary>
        /// Invalid spacing around a comma.
        /// </summary>
        CommasMustBeSpacedCorrectly, 

        /// <summary>
        /// Invalid spacing around a semicolon.
        /// </summary>
        SemicolonsMustBeSpacedCorrectly, 

        /// <summary>
        /// Invalid spacing around a symbol.
        /// </summary>
        SymbolsMustBeSpacedCorrectly, 

        /// <summary>
        /// Invalid spacing around an open parenthesis.
        /// </summary>
        OpeningParenthesisMustBeSpacedCorrectly, 

        /// <summary>
        /// Invalid spacing around a close parenthesis.
        /// </summary>
        ClosingParenthesisMustBeSpacedCorrectly, 

        /// <summary>
        /// Invalid spacing around an open square bracket.
        /// </summary>
        OpeningSquareBracketsMustBeSpacedCorrectly, 

        /// <summary>
        /// Invalid spacing around a close square bracket.
        /// </summary>
        ClosingSquareBracketsMustBeSpacedCorrectly, 

        /// <summary>
        /// Invalid spacing around an open curly bracket.
        /// </summary>
        OpeningCurlyBracketsMustBeSpacedCorrectly, 

        /// <summary>
        /// Invalid spacing around a close curly bracket.
        /// </summary>
        ClosingCurlyBracketsMustBeSpacedCorrectly, 

        /// <summary>
        /// Invalid spacing around the opening bracket of a generic statement.
        /// </summary>
        OpeningGenericBracketsMustBeSpacedCorrectly, 

        /// <summary>
        /// Invalid spacing around the closing bracket of a generic statement.
        /// </summary>
        ClosingGenericBracketsMustBeSpacedCorrectly, 

        /// <summary>
        /// Invalid spacing around an open attribute bracket.
        /// </summary>
        OpeningAttributeBracketsMustBeSpacedCorrectly, 

        /// <summary>
        /// Invalid spacing around a close attribute bracket.
        /// </summary>
        ClosingAttributeBracketsMustBeSpacedCorrectly, 

        /// <summary>
        /// A <see cref="Nullable"/> type symbol should not be preceded by whitespace.
        /// </summary>
        NullableTypeSymbolsMustNotBePrecededBySpace, 

        /// <summary>
        /// Invalid spacing around a member access symbol.
        /// </summary>
        MemberAccessSymbolsMustBeSpacedCorrectly, 

        /// <summary>
        /// Invalid spacing around a decrement or increment symbol.
        /// </summary>
        IncrementDecrementSymbolsMustBeSpacedCorrectly, 

        /// <summary>
        /// Invalid spacing around a negative sign.
        /// </summary>
        NegativeSignsMustBeSpacedCorrectly, 

        /// <summary>
        /// Invalid spacing around a positive sign.
        /// </summary>
        PositiveSignsMustBeSpacedCorrectly, 

        /// <summary>
        /// Invalid spacing around the increment or decrement symbol.
        /// </summary>
        DereferenceAndAccessOfSymbolsMustBeSpacedCorrectly, 

        /// <summary>
        /// Invalid spacing around a colon.
        /// </summary>
        ColonsMustBeSpacedCorrectly, 

        /// <summary>
        /// The code contains tabs, which is not allowed.
        /// </summary>
        TabsMustNotBeUsed, 

        /// <summary>
        /// There are multiple spaces in a row.
        /// </summary>
        CodeMustNotContainMultipleWhitespaceInARow, 

        /// <summary>
        /// There should be no space between the new keyword and the opening square bracket in 
        /// an implicitly typed array allocation.
        /// </summary>
        CodeMustNotContainSpaceAfterNewKeywordInImplicitlyTypedArrayAllocation, 

        /// <summary>
        /// Too many parenthesis.
        /// </summary>
        StatementMustNotUseUnnecessaryParenthesis, 

        /// <summary>
        /// The preprocessor keyword must be followed by a space.
        /// </summary>
        PreprocessorKeywordsMustNotBePrecededBySpace, 

        /// <summary>
        /// The operator keyword must be followed by a space.
        /// </summary>
        OperatorKeywordMustBeFollowedBySpace, 

        /// <summary>
        /// The comment must start with a single space.
        /// </summary>
        SingleLineCommentsMustBeginWithSingleSpace, 

        /// <summary>
        /// The documentation header line must start with a single space.
        /// </summary>
        DocumentationLinesMustBeginWithSingleSpace, 

        /// <summary>
        /// A using statement is outside of a namespace.
        /// </summary>
        UsingDirectivesMustBePlacedWithinNamespace, 

        /// <summary>
        /// The open parenthesis is not on the same line as the method call.
        /// </summary>
        OpeningParenthesisMustBeOnDeclarationLine, 

        /// <summary>
        /// The closing parenthesis is not on the same line as the last parameter.
        /// </summary>
        ClosingParenthesisMustBeOnLineOfLastParameter, 

        /// <summary>
        /// The closing parenthesis or bracket must be placed on the same line as the opening parenthesis or bracket.
        /// </summary>
        ClosingParenthesisMustBeOnLineOfOpeningParenthesis, 

        /// <summary>
        /// The parameter spans multiple lines.
        /// </summary>
        ParameterMustNotSpanMultipleLines, 

        /// <summary>
        /// The comma must be on the same line as the previous parameter.
        /// </summary>
        CommaMustBeOnSameLineAsPreviousParameter, 

        /// <summary>
        /// The parameter list must be on the same line or the next line as the method name.
        /// </summary>
        ParameterListMustFollowDeclaration, 

        /// <summary>
        /// The parameter must begin on the line after the previous parameter.
        /// </summary>
        ParameterMustFollowComma, 

        /// <summary>
        /// If there are multiple parameters and each is on it's own line, they cannot start on the same 
        /// line as the method declaration or name.
        /// </summary>
        SplitParametersMustStartOnLineAfterDeclaration, 

        /// <summary>
        /// All parameters must be on the same line, or each parameter must be on a separate line.
        /// </summary>
        ParametersMustBeOnSameLineOrSeparateLines, 

        /// <summary>
        /// The statement is empty.
        /// </summary>
        CodeMustNotContainEmptyStatements, 

        /// <summary>
        /// A line may only contain a single statement.
        /// </summary>
        CodeMustNotContainMultipleStatementsOnOneLine, 

        /// <summary>
        /// A block statement may not contain a comment embedded within the statement.
        /// </summary>
        BlockStatementsMustNotContainEmbeddedComments, 

        /// <summary>
        /// A block statement may not contain a region embedded within the statement.
        /// </summary>
        BlockStatementsMustNotContainEmbeddedRegions, 

        /// <summary>
        /// The call to {0} can only use 'base.' if there is a local override and the caller is explicitly calling the base implementation.
        /// </summary>
        DoNotPrefixCallsWithBaseUnlessLocalImplementationExists, 

        /// <summary>
        /// The class member {0} does not start with 'this'.
        /// </summary>
        PrefixLocalCallsWithThis, 

        /// <summary>
        /// The {0} keyword must come before the {1} keyword in the element declaration.
        /// </summary>
        DeclarationKeywordsMustFollowOrder, 

        /// <summary>
        /// The keyword 'protected' must come before 'internal'.
        /// </summary>
        ProtectedMustComeBeforeInternal, 

        /// <summary>
        /// Verifies that all using directives within the System namespace are placed before all other using directives.
        /// </summary>
        SystemUsingDirectivesMustBePlacedBeforeOtherUsingDirectives, 

        /// <summary>
        /// Verifies that all using alias directives are placed after all using namespace directives.
        /// </summary>
        UsingAliasDirectivesMustBePlacedAfterOtherUsingDirectives, 

        /// <summary>
        /// Verifies that using directives are sorted alphabetically by the namespaces.
        /// </summary>
        UsingDirectivesMustBeOrderedAlphabeticallyByNamespace, 

        /// <summary>
        /// Verifies that using alias directives are sorted alphabetically by the alias names.
        /// </summary>
        UsingAliasDirectivesMustBeOrderedAlphabeticallyByAliasName, 

        /// <summary>
        /// Verifies that get accessors are placed before set accessors within properties and indexers.
        /// </summary>
        PropertyAccessorsMustFollowOrder, 

        /// <summary>
        /// Verifies that add accessors are placed before remove accessors within events.
        /// </summary>
        EventAccessorsMustFollowOrder, 

        /// <summary>
        /// Empty comments are not allowed.
        /// </summary>
        CommentsMustContainText, 

        /// <summary>
        /// The query clause must begin on the line following the previous clause.
        /// </summary>
        QueryClauseMustFollowPreviousClause, 

        /// <summary>
        /// All query clauses must be placed on the same line, or each clause must begin on a new line.
        /// </summary>
        QueryClausesMustBeOnSeparateLinesOrAllOnOneLine, 

        /// <summary>
        /// A query clause must begin on a new line if the previous clause spans multiple lines.
        /// </summary>
        QueryClauseMustBeginOnNewLineWhenPreviousClauseSpansMultipleLines, 

        /// <summary>
        /// If a query clause spans multiple lines, it must begin on its own line.
        /// </summary>
        QueryClausesSpanningMultipleLinesMustBeginOnOwnLine, 

        /// <summary>
        /// Enforces the use of the built-in <see cref="bool"/> keyword rather than the type Boolean or System.Boolean.
        /// </summary>
        UseBuiltInTypeAlias, 

        /// <summary>
        /// Prohibits the use of the <c>var</c> type outside of query expressions and anonymous types.
        /// </summary>
        AvoidVarType, 

        /// <summary>
        /// Enforces the use of the shorthand for a <see cref="Nullable"/> type.
        /// </summary>
        UseShorthandForNullableTypes, 

        /// <summary>
        /// Use the String.Empty property rather than "".
        /// </summary>
        UseStringEmptyForEmptyStrings, 

        /// <summary>
        /// Prevents the use of regions within code elements, which limits code readability.
        /// </summary>
        DoNotPlaceRegionsWithinElements, 

        /// <summary>
        /// Prevents the use of regions anywhere within the code.
        /// </summary>
        DoNotUseRegions, 

        /// <summary>
        /// The code must not contain blank lines at the start of the file.
        /// </summary>
        CodeMustNotContainBlankLinesAtStartOfFile, 

        /// <summary>
        /// The code must not contain blank lines at the end of the file.
        /// </summary>
        CodeMustNotContainBlankLinesAtEndOfFile, 

        /// <summary>
        /// Prevents the use of parenthesis on attribute constructors when they are not required.
        /// </summary>
        AttributeConstructorMustNotUseUnnecessaryParenthesis, 

        /// <summary>
        /// Ensures the file header filename attribute matches the name of the type in the file.
        /// </summary>
        FileHeaderFileNameDocumentationMustMatchTypeName, 

        /// <summary>
        /// Validates that all static readonly elements are placed before all static non-readonly elements of the same type.
        /// </summary>
        StaticReadonlyElementsMustAppearBeforeStaticNonReadonlyElements, 

        /// <summary>
        /// Validates that all non-static readonly elements are placed before non-static non-readonly elements of the same type.
        /// </summary>
        InstanceReadonlyElementsMustAppearBeforeInstanceNonReadonlyElements, 

        /// <summary>
        /// Validates that C++ style assignment proof comparison where value goes first is not used.
        /// </summary>       
        UseReadableConditions,

        /// <summary>
        /// Verifies that calls to members are prefixed with the correct notation.
        /// </summary>
        PrefixCallsCorrectly, 

        /// <summary>
        /// A static readonly variable starts with an upper case letter.
        /// </summary>
        StaticReadonlyFieldsMustBeginWithUpperCaseLetter, 

        /// <summary>
        /// An elements documentation must be spelled correctly.
        /// </summary>
        ElementDocumentationMustBeSpelledCorrectly,

        /// <summary>
        /// Null conditional operator must not be split by new row or space.
        /// </summary>
        DoNotSplitNullConditionalOperators,

        /// <summary>
        /// Verifies that all using static directives are placed after using namespace directives.
        /// </summary>
        UsingStaticDirectivesMustBePlacedAtTheCorrectLocation,
    }
}