//------------------------------------------------------------------------------
// <copyright file="ProvideEditorExtensionAttribute.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>                                                                
//------------------------------------------------------------------------------

namespace Microsoft.VisualStudio.Shell {

    using System;
    using System.IO;
    using System.Globalization;


    /// <include file='doc\ProvideEditorExtensionAttribute.uex' path='docs/doc[@for="ProvideEditorExtensionAttribute"]' />
    /// <devdoc>
    ///     This attribute associates a file extension to a given editor factory.  
    ///     The editor factory may be specified as either a GUID or a type and 
    ///     is placed on a package.
    /// </devdoc>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple=true, Inherited=true)]
    public sealed class ProvideEditorExtensionAttribute : RegistrationAttribute {

        private Guid factory;
        private string extension;
        private int priority;
        private Guid project;
        private string templateDir;
        private int resId;
        private bool editorFactoryNotify;
        private string editorName;
        
        /// <include file='doc\ProvideEditorExtensionAttribute.uex' path='docs/doc[@for="ProvideEditorExtensionAttribute.ProvideEditorExtensionAttribute"]' />
        /// <devdoc>
        ///     Creates a new attribute.
        /// </devdoc>
        public ProvideEditorExtensionAttribute (object factoryType, string extension, int priority) {

            if (!extension.StartsWith(".", StringComparison.OrdinalIgnoreCase)) {
                throw new ArgumentException(SR.GetString(SR.Attributes_ExtensionNeedsDot, extension));
            }

            // figure out what type of object they passed in and get the GUID from it
            if (factoryType is string)
                this.factory = new Guid((string)factoryType);
            else if (factoryType is Type)
                this.factory = ((Type)factoryType).GUID;
            else if (factoryType is Guid)
                this.factory = (Guid)factoryType;
            else
                throw new ArgumentException(SR.GetString(SR.Attributes_InvalidFactoryType, factoryType));

            this.extension = extension;
            this.priority = priority;
            this.project = Guid.Empty;
            this.templateDir = "";
            this.resId = 0;
            this.editorFactoryNotify = false;
        }
        
        /// <include file='doc\ProvideEditorExtensionAttribute.uex' path='docs/doc[@for="ProvideEditorExtensionAttribute.Extension"]' />
        /// <devdoc>
        ///     The file extension of the file.
        /// </devdoc>
        public string Extension {
            get {
                return extension;
            }
        }
        
        /// <include file='doc\ProvideEditorExtensionAttribute.uex' path='docs/doc[@for="ProvideEditorExtensionAttribute.Factory"]' />
        /// <devdoc>
        ///     The editor factory guid.
        /// </devdoc>
        public Guid Factory {
            get {
                return factory;
            }
        }
        
        /// <include file='doc\ProvideEditorExtensionAttribute.uex' path='docs/doc[@for="ProvideEditorExtensionAttribute.Priority"]' />
        /// <devdoc>
        ///     The priority of this extension registration.
        /// </devdoc>
        public int Priority {
            get {
                return priority;
            }
        }

        /// <include file='doc\ProvideEditorExtensionAttribute.uex' path='docs/doc[@for="ProvideEditorExtensionAttribute.ProjectGuid"]/*' />
        public string ProjectGuid {
            set { project = new System.Guid(value); }
            get { return project.ToString(); }
        }

        /// <include file='doc\ProvideEditorExtensionAttribute.uex' path='docs/doc[@for="ProvideEditorExtensionAttribute.EditorFactoryNotify"]/*' />
        public bool EditorFactoryNotify {
            get { return this.editorFactoryNotify; }
            set { this.editorFactoryNotify = value; }
        }

        /// <include file='doc\ProvideEditorExtensionAttribute.uex' path='docs/doc[@for="ProvideEditorExtensionAttribute.TemplateDir"]/*' />
        public string TemplateDir {
            get { return templateDir; }
            set { templateDir = value; }
        }

        /// <include file='doc\ProvideEditorExtensionAttribute.uex' path='docs/doc[@for="ProvideEditorExtensionAttribute.NameResourceID"]/*' />
        public int NameResourceID {
            get { return resId; }
            set { resId = value; }
        }

        /// <include file='doc\ProvideEditorExtensionAttribute.uex' path='docs/doc[@for="ProvideEditorExtensionAttribute.DefaultName"]/*' />
        public string DefaultName {
            get { return editorName; }
            set { editorName = value; }
        }

