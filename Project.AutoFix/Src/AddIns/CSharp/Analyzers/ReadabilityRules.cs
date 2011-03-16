//-----------------------------------------------------------------------
// <copyright file="ReadabilityRules.cs">
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
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Xml;
    using StyleCop;
    using StyleCop.CSharp;
    using StyleCop.CSharp.CodeModel;

    /// <summary>
    /// Checks rules which improve readability in the code.
    /// </summary>
    [SourceAnalyzer(typeof(CsParser))]
    public partial class ReadabilityRules : SourceAnalyzer
    {
        #region Private Static Constants

        /// <summary>
        /// The built-in type aliases for C#.
        /// </summary>
        private readonly string[][] builtInTypes = new string[][]
        {
            new string[] { "Boolean", "System.Boolean", "bool" },
            new string[] { "Object", "System.Object", "object" },
            new string[] { "String", "System.String", "string" },
            new string[] { "Int16", "System.Int16", "short" },
            new string[] { "UInt16", "System.UInt16", "ushort" },
            new string[] { "Int32", "System.Int32", "int" },
            new string[] { "UInt32", "System.UInt32", "uint" },
            new string[] { "Int64", "System.Int64", "long" },
            new string[] { "UInt64", "System.UInt64", "ulong" },
            new string[] { "Double", "System.Double", "double" },
            new string[] { "Single", "System.Single", "float" },
            new string[] { "Byte", "System.Byte", "byte" },
            new string[] { "SByte", "System.SByte", "sbyte" },
            new string[] { "Char", "System.Char", "char" },
            new string[] { "Decimal", "System.Decimal", "decimal" }
        };

        /// <summary>
        /// The index of the short name version of the type within the builtInTypes array.
        /// </summary>
        private const int ShortNameIndex = 0;

        /// <summary>
        /// The index of the long name version of the type within the builtInTypes array.
        /// </summary>
        private const int LongNameIndex = 1;

        /// <summary>
        /// The index of the type alias within the builtInTypes array.
        /// </summary>
        private const int AliasIndex = 2;

        #endregion Private Static Constants

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the ReadabilityRules class.
        /// </summary>
        public ReadabilityRules()
        {
        }

        #endregion Public Constructors

        #region Public Override Methods

        /// <summary>
        /// Checks the methods within the given document.
        /// </summary>
        /// <param name="document">The document to check.</param>
        public override void AnalyzeDocument(ICodeDocument document)
        {
            Param.RequireNotNull(document, "document");
            this.ProcessDocument(document);
        }

        /// <summary>
        /// Automatically fixes rule violations within a code document.
        /// </summary>
        /// <param name="document">The document to fix.</param>
        public override void AutoFixDocument(ICodeDocument document)
        {
            Param.RequireNotNull(document, "document");
            this.ProcessDocument(document);
        }

        #endregion Public Methods

        #region Private Static Methods

        /// <summary>
        /// Determines whether the statement is declaring a const field or variable.
        /// </summary>
        /// <param name="assignmentOperator">The assignment operator for the variable declaration.</param>
        /// <returns>Returns true if the statement is declaring a const, false otherwise.</returns>
        private static bool IsConstVariableDeclaration(Token assignmentOperator)
        {
            Param.Ignore(assignmentOperator);

            if (assignmentOperator != null && assignmentOperator.Text == "=")
            {
                // Work backwards until we find the keyword const, or have moved past the beginning of the statement.
                Token token = assignmentOperator.FindPreviousToken();

                while (token != null)
                {
                    if (token.TokenType == TokenType.CloseParenthesis ||
                        token.TokenType == TokenType.OpenParenthesis ||
                        token.TokenType == TokenType.OpenCurlyBracket ||
                        token.TokenType == TokenType.CloseCurlyBracket ||
                        token.TokenType == TokenType.Semicolon)
                    {
                        break;
                    }
                    else if (token.TokenType == TokenType.Const)
                    {
                        return true;
                    }

                    token = token.FindPreviousToken();
                }
            }

            return false;
        }

        #endregion Private Static Methods

        #region Private Methods

        /// <summary>
        /// Analyzes or fixes the given document.
        /// </summary>
        /// <param name="document">The document.</param>
        private void ProcessDocument(ICodeDocument document)
        {
            Param.AssertNotNull(document, "document");

            CsDocument csdocument = document.AsCsDocument();

            Settings settings = new Settings();
            settings.DoNotUseRegions = this.IsRuleEnabled(document, Rules.DoNotUseRegions.ToString());
            settings.DoNotPlaceRegionsWithinElements = this.IsRuleEnabled(document, Rules.DoNotPlaceRegionsWithinElements.ToString());

            if (csdocument != null && !csdocument.Generated)
            {
                // Checks various formatting rules.
                csdocument.WalkCodeModel<Settings>(this.VisitCodeUnit, settings);

                // Check statement formatting rules.
                this.CheckStatementFormattingRulesForElement(csdocument);

                // Check the class member rules.
                this.CheckClassMemberRulesForElements(csdocument, null, null);
            }
        }

        /// <summary>
        /// Visits one code unit in the document.
        /// </summary>
        /// <param name="codeUnit">The item being visited.</param>
        /// <param name="parentElement">The parent element, if any.</param>
        /// <param name="parentStatement">The parent statement, if any.</param>
        /// <param name="parentExpression">The parent expression, if any.</param>
        /// <param name="parentClause">The parent query clause, if any.</param>
        /// <param name="parentToken">The parent token, if any.</param>
        /// <param name="settings">The settings.</param>
        /// <returns>Returns true to continue, or false to stop the walker.</returns>
        private bool VisitCodeUnit(
            CodeUnit codeUnit,
            Element parentElement,
            Statement parentStatement,
            Expression parentExpression,
            QueryClause parentClause,
            Token parentToken,
            Settings settings)
        {
            Param.AssertNotNull(codeUnit, "codeUnit");
            Param.Ignore(parentElement, parentStatement, parentExpression, parentClause, parentToken);
            Param.AssertNotNull(settings, "settings");

            if (codeUnit.CodeUnitType == CodeUnitType.Element)
            {
                return this.VisitElement((Element)codeUnit, settings);
            }
            else if (codeUnit.CodeUnitType == CodeUnitType.Expression)
            {
                return this.VisitExpression((Expression)codeUnit, parentElement);
            }
            else if (codeUnit.Is(LexicalElementType.Token))
            {
                Token token = (Token)codeUnit;
                if (token.TokenType == TokenType.Type && !token.Parent.Is(TokenType.Type))
                {
                    // Check that the type is using the built-in types, if applicable.
                    this.CheckBuiltInType((TypeToken)token, parentElement);
                }
                else if (token.TokenType == TokenType.String)
                {
                    // Check that the string is not using the empty string "" syntax.
                    this.CheckEmptyString(token, parentElement);
                }
            }
            else if (codeUnit.Is(PreprocessorType.Region))
            {
                this.CheckRegion((RegionDirective)codeUnit, parentElement, settings);
            }
            else if (codeUnit.Is(LexicalElementType.Comment))
            {
                this.CheckForEmptyComments((Comment)codeUnit, parentElement);
            }

            return !this.Cancel;
        }

        /// <summary>
        /// Checks the given element.
        /// </summary>
        /// <param name="element">The element being visited.</param>
        /// <param name="settings">The current settings.</param>
        /// <returns>Returns true to continue, or false to stop the walker.</returns>
        private bool VisitElement(Element element, Settings settings)
        {
            Param.AssertNotNull(element, "element");
            Param.Ignore(settings);

            this.CheckMethodParameters(element);
            this.CheckForRegionsInElement(element, settings);

            return true;
        }

        /// <summary>
        /// Checks the given expression.
        /// </summary>
        /// <param name="expression">The expression being visited.</param>
        /// <param name="parentElement">The parent element, if any.</param>
        /// <returns>Returns true to continue, or false to stop the walker.</returns>
        private bool VisitExpression(Expression expression, Element parentElement)
        {
            Param.AssertNotNull(expression, "expression");
            Param.AssertNotNull(parentElement, "parentElement");

            if (!parentElement.Generated)
            {
                if (expression.ExpressionType == ExpressionType.Query)
                {
                    this.CheckQueryExpression(parentElement, (QueryExpression)expression);
                }
                else if (expression.ExpressionType == ExpressionType.MethodInvocation)
                {
                    this.CheckMethodInvocationParameters(parentElement, (MethodInvocationExpression)expression);
                }
            }

            return true;
        }

        /// <summary>
        /// Checks a type to determine whether it should use one of the built-in types.
        /// </summary>
        /// <param name="type">The type to check.</param>
        /// <param name="parentElement">The parent element.</param>
        private void CheckBuiltInType(TypeToken type, Element parentElement)
        {
            Param.AssertNotNull(type, "type");
            Param.AssertNotNull(parentElement, "parentElement");

            if (!type.IsGeneric)
            {
                for (int i = 0; i < this.builtInTypes.Length; ++i)
                {
                    string[] builtInType = this.builtInTypes[i];

                    if (type.MatchTokens(builtInType[ShortNameIndex]) ||
                        type.MatchTokens("System", ".", builtInType[ShortNameIndex]))
                    {
                        // If the previous token is an equals sign, then this is a using alias directive. For example:
                        // using SomeAlias = System.String;
                        bool usingAliasDirective = false;
                        for (LexicalElement previous = type.FindPreviousLexicalElement(); previous != null; previous = previous.FindPreviousLexicalElement())
                        {
                            if (previous.LexicalElementType != LexicalElementType.Comment &&
                                previous.LexicalElementType != LexicalElementType.WhiteSpace &&
                                previous.LexicalElementType != LexicalElementType.EndOfLine)
                            {
                                if (previous.Text == "=")
                                {
                                    usingAliasDirective = true;
                                }

                                break;
                            }
                        }

                        if (!usingAliasDirective)
                        {
                            this.Violation(
                                Rules.UseBuiltInTypeAlias,
                                new ViolationContext(parentElement, type.LineNumber, builtInType[AliasIndex], builtInType[ShortNameIndex], builtInType[LongNameIndex]),
                                (c, o) =>
                                {
                                    // Insert a new type token with the correct aliased version of the type.
                                    CsDocument document = type.Document;
                                    TypeToken aliasType = document.CreateTypeToken(document.CreateLiteralToken(builtInType[AliasIndex]));
                                    document.Replace(type, aliasType);
                                });
                        }

                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Checks a string to determine whether it is using an incorrect empty string notation.
        /// </summary>
        /// <param name="text">The string to check.</param>
        /// <param name="parentElement">The parent element.</param>
        private void CheckEmptyString(Token text, Element parentElement)
        {
            Param.AssertNotNull(text, "text");
            Param.AssertNotNull(parentElement, "parentElement");
            
            Debug.Assert(text.TokenType == TokenType.String, "The token must be a string.");

            if (string.Equals(text.Text, "\"\"", StringComparison.Ordinal) ||
                string.Equals(text.Text, "@\"\"", StringComparison.Ordinal))
            {
                // Look at the previous token. If it is the 'case' keyword, then do not throw this
                // exception. It is illegal to write case: String.Empty and instead case: "" must be written.
                Token previousToken = text.FindPreviousToken();
                if (previousToken == null || (previousToken.TokenType != TokenType.Case && !IsConstVariableDeclaration(previousToken)))
                {
                    this.Violation(
                        Rules.UseStringEmptyForEmptyStrings,
                        new ViolationContext(parentElement, text.LineNumber),
                        (c, o) =>
                        {
                            // Fix the violation.
                            CsDocument document = text.Document;

                            // Create a member access expression which represents "string.Empty".
                            var stringEmpty = document.CreateMemberAccessExpression(document.CreateLiteralExpression("string"), document.CreateLiteralExpression("Empty"));

                            // The parent of the token should be a literal expression.
                            if (text.Parent != null && text.Parent.Is(ExpressionType.Literal))
                            {
                                document.Replace(text.Parent, stringEmpty);
                            }
                            else
                            {
                                Debug.Fail("Unhandled situation");
                            }
                        });
                }
            }
        }

        /// <summary>
        /// Checks a region.
        /// </summary>
        /// <param name="region">The region to check.</param>
        /// <param name="parentElement">The parent element.</param>
        /// <param name="settings">The current settings.</param>
        private void CheckRegion(RegionDirective region, Element parentElement, Settings settings)
        {
            Param.AssertNotNull(region, "region");
            Param.AssertNotNull(parentElement, "parentElement");
            Param.AssertNotNull(settings, "settings");

            if (settings.DoNotUseRegions)
            {
                if (!region.Generated && !region.IsGeneratedCodeRegion)
                {
                    // There should not be any regions in the code.
                    this.AddViolation(parentElement, region.LineNumber, Rules.DoNotUseRegions);
                }
            }
        }

        /// <summary>
        /// Processes the given element.
        /// </summary>
        /// <param name="element">The element being visited.</param>
        /// <param name="settings">The settings.</param>
        private void CheckForRegionsInElement(Element element, Settings settings)
        {
            Param.AssertNotNull(element, "element");
            Param.AssertNotNull(settings, "settings");

            // If the DoNotUseRegions setting is enabled, then skip this check as the region 
            // will be discovered during the overall regions rule check.
            if (settings.DoNotPlaceRegionsWithinElements && !settings.DoNotUseRegions && !element.Generated)
            {
                if (element.ElementType == ElementType.Method ||
                    element.ElementType == ElementType.Accessor ||
                    element.ElementType == ElementType.Constructor ||
                    element.ElementType == ElementType.Destructor ||
                    element.ElementType == ElementType.Field)
                {
                    for (RegionDirective region = element.FindFirstDescendent<RegionDirective>(); region != null; region = region.FindNextDescendentOf<RegionDirective>(element))
                    {
                        // If this token is an opening region directive, this is a violation.
                        if (!region.Generated && !region.IsGeneratedCodeRegion)
                        {
                            this.AddViolation(element, region.LineNumber, Rules.DoNotPlaceRegionsWithinElements);
                        }
                    }
                }
            }
        }

        #endregion Private Methods

        #region Private Structs

        /// <summary>
        /// The settings for rules.
        /// </summary>
        private struct Settings
        {
            /// <summary>
            /// Indicates whether the DoNotUseRegions rule is enabled.
            /// </summary>
            public bool DoNotUseRegions;

            /// <summary>
            /// Indicates whether the DoNotPlaceRegionsWithinElements rule is enabled.
            /// </summary>
            public bool DoNotPlaceRegionsWithinElements;
        }

        #endregion Private Structs
    }
}
