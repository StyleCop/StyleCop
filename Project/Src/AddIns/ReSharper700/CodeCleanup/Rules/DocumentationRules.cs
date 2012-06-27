// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DocumentationRules.cs" company="http://stylecop.codeplex.com">
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
//   Declaration comments fixes SA1600, SA1602, SA1611, SA1615, SA1617, SA1642.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

extern alias JB;

namespace StyleCop.ReSharper700.CodeCleanup.Rules
{
    #region Using Directives

    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Globalization;
    using System.Xml;

    using JetBrains.Application.Settings;
    using JetBrains.ReSharper.Psi;
    using JetBrains.ReSharper.Psi.CSharp.Parsing;
    using JetBrains.ReSharper.Psi.CSharp.Tree;
    using JetBrains.ReSharper.Psi.CSharp.Tree.Extensions;
    using JetBrains.ReSharper.Psi.ExtensionsAPI;
    using JetBrains.ReSharper.Psi.Impl.Types;
    using JetBrains.ReSharper.Psi.Tree;

    using StyleCop.CSharp;
    using StyleCop.Diagnostics;
    using StyleCop.ReSharper700.CodeCleanup.Options;
    using StyleCop.ReSharper700.CodeCleanup.Styles;
    using StyleCop.ReSharper700.Core;
    using StyleCop.ReSharper700.Options;

    #endregion

    /// <summary>
    /// Declaration comments fixes SA1600, SA1602, SA1611, SA1615, SA1617, SA1642.
    /// </summary>
    public class DocumentationRules
    {
        #region Public Methods

        /// <summary>
        /// Ensures that the constructor documentation starts with the standard text summary. 
        /// </summary>
        /// <remarks>
        /// Keeps the existing comment, but prepends the standard text.
        /// </remarks>
        /// <param name="constructorDeclaration">
        /// The destructor <see cref="IDeclaration"/>.
        /// </param>
        public void EnsureConstructorSummaryDocBeginsWithStandardText(IConstructorDeclaration constructorDeclaration)
        {
            if (constructorDeclaration == null)
            {
                return;
            }

            var settingsStore = PsiSourceFileExtensions.GetSettingsStore(null, constructorDeclaration.GetSolution());
            if (!settingsStore.GetValue((StyleCopOptionsSettingsKey key) => key.InsertTextIntoDocumentation))
            {
                return;
            }

            var declarationHeader = new DeclarationHeader(constructorDeclaration);

            if (declarationHeader.IsMissing || declarationHeader.IsInherited || !declarationHeader.HasSummary)
            {
                return;
            }

            var existingSummaryText = declarationHeader.SummaryXmlNode.InnerXml;

            var parentIsStruct = Utils.IsContainingTypeAStruct(constructorDeclaration);

            var constructorParameterCount = constructorDeclaration.ParameterDeclarations.Count;

            var xmlComment = Utils.GetTextFromDeclarationHeader(declarationHeader.XmlNode);
            var structOrClass = parentIsStruct ? CachedCodeStrings.StructText : CachedCodeStrings.ClassText;
            string textWeShouldStartWith;

            if (constructorDeclaration.IsStatic)
            {
                textWeShouldStartWith = string.Format(CultureInfo.InvariantCulture, CachedCodeStrings.HeaderSummaryForStaticConstructor, constructorDeclaration.DeclaredName, structOrClass);
            }
            else if (constructorDeclaration.GetAccessRights() == AccessRights.PRIVATE && constructorParameterCount == 0)
            {
                textWeShouldStartWith = string.Format(CultureInfo.InvariantCulture, CachedCodeStrings.HeaderSummaryForPrivateInstanceConstructor, constructorDeclaration.DeclaredName, structOrClass);
            }
            else
            {
                var constructorDescriptionText = Utils.CreateConstructorDescriptionText(constructorDeclaration, true);
                textWeShouldStartWith = string.Format(CultureInfo.InvariantCulture, CachedCodeStrings.HeaderSummaryForInstanceConstructor, constructorDescriptionText, structOrClass);
            }

            if (constructorDeclaration.IsStatic)
            {
                var docStd = string.Format("Initializes the {0} class.", constructorDeclaration.DeclaredName);
                if (xmlComment == docStd)
                {
                    existingSummaryText = string.Empty;
                }
            }

            if (!xmlComment.StartsWith(textWeShouldStartWith, StringComparison.Ordinal))
            {
                var newSummaryText = Utils.CreateSummaryForConstructorDeclaration(constructorDeclaration);

                declarationHeader.SummaryXmlNode.InnerXml = newSummaryText + " " + existingSummaryText;

                declarationHeader.Update();
            }
        }

        /// <summary>
        /// Ensures that the destructor documentation starts with the standard text summary. 
        /// </summary>
        /// <remarks>
        /// Keeps the existing comment, but prepends the standard text.
        /// </remarks>
        /// <param name="destructorDeclaration">
        /// The destructor <see cref="IDeclaration"/>.
        /// </param>
        public void EnsureDestructorSummaryDocBeginsWithStandardText(IDestructorDeclaration destructorDeclaration)
        {
            if (destructorDeclaration == null)
            {
                return;
            }

            var declarationHeader = new DeclarationHeader(destructorDeclaration);

            if (declarationHeader.IsMissing || declarationHeader.IsInherited || !declarationHeader.HasSummary)
            {
                return;
            }

            var settingsStore = PsiSourceFileExtensions.GetSettingsStore(null, destructorDeclaration.GetSolution());
            if (!settingsStore.GetValue((StyleCopOptionsSettingsKey key) => key.InsertTextIntoDocumentation))
            {
                return;
            }

            var destructorDescriptionText = Utils.CreateDestructorDescriptionText(destructorDeclaration, true);

            var xmlComment = Utils.GetTextFromDeclarationHeader(declarationHeader.XmlNode);

            var textWeShouldStartWith = string.Format(CultureInfo.InvariantCulture, CachedCodeStrings.HeaderSummaryForDestructor, destructorDescriptionText);

            if (!xmlComment.StartsWith(textWeShouldStartWith, StringComparison.Ordinal))
            {
                var summaryText = Utils.CreateSummaryForDestructorDeclaration(destructorDeclaration);

                declarationHeader.SummaryXmlNode.InnerXml = Environment.NewLine + summaryText;

                declarationHeader.Update();
            }
        }

