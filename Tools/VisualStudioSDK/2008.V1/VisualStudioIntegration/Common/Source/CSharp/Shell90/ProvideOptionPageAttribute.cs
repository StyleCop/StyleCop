//------------------------------------------------------------------------------
// <copyright file="ProvideOptionPageAttribute.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>                                                                
//------------------------------------------------------------------------------

namespace Microsoft.VisualStudio.Shell {

    using System;
    using System.Globalization;

    /// <include file='doc\ProvideOptionPageAttribute.uex' path='docs/doc[@for="ProvideOptionPageAttribute"]' />
    /// <devdoc>
    ///     This attribute declares that a package offers one or more option pages.  
    ///     Option pages are exposed to the user through Visual Studio's Tools->Options 
    ///     dialog.  The first parameter to this attribute is the type of option page, 
    ///     which is a type that must derive from DialogPage.  Option page attributes 
    ///     are read by the package class when Visual Studio requests a particular option 
    ///     page GUID.  Package will walk the attributes and try to match the requested 
    ///     GUID to a GUID on a type in the package. 
    /// </devdoc>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple=true, Inherited=true)]
    public sealed class ProvideOptionPageAttribute : ProvideOptionDialogPageAttribute {

        private string  _categoryName;
        private string  _pageName;
        private short   _categoryResourceID;
        private bool    _supportsAutomation;
        private bool    _noShowAllView;
        private bool    _supportsProfiles = false;
        private ProfileMigrationType _migrationType = ProfileMigrationType.None;
        
        /// <include file='doc\ProvideOptionPageAttribute.uex' path='docs/doc[@for="ProvideOptionPageAttribute.ProvideOptionPageAttribute"]' />
        /// <devdoc>
        ///     The page type is a type that derives from
        ///     DialogPage.  The nameResourceID
        ///     parameter specifies a Win32 resource ID in the 
        ///     stored in the native UI resource satellite
        ///     that describes the name of this page.
        ///     The categoryResourceID specifies the page
        ///     category name.
        /// </devdoc>        
        public ProvideOptionPageAttribute(Type pageType, string categoryName, string pageName, short categoryResourceID, short pageNameResourceID, bool supportsAutomation) 
            : base (pageType, "#"+pageNameResourceID.ToString()) {
            if (categoryName == null) {
                throw new ArgumentNullException("categoryName");
            }
            if (pageName == null) {
                throw new ArgumentNullException("pageName");
            }

            _categoryName = categoryName;
            _pageName = pageName;
            _categoryResourceID = categoryResourceID;
            _supportsAutomation = supportsAutomation;
        }

        /// <devdoc>
        /// The VB Simplified option page is visible only for "simply" pages, that is a page that sets this
        /// parameter to true.
        /// </devdoc>
        public bool NoShowAllView {
            get { return _noShowAllView;  }
            set { _noShowAllView = value; }
        }

        
        /// <include file='doc\ProvideOptionPageAttribute.uex' path='docs/doc[@for="ProvideOptionPageAttribute.TypeId"]' />
        /// <devdoc>
        /// Identity of this instance of the attribute.
        /// </devdoc>
        public override object TypeId {
            get {
                return this;
            }
        }

        /// <include file='doc\ProvideOptionPageAttribute.uex' path='docs/doc[@for="ProvideOptionPageAttribute.CategoryName"]' />
        /// <devdoc>
        ///     The programmatic name for this category (non localized).
        /// </devdoc>
        public string CategoryName {
            get {
                return _categoryName;
            }
        }

        /// <include file='doc\ProvideOptionPageAttribute.uex' path='docs/doc[@for="ProvideOptionPageAttribute.CategoryResourceID"]' />
        /// <devdoc>
        ///     The native resourceID of the category name for this page.
        /// </devdoc>
        public short CategoryResourceID {
            get {
                return _categoryResourceID;
            }
        }

        /// <include file='doc\ProvideOptionPageAttribute.uex' path='docs/doc[@for="ProvideOptionPageAttribute.PageName"]' />
        /// <devdoc>
        ///     The programmatic name for this page (non localized).
        /// </devdoc>
        public string PageName {
            get {
                return _pageName;
            }
        }

