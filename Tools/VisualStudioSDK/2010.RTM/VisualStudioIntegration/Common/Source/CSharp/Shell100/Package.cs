//------------------------------------------------------------------------------
// <copyright file="Package.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>                                                                
//------------------------------------------------------------------------------

namespace Microsoft.VisualStudio.Shell {

    using Microsoft.VisualStudio.OLE.Interop;
    using Microsoft.VisualStudio.Shell.Interop;
    using Microsoft.Win32;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.Design;
    using System.Drawing.Design;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.IO;
    using System.Reflection;
    using System.Resources;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Windows.Forms;
    using System.Windows.Forms.Design;
    using System.Drawing;

    using AssemblyEnumerationService = Microsoft.VisualStudio.AssemblyEnumerationService;
    using IOleServiceProvider = Microsoft.VisualStudio.OLE.Interop.IServiceProvider;
    using IServiceProvider = System.IServiceProvider;

    /// <include file='doc\Package.uex' path='docs/doc[@for="Package"]' />
    /// <devdoc>
    ///     This class implements IVsPackage.  It provides a 
    ///     framework-friendly way to define a package and its associated 
    ///     services.
    /// </devdoc>
    [PackageRegistrationAttribute()]
    [CLSCompliant(false)]
    [System.Runtime.InteropServices.ComVisible(true)]
    public abstract class Package : 

