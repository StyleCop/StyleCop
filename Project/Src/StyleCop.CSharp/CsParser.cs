// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CsParser.cs" company="https://github.com/StyleCop">
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
//   Parses a C# code file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace StyleCop.CSharp
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Threading;

    using StyleCop.Diagnostics;

    /// <summary>
    /// Parses a C# code file.
    /// </summary>
    /// <exclude />
    [SourceParser]
    [SuppressMessage("Microsoft.Naming", "CA1706:ShortAcronymsShouldBeUppercase", Justification = "Camel case better serves in this case.")]
    public class CsParser : SourceParser
    {
        #region Constants

        /// <summary>
        /// The name of the settings property indicating whether to analyze designer files.
        /// </summary>
        internal const string AnalyzeDesignerFilesProperty = "AnalyzeDesignerFiles";

        /// <summary>
        /// The name of the settings property indicating whether to analyze generated files.
        /// </summary>
        internal const string AnalyzeGeneratedFilesProperty = "AnalyzeGeneratedFiles";

        /// <summary>
        /// The name of the settings property which contains the list of filter filters.
        /// </summary>
        internal const string GeneratedFileFiltersProperty = "GeneratedFileFilters";

        #endregion

        #region Static Fields

        /// <summary>
        /// The default collection of generated file filters.
        /// </summary>
        private static readonly string[] DefaultGeneratedFileFilters = new[] { @"\.g\.cs$", @"\.generated\.cs$", @"\.g\.i\.cs$", @"TemporaryGeneratedFile_.*\.cs$" };

        #endregion

        #region Fields

        /// <summary>
        /// Lock object for suppressions dictionary
        /// </summary>
        private readonly ReaderWriterLock suppressionsLock = new ReaderWriterLock();

        /// <summary>
        /// Stores the collection of partial elements found while parsing the files.
        /// </summary>
        private Dictionary<string, List<CsElement>> partialElements;

        /// <summary>
        /// Stores collection of suppressions for individual elements.
        /// </summary>
        private Dictionary<SuppressedRule, List<CsElement>> suppressions;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the list of partial elements found within the document.
        /// </summary>
        internal Dictionary<string, List<CsElement>> PartialElements
        {
            get
            {
                // This should only be called during a parse\analyze run.
                Debug.Assert(this.partialElements != null, "The list of partial elements should not be null");
                return this.partialElements;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Determines whether the given rule is suppressed for the given element.
        /// </summary>
        /// <param name="element">
        /// The element to check.
        /// </param>
        /// <param name="ruleCheckId">
        /// The Id of the rule to check.
        /// </param>
        /// <param name="ruleName">
        /// The Name of the rule to check.
        /// </param>
        /// <param name="ruleNamespace">
        /// The Namespace of the rule to check.
        /// </param>
        /// <returns>
        /// Returns true is the rule is suppressed; otherwise false.
        /// </returns>
        public override bool IsRuleSuppressed(ICodeElement element, string ruleCheckId, string ruleName, string ruleNamespace)
        {
            if (element != null && !string.IsNullOrEmpty(ruleCheckId) && ruleName != string.Empty && !string.IsNullOrEmpty(ruleNamespace))
            {
                SuppressedRule suppressedRule = new SuppressedRule { RuleId = ruleCheckId, RuleName = ruleName, RuleNamespace = ruleNamespace };

                this.suppressionsLock.AcquireReaderLock(Timeout.Infinite);
                try
                {
                    if (ruleCheckId != "*")
                    {
                        // See if this namespace is suppressed completely.
                        if (this.IsRuleSuppressed(element, "*", null, ruleNamespace))
                        {
                            return true;
                        }
                    }

                    List<CsElement> list = null;
                    if ((this.suppressions.Count != 0) && this.suppressions.TryGetValue(suppressedRule, out list))
                    {
                        return MatchElementWithPossibleElementsTraversingParents((CsElement)element, list);
                    }
                }
                finally
                {
                    this.suppressionsLock.ReleaseReaderLock();
                }
            }

            return false;
        }

        /// <summary>
        /// Parses the given file.
        /// </summary>
        /// <param name="sourceCode">
        /// The source code to parse.
        /// </param>
        /// <param name="passNumber">
        /// The current pass number.
        /// </param>
        /// <param name="document">
        /// The parsed representation of the file.
        /// </param>
        /// <returns>
        /// Returns false if no further analysis should be done on this file, or
        /// true if the file should be parsed again during the next pass.
        /// </returns>
        [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", 
            Justification = "Documents are returned to the caller and ultimately disposed of by the caller.")]
        public override bool ParseFile(SourceCode sourceCode, int passNumber, ref CodeDocument document)
        {
            Param.RequireNotNull(sourceCode, "sourceCode");
            Param.RequireGreaterThanOrEqualToZero(passNumber, "passNumber");
            Param.Ignore(document);

            StyleCopTrace.In(sourceCode, passNumber, document);

            // The document is parsed on the first pass. On any subsequent passes, we do not do anything.
            if (passNumber == 0)
            {
                if (this.SkipAnalysisForDocument(sourceCode))
                {
                    return false;
                }

                try
                {
                    using (TextReader reader = sourceCode.Read())
                    {
                        // Create the document.
                        if (reader == null)
                        {
                            this.AddViolation(sourceCode, 1, Rules.FileMustBeReadable);
                        }
                        else
                        {
                            // Create the lexer object for the code string.
                            CodeLexer lexer = new CodeLexer(this, sourceCode, new CodeReader(reader));

                            // Parse the document.
                            CodeParser parser = new CodeParser(this, lexer);
                            parser.ParseDocument();

                            document = parser.Document;
                        }
                    }
                }
                catch (SyntaxException syntaxex)
                {
                    this.AddViolation(syntaxex.SourceCode, syntaxex.LineNumber, Rules.SyntaxException, syntaxex.Message);
                    CsDocument csdocument = new CsDocument(sourceCode, this);
                    csdocument.FileHeader = new FileHeader(string.Empty, new CsTokenList(csdocument.Tokens), new Reference<ICodePart>(csdocument));
                    document = csdocument;
                }
            }

            return StyleCopTrace.Out(false);
        }

        /// <summary>
        /// Called each time after an analysis run is complete.
        /// </summary>
        public override void PostParse()
        {
            this.partialElements = null;
            this.suppressions = null;
        }

        /// <summary>
        /// Called each time before a new analysis run is initiated.
        /// </summary>
        public override void PreParse()
        {
            this.partialElements = new Dictionary<string, List<CsElement>>();
            this.suppressions = new Dictionary<SuppressedRule, List<CsElement>>();
        }

        /// <summary>
        /// Indicates whether to skip analysis on the given document.
        /// </summary>
        /// <param name="sourceCode">
        /// The document.
        /// </param>
        /// <returns>
        /// Returns true to skip analysis on the document.
        /// </returns>
        public override bool SkipAnalysisForDocument(SourceCode sourceCode)
        {
            Param.RequireNotNull(sourceCode, "sourceCode");

            if (sourceCode == null || sourceCode.Name == null
                || !this.FileTypes.Contains(Path.GetExtension(sourceCode.Name).Trim('.').ToUpperInvariant()))
            {
                return true;
            }

            // Get the property indicating whether to analyze designer files.
            BooleanProperty analyzeDesignerFilesProperty = this.GetSetting(sourceCode.Settings, AnalyzeDesignerFilesProperty) as BooleanProperty;

            // Default the setting to true if it does not exist.
            bool analyzeDesignerFiles = true;
            if (analyzeDesignerFilesProperty != null)
            {
                analyzeDesignerFiles = analyzeDesignerFilesProperty.Value;
            }

            if (analyzeDesignerFiles || !sourceCode.Name.EndsWith(".Designer.cs", StringComparison.OrdinalIgnoreCase))
            {
                // Get the property indicating whether to analyze generated files.
                BooleanProperty analyzerGeneratedFilesProperty = this.GetSetting(sourceCode.Settings, AnalyzeGeneratedFilesProperty) as BooleanProperty;

                // Default the setting to false if it does not exist.
                bool analyzeGeneratedFiles = false;
                if (analyzerGeneratedFilesProperty != null)
                {
                    analyzeGeneratedFiles = analyzerGeneratedFilesProperty.Value;
                }

                if (analyzeGeneratedFiles)
                {
                    // This document should be analyzed.
                    return false;
                }

                // Initialize to the default set of generated file filters.
                IEnumerable<string> filters = DefaultGeneratedFileFilters;

                // Get the file filter list for generated files.
                CollectionProperty generatedFileFilterSettings = this.GetSetting(sourceCode.Settings, GeneratedFileFiltersProperty) as CollectionProperty;

                if (generatedFileFilterSettings != null)
                {
                    filters = generatedFileFilterSettings.Values;
                }

                return Utils.InputMatchesRegExPattern(sourceCode.Path, filters);
            }

            return true;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the type of the given preprocessor symbol.
        /// </summary>
        /// <param name="preprocessor">
        /// The preprocessor symbol.
        /// </param>
        /// <param name="bodyIndex">
        /// Returns the start index of the body of the preprocessor.
        /// </param>
        /// <returns>
        /// Returns the type or null if the type cannot be determined.
        /// </returns>
        internal static string GetPreprocessorDirectiveType(Symbol preprocessor, out int bodyIndex)
        {
            Param.AssertNotNull(preprocessor, "preprocessor");
            Debug.Assert(preprocessor.SymbolType == SymbolType.PreprocessorDirective, "Expected a preprocessor directive");

            // Get the preprocessor type. This is the second word in the statement.
            bodyIndex = -1;
            int startIndex = -1;
            int endIndex = -1;

            // Move to the start of the second word.
            for (int i = 1; i < preprocessor.Text.Length; ++i)
            {
                if (char.IsLetter(preprocessor.Text[i]))
                {
                    startIndex = i;
                    break;
                }
            }

            if (startIndex == -1)
            {
                return null;
            }

            // Move to the end of the word.
            for (endIndex = startIndex; endIndex < preprocessor.Text.Length; ++endIndex)
            {
                if (!char.IsLetter(preprocessor.Text[endIndex]))
                {
                    break;
                }
            }

            --endIndex;
            if (endIndex < startIndex)
            {
                return null;
            }

            // The body start index is just past the endIndex.
            bodyIndex = endIndex + 1;

            // Get the word.
            return preprocessor.Text.Substring(startIndex, endIndex - startIndex + 1);
        }

        /// <summary>
        /// Adds a rule suppression for the given element.
        /// </summary>
        /// <param name="element">
        /// The element.
        /// </param>
        /// <param name="ruleId">
        /// The ID of the rule to suppress.
        /// </param>
        /// <param name="ruleName">
        /// The name of the rule.
        /// </param>
        /// <param name="ruleNamespace">
        /// The namespace in which the rule is contained.
        /// </param>
        internal void AddRuleSuppression(CsElement element, string ruleId, string ruleName, string ruleNamespace)
        {
            Param.AssertNotNull(element, "element");
            Param.AssertValidString(ruleId, "ruleId");
            Param.Assert(ruleId == "*" || !string.IsNullOrEmpty(ruleName), "ruleName", "Rule name is invalid.");
            Param.AssertValidString(ruleNamespace, "ruleNamespace");

            SuppressedRule suppressedRule = new SuppressedRule { RuleId = ruleId, RuleName = ruleName, RuleNamespace = ruleNamespace };

            // Need a writer lock arond this entire section to ensure thread safety of dictionary
            // and the lists contained inside.
            this.suppressionsLock.AcquireWriterLock(Timeout.Infinite);

            try
            {
                // Determine whether there is already at least one suppression for some element for this rule.
                List<CsElement> elementsContainingSuppressedRule = null;
                bool foundElementList = false;

                if (this.suppressions.Count != 0)
                {
                    foundElementList = this.suppressions.TryGetValue(suppressedRule, out elementsContainingSuppressedRule);
                }

                Debug.Assert(
                    !foundElementList || elementsContainingSuppressedRule != null, "The returned list of elements containing the suppressed rule should never be null.");

                if (!foundElementList)
                {
                    // This is the first suppression for this rule type.
                    elementsContainingSuppressedRule = new List<CsElement>();
                    this.suppressions.Add(suppressedRule, elementsContainingSuppressedRule);
                }

                elementsContainingSuppressedRule.Add(element);
            }
            finally
            {
                this.suppressionsLock.ReleaseWriterLock();
            }
        }

        /// <summary>
        /// Attempts to locate the given element within the collection of possible elements, and the parents and ancestors of those elements.
        /// </summary>
        /// <param name="element">
        /// The element to match.
        /// </param>
        /// <param name="possibleElements">
        /// The collection of possible elements to match against.
        /// </param>
        /// <returns>
        /// Returns true if a match is found; otherwise false.
        /// </returns>
        private static bool MatchElementWithPossibleElementsTraversingParents(CsElement element, IList<CsElement> possibleElements)
        {
            Param.AssertNotNull(element, "element");
            Param.AssertNotNull(possibleElements, "possibleElements");

            // Loop through each possible element using a for-style loop rather than a foreach, since this
            // is faster and this method is called very often.
            for (int i = 0; i < possibleElements.Count; ++i)
            {
                CsElement possibleMatch = possibleElements[i];

                // Walk through the element and each of its parents to see if any is a match.
                CsElement item = element;
                while (item != null)
                {
                    if (item == possibleMatch)
                    {
                        return true;
                    }

                    item = item.FindParentElement();
                }
            }

            return false;
        }

        #endregion

        /// <summary>
        /// This is used to keep track of which rules have been suppressed.
        /// </summary>
        private struct SuppressedRule
        {
            #region Fields

            /// <summary>
            /// The rule id.
            /// </summary>
            public string RuleId;

            /// <summary>
            /// The rule name.
            /// </summary>
            public string RuleName;

            /// <summary>
            /// The rule namespace.
            /// </summary>
            public string RuleNamespace;

            #endregion

            #region Public Methods and Operators

            /// <summary>
            /// Generates a unique hash code for this struct.
            /// </summary>
            /// <returns>An <see cref="int"/> of the unique HashCode.</returns>
            public override int GetHashCode()
            {
                return (this.RuleId + ":" + this.RuleNamespace + "." + this.RuleName).GetHashCode();
            }

            #endregion
        }
    }
}