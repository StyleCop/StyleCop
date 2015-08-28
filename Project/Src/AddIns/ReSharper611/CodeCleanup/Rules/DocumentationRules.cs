﻿// --------------------------------------------------------------------------------------------------------------------
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

namespace StyleCop.ReSharper611.CodeCleanup.Rules
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
    using JetBrains.ReSharper.Psi.ExtensionsAPI;
    using JetBrains.ReSharper.Psi.Impl.Types;
    using JetBrains.ReSharper.Psi.Tree;

    using ReSharperBase.CodeCleanup.Styles;

    using StyleCop.CSharp;
    using StyleCop.Diagnostics;
    using StyleCop.ReSharper611.CodeCleanup.Options;
    using StyleCop.ReSharper611.Core;
    using StyleCop.ReSharper611.Options;

    #endregion

    /// <summary>
    /// Declaration comments fixes SA1600, SA1602, SA1611, SA1615, SA1617, SA1642.
    /// </summary>
    public class DocumentationRules
    {
        #region Public Methods and Operators

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
        public void CheckDeclarationDocumentation(ICSharpFile file, IDeclaration declaration, DocumentationOptions options)
        {
            Param.RequireNotNull(file, "file");
            Param.RequireNotNull(declaration, "declaration");
            Param.Ignore(options);

            bool insertMissingElementDocOption = true;
            bool documentationTextMustBeginWithACapitalLetter = true;
            bool documentationTextMustEndWithAPeriod = true;
            bool elementDocumentationMustHaveSummary = true;
            bool constructorSummaryDocBeginsWithStandardText = true;
            bool destructorSummaryDocBeginsWithStandardText = true;
            bool propertyDocumentationMustHaveValueDocumented = true;
            bool insertMissingParamTagOption = true;
            bool genericTypeParametersMustBeDocumented = true;

            if (options != null)
            {
                insertMissingElementDocOption = options.SA1600ElementsMustBeDocumented;
                documentationTextMustBeginWithACapitalLetter = options.SA1628DocumentationTextMustBeginWithACapitalLetter;
                documentationTextMustEndWithAPeriod = options.SA1629DocumentationTextMustEndWithAPeriod;
                elementDocumentationMustHaveSummary = options.SA1604ElementDocumentationMustHaveSummary;
                constructorSummaryDocBeginsWithStandardText = options.SA1642ConstructorSummaryDocumentationMustBeginWithStandardText;
                destructorSummaryDocBeginsWithStandardText = options.SA1643DestructorSummaryDocumentationMustBeginWithStandardText;
                propertyDocumentationMustHaveValueDocumented = options.SA1609PropertyDocumentationMustHaveValue;
                insertMissingParamTagOption = options.SA1611ElementParametersMustBeDocumented;
                genericTypeParametersMustBeDocumented = options.SA1618GenericTypeParametersMustBeDocumented;
            }

            DeclarationHeader declarationHeader = new DeclarationHeader(declaration);

            bool formatSummary = false;
            if (insertMissingElementDocOption && !Utils.IsRuleSuppressed(declaration, StyleCopRules.SA1600) && declarationHeader.IsMissing)
            {
                formatSummary = this.InsertMissingDeclarationHeader(file, declaration);
            }

            if (elementDocumentationMustHaveSummary && !Utils.IsRuleSuppressed(declaration, StyleCopRules.SA1604) && !declarationHeader.HasSummary)
            {
                formatSummary = formatSummary | this.InsertMissingSummaryElement(declaration);
            }

            if (formatSummary)
            {
                this.FormatSummaryElement(declaration);
            }

            if (declaration is IConstructorDeclaration)
            {
                if (insertMissingParamTagOption && !Utils.IsRuleSuppressed(declaration, StyleCopRules.SA1611))
                {
                    IConstructorDeclaration constructorDeclaration = declaration as IConstructorDeclaration;

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

            DocumentationRulesConfiguration docConfig = this.GetDocumentationRulesConfig(file);

            // However it can be on/off depending on the file so we'd have to cache it per file
            bool ruleIsEnabled = docConfig.GetStyleCopRuleEnabled("DocumentationTextMustBeginWithACapitalLetter");

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

            IContextBoundSettingsStore settingsStore = PsiSourceFileExtensions.GetSettingsStore(null, constructorDeclaration.GetSolution());
            if (!settingsStore.GetValue((StyleCopOptionsSettingsKey key) => key.InsertTextIntoDocumentation))
            {
                return;
            }

            DeclarationHeader declarationHeader = new DeclarationHeader(constructorDeclaration);

            if (declarationHeader.IsMissing || declarationHeader.IsInherited || !declarationHeader.HasSummary)
            {
                return;
            }

            string existingSummaryText = declarationHeader.SummaryXmlNode.InnerXml;

            bool parentIsStruct = Utils.IsContainingTypeAStruct(constructorDeclaration);

            int constructorParameterCount = constructorDeclaration.ParameterDeclarations.Count;

            string xmlComment = Utils.GetTextFromDeclarationHeader(declarationHeader.XmlNode);
            string structOrClass = parentIsStruct ? CachedCodeStrings.StructText : CachedCodeStrings.ClassText;
            string textWeShouldStartWith;

            if (constructorDeclaration.IsStatic)
            {
                textWeShouldStartWith = string.Format(
                    CultureInfo.InvariantCulture, CachedCodeStrings.HeaderSummaryForStaticConstructor, constructorDeclaration.DeclaredName, structOrClass);
            }
            else if (constructorDeclaration.GetAccessRights() == AccessRights.PRIVATE && constructorParameterCount == 0)
            {
                textWeShouldStartWith = string.Format(
                    CultureInfo.InvariantCulture, CachedCodeStrings.HeaderSummaryForPrivateInstanceConstructor, constructorDeclaration.DeclaredName, structOrClass);
            }
            else
            {
                string constructorDescriptionText = Utils.CreateConstructorDescriptionText(constructorDeclaration, true);
                textWeShouldStartWith = string.Format(
                    CultureInfo.InvariantCulture, CachedCodeStrings.HeaderSummaryForInstanceConstructor, constructorDescriptionText, structOrClass);
            }

            if (constructorDeclaration.IsStatic)
            {
                string docStd = string.Format("Initializes the {0} class.", constructorDeclaration.DeclaredName);
                if (xmlComment == docStd)
                {
                    existingSummaryText = string.Empty;
                }
            }

            if (!xmlComment.StartsWith(textWeShouldStartWith, StringComparison.Ordinal))
            {
                string newSummaryText = Utils.CreateSummaryForConstructorDeclaration(constructorDeclaration);

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

            DeclarationHeader declarationHeader = new DeclarationHeader(destructorDeclaration);

            if (declarationHeader.IsMissing || declarationHeader.IsInherited || !declarationHeader.HasSummary)
            {
                return;
            }

            IContextBoundSettingsStore settingsStore = PsiSourceFileExtensions.GetSettingsStore(null, destructorDeclaration.GetSolution());
            if (!settingsStore.GetValue((StyleCopOptionsSettingsKey key) => key.InsertTextIntoDocumentation))
            {
                return;
            }

            string destructorDescriptionText = Utils.CreateDestructorDescriptionText(destructorDeclaration, true);

            string xmlComment = Utils.GetTextFromDeclarationHeader(declarationHeader.XmlNode);

            string textWeShouldStartWith = string.Format(CultureInfo.InvariantCulture, CachedCodeStrings.HeaderSummaryForDestructor, destructorDescriptionText);

            if (!xmlComment.StartsWith(textWeShouldStartWith, StringComparison.Ordinal))
            {
                string summaryText = Utils.CreateSummaryForDestructorDeclaration(destructorDeclaration);

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
            DeclarationHeader declarationHeader = new DeclarationHeader(declaration);

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
            IContextBoundSettingsStore settingsStore = PsiSourceFileExtensions.GetSettingsStore(null, declaration.GetSolution());
            if (!settingsStore.GetValue((StyleCopOptionsSettingsKey key) => key.InsertTextIntoDocumentation))
            {
                return;
            }

            DeclarationHeader declarationHeader = new DeclarationHeader(declaration);
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
            IContextBoundSettingsStore settingsStore = PsiSourceFileExtensions.GetSettingsStore(null, declaration.GetSolution());
            if (!settingsStore.GetValue((StyleCopOptionsSettingsKey key) => key.InsertTextIntoDocumentation))
            {
                return;
            }

            DeclarationHeader declarationHeader = new DeclarationHeader(declaration);

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

            foreach (ICSharpNamespaceDeclaration namespaceDeclaration in file.NamespaceDeclarations)
            {
                this.ProcessCSharpTypeDeclarations(options, file, namespaceDeclaration.TypeDeclarations);
            }

            this.ProcessCSharpTypeDeclarations(options, file, file.TypeDeclarations);

            bool fixSingleLineCommentsOption = options.SA1626SingleLineCommentsMustNotUseDocumentationStyleSlashes;

            if (fixSingleLineCommentsOption)
            {
                this.SwapDocCommentsToSingleLineComments(file.FirstChild);
            }

            this.UpdateFileHeader(options, file);
            StyleCopTrace.Out();
        }

        /// <summary>
        /// Formats a summary element.
        /// </summary>
        /// <param name="declaration">
        /// The <see cref="IDeclaration"/> to format the text for.
        /// </param>
        public void FormatSummaryElement(IDeclaration declaration)
        {
            DeclarationHeader declarationHeader = new DeclarationHeader(declaration);

            if (declarationHeader.IsMissing || declarationHeader.IsInherited || declarationHeader.HasEmptySummary || !declarationHeader.HasSummary)
            {
                return;
            }

            declarationHeader.Update();
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
            DocumentationRulesConfiguration docConfig = this.GetDocumentationRulesConfig(file);

            FileHeader fileHeader = new FileHeader(file) { CompanyName = docConfig.CompanyName };

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
            DocumentationRulesConfiguration docConfig = this.GetDocumentationRulesConfig(file);

            FileHeader fileHeader = new FileHeader(file) { CopyrightText = docConfig.Copyright };

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
            FileHeader fileHeader = new FileHeader(file);
            DocumentationRulesConfiguration docConfig = this.GetDocumentationRulesConfig(file);

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
            FileHeader fileHeader = new FileHeader(file) { Summary = Utils.GetSummaryText(file) };
            fileHeader.Update();
        }

        /// <summary>
        /// Inserts the file name into the file.
        /// </summary>
        /// <param name="file">
        /// The file to insert into.
        /// </param>
        public void InsertFileName(ICSharpFile file)
        {
            string fileName = file.GetSourceFile().ToProjectFile().Location.Name;

            FileHeader fileHeader = new FileHeader(file) { FileName = fileName };
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
        /// <returns>
        /// True if it inserted a missing header.
        /// </returns>
        public bool InsertMissingDeclarationHeader(ICSharpFile file, IDeclaration declaration)
        {
            StyleCopTrace.In(file, declaration);
            Param.RequireNotNull(file, "file");
            Param.RequireNotNull(declaration, "declaration");
            Debug.Assert(declaration.DeclaredElement != null, "declaration.DeclaredElement != null");

            bool returnValue = false;
            DocumentationRulesConfiguration docConfig = this.GetDocumentationRulesConfig(file);

            bool isIFieldDeclaration = declaration is IFieldDeclaration;

            AccessRights accessRights = ((IModifiersOwnerDeclaration)declaration).GetAccessRights();

            DeclaredElementType elementType = declaration.DeclaredElement.GetElementType();
            if ((!isIFieldDeclaration || docConfig.RequireFields) && (accessRights != AccessRights.PRIVATE || !docConfig.IgnorePrivates)
                && (accessRights != AccessRights.INTERNAL || !docConfig.IgnoreInternals))
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

            IParametersOwnerDeclaration parametersOwnerDeclaration = declaration as IParametersOwnerDeclaration;

            if (parametersOwnerDeclaration == null)
            {
                return;
            }

            DeclarationHeader declarationHeader = new DeclarationHeader(declaration);

            if (declarationHeader.IsMissing || declarationHeader.IsInherited)
            {
                return;
            }

            XmlNode xmlNode = declarationHeader.XmlNode;
            Hashtable ht = new Hashtable();

            IList<IParameterDeclaration> parameters = parametersOwnerDeclaration.ParameterDeclarations;

            if (parameters != null)
            {
                foreach (IParameterDeclaration parameter in parameters)
                {
                    ht.Add(parameter.DeclaredName, null);

                    if (declarationHeader.ContainsParameter(parameter.DeclaredName))
                    {
                        continue;
                    }

                    XmlNodeList paramNodeList = xmlNode.SelectNodes("//param");
                    if (paramNodeList != null)
                    {
                        XmlNode c = paramNodeList.Count == 0 ? declarationHeader.SummaryXmlNode : paramNodeList.Item(paramNodeList.Count - 1);

                        XmlNode parameterNode = CreateParamNode(xmlNode, parameter);

                        xmlNode.InsertAfter(parameterNode, c);
                    }
                }
            }

            RemoveParamsNotRequired(xmlNode, ht);
            ReorderParams(xmlNode, parameters);
            declarationHeader.Update();
        }

        /// <summary>
        /// Inserts a missing summary element.
        /// </summary>
        /// <param name="declaration">
        /// The <see cref="IDeclaration"/> to get comment from.
        /// </param>
        /// <returns>
        /// True if the element was inserted.
        /// </returns>
        public bool InsertMissingSummaryElement(IDeclaration declaration)
        {
            bool returnValue = false;
            DeclarationHeader declarationHeader = new DeclarationHeader(declaration);

            if (declarationHeader.IsMissing || declarationHeader.IsInherited)
            {
                return false;
            }

            string summaryText = string.Empty;
            IContextBoundSettingsStore settingsStore = PsiSourceFileExtensions.GetSettingsStore(null, declaration.GetSolution());
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

            XmlNode summaryXmlNode = declarationHeader.SummaryXmlNode;

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
                XmlNode newChild = CreateNode(declarationHeader.XmlNode, "summary");
                newChild.InnerText = summaryText;
                declarationHeader.XmlNode.InsertBefore(newChild, declarationHeader.XmlNode.FirstChild);
                declarationHeader.Update();
                returnValue = true;
            }

            return returnValue;
        }

        /// <summary>
        /// Updates the summary to include all <c>typeparam</c> and remove any extra ones and in the correct order.
        /// </summary>
        /// <param name="declaration">
        /// The <see cref="ITypeDeclaration"/> to check and fix.
        /// </param>
        public void InsertMissingTypeParamElement(IDeclaration declaration)
        {
            ITypeParametersOwner declaredElement = declaration.DeclaredElement as ITypeParametersOwner;

            if (declaredElement == null)
            {
                return;
            }

            DeclarationHeader declarationHeader = new DeclarationHeader(declaration);

            if (declarationHeader.IsMissing || declarationHeader.IsInherited)
            {
                return;
            }

            XmlNode xmlNode = declarationHeader.XmlNode;

            Hashtable ht = new Hashtable();

            foreach (ITypeParameter parameter in declaredElement.TypeParameters)
            {
                ht.Add(parameter.ShortName, null);

                if (declarationHeader.ContainsTypeParameter(parameter.ShortName))
                {
                    continue;
                }

                XmlNode parameterNode = CreateTypeParamNode(xmlNode, parameter.ShortName);

                XmlNodeList paramNodeList = xmlNode.SelectNodes("//typeparam");
                if (paramNodeList != null)
                {
                    XmlNode c = paramNodeList.Count == 0 ? declarationHeader.SummaryXmlNode : paramNodeList.Item(paramNodeList.Count - 1);

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
        /// <param name="returnType">
        /// The text to insert as the return type.
        /// </param>
        public void InsertReturnsElement(ITypeMemberDeclaration memberDeclaration, string returnType)
        {
            Param.RequireNotNull(memberDeclaration, "memberDeclaration");

            DeclarationHeader declarationHeader = new DeclarationHeader(memberDeclaration);

            if (declarationHeader.IsMissing || declarationHeader.IsInherited)
            {
                return;
            }

            XmlNode xmlNode = declarationHeader.XmlNode;

            XmlNode returnsXmlNode = declarationHeader.ReturnsXmlNode;

            string valueText = string.Empty;
            IContextBoundSettingsStore settingsStore = PsiSourceFileExtensions.GetSettingsStore(null, memberDeclaration.GetSolution());
            if (settingsStore.GetValue((StyleCopOptionsSettingsKey key) => key.InsertTextIntoDocumentation))
            {
                valueText = string.Format("The <see cref=\"{0}\"/>.", returnType.SubstringBefore('{'));
            }

            if (declarationHeader.HasReturns)
            {
                if (string.IsNullOrEmpty(returnsXmlNode.InnerText.Trim()))
                {
                    returnsXmlNode.InnerXml = valueText;
                    declarationHeader.Update();
                }
            }
            else
            {
                XmlNode valueNode = CreateNode(xmlNode, "returns");
                valueNode.InnerXml = valueText;
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
            DeclarationHeader declarationHeader = new DeclarationHeader(propertyDeclaration);

            if (declarationHeader.IsMissing || declarationHeader.IsInherited)
            {
                return;
            }

            XmlNode xmlNode = declarationHeader.XmlNode;

            string valueText = string.Empty;

            XmlNode valueXmlNode = declarationHeader.ValueXmlNode;

            IContextBoundSettingsStore settingsStore = PsiSourceFileExtensions.GetSettingsStore(null, propertyDeclaration.GetSolution());
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
                XmlNode valueNode = CreateNode(xmlNode, "value");
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
            DeclarationHeader declarationHeader = new DeclarationHeader(memberDeclaration);

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
            IDocCommentNode docCommentNode = currentNode as IDocCommentNode;

            // found a triple slash comment thats not in an ElementHeader
            if (docCommentNode != null)
            {
                string newText = string.Format("//{0}", docCommentNode.CommentText);
                ICommentNode newCommentNode =
                    (ICommentNode)
                    CSharpTokenType.END_OF_LINE_COMMENT.Create(new JB::JetBrains.Text.StringBuffer(newText), new TreeOffset(0), new TreeOffset(newText.Length));

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
        /// The <see cref="XmlNode"/> to create the parameter against.
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

            string parameterName = parameter.DeclaredName;

            XmlNode newNode = CreateNode(xmlNode, "param");
            XmlAttribute newAttribute = xmlNode.OwnerDocument.CreateAttribute("name");

            newAttribute.Value = parameterName;

            string innerText = string.Empty;

            IContextBoundSettingsStore settingsStore = PsiSourceFileExtensions.GetSettingsStore(null, parameter.GetSolution());
            if (settingsStore.GetValue((StyleCopOptionsSettingsKey key) => key.InsertTextIntoDocumentation))
            {
                innerText = string.Format("The {0}.", Utils.ConvertTextToSentence(parameterName));
            }

            XmlText innerChildTextNode = xmlNode.OwnerDocument.CreateTextNode(innerText);

            newNode.AppendChild(innerChildTextNode);
            newNode.Attributes.Append(newAttribute);

            return newNode;
        }

        /// <summary>
        /// Creates a type parameter node.
        /// </summary>
        /// <param name="xmlNode">
        /// The <see cref="XmlNode"/> to create the parameter against.
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

            XmlNode newNode = CreateNode(xmlNode, "typeparam");
            XmlAttribute newAttribute = xmlNode.OwnerDocument.CreateAttribute("name");

            newAttribute.Value = parameterName;
            newNode.Attributes.Append(newAttribute);

            return newNode;
        }

        /// <summary>
        /// Removes the parameters that are not required.
        /// </summary>
        /// <param name="xmlNode">
        /// <see cref="XmlNode"/>to search for <c>param</c> elements.
        /// </param>
        /// <param name="hashtable">
        /// <see cref="Hashtable"/>of parameters that are not required.
        /// </param>
        private static void RemoveParamsNotRequired(XmlNode xmlNode, Hashtable hashtable)
        {
            Param.RequireNotNull(xmlNode, "xmlNode");
            Param.RequireNotNull(hashtable, "hashtable");

            XmlNodeList nodeList = xmlNode.SelectNodes("//param");

            if (nodeList != null)
            {
                for (int i = 0; i < nodeList.Count; i++)
                {
                    XmlNode node = nodeList[i];
                    if (node != null)
                    {
                        XmlAttribute attribute = node.Attributes["name"];
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
        /// <see cref="XmlNode"/>to search for parameters.
        /// </param>
        /// <param name="hashtable">
        /// A <see cref="Hashtable"/> of <c>TypeParam</c> that are not required.
        /// </param>
        private static void RemoveTypeParamsNotRequired(XmlNode xmlNode, Hashtable hashtable)
        {
            Param.RequireNotNull(xmlNode, "xmlNode");
            Param.RequireNotNull(hashtable, "hashtable");

            XmlNodeList nodeList = xmlNode.SelectNodes("//typeparam");

            if (nodeList != null)
            {
                for (int i = 0; i < nodeList.Count; i++)
                {
                    XmlNode node = nodeList[i];

                    if (!hashtable.Contains(node.Attributes["name"].Value))
                    {
                        xmlNode.RemoveChild(node);
                    }
                }
            }
        }

        /// <summary>
        /// Reorder parameters.
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

            for (int i = 0; i < parameters.Count; i++)
            {
                IParameterDeclaration parameter = parameters[i];
                XmlNode node = xmlNode.SelectSingleNode(string.Format("//param[@name='{0}']", parameter.DeclaredName));

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
        /// Reorder type parameters.
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

            for (int i = 0; i < typeParameters.Count; i++)
            {
                ITypeParameter typeParameter = typeParameters[i];
                XmlNode node = xmlNode.SelectSingleNode(string.Format("//typeparam[@name='{0}']", typeParameter.ShortName));

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

            bool insertMissingParamTagOption = options.SA1611ElementParametersMustBeDocumented;

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
            Param.Ignore(options);

            if (methodDeclaration == null)
            {
                return;
            }

            bool insertMissingParamTagOption = true;
            bool insertMissingReturnTagOption = true;
            bool removeReturnTagOnVoidElementsOption = true;

            if (options != null)
            {
                insertMissingParamTagOption = options.SA1611ElementParametersMustBeDocumented;
                insertMissingReturnTagOption = options.SA1615ElementReturnValueMustBeDocumented;
                removeReturnTagOnVoidElementsOption = options.SA1617VoidReturnValueMustNotBeDocumented;
            }

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

            DeclaredTypeFromCLRName declaredTypeFromClrName = methodDeclaration.DeclaredElement.ReturnType as DeclaredTypeFromCLRName;

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
                    this.InsertReturnsElement(methodDeclaration as ITypeMemberDeclaration, Utils.GetXmlPresentableName(methodDeclaration.DeclaredElement.ReturnType));
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

            List<string> elementsThatHaveInnerTextEndingWithPeriod =
                new List<string>(new[] { "description", "exception", "para", "param", "permission", "remarks", "returns", "summary", "typeparam", "value" });

            for (int i = 0; i < xmlNode.ChildNodes.Count; i++)
            {
                XmlNode childNode = xmlNode.ChildNodes[i];
                string strippedInnerText = childNode.InnerText.Replace(" ", string.Empty).Replace("-", string.Empty).ToLowerInvariant().Trim();

                if (elementsThatHaveInnerTextEndingWithPeriod.Contains(childNode.Name) && strippedInnerText != "or")
                {
                    string innerText = childNode.InnerText.Trim();
                    if (innerText.Length > 0)
                    {
                        int lastNonWhitespacePosition = Utils.GetLastNonWhitespaceCharacterPosition(innerText);

                        if (innerText[lastNonWhitespacePosition] != '.')
                        {
                            // insert a '.'
                            if (childNode.LastChild is XmlText)
                            {
                                string text = childNode.LastChild.InnerText;
                                lastNonWhitespacePosition = Utils.GetLastNonWhitespaceCharacterPosition(text);

                                if (text[lastNonWhitespacePosition] != '.')
                                {
                                    // add a '.' after the last char before terminating withspace
                                    childNode.LastChild.InnerText = text.Insert(lastNonWhitespacePosition + 1, ".");
                                }
                            }
                            else if (childNode.LastChild is XmlElement && childNode.Name != "member")
                            {
                                XmlText newNode = childNode.OwnerDocument.CreateTextNode(".\r\n");
                                childNode.AppendChild(newNode);
                            }
                            else if (childNode.LastChild is XmlWhitespace && childNode.Name != "member")
                            {
                                XmlText newNode = childNode.OwnerDocument.CreateTextNode(".");
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

            foreach (ICSharpTypeDeclaration typeDeclaration in typeDeclarations)
            {
                this.CheckDeclarationDocumentation(file, typeDeclaration, options);

                this.CheckClassDeclarationForParams(typeDeclaration, options);

                foreach (ICSharpTypeMemberDeclaration memberDeclaration in typeDeclaration.MemberDeclarations)
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

            foreach (ITypeDeclaration typeDeclaration in typeDeclarations)
            {
                this.CheckDeclarationDocumentation(file, typeDeclaration, options);

                this.CheckClassDeclarationForParams(typeDeclaration, options);

                foreach (ITypeMemberDeclaration memberDeclaration in typeDeclaration.MemberDeclarations)
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
            for (ITreeNode currentNode = node; currentNode != null; currentNode = currentNode.NextSibling)
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

            for (int i = 0; i < xmlNode.ChildNodes.Count; i++)
            {
                XmlNode childNode = xmlNode.ChildNodes[i];

                // we only swap the 1st char of the text if we are the first child otherwise we'd capitalise the first char of XmlText that appears after a <see cref> item.
                if (childNode is XmlText && i == 0)
                {
                    string text = childNode.InnerText;
                    int firstNonWhitespacePosition = Utils.GetFirstNonWhitespaceCharacterPosition(text);

                    if (!char.IsUpper(text[firstNonWhitespacePosition]) && !char.IsDigit(text[firstNonWhitespacePosition]))
                    {
                        // replace the first char here
                        char[] a = text.ToCharArray();
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
            string fileName = file.GetSourceFile().ToProjectFile().Location.Name;
            UpdateFileHeaderStyle updateFileHeaderOption = options.SA1633SA1641UpdateFileHeader;

            if (updateFileHeaderOption == UpdateFileHeaderStyle.Ignore)
            {
                return;
            }

            DocumentationRulesConfiguration docConfig = this.GetDocumentationRulesConfig(file);
            string summaryText = Utils.GetSummaryText(file);
            FileHeader fileHeader = new FileHeader(file) { InsertSummary = options.SA1639FileHeaderMustHaveSummary };

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