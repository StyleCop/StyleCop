// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SpacingOptions.cs" company="http://stylecop.codeplex.com">
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
//   Defines options for SCfR#.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.ReSharper513.CodeCleanup.Options
{
    #region Using Directives

    using System.ComponentModel;
    using System.Reflection;
    using System.Text;

    #endregion

    /// <summary>
    /// Defines options.
    /// </summary>
    public class SpacingOptions : OptionsBase
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SpacingOptions"/> class. 
        /// </summary>
        public SpacingOptions()
        {
            this.InitPropertiesDefaults();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets a value indicating whether SA1001CommasMustBeSpacedCorrectly.
        /// </summary>
        /// <value>
        /// The s a 1001 commas must be spaced correctly.
        /// </value>
        [DisplayName("1001: Commas Must Be Spaced Correctly")]
        public bool SA1001CommasMustBeSpacedCorrectly { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether SA1005SingleLineCommentsMustBeginWithSingleSpace.
        /// </summary>
        /// <value>
        /// The s a 1005 single line comments must begin with single space.
        /// </value>
        [DisplayName("1005: Single Line Comments Must Begin With Single Space")]
        public bool SA1005SingleLineCommentsMustBeginWithSingleSpace { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether SA1006PreprocessorKeywordsMustNotBePrecededBySpace.
        /// </summary>
        /// <value>
        /// The s a 1006 preprocessor keywords must not be preceded by space.
        /// </value>
        [DisplayName("1006: Preprocessor Keywords Must Not Be Preceded By Space")]
        public bool SA1006PreprocessorKeywordsMustNotBePrecededBySpace { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether SA1021NegativeSignsMustBeSpacedCorrectly.
        /// </summary>
        /// <value>
        /// The s a 1021 negative signs must be spaced correctly.
        /// </value>
        [DisplayName("1021: Negative Signs Must Be Spaced Correctly")]
        public bool SA1021NegativeSignsMustBeSpacedCorrectly { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether SA1022PositiveSignsMustBeSpacedCorrectly.
        /// </summary>
        /// <value>
        /// The s a 1022 positive signs must be spaced correctly.
        /// </value>
        [DisplayName("1022: Positive Signs Must Be Spaced Correctly")]
        public bool SA1022PositiveSignsMustBeSpacedCorrectly { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether SA1025CodeMustNotContainMultipleWhitespaceInARow.
        /// </summary>
        /// <value>
        /// Whether code can contain multiple whitespace in a row.
        /// </value>
        [DisplayName("1025: Code Must Not Contain Multiple Whitespace In A Row")]
        public bool SA1025CodeMustNotContainMultipleWhitespaceInARow { get; set; }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the name of the analyzer.
        /// </summary>
        protected override string AnalyzerName
        {
            get
            {
                return "StyleCop.CSharp.SpacingRules";
            }
        }

        #endregion

        #region Public Methods and Operators

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

        #endregion
    }
}