// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StyleCopDescriptor.cs" company="http://stylecop.codeplex.com">
//   MS-PL
// </copyright>
// <summary>
//   Defines the StyleCopDescriptor type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace StyleCop.ReSharper.CodeCleanup
{
    using System;
    using System.ComponentModel;
    using System.Globalization;
    using System.Text;
    using System.Xml;

    using JetBrains.ReSharper.Feature.Services.CodeCleanup;
    using JetBrains.Util;

    /// <summary>
    /// The style cop descriptor.
    /// </summary>
    [DisplayName("Fix StyleCop violations")]
    [Category(CSharpCategory)]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class StyleCopDescriptor : CodeCleanupOptionDescriptor<StyleCopCodeCleanupOptions>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StyleCopDescriptor"/> class.
        /// </summary>
        public StyleCopDescriptor()
            : base("StyleCop")
        {
        }

        /// <summary>
        /// Summarize the options for the Code Cleanup dialog
        /// </summary>
        /// <param name="profile">
        /// The selected profile
        /// </param>
        /// <returns>
        /// A string that summarizes the options
        /// </returns>
        public override string Present(CodeCleanupProfile profile)
        {
            return profile.GetSetting(this).ToString();
        }

        /// <summary>
        /// Save the options
        /// </summary>
        /// <param name="element">
        /// The parent XML element to add the options to
        /// </param>
        /// <param name="value">
        /// The options to save
        /// </param>
        public override void Save(XmlElement element, StyleCopCodeCleanupOptions value)
        {
            element.CreateLeafElementWithValue(
                "FixViolations",
                value.FixViolations.ToString(CultureInfo.InvariantCulture));
            element.CreateLeafElementWithValue(
                "CreateXmlDocStubs",
                value.CreateXmlDocStubs.ToString(CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// Load the options
        /// </summary>
        /// <param name="element">
        /// The parent XML element
        /// </param>
        /// <returns>
        /// A loaded instance of the options
        /// </returns>
        public override StyleCopCodeCleanupOptions Load(XmlElement element)
        {
            return new StyleCopCodeCleanupOptions
                       {
                           FixViolations = bool.Parse(XmlUtil.ReadLeafElementValue(element, "FixViolations")),
                           CreateXmlDocStubs = bool.Parse(XmlUtil.ReadLeafElementValue(element, "CreateXmlDocStubs"))
                       };
        }
    }

    /// <summary>
    /// Options for code cleanup
    /// </summary>
    public class StyleCopCodeCleanupOptions
    {
        /// <summary>
        /// Option to fix StyleCop violations
        /// </summary>
        [DisplayName("Fix StyleCop violations")]
        public bool FixViolations { get; set; }

        /// <summary>
        /// Options to generate XML doc stubs
        /// </summary>
        [DisplayName("Create XML doc stubs")]
        public bool CreateXmlDocStubs { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="StyleCopCodeCleanupOptions"/> class.
        /// </summary>
        public StyleCopCodeCleanupOptions()
        {
            this.FixViolations = true;

            // TODO: What's the best default?
            // I like the argument that we shouldn't blindly create XML docs, but set
            // them properly, but it's nice to be able to fix up everything we can...
            this.CreateXmlDocStubs = false;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(this.FixViolations ? "Yes" : "No");
            stringBuilder.Append(this.CreateXmlDocStubs ? " (create XML doc stubs)" : " (do not create XML doc stubs)");
            return stringBuilder.ToString();
        }
    }
}