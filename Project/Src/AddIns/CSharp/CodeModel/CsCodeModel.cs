//-----------------------------------------------------------------------
// <copyright file="CsCodeModel.cs" company="Microsoft">
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
////namespace Microsoft.StyleCop.CSharp.CodeModel
////{
////    using System;
////    using System.Collections;
////    using System.Collections.Generic;
////    using System.Collections.ObjectModel;
////    using System.Diagnostics;
////    using System.Diagnostics.CodeAnalysis;
////    using System.Globalization;
////    using System.IO;
////    using System.Reflection;
////    using System.Text;
////    using System.Threading;
////    using System.Xml;

////    /// <summary>
////    /// Parses a C# code file.
////    /// </summary>
////    [SuppressMessage("Microsoft.Naming", "CA1706:ShortAcronymsShouldBeUppercase", Justification = "Camel case better serves in this case.")]
////    public partial class CsCodeModel
////    {
////        #region Internal Constants

////        /// <summary>
////        /// An empty array of variables.
////        /// </summary>
////        internal static readonly IVariable[] EmptyVariableArray = new IVariable[] { };

////        #endregion Internal Constants

////        #region Public Constructors

////        /// <summary>
////        /// Initializes a new instance of the CsCodeModel class.
////        /// </summary>
////        public CsCodeModel()
////        {
////        }

////        #endregion Public Constructors

////        #region Public Methods

////        /// <summary>
////        /// Parses the given file.
////        /// </summary>
////        /// <param name="sourceCode">The source code to parse.</param>
////        /// <param name="passNumber">The current pass number.</param>
////        /// <param name="document">The parsed representation of the file.</param>
////        /// <returns>Returns false if no further analysis should be done on this file, or
////        /// true if the file should be parsed again during the next pass.</returns>
////        /// <remarks>This method does not dispose the TextReader.</remarks>
////        /// <exception cref="SyntaxException">Throw a syntax exception if the code cannot be parsed according to the C# specification.</exception>
////        public CsDocument CreateCodeModel(TextReader sourceCode)
////        {
////            Param.RequireNotNull(sourceCode, "sourceCode");

////            // Create the lexer object for the code string.
////            var lexer = new CodeLexer(this, sourceCode, new CodeReader(sourceCode));

////            // Parse the document.
////            var parser = new CodeParser(this, lexer);
////            parser.ParseDocument();

////            return parser.Document;
////        }

////        #endregion Public Methods

////        #region Internal Static Methods

////        /// <summary>
////        /// Gets the type of the given preprocessor symbol.
////        /// </summary>
////        /// <param name="preprocessor">The preprocessor symbol.</param>
////        /// <param name="bodyIndex">Returns the start index of the body of the preprocessor.</param>
////        /// <returns>Returns the type or null if the type cannot be determined.</returns>
////        internal static string GetPreprocessorDirectiveType(Symbol preprocessor, out int bodyIndex)
////        {
////            Param.AssertNotNull(preprocessor, "preprocessor");
////            Debug.Assert(preprocessor.SymbolType == SymbolType.PreprocessorDirective, "Expected a preprocessor directive");

////            // Get the preprocessor type. This is the second word in the statement.
////            bodyIndex = -1;
////            int startIndex = -1;
////            int endIndex = -1;

////            // Move to the start of the second word.
////            for (int i = 1; i < preprocessor.Text.Length; ++i)
////            {
////                if (char.IsLetter(preprocessor.Text[i]))
////                {
////                    startIndex = i;
////                    break;
////                }
////            }

////            if (startIndex == -1)
////            {
////                return null;
////            }

////            // Move to the end of the word.
////            for (endIndex = startIndex; endIndex < preprocessor.Text.Length; ++endIndex)
////            {
////                if (!char.IsLetter(preprocessor.Text[endIndex]))
////                {
////                    break;
////                }
////            }

////            --endIndex;
////            if (endIndex < startIndex)
////            {
////                return null;
////            }

////            // The body start index is just past the endIndex.
////            bodyIndex = endIndex + 1;

////            // Get the word.
////            return preprocessor.Text.Substring(startIndex, endIndex - startIndex + 1);
////        }

////        #endregion Internal Static Methods

