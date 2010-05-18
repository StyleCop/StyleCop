//------------------------------------------------------------------------------
// <copyright file="DialogPage.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>                                                                
//------------------------------------------------------------------------------

namespace Microsoft.VisualStudio.Shell {

    using Microsoft.VisualStudio.OLE.Interop;
    using Microsoft.VisualStudio.Shell.Interop;
    using System.Windows.Forms.Design;
    using Microsoft.Win32;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.ComponentModel.Design;
    using System.Diagnostics;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    using IOleServiceProvider = Microsoft.VisualStudio.OLE.Interop.IServiceProvider;
    using IServiceProvider = System.IServiceProvider;

    /// <include file='doc\DialogPage.uex' path='docs/doc[@for="DialogPage"]' />
    /// <devdoc>
    ///     DialogPage encompasses a tools dialog page.  The default dialog page 
    ///     examines itself for public properties, and offers these properties 
    ///     to the user in a property grid.  You can customize this behavior, 
    ///     however by overriding various methods on the page.  The dialog 
    ///     page will automatically persist any changes made to it to the user's 
    ///     section of the registry, provided that those properties provide 
    ///     support for to/from string conversions on their type converter.
    /// </devdoc>
    [CLSCompliant(false),ComVisible(true)]
    public class DialogPage : Component,
        IWin32Window,
        IProfileManager {

        private IWin32Window     _window;
        private DialogSubclass   _subclass;
        private DialogContainer _container;
        private string           _settingsPath;
        private bool             _initializing = false;
        private bool             _uiActive = false;
        private bool             _propertyChangedHooked = false;
        private EventHandler     _onPropertyChanged;

        /// <include file='doc\DialogPage.uex' path='docs/doc[@for="DialogPage.DialogPage"]' />
        /// <devdoc>
        /// Constructs the Dialog Page.
        /// </devdoc>
        public DialogPage() {
            HookProperties(true);
        }

        /// <include file='doc\DialogPage.uex' path='docs/doc[@for="DialogPage.AutomationObject"]' />
        /// <devdoc>
        ///     The object the dialog page is going to browse.  The
        ///     default returns "this", but you can change it to
        ///     browse any object you want.
        /// </devdoc>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual object AutomationObject {
            get {
                return this;
            }
        }
        
        /// <include file='doc\DialogPage.uex' path='docs/doc[@for="DialogPage".Site]' />
        /// <devdoc>
        ///     Override for the site property.  This override is used so we can
        ///     load and save our settings at the appropriate time.
        /// </devdoc>
        public override ISite Site {
            get {
                return base.Site;
                
            }
            set {
                if (value == null && base.Site != null) {
                    // This is dangerous at shut down time and is causing
                    // bad ExecutionEngineExceptions. It's also entirely redundant.
                    //SaveSettingsToStorage();
                }

                base.Site = value;

                if (value != null) {
                    LoadSettingsFromStorage();
                }
            }
        }
        
