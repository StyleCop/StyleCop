//-----------------------------------------------------------------------
// <copyright file="ElementWrapper.cs" company="Microsoft">
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
    using System.Collections.Generic;
    using System.Diagnostics;
    using Microsoft.StyleCop.CSharp.CodeModel;

    /// <summary>
    /// Wraps an <see cref="Element" /> to add necessary StyleCop document support.
    /// </summary>
    internal class ElementWrapper : ICodeElement
    {
        /// <summary>
        /// The wrapped element.
        /// </summary>
        private Element element;

        /// <summary>
        /// The list of violations in this element.
        /// </summary>
        private Dictionary<string, Violation> violations = new Dictionary<string, Violation>();

        /// <summary>
        /// A private tag which can be used by the current analyzer.
        /// </summary>
        private object analyzerTag;

        /// <summary>
        /// Initializes a new instance of the ElementWrapper class.
        /// </summary>
        public ElementWrapper()
        {
        }

        /// <summary>
        /// Initializes a new instance of the ElementWrapper class.
        /// </summary>
        /// <param name="element">The element to wrap.</param>
        public ElementWrapper(Element element)
        {
            Param.AssertNotNull(element, "element");
            this.element = element;

            // Add any suppressed rules.
            this.AddRuleSuppressionsForElement();
        }

        /// <summary>
        /// Gets the collection of child elements beneath this element.
        /// </summary>
        public IEnumerable<ICodeElement> ChildCodeElements
        {
            get
            {
                if (this.element != null)
                {
                    for (Element child = this.element.FindFirstChild<Element>(); child != null; child = child.FindNextSibling<Element>())
                    {
                        yield return Wrapper(child);
                    }
                }

                yield break;
            }
        }

        /// <summary>
        /// Gets the violations found in this element.
        /// </summary>
        public ICollection<Violation> Violations
        {
            get
            {
                return this.violations.Values;
            }
        }

        /// <summary>
        /// Gets or sets the analyzer tag.
        /// </summary>
        /// <remarks>A StyleCop rules analyzer can temporarily store and retrieve a value in this property. This value will be lost once 
        /// the rules analyzer has completed its analysis of the document containing this code element.</remarks>
        public object AnalyzerTag
        {
            get
            {
                return this.analyzerTag;
            }

            set
            {
                Param.Ignore(value);
                this.analyzerTag = value;
            }
        }

        /// <summary>
        /// Gets the fully qualified name of the element.
        /// </summary>
        public string FullyQualifiedName
        {
            get
            {
                return this.element == null ? string.Empty : this.element.Document.FullyQualifiedName;
            }
        }

        /// <summary>
        /// Gets the document that contains the code part.
        /// </summary>
        public ICodeDocument Document
        {
            get
            {
                if (this.element == null)
                {
                    return null;
                }
                
                return CsDocumentWrapper.Wrapper(this.element.Document);
            }
        }

        /// <summary>
        /// Gets the line number that this code part appears on in the document.
        /// </summary>
        public int LineNumber
        {
            get
            {
                return this.element == null ? 1 : this.element.LineNumber;
            }
        }

        /// <summary>
        /// Gets an element wrapper for the given element.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns>Returns the wrapper.</returns>
        public static ElementWrapper Wrapper(Element element)
        {
            Param.AssertNotNull(element, "element");

            Debug.Assert(element.ElementType != ElementType.Document, "Use DocumentWrapper.Wrapper for docs.");

            if (element.Tag != null)
            {
                return (ElementWrapper)element.Tag;
            }

            ElementWrapper wrapper = new ElementWrapper(element);
            element.Tag = wrapper;
            return wrapper;
        }

        /// <summary>
        /// Adds one violation to this element.
        /// </summary>
        /// <param name="violation">The violation to add.</param>
        /// <returns>Returns false if there is already an identical violation in the element.</returns>
        public bool AddViolation(Violation violation)
        {
            Param.AssertNotNull(violation, "violation");
            string key = violation.Key;

            if (!this.violations.ContainsKey(key))
            {
                this.violations.Add(violation.Key, violation);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Clears the analyzer tags for this element.
        /// </summary>
        /// <remarks>This method should only be called by the StyleCop framework.</remarks>
        public void ClearAnalyzerTags()
        {
            this.analyzerTag = null;
        }

        /// <summary>
        /// Determines whether the given expression is the start of a CodeAnalysis SuppressMessage attribute.
        /// </summary>
        /// <param name="name">The expression to check.</param>
        /// <returns>Returns true if the expression is a CodeAnalysis SuppressMessage; false otherwise.</returns>
        private static bool IsCodeAnalysisSuppression(Expression name)
        {
            Param.AssertNotNull(name, "name");

            if (name.ExpressionType == ExpressionType.Literal)
            {
                string nameText = ((LiteralExpression)name).Text;
                if (string.Equals(nameText, "SuppressMessage", StringComparison.Ordinal) || string.Equals(nameText, "SuppressMessageAttribute"))
                {
                    return true;
                }
            }
            else if (name.ExpressionType == ExpressionType.MemberAccess)
            {
                Token start = name.FindFirstChild<Token>();
                if (name.MatchTokens(start, new string[] { "System", ".", "Diagnostics", ".", "CodeAnalysis", ".", "SuppressMessage" }) ||
                    name.MatchTokens(start, new string[] { "System", ".", "Diagnostics", ".", "CodeAnalysis", ".", "SuppressMessageAttribute" }))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Extracts the CheckID for the rule being suppressed, from the given Code Analysis SuppressMessage attribute expression.
        /// </summary>
        /// <param name="codeAnalysisAttributeExpression">The expression to parse.</param>
        /// <param name="ruleId">Returns the rule ID.</param>
        /// <param name="ruleName">Returns the rule name.</param>
        /// <param name="ruleNamespace">Returns the namespace that contains the rule.</param>
        /// <returns>Returns true if the ID, name, and namespace were successfully extracted from the suppression.</returns>
        private static bool TryCrackCodeAnalysisSuppression(MethodInvocationExpression codeAnalysisAttributeExpression, out string ruleId, out string ruleName, out string ruleNamespace)
        {
            Param.AssertNotNull(codeAnalysisAttributeExpression, "codeAnalysisAttributeExpression");

            // Initialize all out fields to null.
            ruleId = ruleName = ruleNamespace = null;

            if (codeAnalysisAttributeExpression.Arguments != null && codeAnalysisAttributeExpression.Arguments.Count >= 2)
            {
                // The rule namespace sits in the first argument.
                ruleNamespace = ExtractStringFromAttributeExpression(codeAnalysisAttributeExpression.Arguments[0].Expression);
                if (string.IsNullOrEmpty(ruleNamespace))
                {
                    return false;
                }

                // The checkID and rule name sit in the second argument.
                string nameAndId = ExtractStringFromAttributeExpression(codeAnalysisAttributeExpression.Arguments[1].Expression);
                if (string.IsNullOrEmpty(nameAndId))
                {
                    return false;
                }

                int separatorIndex = nameAndId.IndexOf(':');
                if (separatorIndex == -1)
                {
                    return false;
                }

                ruleId = nameAndId.Substring(0, separatorIndex);
                ruleName = nameAndId.Substring(separatorIndex + 1, nameAndId.Length - separatorIndex - 1);

                return ruleId.Length > 0 && ruleName.Length > 0;
            }

            return false;
        }

        /// <summary>
        /// Attempts to extract a string from the given attribute expression, it if is a literal expression containing a string.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <returns>Returns the string or null.</returns>
        private static string ExtractStringFromAttributeExpression(Expression expression)
        {
            Param.Ignore(expression);

            if (expression == null || expression.ExpressionType != ExpressionType.Literal)
            {
                return null;
            }

            LiteralExpression literalExpression = (LiteralExpression)expression;
            if (literalExpression.Token.TokenType != TokenType.String)
            {
                return null;
            }

            string text = literalExpression.Token.Text;
            if (text.StartsWith("\"", StringComparison.Ordinal) && text.EndsWith("\"", StringComparison.Ordinal) && text.Length >= 2)
            {
                return text.Substring(1, text.Length - 2);
            }

            return text;
        }

        /// <summary>
        /// Adds any suppressions for the given element by scanning the attributes on the element.
        /// </summary>
        private void AddRuleSuppressionsForElement()
        {
            if (this.element != null && this.element.Attributes != null && this.element.Attributes.Count > 0)
            {
                foreach (Microsoft.StyleCop.CSharp.CodeModel.Attribute attribute in this.element.Attributes)
                {
                    if (attribute.AttributeExpressions != null)
                    {
                        foreach (AttributeExpression attributeExpression in attribute.AttributeExpressions)
                        {
                            if (attributeExpression.Initialization != null)
                            {
                                MethodInvocationExpression methodInvocation = attributeExpression.Initialization as MethodInvocationExpression;
                                if (methodInvocation != null)
                                {
                                    if (IsCodeAnalysisSuppression(methodInvocation.Name))
                                    {
                                        // Crack open the expression and extract the rule checkID.
                                        string checkId;
                                        string ruleName;
                                        string ruleNamespace;

                                        if (TryCrackCodeAnalysisSuppression(methodInvocation, out checkId, out ruleName, out ruleNamespace))
                                        {
                                            Debug.Assert(!string.IsNullOrEmpty(checkId), "Rule ID should not be null");
                                            Debug.Assert(!string.IsNullOrEmpty(ruleName), "Rule Name should not be null");
                                            Debug.Assert(!string.IsNullOrEmpty(ruleNamespace), "Rule Namespace should not be null");

                                            CsParser parser = CsDocumentWrapper.Wrapper(this.element.Document).Parser;
                                            parser.AddRuleSuppression(this.element, checkId, ruleName, ruleNamespace);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
