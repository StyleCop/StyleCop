//////////////////////////////////////////////////////////////////////////////
// ProvideLanguageCodeExpansionAttribute
//
// This attribute class will ease the pain of registering a language
// service's support for code snippets written with the managed
// package framework.
//
// Usage:
// [ProvideLanguageCodeExpansionAttribute(<type> or "<GUID>",
//                                        <language name>,
//                                        <language name id>,
//                                        "<language identifier>",
//                                        "<Path to snippet index file>",
//   ShowRoots = true | false
//   SearchPaths = "<semi-colon-delimited path list to snippet index
//                  files>"
//   ForceCreateDirs = "<semi-colon-delimited list of dirs that the
//                  expansion manager will create>
// )]
//
//////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Runtime.InteropServices;
using System.ComponentModel.Design;
using Microsoft.Win32;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.OLE.Interop;
using Microsoft.VisualStudio.Shell;

//namespace Vsip.TestPackage
namespace Microsoft.VisualStudio.Shell
{
    /// <include file='doc\ProvideLanguageCodeExpansionAttribute.uex' path='docs/doc[@for="ProvideLanguageCodeExpansionAttribute"]' />
    [ComVisible(false)]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public sealed class ProvideLanguageCodeExpansionAttribute : RegistrationAttribute
    {
        //////////////////////////////////////////////////////////////////////
        // ProvideLanguageServiceAttribute Private fields.
        //
        private Guid   languageServiceGuid;
        private string languageName;
        private string snippetIndexPath;
        private string searchPaths;
        private string forceCreateDirs;
        private string languageIdString;
        private string displayName;
        private bool   showRoots = false;


        //////////////////////////////////////////////////////////////////////
        // ProvideLanguageServiceAttribute Public Methods

        /// <include file='doc\ProvideLanguageCodeExpansionAttribute.uex' path='docs/doc[@for="ProvideLanguageCodeExpansionAttribute.ProvideLanguageCodeExpansionAttribute"]' />
        /// <devdoc>
        /// Registers a language service's support for code snippets.
        /// </devdoc>
        /// <param name="languageService">Language Service class. This can be a string with the value of the Guid or the Type of the language service.</param>
        /// <param name="languageName">Name of the language service.  Used in the registry so cannot be localized.</param>
        /// <param name="languageResourceId">Resource ID of the localized name of the language service.</param>
        /// <param name="languageIdentifier">String used to identify snippets and the snippets index file.</param>
        /// <param name="pathToSnippetIndexFile">Full path to a snippets index file.</param>
        public ProvideLanguageCodeExpansionAttribute(
            object languageService,
            string languageName,
            int languageResourceId,
            string languageIdentifier,
            string pathToSnippetIndexFile)
        {
            // Get the guid of the language service.
            if (languageService is Type)
            {
                this.languageServiceGuid = ((Type)languageService).GUID;
            }
            else if (languageService is string)
            {
                this.languageServiceGuid = new Guid((string)languageService);
            }
            else
                throw new ArgumentException();

            this.languageName     = languageName;
            this.snippetIndexPath = pathToSnippetIndexFile;
            this.displayName      = languageResourceId.ToString(CultureInfo.InvariantCulture);
            this.languageIdString = languageIdentifier;
        }

        // ProvideLanguageCodeExpansionAttribute Properties.

        /// <include file='doc\ProvideLanguageCodeExpansionAttribute.uex' path='docs/doc[@for="ProvideLanguageCodeExpansionAttribute.LanguageServiceSid"]' />
        public Guid LanguageServiceSid
        {
            get { return languageServiceGuid; }
        }

        /// <include file='doc\ProvideLanguageCodeExpansionAttribute.uex' path='docs/doc[@for="ProvideLanguageCodeExpansionAttribute.LanguageName"]' />
        public string LanguageName
        {
            get { return languageName; }
        }


        //////////////////////////////////////////////////////////////////////
        // The following properties are entries in the language key.  These
        // are all optional (however, if they are specified by the user, they
        // will be created in the registry, regardless if they have a value or
        // not).

        /// <include file='doc\ProvideLanguageCodeExpansionAttribute.uex' path='docs/doc[@for="ProvideLanguageCodeExpansionAttribute.ShowRoots"]' />
        public bool ShowRoots
        {
            get { return showRoots; }
            set { showRoots = value; }
        }

        /// <include file='doc\ProvideLanguageCodeExpansionAttribute.uex' path='docs/doc[@for="ProvideLanguageCodeExpansionAttribute.SearchPaths"]' />
        public string SearchPaths
        {
            get { return searchPaths; }
            set { searchPaths = value; }
        }

        /// <include file='doc\ProvideLanguageCodeExpansionAttribute.uex' path='docs/doc[@for="ProvideLanguageCodeExpansionAttribute.ForceCreateDirs"]' />
        public string ForceCreateDirs
        {
            get { return forceCreateDirs; }
            set { forceCreateDirs = value; }
        }
        //////////////////////////////////////////////////////////////////////
        // Helper property
        private string LanguageRegistryKey
        {
            get
            {
                return string.Format(CultureInfo.InvariantCulture,
                                     "{0}\\{1}",
                                     RegistryPaths.codeExpansion,
                                     LanguageName);
            }
        }

        
        //////////////////////////////////////////////////////////////////////
        // ProvideLanguageCodeExpansionAttribute Public Methods.

        /// <include file='doc\ProvideLanguageCodeExpansionAttribute.uex' path='docs/doc[@for="ProvideLanguageCodeExpansionAttribute.Register"]' />
        public override void Register(RegistrationAttribute.RegistrationContext context)
        {
            context.Log.WriteLine(SR.GetString(SR.Reg_NotifyLanguageCodeExpansion, LanguageServiceSid.ToString("B")));

            string packageGuid = context.ComponentType.GUID.ToString("B");
            // Create our top-most language key
            using (Key serviceKey = context.CreateKey(LanguageRegistryKey))
            {
                // Add specific entries corresponding to arguments to
                // ProvideLanguageCodeExpansionAttribute constructor.
                serviceKey.SetValue(string.Empty, LanguageServiceSid.ToString("B"));
                serviceKey.SetValue(RegistryPaths.package, packageGuid);
                serviceKey.SetValue(RegistryPaths.displayName, displayName);
                serviceKey.SetValue(RegistryPaths.languageStringId, languageIdString);
                serviceKey.SetValue(RegistryPaths.indexPath, snippetIndexPath);
                serviceKey.SetValue(RegistryPaths.showRoots, showRoots ? 1 : 0);
                if (!string.IsNullOrEmpty(SearchPaths))
                {
                    using (Key pathsKey = serviceKey.CreateSubkey(RegistryPaths.paths))
                    {
                        pathsKey.SetValue(LanguageName, SearchPaths);
                    }
                }
                if (!string.IsNullOrEmpty(ForceCreateDirs))
                {
                    using (Key forceCreateKey = serviceKey.CreateSubkey(RegistryPaths.forceCreateDirs))
                    {
                        forceCreateKey.SetValue(LanguageName, ForceCreateDirs);
                    }
                }
            }
        }

        /// <include file='doc\ProvideLanguageCodeExpansionAttribute.uex' path='docs/doc[@for="ProvideLanguageCodeExpansionAttribute.Unregister"]' />
        public override void Unregister(RegistrationAttribute.RegistrationContext context)
        {
            context.RemoveKey(LanguageRegistryKey);
        }
    }
}
