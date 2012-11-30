// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LayoutOptions.cs" company="http://stylecop.codeplex.com">
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
//   Defines options for LayoutOptions.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.ReSharper611.CodeCleanup.Options
{
    #region Using Directives

    using System.ComponentModel;
    using System.Reflection;
    using System.Text;

    #endregion

    /// <summary>
    /// Defines options for LayoutOptions.
    /// </summary>
    public class LayoutOptions : OptionsBase
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="LayoutOptions"/> class. 
        /// </summary>
        public LayoutOptions()
        {
            this.InitPropertiesDefaults();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets a value indicating whether.
        /// </summary>
        [DisplayName("1500: Curly Brackets For Multi Line Statements Must Not Share Line ")]
        public bool SA1500CurlyBracketsForMultiLineStatementsMustNotShareLine { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether a blank line should be removed from an opening curly bracket.
        /// </summary>
        [DisplayName("1509: Opening Curly Brackets Must Not Be Preceded By Blank Line")]
        public bool SA1509OpeningCurlyBracketsMustNotBePrecededByBlankLine { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether a blank line should be removed from a chained statement like try/catch/finally or if/else.
        /// </summary>
        [DisplayName("1510: Chained Statement Blocks Must Not Be Preceded By Blank Line")]
        public bool SA1510ChainedStatementBlocksMustNotBePrecededByBlankLine { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether a blank line should be removed from a while statement.
        /// </summary>
        [DisplayName("1511: While Do Footer Must Not Be Preceded By Blank Line...")]
        public bool SA1511WhileDoFooterMustNotBePrecededByBlankLine { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether a blank line should be removed form a single line comment.
        /// </summary>
        [DisplayName("1512: Single Line Comments Must Not Be Followed By Blank Line")]
        public bool SA1512SingleLineCommentsMustNotBeFollowedByBlankLine { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether a blank line should be inserted after a curly bracket.
        /// </summary>
        [DisplayName("1513: Closing Curly Bracket Must Be Followed By Blank Line")]
        public bool SA1513ClosingCurlyBracketMustBeFollowedByBlankLine { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether a blank line should be inserted before a doc comment.
        /// </summary>
        [DisplayName("1514: Element Documentation Headers Must Be Preceded By Blank Line")]
        public bool SA1514ElementDocumentationHeaderMustBePrecededByBlankLine { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether a blank line should be inserted.
        /// </summary>
        [DisplayName("1515: Single Line Comments Must Be Proceeded By Blank Line")]
        public bool SA1515SingleLineCommentMustBeProceededByBlankLine { get; set; }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the name of the analyzer.
        /// </summary>
        protected override string AnalyzerName
        {
            get
            {
                return "StyleCop.CSharp.LayoutRules";
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