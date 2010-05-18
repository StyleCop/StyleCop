//------------------------------------------------------------------------------
// <copyright file="ProvideOptionPageAttribute.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>                                                                
//------------------------------------------------------------------------------

namespace Microsoft.VisualStudio.Shell {

    using System;
    using System.Globalization;

    /// <include file='doc\ProvideOptionDialogPageAttribute.uex' path='docs/doc[@for="ProvideOptionDialogPageAttribute"]' />
    /// <devdoc>
    /// This is the base class for all the attributes that are used to register an option page.
    /// </devdoc>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple=true, Inherited=true)]
    public abstract class ProvideOptionDialogPageAttribute : RegistrationAttribute {

        // The type of the option page provided with this attribute. This type must derive from DialogPage.
        private Type _pageType;
        // The id of the resource storing the localized name of the option page.
        private string _pageNameResourceId;

        /// <include file='doc\ProvideOptionDialogPageAttribute.uex' path='docs/doc[@for="ProvideOptionDialogPageAttribute.ProvideOptionDialogPageAttribute"]' />
        /// <devdoc>
        /// This is the constructor of this attribute; it will set the type of the proferred option page.
        /// </devdoc>
        /// <param name="pageType"></param>
        /// <param name="pageNameResourceId"></param>
        public ProvideOptionDialogPageAttribute(Type pageType, string pageNameResourceId)
        {
            // Check the input type: as first make sure this is not null...
            if (pageType == null) {
                throw new ArgumentNullException("pageType");
            }
            // .. then make sure that it derives from DialogPage.
            if (!typeof(DialogPage).IsAssignableFrom(pageType)) {
                throw new ArgumentException(string.Format(Resources.Culture, Resources.Package_PageNotDialogPage, pageType.FullName));
            }
            _pageType = pageType;
            _pageNameResourceId = pageNameResourceId;
        }

        /// <include file='doc\ProvideOptionDialogPageAttribute.uex' path='docs/doc[@for="ProvideOptionDialogPageAttribute.PageType"]' />
        /// <devdoc>
        /// Gets the type of the option page provided with this attribute.
        /// </devdoc>
        public Type PageType {
            get { return _pageType; }
        }

        /// <include file='doc\ProvideOptionDialogPageAttribute.uex' path='docs/doc[@for="ProvideOptionDialogPageAttribute.PageNameResourceId"]' />
        /// <devdoc>
        /// Gets the id of the resource storing the localized name of the option page.
        /// </devdoc>
        public string PageNameResourceId {
            get { return _pageNameResourceId; }
        }
    }

}