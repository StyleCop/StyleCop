// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PropertyDialog.cs" company="https://github.com/StyleCop">
//   MS-PL
// </copyright>
// <license>
//   This source code is subject to terms and conditions of the Microsoft 
//   Public License. A copy of the license can be found in the License.html 
//   file at the root of this distribution. If you cannot locate the  
//   Microsoft Public License, please send an email to dlr@microsoft.com. 
//   By using this source code in any fashion, you are agreeing to be bound 
//   by the terms of the Microsoft Public License. You must not remove this 
//   notice, or any other, from this software.
// </license>
// <summary>
//   Hosts a <see cref="PropertyControl" /> and provides standard property page buttons.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Globalization;
    using System.IO;
    using System.Security;
    using System.Windows.Forms;
    using System.Xml;

    /// <summary>
    /// Hosts a <see cref="PropertyControl"/> and provides standard property page buttons.
    /// </summary>
    internal partial class PropertyDialog : Form, IPropertyControlHost
    {
        #region Fields

        /// <summary>
        /// The context for the property control.
        /// </summary>
        private readonly object[] context;

        /// <summary>
        /// The StyleCop core instance.
        /// </summary>
        private readonly StyleCopCore core;

        /// <summary>
        /// The callback method for help.
        /// </summary>
        private readonly Help helpCallback;

        /// <summary>
        /// The page set ID.
        /// </summary>
        private readonly string id;

        /// <summary>
        /// The property pages to display.
        /// </summary>
        private readonly IList<IPropertyControlPage> pages;

        /// <summary>
        /// The settings file being edited.
        /// </summary>
        private readonly WritableSettings settingsFile;

        /// <summary>
        /// Indicates whether settings have been changed on any page.
        /// </summary>
        private bool settingsChanged;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the PropertyDialog class.
        /// </summary>
        public PropertyDialog()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the PropertyDialog class.
        /// </summary>
        /// <param name="pages">
        /// The array of pages to display on the property control.
        /// </param>
        /// <param name="settingsFile">
        /// The file that contains the settings being edited.
        /// </param>
        /// <param name="id">
        /// A unique ID that describes this set of property pages.
        /// </param>
        /// <param name="core">
        /// The StyleCop core instance.
        /// </param>
        /// <param name="helpCallback">
        /// Callback method for help, or null for no help.
        /// </param>
        /// <param name="context">
        /// The context to the send to the property page control.
        /// </param>
        public PropertyDialog(IList<IPropertyControlPage> pages, WritableSettings settingsFile, string id, StyleCopCore core, Help helpCallback, params object[] context)
        {
            Param.Assert(pages != null && pages.Count > 0, "pages", "Cannot be null or empty");
            Param.Assert(settingsFile != null && settingsFile.Loaded, "settingsFile", "The settings file must be loaded.");
            Param.AssertValidString(id, "id");
            Param.AssertNotNull(core, "core");
            Param.Ignore(helpCallback);
            Param.Ignore(context);

            this.pages = pages;
            this.settingsFile = settingsFile;
            this.id = id;
            this.core = core;
            this.helpCallback = helpCallback;
            this.context = context;

            this.InitializeComponent();

            this.core.Registry.RestoreWindowPosition(this.id, this, this.Location, this.Size);
        }

        #endregion

        #region Delegates

        /// <summary>
        /// Delegate that is called when the user hits the Help button.
        /// </summary>
        /// <param name="activePage">The currently active page on the control.</param>
        public delegate void Help(IPropertyControlPage activePage);

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets a value indicating whether the user saved any changes to settings on the property pages.
        /// </summary>
        public bool SettingsChanged
        {
            get
            {
                return this.settingsChanged;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Cancels the dialog.
        /// </summary>
        public void Cancel()
        {
            // Close the form.
            this.Close();
        }

        /// <summary>
        /// IPropertyControlHost.Dirty implementation. Enables or disables the Apply button
        /// based upon whether any data on the pages is dirty.
        /// </summary>
        /// <param name="isDirty">
        /// True if the dialog is dirty.
        /// </param>
        public void Dirty(bool isDirty)
        {
            Param.Ignore(isDirty);

            this.apply.Enabled = isDirty;
        }

        #endregion

        #region Methods

        /// <summary>
        /// The form's OnClosing event. Saves the window position.
        /// </summary>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        protected override void OnClosing(CancelEventArgs e)
        {
            Param.Ignore(e);
            base.OnClosing(e);

            this.core.Registry.SaveWindowPositionByForm(this.id, this);
        }

        /// <summary>
        /// The form's OnLoad event. Initializes the PropertyControl object.
        /// </summary>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        protected override void OnLoad(EventArgs e)
        {
            Param.Ignore(e);
            base.OnLoad(e);

            if (this.helpCallback == null)
            {
                this.MoveButton(this.ok, this.cancel);
                this.MoveButton(this.cancel, this.apply);
                this.MoveButton(this.apply, this.help);
                this.help.Visible = false;
            }

            this.apply.Enabled = false;

            try
            {
                this.properties.Initialize(this, this.pages, this.settingsFile, this.core, this.context);
            }
            catch (IOException ioex)
            {
                AlertDialog.Show(
                    this.core, 
                    this, 
                    string.Format(CultureInfo.CurrentUICulture, Strings.LocalSettingsNotOpenedOrCreated, ioex.Message), 
                    Strings.Title, 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);

                this.Close();
            }
            catch (SecurityException secex)
            {
                AlertDialog.Show(
                    this.core, 
                    this, 
                    string.Format(CultureInfo.CurrentUICulture, Strings.LocalSettingsNotOpenedOrCreated, secex.Message), 
                    Strings.Title, 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);

                this.Close();
            }
            catch (UnauthorizedAccessException unauthex)
            {
                AlertDialog.Show(
                    this.core, 
                    this, 
                    string.Format(CultureInfo.CurrentUICulture, Strings.LocalSettingsNotOpenedOrCreated, unauthex.Message), 
                    Strings.Title, 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);

                this.Close();
            }
            catch (XmlException xmlex)
            {
                AlertDialog.Show(
                    this.core, 
                    this, 
                    string.Format(CultureInfo.CurrentUICulture, Strings.LocalSettingsNotOpenedOrCreated, xmlex.Message), 
                    Strings.Title, 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);

                this.Close();
            }
        }

        /// <summary>
        /// Moves the first button into the same position as the second button.
        /// </summary>
        /// <param name="source">
        /// The button to move.
        /// </param>
        /// <param name="dest">
        /// The button to move the first button on top of.
        /// </param>
        private void MoveButton(Button source, Button dest)
        {
            Param.AssertNotNull(source, "source");
            Param.AssertNotNull(dest, "dest");

            this.layoutPanel.SetRow(source, this.layoutPanel.GetRow(dest));
            this.layoutPanel.SetColumn(source, this.layoutPanel.GetColumn(dest));
        }

        /// <summary>
        /// Called when the user clicks the Apply button.
        /// </summary>
        /// <param name="sender">
        /// The event sender.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private void ApplyClick(object sender, EventArgs e)
        {
            Param.Ignore(sender, e);

            bool changed;
            PropertyControlSaveResult result = this.properties.Apply(out changed);

            if (changed)
            {
                this.settingsChanged = true;
            }

            // The dialog is closed when an error occurs while saving the settings. 
            // This can result in an undesirable user experience, since the settings 
            // changes may be lost when a save error occurs, however, this is the best 
            // solution for now until the property pages can recover from a save error 
            // and save themselves properly a second or third time.
            if (result == PropertyControlSaveResult.SaveError)
            {
                this.Close();
            }
        }

        /// <summary>
        /// Called when the user clicks the Cancel button.
        /// </summary>
        /// <param name="sender">
        /// The event sender.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private void CancelClick(object sender, EventArgs e)
        {
            Param.Ignore(sender, e);
            this.Close();
        }

        /// <summary>
        /// Called when the user clicks the Help button.
        /// </summary>
        /// <param name="sender">
        /// The event sender.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private void HelpClick(object sender, EventArgs e)
        {
            Param.Ignore(sender, e);

            if (this.helpCallback != null)
            {
                this.helpCallback(this.properties.ActivePage);
            }
        }

        /// <summary>
        /// Called when the user clicks the OK button.
        /// </summary>
        /// <param name="sender">
        /// The event sender.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private void OkClick(object sender, EventArgs e)
        {
            Param.Ignore(sender, e);

            bool changed;
            PropertyControlSaveResult result = this.properties.Apply(out changed);

            if (changed)
            {
                this.settingsChanged = true;
            }

            // The dialog is closed whenever the settings were successfully saved,
            // or when an error occurred while saving the settings. This can result
            // in an undesirable user experience, since the settings changes may 
            // be lost when a save error occurs, however, this is the best solution
            // for now until the property pages can recover from a save error and 
            // save themselves properly a second or third time.
            if (result == PropertyControlSaveResult.Success)
            {
                this.Close();
            }
        }

        #endregion
    }
}