        /// <summary>
        /// Ensures the declaration passed has no blank lines unless inside code elements.
        /// </summary>
        /// <param name="declaration">
        /// The destructor <see cref="IDeclaration"/>.
        /// </param>
        public void EnsureDocumentationHasNoBlankLines(IDeclaration declaration)
        {
            var declarationHeader = new DeclarationHeader(declaration);

            if (declarationHeader.IsMissing || declarationHeader.IsInherited)
            {
                return;
            }

            this.RemoveBlankLines(declarationHeader.XmlNode);
            declarationHeader.Update();
        }

        /// <summary>
        /// Ensures the declaration passed has its comments ending with a full stop.
        /// </summary>
        /// <param name="declaration">
        /// The destructor <see cref="IDeclaration"/>.
        /// </param>
        public void EnsureDocumentationTextEndsWithAPeriod(IDeclaration declaration)
        {
            var settingsStore = PsiSourceFileExtensions.GetSettingsStore(null, declaration.GetSolution());
            if (!settingsStore.GetValue((StyleCopOptionsSettingsKey key) => key.InsertTextIntoDocumentation))
            {
                return;
            }

            var declarationHeader = new DeclarationHeader(declaration);
            if (declarationHeader.IsMissing || declarationHeader.IsInherited)
            {
                return;
            }

            this.EnsureTerminatingPeriod(declarationHeader.XmlNode);
            declarationHeader.Update();
        }

        /// <summary>
        /// Ensures the declaration passed has its comments beginning with a capital letter.
        /// </summary>
        /// <param name="declaration">
        /// The destructor <see cref="IDeclaration"/>.
        /// </param>
        public void EnsureDocumentationTextIsUppercase(IDeclaration declaration)
        {
            var settingsStore = PsiSourceFileExtensions.GetSettingsStore(null, declaration.GetSolution());
            if (!settingsStore.GetValue((StyleCopOptionsSettingsKey key) => key.InsertTextIntoDocumentation))
            {
                return;
            }

            var declarationHeader = new DeclarationHeader(declaration);

            if (declarationHeader.IsMissing || declarationHeader.IsInherited)
            {
                return;
            }

            this.SwapToUpper(declarationHeader.XmlNode);
            declarationHeader.Update();
        }

        /// <summary>
        /// Execute comments processing for declarations.
        /// </summary>
        /// <param name="options">
        /// The <see cref="OrderingOptions"/> to use.
        /// </param>
        /// <param name="file">
        /// The <see cref="ICSharpFile"/> to use.
        /// </param>
        public void Execute(DocumentationOptions options, ICSharpFile file)
        {
            StyleCopTrace.In(options, file);

            Param.RequireNotNull(options, "options");
            Param.RequireNotNull(file, "file");

            foreach (var namespaceDeclaration in file.NamespaceDeclarations)
            {
                this.ProcessCSharpTypeDeclarations(options, file, namespaceDeclaration.TypeDeclarations);
            }

            this.ProcessCSharpTypeDeclarations(options, file, file.TypeDeclarations);

            var fixSingleLineCommentsOption = options.SA1626SingleLineCommentsMustNotUseDocumentationStyleSlashes;

            if (fixSingleLineCommentsOption)
            {
                this.SwapDocCommentsToSingleLineComments(file.FirstChild);
            }

            this.UpdateFileHeader(options, file);
            StyleCopTrace.Out();
        }

        /// <summary>
        /// Returns a config object exposing the current config settings for this file.
        /// </summary>
        /// <param name="file">
        /// The file to get the config for.
        /// </param>
        /// <returns>
        /// The configuration for the given file.
        /// </returns>
        public DocumentationRulesConfiguration GetDocumentationRulesConfig(ICSharpFile file)
        {
            return new DocumentationRulesConfiguration(file.GetSourceFile());
        }

        /// <summary>
        /// Inserts the company name into the file's header.
        /// </summary>
        /// <param name="file">
        /// The file to insert the company name into.
        /// </param>
        public void InsertCompanyName(ICSharpFile file)
        {
            var docConfig = this.GetDocumentationRulesConfig(file);

            var fileHeader = new FileHeader(file) { CompanyName = docConfig.CompanyName };

            fileHeader.Update();
        }

        /// <summary>
        /// Inserts copyright text into the file's header.
        /// </summary>
        /// <param name="file">
        /// The file to insert the company name into.
        /// </param>
        public void InsertCopyrightText(ICSharpFile file)
        {
            var docConfig = this.GetDocumentationRulesConfig(file);

            var fileHeader = new FileHeader(file) { CopyrightText = docConfig.Copyright };

            fileHeader.Update();
        }

        /// <summary>
        /// Updates the existing header or inserts one if missing.
        /// </summary>
        /// <param name="file">
        /// THe file to check the header on.
        /// </param>
        public void InsertFileHeader(ICSharpFile file)
        {
            var fileHeader = new FileHeader(file);
            var docConfig = this.GetDocumentationRulesConfig(file);

            fileHeader.FileName = file.GetSourceFile().ToProjectFile().Location.Name;
            fileHeader.CompanyName = docConfig.CompanyName;
            fileHeader.CopyrightText = docConfig.Copyright;
            fileHeader.Summary = Utils.GetSummaryText(file);

            fileHeader.Update();
        }

        /// <summary>
        /// Inserts a summary into the file's header.
        /// </summary>
        /// <param name="file">
        /// The file to insert into.
        /// </param>
        public void InsertFileHeaderSummary(ICSharpFile file)
        {
            var fileHeader = new FileHeader(file) { Summary = Utils.GetSummaryText(file) };
            fileHeader.Update();
        }

        /// <summary>
        /// Inserts the file anme into the file.
        /// </summary>
        /// <param name="file">
        /// The file to insert into.
        /// </param>
        public void InsertFileName(ICSharpFile file)
        {
            var fileName = file.GetSourceFile().ToProjectFile().Location.Name;

            var fileHeader = new FileHeader(file) { FileName = fileName };
            fileHeader.Update();
        }

