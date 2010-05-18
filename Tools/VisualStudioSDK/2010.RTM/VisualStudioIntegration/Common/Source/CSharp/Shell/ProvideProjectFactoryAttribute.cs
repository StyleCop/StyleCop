//------------------------------------------------------------------------------
// <copyright file="ProvideProjectFactoryAttribute.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>                                                                
//------------------------------------------------------------------------------

namespace Microsoft.VisualStudio.Shell {

    using System;
    using System.ComponentModel;
    using System.Globalization;

    /// <include file='doc\ProvideProjectFactoryAttribute.uex' path='docs/doc[@for="ProvideProjectFactoryAttribute"]' />
    /// <devdoc>
    ///     This attribute declares that a package offers an project factory.  A single 
    ///     package can provide multiple project factories.  If a package declares that 
    ///     it provides an project factory, it should create the factory and offer it 
    ///     to Visual Studio in the Initialize method of Package.
    /// 
    /// </devdoc>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple=true, Inherited=true)]
    public sealed class ProvideProjectFactoryAttribute : RegistrationAttribute {

        private Type    _factoryType;
        private string   _displayProjectFileExtensions;
        private string  _name;
        private string  _defaultProjectExtension;
        private string  _possibleProjectExtensions;
        private string  _projectTemplatesDirectory;
        private int     _sortPriority = 100;
        private Guid    _folderGuid = Guid.Empty;

        private string languageVsTemplate;
        private string templateGroupIDsVsTemplate;
        private string templateIDsVsTemplate;
        private string displayProjectTypeVsTemplate;
        private string projectSubTypeVsTemplate;
        private bool newProjectRequireNewFolderVsTemplate = false;
        private bool showOnlySpecifiedTemplatesVsTemplate = false;

        /// <include file='doc\ProvideProjectFactoryAttribute.uex' path='docs/doc[@for="ProvideProjectFactoryAttribute.ProvideProjectFactoryAttribute"]' />
        /// <devdoc>
        ///     Creates a new ProvideProjectFactoryAttribute.
        /// </devdoc>
        public ProvideProjectFactoryAttribute(Type factoryType, string name, string displayProjectFileExtensionsResourceID, string defaultProjectExtension, string possibleProjectExtensions, string projectTemplatesDirectory) {
            if (factoryType == null) {
                throw new ArgumentNullException("factoryType");
            }

            _factoryType = factoryType;
            _name = name;
            _displayProjectFileExtensions = displayProjectFileExtensionsResourceID;
            _defaultProjectExtension = defaultProjectExtension;
            _possibleProjectExtensions = possibleProjectExtensions;
            _projectTemplatesDirectory = projectTemplatesDirectory;
        }

        /// <include file='doc\ProvideProjectFactoryAttribute.uex' path='docs/doc[@for="ProvideProjectFactoryAttribute.Name"]/*' />
        /// <summary>
        /// The tree node name in the create new project and add new item dialogs.
        /// Take precendence over the nameResourceID value
        /// </summary>
        /// <value>Name to be used</value>
        public string Name
        {
            get { return _name; }
        }

        /// <include file='doc\ProvideProjectFactoryAttribute.uex' path='docs/doc[@for="ProvideProjectFactoryAttribute.SortPriority"]/*' />
        /// <summary>
        /// Affect the order in which project are displayed in the new project dialog
        /// </summary>
        /// <value>Default is 100</value>
        public int SortPriority
        {
            get { return _sortPriority; }
            set { _sortPriority = value; }
        }

        /// <include file='doc\ProvideProjectFactoryAttribute.uex' path='docs/doc[@for="ProvideProjectFactoryAttribute.FactoryType"]' />
        /// <devdoc>
        ///     Returns the project factory type this attribute declares.
        /// </devdoc>
        public Type FactoryType {
            get {
                return _factoryType;
            }            
        }
        
        /// <include file='doc\ProvideProjectFactoryAttribute.uex' path='docs/doc[@for="ProvideProjectFactoryAttribute.DisplayProjectFileExtensionsResourceID"]' />
        /// <devdoc>
        ///     Returns the display project files extensions string.
        /// </devdoc>
        public string DisplayProjectFileExtensions {
            get {
                return _displayProjectFileExtensions;
            }
        }

