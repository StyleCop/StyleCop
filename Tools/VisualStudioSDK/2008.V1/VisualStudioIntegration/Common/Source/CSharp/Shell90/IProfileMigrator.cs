//------------------------------------------------------------------------------
// <copyright file="IProfileMigrator.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>                                                                
//------------------------------------------------------------------------------

namespace Microsoft.VisualStudio.Shell {
    
    using System;
    using Microsoft.VisualStudio.Shell.Interop;

    /// <include file='doc\IProfileMigrator.uex' path='docs/doc[@for="IProfileMigrator"]' />
    /// <devdoc>
    /// Interface used to support custom migration of user settings from one version of the
    /// product to another.
    /// </devdoc>
    [CLSCompliant(false)]
    public interface IProfileMigrator {
        /// <include file='doc\IProfileMigrator.uex' path='docs/doc[@for=IProfileMigrator.MigrateSettings]/*' />
        /// <devdoc>
        /// Summary of MigrateSettings.
        /// </devdoc>
        /// <param name='reader'></param>
        /// <param name='writer'></param>
        void MigrateSettings(IVsSettingsReader reader, IVsSettingsWriter writer);
    }
}
