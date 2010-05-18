//------------------------------------------------------------------------------
// <copyright file="IProfileManager.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>                                                                
//------------------------------------------------------------------------------

namespace Microsoft.VisualStudio.Shell {
    
    using System;
    using Microsoft.VisualStudio.Shell.Interop;

    /// <include file='doc\IProfileManager.uex' path='docs/doc[@for="IProfileManager"]' />
    /// <devdoc>
    /// Interface used to provide import/export capabilities of properties
    /// usually stored in the registry.
    /// </devdoc>
    [CLSCompliant(false)]
    public interface IProfileManager {
        /// <include file='doc\IProfileManager.uex' path='docs/doc[@for=IProfileManager.SaveSettingsToXml]/*' />
        /// <devdoc>
        /// Summary of SaveSettingsToXml.
        /// </devdoc>
        /// <param name='writer'></param>
        void SaveSettingsToXml(IVsSettingsWriter writer);

        /// <include file='doc\IProfileManager.uex' path='docs/doc[@for=IProfileManager.LoadSettingsFromXml]/*' />
        /// <devdoc>
        /// Summary of LoadSettingsFromXml.
        /// </devdoc>
        /// <param name='reader'></param>
        void LoadSettingsFromXml(IVsSettingsReader reader);

        /// <include file='doc\IProfileManager.uex' path='docs/doc[@for=IProfileManager.SaveSettingsToStorage]/*' />
        /// <devdoc>
        /// Summary of SaveSettingsToStorage.
        /// </devdoc>
        void SaveSettingsToStorage();

        /// <include file='doc\IProfileManager.uex' path='docs/doc[@for=IProfileManager.LoadSettingsFromStorage]/*' />
        /// <devdoc>
        /// Summary of LoadSettingsFromStorage.
        /// </devdoc>
        void LoadSettingsFromStorage();

        /// <include file='doc\IProfileManager.uex' path='docs/doc[@for=IProfileManager.ResetSettings]/*' />
        /// <devdoc>
        /// Reset your settings (__UserSettingsFlags.USF_ResetOnImport was set).
        /// </devdoc>
        void ResetSettings();
    }
}