        /// <summary>
        /// Insert a summary element if missing.
        /// </summary>
        /// <param name="file">
        /// The <see cref="ICSharpFile"/> to use.
        /// </param>
        /// <param name="declaration">
        /// The <see cref="ITypeDeclaration"/> to check and fix.
        /// </param>
        /// <returns>True if it inserted a missing header.</returns>
        public bool InsertMissingDeclarationHeader(ICSharpFile file, IDeclaration declaration)
        {
            StyleCopTrace.In(file, declaration);
            Param.RequireNotNull(file, "file");
            Param.RequireNotNull(declaration, "declaration");
            Debug.Assert(declaration.DeclaredElement != null, "declaration.DeclaredElement != null");

            bool returnValue = false;
            var docConfig = this.GetDocumentationRulesConfig(file);

            var isIFieldDeclaration = declaration is IFieldDeclaration;

            var accessRights = ((IModifiersOwnerDeclaration)declaration).GetAccessRights();

            var elementType = declaration.DeclaredElement.GetElementType();
            if ((!isIFieldDeclaration || docConfig.RequireFields) &&
                (accessRights != AccessRights.PRIVATE || !docConfig.IgnorePrivates) &&
                (accessRights != AccessRights.INTERNAL || !docConfig.IgnoreInternals))
            {
                DeclarationHeader.CreateNewHeader(declaration, docConfig);
                returnValue = true;
            }

            return StyleCopTrace.Out(returnValue);
        }

        /// <summary>
        /// Insert a missing parameter element to the comment.
        /// </summary>
        /// <param name="declaration">
        /// The <see cref="IDeclaration"/> to check and fix.
        /// </param>
        public void InsertMissingParamElement(IDeclaration declaration)
        {
            Param.RequireNotNull(declaration, "declaration");

            var parametersOwnerDeclaration = declaration as IParametersOwnerDeclaration;

            if (parametersOwnerDeclaration == null)
            {
                return;
            }

            var declarationHeader = new DeclarationHeader(declaration);

            if (declarationHeader.IsMissing || declarationHeader.IsInherited)
            {
                return;
            }

            var xmlNode = declarationHeader.XmlNode;
            var ht = new Hashtable();

            var parameters = parametersOwnerDeclaration.ParameterDeclarations;

            if (parameters != null)
            {
                foreach (var parameter in parameters)
                {
                    ht.Add(parameter.DeclaredName, null);

                    if (declarationHeader.ContainsParameter(parameter.DeclaredName))
                    {
                        continue;
                    }

                    var paramNodeList = xmlNode.SelectNodes("//param");
                    if (paramNodeList != null)
                    {
                        var c = paramNodeList.Count == 0 ? declarationHeader.SummaryXmlNode : paramNodeList.Item(paramNodeList.Count - 1);

                        var parameterNode = CreateParamNode(xmlNode, parameter);

                        xmlNode.InsertAfter(parameterNode, c);
                    }
                }
            }

            RemoveParamsNotRequired(xmlNode, ht);
            ReorderParams(xmlNode, parameters);
            declarationHeader.Update();
        }

        /// <summary>
        /// Formats a summary element.
        /// </summary>
        /// <param name="declaration">
        /// The <see cref="IDeclaration"/> to format the text for.
        /// </param>
        public void FormatSummaryElement(IDeclaration declaration)
        {
            var declarationHeader = new DeclarationHeader(declaration);

            if (declarationHeader.IsMissing || declarationHeader.IsInherited || declarationHeader.HasEmptySummary || !declarationHeader.HasSummary)
            {
                return;
            }

            declarationHeader.Update();
        }

        /// <summary>
        /// Inserts a missing summary element.
        /// </summary>
        /// <param name="declaration">
        /// The <see cref="IDeclaration"/> to get comment from.
        /// </param>
        /// <returns>True if the element was inserted.</returns>
        public bool InsertMissingSummaryElement(IDeclaration declaration)
        {
            bool returnValue = false;
            var declarationHeader = new DeclarationHeader(declaration);

            if (declarationHeader.IsMissing || declarationHeader.IsInherited)
            {
                return false;
            }

            var summaryText = string.Empty;
            var settingsStore = PsiSourceFileExtensions.GetSettingsStore(null, declaration.GetSolution());
            if (settingsStore.GetValue((StyleCopOptionsSettingsKey key) => key.InsertTextIntoDocumentation))
            {
                string text;
                if (declaration is IInterfaceDeclaration)
                {
                    text = declaration.DeclaredName.Substring(1) + " interface";
                }
                else
                {
                    text = Utils.ConvertTextToSentence(declaration.DeclaredName).ToLower();
                }

                summaryText = string.Format("The {0}.", text);
            }

            summaryText = Utils.UpdateTextWithToDoPrefixIfRequired(summaryText, settingsStore);

            var summaryXmlNode = declarationHeader.SummaryXmlNode;

            if (declarationHeader.HasSummary)
            {
                if (declarationHeader.HasEmptySummary)
                {
                    summaryXmlNode.InnerText = summaryText;
                    declarationHeader.Update();
                    returnValue = true;
                }
            }
            else
            {
                var newChild = CreateNode(declarationHeader.XmlNode, "summary");
                newChild.InnerText = summaryText;
                declarationHeader.XmlNode.InsertBefore(newChild, declarationHeader.XmlNode.FirstChild);
                declarationHeader.Update();
                returnValue = true;
            }

            return returnValue;
        }

