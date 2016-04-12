// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StyleCopCodeCleanupOptions.cs" company="http://stylecop.codeplex.com">
//   MS-PL
// </copyright>
// <summary>
//   Defines the StyleCopCodeCleanupOptions type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace StyleCop.ReSharper1000.CodeCleanup
{
    using System.ComponentModel;
    using System.Text;

    /// <summary>
    /// Options for code cleanup
    /// </summary>
    public class StyleCopCodeCleanupOptions
    {
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

        /// <summary>
        /// Gets or sets a value indicating whether to fix StyleCop violations
        /// </summary>
        [DisplayName("Fix StyleCop violations")]
        public bool FixViolations { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to generate XML doc stubs
        /// </summary>
        [DisplayName("Create XML doc stubs")]
        public bool CreateXmlDocStubs { get; set; }

        /// <summary>
        /// Returns a string that represents the current <see cref="StyleCopCodeCleanupOptions"/> object.
        /// </summary>
        /// <returns>A string that represents the current <see cref="StyleCopCodeCleanupOptions"/> object.
        /// </returns>
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(this.FixViolations ? "Yes" : "No");
            stringBuilder.Append(this.CreateXmlDocStubs ? " (create XML doc stubs)" : " (do not create XML doc stubs)");
            return stringBuilder.ToString();
        }
    }
}