        /// <include file='doc\ProvideProjectFactoryAttribute.uex' path='docs/doc[@for="ProvideProjectFactoryAttribute.DefaultProjectExtension"]' />
        /// <devdoc>
        ///     Returns the default project extension.
        /// </devdoc>
        public string DefaultProjectExtension {
            get {
                return _defaultProjectExtension;
            }
        }


        /// <include file='doc\ProvideProjectFactoryAttribute.uex' path='docs/doc[@for="ProvideProjectFactoryAttribute.PossibleProjectExtensions"]' />
        /// <devdoc>
        ///     Returns the default project extension.
        /// </devdoc>
        public string PossibleProjectExtensions {
            get {
                return _possibleProjectExtensions;
            }
        }

        /// <include file='doc\ProvideProjectFactoryAttribute.uex' path='docs/doc[@for="ProvideProjectFactoryAttribute.ProjectTemplatesDirectory"]' />
        /// <devdoc>
        ///     Returns the default project extension.
        /// </devdoc>
        public string ProjectTemplatesDirectory {
            get {
                return _projectTemplatesDirectory;
            }
        }

        /// <summary>
        /// Get or Set the Folder guid.
        /// This can be used to control where the project node appear in the New Project dialog
        /// </summary>
        public string FolderGuid
        {
            get { return _folderGuid.ToString("B"); }
            set { _folderGuid = new Guid(value); }
        }

        /// <include file='doc\ProvideProjectFactoryAttribute.uex' path='docs/doc[@for="ProvideProjectFactoryAttribute.LanguageVsTemplate"]/*' />
        public string LanguageVsTemplate
        {
            get { return languageVsTemplate; }
            set { languageVsTemplate = value; }
        }

        /// <include file='doc\ProvideProjectFactoryAttribute.uex' path='docs/doc[@for="ProvideProjectFactoryAttribute.DisplayProjectTypeVsTemplate"]/*' />
        public string DisplayProjectTypeVsTemplate
        {
            get { return displayProjectTypeVsTemplate; }
            set { displayProjectTypeVsTemplate = value; }
        }

        /// <include file='doc\ProvideProjectFactoryAttribute.uex' path='docs/doc[@for="ProvideProjectFactoryAttribute.ProjectSubTypeVsTemplate"]/*' />
        public string ProjectSubTypeVsTemplate
        {
            get { return projectSubTypeVsTemplate; }
            set { projectSubTypeVsTemplate = value; }
        }

        /// <include file='doc\ProvideProjectFactoryAttribute.uex' path='docs/doc[@for="ProvideProjectFactoryAttribute.NewProjectRequireNewFolderVsTemplate"]/*' />
        public bool NewProjectRequireNewFolderVsTemplate
        {
            get { return newProjectRequireNewFolderVsTemplate; }
            set { newProjectRequireNewFolderVsTemplate = value; }
        }

        /// <include file='doc\ProvideProjectFactoryAttribute.uex' path='docs/doc[@for="ProvideProjectFactoryAttribute.ShowOnlySpecifiedTemplatesVsTemplate"]/*' />
        public bool ShowOnlySpecifiedTemplatesVsTemplate
        {
            get { return showOnlySpecifiedTemplatesVsTemplate; }
            set { showOnlySpecifiedTemplatesVsTemplate = value; }
        }

        /// <include file='doc\ProvideProjectFactoryAttribute.uex' path='docs/doc[@for="ProvideProjectFactoryAttribute.TemplateGroupIDsVsTemplate"]/*' />
        public string TemplateGroupIDsVsTemplate
        {
            get { return templateGroupIDsVsTemplate; }
            set { templateGroupIDsVsTemplate = value; }
        }

        /// <include file='doc\ProvideProjectFactoryAttribute.uex' path='docs/doc[@for="ProvideProjectFactoryAttribute.TemplateIDsVsTemplate"]/*' />
        public string TemplateIDsVsTemplate
        {
            get { return templateIDsVsTemplate; }
            set { templateIDsVsTemplate = value; }
        }


