//------------------------------------------------------------------------------
// <copyright file="ProvideViewAttribute.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>                                                                
//------------------------------------------------------------------------------

namespace Microsoft.VisualStudio.Shell {

    using System;

    /// <include file='doc\ProvideViewAttribute.uex' path='docs/doc[@for="ProvideViewAttribute"]' />
    /// <devdoc>
    ///     This attribute declares that an editor factory offers a particular logical view.
    /// </devdoc>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple=true, Inherited=true)]
    public sealed class ProvideViewAttribute : Attribute {

        private LogicalView _logicalView;
        private string      _physicalView;

        /// <include file='doc\ProvideViewAttribute.uex' path='docs/doc[@for="ProvideViewAttribute.ProvideViewAttribute"]' />
        /// <devdoc>
        ///     Creates a new ProvideViewAttribute.
        /// </devdoc>
	    public ProvideViewAttribute (LogicalView logicalView, string physicalView) {
            _logicalView = logicalView;
            _physicalView = physicalView;   // NULL is valid here.
        }

        /// <include file='doc\ProvideViewAttribute.uex' path='docs/doc[@for="ProvideViewAttribute.LogicalView"]' />
        /// <devdoc>
        ///     Returns the logical view in this attribute.
        /// </devdoc>
	    public LogicalView LogicalView {
            get {
                return _logicalView;
            }
        }

        /// <include file='doc\ProvideViewAttribute.uex' path='docs/doc[@for="ProvideViewAttribute.PhysicalView"]' />
        /// <devdoc>
        ///     Returns the physical view that is mapped to the logical view.
        /// </devdoc>
	    public string PhysicalView {
            get {
                return _physicalView;
            }
        }
    }
}

