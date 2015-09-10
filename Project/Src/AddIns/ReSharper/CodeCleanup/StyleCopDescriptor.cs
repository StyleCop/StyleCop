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
    using System.ComponentModel;

    using JetBrains.ReSharper.Feature.Services.CodeCleanup;

    /// <summary>
    /// The style cop descriptor.
    /// </summary>
    [DisplayName("Apply StyleCop rules")]
    [Category(CSharpCategory)]
    [DefaultValue(true)]
    public class StyleCopDescriptor : CodeCleanupBoolOptionDescriptor
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StyleCopDescriptor"/> class.
        /// </summary>
        public StyleCopDescriptor()
            : base("StyleCopReformat")
        {
        }
    }
}