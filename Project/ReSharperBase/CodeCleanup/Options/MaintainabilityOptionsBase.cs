namespace ReSharperBase.CodeCleanup.Options
{
    using System.ComponentModel;
    using System.Reflection;
    using System.Text;

    /// <summary>
    /// Base class for the maintainability options - should be overridden so the defaults can be loaded as you'd expect for different ReSharper versions.
    /// </summary>
    public abstract class MaintainabilityOptionsBase : OptionsBase
    {
        /// <summary>
        /// Gets or sets a value indicating whether SA1119StatementMustNotUseUnnecessaryParenthesis.
        /// </summary>
        [DisplayName("1119: Statement Must Not Use Unnecessary Parenthesis")]
        public bool SA1119StatementMustNotUseUnnecessaryParenthesis { get; set; }

        /// <summary>
        /// Gets the name of the analyzer.
        /// </summary>
        protected override string AnalyzerName
        {
            get
            {
                return "StyleCop.CSharp.MaintainabilityRules";
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