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

namespace StyleCop.ReSharper.CodeCleanup.Descriptors
{
    #region Using Directives

    using System;
    using System.ComponentModel;
    using System.Xml;

    using JetBrains.ReSharper.Feature.Services.CodeCleanup;

    using StyleCop.ReSharper.CodeCleanup.Options;

    #endregion

    /// <summary>
    /// Code Clean Up Description.
    /// </summary>
    [Category("StyleCop for ReSharper")]
    [DisplayName("Readability")]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class ReadabilityDescriptor : CodeCleanupOptionDescriptor<ReadabilityOptions>
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ReadabilityDescriptor"/> class. 
        /// </summary>
        public ReadabilityDescriptor()
            : base("StyleCopForReSharperReadability")
        {
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Loads the specified profile.
        /// </summary>
        /// <param name="profile">
        /// The profile.
        /// </param>
        /// <param name="element">
        /// The element.
        /// </param>
        public override void Load(CodeCleanupProfile profile, XmlElement element)
        {
            var options = new ReadabilityOptions();
            var optionsElement = (XmlElement)element.SelectSingleNode(this.Name);

            if (optionsElement != null)
            {
                try
                {
                    options.SA1100DoNotPrefixCallsWithBaseUnlessLocalImplementationExists =
                        bool.Parse(JB::JetBrains.Util.XmlUtil.ReadLeafElementValue(optionsElement, "SA1100DoNotPrefixCallsWithBaseUnlessLocalImplementationExists"));
                    options.SA1106CodeMustNotContainEmptyStatements = bool.Parse(JB::JetBrains.Util.XmlUtil.ReadLeafElementValue(optionsElement, "SA1106CodeMustNotContainEmptyStatements"));
                    options.SA1108BlockStatementsMustNotContainEmbeddedComments =
                        bool.Parse(JB::JetBrains.Util.XmlUtil.ReadLeafElementValue(optionsElement, "SA1108BlockStatementsMustNotContainEmbeddedComments"));
                    options.SA1109BlockStatementsMustNotContainEmbeddedRegions =
                        bool.Parse(JB::JetBrains.Util.XmlUtil.ReadLeafElementValue(optionsElement, "SA1109BlockStatementsMustNotContainEmbeddedRegions"));
                    options.SA1120CommentsMustContainText = bool.Parse(JB::JetBrains.Util.XmlUtil.ReadLeafElementValue(optionsElement, "SA1120CommentsMustContainText"));
                    options.SA1121UseBuiltInTypeAlias = bool.Parse(JB::JetBrains.Util.XmlUtil.ReadLeafElementValue(optionsElement, "SA1121UseBuiltInTypeAlias"));
                    options.SA1122UseStringEmptyForEmptyStrings = bool.Parse(JB::JetBrains.Util.XmlUtil.ReadLeafElementValue(optionsElement, "SA1122UseStringEmptyForEmptyStrings"));
                    options.SA1123DoNotPlaceRegionsWithinElements = bool.Parse(JB::JetBrains.Util.XmlUtil.ReadLeafElementValue(optionsElement, "SA1123DoNotPlaceRegionsWithinElements"));
                    options.SA1124CodeMustNotContainEmptyRegions = bool.Parse(JB::JetBrains.Util.XmlUtil.ReadLeafElementValue(optionsElement, "SA1124CodeMustNotContainEmptyRegions"));
                }
                catch (ArgumentException)
                {
                }
            }

            profile.SetSetting(this, options);
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
        /// <param name="profile">
        /// The profile.
        /// </param>
        /// <param name="element">
        /// The element.
        /// </param>
        public override void Save(CodeCleanupProfile profile, XmlElement element)
        {
            var options = profile.GetSetting(this);
            var optionsElement = JB::JetBrains.Util.XmlUtil.CreateElement(element, this.Name);

            JB::JetBrains.Util.XmlUtil.CreateLeafElementWithValue(
                optionsElement, "SA1100DoNotPrefixCallsWithBaseUnlessLocalImplementationExists", options.SA1100DoNotPrefixCallsWithBaseUnlessLocalImplementationExists.ToString());
            JB::JetBrains.Util.XmlUtil.CreateLeafElementWithValue(optionsElement, "SA1106CodeMustNotContainEmptyStatements", options.SA1106CodeMustNotContainEmptyStatements.ToString());
            JB::JetBrains.Util.XmlUtil.CreateLeafElementWithValue(
                optionsElement, "SA1108BlockStatementsMustNotContainEmbeddedComments", options.SA1108BlockStatementsMustNotContainEmbeddedComments.ToString());
            JB::JetBrains.Util.XmlUtil.CreateLeafElementWithValue(
                optionsElement, "SA1109BlockStatementsMustNotContainEmbeddedRegions", options.SA1109BlockStatementsMustNotContainEmbeddedRegions.ToString());
            JB::JetBrains.Util.XmlUtil.CreateLeafElementWithValue(optionsElement, "SA1120CommentsMustContainText", options.SA1120CommentsMustContainText.ToString());
            JB::JetBrains.Util.XmlUtil.CreateLeafElementWithValue(optionsElement, "SA1121UseBuiltInTypeAlias", options.SA1121UseBuiltInTypeAlias.ToString());
            JB::JetBrains.Util.XmlUtil.CreateLeafElementWithValue(optionsElement, "SA1122UseStringEmptyForEmptyStrings", options.SA1122UseStringEmptyForEmptyStrings.ToString());
            JB::JetBrains.Util.XmlUtil.CreateLeafElementWithValue(optionsElement, "SA1123DoNotPlaceRegionsWithinElements", options.SA1123DoNotPlaceRegionsWithinElements.ToString());
            JB::JetBrains.Util.XmlUtil.CreateLeafElementWithValue(optionsElement, "SA1124CodeMustNotContainEmptyRegions", options.SA1124CodeMustNotContainEmptyRegions.ToString());
        }

        #endregion
    }
}