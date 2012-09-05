// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReadabilityOptions.cs" company="http://stylecop.codeplex.com">
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
// --------------------------------------------------------------------------------------------------------------------

namespace StyleCop.ReSharper700.CodeCleanup.Options
{
    #region Using Directives

    using System.ComponentModel;
    using System.Reflection;
    using System.Text;

    #endregion

    /// <summary>
    /// Defines options for ReadabilityOptions.
    /// </summary>
    public class ReadabilityOptions : OptionsBase
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ReadabilityOptions"/> class. 
        /// </summary>
        public ReadabilityOptions()
        {
            this.InitPropertiesDefaults();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether SA1100DoNotPrefixCallsWithBaseUnlessLocalImplementationExists.
        /// </summary>
        /// <value>
        /// The s a 1100 do not prefix calls with base unless local implementation exists.
        /// </value>
        [DisplayName("1100: Do Not Prefix Calls With Base Unless Local Implementation Exists")]
        public bool SA1100DoNotPrefixCallsWithBaseUnlessLocalImplementationExists { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether SA1106CodeMustNotContainEmptyStatements.
        /// </summary>
        /// <value>
        /// The s a 1106 code must not contain empty statements.
        /// </value>
        [DisplayName("1106: Code Must Not Contain Empty Statements")]
        public bool SA1106CodeMustNotContainEmptyStatements { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether SA1108BlockStatementsMustNotContainEmbeddedComments.
        /// </summary>
        /// <value>
        /// The s a 1108 block statements must not contain embedded comments.
        /// </value>
        [DisplayName("1108: Block Statements Must Not Contain Embedded Comments")]
        public bool SA1108BlockStatementsMustNotContainEmbeddedComments { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether SA1109BlockStatementsMustNotContainEmbeddedRegions.
        /// </summary>
        /// <value>
        /// The s a 1109 block statements must not contain embedded regions.
        /// </value>
        [DisplayName("1109: Block Statements Must Not Contain Embedded Regions")]
        public bool SA1109BlockStatementsMustNotContainEmbeddedRegions { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether SA1120CommentsMustContainText.
        /// </summary>
        /// <value>
        /// The s a 1120 comments must contain text.
        /// </value>
        [DisplayName("1120: Comments Must Contain Text")]
        public bool SA1120CommentsMustContainText { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether SA1121UseBuiltInTypeAlias.
        /// </summary>
        /// <value>
        /// The s a 1121 use built in type alias.
        /// </value>
        [DisplayName("1121: Use Built In Type Alias")]
        public bool SA1121UseBuiltInTypeAlias { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether SA1122UseStringEmptyForEmptyStrings.
        /// </summary>
        /// <value>
        /// The s a 1122 use string empty for empty strings.
        /// </value>
        [DisplayName("1122: Use String Empty For Empty Strings")]
        public bool SA1122UseStringEmptyForEmptyStrings { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether SA1123DoNotPlaceRegionsWithinElements.
        /// </summary>
        /// <value>
        /// The s a 1123 do not place regions within elements.
        /// </value>
        [DisplayName("1123: Do Not Place Regions Within Elements")]
        public bool SA1123DoNotPlaceRegionsWithinElements { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether SA1124Code Must Not Contain Empty Regions.
        /// </summary>
        [DisplayName("1124: Code Must Not Contain Empty Regions")]
        public bool SA1124CodeMustNotContainEmptyRegions { get; set; }

        /// <summary>
        /// Gets the name of the analyzer.
        /// </summary>
        protected override string AnalyzerName
        {
            get
            {
                return "StyleCop.CSharp.ReadabilityRules";
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Returns a concatenated summary of the current options settings.
        /// </summary>
        /// <returns>
        /// A String of the options.
        /// </returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            var properties = this.GetType().GetProperties();

            for (var i = 0; i < properties.Length; i++)
            {
                var property = properties[i];
                if (i > 0)
                {
                    sb.Append(", ");
                }

                sb.Append(this.GetPropertyDecription(property));
            }

            return sb.ToString();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Builds a string representation of the property value.
        /// </summary>
        /// <param name="propertyInfo">
        /// The propertyInfo to build the description for.
        /// </param>
        /// <returns>
        /// The string representation.
        /// </returns>
        private string GetPropertyDecription(PropertyInfo propertyInfo)
        {
            var propertyValue = propertyInfo.GetValue(this, null).ToString();

            var propName = string.Empty;
            var propValue = string.Empty;
            var displayNameAttributes = (DisplayNameAttribute[])propertyInfo.GetCustomAttributes(typeof(DisplayNameAttribute), false);
            if (displayNameAttributes.Length == 1)
            {
                propName = displayNameAttributes[0].DisplayName;
            }

            if (propertyInfo.PropertyType == typeof(bool))
            {
                propValue = propertyValue == "True" ? "Yes" : "No";
            }
            else
            {
                var field = propertyInfo.PropertyType.GetField(propertyValue);

                if (field != null)
                {
                    var descriptionAttributes = (DescriptionAttribute[])field.GetCustomAttributes(typeof(DescriptionAttribute), false);
                    if (descriptionAttributes.Length == 1)
                    {
                        propValue = descriptionAttributes[0].Description;
                    }
                }
            }

            return string.Format("{0} = {1}", propName, propValue);
        }

        #endregion
    }
}