////        #region Internal Methods

////        /// <summary>
////        /// Adds a rule suppression for the given element.
////        /// </summary>
////        /// <param name="element">The element.</param>
////        /// <param name="ruleId">The ID of the rule to suppress.</param>
////        /// <param name="ruleName">The name of the rule.</param>
////        /// <param name="ruleNamespace">The namespace in which the rule is contained.</param>
////        internal void AddRuleSuppression(Element element, string ruleId, string ruleName, string ruleNamespace)
////        {
////            Param.AssertNotNull(element, "element");
////            Param.AssertValidString(ruleId, "ruleId");
////            Param.Assert(ruleId == "*" || !string.IsNullOrEmpty(ruleName), "ruleName", "Rule name is invalid.");
////            Param.AssertValidString(ruleNamespace, "ruleNamespace");

////            // Need a writer lock arond this entire section to ensure thread safety of dictionary
////            // and the lists contained inside.
////            this.suppressionsLock.AcquireWriterLock(Timeout.Infinite);

////            try
////            {
////                // Generate the hashcode for the rule being suppressed.
////                int uniqueRuleID = Rule.GenerateUniqueId(ruleNamespace, ruleId, ruleName);

////                // Determine whether there is already at least one suppression for some element for this rule.
////                List<Element> elementsContainingSuppressedRule = null;
////                bool foundElementList = false;

////                if (this.suppressions.Count != 0)
////                {
////                    foundElementList = this.suppressions.TryGetValue(uniqueRuleID, out elementsContainingSuppressedRule);
////                }

////                Debug.Assert(
////                    !foundElementList || elementsContainingSuppressedRule != null,
////                    "The returned list of elements containing the suppressed rule should never be null.");

////                if (!foundElementList)
////                {
////                    // This is the first suppression for this rule type.
////                    elementsContainingSuppressedRule = new List<Element>();
////                    this.suppressions.Add(uniqueRuleID, elementsContainingSuppressedRule);
////                }

////                elementsContainingSuppressedRule.Add(element);
////            }
////            finally
////            {
////                this.suppressionsLock.ReleaseWriterLock();
////            }
////        }

////        #endregion Internal Methods

////        #region Private Static Methods

////        /// <summary>
////        /// Attempts to locate the given element within the collection of possible elements, and the parents and ancestors of those elements.
////        /// </summary>
////        /// <param name="element">The element to match.</param>
////        /// <param name="possibleElements">The collection of possible elements to match against.</param>
////        /// <returns>Returns true if a match is found; otherwise false.</returns>
////        private static bool MatchElementWithPossibleElementsTraversingParents(Element element, IEnumerable<Element> possibleElements)
////        {
////            Param.AssertNotNull(element, "element");
////            Param.AssertNotNull(possibleElements, "possibleElements");

////            foreach (Element possibleMatch in possibleElements)
////            {
////                Element item = element;
////                while (item != null)
////                {
////                    if (item == possibleMatch)
////                    {
////                        return true;
////                    }

////                    item = item.FindParent<Element>();
////                }
////            }

////            return false;
////        }

////        #endregion Private Static Methods

////        #region Private Methods

////        /// <summary>
////        /// Determines whether the given element contains a suppression for the given rule.
////        /// </summary>
////        /// <param name="element">The element to check.</param>
////        /// <param name="ruleHashCode">The rule hash code.</param>
////        /// <returns>Returns true if the rule is suppressed; false otherwise.</returns>
////        private bool IsRuleSuppressed(ICodeElement element, int ruleHashCode)
////        {
////            Param.AssertNotNull(element, "element");
////            Param.Ignore(ruleHashCode);

////            List<Element> elementsContainingSuppressedRule = null;

////            if (this.suppressions.Count != 0 && this.suppressions.TryGetValue(ruleHashCode, out elementsContainingSuppressedRule))
////            {
////                Debug.Assert(elementsContainingSuppressedRule != null, "The returned list of elements containing the suppressed rule should never be null.");
////                return MatchElementWithPossibleElementsTraversingParents((Element)element, elementsContainingSuppressedRule);
////            }

////            return false;
////        }

////        #endregion Private Methods
////    }
////}
