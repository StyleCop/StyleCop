//-----------------------------------------------------------------------
// <copyright file="CsParserDump.cs">
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
namespace StyleCop.CSharpParserTest
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Text;
    using System.Xml;
    using StyleCop;
    using StyleCop.CSharp;
    using StyleCop.CSharp.CodeModel;

    /// <summary>
    /// Dumps the parsed object model from the CsParser into an Xml file.
    /// </summary>
    [SourceAnalyzer(typeof(CsParser))]
    public class CsParserDump : SourceAnalyzer
    {
        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the CsParserDump class.
        /// </summary>
        public CsParserDump()
        {
        }

        #endregion Public Constructors

        #region Public Override Methods

        /// <summary>
        /// Checks the placement of brackets within the given document.
        /// </summary>
        /// <param name="document">The document to check.</param>
        public override void AnalyzeDocument(ICodeDocument document)
        {
            Param.RequireNotNull(document, "document");

            XmlDocument contents = new XmlDocument();
            XmlNode root = contents.CreateElement("StyleCopCsParserObjectModel");
            contents.AppendChild(root);

            CsDocument csdocument = document.AsCsDocument();
            this.ProcessCodeUnit(csdocument, root);

            // Get the location where the output file should be stored.
            string testOutputDirectory = (string)this.Core.HostTag;
            if (string.IsNullOrEmpty(testOutputDirectory))
            {
                throw new InvalidOperationException("The HostTag has not been properly set in StyleCopCore.");
            }

            // Save the output to the file.
            string outputFileLocation = Path.Combine(
                testOutputDirectory,
                Path.GetFileNameWithoutExtension(document.SourceCode.Path) + "ObjectModelResults.xml");

            contents.Save(outputFileLocation);
        }

        #endregion Public Override Methods

        #region Private Methods

        private void ProcessCodeUnit(CodeUnit item, XmlNode parentNode)
        {
            XmlNode elementNode = RecordItem(item, parentNode);
            for (CodeUnit child = item.Children.First; child != null; child = child.LinkNode.Next)
            {
                ProcessCodeUnit(child, elementNode);
            }
        }

        /// <summary>
        /// Records information about the given item, under the given node.
        /// </summary>
        /// <param name="item">The item to record.</param>
        /// <param name="parentNode">The Xml node to record this item beneath.</param>
        /// <returns>Returns the new Xml node describing this item.</returns>
        private static XmlNode RecordItem(CodeUnit item, XmlNode parentNode)
        {
            Param.AssertNotNull(item, "item");
            Param.AssertNotNull(parentNode, "parentNode");

            // Create a new node for this item and add it to the parent.
            XmlNode codeUnitNode = parentNode.OwnerDocument.CreateElement("CodeUnit");
            parentNode.AppendChild(codeUnitNode);

            if (item.Is(CodeUnitType.LexicalElement))
            {
                XmlAttribute text = parentNode.OwnerDocument.CreateAttribute("Text");
                text.Value = ((LexicalElement)item).Text;
                codeUnitNode.Attributes.Append(text);
            }

            XmlAttribute type = parentNode.OwnerDocument.CreateAttribute("Type");
            type.Value = item.GetType().Name;
            codeUnitNode.Attributes.Append(type);

            return codeUnitNode;
        }

        #endregion Private Methods
    }
}
