//------------------------------------------------------------------------------
// <copyright file="LogicalView.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>                                                                
//------------------------------------------------------------------------------

namespace Microsoft.VisualStudio.Shell {

    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Globalization;

    /// <include file='doc\LogicalView.uex' path='docs/doc[@for="LogicalView"]' />
    /// <devdoc>
    ///     This enum lists the supported logical views.
    /// </devdoc>
    [TypeConverter(typeof(LogicalViewConverter))]
    public enum LogicalView {

    	/// <include file='doc\LogicalView.uex' path='docs/doc[@for="LogicalView.Primary"]/*' />
    	Primary,
    	/// <include file='doc\LogicalView.uex' path='docs/doc[@for="LogicalView.Any"]/*' />
    	Any,
        /// <include file='doc\LogicalView.uex' path='docs/doc[@for="LogicalView.Debugging"]/*' />
        Debugging,
        /// <include file='doc\LogicalView.uex' path='docs/doc[@for="LogicalView.Code"]/*' />
        Code,
        /// <include file='doc\LogicalView.uex' path='docs/doc[@for="LogicalView.Designer"]/*' />
        Designer,
        /// <include file='doc\LogicalView.uex' path='docs/doc[@for="LogicalView.Text"]/*' />
        Text,
        /// <include file='doc\LogicalView.uex' path='docs/doc[@for="LogicalView.UserChoose"]/*' />
        UserChoose,
        /// <include file='doc\LogicalView.uex' path='docs/doc[@for="LogicalView.ProjectSpecific"]/*' />
        ProjectSpecific
    }

    /// <devdoc>
    ///     This type converter inherits from the normal enum
    ///     converter.  It adds the ability to convert to/from
    ///     GUID types.
    /// </devdoc>
    internal class LogicalViewConverter : EnumConverter {

        private Guid[] _guids = new Guid[] {
            new Guid("00000000-0000-0000-0000-000000000000"),
            new Guid("FFFFFFFF-FFFF-FFFF-FFFF-FFFFFFFFFFFF"),
            new Guid("7651A700-06E5-11D1-8EBD-00A0C90F26EA"),
            new Guid("7651A701-06E5-11D1-8EBD-00A0C90F26EA"),
            new Guid("7651A702-06E5-11D1-8EBD-00A0C90F26EA"),
            new Guid("7651A703-06E5-11D1-8EBD-00A0C90F26EA"),
            new Guid("7651A704-06E5-11D1-8EBD-00A0C90F26EA"),
            new Guid("80A3471A-6B87-433E-A75A-9D461DE0645F")
        };

        private LogicalView[] _views = new LogicalView[] {
            LogicalView.Primary,
            LogicalView.Any,
            LogicalView.Debugging,
            LogicalView.Code,
            LogicalView.Designer,
            LogicalView.Text,
            LogicalView.UserChoose,
            LogicalView.ProjectSpecific
        };

        public LogicalViewConverter(Type enumType) : base(enumType) {
            Debug.Assert(_views.Length == _guids.Length, "Mismatch in view / guid relationship");
        }

        /// <devdoc>
        ///     Gets a value indicating whether this converter
        ///     can convert an object in the given source type to an enumeration object using
        ///     the specified context.
        /// </devdoc>
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType) {
            if (sourceType == typeof(Guid)) {
                return true;
            }
            return base.CanConvertFrom(context, sourceType);
        }
        
        /// <devdoc>
        ///     Gets a value indicating whether this converter can
        ///     convert an object to the given destination type using the context.
        /// </devdoc>
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType) {
            if (destinationType == typeof(Guid)) {
                return true;
            }
            return base.CanConvertTo(context, destinationType);
        }

        /// <devdoc>
        ///     Converts the specified value object to an enumeration object.
        /// </devdoc>
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value) {
            if (value is Guid) {
                for (int i = 0; i < _guids.Length; i++) {
                    if (value.Equals(_guids[i])) {
                        return _views[i];
                    }
                }
            }
            return base.ConvertFrom(context, culture, value);
        }
    
        /// <devdoc>
        ///     Converts the given value object to the specified destination type.
        /// </devdoc>
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType) {
            if (destinationType == null) {
                throw new ArgumentNullException("destinationType");
            }

            if (destinationType == typeof(Guid) && value != null) {
                for (int i = 0; i < _views.Length; i++) {
                    if (value.Equals(_views[i])) {
                        return _guids[i];
                    }
                }
            }
            
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}

