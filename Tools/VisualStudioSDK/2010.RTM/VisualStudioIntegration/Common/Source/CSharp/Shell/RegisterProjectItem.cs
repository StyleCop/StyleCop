//------------------------------------------------------------------------------
// <copyright file="RegisterProjectItemAttribute.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>                                                                
//------------------------------------------------------------------------------

namespace Microsoft.VisualStudio.Shell
{
    using System;
    using System.IO;
    using System.Diagnostics;
    using System.Globalization;


    /// <include file='doc\RegisterProjectItemAttribute.uex' path='docs/doc[@for="RegisterProjectItemAttribute"]' />
    /// <devdoc>
    ///     This attribute associates register items to be included in the Add New Item.  
    ///     dialog for the specified project type. It is placed on a package.
    /// </devdoc>
	[Obsolete("RegisterProjectItemAttribute has been deprecated. Please use ProvideProjectItemAttribute instead.")]    
    [AttributeUsage(AttributeTargets.Class, AllowMultiple=true, Inherited=true)]
    public sealed class RegisterProjectItemAttribute : RegistrationAttribute
    {
        private int priority;
        private Guid factory;
        private string templateDir;
        private string itemType;

        /// <include file='doc\RegisterProjectItemAttribute.uex' path='docs/doc[@for="RegisterProjectItemAttribute.RegisterProjectItemAttribute"]' />
        /// <devdoc>
        ///     Creates a new attribute.
        /// </devdoc>
        public RegisterProjectItemAttribute(object projectFactoryType, string itemCategoryName, string templatesDir, int priority)
        {
            if (templatesDir == null || templatesDir.Length == 0)
                throw new ArgumentNullException("templatesDir");

            if (itemCategoryName == null || itemCategoryName.Length == 0)
                throw new ArgumentNullException("itemCategoryName");

            // figure out what type of object they passed in and get the GUID from it
            if (projectFactoryType is string)
                this.factory = new Guid((string)projectFactoryType);
            else if (projectFactoryType is Type)
                this.factory = ((Type)projectFactoryType).GUID;
            else if (projectFactoryType is Guid)
                this.factory = (Guid)projectFactoryType;
            else
                throw new ArgumentException(SR.GetString(SR.Attributes_InvalidFactoryType, projectFactoryType));

            this.priority = priority;
            this.templateDir = templatesDir;
            this.itemType = itemCategoryName;
        }

        /// <include file='doc\RegisterProjectItemAttribute.uex' path='docs/doc[@for="RegisterProjectItemAttribute.ProjectFactoryType"]' />
        /// <devdoc>
        ///     The Project factory guid.
        /// </devdoc>
        public Guid ProjectFactoryType
        {
            get {return factory;}
        }

        /// <include file='doc\RegisterProjectItemAttribute.uex' path='docs/doc[@for="RegisterProjectItemAttribute.Priority"]' />
        /// <devdoc>
        ///     The priority of this item.
        /// </devdoc>
        public int Priority
        {
            get {return priority;}
        }

        /// <include file='doc\RegisterProjectItemAttribute.uex' path='docs/doc[@for="RegisterProjectItemAttribute.TemplateDir"]/*' />
        public string TemplateDir
        {
            get { return templateDir; }
        }

        /// <include file='doc\RegisterProjectItemAttribute.uex' path='docs/doc[@for="RegisterProjectItemAttribute.ItemType"]/*' />
        /// <summary>
        /// String describing the item type. This string is used as the folder in the
        /// left side of the "Add New Items" dialog.
        /// </summary>
        public string ItemType
        {
            get { return itemType; }
        }


        /// <summary>
        ///        The reg key name of the project.
        /// </summary>
        private string ProjectRegKeyName(RegistrationContext context) 
        {
            return string.Format(CultureInfo.InvariantCulture, "Projects\\{0}\\AddItemTemplates\\TemplateDirs\\{1}\\/1",
                                factory.ToString("B"),
                                context.ComponentType.GUID.ToString("B"));
        }

        /// <include file='doc\RegisterProjectItemAttribute.uex' path='docs/doc[@for="Register"]' />
        /// <devdoc>
        ///     Called to register this attribute with the given context.  The context
        ///     contains the location where the registration inforomation should be placed.
        ///     it also contains such as the type being registered, and path information.
        ///
        ///     This method is called both for registration and unregistration.  The difference is
        ///     that unregistering just uses a hive that reverses the changes applied to it.
        /// </devdoc>
        public override void Register(RegistrationContext context)
        {
            context.Log.WriteLine(SR.GetString(SR.Reg_NotifyProjectItems, factory.ToString("B")));

            using (Key childKey = context.CreateKey(ProjectRegKeyName(context)))
            {
                childKey.SetValue("", itemType);

                Uri url = new Uri(context.ComponentType.Assembly.CodeBase, true);
                string templates = url.LocalPath;
                templates = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(templates), templateDir);
                templates = context.EscapePath(System.IO.Path.GetFullPath(templates));
                childKey.SetValue("TemplatesDir", templates);

                childKey.SetValue("SortPriority", Priority);
            }
        }

        /// <include file='doc\RegisterProjectItem.uex' path='docs/doc[@for="RegisterProjectItemAttribute.Unregister"]/*' />
        /// <summary>
        /// Unregister this editor.
        /// </summary>
        /// <param name="context"></param>
        public override void Unregister(RegistrationContext context)
        {
            context.RemoveKey(ProjectRegKeyName(context));
        }
    }
}