        private string ProjectRegKey
        {
            get { return string.Format(CultureInfo.InvariantCulture, "Projects\\{0}", FactoryType.GUID.ToString("B")); }
        }

        private string NewPrjTemplateRegKey(RegistrationContext context)
        {
            return string.Format(CultureInfo.InvariantCulture, "NewProjectTemplates\\TemplateDirs\\{0}\\/1", context.ComponentType.GUID.ToString("B"));
        }

        /// <include file='doc\ProvideProjectFactoryAttribute.uex' path='docs/doc[@for="Register"]' />
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
            context.Log.WriteLine(SR.GetString(SR.Reg_NotifyProjectFactory, FactoryType.Name));

            using (Key projectKey = context.CreateKey(ProjectRegKey))
            {
                projectKey.SetValue(string.Empty, FactoryType.Name);
                if (_name != null)
                    projectKey.SetValue("DisplayName", _name);
                if (_displayProjectFileExtensions != null)
                    projectKey.SetValue("DisplayProjectFileExtensions", _displayProjectFileExtensions);
                projectKey.SetValue("Package", context.ComponentType.GUID.ToString("B"));
                if (_defaultProjectExtension != null)
                    projectKey.SetValue("DefaultProjectExtension", _defaultProjectExtension);
                if (_possibleProjectExtensions != null)
                    projectKey.SetValue("PossibleProjectExtensions", _possibleProjectExtensions);
                if (_projectTemplatesDirectory != null)
                {
                    if (!System.IO.Path.IsPathRooted(_projectTemplatesDirectory))
                    {
                        // If path is not rooted, make it relative to package path
                        _projectTemplatesDirectory = System.IO.Path.Combine(context.ComponentPath, _projectTemplatesDirectory);
                    }
                    projectKey.SetValue("ProjectTemplatesDir", _projectTemplatesDirectory);
                }

                // VsTemplate Specific Keys
                if (languageVsTemplate != null)
                    projectKey.SetValue("Language(VsTemplate)", languageVsTemplate);
                if (showOnlySpecifiedTemplatesVsTemplate)
                    projectKey.SetValue("ShowOnlySpecifiedTemplates(VsTemplate)", (int)1);
                if (templateGroupIDsVsTemplate != null)
                    projectKey.SetValue("TemplateGroupIDs(VsTemplate)", templateGroupIDsVsTemplate);
                if (templateIDsVsTemplate != null)
                    projectKey.SetValue("TemplateIDs(VsTemplate)", templateIDsVsTemplate);
                if (displayProjectTypeVsTemplate != null)
                    projectKey.SetValue("DisplayProjectType(VsTemplate)", displayProjectTypeVsTemplate);
                if (projectSubTypeVsTemplate != null)
                    projectKey.SetValue("ProjectSubType(VsTemplate)", projectSubTypeVsTemplate);
                if (newProjectRequireNewFolderVsTemplate)
                    projectKey.SetValue("NewProjectRequireNewFolder(VsTemplate)", (int)1);
            }

            using (Key prjTemplateKey = context.CreateKey(NewPrjTemplateRegKey(context)))
            {

                string keyName = String.Empty;
                if (_name != null)
                    prjTemplateKey.SetValue(keyName, _name);
                prjTemplateKey.SetValue("SortPriority", _sortPriority);
                if (_projectTemplatesDirectory != null)
                {
                    prjTemplateKey.SetValue("TemplatesDir", _projectTemplatesDirectory);
                }
                if (_folderGuid != Guid.Empty)
                {
                    prjTemplateKey.SetValue("Folder", FolderGuid);
                }
            }
        }

        /// <include file='doc\ProvideProjectFactoryAttribute.uex' path='docs/doc[@for="ProvideProjectFactoryAttribute.Unregister"]/*' />
        public override void Unregister(RegistrationContext context) {
            context.RemoveKey(ProjectRegKey);
            context.RemoveKey(NewPrjTemplateRegKey(context));
        }
    }
}

