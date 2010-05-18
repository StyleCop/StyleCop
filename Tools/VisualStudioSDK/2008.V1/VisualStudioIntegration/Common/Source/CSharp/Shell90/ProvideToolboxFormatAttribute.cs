//------------------------------------------------------------------------------
// <copyright file="ProvideToolboxFormatAttribute.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>                                                                
//------------------------------------------------------------------------------

namespace Microsoft.VisualStudio.Shell {

    using System;

    /// <include file='doc\ProvideToolboxFormatAttribute.uex' path='docs/doc[@for="ProvideToolboxFormatAttribute"]' />
    /// <devdoc>
    ///     This attribute declares a single toolbox clipboard format that
    ///     the package supports.  Multiple attributes can be added to
    ///     a package to allow more than one clipboard format.  By
    ///     providing this attribute on your package, you enable
    ///     users to drag data objects containing this format onto the
    ///     toolbox. You must still handle the drop notifications 
    ///     yourself.
    /// </devdoc>
    [AttributeUsage(AttributeTargets.Class, Inherited=true, AllowMultiple=true)]
    public sealed class ProvideToolboxFormatAttribute : Attribute {

        private string _format;
    
        /// <include file='doc\ProvideToolboxFormatAttribute.uex' path='docs/doc[@for="ProvideToolboxFormatAttribute.ProvideToolboxFormatAttribute"]' />
        /// <devdoc>
        ///     Creates a new ProvideToolboxFormatAttribute.
        /// </devdoc>
        public ProvideToolboxFormatAttribute(string format) {

            if (format == null) {
                throw new ArgumentNullException("format");
            }

            _format = format;
        }
    
        /// <include file='doc\ProvideToolboxFormatAttribute.uex' path='docs/doc[@for="ProvideToolboxFormatAttribute.Format"]' />
        /// <devdoc>
        ///     Returns the clipboard format to enable for this package.
        /// </devdoc>
        public string Format {
            get {
                return _format;
            }
        }
    }
}

