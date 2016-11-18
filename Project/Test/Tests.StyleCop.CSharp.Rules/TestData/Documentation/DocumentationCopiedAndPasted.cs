using System;

namespace CSharpAnalyzersTest.TestData.Documentation
{
    /// <summary>
    /// THe DocumentationCopiedAndPasted class.
    /// </summary>
    class DocumentationCopiedAndPasted
    {

        /// <summary>
        /// Duplicated text.
        /// </summary>
        /// <remarks>Duplicated text.</remarks>
        public const string Constant = "Constant";

        /// <summary>
        /// Gets or sets something.
        /// </summary>
        /// <remarks>Gets or sets something.</remarks>
        /// <value>Gets or sets something.</value>
        public int Something { get; set; }

        /// <summary>
        /// Duplicated text.
        /// </summary>
        /// <remarks>Duplicated text.</remarks>
        public event EventHandler Event;

        /// <summary>
        /// Finalizes an instance of the DocumentationCopiedAndPasted class.
        /// </summary>
        /// <remarks>Finalizes an instance of the DocumentationCopiedAndPasted class.</remarks>
        ~DocumentationCopiedAndPasted()
        {
        }
    }
}
