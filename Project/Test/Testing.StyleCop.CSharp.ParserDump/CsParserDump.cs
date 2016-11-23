// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CsParserDump.cs" company="https://github.com/StyleCop">
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
//   Dumps the parsed object model from the CsParser into an Xml file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Testing.StyleCop.CSharp.ParserDump
{
    using System;
    using System.IO;
    using System.Xml;
    using global::StyleCop;
    using global::StyleCop.CSharp;

    /// <summary>
    /// Dumps the parsed object model from the CsParser into an Xml file.
    /// </summary>
    [SourceAnalyzer(typeof(CsParser))]
    public class CsParserDump : SourceAnalyzer
    {
        #region Constructors and Destructors

        /// <summary>
        ///   Initializes a new instance of the CsParserDump class.
        /// </summary>
        public CsParserDump()
        {
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Checks the placement of brackets within the given document.
        /// </summary>
        /// <param name="document">
        /// The document to check.
        /// </param>
        public override void AnalyzeDocument(CodeDocument document)
        {
            Param.RequireNotNull(document, "document");

            XmlDocument contents = new XmlDocument();
            XmlNode root = contents.CreateElement("StyleCopCsParserObjectModel");
            contents.AppendChild(root);

            CsDocument csdocument = (CsDocument)document;
            if (csdocument.RootElement != null)
            {
                this.ProcessElement(csdocument.RootElement, root);
            }

            // Get the location where the output file should be stored.
            string testOutputDirectory = (string)this.Core.HostTag;
            if (string.IsNullOrEmpty(testOutputDirectory))
            {
                throw new InvalidOperationException("The HostTag has not been properly set in StyleCopCore.");
            }

            // Save the output to the file.
            string outputFileLocation = Path.Combine(testOutputDirectory, Path.GetFileNameWithoutExtension(document.SourceCode.Path) + "ObjectModelResults.xml");

            contents.Save(outputFileLocation);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Records information about the given element, under the given node.
        /// </summary>
        /// <param name="element">
        /// The element to record.
        /// </param>
        /// <param name="parentNode">
        /// The Xml node to record this element beneath.
        /// </param>
        /// <returns>
        /// Returns the new Xml node describing this element.
        /// </returns>
        private static XmlNode RecordElement(CsElement element, XmlNode parentNode)
        {
            Param.AssertNotNull(element, "element");
            Param.AssertNotNull(parentNode, "parentNode");

            // Create a new node for this element and add it to the parent.
            XmlNode elementNode = parentNode.OwnerDocument.CreateElement("Element");
            parentNode.AppendChild(elementNode);

            // Add the name and type of the element.
            XmlAttribute name = parentNode.OwnerDocument.CreateAttribute("Name");
            name.Value = element.Declaration.Name;
            elementNode.Attributes.Append(name);

            XmlAttribute type = parentNode.OwnerDocument.CreateAttribute("Type");
            type.Value = element.GetType().Name;
            elementNode.Attributes.Append(type);

            return elementNode;
        }

        /// <summary>
        /// Records information about the given expression, under the given node.
        /// </summary>
        /// <param name="expression">
        /// The expression to record.
        /// </param>
        /// <param name="parentNode">
        /// The Xml node to record this expression beneath.
        /// </param>
        /// <returns>
        /// Returns the new Xml node describing this expression.
        /// </returns>
        private static XmlNode RecordExpression(Expression expression, XmlNode parentNode)
        {
            Param.AssertNotNull(expression, "expression");
            Param.AssertNotNull(parentNode, "parentNode");

            // Create a new node for this expression and add it to the parent.
            XmlNode expressionNode = parentNode.OwnerDocument.CreateElement("Expression");
            parentNode.AppendChild(expressionNode);

            // Add the name and contents of the expression.
            if (expression.ExpressionType == ExpressionType.Literal)
            {
                XmlAttribute text = parentNode.OwnerDocument.CreateAttribute("Text");
                text.Value = expression.ToString();
                expressionNode.Attributes.Append(text);
            }

            XmlAttribute type = parentNode.OwnerDocument.CreateAttribute("Type");
            type.Value = expression.GetType().Name;
            expressionNode.Attributes.Append(type);

            return expressionNode;
        }

        /// <summary>
        /// Records information about the given statement, under the given node.
        /// </summary>
        /// <param name="statement">
        /// The statement to record.
        /// </param>
        /// <param name="parentNode">
        /// The Xml node to record this statement beneath.
        /// </param>
        /// <returns>
        /// Returns the new Xml node describing this statement.
        /// </returns>
        private static XmlNode RecordStatement(Statement statement, XmlNode parentNode)
        {
            Param.AssertNotNull(statement, "statement");
            Param.AssertNotNull(parentNode, "parentNode");

            // Create a new node for this statement and add it to the parent.
            XmlNode statementNode = parentNode.OwnerDocument.CreateElement("Statement");
            parentNode.AppendChild(statementNode);

            // Add the name and contents of the statement.
            ////XmlAttribute text = parentNode.OwnerDocument.CreateAttribute("Text");
            ////text.Value = statement.ToString();
            ////statementNode.Attributes.Append(text);
            XmlAttribute type = parentNode.OwnerDocument.CreateAttribute("Type");
            type.Value = statement.GetType().Name;
            statementNode.Attributes.Append(type);

            return statementNode;
        }

        /// <summary>
        /// Processes the given element and its children.
        /// </summary>
        /// <param name="element">
        /// The element to process.
        /// </param>
        /// <param name="parentNode">
        /// The Xml node to record this element under.
        /// </param>
        private void ProcessElement(CsElement element, XmlNode parentNode)
        {
            Param.AssertNotNull(element, "element");
            Param.AssertNotNull(parentNode, "parentNode");

            XmlNode elementNode = RecordElement(element, parentNode);

            foreach (Statement statement in element.ChildStatements)
            {
                this.ProcessStatement(statement, elementNode);
            }

            foreach (CsElement child in element.ChildElements)
            {
                this.ProcessElement(child, elementNode);
            }
        }

        /// <summary>
        /// Processes the given expression and its child statements and expressions.
        /// </summary>
        /// <param name="expression">
        /// The expression to process.
        /// </param>
        /// <param name="parentNode">
        /// The Xml node to record this expression under.
        /// </param>
        private void ProcessExpression(Expression expression, XmlNode parentNode)
        {
            Param.AssertNotNull(expression, "expression");
            Param.AssertNotNull(parentNode, "parentNode");

            XmlNode expressionNode = RecordExpression(expression, parentNode);

            foreach (Expression childExpression in expression.ChildExpressions)
            {
                this.ProcessExpression(childExpression, expressionNode);
            }

            foreach (Statement childStatement in expression.ChildStatements)
            {
                this.ProcessStatement(childStatement, expressionNode);
            }
        }

        /// <summary>
        /// Processes the given statement and its child statements and expressions.
        /// </summary>
        /// <param name="statement">
        /// The statement to process.
        /// </param>
        /// <param name="parentNode">
        /// The Xml node to record this statement under.
        /// </param>
        private void ProcessStatement(Statement statement, XmlNode parentNode)
        {
            Param.AssertNotNull(statement, "statement");
            Param.AssertNotNull(parentNode, "parentNode");

            XmlNode statementNode = RecordStatement(statement, parentNode);

            if (statement.ChildExpressions != null)
            {
                foreach (Expression expression in statement.ChildExpressions)
                {
                    this.ProcessExpression(expression, statementNode);
                }
            }

            if (statement.ChildStatements != null)
            {
                foreach (Statement childStatement in statement.ChildStatements)
                {
                    this.ProcessStatement(childStatement, statementNode);
                }
            }
        }

        #endregion
    }
}