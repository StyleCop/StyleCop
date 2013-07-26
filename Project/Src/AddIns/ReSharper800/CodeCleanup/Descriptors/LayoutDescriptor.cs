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

namespace StyleCop.ReSharper800.CodeCleanup.Descriptors
{
    #region Using Directives

    using System;
    using System.ComponentModel;
    using System.Globalization;
    using System.Xml;

    using JetBrains.ReSharper.Feature.Services.CodeCleanup;

    using StyleCop.ReSharper800.CodeCleanup.Options;

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

        #region Public Methods and Operators

        /// <summary>
        /// Loads the specified profile.
        /// </summary>
        /// <param name="element">
        /// The element.
        /// </param>
        /// <returns>
        /// The options.
        /// </returns>
        public override LayoutOptions Load(XmlElement element)
        {
            LayoutOptions options = new LayoutOptions();

            try
            {
                options.SA1500CurlyBracketsForMultiLineStatementsMustNotShareLine =
                    bool.Parse(JetBrains.Util.XmlUtil.ReadLeafElementValue(element, "SA1500CurlyBracketsForMultiLineStatementsMustNotShareLine"));
                options.SA1509OpeningCurlyBracketsMustNotBePrecededByBlankLine =
                    bool.Parse(JetBrains.Util.XmlUtil.ReadLeafElementValue(element, "SA1509OpeningCurlyBracketsMustNotBePrecededByBlankLine"));
                options.SA1510ChainedStatementBlocksMustNotBePrecededByBlankLine =
                    bool.Parse(JetBrains.Util.XmlUtil.ReadLeafElementValue(element, "SA1510ChainedStatementBlocksMustNotBePrecededByBlankLine"));
                options.SA1511WhileDoFooterMustNotBePrecededByBlankLine =
                    bool.Parse(JetBrains.Util.XmlUtil.ReadLeafElementValue(element, "SA1511WhileDoFooterMustNotBePrecededByBlankLine"));
                options.SA1512SingleLineCommentsMustNotBeFollowedByBlankLine =
                    bool.Parse(JetBrains.Util.XmlUtil.ReadLeafElementValue(element, "SA1512SingleLineCommentsMustNotBeFollowedByBlankLine"));
                options.SA1513ClosingCurlyBracketMustBeFollowedByBlankLine =
                    bool.Parse(JetBrains.Util.XmlUtil.ReadLeafElementValue(element, "SA1513ClosingCurlyBracketMustBeFollowedByBlankLine"));
                options.SA1514ElementDocumentationHeaderMustBePrecededByBlankLine =
                    bool.Parse(JetBrains.Util.XmlUtil.ReadLeafElementValue(element, "SA1514ElementDocumentationHeaderMustBePrecededByBlankLine"));
                options.SA1515SingleLineCommentMustBeProceededByBlankLine =
                    bool.Parse(JetBrains.Util.XmlUtil.ReadLeafElementValue(element, "SA1515SingleLineCommentMustBeProceededByBlankLine"));
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
        public override void Save(XmlElement element, LayoutOptions options)
        {
            JetBrains.Util.XmlUtil.CreateLeafElementWithValue(
                element, 
                "SA1500CurlyBracketsForMultiLineStatementsMustNotShareLine", 
                options.SA1500CurlyBracketsForMultiLineStatementsMustNotShareLine.ToString(CultureInfo.InvariantCulture));
            JetBrains.Util.XmlUtil.CreateLeafElementWithValue(
                element, 
                "SA1509OpeningCurlyBracketsMustNotBePrecededByBlankLine", 
                options.SA1509OpeningCurlyBracketsMustNotBePrecededByBlankLine.ToString(CultureInfo.InvariantCulture));
            JetBrains.Util.XmlUtil.CreateLeafElementWithValue(
                element, 
                "SA1510ChainedStatementBlocksMustNotBePrecededByBlankLine", 
                options.SA1510ChainedStatementBlocksMustNotBePrecededByBlankLine.ToString(CultureInfo.InvariantCulture));
            JetBrains.Util.XmlUtil.CreateLeafElementWithValue(
                element, "SA1511WhileDoFooterMustNotBePrecededByBlankLine", options.SA1511WhileDoFooterMustNotBePrecededByBlankLine.ToString(CultureInfo.InvariantCulture));
            JetBrains.Util.XmlUtil.CreateLeafElementWithValue(
                element, 
                "SA1512SingleLineCommentsMustNotBeFollowedByBlankLine", 
                options.SA1512SingleLineCommentsMustNotBeFollowedByBlankLine.ToString(CultureInfo.InvariantCulture));
            JetBrains.Util.XmlUtil.CreateLeafElementWithValue(
                element, 
                "SA1513ClosingCurlyBracketMustBeFollowedByBlankLine", 
                options.SA1513ClosingCurlyBracketMustBeFollowedByBlankLine.ToString(CultureInfo.InvariantCulture));
            JetBrains.Util.XmlUtil.CreateLeafElementWithValue(
                element, 
                "SA1514ElementDocumentationHeaderMustBePrecededByBlankLine", 
                options.SA1514ElementDocumentationHeaderMustBePrecededByBlankLine.ToString(CultureInfo.InvariantCulture));
            JetBrains.Util.XmlUtil.CreateLeafElementWithValue(
                element, 
                "SA1515SingleLineCommentMustBeProceededByBlankLine", 
                options.SA1515SingleLineCommentMustBeProceededByBlankLine.ToString(CultureInfo.InvariantCulture));
        }

        #endregion
    }
}