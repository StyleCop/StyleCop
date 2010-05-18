

//------------------------------------------------------------------------------
// <copyright file="ProvideProfileAttribute.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>                                                                
//------------------------------------------------------------------------------

namespace Microsoft.VisualStudio.Shell {

    using System;
    using System.Globalization;

    /// <include file='doc\ProvideProfileAttribute.uex' path='docs/doc[@for="ProvideProfileAttribute"]' />
    /// <devdoc>
    ///     This attribute declares a class as a Visual Studio Profile item and
    ///     places items in the VS registry for the User Settings.
    ///     This may optionally specify a Tools Options page.
    /// </devdoc>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple=true, Inherited=true)]
    public sealed class ProvideProfileAttribute : RegistrationAttribute {
        
        private Type    _objectType;
        private string  _groupName;
        private string  _categoryName;
        private string  _objectName;
        private string  _alternateParent;
        private string  _resourcePackageGuid;
        private short   _groupResourceID = 0;
        private short   _categoryResourceID = 0;
        private short   _objectNameResourceID = 0;
        private short   _descriptionResourceID = 0;
        private bool    _isToolsOptionPage;

        /// <include file='doc\ProvideProfileAttribute.uex' path='docs/doc[@for="ProvideProfileAttribute.ProvideProfileAttribute1"]' />
        /// <devdoc>
        /// </devdoc>        
        public ProvideProfileAttribute(Type objectType, string categoryName, string objectName, short categoryResourceID, short objectNameResourceID, bool isToolsOptionPage) {
            if (objectType == null) {
                throw new ArgumentNullException("objectType");
            }
            if (categoryName == null) {
                throw new ArgumentNullException("categoryName");
            }
            if (objectName == null) {
                throw new ArgumentNullException("objectName");
            }
            if (!typeof(IProfileManager).IsAssignableFrom(objectType)) {
                throw new ArgumentException(SR.GetString(SR.General_InvalidType, typeof(IProfileManager).FullName), objectType.FullName);
            }

            _objectType = objectType;
            _categoryName = categoryName;
            _objectName = objectName;
            _categoryResourceID = categoryResourceID;
            _objectNameResourceID = objectNameResourceID;
            _isToolsOptionPage = isToolsOptionPage;
        }


        /// <devdoc>
        ///     The programmatic name for this Group (non localized).
        /// </devdoc>
        public string GroupName
        {
            get { return _groupName; }
            set { _groupName = value; }
        }

        /// <devdoc>
        ///     The native resourceID of the group name for this page in the Profile.
        /// </devdoc>
        public short GroupResourceID
        {
            get { return _groupResourceID; }
            set { _groupResourceID = value; }
        }

        /// <include file='doc\ProvideProfileAttribute.uex' path='docs/doc[@for="ProvideProfileAttribute.CategoryName"]' />
        /// <devdoc>
        ///     The programmatic name for this category (non localized).
        /// </devdoc>
        public string CategoryName {
            get {
                return _categoryName;
            }
        }

        /// <include file='doc\ProvideProfileAttribute.uex' path='docs/doc[@for="ProvideProfileAttribute.CategoryResourceID"]' />
        /// <devdoc>
        ///     The native resourceID of the category name for this page.
        /// </devdoc>
        public short CategoryResourceID {
            get {
                return _categoryResourceID;
            }
        }

        /// <include file='doc\ProvideProfileAttribute.uex' path='docs/doc[@for="ProvideProfileAttribute.PageName"]' />
        /// <devdoc>
        ///     The programmatic name for this page (non localized).
        /// </devdoc>
        public string ObjectName {
            get {
                return _objectName;
            }
        }

        /// <include file='doc\ProvideProfileAttribute.uex' path='docs/doc[@for="ProvideProfileAttribute.PageNameResourceID"]' />
        /// <devdoc>
        ///     The native resourceID of the name for this page in the Profile.
        /// </devdoc>
        public short ObjectNameResourceID {
            get {
                return _objectNameResourceID;
            }
        }
        