        /// <include file='doc\ProvideOptionPageAttribute.uex' path='docs/doc[@for="ProvideOptionPageAttribute.SupportsAutomation"]' />
        /// <devdoc>
        ///     True if this page should be registered as supporting automation.
        /// </devdoc>
        public bool SupportsAutomation {
            get {
                return _supportsAutomation;
            }
        }

        /// <include file='doc\ProvideOptionPageAttribute.uex' path='docs/doc[@for="ProvideOptionPageAttribute.SupportsProfiles"]' />
        /// <devdoc>
        ///     True if this page should be registered as supporting profiles.  
        ///     Note: Only works if SupportsAutomation is true.  The ProvideProfile attribute 
        ///     can also be used to specify profile support for Tools/Options pages.
        /// </devdoc>
        public bool SupportsProfiles {
            get {
                return _supportsProfiles;
            }
            set {
                _supportsProfiles = value;
            }
        }

        /// <include file='doc\ProvideOptionPageAttribute.uex' path='docs/doc[@for="ProvideOptionPageAttribute.ProfileMigrationType"]' />
        /// <devdoc>
        ///     Specifies the migration action to take for this category.
        /// </devdoc>
        public ProfileMigrationType ProfileMigrationType
        {
            get { return _migrationType; }
            set { _migrationType = value; }
        }

        private string ToolsOptionsPagesRegKey
        {
            get { return string.Format(CultureInfo.InvariantCulture, "ToolsOptionsPages\\{0}", CategoryName); }
        }

        private string AutomationCategoryRegKey
        {
            get { return string.Format(CultureInfo.InvariantCulture, "AutomationProperties\\{0}", CategoryName); }
        }
        private string AutomationRegKey
        {
            get { return String.Format(CultureInfo.InvariantCulture, "{0}\\{1}", AutomationCategoryRegKey, PageName); }
        }

        /// <include file='doc\ProvideOptionPageAttribute.uex' path='docs/doc[@for="Register"]' />
        /// <devdoc>
        ///     Called to register this attribute with the given context.  The context
        ///     contains the location where the registration inforomation should be placed.
        ///     it also contains such as the type being registered, and path information.
        ///
        ///     This method is called both for registration and unregistration.  The difference is
        ///     that unregistering just uses a hive that reverses the changes applied to it.
        /// </devdoc>
        public override void Register(RegistrationContext context) {
            context.Log.WriteLine(string.Format(Resources.Culture, Resources.Reg_NotifyOptionPage, CategoryName, PageName));

            using (Key toolsOptionsKey = context.CreateKey(ToolsOptionsPagesRegKey))
            {
                toolsOptionsKey.SetValue(string.Empty, string.Format(CultureInfo.InvariantCulture, "#{0}", CategoryResourceID));
                toolsOptionsKey.SetValue("Package", context.ComponentType.GUID.ToString("B"));

                using (Key pageKey = toolsOptionsKey.CreateSubkey(PageName))
                {
                    pageKey.SetValue(string.Empty, PageNameResourceId);
                    pageKey.SetValue("Package", context.ComponentType.GUID.ToString("B"));
                    pageKey.SetValue("Page", PageType.GUID.ToString("B"));
                    if ( NoShowAllView )
                        pageKey.SetValue("NoShowAllView", 1);
                }
            }

            if (SupportsAutomation) {
                using (Key automationKey = context.CreateKey(AutomationRegKey))
                {
                    automationKey.SetValue("Name", string.Format(CultureInfo.InvariantCulture, "{0}.{1}", CategoryName, PageName));
                    automationKey.SetValue("Package", context.ComponentType.GUID.ToString("B"));
                    if ( SupportsProfiles ) {
                        automationKey.SetValue("ProfileSave", 1);
                        automationKey.SetValue("VSSettingsMigration", (int)ProfileMigrationType);
                    }
                }
            }

        }

        /// <include file='doc\ProvideOptionPageAttribute.uex' path='docs/doc[@for="Unregister"]' />
        /// <devdoc>
        /// Called to remove this attribute from the given context.
        /// </devdoc>
        public override void Unregister(RegistrationContext context)
        {
            context.RemoveKey(ToolsOptionsPagesRegKey);

            if (SupportsAutomation)
            {
                context.RemoveKey(AutomationRegKey);
                context.RemoveKeyIfEmpty(AutomationCategoryRegKey);
            }
        }
    }
}