        /// <summary>
        ///        The reg key name of this extension.
        /// </summary>
        private string RegKeyName 
        {
            get 
            {
                return string.Format(CultureInfo.InvariantCulture, "Editors\\{0}", Factory.ToString("B"));
            }
        }

        /// <summary>
        ///        The reg key name of the project.
        /// </summary>
        private string ProjectRegKeyName(RegistrationContext context) 
        {
            return string.Format(CultureInfo.InvariantCulture,
                                 "Projects\\{0}\\AddItemTemplates\\TemplateDirs\\{1}",
                                 project.ToString("B"),
                                 context.ComponentType.GUID.ToString("B"));
        }

        private string EditorFactoryNotifyKey {
            get { return string.Format(CultureInfo.InvariantCulture, "Projects\\{0}\\FileExtensions\\{1}",
                                       project.ToString("B"),
                                       Extension);
            }
        }

        /// <include file='doc\ProvideEditorExtensionAttribute.uex' path='docs/doc[@for="Register"]' />
        /// <devdoc>
        ///     Called to register this attribute with the given context.  The context
        ///     contains the location where the registration inforomation should be placed.
        ///     it also contains such as the type being registered, and path information.
        ///
        ///     This method is called both for registration and unregistration.  The difference is
        ///     that unregistering just uses a hive that reverses the changes applied to it.
        /// </devdoc>
        public override void Register(RegistrationContext context) {
            context.Log.WriteLine(SR.GetString(SR.Reg_NotifyEditorExtension, Extension, Factory.ToString("B")));

            using (Key editorKey = context.CreateKey(RegKeyName))
            {
                if (!string.IsNullOrEmpty(DefaultName))
                {
                    editorKey.SetValue(null, DefaultName);
                }
                if (0 != resId)
                    editorKey.SetValue("DisplayName", "#" + resId.ToString(CultureInfo.InvariantCulture));
                editorKey.SetValue("Package", context.ComponentType.GUID.ToString("B"));
            }

            using (Key extensionKey = context.CreateKey(RegKeyName + "\\Extensions"))
            {
                extensionKey.SetValue(Extension.Substring(1), Priority);
            }

            // Build the path of the registry key for the "Add file to project" entry
            if (project != Guid.Empty)
            {
                string prjRegKey = ProjectRegKeyName(context) + "\\/1";
                using (Key projectKey = context.CreateKey( prjRegKey ))
                {
                    if (0 != resId)
                        projectKey.SetValue("", "#" + resId.ToString(CultureInfo.InvariantCulture));
                    if (templateDir.Length != 0)
                    {
                        Uri url = new Uri(context.ComponentType.Assembly.CodeBase, true);
                        string templates = url.LocalPath;
                        templates = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(templates), templateDir);
                        templates = context.EscapePath( System.IO.Path.GetFullPath(templates) );
                        projectKey.SetValue("TemplatesDir", templates);
                    }
                    projectKey.SetValue("SortPriority", Priority);
                }
            }

            // Register the EditorFactoryNotify
            if ( EditorFactoryNotify )
            {
                // The IVsEditorFactoryNotify interface is called by the project system, so it doesn't make sense to
                // register it if there is no project associated to this editor.
                if (project == Guid.Empty)
                    throw new ArgumentException(SR.GetString(SR.Attributes_NoPrjForEditorFactoryNotify));

                // Create the registry key
                using (Key edtFactoryNotifyKey = context.CreateKey(EditorFactoryNotifyKey))
                {
                    edtFactoryNotifyKey.SetValue("EditorFactoryNotify", Factory.ToString("B"));
                }
            }
        }

        /// <include file='doc\ProvideEditorExtensionAttribute.uex' path='docs/doc[@for="Unregister"]' />
        /// <devdoc>
        /// Unregister this editor.
        /// </devdoc>
        /// <param name="context"></param>
        public override void Unregister(RegistrationContext context)
        {
            context.RemoveKey(RegKeyName);
            if (project != Guid.Empty)
            {
                context.RemoveKey(ProjectRegKeyName(context));
                if (EditorFactoryNotify)
                    context.RemoveKey(EditorFactoryNotifyKey);
            }
        }
    }
}

