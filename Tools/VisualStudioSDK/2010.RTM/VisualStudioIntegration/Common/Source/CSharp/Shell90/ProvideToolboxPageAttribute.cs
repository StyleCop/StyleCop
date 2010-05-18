//------------------------------------------------------------------------------
// <copyright file="ProvideToolboxPageAttribute.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>                                                                
//------------------------------------------------------------------------------

namespace Microsoft.VisualStudio.Shell {

    using System;
    using System.Globalization;

    /// <include file='doc\ProvideToolboxPageAttribute.uex' path='docs/doc[@for="ProvideToolboxPageAttribute"]' />
    /// <devdoc>
    ///     This attribute declares that a package offers one or more toolbox pages.  Toolbox pages are 
    ///     exposed to the user through Visual Studio's customize toolbox dialog.  A toolbox page must 
    ///     derive from DialogPage. Toolbox page 
    ///     attributes are read by the package class when Visual Studio requests a particular property 
    ///     page GUID.  Package will walk the attributes and try to match the requested GUID to a 
    ///     GUID on a type in the package. 
    /// </devdoc>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple=true, Inherited=true)]
    public sealed class ProvideToolboxPageAttribute : ProvideOptionDialogPageAttribute {

        private short   _pageOrder;
        private string  _helpKeyword;

        /// <include file='doc\ProvideToolboxPageAttribute.uex' path='docs/doc[@for="ProvideToolboxPageAttribute.ProvideToolboxPageAttribute"]' />
        /// <devdoc>
        ///     The page type is a type that implements
        ///     IWin32Window.  The nameResourceID
        ///     parameter specifies a Win32 resource ID in the 
        ///     stored in the native UI resource satellite
        ///     that describes the name of this page.
        /// </devdoc>
        public ProvideToolboxPageAttribute(Type pageType, short nameResourceID) : this(pageType, nameResourceID, 0) {
        }
        
        /// <include file='doc\ProvideToolboxPageAttribute.uex' path='docs/doc[@for="ProvideToolboxPageAttribute.TypeId"]' />
        /// <devdoc>
        /// Identity of this instance of the attribute.
        /// </devdoc>
        public override object TypeId {
            get {
                return this;
            }
        }

        /// <include file='doc\ProvideToolboxPageAttribute.uex' path='docs/doc[@for="ProvideToolboxPageAttribute.ProvideToolboxPageAttribute1"]' />
        /// <devdoc>
        ///     The page type is a type that implements
        ///     IWin32Window.  The nameResourceID
        ///     parameter specifies a Win32 resource ID in the 
        ///     stored in the native UI resource satellite
        ///     that describes the name of this page.  Page order is 
        ///     optional and defaults to zero.  If non-zero, a registry entry will be
        ///     created named DefaultTbx, which specifies the sort order of the
        ///     toolbox pages.
        /// </devdoc>
        public ProvideToolboxPageAttribute(Type pageType, short nameResourceID, short pageOrder) : this(pageType, nameResourceID, pageOrder, null) {
        }

        /// <include file='doc\ProvideToolboxPageAttribute.uex' path='docs/doc[@for="ProvideToolboxPageAttribute.ProvideToolboxPageAttribute1"]' />
        /// <devdoc>
        ///     The page type is a type that implements
        ///     IWin32Window.  The nameResourceID
        ///     parameter specifies a Win32 resource ID in the 
        ///     stored in the native UI resource satellite
        ///     that describes the name of this page.  Page order is 
        ///     optional and defaults to zero.  If non-zero, a registry entry will be
        ///     created named DefaultTbx, which specifies the sort order of the
        ///     toolbox pages.
        ///     Helpkeyword is a keyword exposed to F1 help (support for this was added by joshs -- reference VS Whidbey#262176)
        /// </devdoc>
        public ProvideToolboxPageAttribute(Type pageType, short nameResourceID, short pageOrder, string helpKeyword) 
            : base(pageType, "#"+nameResourceID.ToString()) {

            _pageOrder = pageOrder;
            _helpKeyword = helpKeyword;
        }

        /// <include file='doc\ProvideToolboxPageAttribute.uex' path='docs/doc[@for="ProvideToolboxPageAttribute.HelpKeyword"]' />
        /// <devdoc>
        /// Returns the help keyword associated with this toolbox page.
        /// </devdoc>
        public string HelpKeyword {
            get {
                return _helpKeyword;
            }
        }

        /// <include file='doc\ProvideToolboxPageAttribute.uex' path='docs/doc[@for="ProvideToolboxPageAttribute.PageOrder"]' />
        /// <devdoc>
        ///     The sort order of the page or zero if this page should be left unsorted.
        /// </devdoc>
        public short PageOrder {
            get {
                return _pageOrder;
            }
        }
        
        private string ToolboxPageRegKey
        {
            get { return string.Format(CultureInfo.InvariantCulture, "ToolboxPages\\{0}", PageType.FullName); }
        }

        /// <include file='doc\ProvideToolboxPageAttribute.uex' path='docs/doc[@for="Register"]' />
        /// <devdoc>
        ///     Called to register this attribute with the given context.  The context
        ///     contains the location where the registration inforomation should be placed.
        ///     it also contains such as the type being registered, and path information.
        ///
        ///     This method is called both for registration and unregistration.  The difference is
        ///     that unregistering just uses a hive that reverses the changes applied to it.
        /// </devdoc>
        public override void Register(RegistrationContext context) {
            context.Log.WriteLine(string.Format(Resources.Culture, Resources.Reg_NotifyToolboxPage, PageType.Name));

            using (Key childKey = context.CreateKey(ToolboxPageRegKey))
            {
                childKey.SetValue(string.Empty, PageNameResourceId);
                childKey.SetValue("Package", context.ComponentType.GUID.ToString("B"));
                childKey.SetValue("Page", PageType.GUID.ToString("B"));
                if (PageOrder != 0) {
                    childKey.SetValue("DefaultTbx", PageOrder);
                }
                if (_helpKeyword != null && _helpKeyword.Length > 0) {
                    childKey.SetValue("HelpKeyword", _helpKeyword);
                }
            }
        }

        /// <include file='doc\ProvideToolboxPageAttribute.uex' path='docs/doc[@for="Unregister"]' />
        /// <devdoc>
        /// Called to remove this attribute from the given context.
        /// </devdoc>
        public override void Unregister(RegistrationContext context)
        {
            context.RemoveKey(ToolboxPageRegKey);
        }
    }
}

