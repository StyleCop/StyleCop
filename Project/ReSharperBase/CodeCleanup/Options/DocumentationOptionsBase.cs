namespace ReSharperBase.CodeCleanup.Options
{
    using System.ComponentModel;
    using System.Reflection;
    using System.Text;

    using ReSharperBase.CodeCleanup.Styles;

    /// <summary>
    /// Base class for the documentation options - should be overridden so the defaults can be loaded as you'd expect for different ReSharper versions.
    /// </summary>
    public abstract class DocumentationOptionsBase : OptionsBase
    {
        /// <summary>
        /// Gets or sets a value indicating whether the elements must be documented.
        /// </summary>
        [DisplayName("1600: Elements Must Be Documented")]
        public bool SA1600ElementsMustBeDocumented { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether SA1604ElementDocumentationMustHaveSummary.
        /// </summary>
        [DisplayName("1604: Element Documentation Must Have Summary")]
        public bool SA1604ElementDocumentationMustHaveSummary { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to insert a missing value tag on properties.
        /// </summary>
        [DisplayName("1609: Property Documentation Must Have Value")]
        public bool SA1609PropertyDocumentationMustHaveValue { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to define the behavior for inserting a missing parameter tag on elements.
        /// </summary>
        [DisplayName("1611: Element Parameters Must Be Documented")]
        public bool SA1611ElementParametersMustBeDocumented { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to insert a missing return tag on elements.
        /// </summary>
        [DisplayName("1615: Element Return Value Must Be Documented")]
        public bool SA1615ElementReturnValueMustBeDocumented { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to remove the return tag on void elements.
        /// </summary>
        [DisplayName("1617: Void Return Value Must Not Be Documented")]
        public bool SA1617VoidReturnValueMustNotBeDocumented { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to ensure type parameters are documented.
        /// </summary>
        [DisplayName("1618: Generic Type Parameters Must Be Documented")]
        public bool SA1618GenericTypeParametersMustBeDocumented { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to fix triple slash comments to double slash.
        /// </summary>
        [DisplayName("1626: Single Line Comments Must Not Use Documentation Style Slashes")]
        public bool SA1626SingleLineCommentsMustNotUseDocumentationStyleSlashes { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether SA1628DocumentationTextMustBeginWithACapitalLetter.
        /// </summary>
        [DisplayName("1628: Documentation Text Must Begin With A Capital Letter")]
        public bool SA1628DocumentationTextMustBeginWithACapitalLetter { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether SA1629DocumentationTextMustEndWithAPeriod.
        /// </summary>
        [DisplayName("1629: Documentation Text Must End With A Period")]
        public bool SA1629DocumentationTextMustEndWithAPeriod { get; set; }

        /// <summary>
        /// Gets or sets the the behavior for updating the file header.
        /// </summary>
        [DisplayName("1633-1641: Update file header")]
        public UpdateFileHeaderStyle SA1633SA1641UpdateFileHeader { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the the behavior for updating the file header summary.
        /// </summary>
        [DisplayName("1639: File Header Must Have Summary")]
        public bool SA1639FileHeaderMustHaveSummary { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether SA1642ConstructorSummaryDocumentationMustBeginWithStandardText.
        /// </summary>
        [DisplayName("1642: Constructor Summary Documentation Must Begin With Standard Text")]
        public bool SA1642ConstructorSummaryDocumentationMustBeginWithStandardText { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether SA1643DestructorSummaryDocumentationMustBeginWithStandardText.
        /// </summary>
        [DisplayName("1643: Destructor Summary Documentation Must Begin With Standard Text")]
        public bool SA1643DestructorSummaryDocumentationMustBeginWithStandardText { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether SA1644DocumentationHeadersMustNotContainBlankLines.
        /// </summary>
        [DisplayName("1644: Documentation Headers Must Not Contain Blank Lines")]
        public bool SA1644DocumentationHeadersMustNotContainBlankLines { get; set; }

        /// <summary>
        /// Gets the name of the analyzer.
        /// </summary>
        protected override string AnalyzerName
        {
            get
            {
                return "StyleCop.CSharp.DocumentationRules";
            }
        }

        /// <summary>
        /// Gets a value indicating whether the file header options of the settings are disabled.
        /// </summary>
        protected bool IsFileHeaderSettingDisabled
        {
            get
            {
                return !this.IsPropertyEnabled("FileMustHaveHeader") && !this.IsPropertyEnabled("FileHeaderMustShowCopyright")
                       && !this.IsPropertyEnabled("FileHeaderMustHaveCopyrightText") && !this.IsPropertyEnabled("FileHeaderMustContainFileName")
                       && !this.IsPropertyEnabled("FileHeaderFileNameDocumentationMustMatchFileName") && !this.IsPropertyEnabled("FileHeaderMustHaveValidCompanyText");
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