        /// <summary>
        /// Updates the summary to include all typeparam and remove any extra ones and in the correct order.
        /// </summary>
        /// <param name="declaration">
        /// The <see cref="ITypeDeclaration"/> to check and fix.
        /// </param>
        public void InsertMissingTypeParamElement(IDeclaration declaration)
        {
            var declaredElement = declaration.DeclaredElement as ITypeParametersOwner;

            if (declaredElement == null)
            {
                return;
            }

            var declarationHeader = new DeclarationHeader(declaration);

            if (declarationHeader.IsMissing || declarationHeader.IsInherited)
            {
                return;
            }

            var xmlNode = declarationHeader.XmlNode;

            var ht = new Hashtable();

            foreach (var parameter in declaredElement.TypeParameters)
            {
                ht.Add(parameter.ShortName, null);

                if (declarationHeader.ContainsTypeParameter(parameter.ShortName))
                {
                    continue;
                }

                var parameterNode = CreateTypeParamNode(xmlNode, parameter.ShortName);

                var paramNodeList = xmlNode.SelectNodes("//typeparam");
                if (paramNodeList != null)
                {
                    var c = paramNodeList.Count == 0 ? declarationHeader.SummaryXmlNode : paramNodeList.Item(paramNodeList.Count - 1);

                    xmlNode.InsertAfter(parameterNode, c);
                }
            }

            RemoveTypeParamsNotRequired(xmlNode, ht);
            ReorderTypeParams(xmlNode, declaredElement.TypeParameters);
            declarationHeader.Update();
        }

        /// <summary>
        /// Inserts a returns element to the element if its missing.
        /// </summary>
        /// <param name="memberDeclaration">
        /// The <see cref="ITypeMemberDeclaration"/> to check and fix.
        /// </param>
        public void InsertReturnsElement(ITypeMemberDeclaration memberDeclaration, string returnType)
        {
            Param.RequireNotNull(memberDeclaration, "memberDeclaration");

            var declarationHeader = new DeclarationHeader(memberDeclaration);

            if (declarationHeader.IsMissing || declarationHeader.IsInherited)
            {
                return;
            }

            var xmlNode = declarationHeader.XmlNode;

            var returnsXmlNode = declarationHeader.ReturnsXmlNode;

            var valueText = string.Empty;
            var settingsStore = PsiSourceFileExtensions.GetSettingsStore(null, memberDeclaration.GetSolution());
            if (settingsStore.GetValue((StyleCopOptionsSettingsKey key) => key.InsertTextIntoDocumentation))
            {
                valueText = string.Format("The {0}.", returnType);
            }

            if (declarationHeader.HasReturns)
            {
                if (string.IsNullOrEmpty(returnsXmlNode.InnerText.Trim()))
                {
                    returnsXmlNode.InnerText = valueText;
                    declarationHeader.Update();
                }
            }
            else
            {
                var valueNode = CreateNode(xmlNode, "returns");
                valueNode.InnerText = valueText;
                xmlNode.AppendChild(valueNode);
                declarationHeader.Update();
            }
        }

        /// <summary>
        /// Inserts a value element to the element if its missing.
        /// </summary>
        /// <param name="propertyDeclaration">
        /// The <see cref="IPropertyDeclaration"/> to check and fix.
        /// </param>
        public void InsertValueElement(IPropertyDeclaration propertyDeclaration)
        {
            var declarationHeader = new DeclarationHeader(propertyDeclaration);

            if (declarationHeader.IsMissing || declarationHeader.IsInherited)
            {
                return;
            }

            var xmlNode = declarationHeader.XmlNode;

            var valueText = string.Empty;

            var valueXmlNode = declarationHeader.ValueXmlNode;

            var settingsStore = PsiSourceFileExtensions.GetSettingsStore(null, propertyDeclaration.GetSolution());
            if (settingsStore.GetValue((StyleCopOptionsSettingsKey key) => key.InsertTextIntoDocumentation))
            {
                valueText = string.Format("The {0}.", Utils.ConvertTextToSentence(propertyDeclaration.DeclaredName).ToLower());
            }

            if (declarationHeader.HasValue)
            {
                if (string.IsNullOrEmpty(valueXmlNode.InnerText.Trim()))
                {
                    valueXmlNode.InnerText = valueText;
                    declarationHeader.Update();
                }
            }
            else
            {
                var valueNode = CreateNode(xmlNode, "value");
                valueNode.InnerText = valueText;
                xmlNode.AppendChild(valueNode);
                declarationHeader.Update();
            }
        }

        /// <summary>
        /// Removes a return element if it currently has one.
        /// </summary>
        /// <param name="memberDeclaration">
        /// The <see cref="ITypeDeclaration"/> to check and fix.
        /// </param>
        public void RemoveReturnsElement(ITypeMemberDeclaration memberDeclaration)
        {
            var declarationHeader = new DeclarationHeader(memberDeclaration);

            if (declarationHeader.IsMissing || declarationHeader.IsInherited || !declarationHeader.HasReturns)
            {
                return;
            }

            declarationHeader.XmlNode.RemoveChild(declarationHeader.ReturnsXmlNode);
            declarationHeader.Update();
        }

