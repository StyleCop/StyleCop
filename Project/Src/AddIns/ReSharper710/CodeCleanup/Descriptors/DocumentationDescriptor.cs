// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DocumentationDescriptor.cs" company="http://stylecop.codeplex.com">
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
//   Code Clean Up Description.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
extern alias JB;

namespace StyleCop.ReSharper710.CodeCleanup.Descriptors
{
    #region Using Directives

    using System;
    using System.ComponentModel;
    using System.Globalization;
    using System.Xml;

    using JetBrains.ReSharper.Feature.Services.CodeCleanup;

    using StyleCop.ReSharper710.CodeCleanup.Options;
    using StyleCop.ReSharper710.CodeCleanup.Styles;

    #endregion

    /// <summary>
    /// Code Clean Up Description.
    /// </summary>
    [Category("StyleCop")]
    [DisplayName("Documentation")]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class DocumentationDescriptor : CodeCleanupOptionDescriptor<DocumentationOptions>
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentationDescriptor"/> class. 
        /// </summary>
        public DocumentationDescriptor()
            : base("StyleCop.Documentation")
        {
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Loads the specified profile.
        /// </summary>
        /// <param name="element">
        /// The element.
        /// </param>
        /// <returns>
        /// The options.
        /// </returns>
        public override DocumentationOptions Load(XmlElement element)
        {
            var options = new DocumentationOptions();

            try
            {
                options.SA1600ElementsMustBeDocumented = bool.Parse(JB::JetBrains.Util.XmlUtil.ReadLeafElementValue(element, "SA1600ElementsMustBeDocumented"));
                options.SA1604ElementDocumentationMustHaveSummary = bool.Parse(JB::JetBrains.Util.XmlUtil.ReadLeafElementValue(element, "SA1604ElementDocumentationMustHaveSummary"));
                options.SA1609PropertyDocumentationMustHaveValue = bool.Parse(JB::JetBrains.Util.XmlUtil.ReadLeafElementValue(element, "SA1609PropertyDocumentationMustHaveValueDocumented"));
                options.SA1611ElementParametersMustBeDocumented = bool.Parse(JB::JetBrains.Util.XmlUtil.ReadLeafElementValue(element, "SA1611ElementParametersMustBeDocumented"));
                options.SA1615ElementReturnValueMustBeDocumented = bool.Parse(JB::JetBrains.Util.XmlUtil.ReadLeafElementValue(element, "SA1615ElementReturnValueMustBeDocumented"));
                options.SA1617VoidReturnValueMustNotBeDocumented = bool.Parse(JB::JetBrains.Util.XmlUtil.ReadLeafElementValue(element, "SA1617VoidReturnValueMustNotBeDocumented"));
                options.SA1618GenericTypeParametersMustBeDocumented = bool.Parse(JB::JetBrains.Util.XmlUtil.ReadLeafElementValue(element, "SA1618GenericTypeParametersMustBeDocumented"));
                options.SA1626SingleLineCommentsMustNotUseDocumentationStyleSlashes =
                    bool.Parse(JB::JetBrains.Util.XmlUtil.ReadLeafElementValue(element, "SA1626SingleLineCommentsMustNotUseDocumentationStyleSlashes"));
                options.SA1628DocumentationTextMustBeginWithACapitalLetter = bool.Parse(JB::JetBrains.Util.XmlUtil.ReadLeafElementValue(element, "SA1628DocumentationTextMustBeginWithACapitalLetter"));
                options.SA1629DocumentationTextMustEndWithAPeriod = bool.Parse(JB::JetBrains.Util.XmlUtil.ReadLeafElementValue(element, "SA1629DocumentationTextMustEndWithAPeriod"));
                options.SA1633SA1641UpdateFileHeader =
                    (UpdateFileHeaderStyle)Enum.Parse(typeof(UpdateFileHeaderStyle), JB::JetBrains.Util.XmlUtil.ReadLeafElementValue(element, "SA1633SA1641UpdateFileHeader"));
                options.SA1639FileHeaderMustHaveSummary = bool.Parse(JB::JetBrains.Util.XmlUtil.ReadLeafElementValue(element, "SA1639FileHeaderMustHaveSummary"));
                options.SA1642ConstructorSummaryDocumentationMustBeginWithStandardText =
                    bool.Parse(JB::JetBrains.Util.XmlUtil.ReadLeafElementValue(element, "SA1642ConstructorSummaryDocumentationMustBeginWithStandardText"));
                options.SA1643DestructorSummaryDocumentationMustBeginWithStandardText =
                    bool.Parse(JB::JetBrains.Util.XmlUtil.ReadLeafElementValue(element, "SA1643DestructorSummaryDocumentationMustBeginWithStandardText"));
                options.SA1644DocumentationHeadersMustNotContainBlankLines = bool.Parse(JB::JetBrains.Util.XmlUtil.ReadLeafElementValue(element, "SA1644DocumentationHeadersMustNotContainBlankLines"));
            }
            catch (ArgumentNullException)
            {
            }
            catch (ArgumentException)
            {
            }

            return options;
        }

        /// <summary>
        /// Presents the specified profile.
        /// </summary>
        /// <param name="profile">
        /// The profile.
        /// </param>
        /// <returns>
        /// Specified profile.
        /// </returns>
        public override string Present(CodeCleanupProfile profile)
        {
            return profile.GetSetting(this).ToString();
        }

        /// <summary>
        /// Saves the specified profile.
        /// </summary>
        /// <param name="element">
        /// The element.
        /// </param>
        /// <param name="options">
        /// The options to save.
        /// </param>
        public override void Save(XmlElement element, DocumentationOptions options)
        {
            JB::JetBrains.Util.XmlUtil.CreateLeafElementWithValue(element, "SA1600ElementsMustBeDocumented", options.SA1600ElementsMustBeDocumented.ToString(CultureInfo.InvariantCulture));
            JB::JetBrains.Util.XmlUtil.CreateLeafElementWithValue(element, "SA1604ElementDocumentationMustHaveSummary", options.SA1604ElementDocumentationMustHaveSummary.ToString(CultureInfo.InvariantCulture));
            JB::JetBrains.Util.XmlUtil.CreateLeafElementWithValue(element, "SA1609PropertyDocumentationMustHaveValueDocumented", options.SA1609PropertyDocumentationMustHaveValue.ToString(CultureInfo.InvariantCulture));
            JB::JetBrains.Util.XmlUtil.CreateLeafElementWithValue(element, "SA1611ElementParametersMustBeDocumented", options.SA1611ElementParametersMustBeDocumented.ToString(CultureInfo.InvariantCulture));
            JB::JetBrains.Util.XmlUtil.CreateLeafElementWithValue(element, "SA1615ElementReturnValueMustBeDocumented", options.SA1615ElementReturnValueMustBeDocumented.ToString(CultureInfo.InvariantCulture));
            JB::JetBrains.Util.XmlUtil.CreateLeafElementWithValue(element, "SA1617VoidReturnValueMustNotBeDocumented", options.SA1617VoidReturnValueMustNotBeDocumented.ToString(CultureInfo.InvariantCulture));
            JB::JetBrains.Util.XmlUtil.CreateLeafElementWithValue(element, "SA1618GenericTypeParametersMustBeDocumented", options.SA1618GenericTypeParametersMustBeDocumented.ToString(CultureInfo.InvariantCulture));
            JB::JetBrains.Util.XmlUtil.CreateLeafElementWithValue(
                element, "SA1626SingleLineCommentsMustNotUseDocumentationStyleSlashes", options.SA1626SingleLineCommentsMustNotUseDocumentationStyleSlashes.ToString(CultureInfo.InvariantCulture));
            JB::JetBrains.Util.XmlUtil.CreateLeafElementWithValue(
                element, "SA1628DocumentationTextMustBeginWithACapitalLetter", options.SA1628DocumentationTextMustBeginWithACapitalLetter.ToString(CultureInfo.InvariantCulture));
            JB::JetBrains.Util.XmlUtil.CreateLeafElementWithValue(element, "SA1629DocumentationTextMustEndWithAPeriod", options.SA1629DocumentationTextMustEndWithAPeriod.ToString(CultureInfo.InvariantCulture));
            JB::JetBrains.Util.XmlUtil.CreateLeafElementWithValue(element, "SA1633SA1641UpdateFileHeader", options.SA1633SA1641UpdateFileHeader.ToString());
            JB::JetBrains.Util.XmlUtil.CreateLeafElementWithValue(element, "SA1639FileHeaderMustHaveSummary", options.SA1639FileHeaderMustHaveSummary.ToString(CultureInfo.InvariantCulture));
            JB::JetBrains.Util.XmlUtil.CreateLeafElementWithValue(
                element, "SA1642ConstructorSummaryDocumentationMustBeginWithStandardText", options.SA1642ConstructorSummaryDocumentationMustBeginWithStandardText.ToString(CultureInfo.InvariantCulture));
            JB::JetBrains.Util.XmlUtil.CreateLeafElementWithValue(
                element, "SA1643DestructorSummaryDocumentationMustBeginWithStandardText", options.SA1643DestructorSummaryDocumentationMustBeginWithStandardText.ToString(CultureInfo.InvariantCulture));
            JB::JetBrains.Util.XmlUtil.CreateLeafElementWithValue(
                element, "SA1644DocumentationHeadersMustNotContainBlankLines", options.SA1644DocumentationHeadersMustNotContainBlankLines.ToString(CultureInfo.InvariantCulture));
        }

        #endregion
    }
}