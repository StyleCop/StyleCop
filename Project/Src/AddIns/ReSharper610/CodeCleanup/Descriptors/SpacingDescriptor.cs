// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SpacingDescriptor.cs" company="http://stylecop.codeplex.com">
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

namespace StyleCop.ReSharper610.CodeCleanup.Descriptors
{
    #region Using Directives

    using System;
    using System.ComponentModel;
    using System.Globalization;
    using System.Xml;

    using JetBrains.ReSharper.Feature.Services.CodeCleanup;

    using StyleCop.ReSharper610.CodeCleanup.Options;

    #endregion

    /// <summary>
    /// Code Clean Up Description.
    /// </summary>
    [Category("StyleCop")]
    [DisplayName("Spacing")]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class SpacingDescriptor : CodeCleanupOptionDescriptor<SpacingOptions>
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SpacingDescriptor"/> class. 
        /// </summary>
        public SpacingDescriptor()
            : base("StyleCop.Spacing")
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
        public override SpacingOptions Load(XmlElement element)
        {
            SpacingOptions options = new SpacingOptions();

            try
            {
                options.SA1001CommasMustBeSpacedCorrectly = bool.Parse(JB::JetBrains.Util.XmlUtil.ReadLeafElementValue(element, "SA1001CommasMustBeSpacedCorrectly"));
                options.SA1005SingleLineCommentsMustBeginWithSingleSpace =
                    bool.Parse(JB::JetBrains.Util.XmlUtil.ReadLeafElementValue(element, "SA1005SingleLineCommentsMustBeginWithSingleSpace"));
                options.SA1006PreprocessorKeywordsMustNotBePrecededBySpace =
                    bool.Parse(JB::JetBrains.Util.XmlUtil.ReadLeafElementValue(element, "SA1006PreprocessorKeywordsMustNotBePrecededBySpace"));
                options.SA1021NegativeSignsMustBeSpacedCorrectly =
                    bool.Parse(JB::JetBrains.Util.XmlUtil.ReadLeafElementValue(element, "SA1021NegativeSignsMustBeSpacedCorrectly"));
                options.SA1022PositiveSignsMustBeSpacedCorrectly =
                    bool.Parse(JB::JetBrains.Util.XmlUtil.ReadLeafElementValue(element, "SA1022PositiveSignsMustBeSpacedCorrectly"));
                options.SA1025CodeMustNotContainMultipleWhitespaceInARow =
                    bool.Parse(JB::JetBrains.Util.XmlUtil.ReadLeafElementValue(element, "SA1025CodeMustNotContainMultipleWhitespaceInARow"));
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
        public override void Save(XmlElement element, SpacingOptions options)
        {
            JB::JetBrains.Util.XmlUtil.CreateLeafElementWithValue(
                element, "SA1001CommasMustBeSpacedCorrectly", options.SA1001CommasMustBeSpacedCorrectly.ToString(CultureInfo.InvariantCulture));
            JB::JetBrains.Util.XmlUtil.CreateLeafElementWithValue(
                element, 
                "SA1005SingleLineCommentsMustBeginWithSingleSpace", 
                options.SA1005SingleLineCommentsMustBeginWithSingleSpace.ToString(CultureInfo.InvariantCulture));
            JB::JetBrains.Util.XmlUtil.CreateLeafElementWithValue(
                element, 
                "SA1006PreprocessorKeywordsMustNotBePrecededBySpace", 
                options.SA1006PreprocessorKeywordsMustNotBePrecededBySpace.ToString(CultureInfo.InvariantCulture));
            JB::JetBrains.Util.XmlUtil.CreateLeafElementWithValue(
                element, "SA1021NegativeSignsMustBeSpacedCorrectly", options.SA1021NegativeSignsMustBeSpacedCorrectly.ToString(CultureInfo.InvariantCulture));
            JB::JetBrains.Util.XmlUtil.CreateLeafElementWithValue(
                element, "SA1022PositiveSignsMustBeSpacedCorrectly", options.SA1022PositiveSignsMustBeSpacedCorrectly.ToString(CultureInfo.InvariantCulture));
            JB::JetBrains.Util.XmlUtil.CreateLeafElementWithValue(
                element, 
                "SA1025CodeMustNotContainMultipleWhitespaceInARow", 
                options.SA1025CodeMustNotContainMultipleWhitespaceInARow.ToString(CultureInfo.InvariantCulture));
        }

        #endregion
    }
}