        /// <summary>
        /// Swaps a DocCommentNode to a CommentNode.
        /// </summary>
        /// <param name="currentNode">
        /// The node to process.
        /// </param>
        public void SwapDocCommentNodeToCommentNode(ITreeNode currentNode)
        {
            var docCommentNode = currentNode as IDocCommentNode;

            // found a triple slash comment thats not in an ElementHeader
            if (docCommentNode != null)
            {
                var newText = string.Format("//{0}", docCommentNode.CommentText);
                var newCommentNode = (ICommentNode)CSharpTokenType.END_OF_LINE_COMMENT.Create(new JB::JetBrains.Text.StringBuffer(newText), new TreeOffset(0), new TreeOffset(newText.Length));

                using (currentNode.CreateWriteLock())
                {
                    LowLevelModificationUtil.ReplaceChildRange(currentNode, currentNode, new ITreeNode[] { newCommentNode });
                }
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Creates an <see cref="XmlNode"/> based on the name sent.
        /// </summary>
        /// <param name="xmlNode">
        /// Node to create the element against.
        /// </param>
        /// <param name="elementName">
        /// The name of the element.
        /// </param>
        /// <returns>
        /// <see cref="XmlNode"/>that has been created.
        /// </returns>
        private static XmlNode CreateNode(XmlNode xmlNode, string elementName)
        {
            Param.RequireNotNull(xmlNode, "xmlNode");
            Param.RequireValidString(elementName, "elementName");

            return xmlNode.OwnerDocument.CreateNode(XmlNodeType.Element, elementName, null);
        }

        /// <summary>
        /// Creates a parameter node.
        /// </summary>
        /// <param name="xmlNode">
        /// The <see cref="XmlNode"/> to create the paramater against.
        /// </param>
        /// <param name="parameter">
        /// The parameter.
        /// </param>
        /// <returns>
        /// <see cref="XmlNode"/>of the created parameter.
        /// </returns>
        private static XmlNode CreateParamNode(XmlNode xmlNode, IParameterDeclaration parameter)
        {
            Param.RequireNotNull(xmlNode, "xmlNode");

            var parameterName = parameter.DeclaredName;

            var newNode = CreateNode(xmlNode, "param");
            var newAttribute = xmlNode.OwnerDocument.CreateAttribute("name");

            newAttribute.Value = parameterName;

            var innerText = string.Empty;

            var settingsStore = PsiSourceFileExtensions.GetSettingsStore(null, parameter.GetSolution());
            if (settingsStore.GetValue((StyleCopOptionsSettingsKey key) => key.InsertTextIntoDocumentation))
            {
                innerText = string.Format("The {0}.", Utils.ConvertTextToSentence(parameterName));
            }

            var innerChildTextNode = xmlNode.OwnerDocument.CreateTextNode(innerText);

            newNode.AppendChild(innerChildTextNode);
            newNode.Attributes.Append(newAttribute);

            return newNode;
        }

        /// <summary>
        /// Creates a type parameter node.
        /// </summary>
        /// <param name="xmlNode">
        /// The <see cref="XmlNode"/> to create the paramater against.
        /// </param>
        /// <param name="parameterName">
        /// The name of the parameter.
        /// </param>
        /// <returns>
        /// <see cref="XmlNode"/>of the created type parameter.
        /// </returns>
        private static XmlNode CreateTypeParamNode(XmlNode xmlNode, string parameterName)
        {
            Param.RequireNotNull(xmlNode, "xmlNode");
            Param.RequireValidString(parameterName, "parameterName");

            var newNode = CreateNode(xmlNode, "typeparam");
            var newAttribute = xmlNode.OwnerDocument.CreateAttribute("name");

            newAttribute.Value = parameterName;
            newNode.Attributes.Append(newAttribute);

            return newNode;
        }

        /// <summary>
        /// Removes the parameters that are not required.
        /// </summary>
        /// <param name="xmlNode">
        /// <see cref="XmlNode"/>to search for params.
        /// </param>
        /// <param name="hashtable">
        /// <see cref="Hashtable"/>of params that are not required.
        /// </param>
        private static void RemoveParamsNotRequired(XmlNode xmlNode, Hashtable hashtable)
        {
            Param.RequireNotNull(xmlNode, "xmlNode");
            Param.RequireNotNull(hashtable, "hashtable");

            var nodeList = xmlNode.SelectNodes("//param");

            if (nodeList != null)
            {
                for (var i = 0; i < nodeList.Count; i++)
                {
                    var node = nodeList[i];
                    if (node != null)
                    {
                        var attribute = node.Attributes["name"];
                        if (attribute != null)
                        {
                            if (!hashtable.Contains(attribute.Value))
                            {
                                xmlNode.RemoveChild(node);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Removes the parameter types that are not required.
        /// </summary>
        /// <param name="xmlNode">
        /// <see cref="XmlNode"/>to search for params.
        /// </param>
        /// <param name="hashtable">
        /// <see cref="Hashtable"/>of param types that are not required.
        /// </param>
        private static void RemoveTypeParamsNotRequired(XmlNode xmlNode, Hashtable hashtable)
        {
            Param.RequireNotNull(xmlNode, "xmlNode");
            Param.RequireNotNull(hashtable, "hashtable");

            var nodeList = xmlNode.SelectNodes("//typeparam");

            if (nodeList != null)
            {
                for (var i = 0; i < nodeList.Count; i++)
                {
                    var node = nodeList[i];

                    if (!hashtable.Contains(node.Attributes["name"].Value))
                    {
                        xmlNode.RemoveChild(node);
                    }
                }
            }
        }

        /// <summary>
        /// Reorder params.
        /// </summary>
        /// <param name="xmlNode">
        /// The xml node.
        /// </param>
        /// <param name="parameters">
        /// The parameters.
        /// </param>
        private static void ReorderParams(XmlNode xmlNode, IList<IParameterDeclaration> parameters)
        {
            XmlNode refChild = null;

            for (var i = 0; i < parameters.Count; i++)
            {
                var parameter = parameters[i];
                var node = xmlNode.SelectSingleNode(string.Format("//param[@name='{0}']", parameter.DeclaredName));

                if (i == 0)
                {
                    if (node.ParentNode.Name == "member")
                    {
                        refChild = node.PreviousSibling;
                    }
                    else
                    {
                        refChild = node.ParentNode;
                    }
                }

                xmlNode.InsertAfter(node, refChild);
                refChild = node;
            }
        }

        /// <summary>
        /// Reorder type params.
        /// </summary>
        /// <param name="xmlNode">
        /// The xml node.
        /// </param>
        /// <param name="typeParameters">
        /// The type parameters.
        /// </param>
        private static void ReorderTypeParams(XmlNode xmlNode, IList<ITypeParameter> typeParameters)
        {
            XmlNode refChild = null;

            for (var i = 0; i < typeParameters.Count; i++)
            {
                var typeParameter = typeParameters[i];
                var node = xmlNode.SelectSingleNode(string.Format("//typeparam[@name='{0}']", typeParameter.ShortName));

                if (i == 0)
                {
                    refChild = node.PreviousSibling;
                }

                xmlNode.InsertAfter(node, refChild);
                refChild = node;
            }
        }

        /// <summary>
        /// Checks a class comments block for parameters.
        /// </summary>
        /// <param name="typeDeclaration">
        /// The <see cref="ITypeDeclaration"/> to check.
        /// </param>
        /// <param name="options">
        /// <see cref="OrderingOptions"/>Current options that we can reference.
        /// </param>
        private void CheckClassDeclarationForParams(ITypeDeclaration typeDeclaration, DocumentationOptions options)
        {
            Param.RequireNotNull(typeDeclaration, "typeDeclaration");
            Param.RequireNotNull(options, "options");

            var insertMissingParamTagOption = options.SA1611ElementParametersMustBeDocumented;

            if (insertMissingParamTagOption)
            {
                if (typeDeclaration.DeclaredElement != null)
                {
                    if (typeDeclaration.DeclaredElement.TypeParameters.Count > 0)
                    {
                        this.InsertMissingTypeParamElement(typeDeclaration);
                    }
                }
            }
        }

        /// <summary>
        /// Checks declaration comment blocks.
        /// </summary>
        /// <param name="file">
        /// The <see cref="ICSharpFile"/> to use.
        /// </param>
        /// <param name="declaration">
        /// The <see cref="IDeclaration"/> to check.
        /// </param>
        /// <param name="options">
        /// <see cref="OrderingOptions"/>Current options that we can reference.
        /// </param>
        private void CheckDeclarationDocumentation(ICSharpFile file, IDeclaration declaration, DocumentationOptions options)
        {
            Param.RequireNotNull(file, "file");
            Param.RequireNotNull(declaration, "declaration");
            Param.RequireNotNull(options, "options");

            var insertMissingElementDocOption = options.SA1600ElementsMustBeDocumented;
            var documentationTextMustBeginWithACapitalLetter = options.SA1628DocumentationTextMustBeginWithACapitalLetter;
            var documentationTextMustEndWithAPeriod = options.SA1629DocumentationTextMustEndWithAPeriod;
            var elementDocumentationMustHaveSummary = options.SA1604ElementDocumentationMustHaveSummary;
            var constructorSummaryDocBeginsWithStandardText = options.SA1642ConstructorSummaryDocumentationMustBeginWithStandardText;
            var destructorSummaryDocBeginsWithStandardText = options.SA1643DestructorSummaryDocumentationMustBeginWithStandardText;
            var propertyDocumentationMustHaveValueDocumented = options.SA1609PropertyDocumentationMustHaveValue;
            var insertMissingParamTagOption = options.SA1611ElementParametersMustBeDocumented;
            var genericTypeParametersMustBeDocumented = options.SA1618GenericTypeParametersMustBeDocumented;

            var declarationHeader = new DeclarationHeader(declaration);

            bool formatSummary = false;
            if (insertMissingElementDocOption && !Utils.IsRuleSuppressed(declaration, StyleCopRules.SA1600) && declarationHeader.IsMissing)
            {
                formatSummary = this.InsertMissingDeclarationHeader(file, declaration);
            }

            if (elementDocumentationMustHaveSummary && !Utils.IsRuleSuppressed(declaration, StyleCopRules.SA1604) && !declarationHeader.HasSummary)
            {
                formatSummary = formatSummary || this.InsertMissingSummaryElement(declaration);
            }

            if (formatSummary)
            {
                this.FormatSummaryElement(declaration);
            }

            if (declaration is IConstructorDeclaration)
            {
                if (insertMissingParamTagOption && !Utils.IsRuleSuppressed(declaration, StyleCopRules.SA1611))
                {
                    var constructorDeclaration = declaration as IConstructorDeclaration;

                    if (constructorDeclaration.ParameterDeclarations.Count > 0)
                    {
                        this.InsertMissingParamElement(constructorDeclaration);
                    }
                }

                if (constructorSummaryDocBeginsWithStandardText && !Utils.IsRuleSuppressed(declaration, StyleCopRules.SA1642))
                {
                    this.EnsureConstructorSummaryDocBeginsWithStandardText(declaration as IConstructorDeclaration);
                }
            }

            var docConfig = this.GetDocumentationRulesConfig(file);

            // However it can be on/off depending on the file so we'd have to cache it per file
            var ruleIsEnabled = docConfig.GetStyleCopRuleEnabled("DocumentationTextMustBeginWithACapitalLetter");

            if (documentationTextMustBeginWithACapitalLetter && ruleIsEnabled && !Utils.IsRuleSuppressed(declaration, StyleCopRules.SA1628))
            {
                this.EnsureDocumentationTextIsUppercase(declaration);
            }

            ruleIsEnabled = docConfig.GetStyleCopRuleEnabled("DocumentationTextMustEndWithAPeriod");

            if (documentationTextMustEndWithAPeriod && ruleIsEnabled && !Utils.IsRuleSuppressed(declaration, StyleCopRules.SA1629))
            {
                this.EnsureDocumentationTextEndsWithAPeriod(declaration);
            }

            if (declaration is IDestructorDeclaration)
            {
                if (destructorSummaryDocBeginsWithStandardText && !Utils.IsRuleSuppressed(declaration, StyleCopRules.SA1643))
                {
                    this.EnsureDestructorSummaryDocBeginsWithStandardText(declaration as IDestructorDeclaration);
                }
            }

            if (declaration is IMethodDeclaration || declaration is IIndexerDeclaration)
            {
                this.CheckMethodAndIndexerDeclarationDocumentation(declaration as IParametersOwnerDeclaration, options);
            }

            if (declaration is IPropertyDeclaration)
            {
                ruleIsEnabled = docConfig.GetStyleCopRuleEnabled("PropertyDocumentationMustHaveValue");

                if (propertyDocumentationMustHaveValueDocumented && ruleIsEnabled && !Utils.IsRuleSuppressed(declaration, StyleCopRules.SA1609))
                {
                    this.InsertValueElement(declaration as IPropertyDeclaration);
                }
            }

            if (declaration is ITypeParametersOwner && (genericTypeParametersMustBeDocumented && !Utils.IsRuleSuppressed(declaration, StyleCopRules.SA1618)))
            {
                this.InsertMissingTypeParamElement(declaration);
            }
        }

        /// <summary>
        /// Checks method comment blocks.
        /// </summary>
        /// <param name="methodDeclaration">
        /// The method <see cref="IDeclaration"/> to check.
        /// </param>
        /// <param name="options">
        /// <see cref="OrderingOptions"/>Current options that we can reference.
        /// </param>
        private void CheckMethodAndIndexerDeclarationDocumentation(IParametersOwnerDeclaration methodDeclaration, DocumentationOptions options)
        {
            Param.RequireNotNull(options, "options");

            if (methodDeclaration == null)
            {
                return;
            }

            var insertMissingParamTagOption = options.SA1611ElementParametersMustBeDocumented;
            var insertMissingReturnTagOption = options.SA1615ElementReturnValueMustBeDocumented;
            var removeReturnTagOnVoidElementsOption = options.SA1617VoidReturnValueMustNotBeDocumented;

            if (insertMissingParamTagOption && !Utils.IsRuleSuppressed(methodDeclaration, StyleCopRules.SA1611))
            {
                if (methodDeclaration.ParameterDeclarations.Count > 0)
                {
                    this.InsertMissingParamElement(methodDeclaration);
                }
            }

            if (methodDeclaration.DeclaredElement == null)
            {
                return;
            }

            var declaredTypeFromClrName = methodDeclaration.DeclaredElement.ReturnType as DeclaredTypeFromCLRName;

            if (removeReturnTagOnVoidElementsOption && !Utils.IsRuleSuppressed(methodDeclaration, StyleCopRules.SA1617))
            {
                // Remove the <returns> if the return type is void
                if (declaredTypeFromClrName != null && declaredTypeFromClrName.GetClrName().FullName == "System.Void")
                {
                    this.RemoveReturnsElement(methodDeclaration as ITypeMemberDeclaration);
                }
            }

            if (insertMissingReturnTagOption && !Utils.IsRuleSuppressed(methodDeclaration, StyleCopRules.SA1615))
            {
                // Insert the <returns> if the return type is not void and it was missing
                if ((declaredTypeFromClrName != null && declaredTypeFromClrName.GetClrName().FullName != "System.Void") || declaredTypeFromClrName == null)
                {
                    this.InsertReturnsElement(methodDeclaration as ITypeMemberDeclaration, methodDeclaration.DeclaredElement.ReturnType.ToString());
                }
            }
        }

        /// <summary>
        /// Ensures comment blocks have an ending period character.
        /// </summary>
        /// <param name="xmlNode">
        /// Each <see cref="XmlNode"/> to check for ending period character.
        /// </param>
        private void EnsureTerminatingPeriod(XmlNode xmlNode)
        {
            Param.RequireNotNull(xmlNode, "xmlNode");

            var elementsThatHaveInnerTextEndingWithPeriod = new List<string>(new[] { "description", "exception", "para", "param", "permission", "remarks", "returns", "summary", "typeparam", "value" });

            for (var i = 0; i < xmlNode.ChildNodes.Count; i++)
            {
                var childNode = xmlNode.ChildNodes[i];
                var strippedInnerText = childNode.InnerText.Replace(" ", string.Empty).Replace("-", string.Empty).ToLowerInvariant().Trim();

                if (elementsThatHaveInnerTextEndingWithPeriod.Contains(childNode.Name) && strippedInnerText != "or")
                {
                    var innerText = childNode.InnerText.Trim();
                    if (innerText.Length > 0)
                    {
                        var lastNonWhitespacePosition = Utils.GetLastNonWhitespaceCharacterPosition(innerText);

                        if (innerText[lastNonWhitespacePosition] != '.')
                        {
                            // insert a '.'
                            if (childNode.LastChild is XmlText)
                            {
                                var text = childNode.LastChild.InnerText;
                                lastNonWhitespacePosition = Utils.GetLastNonWhitespaceCharacterPosition(text);

                                if (text[lastNonWhitespacePosition] != '.')
                                {
                                    // add a '.' after the last char before terminating withspace
                                    childNode.LastChild.InnerText = text.Insert(lastNonWhitespacePosition + 1, ".");
                                }
                            }
                            else if (childNode.LastChild is XmlElement && childNode.Name != "member")
                            {
                                var newNode = childNode.OwnerDocument.CreateTextNode(".\r\n");
                                childNode.AppendChild(newNode);
                            }
                            else if (childNode.LastChild is XmlWhitespace && childNode.Name != "member")
                            {
                                var newNode = childNode.OwnerDocument.CreateTextNode(".");
                                childNode.InsertBefore(newNode, childNode.LastChild);
                            }
                        }
                    }
                }

                this.EnsureTerminatingPeriod(childNode);
            }
        }

        /// <summary>
        /// Process type comment declarations.
        /// </summary>
        /// <param name="options">
        /// <see cref="OrderingOptions"/>Current options that we can reference.
        /// </param>
        /// <param name="file">
        /// The <see cref="ICSharpFile"/> to use.
        /// </param>
        /// <param name="typeDeclarations">
        /// The type <see cref="ICSharpTypeDeclaration"/> to check.
        /// </param>
        private void ProcessCSharpTypeDeclarations(DocumentationOptions options, ICSharpFile file, IEnumerable<ICSharpTypeDeclaration> typeDeclarations)
        {
            Param.RequireNotNull(options, "options");
            Param.RequireNotNull(file, "file");
            Param.RequireNotNull(typeDeclarations, "typeDeclarations");

            foreach (var typeDeclaration in typeDeclarations)
            {
                this.CheckDeclarationDocumentation(file, typeDeclaration, options);

                this.CheckClassDeclarationForParams(typeDeclaration, options);

                foreach (var memberDeclaration in typeDeclaration.MemberDeclarations)
                {
                    this.CheckDeclarationDocumentation(file, memberDeclaration, options);
                }

                this.ProcessNestedTypeDeclarations(options, file, typeDeclaration.NestedTypeDeclarations);
            }
        }

        /// <summary>
        /// Process nested declarations.
        /// </summary>
        /// <param name="options">
        /// <see cref="OrderingOptions"/>Current options that we can reference.
        /// </param>
        /// <param name="file">
        /// The <see cref="ICSharpFile"/> to use.
        /// </param>
        /// <param name="typeDeclarations">
        /// The type <see cref="ICSharpTypeDeclaration"/> to check.
        /// </param>
        private void ProcessNestedTypeDeclarations(DocumentationOptions options, ICSharpFile file, IEnumerable<ITypeDeclaration> typeDeclarations)
        {
            Param.RequireNotNull(options, "options");
            Param.RequireNotNull(file, "file");
            Param.RequireNotNull(typeDeclarations, "typeDeclarations");

            foreach (var typeDeclaration in typeDeclarations)
            {
                this.CheckDeclarationDocumentation(file, typeDeclaration, options);

                this.CheckClassDeclarationForParams(typeDeclaration, options);

                foreach (var memberDeclaration in typeDeclaration.MemberDeclarations)
                {
                    this.CheckDeclarationDocumentation(file, memberDeclaration, options);
                }

                this.ProcessNestedTypeDeclarations(options, file, typeDeclaration.NestedTypeDeclarations);
            }
        }

        /// <summary>
        /// Removes blank lines from the comment block.
        /// </summary>
        /// <param name="xmlNode">
        /// <see cref="XmlNode"/>to loop through and ensure no blank lines.
        /// </param>
        private void RemoveBlankLines(XmlNode xmlNode)
        {
            Param.RequireNotNull(xmlNode, "xmlNode");

            foreach (XmlNode childNode in xmlNode.ChildNodes)
            {
                if (childNode is XmlText)
                {
                    // Once we have a text node it may contain multiple \r\n
                    // we split it up, trim them and join them back together
                    childNode.InnerText = Utils.RemoveBlankLinesFromMultiLineStringComment(childNode.InnerText, 1, CommentType.DOC_COMMENT);
                }

                this.RemoveBlankLines(childNode);
            }
        }

        /// <summary>
        /// Swap doc comments to single line comments.
        /// </summary>
        /// <param name="node">
        /// The node to process.
        /// </param>
        private void SwapDocCommentsToSingleLineComments(ITreeNode node)
        {
            for (var currentNode = node; currentNode != null; currentNode = currentNode.NextSibling)
            {
                if (currentNode is IDocCommentNode)
                {
                    if (!(currentNode.Parent is IDocCommentBlockNode))
                    {
                        this.SwapDocCommentNodeToCommentNode(currentNode);
                    }
                }

                this.SwapDocCommentsToSingleLineComments(currentNode.FirstChild);
            }
        }

        /// <summary>
        /// Swaps a character to upper case as first letter is required to be upper case.
        /// </summary>
        /// <param name="xmlNode">
        /// <see cref="XmlNode"/>to loop through and ensure first character is upper case.
        /// </param>
        private void SwapToUpper(XmlNode xmlNode)
        {
            Param.RequireNotNull(xmlNode, "xmlNode");

            // don't capitalise text inside <c> elements
            if (xmlNode.Name == "c" || xmlNode.Name == "code")
            {
                return;
            }

            for (var i = 0; i < xmlNode.ChildNodes.Count; i++)
            {
                var childNode = xmlNode.ChildNodes[i];

                // we only swap the 1st char of the text if we are the first child otherwise we'd capitalise the first char of XmlText that appears after a <see cref> item.
                if (childNode is XmlText && i == 0)
                {
                    var text = childNode.InnerText;
                    var firstNonWhitespacePosition = Utils.GetFirstNonWhitespaceCharacterPosition(text);

                    if (!char.IsUpper(text[firstNonWhitespacePosition]) && !char.IsDigit(text[firstNonWhitespacePosition]))
                    {
                        // replace the first char here
                        var a = text.ToCharArray();
                        a[firstNonWhitespacePosition] = char.ToUpperInvariant(a[firstNonWhitespacePosition]);
                        childNode.InnerText = new string(a);
                    }
                }

                this.SwapToUpper(childNode);
            }
        }

        /// <summary>
        /// Inserts any missing items from the file header.
        /// Also formats the existing header ensuring that the top and bottom line start with 2 slashes and a space and that a newline follows the header.
        /// </summary>
        /// <param name="options">
        /// The options.
        /// </param>
        /// <param name="file">
        /// The file to update.
        /// </param>
        private void UpdateFileHeader(DocumentationOptions options, ICSharpFile file)
        {
            // The idea here is to load the existing header into our FileHeader object
            // The FileHeader object will ensure that the format of the header is correct even if we're not changing its contents
            // Thus we'll swap it out if its changed at the end.
            var fileName = file.GetSourceFile().ToProjectFile().Location.Name;
            var updateFileHeaderOption = options.SA1633SA1641UpdateFileHeader;

            if (updateFileHeaderOption == UpdateFileHeaderStyle.Ignore)
            {
                return;
            }

            var docConfig = this.GetDocumentationRulesConfig(file);
            var summaryText = Utils.GetSummaryText(file);
            var fileHeader = new FileHeader(file) { InsertSummary = options.SA1639FileHeaderMustHaveSummary };

            switch (updateFileHeaderOption)
            {
                case UpdateFileHeaderStyle.ReplaceCopyrightElement:
                    fileHeader.FileName = fileName;
                    fileHeader.CompanyName = docConfig.CompanyName;
                    fileHeader.CopyrightText = docConfig.Copyright;
                    fileHeader.Summary = string.IsNullOrEmpty(fileHeader.Summary) ? summaryText : fileHeader.Summary;
                    break;

                case UpdateFileHeaderStyle.ReplaceAll:
                    fileHeader.FileName = fileName;
                    fileHeader.CompanyName = docConfig.CompanyName;
                    fileHeader.CopyrightText = docConfig.Copyright;
                    fileHeader.Summary = summaryText;
                    break;

                case UpdateFileHeaderStyle.InsertMissing:
                    fileHeader.FileName = string.IsNullOrEmpty(fileHeader.FileName) ? fileName : fileHeader.FileName;
                    fileHeader.CompanyName = string.IsNullOrEmpty(fileHeader.CompanyName) ? docConfig.CompanyName : fileHeader.CompanyName;
                    fileHeader.CopyrightText = string.IsNullOrEmpty(fileHeader.CopyrightText) ? docConfig.Copyright : fileHeader.CopyrightText;
                    fileHeader.Summary = string.IsNullOrEmpty(fileHeader.Summary) ? summaryText : fileHeader.Summary;
                    break;
            }

            fileHeader.Update();
        }

        #endregion
    }
}