        IVsPackage, 
        IOleServiceProvider,
        IOleCommandTarget,
        IVsPersistSolutionOpts, 
        IServiceContainer,
        IVsUserSettings,
        IVsUserSettingsMigration,
        IVsToolWindowFactory,
        IVsToolboxItemProvider
    {

        private ServiceProvider     _provider;
        private ServiceCollection<object>  _services = new ServiceCollection<object>();
        private Hashtable           _editorFactories;
        private Hashtable           _projectFactories;
        private ToolWindowCollection  _toolWindows;          // this is the list of all toolwindows
        private Container           _componentToolWindows; // this is the toolwindows that implement IComponent
        private Container           _pagesAndProfiles;
        private ArrayList           _optionKeys;
        private Dictionary<string, System.Windows.Forms.IDataObject> _tbxItemDataCache = new Dictionary<string, System.Windows.Forms.IDataObject>();


        
        private enum ProfileManagerLoadAction
        {
            None,
            LoadPropsFromRegistry,
            ResetSettings
        }

        /// <include file='doc\Package.uex' path='docs/doc[@for="Package.Package"]' />
        /// <devdoc>
        ///     Simple constructor.
        /// </devdoc>
        protected Package() {
            ServiceCreatorCallback callback = new ServiceCreatorCallback(OnCreateService);
            ((IServiceContainer)this).AddService(typeof(IMenuCommandService), callback);
            ((IServiceContainer)this).AddService(typeof(IOleCommandTarget), callback);
        }
    
        /// <include file='doc\Package.uex' path='docs/doc[@for="Package.ToolboxInitialized"]' />
        /// <devdoc>
        ///     This event is raised when the toolbox is freshly initialized.
        ///     If you provide tools for the toolbox you should add them when
        ///     this event is raised.
        /// </devdoc>
        protected event EventHandler ToolboxInitialized;
        
        /// <include file='doc\Package.uex' path='docs/doc[@for="Package.ToolboxUpgraded"]' />
        /// <devdoc>
        ///     This event is raised when the toolbox is upgraded to a
        ///     new version.  You should perform any work needed to
        ///     upgrade the toolbox here.
        /// </devdoc>
        protected event EventHandler ToolboxUpgraded;

        /// <include file='doc\Package.uex' path='docs/doc[@for="Package.ApplicationRegistryRoot"]' />
        /// <devdoc>
        ///     This property returns the registry root for the application.
        ///     Typically this is HKLM\Software\Microsoft\VisualStudio\[ver]
        ///     but this can change based on any alternate root that the
        ///     shell was initialized with.  This key is read-only.
        /// </devdoc>
        public RegistryKey ApplicationRegistryRoot {
            get {
                return VSRegistry.RegistryRoot(_provider, __VsLocalRegistryType.RegType_Configuration, false);
            }
        }

        /// <include file='doc\Package.uex' path='docs/doc[@for="Package.UserDataPath"]' />
        /// <devdoc>
        ///     This property returns the path to user data storage for
        ///     Visual Studio.  Typically this is %USERPROFILE%\Application Data\
        ///     Visual Studio\[ver] but this can change based on any
        ///     alternate root that the shell was initialized with.
        /// </devdoc>
        public string UserDataPath {
            get {
                // Get the registry root and remove the SOFTWARE\ part
                string registryRoot = GetRegistryRoot();
                registryRoot = registryRoot.Substring("SOFTWARE\\".Length);
    
                string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
    
                return Path.Combine(appData, registryRoot);
            }
        }
        
        /// <include file='doc\Package.uex' path='docs/doc[@for="Package.UserDataPath"]' />
        /// <devdoc>
        ///     This property returns the path to user data storage for
        ///     Visual Studio.  Typically this is %USERPROFILE%\Local Settings\Application Data\
        ///     Visual Studio\[ver] but this can change based on any
        ///     alternate root that the shell was initialized with.
        /// </devdoc>
        public string UserLocalDataPath {
            get {
                // Get the registry root and remove the SOFTWARE\ part
                string registryRoot = GetRegistryRoot();
                registryRoot = registryRoot.Substring("SOFTWARE\\".Length);
    
                string appData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
    
                return Path.Combine(appData, registryRoot);
            }
        }
        
        /// <include file='doc\Package.uex' path='docs/doc[@for="Package.UserRegistryRoot"]' />
        /// <devdoc>
        ///     This property returns the registry root for the current
        ///     user.  Typically this is HKCU\Software\Microsoft\VisualStudio\[ver]
        ///     but this can change based on any alternate root that the shell
        ///     is initialized with.  This key is read-write.
        /// </devdoc>
        public RegistryKey UserRegistryRoot {
            get {
                return VSRegistry.RegistryRoot(_provider, __VsLocalRegistryType.RegType_UserSettings, true);
            }
        }
        
        /// <include file='doc\Package.uex' path='docs/doc[@for="Package.AddOptionKey"]' />
        /// <devdoc>
        ///     This method adds a user option key name into the list of
        ///     option keys that we will load and save from the solution
        ///     file.  You should call this early in your constructor.
        ///     Calling this will cause the OnLoadOptions and
        ///     OnSaveOptions methods to be invoked for each key you
        ///     add.
        /// </devdoc>
        protected void AddOptionKey(string name) {
            if (zombie)
                Marshal.ThrowExceptionForHR(NativeMethods.E_UNEXPECTED);

            if (name == null) {
                throw new ArgumentNullException("name");
            }

            // the key is the class name of the service interface.  Note that
            // while it would be a lot more correct to use the fully-qualified class
            // name, IStorage won't have it and returns STG_E_INVALIDNAME.  The
            // doc's don't have any information here; I can only assume it is because
            // of the '.'.

            // clovett: According to the docs for IStorage::CreateStream, the name
            // cannot be longer than 31 characters.
            if (name.IndexOf('.') != -1 || name.Length > 31) {
                throw new ArgumentException(string.Format(Resources.Culture, Resources.Package_BadOptionName, name));
            }

            if (_optionKeys == null) {
                _optionKeys = new ArrayList();
            }
            else {
                if (_optionKeys.Contains(name)) {
                    throw new ArgumentException(string.Format(Resources.Culture, Resources.Package_OptionNameUsed, name));
                }
            }
            _optionKeys.Add(name);
        }



        /// <include file='doc\Package.uex' path='docs/doc[@for="Package.ExportSettings"]' />
        /// <devdoc>
        ///     This method implements the IVsUserSettings Interface
        ///     used to manage profiles and import/export settings
        ///     to XML files.
        /// </devdoc>
        int IVsUserSettings.ExportSettings(string strPageGuid, IVsSettingsWriter writer) {
            Debug.Assert(strPageGuid != null && strPageGuid.Length > 0, "Passed page guid cannot be null");
            Debug.Assert(writer != null, "IVsSettingsWriter cannot be null");

            Guid requestPageGuid = new Guid(strPageGuid);
            IProfileManager profileManager = GetProfileManager(requestPageGuid, ProfileManagerLoadAction.LoadPropsFromRegistry);
            if(profileManager != null) {
                profileManager.SaveSettingsToXml(writer);
            }
            return NativeMethods.S_OK;
        }

        /// <include file='doc\Package.uex' path='docs/doc[@for="Package.MigrateSettings"]' />
        /// <devdoc>
        ///     This method implements the IVsUserSettingsMigration Interface
        ///     used to bring forward user settings from a previous version.
        /// </devdoc>
        int IVsUserSettingsMigration.MigrateSettings(IVsSettingsReader reader, IVsSettingsWriter writer, string strPageGuid) {
            
            Debug.Assert(strPageGuid != null && strPageGuid.Length > 0, "Passed page guid cannot be null");
            Debug.Assert(reader != null, "IVsSettingsReader cannot be null");
            Debug.Assert(writer != null, "IVsSettingsWriter cannot be null");

            Guid requestPageGuid = Guid.Empty;

            try
            {
                requestPageGuid = new Guid(strPageGuid);
            }
            catch (FormatException)
            {
                // If this is thrown, it means strPageGuid is not really a GUID, but rather a
                // tools options page name like "Environment.General".
            }

            IProfileMigrator profileMigrator = null;

            if (requestPageGuid == Guid.Empty)
            {
                profileMigrator = GetAutomationObject(strPageGuid) as IProfileMigrator;
            }
            else
            {
                profileMigrator = GetProfileManager(requestPageGuid, ProfileManagerLoadAction.None) as IProfileMigrator;
            }

            if(profileMigrator != null) {
                profileMigrator.MigrateSettings(reader, writer);
            }
            return NativeMethods.S_OK;
        }


        /// <include file='doc\Package.uex' path='docs/doc[@for="Package.ImportSettings"]' />
        /// <devdoc>
        ///     This method implements the IVsUserSettings Interface
        ///     used to manage profiles and import/export settings
        ///     to XML files.
        /// </devdoc>
        int IVsUserSettings.ImportSettings(string strPageGuid, IVsSettingsReader reader, uint flags, ref int restartRequired) {

            // nobody should require a restart...
            if (restartRequired > 0)
                restartRequired = 0;

            Debug.Assert(strPageGuid != null && strPageGuid.Length > 0, "Passed page guid cannot be null");
            Debug.Assert(reader != null, "IVsSettingsReader cannot be null");

            bool loadPropsFromRegistry = (flags & (uint)__UserSettingsFlags.USF_ResetOnImport) == 0;

            Guid requestPageGuid = new Guid(strPageGuid);
            IProfileManager profileManager = GetProfileManager(requestPageGuid, loadPropsFromRegistry ? ProfileManagerLoadAction.LoadPropsFromRegistry : ProfileManagerLoadAction.ResetSettings);
            if(profileManager != null) {
                // we get the live instance (if any) when we load
                profileManager.LoadSettingsFromXml(reader);
                // update the store
                profileManager.SaveSettingsToStorage();
            }
            return NativeMethods.S_OK;
        }


        /// <include file='doc\Package.uex' path='docs/doc[@for="Package.Dispose"]' />
        /// <devdoc>
        ///     This method will be called by Visual Studio in reponse
        ///     to a package close (disposing will be true in this
        ///     case).  The default implementation revokes all
        ///     services and calls Dispose() on any created services
        ///     that implement IDisposable.
        /// </devdoc>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
        protected virtual void Dispose(bool disposing) {
            if (disposing) {

                // Unregister any registered editor factories.
                //
                if (_editorFactories != null)
                {
                    Hashtable editorFactories = _editorFactories;
                    _editorFactories = null;

                    try {
                        IVsRegisterEditors registerEditors = GetService(typeof(SVsRegisterEditors)) as IVsRegisterEditors;
                        foreach (DictionaryEntry de in editorFactories) {
                            try {
                                if (registerEditors != null) {
                                    // Don't check for the return value because, even if this unregister fails,
                                    // we have anyway to try to unregister the others.
                                    registerEditors.UnregisterEditor((uint)de.Value);
                                }
                            }
                            catch (Exception) { /* do nothing */ }
                            finally {
                                IDisposable disposable = de.Key as IDisposable;
                                if (disposable != null) {
                                    disposable.Dispose();
                                }
                            }
                        }
                    }
                    catch (Exception e) {
                        Debug.Fail(String.Format("Failed to dispose editor factories for package {0}\n{1}", this.GetType().FullName, e.Message));
                    }
                }
                // Unregister any registered project factories.
                //
                if (_projectFactories != null)
                {
                    Hashtable projectFactories = _projectFactories;
                    _projectFactories = null;
                    try
                    {
                        IVsRegisterProjectTypes registerProjects = GetService(typeof(SVsRegisterProjectTypes)) as IVsRegisterProjectTypes;

                        foreach (DictionaryEntry de in projectFactories)
                        {
                            try
                            {
                                if (registerProjects != null)
                                {
                                    // As above, don't check for the return value.
                                    registerProjects.UnregisterProjectType((uint)de.Value);
                                }
                            }
                            finally
                            {
                                IDisposable disposable = de.Key as IDisposable;
                                if (disposable != null)
                                {
                                    disposable.Dispose();
                                }
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Debug.Fail(String.Format("Failed to dispose project factories for package {0}\n{1}", this.GetType().FullName, e.Message));
                    }
                }

                // Dispose all IComponent ToolWindows
                //
                if (_componentToolWindows != null)
                {
                    Container componentToolWindows = _componentToolWindows;
                    _componentToolWindows = null;
                    try
                    {
                        componentToolWindows.Dispose();
                    }
                    catch (Exception e)
                    {
                        Debug.Fail(String.Format("Failed to dispose component toolwindows for package {0}\n{1}", this.GetType().FullName, e.Message));
                    }
                }

                // Dispose all pages.
                //
                if (_pagesAndProfiles != null)
                {
                    Container pagesAndProfiles = _pagesAndProfiles;
                    _pagesAndProfiles = null;
                    try
                    {
                        pagesAndProfiles.Dispose();
                    }
                    catch (Exception e)
                    {
                        Debug.Fail(String.Format("Failed to dispose component toolwindows for package {0}\n{1}", this.GetType().FullName, e.Message));
                    }
                }

                // Enumerate the service list and destroy all services.  This should
                // always be done last.
                //
                if (_services != null && _services.Count > 0)
                {
                    try
                    {
                        IProfferService ps = (IProfferService)GetService(typeof(SProfferService));
                        ServiceCollection<object> services = _services;
                        _services = null;

                        foreach (object value in services.Values)
                        {

                            object service = value;
                            ProfferedService proffer = service as ProfferedService;
                            try
                            {
                                if (null != proffer)
                                {
                                    service = proffer.Instance;
                                    if (proffer.Cookie != 0 && ps != null)
                                    {
                                        int hr = ps.RevokeService(proffer.Cookie);
                                        if (NativeMethods.Failed(hr))
                                        {
                                            Debug.Fail(String.Format(CultureInfo.CurrentUICulture, "Failed to unregister service {0}", service.GetType().FullName));
                                            Trace.WriteLine(String.Format(CultureInfo.CurrentUICulture, "Failed to unregister service {0}", service.GetType().FullName));
                                        }
                                    }
                                }
                            }
                            finally
                            {
                                if (service is IDisposable)
                                {
                                    ((IDisposable)service).Dispose();
                                }
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Debug.Fail(String.Format("Failed to dispose proffered service for package {0}\n{1}", this.GetType().FullName, e.Message));
                    }
                }

                // Disallow any service requests after this.
                //
                if (_provider != null)
                {
                    try
                    {
                        _provider.Dispose();
                    }
                    catch (Exception e)
                    {
                        Debug.Fail(String.Format("Failed to dispose the service provider for package {0}\n{1}", this.GetType().FullName, e.Message));
                    }
                    _provider = null;
                }

                if (_toolWindows != null)
                {
                    _toolWindows.Dispose();
                    _toolWindows = null;
                }

                if (_optionKeys != null)
                {
                    _optionKeys = null;
                }

                // Disconnect user preference change events
                //
                SystemEvents.UserPreferenceChanged -= new UserPreferenceChangedEventHandler(OnUserPreferenceChanged);
            }
        }
        
        /// <include file='doc\Package.uex' path='docs/doc[@for="Package.GetAutomationObject"]' />
        /// <devdoc>
        ///     This method returns the automation object for this package.
        ///     The default implementation will return null if name is null, indicating there
        ///     is no default automation object.  If name is non null, this will walk metadata
        ///     attributes searching for an option page that has a name of the format
        ///     &lt;Category&gt;.&lt;Name&gt;.  If the option page has this format and indicates that it
        ///     supports automation, its automation object will be returned.
        /// </devdoc>
        protected virtual object GetAutomationObject(string name) {
            if (zombie)
                Marshal.ThrowExceptionForHR(NativeMethods.E_UNEXPECTED);

            if (name == null) {
                return null;
            }

            string[] nameParts = name.Split(new char[] {'.'});
            if (nameParts.Length != 2) {
                return null;
            }

            nameParts[0] = nameParts[0].Trim();
            nameParts[1] = nameParts[1].Trim();

            AttributeCollection attributes = TypeDescriptor.GetAttributes(this);
            foreach(Attribute attr in attributes) {
                ProvideOptionPageAttribute pa = attr as ProvideOptionPageAttribute;
                if (pa != null && pa.SupportsAutomation) {

                    // Check to see if the name matches.
                    //
                    if (string.Compare(pa.CategoryName, nameParts[0], StringComparison.OrdinalIgnoreCase) != 0) {
                        continue;
                    }

                    if (string.Compare(pa.PageName, nameParts[1], StringComparison.OrdinalIgnoreCase) != 0) {
                        continue;
                    }

                    // Ok, the name matches.  Return this page's automation object.
                    //
                    DialogPage page = GetDialogPage(pa.PageType);
                    return page.AutomationObject;
                }
            }

            // Failed.
            //
            return null;
        }

        
        /// <include file='doc\Package.uex' path='docs/doc[@for="Package.GetDialogPage"]' />
        /// <devdoc>
        ///     This method returns the requested dialog page.  Dialog
        ///     pages are cached so they can keep a single instance
        ///     of their state.  This method allows a deriving class
        ///     to get a cached dialog page.  The object will be 
        ///     dynamically created if it is not in the cache.
        /// </devdoc>
        protected DialogPage GetDialogPage(Type dialogPageType) {
            if (zombie)
                Marshal.ThrowExceptionForHR(NativeMethods.E_UNEXPECTED);

            if (dialogPageType == null) {
                throw new ArgumentNullException("dialogPageType");
            }

            if (!typeof(DialogPage).IsAssignableFrom(dialogPageType)) {
                throw new ArgumentException(string.Format(Resources.Culture, Resources.Package_BadDialogPageType, dialogPageType.FullName));
            }

            if (_pagesAndProfiles != null) {
                foreach(object page in _pagesAndProfiles.Components) {
                    if (page.GetType() == dialogPageType) {
                        return (DialogPage)page;
                    }
                }
            }

            // Create a new instance of this option page.
            //
            ConstructorInfo ctor = dialogPageType.GetConstructor(new Type[] {});
            if (ctor == null) {
                throw new ArgumentException(string.Format(Resources.Culture, Resources.Package_PageCtorMissing, dialogPageType.FullName));
            }

            DialogPage p = (DialogPage)ctor.Invoke(new object[] {});
            
                        
            if (_pagesAndProfiles == null) {
                _pagesAndProfiles = new PackageContainer(this);
            }
            _pagesAndProfiles.Add(p);

            return p;
        }


        
        /// <include file='doc\Package.uex' path='docs/doc[@for="Package.GetProfileManager"]' />
        /// <devdoc>
        ///     This method returns the requested profile manager based on its guid.
        ///     Profile managers are cached so they can keep a single instance
        ///     of their state.  This method allows a deriving class
        ///     to get a cached profile manager.  The object will be 
        ///     dynamically created if it is not in the cache.
        /// </devdoc>
        private IProfileManager GetProfileManager(Guid objectGuid, ProfileManagerLoadAction loadAction) {
            
            IProfileManager result = null;

            if(objectGuid == Guid.Empty) {
                throw new ArgumentNullException("objectGuid");
            }
            if (_pagesAndProfiles != null) {
                foreach(object profileManager in _pagesAndProfiles.Components) {
                    if (profileManager.GetType().GUID.Equals(objectGuid)) {
                        if (profileManager is IProfileManager)
                        {
                            result = profileManager as IProfileManager;
                            if (result != null)
                            {
                                switch (loadAction) {
                                    case ProfileManagerLoadAction.LoadPropsFromRegistry:
                                        result.LoadSettingsFromStorage();
                                        break;
                                    case ProfileManagerLoadAction.ResetSettings:
                                        result.ResetSettings();
                                        break;
                                }
                            }
                        }

                        // No need to keep on looking in the attributes since
                        // we've found the one we were looking for.

                        break;
                    }
                }
            }

            if (result == null) {

                // Didn't find it in our cache.  Now look in the metadata attributes
                // for the class.  Look at all types at the same time.
                //
                AttributeCollection attributes = TypeDescriptor.GetAttributes(this);
                foreach(Attribute attr in attributes) {
                    if (attr is ProvideProfileAttribute) {
                        Type objectType = ((ProvideProfileAttribute)attr).ObjectType;
                        if (objectType.GUID.Equals(objectGuid)) {

                            // found it... now instanciate since it was not in the cache
                            // if not build a constructor for it

                            ConstructorInfo ctor = objectType.GetConstructor(new Type[] {});
                            if (ctor == null) {
                                throw new ArgumentException(string.Format(Resources.Culture, Resources.Package_PageCtorMissing, objectType.FullName));
                            }
                            result = (IProfileManager)ctor.Invoke(new object[] {});

                            // if it's a DialogPage cache it
                            if(result != null) {
                                if(_pagesAndProfiles == null) {
                                    _pagesAndProfiles = new PackageContainer(this);
                                }
                                _pagesAndProfiles.Add((IComponent)result);
                            }

                            // No need to load settings from storage on first creation
                            // since that happens because of the Add above.

                            break;
                        }
                    }
                }
            }
            return result;
        }

        
        /// <devdoc>
        ///     Retrieves the shell's root key for VS options, or uses the value of
        ///     the DefaultRegistryRootAttribute if we coundn't get the shell service.
        /// </devdoc>
        private string GetRegistryRoot() {
            string regisrtyRoot;
    
            IVsShell vsh = (IVsShell)GetService(typeof(SVsShell));
            if (vsh == null) {
                // Search our custom attributes for an instance of DefaultRegistryRoot
                //
                DefaultRegistryRootAttribute regRootAttr = (DefaultRegistryRootAttribute)TypeDescriptor.GetAttributes(this.GetType())[typeof(DefaultRegistryRootAttribute)];
                if (regRootAttr == null) {
                    Debug.Fail("Package should have a registry root attribute");
                    throw new NotSupportedException();
                }
    
                regisrtyRoot = @"SOFTWARE\Microsoft\VisualStudio\" + regRootAttr.Root;
            }
            else {
                object obj;
                NativeMethods.ThrowOnFailure( vsh.GetProperty((int)__VSSPROPID.VSSPROPID_VirtualRegistryRoot, out obj) );
                regisrtyRoot = obj.ToString();
            }
    
            return regisrtyRoot;
        }
    
        
        /// <include file='doc\Package.uex' path='docs/doc[@for="Package.GetService"]' />
        /// <devdoc>
        ///     IServiceProvider implementation.
        /// </devdoc>
        protected object GetService(Type serviceType) {
            if (zombie)
                return null;

            if (serviceType == null) {
                throw new ArgumentNullException("serviceType");
            }

            // Check for the special services we provide.
            //
            if (serviceType.IsEquivalentTo(typeof(IServiceContainer)) || serviceType.IsEquivalentTo(typeof(Package)) || serviceType.IsEquivalentTo(this.GetType())) {
                return this;
            }

            object value = null;

            // Check our service list
            //
            if (_services != null && _services.Count > 0) {
                lock (serviceType) {
                    
                    if (_services.ContainsKey(serviceType))
                        value = _services[serviceType];

                    if (value is ProfferedService) {
                        value = ((ProfferedService)value).Instance;
                    }

                    if (value is ServiceCreatorCallback) {

                        // In case someone recursively requests the same service, 
                        // null out the service type here.  That way they'll just
                        // fail instead of stack fault.
                        //
                        _services[serviceType] = null;


                        value = ((ServiceCreatorCallback)value)(this, serviceType);
                        if (value == null)
                        {
                            string message = "An object was not returned from a service creator callback for the registered type of " + serviceType.Name + ".  This may mean that it failed a type equivalence comparison.  To compare type objects you must use Type.IsEquivalentTo(Type).  Do not use .Equals or the == operator.";

                            // If this fails, it will likely indicate that the pacakge did a .Equals or == on the Service type which may fail type equivalence.
                            IVsAppCommandLine appCmdLine = GetService(typeof(SVsAppCommandLine)) as IVsAppCommandLine;
                            if (appCmdLine != null)
                            {
                                // If we are running under the experimental hive, notify the VSIP developer that this is incorrect.
                                string suffix;
                                int fPresent = 0;
                                appCmdLine.GetOption("RootSuffix", out fPresent, out suffix);
                                if (fPresent == 1 && string.Compare(suffix, "Exp", StringComparison.OrdinalIgnoreCase) == 0)
                                {
                                    System.Windows.Forms.MessageBox.Show(message);
                                }
                            }


                            Debug.Fail(message);
                        }
                        else if (!value.GetType().IsCOMObject && !serviceType.IsAssignableFrom(value.GetType()))
                        {
                            // Callback passed us a bad service.  NULL it, rather than throwing an exception.
                            // Callers here do not need to be prepared to handle bad callback implementations.
                            Debug.Fail("Object " + value.GetType().Name + " was returned from a service creator callback but it does not implement the registered type of " + serviceType.Name);
                            value = null;
                        }
                        _services[serviceType] = value;
                    }
                }
            }

            // Delegate to the parent provider, but only if we have verified that _services doesn't actually contain our key
            // if it does, that means that we're in the middle of trying to resolve this service, and the service resolution
            // has recursed.
            //
            Debug.Assert(value != null || _services == null || _services.Count == 0 || !_services.ContainsKey(serviceType), "GetService is recursing on itself while trying to resolve the service " + serviceType.Name + ". This means that someone is asking for this service while the service is trying to create itself.  Breaking the recursion now and aborting this GetService call.");
            if (value == null && _provider != null && (_services == null || _services.Count == 0 || !_services.ContainsKey(serviceType))) {
                value = _provider.GetService(serviceType);
            }

            return value;
        }

        /// <include file='doc\Package.uex' path='docs/doc[@for="Package.Initialize"]/*' />
        /// <devdoc>
        /// This method is called when the package is first 
        /// initialized.  Override it if you need to do work
        /// that happens as part of package initialization.
        /// </devdoc>
        protected virtual void Initialize() {
            // If we have services to proffer, do that now.
            //
            if (_services.Count > 0)
            {
                IProfferService ps = (IProfferService)GetService(typeof(SProfferService));

                Debug.Assert(ps != null, "We have services to proffer but IProfferService is not available.");
                if (ps != null) {

                    foreach (KeyValuePair<Type, object> pair in _services)
                    {
                        ProfferedService service = pair.Value as ProfferedService;

                        if (service != null) {
                            uint cookie;
                            Guid serviceGuid = (Guid)pair.Key.GUID;
                            NativeMethods.ThrowOnFailure(
                                ps.ProfferService(ref serviceGuid, this, out cookie)
                            );
                            service.Cookie= cookie;
                        }
                    }
                }
            }

            // Initialize this thread's culture info with that of the shell's LCID
            //
            int locale = GetProviderLocale();
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(locale);

            // Begin listening to user preference change events
            //
            SystemEvents.UserPreferenceChanged += new UserPreferenceChangedEventHandler(OnUserPreferenceChanged);
            
            // Be sure to load the package user options from the solution in case
            // the package was not already loaded when the solution was opened.
            if (null != _optionKeys)
            {
                try {
                    IVsSolutionPersistence pPersistance = (IVsSolutionPersistence)this.GetService(typeof(SVsSolutionPersistence));
                    if (pPersistance != null) {
                        foreach (string key in _optionKeys) {
                            // NOTE: don't check for the error code because a failure here is
                            // expected and not a problem.
                            pPersistance.LoadPackageUserOpts(this, key);
                        }
                    }
                } catch (Exception) {
                    // no settings found, no problem.
                }
            }
        }

        /// <include file='doc\Package.uex' path='docs/doc[@for="Package.QueryClose"]/*' />
        /// <devdoc>
        /// Called to ask the package if the shell can be closed.
        /// </devdoc>
        /// <param name="canClose">Set canClose to false if you want to prevent the shell from closing</param>
        /// <returns>HRESULT</returns>
        protected virtual int QueryClose(out bool canClose)
        {
            canClose = true;
            return NativeMethods.S_OK;
        }

        /// <include file='doc\Package.uex' path='docs/doc[@for="Package.GetProviderLocale"]' />
        /// <devdoc>
        /// Return the locale associated with this IServiceProvider.
        /// </devdoc>
        public int GetProviderLocale() {
            CultureInfo ci = CultureInfo.CurrentCulture;
            int lcid = ci.LCID;
            IUIHostLocale loc = (IUIHostLocale)GetService(typeof(IUIHostLocale));
            Debug.Assert(loc != null, "Unable to get IUIHostLocale, defaulting CLR designer to current thread LCID");
            if (loc != null) {
                uint locale;
                NativeMethods.ThrowOnFailure(loc.GetUILocale(out locale));
                lcid = (int)locale;
            }
            return lcid;
        }
        
        /// <include file='doc\Package.uex' path='docs/doc[@for="Package.CreateInstance"]/*' />
        /// <devdoc>
        /// Create the specified COM object using Visual Studio's ILocalRegistry
        /// and cast it to the given managed type.  If VS cannot create it, then
        /// fall back to Activator.CreateInstance.  This allows managed classes
        /// to be registered in local to the particular VS version in 
        /// HKLM\Software\Microsoft\VisualStudio\8.0\clsid.
        /// </devdoc>
        public object CreateInstance(ref Guid clsid, ref Guid iid, Type type) {
            object result = null;
            IntPtr pUnk = this.CreateInstance(ref clsid, ref iid);
            if (pUnk != IntPtr.Zero) {
                try {
                    result = Marshal.GetTypedObjectForIUnknown(pUnk, type);
                } finally {
                    Marshal.Release(pUnk);
                }
            } else {
                result = Activator.CreateInstance(type);
            }
            return result;
        }

        private IntPtr CreateInstance(ref Guid clsid, ref Guid iid) {
            ILocalRegistry3 localRegistry = this.GetService(typeof(SLocalRegistry)) as ILocalRegistry3;
            IntPtr pUnk;
            NativeMethods.ThrowOnFailure(localRegistry.CreateInstance(clsid, null, ref iid, NativeMethods.CLSCTX_INPROC_SERVER, out pUnk));
            localRegistry = null;
            return pUnk;
        }

        /// <include file='doc\Package.uex' path='docs/doc[@for="Package.GetOutputPane"]/*' />
        /// <devdoc>
        /// Return the specified output window pane.  If the pane is not found, 
        /// create it with the given caption.
        /// </devdoc>
        public IVsOutputWindowPane GetOutputPane(Guid page, string caption) {
            IVsOutputWindow outputWindow = this.GetService(typeof(SVsOutputWindow)) as IVsOutputWindow;
            Debug.Assert(outputWindow != null, "Cannot find IVsOutputWindow");
            IVsOutputWindowPane pane = null;
            int hr = outputWindow.GetPane(ref page, out pane);
            if ( NativeMethods.Failed(hr) )
            {
                if (caption != null) {
                    hr = outputWindow.CreatePane(ref page, caption, 1, 1);
                    if ( NativeMethods.Succeeded(hr) ) {
                        // Don't throw or fail here: a null pane is an expected value.
                        outputWindow.GetPane(ref page, out pane);
                    }
                }
            }
            if (pane != null) 
                NativeMethods.ThrowOnFailure( pane.Activate() );
            return pane;
        }

        /// <devdoc>
        ///     ServiceCreatorCallback implementation for the services we offer on demand.
        /// </devdoc>
        private object OnCreateService(IServiceContainer container, Type serviceType) {

            // Menu commands.  IOleCommandTarget is implemented on IMenuCommandService,
            // so we offer both as services and delegate the creation of IOleCommandTarget
            // to IMenuCommandService.
            //
            if (serviceType.IsEquivalentTo(typeof(IOleCommandTarget))) {
                object commandService = GetService(typeof(IMenuCommandService));
                if (commandService is IOleCommandTarget) {
                    return commandService;
                }
                Debug.Fail("IMenuCommandService is either unavailable or does not implement IOleCommandTarget");
            }
            else if (serviceType.IsEquivalentTo(typeof(IMenuCommandService))) {
                return new OleMenuCommandService(this);
            }

            Debug.Fail("OnCreateService invoked for a service we didn't add");
            return null;
        }

        /// <include file='doc\Package.uex' path='docs/doc[@for="Package.OnLoadOptions"]/*' />
        /// <devdoc>
        /// This method can be overridden by the deriving
        /// class to load solution options.
        /// </devdoc>
        protected virtual void OnLoadOptions(string key, Stream stream) {
        }
        
        /// <include file='doc\Package.uex' path='docs/doc[@for="Package.OnSaveOptions"]/*' />
        /// <devdoc>
        /// This method can be overridden by the deriving
        /// class to save solution options.
        /// </devdoc>
        protected virtual void OnSaveOptions(string key, Stream stream) {
        }

        /// <devdoc>
        ///     Invoked when a user setting has changed.  Here we invalidate
        ///     the cached locale data so we can obtain updated culture information.
        /// </devdoc>
        private void OnUserPreferenceChanged(object sender, UserPreferenceChangedEventArgs e) {
            if (e.Category == UserPreferenceCategory.Locale) {
                CultureInfo.CurrentCulture.ClearCachedData();
            }
        }

        /// <include file='doc\Package.uex' path='docs/doc[@for="Package.ParseToolboxResource"]/*' />
        /// <devdoc>
        /// Parses a toolbox resource format and adds the toolbox items to the toolbox.  This
        /// method can be used to automatically add items to the toolbox.  The resource data
        /// is passed in through the resourceData parameter and consists of a text file with
        /// the following format:
        /// ; Comment
        /// [CategoryName]
        /// &lt;class name&gt;, &lt;assembly name&gt;
        /// The category name can be localized through the localizedCategorized resource
        /// manager that is passed into this method.  The localizedCategories parameter
        /// may be null, in which case the category names will not be localized.
        /// The assembly name may either be a fully qualified name, or a partial name.
        /// If a partial name is passed, the latest assembly of that partial name will
        /// be loaded.
        /// </devdoc>
        protected void ParseToolboxResource(TextReader resourceData, ResourceManager localizedCategories) {
            ParseToolboxResource(resourceData, localizedCategories, Guid.Empty);
        }

        /// <include file='doc\Package.uex' path='docs/doc[@for="Package.ParseToolboxResource"]/*' />
        /// <devdoc>
        /// Parses a toolbox resource format and adds the toolbox items to the toolbox.  This
        /// method can be used to automatically add items to the toolbox.  The resource data
        /// is passed in through the resourceData parameter and consists of a text file with
        /// the following format:
        /// ; Comment
        /// [CategoryName]
        /// &lt;class name&gt;, &lt;assembly name&gt;
        /// The category name can be localized through the localizedCategorized resource
        /// manager that is passed into this method.  The localizedCategories parameter
        /// may be null, in which case the category names will not be localized.
        /// The assembly name may either be a fully qualified name, or a partial name.
        /// If a partial name is passed, the latest assembly of that partial name will
        /// be loaded.
        /// </devdoc>
        protected void ParseToolboxResource(TextReader resourceData, Guid packageGuid) {
            ParseToolboxResource(resourceData, null, packageGuid);
        }


        /// <include file='doc\Package.uex' path='docs/doc[@for="Package.ParseToolboxResource"]/*' />
        /// <devdoc>
        /// Parses a toolbox resource format and adds the toolbox items to the toolbox.  This
        /// method can be used to automatically add items to the toolbox.  The resource data
        /// is passed in through the resourceData parameter and consists of a text file with
        /// the following format:
        /// ; Comment
        /// [CategoryName]
        /// &lt;class name&gt;, &lt;assembly name&gt;
        /// The category name can be localized through the localizedCategorized resource
        /// manager that is passed into this method.  The localizedCategories parameter
        /// may be null, in which case the category names will not be localized.
        /// The assembly name may either be a fully qualified name, or a partial name.
        /// If a partial name is passed, the latest assembly of that partial name will
        /// be loaded.
        /// </devdoc>
        private void ParseToolboxResource(TextReader resourceData, ResourceManager localizedCategories, Guid packageGuid) {

            if (resourceData == null) {
                throw new ArgumentNullException("resourceData");
            }

            IToolboxService tbx = GetService(typeof(IToolboxService)) as IToolboxService;
            if (tbx == null) {
                Debug.Fail("Missing toolbox service");
                throw new InvalidOperationException(string.Format(Resources.Culture, Resources.General_MissingService, typeof(IToolboxService).FullName));
            }

            IVsToolbox vstbx = GetService(typeof(SVsToolbox)) as IVsToolbox;
            IVsToolbox2 vsToolbox2 = vstbx as IVsToolbox2;
            IVsToolbox3 vsToolbox = vstbx as IVsToolbox3;
            if (vsToolbox == null) {
                Debug.Fail("Missing VS toolbox service");
                throw new InvalidOperationException(string.Format(Resources.Culture, Resources.General_MissingService, typeof(SVsToolbox).FullName));
            }

            string line = resourceData.ReadLine();
            string currentCategory = null;
            string rawCategory = null;

            while(line != null) {

                try
                {
                    line = line.Trim();

                    if (line.Length != 0)
                    {
                        if (line.StartsWith(";", StringComparison.OrdinalIgnoreCase))
                        {
                            // Ignore this comment
                        }
                        else if (line.StartsWith("[", StringComparison.OrdinalIgnoreCase) && line.EndsWith("]", StringComparison.OrdinalIgnoreCase))
                        {

                            // This line is a toolbox category name.  Create a new category.
                            //
                            currentCategory = line.Trim(new char[] { '[', ']' }).Trim();
                            rawCategory = currentCategory;

                            if (localizedCategories != null) {
                                string locCategory = localizedCategories.GetString(currentCategory);
                                if (locCategory == null) {
                                    Debug.Fail("Category name " + currentCategory + " has not been localized");
                                }
                                else {
                                    currentCategory = locCategory;
                                }
                            }

                            bool categoryAdded = false;
                            if (!String.IsNullOrEmpty(currentCategory)) {
                                if (packageGuid != Guid.Empty && vsToolbox2 != null) {
                                    vsToolbox2.AddTab2(currentCategory, ref packageGuid);   //represents a native resource when package is sent in.
                                    if (!String.IsNullOrEmpty(rawCategory) && vsToolbox != null)
                                    {
                                        vsToolbox.SetIDOfTab(currentCategory, packageGuid.ToString("B") + "-" + rawCategory);
                                        rawCategory = null;
                                    }
                                    categoryAdded = true;
                                }
                                else if (vstbx != null) {
                                    //add the tab -- even if there are no items...
                                    vstbx.AddTab(currentCategory);
                                    categoryAdded = true;
                                }
                                if (categoryAdded && !String.IsNullOrEmpty(rawCategory) && vsToolbox != null)
                                {
                                    vsToolbox.SetIDOfTab(currentCategory, rawCategory);
                                    rawCategory = null;
                                }
                            }
                        }
                        else {

                            // The line is a toolbox item class.  Discover the type.  The
                            // type name is an assembly qualified name.  If it is fully 
                            // qualified we can load it directly.  If it isn't, then we must use the
                            // sdk enumeration service to find the assembly with the matching name.
                            // This allows toolbox item providers to list simple names in their toolbox item
                            // definition files, but do a strong bind.
                            //
                            int idx = line.IndexOf(",");
                            if (idx == -1)
                            {
                                Debug.Fail("Bad line: " + line);
                            }
                            else
                            {
                                string typeName = line.Substring(0, idx).Trim();
                                string assemblyName = line.Substring(idx + 1).Trim();

                                if (assemblyName.IndexOf(",") == -1)
                                {
                                    // Must use the assembly enumeration service to locate the
                                    // assembly.
                                    AssemblyEnumerationService enumSvc = new AssemblyEnumerationService(this);
                                    foreach (AssemblyName an in enumSvc.GetAssemblyNames(assemblyName))
                                    {
                                        assemblyName = an.FullName;
                                        break;
                                    }
                                }

                                Assembly a = Assembly.Load(assemblyName);
                                Debug.Assert(a != null, "Assembly " + assemblyName + " not found on machine");

                                if (a != null)
                                {
                                    Type t = a.GetType(typeName);
                                    Debug.Assert(t != null, "Type " + typeName + " not found on machine");
                                    if (t != null)
                                    {
                                        ToolboxItem item = ToolboxService.GetToolboxItem(t);
                                        Debug.Assert(item != null, "Tool " + line + " does not offer a toolbox item");
                                        if (item != null)
                                        {

                                            if (currentCategory == null)
                                            {
                                                tbx.AddToolboxItem(item);
                                            }
                                            else
                                            {
                                                tbx.AddToolboxItem(item, currentCategory);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.Fail("Exception during toolbox processing: " + ex.ToString());
                }

                line = resourceData.ReadLine();
            }
        }


        /// <include file='doc\Package.uex' path='docs/doc[@for="Package.RegisterEditorFactory"]/*' />
        /// <devdoc>
        /// Registers this editor factory with Visual Studio.
        /// If you are providing an editor factory, you should register
        /// it by overriding the Initialize method. Call 
        /// base.Initialize first, and then call RegisterEditorFactory
        /// for each editor factory.  There is no need to unregister
        /// an editor factory as Package will handle this for you.
        /// Also, if your editor factory is IDisposable, it will be
        /// disposed when it is unregistered.
        /// </devdoc>
        protected void RegisterEditorFactory(IVsEditorFactory factory) {
            IVsRegisterEditors registerEditors = GetService(typeof(SVsRegisterEditors)) as IVsRegisterEditors;
            if (registerEditors == null) {
                throw new InvalidOperationException(string.Format(Resources.Culture, Resources.Package_MissingService, typeof(SVsRegisterEditors).FullName));
            }

            uint cookie;
            Guid riid = factory.GetType().GUID;

            NativeMethods.ThrowOnFailure( registerEditors.RegisterEditor(ref riid, factory, out cookie) );

            if (_editorFactories == null) {
                _editorFactories = new Hashtable();
            }

            _editorFactories[factory] = cookie;
        }

        /// <include file='doc\Package.uex' path='docs/doc[@for="Package.RegisterEditorFactory"]/*' />
        /// <devdoc>
        /// Registers this project factory with Visual Studio.
        /// If you are providing an project factory, you should register
        /// it by overriding the Initialize method. Call 
        /// base.Initialize first, and then call RegisterProjectFactory
        /// for each project factory.  There is no need to unregister
        /// an project factory as the Package base class will handle this for you.
        /// Also, if your project factory is IDisposable, it will be
        /// disposed when it is unregistered.
        /// </devdoc>
        protected void RegisterProjectFactory(IVsProjectFactory factory) {
            IVsRegisterProjectTypes registerProjects = GetService(typeof(SVsRegisterProjectTypes)) as IVsRegisterProjectTypes;
            if (registerProjects == null) {
                throw new InvalidOperationException(string.Format(Resources.Culture, Resources.Package_MissingService, typeof(SVsRegisterProjectTypes).FullName));
            }

            uint cookie;
            Guid riid = factory.GetType().GUID;

            NativeMethods.ThrowOnFailure( registerProjects.RegisterProjectType(ref riid, factory, out cookie) );

            if (_projectFactories == null) {
                _projectFactories = new Hashtable();
            }

            _projectFactories[factory] = cookie;
        }

        /// <include file='doc\Package.uex' path='docs/doc[@for="Package.ShowOptionPage"]/*' />
        /// <devdoc>
        /// Displays the Tools->Options dialog with the given
        /// options page selected.
        /// </devdoc>
        public void ShowOptionPage(Type optionsPageType) {

            if (optionsPageType == null) {
                throw new ArgumentNullException("optionsPageType");
            }

            System.ComponentModel.Design.MenuCommandService mcs = GetService(typeof(IMenuCommandService)) as System.ComponentModel.Design.MenuCommandService;
            if (mcs != null) {
                CommandID cmd = new CommandID(NativeMethods.GUID_VSStandardCommandSet97, NativeMethods.cmdidToolsOptions);
                mcs.GlobalInvoke(cmd, optionsPageType.GUID.ToString());
            }
        }

        /// <include file='doc\Package.uex' path='docs/doc[@for="Package.IOleCommandTarget.Exec"]/*' />
        /// <internalonly/>
        /// <devdoc>
        /// IOleCommandTarget implementation.
        /// </devdoc>
        int IOleCommandTarget.Exec(ref Guid guidGroup, uint nCmdId, uint nCmdExcept, IntPtr pIn, IntPtr vOut) {
            IOleCommandTarget tgt = (IOleCommandTarget)GetService(typeof(IOleCommandTarget));
            if (tgt != null) {
                return tgt.Exec(ref guidGroup, nCmdId, nCmdExcept, pIn, vOut);
            }
            else {
                return NativeMethods.OLECMDERR_E_NOTSUPPORTED;
            }
        }
        
        /// <include file='doc\Package.uex' path='docs/doc[@for="Package.IOleCommandTarget.QueryStatus"]/*' />
        /// <internalonly/>
        /// <devdoc>
        /// IOleCommandTarget implementation.
        /// </devdoc>
        int IOleCommandTarget.QueryStatus(ref Guid guidGroup, uint nCmdId, OLECMD[] oleCmd, IntPtr oleText) {
            IOleCommandTarget tgt = (IOleCommandTarget)GetService(typeof(IOleCommandTarget));
            if (tgt != null) {
                return tgt.QueryStatus(ref guidGroup, nCmdId, oleCmd, oleText);
            }
            return(NativeMethods.OLECMDERR_E_NOTSUPPORTED);
        }

        /// <include file='doc\Package.uex' path='docs/doc[@for="Package.IOleServiceProvider.QueryService"]/*' />
        /// <internalonly/>
        /// <devdoc>
        /// IOleServiceProvider implementation.
        /// </devdoc>
        int IOleServiceProvider.QueryService(ref Guid sid, ref Guid iid, out IntPtr ppvObj) {
            
            ppvObj = (IntPtr)0;
            int hr = NativeMethods.S_OK;

            object service = null;

            if (_services != null && _services.Count > 0) {
                foreach(Type serviceType in _services.Keys) {
                    if (serviceType.GUID.Equals(sid)) {
                        service = GetService(serviceType);
                        break;
                    }
                }
            }

            if (service == null) {
                hr = NativeMethods.E_NOINTERFACE;
            }
            else {
                // Now check to see if the user asked for an IID other than
                // IUnknown.  If so, we must do another QI.
                //
                if (iid.Equals(NativeMethods.IID_IUnknown)) {
                    ppvObj = Marshal.GetIUnknownForObject(service);
                }
                else {
                    IntPtr pUnk = Marshal.GetIUnknownForObject(service);
                    hr = Marshal.QueryInterface(pUnk, ref iid, out ppvObj);
                    Marshal.Release(pUnk);
                }
            }

            return hr;
        }
    
        /// <include file='doc\Package.uex' path='docs/doc[@for="Package.IServiceContainer.AddService"]/*' />
        /// <internalonly/>
        /// <devdoc>
        /// Adds the given service to the service container.
        /// </devdoc>
        void IServiceContainer.AddService(Type serviceType, object serviceInstance) {
            ((IServiceContainer)this).AddService(serviceType, serviceInstance, false);
        }
        
        /// <include file='doc\Package.uex' path='docs/doc[@for="Package.IServiceContainer.AddService1"]/*' />
        /// <internalonly/>
        /// <devdoc>
        /// Adds the given service to the service container.
        /// </devdoc>
        void IServiceContainer.AddService(Type serviceType, object serviceInstance, bool promote) {

            if (serviceType == null) {
                throw new ArgumentNullException("serviceType");
            }

            if (serviceInstance == null) {
                throw new ArgumentNullException("serviceInstance");
            }

            // Disallow the addition of duplicate services.
            //
            if (_services.ContainsKey(serviceType)) {
                throw new InvalidOperationException(string.Format(Resources.Culture, Resources.Package_DuplicateService, serviceType.FullName));
            }

            if (promote) {

                // If we're promoting, we need to store this guy in a promoted service
                // object because we need to manage additional state.  We attempt
                // to proffer at this time if we have a service provider.  If we don't,
                // we will proffer when we get one.
                //
                ProfferedService service = new ProfferedService();
                service.Instance = serviceInstance;
                
                if (_provider != null) {
                    IProfferService ps = (IProfferService)GetService(typeof(SProfferService));
                    if (ps != null) {
                        uint cookie;
                        Guid serviceGuid = (Guid)serviceType.GUID;
                        NativeMethods.ThrowOnFailure( ps.ProfferService(ref serviceGuid, this, out cookie) );
                        service.Cookie= cookie;
                        _services[serviceType] = service;
                    }
                }
            }
            else {
                _services[serviceType] = serviceInstance;
            }
        }
        
        /// <include file='doc\Package.uex' path='docs/doc[@for="Package.IServiceContainer.AddService2"]/*' />
        /// <internalonly/>
        /// <devdoc>
        /// Adds the given service to the service container.
        /// </devdoc>
        void IServiceContainer.AddService(Type serviceType, ServiceCreatorCallback callback) {
            ((IServiceContainer)this).AddService(serviceType, callback, false);
        }
        
        /// <include file='doc\Package.uex' path='docs/doc[@for="Package.IServiceContainer.AddService3"]/*' />
        /// <internalonly/>
        /// <devdoc>
        /// Adds the given service to the service container.
        /// </devdoc>
        void IServiceContainer.AddService(Type serviceType, ServiceCreatorCallback callback, bool promote) {

            if (serviceType == null) {
                throw new ArgumentNullException("serviceType");
            }

            if (callback == null) {
                throw new ArgumentNullException("callback");
            }

            // Disallow the addition of duplicate services.
            //
            if (_services.ContainsKey(serviceType)) {
                throw new InvalidOperationException(string.Format(Resources.Culture, Resources.Package_DuplicateService, serviceType.FullName));
            }

            if (promote) {

                // If we're promoting, we need to store this guy in a promoted service
                // object because we need to manage additional state.  We attempt
                // to proffer at this time if we have a service provider.  If we don't,
                // we will proffer when we get one.
                //
                ProfferedService service = new ProfferedService();
                _services[serviceType] = service;
                service.Instance = callback;
                
                if (_provider != null) {
                    IProfferService ps = (IProfferService)GetService(typeof(SProfferService));
                    if (ps != null) {
                        uint cookie;
                        Guid serviceGuid = (Guid)serviceType.GUID;
                        NativeMethods.ThrowOnFailure( ps.ProfferService(ref serviceGuid, this, out cookie) );
                        service.Cookie= cookie;
                    }
                }
            }
            else {
                _services[serviceType] = callback;
            }
        }
        
        /// <include file='doc\Package.uex' path='docs/doc[@for="Package.IServiceContainer.RemoveService"]/*' />
        /// <internalonly/>
        /// <devdoc>
        /// Removes the given service type from the service container.
        /// </devdoc>
        void IServiceContainer.RemoveService(Type serviceType) {
            ((IServiceContainer)this).RemoveService(serviceType, false);
        }
        
        /// <include file='doc\Package.uex' path='docs/doc[@for="Package.IServiceContainer.RemoveService1"]/*' />
        /// <internalonly/>
        /// <devdoc>
        /// Removes the given service type from the service container.
        /// </devdoc>
        void IServiceContainer.RemoveService(Type serviceType, bool promote) {
            if (serviceType == null) {
                throw new ArgumentNullException("serviceType");
            }

            if (_services != null && _services.Count > 0) {
                object value = null;
                if (_services.ContainsKey(serviceType))
                    value = _services[serviceType];

                if (value != null) {
                    _services.Remove(serviceType);

                    try {
                        ProfferedService service = value as ProfferedService;
                        if (null != service) {
                            value = service.Instance;
                            if (service.Cookie != 0) {
                                IProfferService ps = (IProfferService)GetService(typeof(SProfferService));
                                if (ps != null) {
                                    NativeMethods.ThrowOnFailure(ps.RevokeService(service.Cookie));
                                }
                                service.Cookie = 0;
                            }
                        }
                    } 
                    finally {
                        if (value is IDisposable) {
                            ((IDisposable)value).Dispose();
                        }
                    }
                }
            }
        }

        /// <include file='doc\Package.uex' path='docs/doc[@for="Package.IServiceProvider.GetService"]/*' />
        /// <internalonly/>
        /// <devdoc>
        /// IServiceProvider implementation.  We just delegate to
        /// the Package implementation for this.
        /// </devdoc>
        object IServiceProvider.GetService(Type serviceType) {
            return GetService(serviceType);
        }

        /// <include file='doc\Package.uex' path='docs/doc[@for="Package.IVsPackage.Close"]/*' />
        /// <internalonly/>
        /// <devdoc>
        /// IVsPackage implementation.
        /// </devdoc>
        int IVsPackage.Close() {
            if (!zombie)
            {
                Dispose(true);
            }

            zombie = true;

            return NativeMethods.S_OK;
        }
        
        /// <include file='doc\Package.uex' path='docs/doc[@for="Package.IVsPackage.CreateTool"]/*' />
        /// <internalonly/>
        /// <devdoc>
        /// IVsPackage implementation.
        /// graysonm : temporarily remove explicit implementation syntax in order to allow hiding of this method
        /// in a derived class until tool window support is implemented.
        /// </devdoc>
        public int CreateTool(ref Guid persistenceSlot)
        {
            if (zombie)
                Marshal.ThrowExceptionForHR(NativeMethods.E_UNEXPECTED);

            // Let the factory do the work
            int hr = ((IVsToolWindowFactory)this).CreateToolWindow(ref persistenceSlot, 0);
            return hr;
        }

        /// <include file='doc\Package.uex' path='docs/doc[@for="Package.IVsToolWindowFactory.CreateToolWindow"]/*' />
        /// <internalonly/>
        /// <devdoc>
        /// Create a tool window of the specified type with the specified ID.
        /// </devdoc>
        /// <param name="toolWindowType">Type of the window to be created</param>
        /// <param name="id">Instance ID</param>
        int IVsToolWindowFactory.CreateToolWindow(ref Guid toolWindowType, uint id)
        {
            if (id > int.MaxValue)
                throw new ArgumentOutOfRangeException(String.Format(CultureInfo.CurrentUICulture, "Instance ID cannot be more then {0}", int.MaxValue));
            int instanceID = (int)id;

            // Find the Type for this GUID
            Attribute[] attributes = Attribute.GetCustomAttributes(this.GetType());
            foreach (Attribute attribute in attributes)
            {
                if (attribute is ProvideToolWindowAttribute)
                {
                    ProvideToolWindowAttribute tool = (ProvideToolWindowAttribute)attribute;
                    if (tool.ToolType.GUID == toolWindowType)
                    {
                        // We found the corresponding type
                        // If a window get created this way, FindToolWindow should be used to get a reference to it
                        FindToolWindow(tool.ToolType, instanceID, true, tool);
                        break;
                    }
                }
            }
            return NativeMethods.S_OK;
        }

        /// <include file='doc\Package.uex' path='docs/doc[@for="Package.CreateToolWindow"]/*' />
        /// <devdoc>
        /// Create a tool window of the specified type with the specified ID.
        /// </devdoc>
        /// <param name="toolWindowType">Type of the window to be created</param>
        /// <param name="id">Instance ID</param>
        /// <returns>An instance of a class derived from ToolWindowPane</returns>
        protected WindowPane CreateToolWindow(Type toolWindowType, int id)
        {
            if (toolWindowType == null)
                throw new ArgumentNullException("toolWindowType");
            if (id < 0)
                throw new ArgumentOutOfRangeException(string.Format(Resources.Culture, Resources.Package_InvalidInstanceID, id));
            if (!toolWindowType.IsSubclassOf(typeof(WindowPane)))
                throw new ArgumentException(Resources.Package_InvalidToolWindowClass);

            // Look in the Attributes of this package and see if this package
            // support this type of ToolWindow
            Attribute[] attributes = Attribute.GetCustomAttributes(this.GetType());
            foreach (Attribute attribute in attributes)
            {
                if (attribute is ProvideToolWindowAttribute)
                {
                    ProvideToolWindowAttribute tool = (ProvideToolWindowAttribute)attribute;
                    if (tool.ToolType == toolWindowType)
                    {
                        // We found the corresponding attribute on the package,
                        // so create the toolwindow
                        return CreateToolWindow(toolWindowType, id, tool);
                    }
                }
            }

            return null;
        }

        /// <devdoc>
        /// This is the only method that should be calling IVsUiShell.CreateToolWindow()
        /// </devdoc>
        private WindowPane CreateToolWindow(Type toolWindowType, int id, ProvideToolWindowAttribute tool)
        {
            if (toolWindowType == null)
                throw new ArgumentNullException("toolWindowType");
            if (id < 0)
                throw new ArgumentOutOfRangeException(string.Format(Resources.Culture, Resources.Package_InvalidInstanceID, id));
            if (!toolWindowType.IsSubclassOf(typeof(WindowPane)))
                throw new ArgumentException(Resources.Package_InvalidToolWindowClass);
            if (tool == null)
                throw new ArgumentNullException("tool");

            // First create an instance of the ToolWindowPane
            WindowPane window = (WindowPane)Activator.CreateInstance(toolWindowType);
            ToolWindowPane toolwindow = window as ToolWindowPane;

            // Check if this window has a ToolBar
            bool hasToolBar = false;

            Guid emptyGuid = Guid.Empty;
            Guid toolClsid = Guid.Empty;
            string caption = null;

            if (toolwindow != null)
            {
                toolClsid = toolwindow.ToolClsid;
                caption = toolwindow.Caption;
                hasToolBar = (toolwindow.ToolBar != null);
                toolwindow.Package = this;
            }

            uint flags = (uint)__VSCREATETOOLWIN.CTW_fInitNew;
            if (!tool.Transient)
                flags |= (uint)__VSCREATETOOLWIN.CTW_fForceCreate;
            if (hasToolBar)
                flags |= (uint)__VSCREATETOOLWIN.CTW_fToolbarHost;
            if (tool.MultiInstances)
                flags |= (uint)__VSCREATETOOLWIN.CTW_fMultiInstance;
            
            object windowPane = null;
            if (toolClsid.CompareTo(Guid.Empty) == 0)
            {
                // If a tool CLSID is not specified, then host the IVsWindowPane
                if (toolwindow != null)
                    // This method makes it possible to provide an IVsWindowPane not derived from ToolWindowPane
                    windowPane = toolwindow.GetIVsWindowPane();
                else
                    windowPane = window;
            }

            Guid persistenceGuid = toolWindowType.GUID;
            IVsWindowFrame windowFrame;
            // Use IVsUIShell to create frame.
            IVsUIShell vsUiShell = (IVsUIShell)GetService(typeof(SVsUIShell));
            if (vsUiShell == null)
                throw new Exception(string.Format(Resources.Culture, Resources.General_MissingService, typeof(SVsUIShell).FullName));

            int hr = vsUiShell.CreateToolWindow(flags,         // flags
                (uint)id,               // instance ID
                windowPane,             // IVsWindowPane to host in the toolwindow (null if toolClsid is specified)
                ref toolClsid,          // toolClsid to host in the toolwindow (Guid.Empty if windowPane is not null)
                ref persistenceGuid,    // persistence Guid
                ref emptyGuid,          // auto activate Guid
                null,                   // service provider
                caption,         // Window title
                null,
                out windowFrame);
            NativeMethods.ThrowOnFailure(hr);

            // If the toolwindow is a component, site it.
            IComponent component = null;
            // Check first if the content is a component, preferring IVsUIElementPane over IVsWindowPane-style pane
            if (window.Content != null)
            {
                component = window.Content as IComponent;
            }
            else
            {
                component = window.Window as IComponent;
            }
            // If we don't have a component yet, see if the toolwindow itself is a component
            if (component == null)
            {
                component = windowPane as IComponent;
            }
            if (component != null)
            {
                if (_componentToolWindows == null)
                    _componentToolWindows = new PackageContainer(this);
                _componentToolWindows.Add((IComponent)component);
            }

            // This generates the OnToolWindowCreated event on the ToolWindowPane
            if (toolwindow != null)
                toolwindow.Frame = windowFrame;

            if (hasToolBar && windowFrame != null && toolwindow != null)
            {
                // Set the toolbar
                IVsToolWindowToolbarHost2 toolBarHost;
                object obj;
                NativeMethods.ThrowOnFailure(windowFrame.GetProperty((int)__VSFPROPID.VSFPROPID_ToolbarHost, out obj));
                toolBarHost = (IVsToolWindowToolbarHost2)obj;
                if (toolBarHost != null)
                {
                    Guid toolBarCommandSet = toolwindow.ToolBar.Guid;
                    NativeMethods.ThrowOnFailure(toolBarHost.AddToolbar2((VSTWT_LOCATION)toolwindow.ToolBarLocation, ref toolBarCommandSet, (uint)toolwindow.ToolBar.ID, toolwindow.ToolBarDropTarget));
                }

                toolwindow.OnToolBarAdded();
            }


            // If the ToolWindow was created successfully, keep track of it
            if (toolwindow != null)
            {
                if (_toolWindows == null)
                    _toolWindows = new ToolWindowCollection();
                _toolWindows.Add(toolWindowType.GUID, id, toolwindow);
            }
            return window;
        }

        /// <include file='doc\Package.uex' path='docs/doc[@for="Package.0lWindow"]/*' />
        /// <devdoc>
        /// Return the tool window corresponding to the specified type and ID.
        /// If it does not exist, it returns creates one if create is true,
        /// or null if create is false.
        /// </devdoc>
        /// <param name="toolWindowType">Type of the window to be created</param>
        /// <param name="id">Instance ID</param>
        /// <param name="create">Create if none exist?</param>
        /// <returns>An instance of a class derived from ToolWindowPane</returns>
        public ToolWindowPane FindToolWindow(Type toolWindowType, int id, bool create)
        {
            return FindToolWindow(toolWindowType, id, create, null) as ToolWindowPane;
        }

        /// <include file='doc\Package.uex' path='docs/doc[@for="Package.0lWindow"]/*' />
        /// <devdoc>
        /// Return the window pane corresponding to the specified type and ID.
        /// If it does not exist, it returns creates one if create is true,
        /// or null if create is false.
        /// </devdoc>
        /// <param name="toolWindowType">Type of the window to be created</param>
        /// <param name="id">Instance ID</param>
        /// <param name="create">Create if none exist?</param>
        /// <returns>An instance of a class derived from WindowPane</returns>
        public WindowPane FindWindowPane(Type toolWindowType, int id, bool create)
        {
            return FindToolWindow(toolWindowType, id, create, null);
        }

        private WindowPane FindToolWindow(Type toolWindowType, int id, bool create, ProvideToolWindowAttribute tool)
        {
            if (toolWindowType == null)
                throw new ArgumentNullException("toolWindowType");

            WindowPane window = null;

            if (null != _toolWindows)
            {
                window = _toolWindows.GetToolWindowPane(toolWindowType.GUID, id);
            }

            if ((null == window) && create)
            {
                if (tool != null)
                    window = CreateToolWindow(toolWindowType, id, tool);
                else
                    window = CreateToolWindow(toolWindowType, id);
            }

            return window;
        }

        /// <include file='doc\Package.uex' path='docs/doc[@for="Package.IVsPackage.GetAutomationObject"]/*' />
        /// <internalonly/>
        /// <devdoc>
        /// IVsPackage implementation.
        /// </devdoc>
        int IVsPackage.GetAutomationObject(string propName, out object auto) {
            if (zombie)
                Marshal.ThrowExceptionForHR(NativeMethods.E_UNEXPECTED);

            auto = GetAutomationObject(propName);
            if (auto == null) {
                Marshal.ThrowExceptionForHR(NativeMethods.E_NOTIMPL);
            }
            return NativeMethods.S_OK;
        }

        /// <include file='doc\Package.uex' path='docs/doc[@for="Package.IVsPackage.GetPropertyPage"]/*' />
        /// <internalonly/>
        /// <devdoc>
        /// IVsPackage implementation.
        /// </devdoc>
        int IVsPackage.GetPropertyPage(ref Guid rguidPage, VSPROPSHEETPAGE[] ppage) {
            if (ppage == null || ppage.Length < 1)
                throw new ArgumentException(string.Format(Resources.Culture, Resources.General_ArraySizeShouldBeAtLeast1), "ppage");

            if (zombie)
                Marshal.ThrowExceptionForHR(NativeMethods.E_UNEXPECTED);

            IWin32Window pageWindow = null;

            // First, check out the active pages.
            //
            if (_pagesAndProfiles != null) {
                foreach(object page in _pagesAndProfiles.Components) {
                    if (page.GetType().GUID.Equals(rguidPage)) {

                        // Found a match.
                        //
                        IWin32Window w = page as IWin32Window;
                        if (w != null) {
                            if (w is DialogPage) {
                                ((DialogPage)w).ResetContainer();
                            }
                            pageWindow = w;
                            break;
                        }
                    }
                }
            }

            if (pageWindow == null) {

                DialogPage page = null;

                // Didn't find it in our cache.  Now look in the metadata attributes
                // for the class.  Look at all types at the same time.
                //
                AttributeCollection attributes = TypeDescriptor.GetAttributes(this);
                foreach(Attribute attr in attributes) {
                    if (attr is ProvideOptionDialogPageAttribute) {
                        Type pageType = ((ProvideOptionDialogPageAttribute)attr).PageType;
                        if (pageType.GUID.Equals(rguidPage)) {

                            // Found a matching attribute.  Now go get the DialogPage with GetDialogPage.
                            // This has a side-effect of storing the page in
                            // _pagesAndProfiles for us.
                            //
                            page = GetDialogPage(pageType);
                            pageWindow = page;
                            break;
                        }
                    }

                    if (page != null)
                    {
                        if (_pagesAndProfiles == null)       
                        {
                            _pagesAndProfiles = new PackageContainer(this);
                        }
                        _pagesAndProfiles.Add(page);

                        // No need to continue looking in the attributes, 
                        // we've already found the one we're looking for
                        break;
                    }
                }
            }

            // We should now have a page window. If we don't then the requested page
            // doesn't exist.
            //
            if (pageWindow == null) {
                Marshal.ThrowExceptionForHR(NativeMethods.E_NOTIMPL);
            }

            ppage[0].dwSize = (uint)Marshal.SizeOf(typeof(VSPROPSHEETPAGE));
            ppage[0].hwndDlg = pageWindow.Handle;
            // zero-out all the fields we aren't using.
            ppage[0].dwFlags = 0;
            ppage[0].HINSTANCE = 0;
            ppage[0].dwTemplateSize = 0;
            ppage[0].pTemplate = IntPtr.Zero;
            ppage[0].pfnDlgProc = IntPtr.Zero;
            ppage[0].lParam = IntPtr.Zero;
            ppage[0].pfnCallback = IntPtr.Zero;
            ppage[0].pcRefParent = IntPtr.Zero;
            ppage[0].dwReserved = 0;
            ppage[0].wTemplateId = (ushort)0;

            return NativeMethods.S_OK;
        }

        /// <include file='doc\Package.uex' path='docs/doc[@for="Package.IVsPackage.QueryClose"]/*' />
        /// <internalonly/>
        /// <devdoc>
        /// IVsPackage implementation.
        /// </devdoc>
        int IVsPackage.QueryClose(out int close)
        {
            // Default to true as we don't want an error to prevent the shell from closing
            close = 1;
            bool canClose = true;
            int hr = this.QueryClose(out canClose);
            if (!canClose)
                close = 0;
            return hr;
        }

        /// <include file='doc\Package.uex' path='docs/doc[@for="Package.IVsPackage.ResetDefaults"]/*' />
        /// <internalonly/>
        /// <devdoc>
        /// IVsPackage implementation.
        /// </devdoc>
        int IVsPackage.ResetDefaults(uint grfFlags) {

            if (zombie)
                Marshal.ThrowExceptionForHR(NativeMethods.E_UNEXPECTED);

            if (grfFlags == (uint)__VSPKGRESETFLAGS.PKGRF_TOOLBOXITEMS) {
                if (ToolboxInitialized != null) {
                    ToolboxInitialized(this, EventArgs.Empty);
                }
            }
            else if (grfFlags == (uint)__VSPKGRESETFLAGS.PKGRF_TOOLBOXSETUP) {
                if (ToolboxUpgraded != null) {
                    ToolboxUpgraded(this, EventArgs.Empty);
                }
            }
            return NativeMethods.S_OK;
        }

        /// <include file='doc\Package.uex' path='docs/doc[@for="Package.IVsPackage.SetSite"]/*' />
        /// <internalonly/>
        /// <devdoc>
        /// IVsPackage implementation.
        /// </devdoc>
        int IVsPackage.SetSite(IOleServiceProvider sp) {

            if (zombie)
                Marshal.ThrowExceptionForHR(NativeMethods.E_UNEXPECTED);

            if (sp != null) {
                if (_provider != null) {
                    throw new InvalidOperationException(string.Format(Resources.Culture, Resources.Package_SiteAlreadySet, GetType().FullName));
                }
                _provider = ServiceProvider.CreateFromSetSite(sp);

                Initialize();
            }
            else if (_provider != null)
            {
                // No SP, dispose us.
                //
                Dispose(true);
            }
            return NativeMethods.S_OK;
        }

        /// <include file='doc\Package.uex' path='docs/doc[@for="Package.IVsPersistSolutionOpts.LoadUserOptions"]/*' />
        /// <internalonly/>
        /// <devdoc>
        /// IVsPersistSolutionOpts implementation.
        /// Called when a solution is opened, and allows us to inspect our options.
        /// </devdoc>
        int IVsPersistSolutionOpts.LoadUserOptions(IVsSolutionPersistence pPersistance, uint options) {

            int hr = NativeMethods.S_OK;
            if ((options & (uint)__VSLOADUSEROPTS.LUO_OPENEDDSW) != 0) {
                return hr;
            }

            if (_optionKeys != null) {
                foreach(string key in _optionKeys) {
                    hr = pPersistance.LoadPackageUserOpts(this, key);
                    if (NativeMethods.Failed(hr))
                        break;
                }
            }

            NativeMethods.ThrowOnFailure(hr);
            return hr;
        }

        /// <include file='doc\Package.uex' path='docs/doc[@for="Package.IVsPersistSolutionOpts.ReadUserOptions"]/*' />
        /// <internalonly/>
        /// <devdoc>
        /// IVsPersistSolutionOpts implementation.
        /// Called by the shell to load our solution options.
        /// </devdoc>
        int IVsPersistSolutionOpts.ReadUserOptions(IStream pStream, string pszKey) {

            NativeMethods.DataStreamFromComStream stream = new NativeMethods.DataStreamFromComStream(pStream);
            using (stream) {
                OnLoadOptions(pszKey, stream);
            }

            return NativeMethods.S_OK;
        }

        /// <include file='doc\Package.uex' path='docs/doc[@for="Package.IVsPersistSolutionOpts.SaveUserOptions"]/*' />
        /// <internalonly/>
        /// <devdoc>
        /// IVsPersistSolutionOpts implementation.
        /// Called by the shell when we are to persist our service options
        /// </devdoc>
        int IVsPersistSolutionOpts.SaveUserOptions(IVsSolutionPersistence pPersistance) {

            if (_optionKeys != null) {
                foreach(string key in _optionKeys) {
                    NativeMethods.ThrowOnFailure( pPersistance.SavePackageUserOpts(this, key) );
                }
            }

            return NativeMethods.S_OK;
        }

        /// <include file='doc\Package.uex' path='docs/doc[@for="Package.IVsPersistSolutionOpts.WriteUserOptions"]/*' />
        /// <internalonly/>
        /// <devdoc>
        /// IVsPersistSolutionOpts implementation.
        /// Called by the shell to persist our solution options.  Here is where the service
        /// can persist any goo that it cares about.
        /// </devdoc>
        int IVsPersistSolutionOpts.WriteUserOptions(IStream pStream, string pszKey) {

            NativeMethods.DataStreamFromComStream stream = new NativeMethods.DataStreamFromComStream(pStream);
            using (stream) {
                OnSaveOptions(pszKey, stream);
            }

            return NativeMethods.S_OK;
        }

        /// <include file='doc\Package.uex' path='docs/doc[@for="Package.IVsToolboxItemProvider.GetItemContent"]/*' />
        /// <devdoc>
        /// IVsToolboxItemProvider implementation.
        /// Called by the shell to retrieve the content of a data format in a toolbox item that
        /// was statically registered.  See comments in vsshell100.idl for details.
        /// </devdoc>
        int IVsToolboxItemProvider.GetItemContent(string itemId, /* CLIPFORMAT */ ushort format, out /* HGLOBAL */ IntPtr global) {
            if (zombie)
                Marshal.ThrowExceptionForHR(NativeMethods.E_UNEXPECTED);

            object data = GetToolboxItemData(itemId, DataFormats.GetFormat(format));

            if (data == null) {
                global = IntPtr.Zero;
            }
            else {
                // OleDataObject has a nice facility for serializing objects into hglobals, so
                // let's take advantage of it.
                var dataObj = new OleDataObject();
                dataObj.SetData(DataFormats.GetFormat(format).Name, data);

                FORMATETC[] fetc = new FORMATETC[] { new FORMATETC() };
                fetc[0].cfFormat = format;
                fetc[0].dwAspect = (uint)DVASPECT.DVASPECT_CONTENT;
                fetc[0].lindex = -1;
                fetc[0].tymed = (uint)TYMED.TYMED_HGLOBAL;

                STGMEDIUM[] stm = new STGMEDIUM[] { new STGMEDIUM() };
                stm[0].tymed = (uint)TYMED.TYMED_HGLOBAL;

                ((Microsoft.VisualStudio.OLE.Interop.IDataObject)dataObj).GetData(fetc, stm);
                global = stm[0].unionmember;
            }
            return NativeMethods.S_OK;
        }

        /// <include file='doc\Package.uex' path='docs/doc[@for="Package.GetToolboxItemData"]' />
        /// <devdoc>
        /// Given a toolbox item "unique ID" and a data format identifier, returns the content of
        /// the data format.  If this is not implemented, the shell will fall back to a call to
        /// IVsPackage.ResetDefaults (which invokes the ToolboxInitialized or ToolboxUpgraded
        /// event).
        /// </devdoc>
        protected virtual object GetToolboxItemData(string itemId, DataFormats.Format format) {
            if (string.IsNullOrEmpty(itemId)) {
                throw new ArgumentNullException("itemId");
            }

            // Try cache first
            System.Windows.Forms.IDataObject tbxDataObj;
            if (_tbxItemDataCache.TryGetValue(itemId, out tbxDataObj)) {
                if (tbxDataObj.GetDataPresent(format.Name)) {
                    return tbxDataObj.GetData(format.Name);
                }
                else {
                    throw new InvalidOperationException(string.Format(Resources.Culture, Resources.Toolbox_UnsupportedFormat, format.Name));
                }
            }

            string typeName;
            string assemblyName;
            int idx = itemId.IndexOf(",");
            if (idx == -1) {
                Debug.Fail("Invalid toolbox item ID: " + itemId);
                throw new InvalidOperationException(string.Format(Resources.Culture, Resources.Toolbox_InvalidItemId, itemId));
            }
            else {
                typeName = itemId.Substring(0, idx).Trim();
                assemblyName = itemId.Substring(idx + 1).Trim();
            }

            if (assemblyName.IndexOf(",") == -1) {
                // Must use the assembly enumeration service to locate the assembly.
                Microsoft.VisualStudio.AssemblyEnumerationService enumSvc = 
                    new Microsoft.VisualStudio.AssemblyEnumerationService(this);
                foreach (AssemblyName an in enumSvc.GetAssemblyNames(assemblyName)) {
                    assemblyName = an.FullName;
                    break;
                }
            }

            Assembly a = Assembly.Load(assemblyName);
            Debug.Assert(a != null, "Assembly " + assemblyName + " not found on machine");

            if (a != null) {
                Type t = a.GetType(typeName);
                Debug.Assert(t != null, "Type " + itemId + " not found on machine");
                if (t != null) {
                    ToolboxItem item = ToolboxService.GetToolboxItem(t);
                    Debug.Assert(item != null, "Tool " + assemblyName + ":" + itemId + " does not offer a toolbox item");
                    if (item != null) {
                        ToolboxItemContainer container = new ToolboxItemContainer(item);
                        tbxDataObj = container.ToolboxData;
                        // Missed in cache, so save it in cache now
                        _tbxItemDataCache.Add(itemId, tbxDataObj);

                        if (tbxDataObj.GetDataPresent(format.Name)) {
                            return tbxDataObj.GetData(format.Name);
                        }
                        else {
                            throw new InvalidOperationException(string.Format(Resources.Culture, Resources.Toolbox_UnsupportedFormat, format.Name));
                        }
                    }
                }
            }

            throw new InvalidOperationException(string.Format(Resources.Culture, Resources.Toolbox_ItemNotFound, itemId));
        }

        /// <devdoc>
        ///     This class derives from container to provide a service provider
        ///     connection to the package.
        /// </devdoc>
        private sealed class PackageContainer : Container {
            private IUIService _uis;
            private AmbientProperties _ambientProperties;

            private IServiceProvider _provider;

            /// <devdoc>
            ///     Creates a new container using the given service provider.
            /// </devdoc>
            internal PackageContainer(IServiceProvider provider) {
                _provider = provider;
            }

            /// <devdoc>
            ///     Override to GetService so we can route requests
            ///     to the package's service provider.
            /// </devdoc>
            protected override object GetService(Type serviceType) {
                if (serviceType == null) {
                    throw new ArgumentNullException("serviceType");
                }
                if (_provider != null) {
                    if (serviceType.IsEquivalentTo(typeof(AmbientProperties))) {
                        if (_uis == null) {
                            _uis = (IUIService)_provider.GetService(typeof(IUIService));
                        }
                        if (_ambientProperties == null) {
                            _ambientProperties = new AmbientProperties();
                        }
                        if (_uis != null) {
                            // update the _ambientProperties in case the styles have changed
                            // since last time.
                            _ambientProperties.Font = (Font)_uis.Styles["DialogFont"];
                        }
                        return _ambientProperties;
                    }
                    object service = _provider.GetService(serviceType);

                    if (service != null) {
                        return service;
                    }
                }
                return base.GetService(serviceType);
            }
        }

        /// <include file='doc\Package.uex' path='docs/doc[@for="Package.GetGlobalService"]' />
        /// <devdoc>
        /// Get a service proffered globally by VisualStudio or one of its package.
        /// This is equivalent to calling GetService() on an instance of a package 
        /// that proffer no service itself.
        /// </devdoc>
        /// <param name="serviceType">Type corresponding to the Service being requested</param>
        /// <returns>The service being requested if available, otherwise null</returns>
        static public object GetGlobalService(Type serviceType)
        {
            object service = null;

            ServiceProvider globalProvider = ServiceProvider.GlobalProvider;

            Debug.Assert(globalProvider != null, "The global service provider is unavailable. You may be calling from the wrong thread.");

            if (globalProvider != null)
            {
                service = globalProvider.GetService(serviceType);
            }
            return service;
        }

        /// <devdoc>
        ///     This class contains a service that is being promoted to vS.  
        /// </devdoc>
        private sealed class ProfferedService {
            public object Instance;
            public uint   Cookie;
        }

        /// <devdoc>
        /// Internal zombie flag indicates that VS is shutting us down.
        /// </devdoc>
        private bool zombie = false;

        /// <include file='doc\Package.uex' path='docs/doc[@for="Package.Zombied"]/*' />
        /// <devdoc>
        /// Zombie flag indicates that the package is being closed.
        /// </devdoc>
        public bool Zombied {
            get {
                return zombie;
            }
        }
    }
}

