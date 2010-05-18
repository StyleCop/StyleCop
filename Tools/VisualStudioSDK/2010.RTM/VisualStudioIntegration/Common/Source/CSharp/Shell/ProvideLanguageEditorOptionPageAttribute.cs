//////////////////////////////////////////////////////////////////////////////
// RegisterLanguageServiceAttribute
//
// Provide a general method for setting a language service's editor tool
// option page.
//
// This information is stored in the registry key
// <RegistrationRoot>\Languages\Language Services\[language]\EditorToolsOptions
// where [language] is the name of the language.
//
// Under EditorToolsOptions is a tree of pages and sub-pages that can
// nest any number of levels.  These pages correspond to options pages
// displayed in the Visual Studio Tools Options for editors (where the
// language name is displayed under which is a tree of option pages, each
// page containing appropriate options).
//
// Each key in this option page list contains a resoure id or literal
// string containing the localized name of the page (this is what is
// actually shown in the Tools Options dialog).  In addition, it also
// contains a package GUID and optionally a GUID of an option page.
//
// If there is no option page GUID then the key is considered a node in the
// tree of options and has no associated page.  Otherwise, the key is
// a leaf in the tree and its option page will be shown.
//
// Example:
// root base key: HKLM\Software\Microsoft\VisualStudio\9.0
//   Languages\
//     Language Services\
//       CSharp\
//         EditorToolsOptions\
//           Formatting\ = sz:#242
//             General\ = sz:#255
//               Package = sz:{GUID}
//               Page = sz:{GUID}
//             Indentation\ = sz:#250
//               Package = sz:{GUID}
//               Page = sz:{GUID}
//
// Goal:
// LanguageEditorOptionPage("CSharp","Formatting","#242");
// LanguageEditorOptionPage("CSharp","Formatting\General","#255","{PAGE GUID}");
// LanguageEditorOptionPage("CSharp","Formatting\Indentation","#250","{PAGE GUID}");
//
//////////////////////////////////////////////////////////////////////////////

#region Using directives

using System;
using System.Diagnostics;
using System.Collections;
using System.Globalization;
using System.Runtime.InteropServices;
using System.ComponentModel.Design;
using Microsoft.Win32;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.OLE.Interop;
using Microsoft.VisualStudio.Shell;
using MSVSIP = Microsoft.VisualStudio.Shell;

#endregion

namespace Microsoft.VisualStudio.Shell
{
    internal class LanguageToolsOptionCreator {
        // This class is used only to expose some static member, so we declare a private constructor
        // to avoid the creation of any instance of it.
        private LanguageToolsOptionCreator() { }

        private static string FormatRegKey(string languageName, string categoryName) {

            string strRegKey =
                string.Format(CultureInfo.InvariantCulture,
                              "{0}\\{1}\\{2}\\{3}",
                              RegistryPaths.languageServices,
                              languageName,
                              RegistryPaths.editorToolsOptions,
                              categoryName);
            return strRegKey;
        }

        internal static void CreateRegistryEntries(RegistrationAttribute.RegistrationContext context, string languageName, string categoryName, string categoryResourceId, Guid pageGuid)
        {

            using (RegistrationAttribute.Key serviceKey = context.CreateKey(FormatRegKey(languageName, categoryName))) {
                // Add specific entries corresponding to arguments to
                // constructor.
                serviceKey.SetValue(string.Empty, categoryResourceId);
                serviceKey.SetValue(RegistryPaths.package, context.ComponentType.GUID.ToString("B"));
                if (pageGuid != Guid.Empty) {
                    serviceKey.SetValue(RegistryPaths.page, pageGuid.ToString("B"));
                }
            }
        }

        internal static void RemoveRegistryEntries(RegistrationAttribute.RegistrationContext context, string languageName, string categoryName) {

            context.RemoveKey(FormatRegKey(languageName, categoryName));
        }
    }

    /// <include file='doc\ProvideLanguageEditorOptionPageAttribute.uex' path='docs/doc[@for="ProvideLanguageEditorToolsOptionCategoryAttribute"]' />
    /// <devdoc>
    /// This attribute is used to declare a ToolsOption category for a language.
    /// </devdoc>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public sealed class ProvideLanguageEditorToolsOptionCategoryAttribute : RegistrationAttribute {
        private string languageName;
        private string categoryName;
        private string categoryResourceId;