        /// <include file='doc\DialogPage.uex' path='docs/doc[@for="DialogPage".Window]' />
        /// <devdoc>
        ///     The window this dialog page will use for its UI.
        ///     This window handle must be constant, so if you are
        ///     returning a Windows Forms control you must make sure
        ///     it does not recreate its handle.  If the window object
        ///     implements IComponent it will be sited by the 
        ///     dialog page so it can get access to global services.
        /// </devdoc>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected virtual IWin32Window Window {
            get {
                PropertyGrid grid = new PropertyGrid();
                grid.Location = new Point(0,0);
                grid.ToolbarVisible = false;
                grid.CommandsVisibleIfAvailable = false;
                grid.SelectedObject = AutomationObject;
                return grid;
            }
        }
        
        /// <include file='doc\DialogPage.uex' path='docs/doc[@for="DialogPage.Dispose"]' />
        /// <devdoc>
        ///     Disposes this object.
        /// </devdoc>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {

                if (_container != null)
                {
                    try
                    {
                        _container.Dispose();
                    }
                    catch (Exception)
                    {
                        Debug.Fail("Failed to dispose container");
                    }
                    _container = null;
                }

                if (_window != null && _window is IDisposable)
                {
                    try
                    {
                    ((IDisposable)_window).Dispose();
                    }
                    catch (Exception)
                    {
                        Debug.Fail("Failed to dispose window");
                    }
                    _window = null;
                }

                if (_subclass != null)
                {
                    _subclass = null;
                }

                HookProperties(false);
            }
            base.Dispose(disposing);
        }
        
        /// <include file='doc\DialogPage.uex' path='docs/doc[@for="DialogPage.LoadSettingsFromStorage"]' />
        /// <devdoc>
        ///     This method is called when the dialog page should load
        ///     its default settings from the registry.  The default
        ///     implementation gets the Package service, gets the
        ///     user registry key, and reads in all properties for this
        ///     page that could be converted from strings.
        /// </devdoc>
        public virtual void LoadSettingsFromStorage() {
            _initializing = true;
            try {
                Package package = (Package)GetService(typeof(Package));
                Debug.Assert(package != null, "No package service; we cannot load settings");
                if (package != null) {
                    using (RegistryKey rootKey = package.UserRegistryRoot) {

                        string path = this.SettingsRegistryPath;
                        object automationObject = this.AutomationObject;

                        RegistryKey key = rootKey.OpenSubKey(path, false /* writable */);
                        if (key != null) {
                            using (key) {

                                string[] valueNames = key.GetValueNames();
                                PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(automationObject);

                                foreach(string valueName in valueNames) {
                                    string value = key.GetValue(valueName).ToString();

                                    PropertyDescriptor prop = properties[valueName];
                                    if (prop != null && prop.Converter.CanConvertFrom(typeof(string))) {
                                        prop.SetValue(automationObject, prop.Converter.ConvertFromInvariantString(value));
                                    }
                                }
                            }
                        }
                    }
                }
            }
            finally {
                _initializing = false;
            }
            HookProperties(true); //hook if this failed during construction.
        }

        /// <include file='doc\DialogPage.uex' path='docs/doc[@for="DialogPage.LoadSettingsFromXml"]' />
        /// <devdoc>
        ///     This method is called when the dialog page should load
        ///     its default settings from the profile XML file.  
        /// </devdoc>
        public virtual void LoadSettingsFromXml(IVsSettingsReader reader) {
            _initializing = true;
            try {
                object automationObject = this.AutomationObject;
                PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(automationObject, new Attribute[] {DesignerSerializationVisibilityAttribute.Visible});

                foreach(PropertyDescriptor property in properties) {
                    TypeConverter converter = property.Converter;
                    if (converter.CanConvertTo(typeof(string)) && converter.CanConvertFrom(typeof(string))) {
                        // read from the xml feed
                        string value = null;
                        object cv = null;
                        try {
                            if ( NativeMethods.Succeeded(reader.ReadSettingString(property.Name, out value)) && (value != null) )
                            {
                                cv = property.Converter.ConvertFromInvariantString(value);
                            }
                        } catch (Exception) {
                            // ReadSettingString throws an exception if the property 
                            // is not found and we also catch ConvertFromInvariantString
                            // exceptions so that we gracefully handle bad vssettings.
                        }
                        //not all values have to be present
                        if (cv != null) { 
                            property.SetValue(automationObject, cv);
                        }
                    }
                }
            }
            finally {
                _initializing = false;    //we have loaded from storage
            }
            HookProperties(true); //hook if this failed during construction.
        }

        /// <include file='doc\DialogPage.uex' path='docs/doc[@for="DialogPage.ResetSettings"]' />
        /// <devdoc>Override this method in order to reset your settings to your default values.</devdoc>
        public virtual void ResetSettings() {
        }

        /// <devdoc>
        /// This function hooks property change events so that we automatically serialize
        /// if the value changes outside of UI and loading
        /// </devdoc>
        private void HookProperties(bool hook) {
            if (_propertyChangedHooked != hook)  {
                
                if (_onPropertyChanged == null)
                    _onPropertyChanged = new EventHandler(OnPropertyChanged);

                object automationObject = null;
                try
                {
                    automationObject = this.AutomationObject;
                }
                catch (Exception e)
                {
                    Debug.Fail(e.ToString());  //assert this so we don't ship bad code.
                }

                if (automationObject!= null)  {
                    PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(automationObject, new Attribute[] {DesignerSerializationVisibilityAttribute.Visible});

                    foreach(PropertyDescriptor property in properties) {
                        if (hook) 
                            property.AddValueChanged(automationObject, _onPropertyChanged);
                        else
                            property.RemoveValueChanged(automationObject, _onPropertyChanged);
                    }
                    _propertyChangedHooked = hook;
                }
            }
        }

        // Convert an item property value changed event into a list changed event
        private void OnPropertyChanged(object sender, EventArgs e)  {
            if (!_initializing && !_uiActive)
                SaveSettingsToStorage();
        }

        /// <include file='doc\DialogPage.uex' path='docs/doc[@for="DialogPage.OnActivate"]' />
        /// <devdoc>
        ///     This method is called when VS wants to activate this
        ///     page.  If true is returned, the page is activated.
        /// </devdoc>
        protected virtual void OnActivate(CancelEventArgs e) {
            _uiActive = true;
        }
        
        /// <include file='doc\DialogPage.uex' path='docs/doc[@for="DialogPage.OnClosed"]' />
        /// <devdoc>
        ///     This event is raised when the page is closed.   
        /// </devdoc>
        protected virtual void OnClosed(EventArgs e) {
            _uiActive = false;
            LoadSettingsFromStorage(); //reload whatever is saved in storage so if someone is accessing this object, it will have the correct values.
        }

        /// <include file='doc\DialogPage.uex' path='docs/doc[@for="DialogPage.OnDeactivate"]' />
        /// <devdoc>
        ///     This method is called when VS wants to deatviate this
        ///     page.  If true is returned, the page is deactivated.
        /// </devdoc>
        protected virtual void OnDeactivate(CancelEventArgs e) {
        }

        /// <include file='doc\DialogPage.uex' path='docs/doc[@for="DialogPage.OnApply"]' />
        /// <devdoc>
        ///     This method is called when VS wants to save the user's 
        ///     changes then the dialog is dismissed.
        /// </devdoc>
        protected virtual void OnApply(PageApplyEventArgs e) {
            SaveSettingsToStorage();
        }

        /// <include file='doc\DialogPage.uex' path='docs/doc[@for="DialogPage.SaveSettingsToStorage"]' />
        /// <devdoc>
        ///     This method does the reverse of LoadSettingsFromStorage.
        /// </devdoc>
        public virtual void SaveSettingsToStorage() {
            Package package = (Package)GetService(typeof(Package));
            Debug.Assert(package != null, "No package service; we cannot load settings");
            if (package != null) {
                using (RegistryKey rootKey = package.UserRegistryRoot) {

                    string path = SettingsRegistryPath;
                    object automationObject = this.AutomationObject;
                    RegistryKey key = rootKey.OpenSubKey(path, true /* writable */);
                    if (key == null) {
                        key = rootKey.CreateSubKey(path);
                    }

                    using (key) {

                        PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(automationObject, new Attribute[] { DesignerSerializationVisibilityAttribute.Visible });

                        foreach(PropertyDescriptor property in properties) {
                            TypeConverter converter = property.Converter;
                            if (converter.CanConvertTo(typeof(string)) && converter.CanConvertFrom(typeof(string))) {
                                key.SetValue(property.Name, converter.ConvertToInvariantString(property.GetValue(automationObject)));
                            }
                        }
                    }
                }
            }
        }

        /// <include file='doc\DialogPage.uex' path='docs/doc[@for="DialogPage.SaveSettingsToXml"]' />
        /// <devdoc>
        ///     This method does the reverse of LoadSettingsFromXml.
        /// </devdoc>
        public virtual void SaveSettingsToXml(IVsSettingsWriter writer) {
            object automationObject = this.AutomationObject;
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(automationObject, new Attribute[] {DesignerSerializationVisibilityAttribute.Visible});
            // [clovett] Sort the names so that tests can depend on the order returned, otherwise the order changes
            // randomly based on some internal hashtable seed.  Besides it makes it easier for the user to
            // read the .vssettings files.
            ArrayList sortedNames = new ArrayList();
            foreach (PropertyDescriptor property in properties) {
                sortedNames.Add(property.Name);
            }
            sortedNames.Sort();
            foreach(string name in sortedNames) {
                PropertyDescriptor property = properties[name];
                TypeConverter converter = property.Converter;
                if (converter.CanConvertTo(typeof(string)) && converter.CanConvertFrom(typeof(string))) {
                    NativeMethods.ThrowOnFailure(
                        writer.WriteSettingString(property.Name, converter.ConvertToInvariantString(property.GetValue(automationObject)))
                    );
                }
            }
        }

        /// <include file='doc\DialogPage.uex' path='docs/doc[@for="DialogPage.SettingsRegistryPath"]' />
        /// <devdoc>
        /// This is where the settings are stored under [UserRegistryRoot]\DialogPage, the default
        /// is the full type name of your AutomationObject.
        /// </devdoc>
        protected string SettingsRegistryPath {
            get {
                if (this._settingsPath == null) {
                    this._settingsPath = "DialogPage\\" + this.AutomationObject.GetType().FullName;
                }
                return this._settingsPath;
            }
            set {
                this._settingsPath = value;
            }
        }

        /// <include file='doc\DialogPage.uex' path='docs/doc[@for="DialogPage.IWin32Window.Handle"]/*' />
        /// <internalonly/>
        /// <devdoc>
        /// IWin32Window implementation.  This just delegates to the Window property.
        /// </devdoc>
        IntPtr IWin32Window.Handle {
            get {

                if (_window == null) {
                    _window = Window;
                    if (_window is IComponent) {
                        if (_container == null) {
                            _container = new DialogContainer(Site);
                        }
                        _container.Add((IComponent)_window);
                    }
                    if (_subclass == null) {
                        _subclass = new DialogSubclass(this);
                    }
                }

                if (_subclass.Handle != _window.Handle) {
                    _subclass.AssignHandle(_window.Handle);
                }

                return _window.Handle;
            }
        }

        internal void ResetContainer() {
            if (_container != null && _window is IComponent) {
                // This resets the AmbientProperties.
                _container._ambientProperties = null;
                _container.Remove((IComponent)_window);                
                _container.Add((IComponent)_window);
            }
        }

        /// <include file='doc\DialogPage.uex' path='docs/doc[@for="DialogPage.ApplyKind"]/*' />
        /// <devdoc>
        /// Apply behavior.  Allows the OnApply event to be canceled with optional navigation instructions.
        /// </devdoc>
        public enum ApplyKind { 
            /// <summary>
            /// Apply - Allows the changes to be applied
            /// </summary>
            Apply = 0, 

            /// <summary>
            /// CancelNavigate - Cancels the apply event and navigates to the page cancelling the event.
            /// </summary>
            Cancel = 1, 
            
            /// <summary>
            /// CancelNoNavigate - Cancels the apply event and returns the active page, not the page cancelling the event.
            /// </summary>
            CancelNoNavigate = 2 
        };

        /// <include file='doc\DialogPage.uex' path='docs/doc[@for="DialogPage.PageApplyEventArgs"]/*' />
        /// <devdoc>
        /// Event arguments to allow the OnApply method to indicate how to handle the apply event.
        /// </devdoc>
        protected class PageApplyEventArgs : EventArgs
        {
            private ApplyKind _apply = ApplyKind.Apply;

            /// <include file='doc\DialogPage.uex' path='docs/doc[@for="DialogPage.AutomationObject.ApplyBehavior"]' />
            public ApplyKind ApplyBehavior
            {
                get
                {
                    return _apply;
                }
                set
                {
                    _apply = value;
                }
            }
        }

        /// <devdoc>
        ///     This class derives from container to provide a service provider
        ///     connection to the dialog page.
        /// </devdoc>
        private sealed class DialogContainer : Container {

            private IServiceProvider _provider;
            internal AmbientProperties _ambientProperties;

            /// <devdoc>
            ///     Creates a new container using the given service provider.
            /// </devdoc>
            public DialogContainer(IServiceProvider provider) {
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
                if (serviceType == typeof(AmbientProperties)) {
                    if (_ambientProperties == null) {
                        IUIService uis = GetService(typeof(IUIService)) as IUIService;
                        _ambientProperties = new AmbientProperties();
                        _ambientProperties.Font = (Font)uis.Styles["DialogFont"];
                    }
                    return _ambientProperties;
                }
                if (_provider != null) {
                    object service = _provider.GetService(serviceType);
                    if (service != null) {
                        return service;
                    }
                }
                return base.GetService(serviceType);
            }
        }

        /// <devdoc>
        ///     This class derives from NativeWindow to provide a hook
        ///     into the window handle.  We use this hook so we can
        ///     respond to property sheet window messages that VS
        ///     will send us.
        /// </devdoc>
        private sealed class DialogSubclass : NativeWindow {

            private DialogPage _page;
            private bool       _closeCalled;

            /// <devdoc>
            ///     Create a new DialogSubclass
            /// </devdoc>
            internal DialogSubclass(DialogPage page) {
                _page = page;
                _closeCalled = false;
            }

            /// <devdoc>
            ///     Override for WndProc to handle our PSP messages
            /// </devdoc>
            protected override void WndProc(ref Message m) {

                CancelEventArgs ce;

                switch (m.Msg) { 
                    case NativeMethods.WM_NOTIFY:
                        NativeMethods.NMHDR nmhdr = (NativeMethods.NMHDR)Marshal.PtrToStructure(m.LParam, typeof(NativeMethods.NMHDR));
                        switch (nmhdr.code) {
                            case NativeMethods.PSN_RESET:
                                _closeCalled = true;
                                _page.OnClosed(EventArgs.Empty);
                                return;
                            case NativeMethods.PSN_APPLY:
                                PageApplyEventArgs pae = new PageApplyEventArgs(); 
                                _page.OnApply(pae);
                                switch (pae.ApplyBehavior)
                                {    
                                    case ApplyKind.Cancel:
                                        m.Result = (IntPtr)NativeMethods.PSNRET_INVALID;
                                        break;

                                    case ApplyKind.CancelNoNavigate:
                                        m.Result = (IntPtr)NativeMethods.PSNRET_INVALID_NOCHANGEPAGE;
                                        break;

                                    case ApplyKind.Apply:
                                    default:
                                        m.Result = IntPtr.Zero;
                                        break;
                                }
                                UnsafeNativeMethods.SetWindowLong(m.HWnd, NativeMethods.DWL_MSGRESULT, m.Result);
                                return;
                            case NativeMethods.PSN_KILLACTIVE:
                                ce = new CancelEventArgs();
                                _page.OnDeactivate(ce);
                                m.Result = (IntPtr)(ce.Cancel ? 1 : 0);
                                UnsafeNativeMethods.SetWindowLong(m.HWnd, NativeMethods.DWL_MSGRESULT, m.Result);
                                return;
                            case NativeMethods.PSN_SETACTIVE:
                                _closeCalled = false;
                                ce = new CancelEventArgs();
                                _page.OnActivate(ce);
                                m.Result = (IntPtr)(ce.Cancel ? -1 : 0);
                                UnsafeNativeMethods.SetWindowLong(m.HWnd, NativeMethods.DWL_MSGRESULT, m.Result);
                                return;
                        }
                        break;
                    case NativeMethods.WM_DESTROY:

                        // we can't tell the difference between OK and Apply (see above), so
                        // if we get a destroy and close hasn't been called, make sure we call it
                        //
                        if (!_closeCalled && _page != null) {
                            _page.OnClosed(EventArgs.Empty);
                        }
                        break;
                }

                base.WndProc(ref m);
            }
        }
    }
}

