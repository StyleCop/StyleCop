// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FileHeader.cs" company="http://stylecop.codeplex.com">
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
//   File header.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace StyleCop.ReSharper.Core
{
    using System;
    using System.Collections.Specialized;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Web;
    using System.Xml;

    using JetBrains.Application.Settings;
    using JetBrains.ReSharper.Psi;
    using JetBrains.ReSharper.Psi.CSharp.Parsing;
    using JetBrains.ReSharper.Psi.CSharp.Tree;
    using JetBrains.ReSharper.Psi.ExtensionsAPI;
    using JetBrains.ReSharper.Psi.Tree;
    using JetBrains.ReSharper.Resources.Shell;

    using StyleCop.ReSharper.Extensions;
    using StyleCop.ReSharper.Options;

    /// <summary>
    /// File header.
    /// </summary>
    internal class FileHeader
    {
        private const string FileHeaderIndentedLinePrefix = "//   ";

        private const string FileHeaderLinePrefix = "// ";

        private static readonly string StandardHeader =
            "// --------------------------------------------------------------------------------------------------------------------" + Environment.NewLine
            + "// <copyright file=\"\" company=\"\">" + Environment.NewLine + "// </copyright>" + Environment.NewLine + "// <summary>" + Environment.NewLine
            + "// </summary>" + Environment.NewLine
            + "// --------------------------------------------------------------------------------------------------------------------";

        /// <summary>
        /// Company name.
        /// </summary>
        private string companyName;

        /// <summary>
        /// Copyright text.
        /// </summary>
        private string copyrightText;

        /// <summary>
        /// File name.
        /// </summary>
        private string fileName;

        /// <summary>
        /// Header xml.
        /// </summary>
        private XmlDocument headerXml;

        /// <summary>
        /// The summary.
        /// </summary>
        private string summary;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileHeader"/> class.
        /// </summary>
        /// <param name="file">
        /// The file to load the header for. 
        /// </param>
        public FileHeader(ICSharpFile file)
        {
            try
            {
                this.File = file;

                string headerText = Utils.GetFileHeader(file);

                if (string.IsNullOrEmpty(headerText))
                {
                    // no header provided so we'll load the default one
                    headerText = StandardHeader;
                }

                this.LoadFileHeader(headerText);
            }
            catch (XmlException)
            {
                this.ResetToStandardHeader();
            }
            catch (ArgumentException)
            {
                this.headerXml = null;
            }

            this.InsertSummary = true;
        }

        /// <summary>
        /// Gets or sets CompanyName. The text you pass in will be trimmed of whitespace.
        /// </summary>
        public string CompanyName
        {
            get
            {
                return this.companyName ?? string.Empty;
            }

            set
            {
                string trimmedValue = value.Trim();
                XmlAttribute companyAttribute = this.EnsureCompanyAttribute();

                companyAttribute.Value = trimmedValue;
                this.companyName = trimmedValue;
            }
        }

        /// <summary>
        /// Gets or sets CopyrightText. The text you pass in will be trimmed of whitespace.
        /// </summary>
        public string CopyrightText
        {
            get
            {
                return this.copyrightText ?? string.Empty;
            }

            set
            {
                string trimmedValue = value.Trim(Utils.TrimChars);
                XmlElement copyrightNode = this.EnsureCopyrightElement();

                // To support multiline copyright text
                string[] linesofCopyrightText = trimmedValue.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
                StringBuilder newValue = new StringBuilder();

                foreach (string copyrightLine in linesofCopyrightText)
                {
                    newValue.AppendFormat("{0}{1}{2}", FileHeaderIndentedLinePrefix, copyrightLine, Environment.NewLine);
                }

                copyrightNode.InnerText = string.Format("{0}{1}{2}", Environment.NewLine, newValue, FileHeaderLinePrefix);
                this.copyrightText = trimmedValue;
            }
        }

        /// <summary>
        /// Gets File.
        /// </summary>
        public ICSharpFile File { get; private set; }

        /// <summary>
        /// Gets or sets FileName. The text you pass in will be trimmed of whitespace.
        /// </summary>
        public string FileName
        {
            get
            {
                return this.fileName ?? string.Empty;
            }

            set
            {
                string trimmedValue = value.Trim();
                XmlAttribute fileAttribute = this.EnsureFileAttribute();

                fileAttribute.Value = trimmedValue;
                this.fileName = trimmedValue;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether InsertSummary.
        /// </summary>
        public bool InsertSummary { get; set; }

        /// <summary>
        /// Gets or sets Summary.
        /// </summary>
        public string Summary
        {
            get
            {
                return this.summary ?? string.Empty;
            }

            set
            {
                XmlElement summaryElement = this.EnsureSummaryElement(null);

                string trimmedValue = value.Trim(Utils.TrimChars);
                this.summary = trimmedValue;

                trimmedValue = Utils.RemoveBlankLinesFromMultiLineStringComment(trimmedValue, 3, CommentType.END_OF_LINE_COMMENT);
                summaryElement.InnerText = string.Format("{0}//   {1}{0}// ", Environment.NewLine, trimmedValue);
            }
        }

        /// <summary>
        /// Gets a value indicating whether the header has a UnStyled element.
        /// </summary>
        public bool UnStyled { get; private set; }

        /// <summary>
        /// Gets the correctly formatted header text string.
        /// </summary>
        /// <returns>
        /// A string of the correctly formatted header. 
        /// </returns>
        public string GetText()
        {
            XmlElement summaryElement = null;

            if (!this.InsertSummary)
            {
                summaryElement = this.headerXml.DocumentElement["summary"];
                if (summaryElement != null)
                {
                    if (summaryElement.PreviousSibling != null)
                    {
                        this.headerXml.DocumentElement.RemoveChild(summaryElement.PreviousSibling);
                    }

                    this.headerXml.DocumentElement.RemoveChild(summaryElement);
                }
            }

            string innerXmlForHeader = this.headerXml.DocumentElement.InnerXml;
            string decodedInnerXml = HttpUtility.HtmlDecode(innerXmlForHeader);

            if (!this.InsertSummary)
            {
                this.EnsureSummaryElement(summaryElement);
            }

            return decodedInnerXml;
        }

        /// <summary>
        /// Load file header.
        /// </summary>
        /// <param name="headerText">
        /// The header text. 
        /// </param>
        public void LoadFileHeader(string headerText)
        {
            this.headerXml = new XmlDocument { PreserveWhitespace = true };
            this.headerXml.LoadXml(string.Format(CultureInfo.InvariantCulture, "<root>{0}</root>", headerText));

            if (this.headerXml.DocumentElement != null)
            {
                StringCollection unstyledElements = new StringCollection();
                unstyledElements.AddRange(new[] { "unstyled", "stylecopoff", "nostyle" });

                XmlNodeList childNodes = this.headerXml.DocumentElement.ChildNodes;
                if (childNodes.Cast<XmlNode>().Any(xmlNode => unstyledElements.Contains(xmlNode.Name.ToLowerInvariant())))
                {
                    this.UnStyled = true;
                }

                this.EnsureCopyrightElement();
                this.EnsureCompanyAttribute();
                this.EnsureFileAttribute();
                this.EnsureSummaryElement(null);
                this.UpdateDashHeaderAndFooter();

                XmlElement copyrightNode = this.headerXml.DocumentElement["copyright"];
                if (copyrightNode != null)
                {
                    this.CopyrightText = copyrightNode.InnerText;

                    XmlAttribute fileNameAttribute = copyrightNode.Attributes["file"];
                    if (fileNameAttribute != null)
                    {
                        this.FileName = fileNameAttribute.Value;
                    }

                    XmlAttribute companyNameAttribute = copyrightNode.Attributes["company"];
                    if (companyNameAttribute != null)
                    {
                        this.CompanyName = companyNameAttribute.Value;
                    }
                }

                XmlElement summaryNode = this.headerXml.DocumentElement["summary"];

                if (summaryNode != null)
                {
                    this.Summary = summaryNode.InnerText;
                }
            }
        }

        /// <summary>
        /// Updates the current File with the current header text.
        /// </summary>
        public void Update()
        {
            SwapFileHeaderNode(this.File, this.GetText());
        }

        /// <summary>
        /// Gets the First Child Of Type XmlElement from the node provided.
        /// </summary>
        /// <param name="node">
        /// The node. 
        /// </param>
        /// <returns>
        /// The first XmlElement or null. 
        /// </returns>
        private static XmlNode GetFirstChildOfTypeXmlElement(XmlNode node)
        {
            for (int i = 0; i < node.ChildNodes.Count; i++)
            {
                XmlNode childNode = node.ChildNodes[i];
                if (childNode is XmlElement)
                {
                    return childNode;
                }
            }

            return null;
        }

        /// <summary>
        /// Gets the First Child Of Type XmlText from the node provided.
        /// </summary>
        /// <param name="node">
        /// The node. 
        /// </param>
        /// <returns>
        /// The first XmlText or null. 
        /// </returns>
        private static XmlNode GetFirstChildOfTypeXmlText(XmlNode node)
        {
            for (int i = 0; i < node.ChildNodes.Count; i++)
            {
                XmlNode childNode = node.ChildNodes[i];
                if (childNode is XmlText)
                {
                    return childNode;
                }
            }

            return null;
        }

        /// <summary>
        /// Gets the last Child Of Type XmlElement from the node provided.
        /// </summary>
        /// <param name="node">
        /// The node. 
        /// </param>
        /// <returns>
        /// The last XmlElement or null. 
        /// </returns>
        private static XmlNode GetLastChildOfTypeXmlElement(XmlNode node)
        {
            for (int i = node.ChildNodes.Count - 1; i >= 0; i--)
            {
                XmlNode childNode = node.ChildNodes[i];
                if (childNode is XmlElement)
                {
                    return childNode;
                }
            }

            return null;
        }

        private static void SwapFileHeaderNode(ICSharpFile file, string newHeader)
        {
            ITreeRange existingHeaderRange = Utils.GetFileHeaderTreeRange(file);

            using (WriteLockCookie.Create(file.IsPhysical()))
            {
                ICommentNode newCommentNode;

                if (existingHeaderRange.IsEmpty)
                {
                    // existing header missing so add on a new line for our new header
                    newHeader += Environment.NewLine;

                    IWhitespaceNode node = file.FirstChild as IWhitespaceNode;
                    bool insertNewLine = true;
                    while (node != null)
                    {
                        if (node.IsNewLine)
                        {
                            insertNewLine = false;
                            break;
                        }

                        node = node.NextSibling as IWhitespaceNode;
                    }

                    if (insertNewLine)
                    {
                        newHeader += Environment.NewLine;
                    }

                    newCommentNode =
                        (ICommentNode)
                        CSharpTokenType.END_OF_LINE_COMMENT.Create(new JetBrains.Text.StringBuffer(newHeader), new TreeOffset(0), new TreeOffset(newHeader.Length));

                    LowLevelModificationUtil.AddChildBefore(file.FirstChild, new ITreeNode[] { newCommentNode });
                }
                else
                {
                    ITokenNode lastToken = (ITokenNode)existingHeaderRange.Last;
                    ITokenNode nextToken = lastToken.GetNextToken();
                    if (nextToken != null)
                    {
                        ITokenNode nextNextToken = nextToken.GetNextToken();
                        if (nextNextToken != null)
                        {
                            ITokenNode nextNextNextToken = nextNextToken.GetNextToken();

                            if (!nextToken.IsNewLine() || !nextNextToken.IsNewLine())
                            {
                                newHeader += Environment.NewLine;
                            }

                            if (nextNextNextToken.GetTokenType() == CSharpTokenType.PP_SHARP && nextToken.IsNewLine() && nextNextToken.IsNewLine())
                            {
                                newHeader += Environment.NewLine;
                            }

                            newCommentNode =
                                (ICommentNode)
                                CSharpTokenType.END_OF_LINE_COMMENT.Create(
                                    new JetBrains.Text.StringBuffer(newHeader), new TreeOffset(0), new TreeOffset(newHeader.Length));

                            LowLevelModificationUtil.ReplaceChildRange(existingHeaderRange.First, existingHeaderRange.Last, new ITreeNode[] { newCommentNode });
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Ensure company attribute.
        /// </summary>
        /// <returns>
        /// An updated XmlAttribute for the company text. 
        /// </returns>
        private XmlAttribute EnsureCompanyAttribute()
        {
            XmlElement copyrightNode = this.EnsureCopyrightElement();

            XmlAttribute companyAttribute = copyrightNode.Attributes["company"];
            if (companyAttribute == null)
            {
                companyAttribute = this.headerXml.CreateAttribute("company");
                copyrightNode.Attributes.Append(companyAttribute);
            }

            return companyAttribute;
        }

        /// <summary>
        /// Ensure copyright element.
        /// </summary>
        /// <returns>
        /// An updated XmlElement for the copyright text. 
        /// </returns>
        private XmlElement EnsureCopyrightElement()
        {
            XmlElement copyrightNode = this.headerXml.DocumentElement["copyright"];
            if (copyrightNode == null)
            {
                copyrightNode = this.headerXml.CreateElement("copyright");

                // This is to put a CR/LF after the node so summary is on a new line
                XmlText xmlText = this.headerXml.CreateTextNode(string.Format("{0}// ", Environment.NewLine));

                XmlNode insertNode = GetFirstChildOfTypeXmlElement(this.headerXml.DocumentElement);
                if (insertNode != null)
                {
                    this.headerXml.DocumentElement.InsertBefore(copyrightNode, insertNode);
                    this.headerXml.DocumentElement.InsertAfter(xmlText, copyrightNode);
                }

                if (insertNode == null)
                {
                    insertNode = GetFirstChildOfTypeXmlText(this.headerXml.DocumentElement);
                    if (insertNode != null)
                    {
                        this.headerXml.DocumentElement.InsertBefore(copyrightNode, insertNode);
                        this.headerXml.DocumentElement.InsertAfter(xmlText, copyrightNode);
                    }
                    else
                    {
                        this.headerXml.DocumentElement.AppendChild(copyrightNode);
                        this.headerXml.DocumentElement.InsertAfter(xmlText, copyrightNode);
                    }
                }
            }

            return copyrightNode;
        }

        /// <summary>
        /// Ensure file attribute.
        /// </summary>
        /// <returns>
        /// An updated XmlElement with the file element updated. 
        /// </returns>
        private XmlAttribute EnsureFileAttribute()
        {
            XmlElement copyrightNode = this.EnsureCopyrightElement();

            XmlAttribute fileAttribute = copyrightNode.Attributes["file"];
            if (fileAttribute == null)
            {
                fileAttribute = this.headerXml.CreateAttribute("file");
                copyrightNode.Attributes.Append(fileAttribute);
            }

            return fileAttribute;
        }

        /// <summary>
        /// Ensure summary element.
        /// </summary>
        /// <param name="newSummaryElement">
        /// The new Summary Element. 
        /// </param>
        /// <returns>
        /// An updated XmlElement with the summary inserted. 
        /// </returns>
        private XmlElement EnsureSummaryElement(XmlElement newSummaryElement)
        {
            XmlElement summaryElement = this.headerXml.DocumentElement["summary"];

            if (summaryElement == null)
            {
                if (newSummaryElement == null)
                {
                    summaryElement = this.headerXml.CreateElement("summary");
                }
                else
                {
                    summaryElement = newSummaryElement;
                }

                // This is to put a CR/LF after the preceding node so summary is on a new line
                XmlText xmlText = this.headerXml.CreateTextNode(string.Format("{0}// ", Environment.NewLine));

                XmlNode insertAfterNode = GetLastChildOfTypeXmlElement(this.headerXml.DocumentElement);
                this.headerXml.DocumentElement.InsertAfter(xmlText, insertAfterNode);
                this.headerXml.DocumentElement.InsertAfter(summaryElement, xmlText);
            }

            return summaryElement;
        }

        private void ResetToStandardHeader()
        {
            // no header provided so we'll load the default one
            string headerText = StandardHeader;
            this.LoadFileHeader(headerText);
        }

        /// <summary>
        /// Update dash header and footer.
        /// </summary>
        private void UpdateDashHeaderAndFooter()
        {
            if (this.headerXml == null)
            {
                return;
            }

            IContextBoundSettingsStore settingsStore = PsiSourceFileExtensions.GetSettingsStore(null, this.File.GetSolution());
            int dashCount = settingsStore.GetValue((StyleCopOptionsSettingsKey key) => key.DashesCountInFileHeader);
            string dashes = new string('-', dashCount);

            XmlText xmlTextTop = this.headerXml.CreateTextNode(string.Format("// {0}{1}// ", dashes, Environment.NewLine));
            if (this.headerXml.DocumentElement.FirstChild.NodeType == XmlNodeType.Text)
            {
                this.headerXml.DocumentElement.ReplaceChild(xmlTextTop, this.headerXml.DocumentElement.FirstChild);
            }
            else
            {
                this.headerXml.DocumentElement.InsertBefore(xmlTextTop, this.headerXml.DocumentElement.FirstChild);
            }

            XmlText xmlTextBottom = this.headerXml.CreateTextNode(string.Format("{0}// {1}", Environment.NewLine, dashes));

            if (this.headerXml.DocumentElement.LastChild.NodeType == XmlNodeType.Text)
            {
                this.headerXml.DocumentElement.ReplaceChild(xmlTextBottom, this.headerXml.DocumentElement.LastChild);
            }
            else
            {
                this.headerXml.DocumentElement.InsertAfter(xmlTextBottom, this.headerXml.DocumentElement.LastChild);
            }
        }
    }
}