        /// <include file='doc\ProvideLanguageEditorOptionPageAttribute.uex' path='docs/doc[@for="ProvideLanguageEditorToolsOptionCategoryAttribute.ProvideLanguageEditorToolsOptionCategoryAttribute"]' />
        /// <devdoc>
        /// Creates a new ProvideLanguageEditorToolsOptionCategory attribute for a given language and category.
        /// </devdoc>
        /// <param name="languageName">The name of the language.</param>
        /// <param name="categoryName">The name of the category.</param>
        /// <param name="categoryResourceId">The id of the resource with the localized name for the category.</param>
        public ProvideLanguageEditorToolsOptionCategoryAttribute(string languageName, string categoryName, string categoryResourceId) {
            this.languageName = languageName;
            this.categoryName = categoryName;
            this.categoryResourceId = categoryResourceId;
        }

        /// <include file='doc\ProvideLanguageEditorOptionPageAttribute.uex' path='docs/doc[@for="ProvideLanguageEditorToolsOptionCategoryAttribute.Register"]' />
        public override void Register(RegistrationAttribute.RegistrationContext context) {
            context.Log.WriteLine(SR.GetString(SR.Reg_NotifyLanguageOptionCategory, languageName, categoryName));

            // Create the registry entries using the creator object.
            LanguageToolsOptionCreator.CreateRegistryEntries(context, languageName, categoryName, categoryResourceId, Guid.Empty);
        }

        /// <include file='doc\ProvideLanguageEditorOptionPageAttribute.uex' path='docs/doc[@for="ProvideLanguageEditorToolsOptionCategoryAttribute.Unregister"]' />
        public override void Unregister(RegistrationAttribute.RegistrationContext context) {
            // Remove the entries using the creator object.
            LanguageToolsOptionCreator.RemoveRegistryEntries(context, languageName, categoryName);
        }
    }

    /// <include file='doc\ProvideLanguageEditorOptionPageAttribute.uex' path='docs/doc[@for="ProvideLanguageEditorOptionPageAttribute"]' />
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public sealed class ProvideLanguageEditorOptionPageAttribute : ProvideOptionDialogPageAttribute
    {
        private string languageName;
        private string pageName;
        private string category;

        /// <include file='doc\ProvideLanguageEditorOptionPageAttribute.uex' path='docs/doc[@for="ProvideLanguageEditorOptionPageAttribute.ProvideLanguageEditorOptionPageAttribute"]' />
        /// <devdoc>
        /// Constructor for node with child option pages (to be added with
        /// additional ProvideLanguageEditorOptionPageAttribute).
        /// </devdoc>
        public ProvideLanguageEditorOptionPageAttribute(
            Type pageType,
            string languageName,
            string category,
            string pageName,
            string pageNameResourceId
            ) : base(pageType, pageNameResourceId)
        {
            this.languageName = languageName;
            this.pageName = pageName;
            this.category = category;
        }

        //////////////////////////////////////////////////////////////////////
        // Properties.

        /// <include file='doc\ProvideLanguageEditorOptionPageAttribute.uex' path='docs/doc[@for="ProvideLanguageEditorOptionPageAttribute.LanguageName"]' />
        public string LanguageName
        {
            get { return languageName; }
        }

        /// <include file='doc\ProvideLanguageEditorOptionPageAttribute.uex' path='docs/doc[@for="ProvideLanguageEditorOptionPageAttribute.PageGuid"]' />
        public Guid PageGuid
        {
            get { return PageType.GUID; }
        }

        private string FullPathToPage {
            get {
                if (string.IsNullOrEmpty(category))
                    return pageName;
                return string.Format("{0}\\{1}", category, pageName);
            }
        }
        //////////////////////////////////////////////////////////////////////
        // Public methods.

        /// <include file='doc\ProvideLanguageEditorOptionPageAttribute.uex' path='docs/doc[@for="ProvideLanguageEditorOptionPageAttribute.Register"]' />
        public override void Register(RegistrationAttribute.RegistrationContext context)
        {
            context.Log.WriteLine(SR.GetString(SR.Reg_NotifyLanguageOptionPage, LanguageName, PageNameResourceId));

            // Create the registry entries using the creator object.
            LanguageToolsOptionCreator.CreateRegistryEntries(context, LanguageName, FullPathToPage, PageNameResourceId, PageGuid);
        }

        /// <include file='doc\ProvideLanguageEditorOptionPageAttribute.uex' path='docs/doc[@for="ProvideLanguageEditorOptionPageAttribute.Unregister"]' />
        public override void Unregister(RegistrationAttribute.RegistrationContext context)
        {
            // Remove the registry entries for this page.
            LanguageToolsOptionCreator.RemoveRegistryEntries(context, LanguageName, FullPathToPage);
        }

    }
}
