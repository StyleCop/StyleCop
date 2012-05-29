// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReadabilityDescriptor.cs" company="http://stylecop.codeplex.com">
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

namespace StyleCop.ReSharper700.CodeCleanup.Descriptors
{
    #region Using Directives

    using System;
    using System.ComponentModel;
    using System.Globalization;
    using System.Xml;

    using JetBrains.ReSharper.Feature.Services.CodeCleanup;

    using StyleCop.ReSharper700.CodeCleanup.Options;

    #endregion

    /// <summary>
    /// Code Clean Up Description.
    /// </summary>
    [Category("StyleCop")]
    [DisplayName("Readability")]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class ReadabilityDescriptor : CodeCleanupOptionDescriptor<ReadabilityOptions>
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ReadabilityDescriptor"/> class. 
        /// </summary>
        public ReadabilityDescriptor()
            : base("StyleCop.Readability")
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
        public override ReadabilityOptions Load(XmlElement element)
        {
            var options = new ReadabilityOptions();

            try
            {
                options.SA1100DoNotPrefixCallsWithBaseUnlessLocalImplementationExists =
                    bool.Parse(JB::JetBrains.Util.XmlUtil.ReadLeafElementValue(element, "SA1100DoNotPrefixCallsWithBaseUnlessLocalImplementationExists"));
                options.SA1106CodeMustNotContainEmptyStatements = bool.Parse(JB::JetBrains.Util.XmlUtil.ReadLeafElementValue(element, "SA1106CodeMustNotContainEmptyStatements"));
                options.SA1108BlockStatementsMustNotContainEmbeddedComments =
                    bool.Parse(JB::JetBrains.Util.XmlUtil.ReadLeafElementValue(element, "SA1108BlockStatementsMustNotContainEmbeddedComments"));
                options.SA1109BlockStatementsMustNotContainEmbeddedRegions =
                    bool.Parse(JB::JetBrains.Util.XmlUtil.ReadLeafElementValue(element, "SA1109BlockStatementsMustNotContainEmbeddedRegions"));
                options.SA1120CommentsMustContainText = bool.Parse(JB::JetBrains.Util.XmlUtil.ReadLeafElementValue(element, "SA1120CommentsMustContainText"));
                options.SA1121UseBuiltInTypeAlias = bool.Parse(JB::JetBrains.Util.XmlUtil.ReadLeafElementValue(element, "SA1121UseBuiltInTypeAlias"));
                options.SA1122UseStringEmptyForEmptyStrings = bool.Parse(JB::JetBrains.Util.XmlUtil.ReadLeafElementValue(element, "SA1122UseStringEmptyForEmptyStrings"));
                options.SA1123DoNotPlaceRegionsWithinElements = bool.Parse(JB::JetBrains.Util.XmlUtil.ReadLeafElementValue(element, "SA1123DoNotPlaceRegionsWithinElements"));
                options.SA1124CodeMustNotContainEmptyRegions = bool.Parse(JB::JetBrains.Util.XmlUtil.ReadLeafElementValue(element, "SA1124CodeMustNotContainEmptyRegions"));
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
        public override void Save(XmlElement element, ReadabilityOptions options)
        {
            JB::JetBrains.Util.XmlUtil.CreateLeafElementWithValue(
                element, "SA1100DoNotPrefixCallsWithBaseUnlessLocalImplementationExists", options.SA1100DoNotPrefixCallsWithBaseUnlessLocalImplementationExists.ToString(CultureInfo.InvariantCulture));
            JB::JetBrains.Util.XmlUtil.CreateLeafElementWithValue(element, "SA1106CodeMustNotContainEmptyStatements", options.SA1106CodeMustNotContainEmptyStatements.ToString(CultureInfo.InvariantCulture));
            JB::JetBrains.Util.XmlUtil.CreateLeafElementWithValue(
                element, "SA1108BlockStatementsMustNotContainEmbeddedComments", options.SA1108BlockStatementsMustNotContainEmbeddedComments.ToString(CultureInfo.InvariantCulture));
            JB::JetBrains.Util.XmlUtil.CreateLeafElementWithValue(
                element, "SA1109BlockStatementsMustNotContainEmbeddedRegions", options.SA1109BlockStatementsMustNotContainEmbeddedRegions.ToString(CultureInfo.InvariantCulture));
            JB::JetBrains.Util.XmlUtil.CreateLeafElementWithValue(element, "SA1120CommentsMustContainText", options.SA1120CommentsMustContainText.ToString(CultureInfo.InvariantCulture));
            JB::JetBrains.Util.XmlUtil.CreateLeafElementWithValue(element, "SA1121UseBuiltInTypeAlias", options.SA1121UseBuiltInTypeAlias.ToString(CultureInfo.InvariantCulture));
            JB::JetBrains.Util.XmlUtil.CreateLeafElementWithValue(element, "SA1122UseStringEmptyForEmptyStrings", options.SA1122UseStringEmptyForEmptyStrings.ToString(CultureInfo.InvariantCulture));
            JB::JetBrains.Util.XmlUtil.CreateLeafElementWithValue(element, "SA1123DoNotPlaceRegionsWithinElements", options.SA1123DoNotPlaceRegionsWithinElements.ToString(CultureInfo.InvariantCulture));
            JB::JetBrains.Util.XmlUtil.CreateLeafElementWithValue(element, "SA1124CodeMustNotContainEmptyRegions", options.SA1124CodeMustNotContainEmptyRegions.ToString(CultureInfo.InvariantCulture));
        }

        #endregion
    }
}