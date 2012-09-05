// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OrderingOptions.cs" company="http://stylecop.codeplex.com">
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

namespace StyleCop.ReSharper600.CodeCleanup.Options
{
    #region Using Directives

    using System.ComponentModel;
    using System.Reflection;
    using System.Text;

    using StyleCop.ReSharper600.CodeCleanup.Styles;

    #endregion

    /// <summary>
    /// Defines options for SCfR#.
    /// </summary>
    public class OrderingOptions : OptionsBase
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the OrderingOptions class.
        /// </summary>
        public OrderingOptions()
        {
            this.InitPropertiesDefaults();
            this.AlphabeticalUsingDirectives = AlphabeticalUsingsStyle.Alphabetical;
            this.ExpandUsingDirectives = ExpandUsingsStyle.FullyQualify;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the enumeration to define the behavior of sorting Using Declarations.
        /// </summary>
        [DisplayName("Organize 'using' statements alphabetically")]
        public AlphabeticalUsingsStyle AlphabeticalUsingDirectives { get; set; }

        /// <summary>
        /// Gets or sets the enumeration to define the behavior of Usings declarations.
        /// </summary>
        [DisplayName("Expand 'using' directives")]
        public ExpandUsingsStyle ExpandUsingDirectives { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to order get and set on properties and indexers.
        /// </summary>
        [DisplayName("1212: Property Accessors Must Follow Order")]
        public bool SA1212PropertyAccessorsMustFollowOrder { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to order event accessors.
        /// </summary>
        [DisplayName("1213: Event Accessors Must Follow Order")]
        public bool SA1213EventAccessorsMustFollowOrder { get; set; }

        /// <summary>
        /// Gets the name of the analyzer.
        /// </summary>
        protected override string AnalyzerName
        {
            get
            {
                return "StyleCop.CSharp.OrderingRules";
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