//-----------------------------------------------------------------------
// <copyright file="CsParser.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.
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
//-----------------------------------------------------------------------
namespace Microsoft.StyleCop.CSharp
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.IO;
    using System.Reflection;
    using System.Text;
    using System.Threading;
    using System.Xml;
    using Microsoft.StyleCop;

    /// <summary>
    /// Parses a C# code file.
    /// </summary>
    /// <exclude />
    [SourceParser]
    [SuppressMessage("Microsoft.Naming", "CA1706:ShortAcronymsShouldBeUppercase", Justification = "Camel case better serves in this case.")]
    public partial class CsParser : SourceParser
    {
        #region Internal Constants

        /// <summary>
        /// The name of the settings property indicating whether to analyze designer files.
        /// </summary>
        internal const string AnalyzeDesignerFilesProperty = "AnalyzeDesignerFiles";

        /// <summary>
        /// The name of the settings property indicating whether to analyze generated files.
        /// </summary>
        internal const string AnalyzeGeneratedFilesProperty = "AnalyzeGeneratedFiles";

        /// <summary>
        /// An empty array of variables.
        /// </summary>
        internal static readonly IVariable[] EmptyVariableArray = new IVariable[] { };

        #endregion Internal Constants

        #region Private Fields

        /// <summary>
        /// Stores the collection of partial elements found while parsing the files.
        /// </summary>
        private Dictionary<string, List<Element>> partialElements;

        /// <summary>
        /// Stores collection of suppressions for individual elements.
        /// </summary>
        private Dictionary<int, List<Element>> suppressions;

        /// <summary>
        /// Lock object for suppressions dictionary
        /// </summary>
        private ReaderWriterLock suppressionsLock = new ReaderWriterLock();

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the CsParser class.
        /// </summary>
        public CsParser()
        {
        }

        #endregion Public Constructors

        #region Internal Properties

        /// <summary>
        /// Gets the list of partial elements found within the document.
        /// </summary>
        internal Dictionary<string, List<Element>> PartialElements
        {
            get
            {
                // This should only be called during a parse\analyze run.
                Debug.Assert(this.partialElements != null, "The list of partial elements should not be null");
                return this.partialElements;
            }
        }

        #endregion Internal Properties

        #region Public Override Methods

        /// <summary>
        /// Parses the given file.
        /// </summary>
        /// <param name="sourceCode">The source code to parse.</param>
        /// <param name="passNumber">The current pass number.</param>
        /// <param name="document">The parsed representation of the file.</param>
        /// <returns>Returns false if no further analysis should be done on this file, or
        /// true if the file should be parsed again during the next pass.</returns>
        public override bool ParseFile(SourceCode sourceCode, int passNumber, ref ICodeDocument document)
        {
            Param.RequireNotNull(sourceCode, "sourceCode");
            Param.RequireGreaterThanOrEqualToZero(passNumber, "passNumber");
            Param.Ignore(document);

            // The document is parsed on the first pass. On any subsequent passes, we do not do anything.
            if (passNumber == 0)
            {
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
                            var lexer = new CodeLexer(this, sourceCode, new CodeReader(reader));

                            // Parse the document.
                            var parser = new CodeParser(this, lexer);
                            parser.ParseDocument();

                            document = parser.Document;
                        }
                    }
                }
                catch (SyntaxException syntaxex)
                {
                    this.AddViolation(syntaxex.SourceCode, syntaxex.LineNumber, Rules.SyntaxException, syntaxex.Message);
                    var csdocument = new CsDocument(new CodeUnitProxy(), sourceCode, this);
                    document = csdocument;
                }
            }

            return false;
        }

        /// <summary>
        /// Called each time before a new analysis run is initiated.
        /// </summary>
        public override void PreParse()
        {
            this.partialElements = new Dictionary<string, List<Element>>();
            this.suppressions = new Dictionary<int, List<Element>>();
        }

        /// <summary>
        /// Called each time after a analysis run is complete.
        /// </summary>
        public override void PostParse()
        {
            this.partialElements = null;
            this.suppressions = null;
        }

        /// <summary>
        /// Indicates whether to skip analyzis on the given document.
        /// </summary>
        /// <param name="document">The document.</param>
        /// <returns>Returns true to skip analysis on the document.</returns>
        public override bool SkipAnalysisForDocument(ICodeDocument document)
        {
            Param.RequireNotNull(document, "document");

            // Get the property indicating whether to analyze designer files.
            BooleanProperty analyzeDesignerFilesProperty = this.GetSetting(
                document.Settings, CsParser.AnalyzeDesignerFilesProperty) as BooleanProperty;

            // Default the setting to true if it does not exist.
            bool analyzeDesignerFiles = true;
            if (analyzeDesignerFilesProperty != null)
            {
                analyzeDesignerFiles = analyzeDesignerFilesProperty.Value;
            }

            if (analyzeDesignerFiles || !document.SourceCode.Name.EndsWith(".Designer.cs", StringComparison.OrdinalIgnoreCase))
            {
                // Get the property indicating whether to analyze generated files.
                BooleanProperty analyzerGeneratedFilesProperty = this.GetSetting(
                    document.Settings, CsParser.AnalyzeGeneratedFilesProperty) as BooleanProperty;

                // Default the setting to false if it does not exist.
                bool analyzeGeneratedFiles = false;
                if (analyzerGeneratedFilesProperty != null)
                {
                    analyzeGeneratedFiles = analyzerGeneratedFilesProperty.Value;
                }

                if (analyzeGeneratedFiles || 
                    (!document.SourceCode.Name.EndsWith(".g.cs", StringComparison.OrdinalIgnoreCase) &&
                     !document.SourceCode.Name.EndsWith(".generated.cs", StringComparison.OrdinalIgnoreCase)))
                {
                    // This document should be analyzed.
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Determines whether the given rule is suppressed for the given element.
        /// </summary>
        /// <param name="element">The element to check.</param>
        /// <param name="rule">The rule to check.</param>
        /// <returns>Returns true is the rule is suppressed; otherwise false.</returns>
        public override bool IsRuleSuppressed(ICodeElement element, Rule rule)
        {
            Param.Ignore(element, rule);

            if (element != null && rule != null)
            {
                // If the lock throws we are okay with it unwinding
                this.suppressionsLock.AcquireReaderLock(Timeout.Infinite);

                try
                {
                    // First, check whether the entire rule namespace is suppressed for this element.
                    if (this.IsRuleSuppressed(element, rule.UniqueRuleNamespaceId))
                    {
                        return true;
                    }

                    // Now determine whether the specific rule is suppressed.
                    if (this.IsRuleSuppressed(element, rule.UniqueRuleId))
                    {
                        return true;
                    }
                }
                finally
                {
                    this.suppressionsLock.ReleaseReaderLock();
                }
            }

            return false;
        }

        #endregion Public Override Methods

        #region Internal Static Methods
 
        /// <summary>
        /// Gets the type of the given preprocessor symbol.
        /// </summary>
        /// <param name="preprocessor">The preprocessor symbol.</param>
        /// <param name="bodyIndex">Returns the start index of the body of the preprocessor.</param>
        /// <returns>Returns the type or null if the type cannot be determined.</returns>
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

        #endregion Internal Static Methods

        #region Internal Methods

        /// <summary>
        /// Adds a rule suppression for the given element.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="ruleId">The ID of the rule to suppress.</param>
        /// <param name="ruleName">The name of the rule.</param>
        /// <param name="ruleNamespace">The namespace in which the rule is contained.</param>
        internal void AddRuleSuppression(Element element, string ruleId, string ruleName, string ruleNamespace)
        {
            Param.AssertNotNull(element, "element");
            Param.AssertValidString(ruleId, "ruleId");
            Param.Assert(ruleId == "*" || !string.IsNullOrEmpty(ruleName), "ruleName", "Rule name is invalid.");
            Param.AssertValidString(ruleNamespace, "ruleNamespace");

            // Need a writer lock arond this entire section to ensure thread safety of dictionary
            // and the lists contained inside.
            this.suppressionsLock.AcquireWriterLock(Timeout.Infinite);

            try
            {
                // Generate the hashcode for the rule being suppressed.
                int uniqueRuleID = Rule.GenerateUniqueId(ruleNamespace, ruleId, ruleName);

                // Determine whether there is already at least one suppression for some element for this rule.
                List<Element> elementsContainingSuppressedRule = null;
                bool foundElementList = false;

                if (this.suppressions.Count != 0)
                {
                    foundElementList = this.suppressions.TryGetValue(uniqueRuleID, out elementsContainingSuppressedRule);
                }

                Debug.Assert(
                    !foundElementList || elementsContainingSuppressedRule != null,
                    "The returned list of elements containing the suppressed rule should never be null.");

                if (!foundElementList)
                {
                    // This is the first suppression for this rule type.
                    elementsContainingSuppressedRule = new List<Element>();
                    this.suppressions.Add(uniqueRuleID, elementsContainingSuppressedRule);
                }

                elementsContainingSuppressedRule.Add(element);
            }
            finally
            {
                this.suppressionsLock.ReleaseWriterLock();
            }
        }

        #endregion Internal Methods

        #region Private Static Methods

        /// <summary>
        /// Attempts to locate the given element within the collection of possible elements, and the parents and ancestors of those elements.
        /// </summary>
        /// <param name="element">The element to match.</param>
        /// <param name="possibleElements">The collection of possible elements to match against.</param>
        /// <returns>Returns true if a match is found; otherwise false.</returns>
        private static bool MatchElementWithPossibleElementsTraversingParents(Element element, IEnumerable<Element> possibleElements)
        {
            Param.AssertNotNull(element, "element");
            Param.AssertNotNull(possibleElements, "possibleElements");

            foreach (Element possibleMatch in possibleElements)
            {
                Element item = element;
                while (item != null)
                {
                    if (item == possibleMatch)
                    {
                        return true;
                    }

                    item = item.FindParent<Element>();
                }
            }

            return false;
        }

        #endregion Private Static Methods

        #region Private Methods

        /// <summary>
        /// Determines whether the given element contains a suppression for the given rule.
        /// </summary>
        /// <param name="element">The element to check.</param>
        /// <param name="ruleHashCode">The rule hash code.</param>
        /// <returns>Returns true if the rule is suppressed; false otherwise.</returns>
        private bool IsRuleSuppressed(ICodeElement element, int ruleHashCode)
        {
            Param.AssertNotNull(element, "element");
            Param.Ignore(ruleHashCode);

            List<Element> elementsContainingSuppressedRule = null;

            if (this.suppressions.Count != 0 && this.suppressions.TryGetValue(ruleHashCode, out elementsContainingSuppressedRule))
            {
                Debug.Assert(elementsContainingSuppressedRule != null, "The returned list of elements containing the suppressed rule should never be null.");
                return MatchElementWithPossibleElementsTraversingParents((Element)element, elementsContainingSuppressedRule);
            }

            return false;
        }

        #endregion Private Methods
    }
}
