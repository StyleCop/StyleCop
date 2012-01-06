// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LayoutDescriptor.cs" company="http://stylecop.codeplex.com">
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

namespace StyleCop.ReSharper51.CodeCleanup.Descriptors
{
    #region Using Directives

    using System;
    using System.ComponentModel;
    using System.Xml;

    using JetBrains.ReSharper.Feature.Services.CodeCleanup;

    using StyleCop.ReSharper51.CodeCleanup.Options;

    #endregion

    /// <summary>
    /// Code Clean Up Description.
    /// </summary>
    [Category("StyleCop")]
    [DisplayName("Layout")]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class LayoutDescriptor : CodeCleanupOptionDescriptor<LayoutOptions>
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="LayoutDescriptor"/> class. 
        /// </summary>
        public LayoutDescriptor()
            : base("StyleCop.Layout")
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
            var options = new LayoutOptions();
            var optionsElement = (XmlElement)element.SelectSingleNode(this.Name);

            if (optionsElement != null)
            {
                try
                {
                    options.SA1500CurlyBracketsForMultiLineStatementsMustNotShareLine =
                        bool.Parse(JB::JetBrains.Util.XmlUtil.ReadLeafElementValue(optionsElement, "SA1500CurlyBracketsForMultiLineStatementsMustNotShareLine"));
                    options.SA1509OpeningCurlyBracketsMustNotBePrecededByBlankLine =
                        bool.Parse(JB::JetBrains.Util.XmlUtil.ReadLeafElementValue(optionsElement, "SA1509OpeningCurlyBracketsMustNotBePrecededByBlankLine"));
                    options.SA1510ChainedStatementBlocksMustNotBePrecededByBlankLine =
                        bool.Parse(JB::JetBrains.Util.XmlUtil.ReadLeafElementValue(optionsElement, "SA1510ChainedStatementBlocksMustNotBePrecededByBlankLine"));
                    options.SA1511WhileDoFooterMustNotBePrecededByBlankLine =
                        bool.Parse(JB::JetBrains.Util.XmlUtil.ReadLeafElementValue(optionsElement, "SA1511WhileDoFooterMustNotBePrecededByBlankLine"));
                    options.SA1512SingleLineCommentsMustNotBeFollowedByBlankLine =
                        bool.Parse(JB::JetBrains.Util.XmlUtil.ReadLeafElementValue(optionsElement, "SA1512SingleLineCommentsMustNotBeFollowedByBlankLine"));
                    options.SA1513ClosingCurlyBracketMustBeFollowedByBlankLine =
                        bool.Parse(JB::JetBrains.Util.XmlUtil.ReadLeafElementValue(optionsElement, "SA1513ClosingCurlyBracketMustBeFollowedByBlankLine"));
                    options.SA1514ElementDocumentationHeaderMustBePrecededByBlankLine =
                        bool.Parse(JB::JetBrains.Util.XmlUtil.ReadLeafElementValue(optionsElement, "SA1514ElementDocumentationHeaderMustBePrecededByBlankLine"));
                    options.SA1515SingleLineCommentMustBeProceededByBlankLine =
                        bool.Parse(JB::JetBrains.Util.XmlUtil.ReadLeafElementValue(optionsElement, "SA1515SingleLineCommentMustBeProceededByBlankLine"));
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
                optionsElement, "SA1500CurlyBracketsForMultiLineStatementsMustNotShareLine", options.SA1500CurlyBracketsForMultiLineStatementsMustNotShareLine.ToString());
            JB::JetBrains.Util.XmlUtil.CreateLeafElementWithValue(
                optionsElement, "SA1509OpeningCurlyBracketsMustNotBePrecededByBlankLine", options.SA1509OpeningCurlyBracketsMustNotBePrecededByBlankLine.ToString());
            JB::JetBrains.Util.XmlUtil.CreateLeafElementWithValue(
                optionsElement, "SA1510ChainedStatementBlocksMustNotBePrecededByBlankLine", options.SA1510ChainedStatementBlocksMustNotBePrecededByBlankLine.ToString());
            JB::JetBrains.Util.XmlUtil.CreateLeafElementWithValue(optionsElement, "SA1511WhileDoFooterMustNotBePrecededByBlankLine", options.SA1511WhileDoFooterMustNotBePrecededByBlankLine.ToString());
            JB::JetBrains.Util.XmlUtil.CreateLeafElementWithValue(
                optionsElement, "SA1512SingleLineCommentsMustNotBeFollowedByBlankLine", options.SA1512SingleLineCommentsMustNotBeFollowedByBlankLine.ToString());
            JB::JetBrains.Util.XmlUtil.CreateLeafElementWithValue(
                optionsElement, "SA1513ClosingCurlyBracketMustBeFollowedByBlankLine", options.SA1513ClosingCurlyBracketMustBeFollowedByBlankLine.ToString());
            JB::JetBrains.Util.XmlUtil.CreateLeafElementWithValue(
                optionsElement, "SA1514ElementDocumentationHeaderMustBePrecededByBlankLine", options.SA1514ElementDocumentationHeaderMustBePrecededByBlankLine.ToString());
            JB::JetBrains.Util.XmlUtil.CreateLeafElementWithValue(
                optionsElement, "SA1515SingleLineCommentMustBeProceededByBlankLine", options.SA1515SingleLineCommentMustBeProceededByBlankLine.ToString());
        }

        #endregion
    }
}