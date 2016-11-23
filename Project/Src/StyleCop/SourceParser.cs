// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SourceParser.cs" company="https://github.com/StyleCop">
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
//   Base class for StyleCop code parser modules.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Xml;

    /// <summary>
    /// Base class for StyleCop code parser modules.
    /// </summary>
    public abstract class SourceParser : StyleCopAddIn
    {
        #region Fields

        /// <summary>
        /// The list of analyzers loaded into this parser.
        /// </summary>
        private readonly List<SourceAnalyzer> analyzers = new List<SourceAnalyzer>();

        /// <summary>
        /// The list of file types supported by this parser.
        /// </summary>
        private readonly List<string> fileTypes = new List<string>(1);

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the list of analyzers loaded into this parser.
        /// </summary>
        public ICollection<SourceAnalyzer> Analyzers
        {
            get
            {
                return this.analyzers;
            }
        }

        /// <summary>
        /// Gets the collection of code file types supported by this parser.
        /// </summary>
        public ICollection<string> FileTypes
        {
            get
            {
                return this.fileTypes;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Adds a global violation.
        /// </summary>
        /// <param name="line">
        /// The line in the code where the violation occurs.
        /// </param>
        /// <param name="ruleName">
        /// The name of the rule that triggered the violation.
        /// </param>
        /// <param name="values">
        /// String values to add to the violation string.
        /// </param>
        public void AddGlobalViolation(int line, string ruleName, params object[] values)
        {
            Param.Ignore(line, ruleName, values);

            Rule rule = this.GetRule(ruleName);
            if (rule == null)
            {
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Strings.RuleDoesNotExist, ruleName), "ruleName");
            }

            // Look up this violation type.
            this.Core.AddViolation((ICodeElement)null, rule, line, values);
        }

        /// <summary>
        /// Adds a global violation.
        /// </summary>
        /// <param name="line">
        /// The line in the code where the violation occurs.
        /// </param>
        /// <param name="ruleName">
        /// The name of the rule that triggered the violation.
        /// </param>
        /// <param name="values">
        /// String values to add to the violation string.
        /// </param>
        public void AddGlobalViolation(int line, Enum ruleName, params object[] values)
        {
            Param.Ignore(line);
            Param.RequireNotNull(ruleName, "ruleName");
            Param.Ignore(values);

            this.AddGlobalViolation(line, ruleName.ToString(), values);
        }

        /// <summary>
        /// Adds one violation to the given source code document.
        /// </summary>
        /// <param name="sourceCode">
        /// The source code document that the violation appears in.
        /// </param>
        /// <param name="line">
        /// The line in the code where the violation occurs.
        /// </param>
        /// <param name="ruleName">
        /// The name of the rule that triggered the violation.
        /// </param>
        /// <param name="values">
        /// String parameters to insert into the violation string.
        /// </param>
        public void AddViolation(SourceCode sourceCode, int line, string ruleName, params object[] values)
        {
            Param.Ignore(sourceCode, line, ruleName, values);

            Rule rule = this.GetRule(ruleName);
            if (rule == null)
            {
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Strings.RuleDoesNotExist, ruleName), "ruleName");
            }

            // Look up this violation type.
            this.Core.AddViolation(sourceCode, rule, line, values);
        }

        /// <summary>
        /// Adds one violation to the given source code document.
        /// </summary>
        /// <param name="sourceCode">
        /// The source code document that the violation appears in.
        /// </param>
        /// <param name="line">
        /// The line in the code where the violation occurs.
        /// </param>
        /// <param name="ruleName">
        /// The name of the rule that triggered the violation.
        /// </param>
        /// <param name="values">
        /// String parameters to insert into the violation string.
        /// </param>
        public void AddViolation(SourceCode sourceCode, int line, Enum ruleName, params object[] values)
        {
            Param.Ignore(sourceCode);
            Param.Ignore(line);
            Param.RequireNotNull(ruleName, "ruleName");
            Param.Ignore(values);

            this.AddViolation(sourceCode, line, ruleName.ToString(), values);
        }

        /// <summary>
        /// Adds the given violation.
        /// </summary>
        /// <param name="violation">
        /// The violation to add.
        /// </param>
        public void AddViolation(Violation violation)
        {
            Param.RequireNotNull(violation, "violation");

            if (violation.Element != null)
            {
                this.Core.AddViolation(violation.Element, violation);
            }
            else if (violation.SourceCode != null)
            {
                this.Core.AddViolation(violation.SourceCode, violation);
            }
            else
            {
                this.Core.AddViolation((ICodeElement)null, violation);
            }
        }

        /// <summary>
        /// Parses a source code document.
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
        /// Returns false if no further analysis should be done on this file.
        /// </returns>
        /// <remarks>
        /// If this method returns false, StyleCop will call the method again on the next pass
        /// and send in the same file, list of analyzers, and document. This allows the parser to perform 
        /// to parse its files in stages, if necessary.
        /// </remarks>
        [SuppressMessage("Microsoft.Design", "CA1045:DoNotPassTypesByReference", MessageId = "2#", 
            Justification = "The design of the method is consistent with other .Net Framework methods such as int.TryParse, etc.")]
        [SuppressMessage("Microsoft.Maintainability", "CA1500:VariableNamesShouldNotMatchFieldNames", Justification = "The method is abstract")]
        public abstract bool ParseFile(SourceCode sourceCode, int passNumber, ref CodeDocument document);

        /// <summary>
        /// Called after an analysis run is completed.
        /// </summary>
        public virtual void PostParse()
        {
        }

        /// <summary>
        /// Called before a new analysis run is initiated.
        /// </summary>
        public virtual void PreParse()
        {
        }

        /// <summary>
        /// Indicates whether to skip analysis on the given document.
        /// </summary>
        /// <param name="sourceCode">
        /// The sourceCode to check.
        /// </param>
        /// <returns>
        /// Returns true to skip analysis on the document.
        /// </returns>
        public virtual bool SkipAnalysisForDocument(SourceCode sourceCode)
        {
            Param.Ignore(sourceCode);
            return false;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Clears the analyzer tags for the given document and all of its children.
        /// </summary>
        /// <param name="document">
        /// The document to clear.
        /// </param>
        /// <remarks>
        /// <para>
        /// During each analysis run, analyzers can store data within each analyzed document for
        /// later use. Analyzers store and retrieve this data using the <see cref="SourceAnalyzer.GetDocumentData"/>
        /// and <see cref="SourceAnalyzer.SetDocumentData"/> methods.
        /// </para>
        /// <para>
        /// After all analysis has been completed, this analyzer data should be cleared so that
        /// it will not conflict with the next analysis. This method can be called to clear all
        /// analyzer data which was stored during the previous analysis.
        /// </para>
        /// </remarks>
        internal static void ClearAnalyzerTags(CodeDocument document)
        {
            Param.AssertNotNull(document, "document");

            if (document != null && document.DocumentContents != null)
            {
                document.DocumentContents.ClearAnalyzerTags();
            }
        }

        /// <summary>
        /// Exports the violations found within this document into the given xml node.
        /// </summary>
        /// <param name="document">
        /// The document containing the violations.
        /// </param>
        /// <param name="violationsDocument">
        /// The xml document in which to store the violation information.
        /// </param>
        /// <param name="parentNode">
        /// The parent node within this xml document under which to store the violation information.
        /// </param>
        internal static void ExportViolations(CodeDocument document, XmlDocument violationsDocument, XmlNode parentNode)
        {
            Param.AssertNotNull(document, "document");
            Param.AssertNotNull(violationsDocument, "violationsDocument");
            Param.AssertNotNull(parentNode, "parentNode");

            if (document.DocumentContents != null)
            {
                SourceParser.ExportElementViolations(document.DocumentContents, violationsDocument, parentNode);
            }

            if (document.SourceCode != null)
            {
                // Add the violations from the source code.
                foreach (Violation violation in document.SourceCode.Violations)
                {
                    SourceParser.ExportViolation(violation, violationsDocument, parentNode);
                }
            }
        }

        /// <summary>
        /// Imports the cached violations under the given node.
        /// </summary>
        /// <param name="sourceCode">
        /// The source code containing the violations.
        /// </param>
        /// <param name="parentNode">
        /// The parent xml node containing the list of violations.
        /// </param>
        /// <returns>
        /// Returns true if all the data was loaded successfully from the file.
        /// </returns>
        internal bool ImportViolations(SourceCode sourceCode, XmlNode parentNode)
        {
            Param.AssertNotNull(sourceCode, "sourceCode");
            Param.AssertNotNull(parentNode, "parentNode");

            bool success = true;

            try
            {
                XmlNodeList violations = parentNode.SelectNodes("violation");
                if (violations != null && violations.Count > 0)
                {
                    foreach (XmlNode violationNode in violations)
                    {
                        // Get the violation data from the xml node.
                        XmlNode nameSpace = violationNode.SelectSingleNode("@namespace");
                        XmlNode ruleName = violationNode.SelectSingleNode("@rule");
                        XmlNode ruleCheckId = violationNode.SelectSingleNode("@ruleCheckId");
                        XmlNode context = violationNode.SelectSingleNode("context");
                        XmlNode lineNumber = violationNode.SelectSingleNode("line");
                        XmlNode warning = violationNode.SelectSingleNode("warning");

                        XmlNode index = violationNode.SelectSingleNode("index");
                        XmlNode endIndex = violationNode.SelectSingleNode("endIndex");
                        XmlNode startLine = violationNode.SelectSingleNode("startLine");
                        XmlNode startColumn = violationNode.SelectSingleNode("startColumn");
                        XmlNode endLine = violationNode.SelectSingleNode("endLine");
                        XmlNode endColumn = violationNode.SelectSingleNode("endColumn");

                        // Create a Rule object representing this data.
                        Rule rule = new Rule(
                            ruleName.InnerText, 
                            nameSpace.InnerText, 
                            ruleCheckId.InnerText, 
                            context.InnerText, 
                            Convert.ToBoolean(warning.InnerText, CultureInfo.InvariantCulture));

                        Violation violation;

                        if (startLine != null && startColumn != null && endLine != null && endColumn != null)
                        {
                            CodeLocation location = new CodeLocation(
                                Convert.ToInt32(index.InnerText, null), 
                                Convert.ToInt32(endIndex.InnerText, null), 
                                Convert.ToInt32(startColumn.InnerText, null), 
                                Convert.ToInt32(endColumn.InnerText, null), 
                                Convert.ToInt32(startLine.InnerText, null), 
                                Convert.ToInt32(endLine.InnerText, null));

                            // Create a Violation object representing this data.
                            violation = new Violation(rule, sourceCode, location, context.InnerText);
                        }
                        else
                        {
                            // Create a Violation object representing this data.
                            violation = new Violation(rule, sourceCode, Convert.ToInt32(lineNumber.InnerText, null), context.InnerText);
                        }

                        this.AddViolation(violation);
                    }
                }
            }
            catch (ArgumentException)
            {
                success = false;
            }
            catch (XmlException)
            {
                success = false;
            }
            catch (FormatException)
            {
                success = false;
            }
            catch (OverflowException)
            {
                success = false;
            }

            return success;
        }

        /// <summary>
        /// Parses the given Xml document and loads the rules.
        /// </summary>
        /// <param name="document">
        /// The xml document to load.
        /// </param>
        /// <param name="topmostType">
        /// Indicates whether the xml document comes from the top-most type in the 
        /// add-in's type hierarchy.
        /// </param>
        /// <param name="isKnownAssembly">
        /// Indicates whether the add-in comes from a known assembly.
        /// </param>
        protected override void ImportInitializationXml(XmlDocument document, bool topmostType, bool isKnownAssembly)
        {
            Param.RequireNotNull(document, "document");
            Param.RequireNotNull(document.DocumentElement, "document.DocumentElement");
            Param.Ignore(topmostType);
            Param.Ignore(isKnownAssembly);

            base.ImportInitializationXml(document, topmostType, isKnownAssembly);

            if (topmostType)
            {
                // Make sure the root element's name is correct.
                if (document.DocumentElement.Name != "SourceParser")
                {
                    throw new ArgumentException(Strings.RootNodeMustBeSourceParser);
                }
            }

            // Create a list to store the supported file types.
            List<string> fileTypesForParser = null;

            // Go through all the child nodes of the root parser node.
            XmlNodeList fileTypeNodes = document.DocumentElement.SelectNodes("FileTypes/FileType");
            if (fileTypeNodes != null)
            {
                foreach (XmlNode fileType in fileTypeNodes)
                {
                    if (fileTypesForParser == null)
                    {
                        fileTypesForParser = new List<string>();
                    }

                    fileTypesForParser.Add(fileType.InnerText.Trim(' ', '\t', '.').ToUpperInvariant());
                }
            }

            if (fileTypesForParser != null && fileTypesForParser.Count > 0)
            {
                // Store the file types list.
                this.fileTypes.AddRange(fileTypesForParser);
            }
        }

        /// <summary>
        /// Writes the given output to the StyleCop log file.
        /// </summary>
        /// <param name="level">
        /// The output level.
        /// </param>
        /// <param name="output">
        /// The output text to write.
        /// </param>
        [SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "output", Justification = "The method is not yet implemented.")]
        [SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "level", Justification = "The method is not yet implemented.")]
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "The method is not yet implemented.")]
        protected void Log(StyleCopLogLevel level, string output)
        {
            Param.Ignore(level, output);
        }

        /// <summary>
        /// Exports the violations found within this document into the given xml node.
        /// </summary>
        /// <param name="element">
        /// The element containing the violations to export.
        /// </param>
        /// <param name="violationsDocument">
        /// The xml document in which to store the violation information.
        /// </param>
        /// <param name="parentNode">
        /// The parent node within this xml document under which to store the violation information.
        /// </param>
        private static void ExportElementViolations(ICodeElement element, XmlDocument violationsDocument, XmlNode parentNode)
        {
            Param.AssertNotNull(element, "element");
            Param.AssertNotNull(violationsDocument, "violationsDocument");
            Param.AssertNotNull(parentNode, "parentNode");

            // Add the violations from this element.
            foreach (Violation violation in element.Violations)
            {
                SourceParser.ExportViolation(violation, violationsDocument, parentNode);
            }

            // Add this violations from this element's children.
            IEnumerable<ICodeElement> children = element.ChildCodeElements;
            if (children != null)
            {
                foreach (ICodeElement child in children)
                {
                    SourceParser.ExportElementViolations(child, violationsDocument, parentNode);
                }
            }
        }

        /// <summary>
        /// Exports the contents of the given violation into the given xml node.
        /// </summary>
        /// <param name="violation">
        /// The violation to save.
        /// </param>
        /// <param name="violationsDocument">
        /// The xml document in which to store the violation information.
        /// </param>
        /// <param name="parentNode">
        /// The parent node within this xml document under which to store the violation information.
        /// </param>
        private static void ExportViolation(Violation violation, XmlDocument violationsDocument, XmlNode parentNode)
        {
            Param.AssertNotNull(violation, "violation");
            Param.AssertNotNull(violationsDocument, "violationsDocument");
            Param.AssertNotNull(parentNode, "parentNode");

            // Create the root element for this violation.
            XmlElement item = violationsDocument.CreateElement("violation");
            parentNode.AppendChild(item);

            // Create the namespace attribute.
            XmlAttribute nameSpace = violationsDocument.CreateAttribute("namespace");
            nameSpace.Value = violation.Rule.Namespace;
            item.Attributes.Append(nameSpace);

            // Create the rule name attribute.
            XmlAttribute name = violationsDocument.CreateAttribute("rule");
            name.Value = violation.Rule.Name;
            item.Attributes.Append(name);

            // Create the rule check-id attribute.
            XmlAttribute checkId = violationsDocument.CreateAttribute("ruleCheckId");
            checkId.Value = violation.Rule.CheckId;
            item.Attributes.Append(checkId);

            // Create a child node for the violation content string.
            XmlElement context = violationsDocument.CreateElement("context");
            context.InnerText = violation.Message;
            item.AppendChild(context);

            // Create a child node for the violation line number.
            XmlElement lineNumber = violationsDocument.CreateElement("line");
            lineNumber.InnerText = violation.Line.ToString(CultureInfo.InvariantCulture);
            item.AppendChild(lineNumber);

            if (violation.Location != null)
            {
                XmlElement index = violationsDocument.CreateElement("index");
                index.InnerText = violation.Location.Value.StartPoint.Index.ToString(CultureInfo.InvariantCulture);
                item.AppendChild(index);

                XmlElement endIndex = violationsDocument.CreateElement("endIndex");
                endIndex.InnerText = violation.Location.Value.EndPoint.Index.ToString(CultureInfo.InvariantCulture);
                item.AppendChild(endIndex);

                XmlElement startLine = violationsDocument.CreateElement("startLine");
                startLine.InnerText = violation.Location.Value.StartPoint.LineNumber.ToString(CultureInfo.InvariantCulture);
                item.AppendChild(startLine);

                XmlElement startColumn = violationsDocument.CreateElement("startColumn");
                startColumn.InnerText = violation.Location.Value.StartPoint.IndexOnLine.ToString(CultureInfo.InvariantCulture);
                item.AppendChild(startColumn);

                XmlElement endLine = violationsDocument.CreateElement("endLine");
                endLine.InnerText = violation.Location.Value.EndPoint.LineNumber.ToString(CultureInfo.InvariantCulture);
                item.AppendChild(endLine);

                XmlElement endColumn = violationsDocument.CreateElement("endColumn");
                endColumn.InnerText = violation.Location.Value.EndPoint.IndexOnLine.ToString(CultureInfo.InvariantCulture);
                item.AppendChild(endColumn);
            }

            // Create a child node for the warning indicator.
            XmlElement warning = violationsDocument.CreateElement("warning");
            warning.InnerText = violation.Rule.Warning.ToString(CultureInfo.InvariantCulture);
            item.AppendChild(warning);
        }

        #endregion
    }
}