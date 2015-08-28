namespace ReSharperBase.CodeCleanup.Options
{
    using System.ComponentModel;
    using System.Reflection;
    using System.Text;

    /// <summary>
    /// Base class for the readability options - should be overridden so the defaults can be loaded as you'd expect for different ReSharper versions.
    /// </summary>
    public abstract class ReadabilityOptionsBase : OptionsBase
    {
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

        /// <summary>
        /// Returns a concatenated summary of the current options settings.
        /// </summary>
        /// <returns>
        /// A String of the options.
        /// </returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            PropertyInfo[] properties = this.GetType().GetProperties();

            for (int i = 0; i < properties.Length; i++)
            {
                PropertyInfo property = properties[i];
                if (i > 0)
                {
                    sb.Append(", ");
                }

                sb.Append((string)this.GetPropertyDecription(property));
            }

            return sb.ToString();
        }

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
            string propertyValue = propertyInfo.GetValue(this, null).ToString();

            string propName = string.Empty;
            string propValue = string.Empty;
            DisplayNameAttribute[] displayNameAttributes = (DisplayNameAttribute[])propertyInfo.GetCustomAttributes(typeof(DisplayNameAttribute), false);
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
                FieldInfo field = propertyInfo.PropertyType.GetField(propertyValue);

                if (field != null)
                {
                    DescriptionAttribute[] descriptionAttributes = (DescriptionAttribute[])field.GetCustomAttributes(typeof(DescriptionAttribute), false);
                    if (descriptionAttributes.Length == 1)
                    {
                        propValue = descriptionAttributes[0].Description;
                    }
                }
            }

            return string.Format("{0} = {1}", propName, propValue);
        }
    }
}