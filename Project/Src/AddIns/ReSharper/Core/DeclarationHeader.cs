// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DeclarationHeader.cs" company="http://stylecop.codeplex.com">
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
//   Provides a wrapper for a declaration elements documentation comments.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.ReSharper.Core
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Xml;

    using JetBrains.Application.Settings;
    using JetBrains.ReSharper.Psi;
    using JetBrains.ReSharper.Psi.CSharp;
    using JetBrains.ReSharper.Psi.CSharp.Tree;
    using JetBrains.ReSharper.Psi.ExtensionsAPI.Tree;
    using JetBrains.ReSharper.Psi.Tree;
    using JetBrains.ReSharper.Resources.Shell;

    using StyleCop.ReSharper.CodeCleanup.Rules;
    using StyleCop.ReSharper.Extensions;
    using StyleCop.ReSharper.Options;

    /// <summary>
    /// Provides a wrapper for a declaration elements documentation comments.
    /// </summary>
    public class DeclarationHeader
    {
        private static readonly ArrayList ElementsThatStartOnNewLine;

        private static readonly ArrayList ElementsThatStartOnNewLineAndHaveNewLineOnInnerXml;

        /// <summary>
        /// Initializes static members of the <see cref="DeclarationHeader"/> class.
        /// </summary>
        static DeclarationHeader()
        {
            // These elements will always start on a new line. Their InnerXml doesn't start on a new line.
            // The exception is the <para> element. If it contains -or- the InnerXml is not on a new line.
            ElementsThatStartOnNewLine = new ArrayList(new[] { "description", "exclude", "include", "para", "seealso", "term", "threadsafety" });

            // These elements always start on a new line and their InnerXml starts on a new line.
            // The exception is the <para> element. If it contains -or- the InnerXml is not on a new line.
            ElementsThatStartOnNewLineAndHaveNewLineOnInnerXml =
                new ArrayList(
                    new[]
                        {
                            "code", "event", "example", "exception", "item", "list", "listheader", "note", "overloads", "para", "param", "permission", "preliminary", 
                            "remarks", "returns", "summary", "typeparam", "value"
                        });
        }

        /// <summary>
        /// Initializes a new instance of the DeclarationHeader class.
        /// </summary>
        /// <param name="declaration">
        /// The declaration to use.
        /// </param>
        public DeclarationHeader(IDeclaration declaration)
        {
            this.Init(declaration);
        }

        /// <summary>
        /// Gets the declaration we have the header for.
        /// </summary>
        public IDeclaration Declaration { get; private set; }

        /// <summary>
        /// Gets the DocCommentBlockNode for the declaration.
        /// </summary>
        public IDocCommentBlock DocCommentBlockNode { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the summary element is empty.
        /// </summary>
        /// <returns>
        /// True if its empty (or missing).
        /// </returns>
        public bool HasEmptySummary
        {
            get
            {
                if (this.IsMissing || !this.HasSummary)
                {
                    return true;
                }

                return string.IsNullOrEmpty(Utils.GetTextFromDeclarationHeader(this.SummaryXmlNode).Trim());
            }
        }

        /// <summary>
        /// Gets a value indicating whether the header has a Returns element.
        /// </summary>
        public bool HasReturns { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the header has a summary element.
        /// </summary>
        public bool HasSummary { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the header has a value element.
        /// </summary>
        public bool HasValue { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the header has an <c>inheritdoc</c> element.
        /// </summary>
        public bool IsInherited { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the header is missing or not.
        /// </summary>
        public bool IsMissing { get; private set; }

        /// <summary>
        /// Gets the returns node of the documentation header. Null if it is missing.
        /// </summary>
        public XmlNode ReturnsXmlNode { get; private set; }

        /// <summary>
        /// Gets the summary node of the documentation header. Null if it is missing.
        /// </summary>
        public XmlNode SummaryXmlNode { get; private set; }

        /// <summary>
        /// Gets the value node of the documentation header. Null if it is missing.
        /// </summary>
        public XmlNode ValueXmlNode { get; private set; }

        /// <summary>
        /// Gets the XmlNode of the entire declaration header. Null if it is missing.
        /// </summary>
        public XmlNode XmlNode { get; private set; }

        /// <summary>
        /// Creates a new DeclarationHeader for the declaration and assigns it to the declaration.
        /// </summary>
        /// <param name="declaration">
        /// The declaration to create the header for.
        /// </param>
        /// <param name="docConfig">
        /// Provides the configuration for the current ProjectFile.
        /// </param>
        /// <returns>
        /// A DeclarationHeader for the declaration passed in.
        /// </returns>
        public static DeclarationHeader CreateNewHeader(IDeclaration declaration, DocumentationRulesConfiguration docConfig)
        {
            IFile file = declaration.GetContainingFile();
            using (WriteLockCookie.Create(file.IsPhysical()))
            {
                IDeclaration declarationTreeNode = declaration;

                IContextBoundSettingsStore settingsStore = PsiSourceFileExtensions.GetSettingsStore(null, declaration.GetSolution());
                bool useSingleLineDeclarationComments = settingsStore.GetValue((StyleCopOptionsSettingsKey key) => key.UseSingleLineDeclarationComments);
                string middleText = useSingleLineDeclarationComments ? string.Empty : Environment.NewLine;

                string emptyDocHeader = string.Format("<summary>{0}</summary>", middleText);

                if (!(declarationTreeNode is IMultipleDeclarationMember))
                {
                    emptyDocHeader = CreateDocumentationForElement((IDocCommentBlockOwner)declaration, docConfig);
                    emptyDocHeader = emptyDocHeader.Substring(0, emptyDocHeader.Length - Environment.NewLine.Length);
                }

                string header = LayoutDocumentationHeader(emptyDocHeader, declaration);

                IDocCommentBlock newDocCommentNode = Utils.CreateDocCommentBlockNode(file, header);

                IDocCommentBlockOwner docCommentBlockOwnerNode = Utils.GetDocCommentBlockOwnerNodeForDeclaration(declaration);

                if (docCommentBlockOwnerNode != null)
                {
                    docCommentBlockOwnerNode.SetDocCommentBlock(newDocCommentNode);
                }

                return new DeclarationHeader(declaration);
            }
        }

        /// <summary>
        /// Determines whether a parameter is declared in the comments header.
        /// </summary>
        /// <param name="parameterName">
        /// The parameter name to search for.
        /// </param>
        /// <returns>
        /// A <see cref="bool"/> of whether a parameter is declared in the header.
        /// </returns>
        public bool ContainsParameter(string parameterName)
        {
            Param.RequireValidString(parameterName, "parameterName");

            string query = string.Format("//param[@name='{0}']", parameterName);
            XmlNode node = this.XmlNode.SelectSingleNode(query);

            return node != null;
        }

        /// <summary>
        /// Determines whether a type parameter is declared in the comments header.
        /// </summary>
        /// <param name="parameterName">
        /// The parameter name to search for.
        /// </param>
        /// <returns>
        /// A <see cref="bool"/> of whether a type parameter is declared in the header.
        /// </returns>
        public bool ContainsTypeParameter(string parameterName)
        {
            Param.RequireValidString(parameterName, "parameterName");

            string query = string.Format("//typeparam[@name='{0}']", parameterName);
            XmlNode node = this.XmlNode.SelectSingleNode(query);

            return node != null;
        }

        /// <summary>
        /// Updates the elements header with the current xml.
        /// </summary>
        public void Update()
        {
            if (this.DocCommentBlockNode != null)
            {
                IFile file = this.Declaration.GetContainingFile();

                using (this.DocCommentBlockNode.CreateWriteLock())
                {
                    string header = LayoutDocumentationHeader(this.XmlNode, this.Declaration);
                    IDocCommentBlock newDocCommentNode = Utils.CreateDocCommentBlockNode(file, header);

                    if (newDocCommentNode == null)
                    {
                        ModificationUtil.DeleteChild(this.DocCommentBlockNode);
                    }
                    else
                    {
                        ModificationUtil.ReplaceChild(this.DocCommentBlockNode, newDocCommentNode);
                    }
                }
            }
        }

        /// <summary>
        /// Finds Exceptions in a TreeNode and all its children.
        /// </summary>
        /// <param name="node">
        /// The node to start at.
        /// </param>
        /// <param name="exceptions">
        /// The exceptions found.
        /// </param>
        private static void CollectExceptions(ITreeNode node, IList<IType> exceptions)
        {
            if (node is IThrowStatement)
            {
                IThrowStatement throwStatement = (IThrowStatement)node;
                ICSharpExpression expression = throwStatement.Exception;
                if (expression != null)
                {
                    if (!exceptions.Contains(expression.Type()))
                    {
                        exceptions.Add(expression.Type());
                    }
                }
            }
            else
            {
                for (ITreeNode child = node.FirstChild; child != null; child = child.NextSibling)
                {
                    CollectExceptions(child, exceptions);
                }
            }
        }

        /// <summary>
        /// Finds exceptions in the declaration provided.
        /// </summary>
        /// <param name="accessorDeclarations">
        /// The accessor to start at.
        /// </param>
        /// <param name="exceptions">
        /// The exceptions found.
        /// </param>
        private static void CollectExceptions(IEnumerable<IAccessorDeclaration> accessorDeclarations, IList<IType> exceptions)
        {
            foreach (IAccessorDeclaration accessorDeclaration in accessorDeclarations)
            {
                IBlock body = accessorDeclaration.Body;
                if (body != null)
                {
                    CollectExceptions(body, exceptions);
                }
            }
        }

        /// <summary>
        /// Returns an xml string of the documentation for an element.
        /// </summary>
        /// <param name="owner">
        /// The owner of the doc comment block.
        /// </param>
        /// <param name="docConfig">
        /// The config for the current ProjectFile.
        /// </param>
        /// <returns>
        /// A string of the declarations summary text.
        /// </returns>
        private static string CreateDocumentationForElement(IDocCommentBlockOwner owner, DocumentationRulesConfiguration docConfig)
        {
            ITreeNode element = owner;
            IDeclaredElement declaredElement = (element is IDeclaration) ? ((IDeclaration)element).DeclaredElement : null;
            StringBuilder text = new StringBuilder();
            text.AppendLine("<summary>");
            string summaryText = string.Empty;
            if (element is IConstructorDeclaration)
            {
                summaryText = Utils.CreateSummaryForConstructorDeclaration((IConstructorDeclaration)element);
            }

            if (element is IDestructorDeclaration)
            {
                summaryText = Utils.CreateSummaryForDestructorDeclaration((IDestructorDeclaration)element);
            }

            if (element is IPropertyDeclaration)
            {
                summaryText = Utils.CreateSummaryDocumentationForProperty((IPropertyDeclaration)element);
            }

            text.AppendLine(summaryText);
            text.AppendLine("</summary>");

            ICSharpParametersOwnerDeclaration declarationWithParameters = element as ICSharpParametersOwnerDeclaration;
            if (declarationWithParameters != null)
            {
                foreach (ICSharpParameterDeclaration parameterDeclaration in declarationWithParameters.ParameterDeclarations)
                {
                    text.AppendLine(Utils.CreateDocumentationForParameter(parameterDeclaration));
                }
            }

            ICSharpTypeDeclaration typeDeclaration = element as ICSharpTypeDeclaration;
            if (typeDeclaration != null && (typeDeclaration.TypeParameters.Count > 0))
            {
                foreach (ITypeParameterOfTypeDeclaration typeParameter in typeDeclaration.TypeParameters)
                {
                    text.AppendLine(Utils.CreateDocumentationForParameter(typeParameter));
                }
            }

            ITypeParametersOwner typeParametersOwner = element as ITypeParametersOwner;
            if (typeParametersOwner != null && (typeParametersOwner.TypeParameters.Count > 0))
            {
                foreach (ITypeParameter typeParameter in typeParametersOwner.TypeParameters)
                {
                    text.AppendLine(Utils.CreateDocumentationForTypeParameterDeclaration((ITypeParameterDeclaration)typeParameter));
                }
            }

            IMethodDeclaration methodDeclaration = element as IMethodDeclaration;
            if (methodDeclaration != null && (methodDeclaration.TypeParameterDeclarations.Count > 0))
            {
                foreach (ITypeParameterOfMethodDeclaration typeParameter in methodDeclaration.TypeParameterDeclarations)
                {
                    text.AppendLine(Utils.CreateDocumentationForParameter(typeParameter));
                }
            }

            IParametersOwner parametersOwner = declaredElement as IParametersOwner;
            if ((parametersOwner != null && ((parametersOwner is IMethod) || (parametersOwner is IOperator)))
                && !parametersOwner.ReturnType.Equals(parametersOwner.Module.GetPredefinedType().Void))
            {
                text.AppendLine("<returns></returns>");
            }

            bool ruleIsEnabled = docConfig.GetStyleCopRuleEnabled("PropertyDocumentationMustHaveValue");

            if (element is IPropertyDeclaration && ruleIsEnabled)
            {
                text.AppendLine(Utils.CreateValueDocumentationForProperty((IPropertyDeclaration)element));
            }

            List<IType> exceptions = new List<IType>();
            ICSharpFunctionDeclaration functionDeclaration = element as ICSharpFunctionDeclaration;
            if (functionDeclaration != null && functionDeclaration.Body != null)
            {
                CollectExceptions(functionDeclaration.Body, exceptions);
            }

            IPropertyDeclaration propertyDeclaration = element as IPropertyDeclaration;
            if (propertyDeclaration != null)
            {
                CollectExceptions(propertyDeclaration.AccessorDeclarations, exceptions);
            }

            IIndexerDeclaration indexerDeclaration = element as IIndexerDeclaration;
            if (indexerDeclaration != null)
            {
                CollectExceptions(indexerDeclaration.AccessorDeclarations, exceptions);
            }

            IEventDeclaration eventDeclaration = element as IEventDeclaration;
            if (eventDeclaration != null)
            {
                CollectExceptions(eventDeclaration.AccessorDeclarations, exceptions);
            }

            foreach (IType exception in exceptions)
            {
                string presentableName = exception.GetPresentableName(CSharpLanguage.Instance);

                string a = Utils.StripClassName(presentableName);
                text.AppendLine("<exception cref=\"" + Utils.SwapGenericTypeToDocumentation(a) + "\"></exception>");
            }

            return text.ToString();
        }

        /// <summary>
        /// Returns the xml for the given declaration or null.
        /// </summary>
        /// <param name="declaration">
        /// The declaration to get the docs for.
        /// </param>
        /// <returns>
        /// An XmlNode of the docs.
        /// </returns>
        private static XmlNode GetXmlNodeForDeclaration(IDeclaration declaration)
        {
            IDeclaration declarationTreeNode = declaration;

            ITreeNode treeNode = declarationTreeNode is IMultipleDeclarationMember ? declarationTreeNode.Parent.FirstChild : declarationTreeNode.FirstChild;

            XmlNode node;
            StringBuilder text = new StringBuilder();

            text.AppendLine("<member>");

            for (ITreeNode child = treeNode.FirstChild; child != null; child = child.NextSibling)
            {
                if (child.IsNewLine())
                {
                    text.AppendLine(string.Empty);
                    continue;
                }

                IDocCommentNode docCommentNode = child as IDocCommentNode;
                if (docCommentNode != null)
                {
                    text.Append(docCommentNode.CommentText);
                }
            }

            text.AppendLine("</member>");
            try
            {
                XmlDocument xmlDoc = new XmlDocument { PreserveWhitespace = true };
                xmlDoc.LoadXml(text.ToString());
                node = xmlDoc.SelectSingleNode("member");
            }
            catch (XmlException)
            {
                return null;
            }

            return node;
        }

        /// <summary>
        /// Builds a xml doc header from the string passed in all set out correctly.
        /// </summary>
        /// <param name="header">
        /// The text to use to build the header.
        /// </param>
        /// <param name="declaration">
        /// The declaration we start with.
        /// </param>
        /// <returns>
        /// A String of the correctly formatted header.
        /// </returns>
        private static string LayoutDocumentationHeader(string header, IDeclaration declaration)
        {
            StringBuilder text = new StringBuilder();
            text.AppendLine("<member>");
            text.AppendLine(header);
            text.AppendLine("</member>");

            XmlDocument xmlDoc = new XmlDocument { PreserveWhitespace = true };
            xmlDoc.LoadXml(text.ToString());

            return LayoutDocumentationHeader(xmlDoc.SelectSingleNode("member"), declaration);
        }

        /// <summary>
        /// Takes the XmlNode and creates a formatted StringBuilder of it all formatted lovely.
        /// </summary>
        /// <param name="xml">
        /// The xml to use.
        /// </param>
        /// <param name="declaration">
        /// The declaration we start with.
        /// </param>
        /// <returns>
        /// A String all formatted.
        /// </returns>
        private static string LayoutDocumentationHeader(XmlNode xml, IDeclaration declaration)
        {
            StringBuilder pattern = new StringBuilder();
            StringWriter writer = new StringWriter(pattern);

            bool writtenNewLine = true;
            IContextBoundSettingsStore settingsStore = PsiSourceFileExtensions.GetSettingsStore(null, declaration.GetSolution());
            bool useSingleLineDeclarationComments = settingsStore.GetValue((StyleCopOptionsSettingsKey key) => key.UseSingleLineDeclarationComments);

            LayoutDocumentationXml(xml, writer, ref writtenNewLine, useSingleLineDeclarationComments);

            if (pattern.ToString().EndsWith(Environment.NewLine))
            {
                pattern.Remove(pattern.Length - Environment.NewLine.Length, Environment.NewLine.Length);
            }

            if (pattern.ToString().StartsWith(Environment.NewLine))
            {
                pattern.Remove(0, Environment.NewLine.Length);
            }

            return pattern.ToString().Trim();
        }

        /// <summary>
        /// Fills the TextWriter with the xml all formatted lovely.
        /// </summary>
        /// <param name="xml">
        /// The xml to use.
        /// </param>
        /// <param name="writer">
        /// The writer to use.
        /// </param>
        /// <param name="writtenNewLine">
        /// True if a newline was the last item written to the TextWriter.
        /// </param>
        /// <param name="useSingleLineDeclarationComments">
        /// False pushes newlines in after all element tags.
        /// </param>
        private static void LayoutDocumentationXml(XmlNode xml, TextWriter writer, ref bool writtenNewLine, bool useSingleLineDeclarationComments)
        {
            switch (xml.NodeType)
            {
                case XmlNodeType.Element:
                    {
                        XmlElement element = (XmlElement)xml;
                        string elementName = element.Name;
                        if (elementName == "member")
                        {
                            foreach (XmlNode childNode in xml.ChildNodes)
                            {
                                LayoutDocumentationXml(childNode, writer, ref writtenNewLine, useSingleLineDeclarationComments);
                            }

                            break;
                        }

                        string strippedInnerText = xml.InnerText.Replace(" ", string.Empty).Replace("-", string.Empty).ToLowerInvariant();

                        if (ElementsThatStartOnNewLineAndHaveNewLineOnInnerXml.Contains(elementName) && strippedInnerText != "or")
                        {
                            if (!writtenNewLine)
                            {
                                writer.WriteLine();
                            }

                            writer.Write('<');
                            writer.Write(xml.Name);

                            foreach (XmlAttribute xmlAttribute in element.Attributes)
                            {
                                writer.Write(' ');
                                writer.Write(xmlAttribute.Name);
                                writer.Write('=');
                                writer.Write('"');
                                writer.Write(xmlAttribute.Value);
                                writer.Write('"');
                            }

                            writer.Write('>');

                            if (!useSingleLineDeclarationComments)
                            {
                                writer.WriteLine();
                                writtenNewLine = true;
                            }

                            foreach (XmlNode childNode in xml.ChildNodes)
                            {
                                LayoutDocumentationXml(childNode, writer, ref writtenNewLine, useSingleLineDeclarationComments);
                            }

                            if (!writtenNewLine && !useSingleLineDeclarationComments)
                            {
                                writer.WriteLine();
                            }

                            writer.Write("</");
                            writer.Write(elementName);
                            writer.Write('>');
                            writer.WriteLine();
                            writtenNewLine = true;
                            return;
                        }

                        if (!useSingleLineDeclarationComments && ElementsThatStartOnNewLine.Contains(elementName) && !writtenNewLine)
                        {
                            writer.WriteLine();
                        }

                        writer.Write(element.OuterXml);
                        writtenNewLine = false;

                        if (!useSingleLineDeclarationComments && ElementsThatStartOnNewLine.Contains(elementName))
                        {
                            writer.WriteLine();
                            writtenNewLine = true;
                        }

                        return;
                    }

                default:

                    // if the text is '\r\n ' then dont write anything out
                    string text = xml.OuterXml;

                    if (writtenNewLine)
                    {
                        if (text.StartsWith(Environment.NewLine))
                        {
                            text = text.Substring(Environment.NewLine.Length);
                        }

                        text = text.TrimStart(' ');
                    }

                    if (useSingleLineDeclarationComments && text.TrimEnd(' ').EndsWith(Environment.NewLine))
                    {
                        text = text.TrimEnd(' ').TrimEnd(Environment.NewLine.ToCharArray());
                    }

                    if (text.TrimStart() != string.Empty || !writtenNewLine)
                    {
                        writer.Write(text);
                        writtenNewLine = false;
                    }

                    // only trim space off and not NewLines
                    string textTrimmedEnd = text.TrimEnd(' ');
                    if (textTrimmedEnd.EndsWith(Environment.NewLine))
                    {
                        writtenNewLine = true;
                    }

                    break;
            }
        }

        /// <summary>
        /// Initializes this type.
        /// </summary>
        /// <param name="declaration">
        /// The declaration.
        /// </param>
        private void Init(IDeclaration declaration)
        {
            if (declaration == null)
            {
                this.IsMissing = true;
                return;
            }

            this.Declaration = declaration;

            this.DocCommentBlockNode = Utils.GetDocCommentBlockNodeForDeclaration(declaration);
            if (this.DocCommentBlockNode == null)
            {
                this.IsMissing = true;
            }
            else
            {
                this.XmlNode = GetXmlNodeForDeclaration(declaration);

                if (this.XmlNode == null)
                {
                    this.IsMissing = true;
                }
                else
                {
                    if (this.XmlNode.SelectSingleNode("//inheritdoc") != null)
                    {
                        this.IsInherited = true;
                    }

                    XmlNode node = this.XmlNode.SelectSingleNode("//summary");
                    if (node != null)
                    {
                        this.HasSummary = true;
                        this.SummaryXmlNode = node;
                    }

                    node = this.XmlNode.SelectSingleNode("//returns");
                    if (node != null)
                    {
                        this.HasReturns = true;
                        this.ReturnsXmlNode = node;
                    }

                    node = this.XmlNode.SelectSingleNode("//value");
                    if (node != null)
                    {
                        this.HasValue = true;
                        this.ValueXmlNode = node;
                    }
                }
            }
        }
    }
}