        /// <include file='doc\ProvideProfileAttribute.uex' path='docs/doc[@for="ProvideProfileAttribute.PageType"]' />
        /// <devdoc>
        ///     The type of this object.
        /// </devdoc>
        public Type ObjectType {
            get {
                return _objectType;
            }
        }
    
        /// <devdoc>
        ///     The Guid of a package providing the resource strings (only need to specify if this a different package).
        /// </devdoc>
        public string ResourcePackageGuid
        {
            get { return _resourcePackageGuid; }
            set { _resourcePackageGuid = value; }
        }

        /// <devdoc>
        ///     The native resourceID of the description for this page in the Profile.
        /// </devdoc>
        public short DescriptionResourceID
        {
            get { return _descriptionResourceID; }
            set { _descriptionResourceID = value; }
        }

        /// <include file='doc\ProvideProfileAttribute.uex' path='docs/doc[@for="ProvideProfileAttribute.AlternateParent"]' />
        /// <devdoc>
        ///     Allows the data to be parented under a different category in profile data.
        /// </devdoc>
        public string AlternateParent
        {
            get { return _alternateParent; }
            set { _alternateParent = value; }
        }

        /// <include file='doc\ProvideProfileAttribute.uex' path='docs/doc[@for="ProvideProfileAttribute.IsToolsOptionPage"]' />
        /// <devdoc>
        ///     Is this a Tools->Option page.
        /// </devdoc>

        public bool IsToolsOptionPage {
            get {
                return _isToolsOptionPage;
            }
        }

        private string SettingsRegKey
        {
            get
            {
                if (String.IsNullOrEmpty(GroupName))
                    return string.Format(CultureInfo.InvariantCulture, "UserSettings\\{0}_{1}", CategoryName, ObjectName);
                else
                    return string.Format(CultureInfo.InvariantCulture, "UserSettings\\{0}\\{1}_{2}", GroupName, CategoryName, ObjectName);
            }
        }
     
        /// <include file='doc\ProvideProfileAttribute.uex' path='docs/doc[@for="Register"]' />
        /// <devdoc>
        ///     Called to register this attribute with the given context.  The context
        ///     contains the location where the registration inforomation should be placed.
        ///     it also contains such as the type being registered, and path information.
        ///
        ///     This method is called both for registration and unregistration.  The difference is
        ///     that unregistering just uses a hive that reverses the changes applied to it.
        /// </devdoc>
        public override void Register(RegistrationContext context) {
            context.Log.WriteLine(SR.GetString(SR.Reg_NotifyCreateObject, ObjectType.Name));

            if (!String.IsNullOrEmpty(GroupName) && GroupResourceID>0)
            {
                using (Key groupKey = context.CreateKey(String.Format(CultureInfo.InvariantCulture, "UserSettings\\{0}", GroupName)))
                {
                    groupKey.SetValue(string.Empty, string.Format(CultureInfo.InvariantCulture, "#{0}", GroupResourceID));
                }
            }

            using (Key childKey = context.CreateKey(SettingsRegKey))
            {
                childKey.SetValue(string.Empty, string.Format(CultureInfo.InvariantCulture, "#{0}", ObjectNameResourceID));
                childKey.SetValue("Package", context.ComponentType.GUID.ToString("B"));
                childKey.SetValue("Category", ObjectType.GUID.ToString("B"));
                if(IsToolsOptionPage) {
                    childKey.SetValue("ToolsOptionsPath", CategoryName);
                }
                if (!String.IsNullOrEmpty(AlternateParent))
                    childKey.SetValue("AlternateParent", AlternateParent);
                if (!String.IsNullOrEmpty(ResourcePackageGuid))
                    childKey.SetValue("ResourcePackage", ResourcePackageGuid);
                if (DescriptionResourceID > 0)
                    childKey.SetValue("Description", string.Format(CultureInfo.InvariantCulture, "#{0}", DescriptionResourceID));
            }
        }

        /// <include file='doc\ProvideProfileAttribute.uex' path='docs/doc[@for="Unregister"]' />
        /// <devdoc>
        /// Called to remove this attribute from the given context.
        /// </devdoc>
        public override void Unregister(RegistrationContext context)
        {
            context.RemoveKey(SettingsRegKey);
        }
    }
}

