namespace CSharpAnalyzersTest.TestData.Spacing
{
    using System.ComponentModel;

    internal class AttributeBrackets
    {
        /// <summary>
        /// Gets or sets a value indicating a Property.
        /// </summary>
        [
        Description("Description of property"),
        DefaultValue(typeof(int),"1"),
        Category("Category"),
        Browsable(true)
        ]
        public int Property1 { get; set; }

        /// <summary>
        /// Gets or sets a value indicating a Property.
        /// </summary>
        [ Description("Description of property"),
        DefaultValue(typeof(int),"1"),
        Category("Category"),
        Browsable(true) ]
        public int Property2 { get; set; }
    }
}
